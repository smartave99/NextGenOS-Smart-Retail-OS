Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports Lyquidity.UtilityLibrary.Controls
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000017 RID: 23
	<DesignerGenerated()>
	Public Partial Class frmBarcodeMain
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060005A2 RID: 1442 RVA: 0x0008F418 File Offset: 0x0008D618
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBarcodeMain_Load
			AddHandler MyBase.KeyPress, AddressOf Me.frmBarcodeMain_KeyPress
			Me.inHardMarginY = 0
			Me.strImgPath = "No Image"
			Me.strFinalPath = String.Empty
			Me.dl = New DragLabel()
			Me.infoDimension = New DimensionInfo()
			Me.dtb = New DataTable()
			Me.MyDS = New DataSet()
			Me.ds_labels = New DataSet()
			Me.number = 1
			Me.mPageNumber = 1
			Me.counter = 0
			Me.counter_qrcode = 0
			Me.dt1 = New DataTable()
			Me.clickLocation = Nothing
			Me.numberPb = 1
			Me.originalSizes = New Dictionary(Of Control, Size)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000322 RID: 802
		' (get) Token: 0x060005A5 RID: 1445 RVA: 0x000098D4 File Offset: 0x00007AD4
		' (set) Token: 0x060005A6 RID: 1446 RVA: 0x00093D08 File Offset: 0x00091F08
		Private _ToolStripCmbFonts As ToolStripComboBox
		Friend Overridable Property ToolStripCmbFonts As ToolStripComboBox
			<CompilerGenerated()>
			Get
				Return Me._ToolStripCmbFonts
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripCmbFonts_SelectedIndexChanged
				Dim toolStripComboBox As ToolStripComboBox = Me._ToolStripCmbFonts
				If toolStripComboBox IsNot Nothing Then
					RemoveHandler toolStripComboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ToolStripCmbFonts = value
				toolStripComboBox = Me._ToolStripCmbFonts
				If toolStripComboBox IsNot Nothing Then
					AddHandler toolStripComboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000323 RID: 803
		' (get) Token: 0x060005A7 RID: 1447 RVA: 0x000098DE File Offset: 0x00007ADE
		' (set) Token: 0x060005A8 RID: 1448 RVA: 0x00093D4C File Offset: 0x00091F4C
		Private _ContextMenuStrip1 As ContextMenuStrip
		Friend Overridable Property ContextMenuStrip1 As ContextMenuStrip
			<CompilerGenerated()>
			Get
				Return Me._ContextMenuStrip1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ContextMenuStrip)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.ContextMenuStrip1_Opening
				Dim contextMenuStrip As ContextMenuStrip = Me._ContextMenuStrip1
				If contextMenuStrip IsNot Nothing Then
					RemoveHandler contextMenuStrip.Opening, cancelEventHandler
				End If
				Me._ContextMenuStrip1 = value
				contextMenuStrip = Me._ContextMenuStrip1
				If contextMenuStrip IsNot Nothing Then
					AddHandler contextMenuStrip.Opening, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000324 RID: 804
		' (get) Token: 0x060005A9 RID: 1449 RVA: 0x000098E8 File Offset: 0x00007AE8
		' (set) Token: 0x060005AA RID: 1450 RVA: 0x000098F2 File Offset: 0x00007AF2
		Friend Overridable Property FontFamilyToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000325 RID: 805
		' (get) Token: 0x060005AB RID: 1451 RVA: 0x000098FB File Offset: 0x00007AFB
		' (set) Token: 0x060005AC RID: 1452 RVA: 0x00009905 File Offset: 0x00007B05
		Friend Overridable Property TextSizeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000326 RID: 806
		' (get) Token: 0x060005AD RID: 1453 RVA: 0x0000990E File Offset: 0x00007B0E
		' (set) Token: 0x060005AE RID: 1454 RVA: 0x00093D90 File Offset: 0x00091F90
		Private _BoldToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BoldToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BoldToolStripMenuItem = value
				toolStripMenuItem = Me._BoldToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000327 RID: 807
		' (get) Token: 0x060005AF RID: 1455 RVA: 0x00009918 File Offset: 0x00007B18
		' (set) Token: 0x060005B0 RID: 1456 RVA: 0x00093DD4 File Offset: 0x00091FD4
		Private _ItalicToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ItalicToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ItalicToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ItalicToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ItalicToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ItalicToolStripMenuItem = value
				toolStripMenuItem = Me._ItalicToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000328 RID: 808
		' (get) Token: 0x060005B1 RID: 1457 RVA: 0x00009922 File Offset: 0x00007B22
		' (set) Token: 0x060005B2 RID: 1458 RVA: 0x00093E18 File Offset: 0x00092018
		Private _BoldItalicToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldItalicToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldItalicToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldItalicToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BoldItalicToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BoldItalicToolStripMenuItem = value
				toolStripMenuItem = Me._BoldItalicToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000329 RID: 809
		' (get) Token: 0x060005B3 RID: 1459 RVA: 0x0000992C File Offset: 0x00007B2C
		' (set) Token: 0x060005B4 RID: 1460 RVA: 0x00093E5C File Offset: 0x0009205C
		Private _RegularToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RegularToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RegularToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RegularToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._RegularToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._RegularToolStripMenuItem = value
				toolStripMenuItem = Me._RegularToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700032A RID: 810
		' (get) Token: 0x060005B5 RID: 1461 RVA: 0x00009936 File Offset: 0x00007B36
		' (set) Token: 0x060005B6 RID: 1462 RVA: 0x00093EA0 File Offset: 0x000920A0
		Private _UnderlineToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property UnderlineToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UnderlineToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UnderlineToolStripMenuItem1_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UnderlineToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UnderlineToolStripMenuItem1 = value
				toolStripMenuItem = Me._UnderlineToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700032B RID: 811
		' (get) Token: 0x060005B7 RID: 1463 RVA: 0x00009940 File Offset: 0x00007B40
		' (set) Token: 0x060005B8 RID: 1464 RVA: 0x00093EE4 File Offset: 0x000920E4
		Private _BoldUnderlineToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldUnderlineToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldUnderlineToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldUnderlineToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BoldUnderlineToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BoldUnderlineToolStripMenuItem = value
				toolStripMenuItem = Me._BoldUnderlineToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700032C RID: 812
		' (get) Token: 0x060005B9 RID: 1465 RVA: 0x0000994A File Offset: 0x00007B4A
		' (set) Token: 0x060005BA RID: 1466 RVA: 0x00009954 File Offset: 0x00007B54
		Friend Overridable Property FontSizeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x1700032D RID: 813
		' (get) Token: 0x060005BB RID: 1467 RVA: 0x0000995D File Offset: 0x00007B5D
		' (set) Token: 0x060005BC RID: 1468 RVA: 0x00093F28 File Offset: 0x00092128
		Private _ToolStripTextBox1 As ToolStripTextBox
		Friend Overridable Property ToolStripTextBox1 As ToolStripTextBox
			<CompilerGenerated()>
			Get
				Return Me._ToolStripTextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ToolStripTextBox1_KeyDown
				Dim toolStripTextBox As ToolStripTextBox = Me._ToolStripTextBox1
				If toolStripTextBox IsNot Nothing Then
					RemoveHandler toolStripTextBox.KeyDown, keyEventHandler
				End If
				Me._ToolStripTextBox1 = value
				toolStripTextBox = Me._ToolStripTextBox1
				If toolStripTextBox IsNot Nothing Then
					AddHandler toolStripTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700032E RID: 814
		' (get) Token: 0x060005BD RID: 1469 RVA: 0x00009967 File Offset: 0x00007B67
		' (set) Token: 0x060005BE RID: 1470 RVA: 0x00093F6C File Offset: 0x0009216C
		Private _TextColorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TextColorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TextColorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TextColorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TextColorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TextColorToolStripMenuItem = value
				toolStripMenuItem = Me._TextColorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700032F RID: 815
		' (get) Token: 0x060005BF RID: 1471 RVA: 0x00009971 File Offset: 0x00007B71
		' (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000997B File Offset: 0x00007B7B
		Friend Overridable Property AlignmentToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000330 RID: 816
		' (get) Token: 0x060005C1 RID: 1473 RVA: 0x00009984 File Offset: 0x00007B84
		' (set) Token: 0x060005C2 RID: 1474 RVA: 0x00093FB0 File Offset: 0x000921B0
		Private _LeftToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LeftToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LeftToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LeftToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LeftToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LeftToolStripMenuItem = value
				toolStripMenuItem = Me._LeftToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000331 RID: 817
		' (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000998E File Offset: 0x00007B8E
		' (set) Token: 0x060005C4 RID: 1476 RVA: 0x00093FF4 File Offset: 0x000921F4
		Private _CenterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CenterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CenterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CenterToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CenterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CenterToolStripMenuItem = value
				toolStripMenuItem = Me._CenterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000332 RID: 818
		' (get) Token: 0x060005C5 RID: 1477 RVA: 0x00009998 File Offset: 0x00007B98
		' (set) Token: 0x060005C6 RID: 1478 RVA: 0x00094038 File Offset: 0x00092238
		Private _RightToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RightToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RightToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RightToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._RightToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._RightToolStripMenuItem = value
				toolStripMenuItem = Me._RightToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000333 RID: 819
		' (get) Token: 0x060005C7 RID: 1479 RVA: 0x000099A2 File Offset: 0x00007BA2
		' (set) Token: 0x060005C8 RID: 1480 RVA: 0x0009407C File Offset: 0x0009227C
		Private _JustifyToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property JustifyToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._JustifyToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.JustifyToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._JustifyToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._JustifyToolStripMenuItem1 = value
				toolStripMenuItem = Me._JustifyToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000334 RID: 820
		' (get) Token: 0x060005C9 RID: 1481 RVA: 0x000099AC File Offset: 0x00007BAC
		' (set) Token: 0x060005CA RID: 1482 RVA: 0x000099B6 File Offset: 0x00007BB6
		Friend Overridable Property EditTextToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000335 RID: 821
		' (get) Token: 0x060005CB RID: 1483 RVA: 0x000099BF File Offset: 0x00007BBF
		' (set) Token: 0x060005CC RID: 1484 RVA: 0x000940C0 File Offset: 0x000922C0
		Private _ToolStripTextBox2 As ToolStripTextBox
		Friend Overridable Property ToolStripTextBox2 As ToolStripTextBox
			<CompilerGenerated()>
			Get
				Return Me._ToolStripTextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ToolStripTextBox2_KeyDown
				Dim toolStripTextBox As ToolStripTextBox = Me._ToolStripTextBox2
				If toolStripTextBox IsNot Nothing Then
					RemoveHandler toolStripTextBox.KeyDown, keyEventHandler
				End If
				Me._ToolStripTextBox2 = value
				toolStripTextBox = Me._ToolStripTextBox2
				If toolStripTextBox IsNot Nothing Then
					AddHandler toolStripTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000336 RID: 822
		' (get) Token: 0x060005CD RID: 1485 RVA: 0x000099C9 File Offset: 0x00007BC9
		' (set) Token: 0x060005CE RID: 1486 RVA: 0x00094104 File Offset: 0x00092304
		Private _DeleteToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DeleteToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DeleteToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DeleteToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DeleteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DeleteToolStripMenuItem = value
				toolStripMenuItem = Me._DeleteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000337 RID: 823
		' (get) Token: 0x060005CF RID: 1487 RVA: 0x000099D3 File Offset: 0x00007BD3
		' (set) Token: 0x060005D0 RID: 1488 RVA: 0x000099DD File Offset: 0x00007BDD
		Friend Overridable Property AllignmentToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000338 RID: 824
		' (get) Token: 0x060005D1 RID: 1489 RVA: 0x000099E6 File Offset: 0x00007BE6
		' (set) Token: 0x060005D2 RID: 1490 RVA: 0x000099F0 File Offset: 0x00007BF0
		Friend Overridable Property LeftToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17000339 RID: 825
		' (get) Token: 0x060005D3 RID: 1491 RVA: 0x000099F9 File Offset: 0x00007BF9
		' (set) Token: 0x060005D4 RID: 1492 RVA: 0x00009A03 File Offset: 0x00007C03
		Friend Overridable Property RightToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x1700033A RID: 826
		' (get) Token: 0x060005D5 RID: 1493 RVA: 0x00009A0C File Offset: 0x00007C0C
		' (set) Token: 0x060005D6 RID: 1494 RVA: 0x00009A16 File Offset: 0x00007C16
		Friend Overridable Property CenterToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x1700033B RID: 827
		' (get) Token: 0x060005D7 RID: 1495 RVA: 0x00009A1F File Offset: 0x00007C1F
		' (set) Token: 0x060005D8 RID: 1496 RVA: 0x00009A29 File Offset: 0x00007C29
		Friend Overridable Property JustifyToolStripMenuItem As ToolStripMenuItem

		' Token: 0x1700033C RID: 828
		' (get) Token: 0x060005D9 RID: 1497 RVA: 0x00009A32 File Offset: 0x00007C32
		' (set) Token: 0x060005DA RID: 1498 RVA: 0x00094148 File Offset: 0x00092348
		Private _cbxPurInv As CheckBox
		Friend Overridable Property cbxPurInv As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxPurInv
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxPurInv_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxPurInv
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxPurInv = value
				checkBox = Me._cbxPurInv
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700033D RID: 829
		' (get) Token: 0x060005DB RID: 1499 RVA: 0x00009A3C File Offset: 0x00007C3C
		' (set) Token: 0x060005DC RID: 1500 RVA: 0x0009418C File Offset: 0x0009238C
		Private _cbxQrBarcode As CheckBox
		Friend Overridable Property cbxQrBarcode As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxQrBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = Sub(a0 As Object, a1 As EventArgs)
					Me.cbxQrBarcode_CheckedChanged(RuntimeHelpers.GetObjectValue(a0), a1)
				End Sub
				Dim checkBox As CheckBox = Me._cbxQrBarcode
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxQrBarcode = value
				checkBox = Me._cbxQrBarcode
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700033E RID: 830
		' (get) Token: 0x060005DD RID: 1501 RVA: 0x00009A46 File Offset: 0x00007C46
		' (set) Token: 0x060005DE RID: 1502 RVA: 0x000941D0 File Offset: 0x000923D0
		Private _cbxColour As CheckBox
		Friend Overridable Property cbxColour As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxColour
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxColour_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxColour
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxColour = value
				checkBox = Me._cbxColour
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700033F RID: 831
		' (get) Token: 0x060005DF RID: 1503 RVA: 0x00009A50 File Offset: 0x00007C50
		' (set) Token: 0x060005E0 RID: 1504 RVA: 0x00094214 File Offset: 0x00092414
		Private _cbxGST As CheckBox
		Friend Overridable Property cbxGST As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxGST_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxGST
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxGST = value
				checkBox = Me._cbxGST
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000340 RID: 832
		' (get) Token: 0x060005E1 RID: 1505 RVA: 0x00009A5A File Offset: 0x00007C5A
		' (set) Token: 0x060005E2 RID: 1506 RVA: 0x00094258 File Offset: 0x00092458
		Private _cbxExp As CheckBox
		Friend Overridable Property cbxExp As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxExp
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxExp_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxExp
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxExp = value
				checkBox = Me._cbxExp
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000341 RID: 833
		' (get) Token: 0x060005E3 RID: 1507 RVA: 0x00009A64 File Offset: 0x00007C64
		' (set) Token: 0x060005E4 RID: 1508 RVA: 0x0009429C File Offset: 0x0009249C
		Private _cbxSize As CheckBox
		Friend Overridable Property cbxSize As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxSize
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxSize_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxSize
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxSize = value
				checkBox = Me._cbxSize
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000342 RID: 834
		' (get) Token: 0x060005E5 RID: 1509 RVA: 0x00009A6E File Offset: 0x00007C6E
		' (set) Token: 0x060005E6 RID: 1510 RVA: 0x000942E0 File Offset: 0x000924E0
		Private _cbxMfg As CheckBox
		Friend Overridable Property cbxMfg As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxMfg
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxMfg_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxMfg
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxMfg = value
				checkBox = Me._cbxMfg
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000343 RID: 835
		' (get) Token: 0x060005E7 RID: 1511 RVA: 0x00009A78 File Offset: 0x00007C78
		' (set) Token: 0x060005E8 RID: 1512 RVA: 0x00094324 File Offset: 0x00092524
		Private _cbxWholesalePrice As CheckBox
		Friend Overridable Property cbxWholesalePrice As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxWholesalePrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxWholesalePrice_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxWholesalePrice
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxWholesalePrice = value
				checkBox = Me._cbxWholesalePrice
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000344 RID: 836
		' (get) Token: 0x060005E9 RID: 1513 RVA: 0x00009A82 File Offset: 0x00007C82
		' (set) Token: 0x060005EA RID: 1514 RVA: 0x00094368 File Offset: 0x00092568
		Private _cbxBatch As CheckBox
		Friend Overridable Property cbxBatch As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxBatch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxBatch_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxBatch
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxBatch = value
				checkBox = Me._cbxBatch
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000345 RID: 837
		' (get) Token: 0x060005EB RID: 1515 RVA: 0x00009A8C File Offset: 0x00007C8C
		' (set) Token: 0x060005EC RID: 1516 RVA: 0x000943AC File Offset: 0x000925AC
		Private _cbxMRP As CheckBox
		Friend Overridable Property cbxMRP As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxMRP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxMRP_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxMRP
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxMRP = value
				checkBox = Me._cbxMRP
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000346 RID: 838
		' (get) Token: 0x060005ED RID: 1517 RVA: 0x00009A96 File Offset: 0x00007C96
		' (set) Token: 0x060005EE RID: 1518 RVA: 0x00009AA0 File Offset: 0x00007CA0
		Friend Overridable Property panel1 As Panel

		' Token: 0x17000347 RID: 839
		' (get) Token: 0x060005EF RID: 1519 RVA: 0x00009AA9 File Offset: 0x00007CA9
		' (set) Token: 0x060005F0 RID: 1520 RVA: 0x000943F0 File Offset: 0x000925F0
		Private _btnTestPrint As Button
		Friend Overridable Property btnTestPrint As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTestPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTestPrint_Click
				Dim button As Button = Me._btnTestPrint
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTestPrint = value
				button = Me._btnTestPrint
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000348 RID: 840
		' (get) Token: 0x060005F1 RID: 1521 RVA: 0x00009AB3 File Offset: 0x00007CB3
		' (set) Token: 0x060005F2 RID: 1522 RVA: 0x00009ABD File Offset: 0x00007CBD
		Friend Overridable Property btnClose As Button

		' Token: 0x17000349 RID: 841
		' (get) Token: 0x060005F3 RID: 1523 RVA: 0x00009AC6 File Offset: 0x00007CC6
		' (set) Token: 0x060005F4 RID: 1524 RVA: 0x00094434 File Offset: 0x00092634
		Private _btnClear As Button
		Friend Overridable Property btnClear As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim button As Button = Me._btnClear
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClear = value
				button = Me._btnClear
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700034A RID: 842
		' (get) Token: 0x060005F5 RID: 1525 RVA: 0x00009AD0 File Offset: 0x00007CD0
		' (set) Token: 0x060005F6 RID: 1526 RVA: 0x00094478 File Offset: 0x00092678
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

		' Token: 0x1700034B RID: 843
		' (get) Token: 0x060005F7 RID: 1527 RVA: 0x00009ADA File Offset: 0x00007CDA
		' (set) Token: 0x060005F8 RID: 1528 RVA: 0x00009AE4 File Offset: 0x00007CE4
		Friend Overridable Property gbxPosition As GroupBox

		' Token: 0x1700034C RID: 844
		' (get) Token: 0x060005F9 RID: 1529 RVA: 0x00009AED File Offset: 0x00007CED
		' (set) Token: 0x060005FA RID: 1530 RVA: 0x00009AF7 File Offset: 0x00007CF7
		Friend Overridable Property lblY As Label

		' Token: 0x1700034D RID: 845
		' (get) Token: 0x060005FB RID: 1531 RVA: 0x00009B00 File Offset: 0x00007D00
		' (set) Token: 0x060005FC RID: 1532 RVA: 0x00009B0A File Offset: 0x00007D0A
		Friend Overridable Property lblX As Label

		' Token: 0x1700034E RID: 846
		' (get) Token: 0x060005FD RID: 1533 RVA: 0x00009B13 File Offset: 0x00007D13
		' (set) Token: 0x060005FE RID: 1534 RVA: 0x00009B1D File Offset: 0x00007D1D
		Friend Overridable Property lblDiamensionY As Label

		' Token: 0x1700034F RID: 847
		' (get) Token: 0x060005FF RID: 1535 RVA: 0x00009B26 File Offset: 0x00007D26
		' (set) Token: 0x06000600 RID: 1536 RVA: 0x00009B30 File Offset: 0x00007D30
		Friend Overridable Property lblDiamensionX As Label

		' Token: 0x17000350 RID: 848
		' (get) Token: 0x06000601 RID: 1537 RVA: 0x00009B39 File Offset: 0x00007D39
		' (set) Token: 0x06000602 RID: 1538 RVA: 0x000944BC File Offset: 0x000926BC
		Private _cbxSalePrice As CheckBox
		Friend Overridable Property cbxSalePrice As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxSalePrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxSalePrice_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxSalePrice
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxSalePrice = value
				checkBox = Me._cbxSalePrice
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000351 RID: 849
		' (get) Token: 0x06000603 RID: 1539 RVA: 0x00009B43 File Offset: 0x00007D43
		' (set) Token: 0x06000604 RID: 1540 RVA: 0x00094500 File Offset: 0x00092700
		Private _cbxHSNC As CheckBox
		Friend Overridable Property cbxHSNC As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxHSNC
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxHSNC_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxHSNC
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxHSNC = value
				checkBox = Me._cbxHSNC
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000352 RID: 850
		' (get) Token: 0x06000605 RID: 1541 RVA: 0x00009B4D File Offset: 0x00007D4D
		' (set) Token: 0x06000606 RID: 1542 RVA: 0x00094544 File Offset: 0x00092744
		Private _cbxAvlQty As CheckBox
		Friend Overridable Property cbxAvlQty As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxAvlQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxAvlQty_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxAvlQty
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxAvlQty = value
				checkBox = Me._cbxAvlQty
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000353 RID: 851
		' (get) Token: 0x06000607 RID: 1543 RVA: 0x00009B57 File Offset: 0x00007D57
		' (set) Token: 0x06000608 RID: 1544 RVA: 0x00094588 File Offset: 0x00092788
		Private _cbxNoCopy As CheckBox
		Friend Overridable Property cbxNoCopy As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxNoCopy
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxNoCopy_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxNoCopy
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxNoCopy = value
				checkBox = Me._cbxNoCopy
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000354 RID: 852
		' (get) Token: 0x06000609 RID: 1545 RVA: 0x00009B61 File Offset: 0x00007D61
		' (set) Token: 0x0600060A RID: 1546 RVA: 0x000945CC File Offset: 0x000927CC
		Private _cbxCategory As CheckBox
		Friend Overridable Property cbxCategory As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxCategory_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxCategory
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxCategory = value
				checkBox = Me._cbxCategory
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000355 RID: 853
		' (get) Token: 0x0600060B RID: 1547 RVA: 0x00009B6B File Offset: 0x00007D6B
		' (set) Token: 0x0600060C RID: 1548 RVA: 0x00094610 File Offset: 0x00092810
		Private _cbxBarcode As CheckBox
		Friend Overridable Property cbxBarcode As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxBarcode_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxBarcode
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxBarcode = value
				checkBox = Me._cbxBarcode
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000356 RID: 854
		' (get) Token: 0x0600060D RID: 1549 RVA: 0x00009B75 File Offset: 0x00007D75
		' (set) Token: 0x0600060E RID: 1550 RVA: 0x00094654 File Offset: 0x00092854
		Private _cbxPCode As CheckBox
		Friend Overridable Property cbxPCode As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxPCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxPCode_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxPCode
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxPCode = value
				checkBox = Me._cbxPCode
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000357 RID: 855
		' (get) Token: 0x0600060F RID: 1551 RVA: 0x00009B7F File Offset: 0x00007D7F
		' (set) Token: 0x06000610 RID: 1552 RVA: 0x00094698 File Offset: 0x00092898
		Private _cbxProductName As CheckBox
		Friend Overridable Property cbxProductName As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxProductName_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxProductName
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxProductName = value
				checkBox = Me._cbxProductName
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000358 RID: 856
		' (get) Token: 0x06000611 RID: 1553 RVA: 0x00009B89 File Offset: 0x00007D89
		' (set) Token: 0x06000612 RID: 1554 RVA: 0x000946DC File Offset: 0x000928DC
		Private _PrintDocument1 As PrintDocument
		Friend Overridable Property PrintDocument1 As PrintDocument
			<CompilerGenerated()>
			Get
				Return Me._PrintDocument1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PrintDocument)
				Dim printPageEventHandler As PrintPageEventHandler = AddressOf Me.PrintDocument1_PrintPage
				Dim printDocument As PrintDocument = Me._PrintDocument1
				If printDocument IsNot Nothing Then
					RemoveHandler printDocument.PrintPage, printPageEventHandler
				End If
				Me._PrintDocument1 = value
				printDocument = Me._PrintDocument1
				If printDocument IsNot Nothing Then
					AddHandler printDocument.PrintPage, printPageEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000359 RID: 857
		' (get) Token: 0x06000613 RID: 1555 RVA: 0x00009B93 File Offset: 0x00007D93
		' (set) Token: 0x06000614 RID: 1556 RVA: 0x00094720 File Offset: 0x00092920
		Private _cbxPartNo As CheckBox
		Friend Overridable Property cbxPartNo As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._cbxPartNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.cbxPartNo_CheckedChanged
				Dim checkBox As CheckBox = Me._cbxPartNo
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._cbxPartNo = value
				checkBox = Me._cbxPartNo
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700035A RID: 858
		' (get) Token: 0x06000615 RID: 1557 RVA: 0x00009B9D File Offset: 0x00007D9D
		' (set) Token: 0x06000616 RID: 1558 RVA: 0x00009BA7 File Offset: 0x00007DA7
		Friend Overridable Property dgvLabels As DataGridView

		' Token: 0x1700035B RID: 859
		' (get) Token: 0x06000617 RID: 1559 RVA: 0x00009BB0 File Offset: 0x00007DB0
		' (set) Token: 0x06000618 RID: 1560 RVA: 0x00009BBA File Offset: 0x00007DBA
		Friend Overridable Property PrintPreviewDialog1 As PrintPreviewDialog

		' Token: 0x1700035C RID: 860
		' (get) Token: 0x06000619 RID: 1561 RVA: 0x00009BC3 File Offset: 0x00007DC3
		' (set) Token: 0x0600061A RID: 1562 RVA: 0x00009BCD File Offset: 0x00007DCD
		Friend Overridable Property PrintDialog1 As PrintDialog

		' Token: 0x1700035D RID: 861
		' (get) Token: 0x0600061B RID: 1563 RVA: 0x00009BD6 File Offset: 0x00007DD6
		' (set) Token: 0x0600061C RID: 1564 RVA: 0x00009BE0 File Offset: 0x00007DE0
		Friend Overridable Property pbQrBarCode As PictureBox

		' Token: 0x1700035E RID: 862
		' (get) Token: 0x0600061D RID: 1565 RVA: 0x00009BE9 File Offset: 0x00007DE9
		' (set) Token: 0x0600061E RID: 1566 RVA: 0x00009BF3 File Offset: 0x00007DF3
		Friend Overridable Property pbQrCode As PictureBox

		' Token: 0x1700035F RID: 863
		' (get) Token: 0x0600061F RID: 1567 RVA: 0x00009BFC File Offset: 0x00007DFC
		' (set) Token: 0x06000620 RID: 1568 RVA: 0x00009C06 File Offset: 0x00007E06
		Friend Overridable Property gbxOptions As GroupBox

		' Token: 0x17000360 RID: 864
		' (get) Token: 0x06000621 RID: 1569 RVA: 0x00009C0F File Offset: 0x00007E0F
		' (set) Token: 0x06000622 RID: 1570 RVA: 0x00009C19 File Offset: 0x00007E19
		Friend Overridable Property toolTip As ToolTip

		' Token: 0x17000361 RID: 865
		' (get) Token: 0x06000623 RID: 1571 RVA: 0x00009C22 File Offset: 0x00007E22
		' (set) Token: 0x06000624 RID: 1572 RVA: 0x00009C2C File Offset: 0x00007E2C
		Friend Overridable Property lblMandatory As Label

		' Token: 0x17000362 RID: 866
		' (get) Token: 0x06000625 RID: 1573 RVA: 0x00009C35 File Offset: 0x00007E35
		' (set) Token: 0x06000626 RID: 1574 RVA: 0x00009C3F File Offset: 0x00007E3F
		Friend Overridable Property ttPanelCheque As ToolTip

		' Token: 0x17000363 RID: 867
		' (get) Token: 0x06000627 RID: 1575 RVA: 0x00009C48 File Offset: 0x00007E48
		' (set) Token: 0x06000628 RID: 1576 RVA: 0x00094764 File Offset: 0x00092964
		Private _pnlCheque As Panel
		Friend Overridable Property pnlCheque As Panel
			<CompilerGenerated()>
			Get
				Return Me._pnlCheque
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.pnlCheque_MouseClick
				Dim mouseEventHandler2 As MouseEventHandler = AddressOf Me.pnlCheque_MouseDown
				Dim eventHandler As EventHandler = AddressOf Me.pnlCheque_Resize_1
				Dim panel As Panel = Me._pnlCheque
				If panel IsNot Nothing Then
					RemoveHandler panel.MouseClick, mouseEventHandler
					RemoveHandler panel.MouseDown, mouseEventHandler2
					RemoveHandler panel.Resize, eventHandler
				End If
				Me._pnlCheque = value
				panel = Me._pnlCheque
				If panel IsNot Nothing Then
					AddHandler panel.MouseClick, mouseEventHandler
					AddHandler panel.MouseDown, mouseEventHandler2
					AddHandler panel.Resize, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000364 RID: 868
		' (get) Token: 0x06000629 RID: 1577 RVA: 0x00009C52 File Offset: 0x00007E52
		' (set) Token: 0x0600062A RID: 1578 RVA: 0x00009C5C File Offset: 0x00007E5C
		Friend Overridable Property lblChequeHeight As Label

		' Token: 0x17000365 RID: 869
		' (get) Token: 0x0600062B RID: 1579 RVA: 0x00009C65 File Offset: 0x00007E65
		' (set) Token: 0x0600062C RID: 1580 RVA: 0x00009C6F File Offset: 0x00007E6F
		Friend Overridable Property lblChequeWidth As Label

		' Token: 0x17000366 RID: 870
		' (get) Token: 0x0600062D RID: 1581 RVA: 0x00009C78 File Offset: 0x00007E78
		' (set) Token: 0x0600062E RID: 1582 RVA: 0x000947E0 File Offset: 0x000929E0
		Private _nudChequeLeafWidth As NumericUpDown
		Friend Overridable Property nudChequeLeafWidth As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudChequeLeafWidth
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudChequeLeafWidth_ValueChanged
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.nudChequeLeafWidth_MouseDown
				Dim numericUpDown As NumericUpDown = Me._nudChequeLeafWidth
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
					RemoveHandler numericUpDown.MouseDown, mouseEventHandler
				End If
				Me._nudChequeLeafWidth = value
				numericUpDown = Me._nudChequeLeafWidth
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
					AddHandler numericUpDown.MouseDown, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000367 RID: 871
		' (get) Token: 0x0600062F RID: 1583 RVA: 0x00009C82 File Offset: 0x00007E82
		' (set) Token: 0x06000630 RID: 1584 RVA: 0x00094840 File Offset: 0x00092A40
		Private _nudChequeHeight As NumericUpDown
		Friend Overridable Property nudChequeHeight As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudChequeHeight
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudChequeHeight_ValueChanged
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.nudChequeHeight_MouseDown
				Dim numericUpDown As NumericUpDown = Me._nudChequeHeight
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
					RemoveHandler numericUpDown.MouseDown, mouseEventHandler
				End If
				Me._nudChequeHeight = value
				numericUpDown = Me._nudChequeHeight
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
					AddHandler numericUpDown.MouseDown, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000368 RID: 872
		' (get) Token: 0x06000631 RID: 1585 RVA: 0x00009C8C File Offset: 0x00007E8C
		' (set) Token: 0x06000632 RID: 1586 RVA: 0x000948A0 File Offset: 0x00092AA0
		Private _nudLeft As NumericUpDown
		Friend Overridable Property nudLeft As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudLeft
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudLeft_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudLeft
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudLeft = value
				numericUpDown = Me._nudLeft
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000369 RID: 873
		' (get) Token: 0x06000633 RID: 1587 RVA: 0x00009C96 File Offset: 0x00007E96
		' (set) Token: 0x06000634 RID: 1588 RVA: 0x00009CA0 File Offset: 0x00007EA0
		Friend Overridable Property lblLeft As Label

		' Token: 0x1700036A RID: 874
		' (get) Token: 0x06000635 RID: 1589 RVA: 0x00009CA9 File Offset: 0x00007EA9
		' (set) Token: 0x06000636 RID: 1590 RVA: 0x000948E4 File Offset: 0x00092AE4
		Private _nudTop As NumericUpDown
		Friend Overridable Property nudTop As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudTop
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudTop_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudTop
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudTop = value
				numericUpDown = Me._nudTop
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700036B RID: 875
		' (get) Token: 0x06000637 RID: 1591 RVA: 0x00009CB3 File Offset: 0x00007EB3
		' (set) Token: 0x06000638 RID: 1592 RVA: 0x00094928 File Offset: 0x00092B28
		Private _nudHeight As NumericUpDown
		Friend Overridable Property nudHeight As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudHeight
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudHeight_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudHeight
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudHeight = value
				numericUpDown = Me._nudHeight
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700036C RID: 876
		' (get) Token: 0x06000639 RID: 1593 RVA: 0x00009CBD File Offset: 0x00007EBD
		' (set) Token: 0x0600063A RID: 1594 RVA: 0x0009496C File Offset: 0x00092B6C
		Private _nudWidth As NumericUpDown
		Friend Overridable Property nudWidth As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudWidth
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudWidth_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudWidth
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudWidth = value
				numericUpDown = Me._nudWidth
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700036D RID: 877
		' (get) Token: 0x0600063B RID: 1595 RVA: 0x00009CC7 File Offset: 0x00007EC7
		' (set) Token: 0x0600063C RID: 1596 RVA: 0x000949B0 File Offset: 0x00092BB0
		Private _lnklblSetDefault As LinkLabel
		Friend Overridable Property lnklblSetDefault As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._lnklblSetDefault
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.lnklblSetDefault_LinkClicked
				Dim linkLabel As LinkLabel = Me._lnklblSetDefault
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._lnklblSetDefault = value
				linkLabel = Me._lnklblSetDefault
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700036E RID: 878
		' (get) Token: 0x0600063D RID: 1597 RVA: 0x00009CD1 File Offset: 0x00007ED1
		' (set) Token: 0x0600063E RID: 1598 RVA: 0x00009CDB File Offset: 0x00007EDB
		Friend Overridable Property lblTop As Label

		' Token: 0x1700036F RID: 879
		' (get) Token: 0x0600063F RID: 1599 RVA: 0x00009CE4 File Offset: 0x00007EE4
		' (set) Token: 0x06000640 RID: 1600 RVA: 0x00009CEE File Offset: 0x00007EEE
		Friend Overridable Property lblHeight As Label

		' Token: 0x17000370 RID: 880
		' (get) Token: 0x06000641 RID: 1601 RVA: 0x00009CF7 File Offset: 0x00007EF7
		' (set) Token: 0x06000642 RID: 1602 RVA: 0x00009D01 File Offset: 0x00007F01
		Friend Overridable Property lblLayOutName As Label

		' Token: 0x17000371 RID: 881
		' (get) Token: 0x06000643 RID: 1603 RVA: 0x00009D0A File Offset: 0x00007F0A
		' (set) Token: 0x06000644 RID: 1604 RVA: 0x00009D14 File Offset: 0x00007F14
		Friend Overridable Property gbxAlignMent As GroupBox

		' Token: 0x17000372 RID: 882
		' (get) Token: 0x06000645 RID: 1605 RVA: 0x00009D1D File Offset: 0x00007F1D
		' (set) Token: 0x06000646 RID: 1606 RVA: 0x00009D27 File Offset: 0x00007F27
		Friend Overridable Property lblWidth As Label

		' Token: 0x17000373 RID: 883
		' (get) Token: 0x06000647 RID: 1607 RVA: 0x00009D30 File Offset: 0x00007F30
		' (set) Token: 0x06000648 RID: 1608 RVA: 0x00009D3A File Offset: 0x00007F3A
		Friend Overridable Property txtLayoutName As TextBox

		' Token: 0x17000374 RID: 884
		' (get) Token: 0x06000649 RID: 1609 RVA: 0x00009D43 File Offset: 0x00007F43
		' (set) Token: 0x0600064A RID: 1610 RVA: 0x000949F4 File Offset: 0x00092BF4
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

		' Token: 0x17000375 RID: 885
		' (get) Token: 0x0600064B RID: 1611 RVA: 0x00009D4D File Offset: 0x00007F4D
		' (set) Token: 0x0600064C RID: 1612 RVA: 0x00094A38 File Offset: 0x00092C38
		Private _cmbFontSize As ComboBox
		Friend Overridable Property cmbFontSize As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbFontSize
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbFontSize_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbFontSize
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbFontSize = value
				comboBox = Me._cmbFontSize
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000376 RID: 886
		' (get) Token: 0x0600064D RID: 1613 RVA: 0x00009D57 File Offset: 0x00007F57
		' (set) Token: 0x0600064E RID: 1614 RVA: 0x00094A7C File Offset: 0x00092C7C
		Private _btnUnderline As CheckBox
		Friend Overridable Property btnUnderline As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._btnUnderline
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.btnItalic_Click
				Dim checkBox As CheckBox = Me._btnUnderline
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.Click, eventHandler
				End If
				Me._btnUnderline = value
				checkBox = Me._btnUnderline
				If checkBox IsNot Nothing Then
					AddHandler checkBox.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000377 RID: 887
		' (get) Token: 0x0600064F RID: 1615 RVA: 0x00009D61 File Offset: 0x00007F61
		' (set) Token: 0x06000650 RID: 1616 RVA: 0x00094AC0 File Offset: 0x00092CC0
		Private _btnItalic As CheckBox
		Friend Overridable Property btnItalic As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._btnItalic
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.btnItalic_Click
				Dim checkBox As CheckBox = Me._btnItalic
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.Click, eventHandler
				End If
				Me._btnItalic = value
				checkBox = Me._btnItalic
				If checkBox IsNot Nothing Then
					AddHandler checkBox.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000378 RID: 888
		' (get) Token: 0x06000651 RID: 1617 RVA: 0x00009D6B File Offset: 0x00007F6B
		' (set) Token: 0x06000652 RID: 1618 RVA: 0x00094B04 File Offset: 0x00092D04
		Private _btnColor As Button
		Friend Overridable Property btnColor As Button
			<CompilerGenerated()>
			Get
				Return Me._btnColor
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnColor_Click
				Dim button As Button = Me._btnColor
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnColor = value
				button = Me._btnColor
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000379 RID: 889
		' (get) Token: 0x06000653 RID: 1619 RVA: 0x00009D75 File Offset: 0x00007F75
		' (set) Token: 0x06000654 RID: 1620 RVA: 0x00094B48 File Offset: 0x00092D48
		Private _btnBold As CheckBox
		Friend Overridable Property btnBold As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._btnBold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.btnBold_Click
				Dim checkBox As CheckBox = Me._btnBold
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.Click, eventHandler
				End If
				Me._btnBold = value
				checkBox = Me._btnBold
				If checkBox IsNot Nothing Then
					AddHandler checkBox.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700037A RID: 890
		' (get) Token: 0x06000655 RID: 1621 RVA: 0x00009D7F File Offset: 0x00007F7F
		' (set) Token: 0x06000656 RID: 1622 RVA: 0x00094B8C File Offset: 0x00092D8C
		Private _cmbFonts As ComboBox
		Friend Overridable Property cmbFonts As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbFonts
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbFonts_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbFonts
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbFonts = value
				comboBox = Me._cmbFonts
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700037B RID: 891
		' (get) Token: 0x06000657 RID: 1623 RVA: 0x00009D89 File Offset: 0x00007F89
		' (set) Token: 0x06000658 RID: 1624 RVA: 0x00094BD0 File Offset: 0x00092DD0
		Private _btnRevert As Button
		Friend Overridable Property btnRevert As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRevert
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRevert_Click
				Dim button As Button = Me._btnRevert
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRevert = value
				button = Me._btnRevert
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700037C RID: 892
		' (get) Token: 0x06000659 RID: 1625 RVA: 0x00009D93 File Offset: 0x00007F93
		' (set) Token: 0x0600065A RID: 1626 RVA: 0x00009D9D File Offset: 0x00007F9D
		Friend Overridable Property lblHiddenImage As Label

		' Token: 0x1700037D RID: 893
		' (get) Token: 0x0600065B RID: 1627 RVA: 0x00009DA6 File Offset: 0x00007FA6
		' (set) Token: 0x0600065C RID: 1628 RVA: 0x00094C14 File Offset: 0x00092E14
		Private _btnZoom As Button
		Friend Overridable Property btnZoom As Button
			<CompilerGenerated()>
			Get
				Return Me._btnZoom
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnZoom_Click
				Dim button As Button = Me._btnZoom
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnZoom = value
				button = Me._btnZoom
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700037E RID: 894
		' (get) Token: 0x0600065D RID: 1629 RVA: 0x00009DB0 File Offset: 0x00007FB0
		' (set) Token: 0x0600065E RID: 1630 RVA: 0x00094C58 File Offset: 0x00092E58
		Private _btnAddImage As Button
		Friend Overridable Property btnAddImage As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAddImage
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = Sub(a0 As Object, a1 As EventArgs)
					Me.btnAddImage_Click(RuntimeHelpers.GetObjectValue(a0), a1)
				End Sub
				Dim button As Button = Me._btnAddImage
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAddImage = value
				button = Me._btnAddImage
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700037F RID: 895
		' (get) Token: 0x0600065F RID: 1631 RVA: 0x00009DBA File Offset: 0x00007FBA
		' (set) Token: 0x06000660 RID: 1632 RVA: 0x00094C9C File Offset: 0x00092E9C
		Private _cmbLayouts As ComboBox
		Friend Overridable Property cmbLayouts As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbLayouts
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbLayouts_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbLayouts
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbLayouts = value
				comboBox = Me._cmbLayouts
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000380 RID: 896
		' (get) Token: 0x06000661 RID: 1633 RVA: 0x00009DC4 File Offset: 0x00007FC4
		' (set) Token: 0x06000662 RID: 1634 RVA: 0x00009DCE File Offset: 0x00007FCE
		Friend Overridable Property Label1 As Label

		' Token: 0x17000381 RID: 897
		' (get) Token: 0x06000663 RID: 1635 RVA: 0x00009DD7 File Offset: 0x00007FD7
		' (set) Token: 0x06000664 RID: 1636 RVA: 0x00009DE1 File Offset: 0x00007FE1
		Friend Overridable Property lblHidden As Label

		' Token: 0x17000382 RID: 898
		' (get) Token: 0x06000665 RID: 1637 RVA: 0x00009DEA File Offset: 0x00007FEA
		' (set) Token: 0x06000666 RID: 1638 RVA: 0x00009DF4 File Offset: 0x00007FF4
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000383 RID: 899
		' (get) Token: 0x06000667 RID: 1639 RVA: 0x00009DFD File Offset: 0x00007FFD
		' (set) Token: 0x06000668 RID: 1640 RVA: 0x00009E07 File Offset: 0x00008007
		Friend Overridable Property panel2 As Panel

		' Token: 0x17000384 RID: 900
		' (get) Token: 0x06000669 RID: 1641 RVA: 0x00009E10 File Offset: 0x00008010
		' (set) Token: 0x0600066A RID: 1642 RVA: 0x00094CE0 File Offset: 0x00092EE0
		Private _btnAddLabel As Button
		Friend Overridable Property btnAddLabel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAddLabel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddLabel_Click
				Dim button As Button = Me._btnAddLabel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAddLabel = value
				button = Me._btnAddLabel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000385 RID: 901
		' (get) Token: 0x0600066B RID: 1643 RVA: 0x00009E1A File Offset: 0x0000801A
		' (set) Token: 0x0600066C RID: 1644 RVA: 0x00009E24 File Offset: 0x00008024
		Friend Overridable Property gbxChequeSize As GroupBox

		' Token: 0x17000386 RID: 902
		' (get) Token: 0x0600066D RID: 1645 RVA: 0x00009E2D File Offset: 0x0000802D
		' (set) Token: 0x0600066E RID: 1646 RVA: 0x00094D24 File Offset: 0x00092F24
		Private _btnBgColor_Layout As Button
		Friend Overridable Property btnBgColor_Layout As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBgColor_Layout
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBgColor_Layout_Click
				Dim button As Button = Me._btnBgColor_Layout
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBgColor_Layout = value
				button = Me._btnBgColor_Layout
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000387 RID: 903
		' (get) Token: 0x0600066F RID: 1647 RVA: 0x00009E37 File Offset: 0x00008037
		' (set) Token: 0x06000670 RID: 1648 RVA: 0x00009E41 File Offset: 0x00008041
		Friend Overridable Property lblBg As Label

		' Token: 0x17000388 RID: 904
		' (get) Token: 0x06000671 RID: 1649 RVA: 0x00009E4A File Offset: 0x0000804A
		' (set) Token: 0x06000672 RID: 1650 RVA: 0x00094D68 File Offset: 0x00092F68
		Private _rulerCtrlLeft As RulerControl
		Friend Overridable Property rulerCtrlLeft As RulerControl
			<CompilerGenerated()>
			Get
				Return Me._rulerCtrlLeft
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RulerControl)
				Dim hooverValueEvent As RulerControl.HooverValueEvent = AddressOf Me.rulerCtrlLeft_HooverValue
				Dim rulerControl As RulerControl = Me._rulerCtrlLeft
				If rulerControl IsNot Nothing Then
					RemoveHandler rulerControl.HooverValue, hooverValueEvent
				End If
				Me._rulerCtrlLeft = value
				rulerControl = Me._rulerCtrlLeft
				If rulerControl IsNot Nothing Then
					AddHandler rulerControl.HooverValue, hooverValueEvent
				End If
			End Set
		End Property

		' Token: 0x17000389 RID: 905
		' (get) Token: 0x06000673 RID: 1651 RVA: 0x00009E54 File Offset: 0x00008054
		' (set) Token: 0x06000674 RID: 1652 RVA: 0x00094DAC File Offset: 0x00092FAC
		Private _rulerCtrlTop As RulerControl
		Friend Overridable Property rulerCtrlTop As RulerControl
			<CompilerGenerated()>
			Get
				Return Me._rulerCtrlTop
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RulerControl)
				Dim hooverValueEvent As RulerControl.HooverValueEvent = AddressOf Me.rulerCtrlTop_HooverValue
				Dim rulerControl As RulerControl = Me._rulerCtrlTop
				If rulerControl IsNot Nothing Then
					RemoveHandler rulerControl.HooverValue, hooverValueEvent
				End If
				Me._rulerCtrlTop = value
				rulerControl = Me._rulerCtrlTop
				If rulerControl IsNot Nothing Then
					AddHandler rulerControl.HooverValue, hooverValueEvent
				End If
			End Set
		End Property

		' Token: 0x1700038A RID: 906
		' (get) Token: 0x06000675 RID: 1653 RVA: 0x00009E5E File Offset: 0x0000805E
		' (set) Token: 0x06000676 RID: 1654 RVA: 0x00094DF0 File Offset: 0x00092FF0
		Private _pnlWorkSpace As Panel
		Friend Overridable Property pnlWorkSpace As Panel
			<CompilerGenerated()>
			Get
				Return Me._pnlWorkSpace
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Dim eventHandler As EventHandler = AddressOf Me.pnlWorkSpace_MouseEnter
				Dim panel As Panel = Me._pnlWorkSpace
				If panel IsNot Nothing Then
					RemoveHandler panel.MouseEnter, eventHandler
				End If
				Me._pnlWorkSpace = value
				panel = Me._pnlWorkSpace
				If panel IsNot Nothing Then
					AddHandler panel.MouseEnter, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700038B RID: 907
		' (get) Token: 0x06000677 RID: 1655 RVA: 0x00009E68 File Offset: 0x00008068
		' (set) Token: 0x06000678 RID: 1656 RVA: 0x00009E72 File Offset: 0x00008072
		Private Property number As Integer

		' Token: 0x1700038C RID: 908
		' (get) Token: 0x06000679 RID: 1657 RVA: 0x00009E7B File Offset: 0x0000807B
		' (set) Token: 0x0600067A RID: 1658 RVA: 0x00009E85 File Offset: 0x00008085
		Private Property numberPb As Integer

		' Token: 0x0600067B RID: 1659 RVA: 0x00094E34 File Offset: 0x00093034
		Private Function CreateLabelOnLocation() As Object
			Dim flag As Boolean = (Me.clickLocation.X = 0) And (Me.clickLocation.Y = 0)
			Dim obj As Object
			If flag Then
				MessageBox.Show("Please click anywhere on panel to insert")
				obj = False
			Else
				obj = True
			End If
			Return obj
		End Function

		' Token: 0x0600067C RID: 1660 RVA: 0x00094E84 File Offset: 0x00093084
		Private Sub lnklblSetDefault_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Me.SetDefault()
				Dim flag As Boolean = Me.ctrlPanel IsNot Nothing
				If flag Then
					Me.dl.Remove()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x0600067D RID: 1661 RVA: 0x00094EE4 File Offset: 0x000930E4
		Private Sub SetDefault()
			Try
				Me.nudChequeLeafWidth.Value = 17.6D
				Me.nudChequeHeight.Value = 8.7D
				Me.pnlCheque.Top = 21
				Me.pnlCheque.Left = 21
			Catch ex As Exception
				MessageBox.Show("CH:3" + ex.Message)
			End Try
		End Sub

		' Token: 0x0600067E RID: 1662 RVA: 0x00094F78 File Offset: 0x00093178
		Private Sub nudChequeLeafWidth_ValueChanged(sender As Object, e As EventArgs)
			Try
				Me.pnlCheque.Width = Convert.ToInt32(Decimal.Multiply(Me.nudChequeLeafWidth.Value, 38D))
			Catch ex As Exception
				MessageBox.Show("CH:25" + ex.Message)
			End Try
		End Sub

		' Token: 0x0600067F RID: 1663 RVA: 0x00094FE8 File Offset: 0x000931E8
		Private Sub nudChequeLeafWidth_MouseDown(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.ctrlPanel IsNot Nothing
				If flag Then
					Me.dl.Remove()
				End If
			Catch ex As Exception
				MessageBox.Show("CH:34" + ex.Message)
			End Try
		End Sub

		' Token: 0x06000680 RID: 1664 RVA: 0x0009504C File Offset: 0x0009324C
		Private Sub nudChequeHeight_ValueChanged(sender As Object, e As EventArgs)
			Try
				Me.pnlCheque.Height = Convert.ToInt32(Decimal.Multiply(Me.nudChequeHeight.Value, 38D))
			Catch ex As Exception
				MessageBox.Show("CH:26" + ex.Message)
			End Try
		End Sub

		' Token: 0x06000681 RID: 1665 RVA: 0x000950BC File Offset: 0x000932BC
		Private Sub nudChequeHeight_MouseDown(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.ctrlPanel IsNot Nothing
				If flag Then
					Me.dl.Remove()
				End If
			Catch ex As Exception
				MessageBox.Show("CH:35" + ex.Message)
			End Try
		End Sub

		' Token: 0x06000682 RID: 1666 RVA: 0x00009E8E File Offset: 0x0000808E
		Private Sub btnAddLabel_Click(sender As Object, e As EventArgs)
			Me.btnCreateLAbel()
		End Sub

		' Token: 0x06000683 RID: 1667 RVA: 0x00095120 File Offset: 0x00093320
		Private Function lblCreatePcode() As Object
			Dim label As Label = New Label()
			label.Name = "PCode"
			label.Text = "PCode"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxPCode.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000684 RID: 1668 RVA: 0x00095290 File Offset: 0x00093490
		Private Function lblCreateProductName() As Object
			Dim label As Label = New Label()
			label.Name = "ProductName"
			label.Text = "ProductName"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxProductName.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000685 RID: 1669 RVA: 0x00095400 File Offset: 0x00093600
		Private Function lblCreateCategory() As Object
			Dim label As Label = New Label()
			label.Name = "Category"
			label.Text = "Category"
			label.SendToBack()
			label.AutoSize = False
			label.Width = Convert.ToInt32(Me.nudWidth.Value)
			label.Height = Me.nudWidth.Height
			label.Top = Me.nudWidth.Top
			label.Left = Me.nudWidth.Left
			label.Font = New Font(Me.cmbFonts.Text, Conversions.ToSingle(Me.cmbFontSize.Text))
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxCategory.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000686 RID: 1670 RVA: 0x000955E4 File Offset: 0x000937E4
		Private Function lblCreateBarcode() As Object
			Dim label As Label = New Label()
			label.Name = "Barcode"
			label.Text = "Barcode"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxBarcode.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000687 RID: 1671 RVA: 0x00095754 File Offset: 0x00093954
		Private Function lblCreateAvlQty() As Object
			Dim label As Label = New Label()
			label.Name = "AvlQty"
			label.Text = "AvlQty"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxAvlQty.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000688 RID: 1672 RVA: 0x000958C4 File Offset: 0x00093AC4
		Private Function lblCreateNoCopy() As Object
			Dim label As Label = New Label()
			label.Name = "NoCopy"
			label.Text = "NoCopy"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxNoCopy.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000689 RID: 1673 RVA: 0x00095A34 File Offset: 0x00093C34
		Private Function lblCreatePartNo() As Object
			Dim label As Label = New Label()
			label.Name = "PartNo"
			label.Text = "PartNo"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxPartNo.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068A RID: 1674 RVA: 0x00095BA4 File Offset: 0x00093DA4
		Private Function lblCreateHSNC() As Object
			Dim label As Label = New Label()
			label.Name = "HSNC"
			label.Text = "HSNC"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxHSNC.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068B RID: 1675 RVA: 0x00095D14 File Offset: 0x00093F14
		Private Function lblCreateMRP() As Object
			Dim label As Label = New Label()
			label.Name = "MRP"
			label.Text = "MRP"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxMRP.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068C RID: 1676 RVA: 0x00095E84 File Offset: 0x00094084
		Private Function lblCreateSalePrice() As Object
			Dim label As Label = New Label()
			label.Name = "SalePrice"
			label.Text = "SalePrice"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxSalePrice.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068D RID: 1677 RVA: 0x00095FF4 File Offset: 0x000941F4
		Private Function lblCreateWholesalePrice() As Object
			Dim label As Label = New Label()
			label.Name = "WholesalePrice"
			label.Text = "WholesalePrice"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxWholesalePrice.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068E RID: 1678 RVA: 0x00096164 File Offset: 0x00094364
		Private Function lblCreateBatch() As Object
			Dim label As Label = New Label()
			label.Name = "Batch"
			label.Text = "Batch"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxBatch.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x0600068F RID: 1679 RVA: 0x000962D4 File Offset: 0x000944D4
		Private Function lblCreateMfg() As Object
			Dim label As Label = New Label()
			label.Name = "Mfg"
			label.Text = "Mfg"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxMfg.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000690 RID: 1680 RVA: 0x00096444 File Offset: 0x00094644
		Private Function lblCreateExp() As Object
			Dim label As Label = New Label()
			label.Name = "Exp"
			label.Text = "Exp"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxExp.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000691 RID: 1681 RVA: 0x000965B4 File Offset: 0x000947B4
		Private Function lblCreateSize() As Object
			Dim label As Label = New Label()
			label.Name = "Size"
			label.Text = "Size"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxSize.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000692 RID: 1682 RVA: 0x00096724 File Offset: 0x00094924
		Private Function lblCreateColour() As Object
			Dim label As Label = New Label()
			label.Name = "Colour"
			label.Text = "Colour"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxColour.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000693 RID: 1683 RVA: 0x00096894 File Offset: 0x00094A94
		Private Function lblCreateGST() As Object
			Dim label As Label = New Label()
			label.Name = "GST"
			label.Text = "GST"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxGST.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000694 RID: 1684 RVA: 0x00096A04 File Offset: 0x00094C04
		Private Function lblCreatePurInv() As Object
			Dim label As Label = New Label()
			label.Name = "PurInv"
			label.Text = "PurInv"
			label.SendToBack()
			label.AutoSize = False
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.lblHidden.Tag = label.Name
				label.Visible = False
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Me.cbxPurInv.Checked = False
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000695 RID: 1685 RVA: 0x00096B74 File Offset: 0x00094D74
		Private Sub lblCreateQrBarcode()
			Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
			Dim text As String = "qrimg.png"
			Dim text2 As String = Path.Combine(baseDirectory, text)
			Dim flag As Boolean = File.Exists(text2)
			If flag Then
				Me.pbQrBarCode.Image = Image.FromFile(text2)
			End If
			Me.pbQrBarCode.Text = "pbarcode" + Me.numberPb.ToString()
			Me.pbQrBarCode.SendToBack()
			Me.pbQrBarCode.SizeMode = PictureBoxSizeMode.Zoom
			Me.pbQrBarCode.Top = Me.nudWidth.Top
			Me.pbQrBarCode.Left = Me.nudWidth.Left
			Me.pbQrBarCode.Location = New Point(CType(Me.clickLocation, Size))
			Me.clickLocation.X = 0
			Me.clickLocation.Y = 0
			Me.pnlCheque.Controls.Add(Me.pbQrBarCode)
			Try
				For Each obj As Object In Me.pnlCheque.Controls
					Dim control As Control = CType(obj, Control)
					Me.dl.WireControl(control)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06000696 RID: 1686 RVA: 0x00096CDC File Offset: 0x00094EDC
		Private Function btnCreateLAbel() As Object
			Dim label As Label = New Label()
			label.Name = "Label" + Me.number.ToString()
			label.Text = "Label" + Me.number.ToString()
			label.SendToBack()
			label.AutoSize = False
			label.Width = Convert.ToInt32(Me.nudWidth.Value)
			label.Height = Me.nudWidth.Height
			label.Top = Me.nudWidth.Top
			label.Left = Me.nudWidth.Left
			label.Font = New Font(Me.cmbFonts.Text, Conversions.ToSingle(Me.cmbFontSize.Text))
			Dim flag As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
			Dim obj2 As Object
			If flag Then
				label.Location = New Point(CType(Me.clickLocation, Size))
				Me.clickLocation.X = 0
				Me.clickLocation.Y = 0
				label.ContextMenuStrip = Me.ContextMenuStrip1
				Me.pnlCheque.Controls.Add(label)
				Me.number += 1
				Me.lblHidden.Tag = label.Name
				Dim checked As Boolean = Me.btnBold.Checked
				If checked Then
					Me.SetBoldItalicUnderline(label, FontStyle.Bold)
					Dim checked2 As Boolean = Me.btnItalic.Checked
					If checked2 Then
						Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic)
						Dim checked3 As Boolean = Me.btnUnderline.Checked
						If checked3 Then
							Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
						End If
					End If
					Dim checked4 As Boolean = Me.btnUnderline.Checked
					If checked4 Then
						Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Underline)
						Dim checked5 As Boolean = Me.btnItalic.Checked
						If checked5 Then
							Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
						End If
					End If
				Else
					Dim checked6 As Boolean = Me.btnItalic.Checked
					If checked6 Then
						Me.SetBoldItalicUnderline(label, FontStyle.Italic)
						Dim checked7 As Boolean = Me.btnBold.Checked
						If checked7 Then
							Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic)
							Dim checked8 As Boolean = Me.btnUnderline.Checked
							If checked8 Then
								Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
							End If
						End If
						Dim checked9 As Boolean = Me.btnUnderline.Checked
						If checked9 Then
							Dim checked10 As Boolean = Me.btnBold.Checked
							If checked10 Then
								Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
							End If
						End If
					Else
						Dim checked11 As Boolean = Me.btnUnderline.Checked
						If checked11 Then
							Me.SetBoldItalicUnderline(label, FontStyle.Underline)
							Dim checked12 As Boolean = Me.btnBold.Checked
							If checked12 Then
								Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Underline)
								Dim checked13 As Boolean = Me.btnItalic.Checked
								If checked13 Then
									Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
								End If
							End If
							Dim checked14 As Boolean = Me.btnItalic.Checked
							If checked14 Then
								Dim checked15 As Boolean = Me.btnBold.Checked
								If checked15 Then
									Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
								End If
							End If
						End If
					End If
				End If
				AddHandler label.Click, AddressOf Me.lb_Click
				AddHandler label.Resize, AddressOf Me.lb_Resize
				AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
				Try
					For Each obj As Object In Me.pnlCheque.Controls
						Dim control As Control = CType(obj, Control)
						Me.dl.WireControl(control)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				obj2 = True
			Else
				obj2 = False
			End If
			Return obj2
		End Function

		' Token: 0x06000697 RID: 1687 RVA: 0x00097084 File Offset: 0x00095284
		Private Function btnCreateImage() As Object
			Dim pictureBox As PictureBox = New PictureBox()
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				pictureBox.Load(openFileDialog.FileName)
			End If
			pictureBox.Name = "GenericImage" + Me.numberPb.ToString()
			pictureBox.Text = "GenericImage" + Me.numberPb.ToString()
			pictureBox.SendToBack()
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom
			pictureBox.Top = Me.nudWidth.Top
			pictureBox.Left = Me.nudWidth.Left
			pictureBox.Location = New Point(CType(Me.clickLocation, Size))
			Me.clickLocation.X = 0
			Me.clickLocation.Y = 0
			Me.pnlCheque.Controls.Add(pictureBox)
			Me.numberPb += 1
			Me.lblHiddenImage.Tag = pictureBox.Name
			AddHandler pictureBox.Click, AddressOf Me.pb_Click
			AddHandler pictureBox.Resize, AddressOf Me.pb_Resize
			Try
				For Each obj As Object In Me.pnlCheque.Controls
					Dim control As Control = CType(obj, Control)
					Me.dl.WireControl(control)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Return True
		End Function

		' Token: 0x06000698 RID: 1688 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub pb_Resize(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06000699 RID: 1689 RVA: 0x00009E9B File Offset: 0x0000809B
		Private Sub pb_Click(sender As Object, e As EventArgs)
			Me.lblHiddenImage.Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, Nothing, "Name", New Object(-1) {}, Nothing, Nothing, Nothing))
		End Sub

		' Token: 0x0600069A RID: 1690 RVA: 0x00097234 File Offset: 0x00095434
		Private Sub lb_DoubleClick(sender As Object, e As EventArgs)
			Dim label As Label = CType(sender, Label)
			Dim textBox As TextBox = New TextBox()
			Dim size As Size = New Size(label.Width + 25, textBox.Size.Height + 25)
			textBox.Size = size
			textBox.Top = label.Top
			textBox.Left = label.Left
			textBox.Name = "TextField" + Me.number.ToString()
			textBox.Text = label.Text
			AddHandler textBox.KeyPress, AddressOf Me.box_keypress
			Me.pnlCheque.Controls.Add(textBox)
			textBox.BringToFront()
		End Sub

		' Token: 0x0600069B RID: 1691 RVA: 0x000972EC File Offset: 0x000954EC
		Private Sub box_keypress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = e.KeyChar = vbCr
			If flag Then
				Dim textBox As TextBox = CType(sender, TextBox)
				Dim label As Label = New Label()
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label2 As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label2.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label3 As Label = CType(obj, Label)
				label3.AutoSize = True
				label3.Text = textBox.Text
				textBox.Dispose()
			End If
		End Sub

		' Token: 0x0600069C RID: 1692 RVA: 0x0009739C File Offset: 0x0009559C
		Private Sub lb_Resize(sender As Object, e As EventArgs)
			Dim label As Label = CType(sender, Label)
			Me.nudWidth.Value = New Decimal(label.Width)
			Me.nudHeight.Value = New Decimal(label.Height)
			Me.nudTop.Value = New Decimal(label.Top)
			Me.nudLeft.Value = New Decimal(label.Left)
		End Sub

		' Token: 0x0600069D RID: 1693 RVA: 0x00097410 File Offset: 0x00095610
		Private Sub lb_Click(sender As Object, e As EventArgs)
			Me.lblHidden.Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, Nothing, "Name", New Object(-1) {}, Nothing, Nothing, Nothing))
			Dim label As Label = CType(sender, Label)
			Me.nudWidth.Value = New Decimal(label.Width)
			Me.nudHeight.Value = New Decimal(label.Height)
			Me.nudTop.Value = New Decimal(label.Top)
			Me.nudLeft.Value = New Decimal(label.Left)
			Me.cmbFonts.Text = label.Font.Name
			Me.cmbFontSize.Text = Conversions.ToString(label.Font.Size)
			label.Focus()
			AddHandler label.PreviewKeyDown, AddressOf Me.lbGenerated_KeyPress
		End Sub

		' Token: 0x0600069E RID: 1694 RVA: 0x000974F4 File Offset: 0x000956F4
		Private Sub lbGenerated_KeyPress(sender As Object, e As PreviewKeyDownEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.Delete
				If flag Then
					Dim controls As Object = Me.pnlCheque.Controls
					Dim type As Type = Nothing
					Dim text As String = "Item"
					Dim array As Object() = New Object(0) {}
					Dim num As Integer = 0
					Dim lblHidden As Label = Me.lblHidden
					Dim label As Label = lblHidden
					array(num) = lblHidden.Tag
					Dim array2 As Object() = array
					Dim array3 As String() = Nothing
					Dim array4 As Type() = Nothing
					Dim array5 As Boolean() = New Boolean() { True }
					Dim array6 As Boolean() = array5
					Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
					If array6(0) Then
						label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
					End If
					Dim label2 As Label = CType(obj, Label)
					Dim flag2 As Boolean = label2 IsNot Nothing
					If flag2 Then
						label2.Dispose()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600069F RID: 1695 RVA: 0x000975A8 File Offset: 0x000957A8
		Private Sub SetBold(LabelMe As Label)
			Dim fontStyle As FontStyle = FontStyle.Bold
			Dim font As Font = New Font(LabelMe.Font.FontFamily, LabelMe.Font.Size, fontStyle)
			LabelMe.Font = font
		End Sub

		' Token: 0x060006A0 RID: 1696 RVA: 0x000975E0 File Offset: 0x000957E0
		Private Sub SetFontSize()
			Dim num As Integer = 5
			Do
				Me.cmbFontSize.Items.Add(num)
				num += 1
			Loop While num <= 100
		End Sub

		' Token: 0x060006A1 RID: 1697 RVA: 0x00097610 File Offset: 0x00095810
		Private Sub GetFonts()
			For Each fontFamily As FontFamily In FontFamily.Families
				Me.cmbFonts.Items.Add(fontFamily.Name)
				Me.ToolStripCmbFonts.Items.Add(fontFamily.Name)
			Next
			Me.ToolStripCmbFonts.SelectedIndex = 0
		End Sub

		' Token: 0x060006A2 RID: 1698 RVA: 0x00097678 File Offset: 0x00095878
		Private Sub WireLabels(cont As Control)
			Try
				For Each obj As Object In cont.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is Label
					If flag Then
						AddHandler control.MouseDown, AddressOf Me.obj1_MouseDown
						AddHandler control.MouseMove, AddressOf Me.obj1_MouseMove
						control.Cursor = Cursors.SizeAll
					Else
						Dim hasChildren As Boolean = control.HasChildren
						If hasChildren Then
							Me.WireLabels(control)
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060006A3 RID: 1699 RVA: 0x0009772C File Offset: 0x0009592C
		Private Sub obj1_MouseDown(sender As Object, e As MouseEventArgs)
			Me.Off.X = Conversions.ToInteger(Operators.SubtractObject(Control.MousePosition.X, NewLateBinding.LateGet(sender, Nothing, "Left", New Object(-1) {}, Nothing, Nothing, Nothing)))
			Me.Off.Y = Conversions.ToInteger(Operators.SubtractObject(Control.MousePosition.Y, NewLateBinding.LateGet(sender, Nothing, "Top", New Object(-1) {}, Nothing, Nothing, Nothing)))
		End Sub

		' Token: 0x060006A4 RID: 1700 RVA: 0x000977B4 File Offset: 0x000959B4
		Private Sub obj1_MouseMove(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = e.Button = MouseButtons.Left
			If flag Then
				NewLateBinding.LateSet(sender, Nothing, "Left", New Object() { Control.MousePosition.X - Me.Off.X }, Nothing, Nothing)
				NewLateBinding.LateSet(sender, Nothing, "Top", New Object() { Control.MousePosition.Y - Me.Off.Y }, Nothing, Nothing)
			End If
		End Sub

		' Token: 0x060006A5 RID: 1701 RVA: 0x00097844 File Offset: 0x00095A44
		Private Sub LeftToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Left
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x060006A6 RID: 1702 RVA: 0x000978A8 File Offset: 0x00095AA8
		Private Sub CenterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Fill
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x060006A7 RID: 1703 RVA: 0x0009790C File Offset: 0x00095B0C
		Private Sub RightToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Right
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x060006A8 RID: 1704 RVA: 0x00097970 File Offset: 0x00095B70
		Private Sub ToolStripTextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripTextBox).OwnerItem.Owner, ContextMenuStrip)
				Dim label As Label = CType(contextMenuStrip.Tag, Label)
				label.Text = Me.ToolStripTextBox2.Text
				Me.ContextMenuStrip1.Visible = False
			End If
		End Sub

		' Token: 0x060006A9 RID: 1705 RVA: 0x000979D0 File Offset: 0x00095BD0
		Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			label.Dispose()
		End Sub

		' Token: 0x060006AA RID: 1706 RVA: 0x00097A04 File Offset: 0x00095C04
		Private Sub TextColorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim colorDialog As ColorDialog = New ColorDialog()
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim flag As Boolean = colorDialog.ShowDialog() = DialogResult.OK
			If flag Then
				label.ForeColor = colorDialog.Color
			End If
		End Sub

		' Token: 0x060006AB RID: 1707 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextSizeToolStripMenuItem_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060006AC RID: 1708 RVA: 0x00097A54 File Offset: 0x00095C54
		Private Sub BoldToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBold(label)
		End Sub

		' Token: 0x060006AD RID: 1709 RVA: 0x00097A8C File Offset: 0x00095C8C
		Private Sub ItalicToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Italic
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006AE RID: 1710 RVA: 0x00097AE4 File Offset: 0x00095CE4
		Private Sub RegularToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Regular
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006AF RID: 1711 RVA: 0x00097B3C File Offset: 0x00095D3C
		Private Sub UnderlineToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Strikeout
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006B0 RID: 1712 RVA: 0x00097B94 File Offset: 0x00095D94
		Private Sub pnlWorkSpace_MouseEnter(sender As Object, e As EventArgs)
			Try
				Me.rulerCtrlTop.MouseTrackingOn = False
				Me.rulerCtrlLeft.MouseTrackingOn = False
				Me.Cursor = Cursors.Arrow
			Catch ex As Exception
				MessageBox.Show("CH:21" + ex.Message)
			End Try
		End Sub

		' Token: 0x060006B1 RID: 1713 RVA: 0x00097C04 File Offset: 0x00095E04
		Private Sub pnlCheque_Resize(sender As Object, e As EventArgs)
			Try
				Me.nudChequeLeafWidth.Value = Decimal.Divide(New Decimal(Me.pnlCheque.Width), 38D)
				Me.nudChequeHeight.Value = Decimal.Divide(New Decimal(Me.pnlCheque.Height), 38D)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006B2 RID: 1714 RVA: 0x00097C88 File Offset: 0x00095E88
		Private Sub UnderlineToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Underline
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006B3 RID: 1715 RVA: 0x00097CE0 File Offset: 0x00095EE0
		Private Sub BoldItalicToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Bold Or FontStyle.Italic
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006B4 RID: 1716 RVA: 0x00097D38 File Offset: 0x00095F38
		Private Sub BoldStrikeoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Bold Or FontStyle.Strikeout
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006B5 RID: 1717 RVA: 0x00097D90 File Offset: 0x00095F90
		Private Sub BoldUnderlineToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Bold Or FontStyle.Underline
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x060006B6 RID: 1718 RVA: 0x00097DE8 File Offset: 0x00095FE8
		Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripTextBox).OwnerItem.Owner, ContextMenuStrip)
				Dim label As Label = CType(contextMenuStrip.Tag, Label)
				Dim fontStyle As FontStyle
				Dim font As Font = New Font(label.Font.FontFamily, CSng(Convert.ToInt16(Me.ToolStripTextBox1.Text)), fontStyle)
				label.Font = font
				Me.ContextMenuStrip1.Visible = False
			End If
		End Sub

		' Token: 0x060006B7 RID: 1719 RVA: 0x00009EC4 File Offset: 0x000080C4
		Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs)
			Me.ContextMenuStrip1.Tag = Me.ContextMenuStrip1.SourceControl
		End Sub

		' Token: 0x060006B8 RID: 1720 RVA: 0x00097E64 File Offset: 0x00096064
		Private Sub btnBold_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.pnlCheque.Controls
			Dim type As Type = Nothing
			Dim text As String = "Item"
			Dim array As Object() = New Object(0) {}
			Dim num As Integer = 0
			Dim lblHidden As Label = Me.lblHidden
			Dim label As Label = lblHidden
			array(num) = lblHidden.Tag
			Dim array2 As Object() = array
			Dim array3 As String() = Nothing
			Dim array4 As Type() = Nothing
			Dim array5 As Boolean() = New Boolean() { True }
			Dim array6 As Boolean() = array5
			Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
			If array6(0) Then
				label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
			End If
			Dim label2 As Label = CType(obj, Label)
			Dim flag As Boolean = Me.btnBold.CheckState = CheckState.Checked
			If flag Then
				Me.SetBoldItalicUnderline(label2, FontStyle.Bold)
			Else
				Me.SetBoldItalicUnderline(label2, FontStyle.Regular)
			End If
		End Sub

		' Token: 0x060006B9 RID: 1721 RVA: 0x00097EFC File Offset: 0x000960FC
		Private Sub SetBoldItalicUnderline(LabelMe As Label, FS As FontStyle)
			Dim fontStyle As FontStyle = FS
			Dim checked As Boolean = Me.btnBold.Checked
			If checked Then
				fontStyle = FS
				Dim checked2 As Boolean = Me.btnItalic.Checked
				If checked2 Then
					fontStyle = FontStyle.Bold Or FontStyle.Italic
					Dim checked3 As Boolean = Me.btnUnderline.Checked
					If checked3 Then
						fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
					End If
				End If
				Dim checked4 As Boolean = Me.btnUnderline.Checked
				If checked4 Then
					fontStyle = FontStyle.Bold Or FontStyle.Underline
					Dim checked5 As Boolean = Me.btnItalic.Checked
					If checked5 Then
						fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
					End If
				End If
			Else
				Dim checked6 As Boolean = Me.btnItalic.Checked
				If checked6 Then
					fontStyle = FontStyle.Italic
					Dim checked7 As Boolean = Me.btnBold.Checked
					If checked7 Then
						fontStyle = FontStyle.Bold Or FontStyle.Italic
						Dim checked8 As Boolean = Me.btnUnderline.Checked
						If checked8 Then
							fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
						End If
					End If
					Dim checked9 As Boolean = Me.btnUnderline.Checked
					If checked9 Then
						Dim checked10 As Boolean = Me.btnBold.Checked
						If checked10 Then
							fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
						End If
					End If
				Else
					Dim checked11 As Boolean = Me.btnUnderline.Checked
					If checked11 Then
						fontStyle = FontStyle.Underline
						Dim checked12 As Boolean = Me.btnBold.Checked
						If checked12 Then
							fontStyle = FontStyle.Bold Or FontStyle.Underline
							Dim checked13 As Boolean = Me.btnItalic.Checked
							If checked13 Then
								fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
							End If
						End If
						Dim checked14 As Boolean = Me.btnItalic.Checked
						If checked14 Then
							Dim checked15 As Boolean = Me.btnBold.Checked
							If checked15 Then
								fontStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
							End If
						End If
					End If
				End If
			End If
			Dim font As Font = New Font(LabelMe.Font.FontFamily, LabelMe.Font.Size, fontStyle)
			LabelMe.Font = font
		End Sub

		' Token: 0x060006BA RID: 1722 RVA: 0x00098068 File Offset: 0x00096268
		Private Sub frmBarcodeMain_Load(sender As Object, e As EventArgs)
			Me.connString = ModCS.ReadCS()
			Dim chequeLayoutInfo As ChequeLayoutInfo = New ChequeLayoutInfo()
			Try
				For Each obj As Object In Me.pnlCheque.Controls
					Dim control As Control = CType(obj, Control)
					Me.dl.WireControl(control)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.BindLayouts()
			Me.GetFonts()
			Me.SetFontSize()
			Me.Convert_Language()
		End Sub

		' Token: 0x060006BB RID: 1723 RVA: 0x00098104 File Offset: 0x00096304
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

		' Token: 0x060006BC RID: 1724 RVA: 0x000983A4 File Offset: 0x000965A4
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

		' Token: 0x060006BD RID: 1725 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060006BE RID: 1726 RVA: 0x00009EDE File Offset: 0x000080DE
		Private Sub pnlCheque_Click(sender As Object, e As EventArgs)
			Me.clickLocation = New Point(CType(e, MouseEventArgs).X, CType(e, MouseEventArgs).Y)
		End Sub

		' Token: 0x060006BF RID: 1727 RVA: 0x00009F02 File Offset: 0x00008102
		Private Sub pnlCheque_MouseClick(sender As Object, e As MouseEventArgs)
			Me.clickLocation = New Point(e.X, e.Y)
			Me.createDot(e.X, e.Y)
		End Sub

		' Token: 0x060006C0 RID: 1728 RVA: 0x00098460 File Offset: 0x00096660
		Private Sub createDot(x As Integer, y As Integer)
			Dim graphics As Graphics = Me.pnlCheque.CreateGraphics()
			Dim pen As Pen = New Pen(Color.Orange, 4F)
			graphics.DrawRectangle(pen, x, y, 4, 4)
		End Sub

		' Token: 0x060006C1 RID: 1729 RVA: 0x00098498 File Offset: 0x00096698
		Public Sub BindLayouts()
			Dim text As String = "Select distinct layout_name,layout_id from tbl_layout order by 1"
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "layouts")
				Dim dataTable As DataTable = dataSet.Tables("layouts")
				Dim dataRow As DataRow = dataTable.NewRow()
				dataRow(0) = "Select"
				dataTable.Rows.InsertAt(dataRow, 0)
				Me.cmbLayouts.DataSource = dataTable
				Me.cmbLayouts.DisplayMember = "layout_name"
				Me.cmbLayouts.ValueMember = "layout_id"
				Me.cmbLayouts.SelectedIndex = 0
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x060006C2 RID: 1730 RVA: 0x000985A4 File Offset: 0x000967A4
		Private Sub cmbFonts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				Dim fontStyle As FontStyle
				Dim font As Font = New Font(Me.cmbFonts.Text, label2.Font.Size, fontStyle)
				label2.Font = font
			End If
		End Sub

		' Token: 0x060006C3 RID: 1731 RVA: 0x00098654 File Offset: 0x00096854
		Private Sub cmbFontSize_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
				If flag Then
					Dim controls As Object = Me.pnlCheque.Controls
					Dim type As Type = Nothing
					Dim text As String = "Item"
					Dim array As Object() = New Object(0) {}
					Dim num As Integer = 0
					Dim lblHidden As Label = Me.lblHidden
					Dim label As Label = lblHidden
					array(num) = lblHidden.Tag
					Dim array2 As Object() = array
					Dim array3 As String() = Nothing
					Dim array4 As Type() = Nothing
					Dim array5 As Boolean() = New Boolean() { True }
					Dim array6 As Boolean() = array5
					Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
					If array6(0) Then
						label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
					End If
					Dim label2 As Label = CType(obj, Label)
					Dim fontStyle As FontStyle
					Dim font As Font = New Font(label2.Font.FontFamily, CSng(Convert.ToInt16(Me.cmbFontSize.Text)), fontStyle)
					label2.Font = font
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006C4 RID: 1732 RVA: 0x0009872C File Offset: 0x0009692C
		Private Sub btnItalic_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.pnlCheque.Controls
			Dim type As Type = Nothing
			Dim text As String = "Item"
			Dim array As Object() = New Object(0) {}
			Dim num As Integer = 0
			Dim lblHidden As Label = Me.lblHidden
			Dim label As Label = lblHidden
			array(num) = lblHidden.Tag
			Dim array2 As Object() = array
			Dim array3 As String() = Nothing
			Dim array4 As Type() = Nothing
			Dim array5 As Boolean() = New Boolean() { True }
			Dim array6 As Boolean() = array5
			Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
			If array6(0) Then
				label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
			End If
			Dim label2 As Label = CType(obj, Label)
			Me.SetBoldItalicUnderline(label2, FontStyle.Italic)
		End Sub

		' Token: 0x060006C5 RID: 1733 RVA: 0x000987A0 File Offset: 0x000969A0
		Private Sub btnUnderline_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.pnlCheque.Controls
			Dim type As Type = Nothing
			Dim text As String = "Item"
			Dim array As Object() = New Object(0) {}
			Dim num As Integer = 0
			Dim lblHidden As Label = Me.lblHidden
			Dim label As Label = lblHidden
			array(num) = lblHidden.Tag
			Dim array2 As Object() = array
			Dim array3 As String() = Nothing
			Dim array4 As Type() = Nothing
			Dim array5 As Boolean() = New Boolean() { True }
			Dim array6 As Boolean() = array5
			Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
			If array6(0) Then
				label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
			End If
			Dim label2 As Label = CType(obj, Label)
			Me.SetBoldItalicUnderline(label2, FontStyle.Underline)
		End Sub

		' Token: 0x060006C6 RID: 1734 RVA: 0x00098814 File Offset: 0x00096A14
		Private Sub btnColor_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				Dim colorDialog As ColorDialog = New ColorDialog()
				Dim flag2 As Boolean = colorDialog.ShowDialog() = DialogResult.OK
				If flag2 Then
					label2.ForeColor = colorDialog.Color
				End If
			End If
		End Sub

		' Token: 0x060006C7 RID: 1735 RVA: 0x000988C0 File Offset: 0x00096AC0
		Private Sub ToolStripCmbFonts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				Dim fontStyle As FontStyle
				Dim font As Font = New Font(Me.ToolStripCmbFonts.Text, label2.Font.Size, fontStyle)
				label2.Font = font
			End If
		End Sub

		' Token: 0x060006C8 RID: 1736 RVA: 0x00098970 File Offset: 0x00096B70
		Private Sub BoldToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold)
		End Sub

		' Token: 0x060006C9 RID: 1737 RVA: 0x000989AC File Offset: 0x00096BAC
		Private Sub ItalicToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Italic)
		End Sub

		' Token: 0x060006CA RID: 1738 RVA: 0x000989E8 File Offset: 0x00096BE8
		Private Sub BoldItalicToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic)
		End Sub

		' Token: 0x060006CB RID: 1739 RVA: 0x00098A24 File Offset: 0x00096C24
		Private Sub RegularToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Regular)
		End Sub

		' Token: 0x060006CC RID: 1740 RVA: 0x00098A60 File Offset: 0x00096C60
		Private Sub UnderlineToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Underline)
		End Sub

		' Token: 0x060006CD RID: 1741 RVA: 0x00098A9C File Offset: 0x00096C9C
		Private Sub BoldUnderlineToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Underline)
		End Sub

		' Token: 0x060006CE RID: 1742 RVA: 0x00098AD8 File Offset: 0x00096CD8
		Private Sub LeftToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			label.TextAlign = ContentAlignment.MiddleLeft
		End Sub

		' Token: 0x060006CF RID: 1743 RVA: 0x00098B14 File Offset: 0x00096D14
		Private Sub CenterToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			label.TextAlign = ContentAlignment.MiddleCenter
		End Sub

		' Token: 0x060006D0 RID: 1744 RVA: 0x00098B50 File Offset: 0x00096D50
		Private Sub RightToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			label.TextAlign = ContentAlignment.MiddleRight
		End Sub

		' Token: 0x060006D1 RID: 1745 RVA: 0x00098B8C File Offset: 0x00096D8C
		Private Sub JustifyToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
		End Sub

		' Token: 0x060006D2 RID: 1746 RVA: 0x00098BBC File Offset: 0x00096DBC
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Select Case Me.ComboBox3.SelectedIndex
				Case 0
					Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
					If flag Then
						Dim controls As Object = Me.pnlCheque.Controls
						Dim type As Type = Nothing
						Dim text As String = "Item"
						Dim array As Object() = New Object(0) {}
						Dim num As Integer = 0
						Dim lblHidden As Label = Me.lblHidden
						Dim label As Label = lblHidden
						array(num) = lblHidden.Tag
						Dim array2 As Object() = array
						Dim array3 As String() = Nothing
						Dim array4 As Type() = Nothing
						Dim array5 As Boolean() = New Boolean() { True }
						Dim array6 As Boolean() = array5
						Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
						If array6(0) Then
							label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
						End If
						Dim label2 As Label = CType(obj, Label)
						label2.TextAlign = ContentAlignment.MiddleLeft
					End If
				Case 1
					Dim flag2 As Boolean = Me.lblHidden.Tag IsNot Nothing
					If flag2 Then
						Dim controls2 As Object = Me.pnlCheque.Controls
						Dim type2 As Type = Nothing
						Dim text2 As String = "Item"
						Dim array7 As Object() = New Object(0) {}
						Dim num2 As Integer = 0
						Dim lblHidden2 As Label = Me.lblHidden
						Dim label As Label = lblHidden2
						array7(num2) = lblHidden2.Tag
						Dim array2 As Object() = array7
						Dim array8 As String() = Nothing
						Dim array9 As Type() = Nothing
						Dim array10 As Boolean() = New Boolean() { True }
						Dim array6 As Boolean() = array10
						Dim obj2 As Object = NewLateBinding.LateGet(controls2, type2, text2, array7, array8, array9, array10)
						If array6(0) Then
							label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
						End If
						Dim label3 As Label = CType(obj2, Label)
						label3.TextAlign = ContentAlignment.MiddleRight
					End If
				Case 2
					Dim flag3 As Boolean = Me.lblHidden.Tag IsNot Nothing
					If flag3 Then
						Dim controls3 As Object = Me.pnlCheque.Controls
						Dim type3 As Type = Nothing
						Dim text3 As String = "Item"
						Dim array11 As Object() = New Object(0) {}
						Dim num3 As Integer = 0
						Dim lblHidden3 As Label = Me.lblHidden
						Dim label As Label = lblHidden3
						array11(num3) = lblHidden3.Tag
						Dim array2 As Object() = array11
						Dim array12 As String() = Nothing
						Dim array13 As Type() = Nothing
						Dim array14 As Boolean() = New Boolean() { True }
						Dim array6 As Boolean() = array14
						Dim obj3 As Object = NewLateBinding.LateGet(controls3, type3, text3, array11, array12, array13, array14)
						If array6(0) Then
							label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
						End If
						Dim label4 As Label = CType(obj3, Label)
						label4.TextAlign = ContentAlignment.MiddleCenter
					End If
			End Select
		End Sub

		' Token: 0x060006D3 RID: 1747 RVA: 0x00098D84 File Offset: 0x00096F84
		Private Sub rulerCtrlLeft_HooverValue(sender As Object, e As RulerControl.HooverValueEventArgs)
			Try
				Me.lblDiamensionY.Text = e.Value.ToString("0.0")
			Catch ex As Exception
				MessageBox.Show("CH:23" + ex.Message)
			End Try
		End Sub

		' Token: 0x060006D4 RID: 1748 RVA: 0x00098DE8 File Offset: 0x00096FE8
		Private Sub rulerCtrlTop_HooverValue(sender As Object, e As RulerControl.HooverValueEventArgs)
			Try
				Me.lblDiamensionX.Text = e.Value.ToString("0.0")
			Catch ex As Exception
				MessageBox.Show("CH:22" + ex.Message)
			End Try
		End Sub

		' Token: 0x060006D5 RID: 1749 RVA: 0x00098E4C File Offset: 0x0009704C
		Private Sub cbxPCode_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxPCode.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxPCode.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxPCode.Checked
					If checked Then
						Me.lblCreatePcode()
						Me.FixedLabels(Me.cbxPCode, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006D6 RID: 1750 RVA: 0x00098EFC File Offset: 0x000970FC
		Public Sub FixedLabels(cmb As CheckBox, lbl As Label)
			lbl = CType(Me.pnlCheque.Controls(cmb.Text), Label)
			Dim flag As Boolean = lbl IsNot Nothing
			If flag Then
				Dim flag2 As Boolean = Not cmb.Checked
				If flag2 Then
					lbl.Visible = False
				Else
					lbl.Visible = True
				End If
			End If
		End Sub

		' Token: 0x060006D7 RID: 1751 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cbxPCode_ChangeUICues(sender As Object, e As UICuesEventArgs)
		End Sub

		' Token: 0x060006D8 RID: 1752 RVA: 0x00098F54 File Offset: 0x00097154
		Private Sub cbxProductName_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxProductName.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxProductName.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxProductName.Checked
					If checked Then
						Me.lblCreateProductName()
						Me.FixedLabels(Me.cbxProductName, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006D9 RID: 1753 RVA: 0x00099004 File Offset: 0x00097204
		Private Sub cbxCategory_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxCategory.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxCategory.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxCategory.Checked
					If checked Then
						Me.lblCreateCategory()
						Me.FixedLabels(Me.cbxCategory, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DA RID: 1754 RVA: 0x000990B4 File Offset: 0x000972B4
		Private Sub cbxBarcode_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxBarcode.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxBarcode.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxBarcode.Checked
					If checked Then
						Me.lblCreateBarcode()
						Me.FixedLabels(Me.cbxBarcode, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DB RID: 1755 RVA: 0x00099164 File Offset: 0x00097364
		Private Sub cbxAvlQty_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxAvlQty.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxAvlQty.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxAvlQty.Checked
					If checked Then
						Me.lblCreateAvlQty()
						Me.FixedLabels(Me.cbxAvlQty, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DC RID: 1756 RVA: 0x00099214 File Offset: 0x00097414
		Private Sub cbxNoCopy_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxNoCopy.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxNoCopy.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxNoCopy.Checked
					If checked Then
						Me.lblCreateNoCopy()
						Me.FixedLabels(Me.cbxNoCopy, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DD RID: 1757 RVA: 0x000992C4 File Offset: 0x000974C4
		Private Sub cbxPartNo_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxPartNo.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxPartNo.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxPartNo.Checked
					If checked Then
						Me.lblCreatePartNo()
						Me.FixedLabels(Me.cbxPartNo, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DE RID: 1758 RVA: 0x00099374 File Offset: 0x00097574
		Private Sub cbxHSNC_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxHSNC.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxHSNC.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxHSNC.Checked
					If checked Then
						Me.lblCreateHSNC()
						Me.FixedLabels(Me.cbxHSNC, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006DF RID: 1759 RVA: 0x00099424 File Offset: 0x00097624
		Private Sub cbxMRP_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxMRP.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxMRP.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxMRP.Checked
					If checked Then
						Me.lblCreateMRP()
						Me.FixedLabels(Me.cbxMRP, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E0 RID: 1760 RVA: 0x000994D4 File Offset: 0x000976D4
		Private Sub cbxSalePrice_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxSalePrice.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxSalePrice.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxSalePrice.Checked
					If checked Then
						Me.lblCreateSalePrice()
						Me.FixedLabels(Me.cbxSalePrice, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E1 RID: 1761 RVA: 0x00099584 File Offset: 0x00097784
		Private Sub cbxWholesalePrice_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxWholesalePrice.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxWholesalePrice.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxWholesalePrice.Checked
					If checked Then
						Me.lblCreateWholesalePrice()
						Me.FixedLabels(Me.cbxWholesalePrice, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E2 RID: 1762 RVA: 0x00099634 File Offset: 0x00097834
		Private Sub cbxBatch_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxBatch.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxBatch.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxBatch.Checked
					If checked Then
						Me.lblCreateBatch()
						Me.FixedLabels(Me.cbxBatch, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E3 RID: 1763 RVA: 0x000996E4 File Offset: 0x000978E4
		Private Sub cbxMfg_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxMfg.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxMfg.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxMfg.Checked
					If checked Then
						Me.lblCreateMfg()
						Me.FixedLabels(Me.cbxMfg, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E4 RID: 1764 RVA: 0x00099794 File Offset: 0x00097994
		Private Sub cbxExp_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxExp.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxExp.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxExp.Checked
					If checked Then
						Me.lblCreateExp()
						Me.FixedLabels(Me.cbxExp, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E5 RID: 1765 RVA: 0x00099844 File Offset: 0x00097A44
		Private Sub cbxSize_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxSize.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxSize.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxSize.Checked
					If checked Then
						Me.lblCreateSize()
						Me.FixedLabels(Me.cbxSize, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E6 RID: 1766 RVA: 0x000998F4 File Offset: 0x00097AF4
		Private Sub cbxColour_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxColour.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxColour.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxColour.Checked
					If checked Then
						Me.lblCreateColour()
						Me.FixedLabels(Me.cbxColour, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E7 RID: 1767 RVA: 0x000999A4 File Offset: 0x00097BA4
		Private Sub cbxGST_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxGST.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxGST.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxGST.Checked
					If checked Then
						Me.lblCreateGST()
						Me.FixedLabels(Me.cbxGST, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E8 RID: 1768 RVA: 0x00099A54 File Offset: 0x00097C54
		Private Sub cbxPurInv_CheckedChanged(sender As Object, e As EventArgs)
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxPurInv.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxPurInv.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxPurInv.Checked
					If checked Then
						Me.lblCreatePurInv()
						Me.FixedLabels(Me.cbxPurInv, label)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006E9 RID: 1769 RVA: 0x00099B04 File Offset: 0x00097D04
		Private Function cbxQrBarcode_CheckedChanged(sender As Object, e As EventArgs) As Object
			Dim obj As Object
			Try
				Dim label As Label = CType(Me.pnlCheque.Controls(Me.cbxQrBarcode.Text), Label)
				Dim flag As Boolean = label IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = Not Me.cbxQrBarcode.Checked
					If flag2 Then
						label.Visible = False
					Else
						label.Visible = True
					End If
				Else
					Dim checked As Boolean = Me.cbxQrBarcode.Checked
					If checked Then
						Dim flag3 As Boolean = Conversions.ToBoolean(Me.CreateLabelOnLocation())
						If flag3 Then
							Me.lblCreateQrBarcode()
							Me.pbQrBarCode.Visible = True
							Me.clickLocation.X = 0
							Me.clickLocation.Y = 0
						Else
							Me.cbxQrBarcode.Checked = False
							obj = False
						End If
					Else
						Dim flag4 As Boolean = Not Me.cbxQrBarcode.Checked
						If flag4 Then
							Me.pbQrBarCode.Visible = False
						Else
							Me.pbQrBarCode.Visible = True
						End If
					End If
				End If
			Catch ex As Exception
			End Try
			Return obj
		End Function

		' Token: 0x060006EA RID: 1770 RVA: 0x00099C34 File Offset: 0x00097E34
		Private Sub pnlCheque_MouseDown(sender As Object, e As MouseEventArgs)
			Try
				Me.ctrlPanel = TryCast(sender, Control)
				Me.dl.WireControl(Me.ctrlPanel)
			Catch ex As Exception
				MessageBox.Show("CH:36" + ex.Message)
			End Try
		End Sub

		' Token: 0x060006EB RID: 1771 RVA: 0x00097C04 File Offset: 0x00095E04
		Private Sub pnlCheque_Resize_1(sender As Object, e As EventArgs)
			Try
				Me.nudChequeLeafWidth.Value = Decimal.Divide(New Decimal(Me.pnlCheque.Width), 38D)
				Me.nudChequeHeight.Value = Decimal.Divide(New Decimal(Me.pnlCheque.Height), 38D)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006EC RID: 1772 RVA: 0x00099C9C File Offset: 0x00097E9C
		Private Sub SaveLayout()
			Dim text As String = "INSERT INTO tbl_layout ([layout_name]" & vbCrLf & "           ,[layout_width]" & vbCrLf & "           ,[layout_height]" & vbCrLf & "           ,[layout_bg_color]" & vbCrLf & "           ,[layout_bg_color_status]) " & vbCrLf & "VALUES(@layout_name, @layout_width,@layout_height,@layout_bg_color,@layout_bg_color_status)"
			text += " SELECT SCOPE_IDENTITY()"
			Dim num As Integer
			Using sqlConnection As SqlConnection = New SqlConnection(Me.connString)
				Using sqlCommand As SqlCommand = New SqlCommand(text)
					sqlCommand.Parameters.AddWithValue("@layout_name", Me.txtLayoutName.Text)
					sqlCommand.Parameters.AddWithValue("@layout_width", Decimal.Divide(Math.Truncate(Decimal.Multiply(Me.nudChequeLeafWidth.Value, 100D)), 100D))
					sqlCommand.Parameters.AddWithValue("@layout_height", Decimal.Divide(Math.Truncate(Decimal.Multiply(Me.nudChequeHeight.Value, 100D)), 100D))
					sqlCommand.Parameters.AddWithValue("@layout_bg_color", Me.pnlCheque.BackColor.ToArgb().ToString())
					sqlCommand.Parameters.AddWithValue("@layout_bg_color_status", "true")
					sqlCommand.Connection = sqlConnection
					sqlConnection.Open()
					num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
					sqlConnection.Close()
				End Using
			End Using
			Me.SaveLayoutLabel(num)
		End Sub

		' Token: 0x060006ED RID: 1773 RVA: 0x00099E30 File Offset: 0x00098030
		Private Sub UpdateLayout()
			Dim text As String = "update tbl_layout set [layout_name] = @layout_name" & vbCrLf & "           ,[layout_width] = @layout_width" & vbCrLf & "           ,[layout_height] = @layout_height" & vbCrLf & "           ,[layout_bg_color] = @layout_bg_color" & vbCrLf & "           ,[layout_bg_color_status]  = @layout_bg_color_status where layout_id='" + Me.cmbLayouts.SelectedValue.ToString() + "'"
			Using sqlConnection As SqlConnection = New SqlConnection(Me.connString)
				Using sqlCommand As SqlCommand = New SqlCommand(text)
					sqlCommand.Parameters.AddWithValue("@layout_name", Me.txtLayoutName.Text)
					sqlCommand.Parameters.AddWithValue("@layout_width", Decimal.Divide(Math.Truncate(Decimal.Multiply(Me.nudChequeLeafWidth.Value, 100D)), 100D))
					sqlCommand.Parameters.AddWithValue("@layout_height", Decimal.Divide(Math.Truncate(Decimal.Multiply(Me.nudChequeHeight.Value, 100D)), 100D))
					sqlCommand.Parameters.AddWithValue("@layout_bg_color", Me.pnlCheque.BackColor.ToArgb().ToString())
					sqlCommand.Parameters.AddWithValue("@layout_bg_color_status", "true")
					sqlCommand.Connection = sqlConnection
					sqlConnection.Open()
					sqlCommand.ExecuteNonQuery()
					sqlConnection.Close()
				End Using
			End Using
			Dim flag As Boolean = Me.cmbLayouts.SelectedIndex <> 0
			If flag Then
				Me.DelLayoutLabels(Conversions.ToInteger(Me.cmbLayouts.SelectedValue.ToString()))
			End If
		End Sub

		' Token: 0x060006EE RID: 1774 RVA: 0x00099FF4 File Offset: 0x000981F4
		Private Sub DelLayoutLabels(layoutId As Integer)
			Dim text As String = "delete from tbl_layout_label where layout_id= @layout_id"
			Using sqlConnection As SqlConnection = New SqlConnection(Me.connString)
				Using sqlCommand As SqlCommand = New SqlCommand(text)
					sqlCommand.Parameters.AddWithValue("@layout_id", Me.cmbLayouts.SelectedValue.ToString())
					sqlCommand.Connection = sqlConnection
					sqlConnection.Open()
					sqlCommand.ExecuteNonQuery()
					sqlConnection.Close()
				End Using
			End Using
			Me.SaveLayoutLabel(layoutId)
		End Sub

		' Token: 0x060006EF RID: 1775 RVA: 0x0009A09C File Offset: 0x0009829C
		Private Sub SaveLayoutLabel(layoutId As Integer)
			Try
				For Each label As Label In Me.pnlCheque.Controls.OfType(Of Label)()
					Dim text As String = "0"
					Dim flag As Boolean = (Operators.CompareString(label.Text.ToString(), "", False) <> 0) And label.Visible
					If flag Then
						Dim text2 As String = "INSERT INTO tbl_layout_label (" & vbCrLf & "            [layout_id]" & vbCrLf & "           ,[label_name]" & vbCrLf & "           ,[label_width]" & vbCrLf & "           ,[label_height]" & vbCrLf & "           ,[label_X]" & vbCrLf & "           ,[label_Y]" & vbCrLf & "           ,[label_font_name]" & vbCrLf & "           ,[label_font_size]" & vbCrLf & "           ,lbl_font_style" & vbCrLf & "           ,[label_text_color]" & vbCrLf & "           ,[label_text]" & vbCrLf & "           ,[label_is_fixed]) " & vbCrLf & "        VALUES(" & vbCrLf & "        @layout_id " & vbCrLf & "        ,@label_name" & vbCrLf & "           ,@label_width" & vbCrLf & "           ,@label_height" & vbCrLf & "           ,@label_X" & vbCrLf & "           ,@label_Y" & vbCrLf & "           ,@label_font_name" & vbCrLf & "           ,@label_font_size" & vbCrLf & "           ,@lbl_font_style" & vbCrLf & "           " & vbCrLf & "           ,@label_text_color" & vbCrLf & "           ,@label_text" & vbCrLf & "           ,@label_is_fixed)"
						text2 += " SELECT SCOPE_IDENTITY()"
						Using sqlConnection As SqlConnection = New SqlConnection(Me.connString)
							Using sqlCommand As SqlCommand = New SqlCommand(text2)
								sqlCommand.Parameters.AddWithValue("@layout_id", layoutId)
								sqlCommand.Parameters.AddWithValue("@label_name", label.Name)
								sqlCommand.Parameters.AddWithValue("@label_width", label.Width)
								sqlCommand.Parameters.AddWithValue("@label_height", label.Height)
								sqlCommand.Parameters.AddWithValue("@label_X", label.Location.X)
								sqlCommand.Parameters.AddWithValue("@label_Y", label.Location.Y)
								sqlCommand.Parameters.AddWithValue("@label_font_name", label.Font.Name)
								sqlCommand.Parameters.AddWithValue("@label_font_size", label.Font.Size)
								sqlCommand.Parameters.AddWithValue("@lbl_font_style", label.Font.Style.ToString())
								sqlCommand.Parameters.AddWithValue("@label_is_strikeout", text)
								sqlCommand.Parameters.AddWithValue("@label_text_color", label.ForeColor.ToArgb().ToString())
								sqlCommand.Parameters.AddWithValue("@label_text", label.Text)
								sqlCommand.Parameters.AddWithValue("@label_is_fixed", "false")
								sqlCommand.Connection = sqlConnection
								sqlConnection.Open()
								Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
								sqlConnection.Close()
							End Using
						End Using
					End If
				Next
			Finally
				Dim enumerator As IEnumerator(Of Label)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
			Try
				For Each pictureBox As PictureBox In Me.pnlCheque.Controls.OfType(Of PictureBox)()
					Dim flag2 As Boolean = Operators.CompareString(pictureBox.Name, "pbQrBarCode", False) = 0
					Dim text3 As String
					If flag2 Then
						text3 = "QrBarcode"
					Else
						text3 = pictureBox.Name
					End If
					Dim text4 As String = "INSERT INTO tbl_layout_label (" & vbCrLf & vbCrLf & "            [layout_id]" & vbCrLf & "           ,[label_name]" & vbCrLf & "           ,[label_text] " & vbCrLf & "           ,[label_width]" & vbCrLf & "           ,[label_height]" & vbCrLf & "           ,[label_X]" & vbCrLf & "           ,[label_Y]" & vbCrLf & "           ,[image] " & vbCrLf & "           ) " & vbCrLf & "        VALUES(" & vbCrLf & "        @layout_id" & vbCrLf & "        ,@label_name" & vbCrLf & "        ,@label_text " & vbCrLf & "           ,@label_width" & vbCrLf & "           ,@label_height" & vbCrLf & "           ,@label_X" & vbCrLf & "           ,@label_Y" & vbCrLf & "            ,@image" & vbCrLf & "        )"
					text4 += " SELECT SCOPE_IDENTITY()"
					Using sqlConnection2 As SqlConnection = New SqlConnection(Me.connString)
						Using sqlCommand2 As SqlCommand = New SqlCommand(text4)
							sqlCommand2.Parameters.AddWithValue("@layout_id", layoutId)
							sqlCommand2.Parameters.AddWithValue("@label_name", text3)
							sqlCommand2.Parameters.AddWithValue("@label_text", text3)
							sqlCommand2.Parameters.AddWithValue("@label_width", pictureBox.Width)
							sqlCommand2.Parameters.AddWithValue("@label_height", pictureBox.Height)
							sqlCommand2.Parameters.AddWithValue("@label_X", pictureBox.Location.X)
							sqlCommand2.Parameters.AddWithValue("@label_Y", pictureBox.Location.Y)
							sqlCommand2.Parameters.AddWithValue("@image", frmBarcodeMain.ImgToByteArray(pictureBox.Image, ImageFormat.Png))
							sqlCommand2.Connection = sqlConnection2
							sqlConnection2.Open()
							Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar()))
							sqlConnection2.Close()
						End Using
					End Using
				Next
			Finally
				Dim enumerator2 As IEnumerator(Of PictureBox)
				If enumerator2 IsNot Nothing Then
					enumerator2.Dispose()
				End If
			End Try
			Me.BindLayouts()
			MessageBox.Show("Layout Saved with Layout ID: " + Conversions.ToString(layoutId))
		End Sub

		' Token: 0x060006F0 RID: 1776 RVA: 0x0009A5C8 File Offset: 0x000987C8
		Public Shared Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
			Dim array As Byte()
			Using memoryStream As MemoryStream = New MemoryStream()
				img.Save(memoryStream, imgFormat)
				array = memoryStream.ToArray()
			End Using
			Return array
		End Function

		' Token: 0x060006F1 RID: 1777 RVA: 0x0009A610 File Offset: 0x00098810
		Private Sub btnBgColor_Layout_Click(sender As Object, e As EventArgs)
			Dim colorDialog As ColorDialog = New ColorDialog()
			Dim flag As Boolean = colorDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.pnlCheque.BackColor = colorDialog.Color
			End If
		End Sub

		' Token: 0x060006F2 RID: 1778 RVA: 0x0009A648 File Offset: 0x00098848
		Private Sub RevertControlSizes()
			Try
				For Each keyValuePair As KeyValuePair(Of Control, Size) In Me.originalSizes
					Dim key As Control = keyValuePair.Key
					Dim value As Size = keyValuePair.Value
					key.Size = value
					Dim flag As Boolean = key.Font IsNot Nothing
					If flag Then
						key.Font = New Font(key.Font.FontFamily, key.Font.Size / 2F)
					End If
				Next
			Finally
				Dim enumerator As Dictionary(Of Control, Size).Enumerator
				CType(enumerator, IDisposable).Dispose()
			End Try
			Me.originalSizes.Clear()
		End Sub

		' Token: 0x060006F3 RID: 1779 RVA: 0x0009A6F8 File Offset: 0x000988F8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtLayoutName.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Enter layout name to save layout")
			Else
				Try
					For Each label As Label In Me.pnlCheque.Controls.OfType(Of Label)()
						Dim flag2 As Boolean = (Operators.CompareString(label.Text, "Barcode", False) = 0) And label.Visible
						If flag2 Then
							Me.counter += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator(Of Label)
					If enumerator IsNot Nothing Then
						enumerator.Dispose()
					End If
				End Try
				Try
					For Each pictureBox As PictureBox In Me.pnlCheque.Controls.OfType(Of PictureBox)()
						Dim flag3 As Boolean = (Operators.CompareString(pictureBox.Name, "pbQrBarCode", False) = 0) Or (Operators.CompareString(pictureBox.Name, "QrBarcode", False) = 0)
						If flag3 Then
							Me.counter_qrcode += 1
						End If
					Next
				Finally
					Dim enumerator2 As IEnumerator(Of PictureBox)
					If enumerator2 IsNot Nothing Then
						enumerator2.Dispose()
					End If
				End Try
				Dim flag4 As Boolean = (Me.counter > 0) Or (Me.counter_qrcode > 0)
				If flag4 Then
					Dim flag5 As Boolean = Operators.CompareString(Me.btnSave.Text, "Save", False) = 0
					If flag5 Then
						Me.SaveLayout()
					Else
						Me.UpdateLayout()
					End If
				Else
					MessageBox.Show("Layout must contain Barcode label before saving layout")
				End If
			End If
		End Sub

		' Token: 0x060006F4 RID: 1780 RVA: 0x0009A898 File Offset: 0x00098A98
		Private Sub cmbLayouts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbLayouts.SelectedIndex <> 0
			If flag Then
				Me.pnlCheque.Visible = False
				Me.pnlCheque.Controls.Clear()
				Me.pnlCheque.Visible = True
				Thread.Sleep(500)
				Me.btnSave.Text = "Update"
				Me.LoadSelectedLayout(Me.cmbLayouts.SelectedValue.ToString())
			End If
		End Sub

		' Token: 0x060006F5 RID: 1781 RVA: 0x0009A918 File Offset: 0x00098B18
		Private Sub LoadSelectedLayout(selectedValue As Object)
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select * from tbl_layout where layout_id='", selectedValue), "'"))
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "layouts_detail")
				Me.txtLayoutName.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_name").ToString()
				Me.nudChequeLeafWidth.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_width").ToString()
				Me.nudChequeHeight.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_height").ToString()
				Me.pnlCheque.BackColor = Color.FromArgb(CInt(Convert.ToInt64(dataSet.Tables("layouts_detail").Rows(0)("layout_bg_color").ToString())))
				Me.LoadSelectedLayoutLabels(dataSet.Tables("layouts_detail").Rows(0)("layout_id").ToString())
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x060006F6 RID: 1782 RVA: 0x0008EC1C File Offset: 0x0008CE1C
		Public Function ConvertToRbg(HexColor As String) As Color
			HexColor = Strings.Replace(HexColor, "#", "", 1, -1, CompareMethod.Binary)
			Dim text As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 1, 2)))
			Dim text2 As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 3, 2)))
			Dim text3 As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 5, 2)))
			Return Color.FromArgb(Conversions.ToInteger(text), Conversions.ToInteger(text2), Conversions.ToInteger(text3))
		End Function

		' Token: 0x060006F7 RID: 1783 RVA: 0x0009AAF0 File Offset: 0x00098CF0
		Private Sub LoadSelectedLayoutLabels(selectedValue As Object)
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select * from tbl_layout_label  where layout_id='", selectedValue), "'"))
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Dim dataSet As DataSet = New DataSet()
				Me.ds_labels.Clear()
				Me.number = 1
				Me.numberPb = 1
				sqlDataAdapter.Fill(Me.ds_labels, "layout_labels")
				Me.dgvLabels.DataSource = Me.ds_labels.Tables("layout_labels")
				Dim num As Integer = Me.ds_labels.Tables("layout_labels").Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("image").ToString(), "", False) = 0
					If flag Then
						Dim label As Label = New Label()
						label.Name = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString()
						label.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
						label.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
						Dim fontConverter As FontConverter = New FontConverter()
						Dim text2 As String = Me.ds_labels.Tables("layout_labels").Rows(i)("lbl_font_style").ToString()
						If Operators.CompareString(text2, "Bold", False) <> 0 Then
							If Operators.CompareString(text2, "Italic", False) <> 0 Then
								If Operators.CompareString(text2, "Underline", False) <> 0 Then
									If Operators.CompareString(text2, "Bold, Italic, Underline", False) <> 0 Then
										If Operators.CompareString(text2, "Bold, Underline ", False) <> 0 Then
											If Operators.CompareString(text2, "Italic, Underline ", False) <> 0 Then
												text2 = Conversions.ToString(0)
											Else
												text2 = Conversions.ToString(6)
											End If
										Else
											text2 = Conversions.ToString(5)
										End If
									Else
										text2 = Conversions.ToString(7)
									End If
								Else
									text2 = Conversions.ToString(4)
								End If
							Else
								text2 = Conversions.ToString(2)
							End If
						Else
							text2 = Conversions.ToString(1)
						End If
						label.Font = New Font(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_name").ToString(), Conversions.ToSingle(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_size").ToString()), CType(Conversions.ToInteger(text2), FontStyle), GraphicsUnit.Point, 0)
						label.ForeColor = Color.FromArgb(CInt(Convert.ToInt64(Me.ds_labels.Tables("layout_labels").Rows(i)("label_text_color").ToString())))
						label.Text = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
						label.SendToBack()
						label.AutoSize = False
						label.ContextMenuStrip = Me.ContextMenuStrip1
						Me.pnlCheque.Controls.Add(label)
						Me.number += 1
						Me.lblHidden.Tag = label.Name
						AddHandler label.Click, AddressOf Me.lb_Click
						AddHandler label.Resize, AddressOf Me.lb_Resize
						AddHandler label.DoubleClick, AddressOf Me.lb_DoubleClick
						Try
							For Each obj As Object In Me.pnlCheque.Controls
								Dim control As Control = CType(obj, Control)
								Me.dl.WireControl(control)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					Else
						Dim pictureBox As PictureBox = New PictureBox()
						pictureBox.Name = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString()
						pictureBox.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
						pictureBox.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
						Dim array As Byte() = CType(Me.ds_labels.Tables("layout_labels").Rows(i)("image"), Byte())
						pictureBox.Image = Image.FromStream(New MemoryStream(array))
						pictureBox.SendToBack()
						pictureBox.SizeMode = PictureBoxSizeMode.Zoom
						Me.pnlCheque.Controls.Add(pictureBox)
						Me.numberPb += 1
						Me.lblHiddenImage.Tag = pictureBox.Name
						AddHandler pictureBox.Click, AddressOf Me.pb_Click
						AddHandler pictureBox.Resize, AddressOf Me.pb_Resize
						Try
							For Each obj2 As Object In Me.pnlCheque.Controls
								Dim control2 As Control = CType(obj2, Control)
								Me.dl.WireControl(control2)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End If
				Next
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x060006F8 RID: 1784 RVA: 0x0009B2D4 File Offset: 0x000994D4
		Private Sub nudWidth_ValueChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Width = Convert.ToInt32(Me.nudWidth.Value)
			End If
		End Sub

		' Token: 0x060006F9 RID: 1785 RVA: 0x0009B36C File Offset: 0x0009956C
		Private Sub nudHeight_ValueChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Height = Convert.ToInt32(Me.nudHeight.Value)
			End If
		End Sub

		' Token: 0x060006FA RID: 1786 RVA: 0x0009B404 File Offset: 0x00099604
		Private Sub nudTop_ValueChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Top = Convert.ToInt32(Me.nudTop.Value)
			End If
		End Sub

		' Token: 0x060006FB RID: 1787 RVA: 0x0009B49C File Offset: 0x0009969C
		Private Sub nudLeft_ValueChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Left = Convert.ToInt32(Me.nudLeft.Value)
			End If
		End Sub

		' Token: 0x060006FC RID: 1788 RVA: 0x00009F2F File Offset: 0x0000812F
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.ResetForm()
		End Sub

		' Token: 0x060006FD RID: 1789 RVA: 0x0009B534 File Offset: 0x00099734
		Private Sub ResetForm()
			Me.cmbLayouts.SelectedIndex = 0
			Me.txtLayoutName.Text = ""
			Me.btnSave.Text = "Save"
			Me.pnlCheque.BackColor = Color.White
			Me.pnlCheque.Visible = False
			Me.pnlCheque.Controls.Clear()
			Me.pnlCheque.Visible = True
		End Sub

		' Token: 0x060006FE RID: 1790 RVA: 0x0009B5B0 File Offset: 0x000997B0
		Private Sub btnTestPrint_Click(sender As Object, e As EventArgs)
			Dim dataTable As DataTable = Me.dt1
			dataTable.Columns.Add("PCode")
			dataTable.Columns.Add("ProductName")
			dataTable.Columns.Add("Category")
			dataTable.Columns.Add("Barcode")
			dataTable.Columns.Add("QrBarcode")
			Me.dt1.Rows.Add(New Object() { "123", "My Product", "Print 1", "322678989", "322678989" })
			Me.dt1.Rows.Add(New Object() { "456", "My Product 2", "Print 2", "03214545", "03214545" })
			Me.dt1.Rows.Add(New Object() { "789", "My Product 3", "Print 3", "12114556", "12114556" })
			Me.dt1.Rows.Add(New Object() { "1011", "My Product 4", "Print 4", "25598999", "25598999" })
			Try
				Dim num As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Width), 38D)) * 39.3701F
				Dim num2 As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Height), 38D)) * 39.3701F
				Dim num3 As Integer = CInt(CDbl(num)) + 7
				Dim num4 As Integer = CInt(CDbl(num2)) + 8
				Me.PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Cheque", num4, num3)
				Me.PrintPreviewDialog1.Size = New Size(800, 500)
				Me.PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
				Me.PrintDocument1.DefaultPageSettings.Landscape = True
				Me.PrintPreviewDialog1.Document = Me.PrintDocument1
				Me.PrintPreviewDialog1.ShowDialog()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060006FF RID: 1791 RVA: 0x0009B834 File Offset: 0x00099A34
		Public Function GetClientareaImage(frm As Form) As Bitmap
			' The following expression was wrapped in a checked-statement
			Dim bitmap2 As Bitmap
			Using controlImage As Bitmap = Me.GetControlImage(frm)
				Dim point As Point = frm.PointToScreen(New Point(0, 0))
				Dim num As Integer = point.X - frm.Left
				Dim num2 As Integer = point.Y - frm.Top
				Dim width As Integer = frm.ClientSize.Width
				Dim height As Integer = frm.ClientSize.Height
				Dim bitmap As Bitmap = New Bitmap(width, height)
				Using graphics As Graphics = Graphics.FromImage(bitmap)
					graphics.DrawImage(controlImage, 0, 0)
				End Using
				bitmap2 = bitmap
			End Using
			Return bitmap2
		End Function

		' Token: 0x06000700 RID: 1792 RVA: 0x0009B8F8 File Offset: 0x00099AF8
		Public Function GetControlImage(ctrl As Control) As Bitmap
			Dim bitmap As Bitmap = New Bitmap(ctrl.Width, ctrl.Height)
			ctrl.DrawToBitmap(bitmap, New Rectangle(0, 0, ctrl.Width, ctrl.Height))
			Return bitmap
		End Function

		' Token: 0x06000701 RID: 1793 RVA: 0x0009B938 File Offset: 0x00099B38
		Private Sub frmBarcodeMain_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Delete
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Dispose()
			End If
		End Sub

		' Token: 0x06000702 RID: 1794 RVA: 0x0009B9BC File Offset: 0x00099BBC
		Private Sub frmBarcodeMain_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = e.KeyChar = "."c
			If flag Then
				Interaction.MsgBox("delete", MsgBoxStyle.OkOnly, Nothing)
			End If
		End Sub

		' Token: 0x06000703 RID: 1795 RVA: 0x0009B938 File Offset: 0x00099B38
		Private Sub frmBarcodeMain_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Delete
			If flag Then
				Dim controls As Object = Me.pnlCheque.Controls
				Dim type As Type = Nothing
				Dim text As String = "Item"
				Dim array As Object() = New Object(0) {}
				Dim num As Integer = 0
				Dim lblHidden As Label = Me.lblHidden
				Dim label As Label = lblHidden
				array(num) = lblHidden.Tag
				Dim array2 As Object() = array
				Dim array3 As String() = Nothing
				Dim array4 As Type() = Nothing
				Dim array5 As Boolean() = New Boolean() { True }
				Dim array6 As Boolean() = array5
				Dim obj As Object = NewLateBinding.LateGet(controls, type, text, array, array3, array4, array5)
				If array6(0) Then
					label.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2(0)))
				End If
				Dim label2 As Label = CType(obj, Label)
				label2.Dispose()
			End If
		End Sub

		' Token: 0x06000704 RID: 1796 RVA: 0x0009B9E8 File Offset: 0x00099BE8
		Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
			Dim num As Integer = 15
			Dim text As String = "Item".PadRight(30)
			Dim text2 As String = "Price".PadRight(8)
			Dim text3 As String = "Qty".PadRight(5)
			Dim text4 As String = "Amount"
			Dim text5 As String = text + text2 + text3 + text4
			Dim num2 As Integer = Me.ds_labels.Tables(0).Rows.Count - 1
			For i As Integer = 0 To num2
				Dim label As Label = New Label()
				Dim text6 As String = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
				If Operators.CompareString(text6, "PCode", False) <> 0 Then
					If Operators.CompareString(text6, "ProductName", False) <> 0 Then
						If Operators.CompareString(text6, "Category", False) <> 0 Then
							If Operators.CompareString(text6, "Barcode", False) <> 0 Then
								If Operators.CompareString(text6, "QrBarcode", False) <> 0 Then
									label.Text = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
								Else
									label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(4))
								End If
							Else
								label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(3))
							End If
						Else
							label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(2))
						End If
					Else
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(1))
					End If
				Else
					label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(0))
				End If
				label.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
				label.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
				Dim flag As Boolean = (Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString(), "QrBarcode", False) <> 0) And (Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString().IndexOf("Generic") = -1)
				If flag Then
					Dim fontConverter As FontConverter = New FontConverter()
					Dim text7 As String = Conversions.ToString(Me.ds_labels.Tables("layout_labels").Rows(i)("lbl_font_style"))
					If Operators.CompareString(text7, "Bold", False) <> 0 Then
						If Operators.CompareString(text7, "Italic", False) <> 0 Then
							If Operators.CompareString(text7, "Underline", False) <> 0 Then
								If Operators.CompareString(text7, "Bold, Italic, Underline", False) <> 0 Then
									If Operators.CompareString(text7, "Bold, Underline ", False) <> 0 Then
										If Operators.CompareString(text7, "Italic, Underline ", False) <> 0 Then
											text7 = Conversions.ToString(0)
										Else
											text7 = Conversions.ToString(6)
										End If
									Else
										text7 = Conversions.ToString(5)
									End If
								Else
									text7 = Conversions.ToString(7)
								End If
							Else
								text7 = Conversions.ToString(4)
							End If
						Else
							text7 = Conversions.ToString(2)
						End If
					Else
						text7 = Conversions.ToString(1)
					End If
					label.Font = New Font(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_name").ToString(), Conversions.ToSingle(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_size").ToString()), CType(Conversions.ToInteger(text7), FontStyle), GraphicsUnit.Point, 0)
					label.ForeColor = Color.FromArgb(CInt(Convert.ToInt64(Me.ds_labels.Tables("layout_labels").Rows(i)("label_text_color").ToString())))
					label.SendToBack()
					label.AutoSize = False
					e.Graphics.DrawString(label.Text, label.Font, Brushes.Black, CSng(label.Location.X), CSng(label.Location.Y))
					num += 10
					Dim font As Font = New Font("Courier New", 8F, FontStyle.Regular)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString(), "QrBarcode", False) = 0
					If flag2 Then
						Dim text8 As String = label.Text
						Dim bitmap As Bitmap = New Bitmap(text8.Length * 40, 80)
						Using graphics As Graphics = Graphics.FromImage(bitmap)
							Dim font2 As Font = New Font("IDAutomationHC39M Free Version", 16F)
							Dim pointF As PointF = New PointF(2F, 2F)
							Dim solidBrush As SolidBrush = New SolidBrush(Color.Black)
							Dim solidBrush2 As SolidBrush = New SolidBrush(Color.White)
							graphics.FillRectangle(solidBrush2, 0, 0, bitmap.Width, bitmap.Height)
							graphics.DrawString(Convert.ToString("*") + text8 + "*", font2, solidBrush, pointF)
						End Using
						Using memoryStream As MemoryStream = New MemoryStream()
							bitmap.Save(memoryStream, ImageFormat.Png)
							Me.pbQrCode.Image = bitmap
							Me.pbQrCode.Height = bitmap.Height
							Me.pbQrCode.Width = bitmap.Width
						End Using
						e.Graphics.DrawImage(Me.pbQrCode.Image, label.Location.X, label.Location.Y)
						num += 10
					Else
						e.Graphics.DrawString(label.Text, label.Font, Brushes.Black, CSng(label.Location.X), CSng(label.Location.Y))
						num += 10
					End If
				End If
			Next
			Dim flag3 As Boolean = Me.mPageNumber < Me.dt1.Rows.Count
			If flag3 Then
				e.HasMorePages = True
				Me.mPageNumber = Me.mPageNumber + 1
			Else
				e.HasMorePages = False
			End If
		End Sub

		' Token: 0x06000705 RID: 1797 RVA: 0x0009C1E8 File Offset: 0x0009A3E8
		Private Function btnAddImage_Click(sender As Object, e As EventArgs) As Object
			Dim flag As Boolean = (Me.clickLocation.X = 0) And (Me.clickLocation.Y = 0)
			Dim obj As Object
			If flag Then
				MessageBox.Show("Please click anywhere on panel to insert")
				obj = False
			Else
				Me.btnCreateImage()
				obj = True
			End If
			Return obj
		End Function

		' Token: 0x06000706 RID: 1798 RVA: 0x0009C240 File Offset: 0x0009A440
		Private Sub btnZoom_Click(sender As Object, e As EventArgs)
			Dim num As Double = 2.0
			Me.pnlCheque.Width = CInt(Math.Round(CDbl(Me.pnlCheque.Width) * num))
			Me.pnlCheque.Height = CInt(Math.Round(CDbl(Me.pnlCheque.Height) * num))
			Try
				For Each obj As Object In Me.pnlCheque.Controls
					Dim control As Control = CType(obj, Control)
					control.Width = CInt(Math.Round(CDbl(control.Width) * num))
					control.Height = CInt(Math.Round(CDbl(control.Height) * num))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06000707 RID: 1799 RVA: 0x0009C318 File Offset: 0x0009A518
		Private Sub ScaleControl(ctrl As Control, scaleFactor As Double)
			Dim flag As Boolean = Not Me.originalSizes.ContainsKey(ctrl)
			If flag Then
				Me.originalSizes.Add(ctrl, ctrl.Size)
			End If
			Dim flag2 As Boolean
			ctrl.Width = CInt(Math.Round(CDbl(ctrl.Width) * scaleFactor))
			ctrl.Height = CInt(Math.Round(CDbl(ctrl.Height) * scaleFactor))
			flag2 = ctrl.Font IsNot Nothing
			If flag2 Then
				ctrl.Font = New Font(ctrl.Font.FontFamily, ctrl.Font.Size * CSng(scaleFactor))
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.ScaleControl(control, scaleFactor)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06000708 RID: 1800 RVA: 0x0009C408 File Offset: 0x0009A608
		Private Sub ZoomControls(scaleFactor As Double)
			Try
				For Each obj As Object In MyBase.Controls
					Dim control As Control = CType(obj, Control)
					Me.ScaleControl(control, scaleFactor)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06000709 RID: 1801 RVA: 0x0009C46C File Offset: 0x0009A66C
		Private Sub btnRevert_Click(sender As Object, e As EventArgs)
			Dim num As Double = 2.0
			Me.pnlCheque.Width = CInt(Math.Round(CDbl(Me.pnlCheque.Width) / num))
			Me.pnlCheque.Height = CInt(Math.Round(CDbl(Me.pnlCheque.Height) / num))
			Try
				For Each obj As Object In Me.pnlCheque.Controls
					Dim control As Control = CType(obj, Control)
					control.Width = CInt(Math.Round(CDbl(control.Width) / num))
					control.Height = CInt(Math.Round(CDbl(control.Height) / num))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0400028D RID: 653
		Private inFlag As Integer

		' Token: 0x0400028E RID: 654
		Private strDate As String

		' Token: 0x0400028F RID: 655
		Private strSeparateDate As String

		' Token: 0x04000290 RID: 656
		Private ctrlLabel As Control

		' Token: 0x04000291 RID: 657
		Private ctrlPanel As Control

		' Token: 0x04000292 RID: 658
		Private inHardMarginY As Integer

		' Token: 0x04000293 RID: 659
		Private strImgPath As String

		' Token: 0x04000294 RID: 660
		Private strFinalPath As String

		' Token: 0x04000295 RID: 661
		Private decLayoutId As Decimal

		' Token: 0x04000296 RID: 662
		Private decDimensionId As Decimal

		' Token: 0x04000297 RID: 663
		Private dl As DragLabel

		' Token: 0x04000298 RID: 664
		Private infoDimension As DimensionInfo

		' Token: 0x04000299 RID: 665
		Private Const grid_gap As Integer = 4

		' Token: 0x0400029A RID: 666
		Private Off As Point

		' Token: 0x0400029B RID: 667
		Private connString As String

		' Token: 0x0400029C RID: 668
		Private dtb As DataTable

		' Token: 0x0400029D RID: 669
		Private MyDS As DataSet

		' Token: 0x0400029E RID: 670
		Private ds_labels As DataSet

		' Token: 0x040002A0 RID: 672
		Private mPageNumber As Integer

		' Token: 0x040002A1 RID: 673
		Private counter As Integer

		' Token: 0x040002A2 RID: 674
		Private counter_qrcode As Integer

		' Token: 0x040002A3 RID: 675
		Private dt1 As DataTable

		' Token: 0x040002A4 RID: 676
		Private bitmap As Bitmap

		' Token: 0x040002A5 RID: 677
		Private clickLocation As Point

		' Token: 0x040002A7 RID: 679
		Private originalSizes As Dictionary(Of Control, Size)
	End Class
End Namespace
