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
        //private bool logged;
        public MyBooks()
        {
            InitializeComponent();

            // получить книги пользователя --
            //Author author = new Author { Surname = "Пушкин" };
            //List<BooksGenre> genres = new List<BooksGenre> { new BooksGenre { Genre = new Genre { GenreName = "Фантастика" } } };
            //List<Assessment> assessments = new List<Assessment> { new Assessment { Grade = new Grade { Grade1 = 4 } }, new Assessment { Grade = new Grade { Grade1 = 5 } } };
            //List<Book> getBooks = new List<Book>
            //{
            //    new Book{Id = 0, BYear = new DateOnly(), Title = "Преступление и наказание", Author = author, BooksGenres = genres, Assessments = assessments},
            //    new Book{Id = 1, Title = "Война и мир", Author = author, BooksGenres = genres},
            //    new Book{Id = 2, Title = "Вы найдете это в библиотеке", Author = author, BooksGenres = genres},
            //    new Book{Id = 3, Title = "Что такое счастье", Author = author, BooksGenres = genres},
            //    new Book{Id = 4, Title = "Грозовой перевал", Author = author, BooksGenres = genres}
            //};
            //// -- получить книги пользователя

            books.ItemsSource = UserAndBooks.userAndBooks;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Book book = (Book)books.SelectedItem;
            BookCard bookCard = new BookCard(book);
            bookCard.Show();
        }
        //public MyBooks(bool logged)
        //{
        //    this.logged = logged;
        //}

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