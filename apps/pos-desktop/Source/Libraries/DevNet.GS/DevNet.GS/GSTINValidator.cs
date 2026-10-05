using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevNet.GS
{
	public class GSTINValidator
	{
		public GSTINValidator()
		{
		}

		public async Task<Dictionary<string, string>> ValidateGSTINAsync(string gstin)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			return await Task.FromResult(dict);
		}
	}
}
