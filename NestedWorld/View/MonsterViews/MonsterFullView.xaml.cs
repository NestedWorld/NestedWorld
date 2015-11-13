using NestedWorld.Classes.ElementsGame.Monsters;
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

namespace NestedWorld.View.MonsterViews
{
    public sealed partial class MonsterFullView : UserControl
    {
        public UserMonster monsterToDisplay
        {
            get { return null; }
            set
            {
                mainStackPanel.Visibility = Visibility.Visible;
                monsterHeaderView.MonsterName = value.Name;
                monsterHeaderView.MonsterLevel = value.Level;
                monsterHeaderView.MonsterType = value.Type;
                monsterHeaderView.MonsterImage = value.Image;
                monsterHeaderView.MonsterCombat = 0;
                monsterHeaderView.MonsterVictory = 0;
                //monsterAttackView.monsterAttackList = value.monsterAttackList;
                monsterStatsView.Exp = value.Exp;
                monsterStatsView.Life = value.Life;
            }
        }
        public MonsterFullView()
        {
            this.InitializeComponent();
            mainStackPanel.Visibility = Visibility.Collapsed;

        }
    }
}
