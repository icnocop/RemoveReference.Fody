using Mono.Cecil;
using System;

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
            foreach (CustomAttribute customAttribute in ModuleDefinition.Assembly.CustomAttributes)
            {
                if (customAttribute.AttributeType.Name == "RemoveReferenceAttribute")
                {
                    for (int i = ModuleDefinition.AssemblyReferences.Count - 1; i >= 0; i--)
                    {
                        AssemblyNameReference assemblyNameReference = ModuleDefinition.AssemblyReferences[i];

                        if (assemblyNameReference.FullName == (string)customAttribute.ConstructorArguments[0].Value)
                        {
                            LogInfo(assemblyNameReference.ToString());

                            ModuleDefinition.AssemblyReferences.Remove(assemblyNameReference);
                        }
                    }
                }
            }
        }
    }
}
