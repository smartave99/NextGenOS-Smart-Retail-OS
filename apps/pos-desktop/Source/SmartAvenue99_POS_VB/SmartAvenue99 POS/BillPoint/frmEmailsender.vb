Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C3 RID: 1219
	<DesignerGenerated()>
	Public Partial Class frmEmailsender
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F490 RID: 62608 RVA: 0x009299B0 File Offset: 0x00927BB0
		Public Sub New()
			AddHandler MyBase.FormClosed, AddressOf Me.frmMain_FormClosed
			AddHandler MyBase.Load, AddressOf Me.frmMain_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmailsender_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D95 RID: 23957
		' (get) Token: 0x0600F493 RID: 62611 RVA: 0x0006B0CD File Offset: 0x000692CD
		' (set) Token: 0x0600F494 RID: 62612 RVA: 0x0092BF6C File Offset: 0x0092A16C
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

		' Token: 0x17005D96 RID: 23958
		' (get) Token: 0x0600F495 RID: 62613 RVA: 0x0006B0D7 File Offset: 0x000692D7
		' (set) Token: 0x0600F496 RID: 62614 RVA: 0x0092BFB0 File Offset: 0x0092A1B0
		Private _Timerdate As Timer
		Friend Overridable Property Timerdate As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timerdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timerdate
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timerdate = value
				timer = Me._Timerdate
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D97 RID: 23959
		' (get) Token: 0x0600F497 RID: 62615 RVA: 0x0006B0E1 File Offset: 0x000692E1
		' (set) Token: 0x0600F498 RID: 62616 RVA: 0x0006B0EB File Offset: 0x000692EB
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17005D98 RID: 23960
		' (get) Token: 0x0600F499 RID: 62617 RVA: 0x0006B0F4 File Offset: 0x000692F4
		' (set) Token: 0x0600F49A RID: 62618 RVA: 0x0092BFF4 File Offset: 0x0092A1F4
		Private _btnClear As Button
		Friend Overridable Property btnClear As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim button As Button = Me._btnClear
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClear = value
				button = Me._btnClear
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D99 RID: 23961
		' (get) Token: 0x0600F49B RID: 62619 RVA: 0x0006B0FE File Offset: 0x000692FE
		' (set) Token: 0x0600F49C RID: 62620 RVA: 0x0006B108 File Offset: 0x00069308
		Friend Overridable Property tbTo As TextBox

		' Token: 0x17005D9A RID: 23962
		' (get) Token: 0x0600F49D RID: 62621 RVA: 0x0006B111 File Offset: 0x00069311
		' (set) Token: 0x0600F49E RID: 62622 RVA: 0x0006B11B File Offset: 0x0006931B
		Friend Overridable Property tbUname As TextBox

		' Token: 0x17005D9B RID: 23963
		' (get) Token: 0x0600F49F RID: 62623 RVA: 0x0006B124 File Offset: 0x00069324
		' (set) Token: 0x0600F4A0 RID: 62624 RVA: 0x0006B12E File Offset: 0x0006932E
		Friend Overridable Property tbPass As TextBox

		' Token: 0x17005D9C RID: 23964
		' (get) Token: 0x0600F4A1 RID: 62625 RVA: 0x0006B137 File Offset: 0x00069337
		' (set) Token: 0x0600F4A2 RID: 62626 RVA: 0x0006B141 File Offset: 0x00069341
		Friend Overridable Property tbCc As TextBox

		' Token: 0x17005D9D RID: 23965
		' (get) Token: 0x0600F4A3 RID: 62627 RVA: 0x0006B14A File Offset: 0x0006934A
		' (set) Token: 0x0600F4A4 RID: 62628 RVA: 0x0006B154 File Offset: 0x00069354
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D9E RID: 23966
		' (get) Token: 0x0600F4A5 RID: 62629 RVA: 0x0006B15D File Offset: 0x0006935D
		' (set) Token: 0x0600F4A6 RID: 62630 RVA: 0x0006B167 File Offset: 0x00069367
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D9F RID: 23967
		' (get) Token: 0x0600F4A7 RID: 62631 RVA: 0x0006B170 File Offset: 0x00069370
		' (set) Token: 0x0600F4A8 RID: 62632 RVA: 0x0006B17A File Offset: 0x0006937A
		Friend Overridable Property Label3 As Label

		' Token: 0x17005DA0 RID: 23968
		' (get) Token: 0x0600F4A9 RID: 62633 RVA: 0x0006B183 File Offset: 0x00069383
		' (set) Token: 0x0600F4AA RID: 62634 RVA: 0x0006B18D File Offset: 0x0006938D
		Friend Overridable Property Label4 As Label

		' Token: 0x17005DA1 RID: 23969
		' (get) Token: 0x0600F4AB RID: 62635 RVA: 0x0006B196 File Offset: 0x00069396
		' (set) Token: 0x0600F4AC RID: 62636 RVA: 0x0006B1A0 File Offset: 0x000693A0
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005DA2 RID: 23970
		' (get) Token: 0x0600F4AD RID: 62637 RVA: 0x0006B1A9 File Offset: 0x000693A9
		' (set) Token: 0x0600F4AE RID: 62638 RVA: 0x0006B1B3 File Offset: 0x000693B3
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005DA3 RID: 23971
		' (get) Token: 0x0600F4AF RID: 62639 RVA: 0x0006B1BC File Offset: 0x000693BC
		' (set) Token: 0x0600F4B0 RID: 62640 RVA: 0x0006B1C6 File Offset: 0x000693C6
		Friend Overridable Property tbSubject As TextBox

		' Token: 0x17005DA4 RID: 23972
		' (get) Token: 0x0600F4B1 RID: 62641 RVA: 0x0006B1CF File Offset: 0x000693CF
		' (set) Token: 0x0600F4B2 RID: 62642 RVA: 0x0006B1D9 File Offset: 0x000693D9
		Friend Overridable Property Label6 As Label

		' Token: 0x17005DA5 RID: 23973
		' (get) Token: 0x0600F4B3 RID: 62643 RVA: 0x0006B1E2 File Offset: 0x000693E2
		' (set) Token: 0x0600F4B4 RID: 62644 RVA: 0x0006B1EC File Offset: 0x000693EC
		Friend Overridable Property Label7 As Label

		' Token: 0x17005DA6 RID: 23974
		' (get) Token: 0x0600F4B5 RID: 62645 RVA: 0x0006B1F5 File Offset: 0x000693F5
		' (set) Token: 0x0600F4B6 RID: 62646 RVA: 0x0006B1FF File Offset: 0x000693FF
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17005DA7 RID: 23975
		' (get) Token: 0x0600F4B7 RID: 62647 RVA: 0x0006B208 File Offset: 0x00069408
		' (set) Token: 0x0600F4B8 RID: 62648 RVA: 0x0006B212 File Offset: 0x00069412
		Friend Overridable Property lblDate As Label

		' Token: 0x17005DA8 RID: 23976
		' (get) Token: 0x0600F4B9 RID: 62649 RVA: 0x0006B21B File Offset: 0x0006941B
		' (set) Token: 0x0600F4BA RID: 62650 RVA: 0x0006B225 File Offset: 0x00069425
		Friend Overridable Property lblTime As Label

		' Token: 0x17005DA9 RID: 23977
		' (get) Token: 0x0600F4BB RID: 62651 RVA: 0x0006B22E File Offset: 0x0006942E
		' (set) Token: 0x0600F4BC RID: 62652 RVA: 0x0092C038 File Offset: 0x0092A238
		Private _TimerProgressbar As Timer
		Friend Overridable Property TimerProgressbar As Timer
			<CompilerGenerated()>
			Get
				Return Me._TimerProgressbar
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.TimerProgressbar_Tick
				Dim timer As Timer = Me._TimerProgressbar
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._TimerProgressbar = value
				timer = Me._TimerProgressbar
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DAA RID: 23978
		' (get) Token: 0x0600F4BD RID: 62653 RVA: 0x0006B238 File Offset: 0x00069438
		' (set) Token: 0x0600F4BE RID: 62654 RVA: 0x0006B242 File Offset: 0x00069442
		Friend Overridable Property tbBody As RichTextBox

		' Token: 0x17005DAB RID: 23979
		' (get) Token: 0x0600F4BF RID: 62655 RVA: 0x0006B24B File Offset: 0x0006944B
		' (set) Token: 0x0600F4C0 RID: 62656 RVA: 0x0006B255 File Offset: 0x00069455
		Friend Overridable Property FontDialog1 As FontDialog

		' Token: 0x17005DAC RID: 23980
		' (get) Token: 0x0600F4C1 RID: 62657 RVA: 0x0006B25E File Offset: 0x0006945E
		' (set) Token: 0x0600F4C2 RID: 62658 RVA: 0x0006B268 File Offset: 0x00069468
		Friend Overridable Property lblStatus As Label

		' Token: 0x17005DAD RID: 23981
		' (get) Token: 0x0600F4C3 RID: 62659 RVA: 0x0006B271 File Offset: 0x00069471
		' (set) Token: 0x0600F4C4 RID: 62660 RVA: 0x0092C07C File Offset: 0x0092A27C
		Private _OpenFileDialog1 As OpenFileDialog
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog
			<CompilerGenerated()>
			Get
				Return Me._OpenFileDialog1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As OpenFileDialog)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.OpenFileDialog1_FileOk
				Dim openFileDialog As OpenFileDialog = Me._OpenFileDialog1
				If openFileDialog IsNot Nothing Then
					RemoveHandler openFileDialog.FileOk, cancelEventHandler
				End If
				Me._OpenFileDialog1 = value
				openFileDialog = Me._OpenFileDialog1
				If openFileDialog IsNot Nothing Then
					AddHandler openFileDialog.FileOk, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DAE RID: 23982
		' (get) Token: 0x0600F4C5 RID: 62661 RVA: 0x0006B27B File Offset: 0x0006947B
		' (set) Token: 0x0600F4C6 RID: 62662 RVA: 0x0006B285 File Offset: 0x00069485
		Friend Overridable Property cbEnd As ComboBox

		' Token: 0x17005DAF RID: 23983
		' (get) Token: 0x0600F4C7 RID: 62663 RVA: 0x0006B28E File Offset: 0x0006948E
		' (set) Token: 0x0600F4C8 RID: 62664 RVA: 0x0006B298 File Offset: 0x00069498
		Friend Overridable Property cbEndcc As ComboBox

		' Token: 0x17005DB0 RID: 23984
		' (get) Token: 0x0600F4C9 RID: 62665 RVA: 0x0006B2A1 File Offset: 0x000694A1
		' (set) Token: 0x0600F4CA RID: 62666 RVA: 0x0006B2AB File Offset: 0x000694AB
		Friend Overridable Property lblAttach As Label

		' Token: 0x17005DB1 RID: 23985
		' (get) Token: 0x0600F4CB RID: 62667 RVA: 0x0006B2B4 File Offset: 0x000694B4
		' (set) Token: 0x0600F4CC RID: 62668 RVA: 0x0092C0C0 File Offset: 0x0092A2C0
		Private _btnBrowse As Button
		Friend Overridable Property btnBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim button As Button = Me._btnBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBrowse = value
				button = Me._btnBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DB2 RID: 23986
		' (get) Token: 0x0600F4CD RID: 62669 RVA: 0x0006B2BE File Offset: 0x000694BE
		' (set) Token: 0x0600F4CE RID: 62670 RVA: 0x0006B2C8 File Offset: 0x000694C8
		Friend Overridable Property Label8 As Label

		' Token: 0x17005DB3 RID: 23987
		' (get) Token: 0x0600F4CF RID: 62671 RVA: 0x0006B2D1 File Offset: 0x000694D1
		' (set) Token: 0x0600F4D0 RID: 62672 RVA: 0x0092C104 File Offset: 0x0092A304
		Private _OpenFileDialog2 As OpenFileDialog
		Friend Overridable Property OpenFileDialog2 As OpenFileDialog
			<CompilerGenerated()>
			Get
				Return Me._OpenFileDialog2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As OpenFileDialog)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.OpenFileDialog2_FileOk
				Dim openFileDialog As OpenFileDialog = Me._OpenFileDialog2
				If openFileDialog IsNot Nothing Then
					RemoveHandler openFileDialog.FileOk, cancelEventHandler
				End If
				Me._OpenFileDialog2 = value
				openFileDialog = Me._OpenFileDialog2
				If openFileDialog IsNot Nothing Then
					AddHandler openFileDialog.FileOk, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DB4 RID: 23988
		' (get) Token: 0x0600F4D1 RID: 62673 RVA: 0x0006B2DB File Offset: 0x000694DB
		' (set) Token: 0x0600F4D2 RID: 62674 RVA: 0x0006B2E5 File Offset: 0x000694E5
		Friend Overridable Property lblerroruser As Label

		' Token: 0x17005DB5 RID: 23989
		' (get) Token: 0x0600F4D3 RID: 62675 RVA: 0x0006B2EE File Offset: 0x000694EE
		' (set) Token: 0x0600F4D4 RID: 62676 RVA: 0x0006B2F8 File Offset: 0x000694F8
		Friend Overridable Property lblerrorsubject As Label

		' Token: 0x17005DB6 RID: 23990
		' (get) Token: 0x0600F4D5 RID: 62677 RVA: 0x0006B301 File Offset: 0x00069501
		' (set) Token: 0x0600F4D6 RID: 62678 RVA: 0x0006B30B File Offset: 0x0006950B
		Friend Overridable Property lblerrorcc As Label

		' Token: 0x17005DB7 RID: 23991
		' (get) Token: 0x0600F4D7 RID: 62679 RVA: 0x0006B314 File Offset: 0x00069514
		' (set) Token: 0x0600F4D8 RID: 62680 RVA: 0x0006B31E File Offset: 0x0006951E
		Friend Overridable Property lblerrorto As Label

		' Token: 0x17005DB8 RID: 23992
		' (get) Token: 0x0600F4D9 RID: 62681 RVA: 0x0006B327 File Offset: 0x00069527
		' (set) Token: 0x0600F4DA RID: 62682 RVA: 0x0006B331 File Offset: 0x00069531
		Friend Overridable Property ToolStrip1 As ToolStrip

		' Token: 0x17005DB9 RID: 23993
		' (get) Token: 0x0600F4DB RID: 62683 RVA: 0x0006B33A File Offset: 0x0006953A
		' (set) Token: 0x0600F4DC RID: 62684 RVA: 0x0092C148 File Offset: 0x0092A348
		Private _tbrFont As ToolStripButton
		Friend Overridable Property tbrFont As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrFont
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrFont_Click
				Dim toolStripButton As ToolStripButton = Me._tbrFont
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrFont = value
				toolStripButton = Me._tbrFont
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DBA RID: 23994
		' (get) Token: 0x0600F4DD RID: 62685 RVA: 0x0006B344 File Offset: 0x00069544
		' (set) Token: 0x0600F4DE RID: 62686 RVA: 0x0006B34E File Offset: 0x0006954E
		Friend Overridable Property ToolStripSeparator4 As ToolStripSeparator

		' Token: 0x17005DBB RID: 23995
		' (get) Token: 0x0600F4DF RID: 62687 RVA: 0x0006B357 File Offset: 0x00069557
		' (set) Token: 0x0600F4E0 RID: 62688 RVA: 0x0092C18C File Offset: 0x0092A38C
		Private _tbrLeft As ToolStripButton
		Friend Overridable Property tbrLeft As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrLeft
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrLeft_Click
				Dim toolStripButton As ToolStripButton = Me._tbrLeft
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrLeft = value
				toolStripButton = Me._tbrLeft
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DBC RID: 23996
		' (get) Token: 0x0600F4E1 RID: 62689 RVA: 0x0006B361 File Offset: 0x00069561
		' (set) Token: 0x0600F4E2 RID: 62690 RVA: 0x0092C1D0 File Offset: 0x0092A3D0
		Private _tbrCenter As ToolStripButton
		Friend Overridable Property tbrCenter As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrCenter
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrCenter_Click
				Dim toolStripButton As ToolStripButton = Me._tbrCenter
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrCenter = value
				toolStripButton = Me._tbrCenter
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DBD RID: 23997
		' (get) Token: 0x0600F4E3 RID: 62691 RVA: 0x0006B36B File Offset: 0x0006956B
		' (set) Token: 0x0600F4E4 RID: 62692 RVA: 0x0092C214 File Offset: 0x0092A414
		Private _tbrRight As ToolStripButton
		Friend Overridable Property tbrRight As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrRight
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrRight_Click
				Dim toolStripButton As ToolStripButton = Me._tbrRight
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrRight = value
				toolStripButton = Me._tbrRight
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DBE RID: 23998
		' (get) Token: 0x0600F4E5 RID: 62693 RVA: 0x0006B375 File Offset: 0x00069575
		' (set) Token: 0x0600F4E6 RID: 62694 RVA: 0x0006B37F File Offset: 0x0006957F
		Friend Overridable Property ToolStripSeparator2 As ToolStripSeparator

		' Token: 0x17005DBF RID: 23999
		' (get) Token: 0x0600F4E7 RID: 62695 RVA: 0x0006B388 File Offset: 0x00069588
		' (set) Token: 0x0600F4E8 RID: 62696 RVA: 0x0092C258 File Offset: 0x0092A458
		Private _tbrBold As ToolStripButton
		Friend Overridable Property tbrBold As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrBold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrBold_Click
				Dim toolStripButton As ToolStripButton = Me._tbrBold
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrBold = value
				toolStripButton = Me._tbrBold
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC0 RID: 24000
		' (get) Token: 0x0600F4E9 RID: 62697 RVA: 0x0006B392 File Offset: 0x00069592
		' (set) Token: 0x0600F4EA RID: 62698 RVA: 0x0092C29C File Offset: 0x0092A49C
		Private _tbrItalic As ToolStripButton
		Friend Overridable Property tbrItalic As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrItalic
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrItalic_Click
				Dim toolStripButton As ToolStripButton = Me._tbrItalic
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrItalic = value
				toolStripButton = Me._tbrItalic
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC1 RID: 24001
		' (get) Token: 0x0600F4EB RID: 62699 RVA: 0x0006B39C File Offset: 0x0006959C
		' (set) Token: 0x0600F4EC RID: 62700 RVA: 0x0092C2E0 File Offset: 0x0092A4E0
		Private _tbrUnderline As ToolStripButton
		Friend Overridable Property tbrUnderline As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrUnderline
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrUnderline_Click
				Dim toolStripButton As ToolStripButton = Me._tbrUnderline
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrUnderline = value
				toolStripButton = Me._tbrUnderline
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC2 RID: 24002
		' (get) Token: 0x0600F4ED RID: 62701 RVA: 0x0006B3A6 File Offset: 0x000695A6
		' (set) Token: 0x0600F4EE RID: 62702 RVA: 0x0006B3B0 File Offset: 0x000695B0
		Friend Overridable Property ToolStripSeparator3 As ToolStripSeparator

		' Token: 0x17005DC3 RID: 24003
		' (get) Token: 0x0600F4EF RID: 62703 RVA: 0x0006B3B9 File Offset: 0x000695B9
		' (set) Token: 0x0600F4F0 RID: 62704 RVA: 0x0092C324 File Offset: 0x0092A524
		Private _tbrOpen As ToolStripButton
		Friend Overridable Property tbrOpen As ToolStripButton
			<CompilerGenerated()>
			Get
				Return Me._tbrOpen
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripButton)
				Dim eventHandler As EventHandler = AddressOf Me.tbrOpen_Click
				Dim toolStripButton As ToolStripButton = Me._tbrOpen
				If toolStripButton IsNot Nothing Then
					RemoveHandler toolStripButton.Click, eventHandler
				End If
				Me._tbrOpen = value
				toolStripButton = Me._tbrOpen
				If toolStripButton IsNot Nothing Then
					AddHandler toolStripButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC4 RID: 24004
		' (get) Token: 0x0600F4F1 RID: 62705 RVA: 0x0006B3C3 File Offset: 0x000695C3
		' (set) Token: 0x0600F4F2 RID: 62706 RVA: 0x0006B3CD File Offset: 0x000695CD
		Friend Overridable Property lblerrortoend As Label

		' Token: 0x17005DC5 RID: 24005
		' (get) Token: 0x0600F4F3 RID: 62707 RVA: 0x0006B3D6 File Offset: 0x000695D6
		' (set) Token: 0x0600F4F4 RID: 62708 RVA: 0x0006B3E0 File Offset: 0x000695E0
		Friend Overridable Property lblerrorccend As Label

		' Token: 0x17005DC6 RID: 24006
		' (get) Token: 0x0600F4F5 RID: 62709 RVA: 0x0006B3E9 File Offset: 0x000695E9
		' (set) Token: 0x0600F4F6 RID: 62710 RVA: 0x0092C368 File Offset: 0x0092A568
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick_1
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC7 RID: 24007
		' (get) Token: 0x0600F4F7 RID: 62711 RVA: 0x0006B3F3 File Offset: 0x000695F3
		' (set) Token: 0x0600F4F8 RID: 62712 RVA: 0x0092C3AC File Offset: 0x0092A5AC
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

		' Token: 0x17005DC8 RID: 24008
		' (get) Token: 0x0600F4F9 RID: 62713 RVA: 0x0006B3FD File Offset: 0x000695FD
		' (set) Token: 0x0600F4FA RID: 62714 RVA: 0x0092C3F0 File Offset: 0x0092A5F0
		Private _Button7 As Button
		Friend Overridable Property Button7 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
				Dim button As Button = Me._Button7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button7 = value
				button = Me._Button7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DC9 RID: 24009
		' (get) Token: 0x0600F4FB RID: 62715 RVA: 0x0006B407 File Offset: 0x00069607
		' (set) Token: 0x0600F4FC RID: 62716 RVA: 0x0006B411 File Offset: 0x00069611
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005DCA RID: 24010
		' (get) Token: 0x0600F4FD RID: 62717 RVA: 0x0006B41A File Offset: 0x0006961A
		' (set) Token: 0x0600F4FE RID: 62718 RVA: 0x0006B424 File Offset: 0x00069624
		Friend Overridable Property Label5 As Label

		' Token: 0x17005DCB RID: 24011
		' (get) Token: 0x0600F4FF RID: 62719 RVA: 0x0006B42D File Offset: 0x0006962D
		' (set) Token: 0x0600F500 RID: 62720 RVA: 0x0006B437 File Offset: 0x00069637
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x0600F501 RID: 62721 RVA: 0x0092C434 File Offset: 0x0092A634
		Private Sub btnSend_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.tbUname.Text.EndsWith("@gmail.com")
			If flag Then
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim text As String = Me.tbUname.Text
				Dim text2 As String = Me.tbPass.Text.Trim()
				Dim text3 As String = Me.tbTo.Text
				Dim text4 As String = Me.tbCc.Text
				Dim text5 As String = Me.tbSubject.Text.Trim()
				Dim text6 As String = If((Me.tbBody.Text.Trim() + vbCrLf + vbCrLf), "")
				Dim text7 As String = Me.lblAttach.Text
				Dim flag2 As Boolean = (Operators.CompareString(Me.tbUname.Text, "", False) = 0) Or (Me.tbUname.Text.Length < 2)
				If flag2 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Username"
					Me.tbUname.Focus()
					Return
				End If
				Dim flag3 As Boolean = text2.Length < 6
				If flag3 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Password"
					Me.tbPass.Focus()
					Return
				End If
				Dim flag4 As Boolean = (Operators.CompareString(Me.tbTo.Text, "", False) = 0) Or (Me.tbTo.Text.Length < 2)
				If flag4 Then
					Me.hidelbl()
					Me.lblerrorto.Show()
					Me.lblerrorto.Text = "Invalid Receiver E-Mail"
					Me.tbTo.Focus()
					Return
				End If
				Dim flag5 As Boolean = (Operators.CompareString(Me.tbSubject.Text, "", False) = 0) Or (Me.tbSubject.Text.Length < 2)
				If flag5 Then
					Me.hidelbl()
					Me.lblerrorsubject.Show()
					Me.lblerrorsubject.Text = "Invalid Subject"
					Me.tbSubject.Focus()
					Return
				End If
				Dim flag6 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
				If flag6 Then
					Me.hidelbl()
					Dim mailMessage As MailMessage = New MailMessage()
					Try
						mailMessage.From = New MailAddress(text)
						mailMessage.[To].Add(text3)
						mailMessage.Subject = text5
						mailMessage.Body = text6
						Dim smtpClient As SmtpClient = New SmtpClient("smtp.gmail.com")
						smtpClient.Port = 587
						smtpClient.Credentials = New NetworkCredential(text, text2)
						smtpClient.EnableSsl = True
						Try
							MyBase.Enabled = False
							MyBase.WindowState = FormWindowState.Normal
							smtpClient.Send(mailMessage)
							Me.TimerProgressbar.Start()
							Me.lblAttach.Hide()
							Me.clearinputs()
						Catch ex As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Catch ex2 As Exception
						Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
						MyBase.Enabled = True
					End Try
				Else
					Dim flag7 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
					If flag7 Then
						Me.hidelbl()
						Dim attachment As Attachment = New Attachment(text7)
						Dim mailMessage2 As MailMessage = New MailMessage()
						Try
							mailMessage2.From = New MailAddress(text)
							mailMessage2.[To].Add(text3)
							mailMessage2.Subject = text5
							mailMessage2.Body = text6
							mailMessage2.Attachments.Add(attachment)
							Dim smtpClient2 As SmtpClient = New SmtpClient("smtp.gmail.com")
							smtpClient2.Port = 587
							smtpClient2.Credentials = New NetworkCredential(text, text2)
							smtpClient2.EnableSsl = True
							Try
								MyBase.Enabled = False
								MyBase.WindowState = FormWindowState.Normal
								smtpClient2.Send(mailMessage2)
								Me.TimerProgressbar.Start()
								Me.lblAttach.Hide()
								Me.clearinputs()
							Catch ex3 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Catch ex4 As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Else
						Dim flag8 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
						If flag8 Then
							Dim flag9 As Boolean = Me.tbCc.Text.Length < 2
							If flag9 Then
								Me.hidelbl()
								Me.lblerrorcc.Show()
								Me.lblerrorcc.Text = "Invalid Cc E-Mail"
								Return
							End If
							Me.hidelbl()
							Dim mailMessage3 As MailMessage = New MailMessage()
							Try
								mailMessage3.From = New MailAddress(text)
								mailMessage3.[To].Add(text3)
								mailMessage3.Subject = text5
								mailMessage3.CC.Add(text4)
								mailMessage3.Body = text6
								Dim smtpClient3 As SmtpClient = New SmtpClient("smtp.gmail.com")
								smtpClient3.Port = 587
								smtpClient3.Credentials = New NetworkCredential(text, text2)
								smtpClient3.EnableSsl = True
								Try
									MyBase.Enabled = False
									MyBase.WindowState = FormWindowState.Normal
									smtpClient3.Send(mailMessage3)
									Me.TimerProgressbar.Start()
									Me.lblAttach.Hide()
									Me.clearinputs()
								Catch ex5 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							Catch ex6 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Else
							Dim flag10 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
							If flag10 Then
								Me.hidelbl()
								Dim attachment2 As Attachment = New Attachment(text7)
								Dim mailMessage4 As MailMessage = New MailMessage()
								Try
									mailMessage4.From = New MailAddress(text)
									mailMessage4.[To].Add(text3)
									mailMessage4.Subject = text5
									mailMessage4.Body = text6
									mailMessage4.CC.Add(text4)
									mailMessage4.Attachments.Add(attachment2)
									Dim smtpClient4 As SmtpClient = New SmtpClient("smtp.gmail.com")
									smtpClient4.Port = 587
									smtpClient4.Credentials = New NetworkCredential(text, text2)
									smtpClient4.EnableSsl = True
									Try
										MyBase.Enabled = False
										MyBase.WindowState = FormWindowState.Normal
										smtpClient4.Send(mailMessage4)
										Me.TimerProgressbar.Start()
										Me.lblAttach.Hide()
										Me.clearinputs()
									Catch ex7 As Exception
										Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
										MyBase.Enabled = True
									End Try
								Catch ex8 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							End If
						End If
					End If
				End If
			End If
			Dim flag11 As Boolean = Me.tbUname.Text.EndsWith("@yahoo.com") Or Me.tbUname.Text.EndsWith("@yahoo.co.uk") Or Me.tbUname.Text.EndsWith("@ymail.com")
			If flag11 Then
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim text8 As String = Me.tbUname.Text
				Dim text9 As String = Me.tbPass.Text.Trim()
				Dim text10 As String = Me.tbTo.Text
				Dim text11 As String = Me.tbCc.Text
				Dim text12 As String = Me.tbSubject.Text.Trim()
				Dim text13 As String = If((Me.tbBody.Text.Trim() + vbCrLf + vbCrLf), "")
				Dim text14 As String = Me.lblAttach.Text
				Dim flag12 As Boolean = (Operators.CompareString(Me.tbUname.Text, "", False) = 0) Or (Me.tbUname.Text.Length < 2)
				If flag12 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Username"
					Me.tbUname.Focus()
					Return
				End If
				Dim flag13 As Boolean = text9.Length < 6
				If flag13 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Password"
					Me.tbPass.Focus()
					Return
				End If
				Dim flag14 As Boolean = (Operators.CompareString(Me.tbTo.Text, "", False) = 0) Or (Me.tbTo.Text.Length < 2)
				If flag14 Then
					Me.hidelbl()
					Me.lblerrorto.Show()
					Me.lblerrorto.Text = "Invalid Receiver E-Mail"
					Me.tbTo.Focus()
					Return
				End If
				Dim flag15 As Boolean = (Operators.CompareString(Me.tbSubject.Text, "", False) = 0) Or (Me.tbSubject.Text.Length < 2)
				If flag15 Then
					Me.hidelbl()
					Me.lblerrorsubject.Show()
					Me.lblerrorsubject.Text = "Invalid Subject"
					Me.tbSubject.Focus()
					Return
				End If
				Dim flag16 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
				If flag16 Then
					Me.hidelbl()
					Dim mailMessage5 As MailMessage = New MailMessage()
					Try
						mailMessage5.From = New MailAddress(text8)
						mailMessage5.[To].Add(text10)
						mailMessage5.Subject = text12
						mailMessage5.Body = text13
						Dim smtpClient5 As SmtpClient = New SmtpClient("smtp.mail.yahoo.com")
						smtpClient5.Port = 587
						smtpClient5.Credentials = New NetworkCredential(text8, text9)
						smtpClient5.EnableSsl = True
						Try
							MyBase.Enabled = False
							MyBase.WindowState = FormWindowState.Normal
							smtpClient5.Send(mailMessage5)
							Me.TimerProgressbar.Start()
							Me.lblAttach.Hide()
							Me.clearinputs()
						Catch ex9 As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Catch ex10 As Exception
						Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
						MyBase.Enabled = True
					End Try
				Else
					Dim flag17 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
					If flag17 Then
						Me.hidelbl()
						Dim attachment3 As Attachment = New Attachment(text14)
						Dim mailMessage6 As MailMessage = New MailMessage()
						Try
							mailMessage6.From = New MailAddress(text8)
							mailMessage6.[To].Add(text10)
							mailMessage6.Subject = text12
							mailMessage6.Body = text13
							mailMessage6.Attachments.Add(attachment3)
							Dim smtpClient6 As SmtpClient = New SmtpClient("smtp.mail.yahoo.com")
							smtpClient6.Port = 587
							smtpClient6.Credentials = New NetworkCredential(text8, text9)
							smtpClient6.EnableSsl = True
							Try
								MyBase.Enabled = False
								MyBase.WindowState = FormWindowState.Normal
								smtpClient6.Send(mailMessage6)
								Me.TimerProgressbar.Start()
								Me.lblAttach.Hide()
								Me.clearinputs()
							Catch ex11 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Catch ex12 As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Else
						Dim flag18 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
						If flag18 Then
							Dim flag19 As Boolean = Me.tbCc.Text.Length < 2
							If flag19 Then
								Me.hidelbl()
								Me.lblerrorcc.Show()
								Me.lblerrorcc.Text = "Invalid Cc E-Mail"
								Return
							End If
							Me.hidelbl()
							Dim mailMessage7 As MailMessage = New MailMessage()
							Try
								mailMessage7.From = New MailAddress(text8)
								mailMessage7.[To].Add(text10)
								mailMessage7.Subject = text12
								mailMessage7.CC.Add(text11)
								mailMessage7.Body = text13
								Dim smtpClient7 As SmtpClient = New SmtpClient("smtp.mail.yahoo.com")
								smtpClient7.Port = 587
								smtpClient7.Credentials = New NetworkCredential(text8, text9)
								smtpClient7.EnableSsl = True
								Try
									MyBase.Enabled = False
									MyBase.WindowState = FormWindowState.Normal
									smtpClient7.Send(mailMessage7)
									Me.TimerProgressbar.Start()
									Me.lblAttach.Hide()
									Me.clearinputs()
								Catch ex13 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							Catch ex14 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Else
							Dim flag20 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
							If flag20 Then
								Me.hidelbl()
								Dim attachment4 As Attachment = New Attachment(text14)
								Dim mailMessage8 As MailMessage = New MailMessage()
								Try
									mailMessage8.From = New MailAddress(text8)
									mailMessage8.[To].Add(text10)
									mailMessage8.Subject = text12
									mailMessage8.Body = text13
									mailMessage8.CC.Add(text11)
									mailMessage8.Attachments.Add(attachment4)
									Dim smtpClient8 As SmtpClient = New SmtpClient("smtp.mail.yahoo.com")
									smtpClient8.Port = 587
									smtpClient8.Credentials = New NetworkCredential(text8, text9)
									smtpClient8.EnableSsl = True
									Try
										MyBase.Enabled = False
										MyBase.WindowState = FormWindowState.Normal
										smtpClient8.Send(mailMessage8)
										Me.TimerProgressbar.Start()
										Me.lblAttach.Hide()
										Me.clearinputs()
									Catch ex15 As Exception
										Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
										MyBase.Enabled = True
									End Try
								Catch ex16 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							End If
						End If
					End If
				End If
			End If
			Dim flag21 As Boolean = Me.tbUname.Text.EndsWith("@rediffmail.com")
			If flag21 Then
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim text15 As String = Me.tbUname.Text
				Dim text16 As String = Me.tbPass.Text.Trim()
				Dim text17 As String = Me.tbTo.Text
				Dim text18 As String = Me.tbCc.Text
				Dim text19 As String = Me.tbSubject.Text.Trim()
				Dim text20 As String = If((Me.tbBody.Text.Trim() + vbCrLf + vbCrLf), "")
				Dim text21 As String = Me.lblAttach.Text
				Dim flag22 As Boolean = (Operators.CompareString(Me.tbUname.Text, "", False) = 0) Or (Me.tbUname.Text.Length < 2)
				If flag22 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Username"
					Me.tbUname.Focus()
					Return
				End If
				Dim flag23 As Boolean = text16.Length < 6
				If flag23 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Password"
					Me.tbPass.Focus()
					Return
				End If
				Dim flag24 As Boolean = (Operators.CompareString(Me.tbTo.Text, "", False) = 0) Or (Me.tbTo.Text.Length < 2)
				If flag24 Then
					Me.hidelbl()
					Me.lblerrorto.Show()
					Me.lblerrorto.Text = "Invalid Receiver E-Mail"
					Me.tbTo.Focus()
					Return
				End If
				Dim flag25 As Boolean = (Operators.CompareString(Me.tbSubject.Text, "", False) = 0) Or (Me.tbSubject.Text.Length < 2)
				If flag25 Then
					Me.hidelbl()
					Me.lblerrorsubject.Show()
					Me.lblerrorsubject.Text = "Invalid Subject"
					Me.tbSubject.Focus()
					Return
				End If
				Dim flag26 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
				If flag26 Then
					Me.hidelbl()
					Dim mailMessage9 As MailMessage = New MailMessage()
					Try
						mailMessage9.From = New MailAddress(text15)
						mailMessage9.[To].Add(text17)
						mailMessage9.Subject = text19
						mailMessage9.Body = text20
						Dim smtpClient9 As SmtpClient = New SmtpClient("smtp.rediffmail.com")
						smtpClient9.Port = 587
						smtpClient9.Credentials = New NetworkCredential(text15, text16)
						smtpClient9.EnableSsl = True
						Try
							MyBase.Enabled = False
							MyBase.WindowState = FormWindowState.Normal
							smtpClient9.Send(mailMessage9)
							Me.TimerProgressbar.Start()
							Me.lblAttach.Hide()
							Me.clearinputs()
						Catch ex17 As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Catch ex18 As Exception
						Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
						MyBase.Enabled = True
					End Try
				Else
					Dim flag27 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
					If flag27 Then
						Me.hidelbl()
						Dim attachment5 As Attachment = New Attachment(text21)
						Dim mailMessage10 As MailMessage = New MailMessage()
						Try
							mailMessage10.From = New MailAddress(text15)
							mailMessage10.[To].Add(text17)
							mailMessage10.Subject = text19
							mailMessage10.Body = text20
							mailMessage10.Attachments.Add(attachment5)
							Dim smtpClient10 As SmtpClient = New SmtpClient("smtp.rediffmail.com")
							smtpClient10.Port = 587
							smtpClient10.Credentials = New NetworkCredential(text15, text16)
							smtpClient10.EnableSsl = True
							Try
								MyBase.Enabled = False
								MyBase.WindowState = FormWindowState.Normal
								smtpClient10.Send(mailMessage10)
								Me.TimerProgressbar.Start()
								Me.lblAttach.Hide()
								Me.clearinputs()
							Catch ex19 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Catch ex20 As Exception
							Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
							MyBase.Enabled = True
						End Try
					Else
						Dim flag28 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
						If flag28 Then
							Dim flag29 As Boolean = Me.tbCc.Text.Length < 2
							If flag29 Then
								Me.hidelbl()
								Me.lblerrorcc.Show()
								Me.lblerrorcc.Text = "Invalid Cc E-Mail"
								Return
							End If
							Me.hidelbl()
							Dim mailMessage11 As MailMessage = New MailMessage()
							Try
								mailMessage11.From = New MailAddress(text15)
								mailMessage11.[To].Add(text17)
								mailMessage11.Subject = text19
								mailMessage11.CC.Add(text18)
								mailMessage11.Body = text20
								Dim smtpClient11 As SmtpClient = New SmtpClient("smtp.rediffmail.com")
								smtpClient11.Port = 587
								smtpClient11.Credentials = New NetworkCredential(text15, text16)
								smtpClient11.EnableSsl = True
								Try
									MyBase.Enabled = False
									MyBase.WindowState = FormWindowState.Normal
									smtpClient11.Send(mailMessage11)
									Me.TimerProgressbar.Start()
									Me.lblAttach.Hide()
									Me.clearinputs()
								Catch ex21 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							Catch ex22 As Exception
								Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
								MyBase.Enabled = True
							End Try
						Else
							Dim flag30 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
							If flag30 Then
								Me.hidelbl()
								Dim attachment6 As Attachment = New Attachment(text21)
								Dim mailMessage12 As MailMessage = New MailMessage()
								Try
									mailMessage12.From = New MailAddress(text15)
									mailMessage12.[To].Add(text17)
									mailMessage12.Subject = text19
									mailMessage12.Body = text20
									mailMessage12.CC.Add(text18)
									mailMessage12.Attachments.Add(attachment6)
									Dim smtpClient12 As SmtpClient = New SmtpClient("smtp.rediffmail.com")
									smtpClient12.Port = 587
									smtpClient12.Credentials = New NetworkCredential(text15, text16)
									smtpClient12.EnableSsl = True
									Try
										MyBase.Enabled = False
										MyBase.WindowState = FormWindowState.Normal
										smtpClient12.Send(mailMessage12)
										Me.TimerProgressbar.Start()
										Me.lblAttach.Hide()
										Me.clearinputs()
									Catch ex23 As Exception
										Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
										MyBase.Enabled = True
									End Try
								Catch ex24 As Exception
									Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
									MyBase.Enabled = True
								End Try
							End If
						End If
					End If
				End If
			End If
			Dim flag31 As Boolean = Me.tbUname.Text.EndsWith("@hotmail.com")
			If flag31 Then
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim text22 As String = Me.tbUname.Text
				Dim text23 As String = Me.tbPass.Text.Trim()
				Dim text24 As String = Me.tbTo.Text
				Dim text25 As String = Me.tbCc.Text
				Dim text26 As String = Me.tbSubject.Text.Trim()
				Dim text27 As String = If((Me.tbBody.Text.Trim() + vbCrLf + vbCrLf), "")
				Dim text28 As String = Me.lblAttach.Text
				Dim flag32 As Boolean = (Operators.CompareString(Me.tbUname.Text, "", False) = 0) Or (Me.tbUname.Text.Length < 2)
				If flag32 Then
					Me.hidelbl()
					Me.lblerroruser.Show()
					Me.lblerroruser.Text = "Invalid Username"
					Me.tbUname.Focus()
				Else
					Dim flag33 As Boolean = text23.Length < 6
					If flag33 Then
						Me.hidelbl()
						Me.lblerroruser.Show()
						Me.lblerroruser.Text = "Invalid Password"
						Me.tbPass.Focus()
					Else
						Dim flag34 As Boolean = (Operators.CompareString(Me.tbTo.Text, "", False) = 0) Or (Me.tbTo.Text.Length < 2)
						If flag34 Then
							Me.hidelbl()
							Me.lblerrorto.Show()
							Me.lblerrorto.Text = "Invalid Receiver E-Mail"
							Me.tbTo.Focus()
						Else
							Dim flag35 As Boolean = (Operators.CompareString(Me.tbSubject.Text, "", False) = 0) Or (Me.tbSubject.Text.Length < 2)
							If flag35 Then
								Me.hidelbl()
								Me.lblerrorsubject.Show()
								Me.lblerrorsubject.Text = "Invalid Subject"
								Me.tbSubject.Focus()
							Else
								Dim flag36 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
								If flag36 Then
									Me.hidelbl()
									Dim mailMessage13 As MailMessage = New MailMessage()
									Try
										mailMessage13.From = New MailAddress(text22)
										mailMessage13.[To].Add(text24)
										mailMessage13.Subject = text26
										mailMessage13.Body = text27
										Dim smtpClient13 As SmtpClient = New SmtpClient("smtp-mail.outlook.com")
										smtpClient13.Port = 587
										smtpClient13.Credentials = New NetworkCredential(text22, text23)
										smtpClient13.EnableSsl = True
										Try
											MyBase.Enabled = False
											MyBase.WindowState = FormWindowState.Normal
											smtpClient13.Send(mailMessage13)
											Me.TimerProgressbar.Start()
											Me.lblAttach.Hide()
											Me.clearinputs()
										Catch ex25 As Exception
											Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
											MyBase.Enabled = True
										End Try
									Catch ex26 As Exception
										Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
										MyBase.Enabled = True
									End Try
								Else
									Dim flag37 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) = 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
									If flag37 Then
										Me.hidelbl()
										Dim attachment7 As Attachment = New Attachment(text28)
										Dim mailMessage14 As MailMessage = New MailMessage()
										Try
											mailMessage14.From = New MailAddress(text22)
											mailMessage14.[To].Add(text24)
											mailMessage14.Subject = text26
											mailMessage14.Body = text27
											mailMessage14.Attachments.Add(attachment7)
											Dim smtpClient14 As SmtpClient = New SmtpClient("smtp-mail.outlook.com")
											smtpClient14.Port = 587
											smtpClient14.Credentials = New NetworkCredential(text22, text23)
											smtpClient14.EnableSsl = True
											Try
												MyBase.Enabled = False
												MyBase.WindowState = FormWindowState.Normal
												smtpClient14.Send(mailMessage14)
												Me.TimerProgressbar.Start()
												Me.lblAttach.Hide()
												Me.clearinputs()
											Catch ex27 As Exception
												Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
												MyBase.Enabled = True
											End Try
										Catch ex28 As Exception
											Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
											MyBase.Enabled = True
										End Try
									Else
										Dim flag38 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) = 0)
										If flag38 Then
											Dim flag39 As Boolean = Me.tbCc.Text.Length < 2
											If flag39 Then
												Me.hidelbl()
												Me.lblerrorcc.Show()
												Me.lblerrorcc.Text = "Invalid Cc E-Mail"
											Else
												Me.hidelbl()
												Dim mailMessage15 As MailMessage = New MailMessage()
												Try
													mailMessage15.From = New MailAddress(text22)
													mailMessage15.[To].Add(text24)
													mailMessage15.Subject = text26
													mailMessage15.CC.Add(text25)
													mailMessage15.Body = text27
													Dim smtpClient15 As SmtpClient = New SmtpClient("smtp-mail.outlook.com")
													smtpClient15.Port = 587
													smtpClient15.Credentials = New NetworkCredential(text22, text23)
													smtpClient15.EnableSsl = True
													Try
														MyBase.Enabled = False
														MyBase.WindowState = FormWindowState.Normal
														smtpClient15.Send(mailMessage15)
														Me.TimerProgressbar.Start()
														Me.lblAttach.Hide()
														Me.clearinputs()
													Catch ex29 As Exception
														Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
														MyBase.Enabled = True
													End Try
												Catch ex30 As Exception
													Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
													MyBase.Enabled = True
												End Try
											End If
										Else
											Dim flag40 As Boolean = (Operators.CompareString(Me.tbCc.Text, "", False) <> 0) And (Operators.CompareString(Me.lblAttach.Text, "attach", False) <> 0)
											If flag40 Then
												Me.hidelbl()
												Dim attachment8 As Attachment = New Attachment(text28)
												Dim mailMessage16 As MailMessage = New MailMessage()
												Try
													mailMessage16.From = New MailAddress(text22)
													mailMessage16.[To].Add(text24)
													mailMessage16.Subject = text26
													mailMessage16.Body = text27
													mailMessage16.CC.Add(text25)
													mailMessage16.Attachments.Add(attachment8)
													Dim smtpClient16 As SmtpClient = New SmtpClient("smtp-mail.outlook.com")
													smtpClient16.Port = 587
													smtpClient16.Credentials = New NetworkCredential(text22, text23)
													smtpClient16.EnableSsl = True
													Try
														MyBase.Enabled = False
														MyBase.WindowState = FormWindowState.Normal
														smtpClient16.Send(mailMessage16)
														Me.TimerProgressbar.Start()
														Me.lblAttach.Hide()
														Me.clearinputs()
													Catch ex31 As Exception
														Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
														MyBase.Enabled = True
													End Try
												Catch ex32 As Exception
													Interaction.MsgBox("Please check username and password", MsgBoxStyle.Critical, "Error")
													MyBase.Enabled = True
												End Try
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F502 RID: 62722 RVA: 0x0006B440 File Offset: 0x00069640
		Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs)
			MyBase.Dispose()
		End Sub

		' Token: 0x0600F503 RID: 62723 RVA: 0x0006B44A File Offset: 0x0006964A
		Private Sub frmMain_Load(sender As Object, e As EventArgs)
			Me.Timerdate.Enabled = True
			Me.Timerdate.Interval = 1
			Me.tbPass.PasswordChar = "♠"c
			Me.Emaildisplay()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F504 RID: 62724 RVA: 0x0092E724 File Offset: 0x0092C924
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

		' Token: 0x0600F505 RID: 62725 RVA: 0x0092E89C File Offset: 0x0092CA9C
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
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

		' Token: 0x0600F506 RID: 62726 RVA: 0x0092E958 File Offset: 0x0092CB58
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

		' Token: 0x0600F507 RID: 62727 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F508 RID: 62728 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F509 RID: 62729 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F50A RID: 62730 RVA: 0x0092EA24 File Offset: 0x0092CC24
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.lblTime.Text = Conversions.ToString(DateAndTime.TimeOfDay)
			Me.lblDate.Text = DateAndTime.Today.[Date].ToString("dddd, dd MMMM  yyyy")
		End Sub

		' Token: 0x0600F50B RID: 62731 RVA: 0x0006B486 File Offset: 0x00069686
		Private Sub Timer1_Tick_1(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600F50C RID: 62732 RVA: 0x0092EA70 File Offset: 0x0092CC70
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.lblStatus.Hide()
			Me.tbTo.Clear()
			Me.tbCc.Clear()
			Me.tbSubject.Clear()
			Me.lblAttach.Hide()
			Me.lblAttach.Text = "attach"
			Me.tbBody.Clear()
			Me.hidelbl()
		End Sub

		' Token: 0x0600F50D RID: 62733 RVA: 0x0092EAE0 File Offset: 0x0092CCE0
		Private Sub TimerProgressbar_Tick(sender As Object, e As EventArgs)
			Me.ProgressBar1.Show()
			Me.ProgressBar1.Increment(1)
			Me.lblStatus.Visible = True
			Dim flag As Boolean = Me.ProgressBar1.Value = 10
			If flag Then
				Me.lblStatus.Text = "Please wait..."
			Else
				Dim flag2 As Boolean = Me.ProgressBar1.Value = 30
				If flag2 Then
					Me.lblStatus.Text = "Connecting to server..."
				Else
					Dim flag3 As Boolean = Me.ProgressBar1.Value = 40
					If flag3 Then
						Me.lblStatus.Text = "Please wait..."
					Else
						Dim flag4 As Boolean = Me.ProgressBar1.Value = 50
						If flag4 Then
							Me.lblStatus.Text = "Checking connection..."
						Else
							Dim flag5 As Boolean = Me.ProgressBar1.Value = 60
							If flag5 Then
								Me.lblStatus.Text = "Connection OK..."
							Else
								Dim flag6 As Boolean = Me.ProgressBar1.Value = 80
								If flag6 Then
									Me.lblStatus.Text = "Please wait..."
								Else
									Dim flag7 As Boolean = Me.ProgressBar1.Value = 90
									If flag7 Then
										Me.lblStatus.Text = "Finalizing..."
									Else
										Dim flag8 As Boolean = Me.ProgressBar1.Value = Me.ProgressBar1.Maximum
										If flag8 Then
											Me.ProgressBar1.Hide()
											Me.lblStatus.Text = "Mail Sent Successfully !"
											Me.TimerProgressbar.[Stop]()
											MyBase.Enabled = True
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F50E RID: 62734 RVA: 0x0092EC8C File Offset: 0x0092CE8C
		Private Sub tbrLeft_Click(sender As Object, e As EventArgs)
			Me.tbBody.SelectionAlignment = HorizontalAlignment.Left
			Dim text As String = Conversions.ToString(CInt(Me.tbBody.SelectionAlignment))
		End Sub

		' Token: 0x0600F50F RID: 62735 RVA: 0x0092ECB8 File Offset: 0x0092CEB8
		Private Sub tbrCenter_Click(sender As Object, e As EventArgs)
			Me.tbBody.SelectionAlignment = HorizontalAlignment.Center
			Dim text As String = Conversions.ToString(CInt(Me.tbBody.SelectionAlignment))
		End Sub

		' Token: 0x0600F510 RID: 62736 RVA: 0x0092ECE4 File Offset: 0x0092CEE4
		Private Sub tbrRight_Click(sender As Object, e As EventArgs)
			Me.tbBody.SelectionAlignment = HorizontalAlignment.Right
			Dim text As String = Conversions.ToString(CInt(Me.tbBody.SelectionAlignment))
		End Sub

		' Token: 0x0600F511 RID: 62737 RVA: 0x0092ED10 File Offset: 0x0092CF10
		Private Sub tbrBold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.tbBody.SelectionFont IsNot Nothing
			If flag Then
				Dim selectionFont As Font = Me.tbBody.SelectionFont
				Dim bold As Boolean = Me.tbBody.SelectionFont.Bold
				Dim fontStyle As FontStyle
				If bold Then
					fontStyle = FontStyle.Regular
				Else
					fontStyle = FontStyle.Bold
				End If
				Me.tbBody.SelectionFont = New Font(selectionFont.FontFamily, selectionFont.Size, fontStyle)
			End If
		End Sub

		' Token: 0x0600F512 RID: 62738 RVA: 0x0092ED7C File Offset: 0x0092CF7C
		Private Sub tbrItalic_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.tbBody.SelectionFont IsNot Nothing
			If flag Then
				Dim selectionFont As Font = Me.tbBody.SelectionFont
				Dim italic As Boolean = Me.tbBody.SelectionFont.Italic
				Dim fontStyle As FontStyle
				If italic Then
					fontStyle = FontStyle.Regular
				Else
					fontStyle = FontStyle.Italic
				End If
				Me.tbBody.SelectionFont = New Font(selectionFont.FontFamily, selectionFont.Size, fontStyle)
			End If
		End Sub

		' Token: 0x0600F513 RID: 62739 RVA: 0x0092EDE8 File Offset: 0x0092CFE8
		Private Sub tbrUnderline_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.tbBody.SelectionFont IsNot Nothing
			If flag Then
				Dim selectionFont As Font = Me.tbBody.SelectionFont
				Dim underline As Boolean = Me.tbBody.SelectionFont.Underline
				Dim fontStyle As FontStyle
				If underline Then
					fontStyle = FontStyle.Regular
				Else
					fontStyle = FontStyle.Underline
				End If
				Me.tbBody.SelectionFont = New Font(selectionFont.FontFamily, selectionFont.Size, fontStyle)
			End If
		End Sub

		' Token: 0x0600F514 RID: 62740 RVA: 0x0092EE54 File Offset: 0x0092D054
		Private Sub tbrFont_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.tbBody.SelectionFont IsNot Nothing
			If flag Then
				Me.FontDialog1.Font = Me.tbBody.SelectionFont
			Else
				Me.FontDialog1.Font = Nothing
			End If
			Me.FontDialog1.ShowApply = True
			Dim flag2 As Boolean = Me.FontDialog1.ShowDialog() = DialogResult.OK
			If flag2 Then
				Me.tbBody.SelectionFont = Me.FontDialog1.Font
			End If
		End Sub

		' Token: 0x0600F515 RID: 62741 RVA: 0x0092EED8 File Offset: 0x0092D0D8
		Private Sub tbrOpen_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
			openFileDialog.Filter = "Text Files (*.txt)|*.txt"
			openFileDialog.Title = "Open File"
			openFileDialog.FileName = ""
			openFileDialog.ShowDialog()
		End Sub

		' Token: 0x0600F516 RID: 62742 RVA: 0x0092EF1C File Offset: 0x0092D11C
		Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs)
			Dim fileName As String = Me.OpenFileDialog1.FileName
			Dim streamReader As StreamReader = New StreamReader(fileName)
			Me.tbBody.Text = streamReader.ReadToEnd()
			streamReader.Close()
		End Sub

		' Token: 0x0600F517 RID: 62743 RVA: 0x0092EF58 File Offset: 0x0092D158
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			MyBase.Enabled = False
			Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog2
			openFileDialog.Title = "Select Attachment"
			openFileDialog.FileName = ""
			openFileDialog.Filter = "All Files(*.*)|*.*"
			Dim flag As Boolean = Me.OpenFileDialog2.ShowDialog() = DialogResult.Cancel
			If flag Then
				MyBase.Enabled = True
			End If
		End Sub

		' Token: 0x0600F518 RID: 62744 RVA: 0x0006B4A2 File Offset: 0x000696A2
		Private Sub OpenFileDialog2_FileOk(sender As Object, e As CancelEventArgs)
			MyBase.Enabled = True
			Me.lblAttach.Show()
			Me.lblAttach.Text = Path.GetFullPath(Me.OpenFileDialog2.FileName)
		End Sub

		' Token: 0x0600F519 RID: 62745 RVA: 0x0092EFBC File Offset: 0x0092D1BC
		Private Sub hidelbl()
			Me.lblerroruser.Hide()
			Me.lblerrorto.Hide()
			Me.lblerrortoend.Hide()
			Me.lblerrorcc.Hide()
			Me.lblerrorccend.Hide()
			Me.lblerrorsubject.Hide()
		End Sub

		' Token: 0x0600F51A RID: 62746 RVA: 0x0092F014 File Offset: 0x0092D214
		Private Sub clearinputs()
			Me.tbTo.Clear()
			Me.tbCc.Clear()
			Me.tbSubject.Clear()
			Me.tbBody.Clear()
			Me.lblAttach.Text = "attach"
		End Sub

		' Token: 0x0600F51B RID: 62747 RVA: 0x0006B4D5 File Offset: 0x000696D5
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Me.tbPass.PasswordChar = vbNullChar
			Me.tbPass.Focus()
			Me.Button6.Visible = False
			Me.Button7.Visible = True
		End Sub

		' Token: 0x0600F51C RID: 62748 RVA: 0x0006B50B File Offset: 0x0006970B
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Me.tbPass.PasswordChar = "♠"c
			Me.tbPass.Focus()
			Me.Button6.Visible = True
			Me.Button7.Visible = False
		End Sub

		' Token: 0x0600F51D RID: 62749 RVA: 0x0092F064 File Offset: 0x0092D264
		Private Sub Emaildisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "select RTRIM(Username),RTRIM(Password) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.tbUname.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.tbPass.Text = ModFunc.Decrypt(Convert.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(1))))
				Else
					Me.tbUname.Text = ""
					Me.tbPass.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F51E RID: 62750 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Emailstatus()
		End Sub

		' Token: 0x0600F51F RID: 62751 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmailsender_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
