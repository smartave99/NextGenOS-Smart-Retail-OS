Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Namespace BillPoint
	' Token: 0x02000604 RID: 1540
	<DesignerGenerated()>
	Public Partial Class frmTokenOut
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012C9D RID: 76957 RVA: 0x0008067E File Offset: 0x0007E87E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTokenOut_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007491 RID: 29841
		' (get) Token: 0x06012CA0 RID: 76960 RVA: 0x0008069E File Offset: 0x0007E89E
		' (set) Token: 0x06012CA1 RID: 76961 RVA: 0x000806A8 File Offset: 0x0007E8A8
		Friend Overridable Property Label21 As Label

		' Token: 0x17007492 RID: 29842
		' (get) Token: 0x06012CA2 RID: 76962 RVA: 0x000806B1 File Offset: 0x0007E8B1
		' (set) Token: 0x06012CA3 RID: 76963 RVA: 0x000806BB File Offset: 0x0007E8BB
		Friend Overridable Property Label1 As Label

		' Token: 0x17007493 RID: 29843
		' (get) Token: 0x06012CA4 RID: 76964 RVA: 0x000806C4 File Offset: 0x0007E8C4
		' (set) Token: 0x06012CA5 RID: 76965 RVA: 0x000806CE File Offset: 0x0007E8CE
		Friend Overridable Property cmbBranchTo As ComboBox

		' Token: 0x17007494 RID: 29844
		' (get) Token: 0x06012CA6 RID: 76966 RVA: 0x000806D7 File Offset: 0x0007E8D7
		' (set) Token: 0x06012CA7 RID: 76967 RVA: 0x000806E1 File Offset: 0x0007E8E1
		Friend Overridable Property Label2 As Label

		' Token: 0x17007495 RID: 29845
		' (get) Token: 0x06012CA8 RID: 76968 RVA: 0x000806EA File Offset: 0x0007E8EA
		' (set) Token: 0x06012CA9 RID: 76969 RVA: 0x00AC7894 File Offset: 0x00AC5A94
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

		' Token: 0x17007496 RID: 29846
		' (get) Token: 0x06012CAA RID: 76970 RVA: 0x000806F4 File Offset: 0x0007E8F4
		' (set) Token: 0x06012CAB RID: 76971 RVA: 0x000806FE File Offset: 0x0007E8FE
		Friend Overridable Property listView1 As ListView

		' Token: 0x17007497 RID: 29847
		' (get) Token: 0x06012CAC RID: 76972 RVA: 0x00080707 File Offset: 0x0007E907
		' (set) Token: 0x06012CAD RID: 76973 RVA: 0x00080711 File Offset: 0x0007E911
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17007498 RID: 29848
		' (get) Token: 0x06012CAE RID: 76974 RVA: 0x0008071A File Offset: 0x0007E91A
		' (set) Token: 0x06012CAF RID: 76975 RVA: 0x00080724 File Offset: 0x0007E924
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17007499 RID: 29849
		' (get) Token: 0x06012CB0 RID: 76976 RVA: 0x0008072D File Offset: 0x0007E92D
		' (set) Token: 0x06012CB1 RID: 76977 RVA: 0x00080737 File Offset: 0x0007E937
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x1700749A RID: 29850
		' (get) Token: 0x06012CB2 RID: 76978 RVA: 0x00080740 File Offset: 0x0007E940
		' (set) Token: 0x06012CB3 RID: 76979 RVA: 0x0008074A File Offset: 0x0007E94A
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x1700749B RID: 29851
		' (get) Token: 0x06012CB4 RID: 76980 RVA: 0x00080753 File Offset: 0x0007E953
		' (set) Token: 0x06012CB5 RID: 76981 RVA: 0x0008075D File Offset: 0x0007E95D
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x1700749C RID: 29852
		' (get) Token: 0x06012CB6 RID: 76982 RVA: 0x00080766 File Offset: 0x0007E966
		' (set) Token: 0x06012CB7 RID: 76983 RVA: 0x00080770 File Offset: 0x0007E970
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x1700749D RID: 29853
		' (get) Token: 0x06012CB8 RID: 76984 RVA: 0x00080779 File Offset: 0x0007E979
		' (set) Token: 0x06012CB9 RID: 76985 RVA: 0x00080783 File Offset: 0x0007E983
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x1700749E RID: 29854
		' (get) Token: 0x06012CBA RID: 76986 RVA: 0x0008078C File Offset: 0x0007E98C
		' (set) Token: 0x06012CBB RID: 76987 RVA: 0x00080796 File Offset: 0x0007E996
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x1700749F RID: 29855
		' (get) Token: 0x06012CBC RID: 76988 RVA: 0x0008079F File Offset: 0x0007E99F
		' (set) Token: 0x06012CBD RID: 76989 RVA: 0x000807A9 File Offset: 0x0007E9A9
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x170074A0 RID: 29856
		' (get) Token: 0x06012CBE RID: 76990 RVA: 0x000807B2 File Offset: 0x0007E9B2
		' (set) Token: 0x06012CBF RID: 76991 RVA: 0x000807BC File Offset: 0x0007E9BC
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170074A1 RID: 29857
		' (get) Token: 0x06012CC0 RID: 76992 RVA: 0x000807C5 File Offset: 0x0007E9C5
		' (set) Token: 0x06012CC1 RID: 76993 RVA: 0x000807CF File Offset: 0x0007E9CF
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x170074A2 RID: 29858
		' (get) Token: 0x06012CC2 RID: 76994 RVA: 0x000807D8 File Offset: 0x0007E9D8
		' (set) Token: 0x06012CC3 RID: 76995 RVA: 0x000807E2 File Offset: 0x0007E9E2
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x170074A3 RID: 29859
		' (get) Token: 0x06012CC4 RID: 76996 RVA: 0x000807EB File Offset: 0x0007E9EB
		' (set) Token: 0x06012CC5 RID: 76997 RVA: 0x000807F5 File Offset: 0x0007E9F5
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x170074A4 RID: 29860
		' (get) Token: 0x06012CC6 RID: 76998 RVA: 0x000807FE File Offset: 0x0007E9FE
		' (set) Token: 0x06012CC7 RID: 76999 RVA: 0x00080808 File Offset: 0x0007EA08
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x170074A5 RID: 29861
		' (get) Token: 0x06012CC8 RID: 77000 RVA: 0x00080811 File Offset: 0x0007EA11
		' (set) Token: 0x06012CC9 RID: 77001 RVA: 0x0008081B File Offset: 0x0007EA1B
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x170074A6 RID: 29862
		' (get) Token: 0x06012CCA RID: 77002 RVA: 0x00080824 File Offset: 0x0007EA24
		' (set) Token: 0x06012CCB RID: 77003 RVA: 0x0008082E File Offset: 0x0007EA2E
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x170074A7 RID: 29863
		' (get) Token: 0x06012CCC RID: 77004 RVA: 0x00080837 File Offset: 0x0007EA37
		' (set) Token: 0x06012CCD RID: 77005 RVA: 0x00080841 File Offset: 0x0007EA41
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x170074A8 RID: 29864
		' (get) Token: 0x06012CCE RID: 77006 RVA: 0x0008084A File Offset: 0x0007EA4A
		' (set) Token: 0x06012CCF RID: 77007 RVA: 0x00080854 File Offset: 0x0007EA54
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x170074A9 RID: 29865
		' (get) Token: 0x06012CD0 RID: 77008 RVA: 0x0008085D File Offset: 0x0007EA5D
		' (set) Token: 0x06012CD1 RID: 77009 RVA: 0x00080867 File Offset: 0x0007EA67
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x170074AA RID: 29866
		' (get) Token: 0x06012CD2 RID: 77010 RVA: 0x00080870 File Offset: 0x0007EA70
		' (set) Token: 0x06012CD3 RID: 77011 RVA: 0x0008087A File Offset: 0x0007EA7A
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x170074AB RID: 29867
		' (get) Token: 0x06012CD4 RID: 77012 RVA: 0x00080883 File Offset: 0x0007EA83
		' (set) Token: 0x06012CD5 RID: 77013 RVA: 0x0008088D File Offset: 0x0007EA8D
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x170074AC RID: 29868
		' (get) Token: 0x06012CD6 RID: 77014 RVA: 0x00080896 File Offset: 0x0007EA96
		' (set) Token: 0x06012CD7 RID: 77015 RVA: 0x000808A0 File Offset: 0x0007EAA0
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x170074AD RID: 29869
		' (get) Token: 0x06012CD8 RID: 77016 RVA: 0x000808A9 File Offset: 0x0007EAA9
		' (set) Token: 0x06012CD9 RID: 77017 RVA: 0x000808B3 File Offset: 0x0007EAB3
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x170074AE RID: 29870
		' (get) Token: 0x06012CDA RID: 77018 RVA: 0x000808BC File Offset: 0x0007EABC
		' (set) Token: 0x06012CDB RID: 77019 RVA: 0x000808C6 File Offset: 0x0007EAC6
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x170074AF RID: 29871
		' (get) Token: 0x06012CDC RID: 77020 RVA: 0x000808CF File Offset: 0x0007EACF
		' (set) Token: 0x06012CDD RID: 77021 RVA: 0x000808D9 File Offset: 0x0007EAD9
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x170074B0 RID: 29872
		' (get) Token: 0x06012CDE RID: 77022 RVA: 0x000808E2 File Offset: 0x0007EAE2
		' (set) Token: 0x06012CDF RID: 77023 RVA: 0x000808EC File Offset: 0x0007EAEC
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x170074B1 RID: 29873
		' (get) Token: 0x06012CE0 RID: 77024 RVA: 0x000808F5 File Offset: 0x0007EAF5
		' (set) Token: 0x06012CE1 RID: 77025 RVA: 0x000808FF File Offset: 0x0007EAFF
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x170074B2 RID: 29874
		' (get) Token: 0x06012CE2 RID: 77026 RVA: 0x00080908 File Offset: 0x0007EB08
		' (set) Token: 0x06012CE3 RID: 77027 RVA: 0x00080912 File Offset: 0x0007EB12
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x170074B3 RID: 29875
		' (get) Token: 0x06012CE4 RID: 77028 RVA: 0x0008091B File Offset: 0x0007EB1B
		' (set) Token: 0x06012CE5 RID: 77029 RVA: 0x00080925 File Offset: 0x0007EB25
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x170074B4 RID: 29876
		' (get) Token: 0x06012CE6 RID: 77030 RVA: 0x0008092E File Offset: 0x0007EB2E
		' (set) Token: 0x06012CE7 RID: 77031 RVA: 0x00080938 File Offset: 0x0007EB38
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x170074B5 RID: 29877
		' (get) Token: 0x06012CE8 RID: 77032 RVA: 0x00080941 File Offset: 0x0007EB41
		' (set) Token: 0x06012CE9 RID: 77033 RVA: 0x0008094B File Offset: 0x0007EB4B
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x170074B6 RID: 29878
		' (get) Token: 0x06012CEA RID: 77034 RVA: 0x00080954 File Offset: 0x0007EB54
		' (set) Token: 0x06012CEB RID: 77035 RVA: 0x0008095E File Offset: 0x0007EB5E
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x170074B7 RID: 29879
		' (get) Token: 0x06012CEC RID: 77036 RVA: 0x00080967 File Offset: 0x0007EB67
		' (set) Token: 0x06012CED RID: 77037 RVA: 0x00080971 File Offset: 0x0007EB71
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x170074B8 RID: 29880
		' (get) Token: 0x06012CEE RID: 77038 RVA: 0x0008097A File Offset: 0x0007EB7A
		' (set) Token: 0x06012CEF RID: 77039 RVA: 0x00080984 File Offset: 0x0007EB84
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x170074B9 RID: 29881
		' (get) Token: 0x06012CF0 RID: 77040 RVA: 0x0008098D File Offset: 0x0007EB8D
		' (set) Token: 0x06012CF1 RID: 77041 RVA: 0x00080997 File Offset: 0x0007EB97
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x170074BA RID: 29882
		' (get) Token: 0x06012CF2 RID: 77042 RVA: 0x000809A0 File Offset: 0x0007EBA0
		' (set) Token: 0x06012CF3 RID: 77043 RVA: 0x000809AA File Offset: 0x0007EBAA
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x170074BB RID: 29883
		' (get) Token: 0x06012CF4 RID: 77044 RVA: 0x000809B3 File Offset: 0x0007EBB3
		' (set) Token: 0x06012CF5 RID: 77045 RVA: 0x000809BD File Offset: 0x0007EBBD
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x170074BC RID: 29884
		' (get) Token: 0x06012CF6 RID: 77046 RVA: 0x000809C6 File Offset: 0x0007EBC6
		' (set) Token: 0x06012CF7 RID: 77047 RVA: 0x000809D0 File Offset: 0x0007EBD0
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x170074BD RID: 29885
		' (get) Token: 0x06012CF8 RID: 77048 RVA: 0x000809D9 File Offset: 0x0007EBD9
		' (set) Token: 0x06012CF9 RID: 77049 RVA: 0x000809E3 File Offset: 0x0007EBE3
		Friend Overridable Property Label3 As Label

		' Token: 0x170074BE RID: 29886
		' (get) Token: 0x06012CFA RID: 77050 RVA: 0x000809EC File Offset: 0x0007EBEC
		' (set) Token: 0x06012CFB RID: 77051 RVA: 0x000809F6 File Offset: 0x0007EBF6
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170074BF RID: 29887
		' (get) Token: 0x06012CFC RID: 77052 RVA: 0x000809FF File Offset: 0x0007EBFF
		' (set) Token: 0x06012CFD RID: 77053 RVA: 0x00080A09 File Offset: 0x0007EC09
		Friend Overridable Property Label4 As Label

		' Token: 0x170074C0 RID: 29888
		' (get) Token: 0x06012CFE RID: 77054 RVA: 0x00080A12 File Offset: 0x0007EC12
		' (set) Token: 0x06012CFF RID: 77055 RVA: 0x00080A1C File Offset: 0x0007EC1C
		Friend Overridable Property txtRemark As TextBox

		' Token: 0x170074C1 RID: 29889
		' (get) Token: 0x06012D00 RID: 77056 RVA: 0x00080A25 File Offset: 0x0007EC25
		' (set) Token: 0x06012D01 RID: 77057 RVA: 0x00AC78D8 File Offset: 0x00AC5AD8
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

		' Token: 0x170074C2 RID: 29890
		' (get) Token: 0x06012D02 RID: 77058 RVA: 0x00080A2F File Offset: 0x0007EC2F
		' (set) Token: 0x06012D03 RID: 77059 RVA: 0x00AC791C File Offset: 0x00AC5B1C
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

		' Token: 0x170074C3 RID: 29891
		' (get) Token: 0x06012D04 RID: 77060 RVA: 0x00080A39 File Offset: 0x0007EC39
		' (set) Token: 0x06012D05 RID: 77061 RVA: 0x00080A43 File Offset: 0x0007EC43
		Friend Overridable Property ColumnHeader76 As ColumnHeader

		' Token: 0x170074C4 RID: 29892
		' (get) Token: 0x06012D06 RID: 77062 RVA: 0x00080A4C File Offset: 0x0007EC4C
		' (set) Token: 0x06012D07 RID: 77063 RVA: 0x00AC7960 File Offset: 0x00AC5B60
		Private _ListView2 As ListView
		Friend Overridable Property ListView2 As ListView
			<CompilerGenerated()>
			Get
				Return Me._ListView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.ListView2_MouseClick
				Dim columnClickEventHandler As ColumnClickEventHandler = AddressOf Me.ListView2_ColumnClick
				Dim listView As ListView = Me._ListView2
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseClick, mouseEventHandler
					RemoveHandler listView.ColumnClick, columnClickEventHandler
				End If
				Me._ListView2 = value
				listView = Me._ListView2
				If listView IsNot Nothing Then
					AddHandler listView.MouseClick, mouseEventHandler
					AddHandler listView.ColumnClick, columnClickEventHandler
				End If
			End Set
		End Property

		' Token: 0x170074C5 RID: 29893
		' (get) Token: 0x06012D08 RID: 77064 RVA: 0x00080A56 File Offset: 0x0007EC56
		' (set) Token: 0x06012D09 RID: 77065 RVA: 0x00080A60 File Offset: 0x0007EC60
		Friend Overridable Property ColumnHeader39 As ColumnHeader

		' Token: 0x170074C6 RID: 29894
		' (get) Token: 0x06012D0A RID: 77066 RVA: 0x00080A69 File Offset: 0x0007EC69
		' (set) Token: 0x06012D0B RID: 77067 RVA: 0x00080A73 File Offset: 0x0007EC73
		Friend Overridable Property txtDB As TextBox

		' Token: 0x170074C7 RID: 29895
		' (get) Token: 0x06012D0C RID: 77068 RVA: 0x00080A7C File Offset: 0x0007EC7C
		' (set) Token: 0x06012D0D RID: 77069 RVA: 0x00080A86 File Offset: 0x0007EC86
		Friend Overridable Property txtBranchCode As TextBox

		' Token: 0x170074C8 RID: 29896
		' (get) Token: 0x06012D0E RID: 77070 RVA: 0x00080A8F File Offset: 0x0007EC8F
		' (set) Token: 0x06012D0F RID: 77071 RVA: 0x00080A99 File Offset: 0x0007EC99
		Friend Overridable Property cmbBranchFrom As ComboBox

		' Token: 0x170074C9 RID: 29897
		' (get) Token: 0x06012D10 RID: 77072 RVA: 0x00080AA2 File Offset: 0x0007ECA2
		' (set) Token: 0x06012D11 RID: 77073 RVA: 0x00080AAC File Offset: 0x0007ECAC
		Friend Overridable Property cmbBranchAdmin As ComboBox

		' Token: 0x170074CA RID: 29898
		' (get) Token: 0x06012D12 RID: 77074 RVA: 0x00080AB5 File Offset: 0x0007ECB5
		' (set) Token: 0x06012D13 RID: 77075 RVA: 0x00080ABF File Offset: 0x0007ECBF
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x170074CB RID: 29899
		' (get) Token: 0x06012D14 RID: 77076 RVA: 0x00080AC8 File Offset: 0x0007ECC8
		' (set) Token: 0x06012D15 RID: 77077 RVA: 0x00080AD2 File Offset: 0x0007ECD2
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x170074CC RID: 29900
		' (get) Token: 0x06012D16 RID: 77078 RVA: 0x00080ADB File Offset: 0x0007ECDB
		' (set) Token: 0x06012D17 RID: 77079 RVA: 0x00AC79C0 File Offset: 0x00AC5BC0
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

		' Token: 0x06012D18 RID: 77080 RVA: 0x00AC7A04 File Offset: 0x00AC5C04
		Private Sub frmTokenOut_Load(sender As Object, e As EventArgs)
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.txtBranchCode.Text = ModFunc.MD5Encrypt(Me.txtDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.SearchInBranch()
				Me.listView1.Items.Clear()
				Me.ListView2.Items.Clear()
				Me.TextBox1.Text = ""
			Catch ex As Exception
			End Try
			Me.Convert_Language()
		End Sub

		' Token: 0x06012D19 RID: 77081 RVA: 0x00AC7B0C File Offset: 0x00AC5D0C
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

		' Token: 0x06012D1A RID: 77082 RVA: 0x00AC7C84 File Offset: 0x00AC5E84
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

		' Token: 0x06012D1B RID: 77083 RVA: 0x00AC7D40 File Offset: 0x00AC5F40
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

		' Token: 0x06012D1C RID: 77084 RVA: 0x000B726C File Offset: 0x000B546C
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

		' Token: 0x06012D1D RID: 77085 RVA: 0x000B72F4 File Offset: 0x000B54F4
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

		' Token: 0x06012D1E RID: 77086 RVA: 0x00AC7DEC File Offset: 0x00AC5FEC
		Private Sub SearchInBranch()
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = "SELECT admincode, branchname FROM branch WHERE branchcode like N'" + Me.txtBranchCode.Text + "%'"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.cmbBranchFrom.Items.Clear()
							Me.cmbBranchAdmin.Items.Clear()
							While mySqlDataReader.Read()
								Me.cmbBranchFrom.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(1)))
								Me.cmbBranchAdmin.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(0)))
								Me.cmbBranchFrom.SelectedIndex = 0
								Me.cmbBranchAdmin.SelectedIndex = 0
							End While
						End Using
					End Using
				End Using
				Me.SearchInBranchTo()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012D1F RID: 77087 RVA: 0x00AC7F88 File Offset: 0x00AC6188
		Private Sub SearchInBranchTo()
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = String.Concat(New String() { "SELECT branchname FROM branch WHERE admincode='", Me.cmbBranchAdmin.Text, "' AND branchname <> '", Me.cmbBranchFrom.Text, "'" })
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.cmbBranchTo.Items.Clear()
							While mySqlDataReader.Read()
								Me.cmbBranchTo.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(0)))
							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012D20 RID: 77088 RVA: 0x00AC80C8 File Offset: 0x00AC62C8
		Private Sub GetPending()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TocknNo, COUNT(*) as ProductCount FROM P_Transfer WHERE TocknNo like N'" + Me.TextBox1.Text + "%' and PStatus = 'P' GROUP BY TocknNo", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView2.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					Me.ListView2.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012D21 RID: 77089 RVA: 0x00080AE5 File Offset: 0x0007ECE5
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.GetPending()
		End Sub

		' Token: 0x06012D22 RID: 77090 RVA: 0x00AC81F0 File Offset: 0x00AC63F0
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.GetPending()
			End If
		End Sub

		' Token: 0x06012D23 RID: 77091 RVA: 0x00AC8218 File Offset: 0x00AC6418
		Private Sub GetPendingShow()
			Try
				Dim num As Integer = Me.ListView2.Items.IndexOf(Me.ListView2.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.ListView2.Items(num)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,QrBarcode FROM P_Transfer WHERE TocknNo like N'" + listViewItem.Text + "%' and PStatus = 'P'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem2 As ListViewItem = New ListViewItem()
					listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					Me.listView1.Items.Add(listViewItem2)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012D24 RID: 77092 RVA: 0x00AC8804 File Offset: 0x00AC6A04
		Private Sub ListView2_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim num As Integer = Me.ListView2.Items.IndexOf(Me.ListView2.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.ListView2.Items(num)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,QrBarcode,T_Qty,TocknNo,Category,SubCategoryName FROM P_Transfer WHERE TocknNo like N'" + listViewItem.Text + "%' and PStatus = 'P'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem2 As ListViewItem = New ListViewItem()
					listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(25).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(26).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(27).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(28).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(29).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(30).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(31).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(32).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(33).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(34).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(35).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(36).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(37).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(38).ToString().Trim())
					listViewItem2.SubItems.Add(ModCommonClasses.rdr(39).ToString().Trim())
					Me.listView1.Items.Add(listViewItem2)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012D25 RID: 77093 RVA: 0x00AC8E78 File Offset: 0x00AC7078
		Private Sub ListView2_ColumnClick(sender As Object, e As ColumnClickEventArgs)
		End Sub

		' Token: 0x06012D26 RID: 77094 RVA: 0x00AC8E88 File Offset: 0x00AC7088
		Private Sub btnDToken_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbBranchFrom.Text)) = 0
				If flag Then
					MessageBox.Show("Please Select Branch Name From", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbBranchFrom.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbBranchTo.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please Select Branch Name To", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbBranchTo.Focus()
					Else
						Dim flag3 As Boolean = Me.listView1.Items.Count > 0
						If flag3 Then
							Try
								For Each obj As Object In Me.listView1.Items
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Dim mySqlConnection As MySqlConnection = New MySqlConnection(ModCS.ReadCS1())
									Try
										mySqlConnection.Open()
										Dim text As String = "insert into P_Transfer(PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint," & vbCrLf & "                                            Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown," & vbCrLf & "                                            Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour," & vbCrLf & "                                            Size,IMEI1,IMEI2,Status,T_Qty,TocknNo,PStatus,PAdmin,PBranchFrom,PBranchTo,Remarks,PostDate,branchcode,Category,SubCategoryName) " & vbCrLf & "                                            VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10," & vbCrLf & "                                                    @d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20," & vbCrLf & "                                                    @d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30," & vbCrLf & "                                                    @d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39,@d40,@d41,@d42,@d43,@d44,@d45)"
										Dim mySqlCommand As MySqlCommand = New MySqlCommand(text, mySqlConnection)
										Dim text2 As String = listViewItem.SubItems(2).Text
										Dim text3 As String = listViewItem.SubItems(37).Text
										mySqlCommand.Parameters.AddWithValue("@d0", listViewItem.SubItems(0).Text)
										mySqlCommand.Parameters.AddWithValue("@d1", listViewItem.SubItems(1).Text)
										mySqlCommand.Parameters.AddWithValue("@d2", listViewItem.SubItems(2).Text)
										mySqlCommand.Parameters.AddWithValue("@d3", listViewItem.SubItems(3).Text)
										mySqlCommand.Parameters.AddWithValue("@d4", listViewItem.SubItems(4).Text)
										mySqlCommand.Parameters.AddWithValue("@d5", listViewItem.SubItems(5).Text)
										mySqlCommand.Parameters.AddWithValue("@d6", listViewItem.SubItems(6).Text)
										mySqlCommand.Parameters.AddWithValue("@d7", listViewItem.SubItems(7).Text)
										mySqlCommand.Parameters.AddWithValue("@d8", listViewItem.SubItems(8).Text)
										mySqlCommand.Parameters.AddWithValue("@d9", listViewItem.SubItems(9).Text)
										mySqlCommand.Parameters.AddWithValue("@d10", listViewItem.SubItems(10).Text)
										mySqlCommand.Parameters.AddWithValue("@d11", listViewItem.SubItems(11).Text)
										mySqlCommand.Parameters.AddWithValue("@d12", listViewItem.SubItems(12).Text)
										mySqlCommand.Parameters.AddWithValue("@d13", listViewItem.SubItems(13).Text)
										mySqlCommand.Parameters.AddWithValue("@d14", listViewItem.SubItems(14).Text)
										mySqlCommand.Parameters.AddWithValue("@d15", listViewItem.SubItems(15).Text)
										mySqlCommand.Parameters.AddWithValue("@d16", listViewItem.SubItems(16).Text)
										mySqlCommand.Parameters.AddWithValue("@d17", listViewItem.SubItems(17).Text)
										mySqlCommand.Parameters.AddWithValue("@d18", listViewItem.SubItems(18).Text)
										mySqlCommand.Parameters.AddWithValue("@d19", listViewItem.SubItems(19).Text)
										mySqlCommand.Parameters.AddWithValue("@d20", listViewItem.SubItems(20).Text)
										mySqlCommand.Parameters.AddWithValue("@d21", listViewItem.SubItems(21).Text)
										mySqlCommand.Parameters.AddWithValue("@d22", listViewItem.SubItems(22).Text)
										mySqlCommand.Parameters.AddWithValue("@d23", listViewItem.SubItems(23).Text)
										mySqlCommand.Parameters.AddWithValue("@d24", listViewItem.SubItems(24).Text)
										mySqlCommand.Parameters.AddWithValue("@d25", listViewItem.SubItems(25).Text)
										mySqlCommand.Parameters.AddWithValue("@d26", listViewItem.SubItems(26).Text)
										mySqlCommand.Parameters.AddWithValue("@d27", listViewItem.SubItems(27).Text)
										mySqlCommand.Parameters.AddWithValue("@d28", listViewItem.SubItems(28).Text)
										mySqlCommand.Parameters.AddWithValue("@d29", listViewItem.SubItems(29).Text)
										mySqlCommand.Parameters.AddWithValue("@d30", listViewItem.SubItems(30).Text)
										mySqlCommand.Parameters.AddWithValue("@d31", listViewItem.SubItems(31).Text)
										mySqlCommand.Parameters.AddWithValue("@d32", listViewItem.SubItems(32).Text)
										mySqlCommand.Parameters.AddWithValue("@d33", listViewItem.SubItems(33).Text)
										mySqlCommand.Parameters.AddWithValue("@d34", listViewItem.SubItems(34).Text)
										mySqlCommand.Parameters.AddWithValue("@d35", listViewItem.SubItems(36).Text)
										mySqlCommand.Parameters.AddWithValue("@d36", listViewItem.SubItems(37).Text)
										mySqlCommand.Parameters.AddWithValue("@d37", "o")
										mySqlCommand.Parameters.AddWithValue("@d38", Me.cmbBranchAdmin.Text)
										mySqlCommand.Parameters.AddWithValue("@d39", Me.cmbBranchFrom.Text)
										mySqlCommand.Parameters.AddWithValue("@d40", Me.cmbBranchTo.Text)
										mySqlCommand.Parameters.AddWithValue("@d41", Me.txtRemark.Text)
										mySqlCommand.Parameters.AddWithValue("@d42", DateAndTime.Today)
										mySqlCommand.Parameters.AddWithValue("@d43", Me.txtBranchCode.Text)
										mySqlCommand.Parameters.AddWithValue("@d44", listViewItem.SubItems(38).Text)
										mySqlCommand.Parameters.AddWithValue("@d45", listViewItem.SubItems(39).Text)
										Dim num As Integer = mySqlCommand.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Me.updatetoOffline(text2.ToString(), "o", Me.cmbBranchAdmin.Text, Me.cmbBranchFrom.Text, Me.cmbBranchTo.Text, Me.txtRemark.Text, Me.DateTimePicker1.Text, Me.txtBranchCode.Text, text3.ToString())
									Catch ex As Exception
										Console.WriteLine("MySQL Error: " + ex.Message)
										Console.WriteLine("Stack Trace: " + ex.StackTrace)
									End Try
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							MessageBox.Show("Send Post")
							Me.GetPending()
							Me.listView1.Items.Clear()
						End If
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message)
			End Try
		End Sub

		' Token: 0x06012D27 RID: 77095 RVA: 0x00AC9770 File Offset: 0x00AC7970
		Public Function updatetoOffline(barcode As String, pstatus As String, branchadmin As String, branchfrom As String, branchto As String, remark As String, dt As String, branchcode As String, TocknNo As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "Update p_transfer set PStatus=@d1, PAdmin=@d2, PBranchFrom=@d3,  PBranchTo=@d4, Remarks=@d5 ,PostDate=@d6,branchcode=@d7 where barcode= '", barcode, "' and TocknNo= '", TocknNo, "'" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", pstatus)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", branchadmin)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", branchfrom)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", branchto)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", remark)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dt)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", branchcode)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012D28 RID: 77096 RVA: 0x00080AEF File Offset: 0x0007ECEF
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.FrmStockOutPrint.ShowDialog()
		End Sub
	End Class
End Namespace
