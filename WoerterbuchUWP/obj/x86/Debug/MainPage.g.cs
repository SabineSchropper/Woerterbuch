﻿#pragma checksum "C:\Users\DCV\C#\Woerterbuch\WoerterbuchUWP\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B5EED6E940F4D2C2EF6077225F7220CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WoerterbuchUWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 12
                {
                    this.lBoxGermanWord = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lBoxGermanWord).SelectionChanged += this.lBoxGermanWord_SelectionChanged;
                }
                break;
            case 3: // MainPage.xaml line 13
                {
                    this.lBoxAlphabet = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lBoxAlphabet).Tapped += this.lBoxAlphabet_Tapped;
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lBoxAlphabet).LosingFocus += this.lBoxAlphabet_LosingFocus;
                }
                break;
            case 4: // MainPage.xaml line 14
                {
                    this.tbSearch = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.tbSearch).TextChanged += this.tbSearch_TextChanged;
                }
                break;
            case 5: // MainPage.xaml line 15
                {
                    this.tbTranslation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // MainPage.xaml line 16
                {
                    this.tbSpanishTranslation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // MainPage.xaml line 17
                {
                    this.btnExport = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnExport).Click += this.btnExport_Click;
                }
                break;
            case 8: // MainPage.xaml line 18
                {
                    this.btnAddTranslation = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAddTranslation).Click += this.btnAddTranslation_Click;
                }
                break;
            case 9: // MainPage.xaml line 19
                {
                    this.tbEnglishWord = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // MainPage.xaml line 20
                {
                    this.tbSpanishWord = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // MainPage.xaml line 21
                {
                    this.tbGermanWord = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // MainPage.xaml line 22
                {
                    this.tBlockEn = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // MainPage.xaml line 23
                {
                    this.tBlockSp = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

