﻿#pragma checksum "..\..\..\..\Pages\CatalogAutoPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63D2E7FF8F73043FAA08831EC8F26A404B91BE00"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarRent.Pages;
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


namespace CarRent.Pages {
    
    
    /// <summary>
    /// CatalogAutoPage
    /// </summary>
    public partial class CatalogAutoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFilter;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup Popup;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BrandComboBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ModelComboBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassComboBox;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CarListView;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\Pages\CatalogAutoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LoadingImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarRent;component/pages/catalogautopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            ((CarRent.Pages.CatalogAutoPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.CatalogAutoPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OpenFilter = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.OpenFilter.Click += new System.Windows.RoutedEventHandler(this.OpenFilter_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 6:
            this.BrandComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.BrandComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BrandComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ModelComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 63 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.ModelComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ModelComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ClassComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 72 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.ClassComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CarListView = ((System.Windows.Controls.ListView)(target));
            
            #line 86 "..\..\..\..\Pages\CatalogAutoPage.xaml"
            this.CarListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.CarListView_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.LoadingImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
