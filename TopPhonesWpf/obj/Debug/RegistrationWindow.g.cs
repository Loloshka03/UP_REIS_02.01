﻿#pragma checksum "..\..\RegistrationWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1B3DE1CBBB4CFA7307FF9D4F66A35716"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace TopPhonesWpf {
    
    
    /// <summary>
    /// RegistrationWindow
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FamKlient_textbox;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Pass_box;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ConfPass_Box;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameClient_textbox;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Otch_klient_Textbox;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneKlient_box;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login_text;
        
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
            System.Uri resourceLocater = new System.Uri("/TopPhonesWpf;component/registrationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistrationWindow.xaml"
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
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\RegistrationWindow.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FamKlient_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\RegistrationWindow.xaml"
            this.FamKlient_textbox.LostFocus += new System.Windows.RoutedEventHandler(this.FamKlient_textbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 67 "..\..\RegistrationWindow.xaml"
            this.FamKlient_textbox.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.FamKlient_textbox_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 68 "..\..\RegistrationWindow.xaml"
            this.FamKlient_textbox.SelectionChanged += new System.Windows.RoutedEventHandler(this.FamKlient_textbox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 69 "..\..\RegistrationWindow.xaml"
            this.FamKlient_textbox.GotFocus += new System.Windows.RoutedEventHandler(this.FamKlient_textbox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Pass_box = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 78 "..\..\RegistrationWindow.xaml"
            this.Pass_box.GotFocus += new System.Windows.RoutedEventHandler(this.Pass_box_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ConfPass_Box = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 87 "..\..\RegistrationWindow.xaml"
            this.ConfPass_Box.GotFocus += new System.Windows.RoutedEventHandler(this.ConfPass_Box_GotFocus);
            
            #line default
            #line hidden
            
            #line 88 "..\..\RegistrationWindow.xaml"
            this.ConfPass_Box.LostFocus += new System.Windows.RoutedEventHandler(this.ConfPass_Box_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NameClient_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.NameClient_textbox_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 97 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NameClient_textbox_MouseDown);
            
            #line default
            #line hidden
            
            #line 99 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.MouseEnter += new System.Windows.Input.MouseEventHandler(this.NameClient_textbox_MouseEnter);
            
            #line default
            #line hidden
            
            #line 100 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.NameClient_textbox_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 101 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.LostFocus += new System.Windows.RoutedEventHandler(this.NameClient_textbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 103 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.SelectionChanged += new System.Windows.RoutedEventHandler(this.NameClient_textbox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 104 "..\..\RegistrationWindow.xaml"
            this.NameClient_textbox.GotFocus += new System.Windows.RoutedEventHandler(this.NameClient_textbox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Otch_klient_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 113 "..\..\RegistrationWindow.xaml"
            this.Otch_klient_Textbox.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Otch_klient_Textbox_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 114 "..\..\RegistrationWindow.xaml"
            this.Otch_klient_Textbox.LostFocus += new System.Windows.RoutedEventHandler(this.Otch_klient_Textbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 115 "..\..\RegistrationWindow.xaml"
            this.Otch_klient_Textbox.SelectionChanged += new System.Windows.RoutedEventHandler(this.Otch_klient_Textbox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 116 "..\..\RegistrationWindow.xaml"
            this.Otch_klient_Textbox.GotFocus += new System.Windows.RoutedEventHandler(this.Otch_klient_Textbox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PhoneKlient_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\RegistrationWindow.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Login_text = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

