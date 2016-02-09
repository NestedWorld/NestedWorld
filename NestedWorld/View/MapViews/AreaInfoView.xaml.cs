using NestedWorld.Classes.DesignUtilities;
using NestedWorld.Classes.ElementsGame.Maps;
using NestedWorld.Classes.Garden;
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

namespace NestedWorld.View.MapViews
{
    public sealed partial class AreaInfoView : UserControl
    {

        private CircularPresentorItem presentorItem;
        public AreaInfoView(Area area)
        {
            this.InitializeComponent();
            this.DataContext = area;
            this.presentorItem = new CircularPresentorItem(area.Name, area.Image, area.ItemList, 400,
                100, 5);
            this.presentorItem.contenor = contenorGarden;
            this.presentorItem.Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup daddy = this.Parent as Popup;

            daddy.IsOpen = false;
        }
    }
}
