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

        private int PlanBooks;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //создать Challenge c CountBooks.Text в Plan для UserId
            if (PlanBooks != 0)
            {
                ChallengeAfter challengeAfter = new ChallengeAfter();
                challengeAfter.Show();
                Close();
            }     
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string(textBox.Text.Where(ch => Char.IsDigit(ch)).ToArray());
                var planCountBooks = Convert.ToInt32(textBox.Text);
                PlanBooks = planCountBooks;
            }

        }

        private void Statistics_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.Show();
            Close();
        }
    }
}
