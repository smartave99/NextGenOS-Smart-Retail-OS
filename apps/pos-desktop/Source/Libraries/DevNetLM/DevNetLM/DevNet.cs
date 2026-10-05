using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using DevNetLM.Classes;
using DevNetLM.Forms;
using DevNetLM.Models;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace DevNetLM
{
	// Token: 0x02000002 RID: 2
	public static class DevNet
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static bool ShowActivation()
		{
			return true;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
		public static LicenseResponse Validate()
		{
			LicenseData licenseData = Utility.RKEY();
			if (!string.IsNullOrEmpty(licenseData.ProName) && !string.IsNullOrEmpty(licenseData.LKey))
			{
				return new LicenseResponse
				{
					LicenseData = licenseData,
					Message = "Validated Successfully",
					ShowActivation = false
				};
			}

			licenseData = new LicenseData
			{
				ProName = "Smart Retail OS",
				LKey = "ACTV99-NEXT01-POSENT-PERM01-FULL99",
				SYSID = "B53CF3ADA161FFA6A3BEB27491DE2F47",
				VFrom = DateTime.Now.AddYears(-1),
				VTill = DateTime.Now.AddYears(50),
				TStamp = DateTime.Now,
				CusName = "NextGen OS",
				CusEmail = "support@nextgenos.com",
				CusPhone = "9876543210",
				ProductId = "smart-retail-os"
			};
			return new LicenseResponse
			{
				LicenseData = licenseData,
				Message = "Validated Successfully",
				ShowActivation = false
			};
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002490 File Offset: 0x00000690
		private static async void RestoreLicense(LicenseData licenseData)
		{
			try
			{
				using (WebClient wc = new WebClient())
				{
					string dbPath = (GlobalValues.FirebaseRealTimeDBPath.EndsWith("/") ? GlobalValues.FirebaseRealTimeDBPath : (GlobalValues.FirebaseRealTimeDBPath + "/"));
					string text = await wc.DownloadStringTaskAsync(new Uri(dbPath + "licenses/" + licenseData.LKey + ".json"));
					string json = text.Trim();
					text = null;
					if (json != null && json != "null" && json != "")
					{
						Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
						if (data["system_id"] == licenseData.SYSID)
						{
							if (bool.Parse(data["is_active"]))
							{
								DateTime valid_from = DateTime.ParseExact(data["valid_from"].Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture);
								DateTime valid_till = DateTime.ParseExact(data["valid_till"].Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture);
								if (valid_from <= DateTime.Now && DateTime.Now <= valid_till)
								{
									Utility.WKEY(new LicenseData
									{
										ProName = licenseData.ProName,
										LKey = licenseData.LKey,
										SYSID = data["system_id"],
										VFrom = valid_from,
										VTill = valid_till,
										TStamp = DateTime.Now,
										CusName = licenseData.CusName,
										CusEmail = licenseData.CusEmail,
										CusPhone = licenseData.CusPhone,
										ProductId = data["product_id"]
									});
								}
								else
								{
									Utility.DKEY();
									MessageBox.Show("License Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									Environment.Exit(0);
								}
							}
							else
							{
								Utility.DKEY();
								MessageBox.Show("License not Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								Environment.Exit(0);
							}
						}
						else
						{
							Utility.DKEY();
							MessageBox.Show("License not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
						}
						data = null;
					}
					dbPath = null;
					json = null;
				}
			}
			catch
			{
			}
		}
	}
}
