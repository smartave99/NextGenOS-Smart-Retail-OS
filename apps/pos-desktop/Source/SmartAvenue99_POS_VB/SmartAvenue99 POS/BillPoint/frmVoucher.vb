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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005C0 RID: 1472
	<DesignerGenerated()>
	Public Partial Class frmVoucher
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011E89 RID: 73353 RVA: 0x00A51E40 File Offset: 0x00A50040
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmVoucher_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmVoucher_KeyDown
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006F41 RID: 28481
		' (get) Token: 0x06011E8C RID: 73356 RVA: 0x0007ADDB File Offset: 0x00078FDB
		' (set) Token: 0x06011E8D RID: 73357 RVA: 0x0007ADE5 File Offset: 0x00078FE5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006F42 RID: 28482
		' (get) Token: 0x06011E8E RID: 73358 RVA: 0x0007ADEE File Offset: 0x00078FEE
		' (set) Token: 0x06011E8F RID: 73359 RVA: 0x0007ADF8 File Offset: 0x00078FF8
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006F43 RID: 28483
		' (get) Token: 0x06011E90 RID: 73360 RVA: 0x0007AE01 File Offset: 0x00079001
		' (set) Token: 0x06011E91 RID: 73361 RVA: 0x0007AE0B File Offset: 0x0007900B
		Friend Overridable Property Label1 As Label

		' Token: 0x17006F44 RID: 28484
		' (get) Token: 0x06011E92 RID: 73362 RVA: 0x0007AE14 File Offset: 0x00079014
		' (set) Token: 0x06011E93 RID: 73363 RVA: 0x0007AE1E File Offset: 0x0007901E
		Friend Overridable Property txtVoucherID As TextBox

		' Token: 0x17006F45 RID: 28485
		' (get) Token: 0x06011E94 RID: 73364 RVA: 0x0007AE27 File Offset: 0x00079027
		' (set) Token: 0x06011E95 RID: 73365 RVA: 0x0007AE31 File Offset: 0x00079031
		Friend Overridable Property lblUser As Label

		' Token: 0x17006F46 RID: 28486
		' (get) Token: 0x06011E96 RID: 73366 RVA: 0x0007AE3A File Offset: 0x0007903A
		' (set) Token: 0x06011E97 RID: 73367 RVA: 0x0007AE44 File Offset: 0x00079044
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006F47 RID: 28487
		' (get) Token: 0x06011E98 RID: 73368 RVA: 0x0007AE4D File Offset: 0x0007904D
		' (set) Token: 0x06011E99 RID: 73369 RVA: 0x0007AE57 File Offset: 0x00079057
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006F48 RID: 28488
		' (get) Token: 0x06011E9A RID: 73370 RVA: 0x0007AE60 File Offset: 0x00079060
		' (set) Token: 0x06011E9B RID: 73371 RVA: 0x0007AE6A File Offset: 0x0007906A
		Friend Overridable Property Label8 As Label

		' Token: 0x17006F49 RID: 28489
		' (get) Token: 0x06011E9C RID: 73372 RVA: 0x0007AE73 File Offset: 0x00079073
		' (set) Token: 0x06011E9D RID: 73373 RVA: 0x0007AE7D File Offset: 0x0007907D
		Friend Overridable Property Label11 As Label

		' Token: 0x17006F4A RID: 28490
		' (get) Token: 0x06011E9E RID: 73374 RVA: 0x0007AE86 File Offset: 0x00079086
		' (set) Token: 0x06011E9F RID: 73375 RVA: 0x00A550E8 File Offset: 0x00A532E8
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
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

		' Token: 0x17006F4B RID: 28491
		' (get) Token: 0x06011EA0 RID: 73376 RVA: 0x0007AE90 File Offset: 0x00079090
		' (set) Token: 0x06011EA1 RID: 73377 RVA: 0x0007AE9A File Offset: 0x0007909A
		Friend Overridable Property Label12 As Label

		' Token: 0x17006F4C RID: 28492
		' (get) Token: 0x06011EA2 RID: 73378 RVA: 0x0007AEA3 File Offset: 0x000790A3
		' (set) Token: 0x06011EA3 RID: 73379 RVA: 0x00A5512C File Offset: 0x00A5332C
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
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F4D RID: 28493
		' (get) Token: 0x06011EA4 RID: 73380 RVA: 0x0007AEAD File Offset: 0x000790AD
		' (set) Token: 0x06011EA5 RID: 73381 RVA: 0x0007AEB7 File Offset: 0x000790B7
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17006F4E RID: 28494
		' (get) Token: 0x06011EA6 RID: 73382 RVA: 0x0007AEC0 File Offset: 0x000790C0
		' (set) Token: 0x06011EA7 RID: 73383 RVA: 0x00A551A8 File Offset: 0x00A533A8
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F4F RID: 28495
		' (get) Token: 0x06011EA8 RID: 73384 RVA: 0x0007AECA File Offset: 0x000790CA
		' (set) Token: 0x06011EA9 RID: 73385 RVA: 0x0007AED4 File Offset: 0x000790D4
		Friend Overridable Property txtVoucherNo As TextBox

		' Token: 0x17006F50 RID: 28496
		' (get) Token: 0x06011EAA RID: 73386 RVA: 0x0007AEDD File Offset: 0x000790DD
		' (set) Token: 0x06011EAB RID: 73387 RVA: 0x0007AEE7 File Offset: 0x000790E7
		Friend Overridable Property Label2 As Label

		' Token: 0x17006F51 RID: 28497
		' (get) Token: 0x06011EAC RID: 73388 RVA: 0x0007AEF0 File Offset: 0x000790F0
		' (set) Token: 0x06011EAD RID: 73389 RVA: 0x0007AEFA File Offset: 0x000790FA
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006F52 RID: 28498
		' (get) Token: 0x06011EAE RID: 73390 RVA: 0x0007AF03 File Offset: 0x00079103
		' (set) Token: 0x06011EAF RID: 73391 RVA: 0x0007AF0D File Offset: 0x0007910D
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x17006F53 RID: 28499
		' (get) Token: 0x06011EB0 RID: 73392 RVA: 0x0007AF16 File Offset: 0x00079116
		' (set) Token: 0x06011EB1 RID: 73393 RVA: 0x0007AF20 File Offset: 0x00079120
		Friend Overridable Property Label31 As Label

		' Token: 0x17006F54 RID: 28500
		' (get) Token: 0x06011EB2 RID: 73394 RVA: 0x0007AF29 File Offset: 0x00079129
		' (set) Token: 0x06011EB3 RID: 73395 RVA: 0x00A55208 File Offset: 0x00A53408
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

		' Token: 0x17006F55 RID: 28501
		' (get) Token: 0x06011EB4 RID: 73396 RVA: 0x0007AF33 File Offset: 0x00079133
		' (set) Token: 0x06011EB5 RID: 73397 RVA: 0x00A55268 File Offset: 0x00A53468
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

		' Token: 0x17006F56 RID: 28502
		' (get) Token: 0x06011EB6 RID: 73398 RVA: 0x0007AF3D File Offset: 0x0007913D
		' (set) Token: 0x06011EB7 RID: 73399 RVA: 0x0007AF47 File Offset: 0x00079147
		Friend Overridable Property Button1 As Button

		' Token: 0x17006F57 RID: 28503
		' (get) Token: 0x06011EB8 RID: 73400 RVA: 0x0007AF50 File Offset: 0x00079150
		' (set) Token: 0x06011EB9 RID: 73401 RVA: 0x0007AF5A File Offset: 0x0007915A
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17006F58 RID: 28504
		' (get) Token: 0x06011EBA RID: 73402 RVA: 0x0007AF63 File Offset: 0x00079163
		' (set) Token: 0x06011EBB RID: 73403 RVA: 0x00A552AC File Offset: 0x00A534AC
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

		' Token: 0x17006F59 RID: 28505
		' (get) Token: 0x06011EBC RID: 73404 RVA: 0x0007AF6D File Offset: 0x0007916D
		' (set) Token: 0x06011EBD RID: 73405 RVA: 0x0007AF77 File Offset: 0x00079177
		Friend Overridable Property Label3 As Label

		' Token: 0x17006F5A RID: 28506
		' (get) Token: 0x06011EBE RID: 73406 RVA: 0x0007AF80 File Offset: 0x00079180
		' (set) Token: 0x06011EBF RID: 73407 RVA: 0x00A552F0 File Offset: 0x00A534F0
		Private _txtDetails As TextBox
		Friend Overridable Property txtDetails As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDetails
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDetails_KeyDown
				Dim textBox As TextBox = Me._txtDetails
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDetails = value
				textBox = Me._txtDetails
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F5B RID: 28507
		' (get) Token: 0x06011EC0 RID: 73408 RVA: 0x0007AF8A File Offset: 0x0007918A
		' (set) Token: 0x06011EC1 RID: 73409 RVA: 0x00A55334 File Offset: 0x00A53534
		Private _txtNotes As TextBox
		Friend Overridable Property txtNotes As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNotes
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNotes_KeyDown
				Dim textBox As TextBox = Me._txtNotes
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNotes = value
				textBox = Me._txtNotes
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F5C RID: 28508
		' (get) Token: 0x06011EC2 RID: 73410 RVA: 0x0007AF94 File Offset: 0x00079194
		' (set) Token: 0x06011EC3 RID: 73411 RVA: 0x00A55378 File Offset: 0x00A53578
		Private _cmbtxtName As ComboBox
		Friend Overridable Property cmbtxtName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbtxtName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbtxtName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbtxtName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbtxtName = value
				comboBox = Me._cmbtxtName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F5D RID: 28509
		' (get) Token: 0x06011EC4 RID: 73412 RVA: 0x0007AF9E File Offset: 0x0007919E
		' (set) Token: 0x06011EC5 RID: 73413 RVA: 0x00A553D8 File Offset: 0x00A535D8
		Private _cmbParticulars As ComboBox
		Friend Overridable Property cmbParticulars As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbParticulars
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbParticulars_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbParticulars_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbParticulars
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbParticulars = value
				comboBox = Me._cmbParticulars
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F5E RID: 28510
		' (get) Token: 0x06011EC6 RID: 73414 RVA: 0x0007AFA8 File Offset: 0x000791A8
		' (set) Token: 0x06011EC7 RID: 73415 RVA: 0x0007AFB2 File Offset: 0x000791B2
		Friend Overridable Property Label6 As Label

		' Token: 0x17006F5F RID: 28511
		' (get) Token: 0x06011EC8 RID: 73416 RVA: 0x0007AFBB File Offset: 0x000791BB
		' (set) Token: 0x06011EC9 RID: 73417 RVA: 0x0007AFC5 File Offset: 0x000791C5
		Friend Overridable Property Label9 As Label

		' Token: 0x17006F60 RID: 28512
		' (get) Token: 0x06011ECA RID: 73418 RVA: 0x0007AFCE File Offset: 0x000791CE
		' (set) Token: 0x06011ECB RID: 73419 RVA: 0x0007AFD8 File Offset: 0x000791D8
		Friend Overridable Property Label7 As Label

		' Token: 0x17006F61 RID: 28513
		' (get) Token: 0x06011ECC RID: 73420 RVA: 0x0007AFE1 File Offset: 0x000791E1
		' (set) Token: 0x06011ECD RID: 73421 RVA: 0x0007AFEB File Offset: 0x000791EB
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17006F62 RID: 28514
		' (get) Token: 0x06011ECE RID: 73422 RVA: 0x0007AFF4 File Offset: 0x000791F4
		' (set) Token: 0x06011ECF RID: 73423 RVA: 0x0007AFFE File Offset: 0x000791FE
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17006F63 RID: 28515
		' (get) Token: 0x06011ED0 RID: 73424 RVA: 0x0007B007 File Offset: 0x00079207
		' (set) Token: 0x06011ED1 RID: 73425 RVA: 0x0007B011 File Offset: 0x00079211
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17006F64 RID: 28516
		' (get) Token: 0x06011ED2 RID: 73426 RVA: 0x0007B01A File Offset: 0x0007921A
		' (set) Token: 0x06011ED3 RID: 73427 RVA: 0x0007B024 File Offset: 0x00079224
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17006F65 RID: 28517
		' (get) Token: 0x06011ED4 RID: 73428 RVA: 0x0007B02D File Offset: 0x0007922D
		' (set) Token: 0x06011ED5 RID: 73429 RVA: 0x0007B037 File Offset: 0x00079237
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006F66 RID: 28518
		' (get) Token: 0x06011ED6 RID: 73430 RVA: 0x0007B040 File Offset: 0x00079240
		' (set) Token: 0x06011ED7 RID: 73431 RVA: 0x0007B04A File Offset: 0x0007924A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006F67 RID: 28519
		' (get) Token: 0x06011ED8 RID: 73432 RVA: 0x0007B053 File Offset: 0x00079253
		' (set) Token: 0x06011ED9 RID: 73433 RVA: 0x0007B05D File Offset: 0x0007925D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006F68 RID: 28520
		' (get) Token: 0x06011EDA RID: 73434 RVA: 0x0007B066 File Offset: 0x00079266
		' (set) Token: 0x06011EDB RID: 73435 RVA: 0x0007B070 File Offset: 0x00079270
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006F69 RID: 28521
		' (get) Token: 0x06011EDC RID: 73436 RVA: 0x0007B079 File Offset: 0x00079279
		' (set) Token: 0x06011EDD RID: 73437 RVA: 0x00A55454 File Offset: 0x00A53654
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

		' Token: 0x17006F6A RID: 28522
		' (get) Token: 0x06011EDE RID: 73438 RVA: 0x0007B083 File Offset: 0x00079283
		' (set) Token: 0x06011EDF RID: 73439 RVA: 0x00A55498 File Offset: 0x00A53698
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

		' Token: 0x17006F6B RID: 28523
		' (get) Token: 0x06011EE0 RID: 73440 RVA: 0x0007B08D File Offset: 0x0007928D
		' (set) Token: 0x06011EE1 RID: 73441 RVA: 0x00A554DC File Offset: 0x00A536DC
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

		' Token: 0x17006F6C RID: 28524
		' (get) Token: 0x06011EE2 RID: 73442 RVA: 0x0007B097 File Offset: 0x00079297
		' (set) Token: 0x06011EE3 RID: 73443 RVA: 0x00A55520 File Offset: 0x00A53720
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

		' Token: 0x17006F6D RID: 28525
		' (get) Token: 0x06011EE4 RID: 73444 RVA: 0x0007B0A1 File Offset: 0x000792A1
		' (set) Token: 0x06011EE5 RID: 73445 RVA: 0x00A55564 File Offset: 0x00A53764
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

		' Token: 0x17006F6E RID: 28526
		' (get) Token: 0x06011EE6 RID: 73446 RVA: 0x0007B0AB File Offset: 0x000792AB
		' (set) Token: 0x06011EE7 RID: 73447 RVA: 0x00A555A8 File Offset: 0x00A537A8
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

		' Token: 0x17006F6F RID: 28527
		' (get) Token: 0x06011EE8 RID: 73448 RVA: 0x0007B0B5 File Offset: 0x000792B5
		' (set) Token: 0x06011EE9 RID: 73449 RVA: 0x0007B0BF File Offset: 0x000792BF
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17006F70 RID: 28528
		' (get) Token: 0x06011EEA RID: 73450 RVA: 0x0007B0C8 File Offset: 0x000792C8
		' (set) Token: 0x06011EEB RID: 73451 RVA: 0x00A555EC File Offset: 0x00A537EC
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

		' Token: 0x17006F71 RID: 28529
		' (get) Token: 0x06011EEC RID: 73452 RVA: 0x0007B0D2 File Offset: 0x000792D2
		' (set) Token: 0x06011EED RID: 73453 RVA: 0x0007B0DC File Offset: 0x000792DC
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006F72 RID: 28530
		' (get) Token: 0x06011EEE RID: 73454 RVA: 0x0007B0E5 File Offset: 0x000792E5
		' (set) Token: 0x06011EEF RID: 73455 RVA: 0x0007B0EF File Offset: 0x000792EF
		Friend Overridable Property F2 As TextBox

		' Token: 0x17006F73 RID: 28531
		' (get) Token: 0x06011EF0 RID: 73456 RVA: 0x0007B0F8 File Offset: 0x000792F8
		' (set) Token: 0x06011EF1 RID: 73457 RVA: 0x0007B102 File Offset: 0x00079302
		Friend Overridable Property F1 As TextBox

		' Token: 0x17006F74 RID: 28532
		' (get) Token: 0x06011EF2 RID: 73458 RVA: 0x0007B10B File Offset: 0x0007930B
		' (set) Token: 0x06011EF3 RID: 73459 RVA: 0x00A55630 File Offset: 0x00A53830
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F75 RID: 28533
		' (get) Token: 0x06011EF4 RID: 73460 RVA: 0x0007B115 File Offset: 0x00079315
		' (set) Token: 0x06011EF5 RID: 73461 RVA: 0x0007B11F File Offset: 0x0007931F
		Friend Overridable Property Label4 As Label

		' Token: 0x17006F76 RID: 28534
		' (get) Token: 0x06011EF6 RID: 73462 RVA: 0x0007B128 File Offset: 0x00079328
		' (set) Token: 0x06011EF7 RID: 73463 RVA: 0x0007B132 File Offset: 0x00079332
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006F77 RID: 28535
		' (get) Token: 0x06011EF8 RID: 73464 RVA: 0x0007B13B File Offset: 0x0007933B
		' (set) Token: 0x06011EF9 RID: 73465 RVA: 0x0007B145 File Offset: 0x00079345
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17006F78 RID: 28536
		' (get) Token: 0x06011EFA RID: 73466 RVA: 0x0007B14E File Offset: 0x0007934E
		' (set) Token: 0x06011EFB RID: 73467 RVA: 0x0007B158 File Offset: 0x00079358
		Friend Overridable Property Label74 As Label

		' Token: 0x17006F79 RID: 28537
		' (get) Token: 0x06011EFC RID: 73468 RVA: 0x0007B161 File Offset: 0x00079361
		' (set) Token: 0x06011EFD RID: 73469 RVA: 0x00A55690 File Offset: 0x00A53890
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F7A RID: 28538
		' (get) Token: 0x06011EFE RID: 73470 RVA: 0x0007B16B File Offset: 0x0007936B
		' (set) Token: 0x06011EFF RID: 73471 RVA: 0x00A556D4 File Offset: 0x00A538D4
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

		' Token: 0x17006F7B RID: 28539
		' (get) Token: 0x06011F00 RID: 73472 RVA: 0x0007B175 File Offset: 0x00079375
		' (set) Token: 0x06011F01 RID: 73473 RVA: 0x00A55718 File Offset: 0x00A53918
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

		' Token: 0x17006F7C RID: 28540
		' (get) Token: 0x06011F02 RID: 73474 RVA: 0x0007B17F File Offset: 0x0007937F
		' (set) Token: 0x06011F03 RID: 73475 RVA: 0x00A5575C File Offset: 0x00A5395C
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

		' Token: 0x17006F7D RID: 28541
		' (get) Token: 0x06011F04 RID: 73476 RVA: 0x0007B189 File Offset: 0x00079389
		' (set) Token: 0x06011F05 RID: 73477 RVA: 0x00A557A0 File Offset: 0x00A539A0
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

		' Token: 0x17006F7E RID: 28542
		' (get) Token: 0x06011F06 RID: 73478 RVA: 0x0007B193 File Offset: 0x00079393
		' (set) Token: 0x06011F07 RID: 73479 RVA: 0x00A557E4 File Offset: 0x00A539E4
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

		' Token: 0x17006F7F RID: 28543
		' (get) Token: 0x06011F08 RID: 73480 RVA: 0x0007B19D File Offset: 0x0007939D
		' (set) Token: 0x06011F09 RID: 73481 RVA: 0x00A55828 File Offset: 0x00A53A28
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

		' Token: 0x06011F0A RID: 73482 RVA: 0x00A5586C File Offset: 0x00A53A6C
		Public Sub Reset()
			Me.txtVoucherID.Text = ""
			Me.cmbtxtName.Text = ""
			Me.cmbtxtName.SelectedIndex = -1
			Me.cmbParticulars.Items.Clear()
			Me.cmbParticulars.Text = ""
			Me.txtDetails.Text = ""
			Me.txtNotes.Text = ""
			Me.txtVoucherNo.Text = ""
			Me.txtAmount.Text = ""
			Me.txtGrandTotal.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.DataGridView1.Rows.Clear()
			Me.btnPrint.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.Clear()
			Me.auto()
			Me.dtpDate.Focus()
			Me.Fillachead()
			Me.fillName()
			Me.cmbNP.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
		End Sub

		' Token: 0x06011F0B RID: 73483 RVA: 0x00A559DC File Offset: 0x00A53BDC
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbParticulars.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter particulars", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbParticulars.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag3 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag3 Then
							Me.DataGridView1.Rows.Add(New Object() { Me.cmbParticulars.Text, Conversion.Val(Me.txtAmount.Text), Me.txtNotes.Text })
							Dim num As Double = Me.GrandTotal()
							num = Math.Round(num, 2)
							Me.txtGrandTotal.Text = Conversions.ToString(num)
							Me.cmbParticulars.Focus()
							Me.cmbParticulars.SelectedIndex = -1
							Me.Clear()
						Else
							Me.DataGridView1.Rows.Add(New Object() { Me.cmbParticulars.Text, Conversion.Val(Me.txtAmount.Text), Me.txtNotes.Text })
							Dim num2 As Double = Me.GrandTotal()
							num2 = Math.Round(num2, 2)
							Me.txtGrandTotal.Text = Conversions.ToString(num2)
							Me.cmbParticulars.SelectedIndex = -1
							Me.Clear()
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
						End If
					End If
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06011F0C RID: 73484 RVA: 0x00A55C2C File Offset: 0x00A53E2C
		Public Sub Clear()
			Me.cmbParticulars.Text = ""
			Me.txtAmount.Text = ""
			Me.txtNotes.Text = ""
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
		End Sub

		' Token: 0x06011F0D RID: 73485 RVA: 0x00A55C88 File Offset: 0x00A53E88
		Public Function GrandTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(1).Value))
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

		' Token: 0x06011F0E RID: 73486 RVA: 0x007A3EEC File Offset: 0x007A20EC
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Voucher ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06011F0F RID: 73487 RVA: 0x00A55D4C File Offset: 0x00A53F4C
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrExpenses ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06011F10 RID: 73488 RVA: 0x00A55EB8 File Offset: 0x00A540B8
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c9),RTRIM(c19) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "EXP"
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
					Me.txtInvCode1.Text = "EXP"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F11 RID: 73489 RVA: 0x00A56090 File Offset: 0x00A54290
		Public Sub auto()
			Try
				Me.txtVoucherID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtVoucherNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F12 RID: 73490 RVA: 0x00A56140 File Offset: 0x00A54340
		Public Sub Print()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptVoucher As rptVoucher = New rptVoucher()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where VoucherNo='" + Me.txtVoucherNo.Text + "'"
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "Voucher")
				sqlDataAdapter.Fill(dataSet, "Voucher_OtherDetails")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptVoucher.SetDataSource(dataSet)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptVoucher
				MyProject.Forms.frmReport.ShowDialog()
				rptVoucher.Close()
				rptVoucher.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F13 RID: 73491 RVA: 0x00A562A8 File Offset: 0x00A544A8
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Voucher where ID=" + Me.txtVoucherID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
				Dim flag2 As Boolean = num > 0
				If flag2 Then
					ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Expenses")
					ModFunc.SrExpensesDelete(Me.txtVoucherNo.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtVoucherNo.Text, "Expenses-Bank")
					Dim text2 As String = "deleted the voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillVoucherID()
					Me.Reset()
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillVoucherID()
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x06011F14 RID: 73492 RVA: 0x0007B1A7 File Offset: 0x000793A7
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Me.btnRemove.Enabled = True
		End Sub

		' Token: 0x06011F15 RID: 73493 RVA: 0x00A56454 File Offset: 0x00A54654
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
				Dim num As Double = Me.GrandTotal()
				num = Math.Round(num, 2)
				Me.txtGrandTotal.Text = Conversions.ToString(num)
				Me.btnRemove.Enabled = False
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F16 RID: 73494 RVA: 0x0007B1B7 File Offset: 0x000793B7
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011F17 RID: 73495 RVA: 0x00A56540 File Offset: 0x00A54740
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

		' Token: 0x06011F18 RID: 73496 RVA: 0x00A56638 File Offset: 0x00A54838
		Private Sub frmVoucher_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.DataforNP()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.Fillachead()
			Me.fillName()
			Me.fillVoucherID()
			Me.fillAccountInfo()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011F19 RID: 73497 RVA: 0x00A56700 File Offset: 0x00A54900
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

		' Token: 0x06011F1A RID: 73498 RVA: 0x00A569A0 File Offset: 0x00A54BA0
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

		' Token: 0x06011F1B RID: 73499 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011F1C RID: 73500 RVA: 0x00A56A6C File Offset: 0x00A54C6C
		Public Sub GetCompanyState()
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
					Me.F1.Text = ModCommonClasses.rdr.GetValue(0).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(9, 2)
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

		' Token: 0x06011F1D RID: 73501 RVA: 0x00A56BD0 File Offset: 0x00A54DD0
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011F1E RID: 73502 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F1F RID: 73503 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbtxtName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F20 RID: 73504 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F21 RID: 73505 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbParticulars_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F22 RID: 73506 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F23 RID: 73507 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F24 RID: 73508 RVA: 0x00A56C7C File Offset: 0x00A54E7C
		Public Sub Fillachead()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(a1) from AccountHead where a3 IN ('Exp','Tax') order by a1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbParticulars.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbParticulars.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F25 RID: 73509 RVA: 0x00A56D80 File Offset: 0x00A54F80
		Public Sub fillName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Voucher", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbtxtName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbtxtName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011F26 RID: 73510 RVA: 0x00A56EB4 File Offset: 0x00A550B4
		Private Sub cmbParticulars_SelectedIndexChanged(sender As Object, e As EventArgs)
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
					Try
						Me.txtNotes.Text = ""
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
						ModCommonClasses.cmd.CommandText = "SELECT RTRIM(a2) from AccountHead where a3 IN ('Exp','Tax') and a1=@d1 order by a1"
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbParticulars.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							Me.txtNotes.Text = ModCommonClasses.rdr.GetValue(0).ToString()
						End If
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag5 Then
							ModCommonClasses.con.Close()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x06011F27 RID: 73511 RVA: 0x00A570A0 File Offset: 0x00A552A0
		Public Sub fillVoucherID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(ID) FROM Voucher order by ID ASC", ModCommonClasses.con)
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

		' Token: 0x06011F28 RID: 73512 RVA: 0x00A571DC File Offset: 0x00A553DC
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Voucher.Id) as [Voucher ID], RTRIM(VoucherNo) as [Voucher No.],Convert(DateTime,Date,103) as [Voucher Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Voucher.GrandTotal) as [Grand Total], RTRIM(PMode),RTRIM(Voucher.BankAcNumber) as [Bank A/c No] from Voucher where Voucher.ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtVoucherID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtVoucherNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpDate.Value = Conversions.ToDate(ModCommonClasses.rdr.GetValue(2).ToString())
					Me.cmbtxtName.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtDetails.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.cmbAccountNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
					Me.btnUpdate.Enabled = True
					Me.btnPrint.Enabled = True
					Me.btnRemove.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select RTRIM(Particulars),RTRIM(Amount),RTRIM(Note) from Voucher,Voucher_OtherDetails where Voucher.Id=Voucher_OtherDetails.VoucherID and Voucher.ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011F29 RID: 73513 RVA: 0x0007B1D3 File Offset: 0x000793D3
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06011F2A RID: 73514 RVA: 0x00A574AC File Offset: 0x00A556AC
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Voucher", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Voucher")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Voucher").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06011F2B RID: 73515 RVA: 0x00A57588 File Offset: 0x00A55788
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtVoucherID.Text))
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

		' Token: 0x06011F2C RID: 73516 RVA: 0x00A57644 File Offset: 0x00A55844
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtVoucherID.Text))
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

		' Token: 0x06011F2D RID: 73517 RVA: 0x00A576F0 File Offset: 0x00A558F0
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Voucher").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Voucher").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011F2E RID: 73518 RVA: 0x00A577A8 File Offset: 0x00A559A8
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Voucher").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011F2F RID: 73519 RVA: 0x00A57840 File Offset: 0x00A55A40
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column2").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column1").Value.ToString()
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { Me.a1 + " " + Me.txtRsToWords.Text }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011F30 RID: 73520 RVA: 0x00A57988 File Offset: 0x00A55B88
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x06011F31 RID: 73521 RVA: 0x00A579CC File Offset: 0x00A55BCC
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06011F32 RID: 73522 RVA: 0x00A57A1C File Offset: 0x00A55C1C
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

		' Token: 0x06011F33 RID: 73523 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F34 RID: 73524 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmVoucher_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011F35 RID: 73525 RVA: 0x00A57B04 File Offset: 0x00A55D04
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

		' Token: 0x06011F36 RID: 73526 RVA: 0x00A57BFC File Offset: 0x00A55DFC
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Voucher order by Id DESC"
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
					Me.dtpDate.Value = Me.prevdate
				Else
					Me.dtpDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F37 RID: 73527 RVA: 0x00A57D3C File Offset: 0x00A55F3C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbtxtName.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbtxtName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbtxtName, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbParticulars.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbParticulars, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbParticulars, String.Empty)
			End If
		End Sub

		' Token: 0x06011F38 RID: 73528 RVA: 0x00A57E30 File Offset: 0x00A56030
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 1
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x06011F39 RID: 73529 RVA: 0x00A57E7C File Offset: 0x00A5607C
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

		' Token: 0x06011F3A RID: 73530 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011F3B RID: 73531 RVA: 0x0007B1EB File Offset: 0x000793EB
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub

		' Token: 0x06011F3C RID: 73532 RVA: 0x00A57FA4 File Offset: 0x00A561A4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Voucher where Date between @d1 and @d2 having count(*) >= 5"
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
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
			If flag4 Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Try
					Dim flag6 As Boolean = Operators.CompareString(Me.cmbtxtName.Text, "", False) = 0
					If flag6 Then
						MessageBox.Show("Please enter voucher name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbtxtName.Focus()
					Else
						Dim flag7 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag7 Then
							MessageBox.Show("sorry no data added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = -1
							If flag8 Then
								MessageBox.Show("Please enter Payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ComboBox1.Focus()
							Else
								Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag9 Then
									Dim flag10 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
									If flag10 Then
										MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbAccountNo.Focus()
										Return
									End If
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Voucher(Id, VoucherNo, Date,Name,Details,GrandTotal,PMode,BankAcNumber) Values (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVoucherID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbtxtName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtDetails.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtGrandTotal.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "insert into Voucher_OtherDetails(VoucherID,Particulars,Amount,Note,Date,PModeD) VALUES (" + Me.txtVoucherID.Text + ",@d1,@d2,@d3,@d4,@d5)"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim flag11 As Boolean = Not dataGridViewRow.IsNewRow
										If flag11 Then
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
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
								Dim text5 As String = "insert into SrExpenses(ID, InvNo) Values (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								Me.DataforNP()
								Dim text6 As String = "added the new voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
								ModFunc.LogFunc(Me.lblUser.Text, text6)
								Dim flag12 As Boolean = Me.ComboBox1.SelectedIndex = 0
								If flag12 Then
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
								End If
								Dim flag13 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag13 Then
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
								End If
								Dim flag14 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag14 Then
									ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtVoucherNo.Text, "Expenses-Bank", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D)
								End If
								Me.btnSave.Enabled = False
								Dim flag15 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print the Expenses Voucher ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
								If flag15 Then
									Me.Print()
								End If
								Me.fillVoucherID()
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06011F3D RID: 73533 RVA: 0x00A58950 File Offset: 0x00A56B50
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbtxtName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter voucher name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbtxtName.Focus()
				Else
					Dim flag2 As Boolean = Me.DataGridView1.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("sorry no data added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please enter Payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ComboBox1.Focus()
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag4 Then
								Dim flag5 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
								If flag5 Then
									MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAccountNo.Focus()
									Return
								End If
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "Update Voucher set VoucherNo=@d2, Date=@d3,Name=@d4,Details=@d5,GrandTotal=@d7,PMode=@d8,BankAcNumber=@d9 where ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbtxtName.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtDetails.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVoucherID.Text))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "delete from Voucher_OtherDetails where VoucherID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtVoucherID.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Voucher_OtherDetails(VoucherID,Particulars,Amount,Note,Date,PModeD) VALUES (" + Me.txtVoucherID.Text + ",@d1,@d2,@d3,@d4,@d5)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag6 As Boolean = Not dataGridViewRow.IsNewRow
									If flag6 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
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
							Dim text4 As String = "updated the voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text4)
							Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 0
							If flag7 Then
								ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Expenses")
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
							End If
							Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag8 Then
								ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Expenses")
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
							End If
							ModFunc.BankAccountLedgerDelete(Me.txtVoucherNo.Text, "Expenses-Bank")
							Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag9 Then
								ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtVoucherNo.Text, "Expenses-Bank", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D)
							End If
							Me.btnUpdate.Enabled = False
							MessageBox.Show("Successfully Updated", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011F3E RID: 73534 RVA: 0x00A590F4 File Offset: 0x00A572F4
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

		' Token: 0x06011F3F RID: 73535 RVA: 0x00A5915C File Offset: 0x00A5735C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmVoucherRecord.Reset()
			MyProject.Forms.frmVoucherRecord.Label3.Text = "VR"
			MyProject.Forms.frmVoucherRecord.ShowDialog()
			MyProject.Forms.frmVoucherRecord.Dispose()
		End Sub

		' Token: 0x06011F40 RID: 73536 RVA: 0x0007B1FC File Offset: 0x000793FC
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x04006BE3 RID: 27619
		Private ntid As String

		' Token: 0x04006BE4 RID: 27620
		Private Dad As SqlDataAdapter

		' Token: 0x04006BE5 RID: 27621
		Private Dst As DataSet

		' Token: 0x04006BE6 RID: 27622
		Private CurrentRow As Object

		' Token: 0x04006BE7 RID: 27623
		Private voice As Object

		' Token: 0x04006BE8 RID: 27624
		Private a1 As String

		' Token: 0x04006BE9 RID: 27625
		Private InvDateSts As String

		' Token: 0x04006BEA RID: 27626
		Private prevdate As DateTime
	End Class
End Namespace
