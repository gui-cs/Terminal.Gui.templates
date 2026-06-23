// Headless tests for the app's views — no real terminal, no Application.Init.
//
// Terminal.Gui v2 views can be constructed and exercised in-process: build the view,
// trigger a command (e.g. Command.Accept), and assert on the resulting state. This is the
// fast red-green loop for an AI agent — you do NOT need a PTY to test view *logic*.
// (To verify *visuals*, run the app under a PTY recorder; see AGENTS.md.)

using Terminal.Gui.Input;     // Command
using Terminal.Gui.ViewBase;  // View
using Terminal.Gui.Views;     // Label, Button
using Xunit;

public class MainWindowTests
{
    [Fact]
    public void Constructs_with_the_expected_title ()
    {
        using MainWindow window = new ();
        Assert.Equal ("My Terminal.Gui App", window.Title);
    }

    [Fact]
    public void Increment_button_increments_the_count ()
    {
        using MainWindow window = new ();

        Label count = FindFirst<Label> (window, l => l.Text.StartsWith ("Count:"));
        Button increment = FindFirst<Button> (window, b => b.Text.Contains ("Increment"));

        Assert.Equal ("Count: 0", count.Text);

        // Activate the button as if the user pressed it (Enter/click/hotkey all map to Accept).
        increment.InvokeCommand (Command.Accept);

        Assert.Equal ("Count: 1", count.Text);
    }

    // Walk the view tree (SubView/SuperView) to find a view matching a predicate.
    private static T FindFirst<T> (View root, System.Func<T, bool> match) where T : View
    {
        foreach (View view in Descendants (root))
        {
            if (view is T typed && match (typed))
            {
                return typed;
            }
        }

        throw new Xunit.Sdk.XunitException ($"No {typeof (T).Name} matched the predicate.");
    }

    private static System.Collections.Generic.IEnumerable<View> Descendants (View view)
    {
        foreach (View child in view.SubViews)
        {
            yield return child;

            foreach (View descendant in Descendants (child))
            {
                yield return descendant;
            }
        }
    }
}
