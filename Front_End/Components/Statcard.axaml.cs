using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Front_End.Components;

public partial class Statcard : UserControl
{
    public Statcard()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}