using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using NestedWorld.Model;
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
    public sealed partial class ShopElementListView : UserControl
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

        private ItemGroup _itemGroup;
        private ShopElementInformation _shopElementInformation;
        public ShopView shopView { get; set; }
        public ShopElementInformation shopElementInformation
        {
            get { return _shopElementInformation; }
            set
            {
                _shopElementInformation = value;
            }
        }

        public Model.ItemGroup itemGroup
        {
            get { return _itemGroup; }
            set
            {
                _itemGroup = value;
                lv.DataContext = value.content;
                NameText.Text = value.Name;
            }
        }
        public ShopElementListView()
        {
            this.InitializeComponent();
            this.lv.SelectionChanged += Lv_SelectionChanged;
            
        }

        private void Lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Item item = lv.SelectedItem as Model.Item;
            _shopElementInformation.DataContext = item;
            shopView.columSelect = ColumSelect.INFO;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shopView.columSelect = ColumSelect.GROUPE;

        }
    }
}
