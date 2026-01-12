using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class WithStyledPropertyAttribute : Attribute
    {
        public WithStyledPropertyAttribute(Type type, string name, object defaultValue = null,
            bool inherits = false, bool enableDataValidation = false, bool nullable = false)
        {
            Type = type;
            Name = name;
            DefaultValue = defaultValue;
            Inherits = inherits;
            EnableDataValidation = enableDataValidation;
            Nullable = nullable;
        }
        
        public Type Type { get; set; }
        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public bool? Inherits { get; set; }
        public bool? EnableDataValidation { get; set; }
        public bool Nullable { get; set; }
    }
}