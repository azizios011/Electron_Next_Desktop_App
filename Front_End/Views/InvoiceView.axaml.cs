using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Front_End.Views
{
    public partial class InvoiceView : UserControl
    {
        public event EventHandler? MenuRequested;

        public InvoiceView()
        {
            InitializeComponent();

            var menuButton = this.FindControl<Button>("MenuButton");
            if (menuButton != null)
            {
                menuButton.Click += OnMenuButtonClick;
            }
        }

        private void OnMenuButtonClick(object? sender, RoutedEventArgs e)
        {
            MenuRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
