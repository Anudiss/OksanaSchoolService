using SchoolService.Form;
using SchoolService.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using static SchoolService.Form.Form;

namespace SchoolService.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public event Action NavigateToLoginPage;
        public event SubmitForm OnRegister;
        
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void SendForm()
        {
            FormData data = new FormData(
                (FormFieldType.Surname, Surname.Text),
                (FormFieldType.Name, Name.Text),
                (FormFieldType.Patronymic, Patronymic.Text),
                (FormFieldType.Login, Login.Text),
                (FormFieldType.Password, Password.Password)
            );

            OnRegister?.Invoke(data);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateToLoginPage?.Invoke();
        }

        private void Registation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SendForm();
        }
    }
}
