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
    /// Interaction logic for GuideWindow.xaml
    /// </summary>
    public partial class GuideWindow : Window
    {
        List<GuideVo> list; PathGeometry borGeometry = new PathGeometry();
        int index = 0;
        public GuideWindow(Window win, List<GuideVo> list)
        {
            InitializeComponent();

            this.Width = win.Width;
            this.Height = win.Height;
            this.Top = win.Top;
            this.Left = win.Left;
            this.WindowState = win.WindowState;
            this.list = list;
            show(index + 1, list[index].Uc, list[index].Content);

        }
        private void show(int xh, FrameworkElement fe, string con, Visibility vis = Visibility.Visible)
        {
            Point point = fe.TransformToAncestor(Window.GetWindow(fe)).Transform(new Point(0, 0));//获取控件坐标点

            RectangleGeometry rg = new RectangleGeometry();
            rg.Rect = new Rect(0, 0, this.Width, this.Height);
            borGeometry = Geometry.Combine(borGeometry, rg, GeometryCombineMode.Union, null);
            bor.Clip = borGeometry;

            RectangleGeometry rg1 = new RectangleGeometry();
            rg1.Rect = new Rect(point.X, point.Y, fe.ActualWidth + 10, fe.ActualHeight + 10);
            borGeometry = Geometry.Combine(borGeometry, rg1, GeometryCombineMode.Exclude, null);

            bor.Clip = borGeometry;

            HintUC hit = new HintUC(xh.ToString(), con, vis);
            Canvas.SetLeft(hit, point.X + fe.ActualWidth + 3);
            Canvas.SetTop(hit, point.Y + fe.ActualHeight + 3);
            hit.nextHintEvent -= Hit_nextHintEvent;
            hit.nextHintEvent += Hit_nextHintEvent;
            can.Children.Add(hit);

            index++;
        }

        private void Hit_nextHintEvent()
        {
            if (list[index - 1] != null)
            {
                can.Children.Clear();
            }
            if (index == list.Count - 1)
                show(index + 1, list[index].Uc, list[index].Content, Visibility.Collapsed);
            else
                show(index + 1, list[index].Uc, list[index].Content);
        }
    }
}
