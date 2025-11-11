<a href="https://www.dewresearch.com/products/mtxvec/mtxvec-for-delphi-c-builder">
<img align="right" src="https://www.dewresearch.com/images/Dew.png" width="128">
</a>

# Dew Lab Studio .NET — Sample Projects (WinForms, Windows / Core / Linux Variants)

This repository provides sample applications and reference code demonstrating how to use Dew Lab Studio for numerical analysis, scientific computing, DSP, statistical modeling, and high-performance data visualization.

**All samples in this repository are WinForms applications.**  
The visualization libraries (Dew.Math.TeePro, Dew.Signal.Tee, Dew.Stats.Tee) are built on top of TeeChart and require WinForms.  
Therefore, these samples must target Windows desktop-enabled frameworks such as:

- `net48`
- `net8.0-windows7.0`
- `net9.0-windows7.0`

The **core computation libraries** (Dew.Math, Dew.Signal, Dew.Stats) do *not* depend on WinForms and can be used from other UI frameworks (WPF, Avalonia, custom rendering engines, services, console applications, etc.) on Windows.  
However, the **visualization samples** shown here specifically demonstrate WinForms-based visualization workflows.

A **different repository / folder** contains WinForms sample projects for **.NET Core / .NET 5+** targets.  
This separation is required because **TeeChart serialization formats differ between .NET Framework and .NET (Core)**.

---

## Editions and Platform Model

Dew Lab Studio is available in three variants, all sharing the same namespace and API model:

| Edition | Hardware Acceleration | Platforms | Use Case |
|--------|-----------------------|-----------|----------|
| Dew Lab Studio (Windows) | Yes (native AVX/AVX2/AVX-512 acceleration) | Windows x64 | Highest-performance numerical and signal workflows with interactive visualization |
| Dew Lab Studio Core | No native acceleration (managed-only) | Windows, Linux, macOS | Portable analytics, cross-platform builds, containers, cloud |
| Dew Lab Studio Linux | Yes (native-accelerated Linux runtime) | Linux x64 | HPC nodes, compute clusters, headless server pipelines |

You can switch editions by changing the NuGet package reference—application code remains the same.

---

## Installing Evaluation or Full Version

Evaluation builds are available from NuGet:

Dew.Lab.Studio  
Dew.Lab.Studio.Core  
Dew.Lab.Studio.Linux

Visual Studio 2017+ and Rider will automatically restore all packages when opening a sample solution.

Native runtimes are resolved automatically; **no manual DLL copying is required**.

---

## Repository Structure

Each sample application contains multiple focused demonstrations:

- Matrix and vector workflows, dense & sparse solvers
- Numerical modeling, interpolation, polynomial / Chebyshev approximation
- Probability distributions, regression, hypothesis tests, simulation
- Real-time DSP signal chains, filtering, FFT and spectral transforms
- Oscilloscope views, spectrograms, waterfall and frequency-domain displays
- Statistical histograms and visualization helpers

The samples are intentionally **short and direct**, designed to be copied into your own applications.

---

## Note on Line Endings

Enable **CRLF** when cloning this repository.  
Some included data files depend on Windows line endings.

---

## .NET Core / .NET 5+ Samples

WinForms samples for `.NET 5 / 6 / 7 / 8 / 9` (also visualization-bound) are located in:

