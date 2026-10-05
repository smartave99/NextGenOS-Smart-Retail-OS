using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace DevNetSR.Extension
{
	// Token: 0x02000011 RID: 17
	public class Utilities
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00004400 File Offset: 0x00002600
		public static bool IsFileReady(string filename)
		{
			bool flag2;
			try
			{
				bool flag = File.Exists(filename);
				if (flag)
				{
					using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
					{
						return inputStream.Length > 0L;
					}
				}
				flag2 = true;
			}
			catch (Exception)
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004464 File Offset: 0x00002664
		public static bool SaveConfiguration(string Language)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Devstroop Technologies\\DevNetSR");
			bool flag = key != null;
			bool flag2;
			if (flag)
			{
				key.SetValue("Language", Language);
				key.Close();
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000044AC File Offset: 0x000026AC
		public static string ReadConfiguration()
		{
			string result = null;
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Devstroop Technologies\\DevNetSR");
				bool flag = key != null;
				if (flag)
				{
					bool flag2 = key.GetValueNames().Contains("Language");
					if (flag2)
					{
						result = key.GetValue("Language").ToString();
					}
					key.Close();
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004524 File Offset: 0x00002724
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("abcdefghijklmnopqrstuvwxyz0123456789", length)
				select s[Utilities.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0400003A RID: 58
		private static Random random = new Random();
	}
}
