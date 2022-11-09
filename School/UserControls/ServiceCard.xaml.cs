using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ServiceCard.xaml
    /// </summary>
    public partial class ServiceCard : UserControl
    {
        #region Service
        public Service Service
        {
            get { return (Service)GetValue(ServiceProperty); }
            set { SetValue(ServiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Service.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceProperty =
            DependencyProperty.Register("Service", typeof(Service), typeof(ServiceCard));
        #endregion


        public ServiceCard()
        {
            InitializeComponent();
        }
    }

    [ValueConversion(typeof(Service), typeof(string))]
    public class CostDiscountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Service service == false)
                return null;

            return $"{(double)service.Cost - ((double)service.Cost * service.Discount / 100.0):F2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    [ValueConversion(typeof(Service), typeof(Visibility))]
    public class DiscountVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Service service == false)
                return null;

            return service.Discount != 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    [ValueConversion(typeof(Service), typeof(string))]
    public class TimeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Service service == false)
                return null;

            int seconds = service.DurationInSeconds;
            return seconds < 60 ? $"{seconds} секунд" : $"{(seconds / 60):F0} минут";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

}
