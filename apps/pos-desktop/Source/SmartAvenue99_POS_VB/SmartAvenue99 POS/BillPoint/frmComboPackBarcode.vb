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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000CF RID: 207
	<DesignerGenerated()>
	Public Partial Class frmComboPackBarcode
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002426 RID: 9254 RVA: 0x0016EEFC File Offset: 0x0016D0FC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBarcodeLabelPrinting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBarcodeLabelPrinting_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmBarcodeLabelPrinting_Closed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000E5A RID: 3674
		' (get) Token: 0x06002429 RID: 9257 RVA: 0x000189E0 File Offset: 0x00016BE0
		' (set) Token: 0x0600242A RID: 9258 RVA: 0x000189EA File Offset: 0x00016BEA
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17000E5B RID: 3675
		' (get) Token: 0x0600242B RID: 9259 RVA: 0x000189F3 File Offset: 0x00016BF3
		' (set) Token: 0x0600242C RID: 9260 RVA: 0x000189FD File Offset: 0x00016BFD
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17000E5C RID: 3676
		' (get) Token: 0x0600242D RID: 9261 RVA: 0x00018A06 File Offset: 0x00016C06
		' (set) Token: 0x0600242E RID: 9262 RVA: 0x00018A10 File Offset: 0x00016C10
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17000E5D RID: 3677
		' (get) Token: 0x0600242F RID: 9263 RVA: 0x00018A19 File Offset: 0x00016C19
		' (set) Token: 0x06002430 RID: 9264 RVA: 0x00018A23 File Offset: 0x00016C23
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17000E5E RID: 3678
		' (get) Token: 0x06002431 RID: 9265 RVA: 0x00018A2C File Offset: 0x00016C2C
		' (set) Token: 0x06002432 RID: 9266 RVA: 0x00018A36 File Offset: 0x00016C36
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17000E5F RID: 3679
		' (get) Token: 0x06002433 RID: 9267 RVA: 0x00018A3F File Offset: 0x00016C3F
		' (set) Token: 0x06002434 RID: 9268 RVA: 0x00018A49 File Offset: 0x00016C49
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17000E60 RID: 3680
		' (get) Token: 0x06002435 RID: 9269 RVA: 0x00018A52 File Offset: 0x00016C52
		' (set) Token: 0x06002436 RID: 9270 RVA: 0x00018A5C File Offset: 0x00016C5C
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17000E61 RID: 3681
		' (get) Token: 0x06002437 RID: 9271 RVA: 0x00018A65 File Offset: 0x00016C65
		' (set) Token: 0x06002438 RID: 9272 RVA: 0x00018A6F File Offset: 0x00016C6F
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17000E62 RID: 3682
		' (get) Token: 0x06002439 RID: 9273 RVA: 0x00018A78 File Offset: 0x00016C78
		' (set) Token: 0x0600243A RID: 9274 RVA: 0x00018A82 File Offset: 0x00016C82
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17000E63 RID: 3683
		' (get) Token: 0x0600243B RID: 9275 RVA: 0x00018A8B File Offset: 0x00016C8B
		' (set) Token: 0x0600243C RID: 9276 RVA: 0x00018A95 File Offset: 0x00016C95
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17000E64 RID: 3684
		' (get) Token: 0x0600243D RID: 9277 RVA: 0x00018A9E File Offset: 0x00016C9E
		' (set) Token: 0x0600243E RID: 9278 RVA: 0x00018AA8 File Offset: 0x00016CA8
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000E65 RID: 3685
		' (get) Token: 0x0600243F RID: 9279 RVA: 0x00018AB1 File Offset: 0x00016CB1
		' (set) Token: 0x06002440 RID: 9280 RVA: 0x0017076C File Offset: 0x0016E96C
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

		' Token: 0x17000E66 RID: 3686
		' (get) Token: 0x06002441 RID: 9281 RVA: 0x00018ABB File Offset: 0x00016CBB
		' (set) Token: 0x06002442 RID: 9282 RVA: 0x001707B0 File Offset: 0x0016E9B0
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

		' Token: 0x17000E67 RID: 3687
		' (get) Token: 0x06002443 RID: 9283 RVA: 0x00018AC5 File Offset: 0x00016CC5
		' (set) Token: 0x06002444 RID: 9284 RVA: 0x001707F4 File Offset: 0x0016E9F4
		Private _RadioButton2 As RadioButton
		Friend Overridable Property RadioButton2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton2_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton2 = value
				radioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E68 RID: 3688
		' (get) Token: 0x06002445 RID: 9285 RVA: 0x00018ACF File Offset: 0x00016CCF
		' (set) Token: 0x06002446 RID: 9286 RVA: 0x00170838 File Offset: 0x0016EA38
		Private _RadioButton1 As RadioButton
		Friend Overridable Property RadioButton1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton1_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton1 = value
				radioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E69 RID: 3689
		' (get) Token: 0x06002447 RID: 9287 RVA: 0x00018AD9 File Offset: 0x00016CD9
		' (set) Token: 0x06002448 RID: 9288 RVA: 0x0017087C File Offset: 0x0016EA7C
		Private _txtNoOfCopies As TextBox
		Friend Overridable Property txtNoOfCopies As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNoOfCopies
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtNoOfCopies_KeyPress
				Dim textBox As TextBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtNoOfCopies = value
				textBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E6A RID: 3690
		' (get) Token: 0x06002449 RID: 9289 RVA: 0x00018AE3 File Offset: 0x00016CE3
		' (set) Token: 0x0600244A RID: 9290 RVA: 0x001708C0 File Offset: 0x0016EAC0
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E6B RID: 3691
		' (get) Token: 0x0600244B RID: 9291 RVA: 0x00018AED File Offset: 0x00016CED
		' (set) Token: 0x0600244C RID: 9292 RVA: 0x00018AF7 File Offset: 0x00016CF7
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x17000E6C RID: 3692
		' (get) Token: 0x0600244D RID: 9293 RVA: 0x00018B00 File Offset: 0x00016D00
		' (set) Token: 0x0600244E RID: 9294 RVA: 0x00018B0A File Offset: 0x00016D0A
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17000E6D RID: 3693
		' (get) Token: 0x0600244F RID: 9295 RVA: 0x00018B13 File Offset: 0x00016D13
		' (set) Token: 0x06002450 RID: 9296 RVA: 0x00170904 File Offset: 0x0016EB04
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
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_LostFocus
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.LostFocus, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.LostFocus, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E6E RID: 3694
		' (get) Token: 0x06002451 RID: 9297 RVA: 0x00018B1D File Offset: 0x00016D1D
		' (set) Token: 0x06002452 RID: 9298 RVA: 0x00018B27 File Offset: 0x00016D27
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17000E6F RID: 3695
		' (get) Token: 0x06002453 RID: 9299 RVA: 0x00018B30 File Offset: 0x00016D30
		' (set) Token: 0x06002454 RID: 9300 RVA: 0x00170964 File Offset: 0x0016EB64
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.LV
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.KeyDown, keyEventHandler
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.KeyDown, keyEventHandler
					AddHandler listView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E70 RID: 3696
		' (get) Token: 0x06002455 RID: 9301 RVA: 0x00018B3A File Offset: 0x00016D3A
		' (set) Token: 0x06002456 RID: 9302 RVA: 0x00018B44 File Offset: 0x00016D44
		Friend Overridable Property columnHeader1 As ColumnHeader

		' Token: 0x17000E71 RID: 3697
		' (get) Token: 0x06002457 RID: 9303 RVA: 0x00018B4D File Offset: 0x00016D4D
		' (set) Token: 0x06002458 RID: 9304 RVA: 0x00018B57 File Offset: 0x00016D57
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x17000E72 RID: 3698
		' (get) Token: 0x06002459 RID: 9305 RVA: 0x00018B60 File Offset: 0x00016D60
		' (set) Token: 0x0600245A RID: 9306 RVA: 0x00018B6A File Offset: 0x00016D6A
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x17000E73 RID: 3699
		' (get) Token: 0x0600245B RID: 9307 RVA: 0x00018B73 File Offset: 0x00016D73
		' (set) Token: 0x0600245C RID: 9308 RVA: 0x00018B7D File Offset: 0x00016D7D
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17000E74 RID: 3700
		' (get) Token: 0x0600245D RID: 9309 RVA: 0x00018B86 File Offset: 0x00016D86
		' (set) Token: 0x0600245E RID: 9310 RVA: 0x00018B90 File Offset: 0x00016D90
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17000E75 RID: 3701
		' (get) Token: 0x0600245F RID: 9311 RVA: 0x00018B99 File Offset: 0x00016D99
		' (set) Token: 0x06002460 RID: 9312 RVA: 0x00018BA3 File Offset: 0x00016DA3
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17000E76 RID: 3702
		' (get) Token: 0x06002461 RID: 9313 RVA: 0x00018BAC File Offset: 0x00016DAC
		' (set) Token: 0x06002462 RID: 9314 RVA: 0x00018BB6 File Offset: 0x00016DB6
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17000E77 RID: 3703
		' (get) Token: 0x06002463 RID: 9315 RVA: 0x00018BBF File Offset: 0x00016DBF
		' (set) Token: 0x06002464 RID: 9316 RVA: 0x001709C4 File Offset: 0x0016EBC4
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

		' Token: 0x17000E78 RID: 3704
		' (get) Token: 0x06002465 RID: 9317 RVA: 0x00018BC9 File Offset: 0x00016DC9
		' (set) Token: 0x06002466 RID: 9318 RVA: 0x00018BD3 File Offset: 0x00016DD3
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000E79 RID: 3705
		' (get) Token: 0x06002467 RID: 9319 RVA: 0x00018BDC File Offset: 0x00016DDC
		' (set) Token: 0x06002468 RID: 9320 RVA: 0x00170A08 File Offset: 0x0016EC08
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E7A RID: 3706
		' (get) Token: 0x06002469 RID: 9321 RVA: 0x00018BE6 File Offset: 0x00016DE6
		' (set) Token: 0x0600246A RID: 9322 RVA: 0x00018BF0 File Offset: 0x00016DF0
		Friend Overridable Property Label1 As Label

		' Token: 0x17000E7B RID: 3707
		' (get) Token: 0x0600246B RID: 9323 RVA: 0x00018BF9 File Offset: 0x00016DF9
		' (set) Token: 0x0600246C RID: 9324 RVA: 0x00018C03 File Offset: 0x00016E03
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x17000E7C RID: 3708
		' (get) Token: 0x0600246D RID: 9325 RVA: 0x00018C0C File Offset: 0x00016E0C
		' (set) Token: 0x0600246E RID: 9326 RVA: 0x00170A4C File Offset: 0x0016EC4C
		Private _txtSearch As TextBox
		Friend Overridable Property txtSearch As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearch_KeyDown
				Dim textBox As TextBox = Me._txtSearch
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearch = value
				textBox = Me._txtSearch
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E7D RID: 3709
		' (get) Token: 0x0600246F RID: 9327 RVA: 0x00018C16 File Offset: 0x00016E16
		' (set) Token: 0x06002470 RID: 9328 RVA: 0x00170A90 File Offset: 0x0016EC90
		Private _txtPInv As TextBox
		Friend Overridable Property txtPInv As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPInv
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPInv_KeyUp
				Dim textBox As TextBox = Me._txtPInv
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPInv = value
				textBox = Me._txtPInv
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E7E RID: 3710
		' (get) Token: 0x06002471 RID: 9329 RVA: 0x00018C20 File Offset: 0x00016E20
		' (set) Token: 0x06002472 RID: 9330 RVA: 0x00018C2A File Offset: 0x00016E2A
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17000E7F RID: 3711
		' (get) Token: 0x06002473 RID: 9331 RVA: 0x00018C33 File Offset: 0x00016E33
		' (set) Token: 0x06002474 RID: 9332 RVA: 0x00170AD4 File Offset: 0x0016ECD4
		Private _txtBCode As TextBox
		Friend Overridable Property txtBCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBCode_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBCode_KeyUp
				Dim textBox As TextBox = Me._txtBCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtBCode = value
				textBox = Me._txtBCode
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E80 RID: 3712
		' (get) Token: 0x06002475 RID: 9333 RVA: 0x00018C3D File Offset: 0x00016E3D
		' (set) Token: 0x06002476 RID: 9334 RVA: 0x00170B34 File Offset: 0x0016ED34
		Private _txtPCode As TextBox
		Friend Overridable Property txtPCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPCode_KeyUp
				Dim textBox As TextBox = Me._txtPCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPCode = value
				textBox = Me._txtPCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E81 RID: 3713
		' (get) Token: 0x06002477 RID: 9335 RVA: 0x00018C47 File Offset: 0x00016E47
		' (set) Token: 0x06002478 RID: 9336 RVA: 0x00018C51 File Offset: 0x00016E51
		Friend Overridable Property Label2 As Label

		' Token: 0x17000E82 RID: 3714
		' (get) Token: 0x06002479 RID: 9337 RVA: 0x00018C5A File Offset: 0x00016E5A
		' (set) Token: 0x0600247A RID: 9338 RVA: 0x00018C64 File Offset: 0x00016E64
		Friend Overridable Property Label3 As Label

		' Token: 0x17000E83 RID: 3715
		' (get) Token: 0x0600247B RID: 9339 RVA: 0x00018C6D File Offset: 0x00016E6D
		' (set) Token: 0x0600247C RID: 9340 RVA: 0x00170B78 File Offset: 0x0016ED78
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E84 RID: 3716
		' (get) Token: 0x0600247D RID: 9341 RVA: 0x00018C77 File Offset: 0x00016E77
		' (set) Token: 0x0600247E RID: 9342 RVA: 0x00170BBC File Offset: 0x0016EDBC
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E85 RID: 3717
		' (get) Token: 0x0600247F RID: 9343 RVA: 0x00018C81 File Offset: 0x00016E81
		' (set) Token: 0x06002480 RID: 9344 RVA: 0x00018C8B File Offset: 0x00016E8B
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x06002481 RID: 9345 RVA: 0x00170C00 File Offset: 0x0016EE00
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002482 RID: 9346 RVA: 0x00170F7C File Offset: 0x0016F17C
		Public Sub SearchbyPCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and ProductCode like N'" + Me.txtPCode.Text + "%' order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002483 RID: 9347 RVA: 0x0017130C File Offset: 0x0016F50C
		Public Sub SearchbyBCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Temp_Stock.Barcode like N'" + Me.txtBCode.Text + "%' ", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002484 RID: 9348 RVA: 0x0017169C File Offset: 0x0016F89C
		Public Sub GetDataPINV()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.Barcode),Temp_Stock.Qty, Stock_Product.qty, RTRIM(Product.PartNo),RTRIM(HSNCode),(Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice),(Stock_Product.Batch),(Stock_Product.Mfgdate),(Stock_Product.Expdate),(Stock_Product.Size),(Stock_Product.Color),((Stock_Product.CGSTPer)+(Stock_Product.SGSTPer)+(Stock_Product.IGSTPer)),RTRIM(Stock.InvoiceNo),QrBarcode from Product,Stock,Stock_Product,Temp_Stock where Stock.St_ID=Stock_Product.StockID and Product.PID=Stock_Product.ProductID and Temp_Stock.Barcode=Stock_Product.Barcode and InvoiceNo like N'" + Me.txtPInv.Text + "%' order by ProductCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(5)))))
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002485 RID: 9349 RVA: 0x00171A40 File Offset: 0x0016FC40
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.txtSearch.Text = ""
			Me.txtNoOfCopies.Text = Conversions.ToString(1)
			Me.GetData()
			Me.chkSelectAll.Checked = True
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
		End Sub

		' Token: 0x06002486 RID: 9350 RVA: 0x00171AFC File Offset: 0x0016FCFC
		Public Sub FillCompany()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select RTRIM(CompanyName) from Company"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.txtCompany.Text = ModCommonClasses.rdr.GetString(0)
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06002487 RID: 9351 RVA: 0x00171B80 File Offset: 0x0016FD80
		Private Sub frmBarcodeLabelPrinting_Load(sender As Object, e As EventArgs)
			Me.FillCompany()
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
			Me.RadioButton2.Checked = False
			Me.RadioButton1.TabStop = False
			Me.RadioButton2.TabStop = False
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.txtSearch.Text = ""
			Me.fillGategoryName()
			Me.Convert_Language()
		End Sub

		' Token: 0x06002488 RID: 9352 RVA: 0x00171C1C File Offset: 0x0016FE1C
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

		' Token: 0x06002489 RID: 9353 RVA: 0x00171D94 File Offset: 0x0016FF94
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

		' Token: 0x0600248A RID: 9354 RVA: 0x00171E50 File Offset: 0x00170050
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

		' Token: 0x0600248B RID: 9355 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600248C RID: 9356 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600248D RID: 9357 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600248E RID: 9358 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtNoOfCopies_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600248F RID: 9359 RVA: 0x00018C94 File Offset: 0x00016E94
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06002490 RID: 9360 RVA: 0x00171F1C File Offset: 0x0017011C
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x06002491 RID: 9361 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBarcodeLabelPrinting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002492 RID: 9362 RVA: 0x00018CB0 File Offset: 0x00016EB0
		Private Sub txtBCode_TextChanged(sender As Object, e As EventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x06002493 RID: 9363 RVA: 0x00172008 File Offset: 0x00170208
		Private Sub LV(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			If Not flag Then
				Dim keyCode As Keys = e.KeyCode
				If keyCode = Keys.F2 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x06002494 RID: 9364 RVA: 0x00172064 File Offset: 0x00170264
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			If Not flag Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num = 5 Then
					Dim flag2 As Boolean = num = 0
					If flag2 Then
						Me.CurrentItem.BeginEdit()
					Else
						Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
						Dim width As Integer = Me.CurrentSB.Bounds.Width
						Dim textBox As TextBox = Me.TextBox1
						textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
						textBox.Text = Me.CurrentSB.Text
						textBox.Show()
						textBox.Focus()
					End If
				End If
			End If
		End Sub

		' Token: 0x06002495 RID: 9365 RVA: 0x001721A8 File Offset: 0x001703A8
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			If keyChar <> vbCr Then
				If keyChar = ChrW(27) Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			Else
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
			End If
		End Sub

		' Token: 0x06002496 RID: 9366 RVA: 0x0017220C File Offset: 0x0017040C
		Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox1.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text.Trim(), "", False) <> 0
				If flag2 Then
					Dim flag3 As Boolean = Not Versioned.IsNumeric(Me.TextBox1.Text)
					If flag3 Then
						Interaction.MsgBox("Please enter a numeric value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Dim flag4 As Boolean = Conversion.Val(Me.TextBox1.Text) = 0.0
					If flag4 Then
						Interaction.MsgBox("Not allowed to enter 0 value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Me.CurrentSB.Text = Conversions.ToInteger(Me.TextBox1.Text).ToString()
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x06002497 RID: 9367 RVA: 0x001722F0 File Offset: 0x001704F0
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x06002498 RID: 9368 RVA: 0x00172344 File Offset: 0x00170544
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.txtNoOfCopies.Focus()
			End If
		End Sub

		' Token: 0x06002499 RID: 9369 RVA: 0x00172370 File Offset: 0x00170570
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x0600249A RID: 9370 RVA: 0x00172370 File Offset: 0x00170570
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x0600249B RID: 9371 RVA: 0x00018CBA File Offset: 0x00016EBA
		Private Sub txtPCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyPCode()
		End Sub

		' Token: 0x0600249C RID: 9372 RVA: 0x00018CB0 File Offset: 0x00016EB0
		Private Sub txtBCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x0600249D RID: 9373 RVA: 0x00018CC4 File Offset: 0x00016EC4
		Private Sub txtPInv_KeyUp(sender As Object, e As KeyEventArgs)
			Me.GetDataPINV()
		End Sub

		' Token: 0x0600249E RID: 9374 RVA: 0x00018CCE File Offset: 0x00016ECE
		Private Sub frmBarcodeLabelPrinting_Closed(sender As Object, e As EventArgs)
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
		End Sub

		' Token: 0x0600249F RID: 9375 RVA: 0x001723C0 File Offset: 0x001705C0
		Public Sub Print()
			Dim dataSet As DataSet = New DataSet()
			Dim text As String = ""
			Dim dataTable As DataTable = New DataTable()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.ComboBox2.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim dataTable2 As DataTable = New DataTable()
							Dim dataTable3 As DataTable = dataTable2
							dataTable3.Columns.Add("PCode")
							dataTable3.Columns.Add("ProductName")
							dataTable3.Columns.Add("Category")
							dataTable3.Columns.Add("Barcode")
							dataTable3.Columns.Add("AvlQty")
							dataTable3.Columns.Add("NoCopy")
							dataTable3.Columns.Add("PartNo")
							dataTable3.Columns.Add("HSNC")
							dataTable3.Columns.Add("MRP")
							dataTable3.Columns.Add("SalePrice")
							dataTable3.Columns.Add("WholesalePrice")
							dataTable3.Columns.Add("Batch")
							dataTable3.Columns.Add("Mfg")
							dataTable3.Columns.Add("Exp")
							dataTable3.Columns.Add("Size")
							dataTable3.Columns.Add("Colour")
							dataTable3.Columns.Add("GST")
							dataTable3.Columns.Add("PurInv")
							dataTable3.Columns.Add("QrBarcode")
							dataTable3.Columns.Add("CBarcode")
							dataTable3.Columns.Add("DefaultQty")
							Dim dictionary As Dictionary(Of String, List(Of DataTable)) = New Dictionary(Of String, List(Of DataTable))()
							Dim text2 As String = ""
							Dim list As List(Of Integer) = New List(Of Integer)()
							Dim list2 As List(Of DataTable) = New List(Of DataTable)()
							Dim num As Integer
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									dataSet = Me.printCustomBarcode("'" + listViewItem.SubItems(3).Text + "'")
									dataTable = dataSet.Tables(0).Clone()
									Dim checked As Boolean = Me.CheckBox1.Checked
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
										text2 = "A"
									Else
										text2 = "I"
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text)))
									End If
									Dim num2 As Integer = num - 1
									For i As Integer = 0 To num2
										Dim text3 As String = listViewItem.SubItems(0).Text
										Dim text4 As String = listViewItem.SubItems(1).Text
										Dim text5 As String = listViewItem.SubItems(2).Text
										Dim text6 As String = listViewItem.SubItems(3).Text
										Dim text7 As String = listViewItem.SubItems(4).Text
										Dim text8 As String = listViewItem.SubItems(5).Text
										Dim text9 As String = listViewItem.SubItems(6).Text
										Dim text10 As String = listViewItem.SubItems(7).Text
										Dim text11 As String = listViewItem.SubItems(8).Text
										Dim text12 As String = listViewItem.SubItems(9).Text
										Dim text13 As String = listViewItem.SubItems(10).Text
										Dim text14 As String = listViewItem.SubItems(11).Text
										Dim text15 As String = listViewItem.SubItems(12).Text
										Dim text16 As String = listViewItem.SubItems(13).Text
										Dim text17 As String = listViewItem.SubItems(14).Text
										Dim text18 As String = listViewItem.SubItems(15).Text
										Dim text19 As String = listViewItem.SubItems(16).Text
										Dim text20 As String = listViewItem.SubItems(17).Text
										text = listViewItem.SubItems(19).Text
										Dim text21 As String = listViewItem.SubItems(4).Text
										dataTable2.Rows.Add(New Object() { text3, listViewItem.SubItems(1).Text, listViewItem.SubItems(2).Text, listViewItem.SubItems(3).Text, listViewItem.SubItems(4).Text, listViewItem.SubItems(5).Text, listViewItem.SubItems(6).Text, listViewItem.SubItems(7).Text, listViewItem.SubItems(8).Text, listViewItem.SubItems(9).Text, listViewItem.SubItems(10).Text, listViewItem.SubItems(11).Text, listViewItem.SubItems(12).Text, listViewItem.SubItems(13).Text, listViewItem.SubItems(14).Text, listViewItem.SubItems(15).Text, listViewItem.SubItems(16).Text, listViewItem.SubItems(17).Text, listViewItem.SubItems(19).Text, listViewItem.SubItems(4).Text })
									Next
									list.Add(num - 1)
									list2.Add(dataSet.Tables(0))
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
							End If
							Dim flag4 As Boolean = Operators.CompareString(text2, "A", False) = 0
							If flag4 Then
								Dim num3 As Integer = num - 1
								For j As Integer = 0 To num3
									Try
										For Each dataTable4 As DataTable In list2
											Try
												For Each obj2 As Object In dataTable4.Rows
													Dim dataRow As DataRow = CType(obj2, DataRow)
													dataTable.ImportRow(dataRow)
												Next
											Finally
												Dim enumerator3 As IEnumerator
												If TypeOf enumerator3 Is IDisposable Then
													TryCast(enumerator3, IDisposable).Dispose()
												End If
											End Try
										Next
									Finally
										Dim enumerator2 As List(Of DataTable).Enumerator
										CType(enumerator2, IDisposable).Dispose()
									End Try
								Next
							Else
								Dim flag5 As Boolean = Operators.CompareString(text2, "I", False) = 0
								If flag5 Then
									Dim count As Integer = list2.Count
									Dim num4 As Integer = 0
									Try
										For Each num5 As Integer In list
											Dim flag6 As Boolean = num5 = 0
											If flag6 Then
												Dim dataTable5 As DataTable = list2(num4)
												Dim flag7 As Boolean = dataTable5.Rows.Count > 0
												If flag7 Then
													Try
														For Each obj3 As Object In dataTable5.Rows
															Dim dataRow2 As DataRow = CType(obj3, DataRow)
															dataTable.ImportRow(dataRow2)
														Next
													Finally
														Dim enumerator5 As IEnumerator
														If TypeOf enumerator5 Is IDisposable Then
															TryCast(enumerator5, IDisposable).Dispose()
														End If
													End Try
												End If
											Else
												Dim num6 As Integer = num5
												For k As Integer = 0 To num6
													Dim dataTable6 As DataTable = list2(num4)
													Try
														For Each obj4 As Object In dataTable6.Rows
															Dim dataRow3 As DataRow = CType(obj4, DataRow)
															dataTable.ImportRow(dataRow3)
														Next
													Finally
														Dim enumerator6 As IEnumerator
														If TypeOf enumerator6 Is IDisposable Then
															TryCast(enumerator6, IDisposable).Dispose()
														End If
													End Try
												Next
											End If
											num4 += 1
										Next
									Finally
										Dim enumerator4 As List(Of Integer).Enumerator
										CType(enumerator4, IDisposable).Dispose()
									End Try
								End If
							End If
							dataTable.DefaultView.Sort = "Barcode ASC"
							dataTable = dataTable.DefaultView.ToTable()
							Dim reportDocument As ReportDocument = New ReportDocument()
							Dim flag8 As Boolean = Me.ComboBox2.SelectedIndex = 0
							If flag8 Then
								Dim reportDocument2 As ReportDocument = New ReportDocument()
								reportDocument2.Load(Application.StartupPath + "\CryReport\CBarcode.rpt")
								reportDocument2.SetDataSource(dataTable)
								reportDocument2.SetParameterValue("P1", Me.txtCompany.Text)
								reportDocument2.SetParameterValue("CBarcode", text)
								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument2
								MyProject.Forms.frmReport.ShowDialog()
								MyProject.Forms.frmReport.Dispose()
							Else
								reportDocument.SetDataSource(dataTable2)
								reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
								MyProject.Forms.frmReport.ShowDialog()
								MyProject.Forms.frmReport.Dispose()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060024A0 RID: 9376 RVA: 0x00172F5C File Offset: 0x0017115C
		Public Sub PrintQRBarcode()
			Dim dataSet As DataSet = New DataSet()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.ComboBox2.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Dim checked As Boolean = Me.CheckBox1.Checked
									Dim num As Integer
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text))) - 1
									Else
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text))) - 1
									End If
									Dim num2 As Integer = num
									For i As Integer = 0 To num2
										dataSet = Me.printCustomBarcode(listViewItem.SubItems(3).Text)
									Next
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim reportDocument As ReportDocument = New ReportDocument()
							reportDocument = New BarcodeCustomise1()
							reportDocument.SetDataSource(dataSet)
							reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060024A1 RID: 9377 RVA: 0x00173194 File Offset: 0x00171394
		Private Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode,Combopack.CBarcode,ComboPack_Product.DefaultQty,Combopack.QRCBarcode from Category,SubCategory,Product,Temp_Stock,ComboPack_Product,Combopack where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID And Product.PID = ComboPack_Product.ProductID and Product.Status='Yes' and Combopack.ComboCategoryName=ComboPack_Product.ComboCategoryName and Temp_Stock.barcode in(" + barcode + ")"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = ModCommonClasses.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				ModCommonClasses.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x060024A2 RID: 9378 RVA: 0x0017327C File Offset: 0x0017147C
		Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and ProductName like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag2 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Category like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
				If flag3 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Barcode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
				If flag4 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and PartNo like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 4
				If flag5 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and HSNCode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 5
				If flag6 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Batch like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 6
				If flag7 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Size like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 7
				If flag8 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Colour like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060024A3 RID: 9379 RVA: 0x00018D04 File Offset: 0x00016F04
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060024A4 RID: 9380 RVA: 0x001737F0 File Offset: 0x001719F0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise1.rpt")
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise2.rpt")
				End If
			End If
		End Sub

		' Token: 0x060024A5 RID: 9381 RVA: 0x00018D0E File Offset: 0x00016F0E
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x060024A6 RID: 9382 RVA: 0x00173860 File Offset: 0x00171A60
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim text As String = Conversions.ToString(Me.cmbCategory.SelectedItem)
				Me.ShowProduct(text)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060024A7 RID: 9383 RVA: 0x001738AC File Offset: 0x00171AAC
		Private Function ShowProduct(name As String) As Object
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),ComboPack_Product.DefaultQty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Combopack.CBarcode from Category,SubCategory,Product,Temp_Stock,ComboPack_Product,Combopack where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID And Product.PID = ComboPack_Product.ProductID and Product.Status='Yes' and Combopack.ComboCategoryName=ComboPack_Product.ComboCategoryName and Combopack.ComboCategoryName  = N'" + name + "' order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x060024A8 RID: 9384 RVA: 0x00173C58 File Offset: 0x00171E58
		Public Sub fillGategoryName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ComboCategoryName) FROM Combopack order by 1 desc", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x04000EF4 RID: 3828
		Private st As String

		' Token: 0x04000EF5 RID: 3829
		Private bCancelEdit As Boolean

		' Token: 0x04000EF6 RID: 3830
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04000EF7 RID: 3831
		Private CurrentItem As ListViewItem
	End Class
End Namespace
