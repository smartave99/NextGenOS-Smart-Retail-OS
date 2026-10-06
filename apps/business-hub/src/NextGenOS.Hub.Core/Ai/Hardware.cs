using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace NextGenOS.Hub.Ai;

/// <summary>The machine's size, in one of a few profiles. AI features adapt to it: a small office laptop gets small helpers, a workstation with a graphics card gets more.</summary>
public static class HardwareProfile
{
    public const string Light = "LIGHT_LOCAL";
    public const string Standard = "STANDARD_LOCAL";
    public const string GpuLocal = "GPU_LOCAL";
    public const string HeavyGpu = "HEAVY_GPU";
    public const string EdgeServer = "EDGE_SERVER";
    public const string Enterprise = "ENTERPRISE_SERVER";

    public static readonly IReadOnlyList<string> All = new[] { Light, Standard, GpuLocal, HeavyGpu, EdgeServer, Enterprise };

    public static string Label(string profile) => profile switch
    {
        Light => "Light", Standard => "Standard", GpuLocal => "With a graphics card", HeavyGpu => "Powerful graphics card", EdgeServer => "Dedicated edge box", Enterprise => "Server", _ => profile,
    };

    /// <summary>What this size of machine can sensibly do, in plain words.</summary>
    public static string WhatItCanDo(string profile) => profile switch
    {
        Light => "Small helpers on this computer: searching by meaning with a small model, short answers from a small model, basic reports. Not for watching cameras all day or for large models.",
        Standard => "Embeddings and small to medium language models (answers take a few seconds), reading documents, and basic analysis. Cameras only lightly, a picture now and then.",
        GpuLocal => "Medium models quickly, and real-time analysis of a few cameras on this computer.",
        HeavyGpu => "Large models, several cameras at once, and picture-understanding models when needed.",
        EdgeServer => "A box that sits in the shop next to the cameras: analyses them on the spot and keeps working without the internet.",
        Enterprise => "Many cameras, large models and several people asking at the same time.",
        _ => "",
    };
}

/// <summary>"yes", "no" or "unknown": a thing we could not look at is never reported as missing.</summary>
public static class Support
{
    public const string Yes = "yes";
    public const string No = "no";
    public const string Unknown = "unknown";
}

public sealed record GpuInfo(string Vendor, string Model, double? VramGb, bool Integrated);

public sealed record Accelerators(string Cuda, string Rocm, string DirectMl, string Metal, string OpenVino, string TensorRt, string OnnxRuntime);

/// <summary>What was found on the machine, before any judgement.</summary>
public sealed record RawHardware(
    string CpuArch, int? PhysicalCores, int LogicalCores, double RamTotalGb, double? RamAvailableGb, IReadOnlyList<GpuInfo> Gpus, string? Npu,
    Accelerators Accelerators, double? DiskFreeGb, string Os, bool NetworkAvailable, bool IsEdgeBoard, IReadOnlyList<string> Notes);

/// <summary>What was found, with the profile it adds up to.</summary>
public sealed record CapabilityProfile(RawHardware Hardware, string Profile, IReadOnlyList<string> Warnings);

/// <summary>The sizes that separate the profiles. They are values, not code, so that they can be set from outside later.</summary>
public sealed record ProfileThresholds(
    double EnterpriseRamGb = 128, int EnterpriseCores = 32, double EnterpriseVramGb = 80, double HeavyVramGb = 24, double HeavyRamGb = 32,
    double GpuVramGb = 8, double GpuRamGb = 16, double StandardRamGb = 16, int StandardCores = 4, double MinRamForLocalAiGb = 8, double MinDiskForModelsGb = 10);

