using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DevNetLM.Classes
{
	// Token: 0x02000009 RID: 9
	internal class Encryption
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004254 File Offset: 0x00002454
		public static string ENC(string plainText)
		{
			byte[] array = new byte[16];
			byte[] array2;
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(Encryption.key);
				aes.IV = array;
				ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
						{
							streamWriter.Write(plainText);
						}
						array2 = memoryStream.ToArray();
					}
				}
			}
			return Convert.ToBase64String(array2);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004350 File Offset: 0x00002550
		public static string DEC(string cipherText)
		{
			byte[] array = new byte[16];
			byte[] array2 = Convert.FromBase64String(cipherText);
			string text;
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(Encryption.key);
				aes.IV = array;
				ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream(array2))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader(cryptoStream))
						{
							text = streamReader.ReadToEnd();
						}
					}
				}
			}
			return text;
		}

		// Token: 0x0400003D RID: 61
		public static string key = "b14ca5898a4e4133bbce2ea2315a1916";
	}
}
