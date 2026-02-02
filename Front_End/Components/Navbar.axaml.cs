using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Front_End.Components
{
    public partial class Navbar : UserControl
    {
        public event EventHandler? MenuToggleRequested;

        public Navbar()
        {
            InitializeComponent();
            
            var logoButton = this.FindControl<Button>("LogoButton");
            if (logoButton != null)
            {
                logoButton.Click += OnLogoClick;
            }
        }

        private void OnLogoClick(object? sender, RoutedEventArgs e)
        {
            MenuToggleRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
