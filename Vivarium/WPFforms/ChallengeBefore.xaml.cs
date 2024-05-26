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
using Vivarium.View;
using Vivarium.WPFforms;

namespace Vivarium
{
    /// <summary>
    /// Логика взаимодействия для ChallengeBefore.xaml
    /// </summary>
    public partial class ChallengeBefore : Window
    {
        public ChallengeBefore()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //содать Challenge c CountBooks.Text в Plan для UserId 
            ChallengeAfter challengeAfter = new ChallengeAfter();
            challengeAfter.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string(textBox.Text.Where(ch => Char.IsDigit(ch)).ToArray());
            }
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

        private void Profile_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            bool profile = false; //проверить есть ли user
            if (profile)
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
