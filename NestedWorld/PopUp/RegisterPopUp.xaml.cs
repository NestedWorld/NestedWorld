using Facebook;
using Facebook.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using System.Net.Http;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.PopUp
{
    public sealed partial class RegisterPopUp : UserControl
    {
        public RegisterPopUp()
        {
            this.InitializeComponent();
            this.Loaded += RegisterPopUp_Loaded;
        }

        private void RegisterPopUp_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAnnimation.Begin();
        }

        private async void FacebookButton_Click(object sender, RoutedEventArgs e)
        {
            FBSession sess = FBSession.ActiveSession;
            sess.FBAppId = "1667835350097099";
            sess.WinAppId = "S-1-15-2-402772943-4257055698-2726507914-3453098009-221101651-2929789630-257638726";

            List<string> permissionList = new List<string>();
            permissionList.Add("public_profile");
            permissionList.Add("user_friends");
            permissionList.Add("user_photos");
            permissionList.Add("publish_actions");
            FBPermissions permissions = new FBPermissions(permissionList);

            FBResult result = await sess.LoginAsync(permissions);

            if (result.Succeeded)
            {
                Debug.WriteLine("success");
                FBUser user = sess.User;

                Debug.WriteLine(user.FirstName);
                Debug.WriteLine(user.LastName);
                Debug.WriteLine(user.Link);


            }
            else
            {
                Debug.WriteLine("Fail");
            }
        }

      

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

            Popup p = this.Parent as Popup;
            RemoveAnnimation.Begin();
            p.IsOpen = false;
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Request.Auth.Register register = new Classes.Request.Auth.Register();

            if (passOneEntry.Password != passTwoEntry.Password)
            {
                setError("password");
                return;
            }
            if (lastnameEntry.Text == string.Empty)
            {
                setError("LastName");
                return;
            }

            if (firstnameEntry.Text == string.Empty)
            {
                setError("FistName");
                return;
            }

            if (mailEntry.Text == string.Empty || !mailEntry.Text.Contains("@"))
            {
                setError("Mail");
                return;
            }



            register.SetParam(mailEntry.Text, passOneEntry.Password, lastnameEntry.Text + " " + firstnameEntry.Text);

            try
            {
                var obj = await register.GetJsonAsync();
                Popup p = this.Parent as Popup;
                RemoveAnnimation.Begin();

                p.IsOpen = false;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                setError("Error Network");
                Debug.WriteLine(ex);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                setError("Error Json");

                Debug.WriteLine(jEx);
            }
         
        }

        private void setError(string errorMessage)
        {
            ErrorTextBlock.Text = errorMessage;
            ErrorAnnimation.Begin();
        }
    }
}
