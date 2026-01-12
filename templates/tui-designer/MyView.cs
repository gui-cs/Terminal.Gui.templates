namespace MyProject; 

public partial class MyView {
    
    public MyView() {
        InitializeComponent();

        button1.Accepting += (s, e) =>
        {
            e.Handled = true;
            Terminal.Gui.Views.MessageBox.Query(App!,"Hello", "Hello There!", "Ok");
        };
    }
}
