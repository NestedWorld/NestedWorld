using NestedWorld.Classes.ElementsGame.Areas;
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
using NestedWorld.Utils;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View.MapViews
{
    public sealed partial class AreaAllyView : UserControl
    {
        public AreaAllyView()
        {
            this.InitializeComponent();
            this.DataContextChanged += AreaAllyView_DataContextChanged;
        }

        private async void AreaAllyView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Area area = this.DataContext as Area;

            var shape = area.getPolygon();
            shape.AddData(area);
            mapControl.MapElements.Add(shape);
            await mapControl.TrySetViewAsync(new Geopoint(area.geopointList[0]), 10, 0, 0, MapAnimationKind.Linear);
            DistanceTextBlock.Text = "-" + "km";  
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (InfoGrid.Visibility == Visibility.Collapsed)
            {
                InfoGrid.Visibility = Visibility.Visible;
                mapControl.Visibility = Visibility.Collapsed;
            }
            else
            {
                InfoGrid.Visibility = Visibility.Collapsed;
                mapControl.Visibility = Visibility.Visible;
            }

        }

        private void StackPanel_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
