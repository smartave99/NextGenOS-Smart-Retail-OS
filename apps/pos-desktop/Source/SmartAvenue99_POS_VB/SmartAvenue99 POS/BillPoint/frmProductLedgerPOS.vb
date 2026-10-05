Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000360 RID: 864
	<DesignerGenerated()>
	Public Partial Class frmProductLedgerPOS
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CC5A RID: 52314 RVA: 0x007FCEB4 File Offset: 0x007FB0B4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductLedgerPOS_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductLedgerPOS_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmProductLedgerPOS_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005047 RID: 20551
		' (get) Token: 0x0600CC5D RID: 52317 RVA: 0x0005AD76 File Offset: 0x00058F76
		' (set) Token: 0x0600CC5E RID: 52318 RVA: 0x007FED1C File Offset: 0x007FCF1C
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

		' Token: 0x17005048 RID: 20552
		' (get) Token: 0x0600CC5F RID: 52319 RVA: 0x0005AD80 File Offset: 0x00058F80
		' (set) Token: 0x0600CC60 RID: 52320 RVA: 0x007FED60 File Offset: 0x007FCF60
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005049 RID: 20553
		' (get) Token: 0x0600CC61 RID: 52321 RVA: 0x0005AD8A File Offset: 0x00058F8A
		' (set) Token: 0x0600CC62 RID: 52322 RVA: 0x0005AD94 File Offset: 0x00058F94
		Friend Overridable Property Label1 As Label

		' Token: 0x1700504A RID: 20554
		' (get) Token: 0x0600CC63 RID: 52323 RVA: 0x0005AD9D File Offset: 0x00058F9D
		' (set) Token: 0x0600CC64 RID: 52324 RVA: 0x0005ADA7 File Offset: 0x00058FA7
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x1700504B RID: 20555
		' (get) Token: 0x0600CC65 RID: 52325 RVA: 0x0005ADB0 File Offset: 0x00058FB0
		' (set) Token: 0x0600CC66 RID: 52326 RVA: 0x0005ADBA File Offset: 0x00058FBA
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700504C RID: 20556
		' (get) Token: 0x0600CC67 RID: 52327 RVA: 0x0005ADC3 File Offset: 0x00058FC3
		' (set) Token: 0x0600CC68 RID: 52328 RVA: 0x0005ADCD File Offset: 0x00058FCD
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700504D RID: 20557
		' (get) Token: 0x0600CC69 RID: 52329 RVA: 0x0005ADD6 File Offset: 0x00058FD6
		' (set) Token: 0x0600CC6A RID: 52330 RVA: 0x0005ADE0 File Offset: 0x00058FE0
		Friend Overridable Property Label2 As Label

		' Token: 0x1700504E RID: 20558
		' (get) Token: 0x0600CC6B RID: 52331 RVA: 0x0005ADE9 File Offset: 0x00058FE9
		' (set) Token: 0x0600CC6C RID: 52332 RVA: 0x0005ADF3 File Offset: 0x00058FF3
		Friend Overridable Property Label3 As Label

		' Token: 0x1700504F RID: 20559
		' (get) Token: 0x0600CC6D RID: 52333 RVA: 0x0005ADFC File Offset: 0x00058FFC
		' (set) Token: 0x0600CC6E RID: 52334 RVA: 0x007FEDA4 File Offset: 0x007FCFA4
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005050 RID: 20560
		' (get) Token: 0x0600CC6F RID: 52335 RVA: 0x0005AE06 File Offset: 0x00059006
		' (set) Token: 0x0600CC70 RID: 52336 RVA: 0x007FEDE8 File Offset: 0x007FCFE8
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005051 RID: 20561
		' (get) Token: 0x0600CC71 RID: 52337 RVA: 0x0005AE10 File Offset: 0x00059010
		' (set) Token: 0x0600CC72 RID: 52338 RVA: 0x0005AE1A File Offset: 0x0005901A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005052 RID: 20562
		' (get) Token: 0x0600CC73 RID: 52339 RVA: 0x0005AE23 File Offset: 0x00059023
		' (set) Token: 0x0600CC74 RID: 52340 RVA: 0x0005AE2D File Offset: 0x0005902D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005053 RID: 20563
		' (get) Token: 0x0600CC75 RID: 52341 RVA: 0x0005AE36 File Offset: 0x00059036
		' (set) Token: 0x0600CC76 RID: 52342 RVA: 0x0005AE40 File Offset: 0x00059040
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005054 RID: 20564
		' (get) Token: 0x0600CC77 RID: 52343 RVA: 0x0005AE49 File Offset: 0x00059049
		' (set) Token: 0x0600CC78 RID: 52344 RVA: 0x0005AE53 File Offset: 0x00059053
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17005055 RID: 20565
		' (get) Token: 0x0600CC79 RID: 52345 RVA: 0x0005AE5C File Offset: 0x0005905C
		' (set) Token: 0x0600CC7A RID: 52346 RVA: 0x0005AE66 File Offset: 0x00059066
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005056 RID: 20566
		' (get) Token: 0x0600CC7B RID: 52347 RVA: 0x0005AE6F File Offset: 0x0005906F
		' (set) Token: 0x0600CC7C RID: 52348 RVA: 0x0005AE79 File Offset: 0x00059079
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005057 RID: 20567
		' (get) Token: 0x0600CC7D RID: 52349 RVA: 0x0005AE82 File Offset: 0x00059082
		' (set) Token: 0x0600CC7E RID: 52350 RVA: 0x0005AE8C File Offset: 0x0005908C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005058 RID: 20568
		' (get) Token: 0x0600CC7F RID: 52351 RVA: 0x0005AE95 File Offset: 0x00059095
		' (set) Token: 0x0600CC80 RID: 52352 RVA: 0x0005AE9F File Offset: 0x0005909F
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005059 RID: 20569
		' (get) Token: 0x0600CC81 RID: 52353 RVA: 0x0005AEA8 File Offset: 0x000590A8
		' (set) Token: 0x0600CC82 RID: 52354 RVA: 0x0005AEB2 File Offset: 0x000590B2
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700505A RID: 20570
		' (get) Token: 0x0600CC83 RID: 52355 RVA: 0x0005AEBB File Offset: 0x000590BB
		' (set) Token: 0x0600CC84 RID: 52356 RVA: 0x0005AEC5 File Offset: 0x000590C5
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700505B RID: 20571
		' (get) Token: 0x0600CC85 RID: 52357 RVA: 0x0005AECE File Offset: 0x000590CE
		' (set) Token: 0x0600CC86 RID: 52358 RVA: 0x0005AED8 File Offset: 0x000590D8
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700505C RID: 20572
		' (get) Token: 0x0600CC87 RID: 52359 RVA: 0x0005AEE1 File Offset: 0x000590E1
		' (set) Token: 0x0600CC88 RID: 52360 RVA: 0x0005AEEB File Offset: 0x000590EB
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700505D RID: 20573
		' (get) Token: 0x0600CC89 RID: 52361 RVA: 0x0005AEF4 File Offset: 0x000590F4
		' (set) Token: 0x0600CC8A RID: 52362 RVA: 0x0005AEFE File Offset: 0x000590FE
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700505E RID: 20574
		' (get) Token: 0x0600CC8B RID: 52363 RVA: 0x0005AF07 File Offset: 0x00059107
		' (set) Token: 0x0600CC8C RID: 52364 RVA: 0x0005AF11 File Offset: 0x00059111
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700505F RID: 20575
		' (get) Token: 0x0600CC8D RID: 52365 RVA: 0x0005AF1A File Offset: 0x0005911A
		' (set) Token: 0x0600CC8E RID: 52366 RVA: 0x0005AF24 File Offset: 0x00059124
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17005060 RID: 20576
		' (get) Token: 0x0600CC8F RID: 52367 RVA: 0x0005AF2D File Offset: 0x0005912D
		' (set) Token: 0x0600CC90 RID: 52368 RVA: 0x0005AF37 File Offset: 0x00059137
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17005061 RID: 20577
		' (get) Token: 0x0600CC91 RID: 52369 RVA: 0x0005AF40 File Offset: 0x00059140
		' (set) Token: 0x0600CC92 RID: 52370 RVA: 0x007FEE2C File Offset: 0x007FD02C
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005062 RID: 20578
		' (get) Token: 0x0600CC93 RID: 52371 RVA: 0x0005AF4A File Offset: 0x0005914A
		' (set) Token: 0x0600CC94 RID: 52372 RVA: 0x0005AF54 File Offset: 0x00059154
		Friend Overridable Property Label4 As Label

		' Token: 0x17005063 RID: 20579
		' (get) Token: 0x0600CC95 RID: 52373 RVA: 0x0005AF5D File Offset: 0x0005915D
		' (set) Token: 0x0600CC96 RID: 52374 RVA: 0x0005AF67 File Offset: 0x00059167
		Friend Overridable Property Label5 As Label

		' Token: 0x17005064 RID: 20580
		' (get) Token: 0x0600CC97 RID: 52375 RVA: 0x0005AF70 File Offset: 0x00059170
		' (set) Token: 0x0600CC98 RID: 52376 RVA: 0x007FEE70 File Offset: 0x007FD070
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005065 RID: 20581
		' (get) Token: 0x0600CC99 RID: 52377 RVA: 0x0005AF7A File Offset: 0x0005917A
		' (set) Token: 0x0600CC9A RID: 52378 RVA: 0x0005AF84 File Offset: 0x00059184
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17005066 RID: 20582
		' (get) Token: 0x0600CC9B RID: 52379 RVA: 0x0005AF8D File Offset: 0x0005918D
		' (set) Token: 0x0600CC9C RID: 52380 RVA: 0x0005AF97 File Offset: 0x00059197
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17005067 RID: 20583
		' (get) Token: 0x0600CC9D RID: 52381 RVA: 0x0005AFA0 File Offset: 0x000591A0
		' (set) Token: 0x0600CC9E RID: 52382 RVA: 0x0005AFAA File Offset: 0x000591AA
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17005068 RID: 20584
		' (get) Token: 0x0600CC9F RID: 52383 RVA: 0x0005AFB3 File Offset: 0x000591B3
		' (set) Token: 0x0600CCA0 RID: 52384 RVA: 0x0005AFBD File Offset: 0x000591BD
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17005069 RID: 20585
		' (get) Token: 0x0600CCA1 RID: 52385 RVA: 0x0005AFC6 File Offset: 0x000591C6
		' (set) Token: 0x0600CCA2 RID: 52386 RVA: 0x0005AFD0 File Offset: 0x000591D0
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x1700506A RID: 20586
		' (get) Token: 0x0600CCA3 RID: 52387 RVA: 0x0005AFD9 File Offset: 0x000591D9
		' (set) Token: 0x0600CCA4 RID: 52388 RVA: 0x0005AFE3 File Offset: 0x000591E3
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x1700506B RID: 20587
		' (get) Token: 0x0600CCA5 RID: 52389 RVA: 0x0005AFEC File Offset: 0x000591EC
		' (set) Token: 0x0600CCA6 RID: 52390 RVA: 0x0005AFF6 File Offset: 0x000591F6
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x1700506C RID: 20588
		' (get) Token: 0x0600CCA7 RID: 52391 RVA: 0x0005AFFF File Offset: 0x000591FF
		' (set) Token: 0x0600CCA8 RID: 52392 RVA: 0x0005B009 File Offset: 0x00059209
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x1700506D RID: 20589
		' (get) Token: 0x0600CCA9 RID: 52393 RVA: 0x0005B012 File Offset: 0x00059212
		' (set) Token: 0x0600CCAA RID: 52394 RVA: 0x0005B01C File Offset: 0x0005921C
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x1700506E RID: 20590
		' (get) Token: 0x0600CCAB RID: 52395 RVA: 0x0005B025 File Offset: 0x00059225
		' (set) Token: 0x0600CCAC RID: 52396 RVA: 0x0005B02F File Offset: 0x0005922F
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x1700506F RID: 20591
		' (get) Token: 0x0600CCAD RID: 52397 RVA: 0x0005B038 File Offset: 0x00059238
		' (set) Token: 0x0600CCAE RID: 52398 RVA: 0x0005B042 File Offset: 0x00059242
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17005070 RID: 20592
		' (get) Token: 0x0600CCAF RID: 52399 RVA: 0x0005B04B File Offset: 0x0005924B
		' (set) Token: 0x0600CCB0 RID: 52400 RVA: 0x0005B055 File Offset: 0x00059255
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17005071 RID: 20593
		' (get) Token: 0x0600CCB1 RID: 52401 RVA: 0x0005B05E File Offset: 0x0005925E
		' (set) Token: 0x0600CCB2 RID: 52402 RVA: 0x0005B068 File Offset: 0x00059268
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17005072 RID: 20594
		' (get) Token: 0x0600CCB3 RID: 52403 RVA: 0x0005B071 File Offset: 0x00059271
		' (set) Token: 0x0600CCB4 RID: 52404 RVA: 0x0005B07B File Offset: 0x0005927B
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17005073 RID: 20595
		' (get) Token: 0x0600CCB5 RID: 52405 RVA: 0x0005B084 File Offset: 0x00059284
		' (set) Token: 0x0600CCB6 RID: 52406 RVA: 0x0005B08E File Offset: 0x0005928E
		Friend Overridable Property Label6 As Label

		' Token: 0x17005074 RID: 20596
		' (get) Token: 0x0600CCB7 RID: 52407 RVA: 0x0005B097 File Offset: 0x00059297
		' (set) Token: 0x0600CCB8 RID: 52408 RVA: 0x0005B0A1 File Offset: 0x000592A1
		Friend Overridable Property Label7 As Label

		' Token: 0x17005075 RID: 20597
		' (get) Token: 0x0600CCB9 RID: 52409 RVA: 0x0005B0AA File Offset: 0x000592AA
		' (set) Token: 0x0600CCBA RID: 52410 RVA: 0x0005B0B4 File Offset: 0x000592B4
		Friend Overridable Property lblBarcode As Label

		' Token: 0x0600CCBB RID: 52411 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600CCBC RID: 52412 RVA: 0x007FEEB4 File Offset: 0x007FD0B4
		Private Sub frmProductLedgerPOS_Load(sender As Object, e As EventArgs)
			Me.getdata()
			Me.getdata1()
			Me.dgw.Focus()
			Me.dgw.ClearSelection()
			Me.DataGridView1.ClearSelection()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = Color.Red
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = Color.Red
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.Red
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.Red
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.DarkViolet
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.DarkViolet
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkViolet
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkViolet
		End Sub

		' Token: 0x0600CCBD RID: 52413 RVA: 0x007FEFA4 File Offset: 0x007FD1A4
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.TextBox3.Text + " RTRIM(Product.ProductName), RTRIM(Stock_Product.Barcode), (Stock_Product.TaxableAmt / Stock_Product.Qty),((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), Stock_Product.MRP, RTRIM(PurchaseUnit), RTRIM(Stock.InvoiceNo), Stock.Date, RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), Stock_Product.CGSTPer, Stock_Product.SGSTPer, Stock_Product.IGSTPer, Stock_Product.CESSPer FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID WHERE PID=@d1 and Stock_Product.Barcode=@d2 order by Stock.Date DESC, Stock.ST_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CCBE RID: 52414 RVA: 0x007FF1C4 File Offset: 0x007FD3C4
		Private Sub getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.TextBox3.Text + " RTRIM(Product.ProductName), RTRIM(Invoice_Product.Barcode),(Invoice_Product.TaxableAmt / Invoice_Product.Qty), ((Invoice_Product.TaxableAmt + Invoice_Product.CGSTAmt + Invoice_Product.SGSTAmt + Invoice_Product.IGSTAmt + Invoice_Product.CESSAmt) / Invoice_Product.Qty), Invoice_Product.MRP, RTRIM(SalesUnit),RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), Invoice_Product.CGSTPer, Invoice_Product.SGSTPer, Invoice_Product.IGSTPer, Invoice_Product.CESSPer FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where PID=@d1 and Invoice_Product.Barcode=@d2 order by Invoiceinfo.InvoiceDate DESC, Invoiceinfo.Inv_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CCBF RID: 52415 RVA: 0x007FF3C4 File Offset: 0x007FD5C4
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

		' Token: 0x0600CCC0 RID: 52416 RVA: 0x007FF4AC File Offset: 0x007FD6AC
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600CCC1 RID: 52417 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProductLedgerPOS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CCC2 RID: 52418 RVA: 0x007FF594 File Offset: 0x007FD794
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.TextBox3.Text + " RTRIM(Product.ProductName), RTRIM(Stock_Product.Barcode), (Stock_Product.TaxableAmt / Stock_Product.Qty),((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), Stock_Product.MRP, RTRIM(PurchaseUnit), RTRIM(Stock.InvoiceNo), Stock.Date, RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), Stock_Product.CGSTPer, Stock_Product.SGSTPer, Stock_Product.IGSTPer, Stock_Product.CESSPer FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID WHERE PID=@d1 and Stock_Product.Barcode=@d4 order by Stock.Date DESC, Stock.ST_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Product.ProductName), RTRIM(Invoice_Product.Barcode),(Invoice_Product.TaxableAmt / Invoice_Product.Qty),(Invoice_Product.TotalAmount / Invoice_Product.Qty), Invoice_Product.MRP,RTRIM(SalesUnit),RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), Invoice_Product.CGSTPer, Invoice_Product.SGSTPer, Invoice_Product.IGSTPer, Invoice_Product.CESSPer FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where PID=@d3 and Invoice_Product.Barcode=@d4 and (Invoice_Product.TaxableAmt / Invoice_Product.Qty) between @d1 and @d2 order by Invoiceinfo.InvoiceDate DESC, Invoiceinfo.Inv_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x0600CCC3 RID: 52419 RVA: 0x007FFA24 File Offset: 0x007FDC24
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = "8"
			Me.getdata()
			Me.getdata1()
			Me.dgw.Focus()
			Me.dgw.ClearSelection()
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x0600CCC4 RID: 52420 RVA: 0x0005B0BD File Offset: 0x000592BD
		Private Sub frmProductLedgerPOS_Closing(sender As Object, e As CancelEventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.dgw.Focus()
		End Sub

		' Token: 0x0600CCC5 RID: 52421 RVA: 0x0005B0EE File Offset: 0x000592EE
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.getdata()
			Me.getdata1()
		End Sub
	End Class
End Namespace
