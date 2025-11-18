[English](https://github.com/Ching-bit/Attributes.Avalonia/blob/main/README.md) | 中文

# 說明
這是一個使用特性（Attribute）來簡化Avalonia的屬性定義的簡單項目。

# 安裝
可通過 NuGet 安裝 **Attributes.Avalonia**。

# 使用
1. 在類上使用 **WithStyledProperty** 特性來定義一個StyledProperty。
```
[WithStyledProperty(typeof(string), "MyMessage")]
public partial class MyView : UserControl
{

}
```
上述代碼與以下代碼效果相同：
```
public partial class MyView : UserControl
{
    public string MyMessage
    {
        get => GetValue(MyMessageProperty);
        set => SetValue(MyMessageProperty, value);
    }
    public static readonly StyledProperty<string> MyMessageProperty =
        AvaloniaProperty.Register<MyView, string>(nameof(MyMessage));
}
```

2. 在類上使用 **WithDirectProperty** 特性來定義一個DirectProperty。
```
[WithDirectProperty(typeof(string), "MyMessage")]
public partial class MyView : UserControl
{

}
```
上述代碼與以下代碼效果相同：
```
public partial class MyView : UserControl
{
    public string MyMessage
    {
        get => _myMessage;
        set => SetAndRaise(MyMessageProperty, ref _myMessage, value);
    }
    private string _myMessage;
    public static readonly DirectProperty<MyView, string> MyMessageProperty =
        AvaloniaProperty.RegisterDirect<MyView, string>(nameof(MyMessage), o => o.MyMessage, (o, v) => o.MyMessage = v);
}
```

3. 在類上使用 **WithAttachedProperty** 特性來定義一個附加屬性。
```
[WithAttachedProperty(typeof(TextBox), typeof(bool), "OnlyNumbers")]
public static partial class TextBoxHelper
{

}
```
上述代碼與以下代碼效果相同：
```
public static partial class TextBoxHelper
{
    public static readonly AttachedProperty<bool> OnlyNumbersProperty =
                AvaloniaProperty.RegisterAttached<TextBox, bool>("OnlyNumbers", typeof(TextBoxHelper));

    public static bool GetOnlyNumbers(TextBox host)
    {
        return host.GetValue(OnlyNumbersProperty);
    }

    public static void SetOnlyNumbers(TextBox host, bool value)
    {
        host.SetValue(OnlyNumbersProperty, value);
    }
}
```
