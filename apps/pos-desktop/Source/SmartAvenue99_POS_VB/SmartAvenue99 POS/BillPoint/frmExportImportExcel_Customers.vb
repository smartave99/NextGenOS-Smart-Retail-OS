Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002A1 RID: 673
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_Customers
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AC2E RID: 44078 RVA: 0x000502F6 File Offset: 0x0004E4F6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_Customers_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_Customers_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004297 RID: 17047
		' (get) Token: 0x0600AC31 RID: 44081 RVA: 0x00050328 File Offset: 0x0004E528
		' (set) Token: 0x0600AC32 RID: 44082 RVA: 0x00050332 File Offset: 0x0004E532
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004298 RID: 17048
		' (get) Token: 0x0600AC33 RID: 44083 RVA: 0x0005033B File Offset: 0x0004E53B
		' (set) Token: 0x0600AC34 RID: 44084 RVA: 0x00733034 File Offset: 0x00731234
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004299 RID: 17049
		' (get) Token: 0x0600AC35 RID: 44085 RVA: 0x00050345 File Offset: 0x0004E545
		' (set) Token: 0x0600AC36 RID: 44086 RVA: 0x0005034F File Offset: 0x0004E54F
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700429A RID: 17050
		' (get) Token: 0x0600AC37 RID: 44087 RVA: 0x00050358 File Offset: 0x0004E558
		' (set) Token: 0x0600AC38 RID: 44088 RVA: 0x00733078 File Offset: 0x00731278
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700429B RID: 17051
		' (get) Token: 0x0600AC39 RID: 44089 RVA: 0x00050362 File Offset: 0x0004E562
		' (set) Token: 0x0600AC3A RID: 44090 RVA: 0x0005036C File Offset: 0x0004E56C
		Friend Overridable Property Label2 As Label

		' Token: 0x1700429C RID: 17052
		' (get) Token: 0x0600AC3B RID: 44091 RVA: 0x00050375 File Offset: 0x0004E575
		' (set) Token: 0x0600AC3C RID: 44092 RVA: 0x0005037F File Offset: 0x0004E57F
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700429D RID: 17053
		' (get) Token: 0x0600AC3D RID: 44093 RVA: 0x00050388 File Offset: 0x0004E588
		' (set) Token: 0x0600AC3E RID: 44094 RVA: 0x007330BC File Offset: 0x007312BC
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700429E RID: 17054
		' (get) Token: 0x0600AC3F RID: 44095 RVA: 0x00050392 File Offset: 0x0004E592
		' (set) Token: 0x0600AC40 RID: 44096 RVA: 0x0005039C File Offset: 0x0004E59C
		Friend Overridable Property Label3 As Label

		' Token: 0x1700429F RID: 17055
		' (get) Token: 0x0600AC41 RID: 44097 RVA: 0x000503A5 File Offset: 0x0004E5A5
		' (set) Token: 0x0600AC42 RID: 44098 RVA: 0x000503AF File Offset: 0x0004E5AF
		Friend Overridable Property Label1 As Label

		' Token: 0x170042A0 RID: 17056
		' (get) Token: 0x0600AC43 RID: 44099 RVA: 0x000503B8 File Offset: 0x0004E5B8
		' (set) Token: 0x0600AC44 RID: 44100 RVA: 0x00733100 File Offset: 0x00731300
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

		' Token: 0x170042A1 RID: 17057
		' (get) Token: 0x0600AC45 RID: 44101 RVA: 0x000503C2 File Offset: 0x0004E5C2
		' (set) Token: 0x0600AC46 RID: 44102 RVA: 0x00733144 File Offset: 0x00731344
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
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042A2 RID: 17058
		' (get) Token: 0x0600AC47 RID: 44103 RVA: 0x000503CC File Offset: 0x0004E5CC
		' (set) Token: 0x0600AC48 RID: 44104 RVA: 0x00733188 File Offset: 0x00731388
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

		' Token: 0x170042A3 RID: 17059
		' (get) Token: 0x0600AC49 RID: 44105 RVA: 0x000503D6 File Offset: 0x0004E5D6
		' (set) Token: 0x0600AC4A RID: 44106 RVA: 0x000503E0 File Offset: 0x0004E5E0
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x170042A4 RID: 17060
		' (get) Token: 0x0600AC4B RID: 44107 RVA: 0x000503E9 File Offset: 0x0004E5E9
		' (set) Token: 0x0600AC4C RID: 44108 RVA: 0x000503F3 File Offset: 0x0004E5F3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170042A5 RID: 17061
		' (get) Token: 0x0600AC4D RID: 44109 RVA: 0x000503FC File Offset: 0x0004E5FC
		' (set) Token: 0x0600AC4E RID: 44110 RVA: 0x007331CC File Offset: 0x007313CC
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170042A6 RID: 17062
		' (get) Token: 0x0600AC4F RID: 44111 RVA: 0x00050406 File Offset: 0x0004E606
		' (set) Token: 0x0600AC50 RID: 44112 RVA: 0x00733210 File Offset: 0x00731410
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170042A7 RID: 17063
		' (get) Token: 0x0600AC51 RID: 44113 RVA: 0x00050410 File Offset: 0x0004E610
		' (set) Token: 0x0600AC52 RID: 44114 RVA: 0x00733254 File Offset: 0x00731454
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

		' Token: 0x170042A8 RID: 17064
		' (get) Token: 0x0600AC53 RID: 44115 RVA: 0x0005041A File Offset: 0x0004E61A
		' (set) Token: 0x0600AC54 RID: 44116 RVA: 0x00733298 File Offset: 0x00731498
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170042A9 RID: 17065
		' (get) Token: 0x0600AC55 RID: 44117 RVA: 0x00050424 File Offset: 0x0004E624
		' (set) Token: 0x0600AC56 RID: 44118 RVA: 0x0005042E File Offset: 0x0004E62E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170042AA RID: 17066
		' (get) Token: 0x0600AC57 RID: 44119 RVA: 0x00050437 File Offset: 0x0004E637
		' (set) Token: 0x0600AC58 RID: 44120 RVA: 0x00050441 File Offset: 0x0004E641
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170042AB RID: 17067
		' (get) Token: 0x0600AC59 RID: 44121 RVA: 0x0005044A File Offset: 0x0004E64A
		' (set) Token: 0x0600AC5A RID: 44122 RVA: 0x00050454 File Offset: 0x0004E654
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170042AC RID: 17068
		' (get) Token: 0x0600AC5B RID: 44123 RVA: 0x0005045D File Offset: 0x0004E65D
		' (set) Token: 0x0600AC5C RID: 44124 RVA: 0x00050467 File Offset: 0x0004E667
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170042AD RID: 17069
		' (get) Token: 0x0600AC5D RID: 44125 RVA: 0x00050470 File Offset: 0x0004E670
		' (set) Token: 0x0600AC5E RID: 44126 RVA: 0x0005047A File Offset: 0x0004E67A
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170042AE RID: 17070
		' (get) Token: 0x0600AC5F RID: 44127 RVA: 0x00050483 File Offset: 0x0004E683
		' (set) Token: 0x0600AC60 RID: 44128 RVA: 0x0005048D File Offset: 0x0004E68D
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170042AF RID: 17071
		' (get) Token: 0x0600AC61 RID: 44129 RVA: 0x00050496 File Offset: 0x0004E696
		' (set) Token: 0x0600AC62 RID: 44130 RVA: 0x000504A0 File Offset: 0x0004E6A0
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170042B0 RID: 17072
		' (get) Token: 0x0600AC63 RID: 44131 RVA: 0x000504A9 File Offset: 0x0004E6A9
		' (set) Token: 0x0600AC64 RID: 44132 RVA: 0x000504B3 File Offset: 0x0004E6B3
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170042B1 RID: 17073
		' (get) Token: 0x0600AC65 RID: 44133 RVA: 0x000504BC File Offset: 0x0004E6BC
		' (set) Token: 0x0600AC66 RID: 44134 RVA: 0x000504C6 File Offset: 0x0004E6C6
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170042B2 RID: 17074
		' (get) Token: 0x0600AC67 RID: 44135 RVA: 0x000504CF File Offset: 0x0004E6CF
		' (set) Token: 0x0600AC68 RID: 44136 RVA: 0x000504D9 File Offset: 0x0004E6D9
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170042B3 RID: 17075
		' (get) Token: 0x0600AC69 RID: 44137 RVA: 0x000504E2 File Offset: 0x0004E6E2
		' (set) Token: 0x0600AC6A RID: 44138 RVA: 0x000504EC File Offset: 0x0004E6EC
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170042B4 RID: 17076
		' (get) Token: 0x0600AC6B RID: 44139 RVA: 0x000504F5 File Offset: 0x0004E6F5
		' (set) Token: 0x0600AC6C RID: 44140 RVA: 0x000504FF File Offset: 0x0004E6FF
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170042B5 RID: 17077
		' (get) Token: 0x0600AC6D RID: 44141 RVA: 0x00050508 File Offset: 0x0004E708
		' (set) Token: 0x0600AC6E RID: 44142 RVA: 0x00050512 File Offset: 0x0004E712
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170042B6 RID: 17078
		' (get) Token: 0x0600AC6F RID: 44143 RVA: 0x0005051B File Offset: 0x0004E71B
		' (set) Token: 0x0600AC70 RID: 44144 RVA: 0x00050525 File Offset: 0x0004E725
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170042B7 RID: 17079
		' (get) Token: 0x0600AC71 RID: 44145 RVA: 0x0005052E File Offset: 0x0004E72E
		' (set) Token: 0x0600AC72 RID: 44146 RVA: 0x00050538 File Offset: 0x0004E738
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170042B8 RID: 17080
		' (get) Token: 0x0600AC73 RID: 44147 RVA: 0x00050541 File Offset: 0x0004E741
		' (set) Token: 0x0600AC74 RID: 44148 RVA: 0x0005054B File Offset: 0x0004E74B
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170042B9 RID: 17081
		' (get) Token: 0x0600AC75 RID: 44149 RVA: 0x00050554 File Offset: 0x0004E754
		' (set) Token: 0x0600AC76 RID: 44150 RVA: 0x0005055E File Offset: 0x0004E75E
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170042BA RID: 17082
		' (get) Token: 0x0600AC77 RID: 44151 RVA: 0x00050567 File Offset: 0x0004E767
		' (set) Token: 0x0600AC78 RID: 44152 RVA: 0x00050571 File Offset: 0x0004E771
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170042BB RID: 17083
		' (get) Token: 0x0600AC79 RID: 44153 RVA: 0x0005057A File Offset: 0x0004E77A
		' (set) Token: 0x0600AC7A RID: 44154 RVA: 0x00050584 File Offset: 0x0004E784
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170042BC RID: 17084
		' (get) Token: 0x0600AC7B RID: 44155 RVA: 0x0005058D File Offset: 0x0004E78D
		' (set) Token: 0x0600AC7C RID: 44156 RVA: 0x00050597 File Offset: 0x0004E797
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170042BD RID: 17085
		' (get) Token: 0x0600AC7D RID: 44157 RVA: 0x000505A0 File Offset: 0x0004E7A0
		' (set) Token: 0x0600AC7E RID: 44158 RVA: 0x000505AA File Offset: 0x0004E7AA
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170042BE RID: 17086
		' (get) Token: 0x0600AC7F RID: 44159 RVA: 0x000505B3 File Offset: 0x0004E7B3
		' (set) Token: 0x0600AC80 RID: 44160 RVA: 0x000505BD File Offset: 0x0004E7BD
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170042BF RID: 17087
		' (get) Token: 0x0600AC81 RID: 44161 RVA: 0x000505C6 File Offset: 0x0004E7C6
		' (set) Token: 0x0600AC82 RID: 44162 RVA: 0x000505D0 File Offset: 0x0004E7D0
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170042C0 RID: 17088
		' (get) Token: 0x0600AC83 RID: 44163 RVA: 0x000505D9 File Offset: 0x0004E7D9
		' (set) Token: 0x0600AC84 RID: 44164 RVA: 0x000505E3 File Offset: 0x0004E7E3
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170042C1 RID: 17089
		' (get) Token: 0x0600AC85 RID: 44165 RVA: 0x000505EC File Offset: 0x0004E7EC
		' (set) Token: 0x0600AC86 RID: 44166 RVA: 0x000505F6 File Offset: 0x0004E7F6
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170042C2 RID: 17090
		' (get) Token: 0x0600AC87 RID: 44167 RVA: 0x000505FF File Offset: 0x0004E7FF
		' (set) Token: 0x0600AC88 RID: 44168 RVA: 0x00050609 File Offset: 0x0004E809
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170042C3 RID: 17091
		' (get) Token: 0x0600AC89 RID: 44169 RVA: 0x00050612 File Offset: 0x0004E812
		' (set) Token: 0x0600AC8A RID: 44170 RVA: 0x0005061C File Offset: 0x0004E81C
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170042C4 RID: 17092
		' (get) Token: 0x0600AC8B RID: 44171 RVA: 0x00050625 File Offset: 0x0004E825
		' (set) Token: 0x0600AC8C RID: 44172 RVA: 0x0005062F File Offset: 0x0004E82F
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x0600AC8D RID: 44173 RVA: 0x007332DC File Offset: 0x007314DC
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Optype),RTRIM(Opbal),RTRIM(Tcs),RTRIM(Limit),RTRIM(Lstatus),RTRIM(Taround),(DiscPer),RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality) from Customer Order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27) })
				End While
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(0).Cells(2).Value, "Cash", False)
					If flag2 Then
						Me.dgw.Rows(0).Visible = False
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC8E RID: 44174 RVA: 0x00733624 File Offset: 0x00731824
		Private Function GetCustomerBalance(ID As String) As String
			Dim stringBuilder As StringBuilder = New StringBuilder()
			Try
				Me.num1 = 0D
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where PartyID=@d1 group By PartyID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", ID)
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.num1 = Conversions.ToDecimal(ModCommonClasses.rdr1.GetValue(0))
					stringBuilder.Append(Me.num1.ToString() + ",")
				Else
					stringBuilder.Append("00,")
				End If
				ModCommonClasses.con.Close()
				Dim flag2 As Boolean = Conversion.Val(Me.num1) >= 0.0
				If flag2 Then
					Me.str = "Cr"
					stringBuilder.Append(Me.str)
				Else
					Dim flag3 As Boolean = Conversion.Val(Decimal.Compare(Me.num1, 0D) < 0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						stringBuilder.Append(Me.str)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return stringBuilder.ToString()
		End Function

		' Token: 0x0600AC8F RID: 44175 RVA: 0x007337D0 File Offset: 0x007319D0
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

		' Token: 0x0600AC90 RID: 44176 RVA: 0x007338B8 File Offset: 0x00731AB8
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Optype),RTRIM(Opbal),RTRIM(Tcs),RTRIM(Limit),RTRIM(Lstatus),RTRIM(Taround),(DiscPer),RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality) from Customer where name like N'%" + Me.txtCustomerName.Text + "%' Order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27) })
				End While
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(0).Cells(2).Value, "Cash", False)
					If flag2 Then
						Me.dgw.Rows(0).Visible = False
					End If
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC91 RID: 44177 RVA: 0x00733C08 File Offset: 0x00731E08
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Optype),RTRIM(Opbal),RTRIM(Tcs),RTRIM(Limit),RTRIM(Lstatus),RTRIM(Taround),(DiscPer),RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality) from Customer where City like N'%" + Me.txtCity.Text + "%' Order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27) })
				End While
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(0).Cells(2).Value, "Cash", False)
					If flag2 Then
						Me.dgw.Rows(0).Visible = False
					End If
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC92 RID: 44178 RVA: 0x00733F58 File Offset: 0x00732158
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.txtCity.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600AC93 RID: 44179 RVA: 0x00050638 File Offset: 0x0004E838
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600AC94 RID: 44180 RVA: 0x00733FAC File Offset: 0x007321AC
		Private Sub frmExportImportExcel_Customers_Load(sender As Object, e As EventArgs)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600AC95 RID: 44181 RVA: 0x0073409C File Offset: 0x0073229C
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

		' Token: 0x0600AC96 RID: 44182 RVA: 0x00734214 File Offset: 0x00732414
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

		' Token: 0x0600AC97 RID: 44183 RVA: 0x007342D0 File Offset: 0x007324D0
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

		' Token: 0x0600AC98 RID: 44184 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600AC99 RID: 44185 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600AC9A RID: 44186 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600AC9B RID: 44187 RVA: 0x0073439C File Offset: 0x0073259C
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

		' Token: 0x0600AC9C RID: 44188 RVA: 0x00734484 File Offset: 0x00732684
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
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
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag2 As Boolean = dataGridViewRow.Index > 0
							If flag2 Then
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
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag3 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Sheet1")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC9D RID: 44189 RVA: 0x00734748 File Offset: 0x00732948
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Sheet1$]", oleDbConnection)
					oleDbConnection.Open()
					Dim dataSet As DataSet = New DataSet()
					oleDbDataAdapter.Fill(dataSet)
					Me.DataGridView1.Visible = True
					Me.DataGridView1.DataSource = dataSet.Tables(0)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC9E RID: 44190 RVA: 0x0073484C File Offset: 0x00732A4C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
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
				Try
					Dim flag3 As Boolean = Me.DataGridView1.RowCount = 0
					If flag3 Then
						MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim num As Integer = Me.DataGridView1.RowCount - 1
						For i As Integer = 0 To num
							Dim flag4 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(0).Value.ToString(), "", False) = 0
							If flag4 Then
								MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num2 As Integer = Me.DataGridView1.RowCount - 1
						For j As Integer = 0 To num2
							Dim flag5 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(j).Cells(1).Value.ToString(), "", False) = 0
							If flag5 Then
								MessageBox.Show("Customer ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num3 As Integer = Me.DataGridView1.RowCount - 1
						For k As Integer = 0 To num3
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(k).Cells(2).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Customer Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num4 As Integer = Me.DataGridView1.RowCount - 1
						For l As Integer = 0 To num4
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(l).Cells(3).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Address Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num5 As Integer = Me.DataGridView1.RowCount - 1
						For m As Integer = 0 To num5
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(m).Cells(4).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("City Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num6 As Integer = Me.DataGridView1.RowCount - 1
						For n As Integer = 0 To num6
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(n).Cells(5).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("State Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num7 As Integer = Me.DataGridView1.RowCount - 1
						For num8 As Integer = 0 To num7
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num8).Cells(7).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("Contact No. Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num9 As Integer = Me.DataGridView1.RowCount - 1
						For num10 As Integer = 0 To num9
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num10).Cells(18).Value.ToString(), "", False) = 0
							If flag11 Then
								MessageBox.Show("Opening Balance Type Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num11 As Integer = Me.DataGridView1.RowCount - 1
						For num12 As Integer = 0 To num11
							Dim flag12 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num12).Cells(19).Value.ToString(), "", False) = 0
							If flag12 Then
								MessageBox.Show("Opening Balance Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num13 As Integer = Me.DataGridView1.RowCount - 1
						For num14 As Integer = 0 To num13
							Dim flag13 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num14).Cells(20).Value.ToString(), "", False) = 0
							If flag13 Then
								MessageBox.Show("TCS Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num15 As Integer = Me.DataGridView1.RowCount - 1
						For num16 As Integer = 0 To num15
							Dim flag14 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num16).Cells(21).Value.ToString(), "", False) = 0
							If flag14 Then
								MessageBox.Show("Credit Limit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num17 As Integer = Me.DataGridView1.RowCount - 1
						For num18 As Integer = 0 To num17
							Dim flag15 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num18).Cells(22).Value.ToString(), "", False) = 0
							If flag15 Then
								MessageBox.Show("Limit Status Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num19 As Integer = Me.DataGridView1.RowCount - 1
						For num20 As Integer = 0 To num19
							Dim flag16 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num20).Cells(23).Value.ToString(), "", False) = 0
							If flag16 Then
								MessageBox.Show("Turn Around Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num21 As Integer = Me.DataGridView1.RowCount - 1
						For num22 As Integer = 0 To num21
							Dim flag17 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num22).Cells(24).Value.ToString(), "", False) = 0
							If flag17 Then
								MessageBox.Show("Disc% on Item Cell Balnk Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num23 As Integer = Me.DataGridView1.RowCount - 1
						For num24 As Integer = 0 To num23
							Dim flag18 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num24).Cells(25).Value.ToString(), "", False) = 0
							If flag18 Then
								MessageBox.Show("Discount Status on Item Cell Balnk Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag19 As Boolean = Not dataGridViewRow.IsNewRow
								If flag19 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select ID from Customer Where ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag20 As Boolean = ModCommonClasses.rdr.Read()
									If flag20 Then
										MessageBox.Show("Same Customer ID detected", "Check", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Return
									End If
									Dim flag21 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag21 Then
										Me.Cursor = Cursors.WaitCursor
										Me.Timer1.Enabled = True
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into Customer(ID,CustomerID,[Name],Address,City,State,ZipCode,ContactNo,EmailID,Remarks,AccountNumber,AccountName,Bank,Branch,IFSCCode,GSTIN,PAN,CIN,Optype,Opbal,Tcs,Limit,Lstatus,Taround,DiscPer,DiscStatus,Photo, OpLoyalitytype, OpbalLoyality) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27, @d28, @d29)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(1).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(2).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells(3).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow.Cells(4).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow.Cells(6).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow.Cells(7).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow.Cells(8).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(10).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells(11).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow.Cells(12).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow.Cells(13).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", dataGridViewRow.Cells(14).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow.Cells(15).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(16).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(17).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", dataGridViewRow.Cells(18).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", dataGridViewRow.Cells(19).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d21", dataGridViewRow.Cells(20).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d22", dataGridViewRow.Cells(21).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d23", dataGridViewRow.Cells(22).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d24", dataGridViewRow.Cells(23).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d25", dataGridViewRow.Cells(24).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d26", dataGridViewRow.Cells(25).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d28", dataGridViewRow.Cells(26).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d29", dataGridViewRow.Cells(27).Value.ToString())
										Dim memoryStream As MemoryStream = New MemoryStream()
										Dim bitmap As Bitmap = New Bitmap(Resources.photo)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim buffer As Byte() = memoryStream.GetBuffer()
										Dim sqlParameter As SqlParameter = New SqlParameter("@d27", SqlDbType.Image)
										sqlParameter.Value = buffer
										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim flag22 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(18).Value.ToString(), "DR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)) > 0.0)
										If flag22 Then
											ModFunc.LedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.CustomerLedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
										Dim flag23 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(18).Value.ToString(), "CR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)) > 0.0)
										If flag23 Then
											ModFunc.LedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.CustomerLedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
										Dim flag24 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(26).Value.ToString(), "DR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value)) > 0.0)
										If flag24 Then
											ModFunc.LedgerSave_Loyality(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(27).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(27).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
										Dim flag25 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(26).Value.ToString(), "CR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value)) > 0.0)
										If flag25 Then
											ModFunc.LedgerSave_Loyality(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(27).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(27).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.DataGridView1.DataSource = Nothing
						Me.Reset()
					End If
				Catch ex As SqlException
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600AC9F RID: 44191 RVA: 0x00050654 File Offset: 0x0004E854
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600ACA0 RID: 44192 RVA: 0x00735DF0 File Offset: 0x00733FF0
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				File.WriteAllBytes(selectedPath + "\Customer_Format.xls", Resources.Customer_Format)
				Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\Customer_Format.xls")
				If flag2 Then
					File.Delete(selectedPath + "\Customer_Format.xls")
					File.WriteAllBytes(selectedPath + "\Customer_Format.xls", Resources.Customer_Format)
					MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600ACA1 RID: 44193 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExportImportExcel_Customers_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400483D RID: 18493
		Private num1 As Decimal

		' Token: 0x0400483E RID: 18494
		Private num2 As Decimal

		' Token: 0x0400483F RID: 18495
		Private num3 As Decimal

		' Token: 0x04004840 RID: 18496
		Private str As String
	End Class
End Namespace
