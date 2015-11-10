using NestedWorld.View.GardenViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NestedWorld.Classes.Garden
{
    public class Garden
    {
        public List<GardenItem> listItem { get; set; }
        public Canvas canvas { get; set; }
        public Garden(Canvas canva, int numberOfItem = 3)
        {
            Window.Current.SizeChanged += Current_SizeChanged;
            this.canvas = canva;
            InitItem(numberOfItem);
            SetPos(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
        }

        public void Add(GardenItem item)
        {
            listItem.Add(item);
            canvas.Children.Add(item);
            SetPos(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
        }

        private void InitItem(int numberOfItem)
        {
            listItem = new List<GardenItem>();
            for (int i = 0; i < numberOfItem; i++)
            {
               GardenItem item = new GardenItem();

                item.ImageItem = "ms-appx:///Assets/NestedWorldLogo.png";
                listItem.Add(item);
                canvas.Children.Add(item);
            }
        }

        private void SetPos(double height, double width)
        {
            double PidivTwo = (Math.PI / 2);
            double alpha = (2 * Math.PI) / listItem.Count;
            double defautTop = ((height) / 2) - listItem[0].Height;
            double defautLeft = ((width) / 2) - (listItem[0].Width / 2);
            int index = 0;
            foreach (GardenItem item in listItem)
            {
                Debug.WriteLine("alpha = " + alpha);
                //Debug.WriteLine(Math.Sin(PidivTwo + index * alpha));
                //Debug.WriteLine(Math.Cos(PidivTwo + index * alpha));
                item.top = ((Math.Sin(PidivTwo + index * alpha))  * 200) + defautTop;
                item.left =(( Math.Cos(PidivTwo + index * alpha)) * 200) + defautLeft;
                index++;
            }
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SetPos(e.Size.Height, e.Size.Width);
        }
    }
}
