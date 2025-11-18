using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Attributes.Avalonia.Demo;

public class MyModel : INotifyPropertyChanged
{
    private int _value;

    public int Value
    {
        get => _value;
        set => _ = SetField(ref _value, value);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }
        
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}