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
Imports DevNet.Models
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000299 RID: 665
	<DesignerGenerated()>
	Public Partial Class frmCreditCustomerReceipt
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A7E8 RID: 42984 RVA: 0x00706C8C File Offset: 0x00704E8C
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

		' Token: 0x17004110 RID: 16656
		' (get) Token: 0x0600A7EB RID: 42987 RVA: 0x0004E527 File Offset: 0x0004C727
		' (set) Token: 0x0600A7EC RID: 42988 RVA: 0x0004E531 File Offset: 0x0004C731
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004111 RID: 16657
		' (get) Token: 0x0600A7ED RID: 42989 RVA: 0x0004E53A File Offset: 0x0004C73A
		' (set) Token: 0x0600A7EE RID: 42990 RVA: 0x0004E544 File Offset: 0x0004C744
		Friend Overridable Property Label3 As Label

		' Token: 0x17004112 RID: 16658
		' (get) Token: 0x0600A7EF RID: 42991 RVA: 0x0004E54D File Offset: 0x0004C74D
		' (set) Token: 0x0600A7F0 RID: 42992 RVA: 0x0004E557 File Offset: 0x0004C757
		Friend Overridable Property txtTransactionNo As TextBox

		' Token: 0x17004113 RID: 16659
		' (get) Token: 0x0600A7F1 RID: 42993 RVA: 0x0004E560 File Offset: 0x0004C760
		' (set) Token: 0x0600A7F2 RID: 42994 RVA: 0x0004E56A File Offset: 0x0004C76A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004114 RID: 16660
		' (get) Token: 0x0600A7F3 RID: 42995 RVA: 0x0004E573 File Offset: 0x0004C773
		' (set) Token: 0x0600A7F4 RID: 42996 RVA: 0x0004E57D File Offset: 0x0004C77D
		Friend Overridable Property Label1 As Label

		' Token: 0x17004115 RID: 16661
		' (get) Token: 0x0600A7F5 RID: 42997 RVA: 0x0004E586 File Offset: 0x0004C786
		' (set) Token: 0x0600A7F6 RID: 42998 RVA: 0x0004E590 File Offset: 0x0004C790
		Friend Overridable Property Label2 As Label

		' Token: 0x17004116 RID: 16662
		' (get) Token: 0x0600A7F7 RID: 42999 RVA: 0x0004E599 File Offset: 0x0004C799
		' (set) Token: 0x0600A7F8 RID: 43000 RVA: 0x0004E5A3 File Offset: 0x0004C7A3
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004117 RID: 16663
		' (get) Token: 0x0600A7F9 RID: 43001 RVA: 0x0004E5AC File Offset: 0x0004C7AC
		' (set) Token: 0x0600A7FA RID: 43002 RVA: 0x0070AC84 File Offset: 0x00708E84
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

		' Token: 0x17004118 RID: 16664
		' (get) Token: 0x0600A7FB RID: 43003 RVA: 0x0004E5B6 File Offset: 0x0004C7B6
		' (set) Token: 0x0600A7FC RID: 43004 RVA: 0x0070ACE4 File Offset: 0x00708EE4
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

		' Token: 0x17004119 RID: 16665
		' (get) Token: 0x0600A7FD RID: 43005 RVA: 0x0004E5C0 File Offset: 0x0004C7C0
		' (set) Token: 0x0600A7FE RID: 43006 RVA: 0x0004E5CA File Offset: 0x0004C7CA
		Friend Overridable Property Label12 As Label

		' Token: 0x1700411A RID: 16666
		' (get) Token: 0x0600A7FF RID: 43007 RVA: 0x0004E5D3 File Offset: 0x0004C7D3
		' (set) Token: 0x0600A800 RID: 43008 RVA: 0x0004E5DD File Offset: 0x0004C7DD
		Friend Overridable Property txtCustID As TextBox

		' Token: 0x1700411B RID: 16667
		' (get) Token: 0x0600A801 RID: 43009 RVA: 0x0004E5E6 File Offset: 0x0004C7E6
		' (set) Token: 0x0600A802 RID: 43010 RVA: 0x0004E5F0 File Offset: 0x0004C7F0
		Friend Overridable Property txtT_ID As TextBox

		' Token: 0x1700411C RID: 16668
		' (get) Token: 0x0600A803 RID: 43011 RVA: 0x0004E5F9 File Offset: 0x0004C7F9
		' (set) Token: 0x0600A804 RID: 43012 RVA: 0x0004E603 File Offset: 0x0004C803
		Friend Overridable Property lblUser As Label

		' Token: 0x1700411D RID: 16669
		' (get) Token: 0x0600A805 RID: 43013 RVA: 0x0004E60C File Offset: 0x0004C80C
		' (set) Token: 0x0600A806 RID: 43014 RVA: 0x0004E616 File Offset: 0x0004C816
		Friend Overridable Property lblSet As Label

		' Token: 0x1700411E RID: 16670
		' (get) Token: 0x0600A807 RID: 43015 RVA: 0x0004E61F File Offset: 0x0004C81F
		' (set) Token: 0x0600A808 RID: 43016 RVA: 0x0004E629 File Offset: 0x0004C829
		Friend Overridable Property lblUserType As Label

		' Token: 0x1700411F RID: 16671
		' (get) Token: 0x0600A809 RID: 43017 RVA: 0x0004E632 File Offset: 0x0004C832
		' (set) Token: 0x0600A80A RID: 43018 RVA: 0x0004E63C File Offset: 0x0004C83C
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x17004120 RID: 16672
		' (get) Token: 0x0600A80B RID: 43019 RVA: 0x0004E645 File Offset: 0x0004C845
		' (set) Token: 0x0600A80C RID: 43020 RVA: 0x0070AD28 File Offset: 0x00708F28
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

		' Token: 0x17004121 RID: 16673
		' (get) Token: 0x0600A80D RID: 43021 RVA: 0x0004E64F File Offset: 0x0004C84F
		' (set) Token: 0x0600A80E RID: 43022 RVA: 0x0004E659 File Offset: 0x0004C859
		Friend Overridable Property Label10 As Label

		' Token: 0x17004122 RID: 16674
		' (get) Token: 0x0600A80F RID: 43023 RVA: 0x0004E662 File Offset: 0x0004C862
		' (set) Token: 0x0600A810 RID: 43024 RVA: 0x0070AD6C File Offset: 0x00708F6C
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

		' Token: 0x17004123 RID: 16675
		' (get) Token: 0x0600A811 RID: 43025 RVA: 0x0004E66C File Offset: 0x0004C86C
		' (set) Token: 0x0600A812 RID: 43026 RVA: 0x0004E676 File Offset: 0x0004C876
		Friend Overridable Property lblBalance As Label

		' Token: 0x17004124 RID: 16676
		' (get) Token: 0x0600A813 RID: 43027 RVA: 0x0004E67F File Offset: 0x0004C87F
		' (set) Token: 0x0600A814 RID: 43028 RVA: 0x0004E689 File Offset: 0x0004C889
		Friend Overridable Property Label11 As Label

		' Token: 0x17004125 RID: 16677
		' (get) Token: 0x0600A815 RID: 43029 RVA: 0x0004E692 File Offset: 0x0004C892
		' (set) Token: 0x0600A816 RID: 43030 RVA: 0x0004E69C File Offset: 0x0004C89C
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17004126 RID: 16678
		' (get) Token: 0x0600A817 RID: 43031 RVA: 0x0004E6A5 File Offset: 0x0004C8A5
		' (set) Token: 0x0600A818 RID: 43032 RVA: 0x0004E6AF File Offset: 0x0004C8AF
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17004127 RID: 16679
		' (get) Token: 0x0600A819 RID: 43033 RVA: 0x0004E6B8 File Offset: 0x0004C8B8
		' (set) Token: 0x0600A81A RID: 43034 RVA: 0x0004E6C2 File Offset: 0x0004C8C2
		Friend Overridable Property Label26 As Label

		' Token: 0x17004128 RID: 16680
		' (get) Token: 0x0600A81B RID: 43035 RVA: 0x0004E6CB File Offset: 0x0004C8CB
		' (set) Token: 0x0600A81C RID: 43036 RVA: 0x0004E6D5 File Offset: 0x0004C8D5
		Friend Overridable Property Label30 As Label

		' Token: 0x17004129 RID: 16681
		' (get) Token: 0x0600A81D RID: 43037 RVA: 0x0004E6DE File Offset: 0x0004C8DE
		' (set) Token: 0x0600A81E RID: 43038 RVA: 0x0004E6E8 File Offset: 0x0004C8E8
		Friend Overridable Property Label36 As Label

		' Token: 0x1700412A RID: 16682
		' (get) Token: 0x0600A81F RID: 43039 RVA: 0x0004E6F1 File Offset: 0x0004C8F1
		' (set) Token: 0x0600A820 RID: 43040 RVA: 0x0004E6FB File Offset: 0x0004C8FB
		Friend Overridable Property Label19 As Label

		' Token: 0x1700412B RID: 16683
		' (get) Token: 0x0600A821 RID: 43041 RVA: 0x0004E704 File Offset: 0x0004C904
		' (set) Token: 0x0600A822 RID: 43042 RVA: 0x0070ADB0 File Offset: 0x00708FB0
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

		' Token: 0x1700412C RID: 16684
		' (get) Token: 0x0600A823 RID: 43043 RVA: 0x0004E70E File Offset: 0x0004C90E
		' (set) Token: 0x0600A824 RID: 43044 RVA: 0x0070AE50 File Offset: 0x00709050
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

		' Token: 0x1700412D RID: 16685
		' (get) Token: 0x0600A825 RID: 43045 RVA: 0x0004E718 File Offset: 0x0004C918
		' (set) Token: 0x0600A826 RID: 43046 RVA: 0x0004E722 File Offset: 0x0004C922
		Friend Overridable Property Label5 As Label

		' Token: 0x1700412E RID: 16686
		' (get) Token: 0x0600A827 RID: 43047 RVA: 0x0004E72B File Offset: 0x0004C92B
		' (set) Token: 0x0600A828 RID: 43048 RVA: 0x0004E735 File Offset: 0x0004C935
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x1700412F RID: 16687
		' (get) Token: 0x0600A829 RID: 43049 RVA: 0x0004E73E File Offset: 0x0004C93E
		' (set) Token: 0x0600A82A RID: 43050 RVA: 0x0004E748 File Offset: 0x0004C948
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17004130 RID: 16688
		' (get) Token: 0x0600A82B RID: 43051 RVA: 0x0004E751 File Offset: 0x0004C951
		' (set) Token: 0x0600A82C RID: 43052 RVA: 0x0004E75B File Offset: 0x0004C95B
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004131 RID: 16689
		' (get) Token: 0x0600A82D RID: 43053 RVA: 0x0004E764 File Offset: 0x0004C964
		' (set) Token: 0x0600A82E RID: 43054 RVA: 0x0070AECC File Offset: 0x007090CC
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

		' Token: 0x17004132 RID: 16690
		' (get) Token: 0x0600A82F RID: 43055 RVA: 0x0004E76E File Offset: 0x0004C96E
		' (set) Token: 0x0600A830 RID: 43056 RVA: 0x0004E778 File Offset: 0x0004C978
		Friend Overridable Property Label4 As Label

		' Token: 0x17004133 RID: 16691
		' (get) Token: 0x0600A831 RID: 43057 RVA: 0x0004E781 File Offset: 0x0004C981
		' (set) Token: 0x0600A832 RID: 43058 RVA: 0x0004E78B File Offset: 0x0004C98B
		Friend Overridable Property txtTempAmt As TextBox

		' Token: 0x17004134 RID: 16692
		' (get) Token: 0x0600A833 RID: 43059 RVA: 0x0004E794 File Offset: 0x0004C994
		' (set) Token: 0x0600A834 RID: 43060 RVA: 0x0070AF10 File Offset: 0x00709110
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

		' Token: 0x17004135 RID: 16693
		' (get) Token: 0x0600A835 RID: 43061 RVA: 0x0004E79E File Offset: 0x0004C99E
		' (set) Token: 0x0600A836 RID: 43062 RVA: 0x0004E7A8 File Offset: 0x0004C9A8
		Friend Overridable Property cmbprintcopy As ComboBox

		' Token: 0x17004136 RID: 16694
		' (get) Token: 0x0600A837 RID: 43063 RVA: 0x0004E7B1 File Offset: 0x0004C9B1
		' (set) Token: 0x0600A838 RID: 43064 RVA: 0x0070AF54 File Offset: 0x00709154
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

		' Token: 0x17004137 RID: 16695
		' (get) Token: 0x0600A839 RID: 43065 RVA: 0x0004E7BB File Offset: 0x0004C9BB
		' (set) Token: 0x0600A83A RID: 43066 RVA: 0x0004E7C5 File Offset: 0x0004C9C5
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17004138 RID: 16696
		' (get) Token: 0x0600A83B RID: 43067 RVA: 0x0004E7CE File Offset: 0x0004C9CE
		' (set) Token: 0x0600A83C RID: 43068 RVA: 0x0070AF98 File Offset: 0x00709198
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

		' Token: 0x17004139 RID: 16697
		' (get) Token: 0x0600A83D RID: 43069 RVA: 0x0004E7D8 File Offset: 0x0004C9D8
		' (set) Token: 0x0600A83E RID: 43070 RVA: 0x0004E7E2 File Offset: 0x0004C9E2
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x1700413A RID: 16698
		' (get) Token: 0x0600A83F RID: 43071 RVA: 0x0004E7EB File Offset: 0x0004C9EB
		' (set) Token: 0x0600A840 RID: 43072 RVA: 0x0004E7F5 File Offset: 0x0004C9F5
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x1700413B RID: 16699
		' (get) Token: 0x0600A841 RID: 43073 RVA: 0x0004E7FE File Offset: 0x0004C9FE
		' (set) Token: 0x0600A842 RID: 43074 RVA: 0x0004E808 File Offset: 0x0004CA08
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x1700413C RID: 16700
		' (get) Token: 0x0600A843 RID: 43075 RVA: 0x0004E811 File Offset: 0x0004CA11
		' (set) Token: 0x0600A844 RID: 43076 RVA: 0x0004E81B File Offset: 0x0004CA1B
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x1700413D RID: 16701
		' (get) Token: 0x0600A845 RID: 43077 RVA: 0x0004E824 File Offset: 0x0004CA24
		' (set) Token: 0x0600A846 RID: 43078 RVA: 0x0004E82E File Offset: 0x0004CA2E
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x1700413E RID: 16702
		' (get) Token: 0x0600A847 RID: 43079 RVA: 0x0004E837 File Offset: 0x0004CA37
		' (set) Token: 0x0600A848 RID: 43080 RVA: 0x0004E841 File Offset: 0x0004CA41
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x1700413F RID: 16703
		' (get) Token: 0x0600A849 RID: 43081 RVA: 0x0004E84A File Offset: 0x0004CA4A
		' (set) Token: 0x0600A84A RID: 43082 RVA: 0x0070AFDC File Offset: 0x007091DC
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

		' Token: 0x17004140 RID: 16704
		' (get) Token: 0x0600A84B RID: 43083 RVA: 0x0004E854 File Offset: 0x0004CA54
		' (set) Token: 0x0600A84C RID: 43084 RVA: 0x0070B020 File Offset: 0x00709220
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

		' Token: 0x17004141 RID: 16705
		' (get) Token: 0x0600A84D RID: 43085 RVA: 0x0004E85E File Offset: 0x0004CA5E
		' (set) Token: 0x0600A84E RID: 43086 RVA: 0x0070B064 File Offset: 0x00709264
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

		' Token: 0x17004142 RID: 16706
		' (get) Token: 0x0600A84F RID: 43087 RVA: 0x0004E868 File Offset: 0x0004CA68
		' (set) Token: 0x0600A850 RID: 43088 RVA: 0x0070B0A8 File Offset: 0x007092A8
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

		' Token: 0x17004143 RID: 16707
		' (get) Token: 0x0600A851 RID: 43089 RVA: 0x0004E872 File Offset: 0x0004CA72
		' (set) Token: 0x0600A852 RID: 43090 RVA: 0x0070B0EC File Offset: 0x007092EC
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

		' Token: 0x17004144 RID: 16708
		' (get) Token: 0x0600A853 RID: 43091 RVA: 0x0004E87C File Offset: 0x0004CA7C
		' (set) Token: 0x0600A854 RID: 43092 RVA: 0x0070B130 File Offset: 0x00709330
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

		' Token: 0x17004145 RID: 16709
		' (get) Token: 0x0600A855 RID: 43093 RVA: 0x0004E886 File Offset: 0x0004CA86
		' (set) Token: 0x0600A856 RID: 43094 RVA: 0x0004E890 File Offset: 0x0004CA90
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17004146 RID: 16710
		' (get) Token: 0x0600A857 RID: 43095 RVA: 0x0004E899 File Offset: 0x0004CA99
		' (set) Token: 0x0600A858 RID: 43096 RVA: 0x0004E8A3 File Offset: 0x0004CAA3
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004147 RID: 16711
		' (get) Token: 0x0600A859 RID: 43097 RVA: 0x0004E8AC File Offset: 0x0004CAAC
		' (set) Token: 0x0600A85A RID: 43098 RVA: 0x0070B174 File Offset: 0x00709374
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

		' Token: 0x17004148 RID: 16712
		' (get) Token: 0x0600A85B RID: 43099 RVA: 0x0004E8B6 File Offset: 0x0004CAB6
		' (set) Token: 0x0600A85C RID: 43100 RVA: 0x0004E8C0 File Offset: 0x0004CAC0
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004149 RID: 16713
		' (get) Token: 0x0600A85D RID: 43101 RVA: 0x0004E8C9 File Offset: 0x0004CAC9
		' (set) Token: 0x0600A85E RID: 43102 RVA: 0x0004E8D3 File Offset: 0x0004CAD3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700414A RID: 16714
		' (get) Token: 0x0600A85F RID: 43103 RVA: 0x0004E8DC File Offset: 0x0004CADC
		' (set) Token: 0x0600A860 RID: 43104 RVA: 0x0004E8E6 File Offset: 0x0004CAE6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700414B RID: 16715
		' (get) Token: 0x0600A861 RID: 43105 RVA: 0x0004E8EF File Offset: 0x0004CAEF
		' (set) Token: 0x0600A862 RID: 43106 RVA: 0x0004E8F9 File Offset: 0x0004CAF9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700414C RID: 16716
		' (get) Token: 0x0600A863 RID: 43107 RVA: 0x0004E902 File Offset: 0x0004CB02
		' (set) Token: 0x0600A864 RID: 43108 RVA: 0x0004E90C File Offset: 0x0004CB0C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700414D RID: 16717
		' (get) Token: 0x0600A865 RID: 43109 RVA: 0x0004E915 File Offset: 0x0004CB15
		' (set) Token: 0x0600A866 RID: 43110 RVA: 0x0004E91F File Offset: 0x0004CB1F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700414E RID: 16718
		' (get) Token: 0x0600A867 RID: 43111 RVA: 0x0004E928 File Offset: 0x0004CB28
		' (set) Token: 0x0600A868 RID: 43112 RVA: 0x0004E932 File Offset: 0x0004CB32
		Friend Overridable Property Label6 As Label

		' Token: 0x1700414F RID: 16719
		' (get) Token: 0x0600A869 RID: 43113 RVA: 0x0004E93B File Offset: 0x0004CB3B
		' (set) Token: 0x0600A86A RID: 43114 RVA: 0x0004E945 File Offset: 0x0004CB45
		Friend Overridable Property F2 As TextBox

		' Token: 0x17004150 RID: 16720
		' (get) Token: 0x0600A86B RID: 43115 RVA: 0x0004E94E File Offset: 0x0004CB4E
		' (set) Token: 0x0600A86C RID: 43116 RVA: 0x0004E958 File Offset: 0x0004CB58
		Friend Overridable Property F1 As TextBox

		' Token: 0x17004151 RID: 16721
		' (get) Token: 0x0600A86D RID: 43117 RVA: 0x0004E961 File Offset: 0x0004CB61
		' (set) Token: 0x0600A86E RID: 43118 RVA: 0x0004E96B File Offset: 0x0004CB6B
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004152 RID: 16722
		' (get) Token: 0x0600A86F RID: 43119 RVA: 0x0004E974 File Offset: 0x0004CB74
		' (set) Token: 0x0600A870 RID: 43120 RVA: 0x0070B1B8 File Offset: 0x007093B8
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

		' Token: 0x17004153 RID: 16723
		' (get) Token: 0x0600A871 RID: 43121 RVA: 0x0004E97E File Offset: 0x0004CB7E
		' (set) Token: 0x0600A872 RID: 43122 RVA: 0x0004E988 File Offset: 0x0004CB88
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17004154 RID: 16724
		' (get) Token: 0x0600A873 RID: 43123 RVA: 0x0004E991 File Offset: 0x0004CB91
		' (set) Token: 0x0600A874 RID: 43124 RVA: 0x0004E99B File Offset: 0x0004CB9B
		Friend Overridable Property Label74 As Label

		' Token: 0x17004155 RID: 16725
		' (get) Token: 0x0600A875 RID: 43125 RVA: 0x0004E9A4 File Offset: 0x0004CBA4
		' (set) Token: 0x0600A876 RID: 43126 RVA: 0x0070B1FC File Offset: 0x007093FC
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

		' Token: 0x17004156 RID: 16726
		' (get) Token: 0x0600A877 RID: 43127 RVA: 0x0004E9AE File Offset: 0x0004CBAE
		' (set) Token: 0x0600A878 RID: 43128 RVA: 0x0004E9B8 File Offset: 0x0004CBB8
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004157 RID: 16727
		' (get) Token: 0x0600A879 RID: 43129 RVA: 0x0004E9C1 File Offset: 0x0004CBC1
		' (set) Token: 0x0600A87A RID: 43130 RVA: 0x0070B240 File Offset: 0x00709440
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

		' Token: 0x17004158 RID: 16728
		' (get) Token: 0x0600A87B RID: 43131 RVA: 0x0004E9CB File Offset: 0x0004CBCB
		' (set) Token: 0x0600A87C RID: 43132 RVA: 0x0070B284 File Offset: 0x00709484
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

		' Token: 0x17004159 RID: 16729
		' (get) Token: 0x0600A87D RID: 43133 RVA: 0x0004E9D5 File Offset: 0x0004CBD5
		' (set) Token: 0x0600A87E RID: 43134 RVA: 0x0070B2C8 File Offset: 0x007094C8
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

		' Token: 0x1700415A RID: 16730
		' (get) Token: 0x0600A87F RID: 43135 RVA: 0x0004E9DF File Offset: 0x0004CBDF
		' (set) Token: 0x0600A880 RID: 43136 RVA: 0x0070B30C File Offset: 0x0070950C
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

		' Token: 0x1700415B RID: 16731
		' (get) Token: 0x0600A881 RID: 43137 RVA: 0x0004E9E9 File Offset: 0x0004CBE9
		' (set) Token: 0x0600A882 RID: 43138 RVA: 0x0070B350 File Offset: 0x00709550
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

		' Token: 0x1700415C RID: 16732
		' (get) Token: 0x0600A883 RID: 43139 RVA: 0x0004E9F3 File Offset: 0x0004CBF3
		' (set) Token: 0x0600A884 RID: 43140 RVA: 0x0070B394 File Offset: 0x00709594
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

		' Token: 0x1700415D RID: 16733
		' (get) Token: 0x0600A885 RID: 43141 RVA: 0x0004E9FD File Offset: 0x0004CBFD
		' (set) Token: 0x0600A886 RID: 43142 RVA: 0x0070B3D8 File Offset: 0x007095D8
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
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

		' Token: 0x1700415E RID: 16734
		' (get) Token: 0x0600A887 RID: 43143 RVA: 0x0004EA07 File Offset: 0x0004CC07
		' (set) Token: 0x0600A888 RID: 43144 RVA: 0x0070B41C File Offset: 0x0070961C
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

		' Token: 0x1700415F RID: 16735
		' (get) Token: 0x0600A889 RID: 43145 RVA: 0x0004EA11 File Offset: 0x0004CC11
		' (set) Token: 0x0600A88A RID: 43146 RVA: 0x0070B460 File Offset: 0x00709660
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

		' Token: 0x17004160 RID: 16736
		' (get) Token: 0x0600A88B RID: 43147 RVA: 0x0004EA1B File Offset: 0x0004CC1B
		' (set) Token: 0x0600A88C RID: 43148 RVA: 0x0004EA25 File Offset: 0x0004CC25
		Friend Overridable Property cmbCustomerName As TextBox

		' Token: 0x0600A88D RID: 43149 RVA: 0x0070B4A4 File Offset: 0x007096A4
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

		' Token: 0x0600A88E RID: 43150 RVA: 0x0070B63C File Offset: 0x0070983C
		Public Sub GetCustomerBalance()
			Try
				Try
					Me.num1 = 0D
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
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

		' Token: 0x0600A88F RID: 43151 RVA: 0x00131590 File Offset: 0x0012F790
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 T_ID FROM CreditCustomerPayment ORDER BY T_ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600A890 RID: 43152 RVA: 0x001316FC File Offset: 0x0012F8FC
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrReceipt ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600A891 RID: 43153 RVA: 0x0070B880 File Offset: 0x00709A80
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

		' Token: 0x0600A892 RID: 43154 RVA: 0x0070BA58 File Offset: 0x00709C58
		Public Sub auto()
			Try
				Me.txtT_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtTransactionNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A893 RID: 43155 RVA: 0x0070BB08 File Offset: 0x00709D08
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

		' Token: 0x0600A894 RID: 43156 RVA: 0x00131C7C File Offset: 0x0012FE7C
		Public Sub FillCustomers()
			Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A895 RID: 43157 RVA: 0x0070BC94 File Offset: 0x00709E94
		Public Sub GetCustomerInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT CustomerID,Name,Address,ContactNo from Customer where ID=@d1"
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

		' Token: 0x0600A896 RID: 43158 RVA: 0x0070BDD0 File Offset: 0x00709FD0
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from CreditCustomerPayment where T_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LedgerDelete(Me.txtTransactionNo.Text, "Receipt")
					ModFunc.CustomerLedgerDelete(Me.txtTransactionNo.Text)
					ModFunc.SrReceiptDelete(Me.txtTransactionNo.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-By Cheque")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-By Online Transfer")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-PhonePe")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-Google Pay")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Sale-Google Pay")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-Paytm")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-E Wallet")
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the CreditCustomerPayment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
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

		' Token: 0x0600A897 RID: 43159 RVA: 0x0070C00C File Offset: 0x0070A20C
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

		' Token: 0x0600A898 RID: 43160 RVA: 0x0004EA2E File Offset: 0x0004CC2E
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600A899 RID: 43161 RVA: 0x0004EA38 File Offset: 0x0004CC38
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600A89A RID: 43162 RVA: 0x0070C104 File Offset: 0x0070A304
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

		' Token: 0x0600A89B RID: 43163 RVA: 0x0070C1F8 File Offset: 0x0070A3F8
		Private Sub txtCustNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x0600A89C RID: 43164 RVA: 0x0070C1F8 File Offset: 0x0070A3F8
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x0600A89D RID: 43165 RVA: 0x0070C248 File Offset: 0x0070A448
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
			Me.getdata1()
			Me.dgw.Visible = True
			Me.Label6.Visible = True
		End Sub

		' Token: 0x0600A89E RID: 43166 RVA: 0x0070C2BC File Offset: 0x0070A4BC
		Private Sub txtTransactionAmount_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) >= 0.0
			If flag Then
				Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(Me.txtTransactionAmount.Text)))
			Else
				Me.txtRsToWords.Text = ""
			End If
		End Sub

		' Token: 0x0600A89F RID: 43167 RVA: 0x0070C330 File Offset: 0x0070A530
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

		' Token: 0x0600A8A0 RID: 43168 RVA: 0x0070C424 File Offset: 0x0070A624
		Public Sub Print()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptCustomerPaid As rptCustomerPaid = New rptCustomerPaid()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT CreditCustomerPayment.T_ID, CreditCustomerPayment.TransactionID, CreditCustomerPayment.Date, CreditCustomerPayment.PaymentMode, CreditCustomerPayment.Amount, CreditCustomerPayment.PaymentModedetails, Customer.ID, Customer.Name, Customer.Address, Customer.City,Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2 FROM CreditCustomerPayment INNER JOIN Customer ON CreditCustomerPayment.Customer_ID = Customer.ID where CreditCustomerPayment.TransactionID=@d1"
				sqlCommand.Parameters.AddWithValue("@d1", Me.txtTransactionNo.Text)
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "CreditCustomerPayment")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptCustomerPaid.SetDataSource(dataSet)
				rptCustomerPaid.SetParameterValue("p1", Me.txtCustomerID.Text)
				rptCustomerPaid.SetParameterValue("p2", DateAndTime.Today)
				rptCustomerPaid.SetParameterValue("p3", Me.cmbCustomerName.Text)
				rptCustomerPaid.SetParameterValue("p4", Me.cmbprintcopy.Text)
				rptCustomerPaid.SetParameterValue("0", Me.TextBox9.Text.Trim())
				Dim parameterFields As ParameterFields = New ParameterFields()
				Dim parameterField As ParameterField = New ParameterField()
				Dim parameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
				parameterField.ParameterFieldName = "0"
				parameterDiscreteValue.Value = Me.TextBox9.Text.Trim()
				parameterField.CurrentValues.Add(parameterDiscreteValue)
				parameterFields.Add(parameterField)
				MyProject.Forms.frmReport.CrystalReportViewer1.ParameterFieldInfo = parameterFields
				MyProject.Forms.frmReport.CrystalReportViewer1.Refresh()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCustomerPaid
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A8A1 RID: 43169 RVA: 0x001326D8 File Offset: 0x001308D8
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

		' Token: 0x0600A8A2 RID: 43170 RVA: 0x0070C6A8 File Offset: 0x0070A8A8
		Public Sub Print_WAPP()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptCustomerPaid As rptCustomerPaid = New rptCustomerPaid()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT CreditCustomerPayment.T_ID, CreditCustomerPayment.TransactionID, CreditCustomerPayment.Date, CreditCustomerPayment.PaymentMode, CreditCustomerPayment.Amount, CreditCustomerPayment.PaymentModedetails, Customer.ID, Customer.Name, Customer.Address, Customer.City,Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2 FROM CreditCustomerPayment INNER JOIN Customer ON CreditCustomerPayment.Customer_ID = Customer.ID where CreditCustomerPayment.TransactionID=@d1"
				sqlCommand.Parameters.AddWithValue("@d1", Me.txtTransactionNo.Text)
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "CreditCustomerPayment")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptCustomerPaid.SetDataSource(dataSet)
				rptCustomerPaid.SetParameterValue("p1", Me.txtCustomerID.Text)
				rptCustomerPaid.SetParameterValue("p2", DateAndTime.Today)
				rptCustomerPaid.SetParameterValue("p3", Me.cmbCustomerName.Text)
				rptCustomerPaid.SetParameterValue("p4", Me.cmbprintcopy.Text)
				rptCustomerPaid.SetParameterValue("0", Me.TextBox9.Text.Trim())
				Dim parameterFields As ParameterFields = New ParameterFields()
				Dim parameterField As ParameterField = New ParameterField()
				Dim parameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
				parameterField.ParameterFieldName = "0"
				parameterDiscreteValue.Value = Me.TextBox9.Text.Trim()
				parameterField.CurrentValues.Add(parameterDiscreteValue)
				parameterFields.Add(parameterField)
				Me.WAPPREPORT()
				rptCustomerPaid.ExportToDisk(ExportFormatType.PortableDocFormat, Me.WhatsApppdfFile)
				rptCustomerPaid.Close()
				rptCustomerPaid.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A8A3 RID: 43171 RVA: 0x0070C8FC File Offset: 0x0070AAFC
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

		' Token: 0x0600A8A4 RID: 43172 RVA: 0x0070C9BC File Offset: 0x0070ABBC
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

		' Token: 0x0600A8A5 RID: 43173 RVA: 0x0070CC5C File Offset: 0x0070AE5C
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

		' Token: 0x0600A8A6 RID: 43174 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600A8A7 RID: 43175 RVA: 0x0070CD28 File Offset: 0x0070AF28
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

		' Token: 0x0600A8A8 RID: 43176 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpTranactionDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8A9 RID: 43177 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPaymentMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8AA RID: 43178 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8AB RID: 43179 RVA: 0x0070CDD4 File Offset: 0x0070AFD4
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

		' Token: 0x0600A8AC RID: 43180 RVA: 0x0070CF90 File Offset: 0x0070B190
		Private Sub getdata1()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = New SqlCommand("Select Date, RTRIM(Name), RTRIM(LedgerNo), RTRIM(Label), Debit, Credit from CustomerLedgerBook where PartyID=@d1 order by Date DESC", ModCommonClasses.con1)
				ModCommonClasses.cmd1.CommandTimeout = 0
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
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

		' Token: 0x0600A8AD RID: 43181 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTransactionAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8AE RID: 43182 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPaymentModeDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8AF RID: 43183 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8B0 RID: 43184 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600A8B1 RID: 43185 RVA: 0x0070D0DC File Offset: 0x0070B2DC
		Public Sub fillReceiptID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(T_ID) FROM CreditCustomerPayment order by T_ID ASC", ModCommonClasses.con)
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

		' Token: 0x0600A8B2 RID: 43186 RVA: 0x0070D218 File Offset: 0x0070B418
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks),RTRIM(BankAcNo) from Customer,CreditCustomerPayment where Customer.ID=CreditCustomerPayment.Customer_ID and T_ID=@d1", ModCommonClasses.con)
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

		' Token: 0x0600A8B3 RID: 43187 RVA: 0x0004EA54 File Offset: 0x0004CC54
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x0600A8B4 RID: 43188 RVA: 0x0070D4A4 File Offset: 0x0070B6A4
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM CreditCustomerPayment", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "CreditCustomerPayment")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("CreditCustomerPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600A8B5 RID: 43189 RVA: 0x0070D580 File Offset: 0x0070B780
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

		' Token: 0x0600A8B6 RID: 43190 RVA: 0x0070D63C File Offset: 0x0070B83C
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600A8B7 RID: 43191 RVA: 0x0070D68C File Offset: 0x0070B88C
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

		' Token: 0x0600A8B8 RID: 43192 RVA: 0x0070D738 File Offset: 0x0070B938
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("CreditCustomerPayment").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("CreditCustomerPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600A8B9 RID: 43193 RVA: 0x0070D7F0 File Offset: 0x0070B9F0
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("CreditCustomerPayment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600A8BA RID: 43194 RVA: 0x0070D888 File Offset: 0x0070BA88
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

		' Token: 0x0600A8BB RID: 43195 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x0600A8BC RID: 43196 RVA: 0x0070D970 File Offset: 0x0070BB70
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

		' Token: 0x0600A8BD RID: 43197 RVA: 0x00014ABA File Offset: 0x00012CBA
		Private Sub Button39_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Form1.ShowDialog()
		End Sub

		' Token: 0x0600A8BE RID: 43198 RVA: 0x0070DA64 File Offset: 0x0070BC64
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

		' Token: 0x0600A8BF RID: 43199 RVA: 0x0070DB5C File Offset: 0x0070BD5C
		Private Sub cmbPaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x0600A8C0 RID: 43200 RVA: 0x0004EA2E File Offset: 0x0004CC2E
		Private Sub btnNew_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600A8C1 RID: 43201 RVA: 0x0070DBF4 File Offset: 0x0070BDF4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpTranactionDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from CreditCustomerPayment where Date between @d1 and @d2 having count(*) >= 5"
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
					MessageBox.Show("Please retrieve credit customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCustomerID.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please select correct customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
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
									Dim text3 As String = "insert into CreditCustomerPayment(T_ID, TransactionID, Date,PaymentMode, Customer_ID, Amount,Remarks,PaymentModeDetails,BankAcNo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
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
										ModFunc.LedgerSave(Me.dtpTranactionDate.Value.[Date], "Cash Account", Me.txtTransactionNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
									End If
									Dim flag13 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
									If flag13 Then
										ModFunc.LedgerSave(Me.dtpTranactionDate.Value.[Date], "Bank Account", Me.txtTransactionNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
									End If
									Dim flag14 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
									If flag14 Then
										ModFunc.CustomerLedgerSave(Me.dtpTranactionDate.Value.[Date], "Cash Account", Me.txtTransactionNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text.Trim() + Me.txtCustNameId.Text, Me.txtRemarks.Text)
									End If
									Dim flag15 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
									If flag15 Then
										ModFunc.CustomerLedgerSave(Me.dtpTranactionDate.Value.[Date], "Bank Account", Me.txtTransactionNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text.Trim() + Me.txtCustNameId.Text, Me.txtRemarks.Text)
									End If
									Dim flag16 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1
									If flag16 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-By Cheque", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									Dim flag17 As Boolean = Me.cmbPaymentMode.SelectedIndex = 2
									If flag17 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-By Online Transfer", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									Dim flag18 As Boolean = Me.cmbPaymentMode.SelectedIndex = 3
									If flag18 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-PhonePe", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									Dim flag19 As Boolean = Me.cmbPaymentMode.SelectedIndex = 4
									If flag19 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-Google Pay", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									Dim flag20 As Boolean = Me.cmbPaymentMode.SelectedIndex = 5
									If flag20 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-Paytm", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									Dim flag21 As Boolean = Me.cmbPaymentMode.SelectedIndex = 6
									If flag21 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-E Wallet", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into SrReceipt(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, "added the new CreditCustomerPayment having transaction No. '" + Me.txtTransactionNo.Text + "'")
									Me.btnSave.Enabled = False
									ModCommonClasses.con.Close()
									Try
										Dim flag22 As Boolean = ModFunc.CheckForInternetConnection()
										If flag22 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text5 As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes' and AutoSMS='Yes'"
											ModCommonClasses.cmd = New SqlCommand(text5)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag23 As Boolean = ModCommonClasses.rdr.Read()
											If flag23 Then
												Me.st2 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
												Dim text6 As String = String.Concat(New String() { "Dear Sir/Madam, ", Me.cmbCustomerName.Text, ", Thank you for payment to us. Your Receipt No. ", Me.txtTransactionNo.Text, ", Date. ", Me.dtpTranactionDate.Text, " , Amount is Rs.", Strings.Format(Math.Round(Conversion.Val(Me.txtTransactionAmount.Text), 2), "0.00"), ", Best wishes from ", Me.txtcompname.Text.Trim(), "." })
												ModFunc.SMSFunc(Me.txtContactNo.Text, text6, Me.st2)
												ModFunc.SMS(text6)
												MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Dim flag24 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag24 Then
													ModCommonClasses.rdr.Close()
												End If
											End If
										End If
									Catch ex As Exception
										MessageBox.Show("SMS is not sent", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									Dim flag25 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print the Receipt ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
									If flag25 Then
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

		' Token: 0x0600A8C2 RID: 43202 RVA: 0x0070E960 File Offset: 0x0070CB60
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
								Dim text As String = "Update CreditCustomerPayment set TransactionID=@d2, Date=@d3, PaymentMode=@d4, Customer_ID=@d5, Amount=@d6,Remarks=@d7,PaymentModeDetails=@d8,BankAcNo=@d9 where T_ID=@d1"
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
									ModFunc.LedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Cash Account", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtTransactionNo.Text, "Receipt")
								End If
								Dim flag8 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
								If flag8 Then
									ModFunc.LedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Bank Account", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtTransactionNo.Text, "Receipt")
								End If
								Dim flag9 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
								If flag9 Then
									ModFunc.CustomerLedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Cash Account", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtTransactionNo.Text, "Receipt")
								End If
								Dim flag10 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
								If flag10 Then
									ModFunc.CustomerLedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Bank Account", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtTransactionNo.Text, "Receipt")
								End If
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-By Cheque")
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-By Online Transfer")
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-PhonePe")
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-Google Pay")
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-Paytm")
								ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Receipt-E Wallet")
								Dim flag11 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1
								If flag11 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-By Cheque", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								Dim flag12 As Boolean = Me.cmbPaymentMode.SelectedIndex = 2
								If flag12 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-By Online Transfer", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								Dim flag13 As Boolean = Me.cmbPaymentMode.SelectedIndex = 3
								If flag13 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-PhonePe", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								Dim flag14 As Boolean = Me.cmbPaymentMode.SelectedIndex = 4
								If flag14 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-Google Pay", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								Dim flag15 As Boolean = Me.cmbPaymentMode.SelectedIndex = 5
								If flag15 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-Paytm", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								Dim flag16 As Boolean = Me.cmbPaymentMode.SelectedIndex = 6
								If flag16 Then
									ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Receipt-E Wallet", 0D, New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)))
								End If
								ModFunc.LogFunc(Me.lblUser.Text, "updated CreditCustomerPayment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
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

		' Token: 0x0600A8C3 RID: 43203 RVA: 0x0070F2B0 File Offset: 0x0070D4B0
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

		' Token: 0x0600A8C4 RID: 43204 RVA: 0x0070F318 File Offset: 0x0070D518
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceiptRecord.Dispose()
		End Sub

		' Token: 0x0600A8C5 RID: 43205 RVA: 0x0004EA6C File Offset: 0x0004CC6C
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600A8C6 RID: 43206 RVA: 0x0070F378 File Offset: 0x0070D578
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

		' Token: 0x0600A8C7 RID: 43207 RVA: 0x0070F540 File Offset: 0x0070D740
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Me.Print_WAPP()
					Me.stw1 = String.Format("Dear Sir/Madam, {0}, Thank you for payment to us. Your Receipt No.{1}, Date : {2}, Amount is Rs. {3},  _Best wishes from : *{4}*_", New Object() { Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}), Me.txtTransactionNo.Text.TrimEnd(New Char(-1) {}), Me.dtpTranactionDate.Text.TrimEnd(New Char(-1) {}), Strings.Format(Math.Round(Conversion.Val(Me.txtTransactionAmount.Text), 2), "0.00").TrimEnd(New Char(-1) {}), Me.txtcompname.Text.TrimEnd(New Char(-1) {}) })
					Try
						Dim messageRequest As MessageRequest = New MessageRequest()
						messageRequest.Phone = Me.wappno + Me.txtContactNo.Text
						messageRequest.Message = Me.stw1
						messageRequest.AttachmentPath = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.pdf"
					Catch ex As Exception
						Dim exception As Exception = ex
						MessageBox.Show(exception.Message)
					End Try
				Else
					MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600A8C8 RID: 43208 RVA: 0x0070F588 File Offset: 0x0070D788
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

		' Token: 0x0600A8C9 RID: 43209 RVA: 0x0070F6F8 File Offset: 0x0070D8F8
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dtpTranactionDate.Focus()
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x0600A8CA RID: 43210 RVA: 0x0070F764 File Offset: 0x0070D964
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from CreditCustomerPayment order by T_ID DESC"
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

		' Token: 0x0600A8CB RID: 43211 RVA: 0x001359A8 File Offset: 0x00133BA8
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

		' Token: 0x0600A8CC RID: 43212 RVA: 0x0070F8A4 File Offset: 0x0070DAA4
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

		' Token: 0x04004685 RID: 18053
		Private str As String

		' Token: 0x04004686 RID: 18054
		Private OBType As String

		' Token: 0x04004687 RID: 18055
		Private num1 As Decimal

		' Token: 0x04004688 RID: 18056
		Private num2 As Decimal

		' Token: 0x04004689 RID: 18057
		Private num3 As Decimal

		' Token: 0x0400468A RID: 18058
		Private num4 As Decimal

		' Token: 0x0400468B RID: 18059
		Private i As Integer

		' Token: 0x0400468C RID: 18060
		Private st2 As String

		' Token: 0x0400468D RID: 18061
		Private wappno As String

		' Token: 0x0400468E RID: 18062
		Private bankacno As String

		' Token: 0x0400468F RID: 18063
		Private bankifsc As String

		' Token: 0x04004690 RID: 18064
		Private bankholdername As String

		' Token: 0x04004691 RID: 18065
		Private ntid As String

		' Token: 0x04004692 RID: 18066
		Private a As Double

		' Token: 0x04004693 RID: 18067
		Private sts2 As String

		' Token: 0x04004694 RID: 18068
		Private stw1 As String

		' Token: 0x04004695 RID: 18069
		Private WhatsApppdfFile As String

		' Token: 0x04004696 RID: 18070
		Private Dad As SqlDataAdapter

		' Token: 0x04004697 RID: 18071
		Private Dst As DataSet

		' Token: 0x04004698 RID: 18072
		Private CurrentRow As Object

		' Token: 0x04004699 RID: 18073
		Private InvDateSts As String

		' Token: 0x0400469A RID: 18074
		Private prevdate As DateTime
	End Class
End Namespace
