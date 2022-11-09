using SchoolService.Form;
using System;
using System.Windows.Controls;
using static SchoolService.Form.Form;

namespace SchoolService.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public event Action NavigateToRegistrationPage;
        public event SubmitForm OnLogin;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void SendForm()
        {
            FormData data = new FormData(
                (FormFieldType.Login, Login.Text),
                (FormFieldType.Password, Password.Password)
            );

            OnLogin?.Invoke(data);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateToRegistrationPage?.Invoke();
        }

        private void Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SendForm();
        }
    }
}
