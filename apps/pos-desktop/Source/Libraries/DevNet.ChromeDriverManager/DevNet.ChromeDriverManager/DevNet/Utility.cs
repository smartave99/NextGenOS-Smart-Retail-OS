using System;
using System.Diagnostics;
using System.IO;

namespace DevNet
{
	public class Utility
	{
		public Utility()
		{
		}

		public static string GetGoogleChromeInstalledVersion()
		{
			return null;
		}

		public static void DestroyAllChromeDrivers()
		{
			try
			{
				Process[] processes = Process.GetProcessesByName("chromedriver");
				for (int i = 0; i < processes.Length; i++)
				{
					try
					{
						processes[i].Kill();
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		public static string ExecuteCommandSync(object command)
		{
			return null;
		}

		public static bool IsFileReady(string filename)
		{
			try
			{
				using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
				{
					return fs.Length > 0;
				}
			}
			catch
			{
				return false;
			}
		}

		public static void WaitForFileToBeReady(string filename, TimeSpan timeout)
		{
		}
	}
}
