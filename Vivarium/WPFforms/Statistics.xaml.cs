using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Vivarium.View;
using Vivarium.StaticData;

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

            int doneBooks = UserAndBooks.GetCountDoneBook();
            DoneBooks.Text = doneBooks.ToString();

            int stopBooks = UserAndBooks.GetCountStopBook(); 
            StopBooks.Text = stopBooks.ToString();

            int futureBooks = UserAndBooks.GetCountFutureBook();
            FutureBooks.Text = futureBooks.ToString();

            int inProgressBooks = UserAndBooks.GetCountInProgressBook();
            InProgressBooks.Text = inProgressBooks.ToString();
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
            Dictionary<string, int> genresValue = UserAndBooks.GetGenresValue();
            SeriesGenres = new SeriesCollection();
            AddSeries(SeriesGenres, genresValue, GenresResult);
            DataContext = this;
        }

        public void PieGenerateAuthors()
        {
            Dictionary<string, int> authorsValue = UserAndBooks.GetAuthorsValue();
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
            Dictionary<string, int> yearValue = UserAndBooks.GetYearValue();
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
    }
}
