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
Imports BillPoint.My.Resources
Imports CButtonLib
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000C8 RID: 200
	<DesignerGenerated()>
	Public Partial Class frmGSTR1_HSNC
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002234 RID: 8756 RVA: 0x00017B88 File Offset: 0x00015D88
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTR1_HSNC_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000D9D RID: 3485
		' (get) Token: 0x06002237 RID: 8759 RVA: 0x00017BA8 File Offset: 0x00015DA8
		' (set) Token: 0x06002238 RID: 8760 RVA: 0x00017BB2 File Offset: 0x00015DB2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000D9E RID: 3486
		' (get) Token: 0x06002239 RID: 8761 RVA: 0x00017BBB File Offset: 0x00015DBB
		' (set) Token: 0x0600223A RID: 8762 RVA: 0x00017BC5 File Offset: 0x00015DC5
		Friend Overridable Property Label3 As Label

		' Token: 0x17000D9F RID: 3487
		' (get) Token: 0x0600223B RID: 8763 RVA: 0x00017BCE File Offset: 0x00015DCE
		' (set) Token: 0x0600223C RID: 8764 RVA: 0x0015EA08 File Offset: 0x0015CC08
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DA0 RID: 3488
		' (get) Token: 0x0600223D RID: 8765 RVA: 0x00017BD8 File Offset: 0x00015DD8
		' (set) Token: 0x0600223E RID: 8766 RVA: 0x00017BE2 File Offset: 0x00015DE2
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000DA1 RID: 3489
		' (get) Token: 0x0600223F RID: 8767 RVA: 0x00017BEB File Offset: 0x00015DEB
		' (set) Token: 0x06002240 RID: 8768 RVA: 0x00017BF5 File Offset: 0x00015DF5
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000DA2 RID: 3490
		' (get) Token: 0x06002241 RID: 8769 RVA: 0x00017BFE File Offset: 0x00015DFE
		' (set) Token: 0x06002242 RID: 8770 RVA: 0x00017C08 File Offset: 0x00015E08
		Friend Overridable Property Label2 As Label

		' Token: 0x17000DA3 RID: 3491
		' (get) Token: 0x06002243 RID: 8771 RVA: 0x00017C11 File Offset: 0x00015E11
		' (set) Token: 0x06002244 RID: 8772 RVA: 0x0015EA4C File Offset: 0x0015CC4C
		Private _btnGetData As CButton
		Friend Overridable Property btnGetData As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnGetData_ClickButtonArea
				Dim cbutton As CButton = Me._btnGetData
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnGetData = value
				cbutton = Me._btnGetData
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DA4 RID: 3492
		' (get) Token: 0x06002245 RID: 8773 RVA: 0x00017C1B File Offset: 0x00015E1B
		' (set) Token: 0x06002246 RID: 8774 RVA: 0x00017C25 File Offset: 0x00015E25
		Friend Overridable Property Label4 As Label

		' Token: 0x17000DA5 RID: 3493
		' (get) Token: 0x06002247 RID: 8775 RVA: 0x00017C2E File Offset: 0x00015E2E
		' (set) Token: 0x06002248 RID: 8776 RVA: 0x00017C38 File Offset: 0x00015E38
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17000DA6 RID: 3494
		' (get) Token: 0x06002249 RID: 8777 RVA: 0x00017C41 File Offset: 0x00015E41
		' (set) Token: 0x0600224A RID: 8778 RVA: 0x00017C4B File Offset: 0x00015E4B
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17000DA7 RID: 3495
		' (get) Token: 0x0600224B RID: 8779 RVA: 0x00017C54 File Offset: 0x00015E54
		' (set) Token: 0x0600224C RID: 8780 RVA: 0x0015EA90 File Offset: 0x0015CC90
		Private _btnExportExcel As CButton
		Friend Overridable Property btnExportExcel As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnExportExcel_ClickButtonArea
				Dim cbutton As CButton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnExportExcel = value
				cbutton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DA8 RID: 3496
		' (get) Token: 0x0600224D RID: 8781 RVA: 0x00017C5E File Offset: 0x00015E5E
		' (set) Token: 0x0600224E RID: 8782 RVA: 0x0015EAD4 File Offset: 0x0015CCD4
		Private _btnReset As CButton
		Friend Overridable Property btnReset As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnReset_ClickButtonArea
				Dim cbutton As CButton = Me._btnReset
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnReset = value
				cbutton = Me._btnReset
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DA9 RID: 3497
		' (get) Token: 0x0600224F RID: 8783 RVA: 0x00017C68 File Offset: 0x00015E68
		' (set) Token: 0x06002250 RID: 8784 RVA: 0x0015EB18 File Offset: 0x0015CD18
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

		' Token: 0x17000DAA RID: 3498
		' (get) Token: 0x06002251 RID: 8785 RVA: 0x00017C72 File Offset: 0x00015E72
		' (set) Token: 0x06002252 RID: 8786 RVA: 0x00017C7C File Offset: 0x00015E7C
		Friend Overridable Property Label1 As Label

		' Token: 0x17000DAB RID: 3499
		' (get) Token: 0x06002253 RID: 8787 RVA: 0x00017C85 File Offset: 0x00015E85
		' (set) Token: 0x06002254 RID: 8788 RVA: 0x00017C8F File Offset: 0x00015E8F
		Friend Overridable Property Label5 As Label

		' Token: 0x17000DAC RID: 3500
		' (get) Token: 0x06002255 RID: 8789 RVA: 0x00017C98 File Offset: 0x00015E98
		' (set) Token: 0x06002256 RID: 8790 RVA: 0x0015EB5C File Offset: 0x0015CD5C
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DAD RID: 3501
		' (get) Token: 0x06002257 RID: 8791 RVA: 0x00017CA2 File Offset: 0x00015EA2
		' (set) Token: 0x06002258 RID: 8792 RVA: 0x00017CAC File Offset: 0x00015EAC
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000DAE RID: 3502
		' (get) Token: 0x06002259 RID: 8793 RVA: 0x00017CB5 File Offset: 0x00015EB5
		' (set) Token: 0x0600225A RID: 8794 RVA: 0x00017CBF File Offset: 0x00015EBF
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17000DAF RID: 3503
		' (get) Token: 0x0600225B RID: 8795 RVA: 0x00017CC8 File Offset: 0x00015EC8
		' (set) Token: 0x0600225C RID: 8796 RVA: 0x00017CD2 File Offset: 0x00015ED2
		Friend Overridable Property Label17 As Label

		' Token: 0x17000DB0 RID: 3504
		' (get) Token: 0x0600225D RID: 8797 RVA: 0x00017CDB File Offset: 0x00015EDB
		' (set) Token: 0x0600225E RID: 8798 RVA: 0x00017CE5 File Offset: 0x00015EE5
		Friend Overridable Property Label16 As Label

		' Token: 0x17000DB1 RID: 3505
		' (get) Token: 0x0600225F RID: 8799 RVA: 0x00017CEE File Offset: 0x00015EEE
		' (set) Token: 0x06002260 RID: 8800 RVA: 0x00017CF8 File Offset: 0x00015EF8
		Friend Overridable Property Label15 As Label

		' Token: 0x17000DB2 RID: 3506
		' (get) Token: 0x06002261 RID: 8801 RVA: 0x00017D01 File Offset: 0x00015F01
		' (set) Token: 0x06002262 RID: 8802 RVA: 0x00017D0B File Offset: 0x00015F0B
		Friend Overridable Property Label14 As Label

		' Token: 0x17000DB3 RID: 3507
		' (get) Token: 0x06002263 RID: 8803 RVA: 0x00017D14 File Offset: 0x00015F14
		' (set) Token: 0x06002264 RID: 8804 RVA: 0x00017D1E File Offset: 0x00015F1E
		Friend Overridable Property Label13 As Label

		' Token: 0x17000DB4 RID: 3508
		' (get) Token: 0x06002265 RID: 8805 RVA: 0x00017D27 File Offset: 0x00015F27
		' (set) Token: 0x06002266 RID: 8806 RVA: 0x00017D31 File Offset: 0x00015F31
		Friend Overridable Property Label12 As Label

		' Token: 0x17000DB5 RID: 3509
		' (get) Token: 0x06002267 RID: 8807 RVA: 0x00017D3A File Offset: 0x00015F3A
		' (set) Token: 0x06002268 RID: 8808 RVA: 0x00017D44 File Offset: 0x00015F44
		Friend Overridable Property Label11 As Label

		' Token: 0x17000DB6 RID: 3510
		' (get) Token: 0x06002269 RID: 8809 RVA: 0x00017D4D File Offset: 0x00015F4D
		' (set) Token: 0x0600226A RID: 8810 RVA: 0x00017D57 File Offset: 0x00015F57
		Friend Overridable Property Label10 As Label

		' Token: 0x17000DB7 RID: 3511
		' (get) Token: 0x0600226B RID: 8811 RVA: 0x00017D60 File Offset: 0x00015F60
		' (set) Token: 0x0600226C RID: 8812 RVA: 0x00017D6A File Offset: 0x00015F6A
		Friend Overridable Property Label9 As Label

		' Token: 0x17000DB8 RID: 3512
		' (get) Token: 0x0600226D RID: 8813 RVA: 0x00017D73 File Offset: 0x00015F73
		' (set) Token: 0x0600226E RID: 8814 RVA: 0x00017D7D File Offset: 0x00015F7D
		Friend Overridable Property Label8 As Label

		' Token: 0x17000DB9 RID: 3513
		' (get) Token: 0x0600226F RID: 8815 RVA: 0x00017D86 File Offset: 0x00015F86
		' (set) Token: 0x06002270 RID: 8816 RVA: 0x00017D90 File Offset: 0x00015F90
		Friend Overridable Property Label7 As Label

		' Token: 0x17000DBA RID: 3514
		' (get) Token: 0x06002271 RID: 8817 RVA: 0x00017D99 File Offset: 0x00015F99
		' (set) Token: 0x06002272 RID: 8818 RVA: 0x00017DA3 File Offset: 0x00015FA3
		Friend Overridable Property Label6 As Label

		' Token: 0x17000DBB RID: 3515
		' (get) Token: 0x06002273 RID: 8819 RVA: 0x00017DAC File Offset: 0x00015FAC
		' (set) Token: 0x06002274 RID: 8820 RVA: 0x00017DB6 File Offset: 0x00015FB6
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000DBC RID: 3516
		' (get) Token: 0x06002275 RID: 8821 RVA: 0x00017DBF File Offset: 0x00015FBF
		' (set) Token: 0x06002276 RID: 8822 RVA: 0x00017DC9 File Offset: 0x00015FC9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000DBD RID: 3517
		' (get) Token: 0x06002277 RID: 8823 RVA: 0x00017DD2 File Offset: 0x00015FD2
		' (set) Token: 0x06002278 RID: 8824 RVA: 0x00017DDC File Offset: 0x00015FDC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000DBE RID: 3518
		' (get) Token: 0x06002279 RID: 8825 RVA: 0x00017DE5 File Offset: 0x00015FE5
		' (set) Token: 0x0600227A RID: 8826 RVA: 0x00017DEF File Offset: 0x00015FEF
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000DBF RID: 3519
		' (get) Token: 0x0600227B RID: 8827 RVA: 0x00017DF8 File Offset: 0x00015FF8
		' (set) Token: 0x0600227C RID: 8828 RVA: 0x00017E02 File Offset: 0x00016002
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000DC0 RID: 3520
		' (get) Token: 0x0600227D RID: 8829 RVA: 0x00017E0B File Offset: 0x0001600B
		' (set) Token: 0x0600227E RID: 8830 RVA: 0x00017E15 File Offset: 0x00016015
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000DC1 RID: 3521
		' (get) Token: 0x0600227F RID: 8831 RVA: 0x00017E1E File Offset: 0x0001601E
		' (set) Token: 0x06002280 RID: 8832 RVA: 0x00017E28 File Offset: 0x00016028
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000DC2 RID: 3522
		' (get) Token: 0x06002281 RID: 8833 RVA: 0x00017E31 File Offset: 0x00016031
		' (set) Token: 0x06002282 RID: 8834 RVA: 0x00017E3B File Offset: 0x0001603B
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000DC3 RID: 3523
		' (get) Token: 0x06002283 RID: 8835 RVA: 0x00017E44 File Offset: 0x00016044
		' (set) Token: 0x06002284 RID: 8836 RVA: 0x00017E4E File Offset: 0x0001604E
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000DC4 RID: 3524
		' (get) Token: 0x06002285 RID: 8837 RVA: 0x00017E57 File Offset: 0x00016057
		' (set) Token: 0x06002286 RID: 8838 RVA: 0x00017E61 File Offset: 0x00016061
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000DC5 RID: 3525
		' (get) Token: 0x06002287 RID: 8839 RVA: 0x00017E6A File Offset: 0x0001606A
		' (set) Token: 0x06002288 RID: 8840 RVA: 0x00017E74 File Offset: 0x00016074
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000DC6 RID: 3526
		' (get) Token: 0x06002289 RID: 8841 RVA: 0x00017E7D File Offset: 0x0001607D
		' (set) Token: 0x0600228A RID: 8842 RVA: 0x00017E87 File Offset: 0x00016087
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x0600228B RID: 8843 RVA: 0x0015EBA0 File Offset: 0x0015CDA0
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

		' Token: 0x0600228C RID: 8844 RVA: 0x0015EC74 File Offset: 0x0015CE74
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceDate, RTRIM(Product.HSNCode) AS HSNCode, RTRIM(Product.ProductName) AS ProductName, RTRIM(SalesUnit) AS SalesUnit, SUM(Invoice_Product.Qty) AS TotalQty, SUM(Invoice_Product.TaxableAmt) AS TotalTaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) AS TotalTaxPercent, SUM(Invoice_Product.IGSTAmt) AS TotalIGSTAmt, SUM(Invoice_Product.CGSTAmt) AS TotalCGSTAmt, SUM(Invoice_Product.SGSTAmt) AS TotalSGSTAmt, SUM(Invoice_Product.CESSAmt) AS TotalCESSAmt FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE InvoiceDate BETWEEN @d1 AND @d2 AND NOT InvoiceInfo.TaxType='NON GST' AND Product.HSNCode IS NOT NULL AND LTRIM(RTRIM(Product.HSNCode)) <> '' GROUP BY InvoiceInfo.InvoiceDate, Product.HSNCode, Product.ProductName, SalesUnit, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) ORDER BY InvoiceInfo.InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.[Date]).Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.[Date]).Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr("InvoiceDate"), ModCommonClasses.rdr("HSNCode"), "", ModCommonClasses.rdr("ProductName"), ModCommonClasses.rdr("SalesUnit"), ModCommonClasses.rdr("TotalQty"), ModCommonClasses.rdr("TotalTaxableAmt"), ModCommonClasses.rdr("TotalTaxPercent"), ModCommonClasses.rdr("TotalIGSTAmt"), ModCommonClasses.rdr("TotalCGSTAmt"), ModCommonClasses.rdr("TotalSGSTAmt"), ModCommonClasses.rdr("TotalCESSAmt") })
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600228D RID: 8845 RVA: 0x00017E90 File Offset: 0x00016090
		Private Sub btnGetData_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600228E RID: 8846 RVA: 0x0015EEE0 File Offset: 0x0015D0E0
		Private Sub frmGSTR1_HSNC_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.RowHeadersDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#ffffff")
		End Sub

		' Token: 0x0600228F RID: 8847 RVA: 0x0015EFA0 File Offset: 0x0015D1A0
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceDate, RTRIM(Product.HSNCode) AS HSNCode, RTRIM(Product.ProductName) AS ProductName, RTRIM(SalesUnit) AS SalesUnit, SUM(Invoice_Product.Qty) AS TotalQty, SUM(Invoice_Product.TaxableAmt) AS TotalTaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) AS TotalTaxPercent, SUM(Invoice_Product.IGSTAmt) AS TotalIGSTAmt, SUM(Invoice_Product.CGSTAmt) AS TotalCGSTAmt, SUM(Invoice_Product.SGSTAmt) AS TotalSGSTAmt, SUM(Invoice_Product.CESSAmt) AS TotalCESSAmt FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE InvoiceDate BETWEEN @d1 AND @d2 AND (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer)=@d3 AND NOT InvoiceInfo.TaxType='NON GST' AND Product.HSNCode IS NOT NULL AND LTRIM(RTRIM(Product.HSNCode)) <> '' GROUP BY InvoiceInfo.InvoiceDate, Product.HSNCode, Product.ProductName, SalesUnit, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) ORDER BY InvoiceInfo.InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.[Date]).Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.[Date]).Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.TextBox1.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr("InvoiceDate"), ModCommonClasses.rdr("HSNCode"), "", ModCommonClasses.rdr("ProductName"), ModCommonClasses.rdr("SalesUnit"), ModCommonClasses.rdr("TotalQty"), ModCommonClasses.rdr("TotalTaxableAmt"), ModCommonClasses.rdr("TotalTaxPercent"), ModCommonClasses.rdr("TotalIGSTAmt"), ModCommonClasses.rdr("TotalCGSTAmt"), ModCommonClasses.rdr("TotalSGSTAmt"), ModCommonClasses.rdr("TotalCESSAmt") })
					End While
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con IsNot Nothing
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06002290 RID: 8848 RVA: 0x0015F24C File Offset: 0x0015D44C
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceDate, RTRIM(Product.HSNCode) AS HSNCode, RTRIM(Product.ProductName) AS ProductName, RTRIM(SalesUnit) AS SalesUnit, SUM(Invoice_Product.Qty) AS TotalQty, SUM(Invoice_Product.TaxableAmt) AS TotalTaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) AS TotalTaxPercent, SUM(Invoice_Product.IGSTAmt) AS TotalIGSTAmt, SUM(Invoice_Product.CGSTAmt) AS TotalCGSTAmt, SUM(Invoice_Product.SGSTAmt) AS TotalSGSTAmt, SUM(Invoice_Product.CESSAmt) AS TotalCESSAmt FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE InvoiceDate BETWEEN @d1 AND @d2 AND HSNCode=@d3 AND NOT InvoiceInfo.TaxType='NON GST' AND Product.HSNCode IS NOT NULL AND LTRIM(RTRIM(Product.HSNCode)) <> '' GROUP BY InvoiceInfo.InvoiceDate, Product.HSNCode, Product.ProductName, SalesUnit, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer) ORDER BY InvoiceInfo.InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.[Date]).Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.[Date]).Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox2.Text.ToString().Trim())
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr("InvoiceDate"), ModCommonClasses.rdr("HSNCode"), "", ModCommonClasses.rdr("ProductName"), ModCommonClasses.rdr("SalesUnit"), ModCommonClasses.rdr("TotalQty"), ModCommonClasses.rdr("TotalTaxableAmt"), ModCommonClasses.rdr("TotalTaxPercent"), ModCommonClasses.rdr("TotalIGSTAmt"), ModCommonClasses.rdr("TotalCGSTAmt"), ModCommonClasses.rdr("TotalSGSTAmt"), ModCommonClasses.rdr("TotalCESSAmt") })
					End While
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con IsNot Nothing
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06002291 RID: 8849 RVA: 0x00017E9A File Offset: 0x0001609A
		Private Sub btnReset_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.TextBox1.Clear()
			Me.TextBox2.Clear()
			Me.Getdata()
		End Sub

		' Token: 0x06002292 RID: 8850 RVA: 0x0015F4F8 File Offset: 0x0015D6F8
		Private Sub btnExportExcel_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							Dim visible As Boolean = dataGridViewColumn.Visible
							If visible Then
								dataTable.Columns.Add(dataGridViewColumn.HeaderText)
							End If
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
							Dim dataRow As DataRow = dataTable.Rows.Add(New Object(-1) {})
							Dim num As Integer = 0
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									Dim visible2 As Boolean = Me.dgw.Columns(dataGridViewCell.ColumnIndex).Visible
									If visible2 Then
										Dim dataRow2 As DataRow = dataRow
										Dim num2 As Integer = num
										Dim value As Object = dataGridViewCell.Value
										dataRow2(num2) = If((value IsNot Nothing), value.ToString(), Nothing)
										num += 1
									End If
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
						Dim ixlworksheet As IXLWorksheet = xlworkbook.Worksheets.Add(dataTable, "Export File")
						Try
							For Each ixlcolumn As IXLColumn In ixlworksheet.Columns()
								ixlcolumn.AdjustToContents()
							Next
						Finally
							Dim enumerator4 As IEnumerator(Of IXLColumn)
							If enumerator4 IsNot Nothing Then
								enumerator4.Dispose()
							End If
						End Try
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002293 RID: 8851 RVA: 0x0015F824 File Offset: 0x0015DA24
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))
						End If

				Next
				Me.Label12.Text = Conversions.ToString(num2)
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column17").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column17").Value))
						End If

				Next
				Me.Label13.Text = Conversions.ToString(num4)
				Dim num5 As Integer = Me.dgw.Rows.Count - 1
				Dim num6 As Double
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column15").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column15").Value))
						End If

				Next
				Me.Label14.Text = Conversions.ToString(num6)
				Dim num7 As Integer = Me.dgw.Rows.Count - 1
				Dim num8 As Double
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column18").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column18").Value))
						End If

				Next
				Me.Label15.Text = Conversions.ToString(num8)
				Dim num9 As Integer = Me.dgw.Rows.Count - 1
				Dim num10 As Double
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column1").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column1").Value))
						End If

				Next
				Me.Label16.Text = Conversions.ToString(num10)
				Dim num11 As Integer = Me.dgw.Rows.Count - 1
				Dim num12 As Double
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column4").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column4").Value))
						End If

				Next
				Me.Label17.Text = Conversions.ToString(num12)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.Label12.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label12.Text), 3), "0.000")
			Me.Label13.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label13.Text), 2), "0.00")
			Me.Label14.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label14.Text), 2), "0.00")
			Me.Label15.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Me.Label16.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label16.Text), 2), "0.00")
			Me.Label17.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label17.Text), 2), "0.00")
		End Sub

		' Token: 0x06002294 RID: 8852 RVA: 0x0015FD7C File Offset: 0x0015DF7C
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
	End Class
End Namespace
