using System;

namespace RemoveReference
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RemoveReferenceAttribute : Attribute
    {
        public RemoveReferenceAttribute(string fullName)
        {
        }
    }
}
