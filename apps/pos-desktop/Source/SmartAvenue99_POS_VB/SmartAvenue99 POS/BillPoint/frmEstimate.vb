Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200029E RID: 670
	<DesignerGenerated()>
	Public Partial Class frmEstimate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A9AE RID: 43438 RVA: 0x007173B0 File Offset: 0x007155B0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEstimate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEstimate_KeyDown
			Me.a = 0D
			Me.cmpnm = ""
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x170041AF RID: 16815
		' (get) Token: 0x0600A9B1 RID: 43441 RVA: 0x0004F116 File Offset: 0x0004D316
		' (set) Token: 0x0600A9B2 RID: 43442 RVA: 0x00722534 File Offset: 0x00720734
		Private _Timer3 As Timer
		Friend Overridable Property Timer3 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer3_Tick
				Dim timer As Timer = Me._Timer3
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer3 = value
				timer = Me._Timer3
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041B0 RID: 16816
		' (get) Token: 0x0600A9B3 RID: 43443 RVA: 0x0004F120 File Offset: 0x0004D320
		' (set) Token: 0x0600A9B4 RID: 43444 RVA: 0x0004F12A File Offset: 0x0004D32A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170041B1 RID: 16817
		' (get) Token: 0x0600A9B5 RID: 43445 RVA: 0x0004F133 File Offset: 0x0004D333
		' (set) Token: 0x0600A9B6 RID: 43446 RVA: 0x00722578 File Offset: 0x00720778
		Private _Button22 As Button
		Friend Overridable Property Button22 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button22_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button22_MouseHover
				Dim button As Button = Me._Button22
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button22 = value
				button = Me._Button22
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170041B2 RID: 16818
		' (get) Token: 0x0600A9B7 RID: 43447 RVA: 0x0004F13D File Offset: 0x0004D33D
		' (set) Token: 0x0600A9B8 RID: 43448 RVA: 0x0004F147 File Offset: 0x0004D347
		Friend Overridable Property Label30 As Label

		' Token: 0x170041B3 RID: 16819
		' (get) Token: 0x0600A9B9 RID: 43449 RVA: 0x0004F150 File Offset: 0x0004D350
		' (set) Token: 0x0600A9BA RID: 43450 RVA: 0x007225D8 File Offset: 0x007207D8
		Private _cmbCustomerName As ComboBox
		Friend Overridable Property cmbCustomerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_SelectedIndexChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbCustomerName_Validated
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCustomerName_KeyDown
				Dim comboBox As ComboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validated, eventHandler2
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbCustomerName = value
				comboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validated, eventHandler2
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170041B4 RID: 16820
		' (get) Token: 0x0600A9BB RID: 43451 RVA: 0x0004F15A File Offset: 0x0004D35A
		' (set) Token: 0x0600A9BC RID: 43452 RVA: 0x0004F164 File Offset: 0x0004D364
		Friend Overridable Property Label26 As Label

		' Token: 0x170041B5 RID: 16821
		' (get) Token: 0x0600A9BD RID: 43453 RVA: 0x0004F16D File Offset: 0x0004D36D
		' (set) Token: 0x0600A9BE RID: 43454 RVA: 0x0004F177 File Offset: 0x0004D377
		Friend Overridable Property Label19 As Label

		' Token: 0x170041B6 RID: 16822
		' (get) Token: 0x0600A9BF RID: 43455 RVA: 0x0004F180 File Offset: 0x0004D380
		' (set) Token: 0x0600A9C0 RID: 43456 RVA: 0x0004F18A File Offset: 0x0004D38A
		Friend Overridable Property txtCustomerState As TextBox

		' Token: 0x170041B7 RID: 16823
		' (get) Token: 0x0600A9C1 RID: 43457 RVA: 0x0004F193 File Offset: 0x0004D393
		' (set) Token: 0x0600A9C2 RID: 43458 RVA: 0x0004F19D File Offset: 0x0004D39D
		Friend Overridable Property Label7 As Label

		' Token: 0x170041B8 RID: 16824
		' (get) Token: 0x0600A9C3 RID: 43459 RVA: 0x0004F1A6 File Offset: 0x0004D3A6
		' (set) Token: 0x0600A9C4 RID: 43460 RVA: 0x0004F1B0 File Offset: 0x0004D3B0
		Friend Overridable Property txtGSTIN As TextBox

		' Token: 0x170041B9 RID: 16825
		' (get) Token: 0x0600A9C5 RID: 43461 RVA: 0x0004F1B9 File Offset: 0x0004D3B9
		' (set) Token: 0x0600A9C6 RID: 43462 RVA: 0x0004F1C3 File Offset: 0x0004D3C3
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x170041BA RID: 16826
		' (get) Token: 0x0600A9C7 RID: 43463 RVA: 0x0004F1CC File Offset: 0x0004D3CC
		' (set) Token: 0x0600A9C8 RID: 43464 RVA: 0x0004F1D6 File Offset: 0x0004D3D6
		Friend Overridable Property Label9 As Label

		' Token: 0x170041BB RID: 16827
		' (get) Token: 0x0600A9C9 RID: 43465 RVA: 0x0004F1DF File Offset: 0x0004D3DF
		' (set) Token: 0x0600A9CA RID: 43466 RVA: 0x0004F1E9 File Offset: 0x0004D3E9
		Friend Overridable Property Label2 As Label

		' Token: 0x170041BC RID: 16828
		' (get) Token: 0x0600A9CB RID: 43467 RVA: 0x0004F1F2 File Offset: 0x0004D3F2
		' (set) Token: 0x0600A9CC RID: 43468 RVA: 0x00722654 File Offset: 0x00720854
		Private _btnCustomerSelection As Button
		Friend Overridable Property btnCustomerSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCustomerSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelect_Click_1
				Dim button As Button = Me._btnCustomerSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCustomerSelection = value
				button = Me._btnCustomerSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041BD RID: 16829
		' (get) Token: 0x0600A9CD RID: 43469 RVA: 0x0004F1FC File Offset: 0x0004D3FC
		' (set) Token: 0x0600A9CE RID: 43470 RVA: 0x0004F206 File Offset: 0x0004D406
		Friend Overridable Property Label3 As Label

		' Token: 0x170041BE RID: 16830
		' (get) Token: 0x0600A9CF RID: 43471 RVA: 0x0004F20F File Offset: 0x0004D40F
		' (set) Token: 0x0600A9D0 RID: 43472 RVA: 0x00722698 File Offset: 0x00720898
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerID_TextChanged
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041BF RID: 16831
		' (get) Token: 0x0600A9D1 RID: 43473 RVA: 0x0004F219 File Offset: 0x0004D419
		' (set) Token: 0x0600A9D2 RID: 43474 RVA: 0x0004F223 File Offset: 0x0004D423
		Friend Overridable Property Label8 As Label

		' Token: 0x170041C0 RID: 16832
		' (get) Token: 0x0600A9D3 RID: 43475 RVA: 0x0004F22C File Offset: 0x0004D42C
		' (set) Token: 0x0600A9D4 RID: 43476 RVA: 0x0004F236 File Offset: 0x0004D436
		Friend Overridable Property Label31 As Label

		' Token: 0x170041C1 RID: 16833
		' (get) Token: 0x0600A9D5 RID: 43477 RVA: 0x0004F23F File Offset: 0x0004D43F
		' (set) Token: 0x0600A9D6 RID: 43478 RVA: 0x007226DC File Offset: 0x007208DC
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.TextBox5_TextChanged
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.TextBox5_KeyUp
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler2
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170041C2 RID: 16834
		' (get) Token: 0x0600A9D7 RID: 43479 RVA: 0x0004F249 File Offset: 0x0004D449
		' (set) Token: 0x0600A9D8 RID: 43480 RVA: 0x0004F253 File Offset: 0x0004D453
		Friend Overridable Property NumericUpDown1 As NumericUpDown

		' Token: 0x170041C3 RID: 16835
		' (get) Token: 0x0600A9D9 RID: 43481 RVA: 0x0004F25C File Offset: 0x0004D45C
		' (set) Token: 0x0600A9DA RID: 43482 RVA: 0x00722758 File Offset: 0x00720958
		Private _Button33 As Button
		Friend Overridable Property Button33 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button33
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button33_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button33_MouseHover
				Dim button As Button = Me._Button33
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button33 = value
				button = Me._Button33
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170041C4 RID: 16836
		' (get) Token: 0x0600A9DB RID: 43483 RVA: 0x0004F266 File Offset: 0x0004D466
		' (set) Token: 0x0600A9DC RID: 43484 RVA: 0x0004F270 File Offset: 0x0004D470
		Friend Overridable Property lblwmstatus As Label

		' Token: 0x170041C5 RID: 16837
		' (get) Token: 0x0600A9DD RID: 43485 RVA: 0x0004F279 File Offset: 0x0004D479
		' (set) Token: 0x0600A9DE RID: 43486 RVA: 0x0004F283 File Offset: 0x0004D483
		Friend Overridable Property txtSubTotal As TextBox

		' Token: 0x170041C6 RID: 16838
		' (get) Token: 0x0600A9DF RID: 43487 RVA: 0x0004F28C File Offset: 0x0004D48C
		' (set) Token: 0x0600A9E0 RID: 43488 RVA: 0x007227B8 File Offset: 0x007209B8
		Private _lblPurCost As Label
		Friend Overridable Property lblPurCost As Label
			<CompilerGenerated()>
			Get
				Return Me._lblPurCost
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.lblPurCost_TextChanged
				Dim label As Label = Me._lblPurCost
				If label IsNot Nothing Then
					RemoveHandler label.TextChanged, eventHandler
				End If
				Me._lblPurCost = value
				label = Me._lblPurCost
				If label IsNot Nothing Then
					AddHandler label.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041C7 RID: 16839
		' (get) Token: 0x0600A9E1 RID: 43489 RVA: 0x0004F296 File Offset: 0x0004D496
		' (set) Token: 0x0600A9E2 RID: 43490 RVA: 0x007227FC File Offset: 0x007209FC
		Private _cmbTaxType As ComboBox
		Friend Overridable Property cmbTaxType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTaxType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbTaxType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbTaxType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbTaxType = value
				comboBox = Me._cmbTaxType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041C8 RID: 16840
		' (get) Token: 0x0600A9E3 RID: 43491 RVA: 0x0004F2A0 File Offset: 0x0004D4A0
		' (set) Token: 0x0600A9E4 RID: 43492 RVA: 0x00722840 File Offset: 0x00720A40
		Private _CheckBox3 As CheckBox
		Friend Overridable Property CheckBox3 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox3_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox3 = value
				checkBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041C9 RID: 16841
		' (get) Token: 0x0600A9E5 RID: 43493 RVA: 0x0004F2AA File Offset: 0x0004D4AA
		' (set) Token: 0x0600A9E6 RID: 43494 RVA: 0x00722884 File Offset: 0x00720A84
		Private _lblLastPrice As Label
		Friend Overridable Property lblLastPrice As Label
			<CompilerGenerated()>
			Get
				Return Me._lblLastPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.lblLastPrice_TextChanged
				Dim label As Label = Me._lblLastPrice
				If label IsNot Nothing Then
					RemoveHandler label.TextChanged, eventHandler
				End If
				Me._lblLastPrice = value
				label = Me._lblLastPrice
				If label IsNot Nothing Then
					AddHandler label.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041CA RID: 16842
		' (get) Token: 0x0600A9E7 RID: 43495 RVA: 0x0004F2B4 File Offset: 0x0004D4B4
		' (set) Token: 0x0600A9E8 RID: 43496 RVA: 0x007228C8 File Offset: 0x00720AC8
		Private _chkBoxLastSoldPrice As CheckBox
		Friend Overridable Property chkBoxLastSoldPrice As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkBoxLastSoldPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkBoxLastSoldPrice_CheckedChanged
				Dim checkBox As CheckBox = Me._chkBoxLastSoldPrice
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkBoxLastSoldPrice = value
				checkBox = Me._chkBoxLastSoldPrice
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041CB RID: 16843
		' (get) Token: 0x0600A9E9 RID: 43497 RVA: 0x0004F2BE File Offset: 0x0004D4BE
		' (set) Token: 0x0600A9EA RID: 43498 RVA: 0x0072290C File Offset: 0x00720B0C
		Private _CheckBox7 As CheckBox
		Friend Overridable Property CheckBox7 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox7_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox7 = value
				checkBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041CC RID: 16844
		' (get) Token: 0x0600A9EB RID: 43499 RVA: 0x0004F2C8 File Offset: 0x0004D4C8
		' (set) Token: 0x0600A9EC RID: 43500 RVA: 0x00722950 File Offset: 0x00720B50
		Private _lblCustLastItemPrice As Label
		Friend Overridable Property lblCustLastItemPrice As Label
			<CompilerGenerated()>
			Get
				Return Me._lblCustLastItemPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.lblCustLastItemPrice_TextChanged
				Dim label As Label = Me._lblCustLastItemPrice
				If label IsNot Nothing Then
					RemoveHandler label.TextChanged, eventHandler
				End If
				Me._lblCustLastItemPrice = value
				label = Me._lblCustLastItemPrice
				If label IsNot Nothing Then
					AddHandler label.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041CD RID: 16845
		' (get) Token: 0x0600A9ED RID: 43501 RVA: 0x0004F2D2 File Offset: 0x0004D4D2
		' (set) Token: 0x0600A9EE RID: 43502 RVA: 0x0004F2DC File Offset: 0x0004D4DC
		Friend Overridable Property Label36 As Label

		' Token: 0x170041CE RID: 16846
		' (get) Token: 0x0600A9EF RID: 43503 RVA: 0x0004F2E5 File Offset: 0x0004D4E5
		' (set) Token: 0x0600A9F0 RID: 43504 RVA: 0x0004F2EF File Offset: 0x0004D4EF
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x170041CF RID: 16847
		' (get) Token: 0x0600A9F1 RID: 43505 RVA: 0x0004F2F8 File Offset: 0x0004D4F8
		' (set) Token: 0x0600A9F2 RID: 43506 RVA: 0x00722994 File Offset: 0x00720B94
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

		' Token: 0x170041D0 RID: 16848
		' (get) Token: 0x0600A9F3 RID: 43507 RVA: 0x0004F302 File Offset: 0x0004D502
		' (set) Token: 0x0600A9F4 RID: 43508 RVA: 0x007229D8 File Offset: 0x00720BD8
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

		' Token: 0x170041D1 RID: 16849
		' (get) Token: 0x0600A9F5 RID: 43509 RVA: 0x0004F30C File Offset: 0x0004D50C
		' (set) Token: 0x0600A9F6 RID: 43510 RVA: 0x00722A1C File Offset: 0x00720C1C
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
				Dim eventHandler2 As EventHandler = AddressOf Me.Button1_MouseHover
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170041D2 RID: 16850
		' (get) Token: 0x0600A9F7 RID: 43511 RVA: 0x0004F316 File Offset: 0x0004D516
		' (set) Token: 0x0600A9F8 RID: 43512 RVA: 0x00722A7C File Offset: 0x00720C7C
		Private _btnScanItems As Button
		Friend Overridable Property btnScanItems As Button
			<CompilerGenerated()>
			Get
				Return Me._btnScanItems
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnScanItems_Click
				Dim button As Button = Me._btnScanItems
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnScanItems = value
				button = Me._btnScanItems
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041D3 RID: 16851
		' (get) Token: 0x0600A9F9 RID: 43513 RVA: 0x0004F320 File Offset: 0x0004D520
		' (set) Token: 0x0600A9FA RID: 43514 RVA: 0x00722AC0 File Offset: 0x00720CC0
		Private _CheckBox2 As CheckBox
		Friend Overridable Property CheckBox2 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox2_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox2 = value
				checkBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041D4 RID: 16852
		' (get) Token: 0x0600A9FB RID: 43515 RVA: 0x0004F32A File Offset: 0x0004D52A
		' (set) Token: 0x0600A9FC RID: 43516 RVA: 0x00722B04 File Offset: 0x00720D04
		Private _cboxSpeed As CheckBox
		Friend Overridable Property cboxSpeed As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cboxSpeed
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cboxSpeed_CheckedChanged
				Dim checkBox As CheckBox = Me._cboxSpeed
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cboxSpeed = value
				checkBox = Me._cboxSpeed
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041D5 RID: 16853
		' (get) Token: 0x0600A9FD RID: 43517 RVA: 0x0004F334 File Offset: 0x0004D534
		' (set) Token: 0x0600A9FE RID: 43518 RVA: 0x00722B48 File Offset: 0x00720D48
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox6_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.TextBox6_Leave
				Dim eventHandler2 As EventHandler = AddressOf Me.TextBox6_GotFocus
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler
					RemoveHandler textBox.GotFocus, eventHandler2
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler
					AddHandler textBox.GotFocus, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170041D6 RID: 16854
		' (get) Token: 0x0600A9FF RID: 43519 RVA: 0x0004F33E File Offset: 0x0004D53E
		' (set) Token: 0x0600AA00 RID: 43520 RVA: 0x0004F348 File Offset: 0x0004D548
		Friend Overridable Property cmbProductName As ComboBox

		' Token: 0x170041D7 RID: 16855
		' (get) Token: 0x0600AA01 RID: 43521 RVA: 0x0004F351 File Offset: 0x0004D551
		' (set) Token: 0x0600AA02 RID: 43522 RVA: 0x0004F35B File Offset: 0x0004D55B
		Friend Overridable Property Label55 As Label

		' Token: 0x170041D8 RID: 16856
		' (get) Token: 0x0600AA03 RID: 43523 RVA: 0x0004F364 File Offset: 0x0004D564
		' (set) Token: 0x0600AA04 RID: 43524 RVA: 0x0004F36E File Offset: 0x0004D56E
		Friend Overridable Property Label53 As Label

		' Token: 0x170041D9 RID: 16857
		' (get) Token: 0x0600AA05 RID: 43525 RVA: 0x0004F377 File Offset: 0x0004D577
		' (set) Token: 0x0600AA06 RID: 43526 RVA: 0x0004F381 File Offset: 0x0004D581
		Friend Overridable Property Label52 As Label

		' Token: 0x170041DA RID: 16858
		' (get) Token: 0x0600AA07 RID: 43527 RVA: 0x0004F38A File Offset: 0x0004D58A
		' (set) Token: 0x0600AA08 RID: 43528 RVA: 0x0004F394 File Offset: 0x0004D594
		Friend Overridable Property Label72 As Label

		' Token: 0x170041DB RID: 16859
		' (get) Token: 0x0600AA09 RID: 43529 RVA: 0x0004F39D File Offset: 0x0004D59D
		' (set) Token: 0x0600AA0A RID: 43530 RVA: 0x0004F3A7 File Offset: 0x0004D5A7
		Friend Overridable Property lblAltValue As Label

		' Token: 0x170041DC RID: 16860
		' (get) Token: 0x0600AA0B RID: 43531 RVA: 0x0004F3B0 File Offset: 0x0004D5B0
		' (set) Token: 0x0600AA0C RID: 43532 RVA: 0x0004F3BA File Offset: 0x0004D5BA
		Friend Overridable Property lblAltUnit As Label

		' Token: 0x170041DD RID: 16861
		' (get) Token: 0x0600AA0D RID: 43533 RVA: 0x0004F3C3 File Offset: 0x0004D5C3
		' (set) Token: 0x0600AA0E RID: 43534 RVA: 0x0004F3CD File Offset: 0x0004D5CD
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170041DE RID: 16862
		' (get) Token: 0x0600AA0F RID: 43535 RVA: 0x0004F3D6 File Offset: 0x0004D5D6
		' (set) Token: 0x0600AA10 RID: 43536 RVA: 0x00722BC4 File Offset: 0x00720DC4
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNext_Click
				Dim button As Button = Me._btnNext
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNext = value
				button = Me._btnNext
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041DF RID: 16863
		' (get) Token: 0x0600AA11 RID: 43537 RVA: 0x0004F3E0 File Offset: 0x0004D5E0
		' (set) Token: 0x0600AA12 RID: 43538 RVA: 0x00722C08 File Offset: 0x00720E08
		Private _btnFirst As Button
		Friend Overridable Property btnFirst As Button
			<CompilerGenerated()>
			Get
				Return Me._btnFirst
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnFirst_Click
				Dim button As Button = Me._btnFirst
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnFirst = value
				button = Me._btnFirst
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E0 RID: 16864
		' (get) Token: 0x0600AA13 RID: 43539 RVA: 0x0004F3EA File Offset: 0x0004D5EA
		' (set) Token: 0x0600AA14 RID: 43540 RVA: 0x00722C4C File Offset: 0x00720E4C
		Private _txtPrev As Button
		Friend Overridable Property txtPrev As Button
			<CompilerGenerated()>
			Get
				Return Me._txtPrev
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.txtPrev_Click
				Dim button As Button = Me._txtPrev
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtPrev = value
				button = Me._txtPrev
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E1 RID: 16865
		' (get) Token: 0x0600AA15 RID: 43541 RVA: 0x0004F3F4 File Offset: 0x0004D5F4
		' (set) Token: 0x0600AA16 RID: 43542 RVA: 0x00722C90 File Offset: 0x00720E90
		Private _btnLast As Button
		Friend Overridable Property btnLast As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLast
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLast_Click
				Dim button As Button = Me._btnLast
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLast = value
				button = Me._btnLast
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E2 RID: 16866
		' (get) Token: 0x0600AA17 RID: 43543 RVA: 0x0004F3FE File Offset: 0x0004D5FE
		' (set) Token: 0x0600AA18 RID: 43544 RVA: 0x00722CD4 File Offset: 0x00720ED4
		Private _dtpQuotationDate As DateTimePicker
		Friend Overridable Property dtpQuotationDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpQuotationDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpQuotationDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpQuotationDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpQuotationDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpQuotationDate = value
				dateTimePicker = Me._dtpQuotationDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E3 RID: 16867
		' (get) Token: 0x0600AA19 RID: 43545 RVA: 0x0004F408 File Offset: 0x0004D608
		' (set) Token: 0x0600AA1A RID: 43546 RVA: 0x0004F412 File Offset: 0x0004D612
		Friend Overridable Property txtQuotationNo As TextBox

		' Token: 0x170041E4 RID: 16868
		' (get) Token: 0x0600AA1B RID: 43547 RVA: 0x0004F41B File Offset: 0x0004D61B
		' (set) Token: 0x0600AA1C RID: 43548 RVA: 0x0004F425 File Offset: 0x0004D625
		Friend Overridable Property Label4 As Label

		' Token: 0x170041E5 RID: 16869
		' (get) Token: 0x0600AA1D RID: 43549 RVA: 0x0004F42E File Offset: 0x0004D62E
		' (set) Token: 0x0600AA1E RID: 43550 RVA: 0x00722D34 File Offset: 0x00720F34
		Private _Button10 As Button
		Friend Overridable Property Button10 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click
				Dim button As Button = Me._Button10
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button10 = value
				button = Me._Button10
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E6 RID: 16870
		' (get) Token: 0x0600AA1F RID: 43551 RVA: 0x0004F438 File Offset: 0x0004D638
		' (set) Token: 0x0600AA20 RID: 43552 RVA: 0x00722D78 File Offset: 0x00720F78
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041E7 RID: 16871
		' (get) Token: 0x0600AA21 RID: 43553 RVA: 0x0004F442 File Offset: 0x0004D642
		' (set) Token: 0x0600AA22 RID: 43554 RVA: 0x0004F44C File Offset: 0x0004D64C
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x170041E8 RID: 16872
		' (get) Token: 0x0600AA23 RID: 43555 RVA: 0x0004F455 File Offset: 0x0004D655
		' (set) Token: 0x0600AA24 RID: 43556 RVA: 0x0004F45F File Offset: 0x0004D65F
		Friend Overridable Property Label15 As Label

		' Token: 0x170041E9 RID: 16873
		' (get) Token: 0x0600AA25 RID: 43557 RVA: 0x0004F468 File Offset: 0x0004D668
		' (set) Token: 0x0600AA26 RID: 43558 RVA: 0x0004F472 File Offset: 0x0004D672
		Friend Overridable Property lblCPhone As Label

		' Token: 0x170041EA RID: 16874
		' (get) Token: 0x0600AA27 RID: 43559 RVA: 0x0004F47B File Offset: 0x0004D67B
		' (set) Token: 0x0600AA28 RID: 43560 RVA: 0x0004F485 File Offset: 0x0004D685
		Friend Overridable Property F2 As TextBox

		' Token: 0x170041EB RID: 16875
		' (get) Token: 0x0600AA29 RID: 43561 RVA: 0x0004F48E File Offset: 0x0004D68E
		' (set) Token: 0x0600AA2A RID: 43562 RVA: 0x0004F498 File Offset: 0x0004D698
		Friend Overridable Property F1 As TextBox

		' Token: 0x170041EC RID: 16876
		' (get) Token: 0x0600AA2B RID: 43563 RVA: 0x0004F4A1 File Offset: 0x0004D6A1
		' (set) Token: 0x0600AA2C RID: 43564 RVA: 0x00722DBC File Offset: 0x00720FBC
		Private _Button12 As Button
		Friend Overridable Property Button12 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button12_Click
				Dim button As Button = Me._Button12
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button12 = value
				button = Me._Button12
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041ED RID: 16877
		' (get) Token: 0x0600AA2D RID: 43565 RVA: 0x0004F4AB File Offset: 0x0004D6AB
		' (set) Token: 0x0600AA2E RID: 43566 RVA: 0x0004F4B5 File Offset: 0x0004D6B5
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x170041EE RID: 16878
		' (get) Token: 0x0600AA2F RID: 43567 RVA: 0x0004F4BE File Offset: 0x0004D6BE
		' (set) Token: 0x0600AA30 RID: 43568 RVA: 0x00722E00 File Offset: 0x00721000
		Private _Button25 As Button
		Friend Overridable Property Button25 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button25
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button25_Click
				Dim button As Button = Me._Button25
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button25 = value
				button = Me._Button25
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041EF RID: 16879
		' (get) Token: 0x0600AA31 RID: 43569 RVA: 0x0004F4C8 File Offset: 0x0004D6C8
		' (set) Token: 0x0600AA32 RID: 43570 RVA: 0x00722E44 File Offset: 0x00721044
		Private _Button32 As Button
		Friend Overridable Property Button32 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button32
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button32_Click
				Dim button As Button = Me._Button32
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button32 = value
				button = Me._Button32
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041F0 RID: 16880
		' (get) Token: 0x0600AA33 RID: 43571 RVA: 0x0004F4D2 File Offset: 0x0004D6D2
		' (set) Token: 0x0600AA34 RID: 43572 RVA: 0x0004F4DC File Offset: 0x0004D6DC
		Friend Overridable Property Label23 As Label

		' Token: 0x170041F1 RID: 16881
		' (get) Token: 0x0600AA35 RID: 43573 RVA: 0x0004F4E5 File Offset: 0x0004D6E5
		' (set) Token: 0x0600AA36 RID: 43574 RVA: 0x0004F4EF File Offset: 0x0004D6EF
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x170041F2 RID: 16882
		' (get) Token: 0x0600AA37 RID: 43575 RVA: 0x0004F4F8 File Offset: 0x0004D6F8
		' (set) Token: 0x0600AA38 RID: 43576 RVA: 0x0004F502 File Offset: 0x0004D702
		Friend Overridable Property txtCGST As TextBox

		' Token: 0x170041F3 RID: 16883
		' (get) Token: 0x0600AA39 RID: 43577 RVA: 0x0004F50B File Offset: 0x0004D70B
		' (set) Token: 0x0600AA3A RID: 43578 RVA: 0x00722E88 File Offset: 0x00721088
		Private _Button35 As Button
		Friend Overridable Property Button35 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button35_Click
				Dim button As Button = Me._Button35
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button35 = value
				button = Me._Button35
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041F4 RID: 16884
		' (get) Token: 0x0600AA3B RID: 43579 RVA: 0x0004F515 File Offset: 0x0004D715
		' (set) Token: 0x0600AA3C RID: 43580 RVA: 0x00722ECC File Offset: 0x007210CC
		Private _Button34 As Button
		Friend Overridable Property Button34 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button34
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button34_Click
				Dim button As Button = Me._Button34
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button34 = value
				button = Me._Button34
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041F5 RID: 16885
		' (get) Token: 0x0600AA3D RID: 43581 RVA: 0x0004F51F File Offset: 0x0004D71F
		' (set) Token: 0x0600AA3E RID: 43582 RVA: 0x00722F10 File Offset: 0x00721110
		Private _Button13 As Button
		Friend Overridable Property Button13 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button13_Click
				Dim button As Button = Me._Button13
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button13 = value
				button = Me._Button13
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041F6 RID: 16886
		' (get) Token: 0x0600AA3F RID: 43583 RVA: 0x0004F529 File Offset: 0x0004D729
		' (set) Token: 0x0600AA40 RID: 43584 RVA: 0x0004F533 File Offset: 0x0004D733
		Friend Overridable Property RichTextBox1 As RichTextBox

		' Token: 0x170041F7 RID: 16887
		' (get) Token: 0x0600AA41 RID: 43585 RVA: 0x0004F53C File Offset: 0x0004D73C
		' (set) Token: 0x0600AA42 RID: 43586 RVA: 0x0004F546 File Offset: 0x0004D746
		Friend Overridable Property txtWPort As Label

		' Token: 0x170041F8 RID: 16888
		' (get) Token: 0x0600AA43 RID: 43587 RVA: 0x0004F54F File Offset: 0x0004D74F
		' (set) Token: 0x0600AA44 RID: 43588 RVA: 0x00722F54 File Offset: 0x00721154
		Private _txtNP As TextBox
		Friend Overridable Property txtNP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNP_KeyDown
				Dim textBox As TextBox = Me._txtNP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNP = value
				textBox = Me._txtNP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170041F9 RID: 16889
		' (get) Token: 0x0600AA45 RID: 43589 RVA: 0x0004F559 File Offset: 0x0004D759
		' (set) Token: 0x0600AA46 RID: 43590 RVA: 0x0004F563 File Offset: 0x0004D763
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x170041FA RID: 16890
		' (get) Token: 0x0600AA47 RID: 43591 RVA: 0x0004F56C File Offset: 0x0004D76C
		' (set) Token: 0x0600AA48 RID: 43592 RVA: 0x0004F576 File Offset: 0x0004D776
		Friend Overridable Property Label1 As Label

		' Token: 0x170041FB RID: 16891
		' (get) Token: 0x0600AA49 RID: 43593 RVA: 0x0004F57F File Offset: 0x0004D77F
		' (set) Token: 0x0600AA4A RID: 43594 RVA: 0x0004F589 File Offset: 0x0004D789
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170041FC RID: 16892
		' (get) Token: 0x0600AA4B RID: 43595 RVA: 0x0004F592 File Offset: 0x0004D792
		' (set) Token: 0x0600AA4C RID: 43596 RVA: 0x00722F98 File Offset: 0x00721198
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

		' Token: 0x170041FD RID: 16893
		' (get) Token: 0x0600AA4D RID: 43597 RVA: 0x0004F59C File Offset: 0x0004D79C
		' (set) Token: 0x0600AA4E RID: 43598 RVA: 0x0004F5A6 File Offset: 0x0004D7A6
		Friend Overridable Property SerialPort1 As SerialPort

		' Token: 0x170041FE RID: 16894
		' (get) Token: 0x0600AA4F RID: 43599 RVA: 0x0004F5AF File Offset: 0x0004D7AF
		' (set) Token: 0x0600AA50 RID: 43600 RVA: 0x0004F5B9 File Offset: 0x0004D7B9
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x170041FF RID: 16895
		' (get) Token: 0x0600AA51 RID: 43601 RVA: 0x0004F5C2 File Offset: 0x0004D7C2
		' (set) Token: 0x0600AA52 RID: 43602 RVA: 0x0004F5CC File Offset: 0x0004D7CC
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17004200 RID: 16896
		' (get) Token: 0x0600AA53 RID: 43603 RVA: 0x0004F5D5 File Offset: 0x0004D7D5
		' (set) Token: 0x0600AA54 RID: 43604 RVA: 0x0004F5DF File Offset: 0x0004D7DF
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004201 RID: 16897
		' (get) Token: 0x0600AA55 RID: 43605 RVA: 0x0004F5E8 File Offset: 0x0004D7E8
		' (set) Token: 0x0600AA56 RID: 43606 RVA: 0x0004F5F2 File Offset: 0x0004D7F2
		Friend Overridable Property Label16 As Label

		' Token: 0x17004202 RID: 16898
		' (get) Token: 0x0600AA57 RID: 43607 RVA: 0x0004F5FB File Offset: 0x0004D7FB
		' (set) Token: 0x0600AA58 RID: 43608 RVA: 0x0004F605 File Offset: 0x0004D805
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004203 RID: 16899
		' (get) Token: 0x0600AA59 RID: 43609 RVA: 0x0004F60E File Offset: 0x0004D80E
		' (set) Token: 0x0600AA5A RID: 43610 RVA: 0x0004F618 File Offset: 0x0004D818
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17004204 RID: 16900
		' (get) Token: 0x0600AA5B RID: 43611 RVA: 0x0004F621 File Offset: 0x0004D821
		' (set) Token: 0x0600AA5C RID: 43612 RVA: 0x0004F62B File Offset: 0x0004D82B
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004205 RID: 16901
		' (get) Token: 0x0600AA5D RID: 43613 RVA: 0x0004F634 File Offset: 0x0004D834
		' (set) Token: 0x0600AA5E RID: 43614 RVA: 0x0004F63E File Offset: 0x0004D83E
		Friend Overridable Property txtCompanyState As TextBox

		' Token: 0x17004206 RID: 16902
		' (get) Token: 0x0600AA5F RID: 43615 RVA: 0x0004F647 File Offset: 0x0004D847
		' (set) Token: 0x0600AA60 RID: 43616 RVA: 0x00722FDC File Offset: 0x007211DC
		Private _txtProductID As TextBox
		Friend Overridable Property txtProductID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtProductID_TextChanged
				Dim textBox As TextBox = Me._txtProductID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtProductID = value
				textBox = Me._txtProductID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004207 RID: 16903
		' (get) Token: 0x0600AA61 RID: 43617 RVA: 0x0004F651 File Offset: 0x0004D851
		' (set) Token: 0x0600AA62 RID: 43618 RVA: 0x0004F65B File Offset: 0x0004D85B
		Friend Overridable Property txtQ_ID As TextBox

		' Token: 0x17004208 RID: 16904
		' (get) Token: 0x0600AA63 RID: 43619 RVA: 0x0004F664 File Offset: 0x0004D864
		' (set) Token: 0x0600AA64 RID: 43620 RVA: 0x00723020 File Offset: 0x00721220
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClose_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004209 RID: 16905
		' (get) Token: 0x0600AA65 RID: 43621 RVA: 0x0004F66E File Offset: 0x0004D86E
		' (set) Token: 0x0600AA66 RID: 43622 RVA: 0x0004F678 File Offset: 0x0004D878
		Friend Overridable Property txtCID As TextBox

		' Token: 0x1700420A RID: 16906
		' (get) Token: 0x0600AA67 RID: 43623 RVA: 0x0004F681 File Offset: 0x0004D881
		' (set) Token: 0x0600AA68 RID: 43624 RVA: 0x0004F68B File Offset: 0x0004D88B
		Friend Overridable Property txtTotalQty As TextBox

		' Token: 0x1700420B RID: 16907
		' (get) Token: 0x0600AA69 RID: 43625 RVA: 0x0004F694 File Offset: 0x0004D894
		' (set) Token: 0x0600AA6A RID: 43626 RVA: 0x0004F69E File Offset: 0x0004D89E
		Friend Overridable Property lblUserType As Label

		' Token: 0x1700420C RID: 16908
		' (get) Token: 0x0600AA6B RID: 43627 RVA: 0x0004F6A7 File Offset: 0x0004D8A7
		' (set) Token: 0x0600AA6C RID: 43628 RVA: 0x0004F6B1 File Offset: 0x0004D8B1
		Friend Overridable Property lblSet As Label

		' Token: 0x1700420D RID: 16909
		' (get) Token: 0x0600AA6D RID: 43629 RVA: 0x0004F6BA File Offset: 0x0004D8BA
		' (set) Token: 0x0600AA6E RID: 43630 RVA: 0x0004F6C4 File Offset: 0x0004D8C4
		Friend Overridable Property lblUser As Label

		' Token: 0x1700420E RID: 16910
		' (get) Token: 0x0600AA6F RID: 43631 RVA: 0x0004F6CD File Offset: 0x0004D8CD
		' (set) Token: 0x0600AA70 RID: 43632 RVA: 0x00723064 File Offset: 0x00721264
		Private _txtDiscPer As TextBox
		Friend Overridable Property txtDiscPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscPer_KeyDown
				Dim textBox As TextBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscPer = value
				textBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700420F RID: 16911
		' (get) Token: 0x0600AA71 RID: 43633 RVA: 0x0004F6D7 File Offset: 0x0004D8D7
		' (set) Token: 0x0600AA72 RID: 43634 RVA: 0x0004F6E1 File Offset: 0x0004D8E1
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17004210 RID: 16912
		' (get) Token: 0x0600AA73 RID: 43635 RVA: 0x0004F6EA File Offset: 0x0004D8EA
		' (set) Token: 0x0600AA74 RID: 43636 RVA: 0x007230E0 File Offset: 0x007212E0
		Private _txtDiscAmtPerQty As TextBox
		Friend Overridable Property txtDiscAmtPerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscAmtPerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscAmtPerQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyDown
				Dim textBox As TextBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscAmtPerQty = value
				textBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004211 RID: 16913
		' (get) Token: 0x0600AA75 RID: 43637 RVA: 0x0004F6F4 File Offset: 0x0004D8F4
		' (set) Token: 0x0600AA76 RID: 43638 RVA: 0x0004F6FE File Offset: 0x0004D8FE
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004212 RID: 16914
		' (get) Token: 0x0600AA77 RID: 43639 RVA: 0x0004F707 File Offset: 0x0004D907
		' (set) Token: 0x0600AA78 RID: 43640 RVA: 0x0072315C File Offset: 0x0072135C
		Private _CheckBox13 As CheckBox
		Friend Overridable Property CheckBox13 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox13_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox13
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox13 = value
				checkBox = Me._CheckBox13
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004213 RID: 16915
		' (get) Token: 0x0600AA79 RID: 43641 RVA: 0x0004F711 File Offset: 0x0004D911
		' (set) Token: 0x0600AA7A RID: 43642 RVA: 0x0004F71B File Offset: 0x0004D91B
		Friend Overridable Property Label37 As Label

		' Token: 0x17004214 RID: 16916
		' (get) Token: 0x0600AA7B RID: 43643 RVA: 0x0004F724 File Offset: 0x0004D924
		' (set) Token: 0x0600AA7C RID: 43644 RVA: 0x007231A0 File Offset: 0x007213A0
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.ComboBox1_TextChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.TextChanged, eventHandler2
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.TextChanged, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004215 RID: 16917
		' (get) Token: 0x0600AA7D RID: 43645 RVA: 0x0004F72E File Offset: 0x0004D92E
		' (set) Token: 0x0600AA7E RID: 43646 RVA: 0x0004F738 File Offset: 0x0004D938
		Friend Overridable Property Label27 As Label

		' Token: 0x17004216 RID: 16918
		' (get) Token: 0x0600AA7F RID: 43647 RVA: 0x0004F741 File Offset: 0x0004D941
		' (set) Token: 0x0600AA80 RID: 43648 RVA: 0x0004F74B File Offset: 0x0004D94B
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17004217 RID: 16919
		' (get) Token: 0x0600AA81 RID: 43649 RVA: 0x0004F754 File Offset: 0x0004D954
		' (set) Token: 0x0600AA82 RID: 43650 RVA: 0x0004F75E File Offset: 0x0004D95E
		Friend Overridable Property Label29 As Label

		' Token: 0x17004218 RID: 16920
		' (get) Token: 0x0600AA83 RID: 43651 RVA: 0x0004F767 File Offset: 0x0004D967
		' (set) Token: 0x0600AA84 RID: 43652 RVA: 0x00723200 File Offset: 0x00721400
		Private _cmbUnit As ComboBox
		Friend Overridable Property cmbUnit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbUnit_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbUnit_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbUnit_Validated
				Dim comboBox As ComboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validated, eventHandler2
				End If
				Me._cmbUnit = value
				comboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validated, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004219 RID: 16921
		' (get) Token: 0x0600AA85 RID: 43653 RVA: 0x0004F771 File Offset: 0x0004D971
		' (set) Token: 0x0600AA86 RID: 43654 RVA: 0x0004F77B File Offset: 0x0004D97B
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x1700421A RID: 16922
		' (get) Token: 0x0600AA87 RID: 43655 RVA: 0x0004F784 File Offset: 0x0004D984
		' (set) Token: 0x0600AA88 RID: 43656 RVA: 0x0072327C File Offset: 0x0072147C
		Private _cmbaltunit As ComboBox
		Friend Overridable Property cmbaltunit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbaltunit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbaltunit_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbaltunit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbaltunit = value
				comboBox = Me._cmbaltunit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700421B RID: 16923
		' (get) Token: 0x0600AA89 RID: 43657 RVA: 0x0004F78E File Offset: 0x0004D98E
		' (set) Token: 0x0600AA8A RID: 43658 RVA: 0x007232C0 File Offset: 0x007214C0
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700421C RID: 16924
		' (get) Token: 0x0600AA8B RID: 43659 RVA: 0x0004F798 File Offset: 0x0004D998
		' (set) Token: 0x0600AA8C RID: 43660 RVA: 0x0004F7A2 File Offset: 0x0004D9A2
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x1700421D RID: 16925
		' (get) Token: 0x0600AA8D RID: 43661 RVA: 0x0004F7AB File Offset: 0x0004D9AB
		' (set) Token: 0x0600AA8E RID: 43662 RVA: 0x00723304 File Offset: 0x00721504
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox2_TextChanged
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700421E RID: 16926
		' (get) Token: 0x0600AA8F RID: 43663 RVA: 0x0004F7B5 File Offset: 0x0004D9B5
		' (set) Token: 0x0600AA90 RID: 43664 RVA: 0x0004F7BF File Offset: 0x0004D9BF
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x1700421F RID: 16927
		' (get) Token: 0x0600AA91 RID: 43665 RVA: 0x0004F7C8 File Offset: 0x0004D9C8
		' (set) Token: 0x0600AA92 RID: 43666 RVA: 0x00723348 File Offset: 0x00721548
		Private _txtPricePerQty As TextBox
		Friend Overridable Property txtPricePerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPricePerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPricePerQty_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtPricePerQty_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPricePerQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtPricePerQty_GotFocus
				Dim eventHandler3 As EventHandler = AddressOf Me.txtPricePerQty_LostFocus
				Dim textBox As TextBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.GotFocus, eventHandler2
					RemoveHandler textBox.LostFocus, eventHandler3
				End If
				Me._txtPricePerQty = value
				textBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.GotFocus, eventHandler2
					AddHandler textBox.LostFocus, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x17004220 RID: 16928
		' (get) Token: 0x0600AA93 RID: 43667 RVA: 0x0004F7D2 File Offset: 0x0004D9D2
		' (set) Token: 0x0600AA94 RID: 43668 RVA: 0x0004F7DC File Offset: 0x0004D9DC
		Friend Overridable Property Label24 As Label

		' Token: 0x17004221 RID: 16929
		' (get) Token: 0x0600AA95 RID: 43669 RVA: 0x0004F7E5 File Offset: 0x0004D9E5
		' (set) Token: 0x0600AA96 RID: 43670 RVA: 0x0004F7EF File Offset: 0x0004D9EF
		Friend Overridable Property Label11 As Label

		' Token: 0x17004222 RID: 16930
		' (get) Token: 0x0600AA97 RID: 43671 RVA: 0x0004F7F8 File Offset: 0x0004D9F8
		' (set) Token: 0x0600AA98 RID: 43672 RVA: 0x0004F802 File Offset: 0x0004DA02
		Friend Overridable Property Label20 As Label

		' Token: 0x17004223 RID: 16931
		' (get) Token: 0x0600AA99 RID: 43673 RVA: 0x0004F80B File Offset: 0x0004DA0B
		' (set) Token: 0x0600AA9A RID: 43674 RVA: 0x00723408 File Offset: 0x00721608
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw4_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004224 RID: 16932
		' (get) Token: 0x0600AA9B RID: 43675 RVA: 0x0004F815 File Offset: 0x0004DA15
		' (set) Token: 0x0600AA9C RID: 43676 RVA: 0x0004F81F File Offset: 0x0004DA1F
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17004225 RID: 16933
		' (get) Token: 0x0600AA9D RID: 43677 RVA: 0x0004F828 File Offset: 0x0004DA28
		' (set) Token: 0x0600AA9E RID: 43678 RVA: 0x0004F832 File Offset: 0x0004DA32
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17004226 RID: 16934
		' (get) Token: 0x0600AA9F RID: 43679 RVA: 0x0004F83B File Offset: 0x0004DA3B
		' (set) Token: 0x0600AAA0 RID: 43680 RVA: 0x0004F845 File Offset: 0x0004DA45
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17004227 RID: 16935
		' (get) Token: 0x0600AAA1 RID: 43681 RVA: 0x0004F84E File Offset: 0x0004DA4E
		' (set) Token: 0x0600AAA2 RID: 43682 RVA: 0x0004F858 File Offset: 0x0004DA58
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17004228 RID: 16936
		' (get) Token: 0x0600AAA3 RID: 43683 RVA: 0x0004F861 File Offset: 0x0004DA61
		' (set) Token: 0x0600AAA4 RID: 43684 RVA: 0x0004F86B File Offset: 0x0004DA6B
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17004229 RID: 16937
		' (get) Token: 0x0600AAA5 RID: 43685 RVA: 0x0004F874 File Offset: 0x0004DA74
		' (set) Token: 0x0600AAA6 RID: 43686 RVA: 0x0004F87E File Offset: 0x0004DA7E
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x1700422A RID: 16938
		' (get) Token: 0x0600AAA7 RID: 43687 RVA: 0x0004F887 File Offset: 0x0004DA87
		' (set) Token: 0x0600AAA8 RID: 43688 RVA: 0x0004F891 File Offset: 0x0004DA91
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x1700422B RID: 16939
		' (get) Token: 0x0600AAA9 RID: 43689 RVA: 0x0004F89A File Offset: 0x0004DA9A
		' (set) Token: 0x0600AAAA RID: 43690 RVA: 0x0004F8A4 File Offset: 0x0004DAA4
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x1700422C RID: 16940
		' (get) Token: 0x0600AAAB RID: 43691 RVA: 0x0004F8AD File Offset: 0x0004DAAD
		' (set) Token: 0x0600AAAC RID: 43692 RVA: 0x0004F8B7 File Offset: 0x0004DAB7
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x1700422D RID: 16941
		' (get) Token: 0x0600AAAD RID: 43693 RVA: 0x0004F8C0 File Offset: 0x0004DAC0
		' (set) Token: 0x0600AAAE RID: 43694 RVA: 0x0004F8CA File Offset: 0x0004DACA
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x1700422E RID: 16942
		' (get) Token: 0x0600AAAF RID: 43695 RVA: 0x0004F8D3 File Offset: 0x0004DAD3
		' (set) Token: 0x0600AAB0 RID: 43696 RVA: 0x0004F8DD File Offset: 0x0004DADD
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x1700422F RID: 16943
		' (get) Token: 0x0600AAB1 RID: 43697 RVA: 0x0004F8E6 File Offset: 0x0004DAE6
		' (set) Token: 0x0600AAB2 RID: 43698 RVA: 0x0004F8F0 File Offset: 0x0004DAF0
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17004230 RID: 16944
		' (get) Token: 0x0600AAB3 RID: 43699 RVA: 0x0004F8F9 File Offset: 0x0004DAF9
		' (set) Token: 0x0600AAB4 RID: 43700 RVA: 0x0004F903 File Offset: 0x0004DB03
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17004231 RID: 16945
		' (get) Token: 0x0600AAB5 RID: 43701 RVA: 0x0004F90C File Offset: 0x0004DB0C
		' (set) Token: 0x0600AAB6 RID: 43702 RVA: 0x0004F916 File Offset: 0x0004DB16
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17004232 RID: 16946
		' (get) Token: 0x0600AAB7 RID: 43703 RVA: 0x0004F91F File Offset: 0x0004DB1F
		' (set) Token: 0x0600AAB8 RID: 43704 RVA: 0x0004F929 File Offset: 0x0004DB29
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17004233 RID: 16947
		' (get) Token: 0x0600AAB9 RID: 43705 RVA: 0x0004F932 File Offset: 0x0004DB32
		' (set) Token: 0x0600AABA RID: 43706 RVA: 0x0004F93C File Offset: 0x0004DB3C
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17004234 RID: 16948
		' (get) Token: 0x0600AABB RID: 43707 RVA: 0x0004F945 File Offset: 0x0004DB45
		' (set) Token: 0x0600AABC RID: 43708 RVA: 0x0004F94F File Offset: 0x0004DB4F
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17004235 RID: 16949
		' (get) Token: 0x0600AABD RID: 43709 RVA: 0x0004F958 File Offset: 0x0004DB58
		' (set) Token: 0x0600AABE RID: 43710 RVA: 0x0004F962 File Offset: 0x0004DB62
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17004236 RID: 16950
		' (get) Token: 0x0600AABF RID: 43711 RVA: 0x0004F96B File Offset: 0x0004DB6B
		' (set) Token: 0x0600AAC0 RID: 43712 RVA: 0x0004F975 File Offset: 0x0004DB75
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17004237 RID: 16951
		' (get) Token: 0x0600AAC1 RID: 43713 RVA: 0x0004F97E File Offset: 0x0004DB7E
		' (set) Token: 0x0600AAC2 RID: 43714 RVA: 0x0004F988 File Offset: 0x0004DB88
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17004238 RID: 16952
		' (get) Token: 0x0600AAC3 RID: 43715 RVA: 0x0004F991 File Offset: 0x0004DB91
		' (set) Token: 0x0600AAC4 RID: 43716 RVA: 0x007234A8 File Offset: 0x007216A8
		Private _cmbDiscountType As ComboBox
		Friend Overridable Property cmbDiscountType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDiscountType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbDiscountType_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbDiscountType_KeyDown
				Dim comboBox As ComboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbDiscountType = value
				comboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004239 RID: 16953
		' (get) Token: 0x0600AAC5 RID: 43717 RVA: 0x0004F99B File Offset: 0x0004DB9B
		' (set) Token: 0x0600AAC6 RID: 43718 RVA: 0x0004F9A5 File Offset: 0x0004DBA5
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x1700423A RID: 16954
		' (get) Token: 0x0600AAC7 RID: 43719 RVA: 0x0004F9AE File Offset: 0x0004DBAE
		' (set) Token: 0x0600AAC8 RID: 43720 RVA: 0x00723508 File Offset: 0x00721708
		Private _btnListUpdate As Button
		Friend Overridable Property btnListUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListUpdate_Click
				Dim button As Button = Me._btnListUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListUpdate = value
				button = Me._btnListUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700423B RID: 16955
		' (get) Token: 0x0600AAC9 RID: 43721 RVA: 0x0004F9B8 File Offset: 0x0004DBB8
		' (set) Token: 0x0600AACA RID: 43722 RVA: 0x0004F9C2 File Offset: 0x0004DBC2
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x1700423C RID: 16956
		' (get) Token: 0x0600AACB RID: 43723 RVA: 0x0004F9CB File Offset: 0x0004DBCB
		' (set) Token: 0x0600AACC RID: 43724 RVA: 0x0072354C File Offset: 0x0072174C
		Private _btnRemove As Button
		Friend Overridable Property btnRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim button As Button = Me._btnRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemove = value
				button = Me._btnRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700423D RID: 16957
		' (get) Token: 0x0600AACD RID: 43725 RVA: 0x0004F9D5 File Offset: 0x0004DBD5
		' (set) Token: 0x0600AACE RID: 43726 RVA: 0x00723590 File Offset: 0x00721790
		Private _btnListReset As Button
		Friend Overridable Property btnListReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListReset_Click
				Dim button As Button = Me._btnListReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListReset = value
				button = Me._btnListReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700423E RID: 16958
		' (get) Token: 0x0600AACF RID: 43727 RVA: 0x0004F9DF File Offset: 0x0004DBDF
		' (set) Token: 0x0600AAD0 RID: 43728 RVA: 0x0004F9E9 File Offset: 0x0004DBE9
		Friend Overridable Property Label34 As Label

		' Token: 0x1700423F RID: 16959
		' (get) Token: 0x0600AAD1 RID: 43729 RVA: 0x0004F9F2 File Offset: 0x0004DBF2
		' (set) Token: 0x0600AAD2 RID: 43730 RVA: 0x0004F9FC File Offset: 0x0004DBFC
		Friend Overridable Property Label41 As Label

		' Token: 0x17004240 RID: 16960
		' (get) Token: 0x0600AAD3 RID: 43731 RVA: 0x0004FA05 File Offset: 0x0004DC05
		' (set) Token: 0x0600AAD4 RID: 43732 RVA: 0x0004FA0F File Offset: 0x0004DC0F
		Friend Overridable Property Label35 As Label

		' Token: 0x17004241 RID: 16961
		' (get) Token: 0x0600AAD5 RID: 43733 RVA: 0x0004FA18 File Offset: 0x0004DC18
		' (set) Token: 0x0600AAD6 RID: 43734 RVA: 0x0004FA22 File Offset: 0x0004DC22
		Friend Overridable Property txtIGSTPer As TextBox

		' Token: 0x17004242 RID: 16962
		' (get) Token: 0x0600AAD7 RID: 43735 RVA: 0x0004FA2B File Offset: 0x0004DC2B
		' (set) Token: 0x0600AAD8 RID: 43736 RVA: 0x0004FA35 File Offset: 0x0004DC35
		Friend Overridable Property Label42 As Label

		' Token: 0x17004243 RID: 16963
		' (get) Token: 0x0600AAD9 RID: 43737 RVA: 0x0004FA3E File Offset: 0x0004DC3E
		' (set) Token: 0x0600AADA RID: 43738 RVA: 0x007235D4 File Offset: 0x007217D4
		Private _txtDisc As TextBox
		Friend Overridable Property txtDisc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDisc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDisc_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtDisc_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDisc_KeyDown
				Dim textBox As TextBox = Me._txtDisc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDisc = value
				textBox = Me._txtDisc
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004244 RID: 16964
		' (get) Token: 0x0600AADB RID: 43739 RVA: 0x0004FA48 File Offset: 0x0004DC48
		' (set) Token: 0x0600AADC RID: 43740 RVA: 0x00723650 File Offset: 0x00721850
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004245 RID: 16965
		' (get) Token: 0x0600AADD RID: 43741 RVA: 0x0004FA52 File Offset: 0x0004DC52
		' (set) Token: 0x0600AADE RID: 43742 RVA: 0x0004FA5C File Offset: 0x0004DC5C
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17004246 RID: 16966
		' (get) Token: 0x0600AADF RID: 43743 RVA: 0x0004FA65 File Offset: 0x0004DC65
		' (set) Token: 0x0600AAE0 RID: 43744 RVA: 0x00723694 File Offset: 0x00721894
		Private _txtRemarks As TextBox
		Friend Overridable Property txtRemarks As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim textBox As TextBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				textBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004247 RID: 16967
		' (get) Token: 0x0600AAE1 RID: 43745 RVA: 0x0004FA6F File Offset: 0x0004DC6F
		' (set) Token: 0x0600AAE2 RID: 43746 RVA: 0x0004FA79 File Offset: 0x0004DC79
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004248 RID: 16968
		' (get) Token: 0x0600AAE3 RID: 43747 RVA: 0x0004FA82 File Offset: 0x0004DC82
		' (set) Token: 0x0600AAE4 RID: 43748 RVA: 0x007236D8 File Offset: 0x007218D8
		Private _Button14 As Button
		Friend Overridable Property Button14 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button14_Click
				Dim button As Button = Me._Button14
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button14 = value
				button = Me._Button14
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004249 RID: 16969
		' (get) Token: 0x0600AAE5 RID: 43749 RVA: 0x0004FA8C File Offset: 0x0004DC8C
		' (set) Token: 0x0600AAE6 RID: 43750 RVA: 0x0004FA96 File Offset: 0x0004DC96
		Friend Overridable Property Panel7 As Panel

		' Token: 0x1700424A RID: 16970
		' (get) Token: 0x0600AAE7 RID: 43751 RVA: 0x0004FA9F File Offset: 0x0004DC9F
		' (set) Token: 0x0600AAE8 RID: 43752 RVA: 0x0072371C File Offset: 0x0072191C
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click_1
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

		' Token: 0x1700424B RID: 16971
		' (get) Token: 0x0600AAE9 RID: 43753 RVA: 0x0004FAA9 File Offset: 0x0004DCA9
		' (set) Token: 0x0600AAEA RID: 43754 RVA: 0x00723760 File Offset: 0x00721960
		Private _Button11 As Button
		Friend Overridable Property Button11 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button11_Click
				Dim button As Button = Me._Button11
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button11 = value
				button = Me._Button11
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700424C RID: 16972
		' (get) Token: 0x0600AAEB RID: 43755 RVA: 0x0004FAB3 File Offset: 0x0004DCB3
		' (set) Token: 0x0600AAEC RID: 43756 RVA: 0x007237A4 File Offset: 0x007219A4
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

		' Token: 0x1700424D RID: 16973
		' (get) Token: 0x0600AAED RID: 43757 RVA: 0x0004FABD File Offset: 0x0004DCBD
		' (set) Token: 0x0600AAEE RID: 43758 RVA: 0x007237E8 File Offset: 0x007219E8
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700424E RID: 16974
		' (get) Token: 0x0600AAEF RID: 43759 RVA: 0x0004FAC7 File Offset: 0x0004DCC7
		' (set) Token: 0x0600AAF0 RID: 43760 RVA: 0x0072382C File Offset: 0x00721A2C
		Private _Button7 As Button
		Friend Overridable Property Button7 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
				Dim button As Button = Me._Button7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button7 = value
				button = Me._Button7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700424F RID: 16975
		' (get) Token: 0x0600AAF1 RID: 43761 RVA: 0x0004FAD1 File Offset: 0x0004DCD1
		' (set) Token: 0x0600AAF2 RID: 43762 RVA: 0x00723870 File Offset: 0x00721A70
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

		' Token: 0x17004250 RID: 16976
		' (get) Token: 0x0600AAF3 RID: 43763 RVA: 0x0004FADB File Offset: 0x0004DCDB
		' (set) Token: 0x0600AAF4 RID: 43764 RVA: 0x007238B4 File Offset: 0x00721AB4
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

		' Token: 0x17004251 RID: 16977
		' (get) Token: 0x0600AAF5 RID: 43765 RVA: 0x0004FAE5 File Offset: 0x0004DCE5
		' (set) Token: 0x0600AAF6 RID: 43766 RVA: 0x007238F8 File Offset: 0x00721AF8
		Private _Button8 As Button
		Friend Overridable Property Button8 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button8_Click
				Dim button As Button = Me._Button8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button8 = value
				button = Me._Button8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004252 RID: 16978
		' (get) Token: 0x0600AAF7 RID: 43767 RVA: 0x0004FAEF File Offset: 0x0004DCEF
		' (set) Token: 0x0600AAF8 RID: 43768 RVA: 0x0004FAF9 File Offset: 0x0004DCF9
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004253 RID: 16979
		' (get) Token: 0x0600AAF9 RID: 43769 RVA: 0x0004FB02 File Offset: 0x0004DD02
		' (set) Token: 0x0600AAFA RID: 43770 RVA: 0x0004FB0C File Offset: 0x0004DD0C
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17004254 RID: 16980
		' (get) Token: 0x0600AAFB RID: 43771 RVA: 0x0004FB15 File Offset: 0x0004DD15
		' (set) Token: 0x0600AAFC RID: 43772 RVA: 0x0004FB1F File Offset: 0x0004DD1F
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17004255 RID: 16981
		' (get) Token: 0x0600AAFD RID: 43773 RVA: 0x0004FB28 File Offset: 0x0004DD28
		' (set) Token: 0x0600AAFE RID: 43774 RVA: 0x0004FB32 File Offset: 0x0004DD32
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17004256 RID: 16982
		' (get) Token: 0x0600AAFF RID: 43775 RVA: 0x0004FB3B File Offset: 0x0004DD3B
		' (set) Token: 0x0600AB00 RID: 43776 RVA: 0x0004FB45 File Offset: 0x0004DD45
		Friend Overridable Property dgwsale As DataGridView

		' Token: 0x17004257 RID: 16983
		' (get) Token: 0x0600AB01 RID: 43777 RVA: 0x0004FB4E File Offset: 0x0004DD4E
		' (set) Token: 0x0600AB02 RID: 43778 RVA: 0x0004FB58 File Offset: 0x0004DD58
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17004258 RID: 16984
		' (get) Token: 0x0600AB03 RID: 43779 RVA: 0x0004FB61 File Offset: 0x0004DD61
		' (set) Token: 0x0600AB04 RID: 43780 RVA: 0x0004FB6B File Offset: 0x0004DD6B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004259 RID: 16985
		' (get) Token: 0x0600AB05 RID: 43781 RVA: 0x0004FB74 File Offset: 0x0004DD74
		' (set) Token: 0x0600AB06 RID: 43782 RVA: 0x0072393C File Offset: 0x00721B3C
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
				Dim dataGridViewRowsRemovedEventHandler As DataGridViewRowsRemovedEventHandler = AddressOf Me.DataGridView1_RowsRemoved
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.DataGridView1_CellFormatting
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.RowsRemoved, dataGridViewRowsRemovedEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.RowsRemoved, dataGridViewRowsRemovedEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700425A RID: 16986
		' (get) Token: 0x0600AB07 RID: 43783 RVA: 0x0004FB7E File Offset: 0x0004DD7E
		' (set) Token: 0x0600AB08 RID: 43784 RVA: 0x0004FB88 File Offset: 0x0004DD88
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700425B RID: 16987
		' (get) Token: 0x0600AB09 RID: 43785 RVA: 0x0004FB91 File Offset: 0x0004DD91
		' (set) Token: 0x0600AB0A RID: 43786 RVA: 0x0004FB9B File Offset: 0x0004DD9B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700425C RID: 16988
		' (get) Token: 0x0600AB0B RID: 43787 RVA: 0x0004FBA4 File Offset: 0x0004DDA4
		' (set) Token: 0x0600AB0C RID: 43788 RVA: 0x0004FBAE File Offset: 0x0004DDAE
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700425D RID: 16989
		' (get) Token: 0x0600AB0D RID: 43789 RVA: 0x0004FBB7 File Offset: 0x0004DDB7
		' (set) Token: 0x0600AB0E RID: 43790 RVA: 0x0004FBC1 File Offset: 0x0004DDC1
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700425E RID: 16990
		' (get) Token: 0x0600AB0F RID: 43791 RVA: 0x0004FBCA File Offset: 0x0004DDCA
		' (set) Token: 0x0600AB10 RID: 43792 RVA: 0x0004FBD4 File Offset: 0x0004DDD4
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700425F RID: 16991
		' (get) Token: 0x0600AB11 RID: 43793 RVA: 0x0004FBDD File Offset: 0x0004DDDD
		' (set) Token: 0x0600AB12 RID: 43794 RVA: 0x0004FBE7 File Offset: 0x0004DDE7
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004260 RID: 16992
		' (get) Token: 0x0600AB13 RID: 43795 RVA: 0x0004FBF0 File Offset: 0x0004DDF0
		' (set) Token: 0x0600AB14 RID: 43796 RVA: 0x0004FBFA File Offset: 0x0004DDFA
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004261 RID: 16993
		' (get) Token: 0x0600AB15 RID: 43797 RVA: 0x0004FC03 File Offset: 0x0004DE03
		' (set) Token: 0x0600AB16 RID: 43798 RVA: 0x0004FC0D File Offset: 0x0004DE0D
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17004262 RID: 16994
		' (get) Token: 0x0600AB17 RID: 43799 RVA: 0x0004FC16 File Offset: 0x0004DE16
		' (set) Token: 0x0600AB18 RID: 43800 RVA: 0x0004FC20 File Offset: 0x0004DE20
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004263 RID: 16995
		' (get) Token: 0x0600AB19 RID: 43801 RVA: 0x0004FC29 File Offset: 0x0004DE29
		' (set) Token: 0x0600AB1A RID: 43802 RVA: 0x0004FC33 File Offset: 0x0004DE33
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004264 RID: 16996
		' (get) Token: 0x0600AB1B RID: 43803 RVA: 0x0004FC3C File Offset: 0x0004DE3C
		' (set) Token: 0x0600AB1C RID: 43804 RVA: 0x0004FC46 File Offset: 0x0004DE46
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004265 RID: 16997
		' (get) Token: 0x0600AB1D RID: 43805 RVA: 0x0004FC4F File Offset: 0x0004DE4F
		' (set) Token: 0x0600AB1E RID: 43806 RVA: 0x0004FC59 File Offset: 0x0004DE59
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004266 RID: 16998
		' (get) Token: 0x0600AB1F RID: 43807 RVA: 0x0004FC62 File Offset: 0x0004DE62
		' (set) Token: 0x0600AB20 RID: 43808 RVA: 0x0004FC6C File Offset: 0x0004DE6C
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004267 RID: 16999
		' (get) Token: 0x0600AB21 RID: 43809 RVA: 0x0004FC75 File Offset: 0x0004DE75
		' (set) Token: 0x0600AB22 RID: 43810 RVA: 0x0004FC7F File Offset: 0x0004DE7F
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004268 RID: 17000
		' (get) Token: 0x0600AB23 RID: 43811 RVA: 0x0004FC88 File Offset: 0x0004DE88
		' (set) Token: 0x0600AB24 RID: 43812 RVA: 0x0004FC92 File Offset: 0x0004DE92
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004269 RID: 17001
		' (get) Token: 0x0600AB25 RID: 43813 RVA: 0x0004FC9B File Offset: 0x0004DE9B
		' (set) Token: 0x0600AB26 RID: 43814 RVA: 0x0004FCA5 File Offset: 0x0004DEA5
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700426A RID: 17002
		' (get) Token: 0x0600AB27 RID: 43815 RVA: 0x0004FCAE File Offset: 0x0004DEAE
		' (set) Token: 0x0600AB28 RID: 43816 RVA: 0x0004FCB8 File Offset: 0x0004DEB8
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700426B RID: 17003
		' (get) Token: 0x0600AB29 RID: 43817 RVA: 0x0004FCC1 File Offset: 0x0004DEC1
		' (set) Token: 0x0600AB2A RID: 43818 RVA: 0x0004FCCB File Offset: 0x0004DECB
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700426C RID: 17004
		' (get) Token: 0x0600AB2B RID: 43819 RVA: 0x0004FCD4 File Offset: 0x0004DED4
		' (set) Token: 0x0600AB2C RID: 43820 RVA: 0x0004FCDE File Offset: 0x0004DEDE
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700426D RID: 17005
		' (get) Token: 0x0600AB2D RID: 43821 RVA: 0x0004FCE7 File Offset: 0x0004DEE7
		' (set) Token: 0x0600AB2E RID: 43822 RVA: 0x0004FCF1 File Offset: 0x0004DEF1
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700426E RID: 17006
		' (get) Token: 0x0600AB2F RID: 43823 RVA: 0x0004FCFA File Offset: 0x0004DEFA
		' (set) Token: 0x0600AB30 RID: 43824 RVA: 0x0004FD04 File Offset: 0x0004DF04
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x1700426F RID: 17007
		' (get) Token: 0x0600AB31 RID: 43825 RVA: 0x0004FD0D File Offset: 0x0004DF0D
		' (set) Token: 0x0600AB32 RID: 43826 RVA: 0x0004FD17 File Offset: 0x0004DF17
		Friend Overridable Property Label43 As Label

		' Token: 0x17004270 RID: 17008
		' (get) Token: 0x0600AB33 RID: 43827 RVA: 0x0004FD20 File Offset: 0x0004DF20
		' (set) Token: 0x0600AB34 RID: 43828 RVA: 0x0004FD2A File Offset: 0x0004DF2A
		Friend Overridable Property pnlCalc As Panel

		' Token: 0x17004271 RID: 17009
		' (get) Token: 0x0600AB35 RID: 43829 RVA: 0x0004FD33 File Offset: 0x0004DF33
		' (set) Token: 0x0600AB36 RID: 43830 RVA: 0x007239DC File Offset: 0x00721BDC
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

		' Token: 0x17004272 RID: 17010
		' (get) Token: 0x0600AB37 RID: 43831 RVA: 0x0004FD3D File Offset: 0x0004DF3D
		' (set) Token: 0x0600AB38 RID: 43832 RVA: 0x0004FD47 File Offset: 0x0004DF47
		Friend Overridable Property Label32 As Label

		' Token: 0x17004273 RID: 17011
		' (get) Token: 0x0600AB39 RID: 43833 RVA: 0x0004FD50 File Offset: 0x0004DF50
		' (set) Token: 0x0600AB3A RID: 43834 RVA: 0x0004FD5A File Offset: 0x0004DF5A
		Friend Overridable Property txtTotal As TextBox

		' Token: 0x17004274 RID: 17012
		' (get) Token: 0x0600AB3B RID: 43835 RVA: 0x0004FD63 File Offset: 0x0004DF63
		' (set) Token: 0x0600AB3C RID: 43836 RVA: 0x0004FD6D File Offset: 0x0004DF6D
		Friend Overridable Property Label17 As Label

		' Token: 0x17004275 RID: 17013
		' (get) Token: 0x0600AB3D RID: 43837 RVA: 0x0004FD76 File Offset: 0x0004DF76
		' (set) Token: 0x0600AB3E RID: 43838 RVA: 0x0004FD80 File Offset: 0x0004DF80
		Friend Overridable Property Label18 As Label

		' Token: 0x17004276 RID: 17014
		' (get) Token: 0x0600AB3F RID: 43839 RVA: 0x0004FD89 File Offset: 0x0004DF89
		' (set) Token: 0x0600AB40 RID: 43840 RVA: 0x0004FD93 File Offset: 0x0004DF93
		Friend Overridable Property txtRoundOff As TextBox

		' Token: 0x17004277 RID: 17015
		' (get) Token: 0x0600AB41 RID: 43841 RVA: 0x0004FD9C File Offset: 0x0004DF9C
		' (set) Token: 0x0600AB42 RID: 43842 RVA: 0x0004FDA6 File Offset: 0x0004DFA6
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x17004278 RID: 17016
		' (get) Token: 0x0600AB43 RID: 43843 RVA: 0x0004FDAF File Offset: 0x0004DFAF
		' (set) Token: 0x0600AB44 RID: 43844 RVA: 0x0004FDB9 File Offset: 0x0004DFB9
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004279 RID: 17017
		' (get) Token: 0x0600AB45 RID: 43845 RVA: 0x0004FDC2 File Offset: 0x0004DFC2
		' (set) Token: 0x0600AB46 RID: 43846 RVA: 0x0004FDCC File Offset: 0x0004DFCC
		Friend Overridable Property Label28 As Label

		' Token: 0x1700427A RID: 17018
		' (get) Token: 0x0600AB47 RID: 43847 RVA: 0x0004FDD5 File Offset: 0x0004DFD5
		' (set) Token: 0x0600AB48 RID: 43848 RVA: 0x0004FDDF File Offset: 0x0004DFDF
		Friend Overridable Property txtCESSPer As TextBox

		' Token: 0x1700427B RID: 17019
		' (get) Token: 0x0600AB49 RID: 43849 RVA: 0x0004FDE8 File Offset: 0x0004DFE8
		' (set) Token: 0x0600AB4A RID: 43850 RVA: 0x0004FDF2 File Offset: 0x0004DFF2
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x1700427C RID: 17020
		' (get) Token: 0x0600AB4B RID: 43851 RVA: 0x0004FDFB File Offset: 0x0004DFFB
		' (set) Token: 0x0600AB4C RID: 43852 RVA: 0x0004FE05 File Offset: 0x0004E005
		Friend Overridable Property Label6 As Label

		' Token: 0x1700427D RID: 17021
		' (get) Token: 0x0600AB4D RID: 43853 RVA: 0x0004FE0E File Offset: 0x0004E00E
		' (set) Token: 0x0600AB4E RID: 43854 RVA: 0x0004FE18 File Offset: 0x0004E018
		Friend Overridable Property Label45 As Label

		' Token: 0x1700427E RID: 17022
		' (get) Token: 0x0600AB4F RID: 43855 RVA: 0x0004FE21 File Offset: 0x0004E021
		' (set) Token: 0x0600AB50 RID: 43856 RVA: 0x0004FE2B File Offset: 0x0004E02B
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x1700427F RID: 17023
		' (get) Token: 0x0600AB51 RID: 43857 RVA: 0x0004FE34 File Offset: 0x0004E034
		' (set) Token: 0x0600AB52 RID: 43858 RVA: 0x0004FE3E File Offset: 0x0004E03E
		Friend Overridable Property Label46 As Label

		' Token: 0x17004280 RID: 17024
		' (get) Token: 0x0600AB53 RID: 43859 RVA: 0x0004FE47 File Offset: 0x0004E047
		' (set) Token: 0x0600AB54 RID: 43860 RVA: 0x0004FE51 File Offset: 0x0004E051
		Friend Overridable Property lblUnit As Label

		' Token: 0x17004281 RID: 17025
		' (get) Token: 0x0600AB55 RID: 43861 RVA: 0x0004FE5A File Offset: 0x0004E05A
		' (set) Token: 0x0600AB56 RID: 43862 RVA: 0x0004FE64 File Offset: 0x0004E064
		Friend Overridable Property Label21 As Label

		' Token: 0x17004282 RID: 17026
		' (get) Token: 0x0600AB57 RID: 43863 RVA: 0x0004FE6D File Offset: 0x0004E06D
		' (set) Token: 0x0600AB58 RID: 43864 RVA: 0x0004FE77 File Offset: 0x0004E077
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17004283 RID: 17027
		' (get) Token: 0x0600AB59 RID: 43865 RVA: 0x0004FE80 File Offset: 0x0004E080
		' (set) Token: 0x0600AB5A RID: 43866 RVA: 0x0004FE8A File Offset: 0x0004E08A
		Friend Overridable Property Label33 As Label

		' Token: 0x17004284 RID: 17028
		' (get) Token: 0x0600AB5B RID: 43867 RVA: 0x0004FE93 File Offset: 0x0004E093
		' (set) Token: 0x0600AB5C RID: 43868 RVA: 0x0004FE9D File Offset: 0x0004E09D
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x17004285 RID: 17029
		' (get) Token: 0x0600AB5D RID: 43869 RVA: 0x0004FEA6 File Offset: 0x0004E0A6
		' (set) Token: 0x0600AB5E RID: 43870 RVA: 0x0004FEB0 File Offset: 0x0004E0B0
		Friend Overridable Property txtSGSTPer As TextBox

		' Token: 0x17004286 RID: 17030
		' (get) Token: 0x0600AB5F RID: 43871 RVA: 0x0004FEB9 File Offset: 0x0004E0B9
		' (set) Token: 0x0600AB60 RID: 43872 RVA: 0x00723A20 File Offset: 0x00721C20
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtQty_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtQty_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtQty_Leave
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004287 RID: 17031
		' (get) Token: 0x0600AB61 RID: 43873 RVA: 0x0004FEC3 File Offset: 0x0004E0C3
		' (set) Token: 0x0600AB62 RID: 43874 RVA: 0x0004FECD File Offset: 0x0004E0CD
		Friend Overridable Property txtCGSTPer As TextBox

		' Token: 0x17004288 RID: 17032
		' (get) Token: 0x0600AB63 RID: 43875 RVA: 0x0004FED6 File Offset: 0x0004E0D6
		' (set) Token: 0x0600AB64 RID: 43876 RVA: 0x0004FEE0 File Offset: 0x0004E0E0
		Friend Overridable Property Label25 As Label

		' Token: 0x17004289 RID: 17033
		' (get) Token: 0x0600AB65 RID: 43877 RVA: 0x0004FEE9 File Offset: 0x0004E0E9
		' (set) Token: 0x0600AB66 RID: 43878 RVA: 0x0004FEF3 File Offset: 0x0004E0F3
		Friend Overridable Property Label22 As Label

		' Token: 0x1700428A RID: 17034
		' (get) Token: 0x0600AB67 RID: 43879 RVA: 0x0004FEFC File Offset: 0x0004E0FC
		' (set) Token: 0x0600AB68 RID: 43880 RVA: 0x00723AC0 File Offset: 0x00721CC0
		Private _btnProductSelection As Button
		Friend Overridable Property btnProductSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnProductSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductSelection_Click
				Dim button As Button = Me._btnProductSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnProductSelection = value
				button = Me._btnProductSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700428B RID: 17035
		' (get) Token: 0x0600AB69 RID: 43881 RVA: 0x0004FF06 File Offset: 0x0004E106
		' (set) Token: 0x0600AB6A RID: 43882 RVA: 0x0004FF10 File Offset: 0x0004E110
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x1700428C RID: 17036
		' (get) Token: 0x0600AB6B RID: 43883 RVA: 0x0004FF19 File Offset: 0x0004E119
		' (set) Token: 0x0600AB6C RID: 43884 RVA: 0x0004FF23 File Offset: 0x0004E123
		Friend Overridable Property Label12 As Label

		' Token: 0x1700428D RID: 17037
		' (get) Token: 0x0600AB6D RID: 43885 RVA: 0x0004FF2C File Offset: 0x0004E12C
		' (set) Token: 0x0600AB6E RID: 43886 RVA: 0x0004FF36 File Offset: 0x0004E136
		Friend Overridable Property Label14 As Label

		' Token: 0x1700428E RID: 17038
		' (get) Token: 0x0600AB6F RID: 43887 RVA: 0x0004FF3F File Offset: 0x0004E13F
		' (set) Token: 0x0600AB70 RID: 43888 RVA: 0x0004FF49 File Offset: 0x0004E149
		Friend Overridable Property Label10 As Label

		' Token: 0x1700428F RID: 17039
		' (get) Token: 0x0600AB71 RID: 43889 RVA: 0x0004FF52 File Offset: 0x0004E152
		' (set) Token: 0x0600AB72 RID: 43890 RVA: 0x00723B04 File Offset: 0x00721D04
		Private _CheckBox4 As CheckBox
		Friend Overridable Property CheckBox4 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox4_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox4
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox4 = value
				checkBox = Me._CheckBox4
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004290 RID: 17040
		' (get) Token: 0x0600AB73 RID: 43891 RVA: 0x0004FF5C File Offset: 0x0004E15C
		' (set) Token: 0x0600AB74 RID: 43892 RVA: 0x00723B48 File Offset: 0x00721D48
		Private _Button15 As GelButton
		Friend Overridable Property Button15 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button15_Click
				Dim gelButton As GelButton = Me._Button15
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button15 = value
				gelButton = Me._Button15
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004291 RID: 17041
		' (get) Token: 0x0600AB75 RID: 43893 RVA: 0x0004FF66 File Offset: 0x0004E166
		' (set) Token: 0x0600AB76 RID: 43894 RVA: 0x00723B8C File Offset: 0x00721D8C
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004292 RID: 17042
		' (get) Token: 0x0600AB77 RID: 43895 RVA: 0x0004FF70 File Offset: 0x0004E170
		' (set) Token: 0x0600AB78 RID: 43896 RVA: 0x00723BD0 File Offset: 0x00721DD0
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
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

		' Token: 0x17004293 RID: 17043
		' (get) Token: 0x0600AB79 RID: 43897 RVA: 0x0004FF7A File Offset: 0x0004E17A
		' (set) Token: 0x0600AB7A RID: 43898 RVA: 0x00723C14 File Offset: 0x00721E14
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

		' Token: 0x17004294 RID: 17044
		' (get) Token: 0x0600AB7B RID: 43899 RVA: 0x0004FF84 File Offset: 0x0004E184
		' (set) Token: 0x0600AB7C RID: 43900 RVA: 0x00723C58 File Offset: 0x00721E58
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

		' Token: 0x17004295 RID: 17045
		' (get) Token: 0x0600AB7D RID: 43901 RVA: 0x0004FF8E File Offset: 0x0004E18E
		' (set) Token: 0x0600AB7E RID: 43902 RVA: 0x00723C9C File Offset: 0x00721E9C
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

		' Token: 0x17004296 RID: 17046
		' (get) Token: 0x0600AB7F RID: 43903 RVA: 0x0004FF98 File Offset: 0x0004E198
		' (set) Token: 0x0600AB80 RID: 43904 RVA: 0x00723CE0 File Offset: 0x00721EE0
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

		' Token: 0x0600AB81 RID: 43905
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600AB82 RID: 43906
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600AB83 RID: 43907 RVA: 0x00723D24 File Offset: 0x00721F24
		Public Sub VirtualCompInfo()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8) from VCompany"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.V1 = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.V2 = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.V3 = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.V4 = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.V5 = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.V6 = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.V7 = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.V8 = ModCommonClasses.rdr.GetValue(7).ToString()
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

		' Token: 0x0600AB84 RID: 43908 RVA: 0x00723EC4 File Offset: 0x007220C4
		Public Sub Fillproducts()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(ProductName) from Product order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbProductName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbProductName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AB85 RID: 43909 RVA: 0x00723FC8 File Offset: 0x007221C8
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompanyState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
					Me.cmpnm = ModCommonClasses.rdr.GetValue(3).ToString()
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

		' Token: 0x0600AB86 RID: 43910 RVA: 0x0072415C File Offset: 0x0072235C
		Public Sub Reset()
			Me.Clear()
			Me.RadioButton1.TabStop = False
			Me.RadioButton2.TabStop = False
			Me.RadioButton1.Checked = True
			Me.RadioButton1.Enabled = True
			Me.RadioButton2.Enabled = True
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.txtCID.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.cmbCustomerName.SelectedIndex = -1
			Me.txtContactNo.Text = ""
			Me.txtGSTIN.Text = ""
			Me.txtCustomerState.Text = ""
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnRemove.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnPrint.Enabled = False
			Me.Button15.Enabled = False
			Me.txtContactNo.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.auto()
			Me.lblSet.Text = "Allowed"
			Me.DataGridView1.Rows.Clear()
			Me.GetCompanyState()
			Me.cmbTaxType.SelectedIndex = -1
			Me.btnCustomerSelection.Enabled = True
			Me.cmbTaxType.Enabled = False
			Me.txtCustomerID.Text = ""
			Me.txtSubTotal.Text = "0.00"
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtTotal.Text = "0.00"
			Me.txtRoundOff.Text = "0.00"
			Me.txtGrandTotal.Text = "0.00"
			Me.dtpQuotationDate.Focus()
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.txtDiscAmtPerQty.Enabled = False
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.cmbNP.SelectedIndex = -1
			Me.NumericUpDown1.Value = Conversions.ToDecimal("30")
			Me.customerdetailenable()
			Me.InvTempEstStatus()
		End Sub

		' Token: 0x0600AB87 RID: 43911 RVA: 0x00724474 File Offset: 0x00722674
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Return num
		End Function

		' Token: 0x0600AB88 RID: 43912 RVA: 0x0072456C File Offset: 0x0072276C
		Public Sub Compute()
			Me.GridCalc()
			Me.num1 = Conversion.Val(Me.txtSubTotal.Text)
			Me.num1 = Math.Round(Me.num1, 2)
			Me.txtTotal.Text = Conversions.ToString(Me.num1)
			Me.num2 = Math.Round(Me.num1, 0)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.num3 = Me.num2 - Me.num1
			Else
				Me.num3 = 0.0
			End If
			Me.num3 = Math.Round(Me.num3, 2)
			Me.txtRoundOff.Text = Conversions.ToString(Me.num3)
			Me.num4 = Conversion.Val(Me.txtTotal.Text) + Conversion.Val(Me.txtRoundOff.Text)
			Me.num4 = Math.Round(Me.num4, 2)
			Me.txtGrandTotal.Text = Conversions.ToString(Me.num4)
		End Sub

		' Token: 0x0600AB89 RID: 43913 RVA: 0x00724684 File Offset: 0x00722884
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(9).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(11).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(13).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(15).Value))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			num = Math.Round(num, 2)
			num2 = Math.Round(num2, 2)
			num3 = Math.Round(num3, 2)
			num4 = Math.Round(num4, 2)
			Me.txtCGST.Text = Conversions.ToString(num)
			Me.txtSGST.Text = Conversions.ToString(num2)
			Me.txtIGST.Text = Conversions.ToString(num3)
			Me.txtCESS.Text = Conversions.ToString(num4)
		End Sub

		' Token: 0x0600AB8A RID: 43914 RVA: 0x00724814 File Offset: 0x00722A14
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 Q_ID FROM Estimate where KP='P' order BY Q_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("Q_ID"))
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

		' Token: 0x0600AB8B RID: 43915 RVA: 0x00724980 File Offset: 0x00722B80
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c20),RTRIM(c21) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "ESTM"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "ESTM"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AB8C RID: 43916 RVA: 0x00724B58 File Offset: 0x00722D58
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrEstimate ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x0600AB8D RID: 43917 RVA: 0x00724CC4 File Offset: 0x00722EC4
		Public Sub auto()
			Try
				Me.txtQ_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtQuotationNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AB8E RID: 43918 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600AB8F RID: 43919 RVA: 0x0004FFA2 File Offset: 0x0004E1A2
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductRecord.lblSet.Text = "Estimate"
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
		End Sub

		' Token: 0x0600AB90 RID: 43920 RVA: 0x00724D74 File Offset: 0x00722F74
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update InvTempEst set c1=@d1 where ID=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteNonQuery()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600AB91 RID: 43921 RVA: 0x00724D74 File Offset: 0x00722F74
		Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs)
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update InvTempEst set c1=@d1 where ID=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteNonQuery()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600AB92 RID: 43922 RVA: 0x00724E20 File Offset: 0x00723020
		Public Sub InvTempEstStatus()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c1) from InvTempEst where ID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 1)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.ComboBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600AB93 RID: 43923 RVA: 0x00724F2C File Offset: 0x0072312C
		Public Sub Print()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.V8, "No", False) = 0
				If flag2 Then
					Try
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim rptEstimateA As rptEstimateA4 = New rptEstimateA4()
						Dim sqlCommand As SqlCommand = New SqlCommand()
						Dim sqlCommand2 As SqlCommand = New SqlCommand()
						Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
						Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
						Dim dataSet As DataSet = New DataSet()
						Dim dataSet2 As DataSet = New DataSet()
						Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlCommand.Connection = sqlConnection
						sqlCommand2.Connection = sqlConnection
						sqlCommand.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit,Product_Join.Photo FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID INNER JOIN Product_Join ON Estimate_Join.ProductID = Product_Join.ProductID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
						sqlCommand2.CommandText = "SELECT * from Company"
						sqlCommand.CommandType = CommandType.Text
						sqlCommand2.CommandType = CommandType.Text
						sqlDataAdapter.SelectCommand = sqlCommand
						sqlDataAdapter2.SelectCommand = sqlCommand2
						sqlDataAdapter.Fill(dataSet, "Quotation")
						sqlDataAdapter.Fill(dataSet, "Quotation_join")
						sqlDataAdapter.Fill(dataSet, "Customer")
						sqlDataAdapter.Fill(dataSet, "Product")
						sqlDataAdapter.Fill(dataSet, "Product_Join")
						sqlDataAdapter2.Fill(dataSet, "Company")
						rptEstimateA.SetDataSource(dataSet)
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
						ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						End If
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag5 Then
							ModCommonClasses.con.Close()
						End If
						rptEstimateA.SetParameterValue("P1", Me.a)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA
						MyProject.Forms.frmReport.ShowDialog()
						rptEstimateA.Close()
						rptEstimateA.Dispose()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
				Dim flag6 As Boolean = Operators.CompareString(Me.V8, "Yes", False) = 0
				If flag6 Then
					Try
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim rptEstimateA4V As rptEstimateA4V = New rptEstimateA4V()
						Dim sqlCommand3 As SqlCommand = New SqlCommand()
						Dim sqlCommand4 As SqlCommand = New SqlCommand()
						Dim sqlDataAdapter3 As SqlDataAdapter = New SqlDataAdapter()
						Dim sqlDataAdapter4 As SqlDataAdapter = New SqlDataAdapter()
						Dim dataSet3 As DataSet = New DataSet()
						Dim dataSet4 As DataSet = New DataSet()
						Dim sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
						sqlCommand3.Connection = sqlConnection2
						sqlCommand4.Connection = sqlConnection2
						sqlCommand3.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
						sqlCommand4.CommandText = "SELECT * from Company"
						sqlCommand3.CommandType = CommandType.Text
						sqlCommand4.CommandType = CommandType.Text
						sqlDataAdapter3.SelectCommand = sqlCommand3
						sqlDataAdapter4.SelectCommand = sqlCommand4
						sqlDataAdapter3.Fill(dataSet3, "Quotation")
						sqlDataAdapter3.Fill(dataSet3, "Quotation_join")
						sqlDataAdapter3.Fill(dataSet3, "Customer")
						sqlDataAdapter3.Fill(dataSet3, "Product")
						sqlDataAdapter4.Fill(dataSet3, "Company")
						rptEstimateA4V.SetDataSource(dataSet3)
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
						ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
						If flag7 Then
							Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						End If
						Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag8 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag9 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag9 Then
							ModCommonClasses.con.Close()
						End If
						rptEstimateA4V.SetParameterValue("P1", Me.a)
						rptEstimateA4V.SetParameterValue("P2", Me.V1)
						rptEstimateA4V.SetParameterValue("P3", Me.V2)
						rptEstimateA4V.SetParameterValue("P4", Me.V3)
						rptEstimateA4V.SetParameterValue("P5", Me.V4)
						rptEstimateA4V.SetParameterValue("P6", Me.V5)
						rptEstimateA4V.SetParameterValue("P7", Me.V6)
						rptEstimateA4V.SetParameterValue("P8", Me.V7)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA4V
						MyProject.Forms.frmReport.ShowDialog()
						rptEstimateA4V.Close()
						rptEstimateA4V.Dispose()
					Catch ex2 As Exception
						MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			Else
				Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag10 Then
					Dim flag11 As Boolean = Operators.CompareString(Me.V8, "No", False) = 0
					If flag11 Then
						Try
							Me.Cursor = Cursors.WaitCursor
							Me.Timer1.Enabled = True
							Dim rptEstimateA2 As rptEstimateA5 = New rptEstimateA5()
							Dim sqlCommand5 As SqlCommand = New SqlCommand()
							Dim sqlCommand6 As SqlCommand = New SqlCommand()
							Dim sqlDataAdapter5 As SqlDataAdapter = New SqlDataAdapter()
							Dim sqlDataAdapter6 As SqlDataAdapter = New SqlDataAdapter()
							Dim dataSet5 As DataSet = New DataSet()
							Dim dataSet6 As DataSet = New DataSet()
							Dim sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlCommand5.Connection = sqlConnection3
							sqlCommand6.Connection = sqlConnection3
							sqlCommand5.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							sqlCommand6.CommandText = "SELECT * from Company"
							sqlCommand5.CommandType = CommandType.Text
							sqlCommand6.CommandType = CommandType.Text
							sqlDataAdapter5.SelectCommand = sqlCommand5
							sqlDataAdapter6.SelectCommand = sqlCommand6
							sqlDataAdapter5.Fill(dataSet5, "Quotation")
							sqlDataAdapter5.Fill(dataSet5, "Quotation_join")
							sqlDataAdapter5.Fill(dataSet5, "Customer")
							sqlDataAdapter5.Fill(dataSet5, "Product")
							sqlDataAdapter6.Fill(dataSet5, "Company")
							rptEstimateA2.SetDataSource(dataSet5)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
							ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
							If flag12 Then
								Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
							End If
							Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag13 Then
								ModCommonClasses.rdr.Close()
							End If
							Dim flag14 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
							If flag14 Then
								ModCommonClasses.con.Close()
							End If
							rptEstimateA2.SetParameterValue("P1", Me.a)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA2
							MyProject.Forms.frmReport.ShowDialog()
							rptEstimateA2.Close()
							rptEstimateA2.Dispose()
						Catch ex3 As Exception
							MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
					Dim flag15 As Boolean = Operators.CompareString(Me.V8, "Yes", False) = 0
					If flag15 Then
						Try
							Me.Cursor = Cursors.WaitCursor
							Me.Timer1.Enabled = True
							Dim rptEstimateA5A As rptEstimateA5A = New rptEstimateA5A()
							Dim sqlCommand7 As SqlCommand = New SqlCommand()
							Dim sqlCommand8 As SqlCommand = New SqlCommand()
							Dim sqlDataAdapter7 As SqlDataAdapter = New SqlDataAdapter()
							Dim sqlDataAdapter8 As SqlDataAdapter = New SqlDataAdapter()
							Dim dataSet7 As DataSet = New DataSet()
							Dim dataSet8 As DataSet = New DataSet()
							Dim sqlConnection4 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlCommand7.Connection = sqlConnection4
							sqlCommand8.Connection = sqlConnection4
							sqlCommand7.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							sqlCommand8.CommandText = "SELECT * from Company"
							sqlCommand7.CommandType = CommandType.Text
							sqlCommand8.CommandType = CommandType.Text
							sqlDataAdapter7.SelectCommand = sqlCommand7
							sqlDataAdapter8.SelectCommand = sqlCommand8
							sqlDataAdapter7.Fill(dataSet7, "Quotation")
							sqlDataAdapter7.Fill(dataSet7, "Quotation_join")
							sqlDataAdapter7.Fill(dataSet7, "Customer")
							sqlDataAdapter7.Fill(dataSet7, "Product")
							sqlDataAdapter8.Fill(dataSet7, "Company")
							rptEstimateA5A.SetDataSource(dataSet7)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
							ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
							If flag16 Then
								Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
							End If
							Dim flag17 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag17 Then
								ModCommonClasses.rdr.Close()
							End If
							Dim flag18 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
							If flag18 Then
								ModCommonClasses.con.Close()
							End If
							rptEstimateA5A.SetParameterValue("P1", Me.a)
							rptEstimateA5A.SetParameterValue("P2", Me.V1)
							rptEstimateA5A.SetParameterValue("P3", Me.V2)
							rptEstimateA5A.SetParameterValue("P4", Me.V3)
							rptEstimateA5A.SetParameterValue("P5", Me.V4)
							rptEstimateA5A.SetParameterValue("P6", Me.V5)
							rptEstimateA5A.SetParameterValue("P7", Me.V6)
							rptEstimateA5A.SetParameterValue("P8", Me.V7)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA5A
							MyProject.Forms.frmReport.ShowDialog()
							rptEstimateA5A.Close()
							rptEstimateA5A.Dispose()
						Catch ex4 As Exception
							MessageBox.Show(ex4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Else
					Dim flag19 As Boolean = Me.ComboBox1.SelectedIndex = 2
					If flag19 Then
						Dim flag20 As Boolean = Operators.CompareString(Me.V8, "No", False) = 0
						If flag20 Then
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer1.Enabled = True
								Dim rptEstimateA5Economical As rptEstimateA5Economical = New rptEstimateA5Economical()
								Dim sqlCommand9 As SqlCommand = New SqlCommand()
								Dim sqlCommand10 As SqlCommand = New SqlCommand()
								Dim sqlDataAdapter9 As SqlDataAdapter = New SqlDataAdapter()
								Dim sqlDataAdapter10 As SqlDataAdapter = New SqlDataAdapter()
								Dim dataSet9 As DataSet = New DataSet()
								Dim dataSet10 As DataSet = New DataSet()
								Dim sqlConnection5 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlCommand9.Connection = sqlConnection5
								sqlCommand10.Connection = sqlConnection5
								sqlCommand9.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
								sqlCommand10.CommandText = "SELECT * from Company"
								sqlCommand9.CommandType = CommandType.Text
								sqlCommand10.CommandType = CommandType.Text
								sqlDataAdapter9.SelectCommand = sqlCommand9
								sqlDataAdapter10.SelectCommand = sqlCommand10
								sqlDataAdapter9.Fill(dataSet9, "Quotation")
								sqlDataAdapter9.Fill(dataSet9, "Quotation_join")
								sqlDataAdapter9.Fill(dataSet9, "Customer")
								sqlDataAdapter9.Fill(dataSet9, "Product")
								sqlDataAdapter10.Fill(dataSet9, "Company")
								rptEstimateA5Economical.SetDataSource(dataSet9)
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
								ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag21 As Boolean = ModCommonClasses.rdr.Read()
								If flag21 Then
									Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
								End If
								Dim flag22 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag22 Then
									ModCommonClasses.rdr.Close()
								End If
								Dim flag23 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
								If flag23 Then
									ModCommonClasses.con.Close()
								End If
								rptEstimateA5Economical.SetParameterValue("P1", Me.a)
								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA5Economical
								MyProject.Forms.frmReport.ShowDialog()
								rptEstimateA5Economical.Close()
								rptEstimateA5Economical.Dispose()
							Catch ex5 As Exception
								MessageBox.Show(ex5.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
						Dim flag24 As Boolean = Operators.CompareString(Me.V8, "Yes", False) = 0
						If flag24 Then
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer1.Enabled = True
								Dim rptEstimateA5EconomicalV As rptEstimateA5EconomicalV = New rptEstimateA5EconomicalV()
								Dim sqlCommand11 As SqlCommand = New SqlCommand()
								Dim sqlCommand12 As SqlCommand = New SqlCommand()
								Dim sqlDataAdapter11 As SqlDataAdapter = New SqlDataAdapter()
								Dim sqlDataAdapter12 As SqlDataAdapter = New SqlDataAdapter()
								Dim dataSet11 As DataSet = New DataSet()
								Dim dataSet12 As DataSet = New DataSet()
								Dim sqlConnection6 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlCommand11.Connection = sqlConnection6
								sqlCommand12.Connection = sqlConnection6
								sqlCommand11.CommandText = If(("SELECT Estimate.Q_ID, Estimate.QuotationNo, Estimate.Date, Estimate.TaxType, Estimate.CustomerID, Estimate.SubTotal, Estimate.CGST, Estimate.SGST, Estimate.IGST, Estimate.CESS, Estimate.Total,Estimate.RoundOff, Estimate.GrandTotal, Estimate.Remarks, Estimate_Join.QJ_ID, Estimate_Join.QuotationID, Estimate_Join.ProductID, Estimate_Join.AltUnit as Barcode, Estimate_Join.Qty, Estimate_Join.AltQty as Price,Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, Customer.ID, Customer.CustomerID AS Expr1, Customer.Name, Customer.Address, Customer.City, Customer.State,Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode,Customer.GSTIN, Customer.PAN, Customer.CIN, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice, Product.SalesUnit FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID where Q_ID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
								sqlCommand12.CommandText = "SELECT * from Company"
								sqlCommand11.CommandType = CommandType.Text
								sqlCommand12.CommandType = CommandType.Text
								sqlDataAdapter11.SelectCommand = sqlCommand11
								sqlDataAdapter12.SelectCommand = sqlCommand12
								sqlDataAdapter11.Fill(dataSet11, "Quotation")
								sqlDataAdapter11.Fill(dataSet11, "Quotation_join")
								sqlDataAdapter11.Fill(dataSet11, "Customer")
								sqlDataAdapter11.Fill(dataSet11, "Product")
								sqlDataAdapter12.Fill(dataSet11, "Company")
								rptEstimateA5EconomicalV.SetDataSource(dataSet11)
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
								ModCommonClasses.cmd.CommandText = If(("SELECT Sum(Qty*Price) from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
								If flag25 Then
									Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
								End If
								Dim flag26 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag26 Then
									ModCommonClasses.rdr.Close()
								End If
								Dim flag27 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
								If flag27 Then
									ModCommonClasses.con.Close()
								End If
								rptEstimateA5EconomicalV.SetParameterValue("P1", Me.a)
								rptEstimateA5EconomicalV.SetParameterValue("P2", Me.V1)
								rptEstimateA5EconomicalV.SetParameterValue("P3", Me.V2)
								rptEstimateA5EconomicalV.SetParameterValue("P4", Me.V3)
								rptEstimateA5EconomicalV.SetParameterValue("P6", Me.V4)
								rptEstimateA5EconomicalV.SetParameterValue("P5", Me.V5)
								rptEstimateA5EconomicalV.SetParameterValue("P7", Me.V6)
								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEstimateA5EconomicalV
								MyProject.Forms.frmReport.ShowDialog()
								rptEstimateA5EconomicalV.Close()
								rptEstimateA5EconomicalV.Dispose()
							Catch ex6 As Exception
								MessageBox.Show(ex6.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600AB94 RID: 43924 RVA: 0x007260F4 File Offset: 0x007242F4
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.Clear()
					Me.cmbCustomerName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Me.cmbProductName.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox5.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.TextBox5.Text, Me.cmbProductName.Text, False) <> 0
							If flag4 Then
								MessageBox.Show("Please retrieve correct product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.TextBox5.Focus()
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Select RTRIM(Temp_Stock.Barcode),RTRIM(Product.ProductName) from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox6.Text.ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									Dim flag6 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(1).ToString(), Me.TextBox5.Text.ToString(), False) <> 0
									If flag6 Then
										MessageBox.Show("Product name is being missmatched with Barcode !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.Clear()
										Return
									End If
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
								ModCommonClasses.con.Close()
								Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtPricePerQty.Text)) = 0
								If flag8 Then
									MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPricePerQty.Focus()
								Else
									Dim flag9 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscPer.Text)) = 0
									If flag9 Then
										MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtDiscPer.Focus()
									Else
										Dim flag10 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
										If flag10 Then
											MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtQty.Focus()
										Else
											Dim flag11 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
											If flag11 Then
												MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtQty.Focus()
											Else
												Me.RadioButton1.Enabled = False
												Me.RadioButton2.Enabled = False
												Me.alt()
												Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
												Dim text3 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
												Dim flag12 As Boolean = Conversions.ToBoolean(text2) AndAlso Conversions.ToBoolean(text3)
												If flag12 Then
													MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.cmbUnit.Text = Me.TextBox4.Text
													Me.cmbUnit.Focus()
												Else
													Try
														For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
															Dim flag13 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareObjectEqual(dataGridViewRow.Cells(3).Value, Me.txtBarcode.Text, False)))
															If flag13 Then
																dataGridViewRow.Cells(0).Value = Me.txtProductID.Text
																dataGridViewRow.Cells(1).Value = Me.txtHSNCode.Text
																dataGridViewRow.Cells(2).Value = Me.cmbProductName.Text
																dataGridViewRow.Cells(3).Value = Me.txtBarcode.Text
																dataGridViewRow.Cells(4).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)) + Conversion.Val(Me.TextBox2.Text)
																dataGridViewRow.Cells(5).Value = Conversion.Val(Me.txtPricePerQty.Text)
																dataGridViewRow.Cells(6).Value = Conversion.Val(Me.txtDiscPer.Text)
																dataGridViewRow.Cells(7).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)) + Conversion.Val(Me.txtDisc.Text)
																dataGridViewRow.Cells(8).Value = Me.txtCGSTPer.Text
																dataGridViewRow.Cells(9).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(Me.txtCGSTAmt.Text)
																dataGridViewRow.Cells(10).Value = Me.txtSGSTPer.Text
																dataGridViewRow.Cells(11).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)) + Conversion.Val(Me.txtSGSTAmt.Text)
																dataGridViewRow.Cells(12).Value = Me.txtIGSTPer.Text
																dataGridViewRow.Cells(13).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)) + Conversion.Val(Me.txtIGSTAmt.Text)
																dataGridViewRow.Cells(14).Value = Me.txtCESSPer.Text
																dataGridViewRow.Cells(15).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)) + Conversion.Val(Me.txtCESSAmt.Text)
																dataGridViewRow.Cells(16).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)) + Conversion.Val(Me.txtTotalAmount.Text)
																dataGridViewRow.Cells(17).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)) * Conversion.Val(Me.lblAltValue.Text)
																dataGridViewRow.Cells(18).Value = Me.lblAltUnit.Text
																dataGridViewRow.Cells(19).Value = Me.cmbTaxType.Text
																Dim num As Double = Me.SubTotal()
																num = Conversions.ToDouble(Strings.Format(Math.Round(num, 2), "0.00"))
																Me.txtSubTotal.Text = Conversions.ToString(num)
																Me.Compute()
																Me.Clear()
																Return
															End If
														Next
													Finally
														Dim enumerator As IEnumerator
														If TypeOf enumerator Is IDisposable Then
															TryCast(enumerator, IDisposable).Dispose()
														End If
													End Try
													Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.cmbProductName.Text, Me.txtBarcode.Text, Conversion.Val(Me.TextBox2.Text), Conversion.Val(Me.txtPricePerQty.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtTotalAmount.Text), Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text), Me.lblAltUnit.Text, Me.cmbTaxType.Text })
													Dim num2 As Double = Me.SubTotal()
													num2 = Math.Round(num2, 2)
													Me.txtSubTotal.Text = Conversions.ToString(num2)
													Me.Compute()
													Me.Clear()
													Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
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
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600AB95 RID: 43925 RVA: 0x00726C30 File Offset: 0x00724E30
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.cmbProductName.Text = ""
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
			Me.txtQty.Text = Conversions.ToString(0)
			Me.txtPricePerQty.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtBarcode.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.btnListUpdate.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.cmbDiscountType.SelectedIndex = 0
			Me.txtDisc.Enabled = False
			Me.txtTotalAmount.Text = "0.00"
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.cmbTaxType.SelectedIndex = -1
			Me.cmbTaxType.Text = ""
		End Sub

		' Token: 0x0600AB96 RID: 43926 RVA: 0x00726EA4 File Offset: 0x007250A4
		Public Sub Calc()
			Dim flag As Boolean = Operators.CompareString(Me.cmbTaxType.Text, "Exclusive", False) = 0
			If flag Then
				Dim flag2 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag2 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag3 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag3 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.cmbTaxType.Text, "Inclusive", False) = 0
			If flag4 Then
				Dim flag5 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag5 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag6 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag6 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2 / 2.0, 2), "0.00")
				Me.num3 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3 / 2.0, 2), "0.00")
				Me.num4 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtIGSTPer.Text) / 100.0))
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtCESSPer.Text) / 100.0))
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag7 As Boolean = Operators.CompareString(Me.cmbTaxType.Text, "Exempt GST", False) = 0
			If flag7 Then
				Dim flag8 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag8 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag9 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag9 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.txtCGSTPer.Text = "0.00"
				Me.txtSGSTPer.Text = "0.00"
				Me.txtIGSTPer.Text = "0.00"
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag10 As Boolean = Operators.CompareString(Me.cmbTaxType.Text, "No Taxes", False) = 0
			If flag10 Then
				Dim flag11 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag11 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag12 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag12 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.txtCGSTPer.Text = "0.00"
				Me.txtSGSTPer.Text = "0.00"
				Me.txtIGSTPer.Text = "0.00"
				Me.txtCESSPer.Text = "0.00"
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
		End Sub

		' Token: 0x0600AB97 RID: 43927 RVA: 0x00727E88 File Offset: 0x00726088
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Try
					For Each obj As Object In Me.DataGridView1.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.DataGridView1.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim num As Double = Me.SubTotal()
				num = Math.Round(num, 2)
				Me.txtSubTotal.Text = Conversions.ToString(num)
				Me.Compute()
				Me.Clear()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag As Boolean = Me.DataGridView1.RowCount = 0
			If flag Then
				Me.customerdetailenable()
			End If
		End Sub

		' Token: 0x0600AB98 RID: 43928 RVA: 0x00727F90 File Offset: 0x00726190
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Estimate where Q_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = If(("delete from Estimate_Join where QuotationID=" + Me.txtQ_ID.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					ModFunc.SrEstimateDelete(Me.txtQuotationNo.Text)
					Dim text3 As String = "deleted the invoice no. '" + Me.txtQuotationNo.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text3)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillEstimateID()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillEstimateID()
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x0600AB99 RID: 43929 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x0600AB9A RID: 43930 RVA: 0x00728184 File Offset: 0x00726384
		Public Sub auto1()
			Try
				Me.txtCID.Text = Me.GenerateID1()
				Me.txtCustomerID.Text = "C-" + Me.GenerateID1()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AB9B RID: 43931 RVA: 0x0004FFDF File Offset: 0x0004E1DF
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600AB9C RID: 43932 RVA: 0x0004FFFB File Offset: 0x0004E1FB
		Private Sub btnListReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x0600AB9D RID: 43933 RVA: 0x007281F8 File Offset: 0x007263F8
		Private Sub frmEstimate_Load(sender As Object, e As EventArgs)
			Me.RadioButton1.TabStop = False
			Me.RadioButton2.TabStop = False
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.GetCompanyState()
			Me.UserControlSettings()
			Me.ReadWeightPORT()
			Me.DataforNP()
			Me.Invoicecode()
			Me.auto()
			Me.fillUnit()
			Me.Autoroundoff()
			Me.Fillproducts()
			Me.FillCustomers()
			Me.cmbUnit.DropDownHeight = 100
			Me.cmbUnit.DropDownWidth = 200
			Me.VirtualCompInfo()
			Me.fillEstimateID()
			Me.CheckBox4.TabStop = False
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Dim timer As Timer = New Timer()
			timer.Interval = 1000
			AddHandler timer.Tick, AddressOf Me.Timer3_Tick
			timer.Start()
			frmEstimate.DoubleBuffered(Me.dgw4, True)
			Me.PDBoardAll6()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600AB9E RID: 43934 RVA: 0x00728364 File Offset: 0x00726564
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

		' Token: 0x0600AB9F RID: 43935 RVA: 0x00728604 File Offset: 0x00726804
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x0600ABA0 RID: 43936 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ABA1 RID: 43937 RVA: 0x007286D0 File Offset: 0x007268D0
		Private Sub btnListUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Me.cmbProductName.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox5.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.TextBox5.Text, Me.cmbProductName.Text, False) <> 0
							If flag4 Then
								MessageBox.Show("Please retrieve correct product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.TextBox5.Focus()
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Select RTRIM(Temp_Stock.Barcode),RTRIM(Product.ProductName) from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox6.Text.ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									Dim flag6 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(1).ToString(), Me.TextBox5.Text.ToString(), False) <> 0
									If flag6 Then
										MessageBox.Show("Product name is being missmatched with Barcode !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.Clear()
										Return
									End If
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
								ModCommonClasses.con.Close()
								Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtPricePerQty.Text)) = 0
								If flag8 Then
									MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPricePerQty.Focus()
								Else
									Dim flag9 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscPer.Text)) = 0
									If flag9 Then
										MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtDiscPer.Focus()
									Else
										Dim flag10 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
										If flag10 Then
											MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtQty.Focus()
										Else
											Dim flag11 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
											If flag11 Then
												MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtQty.Focus()
											Else
												Me.alt()
												Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
												Dim text3 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
												Dim flag12 As Boolean = Conversions.ToBoolean(text2) AndAlso Conversions.ToBoolean(text3)
												If flag12 Then
													MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.cmbUnit.Text = Me.TextBox4.Text
													Me.cmbUnit.Focus()
												Else
													Dim index As Integer = Me.DataGridView1.CurrentRow.Index
													Me.DataGridView1(0, index).Value = Me.txtProductID.Text
													Me.DataGridView1(1, index).Value = Me.txtHSNCode.Text
													Me.DataGridView1(2, index).Value = Me.cmbProductName.Text
													Me.DataGridView1(3, index).Value = Me.txtBarcode.Text
													Me.DataGridView1(4, index).Value = Conversion.Val(Me.TextBox2.Text)
													Me.DataGridView1(5, index).Value = Conversion.Val(Me.txtPricePerQty.Text)
													Me.DataGridView1(6, index).Value = Conversion.Val(Me.txtDiscPer.Text)
													Me.DataGridView1(7, index).Value = Conversion.Val(Me.txtDisc.Text)
													Me.DataGridView1(8, index).Value = Conversion.Val(Me.txtCGSTPer.Text)
													Me.DataGridView1(9, index).Value = Conversion.Val(Me.txtCGSTAmt.Text)
													Me.DataGridView1(10, index).Value = Conversion.Val(Me.txtSGSTPer.Text)
													Me.DataGridView1(11, index).Value = Conversion.Val(Me.txtSGSTAmt.Text)
													Me.DataGridView1(12, index).Value = Conversion.Val(Me.txtIGSTPer.Text)
													Me.DataGridView1(13, index).Value = Conversion.Val(Me.txtIGSTAmt.Text)
													Me.DataGridView1(14, index).Value = Conversion.Val(Me.txtCESSPer.Text)
													Me.DataGridView1(15, index).Value = Conversion.Val(Me.txtCESSAmt.Text)
													Me.DataGridView1(16, index).Value = Conversion.Val(Me.txtTotalAmount.Text)
													Me.DataGridView1(17, index).Value = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text)
													Me.DataGridView1(18, index).Value = Me.lblAltUnit.Text
													Me.DataGridView1(19, index).Value = Me.cmbTaxType.Text
													Dim num As Double = Me.SubTotal()
													num = Math.Round(num, 2)
													Me.txtSubTotal.Text = Conversions.ToString(num)
													Me.Compute()
													Me.Clear()
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
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600ABA2 RID: 43938 RVA: 0x00728E24 File Offset: 0x00727024
		Private Sub btnSelect_Click_1(sender As Object, e As EventArgs)
			Me.TextBox5.Focus()
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Estimate"
			MyProject.Forms.frmCustomerRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = True
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x0600ABA3 RID: 43939 RVA: 0x00728EC0 File Offset: 0x007270C0
		Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtQty.Text
					Dim selectionStart As Integer = Me.txtQty.SelectionStart
					Dim selectionLength As Integer = Me.txtQty.SelectionLength
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

		' Token: 0x0600ABA4 RID: 43940 RVA: 0x00728FB8 File Offset: 0x007271B8
		Private Sub txtPricePerQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtPricePerQty.Text
					Dim selectionStart As Integer = Me.txtPricePerQty.SelectionStart
					Dim selectionLength As Integer = Me.txtPricePerQty.SelectionLength
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

		' Token: 0x0600ABA5 RID: 43941 RVA: 0x007290B0 File Offset: 0x007272B0
		Private Sub txtDiscPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscPer.Text
					Dim selectionStart As Integer = Me.txtDiscPer.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscPer.SelectionLength
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

		' Token: 0x0600ABA6 RID: 43942 RVA: 0x00050011 File Offset: 0x0004E211
		Private Sub txtPricePerQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600ABA7 RID: 43943 RVA: 0x0005001B File Offset: 0x0004E21B
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x0600ABA8 RID: 43944 RVA: 0x00050025 File Offset: 0x0004E225
		Private Sub txtQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600ABA9 RID: 43945 RVA: 0x00050011 File Offset: 0x0004E211
		Private Sub txtDiscPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600ABAA RID: 43946 RVA: 0x007291A8 File Offset: 0x007273A8
		Private Sub btnProductSelection_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.Clear()
					Me.cmbCustomerName.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						Me.txtQty.Focus()
						MyProject.Forms.frmProductRecord.lblSet.Text = "Estimate"
						MyProject.Forms.frmProductRecord.Reset()
						MyProject.Forms.frmProductRecord.ShowDialog()
						MyProject.Forms.frmProductRecord.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABAB RID: 43947 RVA: 0x00729334 File Offset: 0x00727534
		Public Sub Autoroundoff()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(c1) from Autoroundoff"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					Me.TextBox1.Text = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "Yes", False) = 0
				If flag4 Then
					Me.CheckBox1.Checked = True
				Else
					Me.CheckBox1.Checked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABAC RID: 43948 RVA: 0x0005003D File Offset: 0x0004E23D
		Private Sub cmbTaxType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.Compute()
			Me.cmbTaxType.Enabled = False
		End Sub

		' Token: 0x0600ABAD RID: 43949 RVA: 0x00729478 File Offset: 0x00727678
		Public Sub currentstock()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Temp_Stock.Qty) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and ProductName=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox7.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABAE RID: 43950 RVA: 0x00729568 File Offset: 0x00727768
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Me.btnRemove.Enabled = True
					Me.btnListUpdate.Enabled = True
					Me.btnAdd.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtProductID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.cmbTaxType.Text = Conversions.ToString(dataGridViewRow.Cells(19).Value)
					Me.txtHSNCode.Text = Conversions.ToString(dataGridViewRow.Cells(1).Value)
					Me.cmbProductName.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.TextBox5.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.txtBarcode.Text = Conversions.ToString(dataGridViewRow.Cells(3).Value)
					Me.TextBox6.Text = Conversions.ToString(dataGridViewRow.Cells(3).Value)
					Me.txtQty.Text = Conversions.ToString(dataGridViewRow.Cells(4).Value)
					Me.txtPricePerQty.Text = Conversions.ToString(dataGridViewRow.Cells(5).Value)
					Me.txtDiscPer.Text = Conversions.ToString(dataGridViewRow.Cells(6).Value)
					Me.txtDisc.Text = Conversions.ToString(dataGridViewRow.Cells(7).Value)
					Me.txtCGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(8).Value)
					Me.txtCGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(9).Value)
					Me.txtSGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(10).Value)
					Me.txtSGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(11).Value)
					Me.txtIGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(12).Value)
					Me.txtIGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(13).Value)
					Me.txtCESSPer.Text = Conversions.ToString(dataGridViewRow.Cells(14).Value)
					Me.txtCESSAmt.Text = Conversions.ToString(dataGridViewRow.Cells(15).Value)
					Me.txtTotalAmount.Text = Conversions.ToString(dataGridViewRow.Cells(16).Value)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = If(("SELECT RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
					Me.currentstock()
					Me.conv()
					Me.alt()
					Me.dgw4.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABAF RID: 43951 RVA: 0x007299BC File Offset: 0x00727BBC
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

		' Token: 0x0600ABB0 RID: 43952 RVA: 0x00729AA4 File Offset: 0x00727CA4
		Private Sub cmbDiscountType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbDiscountType.SelectedIndex = 0
			If flag Then
				Me.txtDiscAmtPerQty.Enabled = False
				Me.txtDiscPer.Enabled = True
			Else
				Dim flag2 As Boolean = Me.cmbDiscountType.SelectedIndex = 1
				If flag2 Then
					Me.txtDiscPer.Enabled = False
					Me.txtDiscAmtPerQty.Enabled = True
				End If
			End If
			Me.Calc()
		End Sub

		' Token: 0x0600ABB1 RID: 43953 RVA: 0x00729B18 File Offset: 0x00727D18
		Private Sub txtDisc_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDisc.Text
					Dim selectionStart As Integer = Me.txtDisc.SelectionStart
					Dim selectionLength As Integer = Me.txtDisc.SelectionLength
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

		' Token: 0x0600ABB2 RID: 43954 RVA: 0x00050011 File Offset: 0x0004E211
		Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600ABB3 RID: 43955 RVA: 0x00729C10 File Offset: 0x00727E10
		Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs)
			Me.alt1()
			Dim flag As Boolean = Operators.CompareString(Me.cmbCustomerName.Text, "Cash", False) <> 0
			If flag Then
				Me.CustomerLastItemAmount()
			End If
			Me.ProductLastAmount()
			Me.ProductImageRetrieve()
			Me.UnitInfo()
		End Sub

		' Token: 0x0600ABB4 RID: 43956 RVA: 0x00729C60 File Offset: 0x00727E60
		Private Sub dtpQuotationDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpQuotationDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpQuotationDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpQuotationDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpQuotationDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600ABB5 RID: 43957 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpQuotationDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABB6 RID: 43958 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABB7 RID: 43959 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPricePerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABB8 RID: 43960 RVA: 0x0005005B File Offset: 0x0004E25B
		Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600ABB9 RID: 43961 RVA: 0x0005006C File Offset: 0x0004E26C
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x0600ABBA RID: 43962 RVA: 0x0005006C File Offset: 0x0004E26C
		Private Sub cmbaltunit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x0600ABBB RID: 43963 RVA: 0x0005005B File Offset: 0x0004E25B
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600ABBC RID: 43964 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABBD RID: 43965 RVA: 0x00050076 File Offset: 0x0004E276
		Private Sub txtDiscAmtPerQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
		End Sub

		' Token: 0x0600ABBE RID: 43966 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABBF RID: 43967 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDisc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABC0 RID: 43968 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABC1 RID: 43969 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABC2 RID: 43970 RVA: 0x00729D0C File Offset: 0x00727F0C
		Public Sub fillUnit()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbUnit.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbUnit.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600ABC3 RID: 43971 RVA: 0x00729E40 File Offset: 0x00728040
		Public Sub alt1()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmbaltunit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.TextBox3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
					Me.lblAltUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.lblAltValue.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABC4 RID: 43972 RVA: 0x00729FD0 File Offset: 0x007281D0
		Public Sub alt()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmbaltunit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABC5 RID: 43973 RVA: 0x0072A0C0 File Offset: 0x007282C0
		Private Sub cmbUnit_Validated(sender As Object, e As EventArgs)
			Me.alt()
			Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
			Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
			Dim flag As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
			If flag Then
				MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbUnit.Text = Me.TextBox4.Text
				Me.cmbUnit.Focus()
			End If
		End Sub

		' Token: 0x0600ABC6 RID: 43974 RVA: 0x0072A170 File Offset: 0x00728370
		Private Sub conv()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABC7 RID: 43975 RVA: 0x0072A260 File Offset: 0x00728460
		Private Sub altunitcal()
			Dim flag As Boolean = Operators.CompareString(Me.cmbUnit.Text, Me.cmbaltunit.Text, False) = 0
			If flag Then
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text) / Conversion.Val(Me.TextBox3.Text))
			Else
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text))
			End If
		End Sub

		' Token: 0x0600ABC8 RID: 43976 RVA: 0x0072A2EC File Offset: 0x007284EC
		Private Sub calc100()
			Me.txtDisc.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtDiscAmtPerQty.Text) * Conversion.Val(Me.txtQty.Text), 2), "0.00")
		End Sub

		' Token: 0x0600ABC9 RID: 43977 RVA: 0x0072A33C File Offset: 0x0072853C
		Private Sub txtDiscAmtPerQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscAmtPerQty.Text
					Dim selectionStart As Integer = Me.txtDiscAmtPerQty.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscAmtPerQty.SelectionLength
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

		' Token: 0x0600ABCA RID: 43978 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscAmtPerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABCB RID: 43979 RVA: 0x0072A434 File Offset: 0x00728634
		Public Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.CheckBox4.Checked
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(CostPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.STax) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
				End If
				Dim checked As Boolean = Me.CheckBox4.Checked
				If checked Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(CostPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.STax) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and PartNo like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABCC RID: 43980 RVA: 0x00050080 File Offset: 0x0004E280
		Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
		End Sub

		' Token: 0x0600ABCD RID: 43981 RVA: 0x0072A738 File Offset: 0x00728938
		Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCID.Text = ""
				Me.txtCustomerID.Text = ""
				Me.txtCustomerState.Text = ""
				Me.txtContactNo.Text = ""
				Me.txtGSTIN.Text = ""
				Me.txtContactNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN) from Customer where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						Me.txtCustomerState.Text = Me.txtCompanyState.Text
					Else
						Me.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					End If
				End If
				Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag3 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABCE RID: 43982 RVA: 0x0072A970 File Offset: 0x00728B70
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox5.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getgriditemdata()
					Me.dgw4.Visible = True
					Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
					If flag3 Then
						Me.dgw4.Focus()
						Me.RetrieveData1()
					Else
						Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
						If flag4 Then
							Me.dgw4.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					e.SuppressKeyPress = True
				End If
			End If
		End Sub

		' Token: 0x0600ABCF RID: 43983 RVA: 0x0072AA3C File Offset: 0x00728C3C
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox5.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x0600ABD0 RID: 43984 RVA: 0x0072AA8C File Offset: 0x00728C8C
		Private Sub TextBox5_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x0600ABD1 RID: 43985 RVA: 0x0072AAD4 File Offset: 0x00728CD4
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
					Me.TextBox5.Focus()
					Me.TextBox5.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox5.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.TextBox5.Text = Me.TextBox5.Text.Remove(Me.TextBox5.Text.Length - 1, 1)
						Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
						Me.TextBox5.Focus()
						Me.TextBox5.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "a"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "b"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "c"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "d"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "e"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "f"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "g"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "h"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "i"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "j"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "k"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "l"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "m"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "n"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "o"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "p"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "q"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "r"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "s"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "t"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "u"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "v"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "w"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "x"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "y"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "z"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "0"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "1"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "2"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "3"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "4"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "5"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "6"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "7"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "8"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "9"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "+"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "-"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "\"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + ","
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
		End Sub

		' Token: 0x0600ABD2 RID: 43986 RVA: 0x000500AD File Offset: 0x0004E2AD
		Private Sub txtQty_Leave(sender As Object, e As EventArgs)
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x0600ABD3 RID: 43987 RVA: 0x0072C51C File Offset: 0x0072A71C
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x0600ABD4 RID: 43988 RVA: 0x0072C544 File Offset: 0x0072A744
		Public Sub RetrieveData1()
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
				Else
					Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbTaxType.Text = dataGridViewRow.Cells(22).Value.ToString()
					Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.TextBox5.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.TextBox6.Text = dataGridViewRow.Cells(5).Value.ToString()
					Dim checked As Boolean = Me.RadioButton1.Checked
					If checked Then
						Me.txtPricePerQty.Text = dataGridViewRow.Cells(7).Value.ToString()
					Else
						Dim checked2 As Boolean = Me.RadioButton2.Checked
						If checked2 Then
							Me.txtPricePerQty.Text = dataGridViewRow.Cells(14).Value.ToString()
						End If
					End If
					Dim flag3 As Boolean = (Conversion.Val(Me.txtQty.Text) = 0.0) Or (Operators.CompareString(Me.txtQty.Text, "", False) = 0)
					If flag3 Then
						Me.txtQty.Text = Conversions.ToString(1)
					End If
					Me.txtDiscPer.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.TextBox7.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.TextBox4.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.cmbaltunit.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.lblAltUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.TextBox3.Text = dataGridViewRow.Cells(19).Value.ToString()
					Me.lblAltValue.Text = dataGridViewRow.Cells(19).Value.ToString()
					Dim flag4 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) = 0)
					If flag4 Then
						Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
						Me.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag5 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) = 0)
						If flag5 Then
							Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag6 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) <> 0)
							If flag6 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							Else
								Dim flag7 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) <> 0)
								If flag7 Then
									Me.txtCGSTPer.Text = Conversions.ToString(0)
									Me.txtSGSTPer.Text = Conversions.ToString(0)
									Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
								End If
							End If
						End If
					End If
					Me.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.Calc()
					Dim checked3 As Boolean = Me.cboxSpeed.Checked
					If checked3 Then
						Me.btnAdd.PerformClick()
						Me.TextBox6.Text = ""
						Me.TextBox6.Focus()
					Else
						Dim checked4 As Boolean = Me.CheckBox2.Checked
						If checked4 Then
							Me.btnAdd.PerformClick()
							Me.TextBox5.Text = ""
							Me.TextBox5.Focus()
						Else
							Dim flag8 As Boolean = (Conversion.Val(Me.txtQty.Text) = 0.0) Or (Operators.CompareString(Me.txtQty.Text, "", False) = 0)
							If flag8 Then
								Me.txtQty.Text = Conversions.ToString(1)
							End If
							Me.txtQty.Focus()
						End If
					End If
					Me.dgw4.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABD5 RID: 43989 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw4_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x0600ABD6 RID: 43990 RVA: 0x000500BD File Offset: 0x0004E2BD
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x0600ABD7 RID: 43991 RVA: 0x0072CCB0 File Offset: 0x0072AEB0
		Public Sub FillCustomers()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Name) from Customer order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbCustomerName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbCustomerName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABD8 RID: 43992 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbCustomerName_Validated(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600ABD9 RID: 43993 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ABDA RID: 43994 RVA: 0x0072CDC0 File Offset: 0x0072AFC0
		Public Sub fillEstimateID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Q_ID) FROM Estimate order by Q_ID ASC", ModCommonClasses.con)
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

		' Token: 0x0600ABDB RID: 43995 RVA: 0x0072CEFC File Offset: 0x0072B0FC
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(Estimate.Remarks) from Customer,Estimate where Customer.ID=Estimate.CustomerID and Estimate.KP='P' and Estimate.Q_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtQ_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtQuotationNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpQuotationDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtCID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbCustomerName.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						Me.txtCustomerState.Text = Me.txtCompanyState.Text
					Else
						Me.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					End If
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtTotal.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtRoundOff.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnPrint.Enabled = True
					Me.Button15.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnCustomerSelection.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Estimate_Join.Barcode),Estimate_Join.Qty, Estimate_Join.Price,Estimate_Join.DiscountPer,Estimate_Join.DiscountAmt,Estimate_Join. CGSTPer, Estimate_Join.CGSTAmt,Estimate_Join. SGSTPer,Estimate_Join. SGSTAmt,Estimate_Join. IGSTPer,Estimate_Join. IGSTAmt,Estimate_Join. CESSPer,Estimate_Join. CESSAmt,Estimate_Join.TotalAmount,Estimate_Join.AltQty,RTRIM(Estimate_Join.AltUnit),RTRIM(Estimate_Join.STaxType) from Estimate,Estimate_Join,Product where Estimate.Q_ID=Estimate_Join.QuotationID and Product.PID=Estimate_Join.ProductID and Estimate.Q_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
					End While
				End If
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
				Me.Calc()
				Me.Compute()
				Me.CTypeStatus()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABDC RID: 43996 RVA: 0x000500C7 File Offset: 0x0004E2C7
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x0600ABDD RID: 43997 RVA: 0x0072D464 File Offset: 0x0072B664
		Private Sub cboxSpeed_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Me.cboxSpeed.Checked = False
			End If
		End Sub

		' Token: 0x0600ABDE RID: 43998 RVA: 0x0072D464 File Offset: 0x0072B664
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Me.cboxSpeed.Checked = False
			End If
		End Sub

		' Token: 0x0600ABDF RID: 43999 RVA: 0x0072D490 File Offset: 0x0072B690
		Private Sub btnScanItems_Click(sender As Object, e As EventArgs)
			Me.txtHSNCode.Text = ""
			Me.cmbProductName.Text = ""
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
			Me.txtPricePerQty.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtBarcode.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.btnListUpdate.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.cmbDiscountType.SelectedIndex = 0
			Me.txtDisc.Enabled = False
			Me.txtTotalAmount.Text = "0.00"
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox6.Focus()
			Me.TextBox6.Text = ""
		End Sub

		' Token: 0x0600ABE0 RID: 44000 RVA: 0x000500DF File Offset: 0x0004E2DF
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Me.RetrieveData1()
			Me.Clear()
		End Sub

		' Token: 0x0600ABE1 RID: 44001 RVA: 0x000500DF File Offset: 0x0004E2DF
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Me.RetrieveData1()
			Me.Clear()
		End Sub

		' Token: 0x0600ABE2 RID: 44002 RVA: 0x0072D6F4 File Offset: 0x0072B8F4
		Private Sub Button22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomer.Label16.Text = "Estimate"
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.ShowDialog()
			MyProject.Forms.frmCustomer.Dispose()
		End Sub

		' Token: 0x0600ABE3 RID: 44003 RVA: 0x0072D77C File Offset: 0x0072B97C
		Private Sub Button11_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			Me.OpenCashdrawer()
			Dim text As String = "Cash Drawer Opened without Sales Transaction by Terminal ID : '" + Dns.GetHostName() + "'"
			ModFunc.LogFunc(Me.lblUser.Text, text)
		End Sub

		' Token: 0x0600ABE4 RID: 44004 RVA: 0x0072D7E0 File Offset: 0x0072B9E0
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProduct.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmProduct.lblCondn.Text = "Estimate_Add"
			MyProject.Forms.frmProduct.Reset()
			MyProject.Forms.frmProduct.ShowDialog()
			MyProject.Forms.frmProduct.Dispose()
		End Sub

		' Token: 0x0600ABE5 RID: 44005 RVA: 0x0072D878 File Offset: 0x0072BA78
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Estimate", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Estimate")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Estimate").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600ABE6 RID: 44006 RVA: 0x0072D954 File Offset: 0x0072BB54
		Private Sub Button8_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.frmTerminalSetting.Reset()
			MyProject.Forms.frmTerminalSetting.ShowDialog()
		End Sub

		' Token: 0x0600ABE7 RID: 44007 RVA: 0x0072D9AC File Offset: 0x0072BBAC
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.FrmValidate.Button1.Visible = False
			MyProject.Forms.FrmValidate.ShowDialog()
		End Sub

		' Token: 0x0600ABE8 RID: 44008 RVA: 0x0072DA08 File Offset: 0x0072BC08
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmEstimate.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmEstimate.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x0600ABE9 RID: 44009 RVA: 0x000500F0 File Offset: 0x0004E2F0
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			Interaction.Shell("C:\WINDOWS\system32\calc", AppWinStyle.MinimizedFocus, False, -1)
		End Sub

		' Token: 0x0600ABEA RID: 44010 RVA: 0x00050128 File Offset: 0x0004E328
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.GSTCalculator.ShowDialog()
		End Sub

		' Token: 0x0600ABEB RID: 44011 RVA: 0x00050162 File Offset: 0x0004E362
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.Denomination.ShowDialog()
		End Sub

		' Token: 0x0600ABEC RID: 44012 RVA: 0x0005019C File Offset: 0x0004E39C
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.Cashrefund.ShowDialog()
		End Sub

		' Token: 0x0600ABED RID: 44013 RVA: 0x0072DA78 File Offset: 0x0072BC78
		Private Sub Button14_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
			MyProject.Forms.Calender.ShowDialog()
			MyProject.Forms.Calender.Dispose()
		End Sub

		' Token: 0x0600ABEE RID: 44014 RVA: 0x0072DAD0 File Offset: 0x0072BCD0
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex < Me.cmbNP.Items.Count - 1
				If flag Then
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex + 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("Last Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABEF RID: 44015 RVA: 0x0072DB8C File Offset: 0x0072BD8C
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex > 0
				If flag Then
					' The following expression was wrapped in a checked-expression
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex - 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("First Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABF0 RID: 44016 RVA: 0x0072DC38 File Offset: 0x0072BE38
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Estimate").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Estimate").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABF1 RID: 44017 RVA: 0x0072DCF0 File Offset: 0x0072BEF0
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Estimate").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABF2 RID: 44018 RVA: 0x0072DD88 File Offset: 0x0072BF88
		Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select Temp_Stock.Barcode from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d2 and NOT Status=@d1"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox6.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox6.Text = ""
						Me.TextBox6.Focus()
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
						Return
					End If
					Me.cboxSpeed.Checked = True
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT RTRIM(ProductName) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1"
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox6.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
					If flag4 Then
						Me.TextBox5.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.dgw4.Focus()
						SendKeys.Send("{ENTER}")
						Dim flag5 As Boolean = (Conversion.Val(Me.txtQty.Text) = 0.0) Or (Operators.CompareString(Me.txtQty.Text, "", False) = 0)
						If flag5 Then
							Me.txtQty.Text = Conversions.ToString(1)
						End If
					End If
					Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag6 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag7 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag7 Then
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End Try
				e.SuppressKeyPress = True
			End If
			Me.cboxSpeed.Checked = True
		End Sub

		' Token: 0x0600ABF3 RID: 44019 RVA: 0x000501D6 File Offset: 0x0004E3D6
		Private Sub TextBox6_Leave(sender As Object, e As EventArgs)
			Me.cboxSpeed.Checked = False
		End Sub

		' Token: 0x0600ABF4 RID: 44020 RVA: 0x0072E038 File Offset: 0x0072C238
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCustomerName.Text, "Cash", False) <> 0
			If flag Then
				Me.CustomerLastItemAmount1()
			End If
		End Sub

		' Token: 0x0600ABF5 RID: 44021 RVA: 0x000501E6 File Offset: 0x0004E3E6
		Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs)
			Me.CheckBox2.Checked = False
			Me.cboxSpeed.Checked = True
		End Sub

		' Token: 0x0600ABF6 RID: 44022 RVA: 0x0072E06C File Offset: 0x0072C26C
		Public Sub ReadWeightPORT()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(WSPort) from POSprinterSetting where TillID=@d1 and ActiveWS='Yes'"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Dns.GetHostName())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.RichTextBox1.Text = ""
					Me.txtWPort.Text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End If
				flag = ModCommonClasses.rdr IsNot Nothing
				Dim flag3 As Boolean = flag
				If flag3 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show("You have not connected the Weight Machine in your system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ABF7 RID: 44023 RVA: 0x0072E180 File Offset: 0x0072C380
		Private Sub SerialPortOnDataReceived(sender As Object, serialDataReceivedEventArgs As SerialDataReceivedEventArgs)
			Control.CheckForIllegalCrossThreadCalls = False
			Try
				Dim invokeRequired As Boolean = MyBase.InvokeRequired
				If invokeRequired Then
					MyBase.BeginInvoke(New frmEstimate.Closure(Sub()
						Me.SerialPortOnDataReceived(RuntimeHelpers.GetObjectValue(sender), serialDataReceivedEventArgs)
					End Sub))
				Else
					Dim bytesToRead As Integer = Me.serialPort.BytesToRead
					Dim array As Byte() = New Byte(bytesToRead - 1 + 1 - 1) {}
					Dim num As Integer = Me.serialPort.Read(array, 0, bytesToRead)
					Dim flag As Boolean = num = 0
					If Not flag Then
						Me.txtQty.Text = ""
						Dim [string] As String = Encoding.UTF8.GetString(array)
						Me.txtQty.Text = [string].ToString()
						Me.txtQty.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtQty.Text), 3), "0.000")
						Me.serialPort.Close()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABF8 RID: 44024 RVA: 0x0072E2A0 File Offset: 0x0072C4A0
		Public Sub timingvalue()
			Try
				Dim flag As Boolean = Me.serialPort IsNot Nothing AndAlso Me.serialPort.IsOpen
				If flag Then
					Me.serialPort.Close()
				End If
				Dim flag2 As Boolean = Me.serialPort IsNot Nothing
				If flag2 Then
					Me.serialPort.Dispose()
				End If
				Me.serialPort = New SerialPort(Me.txtWPort.Text, 9600, Parity.None, 8, StopBits.One)
				Me.serialPort.RtsEnable = True
				Me.serialPort.ReceivedBytesThreshold = 1
				AddHandler Me.serialPort.DataReceived, AddressOf Me.SerialPortOnDataReceived
				Me.serialPort.Open()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ABF9 RID: 44025 RVA: 0x0072E36C File Offset: 0x0072C56C
		Private Sub Timer3_Tick(sender As Object, e As EventArgs)
			Me.UserControlSettings()
			Dim flag As Boolean = Not Me.Button25.Visible
			If flag Then
				Me.timingvalue()
			End If
		End Sub

		' Token: 0x0600ABFA RID: 44026 RVA: 0x0072E39C File Offset: 0x0072C59C
		Private Sub Button25_Click(sender As Object, e As EventArgs)
			Me.Button25.Visible = False
			Me.Button32.Visible = True
			Dim flag As Boolean = Not Me.Button25.Visible
			If flag Then
				Me.lblwmstatus.Text = "Weighing Scale Activated"
			Else
				Me.lblwmstatus.Text = ""
			End If
		End Sub

		' Token: 0x0600ABFB RID: 44027 RVA: 0x0072E400 File Offset: 0x0072C600
		Private Sub Button32_Click(sender As Object, e As EventArgs)
			Me.Button25.Visible = True
			Me.Button32.Visible = False
			Dim flag As Boolean = Not Me.Button25.Visible
			If flag Then
				Me.lblwmstatus.Text = "Weighing Scale Activated"
			Else
				Me.lblwmstatus.Text = ""
			End If
			Me.txtQty.Text = "0"
		End Sub

		' Token: 0x0600ABFC RID: 44028 RVA: 0x0072E474 File Offset: 0x0072C674
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update Estimate set KP=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "K")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				Me.Reset()
			Catch ex As Exception
				Me.Reset()
			End Try
		End Sub

		' Token: 0x0600ABFD RID: 44029 RVA: 0x0072E52C File Offset: 0x0072C72C
		Private Sub Button10_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update Estimate set KP=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "P")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				Me.Reset()
			Catch ex As Exception
				Me.Reset()
			End Try
		End Sub

		' Token: 0x0600ABFE RID: 44030 RVA: 0x00050203 File Offset: 0x0004E403
		Private Sub Button12_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = True
			Me.Button12.Visible = False
			Me.Button13.Visible = True
		End Sub

		' Token: 0x0600ABFF RID: 44031 RVA: 0x0005022D File Offset: 0x0004E42D
		Private Sub Button13_Click(sender As Object, e As EventArgs)
			Me.Panel5.Visible = False
			Me.Button12.Visible = True
			Me.Button13.Visible = False
		End Sub

		' Token: 0x0600AC00 RID: 44032 RVA: 0x0072E5E4 File Offset: 0x0072C7E4
		Public Sub OpenCashdrawer()
			Try
				Dim text As String = ChrW(27) & "p0@@"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and CashDrawer='Yes'"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Dns.GetHostName())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.s4 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim text2 As String = Me.s4
				ModCashDrawer.RawPrinter.PrintRaw(text2, text)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC01 RID: 44033 RVA: 0x0072E704 File Offset: 0x0072C904
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600AC02 RID: 44034 RVA: 0x0072E754 File Offset: 0x0072C954
		Public Sub CTypeStatus()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CType) from Estimate where QuotationNo=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtQuotationNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.rb = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Dim flag2 As Boolean = Operators.CompareString(Me.rb, "Retail", False) = 0
					If flag2 Then
						Me.RadioButton1.Checked = True
						Me.RadioButton2.Checked = False
						Me.RadioButton1.Enabled = False
						Me.RadioButton2.Enabled = False
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.rb, "Wholesale", False) = 0
						If flag3 Then
							Me.RadioButton1.Checked = False
							Me.RadioButton2.Checked = True
							Me.RadioButton1.Enabled = False
							Me.RadioButton2.Enabled = False
						End If
					End If
				Else
					Me.RadioButton1.Checked = True
					Me.RadioButton2.Checked = False
					Me.RadioButton1.Enabled = False
					Me.RadioButton2.Enabled = False
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AC03 RID: 44035 RVA: 0x0072E90C File Offset: 0x0072CB0C
		Private Sub Button33_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				MyProject.Forms.frmProductLedgerPOS.txtCustomerID.Text = Conversions.ToString(Conversion.Val(Me.txtProductID.Text))
				MyProject.Forms.frmProductLedgerPOS.Button3.Visible = True
				MyProject.Forms.frmProductLedgerPOS.ShowDialog()
			End If
		End Sub

		' Token: 0x0600AC04 RID: 44036 RVA: 0x0072E9A0 File Offset: 0x0072CBA0
		Public Sub CustomerLastItemAmount()
			Try
				ModCommonClasses.con102 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con102.Open()
				ModCommonClasses.cmd102 = ModCommonClasses.con102.CreateCommand()
				ModCommonClasses.cmd102.CommandText = "SELECT Top 1 RTRIM(Invoice_Product.SalesRate),InvoiceInfo.InvoiceDate from InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE RTRIM(Customer.CustomerID)=@d1 and RTRIM(Product.PID)=@d2 order by Inv_ID DESC"
				ModCommonClasses.cmd102.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.cmd102.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
				ModCommonClasses.rdr102 = ModCommonClasses.cmd102.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr102.Read()
				If flag Then
					Me.lblCustLastItemPrice.Text = ModCommonClasses.rdr102.GetValue(0).ToString()
				Else
					Me.lblCustLastItemPrice.Text = "0"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr102 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr102.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con102.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con102.Close()
				End If
				Me.lblCustLastItemPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblCustLastItemPrice.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC05 RID: 44037 RVA: 0x0072EB24 File Offset: 0x0072CD24
		Public Sub CustomerLastItemAmount1()
			Try
				ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con101.Open()
				ModCommonClasses.cmd101 = ModCommonClasses.con101.CreateCommand()
				ModCommonClasses.cmd101.CommandText = "SELECT Top 1 RTRIM(Invoice_Product.SalesRate),InvoiceInfo.InvoiceDate from InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE RTRIM(Customer.CustomerID)=@d1 and RTRIM(Product.PID)=@d2 order by Inv_ID DESC"
				ModCommonClasses.cmd101.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.cmd101.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
				ModCommonClasses.rdr101 = ModCommonClasses.cmd101.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr101.Read()
				If flag Then
					Me.lblCustLastItemPrice.Text = ModCommonClasses.rdr101.GetValue(0).ToString()
				Else
					Me.lblCustLastItemPrice.Text = "0"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr101 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr101.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con101.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con101.Close()
				End If
				Me.lblCustLastItemPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblCustLastItemPrice.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC06 RID: 44038 RVA: 0x0072ECA8 File Offset: 0x0072CEA8
		Private Sub lblCustLastItemPrice_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.lblCustLastItemPrice.Visible = True
			Else
				Me.lblCustLastItemPrice.Visible = False
			End If
		End Sub

		' Token: 0x0600AC07 RID: 44039 RVA: 0x0072ECA8 File Offset: 0x0072CEA8
		Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.lblCustLastItemPrice.Visible = True
			Else
				Me.lblCustLastItemPrice.Visible = False
			End If
		End Sub

		' Token: 0x0600AC08 RID: 44040 RVA: 0x0072ECE4 File Offset: 0x0072CEE4
		Public Sub ProductLastAmount()
			Try
				ModCommonClasses.con103 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con103.Open()
				ModCommonClasses.cmd103 = ModCommonClasses.con103.CreateCommand()
				ModCommonClasses.cmd103.CommandText = If(("SELECT RTRIM(LastPrice),RTRIM(CostPrice) from Product where PID = " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
				ModCommonClasses.rdr103 = ModCommonClasses.cmd103.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr103.Read()
				If flag Then
					Me.lblLastPrice.Text = ModCommonClasses.rdr103.GetValue(0).ToString()
					Me.lblPurCost.Text = ModCommonClasses.rdr103.GetValue(1).ToString()
				Else
					Me.lblLastPrice.Text = "0"
					Me.lblPurCost.Text = "0"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr103 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr103.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con103.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con103.Close()
				End If
				Me.lblLastPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblLastPrice.Text), 2), "0.00")
				Me.lblPurCost.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblPurCost.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC09 RID: 44041 RVA: 0x0072EEA8 File Offset: 0x0072D0A8
		Private Sub chkBoxLastSoldPrice_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkBoxLastSoldPrice.Checked
			If checked Then
				Me.lblLastPrice.Visible = True
			Else
				Me.lblLastPrice.Visible = False
			End If
		End Sub

		' Token: 0x0600AC0A RID: 44042 RVA: 0x0072EEA8 File Offset: 0x0072D0A8
		Private Sub lblLastPrice_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkBoxLastSoldPrice.Checked
			If checked Then
				Me.lblLastPrice.Visible = True
			Else
				Me.lblLastPrice.Visible = False
			End If
		End Sub

		' Token: 0x0600AC0B RID: 44043 RVA: 0x0072EEE4 File Offset: 0x0072D0E4
		Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Me.lblPurCost.Visible = True
			Else
				Me.lblPurCost.Visible = False
			End If
		End Sub

		' Token: 0x0600AC0C RID: 44044 RVA: 0x0072EEE4 File Offset: 0x0072D0E4
		Private Sub lblPurCost_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Me.lblPurCost.Visible = True
			Else
				Me.lblPurCost.Visible = False
			End If
		End Sub

		' Token: 0x0600AC0D RID: 44045 RVA: 0x0072EF20 File Offset: 0x0072D120
		Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column4").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column4").Value))
						End If

				Next
				Dim flag2 As Boolean = num2 <= 0.0
				If flag2 Then
					Me.RadioButton1.Enabled = True
					Me.RadioButton2.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AC0E RID: 44046 RVA: 0x0072F00C File Offset: 0x0072D20C
		Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Me.CheckBox13.Checked
			If flag Then
				Me.dgw.Visible = False
			Else
				Dim checked As Boolean = Me.CheckBox13.Checked
				If checked Then
					Me.dgw.Visible = True
				End If
			End If
			Dim checked2 As Boolean = Me.CheckBox13.Checked
			If checked2 Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update AutoSet set Set1=@d1 where ID=@d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 8)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			End If
			Dim flag2 As Boolean = Not Me.CheckBox13.Checked
			If flag2 Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "Update AutoSet set Set1=@d1 where ID=@d2"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 8)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "No")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			End If
		End Sub

		' Token: 0x0600AC0F RID: 44047 RVA: 0x0072F1AC File Offset: 0x0072D3AC
		Public Sub PDBoardAll6()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(Set1) from AutoSet where ID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 8)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim text As String
				If flag Then
					text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					text = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(text, "Yes", False) = 0
				If flag4 Then
					Me.CheckBox13.Checked = True
				Else
					Me.CheckBox13.Checked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC10 RID: 44048 RVA: 0x0072F2F4 File Offset: 0x0072D4F4
		Public Sub ProductImageRetrieve()
			Dim checked As Boolean = Me.CheckBox13.Checked
			If checked Then
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con1)
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr1(0), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Dim image As Image = Image.FromStream(memoryStream)
					Me.dgw.Rows.Add(New Object() { image })
				End While
				ModCommonClasses.con1.Close()
			End If
		End Sub

		' Token: 0x0600AC11 RID: 44049 RVA: 0x0072F3E8 File Offset: 0x0072D5E8
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column6").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column3").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column23").Value)))
					Me.a3 = Me.DataGridView1.Rows(i).Cells("Column24").Value.ToString()
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { Me.a1 + " " + Me.a2 + Me.a3 + " " + Me.txtRsToWords.Text }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AC12 RID: 44050 RVA: 0x0072F5B0 File Offset: 0x0072D7B0
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x0600AC13 RID: 44051 RVA: 0x0072F5F4 File Offset: 0x0072D7F4
		Private Sub Button15_Click(sender As Object, e As EventArgs)
			Try
				Dim reportDocument As ReportDocument = New CryToken1()
				reportDocument.SetParameterValue("P1", Me.cmpnm)
				reportDocument.SetParameterValue("P2", Me.txtQuotationNo.Text)
				reportDocument.SetParameterValue("P3", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("P4", Me.dtpQuotationDate.Text)
				reportDocument.SetParameterValue("P5", DateAndTime.Now)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AC14 RID: 44052 RVA: 0x00050257 File Offset: 0x0004E457
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600AC15 RID: 44053 RVA: 0x0072F6D0 File Offset: 0x0072D8D0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmEstimateRecord.Label3.Text = "Est"
			MyProject.Forms.frmEstimateRecord.Reset()
			MyProject.Forms.frmEstimateRecord.ShowDialog()
			MyProject.Forms.frmEstimateRecord.Dispose()
		End Sub

		' Token: 0x0600AC16 RID: 44054 RVA: 0x0072F730 File Offset: 0x0072D930
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

		' Token: 0x0600AC17 RID: 44055 RVA: 0x0072F798 File Offset: 0x0072D998
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag2 Then
					MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select * from Company"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update Estimate set QuotationNo=@d2, Date=@d3, TaxType=@d4, CustomerID=@d5, SubTotal=@d6, CGST=@d7, SGST=@d8, IGST=@d9, CESS=@d10,Total=@d11,RoundOff=@d12, GrandTotal=@d13, Remarks=@d14, CType=@d15, KP=@d16 where Q_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpQuotationDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "NON GST")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtCGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtSGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtRoundOff.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtRemarks.Text)
							Dim flag5 As Boolean = Me.RadioButton1.Checked And Not Me.RadioButton2.Checked
							If flag5 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
							Else
								Dim flag6 As Boolean = Me.RadioButton2.Checked And Not Me.RadioButton1.Checked
								If flag6 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Wholesale")
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
								End If
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "P")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = If(("Delete from Estimate_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "insert into Estimate_Join(QuotationID, ProductID,Barcode, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,AltQty,AltUnit,STaxType) VALUES (" + Me.txtQ_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag7 As Boolean = Not dataGridViewRow.IsNewRow
									If flag7 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.cmd.Parameters.Clear()
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							ModCommonClasses.con.Close()
							Me.btnUpdate.Enabled = False
							Me.btnSave.Enabled = True
							Me.btnDelete.Enabled = False
							Dim text5 As String = "Updated the estimate having estimate no. '" + Me.txtQuotationNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text5)
							MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600AC18 RID: 44056 RVA: 0x007301A8 File Offset: 0x0072E3A8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpQuotationDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Estimate where Date between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dateTime2
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 vouchers for current month in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
			Me.auto()
			Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
			If flag4 Then
				MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag5 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag5 Then
					MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select * from Company"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag6 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag6 Then
							MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag7 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Estimate(Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS,Total,RoundOff, GrandTotal, Remarks,CType,KP) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpQuotationDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "NON GST")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtCGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtSGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtRoundOff.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtRemarks.Text)
							Dim flag8 As Boolean = Me.RadioButton1.Checked And Not Me.RadioButton2.Checked
							If flag8 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
							Else
								Dim flag9 As Boolean = Me.RadioButton2.Checked And Not Me.RadioButton1.Checked
								If flag9 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Wholesale")
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
								End If
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "P")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "insert into Estimate_Join(QuotationID, ProductID,Barcode, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,AltQty,AltUnit,STaxType) VALUES (" + Me.txtQ_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag10 As Boolean = Not dataGridViewRow.IsNewRow
									If flag10 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.cmd.Parameters.Clear()
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text5 As String = "insert into SrEstimate(ID, InvNo) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text5)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Dim text6 As String = "added the new estimate having quotation no. '" + Me.txtQuotationNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text6)
							Me.btnSave.Enabled = False
							ModCommonClasses.con.Close()
							Me.DataforNP()
							Me.Button15.Enabled = True
							Dim flag11 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print the Estimate Invoice ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
							If flag11 Then
								Me.Print()
							End If
							Me.fillEstimateID()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600AC19 RID: 44057 RVA: 0x00050261 File Offset: 0x0004E461
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub

		' Token: 0x0600AC1A RID: 44058 RVA: 0x00730D5C File Offset: 0x0072EF5C
		Public Sub UserControlSettings()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c50) from UserControl where RTRIM(UserID)=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblUser.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.s50 = ModCommonClasses.rdr.GetValue(0).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag2 As Boolean = Operators.CompareString(Me.s50, "Disable", False) = 0
			If flag2 Then
				Me.Button25.Enabled = False
				Me.Button32.Enabled = False
			Else
				Me.Button25.Enabled = True
				Me.Button32.Enabled = True
			End If
		End Sub

		' Token: 0x0600AC1B RID: 44059 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw4 As DataGridView, setting As Boolean)
			Dim type As Type = dgw4.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw4, setting, Nothing)
		End Sub

		' Token: 0x0600AC1C RID: 44060 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEstimate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600AC1D RID: 44061 RVA: 0x00730E90 File Offset: 0x0072F090
		Public Sub InvoiceHead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(LIDS) from InvoiceHead"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.InvDateSts = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.InvDateSts = "No"
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

		' Token: 0x0600AC1E RID: 44062 RVA: 0x00730F88 File Offset: 0x0072F188
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Estimate order by Q_ID DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.prevdate = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0).ToString())
				Else
					Me.prevdate = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.InvDateSts, "Yes", False) = 0
				If flag4 Then
					Me.dtpQuotationDate.Value = Me.prevdate
				Else
					Me.dtpQuotationDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC1F RID: 44063 RVA: 0x00050272 File Offset: 0x0004E472
		Public Sub customerdetaildisable()
			Me.cmbCustomerName.Enabled = False
			Me.btnCustomerSelection.Enabled = False
			Me.txtContactNo.[ReadOnly] = True
		End Sub

		' Token: 0x0600AC20 RID: 44064 RVA: 0x0005029C File Offset: 0x0004E49C
		Public Sub customerdetailenable()
			Me.cmbCustomerName.Enabled = True
			Me.btnCustomerSelection.Enabled = True
			Me.txtContactNo.[ReadOnly] = False
		End Sub

		' Token: 0x0600AC21 RID: 44065 RVA: 0x007310C8 File Offset: 0x0072F2C8
		Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = Me.DataGridView1.RowCount > 0
			If flag Then
				Me.customerdetaildisable()
			End If
		End Sub

		' Token: 0x0600AC22 RID: 44066 RVA: 0x007310F4 File Offset: 0x0072F2F4
		Public Sub UnitInfo()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				Dim text As String = "SELECT DISTINCT RTRIM(a2) FROM ExtDB1 WHERE a1=@d1"
				ModCommonClasses.cmd1 = New SqlCommand(text)
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
				ModCommonClasses.cmd1.CommandTimeout = 0
				Me.cmbUnit.Items.Clear()
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				While ModCommonClasses.rdr1.Read()
					Me.cmbUnit.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr1.GetValue(0)))
				End While
				ModCommonClasses.rdr1.Close()
				ModCommonClasses.con1.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC23 RID: 44067 RVA: 0x00731214 File Offset: 0x0072F414
		Private Sub Button1_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button1, "Add Product")
		End Sub

		' Token: 0x0600AC24 RID: 44068 RVA: 0x00731264 File Offset: 0x0072F464
		Private Sub Button33_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button33, "Product Dashboard")
		End Sub

		' Token: 0x0600AC25 RID: 44069 RVA: 0x007312B4 File Offset: 0x0072F4B4
		Private Sub Button22_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button22, "Add Customer")
		End Sub

		' Token: 0x0600AC26 RID: 44070 RVA: 0x00731304 File Offset: 0x0072F504
		Private Sub txtPricePerQty_GotFocus(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from InvoiceInfo Having count(*) >= 1 and " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " > 0"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dgwsale.Visible = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP 5 InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.InvoiceNo),  RTRIM(Customer.Name), Invoice_Product.SalesRate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE Invoice_Product.ProductID = " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " order by Invoiceinfo.InvoiceDate DESC", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgwsale.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgwsale.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					Me.dgwsale.ClearSelection()
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AC27 RID: 44071 RVA: 0x000502C6 File Offset: 0x0004E4C6
		Private Sub txtPricePerQty_LostFocus(sender As Object, e As EventArgs)
			Me.dgwsale.Visible = False
		End Sub

		' Token: 0x040047E6 RID: 18406
		Private st2 As String

		' Token: 0x040047E7 RID: 18407
		Private num1 As Double

		' Token: 0x040047E8 RID: 18408
		Private num2 As Double

		' Token: 0x040047E9 RID: 18409
		Private num3 As Double

		' Token: 0x040047EA RID: 18410
		Private num4 As Double

		' Token: 0x040047EB RID: 18411
		Private num5 As Double

		' Token: 0x040047EC RID: 18412
		Private num6 As Double

		' Token: 0x040047ED RID: 18413
		Private num7 As Double

		' Token: 0x040047EE RID: 18414
		Private num8 As Double

		' Token: 0x040047EF RID: 18415
		Private num9 As Double

		' Token: 0x040047F0 RID: 18416
		Private num10 As Double

		' Token: 0x040047F1 RID: 18417
		Private num11 As Double

		' Token: 0x040047F2 RID: 18418
		Private a As Decimal

		' Token: 0x040047F3 RID: 18419
		Private V1 As String

		' Token: 0x040047F4 RID: 18420
		Private V2 As String

		' Token: 0x040047F5 RID: 18421
		Private V3 As String

		' Token: 0x040047F6 RID: 18422
		Private V4 As String

		' Token: 0x040047F7 RID: 18423
		Private V5 As String

		' Token: 0x040047F8 RID: 18424
		Private V6 As String

		' Token: 0x040047F9 RID: 18425
		Private V7 As String

		' Token: 0x040047FA RID: 18426
		Private V8 As String

		' Token: 0x040047FB RID: 18427
		Private cmpnm As String

		' Token: 0x040047FC RID: 18428
		Private ntid As String

		' Token: 0x040047FD RID: 18429
		Private Dad As SqlDataAdapter

		' Token: 0x040047FE RID: 18430
		Private Dst As DataSet

		' Token: 0x040047FF RID: 18431
		Private CurrentRow As Object

		' Token: 0x04004800 RID: 18432
		Private serialPort As SerialPort

		' Token: 0x04004801 RID: 18433
		Private Const BaudRate As Integer = 9600

		' Token: 0x04004802 RID: 18434
		Private s4 As String

		' Token: 0x04004803 RID: 18435
		Private rb As String

		' Token: 0x04004804 RID: 18436
		Private voice As Object

		' Token: 0x04004805 RID: 18437
		Private a1 As String

		' Token: 0x04004806 RID: 18438
		Private a2 As String

		' Token: 0x04004807 RID: 18439
		Private a3 As String

		' Token: 0x04004808 RID: 18440
		Private s50 As String

		' Token: 0x04004809 RID: 18441
		Private InvDateSts As String

		' Token: 0x0400480A RID: 18442
		Private prevdate As DateTime

		' Token: 0x0200029F RID: 671
		' (Invoke) Token: 0x0600AC2B RID: 44075
		Private Delegate Sub Closure()
	End Class
End Namespace
