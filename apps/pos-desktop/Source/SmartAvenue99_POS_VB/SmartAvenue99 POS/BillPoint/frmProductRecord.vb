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
	' Token: 0x020002A6 RID: 678
	<DesignerGenerated()>
	Public Partial Class frmProductRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AD3E RID: 44350 RVA: 0x00050A06 File Offset: 0x0004EC06
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170042F7 RID: 17143
		' (get) Token: 0x0600AD41 RID: 44353 RVA: 0x00050A38 File Offset: 0x0004EC38
		' (set) Token: 0x0600AD42 RID: 44354 RVA: 0x00050A42 File Offset: 0x0004EC42
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170042F8 RID: 17144
		' (get) Token: 0x0600AD43 RID: 44355 RVA: 0x00050A4B File Offset: 0x0004EC4B
		' (set) Token: 0x0600AD44 RID: 44356 RVA: 0x0073DBF4 File Offset: 0x0073BDF4
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

		' Token: 0x170042F9 RID: 17145
		' (get) Token: 0x0600AD45 RID: 44357 RVA: 0x00050A55 File Offset: 0x0004EC55
		' (set) Token: 0x0600AD46 RID: 44358 RVA: 0x00050A5F File Offset: 0x0004EC5F
		Friend Overridable Property lblSet As Label

		' Token: 0x170042FA RID: 17146
		' (get) Token: 0x0600AD47 RID: 44359 RVA: 0x00050A68 File Offset: 0x0004EC68
		' (set) Token: 0x0600AD48 RID: 44360 RVA: 0x0073DC70 File Offset: 0x0073BE70
		Private _txtCategory As TextBox
		Friend Overridable Property txtCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCategory_KeyDown
				Dim textBox As TextBox = Me._txtCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCategory = value
				textBox = Me._txtCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042FB RID: 17147
		' (get) Token: 0x0600AD49 RID: 44361 RVA: 0x00050A72 File Offset: 0x0004EC72
		' (set) Token: 0x0600AD4A RID: 44362 RVA: 0x00050A7C File Offset: 0x0004EC7C
		Friend Overridable Property Label2 As Label

		' Token: 0x170042FC RID: 17148
		' (get) Token: 0x0600AD4B RID: 44363 RVA: 0x00050A85 File Offset: 0x0004EC85
		' (set) Token: 0x0600AD4C RID: 44364 RVA: 0x00050A8F File Offset: 0x0004EC8F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170042FD RID: 17149
		' (get) Token: 0x0600AD4D RID: 44365 RVA: 0x00050A98 File Offset: 0x0004EC98
		' (set) Token: 0x0600AD4E RID: 44366 RVA: 0x00050AA2 File Offset: 0x0004ECA2
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170042FE RID: 17150
		' (get) Token: 0x0600AD4F RID: 44367 RVA: 0x00050AAB File Offset: 0x0004ECAB
		' (set) Token: 0x0600AD50 RID: 44368 RVA: 0x0073DCB4 File Offset: 0x0073BEB4
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042FF RID: 17151
		' (get) Token: 0x0600AD51 RID: 44369 RVA: 0x00050AB5 File Offset: 0x0004ECB5
		' (set) Token: 0x0600AD52 RID: 44370 RVA: 0x00050ABF File Offset: 0x0004ECBF
		Friend Overridable Property Label3 As Label

		' Token: 0x17004300 RID: 17152
		' (get) Token: 0x0600AD53 RID: 44371 RVA: 0x00050AC8 File Offset: 0x0004ECC8
		' (set) Token: 0x0600AD54 RID: 44372 RVA: 0x0073DCF8 File Offset: 0x0073BEF8
		Private _txtSubCategory As TextBox
		Friend Overridable Property txtSubCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSubCategory_KeyDown
				Dim textBox As TextBox = Me._txtSubCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSubCategory = value
				textBox = Me._txtSubCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004301 RID: 17153
		' (get) Token: 0x0600AD55 RID: 44373 RVA: 0x00050AD2 File Offset: 0x0004ECD2
		' (set) Token: 0x0600AD56 RID: 44374 RVA: 0x00050ADC File Offset: 0x0004ECDC
		Friend Overridable Property Label4 As Label

		' Token: 0x17004302 RID: 17154
		' (get) Token: 0x0600AD57 RID: 44375 RVA: 0x00050AE5 File Offset: 0x0004ECE5
		' (set) Token: 0x0600AD58 RID: 44376 RVA: 0x0073DD3C File Offset: 0x0073BF3C
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004303 RID: 17155
		' (get) Token: 0x0600AD59 RID: 44377 RVA: 0x00050AEF File Offset: 0x0004ECEF
		' (set) Token: 0x0600AD5A RID: 44378 RVA: 0x00050AF9 File Offset: 0x0004ECF9
		Friend Overridable Property Label5 As Label

		' Token: 0x17004304 RID: 17156
		' (get) Token: 0x0600AD5B RID: 44379 RVA: 0x00050B02 File Offset: 0x0004ED02
		' (set) Token: 0x0600AD5C RID: 44380 RVA: 0x00050B0C File Offset: 0x0004ED0C
		Friend Overridable Property Label1 As Label

		' Token: 0x17004305 RID: 17157
		' (get) Token: 0x0600AD5D RID: 44381 RVA: 0x00050B15 File Offset: 0x0004ED15
		' (set) Token: 0x0600AD5E RID: 44382 RVA: 0x0073DD80 File Offset: 0x0073BF80
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004306 RID: 17158
		' (get) Token: 0x0600AD5F RID: 44383 RVA: 0x00050B1F File Offset: 0x0004ED1F
		' (set) Token: 0x0600AD60 RID: 44384 RVA: 0x00050B29 File Offset: 0x0004ED29
		Friend Overridable Property Label6 As Label

		' Token: 0x17004307 RID: 17159
		' (get) Token: 0x0600AD61 RID: 44385 RVA: 0x00050B32 File Offset: 0x0004ED32
		' (set) Token: 0x0600AD62 RID: 44386 RVA: 0x00050B3C File Offset: 0x0004ED3C
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004308 RID: 17160
		' (get) Token: 0x0600AD63 RID: 44387 RVA: 0x00050B45 File Offset: 0x0004ED45
		' (set) Token: 0x0600AD64 RID: 44388 RVA: 0x0073DDC4 File Offset: 0x0073BFC4
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

		' Token: 0x17004309 RID: 17161
		' (get) Token: 0x0600AD65 RID: 44389 RVA: 0x00050B4F File Offset: 0x0004ED4F
		' (set) Token: 0x0600AD66 RID: 44390 RVA: 0x00050B59 File Offset: 0x0004ED59
		Friend Overridable Property Label7 As Label

		' Token: 0x1700430A RID: 17162
		' (get) Token: 0x0600AD67 RID: 44391 RVA: 0x00050B62 File Offset: 0x0004ED62
		' (set) Token: 0x0600AD68 RID: 44392 RVA: 0x00050B6C File Offset: 0x0004ED6C
		Friend Overridable Property Label9 As Label

		' Token: 0x1700430B RID: 17163
		' (get) Token: 0x0600AD69 RID: 44393 RVA: 0x00050B75 File Offset: 0x0004ED75
		' (set) Token: 0x0600AD6A RID: 44394 RVA: 0x0073DE08 File Offset: 0x0073C008
		Private _cmbRack As ComboBox
		Friend Overridable Property cmbRack As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbRack
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbRack_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbRack
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbRack = value
				comboBox = Me._cmbRack
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700430C RID: 17164
		' (get) Token: 0x0600AD6B RID: 44395 RVA: 0x00050B7F File Offset: 0x0004ED7F
		' (set) Token: 0x0600AD6C RID: 44396 RVA: 0x00050B89 File Offset: 0x0004ED89
		Friend Overridable Property Label8 As Label

		' Token: 0x1700430D RID: 17165
		' (get) Token: 0x0600AD6D RID: 44397 RVA: 0x00050B92 File Offset: 0x0004ED92
		' (set) Token: 0x0600AD6E RID: 44398 RVA: 0x0073DE4C File Offset: 0x0073C04C
		Private _cmbGDown As ComboBox
		Friend Overridable Property cmbGDown As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbGDown
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbGDown_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbGDown
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbGDown = value
				comboBox = Me._cmbGDown
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700430E RID: 17166
		' (get) Token: 0x0600AD6F RID: 44399 RVA: 0x00050B9C File Offset: 0x0004ED9C
		' (set) Token: 0x0600AD70 RID: 44400 RVA: 0x0073DE90 File Offset: 0x0073C090
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

		' Token: 0x1700430F RID: 17167
		' (get) Token: 0x0600AD71 RID: 44401 RVA: 0x00050BA6 File Offset: 0x0004EDA6
		' (set) Token: 0x0600AD72 RID: 44402 RVA: 0x00050BB0 File Offset: 0x0004EDB0
		Friend Overridable Property Label10 As Label

		' Token: 0x17004310 RID: 17168
		' (get) Token: 0x0600AD73 RID: 44403 RVA: 0x00050BB9 File Offset: 0x0004EDB9
		' (set) Token: 0x0600AD74 RID: 44404 RVA: 0x00050BC3 File Offset: 0x0004EDC3
		Friend Overridable Property Label11 As Label

		' Token: 0x17004311 RID: 17169
		' (get) Token: 0x0600AD75 RID: 44405 RVA: 0x00050BCC File Offset: 0x0004EDCC
		' (set) Token: 0x0600AD76 RID: 44406 RVA: 0x00050BD6 File Offset: 0x0004EDD6
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17004312 RID: 17170
		' (get) Token: 0x0600AD77 RID: 44407 RVA: 0x00050BDF File Offset: 0x0004EDDF
		' (set) Token: 0x0600AD78 RID: 44408 RVA: 0x0073DED4 File Offset: 0x0073C0D4
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

		' Token: 0x17004313 RID: 17171
		' (get) Token: 0x0600AD79 RID: 44409 RVA: 0x00050BE9 File Offset: 0x0004EDE9
		' (set) Token: 0x0600AD7A RID: 44410 RVA: 0x0073DF18 File Offset: 0x0073C118
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

		' Token: 0x17004314 RID: 17172
		' (get) Token: 0x0600AD7B RID: 44411 RVA: 0x00050BF3 File Offset: 0x0004EDF3
		' (set) Token: 0x0600AD7C RID: 44412 RVA: 0x0073DF5C File Offset: 0x0073C15C
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click_1
				Dim gelButton As GelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnShowAll = value
				gelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004315 RID: 17173
		' (get) Token: 0x0600AD7D RID: 44413 RVA: 0x00050BFD File Offset: 0x0004EDFD
		' (set) Token: 0x0600AD7E RID: 44414 RVA: 0x00050C07 File Offset: 0x0004EE07
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004316 RID: 17174
		' (get) Token: 0x0600AD7F RID: 44415 RVA: 0x00050C10 File Offset: 0x0004EE10
		' (set) Token: 0x0600AD80 RID: 44416 RVA: 0x00050C1A File Offset: 0x0004EE1A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004317 RID: 17175
		' (get) Token: 0x0600AD81 RID: 44417 RVA: 0x00050C23 File Offset: 0x0004EE23
		' (set) Token: 0x0600AD82 RID: 44418 RVA: 0x00050C2D File Offset: 0x0004EE2D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004318 RID: 17176
		' (get) Token: 0x0600AD83 RID: 44419 RVA: 0x00050C36 File Offset: 0x0004EE36
		' (set) Token: 0x0600AD84 RID: 44420 RVA: 0x00050C40 File Offset: 0x0004EE40
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004319 RID: 17177
		' (get) Token: 0x0600AD85 RID: 44421 RVA: 0x00050C49 File Offset: 0x0004EE49
		' (set) Token: 0x0600AD86 RID: 44422 RVA: 0x00050C53 File Offset: 0x0004EE53
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700431A RID: 17178
		' (get) Token: 0x0600AD87 RID: 44423 RVA: 0x00050C5C File Offset: 0x0004EE5C
		' (set) Token: 0x0600AD88 RID: 44424 RVA: 0x00050C66 File Offset: 0x0004EE66
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700431B RID: 17179
		' (get) Token: 0x0600AD89 RID: 44425 RVA: 0x00050C6F File Offset: 0x0004EE6F
		' (set) Token: 0x0600AD8A RID: 44426 RVA: 0x00050C79 File Offset: 0x0004EE79
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700431C RID: 17180
		' (get) Token: 0x0600AD8B RID: 44427 RVA: 0x00050C82 File Offset: 0x0004EE82
		' (set) Token: 0x0600AD8C RID: 44428 RVA: 0x00050C8C File Offset: 0x0004EE8C
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700431D RID: 17181
		' (get) Token: 0x0600AD8D RID: 44429 RVA: 0x00050C95 File Offset: 0x0004EE95
		' (set) Token: 0x0600AD8E RID: 44430 RVA: 0x00050C9F File Offset: 0x0004EE9F
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700431E RID: 17182
		' (get) Token: 0x0600AD8F RID: 44431 RVA: 0x00050CA8 File Offset: 0x0004EEA8
		' (set) Token: 0x0600AD90 RID: 44432 RVA: 0x00050CB2 File Offset: 0x0004EEB2
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700431F RID: 17183
		' (get) Token: 0x0600AD91 RID: 44433 RVA: 0x00050CBB File Offset: 0x0004EEBB
		' (set) Token: 0x0600AD92 RID: 44434 RVA: 0x00050CC5 File Offset: 0x0004EEC5
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004320 RID: 17184
		' (get) Token: 0x0600AD93 RID: 44435 RVA: 0x00050CCE File Offset: 0x0004EECE
		' (set) Token: 0x0600AD94 RID: 44436 RVA: 0x00050CD8 File Offset: 0x0004EED8
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004321 RID: 17185
		' (get) Token: 0x0600AD95 RID: 44437 RVA: 0x00050CE1 File Offset: 0x0004EEE1
		' (set) Token: 0x0600AD96 RID: 44438 RVA: 0x00050CEB File Offset: 0x0004EEEB
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004322 RID: 17186
		' (get) Token: 0x0600AD97 RID: 44439 RVA: 0x00050CF4 File Offset: 0x0004EEF4
		' (set) Token: 0x0600AD98 RID: 44440 RVA: 0x00050CFE File Offset: 0x0004EEFE
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17004323 RID: 17187
		' (get) Token: 0x0600AD99 RID: 44441 RVA: 0x00050D07 File Offset: 0x0004EF07
		' (set) Token: 0x0600AD9A RID: 44442 RVA: 0x00050D11 File Offset: 0x0004EF11
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17004324 RID: 17188
		' (get) Token: 0x0600AD9B RID: 44443 RVA: 0x00050D1A File Offset: 0x0004EF1A
		' (set) Token: 0x0600AD9C RID: 44444 RVA: 0x00050D24 File Offset: 0x0004EF24
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004325 RID: 17189
		' (get) Token: 0x0600AD9D RID: 44445 RVA: 0x00050D2D File Offset: 0x0004EF2D
		' (set) Token: 0x0600AD9E RID: 44446 RVA: 0x00050D37 File Offset: 0x0004EF37
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004326 RID: 17190
		' (get) Token: 0x0600AD9F RID: 44447 RVA: 0x00050D40 File Offset: 0x0004EF40
		' (set) Token: 0x0600ADA0 RID: 44448 RVA: 0x00050D4A File Offset: 0x0004EF4A
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004327 RID: 17191
		' (get) Token: 0x0600ADA1 RID: 44449 RVA: 0x00050D53 File Offset: 0x0004EF53
		' (set) Token: 0x0600ADA2 RID: 44450 RVA: 0x00050D5D File Offset: 0x0004EF5D
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004328 RID: 17192
		' (get) Token: 0x0600ADA3 RID: 44451 RVA: 0x00050D66 File Offset: 0x0004EF66
		' (set) Token: 0x0600ADA4 RID: 44452 RVA: 0x00050D70 File Offset: 0x0004EF70
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004329 RID: 17193
		' (get) Token: 0x0600ADA5 RID: 44453 RVA: 0x00050D79 File Offset: 0x0004EF79
		' (set) Token: 0x0600ADA6 RID: 44454 RVA: 0x00050D83 File Offset: 0x0004EF83
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700432A RID: 17194
		' (get) Token: 0x0600ADA7 RID: 44455 RVA: 0x00050D8C File Offset: 0x0004EF8C
		' (set) Token: 0x0600ADA8 RID: 44456 RVA: 0x00050D96 File Offset: 0x0004EF96
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700432B RID: 17195
		' (get) Token: 0x0600ADA9 RID: 44457 RVA: 0x00050D9F File Offset: 0x0004EF9F
		' (set) Token: 0x0600ADAA RID: 44458 RVA: 0x00050DA9 File Offset: 0x0004EFA9
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700432C RID: 17196
		' (get) Token: 0x0600ADAB RID: 44459 RVA: 0x00050DB2 File Offset: 0x0004EFB2
		' (set) Token: 0x0600ADAC RID: 44460 RVA: 0x00050DBC File Offset: 0x0004EFBC
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700432D RID: 17197
		' (get) Token: 0x0600ADAD RID: 44461 RVA: 0x00050DC5 File Offset: 0x0004EFC5
		' (set) Token: 0x0600ADAE RID: 44462 RVA: 0x00050DCF File Offset: 0x0004EFCF
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700432E RID: 17198
		' (get) Token: 0x0600ADAF RID: 44463 RVA: 0x00050DD8 File Offset: 0x0004EFD8
		' (set) Token: 0x0600ADB0 RID: 44464 RVA: 0x00050DE2 File Offset: 0x0004EFE2
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700432F RID: 17199
		' (get) Token: 0x0600ADB1 RID: 44465 RVA: 0x00050DEB File Offset: 0x0004EFEB
		' (set) Token: 0x0600ADB2 RID: 44466 RVA: 0x00050DF5 File Offset: 0x0004EFF5
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17004330 RID: 17200
		' (get) Token: 0x0600ADB3 RID: 44467 RVA: 0x00050DFE File Offset: 0x0004EFFE
		' (set) Token: 0x0600ADB4 RID: 44468 RVA: 0x00050E08 File Offset: 0x0004F008
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17004331 RID: 17201
		' (get) Token: 0x0600ADB5 RID: 44469 RVA: 0x00050E11 File Offset: 0x0004F011
		' (set) Token: 0x0600ADB6 RID: 44470 RVA: 0x00050E1B File Offset: 0x0004F01B
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17004332 RID: 17202
		' (get) Token: 0x0600ADB7 RID: 44471 RVA: 0x00050E24 File Offset: 0x0004F024
		' (set) Token: 0x0600ADB8 RID: 44472 RVA: 0x00050E2E File Offset: 0x0004F02E
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17004333 RID: 17203
		' (get) Token: 0x0600ADB9 RID: 44473 RVA: 0x00050E37 File Offset: 0x0004F037
		' (set) Token: 0x0600ADBA RID: 44474 RVA: 0x00050E41 File Offset: 0x0004F041
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17004334 RID: 17204
		' (get) Token: 0x0600ADBB RID: 44475 RVA: 0x00050E4A File Offset: 0x0004F04A
		' (set) Token: 0x0600ADBC RID: 44476 RVA: 0x00050E54 File Offset: 0x0004F054
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17004335 RID: 17205
		' (get) Token: 0x0600ADBD RID: 44477 RVA: 0x00050E5D File Offset: 0x0004F05D
		' (set) Token: 0x0600ADBE RID: 44478 RVA: 0x00050E67 File Offset: 0x0004F067
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17004336 RID: 17206
		' (get) Token: 0x0600ADBF RID: 44479 RVA: 0x00050E70 File Offset: 0x0004F070
		' (set) Token: 0x0600ADC0 RID: 44480 RVA: 0x00050E7A File Offset: 0x0004F07A
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17004337 RID: 17207
		' (get) Token: 0x0600ADC1 RID: 44481 RVA: 0x00050E83 File Offset: 0x0004F083
		' (set) Token: 0x0600ADC2 RID: 44482 RVA: 0x00050E8D File Offset: 0x0004F08D
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17004338 RID: 17208
		' (get) Token: 0x0600ADC3 RID: 44483 RVA: 0x00050E96 File Offset: 0x0004F096
		' (set) Token: 0x0600ADC4 RID: 44484 RVA: 0x00050EA0 File Offset: 0x0004F0A0
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17004339 RID: 17209
		' (get) Token: 0x0600ADC5 RID: 44485 RVA: 0x00050EA9 File Offset: 0x0004F0A9
		' (set) Token: 0x0600ADC6 RID: 44486 RVA: 0x00050EB3 File Offset: 0x0004F0B3
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700433A RID: 17210
		' (get) Token: 0x0600ADC7 RID: 44487 RVA: 0x00050EBC File Offset: 0x0004F0BC
		' (set) Token: 0x0600ADC8 RID: 44488 RVA: 0x00050EC6 File Offset: 0x0004F0C6
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700433B RID: 17211
		' (get) Token: 0x0600ADC9 RID: 44489 RVA: 0x00050ECF File Offset: 0x0004F0CF
		' (set) Token: 0x0600ADCA RID: 44490 RVA: 0x00050ED9 File Offset: 0x0004F0D9
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700433C RID: 17212
		' (get) Token: 0x0600ADCB RID: 44491 RVA: 0x00050EE2 File Offset: 0x0004F0E2
		' (set) Token: 0x0600ADCC RID: 44492 RVA: 0x00050EEC File Offset: 0x0004F0EC
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x1700433D RID: 17213
		' (get) Token: 0x0600ADCD RID: 44493 RVA: 0x00050EF5 File Offset: 0x0004F0F5
		' (set) Token: 0x0600ADCE RID: 44494 RVA: 0x00050EFF File Offset: 0x0004F0FF
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x0600ADCF RID: 44495 RVA: 0x0073DFA0 File Offset: 0x0073C1A0
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status),(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID order by ProductName", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADD0 RID: 44496 RVA: 0x0073E340 File Offset: 0x0073C540
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600ADD1 RID: 44497 RVA: 0x00050F08 File Offset: 0x0004F108
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0600ADD2 RID: 44498 RVA: 0x0073E368 File Offset: 0x0073C568
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Product Entry", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmProduct.Show()
						MyBase.Hide()
						MyProject.Forms.frmProduct.btnUpdate.Enabled = True
						MyProject.Forms.frmProduct.btnDelete.Enabled = True
						MyProject.Forms.frmProduct.btnSave.Enabled = False
						MyProject.Forms.frmProduct.txtOpeningStock.[ReadOnly] = True
						MyProject.Forms.frmProduct.txtOpeningStock.Enabled = False
						MyProject.Forms.frmProduct.Button6.Enabled = True
						MyProject.Forms.frmProduct.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmProduct.txtProductCode.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmProduct.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmProduct.txtPName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmProduct.txtSubCategoryID.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmProduct.cmbCategory.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmProduct.cmbSubCategory.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmProduct.txtHSNCode.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmProduct.txtPartNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmProduct.txtPNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmProduct.txtFeatures.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmProduct.txtCostPrice.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmProduct.txtRSPrice.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmProduct.txtDiscount.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmProduct.txtCGST.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmProduct.txtSGST.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmProduct.txtCESS.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmProduct.txtWSPrice.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmProduct.cmbPurchaseUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmProduct.cmbSalesUnit.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmProduct.cmbAltunit.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmProduct.TextBox1.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmProduct.txtMinStock.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmProduct.txtDefMRP.Text = dataGridViewRow.Cells(23).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(24).Value.ToString().TrimEnd(New Char(-1) {}), "Yes", False) = 0
						If flag3 Then
							MyProject.Forms.frmProduct.CheckBox4.Checked = True
						Else
							MyProject.Forms.frmProduct.CheckBox4.Checked = False
						End If
						MyProject.Forms.frmProduct.cmbSTax.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmProduct.cmbPTax.Text = dataGridViewRow.Cells(26).Value.ToString()
						MyProject.Forms.frmProduct.cmbGST.Text = Conversions.ToString(Conversion.Val(MyProject.Forms.frmProduct.txtIGST.Text))
						MyProject.Forms.frmProduct.cmbGdown.Text = dataGridViewRow.Cells(27).Value.ToString()
						MyProject.Forms.frmProduct.cmbRack.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmProduct.txtSaleQty.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmProduct.cmbKitchen.Text = dataGridViewRow.Cells(40).Value.ToString()
						MyProject.Forms.frmProduct.txtMRPMargin.Text = Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmProduct.txtDefMRP.Text) * 100.0 / Conversion.Val(MyProject.Forms.frmProduct.txtCostPrice.Text) - 100.0, 2), "")
						MyProject.Forms.frmProduct.txtSalePMargin.Text = Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmProduct.txtRSPrice.Text) * 100.0 / Conversion.Val(MyProject.Forms.frmProduct.txtCostPrice.Text) - 100.0, 2), "")
						MyProject.Forms.frmProduct.txtWMargin.Text = Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmProduct.txtWSPrice.Text) * 100.0 / Conversion.Val(MyProject.Forms.frmProduct.txtCostPrice.Text) - 100.0, 2), "")
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString())
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmProduct.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
							Dim memoryStream As MemoryStream = New MemoryStream(array)
							Dim image As Image = Image.FromStream(memoryStream)
							MyProject.Forms.frmProduct.dgw.Rows.Add(New Object() { image })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand("SELECT Qty,MRP,SalePrice,WSalePrice,RTRIM(Batch),Mfgdate,Expdate,RTRIM(Size),RtRIM(Colour),RtRIM(Barcode),RtRIM(RCipher),RtRIM(WCipher),RTRIM(Product_OpeningStock.Barcode),(Product_OpeningStock.PPrice),(Product_OpeningStock.OPSValue),RTRIM(Product_OpeningStock.IMEI1),RTRIM(Product_OpeningStock.IMEI2) from Product_OpeningStock where ProductID=@d1", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString())
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmProduct.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmProduct.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmProduct.DataGridView1.ClearSelection()
						MyProject.Forms.frmProduct.btnAddOS.Enabled = False
						MyProject.Forms.frmProduct.btnRemoveFromGridOS.Enabled = False
						Me.lblSet.Text = ""
					End If
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.lblSet.Text, "Quotation", False) = 0
				If flag4 Then
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag5 As Boolean = Operators.CompareString(dataGridViewRow2.Cells(24).Value.ToString().TrimEnd(New Char(-1) {}), "Yes", False) <> 0
					If flag5 Then
						MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					MyProject.Forms.frmQuotation.Show()
					MyBase.Hide()
					MyProject.Forms.frmQuotation.txtProductID.Text = dataGridViewRow2.Cells(0).Value.ToString()
					MyProject.Forms.frmQuotation.txtTaxType.Text = dataGridViewRow2.Cells(25).Value.ToString()
					MyProject.Forms.frmQuotation.txtHSNCode.Text = dataGridViewRow2.Cells(6).Value.ToString()
					MyProject.Forms.frmQuotation.cmbProductName.Text = dataGridViewRow2.Cells(2).Value.ToString()
					MyProject.Forms.frmQuotation.TextBox5.Text = dataGridViewRow2.Cells(2).Value.ToString()
					Dim checked As Boolean = MyProject.Forms.frmQuotation.RadioButton1.Checked
					If checked Then
						MyProject.Forms.frmQuotation.txtPricePerQty.Text = dataGridViewRow2.Cells(10).Value.ToString()
					Else
						Dim checked2 As Boolean = MyProject.Forms.frmQuotation.RadioButton2.Checked
						If checked2 Then
							MyProject.Forms.frmQuotation.txtPricePerQty.Text = dataGridViewRow2.Cells(15).Value.ToString()
						End If
					End If
					MyProject.Forms.frmQuotation.txtBarcode.Text = dataGridViewRow2.Cells(16).Value.ToString()
					MyProject.Forms.frmQuotation.txtDiscPer.Text = dataGridViewRow2.Cells(11).Value.ToString()
					MyProject.Forms.frmQuotation.lblUnit.Text = dataGridViewRow2.Cells(18).Value.ToString()
					MyProject.Forms.frmQuotation.cmbUnit.Text = dataGridViewRow2.Cells(18).Value.ToString()
					Dim flag6 As Boolean = (Operators.CompareString(MyProject.Forms.frmQuotation.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmQuotation.txtCustomerState.Text, MyProject.Forms.frmQuotation.txtCompanyState.Text, False) = 0)
					If flag6 Then
						MyProject.Forms.frmQuotation.txtCGSTPer.Text = dataGridViewRow2.Cells(12).Value.ToString()
						MyProject.Forms.frmQuotation.txtSGSTPer.Text = dataGridViewRow2.Cells(13).Value.ToString()
						MyProject.Forms.frmQuotation.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag7 As Boolean = (Operators.CompareString(MyProject.Forms.frmQuotation.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmQuotation.txtCustomerState.Text, MyProject.Forms.frmQuotation.txtCompanyState.Text, False) = 0)
						If flag7 Then
							MyProject.Forms.frmQuotation.txtCGSTPer.Text = dataGridViewRow2.Cells(12).Value.ToString()
							MyProject.Forms.frmQuotation.txtSGSTPer.Text = dataGridViewRow2.Cells(13).Value.ToString()
							MyProject.Forms.frmQuotation.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag8 As Boolean = (Operators.CompareString(MyProject.Forms.frmQuotation.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmQuotation.txtCustomerState.Text, MyProject.Forms.frmQuotation.txtCompanyState.Text, False) <> 0)
							If flag8 Then
								MyProject.Forms.frmQuotation.txtCGSTPer.Text = Conversions.ToString(0)
								MyProject.Forms.frmQuotation.txtSGSTPer.Text = Conversions.ToString(0)
								MyProject.Forms.frmQuotation.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(13).Value)))
							Else
								Dim flag9 As Boolean = (Operators.CompareString(MyProject.Forms.frmQuotation.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmQuotation.txtCustomerState.Text, MyProject.Forms.frmQuotation.txtCompanyState.Text, False) <> 0)
								If flag9 Then
									MyProject.Forms.frmQuotation.txtCGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmQuotation.txtSGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmQuotation.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(13).Value)))
								End If
							End If
						End If
					End If
					MyProject.Forms.frmQuotation.txtCESSPer.Text = dataGridViewRow2.Cells(14).Value.ToString()
					MyProject.Forms.frmQuotation.Calc()
					Me.lblSet.Text = ""
					MyProject.Forms.frmQuotation.btnProductSelection.Enabled = True
					MyProject.Forms.frmQuotation.txtQty.Focus()
					MyProject.Forms.frmQuotation.dgw4.Visible = False
				End If
				Dim flag10 As Boolean = Operators.CompareString(Me.lblSet.Text, "Estimate", False) = 0
				If flag10 Then
					Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag11 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(24).Value.ToString().TrimEnd(New Char(-1) {}), "Yes", False) <> 0
					If flag11 Then
						MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					MyProject.Forms.frmEstimate.Show()
					MyBase.Hide()
					MyProject.Forms.frmEstimate.txtProductID.Text = dataGridViewRow3.Cells(0).Value.ToString()
					MyProject.Forms.frmEstimate.cmbTaxType.Text = dataGridViewRow3.Cells(25).Value.ToString()
					MyProject.Forms.frmEstimate.txtHSNCode.Text = dataGridViewRow3.Cells(6).Value.ToString()
					MyProject.Forms.frmEstimate.cmbProductName.Text = dataGridViewRow3.Cells(2).Value.ToString()
					MyProject.Forms.frmEstimate.TextBox5.Text = dataGridViewRow3.Cells(2).Value.ToString()
					Dim checked3 As Boolean = MyProject.Forms.frmEstimate.RadioButton1.Checked
					If checked3 Then
						MyProject.Forms.frmEstimate.txtPricePerQty.Text = dataGridViewRow3.Cells(10).Value.ToString()
					Else
						Dim checked4 As Boolean = MyProject.Forms.frmEstimate.RadioButton2.Checked
						If checked4 Then
							MyProject.Forms.frmEstimate.txtPricePerQty.Text = dataGridViewRow3.Cells(15).Value.ToString()
						End If
					End If
					MyProject.Forms.frmEstimate.txtBarcode.Text = dataGridViewRow3.Cells(16).Value.ToString()
					MyProject.Forms.frmEstimate.TextBox6.Text = dataGridViewRow3.Cells(16).Value.ToString()
					MyProject.Forms.frmEstimate.txtQty.Text = "1"
					MyProject.Forms.frmEstimate.txtDiscPer.Text = dataGridViewRow3.Cells(11).Value.ToString()
					MyProject.Forms.frmEstimate.lblUnit.Text = dataGridViewRow3.Cells(18).Value.ToString()
					MyProject.Forms.frmEstimate.cmbUnit.Text = dataGridViewRow3.Cells(18).Value.ToString()
					Dim flag12 As Boolean = (Operators.CompareString(MyProject.Forms.frmEstimate.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmEstimate.txtCustomerState.Text, MyProject.Forms.frmEstimate.txtCompanyState.Text, False) = 0)
					If flag12 Then
						MyProject.Forms.frmEstimate.txtCGSTPer.Text = dataGridViewRow3.Cells(12).Value.ToString()
						MyProject.Forms.frmEstimate.txtSGSTPer.Text = dataGridViewRow3.Cells(13).Value.ToString()
						MyProject.Forms.frmEstimate.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag13 As Boolean = (Operators.CompareString(MyProject.Forms.frmEstimate.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmEstimate.txtCustomerState.Text, MyProject.Forms.frmEstimate.txtCompanyState.Text, False) = 0)
						If flag13 Then
							MyProject.Forms.frmEstimate.txtCGSTPer.Text = dataGridViewRow3.Cells(12).Value.ToString()
							MyProject.Forms.frmEstimate.txtSGSTPer.Text = dataGridViewRow3.Cells(13).Value.ToString()
							MyProject.Forms.frmEstimate.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag14 As Boolean = (Operators.CompareString(MyProject.Forms.frmEstimate.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmEstimate.txtCustomerState.Text, MyProject.Forms.frmEstimate.txtCompanyState.Text, False) <> 0)
							If flag14 Then
								MyProject.Forms.frmEstimate.txtCGSTPer.Text = Conversions.ToString(0)
								MyProject.Forms.frmEstimate.txtSGSTPer.Text = Conversions.ToString(0)
								MyProject.Forms.frmEstimate.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(13).Value)))
							Else
								Dim flag15 As Boolean = (Operators.CompareString(MyProject.Forms.frmEstimate.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmEstimate.txtCustomerState.Text, MyProject.Forms.frmEstimate.txtCompanyState.Text, False) <> 0)
								If flag15 Then
									MyProject.Forms.frmEstimate.txtCGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmEstimate.txtSGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmEstimate.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(13).Value)))
								End If
							End If
						End If
					End If
					MyProject.Forms.frmEstimate.txtCESSPer.Text = dataGridViewRow3.Cells(14).Value.ToString()
					MyProject.Forms.frmEstimate.currentstock()
					MyProject.Forms.frmEstimate.Calc()
					Me.lblSet.Text = ""
					MyProject.Forms.frmEstimate.btnProductSelection.Enabled = True
					MyProject.Forms.frmEstimate.txtQty.Focus()
					MyProject.Forms.frmEstimate.dgw4.Visible = False
				End If
				Dim flag16 As Boolean = Operators.CompareString(Me.lblSet.Text, "Stock", False) = 0
				If flag16 Then
					Dim dataGridViewRow4 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag17 As Boolean = Operators.CompareString(dataGridViewRow4.Cells(24).Value.ToString().TrimEnd(New Char(-1) {}), "Yes", False) <> 0
					If flag17 Then
						MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					MyProject.Forms.frmPurchaseEntry.Show()
					MyBase.Hide()
					MyProject.Forms.frmPurchaseEntry.txtProductID.Text = dataGridViewRow4.Cells(0).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.lblPTaxType.Text = dataGridViewRow4.Cells(26).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtHSNCode.Text = dataGridViewRow4.Cells(6).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbProductName.Text = dataGridViewRow4.Cells(2).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.TextBox5.Text = dataGridViewRow4.Cells(2).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtPricePerQty.Text = dataGridViewRow4.Cells(9).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtBarcode.Text = dataGridViewRow4.Cells(16).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.lblUnit.Text = dataGridViewRow4.Cells(18).Value.ToString()
					Dim flag18 As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseEntry.txtState.Text, MyProject.Forms.frmPurchaseEntry.txtCompanyState.Text, False) = 0
					If flag18 Then
						MyProject.Forms.frmPurchaseEntry.txtCGSTPer.Text = dataGridViewRow4.Cells(12).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSGSTPer.Text = dataGridViewRow4.Cells(13).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag19 As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseEntry.txtState.Text, MyProject.Forms.frmPurchaseEntry.txtCompanyState.Text, False) <> 0
						If flag19 Then
							MyProject.Forms.frmPurchaseEntry.txtCGSTPer.Text = Conversions.ToString(0)
							MyProject.Forms.frmPurchaseEntry.txtSGSTPer.Text = Conversions.ToString(0)
							MyProject.Forms.frmPurchaseEntry.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(13).Value)))
						End If
					End If
					MyProject.Forms.frmPurchaseEntry.txtCESSPer.Text = dataGridViewRow4.Cells(14).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtRetail.Text = dataGridViewRow4.Cells(10).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtWholesale.Text = dataGridViewRow4.Cells(15).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtQty.Focus()
					Me.lblSet.Text = ""
					MyProject.Forms.frmPurchaseEntry.dgw4.Visible = False
				End If
				Dim flag20 As Boolean = Operators.CompareString(Me.lblSet.Text, "PO", False) = 0
				If flag20 Then
					Dim dataGridViewRow5 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag21 As Boolean = Operators.CompareString(dataGridViewRow5.Cells(24).Value.ToString().TrimEnd(New Char(-1) {}), "Yes", False) <> 0
					If flag21 Then
						MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					MyProject.Forms.frmPurchaseOrder.Show()
					MyBase.Hide()
					MyProject.Forms.frmPurchaseOrder.txtProductID.Text = dataGridViewRow5.Cells(0).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtTaxType.Text = dataGridViewRow5.Cells(26).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtHSNCode.Text = dataGridViewRow5.Cells(6).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtProductName.Text = dataGridViewRow5.Cells(2).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtPricePerQty.Text = dataGridViewRow5.Cells(9).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.lblUnit.Text = dataGridViewRow5.Cells(18).Value.ToString()
					Dim flag22 As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseOrder.txtState.Text, MyProject.Forms.frmPurchaseOrder.txtCompanyState.Text, False) = 0
					If flag22 Then
						MyProject.Forms.frmPurchaseOrder.txtCGSTPer.Text = dataGridViewRow5.Cells(12).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSGSTPer.Text = dataGridViewRow5.Cells(13).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag23 As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseOrder.txtState.Text, MyProject.Forms.frmPurchaseOrder.txtCompanyState.Text, False) <> 0
						If flag23 Then
							MyProject.Forms.frmPurchaseOrder.txtCGSTPer.Text = Conversions.ToString(0)
							MyProject.Forms.frmPurchaseOrder.txtSGSTPer.Text = Conversions.ToString(0)
							MyProject.Forms.frmPurchaseOrder.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(12).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(13).Value)))
						End If
					End If
					MyProject.Forms.frmPurchaseOrder.txtCESSPer.Text = dataGridViewRow5.Cells(14).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtRetail.Text = dataGridViewRow5.Cells(10).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtWholesale.Text = dataGridViewRow5.Cells(15).Value.ToString()
					MyProject.Forms.frmPurchaseOrder.txtQty.Focus()
					MyProject.Forms.frmPurchaseOrder.GetQty_S()
					Me.lblSet.Text = ""
				End If
				Dim flag24 As Boolean = Operators.CompareString(Me.lblSet.Text, "Promotion", False) = 0
				If flag24 Then
					Dim dataGridViewRow6 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyBase.Hide()
					MyProject.Forms.frmPromotionalOffers.Show()
					MyProject.Forms.frmPromotionalOffers.txtProductID.Text = dataGridViewRow6.Cells(0).Value.ToString()
					MyProject.Forms.frmPromotionalOffers.txtProductCode.Text = dataGridViewRow6.Cells(1).Value.ToString()
					MyProject.Forms.frmPromotionalOffers.txtProductName.Text = dataGridViewRow6.Cells(2).Value.ToString()
					Me.lblSet.Text = ""
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ADD3 RID: 44499 RVA: 0x00740594 File Offset: 0x0073E794
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

		' Token: 0x0600ADD4 RID: 44500 RVA: 0x0074067C File Offset: 0x0073E87C
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.txtCategory.Text = ""
			Me.txtSubCategory.Text = ""
			Me.txtBarcode.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.cmbGDown.SelectedIndex = -1
			Me.cmbRack.SelectedIndex = -1
			Me.txtTopResult.Text = "10"
			Me.dgw.Rows.Clear()
			Me.dgw.ClearSelection()
			Me.btnShowAll.Focus()
		End Sub

		' Token: 0x0600ADD5 RID: 44501 RVA: 0x00050F12 File Offset: 0x0004F112
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600ADD6 RID: 44502 RVA: 0x00740730 File Offset: 0x0073E930
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

		' Token: 0x0600ADD7 RID: 44503 RVA: 0x007409DC File Offset: 0x0073EBDC
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode like N'", Me.txtBarcode.Text, "' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADD8 RID: 44504 RVA: 0x00740D90 File Offset: 0x0073EF90
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.Getdata()
				Me.dgw.Focus()
			End If
		End Sub

		' Token: 0x0600ADD9 RID: 44505 RVA: 0x00740DCC File Offset: 0x0073EFCC
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and ProductName like N'", Me.txtProductName.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADDA RID: 44506 RVA: 0x00741180 File Offset: 0x0073F380
		Private Sub txtCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and CategoryName like N'", Me.txtCategory.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADDB RID: 44507 RVA: 0x00741534 File Offset: 0x0073F734
		Private Sub txtSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and SubCategoryName like N'", Me.txtSubCategory.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADDC RID: 44508 RVA: 0x007418E8 File Offset: 0x0073FAE8
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and PartNo like N'", Me.TextBox1.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADDD RID: 44509 RVA: 0x00741C9C File Offset: 0x0073FE9C
		Private Sub frmProductRecord_Load(sender As Object, e As EventArgs)
			Me.btnShowAll.Focus()
			Me.txtProductName.Text = ""
			Me.txtCategory.Text = ""
			Me.txtSubCategory.Text = ""
			Me.txtBarcode.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.dgw.Rows.Clear()
			Me.dgw.ClearSelection()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.fillGdown()
			Me.fillRack()
			Me.cmbGDown.SelectedIndex = -1
			Me.cmbRack.SelectedIndex = -1
			Me.Convert_Language()
		End Sub

		' Token: 0x0600ADDE RID: 44510 RVA: 0x00741DC0 File Offset: 0x0073FFC0
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

		' Token: 0x0600ADDF RID: 44511 RVA: 0x00741F38 File Offset: 0x00740138
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

		' Token: 0x0600ADE0 RID: 44512 RVA: 0x00742004 File Offset: 0x00740204
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

		' Token: 0x0600ADE1 RID: 44513 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600ADE2 RID: 44514 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600ADE3 RID: 44515 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ADE4 RID: 44516 RVA: 0x007420D0 File Offset: 0x007402D0
		Private Sub frmProductRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F1
			If flag3 Then
				e.Handled = True
				Me.btnShowAll.PerformClick()
				Me.dgw.Focus()
			End If
		End Sub

		' Token: 0x0600ADE5 RID: 44517 RVA: 0x0074214C File Offset: 0x0074034C
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='No' order by ProductName", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ADE6 RID: 44518 RVA: 0x00742504 File Offset: 0x00740704
		Private Sub cmbGDown_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and GDown like N'", Me.cmbGDown.Text, "' order by ProductName" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADE7 RID: 44519 RVA: 0x007428A4 File Offset: 0x00740AA4
		Private Sub cmbRack_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Rack like N'", Me.cmbRack.Text, "' order by ProductName" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADE8 RID: 44520 RVA: 0x00742C44 File Offset: 0x00740E44
		Public Sub fillGdown()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GDown) FROM Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbGDown.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbGDown.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.cmbGDown.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADE9 RID: 44521 RVA: 0x00742D84 File Offset: 0x00740F84
		Public Sub fillRack()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Rack) FROM Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbRack.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbRack.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.cmbRack.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ADEA RID: 44522 RVA: 0x00050F1C File Offset: 0x0004F11C
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600ADEB RID: 44523 RVA: 0x00050F12 File Offset: 0x0004F112
		Private Sub btnReset_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600ADEC RID: 44524 RVA: 0x00740730 File Offset: 0x0073E930
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

		' Token: 0x0600ADED RID: 44525 RVA: 0x00740D90 File Offset: 0x0073EF90
		Private Sub btnShowAll_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.Getdata()
				Me.dgw.Focus()
			End If
		End Sub
	End Class
End Namespace
