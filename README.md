 [![NuGet Badge](https://buildstats.info/nuget/gui.cs.templates)](https://www.nuget.org/packages/gui.cs.templates/)

## Usage
This is a template for creating Terminal.Gui applications using `dotnet new`.

To add this template to those available in `dotnet new` you will need to install the NuGet package:
```
dotnet new --install gui.cs.templates
```

After installing you can use the template to create new projects:

```
dotnet new guics -n myproj
cd myProj
dotnet run
```

## Development
For development/testing add this template to `dotnet` using:

```
 dotnet new --install D:\Repos\gui.cs.template\templates\basic
```

To use the template run:

```
dotnet new guics -n myproj
cd myProj
dotnet run
```

To remove it run:

```
dotnet new --uninstall D:\Repos\gui.cs.template\templates\basic
```
