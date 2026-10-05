using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevNetWP.Models;
using Newtonsoft.Json;

namespace DevNetWP.Classes
{
	// Token: 0x02000008 RID: 8
	public class clsWhatsapp
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002841 File Offset: 0x00000A41
		public clsWhatsapp()
		{
			this._clsfun = new clsfun();
			this._ApiRequestor = new ApiRequestor();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002878 File Offset: 0x00000A78
		private Dictionary<string, object> Result(bool success, string result, string message, string instance_id)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["success"] = success;
			dictionary["result"] = result;
			dictionary["message"] = message;
			dictionary["instance_id"] = instance_id;
			return dictionary;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000028CC File Offset: 0x00000ACC
		public Dictionary<string, object> CreateInstanceID(string endpoint)
		{
			string text = endpoint.Replace("createinstance.php", "create_instance");
			text = text.Split(new char[] { '=' }).First<string>();
			text += "=66ab4b4fc5f58";
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(text);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelinstance modelinstance = JsonConvert.DeserializeObject<modelinstance>((string)dictionary["result"]);
				bool flag2 = !modelinstance.Status.Equals("success");
				if (flag2)
				{
					throw new Exception((string)dictionary["message"]);
				}
				string text2 = "get_qrcode?instance_id=" + modelinstance.instance_id + "&access_token=66ab4b4fc5f58";
				Dictionary<string, object> qrcode = this.GetQRCode(text2, modelinstance.instance_id);
				bool flag3 = !(bool)qrcode["success"];
				if (flag3)
				{
					throw new Exception((string)qrcode["message"]);
				}
				qrcode["instance_id"] = modelinstance.instance_id;
				dictionary = this.Result(true, (string)qrcode["result"], (string)qrcode["message"], (string)qrcode["instance_id"]);
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [CreateInstanceID] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A90 File Offset: 0x00000C90
		private Dictionary<string, object> GetQRCode(string endpoint, string instanceID)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelqrcode modelqrcode = JsonConvert.DeserializeObject<modelqrcode>((string)dictionary["result"]);
				bool flag2 = !modelqrcode.Status.Equals("success");
				if (flag2)
				{
					throw new Exception((string)dictionary["message"]);
				}
				string text = "set_webhook?webhook_url=https://webhook.site/66ab4b4fc5f58&enable=true&instance_id=" + instanceID + "&access_token=66ab4b4fc5f58";
				Dictionary<string, object> dictionary2 = this.SetWebhook(text);
				bool flag3 = !(bool)dictionary2["success"];
				if (flag3)
				{
					throw new Exception((string)dictionary2["message"]);
				}
				dictionary = this.Result(true, modelqrcode.base64, modelqrcode.Message, "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [GetQRCode] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002BD0 File Offset: 0x00000DD0
		private Dictionary<string, object> SetWebhook(string endpoint)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				dictionary = this.Result(true, (string)dictionary["result"], "", "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [SetWebhook] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C84 File Offset: 0x00000E84
		public Dictionary<string, object> RebootInstance(string endpoint)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelinstance modelinstance = JsonConvert.DeserializeObject<modelinstance>((string)dictionary["result"]);
				bool flag2 = modelinstance.Status.Equals("success");
				if (!flag2)
				{
					throw new Exception(modelinstance.Message);
				}
				dictionary = this.Result(true, (string)dictionary["result"], "", "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [RebootInstance] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002D74 File Offset: 0x00000F74
		public Dictionary<string, object> ResetInstance(string endpoint)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelinstance modelinstance = JsonConvert.DeserializeObject<modelinstance>((string)dictionary["result"]);
				bool flag2 = modelinstance.Status.Equals("success");
				if (!flag2)
				{
					throw new Exception(modelinstance.Message);
				}
				dictionary = this.Result(true, (string)dictionary["result"], "", "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [ResetInstance] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002E64 File Offset: 0x00001064
		public Dictionary<string, object> Reconnect(string endpoint)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelinstance modelinstance = JsonConvert.DeserializeObject<modelinstance>((string)dictionary["result"]);
				bool flag2 = modelinstance.Status.Equals("success");
				if (!flag2)
				{
					throw new Exception(modelinstance.Message);
				}
				dictionary = this.Result(true, (string)dictionary["result"], "", "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [Reconnect] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002F54 File Offset: 0x00001154
		public Dictionary<string, object> SendMessage(string endpoint)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				dictionary = this._ApiRequestor.GetMEthods(endpoint);
				bool flag = (bool)dictionary["success"];
				if (!flag)
				{
					throw new Exception((string)dictionary["message"]);
				}
				modelinstance modelinstance = JsonConvert.DeserializeObject<modelinstance>((string)dictionary["result"]);
				bool flag2 = modelinstance.Status.Equals("success");
				if (!flag2)
				{
					throw new Exception(modelinstance.Message);
				}
				dictionary = this.Result(true, (string)dictionary["result"], "", "");
			}
			catch (Exception ex)
			{
				dictionary = this.Result(false, "", "Exeception Occured [SendMessage] " + ex.Message, "");
			}
			return dictionary;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003044 File Offset: 0x00001244
		public Dictionary<string, object> WhatsAppTextSender(string contactNo, string msg, string InstanceID)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			DataTable dataTable = new DataTable();
			string text = string.Empty;
			try
			{
				text = string.Concat(new string[] { "send?number=", contactNo, "&type=text&message=", msg, "&instance_id=", InstanceID, "&access_token=66ab4b4fc5f58" });
				dictionary = this._ApiRequestor.GetMEthods(text);
			}
			catch (Exception ex)
			{
			}
			return dictionary;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000030CC File Offset: 0x000012CC
		public Dictionary<string, object> WhatsAppTextWithFileSender(string contactNo, string msg, string url, string filename, string InstanceID)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				url = string.Concat(new string[]
				{
					"send?number=", contactNo, "&type=media&message=", msg, "&media_url=", url, "&filename=", filename, " & instance_id=", InstanceID,
					"&access_token=66ab4b4fc5f58"
				});
				dictionary = this._ApiRequestor.GetMEthods(url);
			}
			catch (Exception ex)
			{
			}
			return dictionary;
		}

		// Token: 0x0400000B RID: 11
		private static string connectionstring = string.Empty;

		// Token: 0x0400000C RID: 12
		private clsfun _clsfun = null;

		// Token: 0x0400000D RID: 13
		private ApiRequestor _ApiRequestor = null;

		// Token: 0x0400000E RID: 14
		private bool isDbConnected = false;
	}
}
