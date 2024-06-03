using System.Windows;
using System.Windows.Input;
using Vivarium.Authorization;
using Vivarium.Context;
using Vivarium.Control;
using Vivarium.StaticData;
using Vivarium.WPFforms;

namespace Vivarium.View
{
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Window
    {
        //private string login;
        public MainPage()
        {
            InitializeComponent();

			if (!Logged.IsLoggedIn)
			{
				new Controller().TryToLoadData();
			}
            
            // Отображение книги на главной странице
			books.ItemsSource = Books.books;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Book book = (Book)books.SelectedItem;
            BookCard bookCard = new BookCard(book);
            bookCard.Show();
        }

        private void Statistics_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.Show();
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
    }
}