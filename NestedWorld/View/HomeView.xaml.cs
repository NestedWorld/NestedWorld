using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View
{
    public sealed partial class HomeView : UserControl
    {
        public static readonly DependencyProperty UserImageProperty = DependencyProperty.Register("UserImage", typeof(string), typeof(HomeView), null);

        public string UserImage
        {
            get { return GetValue(UserImageProperty) as string; }
            set { SetValue(UserImageProperty, value); }
        }

        public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeof(string), typeof(HomeView), null);

        public string BackgroundImage
        {
            get { return GetValue(BackgroundImageProperty) as string; }
            set { SetValue(BackgroundImageProperty, value); }
        }


        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(HomeView), null);

        public string UserName
        {
            get { return GetValue(UserNameProperty) as string; }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserLevelProperty = DependencyProperty.Register("UserLevel", typeof(string), typeof(HomeView), null);

        public string userLevel
        {
            get { return GetValue(UserLevelProperty) as string; }
            set { SetValue(UserLevelProperty, value + " lvl"); }
        }

        public static readonly DependencyProperty MonsterCapturedProperty = DependencyProperty.Register("MonsterCaptured", typeof(string), typeof(HomeView), null);

        public int MonsterCaptured
        {
            get { return 0; }
            set { SetValue(MonsterCapturedProperty, value.ToString()); }
        }

        public static readonly DependencyProperty AreaCapturedProperty = DependencyProperty.Register("AreaCaptured", typeof(string), typeof(HomeView), null);

        public int AreaCaptured
        {
            get { return 0; }
            set { SetValue(AreaCapturedProperty, value.ToString()); }
        }

        public static readonly DependencyProperty AllyOnlineProperty = DependencyProperty.Register("AllyOnline", typeof(string), typeof(HomeView), null);

        public int AllyOnline
        {
            get { return 0; }
            set { SetValue(AllyOnlineProperty, value.ToString()); }
        }


        public static readonly DependencyProperty MonsterSeeProperty = DependencyProperty.Register("MonsterSee", typeof(string), typeof(HomeView), null);

        public int MonsterSee
        {
            get { return 0; }
            set { SetValue(MonsterSeeProperty, value.ToString()); }
        }


        public int UserLevel
        {
            get { return 0; }
            set { userLevel = value.ToString(); }
        }

        private void GridMain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("toto");
        }

        public HomeView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
