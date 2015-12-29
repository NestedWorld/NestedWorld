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

             init();
            

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

          //  App.core.Init();
            App.core.mfv = monsterFullView;
            monsterView.monsterList = App.core.monsterUserList;
            userView.userList = App.core.userList;
            monsterListView.monsterList = App.core.monsterList;
            homeView.DataContext = App.core.user;

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.ChatPage));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

            popupView.Child = new PopUp.NewBattlePopUp(App.core.userList.userList[0]);
            popupView.IsOpen = true;

            //Frame.Navigate(typeof(Pages.PrepareBattlePage));
        }

        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            init();
            //Frame.Navigate(typeof(Pages.SettingsPage));
        }

        private void homeView_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.ProfilePage));
        }
    }
}
