using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Mono.Cecil;

namespace RemoveReference.Fody.Tests
{
    [TestFixture]
    public class WeaverTests
    {
        Assembly assembly;

        [Test]
        public void ValidateReferenceIsRemoved()
        {
            assembly = WeaverHelper.WeaveAssembly();

            AssemblyName[] assemblyNames = assembly.GetReferencedAssemblies();

            Assert.IsTrue(!assemblyNames.Any(x => x.Name == "mscorlib" && x.Version == new Version(2, 0, 5, 0)));
        }

#if(DEBUG)
        [Test]
        public void PeVerify()
        {
            Verifier.Verify(assembly.CodeBase.Remove(0, 8));
        }
#endif

    }
}
