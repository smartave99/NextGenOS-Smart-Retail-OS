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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200030E RID: 782
	<DesignerGenerated()>
	Public Partial Class frmBankAccountRegistration
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B936 RID: 47414 RVA: 0x00052DD9 File Offset: 0x00050FD9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRegistration_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBankAccountRegistration_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170049D9 RID: 18905
		' (get) Token: 0x0600B939 RID: 47417 RVA: 0x00052E0B File Offset: 0x0005100B
		' (set) Token: 0x0600B93A RID: 47418 RVA: 0x00052E15 File Offset: 0x00051015
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170049DA RID: 18906
		' (get) Token: 0x0600B93B RID: 47419 RVA: 0x00052E1E File Offset: 0x0005101E
		' (set) Token: 0x0600B93C RID: 47420 RVA: 0x00052E28 File Offset: 0x00051028
		Friend Overridable Property Label3 As Label

		' Token: 0x170049DB RID: 18907
		' (get) Token: 0x0600B93D RID: 47421 RVA: 0x00052E31 File Offset: 0x00051031
		' (set) Token: 0x0600B93E RID: 47422 RVA: 0x00052E3B File Offset: 0x0005103B
		Friend Overridable Property txtBranchName As TextBox

		' Token: 0x170049DC RID: 18908
		' (get) Token: 0x0600B93F RID: 47423 RVA: 0x00052E44 File Offset: 0x00051044
		' (set) Token: 0x0600B940 RID: 47424 RVA: 0x007763F8 File Offset: 0x007745F8
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049DD RID: 18909
		' (get) Token: 0x0600B941 RID: 47425 RVA: 0x00052E4E File Offset: 0x0005104E
		' (set) Token: 0x0600B942 RID: 47426 RVA: 0x00052E58 File Offset: 0x00051058
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170049DE RID: 18910
		' (get) Token: 0x0600B943 RID: 47427 RVA: 0x00052E61 File Offset: 0x00051061
		' (set) Token: 0x0600B944 RID: 47428 RVA: 0x00052E6B File Offset: 0x0005106B
		Friend Overridable Property Label1 As Label

		' Token: 0x170049DF RID: 18911
		' (get) Token: 0x0600B945 RID: 47429 RVA: 0x00052E74 File Offset: 0x00051074
		' (set) Token: 0x0600B946 RID: 47430 RVA: 0x00052E7E File Offset: 0x0005107E
		Friend Overridable Property Label7 As Label

		' Token: 0x170049E0 RID: 18912
		' (get) Token: 0x0600B947 RID: 47431 RVA: 0x00052E87 File Offset: 0x00051087
		' (set) Token: 0x0600B948 RID: 47432 RVA: 0x00052E91 File Offset: 0x00051091
		Friend Overridable Property Label6 As Label

		' Token: 0x170049E1 RID: 18913
		' (get) Token: 0x0600B949 RID: 47433 RVA: 0x00052E9A File Offset: 0x0005109A
		' (set) Token: 0x0600B94A RID: 47434 RVA: 0x00052EA4 File Offset: 0x000510A4
		Friend Overridable Property txtIFSCCode As TextBox

		' Token: 0x170049E2 RID: 18914
		' (get) Token: 0x0600B94B RID: 47435 RVA: 0x00052EAD File Offset: 0x000510AD
		' (set) Token: 0x0600B94C RID: 47436 RVA: 0x00052EB7 File Offset: 0x000510B7
		Friend Overridable Property txtSwiftCode As TextBox

		' Token: 0x170049E3 RID: 18915
		' (get) Token: 0x0600B94D RID: 47437 RVA: 0x00052EC0 File Offset: 0x000510C0
		' (set) Token: 0x0600B94E RID: 47438 RVA: 0x00052ECA File Offset: 0x000510CA
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x170049E4 RID: 18916
		' (get) Token: 0x0600B94F RID: 47439 RVA: 0x00052ED3 File Offset: 0x000510D3
		' (set) Token: 0x0600B950 RID: 47440 RVA: 0x00052EDD File Offset: 0x000510DD
		Friend Overridable Property Label4 As Label

		' Token: 0x170049E5 RID: 18917
		' (get) Token: 0x0600B951 RID: 47441 RVA: 0x00052EE6 File Offset: 0x000510E6
		' (set) Token: 0x0600B952 RID: 47442 RVA: 0x00052EF0 File Offset: 0x000510F0
		Friend Overridable Property Label2 As Label

		' Token: 0x170049E6 RID: 18918
		' (get) Token: 0x0600B953 RID: 47443 RVA: 0x00052EF9 File Offset: 0x000510F9
		' (set) Token: 0x0600B954 RID: 47444 RVA: 0x00052F03 File Offset: 0x00051103
		Friend Overridable Property txtAccNo As TextBox

		' Token: 0x170049E7 RID: 18919
		' (get) Token: 0x0600B955 RID: 47445 RVA: 0x00052F0C File Offset: 0x0005110C
		' (set) Token: 0x0600B956 RID: 47446 RVA: 0x00052F16 File Offset: 0x00051116
		Friend Overridable Property lblUser As Label

		' Token: 0x170049E8 RID: 18920
		' (get) Token: 0x0600B957 RID: 47447 RVA: 0x00052F1F File Offset: 0x0005111F
		' (set) Token: 0x0600B958 RID: 47448 RVA: 0x00052F29 File Offset: 0x00051129
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x170049E9 RID: 18921
		' (get) Token: 0x0600B959 RID: 47449 RVA: 0x00052F32 File Offset: 0x00051132
		' (set) Token: 0x0600B95A RID: 47450 RVA: 0x00052F3C File Offset: 0x0005113C
		Friend Overridable Property Label14 As Label

		' Token: 0x170049EA RID: 18922
		' (get) Token: 0x0600B95B RID: 47451 RVA: 0x00052F45 File Offset: 0x00051145
		' (set) Token: 0x0600B95C RID: 47452 RVA: 0x00052F4F File Offset: 0x0005114F
		Friend Overridable Property txtBranchID As TextBox

		' Token: 0x170049EB RID: 18923
		' (get) Token: 0x0600B95D RID: 47453 RVA: 0x00052F58 File Offset: 0x00051158
		' (set) Token: 0x0600B95E RID: 47454 RVA: 0x00776458 File Offset: 0x00774658
		Private _txtBank As TextBox
		Friend Overridable Property txtBank As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBank
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtBank
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtBank = value
				textBox = Me._txtBank
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049EC RID: 18924
		' (get) Token: 0x0600B95F RID: 47455 RVA: 0x00052F62 File Offset: 0x00051162
		' (set) Token: 0x0600B960 RID: 47456 RVA: 0x00052F6C File Offset: 0x0005116C
		Friend Overridable Property Label5 As Label

		' Token: 0x170049ED RID: 18925
		' (get) Token: 0x0600B961 RID: 47457 RVA: 0x00052F75 File Offset: 0x00051175
		' (set) Token: 0x0600B962 RID: 47458 RVA: 0x00052F7F File Offset: 0x0005117F
		Friend Overridable Property Label8 As Label

		' Token: 0x170049EE RID: 18926
		' (get) Token: 0x0600B963 RID: 47459 RVA: 0x00052F88 File Offset: 0x00051188
		' (set) Token: 0x0600B964 RID: 47460 RVA: 0x00052F92 File Offset: 0x00051192
		Friend Overridable Property Label10 As Label

		' Token: 0x170049EF RID: 18927
		' (get) Token: 0x0600B965 RID: 47461 RVA: 0x00052F9B File Offset: 0x0005119B
		' (set) Token: 0x0600B966 RID: 47462 RVA: 0x00052FA5 File Offset: 0x000511A5
		Friend Overridable Property Label11 As Label

		' Token: 0x170049F0 RID: 18928
		' (get) Token: 0x0600B967 RID: 47463 RVA: 0x00052FAE File Offset: 0x000511AE
		' (set) Token: 0x0600B968 RID: 47464 RVA: 0x00052FB8 File Offset: 0x000511B8
		Friend Overridable Property Label12 As Label

		' Token: 0x170049F1 RID: 18929
		' (get) Token: 0x0600B969 RID: 47465 RVA: 0x00052FC1 File Offset: 0x000511C1
		' (set) Token: 0x0600B96A RID: 47466 RVA: 0x00052FCB File Offset: 0x000511CB
		Friend Overridable Property Label13 As Label

		' Token: 0x170049F2 RID: 18930
		' (get) Token: 0x0600B96B RID: 47467 RVA: 0x00052FD4 File Offset: 0x000511D4
		' (set) Token: 0x0600B96C RID: 47468 RVA: 0x0077649C File Offset: 0x0077469C
		Private _cmbActive As ComboBox
		Friend Overridable Property cmbActive As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbActive
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbActive_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbActive
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbActive = value
				comboBox = Me._cmbActive
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F3 RID: 18931
		' (get) Token: 0x0600B96D RID: 47469 RVA: 0x00052FDE File Offset: 0x000511DE
		' (set) Token: 0x0600B96E RID: 47470 RVA: 0x007764FC File Offset: 0x007746FC
		Private _txtBalanceAmount As TextBox
		Friend Overridable Property txtBalanceAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBalanceAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtBalanceAmount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBalanceAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtBalanceAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtBalanceAmount = value
				textBox = Me._txtBalanceAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F4 RID: 18932
		' (get) Token: 0x0600B96F RID: 47471 RVA: 0x00052FE8 File Offset: 0x000511E8
		' (set) Token: 0x0600B970 RID: 47472 RVA: 0x00776578 File Offset: 0x00774778
		Private _dtpOpeningDate As DateTimePicker
		Friend Overridable Property dtpOpeningDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpOpeningDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpOpeningDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpOpeningDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpOpeningDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpOpeningDate = value
				dateTimePicker = Me._dtpOpeningDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F5 RID: 18933
		' (get) Token: 0x0600B971 RID: 47473 RVA: 0x00052FF2 File Offset: 0x000511F2
		' (set) Token: 0x0600B972 RID: 47474 RVA: 0x007765D8 File Offset: 0x007747D8
		Private _cmbAccountType As ComboBox
		Friend Overridable Property cmbAccountType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountType_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAccountType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAccountType = value
				comboBox = Me._cmbAccountType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F6 RID: 18934
		' (get) Token: 0x0600B973 RID: 47475 RVA: 0x00052FFC File Offset: 0x000511FC
		' (set) Token: 0x0600B974 RID: 47476 RVA: 0x00776638 File Offset: 0x00774838
		Private _txtAccountName As TextBox
		Friend Overridable Property txtAccountName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccountName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAccountName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAccountName = value
				textBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F7 RID: 18935
		' (get) Token: 0x0600B975 RID: 47477 RVA: 0x00053006 File Offset: 0x00051206
		' (set) Token: 0x0600B976 RID: 47478 RVA: 0x00776698 File Offset: 0x00774898
		Private _txtAccountNo As TextBox
		Friend Overridable Property txtAccountNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAccountNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAccountNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAccountNo = value
				textBox = Me._txtAccountNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F8 RID: 18936
		' (get) Token: 0x0600B977 RID: 47479 RVA: 0x00053010 File Offset: 0x00051210
		' (set) Token: 0x0600B978 RID: 47480 RVA: 0x007766F8 File Offset: 0x007748F8
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170049F9 RID: 18937
		' (get) Token: 0x0600B979 RID: 47481 RVA: 0x0005301A File Offset: 0x0005121A
		' (set) Token: 0x0600B97A RID: 47482 RVA: 0x00053024 File Offset: 0x00051224
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170049FA RID: 18938
		' (get) Token: 0x0600B97B RID: 47483 RVA: 0x0005302D File Offset: 0x0005122D
		' (set) Token: 0x0600B97C RID: 47484 RVA: 0x00053037 File Offset: 0x00051237
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170049FB RID: 18939
		' (get) Token: 0x0600B97D RID: 47485 RVA: 0x00053040 File Offset: 0x00051240
		' (set) Token: 0x0600B97E RID: 47486 RVA: 0x0005304A File Offset: 0x0005124A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170049FC RID: 18940
		' (get) Token: 0x0600B97F RID: 47487 RVA: 0x00053053 File Offset: 0x00051253
		' (set) Token: 0x0600B980 RID: 47488 RVA: 0x0005305D File Offset: 0x0005125D
		Friend Overridable Property txtID As TextBox

		' Token: 0x170049FD RID: 18941
		' (get) Token: 0x0600B981 RID: 47489 RVA: 0x00053066 File Offset: 0x00051266
		' (set) Token: 0x0600B982 RID: 47490 RVA: 0x00053070 File Offset: 0x00051270
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170049FE RID: 18942
		' (get) Token: 0x0600B983 RID: 47491 RVA: 0x00053079 File Offset: 0x00051279
		' (set) Token: 0x0600B984 RID: 47492 RVA: 0x00053083 File Offset: 0x00051283
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x170049FF RID: 18943
		' (get) Token: 0x0600B985 RID: 47493 RVA: 0x0005308C File Offset: 0x0005128C
		' (set) Token: 0x0600B986 RID: 47494 RVA: 0x00053096 File Offset: 0x00051296
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004A00 RID: 18944
		' (get) Token: 0x0600B987 RID: 47495 RVA: 0x0005309F File Offset: 0x0005129F
		' (set) Token: 0x0600B988 RID: 47496 RVA: 0x000530A9 File Offset: 0x000512A9
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004A01 RID: 18945
		' (get) Token: 0x0600B989 RID: 47497 RVA: 0x000530B2 File Offset: 0x000512B2
		' (set) Token: 0x0600B98A RID: 47498 RVA: 0x000530BC File Offset: 0x000512BC
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004A02 RID: 18946
		' (get) Token: 0x0600B98B RID: 47499 RVA: 0x000530C5 File Offset: 0x000512C5
		' (set) Token: 0x0600B98C RID: 47500 RVA: 0x000530CF File Offset: 0x000512CF
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004A03 RID: 18947
		' (get) Token: 0x0600B98D RID: 47501 RVA: 0x000530D8 File Offset: 0x000512D8
		' (set) Token: 0x0600B98E RID: 47502 RVA: 0x000530E2 File Offset: 0x000512E2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004A04 RID: 18948
		' (get) Token: 0x0600B98F RID: 47503 RVA: 0x000530EB File Offset: 0x000512EB
		' (set) Token: 0x0600B990 RID: 47504 RVA: 0x000530F5 File Offset: 0x000512F5
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004A05 RID: 18949
		' (get) Token: 0x0600B991 RID: 47505 RVA: 0x000530FE File Offset: 0x000512FE
		' (set) Token: 0x0600B992 RID: 47506 RVA: 0x00053108 File Offset: 0x00051308
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004A06 RID: 18950
		' (get) Token: 0x0600B993 RID: 47507 RVA: 0x00053111 File Offset: 0x00051311
		' (set) Token: 0x0600B994 RID: 47508 RVA: 0x0005311B File Offset: 0x0005131B
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17004A07 RID: 18951
		' (get) Token: 0x0600B995 RID: 47509 RVA: 0x00053124 File Offset: 0x00051324
		' (set) Token: 0x0600B996 RID: 47510 RVA: 0x0005312E File Offset: 0x0005132E
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17004A08 RID: 18952
		' (get) Token: 0x0600B997 RID: 47511 RVA: 0x00053137 File Offset: 0x00051337
		' (set) Token: 0x0600B998 RID: 47512 RVA: 0x00053141 File Offset: 0x00051341
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17004A09 RID: 18953
		' (get) Token: 0x0600B999 RID: 47513 RVA: 0x0005314A File Offset: 0x0005134A
		' (set) Token: 0x0600B99A RID: 47514 RVA: 0x00053154 File Offset: 0x00051354
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17004A0A RID: 18954
		' (get) Token: 0x0600B99B RID: 47515 RVA: 0x0005315D File Offset: 0x0005135D
		' (set) Token: 0x0600B99C RID: 47516 RVA: 0x00053167 File Offset: 0x00051367
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17004A0B RID: 18955
		' (get) Token: 0x0600B99D RID: 47517 RVA: 0x00053170 File Offset: 0x00051370
		' (set) Token: 0x0600B99E RID: 47518 RVA: 0x0005317A File Offset: 0x0005137A
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17004A0C RID: 18956
		' (get) Token: 0x0600B99F RID: 47519 RVA: 0x00053183 File Offset: 0x00051383
		' (set) Token: 0x0600B9A0 RID: 47520 RVA: 0x0005318D File Offset: 0x0005138D
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004A0D RID: 18957
		' (get) Token: 0x0600B9A1 RID: 47521 RVA: 0x00053196 File Offset: 0x00051396
		' (set) Token: 0x0600B9A2 RID: 47522 RVA: 0x000531A0 File Offset: 0x000513A0
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004A0E RID: 18958
		' (get) Token: 0x0600B9A3 RID: 47523 RVA: 0x000531A9 File Offset: 0x000513A9
		' (set) Token: 0x0600B9A4 RID: 47524 RVA: 0x000531B3 File Offset: 0x000513B3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004A0F RID: 18959
		' (get) Token: 0x0600B9A5 RID: 47525 RVA: 0x000531BC File Offset: 0x000513BC
		' (set) Token: 0x0600B9A6 RID: 47526 RVA: 0x000531C6 File Offset: 0x000513C6
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004A10 RID: 18960
		' (get) Token: 0x0600B9A7 RID: 47527 RVA: 0x000531CF File Offset: 0x000513CF
		' (set) Token: 0x0600B9A8 RID: 47528 RVA: 0x000531D9 File Offset: 0x000513D9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004A11 RID: 18961
		' (get) Token: 0x0600B9A9 RID: 47529 RVA: 0x000531E2 File Offset: 0x000513E2
		' (set) Token: 0x0600B9AA RID: 47530 RVA: 0x000531EC File Offset: 0x000513EC
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004A12 RID: 18962
		' (get) Token: 0x0600B9AB RID: 47531 RVA: 0x000531F5 File Offset: 0x000513F5
		' (set) Token: 0x0600B9AC RID: 47532 RVA: 0x000531FF File Offset: 0x000513FF
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004A13 RID: 18963
		' (get) Token: 0x0600B9AD RID: 47533 RVA: 0x00053208 File Offset: 0x00051408
		' (set) Token: 0x0600B9AE RID: 47534 RVA: 0x00053212 File Offset: 0x00051412
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004A14 RID: 18964
		' (get) Token: 0x0600B9AF RID: 47535 RVA: 0x0005321B File Offset: 0x0005141B
		' (set) Token: 0x0600B9B0 RID: 47536 RVA: 0x00053225 File Offset: 0x00051425
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004A15 RID: 18965
		' (get) Token: 0x0600B9B1 RID: 47537 RVA: 0x0005322E File Offset: 0x0005142E
		' (set) Token: 0x0600B9B2 RID: 47538 RVA: 0x00776758 File Offset: 0x00774958
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

		' Token: 0x17004A16 RID: 18966
		' (get) Token: 0x0600B9B3 RID: 47539 RVA: 0x00053238 File Offset: 0x00051438
		' (set) Token: 0x0600B9B4 RID: 47540 RVA: 0x0077679C File Offset: 0x0077499C
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

		' Token: 0x17004A17 RID: 18967
		' (get) Token: 0x0600B9B5 RID: 47541 RVA: 0x00053242 File Offset: 0x00051442
		' (set) Token: 0x0600B9B6 RID: 47542 RVA: 0x0005324C File Offset: 0x0005144C
		Friend Overridable Property btnNe As GelButton

		' Token: 0x17004A18 RID: 18968
		' (get) Token: 0x0600B9B7 RID: 47543 RVA: 0x00053255 File Offset: 0x00051455
		' (set) Token: 0x0600B9B8 RID: 47544 RVA: 0x007767E0 File Offset: 0x007749E0
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

		' Token: 0x0600B9B9 RID: 47545 RVA: 0x00776824 File Offset: 0x00774A24
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM BankAccountRegistration"
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

		' Token: 0x0600B9BA RID: 47546 RVA: 0x00776928 File Offset: 0x00774B28
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtAccountName.Text = ""
			Me.txtAccountNo.Text = ""
			Me.cmbAccountType.SelectedIndex = -1
			Me.cmbActive.SelectedIndex = 0
			Me.txtBalanceAmount.Text = ""
			Me.dtpOpeningDate.Value = DateAndTime.Today
			Me.txtContactNo.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtBank.Text = ""
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.auto()
			Me.txtAccountNo.Focus()
		End Sub

		' Token: 0x0600B9BB RID: 47547 RVA: 0x00776A34 File Offset: 0x00774C34
		Public Sub Getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(AccountNo),RTRIM(AccountName),RTRIM(AccountType),Openingdate,BalanceAmount,RTRIM(Active),BranchID,RTRIM(Bank.BankName), RTRIM(BranchName), RTRIM(Address), RTRIM(ContactNo), RTRIM(SwiftCode), RTRIM(IFSCCode),BankAccountRegistration.ID from BankBranch,Bank,BankAccountRegistration where Bank.BankName=BankBranch.BankName and BankBranch.ID=BankAccountRegistration.BranchID order by Bank.BankName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B9BC RID: 47548 RVA: 0x00776BEC File Offset: 0x00774DEC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(BankName), RTRIM(BranchName), RTRIM(Address), RTRIM(ContactNo), RTRIM(SwiftCode), RTRIM(IFSCCode) from BankBranch order by BranchName", ModCommonClasses.con)
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

		' Token: 0x0600B9BD RID: 47549 RVA: 0x00776D28 File Offset: 0x00774F28
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

		' Token: 0x0600B9BE RID: 47550 RVA: 0x00776E10 File Offset: 0x00775010
		Private Sub frmRegistration_Load(sender As Object, e As EventArgs)
			Me.FYSerrch()
			Me.Getdata()
			Me.Getdata1()
			Me.Reset()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600B9BF RID: 47551 RVA: 0x00776EB0 File Offset: 0x007750B0
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

		' Token: 0x0600B9C0 RID: 47552 RVA: 0x00777028 File Offset: 0x00775228
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

		' Token: 0x0600B9C1 RID: 47553 RVA: 0x007770E4 File Offset: 0x007752E4
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

		' Token: 0x0600B9C2 RID: 47554 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600B9C3 RID: 47555 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600B9C4 RID: 47556 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600B9C5 RID: 47557 RVA: 0x007771B0 File Offset: 0x007753B0
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

		' Token: 0x0600B9C6 RID: 47558 RVA: 0x007772A8 File Offset: 0x007754A8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtBranchID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtBank.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBranchName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtSwiftCode.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtIFSCCode.Text = dataGridViewRow.Cells(6).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B9C7 RID: 47559 RVA: 0x00777404 File Offset: 0x00775604
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select BankAc from Invoice_Payment where BankAc=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Sales Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select BankAccount from Stock where BankAccount=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "select BankAcNo from CreditCustomerPayment where BankAcNo=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
						If flag5 Then
							MessageBox.Show("Unable to delete..Already in use in Receipt Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "select BankAc from Contra where BankAc=@d1"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Unable to delete..Already in use in Contra Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "select BankAcN from Payment where BankAcN=@d1"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
								If flag9 Then
									MessageBox.Show("Unable to delete..Already in use in Payment Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag10 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text6 As String = "select BankAcNum from Income where BankAcNum=@d1"
									ModCommonClasses.cmd = New SqlCommand(text6)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
									If flag11 Then
										MessageBox.Show("Unable to delete..Already in use in Income Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag12 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text7 As String = "select BankAcNumber from Voucher where BankAcNumber=@d1"
										ModCommonClasses.cmd = New SqlCommand(text7)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
										If flag13 Then
											MessageBox.Show("Unable to delete..Already in use in Expenses Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag14 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text8 As String = "select BankAccount from EmployeePayment where BankAccount=@d1"
											ModCommonClasses.cmd = New SqlCommand(text8)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
											If flag15 Then
												MessageBox.Show("Unable to delete..Already in use in Employee Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Dim flag16 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag16 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text9 As String = "select AccNo from FundDeposit where AccNo=@d1"
												ModCommonClasses.cmd = New SqlCommand(text9)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag17 As Boolean = ModCommonClasses.rdr.Read()
												If flag17 Then
													MessageBox.Show("Unable to delete..Already in use in Fund Deposit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag18 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag18 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text10 As String = "select AccountFrom from Payment_Withdraw where AccountFrom=@d1"
													ModCommonClasses.cmd = New SqlCommand(text10)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag19 As Boolean = ModCommonClasses.rdr.Read()
													If flag19 Then
														MessageBox.Show("Unable to delete..Already in use in Fund Withdrawal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Dim flag20 As Boolean = ModCommonClasses.rdr IsNot Nothing
														If flag20 Then
															ModCommonClasses.rdr.Close()
														End If
													Else
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text11 As String = "select AccountTransFrom from FundTransfer where AccountTransFrom=@d1"
														ModCommonClasses.cmd = New SqlCommand(text11)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag21 As Boolean = ModCommonClasses.rdr.Read()
														If flag21 Then
															MessageBox.Show("Unable to delete..Already in use in Fund Transfer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
															Dim flag22 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag22 Then
																ModCommonClasses.rdr.Close()
															End If
														Else
															ModCommonClasses.con.Close()
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text12 As String = "select AccountTransTo from FundTransfer where AccountTransTo=@d1"
															ModCommonClasses.cmd = New SqlCommand(text12)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag23 As Boolean = ModCommonClasses.rdr.Read()
															If flag23 Then
																MessageBox.Show("Unable to delete..Already in use in Fund Transfer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Dim flag24 As Boolean = ModCommonClasses.rdr IsNot Nothing
																If flag24 Then
																	ModCommonClasses.rdr.Close()
																End If
															Else
																ModCommonClasses.con.Close()
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text13 As String = "select BankAcc from Journal where BankAcc=@d1"
																ModCommonClasses.cmd = New SqlCommand(text13)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
																If flag25 Then
																	MessageBox.Show("Unable to delete..Already in use in Journal Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																	Dim flag26 As Boolean = ModCommonClasses.rdr IsNot Nothing
																	If flag26 Then
																		ModCommonClasses.rdr.Close()
																	End If
																Else
																	ModCommonClasses.con.Close()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text14 As String = "delete from BankAccountRegistration where AccountNo=@d1"
																	ModCommonClasses.cmd = New SqlCommand(text14)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
																	Dim flag27 As Boolean = num > 0
																	If flag27 Then
																		Dim text15 As String = String.Concat(New String() { "deleted the Bank account registration having account no. '", Me.txtAccountNo.Text, "' and Bank Name '", Me.txtBank.Text, "'" })
																		ModFunc.LogFunc(Me.lblUser.Text, text15)
																		ModFunc.BankAccountLedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Opening Balance")
																		ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "A/c Opening Balance")
																		MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																		Me.Getdata1()
																		Me.Reset()
																	Else
																		MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																		Me.Reset()
																	End If
																	Dim flag28 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
																	If flag28 Then
																		ModCommonClasses.con.Close()
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
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

		' Token: 0x0600B9C8 RID: 47560 RVA: 0x00777F3C File Offset: 0x0077613C
		Private Sub txtBalanceAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtBalanceAmount.Text
					Dim selectionStart As Integer = Me.txtBalanceAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtBalanceAmount.SelectionLength
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

		' Token: 0x0600B9C9 RID: 47561 RVA: 0x00778034 File Offset: 0x00776234
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtAccNo.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtAccountNo.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtAccountName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.cmbAccountType.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.dtpOpeningDate.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBalanceAmount.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbActive.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtBranchID.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.txtBank.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.txtBranchName.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtAddress.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.txtSwiftCode.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.txtIFSCCode.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.txtID.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B9CA RID: 47562 RVA: 0x007782E0 File Offset: 0x007764E0
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

		' Token: 0x0600B9CB RID: 47563 RVA: 0x007783C8 File Offset: 0x007765C8
		Private Sub dtpOpeningDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpOpeningDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpOpeningDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpOpeningDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpOpeningDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600B9CC RID: 47564 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9CD RID: 47565 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9CE RID: 47566 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9CF RID: 47567 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpOpeningDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9D0 RID: 47568 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBalanceAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9D1 RID: 47569 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbActive_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B9D2 RID: 47570 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBankAccountRegistration_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B9D3 RID: 47571 RVA: 0x00778468 File Offset: 0x00776668
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtBalanceAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtBalanceAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBalanceAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtAccountNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtAccountNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAccountNo, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtAccountName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtAccountName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAccountName, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.cmbActive.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.cmbActive, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbActive, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbAccountType.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbAccountType, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAccountType, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.txtBank.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.txtBank, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBank, String.Empty)
			End If
		End Sub

		' Token: 0x0600B9D4 RID: 47572 RVA: 0x00778644 File Offset: 0x00776844
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtAccountNo.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAccountNo.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAccountName.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter account name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAccountName.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.cmbAccountType.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please select account type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbAccountType.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtBalanceAmount.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please enter balance amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtBalanceAmount.Focus()
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.txtBank.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Please enter bank name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.dgw.Focus()
								Else
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "select AccountNo from BankAccountRegistration where AccountNo=@d1"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccountNo.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
										If flag8 Then
											MessageBox.Show("Account No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Me.txtAccountNo.Text = ""
											Me.txtAccountNo.Focus()
											Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag9 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											Me.auto()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text3 As String = "insert into BankAccountRegistration(AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID,ID) VALUES (@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
											ModCommonClasses.cmd = New SqlCommand(text3)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAccountNo.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtAccountName.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbAccountType.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpOpeningDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtBalanceAmount.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cmbActive.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtBranchID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
											Dim text4 As String = String.Concat(New String() { "added the new Bank account having account no. '", Me.txtAccountNo.Text, "' and Bank Name '", Me.txtBank.Text, "'" })
											ModFunc.LogFunc(Me.lblUser.Text, text4)
											Dim flag10 As Boolean = Conversion.Val(Me.txtBalanceAmount.Text) > 0.0
											If flag10 Then
												ModFunc.BankAccountLedgerSave(Me.dtpOpeningDate.Value.[Date], Me.txtAccountNo.Text, Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtBalanceAmount.Text)))
												ModFunc.LedgerSave(Me.dtpOpeningDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "A/c Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtBalanceAmount.Text)), Me.txtAccountNo.Text, Me.txtAccountName.Text)
											End If
											MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.btnSave.Enabled = False
											Me.Getdata1()
										End If
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600B9D5 RID: 47573 RVA: 0x00778C38 File Offset: 0x00776E38
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtAccountNo.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtAccountNo.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtAccountName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter account name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAccountName.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.cmbAccountType.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please select account type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbAccountType.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.txtBalanceAmount.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please enter balance amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtBalanceAmount.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtBank.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter bank name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.dgw.Focus()
							Else
								Try
									Dim flag6 As Boolean = Operators.CompareString(Me.txtAccountNo.Text, Me.txtAccNo.Text, False) <> 0
									If flag6 Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text As String = "select AccountNo from BankAccountRegistration where AccountNo=@d1"
										ModCommonClasses.cmd = New SqlCommand(text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccountNo.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
										If flag7 Then
											MessageBox.Show("Account No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Me.txtAccountNo.Text = ""
											Me.txtAccountNo.Focus()
											Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag8 Then
												ModCommonClasses.rdr.Close()
											End If
											Return
										End If
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "update FundTransfer set AccountTransfrom=@d1 where AccountTransfrom=@d2"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccountNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAccNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "update FundTransfer set AccountTransTo=@d1 where AccountTransTo=@d2"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccountNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAccNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "Update BankAccountRegistration set  AccountNo=@d2, AccountName=@d3, AccountType=@d4, OpeningDate=@d5, BalanceAmount=@d6, Active=@d7, BranchID=@d8 where AccountNo=@d1"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAccNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAccountNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtAccountName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbAccountType.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpOpeningDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtBalanceAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cmbActive.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtBranchID.Text))
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim text5 As String = String.Concat(New String() { "updated the Bank account registration details having account no. '", Me.txtAccountNo.Text, "' and Bank Name '", Me.txtBank.Text, "'" })
									ModFunc.LogFunc(Me.lblUser.Text, text5)
									Dim flag9 As Boolean = Conversion.Val(Me.txtBalanceAmount.Text) > 0.0
									If flag9 Then
										ModFunc.BankAccountLedgerUpdate(Me.dtpOpeningDate.Value.[Date], Me.txtAccountNo.Text, 0D, New Decimal(Conversion.Val(Me.txtBalanceAmount.Text)), Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Opening Balance")
										ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "A/c Opening Balance")
										ModFunc.LedgerSave(Me.dtpOpeningDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "A/c Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtBalanceAmount.Text)), Me.txtAccountNo.Text, Me.txtAccountName.Text)
									End If
									MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnUpdate.Enabled = False
									Me.Getdata1()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600B9D6 RID: 47574 RVA: 0x007792EC File Offset: 0x007774EC
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
	End Class
End Namespace
