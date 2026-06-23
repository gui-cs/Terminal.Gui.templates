[![NuGet](https://img.shields.io/nuget/v/Terminal.Gui.Templates)](https://www.nuget.org/packages/Terminal.Gui.Templates/)

# Terminal.Gui Templates

`dotnet new` templates for building [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui) **v2** apps — designed so an **AI coding agent** can scaffold and extend a TUI app correctly. Every generated project ships an **`AGENTS.md`** with the canonical v2 patterns (Terminal.Gui v2 is a complete rewrite, so most online/training-data examples are v1 and won't compile).

## Install

```bash
dotnet new install Terminal.Gui.Templates
```

This installs the latest templates targeting current stable Terminal.Gui (net10.0).

## Create a project

### `tui-simple`

A minimal, agent-ready Terminal.Gui v2 app: a `Window` with a label and a quit button, an embedded `AGENTS.md`/`CLAUDE.md`, and a fully commented `Program.cs`.

```bash
dotnet new tui-simple -n MyApp
cd MyApp
dotnet run            # Esc or the Quit button exits
```

Open `MyApp/AGENTS.md` first — it has the canonical minimal app, the v1→v2 corrections table, `Pos`/`Dim` layout, common gotchas, and links to Terminal.Gui's CI-validated docs.

> **Note:** the previous `tui-designer` template is temporarily not shipped while it's regenerated against current Terminal.Gui — see [#24](https://github.com/gui-cs/Terminal.Gui.templates/issues/24).

## Links
- Terminal.Gui: https://github.com/gui-cs/Terminal.Gui
- Getting started: https://gui-cs.github.io/Terminal.Gui/
- Relaunch plan: [#22](https://github.com/gui-cs/Terminal.Gui.templates/issues/22)
