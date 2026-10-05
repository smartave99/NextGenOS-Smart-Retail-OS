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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000D1 RID: 209
	<DesignerGenerated()>
	Public Partial Class frmContra
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060024F4 RID: 9460 RVA: 0x00018EAB File Offset: 0x000170AB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmContra_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmContra_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000E9D RID: 3741
		' (get) Token: 0x060024F7 RID: 9463 RVA: 0x00018EDD File Offset: 0x000170DD
		' (set) Token: 0x060024F8 RID: 9464 RVA: 0x00018EE7 File Offset: 0x000170E7
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000E9E RID: 3742
		' (get) Token: 0x060024F9 RID: 9465 RVA: 0x00018EF0 File Offset: 0x000170F0
		' (set) Token: 0x060024FA RID: 9466 RVA: 0x00018EFA File Offset: 0x000170FA
		Friend Overridable Property Label1 As Label

		' Token: 0x17000E9F RID: 3743
		' (get) Token: 0x060024FB RID: 9467 RVA: 0x00018F03 File Offset: 0x00017103
		' (set) Token: 0x060024FC RID: 9468 RVA: 0x00018F0D File Offset: 0x0001710D
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000EA0 RID: 3744
		' (get) Token: 0x060024FD RID: 9469 RVA: 0x00018F16 File Offset: 0x00017116
		' (set) Token: 0x060024FE RID: 9470 RVA: 0x00178F00 File Offset: 0x00177100
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EA1 RID: 3745
		' (get) Token: 0x060024FF RID: 9471 RVA: 0x00018F20 File Offset: 0x00017120
		' (set) Token: 0x06002500 RID: 9472 RVA: 0x00178F44 File Offset: 0x00177144
		Private _cmbTransType As ComboBox
		Friend Overridable Property cmbTransType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTransType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbTransType_KeyDown
				Dim comboBox As ComboBox = Me._cmbTransType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbTransType = value
				comboBox = Me._cmbTransType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EA2 RID: 3746
		' (get) Token: 0x06002501 RID: 9473 RVA: 0x00018F2A File Offset: 0x0001712A
		' (set) Token: 0x06002502 RID: 9474 RVA: 0x00018F34 File Offset: 0x00017134
		Friend Overridable Property txtID As TextBox

		' Token: 0x17000EA3 RID: 3747
		' (get) Token: 0x06002503 RID: 9475 RVA: 0x00018F3D File Offset: 0x0001713D
		' (set) Token: 0x06002504 RID: 9476 RVA: 0x00018F47 File Offset: 0x00017147
		Friend Overridable Property txtContraID As TextBox

		' Token: 0x17000EA4 RID: 3748
		' (get) Token: 0x06002505 RID: 9477 RVA: 0x00018F50 File Offset: 0x00017150
		' (set) Token: 0x06002506 RID: 9478 RVA: 0x00018F5A File Offset: 0x0001715A
		Friend Overridable Property Label7 As Label

		' Token: 0x17000EA5 RID: 3749
		' (get) Token: 0x06002507 RID: 9479 RVA: 0x00018F63 File Offset: 0x00017163
		' (set) Token: 0x06002508 RID: 9480 RVA: 0x00178F88 File Offset: 0x00177188
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
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EA6 RID: 3750
		' (get) Token: 0x06002509 RID: 9481 RVA: 0x00018F6D File Offset: 0x0001716D
		' (set) Token: 0x0600250A RID: 9482 RVA: 0x00018F77 File Offset: 0x00017177
		Friend Overridable Property Label6 As Label

		' Token: 0x17000EA7 RID: 3751
		' (get) Token: 0x0600250B RID: 9483 RVA: 0x00018F80 File Offset: 0x00017180
		' (set) Token: 0x0600250C RID: 9484 RVA: 0x00018F8A File Offset: 0x0001718A
		Friend Overridable Property txtName As TextBox

		' Token: 0x17000EA8 RID: 3752
		' (get) Token: 0x0600250D RID: 9485 RVA: 0x00018F93 File Offset: 0x00017193
		' (set) Token: 0x0600250E RID: 9486 RVA: 0x00018F9D File Offset: 0x0001719D
		Friend Overridable Property Label5 As Label

		' Token: 0x17000EA9 RID: 3753
		' (get) Token: 0x0600250F RID: 9487 RVA: 0x00018FA6 File Offset: 0x000171A6
		' (set) Token: 0x06002510 RID: 9488 RVA: 0x00178FE8 File Offset: 0x001771E8
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
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EAA RID: 3754
		' (get) Token: 0x06002511 RID: 9489 RVA: 0x00018FB0 File Offset: 0x000171B0
		' (set) Token: 0x06002512 RID: 9490 RVA: 0x00018FBA File Offset: 0x000171BA
		Friend Overridable Property Label4 As Label

		' Token: 0x17000EAB RID: 3755
		' (get) Token: 0x06002513 RID: 9491 RVA: 0x00018FC3 File Offset: 0x000171C3
		' (set) Token: 0x06002514 RID: 9492 RVA: 0x00018FCD File Offset: 0x000171CD
		Friend Overridable Property Label3 As Label

		' Token: 0x17000EAC RID: 3756
		' (get) Token: 0x06002515 RID: 9493 RVA: 0x00018FD6 File Offset: 0x000171D6
		' (set) Token: 0x06002516 RID: 9494 RVA: 0x00018FE0 File Offset: 0x000171E0
		Friend Overridable Property Label2 As Label

		' Token: 0x17000EAD RID: 3757
		' (get) Token: 0x06002517 RID: 9495 RVA: 0x00018FE9 File Offset: 0x000171E9
		' (set) Token: 0x06002518 RID: 9496 RVA: 0x00018FF3 File Offset: 0x000171F3
		Friend Overridable Property Label9 As Label

		' Token: 0x17000EAE RID: 3758
		' (get) Token: 0x06002519 RID: 9497 RVA: 0x00018FFC File Offset: 0x000171FC
		' (set) Token: 0x0600251A RID: 9498 RVA: 0x00019006 File Offset: 0x00017206
		Friend Overridable Property Label8 As Label

		' Token: 0x17000EAF RID: 3759
		' (get) Token: 0x0600251B RID: 9499 RVA: 0x0001900F File Offset: 0x0001720F
		' (set) Token: 0x0600251C RID: 9500 RVA: 0x00019019 File Offset: 0x00017219
		Friend Overridable Property lblUser As Label

		' Token: 0x17000EB0 RID: 3760
		' (get) Token: 0x0600251D RID: 9501 RVA: 0x00019022 File Offset: 0x00017222
		' (set) Token: 0x0600251E RID: 9502 RVA: 0x0001902C File Offset: 0x0001722C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17000EB1 RID: 3761
		' (get) Token: 0x0600251F RID: 9503 RVA: 0x00019035 File Offset: 0x00017235
		' (set) Token: 0x06002520 RID: 9504 RVA: 0x00179048 File Offset: 0x00177248
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EB2 RID: 3762
		' (get) Token: 0x06002521 RID: 9505 RVA: 0x0001903F File Offset: 0x0001723F
		' (set) Token: 0x06002522 RID: 9506 RVA: 0x00019049 File Offset: 0x00017249
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000EB3 RID: 3763
		' (get) Token: 0x06002523 RID: 9507 RVA: 0x00019052 File Offset: 0x00017252
		' (set) Token: 0x06002524 RID: 9508 RVA: 0x001790A8 File Offset: 0x001772A8
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EB4 RID: 3764
		' (get) Token: 0x06002525 RID: 9509 RVA: 0x0001905C File Offset: 0x0001725C
		' (set) Token: 0x06002526 RID: 9510 RVA: 0x001790EC File Offset: 0x001772EC
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
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EB5 RID: 3765
		' (get) Token: 0x06002527 RID: 9511 RVA: 0x00019066 File Offset: 0x00017266
		' (set) Token: 0x06002528 RID: 9512 RVA: 0x00019070 File Offset: 0x00017270
		Friend Overridable Property Label16 As Label

		' Token: 0x17000EB6 RID: 3766
		' (get) Token: 0x06002529 RID: 9513 RVA: 0x00019079 File Offset: 0x00017279
		' (set) Token: 0x0600252A RID: 9514 RVA: 0x00019083 File Offset: 0x00017283
		Friend Overridable Property Label15 As Label

		' Token: 0x17000EB7 RID: 3767
		' (get) Token: 0x0600252B RID: 9515 RVA: 0x0001908C File Offset: 0x0001728C
		' (set) Token: 0x0600252C RID: 9516 RVA: 0x00019096 File Offset: 0x00017296
		Friend Overridable Property Label14 As Label

		' Token: 0x17000EB8 RID: 3768
		' (get) Token: 0x0600252D RID: 9517 RVA: 0x0001909F File Offset: 0x0001729F
		' (set) Token: 0x0600252E RID: 9518 RVA: 0x00179130 File Offset: 0x00177330
		Private _ComboBox3 As ComboBox
		Friend Overridable Property ComboBox3 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox3_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox3 = value
				comboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EB9 RID: 3769
		' (get) Token: 0x0600252F RID: 9519 RVA: 0x000190A9 File Offset: 0x000172A9
		' (set) Token: 0x06002530 RID: 9520 RVA: 0x000190B3 File Offset: 0x000172B3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000EBA RID: 3770
		' (get) Token: 0x06002531 RID: 9521 RVA: 0x000190BC File Offset: 0x000172BC
		' (set) Token: 0x06002532 RID: 9522 RVA: 0x000190C6 File Offset: 0x000172C6
		Friend Overridable Property Label10 As Label

		' Token: 0x17000EBB RID: 3771
		' (get) Token: 0x06002533 RID: 9523 RVA: 0x000190CF File Offset: 0x000172CF
		' (set) Token: 0x06002534 RID: 9524 RVA: 0x000190D9 File Offset: 0x000172D9
		Friend Overridable Property Label11 As Label

		' Token: 0x17000EBC RID: 3772
		' (get) Token: 0x06002535 RID: 9525 RVA: 0x000190E2 File Offset: 0x000172E2
		' (set) Token: 0x06002536 RID: 9526 RVA: 0x000190EC File Offset: 0x000172EC
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000EBD RID: 3773
		' (get) Token: 0x06002537 RID: 9527 RVA: 0x000190F5 File Offset: 0x000172F5
		' (set) Token: 0x06002538 RID: 9528 RVA: 0x000190FF File Offset: 0x000172FF
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000EBE RID: 3774
		' (get) Token: 0x06002539 RID: 9529 RVA: 0x00019108 File Offset: 0x00017308
		' (set) Token: 0x0600253A RID: 9530 RVA: 0x00019112 File Offset: 0x00017312
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000EBF RID: 3775
		' (get) Token: 0x0600253B RID: 9531 RVA: 0x0001911B File Offset: 0x0001731B
		' (set) Token: 0x0600253C RID: 9532 RVA: 0x00019125 File Offset: 0x00017325
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000EC0 RID: 3776
		' (get) Token: 0x0600253D RID: 9533 RVA: 0x0001912E File Offset: 0x0001732E
		' (set) Token: 0x0600253E RID: 9534 RVA: 0x00019138 File Offset: 0x00017338
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000EC1 RID: 3777
		' (get) Token: 0x0600253F RID: 9535 RVA: 0x00019141 File Offset: 0x00017341
		' (set) Token: 0x06002540 RID: 9536 RVA: 0x0001914B File Offset: 0x0001734B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000EC2 RID: 3778
		' (get) Token: 0x06002541 RID: 9537 RVA: 0x00019154 File Offset: 0x00017354
		' (set) Token: 0x06002542 RID: 9538 RVA: 0x0001915E File Offset: 0x0001735E
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000EC3 RID: 3779
		' (get) Token: 0x06002543 RID: 9539 RVA: 0x00019167 File Offset: 0x00017367
		' (set) Token: 0x06002544 RID: 9540 RVA: 0x00179174 File Offset: 0x00177374
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

		' Token: 0x17000EC4 RID: 3780
		' (get) Token: 0x06002545 RID: 9541 RVA: 0x00019171 File Offset: 0x00017371
		' (set) Token: 0x06002546 RID: 9542 RVA: 0x0001917B File Offset: 0x0001737B
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17000EC5 RID: 3781
		' (get) Token: 0x06002547 RID: 9543 RVA: 0x00019184 File Offset: 0x00017384
		' (set) Token: 0x06002548 RID: 9544 RVA: 0x0001918E File Offset: 0x0001738E
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17000EC6 RID: 3782
		' (get) Token: 0x06002549 RID: 9545 RVA: 0x00019197 File Offset: 0x00017397
		' (set) Token: 0x0600254A RID: 9546 RVA: 0x000191A1 File Offset: 0x000173A1
		Friend Overridable Property Label12 As Label

		' Token: 0x17000EC7 RID: 3783
		' (get) Token: 0x0600254B RID: 9547 RVA: 0x000191AA File Offset: 0x000173AA
		' (set) Token: 0x0600254C RID: 9548 RVA: 0x000191B4 File Offset: 0x000173B4
		Friend Overridable Property Label13 As Label

		' Token: 0x17000EC8 RID: 3784
		' (get) Token: 0x0600254D RID: 9549 RVA: 0x000191BD File Offset: 0x000173BD
		' (set) Token: 0x0600254E RID: 9550 RVA: 0x000191C7 File Offset: 0x000173C7
		Friend Overridable Property Label17 As Label

		' Token: 0x17000EC9 RID: 3785
		' (get) Token: 0x0600254F RID: 9551 RVA: 0x000191D0 File Offset: 0x000173D0
		' (set) Token: 0x06002550 RID: 9552 RVA: 0x000191DA File Offset: 0x000173DA
		Friend Overridable Property Label18 As Label

		' Token: 0x17000ECA RID: 3786
		' (get) Token: 0x06002551 RID: 9553 RVA: 0x000191E3 File Offset: 0x000173E3
		' (set) Token: 0x06002552 RID: 9554 RVA: 0x001791B8 File Offset: 0x001773B8
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
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

		' Token: 0x17000ECB RID: 3787
		' (get) Token: 0x06002553 RID: 9555 RVA: 0x000191ED File Offset: 0x000173ED
		' (set) Token: 0x06002554 RID: 9556 RVA: 0x001791FC File Offset: 0x001773FC
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._Button4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button4 = value
				gelButton = Me._Button4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ECC RID: 3788
		' (get) Token: 0x06002555 RID: 9557 RVA: 0x000191F7 File Offset: 0x000173F7
		' (set) Token: 0x06002556 RID: 9558 RVA: 0x00179240 File Offset: 0x00177440
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ECD RID: 3789
		' (get) Token: 0x06002557 RID: 9559 RVA: 0x00019201 File Offset: 0x00017401
		' (set) Token: 0x06002558 RID: 9560 RVA: 0x00179284 File Offset: 0x00177484
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ECE RID: 3790
		' (get) Token: 0x06002559 RID: 9561 RVA: 0x0001920B File Offset: 0x0001740B
		' (set) Token: 0x0600255A RID: 9562 RVA: 0x001792C8 File Offset: 0x001774C8
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600255B RID: 9563 RVA: 0x0017930C File Offset: 0x0017750C
		Private Sub frmContra_Load(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.dtpDate.Value = DateAndTime.Now
			Me.DateFrom.Value = DateAndTime.Now
			Me.DateTo.Value = DateAndTime.Now
			Me.auto()
			Me.fillAccountInfo()
			Me.cih()
			Me.Getdata()
			Me.fillvoucher()
			Me.fillBankAc()
			Me.Label17.Text = "0.00"
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600255C RID: 9564 RVA: 0x00179424 File Offset: 0x00177624
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

		' Token: 0x0600255D RID: 9565 RVA: 0x001796C4 File Offset: 0x001778C4
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

		' Token: 0x0600255E RID: 9566 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600255F RID: 9567 RVA: 0x00179790 File Offset: 0x00177990
		Private Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.dtpDate.Value = DateAndTime.Now
			Me.DateFrom.Value = DateAndTime.Now
			Me.DateTo.Value = DateAndTime.Now
			Me.auto()
			Me.cih()
			Me.Getdata()
			Me.txtID.Text = ""
			Me.cmbTransType.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.txtName.Text = ""
			Me.txtAmount.Text = "0.00"
			Me.dtpDate.Focus()
			Me.Button2.Enabled = True
			Me.Button3.Enabled = False
			Me.Button1.Enabled = False
			Me.fillvoucher()
			Me.fillBankAc()
			Me.Label17.Text = "0.00"
		End Sub

		' Token: 0x06002560 RID: 9568 RVA: 0x001798AC File Offset: 0x00177AAC
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Contra ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06002561 RID: 9569 RVA: 0x00179A18 File Offset: 0x00177C18
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtContraID.Text = "CON-" + Me.GenerateID() + "-" + DateAndTime.Now.ToString("yyyy")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002562 RID: 9570 RVA: 0x00179AA4 File Offset: 0x00177CA4
		Public Sub fillAccountInfo()
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

		' Token: 0x06002563 RID: 9571 RVA: 0x00179BCC File Offset: 0x00177DCC
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
					Me.txtName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode),IsNull(Sum(Credit)-Sum(Debit),0) from BankAccountRegistration LEFT JOIN BankBranch ON BankAccountRegistration.BranchID = BankBranch.Id LEFT JOIN BankAccountLedger ON BankAccountRegistration.AccountNo = BankAccountLedger.AccNo where AccountNo=@d1 group by AccountName,BankName,BranchName,SwiftCode,IFSCCode"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
				If flag4 Then
					Me.Label17.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
				End If
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag6 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002564 RID: 9572 RVA: 0x00179DE4 File Offset: 0x00177FE4
		Private Sub cih()
			Me.Label9.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from LedgerBook where Name='Cash Account'"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr1.GetValue(0)))
				If flag3 Then
					Me.Label9.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.Label9.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label9.Text), 2), "0.00")
		End Sub

		' Token: 0x06002565 RID: 9573 RVA: 0x00179ECC File Offset: 0x001780CC
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

		' Token: 0x06002566 RID: 9574 RVA: 0x00179FC4 File Offset: 0x001781C4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(ConID),RTRIM(Type),RTRIM(BankAc),RTRIM(BenfName),Amount from Contra order by ID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002567 RID: 9575 RVA: 0x0017A104 File Offset: 0x00178304
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.dtpDate.Text = NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Date", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
					Me.txtContraID.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.cmbTransType.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.cmbAccountNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtName.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtAmount.Text = Conversions.ToString(Conversion.Val(dataGridViewRow.Cells(6).Value.ToString()))
					Me.Button3.Enabled = True
					Me.Button1.Enabled = True
					Me.Button2.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002568 RID: 9576 RVA: 0x00019215 File Offset: 0x00017415
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06002569 RID: 9577 RVA: 0x0017A2A4 File Offset: 0x001784A4
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

		' Token: 0x0600256A RID: 9578 RVA: 0x0017A38C File Offset: 0x0017858C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Contra where ID =" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "Deleted the contra voucher id : '" + Me.txtContraID.Text + "'")
					ModFunc.LedgerDelete(Me.txtContraID.Text, "Contra")
					ModFunc.BankAccountLedgerDelete(Me.txtContraID.Text, "Contra")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag2 Then
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600256B RID: 9579 RVA: 0x0017A50C File Offset: 0x0017870C
		Public Sub fillvoucher()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ConID) FROM Contra", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox2.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox2.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600256C RID: 9580 RVA: 0x0017A640 File Offset: 0x00178840
		Public Sub fillBankAc()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BankAc) FROM Contra", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox3.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox3.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600256D RID: 9581 RVA: 0x0017A774 File Offset: 0x00178974
		Public Sub Getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(ConID),RTRIM(Type),RTRIM(BankAc),RTRIM(BenfName),Amount from Contra where ConID=N'" + Me.ComboBox2.Text + "' order by ID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600256E RID: 9582 RVA: 0x0017A8D8 File Offset: 0x00178AD8
		Public Sub Getdata2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(ConID),RTRIM(Type),RTRIM(BankAc),RTRIM(BenfName),Amount from Contra where BankAc=N'" + Me.ComboBox3.Text + "' order by ID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600256F RID: 9583 RVA: 0x0017AA3C File Offset: 0x00178C3C
		Public Sub Getdata3()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(ConID),RTRIM(Type),RTRIM(BankAc),RTRIM(BenfName),Amount from Contra where Type=N'" + Me.ComboBox1.Text + "' order by ID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002570 RID: 9584 RVA: 0x0001921F File Offset: 0x0001741F
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata1()
		End Sub

		' Token: 0x06002571 RID: 9585 RVA: 0x00019229 File Offset: 0x00017429
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata2()
		End Sub

		' Token: 0x06002572 RID: 9586 RVA: 0x00019233 File Offset: 0x00017433
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata3()
		End Sub

		' Token: 0x06002573 RID: 9587 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06002574 RID: 9588 RVA: 0x0017ABA0 File Offset: 0x00178DA0
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))
						End If

				Next
				Me.Label10.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.Label10.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label10.Text), 2), "0.00")
		End Sub

		' Token: 0x06002575 RID: 9589 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmContra_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002576 RID: 9590 RVA: 0x0017ACA8 File Offset: 0x00178EA8
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(ConID),RTRIM(Type),RTRIM(BankAc),RTRIM(BenfName),Amount from Contra where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002577 RID: 9591 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002578 RID: 9592 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbTransType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002579 RID: 9593 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600257A RID: 9594 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600257B RID: 9595 RVA: 0x0001923D File Offset: 0x0001743D
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600257C RID: 9596 RVA: 0x0017AE68 File Offset: 0x00179068
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Me.cmbTransType.SelectedIndex = -1
				If flag3 Then
					MessageBox.Show("Please enter type of transaction", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbTransType.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please enter bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbAccountNo.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter beneficiary name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtName.Focus()
						Else
							Dim flag6 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
							If flag6 Then
								MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtAmount.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbTransType.SelectedIndex = 0
								If flag7 Then
									Dim flag8 As Boolean = Conversion.Val(Me.txtAmount.Text) > Conversion.Val(Me.Label9.Text)
									If flag8 Then
										Dim flag9 As Boolean = MessageBox.Show("Transferred amount must be less than or equal to Cash-in-Hand amount." & vbCrLf & "Do you really want to proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
										If Not flag9 Then
											Me.txtAmount.Focus()
											Return
										End If
									End If
								End If
								Dim flag10 As Boolean = Me.cmbTransType.SelectedIndex = 1
								If flag10 Then
									Dim flag11 As Boolean = Conversion.Val(Me.txtAmount.Text) > Conversion.Val(Me.Label17.Text)
									If flag11 Then
										Dim flag12 As Boolean = MessageBox.Show("Transferred amount must be less than or equal to Bank Balance." & vbCrLf & "Do you really want to proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
										If Not flag12 Then
											Me.txtAmount.Focus()
											Return
										End If
									End If
								End If
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "update Contra set Date=@d1,ConID=@d2,Type=@d3,BankAc=@d4,BenfName=@d5,Amount=@d6 where ID=@d0"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtContraID.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbTransType.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbAccountNo.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtName.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, "updated the contra voucher having transaction id : '" + Me.txtContraID.Text + "'")
									Dim flag13 As Boolean = Me.cmbTransType.SelectedIndex = 0
									If flag13 Then
										ModFunc.LedgerDelete(Me.txtContraID.Text, "Contra")
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Contra", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Contra", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.BankAccountLedgerUpdate(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtContraID.Text, "Contra")
									End If
									Dim flag14 As Boolean = Me.cmbTransType.SelectedIndex = 1
									If flag14 Then
										ModFunc.LedgerDelete(Me.txtContraID.Text, "Contra")
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Contra", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Contra", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.BankAccountLedgerUpdate(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtContraID.Text, "Contra")
									End If
									MessageBox.Show("Successfully Updated", "Contra Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.Reset()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600257D RID: 9597 RVA: 0x0017B558 File Offset: 0x00179758
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

		' Token: 0x0600257E RID: 9598 RVA: 0x0017B5C0 File Offset: 0x001797C0
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
				Me.auto()
				Dim flag3 As Boolean = Me.cmbTransType.SelectedIndex = -1
				If flag3 Then
					MessageBox.Show("Please enter type of transaction", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbTransType.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please enter bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbAccountNo.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter beneficiary name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtName.Focus()
						Else
							Dim flag6 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
							If flag6 Then
								MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtAmount.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbTransType.SelectedIndex = 0
								If flag7 Then
									Dim flag8 As Boolean = Conversion.Val(Me.txtAmount.Text) > Conversion.Val(Me.Label9.Text)
									If flag8 Then
										Dim flag9 As Boolean = MessageBox.Show("Transferred amount must be less than or equal to Cash-in-Hand amount." & vbCrLf & "Do you really want to proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
										If Not flag9 Then
											Me.txtAmount.Focus()
											Return
										End If
									End If
								End If
								Dim flag10 As Boolean = Me.cmbTransType.SelectedIndex = 1
								If flag10 Then
									Dim flag11 As Boolean = Conversion.Val(Me.txtAmount.Text) > Conversion.Val(Me.Label17.Text)
									If flag11 Then
										Dim flag12 As Boolean = MessageBox.Show("Transferred amount must be less than or equal to Bank Balance." & vbCrLf & "Do you really want to proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
										If Not flag12 Then
											Me.txtAmount.Focus()
											Return
										End If
									End If
								End If
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "insert into Contra(ID, Date, ConID, Type, BankAc, BenfName, Amount) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtContraID.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbTransType.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbAccountNo.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtName.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtAmount.Text))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModFunc.LogFunc(Me.lblUser.Text, "added the new contra voucher having transaction id : '" + Me.txtContraID.Text + "'")
									Dim flag13 As Boolean = Me.cmbTransType.SelectedIndex = 0
									If flag13 Then
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Contra", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Contra", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Contra", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
									End If
									Dim flag14 As Boolean = Me.cmbTransType.SelectedIndex = 1
									If flag14 Then
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Contra", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Contra", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtName.Text)
										ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Contra", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
									End If
									MessageBox.Show("Successfully Saved", "Contra Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									ModCommonClasses.con.Close()
									Me.Reset()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600257F RID: 9599 RVA: 0x0017BC8C File Offset: 0x00179E8C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
