﻿#pragma checksum "..\..\RootURLs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E8617F3C62B799E6D5024D6B9A92A5BDADC0AF8337160C2DE342F8FAC4ADDB63"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WebCrawlerInterface;


namespace WebCrawlerInterface {
    
    
    /// <summary>
    /// RootURLs
    /// </summary>
    public partial class RootURLs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\RootURLs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel upbar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RootURLs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgRoots;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RootURLs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tboxRoot;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RootURLs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRoot;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\RootURLs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WebCrawlerInterface;component/rooturls.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RootURLs.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\RootURLs.xaml"
            ((WebCrawlerInterface.RootURLs)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.upbar = ((System.Windows.Controls.StackPanel)(target));
            
            #line 11 "..\..\RootURLs.xaml"
            this.upbar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.upbar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\RootURLs.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\RootURLs.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgRoots = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.tboxRoot = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAddRoot = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\RootURLs.xaml"
            this.btnAddRoot.Click += new System.Windows.RoutedEventHandler(this.btnAddRoot_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\RootURLs.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
