Imports System
Imports System.Collections
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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000588 RID: 1416
	<DesignerGenerated()>
	Public Partial Class frmLeadGenerateRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011260 RID: 70240 RVA: 0x009F0F80 File Offset: 0x009EF180
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerRecord_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCustomerRecord_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006A5D RID: 27229
		' (get) Token: 0x06011263 RID: 70243 RVA: 0x00075E55 File Offset: 0x00074055
		' (set) Token: 0x06011264 RID: 70244 RVA: 0x00075E5F File Offset: 0x0007405F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006A5E RID: 27230
		' (get) Token: 0x06011265 RID: 70245 RVA: 0x00075E68 File Offset: 0x00074068
		' (set) Token: 0x06011266 RID: 70246 RVA: 0x009F2DE4 File Offset: 0x009F0FE4
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
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A5F RID: 27231
		' (get) Token: 0x06011267 RID: 70247 RVA: 0x00075E72 File Offset: 0x00074072
		' (set) Token: 0x06011268 RID: 70248 RVA: 0x00075E7C File Offset: 0x0007407C
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006A60 RID: 27232
		' (get) Token: 0x06011269 RID: 70249 RVA: 0x00075E85 File Offset: 0x00074085
		' (set) Token: 0x0601126A RID: 70250 RVA: 0x009F2E84 File Offset: 0x009F1084
		Private _txtState As TextBox
		Friend Overridable Property txtState As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtState
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtState = value
				textBox = Me._txtState
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A61 RID: 27233
		' (get) Token: 0x0601126B RID: 70251 RVA: 0x00075E8F File Offset: 0x0007408F
		' (set) Token: 0x0601126C RID: 70252 RVA: 0x00075E99 File Offset: 0x00074099
		Friend Overridable Property Label2 As Label

		' Token: 0x17006A62 RID: 27234
		' (get) Token: 0x0601126D RID: 70253 RVA: 0x00075EA2 File Offset: 0x000740A2
		' (set) Token: 0x0601126E RID: 70254 RVA: 0x00075EAC File Offset: 0x000740AC
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006A63 RID: 27235
		' (get) Token: 0x0601126F RID: 70255 RVA: 0x00075EB5 File Offset: 0x000740B5
		' (set) Token: 0x06011270 RID: 70256 RVA: 0x009F2EC8 File Offset: 0x009F10C8
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCustomerName_KeyDown
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A64 RID: 27236
		' (get) Token: 0x06011271 RID: 70257 RVA: 0x00075EBF File Offset: 0x000740BF
		' (set) Token: 0x06011272 RID: 70258 RVA: 0x00075EC9 File Offset: 0x000740C9
		Friend Overridable Property Label3 As Label

		' Token: 0x17006A65 RID: 27237
		' (get) Token: 0x06011273 RID: 70259 RVA: 0x00075ED2 File Offset: 0x000740D2
		' (set) Token: 0x06011274 RID: 70260 RVA: 0x00075EDC File Offset: 0x000740DC
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17006A66 RID: 27238
		' (get) Token: 0x06011275 RID: 70261 RVA: 0x00075EE5 File Offset: 0x000740E5
		' (set) Token: 0x06011276 RID: 70262 RVA: 0x009F2F0C File Offset: 0x009F110C
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A67 RID: 27239
		' (get) Token: 0x06011277 RID: 70263 RVA: 0x00075EEF File Offset: 0x000740EF
		' (set) Token: 0x06011278 RID: 70264 RVA: 0x00075EF9 File Offset: 0x000740F9
		Friend Overridable Property Label4 As Label

		' Token: 0x17006A68 RID: 27240
		' (get) Token: 0x06011279 RID: 70265 RVA: 0x00075F02 File Offset: 0x00074102
		' (set) Token: 0x0601127A RID: 70266 RVA: 0x00075F0C File Offset: 0x0007410C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006A69 RID: 27241
		' (get) Token: 0x0601127B RID: 70267 RVA: 0x00075F15 File Offset: 0x00074115
		' (set) Token: 0x0601127C RID: 70268 RVA: 0x00075F1F File Offset: 0x0007411F
		Friend Overridable Property lblUser As Label

		' Token: 0x17006A6A RID: 27242
		' (get) Token: 0x0601127D RID: 70269 RVA: 0x00075F28 File Offset: 0x00074128
		' (set) Token: 0x0601127E RID: 70270 RVA: 0x00075F32 File Offset: 0x00074132
		Friend Overridable Property Label1 As Label

		' Token: 0x17006A6B RID: 27243
		' (get) Token: 0x0601127F RID: 70271 RVA: 0x00075F3B File Offset: 0x0007413B
		' (set) Token: 0x06011280 RID: 70272 RVA: 0x00075F45 File Offset: 0x00074145
		Friend Overridable Property lblSet As Label

		' Token: 0x17006A6C RID: 27244
		' (get) Token: 0x06011281 RID: 70273 RVA: 0x00075F4E File Offset: 0x0007414E
		' (set) Token: 0x06011282 RID: 70274 RVA: 0x00075F58 File Offset: 0x00074158
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006A6D RID: 27245
		' (get) Token: 0x06011283 RID: 70275 RVA: 0x00075F61 File Offset: 0x00074161
		' (set) Token: 0x06011284 RID: 70276 RVA: 0x00075F6B File Offset: 0x0007416B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006A6E RID: 27246
		' (get) Token: 0x06011285 RID: 70277 RVA: 0x00075F74 File Offset: 0x00074174
		' (set) Token: 0x06011286 RID: 70278 RVA: 0x009F2F50 File Offset: 0x009F1150
		Private _txtUser As TextBox
		Friend Overridable Property txtUser As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUser
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtRoute_TextChanged
				Dim textBox As TextBox = Me._txtUser
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtUser = value
				textBox = Me._txtUser
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A6F RID: 27247
		' (get) Token: 0x06011287 RID: 70279 RVA: 0x00075F7E File Offset: 0x0007417E
		' (set) Token: 0x06011288 RID: 70280 RVA: 0x00075F88 File Offset: 0x00074188
		Friend Overridable Property Label5 As Label

		' Token: 0x17006A70 RID: 27248
		' (get) Token: 0x06011289 RID: 70281 RVA: 0x00075F91 File Offset: 0x00074191
		' (set) Token: 0x0601128A RID: 70282 RVA: 0x00075F9B File Offset: 0x0007419B
		Friend Overridable Property Label6 As Label

		' Token: 0x17006A71 RID: 27249
		' (get) Token: 0x0601128B RID: 70283 RVA: 0x00075FA4 File Offset: 0x000741A4
		' (set) Token: 0x0601128C RID: 70284 RVA: 0x00075FAE File Offset: 0x000741AE
		Friend Overridable Property Label7 As Label

		' Token: 0x17006A72 RID: 27250
		' (get) Token: 0x0601128D RID: 70285 RVA: 0x00075FB7 File Offset: 0x000741B7
		' (set) Token: 0x0601128E RID: 70286 RVA: 0x009F2F94 File Offset: 0x009F1194
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTopResult_KeyDown
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A73 RID: 27251
		' (get) Token: 0x0601128F RID: 70287 RVA: 0x00075FC1 File Offset: 0x000741C1
		' (set) Token: 0x06011290 RID: 70288 RVA: 0x009F2FD8 File Offset: 0x009F11D8
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

		' Token: 0x17006A74 RID: 27252
		' (get) Token: 0x06011291 RID: 70289 RVA: 0x00075FCB File Offset: 0x000741CB
		' (set) Token: 0x06011292 RID: 70290 RVA: 0x009F301C File Offset: 0x009F121C
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

		' Token: 0x17006A75 RID: 27253
		' (get) Token: 0x06011293 RID: 70291 RVA: 0x00075FD5 File Offset: 0x000741D5
		' (set) Token: 0x06011294 RID: 70292 RVA: 0x00075FDF File Offset: 0x000741DF
		Friend Overridable Property lblUserType As Label

		' Token: 0x17006A76 RID: 27254
		' (get) Token: 0x06011295 RID: 70293 RVA: 0x00075FE8 File Offset: 0x000741E8
		' (set) Token: 0x06011296 RID: 70294 RVA: 0x00075FF2 File Offset: 0x000741F2
		Friend Overridable Property Id As DataGridViewTextBoxColumn

		' Token: 0x17006A77 RID: 27255
		' (get) Token: 0x06011297 RID: 70295 RVA: 0x00075FFB File Offset: 0x000741FB
		' (set) Token: 0x06011298 RID: 70296 RVA: 0x00076005 File Offset: 0x00074205
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006A78 RID: 27256
		' (get) Token: 0x06011299 RID: 70297 RVA: 0x0007600E File Offset: 0x0007420E
		' (set) Token: 0x0601129A RID: 70298 RVA: 0x00076018 File Offset: 0x00074218
		Friend Overridable Property btnLead_Id As DataGridViewButtonColumn

		' Token: 0x17006A79 RID: 27257
		' (get) Token: 0x0601129B RID: 70299 RVA: 0x00076021 File Offset: 0x00074221
		' (set) Token: 0x0601129C RID: 70300 RVA: 0x0007602B File Offset: 0x0007422B
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006A7A RID: 27258
		' (get) Token: 0x0601129D RID: 70301 RVA: 0x00076034 File Offset: 0x00074234
		' (set) Token: 0x0601129E RID: 70302 RVA: 0x0007603E File Offset: 0x0007423E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006A7B RID: 27259
		' (get) Token: 0x0601129F RID: 70303 RVA: 0x00076047 File Offset: 0x00074247
		' (set) Token: 0x060112A0 RID: 70304 RVA: 0x00076051 File Offset: 0x00074251
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006A7C RID: 27260
		' (get) Token: 0x060112A1 RID: 70305 RVA: 0x0007605A File Offset: 0x0007425A
		' (set) Token: 0x060112A2 RID: 70306 RVA: 0x00076064 File Offset: 0x00074264
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17006A7D RID: 27261
		' (get) Token: 0x060112A3 RID: 70307 RVA: 0x0007606D File Offset: 0x0007426D
		' (set) Token: 0x060112A4 RID: 70308 RVA: 0x00076077 File Offset: 0x00074277
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006A7E RID: 27262
		' (get) Token: 0x060112A5 RID: 70309 RVA: 0x00076080 File Offset: 0x00074280
		' (set) Token: 0x060112A6 RID: 70310 RVA: 0x0007608A File Offset: 0x0007428A
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006A7F RID: 27263
		' (get) Token: 0x060112A7 RID: 70311 RVA: 0x00076093 File Offset: 0x00074293
		' (set) Token: 0x060112A8 RID: 70312 RVA: 0x0007609D File Offset: 0x0007429D
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006A80 RID: 27264
		' (get) Token: 0x060112A9 RID: 70313 RVA: 0x000760A6 File Offset: 0x000742A6
		' (set) Token: 0x060112AA RID: 70314 RVA: 0x000760B0 File Offset: 0x000742B0
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006A81 RID: 27265
		' (get) Token: 0x060112AB RID: 70315 RVA: 0x000760B9 File Offset: 0x000742B9
		' (set) Token: 0x060112AC RID: 70316 RVA: 0x000760C3 File Offset: 0x000742C3
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006A82 RID: 27266
		' (get) Token: 0x060112AD RID: 70317 RVA: 0x000760CC File Offset: 0x000742CC
		' (set) Token: 0x060112AE RID: 70318 RVA: 0x000760D6 File Offset: 0x000742D6
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006A83 RID: 27267
		' (get) Token: 0x060112AF RID: 70319 RVA: 0x000760DF File Offset: 0x000742DF
		' (set) Token: 0x060112B0 RID: 70320 RVA: 0x000760E9 File Offset: 0x000742E9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006A84 RID: 27268
		' (get) Token: 0x060112B1 RID: 70321 RVA: 0x000760F2 File Offset: 0x000742F2
		' (set) Token: 0x060112B2 RID: 70322 RVA: 0x000760FC File Offset: 0x000742FC
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006A85 RID: 27269
		' (get) Token: 0x060112B3 RID: 70323 RVA: 0x00076105 File Offset: 0x00074305
		' (set) Token: 0x060112B4 RID: 70324 RVA: 0x0007610F File Offset: 0x0007430F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006A86 RID: 27270
		' (get) Token: 0x060112B5 RID: 70325 RVA: 0x00076118 File Offset: 0x00074318
		' (set) Token: 0x060112B6 RID: 70326 RVA: 0x00076122 File Offset: 0x00074322
		Friend Overridable Property btnfollowup As DataGridViewButtonColumn

		' Token: 0x17006A87 RID: 27271
		' (get) Token: 0x060112B7 RID: 70327 RVA: 0x0007612B File Offset: 0x0007432B
		' (set) Token: 0x060112B8 RID: 70328 RVA: 0x009F3060 File Offset: 0x009F1260
		Private _btnSearch As Button
		Friend Overridable Property btnSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSearch_Click
				Dim button As Button = Me._btnSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSearch = value
				button = Me._btnSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A88 RID: 27272
		' (get) Token: 0x060112B9 RID: 70329 RVA: 0x00076135 File Offset: 0x00074335
		' (set) Token: 0x060112BA RID: 70330 RVA: 0x0007613F File Offset: 0x0007433F
		Friend Overridable Property dtpTo As DateTimePicker

		' Token: 0x17006A89 RID: 27273
		' (get) Token: 0x060112BB RID: 70331 RVA: 0x00076148 File Offset: 0x00074348
		' (set) Token: 0x060112BC RID: 70332 RVA: 0x00076152 File Offset: 0x00074352
		Friend Overridable Property dtpFrom As DateTimePicker

		' Token: 0x17006A8A RID: 27274
		' (get) Token: 0x060112BD RID: 70333 RVA: 0x0007615B File Offset: 0x0007435B
		' (set) Token: 0x060112BE RID: 70334 RVA: 0x00076165 File Offset: 0x00074365
		Friend Overridable Property Label8 As Label

		' Token: 0x17006A8B RID: 27275
		' (get) Token: 0x060112BF RID: 70335 RVA: 0x0007616E File Offset: 0x0007436E
		' (set) Token: 0x060112C0 RID: 70336 RVA: 0x00076178 File Offset: 0x00074378
		Friend Overridable Property Label9 As Label

		' Token: 0x17006A8C RID: 27276
		' (get) Token: 0x060112C1 RID: 70337 RVA: 0x00076181 File Offset: 0x00074381
		' (set) Token: 0x060112C2 RID: 70338 RVA: 0x009F30A4 File Offset: 0x009F12A4
		Private _cmbStatus As ComboBox
		Friend Overridable Property cmbStatus As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbStatus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbStatus_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbStatus
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbStatus = value
				comboBox = Me._cmbStatus
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060112C3 RID: 70339 RVA: 0x009F30E8 File Offset: 0x009F12E8
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f" & vbCrLf & "ORDER BY lm.lead_id DESC;", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user='", Me.lblUser.Text, "'ORDER BY lm.lead_id DESC" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
					Dim text2 As String = ModCommonClasses.rdr(1).ToString().Trim()
					Dim flag4 As Boolean = Operators.CompareString(text2, "NEW LEAD", False) = 0
					If flag4 Then
						dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
					Else
						Dim flag5 As Boolean = Operators.CompareString(text2.ToUpper(), "FOLLOW-UP", False) = 0
						If flag5 Then
							Dim dateTime As DateTime
							Dim flag6 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
							If flag6 Then
								Dim flag7 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
								If flag7 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
							End If
						Else
							Dim flag8 As Boolean = Operators.CompareString(text2, "FINISHED", False) = 0
							If flag8 Then
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112C4 RID: 70340 RVA: 0x009F34CC File Offset: 0x009F16CC
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060112C5 RID: 70341 RVA: 0x009F3554 File Offset: 0x009F1754
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

		' Token: 0x060112C6 RID: 70342 RVA: 0x009F36CC File Offset: 0x009F18CC
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

		' Token: 0x060112C7 RID: 70343 RVA: 0x009F3798 File Offset: 0x009F1998
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

		' Token: 0x060112C8 RID: 70344 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060112C9 RID: 70345 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060112CA RID: 70346 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060112CB RID: 70347 RVA: 0x009F3864 File Offset: 0x009F1A64
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060112CC RID: 70348 RVA: 0x0007618B File Offset: 0x0007438B
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060112CD RID: 70349 RVA: 0x009F388C File Offset: 0x009F1A8C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Entry", False) = 0
					If flag2 Then
						MyProject.Forms.frmCustomer.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomer.btnUpdate.Enabled = True
						MyProject.Forms.frmCustomer.btnDelete.Enabled = True
						MyProject.Forms.frmCustomer.btnSave.Enabled = False
						MyProject.Forms.frmCustomer.chkvalid()
						Me.lblSet.Text = ""
						MyProject.Forms.frmCustomer.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmCustomer.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomer.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtCity.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCustomer.cmbState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCustomer.txtZipCode.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmCustomer.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtPhNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtEmailID.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCustomer.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtCIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCustomer.txtPAN.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmCustomer.txtAccountName.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmCustomer.txtAccountNo.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmCustomer.txtBank.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmCustomer.txtBranch.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmCustomer.txtIFSCcode.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmCustomer.txtRemarks.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmCustomer.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
						MyProject.Forms.frmCustomer.cmbOpeningBalanceType.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmCustomer.txtOpeningBalance.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmCustomer.cmbTCS.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmCustomer.txtcrlimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmCustomer.cmbcrlimit.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmCustomer.cmbRoute.Text = dataGridViewRow.Cells(26).Value.ToString()
						MyProject.Forms.frmCustomer.Num1.Value = Conversions.ToDecimal(dataGridViewRow.Cells(27).Value.ToString())
						MyProject.Forms.frmCustomer.txtDiscItem.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmCustomer.cmbDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmCustomer.cboxLoyality.DropDownStyle = ComboBoxStyle.DropDown
						MyProject.Forms.frmCustomer.cboxLoyality.Text = dataGridViewRow.Cells(30).Value.ToString()
						MyProject.Forms.frmCustomer.txtLoyalitypts.Text = dataGridViewRow.Cells(31).Value.ToString()
						Dim flag3 As Boolean = Conversions.ToDouble(dataGridViewRow.Cells(32).Value.ToString()) = 0.0
						If flag3 Then
							MyProject.Forms.frmCustomer.chkLoyality.Checked = True
						Else
							MyProject.Forms.frmCustomer.chkLoyality.Checked = False
						End If
						Dim array As Byte() = CType(dataGridViewRow.Cells(20).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						MyProject.Forms.frmCustomer.Picture.Image = Image.FromStream(memoryStream)
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.lblSet.Text, "Quotation", False) = 0
					If flag4 Then
						MyProject.Forms.frmQuotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmQuotation.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmQuotation.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmQuotation.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmQuotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag5 Then
							MyProject.Forms.frmQuotation.txtCustomerState.Text = MyProject.Forms.frmQuotation.txtCompanyState.Text
						Else
							MyProject.Forms.frmQuotation.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmQuotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmQuotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmQuotation.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmQuotation.btnProductSelection.Focus()
						Me.lblSet.Text = ""
					End If
					Dim flag6 As Boolean = Operators.CompareString(Me.lblSet.Text, "Estimate", False) = 0
					If flag6 Then
						MyProject.Forms.frmEstimate.Show()
						MyBase.Hide()
						MyProject.Forms.frmEstimate.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmEstimate.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmEstimate.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag7 As Boolean = Operators.CompareString(MyProject.Forms.frmEstimate.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag7 Then
							MyProject.Forms.frmEstimate.txtCustomerState.Text = MyProject.Forms.frmEstimate.txtCompanyState.Text
						Else
							MyProject.Forms.frmEstimate.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmEstimate.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmEstimate.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmEstimate.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmEstimate.btnProductSelection.Focus()
						Me.lblSet.Text = ""
					End If
					Dim flag8 As Boolean = Operators.CompareString(Me.lblSet.Text, "POS", False) = 0
					If flag8 Then
						MyProject.Forms.frmPOS.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOS.FillCustomers()
						MyProject.Forms.frmPOS.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOS.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag9 As Boolean = Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag9 Then
							MyProject.Forms.frmPOS.cmbCustomerState.Text = MyProject.Forms.frmPOS.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOS.cmbCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmPOS.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOS.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOS.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOS.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOS.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOS.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOS.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOS.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOS.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOS.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOS.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOS.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOS.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOS.Label82.Enabled = False
						MyProject.Forms.frmPOS.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOS.GetCustomerBalance()
						MyProject.Forms.frmPOS.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOS.Calculate12345()
						MyProject.Forms.frmPOS.Calculate143()
						MyProject.Forms.frmPOS.tcsconn()
						MyProject.Forms.frmPOS.InvoiceTCSinfo()
						MyProject.Forms.frmPOS.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag10 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouch", False) = 0
					If flag10 Then
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag11 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag11 Then
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = MyProject.Forms.frmPOSTouch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSTouch.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSTouch.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSTouch.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSTouch.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSTouch.Label82.Enabled = False
						MyProject.Forms.frmPOSTouch.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSTouch.GetCustomerBalance()
						MyProject.Forms.frmPOSTouch.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSTouch.Calculate12345()
						MyProject.Forms.frmPOSTouch.Calculate143()
						MyProject.Forms.frmPOSTouch.tcsconn()
						MyProject.Forms.frmPOSTouch.InvoiceTCSinfo()
						MyProject.Forms.frmPOSTouch.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouchNew", False) = 0
					If flag12 Then
						MyProject.Forms.frmPOSNewTuch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag13 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag13 Then
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSNewTuch.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch.Label82.Enabled = False
						MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblLoyality.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.GetCustomerBalance()
						MyProject.Forms.frmPOSNewTuch.CustomerBalance_Loyality()
						MyProject.Forms.frmPOSNewTuch.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSNewTuch.Calculate12345()
						MyProject.Forms.frmPOSNewTuch.Calculate143()
						MyProject.Forms.frmPOSNewTuch.tcsconn()
						MyProject.Forms.frmPOSNewTuch.InvoiceTCSinfo()
						MyProject.Forms.frmPOSNewTuch.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag14 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouchNew_Quotation", False) = 0
					If flag14 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag15 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag15 Then
							MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_Quotation.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.lblLoyality.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalance()
						MyProject.Forms.frmPOSNewTuch_Quotation.CustomerBalance_Loyality()
						MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
						MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
						MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn()
						MyProject.Forms.frmPOSNewTuch_Quotation.InvoiceTCSinfo()
						MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag16 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag16 Then
						MyProject.Forms.frmCreditCustomerReceipt.Show()
						MyBase.Hide()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.GetCustomerBalance()
						Me.lblSet.Text = ""
					End If
					Dim flag17 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Ledger", False) = 0
					If flag17 Then
						MyProject.Forms.frmCustomerLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomerLedger.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomerLedger.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag18 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Ledger Loyalty", False) = 0
					If flag18 Then
						MyProject.Forms.frmCustomerLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomerLedger_Loyalty.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomerLedger_Loyalty.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag19 As Boolean = Operators.CompareString(Me.lblSet.Text, "CT", False) = 0
					If flag19 Then
						MyProject.Forms.frmCreditTermsStatements.Show()
						MyBase.Hide()
						MyProject.Forms.frmCreditTermsStatements.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCreditTermsStatements.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag20 As Boolean = Operators.CompareString(Me.lblSet.Text, "Services", False) = 0
					If flag20 Then
						MyProject.Forms.frmServices.Show()
						MyBase.Hide()
						MyProject.Forms.frmServices.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmServices.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112CE RID: 70350 RVA: 0x009F5870 File Offset: 0x009F3A70
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

		' Token: 0x060112CF RID: 70351 RVA: 0x009F5958 File Offset: 0x009F3B58
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.State like N'", Me.txtState.Text, "%' order by lm.lead_id DESC" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user='", Me.lblUser.Text, "' and lm.State like N'", Me.txtState.Text, "%' order by lm.lead_id DESC" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
					Dim text2 As String = ModCommonClasses.rdr(1).ToString().Trim()
					Dim flag4 As Boolean = Operators.CompareString(text2, "NEW LEAD", False) = 0
					If flag4 Then
						dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
					Else
						Dim flag5 As Boolean = Operators.CompareString(text2.ToUpper(), "FOLLOW-UP", False) = 0
						If flag5 Then
							Dim dateTime As DateTime
							Dim flag6 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
							If flag6 Then
								Dim flag7 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
								If flag7 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
							End If
						Else
							Dim flag8 As Boolean = Operators.CompareString(text2, "FINISHED", False) = 0
							If flag8 Then
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112D0 RID: 70352 RVA: 0x009F5D7C File Offset: 0x009F3F7C
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtState.Text = ""
			Me.txtUser.Text = ""
			Me.txtTopResult.Text = "10"
			Me.Getdata()
		End Sub

		' Token: 0x060112D1 RID: 70353 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060112D2 RID: 70354 RVA: 0x009F5DE8 File Offset: 0x009F3FE8
		Private Sub txtRoute_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user like N'", Me.txtUser.Text, "%' order by lm.lead_id desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user='", Me.lblUser.Text, "' and lm.alloted_user like N'", Me.txtUser.Text, "%' order by lm.lead_id desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
					Dim text2 As String = ModCommonClasses.rdr(1).ToString().Trim()
					Dim flag4 As Boolean = Operators.CompareString(text2, "NEW LEAD", False) = 0
					If flag4 Then
						dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
					Else
						Dim flag5 As Boolean = Operators.CompareString(text2.ToUpper(), "FOLLOW-UP", False) = 0
						If flag5 Then
							Dim dateTime As DateTime
							Dim flag6 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
							If flag6 Then
								Dim flag7 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
								If flag7 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
							End If
						Else
							Dim flag8 As Boolean = Operators.CompareString(text2, "FINISHED", False) = 0
							If flag8 Then
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112D3 RID: 70355 RVA: 0x009F620C File Offset: 0x009F440C
		Public Sub txtCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
					Dim text As String
					If flag2 Then
						text = String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f" & vbCrLf & "                               WHERE lm.customer_name LIKE N'", Me.txtCustomerName.Text, "%'" & vbCrLf & "                               ORDER BY lm.lead_id desc" })
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag3 Then
							text = String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f" & vbCrLf & "                               WHERE lm.alloted_user='", Me.lblUser.Text, "' and lm.customer_name LIKE N'", Me.txtCustomerName.Text, "%'" & vbCrLf & "                               ORDER BY lm.lead_id desc" })
						End If
					End If
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim text2 As String = ""
						Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						If flag4 Then
							Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
							text2 = New String("★"c, num) + New String("☆"c, 5 - num)
						End If
						Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text2, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
						Dim text3 As String = ModCommonClasses.rdr(1).ToString().Trim()
						Dim flag5 As Boolean = Operators.CompareString(text3, "NEW LEAD", False) = 0
						If flag5 Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
						Else
							Dim flag6 As Boolean = Operators.CompareString(text3.ToUpper(), "FOLLOW-UP", False) = 0
							If flag6 Then
								Dim dateTime As DateTime
								Dim flag7 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
								If flag7 Then
									Dim flag8 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
									If flag8 Then
										dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
									Else
										dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
									End If
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								Dim flag9 As Boolean = Operators.CompareString(text3, "FINISHED", False) = 0
								If flag9 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
								End If
							End If
						End If
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060112D4 RID: 70356 RVA: 0x009F6638 File Offset: 0x009F4838
		Public Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "        fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.mobile like N'", Me.txtContactNo.Text, "%' order by lm.lead_id desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "        fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user='", Me.lblUser.Text, "' and lm.mobile like N'", Me.txtContactNo.Text, "%' order by lm.lead_id desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
					Dim text2 As String = ModCommonClasses.rdr(1).ToString().Trim()
					Dim flag4 As Boolean = Operators.CompareString(text2, "NEW LEAD", False) = 0
					If flag4 Then
						dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
					Else
						Dim flag5 As Boolean = Operators.CompareString(text2.ToUpper(), "FOLLOW-UP", False) = 0
						If flag5 Then
							Dim dateTime As DateTime
							Dim flag6 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
							If flag6 Then
								Dim flag7 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
								If flag7 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
							End If
						Else
							Dim flag8 As Boolean = Operators.CompareString(text2, "FINISHED", False) = 0
							If flag8 Then
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.Rows(0).Selected = True
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112D5 RID: 70357 RVA: 0x009F6A68 File Offset: 0x009F4C68
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLeadGenerate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLeadGenerate.Reset()
			MyProject.Forms.frmLeadGenerate.ShowDialog()
			MyProject.Forms.frmLeadGenerate.Dispose()
		End Sub

		' Token: 0x060112D6 RID: 70358 RVA: 0x009F6AC8 File Offset: 0x009F4CC8
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

		' Token: 0x060112D7 RID: 70359 RVA: 0x00076195 File Offset: 0x00074395
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060112D8 RID: 70360 RVA: 0x009F6D74 File Offset: 0x009F4F74
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.dgw.Columns("btnfollowup").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(e.RowIndex)
				MyProject.Forms.frmFollowUp_Lead.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmFollowUp_Lead.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmFollowUp_Lead.lbl_Id.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
				MyProject.Forms.frmFollowUp_Lead.txtLead_Id.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
				MyProject.Forms.frmFollowUp_Lead.txtCustomerName.Text = Conversions.ToString(dataGridViewRow.Cells(5).Value)
				MyProject.Forms.frmFollowUp_Lead.lblMobileno.Text = Conversions.ToString(dataGridViewRow.Cells(7).Value)
				MyProject.Forms.frmFollowUp_Lead.lblState.Text = Conversions.ToString(dataGridViewRow.Cells(10).Value)
				MyBase.Dispose()
				MyProject.Forms.frmFollowUp_Lead.ShowDialog()
			End If
		End Sub

		' Token: 0x060112D9 RID: 70361 RVA: 0x0007619F File Offset: 0x0007439F
		Private Sub txtTopResult_KeyDown(sender As Object, e As KeyEventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060112DA RID: 70362 RVA: 0x009F6F04 File Offset: 0x009F5104
		Private Sub btnSearch_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				Dim text As String
				If flag Then
					text = "SELECT TOP " + Me.txtTopResult.Text + vbCrLf & "        lm.id," & vbCrLf & "        ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "        lm.lead_id," & vbCrLf & "        f.remarks AS latest_lead_remarks,    " & vbCrLf & "        CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "        RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "        lm.customer_name," & vbCrLf & "        lm.coordinate_mode," & vbCrLf & "        lm.mobile,    " & vbCrLf & "        f.rating," & vbCrLf & "        lm.interest_mode," & vbCrLf & "        lm.state," & vbCrLf & "        lm.address,    " & vbCrLf & "        lm.productname," & vbCrLf & "        lm.alloted_user," & vbCrLf & "        f.followup_date,lm.lead_date" & vbCrLf & "    FROM tbl_lead_master lm" & vbCrLf & "    OUTER APPLY (" & vbCrLf & "        SELECT TOP 1 " & vbCrLf & "            fl.lead_status, " & vbCrLf & "            fl.remarks, " & vbCrLf & "            fl.reminder_date, " & vbCrLf & "            fl.reminder_time," & vbCrLf & "            fl.rating," & vbCrLf & "            fl.followup_date" & vbCrLf & "        FROM tbl_followup_lead fl" & vbCrLf & "        WHERE fl.lead_id = lm.id " & vbCrLf & "          AND fl.reminder_date BETWEEN @FromDate AND @ToDate" & vbCrLf & "        ORDER BY fl.followup_id DESC   " & vbCrLf & "    ) f " & vbCrLf & "    ORDER BY lm.lead_id DESC"
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						text = "SELECT TOP " + Me.txtTopResult.Text + vbCrLf & "        lm.id," & vbCrLf & "        ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "        lm.lead_id," & vbCrLf & "        f.remarks AS latest_lead_remarks,    " & vbCrLf & "        CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "        RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "        lm.customer_name," & vbCrLf & "        lm.coordinate_mode," & vbCrLf & "        lm.mobile,    " & vbCrLf & "        f.rating," & vbCrLf & "        lm.interest_mode," & vbCrLf & "        lm.state," & vbCrLf & "        lm.address,    " & vbCrLf & "        lm.productname," & vbCrLf & "        lm.alloted_user," & vbCrLf & "        f.followup_date,lm.lead_date" & vbCrLf & "    FROM tbl_lead_master lm" & vbCrLf & "    OUTER APPLY (" & vbCrLf & "        SELECT TOP 1 " & vbCrLf & "            fl.lead_status, " & vbCrLf & "            fl.remarks, " & vbCrLf & "            fl.reminder_date, " & vbCrLf & "            fl.reminder_time," & vbCrLf & "            fl.rating," & vbCrLf & "            fl.followup_date" & vbCrLf & "        FROM tbl_followup_lead fl" & vbCrLf & "        WHERE fl.lead_id = lm.id " & vbCrLf & "          AND fl.reminder_date BETWEEN @FromDate AND @ToDate" & vbCrLf & "        ORDER BY fl.followup_id DESC   " & vbCrLf & "    ) f" & vbCrLf & "    WHERE lm.alloted_user=@AllotedUser" & vbCrLf & "    ORDER BY lm.lead_id DESC"
					End If
				End If
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@FromDate", SqlDbType.[Date]).Value = Me.dtpFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@ToDate", SqlDbType.[Date]).Value = Me.dtpTo.Value.[Date]
				Dim flag3 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
				If flag3 Then
					ModCommonClasses.cmd.Parameters.Add("@AllotedUser", SqlDbType.NVarChar).Value = Me.lblUser.Text
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(4)))
					If flag4 Then
						Dim text2 As String = ""
						Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						If flag5 Then
							Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
							text2 = New String("★"c, num) + New String("☆"c, 5 - num)
						End If
						Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text2, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
						Dim text3 As String = ModCommonClasses.rdr(1).ToString().Trim()
						Dim flag6 As Boolean = Operators.CompareString(text3, "NEW LEAD", False) = 0
						If flag6 Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
						Else
							Dim flag7 As Boolean = Operators.CompareString(text3.ToUpper(), "FOLLOW-UP", False) = 0
							If flag7 Then
								Dim dateTime As DateTime
								Dim flag8 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
								If flag8 Then
									Dim flag9 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
									If flag9 Then
										dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
									Else
										dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
									End If
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								Dim flag10 As Boolean = Operators.CompareString(text3, "FINISHED", False) = 0
								If flag10 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
								End If
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112DB RID: 70363 RVA: 0x009F7390 File Offset: 0x009F5590
		Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id and" & vbCrLf & "    fl.lead_status='", Me.cmbStatus.Text, "'" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f order by lm.lead_id DESC" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, vbCrLf & "    lm.id," & vbCrLf & "    ISNULL(f.lead_status, 'NEW LEAD') AS latest_lead_status," & vbCrLf & "    lm.lead_id," & vbCrLf & "    f.remarks AS latest_lead_remarks,    " & vbCrLf & "    CONVERT(VARCHAR(11), f.reminder_date, 105) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), f.reminder_time, 100), 7)), 7) AS reminder_datetime,      " & vbCrLf & "    lm.customer_name," & vbCrLf & "    lm.coordinate_mode," & vbCrLf & "    lm.mobile,    " & vbCrLf & "    f.rating," & vbCrLf & "    lm.interest_mode," & vbCrLf & "    lm.state," & vbCrLf & "    lm.address,    " & vbCrLf & "    lm.productname," & vbCrLf & "    lm.alloted_user," & vbCrLf & "    f.followup_date,lm.lead_date" & vbCrLf & "FROM tbl_lead_master lm" & vbCrLf & "OUTER APPLY (" & vbCrLf & "    SELECT TOP 1 " & vbCrLf & "    fl.lead_status, " & vbCrLf & "        fl.remarks, " & vbCrLf & "        fl.reminder_date, " & vbCrLf & "        fl.reminder_time,fl.rating,fl.followup_date" & vbCrLf & "    FROM tbl_followup_lead fl" & vbCrLf & "    WHERE fl.lead_id = lm.id and" & vbCrLf & "    fl.lead_status='", Me.cmbStatus.Text, "'" & vbCrLf & "    ORDER BY fl.followup_id DESC   " & vbCrLf & ") f where lm.alloted_user='", Me.lblUser.Text, "' order by lm.lead_id DESC" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim flag3 As Boolean = (Operators.CompareString(ModCommonClasses.rdr(1).ToString(), "NEW LEAD", False) = 0) And (Operators.CompareString(Me.cmbStatus.Text, "NEW LEAD", False) = 0)
					If flag3 Then
						Dim text As String = ""
						Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
						If flag4 Then
							Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
							text = New String("★"c, num) + New String("☆"c, 5 - num)
						End If
						Dim num2 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(num2)
						Dim text2 As String = ModCommonClasses.rdr(1).ToString().Trim()
						Dim flag5 As Boolean = Operators.CompareString(text2, "NEW LEAD", False) = 0
						If flag5 Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGreen
						Else
							Dim flag6 As Boolean = Operators.CompareString(text2.ToUpper(), "FOLLOW-UP", False) = 0
							If flag6 Then
								Dim dateTime As DateTime
								Dim flag7 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime)
								If flag7 Then
									Dim flag8 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
									If flag8 Then
										dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
									Else
										dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
									End If
								Else
									dataGridViewRow.DefaultCellStyle.BackColor = Color.LightPink
								End If
							Else
								Dim flag9 As Boolean = Operators.CompareString(text2, "FINISHED", False) = 0
								If flag9 Then
									dataGridViewRow.DefaultCellStyle.BackColor = Color.Orange
								End If
							End If
						End If
					Else
						Dim flag10 As Boolean = (Operators.CompareString(ModCommonClasses.rdr(1).ToString(), "FOLLOW-UP", False) = 0) And (Operators.CompareString(Me.cmbStatus.Text, "FOLLOW-UP", False) = 0)
						If flag10 Then
							Dim text3 As String = ""
							Dim flag11 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
							If flag11 Then
								Dim num3 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
								text3 = New String("★"c, num3) + New String("☆"c, 5 - num3)
							End If
							Dim num4 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text3, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
							Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(num4)
							Dim text4 As String = ModCommonClasses.rdr(1).ToString().Trim()
							Dim flag12 As Boolean = Operators.CompareString(text4, "NEW LEAD", False) = 0
							If flag12 Then
								dataGridViewRow2.DefaultCellStyle.BackColor = Color.LightGreen
							Else
								Dim flag13 As Boolean = Operators.CompareString(text4.ToUpper(), "FOLLOW-UP", False) = 0
								If flag13 Then
									Dim dateTime2 As DateTime
									Dim flag14 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime2)
									If flag14 Then
										Dim flag15 As Boolean = DateTime.Compare(dateTime2.[Date], DateTime.Today) = 0
										If flag15 Then
											dataGridViewRow2.DefaultCellStyle.BackColor = Color.Yellow
										Else
											dataGridViewRow2.DefaultCellStyle.BackColor = Color.LightPink
										End If
									Else
										dataGridViewRow2.DefaultCellStyle.BackColor = Color.LightPink
									End If
								Else
									Dim flag16 As Boolean = Operators.CompareString(text4, "FINISHED", False) = 0
									If flag16 Then
										dataGridViewRow2.DefaultCellStyle.BackColor = Color.Orange
									End If
								End If
							End If
						Else
							Dim flag17 As Boolean = (Operators.CompareString(ModCommonClasses.rdr(1).ToString(), "FINISHED", False) = 0) And (Operators.CompareString(Me.cmbStatus.Text, "FINISHED", False) = 0)
							If flag17 Then
								Dim text5 As String = ""
								Dim flag18 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
								If flag18 Then
									Dim num5 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
									text5 = New String("★"c, num5) + New String("☆"c, 5 - num5)
								End If
								Dim num6 As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), text5, ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
								Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.Rows(num6)
								Dim text6 As String = ModCommonClasses.rdr(1).ToString().Trim()
								Dim flag19 As Boolean = Operators.CompareString(text6, "NEW LEAD", False) = 0
								If flag19 Then
									dataGridViewRow3.DefaultCellStyle.BackColor = Color.LightGreen
								Else
									Dim flag20 As Boolean = Operators.CompareString(text6.ToUpper(), "FOLLOW-UP", False) = 0
									If flag20 Then
										Dim dateTime3 As DateTime
										Dim flag21 As Boolean = DateTime.TryParse(ModCommonClasses.rdr(14).ToString(), dateTime3)
										If flag21 Then
											Dim flag22 As Boolean = DateTime.Compare(dateTime3.[Date], DateTime.Today) = 0
											If flag22 Then
												dataGridViewRow3.DefaultCellStyle.BackColor = Color.Yellow
											Else
												dataGridViewRow3.DefaultCellStyle.BackColor = Color.LightPink
											End If
										Else
											dataGridViewRow3.DefaultCellStyle.BackColor = Color.LightPink
										End If
									Else
										Dim flag23 As Boolean = Operators.CompareString(text6, "FINISHED", False) = 0
										If flag23 Then
											dataGridViewRow3.DefaultCellStyle.BackColor = Color.Orange
										End If
									End If
								End If
							End If
						End If
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060112DC RID: 70364 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060112DD RID: 70365 RVA: 0x0001A794 File Offset: 0x00018994
		Private Sub frmCustomerRecord_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmQuotation.FillCustomers()
		End Sub

		' Token: 0x04006752 RID: 26450
		Private num1 As Decimal

		' Token: 0x04006753 RID: 26451
		Private num2 As Decimal

		' Token: 0x04006754 RID: 26452
		Private num3 As Decimal

		' Token: 0x04006755 RID: 26453
		Private str As String
	End Class
End Namespace
