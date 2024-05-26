﻿using System;
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
    /// Логика взаимодействия для ProfileRegistration.xaml
    /// </summary>
    public partial class ProfileRegistration : Window
    {
        public ProfileRegistration()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;

            var controller = new Controller(login, password).TryToSignUp();
            if (controller) MessageBox.Show("Вы были успешно зарегестрированы!");
            else MessageBox.Show("Произошла ошибка!");
        }

        //private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
            
        //}

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
	                
		}

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void PhoneBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}
