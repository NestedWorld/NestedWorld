using NestedWorld.Classes.ElementsGame;
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
    public sealed partial class MonsterSoloView : UserControl
    {
        public static readonly DependencyProperty MonsterNameProperty = DependencyProperty.Register("MonsterName", typeof(string), typeof(MonsterSoloView), null);
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register("Level", typeof(string), typeof(MonsterSoloView), null);
        public static readonly DependencyProperty MonsterImageProperty = DependencyProperty.Register("MonsterImage", typeof(string), typeof(MonsterSoloView), null);
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Windows.UI.Color), typeof(MonsterSoloView), null);

        public string MonsterName
        {
            get { return GetValue(MonsterNameProperty) as string; }
            set { SetValue(MonsterNameProperty, value); }
        }

        public string Level
        {
            get { return GetValue(LevelProperty) as string; }
            set { SetValue(LevelProperty, value + " lvl"); }
        }

        public string MonsterImage
        {
            get { return GetValue(MonsterImageProperty) as string; }
            set { SetValue(MonsterImageProperty, value); }
        }
        public TypeEnum Type
        {
            get { return TypeEnum.FIRE; }
            set { BackgroundColor = Utils.ColorUtils.GetTypeColor(value); }
        }

        public string BackgroundColor
        {
            get { return string.Empty; }
            set { SetValue(BackgroundColorProperty, Utils.ColorUtils.GetColorFromHex(value)); }
        }

        public MonsterSoloView()
        {
            this.InitializeComponent();
            this.Loaded += MonsterSoloView_Loaded;
           // this.DataContext = this;
        }

        private void MonsterSoloView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LevelTextBlock.Text += " Lvl";
        }

        public Classes.ElementsGame.Monsters.UserMonster userMonster
        {
            get
            {
                return null;
            }
            set
            {
                MonsterName = userMonster.Name;
                Level = userMonster.Level.ToString();
                BackgroundColor = Utils.ColorUtils.GetTypeColor(userMonster.Type);
            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
           // root.Navigate(typeof(Pages.MonsterPage));
        }
    }
}
