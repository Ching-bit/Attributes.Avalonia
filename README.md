English | [中文](https://github.com/Ching-bit/Attributes.Avalonia/blob/main/README.zht.md)

# Description
This is a simple project using attributes to simplify the property definitions of Avalonia.

# Usage
1. Use **WithStyledProperty** attribute on a class to define a StyledProperty.
```
[WithStyledProperty(typeof(string), "MyMessage")]
public partial class MyView : UserControl
{

}
```
which is the same with:
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

2. Use **WithDirectProperty** attribute on a class to define a DirectProperty.
```
[WithDirectProperty(typeof(string), "MyMessage")]
public partial class MyView : UserControl
{

}
```
which is the same with:
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
