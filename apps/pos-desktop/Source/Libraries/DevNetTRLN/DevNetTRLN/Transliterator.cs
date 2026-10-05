using System;
using System.Collections.Generic;

namespace DevNetTRLN
{
	public class Transliterator
	{
		private readonly Dictionary<string, string> vdMV2Cohu;

		public Transliterator()
		{
			vdMV2Cohu = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
			{
				{ "Hindi", "hi" },
				{ "Bengali", "bn" },
				{ "Gujarati", "gu" },
				{ "Marathi", "mr" },
				{ "Tamil", "ta" },
				{ "Telugu", "te" },
				{ "Kannada", "kn" },
				{ "Malayalam", "ml" },
				{ "Punjabi", "pa" }
			};
		}

		public List<string> GetSupportedLanguages()
		{
			return new List<string>(vdMV2Cohu.Keys);
		}

		public string Translate(string text, string language)
		{
			return text;
		}
	}
}
