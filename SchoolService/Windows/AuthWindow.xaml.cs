using SchoolService.Database;
using SchoolService.Form;
using SchoolService.Pages;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static SchoolService.Form.Form;

namespace SchoolService.Windows
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private readonly LoginPage _loginPage;
        private readonly RegistrationPage _registrationPage;

        public AuthWindow()
        {
            InitializeComponent();

            _loginPage = new LoginPage();
            _registrationPage = new RegistrationPage();

            _loginPage.NavigateToRegistrationPage += () => Navigate(_registrationPage);
            _registrationPage.NavigateToLoginPage += () => Navigate(_loginPage);

            _registrationPage.OnRegister += Register;
            _loginPage.OnLogin += Login;

            Navigate(_loginPage);
        }

        private async void Register(FormData data)
        {
            User newUser = new User()
            {
                Login = data[FormFieldType.Login] as string,
                Passwrod = data[FormFieldType.Password] as string,
                Role = Roles.Client
            };

            DatabaseConnection.Database.User.Add(newUser);
            await DatabaseConnection.Database.SaveChangesAsync();
        }

        private async void Login(FormData data)
        {
            MessageBox.Show($"{string.Join(", ", DatabaseConnection.Database.User.Select(user => $"{user.Login}"))}");

            User loginedUser = 
                await DatabaseConnection.Database.User.AsQueryable()
                                                      .FirstOrDefaultAsync(user => user.Login == data[FormFieldType.Login] as string &&
                                                                                   user.Passwrod == data[FormFieldType.Password] as string);
            if (loginedUser == null)
                return;

            MessageBox.Show(loginedUser.Login);
        }

        public void Navigate(Page page)
        {
            Frame.Navigate(page);
        }
    }
}
