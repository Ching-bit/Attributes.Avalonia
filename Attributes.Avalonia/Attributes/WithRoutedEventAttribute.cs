using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class WithRoutedEventAttribute : Attribute
    {
        public WithRoutedEventAttribute(Type eventArgsType, string name, EventRoutingStrategies eventRoutingStrategy)
        {
            EventArgsType = eventArgsType;
            Name = name;
            EventRoutingStrategy = eventRoutingStrategy;
        }
        
        public Type EventArgsType { get; set; }
        public string Name { get; set; }
        public EventRoutingStrategies EventRoutingStrategy { get; set; }
    }
}