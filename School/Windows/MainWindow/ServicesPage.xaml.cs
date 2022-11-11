using School.DatabaseConnection;
using School.Windows.EditServiceWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace School.Windows.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public IEnumerable<Service> DefaultServices = Database.Entities.Service.ToList();

        public ServicesPage()
        {
            InitializeComponent();

            #region Filter and sorting component initialization
            List<Filter> filters = new List<Filter>()
            {
                new Filter()
                {
                    Name = "Без фильтра",
                    LowerLimit = 0,
                    UpperLimit = 100
                },
                new Filter()
                {
                    Name = "От 0% до 5%",
                    LowerLimit = 0,
                    UpperLimit = 5
                },
                new Filter()
                {
                    Name = "От 5% до 15%",
                    LowerLimit = 5,
                    UpperLimit = 15
                },
                new Filter()
                {
                    Name = "От 15% до 30%",
                    LowerLimit = 15,
                    UpperLimit = 30
                },
                new Filter()
                {
                    Name = "От 30% до 70%",
                    LowerLimit = 30,
                    UpperLimit = 70
                },
                new Filter()
                {
                    Name = "От 70% до 100%",
                    LowerLimit = 70,
                    UpperLimit = 101
                }
            };
            List<Sorting> sortings = new List<Sorting>()
            {
                new Sorting()
                {
                    Name = "По возрастанию цены",
                    SortingMethod = (services) => services.OrderBy(service => service.CostWithDiscount)
                },
                new Sorting()
                {
                    Name = "По убыванию цена",
                    SortingMethod = (services) => services.OrderByDescending(service => service.CostWithDiscount)
                }
            };

            FilterComponent.ItemsSource = filters;
            FilterComponent.DisplayMemberPath = "Name";

            SortComponent.ItemsSource = sortings;
            SortComponent.DisplayMemberPath = "Name";

            FilterComponent.SelectedIndex = 0;
            SortComponent.SelectedIndex = 0;
            #endregion
        }

        private async Task DoStuff()
        {
            ServiceContainer.ItemsSource = await SortFilterSearch();
            ElementsCountComponent.Text = $"{ServiceContainer.Items.Count}/{DefaultServices.Count()}";
        }

        private async Task<IEnumerable<Service>> SortFilterSearch() =>
            await Task.FromResult(
                        (SortComponent.SelectedItem as Sorting)?.SortingMethod(
                            DefaultServices.Where(service => IsSearched(service) &&
                                                             (FilterComponent.SelectedItem as Filter).IsFilter(service))
                        )
                  );

        private bool IsSearched(Service service) =>
            Regex.IsMatch(input:   $"{service.Title} {service.Description}".ToLower().Trim(), 
                          pattern: $@"{SearchField.Text.ToLower().Trim()}.*");

        private async void SearchField_TextChanged(object sender, TextChangedEventArgs e) =>
            await DoStuff();

        private async void SortingOrFilterChanged(object sender, SelectionChangedEventArgs e) =>
            await DoStuff();

        private async void Card_EditButtonPressed(Service service)
        {
            EditServiceWindow.EditServiceWindow editServiceWindow = new EditServiceWindow.EditServiceWindow()
            {
                Service = service
            };
            editServiceWindow.ShowDialog();
            await Refresh();
        }

        private async void Card_RemoveButtonPressed(Service service)
        {
            EditServiceWindow.EditServiceWindow editServiceWindow = new EditServiceWindow.EditServiceWindow()
            {
                Service = null
            };
            editServiceWindow.ShowDialog();
            await Refresh();
        }

        private async Task Refresh()
        {
            DefaultServices = Database.Entities.Service.ToList();
            await DoStuff();
        }
    }

    public class Filter
    {
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public string Name { get; set; }

        public Predicate<Service> IsFilter;

        public Filter() =>
            IsFilter = (service) => service.Discount >= LowerLimit && service.Discount < UpperLimit;
    }

    public class Sorting
    {
        public string Name { get; set; }
        public Func<IEnumerable<Service>, IEnumerable<Service>> SortingMethod { get; set; }
    }
}