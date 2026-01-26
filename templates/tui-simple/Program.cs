using Terminal.Gui.App;
using Terminal.Gui.Configuration;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

ConfigurationManager.Enable(ConfigLocations.All);
Application
    .Create()
    .Run<SimpleWindow>()
    .Dispose();

internal class SimpleWindow : Window
{
    public SimpleWindow()
    {
        Title = "Hello Terminal.Gui";

        View label = new ()
        {
            Title = "Welcome to Terminal.Gui!",
            X = Pos.Center()
        };

        Button button = new ()
        {
            Title = "_Click Me to Quit (or press Esc)",
            X = Pos.Center(),
            Y = Pos.Center()
        };

        button.Accepting += (_, _) => App!.RequestStop();

        Add(label, button);
    }
}