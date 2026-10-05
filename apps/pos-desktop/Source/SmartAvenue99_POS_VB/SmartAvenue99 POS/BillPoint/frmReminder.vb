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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000364 RID: 868
	<DesignerGenerated()>
	Public Partial Class frmReminder
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CE33 RID: 52787 RVA: 0x0005BB35 File Offset: 0x00059D35
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmReminder_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmReminder_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005104 RID: 20740
		' (get) Token: 0x0600CE36 RID: 52790 RVA: 0x0005BB67 File Offset: 0x00059D67
		' (set) Token: 0x0600CE37 RID: 52791 RVA: 0x0005BB71 File Offset: 0x00059D71
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005105 RID: 20741
		' (get) Token: 0x0600CE38 RID: 52792 RVA: 0x0005BB7A File Offset: 0x00059D7A
		' (set) Token: 0x0600CE39 RID: 52793 RVA: 0x0080C834 File Offset: 0x0080AA34
		Private _txtMsg As TextBox
		Friend Overridable Property txtMsg As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMsg
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtMsg
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtMsg = value
				textBox = Me._txtMsg
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005106 RID: 20742
		' (get) Token: 0x0600CE3A RID: 52794 RVA: 0x0005BB84 File Offset: 0x00059D84
		' (set) Token: 0x0600CE3B RID: 52795 RVA: 0x0005BB8E File Offset: 0x00059D8E
		Friend Overridable Property Label2 As Label

		' Token: 0x17005107 RID: 20743
		' (get) Token: 0x0600CE3C RID: 52796 RVA: 0x0005BB97 File Offset: 0x00059D97
		' (set) Token: 0x0600CE3D RID: 52797 RVA: 0x0005BBA1 File Offset: 0x00059DA1
		Friend Overridable Property Label1 As Label

		' Token: 0x17005108 RID: 20744
		' (get) Token: 0x0600CE3E RID: 52798 RVA: 0x0005BBAA File Offset: 0x00059DAA
		' (set) Token: 0x0600CE3F RID: 52799 RVA: 0x0005BBB4 File Offset: 0x00059DB4
		Friend Overridable Property dtRemind As DateTimePicker

		' Token: 0x17005109 RID: 20745
		' (get) Token: 0x0600CE40 RID: 52800 RVA: 0x0005BBBD File Offset: 0x00059DBD
		' (set) Token: 0x0600CE41 RID: 52801 RVA: 0x0080C878 File Offset: 0x0080AA78
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

		' Token: 0x1700510A RID: 20746
		' (get) Token: 0x0600CE42 RID: 52802 RVA: 0x0005BBC7 File Offset: 0x00059DC7
		' (set) Token: 0x0600CE43 RID: 52803 RVA: 0x0005BBD1 File Offset: 0x00059DD1
		Friend Overridable Property lblUser As Label

		' Token: 0x1700510B RID: 20747
		' (get) Token: 0x0600CE44 RID: 52804 RVA: 0x0005BBDA File Offset: 0x00059DDA
		' (set) Token: 0x0600CE45 RID: 52805 RVA: 0x0005BBE4 File Offset: 0x00059DE4
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x0600CE46 RID: 52806 RVA: 0x0080C8BC File Offset: 0x0080AABC
		Private Sub Button1_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtMsg.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please fill Reminder Message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.txtMsg.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "insert into Reminder(msg, mdate) Values (@d1,@d2)"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtMsg.Text.Trim())
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtRemind.Value.[Date])
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModFunc.LogFunc(Me.lblUser.Text, "added the new reminder for date '" + Conversions.ToString(Me.dtRemind.Value.[Date]) + "'")
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.txtMsg.Text = ""
						Me.dtRemind.Value = DateAndTime.Today
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600CE47 RID: 52807 RVA: 0x0005BBED File Offset: 0x00059DED
		Private Sub frmReminder_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CE48 RID: 52808 RVA: 0x0080CB00 File Offset: 0x0080AD00
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

		' Token: 0x0600CE49 RID: 52809 RVA: 0x0080CC78 File Offset: 0x0080AE78
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

		' Token: 0x0600CE4A RID: 52810 RVA: 0x0080CD34 File Offset: 0x0080AF34
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

		' Token: 0x0600CE4B RID: 52811 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CE4C RID: 52812 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CE4D RID: 52813 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CE4E RID: 52814 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmReminder_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CE4F RID: 52815 RVA: 0x0080CE00 File Offset: 0x0080B000
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtMsg.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtMsg, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtMsg, String.Empty)
			End If
		End Sub
	End Class
End Namespace
