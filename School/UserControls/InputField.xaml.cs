using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace School.UserControls
{
    /// <summary>
    /// Логика взаимодействия для InputField.xaml
    /// </summary>
    public partial class InputField : UserControl
    {
        #region Label
        public string LabelValue
        {
            get { return (string)GetValue(LabelValueProperty); }
            set { SetValue(LabelValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelValueProperty =
            DependencyProperty.Register("LabelValue", typeof(string), typeof(InputField), new PropertyMetadata(string.Empty));

        #endregion
        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(InputField), new PropertyMetadata(string.Empty));
        #endregion
        #region Placeholder value
        public string PlaceholderValue
        {
            get { return (string)GetValue(PlaceholderValueProperty); }
            set { SetValue(PlaceholderValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderValueProperty =
            DependencyProperty.Register("PlaceholderValue", typeof(string), typeof(InputField), new PropertyMetadata(string.Empty));
        #endregion
        #region Placeholder visibility
        public Visibility PlaceholderVisibility
        {
            get { return (Visibility)GetValue(PlaceholderVisibilityProperty); }
            set { SetValue(PlaceholderVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderVisibilityProperty =
            DependencyProperty.Register("PlaceholderVisibility", typeof(Visibility), typeof(InputField), new PropertyMetadata(Visibility.Visible));
        #endregion
        #region TextWrapping
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextWrapping.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(InputField));
        #endregion
        #region IsReadonly
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(InputField));
        #endregion


        public event TextChangedEventHandler TextChanged;

        public InputField()
        {
            InitializeComponent();
        }

        private void TextContainer_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = TextContainer.Text;
            PlaceholderVisibility = Text == string.Empty ? Visibility.Visible : Visibility.Collapsed;
            TextChanged?.Invoke(sender, e);
        }
    }
}
