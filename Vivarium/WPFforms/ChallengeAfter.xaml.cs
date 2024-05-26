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

namespace Vivarium.WPFforms
{
    /// <summary>
    /// Логика взаимодействия для ChallengeAfter.xaml
    /// </summary>
    public partial class ChallengeAfter : Window
    {
        public ChallengeAfter()
        {
            InitializeComponent();

            double fact = 5; // получить fact из Challenge для UserId
            double plan = 10; // получить plan из Challenge для UserId

            TextResult.Text = $"Вы прочли {fact} из {plan} книг";
                        
            double percent = Math.Round(fact/plan * 100);

            if (fact >= plan)
            {
                TextResult.Text += "\nЦель достигнута, поздравляем!";
                percent = 100;
            }

            TextPercent.Text = $"{percent}%";
            RectFact.Width = percent/100 * RectPlan.Width;
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
