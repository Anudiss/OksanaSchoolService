using System;
using System.Collections.Generic;
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

namespace School.Windows.AuthWindow.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public delegate void LoginHandler(LoginEventArgs args);

        public event LoginHandler OnLogin;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            OnLogin?.Invoke(new LoginEventArgs()
            {
                Login = Login.Text,
                Password = Password.Password
            });
        }
    }

    public struct LoginEventArgs
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
