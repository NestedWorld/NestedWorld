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
    public sealed partial class AreaListView : UserControl
    {
        public GridView List { get { return glist; } set { glist = value; } }
        public AreaListView()
        {
            this.InitializeComponent();
        //    List.Loaded += List_Loaded;
            App.core.areaList.areaListView = this;

        }

        private void List_Loaded(object sender, RoutedEventArgs arg)
        {
            if (sender == null)
                return;
            VariableSizedWrapGrid g = (VariableSizedWrapGrid)sender;

            SizeChangedEventHandler handler = (s, e) =>
            {
                g.ItemHeight = (g.ActualHeight) / 2.0;
                g.ItemWidth = g.ItemHeight;
            };

            handler(null, null);

            g.SizeChanged += handler;
        }
    }
}
