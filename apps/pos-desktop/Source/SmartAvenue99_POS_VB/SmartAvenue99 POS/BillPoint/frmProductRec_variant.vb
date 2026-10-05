Imports System
Imports System.Collections
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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001E1 RID: 481
	<DesignerGenerated()>
	Public Partial Class frmProductRec_variant
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600809C RID: 32924 RVA: 0x005F4078 File Offset: 0x005F2278
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRec_variant_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRec_variant_KeyDown
			Me.dt = New DataTable()
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002F30 RID: 12080
		' (get) Token: 0x0600809F RID: 32927 RVA: 0x0003F1CC File Offset: 0x0003D3CC
		' (set) Token: 0x060080A0 RID: 32928 RVA: 0x0003F1D6 File Offset: 0x0003D3D6
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002F31 RID: 12081
		' (get) Token: 0x060080A1 RID: 32929 RVA: 0x0003F1DF File Offset: 0x0003D3DF
		' (set) Token: 0x060080A2 RID: 32930 RVA: 0x0003F1E9 File Offset: 0x0003D3E9
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x17002F32 RID: 12082
		' (get) Token: 0x060080A3 RID: 32931 RVA: 0x0003F1F2 File Offset: 0x0003D3F2
		' (set) Token: 0x060080A4 RID: 32932 RVA: 0x0003F1FC File Offset: 0x0003D3FC
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002F33 RID: 12083
		' (get) Token: 0x060080A5 RID: 32933 RVA: 0x0003F205 File Offset: 0x0003D405
		' (set) Token: 0x060080A6 RID: 32934 RVA: 0x0003F20F File Offset: 0x0003D40F
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002F34 RID: 12084
		' (get) Token: 0x060080A7 RID: 32935 RVA: 0x0003F218 File Offset: 0x0003D418
		' (set) Token: 0x060080A8 RID: 32936 RVA: 0x0003F222 File Offset: 0x0003D422
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002F35 RID: 12085
		' (get) Token: 0x060080A9 RID: 32937 RVA: 0x0003F22B File Offset: 0x0003D42B
		' (set) Token: 0x060080AA RID: 32938 RVA: 0x0003F235 File Offset: 0x0003D435
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17002F36 RID: 12086
		' (get) Token: 0x060080AB RID: 32939 RVA: 0x0003F23E File Offset: 0x0003D43E
		' (set) Token: 0x060080AC RID: 32940 RVA: 0x0003F248 File Offset: 0x0003D448
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17002F37 RID: 12087
		' (get) Token: 0x060080AD RID: 32941 RVA: 0x0003F251 File Offset: 0x0003D451
		' (set) Token: 0x060080AE RID: 32942 RVA: 0x0003F25B File Offset: 0x0003D45B
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002F38 RID: 12088
		' (get) Token: 0x060080AF RID: 32943 RVA: 0x0003F264 File Offset: 0x0003D464
		' (set) Token: 0x060080B0 RID: 32944 RVA: 0x005F6484 File Offset: 0x005F4684
		Private _GelButtonNewRecord As GelButton
		Friend Overridable Property GelButtonNewRecord As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim gelButton As GelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				gelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002F39 RID: 12089
		' (get) Token: 0x060080B1 RID: 32945 RVA: 0x0003F26E File Offset: 0x0003D46E
		' (set) Token: 0x060080B2 RID: 32946 RVA: 0x005F64C8 File Offset: 0x005F46C8
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

		' Token: 0x17002F3A RID: 12090
		' (get) Token: 0x060080B3 RID: 32947 RVA: 0x0003F278 File Offset: 0x0003D478
		' (set) Token: 0x060080B4 RID: 32948 RVA: 0x005F650C File Offset: 0x005F470C
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView2_EditingControlShowing
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellEndEdit
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002F3B RID: 12091
		' (get) Token: 0x060080B5 RID: 32949 RVA: 0x0003F282 File Offset: 0x0003D482
		' (set) Token: 0x060080B6 RID: 32950 RVA: 0x0003F28C File Offset: 0x0003D48C
		Friend Overridable Property Label14 As Label

		' Token: 0x17002F3C RID: 12092
		' (get) Token: 0x060080B7 RID: 32951 RVA: 0x0003F295 File Offset: 0x0003D495
		' (set) Token: 0x060080B8 RID: 32952 RVA: 0x0003F29F File Offset: 0x0003D49F
		Friend Overridable Property Label13 As Label

		' Token: 0x17002F3D RID: 12093
		' (get) Token: 0x060080B9 RID: 32953 RVA: 0x0003F2A8 File Offset: 0x0003D4A8
		' (set) Token: 0x060080BA RID: 32954 RVA: 0x0003F2B2 File Offset: 0x0003D4B2
		Friend Overridable Property PID2 As DataGridViewTextBoxColumn

		' Token: 0x17002F3E RID: 12094
		' (get) Token: 0x060080BB RID: 32955 RVA: 0x0003F2BB File Offset: 0x0003D4BB
		' (set) Token: 0x060080BC RID: 32956 RVA: 0x0003F2C5 File Offset: 0x0003D4C5
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17002F3F RID: 12095
		' (get) Token: 0x060080BD RID: 32957 RVA: 0x0003F2CE File Offset: 0x0003D4CE
		' (set) Token: 0x060080BE RID: 32958 RVA: 0x0003F2D8 File Offset: 0x0003D4D8
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17002F40 RID: 12096
		' (get) Token: 0x060080BF RID: 32959 RVA: 0x0003F2E1 File Offset: 0x0003D4E1
		' (set) Token: 0x060080C0 RID: 32960 RVA: 0x0003F2EB File Offset: 0x0003D4EB
		Friend Overridable Property CategoryName As DataGridViewTextBoxColumn

		' Token: 0x17002F41 RID: 12097
		' (get) Token: 0x060080C1 RID: 32961 RVA: 0x0003F2F4 File Offset: 0x0003D4F4
		' (set) Token: 0x060080C2 RID: 32962 RVA: 0x0003F2FE File Offset: 0x0003D4FE
		Friend Overridable Property DataGridViewButtonColumn1 As DataGridViewButtonColumn

		' Token: 0x17002F42 RID: 12098
		' (get) Token: 0x060080C3 RID: 32963 RVA: 0x0003F307 File Offset: 0x0003D507
		' (set) Token: 0x060080C4 RID: 32964 RVA: 0x0003F311 File Offset: 0x0003D511
		Friend Overridable Property SubCategoryName As DataGridViewTextBoxColumn

		' Token: 0x17002F43 RID: 12099
		' (get) Token: 0x060080C5 RID: 32965 RVA: 0x0003F31A File Offset: 0x0003D51A
		' (set) Token: 0x060080C6 RID: 32966 RVA: 0x0003F324 File Offset: 0x0003D524
		Friend Overridable Property DataGridViewButtonColumn2 As DataGridViewButtonColumn

		' Token: 0x17002F44 RID: 12100
		' (get) Token: 0x060080C7 RID: 32967 RVA: 0x0003F32D File Offset: 0x0003D52D
		' (set) Token: 0x060080C8 RID: 32968 RVA: 0x0003F337 File Offset: 0x0003D537
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17002F45 RID: 12101
		' (get) Token: 0x060080C9 RID: 32969 RVA: 0x0003F340 File Offset: 0x0003D540
		' (set) Token: 0x060080CA RID: 32970 RVA: 0x0003F34A File Offset: 0x0003D54A
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17002F46 RID: 12102
		' (get) Token: 0x060080CB RID: 32971 RVA: 0x0003F353 File Offset: 0x0003D553
		' (set) Token: 0x060080CC RID: 32972 RVA: 0x0003F35D File Offset: 0x0003D55D
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17002F47 RID: 12103
		' (get) Token: 0x060080CD RID: 32973 RVA: 0x0003F366 File Offset: 0x0003D566
		' (set) Token: 0x060080CE RID: 32974 RVA: 0x0003F370 File Offset: 0x0003D570
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17002F48 RID: 12104
		' (get) Token: 0x060080CF RID: 32975 RVA: 0x0003F379 File Offset: 0x0003D579
		' (set) Token: 0x060080D0 RID: 32976 RVA: 0x0003F383 File Offset: 0x0003D583
		Friend Overridable Property CostPrice As DataGridViewTextBoxColumn

		' Token: 0x17002F49 RID: 12105
		' (get) Token: 0x060080D1 RID: 32977 RVA: 0x0003F38C File Offset: 0x0003D58C
		' (set) Token: 0x060080D2 RID: 32978 RVA: 0x0003F396 File Offset: 0x0003D596
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17002F4A RID: 12106
		' (get) Token: 0x060080D3 RID: 32979 RVA: 0x0003F39F File Offset: 0x0003D59F
		' (set) Token: 0x060080D4 RID: 32980 RVA: 0x0003F3A9 File Offset: 0x0003D5A9
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17002F4B RID: 12107
		' (get) Token: 0x060080D5 RID: 32981 RVA: 0x0003F3B2 File Offset: 0x0003D5B2
		' (set) Token: 0x060080D6 RID: 32982 RVA: 0x0003F3BC File Offset: 0x0003D5BC
		Friend Overridable Property cmbGST1 As DataGridViewTextBoxColumn

		' Token: 0x17002F4C RID: 12108
		' (get) Token: 0x060080D7 RID: 32983 RVA: 0x0003F3C5 File Offset: 0x0003D5C5
		' (set) Token: 0x060080D8 RID: 32984 RVA: 0x0003F3CF File Offset: 0x0003D5CF
		Friend Overridable Property DataGridViewButtonColumn3 As DataGridViewButtonColumn

		' Token: 0x17002F4D RID: 12109
		' (get) Token: 0x060080D9 RID: 32985 RVA: 0x0003F3D8 File Offset: 0x0003D5D8
		' (set) Token: 0x060080DA RID: 32986 RVA: 0x0003F3E2 File Offset: 0x0003D5E2
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17002F4E RID: 12110
		' (get) Token: 0x060080DB RID: 32987 RVA: 0x0003F3EB File Offset: 0x0003D5EB
		' (set) Token: 0x060080DC RID: 32988 RVA: 0x0003F3F5 File Offset: 0x0003D5F5
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17002F4F RID: 12111
		' (get) Token: 0x060080DD RID: 32989 RVA: 0x0003F3FE File Offset: 0x0003D5FE
		' (set) Token: 0x060080DE RID: 32990 RVA: 0x0003F408 File Offset: 0x0003D608
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17002F50 RID: 12112
		' (get) Token: 0x060080DF RID: 32991 RVA: 0x0003F411 File Offset: 0x0003D611
		' (set) Token: 0x060080E0 RID: 32992 RVA: 0x0003F41B File Offset: 0x0003D61B
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17002F51 RID: 12113
		' (get) Token: 0x060080E1 RID: 32993 RVA: 0x0003F424 File Offset: 0x0003D624
		' (set) Token: 0x060080E2 RID: 32994 RVA: 0x0003F42E File Offset: 0x0003D62E
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17002F52 RID: 12114
		' (get) Token: 0x060080E3 RID: 32995 RVA: 0x0003F437 File Offset: 0x0003D637
		' (set) Token: 0x060080E4 RID: 32996 RVA: 0x0003F441 File Offset: 0x0003D641
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17002F53 RID: 12115
		' (get) Token: 0x060080E5 RID: 32997 RVA: 0x0003F44A File Offset: 0x0003D64A
		' (set) Token: 0x060080E6 RID: 32998 RVA: 0x0003F454 File Offset: 0x0003D654
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17002F54 RID: 12116
		' (get) Token: 0x060080E7 RID: 32999 RVA: 0x0003F45D File Offset: 0x0003D65D
		' (set) Token: 0x060080E8 RID: 33000 RVA: 0x0003F467 File Offset: 0x0003D667
		Friend Overridable Property cmbPurchaseUnit2 As DataGridViewTextBoxColumn

		' Token: 0x17002F55 RID: 12117
		' (get) Token: 0x060080E9 RID: 33001 RVA: 0x0003F470 File Offset: 0x0003D670
		' (set) Token: 0x060080EA RID: 33002 RVA: 0x0003F47A File Offset: 0x0003D67A
		Friend Overridable Property cmbSalesUnit2 As DataGridViewTextBoxColumn

		' Token: 0x17002F56 RID: 12118
		' (get) Token: 0x060080EB RID: 33003 RVA: 0x0003F483 File Offset: 0x0003D683
		' (set) Token: 0x060080EC RID: 33004 RVA: 0x0003F48D File Offset: 0x0003D68D
		Friend Overridable Property cmbAltunit2 As DataGridViewTextBoxColumn

		' Token: 0x17002F57 RID: 12119
		' (get) Token: 0x060080ED RID: 33005 RVA: 0x0003F496 File Offset: 0x0003D696
		' (set) Token: 0x060080EE RID: 33006 RVA: 0x0003F4A0 File Offset: 0x0003D6A0
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17002F58 RID: 12120
		' (get) Token: 0x060080EF RID: 33007 RVA: 0x0003F4A9 File Offset: 0x0003D6A9
		' (set) Token: 0x060080F0 RID: 33008 RVA: 0x0003F4B3 File Offset: 0x0003D6B3
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17002F59 RID: 12121
		' (get) Token: 0x060080F1 RID: 33009 RVA: 0x0003F4BC File Offset: 0x0003D6BC
		' (set) Token: 0x060080F2 RID: 33010 RVA: 0x0003F4C6 File Offset: 0x0003D6C6
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17002F5A RID: 12122
		' (get) Token: 0x060080F3 RID: 33011 RVA: 0x0003F4CF File Offset: 0x0003D6CF
		' (set) Token: 0x060080F4 RID: 33012 RVA: 0x0003F4D9 File Offset: 0x0003D6D9
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17002F5B RID: 12123
		' (get) Token: 0x060080F5 RID: 33013 RVA: 0x0003F4E2 File Offset: 0x0003D6E2
		' (set) Token: 0x060080F6 RID: 33014 RVA: 0x0003F4EC File Offset: 0x0003D6EC
		Friend Overridable Property cmbSalesTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x17002F5C RID: 12124
		' (get) Token: 0x060080F7 RID: 33015 RVA: 0x0003F4F5 File Offset: 0x0003D6F5
		' (set) Token: 0x060080F8 RID: 33016 RVA: 0x0003F4FF File Offset: 0x0003D6FF
		Friend Overridable Property cmbPurchaseTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x17002F5D RID: 12125
		' (get) Token: 0x060080F9 RID: 33017 RVA: 0x0003F508 File Offset: 0x0003D708
		' (set) Token: 0x060080FA RID: 33018 RVA: 0x0003F512 File Offset: 0x0003D712
		Friend Overridable Property ddlGdown2 As DataGridViewTextBoxColumn

		' Token: 0x17002F5E RID: 12126
		' (get) Token: 0x060080FB RID: 33019 RVA: 0x0003F51B File Offset: 0x0003D71B
		' (set) Token: 0x060080FC RID: 33020 RVA: 0x0003F525 File Offset: 0x0003D725
		Friend Overridable Property ddlRack2 As DataGridViewTextBoxColumn

		' Token: 0x17002F5F RID: 12127
		' (get) Token: 0x060080FD RID: 33021 RVA: 0x0003F52E File Offset: 0x0003D72E
		' (set) Token: 0x060080FE RID: 33022 RVA: 0x0003F538 File Offset: 0x0003D738
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17002F60 RID: 12128
		' (get) Token: 0x060080FF RID: 33023 RVA: 0x0003F541 File Offset: 0x0003D741
		' (set) Token: 0x06008100 RID: 33024 RVA: 0x0003F54B File Offset: 0x0003D74B
		Friend Overridable Property txtOpeningStock2 As DataGridViewTextBoxColumn

		' Token: 0x17002F61 RID: 12129
		' (get) Token: 0x06008101 RID: 33025 RVA: 0x0003F554 File Offset: 0x0003D754
		' (set) Token: 0x06008102 RID: 33026 RVA: 0x0003F55E File Offset: 0x0003D75E
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17002F62 RID: 12130
		' (get) Token: 0x06008103 RID: 33027 RVA: 0x0003F567 File Offset: 0x0003D767
		' (set) Token: 0x06008104 RID: 33028 RVA: 0x0003F571 File Offset: 0x0003D771
		Friend Overridable Property txtMRP As DataGridViewTextBoxColumn

		' Token: 0x17002F63 RID: 12131
		' (get) Token: 0x06008105 RID: 33029 RVA: 0x0003F57A File Offset: 0x0003D77A
		' (set) Token: 0x06008106 RID: 33030 RVA: 0x0003F584 File Offset: 0x0003D784
		Friend Overridable Property txtRSP1 As DataGridViewTextBoxColumn

		' Token: 0x17002F64 RID: 12132
		' (get) Token: 0x06008107 RID: 33031 RVA: 0x0003F58D File Offset: 0x0003D78D
		' (set) Token: 0x06008108 RID: 33032 RVA: 0x0003F597 File Offset: 0x0003D797
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17002F65 RID: 12133
		' (get) Token: 0x06008109 RID: 33033 RVA: 0x0003F5A0 File Offset: 0x0003D7A0
		' (set) Token: 0x0600810A RID: 33034 RVA: 0x0003F5AA File Offset: 0x0003D7AA
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17002F66 RID: 12134
		' (get) Token: 0x0600810B RID: 33035 RVA: 0x0003F5B3 File Offset: 0x0003D7B3
		' (set) Token: 0x0600810C RID: 33036 RVA: 0x0003F5BD File Offset: 0x0003D7BD
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17002F67 RID: 12135
		' (get) Token: 0x0600810D RID: 33037 RVA: 0x0003F5C6 File Offset: 0x0003D7C6
		' (set) Token: 0x0600810E RID: 33038 RVA: 0x0003F5D0 File Offset: 0x0003D7D0
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17002F68 RID: 12136
		' (get) Token: 0x0600810F RID: 33039 RVA: 0x0003F5D9 File Offset: 0x0003D7D9
		' (set) Token: 0x06008110 RID: 33040 RVA: 0x0003F5E3 File Offset: 0x0003D7E3
		Friend Overridable Property cmbSize2 As DataGridViewTextBoxColumn

		' Token: 0x17002F69 RID: 12137
		' (get) Token: 0x06008111 RID: 33041 RVA: 0x0003F5EC File Offset: 0x0003D7EC
		' (set) Token: 0x06008112 RID: 33042 RVA: 0x0003F5F6 File Offset: 0x0003D7F6
		Friend Overridable Property cmbColour2 As DataGridViewTextBoxColumn

		' Token: 0x17002F6A RID: 12138
		' (get) Token: 0x06008113 RID: 33043 RVA: 0x0003F5FF File Offset: 0x0003D7FF
		' (set) Token: 0x06008114 RID: 33044 RVA: 0x0003F609 File Offset: 0x0003D809
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17002F6B RID: 12139
		' (get) Token: 0x06008115 RID: 33045 RVA: 0x0003F612 File Offset: 0x0003D812
		' (set) Token: 0x06008116 RID: 33046 RVA: 0x0003F61C File Offset: 0x0003D81C
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17002F6C RID: 12140
		' (get) Token: 0x06008117 RID: 33047 RVA: 0x0003F625 File Offset: 0x0003D825
		' (set) Token: 0x06008118 RID: 33048 RVA: 0x0003F62F File Offset: 0x0003D82F
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17002F6D RID: 12141
		' (get) Token: 0x06008119 RID: 33049 RVA: 0x0003F638 File Offset: 0x0003D838
		' (set) Token: 0x0600811A RID: 33050 RVA: 0x0003F642 File Offset: 0x0003D842
		Friend Overridable Property Photo As DataGridViewImageColumn

		' Token: 0x17002F6E RID: 12142
		' (get) Token: 0x0600811B RID: 33051 RVA: 0x0003F64B File Offset: 0x0003D84B
		' (set) Token: 0x0600811C RID: 33052 RVA: 0x0003F655 File Offset: 0x0003D855
		Friend Overridable Property btnAddNew As DataGridViewButtonColumn

		' Token: 0x1400002F RID: 47
		' (add) Token: 0x0600811D RID: 33053 RVA: 0x005F65AC File Offset: 0x005F47AC
		' (remove) Token: 0x0600811E RID: 33054 RVA: 0x005F65E4 File Offset: 0x005F47E4
		Public Event frmProductRec_variantClosed As frmProductRec_variant.frmProductRec_variantClosedEventHandler

		' Token: 0x0600811F RID: 33055 RVA: 0x005F661C File Offset: 0x005F481C
		Private Sub frmProductRec_variant_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Me.auto()
			Me.GenerateBarcode()
			Me.DataforNP()
			Me.fillProductID()
			Me.BarcodeRemoveAll()
			Me.Getdata_variant(Conversions.ToShort(Me.Label14.Text), Me.strBarcode)
			Dim flag As Boolean = Conversion.Val(Me.Label13.Text) > 0.0
			If flag Then
				Me.initialQty = Conversions.ToDecimal(Me.Label13.Text)
				Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value = Me.initialQty
			Else
				Me.initialQty = 1D
				Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value = Me.initialQty
			End If
			Me.DataGridView2.Rows(1).Cells("CostPrice").Value = Me.DataGridView2.Rows(0).Cells("CostPrice").Value.ToString()
			Dim index As Integer = Me.DataGridView2.Columns("txtOpeningStock2").Index
			Me.initialQty = Decimal.Parse(Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value.ToString())
			Dim flag2 As Boolean = Me.DataGridView2.CurrentRow IsNot Nothing
			If flag2 Then
				' The following expression was wrapped in a checked-expression
				Dim num As Integer = Me.DataGridView2.CurrentRow.Index + 1
				Dim flag3 As Boolean = num < Me.DataGridView2.Rows.Count
				If flag3 Then
					Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(num).Cells(index)
					Me.DataGridView2.BeginEdit(True)
				End If
			End If
		End Sub

		' Token: 0x06008120 RID: 33056 RVA: 0x005C56AC File Offset: 0x005C38AC
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

		' Token: 0x06008121 RID: 33057 RVA: 0x005F6830 File Offset: 0x005F4A30
		Private Sub DataforNP()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
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

		' Token: 0x06008122 RID: 33058 RVA: 0x0020DD08 File Offset: 0x0020BF08
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

		' Token: 0x06008123 RID: 33059 RVA: 0x005F691C File Offset: 0x005F4B1C
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008124 RID: 33060 RVA: 0x005F69A0 File Offset: 0x005F4BA0
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

		' Token: 0x06008125 RID: 33061 RVA: 0x005EDB9C File Offset: 0x005EBD9C
		Private Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes'  and Temp_Stock.barcode in(" + barcode + ")"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = ModCommonClasses.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				ModCommonClasses.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x06008126 RID: 33062 RVA: 0x005F6A88 File Offset: 0x005F4C88
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

		' Token: 0x06008127 RID: 33063 RVA: 0x005F6BBC File Offset: 0x005F4DBC
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06008128 RID: 33064 RVA: 0x005F6C40 File Offset: 0x005F4E40
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008129 RID: 33065 RVA: 0x0011427C File Offset: 0x0011247C
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

		' Token: 0x0600812A RID: 33066 RVA: 0x005F6CB4 File Offset: 0x005F4EB4
		Public Sub Getdata_variant(Id As Short, strBarcode As String)
			Try
				Me.Label14.Text = Conversions.ToString(CInt(Id))
				Me.Cursor = Cursors.WaitCursor
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "Select PID, RTRIM(ProductCode) as ProductCode, RTRIM(Productname) as Productname, " & vbCrLf & "                RTRIM(CategoryName) as CategoryName, '' as Col4, RTRIM(SubCategoryName) as SubCategoryName, '' as Col6," & vbCrLf & "                SubCategoryID, RTRIM(HSNCode) as HSNCode, RTRIM(PartNo) as PartNo, RTRIM(Description) As Description," & vbCrLf & "                CostPrice, SellingPrice, Discount, '' as Col14, (CGST+SGST) as GST, CGST, SGST, (CGST+SGST) as IGST," & vbCrLf & "                CESS, ReorderPoint, RTRIM(Product.Barcode) as Barcode, OpeningStock, RTRIM(PurchaseUnit) as PurchaseUnit," & vbCrLf & "                RTRIM(Salesunit) as SalesUnit, RTRIM(SalesAltUnit) as SalesAltUnit, RTRIM(Conv) as Conv, RTRIM(MinStock) as MinStock," & vbCrLf & "                Product.MRP, RTRIM(Product.Status) as Status, Product.STax, Product.PTax, RTRIM(Product.GDown) as GDown," & vbCrLf & "                RTRIM(Product.Rack) as Rack, Product.DefQty, Temp_Stock.Qty as txtOpeningStock2, RTRIM(Temp_Stock.Barcode) as TempBarcode," & vbCrLf & "                Temp_Stock.MRP, Temp_Stock.SPrice, Temp_Stock.WPrice, RTRIM(Temp_Stock.Batch) as Batch, Temp_Stock.Mfgdate," & vbCrLf & "                Temp_Stock.Expdate, RTRIM(Temp_Stock.Size) as Size, RTRIM(Temp_Stock.Colour) as Colour, RTRIM(Product.Kitchen) as Kitchen," & vbCrLf & "                temp_Stock.IMEI1, temp_Stock.IMEI2, Photo, Temp_Stock.StLimit, Temp_Stock.SalePrice, Temp_Stock.WSalePrice, Temp_Stock.PPrice, Temp_Stock.EPPrice, Temp_Stock.QrBarcode, Temp_Stock.SalesManPur" & vbCrLf & "                from Category, SubCategory, Product, Temp_Stock, Product_Join " & vbCrLf & "                where Category.CategoryName = SubCategory.Category and Product.SubCategoryID = SubCategory.ID " & vbCrLf & "                and Temp_Stock.ProductID = Product.PID and Product.PID = Product_Join.ProductID " & vbCrLf & "                and Temp_Stock.Variant_id = @Id order by PID ASC", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Id", Id)
					sqlCommand.CommandTimeout = 0
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
					Me.dt.Rows.Clear()
					sqlDataAdapter.Fill(Me.dt)
					Me.DataGridView2.DataSource = Nothing
					Me.DataGridView2.Rows.Clear()
					Dim flag As Boolean = Me.dt.Rows.Count > 0
					If flag Then
						Try
							For Each obj As Object In Me.dt.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Me.DataGridView2.Rows.Add(dataRow.ItemArray)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End If
					Me.DataGridView2.ClearSelection()
					RemoveHandler Me.DataGridView2.KeyDown, AddressOf Me.DataGridView2_KeyDown
					AddHandler Me.DataGridView2.KeyDown, AddressOf Me.DataGridView2_KeyDown
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(1).Cells("txtOpeningStock2")
				Me.DataGridView2.BeginEdit(True)
			End Try
		End Sub

		' Token: 0x0600812B RID: 33067 RVA: 0x005F6EF0 File Offset: 0x005F50F0
		Private Sub gridtodatatable()
			Dim dataTable As DataTable = New DataTable()
			Try
				For Each obj As Object In Me.DataGridView2.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim type As Type = If(dataGridViewColumn.ValueType, GetType(String))
					dataTable.Columns.Add(dataGridViewColumn.HeaderText, type)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim num As Integer = Me.DataGridView2.Rows.Count - 1
			For i As Integer = 1 To num
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
				Dim flag As Boolean = Not dataGridViewRow.IsNewRow
				If flag Then
					Dim dataRow As DataRow = dataTable.NewRow()
					Dim num2 As Integer = Me.DataGridView2.Columns.Count - 1
					For j As Integer = 0 To num2
						dataRow(j) = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(j).Value)
					Next
					dataTable.Rows.Add(dataRow)
				End If
			Next
		End Sub

		' Token: 0x0600812C RID: 33068 RVA: 0x005F7030 File Offset: 0x005F5230
		Private Sub DataGridView2_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewTextBoxCell
				If flag Then
					Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
					RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600812D RID: 33069 RVA: 0x005EE6FC File Offset: 0x005EC8FC
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = editingControlDataGridView.ColumnCount - 1
				Dim num As Integer
				Dim num2 As Integer
				If flag2 Then
					num = editingControlDataGridView.CurrentCell.RowIndex + 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 1
					While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
						num2 += 1
					End While
				End If
				Dim flag4 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 19
				If flag4 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 4
				End If
				While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
					num2 += 1
				End While
				Dim flag5 As Boolean = num2 < editingControlDataGridView.ColumnCount
				If flag5 Then
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
					Dim flag6 As Boolean = New Integer() { 3, 5, 8, 14, 23, 32, 33, 45, 46 }.Contains(num2)
					If flag6 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x0600812E RID: 33070 RVA: 0x005F70AC File Offset: 0x005F52AC
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("btnAddNew").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
				Me.DataGridView2.[ReadOnly] = False
				Dim num As Integer = Me.DataGridView2.Rows.Count - 1
				Dim num2 As Integer = 35
				Me.DataGridView2.Rows(num).Cells("CostPrice").Value = Me.DataGridView2.Rows(0).Cells("CostPrice").Value.ToString()
				Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(num).Cells(num2)
				Me.DataGridView2.BeginEdit(True)
			End If
		End Sub

		' Token: 0x0600812F RID: 33071 RVA: 0x005F71B4 File Offset: 0x005F53B4
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 11
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 24, dataGridView.CurrentCell.RowIndex)
						Else
							Dim flag4 As Boolean = dataGridView.CurrentCell.ColumnIndex = 35
							If flag4 Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 8, dataGridView.CurrentCell.RowIndex)
							Else
								Dim visible As Boolean = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex).Visible
								If visible Then
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
								Else
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)
								End If
							End If
						End If
					Else
						Dim flag5 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag5 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex As Integer = Me.DataGridView2.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView2.CurrentCell.ColumnIndex
					Dim flag6 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag6 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "btnAddNew", False) = 0 Then
							Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008130 RID: 33072 RVA: 0x005F73EC File Offset: 0x005F55EC
		Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView2 IsNot Nothing AndAlso Me.DataGridView2.Columns.Contains("txtOpeningStock2")
				If flag Then
					Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("txtOpeningStock2").Index
					If flag2 Then
						Me.CalculateColumnSum()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in CellEndEdit: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06008131 RID: 33073 RVA: 0x005F7488 File Offset: 0x005F5688
		Private Sub CalculateColumnSum()
			Dim flag As Boolean = Me.dt.Rows.Count = 1
			If flag Then
				Dim num As Decimal = 0D
				Dim text As String = "txtOpeningStock2"
				Dim num2 As Integer = Me.DataGridView2.Rows.Count - 1
				For i As Integer = 1 To num2
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
					Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
					If flag2 Then
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(text).Value)
						Dim num3 As Decimal = 0D
						Dim flag3 As Boolean = Decimal.TryParse(objectValue.ToString(), num3)
						If flag3 Then
							num = Decimal.Add(num, num3)
							Dim num4 As Decimal = Decimal.Subtract(Me.initialQty, num)
							Me.DataGridView2.Rows(0).Cells(text).Value = num4
						End If
					End If
				Next
			End If
		End Sub

		' Token: 0x06008132 RID: 33074 RVA: 0x005F7588 File Offset: 0x005F5788
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = Conversions.ToString(Me.dt.Rows(0)("Productname"))
			Dim text2 As String = Conversions.ToString(Me.dt.Rows(0)("CategoryName"))
			Dim flag As Boolean = Me.dt.Rows.Count > 0
			If flag Then
				Try
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					For i As Integer = 1 To num
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow

							If Not isNewRow Then
								Me.txtID.Text = Me.GenerateID()
								Me.txtProductCode.Text = "P-" + Me.GenerateID()
								Me.BCodeDisplay()
								Dim text3 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
								Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text3
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "        Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("Productname").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.dt.Rows(0)("SubCategoryID").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dt.Rows(0)("Description").ToString())
								Dim flag2 As Boolean = dataGridViewRow.Cells("CostPrice").Value IsNot Nothing
								If flag2 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.dt.Rows(0)("Discount").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.dt.Rows(0)("CGST").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtBarcodeTempStock.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("PurchaseUnit").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("SalesUnit").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.dt.Rows(0)("SGST").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("HSNCode").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("PartNo").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("CESS").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.dt.Rows(0)("SalesAltUnit").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.dt.Rows(0)("Conv").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.dt.Rows(0)("MinStock").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.dt.Rows(0)("STax").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.dt.Rows(0)("PTax").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.dt.Rows(0)("GDown").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.dt.Rows(0)("Rack").ToString())
								Dim flag3 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag3 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d27", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Me.dt.Rows(0)("SPrice").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Me.dt.Rows(0)("ReorderPoint").ToString())
								Dim flag4 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag4 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d30", 0.0)
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d30", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Me.dt.Rows(0)("DefQty").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d33", "")
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModCommonClasses.con.Open()
								Dim text5 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								Try
									For Each obj As Object In CType(Me.DataGridView2.Rows, IEnumerable)
										Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim isNewRow2 As Boolean = dataGridViewRow2.IsNewRow
										If isNewRow2 Then
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim image As Image = CType(dataGridViewRow2.Cells("Photo").Value, Image)
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
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								ModCommonClasses.con.Close()
								ModCommonClasses.con.Open()
								Dim text6 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
								ModCommonClasses.cmd = New SqlCommand(text6)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag5 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag5 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0.0)
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								Dim flag6 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag6 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 0)
								End If
								Dim flag7 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag7 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								Dim flag8 As Boolean = Operators.ConditionalCompareObjectGreater(Me.dt.Rows(0)("WPrice"), 0, False)
								If flag8 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(Me.dt.Rows(0)("WPrice"))))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dt.Rows(0)("Batch").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.dt.Rows(0)("Mfgdate").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Expdate").ToString())
								Dim flag9 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag9 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
								End If
								Dim flag10 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag10 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
								Dim flag11 As Boolean = Operators.CompareString(Me.dt.Rows(0)("PTax").ToString(), "Inclusive", False) = 0
								Dim num2 As Double
								If flag11 Then
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								Else
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", num2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num2 * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)), 2)), "0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI1").ToString().Trim())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("IMEI2").ToString().Trim())
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.cmd.Parameters.Clear()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text7 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "        Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
								ModCommonClasses.cmd = New SqlCommand(text7)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag12 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag12 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0.0)
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcodeTempStock.Text)
								Dim flag13 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag13 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(Me.dt.Rows(0)("WPrice").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.dt.Rows(0)("StLimit").ToString()))
								Dim flag14 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag14 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", 0)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Batch").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.dt.Rows(0)("MfgDate").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.dt.Rows(0)("ExpDate").ToString())
								Dim flag15 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag15 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "")
								End If
								Dim flag16 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag16 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", "")
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("SalePrice").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("WSalePrice").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("IMEI1").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI2").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Convert.ToDecimal(Me.dt.Rows(0)("PPrice").ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Convert.ToDecimal(Me.dt.Rows(0)("EPPrice").ToString()))
								Me.Generate_GiftQR(Me.txtBarcodeTempStock.Text)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0.0)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("PID2").Value)))
								ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.cmd.Parameters.Clear()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text8)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesUnit").ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text9)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesAltUnit").ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text10 As String = "insert into temp_product(PID, qty, barcode, variant_id) Values (@d1,@d2, @d3, @d4)"
								ModCommonClasses.cmd = New SqlCommand(text10)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcodeTempStock.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.dt.Rows(0)("PID").ToString()))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If

					Next
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text11 As String = "insert into temp_product(PID, qty, barcode,variant_id) Values (@d1,@d2, @d3, @d4)"
					ModCommonClasses.cmd = New SqlCommand(text11)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.dt.Rows(0)("PID").ToString()))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value)))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dt.Rows(0)("TempBarcode").ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.dt.Rows(0)("PID").ToString()))
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				MyProject.Forms.frmPurchaseEntry.ReceivedValue3 = Me.Label14.Text.ToString()
				MyProject.Forms.frmPurchaseEntry.strStatus = "variant"
				MyBase.Dispose()
			End If
		End Sub

		' Token: 0x06008133 RID: 33075 RVA: 0x005EF02C File Offset: 0x005ED22C
		Private Sub frmProductRec_variant_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim msgBoxResult As MsgBoxResult = Interaction.MsgBox("Are you sure you want to Exit ?", MsgBoxStyle.YesNo, Nothing)
				Dim flag2 As Boolean = msgBoxResult = MsgBoxResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06008134 RID: 33076 RVA: 0x0003F65E File Offset: 0x0003D85E
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseEntry.ReceivedValue3 = Me.Label14.Text.ToString()
			MyProject.Forms.frmPurchaseEntry.strStatus = "variant"
			MyBase.Dispose()
		End Sub

		' Token: 0x04003906 RID: 14598
		Private strBarcode As String

		' Token: 0x04003907 RID: 14599
		Private dt As DataTable

		' Token: 0x04003908 RID: 14600
		Private initialQty As Decimal

		' Token: 0x04003909 RID: 14601
		Private Dad As SqlDataAdapter

		' Token: 0x0400390A RID: 14602
		Private Dst As DataSet

		' Token: 0x0400390B RID: 14603
		Private CurrentRow As Object

		' Token: 0x0400390C RID: 14604
		Private isd As String

		' Token: 0x020001E2 RID: 482
		' (Invoke) Token: 0x06008138 RID: 33080
		Public Delegate Sub frmProductRec_variantClosedEventHandler(value As String)
	End Class
End Namespace
