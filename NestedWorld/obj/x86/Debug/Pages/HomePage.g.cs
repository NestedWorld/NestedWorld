﻿#pragma checksum "E:\c#\NestedWorld\NestedWorld\Pages\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A9E65F20EDA4F5CE1CCA9D68C5098E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NestedWorld.Pages
{
    partial class HomePage : 
        global::Windows.UI.Xaml.Controls.Page, 
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
                    this.monsterListView = (global::NestedWorld.View.MonsterListView)(target);
                }
                break;
            case 2:
                {
                    this.monsterFullView = (global::NestedWorld.View.MonsterViews.MonsterFullView)(target);
                }
                break;
            case 3:
                {
                    this.homeView = (global::NestedWorld.View.HomeView)(target);
                }
                break;
            case 4:
                {
                    this.monsterView = (global::NestedWorld.View.MonsterView)(target);
                }
                break;
            case 5:
                {
                    this.userView = (global::NestedWorld.View.UserView)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element6 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 38 "..\..\..\Pages\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element6).Click += this.AppBarButton_Click;
                    #line default
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
