using System.Windows.Media;

namespace School
{
    public partial class Service
    {
        public SolidColorBrush Background => Discount == 0 ? 
                                                new SolidColorBrush(Colors.Transparent) : 
                                                new SolidColorBrush(Colors.LightSeaGreen);
        public double CostWithDiscount => (double)((double)Cost - ((double)Cost * Discount / 100));
    }
}
