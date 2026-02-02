using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Front_End.Components
{
    public partial class TransactionItem : UserControl
    {
        public static readonly StyledProperty<string> ClientNameProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(ClientName), "Client Name");

        public static readonly StyledProperty<string> ServiceTypeProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(ServiceType), "Service Type");

        public static readonly StyledProperty<string> InvoiceIdProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(InvoiceId), "#000000");

        public static readonly StyledProperty<string> StatusProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(Status), "Pending");

        public static readonly StyledProperty<string> AmountProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(Amount), "$ 0.00");

        public static readonly StyledProperty<string> DateProperty =
            AvaloniaProperty.Register<TransactionItem, string>(nameof(Date), "01.01.2022");

        public string ClientName
        {
            get => GetValue(ClientNameProperty);
            set => SetValue(ClientNameProperty, value);
        }

        public string ServiceType
        {
            get => GetValue(ServiceTypeProperty);
            set => SetValue(ServiceTypeProperty, value);
        }

        public string InvoiceId
        {
            get => GetValue(InvoiceIdProperty);
            set => SetValue(InvoiceIdProperty, value);
        }

        public string Status
        {
            get => GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Amount
        {
            get => GetValue(AmountProperty);
            set => SetValue(AmountProperty, value);
        }

        public string Date
        {
            get => GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        public TransactionItem()
        {
            InitializeComponent();
            UpdateVisuals();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == ClientNameProperty ||
                change.Property == ServiceTypeProperty ||
                change.Property == InvoiceIdProperty ||
                change.Property == StatusProperty ||
                change.Property == AmountProperty ||
                change.Property == DateProperty)
            {
                UpdateVisuals();
            }
        }

        private void UpdateVisuals()
        {
            var nameText = this.FindControl<TextBlock>("NameText");
            var typeText = this.FindControl<TextBlock>("TypeText");
            var invoiceIdText = this.FindControl<TextBlock>("InvoiceIdText");
            var statusBadge = this.FindControl<Border>("StatusBadge");
            var statusText = this.FindControl<TextBlock>("StatusText");
            var amountText = this.FindControl<TextBlock>("AmountText");
            var dateText = this.FindControl<TextBlock>("DateText");

            if (nameText != null) nameText.Text = ClientName;
            if (typeText != null) typeText.Text = ServiceType;
            if (invoiceIdText != null) invoiceIdText.Text = InvoiceId;
            if (amountText != null) amountText.Text = Amount;
            if (dateText != null) dateText.Text = Date;

            if (statusText != null && statusBadge != null)
            {
                statusText.Text = Status;
                
                // Set colors based on status
                switch (Status.ToLower())
                {
                    case "paid":
                        statusBadge.Background = new SolidColorBrush(Color.Parse("#DCFCE7"));
                        statusText.Foreground = new SolidColorBrush(Color.Parse("#16A34A"));
                        break;
                    case "pending":
                        statusBadge.Background = new SolidColorBrush(Color.Parse("#FEF3C7"));
                        statusText.Foreground = new SolidColorBrush(Color.Parse("#D97706"));
                        break;
                    case "declined":
                        statusBadge.Background = new SolidColorBrush(Color.Parse("#FEE2E2"));
                        statusText.Foreground = new SolidColorBrush(Color.Parse("#DC2626"));
                        break;
                    default:
                        statusBadge.Background = new SolidColorBrush(Color.Parse("#F3F4F6"));
                        statusText.Foreground = new SolidColorBrush(Color.Parse("#6B7280"));
                        break;
                }
            }
        }
    }
}
