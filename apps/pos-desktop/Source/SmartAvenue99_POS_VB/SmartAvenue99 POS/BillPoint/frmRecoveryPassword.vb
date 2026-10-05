Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000596 RID: 1430
	<DesignerGenerated()>
	Public Partial Class frmRecoveryPassword
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011969 RID: 72041 RVA: 0x000792EF File Offset: 0x000774EF
		Public Sub New()
			AddHandler MyBase.FormClosing, AddressOf Me.frmChangePassword1_FormClosing
			AddHandler MyBase.Load, AddressOf Me.frmChangePassword_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006D1E RID: 27934
		' (get) Token: 0x0601196C RID: 72044 RVA: 0x00079321 File Offset: 0x00077521
		' (set) Token: 0x0601196D RID: 72045 RVA: 0x00A325EC File Offset: 0x00A307EC
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmailID_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.txtEmailID_Validating
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D1F RID: 27935
		' (get) Token: 0x0601196E RID: 72046 RVA: 0x0007932B File Offset: 0x0007752B
		' (set) Token: 0x0601196F RID: 72047 RVA: 0x00079335 File Offset: 0x00077535
		Friend Overridable Property Label4 As Label

		' Token: 0x17006D20 RID: 27936
		' (get) Token: 0x06011970 RID: 72048 RVA: 0x0007933E File Offset: 0x0007753E
		' (set) Token: 0x06011971 RID: 72049 RVA: 0x00A3264C File Offset: 0x00A3084C
		Private _btnSendMail As Button
		Friend Overridable Property btnSendMail As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSendMail
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._btnSendMail
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSendMail = value
				button = Me._btnSendMail
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D21 RID: 27937
		' (get) Token: 0x06011972 RID: 72050 RVA: 0x00079348 File Offset: 0x00077548
		' (set) Token: 0x06011973 RID: 72051 RVA: 0x00079352 File Offset: 0x00077552
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006D22 RID: 27938
		' (get) Token: 0x06011974 RID: 72052 RVA: 0x0007935B File Offset: 0x0007755B
		' (set) Token: 0x06011975 RID: 72053 RVA: 0x00079365 File Offset: 0x00077565
		Friend Overridable Property Label5 As Label

		' Token: 0x17006D23 RID: 27939
		' (get) Token: 0x06011976 RID: 72054 RVA: 0x0007936E File Offset: 0x0007756E
		' (set) Token: 0x06011977 RID: 72055 RVA: 0x00A32690 File Offset: 0x00A30890
		Private _btnKeyboard As Button
		Friend Overridable Property btnKeyboard As Button
			<CompilerGenerated()>
			Get
				Return Me._btnKeyboard
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnKeyboard_Click
				Dim button As Button = Me._btnKeyboard
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnKeyboard = value
				button = Me._btnKeyboard
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D24 RID: 27940
		' (get) Token: 0x06011978 RID: 72056 RVA: 0x00079378 File Offset: 0x00077578
		' (set) Token: 0x06011979 RID: 72057 RVA: 0x00A326D4 File Offset: 0x00A308D4
		Private _btnCancel As Button
		Friend Overridable Property btnCancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCancel_Click
				Dim button As Button = Me._btnCancel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCancel = value
				button = Me._btnCancel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D25 RID: 27941
		' (get) Token: 0x0601197A RID: 72058 RVA: 0x00079382 File Offset: 0x00077582
		' (set) Token: 0x0601197B RID: 72059 RVA: 0x0007938C File Offset: 0x0007758C
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17006D26 RID: 27942
		' (get) Token: 0x0601197C RID: 72060 RVA: 0x00079395 File Offset: 0x00077595
		' (set) Token: 0x0601197D RID: 72061 RVA: 0x00A32718 File Offset: 0x00A30918
		Private _Timer2 As Timer
		Friend Overridable Property Timer2 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D27 RID: 27943
		' (get) Token: 0x0601197E RID: 72062 RVA: 0x0007939F File Offset: 0x0007759F
		' (set) Token: 0x0601197F RID: 72063 RVA: 0x000793A9 File Offset: 0x000775A9
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17006D28 RID: 27944
		' (get) Token: 0x06011980 RID: 72064 RVA: 0x000793B2 File Offset: 0x000775B2
		' (set) Token: 0x06011981 RID: 72065 RVA: 0x000793BC File Offset: 0x000775BC
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x06011982 RID: 72066
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x06011983 RID: 72067
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x06011984 RID: 72068 RVA: 0x00A3275C File Offset: 0x00A3095C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Please enter Email ID", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtEmailID.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select count(*) from EmailSetting Having count(*) <=0"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MyProject.Forms.frmCustomDialog1.ShowDialog()
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select EmailID from registration where EmailID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmailID.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag5 Then
							MyProject.Forms.frmCustomDialog.ShowDialog()
							Me.txtEmailID.Text = ""
							Me.txtEmailID.Focus()
							Dim flag6 As Boolean = Not ModCommonClasses.rdr.Read()
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							flag = ModFunc.CheckForInternetConnection()
							Dim flag7 As Boolean = flag
							If flag7 Then
								Me.Cursor = Cursors.WaitCursor
								Me.Timer2.Enabled = True
								ModCommonClasses.ds = New DataSet()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim sqlCommand As SqlCommand = New SqlCommand("SELECT Password FROM Registration Where EmailID='" + Me.txtEmailID.Text + "'", ModCommonClasses.con)
								Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
								sqlDataAdapter.Fill(ModCommonClasses.ds)
								Dim flag8 As Boolean = ModCommonClasses.ds.Tables(0).Rows.Count > 0
								If flag8 Then
									ModCommonClasses.rdr = sqlCommand.ExecuteReader()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
									ModCommonClasses.rdr = New SqlCommand(text3) With { .Connection = ModCommonClasses.con }.ExecuteReader()
									Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
									If flag9 Then
										ModFunc.SendMail(Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), Me.txtEmailID.Text, If(("Your Password: " + ModFunc.Decrypt(Convert.ToString(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(ModCommonClasses.ds.Tables(0).Rows(0)("Password")))))), ""), "Password", Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(2))), Conversions.ToInteger(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(3))), Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), ModFunc.Decrypt(Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(1)))))
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
									End If
								End If
								MessageBox.Show("Password Successfully sent " & vbCrLf & "Please check your mail", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								MyBase.Hide()
								MyProject.Forms.frmLogin.Show()
								MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
								MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
								MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
								MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
								MyProject.Forms.frmLogin.cmbCompany.Focus()
								MyProject.Forms.frmLogin.cmbCompany.SelectedIndex = -1
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011985 RID: 72069 RVA: 0x00A32C24 File Offset: 0x00A30E24
		Public Sub OSKeyboard()
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmRecoveryPassword.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmRecoveryPassword.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x06011986 RID: 72070 RVA: 0x00A32C6C File Offset: 0x00A30E6C
		Private Sub frmChangePassword1_FormClosing(sender As Object, e As FormClosingEventArgs)
			MyBase.Hide()
			MyProject.Forms.frmLogin.Show()
			MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
			MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
			MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.cmbCompany.Focus()
			MyProject.Forms.frmLogin.cmbCompany.SelectedIndex = -1
		End Sub

		' Token: 0x06011987 RID: 72071 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChangePassword_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06011988 RID: 72072 RVA: 0x00A32C6C File Offset: 0x00A30E6C
		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			MyBase.Hide()
			MyProject.Forms.frmLogin.Show()
			MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
			MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
			MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.cmbCompany.Focus()
			MyProject.Forms.frmLogin.cmbCompany.SelectedIndex = -1
		End Sub

		' Token: 0x06011989 RID: 72073 RVA: 0x000793C5 File Offset: 0x000775C5
		Private Sub btnKeyboard_Click(sender As Object, e As EventArgs)
			Me.OSKeyboard()
		End Sub

		' Token: 0x0601198A RID: 72074 RVA: 0x00A32D24 File Offset: 0x00A30F24
		Private Sub txtEmailID_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim text As String = "@"
			Dim flag As Boolean = e.KeyChar <> vbBack
			If flag Then
				Dim flag2 As Boolean = (Strings.Asc(e.KeyChar) < 97) Or (Strings.Asc(e.KeyChar) > 122)
				If flag2 Then
					Dim flag3 As Boolean = (Strings.Asc(e.KeyChar) <> 46) And (Strings.Asc(e.KeyChar) <> 95)
					If flag3 Then
						Dim flag4 As Boolean = (Strings.Asc(e.KeyChar) < 48) Or (Strings.Asc(e.KeyChar) > 57)
						If flag4 Then
							Dim flag5 As Boolean = text.IndexOf(e.KeyChar) = -1
							If flag5 Then
								e.Handled = True
							Else
								Dim flag6 As Boolean = Me.txtEmailID.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0601198B RID: 72075 RVA: 0x00A32E2C File Offset: 0x00A3102C
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtEmailID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtEmailID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmailID, String.Empty)
			End If
			Dim text As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
			Dim match As Match = Regex.Match(Me.txtEmailID.Text.Trim(), text, RegexOptions.IgnoreCase)
			Dim success As Boolean = match.Success
			If Not success Then
				MessageBox.Show("Please enter a valid email id", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.txtEmailID.Clear()
			End If
		End Sub

		' Token: 0x0601198C RID: 72076 RVA: 0x000793CF File Offset: 0x000775CF
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub
	End Class
End Namespace
