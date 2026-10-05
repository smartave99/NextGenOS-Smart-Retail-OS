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
	' Token: 0x020000C6 RID: 198
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupportLog_Dashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600213F RID: 8511 RVA: 0x00154F10 File Offset: 0x00153110
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSheet_Report_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerSupportLog_Dashboard_KeyDown
			Me.dt = New DataTable()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000D37 RID: 3383
		' (get) Token: 0x06002142 RID: 8514 RVA: 0x000173B1 File Offset: 0x000155B1
		' (set) Token: 0x06002143 RID: 8515 RVA: 0x00157D7C File Offset: 0x00155F7C
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

		' Token: 0x17000D38 RID: 3384
		' (get) Token: 0x06002144 RID: 8516 RVA: 0x000173BB File Offset: 0x000155BB
		' (set) Token: 0x06002145 RID: 8517 RVA: 0x00157DF8 File Offset: 0x00155FF8
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

		' Token: 0x17000D39 RID: 3385
		' (get) Token: 0x06002146 RID: 8518 RVA: 0x000173C5 File Offset: 0x000155C5
		' (set) Token: 0x06002147 RID: 8519 RVA: 0x000173CF File Offset: 0x000155CF
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000D3A RID: 3386
		' (get) Token: 0x06002148 RID: 8520 RVA: 0x000173D8 File Offset: 0x000155D8
		' (set) Token: 0x06002149 RID: 8521 RVA: 0x00157E3C File Offset: 0x0015603C
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

		' Token: 0x17000D3B RID: 3387
		' (get) Token: 0x0600214A RID: 8522 RVA: 0x000173E2 File Offset: 0x000155E2
		' (set) Token: 0x0600214B RID: 8523 RVA: 0x000173EC File Offset: 0x000155EC
		Friend Overridable Property Label3 As Label

		' Token: 0x17000D3C RID: 3388
		' (get) Token: 0x0600214C RID: 8524 RVA: 0x000173F5 File Offset: 0x000155F5
		' (set) Token: 0x0600214D RID: 8525 RVA: 0x000173FF File Offset: 0x000155FF
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17000D3D RID: 3389
		' (get) Token: 0x0600214E RID: 8526 RVA: 0x00017408 File Offset: 0x00015608
		' (set) Token: 0x0600214F RID: 8527 RVA: 0x00017412 File Offset: 0x00015612
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000D3E RID: 3390
		' (get) Token: 0x06002150 RID: 8528 RVA: 0x0001741B File Offset: 0x0001561B
		' (set) Token: 0x06002151 RID: 8529 RVA: 0x00157E80 File Offset: 0x00156080
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

		' Token: 0x17000D3F RID: 3391
		' (get) Token: 0x06002152 RID: 8530 RVA: 0x00017425 File Offset: 0x00015625
		' (set) Token: 0x06002153 RID: 8531 RVA: 0x0001742F File Offset: 0x0001562F
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000D40 RID: 3392
		' (get) Token: 0x06002154 RID: 8532 RVA: 0x00017438 File Offset: 0x00015638
		' (set) Token: 0x06002155 RID: 8533 RVA: 0x00017442 File Offset: 0x00015642
		Friend Overridable Property Label2 As Label

		' Token: 0x17000D41 RID: 3393
		' (get) Token: 0x06002156 RID: 8534 RVA: 0x0001744B File Offset: 0x0001564B
		' (set) Token: 0x06002157 RID: 8535 RVA: 0x00017455 File Offset: 0x00015655
		Friend Overridable Property Label1 As Label

		' Token: 0x17000D42 RID: 3394
		' (get) Token: 0x06002158 RID: 8536 RVA: 0x0001745E File Offset: 0x0001565E
		' (set) Token: 0x06002159 RID: 8537 RVA: 0x00017468 File Offset: 0x00015668
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17000D43 RID: 3395
		' (get) Token: 0x0600215A RID: 8538 RVA: 0x00017471 File Offset: 0x00015671
		' (set) Token: 0x0600215B RID: 8539 RVA: 0x0001747B File Offset: 0x0001567B
		Friend Overridable Property Label4 As Label

		' Token: 0x17000D44 RID: 3396
		' (get) Token: 0x0600215C RID: 8540 RVA: 0x00017484 File Offset: 0x00015684
		' (set) Token: 0x0600215D RID: 8541 RVA: 0x00157EC4 File Offset: 0x001560C4
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

		' Token: 0x17000D45 RID: 3397
		' (get) Token: 0x0600215E RID: 8542 RVA: 0x0001748E File Offset: 0x0001568E
		' (set) Token: 0x0600215F RID: 8543 RVA: 0x00157F08 File Offset: 0x00156108
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

		' Token: 0x17000D46 RID: 3398
		' (get) Token: 0x06002160 RID: 8544 RVA: 0x00017498 File Offset: 0x00015698
		' (set) Token: 0x06002161 RID: 8545 RVA: 0x00157F4C File Offset: 0x0015614C
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

		' Token: 0x17000D47 RID: 3399
		' (get) Token: 0x06002162 RID: 8546 RVA: 0x000174A2 File Offset: 0x000156A2
		' (set) Token: 0x06002163 RID: 8547 RVA: 0x000174AC File Offset: 0x000156AC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000D48 RID: 3400
		' (get) Token: 0x06002164 RID: 8548 RVA: 0x000174B5 File Offset: 0x000156B5
		' (set) Token: 0x06002165 RID: 8549 RVA: 0x000174BF File Offset: 0x000156BF
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000D49 RID: 3401
		' (get) Token: 0x06002166 RID: 8550 RVA: 0x000174C8 File Offset: 0x000156C8
		' (set) Token: 0x06002167 RID: 8551 RVA: 0x000174D2 File Offset: 0x000156D2
		Friend Overridable Property Label5 As Label

		' Token: 0x17000D4A RID: 3402
		' (get) Token: 0x06002168 RID: 8552 RVA: 0x000174DB File Offset: 0x000156DB
		' (set) Token: 0x06002169 RID: 8553 RVA: 0x000174E5 File Offset: 0x000156E5
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000D4B RID: 3403
		' (get) Token: 0x0600216A RID: 8554 RVA: 0x000174EE File Offset: 0x000156EE
		' (set) Token: 0x0600216B RID: 8555 RVA: 0x000174F8 File Offset: 0x000156F8
		Friend Overridable Property Label18 As Label

		' Token: 0x17000D4C RID: 3404
		' (get) Token: 0x0600216C RID: 8556 RVA: 0x00017501 File Offset: 0x00015701
		' (set) Token: 0x0600216D RID: 8557 RVA: 0x0001750B File Offset: 0x0001570B
		Friend Overridable Property Label21 As Label

		' Token: 0x17000D4D RID: 3405
		' (get) Token: 0x0600216E RID: 8558 RVA: 0x00017514 File Offset: 0x00015714
		' (set) Token: 0x0600216F RID: 8559 RVA: 0x0001751E File Offset: 0x0001571E
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17000D4E RID: 3406
		' (get) Token: 0x06002170 RID: 8560 RVA: 0x00017527 File Offset: 0x00015727
		' (set) Token: 0x06002171 RID: 8561 RVA: 0x00157F90 File Offset: 0x00156190
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

		' Token: 0x17000D4F RID: 3407
		' (get) Token: 0x06002172 RID: 8562 RVA: 0x00017531 File Offset: 0x00015731
		' (set) Token: 0x06002173 RID: 8563 RVA: 0x0001753B File Offset: 0x0001573B
		Friend Overridable Property pnl_FollowUp As Panel

		' Token: 0x17000D50 RID: 3408
		' (get) Token: 0x06002174 RID: 8564 RVA: 0x00017544 File Offset: 0x00015744
		' (set) Token: 0x06002175 RID: 8565 RVA: 0x0001754E File Offset: 0x0001574E
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000D51 RID: 3409
		' (get) Token: 0x06002176 RID: 8566 RVA: 0x00017557 File Offset: 0x00015757
		' (set) Token: 0x06002177 RID: 8567 RVA: 0x00017561 File Offset: 0x00015761
		Friend Overridable Property lblTokenNo As Label

		' Token: 0x17000D52 RID: 3410
		' (get) Token: 0x06002178 RID: 8568 RVA: 0x0001756A File Offset: 0x0001576A
		' (set) Token: 0x06002179 RID: 8569 RVA: 0x00157FD4 File Offset: 0x001561D4
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

		' Token: 0x17000D53 RID: 3411
		' (get) Token: 0x0600217A RID: 8570 RVA: 0x00017574 File Offset: 0x00015774
		' (set) Token: 0x0600217B RID: 8571 RVA: 0x0001757E File Offset: 0x0001577E
		Friend Overridable Property txtRemarks As TextBox

		' Token: 0x17000D54 RID: 3412
		' (get) Token: 0x0600217C RID: 8572 RVA: 0x00017587 File Offset: 0x00015787
		' (set) Token: 0x0600217D RID: 8573 RVA: 0x00017591 File Offset: 0x00015791
		Friend Overridable Property Label6 As Label

		' Token: 0x17000D55 RID: 3413
		' (get) Token: 0x0600217E RID: 8574 RVA: 0x0001759A File Offset: 0x0001579A
		' (set) Token: 0x0600217F RID: 8575 RVA: 0x000175A4 File Offset: 0x000157A4
		Friend Overridable Property lbl_Id As Label

		' Token: 0x17000D56 RID: 3414
		' (get) Token: 0x06002180 RID: 8576 RVA: 0x000175AD File Offset: 0x000157AD
		' (set) Token: 0x06002181 RID: 8577 RVA: 0x000175B7 File Offset: 0x000157B7
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000D57 RID: 3415
		' (get) Token: 0x06002182 RID: 8578 RVA: 0x000175C0 File Offset: 0x000157C0
		' (set) Token: 0x06002183 RID: 8579 RVA: 0x000175CA File Offset: 0x000157CA
		Friend Overridable Property lblUser As Label

		' Token: 0x17000D58 RID: 3416
		' (get) Token: 0x06002184 RID: 8580 RVA: 0x000175D3 File Offset: 0x000157D3
		' (set) Token: 0x06002185 RID: 8581 RVA: 0x00158018 File Offset: 0x00156218
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

		' Token: 0x17000D59 RID: 3417
		' (get) Token: 0x06002186 RID: 8582 RVA: 0x000175DD File Offset: 0x000157DD
		' (set) Token: 0x06002187 RID: 8583 RVA: 0x000175E7 File Offset: 0x000157E7
		Friend Overridable Property lbl_tokenid As Label

		' Token: 0x17000D5A RID: 3418
		' (get) Token: 0x06002188 RID: 8584 RVA: 0x000175F0 File Offset: 0x000157F0
		' (set) Token: 0x06002189 RID: 8585 RVA: 0x000175FA File Offset: 0x000157FA
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x17000D5B RID: 3419
		' (get) Token: 0x0600218A RID: 8586 RVA: 0x00017603 File Offset: 0x00015803
		' (set) Token: 0x0600218B RID: 8587 RVA: 0x0001760D File Offset: 0x0001580D
		Friend Overridable Property lblCount As Label

		' Token: 0x17000D5C RID: 3420
		' (get) Token: 0x0600218C RID: 8588 RVA: 0x00017616 File Offset: 0x00015816
		' (set) Token: 0x0600218D RID: 8589 RVA: 0x00017620 File Offset: 0x00015820
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000D5D RID: 3421
		' (get) Token: 0x0600218E RID: 8590 RVA: 0x00017629 File Offset: 0x00015829
		' (set) Token: 0x0600218F RID: 8591 RVA: 0x00017633 File Offset: 0x00015833
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000D5E RID: 3422
		' (get) Token: 0x06002190 RID: 8592 RVA: 0x0001763C File Offset: 0x0001583C
		' (set) Token: 0x06002191 RID: 8593 RVA: 0x00017646 File Offset: 0x00015846
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17000D5F RID: 3423
		' (get) Token: 0x06002192 RID: 8594 RVA: 0x0001764F File Offset: 0x0001584F
		' (set) Token: 0x06002193 RID: 8595 RVA: 0x00017659 File Offset: 0x00015859
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000D60 RID: 3424
		' (get) Token: 0x06002194 RID: 8596 RVA: 0x00017662 File Offset: 0x00015862
		' (set) Token: 0x06002195 RID: 8597 RVA: 0x0001766C File Offset: 0x0001586C
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000D61 RID: 3425
		' (get) Token: 0x06002196 RID: 8598 RVA: 0x00017675 File Offset: 0x00015875
		' (set) Token: 0x06002197 RID: 8599 RVA: 0x0001767F File Offset: 0x0001587F
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000D62 RID: 3426
		' (get) Token: 0x06002198 RID: 8600 RVA: 0x00017688 File Offset: 0x00015888
		' (set) Token: 0x06002199 RID: 8601 RVA: 0x00017692 File Offset: 0x00015892
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000D63 RID: 3427
		' (get) Token: 0x0600219A RID: 8602 RVA: 0x0001769B File Offset: 0x0001589B
		' (set) Token: 0x0600219B RID: 8603 RVA: 0x000176A5 File Offset: 0x000158A5
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17000D64 RID: 3428
		' (get) Token: 0x0600219C RID: 8604 RVA: 0x000176AE File Offset: 0x000158AE
		' (set) Token: 0x0600219D RID: 8605 RVA: 0x000176B8 File Offset: 0x000158B8
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17000D65 RID: 3429
		' (get) Token: 0x0600219E RID: 8606 RVA: 0x000176C1 File Offset: 0x000158C1
		' (set) Token: 0x0600219F RID: 8607 RVA: 0x000176CB File Offset: 0x000158CB
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17000D66 RID: 3430
		' (get) Token: 0x060021A0 RID: 8608 RVA: 0x000176D4 File Offset: 0x000158D4
		' (set) Token: 0x060021A1 RID: 8609 RVA: 0x000176DE File Offset: 0x000158DE
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17000D67 RID: 3431
		' (get) Token: 0x060021A2 RID: 8610 RVA: 0x000176E7 File Offset: 0x000158E7
		' (set) Token: 0x060021A3 RID: 8611 RVA: 0x0015805C File Offset: 0x0015625C
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

		' Token: 0x17000D68 RID: 3432
		' (get) Token: 0x060021A4 RID: 8612 RVA: 0x000176F1 File Offset: 0x000158F1
		' (set) Token: 0x060021A5 RID: 8613 RVA: 0x000176FB File Offset: 0x000158FB
		Friend Overridable Property lblNumbers As Label

		' Token: 0x17000D69 RID: 3433
		' (get) Token: 0x060021A6 RID: 8614 RVA: 0x00017704 File Offset: 0x00015904
		' (set) Token: 0x060021A7 RID: 8615 RVA: 0x0001770E File Offset: 0x0001590E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000D6A RID: 3434
		' (get) Token: 0x060021A8 RID: 8616 RVA: 0x00017717 File Offset: 0x00015917
		' (set) Token: 0x060021A9 RID: 8617 RVA: 0x00017721 File Offset: 0x00015921
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000D6B RID: 3435
		' (get) Token: 0x060021AA RID: 8618 RVA: 0x0001772A File Offset: 0x0001592A
		' (set) Token: 0x060021AB RID: 8619 RVA: 0x00017734 File Offset: 0x00015934
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000D6C RID: 3436
		' (get) Token: 0x060021AC RID: 8620 RVA: 0x0001773D File Offset: 0x0001593D
		' (set) Token: 0x060021AD RID: 8621 RVA: 0x00017747 File Offset: 0x00015947
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000D6D RID: 3437
		' (get) Token: 0x060021AE RID: 8622 RVA: 0x00017750 File Offset: 0x00015950
		' (set) Token: 0x060021AF RID: 8623 RVA: 0x0001775A File Offset: 0x0001595A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000D6E RID: 3438
		' (get) Token: 0x060021B0 RID: 8624 RVA: 0x00017763 File Offset: 0x00015963
		' (set) Token: 0x060021B1 RID: 8625 RVA: 0x0001776D File Offset: 0x0001596D
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000D6F RID: 3439
		' (get) Token: 0x060021B2 RID: 8626 RVA: 0x00017776 File Offset: 0x00015976
		' (set) Token: 0x060021B3 RID: 8627 RVA: 0x00017780 File Offset: 0x00015980
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000D70 RID: 3440
		' (get) Token: 0x060021B4 RID: 8628 RVA: 0x00017789 File Offset: 0x00015989
		' (set) Token: 0x060021B5 RID: 8629 RVA: 0x00017793 File Offset: 0x00015993
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000D71 RID: 3441
		' (get) Token: 0x060021B6 RID: 8630 RVA: 0x0001779C File Offset: 0x0001599C
		' (set) Token: 0x060021B7 RID: 8631 RVA: 0x000177A6 File Offset: 0x000159A6
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000D72 RID: 3442
		' (get) Token: 0x060021B8 RID: 8632 RVA: 0x000177AF File Offset: 0x000159AF
		' (set) Token: 0x060021B9 RID: 8633 RVA: 0x000177B9 File Offset: 0x000159B9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000D73 RID: 3443
		' (get) Token: 0x060021BA RID: 8634 RVA: 0x000177C2 File Offset: 0x000159C2
		' (set) Token: 0x060021BB RID: 8635 RVA: 0x000177CC File Offset: 0x000159CC
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000D74 RID: 3444
		' (get) Token: 0x060021BC RID: 8636 RVA: 0x000177D5 File Offset: 0x000159D5
		' (set) Token: 0x060021BD RID: 8637 RVA: 0x000177DF File Offset: 0x000159DF
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000D75 RID: 3445
		' (get) Token: 0x060021BE RID: 8638 RVA: 0x000177E8 File Offset: 0x000159E8
		' (set) Token: 0x060021BF RID: 8639 RVA: 0x000177F2 File Offset: 0x000159F2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000D76 RID: 3446
		' (get) Token: 0x060021C0 RID: 8640 RVA: 0x000177FB File Offset: 0x000159FB
		' (set) Token: 0x060021C1 RID: 8641 RVA: 0x00017805 File Offset: 0x00015A05
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000D77 RID: 3447
		' (get) Token: 0x060021C2 RID: 8642 RVA: 0x0001780E File Offset: 0x00015A0E
		' (set) Token: 0x060021C3 RID: 8643 RVA: 0x00017818 File Offset: 0x00015A18
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000D78 RID: 3448
		' (get) Token: 0x060021C4 RID: 8644 RVA: 0x00017821 File Offset: 0x00015A21
		' (set) Token: 0x060021C5 RID: 8645 RVA: 0x0001782B File Offset: 0x00015A2B
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000D79 RID: 3449
		' (get) Token: 0x060021C6 RID: 8646 RVA: 0x00017834 File Offset: 0x00015A34
		' (set) Token: 0x060021C7 RID: 8647 RVA: 0x0001783E File Offset: 0x00015A3E
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000D7A RID: 3450
		' (get) Token: 0x060021C8 RID: 8648 RVA: 0x00017847 File Offset: 0x00015A47
		' (set) Token: 0x060021C9 RID: 8649 RVA: 0x00017851 File Offset: 0x00015A51
		Friend Overridable Property btnJoin As DataGridViewButtonColumn

		' Token: 0x17000D7B RID: 3451
		' (get) Token: 0x060021CA RID: 8650 RVA: 0x0001785A File Offset: 0x00015A5A
		' (set) Token: 0x060021CB RID: 8651 RVA: 0x00017864 File Offset: 0x00015A64
		Friend Overridable Property btnFollow As DataGridViewButtonColumn

		' Token: 0x17000D7C RID: 3452
		' (get) Token: 0x060021CC RID: 8652 RVA: 0x0001786D File Offset: 0x00015A6D
		' (set) Token: 0x060021CD RID: 8653 RVA: 0x00017877 File Offset: 0x00015A77
		Friend Overridable Property lblCurrentIssue As Label

		' Token: 0x17000D7D RID: 3453
		' (get) Token: 0x060021CE RID: 8654 RVA: 0x00017880 File Offset: 0x00015A80
		' (set) Token: 0x060021CF RID: 8655 RVA: 0x0001788A File Offset: 0x00015A8A
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000D7E RID: 3454
		' (get) Token: 0x060021D0 RID: 8656 RVA: 0x00017893 File Offset: 0x00015A93
		' (set) Token: 0x060021D1 RID: 8657 RVA: 0x001580A0 File Offset: 0x001562A0
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

		' Token: 0x17000D7F RID: 3455
		' (get) Token: 0x060021D2 RID: 8658 RVA: 0x0001789D File Offset: 0x00015A9D
		' (set) Token: 0x060021D3 RID: 8659 RVA: 0x000178A7 File Offset: 0x00015AA7
		Friend Overridable Property Label7 As Label

		' Token: 0x17000D80 RID: 3456
		' (get) Token: 0x060021D4 RID: 8660 RVA: 0x000178B0 File Offset: 0x00015AB0
		' (set) Token: 0x060021D5 RID: 8661 RVA: 0x001580E4 File Offset: 0x001562E4
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

		' Token: 0x060021D6 RID: 8662 RVA: 0x000178BA File Offset: 0x00015ABA
		Private Sub frmGSheet_Report_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x060021D7 RID: 8663 RVA: 0x00158128 File Offset: 0x00156328
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

		' Token: 0x060021D8 RID: 8664 RVA: 0x001581FC File Offset: 0x001563FC
		Private Sub LoadCustomerSupportLogs(Optional statusFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportLog_Dashboard "
					Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag Then
						text += "WHERE Status = @status OR Join_user = @join_user "
					Else
						Dim flag2 As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
						If flag2 Then
							Dim flag3 As Boolean = Operators.CompareString(statusFilter, "Process1", False) = 0
							If flag3 Then
								text += "WHERE Status in @status "
							Else
								text += "WHERE Status = @status "
							End If
						End If
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag4 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag4 Then
							sqlCommand.Parameters.AddWithValue("@status", "Open")
							sqlCommand.Parameters.AddWithValue("@join_user", Me.lblUser.Text)
						Else
							Dim flag5 As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
							If flag5 Then
								Dim text2 As String = "Process, Postpone"
								Dim flag6 As Boolean = Operators.CompareString(statusFilter, "Process1", False) = 0
								If flag6 Then
									sqlCommand.Parameters.AddWithValue("@status", text2)
								Else
									sqlCommand.Parameters.AddWithValue("@status", statusFilter)
								End If
							End If
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

		' Token: 0x060021D9 RID: 8665 RVA: 0x00158564 File Offset: 0x00156764
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
					Dim flag4 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnFollow").Index
					If flag4 Then
						Dim flag5 As Boolean = Operators.CompareString(text, "Open", False) <> 0
						If flag5 Then
							e.Value = "Follow"
							e.CellStyle.BackColor = Global.System.Drawing.Color.LightBlue
						Else
							e.Value = "Disabled"
							e.CellStyle.BackColor = Global.System.Drawing.Color.LightGray
						End If
					End If
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x060021DA RID: 8666 RVA: 0x000178F8 File Offset: 0x00015AF8
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x060021DB RID: 8667 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x060021DC RID: 8668 RVA: 0x001586DC File Offset: 0x001568DC
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

		' Token: 0x060021DD RID: 8669 RVA: 0x001589E4 File Offset: 0x00156BE4
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportLog_Dashboard "
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

		' Token: 0x060021DE RID: 8670 RVA: 0x00158CD4 File Offset: 0x00156ED4
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT LogID,support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportLog_Dashboard WHERE LogTimestamp BETWEEN @d1 AND @d2 "
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

		' Token: 0x060021DF RID: 8671 RVA: 0x00158FD4 File Offset: 0x001571D4
		Private Sub rdo_Open_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Open.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Open")
			End If
		End Sub

		' Token: 0x060021E0 RID: 8672 RVA: 0x00159000 File Offset: 0x00157200
		Private Sub rdo_Process_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Process.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Process")
			End If
		End Sub

		' Token: 0x060021E1 RID: 8673 RVA: 0x0015902C File Offset: 0x0015722C
		Private Sub rdo_Closed_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Closed.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Closed")
			End If
		End Sub

		' Token: 0x060021E2 RID: 8674 RVA: 0x00159058 File Offset: 0x00157258
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
										Dim sqlCommand As SqlCommand = New SqlCommand("INSERT INTO CustomerSupportLog_Dashboard " & vbCrLf & "                            (LogTimestamp, support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, " & vbCrLf & "                            CurrentIssue, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress) " & vbCrLf & "                            VALUES (@LogTimestamp,@support_token_no,@CustomerName,@RegisteredMobileNumber,@CallingNumber," & vbCrLf & "                            @CurrentIssue,@SoftwareName,@SoftwareValidity,@Status,@Remark,@Feedback,@Rating,@EmailAddress)", sqlConnection)
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

		' Token: 0x060021E3 RID: 8675 RVA: 0x0015954C File Offset: 0x0015774C
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnFollow").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.lbl_Id.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.lbl_tokenid.Text = dataGridViewRow.Cells(1).Value.ToString()
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
							Dim text6 As String = "UPDATE CustomerSupportLog_Dashboard SET Join_user=@userID, Join_date=GETDATE(), Status='Postpone' WHERE LogID=@logID"
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

		' Token: 0x060021E4 RID: 8676 RVA: 0x001599CC File Offset: 0x00157BCC
		Private Sub frmCustomerSupportLog_Dashboard_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.pnl_FollowUp.Visible = False
			End If
		End Sub

		' Token: 0x060021E5 RID: 8677 RVA: 0x001599F8 File Offset: 0x00157BF8
		Private Sub btnTokenUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT Status FROM CustomerSupportLog_Dashboard WHERE LogId=@LogId"
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
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to Update '" + Me.lbl_Id.Text + "'?", "Update Log", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag5 As Boolean = dialogResult = DialogResult.Yes
					If flag5 Then
						Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection2.Open()
							Dim text3 As String = "UPDATE CustomerSupportLog_Dashboard SET Status = 'Process', Remark = @Remark WHERE LogId = @LogId"
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

		' Token: 0x060021E6 RID: 8678 RVA: 0x00159D1C File Offset: 0x00157F1C
		Private Sub btnClosed_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT Status FROM CustomerSupportLog_Dashboard WHERE LogId=@LogId"
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
						Dim flag6 As Boolean = ModFunc.CheckForInternetConnection()
						If flag6 Then
							Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection2.Open()
								Dim text3 As String = "UPDATE CustomerSupportLog_Dashboard SET Status = 'Closed', Close_date=GETDATE(), Remark = @Remark WHERE LogId = @LogId"
								Using sqlCommand2 As SqlCommand = New SqlCommand(text3, sqlConnection2)
									sqlCommand2.Parameters.AddWithValue("@Remark", Me.txtRemarks.Text.Trim())
									sqlCommand2.Parameters.AddWithValue("@LogId", Convert.ToInt32(Me.lbl_Id.Text))
									Dim num As Integer = sqlCommand2.ExecuteNonQuery()
									Me.LoadCustomerSupportLogs("")
									Me.pnl_FollowUp.Visible = False
									MessageBox.Show(num.ToString() + " record(s) updated to Closed.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								End Using
							End Using
							Dim text4 As String = Path.Combine(Application.StartupPath, "credentials_.json")
							Dim googleCredential As GoogleCredential
							Using fileStream As FileStream = New FileStream(text4, FileMode.Open, FileAccess.Read)
								googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(New String() { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets })
							End Using
							Dim sheetsService As SheetsService = New SheetsService(New BaseClientService.Initializer() With { .HttpClientInitializer = googleCredential, .ApplicationName = "Customer Support Logger" })
							Dim text5 As String = "10Jp2rmH0KQ-6mNWHH3fTVX1eKHPnsipglEwlex9LyHg"
							Dim text6 As String = "Form Responses 1"
							Dim getRequest As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](text5, text6 + "!A2:M")
							Dim valueRange As ValueRange = getRequest.Execute()
							Dim flag7 As Boolean = valueRange.Values IsNot Nothing
							If flag7 Then
								Dim num2 As Integer = valueRange.Values.Count - 1
								For i As Integer = 0 To num2
									Dim list As IList(Of Object) = valueRange.Values(i)
									Dim flag8 As Boolean = list.Count > 1 AndAlso Operators.CompareString(list(1).ToString(), Me.lbl_tokenid.Text, False) = 0
									If flag8 Then
										Dim text7 As String = String.Concat(New String() { text6, "!I", (i + 2).ToString(), ":J", (i + 2).ToString() })
										Dim valueRange2 As ValueRange = New ValueRange() With { .Values = New List(Of IList(Of Object))() From { New List(Of Object)() From { "Closed", Me.txtRemarks.Text.Trim() } } }
										Dim updateRequest As SpreadsheetsResource.ValuesResource.UpdateRequest = sheetsService.Spreadsheets.Values.Update(valueRange2, text5, text7)
										updateRequest.ValueInputOption = New SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum?(SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED)
										updateRequest.Execute()
										Exit For
									End If
								Next
							End If
						Else
							Using sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection3.Open()
								Dim text8 As String = "UPDATE CustomerSupportLog_Dashboard SET Status = 'Closed_Offline', Close_date=GETDATE(), Remark = @Remark WHERE LogId = @LogId"
								Using sqlCommand3 As SqlCommand = New SqlCommand(text8, sqlConnection3)
									sqlCommand3.Parameters.AddWithValue("@Remark", Me.txtRemarks.Text.Trim())
									sqlCommand3.Parameters.AddWithValue("@LogId", Convert.ToInt32(Me.lbl_Id.Text))
									Dim num3 As Integer = sqlCommand3.ExecuteNonQuery()
									Me.LoadCustomerSupportLogs("")
									Me.pnl_FollowUp.Visible = False
									MessageBox.Show(num3.ToString() + " record(s) updated to Closed.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								End Using
							End Using
						End If
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060021E7 RID: 8679 RVA: 0x0015A360 File Offset: 0x00158560
		Private Sub LoadCustomerSupportLogs_mobile(Optional mobileFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, SoftwareName, CustomerName, RegisteredMobileNumber, LogTimestamp, CurrentIssue, Remark, Close_date, Feedback, Rating FROM CustomerSupportLog_Dashboard WHERE Status in ('Closed','Closed_Offline') "
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

		' Token: 0x060021E8 RID: 8680 RVA: 0x0015A594 File Offset: 0x00158794
		Private Function GetTokenCountByMobile(mobile As String) As Integer
			Dim num As Integer = 0
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT COUNT(support_token_no) AS TokenCount FROM CustomerSupportLog_Dashboard WHERE RegisteredMobileNumber = @mobile"
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

		' Token: 0x060021E9 RID: 8681 RVA: 0x0001792E File Offset: 0x00015B2E
		Private Sub lnkPanle_CLose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.pnl_FollowUp.Visible = False
			Me.txtRemarks.Text = ""
		End Sub

		' Token: 0x060021EA RID: 8682 RVA: 0x0015A68C File Offset: 0x0015888C
		Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportLog_Dashboard "
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

		' Token: 0x060021EB RID: 8683 RVA: 0x0015A97C File Offset: 0x00158B7C
		Private Sub btnOffline_Online_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = ModFunc.CheckForInternetConnection()
				If flag Then
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT LogId, support_token_no, Remark " & vbCrLf & "                                                    FROM CustomerSupportLog_Dashboard " & vbCrLf & "                                                    WHERE Status = 'Closed_Offline'"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								While sqlDataReader.Read()
									Dim num As Integer = Conversions.ToInteger(sqlDataReader("LogId"))
									Dim text2 As String = sqlDataReader("support_token_no").ToString()
									Dim text3 As String = sqlDataReader("Remark").ToString()
									Dim flag2 As Boolean = Me.UpdateGoogleSheetStatus(text2, "Closed", text3)
									If flag2 Then
										Me.UpdateSQLStatusToClosed(num)
									End If
								End While
							End Using
						End Using
					End Using
					Me.LoadCustomerSupportLogs("")
					MessageBox.Show("Online Updated data!")
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060021EC RID: 8684 RVA: 0x00151A54 File Offset: 0x0014FC54
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

		' Token: 0x060021ED RID: 8685 RVA: 0x0015AAB8 File Offset: 0x00158CB8
		Private Sub UpdateSQLStatusToClosed(logId As Integer)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "UPDATE CustomerSupportLog_Dashboard " & vbCrLf & "                               SET Status='Closed' " & vbCrLf & "                               WHERE LogId=@LogId"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@LogId", logId)
					sqlCommand.ExecuteNonQuery()
				End Using
			End Using
		End Sub

		' Token: 0x04000DD6 RID: 3542
		Private dt As DataTable
	End Class
End Namespace
