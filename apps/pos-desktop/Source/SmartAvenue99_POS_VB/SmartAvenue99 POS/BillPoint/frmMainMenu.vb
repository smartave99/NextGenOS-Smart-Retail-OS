Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports DevNet
Imports DevNet.Models
Imports DevNetFB
Imports DevNetLM
Imports DevNetLM.Models
Imports GDClient
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary
Imports SautinSoft

Namespace BillPoint
	' Token: 0x0200034C RID: 844
	<DesignerGenerated()>
	Public Partial Class frmMainMenu
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C577 RID: 50551 RVA: 0x007D1BA4 File Offset: 0x007CFDA4
		Public Sub New()
			If AppleUITheme.IsCapturing Then
				Me.InitializeComponent()
				Return
			End If
			AddHandler MyBase.FormClosing, AddressOf Me.frmMainMenu_FormClosing
			AddHandler MyBase.Load, AddressOf Me.frmMainMenu_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmMainMenu_KeyDown
			Me.CurSym = ""
			Me.regdto = ""
			Me.android_service = New FirebaseService()
			Me.isMigrationRunning = False
			Me.AutoMigration_Status = False
			Me.helper = New DBHelper()
			Me.UserButtons = New List(Of GelButton)()
			Me.mydict = New Dictionary(Of String, String)()
			Me.lastClickedButton = Nothing
			Me.sts2 = ""
			Me.sts_w2 = ""
			Me.i = 0
			Me.strb = New StringBuilder()
			Me.json = Nothing
			Me.ujson = Nothing
			Me.pjson = Nothing
			Me.ajson = Nothing
			Me.lblType = ""
			Me.rec = New Record()
			Me.countOrder_previous = 0
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.AID = ""
			Me.InitializeComponent()
			AddHandler MyBase.Shown, Sub(sender, e)
				If Not AppleUITheme.IsCapturing Then RetailLayouts.Apply(Me)
			End Sub
		End Sub

		' Token: 0x17004E5C RID: 20060
		' (get) Token: 0x0600C57A RID: 50554 RVA: 0x00058599 File Offset: 0x00056799
		' (set) Token: 0x0600C57B RID: 50555 RVA: 0x007E09A8 File Offset: 0x007DEBA8
		Private _MenuStrip2 As MenuStrip
		Friend Overridable Property MenuStrip2 As MenuStrip
			<CompilerGenerated()>
			Get
				Return Me._MenuStrip2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As MenuStrip)
				Dim eventHandler As EventHandler = AddressOf Me.MenuStrip2_MouseEnter
				Dim eventHandler2 As EventHandler = AddressOf Me.MenuStrip2_MouseHover
				Dim eventHandler3 As EventHandler = AddressOf Me.MenuStrip2_MouseLeave
				Dim menuStrip As MenuStrip = Me._MenuStrip2
				If menuStrip IsNot Nothing Then
					RemoveHandler menuStrip.MouseEnter, eventHandler
					RemoveHandler menuStrip.MouseHover, eventHandler2
					RemoveHandler menuStrip.MouseLeave, eventHandler3
				End If
				Me._MenuStrip2 = value
				menuStrip = Me._MenuStrip2
				If menuStrip IsNot Nothing Then
					AddHandler menuStrip.MouseEnter, eventHandler
					AddHandler menuStrip.MouseHover, eventHandler2
					AddHandler menuStrip.MouseLeave, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x17004E5D RID: 20061
		' (get) Token: 0x0600C57C RID: 50556 RVA: 0x000585A3 File Offset: 0x000567A3
		' (set) Token: 0x0600C57D RID: 50557 RVA: 0x000585AD File Offset: 0x000567AD
		Friend Overridable Property MasterEntryToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E5E RID: 20062
		' (get) Token: 0x0600C57E RID: 50558 RVA: 0x000585B6 File Offset: 0x000567B6
		' (set) Token: 0x0600C57F RID: 50559 RVA: 0x000585C0 File Offset: 0x000567C0
		Friend Overridable Property AboutToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E5F RID: 20063
		' (get) Token: 0x0600C580 RID: 50560 RVA: 0x000585C9 File Offset: 0x000567C9
		' (set) Token: 0x0600C581 RID: 50561 RVA: 0x000585D3 File Offset: 0x000567D3
		Friend Overridable Property StatusStrip1 As StatusStrip

		' Token: 0x17004E60 RID: 20064
		' (get) Token: 0x0600C582 RID: 50562 RVA: 0x000585DC File Offset: 0x000567DC
		' (set) Token: 0x0600C583 RID: 50563 RVA: 0x000585E6 File Offset: 0x000567E6
		Friend Overridable Property lblUserType As ToolStripStatusLabel

		' Token: 0x17004E61 RID: 20065
		' (get) Token: 0x0600C584 RID: 50564 RVA: 0x000585EF File Offset: 0x000567EF
		' (set) Token: 0x0600C585 RID: 50565 RVA: 0x000585F9 File Offset: 0x000567F9
		Friend Overridable Property ToolStripStatusLabel2 As ToolStripStatusLabel

		' Token: 0x17004E62 RID: 20066
		' (get) Token: 0x0600C586 RID: 50566 RVA: 0x00058602 File Offset: 0x00056802
		' (set) Token: 0x0600C587 RID: 50567 RVA: 0x0005860C File Offset: 0x0005680C
		Friend Overridable Property lblUser As ToolStripStatusLabel

		' Token: 0x17004E63 RID: 20067
		' (get) Token: 0x0600C588 RID: 50568 RVA: 0x00058615 File Offset: 0x00056815
		' (set) Token: 0x0600C589 RID: 50569 RVA: 0x0005861F File Offset: 0x0005681F
		Friend Overridable Property ToolStripStatusLabel3 As ToolStripStatusLabel

		' Token: 0x17004E64 RID: 20068
		' (get) Token: 0x0600C58A RID: 50570 RVA: 0x00058628 File Offset: 0x00056828
		' (set) Token: 0x0600C58B RID: 50571 RVA: 0x00058632 File Offset: 0x00056832
		Friend Overridable Property lblDateTime As ToolStripStatusLabel

		' Token: 0x17004E65 RID: 20069
		' (get) Token: 0x0600C58C RID: 50572 RVA: 0x0005863B File Offset: 0x0005683B
		' (set) Token: 0x0600C58D RID: 50573 RVA: 0x00058645 File Offset: 0x00056845
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004E66 RID: 20070
		' (get) Token: 0x0600C58E RID: 50574 RVA: 0x0005864E File Offset: 0x0005684E
		' (set) Token: 0x0600C58F RID: 50575 RVA: 0x007E0A24 File Offset: 0x007DEC24
		Private _Timer1 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer1
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

		' Token: 0x17004E67 RID: 20071
		' (get) Token: 0x0600C590 RID: 50576 RVA: 0x00058658 File Offset: 0x00056858
		' (set) Token: 0x0600C591 RID: 50577 RVA: 0x007E0A68 File Offset: 0x007DEC68
		Private _Timer2 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer2 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E68 RID: 20072
		' (get) Token: 0x0600C592 RID: 50578 RVA: 0x00058662 File Offset: 0x00056862
		' (set) Token: 0x0600C593 RID: 50579 RVA: 0x007E0AAC File Offset: 0x007DECAC
		Private _CategoryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CategoryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CategoryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CategoryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CategoryToolStripMenuItem = value
				toolStripMenuItem = Me._CategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E69 RID: 20073
		' (get) Token: 0x0600C594 RID: 50580 RVA: 0x0005866C File Offset: 0x0005686C
		' (set) Token: 0x0600C595 RID: 50581 RVA: 0x007E0AF0 File Offset: 0x007DECF0
		Private _SubCategoryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SubCategoryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SubCategoryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SubCategoryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SubCategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SubCategoryToolStripMenuItem = value
				toolStripMenuItem = Me._SubCategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E6A RID: 20074
		' (get) Token: 0x0600C596 RID: 50582 RVA: 0x00058676 File Offset: 0x00056876
		' (set) Token: 0x0600C597 RID: 50583 RVA: 0x007E0B34 File Offset: 0x007DED34
		Private _CompanyInfoToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CompanyInfoToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CompanyInfoToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CompanyInfoToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CompanyInfoToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CompanyInfoToolStripMenuItem = value
				toolStripMenuItem = Me._CompanyInfoToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E6B RID: 20075
		' (get) Token: 0x0600C598 RID: 50584 RVA: 0x00058680 File Offset: 0x00056880
		' (set) Token: 0x0600C599 RID: 50585 RVA: 0x007E0B78 File Offset: 0x007DED78
		Private _UnitMasterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UnitMasterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UnitMasterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UnitMasterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UnitMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UnitMasterToolStripMenuItem = value
				toolStripMenuItem = Me._UnitMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E6C RID: 20076
		' (get) Token: 0x0600C59A RID: 50586 RVA: 0x0005868A File Offset: 0x0005688A
		' (set) Token: 0x0600C59B RID: 50587 RVA: 0x00058694 File Offset: 0x00056894
		Friend Overridable Property BankReconciliationToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E6D RID: 20077
		' (get) Token: 0x0600C59C RID: 50588 RVA: 0x0005869D File Offset: 0x0005689D
		' (set) Token: 0x0600C59D RID: 50589 RVA: 0x007E0BBC File Offset: 0x007DEDBC
		Private _BankMasterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BankMasterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BankMasterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BankMasterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BankMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BankMasterToolStripMenuItem = value
				toolStripMenuItem = Me._BankMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E6E RID: 20078
		' (get) Token: 0x0600C59E RID: 50590 RVA: 0x000586A7 File Offset: 0x000568A7
		' (set) Token: 0x0600C59F RID: 50591 RVA: 0x007E0C00 File Offset: 0x007DEE00
		Private _BranchMasterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BranchMasterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BranchMasterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BranchMasterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BranchMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BranchMasterToolStripMenuItem = value
				toolStripMenuItem = Me._BranchMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E6F RID: 20079
		' (get) Token: 0x0600C5A0 RID: 50592 RVA: 0x000586B1 File Offset: 0x000568B1
		' (set) Token: 0x0600C5A1 RID: 50593 RVA: 0x007E0C44 File Offset: 0x007DEE44
		Private _BankAccountRegistrationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BankAccountRegistrationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BankAccountRegistrationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BankAccountRegistrationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BankAccountRegistrationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BankAccountRegistrationToolStripMenuItem = value
				toolStripMenuItem = Me._BankAccountRegistrationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E70 RID: 20080
		' (get) Token: 0x0600C5A2 RID: 50594 RVA: 0x000586BB File Offset: 0x000568BB
		' (set) Token: 0x0600C5A3 RID: 50595 RVA: 0x007E0C88 File Offset: 0x007DEE88
		Private _FundDepositToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property FundDepositToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._FundDepositToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.FundDepositToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._FundDepositToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._FundDepositToolStripMenuItem = value
				toolStripMenuItem = Me._FundDepositToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E71 RID: 20081
		' (get) Token: 0x0600C5A4 RID: 50596 RVA: 0x000586C5 File Offset: 0x000568C5
		' (set) Token: 0x0600C5A5 RID: 50597 RVA: 0x007E0CCC File Offset: 0x007DEECC
		Private _FundTransferToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property FundTransferToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._FundTransferToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.FundTransferToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._FundTransferToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._FundTransferToolStripMenuItem = value
				toolStripMenuItem = Me._FundTransferToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E72 RID: 20082
		' (get) Token: 0x0600C5A6 RID: 50598 RVA: 0x000586CF File Offset: 0x000568CF
		' (set) Token: 0x0600C5A7 RID: 50599 RVA: 0x007E0D10 File Offset: 0x007DEF10
		Private _PaymentWithdrawalToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PaymentWithdrawalToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PaymentWithdrawalToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PaymentWithdrawalToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PaymentWithdrawalToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PaymentWithdrawalToolStripMenuItem = value
				toolStripMenuItem = Me._PaymentWithdrawalToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E73 RID: 20083
		' (get) Token: 0x0600C5A8 RID: 50600 RVA: 0x000586D9 File Offset: 0x000568D9
		' (set) Token: 0x0600C5A9 RID: 50601 RVA: 0x007E0D54 File Offset: 0x007DEF54
		Private _BankAccountStatementsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BankAccountStatementsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BankAccountStatementsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BankAccountStatementsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BankAccountStatementsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BankAccountStatementsToolStripMenuItem = value
				toolStripMenuItem = Me._BankAccountStatementsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E74 RID: 20084
		' (get) Token: 0x0600C5AA RID: 50602 RVA: 0x000586E3 File Offset: 0x000568E3
		' (set) Token: 0x0600C5AB RID: 50603 RVA: 0x000586ED File Offset: 0x000568ED
		Friend Overridable Property ExportImportExcelToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E75 RID: 20085
		' (get) Token: 0x0600C5AC RID: 50604 RVA: 0x000586F6 File Offset: 0x000568F6
		' (set) Token: 0x0600C5AD RID: 50605 RVA: 0x007E0D98 File Offset: 0x007DEF98
		Private _CustomersToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomersToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomersToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomersToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomersToolStripMenuItem = value
				toolStripMenuItem = Me._CustomersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E76 RID: 20086
		' (get) Token: 0x0600C5AE RID: 50606 RVA: 0x00058700 File Offset: 0x00056900
		' (set) Token: 0x0600C5AF RID: 50607 RVA: 0x007E0DDC File Offset: 0x007DEFDC
		Private _SuppliersToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SuppliersToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SuppliersToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SuppliersToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SuppliersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SuppliersToolStripMenuItem = value
				toolStripMenuItem = Me._SuppliersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E77 RID: 20087
		' (get) Token: 0x0600C5B0 RID: 50608 RVA: 0x0005870A File Offset: 0x0005690A
		' (set) Token: 0x0600C5B1 RID: 50609 RVA: 0x00058714 File Offset: 0x00056914
		Friend Overridable Property DatabaseActivityToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E78 RID: 20088
		' (get) Token: 0x0600C5B2 RID: 50610 RVA: 0x0005871D File Offset: 0x0005691D
		' (set) Token: 0x0600C5B3 RID: 50611 RVA: 0x007E0E20 File Offset: 0x007DF020
		Private _BackupToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property BackupToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BackupToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BackupToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BackupToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BackupToolStripMenuItem1 = value
				toolStripMenuItem = Me._BackupToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E79 RID: 20089
		' (get) Token: 0x0600C5B4 RID: 50612 RVA: 0x00058727 File Offset: 0x00056927
		' (set) Token: 0x0600C5B5 RID: 50613 RVA: 0x007E0E64 File Offset: 0x007DF064
		Private _RestoreToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property RestoreToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RestoreToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RestoreToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._RestoreToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._RestoreToolStripMenuItem1 = value
				toolStripMenuItem = Me._RestoreToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E7A RID: 20090
		' (get) Token: 0x0600C5B6 RID: 50614 RVA: 0x00058731 File Offset: 0x00056931
		' (set) Token: 0x0600C5B7 RID: 50615 RVA: 0x007E0EA8 File Offset: 0x007DF0A8
		Private _SalemanToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalemanToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalemanToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalemanToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalemanToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalemanToolStripMenuItem = value
				toolStripMenuItem = Me._SalemanToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E7B RID: 20091
		' (get) Token: 0x0600C5B8 RID: 50616 RVA: 0x0005873B File Offset: 0x0005693B
		' (set) Token: 0x0600C5B9 RID: 50617 RVA: 0x007E0EEC File Offset: 0x007DF0EC
		Private _SupplierToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property SupplierToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierToolStripMenuItem2 = value
				toolStripMenuItem = Me._SupplierToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E7C RID: 20092
		' (get) Token: 0x0600C5BA RID: 50618 RVA: 0x00058745 File Offset: 0x00056945
		' (set) Token: 0x0600C5BB RID: 50619 RVA: 0x007E0F30 File Offset: 0x007DF130
		Private _ProductsToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property ProductsToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductsToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductsToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductsToolStripMenuItem1 = value
				toolStripMenuItem = Me._ProductsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E7D RID: 20093
		' (get) Token: 0x0600C5BC RID: 50620 RVA: 0x0005874F File Offset: 0x0005694F
		' (set) Token: 0x0600C5BD RID: 50621 RVA: 0x00058759 File Offset: 0x00056959
		Friend Overridable Property ServicesToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004E7E RID: 20094
		' (get) Token: 0x0600C5BE RID: 50622 RVA: 0x00058762 File Offset: 0x00056962
		' (set) Token: 0x0600C5BF RID: 50623 RVA: 0x007E0F74 File Offset: 0x007DF174
		Private _ServiceCreationToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property ServiceCreationToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ServiceCreationToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ServiceCreationToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ServiceCreationToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ServiceCreationToolStripMenuItem1 = value
				toolStripMenuItem = Me._ServiceCreationToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E7F RID: 20095
		' (get) Token: 0x0600C5C0 RID: 50624 RVA: 0x0005876C File Offset: 0x0005696C
		' (set) Token: 0x0600C5C1 RID: 50625 RVA: 0x007E0FB8 File Offset: 0x007DF1B8
		Private _ServiceBillingToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property ServiceBillingToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ServiceBillingToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ServiceBillingToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ServiceBillingToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ServiceBillingToolStripMenuItem2 = value
				toolStripMenuItem = Me._ServiceBillingToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E80 RID: 20096
		' (get) Token: 0x0600C5C2 RID: 50626 RVA: 0x00058776 File Offset: 0x00056976
		' (set) Token: 0x0600C5C3 RID: 50627 RVA: 0x00058780 File Offset: 0x00056980
		Friend Overridable Property VoucherToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004E81 RID: 20097
		' (get) Token: 0x0600C5C4 RID: 50628 RVA: 0x00058789 File Offset: 0x00056989
		' (set) Token: 0x0600C5C5 RID: 50629 RVA: 0x007E0FFC File Offset: 0x007DF1FC
		Private _SendSMSToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SendSMSToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SendSMSToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SendSMSToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SendSMSToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SendSMSToolStripMenuItem1 = value
				toolStripMenuItem = Me._SendSMSToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E82 RID: 20098
		' (get) Token: 0x0600C5C6 RID: 50630 RVA: 0x00058793 File Offset: 0x00056993
		' (set) Token: 0x0600C5C7 RID: 50631 RVA: 0x0005879D File Offset: 0x0005699D
		Friend Overridable Property RecordsToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004E83 RID: 20099
		' (get) Token: 0x0600C5C8 RID: 50632 RVA: 0x000587A6 File Offset: 0x000569A6
		' (set) Token: 0x0600C5C9 RID: 50633 RVA: 0x007E1040 File Offset: 0x007DF240
		Private _CustomerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E84 RID: 20100
		' (get) Token: 0x0600C5CA RID: 50634 RVA: 0x000587B0 File Offset: 0x000569B0
		' (set) Token: 0x0600C5CB RID: 50635 RVA: 0x007E1084 File Offset: 0x007DF284
		Private _SalesmanToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesmanToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesmanToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesmanToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesmanToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesmanToolStripMenuItem = value
				toolStripMenuItem = Me._SalesmanToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E85 RID: 20101
		' (get) Token: 0x0600C5CC RID: 50636 RVA: 0x000587BA File Offset: 0x000569BA
		' (set) Token: 0x0600C5CD RID: 50637 RVA: 0x007E10C8 File Offset: 0x007DF2C8
		Private _SuppliersToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SuppliersToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SuppliersToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SuppliersToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SuppliersToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SuppliersToolStripMenuItem1 = value
				toolStripMenuItem = Me._SuppliersToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E86 RID: 20102
		' (get) Token: 0x0600C5CE RID: 50638 RVA: 0x000587C4 File Offset: 0x000569C4
		' (set) Token: 0x0600C5CF RID: 50639 RVA: 0x007E110C File Offset: 0x007DF30C
		Private _ProductsToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property ProductsToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductsToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductsToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductsToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductsToolStripMenuItem2 = value
				toolStripMenuItem = Me._ProductsToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E87 RID: 20103
		' (get) Token: 0x0600C5D0 RID: 50640 RVA: 0x000587CE File Offset: 0x000569CE
		' (set) Token: 0x0600C5D1 RID: 50641 RVA: 0x007E1150 File Offset: 0x007DF350
		Private _PurchasesToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchasesToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchasesToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchasesToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchasesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchasesToolStripMenuItem = value
				toolStripMenuItem = Me._PurchasesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E88 RID: 20104
		' (get) Token: 0x0600C5D2 RID: 50642 RVA: 0x000587D8 File Offset: 0x000569D8
		' (set) Token: 0x0600C5D3 RID: 50643 RVA: 0x007E1194 File Offset: 0x007DF394
		Private _StockEntryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E89 RID: 20105
		' (get) Token: 0x0600C5D4 RID: 50644 RVA: 0x000587E2 File Offset: 0x000569E2
		' (set) Token: 0x0600C5D5 RID: 50645 RVA: 0x007E11D8 File Offset: 0x007DF3D8
		Private _PurchaseReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8A RID: 20106
		' (get) Token: 0x0600C5D6 RID: 50646 RVA: 0x000587EC File Offset: 0x000569EC
		' (set) Token: 0x0600C5D7 RID: 50647 RVA: 0x007E121C File Offset: 0x007DF41C
		Private _SalesToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property SalesToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesToolStripMenuItem2_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesToolStripMenuItem2 = value
				toolStripMenuItem = Me._SalesToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8B RID: 20107
		' (get) Token: 0x0600C5D8 RID: 50648 RVA: 0x000587F6 File Offset: 0x000569F6
		' (set) Token: 0x0600C5D9 RID: 50649 RVA: 0x007E1260 File Offset: 0x007DF460
		Private _SalesReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesReturnToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesReturnToolStripMenuItem = value
				toolStripMenuItem = Me._SalesReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8C RID: 20108
		' (get) Token: 0x0600C5DA RID: 50650 RVA: 0x00058800 File Offset: 0x00056A00
		' (set) Token: 0x0600C5DB RID: 50651 RVA: 0x007E12A4 File Offset: 0x007DF4A4
		Private _ServicesToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ServicesToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ServicesToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ServicesToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ServicesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ServicesToolStripMenuItem = value
				toolStripMenuItem = Me._ServicesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8D RID: 20109
		' (get) Token: 0x0600C5DC RID: 50652 RVA: 0x0005880A File Offset: 0x00056A0A
		' (set) Token: 0x0600C5DD RID: 50653 RVA: 0x007E12E8 File Offset: 0x007DF4E8
		Private _ServiceBillingToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property ServiceBillingToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ServiceBillingToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ServiceBillingToolStripMenuItem1_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ServiceBillingToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ServiceBillingToolStripMenuItem1 = value
				toolStripMenuItem = Me._ServiceBillingToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8E RID: 20110
		' (get) Token: 0x0600C5DE RID: 50654 RVA: 0x00058814 File Offset: 0x00056A14
		' (set) Token: 0x0600C5DF RID: 50655 RVA: 0x007E132C File Offset: 0x007DF52C
		Private _QuotationsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property QuotationsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._QuotationsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.QuotationsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._QuotationsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._QuotationsToolStripMenuItem = value
				toolStripMenuItem = Me._QuotationsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E8F RID: 20111
		' (get) Token: 0x0600C5E0 RID: 50656 RVA: 0x0005881E File Offset: 0x00056A1E
		' (set) Token: 0x0600C5E1 RID: 50657 RVA: 0x007E1370 File Offset: 0x007DF570
		Private _PaymentsToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PaymentsToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PaymentsToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PaymentsToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PaymentsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PaymentsToolStripMenuItem1 = value
				toolStripMenuItem = Me._PaymentsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E90 RID: 20112
		' (get) Token: 0x0600C5E2 RID: 50658 RVA: 0x00058828 File Offset: 0x00056A28
		' (set) Token: 0x0600C5E3 RID: 50659 RVA: 0x007E13B4 File Offset: 0x007DF5B4
		Private _SMSToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SMSToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SMSToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SMSToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SMSToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SMSToolStripMenuItem1 = value
				toolStripMenuItem = Me._SMSToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E91 RID: 20113
		' (get) Token: 0x0600C5E4 RID: 50660 RVA: 0x00058832 File Offset: 0x00056A32
		' (set) Token: 0x0600C5E5 RID: 50661 RVA: 0x0005883C File Offset: 0x00056A3C
		Friend Overridable Property ReportsToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004E92 RID: 20114
		' (get) Token: 0x0600C5E6 RID: 50662 RVA: 0x00058845 File Offset: 0x00056A45
		' (set) Token: 0x0600C5E7 RID: 50663 RVA: 0x007E13F8 File Offset: 0x007DF5F8
		Private _ServiceBillingToolStripMenuItem3 As ToolStripMenuItem
		Friend Overridable Property ServiceBillingToolStripMenuItem3 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ServiceBillingToolStripMenuItem3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ServiceBillingToolStripMenuItem3_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ServiceBillingToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ServiceBillingToolStripMenuItem3 = value
				toolStripMenuItem = Me._ServiceBillingToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E93 RID: 20115
		' (get) Token: 0x0600C5E8 RID: 50664 RVA: 0x0005884F File Offset: 0x00056A4F
		' (set) Token: 0x0600C5E9 RID: 50665 RVA: 0x007E143C File Offset: 0x007DF63C
		Private _SalesToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SalesToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesToolStripMenuItem1_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesToolStripMenuItem1 = value
				toolStripMenuItem = Me._SalesToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E94 RID: 20116
		' (get) Token: 0x0600C5EA RID: 50666 RVA: 0x00058859 File Offset: 0x00056A59
		' (set) Token: 0x0600C5EB RID: 50667 RVA: 0x007E1480 File Offset: 0x007DF680
		Private _PurchaseToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PurchaseToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseToolStripMenuItem1_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseToolStripMenuItem1 = value
				toolStripMenuItem = Me._PurchaseToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E95 RID: 20117
		' (get) Token: 0x0600C5EC RID: 50668 RVA: 0x00058863 File Offset: 0x00056A63
		' (set) Token: 0x0600C5ED RID: 50669 RVA: 0x007E14C4 File Offset: 0x007DF6C4
		Private _StockEntryToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E96 RID: 20118
		' (get) Token: 0x0600C5EE RID: 50670 RVA: 0x0005886D File Offset: 0x00056A6D
		' (set) Token: 0x0600C5EF RID: 50671 RVA: 0x007E1508 File Offset: 0x007DF708
		Private _StockInAndStockOutToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockInAndStockOutToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockInAndStockOutToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockInAndStockOutToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockInAndStockOutToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockInAndStockOutToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockInAndStockOutToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E97 RID: 20119
		' (get) Token: 0x0600C5F0 RID: 50672 RVA: 0x00058877 File Offset: 0x00056A77
		' (set) Token: 0x0600C5F1 RID: 50673 RVA: 0x007E154C File Offset: 0x007DF74C
		Private _LowStockItemsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LowStockItemsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LowStockItemsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LowStockItemsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LowStockItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LowStockItemsToolStripMenuItem = value
				toolStripMenuItem = Me._LowStockItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E98 RID: 20120
		' (get) Token: 0x0600C5F2 RID: 50674 RVA: 0x00058881 File Offset: 0x00056A81
		' (set) Token: 0x0600C5F3 RID: 50675 RVA: 0x007E1590 File Offset: 0x007DF790
		Private _ExpenditureToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property ExpenditureToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExpenditureToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExpenditureToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExpenditureToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExpenditureToolStripMenuItem1 = value
				toolStripMenuItem = Me._ExpenditureToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E99 RID: 20121
		' (get) Token: 0x0600C5F4 RID: 50676 RVA: 0x0005888B File Offset: 0x00056A8B
		' (set) Token: 0x0600C5F5 RID: 50677 RVA: 0x007E15D4 File Offset: 0x007DF7D4
		Private _BestAndLowSellingItemsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BestAndLowSellingItemsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BestAndLowSellingItemsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BestAndLowSellingItemsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BestAndLowSellingItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BestAndLowSellingItemsToolStripMenuItem = value
				toolStripMenuItem = Me._BestAndLowSellingItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E9A RID: 20122
		' (get) Token: 0x0600C5F6 RID: 50678 RVA: 0x00058895 File Offset: 0x00056A95
		' (set) Token: 0x0600C5F7 RID: 50679 RVA: 0x0005889F File Offset: 0x00056A9F
		Friend Overridable Property GeneralLedgerToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004E9B RID: 20123
		' (get) Token: 0x0600C5F8 RID: 50680 RVA: 0x000588A8 File Offset: 0x00056AA8
		' (set) Token: 0x0600C5F9 RID: 50681 RVA: 0x000588B2 File Offset: 0x00056AB2
		Friend Overridable Property SupplierLedgerToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004E9C RID: 20124
		' (get) Token: 0x0600C5FA RID: 50682 RVA: 0x000588BB File Offset: 0x00056ABB
		' (set) Token: 0x0600C5FB RID: 50683 RVA: 0x007E1618 File Offset: 0x007DF818
		Private _CreditTermsStatementsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CreditTermsStatementsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CreditTermsStatementsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CreditTermsStatementsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CreditTermsStatementsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CreditTermsStatementsToolStripMenuItem = value
				toolStripMenuItem = Me._CreditTermsStatementsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E9D RID: 20125
		' (get) Token: 0x0600C5FC RID: 50684 RVA: 0x000588C5 File Offset: 0x00056AC5
		' (set) Token: 0x0600C5FD RID: 50685 RVA: 0x007E165C File Offset: 0x007DF85C
		Private _TaxToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property TaxToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TaxToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TaxToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TaxToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TaxToolStripMenuItem1 = value
				toolStripMenuItem = Me._TaxToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E9E RID: 20126
		' (get) Token: 0x0600C5FE RID: 50686 RVA: 0x000588CF File Offset: 0x00056ACF
		' (set) Token: 0x0600C5FF RID: 50687 RVA: 0x000588D9 File Offset: 0x00056AD9
		Friend Overridable Property ToolStripStatusLabel4 As ToolStripStatusLabel

		' Token: 0x17004E9F RID: 20127
		' (get) Token: 0x0600C600 RID: 50688 RVA: 0x000588E2 File Offset: 0x00056AE2
		' (set) Token: 0x0600C601 RID: 50689 RVA: 0x000588EC File Offset: 0x00056AEC
		Friend Overridable Property ToolStripStatusLabel1 As ToolStripStatusLabel

		' Token: 0x17004EA0 RID: 20128
		' (get) Token: 0x0600C602 RID: 50690 RVA: 0x000588F5 File Offset: 0x00056AF5
		' (set) Token: 0x0600C603 RID: 50691 RVA: 0x000588FF File Offset: 0x00056AFF
		Friend Overridable Property ToolStripStatusLabel6 As ToolStripStatusLabel

		' Token: 0x17004EA1 RID: 20129
		' (get) Token: 0x0600C604 RID: 50692 RVA: 0x00058908 File Offset: 0x00056B08
		' (set) Token: 0x0600C605 RID: 50693 RVA: 0x00058912 File Offset: 0x00056B12
		Friend Overridable Property ToolStripStatusLabel5 As ToolStripStatusLabel

		' Token: 0x17004EA2 RID: 20130
		' (get) Token: 0x0600C606 RID: 50694 RVA: 0x0005891B File Offset: 0x00056B1B
		' (set) Token: 0x0600C607 RID: 50695 RVA: 0x00058925 File Offset: 0x00056B25
		Friend Overridable Property TransactionToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EA3 RID: 20131
		' (get) Token: 0x0600C608 RID: 50696 RVA: 0x0005892E File Offset: 0x00056B2E
		' (set) Token: 0x0600C609 RID: 50697 RVA: 0x007E16A0 File Offset: 0x007DF8A0
		Private _SaleEntryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleEntryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleEntryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleEntryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleEntryToolStripMenuItem = value
				toolStripMenuItem = Me._SaleEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA4 RID: 20132
		' (get) Token: 0x0600C60A RID: 50698 RVA: 0x00058938 File Offset: 0x00056B38
		' (set) Token: 0x0600C60B RID: 50699 RVA: 0x007E16E4 File Offset: 0x007DF8E4
		Private _SaleReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleReturnToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleReturnToolStripMenuItem = value
				toolStripMenuItem = Me._SaleReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA5 RID: 20133
		' (get) Token: 0x0600C60C RID: 50700 RVA: 0x00058942 File Offset: 0x00056B42
		' (set) Token: 0x0600C60D RID: 50701 RVA: 0x007E1728 File Offset: 0x007DF928
		Private _PurchaseEntryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseEntryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseEntryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseEntryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseEntryToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA6 RID: 20134
		' (get) Token: 0x0600C60E RID: 50702 RVA: 0x0005894C File Offset: 0x00056B4C
		' (set) Token: 0x0600C60F RID: 50703 RVA: 0x007E176C File Offset: 0x007DF96C
		Private _PurchaseReturnToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnToolStripMenuItem1 = value
				toolStripMenuItem = Me._PurchaseReturnToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA7 RID: 20135
		' (get) Token: 0x0600C610 RID: 50704 RVA: 0x00058956 File Offset: 0x00056B56
		' (set) Token: 0x0600C611 RID: 50705 RVA: 0x007E17B0 File Offset: 0x007DF9B0
		Private _QuotationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property QuotationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._QuotationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.QuotationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._QuotationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._QuotationToolStripMenuItem = value
				toolStripMenuItem = Me._QuotationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA8 RID: 20136
		' (get) Token: 0x0600C612 RID: 50706 RVA: 0x00058960 File Offset: 0x00056B60
		' (set) Token: 0x0600C613 RID: 50707 RVA: 0x007E17F4 File Offset: 0x007DF9F4
		Private _PurchaseOrderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseOrderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseOrderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseOrderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseOrderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseOrderToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseOrderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EA9 RID: 20137
		' (get) Token: 0x0600C614 RID: 50708 RVA: 0x0005896A File Offset: 0x00056B6A
		' (set) Token: 0x0600C615 RID: 50709 RVA: 0x007E1838 File Offset: 0x007DFA38
		Private _ReceiptToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ReceiptToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ReceiptToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ReceiptToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ReceiptToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ReceiptToolStripMenuItem = value
				toolStripMenuItem = Me._ReceiptToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EAA RID: 20138
		' (get) Token: 0x0600C616 RID: 50710 RVA: 0x00058974 File Offset: 0x00056B74
		' (set) Token: 0x0600C617 RID: 50711 RVA: 0x007E187C File Offset: 0x007DFA7C
		Private _PaymentToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PaymentToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PaymentToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PaymentToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PaymentToolStripMenuItem = value
				toolStripMenuItem = Me._PaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EAB RID: 20139
		' (get) Token: 0x0600C618 RID: 50712 RVA: 0x0005897E File Offset: 0x00056B7E
		' (set) Token: 0x0600C619 RID: 50713 RVA: 0x007E18C0 File Offset: 0x007DFAC0
		Private _StockStatusToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockStatusToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockStatusToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockStatusToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockStatusToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockStatusToolStripMenuItem = value
				toolStripMenuItem = Me._StockStatusToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EAC RID: 20140
		' (get) Token: 0x0600C61A RID: 50714 RVA: 0x00058988 File Offset: 0x00056B88
		' (set) Token: 0x0600C61B RID: 50715 RVA: 0x007E1904 File Offset: 0x007DFB04
		Private _CustomerToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property CustomerToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerToolStripMenuItem1 = value
				toolStripMenuItem = Me._CustomerToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EAD RID: 20141
		' (get) Token: 0x0600C61C RID: 50716 RVA: 0x00058992 File Offset: 0x00056B92
		' (set) Token: 0x0600C61D RID: 50717 RVA: 0x007E1948 File Offset: 0x007DFB48
		Private _PurchaseOrderToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property PurchaseOrderToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseOrderToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseOrderToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseOrderToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseOrderToolStripMenuItem2 = value
				toolStripMenuItem = Me._PurchaseOrderToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EAE RID: 20142
		' (get) Token: 0x0600C61E RID: 50718 RVA: 0x0005899C File Offset: 0x00056B9C
		' (set) Token: 0x0600C61F RID: 50719 RVA: 0x000589A6 File Offset: 0x00056BA6
		Friend Overridable Property BarcodeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EAF RID: 20143
		' (get) Token: 0x0600C620 RID: 50720 RVA: 0x000589AF File Offset: 0x00056BAF
		' (set) Token: 0x0600C621 RID: 50721 RVA: 0x007E198C File Offset: 0x007DFB8C
		Private _ReceiptsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ReceiptsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ReceiptsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ReceiptsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ReceiptsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ReceiptsToolStripMenuItem = value
				toolStripMenuItem = Me._ReceiptsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB0 RID: 20144
		' (get) Token: 0x0600C622 RID: 50722 RVA: 0x000589B9 File Offset: 0x00056BB9
		' (set) Token: 0x0600C623 RID: 50723 RVA: 0x000589C3 File Offset: 0x00056BC3
		Friend Overridable Property LogoutToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EB1 RID: 20145
		' (get) Token: 0x0600C624 RID: 50724 RVA: 0x000589CC File Offset: 0x00056BCC
		' (set) Token: 0x0600C625 RID: 50725 RVA: 0x000589D6 File Offset: 0x00056BD6
		Friend Overridable Property ContactToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EB2 RID: 20146
		' (get) Token: 0x0600C626 RID: 50726 RVA: 0x000589DF File Offset: 0x00056BDF
		' (set) Token: 0x0600C627 RID: 50727 RVA: 0x007E19D0 File Offset: 0x007DFBD0
		Private _SMSSeetingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SMSSeetingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SMSSeetingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SMSSeetingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SMSSeetingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SMSSeetingToolStripMenuItem = value
				toolStripMenuItem = Me._SMSSeetingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB3 RID: 20147
		' (get) Token: 0x0600C628 RID: 50728 RVA: 0x000589E9 File Offset: 0x00056BE9
		' (set) Token: 0x0600C629 RID: 50729 RVA: 0x007E1A14 File Offset: 0x007DFC14
		Private _EmailSettingToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property EmailSettingToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EmailSettingToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EmailSettingToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EmailSettingToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EmailSettingToolStripMenuItem1 = value
				toolStripMenuItem = Me._EmailSettingToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB4 RID: 20148
		' (get) Token: 0x0600C62A RID: 50730 RVA: 0x000589F3 File Offset: 0x00056BF3
		' (set) Token: 0x0600C62B RID: 50731 RVA: 0x007E1A58 File Offset: 0x007DFC58
		Private _UserPermissionSettingsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UserPermissionSettingsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UserPermissionSettingsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UserPermissionSettingsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UserPermissionSettingsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UserPermissionSettingsToolStripMenuItem = value
				toolStripMenuItem = Me._UserPermissionSettingsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB5 RID: 20149
		' (get) Token: 0x0600C62C RID: 50732 RVA: 0x000589FD File Offset: 0x00056BFD
		' (set) Token: 0x0600C62D RID: 50733 RVA: 0x007E1A9C File Offset: 0x007DFC9C
		Private _TerminalPrinterSettingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TerminalPrinterSettingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TerminalPrinterSettingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TerminalPrinterSettingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TerminalPrinterSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TerminalPrinterSettingToolStripMenuItem = value
				toolStripMenuItem = Me._TerminalPrinterSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB6 RID: 20150
		' (get) Token: 0x0600C62E RID: 50734 RVA: 0x00058A07 File Offset: 0x00056C07
		' (set) Token: 0x0600C62F RID: 50735 RVA: 0x00058A11 File Offset: 0x00056C11
		Friend Overridable Property CommunicationToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EB7 RID: 20151
		' (get) Token: 0x0600C630 RID: 50736 RVA: 0x00058A1A File Offset: 0x00056C1A
		' (set) Token: 0x0600C631 RID: 50737 RVA: 0x007E1AE0 File Offset: 0x007DFCE0
		Private _SendSMSToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SendSMSToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SendSMSToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SendSMSToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SendSMSToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SendSMSToolStripMenuItem = value
				toolStripMenuItem = Me._SendSMSToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB8 RID: 20152
		' (get) Token: 0x0600C632 RID: 50738 RVA: 0x00058A24 File Offset: 0x00056C24
		' (set) Token: 0x0600C633 RID: 50739 RVA: 0x007E1B24 File Offset: 0x007DFD24
		Private _SendEMailToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SendEMailToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SendEMailToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SendEMailToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SendEMailToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SendEMailToolStripMenuItem = value
				toolStripMenuItem = Me._SendEMailToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EB9 RID: 20153
		' (get) Token: 0x0600C634 RID: 50740 RVA: 0x00058A2E File Offset: 0x00056C2E
		' (set) Token: 0x0600C635 RID: 50741 RVA: 0x007E1B68 File Offset: 0x007DFD68
		Private _StockEntryToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem2 = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EBA RID: 20154
		' (get) Token: 0x0600C636 RID: 50742 RVA: 0x00058A38 File Offset: 0x00056C38
		' (set) Token: 0x0600C637 RID: 50743 RVA: 0x007E1BAC File Offset: 0x007DFDAC
		Private _StockAdjustmentToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockAdjustmentToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockAdjustmentToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockAdjustmentToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockAdjustmentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockAdjustmentToolStripMenuItem = value
				toolStripMenuItem = Me._StockAdjustmentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EBB RID: 20155
		' (get) Token: 0x0600C638 RID: 50744 RVA: 0x00058A42 File Offset: 0x00056C42
		' (set) Token: 0x0600C639 RID: 50745 RVA: 0x007E1BF0 File Offset: 0x007DFDF0
		Private _StockAdjustmentToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockAdjustmentToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockAdjustmentToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockAdjustmentToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockAdjustmentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockAdjustmentToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockAdjustmentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EBC RID: 20156
		' (get) Token: 0x0600C63A RID: 50746 RVA: 0x00058A4C File Offset: 0x00056C4C
		' (set) Token: 0x0600C63B RID: 50747 RVA: 0x00058A56 File Offset: 0x00056C56
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17004EBD RID: 20157
		' (get) Token: 0x0600C63C RID: 50748 RVA: 0x00058A5F File Offset: 0x00056C5F
		' (set) Token: 0x0600C63D RID: 50749 RVA: 0x00058A69 File Offset: 0x00056C69
		Friend Overridable Property Label11 As Label

		' Token: 0x17004EBE RID: 20158
		' (get) Token: 0x0600C63E RID: 50750 RVA: 0x00058A72 File Offset: 0x00056C72
		' (set) Token: 0x0600C63F RID: 50751 RVA: 0x007E1C34 File Offset: 0x007DFE34
		Private _Timer3 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer3 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer3_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer3
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer3 = value
				timer = Me._Timer3
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EBF RID: 20159
		' (get) Token: 0x0600C640 RID: 50752 RVA: 0x00058A7C File Offset: 0x00056C7C
		' (set) Token: 0x0600C641 RID: 50753 RVA: 0x00058A86 File Offset: 0x00056C86
		Friend Overridable Property Label12 As Label

		' Token: 0x17004EC0 RID: 20160
		' (get) Token: 0x0600C642 RID: 50754 RVA: 0x00058A8F File Offset: 0x00056C8F
		' (set) Token: 0x0600C643 RID: 50755 RVA: 0x00058A99 File Offset: 0x00056C99
		Friend Overridable Property TableLayoutPanel6 As TableLayoutPanel

		' Token: 0x17004EC1 RID: 20161
		' (get) Token: 0x0600C644 RID: 50756 RVA: 0x00058AA2 File Offset: 0x00056CA2
		' (set) Token: 0x0600C645 RID: 50757 RVA: 0x00058AAC File Offset: 0x00056CAC
		Friend Overridable Property Label13 As Label

		' Token: 0x17004EC2 RID: 20162
		' (get) Token: 0x0600C646 RID: 50758 RVA: 0x00058AB5 File Offset: 0x00056CB5
		' (set) Token: 0x0600C647 RID: 50759 RVA: 0x00058ABF File Offset: 0x00056CBF
		Friend Overridable Property Label14 As Label

		' Token: 0x17004EC3 RID: 20163
		' (get) Token: 0x0600C648 RID: 50760 RVA: 0x00058AC8 File Offset: 0x00056CC8
		' (set) Token: 0x0600C649 RID: 50761 RVA: 0x00058AD2 File Offset: 0x00056CD2
		Friend Overridable Property Label15 As Label

		' Token: 0x17004EC4 RID: 20164
		' (get) Token: 0x0600C64A RID: 50762 RVA: 0x00058ADB File Offset: 0x00056CDB
		' (set) Token: 0x0600C64B RID: 50763 RVA: 0x00058AE5 File Offset: 0x00056CE5
		Friend Overridable Property Label16 As Label

		' Token: 0x17004EC5 RID: 20165
		' (get) Token: 0x0600C64C RID: 50764 RVA: 0x00058AEE File Offset: 0x00056CEE
		' (set) Token: 0x0600C64D RID: 50765 RVA: 0x00058AF8 File Offset: 0x00056CF8
		Friend Overridable Property Label22 As Label

		' Token: 0x17004EC6 RID: 20166
		' (get) Token: 0x0600C64E RID: 50766 RVA: 0x00058B01 File Offset: 0x00056D01
		' (set) Token: 0x0600C64F RID: 50767 RVA: 0x00058B0B File Offset: 0x00056D0B
		Friend Overridable Property Label21 As Label

		' Token: 0x17004EC7 RID: 20167
		' (get) Token: 0x0600C650 RID: 50768 RVA: 0x00058B14 File Offset: 0x00056D14
		' (set) Token: 0x0600C651 RID: 50769 RVA: 0x00058B1E File Offset: 0x00056D1E
		Friend Overridable Property TableLayoutPanel7 As TableLayoutPanel

		' Token: 0x17004EC8 RID: 20168
		' (get) Token: 0x0600C652 RID: 50770 RVA: 0x00058B27 File Offset: 0x00056D27
		' (set) Token: 0x0600C653 RID: 50771 RVA: 0x00058B31 File Offset: 0x00056D31
		Friend Overridable Property Label23 As Label

		' Token: 0x17004EC9 RID: 20169
		' (get) Token: 0x0600C654 RID: 50772 RVA: 0x00058B3A File Offset: 0x00056D3A
		' (set) Token: 0x0600C655 RID: 50773 RVA: 0x00058B44 File Offset: 0x00056D44
		Friend Overridable Property Label24 As Label

		' Token: 0x17004ECA RID: 20170
		' (get) Token: 0x0600C656 RID: 50774 RVA: 0x00058B4D File Offset: 0x00056D4D
		' (set) Token: 0x0600C657 RID: 50775 RVA: 0x00058B57 File Offset: 0x00056D57
		Friend Overridable Property Label25 As Label

		' Token: 0x17004ECB RID: 20171
		' (get) Token: 0x0600C658 RID: 50776 RVA: 0x00058B60 File Offset: 0x00056D60
		' (set) Token: 0x0600C659 RID: 50777 RVA: 0x00058B6A File Offset: 0x00056D6A
		Friend Overridable Property Label26 As Label

		' Token: 0x17004ECC RID: 20172
		' (get) Token: 0x0600C65A RID: 50778 RVA: 0x00058B73 File Offset: 0x00056D73
		' (set) Token: 0x0600C65B RID: 50779 RVA: 0x00058B7D File Offset: 0x00056D7D
		Friend Overridable Property TableLayoutPanel8 As TableLayoutPanel

		' Token: 0x17004ECD RID: 20173
		' (get) Token: 0x0600C65C RID: 50780 RVA: 0x00058B86 File Offset: 0x00056D86
		' (set) Token: 0x0600C65D RID: 50781 RVA: 0x00058B90 File Offset: 0x00056D90
		Friend Overridable Property Label27 As Label

		' Token: 0x17004ECE RID: 20174
		' (get) Token: 0x0600C65E RID: 50782 RVA: 0x00058B99 File Offset: 0x00056D99
		' (set) Token: 0x0600C65F RID: 50783 RVA: 0x00058BA3 File Offset: 0x00056DA3
		Friend Overridable Property Label28 As Label

		' Token: 0x17004ECF RID: 20175
		' (get) Token: 0x0600C660 RID: 50784 RVA: 0x00058BAC File Offset: 0x00056DAC
		' (set) Token: 0x0600C661 RID: 50785 RVA: 0x00058BB6 File Offset: 0x00056DB6
		Friend Overridable Property Label29 As Label

		' Token: 0x17004ED0 RID: 20176
		' (get) Token: 0x0600C662 RID: 50786 RVA: 0x00058BBF File Offset: 0x00056DBF
		' (set) Token: 0x0600C663 RID: 50787 RVA: 0x00058BC9 File Offset: 0x00056DC9
		Friend Overridable Property Label30 As Label

		' Token: 0x17004ED1 RID: 20177
		' (get) Token: 0x0600C664 RID: 50788 RVA: 0x00058BD2 File Offset: 0x00056DD2
		' (set) Token: 0x0600C665 RID: 50789 RVA: 0x00058BDC File Offset: 0x00056DDC
		Friend Overridable Property Label31 As Label

		' Token: 0x17004ED2 RID: 20178
		' (get) Token: 0x0600C666 RID: 50790 RVA: 0x00058BE5 File Offset: 0x00056DE5
		' (set) Token: 0x0600C667 RID: 50791 RVA: 0x00058BEF File Offset: 0x00056DEF
		Friend Overridable Property Label32 As Label

		' Token: 0x17004ED3 RID: 20179
		' (get) Token: 0x0600C668 RID: 50792 RVA: 0x00058BF8 File Offset: 0x00056DF8
		' (set) Token: 0x0600C669 RID: 50793 RVA: 0x00058C02 File Offset: 0x00056E02
		Friend Overridable Property Label33 As Label

		' Token: 0x17004ED4 RID: 20180
		' (get) Token: 0x0600C66A RID: 50794 RVA: 0x00058C0B File Offset: 0x00056E0B
		' (set) Token: 0x0600C66B RID: 50795 RVA: 0x00058C15 File Offset: 0x00056E15
		Friend Overridable Property Label34 As Label

		' Token: 0x17004ED5 RID: 20181
		' (get) Token: 0x0600C66C RID: 50796 RVA: 0x00058C1E File Offset: 0x00056E1E
		' (set) Token: 0x0600C66D RID: 50797 RVA: 0x007E1C78 File Offset: 0x007DFE78
		Private _SaleInvoiceCodeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleInvoiceCodeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleInvoiceCodeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleInvoiceCodeToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleInvoiceCodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleInvoiceCodeToolStripMenuItem = value
				toolStripMenuItem = Me._SaleInvoiceCodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004ED6 RID: 20182
		' (get) Token: 0x0600C66E RID: 50798 RVA: 0x00058C28 File Offset: 0x00056E28
		' (set) Token: 0x0600C66F RID: 50799 RVA: 0x007E1CBC File Offset: 0x007DFEBC
		Private _AutoRoundoffToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property AutoRoundoffToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AutoRoundoffToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AutoRoundoffToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AutoRoundoffToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AutoRoundoffToolStripMenuItem = value
				toolStripMenuItem = Me._AutoRoundoffToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004ED7 RID: 20183
		' (get) Token: 0x0600C670 RID: 50800 RVA: 0x00058C32 File Offset: 0x00056E32
		' (set) Token: 0x0600C671 RID: 50801 RVA: 0x00058C3C File Offset: 0x00056E3C
		Friend Overridable Property ToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004ED8 RID: 20184
		' (get) Token: 0x0600C672 RID: 50802 RVA: 0x00058C45 File Offset: 0x00056E45
		' (set) Token: 0x0600C673 RID: 50803 RVA: 0x00058C4F File Offset: 0x00056E4F
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004ED9 RID: 20185
		' (get) Token: 0x0600C674 RID: 50804 RVA: 0x00058C58 File Offset: 0x00056E58
		' (set) Token: 0x0600C675 RID: 50805 RVA: 0x00058C62 File Offset: 0x00056E62
		Friend Overridable Property Label48 As Label

		' Token: 0x17004EDA RID: 20186
		' (get) Token: 0x0600C676 RID: 50806 RVA: 0x00058C6B File Offset: 0x00056E6B
		' (set) Token: 0x0600C677 RID: 50807 RVA: 0x00058C75 File Offset: 0x00056E75
		Friend Overridable Property Label47 As Label

		' Token: 0x17004EDB RID: 20187
		' (get) Token: 0x0600C678 RID: 50808 RVA: 0x00058C7E File Offset: 0x00056E7E
		' (set) Token: 0x0600C679 RID: 50809 RVA: 0x00058C88 File Offset: 0x00056E88
		Friend Overridable Property Label46 As Label

		' Token: 0x17004EDC RID: 20188
		' (get) Token: 0x0600C67A RID: 50810 RVA: 0x00058C91 File Offset: 0x00056E91
		' (set) Token: 0x0600C67B RID: 50811 RVA: 0x00058C9B File Offset: 0x00056E9B
		Friend Overridable Property Label45 As Label

		' Token: 0x17004EDD RID: 20189
		' (get) Token: 0x0600C67C RID: 50812 RVA: 0x00058CA4 File Offset: 0x00056EA4
		' (set) Token: 0x0600C67D RID: 50813 RVA: 0x00058CAE File Offset: 0x00056EAE
		Friend Overridable Property Label44 As Label

		' Token: 0x17004EDE RID: 20190
		' (get) Token: 0x0600C67E RID: 50814 RVA: 0x00058CB7 File Offset: 0x00056EB7
		' (set) Token: 0x0600C67F RID: 50815 RVA: 0x00058CC1 File Offset: 0x00056EC1
		Friend Overridable Property Label43 As Label

		' Token: 0x17004EDF RID: 20191
		' (get) Token: 0x0600C680 RID: 50816 RVA: 0x00058CCA File Offset: 0x00056ECA
		' (set) Token: 0x0600C681 RID: 50817 RVA: 0x007E1D00 File Offset: 0x007DFF00
		Private _AutoBackupToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property AutoBackupToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AutoBackupToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AutoBackupToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AutoBackupToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AutoBackupToolStripMenuItem = value
				toolStripMenuItem = Me._AutoBackupToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE0 RID: 20192
		' (get) Token: 0x0600C682 RID: 50818 RVA: 0x00058CD4 File Offset: 0x00056ED4
		' (set) Token: 0x0600C683 RID: 50819 RVA: 0x007E1D44 File Offset: 0x007DFF44
		Private _TermsAndConditionsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TermsAndConditionsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TermsAndConditionsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TermsAndConditionsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TermsAndConditionsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TermsAndConditionsToolStripMenuItem = value
				toolStripMenuItem = Me._TermsAndConditionsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE1 RID: 20193
		' (get) Token: 0x0600C684 RID: 50820 RVA: 0x00058CDE File Offset: 0x00056EDE
		' (set) Token: 0x0600C685 RID: 50821 RVA: 0x00058CE8 File Offset: 0x00056EE8
		Friend Overridable Property GSTRToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EE2 RID: 20194
		' (get) Token: 0x0600C686 RID: 50822 RVA: 0x00058CF1 File Offset: 0x00056EF1
		' (set) Token: 0x0600C687 RID: 50823 RVA: 0x007E1D88 File Offset: 0x007DFF88
		Private _SaleRegisterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleRegisterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleRegisterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleRegisterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleRegisterToolStripMenuItem = value
				toolStripMenuItem = Me._SaleRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE3 RID: 20195
		' (get) Token: 0x0600C688 RID: 50824 RVA: 0x00058CFB File Offset: 0x00056EFB
		' (set) Token: 0x0600C689 RID: 50825 RVA: 0x007E1DCC File Offset: 0x007DFFCC
		Private _PurchaseRegisterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseRegisterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseRegisterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseRegisterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseRegisterToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE4 RID: 20196
		' (get) Token: 0x0600C68A RID: 50826 RVA: 0x00058D05 File Offset: 0x00056F05
		' (set) Token: 0x0600C68B RID: 50827 RVA: 0x007E1E10 File Offset: 0x007E0010
		Private _SalesReturnRegisterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesReturnRegisterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesReturnRegisterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesReturnRegisterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesReturnRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesReturnRegisterToolStripMenuItem = value
				toolStripMenuItem = Me._SalesReturnRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE5 RID: 20197
		' (get) Token: 0x0600C68C RID: 50828 RVA: 0x00058D0F File Offset: 0x00056F0F
		' (set) Token: 0x0600C68D RID: 50829 RVA: 0x007E1E54 File Offset: 0x007E0054
		Private _PurchaseReturnRegisterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnRegisterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnRegisterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnRegisterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnRegisterToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseReturnRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE6 RID: 20198
		' (get) Token: 0x0600C68E RID: 50830 RVA: 0x00058D19 File Offset: 0x00056F19
		' (set) Token: 0x0600C68F RID: 50831 RVA: 0x00058D23 File Offset: 0x00056F23
		Friend Overridable Property TaxCalculatorToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004EE7 RID: 20199
		' (get) Token: 0x0600C690 RID: 50832 RVA: 0x00058D2C File Offset: 0x00056F2C
		' (set) Token: 0x0600C691 RID: 50833 RVA: 0x007E1E98 File Offset: 0x007E0098
		Private _OutputTaxToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property OutputTaxToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._OutputTaxToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.OutputTaxToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._OutputTaxToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._OutputTaxToolStripMenuItem = value
				toolStripMenuItem = Me._OutputTaxToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE8 RID: 20200
		' (get) Token: 0x0600C692 RID: 50834 RVA: 0x00058D36 File Offset: 0x00056F36
		' (set) Token: 0x0600C693 RID: 50835 RVA: 0x007E1EDC File Offset: 0x007E00DC
		Private _InputTaxToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property InputTaxToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._InputTaxToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.InputTaxToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._InputTaxToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._InputTaxToolStripMenuItem = value
				toolStripMenuItem = Me._InputTaxToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EE9 RID: 20201
		' (get) Token: 0x0600C694 RID: 50836 RVA: 0x00058D40 File Offset: 0x00056F40
		' (set) Token: 0x0600C695 RID: 50837 RVA: 0x007E1F20 File Offset: 0x007E0120
		Private _GSTR1ToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property GSTR1ToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._GSTR1ToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.GSTR1ToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._GSTR1ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._GSTR1ToolStripMenuItem = value
				toolStripMenuItem = Me._GSTR1ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EEA RID: 20202
		' (get) Token: 0x0600C696 RID: 50838 RVA: 0x00058D4A File Offset: 0x00056F4A
		' (set) Token: 0x0600C697 RID: 50839 RVA: 0x007E1F64 File Offset: 0x007E0164
		Private _GSTR3BToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property GSTR3BToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._GSTR3BToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.GSTR3BToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._GSTR3BToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._GSTR3BToolStripMenuItem = value
				toolStripMenuItem = Me._GSTR3BToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EEB RID: 20203
		' (get) Token: 0x0600C698 RID: 50840 RVA: 0x00058D54 File Offset: 0x00056F54
		' (set) Token: 0x0600C699 RID: 50841 RVA: 0x007E1FA8 File Offset: 0x007E01A8
		Private _ToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem2 = value
				toolStripMenuItem = Me._ToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EEC RID: 20204
		' (get) Token: 0x0600C69A RID: 50842 RVA: 0x00058D5E File Offset: 0x00056F5E
		' (set) Token: 0x0600C69B RID: 50843 RVA: 0x007E1FEC File Offset: 0x007E01EC
		Private _ToolStripMenuItem3 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem3 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem3_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem3 = value
				toolStripMenuItem = Me._ToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EED RID: 20205
		' (get) Token: 0x0600C69C RID: 50844 RVA: 0x00058D68 File Offset: 0x00056F68
		' (set) Token: 0x0600C69D RID: 50845 RVA: 0x007E2030 File Offset: 0x007E0230
		Private _ToolStripMenuItem4 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem4 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem4_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem4
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem4 = value
				toolStripMenuItem = Me._ToolStripMenuItem4
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EEE RID: 20206
		' (get) Token: 0x0600C69E RID: 50846 RVA: 0x00058D72 File Offset: 0x00056F72
		' (set) Token: 0x0600C69F RID: 50847 RVA: 0x007E2074 File Offset: 0x007E0274
		Private _SaleGSTReportToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleGSTReportToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleGSTReportToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleGSTReportToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleGSTReportToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleGSTReportToolStripMenuItem = value
				toolStripMenuItem = Me._SaleGSTReportToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EEF RID: 20207
		' (get) Token: 0x0600C6A0 RID: 50848 RVA: 0x00058D7C File Offset: 0x00056F7C
		' (set) Token: 0x0600C6A1 RID: 50849 RVA: 0x007E20B8 File Offset: 0x007E02B8
		Private _DashBoardToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DashBoardToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DashBoardToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DashBoardToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DashBoardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DashBoardToolStripMenuItem = value
				toolStripMenuItem = Me._DashBoardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF0 RID: 20208
		' (get) Token: 0x0600C6A2 RID: 50850 RVA: 0x00058D86 File Offset: 0x00056F86
		' (set) Token: 0x0600C6A3 RID: 50851 RVA: 0x007E20FC File Offset: 0x007E02FC
		Private _BalanceSheetToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BalanceSheetToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BalanceSheetToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BalanceSheetToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BalanceSheetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BalanceSheetToolStripMenuItem = value
				toolStripMenuItem = Me._BalanceSheetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF1 RID: 20209
		' (get) Token: 0x0600C6A4 RID: 50852 RVA: 0x00058D90 File Offset: 0x00056F90
		' (set) Token: 0x0600C6A5 RID: 50853 RVA: 0x007E2140 File Offset: 0x007E0340
		Private _ProfitAndLossToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProfitAndLossToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProfitAndLossToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProfitAndLossToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProfitAndLossToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProfitAndLossToolStripMenuItem = value
				toolStripMenuItem = Me._ProfitAndLossToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF2 RID: 20210
		' (get) Token: 0x0600C6A6 RID: 50854 RVA: 0x00058D9A File Offset: 0x00056F9A
		' (set) Token: 0x0600C6A7 RID: 50855 RVA: 0x007E2184 File Offset: 0x007E0384
		Private _TrialBalanceToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TrialBalanceToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TrialBalanceToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TrialBalanceToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TrialBalanceToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TrialBalanceToolStripMenuItem = value
				toolStripMenuItem = Me._TrialBalanceToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF3 RID: 20211
		' (get) Token: 0x0600C6A8 RID: 50856 RVA: 0x00058DA4 File Offset: 0x00056FA4
		' (set) Token: 0x0600C6A9 RID: 50857 RVA: 0x007E21C8 File Offset: 0x007E03C8
		Private _GeneralLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property GeneralLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._GeneralLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.GeneralLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._GeneralLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._GeneralLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._GeneralLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF4 RID: 20212
		' (get) Token: 0x0600C6AA RID: 50858 RVA: 0x00058DAE File Offset: 0x00056FAE
		' (set) Token: 0x0600C6AB RID: 50859 RVA: 0x007E220C File Offset: 0x007E040C
		Private _DayBookToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DayBookToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DayBookToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DayBookToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DayBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DayBookToolStripMenuItem = value
				toolStripMenuItem = Me._DayBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF5 RID: 20213
		' (get) Token: 0x0600C6AC RID: 50860 RVA: 0x00058DB8 File Offset: 0x00056FB8
		' (set) Token: 0x0600C6AD RID: 50861 RVA: 0x007E2250 File Offset: 0x007E0450
		Private _SalesmanCommissionToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesmanCommissionToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesmanCommissionToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesmanCommissionToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesmanCommissionToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesmanCommissionToolStripMenuItem = value
				toolStripMenuItem = Me._SalesmanCommissionToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF6 RID: 20214
		' (get) Token: 0x0600C6AE RID: 50862 RVA: 0x00058DC2 File Offset: 0x00056FC2
		' (set) Token: 0x0600C6AF RID: 50863 RVA: 0x007E2294 File Offset: 0x007E0494
		Private _SupplierLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SupplierLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._SupplierLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF7 RID: 20215
		' (get) Token: 0x0600C6B0 RID: 50864 RVA: 0x00058DCC File Offset: 0x00056FCC
		' (set) Token: 0x0600C6B1 RID: 50865 RVA: 0x007E22D8 File Offset: 0x007E04D8
		Private _CustomerLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF8 RID: 20216
		' (get) Token: 0x0600C6B2 RID: 50866 RVA: 0x00058DD6 File Offset: 0x00056FD6
		' (set) Token: 0x0600C6B3 RID: 50867 RVA: 0x007E231C File Offset: 0x007E051C
		Private _SalesmanLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesmanLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesmanLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesmanLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesmanLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesmanLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._SalesmanLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EF9 RID: 20217
		' (get) Token: 0x0600C6B4 RID: 50868 RVA: 0x00058DE0 File Offset: 0x00056FE0
		' (set) Token: 0x0600C6B5 RID: 50869 RVA: 0x007E2360 File Offset: 0x007E0560
		Private _CashBookToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CashBookToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CashBookToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CashBookToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CashBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CashBookToolStripMenuItem = value
				toolStripMenuItem = Me._CashBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EFA RID: 20218
		' (get) Token: 0x0600C6B6 RID: 50870 RVA: 0x00058DEA File Offset: 0x00056FEA
		' (set) Token: 0x0600C6B7 RID: 50871 RVA: 0x007E23A4 File Offset: 0x007E05A4
		Private _BankBalanceBookToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BankBalanceBookToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BankBalanceBookToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BankBalanceBookToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BankBalanceBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BankBalanceBookToolStripMenuItem = value
				toolStripMenuItem = Me._BankBalanceBookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EFB RID: 20219
		' (get) Token: 0x0600C6B8 RID: 50872 RVA: 0x00058DF4 File Offset: 0x00056FF4
		' (set) Token: 0x0600C6B9 RID: 50873 RVA: 0x00058DFE File Offset: 0x00056FFE
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17004EFC RID: 20220
		' (get) Token: 0x0600C6BA RID: 50874 RVA: 0x00058E07 File Offset: 0x00057007
		' (set) Token: 0x0600C6BB RID: 50875 RVA: 0x007E23E8 File Offset: 0x007E05E8
		Private _BackgroundWorker1 As BackgroundWorker
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker
			<CompilerGenerated()>
			Get
				Return Me._BackgroundWorker1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As BackgroundWorker)
				Dim doWorkEventHandler As DoWorkEventHandler = AddressOf Me.BackgroundWorker1_DoWork
				Dim runWorkerCompletedEventHandler As RunWorkerCompletedEventHandler = AddressOf Me.BackgroundWorker1_RunWorkerCompleted
				Dim backgroundWorker As BackgroundWorker = Me._BackgroundWorker1
				If backgroundWorker IsNot Nothing Then
					RemoveHandler backgroundWorker.DoWork, doWorkEventHandler
					RemoveHandler backgroundWorker.RunWorkerCompleted, runWorkerCompletedEventHandler
				End If
				Me._BackgroundWorker1 = value
				backgroundWorker = Me._BackgroundWorker1
				If backgroundWorker IsNot Nothing Then
					AddHandler backgroundWorker.DoWork, doWorkEventHandler
					AddHandler backgroundWorker.RunWorkerCompleted, runWorkerCompletedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EFD RID: 20221
		' (get) Token: 0x0600C6BC RID: 50876 RVA: 0x00058E11 File Offset: 0x00057011
		' (set) Token: 0x0600C6BD RID: 50877 RVA: 0x007E2448 File Offset: 0x007E0648
		Private _ToolStripMenuItem6 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem6 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem6_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem6
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem6 = value
				toolStripMenuItem = Me._ToolStripMenuItem6
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EFE RID: 20222
		' (get) Token: 0x0600C6BE RID: 50878 RVA: 0x00058E1B File Offset: 0x0005701B
		' (set) Token: 0x0600C6BF RID: 50879 RVA: 0x007E248C File Offset: 0x007E068C
		Private _ToolStripMenuItem8 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem8 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem8_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem8
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem8 = value
				toolStripMenuItem = Me._ToolStripMenuItem8
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004EFF RID: 20223
		' (get) Token: 0x0600C6C0 RID: 50880 RVA: 0x00058E25 File Offset: 0x00057025
		' (set) Token: 0x0600C6C1 RID: 50881 RVA: 0x007E24D0 File Offset: 0x007E06D0
		Private _OfferValidationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property OfferValidationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._OfferValidationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.OfferValidationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._OfferValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._OfferValidationToolStripMenuItem = value
				toolStripMenuItem = Me._OfferValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F00 RID: 20224
		' (get) Token: 0x0600C6C2 RID: 50882 RVA: 0x00058E2F File Offset: 0x0005702F
		' (set) Token: 0x0600C6C3 RID: 50883 RVA: 0x007E2514 File Offset: 0x007E0714
		Private _OfferMessangerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property OfferMessangerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._OfferMessangerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.OfferMessangerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._OfferMessangerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._OfferMessangerToolStripMenuItem = value
				toolStripMenuItem = Me._OfferMessangerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F01 RID: 20225
		' (get) Token: 0x0600C6C4 RID: 50884 RVA: 0x00058E39 File Offset: 0x00057039
		' (set) Token: 0x0600C6C5 RID: 50885 RVA: 0x007E2558 File Offset: 0x007E0758
		Private _IncomeVoucherToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property IncomeVoucherToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._IncomeVoucherToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.IncomeVoucherToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._IncomeVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._IncomeVoucherToolStripMenuItem = value
				toolStripMenuItem = Me._IncomeVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F02 RID: 20226
		' (get) Token: 0x0600C6C6 RID: 50886 RVA: 0x00058E43 File Offset: 0x00057043
		' (set) Token: 0x0600C6C7 RID: 50887 RVA: 0x007E259C File Offset: 0x007E079C
		Private _ExpenseVoucherToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ExpenseVoucherToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExpenseVoucherToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExpenseVoucherToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExpenseVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExpenseVoucherToolStripMenuItem = value
				toolStripMenuItem = Me._ExpenseVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F03 RID: 20227
		' (get) Token: 0x0600C6C8 RID: 50888 RVA: 0x00058E4D File Offset: 0x0005704D
		' (set) Token: 0x0600C6C9 RID: 50889 RVA: 0x007E25E0 File Offset: 0x007E07E0
		Private _BulkSMSToCustomerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BulkSMSToCustomerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BulkSMSToCustomerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BulkSMSToCustomerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BulkSMSToCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BulkSMSToCustomerToolStripMenuItem = value
				toolStripMenuItem = Me._BulkSMSToCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F04 RID: 20228
		' (get) Token: 0x0600C6CA RID: 50890 RVA: 0x00058E57 File Offset: 0x00057057
		' (set) Token: 0x0600C6CB RID: 50891 RVA: 0x00058E61 File Offset: 0x00057061
		Friend Overridable Property ToolStripMenuItem9 As ToolStripMenuItem

		' Token: 0x17004F05 RID: 20229
		' (get) Token: 0x0600C6CC RID: 50892 RVA: 0x00058E6A File Offset: 0x0005706A
		' (set) Token: 0x0600C6CD RID: 50893 RVA: 0x007E2624 File Offset: 0x007E0824
		Private _CustomerToolStripMenuItem3 As ToolStripMenuItem
		Friend Overridable Property CustomerToolStripMenuItem3 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerToolStripMenuItem3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerToolStripMenuItem3_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerToolStripMenuItem3 = value
				toolStripMenuItem = Me._CustomerToolStripMenuItem3
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F06 RID: 20230
		' (get) Token: 0x0600C6CE RID: 50894 RVA: 0x00058E74 File Offset: 0x00057074
		' (set) Token: 0x0600C6CF RID: 50895 RVA: 0x007E2668 File Offset: 0x007E0868
		Private _SupplierToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SupplierToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierToolStripMenuItem1 = value
				toolStripMenuItem = Me._SupplierToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F07 RID: 20231
		' (get) Token: 0x0600C6D0 RID: 50896 RVA: 0x00058E7E File Offset: 0x0005707E
		' (set) Token: 0x0600C6D1 RID: 50897 RVA: 0x007E26AC File Offset: 0x007E08AC
		Private _BillSundryHeadToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BillSundryHeadToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BillSundryHeadToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BillSundryHeadToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BillSundryHeadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BillSundryHeadToolStripMenuItem = value
				toolStripMenuItem = Me._BillSundryHeadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F08 RID: 20232
		' (get) Token: 0x0600C6D2 RID: 50898 RVA: 0x00058E88 File Offset: 0x00057088
		' (set) Token: 0x0600C6D3 RID: 50899 RVA: 0x007E26F0 File Offset: 0x007E08F0
		Private _LoyaltyValidationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LoyaltyValidationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LoyaltyValidationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LoyaltyValidationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LoyaltyValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LoyaltyValidationToolStripMenuItem = value
				toolStripMenuItem = Me._LoyaltyValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F09 RID: 20233
		' (get) Token: 0x0600C6D4 RID: 50900 RVA: 0x00058E92 File Offset: 0x00057092
		' (set) Token: 0x0600C6D5 RID: 50901 RVA: 0x007E2734 File Offset: 0x007E0934
		Private _BulkLoyaltySMSToCustomerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BulkLoyaltySMSToCustomerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BulkLoyaltySMSToCustomerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BulkLoyaltySMSToCustomerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BulkLoyaltySMSToCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BulkLoyaltySMSToCustomerToolStripMenuItem = value
				toolStripMenuItem = Me._BulkLoyaltySMSToCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F0A RID: 20234
		' (get) Token: 0x0600C6D6 RID: 50902 RVA: 0x00058E9C File Offset: 0x0005709C
		' (set) Token: 0x0600C6D7 RID: 50903 RVA: 0x007E2778 File Offset: 0x007E0978
		Private _LoyaltyCardToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LoyaltyCardToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LoyaltyCardToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LoyaltyCardToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LoyaltyCardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LoyaltyCardToolStripMenuItem = value
				toolStripMenuItem = Me._LoyaltyCardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F0B RID: 20235
		' (get) Token: 0x0600C6D8 RID: 50904 RVA: 0x00058EA6 File Offset: 0x000570A6
		' (set) Token: 0x0600C6D9 RID: 50905 RVA: 0x007E27BC File Offset: 0x007E09BC
		Private _BulkEMailSenderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BulkEMailSenderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BulkEMailSenderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BulkEMailSenderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BulkEMailSenderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BulkEMailSenderToolStripMenuItem = value
				toolStripMenuItem = Me._BulkEMailSenderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F0C RID: 20236
		' (get) Token: 0x0600C6DA RID: 50906 RVA: 0x00058EB0 File Offset: 0x000570B0
		' (set) Token: 0x0600C6DB RID: 50907 RVA: 0x00058EBA File Offset: 0x000570BA
		Friend Overridable Property TCSToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004F0D RID: 20237
		' (get) Token: 0x0600C6DC RID: 50908 RVA: 0x00058EC3 File Offset: 0x000570C3
		' (set) Token: 0x0600C6DD RID: 50909 RVA: 0x007E2800 File Offset: 0x007E0A00
		Private _TCSValidationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TCSValidationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TCSValidationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TCSValidationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TCSValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TCSValidationToolStripMenuItem = value
				toolStripMenuItem = Me._TCSValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F0E RID: 20238
		' (get) Token: 0x0600C6DE RID: 50910 RVA: 0x00058ECD File Offset: 0x000570CD
		' (set) Token: 0x0600C6DF RID: 50911 RVA: 0x007E2844 File Offset: 0x007E0A44
		Private _TCSReceivedToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TCSReceivedToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TCSReceivedToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TCSReceivedToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TCSReceivedToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TCSReceivedToolStripMenuItem = value
				toolStripMenuItem = Me._TCSReceivedToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F0F RID: 20239
		' (get) Token: 0x0600C6E0 RID: 50912 RVA: 0x00058ED7 File Offset: 0x000570D7
		' (set) Token: 0x0600C6E1 RID: 50913 RVA: 0x007E2888 File Offset: 0x007E0A88
		Private _TCSPaymentPurchaseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TCSPaymentPurchaseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TCSPaymentPurchaseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TCSPaymentPurchaseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TCSPaymentPurchaseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TCSPaymentPurchaseToolStripMenuItem = value
				toolStripMenuItem = Me._TCSPaymentPurchaseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F10 RID: 20240
		' (get) Token: 0x0600C6E2 RID: 50914 RVA: 0x00058EE1 File Offset: 0x000570E1
		' (set) Token: 0x0600C6E3 RID: 50915 RVA: 0x007E28CC File Offset: 0x007E0ACC
		Private _TCSPaymentSaleReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TCSPaymentSaleReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TCSPaymentSaleReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TCSPaymentSaleReturnToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TCSPaymentSaleReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TCSPaymentSaleReturnToolStripMenuItem = value
				toolStripMenuItem = Me._TCSPaymentSaleReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F11 RID: 20241
		' (get) Token: 0x0600C6E4 RID: 50916 RVA: 0x00058EEB File Offset: 0x000570EB
		' (set) Token: 0x0600C6E5 RID: 50917 RVA: 0x007E2910 File Offset: 0x007E0B10
		Private _TCSReceivedPurchaseReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TCSReceivedPurchaseReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TCSReceivedPurchaseReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TCSReceivedPurchaseReturnToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TCSReceivedPurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TCSReceivedPurchaseReturnToolStripMenuItem = value
				toolStripMenuItem = Me._TCSReceivedPurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F12 RID: 20242
		' (get) Token: 0x0600C6E6 RID: 50918 RVA: 0x00058EF5 File Offset: 0x000570F5
		' (set) Token: 0x0600C6E7 RID: 50919 RVA: 0x007E2954 File Offset: 0x007E0B54
		Private _LoyaltyCardIssueToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LoyaltyCardIssueToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LoyaltyCardIssueToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LoyaltyCardIssueToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LoyaltyCardIssueToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LoyaltyCardIssueToolStripMenuItem = value
				toolStripMenuItem = Me._LoyaltyCardIssueToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F13 RID: 20243
		' (get) Token: 0x0600C6E8 RID: 50920 RVA: 0x00058EFF File Offset: 0x000570FF
		' (set) Token: 0x0600C6E9 RID: 50921 RVA: 0x007E2998 File Offset: 0x007E0B98
		Private _BulkSMSToCreditCustomerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BulkSMSToCreditCustomerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BulkSMSToCreditCustomerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BulkSMSToCreditCustomerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BulkSMSToCreditCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BulkSMSToCreditCustomerToolStripMenuItem = value
				toolStripMenuItem = Me._BulkSMSToCreditCustomerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F14 RID: 20244
		' (get) Token: 0x0600C6EA RID: 50922 RVA: 0x00058F09 File Offset: 0x00057109
		' (set) Token: 0x0600C6EB RID: 50923 RVA: 0x007E29DC File Offset: 0x007E0BDC
		Private _ToolStripMenuItem10 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem10 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem10_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem10
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem10 = value
				toolStripMenuItem = Me._ToolStripMenuItem10
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F15 RID: 20245
		' (get) Token: 0x0600C6EC RID: 50924 RVA: 0x00058F13 File Offset: 0x00057113
		' (set) Token: 0x0600C6ED RID: 50925 RVA: 0x007E2A20 File Offset: 0x007E0C20
		Private _ProductBulkEditorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductBulkEditorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductBulkEditorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductBulkEditorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductBulkEditorToolStripMenuItem = value
				toolStripMenuItem = Me._ProductBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F16 RID: 20246
		' (get) Token: 0x0600C6EE RID: 50926 RVA: 0x00058F1D File Offset: 0x0005711D
		' (set) Token: 0x0600C6EF RID: 50927 RVA: 0x007E2A64 File Offset: 0x007E0C64
		Private _AccountHeadToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property AccountHeadToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AccountHeadToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AccountHeadToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AccountHeadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AccountHeadToolStripMenuItem = value
				toolStripMenuItem = Me._AccountHeadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F17 RID: 20247
		' (get) Token: 0x0600C6F0 RID: 50928 RVA: 0x00058F27 File Offset: 0x00057127
		' (set) Token: 0x0600C6F1 RID: 50929 RVA: 0x00058F31 File Offset: 0x00057131
		Friend Overridable Property GSTRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004F18 RID: 20248
		' (get) Token: 0x0600C6F2 RID: 50930 RVA: 0x00058F3A File Offset: 0x0005713A
		' (set) Token: 0x0600C6F3 RID: 50931 RVA: 0x007E2AA8 File Offset: 0x007E0CA8
		Private _SaleRegisterBillWiseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleRegisterBillWiseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleRegisterBillWiseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleRegisterBillWiseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleRegisterBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleRegisterBillWiseToolStripMenuItem = value
				toolStripMenuItem = Me._SaleRegisterBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F19 RID: 20249
		' (get) Token: 0x0600C6F4 RID: 50932 RVA: 0x00058F44 File Offset: 0x00057144
		' (set) Token: 0x0600C6F5 RID: 50933 RVA: 0x007E2AEC File Offset: 0x007E0CEC
		Private _PurchaseRegisterBillWiseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseRegisterBillWiseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseRegisterBillWiseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseRegisterBillWiseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseRegisterBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseRegisterBillWiseToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseRegisterBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1A RID: 20250
		' (get) Token: 0x0600C6F6 RID: 50934 RVA: 0x00058F4E File Offset: 0x0005714E
		' (set) Token: 0x0600C6F7 RID: 50935 RVA: 0x007E2B30 File Offset: 0x007E0D30
		Private _EstimateToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property EstimateToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EstimateToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EstimateToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EstimateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EstimateToolStripMenuItem = value
				toolStripMenuItem = Me._EstimateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1B RID: 20251
		' (get) Token: 0x0600C6F8 RID: 50936 RVA: 0x00058F58 File Offset: 0x00057158
		' (set) Token: 0x0600C6F9 RID: 50937 RVA: 0x007E2B74 File Offset: 0x007E0D74
		Private _ToolStripMenuItem11 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem11 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem11_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem11
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem11 = value
				toolStripMenuItem = Me._ToolStripMenuItem11
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1C RID: 20252
		' (get) Token: 0x0600C6FA RID: 50938 RVA: 0x00058F62 File Offset: 0x00057162
		' (set) Token: 0x0600C6FB RID: 50939 RVA: 0x007E2BB8 File Offset: 0x007E0DB8
		Private _CustomerBulkEditorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerBulkEditorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerBulkEditorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerBulkEditorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerBulkEditorToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1D RID: 20253
		' (get) Token: 0x0600C6FC RID: 50940 RVA: 0x00058F6C File Offset: 0x0005716C
		' (set) Token: 0x0600C6FD RID: 50941 RVA: 0x007E2BFC File Offset: 0x007E0DFC
		Private _SupplierBulkEditorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SupplierBulkEditorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierBulkEditorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierBulkEditorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierBulkEditorToolStripMenuItem = value
				toolStripMenuItem = Me._SupplierBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1E RID: 20254
		' (get) Token: 0x0600C6FE RID: 50942 RVA: 0x00058F76 File Offset: 0x00057176
		' (set) Token: 0x0600C6FF RID: 50943 RVA: 0x007E2C40 File Offset: 0x007E0E40
		Private _CustomerTurnAroundRecordToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerTurnAroundRecordToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerTurnAroundRecordToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerTurnAroundRecordToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerTurnAroundRecordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerTurnAroundRecordToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerTurnAroundRecordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F1F RID: 20255
		' (get) Token: 0x0600C700 RID: 50944 RVA: 0x00058F80 File Offset: 0x00057180
		' (set) Token: 0x0600C701 RID: 50945 RVA: 0x007E2C84 File Offset: 0x007E0E84
		Private _RouteToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RouteToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RouteToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RouteToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._RouteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._RouteToolStripMenuItem = value
				toolStripMenuItem = Me._RouteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F20 RID: 20256
		' (get) Token: 0x0600C702 RID: 50946 RVA: 0x00058F8A File Offset: 0x0005718A
		' (set) Token: 0x0600C703 RID: 50947 RVA: 0x007E2CC8 File Offset: 0x007E0EC8
		Private _ToolStripMenuItem14 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem14 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem14_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem14
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem14 = value
				toolStripMenuItem = Me._ToolStripMenuItem14
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F21 RID: 20257
		' (get) Token: 0x0600C704 RID: 50948 RVA: 0x00058F94 File Offset: 0x00057194
		' (set) Token: 0x0600C705 RID: 50949 RVA: 0x007E2D0C File Offset: 0x007E0F0C
		Private _TransporterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TransporterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TransporterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TransporterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TransporterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TransporterToolStripMenuItem = value
				toolStripMenuItem = Me._TransporterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F22 RID: 20258
		' (get) Token: 0x0600C706 RID: 50950 RVA: 0x00058F9E File Offset: 0x0005719E
		' (set) Token: 0x0600C707 RID: 50951 RVA: 0x007E2D50 File Offset: 0x007E0F50
		Private _DamageProductManagementToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DamageProductManagementToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DamageProductManagementToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DamageProductManagementToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DamageProductManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DamageProductManagementToolStripMenuItem = value
				toolStripMenuItem = Me._DamageProductManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F23 RID: 20259
		' (get) Token: 0x0600C708 RID: 50952 RVA: 0x00058FA8 File Offset: 0x000571A8
		' (set) Token: 0x0600C709 RID: 50953 RVA: 0x007E2D94 File Offset: 0x007E0F94
		Private _IncomeTaxCalculatorOnlineToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property IncomeTaxCalculatorOnlineToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._IncomeTaxCalculatorOnlineToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.IncomeTaxCalculatorOnlineToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._IncomeTaxCalculatorOnlineToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._IncomeTaxCalculatorOnlineToolStripMenuItem = value
				toolStripMenuItem = Me._IncomeTaxCalculatorOnlineToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F24 RID: 20260
		' (get) Token: 0x0600C70A RID: 50954 RVA: 0x00058FB2 File Offset: 0x000571B2
		' (set) Token: 0x0600C70B RID: 50955 RVA: 0x007E2DD8 File Offset: 0x007E0FD8
		Private _DBarcodeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DBarcodeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DBarcodeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DBarcodeToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DBarcodeToolStripMenuItem = value
				toolStripMenuItem = Me._DBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F25 RID: 20261
		' (get) Token: 0x0600C70C RID: 50956 RVA: 0x00058FBC File Offset: 0x000571BC
		' (set) Token: 0x0600C70D RID: 50957 RVA: 0x007E2E1C File Offset: 0x007E101C
		Private _CipherBarcodeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CipherBarcodeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CipherBarcodeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CipherBarcodeToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CipherBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CipherBarcodeToolStripMenuItem = value
				toolStripMenuItem = Me._CipherBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F26 RID: 20262
		' (get) Token: 0x0600C70E RID: 50958 RVA: 0x00058FC6 File Offset: 0x000571C6
		' (set) Token: 0x0600C70F RID: 50959 RVA: 0x007E2E60 File Offset: 0x007E1060
		Private _ToolStripMenuItem15 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem15 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem15_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem15
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem15 = value
				toolStripMenuItem = Me._ToolStripMenuItem15
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F27 RID: 20263
		' (get) Token: 0x0600C710 RID: 50960 RVA: 0x00058FD0 File Offset: 0x000571D0
		' (set) Token: 0x0600C711 RID: 50961 RVA: 0x007E2EA4 File Offset: 0x007E10A4
		Private _ToolStripMenuItem16 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem16 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem16_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem16
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem16 = value
				toolStripMenuItem = Me._ToolStripMenuItem16
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F28 RID: 20264
		' (get) Token: 0x0600C712 RID: 50962 RVA: 0x00058FDA File Offset: 0x000571DA
		' (set) Token: 0x0600C713 RID: 50963 RVA: 0x007E2EE8 File Offset: 0x007E10E8
		Private _TaxCategoryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TaxCategoryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TaxCategoryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TaxCategoryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TaxCategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TaxCategoryToolStripMenuItem = value
				toolStripMenuItem = Me._TaxCategoryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F29 RID: 20265
		' (get) Token: 0x0600C714 RID: 50964 RVA: 0x00058FE4 File Offset: 0x000571E4
		' (set) Token: 0x0600C715 RID: 50965 RVA: 0x007E2F2C File Offset: 0x007E112C
		Private _TaxTypeSettingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TaxTypeSettingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TaxTypeSettingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TaxTypeSettingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TaxTypeSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TaxTypeSettingToolStripMenuItem = value
				toolStripMenuItem = Me._TaxTypeSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2A RID: 20266
		' (get) Token: 0x0600C716 RID: 50966 RVA: 0x00058FEE File Offset: 0x000571EE
		' (set) Token: 0x0600C717 RID: 50967 RVA: 0x007E2F70 File Offset: 0x007E1170
		Private _ToolStripMenuItem18 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem18 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem18_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem18
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem18 = value
				toolStripMenuItem = Me._ToolStripMenuItem18
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2B RID: 20267
		' (get) Token: 0x0600C718 RID: 50968 RVA: 0x00058FF8 File Offset: 0x000571F8
		' (set) Token: 0x0600C719 RID: 50969 RVA: 0x007E2FB4 File Offset: 0x007E11B4
		Private _QRBarcodeReaderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property QRBarcodeReaderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._QRBarcodeReaderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.QRBarcodeReaderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._QRBarcodeReaderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._QRBarcodeReaderToolStripMenuItem = value
				toolStripMenuItem = Me._QRBarcodeReaderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2C RID: 20268
		' (get) Token: 0x0600C71A RID: 50970 RVA: 0x00059002 File Offset: 0x00057202
		' (set) Token: 0x0600C71B RID: 50971 RVA: 0x007E2FF8 File Offset: 0x007E11F8
		Private _SalesManToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SalesManToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesManToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesManToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesManToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesManToolStripMenuItem1 = value
				toolStripMenuItem = Me._SalesManToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2D RID: 20269
		' (get) Token: 0x0600C71C RID: 50972 RVA: 0x0005900C File Offset: 0x0005720C
		' (set) Token: 0x0600C71D RID: 50973 RVA: 0x007E303C File Offset: 0x007E123C
		Private _SalesmanBulkEditorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesmanBulkEditorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesmanBulkEditorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesmanBulkEditorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesmanBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesmanBulkEditorToolStripMenuItem = value
				toolStripMenuItem = Me._SalesmanBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2E RID: 20270
		' (get) Token: 0x0600C71E RID: 50974 RVA: 0x00059016 File Offset: 0x00057216
		' (set) Token: 0x0600C71F RID: 50975 RVA: 0x007E3080 File Offset: 0x007E1280
		Private _EmployeeRegistrationToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property EmployeeRegistrationToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EmployeeRegistrationToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EmployeeRegistrationToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EmployeeRegistrationToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EmployeeRegistrationToolStripMenuItem1 = value
				toolStripMenuItem = Me._EmployeeRegistrationToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F2F RID: 20271
		' (get) Token: 0x0600C720 RID: 50976 RVA: 0x00059020 File Offset: 0x00057220
		' (set) Token: 0x0600C721 RID: 50977 RVA: 0x007E30C4 File Offset: 0x007E12C4
		Private _EmployeeAttendanceToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property EmployeeAttendanceToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EmployeeAttendanceToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EmployeeAttendanceToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EmployeeAttendanceToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EmployeeAttendanceToolStripMenuItem1 = value
				toolStripMenuItem = Me._EmployeeAttendanceToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F30 RID: 20272
		' (get) Token: 0x0600C722 RID: 50978 RVA: 0x0005902A File Offset: 0x0005722A
		' (set) Token: 0x0600C723 RID: 50979 RVA: 0x007E3108 File Offset: 0x007E1308
		Private _AdvancePaymentEntryToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property AdvancePaymentEntryToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AdvancePaymentEntryToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AdvancePaymentEntryToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AdvancePaymentEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AdvancePaymentEntryToolStripMenuItem1 = value
				toolStripMenuItem = Me._AdvancePaymentEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F31 RID: 20273
		' (get) Token: 0x0600C724 RID: 50980 RVA: 0x00059034 File Offset: 0x00057234
		' (set) Token: 0x0600C725 RID: 50981 RVA: 0x007E314C File Offset: 0x007E134C
		Private _EmployeePaymentToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property EmployeePaymentToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EmployeePaymentToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EmployeePaymentToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EmployeePaymentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EmployeePaymentToolStripMenuItem1 = value
				toolStripMenuItem = Me._EmployeePaymentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F32 RID: 20274
		' (get) Token: 0x0600C726 RID: 50982 RVA: 0x0005903E File Offset: 0x0005723E
		' (set) Token: 0x0600C727 RID: 50983 RVA: 0x007E3190 File Offset: 0x007E1390
		Private _SalarySlipToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SalarySlipToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalarySlipToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalarySlipToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalarySlipToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalarySlipToolStripMenuItem1 = value
				toolStripMenuItem = Me._SalarySlipToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F33 RID: 20275
		' (get) Token: 0x0600C728 RID: 50984 RVA: 0x00059048 File Offset: 0x00057248
		' (set) Token: 0x0600C729 RID: 50985 RVA: 0x007E31D4 File Offset: 0x007E13D4
		Private _SalarySlipsReportToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalarySlipsReportToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalarySlipsReportToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalarySlipsReportToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalarySlipsReportToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalarySlipsReportToolStripMenuItem = value
				toolStripMenuItem = Me._SalarySlipsReportToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F34 RID: 20276
		' (get) Token: 0x0600C72A RID: 50986 RVA: 0x00059052 File Offset: 0x00057252
		' (set) Token: 0x0600C72B RID: 50987 RVA: 0x007E3218 File Offset: 0x007E1418
		Private _AdvancePaymentReportToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property AdvancePaymentReportToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AdvancePaymentReportToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AdvancePaymentReportToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AdvancePaymentReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AdvancePaymentReportToolStripMenuItem1 = value
				toolStripMenuItem = Me._AdvancePaymentReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F35 RID: 20277
		' (get) Token: 0x0600C72C RID: 50988 RVA: 0x0005905C File Offset: 0x0005725C
		' (set) Token: 0x0600C72D RID: 50989 RVA: 0x007E325C File Offset: 0x007E145C
		Private _DeductionReportToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property DeductionReportToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DeductionReportToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DeductionReportToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DeductionReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DeductionReportToolStripMenuItem1 = value
				toolStripMenuItem = Me._DeductionReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F36 RID: 20278
		' (get) Token: 0x0600C72E RID: 50990 RVA: 0x00059066 File Offset: 0x00057266
		' (set) Token: 0x0600C72F RID: 50991 RVA: 0x007E32A0 File Offset: 0x007E14A0
		Private _EmployeePaymentReportToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property EmployeePaymentReportToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EmployeePaymentReportToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EmployeePaymentReportToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EmployeePaymentReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EmployeePaymentReportToolStripMenuItem1 = value
				toolStripMenuItem = Me._EmployeePaymentReportToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F37 RID: 20279
		' (get) Token: 0x0600C730 RID: 50992 RVA: 0x00059070 File Offset: 0x00057270
		' (set) Token: 0x0600C731 RID: 50993 RVA: 0x007E32E4 File Offset: 0x007E14E4
		Private _ContactToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property ContactToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ContactToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ContactToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ContactToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ContactToolStripMenuItem1 = value
				toolStripMenuItem = Me._ContactToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F38 RID: 20280
		' (get) Token: 0x0600C732 RID: 50994 RVA: 0x0005907A File Offset: 0x0005727A
		' (set) Token: 0x0600C733 RID: 50995 RVA: 0x007E3328 File Offset: 0x007E1528
		Private _CustomerContactListToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property CustomerContactListToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerContactListToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerContactListToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerContactListToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerContactListToolStripMenuItem1 = value
				toolStripMenuItem = Me._CustomerContactListToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F39 RID: 20281
		' (get) Token: 0x0600C734 RID: 50996 RVA: 0x00059084 File Offset: 0x00057284
		' (set) Token: 0x0600C735 RID: 50997 RVA: 0x007E336C File Offset: 0x007E156C
		Private _SupplierContactListToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SupplierContactListToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierContactListToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierContactListToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierContactListToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierContactListToolStripMenuItem1 = value
				toolStripMenuItem = Me._SupplierContactListToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3A RID: 20282
		' (get) Token: 0x0600C736 RID: 50998 RVA: 0x0005908E File Offset: 0x0005728E
		' (set) Token: 0x0600C737 RID: 50999 RVA: 0x007E33B0 File Offset: 0x007E15B0
		Private _ManualContactListToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ManualContactListToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ManualContactListToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ManualContactListToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ManualContactListToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ManualContactListToolStripMenuItem = value
				toolStripMenuItem = Me._ManualContactListToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3B RID: 20283
		' (get) Token: 0x0600C738 RID: 51000 RVA: 0x00059098 File Offset: 0x00057298
		' (set) Token: 0x0600C739 RID: 51001 RVA: 0x007E33F4 File Offset: 0x007E15F4
		Private _ChequePrintToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ChequePrintToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ChequePrintToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ChequePrintToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ChequePrintToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ChequePrintToolStripMenuItem = value
				toolStripMenuItem = Me._ChequePrintToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3C RID: 20284
		' (get) Token: 0x0600C73A RID: 51002 RVA: 0x000590A2 File Offset: 0x000572A2
		' (set) Token: 0x0600C73B RID: 51003 RVA: 0x007E3438 File Offset: 0x007E1638
		Private _ToolStripMenuItem7 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem7 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem7_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem7
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem7 = value
				toolStripMenuItem = Me._ToolStripMenuItem7
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3D RID: 20285
		' (get) Token: 0x0600C73C RID: 51004 RVA: 0x000590AC File Offset: 0x000572AC
		' (set) Token: 0x0600C73D RID: 51005 RVA: 0x007E347C File Offset: 0x007E167C
		Private _CloudDataManagementToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CloudDataManagementToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CloudDataManagementToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CloudDataManagementToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CloudDataManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CloudDataManagementToolStripMenuItem = value
				toolStripMenuItem = Me._CloudDataManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3E RID: 20286
		' (get) Token: 0x0600C73E RID: 51006 RVA: 0x000590B6 File Offset: 0x000572B6
		' (set) Token: 0x0600C73F RID: 51007 RVA: 0x007E34C0 File Offset: 0x007E16C0
		Private _ToolStripMenuItem19 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem19 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem19_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem19
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem19 = value
				toolStripMenuItem = Me._ToolStripMenuItem19
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F3F RID: 20287
		' (get) Token: 0x0600C740 RID: 51008 RVA: 0x000590C0 File Offset: 0x000572C0
		' (set) Token: 0x0600C741 RID: 51009 RVA: 0x007E3504 File Offset: 0x007E1704
		Private _ToolStripMenuItem20 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem20 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem20_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem20
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem20 = value
				toolStripMenuItem = Me._ToolStripMenuItem20
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F40 RID: 20288
		' (get) Token: 0x0600C742 RID: 51010 RVA: 0x000590CA File Offset: 0x000572CA
		' (set) Token: 0x0600C743 RID: 51011 RVA: 0x007E3548 File Offset: 0x007E1748
		Private _ToolStripMenuItem21 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem21 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem21
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem21_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem21
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem21 = value
				toolStripMenuItem = Me._ToolStripMenuItem21
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F41 RID: 20289
		' (get) Token: 0x0600C744 RID: 51012 RVA: 0x000590D4 File Offset: 0x000572D4
		' (set) Token: 0x0600C745 RID: 51013 RVA: 0x007E358C File Offset: 0x007E178C
		Private _SaleReturnBillWiseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaleReturnBillWiseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaleReturnBillWiseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaleReturnBillWiseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaleReturnBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaleReturnBillWiseToolStripMenuItem = value
				toolStripMenuItem = Me._SaleReturnBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F42 RID: 20290
		' (get) Token: 0x0600C746 RID: 51014 RVA: 0x000590DE File Offset: 0x000572DE
		' (set) Token: 0x0600C747 RID: 51015 RVA: 0x007E35D0 File Offset: 0x007E17D0
		Private _PurchaseReturnBillWiseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnBillWiseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnBillWiseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnBillWiseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnBillWiseToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseReturnBillWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F43 RID: 20291
		' (get) Token: 0x0600C748 RID: 51016 RVA: 0x000590E8 File Offset: 0x000572E8
		' (set) Token: 0x0600C749 RID: 51017 RVA: 0x007E3614 File Offset: 0x007E1814
		Private _ToolStripMenuItem22 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem22 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem22_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem22
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem22 = value
				toolStripMenuItem = Me._ToolStripMenuItem22
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F44 RID: 20292
		' (get) Token: 0x0600C74A RID: 51018 RVA: 0x000590F2 File Offset: 0x000572F2
		' (set) Token: 0x0600C74B RID: 51019 RVA: 0x007E3658 File Offset: 0x007E1858
		Private _ToolStripMenuItem23 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem23 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem23
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem23_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem23
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem23 = value
				toolStripMenuItem = Me._ToolStripMenuItem23
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F45 RID: 20293
		' (get) Token: 0x0600C74C RID: 51020 RVA: 0x000590FC File Offset: 0x000572FC
		' (set) Token: 0x0600C74D RID: 51021 RVA: 0x007E369C File Offset: 0x007E189C
		Private _StockMovementToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockMovementToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockMovementToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockMovementToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockMovementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockMovementToolStripMenuItem = value
				toolStripMenuItem = Me._StockMovementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F46 RID: 20294
		' (get) Token: 0x0600C74E RID: 51022 RVA: 0x00059106 File Offset: 0x00057306
		' (set) Token: 0x0600C74F RID: 51023 RVA: 0x00059110 File Offset: 0x00057310
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004F47 RID: 20295
		' (get) Token: 0x0600C750 RID: 51024 RVA: 0x00059119 File Offset: 0x00057319
		' (set) Token: 0x0600C751 RID: 51025 RVA: 0x00059123 File Offset: 0x00057323
		Friend Overridable Property lblScroll As Label

		' Token: 0x17004F48 RID: 20296
		' (get) Token: 0x0600C752 RID: 51026 RVA: 0x0005912C File Offset: 0x0005732C
		' (set) Token: 0x0600C753 RID: 51027 RVA: 0x007E36E0 File Offset: 0x007E18E0
		Private _Timer4 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer4 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer4_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer4
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer4 = value
				timer = Me._Timer4
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F49 RID: 20297
		' (get) Token: 0x0600C754 RID: 51028 RVA: 0x00059136 File Offset: 0x00057336
		' (set) Token: 0x0600C755 RID: 51029 RVA: 0x007E3724 File Offset: 0x007E1924
		Private _Timer5 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer5 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer5_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer5
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer5 = value
				timer = Me._Timer5
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F4A RID: 20298
		' (get) Token: 0x0600C756 RID: 51030 RVA: 0x00059140 File Offset: 0x00057340
		' (set) Token: 0x0600C757 RID: 51031 RVA: 0x007E3768 File Offset: 0x007E1968
		Private _ToolStripMenuItem24 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem24 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem24
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem24_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem24
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem24 = value
				toolStripMenuItem = Me._ToolStripMenuItem24
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F4B RID: 20299
		' (get) Token: 0x0600C758 RID: 51032 RVA: 0x0005914A File Offset: 0x0005734A
		' (set) Token: 0x0600C759 RID: 51033 RVA: 0x007E37AC File Offset: 0x007E19AC
		Private _ToolStripMenuItem25 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem25 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem25
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem25_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem25
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem25 = value
				toolStripMenuItem = Me._ToolStripMenuItem25
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F4C RID: 20300
		' (get) Token: 0x0600C75A RID: 51034 RVA: 0x00059154 File Offset: 0x00057354
		' (set) Token: 0x0600C75B RID: 51035 RVA: 0x007E37F0 File Offset: 0x007E19F0
		Private _ToolStripMenuItem26 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem26 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem26
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem26_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem26
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem26 = value
				toolStripMenuItem = Me._ToolStripMenuItem26
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F4D RID: 20301
		' (get) Token: 0x0600C75C RID: 51036 RVA: 0x0005915E File Offset: 0x0005735E
		' (set) Token: 0x0600C75D RID: 51037 RVA: 0x00059168 File Offset: 0x00057368
		Friend Overridable Property Label2 As Label

		' Token: 0x17004F4E RID: 20302
		' (get) Token: 0x0600C75E RID: 51038 RVA: 0x00059171 File Offset: 0x00057371
		' (set) Token: 0x0600C75F RID: 51039 RVA: 0x0005917B File Offset: 0x0005737B
		Friend Overridable Property Timer6 As Global.System.Windows.Forms.Timer

		' Token: 0x17004F4F RID: 20303
		' (get) Token: 0x0600C760 RID: 51040 RVA: 0x00059184 File Offset: 0x00057384
		' (set) Token: 0x0600C761 RID: 51041 RVA: 0x007E3834 File Offset: 0x007E1A34
		Private _SalesRegisterDetailsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesRegisterDetailsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesRegisterDetailsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesRegisterDetailsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesRegisterDetailsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesRegisterDetailsToolStripMenuItem = value
				toolStripMenuItem = Me._SalesRegisterDetailsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F50 RID: 20304
		' (get) Token: 0x0600C762 RID: 51042 RVA: 0x0005918E File Offset: 0x0005738E
		' (set) Token: 0x0600C763 RID: 51043 RVA: 0x007E3878 File Offset: 0x007E1A78
		Private _PurchaseRegisterItemWiseToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseRegisterItemWiseToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseRegisterItemWiseToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseRegisterItemWiseToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseRegisterItemWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseRegisterItemWiseToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseRegisterItemWiseToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F51 RID: 20305
		' (get) Token: 0x0600C764 RID: 51044 RVA: 0x00059198 File Offset: 0x00057398
		' (set) Token: 0x0600C765 RID: 51045 RVA: 0x007E38BC File Offset: 0x007E1ABC
		Private _ToolStripMenuItem27 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem27 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem27
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem27_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem27
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem27 = value
				toolStripMenuItem = Me._ToolStripMenuItem27
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F52 RID: 20306
		' (get) Token: 0x0600C766 RID: 51046 RVA: 0x000591A2 File Offset: 0x000573A2
		' (set) Token: 0x0600C767 RID: 51047 RVA: 0x007E3900 File Offset: 0x007E1B00
		Private _ProductCatalogueMakerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductCatalogueMakerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductCatalogueMakerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductCatalogueMakerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductCatalogueMakerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductCatalogueMakerToolStripMenuItem = value
				toolStripMenuItem = Me._ProductCatalogueMakerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F53 RID: 20307
		' (get) Token: 0x0600C768 RID: 51048 RVA: 0x000591AC File Offset: 0x000573AC
		' (set) Token: 0x0600C769 RID: 51049 RVA: 0x007E3944 File Offset: 0x007E1B44
		Private _GSTINValidationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property GSTINValidationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._GSTINValidationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.GSTINValidationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._GSTINValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._GSTINValidationToolStripMenuItem = value
				toolStripMenuItem = Me._GSTINValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F54 RID: 20308
		' (get) Token: 0x0600C76A RID: 51050 RVA: 0x000591B6 File Offset: 0x000573B6
		' (set) Token: 0x0600C76B RID: 51051 RVA: 0x007E3988 File Offset: 0x007E1B88
		Private _BrokerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BrokerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BrokerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BrokerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BrokerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BrokerToolStripMenuItem = value
				toolStripMenuItem = Me._BrokerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F55 RID: 20309
		' (get) Token: 0x0600C76C RID: 51052 RVA: 0x000591C0 File Offset: 0x000573C0
		' (set) Token: 0x0600C76D RID: 51053 RVA: 0x007E39CC File Offset: 0x007E1BCC
		Private _BrokerLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BrokerLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BrokerLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BrokerLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BrokerLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BrokerLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._BrokerLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F56 RID: 20310
		' (get) Token: 0x0600C76E RID: 51054 RVA: 0x000591CA File Offset: 0x000573CA
		' (set) Token: 0x0600C76F RID: 51055 RVA: 0x007E3A10 File Offset: 0x007E1C10
		Private _PromotionalOfferBuyXAndGetYToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PromotionalOfferBuyXAndGetYToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PromotionalOfferBuyXAndGetYToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PromotionalOfferBuyXAndGetYToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PromotionalOfferBuyXAndGetYToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PromotionalOfferBuyXAndGetYToolStripMenuItem = value
				toolStripMenuItem = Me._PromotionalOfferBuyXAndGetYToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F57 RID: 20311
		' (get) Token: 0x0600C770 RID: 51056 RVA: 0x000591D4 File Offset: 0x000573D4
		' (set) Token: 0x0600C771 RID: 51057 RVA: 0x000591DE File Offset: 0x000573DE
		Friend Overridable Property WeighingMachineControlToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004F58 RID: 20312
		' (get) Token: 0x0600C772 RID: 51058 RVA: 0x000591E7 File Offset: 0x000573E7
		' (set) Token: 0x0600C773 RID: 51059 RVA: 0x007E3A54 File Offset: 0x007E1C54
		Private _ProductGenerateToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductGenerateToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductGenerateToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductGenerateToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductGenerateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductGenerateToolStripMenuItem = value
				toolStripMenuItem = Me._ProductGenerateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F59 RID: 20313
		' (get) Token: 0x0600C774 RID: 51060 RVA: 0x000591F1 File Offset: 0x000573F1
		' (set) Token: 0x0600C775 RID: 51061 RVA: 0x007E3A98 File Offset: 0x007E1C98
		Private _ReceiptPrinterScaleToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ReceiptPrinterScaleToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ReceiptPrinterScaleToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ReceiptPrinterScaleToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ReceiptPrinterScaleToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ReceiptPrinterScaleToolStripMenuItem = value
				toolStripMenuItem = Me._ReceiptPrinterScaleToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F5A RID: 20314
		' (get) Token: 0x0600C776 RID: 51062 RVA: 0x000591FB File Offset: 0x000573FB
		' (set) Token: 0x0600C777 RID: 51063 RVA: 0x00059205 File Offset: 0x00057405
		Friend Overridable Property StatusRetriever As Global.System.Windows.Forms.Timer

		' Token: 0x17004F5B RID: 20315
		' (get) Token: 0x0600C778 RID: 51064 RVA: 0x0005920E File Offset: 0x0005740E
		' (set) Token: 0x0600C779 RID: 51065 RVA: 0x007E3ADC File Offset: 0x007E1CDC
		Private _CustomerApprovedDiscountRegisterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerApprovedDiscountRegisterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerApprovedDiscountRegisterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerApprovedDiscountRegisterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerApprovedDiscountRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerApprovedDiscountRegisterToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerApprovedDiscountRegisterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F5C RID: 20316
		' (get) Token: 0x0600C77A RID: 51066 RVA: 0x00059218 File Offset: 0x00057418
		' (set) Token: 0x0600C77B RID: 51067 RVA: 0x007E3B20 File Offset: 0x007E1D20
		Private _PointOfSaleToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PointOfSaleToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PointOfSaleToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PointOfSaleToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PointOfSaleToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PointOfSaleToolStripMenuItem = value
				toolStripMenuItem = Me._PointOfSaleToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F5D RID: 20317
		' (get) Token: 0x0600C77C RID: 51068 RVA: 0x00059222 File Offset: 0x00057422
		' (set) Token: 0x0600C77D RID: 51069 RVA: 0x007E3B64 File Offset: 0x007E1D64
		Private _ProductOrderSectionToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductOrderSectionToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductOrderSectionToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductOrderSectionToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductOrderSectionToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductOrderSectionToolStripMenuItem = value
				toolStripMenuItem = Me._ProductOrderSectionToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F5E RID: 20318
		' (get) Token: 0x0600C77E RID: 51070 RVA: 0x0005922C File Offset: 0x0005742C
		' (set) Token: 0x0600C77F RID: 51071 RVA: 0x007E3BA8 File Offset: 0x007E1DA8
		Private _CustomerCouponManagementToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerCouponManagementToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerCouponManagementToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerCouponManagementToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerCouponManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerCouponManagementToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerCouponManagementToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F5F RID: 20319
		' (get) Token: 0x0600C780 RID: 51072 RVA: 0x00059236 File Offset: 0x00057436
		' (set) Token: 0x0600C781 RID: 51073 RVA: 0x007E3BEC File Offset: 0x007E1DEC
		Private _ContraVoucherToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ContraVoucherToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ContraVoucherToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ContraVoucherToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ContraVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ContraVoucherToolStripMenuItem = value
				toolStripMenuItem = Me._ContraVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F60 RID: 20320
		' (get) Token: 0x0600C782 RID: 51074 RVA: 0x00059240 File Offset: 0x00057440
		' (set) Token: 0x0600C783 RID: 51075 RVA: 0x007E3C30 File Offset: 0x007E1E30
		Private _Timer7 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer7 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer7_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer7
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer7 = value
				timer = Me._Timer7
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F61 RID: 20321
		' (get) Token: 0x0600C784 RID: 51076 RVA: 0x0005924A File Offset: 0x0005744A
		' (set) Token: 0x0600C785 RID: 51077 RVA: 0x007E3C74 File Offset: 0x007E1E74
		Private _JournalVoucherToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property JournalVoucherToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._JournalVoucherToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.JournalVoucherToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._JournalVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._JournalVoucherToolStripMenuItem = value
				toolStripMenuItem = Me._JournalVoucherToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F62 RID: 20322
		' (get) Token: 0x0600C786 RID: 51078 RVA: 0x00059254 File Offset: 0x00057454
		' (set) Token: 0x0600C787 RID: 51079 RVA: 0x007E3CB8 File Offset: 0x007E1EB8
		Private _ExpiredProductMenuItem As ToolStripMenuItem
		Friend Overridable Property ExpiredProductMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExpiredProductMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExpiredProductMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExpiredProductMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExpiredProductMenuItem = value
				toolStripMenuItem = Me._ExpiredProductMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F63 RID: 20323
		' (get) Token: 0x0600C788 RID: 51080 RVA: 0x0005925E File Offset: 0x0005745E
		' (set) Token: 0x0600C789 RID: 51081 RVA: 0x007E3CFC File Offset: 0x007E1EFC
		Private _CustomerOfferMessageToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerOfferMessageToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerOfferMessageToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerOfferMessageToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerOfferMessageToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerOfferMessageToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerOfferMessageToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F64 RID: 20324
		' (get) Token: 0x0600C78A RID: 51082 RVA: 0x00059268 File Offset: 0x00057468
		' (set) Token: 0x0600C78B RID: 51083 RVA: 0x007E3D40 File Offset: 0x007E1F40
		Private _CustomerMobileApkSenderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerMobileApkSenderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerMobileApkSenderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerMobileApkSenderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerMobileApkSenderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerMobileApkSenderToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerMobileApkSenderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F65 RID: 20325
		' (get) Token: 0x0600C78C RID: 51084 RVA: 0x00059272 File Offset: 0x00057472
		' (set) Token: 0x0600C78D RID: 51085 RVA: 0x007E3D84 File Offset: 0x007E1F84
		Private _ToolStripMenuItem28 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem28 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem28
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem28_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem28
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem28 = value
				toolStripMenuItem = Me._ToolStripMenuItem28
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F66 RID: 20326
		' (get) Token: 0x0600C78E RID: 51086 RVA: 0x0005927C File Offset: 0x0005747C
		' (set) Token: 0x0600C78F RID: 51087 RVA: 0x007E3DC8 File Offset: 0x007E1FC8
		Private _CustomerGiftOfferValidationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerGiftOfferValidationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerGiftOfferValidationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerGiftOfferValidationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerGiftOfferValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerGiftOfferValidationToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerGiftOfferValidationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F67 RID: 20327
		' (get) Token: 0x0600C790 RID: 51088 RVA: 0x00059286 File Offset: 0x00057486
		' (set) Token: 0x0600C791 RID: 51089 RVA: 0x007E3E0C File Offset: 0x007E200C
		Private _ToolStripMenuItem29 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem29 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem29
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem29_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem29
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem29 = value
				toolStripMenuItem = Me._ToolStripMenuItem29
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F68 RID: 20328
		' (get) Token: 0x0600C792 RID: 51090 RVA: 0x00059290 File Offset: 0x00057490
		' (set) Token: 0x0600C793 RID: 51091 RVA: 0x0005929A File Offset: 0x0005749A
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17004F69 RID: 20329
		' (get) Token: 0x0600C794 RID: 51092 RVA: 0x000592A3 File Offset: 0x000574A3
		' (set) Token: 0x0600C795 RID: 51093 RVA: 0x000592AD File Offset: 0x000574AD
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17004F6A RID: 20330
		' (get) Token: 0x0600C796 RID: 51094 RVA: 0x000592B6 File Offset: 0x000574B6
		' (set) Token: 0x0600C797 RID: 51095 RVA: 0x007E3E50 File Offset: 0x007E2050
		Private _Button17 As GelButton
		Friend Overridable Property Button17 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button17_Click_1
				Dim gelButton As GelButton = Me._Button17
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button17 = value
				gelButton = Me._Button17
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F6B RID: 20331
		' (get) Token: 0x0600C798 RID: 51096 RVA: 0x000592C0 File Offset: 0x000574C0
		' (set) Token: 0x0600C799 RID: 51097 RVA: 0x000592CA File Offset: 0x000574CA
		Friend Overridable Property LblEngine As Label

		' Token: 0x17004F6C RID: 20332
		' (get) Token: 0x0600C79A RID: 51098 RVA: 0x000592D3 File Offset: 0x000574D3
		' (set) Token: 0x0600C79B RID: 51099 RVA: 0x007E3E94 File Offset: 0x007E2094
		Private _Button13 As GelButton
		Friend Overridable Property Button13 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button13_Click_1
				Dim gelButton As GelButton = Me._Button13
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button13 = value
				gelButton = Me._Button13
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F6D RID: 20333
		' (get) Token: 0x0600C79C RID: 51100 RVA: 0x000592DD File Offset: 0x000574DD
		' (set) Token: 0x0600C79D RID: 51101 RVA: 0x007E3ED8 File Offset: 0x007E20D8
		Private _btnSaleReturn As GelButton
		Friend Overridable Property btnSaleReturn As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSaleReturn
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSaleReturn_Click
				Dim gelButton As GelButton = Me._btnSaleReturn
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSaleReturn = value
				gelButton = Me._btnSaleReturn
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F6E RID: 20334
		' (get) Token: 0x0600C79E RID: 51102 RVA: 0x000592E7 File Offset: 0x000574E7
		' (set) Token: 0x0600C79F RID: 51103 RVA: 0x007E3F1C File Offset: 0x007E211C
		Private _Button12 As GelButton
		Friend Overridable Property Button12 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button12_Click_1
				Dim gelButton As GelButton = Me._Button12
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button12 = value
				gelButton = Me._Button12
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F6F RID: 20335
		' (get) Token: 0x0600C7A0 RID: 51104 RVA: 0x000592F1 File Offset: 0x000574F1
		' (set) Token: 0x0600C7A1 RID: 51105 RVA: 0x007E3F60 File Offset: 0x007E2160
		Private _btnPurchaseReturn As GelButton
		Friend Overridable Property btnPurchaseReturn As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPurchaseReturn
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPurchaseReturn_Click
				Dim gelButton As GelButton = Me._btnPurchaseReturn
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPurchaseReturn = value
				gelButton = Me._btnPurchaseReturn
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F70 RID: 20336
		' (get) Token: 0x0600C7A2 RID: 51106 RVA: 0x000592FB File Offset: 0x000574FB
		' (set) Token: 0x0600C7A3 RID: 51107 RVA: 0x007E3FA4 File Offset: 0x007E21A4
		Private _BWChrome As BackgroundWorker
		Friend Overridable Property BWChrome As BackgroundWorker
			<CompilerGenerated()>
			Get
				Return Me._BWChrome
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As BackgroundWorker)
				Dim doWorkEventHandler As DoWorkEventHandler = AddressOf Me.BWChrome_DoWork
				Dim runWorkerCompletedEventHandler As RunWorkerCompletedEventHandler = AddressOf Me.BWChrome_RunWorkerCompleted
				Dim backgroundWorker As BackgroundWorker = Me._BWChrome
				If backgroundWorker IsNot Nothing Then
					RemoveHandler backgroundWorker.DoWork, doWorkEventHandler
					RemoveHandler backgroundWorker.RunWorkerCompleted, runWorkerCompletedEventHandler
				End If
				Me._BWChrome = value
				backgroundWorker = Me._BWChrome
				If backgroundWorker IsNot Nothing Then
					AddHandler backgroundWorker.DoWork, doWorkEventHandler
					AddHandler backgroundWorker.RunWorkerCompleted, runWorkerCompletedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F71 RID: 20337
		' (get) Token: 0x0600C7A4 RID: 51108 RVA: 0x00059305 File Offset: 0x00057505
		' (set) Token: 0x0600C7A5 RID: 51109 RVA: 0x007E4004 File Offset: 0x007E2204
		Private _tChrome As Global.System.Windows.Forms.Timer
		Friend Overridable Property tChrome As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._tChrome
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.tChrome_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._tChrome
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._tChrome = value
				timer = Me._tChrome
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F72 RID: 20338
		' (get) Token: 0x0600C7A6 RID: 51110 RVA: 0x0005930F File Offset: 0x0005750F
		' (set) Token: 0x0600C7A7 RID: 51111 RVA: 0x007E4048 File Offset: 0x007E2248
		Private _ComboPackToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ComboPackToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ComboPackToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ComboPackToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ComboPackToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ComboPackToolStripMenuItem = value
				toolStripMenuItem = Me._ComboPackToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F73 RID: 20339
		' (get) Token: 0x0600C7A8 RID: 51112 RVA: 0x00059319 File Offset: 0x00057519
		' (set) Token: 0x0600C7A9 RID: 51113 RVA: 0x007E408C File Offset: 0x007E228C
		Private _ComboPackMasterToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ComboPackMasterToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ComboPackMasterToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ComboPackMasterToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ComboPackMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ComboPackMasterToolStripMenuItem = value
				toolStripMenuItem = Me._ComboPackMasterToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F74 RID: 20340
		' (get) Token: 0x0600C7AA RID: 51114 RVA: 0x00059323 File Offset: 0x00057523
		' (set) Token: 0x0600C7AB RID: 51115 RVA: 0x007E40D0 File Offset: 0x007E22D0
		Private _ProductDiscountSetToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductDiscountSetToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductDiscountSetToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductDiscountSetToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductDiscountSetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductDiscountSetToolStripMenuItem = value
				toolStripMenuItem = Me._ProductDiscountSetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F75 RID: 20341
		' (get) Token: 0x0600C7AC RID: 51116 RVA: 0x0005932D File Offset: 0x0005752D
		' (set) Token: 0x0600C7AD RID: 51117 RVA: 0x007E4114 File Offset: 0x007E2314
		Private _EToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property EToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EToolStripMenuItem = value
				toolStripMenuItem = Me._EToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F76 RID: 20342
		' (get) Token: 0x0600C7AE RID: 51118 RVA: 0x00059337 File Offset: 0x00057537
		' (set) Token: 0x0600C7AF RID: 51119 RVA: 0x007E4158 File Offset: 0x007E2358
		Private _ExpiryProductToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ExpiryProductToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExpiryProductToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExpiryProductToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExpiryProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExpiryProductToolStripMenuItem = value
				toolStripMenuItem = Me._ExpiryProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F77 RID: 20343
		' (get) Token: 0x0600C7B0 RID: 51120 RVA: 0x00059341 File Offset: 0x00057541
		' (set) Token: 0x0600C7B1 RID: 51121 RVA: 0x007E419C File Offset: 0x007E239C
		Private _UpdatePostToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UpdatePostToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UpdatePostToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UpdatePostToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UpdatePostToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UpdatePostToolStripMenuItem = value
				toolStripMenuItem = Me._UpdatePostToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F78 RID: 20344
		' (get) Token: 0x0600C7B2 RID: 51122 RVA: 0x0005934B File Offset: 0x0005754B
		' (set) Token: 0x0600C7B3 RID: 51123 RVA: 0x00059355 File Offset: 0x00057555
		Friend Overridable Property StockRootToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17004F79 RID: 20345
		' (get) Token: 0x0600C7B4 RID: 51124 RVA: 0x0005935E File Offset: 0x0005755E
		' (set) Token: 0x0600C7B5 RID: 51125 RVA: 0x007E41E0 File Offset: 0x007E23E0
		Private _TransferProductToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TransferProductToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TransferProductToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TransferProductToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TransferProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TransferProductToolStripMenuItem = value
				toolStripMenuItem = Me._TransferProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7A RID: 20346
		' (get) Token: 0x0600C7B6 RID: 51126 RVA: 0x00059368 File Offset: 0x00057568
		' (set) Token: 0x0600C7B7 RID: 51127 RVA: 0x007E4224 File Offset: 0x007E2424
		Private _BranchAdminToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BranchAdminToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BranchAdminToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BranchAdminToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BranchAdminToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BranchAdminToolStripMenuItem = value
				toolStripMenuItem = Me._BranchAdminToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7B RID: 20347
		' (get) Token: 0x0600C7B8 RID: 51128 RVA: 0x00059372 File Offset: 0x00057572
		' (set) Token: 0x0600C7B9 RID: 51129 RVA: 0x007E4268 File Offset: 0x007E2468
		Private _TokenSendToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TokenSendToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TokenSendToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TokenSendToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TokenSendToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TokenSendToolStripMenuItem = value
				toolStripMenuItem = Me._TokenSendToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7C RID: 20348
		' (get) Token: 0x0600C7BA RID: 51130 RVA: 0x0005937C File Offset: 0x0005757C
		' (set) Token: 0x0600C7BB RID: 51131 RVA: 0x007E42AC File Offset: 0x007E24AC
		Private _TokenInToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TokenInToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TokenInToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TokenInToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TokenInToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TokenInToolStripMenuItem = value
				toolStripMenuItem = Me._TokenInToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7D RID: 20349
		' (get) Token: 0x0600C7BC RID: 51132 RVA: 0x00059386 File Offset: 0x00057586
		' (set) Token: 0x0600C7BD RID: 51133 RVA: 0x007E42F0 File Offset: 0x007E24F0
		Private _TokenSeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TokenSeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TokenSeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TokenSeToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TokenSeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TokenSeToolStripMenuItem = value
				toolStripMenuItem = Me._TokenSeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7E RID: 20350
		' (get) Token: 0x0600C7BE RID: 51134 RVA: 0x00059390 File Offset: 0x00057590
		' (set) Token: 0x0600C7BF RID: 51135 RVA: 0x007E4334 File Offset: 0x007E2534
		Private _CreateBanarToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CreateBanarToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CreateBanarToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CreateBanarToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CreateBanarToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CreateBanarToolStripMenuItem = value
				toolStripMenuItem = Me._CreateBanarToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F7F RID: 20351
		' (get) Token: 0x0600C7C0 RID: 51136 RVA: 0x0005939A File Offset: 0x0005759A
		' (set) Token: 0x0600C7C1 RID: 51137 RVA: 0x007E4378 File Offset: 0x007E2578
		Private _ComboPackBarcodeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ComboPackBarcodeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ComboPackBarcodeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ComboPackBarcodeToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ComboPackBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ComboPackBarcodeToolStripMenuItem = value
				toolStripMenuItem = Me._ComboPackBarcodeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F80 RID: 20352
		' (get) Token: 0x0600C7C2 RID: 51138 RVA: 0x000593A4 File Offset: 0x000575A4
		' (set) Token: 0x0600C7C3 RID: 51139 RVA: 0x007E43BC File Offset: 0x007E25BC
		Private _SalesManPaymentToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SalesManPaymentToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SalesManPaymentToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SalesManPaymentToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SalesManPaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SalesManPaymentToolStripMenuItem = value
				toolStripMenuItem = Me._SalesManPaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F81 RID: 20353
		' (get) Token: 0x0600C7C4 RID: 51140 RVA: 0x000593AE File Offset: 0x000575AE
		' (set) Token: 0x0600C7C5 RID: 51141 RVA: 0x007E4400 File Offset: 0x007E2600
		Private _BarcodeToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property BarcodeToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BarcodeToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BarcodeToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BarcodeToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BarcodeToolStripMenuItem1 = value
				toolStripMenuItem = Me._BarcodeToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F82 RID: 20354
		' (get) Token: 0x0600C7C6 RID: 51142 RVA: 0x000593B8 File Offset: 0x000575B8
		' (set) Token: 0x0600C7C7 RID: 51143 RVA: 0x007E4444 File Offset: 0x007E2644
		Private _BarcodePrintToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BarcodePrintToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BarcodePrintToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BarcodePrintToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BarcodePrintToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BarcodePrintToolStripMenuItem = value
				toolStripMenuItem = Me._BarcodePrintToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F83 RID: 20355
		' (get) Token: 0x0600C7C8 RID: 51144 RVA: 0x000593C2 File Offset: 0x000575C2
		' (set) Token: 0x0600C7C9 RID: 51145 RVA: 0x007E4488 File Offset: 0x007E2688
		Private _Test1ToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property Test1ToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._Test1ToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.Test1ToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._Test1ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._Test1ToolStripMenuItem = value
				toolStripMenuItem = Me._Test1ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F84 RID: 20356
		' (get) Token: 0x0600C7CA RID: 51146 RVA: 0x000593CC File Offset: 0x000575CC
		' (set) Token: 0x0600C7CB RID: 51147 RVA: 0x007E44CC File Offset: 0x007E26CC
		Private _cmbChartType As ComboBox
		Friend Overridable Property cmbChartType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbChartType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbChartType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbChartType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbChartType = value
				comboBox = Me._cmbChartType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F85 RID: 20357
		' (get) Token: 0x0600C7CC RID: 51148 RVA: 0x000593D6 File Offset: 0x000575D6
		' (set) Token: 0x0600C7CD RID: 51149 RVA: 0x000593E0 File Offset: 0x000575E0
		Friend Overridable Property LblSenderId As Label

		' Token: 0x17004F86 RID: 20358
		' (get) Token: 0x0600C7CE RID: 51150 RVA: 0x000593E9 File Offset: 0x000575E9
		' (set) Token: 0x0600C7CF RID: 51151 RVA: 0x000593F3 File Offset: 0x000575F3
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004F87 RID: 20359
		' (get) Token: 0x0600C7D0 RID: 51152 RVA: 0x000593FC File Offset: 0x000575FC
		' (set) Token: 0x0600C7D1 RID: 51153 RVA: 0x00059406 File Offset: 0x00057606
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17004F88 RID: 20360
		' (get) Token: 0x0600C7D2 RID: 51154 RVA: 0x0005940F File Offset: 0x0005760F
		' (set) Token: 0x0600C7D3 RID: 51155 RVA: 0x00059419 File Offset: 0x00057619
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17004F89 RID: 20361
		' (get) Token: 0x0600C7D4 RID: 51156 RVA: 0x00059422 File Offset: 0x00057622
		' (set) Token: 0x0600C7D5 RID: 51157 RVA: 0x0005942C File Offset: 0x0005762C
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004F8A RID: 20362
		' (get) Token: 0x0600C7D6 RID: 51158 RVA: 0x00059435 File Offset: 0x00057635
		' (set) Token: 0x0600C7D7 RID: 51159 RVA: 0x0005943F File Offset: 0x0005763F
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004F8B RID: 20363
		' (get) Token: 0x0600C7D8 RID: 51160 RVA: 0x00059448 File Offset: 0x00057648
		' (set) Token: 0x0600C7D9 RID: 51161 RVA: 0x00059452 File Offset: 0x00057652
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004F8C RID: 20364
		' (get) Token: 0x0600C7DA RID: 51162 RVA: 0x0005945B File Offset: 0x0005765B
		' (set) Token: 0x0600C7DB RID: 51163 RVA: 0x00059465 File Offset: 0x00057665
		Friend Overridable Property TableLayoutPanel9 As TableLayoutPanel

		' Token: 0x17004F8D RID: 20365
		' (get) Token: 0x0600C7DC RID: 51164 RVA: 0x0005946E File Offset: 0x0005766E
		' (set) Token: 0x0600C7DD RID: 51165 RVA: 0x00059478 File Offset: 0x00057678
		Friend Overridable Property Label51 As Label

		' Token: 0x17004F8E RID: 20366
		' (get) Token: 0x0600C7DE RID: 51166 RVA: 0x00059481 File Offset: 0x00057681
		' (set) Token: 0x0600C7DF RID: 51167 RVA: 0x0005948B File Offset: 0x0005768B
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17004F8F RID: 20367
		' (get) Token: 0x0600C7E0 RID: 51168 RVA: 0x00059494 File Offset: 0x00057694
		' (set) Token: 0x0600C7E1 RID: 51169 RVA: 0x0005949E File Offset: 0x0005769E
		Friend Overridable Property TableLayoutPanel2 As TableLayoutPanel

		' Token: 0x17004F90 RID: 20368
		' (get) Token: 0x0600C7E2 RID: 51170 RVA: 0x000594A7 File Offset: 0x000576A7
		' (set) Token: 0x0600C7E3 RID: 51171 RVA: 0x007E4510 File Offset: 0x007E2710
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F91 RID: 20369
		' (get) Token: 0x0600C7E4 RID: 51172 RVA: 0x000594B1 File Offset: 0x000576B1
		' (set) Token: 0x0600C7E5 RID: 51173 RVA: 0x007E4554 File Offset: 0x007E2754
		Private _Button8 As Button
		Friend Overridable Property Button8 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button8_Click
				Dim button As Button = Me._Button8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button8 = value
				button = Me._Button8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004F92 RID: 20370
		' (get) Token: 0x0600C7E6 RID: 51174 RVA: 0x000594BB File Offset: 0x000576BB
		' (set) Token: 0x0600C7E7 RID: 51175 RVA: 0x007E4598 File Offset: 0x007E2798
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

		' Token: 0x17004F93 RID: 20371
		' (get) Token: 0x0600C7E8 RID: 51176 RVA: 0x000594C5 File Offset: 0x000576C5
		' (set) Token: 0x0600C7E9 RID: 51177 RVA: 0x007E45DC File Offset: 0x007E27DC
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

		' Token: 0x17004F94 RID: 20372
		' (get) Token: 0x0600C7EA RID: 51178 RVA: 0x000594CF File Offset: 0x000576CF
		' (set) Token: 0x0600C7EB RID: 51179 RVA: 0x007E4620 File Offset: 0x007E2820
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

		' Token: 0x17004F95 RID: 20373
		' (get) Token: 0x0600C7EC RID: 51180 RVA: 0x000594D9 File Offset: 0x000576D9
		' (set) Token: 0x0600C7ED RID: 51181 RVA: 0x007E4664 File Offset: 0x007E2864
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

		' Token: 0x17004F96 RID: 20374
		' (get) Token: 0x0600C7EE RID: 51182 RVA: 0x000594E3 File Offset: 0x000576E3
		' (set) Token: 0x0600C7EF RID: 51183 RVA: 0x007E46A8 File Offset: 0x007E28A8
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

		' Token: 0x17004F97 RID: 20375
		' (get) Token: 0x0600C7F0 RID: 51184 RVA: 0x000594ED File Offset: 0x000576ED
		' (set) Token: 0x0600C7F1 RID: 51185 RVA: 0x007E46EC File Offset: 0x007E28EC
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

		' Token: 0x17004F98 RID: 20376
		' (get) Token: 0x0600C7F2 RID: 51186 RVA: 0x000594F7 File Offset: 0x000576F7
		' (set) Token: 0x0600C7F3 RID: 51187 RVA: 0x007E4730 File Offset: 0x007E2930
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

		' Token: 0x17004F99 RID: 20377
		' (get) Token: 0x0600C7F4 RID: 51188 RVA: 0x00059501 File Offset: 0x00057701
		' (set) Token: 0x0600C7F5 RID: 51189 RVA: 0x0005950B File Offset: 0x0005770B
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004F9A RID: 20378
		' (get) Token: 0x0600C7F6 RID: 51190 RVA: 0x00059514 File Offset: 0x00057714
		' (set) Token: 0x0600C7F7 RID: 51191 RVA: 0x0005951E File Offset: 0x0005771E
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17004F9B RID: 20379
		' (get) Token: 0x0600C7F8 RID: 51192 RVA: 0x00059527 File Offset: 0x00057727
		' (set) Token: 0x0600C7F9 RID: 51193 RVA: 0x00059531 File Offset: 0x00057731
		Friend Overridable Property Chart1 As Chart

		' Token: 0x17004F9C RID: 20380
		' (get) Token: 0x0600C7FA RID: 51194 RVA: 0x0005953A File Offset: 0x0005773A
		' (set) Token: 0x0600C7FB RID: 51195 RVA: 0x00059544 File Offset: 0x00057744
		Friend Overridable Property Label49 As Label

		' Token: 0x17004F9D RID: 20381
		' (get) Token: 0x0600C7FC RID: 51196 RVA: 0x0005954D File Offset: 0x0005774D
		' (set) Token: 0x0600C7FD RID: 51197 RVA: 0x00059557 File Offset: 0x00057757
		Friend Overridable Property txtDB As TextBox

		' Token: 0x17004F9E RID: 20382
		' (get) Token: 0x0600C7FE RID: 51198 RVA: 0x00059560 File Offset: 0x00057760
		' (set) Token: 0x0600C7FF RID: 51199 RVA: 0x0005956A File Offset: 0x0005776A
		Friend Overridable Property Label5 As Label

		' Token: 0x17004F9F RID: 20383
		' (get) Token: 0x0600C800 RID: 51200 RVA: 0x00059573 File Offset: 0x00057773
		' (set) Token: 0x0600C801 RID: 51201 RVA: 0x0005957D File Offset: 0x0005777D
		Friend Overridable Property Label1 As Label

		' Token: 0x17004FA0 RID: 20384
		' (get) Token: 0x0600C802 RID: 51202 RVA: 0x00059586 File Offset: 0x00057786
		' (set) Token: 0x0600C803 RID: 51203 RVA: 0x00059590 File Offset: 0x00057790
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17004FA1 RID: 20385
		' (get) Token: 0x0600C804 RID: 51204 RVA: 0x00059599 File Offset: 0x00057799
		' (set) Token: 0x0600C805 RID: 51205 RVA: 0x000595A3 File Offset: 0x000577A3
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17004FA2 RID: 20386
		' (get) Token: 0x0600C806 RID: 51206 RVA: 0x000595AC File Offset: 0x000577AC
		' (set) Token: 0x0600C807 RID: 51207 RVA: 0x007E4774 File Offset: 0x007E2974
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

		' Token: 0x17004FA3 RID: 20387
		' (get) Token: 0x0600C808 RID: 51208 RVA: 0x000595B6 File Offset: 0x000577B6
		' (set) Token: 0x0600C809 RID: 51209 RVA: 0x000595C0 File Offset: 0x000577C0
		Friend Overridable Property lblCName As Label

		' Token: 0x17004FA4 RID: 20388
		' (get) Token: 0x0600C80A RID: 51210 RVA: 0x000595C9 File Offset: 0x000577C9
		' (set) Token: 0x0600C80B RID: 51211 RVA: 0x007E47B8 File Offset: 0x007E29B8
		Private _Button15 As Button
		Friend Overridable Property Button15 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button15_Click
				Dim button As Button = Me._Button15
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button15 = value
				button = Me._Button15
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FA5 RID: 20389
		' (get) Token: 0x0600C80C RID: 51212 RVA: 0x000595D3 File Offset: 0x000577D3
		' (set) Token: 0x0600C80D RID: 51213 RVA: 0x007E47FC File Offset: 0x007E29FC
		Private _Button14 As Button
		Friend Overridable Property Button14 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button14_Click
				Dim button As Button = Me._Button14
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button14 = value
				button = Me._Button14
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FA6 RID: 20390
		' (get) Token: 0x0600C80E RID: 51214 RVA: 0x000595DD File Offset: 0x000577DD
		' (set) Token: 0x0600C80F RID: 51215 RVA: 0x000595E7 File Offset: 0x000577E7
		Friend Overridable Property TableLayoutPanel5 As TableLayoutPanel

		' Token: 0x17004FA7 RID: 20391
		' (get) Token: 0x0600C810 RID: 51216 RVA: 0x000595F0 File Offset: 0x000577F0
		' (set) Token: 0x0600C811 RID: 51217 RVA: 0x007E4840 File Offset: 0x007E2A40
		Private _Label6 As Label
		Friend Overridable Property Label6 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label6_Backup
				Dim label As Label = Me._Label6
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label6 = value
				label = Me._Label6
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FA8 RID: 20392
		' (get) Token: 0x0600C812 RID: 51218 RVA: 0x000595FA File Offset: 0x000577FA
		' (set) Token: 0x0600C813 RID: 51219 RVA: 0x007E4884 File Offset: 0x007E2A84
		Private _Label52 As Label
		Friend Overridable Property Label52 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label52
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label52_Click
				Dim label As Label = Me._Label52
				If label IsNot Nothing Then
					RemoveHandler label.Click, eventHandler
				End If
				Me._Label52 = value
				label = Me._Label52
				If label IsNot Nothing Then
					AddHandler label.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FA9 RID: 20393
		' (get) Token: 0x0600C814 RID: 51220 RVA: 0x00059604 File Offset: 0x00057804
		' (set) Token: 0x0600C815 RID: 51221 RVA: 0x007E48C8 File Offset: 0x007E2AC8
		Private _Label10 As Label
		Friend Overridable Property Label10 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label10_Backup
				Dim label As Label = Me._Label10
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label10 = value
				label = Me._Label10
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FAA RID: 20394
		' (get) Token: 0x0600C816 RID: 51222 RVA: 0x0005960E File Offset: 0x0005780E
		' (set) Token: 0x0600C817 RID: 51223 RVA: 0x007E490C File Offset: 0x007E2B0C
		Private _Label17 As Label
		Friend Overridable Property Label17 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label17_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Label17_MouseHover
				Dim label As Label = Me._Label17
				If label IsNot Nothing Then
					RemoveHandler label.Click, eventHandler
					RemoveHandler label.MouseHover, eventHandler2
				End If
				Me._Label17 = value
				label = Me._Label17
				If label IsNot Nothing Then
					AddHandler label.Click, eventHandler
					AddHandler label.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004FAB RID: 20395
		' (get) Token: 0x0600C818 RID: 51224 RVA: 0x00059618 File Offset: 0x00057818
		' (set) Token: 0x0600C819 RID: 51225 RVA: 0x007E496C File Offset: 0x007E2B6C
		Private _Label7 As Label
		Friend Overridable Property Label7 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label7_Backup
				Dim label As Label = Me._Label7
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label7 = value
				label = Me._Label7
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FAC RID: 20396
		' (get) Token: 0x0600C81A RID: 51226 RVA: 0x00059622 File Offset: 0x00057822
		' (set) Token: 0x0600C81B RID: 51227 RVA: 0x007E49B0 File Offset: 0x007E2BB0
		Private _Label3 As Label
		Friend Overridable Property Label3 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label3_Backup
				Dim label As Label = Me._Label3
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label3 = value
				label = Me._Label3
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FAD RID: 20397
		' (get) Token: 0x0600C81C RID: 51228 RVA: 0x0005962C File Offset: 0x0005782C
		' (set) Token: 0x0600C81D RID: 51229 RVA: 0x007E49F4 File Offset: 0x007E2BF4
		Private _Label4 As Label
		Friend Overridable Property Label4 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label4_Backup
				Dim eventHandler2 As EventHandler = AddressOf Me.Label4_Click
				Dim label As Label = Me._Label4
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
					RemoveHandler label.Click, eventHandler2
				End If
				Me._Label4 = value
				label = Me._Label4
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
					AddHandler label.Click, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004FAE RID: 20398
		' (get) Token: 0x0600C81E RID: 51230 RVA: 0x00059636 File Offset: 0x00057836
		' (set) Token: 0x0600C81F RID: 51231 RVA: 0x007E4A54 File Offset: 0x007E2C54
		Private _Label8 As Label
		Friend Overridable Property Label8 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label8_Backup
				Dim label As Label = Me._Label8
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label8 = value
				label = Me._Label8
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FAF RID: 20399
		' (get) Token: 0x0600C820 RID: 51232 RVA: 0x00059640 File Offset: 0x00057840
		' (set) Token: 0x0600C821 RID: 51233 RVA: 0x007E4A98 File Offset: 0x007E2C98
		Private _Label9 As Label
		Friend Overridable Property Label9 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label9_Backup
				Dim label As Label = Me._Label9
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label9 = value
				label = Me._Label9
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB0 RID: 20400
		' (get) Token: 0x0600C822 RID: 51234 RVA: 0x0005964A File Offset: 0x0005784A
		' (set) Token: 0x0600C823 RID: 51235 RVA: 0x007E4ADC File Offset: 0x007E2CDC
		Private _Label18 As Label
		Friend Overridable Property Label18 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label18_Backup
				Dim label As Label = Me._Label18
				If label IsNot Nothing Then
					RemoveHandler label.MouseHover, eventHandler
				End If
				Me._Label18 = value
				label = Me._Label18
				If label IsNot Nothing Then
					AddHandler label.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB1 RID: 20401
		' (get) Token: 0x0600C824 RID: 51236 RVA: 0x00059654 File Offset: 0x00057854
		' (set) Token: 0x0600C825 RID: 51237 RVA: 0x0005965E File Offset: 0x0005785E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004FB2 RID: 20402
		' (get) Token: 0x0600C826 RID: 51238 RVA: 0x00059667 File Offset: 0x00057867
		' (set) Token: 0x0600C827 RID: 51239 RVA: 0x00059671 File Offset: 0x00057871
		Friend Overridable Property PictureBox3 As PictureBox

		' Token: 0x17004FB3 RID: 20403
		' (get) Token: 0x0600C828 RID: 51240 RVA: 0x0005967A File Offset: 0x0005787A
		' (set) Token: 0x0600C829 RID: 51241 RVA: 0x007E4B20 File Offset: 0x007E2D20
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

		' Token: 0x17004FB4 RID: 20404
		' (get) Token: 0x0600C82A RID: 51242 RVA: 0x00059684 File Offset: 0x00057884
		' (set) Token: 0x0600C82B RID: 51243 RVA: 0x007E4B64 File Offset: 0x007E2D64
		Private _LogActivityToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property LogActivityToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LogActivityToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LogActivityToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LogActivityToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LogActivityToolStripMenuItem1 = value
				toolStripMenuItem = Me._LogActivityToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB5 RID: 20405
		' (get) Token: 0x0600C82C RID: 51244 RVA: 0x0005968E File Offset: 0x0005788E
		' (set) Token: 0x0600C82D RID: 51245 RVA: 0x007E4BA8 File Offset: 0x007E2DA8
		Private _ToolStripMenuItem5 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem5 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem5_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem5
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem5 = value
				toolStripMenuItem = Me._ToolStripMenuItem5
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB6 RID: 20406
		' (get) Token: 0x0600C82E RID: 51246 RVA: 0x00059698 File Offset: 0x00057898
		' (set) Token: 0x0600C82F RID: 51247 RVA: 0x007E4BEC File Offset: 0x007E2DEC
		Private _GalleryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property GalleryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._GalleryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.GalleryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._GalleryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._GalleryToolStripMenuItem = value
				toolStripMenuItem = Me._GalleryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB7 RID: 20407
		' (get) Token: 0x0600C830 RID: 51248 RVA: 0x000596A2 File Offset: 0x000578A2
		' (set) Token: 0x0600C831 RID: 51249 RVA: 0x007E4C30 File Offset: 0x007E2E30
		Private _TaskManagerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TaskManagerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TaskManagerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TaskManagerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TaskManagerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TaskManagerToolStripMenuItem = value
				toolStripMenuItem = Me._TaskManagerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB8 RID: 20408
		' (get) Token: 0x0600C832 RID: 51250 RVA: 0x000596AC File Offset: 0x000578AC
		' (set) Token: 0x0600C833 RID: 51251 RVA: 0x007E4C74 File Offset: 0x007E2E74
		Private _WordToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property WordToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._WordToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.WordToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._WordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._WordToolStripMenuItem = value
				toolStripMenuItem = Me._WordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FB9 RID: 20409
		' (get) Token: 0x0600C834 RID: 51252 RVA: 0x000596B6 File Offset: 0x000578B6
		' (set) Token: 0x0600C835 RID: 51253 RVA: 0x007E4CB8 File Offset: 0x007E2EB8
		Private _ExcelToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ExcelToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExcelToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExcelToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExcelToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExcelToolStripMenuItem = value
				toolStripMenuItem = Me._ExcelToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FBA RID: 20410
		' (get) Token: 0x0600C836 RID: 51254 RVA: 0x000596C0 File Offset: 0x000578C0
		' (set) Token: 0x0600C837 RID: 51255 RVA: 0x007E4CFC File Offset: 0x007E2EFC
		Private _OutlookToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property OutlookToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._OutlookToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.OutlookToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._OutlookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._OutlookToolStripMenuItem = value
				toolStripMenuItem = Me._OutlookToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FBB RID: 20411
		' (get) Token: 0x0600C838 RID: 51256 RVA: 0x000596CA File Offset: 0x000578CA
		' (set) Token: 0x0600C839 RID: 51257 RVA: 0x007E4D40 File Offset: 0x007E2F40
		Private _NotepadToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property NotepadToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._NotepadToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.NotepadToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._NotepadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._NotepadToolStripMenuItem = value
				toolStripMenuItem = Me._NotepadToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FBC RID: 20412
		' (get) Token: 0x0600C83A RID: 51258 RVA: 0x000596D4 File Offset: 0x000578D4
		' (set) Token: 0x0600C83B RID: 51259 RVA: 0x000596DE File Offset: 0x000578DE
		Friend Overridable Property ToolStripMenuItem12 As ToolStripMenuItem

		' Token: 0x17004FBD RID: 20413
		' (get) Token: 0x0600C83C RID: 51260 RVA: 0x000596E7 File Offset: 0x000578E7
		' (set) Token: 0x0600C83D RID: 51261 RVA: 0x007E4D84 File Offset: 0x007E2F84
		Private _UserControlToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UserControlToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UserControlToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UserControlToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UserControlToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UserControlToolStripMenuItem = value
				toolStripMenuItem = Me._UserControlToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FBE RID: 20414
		' (get) Token: 0x0600C83E RID: 51262 RVA: 0x000596F1 File Offset: 0x000578F1
		' (set) Token: 0x0600C83F RID: 51263 RVA: 0x007E4DC8 File Offset: 0x007E2FC8
		Private _MultiBranchReportDashboardToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property MultiBranchReportDashboardToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._MultiBranchReportDashboardToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.MultiBranchReportDashboardToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._MultiBranchReportDashboardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._MultiBranchReportDashboardToolStripMenuItem = value
				toolStripMenuItem = Me._MultiBranchReportDashboardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FBF RID: 20415
		' (get) Token: 0x0600C840 RID: 51264 RVA: 0x000596FB File Offset: 0x000578FB
		' (set) Token: 0x0600C841 RID: 51265 RVA: 0x007E4E0C File Offset: 0x007E300C
		Private _ReminderRecordToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ReminderRecordToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ReminderRecordToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ReminderRecordToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ReminderRecordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ReminderRecordToolStripMenuItem = value
				toolStripMenuItem = Me._ReminderRecordToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC0 RID: 20416
		' (get) Token: 0x0600C842 RID: 51266 RVA: 0x00059705 File Offset: 0x00057905
		' (set) Token: 0x0600C843 RID: 51267 RVA: 0x007E4E50 File Offset: 0x007E3050
		Private _UserRegistrationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UserRegistrationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UserRegistrationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UserRegistrationToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UserRegistrationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UserRegistrationToolStripMenuItem = value
				toolStripMenuItem = Me._UserRegistrationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC1 RID: 20417
		' (get) Token: 0x0600C844 RID: 51268 RVA: 0x0005970F File Offset: 0x0005790F
		' (set) Token: 0x0600C845 RID: 51269 RVA: 0x007E4E94 File Offset: 0x007E3094
		Private _DeleteCompanyToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DeleteCompanyToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DeleteCompanyToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DeleteCompanyToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DeleteCompanyToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DeleteCompanyToolStripMenuItem = value
				toolStripMenuItem = Me._DeleteCompanyToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC2 RID: 20418
		' (get) Token: 0x0600C846 RID: 51270 RVA: 0x00059719 File Offset: 0x00057919
		' (set) Token: 0x0600C847 RID: 51271 RVA: 0x007E4ED8 File Offset: 0x007E30D8
		Private _FinancialYearChangeToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property FinancialYearChangeToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._FinancialYearChangeToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.FinancialYearChangeToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._FinancialYearChangeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._FinancialYearChangeToolStripMenuItem = value
				toolStripMenuItem = Me._FinancialYearChangeToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC3 RID: 20419
		' (get) Token: 0x0600C848 RID: 51272 RVA: 0x00059723 File Offset: 0x00057923
		' (set) Token: 0x0600C849 RID: 51273 RVA: 0x007E4F1C File Offset: 0x007E311C
		Private _PurchaseBillMRPUpdateToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseBillMRPUpdateToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseBillMRPUpdateToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseBillMRPUpdateToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseBillMRPUpdateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseBillMRPUpdateToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseBillMRPUpdateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC4 RID: 20420
		' (get) Token: 0x0600C84A RID: 51274 RVA: 0x0005972D File Offset: 0x0005792D
		' (set) Token: 0x0600C84B RID: 51275 RVA: 0x007E4F60 File Offset: 0x007E3160
		Private _PurchaseStockToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseStockToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseStockToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseStockToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseStockToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseStockToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseStockToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC5 RID: 20421
		' (get) Token: 0x0600C84C RID: 51276 RVA: 0x00059737 File Offset: 0x00057937
		' (set) Token: 0x0600C84D RID: 51277 RVA: 0x007E4FA4 File Offset: 0x007E31A4
		Private _LanguageSetToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LanguageSetToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LanguageSetToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LanguageSetToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LanguageSetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LanguageSetToolStripMenuItem = value
				toolStripMenuItem = Me._LanguageSetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC6 RID: 20422
		' (get) Token: 0x0600C84E RID: 51278 RVA: 0x00059741 File Offset: 0x00057941
		' (set) Token: 0x0600C84F RID: 51279 RVA: 0x007E4FE8 File Offset: 0x007E31E8
		Private _CustomerLedgerLoyaltyToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CustomerLedgerLoyaltyToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CustomerLedgerLoyaltyToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CustomerLedgerLoyaltyToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CustomerLedgerLoyaltyToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CustomerLedgerLoyaltyToolStripMenuItem = value
				toolStripMenuItem = Me._CustomerLedgerLoyaltyToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC7 RID: 20423
		' (get) Token: 0x0600C850 RID: 51280 RVA: 0x0005974B File Offset: 0x0005794B
		' (set) Token: 0x0600C851 RID: 51281 RVA: 0x007E502C File Offset: 0x007E322C
		Private _MultiBranchSettingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property MultiBranchSettingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._MultiBranchSettingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.MultiBranchSettingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._MultiBranchSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._MultiBranchSettingToolStripMenuItem = value
				toolStripMenuItem = Me._MultiBranchSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FC8 RID: 20424
		' (get) Token: 0x0600C852 RID: 51282 RVA: 0x00059755 File Offset: 0x00057955
		' (set) Token: 0x0600C853 RID: 51283 RVA: 0x0005975F File Offset: 0x0005795F
		Friend Overridable Property BranchStockManagementToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17004FC9 RID: 20425
		' (get) Token: 0x0600C854 RID: 51284 RVA: 0x00059768 File Offset: 0x00057968
		' (set) Token: 0x0600C855 RID: 51285 RVA: 0x007E5070 File Offset: 0x007E3270
		Private _BranchStockOutToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BranchStockOutToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BranchStockOutToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BranchStockOutToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BranchStockOutToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BranchStockOutToolStripMenuItem = value
				toolStripMenuItem = Me._BranchStockOutToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FCA RID: 20426
		' (get) Token: 0x0600C856 RID: 51286 RVA: 0x00059772 File Offset: 0x00057972
		' (set) Token: 0x0600C857 RID: 51287 RVA: 0x007E50B4 File Offset: 0x007E32B4
		Private _BranchStockInToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BranchStockInToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BranchStockInToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BranchStockInToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BranchStockInToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BranchStockInToolStripMenuItem = value
				toolStripMenuItem = Me._BranchStockInToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FCB RID: 20427
		' (get) Token: 0x0600C858 RID: 51288 RVA: 0x0005977C File Offset: 0x0005797C
		' (set) Token: 0x0600C859 RID: 51289 RVA: 0x007E50F8 File Offset: 0x007E32F8
		Private _WhatsAppConfiguration2ToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property WhatsAppConfiguration2ToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._WhatsAppConfiguration2ToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.WhatsAppConfiguration2ToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._WhatsAppConfiguration2ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._WhatsAppConfiguration2ToolStripMenuItem = value
				toolStripMenuItem = Me._WhatsAppConfiguration2ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FCC RID: 20428
		' (get) Token: 0x0600C85A RID: 51290 RVA: 0x00059786 File Offset: 0x00057986
		' (set) Token: 0x0600C85B RID: 51291 RVA: 0x007E513C File Offset: 0x007E333C
		Private _WhatsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property WhatsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._WhatsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.WhatsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._WhatsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._WhatsToolStripMenuItem = value
				toolStripMenuItem = Me._WhatsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FCD RID: 20429
		' (get) Token: 0x0600C85C RID: 51292 RVA: 0x00059790 File Offset: 0x00057990
		' (set) Token: 0x0600C85D RID: 51293 RVA: 0x0005979A File Offset: 0x0005799A
		Friend Overridable Property LblEngine1 As Label

		' Token: 0x17004FCE RID: 20430
		' (get) Token: 0x0600C85E RID: 51294 RVA: 0x000597A3 File Offset: 0x000579A3
		' (set) Token: 0x0600C85F RID: 51295 RVA: 0x007E5180 File Offset: 0x007E3380
		Private _UploadTestToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UploadTestToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UploadTestToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UploadTestToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UploadTestToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UploadTestToolStripMenuItem = value
				toolStripMenuItem = Me._UploadTestToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FCF RID: 20431
		' (get) Token: 0x0600C860 RID: 51296 RVA: 0x000597AD File Offset: 0x000579AD
		' (set) Token: 0x0600C861 RID: 51297 RVA: 0x000597B7 File Offset: 0x000579B7
		Friend Overridable Property btnNotification As GelButton

		' Token: 0x17004FD0 RID: 20432
		' (get) Token: 0x0600C862 RID: 51298 RVA: 0x000597C0 File Offset: 0x000579C0
		' (set) Token: 0x0600C863 RID: 51299 RVA: 0x007E51C4 File Offset: 0x007E33C4
		Private _ProductsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductsToolStripMenuItem_Click_1
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductsToolStripMenuItem = value
				toolStripMenuItem = Me._ProductsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD1 RID: 20433
		' (get) Token: 0x0600C864 RID: 51300 RVA: 0x000597CA File Offset: 0x000579CA
		' (set) Token: 0x0600C865 RID: 51301 RVA: 0x007E5208 File Offset: 0x007E3408
		Private _Products2ToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property Products2ToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._Products2ToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.Products2ToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._Products2ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._Products2ToolStripMenuItem = value
				toolStripMenuItem = Me._Products2ToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD2 RID: 20434
		' (get) Token: 0x0600C866 RID: 51302 RVA: 0x000597D4 File Offset: 0x000579D4
		' (set) Token: 0x0600C867 RID: 51303 RVA: 0x007E524C File Offset: 0x007E344C
		Private _PrinterSettingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PrinterSettingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PrinterSettingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PrinterSettingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PrinterSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PrinterSettingToolStripMenuItem = value
				toolStripMenuItem = Me._PrinterSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD3 RID: 20435
		' (get) Token: 0x0600C868 RID: 51304 RVA: 0x000597DE File Offset: 0x000579DE
		' (set) Token: 0x0600C869 RID: 51305 RVA: 0x007E5290 File Offset: 0x007E3490
		Private _EwayBillSettingToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property EwayBillSettingToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EwayBillSettingToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EwayBillSettingToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EwayBillSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EwayBillSettingToolStripMenuItem = value
				toolStripMenuItem = Me._EwayBillSettingToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD4 RID: 20436
		' (get) Token: 0x0600C86A RID: 51306 RVA: 0x000597E8 File Offset: 0x000579E8
		' (set) Token: 0x0600C86B RID: 51307 RVA: 0x007E52D4 File Offset: 0x007E34D4
		Private _Button16 As Button
		Friend Overridable Property Button16 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button16_Click_1
				Dim button As Button = Me._Button16
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button16 = value
				button = Me._Button16
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD5 RID: 20437
		' (get) Token: 0x0600C86C RID: 51308 RVA: 0x000597F2 File Offset: 0x000579F2
		' (set) Token: 0x0600C86D RID: 51309 RVA: 0x007E5318 File Offset: 0x007E3518
		Private _btnAT0 As Button
		Friend Overridable Property btnAT0 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAT0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAT0_Click
				Dim button As Button = Me._btnAT0
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAT0 = value
				button = Me._btnAT0
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD6 RID: 20438
		' (get) Token: 0x0600C86E RID: 51310 RVA: 0x000597FC File Offset: 0x000579FC
		' (set) Token: 0x0600C86F RID: 51311 RVA: 0x007E535C File Offset: 0x007E355C
		Private _Button11 As Button
		Friend Overridable Property Button11 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button11_Click_1
				Dim button As Button = Me._Button11
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button11 = value
				button = Me._Button11
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD7 RID: 20439
		' (get) Token: 0x0600C870 RID: 51312 RVA: 0x00059806 File Offset: 0x00057A06
		' (set) Token: 0x0600C871 RID: 51313 RVA: 0x007E53A0 File Offset: 0x007E35A0
		Private _GelButton2 As Button
		Friend Overridable Property GelButton2 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim button As Button = Me._GelButton2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton2 = value
				button = Me._GelButton2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD8 RID: 20440
		' (get) Token: 0x0600C872 RID: 51314 RVA: 0x00059810 File Offset: 0x00057A10
		' (set) Token: 0x0600C873 RID: 51315 RVA: 0x007E53E4 File Offset: 0x007E35E4
		Private _Button10 As Button
		Friend Overridable Property Button10 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click_1
				Dim button As Button = Me._Button10
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button10 = value
				button = Me._Button10
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FD9 RID: 20441
		' (get) Token: 0x0600C874 RID: 51316 RVA: 0x0005981A File Offset: 0x00057A1A
		' (set) Token: 0x0600C875 RID: 51317 RVA: 0x007E5428 File Offset: 0x007E3628
		Private _MenuTestToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property MenuTestToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._MenuTestToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.MenuTestToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._MenuTestToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._MenuTestToolStripMenuItem = value
				toolStripMenuItem = Me._MenuTestToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FDA RID: 20442
		' (get) Token: 0x0600C876 RID: 51318 RVA: 0x00059824 File Offset: 0x00057A24
		' (set) Token: 0x0600C877 RID: 51319 RVA: 0x007E546C File Offset: 0x007E366C
		Private _UpdateMenuImagesToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UpdateMenuImagesToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UpdateMenuImagesToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UpdateMenuImagesToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UpdateMenuImagesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UpdateMenuImagesToolStripMenuItem = value
				toolStripMenuItem = Me._UpdateMenuImagesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FDB RID: 20443
		' (get) Token: 0x0600C878 RID: 51320 RVA: 0x0005982E File Offset: 0x00057A2E
		' (set) Token: 0x0600C879 RID: 51321 RVA: 0x00059838 File Offset: 0x00057A38
		Friend Overridable Property flpItems_BV As FlowLayoutPanel

		' Token: 0x17004FDC RID: 20444
		' (get) Token: 0x0600C87A RID: 51322 RVA: 0x00059841 File Offset: 0x00057A41
		' (set) Token: 0x0600C87B RID: 51323 RVA: 0x0005984B File Offset: 0x00057A4B
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x17004FDD RID: 20445
		' (get) Token: 0x0600C87C RID: 51324 RVA: 0x00059854 File Offset: 0x00057A54
		' (set) Token: 0x0600C87D RID: 51325 RVA: 0x0005985E File Offset: 0x00057A5E
		Friend Overridable Property flpItemsCategory As FlowLayoutPanel

		' Token: 0x17004FDE RID: 20446
		' (get) Token: 0x0600C87E RID: 51326 RVA: 0x00059867 File Offset: 0x00057A67
		' (set) Token: 0x0600C87F RID: 51327 RVA: 0x00059871 File Offset: 0x00057A71
		Friend Overridable Property Label130 As Label

		' Token: 0x17004FDF RID: 20447
		' (get) Token: 0x0600C880 RID: 51328 RVA: 0x0005987A File Offset: 0x00057A7A
		' (set) Token: 0x0600C881 RID: 51329 RVA: 0x007E54B0 File Offset: 0x007E36B0
		Private _UpdateMenuHeaderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property UpdateMenuHeaderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._UpdateMenuHeaderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.UpdateMenuHeaderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._UpdateMenuHeaderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._UpdateMenuHeaderToolStripMenuItem = value
				toolStripMenuItem = Me._UpdateMenuHeaderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE0 RID: 20448
		' (get) Token: 0x0600C882 RID: 51330 RVA: 0x00059884 File Offset: 0x00057A84
		' (set) Token: 0x0600C883 RID: 51331 RVA: 0x007E54F4 File Offset: 0x007E36F4
		Private _Button18 As Button
		Friend Overridable Property Button18 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button18_Click
				Dim button As Button = Me._Button18
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button18 = value
				button = Me._Button18
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE1 RID: 20449
		' (get) Token: 0x0600C884 RID: 51332 RVA: 0x0005988E File Offset: 0x00057A8E
		' (set) Token: 0x0600C885 RID: 51333 RVA: 0x007E5538 File Offset: 0x007E3738
		Private _Button19 As Button
		Friend Overridable Property Button19 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button19_Click
				Dim button As Button = Me._Button19
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button19 = value
				button = Me._Button19
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE2 RID: 20450
		' (get) Token: 0x0600C886 RID: 51334 RVA: 0x00059898 File Offset: 0x00057A98
		' (set) Token: 0x0600C887 RID: 51335 RVA: 0x007E557C File Offset: 0x007E377C
		Private _Button20 As Button
		Friend Overridable Property Button20 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button20_Click
				Dim button As Button = Me._Button20
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button20 = value
				button = Me._Button20
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE3 RID: 20451
		' (get) Token: 0x0600C888 RID: 51336 RVA: 0x000598A2 File Offset: 0x00057AA2
		' (set) Token: 0x0600C889 RID: 51337 RVA: 0x007E55C0 File Offset: 0x007E37C0
		Private _Button21 As Button
		Friend Overridable Property Button21 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button21
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button21_Click
				Dim button As Button = Me._Button21
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button21 = value
				button = Me._Button21
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE4 RID: 20452
		' (get) Token: 0x0600C88A RID: 51338 RVA: 0x000598AC File Offset: 0x00057AAC
		' (set) Token: 0x0600C88B RID: 51339 RVA: 0x007E5604 File Offset: 0x007E3804
		Private _Button22 As Button
		Friend Overridable Property Button22 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button22_Click
				Dim button As Button = Me._Button22
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button22 = value
				button = Me._Button22
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE5 RID: 20453
		' (get) Token: 0x0600C88C RID: 51340 RVA: 0x000598B6 File Offset: 0x00057AB6
		' (set) Token: 0x0600C88D RID: 51341 RVA: 0x007E5648 File Offset: 0x007E3848
		Private _Button23 As Button
		Friend Overridable Property Button23 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button23
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button23_Click
				Dim button As Button = Me._Button23
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button23 = value
				button = Me._Button23
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE6 RID: 20454
		' (get) Token: 0x0600C88E RID: 51342 RVA: 0x000598C0 File Offset: 0x00057AC0
		' (set) Token: 0x0600C88F RID: 51343 RVA: 0x007E568C File Offset: 0x007E388C
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

		' Token: 0x17004FE7 RID: 20455
		' (get) Token: 0x0600C890 RID: 51344 RVA: 0x000598CA File Offset: 0x00057ACA
		' (set) Token: 0x0600C891 RID: 51345 RVA: 0x007E56D0 File Offset: 0x007E38D0
		Private _btnLeadGenerate As Button
		Friend Overridable Property btnLeadGenerate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLeadGenerate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLeadGenerate_Click
				Dim button As Button = Me._btnLeadGenerate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLeadGenerate = value
				button = Me._btnLeadGenerate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE8 RID: 20456
		' (get) Token: 0x0600C892 RID: 51346 RVA: 0x000598D4 File Offset: 0x00057AD4
		' (set) Token: 0x0600C893 RID: 51347 RVA: 0x007E5714 File Offset: 0x007E3914
		Private _Button24 As Button
		Friend Overridable Property Button24 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button24
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button24_Click
				Dim button As Button = Me._Button24
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button24 = value
				button = Me._Button24
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FE9 RID: 20457
		' (get) Token: 0x0600C894 RID: 51348 RVA: 0x000598DE File Offset: 0x00057ADE
		' (set) Token: 0x0600C895 RID: 51349 RVA: 0x007E5758 File Offset: 0x007E3958
		Private _btnSupport_Dashboard As Button
		Friend Overridable Property btnSupport_Dashboard As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSupport_Dashboard
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSupport_Dashboard_Click
				Dim button As Button = Me._btnSupport_Dashboard
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSupport_Dashboard = value
				button = Me._btnSupport_Dashboard
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FEA RID: 20458
		' (get) Token: 0x0600C896 RID: 51350 RVA: 0x000598E8 File Offset: 0x00057AE8
		' (set) Token: 0x0600C897 RID: 51351 RVA: 0x000598F2 File Offset: 0x00057AF2
		Friend Overridable Property Timer8 As Global.System.Windows.Forms.Timer

		' Token: 0x17004FEB RID: 20459
		' (get) Token: 0x0600C898 RID: 51352 RVA: 0x000598FB File Offset: 0x00057AFB
		' (set) Token: 0x0600C899 RID: 51353 RVA: 0x007E579C File Offset: 0x007E399C
		Private _GelBtnSerialWiseReport As GelButton
		Friend Overridable Property GelBtnSerialWiseReport As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelBtnSerialWiseReport
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelBtnSerialWiseReport_Click
				Dim gelButton As GelButton = Me._GelBtnSerialWiseReport
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelBtnSerialWiseReport = value
				gelButton = Me._GelBtnSerialWiseReport
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FEC RID: 20460
		' (get) Token: 0x0600C89A RID: 51354 RVA: 0x00059905 File Offset: 0x00057B05
		' (set) Token: 0x0600C89B RID: 51355 RVA: 0x007E57E0 File Offset: 0x007E39E0
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

		' Token: 0x17004FED RID: 20461
		' (get) Token: 0x0600C89C RID: 51356 RVA: 0x0005990F File Offset: 0x00057B0F
		' (set) Token: 0x0600C89D RID: 51357 RVA: 0x007E5824 File Offset: 0x007E3A24
		Private _Button25 As Button
		Friend Overridable Property Button25 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button25
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button25_Click
				Dim button As Button = Me._Button25
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button25 = value
				button = Me._Button25
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FEE RID: 20462
		' (get) Token: 0x0600C89E RID: 51358 RVA: 0x00059919 File Offset: 0x00057B19
		' (set) Token: 0x0600C89F RID: 51359 RVA: 0x007E5868 File Offset: 0x007E3A68
		Private _btnImportPro As GelButton
		Friend Overridable Property btnImportPro As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnImportPro
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnImportPro_Click
				Dim gelButton As GelButton = Me._btnImportPro
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnImportPro = value
				gelButton = Me._btnImportPro
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FEF RID: 20463
		' (get) Token: 0x0600C8A0 RID: 51360 RVA: 0x00059923 File Offset: 0x00057B23
		' (set) Token: 0x0600C8A1 RID: 51361 RVA: 0x007E58AC File Offset: 0x007E3AAC
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

		' Token: 0x17004FF0 RID: 20464
		' (get) Token: 0x0600C8A2 RID: 51362 RVA: 0x0005992D File Offset: 0x00057B2D
		' (set) Token: 0x0600C8A3 RID: 51363 RVA: 0x007E58F0 File Offset: 0x007E3AF0
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

		' Token: 0x0600C8A4 RID: 51364
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600C8A5 RID: 51365
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600C8A6 RID: 51366 RVA: 0x007E5934 File Offset: 0x007E3B34
		Public Sub UserControlSettings()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12),RTRIM(c13),RTRIM(c14),RTRIM(c15),RTRIM(c16),RTRIM(c17),RTRIM(c18),RTRIM(c19),RTRIM(c20),RTRIM(c21),RTRIM(c22),RTRIM(c23),RTRIM(c24),RTRIM(c25),RTRIM(c26),RTRIM(c27),RTRIM(c28),RTRIM(c29),RTRIM(c30),RTRIM(c31),RTRIM(c32),RTRIM(c33),RTRIM(c34),RTRIM(c35),RTRIM(c36),RTRIM(c37),RTRIM(c38),RTRIM(c39),RTRIM(c40),RTRIM(c41),RTRIM(c42),RTRIM(c43),RTRIM(c44),RTRIM(c45),RTRIM(c46),RTRIM(c47),RTRIM(c48),RTRIM(c49),RTRIM(c50),RTRIM(c51) from UserControl where UserID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblUser.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.C1 = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.C2 = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.C3 = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.C4 = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.C5 = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.C6 = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.C7 = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.C8 = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.C9 = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.C10 = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.C11 = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.C12 = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.C13 = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.C14 = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.C15 = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.C16 = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.C17 = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.C18 = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.C19 = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.C20 = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.C21 = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.C22 = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.C23 = ModCommonClasses.rdr.GetValue(22).ToString()
					Me.C24 = ModCommonClasses.rdr.GetValue(23).ToString()
					Me.C25 = ModCommonClasses.rdr.GetValue(24).ToString()
					Me.C26 = ModCommonClasses.rdr.GetValue(25).ToString()
					Me.C27 = ModCommonClasses.rdr.GetValue(26).ToString()
					Me.C28 = ModCommonClasses.rdr.GetValue(27).ToString()
					Me.C29 = ModCommonClasses.rdr.GetValue(28).ToString()
					Me.C30 = ModCommonClasses.rdr.GetValue(29).ToString()
					Me.C31 = ModCommonClasses.rdr.GetValue(30).ToString()
					Me.C32 = ModCommonClasses.rdr.GetValue(31).ToString()
					Me.C33 = ModCommonClasses.rdr.GetValue(32).ToString()
					Me.C34 = ModCommonClasses.rdr.GetValue(33).ToString()
					Me.C35 = ModCommonClasses.rdr.GetValue(34).ToString()
					Me.C36 = ModCommonClasses.rdr.GetValue(35).ToString()
					Me.C37 = ModCommonClasses.rdr.GetValue(36).ToString()
					Me.C38 = ModCommonClasses.rdr.GetValue(37).ToString()
					Me.C39 = ModCommonClasses.rdr.GetValue(38).ToString()
					Me.C40 = ModCommonClasses.rdr.GetValue(39).ToString()
					Me.C41 = ModCommonClasses.rdr.GetValue(40).ToString()
					Me.C42 = ModCommonClasses.rdr.GetValue(41).ToString()
					Me.C43 = ModCommonClasses.rdr.GetValue(42).ToString()
					Me.C44 = ModCommonClasses.rdr.GetValue(43).ToString()
					Me.C45 = ModCommonClasses.rdr.GetValue(44).ToString()
					Me.C46 = ModCommonClasses.rdr.GetValue(45).ToString()
					Me.C47 = ModCommonClasses.rdr.GetValue(46).ToString()
					Me.C48 = ModCommonClasses.rdr.GetValue(47).ToString()
					Me.C49 = ModCommonClasses.rdr.GetValue(48).ToString()
					Me.C50 = ModCommonClasses.rdr.GetValue(49).ToString()
					Me.C51 = ModCommonClasses.rdr.GetValue(50).ToString()
				Else
					Me.C1 = ""
					Me.C2 = ""
					Me.C3 = ""
					Me.C4 = ""
					Me.C5 = ""
					Me.C6 = ""
					Me.C7 = ""
					Me.C8 = ""
					Me.C9 = ""
					Me.C10 = ""
					Me.C11 = ""
					Me.C12 = ""
					Me.C13 = ""
					Me.C14 = ""
					Me.C15 = ""
					Me.C16 = ""
					Me.C17 = ""
					Me.C18 = ""
					Me.C19 = ""
					Me.C20 = ""
					Me.C21 = ""
					Me.C22 = ""
					Me.C23 = ""
					Me.C24 = ""
					Me.C25 = ""
					Me.C26 = ""
					Me.C27 = ""
					Me.C28 = ""
					Me.C29 = ""
					Me.C30 = ""
					Me.C31 = ""
					Me.C32 = ""
					Me.C33 = ""
					Me.C34 = ""
					Me.C35 = ""
					Me.C36 = ""
					Me.C37 = ""
					Me.C38 = ""
					Me.C39 = ""
					Me.C40 = ""
					Me.C41 = ""
					Me.C42 = ""
					Me.C43 = ""
					Me.C44 = ""
					Me.C45 = ""
					Me.C46 = ""
					Me.C47 = ""
					Me.C48 = ""
					Me.C49 = ""
					Me.C50 = ""
					Me.C51 = ""
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8A7 RID: 51367 RVA: 0x007E60EC File Offset: 0x007E42EC
		Public Sub UserControlValidation()
			Dim flag As Boolean = (Operators.CompareString(Me.C1, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag Then
				Me.CompanyInfoToolStripMenuItem.Visible = False
			Else
				Me.CompanyInfoToolStripMenuItem.Visible = True
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag2 Then
				Me.CompanyInfoToolStripMenuItem.Visible = True
			End If
			Dim flag3 As Boolean = (Operators.CompareString(Me.C2, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag3 Then
				Me.SaleEntryToolStripMenuItem.Visible = False
				Me.PointOfSaleToolStripMenuItem.Visible = False
				Me.Button10.Enabled = False
			Else
				Me.SaleEntryToolStripMenuItem.Visible = False
				Me.PointOfSaleToolStripMenuItem.Visible = True
				Me.Button10.Enabled = True
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag4 Then
				Me.SaleEntryToolStripMenuItem.Visible = False
				Me.PointOfSaleToolStripMenuItem.Visible = True
				Me.Button10.Enabled = True
			End If
			Dim flag5 As Boolean = (Operators.CompareString(Me.C3, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag5 Then
				Me.SaleReturnToolStripMenuItem.Visible = False
				Me.btnSaleReturn.Enabled = False
			Else
				Me.SaleReturnToolStripMenuItem.Visible = True
				Me.btnSaleReturn.Enabled = True
			End If
			Dim flag6 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag6 Then
				Me.SaleReturnToolStripMenuItem.Visible = True
				Me.btnSaleReturn.Enabled = True
			End If
			Dim flag7 As Boolean = (Operators.CompareString(Me.C4, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag7 Then
				Me.QuotationToolStripMenuItem.Visible = False
			Else
				Me.QuotationToolStripMenuItem.Visible = True
			End If
			Dim flag8 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag8 Then
				Me.QuotationToolStripMenuItem.Visible = True
			End If
			Dim flag9 As Boolean = (Operators.CompareString(Me.C5, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag9 Then
				Me.PurchaseEntryToolStripMenuItem.Visible = False
				Me.Button11.Enabled = False
			Else
				Me.PurchaseEntryToolStripMenuItem.Visible = True
				Me.Button11.Enabled = True
			End If
			Dim flag10 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag10 Then
				Me.PurchaseEntryToolStripMenuItem.Visible = True
				Me.Button11.Enabled = True
			End If
			Dim flag11 As Boolean = (Operators.CompareString(Me.C6, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag11 Then
				Me.PurchaseReturnToolStripMenuItem1.Visible = False
				Me.btnPurchaseReturn.Enabled = False
			Else
				Me.PurchaseReturnToolStripMenuItem1.Visible = True
				Me.btnPurchaseReturn.Enabled = True
			End If
			Dim flag12 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag12 Then
				Me.PurchaseReturnToolStripMenuItem1.Visible = True
				Me.btnPurchaseReturn.Enabled = True
			End If
			Dim flag13 As Boolean = (Operators.CompareString(Me.C7, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag13 Then
				Me.PurchaseOrderToolStripMenuItem.Visible = False
			Else
				Me.PurchaseOrderToolStripMenuItem.Visible = True
			End If
			Dim flag14 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag14 Then
				Me.PurchaseOrderToolStripMenuItem.Visible = True
			End If
			Dim flag15 As Boolean = (Operators.CompareString(Me.C8, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag15 Then
				Me.ReceiptToolStripMenuItem.Visible = False
				Me.Button12.Enabled = False
			Else
				Me.ReceiptToolStripMenuItem.Visible = True
				Me.Button12.Enabled = True
			End If
			Dim flag16 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag16 Then
				Me.ReceiptToolStripMenuItem.Visible = True
				Me.Button12.Enabled = True
			End If
			Dim flag17 As Boolean = (Operators.CompareString(Me.C9, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag17 Then
				Me.PaymentToolStripMenuItem.Visible = False
				Me.Button13.Enabled = False
			Else
				Me.PaymentToolStripMenuItem.Visible = True
				Me.Button13.Enabled = True
			End If
			Dim flag18 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag18 Then
				Me.PaymentToolStripMenuItem.Visible = True
				Me.Button13.Enabled = True
			End If
			Dim flag19 As Boolean = (Operators.CompareString(Me.C10, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag19 Then
				Me.IncomeVoucherToolStripMenuItem.Visible = False
			Else
				Me.IncomeVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag20 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag20 Then
				Me.IncomeVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag21 As Boolean = (Operators.CompareString(Me.C11, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag21 Then
				Me.ExpenseVoucherToolStripMenuItem.Visible = False
				Me.Button17.Enabled = False
			Else
				Me.ExpenseVoucherToolStripMenuItem.Visible = True
				Me.Button17.Enabled = True
			End If
			Dim flag22 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag22 Then
				Me.ExpenseVoucherToolStripMenuItem.Visible = True
				Me.Button17.Enabled = True
			End If
			Dim flag23 As Boolean = (Operators.CompareString(Me.C12, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag23 Then
				Me.EstimateToolStripMenuItem.Visible = False
			Else
				Me.EstimateToolStripMenuItem.Visible = True
			End If
			Dim flag24 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag24 Then
				Me.EstimateToolStripMenuItem.Visible = True
			End If
			Dim flag25 As Boolean = (Operators.CompareString(Me.C13, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag25 Then
				Me.ProductCatalogueMakerToolStripMenuItem.Visible = False
			Else
				Me.ProductCatalogueMakerToolStripMenuItem.Visible = True
			End If
			Dim flag26 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag26 Then
				Me.ProductCatalogueMakerToolStripMenuItem.Visible = True
			End If
			Dim flag27 As Boolean = (Operators.CompareString(Me.C14, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag27 Then
				Me.GalleryToolStripMenuItem.Visible = False
			Else
				Me.GalleryToolStripMenuItem.Visible = True
			End If
			Dim flag28 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag28 Then
				Me.GalleryToolStripMenuItem.Visible = True
			End If
			Dim flag29 As Boolean = (Operators.CompareString(Me.C15, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag29 Then
				Me.ProductBulkEditorToolStripMenuItem.Visible = False
				Me.CustomerBulkEditorToolStripMenuItem.Visible = False
				Me.SupplierBulkEditorToolStripMenuItem.Visible = False
				Me.SalesmanBulkEditorToolStripMenuItem.Visible = False
			Else
				Me.ProductBulkEditorToolStripMenuItem.Visible = True
				Me.CustomerBulkEditorToolStripMenuItem.Visible = True
				Me.SupplierBulkEditorToolStripMenuItem.Visible = True
				Me.SalesmanBulkEditorToolStripMenuItem.Visible = True
			End If
			Dim flag30 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag30 Then
				Me.ProductBulkEditorToolStripMenuItem.Visible = True
				Me.CustomerBulkEditorToolStripMenuItem.Visible = True
				Me.SupplierBulkEditorToolStripMenuItem.Visible = True
				Me.SalesmanBulkEditorToolStripMenuItem.Visible = True
			End If
			Dim flag31 As Boolean = (Operators.CompareString(Me.C16, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag31 Then
				Me.CustomerToolStripMenuItem1.Visible = False
				Me.Button14.Enabled = False
			Else
				Me.CustomerToolStripMenuItem1.Visible = True
				Me.Button14.Enabled = True
			End If
			Dim flag32 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag32 Then
				Me.CustomerToolStripMenuItem1.Visible = True
				Me.Button14.Enabled = True
			End If
			Dim flag33 As Boolean = (Operators.CompareString(Me.C17, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag33 Then
				Me.SupplierToolStripMenuItem2.Visible = False
				Me.Button15.Enabled = False
			Else
				Me.SupplierToolStripMenuItem2.Visible = True
				Me.Button15.Enabled = True
			End If
			Dim flag34 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag34 Then
				Me.SupplierToolStripMenuItem2.Visible = True
				Me.Button15.Enabled = True
			End If
			Dim flag35 As Boolean = (Operators.CompareString(Me.C18, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag35 Then
				Me.SalemanToolStripMenuItem.Visible = False
			Else
				Me.SalemanToolStripMenuItem.Visible = True
			End If
			Dim flag36 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag36 Then
				Me.SalemanToolStripMenuItem.Visible = True
			End If
			Dim flag37 As Boolean = (Operators.CompareString(Me.C19, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag37 Then
				Me.ProductsToolStripMenuItem1.Visible = False
				Me.Button16.Enabled = False
			Else
				Me.ProductsToolStripMenuItem1.Visible = True
				Me.Button16.Enabled = True
			End If
			Dim flag38 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag38 Then
				Me.ProductsToolStripMenuItem1.Visible = True
				Me.Button16.Enabled = True
			End If
			Dim flag39 As Boolean = (Operators.CompareString(Me.C20, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag39 Then
				Me.AboutToolStripMenuItem.Visible = False
			Else
				Me.AboutToolStripMenuItem.Visible = True
			End If
			Dim flag40 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag40 Then
				Me.AboutToolStripMenuItem.Visible = True
			End If
			Dim flag41 As Boolean = (Operators.CompareString(Me.C21, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag41 Then
				Me.ToolStripMenuItem27.Visible = False
			Else
				Me.ToolStripMenuItem27.Visible = True
			End If
			Dim flag42 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag42 Then
				Me.ToolStripMenuItem27.Visible = True
			End If
			Dim flag43 As Boolean = (Operators.CompareString(Me.C22, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag43 Then
				Me.BankReconciliationToolStripMenuItem.Visible = False
			Else
				Me.BankReconciliationToolStripMenuItem.Visible = True
			End If
			Dim flag44 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag44 Then
				Me.BankReconciliationToolStripMenuItem.Visible = True
			End If
			Dim flag45 As Boolean = (Operators.CompareString(Me.C23, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag45 Then
				Me.RecordsToolStripMenuItem.Visible = False
			Else
				Me.RecordsToolStripMenuItem.Visible = True
			End If
			Dim flag46 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag46 Then
				Me.RecordsToolStripMenuItem.Visible = True
			End If
			Dim flag47 As Boolean = (Operators.CompareString(Me.C24, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag47 Then
				Me.ReportsToolStripMenuItem1.Visible = False
			Else
				Me.ReportsToolStripMenuItem1.Visible = True
			End If
			Dim flag48 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag48 Then
				Me.ReportsToolStripMenuItem1.Visible = True
			End If
			Dim flag49 As Boolean = (Operators.CompareString(Me.C25, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag49 Then
				Me.GSTRToolStripMenuItem.Visible = False
			Else
				Me.GSTRToolStripMenuItem.Visible = True
			End If
			Dim flag50 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag50 Then
				Me.GSTRToolStripMenuItem.Visible = True
			End If
			Dim flag51 As Boolean = (Operators.CompareString(Me.C26, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag51 Then
				Me.ExportImportExcelToolStripMenuItem.Visible = False
			Else
				Me.ExportImportExcelToolStripMenuItem.Visible = True
			End If
			Dim flag52 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag52 Then
				Me.ExportImportExcelToolStripMenuItem.Visible = True
			End If
			Dim flag53 As Boolean = (Operators.CompareString(Me.C27, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag53 Then
				Me.ContraVoucherToolStripMenuItem.Visible = False
			Else
				Me.ContraVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag54 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag54 Then
				Me.ContraVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag55 As Boolean = (Operators.CompareString(Me.C28, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag55 Then
				Me.OfferValidationToolStripMenuItem.Visible = False
				Me.OfferMessangerToolStripMenuItem.Visible = False
				Me.PromotionalOfferBuyXAndGetYToolStripMenuItem.Visible = False
				Me.CustomerCouponManagementToolStripMenuItem.Visible = False
				Me.CustomerGiftOfferValidationToolStripMenuItem.Visible = False
				Me.ToolStripMenuItem29.Visible = False
			Else
				Me.OfferValidationToolStripMenuItem.Visible = True
				Me.OfferMessangerToolStripMenuItem.Visible = True
				Me.PromotionalOfferBuyXAndGetYToolStripMenuItem.Visible = True
				Me.CustomerCouponManagementToolStripMenuItem.Visible = True
				Me.CustomerGiftOfferValidationToolStripMenuItem.Visible = True
				Me.ToolStripMenuItem29.Visible = True
			End If
			Dim flag56 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag56 Then
				Me.OfferValidationToolStripMenuItem.Visible = True
				Me.OfferMessangerToolStripMenuItem.Visible = True
				Me.PromotionalOfferBuyXAndGetYToolStripMenuItem.Visible = True
				Me.CustomerCouponManagementToolStripMenuItem.Visible = True
				Me.CustomerGiftOfferValidationToolStripMenuItem.Visible = True
				Me.ToolStripMenuItem29.Visible = True
			End If
			Dim flag57 As Boolean = (Operators.CompareString(Me.C29, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag57 Then
				Me.LogoutToolStripMenuItem.Visible = False
			Else
				Me.LogoutToolStripMenuItem.Visible = True
			End If
			Dim flag58 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag58 Then
				Me.LogoutToolStripMenuItem.Visible = True
			End If
			Dim flag59 As Boolean = (Operators.CompareString(Me.C30, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag59 Then
				Me.CommunicationToolStripMenuItem.Visible = False
			Else
				Me.CommunicationToolStripMenuItem.Visible = True
			End If
			Dim flag60 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag60 Then
				Me.CommunicationToolStripMenuItem.Visible = True
			End If
			Dim flag61 As Boolean = (Operators.CompareString(Me.C31, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag61 Then
				Me.ChequePrintToolStripMenuItem.Visible = False
			Else
				Me.ChequePrintToolStripMenuItem.Visible = True
			End If
			Dim flag62 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag62 Then
				Me.ChequePrintToolStripMenuItem.Visible = True
			End If
			Dim flag63 As Boolean = (Operators.CompareString(Me.C32, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag63 Then
				Me.DashBoardToolStripMenuItem.Visible = True
				Me.TableLayoutPanel6.Visible = False
				Me.TableLayoutPanel1.Visible = False
				Me.TableLayoutPanel7.Visible = False
				Me.TableLayoutPanel8.Visible = False
				Me.Chart1.Visible = False
				Me.cmbChartType.Visible = False
			Else
				Me.DashBoardToolStripMenuItem.Visible = True
				Me.TableLayoutPanel6.Visible = True
				Me.TableLayoutPanel1.Visible = True
				Me.TableLayoutPanel7.Visible = True
				Me.TableLayoutPanel8.Visible = True
				Me.Chart1.Visible = True
				Me.cmbChartType.Visible = True
			End If
			Dim flag64 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag64 Then
				Me.DashBoardToolStripMenuItem.Visible = True
				Me.TableLayoutPanel6.Visible = True
				Me.TableLayoutPanel1.Visible = True
				Me.TableLayoutPanel7.Visible = True
				Me.TableLayoutPanel8.Visible = True
				Me.Chart1.Visible = True
				Me.cmbChartType.Visible = True
			End If
			Dim flag65 As Boolean = (Operators.CompareString(Me.C33, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag65 Then
			End If
			Dim flag66 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag66 Then
			End If
			Dim flag67 As Boolean = (Operators.CompareString(Me.C34, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag67 Then
				Me.LoyaltyCardIssueToolStripMenuItem.Visible = False
				Me.LoyaltyValidationToolStripMenuItem.Visible = False
				Me.LoyaltyCardToolStripMenuItem.Visible = False
			Else
				Me.LoyaltyCardIssueToolStripMenuItem.Visible = True
				Me.LoyaltyValidationToolStripMenuItem.Visible = True
				Me.LoyaltyCardToolStripMenuItem.Visible = True
			End If
			Dim flag68 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag68 Then
				Me.LoyaltyCardIssueToolStripMenuItem.Visible = True
				Me.LoyaltyValidationToolStripMenuItem.Visible = True
				Me.LoyaltyCardToolStripMenuItem.Visible = True
			End If
			Dim flag69 As Boolean = (Operators.CompareString(Me.C35, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag69 Then
				Me.ServicesToolStripMenuItem1.Visible = False
			Else
				Me.ServicesToolStripMenuItem1.Visible = True
			End If
			Dim flag70 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag70 Then
				Me.ServicesToolStripMenuItem1.Visible = True
			End If
			Dim flag71 As Boolean = (Operators.CompareString(Me.C37, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag71 Then
				Me.JournalVoucherToolStripMenuItem.Visible = False
			Else
				Me.JournalVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag72 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag72 Then
				Me.JournalVoucherToolStripMenuItem.Visible = True
			End If
			Dim flag73 As Boolean = (Operators.CompareString(Me.C38, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag73 Then
				Me.DamageProductManagementToolStripMenuItem.Visible = False
			Else
				Me.DamageProductManagementToolStripMenuItem.Visible = True
			End If
			Dim flag74 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag74 Then
				Me.DamageProductManagementToolStripMenuItem.Visible = True
			End If
			Dim flag75 As Boolean = (Operators.CompareString(Me.C39, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag75 Then
				Me.ContactToolStripMenuItem.Visible = False
			Else
				Me.ContactToolStripMenuItem.Visible = True
			End If
			Dim flag76 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag76 Then
				Me.ContactToolStripMenuItem.Visible = True
			End If
			Dim flag77 As Boolean = (Operators.CompareString(Me.C40, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag77 Then
				Me.CloudDataManagementToolStripMenuItem.Visible = False
			Else
				Me.CloudDataManagementToolStripMenuItem.Visible = True
			End If
			Dim flag78 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag78 Then
				Me.CloudDataManagementToolStripMenuItem.Visible = True
			End If
			Dim flag79 As Boolean = (Operators.CompareString(Me.C41, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag79 Then
				Me.ToolStripMenuItem14.Visible = False
			Else
				Me.ToolStripMenuItem14.Visible = True
			End If
			Dim flag80 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag80 Then
				Me.ToolStripMenuItem14.Visible = True
			End If
			Dim flag81 As Boolean = (Operators.CompareString(Me.C42, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag81 Then
				Me.RouteToolStripMenuItem.Visible = False
			Else
				Me.RouteToolStripMenuItem.Visible = True
			End If
			Dim flag82 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag82 Then
				Me.RouteToolStripMenuItem.Visible = True
			End If
			Dim flag83 As Boolean = (Operators.CompareString(Me.C43, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag83 Then
				Me.AutoBackupToolStripMenuItem.Visible = False
			Else
				Me.AutoBackupToolStripMenuItem.Visible = True
			End If
			Dim flag84 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag84 Then
				Me.AutoBackupToolStripMenuItem.Visible = True
			End If
			Dim flag85 As Boolean = (Operators.CompareString(Me.C46, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag85 Then
				Me.DBarcodeToolStripMenuItem.Visible = False
			Else
				Me.DBarcodeToolStripMenuItem.Visible = True
			End If
			Dim flag86 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag86 Then
				Me.DBarcodeToolStripMenuItem.Visible = True
			End If
			Dim flag87 As Boolean = (Operators.CompareString(Me.C47, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag87 Then
				Me.CipherBarcodeToolStripMenuItem.Visible = False
				Me.ToolStripMenuItem15.Visible = False
			End If
			Dim flag88 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag88 Then
			End If
			Dim flag89 As Boolean = (Operators.CompareString(Me.C48, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag89 Then
				Me.SaleInvoiceCodeToolStripMenuItem.Visible = False
			Else
				Me.SaleInvoiceCodeToolStripMenuItem.Visible = True
			End If
			Dim flag90 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag90 Then
				Me.SaleInvoiceCodeToolStripMenuItem.Visible = True
			End If
			Dim flag91 As Boolean = (Operators.CompareString(Me.C49, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag91 Then
				Me.TransporterToolStripMenuItem.Visible = False
			Else
				Me.TransporterToolStripMenuItem.Visible = True
			End If
			Dim flag92 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag92 Then
				Me.TransporterToolStripMenuItem.Visible = True
			End If
			Dim flag93 As Boolean = (Operators.CompareString(Me.C50, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag93 Then
				Me.WeighingMachineControlToolStripMenuItem.Visible = False
			Else
				Me.WeighingMachineControlToolStripMenuItem.Visible = True
			End If
			Dim flag94 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag94 Then
				Me.WeighingMachineControlToolStripMenuItem.Visible = True
			End If
			Dim flag95 As Boolean = (Operators.CompareString(Me.C51, "Disable", False) = 0) And (Operators.CompareString(Me.lblUserType.Text, "*****", False) <> 0)
			If flag95 Then
				Me.ToolStripMenuItem18.Visible = False
			Else
				Me.ToolStripMenuItem18.Visible = True
			End If
			Dim flag96 As Boolean = Operators.CompareString(Me.lblUserType.Text, "*****", False) = 0
			If flag96 Then
				Me.ToolStripMenuItem18.Visible = True
			End If
		End Sub

		' Token: 0x0600C8A8 RID: 51368 RVA: 0x007E7D0C File Offset: 0x007E5F0C
		Public Sub Backup()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
				saveFileDialog.FileName = text
				Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
					Me.Filename = saveFileDialog.FileName
					Me.Cursor = Cursors.WaitCursor
					Me.Timer2.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
					ModCommonClasses.con.Open()
					Dim text2 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					Dim text3 As String = "Sucessfully Performed the Backup"
					ModFunc.LogFunc(Me.lblUser.Text, text3)
					MessageBox.Show("Successfully Performed the Backup", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8A9 RID: 51369 RVA: 0x007E7EA0 File Offset: 0x007E60A0
		Public Sub autoBackup()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Me.Filename = "D:\SBPE_DATA\" + Me.stX + ".bak"
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					File.Delete(text)
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text2 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8AA RID: 51370 RVA: 0x007E7FD0 File Offset: 0x007E61D0
		Public Sub autocloudBackup()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\SBPE_DATA")
				If flag Then
					Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\SBPE_DATA\")
				End If
				Me.Filename = MyProject.Application.Info.DirectoryPath + "\SBPE_DATA\" + Me.stX + ".bak"
				Dim flag2 As Boolean = File.Exists(text)
				If flag2 Then
					File.Delete(text)
				End If
				Me.Cursor = Cursors.WaitCursor
				Me.Timer2.Enabled = True
				Dim directoryName As String = Path.GetDirectoryName(Me.Filename)
				Dim text2 As String = String.Format("icacls ""{0}"" /grant Users:(OI)(CI)RW", directoryName)
				Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
				processStartInfo.UseShellExecute = False
				processStartInfo.RedirectStandardOutput = True
				processStartInfo.RedirectStandardError = True
				processStartInfo.CreateNoWindow = True
				processStartInfo.Verb = "runas"
				processStartInfo.Arguments = "/C " + text2
				Dim process As Process = New Process()
				process.StartInfo = processStartInfo
				process.Start()
				process.WaitForExit()
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text3 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
				ModCommonClasses.cmd = New SqlCommand(text3)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				Dim text4 As String = "Sucessfully Performed the auto cloud Backup"
				ModFunc.LogFunc(Me.lblUser.Text, text4)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8AB RID: 51371 RVA: 0x007E8220 File Offset: 0x007E6420
		Public Sub cloud()
			Dim flag As Boolean = Operators.CompareString(Me.TextBox3.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) = 0
			If flag Then
				Me.Label7.Enabled = True
				Dim enabled As Boolean = Me.Label7.Enabled
				If enabled Then
					Me.autocloudBackup()
					Try
						Dim flag2 As Boolean = Not Directory.Exists("D:\SBPE_DATA")
						If flag2 Then
							Directory.CreateDirectory("D:\SBPE_DATA")
						End If
						Me.Cursor = Cursors.WaitCursor
						Me.Timer2.Enabled = True
						Dim flag3 As Boolean = Directory.Exists("D:\SBPE_DATA\")
						Dim flag4 As Boolean = flag3
						If flag4 Then
							Try
								Dim gddata As GDData = Me.gDClient.BackupData("D:\SBPE_DATA\")
								MessageBox.Show("Successfully auto cloud backed Up, File ID : " + gddata.Id)
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						Else
							MessageBox.Show("Directory not exists for cloud backup")
						End If
						For Each text As String In Directory.GetFiles("D:\SBPE_DATA\", "*.*", SearchOption.TopDirectoryOnly)
							File.Delete(text)
						Next
					Catch ex2 As Exception
					End Try
				Else
					MessageBox.Show("Please check your internet connection for cloud backup", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600C8AC RID: 51372 RVA: 0x00059937 File Offset: 0x00057B37
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600C8AD RID: 51373 RVA: 0x007E83B4 File Offset: 0x007E65B4
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.lblDateTime.Text = DateAndTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
			Me.Label51.Text = DateAndTime.Now.ToString("dd MMM yyyy, hh:mm:ss tt") + vbCrLf + DateAndTime.Now.ToString("dddd")
		End Sub

		' Token: 0x0600C8AE RID: 51374 RVA: 0x007E841C File Offset: 0x007E661C
		Public Async Sub LogOut()
			Dim st As String = "Successfully logged out"
			ModFunc.LogFunc(Me.lblUser.Text, st)
			Me.Hide()
			ProjectData.EndApp()
		End Sub

		' Token: 0x0600C8AF RID: 51375 RVA: 0x00059953 File Offset: 0x00057B53
		Private Sub frmMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs)
			MessageBox.Show("Please Logout the application", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			e.Cancel = True
		End Sub

		' Token: 0x0600C8B0 RID: 51376 RVA: 0x007E8458 File Offset: 0x007E6658
		Private Sub CompanyInfoToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCompanyupdate.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmCompanyupdate.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCompanyupdate.ShowDialog()
			MyProject.Forms.frmCompanyupdate.Dispose()
		End Sub

		' Token: 0x0600C8B1 RID: 51377 RVA: 0x007E8458 File Offset: 0x007E6658
		Public Sub frmCompanyupdate1()
			MyProject.Forms.frmCompanyupdate.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmCompanyupdate.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCompanyupdate.ShowDialog()
			MyProject.Forms.frmCompanyupdate.Dispose()
		End Sub

		' Token: 0x0600C8B2 RID: 51378 RVA: 0x007E84C8 File Offset: 0x007E66C8
		Private Sub CategoryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Reset()
			MyProject.Forms.frmCategory.ShowDialog()
			MyProject.Forms.frmCategory.Dispose()
		End Sub

		' Token: 0x0600C8B3 RID: 51379 RVA: 0x007E84C8 File Offset: 0x007E66C8
		Public Sub frmCategory1()
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Reset()
			MyProject.Forms.frmCategory.ShowDialog()
			MyProject.Forms.frmCategory.Dispose()
		End Sub

		' Token: 0x0600C8B4 RID: 51380 RVA: 0x007E8528 File Offset: 0x007E6728
		Private Sub SubCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Reset()
			MyProject.Forms.frmSubCategory.ShowDialog()
			MyProject.Forms.frmSubCategory.Dispose()
		End Sub

		' Token: 0x0600C8B5 RID: 51381 RVA: 0x007E8528 File Offset: 0x007E6728
		Public Sub frmSubCategory1()
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Reset()
			MyProject.Forms.frmSubCategory.ShowDialog()
			MyProject.Forms.frmSubCategory.Dispose()
		End Sub

		' Token: 0x0600C8B6 RID: 51382 RVA: 0x007E8588 File Offset: 0x007E6788
		Private Function HandleRegistry() As Boolean
			Dim dateTime As DateTime = Conversions.ToDate(MyProject.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventoryGST12x", "Set", Nothing))
			Dim dateTime2 As DateTime = dateTime
			Dim flag As Boolean = DateTime.Compare(dateTime2, DateTime.MinValue) = 0
			If flag Then
				dateTime2 = DateTime.Today.[Date]
				MyProject.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventoryGST12x", "Set", dateTime2)
			Else
				Dim flag2 As Boolean = (DateAndTime.Now - dateTime2).Days > 7
				If flag2 Then
					Return False
				End If
			End If
			Return True
		End Function

		' Token: 0x0600C8B7 RID: 51383 RVA: 0x007E8624 File Offset: 0x007E6824
		Private Sub CashinhandBalance()
			Try
				Me.Label49.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from LedgerBook where Date between @d2 and @d3 and Name=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Cash Account")
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					If flag3 Then
						Me.Label49.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label49.Text = String.Concat(New String() { "Cash-in-Hand : ", Me.CurSym, " ", Strings.Format(Math.Round(Conversion.Val(Me.Label49.Text), 2), "0.00"), vbCrLf & "( FY : ", Conversions.ToString(Me.DTP1.Value.[Date]), " To ", Conversions.ToString(Me.DTP2.Value.[Date]), " )" })
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C8B8 RID: 51384 RVA: 0x007E8860 File Offset: 0x007E6A60
		Private Sub todaysale()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label13.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.bx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label13.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label13.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8B9 RID: 51385 RVA: 0x007E89C4 File Offset: 0x007E6BC4
		Private Sub todaypurchase()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal)-Sum(PreviousDue),0) from Stock where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label15.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.cx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label15.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BA RID: 51386 RVA: 0x007E8B28 File Offset: 0x007E6D28
		Private Sub todayreceipt()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Amount),0) from Payment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label27.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.ix = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label27.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label27.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BB RID: 51387 RVA: 0x007E8C8C File Offset: 0x007E6E8C
		Private Sub todaypayment()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Amount),0) from CreditCustomerPayment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label21.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.dx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label21.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label21.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BC RID: 51388 RVA: 0x007E8DF0 File Offset: 0x007E6FF0
		Private Sub todayexpenses()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from Voucher where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label30.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.fx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label30.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label30.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BD RID: 51389 RVA: 0x007E8F54 File Offset: 0x007E7154
		Private Sub todayincome()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from Income where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label11.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.ax = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label11.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label11.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BE RID: 51390 RVA: 0x007E90B8 File Offset: 0x007E72B8
		Private Sub todaysalereturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from SalesReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label29.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.gx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label29.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label29.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8BF RID: 51391 RVA: 0x007E921C File Offset: 0x007E741C
		Private Sub todaypurchasereturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from PurchaseReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label28.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.hx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label28.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label28.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8C0 RID: 51392 RVA: 0x007E9380 File Offset: 0x007E7580
		Private Sub todayservice()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo1 where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label32.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.ex = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label32.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label32.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8C1 RID: 51393 RVA: 0x007E94E4 File Offset: 0x007E76E4
		Private Sub todayserviceadvance()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(AdvanceDeposit),0) from Service where Day(ServiceCreationDate)=Day(GetDate()) and Month(ServiceCreationDate)=Month(GetDate()) and Year(ServiceCreationDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label33.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.jx = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))), 2), "0.00"))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.Label33.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.Label33.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8C2 RID: 51394 RVA: 0x00059971 File Offset: 0x00057B71
		Private Sub cmbChartType_SelectedIndexChanged(sender As Object, e As EventArgs)
			If AppleUITheme.IsCapturing Then Return
			Me.Chart1.Series("Transaction").ChartType = CType(Conversions.ToInteger(Me.cmbChartType.SelectedItem), SeriesChartType)
		End Sub

		' Token: 0x0600C8C3 RID: 51395 RVA: 0x007E9648 File Offset: 0x007E7848
		Public Function Base64ToImage(base64string As String) As Image
			If String.IsNullOrWhiteSpace(base64string) Then
				Return Nothing
			End If
			Try
				Dim text As String = base64string.Trim().Replace(" ", "+")
				Dim commaIndex As Integer = text.IndexOf(","c)
				If commaIndex >= 0 Then
					text = text.Substring(commaIndex + 1)
				End If
				Dim array As Byte() = Convert.FromBase64String(text)
				If array Is Nothing OrElse array.Length = 0 Then
					Return Nothing
				End If
				Using memoryStream As MemoryStream = New MemoryStream(array)
					Using rawImg As Image = Image.FromStream(memoryStream)
						Return New Bitmap(rawImg)
					End Using
				End Using
			Catch ex As Exception
				Return Nothing
			End Try
		End Function

		' Token: 0x0600C8C4 RID: 51396 RVA: 0x000EE848 File Offset: 0x000ECA48
		Public Sub CheckAllResourceImages()
			Dim list As List(Of String) = New List(Of String)()
			Dim resourceSet As ResourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
			For Each obj As Object In resourceSet
				Dim dictionaryEntry As DictionaryEntry = If((obj IsNot Nothing), CType(obj, DictionaryEntry), Nothing)
				Dim text As String = dictionaryEntry.Key.ToString()
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dictionaryEntry.Value)
				Dim flag As Boolean = TypeOf objectValue Is Bitmap OrElse TypeOf objectValue Is Image
				If flag Then
					Try
						Using CType(objectValue, Image)
						End Using
					Catch ex As Exception
						list.Add(text)
					End Try
				End If
			Next
			Dim flag2 As Boolean = list.Count > 0
			If flag2 Then
				MessageBox.Show("Corrupt Images Found: " + String.Join(", ", list))
			Else
				MessageBox.Show("All images are valid.")
			End If
		End Sub

		' Token: 0x0600C8C5 RID: 51397 RVA: 0x007E968C File Offset: 0x007E788C
		Private Async Sub frmMainMenu_Load(sender As Object, e As EventArgs)
			If AppleUITheme.IsCapturing Then
				Me.BackColor = AppleUITheme.CanvasBg
				Return
			End If
			Me.FillCategory()
			Me.HomeButtonControl()
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
			If flag Then
				Me.Button20.Visible = True
			Else
				Me.Button20.Visible = False
			End If
			Me.Timer3.Interval = 5000
			Me.Timer3.Start()
			Dim licdata As frmSplash.LicenseDataNew = MyProject.Forms.frmSplash.getRegistrydata()
			If licdata IsNot Nothing Then
				If Not String.IsNullOrEmpty(licdata.company) Then
					Me.ToolStripStatusLabel1.Text = licdata.company
				End If
				If Not String.IsNullOrEmpty(licdata.phone) Then
					Me.ToolStripStatusLabel6.Text = "+91" + licdata.phone
				End If
				If Not String.IsNullOrEmpty(licdata.email) Then
					Me.ToolStripStatusLabel5.Text = licdata.email
				End If
				If Not String.IsNullOrWhiteSpace(licdata.MainLogo) Then
					Dim logoImg As Image = Me.Base64ToImage(licdata.MainLogo)
					If logoImg IsNot Nothing Then
						Me.Panel6.BackgroundImage = logoImg
					End If
				End If
			End If
			frmMainMenu.MyRender.highlightbackcolor = AppleUITheme.PrimaryBlue
			frmMainMenu.MyRender.highlightforecolor = Color.White
			frmMainMenu.MyRender.nonhighlightbackcolor = AppleUITheme.CardBg
			frmMainMenu.MyRender.nonhighlightforecolor = AppleUITheme.TextPrimary
			frmMainMenu.MyRender.menufont = AppleUITheme.FontSemiBold(10.5F)
			Me.MenuStrip2.Renderer = New frmMainMenu.MyRender()
			Me.BackColor = AppleUITheme.CanvasBg
			Me.CompanyInfoDisplay()
			Me.UserControlSettings()
			Me.UserControlValidation()
			Dim flag2 As Boolean = Operators.CompareString(Me.AID, "Enabled", False) = 0
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Me.C36, "Disable", False) = 0
				If flag3 Then
					Dim flag4 As Boolean = Me.android_service IsNot Nothing
					If flag4 Then
						Me.android_service.StopService()
					End If
				Else
					Dim AY As String() = File.ReadAllLines(Application.StartupPath + "\Ext")
					Dim N_URL As String = AY(0)
					Dim N_SEC As String = AY(1)
					Me.android_service.basePathFB = N_URL
					Me.android_service.authSecretFB = N_SEC
					Dim mosFB As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
					Try
						For Each managementBaseObject As ManagementBaseObject In mosFB.[Get]()
							Dim moFB As ManagementObject = CType(managementBaseObject, ManagementObject)
							Dim serialFB As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(moFB("SerialNumber")))
							Me.android_service.companyid = ModFunc.MD5Encrypt(Me.txtDB.Text.ToString().Trim() + Strings.StrReverse(serialFB))
						Next
					Finally
						Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
						If enumerator IsNot Nothing Then
							CType(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.android_service.usernameFB = Me.lblUser.Text
					Me.android_service.dbnameFB = Me.txtDB.Text
					Me.android_service.TBoxCompName = Me.Label43.Text
					Me.android_service.TBoxAddress = Me.Label44.Text.Replace("Address : ", "")
					Me.android_service.TBoxState = Me.Label48.Text.Replace("State : ", "")
					Me.android_service.TBoxGSTIN = Me.Label47.Text.Replace("GSTIN : ", "")
					Me.android_service.TBoxContactNo = Me.Label45.Text.Replace("Contact : ", "")
					Me.android_service.TBoxEmail = Me.Label46.Text.Replace("Email : ", "")
					Me.android_service.DTP1 = Me.DTP1.Value
					Me.android_service.DTP2 = Me.DTP2.Value
					Me.android_service.StartService()
					Me.android_service.StartServiceStockUpdate()
				End If
			Else
				Dim flag5 As Boolean = Me.android_service IsNot Nothing
				If flag5 Then
					Me.android_service.StopService()
				End If
			End If
			Me.logo()
			Me.CashinhandBalance()
			Me.Autobackupstatusdisplay()
			Me.GetCustomerDisplayPort()
			Me.Chartclear()
			Me.Chart()
			Me.emailstatuscheck()
			Me.smsstatuscheck()
			Me.ReminderCount()
			Me.wappnodisplay()
			Try
				Dim licenseResponse As LicenseResponse = Global.DevNetLM.DevNet.Validate()
				Dim licenseData As LicenseData = licenseResponse.LicenseData
				Me.DateTimePicker1.Value = DateAndTime.Today
				Dim Result As TimeSpan = Nothing
				Me.fdt = licenseData.VTill
				Dim sdt As DateTime = DateAndTime.Today
				Result = Me.fdt - sdt
				Me.countdays = Conversions.ToInteger(Result.TotalDays.ToString())
				Me.lblCName.Text = licenseData.CusPhone.ToString()
				Me.regdto = licenseData.CusName.ToString()
				Dim flag6 As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) <> 0
				If flag6 Then
					Me.Text = String.Concat(New String() { "|", Me.ToolStripStatusLabel1.Text, " |  Rel ", MyProject.Application.Info.Version.ToString().Substring(0, 3), "  |  Enterprise Edition  |  Multiuser Mode  |  Valid Upto : ", Strings.Format(licenseData.VTill, "dd-MM-yyyy"), "  |  ", Me.Label43.Text.TrimEnd(New Char(-1) {}), "  |  FY : ", Me.fy1, "  -  ", Me.fy2, "  |" })
				Else
					Me.Text = String.Concat(New String() { "|", Me.ToolStripStatusLabel1.Text, " |  Rel ", MyProject.Application.Info.Version.ToString().Substring(0, 3), "  |  Trial Copy (Limitation Applied)  |  Valid Upto : ", Strings.Format(licenseData.VTill, "dd-MM-yyyy"), "  |  ", Me.Label43.Text.TrimEnd(New Char(-1) {}), "  |  FY : ", Me.fy1, "  -  ", Me.fy2, "  |" })
				End If
				Dim flag7 As Boolean = (Me.countdays >= 1) And (Me.countdays <= 7)
				If flag7 Then
					MessageBox.Show("Your license key is expiring after " + Me.countdays.ToString().Substring(0, 1) + " days, Please renew the license before expiry, Thank You.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Please restart the application", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				ProjectData.EndApp()
			End Try
			Dim flag8 As Boolean = Operators.CompareString(Me.TextBox2.Text, "Enabled", False) = 0
			If flag8 Then
				Me.Label3.Enabled = True
			Else
				Me.Label3.Enabled = False
			End If
			Dim flag9 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
			If flag9 Then
				Me.ToolStripMenuItem12.Visible = True
				Me.Button3.Enabled = True
				Me.UserPermissionSettingsToolStripMenuItem.Visible = True
			End If
			Dim flag10 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0
			If flag10 Then
				Me.Button3.Enabled = True
				Me.ToolStripMenuItem12.Visible = False
				Me.UserRegistrationToolStripMenuItem.Visible = False
				Me.UserPermissionSettingsToolStripMenuItem.Visible = True
			End If
			Dim flag11 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
			If flag11 Then
				Me.ToolStripMenuItem12.Visible = False
				Me.Button3.Enabled = False
				Me.UserPermissionSettingsToolStripMenuItem.Visible = False
			End If
			Dim flag12 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Inventory Manager", False) = 0
			If flag12 Then
				Me.ToolStripMenuItem12.Visible = False
				Me.Button3.Enabled = False
				Me.UserPermissionSettingsToolStripMenuItem.Visible = False
			End If
			frmMainMenu.whatsApp = New WhatsApp()
			Dim flag13 As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) = 0
			If flag13 Then
				Dim flag14 As Boolean = ModFunc.CheckForInternetConnection()
				If flag14 Then
					Me.ReadInstanceFile()
				Else
					Me.LblEngine.Text = "Internet not connected"
				End If
			Else
				Me.LblEngine.Text = "sts2 is not enable"
			End If
			Try
				Dim flag15 As Boolean = Directory.Exists(MyProject.Application.Info.DirectoryPath + "\WhatsApp")
				If flag15 Then
					Dim directoryName2 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
					For Each deleteFile2 As String In Directory.GetFiles(directoryName2, "*.*", SearchOption.TopDirectoryOnly)
						File.Delete(deleteFile2)
					Next
				End If
				Dim flag16 As Boolean = Directory.Exists(MyProject.Application.Info.DirectoryPath + "\GDrive Reports")
				If flag16 Then
					Dim directoryName3 As String = MyProject.Application.Info.DirectoryPath + "\GDrive Reports"
					For Each deleteFile3 As String In Directory.GetFiles(directoryName3, "*.*", SearchOption.TopDirectoryOnly)
						File.Delete(deleteFile3)
					Next
				End If
			Catch ex2 As Exception
			End Try
			frmMainMenu.whatsApp1 = New WhatsApp()
			Await Task.Run(Sub()
				Me.CleanupFiles()
			End Sub)
			If Operators.CompareString(Me.sts2, "Enabled", False) = 0 Then
				Await Task.Run(Sub()
					Me.InitializeWhatsApp()
				End Sub)
			End If
			If Operators.CompareString(Me.AID, "Enabled", False) = 0 Then
				Me.Panel5.Controls.Clear()
				Dim frmDash As New Form()

			frmDash.Size = Me.Panel5.Size

			frmDash.TopLevel = False

			frmDash.Parent = Me.Panel5

			frmDash.lblUser.Text = Me.lblUser.Text

			frmDash.txtDB.Text = Me.txtDB.Text

			frmDash.Show()
			Else
				Me.Panel5.Controls.Clear()
				Dim frmDashClose As New Form() With { .Size = Me.Panel5.Size, .TopLevel = False, .Parent = Me.Panel1 } : frmDashClose.Close()
				MyProject.Forms.Form.Close()
			End If
			Try
			Catch ex3 As Exception
			End Try
			Try
			Catch ex4 As Exception
			End Try
			Try
				If Operators.CompareString(Me.custsecdisplay, "Yes", False) = 0 Then
					Dim screen As Screen = Screen.AllScreens(1)
					MyProject.Forms.frmScrDsply.StartPosition = FormStartPosition.Manual
					MyProject.Forms.frmScrDsply.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
					MyProject.Forms.frmScrDsply.Show()
				End If
			Catch ex5 As Exception
			End Try
			Me.Convert_Language()
			If ModFunc.CheckForInternetConnection() Then
				Await Me.Company_dtl()
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT is_db_enable FROM RaintechMaster WHERE Online_DBName=@d1 and is_active=1 ", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.Online_DBName)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					If ModCommonClasses.rdr.Read() Then
						Dim isDbEnable As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("is_db_enable")))
						ModCommonClasses.rdr.Close()
						ModCommonClasses.con.Close()
					End If
					Me.Recover_MigrationLogs_failed_System()
					Me.migrationTimer = New Global.System.Windows.Forms.Timer()
					Me.migrationTimer.Interval = 60000
					AddHandler Me.migrationTimer.Tick, AddressOf Me.CheckAndRunMigration
					Me.migrationTimer.Start()
				Catch ex6 As Exception
				End Try
			End If
		End Sub

		' Token: 0x0600C8C6 RID: 51398 RVA: 0x007E96D4 File Offset: 0x007E78D4
		Private Sub CleanupFiles()
			Try
				Dim text As String = Path.Combine(MyProject.Application.Info.DirectoryPath, "WhatsApp")
				Dim flag As Boolean = Directory.Exists(text)
				If flag Then
					For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
						File.Delete(text2)
					Next
				End If
				Dim text3 As String = Path.Combine(MyProject.Application.Info.DirectoryPath, "GDrive Reports")
				Dim flag2 As Boolean = Directory.Exists(text3)
				If flag2 Then
					For Each text4 As String In Directory.GetFiles(text3, "*.*", SearchOption.TopDirectoryOnly)
						File.Delete(text4)
					Next
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C8C7 RID: 51399 RVA: 0x007E97C0 File Offset: 0x007E79C0
		Private Async Function Company_dtl() As Task
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.strdb_name = array(0)
				Using con As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					con.Open()
					Dim cmdText As String = "SELECT CompanyName,DBName,Online_DBName FROM RaintechMaster WHERE DBName=@d1"
					Using cmd As SqlCommand = New SqlCommand(cmdText, con)
						cmd.Parameters.AddWithValue("@d1", Me.strdb_name)
						Using reader As SqlDataReader = cmd.ExecuteReader()
							Dim hasRows As Boolean = reader.HasRows
							If hasRows Then
								While reader.Read()
									Me.Online_DBName = reader("Online_DBName").ToString()
									Me.Local_DBName = reader("DBName").ToString()
									Me.getCompanydtl_cmpid(Me.Local_DBName)
								End While
							End If
						End Using
					End Using
				End Using
			Catch ex2 As Exception
				Dim ex As Exception = ex2
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Function

		' Token: 0x0600C8C8 RID: 51400 RVA: 0x007E9804 File Offset: 0x007E7A04
		Public Sub getCompanydtl_cmpid(strLocalDb As String)
			Me.strCompany_id = ""
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.strCompany_id = ModFunc.MD5Encrypt(strLocalDb.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			End Try
		End Sub

		' Token: 0x0600C8C9 RID: 51401 RVA: 0x007E98DC File Offset: 0x007E7ADC
		Public Sub Recover_MigrationLogs_failed_System()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim num As Integer = -1
					Using sqlCommand As SqlCommand = New SqlCommand("SELECT TOP 1 Id FROM DataMigration_Logs WHERE Status = 'Started' AND EndTime IS NULL", sqlConnection)
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
						Dim flag As Boolean = objectValue IsNot Nothing AndAlso Not Convert.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue))
						If flag Then
							num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue))
						End If
					End Using
					Dim flag2 As Boolean = num > 0
					If flag2 Then
						Using sqlCommand2 As SqlCommand = New SqlCommand(vbCrLf & "                    UPDATE DataMigration_Logs " & vbCrLf & "                    SET EndTime = @end, " & vbCrLf & "                        Status = 'Failed', " & vbCrLf & "                        ErrorMessage = 'Auto-recovered due to system shutdown or crash' " & vbCrLf & "                    WHERE Id = @id", sqlConnection)
							sqlCommand2.Parameters.AddWithValue("@end", DateTime.Now)
							sqlCommand2.Parameters.AddWithValue("@id", num)
							sqlCommand2.ExecuteNonQuery()
						End Using
					End If
				End Using
			Catch ex As Exception
				Console.WriteLine("Error during failed migration log recovery: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600C8CA RID: 51402 RVA: 0x007E9A24 File Offset: 0x007E7C24
		Public Sub AutoMigration_ControlStatus()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT IsEnabled FROM AutoMigrationControl WHERE ID = 1", sqlConnection)
					Me.AutoMigration_Status = Conversions.ToBoolean(sqlCommand.ExecuteScalar())
					sqlConnection.Close()
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading auto-migration status: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600C8CB RID: 51403 RVA: 0x007E9ABC File Offset: 0x007E7CBC
		Private Sub CheckAndRunMigration(sender As Object, e As EventArgs)
			Me.AutoMigration_ControlStatus()
			Dim flag As Boolean = Not Me.AutoMigration_Status
			If Not flag Then
				Dim flag2 As Boolean = Me.isMigrationRunning
				If Not flag2 Then
					Task.Run(Sub()
						Try
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "                             SELECT COUNT(*) FROM DataMigration_Logs " & vbCrLf & "                             WHERE Status = 'Started' AND EndTime IS NULL", sqlConnection)
								Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
								Dim flag3 As Boolean = num > 0
								If Not flag3 Then
									Dim sqlCommand2 As SqlCommand = New SqlCommand(vbCrLf & "                             SELECT MAX(EndTime) " & vbCrLf & "                             FROM DataMigration_Logs " & vbCrLf & "                             WHERE Status = 'Completed'", sqlConnection)
									Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())
									Dim flag4 As Boolean = False
									Dim flag5 As Boolean = objectValue IsNot DBNull.Value AndAlso objectValue IsNot Nothing
									If flag5 Then
										Dim dateTime As DateTime = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objectValue))
										Dim flag6 As Boolean = DateTime.Compare(DateTime.Now, dateTime.AddMinutes(15.0)) >= 0
										If flag6 Then
											flag4 = True
										End If
									Else
										flag4 = True
									End If
									Dim flag7 As Boolean = flag4
									If flag7 Then
										Me.isMigrationRunning = True
										Me.RunMigrationSilently("auto")
										Me.isMigrationRunning = False
									End If
								End If
							End Using
						Catch ex As Exception
							Me.isMigrationRunning = False
						End Try
					End Sub)
				End If
			End If
		End Sub

		' Token: 0x0600C8CC RID: 51404 RVA: 0x007E9B00 File Offset: 0x007E7D00
		Private Sub RunMigrationSilently(triggerType As String)
			ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
			ModCommonClasses.con.Open()
			Dim text As String = "select is_db_enable from RaintechMaster where Online_DBName=@d1 and is_active=1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.Online_DBName)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("is_db_enable")))
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Else
				ModCommonClasses.con.Close()
				Dim text2 As String = Me.helper.UpdateConnectionStringFromGrid(Me.Online_DBName)
				Try
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						Using sqlConnection2 As SqlConnection = New SqlConnection(text2)
							sqlConnection.Open()
							sqlConnection2.Open()
							Dim num As Integer = -1
							Dim now As DateTime = DateTime.Now
							Using sqlCommand As SqlCommand = New SqlCommand("INSERT INTO DataMigration_Logs (StartTime, Status, TriggerType) OUTPUT INSERTED.Id VALUES (@d1, 'Started', @d2)", sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", now)
								sqlCommand.Parameters.AddWithValue("@d2", triggerType)
								num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
							End Using
							Dim tableMigrationOrder As List(Of String) = frmMainMenu.GetTableMigrationOrder(sqlConnection)
							Try
								For Each text3 As String In tableMigrationOrder
									Me.MigratePendingRows(text3, New Dictionary(Of String, String)(), sqlConnection, sqlConnection2)
								Next
							Finally
								Dim enumerator As List(Of String).Enumerator
								CType(enumerator, IDisposable).Dispose()
							End Try
							Using sqlCommand2 As SqlCommand = New SqlCommand("UPDATE DataMigration_Logs SET EndTime = @end, Status = 'Completed' WHERE Id = @id", sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@end", DateTime.Now)
								sqlCommand2.Parameters.AddWithValue("@id", num)
								sqlCommand2.ExecuteNonQuery()
							End Using
							sqlConnection.Close()
							sqlConnection2.Close()
						End Using
					End Using
				Catch ex As Exception
					Try
						Using sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection3.Open()
							Dim sqlCommand3 As SqlCommand = New SqlCommand("SELECT TOP 1 Id FROM DataMigration_Logs WHERE Status = 'Started' AND TriggerType = @trigger ORDER BY StartTime DESC", sqlConnection3)
							sqlCommand3.Parameters.AddWithValue("@trigger", triggerType)
							Dim num2 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand3.ExecuteScalar()))
							Dim sqlCommand4 As SqlCommand = New SqlCommand("UPDATE DataMigration_Logs SET EndTime = @end, Status = 'Failed', ErrorMessage = @msg WHERE Id = @id", sqlConnection3)
							sqlCommand4.Parameters.AddWithValue("@end", DateTime.Now)
							sqlCommand4.Parameters.AddWithValue("@msg", ex.Message)
							sqlCommand4.Parameters.AddWithValue("@id", num2)
							sqlCommand4.ExecuteNonQuery()
							sqlConnection3.Close()
						End Using
					Catch ex2 As Exception
					End Try
				Finally
					Me.isMigrationRunning = False
				End Try
			End If
		End Sub

		' Token: 0x0600C8CD RID: 51405 RVA: 0x007E9F10 File Offset: 0x007E8110
				Public Shared Function GetTableMigrationOrder(con As SqlConnection) As List(Of String)
			Dim dependencies As New Dictionary(Of String, List(Of String))()
			Dim allTables As New HashSet(Of String)()
			Dim sqlCommand As New SqlCommand("SELECT fk.name AS FK_Name, tp.name AS ParentTable, tr.name AS ChildTable FROM sys.foreign_keys fk INNER JOIN sys.tables tp ON fk.referenced_object_id = tp.object_id INNER JOIN sys.tables tr ON fk.parent_object_id = tr.object_id", con)
			Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					Dim parentTable As String = sqlDataReader("ParentTable").ToString()
					Dim childTable As String = sqlDataReader("ChildTable").ToString()
					If Not dependencies.ContainsKey(childTable) Then
						dependencies(childTable) = New List(Of String)()
					End If
					dependencies(childTable).Add(parentTable)
					allTables.Add(parentTable)
					allTables.Add(childTable)
				End While
			End Using
			Dim sqlCommand2 As New SqlCommand("SELECT name FROM sys.tables", con)
			Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					allTables.Add(sqlDataReader2("name").ToString())
				End While
			End Using
			Dim visited As New HashSet(Of String)()
			Dim result As New List(Of String)()
			Dim visitAction As Action(Of String) = Nothing
			visitAction = Sub(t As String)
				If Not visited.Contains(t) Then
					visited.Add(t)
					If dependencies.ContainsKey(t) Then
						For Each dep As String In dependencies(t)
							visitAction(dep)
						Next
					End If
					result.Add(t)
				End If
			End Sub
			For Each table As String In allTables
				visitAction(table)
			Next
			Return result.Distinct().ToList()
		End Function

		' Token: 0x0600C8CE RID: 51406 RVA: 0x000D8784 File Offset: 0x000D6984
		Private Function GetSqlDbTypeFromType(type As Type) As SqlDbType
			Dim flag As Boolean = type Is GetType(Integer)
			Dim sqlDbType As SqlDbType
			If flag Then
				sqlDbType = SqlDbType.Int
			Else
				Dim flag2 As Boolean = type Is GetType(String)
				If flag2 Then
					sqlDbType = SqlDbType.NVarChar
				Else
					Dim flag3 As Boolean = type Is GetType(DateTime)
					If flag3 Then
						sqlDbType = SqlDbType.DateTime
					Else
						Dim flag4 As Boolean = type Is GetType(Boolean)
						If flag4 Then
							sqlDbType = SqlDbType.Bit
						Else
							Dim flag5 As Boolean = type Is GetType(Decimal)
							If flag5 Then
								sqlDbType = SqlDbType.[Decimal]
							Else
								Dim flag6 As Boolean = type Is GetType(Double)
								If flag6 Then
									sqlDbType = SqlDbType.Float
								Else
									Dim flag7 As Boolean = type Is GetType(Byte())
									If flag7 Then
										sqlDbType = SqlDbType.Image
									Else
										Dim flag8 As Boolean = type Is GetType(Guid)
										If flag8 Then
											sqlDbType = SqlDbType.UniqueIdentifier
										Else
											Dim flag9 As Boolean = type Is GetType(Long)
											If flag9 Then
												sqlDbType = SqlDbType.BigInt
											Else
												Dim flag10 As Boolean = type Is GetType(Short)
												If flag10 Then
													sqlDbType = SqlDbType.SmallInt
												Else
													sqlDbType = SqlDbType.[Variant]
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
			Return sqlDbType
		End Function

		' Token: 0x0600C8CF RID: 51407 RVA: 0x007EA0E0 File Offset: 0x007E82E0
		Private Sub MigratePendingRows(tableName As String, tableKeys As Dictionary(Of String, String), localCon As SqlConnection, remoteCon As SqlConnection)
			' The following expression was wrapped in a checked-statement
			Try
				Dim dictionary As Dictionary(Of String, Type) = New Dictionary(Of String, Type)()
				Dim hashSet As HashSet(Of String) = New HashSet(Of String)()
				Using sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT TOP 0 * FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly)
						Dim schemaTable As DataTable = sqlDataReader.GetSchemaTable()
						Try
							For Each obj As Object In schemaTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("ColumnName").ToString()
								dictionary(text) = CType(dataRow("DataType"), Type)
								Dim flag As Boolean = schemaTable.Columns.Contains("IsIdentity") AndAlso Conversions.ToBoolean(dataRow("IsIdentity"))
								If flag Then
									hashSet.Add(text)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
				Dim dictionary2 As Dictionary(Of String, String) = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
				Dim hashSet2 As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
				Using sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT SyncGuid, Version FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
						While sqlDataReader2.Read()
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlDataReader2("Version"))
							Dim flag2 As Boolean = TypeOf objectValue Is Byte()
							Dim text2 As String
							If flag2 Then
								text2 = BitConverter.ToString(CType(objectValue, Byte())).Replace("-", "")
							Else
								text2 = objectValue.ToString()
							End If
							Dim text3 As String = sqlDataReader2("SyncGuid").ToString()
							dictionary2(text3) = text2
							hashSet2.Add(text3)
						End While
					End Using
				End Using
				Dim hashSet3 As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
				Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("SELECT * FROM [{0}] WHERE ISNULL(is_remote, 0) IN (0, 1)", tableName), localCon)
				Dim sqlDataReader3 As SqlDataReader = sqlCommand3.ExecuteReader()
				While sqlDataReader3.Read()
					Dim flag3 As Boolean = (Operators.CompareString(tableName, "EmailCache", False) <> 0) And (Operators.CompareString(tableName, "Language_set", False) <> 0) And (Operators.CompareString(tableName, "DataMigration_Logs", False) <> 0) And (Operators.CompareString(tableName, "AutoMigrationControl", False) <> 0)
					If flag3 Then
						Dim text4 As String = sqlDataReader3("SyncGuid").ToString()
						hashSet3.Add(text4)
						Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote"))) AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote")))
						Dim array As Byte() = CType(sqlDataReader3("Version"), Byte())
						Dim text5 As String = BitConverter.ToString(array).Replace("-", "")
						Dim flag5 As Boolean = False
						Dim flag6 As Boolean = False
						Dim flag7 As Boolean = Not flag4
						If flag7 Then
							flag5 = True
						Else
							Dim flag8 As Boolean = dictionary2.ContainsKey(text4)
							If flag8 Then
								Dim text6 As String = dictionary2(text4)
								Dim flag9 As Boolean = Not String.Equals(text5, text6, StringComparison.OrdinalIgnoreCase)
								If flag9 Then
									flag6 = True
								End If
							End If
						End If
						Dim flag10 As Boolean = Not flag5 AndAlso Not flag6
						If Not flag10 Then
							Dim cols As New List(Of String)()
							Dim list As List(Of String) = New List(Of String)()
							Dim list2 As List(Of SqlParameter) = New List(Of SqlParameter)()
							Dim list3 As List(Of String) = New List(Of String)()
							Dim num As Integer = sqlDataReader3.FieldCount - 1
							For i As Integer = 0 To num
								Dim name As String = sqlDataReader3.GetName(i)
								Dim flag11 As Boolean = Operators.CompareString(name.ToLower(), "is_remote", False) <> 0
								If flag11 Then
									cols.Add("[" + name + "]")
									list.Add("@" + name)
									list3.Add("[" + name + "] = @upd_" + name)
									Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(sqlDataReader3(name))
									Dim sqlParameter As SqlParameter = New SqlParameter("@" + name, DBNull.Value)
									Dim sqlParameter2 As SqlParameter = New SqlParameter("@upd_" + name, DBNull.Value)
									Dim flag12 As Boolean = objectValue2 IsNot Nothing AndAlso objectValue2 IsNot DBNull.Value
									If flag12 Then
										Dim flag13 As Boolean = dictionary.ContainsKey(name)
										If flag13 Then
											Dim type As Type = dictionary(name)
											Try
												Dim flag14 As Boolean = Operators.CompareString(name, "Version", False) = 0 AndAlso type Is GetType(String) AndAlso TypeOf objectValue2 Is Byte()
												If flag14 Then
													Dim array2 As Byte() = CType(objectValue2, Byte())
													sqlParameter.Value = BitConverter.ToString(array2).Replace("-", "")
													sqlParameter.SqlDbType = SqlDbType.NVarChar
													sqlParameter2.Value = RuntimeHelpers.GetObjectValue(sqlParameter.Value)
													sqlParameter2.SqlDbType = sqlParameter.SqlDbType
												Else
													Dim type2 As Type = type
													Dim flag15 As Boolean = type2 Is GetType(Decimal)
													If flag15 Then
														sqlParameter.Value = Convert.ToDecimal(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
														sqlParameter.SqlDbType = SqlDbType.[Decimal]
													Else
														flag15 = type2 Is GetType(Double)
														If flag15 Then
															sqlParameter.Value = Convert.ToDouble(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
															sqlParameter.SqlDbType = SqlDbType.Float
														Else
															flag15 = type2 Is GetType(Single)
															If flag15 Then
																sqlParameter.Value = Convert.ToSingle(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
																sqlParameter.SqlDbType = SqlDbType.Real
															Else
																flag15 = type2 Is GetType(Integer)
																If flag15 Then
																	sqlParameter.Value = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue2))
																	sqlParameter.SqlDbType = SqlDbType.Int
																Else
																	flag15 = type2 Is GetType(Long)
																	If flag15 Then
																		sqlParameter.Value = Convert.ToInt64(RuntimeHelpers.GetObjectValue(objectValue2))
																		sqlParameter.SqlDbType = SqlDbType.BigInt
																	Else
																		flag15 = type2 Is GetType(DateTime)
																		If flag15 Then
																			sqlParameter.Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objectValue2))
																			sqlParameter.SqlDbType = SqlDbType.DateTime
																		Else
																			flag15 = type2 Is GetType(Byte())
																			If flag15 Then
																				sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
																				Dim text7 As String = sqlDataReader3.GetDataTypeName(i).ToLower()
																				Dim flag16 As Boolean = text7.Contains("image")
																				If flag16 Then
																					sqlParameter.SqlDbType = SqlDbType.Image
																				Else
																					sqlParameter.SqlDbType = SqlDbType.VarBinary
																				End If
																			Else
																				sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
																				sqlParameter.SqlDbType = Me.GetSqlDbTypeFromType(type)
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
													sqlParameter2.Value = RuntimeHelpers.GetObjectValue(sqlParameter.Value)
													sqlParameter2.SqlDbType = sqlParameter.SqlDbType
												End If
											Catch ex As Exception
												Throw New Exception(String.Format("Column '{0}' value '{1}' could not be converted to {2}.", name, RuntimeHelpers.GetObjectValue(objectValue2), type.Name), ex)
											End Try
										Else
											sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
											sqlParameter2.Value = RuntimeHelpers.GetObjectValue(objectValue2)
										End If
									End If
									list2.Add(sqlParameter)
									Dim flag17 As Boolean = flag6
									If flag17 Then
										list2.Add(sqlParameter2)
									End If
								End If
							Next
							Try
								Dim flag18 As Boolean = flag5
								If flag18 Then
																		Dim flag19 As Boolean = False
									Dim flag20 As Boolean = hashSet.Any(Function(ic As String) cols.Any(Function(c As String) String.Equals(c.Trim("["c, "]"c), ic, StringComparison.OrdinalIgnoreCase)))
									If flag20 Then
										Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] ON", tableName), remoteCon)
										sqlCommand4.ExecuteNonQuery()
										flag19 = True
									End If
									Dim text8 As String = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, String.Join(",", cols), String.Join(",", list))
									Dim sqlCommand5 As SqlCommand = New SqlCommand(text8, remoteCon)
									sqlCommand5.Parameters.AddRange(list2.ToArray())
									sqlCommand5.ExecuteNonQuery()
									Dim flag21 As Boolean = flag19
									If flag21 Then
										Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] OFF", tableName), remoteCon)
										sqlCommand6.ExecuteNonQuery()
									End If
									Using sqlCommand7 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 1 WHERE SyncGuid = @sync", tableName), localCon)
										sqlCommand7.Parameters.AddWithValue("@sync", text4)
										sqlCommand7.ExecuteNonQuery()
									End Using
								Else
									Dim flag22 As Boolean = flag6
									If flag22 Then
										Dim list4 As List(Of String) = New List(Of String)()
										Dim list5 As List(Of SqlParameter) = New List(Of SqlParameter)()
																				Dim num2 As Integer = sqlDataReader3.FieldCount - 1
										For j As Integer = 0 To num2
											Dim colName As String = sqlDataReader3.GetName(j)
											Dim flag23 As Boolean = hashSet.Contains(colName) OrElse Operators.CompareString(colName, "is_remote", False) = 0
											If Not flag23 Then
												list4.Add(String.Format("[{0}] = @upd_{1}", colName, colName))
												Dim sqlParameter3 As SqlParameter = list2.FirstOrDefault(Function(p As SqlParameter) Operators.CompareString(p.ParameterName, "@upd_" + colName, False) = 0)
												If sqlParameter3 IsNot Nothing Then
													list5.Add(sqlParameter3)
												End If
											End If
										Next
										list5.Add(New SqlParameter("@sync", text4))
										Dim text9 As String = String.Format("UPDATE [{0}] SET {1} WHERE SyncGuid = @sync", tableName, String.Join(", ", list4))
										Using sqlCommand8 As SqlCommand = New SqlCommand(text9, remoteCon)
											sqlCommand8.Parameters.AddRange(list5.ToArray())
											sqlCommand8.ExecuteNonQuery()
										End Using
									End If
								End If
							Catch ex2 As Exception
								Debug.WriteLine(String.Format("❌ Error in {0}: {1}", tableName, ex2.Message))
							End Try
						End If
					End If
				End While
				sqlDataReader3.Close()
				Dim list6 As List(Of String) = hashSet2.Except(hashSet3).ToList()
				Try
					For Each text10 As String In list6
						Using sqlCommand9 As SqlCommand = New SqlCommand(String.Format("DELETE FROM [{0}] WHERE SyncGuid = @sync", tableName), remoteCon)
							sqlCommand9.Parameters.AddWithValue("@sync", text10)
							sqlCommand9.ExecuteNonQuery()
						End Using
					Next
				Finally
					Dim enumerator2 As List(Of String).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
			Catch ex3 As Exception
				MessageBox.Show("❌ Error in table " + tableName + ": " + ex3.Message)
			End Try
		End Sub

		' Token: 0x0600C8D0 RID: 51408 RVA: 0x007EACF8 File Offset: 0x007E8EF8
		Public Sub HomeButtonControl()
			Dim dictionary As Dictionary(Of String, List(Of Button)) = New Dictionary(Of String, List(Of Button))() From { { "frmProduct", New List(Of Button)() From { Me.Button20, Me.Button16 } }, { "frmPOSTouch", New List(Of Button)() From { Me.Button10 } }, { "frmPOSNewTuch", New List(Of Button)() From { Me.GelButton2 } }, { "frmPurchaseEntry", New List(Of Button)() From { Me.Button11 } } }
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = ""
				Dim text2 As String = Me.lblUserType.Text
				If Operators.CompareString(text2, "Admin", False) <> 0 Then
					If Operators.CompareString(text2, "Sales Person", False) <> 0 Then
						If Operators.CompareString(text2, "Moderator", False) <> 0 Then
							If Operators.CompareString(text2, "Inventory Manager", False) <> 0 Then
								Return
							End If
							text = "SELECT COUNT(*) FROM tbl_master_menu WHERE form_name = @FormName AND for_InventoryManager=1"
						Else
							text = "SELECT COUNT(*) FROM tbl_master_menu WHERE form_name = @FormName AND for_Moderator=1"
						End If
					Else
						text = "SELECT COUNT(*) FROM tbl_master_menu WHERE form_name = @FormName AND for_SalesPerson=1"
					End If
				Else
					text = "SELECT COUNT(*) FROM tbl_master_menu WHERE form_name = @FormName AND for_admin=1"
				End If
				Try
					For Each keyValuePair As KeyValuePair(Of String, List(Of Button)) In dictionary
						Dim key As String = keyValuePair.Key
						Dim value As List(Of Button) = keyValuePair.Value
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@FormName", key)
							Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
							Try
								For Each button As Button In value
									button.Visible = num > 0
								Next
							Finally
								Dim enumerator2 As List(Of Button).Enumerator
								CType(enumerator2, IDisposable).Dispose()
							End Try
						End Using
					Next
				Finally
					Dim enumerator As Dictionary(Of String, List(Of Button)).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
			End Using
		End Sub

		' Token: 0x17004FF1 RID: 20465
		' (get) Token: 0x0600C8D1 RID: 51409 RVA: 0x0005999F File Offset: 0x00057B9F
		' (set) Token: 0x0600C8D2 RID: 51410 RVA: 0x000599A9 File Offset: 0x00057BA9
		Friend Overridable Property btnCategory As Button

		' Token: 0x17004FF2 RID: 20466
		' (get) Token: 0x0600C8D3 RID: 51411 RVA: 0x000599B2 File Offset: 0x00057BB2
		' (set) Token: 0x0600C8D4 RID: 51412 RVA: 0x000599BC File Offset: 0x00057BBC
		Friend Overridable Property btnSubCategory As Button

		' Token: 0x0600C8D5 RID: 51413 RVA: 0x007EAF5C File Offset: 0x007E915C
		Private Sub FillCategory()
			Me.FlowLayoutPanel1.Controls.Clear()
			Dim text As String = Me.lblUserType.Text
			Dim num As Integer = 70
			Dim num2 As Integer = 70
			Dim text2 As String = "SELECT h.category_name, h.id, h.icon_img" & vbCrLf & "         FROM tbl_master_menu_header h" & vbCrLf & "         WHERE is_deleted = 'false'" & vbCrLf & "           AND EXISTS (" & vbCrLf & "               SELECT 1 " & vbCrLf & "               FROM tbl_master_menu m" & vbCrLf & "               WHERE m.category_name = h.category_name" & vbCrLf & "                 AND (" & vbCrLf & "                      (@userType = 'Admin' AND m.for_admin = 1) OR" & vbCrLf & "                      (@userType = 'Sales Person' AND m.for_SalesPerson = 1) OR" & vbCrLf & "                      (@userType = 'Moderator' AND m.for_Moderator = 1) OR" & vbCrLf & "                      (@userType = 'Inventory Manager' AND m.for_InventoryManager = 1)" & vbCrLf & "                 )" & vbCrLf & "           )" & vbCrLf & "         ORDER BY h.orderby"
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@userType", text)
					sqlConnection.Open()
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim button As Button = New Button()
							button.Width = num
							button.Height = num2
							button.BackColor = Color.White
							button.ForeColor = Color.Black
							button.FlatStyle = FlatStyle.Flat
							button.FlatAppearance.BorderSize = 0
							button.Tag = sqlDataReader("category_name").ToString()
							button.TextAlign = ContentAlignment.BottomCenter
							Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))
							If flag Then
								Dim array As Byte() = CType(sqlDataReader("icon_img"), Byte())
								Dim flag2 As Boolean = array.Length > 0
								If flag2 Then
									Using memoryStream As MemoryStream = New MemoryStream(array)
										Using image As Image = Image.FromStream(memoryStream)
											Using bitmap As Bitmap = New Bitmap(image, num, num2)
												bitmap.MakeTransparent(Color.White)
												button.BackgroundImage = CType(bitmap.Clone(), Image)
											End Using
										End Using
									End Using
								End If
							End If
							AddHandler button.Click, AddressOf Me.btnCategory_Click
							Me.flpItemsCategory.Controls.Add(button)
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x0600C8D6 RID: 51414 RVA: 0x007EB1F8 File Offset: 0x007E93F8
		Private Sub FillSubCategory(strCategory As String)
			Dim num As Integer = 110
			Dim num2 As Integer = 110
			Dim num3 As Integer = 7
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Dim text As String = "SELECT RTRIM(sub_category_name) AS subCategory, id, icon_img " & vbCrLf & "         FROM tbl_master_menu " & vbCrLf & "         WHERE is_deleted = 'false' " & vbCrLf & "           AND category_name = @Category " & vbCrLf & "           AND (" & vbCrLf & "                (@userType = 'Admin' AND for_admin = 1) OR" & vbCrLf & "                (@userType = 'Sales Person' AND for_SalesPerson = 1) OR" & vbCrLf & "                (@userType = 'Moderator' AND for_Moderator = 1) OR" & vbCrLf & "                (@userType = 'Inventory Manager' AND for_InventoryManager = 1)" & vbCrLf & "               )"
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Category", strCategory)
					sqlCommand.Parameters.AddWithValue("@userType", Me.lblUserType.Text)
					sqlConnection.Open()
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim button As Button = New Button()
							button.Tag = RuntimeHelpers.GetObjectValue(sqlDataReader("id"))
							button.Size = New Size(num, num2)
							button.BackColor = Color.White
							button.FlatStyle = FlatStyle.Flat
							button.FlatAppearance.BorderSize = 0
							button.FlatAppearance.MouseOverBackColor = button.BackColor
							button.FlatAppearance.MouseDownBackColor = button.BackColor
							button.Margin = New Padding(num3)
							Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))
							If flag Then
								Dim array As Byte() = CType(sqlDataReader("icon_img"), Byte())
								Dim flag2 As Boolean = array.Length > 0
								If flag2 Then
									Using memoryStream As MemoryStream = New MemoryStream(array)
										Using image As Image = Image.FromStream(memoryStream)
											Using bitmap As Bitmap = New Bitmap(image, num, num2)
												button.BackgroundImage = CType(bitmap.Clone(), Image)
												button.BackgroundImageLayout = ImageLayout.Stretch
											End Using
										End Using
									End Using
								End If
							End If
							AddHandler button.Click, AddressOf Me.btnSubCategory_Click
							Me.flpItems_BV.Controls.Add(button)
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x0600C8D7 RID: 51415 RVA: 0x007EB4D0 File Offset: 0x007E96D0
		Private Sub btnCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = Me.lastClickedButton Is button
				If flag Then
					Me.flpItems_BV.Visible = Not Me.flpItems_BV.Visible
				Else
					Me.flpItems_BV.Visible = True
					Me.lastClickedButton = button
					Dim text As String = button.Tag.ToString()
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
					If flag2 Then
						Me.ToolStripMenuItem12.Visible = True
						Me.Button3.Enabled = True
						Me.UserPermissionSettingsToolStripMenuItem.Visible = True
					End If
					Me.FillSubCategory(text)
					Application.DoEvents()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8D8 RID: 51416 RVA: 0x007EB5C0 File Offset: 0x007E97C0
		Private Sub btnSubCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = button.Tag IsNot Nothing
				If flag Then
					Dim num As Integer = Conversions.ToInteger(button.Tag)
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, form_name FROM tbl_master_menu WHERE id = @id"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@id", num)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Dim text2 As String = sqlDataReader("form_name").ToString().Trim() + "1"
									Dim flag3 As Boolean = Not String.IsNullOrEmpty(text2)
									If flag3 Then
										Dim type As Type = MyBase.[GetType]()
										Dim method As MethodInfo = type.GetMethod(text2, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
										Dim flag4 As Boolean = method IsNot Nothing
										If flag4 Then
											method.Invoke(Me, Nothing)
										Else
											MessageBox.Show("Function '" + text2 + "' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End If
									Else
										MessageBox.Show("No function name found in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End If
								End If
							End Using
						End Using
					End Using
				Else
					MessageBox.Show("Button tag is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8D9 RID: 51417 RVA: 0x007EB7C0 File Offset: 0x007E99C0
		Public Function GetMenuItemsWithForms(menuStrip As MenuStrip) As DataTable
			Dim dataTable As DataTable = New DataTable()
			dataTable.Columns.Add("Parent Menu", GetType(String))
			dataTable.Columns.Add("Subcategory", GetType(String))
			dataTable.Columns.Add("Form Name", GetType(String))
			Try
				For Each obj As Object In menuStrip.Items
					Dim toolStripMenuItem As ToolStripMenuItem = CType(obj, ToolStripMenuItem)
					Me.ProcessSubMenu(toolStripMenuItem, dataTable, toolStripMenuItem.Text)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Return dataTable
		End Function

		' Token: 0x0600C8DA RID: 51418 RVA: 0x007EB888 File Offset: 0x007E9A88
		Private Sub ProcessSubMenu(parentItem As ToolStripMenuItem, dt As DataTable, parentName As String)
			Try
				For Each obj As Object In parentItem.DropDownItems
					Dim toolStripItem As ToolStripItem = CType(obj, ToolStripItem)
					Dim flag As Boolean = TypeOf toolStripItem Is ToolStripMenuItem
					If flag Then
						Dim toolStripMenuItem As ToolStripMenuItem = CType(toolStripItem, ToolStripMenuItem)
						Dim text As String = If((toolStripMenuItem.Tag IsNot Nothing), toolStripMenuItem.Tag.ToString(), "N/A")
						dt.Rows.Add(New Object() { parentName, toolStripMenuItem.Text, text })
						Dim hasDropDownItems As Boolean = toolStripMenuItem.HasDropDownItems
						If hasDropDownItems Then
							Me.ProcessSubMenu(toolStripMenuItem, dt, toolStripMenuItem.Text)
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C8DB RID: 51419 RVA: 0x007EB960 File Offset: 0x007E9B60
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
						Me.UpdateToolStripMenuItems()
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600C8DC RID: 51420 RVA: 0x007EBAE0 File Offset: 0x007E9CE0
		Private Sub UpdateToolStripMenuItems()
			Try
				For Each obj As Object In MyBase.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is MenuStrip
					If flag Then
						Dim menuStrip As MenuStrip = CType(control, MenuStrip)
						Try
							For Each obj2 As Object In menuStrip.Items
								Dim toolStripMenuItem As ToolStripMenuItem = CType(obj2, ToolStripMenuItem)
								Me.UpdateMenuItemText(toolStripMenuItem)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C8DD RID: 51421 RVA: 0x007EBBAC File Offset: 0x007E9DAC
		Private Sub UpdateMenuItemText(menuItem As ToolStripMenuItem)
			Dim text As String = menuItem.Text.Trim()
			Dim flag As Boolean = GlobalVariables.translations.ContainsKey(text)
			If flag Then
				menuItem.Text = GlobalVariables.translations(text).Trim()
			End If
			Try
				For Each obj As Object In menuItem.DropDownItems
					Dim toolStripMenuItem As ToolStripMenuItem = CType(obj, ToolStripMenuItem)
					Me.UpdateMenuItemText(toolStripMenuItem)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600C8DE RID: 51422 RVA: 0x007EBC44 File Offset: 0x007E9E44
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

		' Token: 0x0600C8DF RID: 51423 RVA: 0x007EBD10 File Offset: 0x007E9F10
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

		' Token: 0x0600C8E0 RID: 51424 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C8E1 RID: 51425 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C8E2 RID: 51426 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C8E3 RID: 51427 RVA: 0x007EBDDC File Offset: 0x007E9FDC
		Public Sub GetCustomerDisplayPort()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(CDPort),RTRIM(SecDisplay) from POSPrinterSetting where TillID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Dns.GetHostName())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.custsecdisplay = ModCommonClasses.rdr.GetValue(1).ToString()
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
		End Sub

		' Token: 0x0600C8E4 RID: 51428 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub InitializeChrome()
		End Sub

		' Token: 0x0600C8E5 RID: 51429 RVA: 0x007EBEEC File Offset: 0x007EA0EC
		Private Async Sub Timer7_Tick(sender As Object, e As EventArgs)
			Dim flag As Boolean = frmMainMenu.whatsApp1 Is Nothing
			If flag Then
				Await Task.Delay(500)
			Else
				Me.LblSenderId.Text = String.Format("Sender Id: {0}", If(frmMainMenu.whatsApp1.SenderID, "Unavailable"))
				If frmMainMenu.whatsApp1.CurrentState = State.READY Then
					Me.Label18.Enabled = True
					Me.LblEngine1.ForeColor = Color.DarkGreen
					Me.LblSenderId.Visible = False
				Else
					Me.Label18.Enabled = False
					Me.LblEngine1.ForeColor = Color.Red
					Me.LblSenderId.Visible = False
				End If
				If Me._ENGINE_STATE1 <> frmMainMenu.whatsApp.CurrentState Then
					Me.LblEngine1.Text = String.Format("WhatsApp : {0}", frmMainMenu.whatsApp.CurrentState.GetString())
					Me._ENGINE_STATE1 = frmMainMenu.whatsApp.CurrentState
				End If
			End If
		End Sub

		' Token: 0x0600C8E6 RID: 51430 RVA: 0x007EBF34 File Offset: 0x007EA134
		Public Sub wappnodisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C8E7 RID: 51431 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x0600C8E8 RID: 51432 RVA: 0x000599C5 File Offset: 0x00057BC5
		Private Sub IndividualToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
		End Sub

		' Token: 0x0600C8E9 RID: 51433 RVA: 0x000599C5 File Offset: 0x00057BC5
		Public Sub frmProductRecordx1()
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
		End Sub

		' Token: 0x0600C8EA RID: 51434 RVA: 0x007EC004 File Offset: 0x007EA204
		Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
		End Sub

		' Token: 0x0600C8EB RID: 51435 RVA: 0x007EC004 File Offset: 0x007EA204
		Public Sub frmPayment1()
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
		End Sub

		' Token: 0x0600C8EC RID: 51436 RVA: 0x00043350 File Offset: 0x00041550
		Private Sub TrialBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTrialBalance.Reset()
			MyProject.Forms.frmTrialBalance.ShowDialog()
			MyProject.Forms.frmTrialBalance.Dispose()
		End Sub

		' Token: 0x0600C8ED RID: 51437 RVA: 0x00043350 File Offset: 0x00041550
		Public Sub frmTrialBalance1()
			MyProject.Forms.frmTrialBalance.Reset()
			MyProject.Forms.frmTrialBalance.ShowDialog()
			MyProject.Forms.frmTrialBalance.Dispose()
		End Sub

		' Token: 0x0600C8EE RID: 51438 RVA: 0x007EC054 File Offset: 0x007EA254
		Private Sub UnitMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUnit.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmUnit.Reset()
			MyProject.Forms.frmUnit.ShowDialog()
			MyProject.Forms.frmUnit.Dispose()
		End Sub

		' Token: 0x0600C8EF RID: 51439 RVA: 0x007EC054 File Offset: 0x007EA254
		Public Sub frmUnit1()
			MyProject.Forms.frmUnit.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmUnit.Reset()
			MyProject.Forms.frmUnit.ShowDialog()
			MyProject.Forms.frmUnit.Dispose()
		End Sub

		' Token: 0x0600C8F0 RID: 51440 RVA: 0x000599E8 File Offset: 0x00057BE8
		Private Sub SalesToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord.Reset()
			MyProject.Forms.frmSalesInvoiceRecord.ShowDialog()
		End Sub

		' Token: 0x0600C8F1 RID: 51441 RVA: 0x000599E8 File Offset: 0x00057BE8
		Public Sub frmSalesInvoiceRecord1()
			MyProject.Forms.frmSalesInvoiceRecord.Reset()
			MyProject.Forms.frmSalesInvoiceRecord.ShowDialog()
		End Sub

		' Token: 0x0600C8F2 RID: 51442 RVA: 0x00059A0B File Offset: 0x00057C0B
		Private Sub SalesReturnToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.ShowDialog()
		End Sub

		' Token: 0x0600C8F3 RID: 51443 RVA: 0x007EC0B4 File Offset: 0x007EA2B4
		Private Sub BankMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBank.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBank.Reset()
			MyProject.Forms.frmBank.ShowDialog()
			MyProject.Forms.frmBank.Dispose()
		End Sub

		' Token: 0x0600C8F4 RID: 51444 RVA: 0x007EC0B4 File Offset: 0x007EA2B4
		Public Sub frmBank1()
			MyProject.Forms.frmBank.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBank.Reset()
			MyProject.Forms.frmBank.ShowDialog()
			MyProject.Forms.frmBank.Dispose()
		End Sub

		' Token: 0x0600C8F5 RID: 51445 RVA: 0x007EC114 File Offset: 0x007EA314
		Private Sub BranchMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBranchMaster_Bank.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBranchMaster_Bank.Reset()
			MyProject.Forms.frmBranchMaster_Bank.ShowDialog()
			MyProject.Forms.frmBranchMaster_Bank.Dispose()
		End Sub

		' Token: 0x0600C8F6 RID: 51446 RVA: 0x007EC114 File Offset: 0x007EA314
		Public Sub frmBranchMaster_Bank1()
			MyProject.Forms.frmBranchMaster_Bank.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBranchMaster_Bank.Reset()
			MyProject.Forms.frmBranchMaster_Bank.ShowDialog()
			MyProject.Forms.frmBranchMaster_Bank.Dispose()
		End Sub

		' Token: 0x0600C8F7 RID: 51447 RVA: 0x007EC174 File Offset: 0x007EA374
		Private Sub BankAccountRegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBankAccountRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBankAccountRegistration.Reset()
			MyProject.Forms.frmBankAccountRegistration.ShowDialog()
			MyProject.Forms.frmBankAccountRegistration.Dispose()
		End Sub

		' Token: 0x0600C8F8 RID: 51448 RVA: 0x007EC174 File Offset: 0x007EA374
		Public Sub frmBankAccountRegistration1()
			MyProject.Forms.frmBankAccountRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBankAccountRegistration.Reset()
			MyProject.Forms.frmBankAccountRegistration.ShowDialog()
			MyProject.Forms.frmBankAccountRegistration.Dispose()
		End Sub

		' Token: 0x0600C8F9 RID: 51449 RVA: 0x007EC1D4 File Offset: 0x007EA3D4
		Private Sub FundDepositToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFundDeposit.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFundDeposit.Reset()
			MyProject.Forms.frmFundDeposit.ShowDialog()
			MyProject.Forms.frmFundDeposit.Dispose()
		End Sub

		' Token: 0x0600C8FA RID: 51450 RVA: 0x007EC1D4 File Offset: 0x007EA3D4
		Public Sub frmFundDeposit1()
			MyProject.Forms.frmFundDeposit.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFundDeposit.Reset()
			MyProject.Forms.frmFundDeposit.ShowDialog()
			MyProject.Forms.frmFundDeposit.Dispose()
		End Sub

		' Token: 0x0600C8FB RID: 51451 RVA: 0x007EC234 File Offset: 0x007EA434
		Private Sub FundTransferToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFundTransfer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFundTransfer.Reset()
			MyProject.Forms.frmFundTransfer.ShowDialog()
			MyProject.Forms.frmFundTransfer.Dispose()
		End Sub

		' Token: 0x0600C8FC RID: 51452 RVA: 0x007EC234 File Offset: 0x007EA434
		Public Sub frmFundTransfer1()
			MyProject.Forms.frmFundTransfer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFundTransfer.Reset()
			MyProject.Forms.frmFundTransfer.ShowDialog()
			MyProject.Forms.frmFundTransfer.Dispose()
		End Sub

		' Token: 0x0600C8FD RID: 51453 RVA: 0x007EC294 File Offset: 0x007EA494
		Private Sub PaymentWithdrawalToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment_Withdrawal.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment_Withdrawal.Reset()
			MyProject.Forms.frmPayment_Withdrawal.ShowDialog()
			MyProject.Forms.frmPayment_Withdrawal.Dispose()
		End Sub

		' Token: 0x0600C8FE RID: 51454 RVA: 0x007EC294 File Offset: 0x007EA494
		Public Sub frmPayment_Withdrawal1()
			MyProject.Forms.frmPayment_Withdrawal.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment_Withdrawal.Reset()
			MyProject.Forms.frmPayment_Withdrawal.ShowDialog()
			MyProject.Forms.frmPayment_Withdrawal.Dispose()
		End Sub

		' Token: 0x0600C8FF RID: 51455 RVA: 0x00059A2E File Offset: 0x00057C2E
		Private Sub BankAccountStatementsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBankAccountStatements.Reset()
			MyProject.Forms.frmBankAccountStatements.ShowDialog()
			MyProject.Forms.frmBankAccountStatements.Dispose()
		End Sub

		' Token: 0x0600C900 RID: 51456 RVA: 0x00059A2E File Offset: 0x00057C2E
		Public Sub frmBankAccountStatements1()
			MyProject.Forms.frmBankAccountStatements.Reset()
			MyProject.Forms.frmBankAccountStatements.ShowDialog()
			MyProject.Forms.frmBankAccountStatements.Dispose()
		End Sub

		' Token: 0x0600C901 RID: 51457 RVA: 0x007EC2F4 File Offset: 0x007EA4F4
		Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Customers.Reset()
				MyProject.Forms.frmExportImportExcel_Customers.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C902 RID: 51458 RVA: 0x007EC2F4 File Offset: 0x007EA4F4
		Public Sub frmExportImportExcel_Customers1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Customers.Reset()
				MyProject.Forms.frmExportImportExcel_Customers.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C903 RID: 51459 RVA: 0x007EC358 File Offset: 0x007EA558
		Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Suppliers.Reset()
				MyProject.Forms.frmExportImportExcel_Suppliers.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C904 RID: 51460 RVA: 0x007EC358 File Offset: 0x007EA558
		Public Sub frmExportImportExcel_Suppliers1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Suppliers.Reset()
				MyProject.Forms.frmExportImportExcel_Suppliers.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C905 RID: 51461 RVA: 0x007EC3BC File Offset: 0x007EA5BC
		Private Sub ProductsToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_ProductsRecord.Reset()
				MyProject.Forms.frmExportImportExcel_ProductsRecord.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C906 RID: 51462 RVA: 0x007EC3BC File Offset: 0x007EA5BC
		Public Sub frmExportImportExcel_ProductsRecordx1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_ProductsRecord.Reset()
				MyProject.Forms.frmExportImportExcel_ProductsRecord.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C907 RID: 51463 RVA: 0x007EC420 File Offset: 0x007EA620
		Private Sub LogActivityToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLogs.Reset()
			MyProject.Forms.frmLogs.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLogs.ShowDialog()
		End Sub

		' Token: 0x0600C908 RID: 51464 RVA: 0x007EC420 File Offset: 0x007EA620
		Public Sub frmLogs1()
			MyProject.Forms.frmLogs.Reset()
			MyProject.Forms.frmLogs.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLogs.ShowDialog()
		End Sub

		' Token: 0x0600C909 RID: 51465 RVA: 0x00059A61 File Offset: 0x00057C61
		Private Sub BackupToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Me.Backup()
		End Sub

		' Token: 0x0600C90A RID: 51466 RVA: 0x00059A61 File Offset: 0x00057C61
		Public Sub Backup1()
			Me.Backup()
		End Sub

		' Token: 0x0600C90B RID: 51467 RVA: 0x007EC470 File Offset: 0x007EA670
		Private Sub RestoreToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = MessageBox.Show("Restored company database and exising company database name should be same.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag2 Then
					Try
						Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
						openFileDialog.Filter = "DB Backup File|*.bak;"
						openFileDialog.FilterIndex = 4
						Me.OpenFileDialog1.FileName = ""
						Dim flag3 As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
						Dim flag4 As Boolean = flag3
						If flag4 Then
							Me.Cursor = Cursors.WaitCursor
							Me.Timer2.Enabled = True
							Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
							Me.stX = array(0)
							SqlConnection.ClearAllPools()
							ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
							ModCommonClasses.con.Open()
							Dim text As String = String.Concat(New String() { "USE Master ALTER DATABASE ", Me.stX, " SET Single_User WITH Rollback Immediate Restore database ", Me.stX, " FROM disk='", Me.OpenFileDialog1.FileName, "' WITH REPLACE ALTER DATABASE ", Me.stX, " SET Multi_User " })
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Me.CompanyInfoDisplay()
							ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update RaintechMaster set companyName=@d1 where DBName=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.Label43.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtDB.Text)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							Dim text3 As String = "Sucessfully Performed the Restore"
							ModFunc.LogFunc(Me.lblUser.Text, text3)
							MessageBox.Show("Successfully Performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600C90C RID: 51468 RVA: 0x007EC710 File Offset: 0x007EA910
		Public Sub Restore1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = MessageBox.Show("Restored company database and existing company database name should be same.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag2 Then
					Try
						Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
						openFileDialog.Filter = "DB Backup File|*.bak;"
						openFileDialog.FilterIndex = 4
						Me.OpenFileDialog1.FileName = ""
						Dim flag3 As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
						Dim flag4 As Boolean = flag3
						If flag4 Then
							Me.Cursor = Cursors.WaitCursor
							Me.Timer2.Enabled = True
							Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
							Me.stX = array(0)
							SqlConnection.ClearAllPools()
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.ReadCS())
								sqlConnection.Open()
								Dim text As String = ""
								Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
									sqlConnection2.Open()
									Using sqlCommand As SqlCommand = New SqlCommand("SELECT SERVERPROPERTY('InstanceDefaultDataPath')", sqlConnection2)
										text = sqlCommand.ExecuteScalar().ToString()
									End Using
									sqlConnection2.Close()
								End Using
								Dim text2 As String = String.Concat(New String() { vbCrLf & "USE master;" & vbCrLf & "ALTER DATABASE ", Me.stX, " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" & vbCrLf & vbCrLf & "RESTORE DATABASE ", Me.stX, " " & vbCrLf & "FROM DISK = '", Me.OpenFileDialog1.FileName, "' " & vbCrLf & "WITH REPLACE," & vbCrLf & "MOVE 'Raintech_DB1' TO '", text, Me.stX, ".mdf'," & vbCrLf & "MOVE 'Raintech_DB1_log' TO '", text, Me.stX, "_log.ldf';" & vbCrLf & vbCrLf & "ALTER DATABASE ", Me.stX, " SET MULTI_USER;" & vbCrLf })
								Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
									sqlCommand2.ExecuteNonQuery()
								End Using
							End Using
							Me.CompanyInfoDisplay()
							Using sqlConnection3 As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
								sqlConnection3.Open()
								Dim text3 As String = "Update RaintechMaster set companyName=@d1 where DBName=@d2"
								Using sqlCommand3 As SqlCommand = New SqlCommand(text3, sqlConnection3)
									sqlCommand3.Parameters.AddWithValue("@d1", Me.Label43.Text)
									sqlCommand3.Parameters.AddWithValue("@d2", Me.txtDB.Text)
									sqlCommand3.ExecuteNonQuery()
								End Using
							End Using
							Dim text4 As String = "Successfully Performed the Restore"
							ModFunc.LogFunc(Me.lblUser.Text, text4)
							MessageBox.Show("Successfully Performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600C90D RID: 51469 RVA: 0x007ECAC8 File Offset: 0x007EACC8
		Public Sub Restoredata()
			Dim flag As Boolean = MessageBox.Show("Restored company database and exising company database name should be same.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			If flag Then
				Try
					Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
					openFileDialog.Filter = "DB Backup File|*.bak;"
					openFileDialog.FilterIndex = 4
					Me.OpenFileDialog1.FileName = ""
					Dim flag2 As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
					Dim flag3 As Boolean = flag2
					If flag3 Then
						Me.Cursor = Cursors.WaitCursor
						Me.Timer2.Enabled = True
						Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
						Me.stX = array(0)
						SqlConnection.ClearAllPools()
						ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
						ModCommonClasses.con.Open()
						Dim text As String = String.Concat(New String() { "USE Master ALTER DATABASE ", Me.stX, " SET Single_User WITH Rollback Immediate Restore database ", Me.stX, " FROM disk='", Me.OpenFileDialog1.FileName, "' WITH REPLACE ALTER DATABASE ", Me.stX, " SET Multi_User " })
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						Dim text2 As String = "Sucessfully Performed the cloud Restore"
						ModFunc.LogFunc(Me.Label1.Text, text2)
						MessageBox.Show("Successfully Performed Cloud Restore", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600C90E RID: 51470 RVA: 0x007ECC98 File Offset: 0x007EAE98
		Private Sub SalemanToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesman.Reset()
			MyProject.Forms.frmSalesman.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesman.ShowDialog()
			MyProject.Forms.frmSalesman.Dispose()
		End Sub

		' Token: 0x0600C90F RID: 51471 RVA: 0x007ECC98 File Offset: 0x007EAE98
		Public Sub frmSalesman1()
			MyProject.Forms.frmSalesman.Reset()
			MyProject.Forms.frmSalesman.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesman.ShowDialog()
			MyProject.Forms.frmSalesman.Dispose()
		End Sub

		' Token: 0x0600C910 RID: 51472 RVA: 0x007ECCF8 File Offset: 0x007EAEF8
		Private Sub SupplierToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplier.Label31.Text = Me.lblUserType.Text
			MyProject.Forms.frmSupplier.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x0600C911 RID: 51473 RVA: 0x007ECD98 File Offset: 0x007EAF98
		Public Sub frmSupplier1()
			MyProject.Forms.frmSuppliers.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSuppliers.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSuppliers.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSuppliers.Reset()
			MyProject.Forms.frmSuppliers.ShowDialog()
			MyProject.Forms.frmSuppliers.Dispose()
		End Sub

		' Token: 0x0600C912 RID: 51474 RVA: 0x007ECE38 File Offset: 0x007EB038
		Private Sub ProductsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProduct.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmProduct.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmProduct.Reset()
			MyProject.Forms.frmProduct.ShowDialog()
			MyProject.Forms.frmProduct.Dispose()
		End Sub

		' Token: 0x0600C913 RID: 51475 RVA: 0x007ECE38 File Offset: 0x007EB038
		Public Sub frmProduct1()
			MyProject.Forms.frmProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProduct.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmProduct.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmProduct.Reset()
			MyProject.Forms.frmProduct.ShowDialog()
			MyProject.Forms.frmProduct.Dispose()
		End Sub

		' Token: 0x0600C914 RID: 51476 RVA: 0x007ECED8 File Offset: 0x007EB0D8
		Private Sub ServiceCreationToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServices.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmServices.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmServices.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmServices.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmServices.Reset()
			MyProject.Forms.frmServices.ShowDialog()
			MyProject.Forms.frmServices.Dispose()
		End Sub

		' Token: 0x0600C915 RID: 51477 RVA: 0x007ECED8 File Offset: 0x007EB0D8
		Public Sub frmServices1()
			MyProject.Forms.frmServices.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmServices.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmServices.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmServices.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmServices.Reset()
			MyProject.Forms.frmServices.ShowDialog()
			MyProject.Forms.frmServices.Dispose()
		End Sub

		' Token: 0x0600C916 RID: 51478 RVA: 0x007ECF98 File Offset: 0x007EB198
		Private Sub ServiceBillingToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServiceBilling.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmServiceBilling.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmServiceBilling.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmServiceBilling.Reset()
			MyProject.Forms.frmServiceBilling.ShowDialog()
			MyProject.Forms.frmServiceBilling.Dispose()
		End Sub

		' Token: 0x0600C917 RID: 51479 RVA: 0x007ECF98 File Offset: 0x007EB198
		Public Sub frmServiceBilling1()
			MyProject.Forms.frmServiceBilling.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmServiceBilling.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmServiceBilling.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmServiceBilling.Reset()
			MyProject.Forms.frmServiceBilling.ShowDialog()
			MyProject.Forms.frmServiceBilling.Dispose()
		End Sub

		' Token: 0x0600C918 RID: 51480 RVA: 0x007ED038 File Offset: 0x007EB238
		Private Sub SendSMSToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSendSMS_Services.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSendSMS_Services.Reset()
			MyProject.Forms.frmSendSMS_Services.ShowDialog()
			MyProject.Forms.frmSendSMS_Services.Dispose()
		End Sub

		' Token: 0x0600C919 RID: 51481 RVA: 0x007ED038 File Offset: 0x007EB238
		Public Sub frmSendSMS_Services1()
			MyProject.Forms.frmSendSMS_Services.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSendSMS_Services.Reset()
			MyProject.Forms.frmSendSMS_Services.ShowDialog()
			MyProject.Forms.frmSendSMS_Services.Dispose()
		End Sub

		' Token: 0x0600C91A RID: 51482 RVA: 0x0003873B File Offset: 0x0003693B
		Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x0600C91B RID: 51483 RVA: 0x0003873B File Offset: 0x0003693B
		Public Sub frmCustomerRecord1()
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x0600C91C RID: 51484 RVA: 0x00525728 File Offset: 0x00523928
		Private Sub SalesmanToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanRecord.Reset()
			MyProject.Forms.frmSalesmanRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesmanRecord.ShowDialog()
			MyProject.Forms.frmSalesmanRecord.Dispose()
		End Sub

		' Token: 0x0600C91D RID: 51485 RVA: 0x00525728 File Offset: 0x00523928
		Public Sub frmSalesmanRecord1()
			MyProject.Forms.frmSalesmanRecord.Reset()
			MyProject.Forms.frmSalesmanRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesmanRecord.ShowDialog()
			MyProject.Forms.frmSalesmanRecord.Dispose()
		End Sub

		' Token: 0x0600C91E RID: 51486 RVA: 0x000432B4 File Offset: 0x000414B4
		Private Sub SuppliersToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x0600C91F RID: 51487 RVA: 0x000432B4 File Offset: 0x000414B4
		Public Sub frmSupplierRecord1()
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x0600C920 RID: 51488 RVA: 0x0003876E File Offset: 0x0003696E
		Private Sub ProductsToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
			MyProject.Forms.frmProductRecord.Dispose()
		End Sub

		' Token: 0x0600C921 RID: 51489 RVA: 0x0003876E File Offset: 0x0003696E
		Public Sub frmProductRecord1()
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
			MyProject.Forms.frmProductRecord.Dispose()
		End Sub

		' Token: 0x0600C922 RID: 51490 RVA: 0x007ED098 File Offset: 0x007EB298
		Private Sub PurchasesToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.ShowDialog()
			MyProject.Forms.frmPurchaseRecord.Dispose()
		End Sub

		' Token: 0x0600C923 RID: 51491 RVA: 0x007ED098 File Offset: 0x007EB298
		Public Sub frmPurchaseRecord1()
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.ShowDialog()
			MyProject.Forms.frmPurchaseRecord.Dispose()
		End Sub

		' Token: 0x0600C924 RID: 51492 RVA: 0x000387B4 File Offset: 0x000369B4
		Private Sub StockEntryToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntryRecord1.Reset()
			MyProject.Forms.frmStockEntryRecord1.ShowDialog()
			MyProject.Forms.frmStockEntryRecord1.Dispose()
		End Sub

		' Token: 0x0600C925 RID: 51493 RVA: 0x000387B4 File Offset: 0x000369B4
		Public Sub frmStockEntryRecord11()
			MyProject.Forms.frmStockEntryRecord1.Reset()
			MyProject.Forms.frmStockEntryRecord1.ShowDialog()
			MyProject.Forms.frmStockEntryRecord1.Dispose()
		End Sub

		' Token: 0x0600C926 RID: 51494 RVA: 0x007ED108 File Offset: 0x007EB308
		Private Sub PurchaseReturnToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord.Dispose()
		End Sub

		' Token: 0x0600C927 RID: 51495 RVA: 0x007ED108 File Offset: 0x007EB308
		Public Sub frmPurchaseReturnRecord1()
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord.Dispose()
		End Sub

		' Token: 0x0600C928 RID: 51496 RVA: 0x007ED178 File Offset: 0x007EB378
		Private Sub ServicesToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmServicesRecord.Reset()
			MyProject.Forms.frmServicesRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmServicesRecord.Reset()
			MyProject.Forms.frmServicesRecord.ShowDialog()
			MyProject.Forms.frmServicesRecord.Dispose()
		End Sub

		' Token: 0x0600C929 RID: 51497 RVA: 0x007ED178 File Offset: 0x007EB378
		Public Sub frmServicesRecord1()
			MyProject.Forms.frmServicesRecord.Reset()
			MyProject.Forms.frmServicesRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmServicesRecord.Reset()
			MyProject.Forms.frmServicesRecord.ShowDialog()
			MyProject.Forms.frmServicesRecord.Dispose()
		End Sub

		' Token: 0x0600C92A RID: 51498 RVA: 0x00059A6B File Offset: 0x00057C6B
		Private Sub ServiceBillingToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmServiceBillingRecord.Reset()
			MyProject.Forms.frmServiceBillingRecord.ShowDialog()
			MyProject.Forms.frmServiceBillingRecord.Dispose()
		End Sub

		' Token: 0x0600C92B RID: 51499 RVA: 0x00059A6B File Offset: 0x00057C6B
		Public Sub frmServiceBillingRecord1()
			MyProject.Forms.frmServiceBillingRecord.Reset()
			MyProject.Forms.frmServiceBillingRecord.ShowDialog()
			MyProject.Forms.frmServiceBillingRecord.Dispose()
		End Sub

		' Token: 0x0600C92C RID: 51500 RVA: 0x005259AC File Offset: 0x00523BAC
		Private Sub QuotationsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmQuotationRecord.Reset()
			MyProject.Forms.frmQuotationRecord.Label3.Text = ""
			MyProject.Forms.frmQuotationRecord.Reset()
			MyProject.Forms.frmQuotationRecord.ShowDialog()
			MyProject.Forms.frmQuotationRecord.Dispose()
		End Sub

		' Token: 0x0600C92D RID: 51501 RVA: 0x007ED1E8 File Offset: 0x007EB3E8
		Public Sub frmQuotationRecord1()
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.lblSet.Text = ""
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.Reset()
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.ShowDialog()
			MyProject.Forms.frmPOSNewTuch_QuotationRecord.Dispose()
		End Sub

		' Token: 0x0600C92E RID: 51502 RVA: 0x0065432C File Offset: 0x0065252C
		Private Sub PaymentsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.lblSet.Text = ""
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.ShowDialog()
			MyProject.Forms.frmPaymentRecord.Dispose()
		End Sub

		' Token: 0x0600C92F RID: 51503 RVA: 0x0065432C File Offset: 0x0065252C
		Public Sub frmPaymentRecord1()
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.lblSet.Text = ""
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.ShowDialog()
			MyProject.Forms.frmPaymentRecord.Dispose()
		End Sub

		' Token: 0x0600C930 RID: 51504 RVA: 0x007ED280 File Offset: 0x007EB480
		Private Sub SMSToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSMS.Reset()
			MyProject.Forms.frmSMS.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSMS.ShowDialog()
			MyProject.Forms.frmSMS.Dispose()
		End Sub

		' Token: 0x0600C931 RID: 51505 RVA: 0x007ED280 File Offset: 0x007EB480
		Public Sub frmSMS1()
			MyProject.Forms.frmSMS.Reset()
			MyProject.Forms.frmSMS.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSMS.ShowDialog()
			MyProject.Forms.frmSMS.Dispose()
		End Sub

		' Token: 0x0600C932 RID: 51506 RVA: 0x00059A9E File Offset: 0x00057C9E
		Private Sub ServiceBillingToolStripMenuItem3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServiceDoneReport.Reset()
			MyProject.Forms.frmServiceDoneReport.ShowDialog()
			MyProject.Forms.frmServiceDoneReport.Dispose()
		End Sub

		' Token: 0x0600C933 RID: 51507 RVA: 0x00059A9E File Offset: 0x00057C9E
		Public Sub frmServiceDoneReport1()
			MyProject.Forms.frmServiceDoneReport.Reset()
			MyProject.Forms.frmServiceDoneReport.ShowDialog()
			MyProject.Forms.frmServiceDoneReport.Dispose()
		End Sub

		' Token: 0x0600C934 RID: 51508 RVA: 0x00038708 File Offset: 0x00036908
		Private Sub SalesToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReport.Reset()
			MyProject.Forms.frmSalesReport.ShowDialog()
			MyProject.Forms.frmSalesReport.Dispose()
		End Sub

		' Token: 0x0600C935 RID: 51509 RVA: 0x00038708 File Offset: 0x00036908
		Public Sub frmSalesReport1()
			MyProject.Forms.frmSalesReport.Reset()
			MyProject.Forms.frmSalesReport.ShowDialog()
			MyProject.Forms.frmSalesReport.Dispose()
		End Sub

		' Token: 0x0600C936 RID: 51510 RVA: 0x000433B6 File Offset: 0x000415B6
		Private Sub PurchaseToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReport.Reset()
			MyProject.Forms.frmPurchaseReport.ShowDialog()
			MyProject.Forms.frmPurchaseReport.Dispose()
		End Sub

		' Token: 0x0600C937 RID: 51511 RVA: 0x000433B6 File Offset: 0x000415B6
		Public Sub frmPurchaseReport1()
			MyProject.Forms.frmPurchaseReport.Reset()
			MyProject.Forms.frmPurchaseReport.ShowDialog()
			MyProject.Forms.frmPurchaseReport.Dispose()
		End Sub

		' Token: 0x0600C938 RID: 51512 RVA: 0x0003868F File Offset: 0x0003688F
		Private Sub StockEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntryReport.Reset()
			MyProject.Forms.frmStockEntryReport.ShowDialog()
			MyProject.Forms.frmStockEntryReport.Dispose()
		End Sub

		' Token: 0x0600C939 RID: 51513 RVA: 0x0003868F File Offset: 0x0003688F
		Public Sub frmStockEntryReport1()
			MyProject.Forms.frmStockEntryReport.Reset()
			MyProject.Forms.frmStockEntryReport.ShowDialog()
			MyProject.Forms.frmStockEntryReport.Dispose()
		End Sub

		' Token: 0x0600C93A RID: 51514 RVA: 0x000386C2 File Offset: 0x000368C2
		Private Sub StockInAndStockOutToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockInAndOutReport.ShowDialog()
			MyProject.Forms.frmStockInAndOutReport.Dispose()
		End Sub

		' Token: 0x0600C93B RID: 51515 RVA: 0x000386C2 File Offset: 0x000368C2
		Public Sub frmStockInAndOutReport1()
			MyProject.Forms.frmStockInAndOutReport.ShowDialog()
			MyProject.Forms.frmStockInAndOutReport.Dispose()
		End Sub

		' Token: 0x0600C93C RID: 51516 RVA: 0x007ED2E0 File Offset: 0x007EB4E0
		Private Sub LowStockItemsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer2.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ProductCode,Product.HSNCode,ProductName,Minstock,sum(Temp_Stock.Qty) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID group by ProductCode,Product.HSNCode,ProductName,MinStock having (sum(Temp_Stock.Qty)< MinStock) order by ProductName", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("LowStock.xml")
				Dim rptLowStock As rptLowStock = New rptLowStock()
				rptLowStock.SetDataSource(ModCommonClasses.ds)
				rptLowStock.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptLowStock
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C93D RID: 51517 RVA: 0x007ED2E0 File Offset: 0x007EB4E0
		Public Sub frmReport1()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer2.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ProductCode,Product.HSNCode,ProductName,Minstock,sum(Temp_Stock.Qty) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID group by ProductCode,Product.HSNCode,ProductName,MinStock having (sum(Temp_Stock.Qty)< MinStock) order by ProductName", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("LowStock.xml")
				Dim rptLowStock As rptLowStock = New rptLowStock()
				rptLowStock.SetDataSource(ModCommonClasses.ds)
				rptLowStock.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptLowStock
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C93E RID: 51518 RVA: 0x00059AD1 File Offset: 0x00057CD1
		Private Sub ExpenditureToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmVoucherReport.Reset()
			MyProject.Forms.frmVoucherReport.ShowDialog()
			MyProject.Forms.frmVoucherReport.Dispose()
		End Sub

		' Token: 0x0600C93F RID: 51519 RVA: 0x00059AD1 File Offset: 0x00057CD1
		Public Sub frmVoucherReport1()
			MyProject.Forms.frmVoucherReport.Reset()
			MyProject.Forms.frmVoucherReport.ShowDialog()
			MyProject.Forms.frmVoucherReport.Dispose()
		End Sub

		' Token: 0x0600C940 RID: 51520 RVA: 0x0003865C File Offset: 0x0003685C
		Private Sub BestAndLowSellingItemsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBestAndLowSellingItemsReport.Reset()
			MyProject.Forms.frmBestAndLowSellingItemsReport.ShowDialog()
			MyProject.Forms.frmBestAndLowSellingItemsReport.Dispose()
		End Sub

		' Token: 0x0600C941 RID: 51521 RVA: 0x0003865C File Offset: 0x0003685C
		Public Sub frmBestAndLowSellingItemsReport1()
			MyProject.Forms.frmBestAndLowSellingItemsReport.Reset()
			MyProject.Forms.frmBestAndLowSellingItemsReport.ShowDialog()
			MyProject.Forms.frmBestAndLowSellingItemsReport.Dispose()
		End Sub

		' Token: 0x0600C942 RID: 51522 RVA: 0x00038629 File Offset: 0x00036829
		Private Sub CreditTermsStatementsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCreditTermsStatements.Reset()
			MyProject.Forms.frmCreditTermsStatements.ShowDialog()
			MyProject.Forms.frmCreditTermsStatements.Dispose()
		End Sub

		' Token: 0x0600C943 RID: 51523 RVA: 0x00038629 File Offset: 0x00036829
		Public Sub frmCreditTermsStatements1()
			MyProject.Forms.frmCreditTermsStatements.Reset()
			MyProject.Forms.frmCreditTermsStatements.ShowDialog()
			MyProject.Forms.frmCreditTermsStatements.Dispose()
		End Sub

		' Token: 0x0600C944 RID: 51524 RVA: 0x007ED43C File Offset: 0x007EB63C
		Public Function ProcessRunning(name As String) As Boolean
			For Each process As Process In Process.GetProcesses()
				Dim flag As Boolean = process.ProcessName.StartsWith(name)
				If flag Then
					Return False
				End If
			Next
			Return True
		End Function

		' Token: 0x0600C945 RID: 51525 RVA: 0x007ED488 File Offset: 0x007EB688
		Private Sub btnTA0_Click(sender As Object, e As EventArgs)
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("MoneyLeaf")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("MoneyLeaf")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\MoneyLeaf.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Try
				Dim processesByName2 As Process() = Process.GetProcessesByName("RECEIPT_PRINTER")
				For Each process2 As Process In processesByName2
					process2.Kill()
				Next
				Dim flag3 As Boolean = Me.ProcessRunning("RECEIPT_PRINTER")
				If flag3 Then
					Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\RECEIPT_PRINTER.exe"
					Dim flag4 As Boolean = File.Exists(text2)
					If flag4 Then
						File.Delete(text2)
					End If
				End If
			Catch ex2 As Exception
			End Try
			Try
				Dim flag5 As Boolean = MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag5 Then
					Me.cloud()
					Dim flag6 As Boolean = Operators.CompareString(Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) <> 0
					If flag6 Then
						Me.Label3.Enabled = False
						Dim flag7 As Boolean = MessageBox.Show("Do you want take offline backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
						If flag7 Then
							Me.Backup()
							Me.LogOut()
						End If
						Me.LogOut()
					Else
						Me.Label3.Enabled = True
						Dim flag8 As Boolean = Operators.CompareString(Me.TextBox3.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) <> 0
						If flag8 Then
							Me.autoBackup()
						End If
						Me.LogOut()
					End If
				End If
			Catch ex3 As Exception
				MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C946 RID: 51526 RVA: 0x007ED6E8 File Offset: 0x007EB8E8
		Private Sub SalesToolStripMenuItem2_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesInvoiceRecord.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSalesInvoiceRecord.Reset()
			MyProject.Forms.frmSalesInvoiceRecord.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord.Dispose()
		End Sub

		' Token: 0x0600C947 RID: 51527 RVA: 0x007ED6E8 File Offset: 0x007EB8E8
		Public Sub frmSalesInvoiceRecordx1()
			MyProject.Forms.frmSalesInvoiceRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesInvoiceRecord.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSalesInvoiceRecord.Reset()
			MyProject.Forms.frmSalesInvoiceRecord.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord.Dispose()
		End Sub

		' Token: 0x0600C948 RID: 51528 RVA: 0x005258CC File Offset: 0x00523ACC
		Private Sub SalesReturnToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord.Dispose()
		End Sub

		' Token: 0x0600C949 RID: 51529 RVA: 0x005258CC File Offset: 0x00523ACC
		Public Sub frmSalesReturnRecord1()
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.lblSet.Text = ""
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord.Dispose()
		End Sub

		' Token: 0x0600C94A RID: 51530 RVA: 0x007ED760 File Offset: 0x007EB960
		Private Sub SaleEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOS.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOS.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmPOS.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOS.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPOS.Reset()
			MyProject.Forms.frmPOS.ShowDialog()
			MyProject.Forms.frmPOS.Dispose()
		End Sub

		' Token: 0x0600C94B RID: 51531 RVA: 0x007ED760 File Offset: 0x007EB960
		Public Sub frmPOS1()
			MyProject.Forms.frmPOS.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOS.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmPOS.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOS.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPOS.Reset()
			MyProject.Forms.frmPOS.ShowDialog()
			MyProject.Forms.frmPOS.Dispose()
		End Sub

		' Token: 0x0600C94C RID: 51532 RVA: 0x007ED820 File Offset: 0x007EBA20
		Private Sub SaleReturnToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSalesReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSalesReturn.Reset()
			MyProject.Forms.frmSalesReturn.ShowDialog()
			MyProject.Forms.frmSalesReturn.Dispose()
		End Sub

		' Token: 0x0600C94D RID: 51533 RVA: 0x007ED820 File Offset: 0x007EBA20
		Public Sub frmSalesReturn1()
			MyProject.Forms.frmSalesReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSalesReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSalesReturn.Reset()
			MyProject.Forms.frmSalesReturn.ShowDialog()
			MyProject.Forms.frmSalesReturn.Dispose()
		End Sub

		' Token: 0x0600C94E RID: 51534 RVA: 0x007ED8C0 File Offset: 0x007EBAC0
		Private Sub PurchaseEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseEntry.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseEntry.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseEntry.Reset()
			MyProject.Forms.frmPurchaseEntry.ShowDialog()
			MyProject.Forms.frmPurchaseEntry.Dispose()
		End Sub

		' Token: 0x0600C94F RID: 51535 RVA: 0x007ED8C0 File Offset: 0x007EBAC0
		Public Sub frmPurchaseEntry1()
			MyProject.Forms.frmPurchaseEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseEntry.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseEntry.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseEntry.Reset()
			MyProject.Forms.frmPurchaseEntry.ShowDialog()
			MyProject.Forms.frmPurchaseEntry.Dispose()
		End Sub

		' Token: 0x0600C950 RID: 51536 RVA: 0x007ED960 File Offset: 0x007EBB60
		Private Sub PurchaseReturnToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseReturn.Reset()
			MyProject.Forms.frmPurchaseReturn.ShowDialog()
			MyProject.Forms.frmPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600C951 RID: 51537 RVA: 0x007ED960 File Offset: 0x007EBB60
		Public Sub frmPurchaseReturn1()
			MyProject.Forms.frmPurchaseReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseReturn.Reset()
			MyProject.Forms.frmPurchaseReturn.ShowDialog()
			MyProject.Forms.frmPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600C952 RID: 51538 RVA: 0x007EDA00 File Offset: 0x007EBC00
		Private Sub QuotationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmQuotation.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmQuotation.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmQuotation.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmQuotation.Reset()
			MyProject.Forms.frmQuotation.ShowDialog()
			MyProject.Forms.frmQuotation.Dispose()
		End Sub

		' Token: 0x0600C953 RID: 51539 RVA: 0x007EDAA0 File Offset: 0x007EBCA0
		Public Sub frmQuotation1()
			Try
				MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmPOSNewTuch_Quotation.lblCPhone.Text = Me.lblCName.Text
				MyProject.Forms.frmPOSNewTuch_Quotation.Reset()
				MyProject.Forms.frmPOSNewTuch_Quotation.ShowDialog()
				MyProject.Forms.frmPOSNewTuch_Quotation.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C954 RID: 51540 RVA: 0x007EDB64 File Offset: 0x007EBD64
		Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseOrder.Reset()
			MyProject.Forms.frmPurchaseOrder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseOrder.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseOrder.ShowDialog()
			MyProject.Forms.frmPurchaseOrder.Dispose()
		End Sub

		' Token: 0x0600C955 RID: 51541 RVA: 0x007EDB64 File Offset: 0x007EBD64
		Public Sub frmPurchaseOrder1()
			MyProject.Forms.frmPurchaseOrder.Reset()
			MyProject.Forms.frmPurchaseOrder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseOrder.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseOrder.ShowDialog()
			MyProject.Forms.frmPurchaseOrder.Dispose()
		End Sub

		' Token: 0x0600C956 RID: 51542 RVA: 0x007EDBE4 File Offset: 0x007EBDE4
		Private Sub ReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCreditCustomerReceipt.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCreditCustomerReceipt.Reset()
			MyProject.Forms.frmCreditCustomerReceipt.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceipt.Dispose()
		End Sub

		' Token: 0x0600C957 RID: 51543 RVA: 0x007EDBE4 File Offset: 0x007EBDE4
		Public Sub frmCreditCustomerReceipt1()
			MyProject.Forms.frmCreditCustomerReceipt.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCreditCustomerReceipt.Reset()
			MyProject.Forms.frmCreditCustomerReceipt.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceipt.Dispose()
		End Sub

		' Token: 0x0600C958 RID: 51544 RVA: 0x007EDC84 File Offset: 0x007EBE84
		Private Sub PaymentToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
			MyProject.Forms.frmPayment.Dispose()
		End Sub

		' Token: 0x0600C959 RID: 51545 RVA: 0x007EDC84 File Offset: 0x007EBE84
		Public Sub frmPaymentx1()
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
			MyProject.Forms.frmPayment.Dispose()
		End Sub

		' Token: 0x0600C95A RID: 51546 RVA: 0x0049A3A4 File Offset: 0x004985A4
		Private Sub StockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.lblSet.Text = ""
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.ShowDialog()
			MyProject.Forms.frmCurrentStock.Dispose()
		End Sub

		' Token: 0x0600C95B RID: 51547 RVA: 0x0049A3A4 File Offset: 0x004985A4
		Public Sub frmCurrentStock1()
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.lblSet.Text = ""
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.ShowDialog()
			MyProject.Forms.frmCurrentStock.Dispose()
		End Sub

		' Token: 0x0600C95C RID: 51548 RVA: 0x007EDD04 File Offset: 0x007EBF04
		Private Sub CustomerToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomer.Label31.Text = Me.lblUserType.Text
			MyProject.Forms.frmCustomer.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.ShowDialog()
			MyProject.Forms.frmCustomer.Dispose()
		End Sub

		' Token: 0x0600C95D RID: 51549 RVA: 0x007EDD04 File Offset: 0x007EBF04
		Public Sub frmCustomer1()
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomer.Label31.Text = Me.lblUserType.Text
			MyProject.Forms.frmCustomer.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.ShowDialog()
			MyProject.Forms.frmCustomer.Dispose()
		End Sub

		' Token: 0x0600C95E RID: 51550 RVA: 0x006542C4 File Offset: 0x006524C4
		Private Sub PurchaseOrderToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.lblSet.Text = ""
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.ShowDialog()
			MyProject.Forms.frmPurchaseOrderRecord.Dispose()
		End Sub

		' Token: 0x0600C95F RID: 51551 RVA: 0x006542C4 File Offset: 0x006524C4
		Public Sub frmPurchaseOrderRecord1()
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.lblSet.Text = ""
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.ShowDialog()
			MyProject.Forms.frmPurchaseOrderRecord.Dispose()
		End Sub

		' Token: 0x0600C960 RID: 51552 RVA: 0x00525A7C File Offset: 0x00523C7C
		Private Sub ReceiptsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.lblSet.Text = ""
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceiptRecord.Dispose()
		End Sub

		' Token: 0x0600C961 RID: 51553 RVA: 0x00525A7C File Offset: 0x00523C7C
		Public Sub frmCreditCustomerReceiptRecord1()
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.lblSet.Text = ""
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceiptRecord.Dispose()
		End Sub

		' Token: 0x0600C962 RID: 51554 RVA: 0x00059B04 File Offset: 0x00057D04
		Private Sub SMSSeetingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSMSSetting.Reset()
			MyProject.Forms.frmSMSSetting.ShowDialog()
			MyProject.Forms.frmSMSSetting.Dispose()
		End Sub

		' Token: 0x0600C963 RID: 51555 RVA: 0x00059B04 File Offset: 0x00057D04
		Public Sub frmSMSSetting1()
			MyProject.Forms.frmSMSSetting.Reset()
			MyProject.Forms.frmSMSSetting.ShowDialog()
			MyProject.Forms.frmSMSSetting.Dispose()
		End Sub

		' Token: 0x0600C964 RID: 51556 RVA: 0x000388FF File Offset: 0x00036AFF
		Private Sub EmailSettingToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmailSetting.Reset()
			MyProject.Forms.frmEmailSetting.ShowDialog()
			MyProject.Forms.frmEmailSetting.Dispose()
		End Sub

		' Token: 0x0600C965 RID: 51557 RVA: 0x000388FF File Offset: 0x00036AFF
		Public Sub frmEmailSetting1()
			MyProject.Forms.frmEmailSetting.Reset()
			MyProject.Forms.frmEmailSetting.ShowDialog()
			MyProject.Forms.frmEmailSetting.Dispose()
		End Sub

		' Token: 0x0600C966 RID: 51558 RVA: 0x00059B37 File Offset: 0x00057D37
		Private Sub UserPermissionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmOtherSettings.Reset()
			MyProject.Forms.frmOtherSettings.ShowDialog()
			MyProject.Forms.frmOtherSettings.Dispose()
		End Sub

		' Token: 0x0600C967 RID: 51559 RVA: 0x00059B37 File Offset: 0x00057D37
		Public Sub frmOtherSettings1()
			MyProject.Forms.frmOtherSettings.Reset()
			MyProject.Forms.frmOtherSettings.ShowDialog()
			MyProject.Forms.frmOtherSettings.Dispose()
		End Sub

		' Token: 0x0600C968 RID: 51560 RVA: 0x00059B6A File Offset: 0x00057D6A
		Private Sub TerminalPrinterSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTerminalSetting.Reset()
			MyProject.Forms.frmTerminalSetting.ShowDialog()
			MyProject.Forms.frmTerminalSetting.Dispose()
		End Sub

		' Token: 0x0600C969 RID: 51561 RVA: 0x00059B6A File Offset: 0x00057D6A
		Public Sub frmTerminalSetting1()
			MyProject.Forms.frmTerminalSetting.Reset()
			MyProject.Forms.frmTerminalSetting.ShowDialog()
			MyProject.Forms.frmTerminalSetting.Dispose()
		End Sub

		' Token: 0x0600C96A RID: 51562 RVA: 0x007EDDB4 File Offset: 0x007EBFB4
		Private Sub SendSMSToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSendSMS_Sales.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSendSMS_Sales.Reset()
			MyProject.Forms.frmSendSMS_Sales.ShowDialog()
			MyProject.Forms.frmSendSMS_Sales.Dispose()
		End Sub

		' Token: 0x0600C96B RID: 51563 RVA: 0x007EDDB4 File Offset: 0x007EBFB4
		Public Sub frmSendSMS_Sales1()
			MyProject.Forms.frmSendSMS_Sales.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSendSMS_Sales.Reset()
			MyProject.Forms.frmSendSMS_Sales.ShowDialog()
			MyProject.Forms.frmSendSMS_Sales.Dispose()
		End Sub

		' Token: 0x0600C96C RID: 51564 RVA: 0x00059B9D File Offset: 0x00057D9D
		Private Sub SendEMailToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmailsender.ShowDialog()
			MyProject.Forms.frmEmailsender.Dispose()
		End Sub

		' Token: 0x0600C96D RID: 51565 RVA: 0x00059B9D File Offset: 0x00057D9D
		Public Sub frmEmailsender1()
			MyProject.Forms.frmEmailsender.ShowDialog()
			MyProject.Forms.frmEmailsender.Dispose()
		End Sub

		' Token: 0x0600C96E RID: 51566 RVA: 0x007EDE14 File Offset: 0x007EC014
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAbout.Label5.Text = "Remaining " + Strings.Format(Math.Round(New Decimal(Me.countdays)), "") + " Days"
			MyProject.Forms.frmAbout.Label3.Text = Me.regdto
			MyProject.Forms.frmAbout.Label4.Text = Strings.Format(Me.fdt, "dd-MM-yyyy")
			MyProject.Forms.frmAbout.ShowDialog()
			MyProject.Forms.frmAbout.Dispose()
		End Sub

		' Token: 0x0600C96F RID: 51567 RVA: 0x00525874 File Offset: 0x00523A74
		Private Sub StockAdjustmentToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockAdjustment_Store_Record.lblSet.Text = ""
			MyProject.Forms.frmStockAdjustment_Store_Record.Reset()
			MyProject.Forms.frmStockAdjustment_Store_Record.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store_Record.Dispose()
		End Sub

		' Token: 0x0600C970 RID: 51568 RVA: 0x00525874 File Offset: 0x00523A74
		Public Sub frmStockAdjustment_Store_Record1()
			MyProject.Forms.frmStockAdjustment_Store_Record.lblSet.Text = ""
			MyProject.Forms.frmStockAdjustment_Store_Record.Reset()
			MyProject.Forms.frmStockAdjustment_Store_Record.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store_Record.Dispose()
		End Sub

		' Token: 0x0600C971 RID: 51569 RVA: 0x007EDECC File Offset: 0x007EC0CC
		Private Sub StockEntryToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockEntry.Reset()
			MyProject.Forms.frmStockEntry.ShowDialog()
			MyProject.Forms.frmStockEntry.Dispose()
		End Sub

		' Token: 0x0600C972 RID: 51570 RVA: 0x007EDECC File Offset: 0x007EC0CC
		Public Sub frmStockEntry1()
			MyProject.Forms.frmStockEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockEntry.Reset()
			MyProject.Forms.frmStockEntry.ShowDialog()
			MyProject.Forms.frmStockEntry.Dispose()
		End Sub

		' Token: 0x0600C973 RID: 51571 RVA: 0x007EDF2C File Offset: 0x007EC12C
		Private Sub StockAdjustmentToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockAdjustment_Store.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockAdjustment_Store.Reset()
			MyProject.Forms.frmStockAdjustment_Store.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store.Dispose()
		End Sub

		' Token: 0x0600C974 RID: 51572 RVA: 0x007EDF2C File Offset: 0x007EC12C
		Public Sub frmStockAdjustment_Store1()
			MyProject.Forms.frmStockAdjustment_Store.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockAdjustment_Store.Reset()
			MyProject.Forms.frmStockAdjustment_Store.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store.Dispose()
		End Sub

		' Token: 0x0600C975 RID: 51573 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Timer3_Tick(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C976 RID: 51574 RVA: 0x007EDF8C File Offset: 0x007EC18C
		Private Sub OrderSearch()
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Me.strb.Clear()
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-order?"
					Me.strb.Append(text)
					Dim text2 As String = "pending"
					Me.strb.Append("type=" + text2)
					Dim text3 As String = Me.strb.ToString().Trim()
					Dim webRequest As WebRequest = WebRequest.Create(text3)
					Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
					httpWebRequest.Method = "GET"
					httpWebRequest.ContentType = "application/json"
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
						Dim text4 As String = streamReader.ReadToEnd()
						Dim bytes As Byte() = Encoding.UTF8.GetBytes(text4)
						Dim memoryStream As MemoryStream = New MemoryStream(bytes)
						Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(mOrder))
						Me.json = CType(dataContractJsonSerializer.ReadObject(memoryStream), mOrder)
						Dim success As Boolean = Me.json.success
						If success Then
							Dim num As Integer = Me.json.records.Count()
							Dim flag2 As Boolean = num > Me.countOrder_previous
							If flag2 Then
								Me.countOrder_previous = num
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Me.btnNotification.Visible = True
									Me.btnNotification.Text = "New Order Arrives(" + Conversions.ToString(num) + ")"
									NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "New Order Received " + Conversions.ToString(num) + ". Thank you" }, Nothing, Nothing, Nothing, True)
								Else
									Me.btnNotification.Visible = False
									Me.btnNotification.Text = "Notifications(0)"
								End If
							Else
								Dim flag4 As Boolean = num = 0
								If flag4 Then
									Me.btnNotification.Visible = False
									Me.btnNotification.Text = "Notifications(0)"
								End If
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x0600C977 RID: 51575 RVA: 0x00059BC0 File Offset: 0x00057DC0
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSystemInfo.ShowDialog()
			MyProject.Forms.frmSystemInfo.Dispose()
		End Sub

		' Token: 0x0600C978 RID: 51576 RVA: 0x007EE22C File Offset: 0x007EC42C
		Private Sub TaskManagerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Process.Start("TaskMgr.exe")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C979 RID: 51577 RVA: 0x007EE22C File Offset: 0x007EC42C
		Public Sub TaskManager1()
			Try
				Process.Start("TaskMgr.exe")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97A RID: 51578 RVA: 0x007EE27C File Offset: 0x007EC47C
		Private Sub WordToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Process.Start("Winword")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97B RID: 51579 RVA: 0x007EE27C File Offset: 0x007EC47C
		Public Sub Word1()
			Try
				Process.Start("Winword")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97C RID: 51580 RVA: 0x007EE2CC File Offset: 0x007EC4CC
		Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Process.Start("EXCEL.exe")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97D RID: 51581 RVA: 0x007EE2CC File Offset: 0x007EC4CC
		Public Sub Excel1()
			Try
				Process.Start("EXCEL.exe")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97E RID: 51582 RVA: 0x007EE31C File Offset: 0x007EC51C
		Private Sub OutlookToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Process.Start("OUTLOOK.exe")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C97F RID: 51583 RVA: 0x007EE31C File Offset: 0x007EC51C
		Public Sub Outlook1()
			Try
				Process.Start("OUTLOOK.exe")
			Catch ex As Exception
				MessageBox.Show("Microsoft Office is not installed in your computer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C980 RID: 51584 RVA: 0x007EE36C File Offset: 0x007EC56C
		Private Sub NotepadToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Process.Start("notepad.exe")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C981 RID: 51585 RVA: 0x007EE36C File Offset: 0x007EC56C
		Public Sub Notepad1()
			Try
				Process.Start("notepad.exe")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C982 RID: 51586 RVA: 0x00023290 File Offset: 0x00021490
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Interaction.Shell("C:\WINDOWS\system32\calc", AppWinStyle.MinimizedFocus, False, -1)
		End Sub

		' Token: 0x0600C983 RID: 51587 RVA: 0x007EE3BC File Offset: 0x007EC5BC
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmMainMenu.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmMainMenu.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x0600C984 RID: 51588 RVA: 0x00059BE3 File Offset: 0x00057DE3
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Calender.Show()
		End Sub

		' Token: 0x0600C985 RID: 51589 RVA: 0x00059BF6 File Offset: 0x00057DF6
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.GSTCalculator.Show()
		End Sub

		' Token: 0x0600C986 RID: 51590 RVA: 0x00059C09 File Offset: 0x00057E09
		Private Sub SaleInvoiceCodeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmInvCode.ShowDialog()
			MyProject.Forms.frmInvCode.Dispose()
		End Sub

		' Token: 0x0600C987 RID: 51591 RVA: 0x00059C09 File Offset: 0x00057E09
		Public Sub frmInvCode1()
			MyProject.Forms.frmInvCode.ShowDialog()
			MyProject.Forms.frmInvCode.Dispose()
		End Sub

		' Token: 0x0600C988 RID: 51592 RVA: 0x00059C2C File Offset: 0x00057E2C
		Private Sub AutoRoundoffToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAutoRoundoff.ShowDialog()
			MyProject.Forms.frmAutoRoundoff.Dispose()
		End Sub

		' Token: 0x0600C989 RID: 51593 RVA: 0x00059C2C File Offset: 0x00057E2C
		Public Sub frmAutoRoundoff1()
			MyProject.Forms.frmAutoRoundoff.ShowDialog()
			MyProject.Forms.frmAutoRoundoff.Dispose()
		End Sub

		' Token: 0x0600C98A RID: 51594 RVA: 0x00059C4F File Offset: 0x00057E4F
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Denomination.Show()
		End Sub

		' Token: 0x0600C98B RID: 51595 RVA: 0x00059C62 File Offset: 0x00057E62
		Private Sub Button8_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Cashrefund.Show()
		End Sub

		' Token: 0x0600C98C RID: 51596 RVA: 0x0026038C File Offset: 0x0025E58C
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmScreenlock.txtuser.Text = MyProject.Forms.frmLogin.UserID.Text
			Dim text As String = "Screen Locked"
			ModFunc.LogFunc(MyProject.Forms.frmLogin.UserID.Text, text)
			MyProject.Forms.frmScreenlock.ShowDialog()
			MyProject.Forms.frmScreenlock.Dispose()
		End Sub

		' Token: 0x17004FF3 RID: 20467
		' (get) Token: 0x0600C98D RID: 51597 RVA: 0x00059C75 File Offset: 0x00057E75
		' (set) Token: 0x0600C98E RID: 51598 RVA: 0x00059C7F File Offset: 0x00057E7F
		Public Property frmExpiryProduct As Object

		' Token: 0x0600C98F RID: 51599 RVA: 0x007EE404 File Offset: 0x007EC604
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(ID), RTRIM(CompanyName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(State), RTRIM(FYFrom), RTRIM(FYTo), RTRIM(AndroidID), RTRIM(CurSym) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.TextBox7.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.Label43.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.Label44.Text = "Address : " + ModCommonClasses.rdr.GetValue(2).ToString()
					Me.Label45.Text = "Contact : " + ModCommonClasses.rdr.GetValue(3).ToString()
					Me.Label46.Text = "Email : " + ModCommonClasses.rdr.GetValue(4).ToString()
					Me.Label47.Text = "GSTIN : " + ModCommonClasses.rdr.GetValue(5).ToString()
					Me.Label48.Text = "State : " + ModCommonClasses.rdr.GetValue(6).ToString()
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(7))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
					Me.fy1 = Me.DTP1.Value.[Date].ToString("dd-MM-yyyy")
					Me.fy2 = Me.DTP2.Value.[Date].ToString("dd-MM-yyyy")
					Me.AID = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.CurSym = NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(10), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
				Else
					Me.TextBox7.Text = ""
					Me.Label43.Text = ""
					Me.Label44.Text = ""
					Me.Label45.Text = ""
					Me.Label46.Text = ""
					Me.Label47.Text = ""
					Me.Label48.Text = ""
					Me.AID = ""
					Me.CurSym = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag3 As Boolean = Operators.CompareString(Me.AID, "Enabled", False) = 0
			If flag3 Then
				Me.Label17.Enabled = True
			Else
				Me.Label17.Enabled = False
			End If
		End Sub

		' Token: 0x0600C990 RID: 51600 RVA: 0x00059C8D File Offset: 0x00057E8D
		Private Sub AutoBackupToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAutobackup.ShowDialog()
			MyProject.Forms.frmAutobackup.Dispose()
		End Sub

		' Token: 0x0600C991 RID: 51601 RVA: 0x00059C8D File Offset: 0x00057E8D
		Public Sub frmAutobackup1()
			MyProject.Forms.frmAutobackup.ShowDialog()
			MyProject.Forms.frmAutobackup.Dispose()
		End Sub

		' Token: 0x0600C992 RID: 51602 RVA: 0x007EE754 File Offset: 0x007EC954
		Private Sub logo()
			Dim sqlCommand As SqlCommand = New SqlCommand("Select Logo from Company where id = @idn", ModCommonClasses.con)
			sqlCommand.Parameters.AddWithValue("@idn", Me.TextBox7.Text)
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count = 1
				If flag Then
					Dim array As Byte() = CType(dataTable.AsEnumerable().ElementAtOrDefault(0)(0), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.PictureBox1.Image = Image.FromStream(memoryStream)
				Else
					Me.PictureBox1.Image = Resources.Nologo
				End If
			Catch ex As Exception
				Me.PictureBox1.Image = Resources.Nologo
			End Try
		End Sub

		' Token: 0x0600C993 RID: 51603 RVA: 0x00059CB0 File Offset: 0x00057EB0
		Private Sub TermsAndConditionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTermsandCondn.ShowDialog()
			MyProject.Forms.frmTermsandCondn.Dispose()
		End Sub

		' Token: 0x0600C994 RID: 51604 RVA: 0x00059CB0 File Offset: 0x00057EB0
		Public Sub frmTermsandCondn1()
			MyProject.Forms.frmTermsandCondn.ShowDialog()
			MyProject.Forms.frmTermsandCondn.Dispose()
		End Sub

		' Token: 0x0600C995 RID: 51605 RVA: 0x007EE838 File Offset: 0x007ECA38
		Private Sub SaleRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Reset()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C996 RID: 51606 RVA: 0x007EE838 File Offset: 0x007ECA38
		Public Sub frmSalesInvoiceRecord_GSTR1()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Reset()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C997 RID: 51607 RVA: 0x007EE8A4 File Offset: 0x007ECAA4
		Private Sub PurchaseRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C998 RID: 51608 RVA: 0x007EE8A4 File Offset: 0x007ECAA4
		Public Sub frmPurchaseRecord_GSTR1()
			MyProject.Forms.frmPurchaseRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C999 RID: 51609 RVA: 0x007EE910 File Offset: 0x007ECB10
		Private Sub SalesReturnRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesReturnRecord_GSTR.Reset()
			MyProject.Forms.frmSalesReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C99A RID: 51610 RVA: 0x007EE910 File Offset: 0x007ECB10
		Public Sub frmSalesReturnRecord_GSTR1()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesReturnRecord_GSTR.Reset()
			MyProject.Forms.frmSalesReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C99B RID: 51611 RVA: 0x007EE964 File Offset: 0x007ECB64
		Private Sub PurchaseReturnRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C99C RID: 51612 RVA: 0x007EE964 File Offset: 0x007ECB64
		Public Sub frmPurchaseReturnRecord_GSTR11()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600C99D RID: 51613 RVA: 0x00059CD3 File Offset: 0x00057ED3
		Private Sub OutputTaxToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTCalc.Reset()
			MyProject.Forms.frmGSTCalc.ShowDialog()
			MyProject.Forms.frmGSTCalc.Dispose()
		End Sub

		' Token: 0x0600C99E RID: 51614 RVA: 0x00059CD3 File Offset: 0x00057ED3
		Public Sub frmGSTCalcx1()
			MyProject.Forms.frmGSTCalc.Reset()
			MyProject.Forms.frmGSTCalc.ShowDialog()
			MyProject.Forms.frmGSTCalc.Dispose()
		End Sub

		' Token: 0x0600C99F RID: 51615 RVA: 0x00059D06 File Offset: 0x00057F06
		Private Sub InputTaxToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTCalc1.Reset()
			MyProject.Forms.frmGSTCalc1.ShowDialog()
			MyProject.Forms.frmGSTCalc1.Dispose()
		End Sub

		' Token: 0x0600C9A0 RID: 51616 RVA: 0x00059D06 File Offset: 0x00057F06
		Public Sub frmGSTCalc11()
			MyProject.Forms.frmGSTCalc1.Reset()
			MyProject.Forms.frmGSTCalc1.ShowDialog()
			MyProject.Forms.frmGSTCalc1.Dispose()
		End Sub

		' Token: 0x0600C9A1 RID: 51617 RVA: 0x00059D39 File Offset: 0x00057F39
		Private Sub GSTR1ToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTR1.ShowDialog()
			MyProject.Forms.frmGSTR1.Dispose()
		End Sub

		' Token: 0x0600C9A2 RID: 51618 RVA: 0x00059D39 File Offset: 0x00057F39
		Public Sub frmGSTR11()
			MyProject.Forms.frmGSTR1.ShowDialog()
			MyProject.Forms.frmGSTR1.Dispose()
		End Sub

		' Token: 0x0600C9A3 RID: 51619 RVA: 0x00059D5C File Offset: 0x00057F5C
		Private Sub GSTR3BToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTR3B.ShowDialog()
			MyProject.Forms.frmGSTR3B.Dispose()
		End Sub

		' Token: 0x0600C9A4 RID: 51620 RVA: 0x00059D5C File Offset: 0x00057F5C
		Public Sub frmGSTR3B1()
			MyProject.Forms.frmGSTR3B.ShowDialog()
			MyProject.Forms.frmGSTR3B.Dispose()
		End Sub

		' Token: 0x0600C9A5 RID: 51621 RVA: 0x00059D7F File Offset: 0x00057F7F
		Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmVoucherRecord.Reset()
			MyProject.Forms.frmVoucherRecord.ShowDialog()
			MyProject.Forms.frmVoucherRecord.Dispose()
		End Sub

		' Token: 0x0600C9A6 RID: 51622 RVA: 0x00059D7F File Offset: 0x00057F7F
		Public Sub frmVoucherRecord1()
			MyProject.Forms.frmVoucherRecord.Reset()
			MyProject.Forms.frmVoucherRecord.ShowDialog()
			MyProject.Forms.frmVoucherRecord.Dispose()
		End Sub

		' Token: 0x0600C9A7 RID: 51623 RVA: 0x007EE9B8 File Offset: 0x007ECBB8
		Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmIncomeRecord.Reset()
			MyProject.Forms.frmIncomeRecord.Button2.Visible = False
			MyProject.Forms.frmIncomeRecord.ShowDialog()
			MyProject.Forms.frmIncomeRecord.Dispose()
		End Sub

		' Token: 0x0600C9A8 RID: 51624 RVA: 0x007EE9B8 File Offset: 0x007ECBB8
		Public Sub frmIncomeRecord1()
			MyProject.Forms.frmIncomeRecord.Reset()
			MyProject.Forms.frmIncomeRecord.Button2.Visible = False
			MyProject.Forms.frmIncomeRecord.ShowDialog()
			MyProject.Forms.frmIncomeRecord.Dispose()
		End Sub

		' Token: 0x0600C9A9 RID: 51625 RVA: 0x007EEA0C File Offset: 0x007ECC0C
		Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmIncomeRecord.Reset()
			MyProject.Forms.frmIncomeRecord.Panel4.Visible = False
			MyProject.Forms.frmIncomeRecord.ShowDialog()
			MyProject.Forms.frmIncomeRecord.Dispose()
		End Sub

		' Token: 0x0600C9AA RID: 51626 RVA: 0x007EEA0C File Offset: 0x007ECC0C
		Public Sub frmIncomeRecordx1()
			MyProject.Forms.frmIncomeRecord.Reset()
			MyProject.Forms.frmIncomeRecord.Panel4.Visible = False
			MyProject.Forms.frmIncomeRecord.ShowDialog()
			MyProject.Forms.frmIncomeRecord.Dispose()
		End Sub

		' Token: 0x0600C9AB RID: 51627 RVA: 0x007EEA60 File Offset: 0x007ECC60
		Public Sub Autobackupstatusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2, c3 FROM Autobackup"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(2).ToString()
				Else
					Me.TextBox1.Text = ""
					Me.TextBox2.Text = ""
					Me.TextBox3.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C9AC RID: 51628 RVA: 0x007EEBA4 File Offset: 0x007ECDA4
		Private Sub Chart()
			Me.Chart1.Series("Transaction").Points.Clear()
			Me.Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1.0
			Me.Chart1.Series("Transaction").Points.AddXY("Income", New Object() { Me.ax })
			Me.Chart1.Series("Transaction").Points.AddXY("Expenses", New Object() { Me.fx })
			Me.Chart1.Series("Transaction").Points.AddXY("Sale", New Object() { Me.bx })
			Me.Chart1.Series("Transaction").Points.AddXY("Sale Return", New Object() { Me.gx })
			Me.Chart1.Series("Transaction").Points.AddXY("Purchase", New Object() { Me.cx })
			Me.Chart1.Series("Transaction").Points.AddXY("Purchase Return", New Object() { Me.hx })
			Me.Chart1.Series("Transaction").Points.AddXY("Receipt", New Object() { Me.dx })
			Me.Chart1.Series("Transaction").Points.AddXY("Payment", New Object() { Me.ix })
			Me.Chart1.Series("Transaction").Points.AddXY("Service Bill", New Object() { Me.ex })
			Me.Chart1.Series("Transaction").Points.AddXY("Service Advance", New Object() { Me.jx })
		End Sub

		' Token: 0x0600C9AD RID: 51629 RVA: 0x00059DB2 File Offset: 0x00057FB2
		Private Sub GalleryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGallery.ShowDialog()
			MyProject.Forms.frmGallery.Dispose()
		End Sub

		' Token: 0x0600C9AE RID: 51630 RVA: 0x00059DD5 File Offset: 0x00057FD5
		Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.FormCamera.ShowDialog()
			MyProject.Forms.FormCamera.Dispose()
		End Sub

		' Token: 0x0600C9AF RID: 51631 RVA: 0x00059DD5 File Offset: 0x00057FD5
		Public Sub FormCamera1()
			MyProject.Forms.FormCamera.ShowDialog()
			MyProject.Forms.FormCamera.Dispose()
		End Sub

		' Token: 0x0600C9B0 RID: 51632 RVA: 0x00059DF8 File Offset: 0x00057FF8
		Private Sub SaleGSTReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxReport.Reset()
			MyProject.Forms.frmTaxReport.ShowDialog()
			MyProject.Forms.frmTaxReport.Dispose()
		End Sub

		' Token: 0x0600C9B1 RID: 51633 RVA: 0x00059DF8 File Offset: 0x00057FF8
		Public Sub frmTaxReport1()
			MyProject.Forms.frmTaxReport.Reset()
			MyProject.Forms.frmTaxReport.ShowDialog()
			MyProject.Forms.frmTaxReport.Dispose()
		End Sub

		' Token: 0x0600C9B2 RID: 51634 RVA: 0x00059E2B File Offset: 0x0005802B
		Private Sub Label52_Click(sender As Object, e As EventArgs)
			Process.Start("https://youtube.com/playlist?list=PLk8SDfuPj1bCNjCh4XedH4zhk4-uv3N4x")
		End Sub

		' Token: 0x0600C9B3 RID: 51635 RVA: 0x007EEE38 File Offset: 0x007ED038
		Private Sub UserRegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRegistration.Reset()
			MyProject.Forms.frmRegistration.ShowDialog()
			MyProject.Forms.frmRegistration.Dispose()
		End Sub

		' Token: 0x0600C9B4 RID: 51636 RVA: 0x007EEE38 File Offset: 0x007ED038
		Public Sub frmRegistration1()
			MyProject.Forms.frmRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRegistration.Reset()
			MyProject.Forms.frmRegistration.ShowDialog()
			MyProject.Forms.frmRegistration.Dispose()
		End Sub

		' Token: 0x0600C9B5 RID: 51637 RVA: 0x007EEE98 File Offset: 0x007ED098
		Private Sub CompanyDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCompanyDelete.Label2.Text = Me.lblUserType.Text
			MyProject.Forms.frmCompanyDelete.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmCompanyDelete.ShowDialog()
			MyProject.Forms.frmCompanyDelete.Dispose()
		End Sub

		' Token: 0x0600C9B6 RID: 51638 RVA: 0x007EEE98 File Offset: 0x007ED098
		Public Sub frmCompanyDelete1()
			MyProject.Forms.frmCompanyDelete.Label2.Text = Me.lblUserType.Text
			MyProject.Forms.frmCompanyDelete.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmCompanyDelete.ShowDialog()
			MyProject.Forms.frmCompanyDelete.Dispose()
		End Sub

		' Token: 0x0600C9B7 RID: 51639 RVA: 0x00059E39 File Offset: 0x00058039
		Private Sub Chartclear()
			Me.Chart1.Series("Transaction").Points.Clear()
		End Sub

		' Token: 0x0600C9B8 RID: 51640 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button10_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9B9 RID: 51641 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button11_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9BA RID: 51642 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button12_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9BB RID: 51643 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button13_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9BC RID: 51644 RVA: 0x007EDD04 File Offset: 0x007EBF04
		Private Sub Button14_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomer.Label31.Text = Me.lblUserType.Text
			MyProject.Forms.frmCustomer.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.ShowDialog()
			MyProject.Forms.frmCustomer.Dispose()
		End Sub

		' Token: 0x0600C9BD RID: 51645 RVA: 0x007ECCF8 File Offset: 0x007EAEF8
		Private Sub Button15_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplier.Label31.Text = Me.lblUserType.Text
			MyProject.Forms.frmSupplier.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x0600C9BE RID: 51646 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button16_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9BF RID: 51647 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button17_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C9C0 RID: 51648 RVA: 0x000432E7 File Offset: 0x000414E7
		Private Sub DashBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBalancesheet.ShowDialog()
			MyProject.Forms.frmBalancesheet.Dispose()
		End Sub

		' Token: 0x0600C9C1 RID: 51649 RVA: 0x000432E7 File Offset: 0x000414E7
		Public Sub frmBalancesheet1()
			MyProject.Forms.frmBalancesheet.ShowDialog()
			MyProject.Forms.frmBalancesheet.Dispose()
		End Sub

		' Token: 0x0600C9C2 RID: 51650 RVA: 0x0004330A File Offset: 0x0004150A
		Private Sub BalanceSheetToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.BalanceSheetForm.ShowDialog()
			MyProject.Forms.BalanceSheetForm.Dispose()
		End Sub

		' Token: 0x0600C9C3 RID: 51651 RVA: 0x0004330A File Offset: 0x0004150A
		Public Sub BalanceSheetForm1()
			MyProject.Forms.BalanceSheetForm.ShowDialog()
			MyProject.Forms.BalanceSheetForm.Dispose()
		End Sub

		' Token: 0x0600C9C4 RID: 51652 RVA: 0x0004332D File Offset: 0x0004152D
		Private Sub ProfitAndLossToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProfitloss.ShowDialog()
			MyProject.Forms.frmProfitloss.Dispose()
		End Sub

		' Token: 0x0600C9C5 RID: 51653 RVA: 0x0004332D File Offset: 0x0004152D
		Public Sub frmProfitloss1()
			MyProject.Forms.frmProfitloss.ShowDialog()
			MyProject.Forms.frmProfitloss.Dispose()
		End Sub

		' Token: 0x0600C9C6 RID: 51654 RVA: 0x00043350 File Offset: 0x00041550
		Private Sub TrialBalanceToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmTrialBalance.Reset()
			MyProject.Forms.frmTrialBalance.ShowDialog()
			MyProject.Forms.frmTrialBalance.Dispose()
		End Sub

		' Token: 0x0600C9C7 RID: 51655 RVA: 0x0003854A File Offset: 0x0003674A
		Private Sub GeneralLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGeneralLedger.Reset()
			MyProject.Forms.frmGeneralLedger.ShowDialog()
			MyProject.Forms.frmGeneralLedger.Dispose()
		End Sub

		' Token: 0x0600C9C8 RID: 51656 RVA: 0x0003854A File Offset: 0x0003674A
		Public Sub frmGeneralLedger1()
			MyProject.Forms.frmGeneralLedger.Reset()
			MyProject.Forms.frmGeneralLedger.ShowDialog()
			MyProject.Forms.frmGeneralLedger.Dispose()
		End Sub

		' Token: 0x0600C9C9 RID: 51657 RVA: 0x0003857D File Offset: 0x0003677D
		Private Sub DayBookToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGeneralDayBook.Reset()
			MyProject.Forms.frmGeneralDayBook.ShowDialog()
			MyProject.Forms.frmGeneralDayBook.Dispose()
		End Sub

		' Token: 0x0600C9CA RID: 51658 RVA: 0x0003857D File Offset: 0x0003677D
		Public Sub frmGeneralDayBook1()
			MyProject.Forms.frmGeneralDayBook.Reset()
			MyProject.Forms.frmGeneralDayBook.ShowDialog()
			MyProject.Forms.frmGeneralDayBook.Dispose()
		End Sub

		' Token: 0x0600C9CB RID: 51659 RVA: 0x00043383 File Offset: 0x00041583
		Private Sub SupplierLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierLedger.Reset()
			MyProject.Forms.frmSupplierLedger.ShowDialog()
			MyProject.Forms.frmSupplierLedger.Dispose()
		End Sub

		' Token: 0x0600C9CC RID: 51660 RVA: 0x00043383 File Offset: 0x00041583
		Public Sub frmSupplierLedger1()
			MyProject.Forms.frmSupplierLedger.Reset()
			MyProject.Forms.frmSupplierLedger.ShowDialog()
			MyProject.Forms.frmSupplierLedger.Dispose()
		End Sub

		' Token: 0x0600C9CD RID: 51661 RVA: 0x0003848E File Offset: 0x0003668E
		Private Sub CustomerLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerLedger.Reset()
			MyProject.Forms.frmCustomerLedger.ShowDialog()
			MyProject.Forms.frmCustomerLedger.Dispose()
		End Sub

		' Token: 0x0600C9CE RID: 51662 RVA: 0x0003848E File Offset: 0x0003668E
		Public Sub frmCustomerLedger1()
			MyProject.Forms.frmCustomerLedger.Reset()
			MyProject.Forms.frmCustomerLedger.ShowDialog()
			MyProject.Forms.frmCustomerLedger.Dispose()
		End Sub

		' Token: 0x0600C9CF RID: 51663 RVA: 0x000384C1 File Offset: 0x000366C1
		Private Sub SalesmanLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanLedgerNew.Reset()
			MyProject.Forms.frmSalesmanLedgerNew.ShowDialog()
			MyProject.Forms.frmSalesmanLedgerNew.Dispose()
		End Sub

		' Token: 0x0600C9D0 RID: 51664 RVA: 0x000384C1 File Offset: 0x000366C1
		Public Sub frmSalesmanLedgerNew1()
			MyProject.Forms.frmSalesmanLedgerNew.Reset()
			MyProject.Forms.frmSalesmanLedgerNew.ShowDialog()
			MyProject.Forms.frmSalesmanLedgerNew.Dispose()
		End Sub

		' Token: 0x0600C9D1 RID: 51665 RVA: 0x000385D3 File Offset: 0x000367D3
		Private Sub SalesmanCommissionToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanCommmissionReport.Reset()
			MyProject.Forms.frmSalesmanCommmissionReport.ShowDialog()
			MyProject.Forms.frmSalesmanCommmissionReport.Dispose()
		End Sub

		' Token: 0x0600C9D2 RID: 51666 RVA: 0x000385D3 File Offset: 0x000367D3
		Public Sub frmSalesmanCommmissionReport1()
			MyProject.Forms.frmSalesmanCommmissionReport.Reset()
			MyProject.Forms.frmSalesmanCommmissionReport.ShowDialog()
			MyProject.Forms.frmSalesmanCommmissionReport.Dispose()
		End Sub

		' Token: 0x0600C9D3 RID: 51667 RVA: 0x00038527 File Offset: 0x00036727
		Private Sub CashBookToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCashLedger.ShowDialog()
			MyProject.Forms.frmCashLedger.Dispose()
		End Sub

		' Token: 0x0600C9D4 RID: 51668 RVA: 0x00038527 File Offset: 0x00036727
		Public Sub frmCashLedger1()
			MyProject.Forms.frmCashLedger.ShowDialog()
			MyProject.Forms.frmCashLedger.Dispose()
		End Sub

		' Token: 0x0600C9D5 RID: 51669 RVA: 0x000385B0 File Offset: 0x000367B0
		Private Sub BankBalanceBookToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBankLedger.ShowDialog()
			MyProject.Forms.frmBankLedger.Dispose()
		End Sub

		' Token: 0x0600C9D6 RID: 51670 RVA: 0x000385B0 File Offset: 0x000367B0
		Public Sub frmBankLedger1()
			MyProject.Forms.frmBankLedger.ShowDialog()
			MyProject.Forms.frmBankLedger.Dispose()
		End Sub

		' Token: 0x0600C9D7 RID: 51671 RVA: 0x007EEF08 File Offset: 0x007ED108
		Private Sub frmMainMenu_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.F1
			If flag Then
				e.Handled = True
				Me.Button10.PerformClick()
			End If
			Dim flag2 As Boolean = e.KeyCode = Keys.F2
			If flag2 Then
				e.Handled = True
				Me.Button11.PerformClick()
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F3
			If flag3 Then
				e.Handled = True
				Me.Button12.PerformClick()
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.F4
			If flag4 Then
				e.Handled = True
				Me.Button13.PerformClick()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.F5
			If flag5 Then
				e.Handled = True
				Me.Button14.PerformClick()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.F6
			If flag6 Then
				e.Handled = True
				Me.Button15.PerformClick()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.F7
			If flag7 Then
				e.Handled = True
				Me.Button16.PerformClick()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.F8
			If flag8 Then
				e.Handled = True
				Me.Button17.PerformClick()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.Escape
			If flag9 Then
				e.Handled = True
				Me.btnAT0.PerformClick()
			End If
		End Sub

		' Token: 0x0600C9D8 RID: 51672 RVA: 0x007EF064 File Offset: 0x007ED264
		Private Sub Label3_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Dim enabled As Boolean = Me.Label3.Enabled
			If enabled Then
				Me.ToolTip1.SetToolTip(Me.Label3, "Auto Backup Activated")
			Else
				Me.ToolTip1.SetToolTip(Me.Label3, "Auto Backup Deactivated")
			End If
		End Sub

		' Token: 0x0600C9D9 RID: 51673 RVA: 0x007EF0E0 File Offset: 0x007ED2E0
		Private Sub Label6_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label6, Me.Label49.Text)
		End Sub

		' Token: 0x0600C9DA RID: 51674 RVA: 0x007EF138 File Offset: 0x007ED338
		Private Sub Label7_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label7, "Internet Connected")
		End Sub

		' Token: 0x0600C9DB RID: 51675 RVA: 0x007EF188 File Offset: 0x007ED388
		Private Sub internetcheck()
			Try
				Dim webClient As WebClient = New WebClient()
				webClient.OpenRead("http://www.google.com")
				Me.Label7.Enabled = True
			Catch ex As Exception
				Me.Label7.Enabled = False
			End Try
		End Sub

		' Token: 0x0600C9DC RID: 51676 RVA: 0x007EF1E8 File Offset: 0x007ED3E8
		Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)
			Thread.Sleep(1000)
			Dim isAvailable As Boolean = MyProject.Computer.Network.IsAvailable
			If isAvailable Then
				Me.internetStatus = True
			Else
				Me.internetStatus = False
			End If
		End Sub

		' Token: 0x0600C9DD RID: 51677 RVA: 0x007EF228 File Offset: 0x007ED428
		Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
			Dim flag As Boolean = Me.internetStatus
			If flag Then
				Me.Label7.Enabled = True
			Else
				Me.Label7.Enabled = False
			End If
			Me.BackgroundWorker1.RunWorkerAsync()
		End Sub

		' Token: 0x0600C9DE RID: 51678 RVA: 0x007EF26C File Offset: 0x007ED46C
		Private Sub emailstatuscheck()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select IsDefault from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label8.Enabled = True
				Else
					Me.Label8.Enabled = False
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C9DF RID: 51679 RVA: 0x007EF330 File Offset: 0x007ED530
		Private Sub Label8_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label8, "Email Setting Configured")
		End Sub

		' Token: 0x0600C9E0 RID: 51680 RVA: 0x007EF380 File Offset: 0x007ED580
		Private Sub smsstatuscheck()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select IsDefault from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.Label9.Enabled = True
				Else
					Me.Label9.Enabled = False
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C9E1 RID: 51681 RVA: 0x007EF444 File Offset: 0x007ED644
		Private Sub Label9_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label9, "SMS Setting Configured")
		End Sub

		' Token: 0x0600C9E2 RID: 51682 RVA: 0x007EF494 File Offset: 0x007ED694
		Private Sub RouteToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmRoute.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRoute.Reset()
			MyProject.Forms.frmRoute.ShowDialog()
			MyProject.Forms.frmRoute.Dispose()
		End Sub

		' Token: 0x0600C9E3 RID: 51683 RVA: 0x007EF494 File Offset: 0x007ED694
		Public Sub frmRoute1()
			MyProject.Forms.frmRoute.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRoute.Reset()
			MyProject.Forms.frmRoute.ShowDialog()
			MyProject.Forms.frmRoute.Dispose()
		End Sub

		' Token: 0x0600C9E4 RID: 51684 RVA: 0x00059E5C File Offset: 0x0005805C
		Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmVirtualCompany.ShowDialog()
			MyProject.Forms.frmVirtualCompany.Dispose()
		End Sub

		' Token: 0x0600C9E5 RID: 51685 RVA: 0x00059E5C File Offset: 0x0005805C
		Public Sub frmVirtualCompany1()
			MyProject.Forms.frmVirtualCompany.ShowDialog()
			MyProject.Forms.frmVirtualCompany.Dispose()
		End Sub

		' Token: 0x0600C9E6 RID: 51686 RVA: 0x007EF4F4 File Offset: 0x007ED6F4
		Private Sub TransporterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTransport.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTransport.clear()
			MyProject.Forms.frmTransport.ShowDialog()
			MyProject.Forms.frmTransport.Dispose()
		End Sub

		' Token: 0x0600C9E7 RID: 51687 RVA: 0x007EF4F4 File Offset: 0x007ED6F4
		Public Sub frmTransport1()
			MyProject.Forms.frmTransport.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTransport.clear()
			MyProject.Forms.frmTransport.ShowDialog()
			MyProject.Forms.frmTransport.Dispose()
		End Sub

		' Token: 0x0600C9E8 RID: 51688 RVA: 0x007EF554 File Offset: 0x007ED754
		Private Sub DamageProductManagementToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmDamageProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmDamageProduct.ShowDialog()
			MyProject.Forms.frmDamageProduct.Dispose()
		End Sub

		' Token: 0x0600C9E9 RID: 51689 RVA: 0x007EF554 File Offset: 0x007ED754
		Public Sub frmDamageProduct1()
			MyProject.Forms.frmDamageProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmDamageProduct.ShowDialog()
			MyProject.Forms.frmDamageProduct.Dispose()
		End Sub

		' Token: 0x0600C9EA RID: 51690 RVA: 0x007EF5A4 File Offset: 0x007ED7A4
		Private Sub TaxCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTaxCategory.ShowDialog()
			MyProject.Forms.frmTaxCategory.Dispose()
		End Sub

		' Token: 0x0600C9EB RID: 51691 RVA: 0x007EF5A4 File Offset: 0x007ED7A4
		Public Sub frmTaxCategory1()
			MyProject.Forms.frmTaxCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTaxCategory.ShowDialog()
			MyProject.Forms.frmTaxCategory.Dispose()
		End Sub

		' Token: 0x0600C9EC RID: 51692 RVA: 0x000232DA File Offset: 0x000214DA
		Private Sub TaxTypeSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxSetting.Reset()
			MyProject.Forms.frmTaxSetting.ShowDialog()
			MyProject.Forms.frmTaxSetting.Dispose()
		End Sub

		' Token: 0x0600C9ED RID: 51693 RVA: 0x000232DA File Offset: 0x000214DA
		Public Sub frmTaxSetting1()
			MyProject.Forms.frmTaxSetting.Reset()
			MyProject.Forms.frmTaxSetting.ShowDialog()
			MyProject.Forms.frmTaxSetting.Dispose()
		End Sub

		' Token: 0x0600C9EE RID: 51694 RVA: 0x007EF5F4 File Offset: 0x007ED7F4
		Private Async Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
			End If
			MyProject.Forms.frmWAppAPIServer.ShowDialog()
			MyProject.Forms.frmWAppAPIServer.Dispose()
		End Sub

		' Token: 0x0600C9EF RID: 51695 RVA: 0x00525DD4 File Offset: 0x00523FD4
		Public Sub frmWAppAPIServer1()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
			End If
			MyProject.Forms.frmWAppAPIServer.ShowDialog()
			MyProject.Forms.frmWAppAPIServer.Dispose()
		End Sub

		' Token: 0x0600C9F0 RID: 51696 RVA: 0x00059E7F File Offset: 0x0005807F
		Private Sub QRBarcodeReaderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.QRGenerator.ShowDialog()
			MyProject.Forms.QRGenerator.Dispose()
		End Sub

		' Token: 0x0600C9F1 RID: 51697 RVA: 0x00059E7F File Offset: 0x0005807F
		Public Sub QRGenerator1()
			MyProject.Forms.QRGenerator.ShowDialog()
			MyProject.Forms.QRGenerator.Dispose()
		End Sub

		' Token: 0x0600C9F2 RID: 51698 RVA: 0x007EF63C File Offset: 0x007ED83C
		Private Sub SalesManToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Salesman.Reset()
				MyProject.Forms.frmExportImportExcel_Salesman.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C9F3 RID: 51699 RVA: 0x007EF63C File Offset: 0x007ED83C
		Public Sub frmExportImportExcel_Salesman1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Salesman.Reset()
				MyProject.Forms.frmExportImportExcel_Salesman.ShowDialog()
			End If
		End Sub

		' Token: 0x0600C9F4 RID: 51700 RVA: 0x000388A6 File Offset: 0x00036AA6
		Private Sub SalesmanBulkEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanBulkUpdate.ShowDialog()
			MyProject.Forms.frmSalesmanBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600C9F5 RID: 51701 RVA: 0x000388A6 File Offset: 0x00036AA6
		Public Sub frmSalesmanBulkUpdate1()
			MyProject.Forms.frmSalesmanBulkUpdate.ShowDialog()
			MyProject.Forms.frmSalesmanBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600C9F6 RID: 51702 RVA: 0x007EF6A0 File Offset: 0x007ED8A0
		Private Sub EmployeeRegistrationToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmployeeRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEmployeeRegistration.ShowDialog()
			MyProject.Forms.frmEmployeeRegistration.Dispose()
		End Sub

		' Token: 0x0600C9F7 RID: 51703 RVA: 0x007EF6A0 File Offset: 0x007ED8A0
		Public Sub frmEmployeeRegistration1()
			MyProject.Forms.frmEmployeeRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEmployeeRegistration.ShowDialog()
			MyProject.Forms.frmEmployeeRegistration.Dispose()
		End Sub

		' Token: 0x0600C9F8 RID: 51704 RVA: 0x007EF6F0 File Offset: 0x007ED8F0
		Private Sub EmployeeAttendanceToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAttendance.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAttendance.ShowDialog()
			MyProject.Forms.frmAttendance.Dispose()
		End Sub

		' Token: 0x0600C9F9 RID: 51705 RVA: 0x007EF6F0 File Offset: 0x007ED8F0
		Public Sub frmAttendance1()
			MyProject.Forms.frmAttendance.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAttendance.ShowDialog()
			MyProject.Forms.frmAttendance.Dispose()
		End Sub

		' Token: 0x0600C9FA RID: 51706 RVA: 0x007EF740 File Offset: 0x007ED940
		Private Sub AdvancePaymentEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAdvanceEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAdvanceEntry.ShowDialog()
			MyProject.Forms.frmAdvanceEntry.Dispose()
		End Sub

		' Token: 0x0600C9FB RID: 51707 RVA: 0x007EF740 File Offset: 0x007ED940
		Public Sub frmAdvanceEntry1()
			MyProject.Forms.frmAdvanceEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAdvanceEntry.ShowDialog()
			MyProject.Forms.frmAdvanceEntry.Dispose()
		End Sub

		' Token: 0x0600C9FC RID: 51708 RVA: 0x007EF790 File Offset: 0x007ED990
		Private Sub EmployeePaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmployeePayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEmployeePayment.ShowDialog()
			MyProject.Forms.frmEmployeePayment.Dispose()
		End Sub

		' Token: 0x0600C9FD RID: 51709 RVA: 0x007EF790 File Offset: 0x007ED990
		Public Sub frmEmployeePayment1()
			MyProject.Forms.frmEmployeePayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEmployeePayment.ShowDialog()
			MyProject.Forms.frmEmployeePayment.Dispose()
		End Sub

		' Token: 0x0600C9FE RID: 51710 RVA: 0x00059EA2 File Offset: 0x000580A2
		Private Sub SalarySlipToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalaryslip.ShowDialog()
			MyProject.Forms.frmSalaryslip.Dispose()
		End Sub

		' Token: 0x0600C9FF RID: 51711 RVA: 0x00059EA2 File Offset: 0x000580A2
		Public Sub frmSalaryslip1()
			MyProject.Forms.frmSalaryslip.ShowDialog()
			MyProject.Forms.frmSalaryslip.Dispose()
		End Sub

		' Token: 0x0600CA00 RID: 51712 RVA: 0x00059EC5 File Offset: 0x000580C5
		Private Sub SalarySlipsReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalarySlipsReport.ShowDialog()
			MyProject.Forms.frmSalarySlipsReport.Dispose()
		End Sub

		' Token: 0x0600CA01 RID: 51713 RVA: 0x00059EC5 File Offset: 0x000580C5
		Public Sub frmSalarySlipsReport1()
			MyProject.Forms.frmSalarySlipsReport.ShowDialog()
			MyProject.Forms.frmSalarySlipsReport.Dispose()
		End Sub

		' Token: 0x0600CA02 RID: 51714 RVA: 0x00059EE8 File Offset: 0x000580E8
		Private Sub AdvancePaymentReportToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAdvanceEntryReport.ShowDialog()
			MyProject.Forms.frmAdvanceEntryReport.Dispose()
		End Sub

		' Token: 0x0600CA03 RID: 51715 RVA: 0x00059EE8 File Offset: 0x000580E8
		Public Sub frmAdvanceEntryReport1()
			MyProject.Forms.frmAdvanceEntryReport.ShowDialog()
			MyProject.Forms.frmAdvanceEntryReport.Dispose()
		End Sub

		' Token: 0x0600CA04 RID: 51716 RVA: 0x00059F0B File Offset: 0x0005810B
		Private Sub DeductionReportToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmDeductionReport.ShowDialog()
			MyProject.Forms.frmDeductionReport.Dispose()
		End Sub

		' Token: 0x0600CA05 RID: 51717 RVA: 0x00059F0B File Offset: 0x0005810B
		Public Sub frmDeductionReport1()
			MyProject.Forms.frmDeductionReport.ShowDialog()
			MyProject.Forms.frmDeductionReport.Dispose()
		End Sub

		' Token: 0x0600CA06 RID: 51718 RVA: 0x007EF7E0 File Offset: 0x007ED9E0
		Private Sub ManualContactListToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmContacts.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmContacts.Reset()
			MyProject.Forms.frmContacts.ShowDialog()
			MyProject.Forms.frmContacts.Dispose()
		End Sub

		' Token: 0x0600CA07 RID: 51719 RVA: 0x007EF7E0 File Offset: 0x007ED9E0
		Public Sub frmContacts1()
			MyProject.Forms.frmContacts.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmContacts.Reset()
			MyProject.Forms.frmContacts.ShowDialog()
			MyProject.Forms.frmContacts.Dispose()
		End Sub

		' Token: 0x0600CA08 RID: 51720 RVA: 0x00059F2E File Offset: 0x0005812E
		Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLanChat.Show()
		End Sub

		' Token: 0x0600CA09 RID: 51721 RVA: 0x00059F2E File Offset: 0x0005812E
		Public Sub frmLanChat1()
			MyProject.Forms.frmLanChat.Show()
		End Sub

		' Token: 0x0600CA0A RID: 51722 RVA: 0x007EF840 File Offset: 0x007EDA40
		Private Sub CloudDataManagementToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					MyProject.Forms.FrmGDClientSample.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.FrmGDClientSample.txtDB.Text = Me.txtDB.Text
					MyProject.Forms.FrmGDClientSample.ShowDialog()
					MyProject.Forms.FrmGDClientSample.Dispose()
				End If
			End If
		End Sub

		' Token: 0x0600CA0B RID: 51723 RVA: 0x007EF840 File Offset: 0x007EDA40
		Public Sub FrmGDClientSample1()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					MyProject.Forms.FrmGDClientSample.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.FrmGDClientSample.txtDB.Text = Me.txtDB.Text
					MyProject.Forms.FrmGDClientSample.ShowDialog()
					MyProject.Forms.FrmGDClientSample.Dispose()
				End If
			End If
		End Sub

		' Token: 0x0600CA0C RID: 51724 RVA: 0x00525780 File Offset: 0x00523980
		Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label1.Text = "Sales Dashboard"
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Reset()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA0D RID: 51725 RVA: 0x00525780 File Offset: 0x00523980
		Public Sub frmSalesInvoiceRecord_GSTRx1()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Label1.Text = "Sales Dashboard"
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Reset()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA0E RID: 51726 RVA: 0x006540F0 File Offset: 0x006522F0
		Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmPurchaseRecord_GSTR.Label1.Text = "Purchase Dashboard"
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA0F RID: 51727 RVA: 0x006540F0 File Offset: 0x006522F0
		Public Sub sufrmPurchaseRecord_GSTR1()
			MyProject.Forms.frmPurchaseRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmPurchaseRecord_GSTR.Label1.Text = "Purchase Dashboard"
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA10 RID: 51728 RVA: 0x00059F41 File Offset: 0x00058141
		Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWapp2CrCustomer.ShowDialog()
			MyProject.Forms.frmBulkWapp2CrCustomer.Dispose()
		End Sub

		' Token: 0x0600CA11 RID: 51729 RVA: 0x00059F41 File Offset: 0x00058141
		Public Sub frmBulkWapp2CrCustomer1()
			MyProject.Forms.frmBulkWapp2CrCustomer.ShowDialog()
			MyProject.Forms.frmBulkWapp2CrCustomer.Dispose()
		End Sub

		' Token: 0x0600CA12 RID: 51730 RVA: 0x00059F64 File Offset: 0x00058164
		Private Sub SaleReturnBillWiseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.GSTSaleReturn.ShowDialog()
			MyProject.Forms.GSTSaleReturn.Dispose()
		End Sub

		' Token: 0x0600CA13 RID: 51731 RVA: 0x00059F64 File Offset: 0x00058164
		Public Sub GSTSaleReturn1()
			MyProject.Forms.GSTSaleReturn.ShowDialog()
			MyProject.Forms.GSTSaleReturn.Dispose()
		End Sub

		' Token: 0x0600CA14 RID: 51732 RVA: 0x00059F87 File Offset: 0x00058187
		Private Sub PurchaseReturnBillWiseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.GSTPurchaseReturn.ShowDialog()
			MyProject.Forms.GSTPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600CA15 RID: 51733 RVA: 0x00059F87 File Offset: 0x00058187
		Public Sub GSTPurchaseReturn1()
			MyProject.Forms.GSTPurchaseReturn.ShowDialog()
			MyProject.Forms.GSTPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600CA16 RID: 51734 RVA: 0x00525804 File Offset: 0x00523A04
		Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesReturnRecord_GSTR.Label1.Text = "Sales Return Dashboard"
			MyProject.Forms.frmSalesReturnRecord_GSTR.Reset()
			MyProject.Forms.frmSalesReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA17 RID: 51735 RVA: 0x00525804 File Offset: 0x00523A04
		Public Sub frmSalesReturnRecord_GSTRx1()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmSalesReturnRecord_GSTR.Label1.Text = "Sales Return Dashboard"
			MyProject.Forms.frmSalesReturnRecord_GSTR.Reset()
			MyProject.Forms.frmSalesReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA18 RID: 51736 RVA: 0x00654174 File Offset: 0x00652374
		Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Label1.Text = "Purchase Return Dashboard"
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA19 RID: 51737 RVA: 0x00654174 File Offset: 0x00652374
		Public Sub frmPurchaseReturnRecord_GSTR1()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Label1.Text = "Purchase Return Dashboard"
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600CA1A RID: 51738 RVA: 0x000386E5 File Offset: 0x000368E5
		Private Sub StockMovementToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockMovementReport.Reset()
			MyProject.Forms.frmStockMovementReport.ShowDialog()
		End Sub

		' Token: 0x0600CA1B RID: 51739 RVA: 0x000386E5 File Offset: 0x000368E5
		Public Sub frmStockMovementReport1()
			MyProject.Forms.frmStockMovementReport.Reset()
			MyProject.Forms.frmStockMovementReport.ShowDialog()
		End Sub

		' Token: 0x0600CA1C RID: 51740 RVA: 0x007EF908 File Offset: 0x007EDB08
		Private Sub Timer4_Tick(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.lblScroll.Right = 0
			If flag Then
				Me.lblScroll.Left = MyBase.Width
			Else
				Dim lblScroll As Label = Me.lblScroll
				Dim label As Label = lblScroll
				lblScroll.Left = label.Left - 1
			End If
		End Sub

		' Token: 0x0600CA1D RID: 51741 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Timer5_Tick(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA1E RID: 51742 RVA: 0x00010F3E File Offset: 0x0000F13E
		Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x0600CA1F RID: 51743 RVA: 0x00010F3E File Offset: 0x0000F13E
		Public Sub frmBulkWhatsappDoc1()
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x0600CA20 RID: 51744 RVA: 0x00059FAA File Offset: 0x000581AA
		Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmExpDashboard.ShowDialog()
		End Sub

		' Token: 0x0600CA21 RID: 51745 RVA: 0x00059FAA File Offset: 0x000581AA
		Public Sub frmExpDashboard1()
			MyProject.Forms.frmExpDashboard.ShowDialog()
		End Sub

		' Token: 0x0600CA22 RID: 51746 RVA: 0x000387A1 File Offset: 0x000369A1
		Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmIncomeDashboard.ShowDialog()
		End Sub

		' Token: 0x0600CA23 RID: 51747 RVA: 0x000387A1 File Offset: 0x000369A1
		Public Sub frmIncomeDashboard1()
			MyProject.Forms.frmIncomeDashboard.ShowDialog()
		End Sub

		' Token: 0x0600CA24 RID: 51748 RVA: 0x00059FBD File Offset: 0x000581BD
		Private Sub SalesRegisterDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTDetails.ShowDialog()
		End Sub

		' Token: 0x0600CA25 RID: 51749 RVA: 0x00059FBD File Offset: 0x000581BD
		Public Sub frmGSTDetails1()
			MyProject.Forms.frmGSTDetails.ShowDialog()
		End Sub

		' Token: 0x0600CA26 RID: 51750 RVA: 0x00059FD0 File Offset: 0x000581D0
		Private Sub PurchaseRegisterItemWiseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTDetailsPur.ShowDialog()
		End Sub

		' Token: 0x0600CA27 RID: 51751 RVA: 0x00059FD0 File Offset: 0x000581D0
		Public Sub frmGSTDetailsPur1()
			MyProject.Forms.frmGSTDetailsPur.ShowDialog()
		End Sub

		' Token: 0x0600CA28 RID: 51752 RVA: 0x00059FE3 File Offset: 0x000581E3
		Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUPIQRCodeImg.ShowDialog()
		End Sub

		' Token: 0x0600CA29 RID: 51753 RVA: 0x00059FE3 File Offset: 0x000581E3
		Public Sub frmUPIQRCodeImg1()
			MyProject.Forms.frmUPIQRCodeImg.ShowDialog()
		End Sub

		' Token: 0x0600CA2A RID: 51754 RVA: 0x00059FF6 File Offset: 0x000581F6
		Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMultiBranchReport.ShowDialog()
		End Sub

		' Token: 0x0600CA2B RID: 51755 RVA: 0x00059FF6 File Offset: 0x000581F6
		Public Sub frmMultiBranchReport1()
			MyProject.Forms.frmMultiBranchReport.ShowDialog()
		End Sub

		' Token: 0x0600CA2C RID: 51756 RVA: 0x007EF958 File Offset: 0x007EDB58
		Private Sub PointOfSaleToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSTouch.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSTouch.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSTouch.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOSTouch.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPOSTouch.Reset()
			MyProject.Forms.frmPOSTouch.ShowDialog()
			MyProject.Forms.frmPOSTouch.Dispose()
		End Sub

		' Token: 0x0600CA2D RID: 51757 RVA: 0x007EFA18 File Offset: 0x007EDC18
		Private Sub ProductOrderSectionToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmKitchen_Section.Reset()
			MyProject.Forms.frmKitchen_Section.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmKitchen_Section.ShowDialog()
			MyProject.Forms.frmKitchen_Section.Dispose()
		End Sub

		' Token: 0x0600CA2E RID: 51758 RVA: 0x007EFA18 File Offset: 0x007EDC18
		Public Sub frmKitchen_Section1()
			MyProject.Forms.frmKitchen_Section.Reset()
			MyProject.Forms.frmKitchen_Section.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmKitchen_Section.ShowDialog()
			MyProject.Forms.frmKitchen_Section.Dispose()
		End Sub

		' Token: 0x0600CA2F RID: 51759 RVA: 0x007EFA78 File Offset: 0x007EDC78
		Private Sub CustomerCouponManagementToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCouponGenerate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCouponGenerate.ShowDialog()
			MyProject.Forms.frmCouponGenerate.Dispose()
		End Sub

		' Token: 0x0600CA30 RID: 51760 RVA: 0x007EFA78 File Offset: 0x007EDC78
		Public Sub frmCouponGenerate1()
			MyProject.Forms.frmCouponGenerate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCouponGenerate.ShowDialog()
			MyProject.Forms.frmCouponGenerate.Dispose()
		End Sub

		' Token: 0x0600CA31 RID: 51761 RVA: 0x007EFAC8 File Offset: 0x007EDCC8
		Private Sub ContraVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmContra.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmContra.ShowDialog()
			MyProject.Forms.frmContra.Dispose()
		End Sub

		' Token: 0x0600CA32 RID: 51762 RVA: 0x007EFAC8 File Offset: 0x007EDCC8
		Public Sub frmContra1()
			MyProject.Forms.frmContra.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmContra.ShowDialog()
			MyProject.Forms.frmContra.Dispose()
		End Sub

		' Token: 0x0600CA33 RID: 51763 RVA: 0x007EFB18 File Offset: 0x007EDD18
		Private Sub Label18_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label18, "WhatsApp : Ready")
		End Sub

		' Token: 0x0600CA34 RID: 51764 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub ExpiredProductMenuItem_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA35 RID: 51765 RVA: 0x007EFB68 File Offset: 0x007EDD68
		Private Sub Label17_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) <> 0
			If flag Then
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Process.Start("https://drive.google.com/file/d/1pVEYnCGIZkV0UrISTVGQpkNp-EXIhykR/view?usp=sharing")
				End If
			End If
		End Sub

		' Token: 0x0600CA36 RID: 51766 RVA: 0x0005A009 File Offset: 0x00058209
		Private Sub CustomerOfferMessageToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmOfferMessage.ShowDialog()
			MyProject.Forms.frmOfferMessage.Dispose()
		End Sub

		' Token: 0x0600CA37 RID: 51767 RVA: 0x0005A009 File Offset: 0x00058209
		Public Sub frmOfferMessage1()
			MyProject.Forms.frmOfferMessage.ShowDialog()
			MyProject.Forms.frmOfferMessage.Dispose()
		End Sub

		' Token: 0x0600CA38 RID: 51768 RVA: 0x0005A02C File Offset: 0x0005822C
		Private Sub CustomerMobileApkSenderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerMobileAppSender.ShowDialog()
			MyProject.Forms.frmCustomerMobileAppSender.Dispose()
		End Sub

		' Token: 0x0600CA39 RID: 51769 RVA: 0x0005A02C File Offset: 0x0005822C
		Public Sub frmCustomerMobileAppSender1()
			MyProject.Forms.frmCustomerMobileAppSender.ShowDialog()
			MyProject.Forms.frmCustomerMobileAppSender.Dispose()
		End Sub

		' Token: 0x0600CA3A RID: 51770 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA3B RID: 51771 RVA: 0x007EFBAC File Offset: 0x007EDDAC
		Public Sub PhonePe1()
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
			End If
		End Sub

		' Token: 0x0600CA3C RID: 51772 RVA: 0x007EFBDC File Offset: 0x007EDDDC
		Private Sub CustomerGiftOfferValidationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGift.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGift.ShowDialog()
			MyProject.Forms.frmGift.Dispose()
		End Sub

		' Token: 0x0600CA3D RID: 51773 RVA: 0x007EFBDC File Offset: 0x007EDDDC
		Public Sub frmGift1()
			MyProject.Forms.frmGift.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGift.ShowDialog()
			MyProject.Forms.frmGift.Dispose()
		End Sub

		' Token: 0x0600CA3E RID: 51774 RVA: 0x0003881A File Offset: 0x00036A1A
		Private Sub ToolStripMenuItem29_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGiftCodeSender.ShowDialog()
			MyProject.Forms.frmGiftCodeSender.Dispose()
		End Sub

		' Token: 0x0600CA3F RID: 51775 RVA: 0x0003881A File Offset: 0x00036A1A
		Public Sub frmGiftCodeSender1()
			MyProject.Forms.frmGiftCodeSender.ShowDialog()
			MyProject.Forms.frmGiftCodeSender.Dispose()
		End Sub

		' Token: 0x0600CA40 RID: 51776 RVA: 0x007EFC2C File Offset: 0x007EDE2C
		Public Sub InitializeWhatsApp()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim flag2 As Boolean = ModFunc.CheckGoogleChromeInstalledVersion() <> Nothing
				If flag2 Then
					Me.Timer7.Enabled = True
					Try
						frmMainMenu.whatsApp1.Initialize(New Config() With { .HideCommandPromptWindow = True, .Headless = True })
					Catch ex As Exception
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600CA41 RID: 51777 RVA: 0x007EFCAC File Offset: 0x007EDEAC
		Public Async Sub LogOut1()
			Dim flag As Boolean = Operators.CompareString(Me.LblEngine1.Text, "WhatsApp : Ready", False) = 0
			If flag Then
				Try
					Await frmMainMenu.whatsApp1.Destroy()
				Catch ex As Exception
					MessageBox.Show(ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x0600CA42 RID: 51778 RVA: 0x007EFCE8 File Offset: 0x007EDEE8
		Private Sub btnAT0_Click(sender As Object, e As EventArgs)
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("MoneyLeaf")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("MoneyLeaf")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\MoneyLeaf.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Try
				Dim processesByName2 As Process() = Process.GetProcessesByName("RECEIPT_PRINTER")
				For Each process2 As Process In processesByName2
					process2.Kill()
				Next
				Dim flag3 As Boolean = Me.ProcessRunning("RECEIPT_PRINTER")
				If flag3 Then
					Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\RECEIPT_PRINTER.exe"
					Dim flag4 As Boolean = File.Exists(text2)
					If flag4 Then
						File.Delete(text2)
					End If
				End If
			Catch ex2 As Exception
			End Try
			Try
				Dim flag5 As Boolean = MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag5 Then
					Dim flag6 As Boolean = ModFunc.CheckForInternetConnection()
					If flag6 Then
						Dim flag7 As Boolean = Operators.CompareString(Me.TextBox3.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) = 0
						If flag7 Then
							Me.gDClient = New Global.GDClient.GDClient()
							Me.cloudbackup_anil()
							Me.autoBackup_anil_offline()
						Else
							Dim flag8 As Boolean = Operators.CompareString(Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) = 0
							If flag8 Then
								Me.autoBackup_anil_offline()
							End If
						End If
					Else
						Dim flag9 As Boolean = Operators.CompareString(Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString(), "Enabled", False) = 0
						If flag9 Then
							Dim flag10 As Boolean = MessageBox.Show("Do you want take offline backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
							If flag10 Then
								Me.autoBackup_anil_offline()
							End If
						End If
					End If
					Me.LogOut()
				End If
			Catch ex3 As Exception
				MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CA43 RID: 51779 RVA: 0x007EFF98 File Offset: 0x007EE198
		Public Sub cloudbackup_anil()
			Dim text As String = "D:\SBPE_DATA"
			Dim flag As Boolean = Directory.Exists(text)
			If flag Then
				For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
					File.Delete(text2)
				Next
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Me.autoBackup_anil()
					Try
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim flag3 As Boolean = Me.gDClient Is Nothing
						If flag3 Then
							MessageBox.Show("gDClient is not initialized. Cannot proceed with backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.Cursor = Cursors.[Default]
						Else
							Dim gddata As GDData = Me.gDClient.BackupData(text)
							Dim flag4 As Boolean = gddata IsNot Nothing AndAlso gddata.Id <> Nothing
							If flag4 Then
								MessageBox.Show("Successfully Backed Up, File ID : " + gddata.Id.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Else
								MessageBox.Show("Backup failed. The returned data is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
							For Each text3 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
								File.Delete(text3)
							Next
						End If
					Catch ex As Exception
						MessageBox.Show("An error occurred during backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Finally
						Me.Cursor = Cursors.[Default]
					End Try
				Else
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Else
				MessageBox.Show("Directory does not exist: " + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600CA44 RID: 51780 RVA: 0x007E7EA0 File Offset: 0x007E60A0
		Public Sub autoBackup_anil()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Me.Filename = "D:\SBPE_DATA\" + Me.stX + ".bak"
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					File.Delete(text)
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text2 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CA45 RID: 51781 RVA: 0x007F0190 File Offset: 0x007EE390
		Public Sub autoBackup_anil_offline()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Me.Filename = Me.TextBox1.Text + "\" + Me.stX + ".bak"
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					File.Delete(text)
				Else
					Dim directoryName As String = Path.GetDirectoryName(Me.Filename)
					Dim flag2 As Boolean = Not Directory.Exists(directoryName)
					If flag2 Then
						Directory.CreateDirectory(directoryName)
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text2 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CA46 RID: 51782 RVA: 0x007F0300 File Offset: 0x007EE500
		Private Sub Button16_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSmart.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProductSmart.ShowDialog()
			MyProject.Forms.frmProductSmart.Dispose()
		End Sub

		' Token: 0x0600CA47 RID: 51783 RVA: 0x007F0350 File Offset: 0x007EE550
		Public Sub frmProductRec1()
			MyProject.Forms.frmProductRec.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProductRec.ShowDialog()
			MyProject.Forms.frmProductRec.Dispose()
		End Sub

		' Token: 0x0600CA48 RID: 51784 RVA: 0x007F03A0 File Offset: 0x007EE5A0
		Private Sub Button10_Click_1(sender As Object, e As EventArgs)
			Try
				Me.frmPOSTouch1()
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600CA49 RID: 51785 RVA: 0x007F03E8 File Offset: 0x007EE5E8
		Public Sub frmPOSTouch1()
			Try
				MyProject.Forms.frmPOSTouch.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSTouch.TextBox10.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSTouch.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmPOSTouch.lblCPhone.Text = Me.lblCName.Text
				MyProject.Forms.frmPOSTouch.Reset()
				MyProject.Forms.frmPOSTouch.ShowDialog()
				MyProject.Forms.frmPOSTouch.Dispose()
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600CA4A RID: 51786 RVA: 0x007ED8C0 File Offset: 0x007EBAC0
		Private Sub Button11_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseEntry.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseEntry.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseEntry.Reset()
			MyProject.Forms.frmPurchaseEntry.ShowDialog()
			MyProject.Forms.frmPurchaseEntry.Dispose()
		End Sub

		' Token: 0x0600CA4B RID: 51787 RVA: 0x007EDBE4 File Offset: 0x007EBDE4
		Private Sub Button12_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmCreditCustomerReceipt.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmCreditCustomerReceipt.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmCreditCustomerReceipt.Reset()
			MyProject.Forms.frmCreditCustomerReceipt.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceipt.Dispose()
		End Sub

		' Token: 0x0600CA4C RID: 51788 RVA: 0x007ED820 File Offset: 0x007EBA20
		Private Sub btnSaleReturn_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmSalesReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSalesReturn.Reset()
			MyProject.Forms.frmSalesReturn.ShowDialog()
			MyProject.Forms.frmSalesReturn.Dispose()
		End Sub

		' Token: 0x0600CA4D RID: 51789 RVA: 0x007ED960 File Offset: 0x007EBB60
		Private Sub btnPurchaseReturn_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseReturn.Reset()
			MyProject.Forms.frmPurchaseReturn.ShowDialog()
			MyProject.Forms.frmPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600CA4E RID: 51790 RVA: 0x007F04D8 File Offset: 0x007EE6D8
		Private Sub Button17_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmVoucher.Reset()
			MyProject.Forms.frmVoucher.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmVoucher.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmVoucher.ShowDialog()
			MyProject.Forms.frmVoucher.Dispose()
		End Sub

		' Token: 0x0600CA4F RID: 51791 RVA: 0x007EDC84 File Offset: 0x007EBE84
		Private Sub Button13_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
			MyProject.Forms.frmPayment.Dispose()
		End Sub

		' Token: 0x0600CA50 RID: 51792 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BWChrome_DoWork(sender As Object, e As DoWorkEventArgs)
		End Sub

		' Token: 0x0600CA51 RID: 51793 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BWChrome_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
		End Sub

		' Token: 0x0600CA52 RID: 51794 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub tChrome_Tick(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA53 RID: 51795 RVA: 0x007F0558 File Offset: 0x007EE758
		Private Sub ComboPackToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmComboPack.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmComboPack.ShowDialog()
			MyProject.Forms.frmComboPack.Dispose()
		End Sub

		' Token: 0x0600CA54 RID: 51796 RVA: 0x007F0558 File Offset: 0x007EE758
		Public Sub frmComboPack1()
			MyProject.Forms.frmComboPack.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmComboPack.ShowDialog()
			MyProject.Forms.frmComboPack.Dispose()
		End Sub

		' Token: 0x0600CA55 RID: 51797 RVA: 0x007F05A8 File Offset: 0x007EE7A8
		Private Sub ComboPackMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmComboPackMaster.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmComboPackMaster.Reset()
			MyProject.Forms.frmComboPackMaster.ShowDialog()
			MyProject.Forms.frmComboPackMaster.Dispose()
		End Sub

		' Token: 0x0600CA56 RID: 51798 RVA: 0x007F05A8 File Offset: 0x007EE7A8
		Public Sub frmComboPackMaster1()
			MyProject.Forms.frmComboPackMaster.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmComboPackMaster.Reset()
			MyProject.Forms.frmComboPackMaster.ShowDialog()
			MyProject.Forms.frmComboPackMaster.Dispose()
		End Sub

		' Token: 0x0600CA57 RID: 51799 RVA: 0x007F0608 File Offset: 0x007EE808
		Private Sub ProductDiscountSetToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductDiscount.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProductDiscount.ShowDialog()
			MyProject.Forms.frmProductDiscount.Dispose()
		End Sub

		' Token: 0x0600CA58 RID: 51800 RVA: 0x007F0608 File Offset: 0x007EE808
		Public Sub frmProductDiscount1()
			MyProject.Forms.frmProductDiscount.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProductDiscount.ShowDialog()
			MyProject.Forms.frmProductDiscount.Dispose()
		End Sub

		' Token: 0x0600CA59 RID: 51801 RVA: 0x007F0658 File Offset: 0x007EE858
		Private Sub JournalVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmRefundAmt.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRefundAmt.ShowDialog()
			MyProject.Forms.frmRefundAmt.Dispose()
		End Sub

		' Token: 0x0600CA5A RID: 51802 RVA: 0x007F0658 File Offset: 0x007EE858
		Public Sub frmRefundAmt1()
			MyProject.Forms.frmRefundAmt.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRefundAmt.ShowDialog()
			MyProject.Forms.frmRefundAmt.Dispose()
		End Sub

		' Token: 0x0600CA5B RID: 51803 RVA: 0x0005A04F File Offset: 0x0005824F
		Private Sub EToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEMain.ShowDialog()
		End Sub

		' Token: 0x0600CA5C RID: 51804 RVA: 0x0005A04F File Offset: 0x0005824F
		Public Sub frmEMain1()
			MyProject.Forms.frmEMain.ShowDialog()
		End Sub

		' Token: 0x0600CA5D RID: 51805 RVA: 0x0005A062 File Offset: 0x00058262
		Private Sub ExpiryProductToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.btnGetData.ShowDialog()
		End Sub

		' Token: 0x0600CA5E RID: 51806 RVA: 0x0005A062 File Offset: 0x00058262
		Public Sub btnGetData1()
			MyProject.Forms.btnGetData.ShowDialog()
		End Sub

		' Token: 0x0600CA5F RID: 51807 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA60 RID: 51808 RVA: 0x007F06A8 File Offset: 0x007EE8A8
		Private Sub UpdatePostToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPostImport.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPostImport.ShowDialog()
			MyProject.Forms.frmPostImport.Dispose()
		End Sub

		' Token: 0x0600CA61 RID: 51809 RVA: 0x007F06A8 File Offset: 0x007EE8A8
		Public Sub frmPostImport1()
			MyProject.Forms.frmPostImport.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPostImport.ShowDialog()
			MyProject.Forms.frmPostImport.Dispose()
		End Sub

		' Token: 0x0600CA62 RID: 51810 RVA: 0x007F06F8 File Offset: 0x007EE8F8
		Private Sub TransferProductToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockTransfer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockTransfer.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStockTransfer.ShowDialog()
			MyProject.Forms.frmStockTransfer.Dispose()
		End Sub

		' Token: 0x0600CA63 RID: 51811 RVA: 0x007F06F8 File Offset: 0x007EE8F8
		Public Sub frmStockTransfer1()
			MyProject.Forms.frmStockTransfer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockTransfer.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStockTransfer.ShowDialog()
			MyProject.Forms.frmStockTransfer.Dispose()
		End Sub

		' Token: 0x0600CA64 RID: 51812 RVA: 0x007F0768 File Offset: 0x007EE968
		Private Sub BranchAdminToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmScreenlock.txtuser.Text = "sadmin"
			MyProject.Forms.frmScreenlock.Label2.Text = "Security Checked"
			MyProject.Forms.frmScreenlock.ShowDialog()
			MyProject.Forms.frmScreenlock.Dispose()
			MyProject.Forms.frmBranchAdmin.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBranchAdmin.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmBranchAdmin.ShowDialog()
			MyProject.Forms.frmBranchAdmin.Dispose()
		End Sub

		' Token: 0x0600CA65 RID: 51813 RVA: 0x007F0768 File Offset: 0x007EE968
		Public Sub frmBranchAdmin1()
			MyProject.Forms.frmScreenlock.txtuser.Text = "sadmin"
			MyProject.Forms.frmScreenlock.Label2.Text = "Security Checked"
			MyProject.Forms.frmScreenlock.ShowDialog()
			MyProject.Forms.frmScreenlock.Dispose()
			MyProject.Forms.frmBranchAdmin.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBranchAdmin.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmBranchAdmin.ShowDialog()
			MyProject.Forms.frmBranchAdmin.Dispose()
		End Sub

		' Token: 0x0600CA66 RID: 51814 RVA: 0x0005A075 File Offset: 0x00058275
		Private Sub TokenSendToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTokenOut.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenOut.ShowDialog()
		End Sub

		' Token: 0x0600CA67 RID: 51815 RVA: 0x0005A075 File Offset: 0x00058275
		Public Sub frmTokenOut1()
			MyProject.Forms.frmTokenOut.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenOut.ShowDialog()
		End Sub

		' Token: 0x0600CA68 RID: 51816 RVA: 0x0005A0A8 File Offset: 0x000582A8
		Private Sub TokenInToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTokenIn.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenIn.ShowDialog()
		End Sub

		' Token: 0x0600CA69 RID: 51817 RVA: 0x0005A0A8 File Offset: 0x000582A8
		Public Sub frmTokenIn1()
			MyProject.Forms.frmTokenIn.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenIn.ShowDialog()
		End Sub

		' Token: 0x0600CA6A RID: 51818 RVA: 0x007F082C File Offset: 0x007EEA2C
		Private Sub TokenSeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTokenSettlement.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenSettlement.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTokenSettlement.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmTokenSettlement.ShowDialog()
		End Sub

		' Token: 0x0600CA6B RID: 51819 RVA: 0x007F082C File Offset: 0x007EEA2C
		Public Sub frmTokenSettlement1()
			MyProject.Forms.frmTokenSettlement.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmTokenSettlement.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTokenSettlement.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmTokenSettlement.ShowDialog()
		End Sub

		' Token: 0x0600CA6C RID: 51820 RVA: 0x0005A0DB File Offset: 0x000582DB
		Private Sub CreateBanarToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBanarCreate.ShowDialog()
		End Sub

		' Token: 0x0600CA6D RID: 51821 RVA: 0x0005A0DB File Offset: 0x000582DB
		Public Sub frmBanarCreate1()
			MyProject.Forms.frmBanarCreate.ShowDialog()
		End Sub

		' Token: 0x0600CA6E RID: 51822 RVA: 0x007F08AC File Offset: 0x007EEAAC
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = Path.Combine(MyProject.Application.Info.DirectoryPath, "expReports\report.pdf")
			Dim text2 As String = text.Replace(".pdf", ".png")
			Dim pdfFocus As PdfFocus = New PdfFocus()
			pdfFocus.OpenPdf(text)
			Dim flag As Boolean = pdfFocus.PageCount > 0
			If flag Then
				pdfFocus.ImageOptions.Dpi = 300
				Dim text3 As String = text.Replace(".pdf", ".tiff")
				pdfFocus.ToMultipageTiff(text3)
			End If
		End Sub

		' Token: 0x0600CA6F RID: 51823 RVA: 0x0005A0EE File Offset: 0x000582EE
		Private Sub ComboPackBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmComboPackBarcode.ShowDialog()
			MyProject.Forms.frmComboPackBarcode.Dispose()
		End Sub

		' Token: 0x0600CA70 RID: 51824 RVA: 0x0005A0EE File Offset: 0x000582EE
		Public Sub frmComboPackBarcode1()
			MyProject.Forms.frmComboPackBarcode.ShowDialog()
			MyProject.Forms.frmComboPackBarcode.Dispose()
		End Sub

		' Token: 0x0600CA71 RID: 51825 RVA: 0x007F0934 File Offset: 0x007EEB34
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmPOSNewTuch.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSNewTuch.TextBox10.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSNewTuch.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmPOSNewTuch.lblCPhone.Text = Me.lblCName.Text
				MyProject.Forms.frmPOSNewTuch.Reset()
				MyProject.Forms.frmPOSNewTuch.ShowDialog()
				MyProject.Forms.frmPOSNewTuch.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CA72 RID: 51826 RVA: 0x007F0934 File Offset: 0x007EEB34
		Public Sub frmPOSNewTuch1()
			Try
				MyProject.Forms.frmPOSNewTuch.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSNewTuch.TextBox10.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSNewTuch.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmPOSNewTuch.lblCPhone.Text = Me.lblCName.Text
				MyProject.Forms.frmPOSNewTuch.Reset()
				MyProject.Forms.frmPOSNewTuch.ShowDialog()
				MyProject.Forms.frmPOSNewTuch.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CA73 RID: 51827 RVA: 0x007F0A18 File Offset: 0x007EEC18
		Public Sub frmPOSNewTuch_StockTransfer1()
			MyProject.Forms.frmPOSNewTuch_StockTransfer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSNewTuch_StockTransfer.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSNewTuch_StockTransfer.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOSNewTuch_StockTransfer.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPOSNewTuch_StockTransfer.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmPOSNewTuch_StockTransfer.Reset()
			MyProject.Forms.frmPOSNewTuch_StockTransfer.ShowDialog()
			MyProject.Forms.frmPOSNewTuch_StockTransfer.Dispose()
		End Sub

		' Token: 0x0600CA74 RID: 51828 RVA: 0x007F0AF8 File Offset: 0x007EECF8
		Public Sub frmPOSNewTuch_Service1()
			MyProject.Forms.frmPOSNewTuch_Service.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSNewTuch_Service.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmPOSNewTuch_Service.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPOSNewTuch_Service.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPOSNewTuch_Service.Reset()
			MyProject.Forms.frmPOSNewTuch_Service.ShowDialog()
			MyProject.Forms.frmPOSNewTuch_Service.Dispose()
		End Sub

		' Token: 0x0600CA75 RID: 51829 RVA: 0x007F0BB8 File Offset: 0x007EEDB8
		Private Sub SalesManPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesManPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesManPayment.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesManPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSalesManPayment.Reset()
			MyProject.Forms.frmSalesManPayment.ShowDialog()
			MyProject.Forms.frmSalesManPayment.Dispose()
		End Sub

		' Token: 0x0600CA76 RID: 51830 RVA: 0x007F0BB8 File Offset: 0x007EEDB8
		Public Sub frmSalesManPayment1()
			MyProject.Forms.frmSalesManPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesManPayment.TextBox10.Text = Me.lblUser.Text
			MyProject.Forms.frmSalesManPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmSalesManPayment.Reset()
			MyProject.Forms.frmSalesManPayment.ShowDialog()
			MyProject.Forms.frmSalesManPayment.Dispose()
		End Sub

		' Token: 0x0600CA77 RID: 51831 RVA: 0x0005A111 File Offset: 0x00058311
		Private Sub BarcodeToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeMain.ShowDialog()
		End Sub

		' Token: 0x0600CA78 RID: 51832 RVA: 0x0005A111 File Offset: 0x00058311
		Public Sub frmBarcodeMain1()
			MyProject.Forms.frmBarcodeMain.ShowDialog()
		End Sub

		' Token: 0x0600CA79 RID: 51833 RVA: 0x0005A124 File Offset: 0x00058324
		Private Sub BarcodePrintToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeLabelPrintingnew.Reset()
			MyProject.Forms.frmBarcodeLabelPrintingnew.ShowDialog()
			MyProject.Forms.frmBarcodeLabelPrintingnew.Dispose()
		End Sub

		' Token: 0x0600CA7A RID: 51834 RVA: 0x0005A124 File Offset: 0x00058324
		Public Sub frmBarcodeLabelPrintingnew1()
			MyProject.Forms.frmBarcodeLabelPrintingnew.Reset()
			MyProject.Forms.frmBarcodeLabelPrintingnew.ShowDialog()
			MyProject.Forms.frmBarcodeLabelPrintingnew.Dispose()
		End Sub

		' Token: 0x0600CA7B RID: 51835 RVA: 0x0005A157 File Offset: 0x00058357
		Private Sub Test1ToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTestnew.ShowDialog()
		End Sub

		' Token: 0x0600CA7C RID: 51836 RVA: 0x0005A157 File Offset: 0x00058357
		Public Sub frmTestnew1()
			MyProject.Forms.frmTestnew.ShowDialog()
		End Sub

		' Token: 0x0600CA7D RID: 51837 RVA: 0x007ECE38 File Offset: 0x007EB038
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProduct.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmProduct.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmProduct.Reset()
			MyProject.Forms.frmProduct.ShowDialog()
			MyProject.Forms.frmProduct.Dispose()
		End Sub

		' Token: 0x0600CA7E RID: 51838 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub ContactToolStripMenuItem1_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CA7F RID: 51839 RVA: 0x007EC420 File Offset: 0x007EA620
		Private Sub LogActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLogs.Reset()
			MyProject.Forms.frmLogs.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLogs.ShowDialog()
		End Sub

		' Token: 0x0600CA80 RID: 51840 RVA: 0x0005A16A File Offset: 0x0005836A
		Private Sub UserControlToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUserControl.ShowDialog()
			MyProject.Forms.frmUserControl.Dispose()
		End Sub

		' Token: 0x0600CA81 RID: 51841 RVA: 0x0005A16A File Offset: 0x0005836A
		Public Sub frmUserControl1()
			MyProject.Forms.frmUserControl.ShowDialog()
			MyProject.Forms.frmUserControl.Dispose()
		End Sub

		' Token: 0x0600CA82 RID: 51842 RVA: 0x0005A18D File Offset: 0x0005838D
		Public Sub frmUserMenu_Control1()
			MyProject.Forms.frmUserMenu_Control.ShowDialog()
			MyProject.Forms.frmUserMenu_Control.Dispose()
		End Sub

		' Token: 0x0600CA83 RID: 51843 RVA: 0x00059FF6 File Offset: 0x000581F6
		Private Sub MultiBranchReportDashboardToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMultiBranchReport.ShowDialog()
		End Sub

		' Token: 0x0600CA84 RID: 51844 RVA: 0x007F0C58 File Offset: 0x007EEE58
		Private Sub ReminderRecordToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminderRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminderRecord.ShowDialog()
			MyProject.Forms.frmReminderRecord.Dispose()
		End Sub

		' Token: 0x0600CA85 RID: 51845 RVA: 0x007F0C58 File Offset: 0x007EEE58
		Public Sub frmReminderRecord1()
			MyProject.Forms.frmReminderRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminderRecord.ShowDialog()
			MyProject.Forms.frmReminderRecord.Dispose()
		End Sub

		' Token: 0x0600CA86 RID: 51846 RVA: 0x007EEE38 File Offset: 0x007ED038
		Private Sub UserRegistrationToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmRegistration.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmRegistration.Reset()
			MyProject.Forms.frmRegistration.ShowDialog()
			MyProject.Forms.frmRegistration.Dispose()
		End Sub

		' Token: 0x0600CA87 RID: 51847 RVA: 0x007EEE98 File Offset: 0x007ED098
		Private Sub DeleteCompanyToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCompanyDelete.Label2.Text = Me.lblUserType.Text
			MyProject.Forms.frmCompanyDelete.txtDB.Text = Me.txtDB.Text
			MyProject.Forms.frmCompanyDelete.ShowDialog()
			MyProject.Forms.frmCompanyDelete.Dispose()
		End Sub

		' Token: 0x0600CA88 RID: 51848 RVA: 0x007F0CA8 File Offset: 0x007EEEA8
		Private Sub FinancialYearChangeToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmFYChange.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFYChange.ShowDialog()
			MyProject.Forms.frmFYChange.Dispose()
		End Sub

		' Token: 0x0600CA89 RID: 51849 RVA: 0x007F0CA8 File Offset: 0x007EEEA8
		Public Sub frmFYChange1()
			MyProject.Forms.frmFYChange.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFYChange.ShowDialog()
			MyProject.Forms.frmFYChange.Dispose()
		End Sub

		' Token: 0x0600CA8A RID: 51850 RVA: 0x0005A1B0 File Offset: 0x000583B0
		Private Sub MRPUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMRP_Purchase_Update.ShowDialog()
		End Sub

		' Token: 0x0600CA8B RID: 51851 RVA: 0x0005A1B0 File Offset: 0x000583B0
		Public Sub frmMRP_Purchase_Update1()
			MyProject.Forms.frmMRP_Purchase_Update.ShowDialog()
		End Sub

		' Token: 0x0600CA8C RID: 51852 RVA: 0x0005A1B0 File Offset: 0x000583B0
		Private Sub PurchaseBillMRPUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMRP_Purchase_Update.ShowDialog()
		End Sub

		' Token: 0x0600CA8D RID: 51853 RVA: 0x0005A1C3 File Offset: 0x000583C3
		Private Sub PurchaseStockToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseStock.ShowDialog()
		End Sub

		' Token: 0x0600CA8E RID: 51854 RVA: 0x0005A1C3 File Offset: 0x000583C3
		Public Sub frmPurchaseStock1()
			MyProject.Forms.frmPurchaseStock.ShowDialog()
		End Sub

		' Token: 0x0600CA8F RID: 51855 RVA: 0x0005A1D6 File Offset: 0x000583D6
		Private Sub LanguageSetToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmConvert_Language.ShowDialog()
			MyProject.Forms.frmConvert_Language.Dispose()
		End Sub

		' Token: 0x0600CA90 RID: 51856 RVA: 0x0005A1D6 File Offset: 0x000583D6
		Public Sub frmConvert_Language1()
			MyProject.Forms.frmConvert_Language.ShowDialog()
			MyProject.Forms.frmConvert_Language.Dispose()
		End Sub

		' Token: 0x0600CA91 RID: 51857 RVA: 0x0003893C File Offset: 0x00036B3C
		Private Sub CustomerLedgerLoyaltyToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerLedger_Loyalty.Reset()
			MyProject.Forms.frmCustomerLedger_Loyalty.ShowDialog()
			MyProject.Forms.frmCustomerLedger_Loyalty.Dispose()
		End Sub

		' Token: 0x0600CA92 RID: 51858 RVA: 0x0003893C File Offset: 0x00036B3C
		Public Sub frmCustomerLedger_Loyalty1()
			MyProject.Forms.frmCustomerLedger_Loyalty.Reset()
			MyProject.Forms.frmCustomerLedger_Loyalty.ShowDialog()
			MyProject.Forms.frmCustomerLedger_Loyalty.Dispose()
		End Sub

		' Token: 0x0600CA93 RID: 51859 RVA: 0x007F0CF8 File Offset: 0x007EEEF8
		Private Sub MultiBranchSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGodownConfig.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmGodownConfig.ShowDialog()
			MyProject.Forms.frmGodownConfig.Dispose()
		End Sub

		' Token: 0x0600CA94 RID: 51860 RVA: 0x007F0CF8 File Offset: 0x007EEEF8
		Public Sub frmGodownConfig1()
			MyProject.Forms.frmGodownConfig.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmGodownConfig.ShowDialog()
			MyProject.Forms.frmGodownConfig.Dispose()
		End Sub

		' Token: 0x0600CA95 RID: 51861 RVA: 0x007F0D48 File Offset: 0x007EEF48
		Private Sub BranchStockOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGodownOutward.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGodownOutward.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmGodownOutward.ShowDialog()
			MyProject.Forms.frmGodownOutward.Dispose()
		End Sub

		' Token: 0x0600CA96 RID: 51862 RVA: 0x007F0D48 File Offset: 0x007EEF48
		Public Sub frmGodownOutward1()
			MyProject.Forms.frmGodownOutward.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGodownOutward.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmGodownOutward.ShowDialog()
			MyProject.Forms.frmGodownOutward.Dispose()
		End Sub

		' Token: 0x0600CA97 RID: 51863 RVA: 0x007F0DB8 File Offset: 0x007EEFB8
		Private Sub BranchStockInToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGodownInward.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGodownInward.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmGodownInward.ShowDialog()
			MyProject.Forms.frmGodownInward.Dispose()
		End Sub

		' Token: 0x0600CA98 RID: 51864 RVA: 0x007F0DB8 File Offset: 0x007EEFB8
		Public Sub frmGodownInward1()
			MyProject.Forms.frmGodownInward.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmGodownInward.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmGodownInward.ShowDialog()
			MyProject.Forms.frmGodownInward.Dispose()
		End Sub

		' Token: 0x0600CA99 RID: 51865 RVA: 0x007F0E28 File Offset: 0x007EF028
		Private Async Sub WhatsAppConfiguration2ToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.LblEngine.Text, "WhatsApp : Ready", False) = 0
					If flag2 Then
						Await frmMainMenu.whatsApp.Destroy()
					End If
					Me.Timer7.Enabled = False
					Me.LblEngine.Text = "WhatsApp : Not Ready"
					Me.LblEngine.ForeColor = Color.Red
					Me.Label18.Enabled = False
				Catch ex As Exception
				End Try
			End If
			MyProject.Forms.frmWAppAPIServer2.ShowDialog()
			MyProject.Forms.frmWAppAPIServer2.Dispose()
		End Sub

		' Token: 0x0600CA9A RID: 51866 RVA: 0x007F0E70 File Offset: 0x007EF070
		Public Async Sub frmWAppAPIServer21()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.LblEngine.Text, "WhatsApp : Ready", False) = 0
					If flag2 Then
						Await frmMainMenu.whatsApp.Destroy()
					End If
					Me.Timer7.Enabled = False
					Me.LblEngine.Text = "WhatsApp : Not Ready"
					Me.LblEngine.ForeColor = Color.Red
					Me.Label18.Enabled = False
				Catch ex As Exception
				End Try
			End If
			MyProject.Forms.frmWAppAPIServer2.ShowDialog()
			MyProject.Forms.frmWAppAPIServer2.Dispose()
		End Sub

		' Token: 0x0600CA9B RID: 51867 RVA: 0x0005A1F9 File Offset: 0x000583F9
		Private Sub WhatsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.FrmApp.ShowDialog()
			MyProject.Forms.FrmApp.Dispose()
		End Sub

		' Token: 0x0600CA9C RID: 51868 RVA: 0x0005A1F9 File Offset: 0x000583F9
		Public Sub FrmApp1()
			MyProject.Forms.FrmApp.ShowDialog()
			MyProject.Forms.FrmApp.Dispose()
		End Sub

		' Token: 0x0600CA9D RID: 51869 RVA: 0x0005A21C File Offset: 0x0005841C
		Private Sub UploadTestToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFileupload.ShowDialog()
		End Sub

		' Token: 0x0600CA9E RID: 51870 RVA: 0x0005A21C File Offset: 0x0005841C
		Public Sub frmFileupload1()
			MyProject.Forms.frmFileupload.ShowDialog()
		End Sub

		' Token: 0x0600CA9F RID: 51871 RVA: 0x007F0EAC File Offset: 0x007EF0AC
		Private Sub Products2ToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_ProductsRecord1.Reset()
				MyProject.Forms.frmExportImportExcel_ProductsRecord1.ShowDialog()
			End If
		End Sub

		' Token: 0x0600CAA0 RID: 51872 RVA: 0x007F0EAC File Offset: 0x007EF0AC
		Public Sub frmExportImportExcel_ProductsRecord11()
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_ProductsRecord1.Reset()
				MyProject.Forms.frmExportImportExcel_ProductsRecord1.ShowDialog()
			End If
		End Sub

		' Token: 0x0600CAA1 RID: 51873 RVA: 0x00029C8B File Offset: 0x00027E8B
		Private Sub PrinterSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPrinterSettings.ShowDialog()
		End Sub

		' Token: 0x0600CAA2 RID: 51874 RVA: 0x00029C8B File Offset: 0x00027E8B
		Public Sub frmPrinterSettings1()
			MyProject.Forms.frmPrinterSettings.ShowDialog()
		End Sub

		' Token: 0x0600CAA3 RID: 51875 RVA: 0x0005A22F File Offset: 0x0005842F
		Private Sub EwayBillSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEwayBillSetting.ShowDialog()
		End Sub

		' Token: 0x0600CAA4 RID: 51876 RVA: 0x0005A22F File Offset: 0x0005842F
		Public Sub frmEwayBillSetting1()
			MyProject.Forms.frmEwayBillSetting.ShowDialog()
		End Sub

		' Token: 0x0600CAA5 RID: 51877 RVA: 0x0005A242 File Offset: 0x00058442
		Private Sub MenuTestToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTest1.ShowDialog()
		End Sub

		' Token: 0x0600CAA6 RID: 51878 RVA: 0x0005A242 File Offset: 0x00058442
		Public Sub frmTest11()
			MyProject.Forms.frmTest1.ShowDialog()
		End Sub

		' Token: 0x0600CAA7 RID: 51879 RVA: 0x0005A255 File Offset: 0x00058455
		Private Sub UpdateMenuImagesToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMenu_update.ShowDialog()
		End Sub

		' Token: 0x0600CAA8 RID: 51880 RVA: 0x0005A255 File Offset: 0x00058455
		Public Sub frmMenu_update1()
			MyProject.Forms.frmMenu_update.ShowDialog()
		End Sub

		' Token: 0x0600CAA9 RID: 51881 RVA: 0x0005A268 File Offset: 0x00058468
		Public Sub frmPdfReader1()
			MyProject.Forms.frmImageReader.ShowDialog()
		End Sub

		' Token: 0x0600CAAA RID: 51882 RVA: 0x000388EC File Offset: 0x00036AEC
		Private Sub ProductCatalogueMakerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductImageMaker.ShowDialog()
		End Sub

		' Token: 0x0600CAAB RID: 51883 RVA: 0x000388EC File Offset: 0x00036AEC
		Public Sub frmProductImageMaker1()
			MyProject.Forms.frmProductImageMaker.ShowDialog()
		End Sub

		' Token: 0x0600CAAC RID: 51884 RVA: 0x007F0F10 File Offset: 0x007EF110
		Private Sub ChequePrintToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("MoneyLeaf")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("MoneyLeaf")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\MoneyLeaf.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Dim text2 As String = Application.StartupPath + "\MoneyLeaf.exe"
			Using fileStream As FileStream = New FileStream(text2, FileMode.Create)
				fileStream.Write(Resources.MoneyLeaf, 0, Resources.MoneyLeaf.Length)
			End Using
			Process.Start(text2)
			File.SetAttributes(text2, File.GetAttributes(text2) Or FileAttributes.Hidden)
		End Sub

		' Token: 0x0600CAAD RID: 51885 RVA: 0x007F0F10 File Offset: 0x007EF110
		Public Sub ChequePrint1()
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("MoneyLeaf")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("MoneyLeaf")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\MoneyLeaf.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Dim text2 As String = Application.StartupPath + "\MoneyLeaf.exe"
			Using fileStream As FileStream = New FileStream(text2, FileMode.Create)
				fileStream.Write(Resources.MoneyLeaf, 0, Resources.MoneyLeaf.Length)
			End Using
			Process.Start(text2)
			File.SetAttributes(text2, File.GetAttributes(text2) Or FileAttributes.Hidden)
		End Sub

		' Token: 0x0600CAAE RID: 51886 RVA: 0x000236CB File Offset: 0x000218CB
		Private Sub GSTINValidationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.FrmValidate.Button1.Visible = False
			MyProject.Forms.FrmValidate.ShowDialog()
		End Sub

		' Token: 0x0600CAAF RID: 51887 RVA: 0x000236CB File Offset: 0x000218CB
		Public Sub FrmValidate1()
			MyProject.Forms.FrmValidate.Button1.Visible = False
			MyProject.Forms.FrmValidate.ShowDialog()
		End Sub

		' Token: 0x0600CAB0 RID: 51888 RVA: 0x007F1018 File Offset: 0x007EF218
		Private Sub BrokerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBroker.Reset()
			MyProject.Forms.frmBroker.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBroker.ShowDialog()
			MyProject.Forms.frmBroker.Dispose()
		End Sub

		' Token: 0x0600CAB1 RID: 51889 RVA: 0x007F1018 File Offset: 0x007EF218
		Public Sub frmBroker1()
			MyProject.Forms.frmBroker.Reset()
			MyProject.Forms.frmBroker.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBroker.ShowDialog()
			MyProject.Forms.frmBroker.Dispose()
		End Sub

		' Token: 0x0600CAB2 RID: 51890 RVA: 0x000384F4 File Offset: 0x000366F4
		Private Sub BrokerLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBrokerLedger.Reset()
			MyProject.Forms.frmBrokerLedger.ShowDialog()
			MyProject.Forms.frmBrokerLedger.Dispose()
		End Sub

		' Token: 0x0600CAB3 RID: 51891 RVA: 0x000384F4 File Offset: 0x000366F4
		Public Sub frmBrokerLedger1()
			MyProject.Forms.frmBrokerLedger.Reset()
			MyProject.Forms.frmBrokerLedger.ShowDialog()
			MyProject.Forms.frmBrokerLedger.Dispose()
		End Sub

		' Token: 0x0600CAB4 RID: 51892 RVA: 0x0005A27B File Offset: 0x0005847B
		Private Sub PromotionalOfferBuyXAndGetYToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPromotionalOffers.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPromotionalOffers.ShowDialog()
		End Sub

		' Token: 0x0600CAB5 RID: 51893 RVA: 0x0005A27B File Offset: 0x0005847B
		Public Sub frmPromotionalOffers1()
			MyProject.Forms.frmPromotionalOffers.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPromotionalOffers.ShowDialog()
		End Sub

		' Token: 0x0600CAB6 RID: 51894 RVA: 0x0005A2AE File Offset: 0x000584AE
		Private Sub ProductGenerateToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductListWeigh.Reset()
			MyProject.Forms.frmProductListWeigh.ShowDialog()
		End Sub

		' Token: 0x0600CAB7 RID: 51895 RVA: 0x0005A2AE File Offset: 0x000584AE
		Public Sub frmProductListWeigh1()
			MyProject.Forms.frmProductListWeigh.Reset()
			MyProject.Forms.frmProductListWeigh.ShowDialog()
		End Sub

		' Token: 0x0600CAB8 RID: 51896 RVA: 0x007F1078 File Offset: 0x007EF278
		Private Sub ReceiptPrinterScaleToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("RECEIPT_PRINTER")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("RECEIPT_PRINTER")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\RECEIPT_PRINTER.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Dim text2 As String = Application.StartupPath + "\RECEIPT_PRINTER.exe"
			Using fileStream As FileStream = New FileStream(text2, FileMode.Create)
				fileStream.Write(Resources.RECEIPT_PRINTER, 0, Resources.RECEIPT_PRINTER.Length)
			End Using
			Process.Start(text2)
			File.SetAttributes(text2, File.GetAttributes(text2) Or FileAttributes.Hidden)
		End Sub

		' Token: 0x0600CAB9 RID: 51897 RVA: 0x007F1078 File Offset: 0x007EF278
		Public Sub ReceiptPrinterScale1()
			Try
				Dim processesByName As Process() = Process.GetProcessesByName("RECEIPT_PRINTER")
				For Each process As Process In processesByName
					process.Kill()
				Next
				Dim flag As Boolean = Me.ProcessRunning("RECEIPT_PRINTER")
				If flag Then
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\RECEIPT_PRINTER.exe"
					Dim flag2 As Boolean = File.Exists(text)
					If flag2 Then
						File.Delete(text)
					End If
				End If
			Catch ex As Exception
			End Try
			Dim text2 As String = Application.StartupPath + "\RECEIPT_PRINTER.exe"
			Using fileStream As FileStream = New FileStream(text2, FileMode.Create)
				fileStream.Write(Resources.RECEIPT_PRINTER, 0, Resources.RECEIPT_PRINTER.Length)
			End Using
			Process.Start(text2)
			File.SetAttributes(text2, File.GetAttributes(text2) Or FileAttributes.Hidden)
		End Sub

		' Token: 0x0600CABA RID: 51898 RVA: 0x0003883D File Offset: 0x00036A3D
		Private Sub CustomerApprovedDiscountRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerDiscRecord.ShowDialog()
			MyProject.Forms.frmCustomerDiscRecord.Dispose()
		End Sub

		' Token: 0x0600CABB RID: 51899 RVA: 0x0003883D File Offset: 0x00036A3D
		Public Sub frmCustomerDiscRecord1()
			MyProject.Forms.frmCustomerDiscRecord.ShowDialog()
			MyProject.Forms.frmCustomerDiscRecord.Dispose()
		End Sub

		' Token: 0x0600CABC RID: 51900 RVA: 0x0005A2D1 File Offset: 0x000584D1
		Private Sub SupplierContactListToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierContactList.ShowDialog()
			MyProject.Forms.frmSupplierContactList.Dispose()
		End Sub

		' Token: 0x0600CABD RID: 51901 RVA: 0x0005A2D1 File Offset: 0x000584D1
		Public Sub frmSupplierContactList1()
			MyProject.Forms.frmSupplierContactList.ShowDialog()
			MyProject.Forms.frmSupplierContactList.Dispose()
		End Sub

		' Token: 0x0600CABE RID: 51902 RVA: 0x0005A2F4 File Offset: 0x000584F4
		Private Sub CustomerContactListToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerContactList.ShowDialog()
			MyProject.Forms.frmCustomerContactList.Dispose()
		End Sub

		' Token: 0x0600CABF RID: 51903 RVA: 0x0005A2F4 File Offset: 0x000584F4
		Public Sub frmCustomerContactList1()
			MyProject.Forms.frmCustomerContactList.ShowDialog()
			MyProject.Forms.frmCustomerContactList.Dispose()
		End Sub

		' Token: 0x0600CAC0 RID: 51904 RVA: 0x0005A317 File Offset: 0x00058517
		Private Sub EmployeePaymentReportToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmployeePaymentReport.ShowDialog()
			MyProject.Forms.frmEmployeePaymentReport.Dispose()
		End Sub

		' Token: 0x0600CAC1 RID: 51905 RVA: 0x0005A317 File Offset: 0x00058517
		Public Sub frmEmployeePaymentReport1()
			MyProject.Forms.frmEmployeePaymentReport.ShowDialog()
			MyProject.Forms.frmEmployeePaymentReport.Dispose()
		End Sub

		' Token: 0x0600CAC2 RID: 51906 RVA: 0x0005A33A File Offset: 0x0005853A
		Private Sub IncomeTaxCalculatorOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Process.Start("https://www.incometaxindia.gov.in/pages/tools/income-tax-calculator.aspx")
		End Sub

		' Token: 0x0600CAC3 RID: 51907 RVA: 0x0005A33A File Offset: 0x0005853A
		Public Sub IncomeTaxCalculatorOnline1()
			Process.Start("https://www.incometaxindia.gov.in/pages/tools/income-tax-calculator.aspx")
		End Sub

		' Token: 0x0600CAC4 RID: 51908 RVA: 0x0005A348 File Offset: 0x00058548
		Private Sub DBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeLabelPrinting.Reset()
			MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
			MyProject.Forms.frmBarcodeLabelPrinting.Dispose()
		End Sub

		' Token: 0x0600CAC5 RID: 51909 RVA: 0x0005A348 File Offset: 0x00058548
		Public Sub frmBarcodeLabelPrinting1()
			MyProject.Forms.frmBarcodeLabelPrinting.Reset()
			MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
			MyProject.Forms.frmBarcodeLabelPrinting.Dispose()
		End Sub

		' Token: 0x0600CAC6 RID: 51910 RVA: 0x0005A37B File Offset: 0x0005857B
		Private Sub CipherBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomiseBarcode.Reset()
			MyProject.Forms.frmCustomiseBarcode.ShowDialog()
			MyProject.Forms.frmCustomiseBarcode.Dispose()
		End Sub

		' Token: 0x0600CAC7 RID: 51911 RVA: 0x0005A37B File Offset: 0x0005857B
		Public Sub frmCustomiseBarcode1()
			MyProject.Forms.frmCustomiseBarcode.Reset()
			MyProject.Forms.frmCustomiseBarcode.ShowDialog()
			MyProject.Forms.frmCustomiseBarcode.Dispose()
		End Sub

		' Token: 0x0600CAC8 RID: 51912 RVA: 0x0005A3AE File Offset: 0x000585AE
		Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCipherSetting.ShowDialog()
			MyProject.Forms.frmCipherSetting.Dispose()
		End Sub

		' Token: 0x0600CAC9 RID: 51913 RVA: 0x0005A3AE File Offset: 0x000585AE
		Public Sub frmCipherSetting1()
			MyProject.Forms.frmCipherSetting.ShowDialog()
			MyProject.Forms.frmCipherSetting.Dispose()
		End Sub

		' Token: 0x0600CACA RID: 51914 RVA: 0x007F1180 File Offset: 0x007EF380
		Private Sub Label4_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label4, "Reminder Notification")
		End Sub

		' Token: 0x0600CACB RID: 51915 RVA: 0x007F11D0 File Offset: 0x007EF3D0
		Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600CACC RID: 51916 RVA: 0x007F11D0 File Offset: 0x007EF3D0
		Public Sub frmReminder1()
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600CACD RID: 51917 RVA: 0x007F1220 File Offset: 0x007EF420
		Private Sub Label10_Backup(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Label10, "Software License Activated")
		End Sub

		' Token: 0x0600CACE RID: 51918 RVA: 0x0005A3D1 File Offset: 0x000585D1
		Private Sub Label4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminderShow.ShowDialog()
			MyProject.Forms.frmReminderShow.Dispose()
		End Sub

		' Token: 0x0600CACF RID: 51919 RVA: 0x007F0C58 File Offset: 0x007EEE58
		Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminderRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminderRecord.ShowDialog()
			MyProject.Forms.frmReminderRecord.Dispose()
		End Sub

		' Token: 0x0600CAD0 RID: 51920 RVA: 0x0005A3F4 File Offset: 0x000585F4
		Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmInvoiceHeader.ShowDialog()
			MyProject.Forms.frmInvoiceHeader.Dispose()
		End Sub

		' Token: 0x0600CAD1 RID: 51921 RVA: 0x0005A3F4 File Offset: 0x000585F4
		Public Sub frmInvoiceHeader1()
			MyProject.Forms.frmInvoiceHeader.ShowDialog()
			MyProject.Forms.frmInvoiceHeader.Dispose()
		End Sub

		' Token: 0x0600CAD2 RID: 51922 RVA: 0x0005A417 File Offset: 0x00058617
		Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEwaysetting.ShowDialog()
			MyProject.Forms.frmEwaysetting.Dispose()
		End Sub

		' Token: 0x0600CAD3 RID: 51923 RVA: 0x0005A417 File Offset: 0x00058617
		Public Sub frmEwaysetting1()
			MyProject.Forms.frmEwaysetting.ShowDialog()
			MyProject.Forms.frmEwaysetting.Dispose()
		End Sub

		' Token: 0x0600CAD4 RID: 51924 RVA: 0x007F1270 File Offset: 0x007EF470
		Private Sub OfferValidationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerValid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerValid.ShowDialog()
			MyProject.Forms.frmCustomerValid.Dispose()
		End Sub

		' Token: 0x0600CAD5 RID: 51925 RVA: 0x007F1270 File Offset: 0x007EF470
		Public Sub frmCustomerValid1()
			MyProject.Forms.frmCustomerValid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerValid.ShowDialog()
			MyProject.Forms.frmCustomerValid.Dispose()
		End Sub

		' Token: 0x0600CAD6 RID: 51926 RVA: 0x007F12C0 File Offset: 0x007EF4C0
		Private Sub IncomeVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmIncome.Reset()
			MyProject.Forms.frmIncome.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmIncome.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmIncome.ShowDialog()
			MyProject.Forms.frmIncome.Dispose()
		End Sub

		' Token: 0x0600CAD7 RID: 51927 RVA: 0x007F12C0 File Offset: 0x007EF4C0
		Public Sub frmIncome1()
			MyProject.Forms.frmIncome.Reset()
			MyProject.Forms.frmIncome.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmIncome.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmIncome.ShowDialog()
			MyProject.Forms.frmIncome.Dispose()
		End Sub

		' Token: 0x0600CAD8 RID: 51928 RVA: 0x007F04D8 File Offset: 0x007EE6D8
		Private Sub ExpenseVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmVoucher.Reset()
			MyProject.Forms.frmVoucher.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmVoucher.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmVoucher.ShowDialog()
			MyProject.Forms.frmVoucher.Dispose()
		End Sub

		' Token: 0x0600CAD9 RID: 51929 RVA: 0x007F04D8 File Offset: 0x007EE6D8
		Public Sub frmVoucher1()
			MyProject.Forms.frmVoucher.Reset()
			MyProject.Forms.frmVoucher.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmVoucher.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmVoucher.ShowDialog()
			MyProject.Forms.frmVoucher.Dispose()
		End Sub

		' Token: 0x0600CADA RID: 51930 RVA: 0x0005A43A File Offset: 0x0005863A
		Private Sub BulkSMSToCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerOffer.ShowDialog()
			MyProject.Forms.frmCustomerOffer.Dispose()
		End Sub

		' Token: 0x0600CADB RID: 51931 RVA: 0x0005A45D File Offset: 0x0005865D
		Private Sub UpdateMenuHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMenuHeader_update.ShowDialog()
			MyProject.Forms.frmMenuHeader_update.Dispose()
		End Sub

		' Token: 0x0600CADC RID: 51932 RVA: 0x0005A45D File Offset: 0x0005865D
		Public Sub frmMenuHeader_update1()
			MyProject.Forms.frmMenuHeader_update.ShowDialog()
			MyProject.Forms.frmMenuHeader_update.Dispose()
		End Sub

		' Token: 0x0600CADD RID: 51933 RVA: 0x0005A480 File Offset: 0x00058680
		Private Sub Button19_Click(sender As Object, e As EventArgs)
			Me.frmMenu_update1()
		End Sub

		' Token: 0x0600CADE RID: 51934 RVA: 0x0005A48A File Offset: 0x0005868A
		Private Sub Button18_Click(sender As Object, e As EventArgs)
			Me.frmMenuHeader_update1()
		End Sub

		' Token: 0x0600CADF RID: 51935 RVA: 0x0005A43A File Offset: 0x0005863A
		Public Sub frmCustomerOffer1()
			MyProject.Forms.frmCustomerOffer.ShowDialog()
			MyProject.Forms.frmCustomerOffer.Dispose()
		End Sub

		' Token: 0x0600CAE0 RID: 51936 RVA: 0x007F1340 File Offset: 0x007EF540
		Public Sub frmBranch_AddMaster1()
			MyProject.Forms.frmBranch_AddMaster.Label1.Text = "new"
			MyProject.Forms.frmBranch_AddMaster.lblDB.Text = Me.txtDB.Text
			MyProject.Forms.frmBranch_AddMaster.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmBranch_AddMaster.ShowDialog()
			MyProject.Forms.frmBranch_AddMaster.Dispose()
		End Sub

		' Token: 0x0600CAE1 RID: 51937 RVA: 0x0005A494 File Offset: 0x00058694
		Private Sub Button20_Click(sender As Object, e As EventArgs)
			Me.frmProductEntry1()
		End Sub

		' Token: 0x0600CAE2 RID: 51938 RVA: 0x007F13C8 File Offset: 0x007EF5C8
		Private Sub OfferMessangerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.fromItemoffervalid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.fromItemoffervalid.ShowDialog()
			MyProject.Forms.fromItemoffervalid.Dispose()
		End Sub

		' Token: 0x0600CAE3 RID: 51939 RVA: 0x0005A49E File Offset: 0x0005869E
		Private Sub Button21_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmailDashboard3.ShowDialog()
		End Sub

		' Token: 0x0600CAE4 RID: 51940 RVA: 0x007F13C8 File Offset: 0x007EF5C8
		Public Sub fromItemoffervalid1()
			MyProject.Forms.fromItemoffervalid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.fromItemoffervalid.ShowDialog()
			MyProject.Forms.fromItemoffervalid.Dispose()
		End Sub

		' Token: 0x0600CAE5 RID: 51941 RVA: 0x000433E9 File Offset: 0x000415E9
		Private Sub BtnPurchaseWiseMerge_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseWiseMerge.ShowDialog()
			MyProject.Forms.frmPurchaseWiseMerge.Dispose()
		End Sub

		' Token: 0x0600CAE6 RID: 51942 RVA: 0x007F1418 File Offset: 0x007EF618
		Private Sub Button22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAuto_Migrate.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmAuto_Migrate.ShowDialog()
			MyProject.Forms.frmAuto_Migrate.Dispose()
		End Sub

		' Token: 0x0600CAE7 RID: 51943 RVA: 0x007F1418 File Offset: 0x007EF618
		Public Sub frmAuto_Migrate1()
			MyProject.Forms.frmAuto_Migrate.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmAuto_Migrate.ShowDialog()
			MyProject.Forms.frmAuto_Migrate.Dispose()
		End Sub

		' Token: 0x0600CAE8 RID: 51944 RVA: 0x007F1468 File Offset: 0x007EF668
		Private Sub Button23_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
			If flag Then
				MyProject.Forms.frmBranchReport_Dashboard.ShowDialog()
				MyProject.Forms.frmBranchReport_Dashboard.Dispose()
			Else
				MessageBox.Show("Only Admin can access this features! ")
			End If
		End Sub

		' Token: 0x0600CAE9 RID: 51945 RVA: 0x007F1468 File Offset: 0x007EF668
		Public Sub frmBranchReport_Dashboard1()
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
			If flag Then
				MyProject.Forms.frmBranchReport_Dashboard.ShowDialog()
				MyProject.Forms.frmBranchReport_Dashboard.Dispose()
			Else
				MessageBox.Show("Only Admin can access this features! ")
			End If
		End Sub

		' Token: 0x0600CAEA RID: 51946 RVA: 0x0005A4B1 File Offset: 0x000586B1
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSTR1_HSNC.ShowDialog()
			MyProject.Forms.frmGSTR1_HSNC.Dispose()
		End Sub

		' Token: 0x0600CAEB RID: 51947 RVA: 0x0005A4B1 File Offset: 0x000586B1
		Public Sub frmGSTR1_HSNC1()
			MyProject.Forms.frmGSTR1_HSNC.ShowDialog()
			MyProject.Forms.frmGSTR1_HSNC.Dispose()
		End Sub

		' Token: 0x0600CAEC RID: 51948 RVA: 0x00033D16 File Offset: 0x00031F16
		Private Sub CustomerToolStripMenuItem3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerOutstanding.ShowDialog()
			MyProject.Forms.frmCustomerOutstanding.Dispose()
		End Sub

		' Token: 0x0600CAED RID: 51949 RVA: 0x00033D16 File Offset: 0x00031F16
		Public Sub frmCustomerOutstanding1()
			MyProject.Forms.frmCustomerOutstanding.ShowDialog()
			MyProject.Forms.frmCustomerOutstanding.Dispose()
		End Sub

		' Token: 0x0600CAEE RID: 51950 RVA: 0x00033D39 File Offset: 0x00031F39
		Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierOutstanding.ShowDialog()
			MyProject.Forms.frmSupplierOutstanding.Dispose()
		End Sub

		' Token: 0x0600CAEF RID: 51951 RVA: 0x007F14C4 File Offset: 0x007EF6C4
		Private Sub btnLeadGenerate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					MyProject.Forms.frmLead2.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmLead2.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmLead2.ShowDialog()
					MyProject.Forms.frmLead2.Dispose()
				Else
					MessageBox.Show("Only Admin can access this features! ")
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CAF0 RID: 51952 RVA: 0x007F14C4 File Offset: 0x007EF6C4
		Public Sub frmLeads_followup1()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					MyProject.Forms.frmLead2.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmLead2.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmLead2.ShowDialog()
					MyProject.Forms.frmLead2.Dispose()
				Else
					MessageBox.Show("Only Admin can access this features! ")
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CAF1 RID: 51953 RVA: 0x007F1584 File Offset: 0x007EF784
		Public Sub frmLeadGenerateRecord1()
			MyProject.Forms.frmLeadGenerateRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLeadGenerateRecord.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmLeadGenerateRecord.ShowDialog()
			MyProject.Forms.frmLeadGenerateRecord.Dispose()
		End Sub

		' Token: 0x0600CAF2 RID: 51954 RVA: 0x0005A4D4 File Offset: 0x000586D4
		Private Sub Button24_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductBulkUpdate_GST.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate_GST.Dispose()
		End Sub

		' Token: 0x0600CAF3 RID: 51955 RVA: 0x0005A4D4 File Offset: 0x000586D4
		Public Sub frmProductBulkUpdate_GST1()
			MyProject.Forms.frmProductBulkUpdate_GST.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate_GST.Dispose()
		End Sub

		' Token: 0x0600CAF4 RID: 51956 RVA: 0x007F15F4 File Offset: 0x007EF7F4
		Private Sub btnSupport_Dashboard_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmCustomerSupportForm_Dashboard.lblUserType.Text = Me.lblUserType.Text
				MyProject.Forms.frmCustomerSupportForm_Dashboard.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmCustomerSupportForm_Dashboard.ShowDialog()
				MyProject.Forms.frmCustomerSupportForm_Dashboard.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CAF5 RID: 51957 RVA: 0x0005A4F7 File Offset: 0x000586F7
		Private Sub GelBtnSerialWiseReport_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSerialwiseReport.ShowDialog()
		End Sub

		' Token: 0x0600CAF6 RID: 51958 RVA: 0x0005A50A File Offset: 0x0005870A
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmState.ShowDialog()
		End Sub

		' Token: 0x0600CAF7 RID: 51959 RVA: 0x0005A4F7 File Offset: 0x000586F7
		Private Sub Button25_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSerialwiseReport.ShowDialog()
		End Sub

		' Token: 0x0600CAF8 RID: 51960 RVA: 0x0005A4F7 File Offset: 0x000586F7
		Public Sub frmSerialwiseReport1()
			MyProject.Forms.frmSerialwiseReport.ShowDialog()
		End Sub

		' Token: 0x0600CAF9 RID: 51961 RVA: 0x0005156A File Offset: 0x0004F76A
		Public Sub frmBIllwise_ProfitReport1()
			MyProject.Forms.frmBIllwise_ProfitReport.ShowDialog()
		End Sub

		' Token: 0x0600CAFA RID: 51962 RVA: 0x00052A7D File Offset: 0x00050C7D
		Public Sub frmSaleReport_Multi_Payment1()
			MyProject.Forms.frmSaleReport_Multi_Payment.ShowDialog()
			MyProject.Forms.frmSaleReport_Multi_Payment.Dispose()
		End Sub

		' Token: 0x0600CAFB RID: 51963 RVA: 0x0001CBAB File Offset: 0x0001ADAB
		Private Sub btnImportPro_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmImportPro.ShowDialog()
			MyProject.Forms.frmImportPro.Dispose()
		End Sub

		' Token: 0x0600CAFC RID: 51964 RVA: 0x0005A51D File Offset: 0x0005871D
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSMS_AutoDetect.ShowDialog()
			MyProject.Forms.frmSMS_AutoDetect.Dispose()
		End Sub

		' Token: 0x0600CAFD RID: 51965 RVA: 0x007F0300 File Offset: 0x007EE500
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSmart.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProductSmart.ShowDialog()
			MyProject.Forms.frmProductSmart.Dispose()
		End Sub

		' Token: 0x0600CAFE RID: 51966 RVA: 0x00033D39 File Offset: 0x00031F39
		Public Sub frmSupplierOutstanding1()
			MyProject.Forms.frmSupplierOutstanding.ShowDialog()
			MyProject.Forms.frmSupplierOutstanding.Dispose()
		End Sub

		' Token: 0x0600CAFF RID: 51967 RVA: 0x00038606 File Offset: 0x00036806
		Private Sub TaxToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmDebtorsReport.ShowDialog()
			MyProject.Forms.frmDebtorsReport.Dispose()
		End Sub

		' Token: 0x0600CB00 RID: 51968 RVA: 0x00038606 File Offset: 0x00036806
		Public Sub frmDebtorsReport1()
			MyProject.Forms.frmDebtorsReport.ShowDialog()
			MyProject.Forms.frmDebtorsReport.Dispose()
		End Sub

		' Token: 0x0600CB01 RID: 51969 RVA: 0x007F1688 File Offset: 0x007EF888
		Private Sub BillSundryHeadToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBillSundry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBillSundry.Reset()
			MyProject.Forms.frmBillSundry.ShowDialog()
			MyProject.Forms.frmBillSundry.Dispose()
		End Sub

		' Token: 0x0600CB02 RID: 51970 RVA: 0x007F1688 File Offset: 0x007EF888
		Public Sub frmBillSundry1()
			MyProject.Forms.frmBillSundry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmBillSundry.Reset()
			MyProject.Forms.frmBillSundry.ShowDialog()
			MyProject.Forms.frmBillSundry.Dispose()
		End Sub

		' Token: 0x0600CB03 RID: 51971 RVA: 0x007F16E8 File Offset: 0x007EF8E8
		Private Sub LoyaltyValidationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLoyaltyvalid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLoyaltyvalid.Clear()
			MyProject.Forms.frmLoyaltyvalid.ShowDialog()
			MyProject.Forms.frmLoyaltyvalid.Dispose()
		End Sub

		' Token: 0x0600CB04 RID: 51972 RVA: 0x007F16E8 File Offset: 0x007EF8E8
		Public Sub frmLoyaltyvalid1()
			MyProject.Forms.frmLoyaltyvalid.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLoyaltyvalid.Clear()
			MyProject.Forms.frmLoyaltyvalid.ShowDialog()
			MyProject.Forms.frmLoyaltyvalid.Dispose()
		End Sub

		' Token: 0x0600CB05 RID: 51973 RVA: 0x0005A540 File Offset: 0x00058740
		Private Sub BulkLoyaltySMSToCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLoyaltySMS.ShowDialog()
			MyProject.Forms.frmLoyaltySMS.Dispose()
		End Sub

		' Token: 0x0600CB06 RID: 51974 RVA: 0x0005A540 File Offset: 0x00058740
		Public Sub frmLoyaltySMS1()
			MyProject.Forms.frmLoyaltySMS.ShowDialog()
			MyProject.Forms.frmLoyaltySMS.Dispose()
		End Sub

		' Token: 0x0600CB07 RID: 51975 RVA: 0x00038860 File Offset: 0x00036A60
		Private Sub LoyaltyCardToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPrintLoyaltyCard.ShowDialog()
			MyProject.Forms.frmPrintLoyaltyCard.Dispose()
		End Sub

		' Token: 0x0600CB08 RID: 51976 RVA: 0x00038860 File Offset: 0x00036A60
		Public Sub frmPrintLoyaltyCard1()
			MyProject.Forms.frmPrintLoyaltyCard.ShowDialog()
			MyProject.Forms.frmPrintLoyaltyCard.Dispose()
		End Sub

		' Token: 0x0600CB09 RID: 51977 RVA: 0x0005A563 File Offset: 0x00058763
		Private Sub BulkEMailSenderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSendEmail.ShowDialog()
			MyProject.Forms.frmSendEmail.Dispose()
		End Sub

		' Token: 0x0600CB0A RID: 51978 RVA: 0x0005A563 File Offset: 0x00058763
		Public Sub frmSendEmail1()
			MyProject.Forms.frmSendEmail.ShowDialog()
			MyProject.Forms.frmSendEmail.Dispose()
		End Sub

		' Token: 0x0600CB0B RID: 51979 RVA: 0x0005A586 File Offset: 0x00058786
		Private Sub TCSReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTCSRcvd.ShowDialog()
			MyProject.Forms.frmTCSRcvd.Dispose()
		End Sub

		' Token: 0x0600CB0C RID: 51980 RVA: 0x0005A586 File Offset: 0x00058786
		Public Sub frmTCSRcvd1()
			MyProject.Forms.frmTCSRcvd.ShowDialog()
			MyProject.Forms.frmTCSRcvd.Dispose()
		End Sub

		' Token: 0x0600CB0D RID: 51981 RVA: 0x0005A5A9 File Offset: 0x000587A9
		Private Sub TCSPaymentPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTCSPurchase.ShowDialog()
			MyProject.Forms.frmTCSPurchase.Dispose()
		End Sub

		' Token: 0x0600CB0E RID: 51982 RVA: 0x0005A5A9 File Offset: 0x000587A9
		Public Sub frmTCSPurchase1()
			MyProject.Forms.frmTCSPurchase.ShowDialog()
			MyProject.Forms.frmTCSPurchase.Dispose()
		End Sub

		' Token: 0x0600CB0F RID: 51983 RVA: 0x0005A5CC File Offset: 0x000587CC
		Private Sub TCSPaymentSaleReturnToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTCSSaleReturn.ShowDialog()
			MyProject.Forms.frmTCSSaleReturn.Dispose()
		End Sub

		' Token: 0x0600CB10 RID: 51984 RVA: 0x0005A5CC File Offset: 0x000587CC
		Public Sub frmTCSSaleReturn1()
			MyProject.Forms.frmTCSSaleReturn.ShowDialog()
			MyProject.Forms.frmTCSSaleReturn.Dispose()
		End Sub

		' Token: 0x0600CB11 RID: 51985 RVA: 0x0005A5EF File Offset: 0x000587EF
		Private Sub TCSReceivedPurchaseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTCSPurchaseReturn.ShowDialog()
			MyProject.Forms.frmTCSPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600CB12 RID: 51986 RVA: 0x0005A5EF File Offset: 0x000587EF
		Public Sub frmTCSPurchaseReturn1()
			MyProject.Forms.frmTCSPurchaseReturn.ShowDialog()
			MyProject.Forms.frmTCSPurchaseReturn.Dispose()
		End Sub

		' Token: 0x0600CB13 RID: 51987 RVA: 0x007F1748 File Offset: 0x007EF948
		Private Sub TCSValidationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTCSValidation.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTCSValidation.ShowDialog()
			MyProject.Forms.frmTCSValidation.Dispose()
		End Sub

		' Token: 0x0600CB14 RID: 51988 RVA: 0x007F1748 File Offset: 0x007EF948
		Public Sub frmTCSValidation1()
			MyProject.Forms.frmTCSValidation.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmTCSValidation.ShowDialog()
			MyProject.Forms.frmTCSValidation.Dispose()
		End Sub

		' Token: 0x0600CB15 RID: 51989 RVA: 0x007F1798 File Offset: 0x007EF998
		Private Sub LoyaltyCardIssueToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLCardIssue.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLCardIssue.ShowDialog()
			MyProject.Forms.frmLCardIssue.Dispose()
		End Sub

		' Token: 0x0600CB16 RID: 51990 RVA: 0x007F1798 File Offset: 0x007EF998
		Public Sub frmLCardIssue1()
			MyProject.Forms.frmLCardIssue.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLCardIssue.ShowDialog()
			MyProject.Forms.frmLCardIssue.Dispose()
		End Sub

		' Token: 0x0600CB17 RID: 51991 RVA: 0x0005A612 File Offset: 0x00058812
		Private Sub BulkSMSToCreditCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCreditCustomerSMS.ShowDialog()
			MyProject.Forms.frmCreditCustomerSMS.Dispose()
		End Sub

		' Token: 0x0600CB18 RID: 51992 RVA: 0x0005A612 File Offset: 0x00058812
		Public Sub frmCreditCustomerSMS1()
			MyProject.Forms.frmCreditCustomerSMS.ShowDialog()
			MyProject.Forms.frmCreditCustomerSMS.Dispose()
		End Sub

		' Token: 0x0600CB19 RID: 51993 RVA: 0x0005A635 File Offset: 0x00058835
		Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmWhatsappMessage.ShowDialog()
			MyProject.Forms.frmWhatsappMessage.Dispose()
		End Sub

		' Token: 0x0600CB1A RID: 51994 RVA: 0x0005A635 File Offset: 0x00058835
		Public Sub frmWhatsappMessage1()
			MyProject.Forms.frmWhatsappMessage.ShowDialog()
			MyProject.Forms.frmWhatsappMessage.Dispose()
		End Sub

		' Token: 0x0600CB1B RID: 51995 RVA: 0x00012250 File Offset: 0x00010450
		Private Sub ProductBulkEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductBulkUpdate.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB1C RID: 51996 RVA: 0x00012250 File Offset: 0x00010450
		Public Sub frmProductBulkUpdate1()
			MyProject.Forms.frmProductBulkUpdate.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB1D RID: 51997 RVA: 0x007F17E8 File Offset: 0x007EF9E8
		Private Sub AccountHeadToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAccountHead.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAccountHead.Reset()
			MyProject.Forms.frmAccountHead.ShowDialog()
			MyProject.Forms.frmAccountHead.Dispose()
		End Sub

		' Token: 0x0600CB1E RID: 51998 RVA: 0x007F17E8 File Offset: 0x007EF9E8
		Public Sub frmAccountHead1()
			MyProject.Forms.frmAccountHead.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmAccountHead.Reset()
			MyProject.Forms.frmAccountHead.ShowDialog()
			MyProject.Forms.frmAccountHead.Dispose()
		End Sub

		' Token: 0x0600CB1F RID: 51999 RVA: 0x007F0CA8 File Offset: 0x007EEEA8
		Private Sub FinancialYearChangeToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFYChange.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFYChange.ShowDialog()
			MyProject.Forms.frmFYChange.Dispose()
		End Sub

		' Token: 0x0600CB20 RID: 52000 RVA: 0x0005A658 File Offset: 0x00058858
		Private Sub MenuStrip2_MouseEnter(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.Hand
		End Sub

		' Token: 0x0600CB21 RID: 52001 RVA: 0x0005A658 File Offset: 0x00058858
		Private Sub MenuStrip2_MouseHover(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.Hand
		End Sub

		' Token: 0x0600CB22 RID: 52002 RVA: 0x0005A667 File Offset: 0x00058867
		Private Sub SaleRegisterBillWiseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.GSTSaleRegister.ShowDialog()
			MyProject.Forms.GSTSaleRegister.Dispose()
		End Sub

		' Token: 0x0600CB23 RID: 52003 RVA: 0x0005A667 File Offset: 0x00058867
		Public Sub GSTSaleRegister1()
			MyProject.Forms.GSTSaleRegister.ShowDialog()
			MyProject.Forms.GSTSaleRegister.Dispose()
		End Sub

		' Token: 0x0600CB24 RID: 52004 RVA: 0x0005A68A File Offset: 0x0005888A
		Private Sub PurchaseRegisterBillWiseToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.GSTPurchaseRegister.ShowDialog()
			MyProject.Forms.GSTPurchaseRegister.Dispose()
		End Sub

		' Token: 0x0600CB25 RID: 52005 RVA: 0x0005A68A File Offset: 0x0005888A
		Public Sub GSTPurchaseRegister1()
			MyProject.Forms.GSTPurchaseRegister.ShowDialog()
			MyProject.Forms.GSTPurchaseRegister.Dispose()
		End Sub

		' Token: 0x0600CB26 RID: 52006 RVA: 0x007F1848 File Offset: 0x007EFA48
		Private Sub EstimateToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEstimate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEstimate.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmEstimate.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmEstimate.Reset()
			MyProject.Forms.frmEstimate.ShowDialog()
			MyProject.Forms.frmEstimate.Dispose()
		End Sub

		' Token: 0x0600CB27 RID: 52007 RVA: 0x007F1848 File Offset: 0x007EFA48
		Public Sub frmEstimate1()
			MyProject.Forms.frmEstimate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEstimate.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmEstimate.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmEstimate.Reset()
			MyProject.Forms.frmEstimate.ShowDialog()
			MyProject.Forms.frmEstimate.Dispose()
		End Sub

		' Token: 0x0600CB28 RID: 52008 RVA: 0x00525A14 File Offset: 0x00523C14
		Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEstimateRecord.Reset()
			MyProject.Forms.frmEstimateRecord.Label3.Text = ""
			MyProject.Forms.frmEstimateRecord.Reset()
			MyProject.Forms.frmEstimateRecord.ShowDialog()
			MyProject.Forms.frmEstimateRecord.Dispose()
		End Sub

		' Token: 0x0600CB29 RID: 52009 RVA: 0x00525A14 File Offset: 0x00523C14
		Public Sub frmEstimateRecord1()
			MyProject.Forms.frmEstimateRecord.Reset()
			MyProject.Forms.frmEstimateRecord.Label3.Text = ""
			MyProject.Forms.frmEstimateRecord.Reset()
			MyProject.Forms.frmEstimateRecord.ShowDialog()
			MyProject.Forms.frmEstimateRecord.Dispose()
		End Sub

		' Token: 0x0600CB2A RID: 52010 RVA: 0x00038883 File Offset: 0x00036A83
		Private Sub CustomerBulkEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerBulkUpdate.ShowDialog()
			MyProject.Forms.frmCustomerBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB2B RID: 52011 RVA: 0x00038883 File Offset: 0x00036A83
		Public Sub frmCustomerBulkUpdate1()
			MyProject.Forms.frmCustomerBulkUpdate.ShowDialog()
			MyProject.Forms.frmCustomerBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB2C RID: 52012 RVA: 0x00043291 File Offset: 0x00041491
		Private Sub SupplierBulkEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierBulkUpdate.ShowDialog()
			MyProject.Forms.frmSupplierBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB2D RID: 52013 RVA: 0x00043291 File Offset: 0x00041491
		Public Sub frmSupplierBulkUpdate1()
			MyProject.Forms.frmSupplierBulkUpdate.ShowDialog()
			MyProject.Forms.frmSupplierBulkUpdate.Dispose()
		End Sub

		' Token: 0x0600CB2E RID: 52014 RVA: 0x000388C9 File Offset: 0x00036AC9
		Private Sub CustomerTurnAroundRecordToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerRoundover.ShowDialog()
			MyProject.Forms.frmCustomerRoundover.Dispose()
		End Sub

		' Token: 0x0600CB2F RID: 52015 RVA: 0x000388C9 File Offset: 0x00036AC9
		Public Sub frmCustomerRoundover1()
			MyProject.Forms.frmCustomerRoundover.ShowDialog()
			MyProject.Forms.frmCustomerRoundover.Dispose()
		End Sub

		' Token: 0x0600CB30 RID: 52016 RVA: 0x0005A16A File Offset: 0x0005836A
		Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUserControl.ShowDialog()
			MyProject.Forms.frmUserControl.Dispose()
		End Sub

		' Token: 0x0600CB31 RID: 52017 RVA: 0x0005A6AD File Offset: 0x000588AD
		Private Sub MenuStrip2_MouseLeave(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
		End Sub

		' Token: 0x0600CB32 RID: 52018 RVA: 0x007F18E8 File Offset: 0x007EFAE8
		Private Sub ReminderCount()
			Try
				Me.Label5.Text = ""
				Me.Label5.Text = ""
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con101.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM Reminder WHERE mdate=@d1", ModCommonClasses.con101)
				sqlCommand.Parameters.AddWithValue("@d1", DateAndTime.Today)
				Dim text As String = Convert.ToString(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
				Me.Label5.Text = text
				Dim flag As Boolean = (Conversions.ToDouble(Me.Label5.Text) = 0.0) Or (Operators.CompareString(Me.Label5.Text, "", False) = 0)
				If flag Then
					Me.Label5.Visible = False
					Me.Label4.Enabled = False
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(Me.Label5.Text) > 0.0
					If flag2 Then
						Me.Label5.Visible = True
						Me.Label4.Enabled = True
					End If
				End If
				ModCommonClasses.con101.Close()
			Catch ex As Exception
				ModCommonClasses.con101.Close()
			End Try
		End Sub

		' Token: 0x0600CB33 RID: 52019 RVA: 0x007F1A5C File Offset: 0x007EFC5C
		Private Sub Label17_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Dim enabled As Boolean = Me.Label17.Enabled
			If enabled Then
				Me.ToolTip1.SetToolTip(Me.Label17, "Android Mobile Feature Activated...." & vbCrLf & "Click here to download the Android Apk file")
			Else
				Me.ToolTip1.SetToolTip(Me.Label17, "Android Mobile Feature Activated...." & vbCrLf & "Click here to download the Android Apk file")
			End If
		End Sub

		' Token: 0x0600CB34 RID: 52020 RVA: 0x007F1AD8 File Offset: 0x007EFCD8
		Private Function ReadInstanceFile() As Object
			Dim flag As Boolean = File.Exists(Application.StartupPath + "\instanceID.txt")
			If flag Then
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\instanceID.txt")
				frmLogin.InstanceID = array(0)
				Dim flag2 As Boolean = frmLogin.InstanceID.Equals("")
				If flag2 Then
					Me.LblEngine.Text = "WhatsApp : Not Ready"
					Me.LblEngine1.Text = "WhatsApp : Not Ready"
				Else
					Me.LblEngine.Text = "WhatsApp : Ready"
					Me.LblEngine1.Text = "WhatsApp : Ready"
					Me.LblEngine.ForeColor = Color.Green
					Me.LblEngine1.ForeColor = Color.Green
				End If
			End If
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600CB35 RID: 52021 RVA: 0x0005A6BC File Offset: 0x000588BC
		Public Sub frmProductEntry1()
			MyProject.Forms.frmProductEntry.ShowDialog()
			MyProject.Forms.frmProductEntry.Dispose()
		End Sub

		' Token: 0x0600CB36 RID: 52022 RVA: 0x0005A6DF File Offset: 0x000588DF
		Public Sub frmEmailDashboard1()
			MyProject.Forms.frmEmailDashboard.ShowDialog()
			MyProject.Forms.frmEmailDashboard.Dispose()
		End Sub

		' Token: 0x0600CB37 RID: 52023 RVA: 0x0001AB6E File Offset: 0x00018D6E
		Public Sub frmEmailSetting_login1()
			MyProject.Forms.frmEmailSetting_login.ShowDialog()
			MyProject.Forms.frmEmailSetting_login.Dispose()
		End Sub

		' Token: 0x0600CB38 RID: 52024 RVA: 0x007F1BA0 File Offset: 0x007EFDA0
		Public Sub frmStock_Inward_Notification1()
			MyProject.Forms.frmStock_Inward_Notification.lblSet.Text = "transfer"
			MyProject.Forms.frmStock_Inward_Notification.lblUser.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Notification.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Notification.lblFrom_Company_id.Text = Me.strCompany_id
			MyProject.Forms.frmStock_Inward_Notification.ShowDialog()
			MyProject.Forms.frmStock_Inward_Notification.Dispose()
		End Sub

		' Token: 0x0600CB39 RID: 52025 RVA: 0x007F1C44 File Offset: 0x007EFE44
		Public Sub frmStock_Inward_Record1()
			MyProject.Forms.frmStock_Inward_Record.lblSet.Text = "transfer"
			MyProject.Forms.frmStock_Inward_Record.lblUser.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Record.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Record.lblFrom_Company_id.Text = Me.strCompany_id
			MyProject.Forms.frmStock_Inward_Record.ShowDialog()
			MyProject.Forms.frmStock_Inward_Record.Dispose()
		End Sub

		' Token: 0x0600CB3A RID: 52026 RVA: 0x0005A702 File Offset: 0x00058902
		Public Sub frmGSheet_Report1()
			MyProject.Forms.frmGSheet_Report.ShowDialog()
			MyProject.Forms.frmGSheet_Report.Dispose()
		End Sub

		' Token: 0x040050C2 RID: 20674
		Private internetStatus As Boolean

		' Token: 0x040050C3 RID: 20675
		Private Filename As String

		' Token: 0x040050C4 RID: 20676
		Private i1 As Integer

		' Token: 0x040050C5 RID: 20677
		Private i2 As Integer

		' Token: 0x040050C6 RID: 20678
		Private stX As String

		' Token: 0x040050C7 RID: 20679
		Private C1 As String

		' Token: 0x040050C8 RID: 20680
		Private C2 As String

		' Token: 0x040050C9 RID: 20681
		Private C3 As String

		' Token: 0x040050CA RID: 20682
		Private C4 As String

		' Token: 0x040050CB RID: 20683
		Private C5 As String

		' Token: 0x040050CC RID: 20684
		Private C6 As String

		' Token: 0x040050CD RID: 20685
		Private C7 As String

		' Token: 0x040050CE RID: 20686
		Private C8 As String

		' Token: 0x040050CF RID: 20687
		Private C9 As String

		' Token: 0x040050D0 RID: 20688
		Private C10 As String

		' Token: 0x040050D1 RID: 20689
		Private C11 As String

		' Token: 0x040050D2 RID: 20690
		Private C12 As String

		' Token: 0x040050D3 RID: 20691
		Private C13 As String

		' Token: 0x040050D4 RID: 20692
		Private C14 As String

		' Token: 0x040050D5 RID: 20693
		Private C15 As String

		' Token: 0x040050D6 RID: 20694
		Private C16 As String

		' Token: 0x040050D7 RID: 20695
		Private C17 As String

		' Token: 0x040050D8 RID: 20696
		Private C18 As String

		' Token: 0x040050D9 RID: 20697
		Private C19 As String

		' Token: 0x040050DA RID: 20698
		Private C20 As String

		' Token: 0x040050DB RID: 20699
		Private C21 As String

		' Token: 0x040050DC RID: 20700
		Private C22 As String

		' Token: 0x040050DD RID: 20701
		Private C23 As String

		' Token: 0x040050DE RID: 20702
		Private C24 As String

		' Token: 0x040050DF RID: 20703
		Private C25 As String

		' Token: 0x040050E0 RID: 20704
		Private C26 As String

		' Token: 0x040050E1 RID: 20705
		Private C27 As String

		' Token: 0x040050E2 RID: 20706
		Private C28 As String

		' Token: 0x040050E3 RID: 20707
		Private C29 As String

		' Token: 0x040050E4 RID: 20708
		Private C30 As String

		' Token: 0x040050E5 RID: 20709
		Private C31 As String

		' Token: 0x040050E6 RID: 20710
		Private C32 As String

		' Token: 0x040050E7 RID: 20711
		Private C33 As String

		' Token: 0x040050E8 RID: 20712
		Private C34 As String

		' Token: 0x040050E9 RID: 20713
		Private C35 As String

		' Token: 0x040050EA RID: 20714
		Private C36 As String

		' Token: 0x040050EB RID: 20715
		Private C37 As String

		' Token: 0x040050EC RID: 20716
		Private C38 As String

		' Token: 0x040050ED RID: 20717
		Private C39 As String

		' Token: 0x040050EE RID: 20718
		Private C40 As String

		' Token: 0x040050EF RID: 20719
		Private C41 As String

		' Token: 0x040050F0 RID: 20720
		Private C42 As String

		' Token: 0x040050F1 RID: 20721
		Private C43 As String

		' Token: 0x040050F2 RID: 20722
		Private C44 As String

		' Token: 0x040050F3 RID: 20723
		Private C45 As String

		' Token: 0x040050F4 RID: 20724
		Private C46 As String

		' Token: 0x040050F5 RID: 20725
		Private C47 As String

		' Token: 0x040050F6 RID: 20726
		Private C48 As String

		' Token: 0x040050F7 RID: 20727
		Private C49 As String

		' Token: 0x040050F8 RID: 20728
		Private C50 As String

		' Token: 0x040050F9 RID: 20729
		Private C51 As String

		' Token: 0x040050FA RID: 20730
		Private fy1 As String

		' Token: 0x040050FB RID: 20731
		Private custsecdisplay As String

		' Token: 0x040050FC RID: 20732
		Private fy2 As String

		' Token: 0x040050FD RID: 20733
		Private gDClient As Global.GDClient.GDClient

		' Token: 0x040050FE RID: 20734
		Private CurSym As String

		' Token: 0x040050FF RID: 20735
		Private ax As Double

		' Token: 0x04005100 RID: 20736
		Private bx As Double

		' Token: 0x04005101 RID: 20737
		Private cx As Double

		' Token: 0x04005102 RID: 20738
		Private dx As Double

		' Token: 0x04005103 RID: 20739
		Private ex As Double

		' Token: 0x04005104 RID: 20740
		Private fx As Double

		' Token: 0x04005105 RID: 20741
		Private gx As Double

		' Token: 0x04005106 RID: 20742
		Private hx As Double

		' Token: 0x04005107 RID: 20743
		Private ix As Double

		' Token: 0x04005108 RID: 20744
		Private jx As Double

		' Token: 0x04005109 RID: 20745
		Private regdto As String

		' Token: 0x0400510A RID: 20746
		Private fdt As DateTime

		' Token: 0x0400510B RID: 20747
		Private countdays As Integer

		' Token: 0x0400510C RID: 20748
		Private android_service As FirebaseService

		' Token: 0x0400510D RID: 20749
		Public Shared whatsApp As WhatsApp

		' Token: 0x0400510E RID: 20750
		Private _ENGINE_STATE As State

		' Token: 0x0400510F RID: 20751
		Public Shared whatsApp1 As WhatsApp

		' Token: 0x04005110 RID: 20752
		Private _ENGINE_STATE1 As State

		' Token: 0x04005111 RID: 20753
		Private strdb_name As String

		' Token: 0x04005112 RID: 20754
		Private Online_DBName As String

		' Token: 0x04005113 RID: 20755
		Private Local_DBName As String

		' Token: 0x04005114 RID: 20756
		Private strCompany_id As String

		' Token: 0x04005115 RID: 20757
		Private migrationTimer As Global.System.Windows.Forms.Timer

		' Token: 0x04005116 RID: 20758
		Private isMigrationRunning As Boolean

		' Token: 0x04005117 RID: 20759
		Private AutoMigration_Status As Boolean

		' Token: 0x04005118 RID: 20760
		Private helper As DBHelper

		' Token: 0x04005119 RID: 20761
		Private UserButtons As List(Of GelButton)

		' Token: 0x0400511A RID: 20762
		Private mydict As Dictionary(Of String, String)

		' Token: 0x0400511D RID: 20765
		Private lastClickedButton As Button

		' Token: 0x0400511E RID: 20766
		Public sts2 As String

		' Token: 0x0400511F RID: 20767
		Public sts_w2 As String

		' Token: 0x04005120 RID: 20768
		Private i As Integer

		' Token: 0x04005121 RID: 20769
		Private j As Integer

		' Token: 0x04005122 RID: 20770
		Private strb As StringBuilder

		' Token: 0x04005123 RID: 20771
		Private json As mOrder

		' Token: 0x04005124 RID: 20772
		Private ujson As mUser

		' Token: 0x04005125 RID: 20773
		Private pjson As pProduct

		' Token: 0x04005126 RID: 20774
		Private ajson As mArea

		' Token: 0x04005127 RID: 20775
		Private lblType As String

		' Token: 0x04005128 RID: 20776
		Private rec As Record

		' Token: 0x04005129 RID: 20777
		Private countOrder_previous As Integer

		' Token: 0x0400512A RID: 20778
		Private voice As Object

		' Token: 0x0400512B RID: 20779
		Private AID As String

		' Token: 0x0200034D RID: 845
		Public Class MyRender
			Inherits ToolStripProfessionalRenderer

			' Token: 0x17004FF4 RID: 20468
			' (get) Token: 0x0600CB40 RID: 52032 RVA: 0x0005A741 File Offset: 0x00058941
			' (set) Token: 0x0600CB41 RID: 52033 RVA: 0x0005A74A File Offset: 0x0005894A
			Public Shared Property highlightbackcolor As Color = Color.FromArgb(0, 113, 227)

			' Token: 0x17004FF5 RID: 20469
			' (get) Token: 0x0600CB42 RID: 52034 RVA: 0x0005A752 File Offset: 0x00058952
			' (set) Token: 0x0600CB43 RID: 52035 RVA: 0x0005A75B File Offset: 0x0005895B
			Public Shared Property highlightforecolor As Color = Color.White

			' Token: 0x17004FF6 RID: 20470
			' (get) Token: 0x0600CB44 RID: 52036 RVA: 0x0005A763 File Offset: 0x00058963
			' (set) Token: 0x0600CB45 RID: 52037 RVA: 0x0005A76C File Offset: 0x0005896C
			Public Shared Property nonhighlightbackcolor As Color = Color.White

			' Token: 0x17004FF7 RID: 20471
			' (get) Token: 0x0600CB46 RID: 52038 RVA: 0x0005A774 File Offset: 0x00058974
			' (set) Token: 0x0600CB47 RID: 52039 RVA: 0x0005A77D File Offset: 0x0005897D
			Public Shared Property nonhighlightforecolor As Color = Color.FromArgb(29, 29, 31)

			' Token: 0x17004FF8 RID: 20472
			' (get) Token: 0x0600CB48 RID: 52040 RVA: 0x0005A785 File Offset: 0x00058985
			' (set) Token: 0x0600CB49 RID: 52041 RVA: 0x0005A78E File Offset: 0x0005898E
			Public Shared Property menufont As Font = New Font("Segoe UI Semibold", 11F)

			' Token: 0x0600CB4A RID: 52042 RVA: 0x007F1E68 File Offset: 0x007F0068
			Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
				Dim rectangle As Rectangle = New Rectangle(Point.Empty, e.Item.Size)
				Dim obj As Object = Interaction.IIf(e.Item.Selected, frmMainMenu.MyRender.highlightbackcolor, frmMainMenu.MyRender.nonhighlightbackcolor)
				Dim color As Color = If((obj IsNot Nothing), CType(obj, Color), Nothing)
				Dim obj2 As Object = Interaction.IIf(e.Item.Selected, frmMainMenu.MyRender.highlightforecolor, frmMainMenu.MyRender.nonhighlightforecolor)
				Dim color2 As Color = If((obj2 IsNot Nothing), CType(obj2, Color), Nothing)
				Using solidBrush As SolidBrush = New SolidBrush(color)
					e.Graphics.FillRectangle(solidBrush, rectangle)
				End Using
				e.Item.ForeColor = color2
				e.Item.Font = frmMainMenu.MyRender.menufont
			End Sub
		End Class
	End Class
End Namespace
