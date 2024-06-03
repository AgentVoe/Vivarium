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

namespace Vivarium.View
{
    /// <summary>
    /// Логика взаимодействия для BookCard.xaml
    /// </summary>
    public partial class BookCard : Window
    {
        public BookCard(Book book)
        {
            InitializeComponent();

            name.Text = book.Title;
            author.Text = book.Author.Surname;
            year.Text += book.BYear.Value.Year;

            string genres = "";
            foreach (var item in book.BooksGenres)
                genres += item.Genre.GenreName + ", ";
            genres = genres.Remove(genres.Length - 2);
            genre.Text += genres;

            List<int?> grades = new List<int?>();
            foreach (var item in book.Assessments)
                grades.Add(item.Grade.Grade1);
            rating.Text += grades.Average();

            grade = 0; //получить assessment для book от user (если есть)
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

            List<Status> statuses = new List<Status> // получить список статусов
            {
                new Status{Status1 = "не читал"},
                new Status{Status1 = "хочу прочитать"},
                new Status{Status1 = "прочитано"},
                new Status{Status1 = "читаю"},
                new Status{Status1 = "перестал читать"},
            };

            status.ItemsSource = statuses;

            status.SelectedIndex = 0; // получить statusBook для book от user (если есть)
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
            // сохранить grade для book от user
        }

        private void status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // сохранить status.SelectedItem для book от user
        }
    }
}
