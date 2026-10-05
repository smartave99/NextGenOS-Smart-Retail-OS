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
Imports DevNet
Imports DevNet.Models
Imports DevNetWP.Classes
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004EA RID: 1258
	<DesignerGenerated()>
	Public Partial Class frmWhatsappMessage
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060102AB RID: 66219 RVA: 0x009A15A4 File Offset: 0x0099F7A4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmWhatsappMessage_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmWhatsappMessage_KeyDown
			Me.whatsApp1 = frmMainMenu.whatsApp1
			Me.InitializeComponent()
		End Sub

		' Token: 0x170062EF RID: 25327
		' (get) Token: 0x060102AE RID: 66222 RVA: 0x00071951 File Offset: 0x0006FB51
		' (set) Token: 0x060102AF RID: 66223 RVA: 0x009A1EB4 File Offset: 0x009A00B4
		Private _txtWNo As TextBox
		Friend Overridable Property txtWNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim textBox As TextBox = Me._txtWNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtWNo = value
				textBox = Me._txtWNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062F0 RID: 25328
		' (get) Token: 0x060102B0 RID: 66224 RVA: 0x0007195B File Offset: 0x0006FB5B
		' (set) Token: 0x060102B1 RID: 66225 RVA: 0x00071965 File Offset: 0x0006FB65
		Friend Overridable Property txtWMsg As TextBox

		' Token: 0x170062F1 RID: 25329
		' (get) Token: 0x060102B2 RID: 66226 RVA: 0x0007196E File Offset: 0x0006FB6E
		' (set) Token: 0x060102B3 RID: 66227 RVA: 0x009A1EF8 File Offset: 0x009A00F8
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

		' Token: 0x170062F2 RID: 25330
		' (get) Token: 0x060102B4 RID: 66228 RVA: 0x00071978 File Offset: 0x0006FB78
		' (set) Token: 0x060102B5 RID: 66229 RVA: 0x00071982 File Offset: 0x0006FB82
		Friend Overridable Property Label2 As Label

		' Token: 0x170062F3 RID: 25331
		' (get) Token: 0x060102B6 RID: 66230 RVA: 0x0007198B File Offset: 0x0006FB8B
		' (set) Token: 0x060102B7 RID: 66231 RVA: 0x00071995 File Offset: 0x0006FB95
		Friend Overridable Property Label3 As Label

		' Token: 0x170062F4 RID: 25332
		' (get) Token: 0x060102B8 RID: 66232 RVA: 0x0007199E File Offset: 0x0006FB9E
		' (set) Token: 0x060102B9 RID: 66233 RVA: 0x000719A8 File Offset: 0x0006FBA8
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170062F5 RID: 25333
		' (get) Token: 0x060102BA RID: 66234 RVA: 0x000719B1 File Offset: 0x0006FBB1
		' (set) Token: 0x060102BB RID: 66235 RVA: 0x009A1F3C File Offset: 0x009A013C
		Private _btnListReset1 As Button
		Friend Overridable Property btnListReset1 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListReset1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListReset1_Click
				Dim button As Button = Me._btnListReset1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListReset1 = value
				button = Me._btnListReset1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170062F6 RID: 25334
		' (get) Token: 0x060102BC RID: 66236 RVA: 0x000719BB File Offset: 0x0006FBBB
		' (set) Token: 0x060102BD RID: 66237 RVA: 0x000719C5 File Offset: 0x0006FBC5
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x170062F7 RID: 25335
		' (get) Token: 0x060102BE RID: 66238 RVA: 0x000719CE File Offset: 0x0006FBCE
		' (set) Token: 0x060102BF RID: 66239 RVA: 0x009A1F80 File Offset: 0x009A0180
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060102C0 RID: 66240 RVA: 0x009A1FC4 File Offset: 0x009A01C4
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts = NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(1), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
				Else
					Me.TextBox3.Text = "+91"
					Me.sts = "Disabled"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060102C1 RID: 66241 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060102C2 RID: 66242 RVA: 0x009A20E0 File Offset: 0x009A02E0
		Private Async Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtWNo.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please Enter WhatsApp No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtWNo.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtWMsg.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Message", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtWMsg.Focus()
					Else
						Dim flag4 As Boolean = ModFunc.CheckForInternetConnection()
						If flag4 Then
							Try
								Dim WP As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
								Dim dct As Dictionary(Of String, Object) = WP.WhatsAppTextSender(Me.TextBox3.Text + Me.txtWNo.Text, Me.txtWMsg.Text, frmLogin.InstanceID)
								Dim newresult As String = ""
								Dim flag5 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(dct("success")))
								If flag5 Then
									newresult = dct("result").ToString()
									MessageBox.Show("Success")
								Else
									newresult = dct("message").ToString()
									MessageBox.Show(newresult)
								End If
							Catch ex As Exception
								Dim exception As Exception = ex
								MessageBox.Show(exception.Message)
							End Try
						Else
							MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060102C3 RID: 66243 RVA: 0x000719D8 File Offset: 0x0006FBD8
		Private Sub btnListReset1_Click(sender As Object, e As EventArgs)
			Me.txtWNo.Text = ""
			Me.txtWMsg.Text = ""
			Me.txtWNo.Focus()
		End Sub

		' Token: 0x060102C4 RID: 66244 RVA: 0x00071A09 File Offset: 0x0006FC09
		Private Sub frmWhatsappMessage_Load(sender As Object, e As EventArgs)
			Me.statusdisplay()
			Me.Convert_Language()
		End Sub

		' Token: 0x060102C5 RID: 66245 RVA: 0x009A2128 File Offset: 0x009A0328
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

		' Token: 0x060102C6 RID: 66246 RVA: 0x009A22A0 File Offset: 0x009A04A0
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

		' Token: 0x060102C7 RID: 66247 RVA: 0x009A235C File Offset: 0x009A055C
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

		' Token: 0x060102C8 RID: 66248 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060102C9 RID: 66249 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060102CA RID: 66250 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060102CB RID: 66251 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmWhatsappMessage_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060102CC RID: 66252 RVA: 0x009A2428 File Offset: 0x009A0628
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtWNo.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please Enter WhatsApp No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtWNo.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtWMsg.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Message", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtWMsg.Focus()
					Else
						Dim flag4 As Boolean = ModFunc.CheckForInternetConnection()
						If flag4 Then
							Try
								Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = Me.TextBox3.Text + Me.txtWNo.Text, .Message = Me.txtWMsg.Text, .AttachmentPath = "" }
								Dim response As MessageResponse = Await Me.whatsApp1.Send(messageRequest)
								MessageBox.Show(response.Status.Description())
							Catch exception As Exception
								MessageBox.Show(exception.Message)
							End Try
						Else
							MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0400633B RID: 25403
		Private sts As String

		' Token: 0x0400633C RID: 25404
		Private whatsApp1 As WhatsApp
	End Class
End Namespace
