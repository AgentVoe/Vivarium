using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
using Vivarium.Control;
using Vivarium.StaticData;

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


            //// получить книги --
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
            //// -- получить книги

            //books.ItemsSource = getBooks;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Book book = (Book)books.SelectedItem;
            BookCard bookCard = new BookCard(book);
            bookCard.Show();

            if (!Logged.IsLoggedIn)
            {
                new Controller().TryToLoadData();
            }
        }
  //      public MainPage(string login)
  //      {
		//	InitializeComponent();
  //          this.login = login;
		//}

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