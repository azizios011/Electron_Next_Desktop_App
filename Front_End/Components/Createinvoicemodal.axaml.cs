using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Front_End.Components;

public partial class CreateInvoiceModal : Window
{
    public CreateInvoiceModal()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OnAiSuggestClick(object? sender, RoutedEventArgs e)
    {
        // TODO: Implement AI suggestion logic
    }

    private void OnCreateInvoiceClick(object? sender, RoutedEventArgs e)
    {
        // TODO: Implement invoice creation logic
        Close();
    }
}
