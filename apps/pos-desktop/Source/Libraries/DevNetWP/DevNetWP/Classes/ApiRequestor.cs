using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DevNetWP.Classes
{
	// Token: 0x02000006 RID: 6
	internal class ApiRequestor
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002138 File Offset: 0x00000338
		public Dictionary<string, object> GetMEthods(string url)
		{
			string text = GlobalVariables.baseurl + url;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				WebRequest webRequest = WebRequest.Create(text);
				webRequest.Method = "GET";
				using (WebResponse response = webRequest.GetResponse())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(responseStream))
						{
							dictionary["success"] = true;
							dictionary["result"] = streamReader.ReadToEnd();
						}
					}
				}
			}
			catch (Exception ex)
			{
				dictionary["success"] = false;
				dictionary["message"] = ex.Message;
			}
			return dictionary;
		}
	}
}
