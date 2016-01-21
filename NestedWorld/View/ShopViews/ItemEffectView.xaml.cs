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

namespace NestedWorld.View.ShopViews
{
    public sealed partial class ItemEffectView : UserControl
    {
        public static readonly DependencyProperty nameProperty = DependencyProperty.Register("NameEffect", typeof(string), typeof(ItemEffectView), null);
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register("LevelEffect", typeof(string), typeof(ItemEffectView), null);


        public string NameEffect
        {
            get { return ""; }
            set { SetValue(nameProperty, value); }
        }

        public int LevelEffect
        {
            get { return 0; }
            set
            {
                SetValue(LevelProperty, (value).ToString());
                if (value < 0)
                {
                    rec.Fill = new SolidColorBrush(Utils.ColorUtils.GetColorFromHex(""));
                    rec.Width = ((double)(value) / 3.5) * (-1);
                }
                else
                {
                    rec.Fill = new SolidColorBrush(Utils.ColorUtils.GetColorFromHex(""));
                    rec.Width = (double)(value) / 3.5;
                }
            }
        }

        public ItemEffectView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
