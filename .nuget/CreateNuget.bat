"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv" "..\PodioPCL\PodioPCL.csproj" /build Release
pushd NugetBuilds
..\Nuget.exe pack ..\PodioPCL.nuspec