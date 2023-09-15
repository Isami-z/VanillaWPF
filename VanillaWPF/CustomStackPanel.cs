using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VanillaWPF
{
    public class CustomStackPanel : Panel
    {
        public CustomStackPanel() : base()
        {

        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size panelDesiredSize = new Size();
            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(availableSize);
                panelDesiredSize.Width += child.DesiredSize.Width;
                panelDesiredSize.Height += child.DesiredSize.Height;
            }
            return panelDesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 10;
            double y = 10;

            foreach (UIElement child in this.InternalChildren)
            {
                child.Arrange(new Rect(new Point(x, y), new Size(finalSize.Width - 10, child.DesiredSize.Height + 5)));
                y += child.DesiredSize.Height + 10;
            }
            return finalSize;
        }
    }
}
