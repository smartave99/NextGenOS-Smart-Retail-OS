Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports CButtonLib
Imports DevNet
Imports DevNet.Models
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000216 RID: 534
	<DesignerGenerated()>
	Public Partial Class frmWAppAPIServer2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060099E6 RID: 39398 RVA: 0x006E505C File Offset: 0x006E325C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAutobackup_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmWAppAPIServer_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmWAppAPIServer_Closed
			Me.sts2 = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700392A RID: 14634
		' (get) Token: 0x060099E9 RID: 39401 RVA: 0x0004B2B6 File Offset: 0x000494B6
		' (set) Token: 0x060099EA RID: 39402 RVA: 0x006E6D10 File Offset: 0x006E4F10
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

		' Token: 0x1700392B RID: 14635
		' (get) Token: 0x060099EB RID: 39403 RVA: 0x0004B2C0 File Offset: 0x000494C0
		' (set) Token: 0x060099EC RID: 39404 RVA: 0x0004B2CA File Offset: 0x000494CA
		Friend Overridable Property Label1 As Label

		' Token: 0x1700392C RID: 14636
		' (get) Token: 0x060099ED RID: 39405 RVA: 0x0004B2D3 File Offset: 0x000494D3
		' (set) Token: 0x060099EE RID: 39406 RVA: 0x0004B2DD File Offset: 0x000494DD
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700392D RID: 14637
		' (get) Token: 0x060099EF RID: 39407 RVA: 0x0004B2E6 File Offset: 0x000494E6
		' (set) Token: 0x060099F0 RID: 39408 RVA: 0x0004B2F0 File Offset: 0x000494F0
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700392E RID: 14638
		' (get) Token: 0x060099F1 RID: 39409 RVA: 0x0004B2F9 File Offset: 0x000494F9
		' (set) Token: 0x060099F2 RID: 39410 RVA: 0x0004B303 File Offset: 0x00049503
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700392F RID: 14639
		' (get) Token: 0x060099F3 RID: 39411 RVA: 0x0004B30C File Offset: 0x0004950C
		' (set) Token: 0x060099F4 RID: 39412 RVA: 0x0004B316 File Offset: 0x00049516
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003930 RID: 14640
		' (get) Token: 0x060099F5 RID: 39413 RVA: 0x0004B31F File Offset: 0x0004951F
		' (set) Token: 0x060099F6 RID: 39414 RVA: 0x006E6D54 File Offset: 0x006E4F54
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

		' Token: 0x17003931 RID: 14641
		' (get) Token: 0x060099F7 RID: 39415 RVA: 0x0004B329 File Offset: 0x00049529
		' (set) Token: 0x060099F8 RID: 39416 RVA: 0x006E6DB4 File Offset: 0x006E4FB4
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

		' Token: 0x17003932 RID: 14642
		' (get) Token: 0x060099F9 RID: 39417 RVA: 0x0004B333 File Offset: 0x00049533
		' (set) Token: 0x060099FA RID: 39418 RVA: 0x006E6DF8 File Offset: 0x006E4FF8
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003933 RID: 14643
		' (get) Token: 0x060099FB RID: 39419 RVA: 0x0004B33D File Offset: 0x0004953D
		' (set) Token: 0x060099FC RID: 39420 RVA: 0x006E6E74 File Offset: 0x006E5074
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003934 RID: 14644
		' (get) Token: 0x060099FD RID: 39421 RVA: 0x0004B347 File Offset: 0x00049547
		' (set) Token: 0x060099FE RID: 39422 RVA: 0x0004B351 File Offset: 0x00049551
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17003935 RID: 14645
		' (get) Token: 0x060099FF RID: 39423 RVA: 0x0004B35A File Offset: 0x0004955A
		' (set) Token: 0x06009A00 RID: 39424 RVA: 0x0004B364 File Offset: 0x00049564
		Friend Overridable Property Label2 As Label

		' Token: 0x17003936 RID: 14646
		' (get) Token: 0x06009A01 RID: 39425 RVA: 0x0004B36D File Offset: 0x0004956D
		' (set) Token: 0x06009A02 RID: 39426 RVA: 0x0004B377 File Offset: 0x00049577
		Friend Overridable Property Label3 As Label

		' Token: 0x17003937 RID: 14647
		' (get) Token: 0x06009A03 RID: 39427 RVA: 0x0004B380 File Offset: 0x00049580
		' (set) Token: 0x06009A04 RID: 39428 RVA: 0x0004B38A File Offset: 0x0004958A
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17003938 RID: 14648
		' (get) Token: 0x06009A05 RID: 39429 RVA: 0x0004B393 File Offset: 0x00049593
		' (set) Token: 0x06009A06 RID: 39430 RVA: 0x0004B39D File Offset: 0x0004959D
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17003939 RID: 14649
		' (get) Token: 0x06009A07 RID: 39431 RVA: 0x0004B3A6 File Offset: 0x000495A6
		' (set) Token: 0x06009A08 RID: 39432 RVA: 0x0004B3B0 File Offset: 0x000495B0
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700393A RID: 14650
		' (get) Token: 0x06009A09 RID: 39433 RVA: 0x0004B3B9 File Offset: 0x000495B9
		' (set) Token: 0x06009A0A RID: 39434 RVA: 0x0004B3C3 File Offset: 0x000495C3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700393B RID: 14651
		' (get) Token: 0x06009A0B RID: 39435 RVA: 0x0004B3CC File Offset: 0x000495CC
		' (set) Token: 0x06009A0C RID: 39436 RVA: 0x0004B3D6 File Offset: 0x000495D6
		Friend Overridable Property Panel8 As Panel

		' Token: 0x1700393C RID: 14652
		' (get) Token: 0x06009A0D RID: 39437 RVA: 0x0004B3DF File Offset: 0x000495DF
		' (set) Token: 0x06009A0E RID: 39438 RVA: 0x0004B3E9 File Offset: 0x000495E9
		Friend Overridable Property LblSenderId As Label

		' Token: 0x1700393D RID: 14653
		' (get) Token: 0x06009A0F RID: 39439 RVA: 0x0004B3F2 File Offset: 0x000495F2
		' (set) Token: 0x06009A10 RID: 39440 RVA: 0x0004B3FC File Offset: 0x000495FC
		Friend Overridable Property lblWhatsAppState As Label

		' Token: 0x1700393E RID: 14654
		' (get) Token: 0x06009A11 RID: 39441 RVA: 0x0004B405 File Offset: 0x00049605
		' (set) Token: 0x06009A12 RID: 39442 RVA: 0x0004B40F File Offset: 0x0004960F
		Friend Overridable Property chkBoxHeadLess As CheckBox

		' Token: 0x1700393F RID: 14655
		' (get) Token: 0x06009A13 RID: 39443 RVA: 0x0004B418 File Offset: 0x00049618
		' (set) Token: 0x06009A14 RID: 39444 RVA: 0x006E6ED4 File Offset: 0x006E50D4
		Private _btnTerminate As Button
		Friend Overridable Property btnTerminate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTerminate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTerminate_Click
				Dim button As Button = Me._btnTerminate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTerminate = value
				button = Me._btnTerminate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003940 RID: 14656
		' (get) Token: 0x06009A15 RID: 39445 RVA: 0x0004B422 File Offset: 0x00049622
		' (set) Token: 0x06009A16 RID: 39446 RVA: 0x006E6F18 File Offset: 0x006E5118
		Private _btnInitialize As Button
		Friend Overridable Property btnInitialize As Button
			<CompilerGenerated()>
			Get
				Return Me._btnInitialize
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnInitialize_Click
				Dim button As Button = Me._btnInitialize
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnInitialize = value
				button = Me._btnInitialize
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003941 RID: 14657
		' (get) Token: 0x06009A17 RID: 39447 RVA: 0x0004B42C File Offset: 0x0004962C
		' (set) Token: 0x06009A18 RID: 39448 RVA: 0x006E6F5C File Offset: 0x006E515C
		Private _btnLogout As Button
		Friend Overridable Property btnLogout As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLogout
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLogout_Click
				Dim button As Button = Me._btnLogout
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLogout = value
				button = Me._btnLogout
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003942 RID: 14658
		' (get) Token: 0x06009A19 RID: 39449 RVA: 0x0004B436 File Offset: 0x00049636
		' (set) Token: 0x06009A1A RID: 39450 RVA: 0x0004B440 File Offset: 0x00049640
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17003943 RID: 14659
		' (get) Token: 0x06009A1B RID: 39451 RVA: 0x0004B449 File Offset: 0x00049649
		' (set) Token: 0x06009A1C RID: 39452 RVA: 0x0004B453 File Offset: 0x00049653
		Friend Overridable Property pBoxAuthQR As PictureBox

		' Token: 0x17003944 RID: 14660
		' (get) Token: 0x06009A1D RID: 39453 RVA: 0x0004B45C File Offset: 0x0004965C
		' (set) Token: 0x06009A1E RID: 39454 RVA: 0x0004B466 File Offset: 0x00049666
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003945 RID: 14661
		' (get) Token: 0x06009A1F RID: 39455 RVA: 0x0004B46F File Offset: 0x0004966F
		' (set) Token: 0x06009A20 RID: 39456 RVA: 0x006E6FA0 File Offset: 0x006E51A0
		Private _Button2 As CButton
		Friend Overridable Property Button2 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button2_ClickButtonArea
				Dim cbutton As CButton = Me._Button2
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button2 = value
				cbutton = Me._Button2
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003946 RID: 14662
		' (get) Token: 0x06009A21 RID: 39457 RVA: 0x0004B479 File Offset: 0x00049679
		' (set) Token: 0x06009A22 RID: 39458 RVA: 0x006E6FE4 File Offset: 0x006E51E4
		Private _Button3 As CButton
		Friend Overridable Property Button3 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button3_ClickButtonArea
				Dim cbutton As CButton = Me._Button3
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button3 = value
				cbutton = Me._Button3
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003947 RID: 14663
		' (get) Token: 0x06009A23 RID: 39459 RVA: 0x0004B483 File Offset: 0x00049683
		' (set) Token: 0x06009A24 RID: 39460 RVA: 0x006E7028 File Offset: 0x006E5228
		Private _Button4 As CButton
		Friend Overridable Property Button4 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button4_ClickButtonArea
				Dim cbutton As CButton = Me._Button4
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button4 = value
				cbutton = Me._Button4
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003948 RID: 14664
		' (get) Token: 0x06009A25 RID: 39461 RVA: 0x0004B48D File Offset: 0x0004968D
		' (set) Token: 0x06009A26 RID: 39462 RVA: 0x006E706C File Offset: 0x006E526C
		Private _Button5 As CButton
		Friend Overridable Property Button5 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button5_ClickButtonArea
				Dim cbutton As CButton = Me._Button5
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button5 = value
				cbutton = Me._Button5
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003949 RID: 14665
		' (get) Token: 0x06009A27 RID: 39463 RVA: 0x0004B497 File Offset: 0x00049697
		' (set) Token: 0x06009A28 RID: 39464 RVA: 0x0004B4A1 File Offset: 0x000496A1
		Friend Overridable Property Panel4 As Panel

		' Token: 0x06009A29 RID: 39465 RVA: 0x006E70B0 File Offset: 0x006E52B0
		Private Sub Button4_ClickButtonArea(Sender As Object, e As MouseEventArgs)
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
						MessageBox.Show("Please fill WhatsApp API Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Select count(*) from WappApi Having count(*) >= 1"
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
								Dim text3 As String = "insert into WappApi(c1,c2) VALUES (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
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

		' Token: 0x06009A2A RID: 39466 RVA: 0x006E7384 File Offset: 0x006E5584
		Private Sub Clear()
			Me.TextBox1.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.TextBox1.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06009A2B RID: 39467 RVA: 0x006E73EC File Offset: 0x006E55EC
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2) from WappApi ORDER BY ID", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009A2C RID: 39468 RVA: 0x006E74E4 File Offset: 0x006E56E4
		Private Sub frmAutobackup_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.LinkLabel1.TabStop = False
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4169e1")
			Me.dgw.RowHeadersDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.LoadProfile()
		End Sub

		' Token: 0x06009A2D RID: 39469 RVA: 0x006E75B0 File Offset: 0x006E57B0
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
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(2).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009A2E RID: 39470 RVA: 0x006E769C File Offset: 0x006E589C
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

		' Token: 0x06009A2F RID: 39471 RVA: 0x006E7784 File Offset: 0x006E5984
		Private Sub Button3_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Add Company Information first in master entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					flag = ModCommonClasses.rdr IsNot Nothing
					Dim flag3 As Boolean = flag
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Me.Clear()
				Else
					Dim flag4 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
					If flag4 Then
						MessageBox.Show("Please fill WhatsApp API Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Update WappApi set c1=@d1, c2=@d2 where ID=" + Me.TextBox2.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
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

		' Token: 0x06009A30 RID: 39472 RVA: 0x006E79E8 File Offset: 0x006E5BE8
		Private Sub Button2_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM WappApi WHERE ID = " + Me.TextBox2.Text
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

		' Token: 0x06009A31 RID: 39473 RVA: 0x0004B4AA File Offset: 0x000496AA
		Private Sub Button5_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.Clear()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06009A32 RID: 39474 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06009A33 RID: 39475 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009A34 RID: 39476 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009A35 RID: 39477 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmWAppAPIServer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009A36 RID: 39478 RVA: 0x0004B4DB File Offset: 0x000496DB
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Process.Start("https://chromedriver.chromium.org/downloads")
		End Sub

		' Token: 0x06009A37 RID: 39479 RVA: 0x006E7AEC File Offset: 0x006E5CEC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub

		' Token: 0x06009A38 RID: 39480 RVA: 0x0004B4E9 File Offset: 0x000496E9
		Private Sub btnInitialize_Click(sender As Object, e As EventArgs)
			Me.Initialization()
		End Sub

		' Token: 0x06009A39 RID: 39481 RVA: 0x006E7B94 File Offset: 0x006E5D94
		Public Sub Initialization()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					frmWAppAPIServer2.whatsApp = New WhatsApp()
					frmWAppAPIServer2.whatsApp.Initialize(New Config() With { .HideCommandPromptWindow = True, .Headless = Me.chkBoxHeadLess.Checked })
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("Internet Connection Failed", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06009A3A RID: 39482 RVA: 0x0004B4F3 File Offset: 0x000496F3
		Public Sub LoadProfile()
			frmWAppAPIServer2.whatsApp = New WhatsApp()
		End Sub

		' Token: 0x06009A3B RID: 39483 RVA: 0x006E7C30 File Offset: 0x006E5E30
		Private Async Sub btnTerminate_Click(sender As Object, e As EventArgs)
			Await frmWAppAPIServer2.whatsApp.Destroy()
		End Sub

		' Token: 0x06009A3C RID: 39484 RVA: 0x006E7C78 File Offset: 0x006E5E78
		Private Async Sub Timer1_Tick(sender As Object, e As EventArgs)
			Dim flag As Boolean = frmWAppAPIServer2.whatsApp Is Nothing
			If flag Then
				Await Task.Delay(500)
			Else
				Me.pBoxAuthQR.Image = frmWAppAPIServer2.whatsApp.AuthQR
				Me.LblSenderId.Text = String.Format("Sender Id: {0}", If(frmWAppAPIServer2.whatsApp.SenderID, "Unavailable"))
				If frmWAppAPIServer2.whatsApp.CurrentState = State.READY Then
					Me.btnLogout.Enabled = True
				Else
					Me.btnLogout.Enabled = False
				End If
				If frmWAppAPIServer2.whatsApp.CurrentState = State.STOPPED Then
					Me.btnInitialize.Enabled = True
					Me.btnTerminate.Enabled = False
					Me.chkBoxHeadLess.Enabled = True
				Else
					Me.btnInitialize.Enabled = False
					Me.btnTerminate.Enabled = True
					Me.chkBoxHeadLess.Enabled = False
				End If
				If frmWAppAPIServer2.whatsApp.CurrentState = State.AUTH_REQUIRED Then
					Me.Panel7.Enabled = True
					If Me._AUTH_QR IsNot frmWAppAPIServer2.whatsApp.AuthQR Then
						Me._AUTH_QR = frmWAppAPIServer2.whatsApp.AuthQR
					End If
				Else
					Me.Panel7.Enabled = False
				End If
				If Me._ENGINE_STATE <> frmWAppAPIServer2.whatsApp.CurrentState Then
					Me.lblWhatsAppState.Text = String.Format("Engine : {0}", frmWAppAPIServer2.whatsApp.CurrentState.GetString())
					Me._ENGINE_STATE = frmWAppAPIServer2.whatsApp.CurrentState
				End If
			End If
		End Sub

		' Token: 0x06009A3D RID: 39485 RVA: 0x006E7CC0 File Offset: 0x006E5EC0
		Private Async Sub btnLogout_Click(sender As Object, e As EventArgs)
			Await frmWAppAPIServer2.whatsApp.Logout()
		End Sub

		' Token: 0x06009A3E RID: 39486 RVA: 0x006E7D08 File Offset: 0x006E5F08
		Private Async Sub frmWAppAPIServer_Closed(sender As Object, e As EventArgs)
			Me.wappnodisplay()
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) = 0
			If flag Then
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Try
						Dim flag3 As Boolean = Operators.CompareString(Me.lblWhatsAppState.Text, "Engine : Ready", False) = 0
						If flag3 Then
							Await frmWAppAPIServer2.whatsApp.Destroy()
						End If
					Catch ex As Exception
					End Try
				End If
			End If
			MessageBox.Show("Application is going to be closed," & vbCrLf & "Please restart your application", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			ProjectData.EndApp()
		End Sub

		' Token: 0x06009A3F RID: 39487 RVA: 0x006E7D50 File Offset: 0x006E5F50
		Public Sub wappnodisplay()
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
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04004445 RID: 17477
		Public Shared whatsApp As WhatsApp

		' Token: 0x04004446 RID: 17478
		Private _ENGINE_STATE As State

		' Token: 0x04004447 RID: 17479
		Private _AUTH_QR As Image

		' Token: 0x04004448 RID: 17480
		Private sts2 As String
	End Class
End Namespace
