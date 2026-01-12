using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class WithDirectPropertyAttribute : Attribute
    {
        public WithDirectPropertyAttribute(Type type, string name, object defaultValue = null,
            bool enableDataValidation = false, bool nullable = false)
        {
            Type = type;
            Name = name;
            Nullable = nullable;
            DefaultValue = defaultValue;
            EnableDataValidation = enableDataValidation;
        }
        
        public Type Type { get; set; }
        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public bool EnableDataValidation { get; set; }
        public bool Nullable { get; set; }
    }
}