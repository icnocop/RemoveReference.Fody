using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using System.Collections.Generic;

namespace RemoveReference.Fody.Tests
{
    public class WeaverHelper
    {
        public static Assembly WeaveAssembly()
        {
            string assemblyPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\AssemblyToProcess\bin\Debug\AssemblyToProcess.dll"));

            string newAssembly = assemblyPath.Replace(".dll", "2.dll");

            File.Copy(assemblyPath, newAssembly, true);

            ModuleDefinition moduleDefinition = ModuleDefinition.ReadModule(newAssembly);

            ModuleWeaver weavingTask = new ModuleWeaver
            {
                ModuleDefinition = moduleDefinition
            };

            weavingTask.Execute();

            moduleDefinition.Write(newAssembly);

            return Assembly.LoadFile(newAssembly);
        }
    }
}
