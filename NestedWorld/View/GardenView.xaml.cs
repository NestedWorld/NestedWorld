using NestedWorld.Classes.Garden;
using NestedWorld.View.GardenViews;
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

namespace NestedWorld.View
{
    public sealed partial class GardenView : UserControl
    {
        public GardenView()
        {
            this.InitializeComponent();
            App.core.garden.canvas = mainCanvas;
            mainCanvas.AllowDrop = true;
            mainCanvas.Drop += Grid_Drop;
            App.core.garden.init();
            App.core.garden.viewModel = new ViewModel.GardenElementListViewModel(gardenElementListView);
            App.core.garden.elementList.viewModel = App.core.garden.viewModel;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            object sourceItem;
            e.Data.Properties.TryGetValue("item", out sourceItem);
            if (sourceItem == null)
                return;
            Debug.WriteLine("_canvas_Drop");

            GardenElement element = sourceItem as GardenElement;
            GardenItem item = new GardenItem();
            item.element = element;
            App.core.garden.Add(item);
        }
    }
}
