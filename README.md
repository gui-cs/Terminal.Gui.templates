 [![NuGet Badge](https://buildstats.info/nuget/Terminal.gui.templates)](https://www.nuget.org/packages/Terminal.gui.templates/)

# Usage
This is a template for creating Terminal.Gui applications using `dotnet new`.

To add this template to those available in `dotnet new` you will need to install the NuGet package:

# V1
Version 1 of [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui) is stable and actively maintained but does not receive new features. To create projects using the V1 template install the latest version of the template:

```
dotnet new --install Terminal.Gui.templates
```

# V2
Version 2 of [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui) is in alpha.  To create projects using the v2 template you install the [latest version from nuget.org](https://www.nuget.org/packages/Terminal.gui.templates) e.g.

```
dotnet new install Terminal.Gui.Templates::2.0.0-v2-develop.4519
```

## Creating projects

After installing you can use the template to create new projects:

```
dotnet new tui -n myproj
cd myproj
dotnet run
```

## Next Steps

The basic template includes `MyView.cs` which was created by [TerminalGuiDesigner](https://github.com/gui-cs/TerminalGuiDesigner).  You can delete edit this file with the visual designer using the code below or delete it and create your own `Window`/`TopLevel` class manually.

```
dotnet tool install --global TerminalGuiDesigner
TerminalGuiDesigner ./MyView.cs
```

If you are targetting v2 you will need to add `--prerelease`.

## Development
For development/testing add this template to `dotnet` using:

```
 dotnet new --install D:\Repos\Terminal.Gui.templates\templates\basic
```

To use the template run:

```
dotnet new tui -n myproj
cd myproj
dotnet run
```

To remove it run:

```
dotnet new --uninstall D:\Repos\Terminal.Gui.templates\templates\basic
```
