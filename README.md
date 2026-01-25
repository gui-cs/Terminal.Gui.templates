  [![NuGet Badge](https://buildstats.info/nuget/Terminal.gui.templates)](https://www.nuget.org/packages/Terminal.gui.templates/)

  # Usage
  This is a template for creating Terminal.Gui v2 applications using `dotnet new`.

  To add this template to those available in `dotnet new` install the NuGet package:

  ```
  dotnet new install Terminal.gui.templates@2.0.0-alpha.*
  ```

  The above will install the latest Terminal.Gui v2 alpha templates. For the stable v1 templates:

  ```
  dotnet new install Terminal.gui.templates
  ```

  ## Creating projects

  After installing you can use the templates to create new projects:

  ### tui-simple

  A minimal starter template with a simple window, welcome label, and quit button:

  ```
  dotnet new tui-simple -n mytuiapp
  cd mytuiapp
  dotnet run
  ```

  ### tui-designer

  A template optimized for use with [Terminal.Gui Designer](https://github.com/gui-cs/TerminalGuiDesigner):

  ```
  dotnet new tui-designer -n mytuiapp
  cd mytuiapp
  dotnet run
  ```