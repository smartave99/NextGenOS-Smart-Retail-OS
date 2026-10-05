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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C0 RID: 1216
	<DesignerGenerated()>
	Public Partial Class frmCustomerValid
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F37D RID: 62333 RVA: 0x0006A94B File Offset: 0x00068B4B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerValid_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerValid_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D34 RID: 23860
		' (get) Token: 0x0600F380 RID: 62336 RVA: 0x0006A97D File Offset: 0x00068B7D
		' (set) Token: 0x0600F381 RID: 62337 RVA: 0x0006A987 File Offset: 0x00068B87
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005D35 RID: 23861
		' (get) Token: 0x0600F382 RID: 62338 RVA: 0x0006A990 File Offset: 0x00068B90
		' (set) Token: 0x0600F383 RID: 62339 RVA: 0x0006A99A File Offset: 0x00068B9A
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D36 RID: 23862
		' (get) Token: 0x0600F384 RID: 62340 RVA: 0x0006A9A3 File Offset: 0x00068BA3
		' (set) Token: 0x0600F385 RID: 62341 RVA: 0x0006A9AD File Offset: 0x00068BAD
		Friend Overridable Property lblUser As Label

		' Token: 0x17005D37 RID: 23863
		' (get) Token: 0x0600F386 RID: 62342 RVA: 0x0006A9B6 File Offset: 0x00068BB6
		' (set) Token: 0x0600F387 RID: 62343 RVA: 0x009227EC File Offset: 0x009209EC
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

		' Token: 0x17005D38 RID: 23864
		' (get) Token: 0x0600F388 RID: 62344 RVA: 0x0006A9C0 File Offset: 0x00068BC0
		' (set) Token: 0x0600F389 RID: 62345 RVA: 0x0006A9CA File Offset: 0x00068BCA
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005D39 RID: 23865
		' (get) Token: 0x0600F38A RID: 62346 RVA: 0x0006A9D3 File Offset: 0x00068BD3
		' (set) Token: 0x0600F38B RID: 62347 RVA: 0x0006A9DD File Offset: 0x00068BDD
		Friend Overridable Property Label3 As Label

		' Token: 0x17005D3A RID: 23866
		' (get) Token: 0x0600F38C RID: 62348 RVA: 0x0006A9E6 File Offset: 0x00068BE6
		' (set) Token: 0x0600F38D RID: 62349 RVA: 0x0092284C File Offset: 0x00920A4C
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

		' Token: 0x17005D3B RID: 23867
		' (get) Token: 0x0600F38E RID: 62350 RVA: 0x0006A9F0 File Offset: 0x00068BF0
		' (set) Token: 0x0600F38F RID: 62351 RVA: 0x0006A9FA File Offset: 0x00068BFA
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D3C RID: 23868
		' (get) Token: 0x0600F390 RID: 62352 RVA: 0x0006AA03 File Offset: 0x00068C03
		' (set) Token: 0x0600F391 RID: 62353 RVA: 0x009228AC File Offset: 0x00920AAC
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

		' Token: 0x17005D3D RID: 23869
		' (get) Token: 0x0600F392 RID: 62354 RVA: 0x0006AA0D File Offset: 0x00068C0D
		' (set) Token: 0x0600F393 RID: 62355 RVA: 0x0006AA17 File Offset: 0x00068C17
		Friend Overridable Property Label14 As Label

		' Token: 0x17005D3E RID: 23870
		' (get) Token: 0x0600F394 RID: 62356 RVA: 0x0006AA20 File Offset: 0x00068C20
		' (set) Token: 0x0600F395 RID: 62357 RVA: 0x0092290C File Offset: 0x00920B0C
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

		' Token: 0x17005D3F RID: 23871
		' (get) Token: 0x0600F396 RID: 62358 RVA: 0x0006AA2A File Offset: 0x00068C2A
		' (set) Token: 0x0600F397 RID: 62359 RVA: 0x0006AA34 File Offset: 0x00068C34
		Friend Overridable Property Label5 As Label

		' Token: 0x17005D40 RID: 23872
		' (get) Token: 0x0600F398 RID: 62360 RVA: 0x0006AA3D File Offset: 0x00068C3D
		' (set) Token: 0x0600F399 RID: 62361 RVA: 0x0006AA47 File Offset: 0x00068C47
		Friend Overridable Property Label4 As Label

		' Token: 0x17005D41 RID: 23873
		' (get) Token: 0x0600F39A RID: 62362 RVA: 0x0006AA50 File Offset: 0x00068C50
		' (set) Token: 0x0600F39B RID: 62363 RVA: 0x0092296C File Offset: 0x00920B6C
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

		' Token: 0x17005D42 RID: 23874
		' (get) Token: 0x0600F39C RID: 62364 RVA: 0x0006AA5A File Offset: 0x00068C5A
		' (set) Token: 0x0600F39D RID: 62365 RVA: 0x009229B0 File Offset: 0x00920BB0
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

		' Token: 0x17005D43 RID: 23875
		' (get) Token: 0x0600F39E RID: 62366 RVA: 0x0006AA64 File Offset: 0x00068C64
		' (set) Token: 0x0600F39F RID: 62367 RVA: 0x0006AA6E File Offset: 0x00068C6E
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005D44 RID: 23876
		' (get) Token: 0x0600F3A0 RID: 62368 RVA: 0x0006AA77 File Offset: 0x00068C77
		' (set) Token: 0x0600F3A1 RID: 62369 RVA: 0x009229F4 File Offset: 0x00920BF4
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

		' Token: 0x17005D45 RID: 23877
		' (get) Token: 0x0600F3A2 RID: 62370 RVA: 0x0006AA81 File Offset: 0x00068C81
		' (set) Token: 0x0600F3A3 RID: 62371 RVA: 0x00922A38 File Offset: 0x00920C38
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

		' Token: 0x17005D46 RID: 23878
		' (get) Token: 0x0600F3A4 RID: 62372 RVA: 0x0006AA8B File Offset: 0x00068C8B
		' (set) Token: 0x0600F3A5 RID: 62373 RVA: 0x00922A7C File Offset: 0x00920C7C
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

		' Token: 0x17005D47 RID: 23879
		' (get) Token: 0x0600F3A6 RID: 62374 RVA: 0x0006AA95 File Offset: 0x00068C95
		' (set) Token: 0x0600F3A7 RID: 62375 RVA: 0x00922AC0 File Offset: 0x00920CC0
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

		' Token: 0x17005D48 RID: 23880
		' (get) Token: 0x0600F3A8 RID: 62376 RVA: 0x0006AA9F File Offset: 0x00068C9F
		' (set) Token: 0x0600F3A9 RID: 62377 RVA: 0x0006AAA9 File Offset: 0x00068CA9
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005D49 RID: 23881
		' (get) Token: 0x0600F3AA RID: 62378 RVA: 0x0006AAB2 File Offset: 0x00068CB2
		' (set) Token: 0x0600F3AB RID: 62379 RVA: 0x0006AABC File Offset: 0x00068CBC
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005D4A RID: 23882
		' (get) Token: 0x0600F3AC RID: 62380 RVA: 0x0006AAC5 File Offset: 0x00068CC5
		' (set) Token: 0x0600F3AD RID: 62381 RVA: 0x0006AACF File Offset: 0x00068CCF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005D4B RID: 23883
		' (get) Token: 0x0600F3AE RID: 62382 RVA: 0x0006AAD8 File Offset: 0x00068CD8
		' (set) Token: 0x0600F3AF RID: 62383 RVA: 0x0006AAE2 File Offset: 0x00068CE2
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005D4C RID: 23884
		' (get) Token: 0x0600F3B0 RID: 62384 RVA: 0x0006AAEB File Offset: 0x00068CEB
		' (set) Token: 0x0600F3B1 RID: 62385 RVA: 0x0006AAF5 File Offset: 0x00068CF5
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005D4D RID: 23885
		' (get) Token: 0x0600F3B2 RID: 62386 RVA: 0x0006AAFE File Offset: 0x00068CFE
		' (set) Token: 0x0600F3B3 RID: 62387 RVA: 0x0006AB08 File Offset: 0x00068D08
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005D4E RID: 23886
		' (get) Token: 0x0600F3B4 RID: 62388 RVA: 0x0006AB11 File Offset: 0x00068D11
		' (set) Token: 0x0600F3B5 RID: 62389 RVA: 0x0006AB1B File Offset: 0x00068D1B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005D4F RID: 23887
		' (get) Token: 0x0600F3B6 RID: 62390 RVA: 0x0006AB24 File Offset: 0x00068D24
		' (set) Token: 0x0600F3B7 RID: 62391 RVA: 0x0006AB2E File Offset: 0x00068D2E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005D50 RID: 23888
		' (get) Token: 0x0600F3B8 RID: 62392 RVA: 0x0006AB37 File Offset: 0x00068D37
		' (set) Token: 0x0600F3B9 RID: 62393 RVA: 0x0006AB41 File Offset: 0x00068D41
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005D51 RID: 23889
		' (get) Token: 0x0600F3BA RID: 62394 RVA: 0x0006AB4A File Offset: 0x00068D4A
		' (set) Token: 0x0600F3BB RID: 62395 RVA: 0x0006AB54 File Offset: 0x00068D54
		Friend Overridable Property lblOfferDetail As Label

		' Token: 0x17005D52 RID: 23890
		' (get) Token: 0x0600F3BC RID: 62396 RVA: 0x0006AB5D File Offset: 0x00068D5D
		' (set) Token: 0x0600F3BD RID: 62397 RVA: 0x0006AB67 File Offset: 0x00068D67
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005D53 RID: 23891
		' (get) Token: 0x0600F3BE RID: 62398 RVA: 0x0006AB70 File Offset: 0x00068D70
		' (set) Token: 0x0600F3BF RID: 62399 RVA: 0x0006AB7A File Offset: 0x00068D7A
		Friend Overridable Property lblDiscAmt As Label

		' Token: 0x17005D54 RID: 23892
		' (get) Token: 0x0600F3C0 RID: 62400 RVA: 0x0006AB83 File Offset: 0x00068D83
		' (set) Token: 0x0600F3C1 RID: 62401 RVA: 0x0006AB8D File Offset: 0x00068D8D
		Friend Overridable Property lblValid As Label

		' Token: 0x17005D55 RID: 23893
		' (get) Token: 0x0600F3C2 RID: 62402 RVA: 0x0006AB96 File Offset: 0x00068D96
		' (set) Token: 0x0600F3C3 RID: 62403 RVA: 0x0006ABA0 File Offset: 0x00068DA0
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17005D56 RID: 23894
		' (get) Token: 0x0600F3C4 RID: 62404 RVA: 0x0006ABA9 File Offset: 0x00068DA9
		' (set) Token: 0x0600F3C5 RID: 62405 RVA: 0x00922B04 File Offset: 0x00920D04
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

		' Token: 0x17005D57 RID: 23895
		' (get) Token: 0x0600F3C6 RID: 62406 RVA: 0x0006ABB3 File Offset: 0x00068DB3
		' (set) Token: 0x0600F3C7 RID: 62407 RVA: 0x00922B48 File Offset: 0x00920D48
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

		' Token: 0x17005D58 RID: 23896
		' (get) Token: 0x0600F3C8 RID: 62408 RVA: 0x0006ABBD File Offset: 0x00068DBD
		' (set) Token: 0x0600F3C9 RID: 62409 RVA: 0x0006ABC7 File Offset: 0x00068DC7
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17005D59 RID: 23897
		' (get) Token: 0x0600F3CA RID: 62410 RVA: 0x0006ABD0 File Offset: 0x00068DD0
		' (set) Token: 0x0600F3CB RID: 62411 RVA: 0x00922B8C File Offset: 0x00920D8C
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

		' Token: 0x17005D5A RID: 23898
		' (get) Token: 0x0600F3CC RID: 62412 RVA: 0x0006ABDA File Offset: 0x00068DDA
		' (set) Token: 0x0600F3CD RID: 62413 RVA: 0x00922BD0 File Offset: 0x00920DD0
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

		' Token: 0x0600F3CE RID: 62414 RVA: 0x00922C14 File Offset: 0x00920E14
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

		' Token: 0x0600F3CF RID: 62415 RVA: 0x0006ABE4 File Offset: 0x00068DE4
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F3D0 RID: 62416 RVA: 0x00922CF8 File Offset: 0x00920EF8
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
							Dim text As String = "insert into CustomerOffer (SellAmountFrom, SellAmountTo,DiscPerc, FromDate, ToDate) VALUES (@d1, @d2, @d3, @d4, @d5)"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSaleAmtFrom.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtSaleAmtTo.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtFreeRs.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDateFrom.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpDateTo.Value.[Date])
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "Added the new offer '" + Me.txtFreeRs.Text + "'")
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

		' Token: 0x0600F3D1 RID: 62417 RVA: 0x00922FA4 File Offset: 0x009211A4
		Private Sub frmCustomerValid_Load(sender As Object, e As EventArgs)
			Me.CompanyInfoDisplay()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F3D2 RID: 62418 RVA: 0x00923034 File Offset: 0x00921234
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

		' Token: 0x0600F3D3 RID: 62419 RVA: 0x009232D4 File Offset: 0x009214D4
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

		' Token: 0x0600F3D4 RID: 62420 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F3D5 RID: 62421 RVA: 0x00923390 File Offset: 0x00921590
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

		' Token: 0x0600F3D6 RID: 62422 RVA: 0x00923478 File Offset: 0x00921678
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
							Dim text As String = "UPDATE CustomerOffer SET SellAmountFrom=@d1,  SellAmountTo=@d2, DiscPerc=@d3, FromDate=@d4, ToDate=@d5 WHERE OfferId=@d6"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSaleAmtFrom.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtSaleAmtTo.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtFreeRs.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDateFrom.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpDateTo.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtID.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModFunc.LogFunc(Me.lblUser.Text, "Updated the offer '" + Me.txtFreeRs.Text + "'")
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

		' Token: 0x0600F3D7 RID: 62423 RVA: 0x00923738 File Offset: 0x00921938
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM CustomerOffer WHERE OfferId=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModFunc.LogFunc(Me.lblUser.Text, "Deleted the Offer '" + Me.txtFreeRs.Text + "'")
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

		' Token: 0x0600F3D8 RID: 62424 RVA: 0x00923850 File Offset: 0x00921A50
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

		' Token: 0x0600F3D9 RID: 62425 RVA: 0x009238BC File Offset: 0x00921ABC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT OfferId, SellAmountFrom, SellAmountTo, DiscPerc, FromDate,ToDate FROM CustomerOffer ORDER BY OfferId", ModCommonClasses.con)
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

		' Token: 0x0600F3DA RID: 62426 RVA: 0x009239E4 File Offset: 0x00921BE4
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

		' Token: 0x0600F3DB RID: 62427 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSaleAmtFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F3DC RID: 62428 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSaleAmtTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F3DD RID: 62429 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFreeRs_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F3DE RID: 62430 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F3DF RID: 62431 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDateTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F3E0 RID: 62432 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x0600F3E1 RID: 62433 RVA: 0x00923C30 File Offset: 0x00921E30
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

		' Token: 0x0600F3E2 RID: 62434 RVA: 0x00923D24 File Offset: 0x00921F24
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

		' Token: 0x0600F3E3 RID: 62435 RVA: 0x00923E14 File Offset: 0x00922014
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

		' Token: 0x0600F3E4 RID: 62436 RVA: 0x0006ABEE File Offset: 0x00068DEE
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Panel6.BackgroundImage = Resources.offer
		End Sub

		' Token: 0x0600F3E5 RID: 62437 RVA: 0x00923EB4 File Offset: 0x009220B4
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

		' Token: 0x0600F3E6 RID: 62438 RVA: 0x00010F3E File Offset: 0x0000F13E
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x04005D3A RID: 23866
		Private CurSym As String
	End Class
End Namespace
