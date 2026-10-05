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
	' Token: 0x020001F3 RID: 499
	<DesignerGenerated()>
	Public Partial Class frmPOSNewTuch_QuotationRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008D26 RID: 36134 RVA: 0x00044DEF File Offset: 0x00042FEF
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170033FE RID: 13310
		' (get) Token: 0x06008D29 RID: 36137 RVA: 0x00044E21 File Offset: 0x00043021
		' (set) Token: 0x06008D2A RID: 36138 RVA: 0x00044E2B File Offset: 0x0004302B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170033FF RID: 13311
		' (get) Token: 0x06008D2B RID: 36139 RVA: 0x00044E34 File Offset: 0x00043034
		' (set) Token: 0x06008D2C RID: 36140 RVA: 0x006795F8 File Offset: 0x006777F8
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

		' Token: 0x17003400 RID: 13312
		' (get) Token: 0x06008D2D RID: 36141 RVA: 0x00044E3E File Offset: 0x0004303E
		' (set) Token: 0x06008D2E RID: 36142 RVA: 0x00044E48 File Offset: 0x00043048
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003401 RID: 13313
		' (get) Token: 0x06008D2F RID: 36143 RVA: 0x00044E51 File Offset: 0x00043051
		' (set) Token: 0x06008D30 RID: 36144 RVA: 0x00044E5B File Offset: 0x0004305B
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17003402 RID: 13314
		' (get) Token: 0x06008D31 RID: 36145 RVA: 0x00044E64 File Offset: 0x00043064
		' (set) Token: 0x06008D32 RID: 36146 RVA: 0x00044E6E File Offset: 0x0004306E
		Friend Overridable Property Label2 As Label

		' Token: 0x17003403 RID: 13315
		' (get) Token: 0x06008D33 RID: 36147 RVA: 0x00044E77 File Offset: 0x00043077
		' (set) Token: 0x06008D34 RID: 36148 RVA: 0x00044E81 File Offset: 0x00043081
		Friend Overridable Property Label4 As Label

		' Token: 0x17003404 RID: 13316
		' (get) Token: 0x06008D35 RID: 36149 RVA: 0x00044E8A File Offset: 0x0004308A
		' (set) Token: 0x06008D36 RID: 36150 RVA: 0x00044E94 File Offset: 0x00043094
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003405 RID: 13317
		' (get) Token: 0x06008D37 RID: 36151 RVA: 0x00044E9D File Offset: 0x0004309D
		' (set) Token: 0x06008D38 RID: 36152 RVA: 0x00679674 File Offset: 0x00677874
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

		' Token: 0x17003406 RID: 13318
		' (get) Token: 0x06008D39 RID: 36153 RVA: 0x00044EA7 File Offset: 0x000430A7
		' (set) Token: 0x06008D3A RID: 36154 RVA: 0x00044EB1 File Offset: 0x000430B1
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003407 RID: 13319
		' (get) Token: 0x06008D3B RID: 36155 RVA: 0x00044EBA File Offset: 0x000430BA
		' (set) Token: 0x06008D3C RID: 36156 RVA: 0x00044EC4 File Offset: 0x000430C4
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17003408 RID: 13320
		' (get) Token: 0x06008D3D RID: 36157 RVA: 0x00044ECD File Offset: 0x000430CD
		' (set) Token: 0x06008D3E RID: 36158 RVA: 0x00044ED7 File Offset: 0x000430D7
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17003409 RID: 13321
		' (get) Token: 0x06008D3F RID: 36159 RVA: 0x00044EE0 File Offset: 0x000430E0
		' (set) Token: 0x06008D40 RID: 36160 RVA: 0x00044EEA File Offset: 0x000430EA
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x1700340A RID: 13322
		' (get) Token: 0x06008D41 RID: 36161 RVA: 0x00044EF3 File Offset: 0x000430F3
		' (set) Token: 0x06008D42 RID: 36162 RVA: 0x00044EFD File Offset: 0x000430FD
		Friend Overridable Property Label3 As Label

		' Token: 0x1700340B RID: 13323
		' (get) Token: 0x06008D43 RID: 36163 RVA: 0x00044F06 File Offset: 0x00043106
		' (set) Token: 0x06008D44 RID: 36164 RVA: 0x00044F10 File Offset: 0x00043110
		Friend Overridable Property Label5 As Label

		' Token: 0x1700340C RID: 13324
		' (get) Token: 0x06008D45 RID: 36165 RVA: 0x00044F19 File Offset: 0x00043119
		' (set) Token: 0x06008D46 RID: 36166 RVA: 0x00044F23 File Offset: 0x00043123
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x1700340D RID: 13325
		' (get) Token: 0x06008D47 RID: 36167 RVA: 0x00044F2C File Offset: 0x0004312C
		' (set) Token: 0x06008D48 RID: 36168 RVA: 0x00044F36 File Offset: 0x00043136
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x1700340E RID: 13326
		' (get) Token: 0x06008D49 RID: 36169 RVA: 0x00044F3F File Offset: 0x0004313F
		' (set) Token: 0x06008D4A RID: 36170 RVA: 0x006796F0 File Offset: 0x006778F0
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

		' Token: 0x1700340F RID: 13327
		' (get) Token: 0x06008D4B RID: 36171 RVA: 0x00044F49 File Offset: 0x00043149
		' (set) Token: 0x06008D4C RID: 36172 RVA: 0x00044F53 File Offset: 0x00043153
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x17003410 RID: 13328
		' (get) Token: 0x06008D4D RID: 36173 RVA: 0x00044F5C File Offset: 0x0004315C
		' (set) Token: 0x06008D4E RID: 36174 RVA: 0x00679734 File Offset: 0x00677934
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

		' Token: 0x17003411 RID: 13329
		' (get) Token: 0x06008D4F RID: 36175 RVA: 0x00044F66 File Offset: 0x00043166
		' (set) Token: 0x06008D50 RID: 36176 RVA: 0x00044F70 File Offset: 0x00043170
		Friend Overridable Property lblSet As Label

		' Token: 0x17003412 RID: 13330
		' (get) Token: 0x06008D51 RID: 36177 RVA: 0x00044F79 File Offset: 0x00043179
		' (set) Token: 0x06008D52 RID: 36178 RVA: 0x00044F83 File Offset: 0x00043183
		Friend Overridable Property Label1 As Label

		' Token: 0x17003413 RID: 13331
		' (get) Token: 0x06008D53 RID: 36179 RVA: 0x00044F8C File Offset: 0x0004318C
		' (set) Token: 0x06008D54 RID: 36180 RVA: 0x00044F96 File Offset: 0x00043196
		Friend Overridable Property lblUserType As Label

		' Token: 0x17003414 RID: 13332
		' (get) Token: 0x06008D55 RID: 36181 RVA: 0x00044F9F File Offset: 0x0004319F
		' (set) Token: 0x06008D56 RID: 36182 RVA: 0x00044FA9 File Offset: 0x000431A9
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x17003415 RID: 13333
		' (get) Token: 0x06008D57 RID: 36183 RVA: 0x00044FB2 File Offset: 0x000431B2
		' (set) Token: 0x06008D58 RID: 36184 RVA: 0x00679778 File Offset: 0x00677978
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

		' Token: 0x17003416 RID: 13334
		' (get) Token: 0x06008D59 RID: 36185 RVA: 0x00044FBC File Offset: 0x000431BC
		' (set) Token: 0x06008D5A RID: 36186 RVA: 0x00044FC6 File Offset: 0x000431C6
		Friend Overridable Property GroupBox7 As GroupBox

		' Token: 0x17003417 RID: 13335
		' (get) Token: 0x06008D5B RID: 36187 RVA: 0x00044FCF File Offset: 0x000431CF
		' (set) Token: 0x06008D5C RID: 36188 RVA: 0x00044FD9 File Offset: 0x000431D9
		Friend Overridable Property txtSlNo2 As TextBox

		' Token: 0x17003418 RID: 13336
		' (get) Token: 0x06008D5D RID: 36189 RVA: 0x00044FE2 File Offset: 0x000431E2
		' (set) Token: 0x06008D5E RID: 36190 RVA: 0x00044FEC File Offset: 0x000431EC
		Friend Overridable Property txtSlNo1 As TextBox

		' Token: 0x17003419 RID: 13337
		' (get) Token: 0x06008D5F RID: 36191 RVA: 0x00044FF5 File Offset: 0x000431F5
		' (set) Token: 0x06008D60 RID: 36192 RVA: 0x00044FFF File Offset: 0x000431FF
		Friend Overridable Property Label6 As Label

		' Token: 0x1700341A RID: 13338
		' (get) Token: 0x06008D61 RID: 36193 RVA: 0x00045008 File Offset: 0x00043208
		' (set) Token: 0x06008D62 RID: 36194 RVA: 0x00045012 File Offset: 0x00043212
		Friend Overridable Property Label7 As Label

		' Token: 0x1700341B RID: 13339
		' (get) Token: 0x06008D63 RID: 36195 RVA: 0x0004501B File Offset: 0x0004321B
		' (set) Token: 0x06008D64 RID: 36196 RVA: 0x00045025 File Offset: 0x00043225
		Friend Overridable Property GroupBox8 As GroupBox

		' Token: 0x1700341C RID: 13340
		' (get) Token: 0x06008D65 RID: 36197 RVA: 0x0004502E File Offset: 0x0004322E
		' (set) Token: 0x06008D66 RID: 36198 RVA: 0x006797BC File Offset: 0x006779BC
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

		' Token: 0x1700341D RID: 13341
		' (get) Token: 0x06008D67 RID: 36199 RVA: 0x00045038 File Offset: 0x00043238
		' (set) Token: 0x06008D68 RID: 36200 RVA: 0x00045042 File Offset: 0x00043242
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700341E RID: 13342
		' (get) Token: 0x06008D69 RID: 36201 RVA: 0x0004504B File Offset: 0x0004324B
		' (set) Token: 0x06008D6A RID: 36202 RVA: 0x00045055 File Offset: 0x00043255
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x1700341F RID: 13343
		' (get) Token: 0x06008D6B RID: 36203 RVA: 0x0004505E File Offset: 0x0004325E
		' (set) Token: 0x06008D6C RID: 36204 RVA: 0x00045068 File Offset: 0x00043268
		Friend Overridable Property GroupBox9 As GroupBox

		' Token: 0x17003420 RID: 13344
		' (get) Token: 0x06008D6D RID: 36205 RVA: 0x00045071 File Offset: 0x00043271
		' (set) Token: 0x06008D6E RID: 36206 RVA: 0x0004507B File Offset: 0x0004327B
		Friend Overridable Property Label9 As Label

		' Token: 0x17003421 RID: 13345
		' (get) Token: 0x06008D6F RID: 36207 RVA: 0x00045084 File Offset: 0x00043284
		' (set) Token: 0x06008D70 RID: 36208 RVA: 0x00679800 File Offset: 0x00677A00
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

		' Token: 0x17003422 RID: 13346
		' (get) Token: 0x06008D71 RID: 36209 RVA: 0x0004508E File Offset: 0x0004328E
		' (set) Token: 0x06008D72 RID: 36210 RVA: 0x00045098 File Offset: 0x00043298
		Friend Overridable Property Label8 As Label

		' Token: 0x17003423 RID: 13347
		' (get) Token: 0x06008D73 RID: 36211 RVA: 0x000450A1 File Offset: 0x000432A1
		' (set) Token: 0x06008D74 RID: 36212 RVA: 0x00679844 File Offset: 0x00677A44
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

		' Token: 0x17003424 RID: 13348
		' (get) Token: 0x06008D75 RID: 36213 RVA: 0x000450AB File Offset: 0x000432AB
		' (set) Token: 0x06008D76 RID: 36214 RVA: 0x000450B5 File Offset: 0x000432B5
		Friend Overridable Property lblOperator As Label

		' Token: 0x17003425 RID: 13349
		' (get) Token: 0x06008D77 RID: 36215 RVA: 0x000450BE File Offset: 0x000432BE
		' (set) Token: 0x06008D78 RID: 36216 RVA: 0x00679888 File Offset: 0x00677A88
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

		' Token: 0x17003426 RID: 13350
		' (get) Token: 0x06008D79 RID: 36217 RVA: 0x000450C8 File Offset: 0x000432C8
		' (set) Token: 0x06008D7A RID: 36218 RVA: 0x000450D2 File Offset: 0x000432D2
		Friend Overridable Property Label13 As Label

		' Token: 0x17003427 RID: 13351
		' (get) Token: 0x06008D7B RID: 36219 RVA: 0x000450DB File Offset: 0x000432DB
		' (set) Token: 0x06008D7C RID: 36220 RVA: 0x000450E5 File Offset: 0x000432E5
		Friend Overridable Property Label12 As Label

		' Token: 0x17003428 RID: 13352
		' (get) Token: 0x06008D7D RID: 36221 RVA: 0x000450EE File Offset: 0x000432EE
		' (set) Token: 0x06008D7E RID: 36222 RVA: 0x000450F8 File Offset: 0x000432F8
		Friend Overridable Property Label11 As Label

		' Token: 0x17003429 RID: 13353
		' (get) Token: 0x06008D7F RID: 36223 RVA: 0x00045101 File Offset: 0x00043301
		' (set) Token: 0x06008D80 RID: 36224 RVA: 0x0004510B File Offset: 0x0004330B
		Friend Overridable Property Label16 As Label

		' Token: 0x1700342A RID: 13354
		' (get) Token: 0x06008D81 RID: 36225 RVA: 0x00045114 File Offset: 0x00043314
		' (set) Token: 0x06008D82 RID: 36226 RVA: 0x0004511E File Offset: 0x0004331E
		Friend Overridable Property Label15 As Label

		' Token: 0x1700342B RID: 13355
		' (get) Token: 0x06008D83 RID: 36227 RVA: 0x00045127 File Offset: 0x00043327
		' (set) Token: 0x06008D84 RID: 36228 RVA: 0x00045131 File Offset: 0x00043331
		Friend Overridable Property Label14 As Label

		' Token: 0x1700342C RID: 13356
		' (get) Token: 0x06008D85 RID: 36229 RVA: 0x0004513A File Offset: 0x0004333A
		' (set) Token: 0x06008D86 RID: 36230 RVA: 0x00045144 File Offset: 0x00043344
		Friend Overridable Property Label18 As Label

		' Token: 0x1700342D RID: 13357
		' (get) Token: 0x06008D87 RID: 36231 RVA: 0x0004514D File Offset: 0x0004334D
		' (set) Token: 0x06008D88 RID: 36232 RVA: 0x00045157 File Offset: 0x00043357
		Friend Overridable Property Label17 As Label

		' Token: 0x1700342E RID: 13358
		' (get) Token: 0x06008D89 RID: 36233 RVA: 0x00045160 File Offset: 0x00043360
		' (set) Token: 0x06008D8A RID: 36234 RVA: 0x0004516A File Offset: 0x0004336A
		Friend Overridable Property Label20 As Label

		' Token: 0x1700342F RID: 13359
		' (get) Token: 0x06008D8B RID: 36235 RVA: 0x00045173 File Offset: 0x00043373
		' (set) Token: 0x06008D8C RID: 36236 RVA: 0x0004517D File Offset: 0x0004337D
		Friend Overridable Property Label19 As Label

		' Token: 0x17003430 RID: 13360
		' (get) Token: 0x06008D8D RID: 36237 RVA: 0x00045186 File Offset: 0x00043386
		' (set) Token: 0x06008D8E RID: 36238 RVA: 0x006798CC File Offset: 0x00677ACC
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

		' Token: 0x17003431 RID: 13361
		' (get) Token: 0x06008D8F RID: 36239 RVA: 0x00045190 File Offset: 0x00043390
		' (set) Token: 0x06008D90 RID: 36240 RVA: 0x00679910 File Offset: 0x00677B10
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

		' Token: 0x17003432 RID: 13362
		' (get) Token: 0x06008D91 RID: 36241 RVA: 0x0004519A File Offset: 0x0004339A
		' (set) Token: 0x06008D92 RID: 36242 RVA: 0x00679954 File Offset: 0x00677B54
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

		' Token: 0x17003433 RID: 13363
		' (get) Token: 0x06008D93 RID: 36243 RVA: 0x000451A4 File Offset: 0x000433A4
		' (set) Token: 0x06008D94 RID: 36244 RVA: 0x00679998 File Offset: 0x00677B98
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

		' Token: 0x17003434 RID: 13364
		' (get) Token: 0x06008D95 RID: 36245 RVA: 0x000451AE File Offset: 0x000433AE
		' (set) Token: 0x06008D96 RID: 36246 RVA: 0x006799DC File Offset: 0x00677BDC
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

		' Token: 0x17003435 RID: 13365
		' (get) Token: 0x06008D97 RID: 36247 RVA: 0x000451B8 File Offset: 0x000433B8
		' (set) Token: 0x06008D98 RID: 36248 RVA: 0x00679A20 File Offset: 0x00677C20
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

		' Token: 0x17003436 RID: 13366
		' (get) Token: 0x06008D99 RID: 36249 RVA: 0x000451C2 File Offset: 0x000433C2
		' (set) Token: 0x06008D9A RID: 36250 RVA: 0x00679A64 File Offset: 0x00677C64
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

		' Token: 0x17003437 RID: 13367
		' (get) Token: 0x06008D9B RID: 36251 RVA: 0x000451CC File Offset: 0x000433CC
		' (set) Token: 0x06008D9C RID: 36252 RVA: 0x000451D6 File Offset: 0x000433D6
		Friend Overridable Property lblUser As Label

		' Token: 0x17003438 RID: 13368
		' (get) Token: 0x06008D9D RID: 36253 RVA: 0x000451DF File Offset: 0x000433DF
		' (set) Token: 0x06008D9E RID: 36254 RVA: 0x000451E9 File Offset: 0x000433E9
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003439 RID: 13369
		' (get) Token: 0x06008D9F RID: 36255 RVA: 0x000451F2 File Offset: 0x000433F2
		' (set) Token: 0x06008DA0 RID: 36256 RVA: 0x000451FC File Offset: 0x000433FC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700343A RID: 13370
		' (get) Token: 0x06008DA1 RID: 36257 RVA: 0x00045205 File Offset: 0x00043405
		' (set) Token: 0x06008DA2 RID: 36258 RVA: 0x0004520F File Offset: 0x0004340F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700343B RID: 13371
		' (get) Token: 0x06008DA3 RID: 36259 RVA: 0x00045218 File Offset: 0x00043418
		' (set) Token: 0x06008DA4 RID: 36260 RVA: 0x00045222 File Offset: 0x00043422
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700343C RID: 13372
		' (get) Token: 0x06008DA5 RID: 36261 RVA: 0x0004522B File Offset: 0x0004342B
		' (set) Token: 0x06008DA6 RID: 36262 RVA: 0x00045235 File Offset: 0x00043435
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700343D RID: 13373
		' (get) Token: 0x06008DA7 RID: 36263 RVA: 0x0004523E File Offset: 0x0004343E
		' (set) Token: 0x06008DA8 RID: 36264 RVA: 0x00045248 File Offset: 0x00043448
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700343E RID: 13374
		' (get) Token: 0x06008DA9 RID: 36265 RVA: 0x00045251 File Offset: 0x00043451
		' (set) Token: 0x06008DAA RID: 36266 RVA: 0x0004525B File Offset: 0x0004345B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700343F RID: 13375
		' (get) Token: 0x06008DAB RID: 36267 RVA: 0x00045264 File Offset: 0x00043464
		' (set) Token: 0x06008DAC RID: 36268 RVA: 0x0004526E File Offset: 0x0004346E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003440 RID: 13376
		' (get) Token: 0x06008DAD RID: 36269 RVA: 0x00045277 File Offset: 0x00043477
		' (set) Token: 0x06008DAE RID: 36270 RVA: 0x00045281 File Offset: 0x00043481
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17003441 RID: 13377
		' (get) Token: 0x06008DAF RID: 36271 RVA: 0x0004528A File Offset: 0x0004348A
		' (set) Token: 0x06008DB0 RID: 36272 RVA: 0x00045294 File Offset: 0x00043494
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003442 RID: 13378
		' (get) Token: 0x06008DB1 RID: 36273 RVA: 0x0004529D File Offset: 0x0004349D
		' (set) Token: 0x06008DB2 RID: 36274 RVA: 0x000452A7 File Offset: 0x000434A7
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003443 RID: 13379
		' (get) Token: 0x06008DB3 RID: 36275 RVA: 0x000452B0 File Offset: 0x000434B0
		' (set) Token: 0x06008DB4 RID: 36276 RVA: 0x000452BA File Offset: 0x000434BA
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003444 RID: 13380
		' (get) Token: 0x06008DB5 RID: 36277 RVA: 0x000452C3 File Offset: 0x000434C3
		' (set) Token: 0x06008DB6 RID: 36278 RVA: 0x000452CD File Offset: 0x000434CD
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003445 RID: 13381
		' (get) Token: 0x06008DB7 RID: 36279 RVA: 0x000452D6 File Offset: 0x000434D6
		' (set) Token: 0x06008DB8 RID: 36280 RVA: 0x000452E0 File Offset: 0x000434E0
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003446 RID: 13382
		' (get) Token: 0x06008DB9 RID: 36281 RVA: 0x000452E9 File Offset: 0x000434E9
		' (set) Token: 0x06008DBA RID: 36282 RVA: 0x000452F3 File Offset: 0x000434F3
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003447 RID: 13383
		' (get) Token: 0x06008DBB RID: 36283 RVA: 0x000452FC File Offset: 0x000434FC
		' (set) Token: 0x06008DBC RID: 36284 RVA: 0x00045306 File Offset: 0x00043506
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003448 RID: 13384
		' (get) Token: 0x06008DBD RID: 36285 RVA: 0x0004530F File Offset: 0x0004350F
		' (set) Token: 0x06008DBE RID: 36286 RVA: 0x00045319 File Offset: 0x00043519
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17003449 RID: 13385
		' (get) Token: 0x06008DBF RID: 36287 RVA: 0x00045322 File Offset: 0x00043522
		' (set) Token: 0x06008DC0 RID: 36288 RVA: 0x0004532C File Offset: 0x0004352C
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700344A RID: 13386
		' (get) Token: 0x06008DC1 RID: 36289 RVA: 0x00045335 File Offset: 0x00043535
		' (set) Token: 0x06008DC2 RID: 36290 RVA: 0x0004533F File Offset: 0x0004353F
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700344B RID: 13387
		' (get) Token: 0x06008DC3 RID: 36291 RVA: 0x00045348 File Offset: 0x00043548
		' (set) Token: 0x06008DC4 RID: 36292 RVA: 0x00045352 File Offset: 0x00043552
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700344C RID: 13388
		' (get) Token: 0x06008DC5 RID: 36293 RVA: 0x0004535B File Offset: 0x0004355B
		' (set) Token: 0x06008DC6 RID: 36294 RVA: 0x00045365 File Offset: 0x00043565
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700344D RID: 13389
		' (get) Token: 0x06008DC7 RID: 36295 RVA: 0x0004536E File Offset: 0x0004356E
		' (set) Token: 0x06008DC8 RID: 36296 RVA: 0x00045378 File Offset: 0x00043578
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700344E RID: 13390
		' (get) Token: 0x06008DC9 RID: 36297 RVA: 0x00045381 File Offset: 0x00043581
		' (set) Token: 0x06008DCA RID: 36298 RVA: 0x0004538B File Offset: 0x0004358B
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700344F RID: 13391
		' (get) Token: 0x06008DCB RID: 36299 RVA: 0x00045394 File Offset: 0x00043594
		' (set) Token: 0x06008DCC RID: 36300 RVA: 0x0004539E File Offset: 0x0004359E
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003450 RID: 13392
		' (get) Token: 0x06008DCD RID: 36301 RVA: 0x000453A7 File Offset: 0x000435A7
		' (set) Token: 0x06008DCE RID: 36302 RVA: 0x000453B1 File Offset: 0x000435B1
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003451 RID: 13393
		' (get) Token: 0x06008DCF RID: 36303 RVA: 0x000453BA File Offset: 0x000435BA
		' (set) Token: 0x06008DD0 RID: 36304 RVA: 0x000453C4 File Offset: 0x000435C4
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003452 RID: 13394
		' (get) Token: 0x06008DD1 RID: 36305 RVA: 0x000453CD File Offset: 0x000435CD
		' (set) Token: 0x06008DD2 RID: 36306 RVA: 0x000453D7 File Offset: 0x000435D7
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17003453 RID: 13395
		' (get) Token: 0x06008DD3 RID: 36307 RVA: 0x000453E0 File Offset: 0x000435E0
		' (set) Token: 0x06008DD4 RID: 36308 RVA: 0x000453EA File Offset: 0x000435EA
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003454 RID: 13396
		' (get) Token: 0x06008DD5 RID: 36309 RVA: 0x000453F3 File Offset: 0x000435F3
		' (set) Token: 0x06008DD6 RID: 36310 RVA: 0x000453FD File Offset: 0x000435FD
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003455 RID: 13397
		' (get) Token: 0x06008DD7 RID: 36311 RVA: 0x00045406 File Offset: 0x00043606
		' (set) Token: 0x06008DD8 RID: 36312 RVA: 0x00045410 File Offset: 0x00043610
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003456 RID: 13398
		' (get) Token: 0x06008DD9 RID: 36313 RVA: 0x00045419 File Offset: 0x00043619
		' (set) Token: 0x06008DDA RID: 36314 RVA: 0x00045423 File Offset: 0x00043623
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003457 RID: 13399
		' (get) Token: 0x06008DDB RID: 36315 RVA: 0x0004542C File Offset: 0x0004362C
		' (set) Token: 0x06008DDC RID: 36316 RVA: 0x00045436 File Offset: 0x00043636
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003458 RID: 13400
		' (get) Token: 0x06008DDD RID: 36317 RVA: 0x0004543F File Offset: 0x0004363F
		' (set) Token: 0x06008DDE RID: 36318 RVA: 0x00045449 File Offset: 0x00043649
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003459 RID: 13401
		' (get) Token: 0x06008DDF RID: 36319 RVA: 0x00045452 File Offset: 0x00043652
		' (set) Token: 0x06008DE0 RID: 36320 RVA: 0x0004545C File Offset: 0x0004365C
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700345A RID: 13402
		' (get) Token: 0x06008DE1 RID: 36321 RVA: 0x00045465 File Offset: 0x00043665
		' (set) Token: 0x06008DE2 RID: 36322 RVA: 0x0004546F File Offset: 0x0004366F
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700345B RID: 13403
		' (get) Token: 0x06008DE3 RID: 36323 RVA: 0x00045478 File Offset: 0x00043678
		' (set) Token: 0x06008DE4 RID: 36324 RVA: 0x00045482 File Offset: 0x00043682
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x1700345C RID: 13404
		' (get) Token: 0x06008DE5 RID: 36325 RVA: 0x0004548B File Offset: 0x0004368B
		' (set) Token: 0x06008DE6 RID: 36326 RVA: 0x00045495 File Offset: 0x00043695
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700345D RID: 13405
		' (get) Token: 0x06008DE7 RID: 36327 RVA: 0x0004549E File Offset: 0x0004369E
		' (set) Token: 0x06008DE8 RID: 36328 RVA: 0x000454A8 File Offset: 0x000436A8
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700345E RID: 13406
		' (get) Token: 0x06008DE9 RID: 36329 RVA: 0x000454B1 File Offset: 0x000436B1
		' (set) Token: 0x06008DEA RID: 36330 RVA: 0x000454BB File Offset: 0x000436BB
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700345F RID: 13407
		' (get) Token: 0x06008DEB RID: 36331 RVA: 0x000454C4 File Offset: 0x000436C4
		' (set) Token: 0x06008DEC RID: 36332 RVA: 0x000454CE File Offset: 0x000436CE
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17003460 RID: 13408
		' (get) Token: 0x06008DED RID: 36333 RVA: 0x000454D7 File Offset: 0x000436D7
		' (set) Token: 0x06008DEE RID: 36334 RVA: 0x000454E1 File Offset: 0x000436E1
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17003461 RID: 13409
		' (get) Token: 0x06008DEF RID: 36335 RVA: 0x000454EA File Offset: 0x000436EA
		' (set) Token: 0x06008DF0 RID: 36336 RVA: 0x000454F4 File Offset: 0x000436F4
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17003462 RID: 13410
		' (get) Token: 0x06008DF1 RID: 36337 RVA: 0x000454FD File Offset: 0x000436FD
		' (set) Token: 0x06008DF2 RID: 36338 RVA: 0x00045507 File Offset: 0x00043707
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17003463 RID: 13411
		' (get) Token: 0x06008DF3 RID: 36339 RVA: 0x00045510 File Offset: 0x00043710
		' (set) Token: 0x06008DF4 RID: 36340 RVA: 0x0004551A File Offset: 0x0004371A
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17003464 RID: 13412
		' (get) Token: 0x06008DF5 RID: 36341 RVA: 0x00045523 File Offset: 0x00043723
		' (set) Token: 0x06008DF6 RID: 36342 RVA: 0x0004552D File Offset: 0x0004372D
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17003465 RID: 13413
		' (get) Token: 0x06008DF7 RID: 36343 RVA: 0x00045536 File Offset: 0x00043736
		' (set) Token: 0x06008DF8 RID: 36344 RVA: 0x00045540 File Offset: 0x00043740
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17003466 RID: 13414
		' (get) Token: 0x06008DF9 RID: 36345 RVA: 0x00045549 File Offset: 0x00043749
		' (set) Token: 0x06008DFA RID: 36346 RVA: 0x00045553 File Offset: 0x00043753
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17003467 RID: 13415
		' (get) Token: 0x06008DFB RID: 36347 RVA: 0x0004555C File Offset: 0x0004375C
		' (set) Token: 0x06008DFC RID: 36348 RVA: 0x00045566 File Offset: 0x00043766
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x17003468 RID: 13416
		' (get) Token: 0x06008DFD RID: 36349 RVA: 0x0004556F File Offset: 0x0004376F
		' (set) Token: 0x06008DFE RID: 36350 RVA: 0x00045579 File Offset: 0x00043779
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x06008DFF RID: 36351 RVA: 0x00679AA8 File Offset: 0x00677CA8
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

		' Token: 0x06008E00 RID: 36352 RVA: 0x00141E1C File Offset: 0x0014001C
		Private Sub ApplyRowColor(row As DataGridViewRow, status As String)
			Dim flag As Boolean = Operators.CompareString(status, "Pending", False) = 0
			If flag Then
				row.DefaultCellStyle.BackColor = Color.Red
				row.DefaultCellStyle.ForeColor = Color.White
			Else
				row.DefaultCellStyle.BackColor = Color.LightGreen
				row.DefaultCellStyle.ForeColor = Color.Black
			End If
		End Sub

		' Token: 0x06008E01 RID: 36353 RVA: 0x00679B8C File Offset: 0x00677D8C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and Operator=@d3 order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Dim flag2 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) <> 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.VarChar).Value = Me.lblUser.Text
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008E02 RID: 36354 RVA: 0x0067A09C File Offset: 0x0067829C
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

		' Token: 0x06008E03 RID: 36355 RVA: 0x0067A170 File Offset: 0x00678370
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
			Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
			If flag Then
				Me.lblOperator.Visible = True
				Me.ComboBox3.Visible = True
			Else
				Me.lblOperator.Visible = False
				Me.ComboBox3.Visible = False
			End If
			Me.Convert_Language()
		End Sub

		' Token: 0x06008E04 RID: 36356 RVA: 0x0067A300 File Offset: 0x00678500
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

		' Token: 0x06008E05 RID: 36357 RVA: 0x0067A478 File Offset: 0x00678678
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

		' Token: 0x06008E06 RID: 36358 RVA: 0x0067A544 File Offset: 0x00678744
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

		' Token: 0x06008E07 RID: 36359 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06008E08 RID: 36360 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06008E09 RID: 36361 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06008E0A RID: 36362 RVA: 0x0067A610 File Offset: 0x00678810
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06008E0B RID: 36363 RVA: 0x00045582 File Offset: 0x00043782
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06008E0C RID: 36364 RVA: 0x0067A638 File Offset: 0x00678838
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Touch NewSales Invoice", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSNewTuch_Quotation.Show()
						MyBase.Hide()
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
						Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag3 Then
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
						Dim flag4 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
						If flag4 Then
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
						Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text, "TCS", False) = 0
						If flag5 Then
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
					Dim flag6 As Boolean = Operators.CompareString(Me.lblSet.Text, "Quotation", False) = 0
					If flag6 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim flag7 As Boolean = Operators.CompareString(dataGridViewRow2.Cells(46).Value.ToString(), "Generated", False) = 0
						If flag7 Then
							MessageBox.Show("This Quotaion have already Bill Generate!")
							Return
						End If
						MyProject.Forms.frmPOSNewTuch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch.Reset()
						MyProject.Forms.frmPOSNewTuch.lblQuotation_No.Text = dataGridViewRow2.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow2.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGSTNonGST.Text = dataGridViewRow2.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow2.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow2.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.Label202.Text = dataGridViewRow2.Cells(5).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow2.Cells(4).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow2.Cells(6).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow2.Cells(7).Value.ToString()
						Dim flag8 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag8 Then
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow2.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow2.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow2.Cells(10).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow2.Cells(11).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow2.Cells(12).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSubTotal.Text = dataGridViewRow2.Cells(13).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCGST.Text = dataGridViewRow2.Cells(14).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSGST.Text = dataGridViewRow2.Cells(15).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtIGST.Text = dataGridViewRow2.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCESS.Text = dataGridViewRow2.Cells(17).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtFreightCharges.Text = dataGridViewRow2.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtBillDiscount.Text = dataGridViewRow2.Cells(19).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotal.Text = dataGridViewRow2.Cells(20).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtRoundOff.Text = dataGridViewRow2.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGrandTotal.Text = dataGridViewRow2.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = dataGridViewRow2.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtPaymentDue.Text = dataGridViewRow2.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtNar.Text = dataGridViewRow2.Cells(26).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txteway.Text = dataGridViewRow2.Cells(27).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text = dataGridViewRow2.Cells(30).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtOffer.Text = dataGridViewRow2.Cells(31).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtApplyPoint.Text = dataGridViewRow2.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtLAmt.Text = dataGridViewRow2.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtbilldisc.Text = dataGridViewRow2.Cells(33).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = dataGridViewRow2.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow2.Cells(35).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow2.Cells(36).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow2.Cells(37).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow2.Cells(40).Value.ToString()
						Dim flag9 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow2.Cells(32).Value, 0, False)
						If flag9 Then
							MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
						Else
							MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
						End If
						MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow2.Cells(38).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow2.Cells(39).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtByReturn.Text = dataGridViewRow2.Cells(42).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTotalLoyality_points.Text = dataGridViewRow2.Cells(43).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblTPoints1.Text = dataGridViewRow2.Cells(44).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblTPointsAmt1.Text = dataGridViewRow2.Cells(45).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.TextBox43.Text = dataGridViewRow2.Cells(45).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblLead_Id.Text = dataGridViewRow2.Cells(48).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
						MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text4 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin,Invoiceinfo_Product_Quotation.Descr,Invoiceinfo_Product_Quotation.Qty,RTRIM(Invoiceinfo_Product_Quotation.IM1),RTRIM(Invoiceinfo_Product_Quotation.IM2),(Invoiceinfo_Product_Quotation.MRP),(Invoiceinfo_Product_Quotation.TaxableAmt),(Invoiceinfo_Product_Quotation.AltQty),(Invoiceinfo_Product_Quotation.AltUnit),(Invoiceinfo_Product_Quotation.STaxType),(Invoiceinfo_Product_Quotation.TotalMRP),(Invoiceinfo_Product_Quotation.PromoQty),RTRIM(Invoiceinfo_Product_Quotation.MainUnit),RTRIM(Invoiceinfo_Product_Quotation.Batch),RTRIM(Invoiceinfo_Product_Quotation.Mfg),RTRIM(Invoiceinfo_Product_Quotation.Exp),RTRIM(Invoiceinfo_Product_Quotation.Size),RTRIM(Invoiceinfo_Product_Quotation.Colour),Invoiceinfo_Product_Quotation.SalesManID,Invoiceinfo_Product_Quotation.SalesMan,Invoiceinfo_Product_Quotation.SalesManPur,Invoiceinfo_Product_Quotation.SalesManComm ,Invoiceinfo_Product_Quotation.StockID, Invoiceinfo_Product_Quotation.LoyalityPoints from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
						End While
						MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text5 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text5, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
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
						Dim flag10 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text, "TCS", False) = 0
						If flag10 Then
							MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
						Else
							MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
							MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = "0"
						End If
						MyProject.Forms.frmPOSNewTuch.CTypeStatus()
						MyProject.Forms.frmPOSNewTuch.BrokerRetrive()
					End If
					Dim flag11 As Boolean = Operators.CompareString(Me.lblSet.Text, "Quotation_frmPOSTouch", False) = 0
					If flag11 Then
						Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim flag12 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(46).Value.ToString(), "Generated", False) = 0
						If flag12 Then
							MessageBox.Show("This Quotaion have already Bill Generate!")
						Else
							MyProject.Forms.frmPOSTouch.Show()
							MyBase.Hide()
							MyProject.Forms.frmPOSTouch.lblQuotation_No.Text = dataGridViewRow3.Cells(0).Value.ToString()
							MyProject.Forms.frmPOSTouch.dtpInvoiceDate.Text = dataGridViewRow3.Cells(2).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtGSTNonGST.Text = dataGridViewRow3.Cells(3).Value.ToString()
							MyProject.Forms.frmPOSTouch.TextBox7.Text = dataGridViewRow3.Cells(3).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow3.Cells(5).Value.ToString()
							MyProject.Forms.frmPOSTouch.Label202.Text = dataGridViewRow3.Cells(5).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow3.Cells(4).Value.ToString()
							MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow3.Cells(6).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow3.Cells(7).Value.ToString()
							Dim flag13 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
							If flag13 Then
								MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = MyProject.Forms.frmPOSTouch.txtCompanyState.Text
							Else
								MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow3.Cells(8).Value.ToString()
							End If
							MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow3.Cells(9).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSM_ID.Text = dataGridViewRow3.Cells(10).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = dataGridViewRow3.Cells(11).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSalesman.Text = dataGridViewRow3.Cells(12).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSubTotal.Text = dataGridViewRow3.Cells(13).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtCGST.Text = dataGridViewRow3.Cells(14).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSGST.Text = dataGridViewRow3.Cells(15).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtIGST.Text = dataGridViewRow3.Cells(16).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtCESS.Text = dataGridViewRow3.Cells(17).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtFreightCharges.Text = dataGridViewRow3.Cells(18).Value.ToString()
							MyProject.Forms.frmPOSTouch.TextBox44.Text = dataGridViewRow3.Cells(19).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtBillDiscount.Text = dataGridViewRow3.Cells(19).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtTotal.Text = dataGridViewRow3.Cells(20).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtRoundOff.Text = dataGridViewRow3.Cells(21).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtGrandTotal.Text = dataGridViewRow3.Cells(22).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = dataGridViewRow3.Cells(23).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtPaymentDue.Text = dataGridViewRow3.Cells(24).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtNar.Text = dataGridViewRow3.Cells(26).Value.ToString()
							MyProject.Forms.frmPOSTouch.txteway.Text = dataGridViewRow3.Cells(27).Value.ToString()
							MyProject.Forms.frmPOSTouch.cmbBSundry.Text = dataGridViewRow3.Cells(30).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtOffer.Text = dataGridViewRow3.Cells(31).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtApplyPoint.Text = dataGridViewRow3.Cells(32).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtLAmt.Text = dataGridViewRow3.Cells(32).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtbilldisc.Text = dataGridViewRow3.Cells(33).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtTCSdbl.Text = dataGridViewRow3.Cells(18).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtTendAmt.Text = dataGridViewRow3.Cells(35).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtRefAmt.Text = dataGridViewRow3.Cells(36).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtBillAmt.Text = dataGridViewRow3.Cells(37).Value.ToString()
							MyProject.Forms.frmPOSTouch.CAddress = dataGridViewRow3.Cells(40).Value.ToString()
							Dim flag14 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow3.Cells(32).Value, 0, False)
							If flag14 Then
								MyProject.Forms.frmPOSTouch.cb1.Checked = True
							Else
								MyProject.Forms.frmPOSTouch.cb1.Checked = False
							End If
							MyProject.Forms.frmPOSTouch.txtCoupAmt.Text = dataGridViewRow3.Cells(38).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtgiftamt.Text = dataGridViewRow3.Cells(39).Value.ToString()
							MyProject.Forms.frmPOSTouch.lblSalesReturnNo.Text = dataGridViewRow3.Cells(41).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtByReturn.Text = dataGridViewRow3.Cells(42).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtTotalLoyality_points.Text = dataGridViewRow3.Cells(43).Value.ToString()
							MyProject.Forms.frmPOSTouch.lblTPoints1.Text = dataGridViewRow3.Cells(44).Value.ToString()
							MyProject.Forms.frmPOSTouch.lblTPointsAmt1.Text = dataGridViewRow3.Cells(45).Value.ToString()
							MyProject.Forms.frmPOSTouch.TextBox43.Text = dataGridViewRow3.Cells(45).Value.ToString()
							MyProject.Forms.frmPOSTouch.lblLead_Id.Text = dataGridViewRow3.Cells(48).Value.ToString()
							Dim flag15 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.txtByReturn.Text, "", False) = 0
							If flag15 Then
								MyProject.Forms.frmPOSTouch.txtByReturn.Text = Conversions.ToString(0.0)
							End If
							MyProject.Forms.frmPOSTouch.txtOffer.Text = "0.00"
							MyProject.Forms.frmPOSTouch.GridGetCustomer.Visible = False
							Dim flag16 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
							If flag16 Then
								MyProject.Forms.frmPOSTouch.btnUpdate.Enabled = True
								MyProject.Forms.frmPOSTouch.btnDelete.Enabled = True
							Else
								MyProject.Forms.frmPOSTouch.btnUpdate.Enabled = False
								MyProject.Forms.frmPOSTouch.btnDelete.Enabled = False
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text6 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin,Invoiceinfo_Product_Quotation.Descr,Invoiceinfo_Product_Quotation.Qty,RTRIM(Invoiceinfo_Product_Quotation.IM1),RTRIM(Invoiceinfo_Product_Quotation.IM2),(Invoiceinfo_Product_Quotation.MRP),(Invoiceinfo_Product_Quotation.TaxableAmt),(Invoiceinfo_Product_Quotation.AltQty),(Invoiceinfo_Product_Quotation.AltUnit),(Invoiceinfo_Product_Quotation.STaxType),(Invoiceinfo_Product_Quotation.TotalMRP),(Invoiceinfo_Product_Quotation.PromoQty),RTRIM(Invoiceinfo_Product_Quotation.MainUnit),RTRIM(Invoiceinfo_Product_Quotation.Batch),RTRIM(Invoiceinfo_Product_Quotation.Mfg),RTRIM(Invoiceinfo_Product_Quotation.Exp),RTRIM(Invoiceinfo_Product_Quotation.Size),RTRIM(Invoiceinfo_Product_Quotation.Colour),Invoiceinfo_Product_Quotation.SalesManID,Invoiceinfo_Product_Quotation.SalesMan,Invoiceinfo_Product_Quotation.SalesManPur,Invoiceinfo_Product_Quotation.SalesManComm ,Invoiceinfo_Product_Quotation.StockID, Invoiceinfo_Product_Quotation.LoyalityPoints from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text6, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
							MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Clear()
							While ModCommonClasses.rdr.Read()
								MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), MyProject.Forms.frmPOSTouch.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
							End While
							MyProject.Forms.frmPOSTouch.DataGridView1.ClearSelection()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text7 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin, Invoiceinfo_Product_Quotation.LoyalityPoints from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text7, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
							MyProject.Forms.frmPOSTouch.DataGridView3.Rows.Clear()
							While ModCommonClasses.rdr.Read()
								MyProject.Forms.frmPOSTouch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
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
							Dim flag17 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbBSundry.Text, "TCS", False) = 0
							If flag17 Then
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
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008E0D RID: 36365 RVA: 0x0067DB48 File Offset: 0x0067BD48
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

		' Token: 0x06008E0E RID: 36366 RVA: 0x0067DC30 File Offset: 0x0067BE30
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				sqlCommand.Connection = ModCommonClasses.con
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					sqlCommand.CommandText = "SELECT DISTINCT RTRIM(InvoiceNo) FROM Invoiceinfo_Quotation"
				Else
					sqlCommand.CommandText = "SELECT DISTINCT RTRIM(InvoiceNo) FROM Invoiceinfo_Quotation WHERE Operator = @d3"
					sqlCommand.Parameters.Add("@d3", SqlDbType.VarChar).Value = Me.lblUser.Text
				End If
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet)
				Me.cmbInvoiceNo.Items.Clear()
				Try
					For Each obj As Object In dataSet.Tables(0).Rows
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

		' Token: 0x06008E0F RID: 36367 RVA: 0x0067DDB8 File Offset: 0x0067BFB8
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

		' Token: 0x06008E10 RID: 36368 RVA: 0x0067DEAC File Offset: 0x0067C0AC
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select top 10 Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceNo='" + Me.cmbInvoiceNo.Text + "' order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select top 10 Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceNo='", Me.cmbInvoiceNo.Text, "' and Operator='", Me.lblUser.Text, "' order by InvoiceDate" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E11 RID: 36369 RVA: 0x0067E3E0 File Offset: 0x0067C5E0
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.Name like N'" + Me.txtCustomerName.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.Name like N'", Me.txtCustomerName.Text, "%' and InvoiceDate between @d1 and @d2 and Operator='", Me.lblUser.Text, "' order by InvoiceDate" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E12 RID: 36370 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06008E13 RID: 36371 RVA: 0x0067E9D8 File Offset: 0x0067CBD8
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Salesman.Name like N'" + Me.txtSalesman.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Salesman.Name like N'", Me.txtSalesman.Text, "%' and InvoiceDate between @d1 and @d2 and Operator='", Me.lblUser.Text, "'  order by InvoiceDate" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E14 RID: 36372 RVA: 0x0067EF90 File Offset: 0x0067D190
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.City like N'" + Me.txtCustCity.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.City like N'", Me.txtCustCity.Text, "%' and InvoiceDate between @d1 and @d2 and Operator='", Me.lblUser.Text, "' order by InvoiceDate" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E15 RID: 36373 RVA: 0x0067F548 File Offset: 0x0067D748
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.State like N'" + Me.txtstate.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Customer.State like N'", Me.txtstate.Text, "%' and InvoiceDate between @d1 and @d2 and Operator='", Me.lblUser.Text, "' order by InvoiceDate" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E16 RID: 36374 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06008E17 RID: 36375 RVA: 0x0067FAF0 File Offset: 0x0067DCF0
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

		' Token: 0x06008E18 RID: 36376 RVA: 0x00680054 File Offset: 0x0067E254
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
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE NOT TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
					Else
						ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE NOT TaxType=@d3 and InvoiceDate between @d1 and @d2 and Operator='" + Me.lblUser.Text + "' order by InvoiceDate", ModCommonClasses.con)
					End If
				Else
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag3 Then
						Dim flag4 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
						If flag4 Then
							ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE TaxType=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
						Else
							ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE TaxType=@d3 and InvoiceDate between @d1 and @d2 and Operator='" + Me.lblUser.Text + "' order by InvoiceDate", ModCommonClasses.con)
						End If
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr1(43), ModCommonClasses.rdr1(44), ModCommonClasses.rdr1(45), ModCommonClasses.rdr1(46), ModCommonClasses.rdr1(47) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E19 RID: 36377 RVA: 0x00680628 File Offset: 0x0067E828
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

		' Token: 0x06008E1A RID: 36378 RVA: 0x0068075C File Offset: 0x0067E95C
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE TillID=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE TillID=@d3 and InvoiceDate between @d1 and @d2 and Operator='" + Me.lblUser.Text + "' order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr1(43), ModCommonClasses.rdr1(44), ModCommonClasses.rdr1(45), ModCommonClasses.rdr1(46), ModCommonClasses.rdr1(47) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E1B RID: 36379 RVA: 0x00680CC0 File Offset: 0x0067EEC0
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
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID WHERE Operator=@d3 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5), ModCommonClasses.rdr1(6), ModCommonClasses.rdr1(7), ModCommonClasses.rdr1(8), ModCommonClasses.rdr1(9), ModCommonClasses.rdr1(10), ModCommonClasses.rdr1(11), ModCommonClasses.rdr1(12), ModCommonClasses.rdr1(13), ModCommonClasses.rdr1(14), ModCommonClasses.rdr1(15), ModCommonClasses.rdr1(16), ModCommonClasses.rdr1(17), ModCommonClasses.rdr1(18), ModCommonClasses.rdr1(19), ModCommonClasses.rdr1(20), ModCommonClasses.rdr1(21), ModCommonClasses.rdr1(22), ModCommonClasses.rdr1(23), ModCommonClasses.rdr1(24), ModCommonClasses.rdr1(25), ModCommonClasses.rdr1(26), ModCommonClasses.rdr1(27), ModCommonClasses.rdr1(28), ModCommonClasses.rdr1(29), ModCommonClasses.rdr1(30), ModCommonClasses.rdr1(31), ModCommonClasses.rdr1(32), ModCommonClasses.rdr1(33), ModCommonClasses.rdr1(34), ModCommonClasses.rdr1(35), ModCommonClasses.rdr1(36), ModCommonClasses.rdr1(37), ModCommonClasses.rdr1(38), ModCommonClasses.rdr1(39), ModCommonClasses.rdr1(40), ModCommonClasses.rdr1(41), ModCommonClasses.rdr1(42), ModCommonClasses.rdr1(43), ModCommonClasses.rdr1(44), ModCommonClasses.rdr1(45), ModCommonClasses.rdr1(46), ModCommonClasses.rdr1(47) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E1C RID: 36380 RVA: 0x0004558C File Offset: 0x0004378C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06008E1D RID: 36381 RVA: 0x006811DC File Offset: 0x0067F3DC
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

		' Token: 0x06008E1E RID: 36382 RVA: 0x0004559D File Offset: 0x0004379D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesPmtInfo.ShowDialog()
		End Sub

		' Token: 0x06008E1F RID: 36383 RVA: 0x00681488 File Offset: 0x0067F688
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and RTRIM(Operator)='" + Me.lblUser.Text + "' order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E20 RID: 36384 RVA: 0x00681A18 File Offset: 0x0067FC18
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2 from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2 from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and Balance > 0 and Operator='" + Me.lblUser.Text + "'order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E21 RID: 36385 RVA: 0x00681FA8 File Offset: 0x006801A8
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
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Inv_ID between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2,lead_id   from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where Inv_ID between @d1 and @d2 and Operator='" + Me.lblUser.Text + "' order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSlNo1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSlNo2.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008E22 RID: 36386 RVA: 0x000455B0 File Offset: 0x000437B0
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			Me.fillInvoiceNo()
		End Sub

		' Token: 0x06008E23 RID: 36387 RVA: 0x006824E8 File Offset: 0x006806E8
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
				ModCommonClasses.cmd = New SqlCommand("Select top 10 Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway),RTRIM(TillID),RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt from Invoiceinfo_Quotation LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID where InvoiceNo like '%" + Me.cmbInvoiceNo.Text + "%' order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.dgw.Rows(num), ModCommonClasses.rdr(46).ToString())
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
