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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001D9 RID: 473
	<DesignerGenerated()>
	Public Partial Class frmProductDiscount
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007E28 RID: 32296 RVA: 0x0003DFBA File Offset: 0x0003C1BA
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductDiscount_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002E43 RID: 11843
		' (get) Token: 0x06007E2B RID: 32299 RVA: 0x0003DFDA File Offset: 0x0003C1DA
		' (set) Token: 0x06007E2C RID: 32300 RVA: 0x005E1940 File Offset: 0x005DFB40
		Private _btnClear As GelButton
		Friend Overridable Property btnClear As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim gelButton As GelButton = Me._btnClear
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnClear = value
				gelButton = Me._btnClear
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E44 RID: 11844
		' (get) Token: 0x06007E2D RID: 32301 RVA: 0x0003DFE4 File Offset: 0x0003C1E4
		' (set) Token: 0x06007E2E RID: 32302 RVA: 0x0003DFEE File Offset: 0x0003C1EE
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17002E45 RID: 11845
		' (get) Token: 0x06007E2F RID: 32303 RVA: 0x0003DFF7 File Offset: 0x0003C1F7
		' (set) Token: 0x06007E30 RID: 32304 RVA: 0x0003E001 File Offset: 0x0003C201
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17002E46 RID: 11846
		' (get) Token: 0x06007E31 RID: 32305 RVA: 0x0003E00A File Offset: 0x0003C20A
		' (set) Token: 0x06007E32 RID: 32306 RVA: 0x0003E014 File Offset: 0x0003C214
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17002E47 RID: 11847
		' (get) Token: 0x06007E33 RID: 32307 RVA: 0x0003E01D File Offset: 0x0003C21D
		' (set) Token: 0x06007E34 RID: 32308 RVA: 0x0003E027 File Offset: 0x0003C227
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17002E48 RID: 11848
		' (get) Token: 0x06007E35 RID: 32309 RVA: 0x0003E030 File Offset: 0x0003C230
		' (set) Token: 0x06007E36 RID: 32310 RVA: 0x0003E03A File Offset: 0x0003C23A
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17002E49 RID: 11849
		' (get) Token: 0x06007E37 RID: 32311 RVA: 0x0003E043 File Offset: 0x0003C243
		' (set) Token: 0x06007E38 RID: 32312 RVA: 0x0003E04D File Offset: 0x0003C24D
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17002E4A RID: 11850
		' (get) Token: 0x06007E39 RID: 32313 RVA: 0x0003E056 File Offset: 0x0003C256
		' (set) Token: 0x06007E3A RID: 32314 RVA: 0x0003E060 File Offset: 0x0003C260
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17002E4B RID: 11851
		' (get) Token: 0x06007E3B RID: 32315 RVA: 0x0003E069 File Offset: 0x0003C269
		' (set) Token: 0x06007E3C RID: 32316 RVA: 0x0003E073 File Offset: 0x0003C273
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17002E4C RID: 11852
		' (get) Token: 0x06007E3D RID: 32317 RVA: 0x0003E07C File Offset: 0x0003C27C
		' (set) Token: 0x06007E3E RID: 32318 RVA: 0x0003E086 File Offset: 0x0003C286
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17002E4D RID: 11853
		' (get) Token: 0x06007E3F RID: 32319 RVA: 0x0003E08F File Offset: 0x0003C28F
		' (set) Token: 0x06007E40 RID: 32320 RVA: 0x0003E099 File Offset: 0x0003C299
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x17002E4E RID: 11854
		' (get) Token: 0x06007E41 RID: 32321 RVA: 0x0003E0A2 File Offset: 0x0003C2A2
		' (set) Token: 0x06007E42 RID: 32322 RVA: 0x0003E0AC File Offset: 0x0003C2AC
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x17002E4F RID: 11855
		' (get) Token: 0x06007E43 RID: 32323 RVA: 0x0003E0B5 File Offset: 0x0003C2B5
		' (set) Token: 0x06007E44 RID: 32324 RVA: 0x0003E0BF File Offset: 0x0003C2BF
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x17002E50 RID: 11856
		' (get) Token: 0x06007E45 RID: 32325 RVA: 0x0003E0C8 File Offset: 0x0003C2C8
		' (set) Token: 0x06007E46 RID: 32326 RVA: 0x0003E0D2 File Offset: 0x0003C2D2
		Friend Overridable Property txtComboPackID As TextBox

		' Token: 0x17002E51 RID: 11857
		' (get) Token: 0x06007E47 RID: 32327 RVA: 0x0003E0DB File Offset: 0x0003C2DB
		' (set) Token: 0x06007E48 RID: 32328 RVA: 0x0003E0E5 File Offset: 0x0003C2E5
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x17002E52 RID: 11858
		' (get) Token: 0x06007E49 RID: 32329 RVA: 0x0003E0EE File Offset: 0x0003C2EE
		' (set) Token: 0x06007E4A RID: 32330 RVA: 0x005E1984 File Offset: 0x005DFB84
		Private _Panel4 As Panel
		Friend Overridable Property Panel4 As Panel
			<CompilerGenerated()>
			Get
				Return Me._Panel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Dim paintEventHandler As PaintEventHandler = AddressOf Me.Panel4_Paint
				Dim panel As Panel = Me._Panel4
				If panel IsNot Nothing Then
					RemoveHandler panel.Paint, paintEventHandler
				End If
				Me._Panel4 = value
				panel = Me._Panel4
				If panel IsNot Nothing Then
					AddHandler panel.Paint, paintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E53 RID: 11859
		' (get) Token: 0x06007E4B RID: 32331 RVA: 0x0003E0F8 File Offset: 0x0003C2F8
		' (set) Token: 0x06007E4C RID: 32332 RVA: 0x0003E102 File Offset: 0x0003C302
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x17002E54 RID: 11860
		' (get) Token: 0x06007E4D RID: 32333 RVA: 0x0003E10B File Offset: 0x0003C30B
		' (set) Token: 0x06007E4E RID: 32334 RVA: 0x005E19C8 File Offset: 0x005DFBC8
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBarcode_TextChanged
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E55 RID: 11861
		' (get) Token: 0x06007E4F RID: 32335 RVA: 0x0003E115 File Offset: 0x0003C315
		' (set) Token: 0x06007E50 RID: 32336 RVA: 0x005E1A0C File Offset: 0x005DFC0C
		Private _cmbProductName As TextBox
		Friend Overridable Property cmbProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbProductName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductName_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.cmbProductName_KeyDown
				Dim textBox As TextBox = Me._cmbProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler2
				End If
				Me._cmbProductName = value
				textBox = Me._cmbProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
					AddHandler textBox.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002E56 RID: 11862
		' (get) Token: 0x06007E51 RID: 32337 RVA: 0x0003E11F File Offset: 0x0003C31F
		' (set) Token: 0x06007E52 RID: 32338 RVA: 0x0003E129 File Offset: 0x0003C329
		Friend Overridable Property txtMinQty As TextBox

		' Token: 0x17002E57 RID: 11863
		' (get) Token: 0x06007E53 RID: 32339 RVA: 0x0003E132 File Offset: 0x0003C332
		' (set) Token: 0x06007E54 RID: 32340 RVA: 0x0003E13C File Offset: 0x0003C33C
		Friend Overridable Property Label3 As Label

		' Token: 0x17002E58 RID: 11864
		' (get) Token: 0x06007E55 RID: 32341 RVA: 0x0003E145 File Offset: 0x0003C345
		' (set) Token: 0x06007E56 RID: 32342 RVA: 0x0003E14F File Offset: 0x0003C34F
		Friend Overridable Property Label2 As Label

		' Token: 0x17002E59 RID: 11865
		' (get) Token: 0x06007E57 RID: 32343 RVA: 0x0003E158 File Offset: 0x0003C358
		' (set) Token: 0x06007E58 RID: 32344 RVA: 0x0003E162 File Offset: 0x0003C362
		Friend Overridable Property Label7 As Label

		' Token: 0x17002E5A RID: 11866
		' (get) Token: 0x06007E59 RID: 32345 RVA: 0x0003E16B File Offset: 0x0003C36B
		' (set) Token: 0x06007E5A RID: 32346 RVA: 0x005E1A88 File Offset: 0x005DFC88
		Private _btnAddProduct As GelButton
		Friend Overridable Property btnAddProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddProduct_Click
				Dim gelButton As GelButton = Me._btnAddProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddProduct = value
				gelButton = Me._btnAddProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E5B RID: 11867
		' (get) Token: 0x06007E5B RID: 32347 RVA: 0x0003E175 File Offset: 0x0003C375
		' (set) Token: 0x06007E5C RID: 32348 RVA: 0x005E1ACC File Offset: 0x005DFCCC
		Private _btnUpdateProduct As GelButton
		Friend Overridable Property btnUpdateProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdateProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdateProduct_Click
				Dim gelButton As GelButton = Me._btnUpdateProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdateProduct = value
				gelButton = Me._btnUpdateProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E5C RID: 11868
		' (get) Token: 0x06007E5D RID: 32349 RVA: 0x0003E17F File Offset: 0x0003C37F
		' (set) Token: 0x06007E5E RID: 32350 RVA: 0x005E1B10 File Offset: 0x005DFD10
		Private _btnRemoveProduct As GelButton
		Friend Overridable Property btnRemoveProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRemoveProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemoveProduct_Click
				Dim gelButton As GelButton = Me._btnRemoveProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRemoveProduct = value
				gelButton = Me._btnRemoveProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E5D RID: 11869
		' (get) Token: 0x06007E5F RID: 32351 RVA: 0x0003E189 File Offset: 0x0003C389
		' (set) Token: 0x06007E60 RID: 32352 RVA: 0x0003E193 File Offset: 0x0003C393
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17002E5E RID: 11870
		' (get) Token: 0x06007E61 RID: 32353 RVA: 0x0003E19C File Offset: 0x0003C39C
		' (set) Token: 0x06007E62 RID: 32354 RVA: 0x0003E1A6 File Offset: 0x0003C3A6
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17002E5F RID: 11871
		' (get) Token: 0x06007E63 RID: 32355 RVA: 0x0003E1AF File Offset: 0x0003C3AF
		' (set) Token: 0x06007E64 RID: 32356 RVA: 0x005E1B54 File Offset: 0x005DFD54
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E60 RID: 11872
		' (get) Token: 0x06007E65 RID: 32357 RVA: 0x0003E1B9 File Offset: 0x0003C3B9
		' (set) Token: 0x06007E66 RID: 32358 RVA: 0x0003E1C3 File Offset: 0x0003C3C3
		Friend Overridable Property lblBarcode As Label

		' Token: 0x17002E61 RID: 11873
		' (get) Token: 0x06007E67 RID: 32359 RVA: 0x0003E1CC File Offset: 0x0003C3CC
		' (set) Token: 0x06007E68 RID: 32360 RVA: 0x0003E1D6 File Offset: 0x0003C3D6
		Friend Overridable Property lblUser As Label

		' Token: 0x17002E62 RID: 11874
		' (get) Token: 0x06007E69 RID: 32361 RVA: 0x0003E1DF File Offset: 0x0003C3DF
		' (set) Token: 0x06007E6A RID: 32362 RVA: 0x0003E1E9 File Offset: 0x0003C3E9
		Friend Overridable Property Label1 As Label

		' Token: 0x17002E63 RID: 11875
		' (get) Token: 0x06007E6B RID: 32363 RVA: 0x0003E1F2 File Offset: 0x0003C3F2
		' (set) Token: 0x06007E6C RID: 32364 RVA: 0x0003E1FC File Offset: 0x0003C3FC
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17002E64 RID: 11876
		' (get) Token: 0x06007E6D RID: 32365 RVA: 0x0003E205 File Offset: 0x0003C405
		' (set) Token: 0x06007E6E RID: 32366 RVA: 0x0003E20F File Offset: 0x0003C40F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17002E65 RID: 11877
		' (get) Token: 0x06007E6F RID: 32367 RVA: 0x0003E218 File Offset: 0x0003C418
		' (set) Token: 0x06007E70 RID: 32368 RVA: 0x005E1B98 File Offset: 0x005DFD98
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler2
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002E66 RID: 11878
		' (get) Token: 0x06007E71 RID: 32369 RVA: 0x0003E222 File Offset: 0x0003C422
		' (set) Token: 0x06007E72 RID: 32370 RVA: 0x0003E22C File Offset: 0x0003C42C
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17002E67 RID: 11879
		' (get) Token: 0x06007E73 RID: 32371 RVA: 0x0003E235 File Offset: 0x0003C435
		' (set) Token: 0x06007E74 RID: 32372 RVA: 0x0003E23F File Offset: 0x0003C43F
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17002E68 RID: 11880
		' (get) Token: 0x06007E75 RID: 32373 RVA: 0x0003E248 File Offset: 0x0003C448
		' (set) Token: 0x06007E76 RID: 32374 RVA: 0x0003E252 File Offset: 0x0003C452
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17002E69 RID: 11881
		' (get) Token: 0x06007E77 RID: 32375 RVA: 0x0003E25B File Offset: 0x0003C45B
		' (set) Token: 0x06007E78 RID: 32376 RVA: 0x0003E265 File Offset: 0x0003C465
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17002E6A RID: 11882
		' (get) Token: 0x06007E79 RID: 32377 RVA: 0x0003E26E File Offset: 0x0003C46E
		' (set) Token: 0x06007E7A RID: 32378 RVA: 0x0003E278 File Offset: 0x0003C478
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17002E6B RID: 11883
		' (get) Token: 0x06007E7B RID: 32379 RVA: 0x0003E281 File Offset: 0x0003C481
		' (set) Token: 0x06007E7C RID: 32380 RVA: 0x0003E28B File Offset: 0x0003C48B
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17002E6C RID: 11884
		' (get) Token: 0x06007E7D RID: 32381 RVA: 0x0003E294 File Offset: 0x0003C494
		' (set) Token: 0x06007E7E RID: 32382 RVA: 0x0003E29E File Offset: 0x0003C49E
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17002E6D RID: 11885
		' (get) Token: 0x06007E7F RID: 32383 RVA: 0x0003E2A7 File Offset: 0x0003C4A7
		' (set) Token: 0x06007E80 RID: 32384 RVA: 0x0003E2B1 File Offset: 0x0003C4B1
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17002E6E RID: 11886
		' (get) Token: 0x06007E81 RID: 32385 RVA: 0x0003E2BA File Offset: 0x0003C4BA
		' (set) Token: 0x06007E82 RID: 32386 RVA: 0x0003E2C4 File Offset: 0x0003C4C4
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17002E6F RID: 11887
		' (get) Token: 0x06007E83 RID: 32387 RVA: 0x0003E2CD File Offset: 0x0003C4CD
		' (set) Token: 0x06007E84 RID: 32388 RVA: 0x0003E2D7 File Offset: 0x0003C4D7
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17002E70 RID: 11888
		' (get) Token: 0x06007E85 RID: 32389 RVA: 0x0003E2E0 File Offset: 0x0003C4E0
		' (set) Token: 0x06007E86 RID: 32390 RVA: 0x0003E2EA File Offset: 0x0003C4EA
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17002E71 RID: 11889
		' (get) Token: 0x06007E87 RID: 32391 RVA: 0x0003E2F3 File Offset: 0x0003C4F3
		' (set) Token: 0x06007E88 RID: 32392 RVA: 0x0003E2FD File Offset: 0x0003C4FD
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17002E72 RID: 11890
		' (get) Token: 0x06007E89 RID: 32393 RVA: 0x0003E306 File Offset: 0x0003C506
		' (set) Token: 0x06007E8A RID: 32394 RVA: 0x0003E310 File Offset: 0x0003C510
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17002E73 RID: 11891
		' (get) Token: 0x06007E8B RID: 32395 RVA: 0x0003E319 File Offset: 0x0003C519
		' (set) Token: 0x06007E8C RID: 32396 RVA: 0x0003E323 File Offset: 0x0003C523
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17002E74 RID: 11892
		' (get) Token: 0x06007E8D RID: 32397 RVA: 0x0003E32C File Offset: 0x0003C52C
		' (set) Token: 0x06007E8E RID: 32398 RVA: 0x0003E336 File Offset: 0x0003C536
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17002E75 RID: 11893
		' (get) Token: 0x06007E8F RID: 32399 RVA: 0x0003E33F File Offset: 0x0003C53F
		' (set) Token: 0x06007E90 RID: 32400 RVA: 0x0003E349 File Offset: 0x0003C549
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17002E76 RID: 11894
		' (get) Token: 0x06007E91 RID: 32401 RVA: 0x0003E352 File Offset: 0x0003C552
		' (set) Token: 0x06007E92 RID: 32402 RVA: 0x0003E35C File Offset: 0x0003C55C
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17002E77 RID: 11895
		' (get) Token: 0x06007E93 RID: 32403 RVA: 0x0003E365 File Offset: 0x0003C565
		' (set) Token: 0x06007E94 RID: 32404 RVA: 0x0003E36F File Offset: 0x0003C56F
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17002E78 RID: 11896
		' (get) Token: 0x06007E95 RID: 32405 RVA: 0x0003E378 File Offset: 0x0003C578
		' (set) Token: 0x06007E96 RID: 32406 RVA: 0x0003E382 File Offset: 0x0003C582
		Friend Overridable Property txtDiscountPur As TextBox

		' Token: 0x17002E79 RID: 11897
		' (get) Token: 0x06007E97 RID: 32407 RVA: 0x0003E38B File Offset: 0x0003C58B
		' (set) Token: 0x06007E98 RID: 32408 RVA: 0x0003E395 File Offset: 0x0003C595
		Friend Overridable Property Label5 As Label

		' Token: 0x17002E7A RID: 11898
		' (get) Token: 0x06007E99 RID: 32409 RVA: 0x0003E39E File Offset: 0x0003C59E
		' (set) Token: 0x06007E9A RID: 32410 RVA: 0x0003E3A8 File Offset: 0x0003C5A8
		Friend Overridable Property txtMaxQty As TextBox

		' Token: 0x17002E7B RID: 11899
		' (get) Token: 0x06007E9B RID: 32411 RVA: 0x0003E3B1 File Offset: 0x0003C5B1
		' (set) Token: 0x06007E9C RID: 32412 RVA: 0x0003E3BB File Offset: 0x0003C5BB
		Friend Overridable Property Label4 As Label

		' Token: 0x17002E7C RID: 11900
		' (get) Token: 0x06007E9D RID: 32413 RVA: 0x0003E3C4 File Offset: 0x0003C5C4
		' (set) Token: 0x06007E9E RID: 32414 RVA: 0x0003E3CE File Offset: 0x0003C5CE
		Friend Overridable Property ipoid As TextBox

		' Token: 0x17002E7D RID: 11901
		' (get) Token: 0x06007E9F RID: 32415 RVA: 0x0003E3D7 File Offset: 0x0003C5D7
		' (set) Token: 0x06007EA0 RID: 32416 RVA: 0x0003E3E1 File Offset: 0x0003C5E1
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17002E7E RID: 11902
		' (get) Token: 0x06007EA1 RID: 32417 RVA: 0x0003E3EA File Offset: 0x0003C5EA
		' (set) Token: 0x06007EA2 RID: 32418 RVA: 0x0003E3F4 File Offset: 0x0003C5F4
		Friend Overridable Property ProductName As DataGridViewTextBoxColumn

		' Token: 0x17002E7F RID: 11903
		' (get) Token: 0x06007EA3 RID: 32419 RVA: 0x0003E3FD File Offset: 0x0003C5FD
		' (set) Token: 0x06007EA4 RID: 32420 RVA: 0x0003E407 File Offset: 0x0003C607
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17002E80 RID: 11904
		' (get) Token: 0x06007EA5 RID: 32421 RVA: 0x0003E410 File Offset: 0x0003C610
		' (set) Token: 0x06007EA6 RID: 32422 RVA: 0x0003E41A File Offset: 0x0003C61A
		Friend Overridable Property DefaultQty As DataGridViewTextBoxColumn

		' Token: 0x17002E81 RID: 11905
		' (get) Token: 0x06007EA7 RID: 32423 RVA: 0x0003E423 File Offset: 0x0003C623
		' (set) Token: 0x06007EA8 RID: 32424 RVA: 0x0003E42D File Offset: 0x0003C62D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17002E82 RID: 11906
		' (get) Token: 0x06007EA9 RID: 32425 RVA: 0x0003E436 File Offset: 0x0003C636
		' (set) Token: 0x06007EAA RID: 32426 RVA: 0x0003E440 File Offset: 0x0003C640
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17002E83 RID: 11907
		' (get) Token: 0x06007EAB RID: 32427 RVA: 0x0003E449 File Offset: 0x0003C649
		' (set) Token: 0x06007EAC RID: 32428 RVA: 0x0003E453 File Offset: 0x0003C653
		Friend Overridable Property colipoid As DataGridViewTextBoxColumn

		' Token: 0x17002E84 RID: 11908
		' (get) Token: 0x06007EAD RID: 32429 RVA: 0x0003E45C File Offset: 0x0003C65C
		' (set) Token: 0x06007EAE RID: 32430 RVA: 0x005E1C14 File Offset: 0x005DFE14
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
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

		' Token: 0x17002E85 RID: 11909
		' (get) Token: 0x06007EAF RID: 32431 RVA: 0x0003E466 File Offset: 0x0003C666
		' (set) Token: 0x06007EB0 RID: 32432 RVA: 0x005E1C58 File Offset: 0x005DFE58
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

		' Token: 0x06007EB1 RID: 32433 RVA: 0x005E1C9C File Offset: 0x005DFE9C
		Private Sub cmbProductName_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbProductName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x06007EB2 RID: 32434 RVA: 0x005E1CEC File Offset: 0x005DFEEC
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				Me.dgw4.Columns(24).Visible = True
				Me.dgw4.Columns(26).Visible = True
				Me.dgw4.Columns(27).Visible = True
				Me.dgw4.Columns(28).Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 30 PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.EPPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.EPPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Product.LastPrice),RTRIM(Temp_Stock.Damage),RTRIM(Product.Description),RTRIM(Product.MinStock),(Temp_Stock.MRP),RTRIM(Product.STax),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'" + Me.cmbProductName.Text + "%' order by ProductName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007EB3 RID: 32435 RVA: 0x005E2044 File Offset: 0x005E0244
		Public Sub RetrieveData1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
				Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
				Dim flag As Boolean = (Conversion.Val(Me.txtMinQty.Text) = 0.0) Or (Operators.CompareString(Me.txtMinQty.Text, "", False) = 0)
				If flag Then
					Me.txtMinQty.Text = "1"
				Else
					Me.txtMinQty.Text = dataGridViewRow.Cells(29).Value.ToString()
				End If
				Me.dgw4.Visible = False
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007EB4 RID: 32436 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)
		End Sub

		' Token: 0x06007EB5 RID: 32437 RVA: 0x0003E470 File Offset: 0x0003C670
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06007EB6 RID: 32438 RVA: 0x005E216C File Offset: 0x005E036C
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06007EB7 RID: 32439 RVA: 0x005E2194 File Offset: 0x005E0394
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
					Me.cmbProductName.Focus()
					Me.cmbProductName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.cmbProductName.Text = Me.cmbProductName.Text.Remove(Me.cmbProductName.Text.Length - 1, 1)
						Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
						Me.cmbProductName.Focus()
						Me.cmbProductName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "a"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "b"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "c"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "d"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "e"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "f"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "g"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "h"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "i"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "j"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "k"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "l"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "m"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "n"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "o"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "p"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "q"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "r"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "s"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "t"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "u"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "v"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "w"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "x"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "y"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "z"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "0"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "1"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "2"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "3"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "4"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "5"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "6"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "7"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "8"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "9"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "+"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "-"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "\"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + ","
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06007EB8 RID: 32440 RVA: 0x005E3BDC File Offset: 0x005E1DDC
		Private Sub cmbProductName_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06007EB9 RID: 32441 RVA: 0x005E3C24 File Offset: 0x005E1E24
		Private Sub cmbProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
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

		' Token: 0x06007EBA RID: 32442 RVA: 0x005E3CEC File Offset: 0x005E1EEC
		Private Function Clear() As Object
			Me.txtProductID.Text = ""
			Me.cmbProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtMinQty.Text = Conversions.ToString(1)
			Me.txtMaxQty.Text = Conversions.ToString(1)
			Me.txtDiscountPur.Text = "0.00"
			Me.btnRemoveProduct.Enabled = False
			Me.btnUpdateProduct.Enabled = False
			Me.btnAddProduct.Enabled = True
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06007EBB RID: 32443 RVA: 0x005E3D8C File Offset: 0x005E1F8C
		Private Function ShowProduct(barcode As String, mode As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(mode, "ALL", False) = 0
				Dim text As String
				If flag Then
					text = "SELECT Product_discount.ProductID,Product.ProductName,Product_discount.Barcode,Product_discount.MinQty,Product_discount.MaxQty,Product_discount.DiscountPur,Product_discount.IPo_ID from Product_discount INNER Join Product ON Product_discount.ProductID = Product.PID order by Product_discount.Barcode"
				Else
					text = "SELECT Product_discount.ProductID,Product.ProductName,Product_discount.Barcode,Product_discount.MinQty,Product_discount.MaxQty,Product_discount.DiscountPur,Product_discount.IPo_ID from Product_discount INNER Join Product ON Product_discount.ProductID = Product.PID where Product_discount.Barcode = N'" + barcode + "'"
				End If
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1).ToString().Trim(), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06007EBC RID: 32444 RVA: 0x005E3F08 File Offset: 0x005E2108
		Private Sub btnAddProduct_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please Select product Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbProductName.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please Enter Barcode Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBarcode.Focus()
				Else
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim num As Decimal = Conversions.ToDecimal(Strings.FormatNumber(Conversions.ToDouble(Me.txtMinQty.Text), 3, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault))
							Dim num2 As Decimal = Conversions.ToDecimal(Strings.FormatNumber(Conversions.ToDouble(Me.txtMaxQty.Text), 3, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault))
							Dim num3 As Decimal = Convert.ToDecimal(dataGridViewRow.Cells(3).Value.ToString())
							Dim num4 As Decimal = Convert.ToDecimal(dataGridViewRow.Cells(4).Value.ToString())
							Dim flag3 As Boolean = (Decimal.Compare(num, num3) = 0) Or (Decimal.Compare(num2, num4) = 0)
							If flag3 Then
								MessageBox.Show("Same quantity already exist in product, please enter corerct quantity")
								Return
							End If
							Dim flag4 As Boolean = ((Decimal.Compare(num2, num3) > 0) And (Decimal.Compare(num2, num4) <= 0)) Or ((Decimal.Compare(num2, num3) >= 0) And (Decimal.Compare(num, num4) <= 0))
							If flag4 Then
								MessageBox.Show("Quantity must be different than existing product, please enter corerct quantity")
								Return
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "insert into Product_discount(ProductID, Barcode, MinQty,MaxQty,DiscountPur) VALUES (@d1,@d2,@d3,@d4,@d5)"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Prepare()
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text.ToString().Trim())
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtMinQty.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtMaxQty.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtDiscountPur.Text)
						ModCommonClasses.cmd.ExecuteNonQuery()
						Me.ShowProduct(Me.txtBarcode.Text, "SS")
						ModCommonClasses.cmd.Parameters.Clear()
						ModCommonClasses.con.Close()
					Catch ex As Exception
						MessageBox.Show(ex.Message)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06007EBD RID: 32445 RVA: 0x0003E47A File Offset: 0x0003C67A
		Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs)
			Me.ShowProduct(Me.txtBarcode.Text, "SS")
		End Sub

		' Token: 0x06007EBE RID: 32446 RVA: 0x005E4278 File Offset: 0x005E2478
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbProductName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtMinQty.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtMaxQty.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtDiscountPur.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.ipoid.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.btnRemoveProduct.Enabled = True
					Me.btnUpdateProduct.Enabled = True
					Me.btnAddProduct.Enabled = False
					Me.dgw4.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007EBF RID: 32447 RVA: 0x0003E494 File Offset: 0x0003C694
		Private Sub btnRemoveProduct_Click(sender As Object, e As EventArgs)
			Me.RemoveALL("SS")
		End Sub

		' Token: 0x06007EC0 RID: 32448 RVA: 0x005E4408 File Offset: 0x005E2608
		Private Function RemoveALL(mode As String) As Object
			Dim flag As Boolean = Operators.CompareString(mode, "ALL", False) = 0
			If flag Then
				Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete ALL record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag2 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "delete from Product_discount"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
				End If
			Else
				Dim flag3 As Boolean = Me.dgw.Rows.Count > 0
				If flag3 Then
					Try
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim flag4 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), Me.txtBarcode.Text.Trim(), False) = 0))
						If flag4 Then
							Try
								Dim flag5 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
								If flag5 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text As String = "delete from Product_discount where ProductID=@d1 AND Barcode=@d2 AND IPo_ID=@d3"
									ModCommonClasses.cmd = New SqlCommand(text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text.Trim())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(6).Value.ToString().Trim())
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					Catch ex2 As Exception
						MessageBox.Show("Please select row first to delete data.")
					End Try
				End If
			End If
			Me.ShowProduct(Me.txtBarcode.Text, "SS")
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06007EC1 RID: 32449 RVA: 0x0003E4A3 File Offset: 0x0003C6A3
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub

		' Token: 0x06007EC2 RID: 32450 RVA: 0x005E46CC File Offset: 0x005E28CC
		Private Sub btnUpdateProduct_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.Rows.Count > 0
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please Select product Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
					Return
				End If
				Dim flag3 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please Enter Barcode Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBarcode.Focus()
					Return
				End If
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim num As Decimal = Conversions.ToDecimal(Strings.FormatNumber(Conversions.ToDouble(Me.txtMinQty.Text), 3, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault))
						Dim num2 As Decimal = Conversions.ToDecimal(Strings.FormatNumber(Conversions.ToDouble(Me.txtMaxQty.Text), 3, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault))
						Dim num3 As Decimal = Convert.ToDecimal(dataGridViewRow.Cells(3).Value.ToString())
						Dim num4 As Decimal = Convert.ToDecimal(dataGridViewRow.Cells(4).Value.ToString())
						Dim flag4 As Boolean = (Decimal.Compare(num, num3) = 0) Or (Decimal.Compare(num2, num4) = 0)
						If flag4 Then
							MessageBox.Show("ERROR")
							Return
						End If
						Dim flag5 As Boolean = ((Decimal.Compare(num2, num3) > 0) And (Decimal.Compare(num2, num4) <= 0)) Or ((Decimal.Compare(num2, num3) >= 0) And (Decimal.Compare(num, num4) <= 0))
						If flag5 Then
							MessageBox.Show("ERROR")
							Return
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Try
					Dim flag6 As Boolean = MessageBox.Show("Do you really want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag6 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = String.Concat(New String() { "update Product_discount  set MinQty=@d1, MaxQty=@d2, DiscountPur=@d3 where ProductID= ", Me.txtProductID.Text, " AND Barcode = '", Me.txtBarcode.Text.Trim(), "' AND IPo_ID = '", Me.ipoid.Text, "'" })
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtMinQty.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtMaxQty.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtDiscountPur.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Me.ShowProduct(Me.txtBarcode.Text, "SS")
		End Sub

		' Token: 0x06007EC3 RID: 32451 RVA: 0x0003E4AD File Offset: 0x0003C6AD
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.ShowProduct("", "ALL")
		End Sub

		' Token: 0x06007EC4 RID: 32452 RVA: 0x0003E4C1 File Offset: 0x0003C6C1
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.RemoveALL("ALL")
		End Sub

		' Token: 0x06007EC5 RID: 32453 RVA: 0x0003E4D0 File Offset: 0x0003C6D0
		Private Sub frmProductDiscount_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x06007EC6 RID: 32454 RVA: 0x005E4A70 File Offset: 0x005E2C70
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

		' Token: 0x06007EC7 RID: 32455 RVA: 0x005E4BE8 File Offset: 0x005E2DE8
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

		' Token: 0x06007EC8 RID: 32456 RVA: 0x005E4CA4 File Offset: 0x005E2EA4
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

		' Token: 0x06007EC9 RID: 32457 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06007ECA RID: 32458 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06007ECB RID: 32459 RVA: 0x00087088 File Offset: 0x00085288
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
	End Class
End Namespace
