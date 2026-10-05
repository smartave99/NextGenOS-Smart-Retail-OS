Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports MailKit
Imports MailKit.Net.Imap
Imports MailKit.Net.Smtp
Imports MailKit.Search
Imports MailKit.Security
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MimeKit
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x020000F4 RID: 244
	<DesignerGenerated()>
	Public Partial Class frmEmailDashboard2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600295B RID: 10587 RVA: 0x0019C888 File Offset: 0x0019AA88
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEmailDashboard2_Load
			Me.attachmentPath = ""
			Me.strHost = ""
			Me.strName = ""
			Me.strEmailid = ""
			Me.strPassword = ""
			Me.lastSentUid = 0UI
			Me.emailCache = New List(Of frmEmailDashboard2.EmailModel)()
			Me.lastFetchedUid = 0UI
			Me.sentEmailCache = New List(Of frmEmailDashboard2.EmailModelSent)()
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
			Me.folderEmailCache = New Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel))()
			Me.folderLastFetchedUids = New Dictionary(Of String, HashSet(Of UniqueId))()
			Me.currentFolderFullName = "INBOX"
			Me.currentFolderCache = New List(Of frmEmailDashboard2.EmailModel)()
			Me.folderPageIndex = 0
			Me.currentFolderLastFetchedUids = New HashSet(Of UniqueId)()
			Me.currentFolderPage = 1
			Me.emailDisplayList = New List(Of frmEmailDashboard2.EmailModel)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700102E RID: 4142
		' (get) Token: 0x0600295E RID: 10590 RVA: 0x0001ADC3 File Offset: 0x00018FC3
		' (set) Token: 0x0600295F RID: 10591 RVA: 0x0019E160 File Offset: 0x0019C360
		Private _ListBoxNav As ListBox
		Friend Overridable Property ListBoxNav As ListBox
			<CompilerGenerated()>
			Get
				Return Me._ListBoxNav
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Dim eventHandler As EventHandler = AddressOf Me.ListBoxNav_SelectedIndexChanged
				Dim listBox As ListBox = Me._ListBoxNav
				If listBox IsNot Nothing Then
					RemoveHandler listBox.SelectedIndexChanged, eventHandler
				End If
				Me._ListBoxNav = value
				listBox = Me._ListBoxNav
				If listBox IsNot Nothing Then
					AddHandler listBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700102F RID: 4143
		' (get) Token: 0x06002960 RID: 10592 RVA: 0x0001ADCD File Offset: 0x00018FCD
		' (set) Token: 0x06002961 RID: 10593 RVA: 0x0019E1A4 File Offset: 0x0019C3A4
		Private _TreeViewNav As TreeView
		Friend Overridable Property TreeViewNav As TreeView
			<CompilerGenerated()>
			Get
				Return Me._TreeViewNav
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TreeView)
				Dim treeViewEventHandler As TreeViewEventHandler = AddressOf Me.TreeViewNav_AfterSelect
				Dim treeView As TreeView = Me._TreeViewNav
				If treeView IsNot Nothing Then
					RemoveHandler treeView.AfterSelect, treeViewEventHandler
				End If
				Me._TreeViewNav = value
				treeView = Me._TreeViewNav
				If treeView IsNot Nothing Then
					AddHandler treeView.AfterSelect, treeViewEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001030 RID: 4144
		' (get) Token: 0x06002962 RID: 10594 RVA: 0x0001ADD7 File Offset: 0x00018FD7
		' (set) Token: 0x06002963 RID: 10595 RVA: 0x0001ADE1 File Offset: 0x00018FE1
		Friend Overridable Property lblFrom As Label

		' Token: 0x17001031 RID: 4145
		' (get) Token: 0x06002964 RID: 10596 RVA: 0x0001ADEA File Offset: 0x00018FEA
		' (set) Token: 0x06002965 RID: 10597 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		Friend Overridable Property lblSubject As Label

		' Token: 0x17001032 RID: 4146
		' (get) Token: 0x06002966 RID: 10598 RVA: 0x0001ADFD File Offset: 0x00018FFD
		' (set) Token: 0x06002967 RID: 10599 RVA: 0x0001AE07 File Offset: 0x00019007
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001033 RID: 4147
		' (get) Token: 0x06002968 RID: 10600 RVA: 0x0001AE10 File Offset: 0x00019010
		' (set) Token: 0x06002969 RID: 10601 RVA: 0x0001AE1A File Offset: 0x0001901A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17001034 RID: 4148
		' (get) Token: 0x0600296A RID: 10602 RVA: 0x0001AE23 File Offset: 0x00019023
		' (set) Token: 0x0600296B RID: 10603 RVA: 0x0001AE2D File Offset: 0x0001902D
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001035 RID: 4149
		' (get) Token: 0x0600296C RID: 10604 RVA: 0x0001AE36 File Offset: 0x00019036
		' (set) Token: 0x0600296D RID: 10605 RVA: 0x0001AE40 File Offset: 0x00019040
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17001036 RID: 4150
		' (get) Token: 0x0600296E RID: 10606 RVA: 0x0001AE49 File Offset: 0x00019049
		' (set) Token: 0x0600296F RID: 10607 RVA: 0x0019E1E8 File Offset: 0x0019C3E8
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

		' Token: 0x17001037 RID: 4151
		' (get) Token: 0x06002970 RID: 10608 RVA: 0x0001AE53 File Offset: 0x00019053
		' (set) Token: 0x06002971 RID: 10609 RVA: 0x0001AE5D File Offset: 0x0001905D
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17001038 RID: 4152
		' (get) Token: 0x06002972 RID: 10610 RVA: 0x0001AE66 File Offset: 0x00019066
		' (set) Token: 0x06002973 RID: 10611 RVA: 0x0001AE70 File Offset: 0x00019070
		Friend Overridable Property WebBrowser1 As WebBrowser

		' Token: 0x17001039 RID: 4153
		' (get) Token: 0x06002974 RID: 10612 RVA: 0x0001AE79 File Offset: 0x00019079
		' (set) Token: 0x06002975 RID: 10613 RVA: 0x0001AE83 File Offset: 0x00019083
		Friend Overridable Property rtbBody As RichTextBox

		' Token: 0x1700103A RID: 4154
		' (get) Token: 0x06002976 RID: 10614 RVA: 0x0001AE8C File Offset: 0x0001908C
		' (set) Token: 0x06002977 RID: 10615 RVA: 0x0001AE96 File Offset: 0x00019096
		Friend Overridable Property FlowLayoutAttachments As FlowLayoutPanel

		' Token: 0x1700103B RID: 4155
		' (get) Token: 0x06002978 RID: 10616 RVA: 0x0001AE9F File Offset: 0x0001909F
		' (set) Token: 0x06002979 RID: 10617 RVA: 0x0019E22C File Offset: 0x0019C42C
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

		' Token: 0x1700103C RID: 4156
		' (get) Token: 0x0600297A RID: 10618 RVA: 0x0001AEA9 File Offset: 0x000190A9
		' (set) Token: 0x0600297B RID: 10619 RVA: 0x0019E270 File Offset: 0x0019C470
		Private _btnLoadMore As Button
		Friend Overridable Property btnLoadMore As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLoadMore
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLoadMore_Click
				Dim button As Button = Me._btnLoadMore
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLoadMore = value
				button = Me._btnLoadMore
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700103D RID: 4157
		' (get) Token: 0x0600297C RID: 10620 RVA: 0x0001AEB3 File Offset: 0x000190B3
		' (set) Token: 0x0600297D RID: 10621 RVA: 0x0019E2B4 File Offset: 0x0019C4B4
		Private _lnkReplyAll As LinkLabel
		Friend Overridable Property lnkReplyAll As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._lnkReplyAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.lnkReplyAll_LinkClicked
				Dim linkLabel As LinkLabel = Me._lnkReplyAll
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._lnkReplyAll = value
				linkLabel = Me._lnkReplyAll
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700103E RID: 4158
		' (get) Token: 0x0600297E RID: 10622 RVA: 0x0001AEBD File Offset: 0x000190BD
		' (set) Token: 0x0600297F RID: 10623 RVA: 0x0019E2F8 File Offset: 0x0019C4F8
		Private _lnkReply As LinkLabel
		Friend Overridable Property lnkReply As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._lnkReply
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.lnkReply_LinkClicked
				Dim linkLabel As LinkLabel = Me._lnkReply
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._lnkReply = value
				linkLabel = Me._lnkReply
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700103F RID: 4159
		' (get) Token: 0x06002980 RID: 10624 RVA: 0x0001AEC7 File Offset: 0x000190C7
		' (set) Token: 0x06002981 RID: 10625 RVA: 0x0019E33C File Offset: 0x0019C53C
		Private _lnkForward As LinkLabel
		Friend Overridable Property lnkForward As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._lnkForward
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.lnkForward_LinkClicked
				Dim linkLabel As LinkLabel = Me._lnkForward
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._lnkForward = value
				linkLabel = Me._lnkForward
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001040 RID: 4160
		' (get) Token: 0x06002982 RID: 10626 RVA: 0x0001AED1 File Offset: 0x000190D1
		' (set) Token: 0x06002983 RID: 10627 RVA: 0x0001AEDB File Offset: 0x000190DB
		Friend Overridable Property pnlSend As Panel

		' Token: 0x17001041 RID: 4161
		' (get) Token: 0x06002984 RID: 10628 RVA: 0x0001AEE4 File Offset: 0x000190E4
		' (set) Token: 0x06002985 RID: 10629 RVA: 0x0001AEEE File Offset: 0x000190EE
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17001042 RID: 4162
		' (get) Token: 0x06002986 RID: 10630 RVA: 0x0001AEF7 File Offset: 0x000190F7
		' (set) Token: 0x06002987 RID: 10631 RVA: 0x0001AF01 File Offset: 0x00019101
		Friend Overridable Property Label1 As Label

		' Token: 0x17001043 RID: 4163
		' (get) Token: 0x06002988 RID: 10632 RVA: 0x0001AF0A File Offset: 0x0001910A
		' (set) Token: 0x06002989 RID: 10633 RVA: 0x0001AF14 File Offset: 0x00019114
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17001044 RID: 4164
		' (get) Token: 0x0600298A RID: 10634 RVA: 0x0001AF1D File Offset: 0x0001911D
		' (set) Token: 0x0600298B RID: 10635 RVA: 0x0001AF27 File Offset: 0x00019127
		Friend Overridable Property Label2 As Label

		' Token: 0x17001045 RID: 4165
		' (get) Token: 0x0600298C RID: 10636 RVA: 0x0001AF30 File Offset: 0x00019130
		' (set) Token: 0x0600298D RID: 10637 RVA: 0x0001AF3A File Offset: 0x0001913A
		Friend Overridable Property Panel8 As Panel

		' Token: 0x17001046 RID: 4166
		' (get) Token: 0x0600298E RID: 10638 RVA: 0x0001AF43 File Offset: 0x00019143
		' (set) Token: 0x0600298F RID: 10639 RVA: 0x0001AF4D File Offset: 0x0001914D
		Friend Overridable Property Label3 As Label

		' Token: 0x17001047 RID: 4167
		' (get) Token: 0x06002990 RID: 10640 RVA: 0x0001AF56 File Offset: 0x00019156
		' (set) Token: 0x06002991 RID: 10641 RVA: 0x0019E380 File Offset: 0x0019C580
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

		' Token: 0x17001048 RID: 4168
		' (get) Token: 0x06002992 RID: 10642 RVA: 0x0001AF60 File Offset: 0x00019160
		' (set) Token: 0x06002993 RID: 10643 RVA: 0x0001AF6A File Offset: 0x0001916A
		Friend Overridable Property txtCc As TextBox

		' Token: 0x17001049 RID: 4169
		' (get) Token: 0x06002994 RID: 10644 RVA: 0x0001AF73 File Offset: 0x00019173
		' (set) Token: 0x06002995 RID: 10645 RVA: 0x0001AF7D File Offset: 0x0001917D
		Friend Overridable Property txtTo_view As TextBox

		' Token: 0x1700104A RID: 4170
		' (get) Token: 0x06002996 RID: 10646 RVA: 0x0001AF86 File Offset: 0x00019186
		' (set) Token: 0x06002997 RID: 10647 RVA: 0x0001AF90 File Offset: 0x00019190
		Friend Overridable Property txtFrom As TextBox

		' Token: 0x1700104B RID: 4171
		' (get) Token: 0x06002998 RID: 10648 RVA: 0x0001AF99 File Offset: 0x00019199
		' (set) Token: 0x06002999 RID: 10649 RVA: 0x0001AFA3 File Offset: 0x000191A3
		Friend Overridable Property Label4 As Label

		' Token: 0x1700104C RID: 4172
		' (get) Token: 0x0600299A RID: 10650 RVA: 0x0001AFAC File Offset: 0x000191AC
		' (set) Token: 0x0600299B RID: 10651 RVA: 0x0001AFB6 File Offset: 0x000191B6
		Friend Overridable Property txtSubject As TextBox

		' Token: 0x1700104D RID: 4173
		' (get) Token: 0x0600299C RID: 10652 RVA: 0x0001AFBF File Offset: 0x000191BF
		' (set) Token: 0x0600299D RID: 10653 RVA: 0x0001AFC9 File Offset: 0x000191C9
		Friend Overridable Property RichTextBox1 As RichTextBox

		' Token: 0x1700104E RID: 4174
		' (get) Token: 0x0600299E RID: 10654 RVA: 0x0001AFD2 File Offset: 0x000191D2
		' (set) Token: 0x0600299F RID: 10655 RVA: 0x0001AFDC File Offset: 0x000191DC
		Friend Overridable Property lblTo As Label

		' Token: 0x1700104F RID: 4175
		' (get) Token: 0x060029A0 RID: 10656 RVA: 0x0001AFE5 File Offset: 0x000191E5
		' (set) Token: 0x060029A1 RID: 10657 RVA: 0x0001AFEF File Offset: 0x000191EF
		Friend Overridable Property Label5 As Label

		' Token: 0x17001050 RID: 4176
		' (get) Token: 0x060029A2 RID: 10658 RVA: 0x0001AFF8 File Offset: 0x000191F8
		' (set) Token: 0x060029A3 RID: 10659 RVA: 0x0001B002 File Offset: 0x00019202
		Friend Overridable Property WebBrowser2 As WebBrowser

		' Token: 0x17001051 RID: 4177
		' (get) Token: 0x060029A4 RID: 10660 RVA: 0x0001B00B File Offset: 0x0001920B
		' (set) Token: 0x060029A5 RID: 10661 RVA: 0x0001B015 File Offset: 0x00019215
		Friend Overridable Property lblUid As Label

		' Token: 0x17001052 RID: 4178
		' (get) Token: 0x060029A6 RID: 10662 RVA: 0x0001B01E File Offset: 0x0001921E
		' (set) Token: 0x060029A7 RID: 10663 RVA: 0x0019E3C4 File Offset: 0x0019C5C4
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

		' Token: 0x17001053 RID: 4179
		' (get) Token: 0x060029A8 RID: 10664 RVA: 0x0001B028 File Offset: 0x00019228
		' (set) Token: 0x060029A9 RID: 10665 RVA: 0x0001B032 File Offset: 0x00019232
		Friend Overridable Property txtBcc As TextBox

		' Token: 0x17001054 RID: 4180
		' (get) Token: 0x060029AA RID: 10666 RVA: 0x0001B03B File Offset: 0x0001923B
		' (set) Token: 0x060029AB RID: 10667 RVA: 0x0001B045 File Offset: 0x00019245
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17001055 RID: 4181
		' (get) Token: 0x060029AC RID: 10668 RVA: 0x0001B04E File Offset: 0x0001924E
		' (set) Token: 0x060029AD RID: 10669 RVA: 0x0001B058 File Offset: 0x00019258
		Friend Overridable Property Label6 As Label

		' Token: 0x17001056 RID: 4182
		' (get) Token: 0x060029AE RID: 10670 RVA: 0x0001B061 File Offset: 0x00019261
		' (set) Token: 0x060029AF RID: 10671 RVA: 0x0001B06B File Offset: 0x0001926B
		Friend Overridable Property lblCacheStatus As Label

		' Token: 0x060029B0 RID: 10672 RVA: 0x0019E408 File Offset: 0x0019C608
		Private Sub LoadLocalCache()
			Try
				Dim flag As Boolean = File.Exists("inbox_cache_email.json")
				If flag Then
					Dim text As String = File.ReadAllText("inbox_cache_email.json")
					Dim dictionary As Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)))(text)
					Dim flag2 As Boolean = dictionary.ContainsKey("INBOX")
					If flag2 Then
						Dim enumerable As IEnumerable(Of frmEmailDashboard2.EmailModel) = dictionary("INBOX")
						Me.emailCache = enumerable.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.DateReceived).Take(Me.pageSize).ToList()
						Dim flag3 As Boolean = Me.emailCache.Count > 0
						If flag3 Then
							Me.lastFetchedUid = Me.emailCache.Max(Function(e As frmEmailDashboard2.EmailModel) e.Uid)
						End If
					Else
						Me.emailCache = New List(Of frmEmailDashboard2.EmailModel)()
					End If
				Else
					Me.emailCache = New List(Of frmEmailDashboard2.EmailModel)()
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading cache emails: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029B1 RID: 10673 RVA: 0x0019E53C File Offset: 0x0019C73C
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
						Dim emailModel As frmEmailDashboard2.EmailModel = New frmEmailDashboard2.EmailModel() With { .Uid = uniqueId.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime }
						Me.emailCache.Add(emailModel)
						Me.lastFetchedUid = uniqueId.Id
					Next
				Finally
					Dim enumerator As List(Of UniqueId).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				imapClient.Disconnect(True, Nothing)
				Dim text As String = JsonConvert.SerializeObject(Me.emailCache, Formatting.Indented)
				File.WriteAllText("inbox_cache_email.json", text)
			Catch ex As Exception
				MessageBox.Show("Error fetching new emails: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029B2 RID: 10674 RVA: 0x0001B074 File Offset: 0x00019274
		Private Sub frmEmailDashboard2_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.LoadMailFolders()
			Me.LoadLocalCache()
			Me.BindListBox()
		End Sub

		' Token: 0x060029B3 RID: 10675 RVA: 0x0019E714 File Offset: 0x0019C914
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
					Me.strPassword = ModFunc.Decrypt(ModCommonClasses.rdr(4).ToString())
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060029B4 RID: 10676 RVA: 0x0019E820 File Offset: 0x0019CA20
		Private Sub BindListBox()
			Me.ListBoxNav.Items.Clear()
			Me.emailDisplayList.Clear()
			Dim list As List(Of frmEmailDashboard2.EmailModel) = Me.emailCache.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.Uid).Take(50).ToList()
			For Each emailModel As frmEmailDashboard2.EmailModel In list
				Me.ListBoxNav.Items.Add(String.Format("{0:yyyy-MM-dd HH:mm} - {1}", emailModel.DateReceived, emailModel.Subject))
				Me.emailDisplayList.Add(emailModel)
			Next
			If Me.emailDisplayList.Count > 0 Then
				Dim maxUid As UInteger = Me.emailDisplayList.Max(Function(e As frmEmailDashboard2.EmailModel) e.Uid)
				Dim num As Integer = Me.emailDisplayList.FindIndex(Function(e As frmEmailDashboard2.EmailModel) e.Uid = maxUid)
				If num >= 0 Then
					Me.ListBoxNav.SelectedIndex = num
				End If
			End If
		End Sub

		' Token: 0x060029B5 RID: 10677 RVA: 0x0019E98C File Offset: 0x0019CB8C
		Private Sub LoadMailFolders()
			Try
				Me.TreeViewNav.Nodes.Clear()
				Using imapClient As ImapClient = New ImapClient()
					imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
					imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
					Dim treeNode As TreeNode = New TreeNode(Me.strEmailid)
					Me.TreeViewNav.Nodes.Add(treeNode)
					Dim folder As IMailFolder = imapClient.GetFolder(imapClient.PersonalNamespaces(0))
					Try
						For Each mailFolder As IMailFolder In folder.GetSubfolders(False, Nothing)
							Me.AddFoldersToTree(mailFolder, treeNode)
						Next
					Finally
						Dim enumerator As IEnumerator(Of IMailFolder)
						If enumerator IsNot Nothing Then
							enumerator.Dispose()
						End If
					End Try
					treeNode.Expand()
					imapClient.Disconnect(True, Nothing)
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading folders: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029B6 RID: 10678 RVA: 0x0019EAE0 File Offset: 0x0019CCE0
		Private Sub AddFoldersToTree(folder As IMailFolder, parentNode As TreeNode)
			Try
				Dim treeNode As TreeNode = New TreeNode(folder.Name)
				treeNode.Tag = folder.FullName
				parentNode.Nodes.Add(treeNode)
				Try
					For Each mailFolder As IMailFolder In folder.GetSubfolders(False, Nothing)
						Me.AddFoldersToTree(mailFolder, treeNode)
					Next
				Finally
					Dim enumerator As IEnumerator(Of IMailFolder)
					If enumerator IsNot Nothing Then
						enumerator.Dispose()
					End If
				End Try
			Catch ex As Exception
				Debug.WriteLine("Folder skipped: " + folder.FullName + " - " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029B7 RID: 10679 RVA: 0x0019EBA8 File Offset: 0x0019CDA8
		Private Sub TreeViewNav_AfterSelect(sender As Object, e As TreeViewEventArgs)
			Me.pnlSend.Visible = False
			Dim flag As Boolean = e.Node.Tag Is Nothing
			If Not flag Then
				Me.currentFolderFullName = e.Node.Tag.ToString()
				Me.folderPageIndex = 0
				Me.currentFolderCache.Clear()
				Me.currentFolderLastFetchedUids.Clear()
				Me.LoadEmailsForSelectedFolder()
				Me.StartBackgroundCaching(Me.currentFolderFullName)
			End If
		End Sub

		' Token: 0x060029B8 RID: 10680 RVA: 0x0001B093 File Offset: 0x00019293
		Private Sub LoadEmailsForSelectedFolder()
			Me.ListBoxNav.Items.Clear()
			Me.emailDisplayList.Clear()
			Me.ProgressBar1.Visible = True
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Task.Run(Sub()
				Try
					Dim text As String = Me.currentFolderFullName
					Dim flag As Boolean = File.Exists("inbox_cache_email.json")
					If flag Then
						Dim text2 As String
						Using fileStream As FileStream = New FileStream("inbox_cache_email.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
							Using streamReader As StreamReader = New StreamReader(fileStream)
								text2 = streamReader.ReadToEnd()
							End Using
						End Using
						Me.folderEmailCache = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)))(text2)
						Dim flag2 As Boolean = Me.folderEmailCache.ContainsKey(text)
						If flag2 Then
							Me.currentFolderCache = Me.folderEmailCache(text)
							Me.currentFolderLastFetchedUids = New HashSet(Of UniqueId)(Me.currentFolderCache.Select(Function(e As frmEmailDashboard2.EmailModel) New UniqueId(e.Uid)))
							MyBase.Invoke(Sub()
								Me.BindListBoxWithCurrentFolderEmails()
								Me.ProgressBar1.Visible = False
							End Sub)
							Return
						End If
					Else
						Me.folderEmailCache = New Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel))()
					End If
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(Me.currentFolderFullName, Nothing)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim list As List(Of UniqueId) = folder.Search(SearchQuery.All, Nothing).Reverse().ToList()
						Dim list2 As List(Of UniqueId) = list.Take(Me.pageSize).ToList()
						Dim list3 As List(Of frmEmailDashboard2.EmailModel) = New List(Of frmEmailDashboard2.EmailModel)()
						Dim hashSet As HashSet(Of UniqueId) = New HashSet(Of UniqueId)()
						Try
							For Each uniqueId As UniqueId In list2
								Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
								Dim emailModel As frmEmailDashboard2.EmailModel = New frmEmailDashboard2.EmailModel() With { .Uid = uniqueId.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime, .Body = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody) }
								list3.Add(emailModel)
								hashSet.Add(uniqueId)
							Next
						Finally
							Dim enumerator As List(Of UniqueId).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
						Me.folderEmailCache(text) = list3
						Using fileStream2 As FileStream = New FileStream("inbox_cache_email.json", FileMode.Create, FileAccess.Write, FileShare.None)
							Using streamWriter As StreamWriter = New StreamWriter(fileStream2)
								streamWriter.Write(JsonConvert.SerializeObject(Me.folderEmailCache))
							End Using
						End Using
						Me.currentFolderCache = list3
						Me.currentFolderLastFetchedUids = hashSet
						imapClient.Disconnect(True, Nothing)
					End Using
					MyBase.Invoke(Sub()
						Me.BindListBoxWithCurrentFolderEmails()
						Me.ProgressBar1.Visible = False
					End Sub)
				Catch ex As Exception
					Dim errMsg As String = ex.Message
					MyBase.Invoke(Sub()
						MessageBox.Show("Error loading emails: " + errMsg)
						Me.ProgressBar1.Visible = False
					End Sub)
				End Try
			End Sub)
		End Sub

		' Token: 0x060029B9 RID: 10681 RVA: 0x0019EC20 File Offset: 0x0019CE20
		Private Sub BindListBoxWithCurrentFolderEmails()
			Me.ListBoxNav.Items.Clear()
			Me.emailDisplayList.Clear()
			If Me.currentFolderCache IsNot Nothing Then
				For Each emailModel As frmEmailDashboard2.EmailModel In Me.currentFolderCache.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.Uid)
					Me.ListBoxNav.Items.Add(String.Format("{0:dd-MMM} - {1}: {2}", emailModel.DateReceived, emailModel.From, emailModel.Subject))
					Me.emailDisplayList.Add(emailModel)
				Next
			End If
			If Me.emailDisplayList.Count > 0 Then
				Dim maxUid As UInteger = Me.emailDisplayList.Max(Function(e As frmEmailDashboard2.EmailModel) e.Uid)
				Dim num As Integer = Me.emailDisplayList.FindIndex(Function(e As frmEmailDashboard2.EmailModel) e.Uid = maxUid)
				If num >= 0 Then
					Me.ListBoxNav.SelectedIndex = num
				End If
			End If
		End Sub

		' Token: 0x060029BA RID: 10682 RVA: 0x0019ED7C File Offset: 0x0019CF7C
		Private Sub btnLoadMore_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Dim num As Integer = Me.folderPageIndex * Me.pageSize
			Dim count As Integer = Me.currentFolderCache.Count
			Dim flag As Boolean = num >= count
			If flag Then
				MessageBox.Show("No more emails.")
			Else
				Dim num2 As Integer = Math.Min(Me.pageSize, count - num)
				Dim range As List(Of frmEmailDashboard2.EmailModel) = Me.currentFolderCache.GetRange(num, num2)
				Try
					For Each emailModel As frmEmailDashboard2.EmailModel In range
						Me.ListBoxNav.Items.Add(String.Format("{0:dd-MMM} - {1}: {2}", emailModel.DateReceived, emailModel.From, emailModel.Subject))
						Me.emailDisplayList.Add(emailModel)
					Next
				Finally
					Dim enumerator As List(Of frmEmailDashboard2.EmailModel).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				Me.folderPageIndex = Me.folderPageIndex + 1
			End If
		End Sub

		' Token: 0x060029BB RID: 10683 RVA: 0x0019EE74 File Offset: 0x0019D074
		Private Sub ListBoxNav_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.pnlSend.Visible = False
			Try
				Dim selectedIndex As Integer = Me.ListBoxNav.SelectedIndex
				Dim flag As Boolean = selectedIndex >= 0 AndAlso selectedIndex < Me.emailDisplayList.Count
				If flag Then
					Dim emailModel As frmEmailDashboard2.EmailModel = Me.emailDisplayList(selectedIndex)
					Me.lblSubject.Text = emailModel.Subject
					Me.lblFrom.Text = emailModel.From
					Me.lblTo.Text = Me.strEmailid
					Me.lblUid.Text = Conversions.ToString(emailModel.Uid)
					Dim text As String = emailModel.Body
					Dim flag2 As Boolean = text.IndexOf("<html", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<div", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<p", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<br", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<body", StringComparison.OrdinalIgnoreCase) >= 0
					Dim flag3 As Boolean = flag2
					If flag3 Then
						Me.WebBrowser1.Visible = True
						Me.rtbBody.Visible = False
						Dim flag4 As Boolean = Not text.Contains("<html")
						If flag4 Then
							text = "<html><body style='font-family:Segoe UI; font-size:12pt;'>" + text + "</body></html>"
						End If
						Me.WebBrowser1.DocumentText = text
					Else
						Me.rtbBody.Visible = True
						Me.WebBrowser1.Visible = False
						Me.rtbBody.Text = text
					End If
					Dim text2 As String = Conversions.ToString(emailModel.Uid)
					Dim uniqueId As UniqueId = New UniqueId(Convert.ToUInt32(text2))
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim inbox As IMailFolder = imapClient.Inbox
						inbox.Open(FolderAccess.[ReadOnly], Nothing)
						Dim message As MimeMessage = inbox.GetMessage(uniqueId, Nothing, Nothing)
						Me.FlowLayoutAttachments.Controls.Clear()
						Dim flag5 As Boolean = False
						Try
							For Each mimeEntity As MimeEntity In message.Attachments
								Dim flag6 As Boolean = TypeOf mimeEntity Is MimePart
								If flag6 Then
									Dim mimePart As MimePart = CType(mimeEntity, MimePart)
									Dim button As Button = New Button()
									button.Text = mimePart.FileName
									button.AutoSize = True
									button.Tag = mimePart
									AddHandler button.Click, AddressOf Me.AttachmentButton_Click
									Me.FlowLayoutAttachments.Controls.Add(button)
									flag5 = True
								End If
							Next
						Finally
							Dim enumerator As IEnumerator(Of MimeEntity)
							If enumerator IsNot Nothing Then
								enumerator.Dispose()
							End If
						End Try
						Dim flag7 As Boolean = Not flag5
						If flag7 Then
							Dim label As Label = New Label()
							label.Text = "(No attachments)"
							label.AutoSize = True
							Me.FlowLayoutAttachments.Controls.Add(label)
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("Error displaying email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029BC RID: 10684 RVA: 0x0019F200 File Offset: 0x0019D400
		Private Sub AttachmentButton_Click(sender As Object, e As EventArgs)
			Dim button As Button = CType(sender, Button)
			Dim mimePart As MimePart = TryCast(button.Tag, MimePart)
			Dim flag As Boolean = mimePart Is Nothing
			If flag Then
				MessageBox.Show("Invalid attachment.")
			Else
				Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
					saveFileDialog.FileName = mimePart.FileName
					saveFileDialog.Filter = "All Files|*.*"
					Dim flag2 As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
					If flag2 Then
						Try
							Using fileStream As FileStream = File.Create(saveFileDialog.FileName)
								mimePart.Content.DecodeTo(fileStream, Nothing)
							End Using
							MessageBox.Show("Attachment saved successfully!")
						Catch ex As Exception
							MessageBox.Show("Error saving file: " + ex.Message)
						End Try
					End If
				End Using
			End If
		End Sub

		' Token: 0x060029BD RID: 10685 RVA: 0x0019F310 File Offset: 0x0019D510
		Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
			Me.pnlSend.Visible = False
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

		' Token: 0x060029BE RID: 10686 RVA: 0x0001B0C2 File Offset: 0x000192C2
		Private Sub LoadMoreEmails()
			Me.ProgressBar1.Visible = True
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Task.Run(Sub()
				Try
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(Me.currentFolderFullName, Nothing)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim list As List(Of UniqueId) = folder.Search(SearchQuery.All, Nothing).Reverse().ToList()
						Dim hashSet As HashSet(Of UniqueId) = Me.folderLastFetchedUids(Me.currentFolderFullName)
						Dim list2 As List(Of UniqueId) = list.Except(hashSet).Take(Me.pageSize).ToList()
						If list2.Count = 0 Then
							MyBase.Invoke(Sub()
								MessageBox.Show("No more emails to load.")
							End Sub)
							Return
						End If
						For Each uniqueId As UniqueId In list2
							Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
							Dim emailModel As frmEmailDashboard2.EmailModel = New frmEmailDashboard2.EmailModel() With { .Uid = uniqueId.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime, .Body = (If(message.HtmlBody, message.TextBody)) }
							Me.folderEmailCache(Me.currentFolderFullName).Add(emailModel)
							Me.folderLastFetchedUids(Me.currentFolderFullName).Add(uniqueId)
						Next
						Me.currentFolderCache = Me.folderEmailCache(Me.currentFolderFullName)
						MyBase.Invoke(Sub()
							Me.BindListBox()
						End Sub)
						imapClient.Disconnect(True, Nothing)
					End Using
				Catch ex As Exception
					Dim errMsg As String = ex.Message
					MyBase.Invoke(Sub()
						MessageBox.Show("Error loading more emails: " + errMsg)
					End Sub)
				End Try
				MyBase.Invoke(Sub()
					Me.ProgressBar1.Visible = False
				End Sub)
			End Sub)
		End Sub
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
									Dim msgText As String
									If message.TextBody <> Nothing Then
										msgText = message.TextBody
									ElseIf message.HtmlBody <> Nothing Then
										msgText = message.HtmlBody
									Else
										msgText = "(No body content)"
									End If
									Dim emailModel As frmEmailDashboard2.EmailModel = New frmEmailDashboard2.EmailModel() With { .Uid = uid.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime, .Body = msgText }
									MyBase.Invoke(Sub()
										Me.emailCache.Add(emailModel)
										Me.lastFetchedUids.Add(uid.Id)
									End Sub)
								End If
							Next
							imapClient.Disconnect(True, Nothing)
							Dim text2 As String = JsonConvert.SerializeObject(Me.emailCache, Formatting.Indented)
							File.WriteAllText("inbox_cache_email.json", text2)
							MyBase.Invoke(Sub()
								Me.BindListBox()
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
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmailDashboard.ShowDialog()
		End Sub

		' Token: 0x060029C1 RID: 10689 RVA: 0x0019F3B0 File Offset: 0x0019D5B0
		Private Sub FetchEmailByUid(imapClient As ImapClient, folderName As String)
			Try
				Dim num As UInteger
				Dim flag As Boolean = Not UInteger.TryParse(Me.lblUid.Text, num)
				If flag Then
					MessageBox.Show("Invalid UID")
				Else
					Dim folder As IMailFolder = imapClient.GetFolder(folderName, Nothing)
					folder.Open(FolderAccess.[ReadOnly], Nothing)
					Dim message As MimeMessage = folder.GetMessage(New UniqueId(num), Nothing, Nothing)
					Dim text As String = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody)
					Dim flag2 As Boolean = text.IndexOf("<html", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<div", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<p", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<br", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<body", StringComparison.OrdinalIgnoreCase) >= 0
					Dim flag3 As Boolean = flag2
					If flag3 Then
						Me.WebBrowser2.Visible = True
						Me.RichTextBox1.Visible = True
						Me.RichTextBox1.Text = text
						Dim text2 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'>" + text + "</body></html>"
						Dim text3 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'><div id='replyArea'><br><br></div><hr><blockquote>" + text2 + "</blockquote></body></html>"
						Me.WebBrowser2.DocumentText = text3
					Else
						Me.WebBrowser2.Visible = False
						Me.RichTextBox1.Visible = True
						Me.RichTextBox1.Text = text
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error fetching email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029C2 RID: 10690 RVA: 0x0019F56C File Offset: 0x0019D76C
		Private Sub lnkReply_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.pnlSend.Visible = True
			Me.txtTo_view.Text = Me.lblFrom.Text
			Me.txtFrom.Text = Me.lblTo.Text
			Me.txtSubject.Text = "RE: " + Me.lblSubject.Text
			Me.imapClient = New ImapClient()
			Me.imapClient.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect, Nothing)
			Me.imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
			Me.FetchEmailByUid(Me.imapClient, "INBOX")
		End Sub

		' Token: 0x060029C3 RID: 10691 RVA: 0x0019F634 File Offset: 0x0019D834
		Private Sub lnkReplyAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.pnlSend.Visible = True
			Me.txtTo_view.Text = Me.lblFrom.Text
			Me.txtFrom.Text = Me.lblTo.Text
			Me.txtSubject.Text = "Re: " + Me.lblSubject.Text
		End Sub

		' Token: 0x060029C4 RID: 10692 RVA: 0x0019F6A0 File Offset: 0x0019D8A0
		Private Sub lnkForward_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.pnlSend.Visible = True
			Me.txtTo_view.Text = ""
			Me.txtFrom.Text = Me.lblTo.Text
			Me.txtSubject.Text = "Fwd: " + Me.lblSubject.Text
			Me.imapClient = New ImapClient()
			Me.imapClient.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect, Nothing)
			Me.imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
			Me.FetchEmailByUid(Me.imapClient, "INBOX")
			Me.txtTo_view.Focus()
		End Sub

		' Token: 0x060029C5 RID: 10693 RVA: 0x0019F770 File Offset: 0x0019D970
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.SendMail()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060029C6 RID: 10694 RVA: 0x0019F7A8 File Offset: 0x0019D9A8
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Public Sub SendMail()
			Try
				Dim mimeMessage As MimeMessage = New MimeMessage()
				mimeMessage.From.Add(New MailboxAddress(Me.strName, Me.strEmailid))
				mimeMessage.[To].AddRange(InternetAddressList.Parse(Me.txtTo_view.Text))
				Dim flag As Boolean = Not String.IsNullOrWhiteSpace(Me.txtCc.Text)
				If flag Then
					mimeMessage.Cc.AddRange(InternetAddressList.Parse(Me.txtCc.Text))
				End If
				Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(Me.txtBcc.Text)
				If flag2 Then
					mimeMessage.Bcc.AddRange(InternetAddressList.Parse(Me.txtBcc.Text))
				End If
				mimeMessage.Subject = Me.txtSubject.Text
				Dim bodyBuilder As BodyBuilder = New BodyBuilder()
				bodyBuilder.HtmlBody = Me.WebBrowser2.Document.Body.InnerHtml
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
				FileSystem.Reset()
			Catch ex As Exception
				MessageBox.Show("Failed to send mail: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060029C7 RID: 10695 RVA: 0x0019F9CC File Offset: 0x0019DBCC
		Private Sub btnAttach_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.attachmentPath = openFileDialog.FileName
				MessageBox.Show("Attached: " + Me.attachmentPath)
			End If
		End Sub

		' Token: 0x060029C8 RID: 10696 RVA: 0x0019FA14 File Offset: 0x0019DC14
		Private Sub StartBackgroundCaching(folderName As String)
			Me.lblCacheStatus.Text = "Caching..."
			Me.lblCacheStatus.Visible = True
			Task.Run(Sub()
				Try
					Dim existingEmails As List(Of frmEmailDashboard2.EmailModel) = Me.LoadEmailCache(folderName)
					Dim hashSet As HashSet(Of UInteger) = New HashSet(Of UInteger)(existingEmails.Select(Function(e As frmEmailDashboard2.EmailModel) e.Uid))
					Me.currentFolderCache = existingEmails.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.Uid).ToList()
					Me.folderPageIndex = 0
					Using imapClient As ImapClient = New ImapClient()
						imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
						imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
						Dim folder As IMailFolder = imapClient.GetFolder(folderName, Nothing)
						folder.Open(FolderAccess.[ReadOnly], Nothing)
						Dim list As List(Of UniqueId) = folder.Search(SearchQuery.All, Nothing).Reverse().ToList()
						Dim list2 As List(Of frmEmailDashboard2.EmailModel) = New List(Of frmEmailDashboard2.EmailModel)()
						Dim count As Integer = existingEmails.Count
						For Each uniqueId As UniqueId In list
							If Not hashSet.Contains(uniqueId.Id) Then
								Try
									Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
									Dim emailModel As frmEmailDashboard2.EmailModel = New frmEmailDashboard2.EmailModel() With { .Uid = uniqueId.Id, .Subject = message.Subject, .From = message.From.ToString(), .DateReceived = message.[Date].LocalDateTime, .Body = (If(message.HtmlBody, message.TextBody)) }
									list2.Add(emailModel)
									count += 1
									Dim currentCount As Integer = count
									Me.Invoke(Sub()
										Me.lblCacheStatus.Text = String.Format("Caching... {0} emails loaded", currentCount)
									End Sub)
									Thread.Sleep(50)
								Catch ex As Exception
								End Try
							End If
						Next
						If list2.Any() Then
							existingEmails.AddRange(list2)
							existingEmails = existingEmails.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.Uid).ToList()
							Me.SaveEmailCache(folderName, existingEmails)
						End If
						Me.folderEmailCache(folderName) = existingEmails
						Me.currentFolderCache = existingEmails
						Dim finalCount As Integer = existingEmails.Count
						Me.Invoke(Sub()
							Me.lblCacheStatus.Text = String.Format("Caching complete: {0} emails loaded", finalCount)
						End Sub)
					End Using
				Catch ex2 As Exception
					Dim errMsg As String = ex2.Message
					Me.Invoke(Sub()
						MessageBox.Show("Error caching emails: " + errMsg)
					End Sub)
				End Try
			End Sub)
		End Sub
		Private Sub SaveEmailCache(folderName As String, emails As List(Of frmEmailDashboard2.EmailModel))
			Dim typeFromHandle As Object = GetType(frmEmailDashboard2.EmailModel)
			SyncLock typeFromHandle
				Dim dictionary As Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)) = New Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel))()
				Try
					Dim flag2 As Boolean = File.Exists("inbox_cache_email.json")
					If flag2 Then
						Dim text As String = File.ReadAllText("inbox_cache_email.json")
						dictionary = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)))(text)
					End If
				Catch ex As Exception
					dictionary = New Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel))()
				End Try
				dictionary(folderName) = emails.OrderByDescending(Function(e As frmEmailDashboard2.EmailModel) e.Uid).ToList()
				File.WriteAllText("inbox_cache_email.json", JsonConvert.SerializeObject(dictionary, Formatting.Indented))
			End SyncLock
		End Sub

		' Token: 0x060029CA RID: 10698 RVA: 0x0019FB44 File Offset: 0x0019DD44
		Private Function LoadEmailCache(folderName As String) As List(Of frmEmailDashboard2.EmailModel)
			Try
				Dim flag As Boolean = Not File.Exists("inbox_cache_email.json")
				If flag Then
					Return New List(Of frmEmailDashboard2.EmailModel)()
				End If
				Dim text As String = File.ReadAllText("inbox_cache_email.json")
				Dim dictionary As Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel)))(text)
				Dim flag2 As Boolean = dictionary IsNot Nothing AndAlso dictionary.ContainsKey(folderName)
				If flag2 Then
					Return dictionary(folderName)
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading cache: " + ex.Message)
			End Try
			Return New List(Of frmEmailDashboard2.EmailModel)()
		End Function

		' Token: 0x040011A4 RID: 4516
		Private attachmentPath As String

		' Token: 0x040011A5 RID: 4517
		Private strHost As String

		' Token: 0x040011A6 RID: 4518
		Private intPort As Integer

		' Token: 0x040011A7 RID: 4519
		Private strName As String

		' Token: 0x040011A8 RID: 4520
		Private strEmailid As String

		' Token: 0x040011A9 RID: 4521
		Private strPassword As String

		' Token: 0x040011AA RID: 4522
		Private lastSentUid As UInteger

		' Token: 0x040011AB RID: 4523
		Private Const cacheFilePath As String = "inbox_cache_email.json"

		' Token: 0x040011AC RID: 4524
		Private emailCache As List(Of frmEmailDashboard2.EmailModel)

		' Token: 0x040011AD RID: 4525
		Private lastFetchedUid As UInteger

		' Token: 0x040011AE RID: 4526
		Private sentEmailCache As List(Of frmEmailDashboard2.EmailModelSent)

		' Token: 0x040011AF RID: 4527
		Private sentLastFetchedUids As HashSet(Of UInteger)

		' Token: 0x040011B0 RID: 4528
		Private sentFetchPageIndex As Integer

		' Token: 0x040011B1 RID: 4529
		Private sentPageSize As Integer

		' Token: 0x040011B2 RID: 4530
		Private sentCacheFilePath As String

		' Token: 0x040011B3 RID: 4531
		Private fetchPageIndex As Integer

		' Token: 0x040011B4 RID: 4532
		Private pageSize As Integer

		' Token: 0x040011B5 RID: 4533
		Private lastFetchedUids As HashSet(Of UInteger)

		' Token: 0x040011B6 RID: 4534
		Private strmail_type As String

		' Token: 0x040011B7 RID: 4535
		Private apiKey As String

		' Token: 0x040011B8 RID: 4536
		Private url As String

		' Token: 0x040011B9 RID: 4537
		Private folderEmailCache As Dictionary(Of String, List(Of frmEmailDashboard2.EmailModel))

		' Token: 0x040011BA RID: 4538
		Private folderLastFetchedUids As Dictionary(Of String, HashSet(Of UniqueId))

		' Token: 0x040011BB RID: 4539
		Private currentFolderFullName As String

		' Token: 0x040011BC RID: 4540
		Private currentFolderCache As List(Of frmEmailDashboard2.EmailModel)

		' Token: 0x040011BD RID: 4541
		Private folderPageIndex As Integer

		' Token: 0x040011BE RID: 4542
		Private currentFolderLastFetchedUids As HashSet(Of UniqueId)

		' Token: 0x040011BF RID: 4543
		Private currentFolderPage As Integer

		' Token: 0x040011C0 RID: 4544
		Private emailDisplayList As List(Of frmEmailDashboard2.EmailModel)

		' Token: 0x040011C1 RID: 4545
		Private imapClient As ImapClient

		' Token: 0x020000F5 RID: 245
		Public Class EmailModel
			' Token: 0x17001057 RID: 4183
			' (get) Token: 0x060029D5 RID: 10709 RVA: 0x0001B135 File Offset: 0x00019335
			' (set) Token: 0x060029D6 RID: 10710 RVA: 0x0001B13F File Offset: 0x0001933F
			Public Property Uid As UInteger

			' Token: 0x17001058 RID: 4184
			' (get) Token: 0x060029D7 RID: 10711 RVA: 0x0001B148 File Offset: 0x00019348
			' (set) Token: 0x060029D8 RID: 10712 RVA: 0x0001B152 File Offset: 0x00019352
			Public Property Subject As String

			' Token: 0x17001059 RID: 4185
			' (get) Token: 0x060029D9 RID: 10713 RVA: 0x0001B15B File Offset: 0x0001935B
			' (set) Token: 0x060029DA RID: 10714 RVA: 0x0001B165 File Offset: 0x00019365
			Public Property From As String

			' Token: 0x1700105A RID: 4186
			' (get) Token: 0x060029DB RID: 10715 RVA: 0x0001B16E File Offset: 0x0001936E
			' (set) Token: 0x060029DC RID: 10716 RVA: 0x0001B178 File Offset: 0x00019378
			Public Property DateReceived As DateTime

			' Token: 0x1700105B RID: 4187
			' (get) Token: 0x060029DD RID: 10717 RVA: 0x0001B181 File Offset: 0x00019381
			' (set) Token: 0x060029DE RID: 10718 RVA: 0x0001B18B File Offset: 0x0001938B
			Public Property Body As String

			' Token: 0x1700105C RID: 4188
			' (get) Token: 0x060029DF RID: 10719 RVA: 0x0001B194 File Offset: 0x00019394
			' (set) Token: 0x060029E0 RID: 10720 RVA: 0x0001B19E File Offset: 0x0001939E
			Public Property IsHtml As Boolean
		End Class

		' Token: 0x020000F6 RID: 246
		Public Class EmailModelSent
			' Token: 0x1700105D RID: 4189
			' (get) Token: 0x060029E2 RID: 10722 RVA: 0x0001B1A7 File Offset: 0x000193A7
			' (set) Token: 0x060029E3 RID: 10723 RVA: 0x0001B1B1 File Offset: 0x000193B1
			Public Property Uid As UInteger

			' Token: 0x1700105E RID: 4190
			' (get) Token: 0x060029E4 RID: 10724 RVA: 0x0001B1BA File Offset: 0x000193BA
			' (set) Token: 0x060029E5 RID: 10725 RVA: 0x0001B1C4 File Offset: 0x000193C4
			Public Property Subject As String

			' Token: 0x1700105F RID: 4191
			' (get) Token: 0x060029E6 RID: 10726 RVA: 0x0001B1CD File Offset: 0x000193CD
			' (set) Token: 0x060029E7 RID: 10727 RVA: 0x0001B1D7 File Offset: 0x000193D7
			Public Property [To] As String

			' Token: 0x17001060 RID: 4192
			' (get) Token: 0x060029E8 RID: 10728 RVA: 0x0001B1E0 File Offset: 0x000193E0
			' (set) Token: 0x060029E9 RID: 10729 RVA: 0x0001B1EA File Offset: 0x000193EA
			Public Property From As String

			' Token: 0x17001061 RID: 4193
			' (get) Token: 0x060029EA RID: 10730 RVA: 0x0001B1F3 File Offset: 0x000193F3
			' (set) Token: 0x060029EB RID: 10731 RVA: 0x0001B1FD File Offset: 0x000193FD
			Public Property DateReceived As DateTime
		End Class
	End Class
End Namespace
