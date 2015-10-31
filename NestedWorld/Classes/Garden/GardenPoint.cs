using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace NestedWorld.Classes.Garden
{
    public class GardenPoint
    {
        public Thumb thumb { get; private set; }
        public GardenPoint(string name, string imagesource)
        {
            thumb = new Thumb();
            ControlTemplate template = Application.Current.Resources["GardenPoint"] as ControlTemplate;
            //            (FrameworkElement)template.find
            thumb.Height = 100;
            thumb.Width = 100;
            thumb.Template = template;
            thumb.DragDelta += T_DragDelta;
        }

        public void Draw(Canvas canvas)
        {
            canvas.Children.Add(thumb);
        }

        private void T_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
            Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);
        }
    }
}
