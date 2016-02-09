using NestedWorld.Classes.Garden;
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

namespace NestedWorld.View.GardenViews
{
    public sealed partial class GardenItem : UserControl
    {
      

        public double left { get { return 0; } set { Canvas.SetLeft(this, value); } }
        public double top { get { return 0; } set { Canvas.SetTop(this, value); } }

        public GardenItem()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.CanDrag = true;
           // time = 0;
        }

      

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Tapped");
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            Debug.WriteLine("Holding");
        }

        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Debug.WriteLine("RightTapped");
        }
    }
}
