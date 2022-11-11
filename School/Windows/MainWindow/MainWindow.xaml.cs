using School.Resourses;
using School.Windows.AuthWindow;
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
using System.Windows.Shapes;

namespace School.Windows.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeAuthWindow();
        }

        private void InitializeAuthWindow()
        {
            AuthWindow.AuthWindow authWindow = new AuthWindow.AuthWindow();
            authWindow.Closing += (sender, args) =>
            {
                if (StaticData.AuthtorizatedUser == null)
                    Close();
            };

            authWindow.ShowDialog();
        }
    }
}
