using System;

namespace DevNet.Models
{
	public class Config
	{
		public string UserDataDirectory { get; set; }
		public bool EnableExtensions { get; set; }
		public bool Headless { get; set; }
		public bool HideCommandPromptWindow { get; set; }
		public int InitializationTimeout { get; set; }

		public static void InstallOrUpdateChrome()
		{
		}

		public Config()
		{
		}
	}
}
