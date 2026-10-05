using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

// Every public method returns early unless this is Windows, where these APIs exist.
#pragma warning disable CA1416

namespace SmartRetail.AI.Data
{
    /// <summary>Reads this Windows PC for <see cref="PosDatabaseFinder"/>: running programs, install folders
    /// recorded in the registry, and SQL Server instances. It only reads, and finds nothing on other systems.</summary>
    public sealed class WindowsPosMachine : IPosMachine
    {
        private const int ProcessQueryLimitedInformation = 0x1000;

        private const string SqlInstancesKey = @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL";

        private const string UninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

        /// <summary>Vendors whose registry keys never hold the POS, skipped to keep the search quick.</summary>
        private static readonly string[] SkippedVendors = { "Classes", "Clients", "Microsoft", "Policies", "RegisteredApplications", "WOW6432Node" };

        private static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

        public string MachineName => Environment.MachineName;

        public IEnumerable<string> RunningProgramFolders()
        {
            var folders = new List<string>();
            if (!IsWindows)
            {
                return folders;
            }

            Process[] processes;
            try
            {
                processes = Process.GetProcesses();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is System.ComponentModel.Win32Exception)
            {
                return folders;
            }

            foreach (var process in processes)
            {
                using (process)
                {
                    AddFolderOf(folders, ImagePath(process));
                }
            }

            return folders.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public IEnumerable<string> InstalledProgramFolders()
        {
            var folders = new List<string>();
            if (!IsWindows)
            {
                return folders;
            }

            foreach (var root in RegistryRoots())
            {
                using (root)
                {
                    // The POS installer (Advanced Installer) records Software\<Company>\<Product> "Path".
                    using (var software = OpenSubKey(root, "SOFTWARE"))
                    {
                        foreach (var vendor in SubKeyNames(software).Where(name => !SkippedVendors.Contains(name, StringComparer.OrdinalIgnoreCase)))
                        {
                            using (var vendorKey = OpenSubKey(software, vendor))
                            {
                                foreach (var product in SubKeyNames(vendorKey))
                                {
                                    using (var productKey = OpenSubKey(vendorKey, product))
                                    {
                                        AddFolder(folders, ReadString(productKey, "Path"));
                                    }
                                }
                            }
                        }
                    }

                    using (var uninstall = OpenSubKey(root, UninstallKey))
                    {
                        foreach (var entry in SubKeyNames(uninstall))
                        {
                            using (var entryKey = OpenSubKey(uninstall, entry))
                            {
                                AddFolder(folders, ReadString(entryKey, "InstallLocation"));
                            }
                        }
                    }
                }
            }

            return folders.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public IEnumerable<string> FoldersToSearch()
        {
            var folders = new List<string>();
            if (!IsWindows)
            {
                return folders;
            }

            AddFolder(folders, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
            AddFolder(folders, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            AddFolder(folders, Environment.GetEnvironmentVariable("ProgramW6432"));
            try
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (drive.DriveType == DriveType.Fixed && drive.IsReady)
                    {
                        AddFolder(folders, drive.RootDirectory.FullName);
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
            }

            return folders.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public IEnumerable<string> SqlServerInstances()
        {
            var names = new List<string>();
            if (!IsWindows)
            {
                return names;
            }

            foreach (var view in new[] { RegistryView.Registry64, RegistryView.Registry32 })
            {
                using (var machine = OpenBaseKey(RegistryHive.LocalMachine, view))
                using (var instances = OpenSubKey(machine, SqlInstancesKey))
                {
                    if (instances != null)
                    {
                        try
                        {
                            names.AddRange(instances.GetValueNames());
                        }
                        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
                        {
                        }
                    }
                }
            }

            return names.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static IEnumerable<RegistryKey> RegistryRoots()
        {
            // 64-bit and 32-bit views of the machine settings, then the user's own installs.
            var roots = new[]
            {
                OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32),
                OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default),
            };
            return roots.Where(root => root != null);
        }

        private static RegistryKey OpenBaseKey(RegistryHive hive, RegistryView view)
        {
            try
            {
                return RegistryKey.OpenBaseKey(hive, view);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException || ex is ArgumentException)
            {
                return null;
            }
        }

        private static RegistryKey OpenSubKey(RegistryKey parent, string name)
        {
            if (parent == null)
            {
                return null;
            }

            try
            {
                return parent.OpenSubKey(name, writable: false);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
            {
                return null;
            }
        }

        private static IEnumerable<string> SubKeyNames(RegistryKey key)
        {
            if (key == null)
            {
                return Array.Empty<string>();
            }

            try
            {
                return key.GetSubKeyNames();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
            {
                return Array.Empty<string>();
            }
        }

        private static string ReadString(RegistryKey key, string name)
        {
            if (key == null)
            {
                return null;
            }

            try
            {
                return key.GetValue(name) as string;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
            {
                return null;
            }
        }

        private static string ImagePath(Process process)
        {
            var handle = IntPtr.Zero;
            try
            {
                // Limited rights work for programs of either bitness and for most elevated ones.
                handle = OpenProcess(ProcessQueryLimitedInformation, false, process.Id);
                if (handle == IntPtr.Zero)
                {
                    return null;
                }

                var buffer = new StringBuilder(1024);
                var size = buffer.Capacity;
                return QueryFullProcessImageName(handle, 0, buffer, ref size) ? buffer.ToString(0, size) : null;
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is EntryPointNotFoundException || ex is DllNotFoundException)
            {
                return null;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    CloseHandle(handle);
                }
            }
        }

        private static void AddFolderOf(List<string> folders, string path)
        {
            try
            {
                AddFolder(folders, string.IsNullOrWhiteSpace(path) ? null : Path.GetDirectoryName(path));
            }
            catch (Exception ex) when (ex is ArgumentException || ex is PathTooLongException)
            {
            }
        }

        private static void AddFolder(List<string> folders, string folder)
        {
            var value = PosDatabaseFinder.TidyFolder((folder ?? "").Trim('"'));
            if (value.Length > 0)
            {
                folders.Add(value);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int desiredAccess, bool inheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "QueryFullProcessImageNameW")]
        private static extern bool QueryFullProcessImageName(IntPtr process, int flags, StringBuilder exeName, ref int size);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);
    }
}
