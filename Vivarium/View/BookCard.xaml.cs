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
        }

        private int grade;

        private void Grade1_MouseDown(object sender, MouseButtonEventArgs e)
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
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "☆";
            grade4.Text = "☆";
            grade5.Text = "☆";
            grade = 2;
        }

        private void Grade3_MouseDown(object sender, MouseButtonEventArgs e)
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
            grade1.Text = "★";
            grade2.Text = "★";
            grade3.Text = "★";
            grade4.Text = "★";
            grade5.Text = "☆";
            grade = 4;
        }

        private void Grade5_MouseDown(object sender, MouseButtonEventArgs e)
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
    }
}