public static class ProfileClassifier
{
    public static CapabilityProfile Classify(RawHardware hw, ProfileThresholds? thresholds = null)
    {
        var t = thresholds ?? new ProfileThresholds();
        var discrete = hw.Gpus.Where(g => !g.Integrated && g.VramGb is not null).ToList();
        var maxVram = discrete.Count == 0 ? 0 : discrete.Max(g => g.VramGb!.Value);
        var totalVram = discrete.Sum(g => g.VramGb!.Value);
        // Apple chips and similar share one memory between the processor and the graphics: the whole memory counts.
        var unifiedGpu = hw.Accelerators.Metal == Support.Yes && hw.CpuArch == "arm64";

        string profile;
        if (totalVram >= t.EnterpriseVramGb || (hw.RamTotalGb >= t.EnterpriseRamGb && hw.LogicalCores >= t.EnterpriseCores)) profile = HardwareProfile.Enterprise;
        else if (maxVram >= t.HeavyVramGb && hw.RamTotalGb >= t.HeavyRamGb) profile = HardwareProfile.HeavyGpu;
        else if (hw.IsEdgeBoard && hw.RamTotalGb >= 8) profile = HardwareProfile.EdgeServer;
        else if ((maxVram >= t.GpuVramGb || unifiedGpu) && hw.RamTotalGb >= t.GpuRamGb) profile = HardwareProfile.GpuLocal;
        else if (hw.RamTotalGb >= t.StandardRamGb && hw.LogicalCores >= t.StandardCores) profile = HardwareProfile.Standard;
        else profile = HardwareProfile.Light;

        var warnings = new List<string>();
        if (hw.RamTotalGb < t.MinRamForLocalAiGb) warnings.Add($"This computer has {hw.RamTotalGb:0.#} GB of memory. Local AI models need at least {t.MinRamForLocalAiGb:0} GB; the shop program is not affected.");
        if (hw.DiskFreeGb is { } free && free < t.MinDiskForModelsGb) warnings.Add($"Only {free:0.#} GB of disk space is free. Models need space (many are several GB); free some before installing one.");
        return new CapabilityProfile(hw, profile, warnings);
    }
}

/// <summary>What looks at the machine. A fake one is used in tests.</summary>
public interface IHardwareProbe
{
    RawHardware Probe(string dataFolder);
}

/// <summary>
/// Looks at the real machine with what the operating system and .NET offer, and with a graphics driver's own tool when it is installed. Every part is tried on its own: what cannot be
/// looked at is reported as "unknown" with a note, never guessed, and a probe never throws or takes long (each outside tool gets a few seconds).
/// </summary>
public sealed class SystemHardwareProbe : IHardwareProbe
{
    public RawHardware Probe(string dataFolder)
    {
        var notes = new List<string>();
        var os = OperatingSystem.IsWindows() ? "windows" : OperatingSystem.IsMacOS() ? "macos" : OperatingSystem.IsLinux() ? "linux" : "other";
        var arch = RuntimeInformation.OSArchitecture switch { Architecture.X64 => "x86_64", Architecture.Arm64 => "arm64", Architecture.X86 => "x86", Architecture.Arm => "arm", var a => a.ToString().ToLowerInvariant() };

        var (total, available) = Memory(os);
        var gpus = new List<GpuInfo>();
        string cuda = Support.Unknown;
        var nvidia = NvidiaGpus();
        if (nvidia is not null) { gpus.AddRange(nvidia); cuda = nvidia.Count > 0 ? Support.Yes : Support.No; }
        gpus.AddRange(OtherGpus(os, notes, skipNvidia: nvidia is { Count: > 0 }));
        var jetson = os == "linux" && (File.Exists("/etc/nv_tegra_release") || (SafeRead("/proc/device-tree/model") ?? "").Contains("Jetson", StringComparison.OrdinalIgnoreCase));
        if (jetson)
        {
            if (gpus.All(g => g.Vendor != "NVIDIA")) gpus.Add(new GpuInfo("NVIDIA", "Jetson (integrated)", null, true));
            cuda = Support.Yes;
            notes.Add("Recognised an NVIDIA Jetson board; CUDA is assumed from that.");
        }
        if (nvidia is null && !jetson) cuda = gpus.Count == 0 && os != "windows" ? Support.No : gpus.Any(g => g.Vendor == "NVIDIA") ? Support.Unknown : Support.No;

        var rocm = os == "linux" ? (Directory.Exists("/opt/rocm") || OnPath("rocm-smi") ? Support.Yes : Support.No) : Support.No;
        var directMl = os == "windows" ? (gpus.Count > 0 ? Support.Yes : Support.Unknown) : Support.No;
        if (os == "windows" && gpus.Count > 0) notes.Add("DirectML is assumed from Windows and a graphics adapter; it was not tried.");
        var metal = os == "macos" ? Support.Yes : Support.No;
        notes.Add("OpenVINO, TensorRT and ONNX Runtime were not probed: no such runtime is installed with the shop program yet.");

        string? npu = null;
        var processor = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") ?? "";
        if (arch == "arm64" && processor.Contains("Qualcomm", StringComparison.OrdinalIgnoreCase)) { npu = "qualcomm"; notes.Add("A Qualcomm neural processor is assumed from the processor's name; it was not probed."); }

        double? disk = null;
        try
        {
            var root = Path.GetPathRoot(Path.GetFullPath(dataFolder));
            if (!string.IsNullOrEmpty(root)) disk = Math.Round(new DriveInfo(root).AvailableFreeSpace / Gb, 1);
        }
        catch (Exception e) when (e is IOException or ArgumentException or UnauthorizedAccessException) { notes.Add("The free disk space could not be read."); }

        var network = false;
        try { network = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable(); } catch (System.Net.NetworkInformation.NetworkInformationException) { /* reported as no network */ }

        return new RawHardware(arch, PhysicalCores(os), Environment.ProcessorCount, total, available, gpus,
            npu, new Accelerators(cuda, rocm, directMl, metal, Support.Unknown, Support.Unknown, Support.Unknown), disk, os, network, jetson, notes);
    }

