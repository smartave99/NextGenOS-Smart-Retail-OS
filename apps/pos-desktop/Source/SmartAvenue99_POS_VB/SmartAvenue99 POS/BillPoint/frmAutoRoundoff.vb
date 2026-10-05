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
	' Token: 0x020004AA RID: 1194
	<DesignerGenerated()>
	Public Partial Class frmAutoRoundoff
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600ED15 RID: 60693 RVA: 0x00067D87 File Offset: 0x00065F87
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAutoRoundoff_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAutoRoundoff_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AED RID: 23277
		' (get) Token: 0x0600ED18 RID: 60696 RVA: 0x00067DB9 File Offset: 0x00065FB9
		' (set) Token: 0x0600ED19 RID: 60697 RVA: 0x00067DC3 File Offset: 0x00065FC3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005AEE RID: 23278
		' (get) Token: 0x0600ED1A RID: 60698 RVA: 0x00067DCC File Offset: 0x00065FCC
		' (set) Token: 0x0600ED1B RID: 60699 RVA: 0x00067DD6 File Offset: 0x00065FD6
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005AEF RID: 23279
		' (get) Token: 0x0600ED1C RID: 60700 RVA: 0x00067DDF File Offset: 0x00065FDF
		' (set) Token: 0x0600ED1D RID: 60701 RVA: 0x00067DE9 File Offset: 0x00065FE9
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005AF0 RID: 23280
		' (get) Token: 0x0600ED1E RID: 60702 RVA: 0x00067DF2 File Offset: 0x00065FF2
		' (set) Token: 0x0600ED1F RID: 60703 RVA: 0x00067DFC File Offset: 0x00065FFC
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005AF1 RID: 23281
		' (get) Token: 0x0600ED20 RID: 60704 RVA: 0x00067E05 File Offset: 0x00066005
		' (set) Token: 0x0600ED21 RID: 60705 RVA: 0x00067E0F File Offset: 0x0006600F
		Friend Overridable Property Label2 As Label

		' Token: 0x17005AF2 RID: 23282
		' (get) Token: 0x0600ED22 RID: 60706 RVA: 0x00067E18 File Offset: 0x00066018
		' (set) Token: 0x0600ED23 RID: 60707 RVA: 0x008EC0BC File Offset: 0x008EA2BC
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

		' Token: 0x17005AF3 RID: 23283
		' (get) Token: 0x0600ED24 RID: 60708 RVA: 0x00067E22 File Offset: 0x00066022
		' (set) Token: 0x0600ED25 RID: 60709 RVA: 0x008EC100 File Offset: 0x008EA300
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

		' Token: 0x17005AF4 RID: 23284
		' (get) Token: 0x0600ED26 RID: 60710 RVA: 0x00067E2C File Offset: 0x0006602C
		' (set) Token: 0x0600ED27 RID: 60711 RVA: 0x00067E36 File Offset: 0x00066036
		Friend Overridable Property Label1 As Label

		' Token: 0x17005AF5 RID: 23285
		' (get) Token: 0x0600ED28 RID: 60712 RVA: 0x00067E3F File Offset: 0x0006603F
		' (set) Token: 0x0600ED29 RID: 60713 RVA: 0x00067E49 File Offset: 0x00066049
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005AF6 RID: 23286
		' (get) Token: 0x0600ED2A RID: 60714 RVA: 0x00067E52 File Offset: 0x00066052
		' (set) Token: 0x0600ED2B RID: 60715 RVA: 0x00067E5C File Offset: 0x0006605C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005AF7 RID: 23287
		' (get) Token: 0x0600ED2C RID: 60716 RVA: 0x00067E65 File Offset: 0x00066065
		' (set) Token: 0x0600ED2D RID: 60717 RVA: 0x00067E6F File Offset: 0x0006606F
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005AF8 RID: 23288
		' (get) Token: 0x0600ED2E RID: 60718 RVA: 0x00067E78 File Offset: 0x00066078
		' (set) Token: 0x0600ED2F RID: 60719 RVA: 0x008EC160 File Offset: 0x008EA360
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

		' Token: 0x17005AF9 RID: 23289
		' (get) Token: 0x0600ED30 RID: 60720 RVA: 0x00067E82 File Offset: 0x00066082
		' (set) Token: 0x0600ED31 RID: 60721 RVA: 0x008EC1A4 File Offset: 0x008EA3A4
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

		' Token: 0x17005AFA RID: 23290
		' (get) Token: 0x0600ED32 RID: 60722 RVA: 0x00067E8C File Offset: 0x0006608C
		' (set) Token: 0x0600ED33 RID: 60723 RVA: 0x008EC1E8 File Offset: 0x008EA3E8
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AFB RID: 23291
		' (get) Token: 0x0600ED34 RID: 60724 RVA: 0x00067E96 File Offset: 0x00066096
		' (set) Token: 0x0600ED35 RID: 60725 RVA: 0x008EC22C File Offset: 0x008EA42C
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

		' Token: 0x0600ED36 RID: 60726 RVA: 0x008EC270 File Offset: 0x008EA470
		Private Sub frmAutoRoundoff_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600ED37 RID: 60727 RVA: 0x008EC2F8 File Offset: 0x008EA4F8
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

		' Token: 0x0600ED38 RID: 60728 RVA: 0x008EC470 File Offset: 0x008EA670
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

		' Token: 0x0600ED39 RID: 60729 RVA: 0x008EC52C File Offset: 0x008EA72C
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

		' Token: 0x0600ED3A RID: 60730 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600ED3B RID: 60731 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600ED3C RID: 60732 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ED3D RID: 60733 RVA: 0x00067EA0 File Offset: 0x000660A0
		Private Sub Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600ED3E RID: 60734 RVA: 0x008EC5F8 File Offset: 0x008EA7F8
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT id, RTRIM(c1) from Autoroundoff", ModCommonClasses.con)
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

		' Token: 0x0600ED3F RID: 60735 RVA: 0x008EC6E0 File Offset: 0x008EA8E0
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

		' Token: 0x0600ED40 RID: 60736 RVA: 0x008EC7A8 File Offset: 0x008EA9A8
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

		' Token: 0x0600ED41 RID: 60737 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAutoRoundoff_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600ED42 RID: 60738 RVA: 0x008EC890 File Offset: 0x008EAA90
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub

		' Token: 0x0600ED43 RID: 60739 RVA: 0x00067EDE File Offset: 0x000660DE
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.ComboBox1.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600ED44 RID: 60740 RVA: 0x008EC8EC File Offset: 0x008EAAEC
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
						MessageBox.Show("Please fill Auto Roundoff Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Select count(*) from Autoroundoff Having count(*) >= 1"
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
								Dim text3 As String = "insert into Autoroundoff(c1) VALUES (@d1)"
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

		' Token: 0x0600ED45 RID: 60741 RVA: 0x008ECB94 File Offset: 0x008EAD94
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
						MessageBox.Show("Please fill Auto Roundoff Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Update Autoroundoff set c1=@d1 where ID=" + Me.TextBox2.Text), "")
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

		' Token: 0x0600ED46 RID: 60742 RVA: 0x008ECDCC File Offset: 0x008EAFCC
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Autoroundoff WHERE id = " + Me.TextBox2.Text
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
