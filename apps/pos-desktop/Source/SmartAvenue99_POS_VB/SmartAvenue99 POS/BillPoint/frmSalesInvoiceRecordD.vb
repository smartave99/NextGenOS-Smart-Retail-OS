Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000207 RID: 519
	<DesignerGenerated()>
	Public Partial Class frmSalesInvoiceRecordD
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060095D3 RID: 38355 RVA: 0x00049503 File Offset: 0x00047703
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170037A2 RID: 14242
		' (get) Token: 0x060095D6 RID: 38358 RVA: 0x00049535 File Offset: 0x00047735
		' (set) Token: 0x060095D7 RID: 38359 RVA: 0x0004953F File Offset: 0x0004773F
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170037A3 RID: 14243
		' (get) Token: 0x060095D8 RID: 38360 RVA: 0x00049548 File Offset: 0x00047748
		' (set) Token: 0x060095D9 RID: 38361 RVA: 0x006C1E68 File Offset: 0x006C0068
		Private _cmbInvoiceNo As ComboBox
		Friend Overridable Property cmbInvoiceNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbInvoiceNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbInvoiceNo_Format
				Dim comboBox As ComboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbInvoiceNo = value
				comboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x170037A4 RID: 14244
		' (get) Token: 0x060095DA RID: 38362 RVA: 0x00049552 File Offset: 0x00047752
		' (set) Token: 0x060095DB RID: 38363 RVA: 0x006C1EC8 File Offset: 0x006C00C8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170037A5 RID: 14245
		' (get) Token: 0x060095DC RID: 38364 RVA: 0x0004955C File Offset: 0x0004775C
		' (set) Token: 0x060095DD RID: 38365 RVA: 0x00049566 File Offset: 0x00047766
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170037A6 RID: 14246
		' (get) Token: 0x060095DE RID: 38366 RVA: 0x0004956F File Offset: 0x0004776F
		' (set) Token: 0x060095DF RID: 38367 RVA: 0x00049579 File Offset: 0x00047779
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170037A7 RID: 14247
		' (get) Token: 0x060095E0 RID: 38368 RVA: 0x00049582 File Offset: 0x00047782
		' (set) Token: 0x060095E1 RID: 38369 RVA: 0x0004958C File Offset: 0x0004778C
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170037A8 RID: 14248
		' (get) Token: 0x060095E2 RID: 38370 RVA: 0x00049595 File Offset: 0x00047795
		' (set) Token: 0x060095E3 RID: 38371 RVA: 0x006C1F44 File Offset: 0x006C0144
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

		' Token: 0x170037A9 RID: 14249
		' (get) Token: 0x060095E4 RID: 38372 RVA: 0x0004959F File Offset: 0x0004779F
		' (set) Token: 0x060095E5 RID: 38373 RVA: 0x000495A9 File Offset: 0x000477A9
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170037AA RID: 14250
		' (get) Token: 0x060095E6 RID: 38374 RVA: 0x000495B2 File Offset: 0x000477B2
		' (set) Token: 0x060095E7 RID: 38375 RVA: 0x000495BC File Offset: 0x000477BC
		Friend Overridable Property Label2 As Label

		' Token: 0x170037AB RID: 14251
		' (get) Token: 0x060095E8 RID: 38376 RVA: 0x000495C5 File Offset: 0x000477C5
		' (set) Token: 0x060095E9 RID: 38377 RVA: 0x000495CF File Offset: 0x000477CF
		Friend Overridable Property Label4 As Label

		' Token: 0x170037AC RID: 14252
		' (get) Token: 0x060095EA RID: 38378 RVA: 0x000495D8 File Offset: 0x000477D8
		' (set) Token: 0x060095EB RID: 38379 RVA: 0x000495E2 File Offset: 0x000477E2
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170037AD RID: 14253
		' (get) Token: 0x060095EC RID: 38380 RVA: 0x000495EB File Offset: 0x000477EB
		' (set) Token: 0x060095ED RID: 38381 RVA: 0x006C1F88 File Offset: 0x006C0188
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

		' Token: 0x170037AE RID: 14254
		' (get) Token: 0x060095EE RID: 38382 RVA: 0x000495F5 File Offset: 0x000477F5
		' (set) Token: 0x060095EF RID: 38383 RVA: 0x006C1FCC File Offset: 0x006C01CC
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

		' Token: 0x170037AF RID: 14255
		' (get) Token: 0x060095F0 RID: 38384 RVA: 0x000495FF File Offset: 0x000477FF
		' (set) Token: 0x060095F1 RID: 38385 RVA: 0x00049609 File Offset: 0x00047809
		Friend Overridable Property Label20 As Label

		' Token: 0x170037B0 RID: 14256
		' (get) Token: 0x060095F2 RID: 38386 RVA: 0x00049612 File Offset: 0x00047812
		' (set) Token: 0x060095F3 RID: 38387 RVA: 0x0004961C File Offset: 0x0004781C
		Friend Overridable Property Label19 As Label

		' Token: 0x170037B1 RID: 14257
		' (get) Token: 0x060095F4 RID: 38388 RVA: 0x00049625 File Offset: 0x00047825
		' (set) Token: 0x060095F5 RID: 38389 RVA: 0x0004962F File Offset: 0x0004782F
		Friend Overridable Property Label18 As Label

		' Token: 0x170037B2 RID: 14258
		' (get) Token: 0x060095F6 RID: 38390 RVA: 0x00049638 File Offset: 0x00047838
		' (set) Token: 0x060095F7 RID: 38391 RVA: 0x00049642 File Offset: 0x00047842
		Friend Overridable Property Label17 As Label

		' Token: 0x170037B3 RID: 14259
		' (get) Token: 0x060095F8 RID: 38392 RVA: 0x0004964B File Offset: 0x0004784B
		' (set) Token: 0x060095F9 RID: 38393 RVA: 0x00049655 File Offset: 0x00047855
		Friend Overridable Property Label16 As Label

		' Token: 0x170037B4 RID: 14260
		' (get) Token: 0x060095FA RID: 38394 RVA: 0x0004965E File Offset: 0x0004785E
		' (set) Token: 0x060095FB RID: 38395 RVA: 0x00049668 File Offset: 0x00047868
		Friend Overridable Property Label15 As Label

		' Token: 0x170037B5 RID: 14261
		' (get) Token: 0x060095FC RID: 38396 RVA: 0x00049671 File Offset: 0x00047871
		' (set) Token: 0x060095FD RID: 38397 RVA: 0x0004967B File Offset: 0x0004787B
		Friend Overridable Property Label14 As Label

		' Token: 0x170037B6 RID: 14262
		' (get) Token: 0x060095FE RID: 38398 RVA: 0x00049684 File Offset: 0x00047884
		' (set) Token: 0x060095FF RID: 38399 RVA: 0x0004968E File Offset: 0x0004788E
		Friend Overridable Property Label13 As Label

		' Token: 0x170037B7 RID: 14263
		' (get) Token: 0x06009600 RID: 38400 RVA: 0x00049697 File Offset: 0x00047897
		' (set) Token: 0x06009601 RID: 38401 RVA: 0x000496A1 File Offset: 0x000478A1
		Friend Overridable Property Label12 As Label

		' Token: 0x170037B8 RID: 14264
		' (get) Token: 0x06009602 RID: 38402 RVA: 0x000496AA File Offset: 0x000478AA
		' (set) Token: 0x06009603 RID: 38403 RVA: 0x000496B4 File Offset: 0x000478B4
		Friend Overridable Property Label9 As Label

		' Token: 0x170037B9 RID: 14265
		' (get) Token: 0x06009604 RID: 38404 RVA: 0x000496BD File Offset: 0x000478BD
		' (set) Token: 0x06009605 RID: 38405 RVA: 0x006C2010 File Offset: 0x006C0210
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

		' Token: 0x170037BA RID: 14266
		' (get) Token: 0x06009606 RID: 38406 RVA: 0x000496C7 File Offset: 0x000478C7
		' (set) Token: 0x06009607 RID: 38407 RVA: 0x000496D1 File Offset: 0x000478D1
		Friend Overridable Property Label8 As Label

		' Token: 0x170037BB RID: 14267
		' (get) Token: 0x06009608 RID: 38408 RVA: 0x000496DA File Offset: 0x000478DA
		' (set) Token: 0x06009609 RID: 38409 RVA: 0x006C2054 File Offset: 0x006C0254
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

		' Token: 0x170037BC RID: 14268
		' (get) Token: 0x0600960A RID: 38410 RVA: 0x000496E4 File Offset: 0x000478E4
		' (set) Token: 0x0600960B RID: 38411 RVA: 0x000496EE File Offset: 0x000478EE
		Friend Overridable Property Label11 As Label

		' Token: 0x170037BD RID: 14269
		' (get) Token: 0x0600960C RID: 38412 RVA: 0x000496F7 File Offset: 0x000478F7
		' (set) Token: 0x0600960D RID: 38413 RVA: 0x00049701 File Offset: 0x00047901
		Friend Overridable Property Label10 As Label

		' Token: 0x170037BE RID: 14270
		' (get) Token: 0x0600960E RID: 38414 RVA: 0x0004970A File Offset: 0x0004790A
		' (set) Token: 0x0600960F RID: 38415 RVA: 0x00049714 File Offset: 0x00047914
		Friend Overridable Property GroupBox9 As GroupBox

		' Token: 0x170037BF RID: 14271
		' (get) Token: 0x06009610 RID: 38416 RVA: 0x0004971D File Offset: 0x0004791D
		' (set) Token: 0x06009611 RID: 38417 RVA: 0x006C2098 File Offset: 0x006C0298
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

		' Token: 0x170037C0 RID: 14272
		' (get) Token: 0x06009612 RID: 38418 RVA: 0x00049727 File Offset: 0x00047927
		' (set) Token: 0x06009613 RID: 38419 RVA: 0x006C20DC File Offset: 0x006C02DC
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

		' Token: 0x170037C1 RID: 14273
		' (get) Token: 0x06009614 RID: 38420 RVA: 0x00049731 File Offset: 0x00047931
		' (set) Token: 0x06009615 RID: 38421 RVA: 0x0004973B File Offset: 0x0004793B
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170037C2 RID: 14274
		' (get) Token: 0x06009616 RID: 38422 RVA: 0x00049744 File Offset: 0x00047944
		' (set) Token: 0x06009617 RID: 38423 RVA: 0x0004974E File Offset: 0x0004794E
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170037C3 RID: 14275
		' (get) Token: 0x06009618 RID: 38424 RVA: 0x00049757 File Offset: 0x00047957
		' (set) Token: 0x06009619 RID: 38425 RVA: 0x00049761 File Offset: 0x00047961
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170037C4 RID: 14276
		' (get) Token: 0x0600961A RID: 38426 RVA: 0x0004976A File Offset: 0x0004796A
		' (set) Token: 0x0600961B RID: 38427 RVA: 0x00049774 File Offset: 0x00047974
		Friend Overridable Property GroupBox8 As GroupBox

		' Token: 0x170037C5 RID: 14277
		' (get) Token: 0x0600961C RID: 38428 RVA: 0x0004977D File Offset: 0x0004797D
		' (set) Token: 0x0600961D RID: 38429 RVA: 0x006C2120 File Offset: 0x006C0320
		Private _txtstate As TextBox
		Friend Overridable Property txtstate As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtstate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtstate_TextChanged
				Dim textBox As TextBox = Me._txtstate
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtstate = value
				textBox = Me._txtstate
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037C6 RID: 14278
		' (get) Token: 0x0600961E RID: 38430 RVA: 0x00049787 File Offset: 0x00047987
		' (set) Token: 0x0600961F RID: 38431 RVA: 0x00049791 File Offset: 0x00047991
		Friend Overridable Property GroupBox7 As GroupBox

		' Token: 0x170037C7 RID: 14279
		' (get) Token: 0x06009620 RID: 38432 RVA: 0x0004979A File Offset: 0x0004799A
		' (set) Token: 0x06009621 RID: 38433 RVA: 0x006C2164 File Offset: 0x006C0364
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037C8 RID: 14280
		' (get) Token: 0x06009622 RID: 38434 RVA: 0x000497A4 File Offset: 0x000479A4
		' (set) Token: 0x06009623 RID: 38435 RVA: 0x000497AE File Offset: 0x000479AE
		Friend Overridable Property Label6 As Label

		' Token: 0x170037C9 RID: 14281
		' (get) Token: 0x06009624 RID: 38436 RVA: 0x000497B7 File Offset: 0x000479B7
		' (set) Token: 0x06009625 RID: 38437 RVA: 0x000497C1 File Offset: 0x000479C1
		Friend Overridable Property Label7 As Label

		' Token: 0x170037CA RID: 14282
		' (get) Token: 0x06009626 RID: 38438 RVA: 0x000497CA File Offset: 0x000479CA
		' (set) Token: 0x06009627 RID: 38439 RVA: 0x000497D4 File Offset: 0x000479D4
		Friend Overridable Property txtSlNo2 As TextBox

		' Token: 0x170037CB RID: 14283
		' (get) Token: 0x06009628 RID: 38440 RVA: 0x000497DD File Offset: 0x000479DD
		' (set) Token: 0x06009629 RID: 38441 RVA: 0x000497E7 File Offset: 0x000479E7
		Friend Overridable Property txtSlNo1 As TextBox

		' Token: 0x170037CC RID: 14284
		' (get) Token: 0x0600962A RID: 38442 RVA: 0x000497F0 File Offset: 0x000479F0
		' (set) Token: 0x0600962B RID: 38443 RVA: 0x000497FA File Offset: 0x000479FA
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x170037CD RID: 14285
		' (get) Token: 0x0600962C RID: 38444 RVA: 0x00049803 File Offset: 0x00047A03
		' (set) Token: 0x0600962D RID: 38445 RVA: 0x006C21A8 File Offset: 0x006C03A8
		Private _txtCustCity As TextBox
		Friend Overridable Property txtCustCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustCity_TextChanged
				Dim textBox As TextBox = Me._txtCustCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustCity = value
				textBox = Me._txtCustCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037CE RID: 14286
		' (get) Token: 0x0600962E RID: 38446 RVA: 0x0004980D File Offset: 0x00047A0D
		' (set) Token: 0x0600962F RID: 38447 RVA: 0x00049817 File Offset: 0x00047A17
		Friend Overridable Property lblSet As Label

		' Token: 0x170037CF RID: 14287
		' (get) Token: 0x06009630 RID: 38448 RVA: 0x00049820 File Offset: 0x00047A20
		' (set) Token: 0x06009631 RID: 38449 RVA: 0x0004982A File Offset: 0x00047A2A
		Friend Overridable Property lblUserType As Label

		' Token: 0x170037D0 RID: 14288
		' (get) Token: 0x06009632 RID: 38450 RVA: 0x00049833 File Offset: 0x00047A33
		' (set) Token: 0x06009633 RID: 38451 RVA: 0x0004983D File Offset: 0x00047A3D
		Friend Overridable Property Label1 As Label

		' Token: 0x170037D1 RID: 14289
		' (get) Token: 0x06009634 RID: 38452 RVA: 0x00049846 File Offset: 0x00047A46
		' (set) Token: 0x06009635 RID: 38453 RVA: 0x00049850 File Offset: 0x00047A50
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x170037D2 RID: 14290
		' (get) Token: 0x06009636 RID: 38454 RVA: 0x00049859 File Offset: 0x00047A59
		' (set) Token: 0x06009637 RID: 38455 RVA: 0x006C21EC File Offset: 0x006C03EC
		Private _txtSalesman As TextBox
		Friend Overridable Property txtSalesman As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalesman
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSalesman_TextChanged
				Dim textBox As TextBox = Me._txtSalesman
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSalesman = value
				textBox = Me._txtSalesman
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037D3 RID: 14291
		' (get) Token: 0x06009638 RID: 38456 RVA: 0x00049863 File Offset: 0x00047A63
		' (set) Token: 0x06009639 RID: 38457 RVA: 0x0004986D File Offset: 0x00047A6D
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170037D4 RID: 14292
		' (get) Token: 0x0600963A RID: 38458 RVA: 0x00049876 File Offset: 0x00047A76
		' (set) Token: 0x0600963B RID: 38459 RVA: 0x006C2230 File Offset: 0x006C0430
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

		' Token: 0x170037D5 RID: 14293
		' (get) Token: 0x0600963C RID: 38460 RVA: 0x00049880 File Offset: 0x00047A80
		' (set) Token: 0x0600963D RID: 38461 RVA: 0x0004988A File Offset: 0x00047A8A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170037D6 RID: 14294
		' (get) Token: 0x0600963E RID: 38462 RVA: 0x00049893 File Offset: 0x00047A93
		' (set) Token: 0x0600963F RID: 38463 RVA: 0x006C2274 File Offset: 0x006C0474
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037D7 RID: 14295
		' (get) Token: 0x06009640 RID: 38464 RVA: 0x0004989D File Offset: 0x00047A9D
		' (set) Token: 0x06009641 RID: 38465 RVA: 0x000498A7 File Offset: 0x00047AA7
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170037D8 RID: 14296
		' (get) Token: 0x06009642 RID: 38466 RVA: 0x000498B0 File Offset: 0x00047AB0
		' (set) Token: 0x06009643 RID: 38467 RVA: 0x000498BA File Offset: 0x00047ABA
		Friend Overridable Property Label3 As Label

		' Token: 0x170037D9 RID: 14297
		' (get) Token: 0x06009644 RID: 38468 RVA: 0x000498C3 File Offset: 0x00047AC3
		' (set) Token: 0x06009645 RID: 38469 RVA: 0x000498CD File Offset: 0x00047ACD
		Friend Overridable Property Label5 As Label

		' Token: 0x170037DA RID: 14298
		' (get) Token: 0x06009646 RID: 38470 RVA: 0x000498D6 File Offset: 0x00047AD6
		' (set) Token: 0x06009647 RID: 38471 RVA: 0x000498E0 File Offset: 0x00047AE0
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170037DB RID: 14299
		' (get) Token: 0x06009648 RID: 38472 RVA: 0x000498E9 File Offset: 0x00047AE9
		' (set) Token: 0x06009649 RID: 38473 RVA: 0x000498F3 File Offset: 0x00047AF3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170037DC RID: 14300
		' (get) Token: 0x0600964A RID: 38474 RVA: 0x000498FC File Offset: 0x00047AFC
		' (set) Token: 0x0600964B RID: 38475 RVA: 0x00049906 File Offset: 0x00047B06
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170037DD RID: 14301
		' (get) Token: 0x0600964C RID: 38476 RVA: 0x0004990F File Offset: 0x00047B0F
		' (set) Token: 0x0600964D RID: 38477 RVA: 0x00049919 File Offset: 0x00047B19
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170037DE RID: 14302
		' (get) Token: 0x0600964E RID: 38478 RVA: 0x00049922 File Offset: 0x00047B22
		' (set) Token: 0x0600964F RID: 38479 RVA: 0x0004992C File Offset: 0x00047B2C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170037DF RID: 14303
		' (get) Token: 0x06009650 RID: 38480 RVA: 0x00049935 File Offset: 0x00047B35
		' (set) Token: 0x06009651 RID: 38481 RVA: 0x0004993F File Offset: 0x00047B3F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170037E0 RID: 14304
		' (get) Token: 0x06009652 RID: 38482 RVA: 0x00049948 File Offset: 0x00047B48
		' (set) Token: 0x06009653 RID: 38483 RVA: 0x00049952 File Offset: 0x00047B52
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170037E1 RID: 14305
		' (get) Token: 0x06009654 RID: 38484 RVA: 0x0004995B File Offset: 0x00047B5B
		' (set) Token: 0x06009655 RID: 38485 RVA: 0x00049965 File Offset: 0x00047B65
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170037E2 RID: 14306
		' (get) Token: 0x06009656 RID: 38486 RVA: 0x0004996E File Offset: 0x00047B6E
		' (set) Token: 0x06009657 RID: 38487 RVA: 0x00049978 File Offset: 0x00047B78
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170037E3 RID: 14307
		' (get) Token: 0x06009658 RID: 38488 RVA: 0x00049981 File Offset: 0x00047B81
		' (set) Token: 0x06009659 RID: 38489 RVA: 0x0004998B File Offset: 0x00047B8B
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170037E4 RID: 14308
		' (get) Token: 0x0600965A RID: 38490 RVA: 0x00049994 File Offset: 0x00047B94
		' (set) Token: 0x0600965B RID: 38491 RVA: 0x0004999E File Offset: 0x00047B9E
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170037E5 RID: 14309
		' (get) Token: 0x0600965C RID: 38492 RVA: 0x000499A7 File Offset: 0x00047BA7
		' (set) Token: 0x0600965D RID: 38493 RVA: 0x000499B1 File Offset: 0x00047BB1
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170037E6 RID: 14310
		' (get) Token: 0x0600965E RID: 38494 RVA: 0x000499BA File Offset: 0x00047BBA
		' (set) Token: 0x0600965F RID: 38495 RVA: 0x000499C4 File Offset: 0x00047BC4
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170037E7 RID: 14311
		' (get) Token: 0x06009660 RID: 38496 RVA: 0x000499CD File Offset: 0x00047BCD
		' (set) Token: 0x06009661 RID: 38497 RVA: 0x000499D7 File Offset: 0x00047BD7
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170037E8 RID: 14312
		' (get) Token: 0x06009662 RID: 38498 RVA: 0x000499E0 File Offset: 0x00047BE0
		' (set) Token: 0x06009663 RID: 38499 RVA: 0x000499EA File Offset: 0x00047BEA
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170037E9 RID: 14313
		' (get) Token: 0x06009664 RID: 38500 RVA: 0x000499F3 File Offset: 0x00047BF3
		' (set) Token: 0x06009665 RID: 38501 RVA: 0x000499FD File Offset: 0x00047BFD
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170037EA RID: 14314
		' (get) Token: 0x06009666 RID: 38502 RVA: 0x00049A06 File Offset: 0x00047C06
		' (set) Token: 0x06009667 RID: 38503 RVA: 0x00049A10 File Offset: 0x00047C10
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170037EB RID: 14315
		' (get) Token: 0x06009668 RID: 38504 RVA: 0x00049A19 File Offset: 0x00047C19
		' (set) Token: 0x06009669 RID: 38505 RVA: 0x00049A23 File Offset: 0x00047C23
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170037EC RID: 14316
		' (get) Token: 0x0600966A RID: 38506 RVA: 0x00049A2C File Offset: 0x00047C2C
		' (set) Token: 0x0600966B RID: 38507 RVA: 0x00049A36 File Offset: 0x00047C36
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170037ED RID: 14317
		' (get) Token: 0x0600966C RID: 38508 RVA: 0x00049A3F File Offset: 0x00047C3F
		' (set) Token: 0x0600966D RID: 38509 RVA: 0x00049A49 File Offset: 0x00047C49
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170037EE RID: 14318
		' (get) Token: 0x0600966E RID: 38510 RVA: 0x00049A52 File Offset: 0x00047C52
		' (set) Token: 0x0600966F RID: 38511 RVA: 0x00049A5C File Offset: 0x00047C5C
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x170037EF RID: 14319
		' (get) Token: 0x06009670 RID: 38512 RVA: 0x00049A65 File Offset: 0x00047C65
		' (set) Token: 0x06009671 RID: 38513 RVA: 0x00049A6F File Offset: 0x00047C6F
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x06009672 RID: 38514 RVA: 0x006C22B8 File Offset: 0x006C04B8
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
					Me.DateTimePicker2.Value = DateAndTime.Today
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

		' Token: 0x06009673 RID: 38515 RVA: 0x006C239C File Offset: 0x006C059C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009674 RID: 38516 RVA: 0x006C2654 File Offset: 0x006C0854
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(UserID) from Registration Order by UserID"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.ComboBox3.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox3.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009675 RID: 38517 RVA: 0x006C2728 File Offset: 0x006C0928
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.FillUserID()
			Me.cmbInvoiceNo.SelectedIndex = -1
			Me.txtCustomerName.Text = ""
			Me.txtSalesman.Text = ""
			Me.txtCustCity.Text = ""
			Me.txtSlNo1.Text = ""
			Me.txtSlNo2.Text = ""
			Me.txtstate.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06009676 RID: 38518 RVA: 0x006C2854 File Offset: 0x006C0A54
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06009677 RID: 38519 RVA: 0x00049A78 File Offset: 0x00047C78
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06009678 RID: 38520 RVA: 0x006C287C File Offset: 0x006C0A7C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Touch Sales Invoice", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSTouch.txtInvoiceNoD.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSTouch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "SELECT ProductID,Qty,MainUnit,SalesRate, DiscountPer, Discount, TotalAmount,TotalMRP from InvoiceInfoD,Invoice_ProductD  where InvoiceInfoD.InvoiceNo=Invoice_ProductD.InvoiceID and InvoiceInfoD.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSTouch.DataGridView4.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSTouch.DataGridView4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPOSTouch.GelButton6.Enabled = True
						MyProject.Forms.frmPOSTouch.GridCalcD()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009679 RID: 38521 RVA: 0x006C2AF8 File Offset: 0x006C0CF8
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

		' Token: 0x0600967A RID: 38522 RVA: 0x006C2BE0 File Offset: 0x006C0DE0
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfoD", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbInvoiceNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbInvoiceNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600967B RID: 38523 RVA: 0x006C2D14 File Offset: 0x006C0F14
		Public Sub Reset()
			Me.cmbInvoiceNo.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtSalesman.Text = ""
			Me.txtCustCity.Text = ""
			Me.txtSlNo1.Text = ""
			Me.txtSlNo2.Text = ""
			Me.txtstate.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.fillInvoiceNo()
			Me.fillTillID()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Me.Getdata()
		End Sub

		' Token: 0x0600967C RID: 38524 RVA: 0x006C2E10 File Offset: 0x006C1010
		Private Sub cmbInvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfoD.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where InvoiceNo='" + Me.cmbInvoiceNo.Text + "' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600967D RID: 38525 RVA: 0x006C3168 File Offset: 0x006C1368
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where Customer.Name like N'" + Me.txtCustomerName.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600967E RID: 38526 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600967F RID: 38527 RVA: 0x006C34CC File Offset: 0x006C16CC
		Private Sub txtSalesman_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where Salesman.Name like N'" + Me.txtSalesman.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009680 RID: 38528 RVA: 0x006C3830 File Offset: 0x006C1A30
		Private Sub txtCustCity_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where Customer.City like N'" + Me.txtCustCity.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009681 RID: 38529 RVA: 0x006C3B94 File Offset: 0x006C1D94
		Private Sub txtstate_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where Customer.State like N'" + Me.txtstate.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009682 RID: 38530 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009683 RID: 38531 RVA: 0x006C3EE8 File Offset: 0x006C20E8
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))
						End If

				Next
				Me.Label14.Text = Conversions.ToString(num4)
				Dim num5 As Integer = Me.dgw.Rows.Count - 1
				Dim num6 As Double
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))
						End If

				Next
				Me.Label15.Text = Conversions.ToString(num6)
				Dim num7 As Integer = Me.dgw.Rows.Count - 1
				Dim num8 As Double
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))
						End If

				Next
				Me.Label16.Text = Conversions.ToString(num8)
				Dim num9 As Integer = Me.dgw.Rows.Count - 1
				Dim num10 As Double
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))
						End If

				Next
				Me.Label18.Text = Conversions.ToString(num10)
				Dim num11 As Integer = Me.dgw.Rows.Count - 1
				Dim num12 As Double
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))
						End If

				Next
				Me.Label20.Text = Conversions.ToString(num12)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
			Me.Label14.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label14.Text), 2), "0.00")
			Me.Label15.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Me.Label16.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label16.Text), 2), "0.00")
			Me.Label18.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label18.Text), 2), "0.00")
			Me.Label20.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label20.Text), 2), "0.00")
		End Sub

		' Token: 0x06009684 RID: 38532 RVA: 0x006C444C File Offset: 0x006C264C
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfoD.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID WHERE NOT TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfoD.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID WHERE TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009685 RID: 38533 RVA: 0x006C490C File Offset: 0x006C2B0C
		Public Sub fillTillID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TillID) FROM POSPrinterSetting", ModCommonClasses.con)
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

		' Token: 0x06009686 RID: 38534 RVA: 0x006C4A40 File Offset: 0x006C2C40
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfoD.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID WHERE TillID=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009687 RID: 38535 RVA: 0x006C4EE4 File Offset: 0x006C30E4
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfoD.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID WHERE Operator=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009688 RID: 38536 RVA: 0x00049A82 File Offset: 0x00047C82
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06009689 RID: 38537 RVA: 0x006C5388 File Offset: 0x006C3588
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

		' Token: 0x0600968A RID: 38538 RVA: 0x0004559D File Offset: 0x0004379D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesPmtInfo.ShowDialog()
		End Sub

		' Token: 0x0600968B RID: 38539 RVA: 0x006C5634 File Offset: 0x006C3834
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600968C RID: 38540 RVA: 0x006C5994 File Offset: 0x006C3B94
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600968D RID: 38541 RVA: 0x006C5CF4 File Offset: 0x006C3EF4
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name),RoundOff, GrandTotal, TotalPaid, RTRIM(InvoiceInfoD.Remarks), RTRIM(TillID), RTRIM(Operator),RTRIM(BillDiscount),RTRIM(Customer.City), BillCash,(Customer.Address) from InvoiceInfoD LEFT Join Customer ON InvoiceInfoD.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfoD.SalesmanID=Salesman.SM_ID where Inv_ID between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSlNo1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSlNo2.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
