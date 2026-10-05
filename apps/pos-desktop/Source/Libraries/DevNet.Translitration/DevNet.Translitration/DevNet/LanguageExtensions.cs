using System;

namespace DevNet
{
	public static class LanguageExtensions
	{
		public static string Code(this Language language)
		{
			switch (language)
			{
				case Language.Assamese: return "as";
				case Language.Bangla: return "bn";
				case Language.Boro: return "brx";
				case Language.Gujarati: return "gu";
				case Language.Hindi: return "hi";
				case Language.Kannada: return "kn";
				case Language.Kashmiri: return "ks";
				case Language.KonkaniGoan: return "kok";
				case Language.Maithili: return "mai";
				case Language.Malayalam: return "ml";
				case Language.Manipuri: return "mni";
				case Language.Marathi: return "mr";
				case Language.Nepali: return "ne";
				case Language.Oriya: return "or";
				case Language.Panjabi: return "pa";
				case Language.Sanskrit: return "sa";
				case Language.Sindhi: return "sd";
				case Language.Sinhala: return "si";
				case Language.Tamil: return "ta";
				case Language.Telugu: return "te";
				case Language.Urdu: return "ur";
				default: return "hi";
			}
		}

		public static Language FromName(string language)
		{
			Language result;
			if (Enum.TryParse<Language>(language, true, out result))
			{
				return result;
			}
			return Language.Hindi;
		}
	}
}
