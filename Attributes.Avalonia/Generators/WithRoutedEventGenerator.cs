using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Attributes.Avalonia
{
    [Generator]
    internal class WithRoutedEventGenerator: GeneratorBase<WithRoutedEventAttribute>
    {
        protected override string GenerateCodeOnClass(string namespaceName, string className, IPropertySymbol[] props, IEnumerable<AttributeData> attributes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"#nullable enable
namespace {namespaceName}
{{
    partial class {className}
    {{");

            foreach (AttributeData attribute in attributes)
            {
                string eventArgsType = StringHelper.ToGlobalFullName(((INamedTypeSymbol)attribute.ConstructorArguments[0].Value)?.ToDisplayString());
                string eventName = StringHelper.ToCamel((string)attribute.ConstructorArguments[1].Value);
                int? routingStrategyValue = (int?)attribute.ConstructorArguments[2].Value;
                if (null == eventArgsType || null == eventName)
                {
                    continue;
                }

                List<string> routingStrategyList = new List<string>();
                if ((routingStrategyValue & 1) != 0)
                {
                    routingStrategyList.Add("global::Avalonia.Interactivity.RoutingStrategies.Direct");
                }
                if ((routingStrategyValue & 2) != 0)
                {
                    routingStrategyList.Add("global::Avalonia.Interactivity.RoutingStrategies.Tunnel");
                }
                if ((routingStrategyValue & 4) != 0)
                {
                    routingStrategyList.Add("global::Avalonia.Interactivity.RoutingStrategies.Bubble");
                }

                string routingStrategyCode = routingStrategyList.Count > 0 ?
                    string.Join(" | ", routingStrategyList) :
                    "global::Avalonia.Interactivity.RoutingStrategies.Bubble";
                
                
                sb.Append($@"
        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        public static readonly global::Avalonia.Interactivity.RoutedEvent<{eventArgsType}> {eventName}Event =
            global::Avalonia.Interactivity.RoutedEvent.Register<{className}, {eventArgsType}>(nameof({eventName}), {routingStrategyCode});

        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public event global::System.EventHandler<{eventArgsType}> {eventName}
        {{
            add => AddHandler({eventName}Event, value);
            remove => RemoveHandler({eventName}Event, value);
        }}
");
            }
            
            sb.Append($@"
    }}
}}
");
            
            return sb.ToString();
        }

        protected override string GenerateCodeOnField(string namespaceName, string className, string fieldName, IEnumerable<AttributeData> attributes)
        {
            return string.Empty;
        }
    }
}