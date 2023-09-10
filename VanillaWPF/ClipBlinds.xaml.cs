using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VanillaWPF
{
    /// <summary>
    /// Interaction logic for ClipBlinds.xaml
    /// </summary>
    public partial class ClipBlinds : Window
    {
        PathGeometry pg = null;
        DispatcherTimer timer = null;

        public ClipBlinds()
        {
            InitializeComponent();

            pg = new PathGeometry();
            timer = new DispatcherTimer();
        }

        double size = 100;
        double size1 = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pg != null)
            {
                pg.Clear();
            }

            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (size1 < size)
            {
                for (int i = 0; i < Math.Ceiling(Image1.Width /  size); i++)
                {
                    RectangleGeometry rg = new RectangleGeometry();

                    rg.Rect = new Rect(i * size, 0, size1, Image1.Height);

                    pg = PathGeometry.Combine(pg, rg, GeometryCombineMode.Union, null);

                    Image1.Clip = pg;
                }
            }
            else
            {
                timer.Stop();
                size1 = 0;
            }
            size1 += 2;
        }
    }
}
