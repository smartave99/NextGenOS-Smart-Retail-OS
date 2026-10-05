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
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004E5 RID: 1253
	<DesignerGenerated()>
	Public Partial Class frmTCSValidation
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FFD5 RID: 65493 RVA: 0x000702F9 File Offset: 0x0006E4F9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTCSValidation_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTCSValidation_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170061C4 RID: 25028
		' (get) Token: 0x0600FFD8 RID: 65496 RVA: 0x0007032B File Offset: 0x0006E52B
		' (set) Token: 0x0600FFD9 RID: 65497 RVA: 0x00070335 File Offset: 0x0006E535
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170061C5 RID: 25029
		' (get) Token: 0x0600FFDA RID: 65498 RVA: 0x0007033E File Offset: 0x0006E53E
		' (set) Token: 0x0600FFDB RID: 65499 RVA: 0x00070348 File Offset: 0x0006E548
		Friend Overridable Property lblUser As Label

		' Token: 0x170061C6 RID: 25030
		' (get) Token: 0x0600FFDC RID: 65500 RVA: 0x00070351 File Offset: 0x0006E551
		' (set) Token: 0x0600FFDD RID: 65501 RVA: 0x0007035B File Offset: 0x0006E55B
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170061C7 RID: 25031
		' (get) Token: 0x0600FFDE RID: 65502 RVA: 0x00070364 File Offset: 0x0006E564
		' (set) Token: 0x0600FFDF RID: 65503 RVA: 0x0098CA34 File Offset: 0x0098AC34
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

		' Token: 0x170061C8 RID: 25032
		' (get) Token: 0x0600FFE0 RID: 65504 RVA: 0x0007036E File Offset: 0x0006E56E
		' (set) Token: 0x0600FFE1 RID: 65505 RVA: 0x0098CA78 File Offset: 0x0098AC78
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

		' Token: 0x170061C9 RID: 25033
		' (get) Token: 0x0600FFE2 RID: 65506 RVA: 0x00070378 File Offset: 0x0006E578
		' (set) Token: 0x0600FFE3 RID: 65507 RVA: 0x0098CABC File Offset: 0x0098ACBC
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

		' Token: 0x170061CA RID: 25034
		' (get) Token: 0x0600FFE4 RID: 65508 RVA: 0x00070382 File Offset: 0x0006E582
		' (set) Token: 0x0600FFE5 RID: 65509 RVA: 0x0098CB00 File Offset: 0x0098AD00
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

		' Token: 0x170061CB RID: 25035
		' (get) Token: 0x0600FFE6 RID: 65510 RVA: 0x0007038C File Offset: 0x0006E58C
		' (set) Token: 0x0600FFE7 RID: 65511 RVA: 0x00070396 File Offset: 0x0006E596
		Friend Overridable Property Label1 As Label

		' Token: 0x170061CC RID: 25036
		' (get) Token: 0x0600FFE8 RID: 65512 RVA: 0x0007039F File Offset: 0x0006E59F
		' (set) Token: 0x0600FFE9 RID: 65513 RVA: 0x000703A9 File Offset: 0x0006E5A9
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170061CD RID: 25037
		' (get) Token: 0x0600FFEA RID: 65514 RVA: 0x000703B2 File Offset: 0x0006E5B2
		' (set) Token: 0x0600FFEB RID: 65515 RVA: 0x0098CB44 File Offset: 0x0098AD44
		Private _txtlimit As TextBox
		Friend Overridable Property txtlimit As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtlimit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtlimit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtlimit
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtlimit = value
				textBox = Me._txtlimit
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061CE RID: 25038
		' (get) Token: 0x0600FFEC RID: 65516 RVA: 0x000703BC File Offset: 0x0006E5BC
		' (set) Token: 0x0600FFED RID: 65517 RVA: 0x000703C6 File Offset: 0x0006E5C6
		Friend Overridable Property Label3 As Label

		' Token: 0x170061CF RID: 25039
		' (get) Token: 0x0600FFEE RID: 65518 RVA: 0x000703CF File Offset: 0x0006E5CF
		' (set) Token: 0x0600FFEF RID: 65519 RVA: 0x0098CBA4 File Offset: 0x0098ADA4
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

		' Token: 0x170061D0 RID: 25040
		' (get) Token: 0x0600FFF0 RID: 65520 RVA: 0x000703D9 File Offset: 0x0006E5D9
		' (set) Token: 0x0600FFF1 RID: 65521 RVA: 0x000703E3 File Offset: 0x0006E5E3
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x170061D1 RID: 25041
		' (get) Token: 0x0600FFF2 RID: 65522 RVA: 0x000703EC File Offset: 0x0006E5EC
		' (set) Token: 0x0600FFF3 RID: 65523 RVA: 0x000703F6 File Offset: 0x0006E5F6
		Friend Overridable Property Label2 As Label

		' Token: 0x170061D2 RID: 25042
		' (get) Token: 0x0600FFF4 RID: 65524 RVA: 0x000703FF File Offset: 0x0006E5FF
		' (set) Token: 0x0600FFF5 RID: 65525 RVA: 0x0098CC04 File Offset: 0x0098AE04
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061D3 RID: 25043
		' (get) Token: 0x0600FFF6 RID: 65526 RVA: 0x00070409 File Offset: 0x0006E609
		' (set) Token: 0x0600FFF7 RID: 65527 RVA: 0x00070413 File Offset: 0x0006E613
		Friend Overridable Property Label6 As Label

		' Token: 0x170061D4 RID: 25044
		' (get) Token: 0x0600FFF8 RID: 65528 RVA: 0x0007041C File Offset: 0x0006E61C
		' (set) Token: 0x0600FFF9 RID: 65529 RVA: 0x00070426 File Offset: 0x0006E626
		Friend Overridable Property Label11 As Label

		' Token: 0x170061D5 RID: 25045
		' (get) Token: 0x0600FFFA RID: 65530 RVA: 0x0007042F File Offset: 0x0006E62F
		' (set) Token: 0x0600FFFB RID: 65531 RVA: 0x00070439 File Offset: 0x0006E639
		Friend Overridable Property Label10 As Label

		' Token: 0x170061D6 RID: 25046
		' (get) Token: 0x0600FFFC RID: 65532 RVA: 0x00070442 File Offset: 0x0006E642
		' (set) Token: 0x0600FFFD RID: 65533 RVA: 0x0007044C File Offset: 0x0006E64C
		Friend Overridable Property Label9 As Label

		' Token: 0x170061D7 RID: 25047
		' (get) Token: 0x0600FFFE RID: 65534 RVA: 0x00070455 File Offset: 0x0006E655
		' (set) Token: 0x0600FFFF RID: 65535 RVA: 0x0098CC48 File Offset: 0x0098AE48
		Private _txtwithoutpan As TextBox
		Friend Overridable Property txtwithoutpan As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtwithoutpan
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtwithoutpan_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtwithoutpan
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtwithoutpan = value
				textBox = Me._txtwithoutpan
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061D8 RID: 25048
		' (get) Token: 0x06010000 RID: 65536 RVA: 0x0007045F File Offset: 0x0006E65F
		' (set) Token: 0x06010001 RID: 65537 RVA: 0x0098CCA8 File Offset: 0x0098AEA8
		Private _txtwithpan As TextBox
		Friend Overridable Property txtwithpan As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtwithpan
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtwithpan_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtwithpan
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtwithpan = value
				textBox = Me._txtwithpan
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061D9 RID: 25049
		' (get) Token: 0x06010002 RID: 65538 RVA: 0x00070469 File Offset: 0x0006E669
		' (set) Token: 0x06010003 RID: 65539 RVA: 0x00070473 File Offset: 0x0006E673
		Friend Overridable Property Label8 As Label

		' Token: 0x170061DA RID: 25050
		' (get) Token: 0x06010004 RID: 65540 RVA: 0x0007047C File Offset: 0x0006E67C
		' (set) Token: 0x06010005 RID: 65541 RVA: 0x00070486 File Offset: 0x0006E686
		Friend Overridable Property Label7 As Label

		' Token: 0x170061DB RID: 25051
		' (get) Token: 0x06010006 RID: 65542 RVA: 0x0007048F File Offset: 0x0006E68F
		' (set) Token: 0x06010007 RID: 65543 RVA: 0x0098CD08 File Offset: 0x0098AF08
		Private _dtpDateTo As DateTimePicker
		Friend Overridable Property dtpDateTo As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDateTo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDateTo_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDateTo
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDateTo = value
				dateTimePicker = Me._dtpDateTo
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061DC RID: 25052
		' (get) Token: 0x06010008 RID: 65544 RVA: 0x00070499 File Offset: 0x0006E699
		' (set) Token: 0x06010009 RID: 65545 RVA: 0x0098CD4C File Offset: 0x0098AF4C
		Private _dtpDateFrom As DateTimePicker
		Friend Overridable Property dtpDateFrom As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDateFrom
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDateFrom_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDateFrom
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDateFrom = value
				dateTimePicker = Me._dtpDateFrom
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061DD RID: 25053
		' (get) Token: 0x0601000A RID: 65546 RVA: 0x000704A3 File Offset: 0x0006E6A3
		' (set) Token: 0x0601000B RID: 65547 RVA: 0x000704AD File Offset: 0x0006E6AD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170061DE RID: 25054
		' (get) Token: 0x0601000C RID: 65548 RVA: 0x000704B6 File Offset: 0x0006E6B6
		' (set) Token: 0x0601000D RID: 65549 RVA: 0x000704C0 File Offset: 0x0006E6C0
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170061DF RID: 25055
		' (get) Token: 0x0601000E RID: 65550 RVA: 0x000704C9 File Offset: 0x0006E6C9
		' (set) Token: 0x0601000F RID: 65551 RVA: 0x000704D3 File Offset: 0x0006E6D3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170061E0 RID: 25056
		' (get) Token: 0x06010010 RID: 65552 RVA: 0x000704DC File Offset: 0x0006E6DC
		' (set) Token: 0x06010011 RID: 65553 RVA: 0x000704E6 File Offset: 0x0006E6E6
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170061E1 RID: 25057
		' (get) Token: 0x06010012 RID: 65554 RVA: 0x000704EF File Offset: 0x0006E6EF
		' (set) Token: 0x06010013 RID: 65555 RVA: 0x000704F9 File Offset: 0x0006E6F9
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170061E2 RID: 25058
		' (get) Token: 0x06010014 RID: 65556 RVA: 0x00070502 File Offset: 0x0006E702
		' (set) Token: 0x06010015 RID: 65557 RVA: 0x0007050C File Offset: 0x0006E70C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170061E3 RID: 25059
		' (get) Token: 0x06010016 RID: 65558 RVA: 0x00070515 File Offset: 0x0006E715
		' (set) Token: 0x06010017 RID: 65559 RVA: 0x0007051F File Offset: 0x0006E71F
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170061E4 RID: 25060
		' (get) Token: 0x06010018 RID: 65560 RVA: 0x00070528 File Offset: 0x0006E728
		' (set) Token: 0x06010019 RID: 65561 RVA: 0x00070532 File Offset: 0x0006E732
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x0601001A RID: 65562 RVA: 0x0098CD90 File Offset: 0x0098AF90
		Public Sub Clear()
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtlimit.Text = "0.00"
			Me.txtwithpan.Text = "0.000"
			Me.txtwithoutpan.Text = "0.000"
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0601001B RID: 65563 RVA: 0x0098CE30 File Offset: 0x0098B030
		Private Sub Button4_Click(sender As Object, e As EventArgs)
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
					Dim flag3 As Boolean = Operators.CompareString(Me.txtlimit.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please fill the limit amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtlimit.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.txtwithpan.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please fill the Tax% with PAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtwithpan.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtwithoutpan.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please fill the Tax% without PAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.txtwithoutpan.Focus()
							Else
								Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = -1
								If flag6 Then
									MessageBox.Show("Please fill the Activate Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.ComboBox1.Focus()
								Else
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "Select count(*) from TCSValid Having count(*) >= 1"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
										If flag7 Then
											MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the information only", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag8 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text3 As String = "insert into TCSValid(datefrom,dateto,limit,wpan,wopan,status) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
											ModCommonClasses.cmd = New SqlCommand(text3)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtlimit.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtwithpan.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtwithoutpan.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox1.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteReader()
											ModCommonClasses.con.Close()
											ModFunc.LogFunc(Me.lblUser.Text, "Added the TCS Validation Status : '" + Me.ComboBox1.Text + "'")
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
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0601001C RID: 65564 RVA: 0x0098D290 File Offset: 0x0098B490
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT Id, RTRIM(datefrom),RTRIM(dateto),RTRIM(limit),RTRIM(wpan),RTRIM(wopan),RTRIM(status) from TCSValid", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601001D RID: 65565 RVA: 0x0098D3C4 File Offset: 0x0098B5C4
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
				Me.dtpDateFrom.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.dtpDateTo.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.txtlimit.Text = dataGridViewRow.Cells(3).Value.ToString()
				Me.txtwithpan.Text = dataGridViewRow.Cells(4).Value.ToString()
				Me.txtwithoutpan.Text = dataGridViewRow.Cells(5).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(6).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601001E RID: 65566 RVA: 0x0098D544 File Offset: 0x0098B744
		Private Sub Button3_Click(sender As Object, e As EventArgs)
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
					Dim flag4 As Boolean = Operators.CompareString(Me.txtlimit.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please fill the limit amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtlimit.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtwithpan.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please fill the Tax% with PAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtwithpan.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtwithoutpan.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please fill the Tax% without PAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.txtwithoutpan.Focus()
							Else
								Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = -1
								If flag7 Then
									MessageBox.Show("Please fill the Activate Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.ComboBox1.Focus()
								Else
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = If(("Update TCSValid set datefrom=@d1,dateto=@d2,limit=@d3,wpan=@d4,wopan=@d5,status=@d6 where ID=" + Me.TextBox2.Text), "")
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtlimit.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtwithpan.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtwithoutpan.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox1.Text)
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModFunc.LogFunc(Me.lblUser.Text, "Updated the TCS Validation Status : '" + Me.ComboBox1.Text + "'")
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
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0601001F RID: 65567 RVA: 0x0098D934 File Offset: 0x0098BB34
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM TCSValid WHERE id = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						ModFunc.LogFunc(Me.lblUser.Text, "Deleted the TCS Validation Status : '" + Me.ComboBox1.Text + "'")
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

		' Token: 0x06010020 RID: 65568 RVA: 0x0007053B File Offset: 0x0006E73B
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.dtpDateFrom.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06010021 RID: 65569 RVA: 0x0098DA64 File Offset: 0x0098BC64
		Private Sub frmTCSValidation_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010022 RID: 65570 RVA: 0x0098DAEC File Offset: 0x0098BCEC
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

		' Token: 0x06010023 RID: 65571 RVA: 0x0098DC64 File Offset: 0x0098BE64
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

		' Token: 0x06010024 RID: 65572 RVA: 0x0098DD20 File Offset: 0x0098BF20
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

		' Token: 0x06010025 RID: 65573 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010026 RID: 65574 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010027 RID: 65575 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010028 RID: 65576 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010029 RID: 65577 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601002A RID: 65578 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtlimit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601002B RID: 65579 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtwithpan_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601002C RID: 65580 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtwithoutpan_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601002D RID: 65581 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601002E RID: 65582 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTCSValidation_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601002F RID: 65583 RVA: 0x0098DDEC File Offset: 0x0098BFEC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtwithpan.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtwithpan, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtwithpan, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtwithoutpan.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtwithoutpan, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtwithoutpan, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtlimit.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtlimit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtlimit, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub
	End Class
End Namespace
