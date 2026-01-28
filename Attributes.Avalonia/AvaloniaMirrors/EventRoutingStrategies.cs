using System;

namespace Attributes.Avalonia
{
    [Flags]
    public enum EventRoutingStrategies
    {
        Direct = 1,
        Tunnel = 2,
        Bubble = 4,
    }
}