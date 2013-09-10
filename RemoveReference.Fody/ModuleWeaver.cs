using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace RemoveReference.Fody
{
    public class ModuleWeaver
    {
        // Will log an informational message to MSBuild
        public Action<string> LogInfo { get; set; }

        // An instance of Mono.Cecil.ModuleDefinition for processing
        public ModuleDefinition ModuleDefinition { get; set; }

        // Init logging delegates to make testing easier
        public ModuleWeaver()
        {
            LogInfo = m => { };
        }

        public void Execute()
        {
            var namesToRemove = new List<string>();
            var attributesToRemove = new List<CustomAttribute>();
            foreach (var customAttribute in ModuleDefinition.Assembly.CustomAttributes)
            {
                if (customAttribute.AttributeType.Name == "RemoveReferenceAttribute")
                {
                    namesToRemove.Add((string)customAttribute.ConstructorArguments[0].Value);
                    attributesToRemove.Add(customAttribute);
                }
            }

            foreach (var customAttribute in attributesToRemove)
            {
                ModuleDefinition.Assembly.CustomAttributes.Remove(customAttribute);
            }

            var referencesToRemove = ModuleDefinition.AssemblyReferences
                                         .Where(x => namesToRemove.Contains(x.FullName))
                                         .Distinct()
                                         .ToList();
            foreach (var assemblyNameReference in referencesToRemove)
            {
                LogInfo(assemblyNameReference.ToString());
                ModuleDefinition.AssemblyReferences.Remove(assemblyNameReference);
            }

            RemoveReference();
        }

        private void RemoveReference()
        {
            AssemblyNameReference referenceToRemove = ModuleDefinition.AssemblyReferences.FirstOrDefault(x => x.Name == "RemoveReference");
            if (referenceToRemove == null)
            {
                LogInfo("\tNo reference to 'RemoveReference' found. References not modified.");
                return;
            }

            ModuleDefinition.AssemblyReferences.Remove(referenceToRemove);
            LogInfo("\tRemoved reference to 'RemoveReference'.");
        }
    }
}
