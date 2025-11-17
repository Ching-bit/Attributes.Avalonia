using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Attributes.Avalonia
{
    [Generator]
    internal class WithStyledPropertyGenerator : CommonGenerator<WithStyledPropertyAttribute>
    {
        protected override string GenerateCodeOnClass(string namespaceName, string className, IPropertySymbol[] props, IEnumerable<AttributeData> attributes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"
using Avalonia;

namespace {namespaceName}
{{
    partial class {className}
    {{");
            foreach (AttributeData attribute in attributes)
            {
                string propertyType = ((INamedTypeSymbol)attribute.ConstructorArguments[0].Value)?.ToDisplayString();
                string propertyName = StringHelper.ToCamel((string)attribute.ConstructorArguments[1].Value);
                string defaultValue = attribute.ConstructorArguments[2].ToCSharpString();
                string inherits = attribute.ConstructorArguments[3].ToCSharpString();
                string enableDataValidation = attribute.ConstructorArguments[4].ToCSharpString();

                if (null == propertyType || null == propertyName)
                {
                    continue;
                }

                sb.Append($@"
        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public {propertyType} {propertyName}
        {{
            get => GetValue({propertyName}Property);
            set => SetValue({propertyName}Property, value);
        }}
        public static readonly StyledProperty<{propertyType}> {propertyName}Property =
            AvaloniaProperty.Register<{className}, {propertyType}>(nameof({propertyName}){("null" == defaultValue ? string.Empty : $", defaultValue: {defaultValue}")}, inherits: {inherits}, enableDataValidation: {enableDataValidation});
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