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
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000605 RID: 1541
	<DesignerGenerated()>
	Public Partial Class frmTokenSettlement
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012D29 RID: 77097 RVA: 0x00080B02 File Offset: 0x0007ED02
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTokenSettlement_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170074CD RID: 29901
		' (get) Token: 0x06012D2C RID: 77100 RVA: 0x00080B22 File Offset: 0x0007ED22
		' (set) Token: 0x06012D2D RID: 77101 RVA: 0x00ACB6F8 File Offset: 0x00AC98F8
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

		' Token: 0x170074CE RID: 29902
		' (get) Token: 0x06012D2E RID: 77102 RVA: 0x00080B2C File Offset: 0x0007ED2C
		' (set) Token: 0x06012D2F RID: 77103 RVA: 0x00080B36 File Offset: 0x0007ED36
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x170074CF RID: 29903
		' (get) Token: 0x06012D30 RID: 77104 RVA: 0x00080B3F File Offset: 0x0007ED3F
		' (set) Token: 0x06012D31 RID: 77105 RVA: 0x00080B49 File Offset: 0x0007ED49
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x170074D0 RID: 29904
		' (get) Token: 0x06012D32 RID: 77106 RVA: 0x00080B52 File Offset: 0x0007ED52
		' (set) Token: 0x06012D33 RID: 77107 RVA: 0x00080B5C File Offset: 0x0007ED5C
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x170074D1 RID: 29905
		' (get) Token: 0x06012D34 RID: 77108 RVA: 0x00080B65 File Offset: 0x0007ED65
		' (set) Token: 0x06012D35 RID: 77109 RVA: 0x00080B6F File Offset: 0x0007ED6F
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x170074D2 RID: 29906
		' (get) Token: 0x06012D36 RID: 77110 RVA: 0x00080B78 File Offset: 0x0007ED78
		' (set) Token: 0x06012D37 RID: 77111 RVA: 0x00080B82 File Offset: 0x0007ED82
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x170074D3 RID: 29907
		' (get) Token: 0x06012D38 RID: 77112 RVA: 0x00080B8B File Offset: 0x0007ED8B
		' (set) Token: 0x06012D39 RID: 77113 RVA: 0x00080B95 File Offset: 0x0007ED95
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170074D4 RID: 29908
		' (get) Token: 0x06012D3A RID: 77114 RVA: 0x00080B9E File Offset: 0x0007ED9E
		' (set) Token: 0x06012D3B RID: 77115 RVA: 0x00080BA8 File Offset: 0x0007EDA8
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x170074D5 RID: 29909
		' (get) Token: 0x06012D3C RID: 77116 RVA: 0x00080BB1 File Offset: 0x0007EDB1
		' (set) Token: 0x06012D3D RID: 77117 RVA: 0x00080BBB File Offset: 0x0007EDBB
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170074D6 RID: 29910
		' (get) Token: 0x06012D3E RID: 77118 RVA: 0x00080BC4 File Offset: 0x0007EDC4
		' (set) Token: 0x06012D3F RID: 77119 RVA: 0x00080BCE File Offset: 0x0007EDCE
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x170074D7 RID: 29911
		' (get) Token: 0x06012D40 RID: 77120 RVA: 0x00080BD7 File Offset: 0x0007EDD7
		' (set) Token: 0x06012D41 RID: 77121 RVA: 0x00080BE1 File Offset: 0x0007EDE1
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x170074D8 RID: 29912
		' (get) Token: 0x06012D42 RID: 77122 RVA: 0x00080BEA File Offset: 0x0007EDEA
		' (set) Token: 0x06012D43 RID: 77123 RVA: 0x00080BF4 File Offset: 0x0007EDF4
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x170074D9 RID: 29913
		' (get) Token: 0x06012D44 RID: 77124 RVA: 0x00080BFD File Offset: 0x0007EDFD
		' (set) Token: 0x06012D45 RID: 77125 RVA: 0x00080C07 File Offset: 0x0007EE07
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x170074DA RID: 29914
		' (get) Token: 0x06012D46 RID: 77126 RVA: 0x00080C10 File Offset: 0x0007EE10
		' (set) Token: 0x06012D47 RID: 77127 RVA: 0x00080C1A File Offset: 0x0007EE1A
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x170074DB RID: 29915
		' (get) Token: 0x06012D48 RID: 77128 RVA: 0x00080C23 File Offset: 0x0007EE23
		' (set) Token: 0x06012D49 RID: 77129 RVA: 0x00080C2D File Offset: 0x0007EE2D
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x170074DC RID: 29916
		' (get) Token: 0x06012D4A RID: 77130 RVA: 0x00080C36 File Offset: 0x0007EE36
		' (set) Token: 0x06012D4B RID: 77131 RVA: 0x00080C40 File Offset: 0x0007EE40
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x170074DD RID: 29917
		' (get) Token: 0x06012D4C RID: 77132 RVA: 0x00080C49 File Offset: 0x0007EE49
		' (set) Token: 0x06012D4D RID: 77133 RVA: 0x00080C53 File Offset: 0x0007EE53
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x170074DE RID: 29918
		' (get) Token: 0x06012D4E RID: 77134 RVA: 0x00080C5C File Offset: 0x0007EE5C
		' (set) Token: 0x06012D4F RID: 77135 RVA: 0x00080C66 File Offset: 0x0007EE66
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x170074DF RID: 29919
		' (get) Token: 0x06012D50 RID: 77136 RVA: 0x00080C6F File Offset: 0x0007EE6F
		' (set) Token: 0x06012D51 RID: 77137 RVA: 0x00080C79 File Offset: 0x0007EE79
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x170074E0 RID: 29920
		' (get) Token: 0x06012D52 RID: 77138 RVA: 0x00080C82 File Offset: 0x0007EE82
		' (set) Token: 0x06012D53 RID: 77139 RVA: 0x00080C8C File Offset: 0x0007EE8C
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x170074E1 RID: 29921
		' (get) Token: 0x06012D54 RID: 77140 RVA: 0x00080C95 File Offset: 0x0007EE95
		' (set) Token: 0x06012D55 RID: 77141 RVA: 0x00080C9F File Offset: 0x0007EE9F
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x170074E2 RID: 29922
		' (get) Token: 0x06012D56 RID: 77142 RVA: 0x00080CA8 File Offset: 0x0007EEA8
		' (set) Token: 0x06012D57 RID: 77143 RVA: 0x00080CB2 File Offset: 0x0007EEB2
		Friend Overridable Property Label2 As Label

		' Token: 0x170074E3 RID: 29923
		' (get) Token: 0x06012D58 RID: 77144 RVA: 0x00080CBB File Offset: 0x0007EEBB
		' (set) Token: 0x06012D59 RID: 77145 RVA: 0x00080CC5 File Offset: 0x0007EEC5
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x170074E4 RID: 29924
		' (get) Token: 0x06012D5A RID: 77146 RVA: 0x00080CCE File Offset: 0x0007EECE
		' (set) Token: 0x06012D5B RID: 77147 RVA: 0x00080CD8 File Offset: 0x0007EED8
		Friend Overridable Property cmbBranchTo As ComboBox

		' Token: 0x170074E5 RID: 29925
		' (get) Token: 0x06012D5C RID: 77148 RVA: 0x00080CE1 File Offset: 0x0007EEE1
		' (set) Token: 0x06012D5D RID: 77149 RVA: 0x00080CEB File Offset: 0x0007EEEB
		Friend Overridable Property Label1 As Label

		' Token: 0x170074E6 RID: 29926
		' (get) Token: 0x06012D5E RID: 77150 RVA: 0x00080CF4 File Offset: 0x0007EEF4
		' (set) Token: 0x06012D5F RID: 77151 RVA: 0x00080CFE File Offset: 0x0007EEFE
		Friend Overridable Property Label21 As Label

		' Token: 0x170074E7 RID: 29927
		' (get) Token: 0x06012D60 RID: 77152 RVA: 0x00080D07 File Offset: 0x0007EF07
		' (set) Token: 0x06012D61 RID: 77153 RVA: 0x00080D11 File Offset: 0x0007EF11
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170074E8 RID: 29928
		' (get) Token: 0x06012D62 RID: 77154 RVA: 0x00080D1A File Offset: 0x0007EF1A
		' (set) Token: 0x06012D63 RID: 77155 RVA: 0x00ACB73C File Offset: 0x00AC993C
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

		' Token: 0x170074E9 RID: 29929
		' (get) Token: 0x06012D64 RID: 77156 RVA: 0x00080D24 File Offset: 0x0007EF24
		' (set) Token: 0x06012D65 RID: 77157 RVA: 0x00080D2E File Offset: 0x0007EF2E
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x170074EA RID: 29930
		' (get) Token: 0x06012D66 RID: 77158 RVA: 0x00080D37 File Offset: 0x0007EF37
		' (set) Token: 0x06012D67 RID: 77159 RVA: 0x00080D41 File Offset: 0x0007EF41
		Friend Overridable Property cmbBranchFrom As ComboBox

		' Token: 0x170074EB RID: 29931
		' (get) Token: 0x06012D68 RID: 77160 RVA: 0x00080D4A File Offset: 0x0007EF4A
		' (set) Token: 0x06012D69 RID: 77161 RVA: 0x00080D54 File Offset: 0x0007EF54
		Friend Overridable Property listView1 As ListView

		' Token: 0x170074EC RID: 29932
		' (get) Token: 0x06012D6A RID: 77162 RVA: 0x00080D5D File Offset: 0x0007EF5D
		' (set) Token: 0x06012D6B RID: 77163 RVA: 0x00080D67 File Offset: 0x0007EF67
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x170074ED RID: 29933
		' (get) Token: 0x06012D6C RID: 77164 RVA: 0x00080D70 File Offset: 0x0007EF70
		' (set) Token: 0x06012D6D RID: 77165 RVA: 0x00080D7A File Offset: 0x0007EF7A
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x170074EE RID: 29934
		' (get) Token: 0x06012D6E RID: 77166 RVA: 0x00080D83 File Offset: 0x0007EF83
		' (set) Token: 0x06012D6F RID: 77167 RVA: 0x00080D8D File Offset: 0x0007EF8D
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x170074EF RID: 29935
		' (get) Token: 0x06012D70 RID: 77168 RVA: 0x00080D96 File Offset: 0x0007EF96
		' (set) Token: 0x06012D71 RID: 77169 RVA: 0x00080DA0 File Offset: 0x0007EFA0
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x170074F0 RID: 29936
		' (get) Token: 0x06012D72 RID: 77170 RVA: 0x00080DA9 File Offset: 0x0007EFA9
		' (set) Token: 0x06012D73 RID: 77171 RVA: 0x00080DB3 File Offset: 0x0007EFB3
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x170074F1 RID: 29937
		' (get) Token: 0x06012D74 RID: 77172 RVA: 0x00080DBC File Offset: 0x0007EFBC
		' (set) Token: 0x06012D75 RID: 77173 RVA: 0x00080DC6 File Offset: 0x0007EFC6
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x170074F2 RID: 29938
		' (get) Token: 0x06012D76 RID: 77174 RVA: 0x00080DCF File Offset: 0x0007EFCF
		' (set) Token: 0x06012D77 RID: 77175 RVA: 0x00080DD9 File Offset: 0x0007EFD9
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x170074F3 RID: 29939
		' (get) Token: 0x06012D78 RID: 77176 RVA: 0x00080DE2 File Offset: 0x0007EFE2
		' (set) Token: 0x06012D79 RID: 77177 RVA: 0x00080DEC File Offset: 0x0007EFEC
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x170074F4 RID: 29940
		' (get) Token: 0x06012D7A RID: 77178 RVA: 0x00080DF5 File Offset: 0x0007EFF5
		' (set) Token: 0x06012D7B RID: 77179 RVA: 0x00080DFF File Offset: 0x0007EFFF
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x170074F5 RID: 29941
		' (get) Token: 0x06012D7C RID: 77180 RVA: 0x00080E08 File Offset: 0x0007F008
		' (set) Token: 0x06012D7D RID: 77181 RVA: 0x00080E12 File Offset: 0x0007F012
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x170074F6 RID: 29942
		' (get) Token: 0x06012D7E RID: 77182 RVA: 0x00080E1B File Offset: 0x0007F01B
		' (set) Token: 0x06012D7F RID: 77183 RVA: 0x00080E25 File Offset: 0x0007F025
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x170074F7 RID: 29943
		' (get) Token: 0x06012D80 RID: 77184 RVA: 0x00080E2E File Offset: 0x0007F02E
		' (set) Token: 0x06012D81 RID: 77185 RVA: 0x00080E38 File Offset: 0x0007F038
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x170074F8 RID: 29944
		' (get) Token: 0x06012D82 RID: 77186 RVA: 0x00080E41 File Offset: 0x0007F041
		' (set) Token: 0x06012D83 RID: 77187 RVA: 0x00080E4B File Offset: 0x0007F04B
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x170074F9 RID: 29945
		' (get) Token: 0x06012D84 RID: 77188 RVA: 0x00080E54 File Offset: 0x0007F054
		' (set) Token: 0x06012D85 RID: 77189 RVA: 0x00080E5E File Offset: 0x0007F05E
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x170074FA RID: 29946
		' (get) Token: 0x06012D86 RID: 77190 RVA: 0x00080E67 File Offset: 0x0007F067
		' (set) Token: 0x06012D87 RID: 77191 RVA: 0x00080E71 File Offset: 0x0007F071
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x170074FB RID: 29947
		' (get) Token: 0x06012D88 RID: 77192 RVA: 0x00080E7A File Offset: 0x0007F07A
		' (set) Token: 0x06012D89 RID: 77193 RVA: 0x00080E84 File Offset: 0x0007F084
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x170074FC RID: 29948
		' (get) Token: 0x06012D8A RID: 77194 RVA: 0x00080E8D File Offset: 0x0007F08D
		' (set) Token: 0x06012D8B RID: 77195 RVA: 0x00080E97 File Offset: 0x0007F097
		Friend Overridable Property Label4 As Label

		' Token: 0x170074FD RID: 29949
		' (get) Token: 0x06012D8C RID: 77196 RVA: 0x00080EA0 File Offset: 0x0007F0A0
		' (set) Token: 0x06012D8D RID: 77197 RVA: 0x00080EAA File Offset: 0x0007F0AA
		Friend Overridable Property txtRemark As TextBox

		' Token: 0x170074FE RID: 29950
		' (get) Token: 0x06012D8E RID: 77198 RVA: 0x00080EB3 File Offset: 0x0007F0B3
		' (set) Token: 0x06012D8F RID: 77199 RVA: 0x00080EBD File Offset: 0x0007F0BD
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170074FF RID: 29951
		' (get) Token: 0x06012D90 RID: 77200 RVA: 0x00080EC6 File Offset: 0x0007F0C6
		' (set) Token: 0x06012D91 RID: 77201 RVA: 0x00080ED0 File Offset: 0x0007F0D0
		Friend Overridable Property Label3 As Label

		' Token: 0x17007500 RID: 29952
		' (get) Token: 0x06012D92 RID: 77202 RVA: 0x00080ED9 File Offset: 0x0007F0D9
		' (set) Token: 0x06012D93 RID: 77203 RVA: 0x00080EE3 File Offset: 0x0007F0E3
		Friend Overridable Property ColumnHeader76 As ColumnHeader

		' Token: 0x17007501 RID: 29953
		' (get) Token: 0x06012D94 RID: 77204 RVA: 0x00080EEC File Offset: 0x0007F0EC
		' (set) Token: 0x06012D95 RID: 77205 RVA: 0x00ACB780 File Offset: 0x00AC9980
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
				Dim listView As ListView = Me._ListView2
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseClick, mouseEventHandler
				End If
				Me._ListView2 = value
				listView = Me._ListView2
				If listView IsNot Nothing Then
					AddHandler listView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007502 RID: 29954
		' (get) Token: 0x06012D96 RID: 77206 RVA: 0x00080EF6 File Offset: 0x0007F0F6
		' (set) Token: 0x06012D97 RID: 77207 RVA: 0x00080F00 File Offset: 0x0007F100
		Friend Overridable Property ColumnHeader39 As ColumnHeader

		' Token: 0x17007503 RID: 29955
		' (get) Token: 0x06012D98 RID: 77208 RVA: 0x00080F09 File Offset: 0x0007F109
		' (set) Token: 0x06012D99 RID: 77209 RVA: 0x00080F13 File Offset: 0x0007F113
		Friend Overridable Property txtBranchCode As TextBox

		' Token: 0x17007504 RID: 29956
		' (get) Token: 0x06012D9A RID: 77210 RVA: 0x00080F1C File Offset: 0x0007F11C
		' (set) Token: 0x06012D9B RID: 77211 RVA: 0x00080F26 File Offset: 0x0007F126
		Friend Overridable Property txtDB As TextBox

		' Token: 0x17007505 RID: 29957
		' (get) Token: 0x06012D9C RID: 77212 RVA: 0x00080F2F File Offset: 0x0007F12F
		' (set) Token: 0x06012D9D RID: 77213 RVA: 0x00080F39 File Offset: 0x0007F139
		Friend Overridable Property cmbBranchAdmin As ComboBox

		' Token: 0x17007506 RID: 29958
		' (get) Token: 0x06012D9E RID: 77214 RVA: 0x00080F42 File Offset: 0x0007F142
		' (set) Token: 0x06012D9F RID: 77215 RVA: 0x00080F4C File Offset: 0x0007F14C
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x17007507 RID: 29959
		' (get) Token: 0x06012DA0 RID: 77216 RVA: 0x00080F55 File Offset: 0x0007F155
		' (set) Token: 0x06012DA1 RID: 77217 RVA: 0x00080F5F File Offset: 0x0007F15F
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x17007508 RID: 29960
		' (get) Token: 0x06012DA2 RID: 77218 RVA: 0x00080F68 File Offset: 0x0007F168
		' (set) Token: 0x06012DA3 RID: 77219 RVA: 0x00080F72 File Offset: 0x0007F172
		Friend Overridable Property lblUserType As Label

		' Token: 0x17007509 RID: 29961
		' (get) Token: 0x06012DA4 RID: 77220 RVA: 0x00080F7B File Offset: 0x0007F17B
		' (set) Token: 0x06012DA5 RID: 77221 RVA: 0x00080F85 File Offset: 0x0007F185
		Friend Overridable Property lblUser As Label

		' Token: 0x1700750A RID: 29962
		' (get) Token: 0x06012DA6 RID: 77222 RVA: 0x00080F8E File Offset: 0x0007F18E
		' (set) Token: 0x06012DA7 RID: 77223 RVA: 0x00080F98 File Offset: 0x0007F198
		Public Overridable Property Picture As PictureBox

		' Token: 0x1700750B RID: 29963
		' (get) Token: 0x06012DA8 RID: 77224 RVA: 0x00080FA1 File Offset: 0x0007F1A1
		' (set) Token: 0x06012DA9 RID: 77225 RVA: 0x00080FAB File Offset: 0x0007F1AB
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700750C RID: 29964
		' (get) Token: 0x06012DAA RID: 77226 RVA: 0x00080FB4 File Offset: 0x0007F1B4
		' (set) Token: 0x06012DAB RID: 77227 RVA: 0x00080FBE File Offset: 0x0007F1BE
		Friend Overridable Property txtID1 As TextBox

		' Token: 0x1700750D RID: 29965
		' (get) Token: 0x06012DAC RID: 77228 RVA: 0x00080FC7 File Offset: 0x0007F1C7
		' (set) Token: 0x06012DAD RID: 77229 RVA: 0x00080FD1 File Offset: 0x0007F1D1
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x1700750E RID: 29966
		' (get) Token: 0x06012DAE RID: 77230 RVA: 0x00080FDA File Offset: 0x0007F1DA
		' (set) Token: 0x06012DAF RID: 77231 RVA: 0x00080FE4 File Offset: 0x0007F1E4
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x06012DB0 RID: 77232 RVA: 0x00080FED File Offset: 0x0007F1ED
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.GetPending()
		End Sub

		' Token: 0x06012DB1 RID: 77233 RVA: 0x00ACB7C4 File Offset: 0x00AC99C4
		Private Sub GetPending()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TocknNo, COUNT(*) as ProductCount FROM p_transfer_in WHERE TocknNo like N'" + Me.TextBox1.Text + "%' and PStatus = 'o' GROUP BY TocknNo", ModCommonClasses.con)
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

		' Token: 0x06012DB2 RID: 77234 RVA: 0x00ACB8EC File Offset: 0x00AC9AEC
		Private Sub ListView2_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim num As Integer = Me.ListView2.Items.IndexOf(Me.ListView2.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.ListView2.Items(num)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,QrBarcode,T_Qty,TocknNo,Category,SubCategoryName FROM p_transfer_in WHERE TocknNo like N'" + listViewItem.Text + "%' and PStatus = 'o'", ModCommonClasses.con)
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

		' Token: 0x06012DB3 RID: 77235 RVA: 0x00ACBF60 File Offset: 0x00ACA160
		Public Function CheckCategory(categoryName As String) As Object
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT categoryname FROM category WHERE categoryname = @categoryName"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@categoryName", categoryName.Trim())
						Dim flag As Boolean = sqlCommand.ExecuteScalar() IsNot Nothing
						Dim flag2 As Boolean = flag
						If Not flag2 Then
							Dim text2 As String = "INSERT INTO category(categoryName, CPhoto) VALUES (@categoryName, @photo)"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@categoryName", categoryName.Trim())
								Dim flag3 As Boolean = Me.Picture.Image IsNot Nothing
								If flag3 Then
									Using memoryStream As MemoryStream = New MemoryStream()
										Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim array As Byte() = memoryStream.ToArray()
											sqlCommand2.Parameters.AddWithValue("@photo", array)
										End Using
									End Using
								Else
									MessageBox.Show("Please select an image for the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End If
								sqlCommand2.ExecuteNonQuery()
							End Using
							ModFunc.LogFunc(Me.lblUser.Text, "added the new category '" + categoryName + "'")
						End If
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012DB4 RID: 77236 RVA: 0x00ACC19C File Offset: 0x00ACA39C
		Private Sub btnDToken_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.listView1.Items.Count > 0
			If flag Then
				Try
					For Each obj As Object In Me.listView1.Items
						Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
						Me.CheckCategory(listViewItem.SubItems(38).Text)
						Dim text As String = Me.SubCategoryCheck(listViewItem.SubItems(38).Text, listViewItem.SubItems(39).Text)
						Dim text2 As String = listViewItem.SubItems(3).Text.ToString()
						Dim text3 As String = text
						Dim text4 As String = listViewItem.SubItems(6).Text.ToString()
						Dim num As Double = Double.Parse(listViewItem.SubItems(7).Text)
						Dim num2 As Double = Double.Parse(Conversions.ToString(0.0))
						Dim num3 As Double = Double.Parse(listViewItem.SubItems(12).Text)
						Dim text5 As String = listViewItem.SubItems(2).Text.ToString()
						Dim text6 As String = listViewItem.SubItems(15).Text.ToString()
						Dim text7 As String = listViewItem.SubItems(16).Text.ToString()
						Dim num4 As Double = Double.Parse(listViewItem.SubItems(13).Text)
						Dim text8 As String = listViewItem.SubItems(4).Text.ToString()
						Dim text9 As String = listViewItem.SubItems(5).Text.ToString()
						Dim num5 As Double = Double.Parse(listViewItem.SubItems(14).Text)
						Dim text10 As String = listViewItem.SubItems(17).Text.ToString()
						Dim num6 As Double = Double.Parse(listViewItem.SubItems(18).Text)
						Dim num7 As Double = Double.Parse(listViewItem.SubItems(19).Text)
						Dim text11 As String = "Yes"
						Dim text12 As String = "Inclusive"
						Dim text13 As String = "Exclusive"
						Dim text14 As String = listViewItem.SubItems(20).Text.ToString()
						Dim text15 As String = listViewItem.SubItems(21).Text.ToString()
						Dim num8 As Double = Double.Parse(listViewItem.SubItems(8).Text)
						Dim num9 As Double = Double.Parse(listViewItem.SubItems(9).Text)
						Dim num10 As Double = Double.Parse(listViewItem.SubItems(10).Text)
						Dim num11 As Double = Double.Parse(Conversions.ToString(0.0))
						Dim today As DateTime = DateAndTime.Today
						Dim num12 As Double = Double.Parse(listViewItem.SubItems(22).Text)
						Dim text16 As String = ""
						Dim num13 As Double = Double.Parse(listViewItem.SubItems(25).Text)
						Dim num14 As Double = Double.Parse(listViewItem.SubItems(26).Text)
						Dim num15 As Double = Double.Parse(Conversions.ToString(0.0))
						Dim text17 As String = listViewItem.SubItems(27).Text.ToString()
						Dim text18 As String = listViewItem.SubItems(28).Text.ToString()
						Dim text19 As String = listViewItem.SubItems(29).Text.ToString()
						Dim text20 As String = listViewItem.SubItems(31).Text.ToString()
						Dim text21 As String = listViewItem.SubItems(30).Text.ToString()
						Dim num16 As Double = Double.Parse(listViewItem.SubItems(25).Text)
						Dim num17 As Double = Double.Parse(listViewItem.SubItems(26).Text)
						Dim text22 As String = ""
						Dim text23 As String = listViewItem.SubItems(32).Text.ToString()
						Dim text24 As String = listViewItem.SubItems(33).Text.ToString()
						Dim num18 As Double = Double.Parse(listViewItem.SubItems(7).Text)
						Dim num19 As Double = Double.Parse(listViewItem.SubItems(7).Text)
						Dim num20 As Double = Double.Parse(listViewItem.SubItems(36).Text)
						Dim text25 As String = listViewItem.SubItems(37).Text.ToString()
						Me.InsertProduct(text5, text2, text3, text4, num, num2, num3, text6, text7, num4, text8, text9, num5, text10, num6, num7, text11, text12, text13, text14, text15, num8, num9, num10, num11, Conversions.ToString(today), Conversions.ToString(num12), text16, num13, num14, num15, text17, text18, text19, text20, text21, num16, num17, text22, text23, text24, num18, num19, Conversions.ToString(num20), text25)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.listView1.Items.Clear()
				Me.ListView2.Items.Clear()
				Me.TextBox1.Text = ""
				Try
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x06012DB5 RID: 77237 RVA: 0x006A3584 File Offset: 0x006A1784
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
					Dim text2 As String = "update Temp_stock set qty = qty + (" + Conversions.ToString(TQty) + ") where ProductID=@d1 and Barcode=@d2"
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
				MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012DB6 RID: 77238 RVA: 0x00ACC70C File Offset: 0x00ACA90C
		Public Function SubCategoryCheck(category As String, subcategory As String) As String
			Dim text As String = ""
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text2 As String = "Select ID,SubCategoryName, Category FROM SubCategory WHERE SubCategoryName = @subCategoryName And Category = @category"
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@subCategoryName", subcategory)
						sqlCommand.Parameters.AddWithValue("@category", subcategory)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								subcategory = ""
								Dim text3 As String = sqlDataReader(0).ToString()
								text = text3
							Else
								Dim text4 As String = "INSERT INTO SubCategory (SubCategoryName, Category, ID, SCPhoto) VALUES (@subCategoryName, @category, @id, @photo)"
								Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection)
									Try
										sqlCommand2.Parameters.AddWithValue("@subCategoryName", subcategory)
										sqlCommand2.Parameters.AddWithValue("@category", category)
										Me.auto()
										sqlCommand2.Parameters.AddWithValue("@id", Me.txtID.Text)
										Using memoryStream As MemoryStream = New MemoryStream()
											Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
												bitmap.Save(memoryStream, ImageFormat.Jpeg)
												Dim array As Byte() = memoryStream.ToArray()
												sqlCommand2.Parameters.AddWithValue("@photo", array)
											End Using
										End Using
										sqlCommand2.ExecuteNonQuery()
										text = Me.txtID.Text
									Catch ex As Exception
										MessageBox.Show(ex.Message)
									End Try
								End Using
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the New subcategory '", subcategory, "' having Category '", category, "'" }))
							End If
						End Using
					End Using
				End Using
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return text
		End Function

		' Token: 0x06012DB7 RID: 77239 RVA: 0x00ACCA10 File Offset: 0x00ACAC10
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012DB8 RID: 77240 RVA: 0x00ACCB14 File Offset: 0x00ACAD14
		Public Sub InsertProduct(barcode As String, pName As String, SubCategoryID As String, PDescription As String, PCostPrice As Double, PDiscount As Double, PCGST As Double, PPurchaseUnit As String, PSalesUnit As String, PPSGST As Double, PPHSNCode As String, PPartNo As String, PCess As Double, PSalesAltUnit As String, PConv As Double, PMinStock As Double, PStatus As String, PSTax As String, PPTax As String, PGDown As String, PRack As String, PMRP As Double, PSellingPrice As Double, PReorderPoint As Double, POpeningStock As Double, PAddDate As String, PDefQty As String, PKitchen As String, SPrice As Double, WPrice As Double, StLimit As Double, Batch As String, Mfgdate As String, Expdate As String, Size As String, Colour As String, SalePrice As Double, WSalePrice As Double, SuplName As String, IMEI1 As String, IMEI2 As String, PPrice As Double, EPPrice As Double, TQty As String, TocknNo As String)
			' The following expression was wrapped in a checked-statement
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT Barcode FROM Temp_Stock WHERE Barcode = @d1"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", barcode)
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
						Dim flag As Boolean = objectValue IsNot Nothing
						If flag Then
							Me.CheckBarcodeExists(barcode, Conversions.ToDouble(TQty))
						Else
							Me.GenerateNewProductID()
							Dim num As Integer = CInt(Math.Round(Conversion.Val(Me.txtID1.Text)))
							Dim text2 As String = "INSERT INTO Product (PID,ProductCode,ProductName,SubCategoryID,Description,CostPrice,Discount,CGST,Barcode, " & vbCrLf & "                                                                          PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status, " & vbCrLf & "                                                                          STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES" & vbCrLf & "                                                                          (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & vbCrLf & "                                                                           @d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18," & vbCrLf & "                                                                           @d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29)"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@d0", num)
								sqlCommand2.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
								sqlCommand2.Parameters.AddWithValue("@d2", pName)
								sqlCommand2.Parameters.AddWithValue("@d3", SubCategoryID)
								sqlCommand2.Parameters.AddWithValue("@d4", PDescription)
								sqlCommand2.Parameters.AddWithValue("@d5", PCostPrice)
								sqlCommand2.Parameters.AddWithValue("@d6", PDiscount)
								sqlCommand2.Parameters.AddWithValue("@d7", PCGST)
								sqlCommand2.Parameters.AddWithValue("@d8", "0")
								sqlCommand2.Parameters.AddWithValue("@d9", PPurchaseUnit)
								sqlCommand2.Parameters.AddWithValue("@d10", PSalesUnit)
								sqlCommand2.Parameters.AddWithValue("@d11", PPSGST)
								sqlCommand2.Parameters.AddWithValue("@d12", PPHSNCode)
								sqlCommand2.Parameters.AddWithValue("@d13", PPartNo)
								sqlCommand2.Parameters.AddWithValue("@d14", PCess)
								sqlCommand2.Parameters.AddWithValue("@d15", PSalesAltUnit)
								sqlCommand2.Parameters.AddWithValue("@d16", PConv)
								sqlCommand2.Parameters.AddWithValue("@d17", PMinStock)
								sqlCommand2.Parameters.AddWithValue("@d18", PStatus)
								sqlCommand2.Parameters.AddWithValue("@d19", PSTax)
								sqlCommand2.Parameters.AddWithValue("@d20", PPTax)
								sqlCommand2.Parameters.AddWithValue("@d21", PGDown)
								sqlCommand2.Parameters.AddWithValue("@d22", PRack)
								sqlCommand2.Parameters.AddWithValue("@d23", PMRP)
								sqlCommand2.Parameters.AddWithValue("@d24", PSellingPrice)
								sqlCommand2.Parameters.AddWithValue("@d25", PReorderPoint)
								sqlCommand2.Parameters.AddWithValue("@d26", POpeningStock)
								sqlCommand2.Parameters.AddWithValue("@d27", DateAndTime.Today)
								sqlCommand2.Parameters.AddWithValue("@d28", PDefQty)
								sqlCommand2.Parameters.AddWithValue("@d29", PKitchen)
								sqlCommand2.ExecuteNonQuery()
							End Using
							Dim text3 As String = "INSERT INTO Product_Join (ProductID, photo) VALUES (@productID, @imageData)"
							Using sqlCommand3 As SqlCommand = New SqlCommand(text3, sqlConnection)
								sqlCommand3.Parameters.AddWithValue("@productID", num)
								Using memoryStream As MemoryStream = New MemoryStream()
									Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim array As Byte() = memoryStream.ToArray()
										sqlCommand3.Parameters.AddWithValue("@imageData", array)
									End Using
								End Using
								sqlCommand3.ExecuteNonQuery()
								sqlCommand3.Parameters.Clear()
							End Using
							Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection2.Open()
								Dim text4 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice," & vbCrLf & "                                                                         WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode) VALUES " & vbCrLf & "                                                                        (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12," & vbCrLf & "                                                                        @d13,@d14,@d15,@d16,@d17,@d18,@d19)"
								Using sqlCommand4 As SqlCommand = New SqlCommand(text4, sqlConnection2)
									sqlCommand4.Connection = sqlConnection2
									sqlCommand4.Prepare()
									Me.Generate_GiftQR(barcode)
									sqlCommand4.Parameters.AddWithValue("@d0", num)
									sqlCommand4.Parameters.AddWithValue("@d1", Conversion.Val(TQty))
									sqlCommand4.Parameters.AddWithValue("@d2", barcode)
									sqlCommand4.Parameters.AddWithValue("@d3", Conversion.Val(PSellingPrice))
									sqlCommand4.Parameters.AddWithValue("@d4", Conversion.Val(WPrice))
									sqlCommand4.Parameters.AddWithValue("@d5", 0)
									sqlCommand4.Parameters.AddWithValue("@d6", Conversion.Val(PMRP))
									sqlCommand4.Parameters.AddWithValue("@d7", Batch)
									sqlCommand4.Parameters.AddWithValue("@d8", Mfgdate)
									sqlCommand4.Parameters.AddWithValue("@d9", Expdate)
									sqlCommand4.Parameters.AddWithValue("@d10", Size)
									sqlCommand4.Parameters.AddWithValue("@d11", Colour)
									sqlCommand4.Parameters.AddWithValue("@d12", SalePrice)
									sqlCommand4.Parameters.AddWithValue("@d13", WSalePrice)
									sqlCommand4.Parameters.AddWithValue("@d14", "T Stock")
									sqlCommand4.Parameters.AddWithValue("@d15", IMEI1)
									sqlCommand4.Parameters.AddWithValue("@d16", IMEI2)
									sqlCommand4.Parameters.AddWithValue("@d17", Conversion.Val(PPrice))
									sqlCommand4.Parameters.AddWithValue("@d18", Conversion.Val(EPPrice))
									Dim memoryStream2 As MemoryStream = New MemoryStream()
									Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
									bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
									Dim buffer As Byte() = memoryStream2.GetBuffer()
									Dim sqlParameter As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
									sqlParameter.Value = buffer
									sqlCommand4.Parameters.Add(sqlParameter)
									sqlCommand4.ExecuteNonQuery()
									sqlCommand4.Parameters.Clear()
									sqlConnection2.Close()
								End Using
							End Using
							Dim flag2 As Boolean = Conversion.Val(POpeningStock) <= 0.0
							If flag2 Then
								Using sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
									sqlConnection3.Open()
									Dim text5 As String = "Select ProductID from StockMovement where ProductID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text5)
									ModCommonClasses.cmd.Connection = sqlConnection
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag3 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag3 Then
										ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), 0D, New Decimal(Conversion.Val(10)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
									Else
										Using sqlConnection4 As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection4.Open()
											Dim text6 As String = "Select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 And Date < @d3"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = sqlConnection
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
											Dim num2 As Double
											If flag4 Then
												num2 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
											Else
												num2 = 0.0
											End If
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID1.Text))), New Decimal(num2), New Decimal(Conversion.Val(10)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
										End Using
									End If
								End Using
							End If
						End If
						Using sqlConnection5 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection5.Open()
							Dim text7 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text7)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", PSalesAltUnit)
							ModCommonClasses.cmd.Connection = sqlConnection
							ModCommonClasses.cmd.ExecuteReader()
						End Using
						Using sqlConnection6 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection6.Open()
							Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text8)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", PSalesAltUnit)
							ModCommonClasses.cmd.Connection = sqlConnection
							ModCommonClasses.cmd.ExecuteReader()
							ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new Product '", pName, "' having Product code '", Me.txtProductCode.Text, "'" }))
						End Using
					End Using
					Me.updatetoOffline(barcode, TocknNo)
				End Using
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012DB9 RID: 77241 RVA: 0x006A31D4 File Offset: 0x006A13D4
		Public Function updatetoOffline(barcode As String, TocknNo As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "Update p_transfer_in set PStatus=@d1 where barcode= '", barcode, "' and TocknNo= '", TocknNo, "'" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "f")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012DBA RID: 77242 RVA: 0x00ACD6FC File Offset: 0x00ACB8FC
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06012DBB RID: 77243 RVA: 0x0020DD08 File Offset: 0x0020BF08
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

		' Token: 0x06012DBC RID: 77244 RVA: 0x0011427C File Offset: 0x0011247C
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

		' Token: 0x06012DBD RID: 77245 RVA: 0x00ACD780 File Offset: 0x00ACB980
		Public Sub GenerateNewProductID()
			Try
				Me.txtID1.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012DBE RID: 77246 RVA: 0x00ACD7F4 File Offset: 0x00ACB9F4
		Private Sub frmTokenSettlement_Load(sender As Object, e As EventArgs)
			Me.auto()
			Me.listView1.Items.Clear()
			Me.ListView2.Items.Clear()
			Me.TextBox1.Text = ""
			Me.Convert_Language()
		End Sub

		' Token: 0x06012DBF RID: 77247 RVA: 0x00ACD844 File Offset: 0x00ACBA44
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

		' Token: 0x06012DC0 RID: 77248 RVA: 0x00ACD9BC File Offset: 0x00ACBBBC
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

		' Token: 0x06012DC1 RID: 77249 RVA: 0x00ACDA78 File Offset: 0x00ACBC78
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

		' Token: 0x06012DC2 RID: 77250 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06012DC3 RID: 77251 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012DC4 RID: 77252 RVA: 0x00087088 File Offset: 0x00085288
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
	End Class
End Namespace
