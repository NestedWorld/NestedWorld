﻿#pragma checksum "E:\Project\GitHub\NestedWorld\Windows10\NestedWorld\View\MapView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6964925D2DFFDC2C1C1C604DEF3C64B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NestedWorld.View
{
    partial class MapView : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.userControl = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                }
                break;
            case 2:
                {
                    this.PopupMain = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element3 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    #line 16 "..\..\..\View\MapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element3).Click += this.ShowAlly;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element4 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    #line 21 "..\..\..\View\MapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element4).Click += this.ShowUsers;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element5 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    #line 22 "..\..\..\View\MapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element5).Click += this.ShowMonster;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element6 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    #line 23 "..\..\..\View\MapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element6).Click += this.ShowAreas;
                    #line default
                }
                break;
            case 7:
                {
                    this.stackPanelRoot = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

