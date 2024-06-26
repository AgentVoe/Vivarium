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
using Vivarium.Context;
using Vivarium.Authorization;
using Vivarium.WPFforms;
using Vivarium.StaticData;

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для MyBooks.xaml
    /// </summary>
    public partial class MyBooks : Window
    {
        public MyBooks()
        {
            InitializeComponent();

            if (Logged.IsLoggedIn)
            {
				books.ItemsSource = UserAndBooks.GetBooks();
			}
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Book book = (Book)books.SelectedItem;
            BookCard bookCard = new BookCard(book);
            bookCard.Show();
        }

        private void MainPage_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MainPage mainPageForm = new MainPage();
            mainPageForm.Show();
            this.Close();
        }

        private void Challenge_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            bool challenge = false; //проверить есть ли challenge для user
            if (challenge)
            {
                ChallengeAfter challengeForm = new ChallengeAfter();
                challengeForm.Show();
            }
            else
            {
                ChallengeBefore challengeForm = new ChallengeBefore();
                challengeForm.Show();
            }
            this.Close();
        }

        private void Profile_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
			if (Logged.IsLoggedIn)
			{
                ProfileAfter profileForm = new ProfileAfter();
                profileForm.Show();
            }
            else
            {
                ProfileBefore profileForm = new ProfileBefore();
                profileForm.Show();
            }
            this.Close();
        }
        private void Statistics_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.Show();
            this.Close();
        }
    }
}