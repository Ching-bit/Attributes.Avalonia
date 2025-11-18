using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Attributes.Avalonia
{
    [Generator]
    internal class WithAttachedPropertyGenerator : GeneratorBase<WithAttachedPropertyAttribute>
    {
        protected override string GenerateCodeOnClass(string namespaceName, string className, IPropertySymbol[] props, IEnumerable<AttributeData> attributes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"
namespace {namespaceName}
{{
    partial class {className}
    {{");
            foreach (AttributeData attribute in attributes)
            {
                string hostType = StringHelper.ToGlobalFullName(((INamedTypeSymbol)attribute.ConstructorArguments[0].Value)?.ToDisplayString());
                string propertyType = StringHelper.ToGlobalFullName(((INamedTypeSymbol)attribute.ConstructorArguments[1].Value)?.ToDisplayString());
                string propertyName = StringHelper.ToCamel((string)attribute.ConstructorArguments[2].Value);
                string defaultValue = attribute.ConstructorArguments[3].ToCSharpString();
                string inherits = attribute.ConstructorArguments[4].ToCSharpString();

                if (null == hostType || null == propertyType || null == propertyName)
                {
                    continue;
                }

                sb.Append($@"
        public static readonly global::Avalonia.AttachedProperty<{propertyType}> {propertyName}Property =
                    global::Avalonia.AvaloniaProperty.RegisterAttached<{hostType}, {propertyType}>(""{propertyName}"", typeof({className}){("null" == defaultValue ? string.Empty : $", defaultValue: {defaultValue}")}, inherits: {inherits});

        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static {propertyType} Get{propertyName}({hostType} host)
        {{
            return host.GetValue({propertyName}Property);
        }}

        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void Set{propertyName}({hostType} host, {propertyType} value)
        {{
            host.SetValue({propertyName}Property, value);
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