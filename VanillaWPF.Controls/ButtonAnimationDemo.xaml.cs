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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VanillaWPF.Controls
{
    /// <summary>
    /// Interaction logic for ButtonAnimationDemo.xaml
    /// </summary>
    public partial class ButtonAnimationDemo : UserControl
    {
        public ButtonAnimationDemo()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            DoubleAnimation heightAnimation = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromMilliseconds(300) };
            DoubleAnimation widthAnimation = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromMilliseconds(300) };

            button.BeginAnimation(WidthProperty, widthAnimation);
            button.BeginAnimation(HeightProperty, heightAnimation);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            DoubleAnimation heightAnimation = new DoubleAnimation() { To = 100, Duration = TimeSpan.FromMilliseconds(300) };
            DoubleAnimation widthAnimation = new DoubleAnimation() { To = 110, Duration = TimeSpan.FromMilliseconds(300) };

            button.BeginAnimation(WidthProperty, widthAnimation);
            button.BeginAnimation(HeightProperty, heightAnimation);
        }
    }
}
