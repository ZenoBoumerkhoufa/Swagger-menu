﻿#pragma checksum "..\..\..\..\Bestellingen\AddOrders.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C975425A916677CEA4041395538EB138A072B2DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp.Bestellingen;


namespace WpfApp.Bestellingen {
    
    
    /// <summary>
    /// AddOrders
    /// </summary>
    public partial class AddOrders : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_terug;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_toevoegen;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_customerId;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_menuItemId;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_aantal;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_klantId;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_MenuItemId;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Bestellingen\AddOrders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_aantal;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/bestellingen/addorders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Bestellingen\AddOrders.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_terug = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Bestellingen\AddOrders.xaml"
            this.btn_terug.Click += new System.Windows.RoutedEventHandler(this.btn_terug_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_toevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Bestellingen\AddOrders.xaml"
            this.btn_toevoegen.Click += new System.Windows.RoutedEventHandler(this.btn_toevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbl_customerId = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbl_menuItemId = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbl_aantal = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txt_klantId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_MenuItemId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_aantal = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
