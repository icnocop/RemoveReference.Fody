## This is an add-in for [Fody](https://github.com/Fody/Fody/)

![Icon](https://raw.github.com/icnocop/RemoveReference.Fody/master/Icons/delete-link-32.png)

Facilitates removing references in a compiled assembly during a build.

### Before (decompiled view of assembly references)

![Image](https://raw.github.com/icnocop/RemoveReference.Fody/master/Images/Before.png)

### After (decompiled view of assembly references)

![Image](https://raw.github.com/icnocop/RemoveReference.Fody/master/Images/After.png)

### Quick Start

1. Install the RemoveReference.Fody NuGet package for the project that builds your assembly

2. Add a RemoveReference attribute in your code for each assembly reference you want to remove from the compiled assembly:

    [assembly: RemoveReference("mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e")]
    [assembly: RemoveReference("System.Core, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e")]

3. Rebuild your project and enjoy!

## Nuget 

Nuget package http://nuget.org/packages/RemoveReference.Fody

To Install from the Nuget Package Manager Console 
    
    PM> Install-Package RemoveReference.Fody

## Credits

Inspired by [Microsoft Visual Studio and Portable Class Library (PCL) bug](https://connect.microsoft.com/VisualStudio/feedback/details/779370/vs2012-incorrectly-resolves-mscorlib-version-when-referencing-pcl-assembly).

Many thanks to [Simon Cropp](https://twitter.com/SimonCropp), [Fody](https://github.com/Fody/Fody/), contributors, and the community!

[Introduction to Fody](http://github.com/Fody/Fody/wiki/SampleUsage)

## Icon

<a href="http://www.iconsdb.com/red-icons/delete-link-icon.html" target="_blank">Red delete link icon</a> designed by <a href="http://icons8.com/" target="_blank">Icons8</a> and <a rhef="http://www.visualpharm.com/" target="_blank" >VisualPharm</a>