
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v2.0.0.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace MyGuiCsProject {
    using System;
    using Terminal.Gui;
    using Terminal.Gui.App;
    using Terminal.Gui.Drawing;
    using Terminal.Gui.Input;
    using Terminal.Gui.ViewBase;
    using Terminal.Gui.Views;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    
    
    public partial class MyView : Terminal.Gui.Views.Window {
        
        private Terminal.Gui.Views.Label label;
        
        private Terminal.Gui.Views.Button button1;
        
        private void InitializeComponent() {
            this.button1 = new Terminal.Gui.Views.Button();
            this.label = new Terminal.Gui.Views.Label();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Visible = true;
            this.Arrangement = Terminal.Gui.ViewBase.ViewArrangement.Overlapped;
            this.CanFocus = true;
            this.ShadowStyle = Terminal.Gui.ViewBase.ShadowStyle.None;
            this.Modal = false;
            this.TextAlignment = Terminal.Gui.ViewBase.Alignment.Start;
            this.Title = "Press Esc to quit";
            this.label.Width = Dim.Auto();
            this.label.Height = Dim.Auto();
            this.label.X = Pos.Center();
            this.label.Y = Pos.Center();
            this.label.Visible = true;
            this.label.Arrangement = Terminal.Gui.ViewBase.ViewArrangement.Fixed;
            this.label.CanFocus = false;
            this.label.ShadowStyle = Terminal.Gui.ViewBase.ShadowStyle.None;
            this.label.Data = "label";
            this.label.Text = "Hello World";
            this.label.TextAlignment = Terminal.Gui.ViewBase.Alignment.Start;
            this.Add(this.label);
            this.button1.Width = Dim.Auto();
            this.button1.Height = Dim.Auto();
            this.button1.X = Pos.Center();
            this.button1.Y = Pos.Center() + 1;
            this.button1.Visible = true;
            this.button1.Arrangement = Terminal.Gui.ViewBase.ViewArrangement.Fixed;
            this.button1.CanFocus = true;
            this.button1.ShadowStyle = Terminal.Gui.ViewBase.ShadowStyle.Opaque;
            this.button1.Data = "button1";
            this.button1.Text = "Click Me";
            this.button1.TextAlignment = Terminal.Gui.ViewBase.Alignment.Center;
            this.button1.IsDefault = false;
            this.Add(this.button1);
        }
    }
}
