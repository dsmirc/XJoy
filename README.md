
# XJoy
XJoy is a XInput to vJoy feeder application written in c#. 

![](https://github.com/MasterKenth/XJoy/blob/master/extra/icon_128.png)

It is used to map XInput keys and axes to vJoy equivalents, essentially converting XInput to DirectInput. This has the benefit of making newer controllers work with a range of legacy and cross-platform games and interfaces, such as SDL.

This project first came to be when I wanted to use an Nvidia Shield Controller (XInput only device) with the FCEUX emulator (doesn't appear to support XInput).

<sub>You may wonder why the Xbox 360 controller still works with DirectInput applications. Xbox 360 controllers are most often treated as XInput devices by games and applications that support it, but the 360 controllers also have a DirectInput fallback which makes it backwards-compatible with many applications (though this has the side effect of treating the triggers as one single axis). There is an [MSDN article on the subject](https://msdn.microsoft.com/en-us/library/windows/desktop/ee417014(v=vs.85).aspx). The main issue however, is that many XInput devices don't have the same fallback and can use this program to "enable" it.</sub>

## How to Use
The program is very simple to use. Install vJoy (this program uses v2.1.6), run the program, select your XInput device and corresponding vJoy device from the dropdowns, setup your input mapping and press "Activate". The program should now display that it is running, or show errors if something occurred. You can also minimize the window to put it in the tray and run in the background.

### Input Remapping
After you select a vJoy device from the dropdown, the dropdowns for the input remapping are enabled and populated with the supported axes and buttons of the selected vJoy device. Simply select what vJoy input to emulate from which XInput input. These can be changed at any time, even when the feeder is running (activated).

Multiple XInput inputs can be mapped to same the vJoy inputs, e.g. both the A and B buttons can drive vJoy button "1". For buttons, either button will trigger the vJoy input ('or'd together). For axes, the maximum value of the axes is used.

Currently only analog XInput values can be mapped to analog vJoy inputs, and digital to digital. Enabled analog to digital and vice versa is on the todo list.

## Download
Clone from source or download the pre-built binaries from the [releases page](https://github.com/MasterKenth/XJoy/releases).

## TODO List
List of major new features to implement:
* Cross-type input remapping (i.e. analog to digital and vice versa)
* Read/save input configurations from/to files
* Auto-start commandline options (so that you can launch a config with a single command)
* Configurable feeder frequency (delay between updates, currently hardcoded to 16ms or ~60fps)

## How to use source
This program is dependent on SharpDX and SharpDX.XInput (you can fetch these from the NuGet manager in Visual Studio) as well as the vJoy C# SDK (vJoyInterface.dll and vJoyInterfaceWrap.dll). Make sure that vJoyInterfaceWrap.dll is added as a project reference by right-clicking the project in the Solution Explorer, `Add -> Reference...`, press Browse and select the dll.

##FAQ
### Why aren't my devices listed in the dropdowns?
Only valid devices show up in the dropdowns, and you can refresh them by pressing the refresh button. A valid XInput device is one that is connected (and there is a limitation on max 4 XInput controllers so only the first 4 available are checked) and a valid vJoy device is one where `GetVJDStatus` returns `VJD_STAT_FREE` (e.g. the device slot is created in vJoy and isn't already acquired by some other application).

### I'm getting strange errors/crashes/etc. what is wrong?
I haven't had much time diving into crashes and what not. The application is always in a state that works for me, otherwise I would fix it immediately. Try making sure that all dependencies are installed (.Net 4.5 I believe, as well as making sure the SharpDX and vJoyInterface dll files are there). If you find a bug then you can inform me by creating an issue-ticket or contacting me somehow, or if you're somewhat adept at C# you could give it a go yourself!
