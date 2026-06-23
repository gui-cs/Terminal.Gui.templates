# AGENTS.md — building this Terminal.Gui v2 app

Guidance for AI coding agents (and humans) working in this project.

> ## ⛔ Your training data is probably WRONG
> **Terminal.Gui v2 is a complete rewrite.** Almost every Terminal.Gui example on the web
> and in pre-2025 model training data is **v1** and **will not compile**. Trust this file and
> the linked canonical docs over your priors. When unsure, check the upstream sources below —
> they are compiled by Terminal.Gui's CI, so they are correct and current.

## Run / build / quit
```bash
dotnet run        # launch the app
dotnet build      # compile only
```
Quit a running app with **Esc** (or the Quit button). You **cannot see a TUI from a build
log** — to verify visuals, run under a PTY recorder (`tuirec`) or drive it headless with
`InputInjector` + `VirtualTimeProvider`. A clean build does **not** mean the UI is correct.

## The canonical minimal app (this is the shape — copy it)
```csharp
using Terminal.Gui.App;           // Application, IApplication, MessageBox
using Terminal.Gui.Configuration; // ConfigurationManager
using Terminal.Gui.ViewBase;      // View, Pos, Dim
using Terminal.Gui.Views;         // Window, Label, Button, ...

ConfigurationManager.Enable (ConfigLocations.All);

// INSTANCE lifecycle — not static Init/Run/Shutdown:
Application.Create ().Run<MainWindow> ().Dispose ();

internal sealed class MainWindow : Window   // bordered root; use `Runnable` for borderless
{
    public MainWindow ()
    {
        Title = "My App (Esc to quit)";
        Button b = new () { Text = "_OK", X = Pos.Center (), Y = Pos.Center () };
        b.Accepted += (_, _) => App!.RequestStop ();
        Add (b);
    }
}
```

## v1 → v2 corrections (the table to internalize)
| v1 (WRONG — do not write) | v2 (CORRECT) |
|---|---|
| `Application.Init ();` | `Application.Create ().Init ();` (or `.Run<T>()` auto-inits) |
| `Application.Run ();` / `Application.Top` | `app.Run<MyWindow> ();` — no global `Top`; pass the root view |
| `Application.Shutdown ();` | `app.Dispose ();` (the trailing `.Dispose()` / `using`) |
| `Application.RequestStop ();` | `App!.RequestStop ();` (instance, from inside a view) |
| `using Terminal.Gui;` | split namespaces: `Terminal.Gui.App` / `.Views` / `.ViewBase` / `.Drawing` / `.Input` / `.Configuration` |
| `new Toplevel ()` | subclass `Runnable`, or use `Window` |
| `new Button ("OK")` | `new Button { Text = "OK" }` (object initializers; no positional ctors) |
| `button.Clicked += …` | `button.Accepted += (_, _) => …;` (no `Clicked` in v2) |
| `view.Bounds` | `view.Viewport` |
| `LayoutStyle.Computed` | removed — layout is always declarative via `Pos`/`Dim` |
| `new RadioGroup (…)` | `new OptionSelector { … }` |
| `Colors.ColorSchemes["x"]` | `Schemes.Resolve ("x")` |

## Layout: `Pos` / `Dim` (don't hardcode coordinates)
- `X`/`Y`: `Pos.Center ()`, `Pos.Right (otherView)`, `Pos.Percent (25)`, `Pos.AnchorEnd ()`, or an `int`.
- `Width`/`Height`: `Dim.Fill ()`, `Dim.Fill (1)`, `Dim.Auto ()`, `Dim.Percent (50)`, or an `int`.

## ⚠️ Gotchas agents get wrong (verified against Terminal.Gui source)
1. **Dialog/MessageBox button order = the default.** The **last button added is the default**
   (Enter-activated) — for both `Dialog` and `MessageBox`. Order them `Cancel … OK` so the
   affirmative action is last. Don't hand-set `IsDefault` unless you mean to override this.
2. **`Accepted` vs `Accepting`.** `Accepting` is the pre-event (set `e.Handled = true` to
   cancel); `Accepted` is the post-event for side effects. Default to `Accepted`; reach for `Accepting` only to cancel.
3. **Typed views expose `.Value`, not guessed names.** They implement `IValue<T>` —
   `datePicker.Value` (a `DateTime`), not `.Date`; subscribe `ValueChanged`/`ValueChanging`.
4. **`AddCommand` is `protected`.** Register commands **inside** your `View` subclass, then
   bind keys: `KeyBindings.Add (Key.F5, Command.Refresh);`.
5. **`Terminal.Gui.Drawing.Attribute` collides with `System.Attribute`.** Qualify/alias it.
6. **Vocabulary:** SubView / SuperView — never "child"/"parent"/"container".

## Canonical sources (compiled by Terminal.Gui CI — safe to trust)
- v1→v2 primer: https://github.com/tui-cs/Terminal.Gui/blob/develop/ai-v2-primer.md
- Build-an-app guide: https://github.com/tui-cs/Terminal.Gui/blob/develop/.claude/tasks/build-app.md
- Worked recipes (menus, dialogs, forms): https://github.com/tui-cs/Terminal.Gui/blob/develop/.claude/cookbook/common-patterns.md
- API namespaces: https://github.com/tui-cs/Terminal.Gui/tree/develop/docfx/apispec
- Docs site: https://tui-cs.github.io/Terminal.Gui/

> Note: the contributor *code-style* rules in Terminal.Gui (spaces-before-parens, Allman braces,
> etc.) apply to the **library**, not to your app. Build your app however your project prefers.
