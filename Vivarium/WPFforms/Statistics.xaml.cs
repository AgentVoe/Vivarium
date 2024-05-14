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

            //        double pieWidth = 650;
            //        double pieHeight = 650;
            //        double centerX = pieWidth / 2;
            //        double centerY = pieHeight / 2;
            //        double radius = pieWidth / 2;
            //        FavoriteGenres.Width = pieWidth;
            //        FavoriteGenres.Height = pieHeight;

            //        var Categories = new List<Category>()
            //        {
            //            new Category
            //            {
            //                Title = "Category#01",
            //                Percentage = 10,
            //                ColorBrush = Brushes.Gold,
            //            },

            //            new Category
            //            {
            //                Title = "Category#02",
            //                Percentage = 30,
            //                ColorBrush = Brushes.Pink,
            //            },

            //            new Category
            //            {
            //                Title = "Category#03",
            //                Percentage = 60,
            //                ColorBrush = Brushes.CadetBlue,
            //            }
            //        };


            //        float angle = 0, prevAngle = 0;
            //        foreach (var category in Categories)
            //        {
            //            double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
            //            double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

            //            angle = category.Percentage * (float)360 / 100 + prevAngle;
            //            Debug.WriteLine(angle);

            //            double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
            //            double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

            //            var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
            //            double arcWidth = radius, arcHeight = radius;
            //            bool isLargeArc = category.Percentage > 50;
            //            var arcSegment = new ArcSegment()
            //            {
            //                Size = new Size(arcWidth, arcHeight),
            //                Point = new Point(arcX, arcY),
            //                SweepDirection = SweepDirection.Clockwise,
            //                IsLargeArc = isLargeArc,
            //            };
            //            var line2Segment = new LineSegment(new Point(centerX, centerY), false);

            //            var pathFigure = new PathFigure(
            //                new Point(centerX, centerY),
            //                new List<PathSegment>()
            //                {
            //                    line1Segment,
            //                    arcSegment,
            //                    line2Segment,
            //                },
            //                true);

            //            var pathFigures = new List<PathFigure>() { pathFigure, };
            //            var pathGeometry = new PathGeometry(pathFigures);
            //            var path = new Path()
            //            {
            //                Fill = category.ColorBrush,
            //                Data = pathGeometry,
            //            };
            //            FavoriteGenres.Children.Add(path);

            //            prevAngle = angle;


            //            // draw outlines
            //            var outline1 = new Line()
            //            {
            //                X1 = centerX,
            //                Y1 = centerY,
            //                X2 = line1Segment.Point.X,
            //                Y2 = line1Segment.Point.Y,
            //                Stroke = Brushes.White,
            //                StrokeThickness = 5,
            //            };
            //            var outline2 = new Line()
            //            {
            //                X1 = centerX,
            //                Y1 = centerY,
            //                X2 = arcSegment.Point.X,
            //                Y2 = arcSegment.Point.Y,
            //                Stroke = Brushes.White,
            //                StrokeThickness = 5,
            //            };

            //            FavoriteGenres.Children.Add(outline1);
            //            FavoriteGenres.Children.Add(outline2);
            //        }
            //    }
            //}

            //public class Category
            //{
            //    public float Percentage { get; set; }
            //    public string Title { get; set; }
            //    public Brush ColorBrush { get; set; }
        }
    }
}
