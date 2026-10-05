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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005C1 RID: 1473
	<DesignerGenerated()>
	Public Partial Class frmVoucherRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011F41 RID: 73537 RVA: 0x0007B206 File Offset: 0x00079406
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmVoucherRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006F80 RID: 28544
		' (get) Token: 0x06011F44 RID: 73540 RVA: 0x0007B238 File Offset: 0x00079438
		' (set) Token: 0x06011F45 RID: 73541 RVA: 0x0007B242 File Offset: 0x00079442
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006F81 RID: 28545
		' (get) Token: 0x06011F46 RID: 73542 RVA: 0x0007B24B File Offset: 0x0007944B
		' (set) Token: 0x06011F47 RID: 73543 RVA: 0x00A5A3E0 File Offset: 0x00A585E0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F82 RID: 28546
		' (get) Token: 0x06011F48 RID: 73544 RVA: 0x0007B255 File Offset: 0x00079455
		' (set) Token: 0x06011F49 RID: 73545 RVA: 0x0007B25F File Offset: 0x0007945F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006F83 RID: 28547
		' (get) Token: 0x06011F4A RID: 73546 RVA: 0x0007B268 File Offset: 0x00079468
		' (set) Token: 0x06011F4B RID: 73547 RVA: 0x0007B272 File Offset: 0x00079472
		Friend Overridable Property Label1 As Label

		' Token: 0x17006F84 RID: 28548
		' (get) Token: 0x06011F4C RID: 73548 RVA: 0x0007B27B File Offset: 0x0007947B
		' (set) Token: 0x06011F4D RID: 73549 RVA: 0x0007B285 File Offset: 0x00079485
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006F85 RID: 28549
		' (get) Token: 0x06011F4E RID: 73550 RVA: 0x0007B28E File Offset: 0x0007948E
		' (set) Token: 0x06011F4F RID: 73551 RVA: 0x0007B298 File Offset: 0x00079498
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006F86 RID: 28550
		' (get) Token: 0x06011F50 RID: 73552 RVA: 0x0007B2A1 File Offset: 0x000794A1
		' (set) Token: 0x06011F51 RID: 73553 RVA: 0x0007B2AB File Offset: 0x000794AB
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006F87 RID: 28551
		' (get) Token: 0x06011F52 RID: 73554 RVA: 0x0007B2B4 File Offset: 0x000794B4
		' (set) Token: 0x06011F53 RID: 73555 RVA: 0x0007B2BE File Offset: 0x000794BE
		Friend Overridable Property Label2 As Label

		' Token: 0x17006F88 RID: 28552
		' (get) Token: 0x06011F54 RID: 73556 RVA: 0x0007B2C7 File Offset: 0x000794C7
		' (set) Token: 0x06011F55 RID: 73557 RVA: 0x0007B2D1 File Offset: 0x000794D1
		Friend Overridable Property Label4 As Label

		' Token: 0x17006F89 RID: 28553
		' (get) Token: 0x06011F56 RID: 73558 RVA: 0x0007B2DA File Offset: 0x000794DA
		' (set) Token: 0x06011F57 RID: 73559 RVA: 0x00A5A45C File Offset: 0x00A5865C
		Private _cmbVoucherNo As ComboBox
		Friend Overridable Property cmbVoucherNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbVoucherNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbBillNo_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbVoucherNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbVoucherNo = value
				comboBox = Me._cmbVoucherNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F8A RID: 28554
		' (get) Token: 0x06011F58 RID: 73560 RVA: 0x0007B2E4 File Offset: 0x000794E4
		' (set) Token: 0x06011F59 RID: 73561 RVA: 0x0007B2EE File Offset: 0x000794EE
		Friend Overridable Property Panel8 As Panel

		' Token: 0x17006F8B RID: 28555
		' (get) Token: 0x06011F5A RID: 73562 RVA: 0x0007B2F7 File Offset: 0x000794F7
		' (set) Token: 0x06011F5B RID: 73563 RVA: 0x0007B301 File Offset: 0x00079501
		Friend Overridable Property Label8 As Label

		' Token: 0x17006F8C RID: 28556
		' (get) Token: 0x06011F5C RID: 73564 RVA: 0x0007B30A File Offset: 0x0007950A
		' (set) Token: 0x06011F5D RID: 73565 RVA: 0x0007B314 File Offset: 0x00079514
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006F8D RID: 28557
		' (get) Token: 0x06011F5E RID: 73566 RVA: 0x0007B31D File Offset: 0x0007951D
		' (set) Token: 0x06011F5F RID: 73567 RVA: 0x0007B327 File Offset: 0x00079527
		Friend Overridable Property Label5 As Label

		' Token: 0x17006F8E RID: 28558
		' (get) Token: 0x06011F60 RID: 73568 RVA: 0x0007B330 File Offset: 0x00079530
		' (set) Token: 0x06011F61 RID: 73569 RVA: 0x0007B33A File Offset: 0x0007953A
		Friend Overridable Property Label3 As Label

		' Token: 0x17006F8F RID: 28559
		' (get) Token: 0x06011F62 RID: 73570 RVA: 0x0007B343 File Offset: 0x00079543
		' (set) Token: 0x06011F63 RID: 73571 RVA: 0x0007B34D File Offset: 0x0007954D
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006F90 RID: 28560
		' (get) Token: 0x06011F64 RID: 73572 RVA: 0x0007B356 File Offset: 0x00079556
		' (set) Token: 0x06011F65 RID: 73573 RVA: 0x0007B360 File Offset: 0x00079560
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006F91 RID: 28561
		' (get) Token: 0x06011F66 RID: 73574 RVA: 0x0007B369 File Offset: 0x00079569
		' (set) Token: 0x06011F67 RID: 73575 RVA: 0x00A5A4A0 File Offset: 0x00A586A0
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

		' Token: 0x17006F92 RID: 28562
		' (get) Token: 0x06011F68 RID: 73576 RVA: 0x0007B373 File Offset: 0x00079573
		' (set) Token: 0x06011F69 RID: 73577 RVA: 0x00A5A4E4 File Offset: 0x00A586E4
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

		' Token: 0x17006F93 RID: 28563
		' (get) Token: 0x06011F6A RID: 73578 RVA: 0x0007B37D File Offset: 0x0007957D
		' (set) Token: 0x06011F6B RID: 73579 RVA: 0x00A5A528 File Offset: 0x00A58728
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

		' Token: 0x06011F6C RID: 73580 RVA: 0x00A5A56C File Offset: 0x00A5876C
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

		' Token: 0x06011F6D RID: 73581 RVA: 0x00A5A640 File Offset: 0x00A58840
		Public Sub fillVoucherNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(VoucherNo) FROM Voucher", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbVoucherNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbVoucherNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011F6E RID: 73582 RVA: 0x00A5A768 File Offset: 0x00A58968
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Voucher.Id) as [Voucher ID], RTRIM(VoucherNo) as [Voucher No.],Convert(DateTime,Date,103) as [Voucher Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Voucher.GrandTotal) as [Grand Total], RTRIM(Voucher.PMode) as [Payment Mode],RTRIM(Voucher.BankAcNumber) as [Bank A/c No] from Voucher where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Voucher")
				Me.dgw.DataSource = dataSet.Tables("Voucher").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F6F RID: 73583 RVA: 0x00A5A8A8 File Offset: 0x00A58AA8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.GetData()
			Me.Calculate()
			Me.fillVoucherNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011F70 RID: 73584 RVA: 0x00A5A948 File Offset: 0x00A58B48
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

		' Token: 0x06011F71 RID: 73585 RVA: 0x00A5AAC0 File Offset: 0x00A58CC0
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

		' Token: 0x06011F72 RID: 73586 RVA: 0x00A5AB8C File Offset: 0x00A58D8C
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

		' Token: 0x06011F73 RID: 73587 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011F74 RID: 73588 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011F75 RID: 73589 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011F76 RID: 73590 RVA: 0x0007B387 File Offset: 0x00079587
		Public Sub Reset()
			Me.cmbVoucherNo.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.GetData()
		End Sub

		' Token: 0x06011F77 RID: 73591 RVA: 0x00A5AC58 File Offset: 0x00A58E58
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011F78 RID: 73592 RVA: 0x00A5AC80 File Offset: 0x00A58E80
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.Label3.Text, "VR", False) = 0
					If flag2 Then
						MyBase.Close()
						MyProject.Forms.frmVoucher.Show()
						MyProject.Forms.frmVoucher.txtVoucherID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmVoucher.txtVoucherNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmVoucher.dtpDate.Value = Conversions.ToDate(dataGridViewRow.Cells(2).Value.ToString())
						MyProject.Forms.frmVoucher.cmbtxtName.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmVoucher.txtDetails.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmVoucher.txtGrandTotal.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmVoucher.ComboBox1.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmVoucher.cmbAccountNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmVoucher.btnSave.Enabled = False
						MyProject.Forms.frmVoucher.btnDelete.Enabled = True
						MyProject.Forms.frmVoucher.btnUpdate.Enabled = True
						MyProject.Forms.frmVoucher.btnPrint.Enabled = True
						MyProject.Forms.frmVoucher.btnRemove.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select RTRIM(Particulars),RTRIM(Amount),RTRIM(Note) from Voucher,Voucher_OtherDetails where Voucher.Id=Voucher_OtherDetails.VoucherID and Voucher.ID=", dataGridViewRow.Cells(0).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmVoucher.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmVoucher.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
						End While
						ModCommonClasses.con.Close()
						Me.Label3.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011F79 RID: 73593 RVA: 0x0007B3BA File Offset: 0x000795BA
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011F7A RID: 73594 RVA: 0x00A5AFEC File Offset: 0x00A591EC
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

		' Token: 0x06011F7B RID: 73595 RVA: 0x00A5B0D4 File Offset: 0x00A592D4
		Private Sub cmbBillNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Voucher.Id) as [Voucher ID], RTRIM(VoucherNo) as [Voucher No.],Convert(DateTime,Date,103) as [Voucher Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Voucher.GrandTotal) as [Grand Total], RTRIM(Voucher.PMode) as [Payment Mode],RTRIM(Voucher.BankAcNumber) as [Bank A/c No] from Voucher where VoucherNo='" + Me.cmbVoucherNo.Text + "' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Voucher")
				Me.dgw.DataSource = dataSet.Tables("Voucher").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011F7C RID: 73596 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmVoucherRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011F7D RID: 73597 RVA: 0x00A5B234 File Offset: 0x00A59434
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(5).Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(5).Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x06011F7E RID: 73598 RVA: 0x00A5B344 File Offset: 0x00A59544
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbVoucherNo.SelectedIndex = -1
				Me.cmbVoucherNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Voucher.Id) as [Voucher ID], RTRIM(VoucherNo) as [Voucher No.],Convert(DateTime,Date,103) as [Voucher Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Voucher.GrandTotal) as [Grand Total], RTRIM(Voucher.PMode) as [Payment Mode],RTRIM(Voucher.BankAcNumber) as [Bank A/c No] from Voucher where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Voucher")
				Me.dgw.DataSource = dataSet.Tables("Voucher").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011F7F RID: 73599 RVA: 0x0007B3C4 File Offset: 0x000795C4
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06011F80 RID: 73600 RVA: 0x00A5B4AC File Offset: 0x00A596AC
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
