using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DevNetFB
{
	// Token: 0x02000008 RID: 8
	public class FirebaseService
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000021B4 File Offset: 0x000003B4
		public FirebaseService()
		{
			this.dateFormats = new string[]
			{
				"yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "yyyy-MM-dd HH.mm.ss", "yyyy/MM/dd HH.mm.ss", "MM/dd/yyyy HH.mm.ss", "dd/MM/yyyy HH.mm.ss", "yyyy-MM-dd", "yyyy/MM/dd",
				"MM/dd/yyyy", "dd/MM/yyyy", "yyyyMMdd", "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-ddTHH:mm:ss", "yyyy/MM/ddTHH:mm:ss", "MM/dd/yyyyTHH:mm:ss", "dd/MM/yyyyTHH:mm:ss", "yyyy-MM-ddTHH:mm:ssZ",
				"yyyy/MM/ddTHH:mm:ssZ", "MM/dd/yyyyTHH:mm:ssZ", "dd/MM/yyyyTHH:mm:ssZ", "yyyy-MM-ddTHH:mm:ss.fffZ", "yyyy/MM/ddTHH:mm:ss.fffZ", "MM/dd/yyyyTHH:mm:ss.fffZ", "dd/MM/yyyyTHH:mm:ss.fffZ", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy HH.mm.ss", "dd-MM-yyyyTHH:mm:ss",
				"dd-MM-yyyyTHH:mm:ssZ", "dd-MM-yyyyTHH:mm:ss.fffZ"
			};
			this.inputDate = DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			this.conNFB = null;
			this.rdrNFB = null;
			this.csNFB = this.ReadCSNFB();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002320 File Offset: 0x00000520
		public void StartService()
		{
			DateTime.TryParseExact(this.inputDate, this.dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out this.parsedDate);
			this.lastupdate = this.parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
			this.InitializeConnectionString();
			this.intervalTimer = new Timer(5000.0);
			this.intervalTimer.Elapsed += this.PerformPeriodicTasks;
			this.intervalTimer.AutoReset = true;
			this.intervalTimer.Start();
			bool flag = this.CheckForInternetConnection();
			if (flag)
			{
				this.AutoUpdater();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023C4 File Offset: 0x000005C4
		public async void StartServiceStockUpdate()
		{
			this.InitializeConnectionString();
			bool flag = this.CheckForInternetConnection();
			if (flag)
			{
				await this.UploadStock();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002400 File Offset: 0x00000600
		public async Task UploadStock()
		{
			this.Config = new FirebaseConfig
			{
				AuthSecret = this.authSecretFB,
				BasePath = this.basePathFB
			};
			this.Client = new FirebaseClient(this.Config);
			try
			{
				DataTable dt = this.GetData();
				foreach (object obj in dt.Rows)
				{
					DataRow row = (DataRow)obj;
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_Name", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["ProductName"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_Barcode", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["Barcode"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_Category", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["Category"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_Stock", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["Qty"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_MRP", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["MRP"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_RPrice", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["SPrice"].ToString());
					await this.Client.SetAsync<string>(string.Format("comp/{0}/Stock/{1}/P_WPrice", this.companyid, RuntimeHelpers.GetObjectValue(row["Barcode"])), row["WPrice"].ToString());
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002444 File Offset: 0x00000644
		public DataTable GetData()
		{
			DataTable dataTable = new DataTable();
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				this.cmdNFB = new SqlCommand("SELECT RTRIM(ProductName) AS ProductName, RTRIM(SubCategoryName) AS Category, RTRIM(Temp_Stock.Barcode) AS Barcode, \r\n                                  RTRIM(Temp_Stock.MRP) AS MRP, RTRIM(Temp_Stock.SPrice) AS SPrice, RTRIM(Temp_Stock.WPrice) AS WPrice, Qty \r\n                                  FROM Temp_Stock \r\n                                  INNER JOIN Product ON Product.PID = Temp_Stock.ProductID \r\n                                  INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID \r\n                                  WHERE Product.Status = 'Yes'\r\n                                  ORDER BY ProductName", this.conNFB);
				this.cmdNFB.CommandTimeout = 0;
				using (SqlDataReader sqlDataReader = this.cmdNFB.ExecuteReader(CommandBehavior.CloseConnection))
				{
					dataTable.Load(sqlDataReader);
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error retrieving data", ex);
			}
			finally
			{
				bool flag = this.conNFB != null && this.conNFB.State == ConnectionState.Open;
				if (flag)
				{
					this.conNFB.Close();
				}
			}
			return dataTable;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002534 File Offset: 0x00000734
		public void StopService()
		{
			bool flag = this.autoUpdateTimer != null;
			if (flag)
			{
				this.autoUpdateTimer.Stop();
				this.autoUpdateTimer.Dispose();
			}
			bool flag2 = this.intervalTimer != null;
			if (flag2)
			{
				this.intervalTimer.Stop();
				this.intervalTimer.Dispose();
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002590 File Offset: 0x00000790
		private void AutoUpdater()
		{
			this.Config = new FirebaseConfig
			{
				AuthSecret = this.authSecretFB,
				BasePath = this.basePathFB
			};
			this.Client = new FirebaseClient(this.Config);
			try
			{
				this.Client.Set<string>(string.Format("comp/{0}/comp_name", this.companyid), this.TBoxCompName);
				this.Client.Set<string>(string.Format("comp/{0}/comp_address", this.companyid), this.TBoxAddress);
				this.Client.Set<string>(string.Format("comp/{0}/comp_state", this.companyid), this.TBoxState);
				this.Client.Set<string>(string.Format("comp/{0}/comp_gstin", this.companyid), this.TBoxGSTIN);
				this.Client.Set<string>(string.Format("comp/{0}/comp_contactno", this.companyid), this.TBoxContactNo);
				this.Client.Set<string>(string.Format("comp/{0}/comp_email", this.companyid), this.TBoxEmail);
				this.Client.Set<string>(string.Format("comp/{0}/comp_lastupdate", this.companyid), this.lastupdate);
				this.UploadStock();
			}
			catch (Exception ex)
			{
			}
			this.autoUpdateTimer = new Timer(10000.0);
			this.autoUpdateTimer.Elapsed += this.AutoUpdater_Event;
			this.autoUpdateTimer.AutoReset = true;
			this.autoUpdateTimer.Start();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002734 File Offset: 0x00000934
		private void AutoUpdater_Event(object sender, ElapsedEventArgs e)
		{
			this.todayData = new Dictionary<string, Dictionary<string, string>>();
			this.todayData.Add("Today's Sales", new Dictionary<string, string>
			{
				{ "title", "Today's Sales" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue1
				}
			});
			this.todayData.Add("Today's Purchase", new Dictionary<string, string>
			{
				{ "title", "Today's Purchase" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue2
				}
			});
			this.todayData.Add("Today's Sale Return", new Dictionary<string, string>
			{
				{ "title", "Today's Sale Return" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue3
				}
			});
			this.todayData.Add("Today's Purchase Return", new Dictionary<string, string>
			{
				{ "title", "Today's Purchase Return" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue4
				}
			});
			this.todayData.Add("Today's Receipt", new Dictionary<string, string>
			{
				{ "title", "Today's Receipt" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue5
				}
			});
			this.todayData.Add("Today's Payment", new Dictionary<string, string>
			{
				{ "title", "Today's Payment" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue6
				}
			});
			this.todayData.Add("Today's Service Advance", new Dictionary<string, string>
			{
				{ "title", "Today's Service Advance" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue7
				}
			});
			this.todayData.Add("Today's Service Amount", new Dictionary<string, string>
			{
				{ "title", "Today's Service Amount" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue8
				}
			});
			this.todayData.Add("Today's Income", new Dictionary<string, string>
			{
				{ "title", "Today's Income" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue9
				}
			});
			this.todayData.Add("Today's Expenses", new Dictionary<string, string>
			{
				{ "title", "Today's Expenses" },
				{ "color", "red" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue10
				}
			});
			this.todayData.Add("Today's Cash-In-Hand", new Dictionary<string, string>
			{
				{ "title", "Today's Cash-In-Hand" },
				{ "color", "blue" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue11
				}
			});
			this.todayData.Add("Today's Cash-In-Bank", new Dictionary<string, string>
			{
				{ "title", "Today's Cash-In-Bank" },
				{ "color", "dodger-blue" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue12
				}
			});
			this.todayData.Add("Today's Sundry Creditor", new Dictionary<string, string>
			{
				{ "title", "Today's Sundry Creditor" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue13
				}
			});
			this.todayData.Add("Today's Sundry Debtor", new Dictionary<string, string>
			{
				{ "title", "Today's Sundry Debtor" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue14
				}
			});
			this.todayData.Add("Today's Salary Advance", new Dictionary<string, string>
			{
				{ "title", "Today's Salary Advance" },
				{ "color", "hot-pink" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue15
				}
			});
			this.todayData.Add("Today's Salary Payment", new Dictionary<string, string>
			{
				{ "title", "Today's Salary Payment" },
				{ "color", "hot-pink" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue16
				}
			});
			this.todayData.Add("Today's Contra Entry", new Dictionary<string, string>
			{
				{ "title", "Today's Contra Entry" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue17
				}
			});
			this.todayData.Add("Today's Journal Entry", new Dictionary<string, string>
			{
				{ "title", "Today's Journal Entry" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.TodayValue18
				}
			});
			this.fyData = new Dictionary<string, Dictionary<string, string>>();
			this.fyData.Add("Total Sales", new Dictionary<string, string>
			{
				{ "title", "Total Sales" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue1
				}
			});
			this.fyData.Add("Total Purchase", new Dictionary<string, string>
			{
				{ "title", "Total Purchase" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue2
				}
			});
			this.fyData.Add("Total Sale Return", new Dictionary<string, string>
			{
				{ "title", "Total Sale Return" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue3
				}
			});
			this.fyData.Add("Total Purchase Return", new Dictionary<string, string>
			{
				{ "title", "Total Purchase Return" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue4
				}
			});
			this.fyData.Add("Total Receipt", new Dictionary<string, string>
			{
				{ "title", "Total Receipt" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue5
				}
			});
			this.fyData.Add("Total Payment", new Dictionary<string, string>
			{
				{ "title", "Total Payment" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue6
				}
			});
			this.fyData.Add("Total Service Advance", new Dictionary<string, string>
			{
				{ "title", "Total Service Advance" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue7
				}
			});
			this.fyData.Add("Total Service Amount", new Dictionary<string, string>
			{
				{ "title", "Total Service Amount" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue8
				}
			});
			this.fyData.Add("Total Income", new Dictionary<string, string>
			{
				{ "title", "Total Income" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue9
				}
			});
			this.fyData.Add("Total Expenses", new Dictionary<string, string>
			{
				{ "title", "Total Expenses" },
				{ "color", "red" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue10
				}
			});
			this.fyData.Add("Total Cash-In-Hand", new Dictionary<string, string>
			{
				{ "title", "Total Cash-In-Hand" },
				{ "color", "blue" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue11
				}
			});
			this.fyData.Add("Total Cash-In-Bank", new Dictionary<string, string>
			{
				{ "title", "Total Cash-In-Bank" },
				{ "color", "dodger-blue" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue12
				}
			});
			this.fyData.Add("Total Sundry Creditor", new Dictionary<string, string>
			{
				{ "title", "Total Sundry Creditor" },
				{ "color", "green" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue13
				}
			});
			this.fyData.Add("Total Sundry Debtor", new Dictionary<string, string>
			{
				{ "title", "Total Sundry Debtor" },
				{ "color", "coral" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue14
				}
			});
			this.fyData.Add("Total Salary Advance", new Dictionary<string, string>
			{
				{ "title", "Total Salary Advance" },
				{ "color", "hot-pink" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue15
				}
			});
			this.fyData.Add("Total Salary Payment", new Dictionary<string, string>
			{
				{ "title", "Total Salary Payment" },
				{ "color", "hot-pink" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue16
				}
			});
			this.fyData.Add("Total Contra Entry", new Dictionary<string, string>
			{
				{ "title", "Total Contra Entry" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue17
				}
			});
			this.fyData.Add("Total Journal Entry", new Dictionary<string, string>
			{
				{ "title", "Total Journal Entry" },
				{ "color", "dark-orange" },
				{
					"value",
					" " + this.CurSym + " " + this.FYValue18
				}
			});
			Task.Run(delegate
			{
				this.UploadData();
			});
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000034C8 File Offset: 0x000016C8
		private void UploadData()
		{
			bool flag = this.CheckForInternetConnection();
			if (flag)
			{
				try
				{
					this.Client.Set<Dictionary<string, Dictionary<string, string>>>(string.Format("comp/{0}/today/", this.companyid), this.todayData);
					this.Client.Set<Dictionary<string, Dictionary<string, string>>>(string.Format("comp/{0}/current_fy/", this.companyid), this.fyData);
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000354C File Offset: 0x0000174C
		private bool CheckForInternetConnection()
		{
			bool flag;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					using (webClient.OpenRead("http://www.google.com"))
					{
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000035C4 File Offset: 0x000017C4
		private void PerformPeriodicTasks(object sender, ElapsedEventArgs e)
		{
			this.CompanyCurrency();
			this.todaysale();
			this.todaypurchase();
			this.todaysalereturn();
			this.todaypurchasereturn();
			this.todayreceipt();
			this.todaypayment();
			this.todayserviceadvance();
			this.todayservicebilling();
			this.todayincome();
			this.todayexpenses();
			this.TodayContra();
			this.TodayJournal();
			this.cashinhand();
			this.bankinhand();
			this.SundryCreditor();
			this.SundryDebtor();
			this.SalaryAdvance();
			this.SalaryPayment();
			this.Totalsale();
			this.TotalPurchase();
			this.TotalSaleReturn();
			this.TotalPurchaseReturn();
			this.Totalreceipt();
			this.TotalPayment();
			this.TotalServiceAdvance();
			this.TotalServiceBilling();
			this.TotalIncome();
			this.TotalExpenses();
			this.TotalCashInHand();
			this.TotalCashInbank();
			this.TotalSundryCreditor();
			this.TotalSundryDebtor();
			this.TotalSalaryAdvance();
			this.TotalSalaryPayment();
			this.TotalContra();
			this.TotalJournal();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000036D8 File Offset: 0x000018D8
		private string ReadCSNFB()
		{
			string[] array = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\SQLSettings.dat");
			string[] array2 = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\TempDBSettings.dat");
			this.stNFB = array[0];
			this.st1NFB = array[1];
			this.st2NFB = array[2];
			this.st4NFB = array2[0];
			this.st3NFB = string.Concat(new string[] { "Data Source=", this.stNFB, ";Initial Catalog=", this.st4NFB, ";Integrated Security=False;User ID=", this.st1NFB, ";Password=", this.st2NFB, ";MultipleActiveResultSets=True", ";Max Pool Size=500" });
			return this.st3NFB;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000037AF File Offset: 0x000019AF
		private void InitializeConnectionString()
		{
			this.csNFB = this.ReadCSNFB();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000037C0 File Offset: 0x000019C0
		private void todaysale()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue1 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue1 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue1), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000038B8 File Offset: 0x00001AB8
		private void todaypurchase()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal)-Sum(PreviousDue),0) from Stock where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue2 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue2 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue2), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000039B0 File Offset: 0x00001BB0
		private void todaysalereturn()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from SalesReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue3 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue3 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue3), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003AA8 File Offset: 0x00001CA8
		private void todaypurchasereturn()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from PurchaseReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue4 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue4 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue4), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003BA0 File Offset: 0x00001DA0
		private void todayreceipt()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(Amount),0) from CreditCustomerPayment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue5 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue5 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue5), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003C98 File Offset: 0x00001E98
		private void todaypayment()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(Amount),0) from Payment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue6 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue6 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue6), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003D90 File Offset: 0x00001F90
		private void todayserviceadvance()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(AdvanceDeposit),0) from Service where Day(ServiceCreationDate)=Day(GetDate()) and Month(ServiceCreationDate)=Month(GetDate()) and Year(ServiceCreationDate)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue7 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue7 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue7), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003E88 File Offset: 0x00002088
		private void todayservicebilling()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo1 where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue8 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue8 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue8), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003F80 File Offset: 0x00002180
		private void todayincome()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from Income where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue9 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue9 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue9), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004078 File Offset: 0x00002278
		private void todayexpenses()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(GrandTotal),0) from Voucher where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue10 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue10 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue10), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004170 File Offset: 0x00002370
		private void cashinhand()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Cash Account' and Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue11 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue11 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue11), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004268 File Offset: 0x00002468
		private void bankinhand()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Bank Account' and Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue12 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue12 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue12), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004360 File Offset: 0x00002560
		private void SundryCreditor()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue13 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue13 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue13), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004458 File Offset: 0x00002658
		private void SundryDebtor()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(Debit),0)-IsNull(Sum(Credit),0) from CustomerLedgerBook where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue14 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue14 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue14), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004550 File Offset: 0x00002750
		private void SalaryAdvance()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(Amount),0) from AdvanceEntry where Day(Workingdate)=Day(GetDate()) and Month(Workingdate)=Month(GetDate()) and Year(Workingdate)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue15 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue15 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue15), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00004648 File Offset: 0x00002848
		private void SalaryPayment()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(NetPay),0) from EmployeePayment where Day(Paymentdate)=Day(GetDate()) and Month(Paymentdate)=Month(GetDate()) and Year(Paymentdate)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue16 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue16 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue16), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004740 File Offset: 0x00002940
		private void TodayContra()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(Amount),0) from Contra where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue17 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue17 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue17), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004838 File Offset: 0x00002A38
		private void TodayJournal()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "Select isNULL(Sum(Amt),0) from Journal where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.TodayValue18 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.TodayValue18 = Strings.Format(Math.Round(Conversion.Val(this.TodayValue18), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004930 File Offset: 0x00002B30
		private void TotalJournal()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Amt),0) from Journal where Date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue18 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue18 = Strings.Format(Math.Round(Conversion.Val(this.FYValue18), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004A9C File Offset: 0x00002C9C
		private void TotalContra()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Amount),0) from Contra where Date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue17 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue17 = Strings.Format(Math.Round(Conversion.Val(this.FYValue17), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004C08 File Offset: 0x00002E08
		private void Totalsale()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from invoiceinfo where invoicedate between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue1 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue1 = Strings.Format(Math.Round(Conversion.Val(this.FYValue1), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004D74 File Offset: 0x00002F74
		private void TotalPurchase()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal)-Sum(PreviousDue),0) from Stock where Date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue2 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue2 = Strings.Format(Math.Round(Conversion.Val(this.FYValue2), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004EE0 File Offset: 0x000030E0
		private void TotalSaleReturn()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from SalesReturn where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue3 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue3 = Strings.Format(Math.Round(Conversion.Val(this.FYValue3), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000504C File Offset: 0x0000324C
		private void TotalPurchaseReturn()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from PurchaseReturn where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue4 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue4 = Strings.Format(Math.Round(Conversion.Val(this.FYValue4), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000051B8 File Offset: 0x000033B8
		private void Totalreceipt()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Amount),0) from CreditCustomerPayment where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue5 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue5 = Strings.Format(Math.Round(Conversion.Val(this.FYValue5), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005324 File Offset: 0x00003524
		private void TotalPayment()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Amount),0) from Payment where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue6 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue6 = Strings.Format(Math.Round(Conversion.Val(this.FYValue6), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005490 File Offset: 0x00003690
		private void TotalServiceAdvance()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(AdvanceDeposit),0) from Service where ServiceCreationDate between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue7 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue7 = Strings.Format(Math.Round(Conversion.Val(this.FYValue7), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000055FC File Offset: 0x000037FC
		private void TotalServiceBilling()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "InvoiceDate").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "InvoiceDate").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue8 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue8 = Strings.Format(Math.Round(Conversion.Val(this.FYValue8), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005768 File Offset: 0x00003968
		private void TotalIncome()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from Income where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue9 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue9 = Strings.Format(Math.Round(Conversion.Val(this.FYValue9), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000058D4 File Offset: 0x00003AD4
		private void TotalExpenses()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(GrandTotal),0) from Voucher where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue10 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue10 = Strings.Format(Math.Round(Conversion.Val(this.FYValue10), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005A40 File Offset: 0x00003C40
		private void TotalCashInHand()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Cash Account' and date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue11 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue11 = Strings.Format(Math.Round(Conversion.Val(this.FYValue11), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005BAC File Offset: 0x00003DAC
		private void TotalCashInbank()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Bank Account' and date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue12 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue12 = Strings.Format(Math.Round(Conversion.Val(this.FYValue12), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005D18 File Offset: 0x00003F18
		private void TotalSundryCreditor()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT IsNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where date between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue13 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue13 = Strings.Format(Math.Round(Conversion.Val(this.FYValue13), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005E84 File Offset: 0x00004084
		private void TotalSundryDebtor()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT isNULL(Sum(Debit),0)-IsNull(Sum(Credit),0) from CustomerLedgerBook WHERE Date between @f1 and @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue14 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue14 = Strings.Format(Math.Round(Conversion.Val(this.FYValue14), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005FF0 File Offset: 0x000041F0
		private void TotalSalaryAdvance()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT isNULL(Sum(Amount),0) from AdvanceEntry where Workingdate between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue15 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue15 = Strings.Format(Math.Round(Conversion.Val(this.FYValue15), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000615C File Offset: 0x0000435C
		private void TotalSalaryPayment()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT isNULL(Sum(NetPay),0) from EmployeePayment where Paymentdate between @f1  And  @f2";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = this.DTP1.Date;
				this.cmdNFB.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = this.DTP2.Date;
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.FYValue16 = Conversions.ToString(this.rdrNFB.GetValue(0));
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
				this.FYValue16 = Strings.Format(Math.Round(Conversion.Val(this.FYValue16), 2), "0.00");
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000062C8 File Offset: 0x000044C8
		public void CompanyCurrency()
		{
			try
			{
				this.conNFB = new SqlConnection(this.csNFB);
				this.conNFB.Open();
				string text = "SELECT RTRIM(CurSym) from Company";
				this.cmdNFB = new SqlCommand(text);
				this.cmdNFB.Connection = this.conNFB;
				this.rdrNFB = this.cmdNFB.ExecuteReader();
				bool flag = this.rdrNFB.Read();
				if (flag)
				{
					this.CurSym = this.rdrNFB.GetValue(0).ToString().Trim();
				}
				else
				{
					this.CurSym = "";
				}
				bool flag2 = this.rdrNFB != null;
				if (flag2)
				{
					this.rdrNFB.Close();
				}
				this.conNFB.Close();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x04000008 RID: 8
		private IFirebaseConfig Config;

		// Token: 0x04000009 RID: 9
		private IFirebaseClient Client;

		// Token: 0x0400000A RID: 10
		private Dictionary<string, Dictionary<string, string>> todayData;

		// Token: 0x0400000B RID: 11
		private Dictionary<string, Dictionary<string, string>> fyData;

		// Token: 0x0400000C RID: 12
		private Timer autoUpdateTimer;

		// Token: 0x0400000D RID: 13
		private Timer intervalTimer;

		// Token: 0x0400000E RID: 14
		public string TBoxCompName;

		// Token: 0x0400000F RID: 15
		public string TBoxAddress;

		// Token: 0x04000010 RID: 16
		public string TBoxState;

		// Token: 0x04000011 RID: 17
		public string TBoxGSTIN;

		// Token: 0x04000012 RID: 18
		public string TBoxContactNo;

		// Token: 0x04000013 RID: 19
		public string TBoxEmail;

		// Token: 0x04000014 RID: 20
		private string CurSym;

		// Token: 0x04000015 RID: 21
		public DateTime DTP1;

		// Token: 0x04000016 RID: 22
		public DateTime DTP2;

		// Token: 0x04000017 RID: 23
		public string authSecretFB;

		// Token: 0x04000018 RID: 24
		public string basePathFB;

		// Token: 0x04000019 RID: 25
		public string companyid;

		// Token: 0x0400001A RID: 26
		public string usernameFB;

		// Token: 0x0400001B RID: 27
		public string dbnameFB;

		// Token: 0x0400001C RID: 28
		private string[] dateFormats;

		// Token: 0x0400001D RID: 29
		private string inputDate;

		// Token: 0x0400001E RID: 30
		private DateTime parsedDate;

		// Token: 0x0400001F RID: 31
		private string lastupdate;

		// Token: 0x04000020 RID: 32
		private SqlConnection conNFB;

		// Token: 0x04000021 RID: 33
		private SqlCommand cmdNFB;

		// Token: 0x04000022 RID: 34
		private SqlDataReader rdrNFB;

		// Token: 0x04000023 RID: 35
		private string stNFB;

		// Token: 0x04000024 RID: 36
		private string st1NFB;

		// Token: 0x04000025 RID: 37
		private string st2NFB;

		// Token: 0x04000026 RID: 38
		private string st3NFB;

		// Token: 0x04000027 RID: 39
		private string st4NFB;

		// Token: 0x04000028 RID: 40
		private string csNFB;

		// Token: 0x04000029 RID: 41
		private string TodayValue1;

		// Token: 0x0400002A RID: 42
		private string TodayValue2;

		// Token: 0x0400002B RID: 43
		private string TodayValue3;

		// Token: 0x0400002C RID: 44
		private string TodayValue4;

		// Token: 0x0400002D RID: 45
		private string TodayValue5;

		// Token: 0x0400002E RID: 46
		private string TodayValue6;

		// Token: 0x0400002F RID: 47
		private string TodayValue7;

		// Token: 0x04000030 RID: 48
		private string TodayValue8;

		// Token: 0x04000031 RID: 49
		private string TodayValue9;

		// Token: 0x04000032 RID: 50
		private string TodayValue10;

		// Token: 0x04000033 RID: 51
		private string TodayValue11;

		// Token: 0x04000034 RID: 52
		private string TodayValue12;

		// Token: 0x04000035 RID: 53
		private string TodayValue13;

		// Token: 0x04000036 RID: 54
		private string TodayValue14;

		// Token: 0x04000037 RID: 55
		private string TodayValue15;

		// Token: 0x04000038 RID: 56
		private string TodayValue16;

		// Token: 0x04000039 RID: 57
		private string TodayValue17;

		// Token: 0x0400003A RID: 58
		private string TodayValue18;

		// Token: 0x0400003B RID: 59
		private string FYValue18;

		// Token: 0x0400003C RID: 60
		private string FYValue17;

		// Token: 0x0400003D RID: 61
		private string FYValue1;

		// Token: 0x0400003E RID: 62
		private string FYValue2;

		// Token: 0x0400003F RID: 63
		private string FYValue3;

		// Token: 0x04000040 RID: 64
		private string FYValue4;

		// Token: 0x04000041 RID: 65
		private string FYValue5;

		// Token: 0x04000042 RID: 66
		private string FYValue6;

		// Token: 0x04000043 RID: 67
		private string FYValue7;

		// Token: 0x04000044 RID: 68
		private string FYValue8;

		// Token: 0x04000045 RID: 69
		private string FYValue9;

		// Token: 0x04000046 RID: 70
		private string FYValue10;

		// Token: 0x04000047 RID: 71
		private string FYValue11;

		// Token: 0x04000048 RID: 72
		private string FYValue12;

		// Token: 0x04000049 RID: 73
		private string FYValue13;

		// Token: 0x0400004A RID: 74
		private string FYValue14;

		// Token: 0x0400004B RID: 75
		private string FYValue15;

		// Token: 0x0400004C RID: 76
		private string FYValue16;
	}
}
