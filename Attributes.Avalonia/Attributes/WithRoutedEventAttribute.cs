using System;

namespace Attributes.Avalonia
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class WithRoutedEventAttribute : Attribute
    {
        public WithRoutedEventAttribute(Type eventArgsType, string name, EventRoutingStrategies routingStrategy = EventRoutingStrategies.Bubble)
        {
            EventArgsType = eventArgsType;
            Name = name;
            RoutingStrategy = routingStrategy;
        }
        
        public Type EventArgsType { get; set; }
        public string Name { get; set; }
        public EventRoutingStrategies RoutingStrategy { get; set; }
    }
}