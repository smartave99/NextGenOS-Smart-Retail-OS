Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000602 RID: 1538
	<DesignerGenerated()>
	Public Partial Class frmStockTransfer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012B74 RID: 76660 RVA: 0x0007FD3D File Offset: 0x0007DF3D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockTransfer_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockTransfer_KeyDown
			Me.counter = 0
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007415 RID: 29717
		' (get) Token: 0x06012B77 RID: 76663 RVA: 0x0007FD7A File Offset: 0x0007DF7A
		' (set) Token: 0x06012B78 RID: 76664 RVA: 0x0007FD84 File Offset: 0x0007DF84
		Friend Overridable Property Label21 As Label

		' Token: 0x17007416 RID: 29718
		' (get) Token: 0x06012B79 RID: 76665 RVA: 0x0007FD8D File Offset: 0x0007DF8D
		' (set) Token: 0x06012B7A RID: 76666 RVA: 0x00AC05F0 File Offset: 0x00ABE7F0
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

		' Token: 0x17007417 RID: 29719
		' (get) Token: 0x06012B7B RID: 76667 RVA: 0x0007FD97 File Offset: 0x0007DF97
		' (set) Token: 0x06012B7C RID: 76668 RVA: 0x0007FDA1 File Offset: 0x0007DFA1
		Friend Overridable Property lblUser As Label

		' Token: 0x17007418 RID: 29720
		' (get) Token: 0x06012B7D RID: 76669 RVA: 0x0007FDAA File Offset: 0x0007DFAA
		' (set) Token: 0x06012B7E RID: 76670 RVA: 0x0007FDB4 File Offset: 0x0007DFB4
		Friend Overridable Property lblUserType As Label

		' Token: 0x17007419 RID: 29721
		' (get) Token: 0x06012B7F RID: 76671 RVA: 0x0007FDBD File Offset: 0x0007DFBD
		' (set) Token: 0x06012B80 RID: 76672 RVA: 0x00AC0634 File Offset: 0x00ABE834
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim columnClickEventHandler As ColumnClickEventHandler = AddressOf Me.listView1_ColumnClick
				Dim columnWidthChangedEventHandler As ColumnWidthChangedEventHandler = AddressOf Me.listView1_ColumnWidthChanged
				Dim columnWidthChangingEventHandler As ColumnWidthChangingEventHandler = AddressOf Me.listView1_ColumnWidthChanging
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.listView1_KeyDown
				Dim mouseEventHandler2 As MouseEventHandler = AddressOf Me.listView1_MouseClick
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.ColumnClick, columnClickEventHandler
					RemoveHandler listView.ColumnWidthChanged, columnWidthChangedEventHandler
					RemoveHandler listView.ColumnWidthChanging, columnWidthChangingEventHandler
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
					RemoveHandler listView.KeyDown, keyEventHandler
					RemoveHandler listView.MouseClick, mouseEventHandler2
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.ColumnClick, columnClickEventHandler
					AddHandler listView.ColumnWidthChanged, columnWidthChangedEventHandler
					AddHandler listView.ColumnWidthChanging, columnWidthChangingEventHandler
					AddHandler listView.MouseDoubleClick, mouseEventHandler
					AddHandler listView.KeyDown, keyEventHandler
					AddHandler listView.MouseClick, mouseEventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700741A RID: 29722
		' (get) Token: 0x06012B81 RID: 76673 RVA: 0x0007FDC7 File Offset: 0x0007DFC7
		' (set) Token: 0x06012B82 RID: 76674 RVA: 0x0007FDD1 File Offset: 0x0007DFD1
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x1700741B RID: 29723
		' (get) Token: 0x06012B83 RID: 76675 RVA: 0x0007FDDA File Offset: 0x0007DFDA
		' (set) Token: 0x06012B84 RID: 76676 RVA: 0x0007FDE4 File Offset: 0x0007DFE4
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x1700741C RID: 29724
		' (get) Token: 0x06012B85 RID: 76677 RVA: 0x0007FDED File Offset: 0x0007DFED
		' (set) Token: 0x06012B86 RID: 76678 RVA: 0x0007FDF7 File Offset: 0x0007DFF7
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x1700741D RID: 29725
		' (get) Token: 0x06012B87 RID: 76679 RVA: 0x0007FE00 File Offset: 0x0007E000
		' (set) Token: 0x06012B88 RID: 76680 RVA: 0x0007FE0A File Offset: 0x0007E00A
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x1700741E RID: 29726
		' (get) Token: 0x06012B89 RID: 76681 RVA: 0x0007FE13 File Offset: 0x0007E013
		' (set) Token: 0x06012B8A RID: 76682 RVA: 0x0007FE1D File Offset: 0x0007E01D
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x1700741F RID: 29727
		' (get) Token: 0x06012B8B RID: 76683 RVA: 0x0007FE26 File Offset: 0x0007E026
		' (set) Token: 0x06012B8C RID: 76684 RVA: 0x0007FE30 File Offset: 0x0007E030
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17007420 RID: 29728
		' (get) Token: 0x06012B8D RID: 76685 RVA: 0x0007FE39 File Offset: 0x0007E039
		' (set) Token: 0x06012B8E RID: 76686 RVA: 0x0007FE43 File Offset: 0x0007E043
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17007421 RID: 29729
		' (get) Token: 0x06012B8F RID: 76687 RVA: 0x0007FE4C File Offset: 0x0007E04C
		' (set) Token: 0x06012B90 RID: 76688 RVA: 0x0007FE56 File Offset: 0x0007E056
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17007422 RID: 29730
		' (get) Token: 0x06012B91 RID: 76689 RVA: 0x0007FE5F File Offset: 0x0007E05F
		' (set) Token: 0x06012B92 RID: 76690 RVA: 0x0007FE69 File Offset: 0x0007E069
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17007423 RID: 29731
		' (get) Token: 0x06012B93 RID: 76691 RVA: 0x0007FE72 File Offset: 0x0007E072
		' (set) Token: 0x06012B94 RID: 76692 RVA: 0x0007FE7C File Offset: 0x0007E07C
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17007424 RID: 29732
		' (get) Token: 0x06012B95 RID: 76693 RVA: 0x0007FE85 File Offset: 0x0007E085
		' (set) Token: 0x06012B96 RID: 76694 RVA: 0x0007FE8F File Offset: 0x0007E08F
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17007425 RID: 29733
		' (get) Token: 0x06012B97 RID: 76695 RVA: 0x0007FE98 File Offset: 0x0007E098
		' (set) Token: 0x06012B98 RID: 76696 RVA: 0x0007FEA2 File Offset: 0x0007E0A2
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17007426 RID: 29734
		' (get) Token: 0x06012B99 RID: 76697 RVA: 0x0007FEAB File Offset: 0x0007E0AB
		' (set) Token: 0x06012B9A RID: 76698 RVA: 0x0007FEB5 File Offset: 0x0007E0B5
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17007427 RID: 29735
		' (get) Token: 0x06012B9B RID: 76699 RVA: 0x0007FEBE File Offset: 0x0007E0BE
		' (set) Token: 0x06012B9C RID: 76700 RVA: 0x0007FEC8 File Offset: 0x0007E0C8
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17007428 RID: 29736
		' (get) Token: 0x06012B9D RID: 76701 RVA: 0x0007FED1 File Offset: 0x0007E0D1
		' (set) Token: 0x06012B9E RID: 76702 RVA: 0x0007FEDB File Offset: 0x0007E0DB
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17007429 RID: 29737
		' (get) Token: 0x06012B9F RID: 76703 RVA: 0x0007FEE4 File Offset: 0x0007E0E4
		' (set) Token: 0x06012BA0 RID: 76704 RVA: 0x0007FEEE File Offset: 0x0007E0EE
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x1700742A RID: 29738
		' (get) Token: 0x06012BA1 RID: 76705 RVA: 0x0007FEF7 File Offset: 0x0007E0F7
		' (set) Token: 0x06012BA2 RID: 76706 RVA: 0x0007FF01 File Offset: 0x0007E101
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x1700742B RID: 29739
		' (get) Token: 0x06012BA3 RID: 76707 RVA: 0x0007FF0A File Offset: 0x0007E10A
		' (set) Token: 0x06012BA4 RID: 76708 RVA: 0x0007FF14 File Offset: 0x0007E114
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x1700742C RID: 29740
		' (get) Token: 0x06012BA5 RID: 76709 RVA: 0x0007FF1D File Offset: 0x0007E11D
		' (set) Token: 0x06012BA6 RID: 76710 RVA: 0x0007FF27 File Offset: 0x0007E127
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x1700742D RID: 29741
		' (get) Token: 0x06012BA7 RID: 76711 RVA: 0x0007FF30 File Offset: 0x0007E130
		' (set) Token: 0x06012BA8 RID: 76712 RVA: 0x0007FF3A File Offset: 0x0007E13A
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x1700742E RID: 29742
		' (get) Token: 0x06012BA9 RID: 76713 RVA: 0x0007FF43 File Offset: 0x0007E143
		' (set) Token: 0x06012BAA RID: 76714 RVA: 0x0007FF4D File Offset: 0x0007E14D
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x1700742F RID: 29743
		' (get) Token: 0x06012BAB RID: 76715 RVA: 0x0007FF56 File Offset: 0x0007E156
		' (set) Token: 0x06012BAC RID: 76716 RVA: 0x0007FF60 File Offset: 0x0007E160
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17007430 RID: 29744
		' (get) Token: 0x06012BAD RID: 76717 RVA: 0x0007FF69 File Offset: 0x0007E169
		' (set) Token: 0x06012BAE RID: 76718 RVA: 0x0007FF73 File Offset: 0x0007E173
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x17007431 RID: 29745
		' (get) Token: 0x06012BAF RID: 76719 RVA: 0x0007FF7C File Offset: 0x0007E17C
		' (set) Token: 0x06012BB0 RID: 76720 RVA: 0x0007FF86 File Offset: 0x0007E186
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x17007432 RID: 29746
		' (get) Token: 0x06012BB1 RID: 76721 RVA: 0x0007FF8F File Offset: 0x0007E18F
		' (set) Token: 0x06012BB2 RID: 76722 RVA: 0x0007FF99 File Offset: 0x0007E199
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x17007433 RID: 29747
		' (get) Token: 0x06012BB3 RID: 76723 RVA: 0x0007FFA2 File Offset: 0x0007E1A2
		' (set) Token: 0x06012BB4 RID: 76724 RVA: 0x0007FFAC File Offset: 0x0007E1AC
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x17007434 RID: 29748
		' (get) Token: 0x06012BB5 RID: 76725 RVA: 0x0007FFB5 File Offset: 0x0007E1B5
		' (set) Token: 0x06012BB6 RID: 76726 RVA: 0x0007FFBF File Offset: 0x0007E1BF
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x17007435 RID: 29749
		' (get) Token: 0x06012BB7 RID: 76727 RVA: 0x0007FFC8 File Offset: 0x0007E1C8
		' (set) Token: 0x06012BB8 RID: 76728 RVA: 0x0007FFD2 File Offset: 0x0007E1D2
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x17007436 RID: 29750
		' (get) Token: 0x06012BB9 RID: 76729 RVA: 0x0007FFDB File Offset: 0x0007E1DB
		' (set) Token: 0x06012BBA RID: 76730 RVA: 0x0007FFE5 File Offset: 0x0007E1E5
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x17007437 RID: 29751
		' (get) Token: 0x06012BBB RID: 76731 RVA: 0x0007FFEE File Offset: 0x0007E1EE
		' (set) Token: 0x06012BBC RID: 76732 RVA: 0x0007FFF8 File Offset: 0x0007E1F8
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x17007438 RID: 29752
		' (get) Token: 0x06012BBD RID: 76733 RVA: 0x00080001 File Offset: 0x0007E201
		' (set) Token: 0x06012BBE RID: 76734 RVA: 0x0008000B File Offset: 0x0007E20B
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x17007439 RID: 29753
		' (get) Token: 0x06012BBF RID: 76735 RVA: 0x00080014 File Offset: 0x0007E214
		' (set) Token: 0x06012BC0 RID: 76736 RVA: 0x0008001E File Offset: 0x0007E21E
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x1700743A RID: 29754
		' (get) Token: 0x06012BC1 RID: 76737 RVA: 0x00080027 File Offset: 0x0007E227
		' (set) Token: 0x06012BC2 RID: 76738 RVA: 0x00080031 File Offset: 0x0007E231
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x1700743B RID: 29755
		' (get) Token: 0x06012BC3 RID: 76739 RVA: 0x0008003A File Offset: 0x0007E23A
		' (set) Token: 0x06012BC4 RID: 76740 RVA: 0x00080044 File Offset: 0x0007E244
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x1700743C RID: 29756
		' (get) Token: 0x06012BC5 RID: 76741 RVA: 0x0008004D File Offset: 0x0007E24D
		' (set) Token: 0x06012BC6 RID: 76742 RVA: 0x00080057 File Offset: 0x0007E257
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x1700743D RID: 29757
		' (get) Token: 0x06012BC7 RID: 76743 RVA: 0x00080060 File Offset: 0x0007E260
		' (set) Token: 0x06012BC8 RID: 76744 RVA: 0x0008006A File Offset: 0x0007E26A
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x1700743E RID: 29758
		' (get) Token: 0x06012BC9 RID: 76745 RVA: 0x00080073 File Offset: 0x0007E273
		' (set) Token: 0x06012BCA RID: 76746 RVA: 0x00AC0714 File Offset: 0x00ABE914
		Private _btnRemove As GelButton
		Friend Overridable Property btnRemove As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim gelButton As GelButton = Me._btnRemove
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRemove = value
				gelButton = Me._btnRemove
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700743F RID: 29759
		' (get) Token: 0x06012BCB RID: 76747 RVA: 0x0008007D File Offset: 0x0007E27D
		' (set) Token: 0x06012BCC RID: 76748 RVA: 0x00AC0758 File Offset: 0x00ABE958
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

		' Token: 0x17007440 RID: 29760
		' (get) Token: 0x06012BCD RID: 76749 RVA: 0x00080087 File Offset: 0x0007E287
		' (set) Token: 0x06012BCE RID: 76750 RVA: 0x00AC079C File Offset: 0x00ABE99C
		Private _btnDToken As GelButton
		Friend Overridable Property btnDToken As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDToken
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDToken_Click
				Dim gelButton As GelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDToken = value
				gelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007441 RID: 29761
		' (get) Token: 0x06012BCF RID: 76751 RVA: 0x00080091 File Offset: 0x0007E291
		' (set) Token: 0x06012BD0 RID: 76752 RVA: 0x0008009B File Offset: 0x0007E29B
		Friend Overridable Property lblToken As Label

		' Token: 0x17007442 RID: 29762
		' (get) Token: 0x06012BD1 RID: 76753 RVA: 0x000800A4 File Offset: 0x0007E2A4
		' (set) Token: 0x06012BD2 RID: 76754 RVA: 0x000800AE File Offset: 0x0007E2AE
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17007443 RID: 29763
		' (get) Token: 0x06012BD3 RID: 76755 RVA: 0x000800B7 File Offset: 0x0007E2B7
		' (set) Token: 0x06012BD4 RID: 76756 RVA: 0x000800C1 File Offset: 0x0007E2C1
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x17007444 RID: 29764
		' (get) Token: 0x06012BD5 RID: 76757 RVA: 0x000800CA File Offset: 0x0007E2CA
		' (set) Token: 0x06012BD6 RID: 76758 RVA: 0x000800D4 File Offset: 0x0007E2D4
		Friend Overridable Property ColumnHeader39 As ColumnHeader

		' Token: 0x17007445 RID: 29765
		' (get) Token: 0x06012BD7 RID: 76759 RVA: 0x000800DD File Offset: 0x0007E2DD
		' (set) Token: 0x06012BD8 RID: 76760 RVA: 0x000800E7 File Offset: 0x0007E2E7
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x17007446 RID: 29766
		' (get) Token: 0x06012BD9 RID: 76761 RVA: 0x000800F0 File Offset: 0x0007E2F0
		' (set) Token: 0x06012BDA RID: 76762 RVA: 0x000800FA File Offset: 0x0007E2FA
		Friend Overridable Property TextBox42 As TextBox

		' Token: 0x17007447 RID: 29767
		' (get) Token: 0x06012BDB RID: 76763 RVA: 0x00080103 File Offset: 0x0007E303
		' (set) Token: 0x06012BDC RID: 76764 RVA: 0x0008010D File Offset: 0x0007E30D
		Friend Overridable Property TxtUpdateTQty As TextBox

		' Token: 0x17007448 RID: 29768
		' (get) Token: 0x06012BDD RID: 76765 RVA: 0x00080116 File Offset: 0x0007E316
		' (set) Token: 0x06012BDE RID: 76766 RVA: 0x00AC07E0 File Offset: 0x00ABE9E0
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

		' Token: 0x17007449 RID: 29769
		' (get) Token: 0x06012BDF RID: 76767 RVA: 0x00080120 File Offset: 0x0007E320
		' (set) Token: 0x06012BE0 RID: 76768 RVA: 0x0008012A File Offset: 0x0007E32A
		Friend Overridable Property txtBarcodeUpdate As TextBox

		' Token: 0x1700744A RID: 29770
		' (get) Token: 0x06012BE1 RID: 76769 RVA: 0x00080133 File Offset: 0x0007E333
		' (set) Token: 0x06012BE2 RID: 76770 RVA: 0x0008013D File Offset: 0x0007E33D
		Friend Overridable Property txtProduct As TextBox

		' Token: 0x1700744B RID: 29771
		' (get) Token: 0x06012BE3 RID: 76771 RVA: 0x00080146 File Offset: 0x0007E346
		' (set) Token: 0x06012BE4 RID: 76772 RVA: 0x00080150 File Offset: 0x0007E350
		Friend Overridable Property Label1 As Label

		' Token: 0x1700744C RID: 29772
		' (get) Token: 0x06012BE5 RID: 76773 RVA: 0x00080159 File Offset: 0x0007E359
		' (set) Token: 0x06012BE6 RID: 76774 RVA: 0x00080163 File Offset: 0x0007E363
		Friend Overridable Property Label2 As Label

		' Token: 0x1700744D RID: 29773
		' (get) Token: 0x06012BE7 RID: 76775 RVA: 0x0008016C File Offset: 0x0007E36C
		' (set) Token: 0x06012BE8 RID: 76776 RVA: 0x00080176 File Offset: 0x0007E376
		Friend Overridable Property Label3 As Label

		' Token: 0x1700744E RID: 29774
		' (get) Token: 0x06012BE9 RID: 76777 RVA: 0x0008017F File Offset: 0x0007E37F
		' (set) Token: 0x06012BEA RID: 76778 RVA: 0x00080189 File Offset: 0x0007E389
		Friend Overridable Property txtPid As TextBox

		' Token: 0x1700744F RID: 29775
		' (get) Token: 0x06012BEB RID: 76779 RVA: 0x00080192 File Offset: 0x0007E392
		' (set) Token: 0x06012BEC RID: 76780 RVA: 0x0008019C File Offset: 0x0007E39C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x06012BED RID: 76781 RVA: 0x00AC0824 File Offset: 0x00ABEA24
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select count(*) from Setting Having count(*) >= 1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Please configure Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							MyProject.Forms.frmTaxSetting.ShowDialog()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "select Barcode from Temp_Stock where Barcode=@d1"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag6 As Boolean = Not ModCommonClasses.rdr.Read()
							If flag6 Then
								MessageBox.Show("Barcode is not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.txtBarcode.Focus()
								Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag7 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "select Temp_Stock.Barcode from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d2 and NOT Status=@d1"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
								If flag8 Then
									MessageBox.Show("You are not allowed to retrieve deactivated Product", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.txtBarcode.Text = ""
									Me.txtBarcode.Focus()
									Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag9 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									Me.Getdata(Me.txtBarcode.Text)
									Me.txtBarcode.Text = ""
									Me.txtBarcode.Focus()
									Me.txtBar.Visible = False
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("KETY DOWN  " + ex.ToString())
			End Try
		End Sub

		' Token: 0x06012BEE RID: 76782 RVA: 0x00AC0BC8 File Offset: 0x00ABEDC8
		Private Function AddItem() As Object
			Try
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
					listViewItem.SubItems.Add(Conversions.ToString(1))
					listViewItem.SubItems.Add(Me.lblToken.Text)
					listViewItem.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.rdr.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012BEF RID: 76783 RVA: 0x00AC1154 File Offset: 0x00ABF354
		Public Sub Getdata(barcode As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = False
				Dim num As Integer = 0
				Dim text As String = Nothing
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select PID, RTRIM(Product.ProductCode),RTRIM(Temp_Stock.Barcode),RTRIM(Productname), RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,Product.MRP,SellingPrice,ReorderPoint, Discount,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(GDown),RTRIM(Rack),RTRIM(DefQty),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Product.Status),RTRIM(SubCategory.Category),RTRIM(SubCategory.SubCategoryName) from Product,Temp_Stock,SubCategory where Temp_Stock.Barcode = '" + barcode + "' and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID order by PID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim count As Integer = Me.listView1.Items.Count
				Try
					For Each obj As Object In Me.listView1.Items
						Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
						Dim text2 As String = listViewItem.SubItems(2).Text
						text = listViewItem.SubItems(35).Text
						Dim flag2 As Boolean = Operators.CompareString(text2, barcode, False) = 0
						If flag2 Then
							flag = True
							num = Me.listView1.Items.IndexOf(listViewItem)
							Me.counter = Integer.Parse(text) + 1
							Exit For
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = count > 0
				If flag3 Then
					Dim flag4 As Boolean = flag
					If flag4 Then
						Me.counter = Integer.Parse(text) + 1
						Dim listViewItem2 As ListViewItem = Me.listView1.Items(num)
						listViewItem2.SubItems(35).Text = Conversions.ToString(Me.counter)
					Else
						Me.AddItem()
					End If
				Else
					Me.AddItem()
				End If
				Dim num2 As Integer = 0
				Dim num3 As Integer = Me.listView1.Items.Count - 1
				Dim num4 As Integer = num2
				While True
					Dim num5 As Integer = num4
					Dim num6 As Integer = num3
					Dim flag5 As Boolean = num5 > num6
					If flag5 Then
						Exit While
					End If
					Me.listView1.Items(num4).Checked = False
					num4 += 1
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012BF0 RID: 76784 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnClick(sender As Object, e As ColumnClickEventArgs)
		End Sub

		' Token: 0x06012BF1 RID: 76785 RVA: 0x00AC1398 File Offset: 0x00ABF598
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to Remove record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.RemoveCheckedItems()
				Me.chkSelectAll.Checked = False
			End If
		End Sub

		' Token: 0x06012BF2 RID: 76786 RVA: 0x00AC13D4 File Offset: 0x00ABF5D4
		Private Sub RemoveCheckedItems()
			Dim list As List(Of ListViewItem) = New List(Of ListViewItem)()
			Try
				For Each obj As Object In Me.listView1.Items
					Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
					Dim checked As Boolean = listViewItem.Checked
					If checked Then
						list.Add(listViewItem)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				For Each listViewItem2 As ListViewItem In list
					Me.listView1.Items.Remove(listViewItem2)
				Next
			Finally
				Dim enumerator2 As List(Of ListViewItem).Enumerator
				CType(enumerator2, IDisposable).Dispose()
			End Try
		End Sub

		' Token: 0x06012BF3 RID: 76787 RVA: 0x00AC14A4 File Offset: 0x00ABF6A4
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

		' Token: 0x06012BF4 RID: 76788 RVA: 0x00AC1590 File Offset: 0x00ABF790
		Private Sub btnDToken_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.listView1.Items.Count > 0
				If flag Then
					Try
						For Each obj As Object In Me.listView1.Items
							Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "insert into P_Transfer(PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,TocknNo,T_Qty,Category,SubCategoryName,PStatus ) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39)"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(listViewItem.SubItems(0).Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", listViewItem.SubItems(1).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", listViewItem.SubItems(2).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", listViewItem.SubItems(3).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", listViewItem.SubItems(4).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", listViewItem.SubItems(5).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", listViewItem.SubItems(6).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", listViewItem.SubItems(7).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", listViewItem.SubItems(8).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", listViewItem.SubItems(9).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", listViewItem.SubItems(10).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", listViewItem.SubItems(11).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", listViewItem.SubItems(12).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", listViewItem.SubItems(13).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", listViewItem.SubItems(14).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", listViewItem.SubItems(15).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", listViewItem.SubItems(16).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", listViewItem.SubItems(17).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d18", listViewItem.SubItems(18).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d19", listViewItem.SubItems(19).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d20", listViewItem.SubItems(20).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d21", listViewItem.SubItems(21).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d22", listViewItem.SubItems(22).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d23", listViewItem.SubItems(23).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d24", listViewItem.SubItems(24).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d25", listViewItem.SubItems(25).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d26", listViewItem.SubItems(26).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d27", listViewItem.SubItems(27).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d28", listViewItem.SubItems(28).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d29", listViewItem.SubItems(29).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d30", listViewItem.SubItems(30).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d31", listViewItem.SubItems(31).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d32", listViewItem.SubItems(32).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d33", listViewItem.SubItems(33).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d34", listViewItem.SubItems(34).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d35", Me.lblToken.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d36", listViewItem.SubItems(35).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d37", listViewItem.SubItems(37).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d38", listViewItem.SubItems(38).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d39", "p")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							Me.CheckBarcodeExists(listViewItem.SubItems(2).Text, Conversions.ToDouble(listViewItem.SubItems(35).Text))
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Tokan Create")
					Me.txtBarcode.Text = ""
					Me.TxtUpdateTQty.Text = ""
					Me.txtBarcodeUpdate.Text = ""
					Me.txtPid.Text = ""
					Me.txtProduct.Text = ""
					Me.txtBarcode.Focus()
					Me.txtBar.Visible = False
					Me.TxtUpdateTQty.[ReadOnly] = False
					Me.GelButton1.Enabled = False
					Me.listView1.Items.Clear()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x06012BF5 RID: 76789 RVA: 0x00AC1D84 File Offset: 0x00ABFF84
		Public Function CheckBarcodeExists(barcode As String, TQty As Double) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select ProductID,Barcode from Temp_Stock where Barcode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", barcode)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "update Temp_stock set qty = qty - (" + Conversions.ToString(TQty) + ") where ProductID=@d1 and Barcode=@d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(ModCommonClasses.rdr(0).ToString()))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", barcode)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012BF6 RID: 76790 RVA: 0x00AC1F04 File Offset: 0x00AC0104
		Public Sub GenerateTokan()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.lblToken.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012BF7 RID: 76791 RVA: 0x00AC1F88 File Offset: 0x00AC0188
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

		' Token: 0x06012BF8 RID: 76792 RVA: 0x00AC2070 File Offset: 0x00AC0270
		Private Function GenerateID1() As String
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TOP 1 ID FROM P_Transfer ORDER BY ID DESC", sqlConnection)
				Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = sqlDataReader.HasRows
				If hasRows Then
					sqlDataReader.Read()
					text = Conversions.ToString(sqlDataReader("ID"))
				End If
				sqlDataReader.Close()
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
				Dim flag4 As Boolean = sqlConnection.State = ConnectionState.Open
				If flag4 Then
					sqlConnection.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06012BF9 RID: 76793 RVA: 0x00AC21B4 File Offset: 0x00AC03B4
		Private Sub frmStockTransfer_Load(sender As Object, e As EventArgs)
			Me.GenerateTokan()
			Me.txtBarcode.Text = ""
			Me.TxtUpdateTQty.Text = ""
			Me.txtBarcodeUpdate.Text = ""
			Me.txtPid.Text = ""
			Me.txtProduct.Text = ""
			Me.txtBarcode.Focus()
			Me.txtBar.Visible = False
			Me.TxtUpdateTQty.[ReadOnly] = True
			Me.GelButton1.Enabled = False
			Me.btnRemove.Enabled = False
			Me.listView1.Items.Clear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06012BFA RID: 76794 RVA: 0x00AC2278 File Offset: 0x00AC0478
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

		' Token: 0x06012BFB RID: 76795 RVA: 0x00AC23F0 File Offset: 0x00AC05F0
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

		' Token: 0x06012BFC RID: 76796 RVA: 0x00AC24AC File Offset: 0x00AC06AC
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

		' Token: 0x06012BFD RID: 76797 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06012BFE RID: 76798 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012BFF RID: 76799 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012C00 RID: 76800 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs)
		End Sub

		' Token: 0x06012C01 RID: 76801 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs)
		End Sub

		' Token: 0x06012C02 RID: 76802 RVA: 0x00AC2578 File Offset: 0x00AC0778
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num = 35 Then
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

		' Token: 0x06012C03 RID: 76803 RVA: 0x00AC26A0 File Offset: 0x00AC08A0
		Public Function checkAvailableStock(transferquantity As Decimal, barcode As String, productID As Integer, prooductName As String) As Object
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.ReadCS())
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1 and Barcode=@d2", sqlConnection)
				sqlCommand.Parameters.AddWithValue("@d1", productID)
				sqlCommand.Parameters.AddWithValue("@d2", barcode)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet)
				Dim flag As Boolean = dataSet.Tables(0).Rows.Count > 0
				If flag Then
					transferquantity = New Decimal(productID)
					Dim flag2 As Boolean = -(Conversions.ToDouble(barcode) > Convert.ToDouble(transferquantity) > False) > False
					If flag2 Then
						Dim flag3 As Boolean = MessageBox.Show(String.Concat(New String() { "Added qty. to cart are more than" & vbCrLf & "available qty. of Product Name='", MyBase.ProductName, "' having Barcode='", barcode, "'" }), "Are you confirm to proceed ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
						If flag3 Then
						End If
					End If
				End If
				sqlConnection.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012C04 RID: 76804 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x06012C05 RID: 76805 RVA: 0x00AC27D8 File Offset: 0x00AC09D8
		Private Sub listView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim num As Integer = Me.listView1.Items.IndexOf(Me.listView1.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.listView1.Items(num)
				Dim num2 As Decimal = Decimal.Parse(listViewItem.SubItems(35).Text, NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite)
				Dim text As String = listViewItem.SubItems(2).Text
				Dim num3 As Integer = Conversions.ToInteger(listViewItem.SubItems(0).Text)
				Dim text2 As String = listViewItem.SubItems(3).Text
				Me.txtBarcodeUpdate.Text = listViewItem.SubItems(2).Text
				Me.txtProduct.Text = listViewItem.SubItems(3).Text
				Me.TxtUpdateTQty.Text = listViewItem.SubItems(35).Text
				Me.txtPid.Text = listViewItem.SubItems(0).Text
				Me.GelButton1.Enabled = True
				Me.TxtUpdateTQty.[ReadOnly] = False
				Me.btnRemove.Enabled = True
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012C06 RID: 76806 RVA: 0x00AC2954 File Offset: 0x00AC0B54
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.listView1.Items.IndexOf(Me.listView1.SelectedItems(0))
			Dim listViewItem As ListViewItem = Me.listView1.Items(num)
			listViewItem.SubItems(35).Text = Me.TxtUpdateTQty.Text
			Me.checkAvailableStock(Conversions.ToDecimal(Me.TxtUpdateTQty.Text), Me.txtBarcodeUpdate.Text, Conversions.ToInteger(Me.txtPid.Text), Me.txtProduct.Text)
			Me.txtBarcode.Text = ""
			Me.TxtUpdateTQty.Text = ""
			Me.txtBarcodeUpdate.Text = ""
			Me.txtPid.Text = ""
			Me.txtProduct.Text = ""
			Me.txtBarcode.Focus()
			Me.txtBar.Visible = False
			Me.TxtUpdateTQty.[ReadOnly] = True
			Me.GelButton1.Enabled = False
			Me.btnRemove.Enabled = False
		End Sub

		' Token: 0x06012C07 RID: 76807 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmStockTransfer_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x040070E7 RID: 28903
		Private counter As Integer

		' Token: 0x040070E8 RID: 28904
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x040070E9 RID: 28905
		Private CurrentItem As ListViewItem
	End Class
End Namespace
