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
Imports BillPoint.My
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005CC RID: 1484
	<DesignerGenerated()>
	Public Partial Class frmServicesRecord1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060120CD RID: 73933 RVA: 0x0007BB76 File Offset: 0x00079D76
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServicesRecord1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700701B RID: 28699
		' (get) Token: 0x060120D0 RID: 73936 RVA: 0x0007BBA8 File Offset: 0x00079DA8
		' (set) Token: 0x060120D1 RID: 73937 RVA: 0x0007BBB2 File Offset: 0x00079DB2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700701C RID: 28700
		' (get) Token: 0x060120D2 RID: 73938 RVA: 0x0007BBBB File Offset: 0x00079DBB
		' (set) Token: 0x060120D3 RID: 73939 RVA: 0x0007BBC5 File Offset: 0x00079DC5
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700701D RID: 28701
		' (get) Token: 0x060120D4 RID: 73940 RVA: 0x0007BBCE File Offset: 0x00079DCE
		' (set) Token: 0x060120D5 RID: 73941 RVA: 0x0007BBD8 File Offset: 0x00079DD8
		Friend Overridable Property Label1 As Label

		' Token: 0x1700701E RID: 28702
		' (get) Token: 0x060120D6 RID: 73942 RVA: 0x0007BBE1 File Offset: 0x00079DE1
		' (set) Token: 0x060120D7 RID: 73943 RVA: 0x00A65878 File Offset: 0x00A63A78
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700701F RID: 28703
		' (get) Token: 0x060120D8 RID: 73944 RVA: 0x0007BBEB File Offset: 0x00079DEB
		' (set) Token: 0x060120D9 RID: 73945 RVA: 0x0007BBF5 File Offset: 0x00079DF5
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17007020 RID: 28704
		' (get) Token: 0x060120DA RID: 73946 RVA: 0x0007BBFE File Offset: 0x00079DFE
		' (set) Token: 0x060120DB RID: 73947 RVA: 0x00A658D8 File Offset: 0x00A63AD8
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007021 RID: 28705
		' (get) Token: 0x060120DC RID: 73948 RVA: 0x0007BC08 File Offset: 0x00079E08
		' (set) Token: 0x060120DD RID: 73949 RVA: 0x00A6591C File Offset: 0x00A63B1C
		Private _btnExportExcel As Button
		Friend Overridable Property btnExportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim button As Button = Me._btnExportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExportExcel = value
				button = Me._btnExportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007022 RID: 28706
		' (get) Token: 0x060120DE RID: 73950 RVA: 0x0007BC12 File Offset: 0x00079E12
		' (set) Token: 0x060120DF RID: 73951 RVA: 0x0007BC1C File Offset: 0x00079E1C
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17007023 RID: 28707
		' (get) Token: 0x060120E0 RID: 73952 RVA: 0x0007BC25 File Offset: 0x00079E25
		' (set) Token: 0x060120E1 RID: 73953 RVA: 0x0007BC2F File Offset: 0x00079E2F
		Friend Overridable Property Label2 As Label

		' Token: 0x17007024 RID: 28708
		' (get) Token: 0x060120E2 RID: 73954 RVA: 0x0007BC38 File Offset: 0x00079E38
		' (set) Token: 0x060120E3 RID: 73955 RVA: 0x0007BC42 File Offset: 0x00079E42
		Friend Overridable Property Label4 As Label

		' Token: 0x17007025 RID: 28709
		' (get) Token: 0x060120E4 RID: 73956 RVA: 0x0007BC4B File Offset: 0x00079E4B
		' (set) Token: 0x060120E5 RID: 73957 RVA: 0x0007BC55 File Offset: 0x00079E55
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17007026 RID: 28710
		' (get) Token: 0x060120E6 RID: 73958 RVA: 0x0007BC5E File Offset: 0x00079E5E
		' (set) Token: 0x060120E7 RID: 73959 RVA: 0x00A65960 File Offset: 0x00A63B60
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007027 RID: 28711
		' (get) Token: 0x060120E8 RID: 73960 RVA: 0x0007BC68 File Offset: 0x00079E68
		' (set) Token: 0x060120E9 RID: 73961 RVA: 0x00A659A4 File Offset: 0x00A63BA4
		Private _cmbServiceCode As ComboBox
		Friend Overridable Property cmbServiceCode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbServiceCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbOrderNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbInvoiceNo_Format
				Dim comboBox As ComboBox = Me._cmbServiceCode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbServiceCode = value
				comboBox = Me._cmbServiceCode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007028 RID: 28712
		' (get) Token: 0x060120EA RID: 73962 RVA: 0x0007BC72 File Offset: 0x00079E72
		' (set) Token: 0x060120EB RID: 73963 RVA: 0x0007BC7C File Offset: 0x00079E7C
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17007029 RID: 28713
		' (get) Token: 0x060120EC RID: 73964 RVA: 0x0007BC85 File Offset: 0x00079E85
		' (set) Token: 0x060120ED RID: 73965 RVA: 0x0007BC8F File Offset: 0x00079E8F
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700702A RID: 28714
		' (get) Token: 0x060120EE RID: 73966 RVA: 0x0007BC98 File Offset: 0x00079E98
		' (set) Token: 0x060120EF RID: 73967 RVA: 0x0007BCA2 File Offset: 0x00079EA2
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700702B RID: 28715
		' (get) Token: 0x060120F0 RID: 73968 RVA: 0x0007BCAB File Offset: 0x00079EAB
		' (set) Token: 0x060120F1 RID: 73969 RVA: 0x0007BCB5 File Offset: 0x00079EB5
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x1700702C RID: 28716
		' (get) Token: 0x060120F2 RID: 73970 RVA: 0x0007BCBE File Offset: 0x00079EBE
		' (set) Token: 0x060120F3 RID: 73971 RVA: 0x0007BCC8 File Offset: 0x00079EC8
		Friend Overridable Property Label3 As Label

		' Token: 0x1700702D RID: 28717
		' (get) Token: 0x060120F4 RID: 73972 RVA: 0x0007BCD1 File Offset: 0x00079ED1
		' (set) Token: 0x060120F5 RID: 73973 RVA: 0x00A65A04 File Offset: 0x00A63C04
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

		' Token: 0x1700702E RID: 28718
		' (get) Token: 0x060120F6 RID: 73974 RVA: 0x0007BCDB File Offset: 0x00079EDB
		' (set) Token: 0x060120F7 RID: 73975 RVA: 0x0007BCE5 File Offset: 0x00079EE5
		Friend Overridable Property Label5 As Label

		' Token: 0x1700702F RID: 28719
		' (get) Token: 0x060120F8 RID: 73976 RVA: 0x0007BCEE File Offset: 0x00079EEE
		' (set) Token: 0x060120F9 RID: 73977 RVA: 0x0007BCF8 File Offset: 0x00079EF8
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17007030 RID: 28720
		' (get) Token: 0x060120FA RID: 73978 RVA: 0x0007BD01 File Offset: 0x00079F01
		' (set) Token: 0x060120FB RID: 73979 RVA: 0x0007BD0B File Offset: 0x00079F0B
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17007031 RID: 28721
		' (get) Token: 0x060120FC RID: 73980 RVA: 0x0007BD14 File Offset: 0x00079F14
		' (set) Token: 0x060120FD RID: 73981 RVA: 0x00A65A48 File Offset: 0x00A63C48
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007032 RID: 28722
		' (get) Token: 0x060120FE RID: 73982 RVA: 0x0007BD1E File Offset: 0x00079F1E
		' (set) Token: 0x060120FF RID: 73983 RVA: 0x0007BD28 File Offset: 0x00079F28
		Friend Overridable Property lblSet As Label

		' Token: 0x17007033 RID: 28723
		' (get) Token: 0x06012100 RID: 73984 RVA: 0x0007BD31 File Offset: 0x00079F31
		' (set) Token: 0x06012101 RID: 73985 RVA: 0x0007BD3B File Offset: 0x00079F3B
		Friend Overridable Property Label6 As Label

		' Token: 0x17007034 RID: 28724
		' (get) Token: 0x06012102 RID: 73986 RVA: 0x0007BD44 File Offset: 0x00079F44
		' (set) Token: 0x06012103 RID: 73987 RVA: 0x0007BD4E File Offset: 0x00079F4E
		Friend Overridable Property cmbStatus As ComboBox

		' Token: 0x17007035 RID: 28725
		' (get) Token: 0x06012104 RID: 73988 RVA: 0x0007BD57 File Offset: 0x00079F57
		' (set) Token: 0x06012105 RID: 73989 RVA: 0x0007BD61 File Offset: 0x00079F61
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17007036 RID: 28726
		' (get) Token: 0x06012106 RID: 73990 RVA: 0x0007BD6A File Offset: 0x00079F6A
		' (set) Token: 0x06012107 RID: 73991 RVA: 0x0007BD74 File Offset: 0x00079F74
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17007037 RID: 28727
		' (get) Token: 0x06012108 RID: 73992 RVA: 0x0007BD7D File Offset: 0x00079F7D
		' (set) Token: 0x06012109 RID: 73993 RVA: 0x0007BD87 File Offset: 0x00079F87
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17007038 RID: 28728
		' (get) Token: 0x0601210A RID: 73994 RVA: 0x0007BD90 File Offset: 0x00079F90
		' (set) Token: 0x0601210B RID: 73995 RVA: 0x0007BD9A File Offset: 0x00079F9A
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17007039 RID: 28729
		' (get) Token: 0x0601210C RID: 73996 RVA: 0x0007BDA3 File Offset: 0x00079FA3
		' (set) Token: 0x0601210D RID: 73997 RVA: 0x0007BDAD File Offset: 0x00079FAD
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700703A RID: 28730
		' (get) Token: 0x0601210E RID: 73998 RVA: 0x0007BDB6 File Offset: 0x00079FB6
		' (set) Token: 0x0601210F RID: 73999 RVA: 0x0007BDC0 File Offset: 0x00079FC0
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700703B RID: 28731
		' (get) Token: 0x06012110 RID: 74000 RVA: 0x0007BDC9 File Offset: 0x00079FC9
		' (set) Token: 0x06012111 RID: 74001 RVA: 0x0007BDD3 File Offset: 0x00079FD3
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700703C RID: 28732
		' (get) Token: 0x06012112 RID: 74002 RVA: 0x0007BDDC File Offset: 0x00079FDC
		' (set) Token: 0x06012113 RID: 74003 RVA: 0x0007BDE6 File Offset: 0x00079FE6
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700703D RID: 28733
		' (get) Token: 0x06012114 RID: 74004 RVA: 0x0007BDEF File Offset: 0x00079FEF
		' (set) Token: 0x06012115 RID: 74005 RVA: 0x0007BDF9 File Offset: 0x00079FF9
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700703E RID: 28734
		' (get) Token: 0x06012116 RID: 74006 RVA: 0x0007BE02 File Offset: 0x0007A002
		' (set) Token: 0x06012117 RID: 74007 RVA: 0x0007BE0C File Offset: 0x0007A00C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700703F RID: 28735
		' (get) Token: 0x06012118 RID: 74008 RVA: 0x0007BE15 File Offset: 0x0007A015
		' (set) Token: 0x06012119 RID: 74009 RVA: 0x0007BE1F File Offset: 0x0007A01F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17007040 RID: 28736
		' (get) Token: 0x0601211A RID: 74010 RVA: 0x0007BE28 File Offset: 0x0007A028
		' (set) Token: 0x0601211B RID: 74011 RVA: 0x0007BE32 File Offset: 0x0007A032
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007041 RID: 28737
		' (get) Token: 0x0601211C RID: 74012 RVA: 0x0007BE3B File Offset: 0x0007A03B
		' (set) Token: 0x0601211D RID: 74013 RVA: 0x0007BE45 File Offset: 0x0007A045
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17007042 RID: 28738
		' (get) Token: 0x0601211E RID: 74014 RVA: 0x0007BE4E File Offset: 0x0007A04E
		' (set) Token: 0x0601211F RID: 74015 RVA: 0x0007BE58 File Offset: 0x0007A058
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17007043 RID: 28739
		' (get) Token: 0x06012120 RID: 74016 RVA: 0x0007BE61 File Offset: 0x0007A061
		' (set) Token: 0x06012121 RID: 74017 RVA: 0x0007BE6B File Offset: 0x0007A06B
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17007044 RID: 28740
		' (get) Token: 0x06012122 RID: 74018 RVA: 0x0007BE74 File Offset: 0x0007A074
		' (set) Token: 0x06012123 RID: 74019 RVA: 0x0007BE7E File Offset: 0x0007A07E
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007045 RID: 28741
		' (get) Token: 0x06012124 RID: 74020 RVA: 0x0007BE87 File Offset: 0x0007A087
		' (set) Token: 0x06012125 RID: 74021 RVA: 0x0007BE91 File Offset: 0x0007A091
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x06012126 RID: 74022 RVA: 0x00A65A8C File Offset: 0x00A63C8C
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
					Me.DateTimePicker2.Value = DateAndTime.Today
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

		' Token: 0x06012127 RID: 74023 RVA: 0x00A65B70 File Offset: 0x00A63D70
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and S_ID not in (Select ServiceID from InvoiceInfo1) and S_ID not in (Select ServiceID from InvoiceInfo1) and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012128 RID: 74024 RVA: 0x00A65DAC File Offset: 0x00A63FAC
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Calculate()
			Me.fillServiceCode()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06012129 RID: 74025 RVA: 0x00A65E44 File Offset: 0x00A64044
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0601212A RID: 74026 RVA: 0x00A660E4 File Offset: 0x00A642E4
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

		' Token: 0x0601212B RID: 74027 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601212C RID: 74028 RVA: 0x00A661A0 File Offset: 0x00A643A0
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Billing", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmServiceBilling.Show()
						MyBase.Hide()
						MyProject.Forms.frmServiceBilling.txtS_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtServiceCode.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtCustomerID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtCID.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtCustomerName.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtRepairCharges.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtUpfront.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmServiceBilling.Compute1()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("select RTRIM(ContactNo) from Customer where ID=", dataGridViewRow.Cells(3).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MyProject.Forms.frmServiceBilling.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
						ModCommonClasses.con.Close()
					End If
					Dim flag5 As Boolean = Operators.CompareString(Me.lblSet.Text, "Send SMS", False) = 0
					If flag5 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmSendSMS_Services.Show()
						MyBase.Hide()
						MyProject.Forms.frmSendSMS_Services.txtCustomerID.Text = dataGridViewRow2.Cells(4).Value.ToString()
						MyProject.Forms.frmSendSMS_Services.txtCustomerName.Text = dataGridViewRow2.Cells(5).Value.ToString()
						MyProject.Forms.frmSendSMS_Services.txtMessage.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Your item is ready to pick up having service code '", dataGridViewRow2.Cells(1).Value), "'"))
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("select RTRIM(ContactNo) from Customer where ID=", dataGridViewRow2.Cells(3).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
						If flag6 Then
							MyProject.Forms.frmSendSMS_Services.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
							Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag7 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601212D RID: 74029 RVA: 0x00A6660C File Offset: 0x00A6480C
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

		' Token: 0x0601212E RID: 74030 RVA: 0x00A666F4 File Offset: 0x00A648F4
		Public Sub fillServiceCode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ServiceCode) FROM Service", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbServiceCode.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbServiceCode.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601212F RID: 74031 RVA: 0x00A66828 File Offset: 0x00A64A28
		Public Sub Reset()
			Me.cmbServiceCode.Text = ""
			Me.txtCustomerName.Text = ""
			Me.fillServiceCode()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.cmbStatus.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x06012130 RID: 74032 RVA: 0x0007BE9A File Offset: 0x0007A09A
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06012131 RID: 74033 RVA: 0x00A6689C File Offset: 0x00A64A9C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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

		' Token: 0x06012132 RID: 74034 RVA: 0x00A66B48 File Offset: 0x00A64D48
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbServiceCode.SelectedIndex = -1
				Me.cmbServiceCode.Text = ""
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo)from Customer,Service where Customer.ID=Service.CustomerID and S_ID not in (Select ServiceID from InvoiceInfo1) and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012133 RID: 74035 RVA: 0x00A66DB8 File Offset: 0x00A64FB8
		Private Sub cmbOrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and S_ID not in (Select ServiceID from InvoiceInfo1) and ServiceCode='" + Me.cmbServiceCode.Text + "' and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012134 RID: 74036 RVA: 0x00A67020 File Offset: 0x00A65220
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Operators.CompareString(Me.cmbStatus.Text, "", False) = 0) Or (Me.cmbStatus.SelectedIndex = -1)
				If flag Then
					MessageBox.Show("Please select status", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbStatus.Focus()
					Return
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and S_ID not in (Select ServiceID from InvoiceInfo1) and RTRIM(Service.Status)='" + Me.cmbStatus.Text + "'  and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012135 RID: 74037 RVA: 0x00A672C8 File Offset: 0x00A654C8
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbServiceCode.SelectedIndex = -1
				Me.cmbServiceCode.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and S_ID not in (Select ServiceID from InvoiceInfo1) and Name like N'%" + Me.txtCustomerName.Text + "%' and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012136 RID: 74038 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06012137 RID: 74039 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServicesRecord1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012138 RID: 74040 RVA: 0x00A6753C File Offset: 0x00A6573C
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub
	End Class
End Namespace
