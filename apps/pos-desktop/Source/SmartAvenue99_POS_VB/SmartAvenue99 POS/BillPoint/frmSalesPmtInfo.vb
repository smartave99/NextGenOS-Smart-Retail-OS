Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002AC RID: 684
	<DesignerGenerated()>
	Public Partial Class frmSalesPmtInfo
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B146 RID: 45382 RVA: 0x000525D7 File Offset: 0x000507D7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesPmtInfo_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesPmtInfo_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004480 RID: 17536
		' (get) Token: 0x0600B149 RID: 45385 RVA: 0x00052609 File Offset: 0x00050809
		' (set) Token: 0x0600B14A RID: 45386 RVA: 0x0076425C File Offset: 0x0076245C
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

		' Token: 0x17004481 RID: 17537
		' (get) Token: 0x0600B14B RID: 45387 RVA: 0x00052613 File Offset: 0x00050813
		' (set) Token: 0x0600B14C RID: 45388 RVA: 0x0005261D File Offset: 0x0005081D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004482 RID: 17538
		' (get) Token: 0x0600B14D RID: 45389 RVA: 0x00052626 File Offset: 0x00050826
		' (set) Token: 0x0600B14E RID: 45390 RVA: 0x00052630 File Offset: 0x00050830
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004483 RID: 17539
		' (get) Token: 0x0600B14F RID: 45391 RVA: 0x00052639 File Offset: 0x00050839
		' (set) Token: 0x0600B150 RID: 45392 RVA: 0x00052643 File Offset: 0x00050843
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004484 RID: 17540
		' (get) Token: 0x0600B151 RID: 45393 RVA: 0x0005264C File Offset: 0x0005084C
		' (set) Token: 0x0600B152 RID: 45394 RVA: 0x00052656 File Offset: 0x00050856
		Friend Overridable Property Label2 As Label

		' Token: 0x17004485 RID: 17541
		' (get) Token: 0x0600B153 RID: 45395 RVA: 0x0005265F File Offset: 0x0005085F
		' (set) Token: 0x0600B154 RID: 45396 RVA: 0x007642A0 File Offset: 0x007624A0
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

		' Token: 0x17004486 RID: 17542
		' (get) Token: 0x0600B155 RID: 45397 RVA: 0x00052669 File Offset: 0x00050869
		' (set) Token: 0x0600B156 RID: 45398 RVA: 0x00052673 File Offset: 0x00050873
		Friend Overridable Property Label4 As Label

		' Token: 0x17004487 RID: 17543
		' (get) Token: 0x0600B157 RID: 45399 RVA: 0x0005267C File Offset: 0x0005087C
		' (set) Token: 0x0600B158 RID: 45400 RVA: 0x00052686 File Offset: 0x00050886
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004488 RID: 17544
		' (get) Token: 0x0600B159 RID: 45401 RVA: 0x0005268F File Offset: 0x0005088F
		' (set) Token: 0x0600B15A RID: 45402 RVA: 0x00052699 File Offset: 0x00050899
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004489 RID: 17545
		' (get) Token: 0x0600B15B RID: 45403 RVA: 0x000526A2 File Offset: 0x000508A2
		' (set) Token: 0x0600B15C RID: 45404 RVA: 0x000526AC File Offset: 0x000508AC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700448A RID: 17546
		' (get) Token: 0x0600B15D RID: 45405 RVA: 0x000526B5 File Offset: 0x000508B5
		' (set) Token: 0x0600B15E RID: 45406 RVA: 0x000526BF File Offset: 0x000508BF
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700448B RID: 17547
		' (get) Token: 0x0600B15F RID: 45407 RVA: 0x000526C8 File Offset: 0x000508C8
		' (set) Token: 0x0600B160 RID: 45408 RVA: 0x000526D2 File Offset: 0x000508D2
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700448C RID: 17548
		' (get) Token: 0x0600B161 RID: 45409 RVA: 0x000526DB File Offset: 0x000508DB
		' (set) Token: 0x0600B162 RID: 45410 RVA: 0x000526E5 File Offset: 0x000508E5
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700448D RID: 17549
		' (get) Token: 0x0600B163 RID: 45411 RVA: 0x000526EE File Offset: 0x000508EE
		' (set) Token: 0x0600B164 RID: 45412 RVA: 0x000526F8 File Offset: 0x000508F8
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700448E RID: 17550
		' (get) Token: 0x0600B165 RID: 45413 RVA: 0x00052701 File Offset: 0x00050901
		' (set) Token: 0x0600B166 RID: 45414 RVA: 0x0005270B File Offset: 0x0005090B
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700448F RID: 17551
		' (get) Token: 0x0600B167 RID: 45415 RVA: 0x00052714 File Offset: 0x00050914
		' (set) Token: 0x0600B168 RID: 45416 RVA: 0x0005271E File Offset: 0x0005091E
		Friend Overridable Property Label5 As Label

		' Token: 0x17004490 RID: 17552
		' (get) Token: 0x0600B169 RID: 45417 RVA: 0x00052727 File Offset: 0x00050927
		' (set) Token: 0x0600B16A RID: 45418 RVA: 0x00052731 File Offset: 0x00050931
		Friend Overridable Property Label3 As Label

		' Token: 0x17004491 RID: 17553
		' (get) Token: 0x0600B16B RID: 45419 RVA: 0x0005273A File Offset: 0x0005093A
		' (set) Token: 0x0600B16C RID: 45420 RVA: 0x00052744 File Offset: 0x00050944
		Friend Overridable Property Label1 As Label

		' Token: 0x17004492 RID: 17554
		' (get) Token: 0x0600B16D RID: 45421 RVA: 0x0005274D File Offset: 0x0005094D
		' (set) Token: 0x0600B16E RID: 45422 RVA: 0x007642E4 File Offset: 0x007624E4
		Private _ComboBox3 As ComboBox
		Friend Overridable Property ComboBox3 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox3_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox3 = value
				comboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004493 RID: 17555
		' (get) Token: 0x0600B16F RID: 45423 RVA: 0x00052757 File Offset: 0x00050957
		' (set) Token: 0x0600B170 RID: 45424 RVA: 0x00764328 File Offset: 0x00762528
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

		' Token: 0x17004494 RID: 17556
		' (get) Token: 0x0600B171 RID: 45425 RVA: 0x00052761 File Offset: 0x00050961
		' (set) Token: 0x0600B172 RID: 45426 RVA: 0x0076436C File Offset: 0x0076256C
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

		' Token: 0x17004495 RID: 17557
		' (get) Token: 0x0600B173 RID: 45427 RVA: 0x0005276B File Offset: 0x0005096B
		' (set) Token: 0x0600B174 RID: 45428 RVA: 0x00052775 File Offset: 0x00050975
		Friend Overridable Property Label6 As Label

		' Token: 0x17004496 RID: 17558
		' (get) Token: 0x0600B175 RID: 45429 RVA: 0x0005277E File Offset: 0x0005097E
		' (set) Token: 0x0600B176 RID: 45430 RVA: 0x007643B0 File Offset: 0x007625B0
		Private _ComboBox4 As ComboBox
		Friend Overridable Property ComboBox4 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox4_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox4 = value
				comboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004497 RID: 17559
		' (get) Token: 0x0600B177 RID: 45431 RVA: 0x00052788 File Offset: 0x00050988
		' (set) Token: 0x0600B178 RID: 45432 RVA: 0x007643F4 File Offset: 0x007625F4
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

		' Token: 0x17004498 RID: 17560
		' (get) Token: 0x0600B179 RID: 45433 RVA: 0x00052792 File Offset: 0x00050992
		' (set) Token: 0x0600B17A RID: 45434 RVA: 0x00764438 File Offset: 0x00762638
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

		' Token: 0x17004499 RID: 17561
		' (get) Token: 0x0600B17B RID: 45435 RVA: 0x0005279C File Offset: 0x0005099C
		' (set) Token: 0x0600B17C RID: 45436 RVA: 0x000527A6 File Offset: 0x000509A6
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700449A RID: 17562
		' (get) Token: 0x0600B17D RID: 45437 RVA: 0x000527AF File Offset: 0x000509AF
		' (set) Token: 0x0600B17E RID: 45438 RVA: 0x000527B9 File Offset: 0x000509B9
		Friend Overridable Property Label7 As Label

		' Token: 0x1700449B RID: 17563
		' (get) Token: 0x0600B17F RID: 45439 RVA: 0x000527C2 File Offset: 0x000509C2
		' (set) Token: 0x0600B180 RID: 45440 RVA: 0x000527CC File Offset: 0x000509CC
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x0600B181 RID: 45441 RVA: 0x0076447C File Offset: 0x0076267C
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
					Me.dtpDateTo.Value = DateAndTime.Today
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

		' Token: 0x0600B182 RID: 45442 RVA: 0x00764560 File Offset: 0x00762760
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select InvoiceInfo.Inv_ID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, Invoice_Payment.PaymentDate, Invoice_Payment.TotalPaid, RTRIM(Invoice_Payment.PaymentMode) from InvoiceInfo Left Join Invoice_Payment ON InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B183 RID: 45443 RVA: 0x0076471C File Offset: 0x0076291C
		Private Sub frmSalesPmtInfo_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.fillInvoiceNo()
			Me.FillUserID()
			Me.fillTillID()
			Me.fillPmtMode()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600B184 RID: 45444 RVA: 0x000527D5 File Offset: 0x000509D5
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600B185 RID: 45445 RVA: 0x007647C0 File Offset: 0x007629C0
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600B186 RID: 45446 RVA: 0x007648F4 File Offset: 0x00762AF4
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(UserID) from Registration Order by UserID"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.ComboBox2.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox2.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B187 RID: 45447 RVA: 0x007649C8 File Offset: 0x00762BC8
		Public Sub fillTillID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TillID) FROM Invoiceinfo", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox3.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox3.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600B188 RID: 45448 RVA: 0x00764AFC File Offset: 0x00762CFC
		Public Sub fillPmtMode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PaymentMode) FROM Invoice_Payment", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox4.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox4.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600B189 RID: 45449 RVA: 0x00764C30 File Offset: 0x00762E30
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select InvoiceInfo.Inv_ID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, Invoice_Payment.PaymentDate, Invoice_Payment.TotalPaid, RTRIM(Invoice_Payment.PaymentMode) from InvoiceInfo Left Join Invoice_Payment ON InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID where InvoiceInfo.InvoiceNo=@d1 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B18A RID: 45450 RVA: 0x00764D98 File Offset: 0x00762F98
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select InvoiceInfo.Inv_ID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, Invoice_Payment.PaymentDate, Invoice_Payment.TotalPaid, RTRIM(Invoice_Payment.PaymentMode) from InvoiceInfo Left Join Invoice_Payment ON InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID where InvoiceDate between @d1 and @d2 and InvoiceInfo.Operator=@d3 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B18B RID: 45451 RVA: 0x00764F74 File Offset: 0x00763174
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select InvoiceInfo.Inv_ID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, Invoice_Payment.PaymentDate, Invoice_Payment.TotalPaid, RTRIM(Invoice_Payment.PaymentMode) from InvoiceInfo Left Join Invoice_Payment ON InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID where InvoiceDate between @d1 and @d2 and InvoiceInfo.TillID=@d3 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B18C RID: 45452 RVA: 0x00765150 File Offset: 0x00763350
		Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select InvoiceInfo.Inv_ID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, Invoice_Payment.PaymentDate, Invoice_Payment.TotalPaid, RTRIM(Invoice_Payment.PaymentMode) from InvoiceInfo Left Join Invoice_Payment ON InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID where InvoiceInfo.InvoiceDate between @d1 and @d2 and Invoice_Payment.PaymentMode=@d3 order by InvoiceInfo.InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "PaymentDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "PaymentDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox4.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B18D RID: 45453 RVA: 0x0076532C File Offset: 0x0076352C
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.ComboBox4.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x0600B18E RID: 45454 RVA: 0x0076537C File Offset: 0x0076357C
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

		' Token: 0x0600B18F RID: 45455 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesPmtInfo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B190 RID: 45456 RVA: 0x00765628 File Offset: 0x00763828
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(4).Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(4).Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
				Me.lblTotalAmount.Text = "Total Received Amt : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B191 RID: 45457 RVA: 0x00765728 File Offset: 0x00763928
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
