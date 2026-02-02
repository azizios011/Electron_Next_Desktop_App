using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace Front_End.Components
{
    public partial class StatCard : UserControl
    {
        public static readonly StyledProperty<string> LabelProperty =
            AvaloniaProperty.Register<StatCard, string>(nameof(Label), "LABEL");

        public static readonly StyledProperty<string> ValueProperty =
            AvaloniaProperty.Register<StatCard, string>(nameof(Value), "0");

        public static readonly StyledProperty<string> IconDataProperty =
            AvaloniaProperty.Register<StatCard, string>(nameof(IconData), "");

        public static readonly StyledProperty<IBrush> IconColorProperty =
            AvaloniaProperty.Register<StatCard, IBrush>(nameof(IconColor), Brushes.Orange);

        public static readonly StyledProperty<IBrush> IconBackgroundProperty =
            AvaloniaProperty.Register<StatCard, IBrush>(nameof(IconBackground), new SolidColorBrush(Color.Parse("#FEF3C7")));

        public string Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string IconData
        {
            get => GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }

        public IBrush IconColor
        {
            get => GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public IBrush IconBackground
        {
            get => GetValue(IconBackgroundProperty);
            set => SetValue(IconBackgroundProperty, value);
        }

        public StatCard()
        {
            InitializeComponent();
            UpdateVisuals();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            
            if (change.Property == LabelProperty ||
                change.Property == ValueProperty ||
                change.Property == IconDataProperty ||
                change.Property == IconColorProperty ||
                change.Property == IconBackgroundProperty)
            {
                UpdateVisuals();
            }
        }

        private void UpdateVisuals()
        {
            var labelText = this.FindControl<TextBlock>("LabelText");
            var valueText = this.FindControl<TextBlock>("ValueText");
            var iconContainer = this.FindControl<Border>("IconContainer");
            var iconPath = this.FindControl<Path>("IconPath");

            if (labelText != null) labelText.Text = Label;
            if (valueText != null) valueText.Text = Value;
            if (iconContainer != null) iconContainer.Background = IconBackground;
            if (iconPath != null)
            {
                iconPath.Fill = IconColor;
                if (!string.IsNullOrEmpty(IconData))
                {
                    iconPath.Data = Geometry.Parse(IconData);
                }
            }
        }
    }
}
