using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveReference.Fody
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RemoveReferenceAttribute : Attribute
    {
        public RemoveReferenceAttribute(string fullName)
        {
        }
    }
}
