Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200032F RID: 815
	<DesignerGenerated()>
	Public Partial Class frmBroker
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BF4C RID: 48972 RVA: 0x0079E8E4 File Offset: 0x0079CAE4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBroker_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBroker_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004C24 RID: 19492
		' (get) Token: 0x0600BF4F RID: 48975 RVA: 0x0005581D File Offset: 0x00053A1D
		' (set) Token: 0x0600BF50 RID: 48976 RVA: 0x00055827 File Offset: 0x00053A27
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004C25 RID: 19493
		' (get) Token: 0x0600BF51 RID: 48977 RVA: 0x00055830 File Offset: 0x00053A30
		' (set) Token: 0x0600BF52 RID: 48978 RVA: 0x0005583A File Offset: 0x00053A3A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004C26 RID: 19494
		' (get) Token: 0x0600BF53 RID: 48979 RVA: 0x00055843 File Offset: 0x00053A43
		' (set) Token: 0x0600BF54 RID: 48980 RVA: 0x0005584D File Offset: 0x00053A4D
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004C27 RID: 19495
		' (get) Token: 0x0600BF55 RID: 48981 RVA: 0x00055856 File Offset: 0x00053A56
		' (set) Token: 0x0600BF56 RID: 48982 RVA: 0x00055860 File Offset: 0x00053A60
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004C28 RID: 19496
		' (get) Token: 0x0600BF57 RID: 48983 RVA: 0x00055869 File Offset: 0x00053A69
		' (set) Token: 0x0600BF58 RID: 48984 RVA: 0x00055873 File Offset: 0x00053A73
		Friend Overridable Property Label6 As Label

		' Token: 0x17004C29 RID: 19497
		' (get) Token: 0x0600BF59 RID: 48985 RVA: 0x0005587C File Offset: 0x00053A7C
		' (set) Token: 0x0600BF5A RID: 48986 RVA: 0x00055886 File Offset: 0x00053A86
		Friend Overridable Property Label4 As Label

		' Token: 0x17004C2A RID: 19498
		' (get) Token: 0x0600BF5B RID: 48987 RVA: 0x0005588F File Offset: 0x00053A8F
		' (set) Token: 0x0600BF5C RID: 48988 RVA: 0x007A0C90 File Offset: 0x0079EE90
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C2B RID: 19499
		' (get) Token: 0x0600BF5D RID: 48989 RVA: 0x00055899 File Offset: 0x00053A99
		' (set) Token: 0x0600BF5E RID: 48990 RVA: 0x000558A3 File Offset: 0x00053AA3
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17004C2C RID: 19500
		' (get) Token: 0x0600BF5F RID: 48991 RVA: 0x000558AC File Offset: 0x00053AAC
		' (set) Token: 0x0600BF60 RID: 48992 RVA: 0x000558B6 File Offset: 0x00053AB6
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004C2D RID: 19501
		' (get) Token: 0x0600BF61 RID: 48993 RVA: 0x000558BF File Offset: 0x00053ABF
		' (set) Token: 0x0600BF62 RID: 48994 RVA: 0x000558C9 File Offset: 0x00053AC9
		Friend Overridable Property txtEmail As TextBox

		' Token: 0x17004C2E RID: 19502
		' (get) Token: 0x0600BF63 RID: 48995 RVA: 0x000558D2 File Offset: 0x00053AD2
		' (set) Token: 0x0600BF64 RID: 48996 RVA: 0x007A0CD4 File Offset: 0x0079EED4
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C2F RID: 19503
		' (get) Token: 0x0600BF65 RID: 48997 RVA: 0x000558DC File Offset: 0x00053ADC
		' (set) Token: 0x0600BF66 RID: 48998 RVA: 0x000558E6 File Offset: 0x00053AE6
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004C30 RID: 19504
		' (get) Token: 0x0600BF67 RID: 48999 RVA: 0x000558EF File Offset: 0x00053AEF
		' (set) Token: 0x0600BF68 RID: 49000 RVA: 0x000558F9 File Offset: 0x00053AF9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004C31 RID: 19505
		' (get) Token: 0x0600BF69 RID: 49001 RVA: 0x00055902 File Offset: 0x00053B02
		' (set) Token: 0x0600BF6A RID: 49002 RVA: 0x0005590C File Offset: 0x00053B0C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004C32 RID: 19506
		' (get) Token: 0x0600BF6B RID: 49003 RVA: 0x00055915 File Offset: 0x00053B15
		' (set) Token: 0x0600BF6C RID: 49004 RVA: 0x0005591F File Offset: 0x00053B1F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004C33 RID: 19507
		' (get) Token: 0x0600BF6D RID: 49005 RVA: 0x00055928 File Offset: 0x00053B28
		' (set) Token: 0x0600BF6E RID: 49006 RVA: 0x00055932 File Offset: 0x00053B32
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004C34 RID: 19508
		' (get) Token: 0x0600BF6F RID: 49007 RVA: 0x0005593B File Offset: 0x00053B3B
		' (set) Token: 0x0600BF70 RID: 49008 RVA: 0x00055945 File Offset: 0x00053B45
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004C35 RID: 19509
		' (get) Token: 0x0600BF71 RID: 49009 RVA: 0x0005594E File Offset: 0x00053B4E
		' (set) Token: 0x0600BF72 RID: 49010 RVA: 0x00055958 File Offset: 0x00053B58
		Friend Overridable Property Column5 As DataGridViewImageColumn

		' Token: 0x17004C36 RID: 19510
		' (get) Token: 0x0600BF73 RID: 49011 RVA: 0x00055961 File Offset: 0x00053B61
		' (set) Token: 0x0600BF74 RID: 49012 RVA: 0x007A0D50 File Offset: 0x0079EF50
		Private _cmbSalesmanName As ComboBox
		Friend Overridable Property cmbSalesmanName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSalesmanName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSalesmanName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSalesmanName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSalesmanName = value
				comboBox = Me._cmbSalesmanName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C37 RID: 19511
		' (get) Token: 0x0600BF75 RID: 49013 RVA: 0x0005596B File Offset: 0x00053B6B
		' (set) Token: 0x0600BF76 RID: 49014 RVA: 0x00055975 File Offset: 0x00053B75
		Friend Overridable Property Label16 As Label

		' Token: 0x17004C38 RID: 19512
		' (get) Token: 0x0600BF77 RID: 49015 RVA: 0x0005597E File Offset: 0x00053B7E
		' (set) Token: 0x0600BF78 RID: 49016 RVA: 0x00055988 File Offset: 0x00053B88
		Friend Overridable Property Label13 As Label

		' Token: 0x17004C39 RID: 19513
		' (get) Token: 0x0600BF79 RID: 49017 RVA: 0x00055991 File Offset: 0x00053B91
		' (set) Token: 0x0600BF7A RID: 49018 RVA: 0x0005599B File Offset: 0x00053B9B
		Friend Overridable Property Label33 As Label

		' Token: 0x17004C3A RID: 19514
		' (get) Token: 0x0600BF7B RID: 49019 RVA: 0x000559A4 File Offset: 0x00053BA4
		' (set) Token: 0x0600BF7C RID: 49020 RVA: 0x007A0DB0 File Offset: 0x0079EFB0
		Private _txtCommissionPer As TextBox
		Friend Overridable Property txtCommissionPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCommissionPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCommissionPer_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCommissionPer_KeyDown
				Dim textBox As TextBox = Me._txtCommissionPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCommissionPer = value
				textBox = Me._txtCommissionPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C3B RID: 19515
		' (get) Token: 0x0600BF7D RID: 49021 RVA: 0x000559AE File Offset: 0x00053BAE
		' (set) Token: 0x0600BF7E RID: 49022 RVA: 0x000559B8 File Offset: 0x00053BB8
		Friend Overridable Property Label11 As Label

		' Token: 0x17004C3C RID: 19516
		' (get) Token: 0x0600BF7F RID: 49023 RVA: 0x000559C1 File Offset: 0x00053BC1
		' (set) Token: 0x0600BF80 RID: 49024 RVA: 0x000559CB File Offset: 0x00053BCB
		Public Overridable Property Picture As PictureBox

		' Token: 0x17004C3D RID: 19517
		' (get) Token: 0x0600BF81 RID: 49025 RVA: 0x000559D4 File Offset: 0x00053BD4
		' (set) Token: 0x0600BF82 RID: 49026 RVA: 0x007A0E10 File Offset: 0x0079F010
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C3E RID: 19518
		' (get) Token: 0x0600BF83 RID: 49027 RVA: 0x000559DE File Offset: 0x00053BDE
		' (set) Token: 0x0600BF84 RID: 49028 RVA: 0x007A0E54 File Offset: 0x0079F054
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C3F RID: 19519
		' (get) Token: 0x0600BF85 RID: 49029 RVA: 0x000559E8 File Offset: 0x00053BE8
		' (set) Token: 0x0600BF86 RID: 49030 RVA: 0x007A0E98 File Offset: 0x0079F098
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C40 RID: 19520
		' (get) Token: 0x0600BF87 RID: 49031 RVA: 0x000559F2 File Offset: 0x00053BF2
		' (set) Token: 0x0600BF88 RID: 49032 RVA: 0x000559FC File Offset: 0x00053BFC
		Friend Overridable Property Label2 As Label

		' Token: 0x17004C41 RID: 19521
		' (get) Token: 0x0600BF89 RID: 49033 RVA: 0x00055A05 File Offset: 0x00053C05
		' (set) Token: 0x0600BF8A RID: 49034 RVA: 0x00055A0F File Offset: 0x00053C0F
		Friend Overridable Property Label3 As Label

		' Token: 0x17004C42 RID: 19522
		' (get) Token: 0x0600BF8B RID: 49035 RVA: 0x00055A18 File Offset: 0x00053C18
		' (set) Token: 0x0600BF8C RID: 49036 RVA: 0x00055A22 File Offset: 0x00053C22
		Friend Overridable Property txtSalesmanID As TextBox

		' Token: 0x17004C43 RID: 19523
		' (get) Token: 0x0600BF8D RID: 49037 RVA: 0x00055A2B File Offset: 0x00053C2B
		' (set) Token: 0x0600BF8E RID: 49038 RVA: 0x007A0EDC File Offset: 0x0079F0DC
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAddress_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAddress = value
				textBox = Me._txtAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C44 RID: 19524
		' (get) Token: 0x0600BF8F RID: 49039 RVA: 0x00055A35 File Offset: 0x00053C35
		' (set) Token: 0x0600BF90 RID: 49040 RVA: 0x00055A3F File Offset: 0x00053C3F
		Friend Overridable Property Label5 As Label

		' Token: 0x17004C45 RID: 19525
		' (get) Token: 0x0600BF91 RID: 49041 RVA: 0x00055A48 File Offset: 0x00053C48
		' (set) Token: 0x0600BF92 RID: 49042 RVA: 0x00055A52 File Offset: 0x00053C52
		Friend Overridable Property Label7 As Label

		' Token: 0x17004C46 RID: 19526
		' (get) Token: 0x0600BF93 RID: 49043 RVA: 0x00055A5B File Offset: 0x00053C5B
		' (set) Token: 0x0600BF94 RID: 49044 RVA: 0x007A0F3C File Offset: 0x0079F13C
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C47 RID: 19527
		' (get) Token: 0x0600BF95 RID: 49045 RVA: 0x00055A65 File Offset: 0x00053C65
		' (set) Token: 0x0600BF96 RID: 49046 RVA: 0x00055A6F File Offset: 0x00053C6F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004C48 RID: 19528
		' (get) Token: 0x0600BF97 RID: 49047 RVA: 0x00055A78 File Offset: 0x00053C78
		' (set) Token: 0x0600BF98 RID: 49048 RVA: 0x00055A82 File Offset: 0x00053C82
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17004C49 RID: 19529
		' (get) Token: 0x0600BF99 RID: 49049 RVA: 0x00055A8B File Offset: 0x00053C8B
		' (set) Token: 0x0600BF9A RID: 49050 RVA: 0x00055A95 File Offset: 0x00053C95
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17004C4A RID: 19530
		' (get) Token: 0x0600BF9B RID: 49051 RVA: 0x00055A9E File Offset: 0x00053C9E
		' (set) Token: 0x0600BF9C RID: 49052 RVA: 0x00055AA8 File Offset: 0x00053CA8
		Friend Overridable Property Label1 As Label

		' Token: 0x17004C4B RID: 19531
		' (get) Token: 0x0600BF9D RID: 49053 RVA: 0x00055AB1 File Offset: 0x00053CB1
		' (set) Token: 0x0600BF9E RID: 49054 RVA: 0x00055ABB File Offset: 0x00053CBB
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004C4C RID: 19532
		' (get) Token: 0x0600BF9F RID: 49055 RVA: 0x00055AC4 File Offset: 0x00053CC4
		' (set) Token: 0x0600BFA0 RID: 49056 RVA: 0x00055ACE File Offset: 0x00053CCE
		Friend Overridable Property lblUser As Label

		' Token: 0x17004C4D RID: 19533
		' (get) Token: 0x0600BFA1 RID: 49057 RVA: 0x00055AD7 File Offset: 0x00053CD7
		' (set) Token: 0x0600BFA2 RID: 49058 RVA: 0x00055AE1 File Offset: 0x00053CE1
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004C4E RID: 19534
		' (get) Token: 0x0600BFA3 RID: 49059 RVA: 0x00055AEA File Offset: 0x00053CEA
		' (set) Token: 0x0600BFA4 RID: 49060 RVA: 0x00055AF4 File Offset: 0x00053CF4
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004C4F RID: 19535
		' (get) Token: 0x0600BFA5 RID: 49061 RVA: 0x00055AFD File Offset: 0x00053CFD
		' (set) Token: 0x0600BFA6 RID: 49062 RVA: 0x007A0FB8 File Offset: 0x0079F1B8
		Private _button3 As GelButton
		Friend Overridable Property button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.button3_Click
				Dim gelButton As GelButton = Me._button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._button3 = value
				gelButton = Me._button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C50 RID: 19536
		' (get) Token: 0x0600BFA7 RID: 49063 RVA: 0x00055B07 File Offset: 0x00053D07
		' (set) Token: 0x0600BFA8 RID: 49064 RVA: 0x007A0FFC File Offset: 0x0079F1FC
		Private _button1 As GelButton
		Friend Overridable Property button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.button1_Click
				Dim gelButton As GelButton = Me._button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._button1 = value
				gelButton = Me._button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C51 RID: 19537
		' (get) Token: 0x0600BFA9 RID: 49065 RVA: 0x00055B11 File Offset: 0x00053D11
		' (set) Token: 0x0600BFAA RID: 49066 RVA: 0x007A1040 File Offset: 0x0079F240
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

		' Token: 0x17004C52 RID: 19538
		' (get) Token: 0x0600BFAB RID: 49067 RVA: 0x00055B1B File Offset: 0x00053D1B
		' (set) Token: 0x0600BFAC RID: 49068 RVA: 0x007A1084 File Offset: 0x0079F284
		Private _button2 As GelButton
		Friend Overridable Property button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.button2_Click
				Dim gelButton As GelButton = Me._button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._button2 = value
				gelButton = Me._button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600BFAD RID: 49069 RVA: 0x007A10C8 File Offset: 0x0079F2C8
		Private Sub frmBroker_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.fillBrokerName()
			Me.fillBrokerID()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BFAE RID: 49070 RVA: 0x007A1160 File Offset: 0x0079F360
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) AS default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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

		' Token: 0x0600BFAF RID: 49071 RVA: 0x007A12D8 File Offset: 0x0079F4D8
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

		' Token: 0x0600BFB0 RID: 49072 RVA: 0x007A1394 File Offset: 0x0079F594
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

		' Token: 0x0600BFB1 RID: 49073 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BFB2 RID: 49074 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BFB3 RID: 49075 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BFB4 RID: 49076 RVA: 0x007A1460 File Offset: 0x0079F660
		Public Sub Reset()
			Me.cmbSalesmanName.Text = ""
			Me.txtAddress.Text = ""
			Me.cmbSalesmanName.Text = ""
			Me.txtSalesmanID.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtCommissionPer.Text = "0.000"
			Me.cmbSalesmanName.Focus()
			Me.button2.Enabled = True
			Me.button3.Enabled = False
			Me.button1.Enabled = False
			Me.Picture.Image = Resources.photo
			Me.auto()
			Me.fillBrokerName()
			Me.fillBrokerID()
			Me.Getdata()
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x0600BFB5 RID: 49077 RVA: 0x007A1554 File Offset: 0x0079F754
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 BR_ID FROM Broker ORDER BY BR_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("BR_ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600BFB6 RID: 49078 RVA: 0x007A16C0 File Offset: 0x0079F8C0
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtSalesmanID.Text = "BR-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BFB7 RID: 49079 RVA: 0x007A1734 File Offset: 0x0079F934
		Public Sub fillBrokerName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Broker", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSalesmanName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSalesmanName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600BFB8 RID: 49080 RVA: 0x007A1868 File Offset: 0x0079FA68
		Public Sub fillBrokerID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(BR_ID) FROM Broker order by BR_ID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BFB9 RID: 49081 RVA: 0x007A19A4 File Offset: 0x0079FBA4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Broker where BR_ID =" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the Broker record having Broker id '" + Me.txtSalesmanID.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillBrokerID()
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillBrokerID()
					Me.Reset()
					Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag2 Then
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con.Close()
				End If
				Me.Getdata()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BFBA RID: 49082 RVA: 0x007A1B10 File Offset: 0x0079FD10
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
			Dim frmCamera As frmCamera = New frmCamera()
			frmCamera.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
			End If
		End Sub

		' Token: 0x0600BFBB RID: 49083 RVA: 0x007A1B68 File Offset: 0x0079FD68
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim frmSalesmanRecord As frmSalesmanRecord = New frmSalesmanRecord()
			frmSalesmanRecord.lblSet.Text = "Broker Entry"
			frmSalesmanRecord.Getdata()
			frmSalesmanRecord.ShowDialog()
		End Sub

		' Token: 0x0600BFBC RID: 49084 RVA: 0x007A1B9C File Offset: 0x0079FD9C
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600BFBD RID: 49085 RVA: 0x00055B25 File Offset: 0x00053D25
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources.photo
		End Sub

		' Token: 0x0600BFBE RID: 49086 RVA: 0x007A1C3C File Offset: 0x0079FE3C
		Private Sub txtCommissionPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCommissionPer.Text
					Dim selectionStart As Integer = Me.txtCommissionPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCommissionPer.SelectionLength
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

		' Token: 0x0600BFBF RID: 49087 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600BFC0 RID: 49088 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSalesmanName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BFC1 RID: 49089 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BFC2 RID: 49090 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BFC3 RID: 49091 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCommissionPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BFC4 RID: 49092 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBroker_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BFC5 RID: 49093 RVA: 0x007A1D34 File Offset: 0x0079FF34
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbSalesmanName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbSalesmanName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSalesmanName, String.Empty)
			End If
		End Sub

		' Token: 0x0600BFC6 RID: 49094 RVA: 0x007A1E28 File Offset: 0x007A0028
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

		' Token: 0x0600BFC7 RID: 49095 RVA: 0x007A1F10 File Offset: 0x007A0110
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT BR_ID,RTRIM(Broker_ID),RTRIM([Name]), RTRIM(Address),RTRIM(ContactNo),CommissionPer,Photo from Broker order by name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
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

		' Token: 0x0600BFC8 RID: 49096 RVA: 0x007A204C File Offset: 0x007A024C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600BFC9 RID: 49097 RVA: 0x007A2074 File Offset: 0x007A0274
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.cmbSalesmanName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtCommissionPer.Text = dataGridViewRow.Cells(5).Value.ToString()
					Dim array As Byte() = CType(dataGridViewRow.Cells(6).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Me.button3.Enabled = True
					Me.button1.Enabled = True
					Me.button2.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BFCA RID: 49098 RVA: 0x00055B39 File Offset: 0x00053D39
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0600BFCB RID: 49099 RVA: 0x007A2204 File Offset: 0x007A0404
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT BR_ID,RTRIM(Broker_ID),RTRIM([Name]), RTRIM(Address),RTRIM(ContactNo),CommissionPer,Photo from Broker where name like N'" + Me.TextBox1.Text + "%' order by name", ModCommonClasses.con)
				End If
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag2 Then
					ModCommonClasses.cmd = New SqlCommand("SELECT BR_ID,RTRIM(Broker_ID),RTRIM([Name]), RTRIM(Address),RTRIM(ContactNo),CommissionPer,Photo from Broker where ContactNo like N'" + Me.TextBox1.Text + "%' order by name", ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BFCC RID: 49100 RVA: 0x00055B43 File Offset: 0x00053D43
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BFCD RID: 49101 RVA: 0x007A23A4 File Offset: 0x007A05A4
		Private Sub button2_Click(sender As Object, e As EventArgs)
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
				Me.auto()
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesmanName.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter Broker name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSalesmanName.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtContactNo.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select RTRIM(ContactNo) from Broker where ContactNo=@d1"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into Broker(BR_ID, Broker_ID, [Name], Address,ContactNo, CommissionPer,Photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSalesmanID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSalesmanName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtAddress.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtContactNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtCommissionPer.Text))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									Dim memoryStream As MemoryStream = New MemoryStream()
									Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
									bitmap.Save(memoryStream, ImageFormat.Jpeg)
									Dim buffer As Byte() = memoryStream.GetBuffer()
									Dim sqlParameter As SqlParameter = New SqlParameter("@d7", SqlDbType.Image)
									sqlParameter.Value = buffer
									ModCommonClasses.cmd.Parameters.Add(sqlParameter)
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, "added the new Broker having Broker id '" + Me.txtSalesmanID.Text + "'")
									MessageBox.Show("Successfully Saved", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.fillBrokerID()
									Me.button2.Enabled = False
									ModCommonClasses.con.Close()
									Me.fillBrokerName()
									Me.Getdata()
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BFCE RID: 49102 RVA: 0x007A2804 File Offset: 0x007A0A04
		Private Sub button3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesmanName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Broker name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSalesmanName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAddress.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtContactNo.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "update Broker set Broker_ID=@d2, [Name]=@d3, Address=@d4, ContactNo=@d5, CommissionPer=@d6, Photo=@d7 where BR_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSalesmanID.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSalesmanName.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtAddress.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtContactNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtCommissionPer.Text))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d7", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "updated the Broker having Broker id '" + Me.txtSalesmanID.Text + "'")
							MessageBox.Show("Successfully Updated", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.button3.Enabled = False
							Me.fillBrokerName()
							Me.Getdata()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BFCF RID: 49103 RVA: 0x007A2AF4 File Offset: 0x007A0CF4
		Private Sub button1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04004CD7 RID: 19671
		Private s As String

		' Token: 0x04004CD8 RID: 19672
		Private Photoname As String

		' Token: 0x04004CD9 RID: 19673
		Private IsImageChanged As Boolean
	End Class
End Namespace
