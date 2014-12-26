About
=====
This is a .NET 4.5 Portable Class Library varriant for accessing the Podio API. Very heavily based on the official .NET Client.

Installation
-------

![Nuget](https://www.nuget.org/Content/Logos/nugetlogo.png)

Published Nuget package here: https://www.nuget.org/packages/PodioPCL/0.1.0

Currently there is not a NuGet package for the PCL here. You can include the project, or build it and include the DLL.

Changes
-------------

While I tried to make the PCL as backwards compatible as possible, some classes are just not in the Portable version of .NET. Those methods might be left in but marked as Obsolete (they would work but not optimized), throw a NotImplementedException or not exist at all.

If there is any loss of functionality by making it backwards compatible or becomes too difficult to implement, I will abandon that goal.

This is still a work in progress, but it is a WORKING work in progress :)

For now I will retain the same license as the project this was forked from, with the same lack of warranty.
