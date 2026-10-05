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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004CD RID: 1229
	<DesignerGenerated()>
	Public Partial Class frmIncomeRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FA35 RID: 64053 RVA: 0x0006DC00 File Offset: 0x0006BE00
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmIncomeRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005FCF RID: 24527
		' (get) Token: 0x0600FA38 RID: 64056 RVA: 0x0006DC32 File Offset: 0x0006BE32
		' (set) Token: 0x0600FA39 RID: 64057 RVA: 0x0006DC3C File Offset: 0x0006BE3C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005FD0 RID: 24528
		' (get) Token: 0x0600FA3A RID: 64058 RVA: 0x0006DC45 File Offset: 0x0006BE45
		' (set) Token: 0x0600FA3B RID: 64059 RVA: 0x0095FA90 File Offset: 0x0095DC90
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

		' Token: 0x17005FD1 RID: 24529
		' (get) Token: 0x0600FA3C RID: 64060 RVA: 0x0006DC4F File Offset: 0x0006BE4F
		' (set) Token: 0x0600FA3D RID: 64061 RVA: 0x0006DC59 File Offset: 0x0006BE59
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005FD2 RID: 24530
		' (get) Token: 0x0600FA3E RID: 64062 RVA: 0x0006DC62 File Offset: 0x0006BE62
		' (set) Token: 0x0600FA3F RID: 64063 RVA: 0x0006DC6C File Offset: 0x0006BE6C
		Friend Overridable Property Label1 As Label

		' Token: 0x17005FD3 RID: 24531
		' (get) Token: 0x0600FA40 RID: 64064 RVA: 0x0006DC75 File Offset: 0x0006BE75
		' (set) Token: 0x0600FA41 RID: 64065 RVA: 0x0006DC7F File Offset: 0x0006BE7F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005FD4 RID: 24532
		' (get) Token: 0x0600FA42 RID: 64066 RVA: 0x0006DC88 File Offset: 0x0006BE88
		' (set) Token: 0x0600FA43 RID: 64067 RVA: 0x0006DC92 File Offset: 0x0006BE92
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005FD5 RID: 24533
		' (get) Token: 0x0600FA44 RID: 64068 RVA: 0x0006DC9B File Offset: 0x0006BE9B
		' (set) Token: 0x0600FA45 RID: 64069 RVA: 0x0006DCA5 File Offset: 0x0006BEA5
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005FD6 RID: 24534
		' (get) Token: 0x0600FA46 RID: 64070 RVA: 0x0006DCAE File Offset: 0x0006BEAE
		' (set) Token: 0x0600FA47 RID: 64071 RVA: 0x0006DCB8 File Offset: 0x0006BEB8
		Friend Overridable Property Label2 As Label

		' Token: 0x17005FD7 RID: 24535
		' (get) Token: 0x0600FA48 RID: 64072 RVA: 0x0006DCC1 File Offset: 0x0006BEC1
		' (set) Token: 0x0600FA49 RID: 64073 RVA: 0x0006DCCB File Offset: 0x0006BECB
		Friend Overridable Property Label4 As Label

		' Token: 0x17005FD8 RID: 24536
		' (get) Token: 0x0600FA4A RID: 64074 RVA: 0x0006DCD4 File Offset: 0x0006BED4
		' (set) Token: 0x0600FA4B RID: 64075 RVA: 0x0095FB0C File Offset: 0x0095DD0C
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

		' Token: 0x17005FD9 RID: 24537
		' (get) Token: 0x0600FA4C RID: 64076 RVA: 0x0006DCDE File Offset: 0x0006BEDE
		' (set) Token: 0x0600FA4D RID: 64077 RVA: 0x0006DCE8 File Offset: 0x0006BEE8
		Friend Overridable Property Panel8 As Panel

		' Token: 0x17005FDA RID: 24538
		' (get) Token: 0x0600FA4E RID: 64078 RVA: 0x0006DCF1 File Offset: 0x0006BEF1
		' (set) Token: 0x0600FA4F RID: 64079 RVA: 0x0006DCFB File Offset: 0x0006BEFB
		Friend Overridable Property Label8 As Label

		' Token: 0x17005FDB RID: 24539
		' (get) Token: 0x0600FA50 RID: 64080 RVA: 0x0006DD04 File Offset: 0x0006BF04
		' (set) Token: 0x0600FA51 RID: 64081 RVA: 0x0006DD0E File Offset: 0x0006BF0E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005FDC RID: 24540
		' (get) Token: 0x0600FA52 RID: 64082 RVA: 0x0006DD17 File Offset: 0x0006BF17
		' (set) Token: 0x0600FA53 RID: 64083 RVA: 0x0006DD21 File Offset: 0x0006BF21
		Friend Overridable Property Label5 As Label

		' Token: 0x17005FDD RID: 24541
		' (get) Token: 0x0600FA54 RID: 64084 RVA: 0x0006DD2A File Offset: 0x0006BF2A
		' (set) Token: 0x0600FA55 RID: 64085 RVA: 0x0006DD34 File Offset: 0x0006BF34
		Friend Overridable Property Label3 As Label

		' Token: 0x17005FDE RID: 24542
		' (get) Token: 0x0600FA56 RID: 64086 RVA: 0x0006DD3D File Offset: 0x0006BF3D
		' (set) Token: 0x0600FA57 RID: 64087 RVA: 0x0095FB50 File Offset: 0x0095DD50
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FDF RID: 24543
		' (get) Token: 0x0600FA58 RID: 64088 RVA: 0x0006DD47 File Offset: 0x0006BF47
		' (set) Token: 0x0600FA59 RID: 64089 RVA: 0x0006DD51 File Offset: 0x0006BF51
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005FE0 RID: 24544
		' (get) Token: 0x0600FA5A RID: 64090 RVA: 0x0006DD5A File Offset: 0x0006BF5A
		' (set) Token: 0x0600FA5B RID: 64091 RVA: 0x0006DD64 File Offset: 0x0006BF64
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17005FE1 RID: 24545
		' (get) Token: 0x0600FA5C RID: 64092 RVA: 0x0006DD6D File Offset: 0x0006BF6D
		' (set) Token: 0x0600FA5D RID: 64093 RVA: 0x0095FB94 File Offset: 0x0095DD94
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

		' Token: 0x17005FE2 RID: 24546
		' (get) Token: 0x0600FA5E RID: 64094 RVA: 0x0006DD77 File Offset: 0x0006BF77
		' (set) Token: 0x0600FA5F RID: 64095 RVA: 0x0095FBD8 File Offset: 0x0095DDD8
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

		' Token: 0x17005FE3 RID: 24547
		' (get) Token: 0x0600FA60 RID: 64096 RVA: 0x0006DD81 File Offset: 0x0006BF81
		' (set) Token: 0x0600FA61 RID: 64097 RVA: 0x0095FC1C File Offset: 0x0095DE1C
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

		' Token: 0x17005FE4 RID: 24548
		' (get) Token: 0x0600FA62 RID: 64098 RVA: 0x0006DD8B File Offset: 0x0006BF8B
		' (set) Token: 0x0600FA63 RID: 64099 RVA: 0x0095FC60 File Offset: 0x0095DE60
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600FA64 RID: 64100 RVA: 0x0095FCA4 File Offset: 0x0095DEA4
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

		' Token: 0x0600FA65 RID: 64101 RVA: 0x0095FD78 File Offset: 0x0095DF78
		Public Sub fillVoucherNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(IncomeNo) FROM Income", sqlConnection)
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

		' Token: 0x0600FA66 RID: 64102 RVA: 0x0095FEA0 File Offset: 0x0095E0A0
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Income.Id) as [Income ID], RTRIM(IncomeNo) as [Income No.],Convert(DateTime,Date,103) as [Income Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Income.GrandTotal) as [Grand Total],RTRIM(Income.PMode) as [Payment Mode],RTRIM(Income.BankAcNum) as [Bank A/c No] from Income where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Income")
				Me.dgw.DataSource = dataSet.Tables("Income").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA67 RID: 64103 RVA: 0x0095FFD8 File Offset: 0x0095E1D8
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

		' Token: 0x0600FA68 RID: 64104 RVA: 0x00960078 File Offset: 0x0095E278
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

		' Token: 0x0600FA69 RID: 64105 RVA: 0x009601F0 File Offset: 0x0095E3F0
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

		' Token: 0x0600FA6A RID: 64106 RVA: 0x009602BC File Offset: 0x0095E4BC
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

		' Token: 0x0600FA6B RID: 64107 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FA6C RID: 64108 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FA6D RID: 64109 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FA6E RID: 64110 RVA: 0x00960388 File Offset: 0x0095E588
		Public Sub Reset()
			Me.cmbVoucherNo.SelectedIndex = -1
			Me.cmbVoucherNo.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Button2.Enabled = False
			Me.GetData()
		End Sub

		' Token: 0x0600FA6F RID: 64111 RVA: 0x009603E0 File Offset: 0x0095E5E0
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600FA70 RID: 64112 RVA: 0x00960408 File Offset: 0x0095E608
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.Label3.Text, "IR", False) = 0
					If flag2 Then
						MyBase.Close()
						MyProject.Forms.frmIncome.Show()
						MyProject.Forms.frmIncome.txtVoucherID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmIncome.txtVoucherNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmIncome.dtpDate.Value = Conversions.ToDate(dataGridViewRow.Cells(2).Value.ToString())
						MyProject.Forms.frmIncome.cmbtxtName.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmIncome.txtDetails.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmIncome.txtGrandTotal.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmIncome.ComboBox1.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmIncome.cmbAccountNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmIncome.btnSave.Enabled = False
						MyProject.Forms.frmIncome.btnDelete.Enabled = True
						MyProject.Forms.frmIncome.btnUpdate.Enabled = True
						MyProject.Forms.frmIncome.btnRemove.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select RTRIM(Particulars),RTRIM(Amount),RTRIM(Note) from Income,Income_OtherDetails where Income.Id=Income_OtherDetails.IncomeID and Income.ID=", dataGridViewRow.Cells(0).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmIncome.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmIncome.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
						End While
						ModCommonClasses.con.Close()
						Me.Label3.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA71 RID: 64113 RVA: 0x0006DD95 File Offset: 0x0006BF95
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0600FA72 RID: 64114 RVA: 0x0096075C File Offset: 0x0095E95C
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

		' Token: 0x0600FA73 RID: 64115 RVA: 0x00960844 File Offset: 0x0095EA44
		Private Sub cmbBillNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Income.Id) as [Income ID], RTRIM(IncomeNo) as [Income No.],Convert(DateTime,Date,103) as [Income Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Income.GrandTotal) as [Grand Total],RTRIM(Income.PMode) as [Payment Mode],RTRIM(Income.BankAcNum) as [Bank A/c No] from Income where IncomeNo='" + Me.cmbVoucherNo.Text + "' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Income")
				Me.dgw.DataSource = dataSet.Tables("Income").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Button2.Enabled = True
			Catch ex As Exception
				Me.Button2.Enabled = False
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600FA74 RID: 64116 RVA: 0x0006DD9F File Offset: 0x0006BF9F
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600FA75 RID: 64117 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmIncomeRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FA76 RID: 64118 RVA: 0x009609BC File Offset: 0x0095EBBC
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

		' Token: 0x0600FA77 RID: 64119 RVA: 0x00960ACC File Offset: 0x0095ECCC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbVoucherNo.SelectedIndex = -1
				Me.cmbVoucherNo.Text = ""
				Me.Button2.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Income.Id) as [Income ID], RTRIM(IncomeNo) as [Income No.],Convert(DateTime,Date,103) as [Income Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Income.GrandTotal) as [Grand Total],RTRIM(Income.PMode) as [Payment Mode],RTRIM(Income.BankAcNum) as [Bank A/c No] from Income where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "Income")
				Me.dgw.DataSource = dataSet.Tables("Income").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.Button2.Enabled = False
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600FA78 RID: 64120 RVA: 0x00960C4C File Offset: 0x0095EE4C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.RowCount = 0
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.Button2.Enabled = False
			Else
				Me.Button2.Enabled = False
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("Income ID")
				dataTable2.Columns.Add("Income No.")
				dataTable2.Columns.Add("Income Date")
				dataTable2.Columns.Add("Name")
				dataTable2.Columns.Add("Details")
				dataTable2.Columns.Add("Grand Total")
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New rptIncome()
				reportDocument.SetDataSource(dataTable)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text12"), TextObject)
				textObject.Text = Me.dtpDateFrom.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text14"), TextObject)
				textObject2.Text = Me.dtpDateTo.Text
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x0600FA79 RID: 64121 RVA: 0x0006DDBB File Offset: 0x0006BFBB
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600FA7A RID: 64122 RVA: 0x00960EE4 File Offset: 0x0095F0E4
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
