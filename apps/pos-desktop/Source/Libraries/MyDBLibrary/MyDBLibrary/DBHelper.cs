using System;
using System.Data;

namespace MyDBLibrary
{
	// Token: 0x02000008 RID: 8
	public class DBHelper
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000021BC File Offset: 0x000003BC
		public static string GetMasterConnectionString()
		{
			string text = "103.160.106.35,1433";
			string text2 = "sa";
			string text3 = "82MnuF5DzWy2";
			string text4 = "master";
			return string.Concat(new string[]
			{
				string.Format("Server={0};", text),
				string.Format("User ID={0};", text2),
				string.Format("Password={0};", text3),
				"Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;",
				string.Format("Initial Catalog={0};", text4)
			});
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002238 File Offset: 0x00000438
		public string RaintechMaster_Online_connection()
		{
			string text = "103.160.106.35,1433";
			string text2 = "sa";
			string text3 = "82MnuF5DzWy2";
			string text4 = "RaintechMaster_DB";
			return string.Concat(new string[]
			{
				string.Format("Server={0};", text),
				string.Format("Initial Catalog={0};", text4),
				string.Format("User ID={0};", text2),
				string.Format("Password={0};", text3),
				"Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
			});
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022B4 File Offset: 0x000004B4
		public static string GetOnlineConnectionString(string strOnlinedb_Name)
		{
			string text = "103.160.106.35,1433";
			string text2 = "sa";
			string text3 = "82MnuF5DzWy2";
			return string.Concat(new string[]
			{
				string.Format("Server={0};", text),
				string.Format("Initial Catalog={0};", strOnlinedb_Name),
				string.Format("User ID={0};", text2),
				string.Format("Password={0};", text3),
				"Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
			});
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002328 File Offset: 0x00000528
		public string UpdateConnectionStringFromGrid(string newDBName)
		{
			string text = "103.160.106.35,1433";
			string text2 = "sa";
			string text3 = "82MnuF5DzWy2";
			return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;User ID={2};Password={3};MultipleActiveResultSets=True;Max Pool Size=500", new object[] { text, newDBName, text2, text3 });
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002370 File Offset: 0x00000570
		public static DataTable GetWhatsAppApi_ftpConfig()
		{
			DataTable dataTable = new DataTable("WappApi");
			dataTable.Columns.Add("c1", typeof(string));
			dataTable.Columns.Add("WApi", typeof(string));
			dataTable.Columns.Add("FtpUrl", typeof(string));
			dataTable.Columns.Add("FtpUser", typeof(string));
			dataTable.Columns.Add("FtpPassword", typeof(string));
			dataTable.Columns.Add("FileUrl", typeof(string));
			string text = "91";
			string text2 = "fg";
			string text3 = "ftp://143.198.176.86:39127/";
			string text4 = "mydaddye";
			string text5 = "LrhPAFhsi4eH7Xzk";
			string text6 = "https://www.daddye.in/reports/";
			dataTable.Rows.Add(new object[] { text, text2, text3, text4, text5, text6 });
			return dataTable;
		}
	}
}
