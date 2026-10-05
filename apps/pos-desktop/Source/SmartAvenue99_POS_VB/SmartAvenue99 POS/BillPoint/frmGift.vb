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
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000114 RID: 276
	<DesignerGenerated()>
	Public Partial Class frmGift
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002F10 RID: 12048 RVA: 0x0001DAE7 File Offset: 0x0001BCE7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGift_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerValid_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700125D RID: 4701
		' (get) Token: 0x06002F13 RID: 12051 RVA: 0x0001DB19 File Offset: 0x0001BD19
		' (set) Token: 0x06002F14 RID: 12052 RVA: 0x0001DB23 File Offset: 0x0001BD23
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700125E RID: 4702
		' (get) Token: 0x06002F15 RID: 12053 RVA: 0x0001DB2C File Offset: 0x0001BD2C
		' (set) Token: 0x06002F16 RID: 12054 RVA: 0x001D211C File Offset: 0x001D031C
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

		' Token: 0x1700125F RID: 4703
		' (get) Token: 0x06002F17 RID: 12055 RVA: 0x0001DB36 File Offset: 0x0001BD36
		' (set) Token: 0x06002F18 RID: 12056 RVA: 0x001D2160 File Offset: 0x001D0360
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

		' Token: 0x17001260 RID: 4704
		' (get) Token: 0x06002F19 RID: 12057 RVA: 0x0001DB40 File Offset: 0x0001BD40
		' (set) Token: 0x06002F1A RID: 12058 RVA: 0x001D21A4 File Offset: 0x001D03A4
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

		' Token: 0x17001261 RID: 4705
		' (get) Token: 0x06002F1B RID: 12059 RVA: 0x0001DB4A File Offset: 0x0001BD4A
		' (set) Token: 0x06002F1C RID: 12060 RVA: 0x001D21E8 File Offset: 0x001D03E8
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

		' Token: 0x17001262 RID: 4706
		' (get) Token: 0x06002F1D RID: 12061 RVA: 0x0001DB54 File Offset: 0x0001BD54
		' (set) Token: 0x06002F1E RID: 12062 RVA: 0x0001DB5E File Offset: 0x0001BD5E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17001263 RID: 4707
		' (get) Token: 0x06002F1F RID: 12063 RVA: 0x0001DB67 File Offset: 0x0001BD67
		' (set) Token: 0x06002F20 RID: 12064 RVA: 0x0001DB71 File Offset: 0x0001BD71
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17001264 RID: 4708
		' (get) Token: 0x06002F21 RID: 12065 RVA: 0x0001DB7A File Offset: 0x0001BD7A
		' (set) Token: 0x06002F22 RID: 12066 RVA: 0x0001DB84 File Offset: 0x0001BD84
		Friend Overridable Property lblValid As Label

		' Token: 0x17001265 RID: 4709
		' (get) Token: 0x06002F23 RID: 12067 RVA: 0x0001DB8D File Offset: 0x0001BD8D
		' (set) Token: 0x06002F24 RID: 12068 RVA: 0x0001DB97 File Offset: 0x0001BD97
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17001266 RID: 4710
		' (get) Token: 0x06002F25 RID: 12069 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		' (set) Token: 0x06002F26 RID: 12070 RVA: 0x0001DBAA File Offset: 0x0001BDAA
		Friend Overridable Property lblDiscAmt As Label

		' Token: 0x17001267 RID: 4711
		' (get) Token: 0x06002F27 RID: 12071 RVA: 0x0001DBB3 File Offset: 0x0001BDB3
		' (set) Token: 0x06002F28 RID: 12072 RVA: 0x0001DBBD File Offset: 0x0001BDBD
		Friend Overridable Property lblOfferDetail As Label

		' Token: 0x17001268 RID: 4712
		' (get) Token: 0x06002F29 RID: 12073 RVA: 0x0001DBC6 File Offset: 0x0001BDC6
		' (set) Token: 0x06002F2A RID: 12074 RVA: 0x0001DBD0 File Offset: 0x0001BDD0
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001269 RID: 4713
		' (get) Token: 0x06002F2B RID: 12075 RVA: 0x0001DBD9 File Offset: 0x0001BDD9
		' (set) Token: 0x06002F2C RID: 12076 RVA: 0x0001DBE3 File Offset: 0x0001BDE3
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700126A RID: 4714
		' (get) Token: 0x06002F2D RID: 12077 RVA: 0x0001DBEC File Offset: 0x0001BDEC
		' (set) Token: 0x06002F2E RID: 12078 RVA: 0x0001DBF6 File Offset: 0x0001BDF6
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700126B RID: 4715
		' (get) Token: 0x06002F2F RID: 12079 RVA: 0x0001DBFF File Offset: 0x0001BDFF
		' (set) Token: 0x06002F30 RID: 12080 RVA: 0x0001DC09 File Offset: 0x0001BE09
		Friend Overridable Property Label5 As Label

		' Token: 0x1700126C RID: 4716
		' (get) Token: 0x06002F31 RID: 12081 RVA: 0x0001DC12 File Offset: 0x0001BE12
		' (set) Token: 0x06002F32 RID: 12082 RVA: 0x0001DC1C File Offset: 0x0001BE1C
		Friend Overridable Property Label4 As Label

		' Token: 0x1700126D RID: 4717
		' (get) Token: 0x06002F33 RID: 12083 RVA: 0x0001DC25 File Offset: 0x0001BE25
		' (set) Token: 0x06002F34 RID: 12084 RVA: 0x001D222C File Offset: 0x001D042C
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

		' Token: 0x1700126E RID: 4718
		' (get) Token: 0x06002F35 RID: 12085 RVA: 0x0001DC2F File Offset: 0x0001BE2F
		' (set) Token: 0x06002F36 RID: 12086 RVA: 0x001D2270 File Offset: 0x001D0470
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

		' Token: 0x1700126F RID: 4719
		' (get) Token: 0x06002F37 RID: 12087 RVA: 0x0001DC39 File Offset: 0x0001BE39
		' (set) Token: 0x06002F38 RID: 12088 RVA: 0x0001DC43 File Offset: 0x0001BE43
		Friend Overridable Property Label3 As Label

		' Token: 0x17001270 RID: 4720
		' (get) Token: 0x06002F39 RID: 12089 RVA: 0x0001DC4C File Offset: 0x0001BE4C
		' (set) Token: 0x06002F3A RID: 12090 RVA: 0x001D22B4 File Offset: 0x001D04B4
		Private _txtFreeRs As TextBox
		Friend Overridable Property txtFreeRs As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtFreeRs
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtFreeRs_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtFreeRs
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtFreeRs = value
				textBox = Me._txtFreeRs
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001271 RID: 4721
		' (get) Token: 0x06002F3B RID: 12091 RVA: 0x0001DC56 File Offset: 0x0001BE56
		' (set) Token: 0x06002F3C RID: 12092 RVA: 0x0001DC60 File Offset: 0x0001BE60
		Friend Overridable Property Label2 As Label

		' Token: 0x17001272 RID: 4722
		' (get) Token: 0x06002F3D RID: 12093 RVA: 0x0001DC69 File Offset: 0x0001BE69
		' (set) Token: 0x06002F3E RID: 12094 RVA: 0x001D2314 File Offset: 0x001D0514
		Private _txtSaleAmtTo As TextBox
		Friend Overridable Property txtSaleAmtTo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSaleAmtTo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSaleAmtTo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSaleAmtTo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSaleAmtTo = value
				textBox = Me._txtSaleAmtTo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001273 RID: 4723
		' (get) Token: 0x06002F3F RID: 12095 RVA: 0x0001DC73 File Offset: 0x0001BE73
		' (set) Token: 0x06002F40 RID: 12096 RVA: 0x0001DC7D File Offset: 0x0001BE7D
		Friend Overridable Property Label14 As Label

		' Token: 0x17001274 RID: 4724
		' (get) Token: 0x06002F41 RID: 12097 RVA: 0x0001DC86 File Offset: 0x0001BE86
		' (set) Token: 0x06002F42 RID: 12098 RVA: 0x001D2374 File Offset: 0x001D0574
		Private _txtSaleAmtFrom As TextBox
		Friend Overridable Property txtSaleAmtFrom As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSaleAmtFrom
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSaleAmtFrom_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSaleAmtFrom
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSaleAmtFrom = value
				textBox = Me._txtSaleAmtFrom
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001275 RID: 4725
		' (get) Token: 0x06002F43 RID: 12099 RVA: 0x0001DC90 File Offset: 0x0001BE90
		' (set) Token: 0x06002F44 RID: 12100 RVA: 0x001D23D4 File Offset: 0x001D05D4
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

		' Token: 0x17001276 RID: 4726
		' (get) Token: 0x06002F45 RID: 12101 RVA: 0x0001DC9A File Offset: 0x0001BE9A
		' (set) Token: 0x06002F46 RID: 12102 RVA: 0x0001DCA4 File Offset: 0x0001BEA4
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001277 RID: 4727
		' (get) Token: 0x06002F47 RID: 12103 RVA: 0x0001DCAD File Offset: 0x0001BEAD
		' (set) Token: 0x06002F48 RID: 12104 RVA: 0x0001DCB7 File Offset: 0x0001BEB7
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001278 RID: 4728
		' (get) Token: 0x06002F49 RID: 12105 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
		' (set) Token: 0x06002F4A RID: 12106 RVA: 0x0001DCCA File Offset: 0x0001BECA
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001279 RID: 4729
		' (get) Token: 0x06002F4B RID: 12107 RVA: 0x0001DCD3 File Offset: 0x0001BED3
		' (set) Token: 0x06002F4C RID: 12108 RVA: 0x0001DCDD File Offset: 0x0001BEDD
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700127A RID: 4730
		' (get) Token: 0x06002F4D RID: 12109 RVA: 0x0001DCE6 File Offset: 0x0001BEE6
		' (set) Token: 0x06002F4E RID: 12110 RVA: 0x0001DCF0 File Offset: 0x0001BEF0
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700127B RID: 4731
		' (get) Token: 0x06002F4F RID: 12111 RVA: 0x0001DCF9 File Offset: 0x0001BEF9
		' (set) Token: 0x06002F50 RID: 12112 RVA: 0x0001DD03 File Offset: 0x0001BF03
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700127C RID: 4732
		' (get) Token: 0x06002F51 RID: 12113 RVA: 0x0001DD0C File Offset: 0x0001BF0C
		' (set) Token: 0x06002F52 RID: 12114 RVA: 0x0001DD16 File Offset: 0x0001BF16
		Friend Overridable Property lblUser As Label

		' Token: 0x1700127D RID: 4733
		' (get) Token: 0x06002F53 RID: 12115 RVA: 0x0001DD1F File Offset: 0x0001BF1F
		' (set) Token: 0x06002F54 RID: 12116 RVA: 0x0001DD29 File Offset: 0x0001BF29
		Friend Overridable Property Label1 As Label

		' Token: 0x1700127E RID: 4734
		' (get) Token: 0x06002F55 RID: 12117 RVA: 0x0001DD32 File Offset: 0x0001BF32
		' (set) Token: 0x06002F56 RID: 12118 RVA: 0x0001DD3C File Offset: 0x0001BF3C
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x1700127F RID: 4735
		' (get) Token: 0x06002F57 RID: 12119 RVA: 0x0001DD45 File Offset: 0x0001BF45
		' (set) Token: 0x06002F58 RID: 12120 RVA: 0x0001DD4F File Offset: 0x0001BF4F
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17001280 RID: 4736
		' (get) Token: 0x06002F59 RID: 12121 RVA: 0x0001DD58 File Offset: 0x0001BF58
		' (set) Token: 0x06002F5A RID: 12122 RVA: 0x001D2434 File Offset: 0x001D0634
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

		' Token: 0x17001281 RID: 4737
		' (get) Token: 0x06002F5B RID: 12123 RVA: 0x0001DD62 File Offset: 0x0001BF62
		' (set) Token: 0x06002F5C RID: 12124 RVA: 0x001D2478 File Offset: 0x001D0678
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

		' Token: 0x17001282 RID: 4738
		' (get) Token: 0x06002F5D RID: 12125 RVA: 0x0001DD6C File Offset: 0x0001BF6C
		' (set) Token: 0x06002F5E RID: 12126 RVA: 0x001D24BC File Offset: 0x001D06BC
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

		' Token: 0x17001283 RID: 4739
		' (get) Token: 0x06002F5F RID: 12127 RVA: 0x0001DD76 File Offset: 0x0001BF76
		' (set) Token: 0x06002F60 RID: 12128 RVA: 0x001D2500 File Offset: 0x001D0700
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

		' Token: 0x06002F61 RID: 12129 RVA: 0x001D2544 File Offset: 0x001D0744
		Public Sub Reset()
			Me.txtID.Text = "0"
			Me.txtSaleAmtFrom.Text = "0.00"
			Me.txtSaleAmtTo.Text = "0.00"
			Me.txtFreeRs.Text = "0.00"
			Me.dtpDateFrom.Value = DateAndTime.Now
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtSaleAmtFrom.Focus()
			Me.Getdata()
			Me.lblValid.Text = ""
			Me.lblDiscAmt.Text = ""
			Me.lblOfferDetail.Text = ""
		End Sub

		' Token: 0x06002F62 RID: 12130 RVA: 0x001D2628 File Offset: 0x001D0828
		Private Sub frmGift_Load(sender As Object, e As EventArgs)
			Me.CompanyInfoDisplay()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06002F63 RID: 12131 RVA: 0x001D26B8 File Offset: 0x001D08B8
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06002F64 RID: 12132 RVA: 0x001D2958 File Offset: 0x001D0B58
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

		' Token: 0x06002F65 RID: 12133 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002F66 RID: 12134 RVA: 0x001D2A14 File Offset: 0x001D0C14
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

		' Token: 0x06002F67 RID: 12135 RVA: 0x001D2AFC File Offset: 0x001D0CFC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Gift WHERE OfferId=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModFunc.LogFunc(Me.lblUser.Text, "Deleted the gift Offer '" + Me.txtFreeRs.Text + "'")
				MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.Getdata()
				Me.Reset()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				Dim flag2 As Boolean = flag
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F68 RID: 12136 RVA: 0x001D2C14 File Offset: 0x001D0E14
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT OfferId, SellAmountFrom, SellAmountTo, DiscPerc, FromDate,ToDate FROM Gift ORDER BY OfferId", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F69 RID: 12137 RVA: 0x001D2D3C File Offset: 0x001D0F3C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtSaleAmtFrom.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtSaleAmtTo.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtFreeRs.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.dtpDateFrom.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.dtpDateTo.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Me.lblValid.Text = "Offer Validity : " + Me.dtpDateFrom.Value.ToString("dd/MM/yyyy") + " To " + Me.dtpDateTo.Value.ToString("dd/MM/yyyy")
					Me.lblDiscAmt.Text = "Discount Amount : " + Me.CurSym + dataGridViewRow.Cells(3).Value.ToString()
					Me.lblOfferDetail.Text = String.Concat(New String() { "On Sales Amount From : ", Me.CurSym, dataGridViewRow.Cells(1).Value.ToString(), " To ", Me.CurSym, dataGridViewRow.Cells(2).Value.ToString() })
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002F6A RID: 12138 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSaleAmtFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002F6B RID: 12139 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSaleAmtTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002F6C RID: 12140 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFreeRs_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002F6D RID: 12141 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002F6E RID: 12142 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002F6F RID: 12143 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerValid_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002F70 RID: 12144 RVA: 0x001D2F88 File Offset: 0x001D1188
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSaleAmtTo.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSaleAmtTo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSaleAmtTo, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtSaleAmtFrom.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtSaleAmtFrom, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSaleAmtFrom, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtFreeRs.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtFreeRs, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtFreeRs, String.Empty)
			End If
		End Sub

		' Token: 0x06002F71 RID: 12145 RVA: 0x001D307C File Offset: 0x001D127C
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(CurSym) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.CurSym = NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(0), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
				Else
					Me.CurSym = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F72 RID: 12146 RVA: 0x001D316C File Offset: 0x001D136C
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Panel6.BackgroundImage = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06002F73 RID: 12147 RVA: 0x0001DD80 File Offset: 0x0001BF80
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Panel6.BackgroundImage = Resources.offer
		End Sub

		' Token: 0x06002F74 RID: 12148 RVA: 0x001D320C File Offset: 0x001D140C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
				saveFileDialog.Title = "Save Image"
				saveFileDialog.CheckPathExists = True
				saveFileDialog.DefaultExt = "png"
				saveFileDialog.Filter = "Image (*.png)|*.png|All files (*.*)|*.*"
				saveFileDialog.FilterIndex = 0
				saveFileDialog.RestoreDirectory = True
				Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					Using bitmap As Bitmap = New Bitmap(Me.Panel4.Width, Me.Panel4.Height)
						Me.Panel4.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
						bitmap.Save(saveFileDialog.FileName)
					End Using
					MessageBox.Show("Successfully Image Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub

		' Token: 0x06002F75 RID: 12149 RVA: 0x00010F3E File Offset: 0x0000F13E
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x06002F76 RID: 12150 RVA: 0x0001DD94 File Offset: 0x0001BF94
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002F77 RID: 12151 RVA: 0x001D3318 File Offset: 0x001D1518
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSaleAmtFrom.Text, "", False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MessageBox.Show("Please enter on Sale Amount From", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSaleAmtFrom.Focus()
			Else
				flag = Operators.CompareString(Me.txtSaleAmtTo.Text, "", False) = 0
				Dim flag3 As Boolean = flag
				If flag3 Then
					MessageBox.Show("Please enter Sale Amount to", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSaleAmtTo.Focus()
				Else
					flag = Operators.CompareString(Me.txtFreeRs.Text, "", False) = 0
					Dim flag4 As Boolean = flag
					If flag4 Then
						MessageBox.Show("Please enter free Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtFreeRs.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "insert into Gift (SellAmountFrom, SellAmountTo,DiscPerc, FromDate, ToDate) VALUES (@d1, @d2, @d3, @d4, @d5)"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSaleAmtFrom.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtSaleAmtTo.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtFreeRs.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDateFrom.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpDateTo.Value.[Date])
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "Added the new gift offer '" + Me.txtFreeRs.Text + "'")
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
							Me.Reset()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06002F78 RID: 12152 RVA: 0x001D35C4 File Offset: 0x001D17C4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSaleAmtFrom.Text, "", False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MessageBox.Show("Please enter on Sale Amount From", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSaleAmtFrom.Focus()
			Else
				flag = Operators.CompareString(Me.txtSaleAmtTo.Text, "", False) = 0
				Dim flag3 As Boolean = flag
				If flag3 Then
					MessageBox.Show("Please enter Sale Amount to", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSaleAmtTo.Focus()
				Else
					flag = Operators.CompareString(Me.txtFreeRs.Text, "", False) = 0
					Dim flag4 As Boolean = flag
					If flag4 Then
						MessageBox.Show("Please enter free Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtFreeRs.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "UPDATE Gift SET SellAmountFrom=@d1,  SellAmountTo=@d2, DiscPerc=@d3, FromDate=@d4, ToDate=@d5 WHERE OfferId=@d6"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSaleAmtFrom.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtSaleAmtTo.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtFreeRs.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDateFrom.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpDateTo.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtID.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModFunc.LogFunc(Me.lblUser.Text, "Updated the gift offer '" + Me.txtFreeRs.Text + "'")
							MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							Me.Getdata()
							Me.Reset()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06002F79 RID: 12153 RVA: 0x001D3884 File Offset: 0x001D1A84
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04001443 RID: 5187
		Private CurSym As String
	End Class
End Namespace
