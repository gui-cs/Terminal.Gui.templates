 [![NuGet Badge](https://buildstats.info/nuget/gui.cs.templates)](https://www.nuget.org/packages/gui.cs.templates/)

## Usage
This is a template for creating Terminal.Gui applications using `dotnet new`.

To add this template to those available in `dotnet new` you will need to install the NuGet package:
```
dotnet new --install Terminal.Gui.templates
```

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
