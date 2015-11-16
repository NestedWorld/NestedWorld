using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestedWorld.View.GardenViews;
using NestedWorld.Classes.Garden;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using System.Diagnostics;

namespace NestedWorld.ViewModel
{
    public class GardenElementListViewModel
    {
        private GardenElementListView _gelv;
        private ObservableCollection<GardenElement> _list;
        private CoreDispatcher dispatcher;

        public View.GardenViews.GardenElementListView gelv
        {
            get { return _gelv; }
            set { _gelv = value; }
        }

        public ObservableCollection<GardenElement> list { get { return _list; } set { _list = value; update(); } }


        public GardenElementListViewModel(GardenElementListView listView)
        {
            list = new ObservableCollection<GardenElement>();
            gelv = listView;
            gelv.listView.DragItemsStarting += ListView_DragItemsStarting;
        }

        private void ListView_DragItemsStarting(object sender, Windows.UI.Xaml.Controls.DragItemsStartingEventArgs e)
        {
            var item = e.Items.FirstOrDefault();
            if (item == null)
                return;
            Debug.WriteLine("DragItemsStarting");
            e.Data.Properties.Add("item", item);
        }

        private async void update()
        {
            if (gelv == null)
                return;
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            await this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                gelv.listView.DataContext = list;
            });
        }


    }
}
