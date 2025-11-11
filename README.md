<a href="https://www.dewresearch.com/products/mtxvec/mtxvec-for-delphi-c-builder">
<img align="right" src="https://www.dewresearch.com/images/Dew.png" width="128">
</a>

# Dew Lab Studio .NET — Sample Projects (WinForms, Windows / Core / Linux Variants)

This repository provides sample applications and reference code demonstrating how to use Dew Lab Studio for numerical analysis, scientific computing, DSP, statistical modeling, and high-performance data visualization.

**All samples in this repository are WinForms applications.**  
The visualization libraries (Dew.Math.TeePro, Dew.Signal.Tee, Dew.Stats.Tee) are built on top of TeeChart and require WinForms support.  
Therefore, these samples target Windows desktop-enabled frameworks such as:

- `net48`
- `net8.0-windows7.0`
- `net9.0-windows7.0`

The **core computation libraries** (Dew.Math, Dew.Signal, Dew.Stats) do *not* require WinForms and can be used in WPF, Avalonia, console, services, and custom UIs on Windows.  
However, the visualization samples shown here specifically demonstrate WinForms-based charting and real-time display workflows.

---

## .NET (Core) / .NET 5+ Samples Are in a Separate Repository

WinForms sample applications for `.NET 5 / 6 / 7 / 8 / 9` are located here:

https://github.com/Dew-Research/DewLabStudio-NETCore-Samples

These are separate because **TeeChart serialization differs between .NET Framework and .NET (Core)** and cannot be shared in the same project structure.

---

## Editions and Platform Model

Dew Lab Studio is available in three variants with the same API surface:

| Edition | Hardware Acceleration | Platforms | Use Case |
|--------|-----------------------|-----------|----------|
| Dew Lab Studio (Windows) | Yes (native AVX/AVX2/AVX-512 acceleration) | Windows x64 | Highest performance for engineering, scientific, financial, DSP, real-time visualization |
| Dew Lab Studio Core | No native acceleration (managed-only) | Windows, Linux, macOS | Portable analytics, cloud, containers, CI/CD, code sharing |
| Dew Lab Studio Linux | Yes (native-accelerated Linux kernels) | Linux x64 | HPC compute nodes, scientific pipelines, cluster workflows |

You can switch between editions by changing the NuGet package reference — the application code remains the same.

---

## Installing Evaluation or Full Version

Evaluation builds are available from NuGet:

Dew.Lab.Studio  
Dew.Lab.Studio.Core  
Dew.Lab.Studio.Linux

Visual Studio 2017+ and JetBrains Rider will restore required packages automatically.  
Native libraries are resolved automatically — no manual DLL copying is required.

---

## Repository Structure

Each sample application demonstrates focused workflows:

- Dense & sparse linear algebra, matrix factorization, solvers
- Special functions, interpolation, polynomial / Chebyshev approximation
- Probability distributions, regression models, hypothesis tests, Monte-Carlo
- Real-time DSP chains, spectral FFT displays, filtering, multirate processing
- Spectrograms, oscilloscopes, histograms, matrix and statistical visualization

Samples are intentionally concise to make it easy to transfer code directly into your own projects.

---

## Line Ending Note

Enable **CRLF** when cloning this repository — some sample data files depend on Windows line endings.

---

## Contributing / Feedback

When reporting issues, include:

- Dew Lab Studio edition (Windows / Core / Linux)
- Target runtime (`net48`, `net8.0-windows`, etc.)
- Operating system
- CPU model (important for AVX/AVX-512 dispatch behavior)

Pull requests for new sample cases are welcome.
