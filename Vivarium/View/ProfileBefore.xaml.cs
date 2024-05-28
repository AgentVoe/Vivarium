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
using Vivarium.Authorization;
using Vivarium.WPFforms;

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileBefore.xaml
    /// </summary>
    public partial class ProfileBefore : Window
    {
        public ProfileBefore()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileLogin profileLogin = new ProfileLogin();
            profileLogin.ShowDialog();
            if (Logged.IsLoggedIn) 
            {
                ProfileAfter profileAfter = new ProfileAfter(profileLogin.Login);
                profileAfter.Show();
                this.Close();
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileRegistration profileRegistration = new ProfileRegistration();
            profileRegistration.Show();
        }

        private void MainPage_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MainPage mainPageForm = new MainPage();
            mainPageForm.Show();
            this.Close();
        }

        private void MyBooks_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MyBooks myBooksForm = new MyBooks();
            myBooksForm.Show();
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
        private void Statistics_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.Show();
            this.Close();
        }
    }
}
