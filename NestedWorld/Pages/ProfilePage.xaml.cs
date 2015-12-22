using NestedWorld.Classes.ElementsGame.Users;
using NestedWorld.Classes.Stats;
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
    public sealed partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (e.Parameter == null)
                {
                    mainView.DataContext = App.core.user;
                }
                else
                {
                    User user = e.Parameter as User;
                    mainView.DataContext = user;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.Navigate(typeof(Pages.HomePage));
                    a.Handled = true;
                }
            };
            battleStats.DataContext = Stats.NewStat("Battle Statstics", 20, 1, 15);
            catchStats.DataContext = Stats.NewStat("Catch Statistics", 40, 2, 15);
            areaStats.DataContext = Stats.NewStat("Areas Statistics", 10, 10, 10);
        }
    }
}
