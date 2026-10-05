using System;
using System.Text.RegularExpressions;

namespace DevNet.Utils
{
	public class Tool
	{
		public Tool()
		{
		}

		public static string StripHTML(string input)
		{
			if (string.IsNullOrEmpty(input))
				return string.Empty;
			return Regex.Replace(input, "<.*?>", string.Empty);
		}
	}
}
