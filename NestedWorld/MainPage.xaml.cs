using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NestedWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            // Init();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           // Utils.ThemeSelector.SetTheme();

            EnterAnnimation.Begin();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          if (UserNameText.Text == string.Empty)
                return;
            if (PassWordText.Password == string.Empty)
                return;
            progressRing.IsActive = true;
            loginButton.Visibility = Visibility.Collapsed;
            string ret = await App.network.Connect(UserNameText.Text, PassWordText.Password);
            //string ret = await App.network.Connect("thomas.caron@epitech.eu", "toto");
            progressRing.IsActive = false;
            if (ret == string.Empty)
            {
                await App.core.Init();
                loginButton.Visibility = Visibility.Visible;
                Frame.Navigate(typeof(Pages.HomePage));
            }
            else
                ShowError(ret);
            loginButton.Visibility = Visibility.Visible;
          
        }

        private async void ShowError(string ErrorMessage)
        {
            var messageDialog = new MessageDialog(ErrorMessage);
            await messageDialog.ShowAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Regiter_Click(object sender, RoutedEventArgs e)
        {
            popupView.Child = new PopUp.RegisterPopUp();
            popupView.IsOpen = true;
        }

        private void Forgot_Click(object sender, RoutedEventArgs e)
        {
            popupView.Child = new PopUp.ForgotPassPopUp();
            popupView.IsOpen = true;
        }

        public static bool DeviceIsPhone()
        {
            EasClientDeviceInformation info = new EasClientDeviceInformation();
            string system = info.OperatingSystem;

            Debug.WriteLine(system);

            return true;
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine(DeviceIsPhone());
            //popupView.Child = new PopUp.SettingsPopUp();
            //popupView.IsOpen = true;
        }
    }
}
