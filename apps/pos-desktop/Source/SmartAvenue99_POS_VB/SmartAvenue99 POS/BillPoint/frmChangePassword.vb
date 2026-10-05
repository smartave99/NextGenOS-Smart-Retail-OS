Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005E0 RID: 1504
	<DesignerGenerated()>
	Public Partial Class frmChangePassword
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060127A1 RID: 75681 RVA: 0x0007EC29 File Offset: 0x0007CE29
		Public Sub New()
			AddHandler MyBase.FormClosing, AddressOf Me.frmChangePassword1_FormClosing
			AddHandler MyBase.Load, AddressOf Me.frmChangePassword_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x060127A2 RID: 75682
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060127A3 RID: 75683
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060127A4 RID: 75684 RVA: 0x00AA288C File Offset: 0x00AA0A8C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.UserID.Text)) = 0
				If flag Then
					MessageBox.Show("Please enter user id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.UserID.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.OldPassword.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please enter old password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.OldPassword.Focus()
					Else
						Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.NewPassword.Text)) = 0
						If flag3 Then
							MessageBox.Show("Please enter new password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.NewPassword.Focus()
						Else
							Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.ConfirmPassword.Text)) = 0
							If flag4 Then
								MessageBox.Show("Please confirm new password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.ConfirmPassword.Focus()
							Else
								Dim flag5 As Boolean = Me.NewPassword.TextLength < 5
								If flag5 Then
									MessageBox.Show("The New Password Should be of Atleast 5 Characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.NewPassword.Text = ""
									Me.ConfirmPassword.Text = ""
									Me.NewPassword.Focus()
								Else
									Dim flag6 As Boolean = Operators.CompareString(Me.NewPassword.Text, Me.ConfirmPassword.Text, False) <> 0
									If flag6 Then
										MessageBox.Show("Password do not match", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.NewPassword.Text = ""
										Me.OldPassword.Text = ""
										Me.ConfirmPassword.Text = ""
										Me.OldPassword.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.OldPassword.Text, Me.NewPassword.Text, False) = 0
										If flag7 Then
											MessageBox.Show("Password is same..Re-enter new password", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Me.NewPassword.Text = ""
											Me.ConfirmPassword.Text = ""
											Me.NewPassword.Focus()
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "update Registration set password =@d1 where userid=@d2 and password =@d3"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", ModFunc.Encrypt(Me.NewPassword.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.UserID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", ModFunc.Encrypt(Me.OldPassword.Text))
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
											Dim flag8 As Boolean = num > 0
											If flag8 Then
												Dim text2 As String = "Successfully changed the password"
												ModFunc.LogFunc(Me.UserID.Text, text2)
												MyProject.Forms.frmCustomDialog2.ShowDialog()
												MyBase.Hide()
												MyProject.Forms.frmLogin.Show()
												MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
												MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
												MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
												MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
												MyProject.Forms.frmLogin.cmbCompany.Focus()
											Else
												MessageBox.Show("Invalid user name or password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.UserID.Text = ""
												Me.NewPassword.Text = ""
												Me.OldPassword.Text = ""
												Me.ConfirmPassword.Text = ""
												Me.UserID.Focus()
											End If
											ModCommonClasses.con.Close()
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060127A5 RID: 75685 RVA: 0x00AA2D18 File Offset: 0x00AA0F18
		Public Sub OSKeyboard()
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmChangePassword.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmChangePassword.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x060127A6 RID: 75686 RVA: 0x00AA2D60 File Offset: 0x00AA0F60
		Private Sub frmChangePassword1_FormClosing(sender As Object, e As FormClosingEventArgs)
			MyBase.Hide()
			MyProject.Forms.frmLogin.Show()
			MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
			MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
			MyProject.Forms.frmLogin.cmbCompany.Focus()
			MyProject.Forms.frmLogin.cmbCompany.SelectedIndex = -1
		End Sub

		' Token: 0x060127A7 RID: 75687 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChangePassword_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060127A8 RID: 75688 RVA: 0x00AA2D60 File Offset: 0x00AA0F60
		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			MyBase.Hide()
			MyProject.Forms.frmLogin.Show()
			MyProject.Forms.frmLogin.Password.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.ForeColor = Color.Silver
			MyProject.Forms.frmLogin.UserID.Text = "Enter the User Name"
			MyProject.Forms.frmLogin.Password.Text = "Enter the Password"
			MyProject.Forms.frmLogin.cmbCompany.Focus()
			MyProject.Forms.frmLogin.cmbCompany.SelectedIndex = -1
		End Sub

		' Token: 0x060127A9 RID: 75689 RVA: 0x0007EC5B File Offset: 0x0007CE5B
		Private Sub btnKeyboard_Click(sender As Object, e As EventArgs)
			Me.OSKeyboard()
		End Sub

		' Token: 0x060127AA RID: 75690 RVA: 0x00AA2E18 File Offset: 0x00AA1018
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.UserID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.UserID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.UserID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.OldPassword.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.OldPassword, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.OldPassword, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.NewPassword.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.NewPassword, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.NewPassword, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.ConfirmPassword.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.ConfirmPassword, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ConfirmPassword, String.Empty)
			End If
		End Sub

		' Token: 0x170072AC RID: 29356
		' (get) Token: 0x060127AD RID: 75693 RVA: 0x0007EC65 File Offset: 0x0007CE65
		' (set) Token: 0x060127AE RID: 75694 RVA: 0x00AA3CC0 File Offset: 0x00AA1EC0
		Private _UserID As TextBox
		Friend Overridable Property UserID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._UserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._UserID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._UserID = value
				textBox = Me._UserID
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072AD RID: 29357
		' (get) Token: 0x060127AF RID: 75695 RVA: 0x0007EC6F File Offset: 0x0007CE6F
		' (set) Token: 0x060127B0 RID: 75696 RVA: 0x0007EC79 File Offset: 0x0007CE79
		Friend Overridable Property Label4 As Label

		' Token: 0x170072AE RID: 29358
		' (get) Token: 0x060127B1 RID: 75697 RVA: 0x0007EC82 File Offset: 0x0007CE82
		' (set) Token: 0x060127B2 RID: 75698 RVA: 0x00AA3D04 File Offset: 0x00AA1F04
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

		' Token: 0x170072AF RID: 29359
		' (get) Token: 0x060127B3 RID: 75699 RVA: 0x0007EC8C File Offset: 0x0007CE8C
		' (set) Token: 0x060127B4 RID: 75700 RVA: 0x0007EC96 File Offset: 0x0007CE96
		Friend Overridable Property Label3 As Label

		' Token: 0x170072B0 RID: 29360
		' (get) Token: 0x060127B5 RID: 75701 RVA: 0x0007EC9F File Offset: 0x0007CE9F
		' (set) Token: 0x060127B6 RID: 75702 RVA: 0x00AA3D48 File Offset: 0x00AA1F48
		Private _ConfirmPassword As TextBox
		Friend Overridable Property ConfirmPassword As TextBox
			<CompilerGenerated()>
			Get
				Return Me._ConfirmPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._ConfirmPassword
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._ConfirmPassword = value
				textBox = Me._ConfirmPassword
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072B1 RID: 29361
		' (get) Token: 0x060127B7 RID: 75703 RVA: 0x0007ECA9 File Offset: 0x0007CEA9
		' (set) Token: 0x060127B8 RID: 75704 RVA: 0x00AA3D8C File Offset: 0x00AA1F8C
		Private _NewPassword As TextBox
		Friend Overridable Property NewPassword As TextBox
			<CompilerGenerated()>
			Get
				Return Me._NewPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._NewPassword
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._NewPassword = value
				textBox = Me._NewPassword
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072B2 RID: 29362
		' (get) Token: 0x060127B9 RID: 75705 RVA: 0x0007ECB3 File Offset: 0x0007CEB3
		' (set) Token: 0x060127BA RID: 75706 RVA: 0x00AA3DD0 File Offset: 0x00AA1FD0
		Private _OldPassword As TextBox
		Friend Overridable Property OldPassword As TextBox
			<CompilerGenerated()>
			Get
				Return Me._OldPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._OldPassword
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._OldPassword = value
				textBox = Me._OldPassword
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072B3 RID: 29363
		' (get) Token: 0x060127BB RID: 75707 RVA: 0x0007ECBD File Offset: 0x0007CEBD
		' (set) Token: 0x060127BC RID: 75708 RVA: 0x0007ECC7 File Offset: 0x0007CEC7
		Friend Overridable Property Label2 As Label

		' Token: 0x170072B4 RID: 29364
		' (get) Token: 0x060127BD RID: 75709 RVA: 0x0007ECD0 File Offset: 0x0007CED0
		' (set) Token: 0x060127BE RID: 75710 RVA: 0x0007ECDA File Offset: 0x0007CEDA
		Friend Overridable Property Label1 As Label

		' Token: 0x170072B5 RID: 29365
		' (get) Token: 0x060127BF RID: 75711 RVA: 0x0007ECE3 File Offset: 0x0007CEE3
		' (set) Token: 0x060127C0 RID: 75712 RVA: 0x0007ECED File Offset: 0x0007CEED
		Friend Overridable Property Label5 As Label

		' Token: 0x170072B6 RID: 29366
		' (get) Token: 0x060127C1 RID: 75713 RVA: 0x0007ECF6 File Offset: 0x0007CEF6
		' (set) Token: 0x060127C2 RID: 75714 RVA: 0x00AA3E14 File Offset: 0x00AA2014
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

		' Token: 0x170072B7 RID: 29367
		' (get) Token: 0x060127C3 RID: 75715 RVA: 0x0007ED00 File Offset: 0x0007CF00
		' (set) Token: 0x060127C4 RID: 75716 RVA: 0x00AA3E58 File Offset: 0x00AA2058
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

		' Token: 0x170072B8 RID: 29368
		' (get) Token: 0x060127C5 RID: 75717 RVA: 0x0007ED0A File Offset: 0x0007CF0A
		' (set) Token: 0x060127C6 RID: 75718 RVA: 0x0007ED14 File Offset: 0x0007CF14
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170072B9 RID: 29369
		' (get) Token: 0x060127C7 RID: 75719 RVA: 0x0007ED1D File Offset: 0x0007CF1D
		' (set) Token: 0x060127C8 RID: 75720 RVA: 0x0007ED27 File Offset: 0x0007CF27
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170072BA RID: 29370
		' (get) Token: 0x060127C9 RID: 75721 RVA: 0x0007ED30 File Offset: 0x0007CF30
		' (set) Token: 0x060127CA RID: 75722 RVA: 0x0007ED3A File Offset: 0x0007CF3A
		Friend Overridable Property ErrorProvider1 As ErrorProvider
	End Class
End Namespace
