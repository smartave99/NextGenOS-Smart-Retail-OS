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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F9 RID: 505
	<DesignerGenerated()>
	Public Partial Class frmStock_Inward_Record
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600902F RID: 36911 RVA: 0x00046775 File Offset: 0x00044975
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700354F RID: 13647
		' (get) Token: 0x06009032 RID: 36914 RVA: 0x000467A7 File Offset: 0x000449A7
		' (set) Token: 0x06009033 RID: 36915 RVA: 0x000467B1 File Offset: 0x000449B1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003550 RID: 13648
		' (get) Token: 0x06009034 RID: 36916 RVA: 0x000467BA File Offset: 0x000449BA
		' (set) Token: 0x06009035 RID: 36917 RVA: 0x000467C4 File Offset: 0x000449C4
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003551 RID: 13649
		' (get) Token: 0x06009036 RID: 36918 RVA: 0x000467CD File Offset: 0x000449CD
		' (set) Token: 0x06009037 RID: 36919 RVA: 0x000467D7 File Offset: 0x000449D7
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17003552 RID: 13650
		' (get) Token: 0x06009038 RID: 36920 RVA: 0x000467E0 File Offset: 0x000449E0
		' (set) Token: 0x06009039 RID: 36921 RVA: 0x000467EA File Offset: 0x000449EA
		Friend Overridable Property Label2 As Label

		' Token: 0x17003553 RID: 13651
		' (get) Token: 0x0600903A RID: 36922 RVA: 0x000467F3 File Offset: 0x000449F3
		' (set) Token: 0x0600903B RID: 36923 RVA: 0x000467FD File Offset: 0x000449FD
		Friend Overridable Property Label4 As Label

		' Token: 0x17003554 RID: 13652
		' (get) Token: 0x0600903C RID: 36924 RVA: 0x00046806 File Offset: 0x00044A06
		' (set) Token: 0x0600903D RID: 36925 RVA: 0x00046810 File Offset: 0x00044A10
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003555 RID: 13653
		' (get) Token: 0x0600903E RID: 36926 RVA: 0x00046819 File Offset: 0x00044A19
		' (set) Token: 0x0600903F RID: 36927 RVA: 0x00046823 File Offset: 0x00044A23
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003556 RID: 13654
		' (get) Token: 0x06009040 RID: 36928 RVA: 0x0004682C File Offset: 0x00044A2C
		' (set) Token: 0x06009041 RID: 36929 RVA: 0x00046836 File Offset: 0x00044A36
		Friend Overridable Property lblSet As Label

		' Token: 0x17003557 RID: 13655
		' (get) Token: 0x06009042 RID: 36930 RVA: 0x0004683F File Offset: 0x00044A3F
		' (set) Token: 0x06009043 RID: 36931 RVA: 0x00046849 File Offset: 0x00044A49
		Friend Overridable Property Label1 As Label

		' Token: 0x17003558 RID: 13656
		' (get) Token: 0x06009044 RID: 36932 RVA: 0x00046852 File Offset: 0x00044A52
		' (set) Token: 0x06009045 RID: 36933 RVA: 0x0004685C File Offset: 0x00044A5C
		Friend Overridable Property lblUserType As Label

		' Token: 0x17003559 RID: 13657
		' (get) Token: 0x06009046 RID: 36934 RVA: 0x00046865 File Offset: 0x00044A65
		' (set) Token: 0x06009047 RID: 36935 RVA: 0x0004686F File Offset: 0x00044A6F
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700355A RID: 13658
		' (get) Token: 0x06009048 RID: 36936 RVA: 0x00046878 File Offset: 0x00044A78
		' (set) Token: 0x06009049 RID: 36937 RVA: 0x00046882 File Offset: 0x00044A82
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x1700355B RID: 13659
		' (get) Token: 0x0600904A RID: 36938 RVA: 0x0004688B File Offset: 0x00044A8B
		' (set) Token: 0x0600904B RID: 36939 RVA: 0x00046895 File Offset: 0x00044A95
		Friend Overridable Property Label13 As Label

		' Token: 0x1700355C RID: 13660
		' (get) Token: 0x0600904C RID: 36940 RVA: 0x0004689E File Offset: 0x00044A9E
		' (set) Token: 0x0600904D RID: 36941 RVA: 0x000468A8 File Offset: 0x00044AA8
		Friend Overridable Property Label12 As Label

		' Token: 0x1700355D RID: 13661
		' (get) Token: 0x0600904E RID: 36942 RVA: 0x000468B1 File Offset: 0x00044AB1
		' (set) Token: 0x0600904F RID: 36943 RVA: 0x000468BB File Offset: 0x00044ABB
		Friend Overridable Property Label11 As Label

		' Token: 0x1700355E RID: 13662
		' (get) Token: 0x06009050 RID: 36944 RVA: 0x000468C4 File Offset: 0x00044AC4
		' (set) Token: 0x06009051 RID: 36945 RVA: 0x000468CE File Offset: 0x00044ACE
		Friend Overridable Property Label16 As Label

		' Token: 0x1700355F RID: 13663
		' (get) Token: 0x06009052 RID: 36946 RVA: 0x000468D7 File Offset: 0x00044AD7
		' (set) Token: 0x06009053 RID: 36947 RVA: 0x000468E1 File Offset: 0x00044AE1
		Friend Overridable Property Label15 As Label

		' Token: 0x17003560 RID: 13664
		' (get) Token: 0x06009054 RID: 36948 RVA: 0x000468EA File Offset: 0x00044AEA
		' (set) Token: 0x06009055 RID: 36949 RVA: 0x000468F4 File Offset: 0x00044AF4
		Friend Overridable Property Label14 As Label

		' Token: 0x17003561 RID: 13665
		' (get) Token: 0x06009056 RID: 36950 RVA: 0x000468FD File Offset: 0x00044AFD
		' (set) Token: 0x06009057 RID: 36951 RVA: 0x00046907 File Offset: 0x00044B07
		Friend Overridable Property Label18 As Label

		' Token: 0x17003562 RID: 13666
		' (get) Token: 0x06009058 RID: 36952 RVA: 0x00046910 File Offset: 0x00044B10
		' (set) Token: 0x06009059 RID: 36953 RVA: 0x0004691A File Offset: 0x00044B1A
		Friend Overridable Property Label17 As Label

		' Token: 0x17003563 RID: 13667
		' (get) Token: 0x0600905A RID: 36954 RVA: 0x00046923 File Offset: 0x00044B23
		' (set) Token: 0x0600905B RID: 36955 RVA: 0x0004692D File Offset: 0x00044B2D
		Friend Overridable Property Label20 As Label

		' Token: 0x17003564 RID: 13668
		' (get) Token: 0x0600905C RID: 36956 RVA: 0x00046936 File Offset: 0x00044B36
		' (set) Token: 0x0600905D RID: 36957 RVA: 0x00046940 File Offset: 0x00044B40
		Friend Overridable Property Label19 As Label

		' Token: 0x17003565 RID: 13669
		' (get) Token: 0x0600905E RID: 36958 RVA: 0x00046949 File Offset: 0x00044B49
		' (set) Token: 0x0600905F RID: 36959 RVA: 0x00693810 File Offset: 0x00691A10
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

		' Token: 0x17003566 RID: 13670
		' (get) Token: 0x06009060 RID: 36960 RVA: 0x00046953 File Offset: 0x00044B53
		' (set) Token: 0x06009061 RID: 36961 RVA: 0x00693854 File Offset: 0x00691A54
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

		' Token: 0x17003567 RID: 13671
		' (get) Token: 0x06009062 RID: 36962 RVA: 0x0004695D File Offset: 0x00044B5D
		' (set) Token: 0x06009063 RID: 36963 RVA: 0x00693898 File Offset: 0x00691A98
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

		' Token: 0x17003568 RID: 13672
		' (get) Token: 0x06009064 RID: 36964 RVA: 0x00046967 File Offset: 0x00044B67
		' (set) Token: 0x06009065 RID: 36965 RVA: 0x006938DC File Offset: 0x00691ADC
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003569 RID: 13673
		' (get) Token: 0x06009066 RID: 36966 RVA: 0x00046971 File Offset: 0x00044B71
		' (set) Token: 0x06009067 RID: 36967 RVA: 0x0004697B File Offset: 0x00044B7B
		Friend Overridable Property lblFrom_Company_id As Label

		' Token: 0x1700356A RID: 13674
		' (get) Token: 0x06009068 RID: 36968 RVA: 0x00046984 File Offset: 0x00044B84
		' (set) Token: 0x06009069 RID: 36969 RVA: 0x0004698E File Offset: 0x00044B8E
		Friend Overridable Property lblUser As Label

		' Token: 0x1700356B RID: 13675
		' (get) Token: 0x0600906A RID: 36970 RVA: 0x00046997 File Offset: 0x00044B97
		' (set) Token: 0x0600906B RID: 36971 RVA: 0x000469A1 File Offset: 0x00044BA1
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x1700356C RID: 13676
		' (get) Token: 0x0600906C RID: 36972 RVA: 0x000469AA File Offset: 0x00044BAA
		' (set) Token: 0x0600906D RID: 36973 RVA: 0x000469B4 File Offset: 0x00044BB4
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x1700356D RID: 13677
		' (get) Token: 0x0600906E RID: 36974 RVA: 0x000469BD File Offset: 0x00044BBD
		' (set) Token: 0x0600906F RID: 36975 RVA: 0x000469C7 File Offset: 0x00044BC7
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x1700356E RID: 13678
		' (get) Token: 0x06009070 RID: 36976 RVA: 0x000469D0 File Offset: 0x00044BD0
		' (set) Token: 0x06009071 RID: 36977 RVA: 0x000469DA File Offset: 0x00044BDA
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700356F RID: 13679
		' (get) Token: 0x06009072 RID: 36978 RVA: 0x000469E3 File Offset: 0x00044BE3
		' (set) Token: 0x06009073 RID: 36979 RVA: 0x000469ED File Offset: 0x00044BED
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17003570 RID: 13680
		' (get) Token: 0x06009074 RID: 36980 RVA: 0x000469F6 File Offset: 0x00044BF6
		' (set) Token: 0x06009075 RID: 36981 RVA: 0x00046A00 File Offset: 0x00044C00
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003571 RID: 13681
		' (get) Token: 0x06009076 RID: 36982 RVA: 0x00046A09 File Offset: 0x00044C09
		' (set) Token: 0x06009077 RID: 36983 RVA: 0x00046A13 File Offset: 0x00044C13
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17003572 RID: 13682
		' (get) Token: 0x06009078 RID: 36984 RVA: 0x00046A1C File Offset: 0x00044C1C
		' (set) Token: 0x06009079 RID: 36985 RVA: 0x00046A26 File Offset: 0x00044C26
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003573 RID: 13683
		' (get) Token: 0x0600907A RID: 36986 RVA: 0x00046A2F File Offset: 0x00044C2F
		' (set) Token: 0x0600907B RID: 36987 RVA: 0x00046A39 File Offset: 0x00044C39
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17003574 RID: 13684
		' (get) Token: 0x0600907C RID: 36988 RVA: 0x00046A42 File Offset: 0x00044C42
		' (set) Token: 0x0600907D RID: 36989 RVA: 0x00046A4C File Offset: 0x00044C4C
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003575 RID: 13685
		' (get) Token: 0x0600907E RID: 36990 RVA: 0x00046A55 File Offset: 0x00044C55
		' (set) Token: 0x0600907F RID: 36991 RVA: 0x00046A5F File Offset: 0x00044C5F
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003576 RID: 13686
		' (get) Token: 0x06009080 RID: 36992 RVA: 0x00046A68 File Offset: 0x00044C68
		' (set) Token: 0x06009081 RID: 36993 RVA: 0x00046A72 File Offset: 0x00044C72
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003577 RID: 13687
		' (get) Token: 0x06009082 RID: 36994 RVA: 0x00046A7B File Offset: 0x00044C7B
		' (set) Token: 0x06009083 RID: 36995 RVA: 0x00046A85 File Offset: 0x00044C85
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003578 RID: 13688
		' (get) Token: 0x06009084 RID: 36996 RVA: 0x00046A8E File Offset: 0x00044C8E
		' (set) Token: 0x06009085 RID: 36997 RVA: 0x00046A98 File Offset: 0x00044C98
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003579 RID: 13689
		' (get) Token: 0x06009086 RID: 36998 RVA: 0x00046AA1 File Offset: 0x00044CA1
		' (set) Token: 0x06009087 RID: 36999 RVA: 0x00046AAB File Offset: 0x00044CAB
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x1700357A RID: 13690
		' (get) Token: 0x06009088 RID: 37000 RVA: 0x00046AB4 File Offset: 0x00044CB4
		' (set) Token: 0x06009089 RID: 37001 RVA: 0x00046ABE File Offset: 0x00044CBE
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700357B RID: 13691
		' (get) Token: 0x0600908A RID: 37002 RVA: 0x00046AC7 File Offset: 0x00044CC7
		' (set) Token: 0x0600908B RID: 37003 RVA: 0x00046AD1 File Offset: 0x00044CD1
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700357C RID: 13692
		' (get) Token: 0x0600908C RID: 37004 RVA: 0x00046ADA File Offset: 0x00044CDA
		' (set) Token: 0x0600908D RID: 37005 RVA: 0x00046AE4 File Offset: 0x00044CE4
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700357D RID: 13693
		' (get) Token: 0x0600908E RID: 37006 RVA: 0x00046AED File Offset: 0x00044CED
		' (set) Token: 0x0600908F RID: 37007 RVA: 0x00046AF7 File Offset: 0x00044CF7
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700357E RID: 13694
		' (get) Token: 0x06009090 RID: 37008 RVA: 0x00046B00 File Offset: 0x00044D00
		' (set) Token: 0x06009091 RID: 37009 RVA: 0x00046B0A File Offset: 0x00044D0A
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700357F RID: 13695
		' (get) Token: 0x06009092 RID: 37010 RVA: 0x00046B13 File Offset: 0x00044D13
		' (set) Token: 0x06009093 RID: 37011 RVA: 0x00046B1D File Offset: 0x00044D1D
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17003580 RID: 13696
		' (get) Token: 0x06009094 RID: 37012 RVA: 0x00046B26 File Offset: 0x00044D26
		' (set) Token: 0x06009095 RID: 37013 RVA: 0x00046B30 File Offset: 0x00044D30
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17003581 RID: 13697
		' (get) Token: 0x06009096 RID: 37014 RVA: 0x00046B39 File Offset: 0x00044D39
		' (set) Token: 0x06009097 RID: 37015 RVA: 0x00046B43 File Offset: 0x00044D43
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003582 RID: 13698
		' (get) Token: 0x06009098 RID: 37016 RVA: 0x00046B4C File Offset: 0x00044D4C
		' (set) Token: 0x06009099 RID: 37017 RVA: 0x00046B56 File Offset: 0x00044D56
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003583 RID: 13699
		' (get) Token: 0x0600909A RID: 37018 RVA: 0x00046B5F File Offset: 0x00044D5F
		' (set) Token: 0x0600909B RID: 37019 RVA: 0x00046B69 File Offset: 0x00044D69
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003584 RID: 13700
		' (get) Token: 0x0600909C RID: 37020 RVA: 0x00046B72 File Offset: 0x00044D72
		' (set) Token: 0x0600909D RID: 37021 RVA: 0x00046B7C File Offset: 0x00044D7C
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003585 RID: 13701
		' (get) Token: 0x0600909E RID: 37022 RVA: 0x00046B85 File Offset: 0x00044D85
		' (set) Token: 0x0600909F RID: 37023 RVA: 0x00046B8F File Offset: 0x00044D8F
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17003586 RID: 13702
		' (get) Token: 0x060090A0 RID: 37024 RVA: 0x00046B98 File Offset: 0x00044D98
		' (set) Token: 0x060090A1 RID: 37025 RVA: 0x00046BA2 File Offset: 0x00044DA2
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003587 RID: 13703
		' (get) Token: 0x060090A2 RID: 37026 RVA: 0x00046BAB File Offset: 0x00044DAB
		' (set) Token: 0x060090A3 RID: 37027 RVA: 0x00046BB5 File Offset: 0x00044DB5
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003588 RID: 13704
		' (get) Token: 0x060090A4 RID: 37028 RVA: 0x00046BBE File Offset: 0x00044DBE
		' (set) Token: 0x060090A5 RID: 37029 RVA: 0x00046BC8 File Offset: 0x00044DC8
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003589 RID: 13705
		' (get) Token: 0x060090A6 RID: 37030 RVA: 0x00046BD1 File Offset: 0x00044DD1
		' (set) Token: 0x060090A7 RID: 37031 RVA: 0x00046BDB File Offset: 0x00044DDB
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x1700358A RID: 13706
		' (get) Token: 0x060090A8 RID: 37032 RVA: 0x00046BE4 File Offset: 0x00044DE4
		' (set) Token: 0x060090A9 RID: 37033 RVA: 0x00046BEE File Offset: 0x00044DEE
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x1700358B RID: 13707
		' (get) Token: 0x060090AA RID: 37034 RVA: 0x00046BF7 File Offset: 0x00044DF7
		' (set) Token: 0x060090AB RID: 37035 RVA: 0x00046C01 File Offset: 0x00044E01
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x1700358C RID: 13708
		' (get) Token: 0x060090AC RID: 37036 RVA: 0x00046C0A File Offset: 0x00044E0A
		' (set) Token: 0x060090AD RID: 37037 RVA: 0x00046C14 File Offset: 0x00044E14
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700358D RID: 13709
		' (get) Token: 0x060090AE RID: 37038 RVA: 0x00046C1D File Offset: 0x00044E1D
		' (set) Token: 0x060090AF RID: 37039 RVA: 0x00046C27 File Offset: 0x00044E27
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700358E RID: 13710
		' (get) Token: 0x060090B0 RID: 37040 RVA: 0x00046C30 File Offset: 0x00044E30
		' (set) Token: 0x060090B1 RID: 37041 RVA: 0x00046C3A File Offset: 0x00044E3A
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x1700358F RID: 13711
		' (get) Token: 0x060090B2 RID: 37042 RVA: 0x00046C43 File Offset: 0x00044E43
		' (set) Token: 0x060090B3 RID: 37043 RVA: 0x00046C4D File Offset: 0x00044E4D
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17003590 RID: 13712
		' (get) Token: 0x060090B4 RID: 37044 RVA: 0x00046C56 File Offset: 0x00044E56
		' (set) Token: 0x060090B5 RID: 37045 RVA: 0x00046C60 File Offset: 0x00044E60
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17003591 RID: 13713
		' (get) Token: 0x060090B6 RID: 37046 RVA: 0x00046C69 File Offset: 0x00044E69
		' (set) Token: 0x060090B7 RID: 37047 RVA: 0x00046C73 File Offset: 0x00044E73
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17003592 RID: 13714
		' (get) Token: 0x060090B8 RID: 37048 RVA: 0x00046C7C File Offset: 0x00044E7C
		' (set) Token: 0x060090B9 RID: 37049 RVA: 0x00046C86 File Offset: 0x00044E86
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17003593 RID: 13715
		' (get) Token: 0x060090BA RID: 37050 RVA: 0x00046C8F File Offset: 0x00044E8F
		' (set) Token: 0x060090BB RID: 37051 RVA: 0x00046C99 File Offset: 0x00044E99
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17003594 RID: 13716
		' (get) Token: 0x060090BC RID: 37052 RVA: 0x00046CA2 File Offset: 0x00044EA2
		' (set) Token: 0x060090BD RID: 37053 RVA: 0x00046CAC File Offset: 0x00044EAC
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17003595 RID: 13717
		' (get) Token: 0x060090BE RID: 37054 RVA: 0x00046CB5 File Offset: 0x00044EB5
		' (set) Token: 0x060090BF RID: 37055 RVA: 0x00046CBF File Offset: 0x00044EBF
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17003596 RID: 13718
		' (get) Token: 0x060090C0 RID: 37056 RVA: 0x00046CC8 File Offset: 0x00044EC8
		' (set) Token: 0x060090C1 RID: 37057 RVA: 0x00046CD2 File Offset: 0x00044ED2
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17003597 RID: 13719
		' (get) Token: 0x060090C2 RID: 37058 RVA: 0x00046CDB File Offset: 0x00044EDB
		' (set) Token: 0x060090C3 RID: 37059 RVA: 0x00046CE5 File Offset: 0x00044EE5
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17003598 RID: 13720
		' (get) Token: 0x060090C4 RID: 37060 RVA: 0x00046CEE File Offset: 0x00044EEE
		' (set) Token: 0x060090C5 RID: 37061 RVA: 0x00046CF8 File Offset: 0x00044EF8
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17003599 RID: 13721
		' (get) Token: 0x060090C6 RID: 37062 RVA: 0x00046D01 File Offset: 0x00044F01
		' (set) Token: 0x060090C7 RID: 37063 RVA: 0x00046D0B File Offset: 0x00044F0B
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x1700359A RID: 13722
		' (get) Token: 0x060090C8 RID: 37064 RVA: 0x00046D14 File Offset: 0x00044F14
		' (set) Token: 0x060090C9 RID: 37065 RVA: 0x00046D1E File Offset: 0x00044F1E
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x1700359B RID: 13723
		' (get) Token: 0x060090CA RID: 37066 RVA: 0x00046D27 File Offset: 0x00044F27
		' (set) Token: 0x060090CB RID: 37067 RVA: 0x00046D31 File Offset: 0x00044F31
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x1700359C RID: 13724
		' (get) Token: 0x060090CC RID: 37068 RVA: 0x00046D3A File Offset: 0x00044F3A
		' (set) Token: 0x060090CD RID: 37069 RVA: 0x00046D44 File Offset: 0x00044F44
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700359D RID: 13725
		' (get) Token: 0x060090CE RID: 37070 RVA: 0x00046D4D File Offset: 0x00044F4D
		' (set) Token: 0x060090CF RID: 37071 RVA: 0x00046D57 File Offset: 0x00044F57
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700359E RID: 13726
		' (get) Token: 0x060090D0 RID: 37072 RVA: 0x00046D60 File Offset: 0x00044F60
		' (set) Token: 0x060090D1 RID: 37073 RVA: 0x00046D6A File Offset: 0x00044F6A
		Friend Overridable Property Label7 As Label

		' Token: 0x1700359F RID: 13727
		' (get) Token: 0x060090D2 RID: 37074 RVA: 0x00046D73 File Offset: 0x00044F73
		' (set) Token: 0x060090D3 RID: 37075 RVA: 0x00693920 File Offset: 0x00691B20
		Private _cboxStatus As ComboBox
		Friend Overridable Property cboxStatus As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cboxStatus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cboxStatus_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cboxStatus
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cboxStatus = value
				comboBox = Me._cboxStatus
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170035A0 RID: 13728
		' (get) Token: 0x060090D4 RID: 37076 RVA: 0x00046D7D File Offset: 0x00044F7D
		' (set) Token: 0x060090D5 RID: 37077 RVA: 0x00693964 File Offset: 0x00691B64
		Private _txtTransId As TextBox
		Friend Overridable Property txtTransId As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTransId
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTransId_TextChanged
				Dim textBox As TextBox = Me._txtTransId
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTransId = value
				textBox = Me._txtTransId
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170035A1 RID: 13729
		' (get) Token: 0x060090D6 RID: 37078 RVA: 0x00046D87 File Offset: 0x00044F87
		' (set) Token: 0x060090D7 RID: 37079 RVA: 0x00046D91 File Offset: 0x00044F91
		Friend Overridable Property Label3 As Label

		' Token: 0x170035A2 RID: 13730
		' (get) Token: 0x060090D8 RID: 37080 RVA: 0x00046D9A File Offset: 0x00044F9A
		' (set) Token: 0x060090D9 RID: 37081 RVA: 0x006939A8 File Offset: 0x00691BA8
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060090DA RID: 37082 RVA: 0x006939EC File Offset: 0x00691BEC
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
					Me.dtpDateTo.Value = DateAndTime.Today
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
			End Try
		End Sub

		' Token: 0x060090DB RID: 37083 RVA: 0x00693AD0 File Offset: 0x00691CD0
		Public Sub Getdata(from_companyid As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT " & vbCrLf & "    Inv_ID," & vbCrLf & "    RTRIM(InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceDate," & vbCrLf & "    RTRIM(TaxType) AS TaxType," & vbCrLf & vbCrLf & "    '' AS ID," & vbCrLf & "    '' AS CustomerID," & vbCrLf & "    '' AS CustomerName," & vbCrLf & "    '' AS ContactNo," & vbCrLf & "    '' AS State," & vbCrLf & "    '' AS GSTIN," & vbCrLf & vbCrLf & "    '' as SM_ID," & vbCrLf & "    InvoiceInfo_StockInward.SalesmanID," & vbCrLf & "    '' AS SalesmanName," & vbCrLf & vbCrLf & "    SubTotal," & vbCrLf & "    InvoiceInfo_StockInward.CGST," & vbCrLf & "    InvoiceInfo_StockInward.SGST," & vbCrLf & "    InvoiceInfo_StockInward.IGST," & vbCrLf & "    InvoiceInfo_StockInward.CESS," & vbCrLf & "    FreightCharges," & vbCrLf & "    OtherCharges," & vbCrLf & "    Total," & vbCrLf & "    RoundOff," & vbCrLf & "    GrandTotal," & vbCrLf & "    TotalPaid," & vbCrLf & "    Balance," & vbCrLf & "    RTRIM(InvoiceInfo_StockInward.Remarks) AS Remarks," & vbCrLf & "    RTRIM(Narration) AS Narration," & vbCrLf & "    RTRIM(Eway) AS Eway," & vbCrLf & "    RTRIM(TillID) AS TillID," & vbCrLf & "    RTRIM(Operator) AS Operator," & vbCrLf & "    RTRIM(BillSundry) AS BillSundry," & vbCrLf & "    RTRIM(OfferAmt) AS OfferAmt," & vbCrLf & "    RTRIM(LoyaAmt) AS LoyaAmt," & vbCrLf & "    RTRIM(BillDiscount) AS BillDiscount," & vbCrLf & "    '' AS City," & vbCrLf & vbCrLf & "    Tender," & vbCrLf & "    Refund," & vbCrLf & "    BillCash," & vbCrLf & "    CouponAmt," & vbCrLf & "    GiftAmt," & vbCrLf & "    '' AS Address," & vbCrLf & vbCrLf & "    SRNumber," & vbCrLf & "    ByReturn," & vbCrLf & "    TotalLoyalityPoints," & vbCrLf & "    LoyalityReedemPoints," & vbCrLf & "    LoyalityReedemAmt," & vbCrLf & vbCrLf & "    RTRIM(j.Barcode) AS Barcode," & vbCrLf & "    RTRIM(j.ProductName) AS ProductName," & vbCrLf & "    j.Qty AS Qty," & vbCrLf & vbCrLf & "    InvoiceInfo_StockInward.from_company_id," & vbCrLf & "    InvoiceInfo_StockInward.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS to_companyName,RTRIM(z.CompanyName) AS from_companyName," & vbCrLf & vbCrLf & "    CASE " & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 1 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS StatusText" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockInward" & vbCrLf & "INNER JOIN InvoiceInfo_Product_StockInward j ON InvoiceInfo_StockInward.inv_ID = j.invoiceID" & vbCrLf & "LEFT JOIN Branch_Relation y ON InvoiceInfo_StockInward.from_company_id = y.to_company_id" & vbCrLf & "LEFT JOIN RaintechMaster z on InvoiceInfo_StockInward.from_company_id = z.company_id" & vbCrLf & "where InvoiceInfo_StockInward.to_company_id=@d0 and InvoiceDate between @d1 and @d2 order by InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = from_companyid
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text2 As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("to_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim text4 As String = ModCommonClasses.rdr("from_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text2, num, text3, ModCommonClasses.rdr("from_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x060090DC RID: 37084 RVA: 0x00694108 File Offset: 0x00692308
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata(Me.lblFrom_Company_id.Text)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
			Me.cboxStatus.SelectedIndex = 0
		End Sub

		' Token: 0x060090DD RID: 37085 RVA: 0x006941B0 File Offset: 0x006923B0
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

		' Token: 0x060090DE RID: 37086 RVA: 0x00694328 File Offset: 0x00692528
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x060090DF RID: 37087 RVA: 0x006943F4 File Offset: 0x006925F4
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

		' Token: 0x060090E0 RID: 37088 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060090E1 RID: 37089 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060090E2 RID: 37090 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060090E3 RID: 37091 RVA: 0x006944C0 File Offset: 0x006926C0
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060090E4 RID: 37092 RVA: 0x006944E8 File Offset: 0x006926E8
		Public Sub RetrieveData1()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmStock_Settlement.Show()
				MyBase.Hide()
				MyProject.Forms.frmStock_Settlement.txtCompany_id_from.Text = Me.lblFrom_Company_id.Text
				MyProject.Forms.frmStock_Settlement.txtCompany_to.Text = dataGridViewRow.Cells(48).Value.ToString()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin,InvoiceInfo_Product_StockInward.Descr,InvoiceInfo_Product_StockInward.Qty,RTRIM(InvoiceInfo_Product_StockInward.IM1),RTRIM(InvoiceInfo_Product_StockInward.IM2),(InvoiceInfo_Product_StockInward.MRP),(InvoiceInfo_Product_StockInward.TaxableAmt),(InvoiceInfo_Product_StockInward.AltQty),(InvoiceInfo_Product_StockInward.AltUnit),(InvoiceInfo_Product_StockInward.STaxType),(InvoiceInfo_Product_StockInward.TotalMRP),(InvoiceInfo_Product_StockInward.PromoQty),RTRIM(InvoiceInfo_Product_StockInward.MainUnit),RTRIM(InvoiceInfo_Product_StockInward.Batch),RTRIM(InvoiceInfo_Product_StockInward.Mfg),RTRIM(InvoiceInfo_Product_StockInward.Exp),RTRIM(InvoiceInfo_Product_StockInward.Size),RTRIM(InvoiceInfo_Product_StockInward.Colour),InvoiceInfo_Product_StockInward.SalesManID,InvoiceInfo_Product_StockInward.SalesMan,InvoiceInfo_Product_StockInward.SalesManPur,InvoiceInfo_Product_StockInward.SalesManComm ,InvoiceInfo_Product_StockInward.StockID, InvoiceInfo_Product_StockInward.LoyalityPoints from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmStock_Settlement.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmStock_Settlement.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
				End While
				MyProject.Forms.frmStock_Settlement.DataGridView1.ClearSelection()
				ModCommonClasses.con.Close()
			End If
		End Sub

		' Token: 0x060090E5 RID: 37093 RVA: 0x0069490C File Offset: 0x00692B0C
		Public Sub RetrieveData()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPOSNewTuch_StockInward.Show()
				MyBase.Hide()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
				Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Text.Trim(), "Cash", False) = 0
				If flag2 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_StockInward.txtCompanyState.Text
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.CAddress = dataGridViewRow.Cells(40).Value.ToString()
				Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
				If flag3 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.cb1.Checked = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.cb1.Checked = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCompany_id_from.Text = Me.lblFrom_Company_id.Text
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCompany_to.Text = dataGridViewRow.Cells(48).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.btnSave.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnPrint.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Button5.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Button6.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.txtOffer.Text = "0.00"
				Dim flag4 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
				If flag4 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_StockInward.btnDelete.Enabled = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.btnUpdate.Enabled = False
					MyProject.Forms.frmPOSNewTuch_StockInward.btnDelete.Enabled = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.lblSet.Text = "Not Allowed"
				MyProject.Forms.frmPOSNewTuch_StockInward.btnAdd.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.txtContactNo.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnCustomerSelection.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox15.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Label82.Enabled = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin,InvoiceInfo_Product_StockInward.Descr,InvoiceInfo_Product_StockInward.Qty,RTRIM(InvoiceInfo_Product_StockInward.IM1),RTRIM(InvoiceInfo_Product_StockInward.IM2),(InvoiceInfo_Product_StockInward.MRP),(InvoiceInfo_Product_StockInward.TaxableAmt),(InvoiceInfo_Product_StockInward.AltQty),(InvoiceInfo_Product_StockInward.AltUnit),(InvoiceInfo_Product_StockInward.STaxType),(InvoiceInfo_Product_StockInward.TotalMRP),(InvoiceInfo_Product_StockInward.PromoQty),RTRIM(InvoiceInfo_Product_StockInward.MainUnit),RTRIM(InvoiceInfo_Product_StockInward.Batch),RTRIM(InvoiceInfo_Product_StockInward.Mfg),RTRIM(InvoiceInfo_Product_StockInward.Exp),RTRIM(InvoiceInfo_Product_StockInward.Size),RTRIM(InvoiceInfo_Product_StockInward.Colour),InvoiceInfo_Product_StockInward.SalesManID,InvoiceInfo_Product_StockInward.SalesMan,InvoiceInfo_Product_StockInward.SalesManPur,InvoiceInfo_Product_StockInward.SalesManComm ,InvoiceInfo_Product_StockInward.StockID, InvoiceInfo_Product_StockInward.LoyalityPoints from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
				End While
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.ClearSelection()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text4 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
				ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Visible = True
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				MyProject.Forms.frmPOSNewTuch_StockInward.CustomerBalance_Loyality()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calc()
				MyProject.Forms.frmPOSNewTuch_StockInward.Compute()
				MyProject.Forms.frmPOSNewTuch_StockInward.alldiscountcalc()
				MyProject.Forms.frmPOSNewTuch_StockInward.Bankcondn()
				MyProject.Forms.frmPOSNewTuch_StockInward.totitemnqty()
				MyProject.Forms.frmPOSNewTuch_StockInward.btnSelectSalesman.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnListReset1.PerformClick()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calculate12345()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calculate143()
				Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockInward.cmbBSundry.Text, "TCS", False) = 0
				If flag5 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.[ReadOnly] = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.Text = "0"
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.CTypeStatus()
				MyProject.Forms.frmPOSNewTuch_StockInward.BrokerRetrive()
				MyProject.Forms.frmPOSNewTuch_StockInward.CheckBox11.Checked = False
				MyProject.Forms.frmPOSNewTuch_StockInward.txtInvoiceNo.[ReadOnly] = True
			End If
		End Sub

		' Token: 0x060090E6 RID: 37094 RVA: 0x00695D18 File Offset: 0x00693F18
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

		' Token: 0x060090E7 RID: 37095 RVA: 0x00046DA4 File Offset: 0x00044FA4
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Me.Getdata(Me.lblFrom_Company_id.Text)
		End Sub

		' Token: 0x060090E8 RID: 37096 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060090E9 RID: 37097 RVA: 0x00695E00 File Offset: 0x00694000
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))
						End If

				Next
				Me.Label14.Text = Conversions.ToString(num4)
				Dim num5 As Integer = Me.dgw.Rows.Count - 1
				Dim num6 As Double
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))
						End If

				Next
				Me.Label15.Text = Conversions.ToString(num6)
				Dim num7 As Integer = Me.dgw.Rows.Count - 1
				Dim num8 As Double
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))
						End If

				Next
				Me.Label16.Text = Conversions.ToString(num8)
				Dim num9 As Integer = Me.dgw.Rows.Count - 1
				Dim num10 As Double
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))
						End If

				Next
				Me.Label18.Text = Conversions.ToString(num10)
				Dim num11 As Integer = Me.dgw.Rows.Count - 1
				Dim num12 As Double
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))
						End If

				Next
				Me.Label20.Text = Conversions.ToString(num12)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
			Me.Label14.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label14.Text), 2), "0.00")
			Me.Label15.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Me.Label16.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label16.Text), 2), "0.00")
			Me.Label18.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label18.Text), 2), "0.00")
			Me.Label20.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label20.Text), 2), "0.00")
		End Sub

		' Token: 0x060090EA RID: 37098 RVA: 0x00046DE2 File Offset: 0x00044FE2
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x060090EB RID: 37099 RVA: 0x00696364 File Offset: 0x00694564
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060090EC RID: 37100 RVA: 0x0004559D File Offset: 0x0004379D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesPmtInfo.ShowDialog()
		End Sub

		' Token: 0x060090ED RID: 37101 RVA: 0x00696610 File Offset: 0x00694810
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cboxStatus.Text, "Pending", False) = 0
				Dim text As String
				If flag Then
					text = "(0)"
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cboxStatus.Text, "Inward Done", False) = 0
					If flag2 Then
						text = "(1)"
					Else
						text = "(0, 1)"
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT " & vbCrLf & "    Inv_ID," & vbCrLf & "    RTRIM(InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceDate," & vbCrLf & "    RTRIM(TaxType) AS TaxType," & vbCrLf & vbCrLf & "    '' AS ID," & vbCrLf & "    '' AS CustomerID," & vbCrLf & "    '' AS CustomerName," & vbCrLf & "    '' AS ContactNo," & vbCrLf & "    '' AS State," & vbCrLf & "    '' AS GSTIN," & vbCrLf & vbCrLf & "    '' as SM_ID," & vbCrLf & "    InvoiceInfo_StockInward.SalesmanID," & vbCrLf & "    '' AS SalesmanName," & vbCrLf & vbCrLf & "    SubTotal," & vbCrLf & "    InvoiceInfo_StockInward.CGST," & vbCrLf & "    InvoiceInfo_StockInward.SGST," & vbCrLf & "    InvoiceInfo_StockInward.IGST," & vbCrLf & "    InvoiceInfo_StockInward.CESS," & vbCrLf & "    FreightCharges," & vbCrLf & "    OtherCharges," & vbCrLf & "    Total," & vbCrLf & "    RoundOff," & vbCrLf & "    GrandTotal," & vbCrLf & "    TotalPaid," & vbCrLf & "    Balance," & vbCrLf & "    RTRIM(InvoiceInfo_StockInward.Remarks) AS Remarks," & vbCrLf & "    RTRIM(Narration) AS Narration," & vbCrLf & "    RTRIM(Eway) AS Eway," & vbCrLf & "    RTRIM(TillID) AS TillID," & vbCrLf & "    RTRIM(Operator) AS Operator," & vbCrLf & "    RTRIM(BillSundry) AS BillSundry," & vbCrLf & "    RTRIM(OfferAmt) AS OfferAmt," & vbCrLf & "    RTRIM(LoyaAmt) AS LoyaAmt," & vbCrLf & "    RTRIM(BillDiscount) AS BillDiscount," & vbCrLf & "    '' AS City," & vbCrLf & vbCrLf & "    Tender," & vbCrLf & "    Refund," & vbCrLf & "    BillCash," & vbCrLf & "    CouponAmt," & vbCrLf & "    GiftAmt," & vbCrLf & "    '' AS Address," & vbCrLf & vbCrLf & "    SRNumber," & vbCrLf & "    ByReturn," & vbCrLf & "    TotalLoyalityPoints," & vbCrLf & "    LoyalityReedemPoints," & vbCrLf & "    LoyalityReedemAmt," & vbCrLf & vbCrLf & "    RTRIM(j.Barcode) AS Barcode," & vbCrLf & "    RTRIM(j.ProductName) AS ProductName," & vbCrLf & "    j.Qty AS Qty," & vbCrLf & vbCrLf & "    InvoiceInfo_StockInward.from_company_id," & vbCrLf & "    InvoiceInfo_StockInward.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS to_companyName,RTRIM(z.CompanyName) AS from_companyName," & vbCrLf & vbCrLf & "    CASE " & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 1 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS StatusText" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockInward" & vbCrLf & "INNER JOIN InvoiceInfo_Product_StockInward j ON InvoiceInfo_StockInward.inv_ID = j.invoiceID" & vbCrLf & "LEFT JOIN " & vbCrLf & "    Branch_Relation y ON InvoiceInfo_StockInward.from_company_id = y.to_company_id" & vbCrLf & "LEFT JOIN RaintechMaster z on InvoiceInfo_StockInward.from_company_id = z.company_id" & vbCrLf & "where InvoiceInfo_StockInward.to_company_id=@d0 and InvoiceDate between @d1 and @d2 and InvoiceInfo_StockInward.status in ", text, " and InvoiceNo like '", Me.txtTransId.Text, "%' order by InvoiceDate" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text2 As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("to_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim text4 As String = ModCommonClasses.rdr("from_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text2, num, text3, ModCommonClasses.rdr("from_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag3 Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060090EE RID: 37102 RVA: 0x00696CB4 File Offset: 0x00694EB4
		Private Sub txtTransId_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT top 5" & vbCrLf & "    Inv_ID," & vbCrLf & "    RTRIM(InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceDate," & vbCrLf & "    RTRIM(TaxType) AS TaxType," & vbCrLf & vbCrLf & "    '' AS ID," & vbCrLf & "    '' AS CustomerID," & vbCrLf & "    '' AS CustomerName," & vbCrLf & "    '' AS ContactNo," & vbCrLf & "    '' AS State," & vbCrLf & "    '' AS GSTIN," & vbCrLf & vbCrLf & "    '' as SM_ID," & vbCrLf & "    InvoiceInfo_StockInward.SalesmanID," & vbCrLf & "    '' AS SalesmanName," & vbCrLf & vbCrLf & "    SubTotal," & vbCrLf & "    InvoiceInfo_StockInward.CGST," & vbCrLf & "    InvoiceInfo_StockInward.SGST," & vbCrLf & "    InvoiceInfo_StockInward.IGST," & vbCrLf & "    InvoiceInfo_StockInward.CESS," & vbCrLf & "    FreightCharges," & vbCrLf & "    OtherCharges," & vbCrLf & "    Total," & vbCrLf & "    RoundOff," & vbCrLf & "    GrandTotal," & vbCrLf & "    TotalPaid," & vbCrLf & "    Balance," & vbCrLf & "    RTRIM(InvoiceInfo_StockInward.Remarks) AS Remarks," & vbCrLf & "    RTRIM(Narration) AS Narration," & vbCrLf & "    RTRIM(Eway) AS Eway," & vbCrLf & "    RTRIM(TillID) AS TillID," & vbCrLf & "    RTRIM(Operator) AS Operator," & vbCrLf & "    RTRIM(BillSundry) AS BillSundry," & vbCrLf & "    RTRIM(OfferAmt) AS OfferAmt," & vbCrLf & "    RTRIM(LoyaAmt) AS LoyaAmt," & vbCrLf & "    RTRIM(BillDiscount) AS BillDiscount," & vbCrLf & "    '' AS City," & vbCrLf & vbCrLf & "    Tender," & vbCrLf & "    Refund," & vbCrLf & "    BillCash," & vbCrLf & "    CouponAmt," & vbCrLf & "    GiftAmt," & vbCrLf & "    '' AS Address," & vbCrLf & vbCrLf & "    SRNumber," & vbCrLf & "    ByReturn," & vbCrLf & "    TotalLoyalityPoints," & vbCrLf & "    LoyalityReedemPoints," & vbCrLf & "    LoyalityReedemAmt," & vbCrLf & vbCrLf & "    RTRIM(j.Barcode) AS Barcode," & vbCrLf & "    RTRIM(j.ProductName) AS ProductName," & vbCrLf & "    j.Qty AS Qty," & vbCrLf & vbCrLf & "    InvoiceInfo_StockInward.from_company_id," & vbCrLf & "    InvoiceInfo_StockInward.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS to_companyName,RTRIM(z.CompanyName) AS from_companyName," & vbCrLf & vbCrLf & "    CASE " & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 1 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS StatusText" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockInward" & vbCrLf & "INNER JOIN InvoiceInfo_Product_StockInward j ON InvoiceInfo_StockInward.inv_ID = j.invoiceID" & vbCrLf & "LEFT JOIN " & vbCrLf & "    Branch_Relation y ON InvoiceInfo_StockInward.from_company_id = y.to_company_id" & vbCrLf & "LEFT JOIN RaintechMaster z on InvoiceInfo_StockInward.from_company_id = z.company_id" & vbCrLf & "where InvoiceInfo_StockInward.to_company_id=@d0 and InvoiceNo like '" + Me.txtTransId.Text + "%' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text2 As String = ModCommonClasses.rdr("to_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("from_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text, num, text2, ModCommonClasses.rdr("from_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060090EF RID: 37103 RVA: 0x00697270 File Offset: 0x00695470
		Private Sub cboxStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cboxStatus.Text, "Pending", False) = 0
				Dim num As Integer
				If flag Then
					num = 0
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cboxStatus.Text, "Inward Done", False) = 0
					If flag2 Then
						num = 1
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT top 5" & vbCrLf & "    Inv_ID," & vbCrLf & "    RTRIM(InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceDate," & vbCrLf & "    RTRIM(TaxType) AS TaxType," & vbCrLf & vbCrLf & "    '' AS ID," & vbCrLf & "    '' AS CustomerID," & vbCrLf & "    '' AS CustomerName," & vbCrLf & "    '' AS ContactNo," & vbCrLf & "    '' AS State," & vbCrLf & "    '' AS GSTIN," & vbCrLf & vbCrLf & "    '' as SM_ID," & vbCrLf & "    InvoiceInfo_StockInward.SalesmanID," & vbCrLf & "    '' AS SalesmanName," & vbCrLf & vbCrLf & "    SubTotal," & vbCrLf & "    InvoiceInfo_StockInward.CGST," & vbCrLf & "    InvoiceInfo_StockInward.SGST," & vbCrLf & "    InvoiceInfo_StockInward.IGST," & vbCrLf & "    InvoiceInfo_StockInward.CESS," & vbCrLf & "    FreightCharges," & vbCrLf & "    OtherCharges," & vbCrLf & "    Total," & vbCrLf & "    RoundOff," & vbCrLf & "    GrandTotal," & vbCrLf & "    TotalPaid," & vbCrLf & "    Balance," & vbCrLf & "    RTRIM(InvoiceInfo_StockInward.Remarks) AS Remarks," & vbCrLf & "    RTRIM(Narration) AS Narration," & vbCrLf & "    RTRIM(Eway) AS Eway," & vbCrLf & "    RTRIM(TillID) AS TillID," & vbCrLf & "    RTRIM(Operator) AS Operator," & vbCrLf & "    RTRIM(BillSundry) AS BillSundry," & vbCrLf & "    RTRIM(OfferAmt) AS OfferAmt," & vbCrLf & "    RTRIM(LoyaAmt) AS LoyaAmt," & vbCrLf & "    RTRIM(BillDiscount) AS BillDiscount," & vbCrLf & "    '' AS City," & vbCrLf & vbCrLf & "    Tender," & vbCrLf & "    Refund," & vbCrLf & "    BillCash," & vbCrLf & "    CouponAmt," & vbCrLf & "    GiftAmt," & vbCrLf & "    '' AS Address," & vbCrLf & vbCrLf & "    SRNumber," & vbCrLf & "    ByReturn," & vbCrLf & "    TotalLoyalityPoints," & vbCrLf & "    LoyalityReedemPoints," & vbCrLf & "    LoyalityReedemAmt," & vbCrLf & vbCrLf & "    RTRIM(j.Barcode) AS Barcode," & vbCrLf & "    RTRIM(j.ProductName) AS ProductName," & vbCrLf & "    j.Qty AS Qty," & vbCrLf & vbCrLf & "    InvoiceInfo_StockInward.from_company_id," & vbCrLf & "    InvoiceInfo_StockInward.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS to_companyName,RTRIM(z.CompanyName) AS from_companyName," & vbCrLf & vbCrLf & "    CASE " & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN InvoiceInfo_StockInward.status = 1 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS StatusText" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockInward" & vbCrLf & "INNER JOIN InvoiceInfo_Product_StockInward j ON InvoiceInfo_StockInward.inv_ID = j.invoiceID" & vbCrLf & "LEFT JOIN " & vbCrLf & "    Branch_Relation y ON InvoiceInfo_StockInward.from_company_id = y.to_company_id" & vbCrLf & "LEFT JOIN RaintechMaster z on InvoiceInfo_StockInward.from_company_id = z.company_id" & vbCrLf & "where InvoiceInfo_StockInward.to_company_id=@d0 and InvoiceInfo_StockInward.status=@d1 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.Int).Value = num
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text2 As String = ModCommonClasses.rdr("to_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("from_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim num2 As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text, num2, text2, ModCommonClasses.rdr("from_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num3 As Integer = Me.dgw.Rows.Count - 1
					Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag3 Then
						Me.dgw.Rows(num3).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num3).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060090F0 RID: 37104 RVA: 0x00697880 File Offset: 0x00695A80
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from InvoiceInfo_StockInward where to_company_id=@d0 and InvoiceDate >=@d1 and InvoiceDate < @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.VarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("select CONVERT(char(11), x.InvoiceDate, 103) as ProductCode, x.InvoiceNo as Barcode, y.ProductID, y.ProductName, y.Qty, x.from_company_id as Column1, x.Status," & vbCrLf & "    CASE " & vbCrLf & "        WHEN x.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN x.status = 1 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS Column2" & vbCrLf & "from InvoiceInfo_StockInward x" & vbCrLf & "inner join InvoiceInfo_Product_StockInward y on x.Inv_ID = y.InvoiceID" & vbCrLf & "where x.to_company_id=@d0 and x.InvoiceDate >=@d1 and x.InvoiceDate < @d2", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.VarChar).Value = Me.lblFrom_Company_id.Text
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockMovementReport.xml")
					Dim rptStockInward As rptStockInward = New rptStockInward()
					rptStockInward.SetDataSource(ModCommonClasses.ds)
					rptStockInward.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptStockInward.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockInward
					MyProject.Forms.frmReport.ShowDialog()
					rptStockInward.Close()
					rptStockInward.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
