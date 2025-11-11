<a href="https://www.dewresearch.com/products/mtxvec/mtxvec-for-delphi-c-builder">
<img align="right" src="https://www.dewresearch.com/images/Dew.png" width="128">
</a>

# Dew Lab Studio .NET — Sample Projects (Windows, Core, Linux)

This repository provides sample applications and reference code demonstrating how to use Dew Lab Studio for scientific computing, numerical analysis, DSP, statistical modeling, and high-performance data visualization.

Each sample set corresponds to one or more of the following core libraries:

- Dew.Math — vectorized numerical computing, dense & sparse linear algebra, optimization, special functions, probability distributions, Monte-Carlo, expression evaluation.
- Dew.Signal — real-time DSP pipelines, FFT-based spectral analysis, filtering, multirate processing, streaming capture & playback, time-frequency transforms.
- Dew.Stats — statistical modeling, regression methods, inference, distributions, hypothesis testing, stochastic simulation.

Visualization examples also use:

- Dew.Math.TeePro
- Dew.Signal.Tee
- Dew.Stats.Tee

These extend TeeChart for high-performance plotting of large numerical datasets, spectrograms, matrices, histograms, streaming signals, and model outputs.
The visualization components internally rely on WinForms, but do not require your application to be WinForms-based; they can be used from WinForms, WPF, Avalonia, or custom UI frameworks when targeting Windows (net8.0-windows, net9.0-windows).

---

## Editions and Platform Model

Dew Lab Studio is available in three variants, with the same API surface:

| Edition | Hardware Acceleration | OS / Platforms | Use Case |
|--------|-----------------------|----------------|----------|
| Dew Lab Studio (Windows) | Yes (native AVX/AVX2/AVX-512 acceleration) | Windows x64 | Maximum performance for engineering, scientific, financial, DSP, and real-time visualization workloads |
| Dew Lab Studio Core | No native acceleration (managed-only) | Windows, Linux, macOS, containers | Portable code, cloud & CI/CD builds, cross-platform analytics |
| Dew Lab Studio Linux | Yes (native-accelerated Linux runtime) | Linux x64 | HPC clusters, compute nodes, server pipelines, batch processing |

Write code once and switch platform packages as needed.

---

## Installing Evaluation or Full Version

Evaluation builds are available directly from public NuGet:

Dew.Lab.Studio  
Dew.Lab.Studio.Core  
Dew.Lab.Studio.Linux

Visual Studio 2017+ or JetBrains Rider will automatically restore all dependencies when opening a sample solution.

Native runtime libraries are automatically resolved by build scripts; no manual copying is required.

---

## Repository Structure

Each primary folder contains a main sample application consisting of multiple self-contained demonstrations:

- Linear algebra workflows, solvers, matrix factorizations
- Numerical modeling, interpolation, special functions
- DSP chain construction, FFT pipelines, real-time spectral displays
- Statistical distributions, regressions, stochastic models
- 2D/3D visualization of numerical and signal data using TeeChart extensions

Samples are intentionally designed to be small, isolated, and direct, making it easy to copy the code into your own projects.

---

## Line Ending Note

Ensure that CRLF is enabled when cloning this repository — some sample data files require Windows line endings.

---

## Contributing / Reporting Issues

If you encounter a bug or performance regression, please include:

- Dew Lab Studio edition + version
- .NET runtime (net48, net8.0-windows, net9.0-windows, etc.)
- OS type and CPU model (useful for AVX dispatch optimizations)

Pull requests for additional demo examples are welcome.
