using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevNet
{
	public class Response
	{
		[JsonProperty(PropertyName = "at")]
		public string At { get; set; }

		[JsonProperty(PropertyName = "error")]
		public string Error { get; set; }

		[JsonProperty(PropertyName = "input")]
		public string Input { get; set; }

		[JsonProperty(PropertyName = "result")]
		public string[] Result { get; set; }

		[JsonProperty(PropertyName = "success")]
		public bool Success { get; set; }

		public Response()
		{
			Success = true;
			Result = new string[0];
		}

		public static Response FromDictionary(Dictionary<string, object> dictionary)
		{
			Response res = new Response();
			if (dictionary != null)
			{
				if (dictionary.ContainsKey("at") && dictionary["at"] != null)
					res.At = dictionary["at"].ToString();
				if (dictionary.ContainsKey("error") && dictionary["error"] != null)
					res.Error = dictionary["error"].ToString();
				if (dictionary.ContainsKey("input") && dictionary["input"] != null)
					res.Input = dictionary["input"].ToString();
				if (dictionary.ContainsKey("success") && dictionary["success"] != null)
				{
					bool s;
					if (bool.TryParse(dictionary["success"].ToString(), out s))
						res.Success = s;
				}
			}
			return res;
		}
	}
}
