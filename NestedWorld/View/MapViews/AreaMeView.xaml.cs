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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View.MapViews
{
    public sealed partial class AreaMeView : UserControl
    {
        public AreaMeView()
        {
            this.InitializeComponent();
            this.DataContextChanged += AreaMeView_DataContextChanged;
        }

        private void AreaMeView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Area area = this.DataContext as Area;

            var shape = area.getPolygon();
            shape.AddData(area);
            mapControl.MapElements.Add(shape);
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

        }
    }
}
