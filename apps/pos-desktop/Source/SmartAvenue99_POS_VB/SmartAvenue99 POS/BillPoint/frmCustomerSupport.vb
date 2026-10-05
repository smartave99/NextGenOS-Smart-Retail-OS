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
	' Token: 0x020000C1 RID: 193
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001B61 RID: 7009 RVA: 0x0012BC00 File Offset: 0x00129E00
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

		' Token: 0x17000A9B RID: 2715
		' (get) Token: 0x06001B64 RID: 7012 RVA: 0x000142DC File Offset: 0x000124DC
		' (set) Token: 0x06001B65 RID: 7013 RVA: 0x000142E6 File Offset: 0x000124E6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000A9C RID: 2716
		' (get) Token: 0x06001B66 RID: 7014 RVA: 0x000142EF File Offset: 0x000124EF
		' (set) Token: 0x06001B67 RID: 7015 RVA: 0x000142F9 File Offset: 0x000124F9
		Friend Overridable Property Label3 As Label

		' Token: 0x17000A9D RID: 2717
		' (get) Token: 0x06001B68 RID: 7016 RVA: 0x00014302 File Offset: 0x00012502
		' (set) Token: 0x06001B69 RID: 7017 RVA: 0x0001430C File Offset: 0x0001250C
		Friend Overridable Property txtTransactionNo As TextBox

		' Token: 0x17000A9E RID: 2718
		' (get) Token: 0x06001B6A RID: 7018 RVA: 0x00014315 File Offset: 0x00012515
		' (set) Token: 0x06001B6B RID: 7019 RVA: 0x0001431F File Offset: 0x0001251F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000A9F RID: 2719
		' (get) Token: 0x06001B6C RID: 7020 RVA: 0x00014328 File Offset: 0x00012528
		' (set) Token: 0x06001B6D RID: 7021 RVA: 0x00014332 File Offset: 0x00012532
		Friend Overridable Property Label1 As Label

		' Token: 0x17000AA0 RID: 2720
		' (get) Token: 0x06001B6E RID: 7022 RVA: 0x0001433B File Offset: 0x0001253B
		' (set) Token: 0x06001B6F RID: 7023 RVA: 0x00014345 File Offset: 0x00012545
		Friend Overridable Property Label2 As Label

		' Token: 0x17000AA1 RID: 2721
		' (get) Token: 0x06001B70 RID: 7024 RVA: 0x0001434E File Offset: 0x0001254E
		' (set) Token: 0x06001B71 RID: 7025 RVA: 0x00014358 File Offset: 0x00012558
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000AA2 RID: 2722
		' (get) Token: 0x06001B72 RID: 7026 RVA: 0x00014361 File Offset: 0x00012561
		' (set) Token: 0x06001B73 RID: 7027 RVA: 0x00130994 File Offset: 0x0012EB94
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

		' Token: 0x17000AA3 RID: 2723
		' (get) Token: 0x06001B74 RID: 7028 RVA: 0x0001436B File Offset: 0x0001256B
		' (set) Token: 0x06001B75 RID: 7029 RVA: 0x001309F4 File Offset: 0x0012EBF4
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

		' Token: 0x17000AA4 RID: 2724
		' (get) Token: 0x06001B76 RID: 7030 RVA: 0x00014375 File Offset: 0x00012575
		' (set) Token: 0x06001B77 RID: 7031 RVA: 0x0001437F File Offset: 0x0001257F
		Friend Overridable Property Label12 As Label

		' Token: 0x17000AA5 RID: 2725
		' (get) Token: 0x06001B78 RID: 7032 RVA: 0x00014388 File Offset: 0x00012588
		' (set) Token: 0x06001B79 RID: 7033 RVA: 0x00014392 File Offset: 0x00012592
		Friend Overridable Property txtCustID As TextBox

		' Token: 0x17000AA6 RID: 2726
		' (get) Token: 0x06001B7A RID: 7034 RVA: 0x0001439B File Offset: 0x0001259B
		' (set) Token: 0x06001B7B RID: 7035 RVA: 0x000143A5 File Offset: 0x000125A5
		Friend Overridable Property txtT_ID As TextBox

		' Token: 0x17000AA7 RID: 2727
		' (get) Token: 0x06001B7C RID: 7036 RVA: 0x000143AE File Offset: 0x000125AE
		' (set) Token: 0x06001B7D RID: 7037 RVA: 0x000143B8 File Offset: 0x000125B8
		Friend Overridable Property lblUser As Label

		' Token: 0x17000AA8 RID: 2728
		' (get) Token: 0x06001B7E RID: 7038 RVA: 0x000143C1 File Offset: 0x000125C1
		' (set) Token: 0x06001B7F RID: 7039 RVA: 0x000143CB File Offset: 0x000125CB
		Friend Overridable Property lblSet As Label

		' Token: 0x17000AA9 RID: 2729
		' (get) Token: 0x06001B80 RID: 7040 RVA: 0x000143D4 File Offset: 0x000125D4
		' (set) Token: 0x06001B81 RID: 7041 RVA: 0x000143DE File Offset: 0x000125DE
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000AAA RID: 2730
		' (get) Token: 0x06001B82 RID: 7042 RVA: 0x000143E7 File Offset: 0x000125E7
		' (set) Token: 0x06001B83 RID: 7043 RVA: 0x000143F1 File Offset: 0x000125F1
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x17000AAB RID: 2731
		' (get) Token: 0x06001B84 RID: 7044 RVA: 0x000143FA File Offset: 0x000125FA
		' (set) Token: 0x06001B85 RID: 7045 RVA: 0x00130A38 File Offset: 0x0012EC38
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

		' Token: 0x17000AAC RID: 2732
		' (get) Token: 0x06001B86 RID: 7046 RVA: 0x00014404 File Offset: 0x00012604
		' (set) Token: 0x06001B87 RID: 7047 RVA: 0x0001440E File Offset: 0x0001260E
		Friend Overridable Property Label10 As Label

		' Token: 0x17000AAD RID: 2733
		' (get) Token: 0x06001B88 RID: 7048 RVA: 0x00014417 File Offset: 0x00012617
		' (set) Token: 0x06001B89 RID: 7049 RVA: 0x00130A7C File Offset: 0x0012EC7C
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

		' Token: 0x17000AAE RID: 2734
		' (get) Token: 0x06001B8A RID: 7050 RVA: 0x00014421 File Offset: 0x00012621
		' (set) Token: 0x06001B8B RID: 7051 RVA: 0x0001442B File Offset: 0x0001262B
		Friend Overridable Property lblBalance As Label

		' Token: 0x17000AAF RID: 2735
		' (get) Token: 0x06001B8C RID: 7052 RVA: 0x00014434 File Offset: 0x00012634
		' (set) Token: 0x06001B8D RID: 7053 RVA: 0x0001443E File Offset: 0x0001263E
		Friend Overridable Property Label11 As Label

		' Token: 0x17000AB0 RID: 2736
		' (get) Token: 0x06001B8E RID: 7054 RVA: 0x00014447 File Offset: 0x00012647
		' (set) Token: 0x06001B8F RID: 7055 RVA: 0x00014451 File Offset: 0x00012651
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17000AB1 RID: 2737
		' (get) Token: 0x06001B90 RID: 7056 RVA: 0x0001445A File Offset: 0x0001265A
		' (set) Token: 0x06001B91 RID: 7057 RVA: 0x00014464 File Offset: 0x00012664
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17000AB2 RID: 2738
		' (get) Token: 0x06001B92 RID: 7058 RVA: 0x0001446D File Offset: 0x0001266D
		' (set) Token: 0x06001B93 RID: 7059 RVA: 0x00014477 File Offset: 0x00012677
		Friend Overridable Property Label26 As Label

		' Token: 0x17000AB3 RID: 2739
		' (get) Token: 0x06001B94 RID: 7060 RVA: 0x00014480 File Offset: 0x00012680
		' (set) Token: 0x06001B95 RID: 7061 RVA: 0x0001448A File Offset: 0x0001268A
		Friend Overridable Property Label30 As Label

		' Token: 0x17000AB4 RID: 2740
		' (get) Token: 0x06001B96 RID: 7062 RVA: 0x00014493 File Offset: 0x00012693
		' (set) Token: 0x06001B97 RID: 7063 RVA: 0x0001449D File Offset: 0x0001269D
		Friend Overridable Property Label36 As Label

		' Token: 0x17000AB5 RID: 2741
		' (get) Token: 0x06001B98 RID: 7064 RVA: 0x000144A6 File Offset: 0x000126A6
		' (set) Token: 0x06001B99 RID: 7065 RVA: 0x000144B0 File Offset: 0x000126B0
		Friend Overridable Property Label19 As Label

		' Token: 0x17000AB6 RID: 2742
		' (get) Token: 0x06001B9A RID: 7066 RVA: 0x000144B9 File Offset: 0x000126B9
		' (set) Token: 0x06001B9B RID: 7067 RVA: 0x00130AC0 File Offset: 0x0012ECC0
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

		' Token: 0x17000AB7 RID: 2743
		' (get) Token: 0x06001B9C RID: 7068 RVA: 0x000144C3 File Offset: 0x000126C3
		' (set) Token: 0x06001B9D RID: 7069 RVA: 0x00130B60 File Offset: 0x0012ED60
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

		' Token: 0x17000AB8 RID: 2744
		' (get) Token: 0x06001B9E RID: 7070 RVA: 0x000144CD File Offset: 0x000126CD
		' (set) Token: 0x06001B9F RID: 7071 RVA: 0x000144D7 File Offset: 0x000126D7
		Friend Overridable Property Label5 As Label

		' Token: 0x17000AB9 RID: 2745
		' (get) Token: 0x06001BA0 RID: 7072 RVA: 0x000144E0 File Offset: 0x000126E0
		' (set) Token: 0x06001BA1 RID: 7073 RVA: 0x000144EA File Offset: 0x000126EA
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17000ABA RID: 2746
		' (get) Token: 0x06001BA2 RID: 7074 RVA: 0x000144F3 File Offset: 0x000126F3
		' (set) Token: 0x06001BA3 RID: 7075 RVA: 0x000144FD File Offset: 0x000126FD
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17000ABB RID: 2747
		' (get) Token: 0x06001BA4 RID: 7076 RVA: 0x00014506 File Offset: 0x00012706
		' (set) Token: 0x06001BA5 RID: 7077 RVA: 0x00014510 File Offset: 0x00012710
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17000ABC RID: 2748
		' (get) Token: 0x06001BA6 RID: 7078 RVA: 0x00014519 File Offset: 0x00012719
		' (set) Token: 0x06001BA7 RID: 7079 RVA: 0x00130BDC File Offset: 0x0012EDDC
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

		' Token: 0x17000ABD RID: 2749
		' (get) Token: 0x06001BA8 RID: 7080 RVA: 0x00014523 File Offset: 0x00012723
		' (set) Token: 0x06001BA9 RID: 7081 RVA: 0x0001452D File Offset: 0x0001272D
		Friend Overridable Property Label4 As Label

		' Token: 0x17000ABE RID: 2750
		' (get) Token: 0x06001BAA RID: 7082 RVA: 0x00014536 File Offset: 0x00012736
		' (set) Token: 0x06001BAB RID: 7083 RVA: 0x00014540 File Offset: 0x00012740
		Friend Overridable Property txtTempAmt As TextBox

		' Token: 0x17000ABF RID: 2751
		' (get) Token: 0x06001BAC RID: 7084 RVA: 0x00014549 File Offset: 0x00012749
		' (set) Token: 0x06001BAD RID: 7085 RVA: 0x00130C20 File Offset: 0x0012EE20
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

		' Token: 0x17000AC0 RID: 2752
		' (get) Token: 0x06001BAE RID: 7086 RVA: 0x00014553 File Offset: 0x00012753
		' (set) Token: 0x06001BAF RID: 7087 RVA: 0x0001455D File Offset: 0x0001275D
		Friend Overridable Property cmbprintcopy As ComboBox

		' Token: 0x17000AC1 RID: 2753
		' (get) Token: 0x06001BB0 RID: 7088 RVA: 0x00014566 File Offset: 0x00012766
		' (set) Token: 0x06001BB1 RID: 7089 RVA: 0x00130C64 File Offset: 0x0012EE64
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

		' Token: 0x17000AC2 RID: 2754
		' (get) Token: 0x06001BB2 RID: 7090 RVA: 0x00014570 File Offset: 0x00012770
		' (set) Token: 0x06001BB3 RID: 7091 RVA: 0x0001457A File Offset: 0x0001277A
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17000AC3 RID: 2755
		' (get) Token: 0x06001BB4 RID: 7092 RVA: 0x00014583 File Offset: 0x00012783
		' (set) Token: 0x06001BB5 RID: 7093 RVA: 0x00130CA8 File Offset: 0x0012EEA8
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

		' Token: 0x17000AC4 RID: 2756
		' (get) Token: 0x06001BB6 RID: 7094 RVA: 0x0001458D File Offset: 0x0001278D
		' (set) Token: 0x06001BB7 RID: 7095 RVA: 0x00014597 File Offset: 0x00012797
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x17000AC5 RID: 2757
		' (get) Token: 0x06001BB8 RID: 7096 RVA: 0x000145A0 File Offset: 0x000127A0
		' (set) Token: 0x06001BB9 RID: 7097 RVA: 0x000145AA File Offset: 0x000127AA
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17000AC6 RID: 2758
		' (get) Token: 0x06001BBA RID: 7098 RVA: 0x000145B3 File Offset: 0x000127B3
		' (set) Token: 0x06001BBB RID: 7099 RVA: 0x000145BD File Offset: 0x000127BD
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17000AC7 RID: 2759
		' (get) Token: 0x06001BBC RID: 7100 RVA: 0x000145C6 File Offset: 0x000127C6
		' (set) Token: 0x06001BBD RID: 7101 RVA: 0x000145D0 File Offset: 0x000127D0
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17000AC8 RID: 2760
		' (get) Token: 0x06001BBE RID: 7102 RVA: 0x000145D9 File Offset: 0x000127D9
		' (set) Token: 0x06001BBF RID: 7103 RVA: 0x000145E3 File Offset: 0x000127E3
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17000AC9 RID: 2761
		' (get) Token: 0x06001BC0 RID: 7104 RVA: 0x000145EC File Offset: 0x000127EC
		' (set) Token: 0x06001BC1 RID: 7105 RVA: 0x000145F6 File Offset: 0x000127F6
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17000ACA RID: 2762
		' (get) Token: 0x06001BC2 RID: 7106 RVA: 0x000145FF File Offset: 0x000127FF
		' (set) Token: 0x06001BC3 RID: 7107 RVA: 0x00130CEC File Offset: 0x0012EEEC
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

		' Token: 0x17000ACB RID: 2763
		' (get) Token: 0x06001BC4 RID: 7108 RVA: 0x00014609 File Offset: 0x00012809
		' (set) Token: 0x06001BC5 RID: 7109 RVA: 0x00130D30 File Offset: 0x0012EF30
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

		' Token: 0x17000ACC RID: 2764
		' (get) Token: 0x06001BC6 RID: 7110 RVA: 0x00014613 File Offset: 0x00012813
		' (set) Token: 0x06001BC7 RID: 7111 RVA: 0x00130D74 File Offset: 0x0012EF74
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

		' Token: 0x17000ACD RID: 2765
		' (get) Token: 0x06001BC8 RID: 7112 RVA: 0x0001461D File Offset: 0x0001281D
		' (set) Token: 0x06001BC9 RID: 7113 RVA: 0x00130DB8 File Offset: 0x0012EFB8
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

		' Token: 0x17000ACE RID: 2766
		' (get) Token: 0x06001BCA RID: 7114 RVA: 0x00014627 File Offset: 0x00012827
		' (set) Token: 0x06001BCB RID: 7115 RVA: 0x00130DFC File Offset: 0x0012EFFC
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

		' Token: 0x17000ACF RID: 2767
		' (get) Token: 0x06001BCC RID: 7116 RVA: 0x00014631 File Offset: 0x00012831
		' (set) Token: 0x06001BCD RID: 7117 RVA: 0x00130E40 File Offset: 0x0012F040
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

		' Token: 0x17000AD0 RID: 2768
		' (get) Token: 0x06001BCE RID: 7118 RVA: 0x0001463B File Offset: 0x0001283B
		' (set) Token: 0x06001BCF RID: 7119 RVA: 0x00014645 File Offset: 0x00012845
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17000AD1 RID: 2769
		' (get) Token: 0x06001BD0 RID: 7120 RVA: 0x0001464E File Offset: 0x0001284E
		' (set) Token: 0x06001BD1 RID: 7121 RVA: 0x00014658 File Offset: 0x00012858
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000AD2 RID: 2770
		' (get) Token: 0x06001BD2 RID: 7122 RVA: 0x00014661 File Offset: 0x00012861
		' (set) Token: 0x06001BD3 RID: 7123 RVA: 0x00130E84 File Offset: 0x0012F084
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

		' Token: 0x17000AD3 RID: 2771
		' (get) Token: 0x06001BD4 RID: 7124 RVA: 0x0001466B File Offset: 0x0001286B
		' (set) Token: 0x06001BD5 RID: 7125 RVA: 0x00014675 File Offset: 0x00012875
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000AD4 RID: 2772
		' (get) Token: 0x06001BD6 RID: 7126 RVA: 0x0001467E File Offset: 0x0001287E
		' (set) Token: 0x06001BD7 RID: 7127 RVA: 0x00014688 File Offset: 0x00012888
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000AD5 RID: 2773
		' (get) Token: 0x06001BD8 RID: 7128 RVA: 0x00014691 File Offset: 0x00012891
		' (set) Token: 0x06001BD9 RID: 7129 RVA: 0x0001469B File Offset: 0x0001289B
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000AD6 RID: 2774
		' (get) Token: 0x06001BDA RID: 7130 RVA: 0x000146A4 File Offset: 0x000128A4
		' (set) Token: 0x06001BDB RID: 7131 RVA: 0x000146AE File Offset: 0x000128AE
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000AD7 RID: 2775
		' (get) Token: 0x06001BDC RID: 7132 RVA: 0x000146B7 File Offset: 0x000128B7
		' (set) Token: 0x06001BDD RID: 7133 RVA: 0x000146C1 File Offset: 0x000128C1
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000AD8 RID: 2776
		' (get) Token: 0x06001BDE RID: 7134 RVA: 0x000146CA File Offset: 0x000128CA
		' (set) Token: 0x06001BDF RID: 7135 RVA: 0x000146D4 File Offset: 0x000128D4
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000AD9 RID: 2777
		' (get) Token: 0x06001BE0 RID: 7136 RVA: 0x000146DD File Offset: 0x000128DD
		' (set) Token: 0x06001BE1 RID: 7137 RVA: 0x000146E7 File Offset: 0x000128E7
		Friend Overridable Property Label6 As Label

		' Token: 0x17000ADA RID: 2778
		' (get) Token: 0x06001BE2 RID: 7138 RVA: 0x000146F0 File Offset: 0x000128F0
		' (set) Token: 0x06001BE3 RID: 7139 RVA: 0x000146FA File Offset: 0x000128FA
		Friend Overridable Property F2 As TextBox

		' Token: 0x17000ADB RID: 2779
		' (get) Token: 0x06001BE4 RID: 7140 RVA: 0x00014703 File Offset: 0x00012903
		' (set) Token: 0x06001BE5 RID: 7141 RVA: 0x0001470D File Offset: 0x0001290D
		Friend Overridable Property F1 As TextBox

		' Token: 0x17000ADC RID: 2780
		' (get) Token: 0x06001BE6 RID: 7142 RVA: 0x00014716 File Offset: 0x00012916
		' (set) Token: 0x06001BE7 RID: 7143 RVA: 0x00014720 File Offset: 0x00012920
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17000ADD RID: 2781
		' (get) Token: 0x06001BE8 RID: 7144 RVA: 0x00014729 File Offset: 0x00012929
		' (set) Token: 0x06001BE9 RID: 7145 RVA: 0x00130EC8 File Offset: 0x0012F0C8
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

		' Token: 0x17000ADE RID: 2782
		' (get) Token: 0x06001BEA RID: 7146 RVA: 0x00014733 File Offset: 0x00012933
		' (set) Token: 0x06001BEB RID: 7147 RVA: 0x0001473D File Offset: 0x0001293D
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17000ADF RID: 2783
		' (get) Token: 0x06001BEC RID: 7148 RVA: 0x00014746 File Offset: 0x00012946
		' (set) Token: 0x06001BED RID: 7149 RVA: 0x00014750 File Offset: 0x00012950
		Friend Overridable Property Label74 As Label

		' Token: 0x17000AE0 RID: 2784
		' (get) Token: 0x06001BEE RID: 7150 RVA: 0x00014759 File Offset: 0x00012959
		' (set) Token: 0x06001BEF RID: 7151 RVA: 0x00130F0C File Offset: 0x0012F10C
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

		' Token: 0x17000AE1 RID: 2785
		' (get) Token: 0x06001BF0 RID: 7152 RVA: 0x00014763 File Offset: 0x00012963
		' (set) Token: 0x06001BF1 RID: 7153 RVA: 0x0001476D File Offset: 0x0001296D
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000AE2 RID: 2786
		' (get) Token: 0x06001BF2 RID: 7154 RVA: 0x00014776 File Offset: 0x00012976
		' (set) Token: 0x06001BF3 RID: 7155 RVA: 0x00130F50 File Offset: 0x0012F150
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

		' Token: 0x17000AE3 RID: 2787
		' (get) Token: 0x06001BF4 RID: 7156 RVA: 0x00014780 File Offset: 0x00012980
		' (set) Token: 0x06001BF5 RID: 7157 RVA: 0x00130F94 File Offset: 0x0012F194
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

		' Token: 0x17000AE4 RID: 2788
		' (get) Token: 0x06001BF6 RID: 7158 RVA: 0x0001478A File Offset: 0x0001298A
		' (set) Token: 0x06001BF7 RID: 7159 RVA: 0x00130FD8 File Offset: 0x0012F1D8
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

		' Token: 0x17000AE5 RID: 2789
		' (get) Token: 0x06001BF8 RID: 7160 RVA: 0x00014794 File Offset: 0x00012994
		' (set) Token: 0x06001BF9 RID: 7161 RVA: 0x0013101C File Offset: 0x0012F21C
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

		' Token: 0x17000AE6 RID: 2790
		' (get) Token: 0x06001BFA RID: 7162 RVA: 0x0001479E File Offset: 0x0001299E
		' (set) Token: 0x06001BFB RID: 7163 RVA: 0x00131060 File Offset: 0x0012F260
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

		' Token: 0x17000AE7 RID: 2791
		' (get) Token: 0x06001BFC RID: 7164 RVA: 0x000147A8 File Offset: 0x000129A8
		' (set) Token: 0x06001BFD RID: 7165 RVA: 0x001310A4 File Offset: 0x0012F2A4
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

		' Token: 0x17000AE8 RID: 2792
		' (get) Token: 0x06001BFE RID: 7166 RVA: 0x000147B2 File Offset: 0x000129B2
		' (set) Token: 0x06001BFF RID: 7167 RVA: 0x001310E8 File Offset: 0x0012F2E8
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

		' Token: 0x17000AE9 RID: 2793
		' (get) Token: 0x06001C00 RID: 7168 RVA: 0x000147BC File Offset: 0x000129BC
		' (set) Token: 0x06001C01 RID: 7169 RVA: 0x0013112C File Offset: 0x0012F32C
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

		' Token: 0x17000AEA RID: 2794
		' (get) Token: 0x06001C02 RID: 7170 RVA: 0x000147C6 File Offset: 0x000129C6
		' (set) Token: 0x06001C03 RID: 7171 RVA: 0x00131170 File Offset: 0x0012F370
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

		' Token: 0x17000AEB RID: 2795
		' (get) Token: 0x06001C04 RID: 7172 RVA: 0x000147D0 File Offset: 0x000129D0
		' (set) Token: 0x06001C05 RID: 7173 RVA: 0x000147DA File Offset: 0x000129DA
		Friend Overridable Property cmbCustomerName As TextBox

		' Token: 0x17000AEC RID: 2796
		' (get) Token: 0x06001C06 RID: 7174 RVA: 0x000147E3 File Offset: 0x000129E3
		' (set) Token: 0x06001C07 RID: 7175 RVA: 0x000147ED File Offset: 0x000129ED
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17000AED RID: 2797
		' (get) Token: 0x06001C08 RID: 7176 RVA: 0x000147F6 File Offset: 0x000129F6
		' (set) Token: 0x06001C09 RID: 7177 RVA: 0x00014800 File Offset: 0x00012A00
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000AEE RID: 2798
		' (get) Token: 0x06001C0A RID: 7178 RVA: 0x00014809 File Offset: 0x00012A09
		' (set) Token: 0x06001C0B RID: 7179 RVA: 0x00014813 File Offset: 0x00012A13
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000AEF RID: 2799
		' (get) Token: 0x06001C0C RID: 7180 RVA: 0x0001481C File Offset: 0x00012A1C
		' (set) Token: 0x06001C0D RID: 7181 RVA: 0x00014826 File Offset: 0x00012A26
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000AF0 RID: 2800
		' (get) Token: 0x06001C0E RID: 7182 RVA: 0x0001482F File Offset: 0x00012A2F
		' (set) Token: 0x06001C0F RID: 7183 RVA: 0x00014839 File Offset: 0x00012A39
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000AF1 RID: 2801
		' (get) Token: 0x06001C10 RID: 7184 RVA: 0x00014842 File Offset: 0x00012A42
		' (set) Token: 0x06001C11 RID: 7185 RVA: 0x0001484C File Offset: 0x00012A4C
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000AF2 RID: 2802
		' (get) Token: 0x06001C12 RID: 7186 RVA: 0x00014855 File Offset: 0x00012A55
		' (set) Token: 0x06001C13 RID: 7187 RVA: 0x0001485F File Offset: 0x00012A5F
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000AF3 RID: 2803
		' (get) Token: 0x06001C14 RID: 7188 RVA: 0x00014868 File Offset: 0x00012A68
		' (set) Token: 0x06001C15 RID: 7189 RVA: 0x00014872 File Offset: 0x00012A72
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000AF4 RID: 2804
		' (get) Token: 0x06001C16 RID: 7190 RVA: 0x0001487B File Offset: 0x00012A7B
		' (set) Token: 0x06001C17 RID: 7191 RVA: 0x00014885 File Offset: 0x00012A85
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000AF5 RID: 2805
		' (get) Token: 0x06001C18 RID: 7192 RVA: 0x0001488E File Offset: 0x00012A8E
		' (set) Token: 0x06001C19 RID: 7193 RVA: 0x00014898 File Offset: 0x00012A98
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000AF6 RID: 2806
		' (get) Token: 0x06001C1A RID: 7194 RVA: 0x000148A1 File Offset: 0x00012AA1
		' (set) Token: 0x06001C1B RID: 7195 RVA: 0x000148AB File Offset: 0x00012AAB
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000AF7 RID: 2807
		' (get) Token: 0x06001C1C RID: 7196 RVA: 0x000148B4 File Offset: 0x00012AB4
		' (set) Token: 0x06001C1D RID: 7197 RVA: 0x000148BE File Offset: 0x00012ABE
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000AF8 RID: 2808
		' (get) Token: 0x06001C1E RID: 7198 RVA: 0x000148C7 File Offset: 0x00012AC7
		' (set) Token: 0x06001C1F RID: 7199 RVA: 0x000148D1 File Offset: 0x00012AD1
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000AF9 RID: 2809
		' (get) Token: 0x06001C20 RID: 7200 RVA: 0x000148DA File Offset: 0x00012ADA
		' (set) Token: 0x06001C21 RID: 7201 RVA: 0x000148E4 File Offset: 0x00012AE4
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000AFA RID: 2810
		' (get) Token: 0x06001C22 RID: 7202 RVA: 0x000148ED File Offset: 0x00012AED
		' (set) Token: 0x06001C23 RID: 7203 RVA: 0x000148F7 File Offset: 0x00012AF7
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000AFB RID: 2811
		' (get) Token: 0x06001C24 RID: 7204 RVA: 0x00014900 File Offset: 0x00012B00
		' (set) Token: 0x06001C25 RID: 7205 RVA: 0x0001490A File Offset: 0x00012B0A
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000AFC RID: 2812
		' (get) Token: 0x06001C26 RID: 7206 RVA: 0x00014913 File Offset: 0x00012B13
		' (set) Token: 0x06001C27 RID: 7207 RVA: 0x0001491D File Offset: 0x00012B1D
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000AFD RID: 2813
		' (get) Token: 0x06001C28 RID: 7208 RVA: 0x00014926 File Offset: 0x00012B26
		' (set) Token: 0x06001C29 RID: 7209 RVA: 0x00014930 File Offset: 0x00012B30
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000AFE RID: 2814
		' (get) Token: 0x06001C2A RID: 7210 RVA: 0x00014939 File Offset: 0x00012B39
		' (set) Token: 0x06001C2B RID: 7211 RVA: 0x00014943 File Offset: 0x00012B43
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000AFF RID: 2815
		' (get) Token: 0x06001C2C RID: 7212 RVA: 0x0001494C File Offset: 0x00012B4C
		' (set) Token: 0x06001C2D RID: 7213 RVA: 0x00014956 File Offset: 0x00012B56
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000B00 RID: 2816
		' (get) Token: 0x06001C2E RID: 7214 RVA: 0x0001495F File Offset: 0x00012B5F
		' (set) Token: 0x06001C2F RID: 7215 RVA: 0x00014969 File Offset: 0x00012B69
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000B01 RID: 2817
		' (get) Token: 0x06001C30 RID: 7216 RVA: 0x00014972 File Offset: 0x00012B72
		' (set) Token: 0x06001C31 RID: 7217 RVA: 0x0001497C File Offset: 0x00012B7C
		Friend Overridable Property Column12 As DataGridViewImageColumn

		' Token: 0x17000B02 RID: 2818
		' (get) Token: 0x06001C32 RID: 7218 RVA: 0x00014985 File Offset: 0x00012B85
		' (set) Token: 0x06001C33 RID: 7219 RVA: 0x0001498F File Offset: 0x00012B8F
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17000B03 RID: 2819
		' (get) Token: 0x06001C34 RID: 7220 RVA: 0x00014998 File Offset: 0x00012B98
		' (set) Token: 0x06001C35 RID: 7221 RVA: 0x000149A2 File Offset: 0x00012BA2
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17000B04 RID: 2820
		' (get) Token: 0x06001C36 RID: 7222 RVA: 0x000149AB File Offset: 0x00012BAB
		' (set) Token: 0x06001C37 RID: 7223 RVA: 0x000149B5 File Offset: 0x00012BB5
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17000B05 RID: 2821
		' (get) Token: 0x06001C38 RID: 7224 RVA: 0x000149BE File Offset: 0x00012BBE
		' (set) Token: 0x06001C39 RID: 7225 RVA: 0x000149C8 File Offset: 0x00012BC8
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17000B06 RID: 2822
		' (get) Token: 0x06001C3A RID: 7226 RVA: 0x000149D1 File Offset: 0x00012BD1
		' (set) Token: 0x06001C3B RID: 7227 RVA: 0x000149DB File Offset: 0x00012BDB
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17000B07 RID: 2823
		' (get) Token: 0x06001C3C RID: 7228 RVA: 0x000149E4 File Offset: 0x00012BE4
		' (set) Token: 0x06001C3D RID: 7229 RVA: 0x000149EE File Offset: 0x00012BEE
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17000B08 RID: 2824
		' (get) Token: 0x06001C3E RID: 7230 RVA: 0x000149F7 File Offset: 0x00012BF7
		' (set) Token: 0x06001C3F RID: 7231 RVA: 0x00014A01 File Offset: 0x00012C01
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17000B09 RID: 2825
		' (get) Token: 0x06001C40 RID: 7232 RVA: 0x00014A0A File Offset: 0x00012C0A
		' (set) Token: 0x06001C41 RID: 7233 RVA: 0x00014A14 File Offset: 0x00012C14
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17000B0A RID: 2826
		' (get) Token: 0x06001C42 RID: 7234 RVA: 0x00014A1D File Offset: 0x00012C1D
		' (set) Token: 0x06001C43 RID: 7235 RVA: 0x00014A27 File Offset: 0x00012C27
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17000B0B RID: 2827
		' (get) Token: 0x06001C44 RID: 7236 RVA: 0x00014A30 File Offset: 0x00012C30
		' (set) Token: 0x06001C45 RID: 7237 RVA: 0x00014A3A File Offset: 0x00012C3A
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17000B0C RID: 2828
		' (get) Token: 0x06001C46 RID: 7238 RVA: 0x00014A43 File Offset: 0x00012C43
		' (set) Token: 0x06001C47 RID: 7239 RVA: 0x00014A4D File Offset: 0x00012C4D
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17000B0D RID: 2829
		' (get) Token: 0x06001C48 RID: 7240 RVA: 0x00014A56 File Offset: 0x00012C56
		' (set) Token: 0x06001C49 RID: 7241 RVA: 0x00014A60 File Offset: 0x00012C60
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17000B0E RID: 2830
		' (get) Token: 0x06001C4A RID: 7242 RVA: 0x00014A69 File Offset: 0x00012C69
		' (set) Token: 0x06001C4B RID: 7243 RVA: 0x00014A73 File Offset: 0x00012C73
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x06001C4C RID: 7244 RVA: 0x001311B4 File Offset: 0x0012F3B4
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

		' Token: 0x06001C4D RID: 7245 RVA: 0x0013134C File Offset: 0x0012F54C
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

		' Token: 0x06001C4E RID: 7246 RVA: 0x00131590 File Offset: 0x0012F790
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

		' Token: 0x06001C4F RID: 7247 RVA: 0x001316FC File Offset: 0x0012F8FC
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

		' Token: 0x06001C50 RID: 7248 RVA: 0x00131868 File Offset: 0x0012FA68
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

		' Token: 0x06001C51 RID: 7249 RVA: 0x00131A40 File Offset: 0x0012FC40
		Public Sub auto()
			Try
				Me.txtT_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtTransactionNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001C52 RID: 7250 RVA: 0x00131AF0 File Offset: 0x0012FCF0
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

		' Token: 0x06001C53 RID: 7251 RVA: 0x00131C7C File Offset: 0x0012FE7C
		Public Sub FillCustomers()
			Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001C54 RID: 7252 RVA: 0x00131CC4 File Offset: 0x0012FEC4
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

		' Token: 0x06001C55 RID: 7253 RVA: 0x00131E00 File Offset: 0x00130000
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

		' Token: 0x06001C56 RID: 7254 RVA: 0x0013203C File Offset: 0x0013023C
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

		' Token: 0x06001C57 RID: 7255 RVA: 0x00014A7C File Offset: 0x00012C7C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06001C58 RID: 7256 RVA: 0x00014A86 File Offset: 0x00012C86
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06001C59 RID: 7257 RVA: 0x00132134 File Offset: 0x00130334
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

		' Token: 0x06001C5A RID: 7258 RVA: 0x00132228 File Offset: 0x00130428
		Private Sub txtCustNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06001C5B RID: 7259 RVA: 0x00132228 File Offset: 0x00130428
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06001C5C RID: 7260 RVA: 0x00132278 File Offset: 0x00130478
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
			Me.getdata1()
			Me.dgw.Visible = True
			Me.Label6.Visible = True
		End Sub

		' Token: 0x06001C5D RID: 7261 RVA: 0x001322EC File Offset: 0x001304EC
		Private Sub txtTransactionAmount_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) >= 0.0
			If flag Then
				Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(Me.txtTransactionAmount.Text)))
			Else
				Me.txtRsToWords.Text = ""
			End If
		End Sub

		' Token: 0x06001C5E RID: 7262 RVA: 0x00132360 File Offset: 0x00130560
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

		' Token: 0x06001C5F RID: 7263 RVA: 0x00132454 File Offset: 0x00130654
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

		' Token: 0x06001C60 RID: 7264 RVA: 0x001326D8 File Offset: 0x001308D8
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

		' Token: 0x06001C61 RID: 7265 RVA: 0x00132778 File Offset: 0x00130978
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

		' Token: 0x06001C62 RID: 7266 RVA: 0x001329CC File Offset: 0x00130BCC
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

		' Token: 0x06001C63 RID: 7267 RVA: 0x00132A8C File Offset: 0x00130C8C
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

		' Token: 0x06001C64 RID: 7268 RVA: 0x00132D2C File Offset: 0x00130F2C
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

		' Token: 0x06001C65 RID: 7269 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06001C66 RID: 7270 RVA: 0x00132DF8 File Offset: 0x00130FF8
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

		' Token: 0x06001C67 RID: 7271 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpTranactionDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C68 RID: 7272 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPaymentMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C69 RID: 7273 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C6A RID: 7274 RVA: 0x00132ED8 File Offset: 0x001310D8
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

		' Token: 0x06001C6B RID: 7275 RVA: 0x00133094 File Offset: 0x00131294
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

		' Token: 0x06001C6C RID: 7276 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTransactionAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C6D RID: 7277 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPaymentModeDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C6E RID: 7278 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C6F RID: 7279 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06001C70 RID: 7280 RVA: 0x001331E0 File Offset: 0x001313E0
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

		' Token: 0x06001C71 RID: 7281 RVA: 0x0013331C File Offset: 0x0013151C
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

		' Token: 0x06001C72 RID: 7282 RVA: 0x00014AA2 File Offset: 0x00012CA2
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06001C73 RID: 7283 RVA: 0x001335A8 File Offset: 0x001317A8
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

		' Token: 0x06001C74 RID: 7284 RVA: 0x00133684 File Offset: 0x00131884
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

		' Token: 0x06001C75 RID: 7285 RVA: 0x00133740 File Offset: 0x00131940
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06001C76 RID: 7286 RVA: 0x00133790 File Offset: 0x00131990
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

		' Token: 0x06001C77 RID: 7287 RVA: 0x0013383C File Offset: 0x00131A3C
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

		' Token: 0x06001C78 RID: 7288 RVA: 0x001338F4 File Offset: 0x00131AF4
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

		' Token: 0x06001C79 RID: 7289 RVA: 0x0013398C File Offset: 0x00131B8C
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

		' Token: 0x06001C7A RID: 7290 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06001C7B RID: 7291 RVA: 0x00133A74 File Offset: 0x00131C74
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

		' Token: 0x06001C7C RID: 7292 RVA: 0x00014ABA File Offset: 0x00012CBA
		Private Sub Button39_Click(sender As Object, e As EventArgs)
			MyProject.Forms.Form1.ShowDialog()
		End Sub

		' Token: 0x06001C7D RID: 7293 RVA: 0x00133B68 File Offset: 0x00131D68
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

		' Token: 0x06001C7E RID: 7294 RVA: 0x00133C60 File Offset: 0x00131E60
		Private Sub cmbPaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x06001C7F RID: 7295 RVA: 0x00014A7C File Offset: 0x00012C7C
		Private Sub btnNew_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06001C80 RID: 7296 RVA: 0x00133CF8 File Offset: 0x00131EF8
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

		' Token: 0x06001C81 RID: 7297 RVA: 0x00134A64 File Offset: 0x00132C64
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

		' Token: 0x06001C82 RID: 7298 RVA: 0x001353B4 File Offset: 0x001335B4
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

		' Token: 0x06001C83 RID: 7299 RVA: 0x0013541C File Offset: 0x0013361C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmCreditCustomerReceiptRecord.Reset()
			MyProject.Forms.frmCreditCustomerReceiptRecord.ShowDialog()
			MyProject.Forms.frmCreditCustomerReceiptRecord.Dispose()
		End Sub

		' Token: 0x06001C84 RID: 7300 RVA: 0x00014ACD File Offset: 0x00012CCD
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x06001C85 RID: 7301 RVA: 0x0013547C File Offset: 0x0013367C
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

		' Token: 0x06001C86 RID: 7302 RVA: 0x00135644 File Offset: 0x00133844
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

		' Token: 0x06001C87 RID: 7303 RVA: 0x0013568C File Offset: 0x0013388C
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

		' Token: 0x06001C88 RID: 7304 RVA: 0x001357FC File Offset: 0x001339FC
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dtpTranactionDate.Focus()
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x06001C89 RID: 7305 RVA: 0x00135868 File Offset: 0x00133A68
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

		' Token: 0x06001C8A RID: 7306 RVA: 0x001359A8 File Offset: 0x00133BA8
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

		' Token: 0x06001C8B RID: 7307 RVA: 0x00135A34 File Offset: 0x00133C34
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

		' Token: 0x04000B3F RID: 2879
		Private str As String

		' Token: 0x04000B40 RID: 2880
		Private OBType As String

		' Token: 0x04000B41 RID: 2881
		Private num1 As Decimal

		' Token: 0x04000B42 RID: 2882
		Private num2 As Decimal

		' Token: 0x04000B43 RID: 2883
		Private num3 As Decimal

		' Token: 0x04000B44 RID: 2884
		Private num4 As Decimal

		' Token: 0x04000B45 RID: 2885
		Private i As Integer

		' Token: 0x04000B46 RID: 2886
		Private st2 As String

		' Token: 0x04000B47 RID: 2887
		Private wappno As String

		' Token: 0x04000B48 RID: 2888
		Private bankacno As String

		' Token: 0x04000B49 RID: 2889
		Private bankifsc As String

		' Token: 0x04000B4A RID: 2890
		Private bankholdername As String

		' Token: 0x04000B4B RID: 2891
		Private ntid As String

		' Token: 0x04000B4C RID: 2892
		Private a As Double

		' Token: 0x04000B4D RID: 2893
		Private sts2 As String

		' Token: 0x04000B4E RID: 2894
		Private stw1 As String

		' Token: 0x04000B4F RID: 2895
		Private WhatsApppdfFile As String

		' Token: 0x04000B50 RID: 2896
		Private Dad As SqlDataAdapter

		' Token: 0x04000B51 RID: 2897
		Private Dst As DataSet

		' Token: 0x04000B52 RID: 2898
		Private CurrentRow As Object

		' Token: 0x04000B53 RID: 2899
		Private InvDateSts As String

		' Token: 0x04000B54 RID: 2900
		Private prevdate As DateTime
	End Class
End Namespace
