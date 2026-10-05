Imports System
Imports System.Collections
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
Imports System.Windows.Forms
Imports MailKit
Imports MailKit.Net.Imap
Imports MailKit.Net.Smtp
Imports MailKit.Search
Imports MailKit.Security
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MimeKit

Namespace BillPoint
	' Token: 0x02000104 RID: 260
	<DesignerGenerated()>
	Public Partial Class frmEmailDashboard3
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002A13 RID: 10771 RVA: 0x001A0C48 File Offset: 0x0019EE48
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEmailDashboard3_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmEmailDashboard3_FormClosing
			AddHandler MyBase.Click, AddressOf Me.frmEmailDashboard3_Click
			Me.attachmentPath = ""
			Me.confirmedEmails = New List(Of String)()
			Me.attachmentList = New List(Of String)()
			Me.strHost = ""
			Me.strName = ""
			Me.strEmailid = ""
			Me.strPassword = ""
			Me.currentFolderFullName = "INBOX"
			Me.currentFolderEmails = New List(Of frmEmailDashboard3.EmailItem)()
			Me.currentPageIndex = 0
			Me.pageSize = 50
			Me.strinputype = ""
			Me.emailDisplayList = New List(Of frmEmailDashboard3.EmailItem)()
			Me.strlistStatus = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001062 RID: 4194
		' (get) Token: 0x06002A16 RID: 10774 RVA: 0x0001B40D File Offset: 0x0001960D
		' (set) Token: 0x06002A17 RID: 10775 RVA: 0x001A264C File Offset: 0x001A084C
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

		' Token: 0x17001063 RID: 4195
		' (get) Token: 0x06002A18 RID: 10776 RVA: 0x0001B417 File Offset: 0x00019617
		' (set) Token: 0x06002A19 RID: 10777 RVA: 0x001A2690 File Offset: 0x001A0890
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

		' Token: 0x17001064 RID: 4196
		' (get) Token: 0x06002A1A RID: 10778 RVA: 0x0001B421 File Offset: 0x00019621
		' (set) Token: 0x06002A1B RID: 10779 RVA: 0x001A26D4 File Offset: 0x001A08D4
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

		' Token: 0x17001065 RID: 4197
		' (get) Token: 0x06002A1C RID: 10780 RVA: 0x0001B42B File Offset: 0x0001962B
		' (set) Token: 0x06002A1D RID: 10781 RVA: 0x0001B435 File Offset: 0x00019635
		Friend Overridable Property FlowLayoutAttachments As FlowLayoutPanel

		' Token: 0x17001066 RID: 4198
		' (get) Token: 0x06002A1E RID: 10782 RVA: 0x0001B43E File Offset: 0x0001963E
		' (set) Token: 0x06002A1F RID: 10783 RVA: 0x0001B448 File Offset: 0x00019648
		Friend Overridable Property rtbBody As RichTextBox

		' Token: 0x17001067 RID: 4199
		' (get) Token: 0x06002A20 RID: 10784 RVA: 0x0001B451 File Offset: 0x00019651
		' (set) Token: 0x06002A21 RID: 10785 RVA: 0x0001B45B File Offset: 0x0001965B
		Friend Overridable Property WebBrowser1 As WebBrowser

		' Token: 0x17001068 RID: 4200
		' (get) Token: 0x06002A22 RID: 10786 RVA: 0x0001B464 File Offset: 0x00019664
		' (set) Token: 0x06002A23 RID: 10787 RVA: 0x0001B46E File Offset: 0x0001966E
		Friend Overridable Property Label5 As Label

		' Token: 0x17001069 RID: 4201
		' (get) Token: 0x06002A24 RID: 10788 RVA: 0x0001B477 File Offset: 0x00019677
		' (set) Token: 0x06002A25 RID: 10789 RVA: 0x0001B481 File Offset: 0x00019681
		Friend Overridable Property Label1 As Label

		' Token: 0x1700106A RID: 4202
		' (get) Token: 0x06002A26 RID: 10790 RVA: 0x0001B48A File Offset: 0x0001968A
		' (set) Token: 0x06002A27 RID: 10791 RVA: 0x0001B494 File Offset: 0x00019694
		Friend Overridable Property Label2 As Label

		' Token: 0x1700106B RID: 4203
		' (get) Token: 0x06002A28 RID: 10792 RVA: 0x0001B49D File Offset: 0x0001969D
		' (set) Token: 0x06002A29 RID: 10793 RVA: 0x0001B4A7 File Offset: 0x000196A7
		Friend Overridable Property Label3 As Label

		' Token: 0x1700106C RID: 4204
		' (get) Token: 0x06002A2A RID: 10794 RVA: 0x0001B4B0 File Offset: 0x000196B0
		' (set) Token: 0x06002A2B RID: 10795 RVA: 0x0001B4BA File Offset: 0x000196BA
		Friend Overridable Property lblTo As Label

		' Token: 0x1700106D RID: 4205
		' (get) Token: 0x06002A2C RID: 10796 RVA: 0x0001B4C3 File Offset: 0x000196C3
		' (set) Token: 0x06002A2D RID: 10797 RVA: 0x001A2718 File Offset: 0x001A0918
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

		' Token: 0x1700106E RID: 4206
		' (get) Token: 0x06002A2E RID: 10798 RVA: 0x0001B4CD File Offset: 0x000196CD
		' (set) Token: 0x06002A2F RID: 10799 RVA: 0x0001B4D7 File Offset: 0x000196D7
		Friend Overridable Property WebBrowser2 As WebBrowser

		' Token: 0x1700106F RID: 4207
		' (get) Token: 0x06002A30 RID: 10800 RVA: 0x0001B4E0 File Offset: 0x000196E0
		' (set) Token: 0x06002A31 RID: 10801 RVA: 0x0001B4EA File Offset: 0x000196EA
		Friend Overridable Property Label6 As Label

		' Token: 0x17001070 RID: 4208
		' (get) Token: 0x06002A32 RID: 10802 RVA: 0x0001B4F3 File Offset: 0x000196F3
		' (set) Token: 0x06002A33 RID: 10803 RVA: 0x001A275C File Offset: 0x001A095C
		Private _txtBcc As TextBox
		Friend Overridable Property txtBcc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBcc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBcc_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBcc_KeyDown
				Dim textBox As TextBox = Me._txtBcc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBcc = value
				textBox = Me._txtBcc
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001071 RID: 4209
		' (get) Token: 0x06002A34 RID: 10804 RVA: 0x0001B4FD File Offset: 0x000196FD
		' (set) Token: 0x06002A35 RID: 10805 RVA: 0x0001B507 File Offset: 0x00019707
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17001072 RID: 4210
		' (get) Token: 0x06002A36 RID: 10806 RVA: 0x0001B510 File Offset: 0x00019710
		' (set) Token: 0x06002A37 RID: 10807 RVA: 0x0001B51A File Offset: 0x0001971A
		Friend Overridable Property RichTextBox1 As RichTextBox

		' Token: 0x17001073 RID: 4211
		' (get) Token: 0x06002A38 RID: 10808 RVA: 0x0001B523 File Offset: 0x00019723
		' (set) Token: 0x06002A39 RID: 10809 RVA: 0x001A27BC File Offset: 0x001A09BC
		Private _ListBoxNav As ListBox
		Friend Overridable Property ListBoxNav As ListBox
			<CompilerGenerated()>
			Get
				Return Me._ListBoxNav
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Dim eventHandler As EventHandler = AddressOf Me.ListViewEmails_SelectedIndexChanged
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

		' Token: 0x17001074 RID: 4212
		' (get) Token: 0x06002A3A RID: 10810 RVA: 0x0001B52D File Offset: 0x0001972D
		' (set) Token: 0x06002A3B RID: 10811 RVA: 0x001A2800 File Offset: 0x001A0A00
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

		' Token: 0x17001075 RID: 4213
		' (get) Token: 0x06002A3C RID: 10812 RVA: 0x0001B537 File Offset: 0x00019737
		' (set) Token: 0x06002A3D RID: 10813 RVA: 0x0001B541 File Offset: 0x00019741
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17001076 RID: 4214
		' (get) Token: 0x06002A3E RID: 10814 RVA: 0x0001B54A File Offset: 0x0001974A
		' (set) Token: 0x06002A3F RID: 10815 RVA: 0x0001B554 File Offset: 0x00019754
		Friend Overridable Property lblCacheStatus As Label

		' Token: 0x17001077 RID: 4215
		' (get) Token: 0x06002A40 RID: 10816 RVA: 0x0001B55D File Offset: 0x0001975D
		' (set) Token: 0x06002A41 RID: 10817 RVA: 0x0001B567 File Offset: 0x00019767
		Friend Overridable Property lblUid As Label

		' Token: 0x17001078 RID: 4216
		' (get) Token: 0x06002A42 RID: 10818 RVA: 0x0001B570 File Offset: 0x00019770
		' (set) Token: 0x06002A43 RID: 10819 RVA: 0x0001B57A File Offset: 0x0001977A
		Friend Overridable Property pnlSend As Panel

		' Token: 0x17001079 RID: 4217
		' (get) Token: 0x06002A44 RID: 10820 RVA: 0x0001B583 File Offset: 0x00019783
		' (set) Token: 0x06002A45 RID: 10821 RVA: 0x0001B58D File Offset: 0x0001978D
		Friend Overridable Property Label4 As Label

		' Token: 0x1700107A RID: 4218
		' (get) Token: 0x06002A46 RID: 10822 RVA: 0x0001B596 File Offset: 0x00019796
		' (set) Token: 0x06002A47 RID: 10823 RVA: 0x0001B5A0 File Offset: 0x000197A0
		Friend Overridable Property txtSubject As TextBox

		' Token: 0x1700107B RID: 4219
		' (get) Token: 0x06002A48 RID: 10824 RVA: 0x0001B5A9 File Offset: 0x000197A9
		' (set) Token: 0x06002A49 RID: 10825 RVA: 0x001A2844 File Offset: 0x001A0A44
		Private _txtCc As TextBox
		Friend Overridable Property txtCc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCc_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCc_KeyDown
				Dim textBox As TextBox = Me._txtCc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCc = value
				textBox = Me._txtCc
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700107C RID: 4220
		' (get) Token: 0x06002A4A RID: 10826 RVA: 0x0001B5B3 File Offset: 0x000197B3
		' (set) Token: 0x06002A4B RID: 10827 RVA: 0x001A28A4 File Offset: 0x001A0AA4
		Private _txtTo_view As TextBox
		Friend Overridable Property txtTo_view As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTo_view
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTo_view_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTo_view_KeyDown
				Dim textBox As TextBox = Me._txtTo_view
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtTo_view = value
				textBox = Me._txtTo_view
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700107D RID: 4221
		' (get) Token: 0x06002A4C RID: 10828 RVA: 0x0001B5BD File Offset: 0x000197BD
		' (set) Token: 0x06002A4D RID: 10829 RVA: 0x0001B5C7 File Offset: 0x000197C7
		Friend Overridable Property txtFrom As TextBox

		' Token: 0x1700107E RID: 4222
		' (get) Token: 0x06002A4E RID: 10830 RVA: 0x0001B5D0 File Offset: 0x000197D0
		' (set) Token: 0x06002A4F RID: 10831 RVA: 0x001A2904 File Offset: 0x001A0B04
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

		' Token: 0x1700107F RID: 4223
		' (get) Token: 0x06002A50 RID: 10832 RVA: 0x0001B5DA File Offset: 0x000197DA
		' (set) Token: 0x06002A51 RID: 10833 RVA: 0x0001B5E4 File Offset: 0x000197E4
		Friend Overridable Property Panel8 As Panel

		' Token: 0x17001080 RID: 4224
		' (get) Token: 0x06002A52 RID: 10834 RVA: 0x0001B5ED File Offset: 0x000197ED
		' (set) Token: 0x06002A53 RID: 10835 RVA: 0x0001B5F7 File Offset: 0x000197F7
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17001081 RID: 4225
		' (get) Token: 0x06002A54 RID: 10836 RVA: 0x0001B600 File Offset: 0x00019800
		' (set) Token: 0x06002A55 RID: 10837 RVA: 0x0001B60A File Offset: 0x0001980A
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17001082 RID: 4226
		' (get) Token: 0x06002A56 RID: 10838 RVA: 0x0001B613 File Offset: 0x00019813
		' (set) Token: 0x06002A57 RID: 10839 RVA: 0x0001B61D File Offset: 0x0001981D
		Friend Overridable Property lblFrom As Label

		' Token: 0x17001083 RID: 4227
		' (get) Token: 0x06002A58 RID: 10840 RVA: 0x0001B626 File Offset: 0x00019826
		' (set) Token: 0x06002A59 RID: 10841 RVA: 0x0001B630 File Offset: 0x00019830
		Friend Overridable Property lblSubject As Label

		' Token: 0x17001084 RID: 4228
		' (get) Token: 0x06002A5A RID: 10842 RVA: 0x0001B639 File Offset: 0x00019839
		' (set) Token: 0x06002A5B RID: 10843 RVA: 0x0001B643 File Offset: 0x00019843
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001085 RID: 4229
		' (get) Token: 0x06002A5C RID: 10844 RVA: 0x0001B64C File Offset: 0x0001984C
		' (set) Token: 0x06002A5D RID: 10845 RVA: 0x001A2948 File Offset: 0x001A0B48
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

		' Token: 0x17001086 RID: 4230
		' (get) Token: 0x06002A5E RID: 10846 RVA: 0x0001B656 File Offset: 0x00019856
		' (set) Token: 0x06002A5F RID: 10847 RVA: 0x0001B660 File Offset: 0x00019860
		Friend Overridable Property Button1 As Button

		' Token: 0x17001087 RID: 4231
		' (get) Token: 0x06002A60 RID: 10848 RVA: 0x0001B669 File Offset: 0x00019869
		' (set) Token: 0x06002A61 RID: 10849 RVA: 0x0001B673 File Offset: 0x00019873
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17001088 RID: 4232
		' (get) Token: 0x06002A62 RID: 10850 RVA: 0x0001B67C File Offset: 0x0001987C
		' (set) Token: 0x06002A63 RID: 10851 RVA: 0x0001B686 File Offset: 0x00019886
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17001089 RID: 4233
		' (get) Token: 0x06002A64 RID: 10852 RVA: 0x0001B68F File Offset: 0x0001988F
		' (set) Token: 0x06002A65 RID: 10853 RVA: 0x0001B699 File Offset: 0x00019899
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700108A RID: 4234
		' (get) Token: 0x06002A66 RID: 10854 RVA: 0x0001B6A2 File Offset: 0x000198A2
		' (set) Token: 0x06002A67 RID: 10855 RVA: 0x001A298C File Offset: 0x001A0B8C
		Private _lstSuggestions As ListBox
		Friend Overridable Property lstSuggestions As ListBox
			<CompilerGenerated()>
			Get
				Return Me._lstSuggestions
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Dim eventHandler As EventHandler = AddressOf Me.lstSuggestions_DoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.lstSuggestions_KeyDown
				Dim listBox As ListBox = Me._lstSuggestions
				If listBox IsNot Nothing Then
					RemoveHandler listBox.DoubleClick, eventHandler
					RemoveHandler listBox.KeyDown, keyEventHandler
				End If
				Me._lstSuggestions = value
				listBox = Me._lstSuggestions
				If listBox IsNot Nothing Then
					AddHandler listBox.DoubleClick, eventHandler
					AddHandler listBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700108B RID: 4235
		' (get) Token: 0x06002A68 RID: 10856 RVA: 0x0001B6AC File Offset: 0x000198AC
		' (set) Token: 0x06002A69 RID: 10857 RVA: 0x0001B6B6 File Offset: 0x000198B6
		Friend Overridable Property flpToList As FlowLayoutPanel

		' Token: 0x1700108C RID: 4236
		' (get) Token: 0x06002A6A RID: 10858 RVA: 0x0001B6BF File Offset: 0x000198BF
		' (set) Token: 0x06002A6B RID: 10859 RVA: 0x001A29EC File Offset: 0x001A0BEC
		Private _btnNew As Button
		Friend Overridable Property btnNew As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim button As Button = Me._btnNew
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNew = value
				button = Me._btnNew
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700108D RID: 4237
		' (get) Token: 0x06002A6C RID: 10860 RVA: 0x0001B6C9 File Offset: 0x000198C9
		' (set) Token: 0x06002A6D RID: 10861 RVA: 0x0001B6D3 File Offset: 0x000198D3
		Friend Overridable Property flowAttachments As FlowLayoutPanel

		' Token: 0x06002A6E RID: 10862 RVA: 0x001A2A30 File Offset: 0x001A0C30
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

		' Token: 0x06002A6F RID: 10863 RVA: 0x001A2B3C File Offset: 0x001A0D3C
		Private Sub LoadMailFolders()
			Try
				Me.TreeViewNav.Nodes.Clear()
				Me._imapClient = New ImapClient()
				Me._imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
				Me._imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
				Dim treeNode As TreeNode = New TreeNode(Me.strEmailid)
				Me.TreeViewNav.Nodes.Add(treeNode)
				Dim folder As IMailFolder = Me._imapClient.GetFolder(Me._imapClient.PersonalNamespaces(0))
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
			Catch ex As Exception
				MessageBox.Show("Error loading folders: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A70 RID: 10864 RVA: 0x001A2C78 File Offset: 0x001A0E78
		Private Sub AddFoldersToTree(folder As IMailFolder, parentNode As TreeNode)
			Dim treeNode As TreeNode = New TreeNode(folder.Name)
			treeNode.Tag = folder
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
		End Sub

		' Token: 0x06002A71 RID: 10865 RVA: 0x001A2CFC File Offset: 0x001A0EFC
				Public Sub SyncEmails(folder As IMailFolder)
			folder.Open(FolderAccess.[ReadOnly], Nothing)
			Dim highestUID As ULong = CULng(Me.GetHighestCachedUID(folder.FullName))
			Dim list As IList(Of UniqueId) = folder.Search(SearchQuery.All, Nothing)
			Dim list2 As List(Of UniqueId) = list.Where(Function(uid As UniqueId) CULng(uid.Id) > highestUID).ToList()
			Dim flag As Boolean = list2.Count = 0
			If Not flag Then
				Dim list3 As IList(Of IMessageSummary) = folder.Fetch(list2, MessageSummaryItems.Envelope Or MessageSummaryItems.UniqueId)
				Try
					For Each messageSummary As IMessageSummary In list3
						Me.SaveEmailToCache(folder.FullName, messageSummary)
					Next
				Finally
					Dim enumerator As IEnumerator(Of IMessageSummary)
					If enumerator IsNot Nothing Then
						enumerator.Dispose()
					End If
				End Try
			End If
		End Sub

		' Token: 0x06002A72 RID: 10866 RVA: 0x001A2DDC File Offset: 0x001A0FDC
		Public Sub SaveEmailToCache(folderName As String, summary As IMessageSummary)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "                IF NOT EXISTS (SELECT 1 FROM EmailCache WHERE FolderName=@f AND UID=@u)" & vbCrLf & "                INSERT INTO EmailCache (FolderName, UID, Subject, FromName, DateReceived, Emailid)" & vbCrLf & "                VALUES (@f, @u, @s, @from, @d, @e)", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@f", folderName)
					sqlCommand.Parameters.AddWithValue("@u", Convert.ToInt64(summary.UniqueId.Id))
					sqlCommand.Parameters.AddWithValue("@s", If(summary.Envelope.Subject, ""))
					sqlCommand.Parameters.AddWithValue("@from", summary.Envelope.From.ToString())
					sqlCommand.Parameters.AddWithValue("@d", RuntimeHelpers.GetObjectValue(If((summary.Envelope.[Date] IsNot Nothing), summary.Envelope.[Date].Value.ToLocalTime(), DBNull.Value)))
					sqlCommand.Parameters.AddWithValue("@e", Me.strEmailid)
					sqlCommand.ExecuteNonQuery()
				End Using
			Catch ex As Exception
				MessageBox.Show("Error : " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A73 RID: 10867 RVA: 0x001A2F68 File Offset: 0x001A1168
		Public Function GetHighestCachedUID(folderName As String) As Long
			Dim num As Long
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ISNULL(MAX(UID), 0) FROM EmailCache WHERE FolderName=@f and Emailid=@e", sqlConnection)
				sqlCommand.Parameters.AddWithValue("@f", folderName)
				sqlCommand.Parameters.AddWithValue("@e", Me.strEmailid)
				num = Convert.ToInt64(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
			End Using
			Return num
		End Function

		' Token: 0x06002A74 RID: 10868 RVA: 0x001A2FF0 File Offset: 0x001A11F0
		Public Function LoadCachedEmails(folderName As String) As List(Of frmEmailDashboard3.EmailItem)
			Dim list As List(Of frmEmailDashboard3.EmailItem) = New List(Of frmEmailDashboard3.EmailItem)()
			Dim list2 As List(Of frmEmailDashboard3.EmailItem)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT UID, Subject, FromName, DateReceived FROM EmailCache WHERE FolderName=@f and Emailid=@e ORDER BY UID DESC", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@f", folderName)
					sqlCommand.Parameters.AddWithValue("@e", Me.strEmailid)
					Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
					While sqlDataReader.Read()
						list.Add(New frmEmailDashboard3.EmailItem() With { .UID = sqlDataReader.GetInt64(0), .Subject = If(sqlDataReader.IsDBNull(1), "", sqlDataReader.GetString(1)), .From = If(sqlDataReader.IsDBNull(2), "", sqlDataReader.GetString(2)), .DateReceived = If(sqlDataReader.IsDBNull(3), "", sqlDataReader.GetDateTime(3).ToString("g")) })
					End While
				End Using
				list2 = list
			Catch ex As Exception
				MessageBox.Show("Error : " + ex.Message)
			End Try
			Return list2
		End Function

		' Token: 0x06002A75 RID: 10869 RVA: 0x001A3164 File Offset: 0x001A1364
		Private Function FindNodeByFolderName(parent As TreeNode, folderName As String) As TreeNode
			Dim flag As Boolean = parent Is Nothing
			Dim treeNode As TreeNode
			If flag Then
				treeNode = Nothing
			Else
				Try
					For Each obj As Object In parent.Nodes
						Dim treeNode2 As TreeNode = CType(obj, TreeNode)
						Dim flag2 As Boolean = treeNode2.Text.Equals(folderName, StringComparison.OrdinalIgnoreCase)
						If flag2 Then
							Return treeNode2
						End If
						Dim treeNode3 As TreeNode = Me.FindNodeByFolderName(treeNode2, folderName)
						Dim flag3 As Boolean = treeNode3 IsNot Nothing
						If flag3 Then
							Return treeNode3
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				treeNode = Nothing
			End If
			Return treeNode
		End Function

		' Token: 0x06002A76 RID: 10870 RVA: 0x001A3204 File Offset: 0x001A1404
		Private Sub frmEmailDashboard3_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.LoadMailFolders()
			Dim treeNode As TreeNode = Me.FindNodeByFolderName(Me.TreeViewNav.Nodes(0), Me.currentFolderFullName)
			Dim flag As Boolean = treeNode IsNot Nothing
			If flag Then
				Me.TreeViewNav.SelectedNode = treeNode
				Me.TreeViewNav_AfterSelect(Me.TreeViewNav, New TreeViewEventArgs(treeNode))
			End If
		End Sub

		' Token: 0x06002A77 RID: 10871 RVA: 0x001A3268 File Offset: 0x001A1468
		Private Sub TreeViewNav_AfterSelect(sender As Object, e As TreeViewEventArgs)
			Me.pnlSend.Visible = False
			Try
				Dim mailFolder As IMailFolder = TryCast(e.Node.Tag, IMailFolder)
				Dim flag As Boolean = mailFolder Is Nothing
				If Not flag Then
					Dim flag2 As Boolean = Not mailFolder.IsOpen
					If flag2 Then
						mailFolder.Open(FolderAccess.[ReadOnly], Nothing)
					End If
					Me.SyncEmails(mailFolder)
					Me.currentFolderFullName = mailFolder.FullName
					Me.currentFolderEmails = Me.LoadCachedEmails(mailFolder.FullName).OrderByDescending(Function(email As frmEmailDashboard3.EmailItem) email.UID).ToList()
					Me.currentPageIndex = 0
					Me.LoadPage()
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading cached emails: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A78 RID: 10872 RVA: 0x001A3360 File Offset: 0x001A1560
		Private Sub LoadPage()
			' The following expression was wrapped in a checked-expression
			Dim num As Integer = Me.currentPageIndex * Me.pageSize
			Dim list As List(Of frmEmailDashboard3.EmailItem) = Me.currentFolderEmails.Skip(num).Take(Me.pageSize).ToList()
			Me.BindToListView(list)
		End Sub

		' Token: 0x06002A79 RID: 10873 RVA: 0x001A33A4 File Offset: 0x001A15A4
		Private Sub btnLoadMore_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Dim num As Integer = Me.currentPageIndex + 1
			Dim num2 As Integer = num * Me.pageSize
			Dim flag As Boolean = num2 >= Me.currentFolderEmails.Count
			If flag Then
				MessageBox.Show("No more emails to load.")
			Else
				Me.currentPageIndex = num
				Dim list As List(Of frmEmailDashboard3.EmailItem) = Me.currentFolderEmails.Skip(num2).Take(Me.pageSize).ToList()
				Me.AppendToListView(list)
			End If
		End Sub

		' Token: 0x06002A7A RID: 10874 RVA: 0x001A3414 File Offset: 0x001A1614
		Private Sub AppendToListView(emails As List(Of frmEmailDashboard3.EmailItem))
			Try
				For Each emailItem As frmEmailDashboard3.EmailItem In emails
					Dim text As String = String.Format("{0:yyyy-MM-dd HH:mm} - {1}", emailItem.DateReceived, emailItem.Subject)
					Me.ListBoxNav.Items.Add(text)
				Next
			Finally
				Dim enumerator As List(Of frmEmailDashboard3.EmailItem).Enumerator
				CType(enumerator, IDisposable).Dispose()
			End Try
		End Sub

		' Token: 0x06002A7B RID: 10875 RVA: 0x001A348C File Offset: 0x001A168C
		Public Sub BindToListView(emails As List(Of frmEmailDashboard3.EmailItem))
			Me.ListBoxNav.Items.Clear()
			Try
				For Each emailItem As frmEmailDashboard3.EmailItem In emails
					Dim emailListItem As frmEmailDashboard3.EmailListItem = New frmEmailDashboard3.EmailListItem() With { .UID = emailItem.UID, .DisplayText = String.Format("{0:yyyy-MM-dd HH:mm} - {1}", emailItem.DateReceived, emailItem.Subject) }
					Me.ListBoxNav.Items.Add(emailListItem)
				Next
			Finally
				Dim enumerator As List(Of frmEmailDashboard3.EmailItem).Enumerator
				CType(enumerator, IDisposable).Dispose()
			End Try
		End Sub

		' Token: 0x06002A7C RID: 10876 RVA: 0x001A3530 File Offset: 0x001A1730
		Public Sub LoadFullMessage(selectedUID As Long, folderName As String)
			Try
				Dim uniqueId As UniqueId = New UniqueId(Convert.ToUInt32(selectedUID))
				Using imapClient As ImapClient = New ImapClient()
					imapClient.Connect(Me.strHost, Me.intPort, SecureSocketOptions.SslOnConnect, Nothing)
					imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
					Dim folder As IMailFolder = imapClient.GetFolder(folderName, Nothing)
					folder.Open(FolderAccess.[ReadOnly], Nothing)
					Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
					Me.lblSubject.Text = message.Subject
					Me.lblFrom.Text = message.From.ToString()
					Me.lblTo.Text = message.[To].ToString()
					Me.lblUid.Text = uniqueId.Id.ToString()
					Dim text As String = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody)
					Dim flag As Boolean = Not String.IsNullOrEmpty(message.HtmlBody)
					Dim flag2 As Boolean = flag
					If flag2 Then
						Me.WebBrowser1.Visible = True
						Me.rtbBody.Visible = False
						Dim flag3 As Boolean = Not text.Contains("<html")
						If flag3 Then
							text = "<html><body style='font-family:Segoe UI; font-size:12pt;'>" + text + "</body></html>"
						End If
						Me.WebBrowser1.DocumentText = text
					Else
						Me.rtbBody.Visible = True
						Me.WebBrowser1.Visible = False
						Me.rtbBody.Text = text
					End If
					Me.FlowLayoutAttachments.Controls.Clear()
					Dim flag4 As Boolean = False
					Try
						For Each mimeEntity As MimeEntity In message.Attachments
							Dim flag5 As Boolean = TypeOf mimeEntity Is MimePart
							If flag5 Then
								Dim mimePart As MimePart = CType(mimeEntity, MimePart)
								Dim button As Button = New Button()
								button.Text = mimePart.FileName
								button.AutoSize = True
								button.Tag = mimePart
								AddHandler button.Click, AddressOf Me.AttachmentButton_Click
								Me.FlowLayoutAttachments.Controls.Add(button)
								flag4 = True
							End If
						Next
					Finally
						Dim enumerator As IEnumerator(Of MimeEntity)
						If enumerator IsNot Nothing Then
							enumerator.Dispose()
						End If
					End Try
					Dim flag6 As Boolean = Not flag4
					If flag6 Then
						Dim label As Label = New Label()
						label.Text = "(No attachments)"
						label.AutoSize = True
						Me.FlowLayoutAttachments.Controls.Add(label)
					End If
					imapClient.Disconnect(True, Nothing)
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading full message: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A7D RID: 10877 RVA: 0x001A3864 File Offset: 0x001A1A64
		Private Sub ListViewEmails_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.pnlSend.Visible = False
			Try
				Dim flag As Boolean = Me.ListBoxNav.SelectedItem IsNot Nothing
				If flag Then
					Dim emailListItem As frmEmailDashboard3.EmailListItem = TryCast(Me.ListBoxNav.SelectedItem, frmEmailDashboard3.EmailListItem)
					Dim flag2 As Boolean = emailListItem IsNot Nothing
					If flag2 Then
						Dim uid As Long = emailListItem.UID
						Me.lblUid.Text = uid.ToString()
						Me.LoadFullMessage(Conversions.ToLong(Me.lblUid.Text), Me.currentFolderFullName)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error displaying email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A7E RID: 10878 RVA: 0x0019F200 File Offset: 0x0019D400
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

		' Token: 0x06002A7F RID: 10879 RVA: 0x001A3920 File Offset: 0x001A1B20
		Private Sub frmEmailDashboard3_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Me._imapClient IsNot Nothing AndAlso Me._imapClient.IsConnected
			If flag Then
				Me._imapClient.Disconnect(True, Nothing)
				Me._imapClient.Dispose()
			End If
		End Sub

		' Token: 0x06002A80 RID: 10880 RVA: 0x001A396C File Offset: 0x001A1B6C
		Private Sub lnkReply_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.attachmentList.Clear()
			Me.flowAttachments.Controls.Clear()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.currentFolderFullName)
				If flag Then
					MessageBox.Show("No folder selected.")
				Else
					Dim num As Long
					Dim flag2 As Boolean = String.IsNullOrWhiteSpace(Me.lblUid.Text) OrElse Not Long.TryParse(Me.lblUid.Text, num)
					If flag2 Then
						MessageBox.Show("No valid email UID selected.")
					Else
						Dim text As String = Me.lblFrom.Text
						Me.pnlSend.Visible = True
						Me.txtTo_view.Text = text
						Me.txtFrom.Text = Me.strEmailid
						Me.txtSubject.Text = "RE: " + Me.lblSubject.Text
						Using imapClient As ImapClient = New ImapClient()
							imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
							imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
							Dim folder As IMailFolder = imapClient.GetFolder(Me.currentFolderFullName, Nothing)
							folder.Open(FolderAccess.[ReadOnly], Nothing)
							Dim uniqueId As UniqueId = New UniqueId(CUInt(num))
							Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
							Dim text2 As String = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody)
							Dim flag3 As Boolean = text2.IndexOf("<html", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text2.IndexOf("<div", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text2.IndexOf("<p", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text2.IndexOf("<br", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text2.IndexOf("<body", StringComparison.OrdinalIgnoreCase) >= 0
							Dim flag4 As Boolean = flag3
							If flag4 Then
								Me.WebBrowser2.Visible = True
								Me.RichTextBox1.Visible = False
								Me.RichTextBox1.Text = text2
								Dim text3 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'>" + text2 + "</body></html>"
								Dim text4 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'><div id='replyArea'><br><br></div><hr><blockquote>" + text3 + "</blockquote></body></html>"
								Me.WebBrowser2.DocumentText = text4
							Else
								Me.WebBrowser2.Visible = False
								Me.RichTextBox1.Visible = True
								Me.RichTextBox1.Text = text2
							End If
							imapClient.Disconnect(True, Nothing)
						End Using
						Me.txtTo_view.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error replying to email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A81 RID: 10881 RVA: 0x001A3C78 File Offset: 0x001A1E78
		Private Sub lnkReplyAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.attachmentList.Clear()
			Me.flowAttachments.Controls.Clear()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.currentFolderFullName)
				If flag Then
					MessageBox.Show("No folder selected.")
				Else
					Dim num As Long
					Dim flag2 As Boolean = String.IsNullOrWhiteSpace(Me.lblUid.Text) OrElse Not Long.TryParse(Me.lblUid.Text, num)
					If flag2 Then
						MessageBox.Show("No valid email UID selected.")
					Else
						Me.pnlSend.Visible = True
						Me.txtFrom.Text = Me.strEmailid
						Me.txtSubject.Text = "RE: " + Me.lblSubject.Text
						Using imapClient As ImapClient = New ImapClient()
							imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
							imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
							Dim folder As IMailFolder = imapClient.GetFolder(Me.currentFolderFullName, Nothing)
							folder.Open(FolderAccess.[ReadOnly], Nothing)
							Dim uniqueId As UniqueId = New UniqueId(CUInt(num))
							Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
							Dim list As List(Of String) = New List(Of String)()
														Dim flag3 As Boolean = Not message.From.Mailboxes.Any(Function(mb As MailboxAddress) Operators.CompareString(mb.Address.ToLower(), Me.strEmailid.ToLower(), False) = 0)
							If flag3 Then
								list.AddRange(message.From.Mailboxes.Select(Function(mb As MailboxAddress) mb.Address))
							End If
							list.AddRange(message.[To].Mailboxes.Where(Function(mb As MailboxAddress) Operators.CompareString(mb.Address.ToLower(), Me.strEmailid.ToLower(), False) <> 0).Select(Function(mb As MailboxAddress) mb.Address))
							list.AddRange(message.Cc.Mailboxes.Where(Function(mb As MailboxAddress) Operators.CompareString(mb.Address.ToLower(), Me.strEmailid.ToLower(), False) <> 0).Select(Function(mb As MailboxAddress) mb.Address))
							Dim list5 As List(Of String) = list.Distinct().ToList()
							Me.txtTo_view.Text = String.Join(";", list5)
							Dim text As String = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody)
							Dim flag4 As Boolean = text.IndexOf("<html", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<div", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<p", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<br", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("<body", StringComparison.OrdinalIgnoreCase) >= 0
							Dim flag5 As Boolean = flag4
							If flag5 Then
								Me.WebBrowser2.Visible = True
								Me.RichTextBox1.Visible = False
								Dim text2 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'>" + text + "</body></html>"
								Dim text3 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'><div id='replyArea'><br><br></div><hr><blockquote>" + text2 + "</blockquote></body></html>"
								Me.WebBrowser2.DocumentText = text3
							Else
								Me.WebBrowser2.Visible = False
								Me.RichTextBox1.Visible = True
								Me.RichTextBox1.Text = text
							End If
							imapClient.Disconnect(True, Nothing)
						End Using
						Me.txtTo_view.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error replying to email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A82 RID: 10882 RVA: 0x001A4084 File Offset: 0x001A2284
		Private Sub lnkForward_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.attachmentList.Clear()
			Me.flowAttachments.Controls.Clear()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.currentFolderFullName)
				If flag Then
					MessageBox.Show("No folder selected.")
				Else
					Dim text2 As String
					Dim flag2 As Boolean
					If Not String.IsNullOrWhiteSpace(Me.lblUid.Text) Then
						Dim text As String = Me.lblUid.Text
						Dim num As Long = Conversions.ToLong(text2)
						Dim num2 As Integer = If(Long.TryParse(text, num), 1, 0)
						text2 = Conversions.ToString(num)
						flag2 = num2 = 0
					Else
						flag2 = True
					End If
					Dim flag3 As Boolean = flag2
					If flag3 Then
						MessageBox.Show("No valid email UID selected.")
					Else
						Me.pnlSend.Visible = True
						Me.txtTo_view.Text = ""
						Me.txtFrom.Text = Me.strEmailid
						Me.txtSubject.Text = "Fwd: " + Me.lblSubject.Text
						Using imapClient As ImapClient = New ImapClient()
							imapClient.Connect(Me.strHost, Me.intPort, True, Nothing)
							imapClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
							Dim folder As IMailFolder = imapClient.GetFolder(Me.currentFolderFullName, Nothing)
							folder.Open(FolderAccess.[ReadOnly], Nothing)
							Dim uniqueId As UniqueId = New UniqueId(Conversions.ToUInteger(text2))
							Dim message As MimeMessage = folder.GetMessage(uniqueId, Nothing, Nothing)
							Dim text3 As String = If((Not String.IsNullOrEmpty(message.HtmlBody)), message.HtmlBody, message.TextBody)
							Dim flag4 As Boolean = text3.IndexOf("<html", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text3.IndexOf("<div", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text3.IndexOf("<p", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text3.IndexOf("<br", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text3.IndexOf("<body", StringComparison.OrdinalIgnoreCase) >= 0
							Dim flag5 As Boolean = flag4
							If flag5 Then
								Me.WebBrowser2.Visible = True
								Me.RichTextBox1.Visible = False
								Me.RichTextBox1.Text = text3
								Dim text4 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'>" + text3 + "</body></html>"
								Dim text5 As String = "<html><body contenteditable='true' style='font-family:Segoe UI; font-size:12pt;'><div id='replyArea'><br><br></div><hr><blockquote>" + text4 + "</blockquote></body></html>"
								Me.WebBrowser2.DocumentText = text5
							Else
								Me.WebBrowser2.Visible = False
								Me.RichTextBox1.Visible = True
								Me.RichTextBox1.Text = text3
							End If
							imapClient.Disconnect(True, Nothing)
						End Using
						Me.txtTo_view.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error forwarding email: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A83 RID: 10883 RVA: 0x001A4398 File Offset: 0x001A2598
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.SendMail()
			Else
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002A84 RID: 10884 RVA: 0x001A43D0 File Offset: 0x001A25D0
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Public Sub SendMail()
			Try
				Dim mimeMessage As MimeMessage = New MimeMessage()
				mimeMessage.From.Add(New MailboxAddress(Me.strName, Me.strEmailid))
				Dim internetAddressList As InternetAddressList = New InternetAddressList()
				For Each text As String In Me.txtTo_view.Text.Split(New Char() { ","c, ";"c })
					Dim text2 As String = text.Trim()
					Dim flag As Boolean = Not String.IsNullOrEmpty(text2)
					If flag Then
						Dim mailboxAddress As MailboxAddress = Nothing
						Dim flag2 As Boolean = MailboxAddress.TryParse(text2, mailboxAddress)
						If flag2 Then
							internetAddressList.Add(mailboxAddress)
						Else
							MessageBox.Show("Invalid TO address skipped: " + text2)
						End If
					End If
				Next
				mimeMessage.[To].AddRange(internetAddressList)
				Dim internetAddressList2 As InternetAddressList = New InternetAddressList()
				For Each text3 As String In Me.txtCc.Text.Split(New Char() { ","c, ";"c })
					Dim text4 As String = text3.Trim()
					Dim flag3 As Boolean = Not String.IsNullOrEmpty(text4)
					If flag3 Then
						Try
							internetAddressList2.Add(MailboxAddress.Parse(text4))
						Catch ex As Exception
							MessageBox.Show("Invalid CC address skipped: " + text4)
						End Try
					End If
				Next
				mimeMessage.Cc.AddRange(internetAddressList2)
				Dim internetAddressList3 As InternetAddressList = New InternetAddressList()
				For Each text5 As String In Me.txtBcc.Text.Split(New Char() { ","c, ";"c })
					Dim text6 As String = text5.Trim()
					Dim flag4 As Boolean = Not String.IsNullOrEmpty(text6)
					If flag4 Then
						Try
							internetAddressList3.Add(MailboxAddress.Parse(text6))
						Catch ex2 As Exception
							MessageBox.Show("Invalid BCC address skipped: " + text6)
						End Try
					End If
				Next
				mimeMessage.Bcc.AddRange(internetAddressList3)
				mimeMessage.Subject = Me.txtSubject.Text
				Dim bodyBuilder As BodyBuilder = New BodyBuilder()
				bodyBuilder.HtmlBody = Me.WebBrowser2.Document.Body.InnerHtml
				Try
					For Each text7 As String In Me.attachmentList
						Dim flag5 As Boolean = File.Exists(text7)
						If flag5 Then
							bodyBuilder.Attachments.Add(text7)
						End If
					Next
				Finally
					Dim enumerator As List(Of String).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				mimeMessage.Body = bodyBuilder.ToMessageBody()
				Using smtpClient As SmtpClient = New SmtpClient()
					smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls, Nothing)
					smtpClient.Authenticate(Me.strEmailid, Me.strPassword, Nothing)
					smtpClient.Send(mimeMessage)
					smtpClient.Disconnect(True, Nothing)
				End Using
				MessageBox.Show("Mail sent successfully!")
				FileSystem.Reset()
			Catch ex3 As Exception
				MessageBox.Show("Failed to send mail: " + ex3.Message)
			End Try
		End Sub

		' Token: 0x06002A85 RID: 10885 RVA: 0x001A47C4 File Offset: 0x001A29C4
		Private Sub btnAttach_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Multiselect = True
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each text As String In openFileDialog.FileNames
					Dim flag2 As Boolean = Not Me.attachmentList.Contains(text)
					If flag2 Then
												Me.attachmentList.Add(text)
						Dim panel As Panel = New Panel()
						panel.AutoSize = True
						panel.BackColor = Color.LightGray
						panel.Margin = New Padding(3)
						panel.Padding = New Padding(2)
						panel.BorderStyle = BorderStyle.FixedSingle
						panel.Tag = text
						Dim label As Label = New Label()
						label.Text = Path.GetFileName(text)
						label.AutoSize = True
						label.Margin = New Padding(0, 3, 5, 3)
						Dim btn As New Button()
						btn.Text = "X"
						btn.Font = New Font("Segoe UI", 8F, FontStyle.Regular)
						btn.BackColor = Color.Red
						btn.ForeColor = Color.White
						btn.FlatStyle = FlatStyle.Flat
						btn.FlatAppearance.BorderSize = 0
						btn.Size = New Size(20, 20)
						btn.Margin = New Padding(0)
						btn.Tag = panel
						AddHandler btn.Click, Sub(s As Object, eargs As EventArgs)
							Dim panel2 As Panel = CType(CType(s, Button).Tag, Panel)
							Dim text2 As String = Conversions.ToString(panel2.Tag)
							Me.attachmentList.Remove(text2)
							Me.flowAttachments.Controls.Remove(panel2)
						End Sub
						panel.Controls.Add(label)
						panel.Controls.Add(btn)
						label.Location = New Point(5, 5)
						btn.Location = New Point(label.Right + 5, 3)
						Me.flowAttachments.Controls.Add(panel)
					End If
				Next
			End If
		End Sub

		' Token: 0x06002A86 RID: 10886 RVA: 0x001A4A04 File Offset: 0x001A2C04
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

		' Token: 0x06002A87 RID: 10887 RVA: 0x001A4BC0 File Offset: 0x001A2DC0
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Try
				Me.txtFrom.Text = Me.strEmailid
				Me.txtTo_view.Text = ""
				Me.txtCc.Text = ""
				Me.txtBcc.Text = ""
				Me.txtSubject.Text = ""
				Me.WebBrowser2.DocumentText = ""
				Me.RichTextBox1.Text = ""
				Me.WebBrowser2.Visible = False
				Me.RichTextBox1.Visible = True
				Me.pnlSend.Visible = True
				Me.txtTo_view.Focus()
				Me.attachmentList.Clear()
				Me.flowAttachments.Controls.Clear()
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.ToString())
			End Try
		End Sub

		' Token: 0x06002A88 RID: 10888 RVA: 0x001A4CD0 File Offset: 0x001A2ED0
		Private Sub txtTo_view_TextChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.strlistStatus, "", False) = 0
				If flag Then
					Me.lstSuggestions.Items.Clear()
					Dim text As String = Me.txtTo_view.Text.Split(New Char() { ";"c }).Last().Trim()
					Dim flag2 As Boolean = text.Length < 2
					If flag2 Then
						Me.lstSuggestions.Visible = False
					Else
						Dim list As List(Of String) = New List(Of String)()
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text2 As String = "SELECT DISTINCT TOP 10 RTRIM(FromName) FROM EmailCache WHERE FromName LIKE '%' + @prefix + '%'"
							Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@prefix", text)
								Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
									While sqlDataReader.Read()
										list.Add(sqlDataReader(0).ToString())
									End While
								End Using
							End Using
						End Using
						Dim flag3 As Boolean = list.Count = 1
						If flag3 Then
							Dim text3 As String = Me.txtTo_view.Text
							Dim list2 As List(Of String) = text3.Split(New Char() { ";"c }).ToList()
							Dim flag4 As Boolean = list2.Count > 0
							If flag4 Then
								' The following expression was wrapped in a checked-expression
								list2(list2.Count - 1) = list(0).Trim()
																Me.txtTo_view.Text = String.Join("; ", list2.Select(Function(p) p.Trim())) + "; "
								Me.txtTo_view.SelectionStart = Me.txtTo_view.Text.Length
							End If
							Me.lstSuggestions.Visible = False
						Else
							Dim flag5 As Boolean = list.Count > 1
							If flag5 Then
								Me.lstSuggestions.Items.AddRange(list.ToArray())
								Me.lstSuggestions.Visible = True
								Me.lstSuggestions.BringToFront()
								Me.lstSuggestions.Top = Me.txtTo_view.Bottom
								Me.lstSuggestions.Left = Me.txtTo_view.Left
								Me.lstSuggestions.Width = Me.txtTo_view.Width
							Else
								Me.lstSuggestions.Visible = False
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading email suggestions: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A89 RID: 10889 RVA: 0x001A4FFC File Offset: 0x001A31FC
		Private Sub lstSuggestions_DoubleClick(sender As Object, e As EventArgs)
			Me.strlistStatus = "double"
			Dim flag As Boolean = Operators.CompareString(Me.strinputype, "to", False) = 0
			If flag Then
				Dim flag2 As Boolean = Me.lstSuggestions.SelectedItem IsNot Nothing
				If flag2 Then
					Dim text As String = Me.lstSuggestions.SelectedItem.ToString()
					Dim list As List(Of String) = Me.txtTo_view.Text.Split(New Char() { ";"c }).ToList()
					Dim flag3 As Boolean = list.Count > 0
					If flag3 Then
						list(list.Count - 1) = text
					Else
						list.Add(text)
					End If
					Me.txtTo_view.Text = String.Join("; ", list.Select(Function(p) p.Trim())) + "; "
					Me.txtTo_view.SelectionStart = Me.txtTo_view.Text.Length
					Me.lstSuggestions.Visible = False
					Me.txtTo_view.Focus()
				End If
			Else
				Dim flag4 As Boolean = Operators.CompareString(Me.strinputype, "cc", False) = 0
				If flag4 Then
					Dim flag5 As Boolean = Me.lstSuggestions.SelectedItem IsNot Nothing
					If flag5 Then
						Dim text3 As String = Me.lstSuggestions.SelectedItem.ToString()
						Dim list2 As List(Of String) = Me.txtCc.Text.Split(New Char() { ";"c }).ToList()
						Dim flag6 As Boolean = list2.Count > 0
						If flag6 Then
							list2(list2.Count - 1) = text3
						Else
							list2.Add(text3)
						End If
						Me.txtCc.Text = String.Join("; ", list2.Select(Function(p) p.Trim())) + "; "
						Me.txtCc.SelectionStart = Me.txtCc.Text.Length
						Me.lstSuggestions.Visible = False
						Me.txtCc.Focus()
					End If
				Else
					Dim flag7 As Boolean = Operators.CompareString(Me.strinputype, "bcc", False) = 0
					If flag7 Then
						Dim flag8 As Boolean = Me.lstSuggestions.SelectedItem IsNot Nothing
						If flag8 Then
							Dim text5 As String = Me.lstSuggestions.SelectedItem.ToString()
							Dim list3 As List(Of String) = Me.txtBcc.Text.Split(New Char() { ";"c }).ToList()
							Dim flag9 As Boolean = list3.Count > 0
							If flag9 Then
								list3(list3.Count - 1) = text5
							Else
								list3.Add(text5)
							End If
							Me.txtBcc.Text = String.Join("; ", list3.Select(Function(p) p.Trim())) + "; "
							Me.txtBcc.SelectionStart = Me.txtBcc.Text.Length
							Me.lstSuggestions.Visible = False
							Me.txtBcc.Focus()
						End If
					End If
				End If
			End If
			Me.strlistStatus = ""
		End Sub

		' Token: 0x06002A8A RID: 10890 RVA: 0x001A5374 File Offset: 0x001A3574
		Private Sub txtTo_view_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.lstSuggestions.Visible AndAlso Me.lstSuggestions.Items.Count > 0
				If flag Then
					Dim keyCode As Keys = e.KeyCode
					If keyCode <= Keys.[Return] Then
						If keyCode = Keys.Tab OrElse keyCode = Keys.[Return] Then
							Dim flag2 As Boolean = Me.lstSuggestions.SelectedIndex >= 0
							If flag2 Then
								Me.strinputype = "to"
								Me.lstSuggestions_DoubleClick(Nothing, Nothing)
								e.Handled = True
							End If
						End If
					ElseIf keyCode <> Keys.Escape Then
						If keyCode <> Keys.Up Then
							If keyCode = Keys.Down Then
								Dim flag3 As Boolean = Me.lstSuggestions.SelectedIndex < Me.lstSuggestions.Items.Count - 1
								If flag3 Then
									Dim lstSuggestions As ListBox = Me.lstSuggestions
									Dim listBox As ListBox = lstSuggestions
									lstSuggestions.SelectedIndex = listBox.SelectedIndex + 1
									e.Handled = True
								End If
							End If
						Else
							Dim flag4 As Boolean = Me.lstSuggestions.SelectedIndex > 0
							If flag4 Then
								Dim lstSuggestions2 As ListBox = Me.lstSuggestions
								Dim listBox As ListBox = lstSuggestions2
								lstSuggestions2.SelectedIndex = listBox.SelectedIndex - 1
								e.Handled = True
							End If
						End If
					Else
						Me.lstSuggestions.Visible = False
					End If
				Else
					Dim flag5 As Boolean = e.KeyCode = Keys.[Return]
					If flag5 Then
						Dim flag6 As Boolean = Me.txtTo_view.Text.EndsWith(";")
						If flag6 Then
							e.Handled = True
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Key down handling error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A8B RID: 10891 RVA: 0x001A5534 File Offset: 0x001A3734
		Private Sub lstSuggestions_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.lstSuggestions_DoubleClick(RuntimeHelpers.GetObjectValue(sender), e)
				Me.txtTo_view.Focus()
			End If
		End Sub

		' Token: 0x06002A8C RID: 10892 RVA: 0x0001B6DC File Offset: 0x000198DC
		Private Sub frmEmailDashboard3_Click(sender As Object, e As EventArgs)
			Me.lstSuggestions.Visible = False
		End Sub

		' Token: 0x06002A8D RID: 10893 RVA: 0x001A556C File Offset: 0x001A376C
		Private Sub txtCc_TextChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.strlistStatus, "", False) = 0
				If flag Then
					Me.lstSuggestions.Items.Clear()
					Dim text As String = Me.txtCc.Text.Split(New Char() { ";"c }).Last().Trim()
					Dim flag2 As Boolean = text.Length < 2
					If flag2 Then
						Me.lstSuggestions.Visible = False
					Else
						Dim list As List(Of String) = New List(Of String)()
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text2 As String = "SELECT DISTINCT TOP 10 RTRIM(FromName) FROM EmailCache WHERE FromName LIKE '%' + @prefix + '%'"
							Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@prefix", text)
								Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
									While sqlDataReader.Read()
										list.Add(sqlDataReader(0).ToString())
									End While
								End Using
							End Using
						End Using
						Dim flag3 As Boolean = list.Count = 1
						If flag3 Then
							Dim text3 As String = Me.txtCc.Text
							Dim list2 As List(Of String) = text3.Split(New Char() { ";"c }).ToList()
							Dim flag4 As Boolean = list2.Count > 0
							If flag4 Then
								' The following expression was wrapped in a checked-expression
								list2(list2.Count - 1) = list(0).Trim()
																Me.txtCc.Text = String.Join("; ", list2.Select(Function(p) p.Trim())) + "; "
								Me.txtCc.SelectionStart = Me.txtCc.Text.Length
							End If
							Me.lstSuggestions.Visible = False
						Else
							Dim flag5 As Boolean = list.Count > 1
							If flag5 Then
								Me.lstSuggestions.Items.AddRange(list.ToArray())
								Me.lstSuggestions.Visible = True
								Me.lstSuggestions.BringToFront()
								Me.lstSuggestions.Top = Me.txtCc.Bottom
								Me.lstSuggestions.Left = Me.txtCc.Left
								Me.lstSuggestions.Width = Me.txtCc.Width
							Else
								Me.lstSuggestions.Visible = False
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading email suggestions: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A8E RID: 10894 RVA: 0x001A5898 File Offset: 0x001A3A98
		Private Sub txtBcc_TextChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.strlistStatus, "", False) = 0
				If flag Then
					Me.lstSuggestions.Items.Clear()
					Dim text As String = Me.txtBcc.Text.Split(New Char() { ";"c }).Last().Trim()
					Dim flag2 As Boolean = text.Length < 2
					If flag2 Then
						Me.lstSuggestions.Visible = False
					Else
						Dim list As List(Of String) = New List(Of String)()
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text2 As String = "SELECT DISTINCT TOP 10 RTRIM(FromName) FROM EmailCache WHERE FromName LIKE '%' + @prefix + '%'"
							Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@prefix", text)
								Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
									While sqlDataReader.Read()
										list.Add(sqlDataReader(0).ToString())
									End While
								End Using
							End Using
						End Using
						Dim flag3 As Boolean = list.Count = 1
						If flag3 Then
							Dim text3 As String = Me.txtBcc.Text
							Dim list2 As List(Of String) = text3.Split(New Char() { ";"c }).ToList()
							Dim flag4 As Boolean = list2.Count > 0
							If flag4 Then
								' The following expression was wrapped in a checked-expression
								list2(list2.Count - 1) = list(0).Trim()
																Me.txtBcc.Text = String.Join("; ", list2.Select(Function(p) p.Trim())) + "; "
								Me.txtBcc.SelectionStart = Me.txtBcc.Text.Length
							End If
							Me.lstSuggestions.Visible = False
						Else
							Dim flag5 As Boolean = list.Count > 1
							If flag5 Then
								Me.lstSuggestions.Items.AddRange(list.ToArray())
								Me.lstSuggestions.Visible = True
								Me.lstSuggestions.BringToFront()
								Me.lstSuggestions.Top = Me.txtBcc.Bottom
								Me.lstSuggestions.Left = Me.txtBcc.Left
								Me.lstSuggestions.Width = Me.txtBcc.Width
							Else
								Me.lstSuggestions.Visible = False
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error loading email suggestions: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A8F RID: 10895 RVA: 0x001A5BC4 File Offset: 0x001A3DC4
		Private Sub txtCc_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.lstSuggestions.Visible AndAlso Me.lstSuggestions.Items.Count > 0
				If flag Then
					Dim keyCode As Keys = e.KeyCode
					If keyCode <= Keys.[Return] Then
						If keyCode = Keys.Tab OrElse keyCode = Keys.[Return] Then
							Dim flag2 As Boolean = Me.lstSuggestions.SelectedIndex >= 0
							If flag2 Then
								Me.strinputype = "cc"
								Me.lstSuggestions_DoubleClick(Nothing, Nothing)
								e.Handled = True
							End If
						End If
					ElseIf keyCode <> Keys.Escape Then
						If keyCode <> Keys.Up Then
							If keyCode = Keys.Down Then
								Dim flag3 As Boolean = Me.lstSuggestions.SelectedIndex < Me.lstSuggestions.Items.Count - 1
								If flag3 Then
									Dim lstSuggestions As ListBox = Me.lstSuggestions
									Dim listBox As ListBox = lstSuggestions
									lstSuggestions.SelectedIndex = listBox.SelectedIndex + 1
									e.Handled = True
								End If
							End If
						Else
							Dim flag4 As Boolean = Me.lstSuggestions.SelectedIndex > 0
							If flag4 Then
								Dim lstSuggestions2 As ListBox = Me.lstSuggestions
								Dim listBox As ListBox = lstSuggestions2
								lstSuggestions2.SelectedIndex = listBox.SelectedIndex - 1
								e.Handled = True
							End If
						End If
					Else
						Me.lstSuggestions.Visible = False
					End If
				Else
					Dim flag5 As Boolean = e.KeyCode = Keys.[Return]
					If flag5 Then
						Dim flag6 As Boolean = Me.txtCc.Text.EndsWith(";")
						If flag6 Then
							e.Handled = True
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Key down handling error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002A90 RID: 10896 RVA: 0x001A5D84 File Offset: 0x001A3F84
		Private Sub txtBcc_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.lstSuggestions.Visible AndAlso Me.lstSuggestions.Items.Count > 0
				If flag Then
					Dim keyCode As Keys = e.KeyCode
					If keyCode <= Keys.[Return] Then
						If keyCode = Keys.Tab OrElse keyCode = Keys.[Return] Then
							Dim flag2 As Boolean = Me.lstSuggestions.SelectedIndex >= 0
							If flag2 Then
								Me.strinputype = "bcc"
								Me.lstSuggestions_DoubleClick(Nothing, Nothing)
								e.Handled = True
							End If
						End If
					ElseIf keyCode <> Keys.Escape Then
						If keyCode <> Keys.Up Then
							If keyCode = Keys.Down Then
								Dim flag3 As Boolean = Me.lstSuggestions.SelectedIndex < Me.lstSuggestions.Items.Count - 1
								If flag3 Then
									Dim lstSuggestions As ListBox = Me.lstSuggestions
									Dim listBox As ListBox = lstSuggestions
									lstSuggestions.SelectedIndex = listBox.SelectedIndex + 1
									e.Handled = True
								End If
							End If
						Else
							Dim flag4 As Boolean = Me.lstSuggestions.SelectedIndex > 0
							If flag4 Then
								Dim lstSuggestions2 As ListBox = Me.lstSuggestions
								Dim listBox As ListBox = lstSuggestions2
								lstSuggestions2.SelectedIndex = listBox.SelectedIndex - 1
								e.Handled = True
							End If
						End If
					Else
						Me.lstSuggestions.Visible = False
					End If
				Else
					Dim flag5 As Boolean = e.KeyCode = Keys.[Return]
					If flag5 Then
						Dim flag6 As Boolean = Me.txtBcc.Text.EndsWith(";")
						If flag6 Then
							e.Handled = True
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Key down handling error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0400121E RID: 4638
		Private attachmentPath As String

		' Token: 0x0400121F RID: 4639
		Private confirmedEmails As List(Of String)

		' Token: 0x04001220 RID: 4640
		Private attachmentList As List(Of String)

		' Token: 0x04001221 RID: 4641
		Private strHost As String

		' Token: 0x04001222 RID: 4642
		Private intPort As Integer

		' Token: 0x04001223 RID: 4643
		Private strName As String

		' Token: 0x04001224 RID: 4644
		Private strEmailid As String

		' Token: 0x04001225 RID: 4645
		Private strPassword As String

		' Token: 0x04001226 RID: 4646
		Private currentFolderFullName As String

		' Token: 0x04001227 RID: 4647
		Private _imapClient As ImapClient

		' Token: 0x04001228 RID: 4648
		Private currentFolderEmails As List(Of frmEmailDashboard3.EmailItem)

		' Token: 0x04001229 RID: 4649
		Private currentPageIndex As Integer

		' Token: 0x0400122A RID: 4650
		Private pageSize As Integer

		' Token: 0x0400122B RID: 4651
		Private strinputype As String

		' Token: 0x0400122C RID: 4652
		Private emailDisplayList As List(Of frmEmailDashboard3.EmailItem)

		' Token: 0x0400122D RID: 4653
		Private strlistStatus As String

		' Token: 0x02000105 RID: 261
		Public Class EmailItem
			' Token: 0x1700108E RID: 4238
			' (get) Token: 0x06002A95 RID: 10901 RVA: 0x0001B6EC File Offset: 0x000198EC
			' (set) Token: 0x06002A96 RID: 10902 RVA: 0x0001B6F6 File Offset: 0x000198F6
			Public Property UID As Long

			' Token: 0x1700108F RID: 4239
			' (get) Token: 0x06002A97 RID: 10903 RVA: 0x0001B6FF File Offset: 0x000198FF
			' (set) Token: 0x06002A98 RID: 10904 RVA: 0x0001B709 File Offset: 0x00019909
			Public Property Subject As String

			' Token: 0x17001090 RID: 4240
			' (get) Token: 0x06002A99 RID: 10905 RVA: 0x0001B712 File Offset: 0x00019912
			' (set) Token: 0x06002A9A RID: 10906 RVA: 0x0001B71C File Offset: 0x0001991C
			Public Property From As String

			' Token: 0x17001091 RID: 4241
			' (get) Token: 0x06002A9B RID: 10907 RVA: 0x0001B725 File Offset: 0x00019925
			' (set) Token: 0x06002A9C RID: 10908 RVA: 0x0001B72F File Offset: 0x0001992F
			Public Property DateReceived As String

			' Token: 0x17001092 RID: 4242
			' (get) Token: 0x06002A9D RID: 10909 RVA: 0x0001B738 File Offset: 0x00019938
			' (set) Token: 0x06002A9E RID: 10910 RVA: 0x0001B742 File Offset: 0x00019942
			Public Property Body As String

			' Token: 0x17001093 RID: 4243
			' (get) Token: 0x06002A9F RID: 10911 RVA: 0x0001B74B File Offset: 0x0001994B
			' (set) Token: 0x06002AA0 RID: 10912 RVA: 0x0001B755 File Offset: 0x00019955
			Public Property IsHtml As Boolean
		End Class

		' Token: 0x02000106 RID: 262
		Public Class EmailListItem
			' Token: 0x17001094 RID: 4244
			' (get) Token: 0x06002AA2 RID: 10914 RVA: 0x0001B75E File Offset: 0x0001995E
			' (set) Token: 0x06002AA3 RID: 10915 RVA: 0x0001B768 File Offset: 0x00019968
			Public Property UID As Long

			' Token: 0x17001095 RID: 4245
			' (get) Token: 0x06002AA4 RID: 10916 RVA: 0x0001B771 File Offset: 0x00019971
			' (set) Token: 0x06002AA5 RID: 10917 RVA: 0x0001B77B File Offset: 0x0001997B
			Public Property DisplayText As String

			' Token: 0x06002AA6 RID: 10918 RVA: 0x001A5FAC File Offset: 0x001A41AC
			Public Overrides Function ToString() As String
				Return Me.DisplayText
			End Function
		End Class
	End Class
End Namespace
