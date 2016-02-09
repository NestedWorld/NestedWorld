using NestedWorld.View.GardenViews;
using NestedWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NestedWorld.Classes.Garden
{
    public class Garden
    {
        public List<GardenItem> listItem { get; set; }
        private Canvas _canvas;
        public Canvas canvas { get { return _canvas; } set { _canvas = value; initCanvas(); } }

        public List<Model.Item> itemList { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();

        public Garden(List<Model.Item> itemList)
        {
            listItem = new List<GardenItem>(); // list of element display
            this.itemList = itemList;
        }

        private void initCanvas()
        {
            SetPos(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            foreach (GardenItem item in listItem)
            {
               // item.time++;
            }
        }

        public void Add(GardenItem item)
        {
            listItem.Add(item);
            canvas.Children.Add(item);
            SetPos(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
        }

        public void init()
        {
         /*   elementList.Add(new GardenElement("Fire Flower", "", "ms-appx:///Assets/Flower/flowerFire.png", ElementsGame.TypeEnum.FIRE));
            elementList.Add(new GardenElement("Water Flower", "", "ms-appx:///Assets/Flower/flowerWater.png", ElementsGame.TypeEnum.WATHER));
            elementList.Add(new GardenElement("Grass Flower", "", "ms-appx:///Assets/Flower/flowerGrass.png", ElementsGame.TypeEnum.GRASS));
            elementList.Add(new GardenElement("Stone Flower", "", "ms-appx:///Assets/Flower/flowerDirt.png", ElementsGame.TypeEnum.DIRT));
            elementList.Add(new GardenElement("Tunder Flower", "", "ms-appx:///Assets/Flower/flowerElec.png", ElementsGame.TypeEnum.ELEC));
            foreach (GardenElement element in elementList.list)
            {
                GardenItem tmp = new GardenItem();
                tmp.element = element;
                Add(tmp);
            }*/
        }
        private void SetPos(double height, double width)
        {
            if (listItem == null)
                return;
            if (listItem.Count <= 0)
                return;

            double PidivTwo = (Math.PI / 2);
            double alpha = (2 * Math.PI) / listItem.Count;
            double defautTop = ((height) / 2) - listItem[0].Height;
            double defautLeft = ((width) / 2) - (listItem[0].Width / 2);
            int index = 0;
            foreach (GardenItem item in listItem)
            {
                item.top = ((Math.Sin(PidivTwo + index * alpha)) * 175) + defautTop;
                item.left = ((Math.Cos(PidivTwo + index * alpha)) * 175) + defautLeft;
                index++;
            }
        }

    }
}
