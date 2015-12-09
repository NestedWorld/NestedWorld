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
    public sealed partial class MapView : UserControl
    {
        public MapView()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            SetElementSize(Window.Current.Bounds.Width, Window.Current.Bounds.Height);
        }

        private void SetElementSize(double width, double height)
        {
            mapView.Width = width;
            mapView.Height = (height * 1) / 3;
            AreaListView.Width = width;
            if (width >= 750)
            {
                mapView.Width = width - 450;
                AreaListView.Width = 400;
                mapView.Height = height - mapView.reduce;
            }
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SetElementSize(e.Size.Width, e.Size.Height);
        }
    }
}
