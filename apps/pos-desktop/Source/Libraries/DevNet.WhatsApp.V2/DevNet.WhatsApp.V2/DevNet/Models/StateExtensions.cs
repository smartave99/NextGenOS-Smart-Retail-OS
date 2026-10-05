using System;

namespace DevNet.Models
{
	public static class StateExtensions
	{
		public static string GetString(this State me)
		{
			return me.ToString();
		}
	}
}
