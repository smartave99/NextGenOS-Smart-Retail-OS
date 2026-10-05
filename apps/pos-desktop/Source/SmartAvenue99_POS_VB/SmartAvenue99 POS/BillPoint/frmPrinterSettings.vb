Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001D2 RID: 466
	<DesignerGenerated()>
	Public Partial Class frmPrinterSettings
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007970 RID: 31088 RVA: 0x005AB288 File Offset: 0x005A9488
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPrinterSettings_Load
			AddHandler MyBase.Click, AddressOf Me.Card_Click
			Me.a = 0D
			Me.TAC = ""
			Me.isOffer = False
			Me.testval = ""
			Me.CAddress = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002C96 RID: 11414
		' (get) Token: 0x06007973 RID: 31091 RVA: 0x0003C222 File Offset: 0x0003A422
		' (set) Token: 0x06007974 RID: 31092 RVA: 0x0003C22C File Offset: 0x0003A42C
		Friend Overridable Property pnlPrinterSeting As Panel

		' Token: 0x17002C97 RID: 11415
		' (get) Token: 0x06007975 RID: 31093 RVA: 0x0003C235 File Offset: 0x0003A435
		' (set) Token: 0x06007976 RID: 31094 RVA: 0x0003C23F File Offset: 0x0003A43F
		Friend Overridable Property chkShowImageSetting As CheckBox

		' Token: 0x17002C98 RID: 11416
		' (get) Token: 0x06007977 RID: 31095 RVA: 0x0003C248 File Offset: 0x0003A448
		' (set) Token: 0x06007978 RID: 31096 RVA: 0x0003C252 File Offset: 0x0003A452
		Friend Overridable Property chkSettingCashDraw As CheckBox

		' Token: 0x17002C99 RID: 11417
		' (get) Token: 0x06007979 RID: 31097 RVA: 0x0003C25B File Offset: 0x0003A45B
		' (set) Token: 0x0600797A RID: 31098 RVA: 0x0003C265 File Offset: 0x0003A465
		Friend Overridable Property Label196 As Label

		' Token: 0x17002C9A RID: 11418
		' (get) Token: 0x0600797B RID: 31099 RVA: 0x0003C26E File Offset: 0x0003A46E
		' (set) Token: 0x0600797C RID: 31100 RVA: 0x0003C278 File Offset: 0x0003A478
		Friend Overridable Property cmbPrinterType As ComboBox

		' Token: 0x17002C9B RID: 11419
		' (get) Token: 0x0600797D RID: 31101 RVA: 0x0003C281 File Offset: 0x0003A481
		' (set) Token: 0x0600797E RID: 31102 RVA: 0x0003C28B File Offset: 0x0003A48B
		Friend Overridable Property Label197 As Label

		' Token: 0x17002C9C RID: 11420
		' (get) Token: 0x0600797F RID: 31103 RVA: 0x0003C294 File Offset: 0x0003A494
		' (set) Token: 0x06007980 RID: 31104 RVA: 0x0003C29E File Offset: 0x0003A49E
		Friend Overridable Property txtTillID As TextBox

		' Token: 0x17002C9D RID: 11421
		' (get) Token: 0x06007981 RID: 31105 RVA: 0x0003C2A7 File Offset: 0x0003A4A7
		' (set) Token: 0x06007982 RID: 31106 RVA: 0x0003C2B1 File Offset: 0x0003A4B1
		Friend Overridable Property pNlUpiSeting As Panel

		' Token: 0x17002C9E RID: 11422
		' (get) Token: 0x06007983 RID: 31107 RVA: 0x0003C2BA File Offset: 0x0003A4BA
		' (set) Token: 0x06007984 RID: 31108 RVA: 0x0003C2C4 File Offset: 0x0003A4C4
		Friend Overridable Property txtBrandName As TextBox

		' Token: 0x17002C9F RID: 11423
		' (get) Token: 0x06007985 RID: 31109 RVA: 0x0003C2CD File Offset: 0x0003A4CD
		' (set) Token: 0x06007986 RID: 31110 RVA: 0x0003C2D7 File Offset: 0x0003A4D7
		Friend Overridable Property Label191 As Label

		' Token: 0x17002CA0 RID: 11424
		' (get) Token: 0x06007987 RID: 31111 RVA: 0x0003C2E0 File Offset: 0x0003A4E0
		' (set) Token: 0x06007988 RID: 31112 RVA: 0x0003C2EA File Offset: 0x0003A4EA
		Friend Overridable Property txtUPIid As TextBox

		' Token: 0x17002CA1 RID: 11425
		' (get) Token: 0x06007989 RID: 31113 RVA: 0x0003C2F3 File Offset: 0x0003A4F3
		' (set) Token: 0x0600798A RID: 31114 RVA: 0x0003C2FD File Offset: 0x0003A4FD
		Friend Overridable Property Label192 As Label

		' Token: 0x17002CA2 RID: 11426
		' (get) Token: 0x0600798B RID: 31115 RVA: 0x0003C306 File Offset: 0x0003A506
		' (set) Token: 0x0600798C RID: 31116 RVA: 0x0003C310 File Offset: 0x0003A510
		Friend Overridable Property pnlCustomerDisplaySeting As Panel

		' Token: 0x17002CA3 RID: 11427
		' (get) Token: 0x0600798D RID: 31117 RVA: 0x0003C319 File Offset: 0x0003A519
		' (set) Token: 0x0600798E RID: 31118 RVA: 0x0003C323 File Offset: 0x0003A523
		Friend Overridable Property cmbSecDisplay As ComboBox

		' Token: 0x17002CA4 RID: 11428
		' (get) Token: 0x0600798F RID: 31119 RVA: 0x0003C32C File Offset: 0x0003A52C
		' (set) Token: 0x06007990 RID: 31120 RVA: 0x0003C336 File Offset: 0x0003A536
		Friend Overridable Property Label193 As Label

		' Token: 0x17002CA5 RID: 11429
		' (get) Token: 0x06007991 RID: 31121 RVA: 0x0003C33F File Offset: 0x0003A53F
		' (set) Token: 0x06007992 RID: 31122 RVA: 0x0003C349 File Offset: 0x0003A549
		Friend Overridable Property cboxportdisplay_status As ComboBox

		' Token: 0x17002CA6 RID: 11430
		' (get) Token: 0x06007993 RID: 31123 RVA: 0x0003C352 File Offset: 0x0003A552
		' (set) Token: 0x06007994 RID: 31124 RVA: 0x0003C35C File Offset: 0x0003A55C
		Friend Overridable Property Label194 As Label

		' Token: 0x17002CA7 RID: 11431
		' (get) Token: 0x06007995 RID: 31125 RVA: 0x0003C365 File Offset: 0x0003A565
		' (set) Token: 0x06007996 RID: 31126 RVA: 0x0003C36F File Offset: 0x0003A56F
		Friend Overridable Property cboxportdisplay_setting As ComboBox

		' Token: 0x17002CA8 RID: 11432
		' (get) Token: 0x06007997 RID: 31127 RVA: 0x0003C378 File Offset: 0x0003A578
		' (set) Token: 0x06007998 RID: 31128 RVA: 0x0003C382 File Offset: 0x0003A582
		Friend Overridable Property Label195 As Label

		' Token: 0x17002CA9 RID: 11433
		' (get) Token: 0x06007999 RID: 31129 RVA: 0x0003C38B File Offset: 0x0003A58B
		' (set) Token: 0x0600799A RID: 31130 RVA: 0x0003C395 File Offset: 0x0003A595
		Friend Overridable Property pnlQRDisplay As Panel

		' Token: 0x17002CAA RID: 11434
		' (get) Token: 0x0600799B RID: 31131 RVA: 0x0003C39E File Offset: 0x0003A59E
		' (set) Token: 0x0600799C RID: 31132 RVA: 0x0003C3A8 File Offset: 0x0003A5A8
		Friend Overridable Property Label198 As Label

		' Token: 0x17002CAB RID: 11435
		' (get) Token: 0x0600799D RID: 31133 RVA: 0x0003C3B1 File Offset: 0x0003A5B1
		' (set) Token: 0x0600799E RID: 31134 RVA: 0x0003C3BB File Offset: 0x0003A5BB
		Friend Overridable Property baudrateTxt As TextBox

		' Token: 0x17002CAC RID: 11436
		' (get) Token: 0x0600799F RID: 31135 RVA: 0x0003C3C4 File Offset: 0x0003A5C4
		' (set) Token: 0x060079A0 RID: 31136 RVA: 0x0003C3CE File Offset: 0x0003A5CE
		Friend Overridable Property cboxQR_display_status As ComboBox

		' Token: 0x17002CAD RID: 11437
		' (get) Token: 0x060079A1 RID: 31137 RVA: 0x0003C3D7 File Offset: 0x0003A5D7
		' (set) Token: 0x060079A2 RID: 31138 RVA: 0x0003C3E1 File Offset: 0x0003A5E1
		Friend Overridable Property Label199 As Label

		' Token: 0x17002CAE RID: 11438
		' (get) Token: 0x060079A3 RID: 31139 RVA: 0x0003C3EA File Offset: 0x0003A5EA
		' (set) Token: 0x060079A4 RID: 31140 RVA: 0x0003C3F4 File Offset: 0x0003A5F4
		Friend Overridable Property cboxQR_display_setting As ComboBox

		' Token: 0x17002CAF RID: 11439
		' (get) Token: 0x060079A5 RID: 31141 RVA: 0x0003C3FD File Offset: 0x0003A5FD
		' (set) Token: 0x060079A6 RID: 31142 RVA: 0x0003C407 File Offset: 0x0003A607
		Friend Overridable Property Label200 As Label

		' Token: 0x17002CB0 RID: 11440
		' (get) Token: 0x060079A7 RID: 31143 RVA: 0x0003C410 File Offset: 0x0003A610
		' (set) Token: 0x060079A8 RID: 31144 RVA: 0x005AE16C File Offset: 0x005AC36C
		Private _btnQrSeting As GelButton
		Friend Overridable Property btnQrSeting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnQrSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnQrSeting_Click
				Dim gelButton As GelButton = Me._btnQrSeting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnQrSeting = value
				gelButton = Me._btnQrSeting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CB1 RID: 11441
		' (get) Token: 0x060079A9 RID: 31145 RVA: 0x0003C41A File Offset: 0x0003A61A
		' (set) Token: 0x060079AA RID: 31146 RVA: 0x0003C424 File Offset: 0x0003A624
		Friend Overridable Property pnlWeightSeting As Panel

		' Token: 0x17002CB2 RID: 11442
		' (get) Token: 0x060079AB RID: 31147 RVA: 0x0003C42D File Offset: 0x0003A62D
		' (set) Token: 0x060079AC RID: 31148 RVA: 0x0003C437 File Offset: 0x0003A637
		Friend Overridable Property cboxweight_machineport_status As ComboBox

		' Token: 0x17002CB3 RID: 11443
		' (get) Token: 0x060079AD RID: 31149 RVA: 0x0003C440 File Offset: 0x0003A640
		' (set) Token: 0x060079AE RID: 31150 RVA: 0x0003C44A File Offset: 0x0003A64A
		Friend Overridable Property Label189 As Label

		' Token: 0x17002CB4 RID: 11444
		' (get) Token: 0x060079AF RID: 31151 RVA: 0x0003C453 File Offset: 0x0003A653
		' (set) Token: 0x060079B0 RID: 31152 RVA: 0x0003C45D File Offset: 0x0003A65D
		Friend Overridable Property cboxweight_machineport As ComboBox

		' Token: 0x17002CB5 RID: 11445
		' (get) Token: 0x060079B1 RID: 31153 RVA: 0x0003C466 File Offset: 0x0003A666
		' (set) Token: 0x060079B2 RID: 31154 RVA: 0x0003C470 File Offset: 0x0003A670
		Friend Overridable Property Label190 As Label

		' Token: 0x17002CB6 RID: 11446
		' (get) Token: 0x060079B3 RID: 31155 RVA: 0x0003C479 File Offset: 0x0003A679
		' (set) Token: 0x060079B4 RID: 31156 RVA: 0x005AE1B0 File Offset: 0x005AC3B0
		Private _btnWeightSeting As GelButton
		Friend Overridable Property btnWeightSeting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnWeightSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnWeightSeting_Click
				Dim gelButton As GelButton = Me._btnWeightSeting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnWeightSeting = value
				gelButton = Me._btnWeightSeting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CB7 RID: 11447
		' (get) Token: 0x060079B5 RID: 31157 RVA: 0x0003C483 File Offset: 0x0003A683
		' (set) Token: 0x060079B6 RID: 31158 RVA: 0x005AE1F4 File Offset: 0x005AC3F4
		Private _btnUpiSeting As GelButton
		Friend Overridable Property btnUpiSeting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpiSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpiSeting_Click
				Dim gelButton As GelButton = Me._btnUpiSeting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpiSeting = value
				gelButton = Me._btnUpiSeting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CB8 RID: 11448
		' (get) Token: 0x060079B7 RID: 31159 RVA: 0x0003C48D File Offset: 0x0003A68D
		' (set) Token: 0x060079B8 RID: 31160 RVA: 0x005AE238 File Offset: 0x005AC438
		Private _btnCustomerdISPLAYSeting As GelButton
		Friend Overridable Property btnCustomerdISPLAYSeting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCustomerdISPLAYSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCustomerdISPLAYSeting_Click
				Dim gelButton As GelButton = Me._btnCustomerdISPLAYSeting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCustomerdISPLAYSeting = value
				gelButton = Me._btnCustomerdISPLAYSeting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CB9 RID: 11449
		' (get) Token: 0x060079B9 RID: 31161 RVA: 0x0003C497 File Offset: 0x0003A697
		' (set) Token: 0x060079BA RID: 31162 RVA: 0x005AE27C File Offset: 0x005AC47C
		Private _btnPrinterSetting As GelButton
		Friend Overridable Property btnPrinterSetting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrinterSetting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrinterSetting_Click
				Dim gelButton As GelButton = Me._btnPrinterSetting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrinterSetting = value
				gelButton = Me._btnPrinterSetting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CBA RID: 11450
		' (get) Token: 0x060079BB RID: 31163 RVA: 0x0003C4A1 File Offset: 0x0003A6A1
		' (set) Token: 0x060079BC RID: 31164 RVA: 0x0003C4AB File Offset: 0x0003A6AB
		Friend Overridable Property cmbPrinter As ComboBox

		' Token: 0x17002CBB RID: 11451
		' (get) Token: 0x060079BD RID: 31165 RVA: 0x0003C4B4 File Offset: 0x0003A6B4
		' (set) Token: 0x060079BE RID: 31166 RVA: 0x0003C4BE File Offset: 0x0003A6BE
		Friend Overridable Property GelButton24 As GelButton

		' Token: 0x17002CBC RID: 11452
		' (get) Token: 0x060079BF RID: 31167 RVA: 0x0003C4C7 File Offset: 0x0003A6C7
		' (set) Token: 0x060079C0 RID: 31168 RVA: 0x0003C4D1 File Offset: 0x0003A6D1
		Friend Overridable Property GelButton25 As GelButton

		' Token: 0x17002CBD RID: 11453
		' (get) Token: 0x060079C1 RID: 31169 RVA: 0x0003C4DA File Offset: 0x0003A6DA
		' (set) Token: 0x060079C2 RID: 31170 RVA: 0x005AE2C0 File Offset: 0x005AC4C0
		Private _GelButton11 As GelButton
		Friend Overridable Property GelButton11 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton11_Click
				Dim gelButton As GelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton11 = value
				gelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CBE RID: 11454
		' (get) Token: 0x060079C3 RID: 31171 RVA: 0x0003C4E4 File Offset: 0x0003A6E4
		' (set) Token: 0x060079C4 RID: 31172 RVA: 0x005AE304 File Offset: 0x005AC504
		Private _dgwBill As DataGridView
		Friend Overridable Property dgwBill As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgwBill
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgwBill_MouseClick
				Dim dataGridView As DataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgwBill = value
				dataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CBF RID: 11455
		' (get) Token: 0x060079C5 RID: 31173 RVA: 0x0003C4EE File Offset: 0x0003A6EE
		' (set) Token: 0x060079C6 RID: 31174 RVA: 0x0003C4F8 File Offset: 0x0003A6F8
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17002CC0 RID: 11456
		' (get) Token: 0x060079C7 RID: 31175 RVA: 0x0003C501 File Offset: 0x0003A701
		' (set) Token: 0x060079C8 RID: 31176 RVA: 0x0003C50B File Offset: 0x0003A70B
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17002CC1 RID: 11457
		' (get) Token: 0x060079C9 RID: 31177 RVA: 0x0003C514 File Offset: 0x0003A714
		' (set) Token: 0x060079CA RID: 31178 RVA: 0x0003C51E File Offset: 0x0003A71E
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17002CC2 RID: 11458
		' (get) Token: 0x060079CB RID: 31179 RVA: 0x0003C527 File Offset: 0x0003A727
		' (set) Token: 0x060079CC RID: 31180 RVA: 0x0003C531 File Offset: 0x0003A731
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17002CC3 RID: 11459
		' (get) Token: 0x060079CD RID: 31181 RVA: 0x0003C53A File Offset: 0x0003A73A
		' (set) Token: 0x060079CE RID: 31182 RVA: 0x005AE348 File Offset: 0x005AC548
		Private _RAll As RadioButton
		Friend Overridable Property RAll As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RAll_CheckedChanged
				Dim radioButton As RadioButton = Me._RAll
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RAll = value
				radioButton = Me._RAll
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CC4 RID: 11460
		' (get) Token: 0x060079CF RID: 31183 RVA: 0x0003C544 File Offset: 0x0003A744
		' (set) Token: 0x060079D0 RID: 31184 RVA: 0x005AE38C File Offset: 0x005AC58C
		Private _R3Inch As RadioButton
		Friend Overridable Property R3Inch As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._R3Inch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.R3Inch_CheckedChanged
				Dim radioButton As RadioButton = Me._R3Inch
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._R3Inch = value
				radioButton = Me._R3Inch
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CC5 RID: 11461
		' (get) Token: 0x060079D1 RID: 31185 RVA: 0x0003C54E File Offset: 0x0003A74E
		' (set) Token: 0x060079D2 RID: 31186 RVA: 0x005AE3D0 File Offset: 0x005AC5D0
		Private _RA5 As RadioButton
		Friend Overridable Property RA5 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RA5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RA5_CheckedChanged
				Dim radioButton As RadioButton = Me._RA5
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RA5 = value
				radioButton = Me._RA5
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CC6 RID: 11462
		' (get) Token: 0x060079D3 RID: 31187 RVA: 0x0003C558 File Offset: 0x0003A758
		' (set) Token: 0x060079D4 RID: 31188 RVA: 0x005AE414 File Offset: 0x005AC614
		Private _RA4 As RadioButton
		Friend Overridable Property RA4 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RA4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RA4_CheckedChanged
				Dim radioButton As RadioButton = Me._RA4
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RA4 = value
				radioButton = Me._RA4
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CC7 RID: 11463
		' (get) Token: 0x060079D5 RID: 31189 RVA: 0x0003C562 File Offset: 0x0003A762
		' (set) Token: 0x060079D6 RID: 31190 RVA: 0x0003C56C File Offset: 0x0003A76C
		Friend Overridable Property PictureBox5 As PictureBox

		' Token: 0x17002CC8 RID: 11464
		' (get) Token: 0x060079D7 RID: 31191 RVA: 0x0003C575 File Offset: 0x0003A775
		' (set) Token: 0x060079D8 RID: 31192 RVA: 0x0003C57F File Offset: 0x0003A77F
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17002CC9 RID: 11465
		' (get) Token: 0x060079D9 RID: 31193 RVA: 0x0003C588 File Offset: 0x0003A788
		' (set) Token: 0x060079DA RID: 31194 RVA: 0x0003C592 File Offset: 0x0003A792
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17002CCA RID: 11466
		' (get) Token: 0x060079DB RID: 31195 RVA: 0x0003C59B File Offset: 0x0003A79B
		' (set) Token: 0x060079DC RID: 31196 RVA: 0x0003C5A5 File Offset: 0x0003A7A5
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17002CCB RID: 11467
		' (get) Token: 0x060079DD RID: 31197 RVA: 0x0003C5AE File Offset: 0x0003A7AE
		' (set) Token: 0x060079DE RID: 31198 RVA: 0x0003C5B8 File Offset: 0x0003A7B8
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17002CCC RID: 11468
		' (get) Token: 0x060079DF RID: 31199 RVA: 0x0003C5C1 File Offset: 0x0003A7C1
		' (set) Token: 0x060079E0 RID: 31200 RVA: 0x0003C5CB File Offset: 0x0003A7CB
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17002CCD RID: 11469
		' (get) Token: 0x060079E1 RID: 31201 RVA: 0x0003C5D4 File Offset: 0x0003A7D4
		' (set) Token: 0x060079E2 RID: 31202 RVA: 0x005AE458 File Offset: 0x005AC658
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

		' Token: 0x17002CCE RID: 11470
		' (get) Token: 0x060079E3 RID: 31203 RVA: 0x0003C5DE File Offset: 0x0003A7DE
		' (set) Token: 0x060079E4 RID: 31204 RVA: 0x0003C5E8 File Offset: 0x0003A7E8
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17002CCF RID: 11471
		' (get) Token: 0x060079E5 RID: 31205 RVA: 0x0003C5F1 File Offset: 0x0003A7F1
		' (set) Token: 0x060079E6 RID: 31206 RVA: 0x0003C5FB File Offset: 0x0003A7FB
		Friend Overridable Property FlowPanelBill As FlowLayoutPanel

		' Token: 0x060079E7 RID: 31207
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060079E8 RID: 31208
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060079E9 RID: 31209 RVA: 0x005AE49C File Offset: 0x005AC69C
		Private Sub btnCustomerdISPLAYSeting_Click(sender As Object, e As EventArgs)
			Me.pnlPrinterSeting.Visible = False
			Me.pnlCustomerDisplaySeting.Visible = True
			Me.pNlUpiSeting.Visible = False
			Me.pnlQRDisplay.Visible = False
			Me.pnlWeightSeting.Visible = False
		End Sub

		' Token: 0x060079EA RID: 31210 RVA: 0x005AE4EC File Offset: 0x005AC6EC
		Private Sub btnPrinterSetting_Click(sender As Object, e As EventArgs)
			Me.pnlCustomerDisplaySeting.Visible = False
			Me.pNlUpiSeting.Visible = False
			Me.pnlQRDisplay.Visible = False
			Me.pnlWeightSeting.Visible = False
			Me.pnlPrinterSeting.Visible = True
		End Sub

		' Token: 0x060079EB RID: 31211 RVA: 0x005AE53C File Offset: 0x005AC73C
		Private Sub btnUpiSeting_Click(sender As Object, e As EventArgs)
			Me.pnlPrinterSeting.Visible = False
			Me.pnlCustomerDisplaySeting.Visible = False
			Me.pNlUpiSeting.Visible = True
			Me.pnlQRDisplay.Visible = False
			Me.pnlWeightSeting.Visible = False
		End Sub

		' Token: 0x060079EC RID: 31212 RVA: 0x005AE58C File Offset: 0x005AC78C
		Private Sub btnWeightSeting_Click(sender As Object, e As EventArgs)
			Me.pnlPrinterSeting.Visible = False
			Me.pnlCustomerDisplaySeting.Visible = False
			Me.pNlUpiSeting.Visible = False
			Me.pnlQRDisplay.Visible = False
			Me.pnlWeightSeting.Visible = True
		End Sub

		' Token: 0x060079ED RID: 31213 RVA: 0x005AE5DC File Offset: 0x005AC7DC
		Private Sub btnQrSeting_Click(sender As Object, e As EventArgs)
			Me.pnlPrinterSeting.Visible = False
			Me.pnlCustomerDisplaySeting.Visible = False
			Me.pNlUpiSeting.Visible = False
			Me.pnlQRDisplay.Visible = True
			Me.pnlWeightSeting.Visible = False
		End Sub

		' Token: 0x060079EE RID: 31214 RVA: 0x005AE62C File Offset: 0x005AC82C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.strSetting_type = "Bill Design"
			Dim flag As Boolean = Operators.CompareString(Me.StyleId, "", False) <> 0
			If flag Then
				Dim num As Integer = Me.ComboBox1.Items.Count - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.ComboBox1.Items(i).ToString(), Me.testval, False)
					If flag2 Then
						Me.ComboBox1.SelectedIndex = i
					End If
				Next
				Me.defaulyprintersave()
			Else
				MessageBox.Show("Bill Style Not Selected!")
			End If
			MyBase.Close()
			MyProject.Forms.frmPOSNewTuch.ComboBox1.Text = Me.ComboBox1.Text
		End Sub

		' Token: 0x060079EF RID: 31215 RVA: 0x0003C604 File Offset: 0x0003A804
		Private Sub frmPrinterSettings_Load(sender As Object, e As EventArgs)
			Me.DefaulTerminalSet()
			Me.Getdata()
			Me.PopulateInstalledPrintersCombo()
			Me.DisplayPrinterSetting()
		End Sub

		' Token: 0x060079F0 RID: 31216 RVA: 0x005AE6F4 File Offset: 0x005AC8F4
		Private Sub DisplayPrinterSetting()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select a.*,b.PrintPreviewType, b.BillStyleImage, b.BillStyleName from PosPrinterSetting a left join BillPreview b on a.BillStyleId = b.BillStyleId where a.TillID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim text2 As String = ModCommonClasses.rdr("PrinterName").ToString().Trim()
				Me.cmbPrinter.Text = text2
				Dim text3 As String = ModCommonClasses.rdr("PrinterType").ToString().Trim()
				Me.cmbPrinterType.Text = text3
				Dim flag2 As Boolean = Operators.CompareString(ModCommonClasses.rdr("CashDrawer").ToString(), "No", False) = 0
				If flag2 Then
					Me.chkSettingCashDraw.Checked = False
				Else
					Me.chkSettingCashDraw.Checked = True
				End If
				Me.cboxweight_machineport.Text = ModCommonClasses.rdr("WSPort").ToString().Trim()
				Me.cboxweight_machineport_status.Text = ModCommonClasses.rdr("ActiveWS").ToString().Trim()
				Me.cboxportdisplay_setting.Text = ModCommonClasses.rdr("CDPort").ToString().Trim()
				Me.cboxportdisplay_status.Text = ModCommonClasses.rdr("CustomerDisplay").ToString().Trim()
				Me.cmbSecDisplay.Text = ModCommonClasses.rdr("SecDisplay").ToString().Trim()
				Me.cboxQR_display_setting.Text = ModCommonClasses.rdr("QRDisplayPort").ToString().Trim()
				Me.baudrateTxt.Text = ModCommonClasses.rdr("BundRate").ToString().Trim()
				Me.cboxQR_display_status.Text = ModCommonClasses.rdr("ActiveQR").ToString().Trim()
				Me.txtUPIid.Text = ModCommonClasses.rdr("UPIID").ToString().Trim()
				Me.txtBrandName.Text = ModCommonClasses.rdr("BrandName").ToString().Trim()
				Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr("PT").ToString(), "No", False) = 0
				If flag3 Then
					Me.chkShowImageSetting.Checked = False
				Else
					Me.chkShowImageSetting.Checked = True
				End If
				Me.StyleId = ModCommonClasses.rdr("BillStyleId").ToString().Trim()
				Dim text4 As String = ModCommonClasses.rdr("PrintPreviewType").ToString().Trim()
				Dim flag4 As Boolean = Operators.CompareString(text4, "A4", False) = 0
				If flag4 Then
					Me.RA4.Checked = True
				Else
					Dim flag5 As Boolean = Operators.CompareString(text4, "A5", False) = 0
					If flag5 Then
						Me.RA5.Checked = True
					Else
						Dim flag6 As Boolean = Operators.CompareString(text4, "3Inch", False) = 0
						If flag6 Then
							Me.R3Inch.Checked = True
						Else
							Me.RAll.Checked = True
						End If
					End If
				End If
				Dim text5 As String = ModCommonClasses.rdr("BillStyleImage").ToString().Trim()
				Dim flag7 As Boolean = Operators.CompareString(text5, "", False) <> 0
				If flag7 Then
					Dim text6 As String = Application.StartupPath + "\BillImg\" + text5
					Dim flag8 As Boolean = File.Exists(text6)
					If flag8 Then
						Me.PictureBox5.Image = Image.FromFile(text6)
						Me.ComboBox1.Text = ModCommonClasses.rdr("BillStyleName").ToString().Trim()
					Else
						MessageBox.Show("Image file not found: " + text6)
					End If
				End If
				Try
					For Each obj As Object In CType(Me.dgwBill.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag9 As Boolean = dataGridViewRow.Cells(0).Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells(0).Value.ToString().Trim(), Me.StyleId, False) = 0
						If flag9 Then
							Me.PictureBox5.Image = Image.FromFile(Application.StartupPath + "\BillImg\" + dataGridViewRow.Cells(3).Value.ToString())
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
							Me.ComboBox1.Text = dataGridViewRow.Cells(1).Value.ToString().Trim()
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag10 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
		End Sub

		' Token: 0x060079F1 RID: 31217 RVA: 0x005AEC68 File Offset: 0x005ACE68
		Private Sub PopulateInstalledPrintersCombo()
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbPrinter.Items.Clear()
				Dim num As Integer = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
				For i As Integer = 0 To num
					Dim text As String = System.Drawing.Printing.PrinterSettings.InstalledPrinters(i)
					Me.cmbPrinter.Items.Add(text)
				Next
				Dim printerSettings As PrinterSettings = New PrinterSettings()
				Dim printerName As String = printerSettings.PrinterName
				Me.cmbPrinter.Text = printerName
				Me.txtTillID.Text = Dns.GetHostName()
				Dim portNames As String() = SerialPort.GetPortNames()
				For Each text2 As String In portNames
					Me.cboxweight_machineport.Items.Add(text2)
					Me.cboxportdisplay_setting.Items.Add(text2)
					Me.cboxQR_display_setting.Items.Add(text2)
				Next
				Me.cboxweight_machineport.SelectedIndex = -1
				Me.cboxportdisplay_setting.SelectedIndex = -1
				Me.cboxQR_display_setting.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060079F2 RID: 31218 RVA: 0x005AEDBC File Offset: 0x005ACFBC
		Public Sub Getdata()
			Try
				Me.FlowPanelBill.Controls.Clear()
				Dim text As String = ""
				Dim checked As Boolean = Me.RA4.Checked
				If checked Then
					text = "A4"
				Else
					Dim checked2 As Boolean = Me.RA5.Checked
					If checked2 Then
						text = "A5"
					Else
						Dim checked3 As Boolean = Me.R3Inch.Checked
						If checked3 Then
							text = "3Inch"
						End If
					End If
				End If
				Dim text2 As String = "SELECT BillStyleId, BillStyleName, PrintPreviewType, BillStyleImage " & vbCrLf & "             FROM BillPreview WHERE 1=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " AND PrintPreviewType='" + text + "'"
				End If
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							While sqlDataReader.Read()

								Dim card As Panel = New Panel() With { .Width = 150, .Height = 150, .Margin = New Padding(12), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle, .Tag = RuntimeHelpers.GetObjectValue(sqlDataReader("BillStyleId")) }

								Dim text3 As String = sqlDataReader("BillStyleImage").ToString().Trim()

								Dim text4 As String = Application.StartupPath + "\BillImg\" + text3

								Dim pictureBox As PictureBox = New PictureBox() With { .Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.StretchImage, .BackColor = Color.White }

								Dim flag2 As Boolean = File.Exists(text4)

								If flag2 Then

									pictureBox.Image = Image.FromFile(text4)

								Else

									pictureBox.BackColor = Color.LightGray

								End If

								AddHandler pictureBox.Click, AddressOf Me.Card_Click

								AddHandler card.Click, AddressOf Me.Card_Click

								AddHandler card.MouseEnter, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.Fixed3D

								End Sub

								AddHandler card.MouseLeave, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.FixedSingle

								End Sub

								AddHandler pictureBox.MouseEnter, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.Fixed3D

								End Sub

								AddHandler pictureBox.MouseLeave, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.FixedSingle

								End Sub

								card.Controls.Add(pictureBox)

								Me.FlowPanelBill.Controls.Add(card)

							End While

						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060079F3 RID: 31219 RVA: 0x005AF0F0 File Offset: 0x005AD2F0
		Private Sub Card_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = TypeOf sender Is Panel
				Dim panel As Panel
				If flag Then
					panel = CType(sender, Panel)
				Else
					panel = CType(CType(sender, Control).Parent, Panel)
				End If
				Dim num As Integer = Conversions.ToInteger(panel.Tag)
				Me.StyleId = Conversions.ToString(num)
				Dim text As String = ""
				Dim text2 As String = "SELECT BillStyleId, BillStyleName, PrintPreviewType, BillStyleImage " & vbCrLf & "             FROM BillPreview " & vbCrLf & "             WHERE BillStyleId=" + Conversions.ToString(num)
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag2 As Boolean = sqlDataReader.Read()
							If Not flag2 Then
								MessageBox.Show("Record not found!", "Warning")
								Return
							End If
							Me.StyleId = sqlDataReader("BillStyleId").ToString()
							Me.testval = sqlDataReader("BillStyleName").ToString()
							Dim text3 As String = sqlDataReader("PrintPreviewType").ToString()
							text = sqlDataReader("BillStyleImage").ToString()
							Dim flag3 As Boolean = (Operators.CompareString(text3, "A4", False) = 0) Or (Operators.CompareString(text3, "A5", False) = 0)
							If flag3 Then
								Me.cmbPrinterType.Text = "Laser Printer"
							Else
								Me.cmbPrinterType.Text = "Thermal Printer"
							End If
						End Using
					End Using
				End Using
				Dim flag4 As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag4 Then
					Dim text4 As String = Application.StartupPath + "\BillImg\" + text
					Dim flag5 As Boolean = File.Exists(text4)
					If flag5 Then
						Me.PictureBox5.Image = Image.FromFile(text4)
					Else
						MessageBox.Show("Image file not found: " + text4)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060079F4 RID: 31220 RVA: 0x005AF374 File Offset: 0x005AD574
		Public Sub Getdata_ForGrid()
			Try
				Dim text As String = ""
				Dim checked As Boolean = Me.RA4.Checked
				If checked Then
					text = "A4"
				Else
					Dim checked2 As Boolean = Me.RA5.Checked
					If checked2 Then
						text = "A5"
					Else
						Dim checked3 As Boolean = Me.R3Inch.Checked
						If checked3 Then
							text = "3Inch"
						End If
					End If
				End If
				Dim text2 As String = "Select BillStyleId,BillStyleName,PrintPreviewType,BillStyleImage from BillPreview where 1=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwBill.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwBill.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwBill.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060079F5 RID: 31221 RVA: 0x0003C623 File Offset: 0x0003A823
		Private Sub RA4_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060079F6 RID: 31222 RVA: 0x0003C623 File Offset: 0x0003A823
		Private Sub RA5_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060079F7 RID: 31223 RVA: 0x0003C623 File Offset: 0x0003A823
		Private Sub R3Inch_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060079F8 RID: 31224 RVA: 0x0003C623 File Offset: 0x0003A823
		Private Sub RAll_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060079F9 RID: 31225 RVA: 0x005AF518 File Offset: 0x005AD718
		Private Sub dgwBill_MouseClick(sender As Object, e As MouseEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.dgwBill.SelectedRows(0)
			Me.PictureBox5.Image = Image.FromFile(Application.StartupPath + "\BillImg\" + dataGridViewRow.Cells(3).Value.ToString())
			Me.testval = dataGridViewRow.Cells(1).Value.ToString()
			Me.StyleId = dataGridViewRow.Cells(0).Value.ToString()
			Dim text As String = dataGridViewRow.Cells(2).Value.ToString()
			Dim flag As Boolean = Operators.CompareString(text, "A4", False) = 0
			If flag Then
				Me.cmbPrinterType.Text = "Laser Printer"
			Else
				Dim flag2 As Boolean = Operators.CompareString(text, "A5", False) = 0
				If flag2 Then
					Me.cmbPrinterType.Text = "Laser Printer"
				Else
					Me.cmbPrinterType.Text = "Thermal Printer"
				End If
			End If
		End Sub

		' Token: 0x060079FA RID: 31226 RVA: 0x0031C39C File Offset: 0x0031A59C
		Public Sub DefaulTerminalSet()
			Try
				Dim printerSettings As PrinterSettings = New PrinterSettings()
				Dim printerName As String = printerSettings.PrinterName
				Dim hostName As String = Dns.GetHostName()
				Dim portNames As String() = SerialPort.GetPortNames()
				For Each text As String In portNames
				Next
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "select tillID from PosPrinterSetting where TillID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", hostName.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "insert into PosPrinterSetting(TillID,PrinterName,PrinterType,CashDrawer,WSPort,ActiveWS,CDPort,CustomerDisplay,SecDisplay,QRDisplayPort,ActiveQR,BundRate,UPIID,BrandName,PT,BillStyleId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", hostName.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", printerName.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "Thermal Printer")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "No")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "No")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "No")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "No")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d11", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Yes")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d16", 21)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060079FB RID: 31227 RVA: 0x005AF620 File Offset: 0x005AD820
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			Me.strSetting_type = "Bill Setting"
			Dim flag As Boolean = Operators.CompareString(Me.StyleId, "", False) <> 0
			If flag Then
				Dim num As Integer = Me.ComboBox1.Items.Count - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.ComboBox1.Items(i).ToString(), Me.testval, False)
					If flag2 Then
						Me.ComboBox1.SelectedIndex = i
					End If
				Next
				Me.defaulyprintersave()
			Else
				MessageBox.Show("Bill Style Not Selected!")
			End If
			MyBase.Close()
			MyProject.Forms.frmPOSNewTuch.ComboBox1.Text = Me.ComboBox1.Text
		End Sub

		' Token: 0x060079FC RID: 31228 RVA: 0x005AF6E8 File Offset: 0x005AD8E8
		Private Sub defaulyprintersave()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTillID.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinterType.Focus()
					Else
						Dim checked As Boolean = Me.chkShowImageSetting.Checked
						Dim text2 As String
						If checked Then
							text2 = "Yes"
						Else
							text2 = "No"
						End If
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "select tillID from PosPrinterSetting where TillID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								Dim flag6 As Boolean = Operators.CompareString(Me.strSetting_type, "Bill Design", False) = 0
								If flag6 Then
									Me.defaulyprinterUpdate_Design()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.strSetting_type, "Bill Setting", False) = 0
									If flag7 Then
										Me.defaulyprinterUpdate_Setting()
									End If
								End If
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Dim flag9 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
								If flag9 Then
									MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbPrinter.Focus()
								Else
									Dim checked2 As Boolean = Me.chkShowImageSetting.Checked
									Dim text4 As String
									If checked2 Then
										text4 = "Yes"
									Else
										text4 = "No"
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text5 As String = "insert into PosPrinterSetting(TillID,PrinterName,PrinterType,CashDrawer,WSPort,ActiveWS,CDPort,CustomerDisplay,SecDisplay,QRDisplayPort,ActiveQR,BundRate,UPIID,BrandName,PT,BillStyleId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
									ModCommonClasses.cmd = New SqlCommand(text5)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinter.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbPrinterType.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cboxweight_machineport.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cboxweight_machineport_status.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cboxportdisplay_setting.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cboxportdisplay_status.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbSecDisplay.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cboxQR_display_setting.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.cboxQR_display_status.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.baudrateTxt.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtUPIid.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtBrandName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.StyleId)
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									MessageBox.Show("Successfully Saved", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.DisplayPrinterSetting()
								End If
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060079FD RID: 31229 RVA: 0x005AFC10 File Offset: 0x005ADE10
		Private Sub defaulyprinterUpdate_Design()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTillID.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinterType.Focus()
					Else
						Dim checked As Boolean = Me.chkShowImageSetting.Checked
						If checked Then
						End If
						Try
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbPrinter.Focus()
							Else
								Dim checked2 As Boolean = Me.chkShowImageSetting.Checked
								If checked2 Then
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "update PosPrinterSetting set PrinterType=@d2,BillStyleId=@d15 where TillID=@d16"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtTillID.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinterType.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.StyleId)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.DisplayPrinterSetting()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060079FE RID: 31230 RVA: 0x005AFECC File Offset: 0x005AE0CC
		Private Sub defaulyprinterUpdate_Setting()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTillID.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinterType.Focus()
					Else
						Dim checked As Boolean = Me.chkShowImageSetting.Checked
						Dim text2 As String
						If checked Then
							text2 = "Yes"
						Else
							text2 = "No"
						End If
						Try
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbPrinter.Focus()
							Else
								Dim checked2 As Boolean = Me.chkShowImageSetting.Checked
								Dim text3 As String
								If checked2 Then
									text3 = "Yes"
								Else
									text3 = "No"
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "update PosPrinterSetting set PrinterName=@d1,PrinterType=@d2,CashDrawer=@d3,WSPort=@d4,ActiveWS=@d5,CDPort=@d6,CustomerDisplay=@d7,SecDisplay=@d8,QRDisplayPort=@d9,ActiveQR=@d10,BundRate=@d11,UPIID=@d12,BrandName=@d13,PT=@d14 where TillID=@d16"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtTillID.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbPrinter.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinterType.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cboxweight_machineport.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cboxweight_machineport_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cboxportdisplay_setting.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cboxportdisplay_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cmbSecDisplay.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cboxQR_display_setting.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cboxQR_display_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.baudrateTxt.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtUPIid.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtBrandName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", text2)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.DisplayPrinterSetting()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060079FF RID: 31231 RVA: 0x005B02F8 File Offset: 0x005AE4F8
		Private Sub defaulyprinterUpdate()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTillID.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinterType.Focus()
					Else
						Dim checked As Boolean = Me.chkShowImageSetting.Checked
						Dim text2 As String
						If checked Then
							text2 = "Yes"
						Else
							text2 = "No"
						End If
						Try
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbPrinter.Focus()
							Else
								Dim checked2 As Boolean = Me.chkShowImageSetting.Checked
								Dim text3 As String
								If checked2 Then
									text3 = "Yes"
								Else
									text3 = "No"
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "update PosPrinterSetting set PrinterName=@d1,PrinterType=@d2,CashDrawer=@d3,WSPort=@d4,ActiveWS=@d5,CDPort=@d6,CustomerDisplay=@d7,SecDisplay=@d8,QRDisplayPort=@d9,ActiveQR=@d10,BundRate=@d11,UPIID=@d12,BrandName=@d13,PT=@d14,BillStyleId=@d15 where TillID=@d16"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtTillID.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbPrinter.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinterType.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cboxweight_machineport.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cboxweight_machineport_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cboxportdisplay_setting.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cboxportdisplay_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cmbSecDisplay.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cboxQR_display_setting.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cboxQR_display_status.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.baudrateTxt.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtUPIid.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtBrandName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.StyleId)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.DisplayPrinterSetting()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06007A00 RID: 31232 RVA: 0x005B0740 File Offset: 0x005AE940
		Private Sub EnterSetting_Reset()
			Me.cmbPrinter.Text = ""
			Me.cmbPrinter.SelectedIndex = -1
			Dim printerSettings As PrinterSettings = New PrinterSettings()
			Dim printerName As String = printerSettings.PrinterName
			Me.cmbPrinter.Text = printerName
			Me.cmbPrinterType.SelectedIndex = -1
			Me.txtTillID.Text = Dns.GetHostName()
			Me.txtTillID.Focus()
			Me.cboxweight_machineport_status.SelectedIndex = 0
			Me.cboxportdisplay_status.SelectedIndex = 0
			Me.cboxweight_machineport.Text = ""
			Me.cboxportdisplay_setting.Text = ""
			Me.cboxQR_display_setting.Text = ""
			Me.cboxQR_display_status.Text = ""
			Me.baudrateTxt.Text = ""
			Me.txtUPIid.Text = ""
			Me.txtBrandName.Text = ""
			Me.cmbSecDisplay.SelectedIndex = 0
		End Sub

		' Token: 0x040035F3 RID: 13811
		Private str As String

		' Token: 0x040035F4 RID: 13812
		Private st2 As String

		' Token: 0x040035F5 RID: 13813
		Private num1 As Double

		' Token: 0x040035F6 RID: 13814
		Private num2 As Double

		' Token: 0x040035F7 RID: 13815
		Private num3 As Double

		' Token: 0x040035F8 RID: 13816
		Private num4 As Double

		' Token: 0x040035F9 RID: 13817
		Private num5 As Double

		' Token: 0x040035FA RID: 13818
		Private num6 As Double

		' Token: 0x040035FB RID: 13819
		Private num7 As Double

		' Token: 0x040035FC RID: 13820
		Private num8 As Double

		' Token: 0x040035FD RID: 13821
		Private num9 As Double

		' Token: 0x040035FE RID: 13822
		Private num10 As Double

		' Token: 0x040035FF RID: 13823
		Private num11 As Double

		' Token: 0x04003600 RID: 13824
		Private num1x As Double

		' Token: 0x04003601 RID: 13825
		Private TotItemDiscAmt As Double

		' Token: 0x04003602 RID: 13826
		Private x1 As Double

		' Token: 0x04003603 RID: 13827
		Private x2 As Double

		' Token: 0x04003604 RID: 13828
		Private loyalitybal As Double

		' Token: 0x04003605 RID: 13829
		Private CompanyLoyalityValue As Double

		' Token: 0x04003606 RID: 13830
		Private a As Decimal

		' Token: 0x04003607 RID: 13831
		Private s4 As String

		' Token: 0x04003608 RID: 13832
		Private s1 As String

		' Token: 0x04003609 RID: 13833
		Private custsecdisplay As String

		' Token: 0x0400360A RID: 13834
		Private PName As String

		' Token: 0x0400360B RID: 13835
		Private C1 As String

		' Token: 0x0400360C RID: 13836
		Private C2 As String

		' Token: 0x0400360D RID: 13837
		Private C3 As String

		' Token: 0x0400360E RID: 13838
		Private C4 As String

		' Token: 0x0400360F RID: 13839
		Private TAC As String

		' Token: 0x04003610 RID: 13840
		Private wappno As String

		' Token: 0x04003611 RID: 13841
		Private taxid1 As Integer

		' Token: 0x04003612 RID: 13842
		Private isOffer As Boolean

		' Token: 0x04003613 RID: 13843
		Private testval As Object

		' Token: 0x04003614 RID: 13844
		Private strSetting_type As String

		' Token: 0x04003615 RID: 13845
		Public comSerial As SerialPort

		' Token: 0x04003616 RID: 13846
		Private StyleId As String

		' Token: 0x04003617 RID: 13847
		Private strSearchtype As String

		' Token: 0x04003618 RID: 13848
		Private printStatus As String

		' Token: 0x04003619 RID: 13849
		Public CAddress As String
	End Class
End Namespace
