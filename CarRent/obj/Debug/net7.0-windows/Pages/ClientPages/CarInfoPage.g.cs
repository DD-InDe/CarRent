﻿#pragma checksum "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0FDADE626ED478F2EB39C6E69634BAF72E776D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarRent.Pages.ClientPages;
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


namespace CarRent.Pages.ClientPages {
    
    
    /// <summary>
    /// CarInfoPage
    /// </summary>
    public partial class CarInfoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 64 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CarPhotoImage;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddRequestButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LoadingImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarRent;component/pages/clientpages/carinfopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CarPhotoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddRequestButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\..\Pages\ClientPages\CarInfoPage.xaml"
            this.AddRequestButton.Click += new System.Windows.RoutedEventHandler(this.AddRequestButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LoadingImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

