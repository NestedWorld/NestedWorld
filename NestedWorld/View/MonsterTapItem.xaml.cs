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
    public sealed partial class MonsterTapItem : UserControl
    {

        public MonsterTapItem()
        {
            this.InitializeComponent();
        }

        public void Init()
        {
            monsterListView.DataContext = App.core.monsterList.monsterList;
          

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            monsterListView.DataContext = App.core.monsterList.SearchMonster((sender as TextBox).Text);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((sender as ComboBox).SelectedItem as TextBlock).Text)
            {
                case ("ByName"):
                    monsterListView.DataContext = App.core.monsterList.monsterListByName;
                    break;
                case ("ByLevel"):
                    monsterListView.DataContext = App.core.monsterList.monsterListByLevel;
                    break;
                case ("ByType"):
                    monsterListView.DataContext = App.core.monsterList.monsterListByType;
                    break;
                case ("ByID"):
                    monsterListView.DataContext = App.core.monsterList.monsterListByID;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            splitViewOption.IsPaneOpen = !splitViewOption.IsPaneOpen;
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if ((sender as ToggleSwitch).IsOn)
            {
                monsterListView.DataContext = App.core.monsterList.monsterList;
            }
            else
            {
                monsterListView.DataContext = App.core.monsterUserList.monsterList;
            }
        }
    }
}
