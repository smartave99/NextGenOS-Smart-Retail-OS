using System;

namespace DevNet
{
	public class ChromeDriverManager
	{
		public static bool IS_INSTALLING { get; private set; }
		public static string LOCATION { get; set; }
		public static int? DOWNLOAD_PROGRESS_PERCENTAGE { get; private set; }
		public static string LATEST_VERSION { get; private set; }
		public static string INSTALLED_VERSION { get; private set; }

		public static void InstallSpecified(string version)
		{
		}

		public static void InstallLatest()
		{
		}

		public static void Uninstall()
		{
		}

		public ChromeDriverManager()
		{
		}
	}
}
