using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View.ShopViews
{
    public sealed partial class ShopElementInformation : UserControl
    {
        public double Top
        {
            get { return Canvas.GetTop(this); }
            set { Canvas.SetTop(this, value); }
        }

        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set { Canvas.SetLeft(this, value); }
        }

        public int Zindex
        {
            get { return Canvas.GetZIndex(this); }
            set { Canvas.SetZIndex(this, value); }
        }
        public ShopView shopView { get; set; }

        public ShopElementInformation()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Item item = this.DataContext as Model.Item;

            item.Buy();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            shopView.columSelect = ColumSelect.ITEM;
        }
    }
}
