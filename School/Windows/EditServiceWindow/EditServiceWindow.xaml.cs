using School.DatabaseConnection;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace School.Windows.EditServiceWindow
{
    /// <summary>
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        #region Service
        public Service Service
        {
            get { return (Service)GetValue(ServiceProperty); }
            set
            {
                SetValue(ServiceProperty, value);
                if (value == null)
                    Title = "Добавление сервиса";
            }
        }

        // Using a DependencyProperty as the backing store for Service.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceProperty =
            DependencyProperty.Register("Service", typeof(Service), typeof(EditServiceWindow));
        #endregion

        public EditServiceWindow()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e) =>
            await Save();

        private async void EditServiceWindowRoot_Closing(object sender, CancelEventArgs e)
        {
            if (DialogResult == true)
                return;

            MessageBoxResult result = MessageBox.Show("Хотите сохранить?", "Сохранение", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    await Save();
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private async Task Save()
        {
            try
            {
                if (Service == null)
                    Database.Entities.Service.Add(Service = new Service());
                Service.Title = TitleField.Text;
                Service.Cost = decimal.Parse(Regex.Replace(CostField.Text, @"\.", ","));
                Service.DurationInSeconds = int.Parse(DurationField.Text);
                Service.Discount = double.Parse(Regex.Replace(DiscountField.Text, @"\.", ","));
                Service.Description = DescriptionField.Text;
                await Database.Entities.SaveChangesAsync();
                DialogResult = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введены данные");
            }
        }
    }
}
