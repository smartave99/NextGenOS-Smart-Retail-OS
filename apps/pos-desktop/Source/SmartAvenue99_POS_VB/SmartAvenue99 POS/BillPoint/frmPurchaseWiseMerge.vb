Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F1 RID: 497
	<DesignerGenerated()>
	Public Partial Class frmPurchaseWiseMerge
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008C2B RID: 35883 RVA: 0x00044627 File Offset: 0x00042827
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurchaseWiseMerge_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003394 RID: 13204
		' (get) Token: 0x06008C2E RID: 35886 RVA: 0x00044647 File Offset: 0x00042847
		' (set) Token: 0x06008C2F RID: 35887 RVA: 0x00670C08 File Offset: 0x0066EE08
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim eventHandler As EventHandler = AddressOf Me.DataGridView1_DoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView1_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.DoubleClick, eventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.DoubleClick, eventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003395 RID: 13205
		' (get) Token: 0x06008C30 RID: 35888 RVA: 0x00044651 File Offset: 0x00042851
		' (set) Token: 0x06008C31 RID: 35889 RVA: 0x0004465B File Offset: 0x0004285B
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17003396 RID: 13206
		' (get) Token: 0x06008C32 RID: 35890 RVA: 0x00044664 File Offset: 0x00042864
		' (set) Token: 0x06008C33 RID: 35891 RVA: 0x0004466E File Offset: 0x0004286E
		Friend Overridable Property Label5 As Label

		' Token: 0x17003397 RID: 13207
		' (get) Token: 0x06008C34 RID: 35892 RVA: 0x00044677 File Offset: 0x00042877
		' (set) Token: 0x06008C35 RID: 35893 RVA: 0x00670CA8 File Offset: 0x0066EEA8
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler2
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler2
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003398 RID: 13208
		' (get) Token: 0x06008C36 RID: 35894 RVA: 0x00044681 File Offset: 0x00042881
		' (set) Token: 0x06008C37 RID: 35895 RVA: 0x00670D24 File Offset: 0x0066EF24
		Private _cmbInvoiceNo As TextBox
		Friend Overridable Property cmbInvoiceNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._cmbInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbInvoiceNo_TextChanged_1
				Dim previewKeyDownEventHandler As PreviewKeyDownEventHandler = AddressOf Me.cmbInvoiceNo_PreviewKeyDown_1
				Dim textBox As TextBox = Me._cmbInvoiceNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.PreviewKeyDown, previewKeyDownEventHandler
				End If
				Me._cmbInvoiceNo = value
				textBox = Me._cmbInvoiceNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.PreviewKeyDown, previewKeyDownEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003399 RID: 13209
		' (get) Token: 0x06008C38 RID: 35896 RVA: 0x0004468B File Offset: 0x0004288B
		' (set) Token: 0x06008C39 RID: 35897 RVA: 0x00670D84 File Offset: 0x0066EF84
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700339A RID: 13210
		' (get) Token: 0x06008C3A RID: 35898 RVA: 0x00044695 File Offset: 0x00042895
		' (set) Token: 0x06008C3B RID: 35899 RVA: 0x0004469F File Offset: 0x0004289F
		Friend Overridable Property txtSt_ID As TextBox

		' Token: 0x1700339B RID: 13211
		' (get) Token: 0x06008C3C RID: 35900 RVA: 0x000446A8 File Offset: 0x000428A8
		' (set) Token: 0x06008C3D RID: 35901 RVA: 0x000446B2 File Offset: 0x000428B2
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x1700339C RID: 13212
		' (get) Token: 0x06008C3E RID: 35902 RVA: 0x000446BB File Offset: 0x000428BB
		' (set) Token: 0x06008C3F RID: 35903 RVA: 0x000446C5 File Offset: 0x000428C5
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x1700339D RID: 13213
		' (get) Token: 0x06008C40 RID: 35904 RVA: 0x000446CE File Offset: 0x000428CE
		' (set) Token: 0x06008C41 RID: 35905 RVA: 0x000446D8 File Offset: 0x000428D8
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700339E RID: 13214
		' (get) Token: 0x06008C42 RID: 35906 RVA: 0x000446E1 File Offset: 0x000428E1
		' (set) Token: 0x06008C43 RID: 35907 RVA: 0x000446EB File Offset: 0x000428EB
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700339F RID: 13215
		' (get) Token: 0x06008C44 RID: 35908 RVA: 0x000446F4 File Offset: 0x000428F4
		' (set) Token: 0x06008C45 RID: 35909 RVA: 0x000446FE File Offset: 0x000428FE
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170033A0 RID: 13216
		' (get) Token: 0x06008C46 RID: 35910 RVA: 0x00044707 File Offset: 0x00042907
		' (set) Token: 0x06008C47 RID: 35911 RVA: 0x00044711 File Offset: 0x00042911
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170033A1 RID: 13217
		' (get) Token: 0x06008C48 RID: 35912 RVA: 0x0004471A File Offset: 0x0004291A
		' (set) Token: 0x06008C49 RID: 35913 RVA: 0x00044724 File Offset: 0x00042924
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170033A2 RID: 13218
		' (get) Token: 0x06008C4A RID: 35914 RVA: 0x0004472D File Offset: 0x0004292D
		' (set) Token: 0x06008C4B RID: 35915 RVA: 0x00044737 File Offset: 0x00042937
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170033A3 RID: 13219
		' (get) Token: 0x06008C4C RID: 35916 RVA: 0x00044740 File Offset: 0x00042940
		' (set) Token: 0x06008C4D RID: 35917 RVA: 0x0004474A File Offset: 0x0004294A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170033A4 RID: 13220
		' (get) Token: 0x06008C4E RID: 35918 RVA: 0x00044753 File Offset: 0x00042953
		' (set) Token: 0x06008C4F RID: 35919 RVA: 0x0004475D File Offset: 0x0004295D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170033A5 RID: 13221
		' (get) Token: 0x06008C50 RID: 35920 RVA: 0x00044766 File Offset: 0x00042966
		' (set) Token: 0x06008C51 RID: 35921 RVA: 0x00044770 File Offset: 0x00042970
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170033A6 RID: 13222
		' (get) Token: 0x06008C52 RID: 35922 RVA: 0x00044779 File Offset: 0x00042979
		' (set) Token: 0x06008C53 RID: 35923 RVA: 0x00044783 File Offset: 0x00042983
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170033A7 RID: 13223
		' (get) Token: 0x06008C54 RID: 35924 RVA: 0x0004478C File Offset: 0x0004298C
		' (set) Token: 0x06008C55 RID: 35925 RVA: 0x00044796 File Offset: 0x00042996
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170033A8 RID: 13224
		' (get) Token: 0x06008C56 RID: 35926 RVA: 0x0004479F File Offset: 0x0004299F
		' (set) Token: 0x06008C57 RID: 35927 RVA: 0x000447A9 File Offset: 0x000429A9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170033A9 RID: 13225
		' (get) Token: 0x06008C58 RID: 35928 RVA: 0x000447B2 File Offset: 0x000429B2
		' (set) Token: 0x06008C59 RID: 35929 RVA: 0x000447BC File Offset: 0x000429BC
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170033AA RID: 13226
		' (get) Token: 0x06008C5A RID: 35930 RVA: 0x000447C5 File Offset: 0x000429C5
		' (set) Token: 0x06008C5B RID: 35931 RVA: 0x000447CF File Offset: 0x000429CF
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170033AB RID: 13227
		' (get) Token: 0x06008C5C RID: 35932 RVA: 0x000447D8 File Offset: 0x000429D8
		' (set) Token: 0x06008C5D RID: 35933 RVA: 0x000447E2 File Offset: 0x000429E2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170033AC RID: 13228
		' (get) Token: 0x06008C5E RID: 35934 RVA: 0x000447EB File Offset: 0x000429EB
		' (set) Token: 0x06008C5F RID: 35935 RVA: 0x000447F5 File Offset: 0x000429F5
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170033AD RID: 13229
		' (get) Token: 0x06008C60 RID: 35936 RVA: 0x000447FE File Offset: 0x000429FE
		' (set) Token: 0x06008C61 RID: 35937 RVA: 0x00044808 File Offset: 0x00042A08
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170033AE RID: 13230
		' (get) Token: 0x06008C62 RID: 35938 RVA: 0x00044811 File Offset: 0x00042A11
		' (set) Token: 0x06008C63 RID: 35939 RVA: 0x0004481B File Offset: 0x00042A1B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170033AF RID: 13231
		' (get) Token: 0x06008C64 RID: 35940 RVA: 0x00044824 File Offset: 0x00042A24
		' (set) Token: 0x06008C65 RID: 35941 RVA: 0x0004482E File Offset: 0x00042A2E
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170033B0 RID: 13232
		' (get) Token: 0x06008C66 RID: 35942 RVA: 0x00044837 File Offset: 0x00042A37
		' (set) Token: 0x06008C67 RID: 35943 RVA: 0x00044841 File Offset: 0x00042A41
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170033B1 RID: 13233
		' (get) Token: 0x06008C68 RID: 35944 RVA: 0x0004484A File Offset: 0x00042A4A
		' (set) Token: 0x06008C69 RID: 35945 RVA: 0x00044854 File Offset: 0x00042A54
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170033B2 RID: 13234
		' (get) Token: 0x06008C6A RID: 35946 RVA: 0x0004485D File Offset: 0x00042A5D
		' (set) Token: 0x06008C6B RID: 35947 RVA: 0x00044867 File Offset: 0x00042A67
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170033B3 RID: 13235
		' (get) Token: 0x06008C6C RID: 35948 RVA: 0x00044870 File Offset: 0x00042A70
		' (set) Token: 0x06008C6D RID: 35949 RVA: 0x0004487A File Offset: 0x00042A7A
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170033B4 RID: 13236
		' (get) Token: 0x06008C6E RID: 35950 RVA: 0x00044883 File Offset: 0x00042A83
		' (set) Token: 0x06008C6F RID: 35951 RVA: 0x0004488D File Offset: 0x00042A8D
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170033B5 RID: 13237
		' (get) Token: 0x06008C70 RID: 35952 RVA: 0x00044896 File Offset: 0x00042A96
		' (set) Token: 0x06008C71 RID: 35953 RVA: 0x000448A0 File Offset: 0x00042AA0
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170033B6 RID: 13238
		' (get) Token: 0x06008C72 RID: 35954 RVA: 0x000448A9 File Offset: 0x00042AA9
		' (set) Token: 0x06008C73 RID: 35955 RVA: 0x000448B3 File Offset: 0x00042AB3
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170033B7 RID: 13239
		' (get) Token: 0x06008C74 RID: 35956 RVA: 0x000448BC File Offset: 0x00042ABC
		' (set) Token: 0x06008C75 RID: 35957 RVA: 0x000448C6 File Offset: 0x00042AC6
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170033B8 RID: 13240
		' (get) Token: 0x06008C76 RID: 35958 RVA: 0x000448CF File Offset: 0x00042ACF
		' (set) Token: 0x06008C77 RID: 35959 RVA: 0x000448D9 File Offset: 0x00042AD9
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170033B9 RID: 13241
		' (get) Token: 0x06008C78 RID: 35960 RVA: 0x000448E2 File Offset: 0x00042AE2
		' (set) Token: 0x06008C79 RID: 35961 RVA: 0x000448EC File Offset: 0x00042AEC
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170033BA RID: 13242
		' (get) Token: 0x06008C7A RID: 35962 RVA: 0x000448F5 File Offset: 0x00042AF5
		' (set) Token: 0x06008C7B RID: 35963 RVA: 0x000448FF File Offset: 0x00042AFF
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170033BB RID: 13243
		' (get) Token: 0x06008C7C RID: 35964 RVA: 0x00044908 File Offset: 0x00042B08
		' (set) Token: 0x06008C7D RID: 35965 RVA: 0x00044912 File Offset: 0x00042B12
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x170033BC RID: 13244
		' (get) Token: 0x06008C7E RID: 35966 RVA: 0x0004491B File Offset: 0x00042B1B
		' (set) Token: 0x06008C7F RID: 35967 RVA: 0x00044925 File Offset: 0x00042B25
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x170033BD RID: 13245
		' (get) Token: 0x06008C80 RID: 35968 RVA: 0x0004492E File Offset: 0x00042B2E
		' (set) Token: 0x06008C81 RID: 35969 RVA: 0x00044938 File Offset: 0x00042B38
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x170033BE RID: 13246
		' (get) Token: 0x06008C82 RID: 35970 RVA: 0x00044941 File Offset: 0x00042B41
		' (set) Token: 0x06008C83 RID: 35971 RVA: 0x0004494B File Offset: 0x00042B4B
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x170033BF RID: 13247
		' (get) Token: 0x06008C84 RID: 35972 RVA: 0x00044954 File Offset: 0x00042B54
		' (set) Token: 0x06008C85 RID: 35973 RVA: 0x0004495E File Offset: 0x00042B5E
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x170033C0 RID: 13248
		' (get) Token: 0x06008C86 RID: 35974 RVA: 0x00044967 File Offset: 0x00042B67
		' (set) Token: 0x06008C87 RID: 35975 RVA: 0x00044971 File Offset: 0x00042B71
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x170033C1 RID: 13249
		' (get) Token: 0x06008C88 RID: 35976 RVA: 0x0004497A File Offset: 0x00042B7A
		' (set) Token: 0x06008C89 RID: 35977 RVA: 0x00044984 File Offset: 0x00042B84
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x170033C2 RID: 13250
		' (get) Token: 0x06008C8A RID: 35978 RVA: 0x0004498D File Offset: 0x00042B8D
		' (set) Token: 0x06008C8B RID: 35979 RVA: 0x00044997 File Offset: 0x00042B97
		Friend Overridable Property variant_id As DataGridViewTextBoxColumn

		' Token: 0x170033C3 RID: 13251
		' (get) Token: 0x06008C8C RID: 35980 RVA: 0x000449A0 File Offset: 0x00042BA0
		' (set) Token: 0x06008C8D RID: 35981 RVA: 0x000449AA File Offset: 0x00042BAA
		Friend Overridable Property btnVariant As DataGridViewButtonColumn

		' Token: 0x170033C4 RID: 13252
		' (get) Token: 0x06008C8E RID: 35982 RVA: 0x000449B3 File Offset: 0x00042BB3
		' (set) Token: 0x06008C8F RID: 35983 RVA: 0x000449BD File Offset: 0x00042BBD
		Friend Overridable Property serial_no As DataGridViewTextBoxColumn

		' Token: 0x170033C5 RID: 13253
		' (get) Token: 0x06008C90 RID: 35984 RVA: 0x000449C6 File Offset: 0x00042BC6
		' (set) Token: 0x06008C91 RID: 35985 RVA: 0x000449D0 File Offset: 0x00042BD0
		Friend Overridable Property btnSerial As DataGridViewButtonColumn

		' Token: 0x170033C6 RID: 13254
		' (get) Token: 0x06008C92 RID: 35986 RVA: 0x000449D9 File Offset: 0x00042BD9
		' (set) Token: 0x06008C93 RID: 35987 RVA: 0x000449E3 File Offset: 0x00042BE3
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x170033C7 RID: 13255
		' (get) Token: 0x06008C94 RID: 35988 RVA: 0x000449EC File Offset: 0x00042BEC
		' (set) Token: 0x06008C95 RID: 35989 RVA: 0x000449F6 File Offset: 0x00042BF6
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x170033C8 RID: 13256
		' (get) Token: 0x06008C96 RID: 35990 RVA: 0x000449FF File Offset: 0x00042BFF
		' (set) Token: 0x06008C97 RID: 35991 RVA: 0x00044A09 File Offset: 0x00042C09
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x170033C9 RID: 13257
		' (get) Token: 0x06008C98 RID: 35992 RVA: 0x00044A12 File Offset: 0x00042C12
		' (set) Token: 0x06008C99 RID: 35993 RVA: 0x00044A1C File Offset: 0x00042C1C
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x170033CA RID: 13258
		' (get) Token: 0x06008C9A RID: 35994 RVA: 0x00044A25 File Offset: 0x00042C25
		' (set) Token: 0x06008C9B RID: 35995 RVA: 0x00044A2F File Offset: 0x00042C2F
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x170033CB RID: 13259
		' (get) Token: 0x06008C9C RID: 35996 RVA: 0x00044A38 File Offset: 0x00042C38
		' (set) Token: 0x06008C9D RID: 35997 RVA: 0x00044A42 File Offset: 0x00042C42
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x170033CC RID: 13260
		' (get) Token: 0x06008C9E RID: 35998 RVA: 0x00044A4B File Offset: 0x00042C4B
		' (set) Token: 0x06008C9F RID: 35999 RVA: 0x00044A55 File Offset: 0x00042C55
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x170033CD RID: 13261
		' (get) Token: 0x06008CA0 RID: 36000 RVA: 0x00044A5E File Offset: 0x00042C5E
		' (set) Token: 0x06008CA1 RID: 36001 RVA: 0x00044A68 File Offset: 0x00042C68
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x170033CE RID: 13262
		' (get) Token: 0x06008CA2 RID: 36002 RVA: 0x00044A71 File Offset: 0x00042C71
		' (set) Token: 0x06008CA3 RID: 36003 RVA: 0x00044A7B File Offset: 0x00042C7B
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x170033CF RID: 13263
		' (get) Token: 0x06008CA4 RID: 36004 RVA: 0x00044A84 File Offset: 0x00042C84
		' (set) Token: 0x06008CA5 RID: 36005 RVA: 0x00044A8E File Offset: 0x00042C8E
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x170033D0 RID: 13264
		' (get) Token: 0x06008CA6 RID: 36006 RVA: 0x00044A97 File Offset: 0x00042C97
		' (set) Token: 0x06008CA7 RID: 36007 RVA: 0x00044AA1 File Offset: 0x00042CA1
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x170033D1 RID: 13265
		' (get) Token: 0x06008CA8 RID: 36008 RVA: 0x00044AAA File Offset: 0x00042CAA
		' (set) Token: 0x06008CA9 RID: 36009 RVA: 0x00044AB4 File Offset: 0x00042CB4
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x170033D2 RID: 13266
		' (get) Token: 0x06008CAA RID: 36010 RVA: 0x00044ABD File Offset: 0x00042CBD
		' (set) Token: 0x06008CAB RID: 36011 RVA: 0x00044AC7 File Offset: 0x00042CC7
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x170033D3 RID: 13267
		' (get) Token: 0x06008CAC RID: 36012 RVA: 0x00044AD0 File Offset: 0x00042CD0
		' (set) Token: 0x06008CAD RID: 36013 RVA: 0x00044ADA File Offset: 0x00042CDA
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x170033D4 RID: 13268
		' (get) Token: 0x06008CAE RID: 36014 RVA: 0x00044AE3 File Offset: 0x00042CE3
		' (set) Token: 0x06008CAF RID: 36015 RVA: 0x00044AED File Offset: 0x00042CED
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x170033D5 RID: 13269
		' (get) Token: 0x06008CB0 RID: 36016 RVA: 0x00044AF6 File Offset: 0x00042CF6
		' (set) Token: 0x06008CB1 RID: 36017 RVA: 0x00044B00 File Offset: 0x00042D00
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x170033D6 RID: 13270
		' (get) Token: 0x06008CB2 RID: 36018 RVA: 0x00044B09 File Offset: 0x00042D09
		' (set) Token: 0x06008CB3 RID: 36019 RVA: 0x00044B13 File Offset: 0x00042D13
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x170033D7 RID: 13271
		' (get) Token: 0x06008CB4 RID: 36020 RVA: 0x00044B1C File Offset: 0x00042D1C
		' (set) Token: 0x06008CB5 RID: 36021 RVA: 0x00044B26 File Offset: 0x00042D26
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x170033D8 RID: 13272
		' (get) Token: 0x06008CB6 RID: 36022 RVA: 0x00044B2F File Offset: 0x00042D2F
		' (set) Token: 0x06008CB7 RID: 36023 RVA: 0x00044B39 File Offset: 0x00042D39
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x170033D9 RID: 13273
		' (get) Token: 0x06008CB8 RID: 36024 RVA: 0x00044B42 File Offset: 0x00042D42
		' (set) Token: 0x06008CB9 RID: 36025 RVA: 0x00044B4C File Offset: 0x00042D4C
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170033DA RID: 13274
		' (get) Token: 0x06008CBA RID: 36026 RVA: 0x00044B55 File Offset: 0x00042D55
		' (set) Token: 0x06008CBB RID: 36027 RVA: 0x00044B5F File Offset: 0x00042D5F
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170033DB RID: 13275
		' (get) Token: 0x06008CBC RID: 36028 RVA: 0x00044B68 File Offset: 0x00042D68
		' (set) Token: 0x06008CBD RID: 36029 RVA: 0x00044B72 File Offset: 0x00042D72
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170033DC RID: 13276
		' (get) Token: 0x06008CBE RID: 36030 RVA: 0x00044B7B File Offset: 0x00042D7B
		' (set) Token: 0x06008CBF RID: 36031 RVA: 0x00044B85 File Offset: 0x00042D85
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170033DD RID: 13277
		' (get) Token: 0x06008CC0 RID: 36032 RVA: 0x00044B8E File Offset: 0x00042D8E
		' (set) Token: 0x06008CC1 RID: 36033 RVA: 0x00044B98 File Offset: 0x00042D98
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x170033DE RID: 13278
		' (get) Token: 0x06008CC2 RID: 36034 RVA: 0x00044BA1 File Offset: 0x00042DA1
		' (set) Token: 0x06008CC3 RID: 36035 RVA: 0x00044BAB File Offset: 0x00042DAB
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170033DF RID: 13279
		' (get) Token: 0x06008CC4 RID: 36036 RVA: 0x00044BB4 File Offset: 0x00042DB4
		' (set) Token: 0x06008CC5 RID: 36037 RVA: 0x00044BBE File Offset: 0x00042DBE
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x170033E0 RID: 13280
		' (get) Token: 0x06008CC6 RID: 36038 RVA: 0x00044BC7 File Offset: 0x00042DC7
		' (set) Token: 0x06008CC7 RID: 36039 RVA: 0x00044BD1 File Offset: 0x00042DD1
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x170033E1 RID: 13281
		' (get) Token: 0x06008CC8 RID: 36040 RVA: 0x00044BDA File Offset: 0x00042DDA
		' (set) Token: 0x06008CC9 RID: 36041 RVA: 0x00044BE4 File Offset: 0x00042DE4
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170033E2 RID: 13282
		' (get) Token: 0x06008CCA RID: 36042 RVA: 0x00044BED File Offset: 0x00042DED
		' (set) Token: 0x06008CCB RID: 36043 RVA: 0x00044BF7 File Offset: 0x00042DF7
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x170033E3 RID: 13283
		' (get) Token: 0x06008CCC RID: 36044 RVA: 0x00044C00 File Offset: 0x00042E00
		' (set) Token: 0x06008CCD RID: 36045 RVA: 0x00044C0A File Offset: 0x00042E0A
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170033E4 RID: 13284
		' (get) Token: 0x06008CCE RID: 36046 RVA: 0x00044C13 File Offset: 0x00042E13
		' (set) Token: 0x06008CCF RID: 36047 RVA: 0x00044C1D File Offset: 0x00042E1D
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170033E5 RID: 13285
		' (get) Token: 0x06008CD0 RID: 36048 RVA: 0x00044C26 File Offset: 0x00042E26
		' (set) Token: 0x06008CD1 RID: 36049 RVA: 0x00044C30 File Offset: 0x00042E30
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170033E6 RID: 13286
		' (get) Token: 0x06008CD2 RID: 36050 RVA: 0x00044C39 File Offset: 0x00042E39
		' (set) Token: 0x06008CD3 RID: 36051 RVA: 0x00044C43 File Offset: 0x00042E43
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170033E7 RID: 13287
		' (get) Token: 0x06008CD4 RID: 36052 RVA: 0x00044C4C File Offset: 0x00042E4C
		' (set) Token: 0x06008CD5 RID: 36053 RVA: 0x00044C56 File Offset: 0x00042E56
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170033E8 RID: 13288
		' (get) Token: 0x06008CD6 RID: 36054 RVA: 0x00044C5F File Offset: 0x00042E5F
		' (set) Token: 0x06008CD7 RID: 36055 RVA: 0x00044C69 File Offset: 0x00042E69
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x170033E9 RID: 13289
		' (get) Token: 0x06008CD8 RID: 36056 RVA: 0x00044C72 File Offset: 0x00042E72
		' (set) Token: 0x06008CD9 RID: 36057 RVA: 0x00044C7C File Offset: 0x00042E7C
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x170033EA RID: 13290
		' (get) Token: 0x06008CDA RID: 36058 RVA: 0x00044C85 File Offset: 0x00042E85
		' (set) Token: 0x06008CDB RID: 36059 RVA: 0x00044C8F File Offset: 0x00042E8F
		Friend Overridable Property MergeStock As DataGridViewButtonColumn

		' Token: 0x06008CDC RID: 36060 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
		End Sub

		' Token: 0x06008CDD RID: 36061 RVA: 0x00044C98 File Offset: 0x00042E98
		Private Sub BtnLoadInvoiceNo_Click(sender As Object, e As EventArgs)
			Me.LoadData()
		End Sub

		' Token: 0x06008CDE RID: 36062 RVA: 0x00670DC8 File Offset: 0x0066EFC8
		Private Sub LoadData()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT TOP 10 PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product.Barcode),Qty,Stock_Product.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,Qty,Stock_Product.TaxableAmt,Stock_Product.AltQty,Stock_Product.AltUnit,Stock_Product.PTaxType,Stock_Product.RPrice,Stock_Product.WPrice,RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.RCipher),RTRIM(Stock_Product.WCipher),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.MainUnit),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) from Product,Stock,Stock_Product where product.PID=Stock_product.ProductID and Stock.ST_ID=Stock_Product.StockID and ST_ID like '%" + Conversions.ToString(Conversion.Val(Me.txtSt_ID.Text)) + "%'"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Me.DataGridView1.Rows.Clear()
			While ModCommonClasses.rdr.Read()
				Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36) })
			End While
			ModCommonClasses.con.Close()
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x06008CDF RID: 36063 RVA: 0x006710CC File Offset: 0x0066F2CC
		Private Sub ProductName(ProductName As String, BarCode As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = String.Concat(New String() { "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and ProductName = N'", ProductName, "' and Product.Status='Yes' and Temp_Stock.Barcode<>'", BarCode, "'  order by ProductName" })
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Me.dgw.Rows.Clear()
			While ModCommonClasses.rdr.Read()
				Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
			End While
			ModCommonClasses.con.Close()
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x06008CE0 RID: 36064 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbInvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06008CE1 RID: 36065 RVA: 0x006713C8 File Offset: 0x0066F5C8
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Up
			If flag Then
				Dim flag2 As Boolean = Me.dgw4.CurrentRow.Index > 0
				If flag2 Then
					Me.dgw4.CurrentCell = Me.dgw4.Rows(Me.dgw4.CurrentRow.Index - 1).Cells(1)
					e.Handled = True
				End If
			Else
				Dim flag3 As Boolean = e.KeyCode = Keys.Down
				If flag3 Then
					Dim flag4 As Boolean = Me.dgw4.CurrentRow.Index < Me.dgw4.Rows.Count - 1
					If flag4 Then
						Me.dgw4.CurrentCell = Me.dgw4.Rows(Me.dgw4.CurrentRow.Index + 1).Cells(1)
						e.Handled = True
					End If
				Else
					Dim flag5 As Boolean = e.KeyCode = Keys.[Return]
					If flag5 Then
						Me.txtSt_ID.Text = Me.dgw4.CurrentRow.Cells(0).Value.ToString().Trim()
						Me.cmbInvoiceNo.Text = Me.dgw4.CurrentRow.Cells(1).Value.ToString().Trim()
						Me.LoadData()
						Me.dgw4.Visible = False
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x06008CE2 RID: 36066 RVA: 0x00671554 File Offset: 0x0066F754
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
					Me.cmbInvoiceNo.Focus()
					Me.cmbInvoiceNo.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.cmbInvoiceNo.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text.Remove(Me.cmbInvoiceNo.Text.Length - 1, 1)
						Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
						Me.cmbInvoiceNo.Focus()
						Me.cmbInvoiceNo.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "a"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "b"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "c"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "d"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "e"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "f"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "g"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "h"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "i"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "j"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "k"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "l"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "m"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "n"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "o"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "p"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "q"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "r"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "s"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "t"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "u"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "v"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "w"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "x"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "y"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "z"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "0"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "1"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "2"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "3"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "4"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "5"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "6"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "7"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "8"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "9"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "+"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "-"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + "\"
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
				Me.cmbInvoiceNo.Text = Me.cmbInvoiceNo.Text + ","
				Me.cmbInvoiceNo.[Select](Me.cmbInvoiceNo.Text.Length, 0)
				Me.cmbInvoiceNo.Focus()
				Me.cmbInvoiceNo.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06008CE3 RID: 36067 RVA: 0x00672F9C File Offset: 0x0067119C
		Private Sub cmbInvoiceNo_TextChanged_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbInvoiceNo.Text.Trim().Length < 1
			If flag Then
				Me.dgw4.Visible = False
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT TOP 10 ST_ID,InvoiceNo FROM Stock WHERE InvoiceNo LIKE @invoiceNo"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@invoiceNo", "%" + Me.cmbInvoiceNo.Text.Trim() + "%")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Me.dgw4.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr("ST_ID").ToString(), ModCommonClasses.rdr("InvoiceNo").ToString() })
					End While
					Me.dgw4.Visible = Me.dgw4.Rows.Count > 0
					Me.dgw4.BringToFront()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con IsNot Nothing
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End Try
			End If
		End Sub

		' Token: 0x06008CE4 RID: 36068 RVA: 0x00673170 File Offset: 0x00671370
		Private Sub cmbInvoiceNo_PreviewKeyDown_1(sender As Object, e As PreviewKeyDownEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim flag2 As Boolean = Me.dgw4.Rows.Count > 0
				If flag2 Then
					Me.dgw4.Focus()
					Me.dgw4.CurrentCell = Me.dgw4.Rows(0).Cells(1)
				End If
			End If
		End Sub

		' Token: 0x06008CE5 RID: 36069 RVA: 0x006731DC File Offset: 0x006713DC
		Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
			If flag Then
				Me.ProductName(Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells(2).Value), Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells("Column7").Value))
			End If
		End Sub

		' Token: 0x06008CE6 RID: 36070 RVA: 0x0067325C File Offset: 0x0067145C
		Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Me.DataGridView1.SelectedRows.Count > 0
				If flag2 Then
					Me.ProductName(Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells(2).Value), Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells("Column7").Value))
				End If
			End If
		End Sub

		' Token: 0x06008CE7 RID: 36071 RVA: 0x006731DC File Offset: 0x006713DC
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count > 0
			If flag Then
				Me.ProductName(Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells(2).Value), Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells("Column7").Value))
			End If
		End Sub

		' Token: 0x06008CE8 RID: 36072 RVA: 0x006732EC File Offset: 0x006714EC
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.dgw.Columns("MergeStock").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim flag2 As Boolean = Operators.ConditionalCompareObjectNotEqual(Me.DataGridView1.Rows(e.RowIndex).Cells("Column7").Value, Me.dgw.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn6").Value, False)
				If flag2 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("update Temp_stock set qty = qty + (", Me.dgw.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn13").Value), ") where ProductID=@d1 and Barcode=@d2"))
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells("Column1").Value)))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells("Column7").Value))
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("update Temp_stock set qty = qty - (", Me.dgw.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn13").Value), ") where ProductID=@d1 and Barcode=@d2"))
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn1").Value)))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(Me.dgw.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn6").Value))
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Me.ProductName(Conversions.ToString(Me.DataGridView1.SelectedRows(0).Cells(2).Value), Conversions.ToString(Me.DataGridView1.Rows(e.RowIndex).Cells("Column7").Value))
				Else
					Interaction.MsgBox("Same Barcode Can Not Be Merged", MsgBoxStyle.Information, Nothing)
				End If
			End If
		End Sub

		' Token: 0x06008CE9 RID: 36073 RVA: 0x00673648 File Offset: 0x00671848
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.txtSt_ID.Text = Me.dgw4.CurrentRow.Cells(0).Value.ToString().Trim()
			Me.cmbInvoiceNo.Text = Me.dgw4.CurrentRow.Cells(1).Value.ToString().Trim()
			Me.LoadData()
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x06008CEA RID: 36074 RVA: 0x00044CA2 File Offset: 0x00042EA2
		Private Sub frmPurchaseWiseMerge_Load(sender As Object, e As EventArgs)
			Me.dgw4.ColumnHeadersVisible = False
		End Sub
	End Class
End Namespace
