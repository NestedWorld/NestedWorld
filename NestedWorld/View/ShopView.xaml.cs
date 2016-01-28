using NestedWorld.Classes.ElementsGame.Shop;
using NestedWorld.Common;
using NestedWorld.Model;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View
{
    public enum ColumSelect
    {
        GROUPE,
        ITEM,
        INFO,
    }

    public sealed partial class ShopView : UserControl
    {
        private Shop _shop;
        private ColumSelect _columSelect;

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

        public ColumSelect columSelect
        {
            get { return _columSelect; }
            set
            {
                _columSelect = value;
                SetSize(Window.Current.Bounds.Width);
            }
        }

        public ShopView()
        {
            InitializeComponent();
            GroupeListView.shopElementListView = ElementListView;
            GroupeListView.shopView = this;
            ElementListView.shopElementInformation = ElementInformation;
            ElementListView.shopView = this;
            shopUserInfo.DataContext = App.core.user;
            ElementInformation.shopView = this;
            _columSelect = ColumSelect.GROUPE;
            Window.Current.SizeChanged += Current_SizeChanged;
            SetSize(Window.Current.Bounds.Width);
        }


        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SetSize(e.Size.Width);
        }


        private void SetSize(double width)
        {
            Debug.WriteLine("width " + width.ToString());

            if (width > 920)
            {
                switch (_columSelect)
                {
                    case (ColumSelect.GROUPE):
                        ElementListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Visible;
                        break;
                    case (ColumSelect.ITEM):
                        GroupeListView.Visibility = Visibility.Visible;
                        ElementListView.Visibility = Visibility.Visible;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        ElementListView.Left = GroupeListView.Width;
                        break;
                    case (ColumSelect.INFO):
                        GroupeListView.Visibility = Visibility.Visible;
                        ElementListView.Visibility = Visibility.Visible;
                        ElementInformation.Visibility = Visibility.Visible;
                        if ((GroupeListView.Width + ElementListView.Width + 20) < width)
                            ElementInformation.Width = width - (GroupeListView.Width + ElementListView.Width + 20);
                        else
                            ElementInformation.Width = width;
                        ElementInformation.Left = ElementListView.Width + GroupeListView.Width;
                        break;
                }
            }
            else if (width < 920 && width > 620)
            {
                switch (_columSelect)
                {
                    case (ColumSelect.GROUPE):
                        ElementListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Visible;
                        GroupeListView.Width = (width) / 2;
                        break;
                    case (ColumSelect.ITEM):
                        ElementListView.Visibility = Visibility.Visible;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Visible;

                        ElementListView.Width = (width) / 2;
                        ElementListView.Left = GroupeListView.Width;
                        break;
                    case (ColumSelect.INFO):
                        ElementListView.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Visibility = Visibility.Visible;
                        ElementInformation.Width = width;
                        ElementInformation.Left = 0;
                        break;
                }
            }
            else if (width < 620)
            {
                switch (_columSelect)
                {
                    case (ColumSelect.GROUPE):
                        ElementListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Visible;
                        GroupeListView.Width = width;
                        break;
                    case (ColumSelect.ITEM):
                        ElementListView.Visibility = Visibility.Visible;
                        ElementInformation.Visibility = Visibility.Collapsed;
                        GroupeListView.Visibility = Visibility.Collapsed;

                        ElementListView.Left = 0;
                        ElementListView.Width = width;
                        break;
                    case (ColumSelect.INFO):
                        ElementListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Visibility = Visibility.Visible;
                        GroupeListView.Visibility = Visibility.Collapsed;
                        ElementInformation.Width = width;
                        ElementInformation.Left = 0;
                        break;
                }
            }
            else
            {
                Debug.WriteLine("No Suported");
            }
        }
    }
}
