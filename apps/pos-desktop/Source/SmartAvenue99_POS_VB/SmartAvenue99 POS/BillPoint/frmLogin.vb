Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32

Namespace BillPoint
	' Token: 0x020005D3 RID: 1491
	<DesignerGenerated()>
	Public Partial Class frmLogin
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012388 RID: 74632 RVA: 0x00A7ABB4 File Offset: 0x00A78DB4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.LoginForm1_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmLogin_FormClosing
			Me.frm = New frmMainMenu()
			Me.str = "Attempt : "
			Me.InitializeComponent()
			AddHandler MyBase.Shown, Sub(sender, e)
				If Not AppleUITheme.IsCapturing Then RetailLayouts.Apply(Me)
			End Sub
		End Sub

		' Token: 0x17007126 RID: 28966
		' (get) Token: 0x0601238A RID: 74634 RVA: 0x0007CF7D File Offset: 0x0007B17D
		' (set) Token: 0x0601238B RID: 74635 RVA: 0x00A7AC5C File Offset: 0x00A78E5C
		Private _UserID As TextBox
		Friend Overridable Property UserID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._UserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.Username_Enter
				Dim eventHandler2 As EventHandler = AddressOf Me.Username_Leave
				Dim textBox As TextBox = Me._UserID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Enter, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._UserID = value
				textBox = Me._UserID
				If textBox IsNot Nothing Then
					AddHandler textBox.Enter, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17007127 RID: 28967
		' (get) Token: 0x0601238C RID: 74636 RVA: 0x0007CF87 File Offset: 0x0007B187
		' (set) Token: 0x0601238D RID: 74637 RVA: 0x00A7ACBC File Offset: 0x00A78EBC
		Private _Password As TextBox
		Friend Overridable Property Password As TextBox
			<CompilerGenerated()>
			Get
				Return Me._Password
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.Password_Enter
				Dim eventHandler2 As EventHandler = AddressOf Me.Password_Leave
				Dim textBox As TextBox = Me._Password
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Enter, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._Password = value
				textBox = Me._Password
				If textBox IsNot Nothing Then
					AddHandler textBox.Enter, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17007128 RID: 28968
		' (get) Token: 0x0601238E RID: 74638 RVA: 0x0007CF91 File Offset: 0x0007B191
		' (set) Token: 0x0601238F RID: 74639 RVA: 0x00A7AD1C File Offset: 0x00A78F1C
		Private _OK As Button
		Friend Overridable Property OK As Button
			<CompilerGenerated()>
			Get
				Return Me._OK
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.OK_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Ok_MH
				Dim eventHandler3 As EventHandler = AddressOf Me.Ok_LV
				Dim button As Button = Me._OK
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
					RemoveHandler button.MouseLeave, eventHandler3
				End If
				Me._OK = value
				button = Me._OK
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
					AddHandler button.MouseLeave, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x17007129 RID: 28969
		' (get) Token: 0x06012390 RID: 74640 RVA: 0x0007CF9B File Offset: 0x0007B19B
		' (set) Token: 0x06012391 RID: 74641 RVA: 0x00A7AD98 File Offset: 0x00A78F98
		Private _Cancel As Button
		Friend Overridable Property Cancel As Button
			<CompilerGenerated()>
			Get
				Return Me._Cancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Cancel_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.CL_MH
				Dim eventHandler3 As EventHandler = AddressOf Me.CL_LV
				Dim button As Button = Me._Cancel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
					RemoveHandler button.MouseLeave, eventHandler3
				End If
				Me._Cancel = value
				button = Me._Cancel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
					AddHandler button.MouseLeave, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x1700712A RID: 28970
		' (get) Token: 0x06012393 RID: 74643 RVA: 0x0007CFA5 File Offset: 0x0007B1A5
		' (set) Token: 0x06012394 RID: 74644 RVA: 0x0007CFAF File Offset: 0x0007B1AF
		Friend Overridable Property UserType As TextBox

		' Token: 0x1700712B RID: 28971
		' (get) Token: 0x06012395 RID: 74645 RVA: 0x0007CFB8 File Offset: 0x0007B1B8
		' (set) Token: 0x06012396 RID: 74646 RVA: 0x0007CFC2 File Offset: 0x0007B1C2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700712C RID: 28972
		' (get) Token: 0x06012397 RID: 74647 RVA: 0x0007CFCB File Offset: 0x0007B1CB
		' (set) Token: 0x06012398 RID: 74648 RVA: 0x00A7C7FC File Offset: 0x00A7A9FC
		Private _btnRecoveryPassword As Button
		Friend Overridable Property btnRecoveryPassword As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRecoveryPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRecoveryPassword_MouseHover
				Dim eventHandler2 As EventHandler = AddressOf Me.btnRecoveryPassword_Click
				Dim button As Button = Me._btnRecoveryPassword
				If button IsNot Nothing Then
					RemoveHandler button.MouseHover, eventHandler
					RemoveHandler button.Click, eventHandler2
				End If
				Me._btnRecoveryPassword = value
				button = Me._btnRecoveryPassword
				If button IsNot Nothing Then
					AddHandler button.MouseHover, eventHandler
					AddHandler button.Click, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700712D RID: 28973
		' (get) Token: 0x06012399 RID: 74649 RVA: 0x0007CFD5 File Offset: 0x0007B1D5
		' (set) Token: 0x0601239A RID: 74650 RVA: 0x00A7C85C File Offset: 0x00A7AA5C
		Private _btnChangePassword As Button
		Friend Overridable Property btnChangePassword As Button
			<CompilerGenerated()>
			Get
				Return Me._btnChangePassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnChangePassword_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.btnChangePassword_MouseHover
				Dim button As Button = Me._btnChangePassword
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._btnChangePassword = value
				button = Me._btnChangePassword
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700712E RID: 28974
		' (get) Token: 0x0601239B RID: 74651 RVA: 0x0007CFDF File Offset: 0x0007B1DF
		' (set) Token: 0x0601239C RID: 74652 RVA: 0x00A7C8BC File Offset: 0x00A7AABC
		Private _btnKeyboard As Button
		Friend Overridable Property btnKeyboard As Button
			<CompilerGenerated()>
			Get
				Return Me._btnKeyboard
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnKeyboard_MouseHover
				Dim eventHandler2 As EventHandler = AddressOf Me.btnKeyboard_Click
				Dim button As Button = Me._btnKeyboard
				If button IsNot Nothing Then
					RemoveHandler button.MouseHover, eventHandler
					RemoveHandler button.Click, eventHandler2
				End If
				Me._btnKeyboard = value
				button = Me._btnKeyboard
				If button IsNot Nothing Then
					AddHandler button.MouseHover, eventHandler
					AddHandler button.Click, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700712F RID: 28975
		' (get) Token: 0x0601239D RID: 74653 RVA: 0x0007CFE9 File Offset: 0x0007B1E9
		' (set) Token: 0x0601239E RID: 74654 RVA: 0x0007CFF3 File Offset: 0x0007B1F3
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17007130 RID: 28976
		' (get) Token: 0x0601239F RID: 74655 RVA: 0x0007CFFC File Offset: 0x0007B1FC
		' (set) Token: 0x060123A0 RID: 74656 RVA: 0x0007D006 File Offset: 0x0007B206
		Friend Overridable Property Label3 As Label

		' Token: 0x17007131 RID: 28977
		' (get) Token: 0x060123A1 RID: 74657 RVA: 0x0007D00F File Offset: 0x0007B20F
		' (set) Token: 0x060123A2 RID: 74658 RVA: 0x0007D019 File Offset: 0x0007B219
		Friend Overridable Property Label2 As Label

		' Token: 0x17007132 RID: 28978
		' (get) Token: 0x060123A3 RID: 74659 RVA: 0x0007D022 File Offset: 0x0007B222
		' (set) Token: 0x060123A4 RID: 74660 RVA: 0x0007D02C File Offset: 0x0007B22C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17007133 RID: 28979
		' (get) Token: 0x060123A5 RID: 74661 RVA: 0x0007D035 File Offset: 0x0007B235
		' (set) Token: 0x060123A6 RID: 74662 RVA: 0x00A7C91C File Offset: 0x00A7AB1C
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

		' Token: 0x17007134 RID: 28980
		' (get) Token: 0x060123A7 RID: 74663 RVA: 0x0007D03F File Offset: 0x0007B23F
		' (set) Token: 0x060123A8 RID: 74664 RVA: 0x00A7C960 File Offset: 0x00A7AB60
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

		' Token: 0x17007135 RID: 28981
		' (get) Token: 0x060123A9 RID: 74665 RVA: 0x0007D049 File Offset: 0x0007B249
		' (set) Token: 0x060123AA RID: 74666 RVA: 0x00A7C9A4 File Offset: 0x00A7ABA4
		Private _cmbCompany As ComboBox
		Friend Overridable Property cmbCompany As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCompany
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCompany_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCompany
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCompany = value
				comboBox = Me._cmbCompany
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007136 RID: 28982
		' (get) Token: 0x060123AB RID: 74667 RVA: 0x0007D053 File Offset: 0x0007B253
		' (set) Token: 0x060123AC RID: 74668 RVA: 0x0007D05D File Offset: 0x0007B25D
		Friend Overridable Property txtDBName As TextBox

		' Token: 0x17007137 RID: 28983
		' (get) Token: 0x060123AD RID: 74669 RVA: 0x0007D066 File Offset: 0x0007B266
		' (set) Token: 0x060123AE RID: 74670 RVA: 0x0007D070 File Offset: 0x0007B270
		Friend Overridable Property Label5 As Label

		' Token: 0x17007138 RID: 28984
		' (get) Token: 0x060123AF RID: 74671 RVA: 0x0007D079 File Offset: 0x0007B279
		' (set) Token: 0x060123B0 RID: 74672 RVA: 0x00A7C9E8 File Offset: 0x00A7ABE8
		Private _btnCompany As Button
		Friend Overridable Property btnCompany As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCompany
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Create_Company
				Dim eventHandler2 As EventHandler = AddressOf Me.btnCompany_Click
				Dim button As Button = Me._btnCompany
				If button IsNot Nothing Then
					RemoveHandler button.MouseHover, eventHandler
					RemoveHandler button.Click, eventHandler2
				End If
				Me._btnCompany = value
				button = Me._btnCompany
				If button IsNot Nothing Then
					AddHandler button.MouseHover, eventHandler
					AddHandler button.Click, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17007139 RID: 28985
		' (get) Token: 0x060123B1 RID: 74673 RVA: 0x0007D083 File Offset: 0x0007B283
		' (set) Token: 0x060123B2 RID: 74674 RVA: 0x0007D08D File Offset: 0x0007B28D
		Friend Overridable Property lblAttempt As Label

		' Token: 0x1700713A RID: 28986
		' (get) Token: 0x060123B3 RID: 74675 RVA: 0x0007D096 File Offset: 0x0007B296
		' (set) Token: 0x060123B4 RID: 74676 RVA: 0x0007D0A0 File Offset: 0x0007B2A0
		Friend Overridable Property Label1 As Label

		' Token: 0x1700713B RID: 28987
		' (get) Token: 0x060123B5 RID: 74677 RVA: 0x0007D0A9 File Offset: 0x0007B2A9
		' (set) Token: 0x060123B6 RID: 74678 RVA: 0x0007D0B3 File Offset: 0x0007B2B3
		Friend Overridable Property LabelMsg As Label

		' Token: 0x1700713C RID: 28988
		' (get) Token: 0x060123B7 RID: 74679 RVA: 0x0007D0BC File Offset: 0x0007B2BC
		' (set) Token: 0x060123B8 RID: 74680 RVA: 0x00A7CA48 File Offset: 0x00A7AC48
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

		' Token: 0x1700713D RID: 28989
		' (get) Token: 0x060123B9 RID: 74681 RVA: 0x0007D0C6 File Offset: 0x0007B2C6
		' (set) Token: 0x060123BA RID: 74682 RVA: 0x0007D0D0 File Offset: 0x0007B2D0
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700713E RID: 28990
		' (get) Token: 0x060123BB RID: 74683 RVA: 0x0007D0D9 File Offset: 0x0007B2D9
		' (set) Token: 0x060123BC RID: 74684 RVA: 0x0007D0E3 File Offset: 0x0007B2E3
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700713F RID: 28991
		' (get) Token: 0x060123BD RID: 74685 RVA: 0x0007D0EC File Offset: 0x0007B2EC
		' (set) Token: 0x060123BE RID: 74686 RVA: 0x0007D0F6 File Offset: 0x0007B2F6
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17007140 RID: 28992
		' (get) Token: 0x060123BF RID: 74687 RVA: 0x0007D0FF File Offset: 0x0007B2FF
		' (set) Token: 0x060123C0 RID: 74688 RVA: 0x0007D109 File Offset: 0x0007B309
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17007141 RID: 28993
		' (get) Token: 0x060123C1 RID: 74689 RVA: 0x0007D112 File Offset: 0x0007B312
		' (set) Token: 0x060123C2 RID: 74690 RVA: 0x0007D11C File Offset: 0x0007B31C
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17007142 RID: 28994
		' (get) Token: 0x060123C3 RID: 74691 RVA: 0x0007D125 File Offset: 0x0007B325
		' (set) Token: 0x060123C4 RID: 74692 RVA: 0x0007D12F File Offset: 0x0007B32F
		Friend Overridable Property chkRememberme As CheckBox

		' Token: 0x17007143 RID: 28995
		' (get) Token: 0x060123C5 RID: 74693 RVA: 0x0007D138 File Offset: 0x0007B338
		' (set) Token: 0x060123C6 RID: 74694 RVA: 0x0007D142 File Offset: 0x0007B342
		Friend Overridable Property cmbLang As ComboBox

		' Token: 0x17007144 RID: 28996
		' (get) Token: 0x060123C7 RID: 74695 RVA: 0x0007D14B File Offset: 0x0007B34B
		' (set) Token: 0x060123C8 RID: 74696 RVA: 0x00A7CA8C File Offset: 0x00A7AC8C
		Private _btnHelp As Button
		Friend Overridable Property btnHelp As Button
			<CompilerGenerated()>
			Get
				Return Me._btnHelp
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnHelp_Click
				Dim button As Button = Me._btnHelp
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnHelp = value
				button = Me._btnHelp
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060123C9 RID: 74697
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060123CA RID: 74698
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060123CB RID: 74699 RVA: 0x00A7CAD0 File Offset: 0x00A7ACD0
		Public Sub fillCompany()
			Try
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CompanyName) FROM RaintechMaster order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCompany.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbCompany.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060123CC RID: 74700 RVA: 0x00A7CC70 File Offset: 0x00A7AE70
		Private Sub OK_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.cmbCompany.SelectedIndex = -1
				If flag Then
					MessageBox.Show("Choose a store to sign in.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCompany.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.UserID.Text)) = 0
					If flag2 Then
						MessageBox.Show("Enter your username to sign in.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.UserID.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.UserID.Text, "Enter the User Name", False) = 0
						If flag3 Then
							MessageBox.Show("Enter your username to sign in.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.UserID.Focus()
							Me.UserID.Text = ""
							Me.UserID.ForeColor = Color.OrangeRed
						Else
							Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.Password.Text)) = 0
							If flag4 Then
								MessageBox.Show("Enter your password to sign in.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.Password.Focus()
							Else
								Dim flag5 As Boolean = Operators.CompareString(Me.Password.Text, "Enter the Password", False) = 0
								If flag5 Then
									MessageBox.Show("Enter your password to sign in.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.Password.Focus()
									Me.Password.Text = ""
									Me.Password.ForeColor = Color.OrangeRed
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
									ModCommonClasses.con.Open()
									ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
									ModCommonClasses.cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where UserID = @d1 and Password=@d2 and Active='Yes'"
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.UserID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", ModFunc.Encrypt(Me.Password.Text))
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
									If flag6 Then
										ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
										ModCommonClasses.con.Open()
										ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
										ModCommonClasses.cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.UserID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", ModFunc.Encrypt(Me.Password.Text))
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
										Dim flag10 As Boolean = Operators.CompareString(Me.UserType.Text, "Admin", False) = 0
										If flag10 Then
											Me.frm.Button3.Enabled = True
											Me.frm.UserPermissionSettingsToolStripMenuItem.Visible = True
											Me.frm.lblUser.Text = Me.UserID.Text
											Me.frm.lblUserType.Text = Me.UserType.Text
											Me.frm.txtDB.Text = Me.txtDBName.Text
											Dim text As String = "Successfully logged in"
											Dim text2 As String = "HKEY_CURRENT_USER\Software\" + MyProject.Application.Info.ProductName
											Dim text3 As String = "DefaultLanguage"
											Registry.SetValue(text2, text3, Me.cmbLang.Text)
											GlobalVariables.LoggedInLang_code = Me.cmbLang.Text.ToString()
											ModFunc.LogFunc(Me.UserID.Text, text)
											MyBase.Hide()
											Me.frm.Show()
										End If
										Dim flag11 As Boolean = Operators.CompareString(Me.UserType.Text, "Moderator", False) = 0
										If flag11 Then
											Me.frm.Button3.Enabled = True
											Me.frm.UserPermissionSettingsToolStripMenuItem.Visible = True
											Me.frm.lblUser.Text = Me.UserID.Text
											Me.frm.lblUserType.Text = Me.UserType.Text
											Me.frm.txtDB.Text = Me.txtDBName.Text
											Dim text4 As String = "Successfully logged in"
											ModFunc.LogFunc(Me.UserID.Text, text4)
											MyBase.Hide()
											Me.frm.Show()
										End If
										Dim flag12 As Boolean = Operators.CompareString(Me.UserType.Text, "Sales Person", False) = 0
										If flag12 Then
											Me.frm.Button3.Enabled = True
											Me.frm.UserPermissionSettingsToolStripMenuItem.Visible = False
											Me.frm.lblUser.Text = Me.UserID.Text
											Me.frm.lblUserType.Text = Me.UserType.Text
											Me.frm.txtDB.Text = Me.txtDBName.Text
											Dim text5 As String = "Successfully logged in"
											ModFunc.LogFunc(Me.UserID.Text, text5)
											MyBase.Hide()
											Me.frm.Show()
										End If
										Dim flag13 As Boolean = Operators.CompareString(Me.UserType.Text, "Inventory Manager", False) = 0
										If flag13 Then
											Me.frm.Button3.Enabled = False
											Me.frm.UserPermissionSettingsToolStripMenuItem.Visible = False
											Me.frm.lblUser.Text = Me.UserID.Text
											Me.frm.lblUserType.Text = Me.UserType.Text
											Me.frm.txtDB.Text = Me.txtDBName.Text
											Dim text6 As String = "Successfully logged in"
											ModFunc.LogFunc(Me.UserID.Text, text6)
											MyBase.Hide()
											Me.frm.Show()
										End If
									Else
										Interaction.MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
										Me.UserID.Clear()
										Me.Password.Clear()
										Me.Password.ForeColor = Color.Silver
										Me.UserID.ForeColor = Color.Silver
										Me.cmbCompany.Focus()
										Me.cmbCompany.SelectedIndex = -1
										frmLogin.counter -= 1
										Me.lblAttempt.Text = Me.str + Conversions.ToString(frmLogin.counter)
										Dim flag14 As Boolean = frmLogin.counter = 0
										If flag14 Then
											Me.OK.Enabled = False
										End If
									End If
									ModCommonClasses.cmd.Dispose()
									ModCommonClasses.con.Close()
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060123CD RID: 74701 RVA: 0x00A7D428 File Offset: 0x00A7B628
		Public Sub LoadRegistry()
			Dim text As String = "HKEY_CURRENT_USER\Software\" + MyProject.Application.Info.ProductName
			Dim text2 As String = "DefaultLanguage"
			Dim value As Object = Registry.GetValue(text, text2, Nothing)
			Dim text3 As String = If((value IsNot Nothing), value.ToString(), Nothing)
			Dim flag As Boolean = Not String.IsNullOrEmpty(text3)
			If flag Then
				Me.cmbLang.Text = text3
			End If
		End Sub

		' Token: 0x060123CE RID: 74702 RVA: 0x00A7D488 File Offset: 0x00A7B688
		Public Sub fillLanguage()
			Dim text As String = "SELECT distinct lang_hin as lang_code FROM Language_set order by 1"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						Me.cmbLang.Items.Clear()
						Try
							Try
								For Each obj As Object In dataTable.Rows
									Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
									Dim dataRow As DataRow = CType(objectValue, DataRow)
									Me.cmbLang.Items.Add(dataRow(0).ToString())
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Me.cmbLang.Items.Add("ENGLISH")
							Me.cmbLang.SelectedItem = "ENGLISH"
						Finally
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x060123CF RID: 74703 RVA: 0x0007D155 File Offset: 0x0007B355
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub Cancel_Click(sender As Object, e As EventArgs)
			ProjectData.EndApp()
		End Sub

		' Token: 0x060123D0 RID: 74704 RVA: 0x00A7D5F4 File Offset: 0x00A7B7F4
		Private Sub LoginForm1_Load(sender As Object, e As EventArgs)
			If AppleUITheme.IsCapturing Then Return
			Try
				Me.fillCompany()
				Me.cmbCompany.Focus()
				Me.lblAttempt.Text = Me.str + Conversions.ToString(frmLogin.counter)
				Dim registrydata As frmSplash.LicenseDataNew = MyProject.Forms.frmSplash.getRegistrydata()
				If registrydata IsNot Nothing Then
					Me.Label1.Text = registrydata.company
					If Not String.IsNullOrEmpty(registrydata.Logo) Then
						Me.Panel2.BackgroundImage = Me.Base64ToImage(registrydata.Logo)
					End If
				End If
				Me.fillLanguage()
				Me.LoadRegistry()
				AppleUITheme.PolishLoginForm(Me, Me.Panel1, Me.OK, Me.Cancel, Me.UserID, Me.Password, Me.Label1)
			Catch ex As Exception
				Try
					File.WriteAllText(Application.StartupPath + "\login_load_error.txt", ex.ToString())
				Catch
				End Try
			End Try
		End Sub

		Public Function Base64ToImage(base64string As String) As Image
			If String.IsNullOrEmpty(base64string) Then
				Return Nothing
			End If
			Try
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim text As String = base64string.Replace(" ", "+")
				Dim array As Byte() = Convert.FromBase64String(text)
				memoryStream = New MemoryStream(array)
				Return Image.FromStream(memoryStream)
			Catch
				Return Nothing
			End Try
		End Function

		' Token: 0x060123D2 RID: 74706 RVA: 0x0007D155 File Offset: 0x0007B355
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs)
			ProjectData.EndApp()
		End Sub

		' Token: 0x060123D3 RID: 74707 RVA: 0x00A7D680 File Offset: 0x00A7B880
		Private Sub btnChangePassword_Click(sender As Object, e As EventArgs)
			MyBase.Hide()
			MyProject.Forms.frmChangePassword.Show()
			MyProject.Forms.frmChangePassword.UserID.Text = ""
			MyProject.Forms.frmChangePassword.OldPassword.Text = ""
			MyProject.Forms.frmChangePassword.NewPassword.Text = ""
			MyProject.Forms.frmChangePassword.ConfirmPassword.Text = ""
			MyProject.Forms.frmChangePassword.UserID.Focus()
		End Sub

		' Token: 0x060123D4 RID: 74708 RVA: 0x00A7D724 File Offset: 0x00A7B924
		Private Sub btnChangePassword_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.btnChangePassword, "Change Password")
		End Sub

		' Token: 0x060123D5 RID: 74709 RVA: 0x00A7D774 File Offset: 0x00A7B974
		Private Sub btnRecoveryPassword_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.btnRecoveryPassword, "Password Recovery")
		End Sub

		' Token: 0x060123D6 RID: 74710 RVA: 0x00A7D7C4 File Offset: 0x00A7B9C4
		Private Sub btnKeyboard_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.btnKeyboard, "OnScreen Keyboard")
		End Sub

		' Token: 0x060123D7 RID: 74711 RVA: 0x00A7D814 File Offset: 0x00A7BA14
		Private Sub btnKeyboard_Click(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmLogin.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmLogin.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x060123D8 RID: 74712 RVA: 0x00A7D85C File Offset: 0x00A7BA5C
		Private Sub btnRecoveryPassword_Click(sender As Object, e As EventArgs)
			MyBase.Hide()
			MyProject.Forms.frmRecoveryPassword.Show()
			MyProject.Forms.frmRecoveryPassword.txtEmailID.Text = ""
			MyProject.Forms.frmRecoveryPassword.txtEmailID.Focus()
		End Sub

		' Token: 0x060123D9 RID: 74713 RVA: 0x00A7D8B0 File Offset: 0x00A7BAB0
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.Password.PasswordChar <> vbNullChar
			If flag Then
				Me.Password.PasswordChar = vbNullChar
				Me.Password.Focus()
				Me.Button5.Visible = False
				Me.Button4.Visible = True
			End If
		End Sub

		' Token: 0x060123DA RID: 74714 RVA: 0x0007D15E File Offset: 0x0007B35E
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.Password.PasswordChar = ChrW(&H25CF)
			Me.Password.Focus()
			Me.Button5.Visible = True
			Me.Button4.Visible = False
		End Sub

		' Token: 0x060123DB RID: 74715 RVA: 0x00A7D918 File Offset: 0x00A7BB18
		Private Sub Username_Enter(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.UserID.Text, "Enter the User Name", False) = 0
			If flag Then
				Me.UserID.Text = ""
				Me.UserID.ForeColor = AppleUITheme.TextPrimary
			End If
		End Sub

		' Token: 0x060123DC RID: 74716 RVA: 0x00A7D968 File Offset: 0x00A7BB68
		Private Sub Username_Leave(sender As Object, e As EventArgs)
			' Visible labels replace the old placeholder-as-value behavior.
			DirectCast(sender, TextBox).ForeColor = RetailUI.Tone("label")
		End Sub

		' Token: 0x060123DD RID: 74717 RVA: 0x00A7D9B8 File Offset: 0x00A7BBB8
		Private Sub Password_Enter(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Password.Text, "Enter the Password", False) = 0
			If flag Then
				Me.Password.Text = ""
				Me.Password.ForeColor = AppleUITheme.TextPrimary
			End If
		End Sub

		' Token: 0x060123DE RID: 74718 RVA: 0x00A7DA08 File Offset: 0x00A7BC08
		Private Sub Password_Leave(sender As Object, e As EventArgs)
			' Visible labels replace the old placeholder-as-value behavior.
			DirectCast(sender, TextBox).ForeColor = RetailUI.Tone("label")
		End Sub

		' Token: 0x060123DF RID: 74719 RVA: 0x00A7DA58 File Offset: 0x00A7BC58
		Private Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs)
			If AppleUITheme.IsCapturing Then Return
			Try
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(DBName), RTRIM(Online_DBName) from RaintechMaster where CompanyName=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCompany.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtDBName.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				End If
				flag = ModCommonClasses.rdr IsNot Nothing
				Dim flag3 As Boolean = flag
				If flag3 Then
					ModCommonClasses.rdr.Close()
				End If
				flag = ModCommonClasses.con.State = ConnectionState.Open
				Dim flag4 As Boolean = flag
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				File.WriteAllText(Application.StartupPath + "\TempDBSettings.dat", "")
				Dim streamWriter As StreamWriter = New StreamWriter(Application.StartupPath + "\TempDBSettings.dat")
				Try
					streamWriter.WriteLine(Me.txtDBName.Text)
					streamWriter.Close()
				Finally
					flag = streamWriter IsNot Nothing
					Dim flag5 As Boolean = flag
					If flag5 Then
						CType(streamWriter, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060123E0 RID: 74720 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Ok_MH(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060123E1 RID: 74721 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Ok_LV(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060123E2 RID: 74722 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub CL_MH(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060123E3 RID: 74723 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub CL_LV(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060123E4 RID: 74724 RVA: 0x00A7DBFC File Offset: 0x00A7BDFC
		Private Sub Create_Company(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.btnCompany, "Create Company")
		End Sub

		' Token: 0x060123E5 RID: 74725 RVA: 0x00A7DC4C File Offset: 0x00A7BE4C
		Private Sub btnCompany_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmCompany.ShowDialog()
				MyProject.Forms.frmCompany.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		' Token: 0x060123E6 RID: 74726 RVA: 0x00A7DCAC File Offset: 0x00A7BEAC
		Public Sub DTM()
			Dim flag As Boolean = DateTime.Now.Hour < 12
			If flag Then
				Me.LabelMsg.Text = "Good Morning, Welcome Back!"
			Else
				Dim flag2 As Boolean = DateTime.Now.Hour = 12
				If flag2 Then
					Me.LabelMsg.Text = "Good Afternoon, Welcome Back!"
				Else
					Dim flag3 As Boolean = DateTime.Now.Hour < 16
					If flag3 Then
						Me.LabelMsg.Text = "Good Afternoon, Welcome Back!"
					Else
						Dim flag4 As Boolean = DateTime.Now.Hour < 21
						If flag4 Then
							Me.LabelMsg.Text = "Good Evening, Welcome Back!"
						Else
							Me.LabelMsg.Text = "Good Night, Welcome Back!"
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060123E7 RID: 74727 RVA: 0x0007D198 File Offset: 0x0007B398
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.DTM()
		End Sub

		' Token: 0x060123E8 RID: 74728 RVA: 0x00A7DD78 File Offset: 0x00A7BF78
		Private Sub btnHelp_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmCustomerSupportLog_Report.ShowDialog()
				MyProject.Forms.frmCustomerSupportLog_Report.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		' Token: 0x04006D9C RID: 28060
		Private frm As frmMainMenu

		' Token: 0x04006D9D RID: 28061
		Public Shared InstanceID As String = ""

		' Token: 0x04006D9E RID: 28062
		Public Shared counter As Integer = 3

		' Token: 0x04006D9F RID: 28063
		Private str As String
	End Class
End Namespace
