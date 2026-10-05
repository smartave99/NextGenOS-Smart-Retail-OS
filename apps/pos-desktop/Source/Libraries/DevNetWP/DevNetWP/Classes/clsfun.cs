using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace DevNetWP.Classes
{
	// Token: 0x02000007 RID: 7
	public class clsfun
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002250 File Offset: 0x00000450
		public Dictionary<string, object> ReadCS()
		{
			List<string> list = new List<string>();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string text = directoryName + "\\TempDBSettings.dat";
				using (StreamReader streamReader = new StreamReader(text))
				{
					string text2;
					while ((text2 = streamReader.ReadLine()) != null)
					{
						list.Add(text2);
					}
					string text3 = string.Concat(new string[]
					{
						"Data Source= ",
						list[1],
						";Initial Catalog= ",
						list[0],
						";Integrated Security=SSPI;"
					});
					dictionary["success"] = true;
					dictionary["result"] = text3.Trim();
				}
			}
			catch (Exception ex)
			{
				dictionary["success"] = false;
				dictionary["message"] = ex.Message;
			}
			return dictionary;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002370 File Offset: 0x00000570
		public SqlConnection GetConnection(string cs)
		{
			try
			{
				GlobalVariables.con = new SqlConnection();
				GlobalVariables.con.ConnectionString = cs;
				GlobalVariables.con.Open();
			}
			catch (Exception ex)
			{
				GlobalVariables.con = null;
			}
			return GlobalVariables.con;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000023C8 File Offset: 0x000005C8
		public string CloseConnection(string cs)
		{
			string text = string.Empty;
			try
			{
				bool flag = GlobalVariables.con != null;
				if (flag)
				{
					GlobalVariables.con.Close();
				}
			}
			catch (Exception ex)
			{
				text = "-1";
			}
			return text;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002418 File Offset: 0x00000618
		public DataTable ExecDataTable(string cmdText)
		{
			string empty = string.Empty;
			DataTable dataTable = null;
			try
			{
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdText, GlobalVariables.con))
				{
					dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				dataTable = null;
			}
			return dataTable;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002488 File Offset: 0x00000688
		public DataSet ExecDataSet(string cmdText, string tmptblName = "a")
		{
			DataSet dataSet = null;
			try
			{
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdText, GlobalVariables.con))
				{
					dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, tmptblName);
				}
			}
			catch (Exception ex)
			{
				dataSet = null;
			}
			finally
			{
				dataSet.Dispose();
			}
			return dataSet;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002508 File Offset: 0x00000708
		public Dictionary<string, object> ExecNonQuery(string cmdText, bool withTran = false)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			SqlTransaction sqlTransaction = null;
			try
			{
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, GlobalVariables.con, sqlTransaction))
				{
					bool flag = !withTran;
					int num;
					if (flag)
					{
						num = sqlCommand.ExecuteNonQuery();
					}
					else
					{
						sqlTransaction = GlobalVariables.con.BeginTransaction();
						sqlCommand.CommandTimeout = 7000;
						num = sqlCommand.ExecuteNonQuery();
						sqlTransaction.Commit();
					}
					dictionary["success"] = true;
					dictionary["result"] = num;
				}
			}
			catch (Exception ex)
			{
				sqlTransaction.Rollback();
				dictionary["success"] = false;
				dictionary["message"] = ex.Message;
			}
			finally
			{
				sqlTransaction.Dispose();
			}
			return dictionary;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000260C File Offset: 0x0000080C
		public Dictionary<string, object> ExecScalarStr(string cmdText)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			try
			{
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, GlobalVariables.con))
				{
					dictionary["success"] = true;
					dictionary["result"] = (string)sqlCommand.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				dictionary["success"] = false;
				dictionary["result"] = ex.Message;
			}
			return dictionary;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026C4 File Offset: 0x000008C4
		public int ExecScalarInt(string cmdText)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(this.ExecScalarStr(cmdText));
			}
			catch (Exception)
			{
			}
			return num;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002700 File Offset: 0x00000900
		public decimal ExecScalarDec(string cmdText)
		{
			decimal num = 0m;
			try
			{
				num = Convert.ToDecimal(this.ExecScalarStr(cmdText));
			}
			catch (Exception)
			{
			}
			return num;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002744 File Offset: 0x00000944
		public int ToInt(object Val)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(Convert.ToDecimal(Val));
			}
			catch (Exception)
			{
			}
			return num;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002780 File Offset: 0x00000980
		public DataTable FillDropDownList(object ddl, string cmdText, string sTextField, string sValueField, string sDefaultValue)
		{
			DataTable dataTable = null;
			try
			{
				dataTable = this.ExecDataTable(cmdText);
				bool flag = sDefaultValue == "";
				if (flag)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = 0;
					dataRow[1] = sDefaultValue;
					dataTable.Rows.InsertAt(dataRow, 0);
				}
			}
			catch (Exception)
			{
				dataTable = null;
			}
			return dataTable;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000027F8 File Offset: 0x000009F8
		public string ExecScalarStr(object Val)
		{
			string text = string.Empty;
			try
			{
				text = Val.ToString();
			}
			catch (Exception ex)
			{
				text = "-1";
			}
			return text;
		}
	}
}
