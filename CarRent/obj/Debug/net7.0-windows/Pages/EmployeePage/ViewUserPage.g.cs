﻿#pragma checksum "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57113AB6D77D4F9D10418A2454717BBAE450EE33"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarRent.Pages.EmployeePage;
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


namespace CarRent.Pages.EmployeePage {
    
    
    /// <summary>
    /// ViewUserPage
    /// </summary>
    public partial class ViewUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFilter;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUserButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup Popup;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoleComboBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView UserListView;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CarRent;component/pages/employeepage/viewuserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
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
            
            #line 8 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            ((CarRent.Pages.EmployeePage.ViewUserPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.ViewUserPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OpenFilter = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            this.OpenFilter.Click += new System.Windows.RoutedEventHandler(this.OpenFilter_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            this.AddUserButton.Click += new System.Windows.RoutedEventHandler(this.AddUserButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 6:
            this.RoleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            this.RoleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RoleComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UserListView = ((System.Windows.Controls.ListView)(target));
            
            #line 68 "..\..\..\..\..\Pages\EmployeePage\ViewUserPage.xaml"
            this.UserListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.UserListView_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LoadingImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

