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
using Vivarium.StaticData;
using Vivarium.WPFforms;
using Vivarium.Context;

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileBefore.xaml
    /// </summary>
    public partial class ProfileAfter : Window
    {
        //private string login;
        public ProfileAfter()
        {
            InitializeComponent();
        }
  //      public ProfileAfter(User userAndBooks)
  //      {
  //          this.login = userAndBooks.Login;
		//	InitializeComponent();
		//}

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PhoneBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameBox.Text = UserAndBooks.userAndBooks.Login;
        }

        private void ExtraBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

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
