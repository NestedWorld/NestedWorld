using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NestedWorld.Utils
{
    public class ThemeSelector
    {
        internal static void SetTheme()
        {

           App.Current.Resources.Add("background", "#FFFFFFFF");
            Debug.WriteLine(App.Current.Resources["background"].ToString());

        }
    }
}
