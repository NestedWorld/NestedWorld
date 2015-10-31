using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace NestedWorld.Classes.Garden
{
    public class GardenLine
    {

        public GardenLine(string name, string imagesource)
        {

        }

        public void Draw(Canvas canvas)
        {

        }

        public void DragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb t = sender as Thumb;

            Canvas.SetLeft(t, Canvas.GetLeft(t) + e.HorizontalChange);
            Canvas.SetTop(t, Canvas.GetTop(t) + e.VerticalChange);
        }
    }
}
