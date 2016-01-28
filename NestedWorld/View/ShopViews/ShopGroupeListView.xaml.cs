using NestedWorld.Classes.ElementsGame.Shop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class ShopGroupeListView : UserControl
    {
        private ShopElementListView _shopElementListView;
        public ShopView shopView { get; set; }

        public double Top
        {
            get { return Canvas.GetTop(this);}
            set { Canvas.SetTop(this, value);}
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

        public ShopElementListView shopElementListView
        {
            get { return _shopElementListView; }
            set { _shopElementListView = value; }
        }
        public ShopGroupeListView()
        {
            this.InitializeComponent();
            this.DataContextChanged += ShopGroupeListView_DataContextChanged;
            this.lv.SelectionChanged += Lv_SelectionChanged;
        }

        private void Lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.ItemGroup gp = lv.SelectedItem as Model.ItemGroup;

            _shopElementListView.itemGroup = gp;
            shopView.columSelect = ColumSelect.ITEM;
            Debug.WriteLine(gp.Name);

            foreach (var i in gp.list)
            {
                Debug.WriteLine(i.Name);
            }
        }

        private void ShopGroupeListView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Shop shop = this.DataContext as Shop;
            lv.DataContext = shop.content;
            Debug.WriteLine("DataContextChanged");
        }

        public ListView listView { get { return lv; } set { lv = value; } }
    }
}
