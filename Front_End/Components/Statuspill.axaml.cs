using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Front_End.Components;

public partial class Statuspill : UserControl
{
    public Statuspill()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}