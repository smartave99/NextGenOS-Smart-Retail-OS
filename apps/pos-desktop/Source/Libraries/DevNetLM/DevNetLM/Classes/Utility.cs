using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevNetLM.Models;
using Microsoft.Win32;

namespace DevNetLM.Classes
{
	// Token: 0x0200000B RID: 11
	internal class Utility
	{
		// Token: 0x06000065 RID: 101 RVA: 0x0000447C File Offset: 0x0000267C
		public static LicenseData RKEY()
		{
			LicenseData licenseData = new LicenseData();
			LicenseData1 licenseData2 = new LicenseData1();
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\" + Utility.RBIN().ProductName);
				if (registryKey == null && Utility.RBIN().ProductName != "Smart Retail OS")
				{
					registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\Smart Retail OS");
				}
				if (registryKey == null)
				{
					registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\SmartAvenue99 POS");
				}
				bool flag = registryKey != null;
				if (flag)
				{
					bool flag2 = registryKey.GetValueNames().Contains("LK");
					if (flag2)
					{
						try
						{
							licenseData = new LicenseData
							{
								ProName = Encryption.DEC(registryKey.GetValue("PN").ToString()),
								LKey = Encryption.DEC(registryKey.GetValue("LK").ToString()),
								SYSID = Encryption.DEC(registryKey.GetValue("SID").ToString()),
								VFrom = DateTime.ParseExact(Encryption.DEC(registryKey.GetValue("VF").ToString()).Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture),
								VTill = DateTime.ParseExact(Encryption.DEC(registryKey.GetValue("VT").ToString()).Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture),
								TStamp = DateTime.ParseExact(Encryption.DEC(registryKey.GetValue("TS").ToString()).Replace(".", ":"), GlobalValues.DateTimeFormat, CultureInfo.InvariantCulture),
								CusName = Encryption.DEC(registryKey.GetValue("CN").ToString()),
								CusEmail = Encryption.DEC(registryKey.GetValue("CE").ToString()),
								CusPhone = Encryption.DEC(registryKey.GetValue("CP").ToString()),
								ProductId = Encryption.DEC(registryKey.GetValue("PID").ToString()),
								issuedby = Encryption.DEC(registryKey.GetValue("issuedby").ToString()),
								issued_byid = Encryption.DEC(registryKey.GetValue("issued_byid").ToString())
							};
							LicenseData1 licenseData3 = new LicenseData1();
							licenseData3.company = Encryption.DEC(registryKey.GetValue("c").ToString());
							licenseData3.name = Encryption.DEC(registryKey.GetValue("n").ToString());
							licenseData3.email = Encryption.DEC(registryKey.GetValue("e").ToString());
							licenseData3.phone = Encryption.DEC(registryKey.GetValue("P").ToString());
							licenseData3.address = Encryption.DEC(registryKey.GetValue("a").ToString());
							licenseData3.state = Encryption.DEC(registryKey.GetValue("s").ToString());
							licenseData3.country = Encryption.DEC(registryKey.GetValue("cou").ToString());
							licenseData3.Logo = Encryption.DEC(registryKey.GetValue("Logo").ToString());
							licenseData3.MainLogo = Encryption.DEC(registryKey.GetValue("MainLogo").ToString());
						}
						catch
						{
						}
					}
					registryKey.Close();
				}
			}
			catch
			{
			}
			return licenseData;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000047E4 File Offset: 0x000029E4
		public static void WKEY1(LicenseData1 _licDat1)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\" + Utility.RBIN().ProductName, true);
			bool flag = _licDat1.LKey != null;
			if (flag)
			{
				try
				{
					registryKey.SetValue("c", Encryption.ENC(_licDat1.company));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("n", Encryption.ENC(_licDat1.name));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("e", Encryption.ENC(_licDat1.email));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("p", Encryption.ENC(_licDat1.phone));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("a", Encryption.ENC(_licDat1.address));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("s", Encryption.ENC(_licDat1.state));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("cou", Encryption.ENC(_licDat1.country));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("Logo", Encryption.ENC(_licDat1.Logo));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("MainLogo", Encryption.ENC(_licDat1.MainLogo));
				}
				catch
				{
				}
				registryKey.Close();
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000049C8 File Offset: 0x00002BC8
		public static void WKEYDuplicate(LicenseData _licDat)
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\hdc\\hdc_" + Utility.RBIN().ProductName);
			bool flag = _licDat.LKey != null;
			if (flag)
			{
				try
				{
					registryKey.SetValue("PN", Encryption.ENC(_licDat.ProName));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("LK", Encryption.ENC(_licDat.LKey));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("SID", Encryption.ENC(_licDat.SYSID));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("VF", Encryption.ENC(_licDat.VFrom.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("VT", Encryption.ENC(_licDat.VTill.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("TS", Encryption.ENC(_licDat.TStamp.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CN", Encryption.ENC(_licDat.CusName));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CE", Encryption.ENC(_licDat.CusEmail));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CP", Encryption.ENC(_licDat.CusPhone));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("PID", Encryption.ENC(_licDat.ProductId));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("issuedby", Encryption.ENC(_licDat.issuedby));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("issued_byid", Encryption.ENC(_licDat.issued_byid));
				}
				catch
				{
				}
				registryKey.Close();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004C84 File Offset: 0x00002E84
		public static void WKEY(LicenseData _licDat)
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\SLM\\" + Utility.RBIN().ProductName);
			bool flag = _licDat.LKey != null;
			if (flag)
			{
				try
				{
					registryKey.SetValue("PN", Encryption.ENC(_licDat.ProName));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("LK", Encryption.ENC(_licDat.LKey));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("SID", Encryption.ENC(_licDat.SYSID));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("VF", Encryption.ENC(_licDat.VFrom.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("VT", Encryption.ENC(_licDat.VTill.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("TS", Encryption.ENC(_licDat.TStamp.ToString(GlobalValues.DateTimeFormat).Replace(".", ":")));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CN", Encryption.ENC(_licDat.CusName));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CE", Encryption.ENC(_licDat.CusEmail));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("CP", Encryption.ENC(_licDat.CusPhone));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("PID", Encryption.ENC(_licDat.ProductId));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("issuedby", Encryption.ENC(_licDat.issuedby));
				}
				catch
				{
				}
				try
				{
					registryKey.SetValue("issued_byid", Encryption.ENC(_licDat.issued_byid));
				}
				catch
				{
				}
				registryKey.Close();
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004F40 File Offset: 0x00003140
		public static void DKEY()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\" + Utility.RBIN().ProductName, true);
				bool flag = registryKey != null;
				if (flag)
				{
					try
					{
						registryKey.DeleteValue("PN");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("LK");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("SID");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("VF");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("VT");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("TS");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("CN");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("CE");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("CP");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("PID");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("issuedby");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("issued_byid");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("c");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("n");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("e");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("p");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("a");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("s");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("cou");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("Logo");
					}
					catch
					{
					}
					try
					{
						registryKey.DeleteValue("MainLogo");
					}
					catch
					{
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005374 File Offset: 0x00003574
		public static void DKEYNew()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SLM\\" + Utility.RBIN().ProductName, true);
				bool flag = registryKey != null;
				if (flag)
				{
					MessageBox.Show(Utility.RBIN().ProductName);
					Registry.LocalMachine.DeleteSubKeyTree("Software\\SLM\\" + Utility.RBIN().ProductName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005400 File Offset: 0x00003600
		public static FileVersionInfo RBIN()
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			return FileVersionInfo.GetVersionInfo(entryAssembly.Location);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005424 File Offset: 0x00003624
		public static ArrayList HDS()
		{
			ArrayList arrayList = new ArrayList();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				HardDrive hardDrive = new HardDrive();
				hardDrive.Model = managementObject["Model"].ToString().Trim();
				hardDrive.Type = managementObject["InterfaceType"].ToString().Trim();
				bool flag = managementObject["SerialNumber"] == null;
				if (flag)
				{
					hardDrive.SerialNo = "None";
				}
				else
				{
					hardDrive.SerialNo = managementObject["SerialNumber"].ToString().Trim();
				}
				arrayList.Add(hardDrive);
			}
			return arrayList;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000551C File Offset: 0x0000371C
		public static string CHKSM(string input)
		{
			string text;
			using (MD5 md = MD5.Create())
			{
				text = BitConverter.ToString(md.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", string.Empty);
			}
			return text;
		}
	}
}
