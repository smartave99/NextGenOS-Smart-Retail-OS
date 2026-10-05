Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000018 RID: 24
	<DesignerGenerated()>
	Public Partial Class frmMine
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600070C RID: 1804 RVA: 0x00009F59 File Offset: 0x00008159
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			Me.number = 1
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700038D RID: 909
		' (get) Token: 0x0600070F RID: 1807 RVA: 0x00009F84 File Offset: 0x00008184
		' (set) Token: 0x06000710 RID: 1808 RVA: 0x0009D428 File Offset: 0x0009B628
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

		' Token: 0x1700038E RID: 910
		' (get) Token: 0x06000711 RID: 1809 RVA: 0x00009F8E File Offset: 0x0000818E
		' (set) Token: 0x06000712 RID: 1810 RVA: 0x0009D46C File Offset: 0x0009B66C
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

		' Token: 0x1700038F RID: 911
		' (get) Token: 0x06000713 RID: 1811 RVA: 0x00009F98 File Offset: 0x00008198
		' (set) Token: 0x06000714 RID: 1812 RVA: 0x00009FA2 File Offset: 0x000081A2
		Friend Overridable Property TextSizeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000390 RID: 912
		' (get) Token: 0x06000715 RID: 1813 RVA: 0x00009FAB File Offset: 0x000081AB
		' (set) Token: 0x06000716 RID: 1814 RVA: 0x0009D4B0 File Offset: 0x0009B6B0
		Private _BoldToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldToolStripMenuItem_Click
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

		' Token: 0x17000391 RID: 913
		' (get) Token: 0x06000717 RID: 1815 RVA: 0x00009FB5 File Offset: 0x000081B5
		' (set) Token: 0x06000718 RID: 1816 RVA: 0x0009D4F4 File Offset: 0x0009B6F4
		Private _ItalicToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ItalicToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ItalicToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ItalicToolStripMenuItem_Click
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

		' Token: 0x17000392 RID: 914
		' (get) Token: 0x06000719 RID: 1817 RVA: 0x00009FBF File Offset: 0x000081BF
		' (set) Token: 0x0600071A RID: 1818 RVA: 0x0009D538 File Offset: 0x0009B738
		Private _RegularToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RegularToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RegularToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RegularToolStripMenuItem_Click
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

		' Token: 0x17000393 RID: 915
		' (get) Token: 0x0600071B RID: 1819 RVA: 0x00009FC9 File Offset: 0x000081C9
		' (set) Token: 0x0600071C RID: 1820 RVA: 0x0009D57C File Offset: 0x0009B77C
		Private _UnderlineToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property UnderlineToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UnderlineToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UnderlineToolStripMenuItem1_Click
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

		' Token: 0x17000394 RID: 916
		' (get) Token: 0x0600071D RID: 1821 RVA: 0x00009FD3 File Offset: 0x000081D3
		' (set) Token: 0x0600071E RID: 1822 RVA: 0x0009D5C0 File Offset: 0x0009B7C0
		Private _BoldItalicToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldItalicToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldItalicToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldItalicToolStripMenuItem_Click
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

		' Token: 0x17000395 RID: 917
		' (get) Token: 0x0600071F RID: 1823 RVA: 0x00009FDD File Offset: 0x000081DD
		' (set) Token: 0x06000720 RID: 1824 RVA: 0x0009D604 File Offset: 0x0009B804
		Private _BoldUnderlineToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BoldUnderlineToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BoldUnderlineToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BoldUnderlineToolStripMenuItem_Click
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

		' Token: 0x17000396 RID: 918
		' (get) Token: 0x06000721 RID: 1825 RVA: 0x00009FE7 File Offset: 0x000081E7
		' (set) Token: 0x06000722 RID: 1826 RVA: 0x00009FF1 File Offset: 0x000081F1
		Friend Overridable Property FontSizeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000397 RID: 919
		' (get) Token: 0x06000723 RID: 1827 RVA: 0x00009FFA File Offset: 0x000081FA
		' (set) Token: 0x06000724 RID: 1828 RVA: 0x0009D648 File Offset: 0x0009B848
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

		' Token: 0x17000398 RID: 920
		' (get) Token: 0x06000725 RID: 1829 RVA: 0x0000A004 File Offset: 0x00008204
		' (set) Token: 0x06000726 RID: 1830 RVA: 0x0000A00E File Offset: 0x0000820E
		Friend Overridable Property AlignmentToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17000399 RID: 921
		' (get) Token: 0x06000727 RID: 1831 RVA: 0x0000A017 File Offset: 0x00008217
		' (set) Token: 0x06000728 RID: 1832 RVA: 0x0009D68C File Offset: 0x0009B88C
		Private _LeftToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LeftToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LeftToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LeftToolStripMenuItem_Click
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

		' Token: 0x1700039A RID: 922
		' (get) Token: 0x06000729 RID: 1833 RVA: 0x0000A021 File Offset: 0x00008221
		' (set) Token: 0x0600072A RID: 1834 RVA: 0x0009D6D0 File Offset: 0x0009B8D0
		Private _CenterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CenterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CenterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CenterToolStripMenuItem_Click
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

		' Token: 0x1700039B RID: 923
		' (get) Token: 0x0600072B RID: 1835 RVA: 0x0000A02B File Offset: 0x0000822B
		' (set) Token: 0x0600072C RID: 1836 RVA: 0x0009D714 File Offset: 0x0009B914
		Private _RightToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RightToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RightToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RightToolStripMenuItem_Click
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

		' Token: 0x1700039C RID: 924
		' (get) Token: 0x0600072D RID: 1837 RVA: 0x0000A035 File Offset: 0x00008235
		' (set) Token: 0x0600072E RID: 1838 RVA: 0x0000A03F File Offset: 0x0000823F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700039D RID: 925
		' (get) Token: 0x0600072F RID: 1839 RVA: 0x0000A048 File Offset: 0x00008248
		' (set) Token: 0x06000730 RID: 1840 RVA: 0x0009D758 File Offset: 0x0009B958
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

		' Token: 0x1700039E RID: 926
		' (get) Token: 0x06000731 RID: 1841 RVA: 0x0000A052 File Offset: 0x00008252
		' (set) Token: 0x06000732 RID: 1842 RVA: 0x0000A05C File Offset: 0x0000825C
		Friend Overridable Property EditTextToolStripMenuItem As ToolStripMenuItem

		' Token: 0x1700039F RID: 927
		' (get) Token: 0x06000733 RID: 1843 RVA: 0x0000A065 File Offset: 0x00008265
		' (set) Token: 0x06000734 RID: 1844 RVA: 0x0009D79C File Offset: 0x0009B99C
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

		' Token: 0x170003A0 RID: 928
		' (get) Token: 0x06000735 RID: 1845 RVA: 0x0000A06F File Offset: 0x0000826F
		' (set) Token: 0x06000736 RID: 1846 RVA: 0x0009D7E0 File Offset: 0x0009B9E0
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

		' Token: 0x170003A1 RID: 929
		' (get) Token: 0x06000737 RID: 1847 RVA: 0x0000A079 File Offset: 0x00008279
		' (set) Token: 0x06000738 RID: 1848 RVA: 0x0000A083 File Offset: 0x00008283
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170003A2 RID: 930
		' (get) Token: 0x06000739 RID: 1849 RVA: 0x0000A08C File Offset: 0x0000828C
		' (set) Token: 0x0600073A RID: 1850 RVA: 0x0009D824 File Offset: 0x0009BA24
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

		' Token: 0x170003A3 RID: 931
		' (get) Token: 0x0600073B RID: 1851 RVA: 0x0000A096 File Offset: 0x00008296
		' (set) Token: 0x0600073C RID: 1852 RVA: 0x0009D868 File Offset: 0x0009BA68
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

		' Token: 0x170003A4 RID: 932
		' (get) Token: 0x0600073D RID: 1853 RVA: 0x0000A0A0 File Offset: 0x000082A0
		' (set) Token: 0x0600073E RID: 1854 RVA: 0x0009D8AC File Offset: 0x0009BAAC
		Private _btnUnderline As Button
		Friend Overridable Property btnUnderline As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUnderline
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUnderline_Click
				Dim button As Button = Me._btnUnderline
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUnderline = value
				button = Me._btnUnderline
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170003A5 RID: 933
		' (get) Token: 0x0600073F RID: 1855 RVA: 0x0000A0AA File Offset: 0x000082AA
		' (set) Token: 0x06000740 RID: 1856 RVA: 0x0009D8F0 File Offset: 0x0009BAF0
		Private _btnItalic As Button
		Friend Overridable Property btnItalic As Button
			<CompilerGenerated()>
			Get
				Return Me._btnItalic
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnItalic_Click
				Dim button As Button = Me._btnItalic
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnItalic = value
				button = Me._btnItalic
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170003A6 RID: 934
		' (get) Token: 0x06000741 RID: 1857 RVA: 0x0000A0B4 File Offset: 0x000082B4
		' (set) Token: 0x06000742 RID: 1858 RVA: 0x0009D934 File Offset: 0x0009BB34
		Private _btnBold As Button
		Friend Overridable Property btnBold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBold_Click
				Dim button As Button = Me._btnBold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBold = value
				button = Me._btnBold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170003A7 RID: 935
		' (get) Token: 0x06000743 RID: 1859 RVA: 0x0000A0BE File Offset: 0x000082BE
		' (set) Token: 0x06000744 RID: 1860 RVA: 0x0009D978 File Offset: 0x0009BB78
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

		' Token: 0x170003A8 RID: 936
		' (get) Token: 0x06000745 RID: 1861 RVA: 0x0000A0C8 File Offset: 0x000082C8
		' (set) Token: 0x06000746 RID: 1862 RVA: 0x0000A0D2 File Offset: 0x000082D2
		Friend Overridable Property cmbAlignment As ComboBox

		' Token: 0x170003A9 RID: 937
		' (get) Token: 0x06000747 RID: 1863 RVA: 0x0000A0DB File Offset: 0x000082DB
		' (set) Token: 0x06000748 RID: 1864 RVA: 0x0000A0E5 File Offset: 0x000082E5
		Friend Overridable Property lblHidden As Label

		' Token: 0x170003AA RID: 938
		' (get) Token: 0x06000749 RID: 1865 RVA: 0x0000A0EE File Offset: 0x000082EE
		' (set) Token: 0x0600074A RID: 1866 RVA: 0x0000A0F8 File Offset: 0x000082F8
		Friend Overridable Property FontFamilyToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170003AB RID: 939
		' (get) Token: 0x0600074B RID: 1867 RVA: 0x0000A101 File Offset: 0x00008301
		' (set) Token: 0x0600074C RID: 1868 RVA: 0x0009D9BC File Offset: 0x0009BBBC
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

		' Token: 0x170003AC RID: 940
		' (get) Token: 0x0600074D RID: 1869 RVA: 0x0000A10B File Offset: 0x0000830B
		' (set) Token: 0x0600074E RID: 1870 RVA: 0x0000A115 File Offset: 0x00008315
		Private Property number As Integer

		' Token: 0x0600074F RID: 1871 RVA: 0x0000A11E File Offset: 0x0000831E
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.GetFonts()
			Me.SetFontSize()
		End Sub

		' Token: 0x06000750 RID: 1872 RVA: 0x00097A04 File Offset: 0x00095C04
		Private Sub TextColorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim colorDialog As ColorDialog = New ColorDialog()
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim flag As Boolean = colorDialog.ShowDialog() = DialogResult.OK
			If flag Then
				label.ForeColor = colorDialog.Color
			End If
		End Sub

		' Token: 0x06000751 RID: 1873 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextSizeToolStripMenuItem_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06000752 RID: 1874 RVA: 0x0009DA00 File Offset: 0x0009BC00
		Private Sub BoldToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold)
		End Sub

		' Token: 0x06000753 RID: 1875 RVA: 0x0009DA3C File Offset: 0x0009BC3C
		Private Sub ItalicToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Italic)
		End Sub

		' Token: 0x06000754 RID: 1876 RVA: 0x0009DA78 File Offset: 0x0009BC78
		Private Sub RegularToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Regular)
		End Sub

		' Token: 0x06000755 RID: 1877 RVA: 0x00097B3C File Offset: 0x00095D3C
		Private Sub UnderlineToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Strikeout
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x06000756 RID: 1878 RVA: 0x0009DAB4 File Offset: 0x0009BCB4
		Private Sub UnderlineToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Underline)
		End Sub

		' Token: 0x06000757 RID: 1879 RVA: 0x0009DAF0 File Offset: 0x0009BCF0
		Private Sub BoldItalicToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Italic)
		End Sub

		' Token: 0x06000758 RID: 1880 RVA: 0x00097D38 File Offset: 0x00095F38
		Private Sub BoldStrikeoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim fontStyle As FontStyle = FontStyle.Bold Or FontStyle.Strikeout
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Font = font
		End Sub

		' Token: 0x06000759 RID: 1881 RVA: 0x0009DB2C File Offset: 0x0009BD2C
		Private Sub BoldUnderlineToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Me.SetBoldItalicUnderline(label, FontStyle.Bold Or FontStyle.Underline)
		End Sub

		' Token: 0x0600075A RID: 1882 RVA: 0x0009DB68 File Offset: 0x0009BD68
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

		' Token: 0x0600075B RID: 1883 RVA: 0x0009DBE4 File Offset: 0x0009BDE4
		Private Sub SetFontSize()
			Dim num As Integer = 5
			Do
				Me.cmbFontSize.Items.Add(num)
				num += 1
			Loop While num <= 100
			Me.cmbFontSize.SelectedIndex = 0
		End Sub

		' Token: 0x0600075C RID: 1884 RVA: 0x0009DC24 File Offset: 0x0009BE24
		Private Sub GetFonts()
			For Each fontFamily As FontFamily In FontFamily.Families
				Me.cmbFonts.Items.Add(fontFamily.Name)
				Me.ToolStripCmbFonts.Items.Add(fontFamily.Name)
			Next
			Me.cmbFonts.SelectedIndex = 0
			Me.ToolStripCmbFonts.SelectedIndex = 0
		End Sub

		' Token: 0x0600075D RID: 1885 RVA: 0x0009DC98 File Offset: 0x0009BE98
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

		' Token: 0x0600075E RID: 1886 RVA: 0x0009DD4C File Offset: 0x0009BF4C
		Private Sub obj1_MouseDown(sender As Object, e As MouseEventArgs)
			Me.Off.X = Conversions.ToInteger(Operators.SubtractObject(Control.MousePosition.X, NewLateBinding.LateGet(sender, Nothing, "Left", New Object(-1) {}, Nothing, Nothing, Nothing)))
			Me.Off.Y = Conversions.ToInteger(Operators.SubtractObject(Control.MousePosition.Y, NewLateBinding.LateGet(sender, Nothing, "Top", New Object(-1) {}, Nothing, Nothing, Nothing)))
		End Sub

		' Token: 0x0600075F RID: 1887 RVA: 0x0009DDD4 File Offset: 0x0009BFD4
		Private Sub obj1_MouseMove(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = e.Button = MouseButtons.Left
			If flag Then
				NewLateBinding.LateSet(sender, Nothing, "Left", New Object() { Control.MousePosition.X - Me.Off.X }, Nothing, Nothing)
				NewLateBinding.LateSet(sender, Nothing, "Top", New Object() { Control.MousePosition.Y - Me.Off.Y }, Nothing, Nothing)
			End If
		End Sub

		' Token: 0x06000760 RID: 1888 RVA: 0x0009DE64 File Offset: 0x0009C064
		Private Sub LeftToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Left
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x06000761 RID: 1889 RVA: 0x0009DEC8 File Offset: 0x0009C0C8
		Private Sub CenterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Fill
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x06000762 RID: 1890 RVA: 0x0009DF2C File Offset: 0x0009C12C
		Private Sub RightToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).OwnerItem.Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			Dim fontStyle As FontStyle
			Dim font As Font = New Font(label.Font.FontFamily, label.Font.Size, fontStyle)
			label.Dock = DockStyle.Right
			Me.ContextMenuStrip1.Visible = False
		End Sub

		' Token: 0x06000763 RID: 1891 RVA: 0x0009DF90 File Offset: 0x0009C190
		Private Sub ToolStripTextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripTextBox).OwnerItem.Owner, ContextMenuStrip)
				Dim label As Label = CType(contextMenuStrip.Tag, Label)
				label.Text = Me.ToolStripTextBox2.Text
				Me.ContextMenuStrip1.Visible = False
			End If
		End Sub

		' Token: 0x06000764 RID: 1892 RVA: 0x000979D0 File Offset: 0x00095BD0
		Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim contextMenuStrip As ContextMenuStrip = CType(CType(sender, ToolStripMenuItem).Owner, ContextMenuStrip)
			Dim label As Label = CType(contextMenuStrip.Tag, Label)
			label.Dispose()
		End Sub

		' Token: 0x06000765 RID: 1893 RVA: 0x0009DFF0 File Offset: 0x0009C1F0
		Private Sub btnAddLabel_Click(sender As Object, e As EventArgs)
			Dim label As Label = New Label()
			label.Name = "Label" + Me.number.ToString()
			label.Text = "Label" + Me.number.ToString()
			label.SendToBack()
			label.AutoSize = True
			label.Location = New Point(Me.number * 60, 50)
			label.ContextMenuStrip = Me.ContextMenuStrip1
			Me.Panel1.Controls.Add(label)
			Me.number += 1
			Me.lblHidden.Tag = label.Name
			AddHandler label.Click, AddressOf Me.lb_Click
			Me.WireLabels(Me)
		End Sub

		' Token: 0x06000766 RID: 1894 RVA: 0x0000A12F File Offset: 0x0000832F
		Private Sub lb_Click(sender As Object, e As EventArgs)
			Me.lblHidden.Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, Nothing, "Name", New Object(-1) {}, Nothing, Nothing, Nothing))
		End Sub

		' Token: 0x06000767 RID: 1895 RVA: 0x0000A158 File Offset: 0x00008358
		Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs)
			Me.ContextMenuStrip1.Tag = Me.ContextMenuStrip1.SourceControl
		End Sub

		' Token: 0x06000768 RID: 1896 RVA: 0x0009E0C4 File Offset: 0x0009C2C4
		Private Sub cmbFonts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.Panel1.Controls
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

		' Token: 0x06000769 RID: 1897 RVA: 0x0009E174 File Offset: 0x0009C374
		Private Sub btnBold_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.Panel1.Controls
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
			Me.SetBoldItalicUnderline(label2, FontStyle.Bold)
		End Sub

		' Token: 0x0600076A RID: 1898 RVA: 0x0009E1E8 File Offset: 0x0009C3E8
		Private Sub SetBoldItalicUnderline(LabelMe As Label, FS As FontStyle)
			Dim font As Font = New Font(LabelMe.Font.FontFamily, LabelMe.Font.Size, FS)
			LabelMe.Font = font
		End Sub

		' Token: 0x0600076B RID: 1899 RVA: 0x0009E220 File Offset: 0x0009C420
		Private Sub btnItalic_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.Panel1.Controls
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

		' Token: 0x0600076C RID: 1900 RVA: 0x0009E294 File Offset: 0x0009C494
		Private Sub btnUnderline_Click(sender As Object, e As EventArgs)
			Dim controls As Object = Me.Panel1.Controls
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

		' Token: 0x0600076D RID: 1901 RVA: 0x0009E308 File Offset: 0x0009C508
		Private Sub btnColor_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.Panel1.Controls
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

		' Token: 0x0600076E RID: 1902 RVA: 0x0009E3B4 File Offset: 0x0009C5B4
		Private Sub cmbFontSize_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.Panel1.Controls
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
		End Sub

		' Token: 0x0600076F RID: 1903 RVA: 0x0009E468 File Offset: 0x0009C668
		Private Sub ToolStripCmbFonts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblHidden.Tag IsNot Nothing
			If flag Then
				Dim controls As Object = Me.Panel1.Controls
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

		' Token: 0x040002C8 RID: 712
		Private Off As Point
	End Class
End Namespace
