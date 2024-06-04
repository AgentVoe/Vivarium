using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vivarium.Authorization;
using Vivarium.Context;
using Vivarium.Control;
using Vivarium.StaticData;

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для BookCard.xaml
    /// </summary>
    public partial class BookCard : Window
    {
        private Book _book;
        public BookCard(Book book)
        {
            InitializeComponent();


            _book = book;

            name.Text = book.Title;
            author.Text = book.BooksAuthors.First().Author.Name;
            year.Text += book.BYear;

            string genres = "";
            foreach (var item in book.BooksGenres)
                genres += item.Genre.GenreName + ", ";
            genres = genres.Remove(genres.Length - 2);
            genre.Text += genres;

            //List<int?> grades = new List<int?>();
            //foreach (var item in book.Assessments)
            //    grades.Add(item.Grade.Grade1);
            //rating.Text += grades.Average();

            if (Logged.IsLoggedIn)
            {
                if (UserAndBooks.userAndBooks[0].StatusBooks.Any(b => b.BookId == _book.Id))
                {
                    grade = UserAndBooks.userAndBooks[0].Assessments
                    .Where(b => b.BookId == _book.Id).FirstOrDefault().Grade.Grade1;
                    rating.Text = grade.ToString();
                }
            }
            else
            {
                grade = 0;
            }

            switch (grade)
            {
                case 1:
                    MakeGrade1();
                    break;
                case 2:
                    MakeGrade2();
                    break;
                case 3:
                    MakeGrade3();
                    break;
                case 4:
                    MakeGrade4();
                    break;
                case 5:
                    MakeGrade5();
                    break;
                default:
                    break;
            }

            status.ItemsSource = Books.statuses;
            if (Logged.IsLoggedIn)
            {
                if (UserAndBooks.userAndBooks[0].StatusBooks.Any(b => b.BookId == _book.Id))
                {
                    Status statusBook = UserAndBooks.GetStatus(book.Id);
                    if (statusBook != null)
                        foreach (Status item in status.Items)
                            if (item.Status1 == statusBook.Status1)
                            {
                                status.SelectedItem = item;
                                break;
                            }
                }
                status.SelectedIndex = 0;
            }
            else status.SelectedIndex = 0;
        }

        private int grade;

        private void Grade1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MakeGrade1();
        }

        private void MakeGrade1()
        {
            grade1.Text = "★";
            grade2.Text = "☆";
            grade3.Text = "☆";
            grade4.Text = "☆";
            grade5.Text = "☆";
            grade = 1;
        }

        private void Grade2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MakeGrade2();
        }

        private void MakeGrade2()
        {
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "☆";
            grade4.Text = "☆";
            grade5.Text = "☆";
            grade = 2;
        }

        private void Grade3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MakeGrade3();
        }

        private void MakeGrade3()
        {
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "★";
            grade4.Text = "☆";
            grade5.Text = "☆";
            grade = 3;
        }

        private void Grade4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MakeGrade4();
        }

        private void MakeGrade4()
        {
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "★";
            grade4.Text = "★";
            grade5.Text = "☆";
            grade = 4;
        }

        private void Grade5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MakeGrade5();
        }

        private void MakeGrade5()
        {
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "★";
            grade4.Text = "★";
            grade5.Text = "★";
            grade = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Logged.IsLoggedIn)
                return;
            var bookStatus = status.Text;
            int statusId = 0;

            if (bookStatus == "Хочу прочитать")
            {
                statusId = 11;
            }
            else if (bookStatus == "Прочитано")
            {
                statusId = 7;
            }
            else if (bookStatus == "Читаю")
            {
                statusId = 8;
            }
            else if (bookStatus == "Заброшено")
            {
                statusId = 9;
            }
            if (!UserAndBooks.userAndBooks[0].StatusBooks.Any(b => b.BookId == _book.Id))
            {
                var newStatusBook = new StatusBook
                {
                    StatusId = statusId,
                    BookId = _book.Id,
                    Book = new Book()
                    {
                        Id = _book.Id,
                        Title = _book.Title,
                        BYear = _book.BYear,
                        BooksAuthors = new List<BooksAuthor>()
                        {
                            new BooksAuthor()
                            {
                                Author = new Author()
                                {
                                    Id = _book.BooksAuthors.First().Author.Id,
                                    Name = _book.BooksAuthors.First().Author.Name
                                 },
                                AuthorId = _book.BooksAuthors.First().Author.Id
                            }
                        },
                        BooksGenres = new List<BooksGenre>()
                        {
                            new BooksGenre()
                            {
                                Genre = new Genre()
                                {
                                    Id = _book.BooksGenres.First().Genre.Id,
                                    GenreName = _book.BooksGenres.First().Genre.GenreName
                                },
                                GenreId = _book.BooksGenres.First().GenreId,
                            }
                        },
                        Assessments = new List<Assessment>()
                        {
                            new Assessment()
                            {
                                Grade = new Grade()
                                {
                                    Id = grade,
                                    Grade1 = grade,
                                },
                                GradeId = grade,
                            }
                        }
                    },
                    UserId = UserAndBooks.userAndBooks[0].Id,
                    User = new User()
                    {
                        Id = UserAndBooks.userAndBooks[0].Id,
                        Login = UserAndBooks.userAndBooks[0].Login
                    },
                    Status = new Status()
                    {
                        Id = statusId,
                        Status1 = bookStatus
                    },
                    StDate = DateOnly.Parse(DateTime.Now.ToShortDateString().ToString()),

                };

                var bookToUserId = new StatusBook()
                {
                    StatusId = statusId,
                    BookId = _book.Id,
                    UserId = UserAndBooks.userAndBooks[0].Id,
                    StDate = DateOnly.Parse(DateTime.Now.ToShortDateString().ToString()),
                };

                var userBookGrade = new Assessment()
                {
                    UserId = UserAndBooks.userAndBooks[0].Id,
                    BookId = _book.Id,
                    GradeId = grade,
                };
                UserAndBooks.userAndBooks[0].StatusBooks.Add(newStatusBook);

                new Controller().TryToAddBookToUser(bookToUserId, userBookGrade);
            }
            else
            {
                //var bookToUserId = new StatusBook()
                //{
                //    StatusId = statusId,
                //    BookId = _book.Id,
                //    UserId = UserAndBooks.userAndBooks[0].Id,
                //    StDate = DateOnly.Parse(DateTime.Now.ToShortDateString().ToString()),
                //};

                //var userBookGrade = new Assessment()
                //{
                //    UserId = UserAndBooks.userAndBooks[0].Id,
                //    BookId = _book.Id,
                //    GradeId = grade,
                //};

                //new Controller().TryToUpdateBook(bookToUserId, userBookGrade);
            }

        }

        private void status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // сохранить status.SelectedItem для book от user
        }
    }
}
