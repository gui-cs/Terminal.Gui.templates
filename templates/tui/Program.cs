// -----------------------------------------------------------------------------
//  A small but complete Terminal.Gui v2 app: menu bar + status bar + interactive
//  content.  Run it:  dotnet run   (F9/menu or the status bar quits)
//
//  🤖 AI assistants / agents: READ ./AGENTS.md FIRST.
//     Terminal.Gui v2 is a COMPLETE REWRITE. Pre-2025 training data and most web
//     examples are v1 and will not compile. The canonical v2 patterns are in AGENTS.md.
// -----------------------------------------------------------------------------

using Terminal.Gui.App;           // Application, IApplication, MessageBox
using Terminal.Gui.Configuration; // ConfigurationManager
using Terminal.Gui.Input;         // Key, Command
using Terminal.Gui.ViewBase;      // View, Pos, Dim
using Terminal.Gui.Views;         // Runnable, Label, Button, MenuBar, StatusBar, Shortcut

ConfigurationManager.Enable (ConfigLocations.All);

// Instance lifecycle — NOT static Init/Run/Shutdown:  Create() -> Run<T>() -> Dispose().
Application
    .Create ()
    .Run<MainWindow> ()
    .Dispose ();

// `Runnable` is a full-screen, borderless root (use `Window` if you want a bordered box).
// A typical app puts a MenuBar at the top, a StatusBar at the bottom, and content between.
//
// `public` so the optional test project can construct it (scaffold it with `--WithTests`).
// Terminal.Gui views can be built and exercised headlessly — no terminal needed for logic tests.
public sealed class MainWindow : Runnable
{
    private int _count;
    private readonly Label _countLabel;

    public MainWindow ()
    {
        Title = "My Terminal.Gui App";

        // --- Menu bar -------------------------------------------------------
        // Menus is a collection of MenuBarItem; each holds MenuItems with an Action.
        MenuBar menu = new ()
        {
            Menus =
            [
                new MenuBarItem ("_File", [new MenuItem ("_Quit", "", () => App?.RequestStop ())]),
                new MenuBarItem ("_Help", [new MenuItem ("_About", "", ShowAbout)])
            ]
        };

        // --- Status bar (key hints) ----------------------------------------
        StatusBar status = new ();
        status.Add (new Shortcut (Key.F1, "About", ShowAbout));
        status.Add (new Shortcut (Application.GetDefaultKey (Command.Quit), "Quit", () => App?.RequestStop ()));

        // --- Content (laid out between the menu and status bars) -----------
        // Layout is DECLARATIVE — Pos/Dim, never hardcoded coordinates.
        View content = new ()
        {
            Y = Pos.Bottom (menu),
            Width = Dim.Fill (),
            Height = Dim.Fill (status)   // fill down to (but not over) the status bar
        };

        _countLabel = new ()
        {
            Text = "Count: 0",
            X = Pos.Center (),
            Y = Pos.Center () - 1
        };

        Button increment = new ()
        {
            Text = "_Increment",
            X = Pos.Center (),
            Y = Pos.Center () + 1
        };

        // No `Clicked` in v2 — a view raises `Accepting` when activated (Enter/click/hotkey).
        // `App!` is the running IApplication, reachable from any view in the tree.
        increment.Accepting += (_, _) =>
        {
            _count++;
            _countLabel.Text = $"Count: {_count}";   // update state -> UI
        };

        content.Add (_countLabel, increment);

        // 👉 Add your views to `content`. See AGENTS.md for patterns + common pitfalls.

        Add (menu, content, status);
    }

    private void ShowAbout () =>
        MessageBox.Query (App!, "About", "Built with Terminal.Gui v2.\nEdit Program.cs to make it yours.", "OK");
}
