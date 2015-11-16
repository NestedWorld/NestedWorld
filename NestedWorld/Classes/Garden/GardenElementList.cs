using NestedWorld.View.GardenViews;
using NestedWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.Garden
{
    public class GardenElementList
    {
        public List<GardenElement> _list;
        private GardenElementListViewModel _viewModel;

        public List<GardenElement> list
        {
            get { return _list; }
            set
            {
                _list = value;
                if (viewModel != null)
                    viewModel.list = new System.Collections.ObjectModel.ObservableCollection<GardenElement>(list);
            }
        }
        public GardenElementListViewModel viewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                _viewModel.list = new System.Collections.ObjectModel.ObservableCollection<GardenElement>(list);
            }
        }

        public GardenElementList()
        {
            list = new List<GardenElement>();
        }

        public void Add(GardenElement element)
        {
            list?.Add(element);
        }
    }
}
