using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace Front_End.Components
{
    public partial class Sidebar : UserControl
    {
        public event EventHandler? CloseRequested;
        public event EventHandler<string>? NavigationRequested;
        public event EventHandler<bool>? DarkModeToggled;

        private Button? _dashboardButton;
        private Button? _createInvoiceButton;
        private Path? _dashboardIcon;
        private Path? _createInvoiceIcon;
        private bool _isDarkMode = false;

        // Dark mode UI elements
        private Border? _toggleBg;
        private Border? _toggleKnob;
        private TextBlock? _themeStatusText;
        private Path? _themeIcon;
        private Border? _themeIconBg;
        private Border? _sidebarBorder;
        private TextBlock? _themeModeText;

        public Sidebar()
        {
            InitializeComponent();
            
            var closeButton = this.FindControl<Button>("CloseButton");
            if (closeButton != null)
            {
                closeButton.Click += OnCloseClick;
            }

            _dashboardButton = this.FindControl<Button>("DashboardButton");
            _createInvoiceButton = this.FindControl<Button>("CreateInvoiceButton");
            _dashboardIcon = this.FindControl<Path>("DashboardIcon");
            _createInvoiceIcon = this.FindControl<Path>("CreateInvoiceIcon");

            if (_dashboardButton != null)
            {
                _dashboardButton.Click += OnDashboardClick;
            }

            if (_createInvoiceButton != null)
            {
                _createInvoiceButton.Click += OnCreateInvoiceClick;
            }

            // Dark mode toggle
            var darkModeButton = this.FindControl<Button>("DarkModeButton");
            _toggleBg = this.FindControl<Border>("ToggleBg");
            _toggleKnob = this.FindControl<Border>("ToggleKnob");
            _themeStatusText = this.FindControl<TextBlock>("ThemeStatusText");
            _themeIcon = this.FindControl<Path>("ThemeIcon");
            _themeIconBg = this.FindControl<Border>("ThemeIconBg");
            _sidebarBorder = this.FindControl<Border>("SidebarBorder");
            _themeModeText = this.FindControl<TextBlock>("ThemeModeText");

            if (darkModeButton != null)
            {
                darkModeButton.Click += OnDarkModeClick;
            }
        }

        public void SetDarkMode(bool isDark)
        {
            _isDarkMode = isDark;
            UpdateDarkModeVisuals();
        }

        private void OnDarkModeClick(object? sender, RoutedEventArgs e)
        {
            _isDarkMode = !_isDarkMode;
            UpdateDarkModeVisuals();
            DarkModeToggled?.Invoke(this, _isDarkMode);
        }

        private void UpdateDarkModeVisuals()
        {
            if (_toggleBg != null && _toggleKnob != null && _themeStatusText != null && 
                _themeIcon != null && _themeIconBg != null && _sidebarBorder != null && _themeModeText != null)
            {
                if (_isDarkMode)
                {
                    // Dark mode ON
                    _toggleBg.Background = new SolidColorBrush(Color.Parse("#3B82F6"));
                    _toggleKnob.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right;
                    _toggleKnob.Margin = new Thickness(0, 0, 2, 0);
                    _themeStatusText.Text = "On";
                    
                    // Sun icon for dark mode
                    _themeIcon.Data = Geometry.Parse("M12 7c-2.76 0-5 2.24-5 5s2.24 5 5 5 5-2.24 5-5-2.24-5-5-5zM2 13h2c.55 0 1-.45 1-1s-.45-1-1-1H2c-.55 0-1 .45-1 1s.45 1 1 1zm18 0h2c.55 0 1-.45 1-1s-.45-1-1-1h-2c-.55 0-1 .45-1 1s.45 1 1 1zM11 2v2c0 .55.45 1 1 1s1-.45 1-1V2c0-.55-.45-1-1-1s-1 .45-1 1zm0 18v2c0 .55.45 1 1 1s1-.45 1-1v-2c0-.55-.45-1-1-1s-1 .45-1 1zM5.99 4.58c-.39-.39-1.03-.39-1.41 0-.39.39-.39 1.03 0 1.41l1.06 1.06c.39.39 1.03.39 1.41 0s.39-1.03 0-1.41L5.99 4.58zm12.37 12.37c-.39-.39-1.03-.39-1.41 0-.39.39-.39 1.03 0 1.41l1.06 1.06c.39.39 1.03.39 1.41 0 .39-.39.39-1.03 0-1.41l-1.06-1.06zm1.06-10.96c.39-.39.39-1.03 0-1.41-.39-.39-1.03-.39-1.41 0l-1.06 1.06c-.39.39-.39 1.03 0 1.41s1.03.39 1.41 0l1.06-1.06zM7.05 18.36c.39-.39.39-1.03 0-1.41-.39-.39-1.03-.39-1.41 0l-1.06 1.06c-.39.39-.39 1.03 0 1.41s1.03.39 1.41 0l1.06-1.06z");
                    _themeIcon.Fill = new SolidColorBrush(Color.Parse("#FBBF24"));
                    _themeIconBg.Background = new SolidColorBrush(Color.Parse("#374151"));
                    
                    // Sidebar dark background
                    _sidebarBorder.Background = new SolidColorBrush(Color.Parse("#1F2937"));
                    _sidebarBorder.BorderBrush = new SolidColorBrush(Color.Parse("#374151"));
                    _themeModeText.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    // Light mode
                    _toggleBg.Background = new SolidColorBrush(Color.Parse("#E5E7EB"));
                    _toggleKnob.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
                    _toggleKnob.Margin = new Thickness(2, 0, 0, 0);
                    _themeStatusText.Text = "Off";
                    
                    // Moon icon for light mode
                    _themeIcon.Data = Geometry.Parse("M12 3c-4.97 0-9 4.03-9 9s4.03 9 9 9 9-4.03 9-9c0-.46-.04-.92-.1-1.36-.98 1.37-2.58 2.26-4.4 2.26-2.98 0-5.4-2.42-5.4-5.4 0-1.81.89-3.42 2.26-4.4-.44-.06-.9-.1-1.36-.1z");
                    _themeIcon.Fill = new SolidColorBrush(Color.Parse("#6B7280"));
                    _themeIconBg.Background = new SolidColorBrush(Color.Parse("#F3F4F6"));
                    
                    // Sidebar light background
                    _sidebarBorder.Background = new SolidColorBrush(Colors.White);
                    _sidebarBorder.BorderBrush = new SolidColorBrush(Color.Parse("#F3F4F6"));
                    _themeModeText.Foreground = new SolidColorBrush(Color.Parse("#111827"));
                }
            }
        }

        private void OnCloseClick(object? sender, RoutedEventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnDashboardClick(object? sender, RoutedEventArgs e)
        {
            SetActiveButton("Dashboard");
            NavigationRequested?.Invoke(this, "Dashboard");
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnCreateInvoiceClick(object? sender, RoutedEventArgs e)
        {
            SetActiveButton("CreateInvoice");
            NavigationRequested?.Invoke(this, "CreateInvoice");
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void SetActiveButton(string activeButton)
        {
            // Reset both buttons to inactive state
            if (_dashboardButton != null)
            {
                _dashboardButton.Classes.Clear();
                _dashboardButton.Classes.Add("sidebar-item");
            }
            if (_createInvoiceButton != null)
            {
                _createInvoiceButton.Classes.Clear();
                _createInvoiceButton.Classes.Add("sidebar-item");
            }
            if (_dashboardIcon != null)
            {
                _dashboardIcon.Fill = new SolidColorBrush(Color.Parse("#9CA3AF"));
            }
            if (_createInvoiceIcon != null)
            {
                _createInvoiceIcon.Fill = new SolidColorBrush(Color.Parse("#9CA3AF"));
            }

            // Set the active button
            if (activeButton == "Dashboard" && _dashboardButton != null)
            {
                _dashboardButton.Classes.Clear();
                _dashboardButton.Classes.Add("sidebar-item-active");
                if (_dashboardIcon != null)
                {
                    _dashboardIcon.Fill = Brushes.White;
                }
            }
            else if (activeButton == "CreateInvoice" && _createInvoiceButton != null)
            {
                _createInvoiceButton.Classes.Clear();
                _createInvoiceButton.Classes.Add("sidebar-item-active");
                if (_createInvoiceIcon != null)
                {
                    _createInvoiceIcon.Fill = Brushes.White;
                }
            }
        }
    }
}
