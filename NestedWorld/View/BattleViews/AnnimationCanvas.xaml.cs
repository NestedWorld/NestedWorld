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

namespace NestedWorld.View.BattleViews
{
    public sealed partial class AnnimationCanvas : UserControl
    {
        public AnnimationCanvas()
        {
            this.InitializeComponent();
            DamagesAnnimation.Completed += DamagesAnnimation_Completed;
                
        }

        private void AttackAnnimation_Completed(object sender, object e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void DamagesAnnimation_Completed(object sender, object e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Attack()
        {
            this.Visibility = Visibility.Visible;
            
            //  AttackAnnimation.Begin();
        }

        public void Damages()
        {
            this.Visibility = Visibility.Visible;

            DamagesAnnimation.Begin();
        }
    }
}
