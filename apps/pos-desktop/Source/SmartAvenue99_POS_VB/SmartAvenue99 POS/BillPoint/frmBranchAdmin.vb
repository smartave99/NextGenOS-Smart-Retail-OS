Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Namespace BillPoint
	' Token: 0x020005FF RID: 1535
	<DesignerGenerated()>
	Public Partial Class frmBranchAdmin
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012ADB RID: 76507 RVA: 0x0007F8D8 File Offset: 0x0007DAD8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBranchAdmin_Load
			Me.keyLength = 12
			Me.InitializeComponent()
		End Sub

		' Token: 0x170073D8 RID: 29656
		' (get) Token: 0x06012ADE RID: 76510 RVA: 0x0007F903 File Offset: 0x0007DB03
		' (set) Token: 0x06012ADF RID: 76511 RVA: 0x0007F90D File Offset: 0x0007DB0D
		Friend Overridable Property lblUserType As Label

		' Token: 0x170073D9 RID: 29657
		' (get) Token: 0x06012AE0 RID: 76512 RVA: 0x0007F916 File Offset: 0x0007DB16
		' (set) Token: 0x06012AE1 RID: 76513 RVA: 0x0007F920 File Offset: 0x0007DB20
		Friend Overridable Property lblUser As Label

		' Token: 0x170073DA RID: 29658
		' (get) Token: 0x06012AE2 RID: 76514 RVA: 0x0007F929 File Offset: 0x0007DB29
		' (set) Token: 0x06012AE3 RID: 76515 RVA: 0x0007F933 File Offset: 0x0007DB33
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170073DB RID: 29659
		' (get) Token: 0x06012AE4 RID: 76516 RVA: 0x0007F93C File Offset: 0x0007DB3C
		' (set) Token: 0x06012AE5 RID: 76517 RVA: 0x0007F946 File Offset: 0x0007DB46
		Friend Overridable Property txtBAddress As TextBox

		' Token: 0x170073DC RID: 29660
		' (get) Token: 0x06012AE6 RID: 76518 RVA: 0x0007F94F File Offset: 0x0007DB4F
		' (set) Token: 0x06012AE7 RID: 76519 RVA: 0x0007F959 File Offset: 0x0007DB59
		Friend Overridable Property Label3 As Label

		' Token: 0x170073DD RID: 29661
		' (get) Token: 0x06012AE8 RID: 76520 RVA: 0x0007F962 File Offset: 0x0007DB62
		' (set) Token: 0x06012AE9 RID: 76521 RVA: 0x0007F96C File Offset: 0x0007DB6C
		Friend Overridable Property txtBMobile As TextBox

		' Token: 0x170073DE RID: 29662
		' (get) Token: 0x06012AEA RID: 76522 RVA: 0x0007F975 File Offset: 0x0007DB75
		' (set) Token: 0x06012AEB RID: 76523 RVA: 0x0007F97F File Offset: 0x0007DB7F
		Friend Overridable Property Label4 As Label

		' Token: 0x170073DF RID: 29663
		' (get) Token: 0x06012AEC RID: 76524 RVA: 0x0007F988 File Offset: 0x0007DB88
		' (set) Token: 0x06012AED RID: 76525 RVA: 0x0007F992 File Offset: 0x0007DB92
		Friend Overridable Property txtBName As TextBox

		' Token: 0x170073E0 RID: 29664
		' (get) Token: 0x06012AEE RID: 76526 RVA: 0x0007F99B File Offset: 0x0007DB9B
		' (set) Token: 0x06012AEF RID: 76527 RVA: 0x0007F9A5 File Offset: 0x0007DBA5
		Friend Overridable Property Label2 As Label

		' Token: 0x170073E1 RID: 29665
		' (get) Token: 0x06012AF0 RID: 76528 RVA: 0x0007F9AE File Offset: 0x0007DBAE
		' (set) Token: 0x06012AF1 RID: 76529 RVA: 0x0007F9B8 File Offset: 0x0007DBB8
		Friend Overridable Property txtAdminCode As TextBox

		' Token: 0x170073E2 RID: 29666
		' (get) Token: 0x06012AF2 RID: 76530 RVA: 0x0007F9C1 File Offset: 0x0007DBC1
		' (set) Token: 0x06012AF3 RID: 76531 RVA: 0x00ABC9D8 File Offset: 0x00ABABD8
		Private _btnprint As GelButton
		Friend Overridable Property btnprint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnprint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnprint_Click
				Dim gelButton As GelButton = Me._btnprint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnprint = value
				gelButton = Me._btnprint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170073E3 RID: 29667
		' (get) Token: 0x06012AF4 RID: 76532 RVA: 0x0007F9CB File Offset: 0x0007DBCB
		' (set) Token: 0x06012AF5 RID: 76533 RVA: 0x00ABCA1C File Offset: 0x00ABAC1C
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

		' Token: 0x170073E4 RID: 29668
		' (get) Token: 0x06012AF6 RID: 76534 RVA: 0x0007F9D5 File Offset: 0x0007DBD5
		' (set) Token: 0x06012AF7 RID: 76535 RVA: 0x00ABCA60 File Offset: 0x00ABAC60
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

		' Token: 0x170073E5 RID: 29669
		' (get) Token: 0x06012AF8 RID: 76536 RVA: 0x0007F9DF File Offset: 0x0007DBDF
		' (set) Token: 0x06012AF9 RID: 76537 RVA: 0x00ABCAA4 File Offset: 0x00ABACA4
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170073E6 RID: 29670
		' (get) Token: 0x06012AFA RID: 76538 RVA: 0x0007F9E9 File Offset: 0x0007DBE9
		' (set) Token: 0x06012AFB RID: 76539 RVA: 0x0007F9F3 File Offset: 0x0007DBF3
		Friend Overridable Property Label1 As Label

		' Token: 0x170073E7 RID: 29671
		' (get) Token: 0x06012AFC RID: 76540 RVA: 0x0007F9FC File Offset: 0x0007DBFC
		' (set) Token: 0x06012AFD RID: 76541 RVA: 0x0007FA06 File Offset: 0x0007DC06
		Friend Overridable Property Label5 As Label

		' Token: 0x170073E8 RID: 29672
		' (get) Token: 0x06012AFE RID: 76542 RVA: 0x0007FA0F File Offset: 0x0007DC0F
		' (set) Token: 0x06012AFF RID: 76543 RVA: 0x0007FA19 File Offset: 0x0007DC19
		Friend Overridable Property cmbSearchType As ComboBox

		' Token: 0x170073E9 RID: 29673
		' (get) Token: 0x06012B00 RID: 76544 RVA: 0x0007FA22 File Offset: 0x0007DC22
		' (set) Token: 0x06012B01 RID: 76545 RVA: 0x00ABCAE8 File Offset: 0x00ABACE8
		Private _txtSearchData As TextBox
		Friend Overridable Property txtSearchData As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearch_KeyDown
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.txtSearch_KeyDown
				Dim textBox As TextBox = Me._txtSearchData
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler2
				End If
				Me._txtSearchData = value
				textBox = Me._txtSearchData
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170073EA RID: 29674
		' (get) Token: 0x06012B02 RID: 76546 RVA: 0x0007FA2C File Offset: 0x0007DC2C
		' (set) Token: 0x06012B03 RID: 76547 RVA: 0x0007FA36 File Offset: 0x0007DC36
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170073EB RID: 29675
		' (get) Token: 0x06012B04 RID: 76548 RVA: 0x0007FA3F File Offset: 0x0007DC3F
		' (set) Token: 0x06012B05 RID: 76549 RVA: 0x0007FA49 File Offset: 0x0007DC49
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170073EC RID: 29676
		' (get) Token: 0x06012B06 RID: 76550 RVA: 0x0007FA52 File Offset: 0x0007DC52
		' (set) Token: 0x06012B07 RID: 76551 RVA: 0x0007FA5C File Offset: 0x0007DC5C
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170073ED RID: 29677
		' (get) Token: 0x06012B08 RID: 76552 RVA: 0x0007FA65 File Offset: 0x0007DC65
		' (set) Token: 0x06012B09 RID: 76553 RVA: 0x0007FA6F File Offset: 0x0007DC6F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170073EE RID: 29678
		' (get) Token: 0x06012B0A RID: 76554 RVA: 0x0007FA78 File Offset: 0x0007DC78
		' (set) Token: 0x06012B0B RID: 76555 RVA: 0x00ABCB48 File Offset: 0x00ABAD48
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

		' Token: 0x170073EF RID: 29679
		' (get) Token: 0x06012B0C RID: 76556 RVA: 0x0007FA82 File Offset: 0x0007DC82
		' (set) Token: 0x06012B0D RID: 76557 RVA: 0x0007FA8C File Offset: 0x0007DC8C
		Friend Overridable Property txtBranchData As TextBox

		' Token: 0x170073F0 RID: 29680
		' (get) Token: 0x06012B0E RID: 76558 RVA: 0x0007FA95 File Offset: 0x0007DC95
		' (set) Token: 0x06012B0F RID: 76559 RVA: 0x0007FA9F File Offset: 0x0007DC9F
		Friend Overridable Property cmbBranch As ComboBox

		' Token: 0x170073F1 RID: 29681
		' (get) Token: 0x06012B10 RID: 76560 RVA: 0x0007FAA8 File Offset: 0x0007DCA8
		' (set) Token: 0x06012B11 RID: 76561 RVA: 0x00ABCB8C File Offset: 0x00ABAD8C
		Private _btnBranch As GelButton
		Friend Overridable Property btnBranch As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnBranch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnBranch_Click
				Dim gelButton As GelButton = Me._btnBranch
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnBranch = value
				gelButton = Me._btnBranch
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170073F2 RID: 29682
		' (get) Token: 0x06012B12 RID: 76562 RVA: 0x0007FAB2 File Offset: 0x0007DCB2
		' (set) Token: 0x06012B13 RID: 76563 RVA: 0x00ABCBD0 File Offset: 0x00ABADD0
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170073F3 RID: 29683
		' (get) Token: 0x06012B14 RID: 76564 RVA: 0x0007FABC File Offset: 0x0007DCBC
		' (set) Token: 0x06012B15 RID: 76565 RVA: 0x0007FAC6 File Offset: 0x0007DCC6
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170073F4 RID: 29684
		' (get) Token: 0x06012B16 RID: 76566 RVA: 0x0007FACF File Offset: 0x0007DCCF
		' (set) Token: 0x06012B17 RID: 76567 RVA: 0x0007FAD9 File Offset: 0x0007DCD9
		Friend Overridable Property cone As DataGridViewTextBoxColumn

		' Token: 0x170073F5 RID: 29685
		' (get) Token: 0x06012B18 RID: 76568 RVA: 0x0007FAE2 File Offset: 0x0007DCE2
		' (set) Token: 0x06012B19 RID: 76569 RVA: 0x0007FAEC File Offset: 0x0007DCEC
		Friend Overridable Property ctwo As DataGridViewTextBoxColumn

		' Token: 0x170073F6 RID: 29686
		' (get) Token: 0x06012B1A RID: 76570 RVA: 0x0007FAF5 File Offset: 0x0007DCF5
		' (set) Token: 0x06012B1B RID: 76571 RVA: 0x0007FAFF File Offset: 0x0007DCFF
		Friend Overridable Property cthree As DataGridViewTextBoxColumn

		' Token: 0x170073F7 RID: 29687
		' (get) Token: 0x06012B1C RID: 76572 RVA: 0x0007FB08 File Offset: 0x0007DD08
		' (set) Token: 0x06012B1D RID: 76573 RVA: 0x0007FB12 File Offset: 0x0007DD12
		Friend Overridable Property cfour As DataGridViewTextBoxColumn

		' Token: 0x170073F8 RID: 29688
		' (get) Token: 0x06012B1E RID: 76574 RVA: 0x0007FB1B File Offset: 0x0007DD1B
		' (set) Token: 0x06012B1F RID: 76575 RVA: 0x0007FB25 File Offset: 0x0007DD25
		Friend Overridable Property cfive As DataGridViewTextBoxColumn

		' Token: 0x170073F9 RID: 29689
		' (get) Token: 0x06012B20 RID: 76576 RVA: 0x0007FB2E File Offset: 0x0007DD2E
		' (set) Token: 0x06012B21 RID: 76577 RVA: 0x0007FB38 File Offset: 0x0007DD38
		Friend Overridable Property csix As DataGridViewTextBoxColumn

		' Token: 0x170073FA RID: 29690
		' (get) Token: 0x06012B22 RID: 76578 RVA: 0x0007FB41 File Offset: 0x0007DD41
		' (set) Token: 0x06012B23 RID: 76579 RVA: 0x0007FB4B File Offset: 0x0007DD4B
		Friend Overridable Property cseven As DataGridViewTextBoxColumn

		' Token: 0x170073FB RID: 29691
		' (get) Token: 0x06012B24 RID: 76580 RVA: 0x0007FB54 File Offset: 0x0007DD54
		' (set) Token: 0x06012B25 RID: 76581 RVA: 0x0007FB5E File Offset: 0x0007DD5E
		Friend Overridable Property ceight As DataGridViewTextBoxColumn

		' Token: 0x170073FC RID: 29692
		' (get) Token: 0x06012B26 RID: 76582 RVA: 0x0007FB67 File Offset: 0x0007DD67
		' (set) Token: 0x06012B27 RID: 76583 RVA: 0x0007FB71 File Offset: 0x0007DD71
		Friend Overridable Property cnine As DataGridViewTextBoxColumn

		' Token: 0x170073FD RID: 29693
		' (get) Token: 0x06012B28 RID: 76584 RVA: 0x0007FB7A File Offset: 0x0007DD7A
		' (set) Token: 0x06012B29 RID: 76585 RVA: 0x00ABCC14 File Offset: 0x00ABAE14
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

		' Token: 0x170073FE RID: 29694
		' (get) Token: 0x06012B2A RID: 76586 RVA: 0x0007FB84 File Offset: 0x0007DD84
		' (set) Token: 0x06012B2B RID: 76587 RVA: 0x0007FB8E File Offset: 0x0007DD8E
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170073FF RID: 29695
		' (get) Token: 0x06012B2C RID: 76588 RVA: 0x0007FB97 File Offset: 0x0007DD97
		' (set) Token: 0x06012B2D RID: 76589 RVA: 0x0007FBA1 File Offset: 0x0007DDA1
		Friend Overridable Property txtBranchAddress As TextBox

		' Token: 0x17007400 RID: 29696
		' (get) Token: 0x06012B2E RID: 76590 RVA: 0x0007FBAA File Offset: 0x0007DDAA
		' (set) Token: 0x06012B2F RID: 76591 RVA: 0x0007FBB4 File Offset: 0x0007DDB4
		Friend Overridable Property Label10 As Label

		' Token: 0x17007401 RID: 29697
		' (get) Token: 0x06012B30 RID: 76592 RVA: 0x0007FBBD File Offset: 0x0007DDBD
		' (set) Token: 0x06012B31 RID: 76593 RVA: 0x0007FBC7 File Offset: 0x0007DDC7
		Friend Overridable Property txtBranchState As TextBox

		' Token: 0x17007402 RID: 29698
		' (get) Token: 0x06012B32 RID: 76594 RVA: 0x0007FBD0 File Offset: 0x0007DDD0
		' (set) Token: 0x06012B33 RID: 76595 RVA: 0x0007FBDA File Offset: 0x0007DDDA
		Friend Overridable Property Label6 As Label

		' Token: 0x17007403 RID: 29699
		' (get) Token: 0x06012B34 RID: 76596 RVA: 0x0007FBE3 File Offset: 0x0007DDE3
		' (set) Token: 0x06012B35 RID: 76597 RVA: 0x0007FBED File Offset: 0x0007DDED
		Friend Overridable Property txtBranchName As TextBox

		' Token: 0x17007404 RID: 29700
		' (get) Token: 0x06012B36 RID: 76598 RVA: 0x0007FBF6 File Offset: 0x0007DDF6
		' (set) Token: 0x06012B37 RID: 76599 RVA: 0x0007FC00 File Offset: 0x0007DE00
		Friend Overridable Property Label7 As Label

		' Token: 0x17007405 RID: 29701
		' (get) Token: 0x06012B38 RID: 76600 RVA: 0x0007FC09 File Offset: 0x0007DE09
		' (set) Token: 0x06012B39 RID: 76601 RVA: 0x0007FC13 File Offset: 0x0007DE13
		Friend Overridable Property txtAdminCodeBranch As TextBox

		' Token: 0x17007406 RID: 29702
		' (get) Token: 0x06012B3A RID: 76602 RVA: 0x0007FC1C File Offset: 0x0007DE1C
		' (set) Token: 0x06012B3B RID: 76603 RVA: 0x0007FC26 File Offset: 0x0007DE26
		Friend Overridable Property txtBranchCode As TextBox

		' Token: 0x17007407 RID: 29703
		' (get) Token: 0x06012B3C RID: 76604 RVA: 0x0007FC2F File Offset: 0x0007DE2F
		' (set) Token: 0x06012B3D RID: 76605 RVA: 0x0007FC39 File Offset: 0x0007DE39
		Friend Overridable Property Label8 As Label

		' Token: 0x17007408 RID: 29704
		' (get) Token: 0x06012B3E RID: 76606 RVA: 0x0007FC42 File Offset: 0x0007DE42
		' (set) Token: 0x06012B3F RID: 76607 RVA: 0x0007FC4C File Offset: 0x0007DE4C
		Friend Overridable Property Label9 As Label

		' Token: 0x17007409 RID: 29705
		' (get) Token: 0x06012B40 RID: 76608 RVA: 0x0007FC55 File Offset: 0x0007DE55
		' (set) Token: 0x06012B41 RID: 76609 RVA: 0x0007FC5F File Offset: 0x0007DE5F
		Friend Overridable Property Label11 As Label

		' Token: 0x1700740A RID: 29706
		' (get) Token: 0x06012B42 RID: 76610 RVA: 0x0007FC68 File Offset: 0x0007DE68
		' (set) Token: 0x06012B43 RID: 76611 RVA: 0x0007FC72 File Offset: 0x0007DE72
		Friend Overridable Property Label12 As Label

		' Token: 0x06012B44 RID: 76612 RVA: 0x00ABCC58 File Offset: 0x00ABAE58
		Private Sub btnprint_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbSearchType.Text)
			If flag Then
				MessageBox.Show("Please select search type.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSearchType.Focus()
			Else
				Me.SearchInDataGridView()
			End If
		End Sub

		' Token: 0x06012B45 RID: 76613 RVA: 0x00ABCCA4 File Offset: 0x00ABAEA4
		Public Function GenerateRandomAlphaNumericKey(length As Integer) As String
			Dim random As Random = New Random()
			Return New String(Enumerable.Repeat(Of String)("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length).[Select](Function(s As String) s(random.[Next](s.Length))).ToArray())
		End Function

		' Token: 0x06012B46 RID: 76614 RVA: 0x00ABCCF0 File Offset: 0x00ABAEF0
		Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.SearchInDataGridView()
			End If
		End Sub

		' Token: 0x06012B47 RID: 76615 RVA: 0x00ABCD18 File Offset: 0x00ABAF18
		Private Sub SearchInDataGridView()
			Try
				Using mySqlConnection As MySqlConnection = New MySqlConnection(ModCS.ReadCS1())
					mySqlConnection.Open()
					Dim text As String = ""
					Dim text2 As String = Me.txtSearchData.Text
					Select Case Me.cmbSearchType.SelectedIndex
						Case 0
							text = "SELECT admin_code,admin_name, admin_address, admin_mobno FROM branch_admin WHERE admin_code like N'" + text2 + "%' ORDER BY admin_name"
						Case 1
							text = "SELECT admin_code,admin_name, admin_address, admin_mobno FROM branch_admin WHERE admin_name like N'" + text2 + "%' ORDER BY admin_name"
						Case 2
							text = "SELECT admin_code,admin_name, admin_address, admin_mobno FROM branch_admin WHERE admin_mobno like N'" + text2 + "%' ORDER BY admin_name"
						Case 3
							text = "SELECT admin_code,admin_name, admin_address, admin_mobno FROM branch_admin WHERE admin_address like N'" + text2 + "%' ORDER BY admin_name"
					End Select
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text, mySqlConnection)
						mySqlCommand.Parameters.AddWithValue(text2, Me.txtSearchData.Text + "%")
						mySqlCommand.CommandTimeout = 0
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.dgw.Rows.Clear()
							While mySqlDataReader.Read()
								Me.dgw.Rows.Add(New Object() { mySqlDataReader(0), mySqlDataReader(1), mySqlDataReader(2), mySqlDataReader(3) })
							End While
						End Using
					End Using
				End Using
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B48 RID: 76616 RVA: 0x00ABCF30 File Offset: 0x00ABB130
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim text As String = ModCS.ReadCS1()
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtBName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Branch Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtBName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtBAddress.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter Address ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBAddress.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtBMobile.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter Mobile Number ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBMobile.Focus()
					Else
						Dim mySqlConnection As MySqlConnection = New MySqlConnection(text)
						Try
							mySqlConnection.Open()
							Dim text2 As String = "INSERT INTO branch_admin(admin_code, admin_address, admin_mobno, admin_name) VALUES (@d1, @d2, @d3, @d4)"
							Dim text3 As String = Me.GenerateRandomAlphaNumericKey(Me.keyLength)
							Dim mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
							mySqlCommand.Parameters.AddWithValue("@d1", text3)
							mySqlCommand.Parameters.AddWithValue("@d2", Me.txtBAddress.Text.TrimEnd(New Char(-1) {}))
							mySqlCommand.Parameters.AddWithValue("@d3", Me.txtBMobile.Text.TrimEnd(New Char(-1) {}))
							mySqlCommand.Parameters.AddWithValue("@d4", Me.txtBName.Text.TrimEnd(New Char(-1) {}))
							Dim num As Integer = mySqlCommand.ExecuteNonQuery()
							MessageBox.Show("Data Saved")
							Me.dgw.Rows.Add(New Object() { text3, Me.txtBAddress.Text, Me.txtBMobile.Text, Me.txtBName.Text })
							Clipboard.SetText(text3)
							Console.WriteLine("Rows affected: " + Conversions.ToString(num))
						Catch ex As MySqlException
							Console.WriteLine("MySQL Error: " + ex.Message)
							Console.WriteLine("MySQL ErrorCode: " + Conversions.ToString(ex.Number))
							Console.WriteLine("Stack Trace: " + ex.StackTrace)
						Finally
							mySqlConnection.Close()
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06012B49 RID: 76617 RVA: 0x0007FC7B File Offset: 0x0007DE7B
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012B4A RID: 76618 RVA: 0x00ABD1D8 File Offset: 0x00ABB3D8
		Public Sub Reset()
			Me.txtAdminCode.Text = ""
			Me.txtBName.Text = ""
			Me.txtBMobile.Text = ""
			Me.txtBAddress.Text = ""
		End Sub

		' Token: 0x06012B4B RID: 76619 RVA: 0x00ABD22C File Offset: 0x00ABB42C
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(e.RowIndex)
					Me.txtAdminCode.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtBName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBAddress.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtBMobile.Text = dataGridViewRow.Cells(3).Value.ToString()
				End If
				Me.btnSave.Enabled = False
				Me.btnUpdate.Enabled = True
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B4C RID: 76620 RVA: 0x00ABD358 File Offset: 0x00ABB558
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAdminCode.Text)
				If flag Then
					MessageBox.Show("Please enter admin code.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAdminCode.Focus()
				Else
					Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtBAddress.Text)
					If flag2 Then
						MessageBox.Show("Please enter address.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBAddress.Focus()
					Else
						Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtBMobile.Text)
						If flag3 Then
							MessageBox.Show("Please enter mobile code.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtBMobile.Focus()
						Else
							Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtBName.Text)
							If flag4 Then
								MessageBox.Show("Please enter branch name.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtBName.Focus()
							Else
								Using mySqlConnection As MySqlConnection = New MySqlConnection(ModCS.ReadCS1())
									mySqlConnection.Open()
									Dim text As String = "UPDATE branch_admin SET admin_address=@d1, admin_mobno=@d2, admin_name=@d3 WHERE admin_code=@adminCode"
									Using mySqlCommand As MySqlCommand = New MySqlCommand(text, mySqlConnection)
										mySqlCommand.Parameters.AddWithValue("@d1", Me.txtBAddress.Text)
										mySqlCommand.Parameters.AddWithValue("@d2", Me.txtBMobile.Text)
										mySqlCommand.Parameters.AddWithValue("@d3", Me.txtBName.Text)
										mySqlCommand.Parameters.AddWithValue("@adminCode", Me.txtAdminCode.Text)
										Dim num As Integer = mySqlCommand.ExecuteNonQuery()
										Dim flag5 As Boolean = num > 0
										If flag5 Then
											ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the admin branch with admin code: '", Me.txtAdminCode.Text, "' and Mobile no. '", Me.txtBMobile.Text, "'" }))
											MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.btnUpdate.Enabled = False
										Else
											MessageBox.Show("No records were updated. Admin code not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										End If
									End Using
								End Using
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B4D RID: 76621 RVA: 0x00ABD624 File Offset: 0x00ABB824
		Private Function GetBranch() As Object
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = Me.txtBranchData.Text
					Dim text3 As String = "SELECT branchcode, admincode, branchname, branchstate,branchaddress,branchmobno,branchcity,branchgst,branchstatus FROM branch"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text3, mySqlConnection)
						mySqlCommand.CommandTimeout = 0
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.DataGridView1.Rows.Clear()
							While mySqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { mySqlDataReader(0), mySqlDataReader(1), mySqlDataReader(2), mySqlDataReader(3), mySqlDataReader(4), mySqlDataReader(5), mySqlDataReader(6), mySqlDataReader(7), mySqlDataReader(8) })
							End While
						End Using
					End Using
				End Using
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012B4E RID: 76622 RVA: 0x00ABD7E8 File Offset: 0x00ABB9E8
		Private Sub frmBranchAdmin_Load(sender As Object, e As EventArgs)
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.Reset()
			Me.txtBranchCode.Text = ""
			Me.txtAdminCodeBranch.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtBranchState.Text = ""
			Me.txtBranchAddress.Text = ""
		End Sub

		' Token: 0x06012B4F RID: 76623 RVA: 0x00ABD86C File Offset: 0x00ABBA6C
		Private Sub SearchInBranch()
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = ""
					Dim text3 As String = Me.txtBranchData.Text
					Dim selectedIndex As Integer = Me.cmbBranch.SelectedIndex
					If selectedIndex <> 0 Then
						If selectedIndex = 1 Then
							text2 = "SELECT  branchcode, admincode, branchname, branchstate,branchaddress,branchmobno,branchcity,branchgst,branchstatus FROM branch WHERE admincode like N'" + text3 + "%' ORDER BY branchname"
						End If
					Else
						text2 = "SELECT branchcode, admincode, branchname, branchstate,branchaddress,branchmobno,branchcity,branchgst,branchstatus FROM branch WHERE branchcode like N'" + text3 + "%' ORDER BY branchname"
					End If
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						mySqlCommand.Parameters.AddWithValue(text3, Me.txtBranchData.Text + "%")
						mySqlCommand.CommandTimeout = 0
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.DataGridView1.Rows.Clear()
							While mySqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { mySqlDataReader(0), mySqlDataReader(1), mySqlDataReader(2), mySqlDataReader(3), mySqlDataReader(4), mySqlDataReader(5), mySqlDataReader(6), mySqlDataReader(7), mySqlDataReader(8) })
							End While
						End Using
					End Using
				End Using
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B50 RID: 76624 RVA: 0x00ABDA90 File Offset: 0x00ABBC90
		Private Sub btnBranch_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbBranch.Text)
			If flag Then
				MessageBox.Show("Please select search type.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbBranch.Focus()
			Else
				Me.SearchInBranch()
			End If
		End Sub

		' Token: 0x06012B51 RID: 76625 RVA: 0x00ABDADC File Offset: 0x00ABBCDC
		Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
					Me.txtBranchCode.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtAdminCodeBranch.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBranchName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtBranchState.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBranchAddress.Text = dataGridViewRow.Cells(4).Value.ToString()
				End If
				Me.GelButton1.Enabled = True
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B52 RID: 76626 RVA: 0x00ABDC1C File Offset: 0x00ABBE1C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = "DELETE FROM branch WHERE admincode = @admincode AND branchcode = @branchcode"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						mySqlCommand.Parameters.AddWithValue("@admincode", Me.txtAdminCodeBranch.Text)
						mySqlCommand.Parameters.AddWithValue("@branchcode", Me.txtBranchCode.Text)
						mySqlCommand.CommandTimeout = 0
						Dim num As Integer = mySqlCommand.ExecuteNonQuery()
						Dim flag As Boolean = num > 0
						If flag Then
							MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.DataGridView1.Rows.Clear()
						Else
							MessageBox.Show("No matching record found for deletion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					End Using
				End Using
				Me.dgw.ClearSelection()
				Me.txtBranchCode.Text = ""
				Me.txtAdminCodeBranch.Text = ""
				Me.txtBranchName.Text = ""
				Me.txtBranchState.Text = ""
				Me.txtBranchAddress.Text = ""
			Catch ex As MySqlException
				MessageBox.Show(String.Format("MySQL Error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Catch ex2 As Exception
				MessageBox.Show(String.Format("Error: {0}", ex2.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04007096 RID: 28822
		Private keyLength As Integer
	End Class
End Namespace
