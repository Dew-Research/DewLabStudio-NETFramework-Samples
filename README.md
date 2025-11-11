<a href="https://www.dewresearch.com/products/mtxvec/mtxvec-for-delphi-c-builder">
<img align="right" src="https://www.dewresearch.com/images/Dew.png" width="128">
</a>

# Dew Lab Studio .NET — Sample Projects (WinForms, Windows / Core / Linux Variants)

This repository provides sample applications and reference code demonstrating how to use Dew Lab Studio for numerical analysis, scientific computing, DSP, statistical modeling, and high-performance data visualization.

**All samples in this repository are WinForms applications.**  
The visualization libraries (Dew.Math.TeePro, Dew.Signal.Tee, Dew.Stats.Tee) are built on top of TeeChart and require WinForms support.  
Therefore, these sample projects target Windows desktop-enabled frameworks:

- `net48`
- `net8.0-windows7.0`
- `net9.0-windows7.0`

The **core computation libraries** (Dew.Math, Dew.Signal, Dew.Stats) are independent of WinForms and can be used from WPF, Avalonia, services, console applications, or custom UI frameworks when targeting Windows.  
However, the visualization examples shown here specifically demonstrate WinForms-based charting and real-time display workflows.

---

## Trial NuGet Packages and Debugger Requirement

These sample projects reference the **trial editions** of the Dew Lab Studio libraries from the public NuGet repository.

Trial behavior:
- The libraries run in **full functionality** mode **when a debugger is attached**.
- When the application is executed **without a debugger**, trial restrictions apply (reduced performance and evaluation notices).
- To run applications normally outside debugging, a **registered license** is required.

This affects both `.NET Framework` and `.NET (Core)` usage.

---

## .NET (Core) / .NET 5+ Sample Repository

WinForms sample applications targeting `.NET 5 / 6 / 7 / 8 / 9` are located here:

https://github.com/Dew-Research/DewLabStudio-NETCore-Samples

The separation is required because **TeeChart serialization formats differ** between .NET Framework and .NET (Core).

---

## Editions and Platform Model

Dew Lab Studio is available in three variants, all sharing the same API surface:

| Edition | Hardware Acceleration | Platforms | Use Case |
|--------|-----------------------|-----------|----------|
| Dew Lab Studio (Windows) | Yes (native AVX / AVX2 / AVX-512 acceleration) | Windows x64 | Highest-performance workloads and real-time visualization |
| Dew Lab Studio Core | No native acceleration (managed-only) | Windows, Linux, macOS | Portable analytics, cross-platform builds, cloud/CI/CD |
| Dew Lab Studio Linux | Yes (native-accelerated Linux kernels) | Linux x64 | HPC compute nodes, batch scientific pipelines, servers |

You can switch editions simply by changing the NuGet package reference.

---

## Installing Evaluation or Full Version

Evaluation builds are available from NuGet:

Dew.Lab.Studio  
Dew.Lab.Studio.Core  
Dew.Lab.Studio.Linux

Visual Studio 2017+ and Rider will automatically restore all NuGet dependencies.  
Native runtimes are resolved automatically; **no manual DLL copying is required**.

---

## Repository Structure

Each sample application demonstrates focused workflows:

- Dense & sparse linear algebra, matrix factorizations, solvers
- Interpolation, special functions, Chebyshev / polynomial approximation
- Probability distributions, regression, hypothesis testing, Monte-Carlo simulation
- Real-time DSP pipelines, FFT-based spectral analysis, filtering, multirate processing
- Spectrograms, oscilloscopes, histograms, surface and matrix-based visualization

Samples are concise and designed for easy adaptation into your own applications.

---

## Line Ending Note

Enable **CRLF** when cloning this repository.  
Some dataset files depend on Windows line endings.

---

## Contributing / Feedback

When reporting a performance issue, include:

- Dew edition (Windows / Core / Linux)
- Target runtime (`net48`, `net8.0-windows`, etc.)
- OS version
- CPU model (relevant for AVX / AVX-512 dispatch)

Pull requests for new sample cases are welcome.
