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
	' Token: 0x020001D6 RID: 470
	<DesignerGenerated()>
	Public Partial Class frmProductBulkUpdate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007D08 RID: 32008 RVA: 0x005D4DE0 File Offset: 0x005D2FE0
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

		' Token: 0x17002DDA RID: 11738
		' (get) Token: 0x06007D0B RID: 32011 RVA: 0x0003D834 File Offset: 0x0003BA34
		' (set) Token: 0x06007D0C RID: 32012 RVA: 0x0003D83E File Offset: 0x0003BA3E
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17002DDB RID: 11739
		' (get) Token: 0x06007D0D RID: 32013 RVA: 0x0003D847 File Offset: 0x0003BA47
		' (set) Token: 0x06007D0E RID: 32014 RVA: 0x0003D851 File Offset: 0x0003BA51
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17002DDC RID: 11740
		' (get) Token: 0x06007D0F RID: 32015 RVA: 0x0003D85A File Offset: 0x0003BA5A
		' (set) Token: 0x06007D10 RID: 32016 RVA: 0x0003D864 File Offset: 0x0003BA64
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17002DDD RID: 11741
		' (get) Token: 0x06007D11 RID: 32017 RVA: 0x0003D86D File Offset: 0x0003BA6D
		' (set) Token: 0x06007D12 RID: 32018 RVA: 0x0003D877 File Offset: 0x0003BA77
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17002DDE RID: 11742
		' (get) Token: 0x06007D13 RID: 32019 RVA: 0x0003D880 File Offset: 0x0003BA80
		' (set) Token: 0x06007D14 RID: 32020 RVA: 0x0003D88A File Offset: 0x0003BA8A
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17002DDF RID: 11743
		' (get) Token: 0x06007D15 RID: 32021 RVA: 0x0003D893 File Offset: 0x0003BA93
		' (set) Token: 0x06007D16 RID: 32022 RVA: 0x0003D89D File Offset: 0x0003BA9D
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17002DE0 RID: 11744
		' (get) Token: 0x06007D17 RID: 32023 RVA: 0x0003D8A6 File Offset: 0x0003BAA6
		' (set) Token: 0x06007D18 RID: 32024 RVA: 0x0003D8B0 File Offset: 0x0003BAB0
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17002DE1 RID: 11745
		' (get) Token: 0x06007D19 RID: 32025 RVA: 0x0003D8B9 File Offset: 0x0003BAB9
		' (set) Token: 0x06007D1A RID: 32026 RVA: 0x0003D8C3 File Offset: 0x0003BAC3
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17002DE2 RID: 11746
		' (get) Token: 0x06007D1B RID: 32027 RVA: 0x0003D8CC File Offset: 0x0003BACC
		' (set) Token: 0x06007D1C RID: 32028 RVA: 0x0003D8D6 File Offset: 0x0003BAD6
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17002DE3 RID: 11747
		' (get) Token: 0x06007D1D RID: 32029 RVA: 0x0003D8DF File Offset: 0x0003BADF
		' (set) Token: 0x06007D1E RID: 32030 RVA: 0x0003D8E9 File Offset: 0x0003BAE9
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17002DE4 RID: 11748
		' (get) Token: 0x06007D1F RID: 32031 RVA: 0x0003D8F2 File Offset: 0x0003BAF2
		' (set) Token: 0x06007D20 RID: 32032 RVA: 0x0003D8FC File Offset: 0x0003BAFC
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17002DE5 RID: 11749
		' (get) Token: 0x06007D21 RID: 32033 RVA: 0x0003D905 File Offset: 0x0003BB05
		' (set) Token: 0x06007D22 RID: 32034 RVA: 0x0003D90F File Offset: 0x0003BB0F
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17002DE6 RID: 11750
		' (get) Token: 0x06007D23 RID: 32035 RVA: 0x0003D918 File Offset: 0x0003BB18
		' (set) Token: 0x06007D24 RID: 32036 RVA: 0x0003D922 File Offset: 0x0003BB22
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17002DE7 RID: 11751
		' (get) Token: 0x06007D25 RID: 32037 RVA: 0x0003D92B File Offset: 0x0003BB2B
		' (set) Token: 0x06007D26 RID: 32038 RVA: 0x0003D935 File Offset: 0x0003BB35
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17002DE8 RID: 11752
		' (get) Token: 0x06007D27 RID: 32039 RVA: 0x0003D93E File Offset: 0x0003BB3E
		' (set) Token: 0x06007D28 RID: 32040 RVA: 0x005D7254 File Offset: 0x005D5454
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

		' Token: 0x17002DE9 RID: 11753
		' (get) Token: 0x06007D29 RID: 32041 RVA: 0x0003D948 File Offset: 0x0003BB48
		' (set) Token: 0x06007D2A RID: 32042 RVA: 0x005D72D0 File Offset: 0x005D54D0
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

		' Token: 0x17002DEA RID: 11754
		' (get) Token: 0x06007D2B RID: 32043 RVA: 0x0003D952 File Offset: 0x0003BB52
		' (set) Token: 0x06007D2C RID: 32044 RVA: 0x005D7314 File Offset: 0x005D5514
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

		' Token: 0x17002DEB RID: 11755
		' (get) Token: 0x06007D2D RID: 32045 RVA: 0x0003D95C File Offset: 0x0003BB5C
		' (set) Token: 0x06007D2E RID: 32046 RVA: 0x0003D966 File Offset: 0x0003BB66
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17002DEC RID: 11756
		' (get) Token: 0x06007D2F RID: 32047 RVA: 0x0003D96F File Offset: 0x0003BB6F
		' (set) Token: 0x06007D30 RID: 32048 RVA: 0x0003D979 File Offset: 0x0003BB79
		Friend Overridable Property Label1 As Label

		' Token: 0x17002DED RID: 11757
		' (get) Token: 0x06007D31 RID: 32049 RVA: 0x0003D982 File Offset: 0x0003BB82
		' (set) Token: 0x06007D32 RID: 32050 RVA: 0x0003D98C File Offset: 0x0003BB8C
		Friend Overridable Property Label2 As Label

		' Token: 0x17002DEE RID: 11758
		' (get) Token: 0x06007D33 RID: 32051 RVA: 0x0003D995 File Offset: 0x0003BB95
		' (set) Token: 0x06007D34 RID: 32052 RVA: 0x005D7358 File Offset: 0x005D5558
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

		' Token: 0x17002DEF RID: 11759
		' (get) Token: 0x06007D35 RID: 32053 RVA: 0x0003D99F File Offset: 0x0003BB9F
		' (set) Token: 0x06007D36 RID: 32054 RVA: 0x005D739C File Offset: 0x005D559C
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

		' Token: 0x17002DF0 RID: 11760
		' (get) Token: 0x06007D37 RID: 32055 RVA: 0x0003D9A9 File Offset: 0x0003BBA9
		' (set) Token: 0x06007D38 RID: 32056 RVA: 0x0003D9B3 File Offset: 0x0003BBB3
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17002DF1 RID: 11761
		' (get) Token: 0x06007D39 RID: 32057 RVA: 0x0003D9BC File Offset: 0x0003BBBC
		' (set) Token: 0x06007D3A RID: 32058 RVA: 0x0003D9C6 File Offset: 0x0003BBC6
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17002DF2 RID: 11762
		' (get) Token: 0x06007D3B RID: 32059 RVA: 0x0003D9CF File Offset: 0x0003BBCF
		' (set) Token: 0x06007D3C RID: 32060 RVA: 0x0003D9D9 File Offset: 0x0003BBD9
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17002DF3 RID: 11763
		' (get) Token: 0x06007D3D RID: 32061 RVA: 0x0003D9E2 File Offset: 0x0003BBE2
		' (set) Token: 0x06007D3E RID: 32062 RVA: 0x0003D9EC File Offset: 0x0003BBEC
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17002DF4 RID: 11764
		' (get) Token: 0x06007D3F RID: 32063 RVA: 0x0003D9F5 File Offset: 0x0003BBF5
		' (set) Token: 0x06007D40 RID: 32064 RVA: 0x0003D9FF File Offset: 0x0003BBFF
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17002DF5 RID: 11765
		' (get) Token: 0x06007D41 RID: 32065 RVA: 0x0003DA08 File Offset: 0x0003BC08
		' (set) Token: 0x06007D42 RID: 32066 RVA: 0x0003DA12 File Offset: 0x0003BC12
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x17002DF6 RID: 11766
		' (get) Token: 0x06007D43 RID: 32067 RVA: 0x0003DA1B File Offset: 0x0003BC1B
		' (set) Token: 0x06007D44 RID: 32068 RVA: 0x0003DA25 File Offset: 0x0003BC25
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17002DF7 RID: 11767
		' (get) Token: 0x06007D45 RID: 32069 RVA: 0x0003DA2E File Offset: 0x0003BC2E
		' (set) Token: 0x06007D46 RID: 32070 RVA: 0x0003DA38 File Offset: 0x0003BC38
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x17002DF8 RID: 11768
		' (get) Token: 0x06007D47 RID: 32071 RVA: 0x0003DA41 File Offset: 0x0003BC41
		' (set) Token: 0x06007D48 RID: 32072 RVA: 0x0003DA4B File Offset: 0x0003BC4B
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x17002DF9 RID: 11769
		' (get) Token: 0x06007D49 RID: 32073 RVA: 0x0003DA54 File Offset: 0x0003BC54
		' (set) Token: 0x06007D4A RID: 32074 RVA: 0x0003DA5E File Offset: 0x0003BC5E
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x17002DFA RID: 11770
		' (get) Token: 0x06007D4B RID: 32075 RVA: 0x0003DA67 File Offset: 0x0003BC67
		' (set) Token: 0x06007D4C RID: 32076 RVA: 0x0003DA71 File Offset: 0x0003BC71
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x17002DFB RID: 11771
		' (get) Token: 0x06007D4D RID: 32077 RVA: 0x0003DA7A File Offset: 0x0003BC7A
		' (set) Token: 0x06007D4E RID: 32078 RVA: 0x0003DA84 File Offset: 0x0003BC84
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x17002DFC RID: 11772
		' (get) Token: 0x06007D4F RID: 32079 RVA: 0x0003DA8D File Offset: 0x0003BC8D
		' (set) Token: 0x06007D50 RID: 32080 RVA: 0x0003DA97 File Offset: 0x0003BC97
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x17002DFD RID: 11773
		' (get) Token: 0x06007D51 RID: 32081 RVA: 0x0003DAA0 File Offset: 0x0003BCA0
		' (set) Token: 0x06007D52 RID: 32082 RVA: 0x0003DAAA File Offset: 0x0003BCAA
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x17002DFE RID: 11774
		' (get) Token: 0x06007D53 RID: 32083 RVA: 0x0003DAB3 File Offset: 0x0003BCB3
		' (set) Token: 0x06007D54 RID: 32084 RVA: 0x0003DABD File Offset: 0x0003BCBD
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x17002DFF RID: 11775
		' (get) Token: 0x06007D55 RID: 32085 RVA: 0x0003DAC6 File Offset: 0x0003BCC6
		' (set) Token: 0x06007D56 RID: 32086 RVA: 0x0003DAD0 File Offset: 0x0003BCD0
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x17002E00 RID: 11776
		' (get) Token: 0x06007D57 RID: 32087 RVA: 0x0003DAD9 File Offset: 0x0003BCD9
		' (set) Token: 0x06007D58 RID: 32088 RVA: 0x0003DAE3 File Offset: 0x0003BCE3
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x17002E01 RID: 11777
		' (get) Token: 0x06007D59 RID: 32089 RVA: 0x0003DAEC File Offset: 0x0003BCEC
		' (set) Token: 0x06007D5A RID: 32090 RVA: 0x0003DAF6 File Offset: 0x0003BCF6
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x17002E02 RID: 11778
		' (get) Token: 0x06007D5B RID: 32091 RVA: 0x0003DAFF File Offset: 0x0003BCFF
		' (set) Token: 0x06007D5C RID: 32092 RVA: 0x005D745C File Offset: 0x005D565C
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

		' Token: 0x17002E03 RID: 11779
		' (get) Token: 0x06007D5D RID: 32093 RVA: 0x0003DB09 File Offset: 0x0003BD09
		' (set) Token: 0x06007D5E RID: 32094 RVA: 0x0003DB13 File Offset: 0x0003BD13
		Friend Overridable Property Label3 As Label

		' Token: 0x17002E04 RID: 11780
		' (get) Token: 0x06007D5F RID: 32095 RVA: 0x0003DB1C File Offset: 0x0003BD1C
		' (set) Token: 0x06007D60 RID: 32096 RVA: 0x0003DB26 File Offset: 0x0003BD26
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x17002E05 RID: 11781
		' (get) Token: 0x06007D61 RID: 32097 RVA: 0x0003DB2F File Offset: 0x0003BD2F
		' (set) Token: 0x06007D62 RID: 32098 RVA: 0x0003DB39 File Offset: 0x0003BD39
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x17002E06 RID: 11782
		' (get) Token: 0x06007D63 RID: 32099 RVA: 0x0003DB42 File Offset: 0x0003BD42
		' (set) Token: 0x06007D64 RID: 32100 RVA: 0x0003DB4C File Offset: 0x0003BD4C
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x17002E07 RID: 11783
		' (get) Token: 0x06007D65 RID: 32101 RVA: 0x0003DB55 File Offset: 0x0003BD55
		' (set) Token: 0x06007D66 RID: 32102 RVA: 0x0003DB5F File Offset: 0x0003BD5F
		Friend Overridable Property Label6 As Label

		' Token: 0x17002E08 RID: 11784
		' (get) Token: 0x06007D67 RID: 32103 RVA: 0x0003DB68 File Offset: 0x0003BD68
		' (set) Token: 0x06007D68 RID: 32104 RVA: 0x0003DB72 File Offset: 0x0003BD72
		Friend Overridable Property Label7 As Label

		' Token: 0x17002E09 RID: 11785
		' (get) Token: 0x06007D69 RID: 32105 RVA: 0x0003DB7B File Offset: 0x0003BD7B
		' (set) Token: 0x06007D6A RID: 32106 RVA: 0x0003DB85 File Offset: 0x0003BD85
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17002E0A RID: 11786
		' (get) Token: 0x06007D6B RID: 32107 RVA: 0x0003DB8E File Offset: 0x0003BD8E
		' (set) Token: 0x06007D6C RID: 32108 RVA: 0x005D74A0 File Offset: 0x005D56A0
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

		' Token: 0x17002E0B RID: 11787
		' (get) Token: 0x06007D6D RID: 32109 RVA: 0x0003DB98 File Offset: 0x0003BD98
		' (set) Token: 0x06007D6E RID: 32110 RVA: 0x005D74E4 File Offset: 0x005D56E4
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

		' Token: 0x17002E0C RID: 11788
		' (get) Token: 0x06007D6F RID: 32111 RVA: 0x0003DBA2 File Offset: 0x0003BDA2
		' (set) Token: 0x06007D70 RID: 32112 RVA: 0x005D7528 File Offset: 0x005D5728
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

		' Token: 0x17002E0D RID: 11789
		' (get) Token: 0x06007D71 RID: 32113 RVA: 0x0003DBAC File Offset: 0x0003BDAC
		' (set) Token: 0x06007D72 RID: 32114 RVA: 0x0003DBB6 File Offset: 0x0003BDB6
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x17002E0E RID: 11790
		' (get) Token: 0x06007D73 RID: 32115 RVA: 0x0003DBBF File Offset: 0x0003BDBF
		' (set) Token: 0x06007D74 RID: 32116 RVA: 0x0003DBC9 File Offset: 0x0003BDC9
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002E0F RID: 11791
		' (get) Token: 0x06007D75 RID: 32117 RVA: 0x0003DBD2 File Offset: 0x0003BDD2
		' (set) Token: 0x06007D76 RID: 32118 RVA: 0x0003DBDC File Offset: 0x0003BDDC
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x17002E10 RID: 11792
		' (get) Token: 0x06007D77 RID: 32119 RVA: 0x0003DBE5 File Offset: 0x0003BDE5
		' (set) Token: 0x06007D78 RID: 32120 RVA: 0x005D756C File Offset: 0x005D576C
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

		' Token: 0x17002E11 RID: 11793
		' (get) Token: 0x06007D79 RID: 32121 RVA: 0x0003DBEF File Offset: 0x0003BDEF
		' (set) Token: 0x06007D7A RID: 32122 RVA: 0x005D75B0 File Offset: 0x005D57B0
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

		' Token: 0x17002E12 RID: 11794
		' (get) Token: 0x06007D7B RID: 32123 RVA: 0x0003DBF9 File Offset: 0x0003BDF9
		' (set) Token: 0x06007D7C RID: 32124 RVA: 0x0003DC03 File Offset: 0x0003BE03
		Friend Overridable Property cBoxLangs As ComboBox

		' Token: 0x17002E13 RID: 11795
		' (get) Token: 0x06007D7D RID: 32125 RVA: 0x0003DC0C File Offset: 0x0003BE0C
		' (set) Token: 0x06007D7E RID: 32126 RVA: 0x005D75F4 File Offset: 0x005D57F4
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

		' Token: 0x17002E14 RID: 11796
		' (get) Token: 0x06007D7F RID: 32127 RVA: 0x0003DC16 File Offset: 0x0003BE16
		' (set) Token: 0x06007D80 RID: 32128 RVA: 0x005D7638 File Offset: 0x005D5838
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

		' Token: 0x17002E15 RID: 11797
		' (get) Token: 0x06007D81 RID: 32129 RVA: 0x0003DC20 File Offset: 0x0003BE20
		' (set) Token: 0x06007D82 RID: 32130 RVA: 0x005D767C File Offset: 0x005D587C
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

		' Token: 0x17002E16 RID: 11798
		' (get) Token: 0x06007D83 RID: 32131 RVA: 0x0003DC2A File Offset: 0x0003BE2A
		' (set) Token: 0x06007D84 RID: 32132 RVA: 0x0003DC34 File Offset: 0x0003BE34
		Friend Overridable Property lblPageInfo As Label

		' Token: 0x17002E17 RID: 11799
		' (get) Token: 0x06007D85 RID: 32133 RVA: 0x0003DC3D File Offset: 0x0003BE3D
		' (set) Token: 0x06007D86 RID: 32134 RVA: 0x0003DC47 File Offset: 0x0003BE47
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x17002E18 RID: 11800
		' (get) Token: 0x06007D87 RID: 32135 RVA: 0x0003DC50 File Offset: 0x0003BE50
		' (set) Token: 0x06007D88 RID: 32136 RVA: 0x005D76C0 File Offset: 0x005D58C0
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

		' Token: 0x17002E19 RID: 11801
		' (get) Token: 0x06007D89 RID: 32137 RVA: 0x0003DC5A File Offset: 0x0003BE5A
		' (set) Token: 0x06007D8A RID: 32138 RVA: 0x0003DC64 File Offset: 0x0003BE64
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x17002E1A RID: 11802
		' (get) Token: 0x06007D8B RID: 32139 RVA: 0x0003DC6D File Offset: 0x0003BE6D
		' (set) Token: 0x06007D8C RID: 32140 RVA: 0x0003DC77 File Offset: 0x0003BE77
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x17002E1B RID: 11803
		' (get) Token: 0x06007D8D RID: 32141 RVA: 0x0003DC80 File Offset: 0x0003BE80
		' (set) Token: 0x06007D8E RID: 32142 RVA: 0x005D7704 File Offset: 0x005D5904
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

		' Token: 0x17002E1C RID: 11804
		' (get) Token: 0x06007D8F RID: 32143 RVA: 0x0003DC8A File Offset: 0x0003BE8A
		' (set) Token: 0x06007D90 RID: 32144 RVA: 0x005D7748 File Offset: 0x005D5948
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

		' Token: 0x17002E1D RID: 11805
		' (get) Token: 0x06007D91 RID: 32145 RVA: 0x0003DC94 File Offset: 0x0003BE94
		' (set) Token: 0x06007D92 RID: 32146 RVA: 0x005D778C File Offset: 0x005D598C
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

		' Token: 0x06007D93 RID: 32147 RVA: 0x0003DC9E File Offset: 0x0003BE9E
		Private Sub frmProductBulkUpdate_Load(sender As Object, e As EventArgs)
			Me.GetTotalRecords()
			Me.GetData(False)
			Me.SetColumnVisibilityAndTextFromDatabase()
			Me.LoadLanguage()
			Me.Convert_Language()
		End Sub

		' Token: 0x06007D94 RID: 32148 RVA: 0x005D77D0 File Offset: 0x005D59D0
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

		' Token: 0x06007D95 RID: 32149 RVA: 0x005D797C File Offset: 0x005D5B7C
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

		' Token: 0x06007D96 RID: 32150 RVA: 0x005D7A34 File Offset: 0x005D5C34
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

		' Token: 0x06007D97 RID: 32151 RVA: 0x005D7AB4 File Offset: 0x005D5CB4
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

		' Token: 0x06007D98 RID: 32152 RVA: 0x005D7C2C File Offset: 0x005D5E2C
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

		' Token: 0x06007D99 RID: 32153 RVA: 0x005D7CE8 File Offset: 0x005D5EE8
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

		' Token: 0x06007D9A RID: 32154 RVA: 0x000B726C File Offset: 0x000B546C
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

		' Token: 0x06007D9B RID: 32155 RVA: 0x000B72F4 File Offset: 0x000B54F4
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

		' Token: 0x06007D9C RID: 32156 RVA: 0x005D7D94 File Offset: 0x005D5F94
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

		' Token: 0x06007D9D RID: 32157 RVA: 0x005D8040 File Offset: 0x005D6240
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

		' Token: 0x06007D9E RID: 32158 RVA: 0x005D816C File Offset: 0x005D636C
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

		' Token: 0x06007D9F RID: 32159 RVA: 0x005D8214 File Offset: 0x005D6414
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

		' Token: 0x06007DA0 RID: 32160 RVA: 0x005D829C File Offset: 0x005D649C
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

		' Token: 0x06007DA1 RID: 32161 RVA: 0x005D8304 File Offset: 0x005D6504
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x06007DA2 RID: 32162 RVA: 0x005D8358 File Offset: 0x005D6558
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

		' Token: 0x06007DA3 RID: 32163 RVA: 0x005D951C File Offset: 0x005D771C
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06007DA4 RID: 32164 RVA: 0x005D21CC File Offset: 0x005D03CC
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

		' Token: 0x06007DA5 RID: 32165 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox42_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06007DA6 RID: 32166 RVA: 0x005D95A0 File Offset: 0x005D77A0
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

		' Token: 0x06007DA7 RID: 32167 RVA: 0x005D968C File Offset: 0x005D788C
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

		' Token: 0x06007DA8 RID: 32168 RVA: 0x005D9D44 File Offset: 0x005D7F44
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

		' Token: 0x06007DA9 RID: 32169 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs)
		End Sub

		' Token: 0x06007DAA RID: 32170 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs)
		End Sub

		' Token: 0x06007DAB RID: 32171 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06007DAC RID: 32172 RVA: 0x005DA3FC File Offset: 0x005D85FC
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

		' Token: 0x06007DAD RID: 32173 RVA: 0x005DA608 File Offset: 0x005D8808
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

		' Token: 0x06007DAE RID: 32174 RVA: 0x005DAC54 File Offset: 0x005D8E54
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

		' Token: 0x06007DAF RID: 32175 RVA: 0x005DACA8 File Offset: 0x005D8EA8
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.txtTopResult.Text = "50"
			Me.chkSelectAll.Checked = False
			Me.GetData(False)
		End Sub

		' Token: 0x06007DB0 RID: 32176 RVA: 0x005DAD0C File Offset: 0x005D8F0C
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

		' Token: 0x06007DB1 RID: 32177 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub listView1_MouseClick(sender As Object, e As MouseEventArgs)
		End Sub

		' Token: 0x06007DB2 RID: 32178 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmProductBulkUpdate_Scroll(sender As Object, e As ScrollEventArgs)
		End Sub

		' Token: 0x06007DB3 RID: 32179 RVA: 0x005DAD60 File Offset: 0x005D8F60
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

		' Token: 0x06007DB4 RID: 32180 RVA: 0x005DAE0C File Offset: 0x005D900C
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

		' Token: 0x06007DB5 RID: 32181 RVA: 0x005DAE80 File Offset: 0x005D9080
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

		' Token: 0x06007DB6 RID: 32182 RVA: 0x005DB114 File Offset: 0x005D9314
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.pageIndex > 1
			If flag Then
				Me.pageIndex = Me.pageIndex - 1
				Me.GetData(False)
			End If
		End Sub

		' Token: 0x06007DB7 RID: 32183 RVA: 0x005DB148 File Offset: 0x005D9348
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.pageIndex < Me.totalPages
			If flag Then
				Me.pageIndex = Me.pageIndex + 1
				Me.GetData(False)
			End If
		End Sub

		' Token: 0x06007DB8 RID: 32184 RVA: 0x0003DCC5 File Offset: 0x0003BEC5
		Private Sub Button1_Click_1(sender As Object, e As EventArgs)
			Me.showAll = True
			Me.GetData(Me.showAll)
		End Sub

		' Token: 0x06007DB9 RID: 32185 RVA: 0x0003D7E3 File Offset: 0x0003B9E3
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkProductSeting.ShowDialog()
		End Sub

		' Token: 0x06007DBA RID: 32186 RVA: 0x005DB180 File Offset: 0x005D9380
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

		' Token: 0x06007DBB RID: 32187 RVA: 0x005DB454 File Offset: 0x005D9654
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

		' Token: 0x06007DBC RID: 32188 RVA: 0x0003D7F6 File Offset: 0x0003B9F6
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmLSetDefault.lbltype.Text = "bulk"
			MyProject.Forms.frmLSetDefault.ShowDialog()
		End Sub

		' Token: 0x06007DBD RID: 32189 RVA: 0x005DB4A8 File Offset: 0x005D96A8
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

		' Token: 0x0400378A RID: 14218
		Private pageIndex As Integer

		' Token: 0x0400378B RID: 14219
		Private pageSize As Integer

		' Token: 0x0400378C RID: 14220
		Private totalRecords As Integer

		' Token: 0x0400378D RID: 14221
		Private totalPages As Integer

		' Token: 0x0400378E RID: 14222
		Private showAll As Boolean

		' Token: 0x0400378F RID: 14223
		Private transliterator As Transliterator

		' Token: 0x04003790 RID: 14224
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04003791 RID: 14225
		Private CurrentItem As ListViewItem

		' Token: 0x04003792 RID: 14226
		Private bCancelEdit As Boolean
	End Class
End Namespace
