using System.Windows;
using System.Windows.Media;

namespace School
{
    public partial class Service
    {
        public SolidColorBrush Background => Discount == 0 ? 
                                                new SolidColorBrush(Colors.White) : 
                                                new SolidColorBrush((Color)Application.Current.FindResource("AdditionalBackgroundColor"));
        public double CostWithDiscount => (double)((double)Cost - ((double)Cost * Discount / 100.0));
    }
}
