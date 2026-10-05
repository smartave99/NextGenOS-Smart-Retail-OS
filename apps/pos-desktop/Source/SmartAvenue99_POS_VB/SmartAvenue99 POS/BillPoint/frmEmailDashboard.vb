Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net.Http
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports MailKit
Imports MailKit.Net.Imap
Imports MailKit.Net.Smtp
Imports MailKit.Search
Imports MailKit.Security
Imports Microsoft.VisualBasic.CompilerServices
Imports MimeKit
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x020000E0 RID: 224
	<DesignerGenerated()>
	Public Partial Class frmEmailDashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002884 RID: 10372 RVA: 0x001976B8 File Offset: 0x001958B8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEmailDashboard_Load
			Me.inboxMessages = New List(Of MimeMessage)()
			Me.attachmentPath = ""
			Me.strHost = ""
			Me.strName = ""
			Me.strEmailid = ""
			Me.strPassword = ""
			Me.lastSentUid = 0UI
			Me.emailCache = New List(Of frmEmailDashboard.EmailModel)()
			Me.lastFetchedUid = 0UI
			Me.sentEmailCache = New List(Of frmEmailDashboard.EmailModelSent)()
			Me.sentLastFetchedUids = New HashSet(Of UInteger)()
			Me.sentFetchPageIndex = 0
			Me.sentPageSize = 50
			Me.sentCacheFilePath = "sent_cache_email.json"
			Me.fetchPageIndex = 0
			Me.pageSize = 50
			Me.lastFetchedUids = New HashSet(Of UInteger)()
			Me.strmail_type = ""
			Me.apiKey = ""
			Me.url = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000FF1 RID: 4081
		' (get) Token: 0x06002887 RID: 10375 RVA: 0x0001A7A7 File Offset: 0x000189A7
		' (set) Token: 0x06002888 RID: 10376 RVA: 0x00199680 File Offset: 0x00197880
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FF2 RID: 4082
		' (get) Token: 0x06002889 RID: 10377 RVA: 0x0001A7B1 File Offset: 0x000189B1
		' (set) Token: 0x0600288A RID: 10378 RVA: 0x001996C4 File Offset: 0x001978C4
		Private _btnReply As Button
		Friend Overridable Property btnReply As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReply
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReply_Click
				Dim button As Button = Me._btnReply
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReply = value
				button = Me._btnReply
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FF3 RID: 4083
		' (get) Token: 0x0600288B RID: 10379 RVA: 0x0001A7BB File Offset: 0x000189BB
		' (set) Token: 0x0600288C RID: 10380 RVA: 0x0001A7C5 File Offset: 0x000189C5
		Friend Overridable Property Label1 As Label

		' Token: 0x17000FF4 RID: 4084
		' (get) Token: 0x0600288D RID: 10381 RVA: 0x0001A7CE File Offset: 0x000189CE
		' (set) Token: 0x0600288E RID: 10382 RVA: 0x0001A7D8 File Offset: 0x000189D8
		Friend Overridable Property Label2 As Label

		' Token: 0x17000FF5 RID: 4085
		' (get) Token: 0x0600288F RID: 10383 RVA: 0x0001A7E1 File Offset: 0x000189E1
		' (set) Token: 0x06002890 RID: 10384 RVA: 0x0001A7EB File Offset: 0x000189EB
		Friend Overridable Property Label3 As Label

		' Token: 0x17000FF6 RID: 4086
		' (get) Token: 0x06002891 RID: 10385 RVA: 0x0001A7F4 File Offset: 0x000189F4
		' (set) Token: 0x06002892 RID: 10386 RVA: 0x0001A7FE File Offset: 0x000189FE
		Friend Overridable Property txtFrom As TextBox

		' Token: 0x17000FF7 RID: 4087
		' (get) Token: 0x06002893 RID: 10387 RVA: 0x0001A807 File Offset: 0x00018A07
		' (set) Token: 0x06002894 RID: 10388 RVA: 0x0001A811 File Offset: 0x00018A11
		Friend Overridable Property txtSubject As TextBox

		' Token: 0x17000FF8 RID: 4088
		' (get) Token: 0x06002895 RID: 10389 RVA: 0x0001A81A File Offset: 0x00018A1A
		' (set) Token: 0x06002896 RID: 10390 RVA: 0x0001A824 File Offset: 0x00018A24
		Friend Overridable Property rtbBody As TextBox

		' Token: 0x17000FF9 RID: 4089
		' (get) Token: 0x06002897 RID: 10391 RVA: 0x0001A82D File Offset: 0x00018A2D
		' (set) Token: 0x06002898 RID: 10392 RVA: 0x00199708 File Offset: 0x00197908
		Private _lstAttachments As ListBox
		Friend Overridable Property lstAttachments As ListBox
			<CompilerGenerated()>
			Get
				Return Me._lstAttachments
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Dim eventHandler As EventHandler = AddressOf Me.lstAttachments_DoubleClick
				Dim listBox As ListBox = Me._lstAttachments
				If listBox IsNot Nothing Then
					RemoveHandler listBox.DoubleClick, eventHandler
				End If
				Me._lstAttachments = value
				listBox = Me._lstAttachments
				If listBox IsNot Nothing Then
					AddHandler listBox.DoubleClick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FFA RID: 4090
		' (get) Token: 0x06002899 RID: 10393 RVA: 0x0001A837 File Offset: 0x00018A37
		' (set) Token: 0x0600289A RID: 10394 RVA: 0x0019974C File Offset: 0x0019794C
		Private _btnRefresh As Button
		Friend Overridable Property btnRefresh As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRefresh
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRefresh_Click
				Dim button As Button = Me._btnRefresh
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRefresh = value
				button = Me._btnRefresh
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FFB RID: 4091
		' (get) Token: 0x0600289B RID: 10395 RVA: 0x0001A841 File Offset: 0x00018A41
		' (set) Token: 0x0600289C RID: 10396 RVA: 0x00199790 File Offset: 0x00197990
		Private _btnCompose As Button
		Friend Overridable Property btnCompose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCompose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCompose_Click
				Dim button As Button = Me._btnCompose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCompose = value
				button = Me._btnCompose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FFC RID: 4092
		' (get) Token: 0x0600289D RID: 10397 RVA: 0x0001A84B File Offset: 0x00018A4B
		' (set) Token: 0x0600289E RID: 10398 RVA: 0x0001A855 File Offset: 0x00018A55
		Friend Overridable Property pnlCompose As Panel

		' Token: 0x17000FFD RID: 4093
		' (get) Token: 0x0600289F RID: 10399 RVA: 0x0001A85E File Offset: 0x00018A5E
		' (set) Token: 0x060028A0 RID: 10400 RVA: 0x001997D4 File Offset: 0x001979D4
		Private _btnSend As Button
		Friend Overridable Property btnSend As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSend
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSend_Click
				Dim button As Button = Me._btnSend
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSend = value
				button = Me._btnSend
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FFE RID: 4094
		' (get) Token: 0x060028A1 RID: 10401 RVA: 0x0001A868 File Offset: 0x00018A68
		' (set) Token: 0x060028A2 RID: 10402 RVA: 0x00199818 File Offset: 0x00197A18
		Private _txtSubject_compose As TextBox
		Friend Overridable Property txtSubject_compose As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSubject_compose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSubject_compose_Leave
				Dim textBox As TextBox = Me._txtSubject_compose
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Leave, eventHandler
				End If
				Me._txtSubject_compose = value
				textBox = Me._txtSubject_compose
				If textBox IsNot Nothing Then
					AddHandler textBox.Leave, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FFF RID: 4095
		' (get) Token: 0x060028A3 RID: 10403 RVA: 0x0001A872 File Offset: 0x00018A72
		' (set) Token: 0x060028A4 RID: 10404 RVA: 0x0001A87C File Offset: 0x00018A7C
		Friend Overridable Property txtTo As TextBox

		' Token: 0x17001000 RID: 4096
		' (get) Token: 0x060028A5 RID: 10405 RVA: 0x0001A885 File Offset: 0x00018A85
		' (set) Token: 0x060028A6 RID: 10406 RVA: 0x0001A88F File Offset: 0x00018A8F
		Friend Overridable Property Label4 As Label

		' Token: 0x17001001 RID: 4097
		' (get) Token: 0x060028A7 RID: 10407 RVA: 0x0001A898 File Offset: 0x00018A98
		' (set) Token: 0x060028A8 RID: 10408 RVA: 0x0001A8A2 File Offset: 0x00018AA2
		Friend Overridable Property Label5 As Label

		' Token: 0x17001002 RID: 4098
		' (get) Token: 0x060028A9 RID: 10409 RVA: 0x0001A8AB File Offset: 0x00018AAB
		' (set) Token: 0x060028AA RID: 10410 RVA: 0x0001A8B5 File Offset: 0x00018AB5
		Friend Overridable Property Label6 As Label

		' Token: 0x17001003 RID: 4099
		' (get) Token: 0x060028AB RID: 10411 RVA: 0x0001A8BE File Offset: 0x00018ABE
		' (set) Token: 0x060028AC RID: 10412 RVA: 0x0019985C File Offset: 0x00197A5C
		Private _btnCompose_Exit As Button
		Friend Overridable Property btnCompose_Exit As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCompose_Exit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCompose_Exit_Click
				Dim button As Button = Me._btnCompose_Exit
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCompose_Exit = value
				button = Me._btnCompose_Exit
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001004 RID: 4100
		' (get) Token: 0x060028AD RID: 10413 RVA: 0x0001A8C8 File Offset: 0x00018AC8
		' (set) Token: 0x060028AE RID: 10414 RVA: 0x0001A8D2 File Offset: 0x00018AD2
		Friend Overridable Property txtCC As TextBox

		' Token: 0x17001005 RID: 4101
		' (get) Token: 0x060028AF RID: 10415 RVA: 0x0001A8DB File Offset: 0x00018ADB
		' (set) Token: 0x060028B0 RID: 10416 RVA: 0x0001A8E5 File Offset: 0x00018AE5
		Friend Overridable Property Label8 As Label

		' Token: 0x17001006 RID: 4102
		' (get) Token: 0x060028B1 RID: 10417 RVA: 0x0001A8EE File Offset: 0x00018AEE
		' (set) Token: 0x060028B2 RID: 10418 RVA: 0x0001A8F8 File Offset: 0x00018AF8
		Friend Overridable Property txtBCC As TextBox

		' Token: 0x17001007 RID: 4103
		' (get) Token: 0x060028B3 RID: 10419 RVA: 0x0001A901 File Offset: 0x00018B01
		' (set) Token: 0x060028B4 RID: 10420 RVA: 0x0001A90B File Offset: 0x00018B0B
		Friend Overridable Property Label7 As Label

		' Token: 0x17001008 RID: 4104
		' (get) Token: 0x060028B5 RID: 10421 RVA: 0x0001A914 File Offset: 0x00018B14
		' (set) Token: 0x060028B6 RID: 10422 RVA: 0x001998A0 File Offset: 0x00197AA0
		Private _btnAttach As Button
		Friend Overridable Property btnAttach As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAttach
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAttach_Click
				Dim button As Button = Me._btnAttach
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAttach = value
				button = Me._btnAttach
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001009 RID: 4105
		' (get) Token: 0x060028B7 RID: 10423 RVA: 0x0001A91E File Offset: 0x00018B1E
		' (set) Token: 0x060028B8 RID: 10424 RVA: 0x0001A928 File Offset: 0x00018B28
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x1700100A RID: 4106
		' (get) Token: 0x060028B9 RID: 10425 RVA: 0x0001A931 File Offset: 0x00018B31
		' (set) Token: 0x060028BA RID: 10426 RVA: 0x001998E4 File Offset: 0x00197AE4
		Private _btnLoadSent As Button
		Friend Overridable Property btnLoadSent As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLoadSent
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLoadSent_Click
				Dim button As Button = Me._btnLoadSent
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLoadSent = value
				button = Me._btnLoadSent
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700100B RID: 4107
		' (get) Token: 0x060028BB RID: 10427 RVA: 0x0001A93B File Offset: 0x00018B3B
		' (set) Token: 0x060028BC RID: 10428 RVA: 0x0001A945 File Offset: 0x00018B45
		Friend Overridable Property pnlSentMail As Panel

		' Token: 0x1700100C RID: 4108
		' (get) Token: 0x060028BD RID: 10429 RVA: 0x0001A94E File Offset: 0x00018B4E
		' (set) Token: 0x060028BE RID: 10430 RVA: 0x00199928 File Offset: 0x00197B28
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700100D RID: 4109
		' (get) Token: 0x060028BF RID: 10431 RVA: 0x0001A958 File Offset: 0x00018B58
		' (set) Token: 0x060028C0 RID: 10432 RVA: 0x0019996C File Offset: 0x00197B6C
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

		' Token: 0x1700100E RID: 4110
		' (get) Token: 0x060028C1 RID: 10433 RVA: 0x0001A962 File Offset: 0x00018B62
		' (set) Token: 0x060028C2 RID: 10434 RVA: 0x0001A96C File Offset: 0x00018B6C
		Friend Overridable Property Label9 As Label

		' Token: 0x1700100F RID: 4111
		' (get) Token: 0x060028C3 RID: 10435 RVA: 0x0001A975 File Offset: 0x00018B75
		' (set) Token: 0x060028C4 RID: 10436 RVA: 0x0001A97F File Offset: 0x00018B7F
		Friend Overridable Property flpAttachments As FlowLayoutPanel

		' Token: 0x17001010 RID: 4112
		' (get) Token: 0x060028C5 RID: 10437 RVA: 0x0001A988 File Offset: 0x00018B88
		' (set) Token: 0x060028C6 RID: 10438 RVA: 0x0001A992 File Offset: 0x00018B92
		Friend Overridable Property TabControl2 As TabControl

		' Token: 0x17001011 RID: 4113
		' (get) Token: 0x060028C7 RID: 10439 RVA: 0x0001A99B File Offset: 0x00018B9B
		' (set) Token: 0x060028C8 RID: 10440 RVA: 0x0001A9A5 File Offset: 0x00018BA5
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17001012 RID: 4114
		' (get) Token: 0x060028C9 RID: 10441 RVA: 0x0001A9AE File Offset: 0x00018BAE
		' (set) Token: 0x060028CA RID: 10442 RVA: 0x0001A9B8 File Offset: 0x00018BB8
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17001013 RID: 4115
		' (get) Token: 0x060028CB RID: 10443 RVA: 0x0001A9C1 File Offset: 0x00018BC1
		' (set) Token: 0x060028CC RID: 10444 RVA: 0x0001A9CB File Offset: 0x00018BCB
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x17001014 RID: 4116
		' (get) Token: 0x060028CD RID: 10445 RVA: 0x0001A9D4 File Offset: 0x00018BD4
		' (set) Token: 0x060028CE RID: 10446 RVA: 0x0001A9DE File Offset: 0x00018BDE
		Friend Overridable Property TabPage4 As TabPage

		' Token: 0x17001015 RID: 4117
		' (get) Token: 0x060028CF RID: 10447 RVA: 0x0001A9E7 File Offset: 0x00018BE7
		' (set) Token: 0x060028D0 RID: 10448 RVA: 0x0001A9F1 File Offset: 0x00018BF1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001016 RID: 4118
		' (get) Token: 0x060028D1 RID: 10449 RVA: 0x0001A9FA File Offset: 0x00018BFA
		' (set) Token: 0x060028D2 RID: 10450 RVA: 0x001999B0 File Offset: 0x00197BB0
		Private _btnPrevious As Button
		Friend Overridable Property btnPrevious As Button
			<CompilerGenerated()>
			Get
				Return Me._btnPrevious
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrevious_Click
				Dim button As Button = Me._btnPrevious
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnPrevious = value
				button = Me._btnPrevious
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001017 RID: 4119
		' (get) Token: 0x060028D3 RID: 10451 RVA: 0x0001AA04 File Offset: 0x00018C04
		' (set) Token: 0x060028D4 RID: 10452 RVA: 0x001999F4 File Offset: 0x00197BF4
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNext_Click
				Dim button As Button = Me._btnNext
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNext = value
				button = Me._btnNext
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001018 RID: 4120
		' (get) Token: 0x060028D5 RID: 10453 RVA: 0x0001AA0E File Offset: 0x00018C0E
		' (set) Token: 0x060028D6 RID: 10454 RVA: 0x0001AA18 File Offset: 0x00018C18
		Friend Overridable Property lblPage As Label

		' Token: 0x17001019 RID: 4121
		' (get) Token: 0x060028D7 RID: 10455 RVA: 0x0001AA21 File Offset: 0x00018C21
		' (set) Token: 0x060028D8 RID: 10456 RVA: 0x0001AA2B File Offset: 0x00018C2B
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x1700101A RID: 4122
		' (get) Token: 0x060028D9 RID: 10457 RVA: 0x0001AA34 File Offset: 0x00018C34
		' (set) Token: 0x060028DA RID: 10458 RVA: 0x00199A38 File Offset: 0x00197C38
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

		' Token: 0x1700101B RID: 4123
		' (get) Token: 0x060028DB RID: 10459 RVA: 0x0001AA3E File Offset: 0x00018C3E
		' (set) Token: 0x060028DC RID: 10460 RVA: 0x00199A7C File Offset: 0x00197C7C
		Private _btnRefreshSent As Button
		Friend Overridable Property btnRefreshSent As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRefreshSent
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._btnRefreshSent
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRefreshSent = value
				button = Me._btnRefreshSent
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700101C RID: 4124
		' (get) Token: 0x060028DD RID: 10461 RVA: 0x0001AA48 File Offset: 0x00018C48
		' (set) Token: 0x060028DE RID: 10462 RVA: 0x00199AC0 File Offset: 0x00197CC0
		Private _btnInbox As Button
		Friend Overridable Property btnInbox As Button
			<CompilerGenerated()>
			Get
				Return Me._btnInbox
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnInbox_Click
				Dim button As Button = Me._btnInbox
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnInbox = value
				button = Me._btnInbox
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700101D RID: 4125
		' (get) Token: 0x060028DF RID: 10463 RVA: 0x0001AA52 File Offset: 0x00018C52
		' (set) Token: 0x060028E0 RID: 10464 RVA: 0x0001AA5C File Offset: 0x00018C5C
		Friend Overridable Property txtTo_view As TextBox

		' Token: 0x1700101E RID: 4126
		' (get) Token: 0x060028E1 RID: 10465 RVA: 0x0001AA65 File Offset: 0x00018C65
		' (set) Token: 0x060028E2 RID: 10466 RVA: 0x0001AA6F File Offset: 0x00018C6F
		Friend Overridable Property Label10 As Label

		' Token: 0x1700101F RID: 4127
		' (get) Token: 0x060028E3 RID: 10467 RVA: 0x0001AA78 File Offset: 0x00018C78
		' (set) Token: 0x060028E4 RID: 10468 RVA: 0x0001AA82 File Offset: 0x00018C82
		Friend Overridable Property chkAi As CheckBox

		' Token: 0x17001020 RID: 4128
		' (get) Token: 0x060028E5 RID: 10469 RVA: 0x0001AA8B File Offset: 0x00018C8B
		' (set) Token: 0x060028E6 RID: 10470 RVA: 0x0001AA95 File Offset: 0x00018C95
		Friend Overridable Property txtBody As RichTextBox

		' Token: 0x17001021 RID: 4129
		' (get) Token: 0x060028E7 RID: 10471 RVA: 0x0001AA9E File Offset: 0x00018C9E
		' (set) Token: 0x060028E8 RID: 10472 RVA: 0x00199B04 File Offset: 0x00197D04
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click_1
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

		' Token: 0x060028E9 RID: 10473 RVA: 0x00199B48 File Offset: 0x00197D48
		Private Sub LoadLocalCache()
			Dim flag As Boolean = File.Exists("email_cache.json")
			If flag Then
				Dim text As String = File.ReadAllText("email_cache.json")
				Me.emailCache = JsonConvert.DeserializeObject(Of List(Of frmEmailDashboard.EmailModel))(text)
				If Me.emailCache IsNot Nothing AndAlso Me.emailCache.Count > 0 Then
					Me.lastFetchedUid = Me.emailCache.Max(Function(e As frmEmailDashboard.EmailModel) e.Uid)
				End If
			End If
		End Sub

		' Token: 0x060028EA RID: 10474 RVA: 0x00199BC8 File Offset: 0x00197DC8
		Private Sub FetchNewEmails()
			Try
				Dim imapClient As ImapClient = New ImapClient()
				imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
				imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
				Dim inbox As IMailFolder = imapClient.Inbox
				inbox.Open(FolderAccess.[ReadOnly], Nothing)
				Dim list As IList(Of UniqueId) = inbox.Search(SearchQuery.All, Nothing)
				Dim list2 As List(Of UniqueId) = list.Where(Function(uid As UniqueId) uid.Id > Me.lastFetchedUid).ToList()
				Try
					For Each uniqueId As UniqueId In list2
						Dim message As MimeMessage = inbox.GetMessage(uniqueId, Nothing, Nothing)
						Dim emailModel As frmEmailDashboard.EmailModel = New frmEmailDashboard.EmailModel() With { .Uid = uniqueId.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime }
						Me.emailCache.Add(emailModel)
						Me.lastFetchedUid = uniqueId.Id
					Next
				Finally
					Dim enumerator As List(Of UniqueId).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				imapClient.Disconnect(True, Nothing)
				Dim text As String = JsonConvert.SerializeObject(Me.emailCache, Formatting.Indented)
				File.WriteAllText("email_cache.json", text)
			Catch ex As Exception
				MessageBox.Show("Error fetching new emails: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060028EB RID: 10475 RVA: 0x00199DA0 File Offset: 0x00197FA0
		Private Sub BindGrid()
			Dim dataTable As DataTable = New DataTable()
			dataTable.Columns.Add("UID")
			dataTable.Columns.Add("From")
			dataTable.Columns.Add("Subject")
			dataTable.Columns.Add("Date")
			If Me.emailCache IsNot Nothing Then
				For Each emailModel As frmEmailDashboard.EmailModel In Me.emailCache.OrderByDescending(Function(e As frmEmailDashboard.EmailModel) e.Uid)
					dataTable.Rows.Add(New Object() { emailModel.Uid.ToString(), emailModel.From, emailModel.Subject, emailModel.DateReceived.ToString() })
				Next
			End If
			Me.DataGridView1.DataSource = dataTable
		End Sub

		' Token: 0x060028EC RID: 10476 RVA: 0x00199EB4 File Offset: 0x001980B4
		Public Function Decrypt(encryptpwd As String) As String
			Dim empty As String = String.Empty
			Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
			Dim decoder As Decoder = utf8Encoding.GetDecoder()
			Dim array As Byte() = Convert.FromBase64String(encryptpwd)
			Dim charCount As Integer = decoder.GetCharCount(array, 0, array.Length)
			Dim array2 As Char() = New Char(charCount - 1 + 1 - 1) {}
			decoder.GetChars(array, 0, array.Length, array2, 0)
			Return New String(array2)
		End Function

		' Token: 0x060028ED RID: 10477 RVA: 0x00199F18 File Offset: 0x00198118
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(ServerName), RTRIM(SMTPAddress), RTRIM(Username), RTRIM(Password), Port, RTRIM(TLS_SSL_Required), RTRIM(IsDefault), RTRIM(IsActive),  RTRIM(inbox_json_file),  RTRIM(sentbox_json_file) from EmailSetting_login where RTRIM(IsDefault)='Yes' ", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.strHost = ModCommonClasses.rdr(2).ToString()
					Me.intPort = Conversions.ToInteger(ModCommonClasses.rdr(5).ToString())
					Me.strName = "raintech"
					Me.strEmailid = ModCommonClasses.rdr(3).ToString()
					Me.strPassword = Me.Decrypt(ModCommonClasses.rdr(4).ToString())
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060028EE RID: 10478 RVA: 0x0001AAA8 File Offset: 0x00018CA8
		Private Sub frmEmailDashboard_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.LoadLocalCache()
			Me.BindGrid()
			Me.LoadSentEmailCache()
			Me.GetApiDtl()
			Me.chkAi.Checked = False
		End Sub

		' Token: 0x060028EF RID: 10479 RVA: 0x0019A028 File Offset: 0x00198228
		Private Sub LoadSentEmailCache()
			Dim flag As Boolean = File.Exists(Me.sentCacheFilePath)
			If flag Then
				Dim text As String = File.ReadAllText(Me.sentCacheFilePath)
				Me.sentEmailCache = JsonConvert.DeserializeObject(Of List(Of frmEmailDashboard.EmailModelSent))(text)
				If Me.sentEmailCache IsNot Nothing AndAlso Me.sentEmailCache.Count > 0 Then
					Me.lastSentUid = Me.sentEmailCache.Max(Function(e As frmEmailDashboard.EmailModelSent) e.Uid)
				End If
			End If
			Me.BindSentEmails(Me.sentEmailCache)
		End Sub

		' Token: 0x060028F0 RID: 10480 RVA: 0x0019A0C0 File Offset: 0x001982C0
		Private Sub AddEmailToGrid(inbox As IMailFolder, uid As UniqueId)
			Try
				Dim messageSummary As IMessageSummary = inbox.Fetch(New List(Of UniqueId)() From { uid }, MessageSummaryItems.Envelope Or MessageSummaryItems.UniqueId).FirstOrDefault()
				Dim flag As Boolean = messageSummary IsNot Nothing
				If flag Then
					Dim dataTable As DataTable = CType(Me.DataGridView1.DataSource, DataTable)
					dataTable.Rows.InsertAt(dataTable.NewRow(), 0)
					dataTable.Rows(0)("UID") = messageSummary.UniqueId.Id
					dataTable.Rows(0)("From") = messageSummary.Envelope.From.ToString()
					dataTable.Rows(0)("Subject") = messageSummary.Envelope.Subject
					Dim dataRow As DataRow = dataTable.Rows(0)
					Dim text As String = "Date"
					Dim [date] As DateTimeOffset? = messageSummary.Envelope.[Date]
					dataRow(text) = If(([date] IsNot Nothing), [date].GetValueOrDefault().DateTime.ToString("g"), Nothing)
				End If
			Catch ex As Exception
				MessageBox.Show("AddEmailToGrid error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060028F1 RID: 10481 RVA: 0x0019A230 File Offset: 0x00198430
		Private Sub LoadEmails()
			Try
				Dim imapClient As ImapClient = New ImapClient()
				imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
				imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
				Dim inbox As IMailFolder = imapClient.Inbox
				inbox.Open(FolderAccess.[ReadOnly], Nothing)
				Dim list As IList(Of UniqueId) = inbox.Search(SearchQuery.All, Nothing)
				Dim flag As Boolean = list Is Nothing OrElse list.Count = 0
				If flag Then
					imapClient.Disconnect(True, Nothing)
				Else
					Dim flag2 As Boolean = CULng(Me.lastFetchedUid) = 0UL
					If flag2 Then
						' The following expression was wrapped in a checked-expression
						Dim list2 As List(Of UniqueId) = If((list.Count > 20), list.Skip(list.Count - 20).ToList(), list.ToList())
						Try
							For Each uniqueId As UniqueId In list2
								Me.AddEmailToGrid(inbox, uniqueId)
								Me.lastFetchedUid = Math.Max(Me.lastFetchedUid, uniqueId.Id)
							Next
						Finally
							Dim enumerator As List(Of UniqueId).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
					Else
						Dim list3 As List(Of UniqueId) = list.Where(Function(uid As UniqueId) uid.Id > Me.lastFetchedUid).ToList()
						Try
							For Each uniqueId2 As UniqueId In list3
								Me.AddEmailToGrid(inbox, uniqueId2)
								Me.lastFetchedUid = Math.Max(Me.lastFetchedUid, uniqueId2.Id)
							Next
						Finally
							Dim enumerator2 As List(Of UniqueId).Enumerator
							CType(enumerator2, IDisposable).Dispose()
						End Try
					End If
					imapClient.Disconnect(True, Nothing)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060028F2 RID: 10482 RVA: 0x0019A464 File Offset: 0x00198664
		Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.RowIndex >= 0
			If flag Then
				Try
					Dim text As String = Me.DataGridView1.Rows(e.RowIndex).Cells("UID").Value.ToString()
					Dim uniqueId As UniqueId = New UniqueId(Convert.ToUInt32(text))
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim inbox As IMailFolder = imapClient.Inbox
						inbox.Open(FolderAccess.[ReadOnly], Nothing)
						Dim message As MimeMessage = inbox.GetMessage(uniqueId, Nothing, Nothing)
						Me.txtFrom.Text = message.From.ToString()
						Me.txtTo_view.Text = message.[To].ToString()
						Me.txtSubject.Text = message.Subject
						Me.rtbBody.Text = message.TextBody
						Me.flpAttachments.Controls.Clear()
						Try
							For Each mimeEntity As MimeEntity In message.Attachments
								Dim flag2 As Boolean = TypeOf mimeEntity Is MimePart
								If flag2 Then
									Dim mimePart As MimePart = CType(mimeEntity, MimePart)
									Dim button As Button = New Button()
									button.Text = mimePart.FileName
									button.AutoSize = True
									button.Tag = mimePart
									AddHandler button.Click, AddressOf Me.AttachmentButton_Click
									Me.flpAttachments.Controls.Add(button)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator(Of MimeEntity)
							If enumerator IsNot Nothing Then
								enumerator.Dispose()
							End If
						End Try
						imapClient.Disconnect(True, Nothing)
					End Using
					Me.TabControl2.SelectedIndex = 3
					Me.strmail_type = "inbox"
				Catch ex As Exception
					MessageBox.Show("Failed to load message: " + ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x060028F3 RID: 10483 RVA: 0x0019A6F0 File Offset: 0x001988F0
		Private Sub AttachmentButton_Click(sender As Object, e As EventArgs)
			Dim button As Button = CType(sender, Button)
			Dim mimePart As MimePart = CType(button.Tag, MimePart)
			Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
				saveFileDialog.FileName = mimePart.FileName
				saveFileDialog.Filter = "All Files|*.*"
				Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					Using fileStream As FileStream = File.Create(saveFileDialog.FileName)
						mimePart.Content.DecodeTo(fileStream, Nothing)
					End Using
					MessageBox.Show("Attachment saved successfully!")
				End If
			End Using
		End Sub

		' Token: 0x060028F4 RID: 10484 RVA: 0x0019A7AC File Offset: 0x001989AC
		Private Sub lstAttachments_DoubleClick(sender As Object, e As EventArgs)
			Dim selectedItem As Object = Me.lstAttachments.SelectedItem
			Dim text As String = If((selectedItem IsNot Nothing), selectedItem.ToString(), Nothing)
			Dim flag As Boolean = String.IsNullOrEmpty(text)
			If Not flag Then
				Try
					Dim text2 As String = Me.DataGridView1.CurrentRow.Cells("UID").Value.ToString()
					Dim uniqueId As UniqueId = New UniqueId(Convert.ToUInt32(text2))
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim inbox As IMailFolder = imapClient.Inbox
						inbox.Open(FolderAccess.[ReadOnly], Nothing)
						Dim message As MimeMessage = inbox.GetMessage(uniqueId, Nothing, Nothing)
						Try
							For Each mimeEntity As MimeEntity In message.Attachments
								Dim flag2 As Boolean = TypeOf mimeEntity Is MimePart
								If flag2 Then
									Dim mimePart As MimePart = CType(mimeEntity, MimePart)
									Dim flag3 As Boolean = Operators.CompareString(mimePart.FileName, text, False) = 0
									If flag3 Then
										Dim text3 As String = Path.Combine(Path.GetTempPath(), mimePart.FileName)
										Using fileStream As FileStream = File.Create(text3)
											mimePart.Content.DecodeTo(fileStream, Nothing)
										End Using
										Process.Start(New ProcessStartInfo() With { .FileName = text3, .UseShellExecute = True })
										Exit For
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator(Of MimeEntity)
							If enumerator IsNot Nothing Then
								enumerator.Dispose()
							End If
						End Try
						imapClient.Disconnect(True, Nothing)
					End Using
				Catch ex As Exception
					MessageBox.Show("Error opening attachment: " + ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x060028F5 RID: 10485 RVA: 0x0019AA14 File Offset: 0x00198C14
		Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.fetchPageIndex = 0
				Me.emailCache.Clear()
				Me.lastFetchedUids.Clear()
				Me.FetchPagedEmails()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060028F6 RID: 10486 RVA: 0x0001AADB File Offset: 0x00018CDB
		Private Sub btnCompose_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.TabControl2.SelectedIndex = 2
			Me.txtTo.Focus()
		End Sub

		' Token: 0x060028F7 RID: 10487 RVA: 0x0001AAFE File Offset: 0x00018CFE
		Private Sub btnCompose_Exit_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060028F8 RID: 10488 RVA: 0x0019AA6C File Offset: 0x00198C6C
		Private Sub btnReply_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.strmail_type, "inbox", False) = 0
			If flag Then
				Me.txtTo.Text = Me.txtFrom.Text
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.strmail_type, "sentbox", False) = 0
				If flag2 Then
					Me.txtTo.Text = Me.txtTo_view.Text
				End If
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.txtTo.Text, "", False) = 0
			If flag3 Then
				Me.TabControl2.SelectedIndex = 0
			Else
				Me.txtSubject_compose.Focus()
				Me.TabControl2.SelectedIndex = 2
			End If
		End Sub

		' Token: 0x060028F9 RID: 10489 RVA: 0x0019AB24 File Offset: 0x00198D24
		Private Sub btnSend_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.SendMail()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060028FA RID: 10490 RVA: 0x0019AB5C File Offset: 0x00198D5C
		Public Sub SendMail()
			Try
				Dim mimeMessage As MimeMessage = New MimeMessage()
				mimeMessage.From.Add(New MailboxAddress(Me.strName, Me.strEmailid))
				mimeMessage.[To].AddRange(InternetAddressList.Parse(Me.txtTo.Text))
				Dim flag As Boolean = Not String.IsNullOrWhiteSpace(Me.txtCC.Text)
				If flag Then
					mimeMessage.Cc.AddRange(InternetAddressList.Parse(Me.txtCC.Text))
				End If
				Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(Me.txtBCC.Text)
				If flag2 Then
					mimeMessage.Bcc.AddRange(InternetAddressList.Parse(Me.txtBCC.Text))
				End If
				mimeMessage.Subject = Me.txtSubject_compose.Text
				Dim bodyBuilder As BodyBuilder = New BodyBuilder()
				bodyBuilder.TextBody = Me.txtBody.Text
				Dim flag3 As Boolean = Not String.IsNullOrEmpty(Me.attachmentPath) AndAlso File.Exists(Me.attachmentPath)
				If flag3 Then
					bodyBuilder.Attachments.Add(Me.attachmentPath)
				End If
				mimeMessage.Body = bodyBuilder.ToMessageBody()
				Using smtpClient As SmtpClient = New SmtpClient()
					smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls, Nothing)
					smtpClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
					smtpClient.Send(mimeMessage)
					smtpClient.Disconnect(True, Nothing)
				End Using
				MessageBox.Show("Mail sent successfully!")
				Me.Reset()
				Me.TabControl2.SelectedIndex = 0
			Catch ex As Exception
				MessageBox.Show("Failed to send mail: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060028FB RID: 10491 RVA: 0x0001AB08 File Offset: 0x00018D08
		Public Sub Reset()
			Me.txtTo.Text = ""
			Me.txtSubject_compose.Text = ""
			Me.txtBody.Text = ""
		End Sub

		' Token: 0x060028FC RID: 10492 RVA: 0x0019AD84 File Offset: 0x00198F84
		Private Sub btnAttach_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.attachmentPath = openFileDialog.FileName
				MessageBox.Show("Attached: " + Me.attachmentPath)
			End If
		End Sub

		' Token: 0x060028FD RID: 10493 RVA: 0x0001AB3E File Offset: 0x00018D3E
		Private Sub btnLoadSent_Click(sender As Object, e As EventArgs)
			Me.TabControl2.SelectedIndex = 1
		End Sub

		' Token: 0x060028FE RID: 10494 RVA: 0x0019ADCC File Offset: 0x00198FCC
		Private Sub LoadSentCache()
			Dim flag As Boolean = File.Exists(Me.sentCacheFilePath)
			If flag Then
				Dim text As String = File.ReadAllText(Me.sentCacheFilePath)
				Me.sentEmailCache = JsonConvert.DeserializeObject(Of List(Of frmEmailDashboard.EmailModelSent))(text)
				Try
					For Each emailModelSent As frmEmailDashboard.EmailModelSent In Me.sentEmailCache
						Me.sentLastFetchedUids.Add(emailModelSent.Uid)
					Next
				Finally
					Dim enumerator As List(Of frmEmailDashboard.EmailModelSent).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
			End If
		End Sub

		' Token: 0x060028FF RID: 10495 RVA: 0x0019AE5C File Offset: 0x0019905C
		Private Async Sub RefreshSentEmails()
			Me.ProgressBar1.Visible = True
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Await Task.Run(Sub()
				Try
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(SpecialFolder.Sent)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim enumerable As IEnumerable(Of UniqueId) = folder.Search(SearchQuery.All, Nothing)
						Dim list As List(Of UniqueId) = enumerable.OrderByDescending(Function(uid As UniqueId) uid.Id).ToList()
						Dim list2 As List(Of UniqueId) = list.Where(Function(uid As UniqueId) uid.Id > Me.lastSentUid).Take(50).ToList()
						Dim newlyFetched As List(Of frmEmailDashboard.EmailModelSent) = New List(Of frmEmailDashboard.EmailModelSent)()
						For Each uniqueId As UniqueId In list2
							Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
							Dim emailModelSent As frmEmailDashboard.EmailModelSent = New frmEmailDashboard.EmailModelSent() With { .Uid = uniqueId.Id, .[To] = message.[To].ToString(), .Subject = message.Subject, .DateReceived = message.[Date].LocalDateTime }
							newlyFetched.Add(emailModelSent)
							Me.lastSentUid = Math.Max(Me.lastSentUid, uniqueId.Id)
						Next
						imapClient.Disconnect(True, Nothing)
						MyBase.Invoke(Sub()
							Me.sentEmailCache.AddRange(newlyFetched)
							Me.BindSentEmails(Me.sentEmailCache)
							Dim text As String = JsonConvert.SerializeObject(Me.sentEmailCache, Formatting.Indented)
							File.WriteAllText(Me.sentCacheFilePath, text)
						End Sub)
					End Using
				Catch ex As Exception
					Dim errMsg As String = ex.Message
					MyBase.Invoke(Sub()
						MessageBox.Show("Error refreshing sent emails: " + errMsg)
					End Sub)
				End Try
			End Sub)
			Me.ProgressBar1.Visible = False
		End Sub
		Private Async Sub LoadMoreSentEmails()
			Me.ProgressBar1.Visible = True
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Await Task.Run(Sub()
				Try
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(SpecialFolder.Sent)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim list As List(Of UniqueId) = folder.Search(SearchQuery.All, Nothing).Reverse().ToList()
						Dim num As Integer = Me.sentFetchPageIndex * Me.sentPageSize
						If num >= list.Count Then
							MyBase.Invoke(Sub()
								MessageBox.Show("No more sent emails.")
							End Sub)
						Else
							Dim list2 As List(Of UniqueId) = list.Skip(num).Take(Me.sentPageSize).ToList()
							For Each uid As UniqueId In list2
								If Not Me.sentLastFetchedUids.Contains(uid.Id) Then
									Dim message As MimeMessage = folder.GetMessage(uid, Nothing, Nothing)
									Dim emailModel As frmEmailDashboard.EmailModelSent = New frmEmailDashboard.EmailModelSent() With { .Uid = uid.Id, .Subject = message.Subject, .[To] = message.[To].ToString(), .DateReceived = message.[Date].LocalDateTime }
									MyBase.Invoke(Sub()
										Me.sentEmailCache.Add(emailModel)
										Me.sentLastFetchedUids.Add(uid.Id)
									End Sub)
								End If
							Next
							imapClient.Disconnect(True, Nothing)
							Dim text As String = JsonConvert.SerializeObject(Me.sentEmailCache, Formatting.Indented)
							File.WriteAllText(Me.sentCacheFilePath, text)
							MyBase.Invoke(Sub()
								Me.BindSentGrid()
							End Sub)
						End If
					End Using
				Catch ex As Exception
					Dim errMsg As String = ex.Message
					MyBase.Invoke(Sub()
						MessageBox.Show("Error fetching sent emails: " + errMsg)
					End Sub)
				End Try
			End Sub)
			Me.ProgressBar1.Visible = False
		End Sub
		Private Sub BindSentGrid()
			Dim dataTable As DataTable = New DataTable()
			dataTable.Columns.Add("UID")
			dataTable.Columns.Add("To")
			dataTable.Columns.Add("Subject")
			dataTable.Columns.Add("Date")
			If Me.sentEmailCache IsNot Nothing Then
				For Each emailModelSent As frmEmailDashboard.EmailModelSent In Me.sentEmailCache.OrderByDescending(Function(e As frmEmailDashboard.EmailModelSent) e.Uid)
					dataTable.Rows.Add(New Object() { emailModelSent.Uid.ToString(), emailModelSent.[To], emailModelSent.Subject, emailModelSent.DateReceived.ToString() })
				Next
			End If
			Me.DataGridView2.DataSource = dataTable
		End Sub

		' Token: 0x06002902 RID: 10498 RVA: 0x0001AB4E File Offset: 0x00018D4E
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.pnlSentMail.Visible = False
		End Sub

		' Token: 0x06002903 RID: 10499 RVA: 0x0019AFE8 File Offset: 0x001991E8
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.fetchPageIndex = Me.fetchPageIndex + 1
				Me.FetchPagedEmails()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002904 RID: 10500 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnPrevious_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06002905 RID: 10501 RVA: 0x0019B02C File Offset: 0x0019922C
		Private Async Sub FetchPagedEmails()
			Me.ProgressBar1.Visible = True
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Await Task.Run(Sub()
				Try
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim inbox As IMailFolder = imapClient.Inbox
						inbox.Open(FolderAccess.[ReadOnly], Nothing)
						Dim list As List(Of UniqueId) = inbox.Search(SearchQuery.All, Nothing).Reverse().ToList()
						Dim num As Integer = Me.fetchPageIndex * Me.pageSize
						If num >= list.Count Then
							MyBase.Invoke(Sub()
								MessageBox.Show("No more emails.")
							End Sub)
						Else
							Dim list2 As List(Of UniqueId) = list.Skip(num).Take(Me.pageSize).ToList()
							For Each uid As UniqueId In list2
								If Not Me.lastFetchedUids.Contains(uid.Id) Then
									Dim message As MimeMessage = inbox.GetMessage(uid, Nothing, Nothing)
									Dim emailModel As frmEmailDashboard.EmailModel = New frmEmailDashboard.EmailModel() With { .Uid = uid.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime }
									MyBase.Invoke(Sub()
										Me.emailCache.Add(emailModel)
										Me.lastFetchedUids.Add(uid.Id)
									End Sub)
								End If
							Next
							imapClient.Disconnect(True, Nothing)
							Dim text As String = JsonConvert.SerializeObject(Me.emailCache, Formatting.Indented)
							File.WriteAllText("email_cache.json", text)
							MyBase.Invoke(Sub()
								Me.BindGrid()
							End Sub)
						End If
					End Using
				Catch ex As Exception
					Dim errMsg As String = ex.Message
					MyBase.Invoke(Sub()
						MessageBox.Show("Error fetching emails: " + errMsg)
					End Sub)
				End Try
			End Sub)
			Me.ProgressBar1.Visible = False
		End Sub
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.sentFetchPageIndex = Me.sentFetchPageIndex + 1
				Me.LoadMoreSentEmails()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002907 RID: 10503 RVA: 0x0019B0AC File Offset: 0x001992AC
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.RefreshSentEmails()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002908 RID: 10504 RVA: 0x0019B0E4 File Offset: 0x001992E4
		Private Sub BindSentEmails(emails As List(Of frmEmailDashboard.EmailModelSent))
			Dim dataTable As DataTable = New DataTable()
			dataTable.Columns.Add("UID")
			dataTable.Columns.Add("To")
			dataTable.Columns.Add("Subject")
			dataTable.Columns.Add("Date")
			If emails IsNot Nothing Then
				For Each emailModelSent As frmEmailDashboard.EmailModelSent In emails.OrderByDescending(Function(e As frmEmailDashboard.EmailModelSent) e.Uid)
					dataTable.Rows.Add(New Object() { emailModelSent.Uid.ToString(), emailModelSent.[To], emailModelSent.Subject, emailModelSent.DateReceived.ToString() })
				Next
			End If
			Me.DataGridView2.DataSource = dataTable
		End Sub

		' Token: 0x06002909 RID: 10505 RVA: 0x0001AB5E File Offset: 0x00018D5E
		Private Sub btnInbox_Click(sender As Object, e As EventArgs)
			Me.TabControl2.SelectedIndex = 0
		End Sub

		' Token: 0x0600290A RID: 10506 RVA: 0x0019B1F4 File Offset: 0x001993F4
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.RowIndex >= 0
			If flag Then
				Try
					Dim text As String = Me.DataGridView2.Rows(e.RowIndex).Cells("UID").Value.ToString()
					Dim uniqueId As UniqueId = New UniqueId(Convert.ToUInt32(text))
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(SpecialFolder.Sent)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
						Me.txtFrom.Text = message.From.ToString()
						Me.txtSubject.Text = message.Subject
						Me.txtTo_view.Text = message.[To].ToString()
						Me.rtbBody.Text = message.TextBody
						Me.flpAttachments.Controls.Clear()
						Try
							For Each mimeEntity As MimeEntity In message.Attachments
								Dim flag2 As Boolean = TypeOf mimeEntity Is MimePart
								If flag2 Then
									Dim mimePart As MimePart = CType(mimeEntity, MimePart)
									Dim button As Button = New Button()
									button.Text = mimePart.FileName
									button.AutoSize = True
									button.Tag = mimePart
									AddHandler button.Click, AddressOf Me.AttachmentButton_Click
									Me.flpAttachments.Controls.Add(button)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator(Of MimeEntity)
							If enumerator IsNot Nothing Then
								enumerator.Dispose()
							End If
						End Try
						imapClient.Disconnect(True, Nothing)
					End Using
					Me.TabControl2.SelectedIndex = 3
					Me.strmail_type = "sentbox"
				Catch ex As Exception
					MessageBox.Show("Failed to load message: " + ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x0600290B RID: 10507 RVA: 0x0019B480 File Offset: 0x00199680
		Private Async Sub txtSubject_compose_Leave(sender As Object, e As EventArgs)
			Dim subject As String = Me.txtSubject_compose.Text.Trim()
			Dim flag As Boolean = String.IsNullOrWhiteSpace(subject)
			If flag Then
				MessageBox.Show("Please enter a subject.", "Missing Subject", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim checked As Boolean = Me.chkAi.Checked
				If checked Then
					Me.txtBody.Clear()
					Try
						Dim finalPrompt As String = "Write a formal email based on the subject given below. " & vbCrLf & "If the subject mentions a language, then write the entire email in that language. " & vbCrLf & "If no language is mentioned, then detect the language of the subject and write the email in that same language. " & vbCrLf & "Subject: " + subject
						Dim result As String = Await Me.GenerateLetter(finalPrompt)
						If Not String.IsNullOrWhiteSpace(result) Then
							result = result.Replace("\r\n", Environment.NewLine)
							result = result.Replace("\n\n", Environment.NewLine + Environment.NewLine)
							result = result.Replace("\n", Environment.NewLine)
							Me.txtBody.Text = result.Trim()
						Else
							Me.txtBody.Text = "No letter generated. Please try again."
						End If
					Catch ex As Exception
						MessageBox.Show("Error generating letter: " + ex.Message)
					Finally
					End Try
				Else
					Me.txtBody.Clear()
				End If
				Me.txtBody.Focus()
			End If
		End Sub

		' Token: 0x0600290C RID: 10508 RVA: 0x0019B4C8 File Offset: 0x001996C8
		Public Sub GetApiDtl()
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "select * from tbl_api_setting where isDefault='Yes' and isEnabled='Yes' "
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count > 0
			If flag Then
				Me.apiKey = dataTable.Rows(0)(2).ToString()
				Me.url = dataTable.Rows(0)(1).ToString()
			End If
			sqlConnection.Close()
		End Sub

		' Token: 0x0600290D RID: 10509 RVA: 0x0019B55C File Offset: 0x0019975C
		Private Async Function GenerateLetter(subject As String) As Task(Of String)
			Dim text As String
			Try
				Dim client As HttpClient = New HttpClient()
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
				Dim requestBody = New With{ Key .model = "gpt-3.5-turbo", Key .messages = New Object() { New With{ Key .role = "system", Key .content = "You are a helpful assistant that writes formal letters." }, New With{ Key .role = "user", Key .content = "Write a full formal letter for the following subject: " + subject } } }
				Dim jsonBody As String = JsonConvert.SerializeObject(requestBody)
				Dim content As StringContent = New StringContent(jsonBody, Encoding.UTF8, "application/json")
				Dim response As HttpResponseMessage = Await client.PostAsync(Me.url, content)
				Dim responseString As String = Await response.Content.ReadAsStringAsync()
				Dim responseJson As frmEmailDashboard.OpenAIResponse = JsonConvert.DeserializeObject(Of frmEmailDashboard.OpenAIResponse)(responseString)
				If responseJson IsNot Nothing AndAlso responseJson.choices.Length > 0 Then
					text = responseJson.choices(0).message.content.Trim()
				Else
					text = "Error: No response from AI."
				End If
			Catch ex As Exception
				MessageBox.Show("Error message: " + ex.Message)
			End Try
			Return text
		End Function

		' Token: 0x0600290E RID: 10510 RVA: 0x0001AB6E File Offset: 0x00018D6E
		Private Sub Button3_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmailSetting_login.ShowDialog()
			MyProject.Forms.frmEmailSetting_login.Dispose()
		End Sub

		' Token: 0x0400111E RID: 4382
		Private inboxMessages As List(Of MimeMessage)

		' Token: 0x0400111F RID: 4383
		Private attachmentPath As String

		' Token: 0x04001120 RID: 4384
		Private strHost As String

		' Token: 0x04001121 RID: 4385
		Private intPort As Integer

		' Token: 0x04001122 RID: 4386
		Private strName As String

		' Token: 0x04001123 RID: 4387
		Private strEmailid As String

		' Token: 0x04001124 RID: 4388
		Private strPassword As String

		' Token: 0x04001125 RID: 4389
		Private lastSentUid As UInteger

		' Token: 0x04001126 RID: 4390
		Private Const cacheFilePath As String = "email_cache.json"

		' Token: 0x04001127 RID: 4391
		Private emailCache As List(Of frmEmailDashboard.EmailModel)

		' Token: 0x04001128 RID: 4392
		Private lastFetchedUid As UInteger

		' Token: 0x04001129 RID: 4393
		Private sentEmailCache As List(Of frmEmailDashboard.EmailModelSent)

		' Token: 0x0400112A RID: 4394
		Private sentLastFetchedUids As HashSet(Of UInteger)

		' Token: 0x0400112B RID: 4395
		Private sentFetchPageIndex As Integer

		' Token: 0x0400112C RID: 4396
		Private sentPageSize As Integer

		' Token: 0x0400112D RID: 4397
		Private sentCacheFilePath As String

		' Token: 0x0400112E RID: 4398
		Private fetchPageIndex As Integer

		' Token: 0x0400112F RID: 4399
		Private pageSize As Integer

		' Token: 0x04001130 RID: 4400
		Private lastFetchedUids As HashSet(Of UInteger)

		' Token: 0x04001131 RID: 4401
		Private strmail_type As String

		' Token: 0x04001132 RID: 4402
		Private apiKey As String

		' Token: 0x04001133 RID: 4403
		Private url As String

		' Token: 0x020000E1 RID: 225
		Public Class EmailModel
			' Token: 0x17001022 RID: 4130
			' (get) Token: 0x06002918 RID: 10520 RVA: 0x0001ABA5 File Offset: 0x00018DA5
			' (set) Token: 0x06002919 RID: 10521 RVA: 0x0001ABAF File Offset: 0x00018DAF
			Public Property Uid As UInteger

			' Token: 0x17001023 RID: 4131
			' (get) Token: 0x0600291A RID: 10522 RVA: 0x0001ABB8 File Offset: 0x00018DB8
			' (set) Token: 0x0600291B RID: 10523 RVA: 0x0001ABC2 File Offset: 0x00018DC2
			Public Property Subject As String

			' Token: 0x17001024 RID: 4132
			' (get) Token: 0x0600291C RID: 10524 RVA: 0x0001ABCB File Offset: 0x00018DCB
			' (set) Token: 0x0600291D RID: 10525 RVA: 0x0001ABD5 File Offset: 0x00018DD5
			Public Property From As String

			' Token: 0x17001025 RID: 4133
			' (get) Token: 0x0600291E RID: 10526 RVA: 0x0001ABDE File Offset: 0x00018DDE
			' (set) Token: 0x0600291F RID: 10527 RVA: 0x0001ABE8 File Offset: 0x00018DE8
			Public Property DateReceived As DateTime
		End Class

		' Token: 0x020000E2 RID: 226
		Public Class EmailModelSent
			' Token: 0x17001026 RID: 4134
			' (get) Token: 0x06002921 RID: 10529 RVA: 0x0001ABF1 File Offset: 0x00018DF1
			' (set) Token: 0x06002922 RID: 10530 RVA: 0x0001ABFB File Offset: 0x00018DFB
			Public Property Uid As UInteger

			' Token: 0x17001027 RID: 4135
			' (get) Token: 0x06002923 RID: 10531 RVA: 0x0001AC04 File Offset: 0x00018E04
			' (set) Token: 0x06002924 RID: 10532 RVA: 0x0001AC0E File Offset: 0x00018E0E
			Public Property Subject As String

			' Token: 0x17001028 RID: 4136
			' (get) Token: 0x06002925 RID: 10533 RVA: 0x0001AC17 File Offset: 0x00018E17
			' (set) Token: 0x06002926 RID: 10534 RVA: 0x0001AC21 File Offset: 0x00018E21
			Public Property [To] As String

			' Token: 0x17001029 RID: 4137
			' (get) Token: 0x06002927 RID: 10535 RVA: 0x0001AC2A File Offset: 0x00018E2A
			' (set) Token: 0x06002928 RID: 10536 RVA: 0x0001AC34 File Offset: 0x00018E34
			Public Property From As String

			' Token: 0x1700102A RID: 4138
			' (get) Token: 0x06002929 RID: 10537 RVA: 0x0001AC3D File Offset: 0x00018E3D
			' (set) Token: 0x0600292A RID: 10538 RVA: 0x0001AC47 File Offset: 0x00018E47
			Public Property DateReceived As DateTime
		End Class

		' Token: 0x020000E3 RID: 227
		Public Class OpenAIResponse
			' Token: 0x1700102B RID: 4139
			' (get) Token: 0x0600292C RID: 10540 RVA: 0x0001AC50 File Offset: 0x00018E50
			' (set) Token: 0x0600292D RID: 10541 RVA: 0x0001AC5A File Offset: 0x00018E5A
			Public Property choices As frmEmailDashboard.Choice()
		End Class

		' Token: 0x020000E4 RID: 228
		Public Class Choice
			' Token: 0x1700102C RID: 4140
			' (get) Token: 0x0600292F RID: 10543 RVA: 0x0001AC63 File Offset: 0x00018E63
			' (set) Token: 0x06002930 RID: 10544 RVA: 0x0001AC6D File Offset: 0x00018E6D
			Public Property message As frmEmailDashboard.Message
		End Class

		' Token: 0x020000E5 RID: 229
		Public Class Message
			' Token: 0x1700102D RID: 4141
			' (get) Token: 0x06002932 RID: 10546 RVA: 0x0001AC76 File Offset: 0x00018E76
			' (set) Token: 0x06002933 RID: 10547 RVA: 0x0001AC80 File Offset: 0x00018E80
			Public Property content As String
		End Class
	End Class
End Namespace
