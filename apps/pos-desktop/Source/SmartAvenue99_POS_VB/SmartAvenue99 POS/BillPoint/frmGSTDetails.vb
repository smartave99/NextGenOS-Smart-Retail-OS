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
	' Token: 0x02000346 RID: 838
	<DesignerGenerated()>
	Public Partial Class frmGSTDetails
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C414 RID: 50196 RVA: 0x00057A88 File Offset: 0x00055C88
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTDetails_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGSTDetails_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004DD6 RID: 19926
		' (get) Token: 0x0600C417 RID: 50199 RVA: 0x00057ABA File Offset: 0x00055CBA
		' (set) Token: 0x0600C418 RID: 50200 RVA: 0x00057AC4 File Offset: 0x00055CC4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004DD7 RID: 19927
		' (get) Token: 0x0600C419 RID: 50201 RVA: 0x00057ACD File Offset: 0x00055CCD
		' (set) Token: 0x0600C41A RID: 50202 RVA: 0x00057AD7 File Offset: 0x00055CD7
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004DD8 RID: 19928
		' (get) Token: 0x0600C41B RID: 50203 RVA: 0x00057AE0 File Offset: 0x00055CE0
		' (set) Token: 0x0600C41C RID: 50204 RVA: 0x00057AEA File Offset: 0x00055CEA
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004DD9 RID: 19929
		' (get) Token: 0x0600C41D RID: 50205 RVA: 0x00057AF3 File Offset: 0x00055CF3
		' (set) Token: 0x0600C41E RID: 50206 RVA: 0x00057AFD File Offset: 0x00055CFD
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004DDA RID: 19930
		' (get) Token: 0x0600C41F RID: 50207 RVA: 0x00057B06 File Offset: 0x00055D06
		' (set) Token: 0x0600C420 RID: 50208 RVA: 0x00057B10 File Offset: 0x00055D10
		Friend Overridable Property Label2 As Label

		' Token: 0x17004DDB RID: 19931
		' (get) Token: 0x0600C421 RID: 50209 RVA: 0x00057B19 File Offset: 0x00055D19
		' (set) Token: 0x0600C422 RID: 50210 RVA: 0x00057B23 File Offset: 0x00055D23
		Friend Overridable Property Label4 As Label

		' Token: 0x17004DDC RID: 19932
		' (get) Token: 0x0600C423 RID: 50211 RVA: 0x00057B2C File Offset: 0x00055D2C
		' (set) Token: 0x0600C424 RID: 50212 RVA: 0x00057B36 File Offset: 0x00055D36
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004DDD RID: 19933
		' (get) Token: 0x0600C425 RID: 50213 RVA: 0x00057B3F File Offset: 0x00055D3F
		' (set) Token: 0x0600C426 RID: 50214 RVA: 0x007C94E8 File Offset: 0x007C76E8
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

		' Token: 0x17004DDE RID: 19934
		' (get) Token: 0x0600C427 RID: 50215 RVA: 0x00057B49 File Offset: 0x00055D49
		' (set) Token: 0x0600C428 RID: 50216 RVA: 0x00057B53 File Offset: 0x00055D53
		Friend Overridable Property Label1 As Label

		' Token: 0x17004DDF RID: 19935
		' (get) Token: 0x0600C429 RID: 50217 RVA: 0x00057B5C File Offset: 0x00055D5C
		' (set) Token: 0x0600C42A RID: 50218 RVA: 0x00057B66 File Offset: 0x00055D66
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004DE0 RID: 19936
		' (get) Token: 0x0600C42B RID: 50219 RVA: 0x00057B6F File Offset: 0x00055D6F
		' (set) Token: 0x0600C42C RID: 50220 RVA: 0x00057B79 File Offset: 0x00055D79
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004DE1 RID: 19937
		' (get) Token: 0x0600C42D RID: 50221 RVA: 0x00057B82 File Offset: 0x00055D82
		' (set) Token: 0x0600C42E RID: 50222 RVA: 0x00057B8C File Offset: 0x00055D8C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004DE2 RID: 19938
		' (get) Token: 0x0600C42F RID: 50223 RVA: 0x00057B95 File Offset: 0x00055D95
		' (set) Token: 0x0600C430 RID: 50224 RVA: 0x00057B9F File Offset: 0x00055D9F
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004DE3 RID: 19939
		' (get) Token: 0x0600C431 RID: 50225 RVA: 0x00057BA8 File Offset: 0x00055DA8
		' (set) Token: 0x0600C432 RID: 50226 RVA: 0x00057BB2 File Offset: 0x00055DB2
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004DE4 RID: 19940
		' (get) Token: 0x0600C433 RID: 50227 RVA: 0x00057BBB File Offset: 0x00055DBB
		' (set) Token: 0x0600C434 RID: 50228 RVA: 0x00057BC5 File Offset: 0x00055DC5
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004DE5 RID: 19941
		' (get) Token: 0x0600C435 RID: 50229 RVA: 0x00057BCE File Offset: 0x00055DCE
		' (set) Token: 0x0600C436 RID: 50230 RVA: 0x00057BD8 File Offset: 0x00055DD8
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17004DE6 RID: 19942
		' (get) Token: 0x0600C437 RID: 50231 RVA: 0x00057BE1 File Offset: 0x00055DE1
		' (set) Token: 0x0600C438 RID: 50232 RVA: 0x00057BEB File Offset: 0x00055DEB
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004DE7 RID: 19943
		' (get) Token: 0x0600C439 RID: 50233 RVA: 0x00057BF4 File Offset: 0x00055DF4
		' (set) Token: 0x0600C43A RID: 50234 RVA: 0x00057BFE File Offset: 0x00055DFE
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004DE8 RID: 19944
		' (get) Token: 0x0600C43B RID: 50235 RVA: 0x00057C07 File Offset: 0x00055E07
		' (set) Token: 0x0600C43C RID: 50236 RVA: 0x00057C11 File Offset: 0x00055E11
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17004DE9 RID: 19945
		' (get) Token: 0x0600C43D RID: 50237 RVA: 0x00057C1A File Offset: 0x00055E1A
		' (set) Token: 0x0600C43E RID: 50238 RVA: 0x00057C24 File Offset: 0x00055E24
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004DEA RID: 19946
		' (get) Token: 0x0600C43F RID: 50239 RVA: 0x00057C2D File Offset: 0x00055E2D
		' (set) Token: 0x0600C440 RID: 50240 RVA: 0x00057C37 File Offset: 0x00055E37
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004DEB RID: 19947
		' (get) Token: 0x0600C441 RID: 50241 RVA: 0x00057C40 File Offset: 0x00055E40
		' (set) Token: 0x0600C442 RID: 50242 RVA: 0x00057C4A File Offset: 0x00055E4A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004DEC RID: 19948
		' (get) Token: 0x0600C443 RID: 50243 RVA: 0x00057C53 File Offset: 0x00055E53
		' (set) Token: 0x0600C444 RID: 50244 RVA: 0x00057C5D File Offset: 0x00055E5D
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004DED RID: 19949
		' (get) Token: 0x0600C445 RID: 50245 RVA: 0x00057C66 File Offset: 0x00055E66
		' (set) Token: 0x0600C446 RID: 50246 RVA: 0x00057C70 File Offset: 0x00055E70
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17004DEE RID: 19950
		' (get) Token: 0x0600C447 RID: 50247 RVA: 0x00057C79 File Offset: 0x00055E79
		' (set) Token: 0x0600C448 RID: 50248 RVA: 0x00057C83 File Offset: 0x00055E83
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17004DEF RID: 19951
		' (get) Token: 0x0600C449 RID: 50249 RVA: 0x00057C8C File Offset: 0x00055E8C
		' (set) Token: 0x0600C44A RID: 50250 RVA: 0x00057C96 File Offset: 0x00055E96
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17004DF0 RID: 19952
		' (get) Token: 0x0600C44B RID: 50251 RVA: 0x00057C9F File Offset: 0x00055E9F
		' (set) Token: 0x0600C44C RID: 50252 RVA: 0x00057CA9 File Offset: 0x00055EA9
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004DF1 RID: 19953
		' (get) Token: 0x0600C44D RID: 50253 RVA: 0x00057CB2 File Offset: 0x00055EB2
		' (set) Token: 0x0600C44E RID: 50254 RVA: 0x00057CBC File Offset: 0x00055EBC
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17004DF2 RID: 19954
		' (get) Token: 0x0600C44F RID: 50255 RVA: 0x00057CC5 File Offset: 0x00055EC5
		' (set) Token: 0x0600C450 RID: 50256 RVA: 0x00057CCF File Offset: 0x00055ECF
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004DF3 RID: 19955
		' (get) Token: 0x0600C451 RID: 50257 RVA: 0x00057CD8 File Offset: 0x00055ED8
		' (set) Token: 0x0600C452 RID: 50258 RVA: 0x00057CE2 File Offset: 0x00055EE2
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17004DF4 RID: 19956
		' (get) Token: 0x0600C453 RID: 50259 RVA: 0x00057CEB File Offset: 0x00055EEB
		' (set) Token: 0x0600C454 RID: 50260 RVA: 0x00057CF5 File Offset: 0x00055EF5
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004DF5 RID: 19957
		' (get) Token: 0x0600C455 RID: 50261 RVA: 0x00057CFE File Offset: 0x00055EFE
		' (set) Token: 0x0600C456 RID: 50262 RVA: 0x00057D08 File Offset: 0x00055F08
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17004DF6 RID: 19958
		' (get) Token: 0x0600C457 RID: 50263 RVA: 0x00057D11 File Offset: 0x00055F11
		' (set) Token: 0x0600C458 RID: 50264 RVA: 0x00057D1B File Offset: 0x00055F1B
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17004DF7 RID: 19959
		' (get) Token: 0x0600C459 RID: 50265 RVA: 0x00057D24 File Offset: 0x00055F24
		' (set) Token: 0x0600C45A RID: 50266 RVA: 0x00057D2E File Offset: 0x00055F2E
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17004DF8 RID: 19960
		' (get) Token: 0x0600C45B RID: 50267 RVA: 0x00057D37 File Offset: 0x00055F37
		' (set) Token: 0x0600C45C RID: 50268 RVA: 0x00057D41 File Offset: 0x00055F41
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004DF9 RID: 19961
		' (get) Token: 0x0600C45D RID: 50269 RVA: 0x00057D4A File Offset: 0x00055F4A
		' (set) Token: 0x0600C45E RID: 50270 RVA: 0x007C952C File Offset: 0x007C772C
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004DFA RID: 19962
		' (get) Token: 0x0600C45F RID: 50271 RVA: 0x00057D54 File Offset: 0x00055F54
		' (set) Token: 0x0600C460 RID: 50272 RVA: 0x00057D5E File Offset: 0x00055F5E
		Friend Overridable Property Label3 As Label

		' Token: 0x17004DFB RID: 19963
		' (get) Token: 0x0600C461 RID: 50273 RVA: 0x00057D67 File Offset: 0x00055F67
		' (set) Token: 0x0600C462 RID: 50274 RVA: 0x007C958C File Offset: 0x007C778C
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

		' Token: 0x17004DFC RID: 19964
		' (get) Token: 0x0600C463 RID: 50275 RVA: 0x00057D71 File Offset: 0x00055F71
		' (set) Token: 0x0600C464 RID: 50276 RVA: 0x007C95D0 File Offset: 0x007C77D0
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

		' Token: 0x17004DFD RID: 19965
		' (get) Token: 0x0600C465 RID: 50277 RVA: 0x00057D7B File Offset: 0x00055F7B
		' (set) Token: 0x0600C466 RID: 50278 RVA: 0x007C9614 File Offset: 0x007C7814
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

		' Token: 0x0600C467 RID: 50279 RVA: 0x007C9658 File Offset: 0x007C7858
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

		' Token: 0x0600C468 RID: 50280 RVA: 0x007C972C File Offset: 0x007C792C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.TaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer), (Invoice_Product.CGSTAmt + Invoice_Product.SGSTAmt + Invoice_Product.IGSTAmt), Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoiceinfo.InvoiceDate between @d1 and @d2 and NOT InvoiceInfo.TaxType='NON GST' order by Invoiceinfo.InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C469 RID: 50281 RVA: 0x007C9A14 File Offset: 0x007C7C14
		Private Sub frmGSTDetails_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C46A RID: 50282 RVA: 0x007C9AAC File Offset: 0x007C7CAC
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

		' Token: 0x0600C46B RID: 50283 RVA: 0x007C9C24 File Offset: 0x007C7E24
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
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

		' Token: 0x0600C46C RID: 50284 RVA: 0x007C9CE0 File Offset: 0x007C7EE0
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

		' Token: 0x0600C46D RID: 50285 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C46E RID: 50286 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C46F RID: 50287 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C470 RID: 50288 RVA: 0x007C9DAC File Offset: 0x007C7FAC
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

		' Token: 0x0600C471 RID: 50289 RVA: 0x00057D85 File Offset: 0x00055F85
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.TextBox1.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600C472 RID: 50290 RVA: 0x007C9E94 File Offset: 0x007C8094
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

		' Token: 0x0600C473 RID: 50291 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGSTDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C474 RID: 50292 RVA: 0x007C9FAC File Offset: 0x007C81AC
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.TaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer), (Invoice_Product.CGSTAmt + Invoice_Product.SGSTAmt + Invoice_Product.IGSTAmt), Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer)=@d3 and NOT InvoiceInfo.TaxType='NON GST' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.TextBox1.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600C475 RID: 50293 RVA: 0x007CA2B8 File Offset: 0x007C84B8
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

		' Token: 0x0600C476 RID: 50294 RVA: 0x007CA3F8 File Offset: 0x007C85F8
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.TaxableAmt, (Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer), (Invoice_Product.CGSTAmt + Invoice_Product.SGSTAmt + Invoice_Product.IGSTAmt), Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and NOT InvoiceInfo.TaxType='NON GST' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600C477 RID: 50295 RVA: 0x00057DB8 File Offset: 0x00055FB8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600C478 RID: 50296 RVA: 0x007CA6D8 File Offset: 0x007C88D8
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
