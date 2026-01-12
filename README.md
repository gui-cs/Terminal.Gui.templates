 [![NuGet Badge](https://buildstats.info/nuget/Terminal.gui.templates)](https://www.nuget.org/packages/Terminal.gui.templates/)

# Usage
This is a template for creating Terminal.Gui v2 applications using `dotnet new`.

To add this template to those available in `dotnet new` install the NuGet package:

```
dotnet new install Terminal.Gui.Templates
```

The above will install the Terminal.Gui v2 templates. If you want to use v1:

```
dotnet new install Terminal.gui.templates::1.0.3
```

## Creating projects

After installing you can use the template to create new projects:

```
dotnet new tui-simple -n myproj
cd myproj
dotnet run
```