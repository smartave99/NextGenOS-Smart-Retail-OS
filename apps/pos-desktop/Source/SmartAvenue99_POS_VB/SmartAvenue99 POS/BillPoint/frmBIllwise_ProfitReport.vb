Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200007C RID: 124
	<DesignerGenerated()>
	Public Partial Class frmBIllwise_ProfitReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060014AC RID: 5292 RVA: 0x00011115 File Offset: 0x0000F315
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000856 RID: 2134
		' (get) Token: 0x060014AF RID: 5295 RVA: 0x00011123 File Offset: 0x0000F323
		' (set) Token: 0x060014B0 RID: 5296 RVA: 0x0001112D File Offset: 0x0000F32D
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17000857 RID: 2135
		' (get) Token: 0x060014B1 RID: 5297 RVA: 0x00011136 File Offset: 0x0000F336
		' (set) Token: 0x060014B2 RID: 5298 RVA: 0x00011140 File Offset: 0x0000F340
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000858 RID: 2136
		' (get) Token: 0x060014B3 RID: 5299 RVA: 0x00011149 File Offset: 0x0000F349
		' (set) Token: 0x060014B4 RID: 5300 RVA: 0x00011153 File Offset: 0x0000F353
		Friend Overridable Property Label2 As Label

		' Token: 0x17000859 RID: 2137
		' (get) Token: 0x060014B5 RID: 5301 RVA: 0x0001115C File Offset: 0x0000F35C
		' (set) Token: 0x060014B6 RID: 5302 RVA: 0x00011166 File Offset: 0x0000F366
		Friend Overridable Property Label4 As Label

		' Token: 0x1700085A RID: 2138
		' (get) Token: 0x060014B7 RID: 5303 RVA: 0x0001116F File Offset: 0x0000F36F
		' (set) Token: 0x060014B8 RID: 5304 RVA: 0x00011179 File Offset: 0x0000F379
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700085B RID: 2139
		' (get) Token: 0x060014B9 RID: 5305 RVA: 0x00011182 File Offset: 0x0000F382
		' (set) Token: 0x060014BA RID: 5306 RVA: 0x000DF8D8 File Offset: 0x000DDAD8
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700085C RID: 2140
		' (get) Token: 0x060014BB RID: 5307 RVA: 0x0001118C File Offset: 0x0000F38C
		' (set) Token: 0x060014BC RID: 5308 RVA: 0x00011196 File Offset: 0x0000F396
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700085D RID: 2141
		' (get) Token: 0x060014BD RID: 5309 RVA: 0x0001119F File Offset: 0x0000F39F
		' (set) Token: 0x060014BE RID: 5310 RVA: 0x000111A9 File Offset: 0x0000F3A9
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x1700085E RID: 2142
		' (get) Token: 0x060014BF RID: 5311 RVA: 0x000111B2 File Offset: 0x0000F3B2
		' (set) Token: 0x060014C0 RID: 5312 RVA: 0x000111BC File Offset: 0x0000F3BC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700085F RID: 2143
		' (get) Token: 0x060014C1 RID: 5313 RVA: 0x000111C5 File Offset: 0x0000F3C5
		' (set) Token: 0x060014C2 RID: 5314 RVA: 0x000111CF File Offset: 0x0000F3CF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000860 RID: 2144
		' (get) Token: 0x060014C3 RID: 5315 RVA: 0x000111D8 File Offset: 0x0000F3D8
		' (set) Token: 0x060014C4 RID: 5316 RVA: 0x000111E2 File Offset: 0x0000F3E2
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000861 RID: 2145
		' (get) Token: 0x060014C5 RID: 5317 RVA: 0x000111EB File Offset: 0x0000F3EB
		' (set) Token: 0x060014C6 RID: 5318 RVA: 0x000111F5 File Offset: 0x0000F3F5
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000862 RID: 2146
		' (get) Token: 0x060014C7 RID: 5319 RVA: 0x000111FE File Offset: 0x0000F3FE
		' (set) Token: 0x060014C8 RID: 5320 RVA: 0x00011208 File Offset: 0x0000F408
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000863 RID: 2147
		' (get) Token: 0x060014C9 RID: 5321 RVA: 0x00011211 File Offset: 0x0000F411
		' (set) Token: 0x060014CA RID: 5322 RVA: 0x0001121B File Offset: 0x0000F41B
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000864 RID: 2148
		' (get) Token: 0x060014CB RID: 5323 RVA: 0x00011224 File Offset: 0x0000F424
		' (set) Token: 0x060014CC RID: 5324 RVA: 0x0001122E File Offset: 0x0000F42E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000865 RID: 2149
		' (get) Token: 0x060014CD RID: 5325 RVA: 0x00011237 File Offset: 0x0000F437
		' (set) Token: 0x060014CE RID: 5326 RVA: 0x00011241 File Offset: 0x0000F441
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000866 RID: 2150
		' (get) Token: 0x060014CF RID: 5327 RVA: 0x0001124A File Offset: 0x0000F44A
		' (set) Token: 0x060014D0 RID: 5328 RVA: 0x00011254 File Offset: 0x0000F454
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000867 RID: 2151
		' (get) Token: 0x060014D1 RID: 5329 RVA: 0x0001125D File Offset: 0x0000F45D
		' (set) Token: 0x060014D2 RID: 5330 RVA: 0x00011267 File Offset: 0x0000F467
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000868 RID: 2152
		' (get) Token: 0x060014D3 RID: 5331 RVA: 0x00011270 File Offset: 0x0000F470
		' (set) Token: 0x060014D4 RID: 5332 RVA: 0x0001127A File Offset: 0x0000F47A
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x060014D5 RID: 5333 RVA: 0x000DF91C File Offset: 0x000DDB1C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.DataGridView1.Rows.Clear()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "SELECT " & vbCrLf & "    RTRIM(InvoiceInfo.InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceInfo.InvoiceDate," & vbCrLf & "    RTRIM(Customer.Name) AS CustomerName," & vbCrLf & "    SUM(Invoice_Product.Discount) AS Product_Discount," & vbCrLf & "    InvoiceInfo.GrandTotal," & vbCrLf & "    InvoiceInfo.TotalPaid," & vbCrLf & "    InvoiceInfo.Balance, " & vbCrLf & "    SUM(Invoice_Product.PurchaseRate * Invoice_Product.Qty) AS Cost_Price," & vbCrLf & "    (SUM(Invoice_Product.CGSTAmt) " & vbCrLf & "     + SUM(Invoice_Product.SGSTAmt) " & vbCrLf & "     + SUM(Invoice_Product.IGSTAmt) " & vbCrLf & "     + SUM(Invoice_Product.CESSAmt)) AS Total_Tax_Amount," & vbCrLf & "    InvoiceInfo.BillDiscount," & vbCrLf & "    SUM(Invoice_Product.Margin) AS Profit," & vbCrLf & "    (SUM(Invoice_Product.Margin) - InvoiceInfo.BillDiscount) AS Actual_Profit," & vbCrLf & "    InvoiceInfo.GrandTotal " & vbCrLf & "        - (SUM(Invoice_Product.CGSTAmt) " & vbCrLf & "           + SUM(Invoice_Product.SGSTAmt) " & vbCrLf & "           + SUM(Invoice_Product.IGSTAmt) " & vbCrLf & "           + SUM(Invoice_Product.CESSAmt)) " & vbCrLf & "        - SUM(Invoice_Product.PurchaseRate * Invoice_Product.Qty) AS actual" & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo" & vbCrLf & "INNER JOIN " & vbCrLf & "    Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Customer ON InvoiceInfo.Customer_ID = Customer.ID" & vbCrLf & "WHERE " & vbCrLf & "    InvoiceInfo.InvoiceDate BETWEEN @d1 AND @d2" & vbCrLf & "GROUP BY " & vbCrLf & "    InvoiceInfo.InvoiceNo," & vbCrLf & "    InvoiceInfo.InvoiceDate," & vbCrLf & "    Customer.Name," & vbCrLf & "    InvoiceInfo.GrandTotal," & vbCrLf & "    InvoiceInfo.TotalPaid," & vbCrLf & "    InvoiceInfo.Balance," & vbCrLf & "    InvoiceInfo.BillDiscount" & vbCrLf & "ORDER BY " & vbCrLf & "    InvoiceInfo.InvoiceDate;" & vbCrLf
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim num As Integer = 0
							Dim num2 As Decimal = 0D
							Dim num3 As Decimal = 0D
							Dim num4 As Decimal = 0D
							Dim num5 As Decimal = 0D
							Dim num6 As Decimal = 0D
							Dim num7 As Decimal = 0D
							Dim num8 As Decimal = 0D
							Dim num9 As Decimal = 0D
							Dim num10 As Decimal = 0D
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add()
								Me.DataGridView1.Rows(num).Cells(0).Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(sqlDataReader("InvoiceDate"))).ToString("dd-MMM-yyyy")
								Me.DataGridView1.Rows(num).Cells(1).Value = sqlDataReader("InvoiceNo").ToString()
								Me.DataGridView1.Rows(num).Cells(2).Value = sqlDataReader("CustomerName").ToString()
								Me.DataGridView1.Rows(num).Cells(3).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Product_Discount")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(4).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(5).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(6).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Balance")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(7).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Cost_Price")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(8).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Total_Tax_Amount")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(9).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Profit")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(10).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("BillDiscount")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(11).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Actual_Profit")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Dim num11 As Decimal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Actual_Profit")))
								Dim flag As Boolean = Decimal.Compare(num11, 0D) > 0
								If flag Then
									Me.DataGridView1.Rows(num).Cells(12).Value = "Profit"
									Me.DataGridView1.Rows(num).DefaultCellStyle.BackColor = Color.LightGreen
								Else
									Me.DataGridView1.Rows(num).Cells(12).Value = "Loss"
									Me.DataGridView1.Rows(num).DefaultCellStyle.BackColor = Color.LightCoral
								End If
								num += 1
								num2 = Decimal.Add(num2, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Product_Discount"))))
								num3 = Decimal.Add(num3, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal"))))
								num4 = Decimal.Add(num4, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid"))))
								num5 = Decimal.Add(num5, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Balance"))))
								num6 = Decimal.Add(num6, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Cost_Price"))))
								num7 = Decimal.Add(num7, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Total_Tax_Amount"))))
								num8 = Decimal.Add(num8, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Profit"))))
								num9 = Decimal.Add(num9, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("BillDiscount"))))
								num10 = Decimal.Add(num10, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Actual_Profit"))))
							End While
							Dim num12 As Integer = Me.DataGridView1.Rows.Add()
							Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(num12)
							dataGridViewRow.DefaultCellStyle.BackColor = Color.LightYellow
							dataGridViewRow.DefaultCellStyle.Font = New Font(Me.DataGridView1.Font, FontStyle.Bold)
							dataGridViewRow.Cells(2).Value = "T O T A L"
							dataGridViewRow.Cells(3).Value = Strings.FormatNumber(num2, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(4).Value = Strings.FormatNumber(num3, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(5).Value = Strings.FormatNumber(num4, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(6).Value = Strings.FormatNumber(num5, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(7).Value = Strings.FormatNumber(num6, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(8).Value = Strings.FormatNumber(num7, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(9).Value = Strings.FormatNumber(num8, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(10).Value = Strings.FormatNumber(num9, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							dataGridViewRow.Cells(11).Value = Strings.FormatNumber(num10, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Dim num13 As Decimal = num10
							Dim flag2 As Boolean = Decimal.Compare(num13, 0D) > 0
							If flag2 Then
								dataGridViewRow.Cells(12).Value = "Profit"
								Me.DataGridView1.Rows(num12).DefaultCellStyle.BackColor = Color.LightCyan
							Else
								dataGridViewRow.Cells(12).Value = "Loss"
								Me.DataGridView1.Rows(num12).DefaultCellStyle.BackColor = Color.LightCyan
							End If
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub
	End Class
End Namespace
