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
    }
}