    private const double Gb = 1024d * 1024d * 1024d;

    private static (double Total, double? Available) Memory(string os)
    {
        var info = GC.GetGCMemoryInfo();
        var total = info.TotalAvailableMemoryBytes / Gb;
        double? available = info.TotalAvailableMemoryBytes > 0 ? Math.Max(0, (info.TotalAvailableMemoryBytes - info.MemoryLoadBytes) / Gb) : null;
        if (os == "linux")
        {
            // The kernel's own figure for what can be used without swapping is better than load arithmetic.
            foreach (var line in (SafeRead("/proc/meminfo") ?? "").Split('\n'))
            {
                if (line.StartsWith("MemAvailable:", StringComparison.Ordinal) && TryKb(line, out var kb)) available = kb / (1024d * 1024d);
            }
        }
        return (Math.Round(total, 1), available is null ? null : Math.Round(available.Value, 1));
    }

    private static bool TryKb(string line, out double kb)
    {
        var digits = new string(line.Where(char.IsDigit).ToArray());
        return double.TryParse(digits, NumberStyles.None, CultureInfo.InvariantCulture, out kb);
    }

    private static int? PhysicalCores(string os)
    {
        if (os != "linux") return null;
        var text = SafeRead("/proc/cpuinfo");
        if (text is null) return null;
        var cores = new HashSet<string>();
        string physical = "0";
        foreach (var line in text.Split('\n'))
        {
            if (line.StartsWith("physical id", StringComparison.Ordinal)) physical = line.Split(':').Last().Trim();
            else if (line.StartsWith("core id", StringComparison.Ordinal)) cores.Add(physical + "/" + line.Split(':').Last().Trim());
        }
        return cores.Count > 0 ? cores.Count : null;
    }

