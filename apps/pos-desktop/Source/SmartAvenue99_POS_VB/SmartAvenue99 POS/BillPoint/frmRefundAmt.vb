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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000205 RID: 517
	<DesignerGenerated()>
	Public Partial Class frmRefundAmt
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060094F9 RID: 38137 RVA: 0x00048F5A File Offset: 0x0004715A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRefundAmt_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmContra_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003752 RID: 14162
		' (get) Token: 0x060094FC RID: 38140 RVA: 0x00048F8C File Offset: 0x0004718C
		' (set) Token: 0x060094FD RID: 38141 RVA: 0x00048F96 File Offset: 0x00047196
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003753 RID: 14163
		' (get) Token: 0x060094FE RID: 38142 RVA: 0x00048F9F File Offset: 0x0004719F
		' (set) Token: 0x060094FF RID: 38143 RVA: 0x00048FA9 File Offset: 0x000471A9
		Friend Overridable Property Label10 As Label

		' Token: 0x17003754 RID: 14164
		' (get) Token: 0x06009500 RID: 38144 RVA: 0x00048FB2 File Offset: 0x000471B2
		' (set) Token: 0x06009501 RID: 38145 RVA: 0x00048FBC File Offset: 0x000471BC
		Friend Overridable Property Label11 As Label

		' Token: 0x17003755 RID: 14165
		' (get) Token: 0x06009502 RID: 38146 RVA: 0x00048FC5 File Offset: 0x000471C5
		' (set) Token: 0x06009503 RID: 38147 RVA: 0x00048FCF File Offset: 0x000471CF
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003756 RID: 14166
		' (get) Token: 0x06009504 RID: 38148 RVA: 0x00048FD8 File Offset: 0x000471D8
		' (set) Token: 0x06009505 RID: 38149 RVA: 0x006B9280 File Offset: 0x006B7480
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003757 RID: 14167
		' (get) Token: 0x06009506 RID: 38150 RVA: 0x00048FE2 File Offset: 0x000471E2
		' (set) Token: 0x06009507 RID: 38151 RVA: 0x00048FEC File Offset: 0x000471EC
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17003758 RID: 14168
		' (get) Token: 0x06009508 RID: 38152 RVA: 0x00048FF5 File Offset: 0x000471F5
		' (set) Token: 0x06009509 RID: 38153 RVA: 0x00048FFF File Offset: 0x000471FF
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17003759 RID: 14169
		' (get) Token: 0x0600950A RID: 38154 RVA: 0x00049008 File Offset: 0x00047208
		' (set) Token: 0x0600950B RID: 38155 RVA: 0x00049012 File Offset: 0x00047212
		Friend Overridable Property Label12 As Label

		' Token: 0x1700375A RID: 14170
		' (get) Token: 0x0600950C RID: 38156 RVA: 0x0004901B File Offset: 0x0004721B
		' (set) Token: 0x0600950D RID: 38157 RVA: 0x00049025 File Offset: 0x00047225
		Friend Overridable Property Label13 As Label

		' Token: 0x1700375B RID: 14171
		' (get) Token: 0x0600950E RID: 38158 RVA: 0x0004902E File Offset: 0x0004722E
		' (set) Token: 0x0600950F RID: 38159 RVA: 0x006B92C4 File Offset: 0x006B74C4
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

		' Token: 0x1700375C RID: 14172
		' (get) Token: 0x06009510 RID: 38160 RVA: 0x00049038 File Offset: 0x00047238
		' (set) Token: 0x06009511 RID: 38161 RVA: 0x006B9308 File Offset: 0x006B7508
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

		' Token: 0x1700375D RID: 14173
		' (get) Token: 0x06009512 RID: 38162 RVA: 0x00049042 File Offset: 0x00047242
		' (set) Token: 0x06009513 RID: 38163 RVA: 0x006B934C File Offset: 0x006B754C
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

		' Token: 0x1700375E RID: 14174
		' (get) Token: 0x06009514 RID: 38164 RVA: 0x0004904C File Offset: 0x0004724C
		' (set) Token: 0x06009515 RID: 38165 RVA: 0x00049056 File Offset: 0x00047256
		Friend Overridable Property Label16 As Label

		' Token: 0x1700375F RID: 14175
		' (get) Token: 0x06009516 RID: 38166 RVA: 0x0004905F File Offset: 0x0004725F
		' (set) Token: 0x06009517 RID: 38167 RVA: 0x00049069 File Offset: 0x00047269
		Friend Overridable Property Label15 As Label

		' Token: 0x17003760 RID: 14176
		' (get) Token: 0x06009518 RID: 38168 RVA: 0x00049072 File Offset: 0x00047272
		' (set) Token: 0x06009519 RID: 38169 RVA: 0x0004907C File Offset: 0x0004727C
		Friend Overridable Property Label14 As Label

		' Token: 0x17003761 RID: 14177
		' (get) Token: 0x0600951A RID: 38170 RVA: 0x00049085 File Offset: 0x00047285
		' (set) Token: 0x0600951B RID: 38171 RVA: 0x006B9390 File Offset: 0x006B7590
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003762 RID: 14178
		' (get) Token: 0x0600951C RID: 38172 RVA: 0x0004908F File Offset: 0x0004728F
		' (set) Token: 0x0600951D RID: 38173 RVA: 0x00049099 File Offset: 0x00047299
		Friend Overridable Property lblUser As Label

		' Token: 0x17003763 RID: 14179
		' (get) Token: 0x0600951E RID: 38174 RVA: 0x000490A2 File Offset: 0x000472A2
		' (set) Token: 0x0600951F RID: 38175 RVA: 0x000490AC File Offset: 0x000472AC
		Friend Overridable Property txtID As TextBox

		' Token: 0x17003764 RID: 14180
		' (get) Token: 0x06009520 RID: 38176 RVA: 0x000490B5 File Offset: 0x000472B5
		' (set) Token: 0x06009521 RID: 38177 RVA: 0x000490BF File Offset: 0x000472BF
		Friend Overridable Property Label1 As Label

		' Token: 0x17003765 RID: 14181
		' (get) Token: 0x06009522 RID: 38178 RVA: 0x000490C8 File Offset: 0x000472C8
		' (set) Token: 0x06009523 RID: 38179 RVA: 0x000490D2 File Offset: 0x000472D2
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17003766 RID: 14182
		' (get) Token: 0x06009524 RID: 38180 RVA: 0x000490DB File Offset: 0x000472DB
		' (set) Token: 0x06009525 RID: 38181 RVA: 0x000490E5 File Offset: 0x000472E5
		Friend Overridable Property Label18 As Label

		' Token: 0x17003767 RID: 14183
		' (get) Token: 0x06009526 RID: 38182 RVA: 0x000490EE File Offset: 0x000472EE
		' (set) Token: 0x06009527 RID: 38183 RVA: 0x000490F8 File Offset: 0x000472F8
		Friend Overridable Property Label17 As Label

		' Token: 0x17003768 RID: 14184
		' (get) Token: 0x06009528 RID: 38184 RVA: 0x00049101 File Offset: 0x00047301
		' (set) Token: 0x06009529 RID: 38185 RVA: 0x0004910B File Offset: 0x0004730B
		Friend Overridable Property Label9 As Label

		' Token: 0x17003769 RID: 14185
		' (get) Token: 0x0600952A RID: 38186 RVA: 0x00049114 File Offset: 0x00047314
		' (set) Token: 0x0600952B RID: 38187 RVA: 0x0004911E File Offset: 0x0004731E
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700376A RID: 14186
		' (get) Token: 0x0600952C RID: 38188 RVA: 0x00049127 File Offset: 0x00047327
		' (set) Token: 0x0600952D RID: 38189 RVA: 0x00049131 File Offset: 0x00047331
		Friend Overridable Property Label8 As Label

		' Token: 0x1700376B RID: 14187
		' (get) Token: 0x0600952E RID: 38190 RVA: 0x0004913A File Offset: 0x0004733A
		' (set) Token: 0x0600952F RID: 38191 RVA: 0x00049144 File Offset: 0x00047344
		Friend Overridable Property Label7 As Label

		' Token: 0x1700376C RID: 14188
		' (get) Token: 0x06009530 RID: 38192 RVA: 0x0004914D File Offset: 0x0004734D
		' (set) Token: 0x06009531 RID: 38193 RVA: 0x006B93F0 File Offset: 0x006B75F0
		Private _txtAmount As TextBox
		Friend Overridable Property txtAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtAmount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAmount_KeyDown
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700376D RID: 14189
		' (get) Token: 0x06009532 RID: 38194 RVA: 0x00049157 File Offset: 0x00047357
		' (set) Token: 0x06009533 RID: 38195 RVA: 0x00049161 File Offset: 0x00047361
		Friend Overridable Property Label6 As Label

		' Token: 0x1700376E RID: 14190
		' (get) Token: 0x06009534 RID: 38196 RVA: 0x0004916A File Offset: 0x0004736A
		' (set) Token: 0x06009535 RID: 38197 RVA: 0x00049174 File Offset: 0x00047374
		Friend Overridable Property txtName As TextBox

		' Token: 0x1700376F RID: 14191
		' (get) Token: 0x06009536 RID: 38198 RVA: 0x0004917D File Offset: 0x0004737D
		' (set) Token: 0x06009537 RID: 38199 RVA: 0x00049187 File Offset: 0x00047387
		Friend Overridable Property Label5 As Label

		' Token: 0x17003770 RID: 14192
		' (get) Token: 0x06009538 RID: 38200 RVA: 0x00049190 File Offset: 0x00047390
		' (set) Token: 0x06009539 RID: 38201 RVA: 0x006B9450 File Offset: 0x006B7650
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003771 RID: 14193
		' (get) Token: 0x0600953A RID: 38202 RVA: 0x0004919A File Offset: 0x0004739A
		' (set) Token: 0x0600953B RID: 38203 RVA: 0x000491A4 File Offset: 0x000473A4
		Friend Overridable Property Label4 As Label

		' Token: 0x17003772 RID: 14194
		' (get) Token: 0x0600953C RID: 38204 RVA: 0x000491AD File Offset: 0x000473AD
		' (set) Token: 0x0600953D RID: 38205 RVA: 0x000491B7 File Offset: 0x000473B7
		Friend Overridable Property Label3 As Label

		' Token: 0x17003773 RID: 14195
		' (get) Token: 0x0600953E RID: 38206 RVA: 0x000491C0 File Offset: 0x000473C0
		' (set) Token: 0x0600953F RID: 38207 RVA: 0x000491CA File Offset: 0x000473CA
		Friend Overridable Property Label2 As Label

		' Token: 0x17003774 RID: 14196
		' (get) Token: 0x06009540 RID: 38208 RVA: 0x000491D3 File Offset: 0x000473D3
		' (set) Token: 0x06009541 RID: 38209 RVA: 0x000491DD File Offset: 0x000473DD
		Friend Overridable Property txtContraID As TextBox

		' Token: 0x17003775 RID: 14197
		' (get) Token: 0x06009542 RID: 38210 RVA: 0x000491E6 File Offset: 0x000473E6
		' (set) Token: 0x06009543 RID: 38211 RVA: 0x006B94B0 File Offset: 0x006B76B0
		Private _cmbTransType As ComboBox
		Friend Overridable Property cmbTransType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTransType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbTransType_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbTransType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbTransType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbTransType = value
				comboBox = Me._cmbTransType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003776 RID: 14198
		' (get) Token: 0x06009544 RID: 38212 RVA: 0x000491F0 File Offset: 0x000473F0
		' (set) Token: 0x06009545 RID: 38213 RVA: 0x006B9510 File Offset: 0x006B7710
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003777 RID: 14199
		' (get) Token: 0x06009546 RID: 38214 RVA: 0x000491FA File Offset: 0x000473FA
		' (set) Token: 0x06009547 RID: 38215 RVA: 0x00049204 File Offset: 0x00047404
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003778 RID: 14200
		' (get) Token: 0x06009548 RID: 38216 RVA: 0x0004920D File Offset: 0x0004740D
		' (set) Token: 0x06009549 RID: 38217 RVA: 0x00049217 File Offset: 0x00047417
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17003779 RID: 14201
		' (get) Token: 0x0600954A RID: 38218 RVA: 0x00049220 File Offset: 0x00047420
		' (set) Token: 0x0600954B RID: 38219 RVA: 0x0004922A File Offset: 0x0004742A
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x1700377A RID: 14202
		' (get) Token: 0x0600954C RID: 38220 RVA: 0x00049233 File Offset: 0x00047433
		' (set) Token: 0x0600954D RID: 38221 RVA: 0x0004923D File Offset: 0x0004743D
		Friend Overridable Property F2 As TextBox

		' Token: 0x1700377B RID: 14203
		' (get) Token: 0x0600954E RID: 38222 RVA: 0x00049246 File Offset: 0x00047446
		' (set) Token: 0x0600954F RID: 38223 RVA: 0x00049250 File Offset: 0x00047450
		Friend Overridable Property F1 As TextBox

		' Token: 0x1700377C RID: 14204
		' (get) Token: 0x06009550 RID: 38224 RVA: 0x00049259 File Offset: 0x00047459
		' (set) Token: 0x06009551 RID: 38225 RVA: 0x006B9554 File Offset: 0x006B7754
		Private _cmbAmtType As ComboBox
		Friend Overridable Property cmbAmtType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAmtType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAmtType_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbAmtType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbAmtType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbAmtType = value
				comboBox = Me._cmbAmtType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700377D RID: 14205
		' (get) Token: 0x06009552 RID: 38226 RVA: 0x00049263 File Offset: 0x00047463
		' (set) Token: 0x06009553 RID: 38227 RVA: 0x0004926D File Offset: 0x0004746D
		Friend Overridable Property Label19 As Label

		' Token: 0x1700377E RID: 14206
		' (get) Token: 0x06009554 RID: 38228 RVA: 0x00049276 File Offset: 0x00047476
		' (set) Token: 0x06009555 RID: 38229 RVA: 0x00049280 File Offset: 0x00047480
		Friend Overridable Property Label20 As Label

		' Token: 0x1700377F RID: 14207
		' (get) Token: 0x06009556 RID: 38230 RVA: 0x00049289 File Offset: 0x00047489
		' (set) Token: 0x06009557 RID: 38231 RVA: 0x00049293 File Offset: 0x00047493
		Friend Overridable Property Label21 As Label

		' Token: 0x17003780 RID: 14208
		' (get) Token: 0x06009558 RID: 38232 RVA: 0x0004929C File Offset: 0x0004749C
		' (set) Token: 0x06009559 RID: 38233 RVA: 0x006B95B4 File Offset: 0x006B77B4
		Private _ComboBox4 As ComboBox
		Friend Overridable Property ComboBox4 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox4_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox4 = value
				comboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003781 RID: 14209
		' (get) Token: 0x0600955A RID: 38234 RVA: 0x000492A6 File Offset: 0x000474A6
		' (set) Token: 0x0600955B RID: 38235 RVA: 0x006B95F8 File Offset: 0x006B77F8
		Private _cmbName As ComboBox
		Friend Overridable Property cmbName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbName_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbName_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbName = value
				comboBox = Me._cmbName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003782 RID: 14210
		' (get) Token: 0x0600955C RID: 38236 RVA: 0x000492B0 File Offset: 0x000474B0
		' (set) Token: 0x0600955D RID: 38237 RVA: 0x000492BA File Offset: 0x000474BA
		Friend Overridable Property LblBenName As Label

		' Token: 0x17003783 RID: 14211
		' (get) Token: 0x0600955E RID: 38238 RVA: 0x000492C3 File Offset: 0x000474C3
		' (set) Token: 0x0600955F RID: 38239 RVA: 0x000492CD File Offset: 0x000474CD
		Friend Overridable Property Label23 As Label

		' Token: 0x17003784 RID: 14212
		' (get) Token: 0x06009560 RID: 38240 RVA: 0x000492D6 File Offset: 0x000474D6
		' (set) Token: 0x06009561 RID: 38241 RVA: 0x000492E0 File Offset: 0x000474E0
		Friend Overridable Property Label22 As Label

		' Token: 0x17003785 RID: 14213
		' (get) Token: 0x06009562 RID: 38242 RVA: 0x000492E9 File Offset: 0x000474E9
		' (set) Token: 0x06009563 RID: 38243 RVA: 0x000492F3 File Offset: 0x000474F3
		Friend Overridable Property Label24 As Label

		' Token: 0x17003786 RID: 14214
		' (get) Token: 0x06009564 RID: 38244 RVA: 0x000492FC File Offset: 0x000474FC
		' (set) Token: 0x06009565 RID: 38245 RVA: 0x00049306 File Offset: 0x00047506
		Friend Overridable Property txtNote As TextBox

		' Token: 0x17003787 RID: 14215
		' (get) Token: 0x06009566 RID: 38246 RVA: 0x0004930F File Offset: 0x0004750F
		' (set) Token: 0x06009567 RID: 38247 RVA: 0x00049319 File Offset: 0x00047519
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003788 RID: 14216
		' (get) Token: 0x06009568 RID: 38248 RVA: 0x00049322 File Offset: 0x00047522
		' (set) Token: 0x06009569 RID: 38249 RVA: 0x0004932C File Offset: 0x0004752C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003789 RID: 14217
		' (get) Token: 0x0600956A RID: 38250 RVA: 0x00049335 File Offset: 0x00047535
		' (set) Token: 0x0600956B RID: 38251 RVA: 0x0004933F File Offset: 0x0004753F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700378A RID: 14218
		' (get) Token: 0x0600956C RID: 38252 RVA: 0x00049348 File Offset: 0x00047548
		' (set) Token: 0x0600956D RID: 38253 RVA: 0x00049352 File Offset: 0x00047552
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700378B RID: 14219
		' (get) Token: 0x0600956E RID: 38254 RVA: 0x0004935B File Offset: 0x0004755B
		' (set) Token: 0x0600956F RID: 38255 RVA: 0x00049365 File Offset: 0x00047565
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700378C RID: 14220
		' (get) Token: 0x06009570 RID: 38256 RVA: 0x0004936E File Offset: 0x0004756E
		' (set) Token: 0x06009571 RID: 38257 RVA: 0x00049378 File Offset: 0x00047578
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700378D RID: 14221
		' (get) Token: 0x06009572 RID: 38258 RVA: 0x00049381 File Offset: 0x00047581
		' (set) Token: 0x06009573 RID: 38259 RVA: 0x0004938B File Offset: 0x0004758B
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700378E RID: 14222
		' (get) Token: 0x06009574 RID: 38260 RVA: 0x00049394 File Offset: 0x00047594
		' (set) Token: 0x06009575 RID: 38261 RVA: 0x0004939E File Offset: 0x0004759E
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700378F RID: 14223
		' (get) Token: 0x06009576 RID: 38262 RVA: 0x000493A7 File Offset: 0x000475A7
		' (set) Token: 0x06009577 RID: 38263 RVA: 0x000493B1 File Offset: 0x000475B1
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003790 RID: 14224
		' (get) Token: 0x06009578 RID: 38264 RVA: 0x000493BA File Offset: 0x000475BA
		' (set) Token: 0x06009579 RID: 38265 RVA: 0x000493C4 File Offset: 0x000475C4
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003791 RID: 14225
		' (get) Token: 0x0600957A RID: 38266 RVA: 0x000493CD File Offset: 0x000475CD
		' (set) Token: 0x0600957B RID: 38267 RVA: 0x000493D7 File Offset: 0x000475D7
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003792 RID: 14226
		' (get) Token: 0x0600957C RID: 38268 RVA: 0x000493E0 File Offset: 0x000475E0
		' (set) Token: 0x0600957D RID: 38269 RVA: 0x006B9658 File Offset: 0x006B7858
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003793 RID: 14227
		' (get) Token: 0x0600957E RID: 38270 RVA: 0x000493EA File Offset: 0x000475EA
		' (set) Token: 0x0600957F RID: 38271 RVA: 0x006B969C File Offset: 0x006B789C
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003794 RID: 14228
		' (get) Token: 0x06009580 RID: 38272 RVA: 0x000493F4 File Offset: 0x000475F4
		' (set) Token: 0x06009581 RID: 38273 RVA: 0x006B96E0 File Offset: 0x006B78E0
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003795 RID: 14229
		' (get) Token: 0x06009582 RID: 38274 RVA: 0x000493FE File Offset: 0x000475FE
		' (set) Token: 0x06009583 RID: 38275 RVA: 0x006B9724 File Offset: 0x006B7924
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003796 RID: 14230
		' (get) Token: 0x06009584 RID: 38276 RVA: 0x00049408 File Offset: 0x00047608
		' (set) Token: 0x06009585 RID: 38277 RVA: 0x006B9768 File Offset: 0x006B7968
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003797 RID: 14231
		' (get) Token: 0x06009586 RID: 38278 RVA: 0x00049412 File Offset: 0x00047612
		' (set) Token: 0x06009587 RID: 38279 RVA: 0x0004941C File Offset: 0x0004761C
		Friend Overridable Property Label25 As Label

		' Token: 0x17003798 RID: 14232
		' (get) Token: 0x06009588 RID: 38280 RVA: 0x00049425 File Offset: 0x00047625
		' (set) Token: 0x06009589 RID: 38281 RVA: 0x0004942F File Offset: 0x0004762F
		Friend Overridable Property Label26 As Label

		' Token: 0x0600958A RID: 38282 RVA: 0x006B97AC File Offset: 0x006B79AC
		Private Sub frmRefundAmt_Load(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.GetCompanyname()
			Me.dtpDate.Value = DateAndTime.Now
			Me.DateFrom.Value = DateAndTime.Now
			Me.DateTo.Value = DateAndTime.Now
			Me.auto()
			Me.fillAccountInfo()
			Me.cih()
			Me.Getdata()
			Me.fillvoucher()
			Me.fillBankAc()
			Me.Label17.Text = "0.00"
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600958B RID: 38283 RVA: 0x006B98CC File Offset: 0x006B7ACC
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600958C RID: 38284 RVA: 0x006B9B6C File Offset: 0x006B7D6C
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

		' Token: 0x0600958D RID: 38285 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600958E RID: 38286 RVA: 0x006B9C38 File Offset: 0x006B7E38
		Private Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.dtpDate.Value = DateAndTime.Now
			Me.DateFrom.Value = DateAndTime.Now
			Me.DateTo.Value = DateAndTime.Now
			Me.auto()
			Me.cih()
			Me.Getdata()
			Me.txtID.Text = ""
			Me.cmbTransType.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.txtAmount.Text = "0.00"
			Me.Button2.Enabled = True
			Me.Button3.Enabled = False
			Me.Button1.Enabled = False
			Me.Label17.Text = "0.00"
			Me.cmbName.SelectedIndex = -1
			Me.txtName.Text = ""
			Me.ComboBox4.SelectedIndex = -1
			Me.cmbAmtType.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.txtNote.Text = ""
			Me.dtpDate.Focus()
			Me.fillvoucher()
			Me.fillBankAc()
		End Sub

		' Token: 0x0600958F RID: 38287 RVA: 0x006B9D9C File Offset: 0x006B7F9C
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
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

		' Token: 0x06009590 RID: 38288 RVA: 0x006B9EEC File Offset: 0x006B80EC
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Journal ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06009591 RID: 38289 RVA: 0x006BA058 File Offset: 0x006B8258
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtContraID.Text = String.Concat(New String() { "JRNL-", Me.GenerateID(), "-", Me.F1.Text, "/", Me.F2.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009592 RID: 38290 RVA: 0x006BA104 File Offset: 0x006B8304
		Public Sub fillAccountInfo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06009593 RID: 38291 RVA: 0x006BA22C File Offset: 0x006B842C
		Private Sub cmbAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration where BankBranch.ID=BankAccountRegistration.BranchID and AccountNo=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.LblBenName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode),IsNull(Sum(Credit)-Sum(Debit),0) from BankAccountRegistration LEFT JOIN BankBranch ON BankAccountRegistration.BranchID = BankBranch.Id LEFT JOIN BankAccountLedger ON BankAccountRegistration.AccountNo = BankAccountLedger.AccNo where AccountNo=@d1 group by AccountName,BankName,BranchName,SwiftCode,IFSCCode"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
				If flag4 Then
					Me.Label17.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
				End If
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag6 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009594 RID: 38292 RVA: 0x006BA444 File Offset: 0x006B8644
		Private Sub cih()
			Me.Label9.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from LedgerBook where Name='Cash Account'"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr1.GetValue(0)))
				If flag3 Then
					Me.Label9.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.Label9.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label9.Text), 2), "0.00")
		End Sub

		' Token: 0x06009595 RID: 38293 RVA: 0x006BA52C File Offset: 0x006B872C
		Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtAmount.Text
					Dim selectionStart As Integer = Me.txtAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtAmount.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06009596 RID: 38294 RVA: 0x006BA624 File Offset: 0x006B8824
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(JID),RTRIM(NameType),RTRIM(Name),RTRIM(CSID),Amt,RTRIM(PayRec),RTRIM(AmtType),RTRIM(BankAcc),RTRIM(Note) from Journal where [Date] between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009597 RID: 38295 RVA: 0x006BA81C File Offset: 0x006B8A1C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.dtpDate.Text = NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Date", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
					Me.txtContraID.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.cmbTransType.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.cmbName.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtName.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtAmount.Text = Conversions.ToString(Conversion.Val(dataGridViewRow.Cells(6).Value.ToString()))
					Me.ComboBox4.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.cmbAmtType.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.cmbAccountNo.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtNote.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.Button3.Enabled = True
					Me.Button1.Enabled = True
					Me.Button2.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009598 RID: 38296 RVA: 0x00049438 File Offset: 0x00047638
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06009599 RID: 38297 RVA: 0x006BAA44 File Offset: 0x006B8C44
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

		' Token: 0x0600959A RID: 38298 RVA: 0x006BAB2C File Offset: 0x006B8D2C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Journal where ID =" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "Deleted the journal voucher id : '" + Me.txtContraID.Text + "'")
					ModFunc.LedgerDelete(Me.txtContraID.Text, "Journal")
					ModFunc.CustomerLedgerDelete(Me.txtContraID.Text)
					ModFunc.SupplierLedgerDelete(Me.txtContraID.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtContraID.Text, "Journal-Bank Account")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag2 Then
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600959B RID: 38299 RVA: 0x006BACD4 File Offset: 0x006B8ED4
		Public Sub fillvoucher()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(JID) FROM Journal", ModCommonClasses.con)
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

		' Token: 0x0600959C RID: 38300 RVA: 0x006BAE08 File Offset: 0x006B9008
		Public Sub fillBankAc()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CSID) FROM Journal", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox3.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox3.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600959D RID: 38301 RVA: 0x006BAF3C File Offset: 0x006B913C
		Public Sub Getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(JID),RTRIM(NameType),RTRIM(Name),RTRIM(CSID),Amt,RTRIM(PayRec),RTRIM(AmtType),RTRIM(BankAcc),RTRIM(Note) from Journal where JID=@d3", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text.ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600959E RID: 38302 RVA: 0x006BB0F0 File Offset: 0x006B92F0
		Public Sub Getdata2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(JID),RTRIM(NameType),RTRIM(Name),RTRIM(CSID),Amt,RTRIM(PayRec),RTRIM(AmtType),RTRIM(BankAcc),RTRIM(Note) from Journal where CSID=@d3 and [Date] between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTo.Value
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text.ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600959F RID: 38303 RVA: 0x006BB310 File Offset: 0x006B9510
		Public Sub Getdata3()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(JID),RTRIM(NameType),RTRIM(Name),RTRIM(CSID),Amt,RTRIM(PayRec),RTRIM(AmtType),RTRIM(BankAcc),RTRIM(Note) from Journal where NameType=@d3 and [Date] between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTo.Value
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text.ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060095A0 RID: 38304 RVA: 0x00049442 File Offset: 0x00047642
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata1()
		End Sub

		' Token: 0x060095A1 RID: 38305 RVA: 0x0004944C File Offset: 0x0004764C
		Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata2()
		End Sub

		' Token: 0x060095A2 RID: 38306 RVA: 0x00049456 File Offset: 0x00047656
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata3()
		End Sub

		' Token: 0x060095A3 RID: 38307 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060095A4 RID: 38308 RVA: 0x006BB530 File Offset: 0x006B9730
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Double = 0.0
				Dim num2 As Double = 0.0
				Dim num3 As Double = 0.0
				Dim num4 As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num4
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value)) And (Me.dgw.Rows(i).Cells(7).Value.ToString().Length > 0)

						If flag Then
							Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(i).Cells(7).Value, "Receive", False)
							If flag2 Then
								num += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))
							Else
								Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(i).Cells(7).Value, "Payment", False)
								If flag3 Then
									num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))
								End If
							End If
						End If
						Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))
						If flag4 Then
							num3 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(6).Value))
						End If

				Next
				Me.Label22.Text = Conversions.ToString(num)
				Me.Label23.Text = Conversions.ToString(num2)
				Me.Label10.Text = Conversions.ToString(num3)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.Label22.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label22.Text), 2), "0.00")
			Me.Label23.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label23.Text), 2), "0.00")
			Me.Label10.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label10.Text), 2), "0.00")
		End Sub

		' Token: 0x060095A5 RID: 38309 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmContra_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060095A6 RID: 38310 RVA: 0x006BB828 File Offset: 0x006B9A28
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,Date,RTRIM(JID),RTRIM(NameType),RTRIM(Name),RTRIM(CSID),Amt,RTRIM(PayRec),RTRIM(AmtType),RTRIM(BankAcc),RTRIM(Note) from Journal where [Date] between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060095A7 RID: 38311 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095A8 RID: 38312 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbTransType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095A9 RID: 38313 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095AA RID: 38314 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095AB RID: 38315 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095AC RID: 38316 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAmtType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095AD RID: 38317 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060095AE RID: 38318 RVA: 0x006BBA20 File Offset: 0x006B9C20
		Private Sub cmbAmtType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbAmtType.SelectedIndex = 1
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x060095AF RID: 38319 RVA: 0x006BBA6C File Offset: 0x006B9C6C
		Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbTransType.SelectedIndex = 0
			If flag Then
				Try
					Me.txtName.Text = ""
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN) from Customer where Name=@d1"
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbName.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.txtName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag5 As Boolean = Me.cmbTransType.SelectedIndex = 1
			If flag5 Then
				Try
					Me.txtName.Text = ""
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT ID,RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(ContactNo) from Supplier where Name=@d1"
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbName.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.txtName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					End If
					Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag7 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag8 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag8 Then
						ModCommonClasses.con.Close()
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060095B0 RID: 38320 RVA: 0x006BBCD8 File Offset: 0x006B9ED8
		Public Sub FillCustomers()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Name) from Customer where not Name in ('Cash') order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060095B1 RID: 38321 RVA: 0x006BBDCC File Offset: 0x006B9FCC
		Public Sub FillSuppliers()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Name) from Supplier order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060095B2 RID: 38322 RVA: 0x006BBEC0 File Offset: 0x006BA0C0
		Private Sub cmbTransType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.cmbName.Items.Clear()
			Me.cmbName.Text = ""
			Me.cmbName.SelectedIndex = -1
			Me.txtName.Text = ""
			Dim flag As Boolean = Me.cmbTransType.SelectedIndex = 0
			If flag Then
				Me.FillCustomers()
			End If
			Dim flag2 As Boolean = Me.cmbTransType.SelectedIndex = 1
			If flag2 Then
				Me.FillSuppliers()
			End If
		End Sub

		' Token: 0x060095B3 RID: 38323 RVA: 0x00049460 File Offset: 0x00047660
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060095B4 RID: 38324 RVA: 0x006BBF44 File Offset: 0x006BA144
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Me.cmbTransType.SelectedIndex = -1
				If flag3 Then
					MessageBox.Show("Please select category (Customer / Supplier)", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbTransType.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbName.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select correct (Customer / Supplier) name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbName.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please select correct (Customer / Supplier) name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbName.Focus()
						Else
							Dim flag6 As Boolean = Me.ComboBox4.SelectedIndex = -1
							If flag6 Then
								MessageBox.Show("Please select transation type (Payment / Receive)", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ComboBox4.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbAmtType.SelectedIndex = -1
								If flag7 Then
									MessageBox.Show("Please select amount type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAmtType.Focus()
								Else
									Dim flag8 As Boolean = Me.cmbAmtType.SelectedIndex = 1
									If flag8 Then
										Dim flag9 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
										If flag9 Then
											MessageBox.Show("Please enter bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.cmbAccountNo.Focus()
											Return
										End If
									End If
									Dim flag10 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
									If flag10 Then
										MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtAmount.Focus()
									Else
										Try
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "update Journal set Date=@d1, JID=@d2, NameType=@d3, Name=@d4, CSID=@d5, Amt=@d6, PayRec=@d7, AmtType=@d8, BankAcc=@d9, Note=@d10 where ID=@d0"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtContraID.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbTransType.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbName.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtName.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtAmount.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.ComboBox4.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cmbAmtType.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtNote.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
											ModFunc.LogFunc(Me.lblUser.Text, "updated the journal voucher having transaction id : '" + Me.txtContraID.Text + "'")
											ModFunc.LedgerDelete(Me.txtContraID.Text, "Journal")
											ModFunc.CustomerLedgerDelete(Me.txtContraID.Text)
											ModFunc.SupplierLedgerDelete(Me.txtContraID.Text)
											ModFunc.BankAccountLedgerDelete(Me.txtContraID.Text, "Journal-Bank Account")
											Dim flag11 As Boolean = Me.cmbTransType.SelectedIndex = 0
											If flag11 Then
												Dim flag12 As Boolean = Me.ComboBox4.SelectedIndex = 1
												If flag12 Then
													Dim flag13 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag13 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
													End If
													Dim flag14 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag14 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
													End If
												End If
												Dim flag15 As Boolean = Me.ComboBox4.SelectedIndex = 0
												If flag15 Then
													Dim flag16 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag16 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
													End If
													Dim flag17 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag17 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
													End If
												End If
											End If
											Dim flag18 As Boolean = Me.cmbTransType.SelectedIndex = 1
											If flag18 Then
												Dim flag19 As Boolean = Me.ComboBox4.SelectedIndex = 1
												If flag19 Then
													Dim flag20 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag20 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
													End If
													Dim flag21 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag21 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
													End If
												End If
												Dim flag22 As Boolean = Me.ComboBox4.SelectedIndex = 0
												If flag22 Then
													Dim flag23 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag23 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
													End If
													Dim flag24 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag24 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
													End If
												End If
											End If
											MessageBox.Show("Successfully Updated", "Journal Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.Reset()
										Catch ex As Exception
											MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060095B5 RID: 38325 RVA: 0x006BCDD8 File Offset: 0x006BAFD8
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060095B6 RID: 38326 RVA: 0x006BCE40 File Offset: 0x006BB040
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Me.auto()
				Dim flag3 As Boolean = Me.cmbTransType.SelectedIndex = -1
				If flag3 Then
					MessageBox.Show("Please select category (Customer / Supplier)", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbTransType.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbName.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select correct (Customer / Supplier) name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbName.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please select correct (Customer / Supplier) name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbName.Focus()
						Else
							Dim flag6 As Boolean = Me.ComboBox4.SelectedIndex = -1
							If flag6 Then
								MessageBox.Show("Please select transation type (Payment / Receive)", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ComboBox4.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbAmtType.SelectedIndex = -1
								If flag7 Then
									MessageBox.Show("Please select amount type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAmtType.Focus()
								Else
									Dim flag8 As Boolean = Me.cmbAmtType.SelectedIndex = 1
									If flag8 Then
										Dim flag9 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
										If flag9 Then
											MessageBox.Show("Please enter bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.cmbAccountNo.Focus()
											Return
										End If
									End If
									Dim flag10 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
									If flag10 Then
										MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtAmount.Focus()
									Else
										Try
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "insert into Journal(ID, Date, JID, NameType, Name, CSID, Amt, PayRec, AmtType, BankAcc, Note) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtContraID.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbTransType.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbName.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtName.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtAmount.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox4.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAmtType.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbAccountNo.Text.ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtNote.Text.ToString())
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModFunc.LogFunc(Me.lblUser.Text, "added the new journal voucher having transaction id : '" + Me.txtContraID.Text + "'")
											Dim flag11 As Boolean = Me.cmbTransType.SelectedIndex = 0
											If flag11 Then
												Dim flag12 As Boolean = Me.ComboBox4.SelectedIndex = 1
												If flag12 Then
													Dim flag13 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag13 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
													End If
													Dim flag14 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag14 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
													End If
												End If
												Dim flag15 As Boolean = Me.ComboBox4.SelectedIndex = 0
												If flag15 Then
													Dim flag16 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag16 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
													End If
													Dim flag17 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag17 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.CustomerLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
													End If
												End If
											End If
											Dim flag18 As Boolean = Me.cmbTransType.SelectedIndex = 1
											If flag18 Then
												Dim flag19 As Boolean = Me.ComboBox4.SelectedIndex = 1
												If flag19 Then
													Dim flag20 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag20 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
													End If
													Dim flag21 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag21 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Receive")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
													End If
												End If
												Dim flag22 As Boolean = Me.ComboBox4.SelectedIndex = 0
												If flag22 Then
													Dim flag23 As Boolean = Me.cmbAmtType.SelectedIndex = 0
													If flag23 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
													End If
													Dim flag24 As Boolean = Me.cmbAmtType.SelectedIndex = 1
													If flag24 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtContraID.Text, "Journal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtName.Text, Me.cmbName.Text + "-" + Me.txtName.Text, "Payment")
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtContraID.Text, "Journal-Bank Account", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
													End If
												End If
											End If
											MessageBox.Show("Successfully Saved", "Journal Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											ModCommonClasses.con.Close()
											Me.Reset()
										Catch ex As Exception
											MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060095B7 RID: 38327 RVA: 0x006BDC8C File Offset: 0x006BBE8C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
