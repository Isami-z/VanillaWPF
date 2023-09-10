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
    /// Interaction logic for GuideDemo.xaml
    /// </summary>
    public partial class GuideDemo : Window
    {
        public GuideDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<GuideVo> list = new List<GuideVo>()
            {
                new GuideVo() { Uc = btn1, Content = "我是button， 是第一步"},
                 new GuideVo() { Uc = tb1, Content = "我是textbox， 是第二步"},
                  new GuideVo() { Uc = rb1, Content = "我是radiobutton， 是第三步"},
            };

            GuideWindow guideWindow = new GuideWindow(this, list);

            guideWindow.ShowDialog();
        }
    }
}
