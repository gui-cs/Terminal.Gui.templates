# My Terminal.Gui App

A complete Terminal User Interface (TUI) app built with [Terminal.Gui](https://github.com/tui-cs/Terminal.Gui) **v2** — a menu bar, a status bar, and interactive content.

```bash
dotnet run        # launch (menu File>Quit or the status bar exits)
dotnet build      # compile only
```

## Project layout
| File | Purpose |
|---|---|
| `Program.cs` | App entry point + the root `MainWindow` (menu, status bar, content). Add your views to `content`. |
| `AGENTS.md` | **Canonical Terminal.Gui v2 patterns + gotchas for AI agents and humans.** Start here. |
| `CLAUDE.md` | Thin pointer to `AGENTS.md` for Claude / Claude Code. |
| `*.csproj` | Targets `net10.0`, references `Terminal.Gui`. |

## Building with an AI agent?
Terminal.Gui v2 is a complete rewrite — most examples online (and in model training data)
are **v1 and won't compile**. **Read [`AGENTS.md`](./AGENTS.md) first** for the canonical
patterns, the v1→v2 corrections table, `Pos`/`Dim` layout, and common pitfalls.

## Learn more
- Getting started: https://tui-cs.github.io/Terminal.Gui/
- Repository & samples: https://github.com/tui-cs/Terminal.Gui
