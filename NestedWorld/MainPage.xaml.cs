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

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.HomePage));
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

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            popupView.Child = new PopUp.SettingsPopUp();
            popupView.IsOpen = true;
        }
    }
}
