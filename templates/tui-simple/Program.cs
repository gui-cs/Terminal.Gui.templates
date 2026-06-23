// -----------------------------------------------------------------------------
//  A minimal Terminal.Gui v2 app.  Run it:  dotnet run   (Esc or the button quits)
//
//  🤖 AI assistants / agents: READ ./AGENTS.md FIRST.
//     Terminal.Gui v2 is a COMPLETE REWRITE. Pre-2025 training data and most web
//     examples are v1 and will not compile. The canonical v2 patterns are in AGENTS.md.
// -----------------------------------------------------------------------------

// v2 splits the old monolithic `using Terminal.Gui;` into focused namespaces:
using Terminal.Gui.App;           // Application, IApplication, MessageBox
using Terminal.Gui.Configuration; // ConfigurationManager
using Terminal.Gui.ViewBase;      // View, Pos, Dim
using Terminal.Gui.Views;         // Window, Label, Button

// Enable the configuration/theme system before creating the app (standard first line).
ConfigurationManager.Enable (ConfigLocations.All);

// The v2 lifecycle is INSTANCE-BASED and disposable — NOT the static v1
// Application.Init() / Application.Run() / Application.Shutdown():
//
//     Create()  ->  Run<TWindow>()  (auto-Init)  ->  Dispose()  (replaces Shutdown)
//
Application
    .Create ()
    .Run<MainWindow> ()
    .Dispose ();

// Your app's root view. `Window` is a bordered top-level view; subclass `Runnable`
// instead if you want a borderless root. Build the UI by Add()-ing child views.
internal sealed class MainWindow : Window
{
    public MainWindow ()
    {
        Title = "My App  (Esc to quit)";

        // Layout is DECLARATIVE — position/size with Pos/Dim, don't hardcode coordinates:
        //   Pos.Center(), Pos.Right(view), Pos.AnchorEnd();  Dim.Fill(), Dim.Auto(), Dim.Percent(50).
        Label welcome = new ()
        {
            Text = "Welcome to Terminal.Gui v2!",
            X = Pos.Center (),
            Y = 1
        };

        Button quit = new ()
        {
            Text = "_Quit",        // the leading _ defines the hotkey (Alt+Q)
            X = Pos.Center (),
            Y = Pos.Center ()
        };

        // v2 has NO `Clicked` event. Use `Accepted` for side effects like this — it fires when
        // the user activates the view (Enter / click / hotkey). Use `Accepting` only to inspect
        // or cancel the activation (set e.Handled = true). See AGENTS.md (#Events).
        // `App!` is the running IApplication, reachable from any view in the tree.
        quit.Accepted += (_, _) => App!.RequestStop ();

        Add (welcome, quit);

        // 👉 Add your views here. See AGENTS.md for canonical patterns + common pitfalls.
    }
}
