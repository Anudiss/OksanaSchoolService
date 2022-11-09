using School.Windows.AuthWindow;
using School.Windows.AuthWindow.Pages;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace School.Windows.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public delegate void AuthenticationEventHander(AuthenticationEventArgs args);

        public event AuthenticationEventHander OnAuthenticated;

        private LoginPage _loginPage;

        public AuthWindow()
        {
            InitializeComponent();

            _loginPage = new LoginPage();
            _loginPage.OnLogin += (args) =>
            {

            };
        }
    }

    public struct AuthenticationEventArgs
    {
        public User User { get; set; }
    }
}
