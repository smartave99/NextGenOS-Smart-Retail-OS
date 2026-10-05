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
Imports CrystalDecisions.[Shared]
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000209 RID: 521
	<DesignerGenerated()>
	Public Partial Class frmSalesManPayment
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060096C6 RID: 38598 RVA: 0x006C7A48 File Offset: 0x006C5C48
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditCustomerReceipt_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCreditCustomerReceipt_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCreditCustomerReceipt_Closing
			Me.i = 0
			Me.bankacno = ""
			Me.bankifsc = ""
			Me.bankholdername = ""
			Me.ntid = ""
			Me.sts2 = ""
			Me.WhatsApppdfFile = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.Pdf"
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003802 RID: 14338
		' (get) Token: 0x060096C9 RID: 38601 RVA: 0x00049C65 File Offset: 0x00047E65
		' (set) Token: 0x060096CA RID: 38602 RVA: 0x006CBA94 File Offset: 0x006C9C94
		Private _txtCustNameId As TextBox
		Friend Overridable Property txtCustNameId As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustNameId
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustNameId_TextChanged
				Dim textBox As TextBox = Me._txtCustNameId
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustNameId = value
				textBox = Me._txtCustNameId
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003803 RID: 14339
		' (get) Token: 0x060096CB RID: 38603 RVA: 0x00049C6F File Offset: 0x00047E6F
		' (set) Token: 0x060096CC RID: 38604 RVA: 0x00049C79 File Offset: 0x00047E79
		Friend Overridable Property cmbCustomerName As TextBox

		' Token: 0x17003804 RID: 14340
		' (get) Token: 0x060096CD RID: 38605 RVA: 0x00049C82 File Offset: 0x00047E82
		' (set) Token: 0x060096CE RID: 38606 RVA: 0x006CBAD8 File Offset: 0x006C9CD8
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

		' Token: 0x17003805 RID: 14341
		' (get) Token: 0x060096CF RID: 38607 RVA: 0x00049C8C File Offset: 0x00047E8C
		' (set) Token: 0x060096D0 RID: 38608 RVA: 0x006CBB1C File Offset: 0x006C9D1C
		Private _btnFirst As Button
		Friend Overridable Property btnFirst As Button
			<CompilerGenerated()>
			Get
				Return Me._btnFirst
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnFirst_Click
				Dim button As Button = Me._btnFirst
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnFirst = value
				button = Me._btnFirst
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003806 RID: 14342
		' (get) Token: 0x060096D1 RID: 38609 RVA: 0x00049C96 File Offset: 0x00047E96
		' (set) Token: 0x060096D2 RID: 38610 RVA: 0x006CBB60 File Offset: 0x006C9D60
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
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

		' Token: 0x17003807 RID: 14343
		' (get) Token: 0x060096D3 RID: 38611 RVA: 0x00049CA0 File Offset: 0x00047EA0
		' (set) Token: 0x060096D4 RID: 38612 RVA: 0x006CBBA4 File Offset: 0x006C9DA4
		Private _txtRemarks As RichTextBox
		Friend Overridable Property txtRemarks As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim richTextBox As RichTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				richTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003808 RID: 14344
		' (get) Token: 0x060096D5 RID: 38613 RVA: 0x00049CAA File Offset: 0x00047EAA
		' (set) Token: 0x060096D6 RID: 38614 RVA: 0x00049CB4 File Offset: 0x00047EB4
		Friend Overridable Property Label12 As Label

		' Token: 0x17003809 RID: 14345
		' (get) Token: 0x060096D7 RID: 38615 RVA: 0x00049CBD File Offset: 0x00047EBD
		' (set) Token: 0x060096D8 RID: 38616 RVA: 0x00049CC7 File Offset: 0x00047EC7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700380A RID: 14346
		' (get) Token: 0x060096D9 RID: 38617 RVA: 0x00049CD0 File Offset: 0x00047ED0
		' (set) Token: 0x060096DA RID: 38618 RVA: 0x00049CDA File Offset: 0x00047EDA
		Friend Overridable Property Label1 As Label

		' Token: 0x1700380B RID: 14347
		' (get) Token: 0x060096DB RID: 38619 RVA: 0x00049CE3 File Offset: 0x00047EE3
		' (set) Token: 0x060096DC RID: 38620 RVA: 0x00049CED File Offset: 0x00047EED
		Friend Overridable Property lblCPhone As Label

		' Token: 0x1700380C RID: 14348
		' (get) Token: 0x060096DD RID: 38621 RVA: 0x00049CF6 File Offset: 0x00047EF6
		' (set) Token: 0x060096DE RID: 38622 RVA: 0x006CBBE8 File Offset: 0x006C9DE8
		Private _Button39 As Button
		Friend Overridable Property Button39 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button39
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button39_Click
				Dim button As Button = Me._Button39
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button39 = value
				button = Me._Button39
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700380D RID: 14349
		' (get) Token: 0x060096DF RID: 38623 RVA: 0x00049D00 File Offset: 0x00047F00
		' (set) Token: 0x060096E0 RID: 38624 RVA: 0x00049D0A File Offset: 0x00047F0A
		Friend Overridable Property F2 As TextBox

		' Token: 0x1700380E RID: 14350
		' (get) Token: 0x060096E1 RID: 38625 RVA: 0x00049D13 File Offset: 0x00047F13
		' (set) Token: 0x060096E2 RID: 38626 RVA: 0x00049D1D File Offset: 0x00047F1D
		Friend Overridable Property F1 As TextBox

		' Token: 0x1700380F RID: 14351
		' (get) Token: 0x060096E3 RID: 38627 RVA: 0x00049D26 File Offset: 0x00047F26
		' (set) Token: 0x060096E4 RID: 38628 RVA: 0x00049D30 File Offset: 0x00047F30
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17003810 RID: 14352
		' (get) Token: 0x060096E5 RID: 38629 RVA: 0x00049D39 File Offset: 0x00047F39
		' (set) Token: 0x060096E6 RID: 38630 RVA: 0x006CBC2C File Offset: 0x006C9E2C
		Private _Button35 As Button
		Friend Overridable Property Button35 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button35_Click
				Dim button As Button = Me._Button35
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button35 = value
				button = Me._Button35
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003811 RID: 14353
		' (get) Token: 0x060096E7 RID: 38631 RVA: 0x00049D43 File Offset: 0x00047F43
		' (set) Token: 0x060096E8 RID: 38632 RVA: 0x006CBC70 File Offset: 0x006C9E70
		Private _txtNP As TextBox
		Friend Overridable Property txtNP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNP_KeyDown
				Dim textBox As TextBox = Me._txtNP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNP = value
				textBox = Me._txtNP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003812 RID: 14354
		' (get) Token: 0x060096E9 RID: 38633 RVA: 0x00049D4D File Offset: 0x00047F4D
		' (set) Token: 0x060096EA RID: 38634 RVA: 0x00049D57 File Offset: 0x00047F57
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17003813 RID: 14355
		' (get) Token: 0x060096EB RID: 38635 RVA: 0x00049D60 File Offset: 0x00047F60
		' (set) Token: 0x060096EC RID: 38636 RVA: 0x00049D6A File Offset: 0x00047F6A
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17003814 RID: 14356
		' (get) Token: 0x060096ED RID: 38637 RVA: 0x00049D73 File Offset: 0x00047F73
		' (set) Token: 0x060096EE RID: 38638 RVA: 0x00049D7D File Offset: 0x00047F7D
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17003815 RID: 14357
		' (get) Token: 0x060096EF RID: 38639 RVA: 0x00049D86 File Offset: 0x00047F86
		' (set) Token: 0x060096F0 RID: 38640 RVA: 0x00049D90 File Offset: 0x00047F90
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17003816 RID: 14358
		' (get) Token: 0x060096F1 RID: 38641 RVA: 0x00049D99 File Offset: 0x00047F99
		' (set) Token: 0x060096F2 RID: 38642 RVA: 0x00049DA3 File Offset: 0x00047FA3
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x17003817 RID: 14359
		' (get) Token: 0x060096F3 RID: 38643 RVA: 0x00049DAC File Offset: 0x00047FAC
		' (set) Token: 0x060096F4 RID: 38644 RVA: 0x006CBCB4 File Offset: 0x006C9EB4
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox10_TextChanged
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003818 RID: 14360
		' (get) Token: 0x060096F5 RID: 38645 RVA: 0x00049DB6 File Offset: 0x00047FB6
		' (set) Token: 0x060096F6 RID: 38646 RVA: 0x00049DC0 File Offset: 0x00047FC0
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17003819 RID: 14361
		' (get) Token: 0x060096F7 RID: 38647 RVA: 0x00049DC9 File Offset: 0x00047FC9
		' (set) Token: 0x060096F8 RID: 38648 RVA: 0x00049DD3 File Offset: 0x00047FD3
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x1700381A RID: 14362
		' (get) Token: 0x060096F9 RID: 38649 RVA: 0x00049DDC File Offset: 0x00047FDC
		' (set) Token: 0x060096FA RID: 38650 RVA: 0x00049DE6 File Offset: 0x00047FE6
		Friend Overridable Property txtTempAmt As TextBox

		' Token: 0x1700381B RID: 14363
		' (get) Token: 0x060096FB RID: 38651 RVA: 0x00049DEF File Offset: 0x00047FEF
		' (set) Token: 0x060096FC RID: 38652 RVA: 0x00049DF9 File Offset: 0x00047FF9
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700381C RID: 14364
		' (get) Token: 0x060096FD RID: 38653 RVA: 0x00049E02 File Offset: 0x00048002
		' (set) Token: 0x060096FE RID: 38654 RVA: 0x00049E0C File Offset: 0x0004800C
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700381D RID: 14365
		' (get) Token: 0x060096FF RID: 38655 RVA: 0x00049E15 File Offset: 0x00048015
		' (set) Token: 0x06009700 RID: 38656 RVA: 0x00049E1F File Offset: 0x0004801F
		Friend Overridable Property lblUserType As Label

		' Token: 0x1700381E RID: 14366
		' (get) Token: 0x06009701 RID: 38657 RVA: 0x00049E28 File Offset: 0x00048028
		' (set) Token: 0x06009702 RID: 38658 RVA: 0x00049E32 File Offset: 0x00048032
		Friend Overridable Property lblSet As Label

		' Token: 0x1700381F RID: 14367
		' (get) Token: 0x06009703 RID: 38659 RVA: 0x00049E3B File Offset: 0x0004803B
		' (set) Token: 0x06009704 RID: 38660 RVA: 0x00049E45 File Offset: 0x00048045
		Friend Overridable Property lblUser As Label

		' Token: 0x17003820 RID: 14368
		' (get) Token: 0x06009705 RID: 38661 RVA: 0x00049E4E File Offset: 0x0004804E
		' (set) Token: 0x06009706 RID: 38662 RVA: 0x00049E58 File Offset: 0x00048058
		Friend Overridable Property txtCustID As TextBox

		' Token: 0x17003821 RID: 14369
		' (get) Token: 0x06009707 RID: 38663 RVA: 0x00049E61 File Offset: 0x00048061
		' (set) Token: 0x06009708 RID: 38664 RVA: 0x00049E6B File Offset: 0x0004806B
		Friend Overridable Property txtT_ID As TextBox

		' Token: 0x17003822 RID: 14370
		' (get) Token: 0x06009709 RID: 38665 RVA: 0x00049E74 File Offset: 0x00048074
		' (set) Token: 0x0600970A RID: 38666 RVA: 0x00049E7E File Offset: 0x0004807E
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x17003823 RID: 14371
		' (get) Token: 0x0600970B RID: 38667 RVA: 0x00049E87 File Offset: 0x00048087
		' (set) Token: 0x0600970C RID: 38668 RVA: 0x006CBCF8 File Offset: 0x006C9EF8
		Private _txtPrev As Button
		Friend Overridable Property txtPrev As Button
			<CompilerGenerated()>
			Get
				Return Me._txtPrev
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.txtPrev_Click
				Dim button As Button = Me._txtPrev
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtPrev = value
				button = Me._txtPrev
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003824 RID: 14372
		' (get) Token: 0x0600970D RID: 38669 RVA: 0x00049E91 File Offset: 0x00048091
		' (set) Token: 0x0600970E RID: 38670 RVA: 0x006CBD3C File Offset: 0x006C9F3C
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003825 RID: 14373
		' (get) Token: 0x0600970F RID: 38671 RVA: 0x00049E9B File Offset: 0x0004809B
		' (set) Token: 0x06009710 RID: 38672 RVA: 0x006CBD80 File Offset: 0x006C9F80
		Private _btnLast As Button
		Friend Overridable Property btnLast As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLast
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLast_Click
				Dim button As Button = Me._btnLast
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLast = value
				button = Me._btnLast
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003826 RID: 14374
		' (get) Token: 0x06009711 RID: 38673 RVA: 0x00049EA5 File Offset: 0x000480A5
		' (set) Token: 0x06009712 RID: 38674 RVA: 0x00049EAF File Offset: 0x000480AF
		Friend Overridable Property Label10 As Label

		' Token: 0x17003827 RID: 14375
		' (get) Token: 0x06009713 RID: 38675 RVA: 0x00049EB8 File Offset: 0x000480B8
		' (set) Token: 0x06009714 RID: 38676 RVA: 0x006CBDC4 File Offset: 0x006C9FC4
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerID_TextChanged
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003828 RID: 14376
		' (get) Token: 0x06009715 RID: 38677 RVA: 0x00049EC2 File Offset: 0x000480C2
		' (set) Token: 0x06009716 RID: 38678 RVA: 0x00049ECC File Offset: 0x000480CC
		Friend Overridable Property lblBalance As Label

		' Token: 0x17003829 RID: 14377
		' (get) Token: 0x06009717 RID: 38679 RVA: 0x00049ED5 File Offset: 0x000480D5
		' (set) Token: 0x06009718 RID: 38680 RVA: 0x00049EDF File Offset: 0x000480DF
		Friend Overridable Property Label11 As Label

		' Token: 0x1700382A RID: 14378
		' (get) Token: 0x06009719 RID: 38681 RVA: 0x00049EE8 File Offset: 0x000480E8
		' (set) Token: 0x0600971A RID: 38682 RVA: 0x00049EF2 File Offset: 0x000480F2
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x1700382B RID: 14379
		' (get) Token: 0x0600971B RID: 38683 RVA: 0x00049EFB File Offset: 0x000480FB
		' (set) Token: 0x0600971C RID: 38684 RVA: 0x00049F05 File Offset: 0x00048105
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x1700382C RID: 14380
		' (get) Token: 0x0600971D RID: 38685 RVA: 0x00049F0E File Offset: 0x0004810E
		' (set) Token: 0x0600971E RID: 38686 RVA: 0x00049F18 File Offset: 0x00048118
		Friend Overridable Property Label26 As Label

		' Token: 0x1700382D RID: 14381
		' (get) Token: 0x0600971F RID: 38687 RVA: 0x00049F21 File Offset: 0x00048121
		' (set) Token: 0x06009720 RID: 38688 RVA: 0x00049F2B File Offset: 0x0004812B
		Friend Overridable Property Label30 As Label

		' Token: 0x1700382E RID: 14382
		' (get) Token: 0x06009721 RID: 38689 RVA: 0x00049F34 File Offset: 0x00048134
		' (set) Token: 0x06009722 RID: 38690 RVA: 0x00049F3E File Offset: 0x0004813E
		Friend Overridable Property Label36 As Label

		' Token: 0x1700382F RID: 14383
		' (get) Token: 0x06009723 RID: 38691 RVA: 0x00049F47 File Offset: 0x00048147
		' (set) Token: 0x06009724 RID: 38692 RVA: 0x00049F51 File Offset: 0x00048151
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17003830 RID: 14384
		' (get) Token: 0x06009725 RID: 38693 RVA: 0x00049F5A File Offset: 0x0004815A
		' (set) Token: 0x06009726 RID: 38694 RVA: 0x00049F64 File Offset: 0x00048164
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003831 RID: 14385
		' (get) Token: 0x06009727 RID: 38695 RVA: 0x00049F6D File Offset: 0x0004816D
		' (set) Token: 0x06009728 RID: 38696 RVA: 0x006CBE08 File Offset: 0x006CA008
		Private _Button29 As GelButton
		Friend Overridable Property Button29 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button29
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button29_Click
				Dim gelButton As GelButton = Me._Button29
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button29 = value
				gelButton = Me._Button29
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003832 RID: 14386
		' (get) Token: 0x06009729 RID: 38697 RVA: 0x00049F77 File Offset: 0x00048177
		' (set) Token: 0x0600972A RID: 38698 RVA: 0x00049F81 File Offset: 0x00048181
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17003833 RID: 14387
		' (get) Token: 0x0600972B RID: 38699 RVA: 0x00049F8A File Offset: 0x0004818A
		' (set) Token: 0x0600972C RID: 38700 RVA: 0x00049F94 File Offset: 0x00048194
		Friend Overridable Property cmbprintcopy As ComboBox

		' Token: 0x17003834 RID: 14388
		' (get) Token: 0x0600972D RID: 38701 RVA: 0x00049F9D File Offset: 0x0004819D
		' (set) Token: 0x0600972E RID: 38702 RVA: 0x00049FA7 File Offset: 0x000481A7
		Friend Overridable Property Button2 As GelButton

		' Token: 0x17003835 RID: 14389
		' (get) Token: 0x0600972F RID: 38703 RVA: 0x00049FB0 File Offset: 0x000481B0
		' (set) Token: 0x06009730 RID: 38704 RVA: 0x006CBE4C File Offset: 0x006CA04C
		Private _Button6 As GelButton
		Friend Overridable Property Button6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim gelButton As GelButton = Me._Button6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button6 = value
				gelButton = Me._Button6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003836 RID: 14390
		' (get) Token: 0x06009731 RID: 38705 RVA: 0x00049FBA File Offset: 0x000481BA
		' (set) Token: 0x06009732 RID: 38706 RVA: 0x006CBE90 File Offset: 0x006CA090
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

		' Token: 0x17003837 RID: 14391
		' (get) Token: 0x06009733 RID: 38707 RVA: 0x00049FC4 File Offset: 0x000481C4
		' (set) Token: 0x06009734 RID: 38708 RVA: 0x006CBED4 File Offset: 0x006CA0D4
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003838 RID: 14392
		' (get) Token: 0x06009735 RID: 38709 RVA: 0x00049FCE File Offset: 0x000481CE
		' (set) Token: 0x06009736 RID: 38710 RVA: 0x006CBF18 File Offset: 0x006CA118
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003839 RID: 14393
		' (get) Token: 0x06009737 RID: 38711 RVA: 0x00049FD8 File Offset: 0x000481D8
		' (set) Token: 0x06009738 RID: 38712 RVA: 0x006CBF5C File Offset: 0x006CA15C
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700383A RID: 14394
		' (get) Token: 0x06009739 RID: 38713 RVA: 0x00049FE2 File Offset: 0x000481E2
		' (set) Token: 0x0600973A RID: 38714 RVA: 0x006CBFA0 File Offset: 0x006CA1A0
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click_1
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

		' Token: 0x1700383B RID: 14395
		' (get) Token: 0x0600973B RID: 38715 RVA: 0x00049FEC File Offset: 0x000481EC
		' (set) Token: 0x0600973C RID: 38716 RVA: 0x006CBFE4 File Offset: 0x006CA1E4
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700383C RID: 14396
		' (get) Token: 0x0600973D RID: 38717 RVA: 0x00049FF6 File Offset: 0x000481F6
		' (set) Token: 0x0600973E RID: 38718 RVA: 0x0004A000 File Offset: 0x00048200
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700383D RID: 14397
		' (get) Token: 0x0600973F RID: 38719 RVA: 0x0004A009 File Offset: 0x00048209
		' (set) Token: 0x06009740 RID: 38720 RVA: 0x0004A013 File Offset: 0x00048213
		Friend Overridable Property Label6 As Label

		' Token: 0x1700383E RID: 14398
		' (get) Token: 0x06009741 RID: 38721 RVA: 0x0004A01C File Offset: 0x0004821C
		' (set) Token: 0x06009742 RID: 38722 RVA: 0x006CC028 File Offset: 0x006CA228
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

		' Token: 0x1700383F RID: 14399
		' (get) Token: 0x06009743 RID: 38723 RVA: 0x0004A026 File Offset: 0x00048226
		' (set) Token: 0x06009744 RID: 38724 RVA: 0x0004A030 File Offset: 0x00048230
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17003840 RID: 14400
		' (get) Token: 0x06009745 RID: 38725 RVA: 0x0004A039 File Offset: 0x00048239
		' (set) Token: 0x06009746 RID: 38726 RVA: 0x0004A043 File Offset: 0x00048243
		Friend Overridable Property Label74 As Label

		' Token: 0x17003841 RID: 14401
		' (get) Token: 0x06009747 RID: 38727 RVA: 0x0004A04C File Offset: 0x0004824C
		' (set) Token: 0x06009748 RID: 38728 RVA: 0x006CC06C File Offset: 0x006CA26C
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003842 RID: 14402
		' (get) Token: 0x06009749 RID: 38729 RVA: 0x0004A056 File Offset: 0x00048256
		' (set) Token: 0x0600974A RID: 38730 RVA: 0x006CC0B0 File Offset: 0x006CA2B0
		Private _txtPaymentModeDetails As RichTextBox
		Friend Overridable Property txtPaymentModeDetails As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPaymentModeDetails
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPaymentModeDetails_KeyDown
				Dim richTextBox As RichTextBox = Me._txtPaymentModeDetails
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtPaymentModeDetails = value
				richTextBox = Me._txtPaymentModeDetails
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003843 RID: 14403
		' (get) Token: 0x0600974B RID: 38731 RVA: 0x0004A060 File Offset: 0x00048260
		' (set) Token: 0x0600974C RID: 38732 RVA: 0x0004A06A File Offset: 0x0004826A
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17003844 RID: 14404
		' (get) Token: 0x0600974D RID: 38733 RVA: 0x0004A073 File Offset: 0x00048273
		' (set) Token: 0x0600974E RID: 38734 RVA: 0x0004A07D File Offset: 0x0004827D
		Friend Overridable Property Label4 As Label

		' Token: 0x17003845 RID: 14405
		' (get) Token: 0x0600974F RID: 38735 RVA: 0x0004A086 File Offset: 0x00048286
		' (set) Token: 0x06009750 RID: 38736 RVA: 0x006CC0F4 File Offset: 0x006CA2F4
		Private _cmbPaymentMode As ComboBox
		Friend Overridable Property cmbPaymentMode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPaymentMode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPaymentMode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.cmbPaymentMode_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbPaymentMode = value
				comboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003846 RID: 14406
		' (get) Token: 0x06009751 RID: 38737 RVA: 0x0004A090 File Offset: 0x00048290
		' (set) Token: 0x06009752 RID: 38738 RVA: 0x0004A09A File Offset: 0x0004829A
		Friend Overridable Property Label5 As Label

		' Token: 0x17003847 RID: 14407
		' (get) Token: 0x06009753 RID: 38739 RVA: 0x0004A0A3 File Offset: 0x000482A3
		' (set) Token: 0x06009754 RID: 38740 RVA: 0x006CC170 File Offset: 0x006CA370
		Private _dtpTranactionDate As DateTimePicker
		Friend Overridable Property dtpTranactionDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpTranactionDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpTranactionDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpTranactionDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpTranactionDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpTranactionDate = value
				dateTimePicker = Me._dtpTranactionDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003848 RID: 14408
		' (get) Token: 0x06009755 RID: 38741 RVA: 0x0004A0AD File Offset: 0x000482AD
		' (set) Token: 0x06009756 RID: 38742 RVA: 0x0004A0B7 File Offset: 0x000482B7
		Friend Overridable Property Label3 As Label

		' Token: 0x17003849 RID: 14409
		' (get) Token: 0x06009757 RID: 38743 RVA: 0x0004A0C0 File Offset: 0x000482C0
		' (set) Token: 0x06009758 RID: 38744 RVA: 0x0004A0CA File Offset: 0x000482CA
		Friend Overridable Property txtTransactionNo As TextBox

		' Token: 0x1700384A RID: 14410
		' (get) Token: 0x06009759 RID: 38745 RVA: 0x0004A0D3 File Offset: 0x000482D3
		' (set) Token: 0x0600975A RID: 38746 RVA: 0x0004A0DD File Offset: 0x000482DD
		Friend Overridable Property Label2 As Label

		' Token: 0x1700384B RID: 14411
		' (get) Token: 0x0600975B RID: 38747 RVA: 0x0004A0E6 File Offset: 0x000482E6
		' (set) Token: 0x0600975C RID: 38748 RVA: 0x006CC1D0 File Offset: 0x006CA3D0
		Private _txtTransactionAmount As TextBox
		Friend Overridable Property txtTransactionAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTransactionAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtTotalPaid_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtTransactionAmount_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTransactionAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtTransactionAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtTransactionAmount = value
				textBox = Me._txtTransactionAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700384C RID: 14412
		' (get) Token: 0x0600975D RID: 38749 RVA: 0x0004A0F0 File Offset: 0x000482F0
		' (set) Token: 0x0600975E RID: 38750 RVA: 0x0004A0FA File Offset: 0x000482FA
		Friend Overridable Property Label19 As Label

		' Token: 0x1700384D RID: 14413
		' (get) Token: 0x0600975F RID: 38751 RVA: 0x0004A103 File Offset: 0x00048303
		' (set) Token: 0x06009760 RID: 38752 RVA: 0x0004A10D File Offset: 0x0004830D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700384E RID: 14414
		' (get) Token: 0x06009761 RID: 38753 RVA: 0x0004A116 File Offset: 0x00048316
		' (set) Token: 0x06009762 RID: 38754 RVA: 0x0004A120 File Offset: 0x00048320
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700384F RID: 14415
		' (get) Token: 0x06009763 RID: 38755 RVA: 0x0004A129 File Offset: 0x00048329
		' (set) Token: 0x06009764 RID: 38756 RVA: 0x0004A133 File Offset: 0x00048333
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003850 RID: 14416
		' (get) Token: 0x06009765 RID: 38757 RVA: 0x0004A13C File Offset: 0x0004833C
		' (set) Token: 0x06009766 RID: 38758 RVA: 0x0004A146 File Offset: 0x00048346
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003851 RID: 14417
		' (get) Token: 0x06009767 RID: 38759 RVA: 0x0004A14F File Offset: 0x0004834F
		' (set) Token: 0x06009768 RID: 38760 RVA: 0x0004A159 File Offset: 0x00048359
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003852 RID: 14418
		' (get) Token: 0x06009769 RID: 38761 RVA: 0x0004A162 File Offset: 0x00048362
		' (set) Token: 0x0600976A RID: 38762 RVA: 0x0004A16C File Offset: 0x0004836C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x0600976B RID: 38763 RVA: 0x006CC270 File Offset: 0x006CA470
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtcompname.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
					Me.bankacno = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.bankifsc = ModCommonClasses.rdr.GetValue(6).ToString()
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

		' Token: 0x0600976C RID: 38764 RVA: 0x006CC408 File Offset: 0x006CA608
		Public Sub GetCustomerBalance()
			Try
				Try
					Me.num1 = 0D
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBooksalesman1 where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Me.lblBalance.ForeColor = Color.DarkGreen
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "Cr"
						Me.lblBalance.ForeColor = Color.Blue
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "Dr"
							Me.lblBalance.ForeColor = Color.Red
						End If
					End If
					Me.lblBalance.Text = Conversions.ToString(Math.Abs(Conversion.Val(Me.lblBalance.Text)))
					Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600976D RID: 38765 RVA: 0x006CC64C File Offset: 0x006CA84C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 T_ID FROM CreditSalesManPayment ORDER BY T_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("T_ID"))
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

		' Token: 0x0600976E RID: 38766 RVA: 0x006CC7B8 File Offset: 0x006CA9B8
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrReceiptSalesMan ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600976F RID: 38767 RVA: 0x006CC924 File Offset: 0x006CAB24
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c6),RTRIM(c16) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "RCPT"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "RCPT"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009770 RID: 38768 RVA: 0x006CCAFC File Offset: 0x006CACFC
		Public Sub auto()
			Try
				Me.txtT_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtTransactionNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009771 RID: 38769 RVA: 0x006CCBAC File Offset: 0x006CADAC
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtRemarks.Text = ""
			Me.txtCustomerID.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.txtTransactionAmount.Text = ""
			Me.txtPaymentModeDetails.Text = ""
			Me.cmbPaymentMode.SelectedIndex = 0
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.lblBalance.Text = "0.00"
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSelection.Enabled = True
			Me.btnPrint.Enabled = False
			Me.Button2.Enabled = False
			Me.txtTransactionNo.Text = ""
			Me.txtT_ID.Text = ""
			Me.cmbprintcopy.SelectedIndex = 0
			Me.btnSelection.Focus()
			Me.auto()
			Me.cmbNP.SelectedIndex = -1
			Me.getdata1()
			Me.dgw.Visible = False
			Me.Label6.Visible = False
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
		End Sub

		' Token: 0x06009772 RID: 38770 RVA: 0x00131C7C File Offset: 0x0012FE7C
		Public Sub FillCustomers()
			Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009773 RID: 38771 RVA: 0x006CCD38 File Offset: 0x006CAF38
		Public Sub GetCustomerInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT SalesMan_ID,Name,Address,ContactNo from SalesMan where SM_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCustomerID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.cmbCustomerName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtAddress.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009774 RID: 38772 RVA: 0x006CCE74 File Offset: 0x006CB074
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from CreditSalesManPayment where T_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LedgerDeleteSalesman(Me.txtTransactionNo.Text, "Receipt")
					ModFunc.SrReceiptDelete(Me.txtTransactionNo.Text)
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the CreditSalesManPayment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillReceiptID()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillReceiptID()
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
				Me.DataforNP()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009775 RID: 38773 RVA: 0x006CD000 File Offset: 0x006CB200
		Private Sub txtTotalPaid_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtTransactionAmount.Text
					Dim selectionStart As Integer = Me.txtTransactionAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtTransactionAmount.SelectionLength
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

		' Token: 0x06009776 RID: 38774 RVA: 0x0004A175 File Offset: 0x00048375
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06009777 RID: 38775 RVA: 0x0004A17F File Offset: 0x0004837F
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06009778 RID: 38776 RVA: 0x006CD0F8 File Offset: 0x006CB2F8
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(Sign) from Registration where UserID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox10.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox9.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009779 RID: 38777 RVA: 0x006CD1EC File Offset: 0x006CB3EC
		Private Sub txtCustNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x0600977A RID: 38778 RVA: 0x006CD1EC File Offset: 0x006CB3EC
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x0600977B RID: 38779 RVA: 0x006CD23C File Offset: 0x006CB43C
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
			Me.getdata1()
			Me.dgw.Visible = True
			Me.Label6.Visible = True
		End Sub

		' Token: 0x0600977C RID: 38780 RVA: 0x006CD2B0 File Offset: 0x006CB4B0
		Private Sub txtTransactionAmount_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) >= 0.0
			If flag Then
				Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(Me.txtTransactionAmount.Text)))
			Else
				Me.txtRsToWords.Text = ""
			End If
		End Sub

		' Token: 0x0600977D RID: 38781 RVA: 0x006CD324 File Offset: 0x006CB524
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
					Me.wappno = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.wappno = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600977E RID: 38782 RVA: 0x006CD418 File Offset: 0x006CB618
		Public Sub Print()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptSalesManPayment As rptSalesManPayment = New rptSalesManPayment()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter2.SelectCommand = sqlCommand
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptSalesManPayment.SetDataSource(dataSet)
				rptSalesManPayment.SetParameterValue("p1", Me.txtCustomerID.Text)
				rptSalesManPayment.SetParameterValue("p2", DateAndTime.Today)
				rptSalesManPayment.SetParameterValue("p3", Me.cmbCustomerName.Text)
				rptSalesManPayment.SetParameterValue("pAmount", Me.txtTransactionAmount.Text)
				rptSalesManPayment.SetParameterValue("pTNO", Me.txtTransactionNo.Text)
				rptSalesManPayment.SetParameterValue("pDate", Me.dtpTranactionDate.Text)
				rptSalesManPayment.SetParameterValue("pRs", Me.txtRsToWords.Text)
				rptSalesManPayment.SetParameterValue("p4", Me.cmbprintcopy.Text)
				rptSalesManPayment.SetParameterValue("0", Me.TextBox9.Text.Trim())
				Dim parameterFields As ParameterFields = New ParameterFields()
				Dim parameterField As ParameterField = New ParameterField()
				Dim parameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
				parameterField.ParameterFieldName = "0"
				parameterDiscreteValue.Value = Me.TextBox9.Text.Trim()
				parameterField.CurrentValues.Add(parameterDiscreteValue)
				parameterFields.Add(parameterField)
				MyProject.Forms.frmReport.CrystalReportViewer1.ParameterFieldInfo = parameterFields
				MyProject.Forms.frmReport.CrystalReportViewer1.Refresh()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalesManPayment
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600977F RID: 38783 RVA: 0x001326D8 File Offset: 0x001308D8
		Public Sub WAPPREPORT()
			Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\WhatsApp")
			If flag Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\WhatsApp\")
			End If
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
		End Sub

		' Token: 0x06009780 RID: 38784 RVA: 0x006CD690 File Offset: 0x006CB890
		Private Sub frmCreditCustomerReceipt_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.DataforNP()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.fillReceiptID()
			Me.wappnodisplay()
			Me.fillAccountInfo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06009781 RID: 38785 RVA: 0x006CD750 File Offset: 0x006CB950
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

		' Token: 0x06009782 RID: 38786 RVA: 0x006CD8C8 File Offset: 0x006CBAC8
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

		' Token: 0x06009783 RID: 38787 RVA: 0x006CD984 File Offset: 0x006CBB84
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

		' Token: 0x06009784 RID: 38788 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06009785 RID: 38789 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06009786 RID: 38790 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06009787 RID: 38791 RVA: 0x006CDA50 File Offset: 0x006CBC50
		Private Sub dtpTranactionDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpTranactionDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpTranactionDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpTranactionDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpTranactionDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009788 RID: 38792 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpTranactionDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009789 RID: 38793 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPaymentMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600978A RID: 38794 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600978B RID: 38795 RVA: 0x006CDAFC File Offset: 0x006CBCFC
		Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustID.Text = ""
				Me.txtCustomerID.Text = ""
				Me.txtAddress.Text = ""
				Me.txtContactNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN) from Customer where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCustID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.GetCustomerBalance()
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

		' Token: 0x0600978C RID: 38796 RVA: 0x006CDCB8 File Offset: 0x006CBEB8
		Private Sub getdata1()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = New SqlCommand("Select Date, RTRIM(Name), RTRIM(LedgerNo), RTRIM(Label), Debit, Credit from LedgerBooksalesman1 where PartyID=@d1 order by Date DESC", ModCommonClasses.con1)
				ModCommonClasses.cmd1.CommandTimeout = 0
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.txtCustID.Text)
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5) })
				End While
				ModCommonClasses.con1.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600978D RID: 38797 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTransactionAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600978E RID: 38798 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPaymentModeDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600978F RID: 38799 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009790 RID: 38800 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009791 RID: 38801 RVA: 0x006CDE04 File Offset: 0x006CC004
		Public Sub fillReceiptID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(T_ID) FROM CreditSalesManPayment order by T_ID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009792 RID: 38802 RVA: 0x006CDF40 File Offset: 0x006CC140
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditSalesManPayment.Remarks),RTRIM(BankAcNo) from Customer,CreditSalesManPayment where Customer.ID=CreditSalesManPayment.Customer_ID and T_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtT_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtTransactionNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpTranactionDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmbPaymentMode.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtCustID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.cmbCustomerName.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtTransactionAmount.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtTempAmt.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtPaymentModeDetails.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.cmbAccountNo.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.GetCustomerInfo()
					Me.btnSelection.Enabled = False
					Me.btnPrint.Enabled = True
					Me.Button2.Enabled = True
					Me.GetCustomerBalance()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009793 RID: 38803 RVA: 0x0004A19B File Offset: 0x0004839B
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06009794 RID: 38804 RVA: 0x006CE1CC File Offset: 0x006CC3CC
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM CreditSalesManPayment", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "CreditSalesManPayment")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("CreditSalesManPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06009795 RID: 38805 RVA: 0x006CE2A8 File Offset: 0x006CC4A8
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtT_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex < Me.cmbNP.Items.Count - 1
				If flag Then
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex + 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("Last Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009796 RID: 38806 RVA: 0x006CE364 File Offset: 0x006CC564
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06009797 RID: 38807 RVA: 0x006CE3B4 File Offset: 0x006CC5B4
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtT_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex > 0
				If flag Then
					' The following expression was wrapped in a checked-expression
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex - 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("First Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009798 RID: 38808 RVA: 0x006CE460 File Offset: 0x006CC660
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("CreditSalesManPayment").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("CreditSalesManPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009799 RID: 38809 RVA: 0x006CE518 File Offset: 0x006CC718
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("CreditSalesManPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600979A RID: 38810 RVA: 0x006CE5B0 File Offset: 0x006CC7B0
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

		' Token: 0x0600979B RID: 38811 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCreditCustomerReceipt_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600979C RID: 38812 RVA: 0x006CE698 File Offset: 0x006CC898
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtTransactionAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtTransactionAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtTransactionAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbPaymentMode.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbCustomerName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbCustomerName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCustomerName, String.Empty)
			End If
		End Sub

		' Token: 0x0600979D RID: 38813 RVA: 0x00014ABA File Offset: 0x00012CBA
		Private Sub Button39_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Form1.ShowDialog()
		End Sub

		' Token: 0x0600979E RID: 38814 RVA: 0x006CE78C File Offset: 0x006CC98C
		Public Sub InvoiceHead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(LIDS) from InvoiceHead"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.InvDateSts = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.InvDateSts = "No"
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

		' Token: 0x0600979F RID: 38815 RVA: 0x006CE884 File Offset: 0x006CCA84
		Private Sub cmbPaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x060097A0 RID: 38816 RVA: 0x0004A175 File Offset: 0x00048375
		Private Sub btnNew_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060097A1 RID: 38817 RVA: 0x006CE91C File Offset: 0x006CCB1C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpTranactionDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from CreditSalesManPayment where Date between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dateTime2
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 vouchers for current month in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
			Me.auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
			If flag4 Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerID.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please retrieve Salesman info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCustomerID.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please select correct SalesMan name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.cmbCustomerName.Focus()
					Else
						Dim flag8 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
						If flag8 Then
							Dim flag9 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
							If flag9 Then
								MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAccountNo.Focus()
								Return
							End If
						End If
						Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtTransactionAmount.Text)) = 0
						If flag10 Then
							MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtTransactionAmount.Focus()
						Else
							Dim flag11 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) = 0.0
							If flag11 Then
								MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtTransactionAmount.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into CreditSalesManPayment(T_ID, TransactionID, Date,PaymentMode, Customer_ID, Amount,Remarks,PaymentModeDetails,BankAcNo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpTranactionDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPaymentMode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCustID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtTransactionAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtPaymentModeDetails.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim flag12 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
									If flag12 Then
										ModFunc.LedgerSaveSalesman(Me.dtpTranactionDate.Value.[Date], "Cash Account", Me.txtTransactionNo.Text, "SalesMan_Payment", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtCustID.Text, Me.txtTransactionNo.Text)
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into SrReceiptSalesMan(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, "added the new CreditSalesManPayment having transaction No. '" + Me.txtTransactionNo.Text + "'")
									Me.btnSave.Enabled = False
									ModCommonClasses.con.Close()
									Try
									Catch ex As Exception
										MessageBox.Show("SMS is not sent", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									Dim flag13 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print the Receipt ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
									If flag13 Then
										Me.Print()
									End If
									Me.fillReceiptID()
								Catch ex2 As Exception
									MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
								Me.DataforNP()
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060097A2 RID: 38818 RVA: 0x006CF074 File Offset: 0x006CD274
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerID.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve credit customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCustomerID.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select correct customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbCustomerName.Focus()
				Else
					Dim flag3 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
					If flag3 Then
						Dim flag4 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbAccountNo.Focus()
							Return
						End If
					End If
					Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtTransactionAmount.Text)) = 0
					If flag5 Then
						MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtTransactionAmount.Focus()
					Else
						Dim flag6 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) = 0.0
						If flag6 Then
							MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtTransactionAmount.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update CreditSalesManPayment set TransactionID=@d2, Date=@d3, PaymentMode=@d4, Customer_ID=@d5, Amount=@d6,Remarks=@d7,PaymentModeDetails=@d8,BankAcNo=@d9 where T_ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpTranactionDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPaymentMode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCustID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtTransactionAmount.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtRemarks.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtPaymentModeDetails.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								Dim flag7 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
								If flag7 Then
									ModFunc.LedgerUpdateSalesman(Me.dtpTranactionDate.Value.[Date], "Cash Account", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtCustID.Text, Me.cmbCustomerName.Text, Me.txtTransactionNo.Text, "SalesMan_Payment")
								End If
								ModFunc.LogFunc(Me.lblUser.Text, "updated CreditSalesManPayment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnUpdate.Enabled = False
								ModCommonClasses.con.Close()
								Me.DataforNP()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060097A3 RID: 38819 RVA: 0x006CF4D8 File Offset: 0x006CD6D8
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

		' Token: 0x060097A4 RID: 38820 RVA: 0x006CF540 File Offset: 0x006CD740
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmSalesManPaymentRecordNew.lblSet.Text = "Payment"
			MyProject.Forms.frmSalesManPaymentRecordNew.Reset()
			MyProject.Forms.frmSalesManPaymentRecordNew.ShowDialog()
			MyProject.Forms.frmSalesManPaymentRecordNew.Dispose()
		End Sub

		' Token: 0x060097A5 RID: 38821 RVA: 0x0004A1B3 File Offset: 0x000483B3
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x060097A6 RID: 38822 RVA: 0x006CF5A0 File Offset: 0x006CD7A0
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSendSMS_Sales.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSendSMS_Sales.Reset()
			MyProject.Forms.frmSendSMS_Sales.btnGetSales.Enabled = False
			MyProject.Forms.frmSendSMS_Sales.Button1.Enabled = False
			MyProject.Forms.frmSendSMS_Sales.btnGetSales.Visible = False
			MyProject.Forms.frmSendSMS_Sales.Button1.Visible = False
			MyProject.Forms.frmSendSMS_Sales.txtMobileNo.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			MyProject.Forms.frmSendSMS_Sales.txtMessage.Text = String.Concat(New String() { "Dear Sir/Madam, ", Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}), ", Thank you for payment to us. Your Receipt No. ", Me.txtTransactionNo.Text.TrimEnd(New Char(-1) {}), ", Date. ", Me.dtpTranactionDate.Text.TrimEnd(New Char(-1) {}), " , Amount is Rs.", Strings.Format(Math.Round(Conversion.Val(Me.txtTransactionAmount.Text), 2), "0.00").TrimEnd(New Char(-1) {}), ", Best wishes from ", Me.txtcompname.Text.Trim(), "." })
			MyProject.Forms.frmSendSMS_Sales.ShowDialog()
			MyProject.Forms.frmSendSMS_Sales.Dispose()
		End Sub

		' Token: 0x060097A7 RID: 38823 RVA: 0x006CF768 File Offset: 0x006CD968
		Private Sub Button29_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.cmbPaymentMode.SelectedIndex = 0) Or (Me.cmbPaymentMode.SelectedIndex = 1)
			If flag Then
				MessageBox.Show("Not allowed to Payment of Mode for 'By Cash' and 'By Cheque'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Please fill Bill Amount....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.txtTransactionAmount.Focus()
				Else
					MyProject.Forms.frmAutoUPI.amtamt = Conversions.ToDouble(Me.txtTransactionAmount.Text)
					MyProject.Forms.frmAutoUPI.acac = Me.bankacno
					MyProject.Forms.frmAutoUPI.ifscifsc = Me.bankifsc
					MyProject.Forms.frmAutoUPI.payee = Me.txtcompname.Text
					MyProject.Forms.frmAutoUPI.note = Me.txtTransactionNo.Text
					MyProject.Forms.frmAutoUPI.Label1.Text = "Bill Amount : " + Strings.Format(Math.Round(Conversion.Val(Me.txtTransactionAmount.Text), 2), "0.00")
					MyProject.Forms.frmAutoUPI.ShowDialog()
					MyProject.Forms.frmAutoUPI.Dispose()
				End If
			End If
		End Sub

		' Token: 0x060097A8 RID: 38824 RVA: 0x006CF8D8 File Offset: 0x006CDAD8
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dtpTranactionDate.Focus()
			MyProject.Forms.frmSalesmanRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmSalesmanRecord.Reset()
			MyProject.Forms.frmSalesmanRecord.ShowDialog()
			MyProject.Forms.frmSalesmanRecord.Dispose()
		End Sub

		' Token: 0x060097A9 RID: 38825 RVA: 0x006CF944 File Offset: 0x006CDB44
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from CreditSalesManPayment order by T_ID DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.prevdate = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0).ToString())
				Else
					Me.prevdate = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.InvDateSts, "Yes", False) = 0
				If flag4 Then
					Me.dtpTranactionDate.Value = Me.prevdate
				Else
					Me.dtpTranactionDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060097AA RID: 38826 RVA: 0x001359A8 File Offset: 0x00133BA8
		Private Sub frmCreditCustomerReceipt_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Directory.Exists(MyProject.Application.Info.DirectoryPath + "\WhatsApp")
			If flag Then
				Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
				For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
					File.Delete(text2)
				Next
			End If
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x060097AB RID: 38827 RVA: 0x006CFA84 File Offset: 0x006CDC84
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

		' Token: 0x04004303 RID: 17155
		Private str As String

		' Token: 0x04004304 RID: 17156
		Private OBType As String

		' Token: 0x04004305 RID: 17157
		Private num1 As Decimal

		' Token: 0x04004306 RID: 17158
		Private num2 As Decimal

		' Token: 0x04004307 RID: 17159
		Private num3 As Decimal

		' Token: 0x04004308 RID: 17160
		Private num4 As Decimal

		' Token: 0x04004309 RID: 17161
		Private i As Integer

		' Token: 0x0400430A RID: 17162
		Private st2 As String

		' Token: 0x0400430B RID: 17163
		Private wappno As String

		' Token: 0x0400430C RID: 17164
		Private bankacno As String

		' Token: 0x0400430D RID: 17165
		Private bankifsc As String

		' Token: 0x0400430E RID: 17166
		Private bankholdername As String

		' Token: 0x0400430F RID: 17167
		Private ntid As String

		' Token: 0x04004310 RID: 17168
		Private a As Double

		' Token: 0x04004311 RID: 17169
		Private sts2 As String

		' Token: 0x04004312 RID: 17170
		Private stw1 As String

		' Token: 0x04004313 RID: 17171
		Private WhatsApppdfFile As String

		' Token: 0x04004314 RID: 17172
		Private Dad As SqlDataAdapter

		' Token: 0x04004315 RID: 17173
		Private Dst As DataSet

		' Token: 0x04004316 RID: 17174
		Private CurrentRow As Object

		' Token: 0x04004317 RID: 17175
		Private InvDateSts As String

		' Token: 0x04004318 RID: 17176
		Private prevdate As DateTime
	End Class
End Namespace
