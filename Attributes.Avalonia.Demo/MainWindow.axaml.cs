using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Attributes.Avalonia.Demo;

[WithStyledProperty(typeof(int), "MyStyledNumber", 5, false, false)]
[WithStyledProperty(typeof(string), "MyStyledString", "my string")]
[WithStyledProperty(typeof(MyClass), "MyStyledObj")]
[WithDirectProperty(typeof(double), "MyDirectNumber")]
[WithDirectProperty(typeof(string), "MyDirectString")]
[WithDirectProperty(typeof(MyClass), "MyDirectObj")]
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
        MyStyledObj ??= new MyClass();
        MyStyledObj.Value++;

        MyDirectNumber++;
        MyDirectString += " test";
        MyDirectObj ??= new MyClass();
        MyDirectObj.Value++;
        
    }
}