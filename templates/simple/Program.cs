using Terminal.Gui.App;
using Terminal.Gui.Configuration;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

ConfigurationManager.Enable(ConfigLocations.All);
Application.Create().Init().Run<SimpleWindow>();

class SimpleWindow : Window
{
    public SimpleWindow()
    {
        Title = "Hello Terminal.Gui";

        var label = new View()
        {
            Title = "Welcome to Terminal.Gui!",
            X = Pos.Center(),
            Y = 2
        };

        var button = new Button()
        {
            Title = "_Click Me to Quit (or press Esc)",
            X = Pos.Center(),
            Y = Pos.Bottom(label) + 2
        };

        button.Accepting += (_, _) => App!.RequestStop();

        Add(label, button);
    }
}