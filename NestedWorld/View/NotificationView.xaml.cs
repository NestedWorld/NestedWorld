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
    public sealed partial class NotificationView : UserControl
    {

        public static readonly DependencyProperty NotifProperty = DependencyProperty.Register("notifNumber", typeof(string), typeof(NotificationView), null);
        public static readonly DependencyProperty VisibileProperty = DependencyProperty.Register("visible", typeof(Visibility), typeof(NotificationView), null);

        public int NotificationNumber
        {
            get { return Convert.ToInt32(GetValue(NotifProperty)); }
            set
            {
                if (value <=0 )
                {
                    SetValue(VisibileProperty, Visibility.Collapsed);
                }
                else
                {
                    SetValue(VisibileProperty, Visibility.Visible);
                }
                SetValue(NotifProperty, value.ToString());
            }
        }

        public TappedEventHandler Tap { get; private set; }

        public NotificationView()
        {
            this.InitializeComponent();
            this.DataContext = this;
            gridMain.Tapped += Tap;
        }


    }
}
