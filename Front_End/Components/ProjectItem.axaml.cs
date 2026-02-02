using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Front_End.Components
{
    public partial class ProjectItem : UserControl
    {
        public static readonly StyledProperty<string> ProjectNameProperty =
            AvaloniaProperty.Register<ProjectItem, string>(nameof(ProjectName), "Project Name");

        public static readonly StyledProperty<string> ClientNameProperty =
            AvaloniaProperty.Register<ProjectItem, string>(nameof(ClientName), "Client Name");

        public static readonly StyledProperty<string> StatusProperty =
            AvaloniaProperty.Register<ProjectItem, string>(nameof(Status), "Completed");

        public static readonly StyledProperty<string> CategoryProperty =
            AvaloniaProperty.Register<ProjectItem, string>(nameof(Category), "Design & Creative");

        public string ProjectName
        {
            get => GetValue(ProjectNameProperty);
            set => SetValue(ProjectNameProperty, value);
        }

        public string ClientName
        {
            get => GetValue(ClientNameProperty);
            set => SetValue(ClientNameProperty, value);
        }

        public string Status
        {
            get => GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Category
        {
            get => GetValue(CategoryProperty);
            set => SetValue(CategoryProperty, value);
        }

        public ProjectItem()
        {
            InitializeComponent();
            UpdateVisuals();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == ProjectNameProperty ||
                change.Property == ClientNameProperty ||
                change.Property == StatusProperty ||
                change.Property == CategoryProperty)
            {
                UpdateVisuals();
            }
        }

        private void UpdateVisuals()
        {
            var projectNameText = this.FindControl<TextBlock>("ProjectNameText");
            var clientNameText = this.FindControl<TextBlock>("ClientNameText");
            var statusBadge = this.FindControl<Border>("StatusBadge");
            var statusText = this.FindControl<TextBlock>("StatusText");
            var categoryText = this.FindControl<TextBlock>("CategoryText");

            if (projectNameText != null) projectNameText.Text = ProjectName;
            if (clientNameText != null) clientNameText.Text = ClientName;
            if (categoryText != null) categoryText.Text = Category;

            if (statusText != null && statusBadge != null)
            {
                statusText.Text = Status;

                // Set colors based on status
                switch (Status.ToLower())
                {
                    case "completed":
                        statusBadge.Background = new SolidColorBrush(Color.Parse("#DCFCE7"));
                        statusText.Foreground = new SolidColorBrush(Color.Parse("#16A34A"));
                        break;
                    case "ongoing":
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
