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
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports DevNetTRLN
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001D5 RID: 469
	<DesignerGenerated()>
	Public Partial Class frmProductBulkUpdate_GST
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007C38 RID: 31800 RVA: 0x005CCD0C File Offset: 0x005CAF0C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductBulkUpdate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductBulkUpdate_KeyDown
			AddHandler MyBase.Scroll, AddressOf Me.frmProductBulkUpdate_Scroll
			Me.pageIndex = 1
			Me.pageSize = 35
			Me.totalRecords = 0
			Me.totalPages = 0
			Me.showAll = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002D8D RID: 11661
		' (get) Token: 0x06007C3B RID: 31803 RVA: 0x0003D2E4 File Offset: 0x0003B4E4
		' (set) Token: 0x06007C3C RID: 31804 RVA: 0x0003D2EE File Offset: 0x0003B4EE
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17002D8E RID: 11662
		' (get) Token: 0x06007C3D RID: 31805 RVA: 0x0003D2F7 File Offset: 0x0003B4F7
		' (set) Token: 0x06007C3E RID: 31806 RVA: 0x0003D301 File Offset: 0x0003B501
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17002D8F RID: 11663
		' (get) Token: 0x06007C3F RID: 31807 RVA: 0x0003D30A File Offset: 0x0003B50A
		' (set) Token: 0x06007C40 RID: 31808 RVA: 0x0003D314 File Offset: 0x0003B514
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17002D90 RID: 11664
		' (get) Token: 0x06007C41 RID: 31809 RVA: 0x0003D31D File Offset: 0x0003B51D
		' (set) Token: 0x06007C42 RID: 31810 RVA: 0x0003D327 File Offset: 0x0003B527
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17002D91 RID: 11665
		' (get) Token: 0x06007C43 RID: 31811 RVA: 0x0003D330 File Offset: 0x0003B530
		' (set) Token: 0x06007C44 RID: 31812 RVA: 0x0003D33A File Offset: 0x0003B53A
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17002D92 RID: 11666
		' (get) Token: 0x06007C45 RID: 31813 RVA: 0x0003D343 File Offset: 0x0003B543
		' (set) Token: 0x06007C46 RID: 31814 RVA: 0x0003D34D File Offset: 0x0003B54D
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17002D93 RID: 11667
		' (get) Token: 0x06007C47 RID: 31815 RVA: 0x0003D356 File Offset: 0x0003B556
		' (set) Token: 0x06007C48 RID: 31816 RVA: 0x0003D360 File Offset: 0x0003B560
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17002D94 RID: 11668
		' (get) Token: 0x06007C49 RID: 31817 RVA: 0x0003D369 File Offset: 0x0003B569
		' (set) Token: 0x06007C4A RID: 31818 RVA: 0x0003D373 File Offset: 0x0003B573
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17002D95 RID: 11669
		' (get) Token: 0x06007C4B RID: 31819 RVA: 0x0003D37C File Offset: 0x0003B57C
		' (set) Token: 0x06007C4C RID: 31820 RVA: 0x0003D386 File Offset: 0x0003B586
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17002D96 RID: 11670
		' (get) Token: 0x06007C4D RID: 31821 RVA: 0x0003D38F File Offset: 0x0003B58F
		' (set) Token: 0x06007C4E RID: 31822 RVA: 0x0003D399 File Offset: 0x0003B599
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17002D97 RID: 11671
		' (get) Token: 0x06007C4F RID: 31823 RVA: 0x0003D3A2 File Offset: 0x0003B5A2
		' (set) Token: 0x06007C50 RID: 31824 RVA: 0x0003D3AC File Offset: 0x0003B5AC
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17002D98 RID: 11672
		' (get) Token: 0x06007C51 RID: 31825 RVA: 0x0003D3B5 File Offset: 0x0003B5B5
		' (set) Token: 0x06007C52 RID: 31826 RVA: 0x0003D3BF File Offset: 0x0003B5BF
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17002D99 RID: 11673
		' (get) Token: 0x06007C53 RID: 31827 RVA: 0x0003D3C8 File Offset: 0x0003B5C8
		' (set) Token: 0x06007C54 RID: 31828 RVA: 0x0003D3D2 File Offset: 0x0003B5D2
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17002D9A RID: 11674
		' (get) Token: 0x06007C55 RID: 31829 RVA: 0x0003D3DB File Offset: 0x0003B5DB
		' (set) Token: 0x06007C56 RID: 31830 RVA: 0x0003D3E5 File Offset: 0x0003B5E5
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17002D9B RID: 11675
		' (get) Token: 0x06007C57 RID: 31831 RVA: 0x0003D3EE File Offset: 0x0003B5EE
		' (set) Token: 0x06007C58 RID: 31832 RVA: 0x005CFA38 File Offset: 0x005CDC38
		Private _TextBox42 As TextBox
		Friend Overridable Property TextBox42 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox42
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox42_LostFocus
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox42_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox42_KeyDown
				Dim textBox As TextBox = Me._TextBox42
				If textBox IsNot Nothing Then
					RemoveHandler textBox.LostFocus, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox42 = value
				textBox = Me._TextBox42
				If textBox IsNot Nothing Then
					AddHandler textBox.LostFocus, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002D9C RID: 11676
		' (get) Token: 0x06007C59 RID: 31833 RVA: 0x0003D3F8 File Offset: 0x0003B5F8
		' (set) Token: 0x06007C5A RID: 31834 RVA: 0x005CFAB4 File Offset: 0x005CDCB4
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

		' Token: 0x17002D9D RID: 11677
		' (get) Token: 0x06007C5B RID: 31835 RVA: 0x0003D402 File Offset: 0x0003B602
		' (set) Token: 0x06007C5C RID: 31836 RVA: 0x005CFAF8 File Offset: 0x005CDCF8
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

		' Token: 0x17002D9E RID: 11678
		' (get) Token: 0x06007C5D RID: 31837 RVA: 0x0003D40C File Offset: 0x0003B60C
		' (set) Token: 0x06007C5E RID: 31838 RVA: 0x0003D416 File Offset: 0x0003B616
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17002D9F RID: 11679
		' (get) Token: 0x06007C5F RID: 31839 RVA: 0x0003D41F File Offset: 0x0003B61F
		' (set) Token: 0x06007C60 RID: 31840 RVA: 0x0003D429 File Offset: 0x0003B629
		Friend Overridable Property Label1 As Label

		' Token: 0x17002DA0 RID: 11680
		' (get) Token: 0x06007C61 RID: 31841 RVA: 0x0003D432 File Offset: 0x0003B632
		' (set) Token: 0x06007C62 RID: 31842 RVA: 0x0003D43C File Offset: 0x0003B63C
		Friend Overridable Property Label2 As Label

		' Token: 0x17002DA1 RID: 11681
		' (get) Token: 0x06007C63 RID: 31843 RVA: 0x0003D445 File Offset: 0x0003B645
		' (set) Token: 0x06007C64 RID: 31844 RVA: 0x005CFB3C File Offset: 0x005CDD3C
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DA2 RID: 11682
		' (get) Token: 0x06007C65 RID: 31845 RVA: 0x0003D44F File Offset: 0x0003B64F
		' (set) Token: 0x06007C66 RID: 31846 RVA: 0x005CFB80 File Offset: 0x005CDD80
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.listView1_KeyDown
				Dim columnWidthChangedEventHandler As ColumnWidthChangedEventHandler = AddressOf Me.listView1_ColumnWidthChanged
				Dim columnWidthChangingEventHandler As ColumnWidthChangingEventHandler = AddressOf Me.listView1_ColumnWidthChanging
				Dim mouseEventHandler2 As MouseEventHandler = AddressOf Me.listView1_MouseClick
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
					RemoveHandler listView.KeyDown, keyEventHandler
					RemoveHandler listView.ColumnWidthChanged, columnWidthChangedEventHandler
					RemoveHandler listView.ColumnWidthChanging, columnWidthChangingEventHandler
					RemoveHandler listView.MouseClick, mouseEventHandler2
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.MouseDoubleClick, mouseEventHandler
					AddHandler listView.KeyDown, keyEventHandler
					AddHandler listView.ColumnWidthChanged, columnWidthChangedEventHandler
					AddHandler listView.ColumnWidthChanging, columnWidthChangingEventHandler
					AddHandler listView.MouseClick, mouseEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002DA3 RID: 11683
		' (get) Token: 0x06007C67 RID: 31847 RVA: 0x0003D459 File Offset: 0x0003B659
		' (set) Token: 0x06007C68 RID: 31848 RVA: 0x0003D463 File Offset: 0x0003B663
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17002DA4 RID: 11684
		' (get) Token: 0x06007C69 RID: 31849 RVA: 0x0003D46C File Offset: 0x0003B66C
		' (set) Token: 0x06007C6A RID: 31850 RVA: 0x0003D476 File Offset: 0x0003B676
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17002DA5 RID: 11685
		' (get) Token: 0x06007C6B RID: 31851 RVA: 0x0003D47F File Offset: 0x0003B67F
		' (set) Token: 0x06007C6C RID: 31852 RVA: 0x0003D489 File Offset: 0x0003B689
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17002DA6 RID: 11686
		' (get) Token: 0x06007C6D RID: 31853 RVA: 0x0003D492 File Offset: 0x0003B692
		' (set) Token: 0x06007C6E RID: 31854 RVA: 0x0003D49C File Offset: 0x0003B69C
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17002DA7 RID: 11687
		' (get) Token: 0x06007C6F RID: 31855 RVA: 0x0003D4A5 File Offset: 0x0003B6A5
		' (set) Token: 0x06007C70 RID: 31856 RVA: 0x0003D4AF File Offset: 0x0003B6AF
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17002DA8 RID: 11688
		' (get) Token: 0x06007C71 RID: 31857 RVA: 0x0003D4B8 File Offset: 0x0003B6B8
		' (set) Token: 0x06007C72 RID: 31858 RVA: 0x0003D4C2 File Offset: 0x0003B6C2
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x17002DA9 RID: 11689
		' (get) Token: 0x06007C73 RID: 31859 RVA: 0x0003D4CB File Offset: 0x0003B6CB
		' (set) Token: 0x06007C74 RID: 31860 RVA: 0x0003D4D5 File Offset: 0x0003B6D5
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17002DAA RID: 11690
		' (get) Token: 0x06007C75 RID: 31861 RVA: 0x0003D4DE File Offset: 0x0003B6DE
		' (set) Token: 0x06007C76 RID: 31862 RVA: 0x0003D4E8 File Offset: 0x0003B6E8
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x17002DAB RID: 11691
		' (get) Token: 0x06007C77 RID: 31863 RVA: 0x0003D4F1 File Offset: 0x0003B6F1
		' (set) Token: 0x06007C78 RID: 31864 RVA: 0x0003D4FB File Offset: 0x0003B6FB
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x17002DAC RID: 11692
		' (get) Token: 0x06007C79 RID: 31865 RVA: 0x0003D504 File Offset: 0x0003B704
		' (set) Token: 0x06007C7A RID: 31866 RVA: 0x0003D50E File Offset: 0x0003B70E
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x17002DAD RID: 11693
		' (get) Token: 0x06007C7B RID: 31867 RVA: 0x0003D517 File Offset: 0x0003B717
		' (set) Token: 0x06007C7C RID: 31868 RVA: 0x0003D521 File Offset: 0x0003B721
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x17002DAE RID: 11694
		' (get) Token: 0x06007C7D RID: 31869 RVA: 0x0003D52A File Offset: 0x0003B72A
		' (set) Token: 0x06007C7E RID: 31870 RVA: 0x0003D534 File Offset: 0x0003B734
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x17002DAF RID: 11695
		' (get) Token: 0x06007C7F RID: 31871 RVA: 0x0003D53D File Offset: 0x0003B73D
		' (set) Token: 0x06007C80 RID: 31872 RVA: 0x0003D547 File Offset: 0x0003B747
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x17002DB0 RID: 11696
		' (get) Token: 0x06007C81 RID: 31873 RVA: 0x0003D550 File Offset: 0x0003B750
		' (set) Token: 0x06007C82 RID: 31874 RVA: 0x0003D55A File Offset: 0x0003B75A
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x17002DB1 RID: 11697
		' (get) Token: 0x06007C83 RID: 31875 RVA: 0x0003D563 File Offset: 0x0003B763
		' (set) Token: 0x06007C84 RID: 31876 RVA: 0x0003D56D File Offset: 0x0003B76D
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x17002DB2 RID: 11698
		' (get) Token: 0x06007C85 RID: 31877 RVA: 0x0003D576 File Offset: 0x0003B776
		' (set) Token: 0x06007C86 RID: 31878 RVA: 0x0003D580 File Offset: 0x0003B780
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x17002DB3 RID: 11699
		' (get) Token: 0x06007C87 RID: 31879 RVA: 0x0003D589 File Offset: 0x0003B789
		' (set) Token: 0x06007C88 RID: 31880 RVA: 0x0003D593 File Offset: 0x0003B793
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x17002DB4 RID: 11700
		' (get) Token: 0x06007C89 RID: 31881 RVA: 0x0003D59C File Offset: 0x0003B79C
		' (set) Token: 0x06007C8A RID: 31882 RVA: 0x0003D5A6 File Offset: 0x0003B7A6
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x17002DB5 RID: 11701
		' (get) Token: 0x06007C8B RID: 31883 RVA: 0x0003D5AF File Offset: 0x0003B7AF
		' (set) Token: 0x06007C8C RID: 31884 RVA: 0x005CFC40 File Offset: 0x005CDE40
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

		' Token: 0x17002DB6 RID: 11702
		' (get) Token: 0x06007C8D RID: 31885 RVA: 0x0003D5B9 File Offset: 0x0003B7B9
		' (set) Token: 0x06007C8E RID: 31886 RVA: 0x0003D5C3 File Offset: 0x0003B7C3
		Friend Overridable Property Label3 As Label

		' Token: 0x17002DB7 RID: 11703
		' (get) Token: 0x06007C8F RID: 31887 RVA: 0x0003D5CC File Offset: 0x0003B7CC
		' (set) Token: 0x06007C90 RID: 31888 RVA: 0x0003D5D6 File Offset: 0x0003B7D6
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x17002DB8 RID: 11704
		' (get) Token: 0x06007C91 RID: 31889 RVA: 0x0003D5DF File Offset: 0x0003B7DF
		' (set) Token: 0x06007C92 RID: 31890 RVA: 0x0003D5E9 File Offset: 0x0003B7E9
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x17002DB9 RID: 11705
		' (get) Token: 0x06007C93 RID: 31891 RVA: 0x0003D5F2 File Offset: 0x0003B7F2
		' (set) Token: 0x06007C94 RID: 31892 RVA: 0x0003D5FC File Offset: 0x0003B7FC
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x17002DBA RID: 11706
		' (get) Token: 0x06007C95 RID: 31893 RVA: 0x0003D605 File Offset: 0x0003B805
		' (set) Token: 0x06007C96 RID: 31894 RVA: 0x0003D60F File Offset: 0x0003B80F
		Friend Overridable Property Label6 As Label

		' Token: 0x17002DBB RID: 11707
		' (get) Token: 0x06007C97 RID: 31895 RVA: 0x0003D618 File Offset: 0x0003B818
		' (set) Token: 0x06007C98 RID: 31896 RVA: 0x0003D622 File Offset: 0x0003B822
		Friend Overridable Property Label7 As Label

		' Token: 0x17002DBC RID: 11708
		' (get) Token: 0x06007C99 RID: 31897 RVA: 0x0003D62B File Offset: 0x0003B82B
		' (set) Token: 0x06007C9A RID: 31898 RVA: 0x0003D635 File Offset: 0x0003B835
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17002DBD RID: 11709
		' (get) Token: 0x06007C9B RID: 31899 RVA: 0x0003D63E File Offset: 0x0003B83E
		' (set) Token: 0x06007C9C RID: 31900 RVA: 0x005CFC84 File Offset: 0x005CDE84
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

		' Token: 0x17002DBE RID: 11710
		' (get) Token: 0x06007C9D RID: 31901 RVA: 0x0003D648 File Offset: 0x0003B848
		' (set) Token: 0x06007C9E RID: 31902 RVA: 0x005CFCC8 File Offset: 0x005CDEC8
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
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

		' Token: 0x17002DBF RID: 11711
		' (get) Token: 0x06007C9F RID: 31903 RVA: 0x0003D652 File Offset: 0x0003B852
		' (set) Token: 0x06007CA0 RID: 31904 RVA: 0x005CFD0C File Offset: 0x005CDF0C
		Private _btnStatus As GelButton
		Friend Overridable Property btnStatus As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnStatus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnStatus_Click
				Dim gelButton As GelButton = Me._btnStatus
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnStatus = value
				gelButton = Me._btnStatus
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DC0 RID: 11712
		' (get) Token: 0x06007CA1 RID: 31905 RVA: 0x0003D65C File Offset: 0x0003B85C
		' (set) Token: 0x06007CA2 RID: 31906 RVA: 0x0003D666 File Offset: 0x0003B866
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x17002DC1 RID: 11713
		' (get) Token: 0x06007CA3 RID: 31907 RVA: 0x0003D66F File Offset: 0x0003B86F
		' (set) Token: 0x06007CA4 RID: 31908 RVA: 0x0003D679 File Offset: 0x0003B879
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002DC2 RID: 11714
		' (get) Token: 0x06007CA5 RID: 31909 RVA: 0x0003D682 File Offset: 0x0003B882
		' (set) Token: 0x06007CA6 RID: 31910 RVA: 0x0003D68C File Offset: 0x0003B88C
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x17002DC3 RID: 11715
		' (get) Token: 0x06007CA7 RID: 31911 RVA: 0x0003D695 File Offset: 0x0003B895
		' (set) Token: 0x06007CA8 RID: 31912 RVA: 0x005CFD50 File Offset: 0x005CDF50
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

		' Token: 0x17002DC4 RID: 11716
		' (get) Token: 0x06007CA9 RID: 31913 RVA: 0x0003D69F File Offset: 0x0003B89F
		' (set) Token: 0x06007CAA RID: 31914 RVA: 0x005CFD94 File Offset: 0x005CDF94
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

		' Token: 0x17002DC5 RID: 11717
		' (get) Token: 0x06007CAB RID: 31915 RVA: 0x0003D6A9 File Offset: 0x0003B8A9
		' (set) Token: 0x06007CAC RID: 31916 RVA: 0x0003D6B3 File Offset: 0x0003B8B3
		Friend Overridable Property cBoxLangs As ComboBox

		' Token: 0x17002DC6 RID: 11718
		' (get) Token: 0x06007CAD RID: 31917 RVA: 0x0003D6BC File Offset: 0x0003B8BC
		' (set) Token: 0x06007CAE RID: 31918 RVA: 0x005CFDD8 File Offset: 0x005CDFD8
		Private _btnPrevious As Button
		Friend Overridable Property btnPrevious As Button
			<CompilerGenerated()>
			Get
				Return Me._btnPrevious
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._btnPrevious
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnPrevious = value
				button = Me._btnPrevious
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DC7 RID: 11719
		' (get) Token: 0x06007CAF RID: 31919 RVA: 0x0003D6C6 File Offset: 0x0003B8C6
		' (set) Token: 0x06007CB0 RID: 31920 RVA: 0x005CFE1C File Offset: 0x005CE01C
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
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

		' Token: 0x17002DC8 RID: 11720
		' (get) Token: 0x06007CB1 RID: 31921 RVA: 0x0003D6D0 File Offset: 0x0003B8D0
		' (set) Token: 0x06007CB2 RID: 31922 RVA: 0x005CFE60 File Offset: 0x005CE060
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click_1
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

		' Token: 0x17002DC9 RID: 11721
		' (get) Token: 0x06007CB3 RID: 31923 RVA: 0x0003D6DA File Offset: 0x0003B8DA
		' (set) Token: 0x06007CB4 RID: 31924 RVA: 0x0003D6E4 File Offset: 0x0003B8E4
		Friend Overridable Property lblPageInfo As Label

		' Token: 0x17002DCA RID: 11722
		' (get) Token: 0x06007CB5 RID: 31925 RVA: 0x0003D6ED File Offset: 0x0003B8ED
		' (set) Token: 0x06007CB6 RID: 31926 RVA: 0x0003D6F7 File Offset: 0x0003B8F7
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x17002DCB RID: 11723
		' (get) Token: 0x06007CB7 RID: 31927 RVA: 0x0003D700 File Offset: 0x0003B900
		' (set) Token: 0x06007CB8 RID: 31928 RVA: 0x005CFEA4 File Offset: 0x005CE0A4
		Private _btnProductSeting As GelButton
		Friend Overridable Property btnProductSeting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnProductSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductSeting_Click
				Dim gelButton As GelButton = Me._btnProductSeting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnProductSeting = value
				gelButton = Me._btnProductSeting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DCC RID: 11724
		' (get) Token: 0x06007CB9 RID: 31929 RVA: 0x0003D70A File Offset: 0x0003B90A
		' (set) Token: 0x06007CBA RID: 31930 RVA: 0x0003D714 File Offset: 0x0003B914
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x17002DCD RID: 11725
		' (get) Token: 0x06007CBB RID: 31931 RVA: 0x0003D71D File Offset: 0x0003B91D
		' (set) Token: 0x06007CBC RID: 31932 RVA: 0x0003D727 File Offset: 0x0003B927
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x17002DCE RID: 11726
		' (get) Token: 0x06007CBD RID: 31933 RVA: 0x0003D730 File Offset: 0x0003B930
		' (set) Token: 0x06007CBE RID: 31934 RVA: 0x005CFEE8 File Offset: 0x005CE0E8
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

		' Token: 0x17002DCF RID: 11727
		' (get) Token: 0x06007CBF RID: 31935 RVA: 0x0003D73A File Offset: 0x0003B93A
		' (set) Token: 0x06007CC0 RID: 31936 RVA: 0x005CFF2C File Offset: 0x005CE12C
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

		' Token: 0x17002DD0 RID: 11728
		' (get) Token: 0x06007CC1 RID: 31937 RVA: 0x0003D744 File Offset: 0x0003B944
		' (set) Token: 0x06007CC2 RID: 31938 RVA: 0x005CFF70 File Offset: 0x005CE170
		Private _btnChangebarcode As GelButton
		Friend Overridable Property btnChangebarcode As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnChangebarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnChangebarcode_Click
				Dim gelButton As GelButton = Me._btnChangebarcode
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnChangebarcode = value
				gelButton = Me._btnChangebarcode
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DD1 RID: 11729
		' (get) Token: 0x06007CC3 RID: 31939 RVA: 0x0003D74E File Offset: 0x0003B94E
		' (set) Token: 0x06007CC4 RID: 31940 RVA: 0x005CFFB4 File Offset: 0x005CE1B4
		Private _cmbGST As ComboBox
		Friend Overridable Property cmbGST As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbGST_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbGST
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbGST = value
				comboBox = Me._cmbGST
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DD2 RID: 11730
		' (get) Token: 0x06007CC5 RID: 31941 RVA: 0x0003D758 File Offset: 0x0003B958
		' (set) Token: 0x06007CC6 RID: 31942 RVA: 0x0003D762 File Offset: 0x0003B962
		Friend Overridable Property Label37 As Label

		' Token: 0x17002DD3 RID: 11731
		' (get) Token: 0x06007CC7 RID: 31943 RVA: 0x0003D76B File Offset: 0x0003B96B
		' (set) Token: 0x06007CC8 RID: 31944 RVA: 0x0003D775 File Offset: 0x0003B975
		Friend Overridable Property cmbGST_ As ComboBox

		' Token: 0x17002DD4 RID: 11732
		' (get) Token: 0x06007CC9 RID: 31945 RVA: 0x0003D77E File Offset: 0x0003B97E
		' (set) Token: 0x06007CCA RID: 31946 RVA: 0x0003D788 File Offset: 0x0003B988
		Friend Overridable Property Label4 As Label

		' Token: 0x17002DD5 RID: 11733
		' (get) Token: 0x06007CCB RID: 31947 RVA: 0x0003D791 File Offset: 0x0003B991
		' (set) Token: 0x06007CCC RID: 31948 RVA: 0x0003D79B File Offset: 0x0003B99B
		Friend Overridable Property Label5 As Label

		' Token: 0x17002DD6 RID: 11734
		' (get) Token: 0x06007CCD RID: 31949 RVA: 0x0003D7A4 File Offset: 0x0003B9A4
		' (set) Token: 0x06007CCE RID: 31950 RVA: 0x005CFFF8 File Offset: 0x005CE1F8
		Private _txtHsncode As TextBox
		Friend Overridable Property txtHsncode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtHsncode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtHsncode_KeyDown
				Dim textBox As TextBox = Me._txtHsncode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtHsncode = value
				textBox = Me._txtHsncode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DD7 RID: 11735
		' (get) Token: 0x06007CCF RID: 31951 RVA: 0x0003D7AE File Offset: 0x0003B9AE
		' (set) Token: 0x06007CD0 RID: 31952 RVA: 0x005D003C File Offset: 0x005CE23C
		Private _BtnGelApply As GelButton
		Friend Overridable Property BtnGelApply As GelButton
			<CompilerGenerated()>
			Get
				Return Me._BtnGelApply
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.BtnGelApply_Click
				Dim gelButton As GelButton = Me._BtnGelApply
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._BtnGelApply = value
				gelButton = Me._BtnGelApply
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DD8 RID: 11736
		' (get) Token: 0x06007CD1 RID: 31953 RVA: 0x0003D7B8 File Offset: 0x0003B9B8
		' (set) Token: 0x06007CD2 RID: 31954 RVA: 0x005D0080 File Offset: 0x005CE280
		Private _btnGelSearch As GelButton
		Friend Overridable Property btnGelSearch As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGelSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGelSearch_Click
				Dim gelButton As GelButton = Me._btnGelSearch
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGelSearch = value
				gelButton = Me._btnGelSearch
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002DD9 RID: 11737
		' (get) Token: 0x06007CD3 RID: 31955 RVA: 0x0003D7C2 File Offset: 0x0003B9C2
		' (set) Token: 0x06007CD4 RID: 31956 RVA: 0x005D00C4 File Offset: 0x005CE2C4
		Private _chkGst_Load As CheckBox
		Friend Overridable Property chkGst_Load As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkGst_Load
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkGst_Load_CheckedChanged
				Dim checkBox As CheckBox = Me._chkGst_Load
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkGst_Load = value
				checkBox = Me._chkGst_Load
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06007CD5 RID: 31957 RVA: 0x005D0108 File Offset: 0x005CE308
		Private Sub frmProductBulkUpdate_Load(sender As Object, e As EventArgs)
			Me.GetTotalRecords()
			Me.GetData(False)
			Me.chkGst_Load.Checked = True
			Me.cmbGST.SelectedIndex = 0
			Me.cmbGST_.SelectedIndex = 0
			Me.txtHsncode.Text = ""
			Me.LoadLanguage()
			Me.Convert_Language()
		End Sub

		' Token: 0x06007CD6 RID: 31958 RVA: 0x005D016C File Offset: 0x005CE36C
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
						Dim checked As Boolean = Me.chkGst_Load.Checked
						If checked Then
							Dim flag As Boolean = (Operators.CompareString(dataRow(0).ToString(), "12", False) = 0) Or (Operators.CompareString(dataRow(0).ToString(), "28", False) = 0)
							If flag Then
								Me.cmbGST.Items.Add(dataRow(0).ToString())
							End If
						Else
							Me.cmbGST.Items.Add(dataRow(0).ToString())
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.cmbGST_.Items.Clear()
				Try
					For Each obj2 As Object In ModCommonClasses.dtable.Rows
						Dim dataRow2 As DataRow = CType(obj2, DataRow)
						Dim flag2 As Boolean = (Operators.CompareString(dataRow2(0).ToString(), "5", False) = 0) Or (Operators.CompareString(dataRow2(0).ToString(), "18", False) = 0)
						If flag2 Then
							Me.cmbGST_.Items.Add(dataRow2(0).ToString())
						End If
					Next
				Finally
					Dim enumerator2 As IEnumerator
					If TypeOf enumerator2 Is IDisposable Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007CD7 RID: 31959 RVA: 0x005D03FC File Offset: 0x005CE5FC
		Private Sub SetColumnVisibilityAndTextFromDatabase()
			Dim text As String = "SELECT menu_name, (case when is_active=0 then 1 else 0 end) as is_active FROM Bulk_product_menu_setting"
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlConnection.Open()
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim text2 As String = sqlDataReader("menu_name").ToString()
							Dim text3 As String = sqlDataReader("menu_name").ToString()
							Dim flag As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(sqlDataReader("is_active")))
							Try
								For Each obj As Object In Me.listView1.Columns
									Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
									Dim flag2 As Boolean = (Operators.CompareString(columnHeader.Text, "", False) = 0) Or (Operators.CompareString(columnHeader.Text, text2, False) = 0)
									If flag2 Then
										columnHeader.Text = text3
										columnHeader.Width = If(flag, 100, 0)
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x06007CD8 RID: 31960 RVA: 0x005D05A8 File Offset: 0x005CE7A8
		Private Sub GetTotalRecords()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT COUNT(*) FROM Product, Temp_Stock WHERE Temp_Stock.ProductID = Product.PID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Me.totalRecords = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				Me.totalPages = CInt(Math.Ceiling(CDbl(Me.totalRecords) / CDbl(Me.pageSize)))
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007CD9 RID: 31961 RVA: 0x005D0660 File Offset: 0x005CE860
		Public Sub LoadLanguage()
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
		End Sub

		' Token: 0x06007CDA RID: 31962 RVA: 0x005D06E0 File Offset: 0x005CE8E0
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
						Me.UpdateControlsRecursive(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06007CDB RID: 31963 RVA: 0x005D0858 File Offset: 0x005CEA58
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

		' Token: 0x06007CDC RID: 31964 RVA: 0x005D0914 File Offset: 0x005CEB14
		Private Sub UpdateControlsRecursive(parent As Control)
			Try
				For Each obj As Object In parent.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateControlsRecursive(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06007CDD RID: 31965 RVA: 0x000B726C File Offset: 0x000B546C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(dataGridViewColumn.HeaderText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(dataGridViewColumn.HeaderText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06007CDE RID: 31966 RVA: 0x000B72F4 File Offset: 0x000B54F4
		Private Sub UpdateListViewHeaders(lv As ListView)
			Try
				For Each obj As Object In lv.Columns
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
			Try
				For Each obj2 As Object In lv.Items
					Dim listViewItem As ListViewItem = CType(obj2, ListViewItem)
					Dim flag2 As Boolean = GlobalVariables.translations.ContainsKey(listViewItem.Text)
					If flag2 Then
						listViewItem.Text = GlobalVariables.translations(listViewItem.Text)
					End If
					Try
						For Each obj3 As Object In listViewItem.SubItems
							Dim listViewSubItem As ListViewItem.ListViewSubItem = CType(obj3, ListViewItem.ListViewSubItem)
							Dim flag3 As Boolean = GlobalVariables.translations.ContainsKey(listViewSubItem.Text)
							If flag3 Then
								listViewSubItem.Text = GlobalVariables.translations(listViewSubItem.Text)
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
		End Sub

		' Token: 0x06007CDF RID: 31967 RVA: 0x005D09C0 File Offset: 0x005CEBC0
		Public Sub GetData(Optional showAll As Boolean = False)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				If showAll Then
					Dim text As String = "Select PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),Temp_Stock.QrBarcode,SalesManPur, Loyality_mode, Loyality_value, ROW_NUMBER() OVER (ORDER BY PID) AS RowNum from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID order by PID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Else
					Dim text As String = "WITH Paging AS (Select PID, RTRIM(Product.ProductCode) as ProductCode,RTRIM(Temp_Stock.Barcode) as Barcode,RTRIM(Productname)as Productname, RTRIM(HSNCode)as HSNCode,RTRIM(PartNo) as PartNo, RTRIM(Description) as Description, CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit) as PurchaseUnit,RTRIM(Salesunit) as Salesunit,RTRIM(SalesAltUnit) as SalesAltUnit,RTRIM(Conv) as Conv,RTRIM(MinStock) as MinStock,RTRIM(GDown) as GDown,RTRIM(Rack)as Rack,RTRIM(DefQty)as DefQty,(Temp_Stock.PPrice),(Temp_Stock.MRP) as MRP1,(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch) as Batch,RTRIM(Temp_Stock.Mfgdate) as Mfgdate,RTRIM(Temp_Stock.Expdate) as Expdate,RTRIM(Temp_Stock.Colour) as Colour,RTRIM(Temp_Stock.Size) as Size,RTRIM(Temp_Stock.IMEI1) as IMEI1,RTRIM(Temp_Stock.IMEI2) as IMEI2,RTRIM(Product.Status)as Status,Temp_Stock.QrBarcode,SalesManPur, Loyality_mode, Loyality_value,  ROW_NUMBER() OVER (ORDER BY PID) AS RowNum from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID) SELECT * FROM Paging WHERE RowNum BETWEEN @startRow AND @endRow"
					Dim num As Integer = (Me.pageIndex - 1) * Me.pageSize + 1
					Dim num2 As Integer = Me.pageIndex * Me.pageSize
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@startRow", num)
					ModCommonClasses.cmd.Parameters.AddWithValue("@endRow", num2)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					Dim num3 As Integer = 1
					Do
						listViewItem.SubItems.Add(ModCommonClasses.rdr(num3).ToString().Trim())
						num3 += 1
					Loop While num3 <= 39
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num4 As Integer = 0
				Dim num5 As Integer = Me.listView1.Items.Count - 1
				Dim num6 As Integer = num4
				While True
					Dim num7 As Integer = num6
					Dim num8 As Integer = num5
					Dim flag As Boolean = num7 > num8
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num6).Checked = False
					num6 += 1
				End While
				ModCommonClasses.rdr.Close()
				Me.lblPageInfo.Text = "Page " + Conversions.ToString(Me.pageIndex) + " of " + Conversions.ToString(Me.totalPages)
				Me.btnPrevious.Enabled = Me.pageIndex > 1
				Me.btnNext.Enabled = Me.pageIndex < Me.totalPages
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x06007CE0 RID: 31968 RVA: 0x005D0C6C File Offset: 0x005CEE6C
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num - 3 <= 35 Then
					' The following expression was wrapped in a checked-statement
					Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
					Dim width As Integer = Me.CurrentSB.Bounds.Width
					Dim textBox As TextBox = Me.TextBox42
					textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
					textBox.Text = Me.CurrentSB.Text
					textBox.Show()
					textBox.Focus()
				End If
			End If
		End Sub

		' Token: 0x06007CE1 RID: 31969 RVA: 0x005D0D98 File Offset: 0x005CEF98
		Private Sub TextBox42_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox42.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Me.TextBox42.Text.Trim(), "", False) <> 0
				Dim flag4 As Boolean = flag3
				If flag4 Then
					Me.CurrentSB.Text = Me.TextBox42.Text
					Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
					flag3 = num = 2
					Dim flag5 As Boolean = flag3
					If flag5 Then
					End If
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x06007CE2 RID: 31970 RVA: 0x005D0E40 File Offset: 0x005CF040
		Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(keyChar), vbCr, False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
				Dim listView As ListView = Me.listView1
				Me.listView1 = listView
			Else
				flag = keyChar = ChrW(27)
				Dim flag3 As Boolean = flag
				If flag3 Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			End If
		End Sub

		' Token: 0x06007CE3 RID: 31971 RVA: 0x005D0EC8 File Offset: 0x005CF0C8
		Private Sub listView1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Dim keyCode As Keys = e.KeyCode
				flag = (keyCode = Keys.[Return]) Or (keyCode = Keys.F2)
				Dim flag3 As Boolean = flag
				If flag3 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x06007CE4 RID: 31972 RVA: 0x005D0F30 File Offset: 0x005CF130
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x06007CE5 RID: 31973 RVA: 0x005D0F84 File Offset: 0x005CF184
		Private Sub Updatelistdata(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text10 As String
			Dim text11 As String
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select Unit from UnitMaster where Unit=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", pListView.Items(num4).SubItems(15).Text.ToString())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Unit is not found from record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							pListView.Items(num4).SubItems(15).Text = ""
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
					Catch ex As Exception
					End Try
					Me.Generate_GiftQR(pListView.Items(num4).SubItems(2).Text.Replace("'", "''"))
					Dim flag5 As Boolean = Operators.CompareString(pListView.Items(num4).SubItems(15).Text, pListView.Items(num4).SubItems(16).Text, False) <> 0
					If flag5 Then
						MessageBox.Show("Some products are not updated due to purchase and sale units are same,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim text2 As String = pListView.Items(num4).SubItems(36).Text
						text2 = text2.Replace("'", "''")
						Dim flag6 As Boolean = String.IsNullOrWhiteSpace(text2)
						If flag6 Then
							text2 = "0.00"
						End If
						Dim text3 As String = If(String.IsNullOrEmpty(pListView.Items(num4).SubItems(38).Text), "0", pListView.Items(num4).SubItems(38).Text.Replace("'", "''"))
						Dim text4 As String = String.Concat(New String() { "UPDATE Product SET ProductName= N'", pListView.Items(num4).SubItems(3).Text.Replace("'", "''"), "', HSNCode = N'", pListView.Items(num4).SubItems(4).Text, "', PartNo = N'", pListView.Items(num4).SubItems(5).Text.Replace("'", "''"), "', Description = N'", pListView.Items(num4).SubItems(6).Text.Replace("'", "''"), "', CostPrice = N'", pListView.Items(num4).SubItems(7).Text.Replace("'", "''"), "', MRP = N'", pListView.Items(num4).SubItems(8).Text.Replace("'", "''"), "', SellingPrice = N'", pListView.Items(num4).SubItems(9).Text.Replace("'", "''"), "', ReorderPoint = N'", pListView.Items(num4).SubItems(10).Text.Replace("'", "''"), "', Discount = N'", pListView.Items(num4).SubItems(11).Text.Replace("'", "''"), "', CGST = N'", pListView.Items(num4).SubItems(12).Text.Replace("'", "''"), "', SGST = N'", pListView.Items(num4).SubItems(13).Text.Replace("'", "''"), "', CESS = N'", pListView.Items(num4).SubItems(14).Text.Replace("'", "''"), "', PurchaseUnit = N'", pListView.Items(num4).SubItems(15).Text.Replace("'", "''"), "', Salesunit = N'", pListView.Items(num4).SubItems(16).Text, "', SalesAltUnit = N'", pListView.Items(num4).SubItems(17).Text.Replace("'", "''"), "', Conv = N'", pListView.Items(num4).SubItems(18).Text.Replace("'", "''"), "', MinStock = N'", pListView.Items(num4).SubItems(19).Text.Replace("'", "''"), "', Gdown = N'", pListView.Items(num4).SubItems(20).Text.Replace("'", "''"), "', Rack = N'", pListView.Items(num4).SubItems(21).Text.Replace("'", "''"), "', DefQty = N'", pListView.Items(num4).SubItems(22).Text.Replace("'", "''"), "', loyality_mode = N'", pListView.Items(num4).SubItems(37).Text.Replace("'", "''"), "', loyality_value = N'", text3, "' WHERE PID = N'", pListView.Items(num4).SubItems(0).Text.Replace("'", "''"), "' and ProductCode = N'", pListView.Items(num4).SubItems(1).Text.Replace("'", "''"), "'" })
						Dim text5 As String = String.Concat(New String() { "Update Temp_Stock set PPrice= N'", pListView.Items(num4).SubItems(7).Text.Replace("'", "''"), "',EPPrice= N'", pListView.Items(num4).SubItems(7).Text.Replace("'", "''"), "', MRP= N'", pListView.Items(num4).SubItems(8).Text.Replace("'", "''"), "', SalePrice = N'", pListView.Items(num4).SubItems(9).Text.Replace("'", "''"), "',SPrice = N'", pListView.Items(num4).SubItems(9).Text.Replace("'", "''"), "', WPrice = N'", pListView.Items(num4).SubItems(26).Text.Replace("'", "''"), "', Batch = N'", pListView.Items(num4).SubItems(27).Text.Replace("'", "''"), "', Mfgdate = N'", pListView.Items(num4).SubItems(28).Text.Replace("'", "''"), "', Expdate = N'", pListView.Items(num4).SubItems(29).Text.Replace("'", "''"), "', Colour = N'", pListView.Items(num4).SubItems(30).Text.Replace("'", "''"), "', Size = N'", pListView.Items(num4).SubItems(31).Text.Replace("'", "''"), "', IMEI1 = N'", pListView.Items(num4).SubItems(32).Text.Replace("'", "''"), "', IMEI2 = N'", pListView.Items(num4).SubItems(33).Text.Replace("'", "''"), "',QrBarcode=@d19,SalesManPur = N'", text2, "' WHERE ProductID = N'", pListView.Items(num4).SubItems(0).Text.Replace("'", "''"), "' and Barcode = N'", pListView.Items(num4).SubItems(2).Text.Replace("'", "''"), "'" })
						Dim text6 As String = String.Concat(New String() { "Update Product_OpeningStock set PPrice= N'", pListView.Items(num4).SubItems(23).Text.Replace("'", "''"), "', MRP= N'", pListView.Items(num4).SubItems(24).Text.Replace("'", "''"), "', SalePrice = N'", pListView.Items(num4).SubItems(25).Text.Replace("'", "''"), "', WSalePrice = N'", pListView.Items(num4).SubItems(26).Text.Replace("'", "''"), "', Batch = N'", pListView.Items(num4).SubItems(27).Text.Replace("'", "''"), "', Mfgdate = N'", pListView.Items(num4).SubItems(28).Text.Replace("'", "''"), "', Expdate = N'", pListView.Items(num4).SubItems(29).Text.Replace("'", "''"), "', Colour = N'", pListView.Items(num4).SubItems(30).Text.Replace("'", "''"), "', Size = N'", pListView.Items(num4).SubItems(31).Text.Replace("'", "''"), "', IMEI1 = N'", pListView.Items(num4).SubItems(32).Text.Replace("'", "''"), "', IMEI2 = N'", pListView.Items(num4).SubItems(33).Text.Replace("'", "''"), "' WHERE ProductID = N'", pListView.Items(num4).SubItems(0).Text.Replace("'", "''"), "' and Barcode = N'", pListView.Items(num4).SubItems(2).Text.Replace("'", "''"), "'" })
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(text5)
						Dim memoryStream As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
						bitmap.Save(memoryStream, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream.GetBuffer()
						Dim sqlParameter As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
						sqlParameter.Value = buffer
						ModCommonClasses.cmd.Parameters.Add(sqlParameter)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text7 As String = "delete from ExtDB1 where a1=@d1"
						ModCommonClasses.cmd = New SqlCommand(text7)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", pListView.Items(num4).SubItems(0).Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
						ModCommonClasses.cmd = New SqlCommand(text8)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", pListView.Items(num4).SubItems(0).Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", pListView.Items(num4).SubItems(16).Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
						ModCommonClasses.cmd = New SqlCommand(text9)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", pListView.Items(num4).SubItems(0).Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", pListView.Items(num4).SubItems(17).Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						Me.ExecNonQuery(text4)
						Me.ExecNonQuery(text6)
						text10 = text10 + pListView.Items(num4).SubItems(1).Text + ","
						text11 = text11 + pListView.Items(num4).SubItems(2).Text + ","
						pListView.Items(num4).Checked = False
						num += 1
					End If
				End If
				num4 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Record(s) Updated ", Conversions.ToString(num), ". Updated Product Code :     ", text10, " having Barcode : ", text11 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x06007CE6 RID: 31974 RVA: 0x005D2148 File Offset: 0x005D0348
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06007CE7 RID: 31975 RVA: 0x005D21CC File Offset: 0x005D03CC
		Public Function ExecNonQuery(cmdText As String) As Integer
			Dim num2 As Integer
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
				Dim num As Integer = sqlCommand.ExecuteNonQuery()
				sqlCommand.Dispose()
				sqlConnection.Close()
				num2 = num
			Catch ex As Exception
			End Try
			Return num2
		End Function

		' Token: 0x06007CE8 RID: 31976 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox42_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007CE9 RID: 31977 RVA: 0x005D2230 File Offset: 0x005D0430
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x06007CEA RID: 31978 RVA: 0x005D231C File Offset: 0x005D051C
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),Temp_Stock.QrBarcode,SalesManPur, Loyality_mode, Loyality_value, ROW_NUMBER() OVER (ORDER BY PID) AS RowNum from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID and Product.ProductName like N'%", Me.TextBox1.Text, "%' order by PID" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(27).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(37).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(38).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(39).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007CEB RID: 31979 RVA: 0x005D29D4 File Offset: 0x005D0BD4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),Temp_Stock.QrBarcode,SalesManPur, Loyality_mode, Loyality_value, ROW_NUMBER() OVER (ORDER BY PID) AS RowNum from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode like N'", Me.TextBox2.Text, "%' order by PID" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(27).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(37).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(38).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(39).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007CEC RID: 31980 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs)
		End Sub

		' Token: 0x06007CED RID: 31981 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs)
		End Sub

		' Token: 0x06007CEE RID: 31982 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProductBulkUpdate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06007CEF RID: 31983 RVA: 0x005D308C File Offset: 0x005D128C
		Private Sub UpdatelistdataActnDeact(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text3 As String
			Dim text4 As String
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Dim text As String = String.Concat(New String() { "UPDATE Product SET Status ='Yes' WHERE PID = N'", pListView.Items(num4).SubItems(0).Text, "' and ProductCode = N'", pListView.Items(num4).SubItems(1).Text, "'" })
						Me.ExecNonQuery(text)
					Else
						Dim text2 As String = String.Concat(New String() { "UPDATE Product SET Status ='No' WHERE PID = N'", pListView.Items(num4).SubItems(0).Text, "' and ProductCode = N'", pListView.Items(num4).SubItems(1).Text, "'" })
						Me.ExecNonQuery(text2)
					End If
					text3 = text3 + pListView.Items(num4).SubItems(1).Text + ","
					text4 = text4 + pListView.Items(num4).SubItems(2).Text + ","
					pListView.Items(num4).Checked = False
					num += 1
				End If
				num4 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Status Record(s) Updated ", Conversions.ToString(num), ". Updated Product Code :  ", text3, " having Barode : ", text4 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x06007CF0 RID: 31984 RVA: 0x005D3298 File Offset: 0x005D1498
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),Temp_Stock.QrBarcode,SalesManPur from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID and Product.Status=@d1 order by PID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(27).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007CF1 RID: 31985 RVA: 0x005D38E4 File Offset: 0x005D1AE4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim listView As ListView = Me.listView1
				Me.Updatelistdata(listView)
				Me.listView1 = listView
				Me.GetData(False)
				Me.chkSelectAll.Checked = False
			End If
		End Sub

		' Token: 0x06007CF2 RID: 31986 RVA: 0x005D3938 File Offset: 0x005D1B38
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.txtTopResult.Text = "50"
			Me.chkSelectAll.Checked = False
			Me.cmbGST.SelectedIndex = 0
			Me.cmbGST_.SelectedIndex = 0
			Me.txtHsncode.Text = ""
			Me.GetData(False)
		End Sub

		' Token: 0x06007CF3 RID: 31987 RVA: 0x005D39C8 File Offset: 0x005D1BC8
		Private Sub btnStatus_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim listView As ListView = Me.listView1
				Me.UpdatelistdataActnDeact(listView)
				Me.listView1 = listView
				Me.GetData(False)
				Me.chkSelectAll.Checked = False
			End If
		End Sub

		' Token: 0x06007CF4 RID: 31988 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_MouseClick(sender As Object, e As MouseEventArgs)
		End Sub

		' Token: 0x06007CF5 RID: 31989 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmProductBulkUpdate_Scroll(sender As Object, e As ScrollEventArgs)
		End Sub

		' Token: 0x06007CF6 RID: 31990 RVA: 0x005D3A1C File Offset: 0x005D1C1C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim list As List(Of Integer) = New List(Of Integer)()
			Try
				For Each obj As Object In Me.listView1.Items
					Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
					Dim checked As Boolean = listViewItem.Checked
					If checked Then
						Dim num As Integer = Conversions.ToInteger(listViewItem.SubItems(0).Text)
						list.Add(num)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim frmBLP As New frmBarcodeLabelPrinting() With { .CheckedValues = list } : frmBLP.ShowDialog()
		End Sub

		' Token: 0x06007CF7 RID: 31991 RVA: 0x005D3AC8 File Offset: 0x005D1CC8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Internet connection not found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
				Dim flag3 As Boolean = flag2
				If flag3 Then
					Dim listView As ListView = Me.listView1
					Me.UpdatelistdataLanguage(listView)
					Me.listView1 = listView
					Me.GetData(False)
					Me.chkSelectAll.Checked = False
				End If
			End If
		End Sub

		' Token: 0x06007CF8 RID: 31992 RVA: 0x005D3B3C File Offset: 0x005D1D3C
		Private Sub UpdatelistdataLanguage(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text6 As String
			Dim text7 As String
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Dim text As String = pListView.Items(num4).SubItems(3).Text
						Dim text2 As String = If((Me.cBoxLangs.SelectedItem IsNot Nothing), Me.cBoxLangs.SelectedItem.ToString(), String.Empty)
						Try
							Dim flag3 As Boolean = Me.transliterator IsNot Nothing AndAlso Not String.IsNullOrEmpty(text) AndAlso Not String.IsNullOrEmpty(text2)
							If flag3 Then
								Dim text3 As String = Me.transliterator.Translate(text, text2)
								Dim text4 As String = String.Join(" ", New String() { text3 })
								Dim text5 As String = String.Concat(New String() { "UPDATE Product SET Description =  N'", text4, "' WHERE PID = N'", pListView.Items(num4).SubItems(0).Text, "' and ProductCode = N'", pListView.Items(num4).SubItems(1).Text, "'" })
								Me.ExecNonQuery(text5)
							Else
								MessageBox.Show("Please ensure all fields are selected and initialized.")
							End If
						Catch ex As Exception
							MessageBox.Show("Error: " + ex.Message)
						End Try
					End If
					text6 = text6 + pListView.Items(num4).SubItems(1).Text + ","
					text7 = text7 + pListView.Items(num4).SubItems(2).Text + ","
					pListView.Items(num4).Checked = False
					num += 1
				End If
				num4 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Status Record(s) Updated ", Conversions.ToString(num), ". Updated Product Code :  ", text6, " having Barode : ", text7 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x06007CF9 RID: 31993 RVA: 0x005D3DD0 File Offset: 0x005D1FD0
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.pageIndex > 1
			If flag Then
				Me.pageIndex = Me.pageIndex - 1
				Me.GetData(False)
			End If
		End Sub

		' Token: 0x06007CFA RID: 31994 RVA: 0x005D3E04 File Offset: 0x005D2004
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.pageIndex < Me.totalPages
			If flag Then
				Me.pageIndex = Me.pageIndex + 1
				Me.GetData(False)
			End If
		End Sub

		' Token: 0x06007CFB RID: 31995 RVA: 0x0003D7CC File Offset: 0x0003B9CC
		Private Sub Button1_Click_1(sender As Object, e As EventArgs)
			Me.showAll = True
			Me.GetData(Me.showAll)
		End Sub

		' Token: 0x06007CFC RID: 31996 RVA: 0x0003D7E3 File Offset: 0x0003B9E3
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkProductSeting.ShowDialog()
		End Sub

		' Token: 0x06007CFD RID: 31997 RVA: 0x005D3E3C File Offset: 0x005D203C
		Private Sub UpdatelistdataLoyality(ByRef pListView As ListView)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			Dim text2 As String
			Dim num As Double
			If flag Then
				text2 = ModCommonClasses.rdr(1).ToString()
				num = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			Dim num2 As Integer = 0
			Dim num3 As Integer = 0
			Dim num4 As Integer = pListView.Items.Count - 1
			Dim num5 As Integer = num3
			Dim text4 As String
			Dim text5 As String
			While True
				Dim num6 As Integer = num5
				Dim num7 As Integer = num4
				Dim flag3 As Boolean = num6 > num7
				If flag3 Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num5).Checked
				Dim flag4 As Boolean = checked
				If flag4 Then
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Dim text3 As String = "UPDATE Product SET loyality_mode=@d1, loyality_value=@d2 WHERE PID = @PID AND ProductCode = @ProductCode"
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", text2)
								sqlCommand.Parameters.AddWithValue("@d2", num)
								sqlCommand.Parameters.AddWithValue("@PID", pListView.Items(num5).SubItems(0).Text)
								sqlCommand.Parameters.AddWithValue("@ProductCode", pListView.Items(num5).SubItems(1).Text)
								sqlConnection.Open()
								sqlCommand.ExecuteNonQuery()
							End Using
						End Using
					End If
					text4 = text4 + pListView.Items(num5).SubItems(1).Text + ","
					text5 = text5 + pListView.Items(num5).SubItems(2).Text + ","
					pListView.Items(num5).Checked = False
					num2 += 1
				End If
				num5 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Status Record(s) Updated ", Conversions.ToString(num2), ". Updated Product Code :  ", text4, " having Barode : ", text5 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x06007CFE RID: 31998 RVA: 0x005D4110 File Offset: 0x005D2310
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to update loyality record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim listView As ListView = Me.listView1
				Me.UpdatelistdataLoyality(listView)
				Me.listView1 = listView
				Me.GetData(False)
				Me.chkSelectAll.Checked = False
			End If
		End Sub

		' Token: 0x06007CFF RID: 31999 RVA: 0x0003D7F6 File Offset: 0x0003B9F6
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmLSetDefault.lbltype.Text = "bulk"
			MyProject.Forms.frmLSetDefault.ShowDialog()
		End Sub

		' Token: 0x06007D00 RID: 32000 RVA: 0x005D4164 File Offset: 0x005D2364
		Private Sub btnChangebarcode_Click(sender As Object, e As EventArgs)
			Dim list As List(Of String) = New List(Of String)()
			Try
				For Each obj As Object In Me.listView1.Items
					Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
					Dim checked As Boolean = listViewItem.Checked
					If checked Then
						list.Add(listViewItem.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim flag As Boolean = list.Count > 0
			If flag Then
				Dim frmChangeBarcode As frmChangeBarcode = New frmChangeBarcode(list)
				frmChangeBarcode.Show()
			Else
				MessageBox.Show("Please check at least one item.")
			End If
		End Sub

		' Token: 0x06007D01 RID: 32001 RVA: 0x005D4214 File Offset: 0x005D2414
		Private Sub UpdatelistdataGST_Rate(ByRef pListView As ListView)
			Dim flag As Boolean = String.IsNullOrWhiteSpace(Me.cmbGST.Text) OrElse Conversion.Val(Me.cmbGST.Text) = 0.0
			If flag Then
				MessageBox.Show("From GST value can't be empty or 0.")
				Me.cmbGST.Focus()
			Else
				Dim flag2 As Boolean = String.IsNullOrWhiteSpace(Me.cmbGST_.Text) OrElse Conversion.Val(Me.cmbGST_.Text) = 0.0
				If flag2 Then
					MessageBox.Show("To GST value can't be empty or 0.")
					Me.cmbGST_.Focus()
				Else
					Dim num As Double = Conversion.Val(Me.cmbGST.Text) / 2.0
					Dim num2 As Double = Conversion.Val(Me.cmbGST_.Text) / 2.0
					Dim num3 As Integer = 0
					Dim num4 As Integer = 0
					Dim num5 As Integer = pListView.Items.Count - 1
					Dim num6 As Integer = num4
					Dim text4 As String
					Dim text5 As String
					While True
						Dim num7 As Integer = num6
						Dim num8 As Integer = num5
						Dim flag3 As Boolean = num7 > num8
						If flag3 Then
							Exit While
						End If
						Dim checked As Boolean = pListView.Items(num6).Checked
						Dim flag4 As Boolean = checked
						If flag4 Then
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								Dim text As String = pListView.Items(num6).SubItems(3).Text
								Dim text2 As String = If((Me.cBoxLangs.SelectedItem IsNot Nothing), Me.cBoxLangs.SelectedItem.ToString(), String.Empty)
								Try
									Dim flag5 As Boolean = String.IsNullOrWhiteSpace(Me.txtHsncode.Text) OrElse Operators.CompareString(Me.txtHsncode.Text.Trim(), "0", False) = 0
									Dim text3 As String
									If flag5 Then
										text3 = String.Concat(New String() { String.Concat(New String() { "UPDATE Product SET CGST =  '", Conversions.ToString(num2), "', SGST =  '", Conversions.ToString(num2), "' WHERE CGST = N'" }), Conversions.ToString(num), "' and ProductCode = N'", pListView.Items(num6).SubItems(1).Text, "'" })
									Else
										text3 = String.Concat(New String() { String.Concat(New String() { "UPDATE Product SET CGST =  '", Conversions.ToString(num2), "', SGST =  '", Conversions.ToString(num2), "' WHERE CGST = N'" }), Conversions.ToString(num), "' and HSNCode = N'", Me.txtHsncode.Text, "' and ProductCode = N'", pListView.Items(num6).SubItems(1).Text, "'" })
									End If
									Me.ExecNonQuery(text3)
								Catch ex As Exception
									MessageBox.Show("Error: " + ex.Message)
								End Try
							End If
							text4 = text4 + pListView.Items(num6).SubItems(1).Text + ","
							text5 = text5 + pListView.Items(num6).SubItems(2).Text + ","
							pListView.Items(num6).Checked = False
							num3 += 1
						End If
						num6 += 1
					End While
					Interaction.MsgBox(String.Concat(New String() { "Total Status Record(s) Updated ", Conversions.ToString(num3), ". Updated Product Code :  ", text4, " having Barode : ", text5 }), MsgBoxStyle.OkOnly, Nothing)
				End If
			End If
		End Sub

		' Token: 0x06007D02 RID: 32002 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbGST_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007D03 RID: 32003 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtHsncode_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x06007D04 RID: 32004 RVA: 0x005D4620 File Offset: 0x005D2820
		Private Sub BtnGelApply_Click(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkGst_Load.Checked
			If checked Then
				Dim flag As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim listView As ListView = Me.listView1
					Me.UpdatelistdataGST_Rate(listView)
					Me.listView1 = listView
					Me.GetData(False)
					Me.chkSelectAll.Checked = False
					Me.cmbGST.SelectedIndex = 0
					Me.cmbGST_.SelectedIndex = 0
					Me.txtHsncode.Text = ""
				End If
			Else
				MessageBox.Show("GST Check Box must checked, before Update!")
				Me.chkGst_Load.Focus()
			End If
		End Sub

		' Token: 0x06007D05 RID: 32005 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnGSTUpdate_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007D06 RID: 32006 RVA: 0x005D46C8 File Offset: 0x005D28C8
		Private Sub btnGelSearch_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Double = Conversion.Val(Me.cmbGST.Text) / 2.0
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),Temp_Stock.QrBarcode,SalesManPur, Loyality_mode, Loyality_value, ROW_NUMBER() OVER (ORDER BY PID) AS RowNum from Product,Temp_Stock where Temp_Stock.ProductID=Product.PID and Product.CGST = @CGST and Product.HSNCode like '", Me.txtHsncode.Text, "%' order by PID" }), ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@CGST", num)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(27).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(37).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(38).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(39).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num2 As Integer = 0
				Dim num3 As Integer = Me.listView1.Items.Count - 1
				Dim num4 As Integer = num2
				While True
					Dim num5 As Integer = num4
					Dim num6 As Integer = num3
					Dim flag As Boolean = num5 > num6
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num4).Checked = False
					num4 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007D07 RID: 32007 RVA: 0x0003D82A File Offset: 0x0003BA2A
		Private Sub chkGst_Load_CheckedChanged(sender As Object, e As EventArgs)
			Me.fillTaxRate()
		End Sub

		' Token: 0x0400373C RID: 14140
		Private pageIndex As Integer

		' Token: 0x0400373D RID: 14141
		Private pageSize As Integer

		' Token: 0x0400373E RID: 14142
		Private totalRecords As Integer

		' Token: 0x0400373F RID: 14143
		Private totalPages As Integer

		' Token: 0x04003740 RID: 14144
		Private showAll As Boolean

		' Token: 0x04003741 RID: 14145
		Private transliterator As Transliterator

		' Token: 0x04003742 RID: 14146
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04003743 RID: 14147
		Private CurrentItem As ListViewItem

		' Token: 0x04003744 RID: 14148
		Private bCancelEdit As Boolean
	End Class
End Namespace
