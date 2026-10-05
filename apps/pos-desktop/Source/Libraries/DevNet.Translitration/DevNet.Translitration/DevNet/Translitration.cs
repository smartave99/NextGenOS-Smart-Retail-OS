using System;

namespace DevNet
{
	public class Translitration
	{
		public static Translitration Instance = new Translitration();

		public Translitration()
		{
		}

		public Response DoWork(string input, Language language)
		{
			return new Response
			{
				Input = input,
				Success = true,
				Result = new string[] { input }
			};
		}
	}
}
