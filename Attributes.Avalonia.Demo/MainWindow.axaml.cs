using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Attributes.Avalonia.Demo;

[WithStyledProperty(typeof(int), "MyStyledNumber", 5, false, false)]
[WithStyledProperty(typeof(string), "MyStyledString", "my StyledProperty")]
[WithStyledProperty(typeof(MyModel), "MyStyledObj")]
[WithDirectProperty(typeof(double), "MyDirectNumber")]
[WithDirectProperty(typeof(string), "MyDirectString", "my DirectProperty")]
[WithDirectProperty(typeof(MyModel), "MyDirectObj")]
[WithDirectProperty(typeof(string), "MyMessage")]
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MyStyledNumber++;
        MyStyledString += " test";
        MyStyledObj ??= new MyModel();
        MyStyledObj.Value++;

        MyDirectNumber++;
        MyDirectString += " test";
        MyDirectObj ??= new MyModel();
        MyDirectObj.Value++;
        
        MyMessage = "";
    }
}