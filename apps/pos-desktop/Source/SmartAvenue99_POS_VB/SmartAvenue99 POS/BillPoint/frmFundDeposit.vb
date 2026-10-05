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
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000310 RID: 784
	<DesignerGenerated()>
	Public Partial Class frmFundDeposit
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BA32 RID: 47666 RVA: 0x00053497 File Offset: 0x00051697
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFundDeposit_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmFundDeposit_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004A39 RID: 19001
		' (get) Token: 0x0600BA35 RID: 47669 RVA: 0x000534C9 File Offset: 0x000516C9
		' (set) Token: 0x0600BA36 RID: 47670 RVA: 0x000534D3 File Offset: 0x000516D3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004A3A RID: 19002
		' (get) Token: 0x0600BA37 RID: 47671 RVA: 0x000534DC File Offset: 0x000516DC
		' (set) Token: 0x0600BA38 RID: 47672 RVA: 0x000534E6 File Offset: 0x000516E6
		Friend Overridable Property Label3 As Label

		' Token: 0x17004A3B RID: 19003
		' (get) Token: 0x0600BA39 RID: 47673 RVA: 0x000534EF File Offset: 0x000516EF
		' (set) Token: 0x0600BA3A RID: 47674 RVA: 0x000534F9 File Offset: 0x000516F9
		Friend Overridable Property txtBranchName As TextBox

		' Token: 0x17004A3C RID: 19004
		' (get) Token: 0x0600BA3B RID: 47675 RVA: 0x00053502 File Offset: 0x00051702
		' (set) Token: 0x0600BA3C RID: 47676 RVA: 0x0005350C File Offset: 0x0005170C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004A3D RID: 19005
		' (get) Token: 0x0600BA3D RID: 47677 RVA: 0x00053515 File Offset: 0x00051715
		' (set) Token: 0x0600BA3E RID: 47678 RVA: 0x0005351F File Offset: 0x0005171F
		Friend Overridable Property Label1 As Label

		' Token: 0x17004A3E RID: 19006
		' (get) Token: 0x0600BA3F RID: 47679 RVA: 0x00053528 File Offset: 0x00051728
		' (set) Token: 0x0600BA40 RID: 47680 RVA: 0x00053532 File Offset: 0x00051732
		Friend Overridable Property Label7 As Label

		' Token: 0x17004A3F RID: 19007
		' (get) Token: 0x0600BA41 RID: 47681 RVA: 0x0005353B File Offset: 0x0005173B
		' (set) Token: 0x0600BA42 RID: 47682 RVA: 0x00053545 File Offset: 0x00051745
		Friend Overridable Property Label6 As Label

		' Token: 0x17004A40 RID: 19008
		' (get) Token: 0x0600BA43 RID: 47683 RVA: 0x0005354E File Offset: 0x0005174E
		' (set) Token: 0x0600BA44 RID: 47684 RVA: 0x00053558 File Offset: 0x00051758
		Friend Overridable Property txtIFSCCode As TextBox

		' Token: 0x17004A41 RID: 19009
		' (get) Token: 0x0600BA45 RID: 47685 RVA: 0x00053561 File Offset: 0x00051761
		' (set) Token: 0x0600BA46 RID: 47686 RVA: 0x0005356B File Offset: 0x0005176B
		Friend Overridable Property txtSwiftCode As TextBox

		' Token: 0x17004A42 RID: 19010
		' (get) Token: 0x0600BA47 RID: 47687 RVA: 0x00053574 File Offset: 0x00051774
		' (set) Token: 0x0600BA48 RID: 47688 RVA: 0x0005357E File Offset: 0x0005177E
		Friend Overridable Property lblUser As Label

		' Token: 0x17004A43 RID: 19011
		' (get) Token: 0x0600BA49 RID: 47689 RVA: 0x00053587 File Offset: 0x00051787
		' (set) Token: 0x0600BA4A RID: 47690 RVA: 0x00053591 File Offset: 0x00051791
		Friend Overridable Property Label14 As Label

		' Token: 0x17004A44 RID: 19012
		' (get) Token: 0x0600BA4B RID: 47691 RVA: 0x0005359A File Offset: 0x0005179A
		' (set) Token: 0x0600BA4C RID: 47692 RVA: 0x000535A4 File Offset: 0x000517A4
		Friend Overridable Property txtBank As TextBox

		' Token: 0x17004A45 RID: 19013
		' (get) Token: 0x0600BA4D RID: 47693 RVA: 0x000535AD File Offset: 0x000517AD
		' (set) Token: 0x0600BA4E RID: 47694 RVA: 0x000535B7 File Offset: 0x000517B7
		Friend Overridable Property Label5 As Label

		' Token: 0x17004A46 RID: 19014
		' (get) Token: 0x0600BA4F RID: 47695 RVA: 0x000535C0 File Offset: 0x000517C0
		' (set) Token: 0x0600BA50 RID: 47696 RVA: 0x000535CA File Offset: 0x000517CA
		Friend Overridable Property Label12 As Label

		' Token: 0x17004A47 RID: 19015
		' (get) Token: 0x0600BA51 RID: 47697 RVA: 0x000535D3 File Offset: 0x000517D3
		' (set) Token: 0x0600BA52 RID: 47698 RVA: 0x000535DD File Offset: 0x000517DD
		Friend Overridable Property txtAccountName As TextBox

		' Token: 0x17004A48 RID: 19016
		' (get) Token: 0x0600BA53 RID: 47699 RVA: 0x000535E6 File Offset: 0x000517E6
		' (set) Token: 0x0600BA54 RID: 47700 RVA: 0x0077F134 File Offset: 0x0077D334
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A49 RID: 19017
		' (get) Token: 0x0600BA55 RID: 47701 RVA: 0x000535F0 File Offset: 0x000517F0
		' (set) Token: 0x0600BA56 RID: 47702 RVA: 0x000535FA File Offset: 0x000517FA
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004A4A RID: 19018
		' (get) Token: 0x0600BA57 RID: 47703 RVA: 0x00053603 File Offset: 0x00051803
		' (set) Token: 0x0600BA58 RID: 47704 RVA: 0x0005360D File Offset: 0x0005180D
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004A4B RID: 19019
		' (get) Token: 0x0600BA59 RID: 47705 RVA: 0x00053616 File Offset: 0x00051816
		' (set) Token: 0x0600BA5A RID: 47706 RVA: 0x00053620 File Offset: 0x00051820
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004A4C RID: 19020
		' (get) Token: 0x0600BA5B RID: 47707 RVA: 0x00053629 File Offset: 0x00051829
		' (set) Token: 0x0600BA5C RID: 47708 RVA: 0x00053633 File Offset: 0x00051833
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004A4D RID: 19021
		' (get) Token: 0x0600BA5D RID: 47709 RVA: 0x0005363C File Offset: 0x0005183C
		' (set) Token: 0x0600BA5E RID: 47710 RVA: 0x0077F194 File Offset: 0x0077D394
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A4E RID: 19022
		' (get) Token: 0x0600BA5F RID: 47711 RVA: 0x00053646 File Offset: 0x00051846
		' (set) Token: 0x0600BA60 RID: 47712 RVA: 0x0077F1F4 File Offset: 0x0077D3F4
		Private _txtAmount As TextBox
		Friend Overridable Property txtAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtAmount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A4F RID: 19023
		' (get) Token: 0x0600BA61 RID: 47713 RVA: 0x00053650 File Offset: 0x00051850
		' (set) Token: 0x0600BA62 RID: 47714 RVA: 0x0005365A File Offset: 0x0005185A
		Friend Overridable Property Label2 As Label

		' Token: 0x17004A50 RID: 19024
		' (get) Token: 0x0600BA63 RID: 47715 RVA: 0x00053663 File Offset: 0x00051863
		' (set) Token: 0x0600BA64 RID: 47716 RVA: 0x0077F270 File Offset: 0x0077D470
		Private _txtNotes As TextBox
		Friend Overridable Property txtNotes As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNotes
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNotes_KeyDown
				Dim textBox As TextBox = Me._txtNotes
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNotes = value
				textBox = Me._txtNotes
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A51 RID: 19025
		' (get) Token: 0x0600BA65 RID: 47717 RVA: 0x0005366D File Offset: 0x0005186D
		' (set) Token: 0x0600BA66 RID: 47718 RVA: 0x00053677 File Offset: 0x00051877
		Friend Overridable Property Label8 As Label

		' Token: 0x17004A52 RID: 19026
		' (get) Token: 0x0600BA67 RID: 47719 RVA: 0x00053680 File Offset: 0x00051880
		' (set) Token: 0x0600BA68 RID: 47720 RVA: 0x0005368A File Offset: 0x0005188A
		Friend Overridable Property Label10 As Label

		' Token: 0x17004A53 RID: 19027
		' (get) Token: 0x0600BA69 RID: 47721 RVA: 0x00053693 File Offset: 0x00051893
		' (set) Token: 0x0600BA6A RID: 47722 RVA: 0x0077F2B4 File Offset: 0x0077D4B4
		Private _txtDepositerName As TextBox
		Friend Overridable Property txtDepositerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDepositerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDepositerName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtDepositerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtDepositerName = value
				textBox = Me._txtDepositerName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A54 RID: 19028
		' (get) Token: 0x0600BA6B RID: 47723 RVA: 0x0005369D File Offset: 0x0005189D
		' (set) Token: 0x0600BA6C RID: 47724 RVA: 0x000536A7 File Offset: 0x000518A7
		Friend Overridable Property Label11 As Label

		' Token: 0x17004A55 RID: 19029
		' (get) Token: 0x0600BA6D RID: 47725 RVA: 0x000536B0 File Offset: 0x000518B0
		' (set) Token: 0x0600BA6E RID: 47726 RVA: 0x0077F314 File Offset: 0x0077D514
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A56 RID: 19030
		' (get) Token: 0x0600BA6F RID: 47727 RVA: 0x000536BA File Offset: 0x000518BA
		' (set) Token: 0x0600BA70 RID: 47728 RVA: 0x000536C4 File Offset: 0x000518C4
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17004A57 RID: 19031
		' (get) Token: 0x0600BA71 RID: 47729 RVA: 0x000536CD File Offset: 0x000518CD
		' (set) Token: 0x0600BA72 RID: 47730 RVA: 0x000536D7 File Offset: 0x000518D7
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004A58 RID: 19032
		' (get) Token: 0x0600BA73 RID: 47731 RVA: 0x000536E0 File Offset: 0x000518E0
		' (set) Token: 0x0600BA74 RID: 47732 RVA: 0x000536EA File Offset: 0x000518EA
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004A59 RID: 19033
		' (get) Token: 0x0600BA75 RID: 47733 RVA: 0x000536F3 File Offset: 0x000518F3
		' (set) Token: 0x0600BA76 RID: 47734 RVA: 0x000536FD File Offset: 0x000518FD
		Friend Overridable Property Label4 As Label

		' Token: 0x17004A5A RID: 19034
		' (get) Token: 0x0600BA77 RID: 47735 RVA: 0x00053706 File Offset: 0x00051906
		' (set) Token: 0x0600BA78 RID: 47736 RVA: 0x00053710 File Offset: 0x00051910
		Friend Overridable Property label9 As Label

		' Token: 0x17004A5B RID: 19035
		' (get) Token: 0x0600BA79 RID: 47737 RVA: 0x00053719 File Offset: 0x00051919
		' (set) Token: 0x0600BA7A RID: 47738 RVA: 0x00053723 File Offset: 0x00051923
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004A5C RID: 19036
		' (get) Token: 0x0600BA7B RID: 47739 RVA: 0x0005372C File Offset: 0x0005192C
		' (set) Token: 0x0600BA7C RID: 47740 RVA: 0x0077F390 File Offset: 0x0077D590
		Private _txtAccNo As TextBox
		Friend Overridable Property txtAccNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtAccNo_TextChanged
				Dim textBox As TextBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtAccNo = value
				textBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A5D RID: 19037
		' (get) Token: 0x0600BA7D RID: 47741 RVA: 0x00053736 File Offset: 0x00051936
		' (set) Token: 0x0600BA7E RID: 47742 RVA: 0x00053740 File Offset: 0x00051940
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004A5E RID: 19038
		' (get) Token: 0x0600BA7F RID: 47743 RVA: 0x00053749 File Offset: 0x00051949
		' (set) Token: 0x0600BA80 RID: 47744 RVA: 0x0077F3D4 File Offset: 0x0077D5D4
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

		' Token: 0x17004A5F RID: 19039
		' (get) Token: 0x0600BA81 RID: 47745 RVA: 0x00053753 File Offset: 0x00051953
		' (set) Token: 0x0600BA82 RID: 47746 RVA: 0x0005375D File Offset: 0x0005195D
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004A60 RID: 19040
		' (get) Token: 0x0600BA83 RID: 47747 RVA: 0x00053766 File Offset: 0x00051966
		' (set) Token: 0x0600BA84 RID: 47748 RVA: 0x00053770 File Offset: 0x00051970
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004A61 RID: 19041
		' (get) Token: 0x0600BA85 RID: 47749 RVA: 0x00053779 File Offset: 0x00051979
		' (set) Token: 0x0600BA86 RID: 47750 RVA: 0x00053783 File Offset: 0x00051983
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004A62 RID: 19042
		' (get) Token: 0x0600BA87 RID: 47751 RVA: 0x0005378C File Offset: 0x0005198C
		' (set) Token: 0x0600BA88 RID: 47752 RVA: 0x00053796 File Offset: 0x00051996
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004A63 RID: 19043
		' (get) Token: 0x0600BA89 RID: 47753 RVA: 0x0005379F File Offset: 0x0005199F
		' (set) Token: 0x0600BA8A RID: 47754 RVA: 0x000537A9 File Offset: 0x000519A9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004A64 RID: 19044
		' (get) Token: 0x0600BA8B RID: 47755 RVA: 0x000537B2 File Offset: 0x000519B2
		' (set) Token: 0x0600BA8C RID: 47756 RVA: 0x000537BC File Offset: 0x000519BC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004A65 RID: 19045
		' (get) Token: 0x0600BA8D RID: 47757 RVA: 0x000537C5 File Offset: 0x000519C5
		' (set) Token: 0x0600BA8E RID: 47758 RVA: 0x000537CF File Offset: 0x000519CF
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004A66 RID: 19046
		' (get) Token: 0x0600BA8F RID: 47759 RVA: 0x000537D8 File Offset: 0x000519D8
		' (set) Token: 0x0600BA90 RID: 47760 RVA: 0x000537E2 File Offset: 0x000519E2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004A67 RID: 19047
		' (get) Token: 0x0600BA91 RID: 47761 RVA: 0x000537EB File Offset: 0x000519EB
		' (set) Token: 0x0600BA92 RID: 47762 RVA: 0x000537F5 File Offset: 0x000519F5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004A68 RID: 19048
		' (get) Token: 0x0600BA93 RID: 47763 RVA: 0x000537FE File Offset: 0x000519FE
		' (set) Token: 0x0600BA94 RID: 47764 RVA: 0x00053808 File Offset: 0x00051A08
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004A69 RID: 19049
		' (get) Token: 0x0600BA95 RID: 47765 RVA: 0x00053811 File Offset: 0x00051A11
		' (set) Token: 0x0600BA96 RID: 47766 RVA: 0x0005381B File Offset: 0x00051A1B
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004A6A RID: 19050
		' (get) Token: 0x0600BA97 RID: 47767 RVA: 0x00053824 File Offset: 0x00051A24
		' (set) Token: 0x0600BA98 RID: 47768 RVA: 0x0005382E File Offset: 0x00051A2E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004A6B RID: 19051
		' (get) Token: 0x0600BA99 RID: 47769 RVA: 0x00053837 File Offset: 0x00051A37
		' (set) Token: 0x0600BA9A RID: 47770 RVA: 0x00053841 File Offset: 0x00051A41
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004A6C RID: 19052
		' (get) Token: 0x0600BA9B RID: 47771 RVA: 0x0005384A File Offset: 0x00051A4A
		' (set) Token: 0x0600BA9C RID: 47772 RVA: 0x00053854 File Offset: 0x00051A54
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004A6D RID: 19053
		' (get) Token: 0x0600BA9D RID: 47773 RVA: 0x0005385D File Offset: 0x00051A5D
		' (set) Token: 0x0600BA9E RID: 47774 RVA: 0x00053867 File Offset: 0x00051A67
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004A6E RID: 19054
		' (get) Token: 0x0600BA9F RID: 47775 RVA: 0x00053870 File Offset: 0x00051A70
		' (set) Token: 0x0600BAA0 RID: 47776 RVA: 0x0077F418 File Offset: 0x0077D618
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A6F RID: 19055
		' (get) Token: 0x0600BAA1 RID: 47777 RVA: 0x0005387A File Offset: 0x00051A7A
		' (set) Token: 0x0600BAA2 RID: 47778 RVA: 0x0077F45C File Offset: 0x0077D65C
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

		' Token: 0x17004A70 RID: 19056
		' (get) Token: 0x0600BAA3 RID: 47779 RVA: 0x00053884 File Offset: 0x00051A84
		' (set) Token: 0x0600BAA4 RID: 47780 RVA: 0x0077F4A0 File Offset: 0x0077D6A0
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

		' Token: 0x17004A71 RID: 19057
		' (get) Token: 0x0600BAA5 RID: 47781 RVA: 0x0005388E File Offset: 0x00051A8E
		' (set) Token: 0x0600BAA6 RID: 47782 RVA: 0x0077F4E4 File Offset: 0x0077D6E4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
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

		' Token: 0x17004A72 RID: 19058
		' (get) Token: 0x0600BAA7 RID: 47783 RVA: 0x00053898 File Offset: 0x00051A98
		' (set) Token: 0x0600BAA8 RID: 47784 RVA: 0x0077F528 File Offset: 0x0077D728
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

		' Token: 0x17004A73 RID: 19059
		' (get) Token: 0x0600BAA9 RID: 47785 RVA: 0x000538A2 File Offset: 0x00051AA2
		' (set) Token: 0x0600BAAA RID: 47786 RVA: 0x0077F56C File Offset: 0x0077D76C
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A74 RID: 19060
		' (get) Token: 0x0600BAAB RID: 47787 RVA: 0x000538AC File Offset: 0x00051AAC
		' (set) Token: 0x0600BAAC RID: 47788 RVA: 0x0077F5B0 File Offset: 0x0077D7B0
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A75 RID: 19061
		' (get) Token: 0x0600BAAD RID: 47789 RVA: 0x000538B6 File Offset: 0x00051AB6
		' (set) Token: 0x0600BAAE RID: 47790 RVA: 0x0077F5F4 File Offset: 0x0077D7F4
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600BAAF RID: 47791 RVA: 0x0077F638 File Offset: 0x0077D838
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM FundDeposit"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAB0 RID: 47792 RVA: 0x000538C0 File Offset: 0x00051AC0
		Public Sub Clear()
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Today
			Me.txtAccNo.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600BAB1 RID: 47793 RVA: 0x0077F73C File Offset: 0x0077D93C
		Public Sub Reset()
			Me.txtDepositerName.Text = ""
			Me.txtAccountName.Text = ""
			Me.cmbAccountNo.SelectedIndex = -1
			Me.txtAmount.Text = ""
			Me.dtpDate.Value = DateAndTime.Today
			Me.txtNotes.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtBank.Text = ""
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.btnPrint.Enabled = False
			Me.txtDepositerName.Focus()
			Me.Clear()
			Me.auto()
		End Sub

		' Token: 0x0600BAB2 RID: 47794 RVA: 0x0077F840 File Offset: 0x0077DA40
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT FundDeposit.Id, RTRIM(DepositerName), Amount, FundDeposit.Date, RTRIM(FundDeposit.Notes),RTRIM(AccNo), RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration,FundDeposit where BankBranch.ID=BankAccountRegistration.BranchID and FundDeposit.AccNo=BankAccountRegistration.AccountNo order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAB3 RID: 47795 RVA: 0x0077F9C8 File Offset: 0x0077DBC8
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from FundDeposit where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim text2 As String = String.Concat(New String() { "Deleted the fund deposit record having account no. '", Me.cmbAccountNo.Text, "' and Transaction ID '", Me.txtID.Text, "'" })
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					ModFunc.BankAccountLedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit")
					ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAB4 RID: 47796 RVA: 0x0077FB8C File Offset: 0x0077DD8C
		Private Sub cmbAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration where BankBranch.ID=BankAccountRegistration.BranchID and AccountNo=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtAccountName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtBank.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtBranchName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtSwiftCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtIFSCCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAB5 RID: 47797 RVA: 0x0077FD1C File Offset: 0x0077DF1C
		Public Sub fillAccountNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAB6 RID: 47798 RVA: 0x0077FE44 File Offset: 0x0077E044
		Private Sub frmFundDeposit_Load(sender As Object, e As EventArgs)
			Me.FYSerrch()
			Me.fillAccountNo()
			Me.Getdata()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BAB7 RID: 47799 RVA: 0x0077FEDC File Offset: 0x0077E0DC
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

		' Token: 0x0600BAB8 RID: 47800 RVA: 0x00780054 File Offset: 0x0077E254
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

		' Token: 0x0600BAB9 RID: 47801 RVA: 0x00780110 File Offset: 0x0077E310
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

		' Token: 0x0600BABA RID: 47802 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BABB RID: 47803 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BABC RID: 47804 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BABD RID: 47805 RVA: 0x007801DC File Offset: 0x0077E3DC
		Private Sub FYSerrch()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BABE RID: 47806 RVA: 0x007802D4 File Offset: 0x0077E4D4
		Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtAmount.Text
					Dim selectionStart As Integer = Me.txtAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtAmount.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600BABF RID: 47807 RVA: 0x007803CC File Offset: 0x0077E5CC
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600BAC0 RID: 47808 RVA: 0x007804B4 File Offset: 0x0077E6B4
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtDepositerName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtAmount.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.dtpDate.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtNotes.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbAccountNo.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtAccountName.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.txtBank.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.txtBranchName.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtSwiftCode.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtIFSCCode.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnPrint.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BAC1 RID: 47809 RVA: 0x007806CC File Offset: 0x0077E8CC
		Private Sub txtAccNo_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT FundDeposit.Id, RTRIM(DepositerName), Amount, FundDeposit.Date, RTRIM(FundDeposit.Notes),RTRIM(AccNo), RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration,FundDeposit where BankBranch.ID=BankAccountRegistration.BranchID and FundDeposit.AccNo=BankAccountRegistration.AccountNo and AccNo like N'%" + Me.txtAccNo.Text + "%' order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAC2 RID: 47810 RVA: 0x000538FD File Offset: 0x00051AFD
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600BAC3 RID: 47811 RVA: 0x0078085C File Offset: 0x0077EA5C
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600BAC4 RID: 47812 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDepositerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BAC5 RID: 47813 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BAC6 RID: 47814 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BAC7 RID: 47815 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BAC8 RID: 47816 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BAC9 RID: 47817 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmFundDeposit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BACA RID: 47818 RVA: 0x007808FC File Offset: 0x0077EAFC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtDepositerName.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtDepositerName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtDepositerName, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbAccountNo.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, String.Empty)
			End If
		End Sub

		' Token: 0x0600BACB RID: 47819 RVA: 0x00053919 File Offset: 0x00051B19
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BACC RID: 47820 RVA: 0x007809F0 File Offset: 0x0077EBF0
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtDepositerName.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter depositer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtDepositerName.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag5 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
						If flag5 Then
							MessageBox.Show("Amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAmount.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please select account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAccountNo.Focus()
							Else
								Try
									Me.auto()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "insert into FundDeposit(Id, DepositerName, Amount, Date, AccNo, Notes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtDepositerName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbAccountNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtNotes.Text)
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim text3 As String = String.Concat(New String() { "added the new fund deposit to account no. '", Me.cmbAccountNo.Text, "' and Transaction ID '", Me.txtID.Text, "'" })
									ModFunc.LogFunc(Me.lblUser.Text, text3)
									ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtAccountName.Text)
									MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
									Me.btnPrint.Enabled = True
									Me.Getdata()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BACD RID: 47821 RVA: 0x00780E74 File Offset: 0x0077F074
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtDepositerName.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter depositer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDepositerName.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAmount.Focus()
				Else
					Dim flag3 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
					If flag3 Then
						MessageBox.Show("Amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please select account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbAccountNo.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update FundDeposit set  DepositerName=@d2, Amount=@d3, Date=@d4, AccNo=@d5, Notes=@d6 where ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtDepositerName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtAmount.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbAccountNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtNotes.Text)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								Dim text2 As String = String.Concat(New String() { "Updated the fund deposit record having account no. '", Me.cmbAccountNo.Text, "' and Transaction ID '", Me.txtID.Text, "'" })
								ModFunc.LogFunc(Me.lblUser.Text, text2)
								ModFunc.BankAccountLedgerUpdate(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit")
								ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit")
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Deposit", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtAccountName.Text)
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnUpdate.Enabled = False
								Me.Getdata()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BACE RID: 47822 RVA: 0x00781268 File Offset: 0x0077F468
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

		' Token: 0x0600BACF RID: 47823 RVA: 0x007812D0 File Offset: 0x0077F4D0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				Dim sqlCommand2 As SqlCommand = New SqlCommand(If(("SELECT FundDeposit.Id, DepositerName, Amount, FundDeposit.Date,FundDeposit.Notes,AccNo, AccountName,BankName,BranchName,SwiftCode,IFSCCode from BankBranch,BankAccountRegistration,FundDeposit where BankBranch.ID=BankAccountRegistration.BranchID and FundDeposit.AccNo=BankAccountRegistration.AccountNo and FundDeposit.ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), ""), ModCommonClasses.con)
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				sqlDataAdapter2.Fill(dataTable2)
				Dim dataSet As DataSet = New DataSet()
				dataSet.Tables.Add(dataTable)
				dataSet.Tables.Add(dataTable2)
				dataSet.WriteXmlSchema("FundDepositReceipt.xml")
				Dim rptFundDepositReceipt As rptFundDepositReceipt = New rptFundDepositReceipt()
				rptFundDepositReceipt.SetDataSource(dataSet)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptFundDepositReceipt
				MyProject.Forms.frmReport.ShowDialog()
				rptFundDepositReceipt.Close()
				rptFundDepositReceipt.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAD0 RID: 47824 RVA: 0x00053923 File Offset: 0x00051B23
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub

		' Token: 0x0600BAD1 RID: 47825 RVA: 0x00781440 File Offset: 0x0077F640
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BAD2 RID: 47826 RVA: 0x007816EC File Offset: 0x0077F8EC
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT FundDeposit.Id, RTRIM(DepositerName), Amount, FundDeposit.Date, RTRIM(FundDeposit.Notes),RTRIM(AccNo), RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration,FundDeposit where BankBranch.ID=BankAccountRegistration.BranchID and FundDeposit.AccNo=BankAccountRegistration.AccountNo and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
