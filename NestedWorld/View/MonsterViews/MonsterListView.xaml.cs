using NestedWorld.Classes.ElementsGame.Monsters;
using NestedWorld.View.MonsterViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MonsterListView : UserControl
    {

        public MonsterList monsterList
        {
            get { return null; }
            set
            {
                try
                {
                    //   MonsertGridView.DataContext = new ObservableCollection<UserMonster>(value.monsterList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        public MonsterListView()
        {
            this.InitializeComponent();
            this.DataContextChanged += MonsterListView_DataContextChanged;
        }

        private void MonsterListView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            try
            {
                if (this.DataContext != null)
                    MonsterGridView.DataContext = new ObservableCollection<Monster>(this.DataContext as List<Monster>);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MonsertGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;

            root.Navigate(typeof(Pages.MonsterPage), (sender as GridView).SelectedItem);
        }
    }
}