    /// <summary>NVIDIA's own tool, when it is installed: null means "could not look", an empty list means "looked, found none".</summary>
    private static List<GpuInfo>? NvidiaGpus()
    {
        var output = Run("nvidia-smi", "--query-gpu=name,memory.total --format=csv,noheader,nounits");
        if (output is null) return null;   // the tool is not installed or did not answer: we could not look
        var list = new List<GpuInfo>();
        foreach (var line in output.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split(',');
            if (parts.Length < 2) continue;
            list.Add(new GpuInfo("NVIDIA", parts[0].Trim(), double.TryParse(parts[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var mb) ? Math.Round(mb / 1024d, 1) : null, false));
        }
        return list;
    }

    private static IEnumerable<GpuInfo> OtherGpus(string os, List<string> notes, bool skipNvidia)
    {
        var found = new List<GpuInfo>();
        try
        {
            if (os == "linux")
            {
                var drm = "/sys/class/drm";
                if (Directory.Exists(drm))
                {
                    foreach (var card in Directory.GetDirectories(drm, "card?"))
                    {
                        var vendor = (SafeRead(Path.Combine(card, "device", "vendor")) ?? "").Trim();
                        var name = vendor switch { "0x10de" => "NVIDIA", "0x1002" => "AMD", "0x8086" => "Intel", "0x5143" => "Qualcomm", _ => "" };
                        if (name == "" || (skipNvidia && name == "NVIDIA")) continue;
                        double? vram = null;
                        if (long.TryParse((SafeRead(Path.Combine(card, "device", "mem_info_vram_total")) ?? "").Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out var bytes)) vram = Math.Round(bytes / Gb, 1);
                        found.Add(new GpuInfo(name, "unknown model", vram, vram is null));
                    }
                }
            }
            else if (os == "windows") found.AddRange(WindowsAdapters(skipNvidia));
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException or System.Security.SecurityException)
        {
            notes.Add("The graphics adapters could not be read.");
        }
        return found;
    }

    [SupportedOSPlatform("windows")]
    private static IEnumerable<GpuInfo> WindowsAdaptersCore(bool skipNvidia)
    {
        using var classKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}");
        if (classKey is null) yield break;
        foreach (var name in classKey.GetSubKeyNames().Where(n => n.Length == 4 && n.All(char.IsDigit)))
        {
            using var key = classKey.OpenSubKey(name);
            var description = key?.GetValue("DriverDesc") as string;
            if (string.IsNullOrWhiteSpace(description)) continue;
            var vendor = description.Contains("NVIDIA", StringComparison.OrdinalIgnoreCase) ? "NVIDIA"
                : description.Contains("AMD", StringComparison.OrdinalIgnoreCase) || description.Contains("Radeon", StringComparison.OrdinalIgnoreCase) ? "AMD"
                : description.Contains("Intel", StringComparison.OrdinalIgnoreCase) ? "Intel"
                : description.Contains("Qualcomm", StringComparison.OrdinalIgnoreCase) || description.Contains("Adreno", StringComparison.OrdinalIgnoreCase) ? "Qualcomm" : "other";
            if (skipNvidia && vendor == "NVIDIA") continue;
            if (description.Contains("Basic Display", StringComparison.OrdinalIgnoreCase) || description.Contains("Remote Display", StringComparison.OrdinalIgnoreCase)) continue;
            double? vram = null;
            var raw = key!.GetValue("HardwareInformation.qwMemorySize");
            if (raw is byte[] { Length: 8 } bytes) vram = Math.Round(BitConverter.ToUInt64(bytes, 0) / Gb, 1);
            else if (raw is long l) vram = Math.Round(l / Gb, 1);
            yield return new GpuInfo(vendor, description, vram, vendor == "Intel" || vendor == "Qualcomm");
        }
    }

    private static IEnumerable<GpuInfo> WindowsAdapters(bool skipNvidia) => OperatingSystem.IsWindows() ? WindowsAdaptersCore(skipNvidia).ToList() : Array.Empty<GpuInfo>();

    private static string? SafeRead(string path)
    {
        try { return File.Exists(path) ? File.ReadAllText(path) : null; }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { return null; }
    }

    private static bool OnPath(string tool)
    {
        var separator = OperatingSystem.IsWindows() ? ';' : ':';
        foreach (var dir in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(separator, StringSplitOptions.RemoveEmptyEntries))
        {
            try { if (File.Exists(Path.Combine(dir, tool)) || File.Exists(Path.Combine(dir, tool + ".exe"))) return true; }
            catch (ArgumentException) { /* a malformed folder in PATH */ }
        }
        return false;
    }

    /// <summary>Runs a tool that must already be installed, without a window, and gives its output; null when it is missing, fails or is too slow (4 seconds).</summary>
    private static string? Run(string tool, string arguments)
    {
        if (!OnPath(tool)) return null;
        try
        {
            using var process = Process.Start(new ProcessStartInfo(tool, arguments) { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false, CreateNoWindow = true });
            if (process is null) return null;
            var output = process.StandardOutput.ReadToEndAsync();
            if (!process.WaitForExit(4000)) { try { process.Kill(true); } catch (InvalidOperationException) { /* it just ended */ } return null; }
            return process.ExitCode == 0 ? output.GetAwaiter().GetResult() : null;
        }
        catch (Exception e) when (e is System.ComponentModel.Win32Exception or InvalidOperationException or IOException) { return null; }
    }
}

/// <summary>Looks at the machine once in a while (not on every screen) and keeps the answer.</summary>
public sealed class HardwareService(IHardwareProbe probe, string dataFolder, IClock clock, TimeSpan? lifetime = null)
{
    private readonly object _gate = new();
    private CapabilityProfile? _cached;
    private DateTimeOffset _at;

    public CapabilityProfile Capabilities()
    {
        lock (_gate)
        {
            if (_cached is not null && clock.UtcNow - _at < (lifetime ?? TimeSpan.FromMinutes(5))) return _cached;
            _cached = ProfileClassifier.Classify(probe.Probe(dataFolder));
            _at = clock.UtcNow;
            return _cached;
        }
    }

    /// <summary>Looks again now (after a card was fitted, or for the "check again" button).</summary>
    public CapabilityProfile Refresh()
    {
        lock (_gate) { _cached = null; }
        return Capabilities();
    }
}
