using NestedWorld.Classes.ElementsGame.Monsters;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NestedWorld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();

            App.core.mfv = monsterFullView;
            monsterView.monsterList = App.core.monsterList;
            userView.userList = App.core.userList;
            monsterListView.monsterList = App.core.monsterUserList;
            homeView.UserName = "Thomas";
            homeView.UserLevel = 6;
            homeView.UserImage = "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xlp1/v/t1.0-1/p160x160/10922803_10208019930037378_4351704227098544776_n.jpg?oh=fd24e44ae68ee73ccdb54d4c3f4058a8&oe=569E0588&__gda__=1456530740_111b8273a6a7f61b7a60c9763d4dc96c";
            homeView.BackgroundImage = "https://scontent-mia1-1.xx.fbcdn.net/hphotos-xfp1/t31.0-8/10984565_10206388417970596_1404781524257364777_o.jpg";
            //init();
            

        }

        public void init()
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.BattlePage));
        }
    }
}
