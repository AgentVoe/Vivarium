using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();
            Pie();
            PieGenerateGenres();
            PieGenerateAuthors();
            PieGenerateYears();
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
        public SeriesCollection SeriesGenres { get; set; }
        public SeriesCollection SeriesAuthors { get; set; }
        public SeriesCollection SeriesYears { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Values { get; set; }

        public void Pie()
        {
            PointLabel = chartPoint => string.Format("{0}, {1:P}", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        public void PieGenerateGenres()
        {
            Dictionary<string, int> genresValue = new Dictionary<string, int>() // получить названия жанров прочитанных книг и количество
            {
                {"Романы", 12},
                {"Фантастика", 22},
                {"Детективы", 12},
                {"Ужасы", 12},
                {"Комедии", 7}
            };
            SeriesGenres = new SeriesCollection();
            AddSeries(SeriesGenres, genresValue, GenresResult);
            DataContext = this;
        }

        public void PieGenerateAuthors()
        {
            Dictionary<string, int> authorsValue = new Dictionary<string, int>() // получить фамилии авторов прочитанных книг и количество
            {
                {"Пушкин", 12},
                {"Тургенев", 22},
                {"Лермонтов", 12},
                {"Гоголь", 12},
                {"Толстой", 7}
            };
            SeriesAuthors = new SeriesCollection();
            AddSeries(SeriesAuthors, authorsValue, AuthorsResult);
            DataContext = this;
        }

        public void AddSeries(SeriesCollection series, Dictionary<string, int> dictionary, TextBlock resultText)
        {
            int result = 0;
            foreach (var item in dictionary)
            {
                series.Add(new PieSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(item.Value) },
                    DataLabels = true
                });
                result += item.Value;
            }
            resultText.Text = result.ToString();
        }

        public void PieGenerateYears()
        {
            Dictionary<string, int> yearValue = new Dictionary<string, int>() // получить количество прочитанных книг по годам
            {
                {"2020", 4},
                {"2021", 4},
                {"2022", 7},
                {"2023", 7},
                {"2024", 1}
            };
            SeriesYears = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "книг прочитано",
                    Values = new ChartValues<int>(yearValue.Values),
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(62,145,60))               
                }
            };
            Labels = yearValue.Keys.ToArray();
            Values = value => value.ToString("N");
            DataContext = this;
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
    }
}
