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
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C9 RID: 1225
	<DesignerGenerated()>
	Public Partial Class frmGSTR1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F65D RID: 63069 RVA: 0x0006BE6D File Offset: 0x0006A06D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTR1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGSTR1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005E36 RID: 24118
		' (get) Token: 0x0600F660 RID: 63072 RVA: 0x0006BE9F File Offset: 0x0006A09F
		' (set) Token: 0x0600F661 RID: 63073 RVA: 0x0006BEA9 File Offset: 0x0006A0A9
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17005E37 RID: 24119
		' (get) Token: 0x0600F662 RID: 63074 RVA: 0x0006BEB2 File Offset: 0x0006A0B2
		' (set) Token: 0x0600F663 RID: 63075 RVA: 0x0006BEBC File Offset: 0x0006A0BC
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17005E38 RID: 24120
		' (get) Token: 0x0600F664 RID: 63076 RVA: 0x0006BEC5 File Offset: 0x0006A0C5
		' (set) Token: 0x0600F665 RID: 63077 RVA: 0x0006BECF File Offset: 0x0006A0CF
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17005E39 RID: 24121
		' (get) Token: 0x0600F666 RID: 63078 RVA: 0x0006BED8 File Offset: 0x0006A0D8
		' (set) Token: 0x0600F667 RID: 63079 RVA: 0x0006BEE2 File Offset: 0x0006A0E2
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x17005E3A RID: 24122
		' (get) Token: 0x0600F668 RID: 63080 RVA: 0x0006BEEB File Offset: 0x0006A0EB
		' (set) Token: 0x0600F669 RID: 63081 RVA: 0x0006BEF5 File Offset: 0x0006A0F5
		Friend Overridable Property TabPage4 As TabPage

		' Token: 0x17005E3B RID: 24123
		' (get) Token: 0x0600F66A RID: 63082 RVA: 0x0006BEFE File Offset: 0x0006A0FE
		' (set) Token: 0x0600F66B RID: 63083 RVA: 0x0006BF08 File Offset: 0x0006A108
		Friend Overridable Property TabPage5 As TabPage

		' Token: 0x17005E3C RID: 24124
		' (get) Token: 0x0600F66C RID: 63084 RVA: 0x0006BF11 File Offset: 0x0006A111
		' (set) Token: 0x0600F66D RID: 63085 RVA: 0x0006BF1B File Offset: 0x0006A11B
		Friend Overridable Property TabPage6 As TabPage

		' Token: 0x17005E3D RID: 24125
		' (get) Token: 0x0600F66E RID: 63086 RVA: 0x0006BF24 File Offset: 0x0006A124
		' (set) Token: 0x0600F66F RID: 63087 RVA: 0x0006BF2E File Offset: 0x0006A12E
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005E3E RID: 24126
		' (get) Token: 0x0600F670 RID: 63088 RVA: 0x0006BF37 File Offset: 0x0006A137
		' (set) Token: 0x0600F671 RID: 63089 RVA: 0x0006BF41 File Offset: 0x0006A141
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005E3F RID: 24127
		' (get) Token: 0x0600F672 RID: 63090 RVA: 0x0006BF4A File Offset: 0x0006A14A
		' (set) Token: 0x0600F673 RID: 63091 RVA: 0x0006BF54 File Offset: 0x0006A154
		Friend Overridable Property Label2 As Label

		' Token: 0x17005E40 RID: 24128
		' (get) Token: 0x0600F674 RID: 63092 RVA: 0x0006BF5D File Offset: 0x0006A15D
		' (set) Token: 0x0600F675 RID: 63093 RVA: 0x0093EA70 File Offset: 0x0093CC70
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E41 RID: 24129
		' (get) Token: 0x0600F676 RID: 63094 RVA: 0x0006BF67 File Offset: 0x0006A167
		' (set) Token: 0x0600F677 RID: 63095 RVA: 0x0006BF71 File Offset: 0x0006A171
		Friend Overridable Property Label4 As Label

		' Token: 0x17005E42 RID: 24130
		' (get) Token: 0x0600F678 RID: 63096 RVA: 0x0006BF7A File Offset: 0x0006A17A
		' (set) Token: 0x0600F679 RID: 63097 RVA: 0x0006BF84 File Offset: 0x0006A184
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005E43 RID: 24131
		' (get) Token: 0x0600F67A RID: 63098 RVA: 0x0006BF8D File Offset: 0x0006A18D
		' (set) Token: 0x0600F67B RID: 63099 RVA: 0x0093EAB4 File Offset: 0x0093CCB4
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E44 RID: 24132
		' (get) Token: 0x0600F67C RID: 63100 RVA: 0x0006BF97 File Offset: 0x0006A197
		' (set) Token: 0x0600F67D RID: 63101 RVA: 0x0006BFA1 File Offset: 0x0006A1A1
		Friend Overridable Property Label1 As Label

		' Token: 0x17005E45 RID: 24133
		' (get) Token: 0x0600F67E RID: 63102 RVA: 0x0006BFAA File Offset: 0x0006A1AA
		' (set) Token: 0x0600F67F RID: 63103 RVA: 0x0093EAF8 File Offset: 0x0093CCF8
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

		' Token: 0x17005E46 RID: 24134
		' (get) Token: 0x0600F680 RID: 63104 RVA: 0x0006BFB4 File Offset: 0x0006A1B4
		' (set) Token: 0x0600F681 RID: 63105 RVA: 0x0093EB3C File Offset: 0x0093CD3C
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

		' Token: 0x17005E47 RID: 24135
		' (get) Token: 0x0600F682 RID: 63106 RVA: 0x0006BFBE File Offset: 0x0006A1BE
		' (set) Token: 0x0600F683 RID: 63107 RVA: 0x0093EB80 File Offset: 0x0093CD80
		Private _dgw1 As DataGridView
		Friend Overridable Property dgw1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw1_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw1 = value
				dataGridView = Me._dgw1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E48 RID: 24136
		' (get) Token: 0x0600F684 RID: 63108 RVA: 0x0006BFC8 File Offset: 0x0006A1C8
		' (set) Token: 0x0600F685 RID: 63109 RVA: 0x0093EBC4 File Offset: 0x0093CDC4
		Private _dgw2 As DataGridView
		Friend Overridable Property dgw2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw2_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw2 = value
				dataGridView = Me._dgw2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E49 RID: 24137
		' (get) Token: 0x0600F686 RID: 63110 RVA: 0x0006BFD2 File Offset: 0x0006A1D2
		' (set) Token: 0x0600F687 RID: 63111 RVA: 0x0093EC08 File Offset: 0x0093CE08
		Private _dgw3 As DataGridView
		Friend Overridable Property dgw3 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw3_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw3
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw3 = value
				dataGridView = Me._dgw3
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4A RID: 24138
		' (get) Token: 0x0600F688 RID: 63112 RVA: 0x0006BFDC File Offset: 0x0006A1DC
		' (set) Token: 0x0600F689 RID: 63113 RVA: 0x0093EC4C File Offset: 0x0093CE4C
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw4_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4B RID: 24139
		' (get) Token: 0x0600F68A RID: 63114 RVA: 0x0006BFE6 File Offset: 0x0006A1E6
		' (set) Token: 0x0600F68B RID: 63115 RVA: 0x0093EC90 File Offset: 0x0093CE90
		Private _dgw5 As DataGridView
		Friend Overridable Property dgw5 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw5_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw5
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw5 = value
				dataGridView = Me._dgw5
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4C RID: 24140
		' (get) Token: 0x0600F68C RID: 63116 RVA: 0x0006BFF0 File Offset: 0x0006A1F0
		' (set) Token: 0x0600F68D RID: 63117 RVA: 0x0093ECD4 File Offset: 0x0093CED4
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4D RID: 24141
		' (get) Token: 0x0600F68E RID: 63118 RVA: 0x0006BFFA File Offset: 0x0006A1FA
		' (set) Token: 0x0600F68F RID: 63119 RVA: 0x0093ED18 File Offset: 0x0093CF18
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4E RID: 24142
		' (get) Token: 0x0600F690 RID: 63120 RVA: 0x0006C004 File Offset: 0x0006A204
		' (set) Token: 0x0600F691 RID: 63121 RVA: 0x0093ED5C File Offset: 0x0093CF5C
		Private _LinkLabel4 As LinkLabel
		Friend Overridable Property LinkLabel4 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel4_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel4 = value
				linkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E4F RID: 24143
		' (get) Token: 0x0600F692 RID: 63122 RVA: 0x0006C00E File Offset: 0x0006A20E
		' (set) Token: 0x0600F693 RID: 63123 RVA: 0x0093EDA0 File Offset: 0x0093CFA0
		Private _LinkLabel5 As LinkLabel
		Friend Overridable Property LinkLabel5 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel5_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel5 = value
				linkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E50 RID: 24144
		' (get) Token: 0x0600F694 RID: 63124 RVA: 0x0006C018 File Offset: 0x0006A218
		' (set) Token: 0x0600F695 RID: 63125 RVA: 0x0093EDE4 File Offset: 0x0093CFE4
		Private _LinkLabel6 As LinkLabel
		Friend Overridable Property LinkLabel6 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel6_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel6
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel6 = value
				linkLabel = Me._LinkLabel6
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E51 RID: 24145
		' (get) Token: 0x0600F696 RID: 63126 RVA: 0x0006C022 File Offset: 0x0006A222
		' (set) Token: 0x0600F697 RID: 63127 RVA: 0x0006C02C File Offset: 0x0006A22C
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005E52 RID: 24146
		' (get) Token: 0x0600F698 RID: 63128 RVA: 0x0006C035 File Offset: 0x0006A235
		' (set) Token: 0x0600F699 RID: 63129 RVA: 0x0006C03F File Offset: 0x0006A23F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005E53 RID: 24147
		' (get) Token: 0x0600F69A RID: 63130 RVA: 0x0006C048 File Offset: 0x0006A248
		' (set) Token: 0x0600F69B RID: 63131 RVA: 0x0006C052 File Offset: 0x0006A252
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005E54 RID: 24148
		' (get) Token: 0x0600F69C RID: 63132 RVA: 0x0006C05B File Offset: 0x0006A25B
		' (set) Token: 0x0600F69D RID: 63133 RVA: 0x0006C065 File Offset: 0x0006A265
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17005E55 RID: 24149
		' (get) Token: 0x0600F69E RID: 63134 RVA: 0x0006C06E File Offset: 0x0006A26E
		' (set) Token: 0x0600F69F RID: 63135 RVA: 0x0006C078 File Offset: 0x0006A278
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005E56 RID: 24150
		' (get) Token: 0x0600F6A0 RID: 63136 RVA: 0x0006C081 File Offset: 0x0006A281
		' (set) Token: 0x0600F6A1 RID: 63137 RVA: 0x0006C08B File Offset: 0x0006A28B
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17005E57 RID: 24151
		' (get) Token: 0x0600F6A2 RID: 63138 RVA: 0x0006C094 File Offset: 0x0006A294
		' (set) Token: 0x0600F6A3 RID: 63139 RVA: 0x0006C09E File Offset: 0x0006A29E
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17005E58 RID: 24152
		' (get) Token: 0x0600F6A4 RID: 63140 RVA: 0x0006C0A7 File Offset: 0x0006A2A7
		' (set) Token: 0x0600F6A5 RID: 63141 RVA: 0x0006C0B1 File Offset: 0x0006A2B1
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17005E59 RID: 24153
		' (get) Token: 0x0600F6A6 RID: 63142 RVA: 0x0006C0BA File Offset: 0x0006A2BA
		' (set) Token: 0x0600F6A7 RID: 63143 RVA: 0x0006C0C4 File Offset: 0x0006A2C4
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17005E5A RID: 24154
		' (get) Token: 0x0600F6A8 RID: 63144 RVA: 0x0006C0CD File Offset: 0x0006A2CD
		' (set) Token: 0x0600F6A9 RID: 63145 RVA: 0x0006C0D7 File Offset: 0x0006A2D7
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17005E5B RID: 24155
		' (get) Token: 0x0600F6AA RID: 63146 RVA: 0x0006C0E0 File Offset: 0x0006A2E0
		' (set) Token: 0x0600F6AB RID: 63147 RVA: 0x0006C0EA File Offset: 0x0006A2EA
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17005E5C RID: 24156
		' (get) Token: 0x0600F6AC RID: 63148 RVA: 0x0006C0F3 File Offset: 0x0006A2F3
		' (set) Token: 0x0600F6AD RID: 63149 RVA: 0x0006C0FD File Offset: 0x0006A2FD
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17005E5D RID: 24157
		' (get) Token: 0x0600F6AE RID: 63150 RVA: 0x0006C106 File Offset: 0x0006A306
		' (set) Token: 0x0600F6AF RID: 63151 RVA: 0x0006C110 File Offset: 0x0006A310
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17005E5E RID: 24158
		' (get) Token: 0x0600F6B0 RID: 63152 RVA: 0x0006C119 File Offset: 0x0006A319
		' (set) Token: 0x0600F6B1 RID: 63153 RVA: 0x0006C123 File Offset: 0x0006A323
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17005E5F RID: 24159
		' (get) Token: 0x0600F6B2 RID: 63154 RVA: 0x0006C12C File Offset: 0x0006A32C
		' (set) Token: 0x0600F6B3 RID: 63155 RVA: 0x0006C136 File Offset: 0x0006A336
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17005E60 RID: 24160
		' (get) Token: 0x0600F6B4 RID: 63156 RVA: 0x0006C13F File Offset: 0x0006A33F
		' (set) Token: 0x0600F6B5 RID: 63157 RVA: 0x0006C149 File Offset: 0x0006A349
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17005E61 RID: 24161
		' (get) Token: 0x0600F6B6 RID: 63158 RVA: 0x0006C152 File Offset: 0x0006A352
		' (set) Token: 0x0600F6B7 RID: 63159 RVA: 0x0006C15C File Offset: 0x0006A35C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005E62 RID: 24162
		' (get) Token: 0x0600F6B8 RID: 63160 RVA: 0x0006C165 File Offset: 0x0006A365
		' (set) Token: 0x0600F6B9 RID: 63161 RVA: 0x0006C16F File Offset: 0x0006A36F
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17005E63 RID: 24163
		' (get) Token: 0x0600F6BA RID: 63162 RVA: 0x0006C178 File Offset: 0x0006A378
		' (set) Token: 0x0600F6BB RID: 63163 RVA: 0x0006C182 File Offset: 0x0006A382
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17005E64 RID: 24164
		' (get) Token: 0x0600F6BC RID: 63164 RVA: 0x0006C18B File Offset: 0x0006A38B
		' (set) Token: 0x0600F6BD RID: 63165 RVA: 0x0006C195 File Offset: 0x0006A395
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17005E65 RID: 24165
		' (get) Token: 0x0600F6BE RID: 63166 RVA: 0x0006C19E File Offset: 0x0006A39E
		' (set) Token: 0x0600F6BF RID: 63167 RVA: 0x0006C1A8 File Offset: 0x0006A3A8
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17005E66 RID: 24166
		' (get) Token: 0x0600F6C0 RID: 63168 RVA: 0x0006C1B1 File Offset: 0x0006A3B1
		' (set) Token: 0x0600F6C1 RID: 63169 RVA: 0x0006C1BB File Offset: 0x0006A3BB
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17005E67 RID: 24167
		' (get) Token: 0x0600F6C2 RID: 63170 RVA: 0x0006C1C4 File Offset: 0x0006A3C4
		' (set) Token: 0x0600F6C3 RID: 63171 RVA: 0x0006C1CE File Offset: 0x0006A3CE
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17005E68 RID: 24168
		' (get) Token: 0x0600F6C4 RID: 63172 RVA: 0x0006C1D7 File Offset: 0x0006A3D7
		' (set) Token: 0x0600F6C5 RID: 63173 RVA: 0x0006C1E1 File Offset: 0x0006A3E1
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17005E69 RID: 24169
		' (get) Token: 0x0600F6C6 RID: 63174 RVA: 0x0006C1EA File Offset: 0x0006A3EA
		' (set) Token: 0x0600F6C7 RID: 63175 RVA: 0x0006C1F4 File Offset: 0x0006A3F4
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17005E6A RID: 24170
		' (get) Token: 0x0600F6C8 RID: 63176 RVA: 0x0006C1FD File Offset: 0x0006A3FD
		' (set) Token: 0x0600F6C9 RID: 63177 RVA: 0x0006C207 File Offset: 0x0006A407
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17005E6B RID: 24171
		' (get) Token: 0x0600F6CA RID: 63178 RVA: 0x0006C210 File Offset: 0x0006A410
		' (set) Token: 0x0600F6CB RID: 63179 RVA: 0x0006C21A File Offset: 0x0006A41A
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17005E6C RID: 24172
		' (get) Token: 0x0600F6CC RID: 63180 RVA: 0x0006C223 File Offset: 0x0006A423
		' (set) Token: 0x0600F6CD RID: 63181 RVA: 0x0006C22D File Offset: 0x0006A42D
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17005E6D RID: 24173
		' (get) Token: 0x0600F6CE RID: 63182 RVA: 0x0006C236 File Offset: 0x0006A436
		' (set) Token: 0x0600F6CF RID: 63183 RVA: 0x0006C240 File Offset: 0x0006A440
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17005E6E RID: 24174
		' (get) Token: 0x0600F6D0 RID: 63184 RVA: 0x0006C249 File Offset: 0x0006A449
		' (set) Token: 0x0600F6D1 RID: 63185 RVA: 0x0006C253 File Offset: 0x0006A453
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17005E6F RID: 24175
		' (get) Token: 0x0600F6D2 RID: 63186 RVA: 0x0006C25C File Offset: 0x0006A45C
		' (set) Token: 0x0600F6D3 RID: 63187 RVA: 0x0006C266 File Offset: 0x0006A466
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17005E70 RID: 24176
		' (get) Token: 0x0600F6D4 RID: 63188 RVA: 0x0006C26F File Offset: 0x0006A46F
		' (set) Token: 0x0600F6D5 RID: 63189 RVA: 0x0006C279 File Offset: 0x0006A479
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17005E71 RID: 24177
		' (get) Token: 0x0600F6D6 RID: 63190 RVA: 0x0006C282 File Offset: 0x0006A482
		' (set) Token: 0x0600F6D7 RID: 63191 RVA: 0x0006C28C File Offset: 0x0006A48C
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17005E72 RID: 24178
		' (get) Token: 0x0600F6D8 RID: 63192 RVA: 0x0006C295 File Offset: 0x0006A495
		' (set) Token: 0x0600F6D9 RID: 63193 RVA: 0x0006C29F File Offset: 0x0006A49F
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17005E73 RID: 24179
		' (get) Token: 0x0600F6DA RID: 63194 RVA: 0x0006C2A8 File Offset: 0x0006A4A8
		' (set) Token: 0x0600F6DB RID: 63195 RVA: 0x0006C2B2 File Offset: 0x0006A4B2
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17005E74 RID: 24180
		' (get) Token: 0x0600F6DC RID: 63196 RVA: 0x0006C2BB File Offset: 0x0006A4BB
		' (set) Token: 0x0600F6DD RID: 63197 RVA: 0x0006C2C5 File Offset: 0x0006A4C5
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17005E75 RID: 24181
		' (get) Token: 0x0600F6DE RID: 63198 RVA: 0x0006C2CE File Offset: 0x0006A4CE
		' (set) Token: 0x0600F6DF RID: 63199 RVA: 0x0006C2D8 File Offset: 0x0006A4D8
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17005E76 RID: 24182
		' (get) Token: 0x0600F6E0 RID: 63200 RVA: 0x0006C2E1 File Offset: 0x0006A4E1
		' (set) Token: 0x0600F6E1 RID: 63201 RVA: 0x0006C2EB File Offset: 0x0006A4EB
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17005E77 RID: 24183
		' (get) Token: 0x0600F6E2 RID: 63202 RVA: 0x0006C2F4 File Offset: 0x0006A4F4
		' (set) Token: 0x0600F6E3 RID: 63203 RVA: 0x0006C2FE File Offset: 0x0006A4FE
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17005E78 RID: 24184
		' (get) Token: 0x0600F6E4 RID: 63204 RVA: 0x0006C307 File Offset: 0x0006A507
		' (set) Token: 0x0600F6E5 RID: 63205 RVA: 0x0006C311 File Offset: 0x0006A511
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x17005E79 RID: 24185
		' (get) Token: 0x0600F6E6 RID: 63206 RVA: 0x0006C31A File Offset: 0x0006A51A
		' (set) Token: 0x0600F6E7 RID: 63207 RVA: 0x0006C324 File Offset: 0x0006A524
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x17005E7A RID: 24186
		' (get) Token: 0x0600F6E8 RID: 63208 RVA: 0x0006C32D File Offset: 0x0006A52D
		' (set) Token: 0x0600F6E9 RID: 63209 RVA: 0x0006C337 File Offset: 0x0006A537
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x17005E7B RID: 24187
		' (get) Token: 0x0600F6EA RID: 63210 RVA: 0x0006C340 File Offset: 0x0006A540
		' (set) Token: 0x0600F6EB RID: 63211 RVA: 0x0006C34A File Offset: 0x0006A54A
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x17005E7C RID: 24188
		' (get) Token: 0x0600F6EC RID: 63212 RVA: 0x0006C353 File Offset: 0x0006A553
		' (set) Token: 0x0600F6ED RID: 63213 RVA: 0x0006C35D File Offset: 0x0006A55D
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x17005E7D RID: 24189
		' (get) Token: 0x0600F6EE RID: 63214 RVA: 0x0006C366 File Offset: 0x0006A566
		' (set) Token: 0x0600F6EF RID: 63215 RVA: 0x0006C370 File Offset: 0x0006A570
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17005E7E RID: 24190
		' (get) Token: 0x0600F6F0 RID: 63216 RVA: 0x0006C379 File Offset: 0x0006A579
		' (set) Token: 0x0600F6F1 RID: 63217 RVA: 0x0006C383 File Offset: 0x0006A583
		Friend Overridable Property DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn

		' Token: 0x17005E7F RID: 24191
		' (get) Token: 0x0600F6F2 RID: 63218 RVA: 0x0006C38C File Offset: 0x0006A58C
		' (set) Token: 0x0600F6F3 RID: 63219 RVA: 0x0006C396 File Offset: 0x0006A596
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17005E80 RID: 24192
		' (get) Token: 0x0600F6F4 RID: 63220 RVA: 0x0006C39F File Offset: 0x0006A59F
		' (set) Token: 0x0600F6F5 RID: 63221 RVA: 0x0006C3A9 File Offset: 0x0006A5A9
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x17005E81 RID: 24193
		' (get) Token: 0x0600F6F6 RID: 63222 RVA: 0x0006C3B2 File Offset: 0x0006A5B2
		' (set) Token: 0x0600F6F7 RID: 63223 RVA: 0x0006C3BC File Offset: 0x0006A5BC
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x17005E82 RID: 24194
		' (get) Token: 0x0600F6F8 RID: 63224 RVA: 0x0006C3C5 File Offset: 0x0006A5C5
		' (set) Token: 0x0600F6F9 RID: 63225 RVA: 0x0006C3CF File Offset: 0x0006A5CF
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17005E83 RID: 24195
		' (get) Token: 0x0600F6FA RID: 63226 RVA: 0x0006C3D8 File Offset: 0x0006A5D8
		' (set) Token: 0x0600F6FB RID: 63227 RVA: 0x0006C3E2 File Offset: 0x0006A5E2
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x17005E84 RID: 24196
		' (get) Token: 0x0600F6FC RID: 63228 RVA: 0x0006C3EB File Offset: 0x0006A5EB
		' (set) Token: 0x0600F6FD RID: 63229 RVA: 0x0006C3F5 File Offset: 0x0006A5F5
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17005E85 RID: 24197
		' (get) Token: 0x0600F6FE RID: 63230 RVA: 0x0006C3FE File Offset: 0x0006A5FE
		' (set) Token: 0x0600F6FF RID: 63231 RVA: 0x0006C408 File Offset: 0x0006A608
		Friend Overridable Property DataGridViewTextBoxColumn59 As DataGridViewTextBoxColumn

		' Token: 0x17005E86 RID: 24198
		' (get) Token: 0x0600F700 RID: 63232 RVA: 0x0006C411 File Offset: 0x0006A611
		' (set) Token: 0x0600F701 RID: 63233 RVA: 0x0006C41B File Offset: 0x0006A61B
		Friend Overridable Property DataGridViewTextBoxColumn60 As DataGridViewTextBoxColumn

		' Token: 0x17005E87 RID: 24199
		' (get) Token: 0x0600F702 RID: 63234 RVA: 0x0006C424 File Offset: 0x0006A624
		' (set) Token: 0x0600F703 RID: 63235 RVA: 0x0006C42E File Offset: 0x0006A62E
		Friend Overridable Property DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn

		' Token: 0x17005E88 RID: 24200
		' (get) Token: 0x0600F704 RID: 63236 RVA: 0x0006C437 File Offset: 0x0006A637
		' (set) Token: 0x0600F705 RID: 63237 RVA: 0x0006C441 File Offset: 0x0006A641
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17005E89 RID: 24201
		' (get) Token: 0x0600F706 RID: 63238 RVA: 0x0006C44A File Offset: 0x0006A64A
		' (set) Token: 0x0600F707 RID: 63239 RVA: 0x0006C454 File Offset: 0x0006A654
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17005E8A RID: 24202
		' (get) Token: 0x0600F708 RID: 63240 RVA: 0x0006C45D File Offset: 0x0006A65D
		' (set) Token: 0x0600F709 RID: 63241 RVA: 0x0006C467 File Offset: 0x0006A667
		Friend Overridable Property DataGridViewTextBoxColumn63 As DataGridViewTextBoxColumn

		' Token: 0x17005E8B RID: 24203
		' (get) Token: 0x0600F70A RID: 63242 RVA: 0x0006C470 File Offset: 0x0006A670
		' (set) Token: 0x0600F70B RID: 63243 RVA: 0x0006C47A File Offset: 0x0006A67A
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17005E8C RID: 24204
		' (get) Token: 0x0600F70C RID: 63244 RVA: 0x0006C483 File Offset: 0x0006A683
		' (set) Token: 0x0600F70D RID: 63245 RVA: 0x0006C48D File Offset: 0x0006A68D
		Friend Overridable Property DataGridViewTextBoxColumn65 As DataGridViewTextBoxColumn

		' Token: 0x17005E8D RID: 24205
		' (get) Token: 0x0600F70E RID: 63246 RVA: 0x0006C496 File Offset: 0x0006A696
		' (set) Token: 0x0600F70F RID: 63247 RVA: 0x0006C4A0 File Offset: 0x0006A6A0
		Friend Overridable Property DataGridViewTextBoxColumn66 As DataGridViewTextBoxColumn

		' Token: 0x17005E8E RID: 24206
		' (get) Token: 0x0600F710 RID: 63248 RVA: 0x0006C4A9 File Offset: 0x0006A6A9
		' (set) Token: 0x0600F711 RID: 63249 RVA: 0x0006C4B3 File Offset: 0x0006A6B3
		Friend Overridable Property DataGridViewTextBoxColumn67 As DataGridViewTextBoxColumn

		' Token: 0x17005E8F RID: 24207
		' (get) Token: 0x0600F712 RID: 63250 RVA: 0x0006C4BC File Offset: 0x0006A6BC
		' (set) Token: 0x0600F713 RID: 63251 RVA: 0x0006C4C6 File Offset: 0x0006A6C6
		Friend Overridable Property DataGridViewTextBoxColumn68 As DataGridViewTextBoxColumn

		' Token: 0x17005E90 RID: 24208
		' (get) Token: 0x0600F714 RID: 63252 RVA: 0x0006C4CF File Offset: 0x0006A6CF
		' (set) Token: 0x0600F715 RID: 63253 RVA: 0x0006C4D9 File Offset: 0x0006A6D9
		Friend Overridable Property DataGridViewTextBoxColumn69 As DataGridViewTextBoxColumn

		' Token: 0x17005E91 RID: 24209
		' (get) Token: 0x0600F716 RID: 63254 RVA: 0x0006C4E2 File Offset: 0x0006A6E2
		' (set) Token: 0x0600F717 RID: 63255 RVA: 0x0006C4EC File Offset: 0x0006A6EC
		Friend Overridable Property DataGridViewTextBoxColumn70 As DataGridViewTextBoxColumn

		' Token: 0x17005E92 RID: 24210
		' (get) Token: 0x0600F718 RID: 63256 RVA: 0x0006C4F5 File Offset: 0x0006A6F5
		' (set) Token: 0x0600F719 RID: 63257 RVA: 0x0006C4FF File Offset: 0x0006A6FF
		Friend Overridable Property DataGridViewTextBoxColumn71 As DataGridViewTextBoxColumn

		' Token: 0x17005E93 RID: 24211
		' (get) Token: 0x0600F71A RID: 63258 RVA: 0x0006C508 File Offset: 0x0006A708
		' (set) Token: 0x0600F71B RID: 63259 RVA: 0x0006C512 File Offset: 0x0006A712
		Friend Overridable Property DataGridViewTextBoxColumn72 As DataGridViewTextBoxColumn

		' Token: 0x17005E94 RID: 24212
		' (get) Token: 0x0600F71C RID: 63260 RVA: 0x0006C51B File Offset: 0x0006A71B
		' (set) Token: 0x0600F71D RID: 63261 RVA: 0x0006C525 File Offset: 0x0006A725
		Friend Overridable Property DataGridViewTextBoxColumn74 As DataGridViewTextBoxColumn

		' Token: 0x17005E95 RID: 24213
		' (get) Token: 0x0600F71E RID: 63262 RVA: 0x0006C52E File Offset: 0x0006A72E
		' (set) Token: 0x0600F71F RID: 63263 RVA: 0x0006C538 File Offset: 0x0006A738
		Friend Overridable Property DataGridViewTextBoxColumn75 As DataGridViewTextBoxColumn

		' Token: 0x17005E96 RID: 24214
		' (get) Token: 0x0600F720 RID: 63264 RVA: 0x0006C541 File Offset: 0x0006A741
		' (set) Token: 0x0600F721 RID: 63265 RVA: 0x0006C54B File Offset: 0x0006A74B
		Friend Overridable Property DataGridViewTextBoxColumn76 As DataGridViewTextBoxColumn

		' Token: 0x17005E97 RID: 24215
		' (get) Token: 0x0600F722 RID: 63266 RVA: 0x0006C554 File Offset: 0x0006A754
		' (set) Token: 0x0600F723 RID: 63267 RVA: 0x0006C55E File Offset: 0x0006A75E
		Friend Overridable Property DataGridViewTextBoxColumn78 As DataGridViewTextBoxColumn

		' Token: 0x17005E98 RID: 24216
		' (get) Token: 0x0600F724 RID: 63268 RVA: 0x0006C567 File Offset: 0x0006A767
		' (set) Token: 0x0600F725 RID: 63269 RVA: 0x0006C571 File Offset: 0x0006A771
		Friend Overridable Property DataGridViewTextBoxColumn79 As DataGridViewTextBoxColumn

		' Token: 0x17005E99 RID: 24217
		' (get) Token: 0x0600F726 RID: 63270 RVA: 0x0006C57A File Offset: 0x0006A77A
		' (set) Token: 0x0600F727 RID: 63271 RVA: 0x0006C584 File Offset: 0x0006A784
		Friend Overridable Property DataGridViewTextBoxColumn81 As DataGridViewTextBoxColumn

		' Token: 0x17005E9A RID: 24218
		' (get) Token: 0x0600F728 RID: 63272 RVA: 0x0006C58D File Offset: 0x0006A78D
		' (set) Token: 0x0600F729 RID: 63273 RVA: 0x0006C597 File Offset: 0x0006A797
		Friend Overridable Property DataGridViewTextBoxColumn82 As DataGridViewTextBoxColumn

		' Token: 0x17005E9B RID: 24219
		' (get) Token: 0x0600F72A RID: 63274 RVA: 0x0006C5A0 File Offset: 0x0006A7A0
		' (set) Token: 0x0600F72B RID: 63275 RVA: 0x0006C5AA File Offset: 0x0006A7AA
		Friend Overridable Property DataGridViewTextBoxColumn83 As DataGridViewTextBoxColumn

		' Token: 0x17005E9C RID: 24220
		' (get) Token: 0x0600F72C RID: 63276 RVA: 0x0006C5B3 File Offset: 0x0006A7B3
		' (set) Token: 0x0600F72D RID: 63277 RVA: 0x0006C5BD File Offset: 0x0006A7BD
		Friend Overridable Property DataGridViewTextBoxColumn84 As DataGridViewTextBoxColumn

		' Token: 0x17005E9D RID: 24221
		' (get) Token: 0x0600F72E RID: 63278 RVA: 0x0006C5C6 File Offset: 0x0006A7C6
		' (set) Token: 0x0600F72F RID: 63279 RVA: 0x0006C5D0 File Offset: 0x0006A7D0
		Friend Overridable Property DataGridViewTextBoxColumn85 As DataGridViewTextBoxColumn

		' Token: 0x17005E9E RID: 24222
		' (get) Token: 0x0600F730 RID: 63280 RVA: 0x0006C5D9 File Offset: 0x0006A7D9
		' (set) Token: 0x0600F731 RID: 63281 RVA: 0x0006C5E3 File Offset: 0x0006A7E3
		Friend Overridable Property DataGridViewTextBoxColumn86 As DataGridViewTextBoxColumn

		' Token: 0x17005E9F RID: 24223
		' (get) Token: 0x0600F732 RID: 63282 RVA: 0x0006C5EC File Offset: 0x0006A7EC
		' (set) Token: 0x0600F733 RID: 63283 RVA: 0x0006C5F6 File Offset: 0x0006A7F6
		Friend Overridable Property DataGridViewTextBoxColumn87 As DataGridViewTextBoxColumn

		' Token: 0x17005EA0 RID: 24224
		' (get) Token: 0x0600F734 RID: 63284 RVA: 0x0006C5FF File Offset: 0x0006A7FF
		' (set) Token: 0x0600F735 RID: 63285 RVA: 0x0006C609 File Offset: 0x0006A809
		Friend Overridable Property DataGridViewTextBoxColumn88 As DataGridViewTextBoxColumn

		' Token: 0x17005EA1 RID: 24225
		' (get) Token: 0x0600F736 RID: 63286 RVA: 0x0006C612 File Offset: 0x0006A812
		' (set) Token: 0x0600F737 RID: 63287 RVA: 0x0006C61C File Offset: 0x0006A81C
		Friend Overridable Property DataGridViewTextBoxColumn89 As DataGridViewTextBoxColumn

		' Token: 0x17005EA2 RID: 24226
		' (get) Token: 0x0600F738 RID: 63288 RVA: 0x0006C625 File Offset: 0x0006A825
		' (set) Token: 0x0600F739 RID: 63289 RVA: 0x0006C62F File Offset: 0x0006A82F
		Friend Overridable Property DataGridViewTextBoxColumn90 As DataGridViewTextBoxColumn

		' Token: 0x17005EA3 RID: 24227
		' (get) Token: 0x0600F73A RID: 63290 RVA: 0x0006C638 File Offset: 0x0006A838
		' (set) Token: 0x0600F73B RID: 63291 RVA: 0x0006C642 File Offset: 0x0006A842
		Friend Overridable Property DataGridViewTextBoxColumn91 As DataGridViewTextBoxColumn

		' Token: 0x17005EA4 RID: 24228
		' (get) Token: 0x0600F73C RID: 63292 RVA: 0x0006C64B File Offset: 0x0006A84B
		' (set) Token: 0x0600F73D RID: 63293 RVA: 0x0006C655 File Offset: 0x0006A855
		Friend Overridable Property DataGridViewTextBoxColumn92 As DataGridViewTextBoxColumn

		' Token: 0x17005EA5 RID: 24229
		' (get) Token: 0x0600F73E RID: 63294 RVA: 0x0006C65E File Offset: 0x0006A85E
		' (set) Token: 0x0600F73F RID: 63295 RVA: 0x0006C668 File Offset: 0x0006A868
		Friend Overridable Property DataGridViewTextBoxColumn93 As DataGridViewTextBoxColumn

		' Token: 0x17005EA6 RID: 24230
		' (get) Token: 0x0600F740 RID: 63296 RVA: 0x0006C671 File Offset: 0x0006A871
		' (set) Token: 0x0600F741 RID: 63297 RVA: 0x0006C67B File Offset: 0x0006A87B
		Friend Overridable Property DataGridViewTextBoxColumn101 As DataGridViewTextBoxColumn

		' Token: 0x17005EA7 RID: 24231
		' (get) Token: 0x0600F742 RID: 63298 RVA: 0x0006C684 File Offset: 0x0006A884
		' (set) Token: 0x0600F743 RID: 63299 RVA: 0x0006C68E File Offset: 0x0006A88E
		Friend Overridable Property DataGridViewTextBoxColumn94 As DataGridViewTextBoxColumn

		' Token: 0x17005EA8 RID: 24232
		' (get) Token: 0x0600F744 RID: 63300 RVA: 0x0006C697 File Offset: 0x0006A897
		' (set) Token: 0x0600F745 RID: 63301 RVA: 0x0006C6A1 File Offset: 0x0006A8A1
		Friend Overridable Property DataGridViewTextBoxColumn95 As DataGridViewTextBoxColumn

		' Token: 0x17005EA9 RID: 24233
		' (get) Token: 0x0600F746 RID: 63302 RVA: 0x0006C6AA File Offset: 0x0006A8AA
		' (set) Token: 0x0600F747 RID: 63303 RVA: 0x0006C6B4 File Offset: 0x0006A8B4
		Friend Overridable Property DataGridViewTextBoxColumn96 As DataGridViewTextBoxColumn

		' Token: 0x17005EAA RID: 24234
		' (get) Token: 0x0600F748 RID: 63304 RVA: 0x0006C6BD File Offset: 0x0006A8BD
		' (set) Token: 0x0600F749 RID: 63305 RVA: 0x0006C6C7 File Offset: 0x0006A8C7
		Friend Overridable Property DataGridViewTextBoxColumn97 As DataGridViewTextBoxColumn

		' Token: 0x17005EAB RID: 24235
		' (get) Token: 0x0600F74A RID: 63306 RVA: 0x0006C6D0 File Offset: 0x0006A8D0
		' (set) Token: 0x0600F74B RID: 63307 RVA: 0x0006C6DA File Offset: 0x0006A8DA
		Friend Overridable Property DataGridViewTextBoxColumn98 As DataGridViewTextBoxColumn

		' Token: 0x17005EAC RID: 24236
		' (get) Token: 0x0600F74C RID: 63308 RVA: 0x0006C6E3 File Offset: 0x0006A8E3
		' (set) Token: 0x0600F74D RID: 63309 RVA: 0x0006C6ED File Offset: 0x0006A8ED
		Friend Overridable Property DataGridViewTextBoxColumn99 As DataGridViewTextBoxColumn

		' Token: 0x17005EAD RID: 24237
		' (get) Token: 0x0600F74E RID: 63310 RVA: 0x0006C6F6 File Offset: 0x0006A8F6
		' (set) Token: 0x0600F74F RID: 63311 RVA: 0x0006C700 File Offset: 0x0006A900
		Friend Overridable Property DataGridViewTextBoxColumn100 As DataGridViewTextBoxColumn

		' Token: 0x17005EAE RID: 24238
		' (get) Token: 0x0600F750 RID: 63312 RVA: 0x0006C709 File Offset: 0x0006A909
		' (set) Token: 0x0600F751 RID: 63313 RVA: 0x0006C713 File Offset: 0x0006A913
		Friend Overridable Property DataGridViewTextBoxColumn102 As DataGridViewTextBoxColumn

		' Token: 0x17005EAF RID: 24239
		' (get) Token: 0x0600F752 RID: 63314 RVA: 0x0006C71C File Offset: 0x0006A91C
		' (set) Token: 0x0600F753 RID: 63315 RVA: 0x0006C726 File Offset: 0x0006A926
		Friend Overridable Property DataGridViewTextBoxColumn103 As DataGridViewTextBoxColumn

		' Token: 0x17005EB0 RID: 24240
		' (get) Token: 0x0600F754 RID: 63316 RVA: 0x0006C72F File Offset: 0x0006A92F
		' (set) Token: 0x0600F755 RID: 63317 RVA: 0x0006C739 File Offset: 0x0006A939
		Friend Overridable Property DataGridViewTextBoxColumn104 As DataGridViewTextBoxColumn

		' Token: 0x17005EB1 RID: 24241
		' (get) Token: 0x0600F756 RID: 63318 RVA: 0x0006C742 File Offset: 0x0006A942
		' (set) Token: 0x0600F757 RID: 63319 RVA: 0x0006C74C File Offset: 0x0006A94C
		Friend Overridable Property DataGridViewTextBoxColumn105 As DataGridViewTextBoxColumn

		' Token: 0x17005EB2 RID: 24242
		' (get) Token: 0x0600F758 RID: 63320 RVA: 0x0006C755 File Offset: 0x0006A955
		' (set) Token: 0x0600F759 RID: 63321 RVA: 0x0006C75F File Offset: 0x0006A95F
		Friend Overridable Property DataGridViewTextBoxColumn106 As DataGridViewTextBoxColumn

		' Token: 0x17005EB3 RID: 24243
		' (get) Token: 0x0600F75A RID: 63322 RVA: 0x0006C768 File Offset: 0x0006A968
		' (set) Token: 0x0600F75B RID: 63323 RVA: 0x0006C772 File Offset: 0x0006A972
		Friend Overridable Property DataGridViewTextBoxColumn107 As DataGridViewTextBoxColumn

		' Token: 0x17005EB4 RID: 24244
		' (get) Token: 0x0600F75C RID: 63324 RVA: 0x0006C77B File Offset: 0x0006A97B
		' (set) Token: 0x0600F75D RID: 63325 RVA: 0x0006C785 File Offset: 0x0006A985
		Friend Overridable Property DataGridViewTextBoxColumn108 As DataGridViewTextBoxColumn

		' Token: 0x17005EB5 RID: 24245
		' (get) Token: 0x0600F75E RID: 63326 RVA: 0x0006C78E File Offset: 0x0006A98E
		' (set) Token: 0x0600F75F RID: 63327 RVA: 0x0006C798 File Offset: 0x0006A998
		Friend Overridable Property DataGridViewTextBoxColumn109 As DataGridViewTextBoxColumn

		' Token: 0x17005EB6 RID: 24246
		' (get) Token: 0x0600F760 RID: 63328 RVA: 0x0006C7A1 File Offset: 0x0006A9A1
		' (set) Token: 0x0600F761 RID: 63329 RVA: 0x0006C7AB File Offset: 0x0006A9AB
		Friend Overridable Property DataGridViewTextBoxColumn110 As DataGridViewTextBoxColumn

		' Token: 0x17005EB7 RID: 24247
		' (get) Token: 0x0600F762 RID: 63330 RVA: 0x0006C7B4 File Offset: 0x0006A9B4
		' (set) Token: 0x0600F763 RID: 63331 RVA: 0x0006C7BE File Offset: 0x0006A9BE
		Friend Overridable Property DataGridViewTextBoxColumn111 As DataGridViewTextBoxColumn

		' Token: 0x17005EB8 RID: 24248
		' (get) Token: 0x0600F764 RID: 63332 RVA: 0x0006C7C7 File Offset: 0x0006A9C7
		' (set) Token: 0x0600F765 RID: 63333 RVA: 0x0006C7D1 File Offset: 0x0006A9D1
		Friend Overridable Property DataGridViewTextBoxColumn112 As DataGridViewTextBoxColumn

		' Token: 0x17005EB9 RID: 24249
		' (get) Token: 0x0600F766 RID: 63334 RVA: 0x0006C7DA File Offset: 0x0006A9DA
		' (set) Token: 0x0600F767 RID: 63335 RVA: 0x0006C7E4 File Offset: 0x0006A9E4
		Friend Overridable Property DataGridViewTextBoxColumn113 As DataGridViewTextBoxColumn

		' Token: 0x17005EBA RID: 24250
		' (get) Token: 0x0600F768 RID: 63336 RVA: 0x0006C7ED File Offset: 0x0006A9ED
		' (set) Token: 0x0600F769 RID: 63337 RVA: 0x0006C7F7 File Offset: 0x0006A9F7
		Friend Overridable Property DataGridViewTextBoxColumn114 As DataGridViewTextBoxColumn

		' Token: 0x17005EBB RID: 24251
		' (get) Token: 0x0600F76A RID: 63338 RVA: 0x0006C800 File Offset: 0x0006AA00
		' (set) Token: 0x0600F76B RID: 63339 RVA: 0x0006C80A File Offset: 0x0006AA0A
		Friend Overridable Property DataGridViewTextBoxColumn115 As DataGridViewTextBoxColumn

		' Token: 0x0600F76C RID: 63340 RVA: 0x0006C813 File Offset: 0x0006AA13
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.B2B()
			Me.B2CL()
			Me.B2CS()
			Me.CDNR()
			Me.CDNUR()
			Me.HSN()
		End Sub

		' Token: 0x0600F76D RID: 63341 RVA: 0x0093EE28 File Offset: 0x0093D028
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600F76E RID: 63342 RVA: 0x0093EF04 File Offset: 0x0093D104
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

		' Token: 0x0600F76F RID: 63343 RVA: 0x0093EFEC File Offset: 0x0093D1EC
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.B2B()
			Me.B2CL()
			Me.B2CS()
			Me.CDNR()
			Me.CDNUR()
			Me.HSN()
		End Sub

		' Token: 0x0600F770 RID: 63344 RVA: 0x0006C840 File Offset: 0x0006AA40
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F771 RID: 63345 RVA: 0x0093F03C File Offset: 0x0093D23C
		Private Sub B2B()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), RTRIM(Customer.Name),RTRIM(Customer.State),RTRIM(Customer.GSTIN),TaxableAmt, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where RTRIM(Customer.GSTIN)>'' and NOT TaxType='NON GST' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F772 RID: 63346 RVA: 0x0093F294 File Offset: 0x0093D494
		Private Sub B2CL()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), RTRIM(Customer.Name),RTRIM(Customer.State),RTRIM(Customer.GSTIN),TaxableAmt, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where RTRIM(Customer.GSTIN)='' and GrandTotal >= '250000' and NOT TaxType='NON GST' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F773 RID: 63347 RVA: 0x0093F4EC File Offset: 0x0093D6EC
		Private Sub dgw1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F774 RID: 63348 RVA: 0x0093F5D4 File Offset: 0x0093D7D4
		Private Sub B2CS()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), RTRIM(Customer.Name),RTRIM(Customer.State),RTRIM(Customer.GSTIN),TaxableAmt, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where RTRIM(Customer.GSTIN)='' and GrandTotal < '250000' and NOT TaxType='NON GST' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F775 RID: 63349 RVA: 0x0093F82C File Offset: 0x0093DA2C
		Private Sub dgw2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw2.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw2.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F776 RID: 63350 RVA: 0x0093F914 File Offset: 0x0093DB14
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw1.Columns.Count = 0) Or (Me.dgw1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw1.Columns
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
						For Each obj2 As Object In CType(Me.dgw1.Rows, IEnumerable)
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

		' Token: 0x0600F777 RID: 63351 RVA: 0x0093FBC0 File Offset: 0x0093DDC0
		Private Sub CDNR()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),RTRIM(InvoiceNo),InvoiceDate, RTRIM(Name),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal) FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and RTRIM(Customer.GSTIN)>'' and NOT TaxType='NON GST' and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw3.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F778 RID: 63352 RVA: 0x0093FE24 File Offset: 0x0093E024
		Private Sub CDNUR()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),RTRIM(InvoiceNo),InvoiceDate, RTRIM(Name),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal) FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and RTRIM(Customer.GSTIN)='' and NOT TaxType='NON GST' and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw4.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F779 RID: 63353 RVA: 0x00940088 File Offset: 0x0093E288
		Private Sub dgw3_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw3.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw3.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F77A RID: 63354 RVA: 0x00940170 File Offset: 0x0093E370
		Private Sub dgw4_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw4.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw4.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F77B RID: 63355 RVA: 0x00940258 File Offset: 0x0093E458
		Private Sub HSN()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Product.HSNCode), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where RTRIM(Product.HSNCode)>'' and NOT TaxType='NON GST' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw5.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F77C RID: 63356 RVA: 0x00940504 File Offset: 0x0093E704
		Private Sub dgw5_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw5.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw5.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F77D RID: 63357 RVA: 0x009405EC File Offset: 0x0093E7EC
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
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

		' Token: 0x0600F77E RID: 63358 RVA: 0x00940898 File Offset: 0x0093EA98
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw2.Columns.Count = 0) Or (Me.dgw2.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw2.Columns
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
						For Each obj2 As Object In CType(Me.dgw2.Rows, IEnumerable)
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

		' Token: 0x0600F77F RID: 63359 RVA: 0x00940B44 File Offset: 0x0093ED44
		Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw3.Columns.Count = 0) Or (Me.dgw3.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw3.Columns
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
						For Each obj2 As Object In CType(Me.dgw3.Rows, IEnumerable)
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

		' Token: 0x0600F780 RID: 63360 RVA: 0x00940DF0 File Offset: 0x0093EFF0
		Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw4.Columns.Count = 0) Or (Me.dgw4.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw4.Columns
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
						For Each obj2 As Object In CType(Me.dgw4.Rows, IEnumerable)
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

		' Token: 0x0600F781 RID: 63361 RVA: 0x0094109C File Offset: 0x0093F29C
		Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw5.Columns.Count = 0) Or (Me.dgw5.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw5.Columns
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
						For Each obj2 As Object In CType(Me.dgw5.Rows, IEnumerable)
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

		' Token: 0x0600F782 RID: 63362 RVA: 0x00941348 File Offset: 0x0093F548
		Private Sub frmGSTR1_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw2.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw2.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw3.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw3.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw3.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw3.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw4.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw4.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw4.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw4.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw5.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw5.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw5.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw5.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F783 RID: 63363 RVA: 0x009415EC File Offset: 0x0093F7EC
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

		' Token: 0x0600F784 RID: 63364 RVA: 0x00941764 File Offset: 0x0093F964
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

		' Token: 0x0600F785 RID: 63365 RVA: 0x00941820 File Offset: 0x0093FA20
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

		' Token: 0x0600F786 RID: 63366 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F787 RID: 63367 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F788 RID: 63368 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F789 RID: 63369 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGSTR1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
