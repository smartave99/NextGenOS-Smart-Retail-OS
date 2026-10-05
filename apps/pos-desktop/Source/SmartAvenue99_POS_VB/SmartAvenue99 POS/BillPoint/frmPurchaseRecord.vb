Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005DD RID: 1501
	<DesignerGenerated()>
	Public Partial Class frmPurchaseRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601266D RID: 75373 RVA: 0x0007E3A2 File Offset: 0x0007C5A2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007236 RID: 29238
		' (get) Token: 0x06012670 RID: 75376 RVA: 0x0007E3D4 File Offset: 0x0007C5D4
		' (set) Token: 0x06012671 RID: 75377 RVA: 0x0007E3DE File Offset: 0x0007C5DE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007237 RID: 29239
		' (get) Token: 0x06012672 RID: 75378 RVA: 0x0007E3E7 File Offset: 0x0007C5E7
		' (set) Token: 0x06012673 RID: 75379 RVA: 0x0007E3F1 File Offset: 0x0007C5F1
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17007238 RID: 29240
		' (get) Token: 0x06012674 RID: 75380 RVA: 0x0007E3FA File Offset: 0x0007C5FA
		' (set) Token: 0x06012675 RID: 75381 RVA: 0x0007E404 File Offset: 0x0007C604
		Friend Overridable Property Label1 As Label

		' Token: 0x17007239 RID: 29241
		' (get) Token: 0x06012676 RID: 75382 RVA: 0x0007E40D File Offset: 0x0007C60D
		' (set) Token: 0x06012677 RID: 75383 RVA: 0x00A99B58 File Offset: 0x00A97D58
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

		' Token: 0x1700723A RID: 29242
		' (get) Token: 0x06012678 RID: 75384 RVA: 0x0007E417 File Offset: 0x0007C617
		' (set) Token: 0x06012679 RID: 75385 RVA: 0x0007E421 File Offset: 0x0007C621
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700723B RID: 29243
		' (get) Token: 0x0601267A RID: 75386 RVA: 0x0007E42A File Offset: 0x0007C62A
		' (set) Token: 0x0601267B RID: 75387 RVA: 0x0007E434 File Offset: 0x0007C634
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700723C RID: 29244
		' (get) Token: 0x0601267C RID: 75388 RVA: 0x0007E43D File Offset: 0x0007C63D
		' (set) Token: 0x0601267D RID: 75389 RVA: 0x00A99BD4 File Offset: 0x00A97DD4
		Private _txtSupplierName As TextBox
		Friend Overridable Property txtSupplierName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSupplierName_KeyDown
				Dim textBox As TextBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSupplierName = value
				textBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700723D RID: 29245
		' (get) Token: 0x0601267E RID: 75390 RVA: 0x0007E447 File Offset: 0x0007C647
		' (set) Token: 0x0601267F RID: 75391 RVA: 0x0007E451 File Offset: 0x0007C651
		Friend Overridable Property Label3 As Label

		' Token: 0x1700723E RID: 29246
		' (get) Token: 0x06012680 RID: 75392 RVA: 0x0007E45A File Offset: 0x0007C65A
		' (set) Token: 0x06012681 RID: 75393 RVA: 0x0007E464 File Offset: 0x0007C664
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700723F RID: 29247
		' (get) Token: 0x06012682 RID: 75394 RVA: 0x0007E46D File Offset: 0x0007C66D
		' (set) Token: 0x06012683 RID: 75395 RVA: 0x0007E477 File Offset: 0x0007C677
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17007240 RID: 29248
		' (get) Token: 0x06012684 RID: 75396 RVA: 0x0007E480 File Offset: 0x0007C680
		' (set) Token: 0x06012685 RID: 75397 RVA: 0x0007E48A File Offset: 0x0007C68A
		Friend Overridable Property Label2 As Label

		' Token: 0x17007241 RID: 29249
		' (get) Token: 0x06012686 RID: 75398 RVA: 0x0007E493 File Offset: 0x0007C693
		' (set) Token: 0x06012687 RID: 75399 RVA: 0x0007E49D File Offset: 0x0007C69D
		Friend Overridable Property Label4 As Label

		' Token: 0x17007242 RID: 29250
		' (get) Token: 0x06012688 RID: 75400 RVA: 0x0007E4A6 File Offset: 0x0007C6A6
		' (set) Token: 0x06012689 RID: 75401 RVA: 0x0007E4B0 File Offset: 0x0007C6B0
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17007243 RID: 29251
		' (get) Token: 0x0601268A RID: 75402 RVA: 0x0007E4B9 File Offset: 0x0007C6B9
		' (set) Token: 0x0601268B RID: 75403 RVA: 0x00A99C18 File Offset: 0x00A97E18
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

		' Token: 0x17007244 RID: 29252
		' (get) Token: 0x0601268C RID: 75404 RVA: 0x0007E4C3 File Offset: 0x0007C6C3
		' (set) Token: 0x0601268D RID: 75405 RVA: 0x0007E4CD File Offset: 0x0007C6CD
		Friend Overridable Property lblSet As Label

		' Token: 0x17007245 RID: 29253
		' (get) Token: 0x0601268E RID: 75406 RVA: 0x0007E4D6 File Offset: 0x0007C6D6
		' (set) Token: 0x0601268F RID: 75407 RVA: 0x0007E4E0 File Offset: 0x0007C6E0
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007246 RID: 29254
		' (get) Token: 0x06012690 RID: 75408 RVA: 0x0007E4E9 File Offset: 0x0007C6E9
		' (set) Token: 0x06012691 RID: 75409 RVA: 0x0007E4F3 File Offset: 0x0007C6F3
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17007247 RID: 29255
		' (get) Token: 0x06012692 RID: 75410 RVA: 0x0007E4FC File Offset: 0x0007C6FC
		' (set) Token: 0x06012693 RID: 75411 RVA: 0x00A99C5C File Offset: 0x00A97E5C
		Private _cmbInvoiceNo As ComboBox
		Friend Overridable Property cmbInvoiceNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbInvoiceNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbInvoiceNo = value
				comboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007248 RID: 29256
		' (get) Token: 0x06012694 RID: 75412 RVA: 0x0007E506 File Offset: 0x0007C706
		' (set) Token: 0x06012695 RID: 75413 RVA: 0x0007E510 File Offset: 0x0007C710
		Friend Overridable Property Label5 As Label

		' Token: 0x17007249 RID: 29257
		' (get) Token: 0x06012696 RID: 75414 RVA: 0x0007E519 File Offset: 0x0007C719
		' (set) Token: 0x06012697 RID: 75415 RVA: 0x0007E523 File Offset: 0x0007C723
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x1700724A RID: 29258
		' (get) Token: 0x06012698 RID: 75416 RVA: 0x0007E52C File Offset: 0x0007C72C
		' (set) Token: 0x06012699 RID: 75417 RVA: 0x0007E536 File Offset: 0x0007C736
		Friend Overridable Property Panel7 As Panel

		' Token: 0x1700724B RID: 29259
		' (get) Token: 0x0601269A RID: 75418 RVA: 0x0007E53F File Offset: 0x0007C73F
		' (set) Token: 0x0601269B RID: 75419 RVA: 0x0007E549 File Offset: 0x0007C749
		Friend Overridable Property Label8 As Label

		' Token: 0x1700724C RID: 29260
		' (get) Token: 0x0601269C RID: 75420 RVA: 0x0007E552 File Offset: 0x0007C752
		' (set) Token: 0x0601269D RID: 75421 RVA: 0x00A99CA0 File Offset: 0x00A97EA0
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

		' Token: 0x1700724D RID: 29261
		' (get) Token: 0x0601269E RID: 75422 RVA: 0x0007E55C File Offset: 0x0007C75C
		' (set) Token: 0x0601269F RID: 75423 RVA: 0x0007E566 File Offset: 0x0007C766
		Friend Overridable Property Label10 As Label

		' Token: 0x1700724E RID: 29262
		' (get) Token: 0x060126A0 RID: 75424 RVA: 0x0007E56F File Offset: 0x0007C76F
		' (set) Token: 0x060126A1 RID: 75425 RVA: 0x0007E579 File Offset: 0x0007C779
		Friend Overridable Property Label11 As Label

		' Token: 0x1700724F RID: 29263
		' (get) Token: 0x060126A2 RID: 75426 RVA: 0x0007E582 File Offset: 0x0007C782
		' (set) Token: 0x060126A3 RID: 75427 RVA: 0x0007E58C File Offset: 0x0007C78C
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17007250 RID: 29264
		' (get) Token: 0x060126A4 RID: 75428 RVA: 0x0007E595 File Offset: 0x0007C795
		' (set) Token: 0x060126A5 RID: 75429 RVA: 0x00A99CE4 File Offset: 0x00A97EE4
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click_1
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

		' Token: 0x17007251 RID: 29265
		' (get) Token: 0x060126A6 RID: 75430 RVA: 0x0007E59F File Offset: 0x0007C79F
		' (set) Token: 0x060126A7 RID: 75431 RVA: 0x00A99D28 File Offset: 0x00A97F28
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click_1
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

		' Token: 0x17007252 RID: 29266
		' (get) Token: 0x060126A8 RID: 75432 RVA: 0x0007E5A9 File Offset: 0x0007C7A9
		' (set) Token: 0x060126A9 RID: 75433 RVA: 0x0007E5B3 File Offset: 0x0007C7B3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17007253 RID: 29267
		' (get) Token: 0x060126AA RID: 75434 RVA: 0x0007E5BC File Offset: 0x0007C7BC
		' (set) Token: 0x060126AB RID: 75435 RVA: 0x0007E5C6 File Offset: 0x0007C7C6
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17007254 RID: 29268
		' (get) Token: 0x060126AC RID: 75436 RVA: 0x0007E5CF File Offset: 0x0007C7CF
		' (set) Token: 0x060126AD RID: 75437 RVA: 0x0007E5D9 File Offset: 0x0007C7D9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17007255 RID: 29269
		' (get) Token: 0x060126AE RID: 75438 RVA: 0x0007E5E2 File Offset: 0x0007C7E2
		' (set) Token: 0x060126AF RID: 75439 RVA: 0x0007E5EC File Offset: 0x0007C7EC
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17007256 RID: 29270
		' (get) Token: 0x060126B0 RID: 75440 RVA: 0x0007E5F5 File Offset: 0x0007C7F5
		' (set) Token: 0x060126B1 RID: 75441 RVA: 0x0007E5FF File Offset: 0x0007C7FF
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17007257 RID: 29271
		' (get) Token: 0x060126B2 RID: 75442 RVA: 0x0007E608 File Offset: 0x0007C808
		' (set) Token: 0x060126B3 RID: 75443 RVA: 0x0007E612 File Offset: 0x0007C812
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17007258 RID: 29272
		' (get) Token: 0x060126B4 RID: 75444 RVA: 0x0007E61B File Offset: 0x0007C81B
		' (set) Token: 0x060126B5 RID: 75445 RVA: 0x0007E625 File Offset: 0x0007C825
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17007259 RID: 29273
		' (get) Token: 0x060126B6 RID: 75446 RVA: 0x0007E62E File Offset: 0x0007C82E
		' (set) Token: 0x060126B7 RID: 75447 RVA: 0x0007E638 File Offset: 0x0007C838
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700725A RID: 29274
		' (get) Token: 0x060126B8 RID: 75448 RVA: 0x0007E641 File Offset: 0x0007C841
		' (set) Token: 0x060126B9 RID: 75449 RVA: 0x0007E64B File Offset: 0x0007C84B
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700725B RID: 29275
		' (get) Token: 0x060126BA RID: 75450 RVA: 0x0007E654 File Offset: 0x0007C854
		' (set) Token: 0x060126BB RID: 75451 RVA: 0x0007E65E File Offset: 0x0007C85E
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700725C RID: 29276
		' (get) Token: 0x060126BC RID: 75452 RVA: 0x0007E667 File Offset: 0x0007C867
		' (set) Token: 0x060126BD RID: 75453 RVA: 0x0007E671 File Offset: 0x0007C871
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700725D RID: 29277
		' (get) Token: 0x060126BE RID: 75454 RVA: 0x0007E67A File Offset: 0x0007C87A
		' (set) Token: 0x060126BF RID: 75455 RVA: 0x0007E684 File Offset: 0x0007C884
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700725E RID: 29278
		' (get) Token: 0x060126C0 RID: 75456 RVA: 0x0007E68D File Offset: 0x0007C88D
		' (set) Token: 0x060126C1 RID: 75457 RVA: 0x0007E697 File Offset: 0x0007C897
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700725F RID: 29279
		' (get) Token: 0x060126C2 RID: 75458 RVA: 0x0007E6A0 File Offset: 0x0007C8A0
		' (set) Token: 0x060126C3 RID: 75459 RVA: 0x0007E6AA File Offset: 0x0007C8AA
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17007260 RID: 29280
		' (get) Token: 0x060126C4 RID: 75460 RVA: 0x0007E6B3 File Offset: 0x0007C8B3
		' (set) Token: 0x060126C5 RID: 75461 RVA: 0x0007E6BD File Offset: 0x0007C8BD
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17007261 RID: 29281
		' (get) Token: 0x060126C6 RID: 75462 RVA: 0x0007E6C6 File Offset: 0x0007C8C6
		' (set) Token: 0x060126C7 RID: 75463 RVA: 0x0007E6D0 File Offset: 0x0007C8D0
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17007262 RID: 29282
		' (get) Token: 0x060126C8 RID: 75464 RVA: 0x0007E6D9 File Offset: 0x0007C8D9
		' (set) Token: 0x060126C9 RID: 75465 RVA: 0x0007E6E3 File Offset: 0x0007C8E3
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17007263 RID: 29283
		' (get) Token: 0x060126CA RID: 75466 RVA: 0x0007E6EC File Offset: 0x0007C8EC
		' (set) Token: 0x060126CB RID: 75467 RVA: 0x0007E6F6 File Offset: 0x0007C8F6
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17007264 RID: 29284
		' (get) Token: 0x060126CC RID: 75468 RVA: 0x0007E6FF File Offset: 0x0007C8FF
		' (set) Token: 0x060126CD RID: 75469 RVA: 0x0007E709 File Offset: 0x0007C909
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17007265 RID: 29285
		' (get) Token: 0x060126CE RID: 75470 RVA: 0x0007E712 File Offset: 0x0007C912
		' (set) Token: 0x060126CF RID: 75471 RVA: 0x0007E71C File Offset: 0x0007C91C
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17007266 RID: 29286
		' (get) Token: 0x060126D0 RID: 75472 RVA: 0x0007E725 File Offset: 0x0007C925
		' (set) Token: 0x060126D1 RID: 75473 RVA: 0x0007E72F File Offset: 0x0007C92F
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17007267 RID: 29287
		' (get) Token: 0x060126D2 RID: 75474 RVA: 0x0007E738 File Offset: 0x0007C938
		' (set) Token: 0x060126D3 RID: 75475 RVA: 0x0007E742 File Offset: 0x0007C942
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17007268 RID: 29288
		' (get) Token: 0x060126D4 RID: 75476 RVA: 0x0007E74B File Offset: 0x0007C94B
		' (set) Token: 0x060126D5 RID: 75477 RVA: 0x0007E755 File Offset: 0x0007C955
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17007269 RID: 29289
		' (get) Token: 0x060126D6 RID: 75478 RVA: 0x0007E75E File Offset: 0x0007C95E
		' (set) Token: 0x060126D7 RID: 75479 RVA: 0x0007E768 File Offset: 0x0007C968
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700726A RID: 29290
		' (get) Token: 0x060126D8 RID: 75480 RVA: 0x0007E771 File Offset: 0x0007C971
		' (set) Token: 0x060126D9 RID: 75481 RVA: 0x0007E77B File Offset: 0x0007C97B
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700726B RID: 29291
		' (get) Token: 0x060126DA RID: 75482 RVA: 0x0007E784 File Offset: 0x0007C984
		' (set) Token: 0x060126DB RID: 75483 RVA: 0x0007E78E File Offset: 0x0007C98E
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700726C RID: 29292
		' (get) Token: 0x060126DC RID: 75484 RVA: 0x0007E797 File Offset: 0x0007C997
		' (set) Token: 0x060126DD RID: 75485 RVA: 0x0007E7A1 File Offset: 0x0007C9A1
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700726D RID: 29293
		' (get) Token: 0x060126DE RID: 75486 RVA: 0x0007E7AA File Offset: 0x0007C9AA
		' (set) Token: 0x060126DF RID: 75487 RVA: 0x0007E7B4 File Offset: 0x0007C9B4
		Friend Overridable Property Column14 As DataGridViewImageColumn

		' Token: 0x1700726E RID: 29294
		' (get) Token: 0x060126E0 RID: 75488 RVA: 0x0007E7BD File Offset: 0x0007C9BD
		' (set) Token: 0x060126E1 RID: 75489 RVA: 0x0007E7C7 File Offset: 0x0007C9C7
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x1700726F RID: 29295
		' (get) Token: 0x060126E2 RID: 75490 RVA: 0x0007E7D0 File Offset: 0x0007C9D0
		' (set) Token: 0x060126E3 RID: 75491 RVA: 0x0007E7DA File Offset: 0x0007C9DA
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17007270 RID: 29296
		' (get) Token: 0x060126E4 RID: 75492 RVA: 0x0007E7E3 File Offset: 0x0007C9E3
		' (set) Token: 0x060126E5 RID: 75493 RVA: 0x0007E7ED File Offset: 0x0007C9ED
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17007271 RID: 29297
		' (get) Token: 0x060126E6 RID: 75494 RVA: 0x0007E7F6 File Offset: 0x0007C9F6
		' (set) Token: 0x060126E7 RID: 75495 RVA: 0x0007E800 File Offset: 0x0007CA00
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17007272 RID: 29298
		' (get) Token: 0x060126E8 RID: 75496 RVA: 0x0007E809 File Offset: 0x0007CA09
		' (set) Token: 0x060126E9 RID: 75497 RVA: 0x0007E813 File Offset: 0x0007CA13
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17007273 RID: 29299
		' (get) Token: 0x060126EA RID: 75498 RVA: 0x0007E81C File Offset: 0x0007CA1C
		' (set) Token: 0x060126EB RID: 75499 RVA: 0x00A99D6C File Offset: 0x00A97F6C
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

		' Token: 0x060126EC RID: 75500 RVA: 0x00A99DB0 File Offset: 0x00A97FB0
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

		' Token: 0x060126ED RID: 75501 RVA: 0x00A99E84 File Offset: 0x00A98084
		Public Sub Getdata()
			Try
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060126EE RID: 75502 RVA: 0x00A9A1E8 File Offset: 0x00A983E8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060126EF RID: 75503 RVA: 0x00A9A280 File Offset: 0x00A98480
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

		' Token: 0x060126F0 RID: 75504 RVA: 0x00A9A3F8 File Offset: 0x00A985F8
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

		' Token: 0x060126F1 RID: 75505 RVA: 0x00A9A4C4 File Offset: 0x00A986C4
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

		' Token: 0x060126F2 RID: 75506 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060126F3 RID: 75507 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060126F4 RID: 75508 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060126F5 RID: 75509 RVA: 0x00A9A590 File Offset: 0x00A98790
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060126F6 RID: 75510 RVA: 0x005ED880 File Offset: 0x005EBA80
		Public Sub Clear_SerialData()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim sqlCommand As SqlCommand = Nothing
			Try
				sqlConnection.Open()
				Dim text As String = "DELETE FROM tbl_product_serial"
				sqlCommand = New SqlCommand(text, sqlConnection)
				Dim num As Integer = sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = sqlCommand IsNot Nothing
				If flag Then
					sqlCommand.Dispose()
				End If
				Dim flag2 As Boolean = sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
					sqlConnection.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060126F7 RID: 75511 RVA: 0x005ED5FC File Offset: 0x005EB7FC
		Public Sub copy_data_to_product_serial(InvoiceNo As String, SysUser As String)
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM tbl_product_serial_final " & vbCrLf & "                                     where invoice_no = @d2 " & vbCrLf & "                                     AND sys_user = @sysUser", sqlConnection)
				sqlCommand.Parameters.Add("@d2", SqlDbType.VarChar).Value = InvoiceNo
				sqlCommand.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Try
						For Each obj As Object In dataTable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim sqlCommand2 As SqlCommand = New SqlCommand("INSERT INTO tbl_product_serial (productid, barcode, serialno1, serialno2, status, sys_user, invoice_no)" & vbCrLf & "                                             VALUES (@productid, @barcode, @serialno1, @serialno2, @status, @sysUser, @invoice_no)", sqlConnection)
							sqlCommand2.Parameters.Add("@productid", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("productid"))
							sqlCommand2.Parameters.Add("@barcode", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("barcode"))
							sqlCommand2.Parameters.Add("@serialno1", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno1"))
							sqlCommand2.Parameters.Add("@serialno2", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno2"))
							sqlCommand2.Parameters.Add("@status", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("status"))
							sqlCommand2.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
							sqlCommand2.Parameters.Add("@invoice_no", SqlDbType.VarChar).Value = InvoiceNo
							sqlCommand2.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			Finally
				Dim flag2 As Boolean = sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
				End If
			End Try
		End Sub

		' Token: 0x060126F8 RID: 75512 RVA: 0x00A9A5B8 File Offset: 0x00A987B8
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Purchase", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPurchaseEntry.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseEntry.txtST_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.dtpDate.Value = Conversions.ToDate(dataGridViewRow.Cells(2).Value.ToString())
						MyProject.Forms.frmPurchaseEntry.txtReferenceNo1.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbReverse.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbPurchaseType.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtGSTNonGST.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.lbltaxtype.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSupplierInvoiceNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.dtpSupplierInvoiceDate.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSup_ID.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSupplierID.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSubTotal.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtDiscPer.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSGST.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtIGST.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtCESS.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtFreightCharges.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtOtherCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtPreviousDue.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtTotalPaid.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtBalance.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtRemarks.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbBSundry.Text = dataGridViewRow.Cells(26).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbAccountNo.Text = dataGridViewRow.Cells(28).Value.ToString()
						Dim array As Byte() = CType(dataGridViewRow.Cells(27).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						MyProject.Forms.frmPurchaseEntry.Picture.Image = Image.FromStream(memoryStream)
						MyProject.Forms.frmPurchaseEntry.limitsearch()
						MyProject.Forms.frmPurchaseEntry.btnSave.Enabled = False
						MyProject.Forms.frmPurchaseEntry.GetSupplierBalance1()
						MyProject.Forms.frmPurchaseEntry.btnDelete.Enabled = True
						MyProject.Forms.frmPurchaseEntry.btnUpdate.Enabled = True
						MyProject.Forms.frmPurchaseEntry.GetSupplierInfo()
						MyProject.Forms.frmPurchaseEntry.btnSelection.Enabled = False
						MyProject.Forms.frmPurchaseEntry.lblSet.Text = "Not Allowed"
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product.Barcode),Qty,Stock_Product.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,Qty,Stock_Product.TaxableAmt,Stock_Product.AltQty,Stock_Product.AltUnit,Stock_Product.PTaxType,Stock_Product.RPrice,Stock_Product.WPrice,RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.RCipher),RTRIM(Stock_Product.WCipher),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.MainUnit),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) from Product,Stock,Stock_Product where product.PID=Stock_product.ProductID and Stock.ST_ID=Stock_Product.StockID and ST_ID=", dataGridViewRow.Cells(0).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Clear()
						MyProject.Forms.frmPurchaseEntry.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36) })
							MyProject.Forms.frmPurchaseEntry.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPurchaseEntry.DataGridView1.ClearSelection()
						MyProject.Forms.frmPurchaseEntry.DataGridView2.ClearSelection()
						MyProject.Forms.frmPurchaseEntry.Calc()
						MyProject.Forms.frmPurchaseEntry.Compute()
						MyProject.Forms.frmPurchaseEntry.GetQty_S1()
						MyProject.Forms.frmPurchaseEntry.btnPrint.Enabled = True
						MyProject.Forms.frmPurchaseEntry.Label51.Text = "edit"
						Me.Clear_SerialData()
						Me.copy_data_to_product_serial(MyProject.Forms.frmPurchaseEntry.txtInvoiceNo.Text, MyProject.Forms.frmPurchaseEntry.lblUser.Text)
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.lblSet.Text, "PR", False) = 0
					If flag3 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPurchaseReturn.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseReturn.txtPurchaseID.Text = dataGridViewRow2.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtPurchaseInvoiceNo.Text = dataGridViewRow2.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.dtpPurchaseDate.Text = dataGridViewRow2.Cells(2).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSup_ID.Text = dataGridViewRow2.Cells(9).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSupplierID.Text = dataGridViewRow2.Cells(10).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSupplierName.Text = dataGridViewRow2.Cells(11).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtGSTnonGST.Text = dataGridViewRow2.Cells(6).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox2.Text = dataGridViewRow2.Cells(4).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.cmbBSundry.Text = dataGridViewRow2.Cells(26).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox3.Text = dataGridViewRow2.Cells(29).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox4.Text = dataGridViewRow2.Cells(30).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox5.Text = dataGridViewRow2.Cells(31).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox6.Text = dataGridViewRow2.Cells(32).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.btnSelection.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product.Barcode),Qty,Stock_Product.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,(Stock_Product.PTaxType),(Stock_Product.TaxableAmt) from Product,Stock,Stock_Product where product.PID=Stock_product.ProductID and Stock.ST_ID=Stock_Product.StockID and ST_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPurchaseReturn.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Dim num As Integer = Conversions.ToInteger(ModCommonClasses.rdr("PID"))
							Dim num2 As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
							Dim num3 As Decimal = 0D
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Dim text3 As String = "SELECT ISNULL(SUM(a.ReturnQty), 0) FROM PurchaseReturn_Join a INNER JOIN PurchaseReturn b ON a.PurchaseReturnID  = b.PR_ID  WHERE b.PurchaseID   = @purchaseID AND a.ProductID = @productID"
								Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@purchaseID", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
									sqlCommand.Parameters.AddWithValue("@productID", num)
									num3 = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
								End Using
							End Using
							Dim num4 As Integer = MyProject.Forms.frmPurchaseReturn.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
							Dim dataGridViewRow3 As DataGridViewRow = MyProject.Forms.frmPurchaseReturn.DataGridView2.Rows(num4)
							Dim flag4 As Boolean = Decimal.Compare(num3, 0D) = 0
							If flag4 Then
								dataGridViewRow3.DefaultCellStyle.BackColor = Color.LightGreen
							Else
								Dim flag5 As Boolean = Decimal.Compare(num3, num2) < 0
								If flag5 Then
									dataGridViewRow3.DefaultCellStyle.BackColor = Color.Orange
								Else
									Dim flag6 As Boolean = Decimal.Compare(num3, num2) >= 0
									If flag6 Then
										dataGridViewRow3.DefaultCellStyle.BackColor = Color.LightCoral
									End If
								End If
							End If
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPurchaseReturn.DataGridView2.ClearSelection()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060126F9 RID: 75513 RVA: 0x0007E826 File Offset: 0x0007CA26
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060126FA RID: 75514 RVA: 0x00A9B8B8 File Offset: 0x00A99AB8
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

		' Token: 0x060126FB RID: 75515 RVA: 0x00A9B9A0 File Offset: 0x00A99BA0
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.txtSupplierName.Text = ""
			Me.cmbInvoiceNo.SelectedIndex = -1
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtTopResult.Text = "50"
			Me.Getdata()
		End Sub

		' Token: 0x060126FC RID: 75516 RVA: 0x0007E830 File Offset: 0x0007CA30
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x060126FD RID: 75517 RVA: 0x00A9BA0C File Offset: 0x00A99C0C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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

		' Token: 0x060126FE RID: 75518 RVA: 0x00A9BCB8 File Offset: 0x00A99EB8
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060126FF RID: 75519 RVA: 0x00A9C050 File Offset: 0x00A9A250
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM Stock", ModCommonClasses.con)
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

		' Token: 0x06012700 RID: 75520 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012701 RID: 75521 RVA: 0x00A9C184 File Offset: 0x00A9A384
		Private Sub Calculate()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column17").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column17").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2 - num4)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x06012702 RID: 75522 RVA: 0x00A9C340 File Offset: 0x00A9A540
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID and NOT TaxType=@d3 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID and TaxType=@d3 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012703 RID: 75523 RVA: 0x0007E841 File Offset: 0x0007CA41
		Private Sub btnReset_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012704 RID: 75524 RVA: 0x00A9BA0C File Offset: 0x00A99C0C
		Private Sub btnExportExcel_Click_1(sender As Object, e As EventArgs)
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

		' Token: 0x06012705 RID: 75525 RVA: 0x00A9C718 File Offset: 0x00A9A918
		Private Sub txtSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.ComboBox1.SelectedIndex = -1
					Me.cmbInvoiceNo.SelectedIndex = -1
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID  and [Name] like N'", Me.txtSupplierName.Text, "%' and [Date] between @d1 and @d2 order by [Date]" }), ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012706 RID: 75526 RVA: 0x00A9CACC File Offset: 0x00A9ACCC
		Private Sub cmbInvoiceNo_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.ComboBox1.SelectedIndex = -1
					Me.txtSupplierName.Text = ""
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock where Supplier.ID=Stock.SupplierID  and InvoiceNo like N'" + Me.cmbInvoiceNo.Text + "%' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012707 RID: 75527 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
		End Sub
	End Class
End Namespace
