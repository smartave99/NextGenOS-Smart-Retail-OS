Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports DevNetSR
Imports DevNetTRLN
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001D4 RID: 468
	<DesignerGenerated()>
	Public Partial Class frmProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007A0A RID: 31242 RVA: 0x005B0850 File Offset: 0x005AEA50
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProduct_Load
			AddHandler MyBase.Closing, AddressOf Me.frmProduct_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmProduct_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmProduct_Closed
			Me.keyPath = "HKEY_CURRENT_USER\Software\POS"
			Me.valueName = "Margin"
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002CD0 RID: 11472
		' (get) Token: 0x06007A0D RID: 31245 RVA: 0x0003C6A6 File Offset: 0x0003A8A6
		' (set) Token: 0x06007A0E RID: 31246 RVA: 0x0003C6B0 File Offset: 0x0003A8B0
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17002CD1 RID: 11473
		' (get) Token: 0x06007A0F RID: 31247 RVA: 0x0003C6B9 File Offset: 0x0003A8B9
		' (set) Token: 0x06007A10 RID: 31248 RVA: 0x0003C6C3 File Offset: 0x0003A8C3
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17002CD2 RID: 11474
		' (get) Token: 0x06007A11 RID: 31249 RVA: 0x0003C6CC File Offset: 0x0003A8CC
		' (set) Token: 0x06007A12 RID: 31250 RVA: 0x0003C6D6 File Offset: 0x0003A8D6
		Friend Overridable Property Label3 As Label

		' Token: 0x17002CD3 RID: 11475
		' (get) Token: 0x06007A13 RID: 31251 RVA: 0x0003C6DF File Offset: 0x0003A8DF
		' (set) Token: 0x06007A14 RID: 31252 RVA: 0x0003C6E9 File Offset: 0x0003A8E9
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002CD4 RID: 11476
		' (get) Token: 0x06007A15 RID: 31253 RVA: 0x0003C6F2 File Offset: 0x0003A8F2
		' (set) Token: 0x06007A16 RID: 31254 RVA: 0x0003C6FC File Offset: 0x0003A8FC
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17002CD5 RID: 11477
		' (get) Token: 0x06007A17 RID: 31255 RVA: 0x0003C705 File Offset: 0x0003A905
		' (set) Token: 0x06007A18 RID: 31256 RVA: 0x0003C70F File Offset: 0x0003A90F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17002CD6 RID: 11478
		' (get) Token: 0x06007A19 RID: 31257 RVA: 0x0003C718 File Offset: 0x0003A918
		' (set) Token: 0x06007A1A RID: 31258 RVA: 0x0003C722 File Offset: 0x0003A922
		Friend Overridable Property Label1 As Label

		' Token: 0x17002CD7 RID: 11479
		' (get) Token: 0x06007A1B RID: 31259 RVA: 0x0003C72B File Offset: 0x0003A92B
		' (set) Token: 0x06007A1C RID: 31260 RVA: 0x0003C735 File Offset: 0x0003A935
		Friend Overridable Property Label7 As Label

		' Token: 0x17002CD8 RID: 11480
		' (get) Token: 0x06007A1D RID: 31261 RVA: 0x0003C73E File Offset: 0x0003A93E
		' (set) Token: 0x06007A1E RID: 31262 RVA: 0x0003C748 File Offset: 0x0003A948
		Friend Overridable Property Label6 As Label

		' Token: 0x17002CD9 RID: 11481
		' (get) Token: 0x06007A1F RID: 31263 RVA: 0x0003C751 File Offset: 0x0003A951
		' (set) Token: 0x06007A20 RID: 31264 RVA: 0x0003C75B File Offset: 0x0003A95B
		Friend Overridable Property Label5 As Label

		' Token: 0x17002CDA RID: 11482
		' (get) Token: 0x06007A21 RID: 31265 RVA: 0x0003C764 File Offset: 0x0003A964
		' (set) Token: 0x06007A22 RID: 31266 RVA: 0x005B92B4 File Offset: 0x005B74B4
		Private _txtFeatures As TextBox
		Friend Overridable Property txtFeatures As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtFeatures
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtFeatures_KeyDown
				Dim textBox As TextBox = Me._txtFeatures
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtFeatures = value
				textBox = Me._txtFeatures
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CDB RID: 11483
		' (get) Token: 0x06007A23 RID: 31267 RVA: 0x0003C76E File Offset: 0x0003A96E
		' (set) Token: 0x06007A24 RID: 31268 RVA: 0x0003C778 File Offset: 0x0003A978
		Friend Overridable Property Label2 As Label

		' Token: 0x17002CDC RID: 11484
		' (get) Token: 0x06007A25 RID: 31269 RVA: 0x0003C781 File Offset: 0x0003A981
		' (set) Token: 0x06007A26 RID: 31270 RVA: 0x0003C78B File Offset: 0x0003A98B
		Friend Overridable Property lblUser As Label

		' Token: 0x17002CDD RID: 11485
		' (get) Token: 0x06007A27 RID: 31271 RVA: 0x0003C794 File Offset: 0x0003A994
		' (set) Token: 0x06007A28 RID: 31272 RVA: 0x005B92F8 File Offset: 0x005B74F8
		Private _txtReorderPoint As TextBox
		Friend Overridable Property txtReorderPoint As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtReorderPoint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtReorderPoint_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtReorderPoint_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtReorderPoint_TextChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler2 As EventHandler = AddressOf Me.txtReorderPoint_Leave
				Dim textBox As TextBox = Me._txtReorderPoint
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtReorderPoint = value
				textBox = Me._txtReorderPoint
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002CDE RID: 11486
		' (get) Token: 0x06007A29 RID: 31273 RVA: 0x0003C79E File Offset: 0x0003A99E
		' (set) Token: 0x06007A2A RID: 31274 RVA: 0x0003C7A8 File Offset: 0x0003A9A8
		Friend Overridable Property Label4 As Label

		' Token: 0x17002CDF RID: 11487
		' (get) Token: 0x06007A2B RID: 31275 RVA: 0x0003C7B1 File Offset: 0x0003A9B1
		' (set) Token: 0x06007A2C RID: 31276 RVA: 0x005B93B8 File Offset: 0x005B75B8
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

		' Token: 0x17002CE0 RID: 11488
		' (get) Token: 0x06007A2D RID: 31277 RVA: 0x0003C7BB File Offset: 0x0003A9BB
		' (set) Token: 0x06007A2E RID: 31278 RVA: 0x005B93FC File Offset: 0x005B75FC
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

		' Token: 0x17002CE1 RID: 11489
		' (get) Token: 0x06007A2F RID: 31279 RVA: 0x0003C7C5 File Offset: 0x0003A9C5
		' (set) Token: 0x06007A30 RID: 31280 RVA: 0x0003C7CF File Offset: 0x0003A9CF
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17002CE2 RID: 11490
		' (get) Token: 0x06007A31 RID: 31281 RVA: 0x0003C7D8 File Offset: 0x0003A9D8
		' (set) Token: 0x06007A32 RID: 31282 RVA: 0x0003C7E2 File Offset: 0x0003A9E2
		Public Overridable Property Picture As PictureBox

		' Token: 0x17002CE3 RID: 11491
		' (get) Token: 0x06007A33 RID: 31283 RVA: 0x0003C7EB File Offset: 0x0003A9EB
		' (set) Token: 0x06007A34 RID: 31284 RVA: 0x005B9440 File Offset: 0x005B7640
		Private _txtCostPrice As TextBox
		Friend Overridable Property txtCostPrice As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCostPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPrice_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCostPrice_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtCostPrice_Leave
				Dim textBox As TextBox = Me._txtCostPrice
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.Leave, eventHandler
				End If
				Me._txtCostPrice = value
				textBox = Me._txtCostPrice
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.Leave, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CE4 RID: 11492
		' (get) Token: 0x06007A35 RID: 31285 RVA: 0x0003C7F5 File Offset: 0x0003A9F5
		' (set) Token: 0x06007A36 RID: 31286 RVA: 0x0003C7FF File Offset: 0x0003A9FF
		Friend Overridable Property txtSubCategoryID As TextBox

		' Token: 0x17002CE5 RID: 11493
		' (get) Token: 0x06007A37 RID: 31287 RVA: 0x0003C808 File Offset: 0x0003AA08
		' (set) Token: 0x06007A38 RID: 31288 RVA: 0x005B94E0 File Offset: 0x005B76E0
		Private _cmbSubCategory As ComboBox
		Friend Overridable Property cmbSubCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSubCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSubCategory = value
				comboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CE6 RID: 11494
		' (get) Token: 0x06007A39 RID: 31289 RVA: 0x0003C812 File Offset: 0x0003AA12
		' (set) Token: 0x06007A3A RID: 31290 RVA: 0x005B9540 File Offset: 0x005B7740
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CE7 RID: 11495
		' (get) Token: 0x06007A3B RID: 31291 RVA: 0x0003C81C File Offset: 0x0003AA1C
		' (set) Token: 0x06007A3C RID: 31292 RVA: 0x005B95BC File Offset: 0x005B77BC
		Private _txtSellingPrice As TextBox
		Friend Overridable Property txtSellingPrice As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSellingPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSellingPrice_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSellingPrice_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtSellingPrice_TextChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler2 As EventHandler = AddressOf Me.txtSellingPrice_Leave
				Dim textBox As TextBox = Me._txtSellingPrice
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtSellingPrice = value
				textBox = Me._txtSellingPrice
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002CE8 RID: 11496
		' (get) Token: 0x06007A3D RID: 31293 RVA: 0x0003C826 File Offset: 0x0003AA26
		' (set) Token: 0x06007A3E RID: 31294 RVA: 0x005B967C File Offset: 0x005B787C
		Private _txtCGST As TextBox
		Friend Overridable Property txtCGST As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtVAT_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCGST_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtCGST_TextChanged
				Dim textBox As TextBox = Me._txtCGST
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCGST = value
				textBox = Me._txtCGST
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CE9 RID: 11497
		' (get) Token: 0x06007A3F RID: 31295 RVA: 0x0003C830 File Offset: 0x0003AA30
		' (set) Token: 0x06007A40 RID: 31296 RVA: 0x005B96F8 File Offset: 0x005B78F8
		Private _txtDiscount As TextBox
		Friend Overridable Property txtDiscount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtDiscount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtDiscount = value
				textBox = Me._txtDiscount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CEA RID: 11498
		' (get) Token: 0x06007A41 RID: 31297 RVA: 0x0003C83A File Offset: 0x0003AA3A
		' (set) Token: 0x06007A42 RID: 31298 RVA: 0x0003C844 File Offset: 0x0003AA44
		Friend Overridable Property Label11 As Label

		' Token: 0x17002CEB RID: 11499
		' (get) Token: 0x06007A43 RID: 31299 RVA: 0x0003C84D File Offset: 0x0003AA4D
		' (set) Token: 0x06007A44 RID: 31300 RVA: 0x0003C857 File Offset: 0x0003AA57
		Friend Overridable Property Label9 As Label

		' Token: 0x17002CEC RID: 11500
		' (get) Token: 0x06007A45 RID: 31301 RVA: 0x0003C860 File Offset: 0x0003AA60
		' (set) Token: 0x06007A46 RID: 31302 RVA: 0x0003C86A File Offset: 0x0003AA6A
		Friend Overridable Property lblUserType As Label

		' Token: 0x17002CED RID: 11501
		' (get) Token: 0x06007A47 RID: 31303 RVA: 0x0003C873 File Offset: 0x0003AA73
		' (set) Token: 0x06007A48 RID: 31304 RVA: 0x005B9774 File Offset: 0x005B7974
		Private _btnRemove As Button
		Public Overridable Property btnRemove As Button
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

		' Token: 0x17002CEE RID: 11502
		' (get) Token: 0x06007A49 RID: 31305 RVA: 0x0003C87D File Offset: 0x0003AA7D
		' (set) Token: 0x06007A4A RID: 31306 RVA: 0x005B97B8 File Offset: 0x005B79B8
		Private _btnAdd As Button
		Public Overridable Property btnAdd As Button
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

		' Token: 0x17002CEF RID: 11503
		' (get) Token: 0x06007A4B RID: 31307 RVA: 0x0003C887 File Offset: 0x0003AA87
		' (set) Token: 0x06007A4C RID: 31308 RVA: 0x005B97FC File Offset: 0x005B79FC
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

		' Token: 0x17002CF0 RID: 11504
		' (get) Token: 0x06007A4D RID: 31309 RVA: 0x0003C891 File Offset: 0x0003AA91
		' (set) Token: 0x06007A4E RID: 31310 RVA: 0x0003C89B File Offset: 0x0003AA9B
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002CF1 RID: 11505
		' (get) Token: 0x06007A4F RID: 31311 RVA: 0x0003C8A4 File Offset: 0x0003AAA4
		' (set) Token: 0x06007A50 RID: 31312 RVA: 0x005B9840 File Offset: 0x005B7A40
		Private _txtOpeningStock As TextBox
		Friend Overridable Property txtOpeningStock As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtOpeningStock
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtOpeningStock_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtOpeningStock_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtOpeningStock
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtOpeningStock = value
				textBox = Me._txtOpeningStock
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CF2 RID: 11506
		' (get) Token: 0x06007A51 RID: 31313 RVA: 0x0003C8AE File Offset: 0x0003AAAE
		' (set) Token: 0x06007A52 RID: 31314 RVA: 0x0003C8B8 File Offset: 0x0003AAB8
		Friend Overridable Property Label13 As Label

		' Token: 0x17002CF3 RID: 11507
		' (get) Token: 0x06007A53 RID: 31315 RVA: 0x0003C8C1 File Offset: 0x0003AAC1
		' (set) Token: 0x06007A54 RID: 31316 RVA: 0x005B98BC File Offset: 0x005B7ABC
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtBarcode_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CF4 RID: 11508
		' (get) Token: 0x06007A55 RID: 31317 RVA: 0x0003C8CB File Offset: 0x0003AACB
		' (set) Token: 0x06007A56 RID: 31318 RVA: 0x0003C8D5 File Offset: 0x0003AAD5
		Friend Overridable Property txtBCode As TextBox

		' Token: 0x17002CF5 RID: 11509
		' (get) Token: 0x06007A57 RID: 31319 RVA: 0x0003C8DE File Offset: 0x0003AADE
		' (set) Token: 0x06007A58 RID: 31320 RVA: 0x005B9938 File Offset: 0x005B7B38
		Private _cmbSalesUnit As ComboBox
		Friend Overridable Property cmbSalesUnit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSalesUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSalesUnit_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSalesUnit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSalesUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSalesUnit = value
				comboBox = Me._cmbSalesUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CF6 RID: 11510
		' (get) Token: 0x06007A59 RID: 31321 RVA: 0x0003C8E8 File Offset: 0x0003AAE8
		' (set) Token: 0x06007A5A RID: 31322 RVA: 0x0003C8F2 File Offset: 0x0003AAF2
		Friend Overridable Property Label15 As Label

		' Token: 0x17002CF7 RID: 11511
		' (get) Token: 0x06007A5B RID: 31323 RVA: 0x0003C8FB File Offset: 0x0003AAFB
		' (set) Token: 0x06007A5C RID: 31324 RVA: 0x005B99B4 File Offset: 0x005B7BB4
		Private _cmbPurchaseUnit As ComboBox
		Friend Overridable Property cmbPurchaseUnit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPurchaseUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbPurchaseUnit_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPurchaseUnit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPurchaseUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPurchaseUnit = value
				comboBox = Me._cmbPurchaseUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CF8 RID: 11512
		' (get) Token: 0x06007A5D RID: 31325 RVA: 0x0003C905 File Offset: 0x0003AB05
		' (set) Token: 0x06007A5E RID: 31326 RVA: 0x0003C90F File Offset: 0x0003AB0F
		Friend Overridable Property Label14 As Label

		' Token: 0x17002CF9 RID: 11513
		' (get) Token: 0x06007A5F RID: 31327 RVA: 0x0003C918 File Offset: 0x0003AB18
		' (set) Token: 0x06007A60 RID: 31328 RVA: 0x0003C922 File Offset: 0x0003AB22
		Friend Overridable Property txtOStock As TextBox

		' Token: 0x17002CFA RID: 11514
		' (get) Token: 0x06007A61 RID: 31329 RVA: 0x0003C92B File Offset: 0x0003AB2B
		' (set) Token: 0x06007A62 RID: 31330 RVA: 0x0003C935 File Offset: 0x0003AB35
		Friend Overridable Property Label18 As Label

		' Token: 0x17002CFB RID: 11515
		' (get) Token: 0x06007A63 RID: 31331 RVA: 0x0003C93E File Offset: 0x0003AB3E
		' (set) Token: 0x06007A64 RID: 31332 RVA: 0x005B9A30 File Offset: 0x005B7C30
		Private _txtSGST As TextBox
		Friend Overridable Property txtSGST As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSGST_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSGST_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtSGST_TextChanged
				Dim textBox As TextBox = Me._txtSGST
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSGST = value
				textBox = Me._txtSGST
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CFC RID: 11516
		' (get) Token: 0x06007A65 RID: 31333 RVA: 0x0003C948 File Offset: 0x0003AB48
		' (set) Token: 0x06007A66 RID: 31334 RVA: 0x0003C952 File Offset: 0x0003AB52
		Friend Overridable Property Label17 As Label

		' Token: 0x17002CFD RID: 11517
		' (get) Token: 0x06007A67 RID: 31335 RVA: 0x0003C95B File Offset: 0x0003AB5B
		' (set) Token: 0x06007A68 RID: 31336 RVA: 0x005B9AAC File Offset: 0x005B7CAC
		Private _txtPartNo As TextBox
		Friend Overridable Property txtPartNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPartNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPartNo_KeyDown
				Dim textBox As TextBox = Me._txtPartNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtPartNo = value
				textBox = Me._txtPartNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002CFE RID: 11518
		' (get) Token: 0x06007A69 RID: 31337 RVA: 0x0003C965 File Offset: 0x0003AB65
		' (set) Token: 0x06007A6A RID: 31338 RVA: 0x0003C96F File Offset: 0x0003AB6F
		Friend Overridable Property Label16 As Label

		' Token: 0x17002CFF RID: 11519
		' (get) Token: 0x06007A6B RID: 31339 RVA: 0x0003C978 File Offset: 0x0003AB78
		' (set) Token: 0x06007A6C RID: 31340 RVA: 0x005B9AF0 File Offset: 0x005B7CF0
		Private _txtHSNCode As TextBox
		Friend Overridable Property txtHSNCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtHSNCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtHSNCode_KeyDown
				Dim textBox As TextBox = Me._txtHSNCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtHSNCode = value
				textBox = Me._txtHSNCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D00 RID: 11520
		' (get) Token: 0x06007A6D RID: 31341 RVA: 0x0003C982 File Offset: 0x0003AB82
		' (set) Token: 0x06007A6E RID: 31342 RVA: 0x0003C98C File Offset: 0x0003AB8C
		Friend Overridable Property Label19 As Label

		' Token: 0x17002D01 RID: 11521
		' (get) Token: 0x06007A6F RID: 31343 RVA: 0x0003C995 File Offset: 0x0003AB95
		' (set) Token: 0x06007A70 RID: 31344 RVA: 0x005B9B34 File Offset: 0x005B7D34
		Private _txtCESS As TextBox
		Friend Overridable Property txtCESS As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCESS
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCESS_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCESS
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCESS = value
				textBox = Me._txtCESS
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D02 RID: 11522
		' (get) Token: 0x06007A71 RID: 31345 RVA: 0x0003C99F File Offset: 0x0003AB9F
		' (set) Token: 0x06007A72 RID: 31346 RVA: 0x0003C9A9 File Offset: 0x0003ABA9
		Friend Overridable Property txtPName As TextBox

		' Token: 0x17002D03 RID: 11523
		' (get) Token: 0x06007A73 RID: 31347 RVA: 0x0003C9B2 File Offset: 0x0003ABB2
		' (set) Token: 0x06007A74 RID: 31348 RVA: 0x005B9B94 File Offset: 0x005B7D94
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D04 RID: 11524
		' (get) Token: 0x06007A75 RID: 31349 RVA: 0x0003C9BC File Offset: 0x0003ABBC
		' (set) Token: 0x06007A76 RID: 31350 RVA: 0x0003C9C6 File Offset: 0x0003ABC6
		Friend Overridable Property Label21 As Label

		' Token: 0x17002D05 RID: 11525
		' (get) Token: 0x06007A77 RID: 31351 RVA: 0x0003C9CF File Offset: 0x0003ABCF
		' (set) Token: 0x06007A78 RID: 31352 RVA: 0x005B9C34 File Offset: 0x005B7E34
		Private _cmbAltunit As ComboBox
		Friend Overridable Property cmbAltunit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAltunit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAltunit_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAltunit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAltunit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAltunit = value
				comboBox = Me._cmbAltunit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D06 RID: 11526
		' (get) Token: 0x06007A79 RID: 31353 RVA: 0x0003C9D9 File Offset: 0x0003ABD9
		' (set) Token: 0x06007A7A RID: 31354 RVA: 0x0003C9E3 File Offset: 0x0003ABE3
		Friend Overridable Property Label20 As Label

		' Token: 0x17002D07 RID: 11527
		' (get) Token: 0x06007A7B RID: 31355 RVA: 0x0003C9EC File Offset: 0x0003ABEC
		' (set) Token: 0x06007A7C RID: 31356 RVA: 0x0003C9F6 File Offset: 0x0003ABF6
		Friend Overridable Property Label22 As Label

		' Token: 0x17002D08 RID: 11528
		' (get) Token: 0x06007A7D RID: 31357 RVA: 0x0003C9FF File Offset: 0x0003ABFF
		' (set) Token: 0x06007A7E RID: 31358 RVA: 0x005B9CB0 File Offset: 0x005B7EB0
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

		' Token: 0x17002D09 RID: 11529
		' (get) Token: 0x06007A7F RID: 31359 RVA: 0x0003CA09 File Offset: 0x0003AC09
		' (set) Token: 0x06007A80 RID: 31360 RVA: 0x005B9CF4 File Offset: 0x005B7EF4
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

		' Token: 0x17002D0A RID: 11530
		' (get) Token: 0x06007A81 RID: 31361 RVA: 0x0003CA13 File Offset: 0x0003AC13
		' (set) Token: 0x06007A82 RID: 31362 RVA: 0x005B9D38 File Offset: 0x005B7F38
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

		' Token: 0x17002D0B RID: 11531
		' (get) Token: 0x06007A83 RID: 31363 RVA: 0x0003CA1D File Offset: 0x0003AC1D
		' (set) Token: 0x06007A84 RID: 31364 RVA: 0x005B9D7C File Offset: 0x005B7F7C
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D0C RID: 11532
		' (get) Token: 0x06007A85 RID: 31365 RVA: 0x0003CA27 File Offset: 0x0003AC27
		' (set) Token: 0x06007A86 RID: 31366 RVA: 0x005B9DC0 File Offset: 0x005B7FC0
		Private _cmbProductName As ComboBox
		Friend Overridable Property cmbProductName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbProductName = value
				comboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D0D RID: 11533
		' (get) Token: 0x06007A87 RID: 31367 RVA: 0x0003CA31 File Offset: 0x0003AC31
		' (set) Token: 0x06007A88 RID: 31368 RVA: 0x0003CA3B File Offset: 0x0003AC3B
		Friend Overridable Property txtPNo As TextBox

		' Token: 0x17002D0E RID: 11534
		' (get) Token: 0x06007A89 RID: 31369 RVA: 0x0003CA44 File Offset: 0x0003AC44
		' (set) Token: 0x06007A8A RID: 31370 RVA: 0x005B9E20 File Offset: 0x005B8020
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

		' Token: 0x17002D0F RID: 11535
		' (get) Token: 0x06007A8B RID: 31371 RVA: 0x0003CA4E File Offset: 0x0003AC4E
		' (set) Token: 0x06007A8C RID: 31372 RVA: 0x005B9E64 File Offset: 0x005B8064
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

		' Token: 0x17002D10 RID: 11536
		' (get) Token: 0x06007A8D RID: 31373 RVA: 0x0003CA58 File Offset: 0x0003AC58
		' (set) Token: 0x06007A8E RID: 31374 RVA: 0x005B9EA8 File Offset: 0x005B80A8
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

		' Token: 0x17002D11 RID: 11537
		' (get) Token: 0x06007A8F RID: 31375 RVA: 0x0003CA62 File Offset: 0x0003AC62
		' (set) Token: 0x06007A90 RID: 31376 RVA: 0x005B9EEC File Offset: 0x005B80EC
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

		' Token: 0x17002D12 RID: 11538
		' (get) Token: 0x06007A91 RID: 31377 RVA: 0x0003CA6C File Offset: 0x0003AC6C
		' (set) Token: 0x06007A92 RID: 31378 RVA: 0x005B9F30 File Offset: 0x005B8130
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

		' Token: 0x17002D13 RID: 11539
		' (get) Token: 0x06007A93 RID: 31379 RVA: 0x0003CA76 File Offset: 0x0003AC76
		' (set) Token: 0x06007A94 RID: 31380 RVA: 0x0003CA80 File Offset: 0x0003AC80
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17002D14 RID: 11540
		' (get) Token: 0x06007A95 RID: 31381 RVA: 0x0003CA89 File Offset: 0x0003AC89
		' (set) Token: 0x06007A96 RID: 31382 RVA: 0x005B9F74 File Offset: 0x005B8174
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

		' Token: 0x17002D15 RID: 11541
		' (get) Token: 0x06007A97 RID: 31383 RVA: 0x0003CA93 File Offset: 0x0003AC93
		' (set) Token: 0x06007A98 RID: 31384 RVA: 0x005B9FB8 File Offset: 0x005B81B8
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

		' Token: 0x17002D16 RID: 11542
		' (get) Token: 0x06007A99 RID: 31385 RVA: 0x0003CA9D File Offset: 0x0003AC9D
		' (set) Token: 0x06007A9A RID: 31386 RVA: 0x0003CAA7 File Offset: 0x0003ACA7
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17002D17 RID: 11543
		' (get) Token: 0x06007A9B RID: 31387 RVA: 0x0003CAB0 File Offset: 0x0003ACB0
		' (set) Token: 0x06007A9C RID: 31388 RVA: 0x005B9FFC File Offset: 0x005B81FC
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

		' Token: 0x17002D18 RID: 11544
		' (get) Token: 0x06007A9D RID: 31389 RVA: 0x0003CABA File Offset: 0x0003ACBA
		' (set) Token: 0x06007A9E RID: 31390 RVA: 0x005BA040 File Offset: 0x005B8240
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox5_TextChanged
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D19 RID: 11545
		' (get) Token: 0x06007A9F RID: 31391 RVA: 0x0003CAC4 File Offset: 0x0003ACC4
		' (set) Token: 0x06007AA0 RID: 31392 RVA: 0x0003CACE File Offset: 0x0003ACCE
		Friend Overridable Property Label26 As Label

		' Token: 0x17002D1A RID: 11546
		' (get) Token: 0x06007AA1 RID: 31393 RVA: 0x0003CAD7 File Offset: 0x0003ACD7
		' (set) Token: 0x06007AA2 RID: 31394 RVA: 0x005BA084 File Offset: 0x005B8284
		Private _txtIGST As TextBox
		Friend Overridable Property txtIGST As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtIGST_TextChanged
				Dim textBox As TextBox = Me._txtIGST
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtIGST = value
				textBox = Me._txtIGST
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D1B RID: 11547
		' (get) Token: 0x06007AA3 RID: 31395 RVA: 0x0003CAE1 File Offset: 0x0003ACE1
		' (set) Token: 0x06007AA4 RID: 31396 RVA: 0x005BA0C8 File Offset: 0x005B82C8
		Private _cmbGST As ComboBox
		Friend Overridable Property cmbGST As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbGST_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbGST_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbGST_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbGST
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.TextChanged, eventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler2
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbGST = value
				comboBox = Me._cmbGST
				If comboBox IsNot Nothing Then
					AddHandler comboBox.TextChanged, eventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler2
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D1C RID: 11548
		' (get) Token: 0x06007AA5 RID: 31397 RVA: 0x0003CAEB File Offset: 0x0003ACEB
		' (set) Token: 0x06007AA6 RID: 31398 RVA: 0x0003CAF5 File Offset: 0x0003ACF5
		Friend Overridable Property Label37 As Label

		' Token: 0x17002D1D RID: 11549
		' (get) Token: 0x06007AA7 RID: 31399 RVA: 0x0003CAFE File Offset: 0x0003ACFE
		' (set) Token: 0x06007AA8 RID: 31400 RVA: 0x005BA168 File Offset: 0x005B8368
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

		' Token: 0x17002D1E RID: 11550
		' (get) Token: 0x06007AA9 RID: 31401 RVA: 0x0003CB08 File Offset: 0x0003AD08
		' (set) Token: 0x06007AAA RID: 31402 RVA: 0x0003CB12 File Offset: 0x0003AD12
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002D1F RID: 11551
		' (get) Token: 0x06007AAB RID: 31403 RVA: 0x0003CB1B File Offset: 0x0003AD1B
		' (set) Token: 0x06007AAC RID: 31404 RVA: 0x0003CB25 File Offset: 0x0003AD25
		Friend Overridable Property Label40 As Label

		' Token: 0x17002D20 RID: 11552
		' (get) Token: 0x06007AAD RID: 31405 RVA: 0x0003CB2E File Offset: 0x0003AD2E
		' (set) Token: 0x06007AAE RID: 31406 RVA: 0x005BA1AC File Offset: 0x005B83AC
		Private _txtMinStock As TextBox
		Friend Overridable Property txtMinStock As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMinStock
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtMinStock_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtMinStock_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtMinStock
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtMinStock = value
				textBox = Me._txtMinStock
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D21 RID: 11553
		' (get) Token: 0x06007AAF RID: 31407 RVA: 0x0003CB38 File Offset: 0x0003AD38
		' (set) Token: 0x06007AB0 RID: 31408 RVA: 0x005BA228 File Offset: 0x005B8428
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

		' Token: 0x17002D22 RID: 11554
		' (get) Token: 0x06007AB1 RID: 31409 RVA: 0x0003CB42 File Offset: 0x0003AD42
		' (set) Token: 0x06007AB2 RID: 31410 RVA: 0x005BA26C File Offset: 0x005B846C
		Private _txtMRP As TextBox
		Friend Overridable Property txtMRP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMRP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtMRP_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtMRP_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtMRP_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtMRP_Leave
				Dim textBox As TextBox = Me._txtMRP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtMRP = value
				textBox = Me._txtMRP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D23 RID: 11555
		' (get) Token: 0x06007AB3 RID: 31411 RVA: 0x0003CB4C File Offset: 0x0003AD4C
		' (set) Token: 0x06007AB4 RID: 31412 RVA: 0x0003CB56 File Offset: 0x0003AD56
		Friend Overridable Property lblCondn As Label

		' Token: 0x17002D24 RID: 11556
		' (get) Token: 0x06007AB5 RID: 31413 RVA: 0x0003CB5F File Offset: 0x0003AD5F
		' (set) Token: 0x06007AB6 RID: 31414 RVA: 0x0003CB69 File Offset: 0x0003AD69
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17002D25 RID: 11557
		' (get) Token: 0x06007AB7 RID: 31415 RVA: 0x0003CB72 File Offset: 0x0003AD72
		' (set) Token: 0x06007AB8 RID: 31416 RVA: 0x0003CB7C File Offset: 0x0003AD7C
		Friend Overridable Property CheckBox4 As CheckBox

		' Token: 0x17002D26 RID: 11558
		' (get) Token: 0x06007AB9 RID: 31417 RVA: 0x0003CB85 File Offset: 0x0003AD85
		' (set) Token: 0x06007ABA RID: 31418 RVA: 0x005BA32C File Offset: 0x005B852C
		Private _cmbPTax As ComboBox
		Friend Overridable Property cmbPTax As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPTax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPTax_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPTax
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPTax = value
				comboBox = Me._cmbPTax
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D27 RID: 11559
		' (get) Token: 0x06007ABB RID: 31419 RVA: 0x0003CB8F File Offset: 0x0003AD8F
		' (set) Token: 0x06007ABC RID: 31420 RVA: 0x0003CB99 File Offset: 0x0003AD99
		Friend Overridable Property Label25 As Label

		' Token: 0x17002D28 RID: 11560
		' (get) Token: 0x06007ABD RID: 31421 RVA: 0x0003CBA2 File Offset: 0x0003ADA2
		' (set) Token: 0x06007ABE RID: 31422 RVA: 0x0003CBAC File Offset: 0x0003ADAC
		Friend Overridable Property Label24 As Label

		' Token: 0x17002D29 RID: 11561
		' (get) Token: 0x06007ABF RID: 31423 RVA: 0x0003CBB5 File Offset: 0x0003ADB5
		' (set) Token: 0x06007AC0 RID: 31424 RVA: 0x005BA38C File Offset: 0x005B858C
		Private _cmbSTax As ComboBox
		Friend Overridable Property cmbSTax As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSTax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSTax_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSTax
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSTax = value
				comboBox = Me._cmbSTax
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D2A RID: 11562
		' (get) Token: 0x06007AC1 RID: 31425 RVA: 0x0003CBBF File Offset: 0x0003ADBF
		' (set) Token: 0x06007AC2 RID: 31426 RVA: 0x0003CBC9 File Offset: 0x0003ADC9
		Friend Overridable Property LblLanguage As Label

		' Token: 0x17002D2B RID: 11563
		' (get) Token: 0x06007AC3 RID: 31427 RVA: 0x0003CBD2 File Offset: 0x0003ADD2
		' (set) Token: 0x06007AC4 RID: 31428 RVA: 0x005BA3EC File Offset: 0x005B85EC
		Private _Button41 As Button
		Friend Overridable Property Button41 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button41
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button41_Click
				Dim button As Button = Me._Button41
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button41 = value
				button = Me._Button41
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D2C RID: 11564
		' (get) Token: 0x06007AC5 RID: 31429 RVA: 0x0003CBDC File Offset: 0x0003ADDC
		' (set) Token: 0x06007AC6 RID: 31430 RVA: 0x005BA430 File Offset: 0x005B8630
		Private _Button40 As Button
		Friend Overridable Property Button40 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button40
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button40_Click
				Dim button As Button = Me._Button40
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button40 = value
				button = Me._Button40
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D2D RID: 11565
		' (get) Token: 0x06007AC7 RID: 31431 RVA: 0x0003CBE6 File Offset: 0x0003ADE6
		' (set) Token: 0x06007AC8 RID: 31432 RVA: 0x0003CBF0 File Offset: 0x0003ADF0
		Friend Overridable Property Label27 As Label

		' Token: 0x17002D2E RID: 11566
		' (get) Token: 0x06007AC9 RID: 31433 RVA: 0x0003CBF9 File Offset: 0x0003ADF9
		' (set) Token: 0x06007ACA RID: 31434 RVA: 0x0003CC03 File Offset: 0x0003AE03
		Friend Overridable Property Label23 As Label

		' Token: 0x17002D2F RID: 11567
		' (get) Token: 0x06007ACB RID: 31435 RVA: 0x0003CC0C File Offset: 0x0003AE0C
		' (set) Token: 0x06007ACC RID: 31436 RVA: 0x005BA474 File Offset: 0x005B8674
		Private _cmbRack As ComboBox
		Friend Overridable Property cmbRack As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbRack
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbRack_KeyDown
				Dim comboBox As ComboBox = Me._cmbRack
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbRack = value
				comboBox = Me._cmbRack
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D30 RID: 11568
		' (get) Token: 0x06007ACD RID: 31437 RVA: 0x0003CC16 File Offset: 0x0003AE16
		' (set) Token: 0x06007ACE RID: 31438 RVA: 0x005BA4B8 File Offset: 0x005B86B8
		Private _cmbGdown As ComboBox
		Friend Overridable Property cmbGdown As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbGdown
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbGdown_KeyDown
				Dim comboBox As ComboBox = Me._cmbGdown
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbGdown = value
				comboBox = Me._cmbGdown
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D31 RID: 11569
		' (get) Token: 0x06007ACF RID: 31439 RVA: 0x0003CC20 File Offset: 0x0003AE20
		' (set) Token: 0x06007AD0 RID: 31440 RVA: 0x0003CC2A File Offset: 0x0003AE2A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17002D32 RID: 11570
		' (get) Token: 0x06007AD1 RID: 31441 RVA: 0x0003CC33 File Offset: 0x0003AE33
		' (set) Token: 0x06007AD2 RID: 31442 RVA: 0x005BA4FC File Offset: 0x005B86FC
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

		' Token: 0x17002D33 RID: 11571
		' (get) Token: 0x06007AD3 RID: 31443 RVA: 0x0003CC3D File Offset: 0x0003AE3D
		' (set) Token: 0x06007AD4 RID: 31444 RVA: 0x0003CC47 File Offset: 0x0003AE47
		Friend Overridable Property txtExp As TextBox

		' Token: 0x17002D34 RID: 11572
		' (get) Token: 0x06007AD5 RID: 31445 RVA: 0x0003CC50 File Offset: 0x0003AE50
		' (set) Token: 0x06007AD6 RID: 31446 RVA: 0x0003CC5A File Offset: 0x0003AE5A
		Friend Overridable Property txtMfg As TextBox

		' Token: 0x17002D35 RID: 11573
		' (get) Token: 0x06007AD7 RID: 31447 RVA: 0x0003CC63 File Offset: 0x0003AE63
		' (set) Token: 0x06007AD8 RID: 31448 RVA: 0x005BA540 File Offset: 0x005B8740
		Private _cmbColour As ComboBox
		Friend Overridable Property cmbColour As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbColour
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbColour_KeyDown
				Dim comboBox As ComboBox = Me._cmbColour
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbColour = value
				comboBox = Me._cmbColour
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D36 RID: 11574
		' (get) Token: 0x06007AD9 RID: 31449 RVA: 0x0003CC6D File Offset: 0x0003AE6D
		' (set) Token: 0x06007ADA RID: 31450 RVA: 0x005BA584 File Offset: 0x005B8784
		Private _cmbSize As ComboBox
		Friend Overridable Property cmbSize As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSize
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSize_KeyDown
				Dim comboBox As ComboBox = Me._cmbSize
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbSize = value
				comboBox = Me._cmbSize
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D37 RID: 11575
		' (get) Token: 0x06007ADB RID: 31451 RVA: 0x0003CC77 File Offset: 0x0003AE77
		' (set) Token: 0x06007ADC RID: 31452 RVA: 0x005BA5C8 File Offset: 0x005B87C8
		Private _btnRemoveFromGridOS As Button
		Public Overridable Property btnRemoveFromGridOS As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemoveFromGridOS
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemoveFromGridOS_Click
				Dim button As Button = Me._btnRemoveFromGridOS
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemoveFromGridOS = value
				button = Me._btnRemoveFromGridOS
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D38 RID: 11576
		' (get) Token: 0x06007ADD RID: 31453 RVA: 0x0003CC81 File Offset: 0x0003AE81
		' (set) Token: 0x06007ADE RID: 31454 RVA: 0x005BA60C File Offset: 0x005B880C
		Private _btnAddOS As Button
		Public Overridable Property btnAddOS As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAddOS
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddOS_Click
				Dim button As Button = Me._btnAddOS
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAddOS = value
				button = Me._btnAddOS
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D39 RID: 11577
		' (get) Token: 0x06007ADF RID: 31455 RVA: 0x0003CC8B File Offset: 0x0003AE8B
		' (set) Token: 0x06007AE0 RID: 31456 RVA: 0x005BA650 File Offset: 0x005B8850
		Private _dtpExpiryDate As DateTimePicker
		Friend Overridable Property dtpExpiryDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpExpiryDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpExpiryDate_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.dtpExpiryDate_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._dtpExpiryDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._dtpExpiryDate = value
				dateTimePicker = Me._dtpExpiryDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D3A RID: 11578
		' (get) Token: 0x06007AE1 RID: 31457 RVA: 0x0003CC95 File Offset: 0x0003AE95
		' (set) Token: 0x06007AE2 RID: 31458 RVA: 0x005BA6B0 File Offset: 0x005B88B0
		Private _txtBatchNo As TextBox
		Friend Overridable Property txtBatchNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBatchNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBatchNo_KeyDown
				Dim textBox As TextBox = Me._txtBatchNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBatchNo = value
				textBox = Me._txtBatchNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D3B RID: 11579
		' (get) Token: 0x06007AE3 RID: 31459 RVA: 0x0003CC9F File Offset: 0x0003AE9F
		' (set) Token: 0x06007AE4 RID: 31460 RVA: 0x005BA6F4 File Offset: 0x005B88F4
		Private _dtpManufacturingDate As DateTimePicker
		Friend Overridable Property dtpManufacturingDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpManufacturingDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpManufacturingDate_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.dtpManufacturingDate_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._dtpManufacturingDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._dtpManufacturingDate = value
				dateTimePicker = Me._dtpManufacturingDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D3C RID: 11580
		' (get) Token: 0x06007AE5 RID: 31461 RVA: 0x0003CCA9 File Offset: 0x0003AEA9
		' (set) Token: 0x06007AE6 RID: 31462 RVA: 0x0003CCB3 File Offset: 0x0003AEB3
		Friend Overridable Property Label36 As Label

		' Token: 0x17002D3D RID: 11581
		' (get) Token: 0x06007AE7 RID: 31463 RVA: 0x0003CCBC File Offset: 0x0003AEBC
		' (set) Token: 0x06007AE8 RID: 31464 RVA: 0x0003CCC6 File Offset: 0x0003AEC6
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x17002D3E RID: 11582
		' (get) Token: 0x06007AE9 RID: 31465 RVA: 0x0003CCCF File Offset: 0x0003AECF
		' (set) Token: 0x06007AEA RID: 31466 RVA: 0x0003CCD9 File Offset: 0x0003AED9
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17002D3F RID: 11583
		' (get) Token: 0x06007AEB RID: 31467 RVA: 0x0003CCE2 File Offset: 0x0003AEE2
		' (set) Token: 0x06007AEC RID: 31468 RVA: 0x005BA754 File Offset: 0x005B8954
		Private _txtDefMRP As TextBox
		Friend Overridable Property txtDefMRP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDefMRP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDefMRP_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDefMRP_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtDefMRP_Leave
				Dim textBox As TextBox = Me._txtDefMRP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.Leave, eventHandler
				End If
				Me._txtDefMRP = value
				textBox = Me._txtDefMRP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.Leave, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D40 RID: 11584
		' (get) Token: 0x06007AED RID: 31469 RVA: 0x0003CCEC File Offset: 0x0003AEEC
		' (set) Token: 0x06007AEE RID: 31470 RVA: 0x0003CCF6 File Offset: 0x0003AEF6
		Friend Overridable Property Label8 As Label

		' Token: 0x17002D41 RID: 11585
		' (get) Token: 0x06007AEF RID: 31471 RVA: 0x0003CCFF File Offset: 0x0003AEFF
		' (set) Token: 0x06007AF0 RID: 31472 RVA: 0x0003CD09 File Offset: 0x0003AF09
		Friend Overridable Property Label10 As Label

		' Token: 0x17002D42 RID: 11586
		' (get) Token: 0x06007AF1 RID: 31473 RVA: 0x0003CD12 File Offset: 0x0003AF12
		' (set) Token: 0x06007AF2 RID: 31474 RVA: 0x0003CD1C File Offset: 0x0003AF1C
		Friend Overridable Property Label12 As Label

		' Token: 0x17002D43 RID: 11587
		' (get) Token: 0x06007AF3 RID: 31475 RVA: 0x0003CD25 File Offset: 0x0003AF25
		' (set) Token: 0x06007AF4 RID: 31476 RVA: 0x005BA7F4 File Offset: 0x005B89F4
		Private _txtRSPrice As TextBox
		Friend Overridable Property txtRSPrice As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRSPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtRSPrice_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRSPrice_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtRSPrice_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtRSPrice_Leave
				Dim textBox As TextBox = Me._txtRSPrice
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtRSPrice = value
				textBox = Me._txtRSPrice
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D44 RID: 11588
		' (get) Token: 0x06007AF5 RID: 31477 RVA: 0x0003CD2F File Offset: 0x0003AF2F
		' (set) Token: 0x06007AF6 RID: 31478 RVA: 0x005BA8B4 File Offset: 0x005B8AB4
		Private _txtWSPrice As TextBox
		Friend Overridable Property txtWSPrice As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWSPrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtWSPrice_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtWSPrice_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtWSPrice_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtWSPrice_Leave
				Dim textBox As TextBox = Me._txtWSPrice
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtWSPrice = value
				textBox = Me._txtWSPrice
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D45 RID: 11589
		' (get) Token: 0x06007AF7 RID: 31479 RVA: 0x0003CD39 File Offset: 0x0003AF39
		' (set) Token: 0x06007AF8 RID: 31480 RVA: 0x0003CD43 File Offset: 0x0003AF43
		Friend Overridable Property Label38 As Label

		' Token: 0x17002D46 RID: 11590
		' (get) Token: 0x06007AF9 RID: 31481 RVA: 0x0003CD4C File Offset: 0x0003AF4C
		' (set) Token: 0x06007AFA RID: 31482 RVA: 0x0003CD56 File Offset: 0x0003AF56
		Friend Overridable Property Label41 As Label

		' Token: 0x17002D47 RID: 11591
		' (get) Token: 0x06007AFB RID: 31483 RVA: 0x0003CD5F File Offset: 0x0003AF5F
		' (set) Token: 0x06007AFC RID: 31484 RVA: 0x0003CD69 File Offset: 0x0003AF69
		Friend Overridable Property TempBarcode As TextBox

		' Token: 0x17002D48 RID: 11592
		' (get) Token: 0x06007AFD RID: 31485 RVA: 0x0003CD72 File Offset: 0x0003AF72
		' (set) Token: 0x06007AFE RID: 31486 RVA: 0x0003CD7C File Offset: 0x0003AF7C
		Friend Overridable Property Label42 As Label

		' Token: 0x17002D49 RID: 11593
		' (get) Token: 0x06007AFF RID: 31487 RVA: 0x0003CD85 File Offset: 0x0003AF85
		' (set) Token: 0x06007B00 RID: 31488 RVA: 0x0003CD8F File Offset: 0x0003AF8F
		Friend Overridable Property Label28 As Label

		' Token: 0x17002D4A RID: 11594
		' (get) Token: 0x06007B01 RID: 31489 RVA: 0x0003CD98 File Offset: 0x0003AF98
		' (set) Token: 0x06007B02 RID: 31490 RVA: 0x0003CDA2 File Offset: 0x0003AFA2
		Friend Overridable Property Label30 As Label

		' Token: 0x17002D4B RID: 11595
		' (get) Token: 0x06007B03 RID: 31491 RVA: 0x0003CDAB File Offset: 0x0003AFAB
		' (set) Token: 0x06007B04 RID: 31492 RVA: 0x0003CDB5 File Offset: 0x0003AFB5
		Friend Overridable Property Label33 As Label

		' Token: 0x17002D4C RID: 11596
		' (get) Token: 0x06007B05 RID: 31493 RVA: 0x0003CDBE File Offset: 0x0003AFBE
		' (set) Token: 0x06007B06 RID: 31494 RVA: 0x0003CDC8 File Offset: 0x0003AFC8
		Friend Overridable Property Label31 As Label

		' Token: 0x17002D4D RID: 11597
		' (get) Token: 0x06007B07 RID: 31495 RVA: 0x0003CDD1 File Offset: 0x0003AFD1
		' (set) Token: 0x06007B08 RID: 31496 RVA: 0x0003CDDB File Offset: 0x0003AFDB
		Friend Overridable Property Label32 As Label

		' Token: 0x17002D4E RID: 11598
		' (get) Token: 0x06007B09 RID: 31497 RVA: 0x0003CDE4 File Offset: 0x0003AFE4
		' (set) Token: 0x06007B0A RID: 31498 RVA: 0x0003CDEE File Offset: 0x0003AFEE
		Friend Overridable Property Label29 As Label

		' Token: 0x17002D4F RID: 11599
		' (get) Token: 0x06007B0B RID: 31499 RVA: 0x0003CDF7 File Offset: 0x0003AFF7
		' (set) Token: 0x06007B0C RID: 31500 RVA: 0x0003CE01 File Offset: 0x0003B001
		Friend Overridable Property Label34 As Label

		' Token: 0x17002D50 RID: 11600
		' (get) Token: 0x06007B0D RID: 31501 RVA: 0x0003CE0A File Offset: 0x0003B00A
		' (set) Token: 0x06007B0E RID: 31502 RVA: 0x005BA974 File Offset: 0x005B8B74
		Private _CheckBox5 As CheckBox
		Friend Overridable Property CheckBox5 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox5_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox5
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox5 = value
				checkBox = Me._CheckBox5
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D51 RID: 11601
		' (get) Token: 0x06007B0F RID: 31503 RVA: 0x0003CE14 File Offset: 0x0003B014
		' (set) Token: 0x06007B10 RID: 31504 RVA: 0x005BA9B8 File Offset: 0x005B8BB8
		Private _txtSaleQty As TextBox
		Friend Overridable Property txtSaleQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSaleQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSaleQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSaleQty_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSaleQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSaleQty = value
				textBox = Me._txtSaleQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D52 RID: 11602
		' (get) Token: 0x06007B11 RID: 31505 RVA: 0x0003CE1E File Offset: 0x0003B01E
		' (set) Token: 0x06007B12 RID: 31506 RVA: 0x0003CE28 File Offset: 0x0003B028
		Friend Overridable Property Label35 As Label

		' Token: 0x17002D53 RID: 11603
		' (get) Token: 0x06007B13 RID: 31507 RVA: 0x0003CE31 File Offset: 0x0003B031
		' (set) Token: 0x06007B14 RID: 31508 RVA: 0x005BAA34 File Offset: 0x005B8C34
		Private _Button6 As Button
		Public Overridable Property Button6 As Button
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

		' Token: 0x17002D54 RID: 11604
		' (get) Token: 0x06007B15 RID: 31509 RVA: 0x0003CE3B File Offset: 0x0003B03B
		' (set) Token: 0x06007B16 RID: 31510 RVA: 0x0003CE45 File Offset: 0x0003B045
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17002D55 RID: 11605
		' (get) Token: 0x06007B17 RID: 31511 RVA: 0x0003CE4E File Offset: 0x0003B04E
		' (set) Token: 0x06007B18 RID: 31512 RVA: 0x0003CE58 File Offset: 0x0003B058
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17002D56 RID: 11606
		' (get) Token: 0x06007B19 RID: 31513 RVA: 0x0003CE61 File Offset: 0x0003B061
		' (set) Token: 0x06007B1A RID: 31514 RVA: 0x0003CE6B File Offset: 0x0003B06B
		Friend Overridable Property Label43 As Label

		' Token: 0x17002D57 RID: 11607
		' (get) Token: 0x06007B1B RID: 31515 RVA: 0x0003CE74 File Offset: 0x0003B074
		' (set) Token: 0x06007B1C RID: 31516 RVA: 0x0003CE7E File Offset: 0x0003B07E
		Friend Overridable Property numericUpDown1 As NumericUpDown

		' Token: 0x17002D58 RID: 11608
		' (get) Token: 0x06007B1D RID: 31517 RVA: 0x0003CE87 File Offset: 0x0003B087
		' (set) Token: 0x06007B1E RID: 31518 RVA: 0x005BAA78 File Offset: 0x005B8C78
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D59 RID: 11609
		' (get) Token: 0x06007B1F RID: 31519 RVA: 0x0003CE91 File Offset: 0x0003B091
		' (set) Token: 0x06007B20 RID: 31520 RVA: 0x005BAABC File Offset: 0x005B8CBC
		Private _cmbKitchen As ComboBox
		Friend Overridable Property cmbKitchen As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbKitchen
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbKitchen_KeyDown
				Dim comboBox As ComboBox = Me._cmbKitchen
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbKitchen = value
				comboBox = Me._cmbKitchen
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D5A RID: 11610
		' (get) Token: 0x06007B21 RID: 31521 RVA: 0x0003CE9B File Offset: 0x0003B09B
		' (set) Token: 0x06007B22 RID: 31522 RVA: 0x005BAB00 File Offset: 0x005B8D00
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

		' Token: 0x17002D5B RID: 11611
		' (get) Token: 0x06007B23 RID: 31523 RVA: 0x0003CEA5 File Offset: 0x0003B0A5
		' (set) Token: 0x06007B24 RID: 31524 RVA: 0x005BAB44 File Offset: 0x005B8D44
		Private _Label46 As Label
		Friend Overridable Property Label46 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label46
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label46_Click
				Dim label As Label = Me._Label46
				If label IsNot Nothing Then
					RemoveHandler label.Click, eventHandler
				End If
				Me._Label46 = value
				label = Me._Label46
				If label IsNot Nothing Then
					AddHandler label.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D5C RID: 11612
		' (get) Token: 0x06007B25 RID: 31525 RVA: 0x0003CEAF File Offset: 0x0003B0AF
		' (set) Token: 0x06007B26 RID: 31526 RVA: 0x0003CEB9 File Offset: 0x0003B0B9
		Friend Overridable Property lblunitinfo As Label

		' Token: 0x17002D5D RID: 11613
		' (get) Token: 0x06007B27 RID: 31527 RVA: 0x0003CEC2 File Offset: 0x0003B0C2
		' (set) Token: 0x06007B28 RID: 31528 RVA: 0x0003CECC File Offset: 0x0003B0CC
		Friend Overridable Property Label48 As Label

		' Token: 0x17002D5E RID: 11614
		' (get) Token: 0x06007B29 RID: 31529 RVA: 0x0003CED5 File Offset: 0x0003B0D5
		' (set) Token: 0x06007B2A RID: 31530 RVA: 0x0003CEDF File Offset: 0x0003B0DF
		Friend Overridable Property Label47 As Label

		' Token: 0x17002D5F RID: 11615
		' (get) Token: 0x06007B2B RID: 31531 RVA: 0x0003CEE8 File Offset: 0x0003B0E8
		' (set) Token: 0x06007B2C RID: 31532 RVA: 0x005BAB88 File Offset: 0x005B8D88
		Private _txtIMEI2 As TextBox
		Friend Overridable Property txtIMEI2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIMEI2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIMEI2_KeyDown
				Dim textBox As TextBox = Me._txtIMEI2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIMEI2 = value
				textBox = Me._txtIMEI2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D60 RID: 11616
		' (get) Token: 0x06007B2D RID: 31533 RVA: 0x0003CEF2 File Offset: 0x0003B0F2
		' (set) Token: 0x06007B2E RID: 31534 RVA: 0x005BABCC File Offset: 0x005B8DCC
		Private _txtIMEI1 As TextBox
		Friend Overridable Property txtIMEI1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIMEI1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIMEI1_KeyDown
				Dim textBox As TextBox = Me._txtIMEI1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIMEI1 = value
				textBox = Me._txtIMEI1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D61 RID: 11617
		' (get) Token: 0x06007B2F RID: 31535 RVA: 0x0003CEFC File Offset: 0x0003B0FC
		' (set) Token: 0x06007B30 RID: 31536 RVA: 0x0003CF06 File Offset: 0x0003B106
		Friend Overridable Property Label50 As Label

		' Token: 0x17002D62 RID: 11618
		' (get) Token: 0x06007B31 RID: 31537 RVA: 0x0003CF0F File Offset: 0x0003B10F
		' (set) Token: 0x06007B32 RID: 31538 RVA: 0x005BAC10 File Offset: 0x005B8E10
		Private _txtPurchase As TextBox
		Friend Overridable Property txtPurchase As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPurchase
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPurchase_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtPurchase_TextChanged
				Dim textBox As TextBox = Me._txtPurchase
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtPurchase = value
				textBox = Me._txtPurchase
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D63 RID: 11619
		' (get) Token: 0x06007B33 RID: 31539 RVA: 0x0003CF19 File Offset: 0x0003B119
		' (set) Token: 0x06007B34 RID: 31540 RVA: 0x0003CF23 File Offset: 0x0003B123
		Friend Overridable Property Label52 As Label

		' Token: 0x17002D64 RID: 11620
		' (get) Token: 0x06007B35 RID: 31541 RVA: 0x0003CF2C File Offset: 0x0003B12C
		' (set) Token: 0x06007B36 RID: 31542 RVA: 0x005BAC70 File Offset: 0x005B8E70
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D65 RID: 11621
		' (get) Token: 0x06007B37 RID: 31543 RVA: 0x0003CF36 File Offset: 0x0003B136
		' (set) Token: 0x06007B38 RID: 31544 RVA: 0x0003CF40 File Offset: 0x0003B140
		Friend Overridable Property cBoxLangs As ComboBox

		' Token: 0x17002D66 RID: 11622
		' (get) Token: 0x06007B39 RID: 31545 RVA: 0x0003CF49 File Offset: 0x0003B149
		' (set) Token: 0x06007B3A RID: 31546 RVA: 0x0003CF53 File Offset: 0x0003B153
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17002D67 RID: 11623
		' (get) Token: 0x06007B3B RID: 31547 RVA: 0x0003CF5C File Offset: 0x0003B15C
		' (set) Token: 0x06007B3C RID: 31548 RVA: 0x0003CF66 File Offset: 0x0003B166
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17002D68 RID: 11624
		' (get) Token: 0x06007B3D RID: 31549 RVA: 0x0003CF6F File Offset: 0x0003B16F
		' (set) Token: 0x06007B3E RID: 31550 RVA: 0x005BACB4 File Offset: 0x005B8EB4
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

		' Token: 0x17002D69 RID: 11625
		' (get) Token: 0x06007B3F RID: 31551 RVA: 0x0003CF79 File Offset: 0x0003B179
		' (set) Token: 0x06007B40 RID: 31552 RVA: 0x005BACF8 File Offset: 0x005B8EF8
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
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

		' Token: 0x17002D6A RID: 11626
		' (get) Token: 0x06007B41 RID: 31553 RVA: 0x0003CF83 File Offset: 0x0003B183
		' (set) Token: 0x06007B42 RID: 31554 RVA: 0x005BAD3C File Offset: 0x005B8F3C
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click_1
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

		' Token: 0x17002D6B RID: 11627
		' (get) Token: 0x06007B43 RID: 31555 RVA: 0x0003CF8D File Offset: 0x0003B18D
		' (set) Token: 0x06007B44 RID: 31556 RVA: 0x005BAD80 File Offset: 0x005B8F80
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

		' Token: 0x17002D6C RID: 11628
		' (get) Token: 0x06007B45 RID: 31557 RVA: 0x0003CF97 File Offset: 0x0003B197
		' (set) Token: 0x06007B46 RID: 31558 RVA: 0x005BADC4 File Offset: 0x005B8FC4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click_1
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

		' Token: 0x17002D6D RID: 11629
		' (get) Token: 0x06007B47 RID: 31559 RVA: 0x0003CFA1 File Offset: 0x0003B1A1
		' (set) Token: 0x06007B48 RID: 31560 RVA: 0x005BAE08 File Offset: 0x005B9008
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click_1
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

		' Token: 0x17002D6E RID: 11630
		' (get) Token: 0x06007B49 RID: 31561 RVA: 0x0003CFAB File Offset: 0x0003B1AB
		' (set) Token: 0x06007B4A RID: 31562 RVA: 0x005BAE4C File Offset: 0x005B904C
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint_1
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick_1
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D6F RID: 11631
		' (get) Token: 0x06007B4B RID: 31563 RVA: 0x0003CFB5 File Offset: 0x0003B1B5
		' (set) Token: 0x06007B4C RID: 31564 RVA: 0x0003CFBF File Offset: 0x0003B1BF
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17002D70 RID: 11632
		' (get) Token: 0x06007B4D RID: 31565 RVA: 0x0003CFC8 File Offset: 0x0003B1C8
		' (set) Token: 0x06007B4E RID: 31566 RVA: 0x0003CFD2 File Offset: 0x0003B1D2
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17002D71 RID: 11633
		' (get) Token: 0x06007B4F RID: 31567 RVA: 0x0003CFDB File Offset: 0x0003B1DB
		' (set) Token: 0x06007B50 RID: 31568 RVA: 0x0003CFE5 File Offset: 0x0003B1E5
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17002D72 RID: 11634
		' (get) Token: 0x06007B51 RID: 31569 RVA: 0x0003CFEE File Offset: 0x0003B1EE
		' (set) Token: 0x06007B52 RID: 31570 RVA: 0x0003CFF8 File Offset: 0x0003B1F8
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17002D73 RID: 11635
		' (get) Token: 0x06007B53 RID: 31571 RVA: 0x0003D001 File Offset: 0x0003B201
		' (set) Token: 0x06007B54 RID: 31572 RVA: 0x0003D00B File Offset: 0x0003B20B
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17002D74 RID: 11636
		' (get) Token: 0x06007B55 RID: 31573 RVA: 0x0003D014 File Offset: 0x0003B214
		' (set) Token: 0x06007B56 RID: 31574 RVA: 0x0003D01E File Offset: 0x0003B21E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17002D75 RID: 11637
		' (get) Token: 0x06007B57 RID: 31575 RVA: 0x0003D027 File Offset: 0x0003B227
		' (set) Token: 0x06007B58 RID: 31576 RVA: 0x0003D031 File Offset: 0x0003B231
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17002D76 RID: 11638
		' (get) Token: 0x06007B59 RID: 31577 RVA: 0x0003D03A File Offset: 0x0003B23A
		' (set) Token: 0x06007B5A RID: 31578 RVA: 0x0003D044 File Offset: 0x0003B244
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17002D77 RID: 11639
		' (get) Token: 0x06007B5B RID: 31579 RVA: 0x0003D04D File Offset: 0x0003B24D
		' (set) Token: 0x06007B5C RID: 31580 RVA: 0x0003D057 File Offset: 0x0003B257
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17002D78 RID: 11640
		' (get) Token: 0x06007B5D RID: 31581 RVA: 0x0003D060 File Offset: 0x0003B260
		' (set) Token: 0x06007B5E RID: 31582 RVA: 0x0003D06A File Offset: 0x0003B26A
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17002D79 RID: 11641
		' (get) Token: 0x06007B5F RID: 31583 RVA: 0x0003D073 File Offset: 0x0003B273
		' (set) Token: 0x06007B60 RID: 31584 RVA: 0x0003D07D File Offset: 0x0003B27D
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17002D7A RID: 11642
		' (get) Token: 0x06007B61 RID: 31585 RVA: 0x0003D086 File Offset: 0x0003B286
		' (set) Token: 0x06007B62 RID: 31586 RVA: 0x0003D090 File Offset: 0x0003B290
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17002D7B RID: 11643
		' (get) Token: 0x06007B63 RID: 31587 RVA: 0x0003D099 File Offset: 0x0003B299
		' (set) Token: 0x06007B64 RID: 31588 RVA: 0x0003D0A3 File Offset: 0x0003B2A3
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17002D7C RID: 11644
		' (get) Token: 0x06007B65 RID: 31589 RVA: 0x0003D0AC File Offset: 0x0003B2AC
		' (set) Token: 0x06007B66 RID: 31590 RVA: 0x0003D0B6 File Offset: 0x0003B2B6
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17002D7D RID: 11645
		' (get) Token: 0x06007B67 RID: 31591 RVA: 0x0003D0BF File Offset: 0x0003B2BF
		' (set) Token: 0x06007B68 RID: 31592 RVA: 0x0003D0C9 File Offset: 0x0003B2C9
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17002D7E RID: 11646
		' (get) Token: 0x06007B69 RID: 31593 RVA: 0x0003D0D2 File Offset: 0x0003B2D2
		' (set) Token: 0x06007B6A RID: 31594 RVA: 0x0003D0DC File Offset: 0x0003B2DC
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17002D7F RID: 11647
		' (get) Token: 0x06007B6B RID: 31595 RVA: 0x0003D0E5 File Offset: 0x0003B2E5
		' (set) Token: 0x06007B6C RID: 31596 RVA: 0x0003D0EF File Offset: 0x0003B2EF
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17002D80 RID: 11648
		' (get) Token: 0x06007B6D RID: 31597 RVA: 0x0003D0F8 File Offset: 0x0003B2F8
		' (set) Token: 0x06007B6E RID: 31598 RVA: 0x0003D102 File Offset: 0x0003B302
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002D81 RID: 11649
		' (get) Token: 0x06007B6F RID: 31599 RVA: 0x0003D10B File Offset: 0x0003B30B
		' (set) Token: 0x06007B70 RID: 31600 RVA: 0x0003D115 File Offset: 0x0003B315
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002D82 RID: 11650
		' (get) Token: 0x06007B71 RID: 31601 RVA: 0x0003D11E File Offset: 0x0003B31E
		' (set) Token: 0x06007B72 RID: 31602 RVA: 0x005BAEAC File Offset: 0x005B90AC
		Private _txtMRPMargin As TextBox
		Friend Overridable Property txtMRPMargin As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMRPMargin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMRPMargin_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtMRPMargin_Leave
				Dim textBox As TextBox = Me._txtMRPMargin
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtMRPMargin = value
				textBox = Me._txtMRPMargin
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D83 RID: 11651
		' (get) Token: 0x06007B73 RID: 31603 RVA: 0x0003D128 File Offset: 0x0003B328
		' (set) Token: 0x06007B74 RID: 31604 RVA: 0x0003D132 File Offset: 0x0003B332
		Friend Overridable Property Label39 As Label

		' Token: 0x17002D84 RID: 11652
		' (get) Token: 0x06007B75 RID: 31605 RVA: 0x0003D13B File Offset: 0x0003B33B
		' (set) Token: 0x06007B76 RID: 31606 RVA: 0x005BAF0C File Offset: 0x005B910C
		Private _txtWMargin As TextBox
		Friend Overridable Property txtWMargin As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWMargin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtWMargin_TextChanged
				Dim textBox As TextBox = Me._txtWMargin
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtWMargin = value
				textBox = Me._txtWMargin
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D85 RID: 11653
		' (get) Token: 0x06007B77 RID: 31607 RVA: 0x0003D145 File Offset: 0x0003B345
		' (set) Token: 0x06007B78 RID: 31608 RVA: 0x005BAF50 File Offset: 0x005B9150
		Private _txtSalePMargin As TextBox
		Friend Overridable Property txtSalePMargin As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalePMargin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSalePMargin_TextChanged
				Dim textBox As TextBox = Me._txtSalePMargin
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSalePMargin = value
				textBox = Me._txtSalePMargin
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D86 RID: 11654
		' (get) Token: 0x06007B79 RID: 31609 RVA: 0x0003D14F File Offset: 0x0003B34F
		' (set) Token: 0x06007B7A RID: 31610 RVA: 0x005BAF94 File Offset: 0x005B9194
		Private _txtWMarginNew As TextBox
		Friend Overridable Property txtWMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtWMarginNew_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtWMarginNew_Leave
				Dim textBox As TextBox = Me._txtWMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtWMarginNew = value
				textBox = Me._txtWMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D87 RID: 11655
		' (get) Token: 0x06007B7B RID: 31611 RVA: 0x0003D159 File Offset: 0x0003B359
		' (set) Token: 0x06007B7C RID: 31612 RVA: 0x005BAFF4 File Offset: 0x005B91F4
		Private _txtSaaleMarginNew As TextBox
		Friend Overridable Property txtSaaleMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSaaleMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSaaleMarginNew_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtSaaleMarginNew_Leave
				Dim textBox As TextBox = Me._txtSaaleMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtSaaleMarginNew = value
				textBox = Me._txtSaaleMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D88 RID: 11656
		' (get) Token: 0x06007B7D RID: 31613 RVA: 0x0003D163 File Offset: 0x0003B363
		' (set) Token: 0x06007B7E RID: 31614 RVA: 0x005BB054 File Offset: 0x005B9254
		Private _txtMRPMarginNew As TextBox
		Friend Overridable Property txtMRPMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMRPMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMRPMarginNew_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtMRPMarginNew_Leave
				Dim textBox As TextBox = Me._txtMRPMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtMRPMarginNew = value
				textBox = Me._txtMRPMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002D89 RID: 11657
		' (get) Token: 0x06007B7F RID: 31615 RVA: 0x0003D16D File Offset: 0x0003B36D
		' (set) Token: 0x06007B80 RID: 31616 RVA: 0x0003D177 File Offset: 0x0003B377
		Friend Overridable Property Label49 As Label

		' Token: 0x17002D8A RID: 11658
		' (get) Token: 0x06007B81 RID: 31617 RVA: 0x0003D180 File Offset: 0x0003B380
		' (set) Token: 0x06007B82 RID: 31618 RVA: 0x005BB0B4 File Offset: 0x005B92B4
		Private _chkMarginOnOff As CheckBox
		Friend Overridable Property chkMarginOnOff As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkMarginOnOff
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkMarginOnOff_CheckedChanged
				Dim checkBox As CheckBox = Me._chkMarginOnOff
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkMarginOnOff = value
				checkBox = Me._chkMarginOnOff
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D8B RID: 11659
		' (get) Token: 0x06007B83 RID: 31619 RVA: 0x0003D18A File Offset: 0x0003B38A
		' (set) Token: 0x06007B84 RID: 31620 RVA: 0x0003D194 File Offset: 0x0003B394
		Friend Overridable Property Output As TextBox

		' Token: 0x17002D8C RID: 11660
		' (get) Token: 0x06007B85 RID: 31621 RVA: 0x0003D19D File Offset: 0x0003B39D
		' (set) Token: 0x06007B86 RID: 31622 RVA: 0x0003D1A7 File Offset: 0x0003B3A7
		Friend Overridable Property Input As TextBox

		' Token: 0x06007B87 RID: 31623 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
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

		' Token: 0x06007B88 RID: 31624 RVA: 0x0020DD08 File Offset: 0x0020BF08
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06007B89 RID: 31625 RVA: 0x005BB0F8 File Offset: 0x005B92F8
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B8A RID: 31626 RVA: 0x005BB16C File Offset: 0x005B936C
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcode.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B8B RID: 31627 RVA: 0x005BB1F0 File Offset: 0x005B93F0
		Public Sub BCodeDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B8C RID: 31628 RVA: 0x005BB2D8 File Offset: 0x005B94D8
		Public Sub fillProductName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Productname) FROM Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbProductName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007B8D RID: 31629 RVA: 0x005BB40C File Offset: 0x005B960C
		Public Sub fillGdown()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GDown) FROM Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbGdown.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbGdown.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.cmbGdown.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B8E RID: 31630 RVA: 0x005BB54C File Offset: 0x005B974C
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

		' Token: 0x06007B8F RID: 31631 RVA: 0x005BB68C File Offset: 0x005B988C
		Public Sub NofillProductName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Productname) FROM Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
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

		' Token: 0x06007B90 RID: 31632 RVA: 0x005BB7A0 File Offset: 0x005B99A0
		Public Sub Reset()
			Me.CheckBox3.Checked = False
			Me.CheckBox4.Checked = True
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Me.fillProductName()
			Else
				Dim flag As Boolean = Not Me.CheckBox3.Checked
				If flag Then
					Me.NofillProductName()
				End If
			End If
			Me.txtCostPrice.Text = "0.00"
			Me.txtDefMRP.Text = "0.00"
			Me.txtProductCode.Text = ""
			Me.txtDiscount.Text = "0.00"
			Me.txtRSPrice.Text = "0.00"
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtHSNCode.Text = ""
			Me.txtPartNo.Text = ""
			Me.txtWSPrice.Text = "0.00"
			Me.txtFeatures.Text = ""
			Me.cmbProductName.Text = ""
			Me.cmbProductName.SelectedIndex = -1
			Me.cmbCategory.SelectedIndex = -1
			Me.cmbSubCategory.SelectedIndex = -1
			Me.cmbSubCategory.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.Picture.Image = Resources._12
			Me.cmbPurchaseUnit.SelectedIndex = -1
			Me.cmbSalesUnit.SelectedIndex = -1
			Me.cmbAltunit.SelectedIndex = -1
			Me.TextBox1.Text = "1"
			Me.dgw.Rows.Clear()
			Me.btnRemove.Enabled = False
			Me.auto()
			Me.GenerateBarcode()
			Me.txtPName.Text = ""
			Me.txtPNo.Text = ""
			Me.cmbProductName.Focus()
			Me.cmbGST.SelectedIndex = -1
			Me.cmbGST.Text = ""
			Me.fillDefaultTaxRate()
			Me.cmbNP.SelectedIndex = -1
			Me.txtMinStock.Text = Conversions.ToString(0)
			Me.txtOpeningStock.[ReadOnly] = False
			Me.txtOpeningStock.Enabled = True
			Me.cmbSTax.SelectedIndex = 0
			Me.cmbPTax.SelectedIndex = 1
			Me.fillGdown()
			Me.fillRack()
			Me.cmbGdown.SelectedIndex = -1
			Me.cmbGdown.Text = ""
			Me.cmbRack.SelectedIndex = -1
			Me.cmbRack.Text = ""
			Me.txtSaleQty.Text = "1"
			Me.Clear()
			Me.DataGridView1.Rows.Clear()
			Me.btnAddOS.Enabled = True
			Me.fillColor()
			Me.fillSize()
			Me.FillKitchen()
			Me.BCodeDisplay()
			Me.cmbKitchen.SelectedIndex = -1
			Me.txtMRPMarginNew.Text = "0.00"
			Me.txtSaaleMarginNew.Text = "0.00"
			Me.txtWMarginNew.Text = "0.00"
			Me.txtMRPMargin.Text = "0.00"
			Me.txtSalePMargin.Text = "0.00"
			Me.txtWMargin.Text = "0.00"
		End Sub

		' Token: 0x06007B91 RID: 31633 RVA: 0x005BBB60 File Offset: 0x005B9D60
		Public Sub fillCategory()
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

		' Token: 0x06007B92 RID: 31634 RVA: 0x005BBC94 File Offset: 0x005B9E94
		Public Sub fillUnit()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSalesUnit.Items.Clear()
				Me.cmbPurchaseUnit.Items.Clear()
				Me.cmbAltunit.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSalesUnit.Items.Add(dataRow(0).ToString())
						Me.cmbPurchaseUnit.Items.Add(dataRow(0).ToString())
						Me.cmbAltunit.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007B93 RID: 31635 RVA: 0x005BBE3C File Offset: 0x005BA03C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Store ON Product.PID = StockAdjustment_Store.ProductID where PID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Stock Adjustment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT PID FROM Product INNER JOIN Stock_Store_Join ON Product.PID = Stock_Store_Join.ProductID where PID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("Unable to delete..Already in use in Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "SELECT PID FROM Product INNER JOIN PurchaseOrder_Join ON Product.PID = PurchaseOrder_Join.ProductID where PID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
						If flag5 Then
							MessageBox.Show("Unable to delete..Already in use in Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "SELECT PID FROM Product INNER JOIN Stock_Product ON Product.PID = Stock_Product.ProductID where PID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "SELECT PID FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID where PID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
								If flag9 Then
									MessageBox.Show("Unable to delete..Already in use in Sale Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag10 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text6 As String = "SELECT PID FROM Product INNER JOIN Quotation_Join ON Product.PID = Quotation_Join.ProductID where PID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text6)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
									If flag11 Then
										MessageBox.Show("Unable to delete..Already in use in Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag12 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text7 As String = "SELECT PID FROM Product INNER JOIN Estimate_Join ON Product.PID = Estimate_Join.ProductID where PID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text7)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
										If flag13 Then
											MessageBox.Show("Unable to delete..Already in use in Estimate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag14 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text8 As String = "select ProductID from StockMovement where ProductID=@d1"
											ModCommonClasses.cmd = New SqlCommand(text8)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
											If flag15 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text9 As String = "delete from StockMovement where ProductID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text9)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
											End If
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text10 As String = "delete from Product_OpeningStock where ProductID=@d1"
											ModCommonClasses.cmd = New SqlCommand(text10)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
											Dim flag16 As Boolean = num > 0
											If flag16 Then
												ModCommonClasses.con.Close()
											End If
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text11 As String = "delete from ExtDB1 where a1=@d1"
											ModCommonClasses.cmd = New SqlCommand(text11)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteReader()
											ModCommonClasses.con.Close()
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text12 As String = "delete from Product where PID=@d1"
											ModCommonClasses.cmd = New SqlCommand(text12)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											num = ModCommonClasses.cmd.ExecuteNonQuery()
											Dim flag17 As Boolean = num > 0
											If flag17 Then
												ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "deleted the Product '", Me.cmbProductName.Text, "' having Product code '", Me.txtProductCode.Text, "'" }))
												MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.fillProductID()
												Me.Reset()
											Else
												MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.fillProductID()
												Me.Reset()
												Dim flag18 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
												If flag18 Then
													ModCommonClasses.con.Close()
												End If
												ModCommonClasses.con.Close()
											End If
											Me.DataforNP()
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B94 RID: 31636 RVA: 0x005BC760 File Offset: 0x005BA960
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Me.DataGridView1.ClearSelection()
			Dim num As Integer = Me.DataGridView1.RowCount - 1
			For i As Integer = 0 To num
				Dim num2 As Integer = Me.DataGridView1.RowCount - 1
				For j As Integer = 0 To num2
					Dim flag As Boolean = i <> j
					If flag Then
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.DataGridView1.Rows(i).Cells(9).Value, Me.DataGridView1.Rows(j).Cells(9).Value, False)
						If flag2 Then
							Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
						End If
					End If
				Next
			Next
			Dim num3 As Integer = Me.DataGridView1.Rows.Count - 1
			For k As Integer = 0 To num3
				Dim num4 As Integer = k + 1
				Dim num5 As Integer = Me.DataGridView1.Rows.Count - 1
				For l As Integer = num4 To num5
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(Me.DataGridView1.Rows(k).Cells(9).Value, Me.DataGridView1.Rows(l).Cells(9).Value, False)
					If flag3 Then
						MessageBox.Show("Unable to Update !" & vbCrLf & "Multiple Barcode Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
				Next
			Next
			Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtProductCode.Text)) = 0
			If flag4 Then
				MessageBox.Show("Please enter product code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtProductCode.Focus()
				Return
			End If
			Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbProductName.Text)) = 0
			If flag5 Then
				MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbProductName.Focus()
				Return
			End If
			Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
			If flag6 Then
				MessageBox.Show("Please Select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
				Return
			End If
			Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
			If flag7 Then
				MessageBox.Show("Please Select Sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSubCategory.Focus()
				Return
			End If
			Dim flag8 As Boolean = Me.cmbSTax.SelectedIndex = -1
			If flag8 Then
				MessageBox.Show("Please Select sale tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSTax.Focus()
				Return
			End If
			Dim flag9 As Boolean = Me.cmbPTax.SelectedIndex = -1
			If flag9 Then
				MessageBox.Show("Please Select purchase tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbPTax.Focus()
				Return
			End If
			Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtCostPrice.Text)) = 0
			If flag10 Then
				MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCostPrice.Focus()
				Return
			End If
			Dim flag11 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscount.Text)) = 0
			If flag11 Then
				MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDiscount.Focus()
				Return
			End If
			Dim flag12 As Boolean = Me.cmbGST.SelectedIndex = -1
			If flag12 Then
				MessageBox.Show("Please enter your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbGST.Focus()
				Return
			End If
			Dim flag13 As Boolean = Operators.CompareString(Me.txtMinStock.Text, "", False) = 0
			If flag13 Then
				MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtMinStock.Focus()
				Return
			End If
			Dim flag14 As Boolean = Strings.Len(Strings.Trim(Me.cmbPurchaseUnit.Text)) = 0
			If flag14 Then
				MessageBox.Show("Please Select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbPurchaseUnit.Focus()
				Return
			End If
			Dim flag15 As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesUnit.Text)) = 0
			If flag15 Then
				MessageBox.Show("Please Select sales unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSalesUnit.Focus()
				Return
			End If
			Dim flag16 As Boolean = Strings.Len(Strings.Trim(Me.cmbAltunit.Text)) = 0
			If flag16 Then
				MessageBox.Show("Please Select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbAltunit.Focus()
				Return
			End If
			Dim flag17 As Boolean = Strings.Len(Strings.Trim(Me.TextBox1.Text)) = 0
			If flag17 Then
				MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.TextBox1.Focus()
				Return
			End If
			Dim flag18 As Boolean = Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0
			If flag18 Then
				MessageBox.Show("Please enter Default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSaleQty.Focus()
				Return
			End If
			Dim flag19 As Boolean = Strings.Len(Strings.Trim(Me.txtDefMRP.Text)) = 0
			If flag19 Then
				MessageBox.Show("Please enter defalut MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDefMRP.Focus()
				Return
			End If
			Dim flag20 As Boolean = Strings.Len(Strings.Trim(Me.txtRSPrice.Text)) = 0
			If flag20 Then
				MessageBox.Show("Please enter Default Retail Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtRSPrice.Focus()
				Return
			End If
			Dim flag21 As Boolean = Strings.Len(Strings.Trim(Me.txtWSPrice.Text)) = 0
			If flag21 Then
				MessageBox.Show("Please enter Default Wholesale Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtWSPrice.Focus()
				Return
			End If
			Dim checked As Boolean = Me.CheckBox4.Checked
			If checked Then
				Me.sts = "Yes"
			Else
				Me.sts = "No"
			End If
			Dim flag22 As Boolean = Me.dgw.Rows.Count = 0
			If flag22 Then
				Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
			End If
			Try
				Dim flag23 As Boolean = (Operators.CompareString(Me.txtPName.Text, Me.cmbProductName.Text, False) = 0) And (Operators.CompareString(Me.txtPNo.Text, Me.txtPartNo.Text, False) = 0)
				If Not flag23 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select Productname,PartNo from Product where ProductName=@d1 And PartNo=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPartNo.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag24 As Boolean = ModCommonClasses.rdr.Read()
					If flag24 Then
						Dim flag25 As Boolean = MessageBox.Show("Product Name And Part Or Group already exists, Do you really want To proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
						If Not flag25 Then
							Me.cmbProductName.Text = ""
							Me.cmbProductName.Focus()
							Dim flag26 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag26 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
					End If
				End If
				Me.Fill()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = If(("Update Product Set Productname=@d2, SubCategoryID=@d3, Description=@d4, CostPrice=@d5, Discount=@d7, CGST=@d8, Barcode=@d10, ProductCode=@d1, PurchaseUnit=@d12,SalesUnit=@d13,SGST=@d14,HSNCode=@d15,PartNo=@d16,Cess=@d17,SalesAltUnit=@d18,Conv=@d19,MinStock=@d20,Status=@d22,STax=@d23,PTax=@d24,GDown=@d25,Rack=@d26,MRP=@d27,SellingPrice=@d28,ReorderPoint=@d29,DefQty=@d30,Kitchen=@d31 where PID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbProductName.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtSubCategoryID.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtFeatures.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCostPrice.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtDiscount.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtCGST.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "0")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbPurchaseUnit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.cmbSalesUnit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtSGST.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtHSNCode.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtPartNo.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(Me.txtCESS.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.cmbAltunit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.TextBox1.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.txtMinStock.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.sts)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.cmbSTax.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.cmbPTax.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.cmbGdown.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbRack.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(Me.txtDefMRP.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.txtRSPrice.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val(Me.txtWSPrice.Text))
				Dim flag27 As Boolean = (Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0) Or (Operators.CompareString(Me.txtSaleQty.Text, "0", False) = 0)
				If flag27 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "1")
				Else
					ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.txtSaleQty.Text)
				End If
				ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.cmbKitchen.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text3 As String = "Update Temp_Stock Set SalePrice=@d2, WSalePrice=@d3, StLimit=@d4 where ProductID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text3)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox4.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtMinStock.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag28 As Boolean = Not dataGridViewRow.IsNewRow
						If flag28 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "Select ProductID from Temp_Stock where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag29 As Boolean = ModCommonClasses.rdr.Read()
							If flag29 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "Update Temp_Stock Set MRP=@d1, SPrice=@d2, WPrice=@d3, Batch=@d4, Mfgdate=@d5, Expdate=@d6, Size=@d7, Colour=@d8, Barcode=@d9, SalePrice=@d10, WSalePrice=@d11, IMEI1=@d12, IMEI2=@d13, PPrice=@d14,QrBarcode=@d15 where ProductID=@d16 And Barcode=@d17"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d15", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
						Dim flag30 As Boolean = Not dataGridViewRow2.IsNewRow
						If flag30 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text6 As String = "Select ProductID from Product_OpeningStock where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text6)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag31 As Boolean = ModCommonClasses.rdr.Read()
							If flag31 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text7 As String = "Update Product_OpeningStock Set MRP=@d1, SalePrice=@d2, WSalePrice=@d3, Batch=@d4, Mfgdate=@d5, Expdate=@d6, Size=@d7, Colour=@d8, Barcode=@d9, RCipher=@d10, WCipher=@d11, PPrice=@d14, OPSValue=@d15, IMEI1=@d16, IMEI2=@d17 where ProductID=@d12 And Barcode=@d13"
								ModCommonClasses.cmd = New SqlCommand(text7)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(1).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(2).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(7).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(8).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(10).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(13).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(14).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(15).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(16).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator2 As IEnumerator
					If TypeOf enumerator2 Is IDisposable Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
						Dim flag32 As Boolean = Not dataGridViewRow3.IsNewRow
						If flag32 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text8 As String = "Select ProductID from Invoice_Product where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text8)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag33 As Boolean = ModCommonClasses.rdr.Read()
							If flag33 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text9 As String = "Update Invoice_Product Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text9)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
						Dim flag34 As Boolean = Not dataGridViewRow4.IsNewRow
						If flag34 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text10 As String = "Select ProductID from Stock_Product where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text10)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag35 As Boolean = ModCommonClasses.rdr.Read()
							If flag35 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text11 As String = "Update Stock_Product Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text11)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator4 As IEnumerator
					If TypeOf enumerator4 Is IDisposable Then
						TryCast(enumerator4, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj5 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow5 As DataGridViewRow = CType(obj5, DataGridViewRow)
						Dim flag36 As Boolean = Not dataGridViewRow5.IsNewRow
						If flag36 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text12 As String = "Select ProductID from Quotation_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text12)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag37 As Boolean = ModCommonClasses.rdr.Read()
							If flag37 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text13 As String = "Update Quotation_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text13)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator5 As IEnumerator
					If TypeOf enumerator5 Is IDisposable Then
						TryCast(enumerator5, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj6 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow6 As DataGridViewRow = CType(obj6, DataGridViewRow)
						Dim flag38 As Boolean = Not dataGridViewRow6.IsNewRow
						If flag38 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text14 As String = "Select ProductID from Estimate_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text14)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag39 As Boolean = ModCommonClasses.rdr.Read()
							If flag39 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text15 As String = "Update Estimate_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text15)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator6 As IEnumerator
					If TypeOf enumerator6 Is IDisposable Then
						TryCast(enumerator6, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj7 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow7 As DataGridViewRow = CType(obj7, DataGridViewRow)
						Dim flag40 As Boolean = Not dataGridViewRow7.IsNewRow
						If flag40 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text16 As String = "Select ProductID from PurchaseOrder_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text16)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag41 As Boolean = ModCommonClasses.rdr.Read()
							If flag41 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text17 As String = "Update PurchaseOrder_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text17)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator7 As IEnumerator
					If TypeOf enumerator7 Is IDisposable Then
						TryCast(enumerator7, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj8 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow8 As DataGridViewRow = CType(obj8, DataGridViewRow)
						Dim flag42 As Boolean = Not dataGridViewRow8.IsNewRow
						If flag42 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text18 As String = "Select ProductID from SalesReturn_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text18)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag43 As Boolean = ModCommonClasses.rdr.Read()
							If flag43 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text19 As String = "Update SalesReturn_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text19)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator8 As IEnumerator
					If TypeOf enumerator8 Is IDisposable Then
						TryCast(enumerator8, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj9 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow9 As DataGridViewRow = CType(obj9, DataGridViewRow)
						Dim flag44 As Boolean = Not dataGridViewRow9.IsNewRow
						If flag44 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text20 As String = "Select ProductID from PurchaseReturn_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text20)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag45 As Boolean = ModCommonClasses.rdr.Read()
							If flag45 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text21 As String = "Update PurchaseReturn_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text21)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator9 As IEnumerator
					If TypeOf enumerator9 Is IDisposable Then
						TryCast(enumerator9, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj10 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow10 As DataGridViewRow = CType(obj10, DataGridViewRow)
						Dim flag46 As Boolean = Not dataGridViewRow10.IsNewRow
						If flag46 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text22 As String = "Select ProductID from Stock_Store_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text22)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag47 As Boolean = ModCommonClasses.rdr.Read()
							If flag47 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text23 As String = "Update Stock_Store_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text23)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator10 As IEnumerator
					If TypeOf enumerator10 Is IDisposable Then
						TryCast(enumerator10, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj11 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow11 As DataGridViewRow = CType(obj11, DataGridViewRow)
						Dim flag48 As Boolean = Not dataGridViewRow11.IsNewRow
						If flag48 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text24 As String = "Select ProductID from StockAdjustment_Store where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text24)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag49 As Boolean = ModCommonClasses.rdr.Read()
							If flag49 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text25 As String = "Update StockAdjustment_Store Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text25)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator11 As IEnumerator
					If TypeOf enumerator11 Is IDisposable Then
						TryCast(enumerator11, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text26 As String = "delete from Product_Join where ProductID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text26)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text27 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Me.txtID.Text + ",@d2)"
				ModCommonClasses.cmd = New SqlCommand(text27)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				Try
					For Each obj12 As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow12 As DataGridViewRow = CType(obj12, DataGridViewRow)
						Dim flag50 As Boolean = Not dataGridViewRow12.IsNewRow
						If flag50 Then
							Dim memoryStream2 As MemoryStream = New MemoryStream()
							Dim image As Image = CType(dataGridViewRow12.Cells(0).Value, Image)
							Dim bitmap2 As Bitmap = New Bitmap(image)
							bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
							Dim buffer2 As Byte() = memoryStream2.GetBuffer()
							Dim sqlParameter2 As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
							sqlParameter2.Value = buffer2
							ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
						End If
					Next
				Finally
					Dim enumerator12 As IEnumerator
					If TypeOf enumerator12 Is IDisposable Then
						TryCast(enumerator12, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text28 As String = "delete from ExtDB1 where a1=@d1"
				ModCommonClasses.cmd = New SqlCommand(text28)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text29 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text29)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSalesUnit.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text30 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text30)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbAltunit.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the Product '", Me.cmbProductName.Text, "' having Product code '", Me.txtProductCode.Text, "'" }))
				ModFunc.RefreshRecords()
				MessageBox.Show("Successfully Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.btnUpdate.Enabled = False
				ModCommonClasses.con.Close()
				Me.txtPName.Text = ""
				Me.txtPNo.Text = ""
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007B95 RID: 31637 RVA: 0x0003D1B0 File Offset: 0x0003B3B0
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.BarcodeRemoveAll()
		End Sub

		' Token: 0x06007B96 RID: 31638 RVA: 0x005BF52C File Offset: 0x005BD72C
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06007B97 RID: 31639 RVA: 0x0003D1C1 File Offset: 0x0003B3C1
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources._12
		End Sub

		' Token: 0x06007B98 RID: 31640 RVA: 0x005BF5CC File Offset: 0x005BD7CC
		Public Sub Fill()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID from SubCategory where Category=@d1 and SubCategoryName=@d2"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSubCategory.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSubCategoryID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x06007B99 RID: 31641 RVA: 0x005BF6FC File Offset: 0x005BD8FC
		Private Sub frmProduct_Load(sender As Object, e As EventArgs)
			Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Registry.GetValue(Me.keyPath, Me.valueName, Nothing))
			Dim flag As Boolean = objectValue IsNot Nothing
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(objectValue.ToString(), "true", False) = 0
				If flag2 Then
					Me.chkMarginOnOff.Checked = True
					Me.CheckUncheckMargin()
				Else
					Me.chkMarginOnOff.Checked = False
					Me.CheckUncheckMargin()
				End If
			Else
				Me.chkMarginOnOff.Checked = False
				Me.CheckUncheckMargin()
			End If
			Me.LinkLabel2.TabStop = False
			Me.CheckBox5.TabStop = False
			Me.LblLanguage.Text = Configuration.defaultLanguage()
			Me.CheckBox3.TabStop = False
			Me.CheckBox4.TabStop = False
			Me.LinkLabel3.TabStop = False
			Me.cmbSTax.SelectedIndex = 0
			Me.cmbPTax.SelectedIndex = 1
			Me.DataforNP()
			Me.fillCategory()
			Me.fillUnit()
			Me.CheckBox3.Checked = False
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Me.fillProductName()
			Else
				Dim flag3 As Boolean = Not Me.CheckBox3.Checked
				If flag3 Then
					Me.NofillProductName()
				End If
			End If
			Me.LinkLabel1.TabStop = False
			Me.CipherCode()
			Me.fillTaxRate()
			Me.fillDefaultTaxRate()
			Me.fillProductID()
			Me.fillGdown()
			Me.fillRack()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.BarcodeRemoveAll()
			Me.OSHidnShow()
			Me.unitconverinfo()
			Me.transliterator = New Transliterator()
			Try
				For Each text As String In Me.transliterator.GetSupportedLanguages()
					Me.cBoxLangs.Items.Add(text)
				Next
			Finally
				Dim enumerator As List(Of String).Enumerator
				CType(enumerator, IDisposable).Dispose()
			End Try
			Me.cBoxLangs.SelectedIndex = 0
			Me.Convert_Language()
		End Sub

		' Token: 0x06007B9A RID: 31642 RVA: 0x005BF984 File Offset: 0x005BDB84
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) as default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Me.UpdateDataGridViewHeaders(Me.dgw, GlobalVariables.translations)
						Me.UpdateDataGridViewHeaders(Me.DataGridView1, GlobalVariables.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06007B9B RID: 31643 RVA: 0x005BFB48 File Offset: 0x005BDD48
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Dim flag3 As Boolean = TypeOf ctrl Is TabControl
			If flag3 Then
				Dim tabControl As TabControl = CType(ctrl, TabControl)
				Try
					For Each obj As Object In tabControl.TabPages
						Dim tabPage As TabPage = CType(obj, TabPage)
						Dim text2 As String = tabPage.Text
						Dim flag4 As Boolean = translations.ContainsKey(text2)
						If flag4 Then
							tabPage.Text = translations(text2)
						End If
						Try
							For Each obj2 As Object In tabPage.Controls
								Dim control As Control = CType(obj2, Control)
								Me.UpdateAllControls(control, translations)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Dim flag5 As Boolean = TypeOf ctrl Is MenuStrip
			If flag5 Then
				Dim menuStrip As MenuStrip = CType(ctrl, MenuStrip)
				Try
					For Each obj3 As Object In menuStrip.Items
						Dim toolStripMenuItem As ToolStripMenuItem = CType(obj3, ToolStripMenuItem)
						Me.UpdateMenuItems(toolStripMenuItem, translations)
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj4 As Object In ctrl.Controls
					Dim control2 As Control = CType(obj4, Control)
					Me.UpdateAllControls(control2, translations)
				Next
			Finally
				Dim enumerator4 As IEnumerator
				If TypeOf enumerator4 Is IDisposable Then
					TryCast(enumerator4, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06007B9C RID: 31644 RVA: 0x00208B7C File Offset: 0x00206D7C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView, translations As Dictionary(Of String, String))
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06007B9D RID: 31645 RVA: 0x005BFD74 File Offset: 0x005BDF74
		Private Sub UpdateMenuItems(menuItem As ToolStripMenuItem, translations As Dictionary(Of String, String))
			Dim text As String = menuItem.Text
			Dim flag As Boolean = translations.ContainsKey(text)
			If flag Then
				menuItem.Text = translations(text)
			End If
			Try
				For Each toolStripMenuItem As ToolStripMenuItem In menuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
					Me.UpdateMenuItems(toolStripMenuItem, translations)
				Next
			Finally
				Dim enumerator As IEnumerator(Of ToolStripMenuItem)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06007B9E RID: 31646 RVA: 0x005BFDF4 File Offset: 0x005BDFF4
		Private Sub CheckUncheckMargin()
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			Dim text As String
			If checked Then
				text = "true"
				Me.txtMRPMargin.Visible = True
				Me.txtSalePMargin.Visible = True
				Me.txtWMargin.Visible = True
				Me.Label39.Visible = True
			Else
				text = "false"
				Me.txtMRPMargin.Visible = False
				Me.txtSalePMargin.Visible = False
				Me.txtWMargin.Visible = False
				Me.Label39.Visible = False
			End If
			Registry.SetValue(Me.keyPath, Me.valueName, text)
		End Sub

		' Token: 0x06007B9F RID: 31647 RVA: 0x005BFEA0 File Offset: 0x005BE0A0
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

		' Token: 0x06007BA0 RID: 31648 RVA: 0x005BFF88 File Offset: 0x005BE188
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbSubCategory.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.cmbSubCategory.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.cmbSubCategory.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007BA1 RID: 31649 RVA: 0x005C0094 File Offset: 0x005BE294
		Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCostPrice.Text
					Dim selectionStart As Integer = Me.txtCostPrice.SelectionStart
					Dim selectionLength As Integer = Me.txtCostPrice.SelectionLength
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

		' Token: 0x06007BA2 RID: 31650 RVA: 0x005C018C File Offset: 0x005BE38C
		Private Sub txtReorderPoint_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtReorderPoint.Text
					Dim selectionStart As Integer = Me.txtReorderPoint.SelectionStart
					Dim selectionLength As Integer = Me.txtReorderPoint.SelectionLength
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

		' Token: 0x06007BA3 RID: 31651 RVA: 0x005C0284 File Offset: 0x005BE484
		Private Sub txtDiscount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscount.Text
					Dim selectionStart As Integer = Me.txtDiscount.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscount.SelectionLength
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

		' Token: 0x06007BA4 RID: 31652 RVA: 0x005C037C File Offset: 0x005BE57C
		Private Sub txtVAT_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCGST.Text
					Dim selectionStart As Integer = Me.txtCGST.SelectionStart
					Dim selectionLength As Integer = Me.txtCGST.SelectionLength
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

		' Token: 0x06007BA5 RID: 31653 RVA: 0x005C0474 File Offset: 0x005BE674
		Private Sub txtSellingPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtSellingPrice.Text
					Dim selectionStart As Integer = Me.txtSellingPrice.SelectionStart
					Dim selectionLength As Integer = Me.txtSellingPrice.SelectionLength
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

		' Token: 0x06007BA6 RID: 31654 RVA: 0x005C056C File Offset: 0x005BE76C
		Private Sub txtDefMRP_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDefMRP.Text
					Dim selectionStart As Integer = Me.txtDefMRP.SelectionStart
					Dim selectionLength As Integer = Me.txtDefMRP.SelectionLength
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

		' Token: 0x06007BA7 RID: 31655 RVA: 0x005C0664 File Offset: 0x005BE864
		Private Sub txtRSPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtRSPrice.Text
					Dim selectionStart As Integer = Me.txtRSPrice.SelectionStart
					Dim selectionLength As Integer = Me.txtRSPrice.SelectionLength
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

		' Token: 0x06007BA8 RID: 31656 RVA: 0x005C075C File Offset: 0x005BE95C
		Private Sub txtWSPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtWSPrice.Text
					Dim selectionStart As Integer = Me.txtWSPrice.SelectionStart
					Dim selectionLength As Integer = Me.txtWSPrice.SelectionLength
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

		' Token: 0x06007BA9 RID: 31657 RVA: 0x005C0854 File Offset: 0x005BEA54
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Me.dgw.Rows.Remove(dataGridViewRow)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
					Me.dgw.Rows.Remove(dataGridViewRow2)
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
			Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
		End Sub

		' Token: 0x06007BAA RID: 31658 RVA: 0x005C0950 File Offset: 0x005BEB50
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Try
					For Each obj As Object In Me.dgw.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.dgw.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.btnRemove.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007BAB RID: 31659 RVA: 0x005C0A04 File Offset: 0x005BEC04
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.dgw.Rows.Count > 0
			If flag Then
				Me.btnRemove.Enabled = True
			End If
		End Sub

		' Token: 0x06007BAC RID: 31660 RVA: 0x005C0A38 File Offset: 0x005BEC38
		Private Sub txtOpeningStock_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtOpeningStock.Text
					Dim selectionStart As Integer = Me.txtOpeningStock.SelectionStart
					Dim selectionLength As Integer = Me.txtOpeningStock.SelectionLength
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

		' Token: 0x06007BAD RID: 31661 RVA: 0x005C0B30 File Offset: 0x005BED30
		Private Sub txtMinStock_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtMinStock.Text
					Dim selectionStart As Integer = Me.txtMinStock.SelectionStart
					Dim selectionLength As Integer = Me.txtMinStock.SelectionLength
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

		' Token: 0x06007BAE RID: 31662 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs)
		End Sub

		' Token: 0x06007BAF RID: 31663 RVA: 0x005C0C28 File Offset: 0x005BEE28
		Private Sub txtSGST_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtSGST.Text
					Dim selectionStart As Integer = Me.txtSGST.SelectionStart
					Dim selectionLength As Integer = Me.txtSGST.SelectionLength
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

		' Token: 0x06007BB0 RID: 31664 RVA: 0x005C0D20 File Offset: 0x005BEF20
		Private Sub cmbSalesUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.cmbSalesUnit.Text = Me.cmbPurchaseUnit.Text
			Me.cmbAltunit.Text = Me.cmbSalesUnit.Text
			Dim flag As Boolean = Operators.CompareString(Me.cmbSalesUnit.Text, Me.cmbAltunit.Text, False) = 0
			If flag Then
				Me.TextBox1.Text = "1"
				Me.TextBox1.[ReadOnly] = True
				Me.TextBox1.Enabled = False
				Me.TextBox1.BackColor = Color.Gainsboro
			Else
				Me.TextBox1.Text = "1"
				Me.TextBox1.[ReadOnly] = False
				Me.TextBox1.Enabled = True
				Me.TextBox1.BackColor = Color.White
				Me.TextBox1.Focus()
			End If
			Me.unitconverinfo()
		End Sub

		' Token: 0x06007BB1 RID: 31665 RVA: 0x005C0E10 File Offset: 0x005BF010
		Private Sub cmbAltunit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbSalesUnit.Text, Me.cmbAltunit.Text, False) = 0
			If flag Then
				Me.TextBox1.Text = "1"
				Me.TextBox1.[ReadOnly] = True
				Me.TextBox1.Enabled = False
				Me.TextBox1.BackColor = Color.Gainsboro
			Else
				Me.TextBox1.Text = "1"
				Me.TextBox1.[ReadOnly] = False
				Me.TextBox1.Enabled = True
				Me.TextBox1.BackColor = Color.White
			End If
			Me.unitconverinfo()
		End Sub

		' Token: 0x06007BB2 RID: 31666 RVA: 0x005C0EC8 File Offset: 0x005BF0C8
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Not Char.IsDigit(e.KeyChar)
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0) And (textBox.Text.IndexOf(".") = -1)
			If flag2 Then
				e.Handled = False
			End If
			Dim flag3 As Boolean = (Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) = 0) And (textBox.SelectionStart = 0)
			If flag3 Then
				e.Handled = False
			End If
			Dim flag4 As Boolean = e.KeyChar = vbCr
			If flag4 Then
				MyBase.GetNextControl(textBox, True).Focus()
				Dim flag5 As Boolean = (e.KeyChar = vbCr) And (Operators.CompareString(textBox.Text, ".", False) = 0)
				If flag5 Then
					textBox.Clear()
				End If
			Else
				Dim num As Integer = textBox.Text.IndexOf(".")
				Dim length As Integer = textBox.Text.Length
				Dim flag6 As Boolean = Not e.Handled
				If flag6 Then
					Dim flag7 As Boolean = num = -1
					If flag7 Then
						e.Handled = False
					Else
						' The following expression was wrapped in a checked-expression
						Dim flag8 As Boolean = length - num > 5
						If flag8 Then
							e.Handled = True
						End If
					End If
				End If
				Dim flag9 As Boolean = e.KeyChar = vbBack
				If flag9 Then
					e.Handled = False
				End If
			End If
		End Sub

		' Token: 0x06007BB3 RID: 31667 RVA: 0x005C0EC8 File Offset: 0x005BF0C8
		Private Sub txtSaleQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Not Char.IsDigit(e.KeyChar)
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0) And (textBox.Text.IndexOf(".") = -1)
			If flag2 Then
				e.Handled = False
			End If
			Dim flag3 As Boolean = (Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) = 0) And (textBox.SelectionStart = 0)
			If flag3 Then
				e.Handled = False
			End If
			Dim flag4 As Boolean = e.KeyChar = vbCr
			If flag4 Then
				MyBase.GetNextControl(textBox, True).Focus()
				Dim flag5 As Boolean = (e.KeyChar = vbCr) And (Operators.CompareString(textBox.Text, ".", False) = 0)
				If flag5 Then
					textBox.Clear()
				End If
			Else
				Dim num As Integer = textBox.Text.IndexOf(".")
				Dim length As Integer = textBox.Text.Length
				Dim flag6 As Boolean = Not e.Handled
				If flag6 Then
					Dim flag7 As Boolean = num = -1
					If flag7 Then
						e.Handled = False
					Else
						' The following expression was wrapped in a checked-expression
						Dim flag8 As Boolean = length - num > 5
						If flag8 Then
							e.Handled = True
						End If
					End If
				End If
				Dim flag9 As Boolean = e.KeyChar = vbBack
				If flag9 Then
					e.Handled = False
				End If
			End If
		End Sub

		' Token: 0x06007BB4 RID: 31668 RVA: 0x005C1020 File Offset: 0x005BF220
		Private Sub btnProductSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Reset()
			MyProject.Forms.frmCategory.ShowDialog()
			MyProject.Forms.frmCategory.Dispose()
		End Sub

		' Token: 0x06007BB5 RID: 31669 RVA: 0x005C1080 File Offset: 0x005BF280
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Reset()
			MyProject.Forms.frmSubCategory.ShowDialog()
			MyProject.Forms.frmSubCategory.Dispose()
		End Sub

		' Token: 0x06007BB6 RID: 31670 RVA: 0x005C10E0 File Offset: 0x005BF2E0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUnit.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmUnit.Reset()
			MyProject.Forms.frmUnit.ShowDialog()
			MyProject.Forms.frmUnit.Dispose()
		End Sub

		' Token: 0x06007BB7 RID: 31671 RVA: 0x0003D1D5 File Offset: 0x0003B3D5
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Process.Start("https://services.gst.gov.in/services/searchhsnsac")
		End Sub

		' Token: 0x06007BB8 RID: 31672 RVA: 0x0003D1E3 File Offset: 0x0003B3E3
		Private Sub cmbPurchaseUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.cmbSalesUnit.Text = Me.cmbPurchaseUnit.Text
		End Sub

		' Token: 0x06007BB9 RID: 31673 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDefMRP_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBA RID: 31674 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRSPrice_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBB RID: 31675 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtWSPrice_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBC RID: 31676 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBD RID: 31677 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBE RID: 31678 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BBF RID: 31679 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtHSNCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC0 RID: 31680 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPartNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC1 RID: 31681 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFeatures_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC2 RID: 31682 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCostPrice_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC3 RID: 31683 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC4 RID: 31684 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSellingPrice_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC5 RID: 31685 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCGST_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC6 RID: 31686 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtReorderPoint_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC7 RID: 31687 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSGST_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC8 RID: 31688 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtOpeningStock_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BC9 RID: 31689 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCESS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCA RID: 31690 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCB RID: 31691 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPurchaseUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCC RID: 31692 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSalesUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCD RID: 31693 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAltunit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCE RID: 31694 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSTax_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BCF RID: 31695 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPTax_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD0 RID: 31696 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD1 RID: 31697 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSaleQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD2 RID: 31698 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtMinStock_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD3 RID: 31699 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbGdown_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD4 RID: 31700 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbRack_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BD5 RID: 31701 RVA: 0x005C1140 File Offset: 0x005BF340
		Public Sub fillProductID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PID) FROM Product order by PID ASC", ModCommonClasses.con)
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
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007BD6 RID: 31702 RVA: 0x005C1274 File Offset: 0x005BF474
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),Product.MRP,RTRIM(Status),RTRIM(STax),RTRIM(PTax),RTRIM(GDown),RTRIM(Rack), Product.DefQty, RTRIM(Product.Kitchen) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and PID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Me.txtOpeningStock.[ReadOnly] = True
					Me.txtOpeningStock.Enabled = False
					Me.Button6.Enabled = True
					Me.txtID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtProductCode.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.cmbProductName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtPName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtSubCategoryID.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.cmbCategory.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbSubCategory.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtHSNCode.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtPartNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtPNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtFeatures.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtCostPrice.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtRSPrice.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtDiscount.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtWSPrice.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.cmbPurchaseUnit.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.cmbSalesUnit.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.cmbAltunit.Text = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.txtMinStock.Text = ModCommonClasses.rdr.GetValue(22).ToString()
					Me.txtDefMRP.Text = ModCommonClasses.rdr.GetValue(23).ToString()
					Dim flag2 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(24).ToString(), "Yes", False) = 0
					If flag2 Then
						Me.CheckBox4.Checked = True
					Else
						Me.CheckBox4.Checked = False
					End If
					Me.cmbSTax.Text = ModCommonClasses.rdr.GetValue(25).ToString()
					Me.cmbPTax.Text = ModCommonClasses.rdr.GetValue(26).ToString()
					Me.cmbGdown.Text = ModCommonClasses.rdr.GetValue(27).ToString()
					Me.cmbRack.Text = ModCommonClasses.rdr.GetValue(28).ToString()
					Me.txtSaleQty.Text = ModCommonClasses.rdr.GetValue(29).ToString()
					Me.cmbKitchen.Text = ModCommonClasses.rdr.GetValue(30).ToString()
					Me.cmbGST.Text = Conversions.ToString(Conversion.Val(Me.txtIGST.Text))
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", ModCommonClasses.rdr.GetValue(0).ToString())
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						Dim image As Image = Image.FromStream(memoryStream)
						Me.dgw.Rows.Add(New Object() { image })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Product_OpeningStock.Qty, Product_OpeningStock.MRP,Product_OpeningStock.SalePrice,Product_OpeningStock.WSalePrice,RTRIM(Product_OpeningStock.Batch),RTRIM(Product_OpeningStock.Mfgdate),RTRIM(Product_OpeningStock.Expdate),RTRIM(Product_OpeningStock.Size),RTRIM(Product_OpeningStock.Colour),RTRIM(Product_OpeningStock.Barcode),RTRIM(Product_OpeningStock.RCipher),RTRIM(Product_OpeningStock.WCipher),RTRIM(Product_OpeningStock.Barcode),(Product_OpeningStock.PPrice),(Product_OpeningStock.OPSValue),RTRIM(Product_OpeningStock.IMEI1),RTRIM(Product_OpeningStock.IMEI2) from Product_OpeningStock where ProductID=@d1", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16) })
					End While
					Me.DataGridView1.ClearSelection()
					Me.btnAddOS.Enabled = False
					Me.btnRemoveFromGridOS.Enabled = False
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007BD7 RID: 31703 RVA: 0x0003D1FD File Offset: 0x0003B3FD
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06007BD8 RID: 31704 RVA: 0x005C19FC File Offset: 0x005BFBFC
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Product", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Product")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06007BD9 RID: 31705 RVA: 0x005C1AD8 File Offset: 0x005BFCD8
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
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

		' Token: 0x06007BDA RID: 31706 RVA: 0x005C1B94 File Offset: 0x005BFD94
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
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

		' Token: 0x06007BDB RID: 31707 RVA: 0x005C1C40 File Offset: 0x005BFE40
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Product").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007BDC RID: 31708 RVA: 0x005C1CF8 File Offset: 0x005BFEF8
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007BDD RID: 31709 RVA: 0x005C1D90 File Offset: 0x005BFF90
		Public Sub CipherCode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c0),RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c12),RTRIM(c13),RTRIM(c14) from CipherCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.b0 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.b1 = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.b2 = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.b3 = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.b4 = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.b5 = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.b6 = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.b7 = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.b8 = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.b9 = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.b12 = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.b13 = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.b14 = ModCommonClasses.rdr.GetValue(12).ToString()
				Else
					Me.b0 = Conversions.ToString(0)
					Me.b1 = Conversions.ToString(1)
					Me.b2 = Conversions.ToString(2)
					Me.b3 = Conversions.ToString(3)
					Me.b4 = Conversions.ToString(4)
					Me.b5 = Conversions.ToString(5)
					Me.b6 = Conversions.ToString(6)
					Me.b7 = Conversions.ToString(7)
					Me.b8 = Conversions.ToString(8)
					Me.b9 = Conversions.ToString(9)
					Me.b12 = Conversions.ToString(0)
					Me.b13 = Conversions.ToString(0)
					Me.b14 = "No"
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				Me.b0 = Conversions.ToString(0)
				Me.b1 = Conversions.ToString(1)
				Me.b2 = Conversions.ToString(2)
				Me.b3 = Conversions.ToString(3)
				Me.b4 = Conversions.ToString(4)
				Me.b5 = Conversions.ToString(5)
				Me.b6 = Conversions.ToString(6)
				Me.b7 = Conversions.ToString(7)
				Me.b8 = Conversions.ToString(8)
				Me.b9 = Conversions.ToString(9)
				Me.b12 = Conversions.ToString(0)
				Me.b13 = Conversions.ToString(0)
				Me.b14 = "No"
			End Try
		End Sub

		' Token: 0x06007BDE RID: 31710 RVA: 0x005C2094 File Offset: 0x005C0294
		Private Sub txtSellingPrice_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox3.Text = Conversions.ToString(Conversion.Val(Me.txtSellingPrice.Text) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox3.Text = Conversions.ToString(Conversion.Val(Me.txtSellingPrice.Text))
			End If
		End Sub

		' Token: 0x06007BDF RID: 31711 RVA: 0x005C2110 File Offset: 0x005C0310
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.TextBox2.Text = Me.TextBox3.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox2.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox2.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox2.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox2.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox2.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox2.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox2.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox2.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox2.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox2.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
					If flag11 Then
						Me.TextBox2.Text = Me.TextBox3.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox1.Checked
				If flag12 Then
					Me.TextBox2.Text = Me.TextBox3.Text
				End If
			End If
		End Sub

		' Token: 0x06007BE0 RID: 31712 RVA: 0x005C24E0 File Offset: 0x005C06E0
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox3.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtSellingPrice.Text)) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox3.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtSellingPrice.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.TextBox2.Text = Me.TextBox3.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox2.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox2.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox2.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox2.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox2.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox2.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox2.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox2.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox2.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox2.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox2.Text = Strings.Replace(Me.TextBox2.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
					If flag12 Then
						Me.TextBox2.Text = Me.TextBox3.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox1.Checked
				If flag13 Then
					Me.TextBox2.Text = Me.TextBox3.Text
				End If
			End If
		End Sub

		' Token: 0x06007BE1 RID: 31713 RVA: 0x005C2928 File Offset: 0x005C0B28
		Private Sub txtReorderPoint_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox5.Text = Conversions.ToString(Conversion.Val(Me.txtReorderPoint.Text) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox5.Text = Conversions.ToString(Conversion.Val(Me.txtReorderPoint.Text))
			End If
		End Sub

		' Token: 0x06007BE2 RID: 31714 RVA: 0x005C29A4 File Offset: 0x005C0BA4
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Me.TextBox4.Text = Me.TextBox5.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox4.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox4.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox4.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox4.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox4.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox4.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox4.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox4.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox4.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox4.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox4.Text, "", False) = 0
					If flag11 Then
						Me.TextBox4.Text = Me.TextBox5.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox2.Checked
				If flag12 Then
					Me.TextBox4.Text = Me.TextBox5.Text
				End If
			End If
		End Sub

		' Token: 0x06007BE3 RID: 31715 RVA: 0x005C2D74 File Offset: 0x005C0F74
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox5.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtReorderPoint.Text)) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox5.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtReorderPoint.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Me.TextBox4.Text = Me.TextBox5.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox4.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox4.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox4.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox4.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox4.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox4.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox4.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox4.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox4.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox4.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox4.Text = Strings.Replace(Me.TextBox4.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox4.Text, "", False) = 0
					If flag12 Then
						Me.TextBox4.Text = Me.TextBox5.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox2.Checked
				If flag13 Then
					Me.TextBox4.Text = Me.TextBox5.Text
				End If
			End If
		End Sub

		' Token: 0x06007BE4 RID: 31716 RVA: 0x005C31BC File Offset: 0x005C13BC
		Private Sub txtSGST_TextChanged(sender As Object, byvale As EventArgs)
			Me.txtSGST.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCGST.Text), 2), "0.00")
			Me.txtIGST.Text = Conversions.ToString(Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text))
		End Sub

		' Token: 0x06007BE5 RID: 31717 RVA: 0x005C3230 File Offset: 0x005C1430
		Private Sub txtCGST_TextChanged(sender As Object, e As EventArgs)
			Me.txtSGST.Text = Conversions.ToString(Conversion.Val(Me.txtCGST.Text))
			Me.txtIGST.Text = Conversions.ToString(Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text))
		End Sub

		' Token: 0x06007BE6 RID: 31718 RVA: 0x005C3294 File Offset: 0x005C1494
		Private Sub txtIGST_TextChanged(sender As Object, e As EventArgs)
			Me.txtIGST.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text), 2), "0.00")
		End Sub

		' Token: 0x06007BE7 RID: 31719 RVA: 0x0003D215 File Offset: 0x0003B415
		Private Sub cmbGST_TextChanged(sender As Object, e As EventArgs)
			Me.txtCGST.Text = Strings.Format(Math.Round(Conversion.Val(Me.cmbGST.Text) / 2.0, 2), "0.00")
		End Sub

		' Token: 0x06007BE8 RID: 31720 RVA: 0x005C32E4 File Offset: 0x005C14E4
		Public Sub fillTaxRate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Rate) FROM TaxCat order by Rate ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbGST.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbGST.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007BE9 RID: 31721 RVA: 0x005C3418 File Offset: 0x005C1618
		Public Sub fillDefaultTaxRate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Rate),RTRIM(IsDefault) from TaxCat where IsDefault=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmbGST.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.isd = ModCommonClasses.rdr.GetValue(1).ToString()
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

		' Token: 0x06007BEA RID: 31722 RVA: 0x0003D215 File Offset: 0x0003B415
		Private Sub cmbGST_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.txtCGST.Text = Strings.Format(Math.Round(Conversion.Val(Me.cmbGST.Text) / 2.0, 2), "0.00")
		End Sub

		' Token: 0x06007BEB RID: 31723 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbGST_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BEC RID: 31724 RVA: 0x005C3538 File Offset: 0x005C1738
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTaxCategory.ShowDialog()
			MyProject.Forms.frmTaxCategory.Dispose()
		End Sub

		' Token: 0x06007BED RID: 31725 RVA: 0x005C3588 File Offset: 0x005C1788
		Private Sub frmProduct_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCondn.Text, "Purchase_Add", False) = 0
			If flag Then
				MyProject.Forms.frmPurchaseEntry.Fillproducts()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.lblCondn.Text, "Sales_Add", False) = 0
			If flag2 Then
				MyProject.Forms.frmPOS.Fillproducts()
				MyProject.Forms.frmPOS.fillUnit()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.lblCondn.Text, "Sales_Add_Touch", False) = 0
			If flag3 Then
				MyProject.Forms.frmPOSTouch.Fillproducts()
				MyProject.Forms.frmPOSTouch.fillUnit()
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.lblCondn.Text, "Estimate_Add", False) = 0
			If flag4 Then
				MyProject.Forms.frmEstimate.Fillproducts()
			End If
		End Sub

		' Token: 0x06007BEE RID: 31726 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06007BEF RID: 31727 RVA: 0x005C3674 File Offset: 0x005C1874
		Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Me.fillProductName()
			Else
				Dim flag As Boolean = Not Me.CheckBox3.Checked
				If flag Then
					Me.NofillProductName()
				End If
			End If
		End Sub

		' Token: 0x06007BF0 RID: 31728 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtMRP_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF1 RID: 31729 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBatchNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF2 RID: 31730 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpManufacturingDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF3 RID: 31731 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpExpiryDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF4 RID: 31732 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSize_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF5 RID: 31733 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbColour_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF6 RID: 31734 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbKitchen_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF7 RID: 31735 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIMEI1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF8 RID: 31736 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIMEI2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BF9 RID: 31737 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPurchase_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007BFA RID: 31738 RVA: 0x005C36B8 File Offset: 0x005C18B8
		Private Sub txtMRP_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtMRP.Text
					Dim selectionStart As Integer = Me.txtMRP.SelectionStart
					Dim selectionLength As Integer = Me.txtMRP.SelectionLength
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

		' Token: 0x06007BFB RID: 31739 RVA: 0x005C37B0 File Offset: 0x005C19B0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSellingPrice.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSellingPrice, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSellingPrice, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtReorderPoint.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtReorderPoint, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtReorderPoint, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtOpeningStock.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtOpeningStock, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtOpeningStock, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtMRP.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtMRP, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtMRP, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtMinStock.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtMinStock, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtMinStock, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.txtDiscount.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.txtDiscount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtDiscount, String.Empty)
			End If
			Dim flag7 As Boolean = String.IsNullOrEmpty(Me.txtCostPrice.Text.Trim())
			If flag7 Then
				Me.ErrorProvider1.SetError(Me.txtCostPrice, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCostPrice, String.Empty)
			End If
			Dim flag8 As Boolean = String.IsNullOrEmpty(Me.txtBarcode.Text.Trim())
			If flag8 Then
				Me.ErrorProvider1.SetError(Me.txtBarcode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBarcode, String.Empty)
			End If
			Dim flag9 As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag9 Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
			Dim flag10 As Boolean = String.IsNullOrEmpty(Me.cmbSubCategory.Text.Trim())
			If flag10 Then
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, String.Empty)
			End If
			Dim flag11 As Boolean = String.IsNullOrEmpty(Me.cmbSalesUnit.Text.Trim())
			If flag11 Then
				Me.ErrorProvider1.SetError(Me.cmbSalesUnit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSalesUnit, String.Empty)
			End If
			Dim flag12 As Boolean = String.IsNullOrEmpty(Me.cmbPurchaseUnit.Text.Trim())
			If flag12 Then
				Me.ErrorProvider1.SetError(Me.cmbPurchaseUnit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPurchaseUnit, String.Empty)
			End If
			Dim flag13 As Boolean = String.IsNullOrEmpty(Me.cmbProductName.Text.Trim())
			If flag13 Then
				Me.ErrorProvider1.SetError(Me.cmbProductName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbProductName, String.Empty)
			End If
			Dim flag14 As Boolean = String.IsNullOrEmpty(Me.cmbGST.Text.Trim())
			If flag14 Then
				Me.ErrorProvider1.SetError(Me.cmbGST, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbGST, String.Empty)
			End If
			Dim flag15 As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag15 Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
			Dim flag16 As Boolean = String.IsNullOrEmpty(Me.cmbAltunit.Text.Trim())
			If flag16 Then
				Me.ErrorProvider1.SetError(Me.cmbAltunit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAltunit, String.Empty)
			End If
			Dim flag17 As Boolean = String.IsNullOrEmpty(Me.txtSaleQty.Text.Trim())
			If flag17 Then
				Me.ErrorProvider1.SetError(Me.txtSaleQty, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSaleQty, String.Empty)
			End If
			Dim flag18 As Boolean = String.IsNullOrEmpty(Me.txtCESS.Text.Trim())
			If flag18 Then
				Me.ErrorProvider1.SetError(Me.txtCESS, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCESS, String.Empty)
			End If
			Dim flag19 As Boolean = String.IsNullOrEmpty(Me.cmbSTax.Text.Trim())
			If flag19 Then
				Me.ErrorProvider1.SetError(Me.cmbSTax, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSTax, String.Empty)
			End If
			Dim flag20 As Boolean = String.IsNullOrEmpty(Me.cmbPTax.Text.Trim())
			If flag20 Then
				Me.ErrorProvider1.SetError(Me.cmbPTax, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPTax, String.Empty)
			End If
			Dim flag21 As Boolean = String.IsNullOrEmpty(Me.txtDefMRP.Text.Trim())
			If flag21 Then
				Me.ErrorProvider1.SetError(Me.txtDefMRP, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtDefMRP, String.Empty)
			End If
			Dim flag22 As Boolean = String.IsNullOrEmpty(Me.txtRSPrice.Text.Trim())
			If flag22 Then
				Me.ErrorProvider1.SetError(Me.txtRSPrice, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtRSPrice, String.Empty)
			End If
			Dim flag23 As Boolean = String.IsNullOrEmpty(Me.txtWSPrice.Text.Trim())
			If flag23 Then
				Me.ErrorProvider1.SetError(Me.txtWSPrice, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtWSPrice, String.Empty)
			End If
		End Sub

		' Token: 0x06007BFC RID: 31740 RVA: 0x005C3EB8 File Offset: 0x005C20B8
		Private Sub Button41_Click(sender As Object, e As EventArgs)
			Dim configuration As Configuration = New Configuration()
			configuration.ShowDialog()
			Me.LblLanguage.Text = Configuration.defaultLanguage()
		End Sub

		' Token: 0x06007BFD RID: 31741 RVA: 0x005C3EE4 File Offset: 0x005C20E4
		Private Sub Button40_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Internet connection not found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim listen As Listen = New Listen()
				listen.ShowDialog()
				Me.cmbProductName.Text = ""
				Me.cmbProductName.Focus()
				Dim cmbProductName As ComboBox = Me.cmbProductName
				Dim comboBox As ComboBox = cmbProductName
				cmbProductName.Text = comboBox.Text + String.Format("{0}", listen.Result)
				SendKeys.Send("{Enter}")
				listen.Dispose()
			End If
		End Sub

		' Token: 0x06007BFE RID: 31742 RVA: 0x0003D253 File Offset: 0x0003B453
		Private Sub dtpManufacturingDate_ValueChanged(sender As Object, e As EventArgs)
			Me.txtMfg.Text = Me.dtpManufacturingDate.Text
		End Sub

		' Token: 0x06007BFF RID: 31743 RVA: 0x0003D26D File Offset: 0x0003B46D
		Private Sub dtpExpiryDate_ValueChanged(sender As Object, e As EventArgs)
			Me.txtExp.Text = Me.dtpExpiryDate.Text
		End Sub

		' Token: 0x06007C00 RID: 31744 RVA: 0x0003D287 File Offset: 0x0003B487
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.txtMfg.Text = ""
			Me.txtExp.Text = ""
		End Sub

		' Token: 0x06007C01 RID: 31745 RVA: 0x005C3F7C File Offset: 0x005C217C
		Private Sub btnAddOS_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtOpeningStock.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtOpeningStock.Focus()
				Else
					Dim flag2 As Boolean = Conversion.Val(Me.txtDefMRP.Text) <= 0.0
					If flag2 Then
						MessageBox.Show("MRP must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtDefMRP.Focus()
					Else
						Dim flag3 As Boolean = Conversion.Val(Me.txtRSPrice.Text) <= 0.0
						If flag3 Then
							MessageBox.Show("Retail sale Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtRSPrice.Focus()
						Else
							Dim flag4 As Boolean = Conversion.Val(Me.txtWSPrice.Text) <= 0.0
							If flag4 Then
								MessageBox.Show("Wholesale Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtWSPrice.Focus()
							Else
								Dim flag5 As Boolean = Conversion.Val(Me.txtPurchase.Text) <= 0.0
								If flag5 Then
									MessageBox.Show("Purchase Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPurchase.Focus()
								Else
									Dim flag6 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
									If flag6 Then
										MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtBarcode.Focus()
									Else
										Dim flag7 As Boolean = DateTime.Compare(Me.dtpManufacturingDate.Value.[Date], Me.dtpExpiryDate.Value.[Date]) > 0
										If flag7 Then
											MessageBox.Show("Expiry date must be greater than mfg. date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												MessageBox.Show("Barcode Already Exists in Opening Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.txtBarcode.Focus()
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text2 As String = "select Barcode from Temp_Stock where Barcode=@d1"
												ModCommonClasses.cmd = New SqlCommand(text2)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
												If flag10 Then
													MessageBox.Show("Barcode Already Exists in Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.txtBarcode.Focus()
													Dim flag11 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag11 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "select Barcode from Invoice_Product where Barcode=@d1"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
													If flag12 Then
														MessageBox.Show("Barcode Already Used in Sales Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Me.txtBarcode.Focus()
														Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
														If flag13 Then
															ModCommonClasses.rdr.Close()
														End If
													Else
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text4 As String = "select Barcode from Stock_Product where Barcode=@d1"
														ModCommonClasses.cmd = New SqlCommand(text4)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag14 As Boolean = ModCommonClasses.rdr.Read()
														If flag14 Then
															MessageBox.Show("Barcode Already Used in Purchase Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
															Me.txtBarcode.Focus()
															Dim flag15 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag15 Then
																ModCommonClasses.rdr.Close()
															End If
														Else
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text5 As String = "select Barcode from Quotation_Join where Barcode=@d1"
															ModCommonClasses.cmd = New SqlCommand(text5)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
															If flag16 Then
																MessageBox.Show("Barcode Already Used in Quotation Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Me.txtBarcode.Focus()
																Dim flag17 As Boolean = ModCommonClasses.rdr IsNot Nothing
																If flag17 Then
																	ModCommonClasses.rdr.Close()
																End If
															Else
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text6 As String = "select Barcode from Estimate_Join where Barcode=@d1"
																ModCommonClasses.cmd = New SqlCommand(text6)
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag18 As Boolean = ModCommonClasses.rdr.Read()
																If flag18 Then
																	MessageBox.Show("Barcode Already Used in Estimate Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																	Me.txtBarcode.Focus()
																	Dim flag19 As Boolean = ModCommonClasses.rdr IsNot Nothing
																	If flag19 Then
																		ModCommonClasses.rdr.Close()
																	End If
																Else
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text7 As String = "select Barcode from PurchaseOrder_Join where Barcode=@d1"
																	ModCommonClasses.cmd = New SqlCommand(text7)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																	Dim flag20 As Boolean = ModCommonClasses.rdr.Read()
																	If flag20 Then
																		MessageBox.Show("Barcode Already Used in Purchase Order Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																		Me.txtBarcode.Focus()
																		Dim flag21 As Boolean = ModCommonClasses.rdr IsNot Nothing
																		If flag21 Then
																			ModCommonClasses.rdr.Close()
																		End If
																	Else
																		ModCommonClasses.con = New SqlConnection(ModCS.cs)
																		ModCommonClasses.con.Open()
																		Dim text8 As String = "select Barcode from SalesReturn_Join where Barcode=@d1"
																		ModCommonClasses.cmd = New SqlCommand(text8)
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																		ModCommonClasses.cmd.Connection = ModCommonClasses.con
																		ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																		Dim flag22 As Boolean = ModCommonClasses.rdr.Read()
																		If flag22 Then
																			MessageBox.Show("Barcode Already Used in Sales Return Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																			Me.txtBarcode.Focus()
																			Dim flag23 As Boolean = ModCommonClasses.rdr IsNot Nothing
																			If flag23 Then
																				ModCommonClasses.rdr.Close()
																			End If
																		Else
																			ModCommonClasses.con = New SqlConnection(ModCS.cs)
																			ModCommonClasses.con.Open()
																			Dim text9 As String = "select Barcode from PurchaseReturn_Join where Barcode=@d1"
																			ModCommonClasses.cmd = New SqlCommand(text9)
																			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																			ModCommonClasses.cmd.Connection = ModCommonClasses.con
																			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																			Dim flag24 As Boolean = ModCommonClasses.rdr.Read()
																			If flag24 Then
																				MessageBox.Show("Barcode Already Used in Purchase Return Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																				Me.txtBarcode.Focus()
																				Dim flag25 As Boolean = ModCommonClasses.rdr IsNot Nothing
																				If flag25 Then
																					ModCommonClasses.rdr.Close()
																				End If
																			Else
																				ModCommonClasses.con = New SqlConnection(ModCS.cs)
																				ModCommonClasses.con.Open()
																				Dim text10 As String = "select Barcode from Stock_Store_Join where Barcode=@d1"
																				ModCommonClasses.cmd = New SqlCommand(text10)
																				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																				ModCommonClasses.cmd.Connection = ModCommonClasses.con
																				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																				Dim flag26 As Boolean = ModCommonClasses.rdr.Read()
																				If flag26 Then
																					MessageBox.Show("Barcode Already Used in Stock Entry Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																					Me.txtBarcode.Focus()
																					Dim flag27 As Boolean = ModCommonClasses.rdr IsNot Nothing
																					If flag27 Then
																						ModCommonClasses.rdr.Close()
																					End If
																				Else
																					ModCommonClasses.con = New SqlConnection(ModCS.cs)
																					ModCommonClasses.con.Open()
																					Dim text11 As String = "select Barcode from StockAdjustment_Store where Barcode=@d1"
																					ModCommonClasses.cmd = New SqlCommand(text11)
																					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																					ModCommonClasses.cmd.Connection = ModCommonClasses.con
																					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																					Dim flag28 As Boolean = ModCommonClasses.rdr.Read()
																					If flag28 Then
																						MessageBox.Show("Barcode Already Used in Stock Adjustment Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.txtBarcode.Focus()
																						Dim flag29 As Boolean = ModCommonClasses.rdr IsNot Nothing
																						If flag29 Then
																							ModCommonClasses.rdr.Close()
																						End If
																					Else
																						Try
																							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
																								Dim flag30 As Boolean = Operators.ConditionalCompareObjectEqual(Me.txtBarcode.Text, dataGridViewRow.Cells(9).Value, False)
																								If flag30 Then
																									MessageBox.Show("Same Barcode No. is already added", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																									Me.txtBarcode.Focus()
																									Return
																								End If
																							Next
																						Finally
																							Dim enumerator As IEnumerator
																							If TypeOf enumerator Is IDisposable Then
																								TryCast(enumerator, IDisposable).Dispose()
																							End If
																						End Try
																						Dim flag31 As Boolean = Conversion.Val(Me.txtMRP.Text) > 0.0
																						Dim num As Double
																						If flag31 Then
																							num = Conversion.Val(Me.txtMRP.Text)
																						Else
																							num = Conversion.Val(Me.txtDefMRP.Text)
																						End If
																						Dim flag32 As Boolean = Conversion.Val(Me.txtSellingPrice.Text) > 0.0
																						Dim num2 As Double
																						If flag32 Then
																							num2 = Conversion.Val(Me.txtSellingPrice.Text)
																						Else
																							num2 = Conversion.Val(Me.txtRSPrice.Text)
																						End If
																						Dim flag33 As Boolean = Conversion.Val(Me.txtReorderPoint.Text) > 0.0
																						Dim num3 As Double
																						If flag33 Then
																							num3 = Conversion.Val(Me.txtReorderPoint.Text)
																						Else
																							num3 = Conversion.Val(Me.txtWSPrice.Text)
																						End If
																						Dim flag34 As Boolean = Me.cmbPTax.SelectedIndex = 0
																						Dim num4 As Double
																						If flag34 Then
																							num4 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text), 2), "0.00"))
																						Else
																							num4 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text), 2), "0.00"))
																						End If
																						Me.DataGridView1.Rows.Add(New Object() { Conversion.Val(Me.txtOpeningStock.Text), num, num2, num3, Me.txtBatchNo.Text, Me.txtMfg.Text, Me.txtExp.Text, Me.cmbSize.Text, Me.cmbColour.Text, Me.txtBarcode.Text, Me.TextBox2.Text, Me.TextBox4.Text, "", num4, Strings.Format(Math.Round(num4 * Conversion.Val(Me.txtOpeningStock.Text), 2), "0.00"), Me.txtIMEI1.Text, Me.txtIMEI2.Text })
																						Me.txtOpeningStock.Focus()
																						Me.CreateGenerate()
																						Me.AutoBarcode()
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

		' Token: 0x06007C02 RID: 31746 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub PurcCostCalc()
		End Sub

		' Token: 0x06007C03 RID: 31747 RVA: 0x005C4D0C File Offset: 0x005C2F0C
		Public Sub Clear()
			Me.txtOpeningStock.Text = Conversions.ToString(0)
			Me.txtBatchNo.Text = ""
			Me.txtPurchase.Text = "0.00"
			Me.txtMRP.Text = "0.00"
			Me.txtSellingPrice.Text = "0.00"
			Me.txtReorderPoint.Text = "0.00"
			Me.dtpExpiryDate.Value = DateAndTime.Today
			Me.dtpManufacturingDate.Value = DateAndTime.Today
			Me.txtMfg.Text = ""
			Me.txtExp.Text = ""
			Me.btnAddOS.Enabled = True
			Me.btnRemoveFromGridOS.Enabled = False
			Me.Button6.Enabled = False
			Me.cmbSize.SelectedIndex = -1
			Me.cmbSize.Text = ""
			Me.cmbColour.SelectedIndex = -1
			Me.cmbColour.Text = ""
			Me.TempBarcode.Text = ""
			Me.txtIMEI1.Text = ""
			Me.txtIMEI2.Text = ""
		End Sub

		' Token: 0x06007C04 RID: 31748 RVA: 0x005C4E5C File Offset: 0x005C305C
		Private Sub btnRemoveFromGridOS_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
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
					Me.btnRemoveFromGridOS.Enabled = False
					Me.BarcodeRemove()
					Me.AutoBarcode()
					Me.Clear()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007C05 RID: 31749 RVA: 0x005C4F40 File Offset: 0x005C3140
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Dim flag2 As Boolean = Me.btnSave.Enabled And Not Me.btnUpdate.Enabled
				If flag2 Then
					Me.btnRemoveFromGridOS.Enabled = True
				End If
			Else
				Dim flag3 As Boolean = Not Me.btnSave.Enabled And Me.btnUpdate.Enabled
				If flag3 Then
					Me.btnRemoveFromGridOS.Enabled = False
				End If
			End If
			Try
				Dim flag4 As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag4 Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtPurchase.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.txtMRP.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtSellingPrice.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtReorderPoint.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBatchNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtMfg.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtExp.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.cmbSize.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.cmbColour.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.TempBarcode.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtIMEI1.Text = dataGridViewRow.Cells(15).Value.ToString()
					Me.txtIMEI2.Text = dataGridViewRow.Cells(16).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007C06 RID: 31750 RVA: 0x005C51F0 File Offset: 0x005C33F0
		Public Sub fillColor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Colour) FROM Product_OpeningStock", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbColour.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbColour.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007C07 RID: 31751 RVA: 0x005C532C File Offset: 0x005C352C
		Public Sub fillSize()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Size) FROM Product_OpeningStock", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSize.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSize.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007C08 RID: 31752 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtRSPrice_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C09 RID: 31753 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtWSPrice_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C0A RID: 31754 RVA: 0x005C5468 File Offset: 0x005C3668
		Private Sub CreateGenerate()
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into GenerateBarcode(Barcode) Values (@d1)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06007C0B RID: 31755 RVA: 0x005C54F8 File Offset: 0x005C36F8
		Private Sub AutoBarcode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 RTRIM(Barcode) from GenerateBarcode order by ID DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtBarcode.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))) + 1.0)
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
				Me.txtBarcode.Text = ModCommonClasses.rdr.GetValue(0).ToString()
			End Try
		End Sub

		' Token: 0x06007C0C RID: 31756 RVA: 0x005C5608 File Offset: 0x005C3808
		Private Sub BarcodeRemove()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from GenerateBarcode where Barcode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TempBarcode.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007C0D RID: 31757 RVA: 0x005C56AC File Offset: 0x005C38AC
		Private Sub BarcodeRemoveAll()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from GenerateBarcode"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007C0E RID: 31758 RVA: 0x0003D2AC File Offset: 0x0003B4AC
		Private Sub frmProduct_Closed(sender As Object, e As EventArgs)
			Me.BarcodeRemoveAll()
		End Sub

		' Token: 0x06007C0F RID: 31759 RVA: 0x0003D2B6 File Offset: 0x0003B4B6
		Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs)
			Me.OSHidnShow()
		End Sub

		' Token: 0x06007C10 RID: 31760 RVA: 0x005C5730 File Offset: 0x005C3930
		Private Sub OSHidnShow()
			Dim checked As Boolean = Me.CheckBox5.Checked
			If checked Then
				Me.Label42.Visible = True
				Me.Label34.Visible = True
				Me.Label29.Visible = True
				Me.Label32.Visible = True
				Me.Label31.Visible = True
				Me.Label33.Visible = True
				Me.Label28.Visible = True
				Me.Label30.Visible = True
				Me.Label38.Visible = True
				Me.Label52.Visible = True
				Me.Label47.Visible = True
				Me.Label48.Visible = True
				Me.Label50.Visible = True
				Me.txtPurchase.Visible = True
				Me.txtMRP.Visible = True
				Me.txtSellingPrice.Visible = True
				Me.txtReorderPoint.Visible = True
				Me.txtBatchNo.Visible = True
				Me.txtMfg.Visible = True
				Me.txtExp.Visible = True
				Me.cmbSize.Visible = True
				Me.cmbColour.Visible = True
				Me.dtpManufacturingDate.Visible = True
				Me.dtpExpiryDate.Visible = True
				Me.TextBox2.Visible = True
				Me.TextBox4.Visible = True
				Me.txtIMEI1.Visible = True
				Me.txtIMEI2.Visible = True
				Me.Button5.Visible = True
				Me.Panel5.Visible = False
				Me.btnAddOS.Visible = True
				Me.btnRemoveFromGridOS.Visible = True
				Me.Button6.Visible = True
				Me.Label49.Visible = True
				Dim checked2 As Boolean = Me.chkMarginOnOff.Checked
				If checked2 Then
					Me.txtMRPMarginNew.Visible = True
					Me.txtSaaleMarginNew.Visible = True
					Me.txtWMarginNew.Visible = True
					Me.Label49.Visible = True
				End If
			End If
			Dim flag As Boolean = Not Me.CheckBox5.Checked
			If flag Then
				Me.Label42.Visible = False
				Me.Label34.Visible = False
				Me.Label29.Visible = False
				Me.Label32.Visible = False
				Me.Label31.Visible = False
				Me.Label33.Visible = False
				Me.Label28.Visible = False
				Me.Label30.Visible = False
				Me.Label38.Visible = False
				Me.Label52.Visible = False
				Me.Label47.Visible = False
				Me.Label48.Visible = False
				Me.Label50.Visible = False
				Me.txtPurchase.Visible = False
				Me.txtMRP.Visible = False
				Me.txtSellingPrice.Visible = False
				Me.txtReorderPoint.Visible = False
				Me.txtBatchNo.Visible = False
				Me.txtMfg.Visible = False
				Me.txtExp.Visible = False
				Me.cmbSize.Visible = False
				Me.cmbColour.Visible = False
				Me.dtpManufacturingDate.Visible = False
				Me.dtpExpiryDate.Visible = False
				Me.TextBox2.Visible = False
				Me.TextBox4.Visible = False
				Me.txtIMEI1.Visible = False
				Me.txtIMEI2.Visible = False
				Me.Button5.Visible = False
				Me.Panel5.Visible = True
				Me.btnAddOS.Visible = False
				Me.btnRemoveFromGridOS.Visible = False
				Me.Button6.Visible = False
				Me.Label49.Visible = False
				Me.txtMRPMarginNew.Visible = False
				Me.txtSaaleMarginNew.Visible = False
				Me.txtWMarginNew.Visible = False
			End If
		End Sub

		' Token: 0x06007C11 RID: 31761 RVA: 0x005C5B4C File Offset: 0x005C3D4C
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Conversion.Val(Me.txtDefMRP.Text) <= 0.0
				If flag Then
					MessageBox.Show("MRP must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtDefMRP.Focus()
				Else
					Dim flag2 As Boolean = Conversion.Val(Me.txtRSPrice.Text) <= 0.0
					If flag2 Then
						MessageBox.Show("Retail sale Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtRSPrice.Focus()
					Else
						Dim flag3 As Boolean = Conversion.Val(Me.txtWSPrice.Text) <= 0.0
						If flag3 Then
							MessageBox.Show("Wholesale Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtWSPrice.Focus()
						Else
							Dim flag4 As Boolean = Conversion.Val(Me.txtPurchase.Text) <= 0.0
							If flag4 Then
								MessageBox.Show("Purchase Price must be greater than zero", "Price Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtPurchase.Focus()
							Else
								Dim flag5 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
								If flag5 Then
									MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtBarcode.Focus()
								Else
									Dim flag6 As Boolean = DateTime.Compare(Me.dtpManufacturingDate.Value.[Date], Me.dtpExpiryDate.Value.[Date]) > 0
									If flag6 Then
										MessageBox.Show("Expiry date must be greater than mfg. date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Else
										Dim flag7 As Boolean = Conversion.Val(Me.txtMRP.Text) > 0.0
										Dim num As Double
										If flag7 Then
											num = Conversion.Val(Me.txtMRP.Text)
										Else
											num = Conversion.Val(Me.txtDefMRP.Text)
										End If
										Dim flag8 As Boolean = Conversion.Val(Me.txtSellingPrice.Text) > 0.0
										Dim num2 As Double
										If flag8 Then
											num2 = Conversion.Val(Me.txtSellingPrice.Text)
										Else
											num2 = Conversion.Val(Me.txtRSPrice.Text)
										End If
										Dim flag9 As Boolean = Conversion.Val(Me.txtReorderPoint.Text) > 0.0
										Dim num3 As Double
										If flag9 Then
											num3 = Conversion.Val(Me.txtReorderPoint.Text)
										Else
											num3 = Conversion.Val(Me.txtWSPrice.Text)
										End If
										Dim flag10 As Boolean = Me.cmbPTax.SelectedIndex = 0
										Dim num4 As Double
										If flag10 Then
											num4 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text), 2), "0.00"))
										Else
											num4 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text), 2), "0.00"))
										End If
										Dim index As Integer = Me.DataGridView1.CurrentRow.Index
										Me.DataGridView1(1, index).Value = num
										Me.DataGridView1(2, index).Value = num2
										Me.DataGridView1(3, index).Value = num3
										Me.DataGridView1(4, index).Value = Me.txtBatchNo.Text
										Me.DataGridView1(5, index).Value = Me.txtMfg.Text
										Me.DataGridView1(6, index).Value = Me.txtExp.Text
										Me.DataGridView1(7, index).Value = Me.cmbSize.Text
										Me.DataGridView1(8, index).Value = Me.cmbColour.Text
										Me.DataGridView1(9, index).Value = Me.txtBarcode.Text
										Me.DataGridView1(10, index).Value = Me.TextBox2.Text
										Me.DataGridView1(11, index).Value = Me.TextBox4.Text
										Me.DataGridView1(13, index).Value = num4
										Me.DataGridView1(14, index).Value = Strings.Format(Math.Round(num4 * Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView1(0, index).Value)), 2), "0.00")
										Me.DataGridView1(15, index).Value = Me.txtIMEI1.Text
										Me.DataGridView1(16, index).Value = Me.txtIMEI2.Text
										Me.txtOpeningStock.Focus()
										Me.CreateGenerate()
										Me.AutoBarcode()
										Me.txtOpeningStock.Text = Conversions.ToString(0)
										Me.txtBatchNo.Text = ""
										Me.txtPurchase.Text = "0.00"
										Me.txtMRP.Text = "0.00"
										Me.txtSellingPrice.Text = "0.00"
										Me.txtReorderPoint.Text = "0.00"
										Me.dtpExpiryDate.Value = DateAndTime.Today
										Me.dtpManufacturingDate.Value = DateAndTime.Today
										Me.txtMfg.Text = ""
										Me.txtExp.Text = ""
										Me.btnAddOS.Enabled = False
										Me.btnRemoveFromGridOS.Enabled = False
										Me.cmbSize.SelectedIndex = -1
										Me.cmbSize.Text = ""
										Me.cmbColour.SelectedIndex = -1
										Me.cmbColour.Text = ""
										Me.TempBarcode.Text = ""
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007C12 RID: 31762 RVA: 0x005C61C4 File Offset: 0x005C43C4
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill Product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					MyProject.Forms.frmOnlineImage.Label1.Text = Me.cmbProductName.Text
					MyProject.Forms.frmOnlineImage.Label2.Text = Conversions.ToString(Me.numericUpDown1.Value)
					MyProject.Forms.frmOnlineImage.ShowDialog()
				End If
			Else
				MessageBox.Show("Internet Connction not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Sub

		' Token: 0x06007C13 RID: 31763 RVA: 0x005C628C File Offset: 0x005C448C
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmKitchen_Section.Reset()
			MyProject.Forms.frmKitchen_Section.lblSet.Text = "Product"
			MyProject.Forms.frmKitchen_Section.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmKitchen_Section.ShowDialog()
		End Sub

		' Token: 0x06007C14 RID: 31764 RVA: 0x005C62F4 File Offset: 0x005C44F4
		Public Sub FillKitchen()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbKitchen.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbKitchen.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007C15 RID: 31765 RVA: 0x0003D2C0 File Offset: 0x0003B4C0
		Private Sub Label46_Click(sender As Object, e As EventArgs)
			Me.cmbKitchen.SelectedIndex = -1
		End Sub

		' Token: 0x06007C16 RID: 31766 RVA: 0x005C641C File Offset: 0x005C461C
		Public Sub unitconverinfo()
			Dim flag As Boolean = (Me.cmbSalesUnit.Text.Length > 0) And (Me.cmbAltunit.Text.Length > 0)
			If flag Then
				Me.lblunitinfo.Text = String.Concat(New String() { "1 ", Me.cmbSalesUnit.Text, "  =  ", Me.TextBox1.Text, " ", Me.cmbAltunit.Text })
			Else
				Me.lblunitinfo.Text = ""
			End If
		End Sub

		' Token: 0x06007C17 RID: 31767 RVA: 0x0003D2D0 File Offset: 0x0003B4D0
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.unitconverinfo()
		End Sub

		' Token: 0x06007C18 RID: 31768 RVA: 0x005C64C4 File Offset: 0x005C46C4
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Internet connection not found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					Dim flag3 As Boolean = Me.cBoxLangs.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select correct language", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cBoxLangs.Focus()
					Else
						Dim text As String = Me.cmbProductName.Text
						Dim text2 As String = If((Me.cBoxLangs.SelectedItem IsNot Nothing), Me.cBoxLangs.SelectedItem.ToString(), String.Empty)
						Try
							Dim flag4 As Boolean = Me.transliterator IsNot Nothing AndAlso Not String.IsNullOrEmpty(text) AndAlso Not String.IsNullOrEmpty(text2)
							If flag4 Then
								Dim text3 As String = Me.transliterator.Translate(text, text2)
								Me.txtFeatures.Text = text3
							Else
								MessageBox.Show("Please ensure all fields are selected and initialized.")
							End If
						Catch ex As Exception
							MessageBox.Show("Error: " + ex.Message)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06007C19 RID: 31769 RVA: 0x0003D1B0 File Offset: 0x0003B3B0
		Private Sub btnNew_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
			Me.BarcodeRemoveAll()
		End Sub

		' Token: 0x06007C1A RID: 31770 RVA: 0x005C6630 File Offset: 0x005C4830
		Private Sub btnSave_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Product having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 entry in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
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
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbProductName.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCategory.Focus()
					Else
						Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
						If flag8 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbSubCategory.Focus()
						Else
							Dim flag9 As Boolean = Me.cmbSTax.SelectedIndex = -1
							If flag9 Then
								MessageBox.Show("Please select sale tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbSTax.Focus()
							Else
								Dim flag10 As Boolean = Me.cmbPTax.SelectedIndex = -1
								If flag10 Then
									MessageBox.Show("Please select purchase tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbPTax.Focus()
								Else
									Dim flag11 As Boolean = Strings.Len(Strings.Trim(Me.txtCostPrice.Text)) = 0
									If flag11 Then
										MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtCostPrice.Focus()
									Else
										Dim flag12 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscount.Text)) = 0
										If flag12 Then
											MessageBox.Show("Please enter Discount%", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtDiscount.Focus()
										Else
											Dim flag13 As Boolean = Me.cmbGST.SelectedIndex = -1
											If flag13 Then
												MessageBox.Show("Please enter your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.cmbGST.Focus()
											Else
												Dim flag14 As Boolean = Operators.CompareString(Me.txtMinStock.Text, "", False) = 0
												If flag14 Then
													MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtMinStock.Focus()
												Else
													Dim flag15 As Boolean = Strings.Len(Strings.Trim(Me.cmbPurchaseUnit.Text)) = 0
													If flag15 Then
														MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.cmbPurchaseUnit.Focus()
													Else
														Dim flag16 As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesUnit.Text)) = 0
														If flag16 Then
															MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Me.cmbSalesUnit.Focus()
														Else
															Dim flag17 As Boolean = Strings.Len(Strings.Trim(Me.cmbAltunit.Text)) = 0
															If flag17 Then
																MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Me.cmbAltunit.Focus()
															Else
																Dim flag18 As Boolean = Strings.Len(Strings.Trim(Me.TextBox1.Text)) = 0
																If flag18 Then
																	MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																	Me.TextBox1.Focus()
																Else
																	Dim flag19 As Boolean = Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0
																	If flag19 Then
																		MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																		Me.txtSaleQty.Focus()
																	Else
																		Dim flag20 As Boolean = Conversion.Val(Me.txtDefMRP.Text) <= 0.0
																		If flag20 Then
																			MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Me.txtDefMRP.Focus()
																		Else
																			Dim flag21 As Boolean = Conversion.Val(Me.txtRSPrice.Text) <= 0.0
																			If flag21 Then
																				MessageBox.Show("Please enter Retail Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																				Me.txtRSPrice.Focus()
																			Else
																				Dim flag22 As Boolean = Conversion.Val(Me.txtWSPrice.Text) <= 0.0
																				If flag22 Then
																					MessageBox.Show("Please enter Wholesale Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																					Me.txtWSPrice.Focus()
																				Else
																					Dim flag23 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
																					If flag23 Then
																						MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																						Me.txtBarcode.Focus()
																					Else
																						Dim flag24 As Boolean = Me.dgw.Rows.Count = 0
																						If flag24 Then
																							Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
																						End If
																						Dim checked As Boolean = Me.CheckBox4.Checked
																						If checked Then
																							Me.sts = "Yes"
																						Else
																							Me.sts = "No"
																						End If
																						Me.CheckBox3.TabStop = False
																						Try
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text3 As String = "select Productname,PartNo from Product where ProductName=@d1 and PartNo=@d2"
																							ModCommonClasses.cmd = New SqlCommand(text3)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPartNo.Text)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																							Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
																							If flag25 Then
																								Dim flag26 As Boolean = MessageBox.Show("Product Name and Part or Group already exists, Do you really want to proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
																								If Not flag26 Then
																									Me.cmbProductName.Text = ""
																									Me.cmbProductName.Focus()
																									Dim flag27 As Boolean = ModCommonClasses.rdr IsNot Nothing
																									If flag27 Then
																										ModCommonClasses.rdr.Close()
																									End If
																									Return
																								End If
																							End If
																							Dim flag28 As Boolean = Me.DataGridView1.Rows.Count > 0
																							If flag28 Then
																								Try
																									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
																										ModCommonClasses.con = New SqlConnection(ModCS.cs)
																										ModCommonClasses.con.Open()
																										Dim text4 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																										ModCommonClasses.cmd = New SqlCommand(text4)
																										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value))
																										ModCommonClasses.cmd.Connection = ModCommonClasses.con
																										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																										Dim flag29 As Boolean = ModCommonClasses.rdr.Read()
																										If flag29 Then
																											MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																											Me.DataGridView1.Focus()
																											Dim flag30 As Boolean = ModCommonClasses.rdr IsNot Nothing
																											If flag30 Then
																												ModCommonClasses.rdr.Close()
																											End If
																											Return
																										End If
																										ModCommonClasses.con = New SqlConnection(ModCS.cs)
																										ModCommonClasses.con.Open()
																										Dim text5 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																										ModCommonClasses.cmd = New SqlCommand(text5)
																										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value))
																										ModCommonClasses.cmd.Connection = ModCommonClasses.con
																										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																										Dim flag31 As Boolean = ModCommonClasses.rdr.Read()
																										If flag31 Then
																											MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																											Me.DataGridView1.Focus()
																											Dim flag32 As Boolean = ModCommonClasses.rdr IsNot Nothing
																											If flag32 Then
																												ModCommonClasses.rdr.Close()
																											End If
																											Return
																										End If
																									Next
																								Finally
																									Dim enumerator As IEnumerator
																									If TypeOf enumerator Is IDisposable Then
																										TryCast(enumerator, IDisposable).Dispose()
																									End If
																								End Try
																							Else
																								Dim flag33 As Boolean = Me.DataGridView1.Rows.Count <= 0
																								If flag33 Then
																									ModCommonClasses.con = New SqlConnection(ModCS.cs)
																									ModCommonClasses.con.Open()
																									Dim text6 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																									ModCommonClasses.cmd = New SqlCommand(text6)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																									ModCommonClasses.cmd.Connection = ModCommonClasses.con
																									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																									Dim flag34 As Boolean = ModCommonClasses.rdr.Read()
																									If flag34 Then
																										MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																										Me.DataGridView1.Focus()
																										Dim flag35 As Boolean = ModCommonClasses.rdr IsNot Nothing
																										If flag35 Then
																											ModCommonClasses.rdr.Close()
																										End If
																										Return
																									End If
																									ModCommonClasses.con = New SqlConnection(ModCS.cs)
																									ModCommonClasses.con.Open()
																									Dim text7 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																									ModCommonClasses.cmd = New SqlCommand(text7)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
																									ModCommonClasses.cmd.Connection = ModCommonClasses.con
																									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																									Dim flag36 As Boolean = ModCommonClasses.rdr.Read()
																									If flag36 Then
																										MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																										Me.DataGridView1.Focus()
																										Dim flag37 As Boolean = ModCommonClasses.rdr IsNot Nothing
																										If flag37 Then
																											ModCommonClasses.rdr.Close()
																										End If
																										Return
																									End If
																								End If
																							End If
																							Me.Fill()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text8 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
																							ModCommonClasses.cmd = New SqlCommand(text8)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																							Dim flag38 As Boolean = ModCommonClasses.rdr.Read()
																							Dim text9 As String
																							Dim num As Double
																							If flag38 Then
																								text9 = ModCommonClasses.rdr(1).ToString()
																								num = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
																								Dim flag39 As Boolean = ModCommonClasses.rdr IsNot Nothing
																								If flag39 Then
																									ModCommonClasses.rdr.Close()
																								End If
																							End If
																							Me.auto()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text10 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen, loyality_mode, loyality_value) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35)"
																							ModCommonClasses.cmd = New SqlCommand(text10)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbProductName.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtSubCategoryID.Text))
																							Dim flag40 As Boolean = Operators.CompareString(Me.txtFeatures.Text, "", False) <> 0
																							If flag40 Then
																								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtFeatures.Text)
																							Else
																								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbProductName.Text)
																							End If
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCostPrice.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtDiscount.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtCGST.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", "0")
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbPurchaseUnit.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.cmbSalesUnit.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtSGST.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtHSNCode.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtPartNo.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(Me.txtCESS.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.cmbAltunit.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.TextBox1.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.txtMinStock.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.sts)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.cmbSTax.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.cmbPTax.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.cmbGdown.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbRack.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(Me.txtDefMRP.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.txtRSPrice.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val(Me.txtWSPrice.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "0")
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
																							Dim flag41 As Boolean = (Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0) Or (Operators.CompareString(Me.txtSaleQty.Text, "0", False) = 0)
																							If flag41 Then
																								ModCommonClasses.cmd.Parameters.AddWithValue("@d32", "1")
																							Else
																								ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Me.txtSaleQty.Text)
																							End If
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.cmbKitchen.Text)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d34", text9.ToString())
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d35", Conversion.Val(num))
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.ExecuteNonQuery()
																							ModCommonClasses.con.Close()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text11 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																							ModCommonClasses.cmd = New SqlCommand(text11)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.Prepare()
																							Try
																								For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
																									Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
																									Dim flag42 As Boolean = Not dataGridViewRow2.IsNewRow
																									If flag42 Then
																										Dim memoryStream As MemoryStream = New MemoryStream()
																										Dim image As Image = CType(dataGridViewRow2.Cells(0).Value, Image)
																										Dim bitmap As Bitmap = New Bitmap(image)
																										bitmap.Save(memoryStream, ImageFormat.Jpeg)
																										Dim buffer As Byte() = memoryStream.GetBuffer()
																										Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																										sqlParameter.Value = buffer
																										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
																										ModCommonClasses.cmd.ExecuteNonQuery()
																										ModCommonClasses.cmd.Parameters.Clear()
																									End If
																								Next
																							Finally
																								Dim enumerator2 As IEnumerator
																								If TypeOf enumerator2 Is IDisposable Then
																									TryCast(enumerator2, IDisposable).Dispose()
																								End If
																							End Try
																							ModCommonClasses.con.Close()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text12 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																							ModCommonClasses.cmd = New SqlCommand(text12)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.Prepare()
																							Dim flag43 As Boolean = Me.DataGridView1.Rows.Count > 0
																							If flag43 Then
																								Try
																									For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																										Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
																										Dim flag44 As Boolean = Not dataGridViewRow3.IsNewRow
																										If flag44 Then
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(1).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(2).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(3).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(8).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(9).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(10).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(11).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(13).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(14).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(15).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(16).Value))
																											ModCommonClasses.cmd.ExecuteNonQuery()
																											ModCommonClasses.cmd.Parameters.Clear()
																										End If
																									Next
																								Finally
																									Dim enumerator3 As IEnumerator
																									If TypeOf enumerator3 Is IDisposable Then
																										TryCast(enumerator3, IDisposable).Dispose()
																									End If
																								End Try
																							Else
																								Dim flag45 As Boolean = Me.DataGridView1.Rows.Count <= 0
																								If flag45 Then
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtOpeningStock.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtDefMRP.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtRSPrice.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtWSPrice.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtBarcode.Text)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
																									Dim flag46 As Boolean = Me.cmbPTax.SelectedIndex = 0
																									Dim num2 As Double
																									If flag46 Then
																										num2 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text), 2), "0.00"))
																									Else
																										num2 = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text), 2), "0.00"))
																									End If
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", num2)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Strings.Format(Math.Round(num2 * Conversion.Val(Me.txtOpeningStock.Text), 2), "0.00"))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "")
																									ModCommonClasses.cmd.ExecuteNonQuery()
																									ModCommonClasses.cmd.Parameters.Clear()
																								End If
																							End If
																							ModCommonClasses.con.Close()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text13 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur,Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
																							ModCommonClasses.cmd = New SqlCommand(text13)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.Prepare()
																							Dim flag47 As Boolean = Me.DataGridView1.Rows.Count > 0
																							If flag47 Then
																								Try
																									For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																										Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
																										Dim flag48 As Boolean = Not dataGridViewRow4.IsNewRow
																										If flag48 Then
																											Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow4.Cells(9).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(9).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(2).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(3).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtMinStock.Text))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(1).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(4).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(5).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(6).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(7).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(8).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(10).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(11).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(15).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(16).Value))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(13).Value)))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(13).Value)))
																											Dim memoryStream2 As MemoryStream = New MemoryStream()
																											Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																											bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																											Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																											Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																											sqlParameter2.Value = buffer2
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0.0)
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID.Text))
																											ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
																											ModCommonClasses.cmd.ExecuteNonQuery()
																											ModCommonClasses.cmd.Parameters.Clear()
																										End If
																									Next
																								Finally
																									Dim enumerator4 As IEnumerator
																									If TypeOf enumerator4 Is IDisposable Then
																										TryCast(enumerator4, IDisposable).Dispose()
																									End If
																								End Try
																							Else
																								Dim flag49 As Boolean = Me.DataGridView1.Rows.Count <= 0
																								If flag49 Then
																									Me.Generate_GiftQR(Me.txtBarcode.Text)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtOpeningStock.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtRSPrice.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtWSPrice.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtMinStock.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtDefMRP.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(Me.txtCostPrice.Text))
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(Me.txtCostPrice.Text))
																									Dim memoryStream3 As MemoryStream = New MemoryStream()
																									Dim bitmap3 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																									bitmap3.Save(memoryStream3, ImageFormat.Jpeg)
																									Dim buffer3 As Byte() = memoryStream3.GetBuffer()
																									Dim sqlParameter3 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																									sqlParameter3.Value = buffer3
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0.0)
																									ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID.Text))
																									ModCommonClasses.cmd.Parameters.Add(sqlParameter3)
																									ModCommonClasses.cmd.ExecuteNonQuery()
																									ModCommonClasses.cmd.Parameters.Clear()
																								End If
																							End If
																							ModCommonClasses.con.Close()
																							Dim flag50 As Boolean = Me.DataGridView1.Rows.Count > 0
																							If flag50 Then
																								Try
																									For Each obj5 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																										Dim dataGridViewRow5 As DataGridViewRow = CType(obj5, DataGridViewRow)
																										Dim flag51 As Boolean = Not dataGridViewRow5.IsNewRow
																										If flag51 Then
																											Dim flag52 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(0).Value)) > 0.0
																											If flag52 Then
																												ModCommonClasses.con = New SqlConnection(ModCS.cs)
																												ModCommonClasses.con.Open()
																												Dim text14 As String = "Select ProductID from StockMovement where ProductID=@d1"
																												ModCommonClasses.cmd = New SqlCommand(text14)
																												ModCommonClasses.cmd.Connection = ModCommonClasses.con
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																												Dim flag53 As Boolean = Not ModCommonClasses.rdr.Read()
																												If flag53 Then
																													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(0).Value))), 0D, DateAndTime.Today, Me.txtProductCode.Text)
																												Else
																													ModCommonClasses.con = New SqlConnection(ModCS.cs)
																													ModCommonClasses.con.Open()
																													Dim text15 As String = "Select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 And Date < @d3"
																													ModCommonClasses.cmd = New SqlCommand(text15)
																													ModCommonClasses.cmd.Connection = ModCommonClasses.con
																													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																													Dim flag54 As Boolean = ModCommonClasses.rdr.Read()
																													Dim num3 As Double
																													If flag54 Then
																														num3 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																													Else
																														num3 = 0.0
																													End If
																													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), New Decimal(num3), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(0).Value))), 0D, DateAndTime.Today, Me.txtProductCode.Text)
																												End If
																												ModCommonClasses.con.Close()
																											End If
																										End If
																									Next
																								Finally
																									Dim enumerator5 As IEnumerator
																									If TypeOf enumerator5 Is IDisposable Then
																										TryCast(enumerator5, IDisposable).Dispose()
																									End If
																								End Try
																							Else
																								Dim flag55 As Boolean = Me.DataGridView1.Rows.Count <= 0
																								If flag55 Then
																									Dim flag56 As Boolean = Conversion.Val(Me.txtOpeningStock.Text) > 0.0
																									If flag56 Then
																										ModCommonClasses.con = New SqlConnection(ModCS.cs)
																										ModCommonClasses.con.Open()
																										Dim text16 As String = "Select ProductID from StockMovement where ProductID=@d1"
																										ModCommonClasses.cmd = New SqlCommand(text16)
																										ModCommonClasses.cmd.Connection = ModCommonClasses.con
																										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																										Dim flag57 As Boolean = Not ModCommonClasses.rdr.Read()
																										If flag57 Then
																											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), 0D, New Decimal(Conversion.Val(Me.txtOpeningStock.Text)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
																										Else
																											ModCommonClasses.con = New SqlConnection(ModCS.cs)
																											ModCommonClasses.con.Open()
																											Dim text17 As String = "Select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 And Date < @d3"
																											ModCommonClasses.cmd = New SqlCommand(text17)
																											ModCommonClasses.cmd.Connection = ModCommonClasses.con
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																											Dim flag58 As Boolean = ModCommonClasses.rdr.Read()
																											Dim num4 As Double
																											If flag58 Then
																												num4 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																											Else
																												num4 = 0.0
																											End If
																											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), New Decimal(num4), New Decimal(Conversion.Val(Me.txtOpeningStock.Text)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
																										End If
																										ModCommonClasses.con.Close()
																									End If
																								End If
																							End If
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text18 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																							ModCommonClasses.cmd = New SqlCommand(text18)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSalesUnit.Text)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.ExecuteReader()
																							ModCommonClasses.con.Close()
																							ModCommonClasses.con = New SqlConnection(ModCS.cs)
																							ModCommonClasses.con.Open()
																							Dim text19 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																							ModCommonClasses.cmd = New SqlCommand(text19)
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbAltunit.Text)
																							ModCommonClasses.cmd.Connection = ModCommonClasses.con
																							ModCommonClasses.cmd.ExecuteReader()
																							ModCommonClasses.con.Close()
																							ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new Product '", Me.cmbProductName.Text, "' having Product code '", Me.txtProductCode.Text, "'" }))
																							ModFunc.RefreshRecords()
																							MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																							Me.fillProductID()
																							ModCommonClasses.con.Close()
																							Me.auto()
																							Me.GenerateBarcode()
																							Me.CheckBox3.Checked = False
																							Dim checked2 As Boolean = Me.CheckBox3.Checked
																							If checked2 Then
																								Me.fillProductName()
																							Else
																								Dim flag59 As Boolean = Not Me.CheckBox3.Checked
																								If flag59 Then
																									Me.NofillProductName()
																								End If
																							End If
																							Me.txtPName.Text = ""
																							Me.txtPNo.Text = ""
																						Catch ex As Exception
																							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						End Try
																						Me.DataforNP()
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06007C1B RID: 31771 RVA: 0x005C9070 File Offset: 0x005C7270
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06007C1C RID: 31772 RVA: 0x005C90F4 File Offset: 0x005C72F4
		Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs)
			Me.DataGridView1.ClearSelection()
			Dim num As Integer = Me.DataGridView1.RowCount - 1
			For i As Integer = 0 To num
				Dim num2 As Integer = Me.DataGridView1.RowCount - 1
				For j As Integer = 0 To num2
					Dim flag As Boolean = i <> j
					If flag Then
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.DataGridView1.Rows(i).Cells(9).Value, Me.DataGridView1.Rows(j).Cells(9).Value, False)
						If flag2 Then
							Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
						End If
					End If
				Next
			Next
			Dim num3 As Integer = Me.DataGridView1.Rows.Count - 1
			For k As Integer = 0 To num3
				Dim num4 As Integer = k + 1
				Dim num5 As Integer = Me.DataGridView1.Rows.Count - 1
				For l As Integer = num4 To num5
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(Me.DataGridView1.Rows(k).Cells(9).Value, Me.DataGridView1.Rows(l).Cells(9).Value, False)
					If flag3 Then
						MessageBox.Show("Unable to Update !" & vbCrLf & "Multiple Barcode Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
				Next
			Next
			Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtProductCode.Text)) = 0
			If flag4 Then
				MessageBox.Show("Please enter product code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtProductCode.Focus()
				Return
			End If
			Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbProductName.Text)) = 0
			If flag5 Then
				MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbProductName.Focus()
				Return
			End If
			Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
			If flag6 Then
				MessageBox.Show("Please Select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
				Return
			End If
			Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
			If flag7 Then
				MessageBox.Show("Please Select Sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSubCategory.Focus()
				Return
			End If
			Dim flag8 As Boolean = Me.cmbSTax.SelectedIndex = -1
			If flag8 Then
				MessageBox.Show("Please Select sale tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSTax.Focus()
				Return
			End If
			Dim flag9 As Boolean = Me.cmbPTax.SelectedIndex = -1
			If flag9 Then
				MessageBox.Show("Please Select purchase tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbPTax.Focus()
				Return
			End If
			Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtCostPrice.Text)) = 0
			If flag10 Then
				MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCostPrice.Focus()
				Return
			End If
			Dim flag11 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscount.Text)) = 0
			If flag11 Then
				MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDiscount.Focus()
				Return
			End If
			Dim flag12 As Boolean = Me.cmbGST.SelectedIndex = -1
			If flag12 Then
				MessageBox.Show("Please enter your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbGST.Focus()
				Return
			End If
			Dim flag13 As Boolean = Operators.CompareString(Me.txtMinStock.Text, "", False) = 0
			If flag13 Then
				MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtMinStock.Focus()
				Return
			End If
			Dim flag14 As Boolean = Strings.Len(Strings.Trim(Me.cmbPurchaseUnit.Text)) = 0
			If flag14 Then
				MessageBox.Show("Please Select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbPurchaseUnit.Focus()
				Return
			End If
			Dim flag15 As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesUnit.Text)) = 0
			If flag15 Then
				MessageBox.Show("Please Select sales unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSalesUnit.Focus()
				Return
			End If
			Dim flag16 As Boolean = Strings.Len(Strings.Trim(Me.cmbAltunit.Text)) = 0
			If flag16 Then
				MessageBox.Show("Please Select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbAltunit.Focus()
				Return
			End If
			Dim flag17 As Boolean = Strings.Len(Strings.Trim(Me.TextBox1.Text)) = 0
			If flag17 Then
				MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.TextBox1.Focus()
				Return
			End If
			Dim flag18 As Boolean = Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0
			If flag18 Then
				MessageBox.Show("Please enter Default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSaleQty.Focus()
				Return
			End If
			Dim flag19 As Boolean = Strings.Len(Strings.Trim(Me.txtDefMRP.Text)) = 0
			If flag19 Then
				MessageBox.Show("Please enter defalut MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtDefMRP.Focus()
				Return
			End If
			Dim flag20 As Boolean = Strings.Len(Strings.Trim(Me.txtRSPrice.Text)) = 0
			If flag20 Then
				MessageBox.Show("Please enter Default Retail Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtRSPrice.Focus()
				Return
			End If
			Dim flag21 As Boolean = Strings.Len(Strings.Trim(Me.txtWSPrice.Text)) = 0
			If flag21 Then
				MessageBox.Show("Please enter Default Wholesale Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtWSPrice.Focus()
				Return
			End If
			Dim checked As Boolean = Me.CheckBox4.Checked
			If checked Then
				Me.sts = "Yes"
			Else
				Me.sts = "No"
			End If
			Dim flag22 As Boolean = Me.dgw.Rows.Count = 0
			If flag22 Then
				Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
			End If
			Try
				Dim flag23 As Boolean = (Operators.CompareString(Me.txtPName.Text, Me.cmbProductName.Text, False) = 0) And (Operators.CompareString(Me.txtPNo.Text, Me.txtPartNo.Text, False) = 0)
				If Not flag23 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select Productname,PartNo from Product where ProductName=@d1 And PartNo=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPartNo.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag24 As Boolean = ModCommonClasses.rdr.Read()
					If flag24 Then
						Dim flag25 As Boolean = MessageBox.Show("Product Name And Part Or Group already exists, Do you really want To proceed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
						If Not flag25 Then
							Me.cmbProductName.Text = ""
							Me.cmbProductName.Focus()
							Dim flag26 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag26 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
					End If
				End If
				Me.Fill()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = If(("Update Product Set Productname=@d2, SubCategoryID=@d3, Description=@d4, CostPrice=@d5, Discount=@d7, CGST=@d8, Barcode=@d10, ProductCode=@d1, PurchaseUnit=@d12,SalesUnit=@d13,SGST=@d14,HSNCode=@d15,PartNo=@d16,Cess=@d17,SalesAltUnit=@d18,Conv=@d19,MinStock=@d20,Status=@d22,STax=@d23,PTax=@d24,GDown=@d25,Rack=@d26,MRP=@d27,SellingPrice=@d28,ReorderPoint=@d29,DefQty=@d30,Kitchen=@d31 where PID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbProductName.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtSubCategoryID.Text)
				Dim flag27 As Boolean = Operators.CompareString(Me.txtFeatures.Text, "", False) <> 0
				If flag27 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtFeatures.Text)
				Else
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbProductName.Text)
				End If
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCostPrice.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtDiscount.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtCGST.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "0")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbPurchaseUnit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.cmbSalesUnit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtSGST.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtHSNCode.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtPartNo.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(Me.txtCESS.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.cmbAltunit.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.TextBox1.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.txtMinStock.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.sts)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.cmbSTax.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.cmbPTax.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.cmbGdown.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbRack.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(Me.txtDefMRP.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.txtRSPrice.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val(Me.txtWSPrice.Text))
				Dim flag28 As Boolean = (Operators.CompareString(Me.txtSaleQty.Text, "", False) = 0) Or (Operators.CompareString(Me.txtSaleQty.Text, "0", False) = 0)
				If flag28 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "1")
				Else
					ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.txtSaleQty.Text)
				End If
				ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.cmbKitchen.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text3 As String = "Update Temp_Stock Set SalePrice=@d2, WSalePrice=@d3, StLimit=@d4 where ProductID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text3)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox4.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtMinStock.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag29 As Boolean = Not dataGridViewRow.IsNewRow
						If flag29 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "Select ProductID from Temp_Stock where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag30 As Boolean = ModCommonClasses.rdr.Read()
							If flag30 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "Update Temp_Stock Set MRP=@d1, SPrice=@d2, WPrice=@d3, Batch=@d4, Mfgdate=@d5, Expdate=@d6, Size=@d7, Colour=@d8, Barcode=@d9, SalePrice=@d10, WSalePrice=@d11, IMEI1=@d12, IMEI2=@d13, PPrice=@d14,QrBarcode=@d15 where ProductID=@d16 And Barcode=@d17"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d15", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
						Dim flag31 As Boolean = Not dataGridViewRow2.IsNewRow
						If flag31 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text6 As String = "Select ProductID from Product_OpeningStock where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text6)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag32 As Boolean = ModCommonClasses.rdr.Read()
							If flag32 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text7 As String = "Update Product_OpeningStock Set MRP=@d1, SalePrice=@d2, WSalePrice=@d3, Batch=@d4, Mfgdate=@d5, Expdate=@d6, Size=@d7, Colour=@d8, Barcode=@d9, RCipher=@d10, WCipher=@d11, PPrice=@d14, OPSValue=@d15, IMEI1=@d16, IMEI2=@d17 where ProductID=@d12 And Barcode=@d13"
								ModCommonClasses.cmd = New SqlCommand(text7)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(1).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(2).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(7).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(8).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(10).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(13).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(14).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(15).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(16).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator2 As IEnumerator
					If TypeOf enumerator2 Is IDisposable Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
						Dim flag33 As Boolean = Not dataGridViewRow3.IsNewRow
						If flag33 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text8 As String = "Select ProductID from Invoice_Product where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text8)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag34 As Boolean = ModCommonClasses.rdr.Read()
							If flag34 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text9 As String = "Update Invoice_Product Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text9)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
						Dim flag35 As Boolean = Not dataGridViewRow4.IsNewRow
						If flag35 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text10 As String = "Select ProductID from Stock_Product where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text10)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag36 As Boolean = ModCommonClasses.rdr.Read()
							If flag36 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text11 As String = "Update Stock_Product Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text11)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator4 As IEnumerator
					If TypeOf enumerator4 Is IDisposable Then
						TryCast(enumerator4, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj5 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow5 As DataGridViewRow = CType(obj5, DataGridViewRow)
						Dim flag37 As Boolean = Not dataGridViewRow5.IsNewRow
						If flag37 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text12 As String = "Select ProductID from Quotation_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text12)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag38 As Boolean = ModCommonClasses.rdr.Read()
							If flag38 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text13 As String = "Update Quotation_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text13)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator5 As IEnumerator
					If TypeOf enumerator5 Is IDisposable Then
						TryCast(enumerator5, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj6 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow6 As DataGridViewRow = CType(obj6, DataGridViewRow)
						Dim flag39 As Boolean = Not dataGridViewRow6.IsNewRow
						If flag39 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text14 As String = "Select ProductID from Estimate_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text14)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag40 As Boolean = ModCommonClasses.rdr.Read()
							If flag40 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text15 As String = "Update Estimate_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text15)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow6.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator6 As IEnumerator
					If TypeOf enumerator6 Is IDisposable Then
						TryCast(enumerator6, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj7 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow7 As DataGridViewRow = CType(obj7, DataGridViewRow)
						Dim flag41 As Boolean = Not dataGridViewRow7.IsNewRow
						If flag41 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text16 As String = "Select ProductID from PurchaseOrder_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text16)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag42 As Boolean = ModCommonClasses.rdr.Read()
							If flag42 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text17 As String = "Update PurchaseOrder_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text17)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow7.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator7 As IEnumerator
					If TypeOf enumerator7 Is IDisposable Then
						TryCast(enumerator7, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj8 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow8 As DataGridViewRow = CType(obj8, DataGridViewRow)
						Dim flag43 As Boolean = Not dataGridViewRow8.IsNewRow
						If flag43 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text18 As String = "Select ProductID from SalesReturn_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text18)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag44 As Boolean = ModCommonClasses.rdr.Read()
							If flag44 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text19 As String = "Update SalesReturn_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text19)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow8.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator8 As IEnumerator
					If TypeOf enumerator8 Is IDisposable Then
						TryCast(enumerator8, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj9 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow9 As DataGridViewRow = CType(obj9, DataGridViewRow)
						Dim flag45 As Boolean = Not dataGridViewRow9.IsNewRow
						If flag45 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text20 As String = "Select ProductID from PurchaseReturn_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text20)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag46 As Boolean = ModCommonClasses.rdr.Read()
							If flag46 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text21 As String = "Update PurchaseReturn_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text21)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow9.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator9 As IEnumerator
					If TypeOf enumerator9 Is IDisposable Then
						TryCast(enumerator9, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj10 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow10 As DataGridViewRow = CType(obj10, DataGridViewRow)
						Dim flag47 As Boolean = Not dataGridViewRow10.IsNewRow
						If flag47 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text22 As String = "Select ProductID from Stock_Store_Join where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text22)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag48 As Boolean = ModCommonClasses.rdr.Read()
							If flag48 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text23 As String = "Update Stock_Store_Join Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text23)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow10.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator10 As IEnumerator
					If TypeOf enumerator10 Is IDisposable Then
						TryCast(enumerator10, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj11 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow11 As DataGridViewRow = CType(obj11, DataGridViewRow)
						Dim flag49 As Boolean = Not dataGridViewRow11.IsNewRow
						If flag49 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text24 As String = "Select ProductID from StockAdjustment_Store where ProductID=@d1 And Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text24)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(12).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag50 As Boolean = ModCommonClasses.rdr.Read()
							If flag50 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text25 As String = "Update StockAdjustment_Store Set Barcode=@d1 where ProductID=@d2 And Barcode=@d3"
								ModCommonClasses.cmd = New SqlCommand(text25)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(9).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow11.Cells(12).Value))
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator11 As IEnumerator
					If TypeOf enumerator11 Is IDisposable Then
						TryCast(enumerator11, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text26 As String = "delete from Product_Join where ProductID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text26)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text27 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Me.txtID.Text + ",@d2)"
				ModCommonClasses.cmd = New SqlCommand(text27)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				Try
					For Each obj12 As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow12 As DataGridViewRow = CType(obj12, DataGridViewRow)
						Dim flag51 As Boolean = Not dataGridViewRow12.IsNewRow
						If flag51 Then
							Dim memoryStream2 As MemoryStream = New MemoryStream()
							Dim image As Image = CType(dataGridViewRow12.Cells(0).Value, Image)
							Dim bitmap2 As Bitmap = New Bitmap(image)
							bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
							Dim buffer2 As Byte() = memoryStream2.GetBuffer()
							Dim sqlParameter2 As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
							sqlParameter2.Value = buffer2
							ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
						End If
					Next
				Finally
					Dim enumerator12 As IEnumerator
					If TypeOf enumerator12 Is IDisposable Then
						TryCast(enumerator12, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text28 As String = "delete from ExtDB1 where a1=@d1"
				ModCommonClasses.cmd = New SqlCommand(text28)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text29 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text29)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSalesUnit.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text30 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text30)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbAltunit.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the Product '", Me.cmbProductName.Text, "' having Product code '", Me.txtProductCode.Text, "'" }))
				ModFunc.RefreshRecords()
				MessageBox.Show("Successfully Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.btnUpdate.Enabled = False
				ModCommonClasses.con.Close()
				Me.txtPName.Text = ""
				Me.txtPNo.Text = ""
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007C1D RID: 31773 RVA: 0x005CBF04 File Offset: 0x005CA104
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
					ModFunc.RefreshRecords()
					Me.Reset()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007C1E RID: 31774 RVA: 0x005CBF78 File Offset: 0x005CA178
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim frmProductRecord As frmProductRecord = New frmProductRecord()
			frmProductRecord.lblSet.Text = "Product Entry"
			frmProductRecord.Reset()
			frmProductRecord.ShowDialog()
			frmProductRecord.Dispose()
		End Sub

		' Token: 0x06007C1F RID: 31775 RVA: 0x005CBFB4 File Offset: 0x005CA1B4
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.txtProductCode.Text.Length > 0) And (Me.cmbProductName.Text.Length > 0) And (Me.txtBarcode.Text.Length > 0)
			If flag Then
				MyProject.Forms.frmBarcodeLabelPrinting.txtPCode.Text = Me.txtProductCode.Text.ToString()
				MyProject.Forms.frmBarcodeLabelPrinting.SearchbyPCode()
				MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
			Else
				MessageBox.Show("You have not selected the Barcode !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06007C20 RID: 31776 RVA: 0x005BFEA0 File Offset: 0x005BE0A0
		Private Sub DataGridView1_RowPostPaint_1(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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

		' Token: 0x06007C21 RID: 31777 RVA: 0x005CC060 File Offset: 0x005CA260
		Private Sub DataGridView1_MouseClick_1(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Dim flag2 As Boolean = Me.btnSave.Enabled And Not Me.btnUpdate.Enabled
				If flag2 Then
					Me.btnRemoveFromGridOS.Enabled = True
				End If
			Else
				Dim flag3 As Boolean = Not Me.btnSave.Enabled And Me.btnUpdate.Enabled
				If flag3 Then
					Me.btnRemoveFromGridOS.Enabled = False
				End If
			End If
			Try
				Dim flag4 As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag4 Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtPurchase.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.txtMRP.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtSellingPrice.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtReorderPoint.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBatchNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtMfg.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtExp.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.cmbSize.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.cmbColour.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.TempBarcode.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtIMEI1.Text = dataGridViewRow.Cells(15).Value.ToString()
					Me.txtIMEI2.Text = dataGridViewRow.Cells(16).Value.ToString()
					Me.txtMRPMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtMRP.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
					Me.txtSaaleMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtSellingPrice.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
					Me.txtWMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtReorderPoint.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007C22 RID: 31778 RVA: 0x005CC414 File Offset: 0x005CA614
		Private Sub txtMRPMargin_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtDefMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtMRPMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C23 RID: 31779 RVA: 0x005CC490 File Offset: 0x005CA690
		Private Sub txtMRPMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtMRPMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C24 RID: 31780 RVA: 0x005CC50C File Offset: 0x005CA70C
		Private Sub txtWMargin_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtWSPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtWMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C25 RID: 31781 RVA: 0x005CC588 File Offset: 0x005CA788
		Private Sub txtSaaleMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtSellingPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtSaaleMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C26 RID: 31782 RVA: 0x005CC604 File Offset: 0x005CA804
		Private Sub txtWMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtReorderPoint.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtWMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C27 RID: 31783 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtMRP_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C28 RID: 31784 RVA: 0x005CC680 File Offset: 0x005CA880
		Private Sub updateMargin()
			Me.txtDefMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtMRPMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
			Me.txtRSPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtSalePMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
			Me.txtWSPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtWMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
		End Sub

		' Token: 0x06007C29 RID: 31785 RVA: 0x005CC7A8 File Offset: 0x005CA9A8
		Private Sub updateMarginnew()
			Me.txtMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtMRPMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			Me.txtSellingPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtSaaleMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			Me.txtReorderPoint.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPurchase.Text) * Conversion.Val(Me.txtWMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPurchase.Text), 2), "")
			Me.txtMRPMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtMRP.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
			Me.txtSaaleMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtSellingPrice.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
			Me.txtWMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtReorderPoint.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0, 2), "")
		End Sub

		' Token: 0x06007C2A RID: 31786 RVA: 0x005CC9D0 File Offset: 0x005CABD0
		Private Sub txtPurchase_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.updateMarginnew()
			End If
		End Sub

		' Token: 0x06007C2B RID: 31787 RVA: 0x005CC9F8 File Offset: 0x005CABF8
		Private Sub txtDefMRP_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtMRPMargin.Text = Conversions.ToString(Conversion.Val(Me.txtDefMRP.Text) * 100.0 / Conversion.Val(Me.txtCostPrice.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C2C RID: 31788 RVA: 0x005CCA60 File Offset: 0x005CAC60
		Private Sub txtRSPrice_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtSalePMargin.Text = Conversions.ToString(Conversion.Val(Me.txtRSPrice.Text) * 100.0 / Conversion.Val(Me.txtCostPrice.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C2D RID: 31789 RVA: 0x005CCAC8 File Offset: 0x005CACC8
		Private Sub txtWSPrice_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtWMargin.Text = Conversions.ToString(Conversion.Val(Me.txtWSPrice.Text) * 100.0 / Conversion.Val(Me.txtCostPrice.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C2E RID: 31790 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtMRPMargin_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C2F RID: 31791 RVA: 0x005CCB30 File Offset: 0x005CAD30
		Private Sub txtMRP_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtMRPMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtMRP.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C30 RID: 31792 RVA: 0x005CCB98 File Offset: 0x005CAD98
		Private Sub txtSellingPrice_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtSaaleMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtSellingPrice.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C31 RID: 31793 RVA: 0x005CCC00 File Offset: 0x005CAE00
		Private Sub txtReorderPoint_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtWMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtReorderPoint.Text) * 100.0 / Conversion.Val(Me.txtPurchase.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06007C32 RID: 31794 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtMRPMarginNew_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C33 RID: 31795 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtSaaleMarginNew_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C34 RID: 31796 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtWMarginNew_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007C35 RID: 31797 RVA: 0x005CCC68 File Offset: 0x005CAE68
		Private Sub txtCostPrice_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.updateMargin()
			End If
		End Sub

		' Token: 0x06007C36 RID: 31798 RVA: 0x005CCC90 File Offset: 0x005CAE90
		Private Sub txtSalePMargin_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtRSPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtCostPrice.Text) * Conversion.Val(Me.txtSalePMargin.Text) / 100.0 + Conversion.Val(Me.txtCostPrice.Text), 2), "")
			End If
		End Sub

		' Token: 0x06007C37 RID: 31799 RVA: 0x0003D2DA File Offset: 0x0003B4DA
		Private Sub chkMarginOnOff_CheckedChanged(sender As Object, e As EventArgs)
			Me.CheckUncheckMargin()
		End Sub

		' Token: 0x040036D9 RID: 14041
		Private sts As String

		' Token: 0x040036DA RID: 14042
		Private keyPath As String

		' Token: 0x040036DB RID: 14043
		Private valueName As String

		' Token: 0x040036DC RID: 14044
		Private transliterator As Transliterator

		' Token: 0x040036DD RID: 14045
		Private Dad As SqlDataAdapter

		' Token: 0x040036DE RID: 14046
		Private Dst As DataSet

		' Token: 0x040036DF RID: 14047
		Private CurrentRow As Object

		' Token: 0x040036E0 RID: 14048
		Private b0 As String

		' Token: 0x040036E1 RID: 14049
		Private b1 As String

		' Token: 0x040036E2 RID: 14050
		Private b2 As String

		' Token: 0x040036E3 RID: 14051
		Private b3 As String

		' Token: 0x040036E4 RID: 14052
		Private b4 As String

		' Token: 0x040036E5 RID: 14053
		Private b5 As String

		' Token: 0x040036E6 RID: 14054
		Private b6 As String

		' Token: 0x040036E7 RID: 14055
		Private b7 As String

		' Token: 0x040036E8 RID: 14056
		Private b8 As String

		' Token: 0x040036E9 RID: 14057
		Private b9 As String

		' Token: 0x040036EA RID: 14058
		Private b12 As String

		' Token: 0x040036EB RID: 14059
		Private b13 As String

		' Token: 0x040036EC RID: 14060
		Private b14 As String

		' Token: 0x040036ED RID: 14061
		Private isd As String
	End Class
End Namespace
