using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using Front_End.Components;
using System;

namespace Front_End.Views
{
    public partial class MainWindow : Window
    {
        private Panel? _sidebarOverlay;
        private Border? _overlayBackground;
        private Sidebar? _sidebar;
        private Navbar? _navbar;
        private ScrollViewer? _dashboardContent;
        private InvoiceView? _invoiceContent;
        private bool _isDarkMode = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeStatCards();
            InitializeTransactions();
            InitializeProjects();
            InitializeSidebar();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            _dashboardContent = this.FindControl<ScrollViewer>("DashboardContent");
            _invoiceContent = this.FindControl<InvoiceView>("InvoiceContent");

            // Hook up Invoice view menu button
            if (_invoiceContent != null)
            {
                _invoiceContent.MenuRequested += OnInvoiceMenuRequested;
            }
        }

        private void OnInvoiceMenuRequested(object? sender, EventArgs e)
        {
            OpenSidebar();
        }

        private void InitializeSidebar()
        {
            _sidebarOverlay = this.FindControl<Panel>("SidebarOverlay");
            _overlayBackground = this.FindControl<Border>("OverlayBackground");
            _sidebar = this.FindControl<Sidebar>("MainSidebar");
            _navbar = this.FindControl<Navbar>("MainNavbar");

            // Hook up navbar logo click to open sidebar
            if (_navbar != null)
            {
                _navbar.MenuToggleRequested += OnMenuToggleRequested;
            }

            // Hook up sidebar close button
            if (_sidebar != null)
            {
                _sidebar.CloseRequested += OnSidebarCloseRequested;
                _sidebar.NavigationRequested += OnNavigationRequested;
                _sidebar.DarkModeToggled += OnDarkModeToggled;
            }

            // Click on overlay background to close sidebar
            if (_overlayBackground != null)
            {
                _overlayBackground.PointerPressed += (s, e) => CloseSidebar();
            }
        }

        private void OnDarkModeToggled(object? sender, bool isDark)
        {
            _isDarkMode = isDark;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (Application.Current != null)
            {
                Application.Current.RequestedThemeVariant = _isDarkMode ? ThemeVariant.Dark : ThemeVariant.Light;
            }

            // Update MainWindow background
            this.Background = _isDarkMode 
                ? new SolidColorBrush(Color.Parse("#111827")) 
                : new SolidColorBrush(Color.Parse("#F9FAFB"));

            // Update Navbar if visible
            if (_navbar != null)
            {
                // Navbar will update through Avalonia theme
            }
        }

        private void OnNavigationRequested(object? sender, string pageName)
        {
            NavigateToPage(pageName);
        }

        private void NavigateToPage(string pageName)
        {
            if (_dashboardContent == null || _invoiceContent == null || _navbar == null)
                return;

            switch (pageName)
            {
                case "Dashboard":
                    _dashboardContent.IsVisible = true;
                    _invoiceContent.IsVisible = false;
                    _navbar.IsVisible = true;
                    break;
                case "CreateInvoice":
                    _dashboardContent.IsVisible = false;
                    _invoiceContent.IsVisible = true;
                    _navbar.IsVisible = false;
                    break;
            }
        }

        private void OnMenuToggleRequested(object? sender, EventArgs e)
        {
            OpenSidebar();
        }

        private void OnSidebarCloseRequested(object? sender, EventArgs e)
        {
            CloseSidebar();
        }

        private void OpenSidebar()
        {
            if (_sidebarOverlay != null)
            {
                _sidebarOverlay.IsVisible = true;
            }
            // Sync dark mode state to sidebar
            if (_sidebar != null)
            {
                _sidebar.SetDarkMode(_isDarkMode);
            }
        }

        private void CloseSidebar()
        {
            if (_sidebarOverlay != null)
            {
                _sidebarOverlay.IsVisible = false;
            }
        }

