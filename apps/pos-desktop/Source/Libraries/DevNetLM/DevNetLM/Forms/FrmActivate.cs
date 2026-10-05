using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevNetLM.Classes;
using DevNetLM.Models;
using DevNetLM.Properties;
using FireSharp.Interfaces;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace DevNetLM.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class FrmActivate : Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000284B File Offset: 0x00000A4B
		public FrmActivate()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000286A File Offset: 0x00000A6A
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002874 File Offset: 0x00000A74
		private void btnPasteLKey_Click(object sender, EventArgs e)
		{
			try
			{
				string text = Clipboard.GetText();
				foreach (string text2 in text.Split(new char[] { '-' }))
				{
					bool flag = text2.Length != 6;
					if (flag)
					{
						throw new Exception();
					}
				}
				this.tBoxLKey1.Text = text.Split(new char[] { '-' })[0];
				this.tBoxLKey2.Text = text.Split(new char[] { '-' })[1];
				this.tBoxLKey3.Text = text.Split(new char[] { '-' })[2];
				this.tBoxLKey4.Text = text.Split(new char[] { '-' })[3];
				this.tBoxLKey5.Text = text.Split(new char[] { '-' })[4];
			}
			catch (Exception ex)
			{
				this.tBoxLKey1.Text = string.Empty;
				this.tBoxLKey2.Text = string.Empty;
				this.tBoxLKey3.Text = string.Empty;
				this.tBoxLKey4.Text = string.Empty;
				this.tBoxLKey5.Text = string.Empty;
				MessageBox.Show("License key is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000029E8 File Offset: 0x00000BE8
		public LicenseData GetRegistryData()
		{
			LicenseData licenseData = new LicenseData();
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\hdc\\hdc_" + Application.ProductName, true);
			bool flag = registryKey != null;
			if (flag)
			{
				licenseData.ProName = FrmActivate.Decrypt((string)registryKey.GetValue("PN"));
				licenseData.issuedby = FrmActivate.Decrypt((string)registryKey.GetValue("issuedby"));
				licenseData.issued_byid = FrmActivate.Decrypt((string)registryKey.GetValue("issued_byid"));
				licenseData.ProductId = FrmActivate.Decrypt((string)registryKey.GetValue("PID"));
				registryKey.Close();
			}
			return licenseData;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public static string Decrypt(string cipherText)
		{
			string text = "b14ca5898a4e4133bbce2ea2315a1916";
			byte[] array = new byte[16];
			bool flag = string.IsNullOrEmpty(cipherText);
			string text2;
			if (flag)
			{
				text2 = string.Empty;
			}
			else
			{
				byte[] array2 = Convert.FromBase64String(cipherText);
				using (Aes aes = Aes.Create())
				{
					aes.Key = Encoding.UTF8.GetBytes(text);
					aes.IV = array;
					using (ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV))
					{
						using (MemoryStream memoryStream = new MemoryStream(array2))
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
							{
								using (StreamReader streamReader = new StreamReader(cryptoStream))
								{
									text2 = streamReader.ReadToEnd();
								}
							}
						}
					}
				}
			}
			return text2;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002BC4 File Offset: 0x00000DC4
		public byte[] ImageToByteArray(Image image)
		{
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				image.Save(memoryStream, image.RawFormat);
				array = memoryStream.ToArray();
			}
			return array;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002C0C File Offset: 0x00000E0C
		private async void btnActivate_Click(object sender, EventArgs e)
		{
			base.Enabled = false;
			try
			{
				bool flag = this.tBoxLKey1.TextLength == 6 && this.tBoxLKey2.TextLength == 6 && this.tBoxLKey3.TextLength == 6 && this.tBoxLKey4.TextLength == 6 && this.tBoxLKey5.TextLength == 6;
				if (flag)
				{
					string LKey = string.Concat(new string[]
					{
						this.tBoxLKey1.Text,
						"-",
						this.tBoxLKey2.Text,
						"-",
						this.tBoxLKey3.Text,
						"-",
						this.tBoxLKey4.Text,
						"-",
						this.tBoxLKey5.Text
					});
					using (WebClient wc = new WebClient())
					{
						string dbPath = (GlobalValues.FirebaseRealTimeDBPath.EndsWith("/") ? GlobalValues.FirebaseRealTimeDBPath : (GlobalValues.FirebaseRealTimeDBPath + "/"));
						string text = await wc.DownloadStringTaskAsync(new Uri(dbPath + "licenses/" + LKey + ".json"));
						string json = text.Trim();
						text = null;
						if (json != null || json != "null" || json != "")
						{
							Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
							if (data["product_id"] == Utility.RBIN().ProductName.Replace(" ", "-").Trim().ToLower())
							{
								if (data["system_id"] == this.tBoxSystemId.Text)
								{
									if (bool.Parse(data["is_active"]))
									{
										string resellerid = "";
										DateTime valid_from = DateTime.ParseExact(data["valid_from"].Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture);
										DateTime valid_till = DateTime.ParseExact(data["valid_till"].Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture);
										if (valid_from <= DateTime.Now && DateTime.Now <= valid_till)
										{
											LicenseData lic = this.GetRegistryData();
											if (!string.IsNullOrEmpty(lic.ProName))
											{
												if (!(data["issued_by"] == "admin"))
												{
													if (!lic.ProductId.Contains(data["product_id"]) && !string.IsNullOrWhiteSpace(lic.ProductId))
													{
														MessageBox.Show("Please contact your administrator");
														Utility.DKEY();
														Application.Exit();
														return;
													}
													if (!lic.issuedby.Equals(data["issued_by"]) && !string.IsNullOrWhiteSpace(lic.issuedby))
													{
														MessageBox.Show("Please contact your administrator");
														Utility.DKEY();
														Application.Exit();
														return;
													}
													if (!lic.issued_byid.Equals(data["issued_by_id"]) && !string.IsNullOrWhiteSpace(lic.issued_byid))
													{
														MessageBox.Show("Please contact your administrator");
														Utility.DKEY();
														Application.Exit();
														return;
													}
												}
											}
											Utility.DKEY();
											Utility.WKEY(new LicenseData
											{
												ProName = data["product_name"],
												LKey = LKey,
												SYSID = data["system_id"],
												VFrom = valid_from,
												VTill = valid_till,
												TStamp = DateTime.Now,
												CusName = data["customer_name"],
												CusEmail = data["customer_email"],
												CusPhone = data["customer_phone"],
												ProductId = data["product_id"],
												issuedby = data["issued_by"],
												issued_byid = data["issued_by_id"]
											});
											resellerid = data["issued_by_id"].ToString();
											string text2 = await wc.DownloadStringTaskAsync(new Uri(dbPath + "resellers/" + resellerid + ".json"));
											string json2 = text2.Trim();
											text2 = null;
											Dictionary<string, string> data2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(json2);
											if (data2 == null)
											{
												Image image = this.pictureBox1.Image;
												Image img = this.MainDashPic.Image;
												byte[] imageBytes = this.ImageToByteArray(image);
												byte[] imageMainLogoBytes = this.ImageToByteArray(img);
												string base64String = Convert.ToBase64String(imageBytes);
												string Mainlogo = Convert.ToBase64String(imageMainLogoBytes);
												Utility.WKEY1(new LicenseData1
												{
													issued_byid1 = resellerid,
													LKey = LKey,
													issuedby1 = data["issued_by"].ToString(),
													company = "NextGen OS",
													name = "NextGen OS",
													email = "support@nextgenos.com",
													phone = "8606093110",
													address = "NextGen OS, India",
													state = "Kerala",
													country = "INDIA",
													is_active = true,
													Logo = base64String,
													MainLogo = Mainlogo
												});
												Utility.WKEYDuplicate(new LicenseData
												{
													ProName = data["product_name"],
													LKey = LKey,
													SYSID = data["system_id"],
													VFrom = valid_from,
													VTill = valid_till,
													TStamp = DateTime.Now,
													CusName = data["customer_name"],
													CusEmail = data["customer_email"],
													CusPhone = data["customer_phone"],
													ProductId = data["product_id"],
													issuedby = "admin",
													issued_byid = "Admin"
												});
												image = null;
												img = null;
												imageBytes = null;
												imageMainLogoBytes = null;
												base64String = null;
												Mainlogo = null;
											}
											else if (json2 != null)
											{
												Utility.WKEY1(new LicenseData1
												{
													issued_byid1 = resellerid,
													LKey = LKey,
													issuedby1 = data["issued_by"].ToString(),
													company = data2["company"].ToString(),
													name = data2["name"].ToString(),
													email = data2["email"].ToString(),
													phone = data2["phone"].ToString(),
													address = data2["address"].ToString(),
													state = data2["state"].ToString(),
													country = data2["country"].ToString(),
													is_active = Convert.ToBoolean(data2["is_active"].ToString()),
													Logo = data2["Logo"].ToString(),
													MainLogo = data2["MainLogo"].ToString()
												});
												Utility.WKEYDuplicate(new LicenseData
												{
													ProName = data["product_name"],
													LKey = LKey,
													SYSID = data["system_id"],
													VFrom = valid_from,
													VTill = valid_till,
													TStamp = DateTime.Now,
													CusName = data["customer_name"],
													CusEmail = data["customer_email"],
													CusPhone = data["customer_phone"],
													ProductId = data["product_id"],
													issuedby = data["issued_by"],
													issued_byid = data["issued_by_id"]
												});
											}
											MessageBox.Show("Software Activated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											this.flag = true;
											base.Close();
											lic = null;
											json2 = null;
											data2 = null;
										}
										else
										{
											Utility.DKEY();
											MessageBox.Show("License Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										resellerid = null;
									}
									else
									{
										Utility.DKEY();
										MessageBox.Show("License not Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									Utility.DKEY();
									MessageBox.Show("License not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								Utility.DKEY();
								MessageBox.Show("License not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							data = null;
						}
						else
						{
							Utility.DKEY();
							MessageBox.Show("License not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						dbPath = null;
						json = null;
					}
					LKey = null;
				}
				else
				{
					Utility.DKEY();
					MessageBox.Show("License not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch
			{
				MessageBox.Show("Failed, Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.Enabled = true;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C54 File Offset: 0x00000E54
		private void tBoxLKey1_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.tBoxLKey1.TextLength == 6;
			if (flag)
			{
				base.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002C88 File Offset: 0x00000E88
		private void tBoxLKey2_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.tBoxLKey2.TextLength == 6;
			if (flag)
			{
				base.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002CBC File Offset: 0x00000EBC
		private void tBoxLKey3_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.tBoxLKey3.TextLength == 6;
			if (flag)
			{
				base.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002CF0 File Offset: 0x00000EF0
		private void tBoxLKey4_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.tBoxLKey4.TextLength == 6;
			if (flag)
			{
				base.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002D24 File Offset: 0x00000F24
		private void tBoxLKey5_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.tBoxLKey1.TextLength == 6;
			if (flag)
			{
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002D48 File Offset: 0x00000F48
		private void FrmActivate_Load(object sender, EventArgs e)
		{
			base.ControlBox = false;
			List<string> list = new List<string>();
			foreach (object obj in Utility.HDS())
			{
				HardDrive hardDrive = (HardDrive)obj;
				list.Add(hardDrive.Model + "(" + hardDrive.SerialNo + ")");
			}
			FileVersionInfo fileVersionInfo = Utility.RBIN();
			this.valProductName.Text = fileVersionInfo.ProductName;
			this.valProductVersion.Text = fileVersionInfo.ProductVersion;
			this.valCompany.Text = fileVersionInfo.CompanyName;
			this.cBoxBindWith.DataSource = list;
			LicenseData licenseData = Utility.RKEY();
			bool flag = licenseData.LKey != null;
			if (flag)
			{
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\abc");
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002E4C File Offset: 0x0000104C
		private void cBoxBindWith_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tBoxSystemId.Text = Utility.CHKSM(this.cBoxBindWith.Text.Split(new char[] { '(' })[1].Replace(")", ""));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002E8C File Offset: 0x0000108C
		private void btnCopySystemId_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.tBoxSystemId.Text);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002EA0 File Offset: 0x000010A0
		private void btnTrial_Click(object sender, EventArgs e)
		{
			base.Enabled = false;
			try
			{
				Utility.WKEY(new LicenseData
				{
					ProName = Utility.RBIN().ProductName,
					LKey = "Trial",
					SYSID = this.tBoxSystemId.Text,
					VFrom = DateTime.Now,
					VTill = DateTime.Now.AddDays((double)GlobalValues.TrialDays),
					TStamp = DateTime.Now,
					CusName = "Trial",
					CusEmail = "Trial",
					CusPhone = "Trial",
					ProductId = Utility.RBIN().ProductName.Replace(" ", "-").Trim().ToLower()
				});
				MessageBox.Show("Trial version activated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.flag = true;
				base.Close();
			}
			catch
			{
				MessageBox.Show("Failed, Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.Enabled = true;
		}

		// Token: 0x04000022 RID: 34
		public bool flag = false;

		// Token: 0x04000023 RID: 35
		public static IFirebaseClient client;
	}
}
