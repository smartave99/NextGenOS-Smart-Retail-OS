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
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C5 RID: 1221
	<DesignerGenerated()>
	Public Partial Class frmEwaysetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F588 RID: 62856 RVA: 0x0006B83A File Offset: 0x00069A3A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEwaysetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEwaysetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005DF3 RID: 24051
		' (get) Token: 0x0600F58B RID: 62859 RVA: 0x0006B86C File Offset: 0x00069A6C
		' (set) Token: 0x0600F58C RID: 62860 RVA: 0x0006B876 File Offset: 0x00069A76
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005DF4 RID: 24052
		' (get) Token: 0x0600F58D RID: 62861 RVA: 0x0006B87F File Offset: 0x00069A7F
		' (set) Token: 0x0600F58E RID: 62862 RVA: 0x0006B889 File Offset: 0x00069A89
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005DF5 RID: 24053
		' (get) Token: 0x0600F58F RID: 62863 RVA: 0x0006B892 File Offset: 0x00069A92
		' (set) Token: 0x0600F590 RID: 62864 RVA: 0x0006B89C File Offset: 0x00069A9C
		Friend Overridable Property Label1 As Label

		' Token: 0x17005DF6 RID: 24054
		' (get) Token: 0x0600F591 RID: 62865 RVA: 0x0006B8A5 File Offset: 0x00069AA5
		' (set) Token: 0x0600F592 RID: 62866 RVA: 0x0006B8AF File Offset: 0x00069AAF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005DF7 RID: 24055
		' (get) Token: 0x0600F593 RID: 62867 RVA: 0x0006B8B8 File Offset: 0x00069AB8
		' (set) Token: 0x0600F594 RID: 62868 RVA: 0x0093397C File Offset: 0x00931B7C
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DF8 RID: 24056
		' (get) Token: 0x0600F595 RID: 62869 RVA: 0x0006B8C2 File Offset: 0x00069AC2
		' (set) Token: 0x0600F596 RID: 62870 RVA: 0x0006B8CC File Offset: 0x00069ACC
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005DF9 RID: 24057
		' (get) Token: 0x0600F597 RID: 62871 RVA: 0x0006B8D5 File Offset: 0x00069AD5
		' (set) Token: 0x0600F598 RID: 62872 RVA: 0x0006B8DF File Offset: 0x00069ADF
		Friend Overridable Property Label2 As Label

		' Token: 0x17005DFA RID: 24058
		' (get) Token: 0x0600F599 RID: 62873 RVA: 0x0006B8E8 File Offset: 0x00069AE8
		' (set) Token: 0x0600F59A RID: 62874 RVA: 0x009339C0 File Offset: 0x00931BC0
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

		' Token: 0x17005DFB RID: 24059
		' (get) Token: 0x0600F59B RID: 62875 RVA: 0x0006B8F2 File Offset: 0x00069AF2
		' (set) Token: 0x0600F59C RID: 62876 RVA: 0x0006B8FC File Offset: 0x00069AFC
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005DFC RID: 24060
		' (get) Token: 0x0600F59D RID: 62877 RVA: 0x0006B905 File Offset: 0x00069B05
		' (set) Token: 0x0600F59E RID: 62878 RVA: 0x0006B90F File Offset: 0x00069B0F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005DFD RID: 24061
		' (get) Token: 0x0600F59F RID: 62879 RVA: 0x0006B918 File Offset: 0x00069B18
		' (set) Token: 0x0600F5A0 RID: 62880 RVA: 0x00933A20 File Offset: 0x00931C20
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DFE RID: 24062
		' (get) Token: 0x0600F5A1 RID: 62881 RVA: 0x0006B922 File Offset: 0x00069B22
		' (set) Token: 0x0600F5A2 RID: 62882 RVA: 0x0006B92C File Offset: 0x00069B2C
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005DFF RID: 24063
		' (get) Token: 0x0600F5A3 RID: 62883 RVA: 0x0006B935 File Offset: 0x00069B35
		' (set) Token: 0x0600F5A4 RID: 62884 RVA: 0x00933A64 File Offset: 0x00931C64
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E00 RID: 24064
		' (get) Token: 0x0600F5A5 RID: 62885 RVA: 0x0006B93F File Offset: 0x00069B3F
		' (set) Token: 0x0600F5A6 RID: 62886 RVA: 0x00933AA8 File Offset: 0x00931CA8
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
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

		' Token: 0x17005E01 RID: 24065
		' (get) Token: 0x0600F5A7 RID: 62887 RVA: 0x0006B949 File Offset: 0x00069B49
		' (set) Token: 0x0600F5A8 RID: 62888 RVA: 0x00933AEC File Offset: 0x00931CEC
		Private _Button5 As GelButton
		Friend Overridable Property Button5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._Button5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button5 = value
				gelButton = Me._Button5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E02 RID: 24066
		' (get) Token: 0x0600F5A9 RID: 62889 RVA: 0x0006B953 File Offset: 0x00069B53
		' (set) Token: 0x0600F5AA RID: 62890 RVA: 0x00933B30 File Offset: 0x00931D30
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button4 = value
				gelButton = Me._Button4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600F5AB RID: 62891 RVA: 0x00933B74 File Offset: 0x00931D74
		Private Sub frmEwaysetting_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.LinkLabel1.TabStop = False
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F5AC RID: 62892 RVA: 0x00933C0C File Offset: 0x00931E0C
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

		' Token: 0x0600F5AD RID: 62893 RVA: 0x00933D84 File Offset: 0x00931F84
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

		' Token: 0x0600F5AE RID: 62894 RVA: 0x00933E40 File Offset: 0x00932040
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

		' Token: 0x0600F5AF RID: 62895 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F5B0 RID: 62896 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F5B1 RID: 62897 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F5B2 RID: 62898 RVA: 0x0006B95D File Offset: 0x00069B5D
		Private Sub Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600F5B3 RID: 62899 RVA: 0x00933F0C File Offset: 0x0093210C
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT id, RTRIM(c1) from EwayBill", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F5B4 RID: 62900 RVA: 0x00933FF4 File Offset: 0x009321F4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button4.Enabled = False
					Me.Button3.Enabled = True
					Me.Button2.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox2.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F5B5 RID: 62901 RVA: 0x009340BC File Offset: 0x009322BC
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

		' Token: 0x0600F5B6 RID: 62902 RVA: 0x0006B99B File Offset: 0x00069B9B
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Process.Start("https://ewaybillgst.gov.in/")
		End Sub

		' Token: 0x0600F5B7 RID: 62903 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEwaysetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F5B8 RID: 62904 RVA: 0x009341A4 File Offset: 0x009323A4
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub

		' Token: 0x0600F5B9 RID: 62905 RVA: 0x0006B9A9 File Offset: 0x00069BA9
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.ComboBox1.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600F5BA RID: 62906 RVA: 0x00934200 File Offset: 0x00932400
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag3 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
					If flag3 Then
						MessageBox.Show("Please fill E-Way Bill Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Select count(*) from EwayBill Having count(*) >= 1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the information only", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into EwayBill(c1) VALUES (@d1)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Button4.Enabled = True
								Me.Button3.Enabled = False
								Me.Button2.Enabled = False
								Me.GetData()
								Me.Clear()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600F5BB RID: 62907 RVA: 0x009344A8 File Offset: 0x009326A8
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					flag = ModCommonClasses.rdr IsNot Nothing
					Dim flag3 As Boolean = flag
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Me.Clear()
				Else
					Dim flag4 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
					If flag4 Then
						MessageBox.Show("Please fill E-way Bill Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Update EwayBill set c1=@d1 where ID=" + Me.TextBox2.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.GetData()
							Me.Clear()
							Me.Button4.Enabled = True
							Me.Button3.Enabled = False
							Me.Button2.Enabled = False
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600F5BC RID: 62908 RVA: 0x009346E0 File Offset: 0x009328E0
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM EwayBill WHERE id = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Clear()
					End If
				End If
				Me.GetData()
				Me.Clear()
				ModCommonClasses.con.Close()
				Me.Button4.Enabled = True
				Me.Button3.Enabled = False
				Me.Button3.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