        private void InitializeStatCards()
        {
            // Clients Card
            var clientsCard = this.FindControl<StatCard>("ClientsCard");
            if (clientsCard != null)
            {
                clientsCard.Label = "CLIENTS";
                clientsCard.Value = "12";
                clientsCard.IconData = "M16 11c1.66 0 2.99-1.34 2.99-3S17.66 5 16 5c-1.66 0-3 1.34-3 3s1.34 3 3 3zm-8 0c1.66 0 2.99-1.34 2.99-3S9.66 5 8 5C6.34 5 5 6.34 5 8s1.34 3 3 3zm0 2c-2.33 0-7 1.17-7 3.5V19h14v-2.5c0-2.33-4.67-3.5-7-3.5zm8 0c-.29 0-.62.02-.97.05 1.16.84 1.97 1.97 1.97 3.45V19h6v-2.5c0-2.33-4.67-3.5-7-3.5z";
                clientsCard.IconColor = new SolidColorBrush(Color.Parse("#6B7280"));
                clientsCard.IconBackground = new SolidColorBrush(Color.Parse("#F3F4F6"));
            }

            // Invoices Card
            var invoicesCard = this.FindControl<StatCard>("InvoicesCard");
            if (invoicesCard != null)
            {
                invoicesCard.Label = "INVOICES";
                invoicesCard.Value = "14";
                invoicesCard.IconData = "M14 2H6c-1.1 0-1.99.9-1.99 2L4 20c0 1.1.89 2 1.99 2H18c1.1 0 2-.9 2-2V8l-6-6zm2 16H8v-2h8v2zm0-4H8v-2h8v2zm-3-5V3.5L18.5 9H13z";
                invoicesCard.IconColor = new SolidColorBrush(Color.Parse("#F59E0B"));
                invoicesCard.IconBackground = new SolidColorBrush(Color.Parse("#FEF3C7"));
            }

            // Invoiced Card
            var invoicedCard = this.FindControl<StatCard>("InvoicedCard");
            if (invoicedCard != null)
            {
                invoicedCard.Label = "INVOICED";
                invoicedCard.Value = "$ 65.29K";
                invoicedCard.IconData = "M11.8 10.9c-2.27-.59-3-1.2-3-2.15 0-1.09 1.01-1.85 2.7-1.85 1.78 0 2.44.85 2.5 2.1h2.21c-.07-1.72-1.12-3.3-3.21-3.81V3h-3v2.16c-1.94.42-3.5 1.68-3.5 3.61 0 2.31 1.91 3.46 4.7 4.13 2.5.6 3 1.48 3 2.41 0 .69-.49 1.79-2.7 1.79-2.06 0-2.87-.92-2.98-2.1h-2.2c.12 2.19 1.76 3.42 3.68 3.83V21h3v-2.15c1.95-.37 3.5-1.5 3.5-3.55 0-2.84-2.43-3.81-4.7-4.4z";
                invoicedCard.IconColor = new SolidColorBrush(Color.Parse("#3B82F6"));
                invoicedCard.IconBackground = new SolidColorBrush(Color.Parse("#DBEAFE"));
            }

            // Paid Card
            var paidCard = this.FindControl<StatCard>("PaidCard");
            if (paidCard != null)
            {
                paidCard.Label = "PAID";
                paidCard.Value = "$ 49.34K";
                paidCard.IconData = "M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15l-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z";
                paidCard.IconColor = new SolidColorBrush(Color.Parse("#10B981"));
                paidCard.IconBackground = new SolidColorBrush(Color.Parse("#D1FAE5"));
            }
        }

        private void InitializeTransactions()
        {
            var transactionsPanel = this.FindControl<StackPanel>("TransactionsPanel");
            if (transactionsPanel == null) return;

            var transactions = new[]
            {
                new { Name = "Ebyru Ghundes", Type = "Performance Marketing", InvoiceId = "#786483", Status = "Pending", Amount = "$ 2400.00", Date = "17.06.2022" },
                new { Name = "Monica Garrido", Type = "Landing Design", InvoiceId = "#786229", Status = "Paid", Amount = "$ 945.00", Date = "08.06.2022" },
                new { Name = "Lucifer Morningstar", Type = "Website Design", InvoiceId = "#782437", Status = "Paid", Amount = "$ 1800.00", Date = "05.06.2022" },
                new { Name = "Leonard Cohen", Type = "Performance Marketing", InvoiceId = "#782313", Status = "Pending", Amount = "$ 1350.00", Date = "03.06.2022" },
                new { Name = "Elly West", Type = "Rebranding", InvoiceId = "#786198", Status = "Pending", Amount = "$ 400.00", Date = "02.06.2022" },
                new { Name = "Barry Allen", Type = "Creating user flow", InvoiceId = "#786718", Status = "Pending", Amount = "$ 960.00", Date = "19.05.2022" },
                new { Name = "Xhand Jenner", Type = "Landing Design", InvoiceId = "#786431", Status = "Paid", Amount = "$ 3280.00", Date = "08.05.2022" },
            };

            foreach (var t in transactions)
            {
                var item = new TransactionItem
                {
                    ClientName = t.Name,
                    ServiceType = t.Type,
                    InvoiceId = t.InvoiceId,
                    Status = t.Status,
                    Amount = t.Amount,
                    Date = t.Date
                };
                transactionsPanel.Children.Add(item);
            }
        }

        private void InitializeProjects()
        {
            var projectsPanel = this.FindControl<StackPanel>("ProjectsPanel");
            if (projectsPanel == null) return;

            var projects = new[]
            {
                new { Name = "Landing Design", Client = "Monica Garrido", Status = "Ongoing", Category = "Design & Creative" },
                new { Name = "User Experience Flow", Client = "Lucifer Morningstar", Status = "Completed", Category = "Consultancy" },
                new { Name = "Performance Marketing", Client = "Ebyru Ghundes", Status = "Ongoing", Category = "Marketing" },
                new { Name = "Rebranding", Client = "Elly West", Status = "Ongoing", Category = "Design & Creative" },
                new { Name = "Landing Design", Client = "Xhand Jenner", Status = "Completed", Category = "Design & Creative" },
                new { Name = "Google Ads...", Client = "Leonard Cohen", Status = "Declined", Category = "Marketing" },
                new { Name = "Create User Flow", Client = "Barry Allen", Status = "Completed", Category = "Design & Creative" },
            };

            foreach (var p in projects)
            {
                var item = new ProjectItem
                {
                    ProjectName = p.Name,
                    ClientName = p.Client,
                    Status = p.Status,
                    Category = p.Category
                };
                projectsPanel.Children.Add(item);
            }
        }

        private void OnCreateInvoiceClick(object? sender, RoutedEventArgs e)
        {
            // Navigate to Create Invoice page
            NavigateToPage("CreateInvoice");
        }
    }
}
