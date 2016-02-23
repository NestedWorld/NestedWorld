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

namespace NestedWorld.View.BattleViews
{
    public sealed partial class UserMonster : UserControl
    {
        public static readonly DependencyProperty MonsterImageProperty = DependencyProperty.Register("MonsterImage", typeof(string), typeof(UserMonster), null);
        public static readonly DependencyProperty MonsterNameProperty = DependencyProperty.Register("MonsterName", typeof(string), typeof(UserMonster), null);
        public static readonly DependencyProperty MonsterLevelProperty = DependencyProperty.Register("MonsterLevel", typeof(string), typeof(UserMonster), null);

        public string MonsterImage
        {
            get { return ""; }
            set { SetValue(MonsterImageProperty, value); }
        }

        public string MonsterName
        {
            get { return ""; }
            set { SetValue(MonsterNameProperty, value); }
        }

        public int MonsterLevel
        {
            get { return 0; }
            set { SetValue(MonsterLevelProperty, value.ToString() + "lvl"); }
        }

        public int MonsterLife
        {
            get { return 0; }
            set
            {
                LifeBar.Width = value * 3.25;
                if (value < 25)
                    LifeBar.Fill = new SolidColorBrush(Utils.ColorUtils.GetColorFromHex("#FFFF0000"));
            }
        }

        public Classes.ElementsGame.Monsters.Monster monster
        {
            get { return null; }
            set
            {
                MonsterImage = value.Image;
                MonsterName = value.Name;
                MonsterLevel = value.Level;
                MonsterLife = value.Life;
            }
        }



        public UserMonster()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
