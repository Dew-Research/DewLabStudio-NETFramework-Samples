<a href="https://www.dewresearch.com/products/mtxvec/mtxvec-for-delphi-c-builder">
<img align="right" src="https://www.dewresearch.com/templates/yootheme/cache/mtxvex-icon-ef5151c5.png">
</a>  

# Dew Lab Studio .NET for .NET Framework samples
==============================================================
  
Sample programs showing how to use Dew Lab Studio for .NET Framework (v2.0-4.8)

Dew Lab Studio for .NET Framework contains several products. For each product there is a separate "main" demo project, which contains multiple independent examples. The .NET Core (5.0 and newer) samples are in a separate repository.

You'll need Dew Lab Studio for .NET evaluation or registered version to run the samples on this repository. Fully functional evaluation versions can be obtained from the public NuGet repository as "Dew Lab Studio". Dew Lab Studio is available in three editions:

* Windows Edition. Includes Hardware Acceleration library and runs only on Windows. (net20, net50, net50-windows), (32bit and 64bit) Automatically referenced by the  sample project. 
* Core Edition. Runs on all .NET Core supported platforms, but without Hardware Acceleration library. (net50), (32bit and 64bit)
* Linux Edition. Includes Hardware Acceleration library and runs only on Linux. (net50) (64bit)

VS.NET 2015 and newer should be able to automatically restore missing NuGet packages when attempting to build. If not, install "Dew Lab Studio" NuGet from the public repository for the solution first by using the NuGet Package Manager.  

<b>IMPORTANT:</b>

When using .NET Framework, inside of the solution folder there will be a "Packages" folder created during the build. Within this folder locate 

.\packages\Dew.Math.6.0.4\runtimes

And copy x86 content (dlls) to C:\Windows\SysWO64\ and x64 content to C:\Windows\System32\

When using .NET Core, these dlls are referenced in a different way and copying is not needed.
