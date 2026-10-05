Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200010D RID: 269
	<DesignerGenerated()>
	Public Partial Class btnGetData
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002BD7 RID: 11223 RVA: 0x0001C036 File Offset: 0x0001A236
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExpiryProduct_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExpiryProduct_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001106 RID: 4358
		' (get) Token: 0x06002BDA RID: 11226 RVA: 0x0001C068 File Offset: 0x0001A268
		' (set) Token: 0x06002BDB RID: 11227 RVA: 0x0001C072 File Offset: 0x0001A272
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001107 RID: 4359
		' (get) Token: 0x06002BDC RID: 11228 RVA: 0x0001C07B File Offset: 0x0001A27B
		' (set) Token: 0x06002BDD RID: 11229 RVA: 0x0001C085 File Offset: 0x0001A285
		Friend Overridable Property Label4 As Label

		' Token: 0x17001108 RID: 4360
		' (get) Token: 0x06002BDE RID: 11230 RVA: 0x0001C08E File Offset: 0x0001A28E
		' (set) Token: 0x06002BDF RID: 11231 RVA: 0x0001C098 File Offset: 0x0001A298
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17001109 RID: 4361
		' (get) Token: 0x06002BE0 RID: 11232 RVA: 0x0001C0A1 File Offset: 0x0001A2A1
		' (set) Token: 0x06002BE1 RID: 11233 RVA: 0x0001C0AB File Offset: 0x0001A2AB
		Friend Overridable Property lblNoOfItems As Label

		' Token: 0x1700110A RID: 4362
		' (get) Token: 0x06002BE2 RID: 11234 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
		' (set) Token: 0x06002BE3 RID: 11235 RVA: 0x0001C0BE File Offset: 0x0001A2BE
		Friend Overridable Property Label5 As Label

		' Token: 0x1700110B RID: 4363
		' (get) Token: 0x06002BE4 RID: 11236 RVA: 0x0001C0C7 File Offset: 0x0001A2C7
		' (set) Token: 0x06002BE5 RID: 11237 RVA: 0x0001C0D1 File Offset: 0x0001A2D1
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700110C RID: 4364
		' (get) Token: 0x06002BE6 RID: 11238 RVA: 0x0001C0DA File Offset: 0x0001A2DA
		' (set) Token: 0x06002BE7 RID: 11239 RVA: 0x0001C0E4 File Offset: 0x0001A2E4
		Friend Overridable Property lblSet As Label

		' Token: 0x1700110D RID: 4365
		' (get) Token: 0x06002BE8 RID: 11240 RVA: 0x0001C0ED File Offset: 0x0001A2ED
		' (set) Token: 0x06002BE9 RID: 11241 RVA: 0x001B28B0 File Offset: 0x001B0AB0
		Private _txtSearch As Button
		Friend Overridable Property txtSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._txtSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim button As Button = Me._txtSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtSearch = value
				button = Me._txtSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700110E RID: 4366
		' (get) Token: 0x06002BEA RID: 11242 RVA: 0x0001C0F7 File Offset: 0x0001A2F7
		' (set) Token: 0x06002BEB RID: 11243 RVA: 0x001B28F4 File Offset: 0x001B0AF4
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700110F RID: 4367
		' (get) Token: 0x06002BEC RID: 11244 RVA: 0x0001C101 File Offset: 0x0001A301
		' (set) Token: 0x06002BED RID: 11245 RVA: 0x0001C10B File Offset: 0x0001A30B
		Friend Overridable Property chkBoxZeroQty As CheckBox

		' Token: 0x17001110 RID: 4368
		' (get) Token: 0x06002BEE RID: 11246 RVA: 0x0001C114 File Offset: 0x0001A314
		' (set) Token: 0x06002BEF RID: 11247 RVA: 0x0001C11E File Offset: 0x0001A31E
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001111 RID: 4369
		' (get) Token: 0x06002BF0 RID: 11248 RVA: 0x0001C127 File Offset: 0x0001A327
		' (set) Token: 0x06002BF1 RID: 11249 RVA: 0x0001C131 File Offset: 0x0001A331
		Friend Overridable Property Label3 As Label

		' Token: 0x17001112 RID: 4370
		' (get) Token: 0x06002BF2 RID: 11250 RVA: 0x0001C13A File Offset: 0x0001A33A
		' (set) Token: 0x06002BF3 RID: 11251 RVA: 0x0001C144 File Offset: 0x0001A344
		Friend Overridable Property Label2 As Label

		' Token: 0x17001113 RID: 4371
		' (get) Token: 0x06002BF4 RID: 11252 RVA: 0x0001C14D File Offset: 0x0001A34D
		' (set) Token: 0x06002BF5 RID: 11253 RVA: 0x001B2938 File Offset: 0x001B0B38
		Private _cmbSearchType As ComboBox
		Friend Overridable Property cmbSearchType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSearchType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSearchType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSearchType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSearchType = value
				comboBox = Me._cmbSearchType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001114 RID: 4372
		' (get) Token: 0x06002BF6 RID: 11254 RVA: 0x0001C157 File Offset: 0x0001A357
		' (set) Token: 0x06002BF7 RID: 11255 RVA: 0x001B297C File Offset: 0x001B0B7C
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

		' Token: 0x17001115 RID: 4373
		' (get) Token: 0x06002BF8 RID: 11256 RVA: 0x0001C161 File Offset: 0x0001A361
		' (set) Token: 0x06002BF9 RID: 11257 RVA: 0x0001C16B File Offset: 0x0001A36B
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17001116 RID: 4374
		' (get) Token: 0x06002BFA RID: 11258 RVA: 0x0001C174 File Offset: 0x0001A374
		' (set) Token: 0x06002BFB RID: 11259 RVA: 0x0001C17E File Offset: 0x0001A37E
		Friend Overridable Property Label10 As Label

		' Token: 0x17001117 RID: 4375
		' (get) Token: 0x06002BFC RID: 11260 RVA: 0x0001C187 File Offset: 0x0001A387
		' (set) Token: 0x06002BFD RID: 11261 RVA: 0x0001C191 File Offset: 0x0001A391
		Friend Overridable Property Label11 As Label

		' Token: 0x17001118 RID: 4376
		' (get) Token: 0x06002BFE RID: 11262 RVA: 0x0001C19A File Offset: 0x0001A39A
		' (set) Token: 0x06002BFF RID: 11263 RVA: 0x0001C1A4 File Offset: 0x0001A3A4
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17001119 RID: 4377
		' (get) Token: 0x06002C00 RID: 11264 RVA: 0x0001C1AD File Offset: 0x0001A3AD
		' (set) Token: 0x06002C01 RID: 11265 RVA: 0x001B29C0 File Offset: 0x001B0BC0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700111A RID: 4378
		' (get) Token: 0x06002C02 RID: 11266 RVA: 0x0001C1B7 File Offset: 0x0001A3B7
		' (set) Token: 0x06002C03 RID: 11267 RVA: 0x0001C1C1 File Offset: 0x0001A3C1
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700111B RID: 4379
		' (get) Token: 0x06002C04 RID: 11268 RVA: 0x0001C1CA File Offset: 0x0001A3CA
		' (set) Token: 0x06002C05 RID: 11269 RVA: 0x0001C1D4 File Offset: 0x0001A3D4
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700111C RID: 4380
		' (get) Token: 0x06002C06 RID: 11270 RVA: 0x0001C1DD File Offset: 0x0001A3DD
		' (set) Token: 0x06002C07 RID: 11271 RVA: 0x0001C1E7 File Offset: 0x0001A3E7
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700111D RID: 4381
		' (get) Token: 0x06002C08 RID: 11272 RVA: 0x0001C1F0 File Offset: 0x0001A3F0
		' (set) Token: 0x06002C09 RID: 11273 RVA: 0x0001C1FA File Offset: 0x0001A3FA
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700111E RID: 4382
		' (get) Token: 0x06002C0A RID: 11274 RVA: 0x0001C203 File Offset: 0x0001A403
		' (set) Token: 0x06002C0B RID: 11275 RVA: 0x0001C20D File Offset: 0x0001A40D
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700111F RID: 4383
		' (get) Token: 0x06002C0C RID: 11276 RVA: 0x0001C216 File Offset: 0x0001A416
		' (set) Token: 0x06002C0D RID: 11277 RVA: 0x0001C220 File Offset: 0x0001A420
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17001120 RID: 4384
		' (get) Token: 0x06002C0E RID: 11278 RVA: 0x0001C229 File Offset: 0x0001A429
		' (set) Token: 0x06002C0F RID: 11279 RVA: 0x0001C233 File Offset: 0x0001A433
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001121 RID: 4385
		' (get) Token: 0x06002C10 RID: 11280 RVA: 0x0001C23C File Offset: 0x0001A43C
		' (set) Token: 0x06002C11 RID: 11281 RVA: 0x0001C246 File Offset: 0x0001A446
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001122 RID: 4386
		' (get) Token: 0x06002C12 RID: 11282 RVA: 0x0001C24F File Offset: 0x0001A44F
		' (set) Token: 0x06002C13 RID: 11283 RVA: 0x0001C259 File Offset: 0x0001A459
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001123 RID: 4387
		' (get) Token: 0x06002C14 RID: 11284 RVA: 0x0001C262 File Offset: 0x0001A462
		' (set) Token: 0x06002C15 RID: 11285 RVA: 0x0001C26C File Offset: 0x0001A46C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17001124 RID: 4388
		' (get) Token: 0x06002C16 RID: 11286 RVA: 0x0001C275 File Offset: 0x0001A475
		' (set) Token: 0x06002C17 RID: 11287 RVA: 0x0001C27F File Offset: 0x0001A47F
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17001125 RID: 4389
		' (get) Token: 0x06002C18 RID: 11288 RVA: 0x0001C288 File Offset: 0x0001A488
		' (set) Token: 0x06002C19 RID: 11289 RVA: 0x0001C292 File Offset: 0x0001A492
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17001126 RID: 4390
		' (get) Token: 0x06002C1A RID: 11290 RVA: 0x0001C29B File Offset: 0x0001A49B
		' (set) Token: 0x06002C1B RID: 11291 RVA: 0x0001C2A5 File Offset: 0x0001A4A5
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17001127 RID: 4391
		' (get) Token: 0x06002C1C RID: 11292 RVA: 0x0001C2AE File Offset: 0x0001A4AE
		' (set) Token: 0x06002C1D RID: 11293 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17001128 RID: 4392
		' (get) Token: 0x06002C1E RID: 11294 RVA: 0x0001C2C1 File Offset: 0x0001A4C1
		' (set) Token: 0x06002C1F RID: 11295 RVA: 0x0001C2CB File Offset: 0x0001A4CB
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17001129 RID: 4393
		' (get) Token: 0x06002C20 RID: 11296 RVA: 0x0001C2D4 File Offset: 0x0001A4D4
		' (set) Token: 0x06002C21 RID: 11297 RVA: 0x0001C2DE File Offset: 0x0001A4DE
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700112A RID: 4394
		' (get) Token: 0x06002C22 RID: 11298 RVA: 0x0001C2E7 File Offset: 0x0001A4E7
		' (set) Token: 0x06002C23 RID: 11299 RVA: 0x0001C2F1 File Offset: 0x0001A4F1
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700112B RID: 4395
		' (get) Token: 0x06002C24 RID: 11300 RVA: 0x0001C2FA File Offset: 0x0001A4FA
		' (set) Token: 0x06002C25 RID: 11301 RVA: 0x0001C304 File Offset: 0x0001A504
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700112C RID: 4396
		' (get) Token: 0x06002C26 RID: 11302 RVA: 0x0001C30D File Offset: 0x0001A50D
		' (set) Token: 0x06002C27 RID: 11303 RVA: 0x0001C317 File Offset: 0x0001A517
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x1700112D RID: 4397
		' (get) Token: 0x06002C28 RID: 11304 RVA: 0x0001C320 File Offset: 0x0001A520
		' (set) Token: 0x06002C29 RID: 11305 RVA: 0x0001C32A File Offset: 0x0001A52A
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700112E RID: 4398
		' (get) Token: 0x06002C2A RID: 11306 RVA: 0x0001C333 File Offset: 0x0001A533
		' (set) Token: 0x06002C2B RID: 11307 RVA: 0x0001C33D File Offset: 0x0001A53D
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700112F RID: 4399
		' (get) Token: 0x06002C2C RID: 11308 RVA: 0x0001C346 File Offset: 0x0001A546
		' (set) Token: 0x06002C2D RID: 11309 RVA: 0x0001C350 File Offset: 0x0001A550
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17001130 RID: 4400
		' (get) Token: 0x06002C2E RID: 11310 RVA: 0x0001C359 File Offset: 0x0001A559
		' (set) Token: 0x06002C2F RID: 11311 RVA: 0x0001C363 File Offset: 0x0001A563
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17001131 RID: 4401
		' (get) Token: 0x06002C30 RID: 11312 RVA: 0x0001C36C File Offset: 0x0001A56C
		' (set) Token: 0x06002C31 RID: 11313 RVA: 0x0001C376 File Offset: 0x0001A576
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17001132 RID: 4402
		' (get) Token: 0x06002C32 RID: 11314 RVA: 0x0001C37F File Offset: 0x0001A57F
		' (set) Token: 0x06002C33 RID: 11315 RVA: 0x0001C389 File Offset: 0x0001A589
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17001133 RID: 4403
		' (get) Token: 0x06002C34 RID: 11316 RVA: 0x0001C392 File Offset: 0x0001A592
		' (set) Token: 0x06002C35 RID: 11317 RVA: 0x0001C39C File Offset: 0x0001A59C
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17001134 RID: 4404
		' (get) Token: 0x06002C36 RID: 11318 RVA: 0x0001C3A5 File Offset: 0x0001A5A5
		' (set) Token: 0x06002C37 RID: 11319 RVA: 0x0001C3AF File Offset: 0x0001A5AF
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17001135 RID: 4405
		' (get) Token: 0x06002C38 RID: 11320 RVA: 0x0001C3B8 File Offset: 0x0001A5B8
		' (set) Token: 0x06002C39 RID: 11321 RVA: 0x0001C3C2 File Offset: 0x0001A5C2
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17001136 RID: 4406
		' (get) Token: 0x06002C3A RID: 11322 RVA: 0x0001C3CB File Offset: 0x0001A5CB
		' (set) Token: 0x06002C3B RID: 11323 RVA: 0x0001C3D5 File Offset: 0x0001A5D5
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17001137 RID: 4407
		' (get) Token: 0x06002C3C RID: 11324 RVA: 0x0001C3DE File Offset: 0x0001A5DE
		' (set) Token: 0x06002C3D RID: 11325 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17001138 RID: 4408
		' (get) Token: 0x06002C3E RID: 11326 RVA: 0x0001C3F1 File Offset: 0x0001A5F1
		' (set) Token: 0x06002C3F RID: 11327 RVA: 0x0001C3FB File Offset: 0x0001A5FB
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17001139 RID: 4409
		' (get) Token: 0x06002C40 RID: 11328 RVA: 0x0001C404 File Offset: 0x0001A604
		' (set) Token: 0x06002C41 RID: 11329 RVA: 0x0001C40E File Offset: 0x0001A60E
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x1700113A RID: 4410
		' (get) Token: 0x06002C42 RID: 11330 RVA: 0x0001C417 File Offset: 0x0001A617
		' (set) Token: 0x06002C43 RID: 11331 RVA: 0x0001C421 File Offset: 0x0001A621
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x1700113B RID: 4411
		' (get) Token: 0x06002C44 RID: 11332 RVA: 0x0001C42A File Offset: 0x0001A62A
		' (set) Token: 0x06002C45 RID: 11333 RVA: 0x0001C434 File Offset: 0x0001A634
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700113C RID: 4412
		' (get) Token: 0x06002C46 RID: 11334 RVA: 0x0001C43D File Offset: 0x0001A63D
		' (set) Token: 0x06002C47 RID: 11335 RVA: 0x0001C447 File Offset: 0x0001A647
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700113D RID: 4413
		' (get) Token: 0x06002C48 RID: 11336 RVA: 0x0001C450 File Offset: 0x0001A650
		' (set) Token: 0x06002C49 RID: 11337 RVA: 0x0001C45A File Offset: 0x0001A65A
		Friend Overridable Property Label1 As Label

		' Token: 0x1700113E RID: 4414
		' (get) Token: 0x06002C4A RID: 11338 RVA: 0x0001C463 File Offset: 0x0001A663
		' (set) Token: 0x06002C4B RID: 11339 RVA: 0x0001C46D File Offset: 0x0001A66D
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700113F RID: 4415
		' (get) Token: 0x06002C4C RID: 11340 RVA: 0x0001C476 File Offset: 0x0001A676
		' (set) Token: 0x06002C4D RID: 11341 RVA: 0x001B2A04 File Offset: 0x001B0C04
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
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

		' Token: 0x17001140 RID: 4416
		' (get) Token: 0x06002C4E RID: 11342 RVA: 0x0001C480 File Offset: 0x0001A680
		' (set) Token: 0x06002C4F RID: 11343 RVA: 0x0001C48A File Offset: 0x0001A68A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17001141 RID: 4417
		' (get) Token: 0x06002C50 RID: 11344 RVA: 0x0001C493 File Offset: 0x0001A693
		' (set) Token: 0x06002C51 RID: 11345 RVA: 0x001B2A48 File Offset: 0x001B0C48
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001142 RID: 4418
		' (get) Token: 0x06002C52 RID: 11346 RVA: 0x0001C49D File Offset: 0x0001A69D
		' (set) Token: 0x06002C53 RID: 11347 RVA: 0x001B2A8C File Offset: 0x001B0C8C
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001143 RID: 4419
		' (get) Token: 0x06002C54 RID: 11348 RVA: 0x0001C4A7 File Offset: 0x0001A6A7
		' (set) Token: 0x06002C55 RID: 11349 RVA: 0x001B2AD0 File Offset: 0x001B0CD0
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

		' Token: 0x17001144 RID: 4420
		' (get) Token: 0x06002C56 RID: 11350 RVA: 0x0001C4B1 File Offset: 0x0001A6B1
		' (set) Token: 0x06002C57 RID: 11351 RVA: 0x001B2B14 File Offset: 0x001B0D14
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001145 RID: 4421
		' (get) Token: 0x06002C58 RID: 11352 RVA: 0x0001C4BB File Offset: 0x0001A6BB
		' (set) Token: 0x06002C59 RID: 11353 RVA: 0x001B2B58 File Offset: 0x001B0D58
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001146 RID: 4422
		' (get) Token: 0x06002C5A RID: 11354 RVA: 0x0001C4C5 File Offset: 0x0001A6C5
		' (set) Token: 0x06002C5B RID: 11355 RVA: 0x001B2B9C File Offset: 0x001B0D9C
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

		' Token: 0x06002C5C RID: 11356 RVA: 0x001B2BE0 File Offset: 0x001B0DE0
		Private Sub frmExpiryProduct_Load(sender As Object, e As EventArgs)
			btnGetData.DoubleBuffered(Me.dgw, True)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06002C5D RID: 11357 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x06002C5E RID: 11358 RVA: 0x001B2C68 File Offset: 0x001B0E68
		Public Sub Reset()
			Me.dtpDateFrom.Value = DateAndTime.Now
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.chkBoxZeroQty.Checked = False
			Me.cmbSearchType.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.dgw.Rows.Clear()
			Me.Calculate()
		End Sub

		' Token: 0x06002C5F RID: 11359 RVA: 0x0001C4CF File Offset: 0x0001A6CF
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002C60 RID: 11360 RVA: 0x001B2CDC File Offset: 0x001B0EDC
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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

		' Token: 0x06002C61 RID: 11361 RVA: 0x001B2F88 File Offset: 0x001B1188
		Public Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num3 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))

						If flag Then
							Dim num2 As Double
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))
						End If
						Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						If flag2 Then
							num3 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.TextBox2.Text = Conversions.ToString(num3)
				Me.lblNoOfItems.Text = "No.of Items : " + Conversions.ToString(Me.dgw.Rows.Count)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 3), "0.000")
		End Sub

		' Token: 0x06002C62 RID: 11362 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw As DataGridView, setting As Boolean)
			Dim type As Type = dgw.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw, setting, Nothing)
		End Sub

		' Token: 0x06002C63 RID: 11363 RVA: 0x001B3174 File Offset: 0x001B1374
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.cmbSearchType.SelectedIndex = 0
					If flag2 Then
						Dim flag3 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag3 Then
							Me.dgw.Rows.Clear()
							Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and ProductName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked As Boolean = Me.chkBoxZeroQty.Checked
							If checked Then
								Me.dgw.Rows.Clear()
								Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and ProductName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag4 As Boolean = Me.cmbSearchType.SelectedIndex = 1
					If flag4 Then
						Dim flag5 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag5 Then
							Me.dgw.Rows.Clear()
							Dim text3 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Barcode like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked2 As Boolean = Me.chkBoxZeroQty.Checked
							If checked2 Then
								Me.dgw.Rows.Clear()
								Dim text4 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag6 As Boolean = Me.cmbSearchType.SelectedIndex = 2
					If flag6 Then
						Dim flag7 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag7 Then
							Me.dgw.Rows.Clear()
							Dim text5 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Category like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text5, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked3 As Boolean = Me.chkBoxZeroQty.Checked
							If checked3 Then
								Me.dgw.Rows.Clear()
								Dim text6 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Category like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text6, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag8 As Boolean = Me.cmbSearchType.SelectedIndex = 3
					If flag8 Then
						Dim flag9 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag9 Then
							Me.dgw.Rows.Clear()
							Dim text7 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and SubCategoryName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text7, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked4 As Boolean = Me.chkBoxZeroQty.Checked
							If checked4 Then
								Me.dgw.Rows.Clear()
								Dim text8 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and SubCategoryName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text8, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag10 As Boolean = Me.cmbSearchType.SelectedIndex = 4
					If flag10 Then
						Dim flag11 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag11 Then
							Me.dgw.Rows.Clear()
							Dim text9 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and PartNo like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text9, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked5 As Boolean = Me.chkBoxZeroQty.Checked
							If checked5 Then
								Me.dgw.Rows.Clear()
								Dim text10 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and PartNo like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text10, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag12 As Boolean = Me.cmbSearchType.SelectedIndex = 5
					If flag12 Then
						Dim flag13 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag13 Then
							Me.dgw.Rows.Clear()
							Dim text11 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.GDown like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text11, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked6 As Boolean = Me.chkBoxZeroQty.Checked
							If checked6 Then
								Me.dgw.Rows.Clear()
								Dim text12 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.GDown like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text12, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag14 As Boolean = Me.cmbSearchType.SelectedIndex = 6
					If flag14 Then
						Dim flag15 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag15 Then
							Me.dgw.Rows.Clear()
							Dim text13 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Rack like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text13, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked7 As Boolean = Me.chkBoxZeroQty.Checked
							If checked7 Then
								Me.dgw.Rows.Clear()
								Dim text14 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Rack like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text14, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag16 As Boolean = Me.cmbSearchType.SelectedIndex = 7
					If flag16 Then
						Dim flag17 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag17 Then
							Me.dgw.Rows.Clear()
							Dim text15 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Batch like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text15, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked8 As Boolean = Me.chkBoxZeroQty.Checked
							If checked8 Then
								Me.dgw.Rows.Clear()
								Dim text16 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Batch like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text16, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag18 As Boolean = Me.cmbSearchType.SelectedIndex = 8
					If flag18 Then
						Dim flag19 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag19 Then
							Me.dgw.Rows.Clear()
							Dim text17 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Size like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text17, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked9 As Boolean = Me.chkBoxZeroQty.Checked
							If checked9 Then
								Me.dgw.Rows.Clear()
								Dim text18 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Size like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text18, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag20 As Boolean = Me.cmbSearchType.SelectedIndex = 9
					If flag20 Then
						Dim flag21 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag21 Then
							Me.dgw.Rows.Clear()
							Dim text19 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Colour like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text19, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked10 As Boolean = Me.chkBoxZeroQty.Checked
							If checked10 Then
								Me.dgw.Rows.Clear()
								Dim text20 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Colour like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text20, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag22 As Boolean = Me.cmbSearchType.SelectedIndex = 10
					If flag22 Then
						Dim flag23 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag23 Then
							Me.dgw.Rows.Clear()
							Dim text21 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.IMEI1 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text21, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked11 As Boolean = Me.chkBoxZeroQty.Checked
							If checked11 Then
								Me.dgw.Rows.Clear()
								Dim text22 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.IMEI1 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text22, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					Dim flag24 As Boolean = Me.cmbSearchType.SelectedIndex = 11
					If flag24 Then
						Dim flag25 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag25 Then
							Me.dgw.Rows.Clear()
							Dim text23 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.IMEI2 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text23, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						Else
							Dim checked12 As Boolean = Me.chkBoxZeroQty.Checked
							If checked12 Then
								Me.dgw.Rows.Clear()
								Dim text24 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.IMEI2 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text24, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							End If
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
					Dim num As Integer = Me.dgw.RowCount - 1
					For i As Integer = 0 To num
						Dim flag26 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
						If flag26 Then
							Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
							Dim flag27 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
							If flag27 Then
								Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
							End If
						End If
					Next
					Me.Calculate()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C64 RID: 11364 RVA: 0x0001C4D9 File Offset: 0x0001A6D9
		Private Sub cmbSearchType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x06002C65 RID: 11365 RVA: 0x001B4B84 File Offset: 0x001B2D84
		Private Sub frmExpiryProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F1
			If flag3 Then
				e.Handled = True
				Me.dgw.Focus()
			End If
		End Sub

		' Token: 0x06002C66 RID: 11366 RVA: 0x001B4BF4 File Offset: 0x001B2DF4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(7.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(7.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C67 RID: 11367 RVA: 0x001B53BC File Offset: 0x001B35BC
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(15.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(15.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C68 RID: 11368 RVA: 0x001B5B84 File Offset: 0x001B3D84
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(30.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(30.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C69 RID: 11369 RVA: 0x001B634C File Offset: 0x001B454C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(90.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(90.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C6A RID: 11370 RVA: 0x001B6B14 File Offset: 0x001B4D14
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(180.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(180.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C6B RID: 11371 RVA: 0x001B72DC File Offset: 0x001B54DC
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(365.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Now.AddDays(365.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002C6C RID: 11372 RVA: 0x001B7AA4 File Offset: 0x001B5CA4
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.dgw.Focus()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					Me.dgw.Rows.Clear()
					Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						Me.dgw.Rows.Clear()
						Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
						End While
					End If
				End If
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
