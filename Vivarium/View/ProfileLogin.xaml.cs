using Microsoft.EntityFrameworkCore.Diagnostics;
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
using Vivarium.Control;

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileLogin.xaml
    /// </summary>
    public partial class ProfileLogin : Window
    {
        public ProfileLogin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;
            var control = new Controller(login, password).TryToAuthorize();
            if (control)
                MessageBox.Show("Авторизация прошла успешно!");
            else MessageBox.Show("Неверно введен пароль или логин!");
        }
    }
}
