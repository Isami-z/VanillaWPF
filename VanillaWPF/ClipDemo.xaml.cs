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

namespace VanillaWPF
{
    /// <summary>
    /// Interaction logic for ClipDemo.xaml
    /// </summary>
    public partial class ClipDemo : Window
    {
        private bool isDown = false;

        PathGeometry gridGeometry = new PathGeometry();

        public ClipDemo()
        {
            InitializeComponent();
            RectangleGeometry rectangleGeometry = new RectangleGeometry();
            rectangleGeometry.Rect = new Rect(0, 0, this.Width, this.Height);
            gridGeometry = Geometry.Combine(gridGeometry, rectangleGeometry, GeometryCombineMode.Union, null);
            grid.Clip = gridGeometry ;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                EllipseGeometry eg = new EllipseGeometry();
                eg.Center = e.GetPosition(this);
                eg.RadiusX = 50;
                eg.RadiusY = 50;
                gridGeometry = Geometry.Combine(gridGeometry, eg, GeometryCombineMode.Exclude, null);
                grid.Clip = gridGeometry;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDown = true;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDown = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}
