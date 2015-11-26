using NestedWorld.Classes.ElementsGame.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NestedWorld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatPage : Page
    {
        public ChatPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Init();
        }

        private void Init()
        {
            chanelListView.listView.DataContext = App.core.userList.userList;
            startNewChatView.Visibility = Visibility.Visible;
            chatView.Visibility = Visibility.Collapsed;
            chanelListView.listView.SelectionChanged += ListView_SelectionChanged;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = (sender as ListView).SelectedItem as User;
            Debug.WriteLine(user.Name);
            startNewChatView.Visibility = Visibility.Collapsed;
            chatView.Visibility = Visibility.Visible;
            chatView.channel = user.discution;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            /* if (chanelListView.Visibility == Visibility.Collapsed)
                 chanelListView.Visibility = Visibility.Visible;
             else
                 chanelListView.Visibility = Visibility.Collapsed;
                 */
        }

        private void MySplitView_PaneClosed(SplitView sender, object args)
        {

            //  chanelListView.Visibility = Visibility.Collapsed;

        }
    }
}
