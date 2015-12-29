using NestedWorld.View.MapViews;
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
    public sealed partial class MapView : UserControl
    {
        private UserMapList userMapList;
        private MonsterMapList monsterMapList;

        public MapControlView mapControlView;
        public MapView()
        {
            this.InitializeComponent();
            userMapList = new UserMapList();
            monsterMapList = new MonsterMapList();
            monsterMapList.root = stackPanelRoot;

            mapControlView = new MapControlView();
            stackPanelRoot.Children.Add(mapControlView);
            userMapList.root = stackPanelRoot;
            userMapList.DataContext = App.core.userList.userList;
            setSize(Window.Current.Bounds.Width);
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            setSize(e.Size.Width);
        }

        private void setSize(double Width)
        {
            mapControlView.Width = Width - ((stackPanelRoot.Children.Count - 1) * 300);
        }

        private void ShowAlly(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton button = sender as AppBarToggleButton;
            if (button.IsChecked == true)
            {
                userMapList.Show();
                mapControlView.ShowUser();
            }
            else
                userMapList.Remove();
            setSize(Window.Current.Bounds.Width);

        }

        private void ShowMonster(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton button = sender as AppBarToggleButton;
            if (button.IsChecked == true)
                monsterMapList.Show();
            else
                monsterMapList.Remove();
            setSize(Window.Current.Bounds.Width);
        }
        private void ShowAreas(object sender, RoutedEventArgs e)
        {

        }

        private void ShowUsers(object sender, RoutedEventArgs e)
        {

        }
    }
}
