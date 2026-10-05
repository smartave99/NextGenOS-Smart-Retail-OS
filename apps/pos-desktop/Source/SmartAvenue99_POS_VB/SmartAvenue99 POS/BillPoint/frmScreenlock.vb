Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004D9 RID: 1241
	<DesignerGenerated()>
	Public Partial Class frmScreenlock
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FCB5 RID: 64693 RVA: 0x0006EC8D File Offset: 0x0006CE8D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmScreenlock_Load
			AddHandler MyBase.Load, AddressOf Me.PassShow_Hide_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170060A4 RID: 24740
		' (get) Token: 0x0600FCB8 RID: 64696 RVA: 0x0006ECBF File Offset: 0x0006CEBF
		' (set) Token: 0x0600FCB9 RID: 64697 RVA: 0x0006ECC9 File Offset: 0x0006CEC9
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170060A5 RID: 24741
		' (get) Token: 0x0600FCBA RID: 64698 RVA: 0x0006ECD2 File Offset: 0x0006CED2
		' (set) Token: 0x0600FCBB RID: 64699 RVA: 0x0006ECDC File Offset: 0x0006CEDC
		Friend Overridable Property Label2 As Label

		' Token: 0x170060A6 RID: 24742
		' (get) Token: 0x0600FCBC RID: 64700 RVA: 0x0006ECE5 File Offset: 0x0006CEE5
		' (set) Token: 0x0600FCBD RID: 64701 RVA: 0x0006ECEF File Offset: 0x0006CEEF
		Friend Overridable Property txtuser As TextBox

		' Token: 0x170060A7 RID: 24743
		' (get) Token: 0x0600FCBE RID: 64702 RVA: 0x0006ECF8 File Offset: 0x0006CEF8
		' (set) Token: 0x0600FCBF RID: 64703 RVA: 0x0006ED02 File Offset: 0x0006CF02
		Friend Overridable Property UsernameLabel As Label

		' Token: 0x170060A8 RID: 24744
		' (get) Token: 0x0600FCC0 RID: 64704 RVA: 0x0006ED0B File Offset: 0x0006CF0B
		' (set) Token: 0x0600FCC1 RID: 64705 RVA: 0x0006ED15 File Offset: 0x0006CF15
		Friend Overridable Property PasswordLabel As Label

		' Token: 0x170060A9 RID: 24745
		' (get) Token: 0x0600FCC2 RID: 64706 RVA: 0x0006ED1E File Offset: 0x0006CF1E
		' (set) Token: 0x0600FCC3 RID: 64707 RVA: 0x009740AC File Offset: 0x009722AC
		Private _Btnshow As Button
		Friend Overridable Property Btnshow As Button
			<CompilerGenerated()>
			Get
				Return Me._Btnshow
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Btnshow_Click
				Dim button As Button = Me._Btnshow
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Btnshow = value
				button = Me._Btnshow
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060AA RID: 24746
		' (get) Token: 0x0600FCC4 RID: 64708 RVA: 0x0006ED28 File Offset: 0x0006CF28
		' (set) Token: 0x0600FCC5 RID: 64709 RVA: 0x009740F0 File Offset: 0x009722F0
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

		' Token: 0x170060AB RID: 24747
		' (get) Token: 0x0600FCC6 RID: 64710 RVA: 0x0006ED32 File Offset: 0x0006CF32
		' (set) Token: 0x0600FCC7 RID: 64711 RVA: 0x00974134 File Offset: 0x00972334
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyUp
				Dim eventHandler As EventHandler = AddressOf Me.Text2Enter_Watermark
				Dim eventHandler2 As EventHandler = AddressOf Me.Text2Leave_Watermark
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
					RemoveHandler textBox.Enter, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
					AddHandler textBox.Enter, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170060AC RID: 24748
		' (get) Token: 0x0600FCC8 RID: 64712 RVA: 0x0006ED3C File Offset: 0x0006CF3C
		' (set) Token: 0x0600FCC9 RID: 64713 RVA: 0x0006ED46 File Offset: 0x0006CF46
		Friend Overridable Property LogoPictureBox As PictureBox

		' Token: 0x170060AD RID: 24749
		' (get) Token: 0x0600FCCA RID: 64714 RVA: 0x0006ED4F File Offset: 0x0006CF4F
		' (set) Token: 0x0600FCCB RID: 64715 RVA: 0x0006ED59 File Offset: 0x0006CF59
		Friend Overridable Property UserType As TextBox

		' Token: 0x170060AE RID: 24750
		' (get) Token: 0x0600FCCC RID: 64716 RVA: 0x0006ED62 File Offset: 0x0006CF62
		' (set) Token: 0x0600FCCD RID: 64717 RVA: 0x009741B0 File Offset: 0x009723B0
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060AF RID: 24751
		' (get) Token: 0x0600FCCE RID: 64718 RVA: 0x0006ED6C File Offset: 0x0006CF6C
		' (set) Token: 0x0600FCCF RID: 64719 RVA: 0x0006ED76 File Offset: 0x0006CF76
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170060B0 RID: 24752
		' (get) Token: 0x0600FCD0 RID: 64720 RVA: 0x0006ED7F File Offset: 0x0006CF7F
		' (set) Token: 0x0600FCD1 RID: 64721 RVA: 0x009741F4 File Offset: 0x009723F4
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060B1 RID: 24753
		' (get) Token: 0x0600FCD2 RID: 64722 RVA: 0x0006ED89 File Offset: 0x0006CF89
		' (set) Token: 0x0600FCD3 RID: 64723 RVA: 0x00974238 File Offset: 0x00972438
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060B2 RID: 24754
		' (get) Token: 0x0600FCD4 RID: 64724 RVA: 0x0006ED93 File Offset: 0x0006CF93
		' (set) Token: 0x0600FCD5 RID: 64725 RVA: 0x0097427C File Offset: 0x0097247C
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

		' Token: 0x0600FCD6 RID: 64726
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600FCD7 RID: 64727
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600FCD8 RID: 64728 RVA: 0x0006ED9D File Offset: 0x0006CF9D
		Private Sub frmScreenlock_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FCD9 RID: 64729 RVA: 0x009742C0 File Offset: 0x009724C0
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

		' Token: 0x0600FCDA RID: 64730 RVA: 0x00974438 File Offset: 0x00972638
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

		' Token: 0x0600FCDB RID: 64731 RVA: 0x009744F4 File Offset: 0x009726F4
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

		' Token: 0x0600FCDC RID: 64732 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FCDD RID: 64733 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FCDE RID: 64734 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FCDF RID: 64735 RVA: 0x009745C0 File Offset: 0x009727C0
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtuser.Text)) = 0
				Dim flag4 As Boolean = flag3
				If flag4 Then
					Me.txtuser.Focus()
					Interaction.Beep()
					MyProject.Forms.Error5.ShowDialog()
					MyProject.Forms.Error5.Dispose()
					MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					flag3 = (Strings.Len(Strings.Trim(Me.TextBox2.Text)) = 0) Or (Operators.CompareString(Me.TextBox2.Text, "Enter the Password", False) = 0)
					Dim flag5 As Boolean = flag3
					If flag5 Then
						Me.TextBox2.Focus()
						Interaction.Beep()
						MyProject.Forms.Error6.ShowDialog()
						MyProject.Forms.Error6.Dispose()
						MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
							ModCommonClasses.cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where UserID = @d1 and Password=@d2 and Active='Yes'"
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtuser.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.Encrypt(Me.TextBox2.Text))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
							If flag6 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
								ModCommonClasses.cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtuser.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.Encrypt(Me.TextBox2.Text))
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
								If flag7 Then
									Me.UserType.Text = ModCommonClasses.rdr.GetValue(0).ToString().Trim()
								End If
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
								Dim flag9 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
								If flag9 Then
									ModCommonClasses.con.Close()
								End If
								Dim text2 As String = "Screen Unlocked"
								ModFunc.LogFunc(Me.txtuser.Text, text2)
								MyBase.Close()
							Else
								Me.TextBox2.Text = "Enter the Password"
								Me.TextBox2.Focus()
								Interaction.Beep()
								MyProject.Forms.Error8.ShowDialog()
								MyProject.Forms.Error8.Dispose()
							End If
							ModCommonClasses.cmd.Dispose()
							ModCommonClasses.con.Close()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600FCE0 RID: 64736 RVA: 0x009749BC File Offset: 0x00972BBC
		Private Function Encrypt(password As String) As String
			Dim empty As String = String.Empty
			Dim array As Byte() = New Byte(password.Length - 1 + 1 - 1) {}
			array = Encoding.UTF8.GetBytes(password)
			Return Convert.ToBase64String(array)
		End Function

		' Token: 0x0600FCE1 RID: 64737 RVA: 0x00199EB4 File Offset: 0x001980B4
		Private Function Decrypt(encryptpwd As String) As String
			Dim empty As String = String.Empty
			Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
			Dim decoder As Decoder = utf8Encoding.GetDecoder()
			Dim array As Byte() = Convert.FromBase64String(encryptpwd)
			Dim charCount As Integer = decoder.GetCharCount(array, 0, array.Length)
			Dim array2 As Char() = New Char(charCount - 1 + 1 - 1) {}
			decoder.GetChars(array, 0, array.Length, array2, 0)
			Return New String(array2)
		End Function

		' Token: 0x0600FCE2 RID: 64738 RVA: 0x0006EDA7 File Offset: 0x0006CFA7
		Private Sub PassShow_Hide_Load(sender As Object, e As EventArgs)
			Me.TextBox2.PasswordChar = "✹"c
		End Sub

		' Token: 0x0600FCE3 RID: 64739 RVA: 0x0078F31C File Offset: 0x0078D51C
		Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				SendKeys.Send("{ENTER}")
			End If
		End Sub

		' Token: 0x0600FCE4 RID: 64740 RVA: 0x0006EDBB File Offset: 0x0006CFBB
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			ModFunc.LogFunc(MyProject.Forms.frmLogin.UserID.Text, "Exit Successfully")
			ProjectData.EndApp()
		End Sub

		' Token: 0x0600FCE5 RID: 64741 RVA: 0x009749F8 File Offset: 0x00972BF8
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmScreenlock.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmScreenlock.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x0600FCE6 RID: 64742 RVA: 0x00974A40 File Offset: 0x00972C40
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(Me.TextBox2.PasswordChar), "✹", False) = 0
			If flag Then
				Me.TextBox2.PasswordChar = vbNullChar
				Me.Button5.Visible = False
				Me.Button2.Visible = True
			End If
		End Sub

		' Token: 0x0600FCE7 RID: 64743 RVA: 0x0006EDE3 File Offset: 0x0006CFE3
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.TextBox2.PasswordChar = "✹"c
			Me.Button5.Visible = True
			Me.Button2.Visible = False
		End Sub

		' Token: 0x0600FCE8 RID: 64744 RVA: 0x00974A9C File Offset: 0x00972C9C
		Private Sub Text2Enter_Watermark(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox2.Text, "Enter the Password", False) = 0
			If flag Then
				Me.TextBox2.Text = ""
				Me.TextBox2.ForeColor = Color.Navy
			End If
		End Sub

		' Token: 0x0600FCE9 RID: 64745 RVA: 0x00974AEC File Offset: 0x00972CEC
		Private Sub Text2Leave_Watermark(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
			If flag Then
				Me.TextBox2.Text = "Enter the Password"
				Me.TextBox2.ForeColor = Color.Silver
			End If
		End Sub

		' Token: 0x0600FCEA RID: 64746 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Btnshow_Click(sender As Object, e As EventArgs)
		End Sub
	End Class
End Namespace
