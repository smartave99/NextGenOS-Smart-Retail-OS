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
	' Token: 0x020005DC RID: 1500
	<DesignerGenerated()>
	Public Partial Class frmSalesInvoiceRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012578 RID: 75128 RVA: 0x0007DC36 File Offset: 0x0007BE36
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170071CF RID: 29135
		' (get) Token: 0x0601257B RID: 75131 RVA: 0x0007DC68 File Offset: 0x0007BE68
		' (set) Token: 0x0601257C RID: 75132 RVA: 0x0007DC72 File Offset: 0x0007BE72
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170071D0 RID: 29136
		' (get) Token: 0x0601257D RID: 75133 RVA: 0x0007DC7B File Offset: 0x0007BE7B
		' (set) Token: 0x0601257E RID: 75134 RVA: 0x00A8E298 File Offset: 0x00A8C498
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
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071D1 RID: 29137
		' (get) Token: 0x0601257F RID: 75135 RVA: 0x0007DC85 File Offset: 0x0007BE85
		' (set) Token: 0x06012580 RID: 75136 RVA: 0x0007DC8F File Offset: 0x0007BE8F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170071D2 RID: 29138
		' (get) Token: 0x06012581 RID: 75137 RVA: 0x0007DC98 File Offset: 0x0007BE98
		' (set) Token: 0x06012582 RID: 75138 RVA: 0x0007DCA2 File Offset: 0x0007BEA2
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170071D3 RID: 29139
		' (get) Token: 0x06012583 RID: 75139 RVA: 0x0007DCAB File Offset: 0x0007BEAB
		' (set) Token: 0x06012584 RID: 75140 RVA: 0x0007DCB5 File Offset: 0x0007BEB5
		Friend Overridable Property Label2 As Label

		' Token: 0x170071D4 RID: 29140
		' (get) Token: 0x06012585 RID: 75141 RVA: 0x0007DCBE File Offset: 0x0007BEBE
		' (set) Token: 0x06012586 RID: 75142 RVA: 0x0007DCC8 File Offset: 0x0007BEC8
		Friend Overridable Property Label4 As Label

		' Token: 0x170071D5 RID: 29141
		' (get) Token: 0x06012587 RID: 75143 RVA: 0x0007DCD1 File Offset: 0x0007BED1
		' (set) Token: 0x06012588 RID: 75144 RVA: 0x0007DCDB File Offset: 0x0007BEDB
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170071D6 RID: 29142
		' (get) Token: 0x06012589 RID: 75145 RVA: 0x0007DCE4 File Offset: 0x0007BEE4
		' (set) Token: 0x0601258A RID: 75146 RVA: 0x00A8E314 File Offset: 0x00A8C514
		Private _cmbInvoiceNo As ComboBox
		Friend Overridable Property cmbInvoiceNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbInvoiceNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbInvoiceNo_Format
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbInvoiceNo_TextChanged
				Dim comboBox As ComboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.TextChanged, eventHandler2
				End If
				Me._cmbInvoiceNo = value
				comboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.TextChanged, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170071D7 RID: 29143
		' (get) Token: 0x0601258B RID: 75147 RVA: 0x0007DCEE File Offset: 0x0007BEEE
		' (set) Token: 0x0601258C RID: 75148 RVA: 0x0007DCF8 File Offset: 0x0007BEF8
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170071D8 RID: 29144
		' (get) Token: 0x0601258D RID: 75149 RVA: 0x0007DD01 File Offset: 0x0007BF01
		' (set) Token: 0x0601258E RID: 75150 RVA: 0x0007DD0B File Offset: 0x0007BF0B
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170071D9 RID: 29145
		' (get) Token: 0x0601258F RID: 75151 RVA: 0x0007DD14 File Offset: 0x0007BF14
		' (set) Token: 0x06012590 RID: 75152 RVA: 0x0007DD1E File Offset: 0x0007BF1E
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170071DA RID: 29146
		' (get) Token: 0x06012591 RID: 75153 RVA: 0x0007DD27 File Offset: 0x0007BF27
		' (set) Token: 0x06012592 RID: 75154 RVA: 0x0007DD31 File Offset: 0x0007BF31
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170071DB RID: 29147
		' (get) Token: 0x06012593 RID: 75155 RVA: 0x0007DD3A File Offset: 0x0007BF3A
		' (set) Token: 0x06012594 RID: 75156 RVA: 0x0007DD44 File Offset: 0x0007BF44
		Friend Overridable Property Label3 As Label

		' Token: 0x170071DC RID: 29148
		' (get) Token: 0x06012595 RID: 75157 RVA: 0x0007DD4D File Offset: 0x0007BF4D
		' (set) Token: 0x06012596 RID: 75158 RVA: 0x0007DD57 File Offset: 0x0007BF57
		Friend Overridable Property Label5 As Label

		' Token: 0x170071DD RID: 29149
		' (get) Token: 0x06012597 RID: 75159 RVA: 0x0007DD60 File Offset: 0x0007BF60
		' (set) Token: 0x06012598 RID: 75160 RVA: 0x0007DD6A File Offset: 0x0007BF6A
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170071DE RID: 29150
		' (get) Token: 0x06012599 RID: 75161 RVA: 0x0007DD73 File Offset: 0x0007BF73
		' (set) Token: 0x0601259A RID: 75162 RVA: 0x0007DD7D File Offset: 0x0007BF7D
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170071DF RID: 29151
		' (get) Token: 0x0601259B RID: 75163 RVA: 0x0007DD86 File Offset: 0x0007BF86
		' (set) Token: 0x0601259C RID: 75164 RVA: 0x00A8E390 File Offset: 0x00A8C590
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071E0 RID: 29152
		' (get) Token: 0x0601259D RID: 75165 RVA: 0x0007DD90 File Offset: 0x0007BF90
		' (set) Token: 0x0601259E RID: 75166 RVA: 0x0007DD9A File Offset: 0x0007BF9A
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x170071E1 RID: 29153
		' (get) Token: 0x0601259F RID: 75167 RVA: 0x0007DDA3 File Offset: 0x0007BFA3
		' (set) Token: 0x060125A0 RID: 75168 RVA: 0x00A8E3D4 File Offset: 0x00A8C5D4
		Private _txtSalesman As TextBox
		Friend Overridable Property txtSalesman As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalesman
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSalesman_TextChanged
				Dim textBox As TextBox = Me._txtSalesman
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSalesman = value
				textBox = Me._txtSalesman
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071E2 RID: 29154
		' (get) Token: 0x060125A1 RID: 75169 RVA: 0x0007DDAD File Offset: 0x0007BFAD
		' (set) Token: 0x060125A2 RID: 75170 RVA: 0x0007DDB7 File Offset: 0x0007BFB7
		Friend Overridable Property lblSet As Label

		' Token: 0x170071E3 RID: 29155
		' (get) Token: 0x060125A3 RID: 75171 RVA: 0x0007DDC0 File Offset: 0x0007BFC0
		' (set) Token: 0x060125A4 RID: 75172 RVA: 0x0007DDCA File Offset: 0x0007BFCA
		Friend Overridable Property Label1 As Label

		' Token: 0x170071E4 RID: 29156
		' (get) Token: 0x060125A5 RID: 75173 RVA: 0x0007DDD3 File Offset: 0x0007BFD3
		' (set) Token: 0x060125A6 RID: 75174 RVA: 0x0007DDDD File Offset: 0x0007BFDD
		Friend Overridable Property lblUserType As Label

		' Token: 0x170071E5 RID: 29157
		' (get) Token: 0x060125A7 RID: 75175 RVA: 0x0007DDE6 File Offset: 0x0007BFE6
		' (set) Token: 0x060125A8 RID: 75176 RVA: 0x0007DDF0 File Offset: 0x0007BFF0
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x170071E6 RID: 29158
		' (get) Token: 0x060125A9 RID: 75177 RVA: 0x0007DDF9 File Offset: 0x0007BFF9
		' (set) Token: 0x060125AA RID: 75178 RVA: 0x00A8E418 File Offset: 0x00A8C618
		Private _txtCustCity As TextBox
		Friend Overridable Property txtCustCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustCity_TextChanged
				Dim textBox As TextBox = Me._txtCustCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustCity = value
				textBox = Me._txtCustCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071E7 RID: 29159
		' (get) Token: 0x060125AB RID: 75179 RVA: 0x0007DE03 File Offset: 0x0007C003
		' (set) Token: 0x060125AC RID: 75180 RVA: 0x0007DE0D File Offset: 0x0007C00D
		Friend Overridable Property GroupBox7 As GroupBox

		' Token: 0x170071E8 RID: 29160
		' (get) Token: 0x060125AD RID: 75181 RVA: 0x0007DE16 File Offset: 0x0007C016
		' (set) Token: 0x060125AE RID: 75182 RVA: 0x0007DE20 File Offset: 0x0007C020
		Friend Overridable Property txtSlNo2 As TextBox

		' Token: 0x170071E9 RID: 29161
		' (get) Token: 0x060125AF RID: 75183 RVA: 0x0007DE29 File Offset: 0x0007C029
		' (set) Token: 0x060125B0 RID: 75184 RVA: 0x0007DE33 File Offset: 0x0007C033
		Friend Overridable Property txtSlNo1 As TextBox

		' Token: 0x170071EA RID: 29162
		' (get) Token: 0x060125B1 RID: 75185 RVA: 0x0007DE3C File Offset: 0x0007C03C
		' (set) Token: 0x060125B2 RID: 75186 RVA: 0x0007DE46 File Offset: 0x0007C046
		Friend Overridable Property Label6 As Label

		' Token: 0x170071EB RID: 29163
		' (get) Token: 0x060125B3 RID: 75187 RVA: 0x0007DE4F File Offset: 0x0007C04F
		' (set) Token: 0x060125B4 RID: 75188 RVA: 0x0007DE59 File Offset: 0x0007C059
		Friend Overridable Property Label7 As Label

		' Token: 0x170071EC RID: 29164
		' (get) Token: 0x060125B5 RID: 75189 RVA: 0x0007DE62 File Offset: 0x0007C062
		' (set) Token: 0x060125B6 RID: 75190 RVA: 0x0007DE6C File Offset: 0x0007C06C
		Friend Overridable Property GroupBox8 As GroupBox

		' Token: 0x170071ED RID: 29165
		' (get) Token: 0x060125B7 RID: 75191 RVA: 0x0007DE75 File Offset: 0x0007C075
		' (set) Token: 0x060125B8 RID: 75192 RVA: 0x00A8E45C File Offset: 0x00A8C65C
		Private _txtstate As TextBox
		Friend Overridable Property txtstate As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtstate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtstate_TextChanged
				Dim textBox As TextBox = Me._txtstate
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtstate = value
				textBox = Me._txtstate
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071EE RID: 29166
		' (get) Token: 0x060125B9 RID: 75193 RVA: 0x0007DE7F File Offset: 0x0007C07F
		' (set) Token: 0x060125BA RID: 75194 RVA: 0x0007DE89 File Offset: 0x0007C089
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170071EF RID: 29167
		' (get) Token: 0x060125BB RID: 75195 RVA: 0x0007DE92 File Offset: 0x0007C092
		' (set) Token: 0x060125BC RID: 75196 RVA: 0x0007DE9C File Offset: 0x0007C09C
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170071F0 RID: 29168
		' (get) Token: 0x060125BD RID: 75197 RVA: 0x0007DEA5 File Offset: 0x0007C0A5
		' (set) Token: 0x060125BE RID: 75198 RVA: 0x0007DEAF File Offset: 0x0007C0AF
		Friend Overridable Property GroupBox9 As GroupBox

		' Token: 0x170071F1 RID: 29169
		' (get) Token: 0x060125BF RID: 75199 RVA: 0x0007DEB8 File Offset: 0x0007C0B8
		' (set) Token: 0x060125C0 RID: 75200 RVA: 0x0007DEC2 File Offset: 0x0007C0C2
		Friend Overridable Property Label9 As Label

		' Token: 0x170071F2 RID: 29170
		' (get) Token: 0x060125C1 RID: 75201 RVA: 0x0007DECB File Offset: 0x0007C0CB
		' (set) Token: 0x060125C2 RID: 75202 RVA: 0x00A8E4A0 File Offset: 0x00A8C6A0
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071F3 RID: 29171
		' (get) Token: 0x060125C3 RID: 75203 RVA: 0x0007DED5 File Offset: 0x0007C0D5
		' (set) Token: 0x060125C4 RID: 75204 RVA: 0x0007DEDF File Offset: 0x0007C0DF
		Friend Overridable Property Label8 As Label

		' Token: 0x170071F4 RID: 29172
		' (get) Token: 0x060125C5 RID: 75205 RVA: 0x0007DEE8 File Offset: 0x0007C0E8
		' (set) Token: 0x060125C6 RID: 75206 RVA: 0x00A8E4E4 File Offset: 0x00A8C6E4
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

		' Token: 0x170071F5 RID: 29173
		' (get) Token: 0x060125C7 RID: 75207 RVA: 0x0007DEF2 File Offset: 0x0007C0F2
		' (set) Token: 0x060125C8 RID: 75208 RVA: 0x0007DEFC File Offset: 0x0007C0FC
		Friend Overridable Property Label10 As Label

		' Token: 0x170071F6 RID: 29174
		' (get) Token: 0x060125C9 RID: 75209 RVA: 0x0007DF05 File Offset: 0x0007C105
		' (set) Token: 0x060125CA RID: 75210 RVA: 0x00A8E528 File Offset: 0x00A8C728
		Private _ComboBox3 As ComboBox
		Friend Overridable Property ComboBox3 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox3_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox3 = value
				comboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071F7 RID: 29175
		' (get) Token: 0x060125CB RID: 75211 RVA: 0x0007DF0F File Offset: 0x0007C10F
		' (set) Token: 0x060125CC RID: 75212 RVA: 0x0007DF19 File Offset: 0x0007C119
		Friend Overridable Property Label13 As Label

		' Token: 0x170071F8 RID: 29176
		' (get) Token: 0x060125CD RID: 75213 RVA: 0x0007DF22 File Offset: 0x0007C122
		' (set) Token: 0x060125CE RID: 75214 RVA: 0x0007DF2C File Offset: 0x0007C12C
		Friend Overridable Property Label12 As Label

		' Token: 0x170071F9 RID: 29177
		' (get) Token: 0x060125CF RID: 75215 RVA: 0x0007DF35 File Offset: 0x0007C135
		' (set) Token: 0x060125D0 RID: 75216 RVA: 0x0007DF3F File Offset: 0x0007C13F
		Friend Overridable Property Label11 As Label

		' Token: 0x170071FA RID: 29178
		' (get) Token: 0x060125D1 RID: 75217 RVA: 0x0007DF48 File Offset: 0x0007C148
		' (set) Token: 0x060125D2 RID: 75218 RVA: 0x0007DF52 File Offset: 0x0007C152
		Friend Overridable Property Label16 As Label

		' Token: 0x170071FB RID: 29179
		' (get) Token: 0x060125D3 RID: 75219 RVA: 0x0007DF5B File Offset: 0x0007C15B
		' (set) Token: 0x060125D4 RID: 75220 RVA: 0x0007DF65 File Offset: 0x0007C165
		Friend Overridable Property Label15 As Label

		' Token: 0x170071FC RID: 29180
		' (get) Token: 0x060125D5 RID: 75221 RVA: 0x0007DF6E File Offset: 0x0007C16E
		' (set) Token: 0x060125D6 RID: 75222 RVA: 0x0007DF78 File Offset: 0x0007C178
		Friend Overridable Property Label14 As Label

		' Token: 0x170071FD RID: 29181
		' (get) Token: 0x060125D7 RID: 75223 RVA: 0x0007DF81 File Offset: 0x0007C181
		' (set) Token: 0x060125D8 RID: 75224 RVA: 0x0007DF8B File Offset: 0x0007C18B
		Friend Overridable Property Label18 As Label

		' Token: 0x170071FE RID: 29182
		' (get) Token: 0x060125D9 RID: 75225 RVA: 0x0007DF94 File Offset: 0x0007C194
		' (set) Token: 0x060125DA RID: 75226 RVA: 0x0007DF9E File Offset: 0x0007C19E
		Friend Overridable Property Label17 As Label

		' Token: 0x170071FF RID: 29183
		' (get) Token: 0x060125DB RID: 75227 RVA: 0x0007DFA7 File Offset: 0x0007C1A7
		' (set) Token: 0x060125DC RID: 75228 RVA: 0x0007DFB1 File Offset: 0x0007C1B1
		Friend Overridable Property Label20 As Label

		' Token: 0x17007200 RID: 29184
		' (get) Token: 0x060125DD RID: 75229 RVA: 0x0007DFBA File Offset: 0x0007C1BA
		' (set) Token: 0x060125DE RID: 75230 RVA: 0x0007DFC4 File Offset: 0x0007C1C4
		Friend Overridable Property Label19 As Label

		' Token: 0x17007201 RID: 29185
		' (get) Token: 0x060125DF RID: 75231 RVA: 0x0007DFCD File Offset: 0x0007C1CD
		' (set) Token: 0x060125E0 RID: 75232 RVA: 0x00A8E56C File Offset: 0x00A8C76C
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

		' Token: 0x17007202 RID: 29186
		' (get) Token: 0x060125E1 RID: 75233 RVA: 0x0007DFD7 File Offset: 0x0007C1D7
		' (set) Token: 0x060125E2 RID: 75234 RVA: 0x00A8E5B0 File Offset: 0x00A8C7B0
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

		' Token: 0x17007203 RID: 29187
		' (get) Token: 0x060125E3 RID: 75235 RVA: 0x0007DFE1 File Offset: 0x0007C1E1
		' (set) Token: 0x060125E4 RID: 75236 RVA: 0x00A8E5F4 File Offset: 0x00A8C7F4
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

		' Token: 0x17007204 RID: 29188
		' (get) Token: 0x060125E5 RID: 75237 RVA: 0x0007DFEB File Offset: 0x0007C1EB
		' (set) Token: 0x060125E6 RID: 75238 RVA: 0x00A8E638 File Offset: 0x00A8C838
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

		' Token: 0x17007205 RID: 29189
		' (get) Token: 0x060125E7 RID: 75239 RVA: 0x0007DFF5 File Offset: 0x0007C1F5
		' (set) Token: 0x060125E8 RID: 75240 RVA: 0x00A8E67C File Offset: 0x00A8C87C
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007206 RID: 29190
		' (get) Token: 0x060125E9 RID: 75241 RVA: 0x0007DFFF File Offset: 0x0007C1FF
		' (set) Token: 0x060125EA RID: 75242 RVA: 0x00A8E6C0 File Offset: 0x00A8C8C0
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007207 RID: 29191
		' (get) Token: 0x060125EB RID: 75243 RVA: 0x0007E009 File Offset: 0x0007C209
		' (set) Token: 0x060125EC RID: 75244 RVA: 0x00A8E704 File Offset: 0x00A8C904
		Private _GelButton7 As GelButton
		Friend Overridable Property GelButton7 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton7_Click
				Dim gelButton As GelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton7 = value
				gelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007208 RID: 29192
		' (get) Token: 0x060125ED RID: 75245 RVA: 0x0007E013 File Offset: 0x0007C213
		' (set) Token: 0x060125EE RID: 75246 RVA: 0x0007E01D File Offset: 0x0007C21D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17007209 RID: 29193
		' (get) Token: 0x060125EF RID: 75247 RVA: 0x0007E026 File Offset: 0x0007C226
		' (set) Token: 0x060125F0 RID: 75248 RVA: 0x0007E030 File Offset: 0x0007C230
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700720A RID: 29194
		' (get) Token: 0x060125F1 RID: 75249 RVA: 0x0007E039 File Offset: 0x0007C239
		' (set) Token: 0x060125F2 RID: 75250 RVA: 0x0007E043 File Offset: 0x0007C243
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700720B RID: 29195
		' (get) Token: 0x060125F3 RID: 75251 RVA: 0x0007E04C File Offset: 0x0007C24C
		' (set) Token: 0x060125F4 RID: 75252 RVA: 0x0007E056 File Offset: 0x0007C256
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700720C RID: 29196
		' (get) Token: 0x060125F5 RID: 75253 RVA: 0x0007E05F File Offset: 0x0007C25F
		' (set) Token: 0x060125F6 RID: 75254 RVA: 0x0007E069 File Offset: 0x0007C269
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700720D RID: 29197
		' (get) Token: 0x060125F7 RID: 75255 RVA: 0x0007E072 File Offset: 0x0007C272
		' (set) Token: 0x060125F8 RID: 75256 RVA: 0x0007E07C File Offset: 0x0007C27C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700720E RID: 29198
		' (get) Token: 0x060125F9 RID: 75257 RVA: 0x0007E085 File Offset: 0x0007C285
		' (set) Token: 0x060125FA RID: 75258 RVA: 0x0007E08F File Offset: 0x0007C28F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700720F RID: 29199
		' (get) Token: 0x060125FB RID: 75259 RVA: 0x0007E098 File Offset: 0x0007C298
		' (set) Token: 0x060125FC RID: 75260 RVA: 0x0007E0A2 File Offset: 0x0007C2A2
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17007210 RID: 29200
		' (get) Token: 0x060125FD RID: 75261 RVA: 0x0007E0AB File Offset: 0x0007C2AB
		' (set) Token: 0x060125FE RID: 75262 RVA: 0x0007E0B5 File Offset: 0x0007C2B5
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17007211 RID: 29201
		' (get) Token: 0x060125FF RID: 75263 RVA: 0x0007E0BE File Offset: 0x0007C2BE
		' (set) Token: 0x06012600 RID: 75264 RVA: 0x0007E0C8 File Offset: 0x0007C2C8
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17007212 RID: 29202
		' (get) Token: 0x06012601 RID: 75265 RVA: 0x0007E0D1 File Offset: 0x0007C2D1
		' (set) Token: 0x06012602 RID: 75266 RVA: 0x0007E0DB File Offset: 0x0007C2DB
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17007213 RID: 29203
		' (get) Token: 0x06012603 RID: 75267 RVA: 0x0007E0E4 File Offset: 0x0007C2E4
		' (set) Token: 0x06012604 RID: 75268 RVA: 0x0007E0EE File Offset: 0x0007C2EE
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17007214 RID: 29204
		' (get) Token: 0x06012605 RID: 75269 RVA: 0x0007E0F7 File Offset: 0x0007C2F7
		' (set) Token: 0x06012606 RID: 75270 RVA: 0x0007E101 File Offset: 0x0007C301
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17007215 RID: 29205
		' (get) Token: 0x06012607 RID: 75271 RVA: 0x0007E10A File Offset: 0x0007C30A
		' (set) Token: 0x06012608 RID: 75272 RVA: 0x0007E114 File Offset: 0x0007C314
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17007216 RID: 29206
		' (get) Token: 0x06012609 RID: 75273 RVA: 0x0007E11D File Offset: 0x0007C31D
		' (set) Token: 0x0601260A RID: 75274 RVA: 0x0007E127 File Offset: 0x0007C327
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17007217 RID: 29207
		' (get) Token: 0x0601260B RID: 75275 RVA: 0x0007E130 File Offset: 0x0007C330
		' (set) Token: 0x0601260C RID: 75276 RVA: 0x0007E13A File Offset: 0x0007C33A
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17007218 RID: 29208
		' (get) Token: 0x0601260D RID: 75277 RVA: 0x0007E143 File Offset: 0x0007C343
		' (set) Token: 0x0601260E RID: 75278 RVA: 0x0007E14D File Offset: 0x0007C34D
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17007219 RID: 29209
		' (get) Token: 0x0601260F RID: 75279 RVA: 0x0007E156 File Offset: 0x0007C356
		' (set) Token: 0x06012610 RID: 75280 RVA: 0x0007E160 File Offset: 0x0007C360
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700721A RID: 29210
		' (get) Token: 0x06012611 RID: 75281 RVA: 0x0007E169 File Offset: 0x0007C369
		' (set) Token: 0x06012612 RID: 75282 RVA: 0x0007E173 File Offset: 0x0007C373
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700721B RID: 29211
		' (get) Token: 0x06012613 RID: 75283 RVA: 0x0007E17C File Offset: 0x0007C37C
		' (set) Token: 0x06012614 RID: 75284 RVA: 0x0007E186 File Offset: 0x0007C386
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700721C RID: 29212
		' (get) Token: 0x06012615 RID: 75285 RVA: 0x0007E18F File Offset: 0x0007C38F
		' (set) Token: 0x06012616 RID: 75286 RVA: 0x0007E199 File Offset: 0x0007C399
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700721D RID: 29213
		' (get) Token: 0x06012617 RID: 75287 RVA: 0x0007E1A2 File Offset: 0x0007C3A2
		' (set) Token: 0x06012618 RID: 75288 RVA: 0x0007E1AC File Offset: 0x0007C3AC
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700721E RID: 29214
		' (get) Token: 0x06012619 RID: 75289 RVA: 0x0007E1B5 File Offset: 0x0007C3B5
		' (set) Token: 0x0601261A RID: 75290 RVA: 0x0007E1BF File Offset: 0x0007C3BF
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700721F RID: 29215
		' (get) Token: 0x0601261B RID: 75291 RVA: 0x0007E1C8 File Offset: 0x0007C3C8
		' (set) Token: 0x0601261C RID: 75292 RVA: 0x0007E1D2 File Offset: 0x0007C3D2
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17007220 RID: 29216
		' (get) Token: 0x0601261D RID: 75293 RVA: 0x0007E1DB File Offset: 0x0007C3DB
		' (set) Token: 0x0601261E RID: 75294 RVA: 0x0007E1E5 File Offset: 0x0007C3E5
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007221 RID: 29217
		' (get) Token: 0x0601261F RID: 75295 RVA: 0x0007E1EE File Offset: 0x0007C3EE
		' (set) Token: 0x06012620 RID: 75296 RVA: 0x0007E1F8 File Offset: 0x0007C3F8
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17007222 RID: 29218
		' (get) Token: 0x06012621 RID: 75297 RVA: 0x0007E201 File Offset: 0x0007C401
		' (set) Token: 0x06012622 RID: 75298 RVA: 0x0007E20B File Offset: 0x0007C40B
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17007223 RID: 29219
		' (get) Token: 0x06012623 RID: 75299 RVA: 0x0007E214 File Offset: 0x0007C414
		' (set) Token: 0x06012624 RID: 75300 RVA: 0x0007E21E File Offset: 0x0007C41E
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17007224 RID: 29220
		' (get) Token: 0x06012625 RID: 75301 RVA: 0x0007E227 File Offset: 0x0007C427
		' (set) Token: 0x06012626 RID: 75302 RVA: 0x0007E231 File Offset: 0x0007C431
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17007225 RID: 29221
		' (get) Token: 0x06012627 RID: 75303 RVA: 0x0007E23A File Offset: 0x0007C43A
		' (set) Token: 0x06012628 RID: 75304 RVA: 0x0007E244 File Offset: 0x0007C444
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17007226 RID: 29222
		' (get) Token: 0x06012629 RID: 75305 RVA: 0x0007E24D File Offset: 0x0007C44D
		' (set) Token: 0x0601262A RID: 75306 RVA: 0x0007E257 File Offset: 0x0007C457
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17007227 RID: 29223
		' (get) Token: 0x0601262B RID: 75307 RVA: 0x0007E260 File Offset: 0x0007C460
		' (set) Token: 0x0601262C RID: 75308 RVA: 0x0007E26A File Offset: 0x0007C46A
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17007228 RID: 29224
		' (get) Token: 0x0601262D RID: 75309 RVA: 0x0007E273 File Offset: 0x0007C473
		' (set) Token: 0x0601262E RID: 75310 RVA: 0x0007E27D File Offset: 0x0007C47D
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17007229 RID: 29225
		' (get) Token: 0x0601262F RID: 75311 RVA: 0x0007E286 File Offset: 0x0007C486
		' (set) Token: 0x06012630 RID: 75312 RVA: 0x0007E290 File Offset: 0x0007C490
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700722A RID: 29226
		' (get) Token: 0x06012631 RID: 75313 RVA: 0x0007E299 File Offset: 0x0007C499
		' (set) Token: 0x06012632 RID: 75314 RVA: 0x0007E2A3 File Offset: 0x0007C4A3
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700722B RID: 29227
		' (get) Token: 0x06012633 RID: 75315 RVA: 0x0007E2AC File Offset: 0x0007C4AC
		' (set) Token: 0x06012634 RID: 75316 RVA: 0x0007E2B6 File Offset: 0x0007C4B6
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x1700722C RID: 29228
		' (get) Token: 0x06012635 RID: 75317 RVA: 0x0007E2BF File Offset: 0x0007C4BF
		' (set) Token: 0x06012636 RID: 75318 RVA: 0x0007E2C9 File Offset: 0x0007C4C9
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700722D RID: 29229
		' (get) Token: 0x06012637 RID: 75319 RVA: 0x0007E2D2 File Offset: 0x0007C4D2
		' (set) Token: 0x06012638 RID: 75320 RVA: 0x0007E2DC File Offset: 0x0007C4DC
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700722E RID: 29230
		' (get) Token: 0x06012639 RID: 75321 RVA: 0x0007E2E5 File Offset: 0x0007C4E5
		' (set) Token: 0x0601263A RID: 75322 RVA: 0x0007E2EF File Offset: 0x0007C4EF
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700722F RID: 29231
		' (get) Token: 0x0601263B RID: 75323 RVA: 0x0007E2F8 File Offset: 0x0007C4F8
		' (set) Token: 0x0601263C RID: 75324 RVA: 0x0007E302 File Offset: 0x0007C502
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17007230 RID: 29232
		' (get) Token: 0x0601263D RID: 75325 RVA: 0x0007E30B File Offset: 0x0007C50B
		' (set) Token: 0x0601263E RID: 75326 RVA: 0x0007E315 File Offset: 0x0007C515
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17007231 RID: 29233
		' (get) Token: 0x0601263F RID: 75327 RVA: 0x0007E31E File Offset: 0x0007C51E
		' (set) Token: 0x06012640 RID: 75328 RVA: 0x0007E328 File Offset: 0x0007C528
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17007232 RID: 29234
		' (get) Token: 0x06012641 RID: 75329 RVA: 0x0007E331 File Offset: 0x0007C531
		' (set) Token: 0x06012642 RID: 75330 RVA: 0x0007E33B File Offset: 0x0007C53B
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17007233 RID: 29235
		' (get) Token: 0x06012643 RID: 75331 RVA: 0x0007E344 File Offset: 0x0007C544
		' (set) Token: 0x06012644 RID: 75332 RVA: 0x0007E34E File Offset: 0x0007C54E
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17007234 RID: 29236
		' (get) Token: 0x06012645 RID: 75333 RVA: 0x0007E357 File Offset: 0x0007C557
		' (set) Token: 0x06012646 RID: 75334 RVA: 0x0007E361 File Offset: 0x0007C561
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17007235 RID: 29237
		' (get) Token: 0x06012647 RID: 75335 RVA: 0x0007E36A File Offset: 0x0007C56A
		' (set) Token: 0x06012648 RID: 75336 RVA: 0x0007E374 File Offset: 0x0007C574
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x06012649 RID: 75337 RVA: 0x00A8E748 File Offset: 0x00A8C948
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
					Me.DateTimePicker2.Value = DateAndTime.Today
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

		' Token: 0x0601264A RID: 75338 RVA: 0x00A8E82C File Offset: 0x00A8CA2C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt  from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601264B RID: 75339 RVA: 0x00A8EC64 File Offset: 0x00A8CE64
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(UserID) from Registration Order by UserID"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.ComboBox3.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox3.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601264C RID: 75340 RVA: 0x00A8ED38 File Offset: 0x00A8CF38
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.FillUserID()
			Me.cmbInvoiceNo.SelectedIndex = -1
			Me.txtCustomerName.Text = ""
			Me.txtSalesman.Text = ""
			Me.txtCustCity.Text = ""
			Me.txtSlNo1.Text = ""
			Me.txtSlNo2.Text = ""
			Me.txtstate.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601264D RID: 75341 RVA: 0x00A8EE70 File Offset: 0x00A8D070
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

		' Token: 0x0601264E RID: 75342 RVA: 0x00A8EFE8 File Offset: 0x00A8D1E8
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

		' Token: 0x0601264F RID: 75343 RVA: 0x00A8F0B4 File Offset: 0x00A8D2B4
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

		' Token: 0x06012650 RID: 75344 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06012651 RID: 75345 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012652 RID: 75346 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012653 RID: 75347 RVA: 0x00A8F180 File Offset: 0x00A8D380
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06012654 RID: 75348 RVA: 0x0007E37D File Offset: 0x0007C57D
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06012655 RID: 75349 RVA: 0x00A8F1A8 File Offset: 0x00A8D3A8
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Sales Invoice", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOS.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOS.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOS.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOS.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOS.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOS.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOS.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPOS.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPOS.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag3 Then
							MyProject.Forms.frmPOS.cmbCustomerState.Text = MyProject.Forms.frmPOS.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOS.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOS.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOS.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmPOS.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPOS.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmPOS.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPOS.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmPOS.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmPOS.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOS.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmPOS.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPOS.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmPOS.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmPOS.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOS.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOS.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOS.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOS.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
						MyProject.Forms.frmPOS.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
						MyProject.Forms.frmPOS.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
						MyProject.Forms.frmPOS.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
						MyProject.Forms.frmPOS.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOS.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOS.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
						MyProject.Forms.frmPOS.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPOS.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
						MyProject.Forms.frmPOS.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
						MyProject.Forms.frmPOS.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
						Dim flag4 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
						If flag4 Then
							MyProject.Forms.frmPOS.cb1.Checked = True
						Else
							MyProject.Forms.frmPOS.cb1.Checked = False
						End If
						MyProject.Forms.frmPOS.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
						MyProject.Forms.frmPOS.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
						MyProject.Forms.frmPOS.btnSave.Enabled = False
						MyProject.Forms.frmPOS.btnPrint.Enabled = True
						MyProject.Forms.frmPOS.Button5.Enabled = True
						MyProject.Forms.frmPOS.Button6.Enabled = True
						MyProject.Forms.frmPOS.txtOffer.Text = "0.00"
						Dim flag5 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
						If flag5 Then
							MyProject.Forms.frmPOS.btnUpdate.Enabled = True
							MyProject.Forms.frmPOS.btnDelete.Enabled = True
						Else
							MyProject.Forms.frmPOS.btnUpdate.Enabled = False
							MyProject.Forms.frmPOS.btnDelete.Enabled = False
						End If
						MyProject.Forms.frmPOS.lblSet.Text = "Not Allowed"
						MyProject.Forms.frmPOS.btnAdd.Enabled = True
						MyProject.Forms.frmPOS.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOS.txtContactNo.[ReadOnly] = True
						MyProject.Forms.frmPOS.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOS.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOS.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOS.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOS.Label82.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin,Invoice_Product.Descr,Invoice_Product.Qty,RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),(Invoice_Product.MRP),(Invoice_Product.TaxableAmt),(Invoice_Product.AltQty),(Invoice_Product.AltUnit),(Invoice_Product.STaxType),(Invoice_Product.TotalMRP),(Invoice_Product.PromoQty),RTRIM(Invoice_Product.MainUnit),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOS.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOS.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
						End While
						MyProject.Forms.frmPOS.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOS.DataGridView3.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOS.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOS.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOS.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPOS.Calc()
						MyProject.Forms.frmPOS.Compute()
						MyProject.Forms.frmPOS.alldiscountcalc()
						MyProject.Forms.frmPOS.Bankcondn()
						MyProject.Forms.frmPOS.totitemnqty()
						MyProject.Forms.frmPOS.btnSelectSalesman.Enabled = False
						MyProject.Forms.frmPOS.btnListReset1.PerformClick()
						MyProject.Forms.frmPOS.Calculate12345()
						MyProject.Forms.frmPOS.Calculate143()
						Dim flag6 As Boolean = Operators.CompareString(MyProject.Forms.frmPOS.cmbBSundry.Text, "TCS", False) = 0
						If flag6 Then
							MyProject.Forms.frmPOS.txtTCSdbl.[ReadOnly] = True
						Else
							MyProject.Forms.frmPOS.txtTCSdbl.[ReadOnly] = True
							MyProject.Forms.frmPOS.txtTCSdbl.Text = "0"
						End If
						MyProject.Forms.frmPOS.CTypeStatus()
						MyProject.Forms.frmPOS.BrokerRetrive()
						MyProject.Forms.frmPOS.CheckBox11.Checked = False
						MyProject.Forms.frmPOS.txtInvoiceNo.[ReadOnly] = True
					End If
					Dim flag7 As Boolean = Operators.CompareString(Me.lblSet.Text, "Touch Sales Invoice", False) = 0
					If flag7 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSTouch.Label207.Text = "edit"
						MyProject.Forms.frmPOSTouch.txtID.Text = dataGridViewRow2.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtInvoiceNo.Text = dataGridViewRow2.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSTouch.dtpInvoiceDate.Text = dataGridViewRow2.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtGSTNonGST.Text = dataGridViewRow2.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSTouch.TextBox7.Text = dataGridViewRow2.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow2.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSTouch.Label202.Text = dataGridViewRow2.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow2.Cells(4).Value.ToString()
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(6).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow2.Cells(7).Value.ToString()
						Dim flag8 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag8 Then
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = MyProject.Forms.frmPOSTouch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow2.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow2.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSM_ID.Text = dataGridViewRow2.Cells(10).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = dataGridViewRow2.Cells(11).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSalesman.Text = dataGridViewRow2.Cells(12).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSubTotal.Text = dataGridViewRow2.Cells(13).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCGST.Text = dataGridViewRow2.Cells(14).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSGST.Text = dataGridViewRow2.Cells(15).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtIGST.Text = dataGridViewRow2.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCESS.Text = dataGridViewRow2.Cells(17).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtFreightCharges.Text = dataGridViewRow2.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSTouch.TextBox44.Text = dataGridViewRow2.Cells(19).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtBillDiscount.Text = dataGridViewRow2.Cells(19).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTotal.Text = dataGridViewRow2.Cells(20).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtRoundOff.Text = dataGridViewRow2.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtGrandTotal.Text = dataGridViewRow2.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = dataGridViewRow2.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtPaymentDue.Text = dataGridViewRow2.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtNar.Text = dataGridViewRow2.Cells(26).Value.ToString()
						MyProject.Forms.frmPOSTouch.txteway.Text = dataGridViewRow2.Cells(27).Value.ToString()
						MyProject.Forms.frmPOSTouch.cmbBSundry.Text = dataGridViewRow2.Cells(30).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtOffer.Text = dataGridViewRow2.Cells(31).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtApplyPoint.Text = dataGridViewRow2.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtLAmt.Text = dataGridViewRow2.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtbilldisc.Text = dataGridViewRow2.Cells(33).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTCSdbl.Text = dataGridViewRow2.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTendAmt.Text = dataGridViewRow2.Cells(35).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtRefAmt.Text = dataGridViewRow2.Cells(36).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtBillAmt.Text = dataGridViewRow2.Cells(37).Value.ToString()
						MyProject.Forms.frmPOSTouch.CAddress = dataGridViewRow2.Cells(40).Value.ToString()
						Dim flag9 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow2.Cells(32).Value, 0, False)
						If flag9 Then
							MyProject.Forms.frmPOSTouch.cb1.Checked = True
						Else
							MyProject.Forms.frmPOSTouch.cb1.Checked = False
						End If
						MyProject.Forms.frmPOSTouch.txtCoupAmt.Text = dataGridViewRow2.Cells(38).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtgiftamt.Text = dataGridViewRow2.Cells(39).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblSalesReturnNo.Text = dataGridViewRow2.Cells(41).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtByReturn.Text = dataGridViewRow2.Cells(42).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTotalLoyality_points.Text = dataGridViewRow2.Cells(43).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblTPoints1.Text = dataGridViewRow2.Cells(44).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblTPointsAmt1.Text = dataGridViewRow2.Cells(45).Value.ToString()
						MyProject.Forms.frmPOSTouch.TextBox43.Text = dataGridViewRow2.Cells(45).Value.ToString()
						Dim flag10 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.txtByReturn.Text, "", False) = 0
						If flag10 Then
							MyProject.Forms.frmPOSTouch.txtByReturn.Text = Conversions.ToString(0.0)
						End If
						MyProject.Forms.frmPOSTouch.GelButton7.Enabled = False
						MyProject.Forms.frmPOSTouch.TextBox40.Enabled = False
						MyProject.Forms.frmPOSTouch.TextBox40.Visible = True
						MyProject.Forms.frmPOSTouch.btnSave.Enabled = False
						MyProject.Forms.frmPOSTouch.btnPrint.Enabled = True
						MyProject.Forms.frmPOSTouch.Button5.Enabled = True
						MyProject.Forms.frmPOSTouch.Button6.Enabled = True
						MyProject.Forms.frmPOSTouch.txtOffer.Text = "0.00"
						Dim flag11 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
						If flag11 Then
							MyProject.Forms.frmPOSTouch.btnUpdate.Enabled = True
							MyProject.Forms.frmPOSTouch.btnDelete.Enabled = True
						Else
							MyProject.Forms.frmPOSTouch.btnUpdate.Enabled = False
							MyProject.Forms.frmPOSTouch.btnDelete.Enabled = False
						End If
						MyProject.Forms.frmPOSTouch.lblSet.Text = "Not Allowed"
						MyProject.Forms.frmPOSTouch.btnAdd.Enabled = True
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSTouch.txtContactNo.[ReadOnly] = True
						MyProject.Forms.frmPOSTouch.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSTouch.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSTouch.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSTouch.Label82.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text4 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin,Invoice_Product.Descr,Invoice_Product.Qty,RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),(Invoice_Product.MRP),(Invoice_Product.TaxableAmt),(Invoice_Product.AltQty),(Invoice_Product.AltUnit),(Invoice_Product.STaxType),(Invoice_Product.TotalMRP),(Invoice_Product.PromoQty),RTRIM(Invoice_Product.MainUnit),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour),Invoice_Product.SalesManID,Invoice_Product.SalesMan,Invoice_Product.SalesManPur,Invoice_Product.SalesManComm ,Invoice_Product.StockID, Invoice_Product.LoyalityPoints from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), MyProject.Forms.frmPOSTouch.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
						End While
						MyProject.Forms.frmPOSTouch.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text5 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin, Invoice_Product.LoyalityPoints from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text5, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSTouch.DataGridView3.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSTouch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text6 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text6, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSTouch.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSTouch.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text7 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
						ModCommonClasses.cmd = New SqlCommand(text7, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(1).Value))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSTouch.DataGridView5.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSTouch.DataGridView5.Visible = True
							MyProject.Forms.frmPOSTouch.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPOSTouch.CustomerBalance_Loyality()
						MyProject.Forms.frmPOSTouch.Calc()
						MyProject.Forms.frmPOSTouch.Compute()
						MyProject.Forms.frmPOSTouch.alldiscountcalc()
						MyProject.Forms.frmPOSTouch.Bankcondn()
						MyProject.Forms.frmPOSTouch.totitemnqty()
						MyProject.Forms.frmPOSTouch.btnListReset1.PerformClick()
						MyProject.Forms.frmPOSTouch.Calculate12345()
						MyProject.Forms.frmPOSTouch.Calculate143()
						Dim flag12 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbBSundry.Text, "TCS", False) = 0
						If flag12 Then
							MyProject.Forms.frmPOSTouch.txtTCSdbl.[ReadOnly] = True
						Else
							MyProject.Forms.frmPOSTouch.txtTCSdbl.[ReadOnly] = True
							MyProject.Forms.frmPOSTouch.txtTCSdbl.Text = "0"
						End If
						MyProject.Forms.frmPOSTouch.CTypeStatus()
						MyProject.Forms.frmPOSTouch.BrokerRetrive()
						MyProject.Forms.frmPOSTouch.CheckBox11.Checked = False
						MyProject.Forms.frmPOSTouch.txtInvoiceNo.[ReadOnly] = True
						MyProject.Forms.frmPOSTouch.btnshippingLBL.Visible = True
						MyProject.Forms.frmPOSTouch.TableLayoutPanel5.Visible = True
						MyProject.Forms.frmPOSTouch.btnDelete.Visible = True
					End If
					Dim flag13 As Boolean = Operators.CompareString(Me.lblSet.Text, "Touch NewSales Invoice", False) = 0
					If flag13 Then
						Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSNewTuch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch.txtID.Text = dataGridViewRow3.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtInvoiceNo.Text = dataGridViewRow3.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow3.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGSTNonGST.Text = dataGridViewRow3.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow3.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow3.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.Label202.Text = dataGridViewRow3.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow3.Cells(4).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow3.Cells(6).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow3.Cells(7).Value.ToString()
						Dim flag14 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag14 Then
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow3.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow3.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow3.Cells(10).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow3.Cells(11).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow3.Cells(12).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSubTotal.Text = dataGridViewRow3.Cells(13).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCGST.Text = dataGridViewRow3.Cells(14).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSGST.Text = dataGridViewRow3.Cells(15).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtIGST.Text = dataGridViewRow3.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCESS.Text = dataGridViewRow3.Cells(17).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtFreightCharges.Text = dataGridViewRow3.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtBillDiscount.Text = dataGridViewRow3.Cells(19).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotal.Text = dataGridViewRow3.Cells(20).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtRoundOff.Text = dataGridViewRow3.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGrandTotal.Text = dataGridViewRow3.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = dataGridViewRow3.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtPaymentDue.Text = dataGridViewRow3.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtNar.Text = dataGridViewRow3.Cells(26).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txteway.Text = dataGridViewRow3.Cells(27).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text = dataGridViewRow3.Cells(30).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtOffer.Text = dataGridViewRow3.Cells(31).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtApplyPoint.Text = dataGridViewRow3.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtLAmt.Text = dataGridViewRow3.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtbilldisc.Text = dataGridViewRow3.Cells(33).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = dataGridViewRow3.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow3.Cells(35).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow3.Cells(36).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow3.Cells(37).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow3.Cells(40).Value.ToString()
						Dim flag15 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow3.Cells(32).Value, 0, False)
						If flag15 Then
							MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
						Else
							MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
						End If
						MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow3.Cells(38).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow3.Cells(39).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtByReturn.Text = dataGridViewRow3.Cells(42).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotalLoyality_points.Text = dataGridViewRow3.Cells(43).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblTPoints1.Text = dataGridViewRow3.Cells(44).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblTPointsAmt1.Text = dataGridViewRow3.Cells(45).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.TextBox43.Text = dataGridViewRow3.Cells(45).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.btnSave.Enabled = False
						MyProject.Forms.frmPOSNewTuch.btnPrint.Enabled = True
						MyProject.Forms.frmPOSNewTuch.Button5.Enabled = True
						MyProject.Forms.frmPOSNewTuch.Button6.Enabled = True
						MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
						Dim flag16 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
						If flag16 Then
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
						Dim text8 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin,Invoice_Product.Descr,Invoice_Product.Qty,RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),(Invoice_Product.MRP),(Invoice_Product.TaxableAmt),(Invoice_Product.AltQty),(Invoice_Product.AltUnit),(Invoice_Product.STaxType),(Invoice_Product.TotalMRP),(Invoice_Product.PromoQty),RTRIM(Invoice_Product.MainUnit),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour),Invoice_Product.SalesManID,Invoice_Product.SalesMan,Invoice_Product.SalesManPur,Invoice_Product.SalesManComm ,Invoice_Product.StockID, Invoice_Product.LoyalityPoints from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text8, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
						End While
						MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text9 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text9, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text10 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text10, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
						End While
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text11 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
						ModCommonClasses.cmd = New SqlCommand(text11, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(1).Value))
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
						Dim flag17 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text, "TCS", False) = 0
						If flag17 Then
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
					Dim flag18 As Boolean = Operators.CompareString(Me.lblSet.Text, "Sales Return", False) = 0
					If flag18 Then
						Dim dataGridViewRow4 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmSalesReturn.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesReturn.txtSalesID.Text = dataGridViewRow4.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSalesInvoiceNo.Text = dataGridViewRow4.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesReturn.dtpSalesDate.Text = dataGridViewRow4.Cells(2).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtGSTnonGST.Text = dataGridViewRow4.Cells(3).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCustomerID.Text = dataGridViewRow4.Cells(5).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtcust_ID.Text = dataGridViewRow4.Cells(4).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCustomerName.Text = dataGridViewRow4.Cells(6).Value.ToString()
						MyProject.Forms.frmSalesReturn.cmbBSundry.Text = dataGridViewRow4.Cells(30).Value.ToString()
						MyProject.Forms.frmSalesReturn.btnSelection.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text12 As String = "SELECT ProductID, RTRIM(HSNCode), RTRIM(ProductName), RTRIM(Invoice_Product.Barcode), Invoice_Product.Qty, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, RTRIM(Invoice_Product.STaxType), Invoice_Product.TaxableAmt, Invoice_Product.PromoQty, Invoice_Product.SalesManID, Invoice_Product.SalesMan, Invoice_Product.SalesManPur, Invoice_Product.SalesManComm, Invoice_Product.loyalityPoints FROM InvoiceInfo, Invoice_Product, Product WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID AND Product.PID = Invoice_Product.ProductID AND InvoiceInfo.Inv_ID = @d1"
						ModCommonClasses.cmd = New SqlCommand(text12, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmSalesReturn.DataGridView2.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Dim num As Integer = Conversions.ToInteger(ModCommonClasses.rdr("ProductID"))
							Dim num2 As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
							Dim num3 As Decimal = 0D
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Dim text13 As String = "SELECT ISNULL(SUM(a.ReturnQty), 0) FROM SalesReturn_Join a INNER JOIN SalesReturn b ON a.SalesReturnID = b.SR_ID WHERE b.SalesID = @salesID AND a.ProductID = @productID"
								Using sqlCommand As SqlCommand = New SqlCommand(text13, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@salesID", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value)))
									sqlCommand.Parameters.AddWithValue("@productID", num)
									num3 = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
								End Using
							End Using
							Dim num4 As Integer = MyProject.Forms.frmSalesReturn.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
							Dim dataGridViewRow5 As DataGridViewRow = MyProject.Forms.frmSalesReturn.DataGridView2.Rows(num4)
							Dim flag19 As Boolean = Decimal.Compare(num3, 0D) = 0
							If flag19 Then
								dataGridViewRow5.DefaultCellStyle.BackColor = Color.LightGreen
							Else
								Dim flag20 As Boolean = Decimal.Compare(num3, num2) < 0
								If flag20 Then
									dataGridViewRow5.DefaultCellStyle.BackColor = Color.Orange
								Else
									Dim flag21 As Boolean = Decimal.Compare(num3, num2) >= 0
									If flag21 Then
										dataGridViewRow5.DefaultCellStyle.BackColor = Color.LightCoral
									End If
								End If
							End If
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmSalesReturn.DataGridView2.ClearSelection()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012656 RID: 75350 RVA: 0x00A93238 File Offset: 0x00A91438
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

		' Token: 0x06012657 RID: 75351 RVA: 0x00A93320 File Offset: 0x00A91520
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbInvoiceNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbInvoiceNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06012658 RID: 75352 RVA: 0x00A93454 File Offset: 0x00A91654
		Public Sub Reset()
			Me.cmbInvoiceNo.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtSalesman.Text = ""
			Me.txtCustCity.Text = ""
			Me.txtSlNo1.Text = ""
			Me.txtSlNo2.Text = ""
			Me.txtstate.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.fillTillID()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Me.Getdata()
		End Sub

		' Token: 0x06012659 RID: 75353 RVA: 0x00A93548 File Offset: 0x00A91748
		Private Sub cmbInvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select top 10 Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceNo='" + Me.cmbInvoiceNo.Text + "' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601265A RID: 75354 RVA: 0x00A939B4 File Offset: 0x00A91BB4
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Customer.Name like N'" + Me.txtCustomerName.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601265B RID: 75355 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0601265C RID: 75356 RVA: 0x00A93EA0 File Offset: 0x00A920A0
		Private Sub txtSalesman_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Salesman.Name like N'" + Me.txtSalesman.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601265D RID: 75357 RVA: 0x00A9438C File Offset: 0x00A9258C
		Private Sub txtCustCity_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Customer.City like N'" + Me.txtCustCity.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601265E RID: 75358 RVA: 0x00A94878 File Offset: 0x00A92A78
		Private Sub txtstate_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Customer.State like N'" + Me.txtstate.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601265F RID: 75359 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06012660 RID: 75360 RVA: 0x00A94D54 File Offset: 0x00A92F54
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

		' Token: 0x06012661 RID: 75361 RVA: 0x00A952B8 File Offset: 0x00A934B8
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID WHERE NOT TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID WHERE TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr1(43), ModCommonClasses.rdr1(44) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012662 RID: 75362 RVA: 0x00A957C0 File Offset: 0x00A939C0
		Public Sub fillTillID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TillID) FROM POSPrinterSetting", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox2.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox2.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06012663 RID: 75363 RVA: 0x00A958F4 File Offset: 0x00A93AF4
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID WHERE TillID=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr1(43), ModCommonClasses.rdr1(44) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012664 RID: 75364 RVA: 0x00A95DE0 File Offset: 0x00A93FE0
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID WHERE Operator=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012665 RID: 75365 RVA: 0x0007E387 File Offset: 0x0007C587
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06012666 RID: 75366 RVA: 0x00A962CC File Offset: 0x00A944CC
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

		' Token: 0x06012667 RID: 75367 RVA: 0x0004559D File Offset: 0x0004379D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesPmtInfo.ShowDialog()
		End Sub

		' Token: 0x06012668 RID: 75368 RVA: 0x00A96578 File Offset: 0x00A94778
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012669 RID: 75369 RVA: 0x00A96A60 File Offset: 0x00A94C60
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601266A RID: 75370 RVA: 0x00A96F48 File Offset: 0x00A95148
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Inv_ID between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSlNo1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSlNo2.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601266B RID: 75371 RVA: 0x0007E398 File Offset: 0x0007C598
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			Me.fillInvoiceNo()
		End Sub

		' Token: 0x0601266C RID: 75372 RVA: 0x00A973E4 File Offset: 0x00A955E4
		Private Sub cmbInvoiceNo_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				Me.txtSalesman.Text = ""
				Me.txtCustCity.Text = ""
				Me.txtSlNo1.Text = ""
				Me.txtSlNo2.Text = ""
				Me.txtstate.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				Me.ComboBox3.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select top 10 Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceNo like '%" + Me.cmbInvoiceNo.Text + "%' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub
	End Class
End Namespace
