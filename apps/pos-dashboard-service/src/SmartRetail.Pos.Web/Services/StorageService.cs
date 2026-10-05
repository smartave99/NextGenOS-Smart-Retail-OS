using System.Diagnostics;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Storage;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A drive the owner can keep the data on.</summary>
public sealed record DriveChoice(string Root, string Label, long FreeBytes, long TotalBytes, bool Removable)
{
    public double UsedShare => TotalBytes <= 0 ? 0 : 1 - (double)FreeBytes / TotalBytes;
}

/// <summary>What the data folder holds.</summary>
public sealed record DataFolderUse(int Products, int PhotoFiles, long PhotoBytes, int PlanFiles, long PlanBytes, int Posters, long FreeBytes);

/// <summary>
/// The data folder the owner chose for product photos, growth plans and posters, kept in storage.json beside the side panel's
/// settings, and moving the data when the owner picks another folder.
/// </summary>
public sealed class StorageService
{
    /// <summary>Drives smaller than this are not offered: they cannot hold many photos.</summary>
    private const long MinimumDriveBytes = 1L * 1024 * 1024 * 1024;

    private readonly StorageSettingsStore _settings;
    private readonly SemaphoreSlim _moving = new(1, 1);

    public StorageService(IOptions<AiOptions> options)
    {
        _settings = StorageSettingsStore.Beside(options.Value.SettingsFilePath);
        SettingsFolder = Path.GetDirectoryName(Path.GetFullPath(options.Value.SettingsFilePath)) ?? "";
    }

    /// <summary>Where the side panel's settings and saved keys are; they never move.</summary>
    public string SettingsFolder { get; }

    /// <summary>Read each time, so a change is used at once everywhere.</summary>
    public string DataFolder => DataFolders.Resolve(_settings.Load());

    public bool IsDefault => string.IsNullOrWhiteSpace(_settings.Load().DataFolder);

    public string ProductsFolder => DataFolders.Products(DataFolder);

    public string PlansFolder => DataFolders.Plans(DataFolder);

    /// <summary>True while data is being moved; photos cannot be added meanwhile.</summary>
    public bool IsMoving => _moving.CurrentCount == 0;

    /// <summary>Raised when another data folder is in use (the data moved there, or it held the add-on's data already).</summary>
    public event Action? FolderChanged;

    public static bool CanOpenFolders => OperatingSystem.IsWindows();

    public DataFolderUse Use()
    {
        var folder = DataFolder;
        var photos = DataFolders.Size(folder, DataFolders.ProductsFolderName);
        var plans = DataFolders.Size(folder, DataFolders.PlansFolderName);
        var products = Directory.Exists(ProductsFolder) ? Directory.EnumerateDirectories(ProductsFolder).Count() : 0;
        var postersFolder = DataFolders.Posters(folder);
        var posters = Directory.Exists(postersFolder) ? Directory.EnumerateDirectories(postersFolder).Count(PosterStore.IsPosterFolder) : 0;
        return new DataFolderUse(products, photos.Files, photos.Bytes, plans.Files, plans.Bytes, posters, DataFolderMover.FreeBytes(folder));
    }

    /// <summary>The drives on this PC that can hold the data, with their free space.</summary>
    public IReadOnlyList<DriveChoice> Drives()
    {
        var drives = new List<DriveChoice>();
        foreach (var drive in DriveInfo.GetDrives())
        {
            try
            {
                if (!drive.IsReady || drive.DriveType is not (DriveType.Fixed or DriveType.Removable) || drive.TotalSize < MinimumDriveBytes || IsSystemMount(drive.RootDirectory.FullName))
                {
                    continue;
                }

                var label = string.IsNullOrWhiteSpace(drive.VolumeLabel) || drive.VolumeLabel == drive.RootDirectory.FullName ? "" : drive.VolumeLabel;
                drives.Add(new DriveChoice(drive.RootDirectory.FullName, label, drive.AvailableFreeSpace, drive.TotalSize, drive.DriveType == DriveType.Removable));
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // A drive that is not ready or not ours to read.
            }
        }

        return drives.OrderBy(d => d.Root, StringComparer.OrdinalIgnoreCase).ToList();
    }

    public DataFolderCheck Check(string folder) => DataFolderMover.Check(DataFolder, folder);

    /// <summary>
    /// Makes <paramref name="folder"/> the data folder. The data moves there unless the folder already holds the
    /// add-on's data, which is then used as it is. Returns what was done, in words.
    /// </summary>
    /// <param name="busy">What is writing to the data folder now (photos or a poster's artwork being made), or null.
    /// Asked once the move has begun, so no new work can start between the answer and the move.</param>
    public async Task<string> ChangeAsync(string folder, Func<string?> busy, IProgress<string>? progress)
    {
        if (!await _moving.WaitAsync(0))
        {
            throw new InvalidOperationException("The data is being moved already.");
        }

        var before = DataFolder;
        try
        {
            if (busy() is { } work)
            {
                throw new InvalidOperationException(work + " Wait until it is done, then change the folder.");
            }

            var check = Check(folder);
            if (!check.Ok)
            {
                throw new InvalidOperationException(check.Problem);
            }

            if (check.IsCurrent)
            {
                return "This is the folder in use already.";
            }

            void Use() => _settings.Save(new StorageSettings { DataFolder = check.Folder });
            if (check.HasData)
            {
                Use();
                return $"Now using the data already in {check.Folder}. The data in the old folder was left where it is.";
            }

            var move = await Task.Run(() => DataFolderMover.Move(DataFolder, check.Folder, Use, progress));
            var moved = move.Files == 0
                ? $"Photos, plans and posters will now be kept in {check.Folder}."
                : $"Moved {move.Files} files ({DataFolderMover.Describe(move.Bytes)}). Photos, plans and posters are now kept in {check.Folder}.";
            return move.Warning is null ? moved : moved + " " + move.Warning;
        }
        finally
        {
            _moving.Release();
            if (DataFolder != before)
            {
                FolderChanged?.Invoke();
            }
        }
    }

    /// <summary>Opens the folder in File Explorer, on this PC. Windows only.</summary>
    public void Open(string folder)
    {
        if (!CanOpenFolders)
        {
            throw new PlatformNotSupportedException("Opening folders works on Windows only.");
        }

        Directory.CreateDirectory(folder);
        Process.Start(new ProcessStartInfo("explorer.exe", "\"" + folder + "\"") { UseShellExecute = true })?.Dispose();
    }

    private static bool IsSystemMount(string root) =>
        !OperatingSystem.IsWindows()
        && root != "/"
        && new[] { "/proc", "/sys", "/dev", "/run", "/etc", "/boot", "/snap", "/var/lib" }.Any(system => root.StartsWith(system, StringComparison.Ordinal));
}
