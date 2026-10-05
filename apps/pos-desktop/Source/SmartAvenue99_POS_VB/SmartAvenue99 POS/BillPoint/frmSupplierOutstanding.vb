Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
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
	' Token: 0x020004DF RID: 1247
	<DesignerGenerated()>
	Public Partial Class frmSupplierOutstanding
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FE15 RID: 65045 RVA: 0x0006F57F File Offset: 0x0006D77F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSupplierOutstanding_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplierOutstanding_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006118 RID: 24856
		' (get) Token: 0x0600FE18 RID: 65048 RVA: 0x0006F5B1 File Offset: 0x0006D7B1
		' (set) Token: 0x0600FE19 RID: 65049 RVA: 0x0006F5BB File Offset: 0x0006D7BB
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006119 RID: 24857
		' (get) Token: 0x0600FE1A RID: 65050 RVA: 0x0006F5C4 File Offset: 0x0006D7C4
		' (set) Token: 0x0600FE1B RID: 65051 RVA: 0x0097F834 File Offset: 0x0097DA34
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

		' Token: 0x1700611A RID: 24858
		' (get) Token: 0x0600FE1C RID: 65052 RVA: 0x0006F5CE File Offset: 0x0006D7CE
		' (set) Token: 0x0600FE1D RID: 65053 RVA: 0x0006F5D8 File Offset: 0x0006D7D8
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700611B RID: 24859
		' (get) Token: 0x0600FE1E RID: 65054 RVA: 0x0006F5E1 File Offset: 0x0006D7E1
		' (set) Token: 0x0600FE1F RID: 65055 RVA: 0x0006F5EB File Offset: 0x0006D7EB
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700611C RID: 24860
		' (get) Token: 0x0600FE20 RID: 65056 RVA: 0x0006F5F4 File Offset: 0x0006D7F4
		' (set) Token: 0x0600FE21 RID: 65057 RVA: 0x0006F5FE File Offset: 0x0006D7FE
		Friend Overridable Property Label4 As Label

		' Token: 0x1700611D RID: 24861
		' (get) Token: 0x0600FE22 RID: 65058 RVA: 0x0006F607 File Offset: 0x0006D807
		' (set) Token: 0x0600FE23 RID: 65059 RVA: 0x0006F611 File Offset: 0x0006D811
		Friend Overridable Property Label2 As Label

		' Token: 0x1700611E RID: 24862
		' (get) Token: 0x0600FE24 RID: 65060 RVA: 0x0006F61A File Offset: 0x0006D81A
		' (set) Token: 0x0600FE25 RID: 65061 RVA: 0x0006F624 File Offset: 0x0006D824
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700611F RID: 24863
		' (get) Token: 0x0600FE26 RID: 65062 RVA: 0x0006F62D File Offset: 0x0006D82D
		' (set) Token: 0x0600FE27 RID: 65063 RVA: 0x0006F637 File Offset: 0x0006D837
		Friend Overridable Property Label1 As Label

		' Token: 0x17006120 RID: 24864
		' (get) Token: 0x0600FE28 RID: 65064 RVA: 0x0006F640 File Offset: 0x0006D840
		' (set) Token: 0x0600FE29 RID: 65065 RVA: 0x0006F64A File Offset: 0x0006D84A
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006121 RID: 24865
		' (get) Token: 0x0600FE2A RID: 65066 RVA: 0x0006F653 File Offset: 0x0006D853
		' (set) Token: 0x0600FE2B RID: 65067 RVA: 0x0006F65D File Offset: 0x0006D85D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006122 RID: 24866
		' (get) Token: 0x0600FE2C RID: 65068 RVA: 0x0006F666 File Offset: 0x0006D866
		' (set) Token: 0x0600FE2D RID: 65069 RVA: 0x0006F670 File Offset: 0x0006D870
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006123 RID: 24867
		' (get) Token: 0x0600FE2E RID: 65070 RVA: 0x0006F679 File Offset: 0x0006D879
		' (set) Token: 0x0600FE2F RID: 65071 RVA: 0x0006F683 File Offset: 0x0006D883
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006124 RID: 24868
		' (get) Token: 0x0600FE30 RID: 65072 RVA: 0x0006F68C File Offset: 0x0006D88C
		' (set) Token: 0x0600FE31 RID: 65073 RVA: 0x0006F696 File Offset: 0x0006D896
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006125 RID: 24869
		' (get) Token: 0x0600FE32 RID: 65074 RVA: 0x0006F69F File Offset: 0x0006D89F
		' (set) Token: 0x0600FE33 RID: 65075 RVA: 0x0097F878 File Offset: 0x0097DA78
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006126 RID: 24870
		' (get) Token: 0x0600FE34 RID: 65076 RVA: 0x0006F6A9 File Offset: 0x0006D8A9
		' (set) Token: 0x0600FE35 RID: 65077 RVA: 0x0097F8BC File Offset: 0x0097DABC
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

		' Token: 0x17006127 RID: 24871
		' (get) Token: 0x0600FE36 RID: 65078 RVA: 0x0006F6B3 File Offset: 0x0006D8B3
		' (set) Token: 0x0600FE37 RID: 65079 RVA: 0x0097F900 File Offset: 0x0097DB00
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

		' Token: 0x17006128 RID: 24872
		' (get) Token: 0x0600FE38 RID: 65080 RVA: 0x0006F6BD File Offset: 0x0006D8BD
		' (set) Token: 0x0600FE39 RID: 65081 RVA: 0x0097F944 File Offset: 0x0097DB44
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

		' Token: 0x17006129 RID: 24873
		' (get) Token: 0x0600FE3A RID: 65082 RVA: 0x0006F6C7 File Offset: 0x0006D8C7
		' (set) Token: 0x0600FE3B RID: 65083 RVA: 0x0097F988 File Offset: 0x0097DB88
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

		' Token: 0x1700612A RID: 24874
		' (get) Token: 0x0600FE3C RID: 65084 RVA: 0x0006F6D1 File Offset: 0x0006D8D1
		' (set) Token: 0x0600FE3D RID: 65085 RVA: 0x0097F9CC File Offset: 0x0097DBCC
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700612B RID: 24875
		' (get) Token: 0x0600FE3E RID: 65086 RVA: 0x0006F6DB File Offset: 0x0006D8DB
		' (set) Token: 0x0600FE3F RID: 65087 RVA: 0x0097FA10 File Offset: 0x0097DC10
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600FE40 RID: 65088 RVA: 0x0097FA54 File Offset: 0x0097DC54
		Private Sub frmSupplierOutstanding_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FE41 RID: 65089 RVA: 0x0097FAF0 File Offset: 0x0097DCF0
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

		' Token: 0x0600FE42 RID: 65090 RVA: 0x0097FC68 File Offset: 0x0097DE68
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

		' Token: 0x0600FE43 RID: 65091 RVA: 0x0097FD34 File Offset: 0x0097DF34
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

		' Token: 0x0600FE44 RID: 65092 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FE45 RID: 65093 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FE46 RID: 65094 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FE47 RID: 65095 RVA: 0x0097FE00 File Offset: 0x0097E000
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600FE48 RID: 65096 RVA: 0x0097FEDC File Offset: 0x0097E0DC
		Private Sub Customeros()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SuplNameid, Sum(Credit), Sum(Debit), Sum(Credit)-Sum(Debit) from SupplierLedgerBook where Date between @d1 and @d2 Group By SuplNameid order by SuplNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FE49 RID: 65097 RVA: 0x00980074 File Offset: 0x0097E274
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

		' Token: 0x0600FE4A RID: 65098 RVA: 0x0098015C File Offset: 0x0097E35C
		Private Sub Condition1()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = True
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FE4B RID: 65099 RVA: 0x009802BC File Offset: 0x0097E4BC
		Private Sub Condition2()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = True
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FE4C RID: 65100 RVA: 0x0098041C File Offset: 0x0097E61C
		Private Sub Condition3()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = True
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FE4D RID: 65101 RVA: 0x0098057C File Offset: 0x0097E77C
		Private Sub Condition4()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = True
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = True
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = True
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FE4E RID: 65102 RVA: 0x009806DC File Offset: 0x0097E8DC
		Private Sub Condition5()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FE4F RID: 65103 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplierOutstanding_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FE50 RID: 65104 RVA: 0x0098083C File Offset: 0x0097EA3C
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

		' Token: 0x0600FE51 RID: 65105 RVA: 0x0006F6E5 File Offset: 0x0006D8E5
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Condition5()
			Me.dgw.Rows.Clear()
		End Sub

		' Token: 0x0600FE52 RID: 65106 RVA: 0x0006F718 File Offset: 0x0006D918
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition4()
		End Sub

		' Token: 0x0600FE53 RID: 65107 RVA: 0x0006F729 File Offset: 0x0006D929
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition3()
		End Sub

		' Token: 0x0600FE54 RID: 65108 RVA: 0x0006F73A File Offset: 0x0006D93A
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition2()
		End Sub

		' Token: 0x0600FE55 RID: 65109 RVA: 0x0006F74B File Offset: 0x0006D94B
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition1()
		End Sub

		' Token: 0x0600FE56 RID: 65110 RVA: 0x00980AE8 File Offset: 0x0097ECE8
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmScreenlock.txtuser.Text = "sadmin"
				MyProject.Forms.frmScreenlock.Label2.Text = "Security Checked"
				MyProject.Forms.frmScreenlock.ShowDialog()
				MyProject.Forms.frmScreenlock.Dispose()
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
					oleDbConnection.Open()
					ModCommonClasses.dtable = New DataTable()
					oleDbDataAdapter.Fill(ModCommonClasses.dtable)
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim text As String = dataRow(0).ToString()
							Dim text2 As String = dataRow(1).ToString()
							Dim text3 As String = dataRow(2).ToString()
							Dim text4 As String = dataRow(3).ToString()
							Dim array As String() = text.Split(New Char() { "-"c })
							Dim text5 As String = array(1) + "-" + array(2)
							SqlConnection.ClearAllPools()
							ModFunc.LedgerSave(DateAndTime.Today, text, text5, "Opening Balance", New Decimal(Conversion.Val(text3)), 0D, text5, text)
							ModFunc.SupplierLedgerSave(DateAndTime.Today, text, text5, "Opening Balance", New Decimal(Conversion.Val(text3)), 0D, text5, text, "OLD CUSTOMER Debit Amount")
							ModFunc.LedgerSave(DateAndTime.Today, text, text5, "Opening Balance", 0D, New Decimal(Conversion.Val(text2)), text5, text)
							ModFunc.SupplierLedgerSave(DateAndTime.Today, text, text5, "Opening Balance", 0D, New Decimal(Conversion.Val(text2)), text5, text, "OLD CUSTOMER Credit Amount")
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully imported")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
