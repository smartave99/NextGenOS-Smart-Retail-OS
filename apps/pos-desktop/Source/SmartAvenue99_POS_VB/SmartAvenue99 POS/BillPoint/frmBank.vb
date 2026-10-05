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
	' Token: 0x0200030D RID: 781
	<DesignerGenerated()>
	Public Partial Class frmBank
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B902 RID: 47362 RVA: 0x00052CB6 File Offset: 0x00050EB6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBankName_Load_1
			AddHandler MyBase.KeyDown, AddressOf Me.frmBank_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170049CA RID: 18890
		' (get) Token: 0x0600B905 RID: 47365 RVA: 0x00052CE8 File Offset: 0x00050EE8
		' (set) Token: 0x0600B906 RID: 47366 RVA: 0x00052CF2 File Offset: 0x00050EF2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170049CB RID: 18891
		' (get) Token: 0x0600B907 RID: 47367 RVA: 0x00052CFB File Offset: 0x00050EFB
		' (set) Token: 0x0600B908 RID: 47368 RVA: 0x00772AC0 File Offset: 0x00770CC0
		Private _txtBankName As TextBox
		Friend Overridable Property txtBankName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBankName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBankName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.VT
				Dim textBox As TextBox = Me._txtBankName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtBankName = value
				textBox = Me._txtBankName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049CC RID: 18892
		' (get) Token: 0x0600B909 RID: 47369 RVA: 0x00052D05 File Offset: 0x00050F05
		' (set) Token: 0x0600B90A RID: 47370 RVA: 0x00772B20 File Offset: 0x00770D20
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

		' Token: 0x170049CD RID: 18893
		' (get) Token: 0x0600B90B RID: 47371 RVA: 0x00052D0F File Offset: 0x00050F0F
		' (set) Token: 0x0600B90C RID: 47372 RVA: 0x00052D19 File Offset: 0x00050F19
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170049CE RID: 18894
		' (get) Token: 0x0600B90D RID: 47373 RVA: 0x00052D22 File Offset: 0x00050F22
		' (set) Token: 0x0600B90E RID: 47374 RVA: 0x00052D2C File Offset: 0x00050F2C
		Friend Overridable Property Label1 As Label

		' Token: 0x170049CF RID: 18895
		' (get) Token: 0x0600B90F RID: 47375 RVA: 0x00052D35 File Offset: 0x00050F35
		' (set) Token: 0x0600B910 RID: 47376 RVA: 0x00052D3F File Offset: 0x00050F3F
		Friend Overridable Property txtBank As TextBox

		' Token: 0x170049D0 RID: 18896
		' (get) Token: 0x0600B911 RID: 47377 RVA: 0x00052D48 File Offset: 0x00050F48
		' (set) Token: 0x0600B912 RID: 47378 RVA: 0x00052D52 File Offset: 0x00050F52
		Friend Overridable Property lblUser As Label

		' Token: 0x170049D1 RID: 18897
		' (get) Token: 0x0600B913 RID: 47379 RVA: 0x00052D5B File Offset: 0x00050F5B
		' (set) Token: 0x0600B914 RID: 47380 RVA: 0x00052D65 File Offset: 0x00050F65
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170049D2 RID: 18898
		' (get) Token: 0x0600B915 RID: 47381 RVA: 0x00052D6E File Offset: 0x00050F6E
		' (set) Token: 0x0600B916 RID: 47382 RVA: 0x00052D78 File Offset: 0x00050F78
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170049D3 RID: 18899
		' (get) Token: 0x0600B917 RID: 47383 RVA: 0x00052D81 File Offset: 0x00050F81
		' (set) Token: 0x0600B918 RID: 47384 RVA: 0x00052D8B File Offset: 0x00050F8B
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170049D4 RID: 18900
		' (get) Token: 0x0600B919 RID: 47385 RVA: 0x00052D94 File Offset: 0x00050F94
		' (set) Token: 0x0600B91A RID: 47386 RVA: 0x00052D9E File Offset: 0x00050F9E
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170049D5 RID: 18901
		' (get) Token: 0x0600B91B RID: 47387 RVA: 0x00052DA7 File Offset: 0x00050FA7
		' (set) Token: 0x0600B91C RID: 47388 RVA: 0x00772B80 File Offset: 0x00770D80
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170049D6 RID: 18902
		' (get) Token: 0x0600B91D RID: 47389 RVA: 0x00052DB1 File Offset: 0x00050FB1
		' (set) Token: 0x0600B91E RID: 47390 RVA: 0x00772BC4 File Offset: 0x00770DC4
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170049D7 RID: 18903
		' (get) Token: 0x0600B91F RID: 47391 RVA: 0x00052DBB File Offset: 0x00050FBB
		' (set) Token: 0x0600B920 RID: 47392 RVA: 0x00772C08 File Offset: 0x00770E08
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

		' Token: 0x170049D8 RID: 18904
		' (get) Token: 0x0600B921 RID: 47393 RVA: 0x00052DC5 File Offset: 0x00050FC5
		' (set) Token: 0x0600B922 RID: 47394 RVA: 0x00772C4C File Offset: 0x00770E4C
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600B923 RID: 47395 RVA: 0x00772C90 File Offset: 0x00770E90
		Public Sub Reset()
			Me.txtBankName.Text = ""
			Me.txtBank.Text = ""
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtBankName.Focus()
			Me.Getdata()
		End Sub

		' Token: 0x0600B924 RID: 47396 RVA: 0x00772CFC File Offset: 0x00770EFC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select Bank.BankName from BankBranch,Bank where BankBranch.BankName=Bank.BankName and Bank.BankName=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBank.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Branch Master Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "delete from Bank where BankName=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBank.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Dim text3 As String = "deleted the Bank '" + Me.txtBankName.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B925 RID: 47397 RVA: 0x00772F08 File Offset: 0x00771108
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtBank.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtBankName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B926 RID: 47398 RVA: 0x00772FD0 File Offset: 0x007711D0
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

		' Token: 0x0600B927 RID: 47399 RVA: 0x007730B8 File Offset: 0x007712B8
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(BankName) from Bank order by BankName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B928 RID: 47400 RVA: 0x0077319C File Offset: 0x0077139C
		Private Sub frmBankName_Load_1(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600B929 RID: 47401 RVA: 0x00773224 File Offset: 0x00771424
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

		' Token: 0x0600B92A RID: 47402 RVA: 0x0077339C File Offset: 0x0077159C
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

		' Token: 0x0600B92B RID: 47403 RVA: 0x00773458 File Offset: 0x00771658
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

		' Token: 0x0600B92C RID: 47404 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600B92D RID: 47405 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600B92E RID: 47406 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600B92F RID: 47407 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBankName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B930 RID: 47408 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B931 RID: 47409 RVA: 0x00773524 File Offset: 0x00771724
		Private Sub VT(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtBankName.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtBankName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBankName, String.Empty)
			End If
		End Sub

		' Token: 0x0600B932 RID: 47410 RVA: 0x00052DCF File Offset: 0x00050FCF
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600B933 RID: 47411 RVA: 0x00773580 File Offset: 0x00771780
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtBankName.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter Bank name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBankName.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select BankName from Bank where BankName=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBankName.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Bank Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtBankName.Text = ""
							Me.txtBankName.Focus()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Bank(BankName) VALUES (@d1)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBankName.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Dim text4 As String = "added the new Bank '" + Me.txtBankName.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text4)
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600B934 RID: 47412 RVA: 0x00773844 File Offset: 0x00771A44
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtBankName.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter Bank name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtBankName.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update Bank set BankName=@d1 where BankName=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBankName.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBank.Text)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					Dim text2 As String = "updated the Bank '" + Me.txtBankName.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600B935 RID: 47413 RVA: 0x007739B0 File Offset: 0x00771BB0
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
