using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Front_End.Components;

public partial class Navbar : UserControl
{
    public Navbar()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
