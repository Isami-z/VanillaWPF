using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VanillaWPF.Controls
{
    public class RibbonPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count < 1) return new Size(0, 0);
            UIElement firstChild = (UIElement)Children[0];

            firstChild.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            if (Children.Count < 2) return firstChild.DesiredSize;

            double numberColumns = Math.Ceiling((Children.Count - 1) / 5d);
            double maxWidthForRemainingChild = 0;

            for (int i = 1; i < Children.Count; i++)
            {
                UIElement child = Children[i];
                child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));

                maxWidthForRemainingChild = Math.Max(maxWidthForRemainingChild, child.DesiredSize.Width);
            }

            return new Size(firstChild.DesiredSize.Width + maxWidthForRemainingChild * numberColumns, firstChild.DesiredSize.Height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count < 1) return new Size(0, 0);
            UIElement firstChild = Children[0];
            Point childOrigin = new Point(0, 0);
            Size firstChildSize = new Size(firstChild.DesiredSize.Width, finalSize.Height);
            firstChild.Arrange(new Rect(childOrigin, firstChildSize ));
            if (Children.Count < 2) return finalSize;
            double numberColumns = Math.Ceiling((Children.Count - 1) / 5d);
            double witdhForEachChild = (finalSize.Width - firstChildSize.Width) / numberColumns;
            Size childSize = new Size(witdhForEachChild, firstChildSize.Height / 5d);
            childOrigin = new Point(firstChild.DesiredSize.Width, 0);
            for (int i = 1; i < Children.Count; i++)
            {
                if ((i - 1) % 5 == 0)
                {
                    childOrigin.Y = 0;
                    childOrigin.X += witdhForEachChild;
                }

                Children[i].Arrange(new Rect(childOrigin, childSize));
                childOrigin.Y += childSize.Height;

            }
            return finalSize;
        }
    }
}
