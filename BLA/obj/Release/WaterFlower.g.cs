﻿#pragma checksum "..\..\WaterFlower.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9411226057163A927029EF37A2D53761AC1BA664F405EF3930C3BC69AA282832"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BLA;
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


namespace BLA {
    
    
    /// <summary>
    /// WaterFlower
    /// </summary>
    public partial class WaterFlower : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\WaterFlower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox flowerbedBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\WaterFlower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tubeBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\WaterFlower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox nameFertilizerBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\WaterFlower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckWater;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\WaterFlower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView WaterFlower2;
        
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
            System.Uri resourceLocater = new System.Uri("/BLA;component/waterflower.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WaterFlower.xaml"
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
            this.flowerbedBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 53 "..\..\WaterFlower.xaml"
            this.flowerbedBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tubeBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\WaterFlower.xaml"
            this.tubeBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nameFertilizerBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\WaterFlower.xaml"
            this.nameFertilizerBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CheckWater = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\WaterFlower.xaml"
            this.CheckWater.Checked += new System.Windows.RoutedEventHandler(this.CheckWater_Checked);
            
            #line default
            #line hidden
            
            #line 57 "..\..\WaterFlower.xaml"
            this.CheckWater.Unchecked += new System.Windows.RoutedEventHandler(this.CheckWater_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 58 "..\..\WaterFlower.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 59 "..\..\WaterFlower.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.WaterFlower2 = ((System.Windows.Controls.ListView)(target));
            
            #line 64 "..\..\WaterFlower.xaml"
            this.WaterFlower2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.WaterFlower2_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

