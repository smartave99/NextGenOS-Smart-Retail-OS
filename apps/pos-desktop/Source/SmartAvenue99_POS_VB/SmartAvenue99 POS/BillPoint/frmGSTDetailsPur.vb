Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000347 RID: 839
	<DesignerGenerated()>
	Public Partial Class frmGSTDetailsPur
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C479 RID: 50297 RVA: 0x00057DC9 File Offset: 0x00055FC9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTDetailsPur_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004DFE RID: 19966
		' (get) Token: 0x0600C47C RID: 50300 RVA: 0x00057DFB File Offset: 0x00055FFB
		' (set) Token: 0x0600C47D RID: 50301 RVA: 0x00057E05 File Offset: 0x00056005
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004DFF RID: 19967
		' (get) Token: 0x0600C47E RID: 50302 RVA: 0x00057E0E File Offset: 0x0005600E
		' (set) Token: 0x0600C47F RID: 50303 RVA: 0x00057E18 File Offset: 0x00056018
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004E00 RID: 19968
		' (get) Token: 0x0600C480 RID: 50304 RVA: 0x00057E21 File Offset: 0x00056021
		' (set) Token: 0x0600C481 RID: 50305 RVA: 0x00057E2B File Offset: 0x0005602B
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004E01 RID: 19969
		' (get) Token: 0x0600C482 RID: 50306 RVA: 0x00057E34 File Offset: 0x00056034
		' (set) Token: 0x0600C483 RID: 50307 RVA: 0x00057E3E File Offset: 0x0005603E
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004E02 RID: 19970
		' (get) Token: 0x0600C484 RID: 50308 RVA: 0x00057E47 File Offset: 0x00056047
		' (set) Token: 0x0600C485 RID: 50309 RVA: 0x00057E51 File Offset: 0x00056051
		Friend Overridable Property Label2 As Label

		' Token: 0x17004E03 RID: 19971
		' (get) Token: 0x0600C486 RID: 50310 RVA: 0x00057E5A File Offset: 0x0005605A
		' (set) Token: 0x0600C487 RID: 50311 RVA: 0x00057E64 File Offset: 0x00056064
		Friend Overridable Property Label4 As Label

		' Token: 0x17004E04 RID: 19972
		' (get) Token: 0x0600C488 RID: 50312 RVA: 0x00057E6D File Offset: 0x0005606D
		' (set) Token: 0x0600C489 RID: 50313 RVA: 0x00057E77 File Offset: 0x00056077
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004E05 RID: 19973
		' (get) Token: 0x0600C48A RID: 50314 RVA: 0x00057E80 File Offset: 0x00056080
		' (set) Token: 0x0600C48B RID: 50315 RVA: 0x007CC1E8 File Offset: 0x007CA3E8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E06 RID: 19974
		' (get) Token: 0x0600C48C RID: 50316 RVA: 0x00057E8A File Offset: 0x0005608A
		' (set) Token: 0x0600C48D RID: 50317 RVA: 0x00057E94 File Offset: 0x00056094
		Friend Overridable Property Label1 As Label

		' Token: 0x17004E07 RID: 19975
		' (get) Token: 0x0600C48E RID: 50318 RVA: 0x00057E9D File Offset: 0x0005609D
		' (set) Token: 0x0600C48F RID: 50319 RVA: 0x00057EA7 File Offset: 0x000560A7
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004E08 RID: 19976
		' (get) Token: 0x0600C490 RID: 50320 RVA: 0x00057EB0 File Offset: 0x000560B0
		' (set) Token: 0x0600C491 RID: 50321 RVA: 0x00057EBA File Offset: 0x000560BA
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004E09 RID: 19977
		' (get) Token: 0x0600C492 RID: 50322 RVA: 0x00057EC3 File Offset: 0x000560C3
		' (set) Token: 0x0600C493 RID: 50323 RVA: 0x00057ECD File Offset: 0x000560CD
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004E0A RID: 19978
		' (get) Token: 0x0600C494 RID: 50324 RVA: 0x00057ED6 File Offset: 0x000560D6
		' (set) Token: 0x0600C495 RID: 50325 RVA: 0x00057EE0 File Offset: 0x000560E0
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004E0B RID: 19979
		' (get) Token: 0x0600C496 RID: 50326 RVA: 0x00057EE9 File Offset: 0x000560E9
		' (set) Token: 0x0600C497 RID: 50327 RVA: 0x00057EF3 File Offset: 0x000560F3
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004E0C RID: 19980
		' (get) Token: 0x0600C498 RID: 50328 RVA: 0x00057EFC File Offset: 0x000560FC
		' (set) Token: 0x0600C499 RID: 50329 RVA: 0x00057F06 File Offset: 0x00056106
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004E0D RID: 19981
		' (get) Token: 0x0600C49A RID: 50330 RVA: 0x00057F0F File Offset: 0x0005610F
		' (set) Token: 0x0600C49B RID: 50331 RVA: 0x00057F19 File Offset: 0x00056119
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004E0E RID: 19982
		' (get) Token: 0x0600C49C RID: 50332 RVA: 0x00057F22 File Offset: 0x00056122
		' (set) Token: 0x0600C49D RID: 50333 RVA: 0x00057F2C File Offset: 0x0005612C
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004E0F RID: 19983
		' (get) Token: 0x0600C49E RID: 50334 RVA: 0x00057F35 File Offset: 0x00056135
		' (set) Token: 0x0600C49F RID: 50335 RVA: 0x00057F3F File Offset: 0x0005613F
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17004E10 RID: 19984
		' (get) Token: 0x0600C4A0 RID: 50336 RVA: 0x00057F48 File Offset: 0x00056148
		' (set) Token: 0x0600C4A1 RID: 50337 RVA: 0x00057F52 File Offset: 0x00056152
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004E11 RID: 19985
		' (get) Token: 0x0600C4A2 RID: 50338 RVA: 0x00057F5B File Offset: 0x0005615B
		' (set) Token: 0x0600C4A3 RID: 50339 RVA: 0x00057F65 File Offset: 0x00056165
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004E12 RID: 19986
		' (get) Token: 0x0600C4A4 RID: 50340 RVA: 0x00057F6E File Offset: 0x0005616E
		' (set) Token: 0x0600C4A5 RID: 50341 RVA: 0x00057F78 File Offset: 0x00056178
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17004E13 RID: 19987
		' (get) Token: 0x0600C4A6 RID: 50342 RVA: 0x00057F81 File Offset: 0x00056181
		' (set) Token: 0x0600C4A7 RID: 50343 RVA: 0x00057F8B File Offset: 0x0005618B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004E14 RID: 19988
		' (get) Token: 0x0600C4A8 RID: 50344 RVA: 0x00057F94 File Offset: 0x00056194
		' (set) Token: 0x0600C4A9 RID: 50345 RVA: 0x00057F9E File Offset: 0x0005619E
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17004E15 RID: 19989
		' (get) Token: 0x0600C4AA RID: 50346 RVA: 0x00057FA7 File Offset: 0x000561A7
		' (set) Token: 0x0600C4AB RID: 50347 RVA: 0x00057FB1 File Offset: 0x000561B1
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004E16 RID: 19990
		' (get) Token: 0x0600C4AC RID: 50348 RVA: 0x00057FBA File Offset: 0x000561BA
		' (set) Token: 0x0600C4AD RID: 50349 RVA: 0x00057FC4 File Offset: 0x000561C4
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004E17 RID: 19991
		' (get) Token: 0x0600C4AE RID: 50350 RVA: 0x00057FCD File Offset: 0x000561CD
		' (set) Token: 0x0600C4AF RID: 50351 RVA: 0x00057FD7 File Offset: 0x000561D7
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17004E18 RID: 19992
		' (get) Token: 0x0600C4B0 RID: 50352 RVA: 0x00057FE0 File Offset: 0x000561E0
		' (set) Token: 0x0600C4B1 RID: 50353 RVA: 0x00057FEA File Offset: 0x000561EA
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17004E19 RID: 19993
		' (get) Token: 0x0600C4B2 RID: 50354 RVA: 0x00057FF3 File Offset: 0x000561F3
		' (set) Token: 0x0600C4B3 RID: 50355 RVA: 0x00057FFD File Offset: 0x000561FD
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17004E1A RID: 19994
		' (get) Token: 0x0600C4B4 RID: 50356 RVA: 0x00058006 File Offset: 0x00056206
		' (set) Token: 0x0600C4B5 RID: 50357 RVA: 0x00058010 File Offset: 0x00056210
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004E1B RID: 19995
		' (get) Token: 0x0600C4B6 RID: 50358 RVA: 0x00058019 File Offset: 0x00056219
		' (set) Token: 0x0600C4B7 RID: 50359 RVA: 0x00058023 File Offset: 0x00056223
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17004E1C RID: 19996
		' (get) Token: 0x0600C4B8 RID: 50360 RVA: 0x0005802C File Offset: 0x0005622C
		' (set) Token: 0x0600C4B9 RID: 50361 RVA: 0x00058036 File Offset: 0x00056236
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004E1D RID: 19997
		' (get) Token: 0x0600C4BA RID: 50362 RVA: 0x0005803F File Offset: 0x0005623F
		' (set) Token: 0x0600C4BB RID: 50363 RVA: 0x00058049 File Offset: 0x00056249
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17004E1E RID: 19998
		' (get) Token: 0x0600C4BC RID: 50364 RVA: 0x00058052 File Offset: 0x00056252
		' (set) Token: 0x0600C4BD RID: 50365 RVA: 0x0005805C File Offset: 0x0005625C
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004E1F RID: 19999
		' (get) Token: 0x0600C4BE RID: 50366 RVA: 0x00058065 File Offset: 0x00056265
		' (set) Token: 0x0600C4BF RID: 50367 RVA: 0x0005806F File Offset: 0x0005626F
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17004E20 RID: 20000
		' (get) Token: 0x0600C4C0 RID: 50368 RVA: 0x00058078 File Offset: 0x00056278
		' (set) Token: 0x0600C4C1 RID: 50369 RVA: 0x00058082 File Offset: 0x00056282
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17004E21 RID: 20001
		' (get) Token: 0x0600C4C2 RID: 50370 RVA: 0x0005808B File Offset: 0x0005628B
		' (set) Token: 0x0600C4C3 RID: 50371 RVA: 0x00058095 File Offset: 0x00056295
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17004E22 RID: 20002
		' (get) Token: 0x0600C4C4 RID: 50372 RVA: 0x0005809E File Offset: 0x0005629E
		' (set) Token: 0x0600C4C5 RID: 50373 RVA: 0x000580A8 File Offset: 0x000562A8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004E23 RID: 20003
		' (get) Token: 0x0600C4C6 RID: 50374 RVA: 0x000580B1 File Offset: 0x000562B1
		' (set) Token: 0x0600C4C7 RID: 50375 RVA: 0x000580BB File Offset: 0x000562BB
		Friend Overridable Property Label3 As Label

		' Token: 0x17004E24 RID: 20004
		' (get) Token: 0x0600C4C8 RID: 50376 RVA: 0x000580C4 File Offset: 0x000562C4
		' (set) Token: 0x0600C4C9 RID: 50377 RVA: 0x007CC22C File Offset: 0x007CA42C
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E25 RID: 20005
		' (get) Token: 0x0600C4CA RID: 50378 RVA: 0x000580CE File Offset: 0x000562CE
		' (set) Token: 0x0600C4CB RID: 50379 RVA: 0x007CC28C File Offset: 0x007CA48C
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E26 RID: 20006
		' (get) Token: 0x0600C4CC RID: 50380 RVA: 0x000580D8 File Offset: 0x000562D8
		' (set) Token: 0x0600C4CD RID: 50381 RVA: 0x007CC2D0 File Offset: 0x007CA4D0
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E27 RID: 20007
		' (get) Token: 0x0600C4CE RID: 50382 RVA: 0x000580E2 File Offset: 0x000562E2
		' (set) Token: 0x0600C4CF RID: 50383 RVA: 0x007CC314 File Offset: 0x007CA514
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600C4D0 RID: 50384 RVA: 0x007CC358 File Offset: 0x007CA558
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C4D1 RID: 50385 RVA: 0x007CC42C File Offset: 0x007CA62C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C4D2 RID: 50386 RVA: 0x007CC734 File Offset: 0x007CA934
		Private Sub frmGSTDetailsPur_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C4D3 RID: 50387 RVA: 0x007CC7CC File Offset: 0x007CA9CC
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600C4D4 RID: 50388 RVA: 0x007CC944 File Offset: 0x007CAB44
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C4D5 RID: 50389 RVA: 0x007CCA10 File Offset: 0x007CAC10
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C4D6 RID: 50390 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C4D7 RID: 50391 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C4D8 RID: 50392 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C4D9 RID: 50393 RVA: 0x007CCADC File Offset: 0x007CACDC
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600C4DA RID: 50394 RVA: 0x000580EC File Offset: 0x000562EC
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.TextBox1.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600C4DB RID: 50395 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C4DC RID: 50396 RVA: 0x007CCBC4 File Offset: 0x007CADC4
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600C4DD RID: 50397 RVA: 0x007CCCDC File Offset: 0x007CAEDC
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.TextBox1.Text
					Dim selectionStart As Integer = Me.TextBox1.SelectionStart
					Dim selectionLength As Integer = Me.TextBox1.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
			Dim flag5 As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag5 Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600C4DE RID: 50398 RVA: 0x007CCE1C File Offset: 0x007CB01C
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer)=@d3 and NOT Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.TextBox1.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600C4DF RID: 50399 RVA: 0x007CD148 File Offset: 0x007CB348
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600C4E0 RID: 50400 RVA: 0x0005811F File Offset: 0x0005631F
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600C4E1 RID: 50401 RVA: 0x007CD448 File Offset: 0x007CB648
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
