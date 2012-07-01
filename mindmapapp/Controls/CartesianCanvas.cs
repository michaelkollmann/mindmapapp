using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace mindmapapp.Controls
{
    public class CartesianCanvas : Canvas
    {

        public CartesianCanvas()
        {
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new Point(arrangeSize.Width / 2, arrangeSize.Height / 2);
            UIElementCollection mychildren = Children;

            foreach (UIElement element in mychildren)
            {
                double x = 0.0;
                double y = 0.0;
                double left = GetLeft(element);
                if (!double.IsNaN(left))
                {
                    x = left;
                }

                double top = GetTop(element);
                if (!double.IsNaN(top))
                {
                    y = top;
                }

                element.Arrange(new Rect(new Point(middle.X + x, middle.Y + y), element.DesiredSize));
            }

            return arrangeSize;
        }

    }

}
