using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WithAttachedPropertyAttribute : Attribute
    {
        public WithAttachedPropertyAttribute(Type hostType, Type type, string name,
            object defaultValue = null, bool inherits = false)
        {
            HostType = hostType;
            Type = type;
            Name = name;
            DefaultValue = defaultValue;
            Inherits = inherits;
        }
        
        public Type HostType { get; set; }
        public Type Type { get; set; }
        public string Name { get;set; }
        public object DefaultValue { get; set; }
        public bool Inherits { get; set; }
    }
}