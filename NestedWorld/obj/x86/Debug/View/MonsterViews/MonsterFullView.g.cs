﻿#pragma checksum "E:\c#\NestedWorld\NestedWorld\View\MonsterViews\MonsterFullView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D256951AB5FF8D9BB136F656B98F290F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NestedWorld.View.MonsterViews
{
    partial class MonsterFullView : 
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
                    this.mainStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.monsterHeaderView = (global::NestedWorld.View.MonsterViews.MonsterHeaderView)(target);
                }
                break;
            case 3:
                {
                    this.monsterAttackView = (global::NestedWorld.View.MonsterViews.MonsterAttacksView)(target);
                }
                break;
            case 4:
                {
                    this.monsterStatsView = (global::NestedWorld.View.MonsterViews.MonsterStatsView)(target);
                }
                break;
            case 5:
                {
                    this.monsterLocationView = (global::NestedWorld.View.MonsterViews.MonsterLocationView)(target);
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

