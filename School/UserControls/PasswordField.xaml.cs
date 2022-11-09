using System.Windows;
using System.Windows.Controls;

namespace School.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PasswordField.xaml
    /// </summary>
    public partial class PasswordField : UserControl
    {
        #region Label
        public string PasswordLabelValue
        {
            get { return (string)GetValue(LabelValueProperty); }
            set { SetValue(LabelValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelValueProperty =
            DependencyProperty.Register("PasswordLabelValue", typeof(string), typeof(PasswordField), new PropertyMetadata(string.Empty));

        #endregion
        #region Text
        public string Password => TextContainer.Password;
        #endregion
        #region Placeholder value
        public string PasswordPlaceholderValue
        {
            get { return (string)GetValue(PlaceholderValueProperty); }
            set { SetValue(PlaceholderValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderValueProperty =
            DependencyProperty.Register("PasswordPlaceholderValue", typeof(string), typeof(PasswordField), new PropertyMetadata(string.Empty));
        #endregion
        #region Placeholder visibility
        public Visibility PasswordPlaceholderVisibility
        {
            get { return (Visibility)GetValue(PlaceholderVisibilityProperty); }
            set { SetValue(PlaceholderVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderVisibilityProperty =
            DependencyProperty.Register("PasswordPlaceholderVisibility", typeof(Visibility), typeof(PasswordField), new PropertyMetadata(Visibility.Visible));
        #endregion

        public PasswordField()
        {
            InitializeComponent();
        }

        private void TextContainer_TextChanged(object sender, RoutedEventArgs e) =>
            PasswordPlaceholderVisibility = TextContainer.Password == string.Empty ? Visibility.Visible : Visibility.Collapsed;
    }
}
