[English](https://github.com/Ching-bit/Attributes.Avalonia/blob/main/README.md) | 中文

# 說明
這是一個使用特性（Attribute）來簡化Avalonia的屬性定義的簡單項目。

# 使用
1. 在類上使用 **WithStyledProperty** 特性來定義一個StyledProperty.
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
        AvaloniaProperty.Register<MainWindow, string>(nameof(MyMessage));
}
```

2. 在類上使用 **WithDirectProperty** 特性來定義一個DirectProperty.
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
    public static readonly DirectProperty<MainWindow, string> MyMessageProperty =
        AvaloniaProperty.RegisterDirect<MainWindow, string>(nameof(MyMessage), o => o.MyMessage, (o, v) => o.MyMessage = v);
}
