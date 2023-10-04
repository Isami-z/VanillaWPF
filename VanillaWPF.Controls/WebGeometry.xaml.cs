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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VanillaWPF.Controls
{
    /// <summary>
    /// Interaction logic for WebGeometry.xaml
    /// </summary>
    public partial class WebGeometry : UserControl
    {
        List<Point> points = new List<Point>();
        public WebGeometry()
        {
            InitializeComponent();
        }

        public void DrawWeb()
        {
            if (points.Count > 1)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    for (int j = i + 1; j < points.Count; j++)
                    {
                        DrawLine(points[i], points[j]);
                    }
                }
            }

            foreach (Point p in points)
            {
                Ellipse ellipse = new Ellipse()
                {
                    Fill = Brushes.Coral,
                    Width = 15,
                    Height = 15,
                };
                Canvas.SetLeft(ellipse, p.X - 7.5);
                Canvas.SetTop(ellipse, p.Y - 7.5);

                MainCanvas.Children.Add(ellipse);
            }

        }

        public void DrawLine(Point p1, Point p2)
        {
            Line line = new Line()
            {
                X1 = p1.X,
                Y1 = p1.Y,
                X2 = p2.X,
                Y2 = p2.Y,


                Stroke = Brushes.Gold,
                StrokeThickness = 2,
            };

            MainCanvas.Children.Add(line);
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            points.Add(e.GetPosition(MainCanvas));
            MainCanvas.Children.Clear();
            DrawWeb();
        }
    }
}
