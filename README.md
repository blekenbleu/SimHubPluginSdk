# SimHubPluginSdk
 More portable plugin SDK demo from [SimHub 9.1.12](https://www.simhubdash.com/download-2/):  
- `SimHubPluginSdk.csproj` sections for building:
    - Visual Studio builds install dll in SimHub folder:  
        `<OutputPath>$(SIMHUB_INSTALL_PATH)</OutputPath>`
    - [Visual Studio debug launches SimHub](https://learn.microsoft.com/en-us/dotnet/api/system.environment.processpath):
```
    <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'Debug|AnyCPU'">
      <StartAction>Program</StartAction>
      <StartProgram>$(SIMHUB_INSTALL_PATH)SimHubWPF.exe</StartProgram>
    </PropertyGroup>
``` 
- if installed as `SimHub\PluginSdk\SimHubPluginSdk\`, then Visual Studio `Build` and `Debug` *may just work*...  
  ... but **do NOT**;&nbsp; instead, change `namespace`:  
	- avoid collisions with other plugins that did not change namespace  
	- lines in files to change `Sdk.Plugin`:  
	```
	Control.xaml:﻿<UserControl x:Class="Sdk.Plugin.Control"
	Control.xaml:             xmlns:local="clr-namespace:Sdk.Plugin"
	Control.xaml.cs:namespace Sdk.Plugin
	Plugin.cs:namespace Sdk.Plugin
	Settings.cs:namespace Sdk.Plugin
	SimHubPluginSdk.csproj:    <RootNamespace>Sdk.Plugin</RootNamespace>
	SimHubPluginSdk.csproj:    <AssemblyName>Sdk.Plugin</AssemblyName>
	Properties/AssemblyInfo.cs:[assembly: AssemblyTitle("Sdk.Plugin")]
	Properties/AssemblyInfo.cs:[assembly: AssemblyProduct("Sdk.Plugin")]
	Properties/Resources.Designer.cs:namespace Sdk.Plugin.Properties {
	Properties/Resources.Designer.cs:                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Sdk.Plugin.Properties.Resources", typeof(Resources).Assembly);
	```
	- delete `obj` folder, to force icon rebuild with correct namespace from `sdkmenuicon.png`
## XAML user interface:&nbsp; [Create a UI by using XAML Designer](https://learn.microsoft.com/en-us/visualstudio/xaml-tools/creating-a-ui-by-using-xaml-designer-in-visual-studio?view=vs-2022)  
Until now, [my **SimHub plugins**](https://blekenbleu.github.io/static/SimHub/) avoided having any user interface:  
- @Romainrob *20 Jan 2023* "remove `IWPFSettingsV2` from the class declaration"  

### SimHub user interface uses [XAML](https://learn.microsoft.com/en-us/visualstudio/xaml-tools/?view=vs-2022)  
- @MorGuux *18 Jul 2018*:&nbsp; It uses WPF for the visual framework, so you can use anything WPF, not forms  
- when Visual Studio is first launched for this project, the **Control.xaml** tab will show:  
	![](Documentation/SettingsControlDemo.png)  
	... which displays in SimHub as:  
	![](Documentation/DemoPlugin.png)  
- @Wotever *12 Aug 2018*:  
		- "Designer really miss of precision, it's way better to use the xaml editor.  
	 	- &nbsp;With designer you barely can't do scalable ui"  
- [MahApps.Metro documentation](https://mahapps.com/)  
- @RaceX *20 Nov 2022*:&nbsp; you can use the xaml hot reload feature while debugging  
- removed `Demo` from file names and used VIM to:  
	- remove 'Demo' from references 
	- replace `My.PluginSdk` with `SimHubPluginSdk`  

<details><summary>click for details</summary>
<pre>
bleke@Antec MSYS /d/my/SimHub/PluginSdk/SimHubPluginSdk
$ ls | grep Demo
DataPluginDemo.cs
DataPluginDemoSettings.cs
ControlDemo.xaml
ControlDemo.xaml.cs

bleke@Antec MSYS /d/my/SimHub/PluginSdk/SimHubPluginSdk
$ git mv DataPluginDemo.cs Plugin.cs

bleke@Antec MSYS /d/my/SimHub/PluginSdk/SimHubPluginSdk
$ git mv DataPluginDemoSettings.cs Settings.cs

bleke@Antec MSYS /d/my/SimHub/PluginSdk/SimHubPluginSdk
$ git mv SettingsControlDemo.xaml Control.xaml

bleke@Antec MSYS /d/my/SimHub/PluginSdk/SimHubPluginSdk
$ git mv SettingsControlDemo.xaml.cs Control.xaml.cs
</pre>
</details>

