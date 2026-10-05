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
	' Token: 0x0200056C RID: 1388
	<DesignerGenerated()>
	Public Partial Class frmSalesReturnRecord_GSTR
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010DD7 RID: 69079 RVA: 0x00074122 File Offset: 0x00072322
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesReturnRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700688F RID: 26767
		' (get) Token: 0x06010DDA RID: 69082 RVA: 0x00074154 File Offset: 0x00072354
		' (set) Token: 0x06010DDB RID: 69083 RVA: 0x0007415E File Offset: 0x0007235E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006890 RID: 26768
		' (get) Token: 0x06010DDC RID: 69084 RVA: 0x00074167 File Offset: 0x00072367
		' (set) Token: 0x06010DDD RID: 69085 RVA: 0x009D1BAC File Offset: 0x009CFDAC
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

		' Token: 0x17006891 RID: 26769
		' (get) Token: 0x06010DDE RID: 69086 RVA: 0x00074171 File Offset: 0x00072371
		' (set) Token: 0x06010DDF RID: 69087 RVA: 0x0007417B File Offset: 0x0007237B
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006892 RID: 26770
		' (get) Token: 0x06010DE0 RID: 69088 RVA: 0x00074184 File Offset: 0x00072384
		' (set) Token: 0x06010DE1 RID: 69089 RVA: 0x0007418E File Offset: 0x0007238E
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006893 RID: 26771
		' (get) Token: 0x06010DE2 RID: 69090 RVA: 0x00074197 File Offset: 0x00072397
		' (set) Token: 0x06010DE3 RID: 69091 RVA: 0x000741A1 File Offset: 0x000723A1
		Friend Overridable Property Label2 As Label

		' Token: 0x17006894 RID: 26772
		' (get) Token: 0x06010DE4 RID: 69092 RVA: 0x000741AA File Offset: 0x000723AA
		' (set) Token: 0x06010DE5 RID: 69093 RVA: 0x000741B4 File Offset: 0x000723B4
		Friend Overridable Property Label4 As Label

		' Token: 0x17006895 RID: 26773
		' (get) Token: 0x06010DE6 RID: 69094 RVA: 0x000741BD File Offset: 0x000723BD
		' (set) Token: 0x06010DE7 RID: 69095 RVA: 0x000741C7 File Offset: 0x000723C7
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006896 RID: 26774
		' (get) Token: 0x06010DE8 RID: 69096 RVA: 0x000741D0 File Offset: 0x000723D0
		' (set) Token: 0x06010DE9 RID: 69097 RVA: 0x000741DA File Offset: 0x000723DA
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006897 RID: 26775
		' (get) Token: 0x06010DEA RID: 69098 RVA: 0x000741E3 File Offset: 0x000723E3
		' (set) Token: 0x06010DEB RID: 69099 RVA: 0x000741ED File Offset: 0x000723ED
		Friend Overridable Property Label1 As Label

		' Token: 0x17006898 RID: 26776
		' (get) Token: 0x06010DEC RID: 69100 RVA: 0x000741F6 File Offset: 0x000723F6
		' (set) Token: 0x06010DED RID: 69101 RVA: 0x00074200 File Offset: 0x00072400
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006899 RID: 26777
		' (get) Token: 0x06010DEE RID: 69102 RVA: 0x00074209 File Offset: 0x00072409
		' (set) Token: 0x06010DEF RID: 69103 RVA: 0x00074213 File Offset: 0x00072413
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700689A RID: 26778
		' (get) Token: 0x06010DF0 RID: 69104 RVA: 0x0007421C File Offset: 0x0007241C
		' (set) Token: 0x06010DF1 RID: 69105 RVA: 0x009D1BF0 File Offset: 0x009CFDF0
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

		' Token: 0x1700689B RID: 26779
		' (get) Token: 0x06010DF2 RID: 69106 RVA: 0x00074226 File Offset: 0x00072426
		' (set) Token: 0x06010DF3 RID: 69107 RVA: 0x00074230 File Offset: 0x00072430
		Friend Overridable Property Label5 As Label

		' Token: 0x1700689C RID: 26780
		' (get) Token: 0x06010DF4 RID: 69108 RVA: 0x00074239 File Offset: 0x00072439
		' (set) Token: 0x06010DF5 RID: 69109 RVA: 0x00074243 File Offset: 0x00072443
		Friend Overridable Property Label3 As Label

		' Token: 0x1700689D RID: 26781
		' (get) Token: 0x06010DF6 RID: 69110 RVA: 0x0007424C File Offset: 0x0007244C
		' (set) Token: 0x06010DF7 RID: 69111 RVA: 0x009D1C34 File Offset: 0x009CFE34
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
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700689E RID: 26782
		' (get) Token: 0x06010DF8 RID: 69112 RVA: 0x00074256 File Offset: 0x00072456
		' (set) Token: 0x06010DF9 RID: 69113 RVA: 0x009D1C78 File Offset: 0x009CFE78
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700689F RID: 26783
		' (get) Token: 0x06010DFA RID: 69114 RVA: 0x00074260 File Offset: 0x00072460
		' (set) Token: 0x06010DFB RID: 69115 RVA: 0x0007426A File Offset: 0x0007246A
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170068A0 RID: 26784
		' (get) Token: 0x06010DFC RID: 69116 RVA: 0x00074273 File Offset: 0x00072473
		' (set) Token: 0x06010DFD RID: 69117 RVA: 0x009D1CBC File Offset: 0x009CFEBC
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170068A1 RID: 26785
		' (get) Token: 0x06010DFE RID: 69118 RVA: 0x0007427D File Offset: 0x0007247D
		' (set) Token: 0x06010DFF RID: 69119 RVA: 0x00074287 File Offset: 0x00072487
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170068A2 RID: 26786
		' (get) Token: 0x06010E00 RID: 69120 RVA: 0x00074290 File Offset: 0x00072490
		' (set) Token: 0x06010E01 RID: 69121 RVA: 0x0007429A File Offset: 0x0007249A
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170068A3 RID: 26787
		' (get) Token: 0x06010E02 RID: 69122 RVA: 0x000742A3 File Offset: 0x000724A3
		' (set) Token: 0x06010E03 RID: 69123 RVA: 0x000742AD File Offset: 0x000724AD
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170068A4 RID: 26788
		' (get) Token: 0x06010E04 RID: 69124 RVA: 0x000742B6 File Offset: 0x000724B6
		' (set) Token: 0x06010E05 RID: 69125 RVA: 0x000742C0 File Offset: 0x000724C0
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170068A5 RID: 26789
		' (get) Token: 0x06010E06 RID: 69126 RVA: 0x000742C9 File Offset: 0x000724C9
		' (set) Token: 0x06010E07 RID: 69127 RVA: 0x000742D3 File Offset: 0x000724D3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170068A6 RID: 26790
		' (get) Token: 0x06010E08 RID: 69128 RVA: 0x000742DC File Offset: 0x000724DC
		' (set) Token: 0x06010E09 RID: 69129 RVA: 0x000742E6 File Offset: 0x000724E6
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170068A7 RID: 26791
		' (get) Token: 0x06010E0A RID: 69130 RVA: 0x000742EF File Offset: 0x000724EF
		' (set) Token: 0x06010E0B RID: 69131 RVA: 0x000742F9 File Offset: 0x000724F9
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170068A8 RID: 26792
		' (get) Token: 0x06010E0C RID: 69132 RVA: 0x00074302 File Offset: 0x00072502
		' (set) Token: 0x06010E0D RID: 69133 RVA: 0x0007430C File Offset: 0x0007250C
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170068A9 RID: 26793
		' (get) Token: 0x06010E0E RID: 69134 RVA: 0x00074315 File Offset: 0x00072515
		' (set) Token: 0x06010E0F RID: 69135 RVA: 0x0007431F File Offset: 0x0007251F
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170068AA RID: 26794
		' (get) Token: 0x06010E10 RID: 69136 RVA: 0x00074328 File Offset: 0x00072528
		' (set) Token: 0x06010E11 RID: 69137 RVA: 0x00074332 File Offset: 0x00072532
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170068AB RID: 26795
		' (get) Token: 0x06010E12 RID: 69138 RVA: 0x0007433B File Offset: 0x0007253B
		' (set) Token: 0x06010E13 RID: 69139 RVA: 0x00074345 File Offset: 0x00072545
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170068AC RID: 26796
		' (get) Token: 0x06010E14 RID: 69140 RVA: 0x0007434E File Offset: 0x0007254E
		' (set) Token: 0x06010E15 RID: 69141 RVA: 0x00074358 File Offset: 0x00072558
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170068AD RID: 26797
		' (get) Token: 0x06010E16 RID: 69142 RVA: 0x00074361 File Offset: 0x00072561
		' (set) Token: 0x06010E17 RID: 69143 RVA: 0x0007436B File Offset: 0x0007256B
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170068AE RID: 26798
		' (get) Token: 0x06010E18 RID: 69144 RVA: 0x00074374 File Offset: 0x00072574
		' (set) Token: 0x06010E19 RID: 69145 RVA: 0x0007437E File Offset: 0x0007257E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170068AF RID: 26799
		' (get) Token: 0x06010E1A RID: 69146 RVA: 0x00074387 File Offset: 0x00072587
		' (set) Token: 0x06010E1B RID: 69147 RVA: 0x00074391 File Offset: 0x00072591
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170068B0 RID: 26800
		' (get) Token: 0x06010E1C RID: 69148 RVA: 0x0007439A File Offset: 0x0007259A
		' (set) Token: 0x06010E1D RID: 69149 RVA: 0x000743A4 File Offset: 0x000725A4
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170068B1 RID: 26801
		' (get) Token: 0x06010E1E RID: 69150 RVA: 0x000743AD File Offset: 0x000725AD
		' (set) Token: 0x06010E1F RID: 69151 RVA: 0x000743B7 File Offset: 0x000725B7
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170068B2 RID: 26802
		' (get) Token: 0x06010E20 RID: 69152 RVA: 0x000743C0 File Offset: 0x000725C0
		' (set) Token: 0x06010E21 RID: 69153 RVA: 0x000743CA File Offset: 0x000725CA
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170068B3 RID: 26803
		' (get) Token: 0x06010E22 RID: 69154 RVA: 0x000743D3 File Offset: 0x000725D3
		' (set) Token: 0x06010E23 RID: 69155 RVA: 0x000743DD File Offset: 0x000725DD
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170068B4 RID: 26804
		' (get) Token: 0x06010E24 RID: 69156 RVA: 0x000743E6 File Offset: 0x000725E6
		' (set) Token: 0x06010E25 RID: 69157 RVA: 0x000743F0 File Offset: 0x000725F0
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170068B5 RID: 26805
		' (get) Token: 0x06010E26 RID: 69158 RVA: 0x000743F9 File Offset: 0x000725F9
		' (set) Token: 0x06010E27 RID: 69159 RVA: 0x00074403 File Offset: 0x00072603
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170068B6 RID: 26806
		' (get) Token: 0x06010E28 RID: 69160 RVA: 0x0007440C File Offset: 0x0007260C
		' (set) Token: 0x06010E29 RID: 69161 RVA: 0x00074416 File Offset: 0x00072616
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170068B7 RID: 26807
		' (get) Token: 0x06010E2A RID: 69162 RVA: 0x0007441F File Offset: 0x0007261F
		' (set) Token: 0x06010E2B RID: 69163 RVA: 0x00074429 File Offset: 0x00072629
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170068B8 RID: 26808
		' (get) Token: 0x06010E2C RID: 69164 RVA: 0x00074432 File Offset: 0x00072632
		' (set) Token: 0x06010E2D RID: 69165 RVA: 0x0007443C File Offset: 0x0007263C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170068B9 RID: 26809
		' (get) Token: 0x06010E2E RID: 69166 RVA: 0x00074445 File Offset: 0x00072645
		' (set) Token: 0x06010E2F RID: 69167 RVA: 0x0007444F File Offset: 0x0007264F
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170068BA RID: 26810
		' (get) Token: 0x06010E30 RID: 69168 RVA: 0x00074458 File Offset: 0x00072658
		' (set) Token: 0x06010E31 RID: 69169 RVA: 0x009D1D00 File Offset: 0x009CFF00
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

		' Token: 0x170068BB RID: 26811
		' (get) Token: 0x06010E32 RID: 69170 RVA: 0x00074462 File Offset: 0x00072662
		' (set) Token: 0x06010E33 RID: 69171 RVA: 0x009D1D44 File Offset: 0x009CFF44
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

		' Token: 0x170068BC RID: 26812
		' (get) Token: 0x06010E34 RID: 69172 RVA: 0x0007446C File Offset: 0x0007266C
		' (set) Token: 0x06010E35 RID: 69173 RVA: 0x009D1D88 File Offset: 0x009CFF88
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010E36 RID: 69174 RVA: 0x009D1DCC File Offset: 0x009CFFCC
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

		' Token: 0x06010E37 RID: 69175 RVA: 0x009D1EA0 File Offset: 0x009D00A0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount,RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
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

		' Token: 0x06010E38 RID: 69176 RVA: 0x009D217C File Offset: 0x009D037C
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010E39 RID: 69177 RVA: 0x009D2214 File Offset: 0x009D0414
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

		' Token: 0x06010E3A RID: 69178 RVA: 0x009D238C File Offset: 0x009D058C
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

		' Token: 0x06010E3B RID: 69179 RVA: 0x009D2458 File Offset: 0x009D0658
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

		' Token: 0x06010E3C RID: 69180 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010E3D RID: 69181 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010E3E RID: 69182 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010E3F RID: 69183 RVA: 0x009D2524 File Offset: 0x009D0724
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

		' Token: 0x06010E40 RID: 69184 RVA: 0x00074476 File Offset: 0x00072676
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06010E41 RID: 69185 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesReturnRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010E42 RID: 69186 RVA: 0x009D260C File Offset: 0x009D080C
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					Me.ComboBox2.SelectedIndex = -1
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and SalesReturn.SRNo=N'" + Me.TextBox1.Text + "' order by SalesReturn.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and InvoiceInfo.InvoiceNo=N'" + Me.TextBox1.Text + "' order by SalesReturn.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and Customer.Name=N'" + Me.TextBox1.Text + "' order by SalesReturn.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and Product.ProductName=N'" + Me.TextBox1.Text + "' order by SalesReturn.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and SalesReturn_Join.Barcode=N'" + Me.TextBox1.Text + "' order by SalesReturn.Date", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									End If
								End If
							End If
						End If
					End If
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
			End If
		End Sub

		' Token: 0x06010E43 RID: 69187 RVA: 0x00074498 File Offset: 0x00072698
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010E44 RID: 69188 RVA: 0x000744CD File Offset: 0x000726CD
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.TextBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010E45 RID: 69189 RVA: 0x009D2C48 File Offset: 0x009D0E48
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

		' Token: 0x06010E46 RID: 69190 RVA: 0x009D2D60 File Offset: 0x009D0F60
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.TextBox1.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and NOT InvoiceInfo.TaxType='NON GST' order by SalesReturn.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount, RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.Date between @d1 and @d2 and InvoiceInfo.TaxType='NON GST' order by SalesReturn.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010E47 RID: 69191 RVA: 0x009D3104 File Offset: 0x009D1304
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount,RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
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

		' Token: 0x06010E48 RID: 69192 RVA: 0x009D340C File Offset: 0x009D160C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06010E49 RID: 69193 RVA: 0x009D345C File Offset: 0x009D165C
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
