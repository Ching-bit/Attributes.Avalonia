using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Attributes.Avalonia.Demo;

[WithAttachedProperty(typeof(TextBox), typeof(bool), "OnlyNumbers")]
public static partial class TextBoxHelper
{
    static TextBoxHelper()
    {
        OnlyNumbersProperty.Changed.AddClassHandler<TextBox>((control, args) =>
        {
            var newValue = args.GetNewValue<bool>();

            if (newValue)
            {
                control.AddHandler(InputElement.TextInputEvent, OnTextInput, RoutingStrategies.Tunnel);
            }
            else
            {
                control.RemoveHandler(InputElement.TextInputEvent, OnTextInput);
            }
        });
    }

    private static void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text) && !int.TryParse(e.Text, out _))
        {
            e.Handled = true;
        }
    }
}