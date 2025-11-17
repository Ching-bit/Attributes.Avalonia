using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class WithDirectPropertyAttribute : Attribute
    {
        public WithDirectPropertyAttribute(Type type, string name,
            object defaultValue = null, bool enableDataValidation = false)
        {
            Type = type;
            Name = name;
            DefaultValue = defaultValue;
            EnableDataValidation = enableDataValidation;
        }
        
        public Type Type { get; set; }
        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public bool EnableDataValidation { get; set; }
    }
}