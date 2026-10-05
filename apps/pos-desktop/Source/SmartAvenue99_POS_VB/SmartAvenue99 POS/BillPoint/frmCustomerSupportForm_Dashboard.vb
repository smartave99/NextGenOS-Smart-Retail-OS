Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000C5 RID: 197
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupportForm_Dashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001FBA RID: 8122 RVA: 0x00149754 File Offset: 0x00147954
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSheet_Report_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerSupportLog_Dashboard_KeyDown
			Me.dt = New DataTable()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000C87 RID: 3207
		' (get) Token: 0x06001FBD RID: 8125 RVA: 0x000166C6 File Offset: 0x000148C6
		' (set) Token: 0x06001FBE RID: 8126 RVA: 0x0014F0BC File Offset: 0x0014D2BC
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.DataGridView1_CellFormatting
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C88 RID: 3208
		' (get) Token: 0x06001FBF RID: 8127 RVA: 0x000166D0 File Offset: 0x000148D0
		' (set) Token: 0x06001FC0 RID: 8128 RVA: 0x0014F138 File Offset: 0x0014D338
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim gelButton As GelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnShowAll = value
				gelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C89 RID: 3209
		' (get) Token: 0x06001FC1 RID: 8129 RVA: 0x000166DA File Offset: 0x000148DA
		' (set) Token: 0x06001FC2 RID: 8130 RVA: 0x000166E4 File Offset: 0x000148E4
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000C8A RID: 3210
		' (get) Token: 0x06001FC3 RID: 8131 RVA: 0x000166ED File Offset: 0x000148ED
		' (set) Token: 0x06001FC4 RID: 8132 RVA: 0x0014F17C File Offset: 0x0014D37C
		Private _txtTokenNo As TextBox
		Friend Overridable Property txtTokenNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTokenNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtTokenNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTokenNo = value
				textBox = Me._txtTokenNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C8B RID: 3211
		' (get) Token: 0x06001FC5 RID: 8133 RVA: 0x000166F7 File Offset: 0x000148F7
		' (set) Token: 0x06001FC6 RID: 8134 RVA: 0x00016701 File Offset: 0x00014901
		Friend Overridable Property Label3 As Label

		' Token: 0x17000C8C RID: 3212
		' (get) Token: 0x06001FC7 RID: 8135 RVA: 0x0001670A File Offset: 0x0001490A
		' (set) Token: 0x06001FC8 RID: 8136 RVA: 0x00016714 File Offset: 0x00014914
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17000C8D RID: 3213
		' (get) Token: 0x06001FC9 RID: 8137 RVA: 0x0001671D File Offset: 0x0001491D
		' (set) Token: 0x06001FCA RID: 8138 RVA: 0x00016727 File Offset: 0x00014927
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000C8E RID: 3214
		' (get) Token: 0x06001FCB RID: 8139 RVA: 0x00016730 File Offset: 0x00014930
		' (set) Token: 0x06001FCC RID: 8140 RVA: 0x0014F1C0 File Offset: 0x0014D3C0
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C8F RID: 3215
		' (get) Token: 0x06001FCD RID: 8141 RVA: 0x0001673A File Offset: 0x0001493A
		' (set) Token: 0x06001FCE RID: 8142 RVA: 0x00016744 File Offset: 0x00014944
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000C90 RID: 3216
		' (get) Token: 0x06001FCF RID: 8143 RVA: 0x0001674D File Offset: 0x0001494D
		' (set) Token: 0x06001FD0 RID: 8144 RVA: 0x00016757 File Offset: 0x00014957
		Friend Overridable Property Label2 As Label

		' Token: 0x17000C91 RID: 3217
		' (get) Token: 0x06001FD1 RID: 8145 RVA: 0x00016760 File Offset: 0x00014960
		' (set) Token: 0x06001FD2 RID: 8146 RVA: 0x0001676A File Offset: 0x0001496A
		Friend Overridable Property Label1 As Label

		' Token: 0x17000C92 RID: 3218
		' (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00016773 File Offset: 0x00014973
		' (set) Token: 0x06001FD4 RID: 8148 RVA: 0x0001677D File Offset: 0x0001497D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17000C93 RID: 3219
		' (get) Token: 0x06001FD5 RID: 8149 RVA: 0x00016786 File Offset: 0x00014986
		' (set) Token: 0x06001FD6 RID: 8150 RVA: 0x00016790 File Offset: 0x00014990
		Friend Overridable Property Label4 As Label

		' Token: 0x17000C94 RID: 3220
		' (get) Token: 0x06001FD7 RID: 8151 RVA: 0x00016799 File Offset: 0x00014999
		' (set) Token: 0x06001FD8 RID: 8152 RVA: 0x0014F204 File Offset: 0x0014D404
		Private _rdo_Closed As RadioButton
		Friend Overridable Property rdo_Closed As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Closed
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Closed_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Closed
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Closed = value
				radioButton = Me._rdo_Closed
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C95 RID: 3221
		' (get) Token: 0x06001FD9 RID: 8153 RVA: 0x000167A3 File Offset: 0x000149A3
		' (set) Token: 0x06001FDA RID: 8154 RVA: 0x0014F248 File Offset: 0x0014D448
		Private _rdo_Process As RadioButton
		Friend Overridable Property rdo_Process As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Process
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Process_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Process
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Process = value
				radioButton = Me._rdo_Process
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C96 RID: 3222
		' (get) Token: 0x06001FDB RID: 8155 RVA: 0x000167AD File Offset: 0x000149AD
		' (set) Token: 0x06001FDC RID: 8156 RVA: 0x0014F28C File Offset: 0x0014D48C
		Private _rdo_Open As RadioButton
		Friend Overridable Property rdo_Open As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Open
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Open_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Open
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Open = value
				radioButton = Me._rdo_Open
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C97 RID: 3223
		' (get) Token: 0x06001FDD RID: 8157 RVA: 0x000167B7 File Offset: 0x000149B7
		' (set) Token: 0x06001FDE RID: 8158 RVA: 0x000167C1 File Offset: 0x000149C1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000C98 RID: 3224
		' (get) Token: 0x06001FDF RID: 8159 RVA: 0x000167CA File Offset: 0x000149CA
		' (set) Token: 0x06001FE0 RID: 8160 RVA: 0x000167D4 File Offset: 0x000149D4
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000C99 RID: 3225
		' (get) Token: 0x06001FE1 RID: 8161 RVA: 0x000167DD File Offset: 0x000149DD
		' (set) Token: 0x06001FE2 RID: 8162 RVA: 0x000167E7 File Offset: 0x000149E7
		Friend Overridable Property Label5 As Label

		' Token: 0x17000C9A RID: 3226
		' (get) Token: 0x06001FE3 RID: 8163 RVA: 0x000167F0 File Offset: 0x000149F0
		' (set) Token: 0x06001FE4 RID: 8164 RVA: 0x000167FA File Offset: 0x000149FA
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000C9B RID: 3227
		' (get) Token: 0x06001FE5 RID: 8165 RVA: 0x00016803 File Offset: 0x00014A03
		' (set) Token: 0x06001FE6 RID: 8166 RVA: 0x0001680D File Offset: 0x00014A0D
		Friend Overridable Property Label18 As Label

		' Token: 0x17000C9C RID: 3228
		' (get) Token: 0x06001FE7 RID: 8167 RVA: 0x00016816 File Offset: 0x00014A16
		' (set) Token: 0x06001FE8 RID: 8168 RVA: 0x00016820 File Offset: 0x00014A20
		Friend Overridable Property Label21 As Label

		' Token: 0x17000C9D RID: 3229
		' (get) Token: 0x06001FE9 RID: 8169 RVA: 0x00016829 File Offset: 0x00014A29
		' (set) Token: 0x06001FEA RID: 8170 RVA: 0x00016833 File Offset: 0x00014A33
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17000C9E RID: 3230
		' (get) Token: 0x06001FEB RID: 8171 RVA: 0x0001683C File Offset: 0x00014A3C
		' (set) Token: 0x06001FEC RID: 8172 RVA: 0x0014F2D0 File Offset: 0x0014D4D0
		Private _btnRefresh As GelButton
		Friend Overridable Property btnRefresh As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRefresh
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRefresh_Click
				Dim gelButton As GelButton = Me._btnRefresh
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRefresh = value
				gelButton = Me._btnRefresh
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C9F RID: 3231
		' (get) Token: 0x06001FED RID: 8173 RVA: 0x00016846 File Offset: 0x00014A46
		' (set) Token: 0x06001FEE RID: 8174 RVA: 0x00016850 File Offset: 0x00014A50
		Friend Overridable Property pnl_FollowUp As Panel

		' Token: 0x17000CA0 RID: 3232
		' (get) Token: 0x06001FEF RID: 8175 RVA: 0x00016859 File Offset: 0x00014A59
		' (set) Token: 0x06001FF0 RID: 8176 RVA: 0x00016863 File Offset: 0x00014A63
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000CA1 RID: 3233
		' (get) Token: 0x06001FF1 RID: 8177 RVA: 0x0001686C File Offset: 0x00014A6C
		' (set) Token: 0x06001FF2 RID: 8178 RVA: 0x00016876 File Offset: 0x00014A76
		Friend Overridable Property lblTokenNo As Label

		' Token: 0x17000CA2 RID: 3234
		' (get) Token: 0x06001FF3 RID: 8179 RVA: 0x0001687F File Offset: 0x00014A7F
		' (set) Token: 0x06001FF4 RID: 8180 RVA: 0x0014F314 File Offset: 0x0014D514
		Private _btnTokenUpdate As GelButton
		Friend Overridable Property btnTokenUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnTokenUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnTokenUpdate_Click
				Dim gelButton As GelButton = Me._btnTokenUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnTokenUpdate = value
				gelButton = Me._btnTokenUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CA3 RID: 3235
		' (get) Token: 0x06001FF5 RID: 8181 RVA: 0x00016889 File Offset: 0x00014A89
		' (set) Token: 0x06001FF6 RID: 8182 RVA: 0x00016893 File Offset: 0x00014A93
		Friend Overridable Property txtRemarks As TextBox

		' Token: 0x17000CA4 RID: 3236
		' (get) Token: 0x06001FF7 RID: 8183 RVA: 0x0001689C File Offset: 0x00014A9C
		' (set) Token: 0x06001FF8 RID: 8184 RVA: 0x000168A6 File Offset: 0x00014AA6
		Friend Overridable Property Label6 As Label

		' Token: 0x17000CA5 RID: 3237
		' (get) Token: 0x06001FF9 RID: 8185 RVA: 0x000168AF File Offset: 0x00014AAF
		' (set) Token: 0x06001FFA RID: 8186 RVA: 0x000168B9 File Offset: 0x00014AB9
		Friend Overridable Property lbl_Id As Label

		' Token: 0x17000CA6 RID: 3238
		' (get) Token: 0x06001FFB RID: 8187 RVA: 0x000168C2 File Offset: 0x00014AC2
		' (set) Token: 0x06001FFC RID: 8188 RVA: 0x000168CC File Offset: 0x00014ACC
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000CA7 RID: 3239
		' (get) Token: 0x06001FFD RID: 8189 RVA: 0x000168D5 File Offset: 0x00014AD5
		' (set) Token: 0x06001FFE RID: 8190 RVA: 0x000168DF File Offset: 0x00014ADF
		Friend Overridable Property lblUser As Label

		' Token: 0x17000CA8 RID: 3240
		' (get) Token: 0x06001FFF RID: 8191 RVA: 0x000168E8 File Offset: 0x00014AE8
		' (set) Token: 0x06002000 RID: 8192 RVA: 0x0014F358 File Offset: 0x0014D558
		Private _btnClosed As GelButton
		Friend Overridable Property btnClosed As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnClosed
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnClosed_Click
				Dim gelButton As GelButton = Me._btnClosed
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnClosed = value
				gelButton = Me._btnClosed
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CA9 RID: 3241
		' (get) Token: 0x06002001 RID: 8193 RVA: 0x000168F2 File Offset: 0x00014AF2
		' (set) Token: 0x06002002 RID: 8194 RVA: 0x000168FC File Offset: 0x00014AFC
		Friend Overridable Property lbl_tokenid As Label

		' Token: 0x17000CAA RID: 3242
		' (get) Token: 0x06002003 RID: 8195 RVA: 0x00016905 File Offset: 0x00014B05
		' (set) Token: 0x06002004 RID: 8196 RVA: 0x0001690F File Offset: 0x00014B0F
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x17000CAB RID: 3243
		' (get) Token: 0x06002005 RID: 8197 RVA: 0x00016918 File Offset: 0x00014B18
		' (set) Token: 0x06002006 RID: 8198 RVA: 0x00016922 File Offset: 0x00014B22
		Friend Overridable Property lblCount As Label

		' Token: 0x17000CAC RID: 3244
		' (get) Token: 0x06002007 RID: 8199 RVA: 0x0001692B File Offset: 0x00014B2B
		' (set) Token: 0x06002008 RID: 8200 RVA: 0x00016935 File Offset: 0x00014B35
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000CAD RID: 3245
		' (get) Token: 0x06002009 RID: 8201 RVA: 0x0001693E File Offset: 0x00014B3E
		' (set) Token: 0x0600200A RID: 8202 RVA: 0x00016948 File Offset: 0x00014B48
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000CAE RID: 3246
		' (get) Token: 0x0600200B RID: 8203 RVA: 0x00016951 File Offset: 0x00014B51
		' (set) Token: 0x0600200C RID: 8204 RVA: 0x0001695B File Offset: 0x00014B5B
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17000CAF RID: 3247
		' (get) Token: 0x0600200D RID: 8205 RVA: 0x00016964 File Offset: 0x00014B64
		' (set) Token: 0x0600200E RID: 8206 RVA: 0x0001696E File Offset: 0x00014B6E
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000CB0 RID: 3248
		' (get) Token: 0x0600200F RID: 8207 RVA: 0x00016977 File Offset: 0x00014B77
		' (set) Token: 0x06002010 RID: 8208 RVA: 0x00016981 File Offset: 0x00014B81
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000CB1 RID: 3249
		' (get) Token: 0x06002011 RID: 8209 RVA: 0x0001698A File Offset: 0x00014B8A
		' (set) Token: 0x06002012 RID: 8210 RVA: 0x00016994 File Offset: 0x00014B94
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000CB2 RID: 3250
		' (get) Token: 0x06002013 RID: 8211 RVA: 0x0001699D File Offset: 0x00014B9D
		' (set) Token: 0x06002014 RID: 8212 RVA: 0x000169A7 File Offset: 0x00014BA7
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000CB3 RID: 3251
		' (get) Token: 0x06002015 RID: 8213 RVA: 0x000169B0 File Offset: 0x00014BB0
		' (set) Token: 0x06002016 RID: 8214 RVA: 0x000169BA File Offset: 0x00014BBA
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17000CB4 RID: 3252
		' (get) Token: 0x06002017 RID: 8215 RVA: 0x000169C3 File Offset: 0x00014BC3
		' (set) Token: 0x06002018 RID: 8216 RVA: 0x000169CD File Offset: 0x00014BCD
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17000CB5 RID: 3253
		' (get) Token: 0x06002019 RID: 8217 RVA: 0x000169D6 File Offset: 0x00014BD6
		' (set) Token: 0x0600201A RID: 8218 RVA: 0x000169E0 File Offset: 0x00014BE0
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17000CB6 RID: 3254
		' (get) Token: 0x0600201B RID: 8219 RVA: 0x000169E9 File Offset: 0x00014BE9
		' (set) Token: 0x0600201C RID: 8220 RVA: 0x000169F3 File Offset: 0x00014BF3
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17000CB7 RID: 3255
		' (get) Token: 0x0600201D RID: 8221 RVA: 0x000169FC File Offset: 0x00014BFC
		' (set) Token: 0x0600201E RID: 8222 RVA: 0x0014F39C File Offset: 0x0014D59C
		Private _lnkPanle_CLose As LinkLabel
		Friend Overridable Property lnkPanle_CLose As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._lnkPanle_CLose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.lnkPanle_CLose_LinkClicked
				Dim linkLabel As LinkLabel = Me._lnkPanle_CLose
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._lnkPanle_CLose = value
				linkLabel = Me._lnkPanle_CLose
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CB8 RID: 3256
		' (get) Token: 0x0600201F RID: 8223 RVA: 0x00016A06 File Offset: 0x00014C06
		' (set) Token: 0x06002020 RID: 8224 RVA: 0x00016A10 File Offset: 0x00014C10
		Friend Overridable Property lblNumbers As Label

		' Token: 0x17000CB9 RID: 3257
		' (get) Token: 0x06002021 RID: 8225 RVA: 0x00016A19 File Offset: 0x00014C19
		' (set) Token: 0x06002022 RID: 8226 RVA: 0x00016A23 File Offset: 0x00014C23
		Friend Overridable Property lblCurrentIssue As Label

		' Token: 0x17000CBA RID: 3258
		' (get) Token: 0x06002023 RID: 8227 RVA: 0x00016A2C File Offset: 0x00014C2C
		' (set) Token: 0x06002024 RID: 8228 RVA: 0x00016A36 File Offset: 0x00014C36
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000CBB RID: 3259
		' (get) Token: 0x06002025 RID: 8229 RVA: 0x00016A3F File Offset: 0x00014C3F
		' (set) Token: 0x06002026 RID: 8230 RVA: 0x0014F3E0 File Offset: 0x0014D5E0
		Private _txtMobile As TextBox
		Friend Overridable Property txtMobile As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMobile
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMobile_TextChanged
				Dim textBox As TextBox = Me._txtMobile
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtMobile = value
				textBox = Me._txtMobile
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CBC RID: 3260
		' (get) Token: 0x06002027 RID: 8231 RVA: 0x00016A49 File Offset: 0x00014C49
		' (set) Token: 0x06002028 RID: 8232 RVA: 0x00016A53 File Offset: 0x00014C53
		Friend Overridable Property Label7 As Label

		' Token: 0x17000CBD RID: 3261
		' (get) Token: 0x06002029 RID: 8233 RVA: 0x00016A5C File Offset: 0x00014C5C
		' (set) Token: 0x0600202A RID: 8234 RVA: 0x0014F424 File Offset: 0x0014D624
		Private _btnOffline_Online As GelButton
		Friend Overridable Property btnOffline_Online As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnOffline_Online
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnOffline_Online_Click
				Dim gelButton As GelButton = Me._btnOffline_Online
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnOffline_Online = value
				gelButton = Me._btnOffline_Online
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CBE RID: 3262
		' (get) Token: 0x0600202B RID: 8235 RVA: 0x00016A66 File Offset: 0x00014C66
		' (set) Token: 0x0600202C RID: 8236 RVA: 0x00016A70 File Offset: 0x00014C70
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000CBF RID: 3263
		' (get) Token: 0x0600202D RID: 8237 RVA: 0x00016A79 File Offset: 0x00014C79
		' (set) Token: 0x0600202E RID: 8238 RVA: 0x00016A83 File Offset: 0x00014C83
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000CC0 RID: 3264
		' (get) Token: 0x0600202F RID: 8239 RVA: 0x00016A8C File Offset: 0x00014C8C
		' (set) Token: 0x06002030 RID: 8240 RVA: 0x00016A96 File Offset: 0x00014C96
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000CC1 RID: 3265
		' (get) Token: 0x06002031 RID: 8241 RVA: 0x00016A9F File Offset: 0x00014C9F
		' (set) Token: 0x06002032 RID: 8242 RVA: 0x00016AA9 File Offset: 0x00014CA9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000CC2 RID: 3266
		' (get) Token: 0x06002033 RID: 8243 RVA: 0x00016AB2 File Offset: 0x00014CB2
		' (set) Token: 0x06002034 RID: 8244 RVA: 0x00016ABC File Offset: 0x00014CBC
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000CC3 RID: 3267
		' (get) Token: 0x06002035 RID: 8245 RVA: 0x00016AC5 File Offset: 0x00014CC5
		' (set) Token: 0x06002036 RID: 8246 RVA: 0x00016ACF File Offset: 0x00014CCF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000CC4 RID: 3268
		' (get) Token: 0x06002037 RID: 8247 RVA: 0x00016AD8 File Offset: 0x00014CD8
		' (set) Token: 0x06002038 RID: 8248 RVA: 0x00016AE2 File Offset: 0x00014CE2
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000CC5 RID: 3269
		' (get) Token: 0x06002039 RID: 8249 RVA: 0x00016AEB File Offset: 0x00014CEB
		' (set) Token: 0x0600203A RID: 8250 RVA: 0x00016AF5 File Offset: 0x00014CF5
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000CC6 RID: 3270
		' (get) Token: 0x0600203B RID: 8251 RVA: 0x00016AFE File Offset: 0x00014CFE
		' (set) Token: 0x0600203C RID: 8252 RVA: 0x00016B08 File Offset: 0x00014D08
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000CC7 RID: 3271
		' (get) Token: 0x0600203D RID: 8253 RVA: 0x00016B11 File Offset: 0x00014D11
		' (set) Token: 0x0600203E RID: 8254 RVA: 0x00016B1B File Offset: 0x00014D1B
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000CC8 RID: 3272
		' (get) Token: 0x0600203F RID: 8255 RVA: 0x00016B24 File Offset: 0x00014D24
		' (set) Token: 0x06002040 RID: 8256 RVA: 0x00016B2E File Offset: 0x00014D2E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000CC9 RID: 3273
		' (get) Token: 0x06002041 RID: 8257 RVA: 0x00016B37 File Offset: 0x00014D37
		' (set) Token: 0x06002042 RID: 8258 RVA: 0x00016B41 File Offset: 0x00014D41
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000CCA RID: 3274
		' (get) Token: 0x06002043 RID: 8259 RVA: 0x00016B4A File Offset: 0x00014D4A
		' (set) Token: 0x06002044 RID: 8260 RVA: 0x00016B54 File Offset: 0x00014D54
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000CCB RID: 3275
		' (get) Token: 0x06002045 RID: 8261 RVA: 0x00016B5D File Offset: 0x00014D5D
		' (set) Token: 0x06002046 RID: 8262 RVA: 0x00016B67 File Offset: 0x00014D67
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000CCC RID: 3276
		' (get) Token: 0x06002047 RID: 8263 RVA: 0x00016B70 File Offset: 0x00014D70
		' (set) Token: 0x06002048 RID: 8264 RVA: 0x00016B7A File Offset: 0x00014D7A
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000CCD RID: 3277
		' (get) Token: 0x06002049 RID: 8265 RVA: 0x00016B83 File Offset: 0x00014D83
		' (set) Token: 0x0600204A RID: 8266 RVA: 0x00016B8D File Offset: 0x00014D8D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000CCE RID: 3278
		' (get) Token: 0x0600204B RID: 8267 RVA: 0x00016B96 File Offset: 0x00014D96
		' (set) Token: 0x0600204C RID: 8268 RVA: 0x00016BA0 File Offset: 0x00014DA0
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000CCF RID: 3279
		' (get) Token: 0x0600204D RID: 8269 RVA: 0x00016BA9 File Offset: 0x00014DA9
		' (set) Token: 0x0600204E RID: 8270 RVA: 0x00016BB3 File Offset: 0x00014DB3
		Friend Overridable Property btnJoin As DataGridViewButtonColumn

		' Token: 0x17000CD0 RID: 3280
		' (get) Token: 0x0600204F RID: 8271 RVA: 0x00016BBC File Offset: 0x00014DBC
		' (set) Token: 0x06002050 RID: 8272 RVA: 0x00016BC6 File Offset: 0x00014DC6
		Friend Overridable Property btnFollow As DataGridViewButtonColumn

		' Token: 0x17000CD1 RID: 3281
		' (get) Token: 0x06002051 RID: 8273 RVA: 0x00016BCF File Offset: 0x00014DCF
		' (set) Token: 0x06002052 RID: 8274 RVA: 0x00016BD9 File Offset: 0x00014DD9
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17000CD2 RID: 3282
		' (get) Token: 0x06002053 RID: 8275 RVA: 0x00016BE2 File Offset: 0x00014DE2
		' (set) Token: 0x06002054 RID: 8276 RVA: 0x0014F468 File Offset: 0x0014D668
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

		' Token: 0x17000CD3 RID: 3283
		' (get) Token: 0x06002055 RID: 8277 RVA: 0x00016BEC File Offset: 0x00014DEC
		' (set) Token: 0x06002056 RID: 8278 RVA: 0x00016BF6 File Offset: 0x00014DF6
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17000CD4 RID: 3284
		' (get) Token: 0x06002057 RID: 8279 RVA: 0x00016BFF File Offset: 0x00014DFF
		' (set) Token: 0x06002058 RID: 8280 RVA: 0x00016C09 File Offset: 0x00014E09
		Friend Overridable Property Label8 As Label

		' Token: 0x17000CD5 RID: 3285
		' (get) Token: 0x06002059 RID: 8281 RVA: 0x00016C12 File Offset: 0x00014E12
		' (set) Token: 0x0600205A RID: 8282 RVA: 0x0014F4AC File Offset: 0x0014D6AC
		Private _DataGridView3 As DataGridView
		Friend Overridable Property DataGridView3 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView3_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView3_KeyDown
				Dim dataGridView As DataGridView = Me._DataGridView3
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._DataGridView3 = value
				dataGridView = Me._DataGridView3
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000CD6 RID: 3286
		' (get) Token: 0x0600205B RID: 8283 RVA: 0x00016C1C File Offset: 0x00014E1C
		' (set) Token: 0x0600205C RID: 8284 RVA: 0x00016C26 File Offset: 0x00014E26
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17000CD7 RID: 3287
		' (get) Token: 0x0600205D RID: 8285 RVA: 0x00016C2F File Offset: 0x00014E2F
		' (set) Token: 0x0600205E RID: 8286 RVA: 0x00016C39 File Offset: 0x00014E39
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17000CD8 RID: 3288
		' (get) Token: 0x0600205F RID: 8287 RVA: 0x00016C42 File Offset: 0x00014E42
		' (set) Token: 0x06002060 RID: 8288 RVA: 0x00016C4C File Offset: 0x00014E4C
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17000CD9 RID: 3289
		' (get) Token: 0x06002061 RID: 8289 RVA: 0x00016C55 File Offset: 0x00014E55
		' (set) Token: 0x06002062 RID: 8290 RVA: 0x00016C5F File Offset: 0x00014E5F
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17000CDA RID: 3290
		' (get) Token: 0x06002063 RID: 8291 RVA: 0x00016C68 File Offset: 0x00014E68
		' (set) Token: 0x06002064 RID: 8292 RVA: 0x00016C72 File Offset: 0x00014E72
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17000CDB RID: 3291
		' (get) Token: 0x06002065 RID: 8293 RVA: 0x00016C7B File Offset: 0x00014E7B
		' (set) Token: 0x06002066 RID: 8294 RVA: 0x00016C85 File Offset: 0x00014E85
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17000CDC RID: 3292
		' (get) Token: 0x06002067 RID: 8295 RVA: 0x00016C8E File Offset: 0x00014E8E
		' (set) Token: 0x06002068 RID: 8296 RVA: 0x00016C98 File Offset: 0x00014E98
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17000CDD RID: 3293
		' (get) Token: 0x06002069 RID: 8297 RVA: 0x00016CA1 File Offset: 0x00014EA1
		' (set) Token: 0x0600206A RID: 8298 RVA: 0x00016CAB File Offset: 0x00014EAB
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17000CDE RID: 3294
		' (get) Token: 0x0600206B RID: 8299 RVA: 0x00016CB4 File Offset: 0x00014EB4
		' (set) Token: 0x0600206C RID: 8300 RVA: 0x00016CBE File Offset: 0x00014EBE
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17000CDF RID: 3295
		' (get) Token: 0x0600206D RID: 8301 RVA: 0x00016CC7 File Offset: 0x00014EC7
		' (set) Token: 0x0600206E RID: 8302 RVA: 0x00016CD1 File Offset: 0x00014ED1
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17000CE0 RID: 3296
		' (get) Token: 0x0600206F RID: 8303 RVA: 0x00016CDA File Offset: 0x00014EDA
		' (set) Token: 0x06002070 RID: 8304 RVA: 0x00016CE4 File Offset: 0x00014EE4
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17000CE1 RID: 3297
		' (get) Token: 0x06002071 RID: 8305 RVA: 0x00016CED File Offset: 0x00014EED
		' (set) Token: 0x06002072 RID: 8306 RVA: 0x00016CF7 File Offset: 0x00014EF7
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17000CE2 RID: 3298
		' (get) Token: 0x06002073 RID: 8307 RVA: 0x00016D00 File Offset: 0x00014F00
		' (set) Token: 0x06002074 RID: 8308 RVA: 0x00016D0A File Offset: 0x00014F0A
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17000CE3 RID: 3299
		' (get) Token: 0x06002075 RID: 8309 RVA: 0x00016D13 File Offset: 0x00014F13
		' (set) Token: 0x06002076 RID: 8310 RVA: 0x00016D1D File Offset: 0x00014F1D
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000CE4 RID: 3300
		' (get) Token: 0x06002077 RID: 8311 RVA: 0x00016D26 File Offset: 0x00014F26
		' (set) Token: 0x06002078 RID: 8312 RVA: 0x00016D30 File Offset: 0x00014F30
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000CE5 RID: 3301
		' (get) Token: 0x06002079 RID: 8313 RVA: 0x00016D39 File Offset: 0x00014F39
		' (set) Token: 0x0600207A RID: 8314 RVA: 0x00016D43 File Offset: 0x00014F43
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17000CE6 RID: 3302
		' (get) Token: 0x0600207B RID: 8315 RVA: 0x00016D4C File Offset: 0x00014F4C
		' (set) Token: 0x0600207C RID: 8316 RVA: 0x00016D56 File Offset: 0x00014F56
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000CE7 RID: 3303
		' (get) Token: 0x0600207D RID: 8317 RVA: 0x00016D5F File Offset: 0x00014F5F
		' (set) Token: 0x0600207E RID: 8318 RVA: 0x00016D69 File Offset: 0x00014F69
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17000CE8 RID: 3304
		' (get) Token: 0x0600207F RID: 8319 RVA: 0x00016D72 File Offset: 0x00014F72
		' (set) Token: 0x06002080 RID: 8320 RVA: 0x00016D7C File Offset: 0x00014F7C
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17000CE9 RID: 3305
		' (get) Token: 0x06002081 RID: 8321 RVA: 0x00016D85 File Offset: 0x00014F85
		' (set) Token: 0x06002082 RID: 8322 RVA: 0x00016D8F File Offset: 0x00014F8F
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17000CEA RID: 3306
		' (get) Token: 0x06002083 RID: 8323 RVA: 0x00016D98 File Offset: 0x00014F98
		' (set) Token: 0x06002084 RID: 8324 RVA: 0x00016DA2 File Offset: 0x00014FA2
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17000CEB RID: 3307
		' (get) Token: 0x06002085 RID: 8325 RVA: 0x00016DAB File Offset: 0x00014FAB
		' (set) Token: 0x06002086 RID: 8326 RVA: 0x00016DB5 File Offset: 0x00014FB5
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17000CEC RID: 3308
		' (get) Token: 0x06002087 RID: 8327 RVA: 0x00016DBE File Offset: 0x00014FBE
		' (set) Token: 0x06002088 RID: 8328 RVA: 0x00016DC8 File Offset: 0x00014FC8
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17000CED RID: 3309
		' (get) Token: 0x06002089 RID: 8329 RVA: 0x00016DD1 File Offset: 0x00014FD1
		' (set) Token: 0x0600208A RID: 8330 RVA: 0x00016DDB File Offset: 0x00014FDB
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17000CEE RID: 3310
		' (get) Token: 0x0600208B RID: 8331 RVA: 0x00016DE4 File Offset: 0x00014FE4
		' (set) Token: 0x0600208C RID: 8332 RVA: 0x00016DEE File Offset: 0x00014FEE
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17000CEF RID: 3311
		' (get) Token: 0x0600208D RID: 8333 RVA: 0x00016DF7 File Offset: 0x00014FF7
		' (set) Token: 0x0600208E RID: 8334 RVA: 0x00016E01 File Offset: 0x00015001
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17000CF0 RID: 3312
		' (get) Token: 0x0600208F RID: 8335 RVA: 0x00016E0A File Offset: 0x0001500A
		' (set) Token: 0x06002090 RID: 8336 RVA: 0x00016E14 File Offset: 0x00015014
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17000CF1 RID: 3313
		' (get) Token: 0x06002091 RID: 8337 RVA: 0x00016E1D File Offset: 0x0001501D
		' (set) Token: 0x06002092 RID: 8338 RVA: 0x00016E27 File Offset: 0x00015027
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17000CF2 RID: 3314
		' (get) Token: 0x06002093 RID: 8339 RVA: 0x00016E30 File Offset: 0x00015030
		' (set) Token: 0x06002094 RID: 8340 RVA: 0x00016E3A File Offset: 0x0001503A
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17000CF3 RID: 3315
		' (get) Token: 0x06002095 RID: 8341 RVA: 0x00016E43 File Offset: 0x00015043
		' (set) Token: 0x06002096 RID: 8342 RVA: 0x00016E4D File Offset: 0x0001504D
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17000CF4 RID: 3316
		' (get) Token: 0x06002097 RID: 8343 RVA: 0x00016E56 File Offset: 0x00015056
		' (set) Token: 0x06002098 RID: 8344 RVA: 0x00016E60 File Offset: 0x00015060
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17000CF5 RID: 3317
		' (get) Token: 0x06002099 RID: 8345 RVA: 0x00016E69 File Offset: 0x00015069
		' (set) Token: 0x0600209A RID: 8346 RVA: 0x00016E73 File Offset: 0x00015073
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17000CF6 RID: 3318
		' (get) Token: 0x0600209B RID: 8347 RVA: 0x00016E7C File Offset: 0x0001507C
		' (set) Token: 0x0600209C RID: 8348 RVA: 0x00016E86 File Offset: 0x00015086
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17000CF7 RID: 3319
		' (get) Token: 0x0600209D RID: 8349 RVA: 0x00016E8F File Offset: 0x0001508F
		' (set) Token: 0x0600209E RID: 8350 RVA: 0x00016E99 File Offset: 0x00015099
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17000CF8 RID: 3320
		' (get) Token: 0x0600209F RID: 8351 RVA: 0x00016EA2 File Offset: 0x000150A2
		' (set) Token: 0x060020A0 RID: 8352 RVA: 0x00016EAC File Offset: 0x000150AC
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17000CF9 RID: 3321
		' (get) Token: 0x060020A1 RID: 8353 RVA: 0x00016EB5 File Offset: 0x000150B5
		' (set) Token: 0x060020A2 RID: 8354 RVA: 0x00016EBF File Offset: 0x000150BF
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17000CFA RID: 3322
		' (get) Token: 0x060020A3 RID: 8355 RVA: 0x00016EC8 File Offset: 0x000150C8
		' (set) Token: 0x060020A4 RID: 8356 RVA: 0x00016ED2 File Offset: 0x000150D2
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17000CFB RID: 3323
		' (get) Token: 0x060020A5 RID: 8357 RVA: 0x00016EDB File Offset: 0x000150DB
		' (set) Token: 0x060020A6 RID: 8358 RVA: 0x00016EE5 File Offset: 0x000150E5
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17000CFC RID: 3324
		' (get) Token: 0x060020A7 RID: 8359 RVA: 0x00016EEE File Offset: 0x000150EE
		' (set) Token: 0x060020A8 RID: 8360 RVA: 0x00016EF8 File Offset: 0x000150F8
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17000CFD RID: 3325
		' (get) Token: 0x060020A9 RID: 8361 RVA: 0x00016F01 File Offset: 0x00015101
		' (set) Token: 0x060020AA RID: 8362 RVA: 0x00016F0B File Offset: 0x0001510B
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17000CFE RID: 3326
		' (get) Token: 0x060020AB RID: 8363 RVA: 0x00016F14 File Offset: 0x00015114
		' (set) Token: 0x060020AC RID: 8364 RVA: 0x00016F1E File Offset: 0x0001511E
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17000CFF RID: 3327
		' (get) Token: 0x060020AD RID: 8365 RVA: 0x00016F27 File Offset: 0x00015127
		' (set) Token: 0x060020AE RID: 8366 RVA: 0x00016F31 File Offset: 0x00015131
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17000D00 RID: 3328
		' (get) Token: 0x060020AF RID: 8367 RVA: 0x00016F3A File Offset: 0x0001513A
		' (set) Token: 0x060020B0 RID: 8368 RVA: 0x00016F44 File Offset: 0x00015144
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17000D01 RID: 3329
		' (get) Token: 0x060020B1 RID: 8369 RVA: 0x00016F4D File Offset: 0x0001514D
		' (set) Token: 0x060020B2 RID: 8370 RVA: 0x00016F57 File Offset: 0x00015157
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17000D02 RID: 3330
		' (get) Token: 0x060020B3 RID: 8371 RVA: 0x00016F60 File Offset: 0x00015160
		' (set) Token: 0x060020B4 RID: 8372 RVA: 0x00016F6A File Offset: 0x0001516A
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17000D03 RID: 3331
		' (get) Token: 0x060020B5 RID: 8373 RVA: 0x00016F73 File Offset: 0x00015173
		' (set) Token: 0x060020B6 RID: 8374 RVA: 0x00016F7D File Offset: 0x0001517D
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17000D04 RID: 3332
		' (get) Token: 0x060020B7 RID: 8375 RVA: 0x00016F86 File Offset: 0x00015186
		' (set) Token: 0x060020B8 RID: 8376 RVA: 0x00016F90 File Offset: 0x00015190
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17000D05 RID: 3333
		' (get) Token: 0x060020B9 RID: 8377 RVA: 0x00016F99 File Offset: 0x00015199
		' (set) Token: 0x060020BA RID: 8378 RVA: 0x00016FA3 File Offset: 0x000151A3
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17000D06 RID: 3334
		' (get) Token: 0x060020BB RID: 8379 RVA: 0x00016FAC File Offset: 0x000151AC
		' (set) Token: 0x060020BC RID: 8380 RVA: 0x00016FB6 File Offset: 0x000151B6
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x17000D07 RID: 3335
		' (get) Token: 0x060020BD RID: 8381 RVA: 0x00016FBF File Offset: 0x000151BF
		' (set) Token: 0x060020BE RID: 8382 RVA: 0x0014F50C File Offset: 0x0014D70C
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D08 RID: 3336
		' (get) Token: 0x060020BF RID: 8383 RVA: 0x00016FC9 File Offset: 0x000151C9
		' (set) Token: 0x060020C0 RID: 8384 RVA: 0x00016FD3 File Offset: 0x000151D3
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17000D09 RID: 3337
		' (get) Token: 0x060020C1 RID: 8385 RVA: 0x00016FDC File Offset: 0x000151DC
		' (set) Token: 0x060020C2 RID: 8386 RVA: 0x00016FE6 File Offset: 0x000151E6
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17000D0A RID: 3338
		' (get) Token: 0x060020C3 RID: 8387 RVA: 0x00016FEF File Offset: 0x000151EF
		' (set) Token: 0x060020C4 RID: 8388 RVA: 0x00016FF9 File Offset: 0x000151F9
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17000D0B RID: 3339
		' (get) Token: 0x060020C5 RID: 8389 RVA: 0x00017002 File Offset: 0x00015202
		' (set) Token: 0x060020C6 RID: 8390 RVA: 0x0001700C File Offset: 0x0001520C
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17000D0C RID: 3340
		' (get) Token: 0x060020C7 RID: 8391 RVA: 0x00017015 File Offset: 0x00015215
		' (set) Token: 0x060020C8 RID: 8392 RVA: 0x0001701F File Offset: 0x0001521F
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17000D0D RID: 3341
		' (get) Token: 0x060020C9 RID: 8393 RVA: 0x00017028 File Offset: 0x00015228
		' (set) Token: 0x060020CA RID: 8394 RVA: 0x00017032 File Offset: 0x00015232
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17000D0E RID: 3342
		' (get) Token: 0x060020CB RID: 8395 RVA: 0x0001703B File Offset: 0x0001523B
		' (set) Token: 0x060020CC RID: 8396 RVA: 0x00017045 File Offset: 0x00015245
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17000D0F RID: 3343
		' (get) Token: 0x060020CD RID: 8397 RVA: 0x0001704E File Offset: 0x0001524E
		' (set) Token: 0x060020CE RID: 8398 RVA: 0x00017058 File Offset: 0x00015258
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17000D10 RID: 3344
		' (get) Token: 0x060020CF RID: 8399 RVA: 0x00017061 File Offset: 0x00015261
		' (set) Token: 0x060020D0 RID: 8400 RVA: 0x0001706B File Offset: 0x0001526B
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17000D11 RID: 3345
		' (get) Token: 0x060020D1 RID: 8401 RVA: 0x00017074 File Offset: 0x00015274
		' (set) Token: 0x060020D2 RID: 8402 RVA: 0x0001707E File Offset: 0x0001527E
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17000D12 RID: 3346
		' (get) Token: 0x060020D3 RID: 8403 RVA: 0x00017087 File Offset: 0x00015287
		' (set) Token: 0x060020D4 RID: 8404 RVA: 0x00017091 File Offset: 0x00015291
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x17000D13 RID: 3347
		' (get) Token: 0x060020D5 RID: 8405 RVA: 0x0001709A File Offset: 0x0001529A
		' (set) Token: 0x060020D6 RID: 8406 RVA: 0x000170A4 File Offset: 0x000152A4
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x17000D14 RID: 3348
		' (get) Token: 0x060020D7 RID: 8407 RVA: 0x000170AD File Offset: 0x000152AD
		' (set) Token: 0x060020D8 RID: 8408 RVA: 0x000170B7 File Offset: 0x000152B7
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x17000D15 RID: 3349
		' (get) Token: 0x060020D9 RID: 8409 RVA: 0x000170C0 File Offset: 0x000152C0
		' (set) Token: 0x060020DA RID: 8410 RVA: 0x000170CA File Offset: 0x000152CA
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x17000D16 RID: 3350
		' (get) Token: 0x060020DB RID: 8411 RVA: 0x000170D3 File Offset: 0x000152D3
		' (set) Token: 0x060020DC RID: 8412 RVA: 0x000170DD File Offset: 0x000152DD
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x17000D17 RID: 3351
		' (get) Token: 0x060020DD RID: 8413 RVA: 0x000170E6 File Offset: 0x000152E6
		' (set) Token: 0x060020DE RID: 8414 RVA: 0x000170F0 File Offset: 0x000152F0
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000D18 RID: 3352
		' (get) Token: 0x060020DF RID: 8415 RVA: 0x000170F9 File Offset: 0x000152F9
		' (set) Token: 0x060020E0 RID: 8416 RVA: 0x00017103 File Offset: 0x00015303
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17000D19 RID: 3353
		' (get) Token: 0x060020E1 RID: 8417 RVA: 0x0001710C File Offset: 0x0001530C
		' (set) Token: 0x060020E2 RID: 8418 RVA: 0x00017116 File Offset: 0x00015316
		Friend Overridable Property DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn

		' Token: 0x17000D1A RID: 3354
		' (get) Token: 0x060020E3 RID: 8419 RVA: 0x0001711F File Offset: 0x0001531F
		' (set) Token: 0x060020E4 RID: 8420 RVA: 0x00017129 File Offset: 0x00015329
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17000D1B RID: 3355
		' (get) Token: 0x060020E5 RID: 8421 RVA: 0x00017132 File Offset: 0x00015332
		' (set) Token: 0x060020E6 RID: 8422 RVA: 0x0001713C File Offset: 0x0001533C
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x17000D1C RID: 3356
		' (get) Token: 0x060020E7 RID: 8423 RVA: 0x00017145 File Offset: 0x00015345
		' (set) Token: 0x060020E8 RID: 8424 RVA: 0x0001714F File Offset: 0x0001534F
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x17000D1D RID: 3357
		' (get) Token: 0x060020E9 RID: 8425 RVA: 0x00017158 File Offset: 0x00015358
		' (set) Token: 0x060020EA RID: 8426 RVA: 0x00017162 File Offset: 0x00015362
		Friend Overridable Property DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn

		' Token: 0x17000D1E RID: 3358
		' (get) Token: 0x060020EB RID: 8427 RVA: 0x0001716B File Offset: 0x0001536B
		' (set) Token: 0x060020EC RID: 8428 RVA: 0x00017175 File Offset: 0x00015375
		Friend Overridable Property DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn

		' Token: 0x17000D1F RID: 3359
		' (get) Token: 0x060020ED RID: 8429 RVA: 0x0001717E File Offset: 0x0001537E
		' (set) Token: 0x060020EE RID: 8430 RVA: 0x00017188 File Offset: 0x00015388
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17000D20 RID: 3360
		' (get) Token: 0x060020EF RID: 8431 RVA: 0x00017191 File Offset: 0x00015391
		' (set) Token: 0x060020F0 RID: 8432 RVA: 0x0001719B File Offset: 0x0001539B
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17000D21 RID: 3361
		' (get) Token: 0x060020F1 RID: 8433 RVA: 0x000171A4 File Offset: 0x000153A4
		' (set) Token: 0x060020F2 RID: 8434 RVA: 0x000171AE File Offset: 0x000153AE
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000D22 RID: 3362
		' (get) Token: 0x060020F3 RID: 8435 RVA: 0x000171B7 File Offset: 0x000153B7
		' (set) Token: 0x060020F4 RID: 8436 RVA: 0x000171C1 File Offset: 0x000153C1
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x17000D23 RID: 3363
		' (get) Token: 0x060020F5 RID: 8437 RVA: 0x000171CA File Offset: 0x000153CA
		' (set) Token: 0x060020F6 RID: 8438 RVA: 0x000171D4 File Offset: 0x000153D4
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000D24 RID: 3364
		' (get) Token: 0x060020F7 RID: 8439 RVA: 0x000171DD File Offset: 0x000153DD
		' (set) Token: 0x060020F8 RID: 8440 RVA: 0x000171E7 File Offset: 0x000153E7
		Friend Overridable Property DataGridViewTextBoxColumn58 As DataGridViewTextBoxColumn

		' Token: 0x17000D25 RID: 3365
		' (get) Token: 0x060020F9 RID: 8441 RVA: 0x000171F0 File Offset: 0x000153F0
		' (set) Token: 0x060020FA RID: 8442 RVA: 0x000171FA File Offset: 0x000153FA
		Friend Overridable Property DataGridViewTextBoxColumn59 As DataGridViewTextBoxColumn

		' Token: 0x17000D26 RID: 3366
		' (get) Token: 0x060020FB RID: 8443 RVA: 0x00017203 File Offset: 0x00015403
		' (set) Token: 0x060020FC RID: 8444 RVA: 0x0001720D File Offset: 0x0001540D
		Friend Overridable Property DataGridViewTextBoxColumn60 As DataGridViewTextBoxColumn

		' Token: 0x17000D27 RID: 3367
		' (get) Token: 0x060020FD RID: 8445 RVA: 0x00017216 File Offset: 0x00015416
		' (set) Token: 0x060020FE RID: 8446 RVA: 0x00017220 File Offset: 0x00015420
		Friend Overridable Property DataGridViewTextBoxColumn61 As DataGridViewTextBoxColumn

		' Token: 0x17000D28 RID: 3368
		' (get) Token: 0x060020FF RID: 8447 RVA: 0x00017229 File Offset: 0x00015429
		' (set) Token: 0x06002100 RID: 8448 RVA: 0x00017233 File Offset: 0x00015433
		Friend Overridable Property DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn

		' Token: 0x17000D29 RID: 3369
		' (get) Token: 0x06002101 RID: 8449 RVA: 0x0001723C File Offset: 0x0001543C
		' (set) Token: 0x06002102 RID: 8450 RVA: 0x00017246 File Offset: 0x00015446
		Friend Overridable Property DataGridViewTextBoxColumn63 As DataGridViewTextBoxColumn

		' Token: 0x17000D2A RID: 3370
		' (get) Token: 0x06002103 RID: 8451 RVA: 0x0001724F File Offset: 0x0001544F
		' (set) Token: 0x06002104 RID: 8452 RVA: 0x00017259 File Offset: 0x00015459
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17000D2B RID: 3371
		' (get) Token: 0x06002105 RID: 8453 RVA: 0x00017262 File Offset: 0x00015462
		' (set) Token: 0x06002106 RID: 8454 RVA: 0x0001726C File Offset: 0x0001546C
		Friend Overridable Property DataGridViewTextBoxColumn65 As DataGridViewTextBoxColumn

		' Token: 0x17000D2C RID: 3372
		' (get) Token: 0x06002107 RID: 8455 RVA: 0x00017275 File Offset: 0x00015475
		' (set) Token: 0x06002108 RID: 8456 RVA: 0x0001727F File Offset: 0x0001547F
		Friend Overridable Property DataGridViewTextBoxColumn66 As DataGridViewTextBoxColumn

		' Token: 0x17000D2D RID: 3373
		' (get) Token: 0x06002109 RID: 8457 RVA: 0x00017288 File Offset: 0x00015488
		' (set) Token: 0x0600210A RID: 8458 RVA: 0x00017292 File Offset: 0x00015492
		Friend Overridable Property DataGridViewTextBoxColumn67 As DataGridViewTextBoxColumn

		' Token: 0x17000D2E RID: 3374
		' (get) Token: 0x0600210B RID: 8459 RVA: 0x0001729B File Offset: 0x0001549B
		' (set) Token: 0x0600210C RID: 8460 RVA: 0x000172A5 File Offset: 0x000154A5
		Friend Overridable Property DataGridViewTextBoxColumn68 As DataGridViewTextBoxColumn

		' Token: 0x17000D2F RID: 3375
		' (get) Token: 0x0600210D RID: 8461 RVA: 0x000172AE File Offset: 0x000154AE
		' (set) Token: 0x0600210E RID: 8462 RVA: 0x000172B8 File Offset: 0x000154B8
		Friend Overridable Property DataGridViewTextBoxColumn69 As DataGridViewTextBoxColumn

		' Token: 0x17000D30 RID: 3376
		' (get) Token: 0x0600210F RID: 8463 RVA: 0x000172C1 File Offset: 0x000154C1
		' (set) Token: 0x06002110 RID: 8464 RVA: 0x000172CB File Offset: 0x000154CB
		Friend Overridable Property DataGridViewTextBoxColumn70 As DataGridViewTextBoxColumn

		' Token: 0x17000D31 RID: 3377
		' (get) Token: 0x06002111 RID: 8465 RVA: 0x000172D4 File Offset: 0x000154D4
		' (set) Token: 0x06002112 RID: 8466 RVA: 0x000172DE File Offset: 0x000154DE
		Friend Overridable Property DataGridViewTextBoxColumn71 As DataGridViewTextBoxColumn

		' Token: 0x17000D32 RID: 3378
		' (get) Token: 0x06002113 RID: 8467 RVA: 0x000172E7 File Offset: 0x000154E7
		' (set) Token: 0x06002114 RID: 8468 RVA: 0x000172F1 File Offset: 0x000154F1
		Friend Overridable Property DataGridViewTextBoxColumn72 As DataGridViewTextBoxColumn

		' Token: 0x17000D33 RID: 3379
		' (get) Token: 0x06002115 RID: 8469 RVA: 0x000172FA File Offset: 0x000154FA
		' (set) Token: 0x06002116 RID: 8470 RVA: 0x00017304 File Offset: 0x00015504
		Friend Overridable Property DataGridViewTextBoxColumn73 As DataGridViewTextBoxColumn

		' Token: 0x17000D34 RID: 3380
		' (get) Token: 0x06002117 RID: 8471 RVA: 0x0001730D File Offset: 0x0001550D
		' (set) Token: 0x06002118 RID: 8472 RVA: 0x00017317 File Offset: 0x00015517
		Friend Overridable Property DataGridViewTextBoxColumn74 As DataGridViewTextBoxColumn

		' Token: 0x17000D35 RID: 3381
		' (get) Token: 0x06002119 RID: 8473 RVA: 0x00017320 File Offset: 0x00015520
		' (set) Token: 0x0600211A RID: 8474 RVA: 0x0001732A File Offset: 0x0001552A
		Friend Overridable Property DataGridViewTextBoxColumn75 As DataGridViewTextBoxColumn

		' Token: 0x17000D36 RID: 3382
		' (get) Token: 0x0600211B RID: 8475 RVA: 0x00017333 File Offset: 0x00015533
		' (set) Token: 0x0600211C RID: 8476 RVA: 0x0001733D File Offset: 0x0001553D
		Friend Overridable Property lbl_CustomerID As Label

		' Token: 0x0600211D RID: 8477 RVA: 0x0014F56C File Offset: 0x0014D76C
		Private Sub frmGSheet_Report_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
			If flag Then
				Me.btnOffline_Online.Visible = False
			Else
				Me.btnOffline_Online.Visible = True
			End If
		End Sub

		' Token: 0x0600211E RID: 8478 RVA: 0x0014F5F4 File Offset: 0x0014D7F4
		Private Sub AddFollowButtonColumn()
			Dim flag As Boolean = Not Me.DataGridView1.Columns.Contains("btnJoin")
			If flag Then
				Dim dataGridViewButtonColumn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
				dataGridViewButtonColumn.Name = "btnJoin"
				dataGridViewButtonColumn.HeaderText = "Join"
				dataGridViewButtonColumn.Text = "Join"
				dataGridViewButtonColumn.UseColumnTextForButtonValue = True
				Me.DataGridView1.Columns.Add(dataGridViewButtonColumn)
			End If
			Dim flag2 As Boolean = Not Me.DataGridView1.Columns.Contains("btnFollow")
			If flag2 Then
				Dim dataGridViewButtonColumn2 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
				dataGridViewButtonColumn2.Name = "btnFollow"
				dataGridViewButtonColumn2.HeaderText = "Follow"
				dataGridViewButtonColumn2.Text = "Follow"
				dataGridViewButtonColumn2.UseColumnTextForButtonValue = True
				Me.DataGridView1.Columns.Add(dataGridViewButtonColumn2)
			End If
		End Sub

		' Token: 0x0600211F RID: 8479 RVA: 0x0014F6C8 File Offset: 0x0014D8C8
		Private Sub LoadCustomerSupportLogs(Optional statusFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag Then
						text += "WHERE Join_user = @join_user "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@join_user", Me.lblUser.Text)
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002120 RID: 8480 RVA: 0x0014F968 File Offset: 0x0014DB68
		Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = e.RowIndex < 0
			If Not flag Then
				Try
					Dim text As String = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString()
					Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnJoin").Index
					If flag2 Then
						Dim flag3 As Boolean = Operators.CompareString(text, "Open", False) = 0
						If flag3 Then
							e.Value = "Join"
							e.CellStyle.BackColor = Global.System.Drawing.Color.LightGreen
						Else
							e.Value = "Disabled"
							e.CellStyle.BackColor = Global.System.Drawing.Color.LightGray
						End If
					End If
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x06002121 RID: 8481 RVA: 0x00017346 File Offset: 0x00015546
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x06002122 RID: 8482 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x06002123 RID: 8483 RVA: 0x0014FA54 File Offset: 0x0014DC54
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count = 0
				If flag Then
					MessageBox.Show("Please select a row.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag2 As Boolean = Me.DataGridView1.Rows.Count > 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
						MyProject.Forms.frmCustomer.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomer.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtAddress.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCustomer.txtCity.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCustomer.cmbState.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtZipCode.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCustomer.txtContactNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtPhNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtGSTIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCustomer.txtRemarks.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmCustomer.txtpermentAddress.Text = dataGridViewRow.Cells(11).Value.ToString() + ", Mob:" + dataGridViewRow.Cells(19).Value.ToString()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002124 RID: 8484 RVA: 0x0014FD5C File Offset: 0x0014DF5C
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag Then
						text += "WHERE Status = @status OR Join_user = @join_user AND support_token_no LIKE @tokenNo "
					Else
						text += "WHERE support_token_no LIKE @tokenNo "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@status", "Open")
							sqlCommand.Parameters.AddWithValue("@join_user", Me.lblUser.Text)
						End If
						sqlCommand.Parameters.AddWithValue("@tokenNo", "%" + Me.txtTokenNo.Text + "%")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002125 RID: 8485 RVA: 0x0015004C File Offset: 0x0014E24C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT LogID,support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm WHERE LogTimestamp BETWEEN @d1 AND @d2 "
					Dim flag As Boolean = Not String.IsNullOrWhiteSpace(Me.txtTokenNo.Text)
					If flag Then
						text += "AND support_token_no LIKE @token "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
						sqlCommand.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date].AddDays(1.0).AddSeconds(-1.0))
						Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(Me.txtTokenNo.Text)
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@token", Me.txtTokenNo.Text + "%")
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002126 RID: 8486 RVA: 0x0015034C File Offset: 0x0014E54C
		Private Sub rdo_Open_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Open.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Open")
			End If
		End Sub

		' Token: 0x06002127 RID: 8487 RVA: 0x00150378 File Offset: 0x0014E578
		Private Sub rdo_Process_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Process.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Process")
			End If
		End Sub

		' Token: 0x06002128 RID: 8488 RVA: 0x001503A4 File Offset: 0x0014E5A4
		Private Sub rdo_Closed_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Closed.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Closed")
			End If
		End Sub

		' Token: 0x06002129 RID: 8489 RVA: 0x001503D0 File Offset: 0x0014E5D0
		Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Check Internet Connection!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					Dim text As String = Path.Combine(Application.StartupPath, "credentials_.json")
					Dim googleCredential As GoogleCredential
					Using fileStream As FileStream = New FileStream(text, FileMode.Open, FileAccess.Read)
						googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(New String() { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets })
					End Using
					Dim sheetsService As SheetsService = New SheetsService(New BaseClientService.Initializer() With { .HttpClientInitializer = googleCredential, .ApplicationName = "Customer Support Logger" })
					Dim text2 As String = "10Jp2rmH0KQ-6mNWHH3fTVX1eKHPnsipglEwlex9LyHg"
					Dim text3 As String = "Form Responses 1"
					Dim text4 As String = text3 + "!A2:M"
					Dim getRequest As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](text2, text4)
					Dim valueRange As ValueRange = getRequest.Execute()
					Dim values As IList(Of IList(Of Object)) = valueRange.Values
					Dim flag2 As Boolean = values Is Nothing OrElse values.Count = 0
					If flag2 Then
						MessageBox.Show("No rows found in Google Sheet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim num As Integer = values.Count - 1
							For i As Integer = 0 To num
								Dim list As IList(Of Object) = values(i)
								Dim flag3 As Boolean = list.Count >= 13
								If flag3 Then
									Dim text5 As String = list(8).ToString()
									Dim flag4 As Boolean = Operators.CompareString(text5, "Open", False) = 0
									If flag4 Then
										Dim sqlCommand As SqlCommand = New SqlCommand("INSERT INTO CustomerSupportForm " & vbCrLf & "                            (LogTimestamp, support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, " & vbCrLf & "                            CurrentIssue, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress) " & vbCrLf & "                            VALUES (@LogTimestamp,@support_token_no,@CustomerName,@RegisteredMobileNumber,@CallingNumber," & vbCrLf & "                            @CurrentIssue,@SoftwareName,@SoftwareValidity,@Status,@Remark,@Feedback,@Rating,@EmailAddress)", sqlConnection)
										sqlCommand.Parameters.AddWithValue("@LogTimestamp", RuntimeHelpers.GetObjectValue(If(String.IsNullOrEmpty(list(0).ToString()), DBNull.Value, Convert.ToDateTime(list(0).ToString()))))
										sqlCommand.Parameters.AddWithValue("@support_token_no", list(1).ToString())
										sqlCommand.Parameters.AddWithValue("@CustomerName", list(2).ToString())
										sqlCommand.Parameters.AddWithValue("@RegisteredMobileNumber", list(3).ToString())
										sqlCommand.Parameters.AddWithValue("@CallingNumber", list(4).ToString())
										sqlCommand.Parameters.AddWithValue("@CurrentIssue", list(5).ToString())
										sqlCommand.Parameters.AddWithValue("@SoftwareName", list(6).ToString())
										sqlCommand.Parameters.AddWithValue("@SoftwareValidity", RuntimeHelpers.GetObjectValue(If(String.IsNullOrEmpty(list(7).ToString()), DBNull.Value, Convert.ToDateTime(list(7).ToString()))))
										sqlCommand.Parameters.AddWithValue("@Status", list(8).ToString())
										sqlCommand.Parameters.AddWithValue("@Remark", list(9).ToString())
										sqlCommand.Parameters.AddWithValue("@Feedback", list(10).ToString())
										sqlCommand.Parameters.AddWithValue("@Rating", RuntimeHelpers.GetObjectValue(If(String.IsNullOrEmpty(list(11).ToString()), DBNull.Value, Convert.ToInt32(list(11).ToString()))))
										sqlCommand.Parameters.AddWithValue("@EmailAddress", list(12).ToString())
										sqlCommand.ExecuteNonQuery()
										Dim text6 As String = text3 + "!I" + (i + 2).ToString()
										Dim valueRange2 As ValueRange = New ValueRange() With { .Values = New List(Of IList(Of Object))() From { New List(Of Object)() From { "Process" } } }
										Dim updateRequest As SpreadsheetsResource.ValuesResource.UpdateRequest = sheetsService.Spreadsheets.Values.Update(valueRange2, text2, text6)
										updateRequest.ValueInputOption = New SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum?(SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED)
										updateRequest.Execute()
									End If
								End If
							Next
						End Using
						MessageBox.Show("Migration completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.LoadCustomerSupportLogs("")
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error during migration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600212A RID: 8490 RVA: 0x001508C4 File Offset: 0x0014EAC4
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnFollow").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.lbl_Id.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.lbl_tokenid.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.Getdata_Quotation()
				Me.Getdata()
				Dim text As String = dataGridViewRow.Cells(5).Value.ToString()
				Me.lblTokenNo.Text = "Support Token Number : " + dataGridViewRow.Cells(1).Value.ToString()
				Me.lblCurrentIssue.Text = "Problem : " + dataGridViewRow.Cells(3).Value.ToString()
				Dim text2 As String = dataGridViewRow.Cells(5).Value.ToString()
				Dim text3 As String = If((Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)) OrElse String.IsNullOrWhiteSpace(dataGridViewRow.Cells(16).Value.ToString())), "", dataGridViewRow.Cells(16).Value.ToString())
				Dim flag2 As Boolean = Operators.CompareString(text3, "", False) <> 0
				If flag2 Then
					Me.lblNumbers.Text = "Contact Number(s) : " + text2 + " / " + text3
				Else
					Me.lblNumbers.Text = "Contact Number(s) : " + text2
				End If
				Dim text4 As String = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString()
				Dim flag3 As Boolean = String.IsNullOrWhiteSpace(text4)
				If flag3 Then
					MessageBox.Show("Join First ", "Not Allowed for Follow-Up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Return
				End If
				Me.txtRemarks.Text = ""
				Me.LoadCustomerSupportLogs_mobile(text.ToString())
				Me.lblCount.Text = "Total Support Log : " + Conversions.ToString(Me.GetTokenCountByMobile(text.ToString()))
				Me.pnl_FollowUp.Visible = True
			End If
			Dim flag4 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnJoin").Index
			If flag4 Then
				Me.pnl_FollowUp.Visible = False
				Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value))
				Dim text5 As String = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString()
				Dim dialogResult As DialogResult = MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Are you sure you want to Join '", Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value), "'?")), "Join Log", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
				Dim flag5 As Boolean = dialogResult = DialogResult.Yes
				If flag5 Then
					Dim flag6 As Boolean = String.IsNullOrWhiteSpace(text5)
					If flag6 Then
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text6 As String = "UPDATE CustomerSupportForm SET Join_user=@userID, Join_date=GETDATE(), Status='Postpone' WHERE LogID=@logID"
							Using sqlCommand As SqlCommand = New SqlCommand(text6, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@userID", Me.lblUser.Text)
								sqlCommand.Parameters.AddWithValue("@logID", num)
								sqlCommand.ExecuteNonQuery()
							End Using
						End Using
						MessageBox.Show("Successfully joined for ID: " + Conversions.ToString(num))
						Me.LoadCustomerSupportLogs("")
					Else
						MessageBox.Show("This log is already joined by user: " + text5, "Join Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			End If
		End Sub

		' Token: 0x0600212B RID: 8491 RVA: 0x00150D54 File Offset: 0x0014EF54
		Private Sub frmCustomerSupportLog_Dashboard_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.pnl_FollowUp.Visible = False
			End If
		End Sub

		' Token: 0x0600212C RID: 8492 RVA: 0x00150D80 File Offset: 0x0014EF80
		Private Sub btnTokenUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT Status FROM CustomerSupportForm WHERE LogId=@LogId"
					Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@LogId", Me.lbl_Id.Text)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue IsNot Nothing
					If flag Then
						Dim text2 As String = objectValue.ToString()
						Dim flag2 As Boolean = Operators.CompareString(text2, "Closed", False) = 0 OrElse Operators.CompareString(text2, "Closed", False) = 0
						If flag2 Then
							MessageBox.Show("Token " + Me.lbl_tokenid.Text + " is already closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Return
						End If
					End If
				Catch ex As Exception
					MessageBox.Show("Error checking token: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End Try
				Dim flag4 As Boolean = (Strings.Len(Strings.Trim(Me.txtRemarks.Text)) = 0) Or (Me.txtRemarks.Text = Nothing)
				If flag4 Then
					MessageBox.Show("Please enter Remarks. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRemarks.Focus()
				Else
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to Update '" + Me.lbl_Id.Text + "'?", "Update Form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag5 As Boolean = dialogResult = DialogResult.Yes
					If flag5 Then
						Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection2.Open()
							Dim text3 As String = "UPDATE CustomerSupportForm SET Status = 'Process', Remark = @Remark WHERE LogId = @LogId"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text3, sqlConnection2)
								sqlCommand2.Parameters.AddWithValue("@Remark", Me.txtRemarks.Text.Trim())
								sqlCommand2.Parameters.AddWithValue("@LogId", Convert.ToInt32(Me.lbl_Id.Text))
								Dim num As Integer = sqlCommand2.ExecuteNonQuery()
								Me.LoadCustomerSupportLogs("")
								Me.pnl_FollowUp.Visible = False
								MessageBox.Show(num.ToString() + " record(s) updated to Process.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							End Using
						End Using
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600212D RID: 8493 RVA: 0x001510A4 File Offset: 0x0014F2A4
		Private Sub btnClosed_Click(sender As Object, e As EventArgs)
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT Status FROM CustomerSupportForm WHERE LogId=@LogId"
					Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@LogId", Me.lbl_Id.Text)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue IsNot Nothing
					If flag Then
						Dim text2 As String = objectValue.ToString()
						Dim flag2 As Boolean = Operators.CompareString(text2, "Closed", False) = 0 OrElse Operators.CompareString(text2, "Closed_Offline", False) = 0
						If flag2 Then
							MessageBox.Show("Token " + Me.lbl_tokenid.Text + " is already closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Return
						End If
					End If
				Catch ex As Exception
					MessageBox.Show("Error checking token: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End Try
				Dim flag4 As Boolean = (Strings.Len(Strings.Trim(Me.txtRemarks.Text)) = 0) Or (Me.txtRemarks.Text = Nothing)
				If flag4 Then
					MessageBox.Show("Please enter Remarks. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRemarks.Focus()
				Else
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to Closed Log '" + Me.lbl_Id.Text + "'?", "Close Log", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag5 As Boolean = dialogResult = DialogResult.Yes
					If flag5 Then
						Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection2.Open()
							Dim text3 As String = "UPDATE CustomerSupportForm SET Status = 'Closed', Close_date=GETDATE(), Remark = @Remark WHERE LogId = @LogId"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text3, sqlConnection2)
								sqlCommand2.Parameters.AddWithValue("@Remark", Me.txtRemarks.Text.Trim())
								sqlCommand2.Parameters.AddWithValue("@LogId", Convert.ToInt32(Me.lbl_Id.Text))
								Dim num As Integer = sqlCommand2.ExecuteNonQuery()
								Me.LoadCustomerSupportLogs("")
								Me.pnl_FollowUp.Visible = False
								MessageBox.Show(num.ToString() + " record(s) updated to Closed.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							End Using
						End Using
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600212E RID: 8494 RVA: 0x001513C8 File Offset: 0x0014F5C8
		Private Sub LoadCustomerSupportLogs_mobile(Optional mobileFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, SoftwareName, CustomerName, RegisteredMobileNumber, LogTimestamp, CurrentIssue, Remark, Close_date, Feedback, Rating FROM CustomerSupportForm WHERE Status in ('Closed','Closed_Offline') "
					Dim flag As Boolean = Operators.CompareString(mobileFilter, "", False) <> 0
					If flag Then
						text += "AND RegisteredMobileNumber = @mobile "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag2 As Boolean = Operators.CompareString(mobileFilter, "", False) <> 0
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@mobile", mobileFilter)
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView2.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView2.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600212F RID: 8495 RVA: 0x001515FC File Offset: 0x0014F7FC
		Private Function GetTokenCountByMobile(mobile As String) As Integer
			Dim num As Integer = 0
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT COUNT(support_token_no) AS TokenCount FROM CustomerSupportForm WHERE RegisteredMobileNumber = @mobile"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@mobile", mobile)
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
						Dim flag As Boolean = objectValue IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue))
						If flag Then
							num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue))
						End If
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
			Return num
		End Function

		' Token: 0x06002130 RID: 8496 RVA: 0x0001737C File Offset: 0x0001557C
		Private Sub lnkPanle_CLose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.pnl_FollowUp.Visible = False
			Me.txtRemarks.Text = ""
		End Sub

		' Token: 0x06002131 RID: 8497 RVA: 0x001516F4 File Offset: 0x0014F8F4
		Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag Then
						text += "WHERE Status = @status OR Join_user = @join_user AND RegisteredMobileNumber LIKE @RegisteredMobileNumber "
					Else
						text += "WHERE RegisteredMobileNumber LIKE @RegisteredMobileNumber "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@status", "Open")
							sqlCommand.Parameters.AddWithValue("@join_user", Me.lblUser.Text)
						End If
						sqlCommand.Parameters.AddWithValue("@RegisteredMobileNumber", "%" + Me.txtMobile.Text + "%")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002132 RID: 8498 RVA: 0x001519E4 File Offset: 0x0014FBE4
		Private Sub btnOffline_Online_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerSupport1.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmCustomerSupport1.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerSupport1.ShowDialog()
			MyProject.Forms.frmCustomerSupport1.Dispose()
		End Sub

		' Token: 0x06002133 RID: 8499 RVA: 0x00151A54 File Offset: 0x0014FC54
		Private Function UpdateGoogleSheetStatus(token As String, status As String, remark As String) As Boolean
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = Path.Combine(Application.StartupPath, "credentials_.json")
				Dim googleCredential As GoogleCredential
				Using fileStream As FileStream = New FileStream(text, FileMode.Open, FileAccess.Read)
					googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(New String() { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets })
				End Using
				Dim sheetsService As SheetsService = New SheetsService(New BaseClientService.Initializer() With { .HttpClientInitializer = googleCredential, .ApplicationName = "Customer Support Logger" })
				Dim text2 As String = "10Jp2rmH0KQ-6mNWHH3fTVX1eKHPnsipglEwlex9LyHg"
				Dim text3 As String = "Form Responses 1"
				Dim getRequest As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](text2, text3 + "!A2:M")
				Dim valueRange As ValueRange = getRequest.Execute()
				Dim flag As Boolean = valueRange.Values IsNot Nothing
				If flag Then
					Dim num As Integer = valueRange.Values.Count - 1
					For i As Integer = 0 To num
						Dim list As IList(Of Object) = valueRange.Values(i)
						Dim flag2 As Boolean = list.Count > 1 AndAlso Operators.CompareString(list(1).ToString(), token, False) = 0
						If flag2 Then
							Dim text4 As String = String.Concat(New String() { text3, "!I", (i + 2).ToString(), ":J", (i + 2).ToString() })
							Dim valueRange2 As ValueRange = New ValueRange() With { .Values = New List(Of IList(Of Object))() From { New List(Of Object)() From { status, remark } } }
							Dim updateRequest As SpreadsheetsResource.ValuesResource.UpdateRequest = sheetsService.Spreadsheets.Values.Update(valueRange2, text2, text4)
							updateRequest.ValueInputOption = New SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum?(SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED)
							updateRequest.Execute()
							Return True
						End If
					Next
				End If
			Catch ex As Exception
				Return False
			End Try
			Return False
		End Function

		' Token: 0x06002134 RID: 8500 RVA: 0x00151C80 File Offset: 0x0014FE80
		Private Sub UpdateSQLStatusToClosed(logId As Integer)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "UPDATE CustomerSupportForm " & vbCrLf & "                               SET Status='Closed' " & vbCrLf & "                               WHERE LogId=@LogId"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@LogId", logId)
					sqlCommand.ExecuteNonQuery()
				End Using
			End Using
		End Sub

		' Token: 0x06002135 RID: 8501 RVA: 0x00151D08 File Offset: 0x0014FF08
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to Generate Quotation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLQS.Text = "Support"
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLead_Id.Text = Me.lbl_tokenid.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.ShowDialog()
					MyProject.Forms.frmPOSNewTuch_Quotation.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002136 RID: 8502 RVA: 0x00151E08 File Offset: 0x00150008
		Public Sub Getdata_Quotation()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join CustomerSupportForm on CustomerSupportForm.support_token_no  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where CustomerSupportForm.support_token_no=@d1 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join CustomerSupportForm on CustomerSupportForm.support_token_no  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where CustomerSupportForm.support_token_no=@d1 and Operator=@d2 order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.VarChar).Value = Me.lbl_tokenid.Text
				Dim flag2 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) <> 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar).Value = Me.lblUser.Text
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.DataGridView3.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView3.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002137 RID: 8503 RVA: 0x00141E1C File Offset: 0x0014001C
		Private Sub ApplyRowColor(row As DataGridViewRow, status As String)
			Dim flag As Boolean = Operators.CompareString(status, "Pending", False) = 0
			If flag Then
				row.DefaultCellStyle.BackColor = Global.System.Drawing.Color.Red
				row.DefaultCellStyle.ForeColor = Global.System.Drawing.Color.White
			Else
				row.DefaultCellStyle.BackColor = Global.System.Drawing.Color.LightGreen
				row.DefaultCellStyle.ForeColor = Global.System.Drawing.Color.Black
			End If
		End Sub

		' Token: 0x06002138 RID: 8504 RVA: 0x0001739D File Offset: 0x0001559D
		Private Sub DataGridView3_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_LQ()
		End Sub

		' Token: 0x06002139 RID: 8505 RVA: 0x001522C8 File Offset: 0x001504C8
		Public Sub RetrieveData_LQ()
			Try
				Dim flag As Boolean = Me.DataGridView3.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView3.SelectedRows(0)
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.Show()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label207.Text = "edit"
					MyProject.Forms.frmPOSNewTuch_Quotation.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_Quotation.txtCompanyState.Text
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = dataGridViewRow.Cells(40).Value.ToString()
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag3 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblQ_Status.Text = dataGridViewRow.Cells(46).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSave.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnPrint.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.btnDelete.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnAdd.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(InvoiceInfo_Product_Quotation.Barcode),InvoiceInfo_Product_Quotation.Qty, InvoiceInfo_Product_Quotation.SalesRate,InvoiceInfo_Product_Quotation.DiscountPer, InvoiceInfo_Product_Quotation.Discount, InvoiceInfo_Product_Quotation.CGSTPer, InvoiceInfo_Product_Quotation.CGSTAmt, InvoiceInfo_Product_Quotation.SGSTPer, InvoiceInfo_Product_Quotation.SGSTAmt, InvoiceInfo_Product_Quotation.IGSTPer,InvoiceInfo_Product_Quotation. IGSTAmt, InvoiceInfo_Product_Quotation.CESSPer,InvoiceInfo_Product_Quotation. CESSAmt,InvoiceInfo_Product_Quotation. TotalAmount,InvoiceInfo_Product_Quotation. PurchaseRate,InvoiceInfo_Product_Quotation. Margin,InvoiceInfo_Product_Quotation.Descr,InvoiceInfo_Product_Quotation.Qty,RTRIM(InvoiceInfo_Product_Quotation.IM1),RTRIM(InvoiceInfo_Product_Quotation.IM2),(InvoiceInfo_Product_Quotation.MRP),(InvoiceInfo_Product_Quotation.TaxableAmt),(InvoiceInfo_Product_Quotation.AltQty),(InvoiceInfo_Product_Quotation.AltUnit),(InvoiceInfo_Product_Quotation.STaxType),(InvoiceInfo_Product_Quotation.TotalMRP),(InvoiceInfo_Product_Quotation.PromoQty),RTRIM(InvoiceInfo_Product_Quotation.MainUnit),RTRIM(InvoiceInfo_Product_Quotation.Batch),RTRIM(InvoiceInfo_Product_Quotation.Mfg),RTRIM(InvoiceInfo_Product_Quotation.Exp),RTRIM(InvoiceInfo_Product_Quotation.Size),RTRIM(InvoiceInfo_Product_Quotation.Colour),InvoiceInfo_Product_Quotation.SalesManID,InvoiceInfo_Product_Quotation.SalesMan,InvoiceInfo_Product_Quotation.SalesManPur,InvoiceInfo_Product_Quotation.SalesManComm ,InvoiceInfo_Product_Quotation.StockID, InvoiceInfo_Product_Quotation.LoyalityPoints from InvoiceInfo_Quotation,InvoiceInfo_Product_Quotation,Product where InvoiceInfo_Quotation.Inv_ID=InvoiceInfo_Product_Quotation.InvoiceID and Product.PID=InvoiceInfo_Product_Quotation.ProductID and InvoiceInfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), MyProject.Forms.frmPOSNewTuch_Quotation.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
					End While
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Visible = True
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch_Quotation.CustomerBalance_Loyality()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Compute()
					MyProject.Forms.frmPOSNewTuch_Quotation.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Bankcondn()
					MyProject.Forms.frmPOSNewTuch_Quotation.totitemnqty()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
					Dim flag4 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text, "TCS", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = "0"
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.CTypeStatus()
					MyProject.Forms.frmPOSNewTuch_Quotation.BrokerRetrive()
					MyProject.Forms.frmPOSNewTuch_Quotation.CheckBox11.Checked = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.[ReadOnly] = True
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600213A RID: 8506 RVA: 0x001535F0 File Offset: 0x001517F0
		Private Sub DataGridView3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_LQ()
			End If
		End Sub

		' Token: 0x0600213B RID: 8507 RVA: 0x00153618 File Offset: 0x00151818
		Public Sub Getdata()
			Dim text As String = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select CustomerId  FROM CustomerSupportForm where support_token_no=@d0 ", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.lbl_tokenid.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If Not flag Then
					Return
				End If
				text = Conversions.ToString(ModCommonClasses.rdr(0))
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt  from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Customer.ID=@d1 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600213C RID: 8508 RVA: 0x00153ADC File Offset: 0x00151CDC
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x0600213D RID: 8509 RVA: 0x000173A7 File Offset: 0x000155A7
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x0600213E RID: 8510 RVA: 0x00153B04 File Offset: 0x00151D04
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSNewTuch.Show()
					MyProject.Forms.frmPOSNewTuch.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
					Else
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					End If
					MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow.Cells(40).Value.ToString()
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag3 Then
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.btnSave.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnPrint.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
					Dim flag4 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
					If flag4 Then
						MyProject.Forms.frmPOSNewTuch.btnUpdate.Enabled = True
						MyProject.Forms.frmPOSNewTuch.btnDelete.Enabled = True
					Else
						MyProject.Forms.frmPOSNewTuch.btnUpdate.Enabled = False
						MyProject.Forms.frmPOSNewTuch.btnDelete.Enabled = False
					End If
					MyProject.Forms.frmPOSNewTuch.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmPOSNewTuch.btnAdd.Enabled = True
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch.txtContactNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnCustomerSelection.Enabled = False
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch.TextBox15.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.Label82.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin,Invoice_Product.Descr,Invoice_Product.Qty,RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),(Invoice_Product.MRP),(Invoice_Product.TaxableAmt),(Invoice_Product.AltQty),(Invoice_Product.AltUnit),(Invoice_Product.STaxType),(Invoice_Product.TotalMRP),(Invoice_Product.PromoQty),RTRIM(Invoice_Product.MainUnit),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour),Invoice_Product.SalesManID,Invoice_Product.SalesMan,Invoice_Product.SalesManPur,Invoice_Product.SalesManComm ,Invoice_Product.StockID, Invoice_Product.LoyalityPoints from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
					End While
					MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text4 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView5.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView5.Visible = True
						MyProject.Forms.frmPOSNewTuch.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch.CustomerBalance_Loyality()
					MyProject.Forms.frmPOSNewTuch.Calc()
					MyProject.Forms.frmPOSNewTuch.Compute()
					MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch.Bankcondn()
					MyProject.Forms.frmPOSNewTuch.totitemnqty()
					MyProject.Forms.frmPOSNewTuch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch.Calculate12345()
					MyProject.Forms.frmPOSNewTuch.Calculate143()
					Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text, "TCS", False) = 0
					If flag5 Then
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
					Else
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = "0"
					End If
					MyProject.Forms.frmPOSNewTuch.CTypeStatus()
					MyProject.Forms.frmPOSNewTuch.BrokerRetrive()
					MyProject.Forms.frmPOSNewTuch.CheckBox11.Checked = False
					MyProject.Forms.frmPOSNewTuch.txtInvoiceNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04000D8A RID: 3466
		Private dt As DataTable
	End Class
End Namespace
