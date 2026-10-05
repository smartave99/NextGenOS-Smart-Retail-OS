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
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004ED RID: 1261
	<DesignerGenerated()>
	Public Partial Class fromItemoffervalid
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060102D3 RID: 66259 RVA: 0x009A29D4 File Offset: 0x009A0BD4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.fromItemoffervalid_Load
			AddHandler MyBase.KeyDown, AddressOf Me.fromItemoffervalid_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.fromItemoffervalid_Closed
			Me.InitializeComponent()
		End Sub

		' Token: 0x170062F8 RID: 25336
		' (get) Token: 0x060102D6 RID: 66262 RVA: 0x00071A1A File Offset: 0x0006FC1A
		' (set) Token: 0x060102D7 RID: 66263 RVA: 0x00071A24 File Offset: 0x0006FC24
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170062F9 RID: 25337
		' (get) Token: 0x060102D8 RID: 66264 RVA: 0x00071A2D File Offset: 0x0006FC2D
		' (set) Token: 0x060102D9 RID: 66265 RVA: 0x00071A37 File Offset: 0x0006FC37
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170062FA RID: 25338
		' (get) Token: 0x060102DA RID: 66266 RVA: 0x00071A40 File Offset: 0x0006FC40
		' (set) Token: 0x060102DB RID: 66267 RVA: 0x009A46AC File Offset: 0x009A28AC
		Private _btnNew As Button
		Friend Overridable Property btnNew As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim button As Button = Me._btnNew
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNew = value
				button = Me._btnNew
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170062FB RID: 25339
		' (get) Token: 0x060102DC RID: 66268 RVA: 0x00071A4A File Offset: 0x0006FC4A
		' (set) Token: 0x060102DD RID: 66269 RVA: 0x009A46F0 File Offset: 0x009A28F0
		Private _btnSave As Button
		Friend Overridable Property btnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSave = value
				button = Me._btnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170062FC RID: 25340
		' (get) Token: 0x060102DE RID: 66270 RVA: 0x00071A54 File Offset: 0x0006FC54
		' (set) Token: 0x060102DF RID: 66271 RVA: 0x009A4734 File Offset: 0x009A2934
		Private _btnDelete As Button
		Friend Overridable Property btnDelete As Button
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim button As Button = Me._btnDelete
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnDelete = value
				button = Me._btnDelete
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170062FD RID: 25341
		' (get) Token: 0x060102E0 RID: 66272 RVA: 0x00071A5E File Offset: 0x0006FC5E
		' (set) Token: 0x060102E1 RID: 66273 RVA: 0x009A4778 File Offset: 0x009A2978
		Private _btnUpdate As Button
		Friend Overridable Property btnUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim button As Button = Me._btnUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate = value
				button = Me._btnUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170062FE RID: 25342
		' (get) Token: 0x060102E2 RID: 66274 RVA: 0x00071A68 File Offset: 0x0006FC68
		' (set) Token: 0x060102E3 RID: 66275 RVA: 0x009A47BC File Offset: 0x009A29BC
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

		' Token: 0x170062FF RID: 25343
		' (get) Token: 0x060102E4 RID: 66276 RVA: 0x00071A72 File Offset: 0x0006FC72
		' (set) Token: 0x060102E5 RID: 66277 RVA: 0x00071A7C File Offset: 0x0006FC7C
		Friend Overridable Property lblUser As Label

		' Token: 0x17006300 RID: 25344
		' (get) Token: 0x060102E6 RID: 66278 RVA: 0x00071A85 File Offset: 0x0006FC85
		' (set) Token: 0x060102E7 RID: 66279 RVA: 0x00071A8F File Offset: 0x0006FC8F
		Friend Overridable Property Label1 As Label

		' Token: 0x17006301 RID: 25345
		' (get) Token: 0x060102E8 RID: 66280 RVA: 0x00071A98 File Offset: 0x0006FC98
		' (set) Token: 0x060102E9 RID: 66281 RVA: 0x00071AA2 File Offset: 0x0006FCA2
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006302 RID: 25346
		' (get) Token: 0x060102EA RID: 66282 RVA: 0x00071AAB File Offset: 0x0006FCAB
		' (set) Token: 0x060102EB RID: 66283 RVA: 0x00071AB5 File Offset: 0x0006FCB5
		Friend Overridable Property Label6 As Label

		' Token: 0x17006303 RID: 25347
		' (get) Token: 0x060102EC RID: 66284 RVA: 0x00071ABE File Offset: 0x0006FCBE
		' (set) Token: 0x060102ED RID: 66285 RVA: 0x009A481C File Offset: 0x009A2A1C
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006304 RID: 25348
		' (get) Token: 0x060102EE RID: 66286 RVA: 0x00071AC8 File Offset: 0x0006FCC8
		' (set) Token: 0x060102EF RID: 66287 RVA: 0x00071AD2 File Offset: 0x0006FCD2
		Friend Overridable Property Label7 As Label

		' Token: 0x17006305 RID: 25349
		' (get) Token: 0x060102F0 RID: 66288 RVA: 0x00071ADB File Offset: 0x0006FCDB
		' (set) Token: 0x060102F1 RID: 66289 RVA: 0x009A487C File Offset: 0x009A2A7C
		Private _cmbProductName As ComboBox
		Friend Overridable Property cmbProductName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbProductName_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductName_KeyDown
				Dim comboBox As ComboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbProductName = value
				comboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006306 RID: 25350
		' (get) Token: 0x060102F2 RID: 66290 RVA: 0x00071AE5 File Offset: 0x0006FCE5
		' (set) Token: 0x060102F3 RID: 66291 RVA: 0x00071AEF File Offset: 0x0006FCEF
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17006307 RID: 25351
		' (get) Token: 0x060102F4 RID: 66292 RVA: 0x00071AF8 File Offset: 0x0006FCF8
		' (set) Token: 0x060102F5 RID: 66293 RVA: 0x00071B02 File Offset: 0x0006FD02
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17006308 RID: 25352
		' (get) Token: 0x060102F6 RID: 66294 RVA: 0x00071B0B File Offset: 0x0006FD0B
		' (set) Token: 0x060102F7 RID: 66295 RVA: 0x00071B15 File Offset: 0x0006FD15
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x17006309 RID: 25353
		' (get) Token: 0x060102F8 RID: 66296 RVA: 0x00071B1E File Offset: 0x0006FD1E
		' (set) Token: 0x060102F9 RID: 66297 RVA: 0x00071B28 File Offset: 0x0006FD28
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x1700630A RID: 25354
		' (get) Token: 0x060102FA RID: 66298 RVA: 0x00071B31 File Offset: 0x0006FD31
		' (set) Token: 0x060102FB RID: 66299 RVA: 0x00071B3B File Offset: 0x0006FD3B
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x1700630B RID: 25355
		' (get) Token: 0x060102FC RID: 66300 RVA: 0x00071B44 File Offset: 0x0006FD44
		' (set) Token: 0x060102FD RID: 66301 RVA: 0x009A48DC File Offset: 0x009A2ADC
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700630C RID: 25356
		' (get) Token: 0x060102FE RID: 66302 RVA: 0x00071B4E File Offset: 0x0006FD4E
		' (set) Token: 0x060102FF RID: 66303 RVA: 0x00071B58 File Offset: 0x0006FD58
		Friend Overridable Property lblBarcode As Label

		' Token: 0x1700630D RID: 25357
		' (get) Token: 0x06010300 RID: 66304 RVA: 0x00071B61 File Offset: 0x0006FD61
		' (set) Token: 0x06010301 RID: 66305 RVA: 0x00071B6B File Offset: 0x0006FD6B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700630E RID: 25358
		' (get) Token: 0x06010302 RID: 66306 RVA: 0x00071B74 File Offset: 0x0006FD74
		' (set) Token: 0x06010303 RID: 66307 RVA: 0x00071B7E File Offset: 0x0006FD7E
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700630F RID: 25359
		' (get) Token: 0x06010304 RID: 66308 RVA: 0x00071B87 File Offset: 0x0006FD87
		' (set) Token: 0x06010305 RID: 66309 RVA: 0x00071B91 File Offset: 0x0006FD91
		Friend Overridable Property Label5 As Label

		' Token: 0x17006310 RID: 25360
		' (get) Token: 0x06010306 RID: 66310 RVA: 0x00071B9A File Offset: 0x0006FD9A
		' (set) Token: 0x06010307 RID: 66311 RVA: 0x00071BA4 File Offset: 0x0006FDA4
		Friend Overridable Property Label4 As Label

		' Token: 0x17006311 RID: 25361
		' (get) Token: 0x06010308 RID: 66312 RVA: 0x00071BAD File Offset: 0x0006FDAD
		' (set) Token: 0x06010309 RID: 66313 RVA: 0x009A4920 File Offset: 0x009A2B20
		Private _dtpToDate As DateTimePicker
		Friend Overridable Property dtpToDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpToDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpToDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpToDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpToDate = value
				dateTimePicker = Me._dtpToDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006312 RID: 25362
		' (get) Token: 0x0601030A RID: 66314 RVA: 0x00071BB7 File Offset: 0x0006FDB7
		' (set) Token: 0x0601030B RID: 66315 RVA: 0x009A4964 File Offset: 0x009A2B64
		Private _dtpFromDate As DateTimePicker
		Friend Overridable Property dtpFromDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpFromDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpFromDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpFromDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpFromDate = value
				dateTimePicker = Me._dtpFromDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006313 RID: 25363
		' (get) Token: 0x0601030C RID: 66316 RVA: 0x00071BC1 File Offset: 0x0006FDC1
		' (set) Token: 0x0601030D RID: 66317 RVA: 0x00071BCB File Offset: 0x0006FDCB
		Friend Overridable Property Label3 As Label

		' Token: 0x17006314 RID: 25364
		' (get) Token: 0x0601030E RID: 66318 RVA: 0x00071BD4 File Offset: 0x0006FDD4
		' (set) Token: 0x0601030F RID: 66319 RVA: 0x009A49A8 File Offset: 0x009A2BA8
		Private _txtDiscPerc As TextBox
		Friend Overridable Property txtDiscPerc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscPerc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscPerc_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtDiscPerc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtDiscPerc = value
				textBox = Me._txtDiscPerc
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006315 RID: 25365
		' (get) Token: 0x06010310 RID: 66320 RVA: 0x00071BDE File Offset: 0x0006FDDE
		' (set) Token: 0x06010311 RID: 66321 RVA: 0x009A4A08 File Offset: 0x009A2C08
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

		' Token: 0x17006316 RID: 25366
		' (get) Token: 0x06010312 RID: 66322 RVA: 0x00071BE8 File Offset: 0x0006FDE8
		' (set) Token: 0x06010313 RID: 66323 RVA: 0x00071BF2 File Offset: 0x0006FDF2
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006317 RID: 25367
		' (get) Token: 0x06010314 RID: 66324 RVA: 0x00071BFB File Offset: 0x0006FDFB
		' (set) Token: 0x06010315 RID: 66325 RVA: 0x00071C05 File Offset: 0x0006FE05
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006318 RID: 25368
		' (get) Token: 0x06010316 RID: 66326 RVA: 0x00071C0E File Offset: 0x0006FE0E
		' (set) Token: 0x06010317 RID: 66327 RVA: 0x00071C18 File Offset: 0x0006FE18
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006319 RID: 25369
		' (get) Token: 0x06010318 RID: 66328 RVA: 0x00071C21 File Offset: 0x0006FE21
		' (set) Token: 0x06010319 RID: 66329 RVA: 0x00071C2B File Offset: 0x0006FE2B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700631A RID: 25370
		' (get) Token: 0x0601031A RID: 66330 RVA: 0x00071C34 File Offset: 0x0006FE34
		' (set) Token: 0x0601031B RID: 66331 RVA: 0x00071C3E File Offset: 0x0006FE3E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700631B RID: 25371
		' (get) Token: 0x0601031C RID: 66332 RVA: 0x00071C47 File Offset: 0x0006FE47
		' (set) Token: 0x0601031D RID: 66333 RVA: 0x00071C51 File Offset: 0x0006FE51
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700631C RID: 25372
		' (get) Token: 0x0601031E RID: 66334 RVA: 0x00071C5A File Offset: 0x0006FE5A
		' (set) Token: 0x0601031F RID: 66335 RVA: 0x00071C64 File Offset: 0x0006FE64
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700631D RID: 25373
		' (get) Token: 0x06010320 RID: 66336 RVA: 0x00071C6D File Offset: 0x0006FE6D
		' (set) Token: 0x06010321 RID: 66337 RVA: 0x00071C77 File Offset: 0x0006FE77
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700631E RID: 25374
		' (get) Token: 0x06010322 RID: 66338 RVA: 0x00071C80 File Offset: 0x0006FE80
		' (set) Token: 0x06010323 RID: 66339 RVA: 0x00071C8A File Offset: 0x0006FE8A
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x1700631F RID: 25375
		' (get) Token: 0x06010324 RID: 66340 RVA: 0x00071C93 File Offset: 0x0006FE93
		' (set) Token: 0x06010325 RID: 66341 RVA: 0x00071C9D File Offset: 0x0006FE9D
		Friend Overridable Property Label2 As Label

		' Token: 0x17006320 RID: 25376
		' (get) Token: 0x06010326 RID: 66342 RVA: 0x00071CA6 File Offset: 0x0006FEA6
		' (set) Token: 0x06010327 RID: 66343 RVA: 0x009A4A4C File Offset: 0x009A2C4C
		Private _cmbSubCat As ComboBox
		Friend Overridable Property cmbSubCat As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSubCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSubCat_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSubCat
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSubCat = value
				comboBox = Me._cmbSubCat
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010328 RID: 66344 RVA: 0x009A4A90 File Offset: 0x009A2C90
		Private Sub fillCategory()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbCategory.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010329 RID: 66345 RVA: 0x009A4C24 File Offset: 0x009A2E24
		Public Sub fillItem()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ProductName) FROM Product order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductName.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbProductName.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601032A RID: 66346 RVA: 0x009A4DB8 File Offset: 0x009A2FB8
		Public Sub cat()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(SubCategoryName) FROM SubCategory order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSubCat.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbSubCat.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601032B RID: 66347 RVA: 0x009A4F4C File Offset: 0x009A314C
		Private Sub fromItemoffervalid_Load(sender As Object, e As EventArgs)
			Me.fillItem()
			Me.fillCategory()
			Me.cat()
			Me.Reset()
			Me.lblBarcode.Text = ""
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601032C RID: 66348 RVA: 0x009A4FFC File Offset: 0x009A31FC
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

		' Token: 0x0601032D RID: 66349 RVA: 0x009A529C File Offset: 0x009A349C
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

		' Token: 0x0601032E RID: 66350 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601032F RID: 66351 RVA: 0x00071CB0 File Offset: 0x0006FEB0
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.GetdataX()
		End Sub

		' Token: 0x06010330 RID: 66352 RVA: 0x009A5358 File Offset: 0x009A3558
		Private Sub GetdataX()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010331 RID: 66353 RVA: 0x009A5514 File Offset: 0x009A3714
		Private Sub cmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.ProductName like N'" + Me.cmbProductName.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010332 RID: 66354 RVA: 0x009A56E4 File Offset: 0x009A38E4
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim num As Integer = 0
			Dim num2 As Integer = Me.ListView1.Items.Count - 1
			Dim num3 As Integer = num
			While True
				Dim num4 As Integer = num3
				Dim num5 As Integer = num2
				Dim flag As Boolean = num4 > num5
				If flag Then
					Exit While
				End If
				Me.ListView1.Items(num3).Checked = Me.chkSelectAll.Checked
				num3 += 1
			End While
		End Sub

		' Token: 0x06010333 RID: 66355 RVA: 0x009A574C File Offset: 0x009A394C
		Private Sub Reset()
			Me.txtID.Text = "0"
			Me.cmbProductName.SelectedIndex = -1
			Me.cmbCategory.SelectedIndex = -1
			Me.cmbSubCat.SelectedIndex = -1
			Me.txtDiscPerc.Text = "0.00"
			Me.dtpFromDate.Value = DateAndTime.Now
			Me.dtpToDate.Value = DateAndTime.Now
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.cmbCategory.Focus()
			Me.Getdata()
			Me.lblBarcode.Text = ""
		End Sub

		' Token: 0x06010334 RID: 66356 RVA: 0x00071CBA File Offset: 0x0006FEBA
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.ListView1.Items.Clear()
		End Sub

		' Token: 0x06010335 RID: 66357 RVA: 0x009A5810 File Offset: 0x009A3A10
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ListView1.CheckedItems.Count = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbProductName.Focus()
			Else
				flag = Conversion.Val(Me.txtDiscPerc.Text) = 0.0
				Dim flag3 As Boolean = flag
				If flag3 Then
					MessageBox.Show("Please enter on discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtDiscPerc.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select ProductID from Offer2 where ProductID=@d1"
						Dim num As Integer = 0
						Dim num2 As Integer = Me.ListView1.CheckedItems.Count - 1
						Dim num3 As Integer = num
						While True
							Dim num4 As Integer = num3
							Dim num5 As Integer = num2
							Dim flag4 As Boolean = num4 > num5
							If flag4 Then
								Exit While
							End If
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.ListView1.CheckedItems(num3).SubItems(4).Text))))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								GoTo Block_6
							End If
							num3 += 1
						End While
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "insert into Offer2(ProductID, DiscPerc, FromDate, ToDate) VALUES (@d1, @d2, @d3, @d4)"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num6 As Integer = 0
						Dim num7 As Integer = Me.ListView1.CheckedItems.Count - 1
						Dim num8 As Integer = num6
						While True
							Dim num9 As Integer = num8
							Dim num10 As Integer = num7
							Dim flag6 As Boolean = num9 > num10
							If flag6 Then
								Exit While
							End If
							ModCommonClasses.cmd.Parameters.Clear()
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.ListView1.CheckedItems(num8).SubItems(4).Text))))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtDiscPerc.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpFromDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpToDate.Value.[Date])
							ModCommonClasses.cmd.ExecuteNonQuery()
							num8 += 1
						End While
						ModCommonClasses.con.Close()
						Dim num11 As Integer = 0
						Dim num12 As Integer = Me.ListView1.CheckedItems.Count - 1
						Dim num13 As Integer = num11
						While True
							Dim num14 As Integer = num13
							Dim num15 As Integer = num12
							Dim flag7 As Boolean = num14 > num15
							If flag7 Then
								Exit While
							End If
							ModFunc.LogFunc(Me.lblUser.Text, "added the new offer '" + Me.ListView1.CheckedItems(num13).SubItems(1).Text + "'")
							num13 += 1
						End While
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnSave.Enabled = False
						Me.Getdata()
						Me.Reset()
						GoTo IL_03FE
						Block_6:
						MessageBox.Show("Already Exists for selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag8 Then
							ModCommonClasses.rdr.Close()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
					IL_03FE:
				End If
			End If
		End Sub

		' Token: 0x06010336 RID: 66358 RVA: 0x009A5C3C File Offset: 0x009A3E3C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversion.Val(Me.txtDiscPerc.Text) = 0.0
			If flag Then
				MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDiscPerc.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "UPDATE Offer2 SET DiscPerc=@d2, FromDate=@d3, ToDate=@d4 WHERE OfferId=@d5"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtDiscPerc.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpFromDate.Value.[Date])
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpToDate.Value.[Date])
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtID.Text)
					ModCommonClasses.cmd.ExecuteReader()
					ModFunc.LogFunc(Me.lblUser.Text, "updated the offer '" + Me.cmbProductName.Text + "'")
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
					Me.Reset()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010337 RID: 66359 RVA: 0x009A5E14 File Offset: 0x009A4014
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM offer2 WHERE OfferId=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModFunc.LogFunc(Me.lblUser.Text, "deleted the offer '" + Me.cmbProductName.Text + "'")
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

		' Token: 0x06010338 RID: 66360 RVA: 0x009A5F2C File Offset: 0x009A412C
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010339 RID: 66361 RVA: 0x009A5F98 File Offset: 0x009A4198
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

		' Token: 0x0601033A RID: 66362 RVA: 0x009A6080 File Offset: 0x009A4280
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT OfferId, ProductId, RTRIM(ProductName), RTRIM(ProductCode), discperc, FromDate, ToDate FROM Offer2 LEFT JOIN Product ON Offer2.ProductId = Product.PID ORDER BY OfferId", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(1)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(2)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(3)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(4)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(5)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(6)) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601033B RID: 66363 RVA: 0x009A61EC File Offset: 0x009A43EC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtDiscPerc.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.dtpFromDate.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.dtpToDate.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601033C RID: 66364 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601033D RID: 66365 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601033E RID: 66366 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpFromDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601033F RID: 66367 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpToDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010340 RID: 66368 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscPerc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010341 RID: 66369 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub fromItemoffervalid_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010342 RID: 66370 RVA: 0x009A62FC File Offset: 0x009A44FC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtDiscPerc.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtDiscPerc, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtDiscPerc, String.Empty)
			End If
		End Sub

		' Token: 0x06010343 RID: 66371 RVA: 0x00071CD5 File Offset: 0x0006FED5
		Private Sub fromItemoffervalid_Closed(sender As Object, e As EventArgs)
			Me.ListView1.Items.Clear()
		End Sub

		' Token: 0x06010344 RID: 66372 RVA: 0x009A6358 File Offset: 0x009A4558
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Category.CategoryName like N'" + Me.cmbCategory.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010345 RID: 66373 RVA: 0x009A6528 File Offset: 0x009A4728
		Private Sub cmbSubCat_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and SubCategory.SubCategoryName like N'" + Me.cmbSubCat.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
