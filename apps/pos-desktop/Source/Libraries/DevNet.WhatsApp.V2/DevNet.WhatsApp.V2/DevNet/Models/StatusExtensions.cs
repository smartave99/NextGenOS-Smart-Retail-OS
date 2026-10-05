using System;

namespace DevNet.Models
{
	public static class StatusExtensions
	{
		public static string GetString(this Status me)
		{
			return me.ToString();
		}
	}
}
