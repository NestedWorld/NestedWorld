using NestedWorld.Classes.ElementsGame.Shop;
using NestedWorld.Common;
using NestedWorld.Model;
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

namespace NestedWorld.View
{
    public sealed partial class ShopView : UserControl
    {
        private Shop _shop;

        public Shop shop
        {
            get
            {
                return _shop;
            }
            set
            {
                _shop = value;
                GroupeListView.DataContext = value;
            }
        }


        public ShopView()
        {
            InitializeComponent();
        }

    }
}
