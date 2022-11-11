using School.DatabaseConnection;
using School.Resourses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace School.Windows.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

        }

        private async void OnLogin(object sender, RoutedEventArgs e)
        {
            User authorizatedUser = await DatabaseConnection.Database.Entities.User.FirstOrDefaultAsync(user => user.Login == LoginField.Text.Trim() &&
                                                                                                                user.Password == PasswordField.Password.Trim());
            if (authorizatedUser == default)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            StaticData.AuthtorizatedUser = authorizatedUser;
            DialogResult = true;
        }

        private async void OnRegistration(object sender, RoutedEventArgs e)
        {
            string login = LoginField.Text.Trim();
            string password = PasswordField.Password.Trim();

            if (await DatabaseConnection.Database.Entities.User.AnyAsync(user => user.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже есть");
                return;
            }

            User authorizatedUser = new User()
            {
                Login = login,
                Password = password,
                Role_ID = 2
            };
            DatabaseConnection.Database.Entities.User.Add(authorizatedUser);

            StaticData.AuthtorizatedUser = authorizatedUser;
            DialogResult = true;

            await DatabaseConnection.Database.Entities.SaveChangesAsync();
        }

        private void OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OnLogin(null, default);
        }
    }
}
