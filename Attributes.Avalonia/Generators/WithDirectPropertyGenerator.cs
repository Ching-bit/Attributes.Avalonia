using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Attributes.Avalonia
{
    [Generator]
    internal class WithDirectPropertyGenerator : GeneratorBase<WithDirectPropertyAttribute>
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
                string propertyType = StringHelper.ToGlobalFullName(((INamedTypeSymbol)attribute.ConstructorArguments[0].Value)?.ToDisplayString());
                string propertyName = StringHelper.ToCamel((string)attribute.ConstructorArguments[1].Value);
                string memberName = StringHelper.ToLowerCamel(propertyName, "_");
                string defaultValue = attribute.ConstructorArguments[2].ToCSharpString();
                string enableDataValidation = attribute.ConstructorArguments[3].ToCSharpString();

                if (null == propertyType || null == propertyName)
                {
                    continue;
                }

                sb.Append($@"
        [global::System.CodeDom.Compiler.GeneratedCode(""{AppInfo.AppName}"", ""{AppInfo.Version}"")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public {propertyType} {propertyName}
        {{
            get => {memberName};
            set => SetAndRaise({propertyName}Property, ref {memberName}, value);
        }}
        private {propertyType} {memberName}{("null" == defaultValue ? string.Empty : $" = {defaultValue}")};
        public static readonly global::Avalonia.DirectProperty<{className}, {propertyType}> {propertyName}Property =
            global::Avalonia.AvaloniaProperty.RegisterDirect<{className}, {propertyType}>(nameof({propertyName}), o => o.{propertyName}, (o, v) => o.{propertyName} = v{("null" == defaultValue ? string.Empty : $", unsetValue: {defaultValue}")}, enableDataValidation: {enableDataValidation});
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