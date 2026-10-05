Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.[Shared]
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005CD RID: 1485
	<DesignerGenerated()>
	Public Partial Class frmServiceBilling
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012139 RID: 74041 RVA: 0x00A67654 File Offset: 0x00A65854
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmServiceBilling_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServiceBilling_KeyDown
			Me.ntid = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007046 RID: 28742
		' (get) Token: 0x0601213C RID: 74044 RVA: 0x0007BEAB File Offset: 0x0007A0AB
		' (set) Token: 0x0601213D RID: 74045 RVA: 0x0007BEB5 File Offset: 0x0007A0B5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007047 RID: 28743
		' (get) Token: 0x0601213E RID: 74046 RVA: 0x0007BEBE File Offset: 0x0007A0BE
		' (set) Token: 0x0601213F RID: 74047 RVA: 0x0007BEC8 File Offset: 0x0007A0C8
		Friend Overridable Property Label3 As Label

		' Token: 0x17007048 RID: 28744
		' (get) Token: 0x06012140 RID: 74048 RVA: 0x0007BED1 File Offset: 0x0007A0D1
		' (set) Token: 0x06012141 RID: 74049 RVA: 0x0007BEDB File Offset: 0x0007A0DB
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17007049 RID: 28745
		' (get) Token: 0x06012142 RID: 74050 RVA: 0x0007BEE4 File Offset: 0x0007A0E4
		' (set) Token: 0x06012143 RID: 74051 RVA: 0x0007BEEE File Offset: 0x0007A0EE
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700704A RID: 28746
		' (get) Token: 0x06012144 RID: 74052 RVA: 0x0007BEF7 File Offset: 0x0007A0F7
		' (set) Token: 0x06012145 RID: 74053 RVA: 0x0007BF01 File Offset: 0x0007A101
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700704B RID: 28747
		' (get) Token: 0x06012146 RID: 74054 RVA: 0x0007BF0A File Offset: 0x0007A10A
		' (set) Token: 0x06012147 RID: 74055 RVA: 0x0007BF14 File Offset: 0x0007A114
		Friend Overridable Property Label1 As Label

		' Token: 0x1700704C RID: 28748
		' (get) Token: 0x06012148 RID: 74056 RVA: 0x0007BF1D File Offset: 0x0007A11D
		' (set) Token: 0x06012149 RID: 74057 RVA: 0x0007BF27 File Offset: 0x0007A127
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x1700704D RID: 28749
		' (get) Token: 0x0601214A RID: 74058 RVA: 0x0007BF30 File Offset: 0x0007A130
		' (set) Token: 0x0601214B RID: 74059 RVA: 0x0007BF3A File Offset: 0x0007A13A
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x1700704E RID: 28750
		' (get) Token: 0x0601214C RID: 74060 RVA: 0x0007BF43 File Offset: 0x0007A143
		' (set) Token: 0x0601214D RID: 74061 RVA: 0x00A6A328 File Offset: 0x00A68528
		Private _dtpInvoiceDate As DateTimePicker
		Friend Overridable Property dtpInvoiceDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpInvoiceDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpInvoiceDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpInvoiceDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpInvoiceDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpInvoiceDate = value
				dateTimePicker = Me._dtpInvoiceDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700704F RID: 28751
		' (get) Token: 0x0601214E RID: 74062 RVA: 0x0007BF4D File Offset: 0x0007A14D
		' (set) Token: 0x0601214F RID: 74063 RVA: 0x0007BF57 File Offset: 0x0007A157
		Friend Overridable Property txtInvoiceNo As TextBox

		' Token: 0x17007050 RID: 28752
		' (get) Token: 0x06012150 RID: 74064 RVA: 0x0007BF60 File Offset: 0x0007A160
		' (set) Token: 0x06012151 RID: 74065 RVA: 0x0007BF6A File Offset: 0x0007A16A
		Friend Overridable Property Label4 As Label

		' Token: 0x17007051 RID: 28753
		' (get) Token: 0x06012152 RID: 74066 RVA: 0x0007BF73 File Offset: 0x0007A173
		' (set) Token: 0x06012153 RID: 74067 RVA: 0x0007BF7D File Offset: 0x0007A17D
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17007052 RID: 28754
		' (get) Token: 0x06012154 RID: 74068 RVA: 0x0007BF86 File Offset: 0x0007A186
		' (set) Token: 0x06012155 RID: 74069 RVA: 0x00A6A388 File Offset: 0x00A68588
		Private _btnSelect As Button
		Friend Overridable Property btnSelect As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelect
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelect_Click
				Dim button As Button = Me._btnSelect
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelect = value
				button = Me._btnSelect
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007053 RID: 28755
		' (get) Token: 0x06012156 RID: 74070 RVA: 0x0007BF90 File Offset: 0x0007A190
		' (set) Token: 0x06012157 RID: 74071 RVA: 0x0007BF9A File Offset: 0x0007A19A
		Friend Overridable Property lblUserType As Label

		' Token: 0x17007054 RID: 28756
		' (get) Token: 0x06012158 RID: 74072 RVA: 0x0007BFA3 File Offset: 0x0007A1A3
		' (set) Token: 0x06012159 RID: 74073 RVA: 0x0007BFAD File Offset: 0x0007A1AD
		Friend Overridable Property lblSet As Label

		' Token: 0x17007055 RID: 28757
		' (get) Token: 0x0601215A RID: 74074 RVA: 0x0007BFB6 File Offset: 0x0007A1B6
		' (set) Token: 0x0601215B RID: 74075 RVA: 0x0007BFC0 File Offset: 0x0007A1C0
		Friend Overridable Property lblUser As Label

		' Token: 0x17007056 RID: 28758
		' (get) Token: 0x0601215C RID: 74076 RVA: 0x0007BFC9 File Offset: 0x0007A1C9
		' (set) Token: 0x0601215D RID: 74077 RVA: 0x0007BFD3 File Offset: 0x0007A1D3
		Friend Overridable Property txtCID As TextBox

		' Token: 0x17007057 RID: 28759
		' (get) Token: 0x0601215E RID: 74078 RVA: 0x0007BFDC File Offset: 0x0007A1DC
		' (set) Token: 0x0601215F RID: 74079 RVA: 0x00A6A3CC File Offset: 0x00A685CC
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

		' Token: 0x17007058 RID: 28760
		' (get) Token: 0x06012160 RID: 74080 RVA: 0x0007BFE6 File Offset: 0x0007A1E6
		' (set) Token: 0x06012161 RID: 74081 RVA: 0x0007BFF0 File Offset: 0x0007A1F0
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17007059 RID: 28761
		' (get) Token: 0x06012162 RID: 74082 RVA: 0x0007BFF9 File Offset: 0x0007A1F9
		' (set) Token: 0x06012163 RID: 74083 RVA: 0x0007C003 File Offset: 0x0007A203
		Friend Overridable Property Label2 As Label

		' Token: 0x1700705A RID: 28762
		' (get) Token: 0x06012164 RID: 74084 RVA: 0x0007C00C File Offset: 0x0007A20C
		' (set) Token: 0x06012165 RID: 74085 RVA: 0x0007C016 File Offset: 0x0007A216
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700705B RID: 28763
		' (get) Token: 0x06012166 RID: 74086 RVA: 0x0007C01F File Offset: 0x0007A21F
		' (set) Token: 0x06012167 RID: 74087 RVA: 0x0007C029 File Offset: 0x0007A229
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x1700705C RID: 28764
		' (get) Token: 0x06012168 RID: 74088 RVA: 0x0007C032 File Offset: 0x0007A232
		' (set) Token: 0x06012169 RID: 74089 RVA: 0x0007C03C File Offset: 0x0007A23C
		Friend Overridable Property Label31 As Label

		' Token: 0x1700705D RID: 28765
		' (get) Token: 0x0601216A RID: 74090 RVA: 0x0007C045 File Offset: 0x0007A245
		' (set) Token: 0x0601216B RID: 74091 RVA: 0x0007C04F File Offset: 0x0007A24F
		Friend Overridable Property txtPaymentDue As TextBox

		' Token: 0x1700705E RID: 28766
		' (get) Token: 0x0601216C RID: 74092 RVA: 0x0007C058 File Offset: 0x0007A258
		' (set) Token: 0x0601216D RID: 74093 RVA: 0x00A6A410 File Offset: 0x00A68610
		Private _txtTotalPayment As TextBox
		Friend Overridable Property txtTotalPayment As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTotalPayment
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtTotalPayment_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtTotalPayment_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTotalPayment_KeyDown
				Dim textBox As TextBox = Me._txtTotalPayment
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtTotalPayment = value
				textBox = Me._txtTotalPayment
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700705F RID: 28767
		' (get) Token: 0x0601216E RID: 74094 RVA: 0x0007C062 File Offset: 0x0007A262
		' (set) Token: 0x0601216F RID: 74095 RVA: 0x0007C06C File Offset: 0x0007A26C
		Friend Overridable Property Label34 As Label

		' Token: 0x17007060 RID: 28768
		' (get) Token: 0x06012170 RID: 74096 RVA: 0x0007C075 File Offset: 0x0007A275
		' (set) Token: 0x06012171 RID: 74097 RVA: 0x0007C07F File Offset: 0x0007A27F
		Friend Overridable Property Label35 As Label

		' Token: 0x17007061 RID: 28769
		' (get) Token: 0x06012172 RID: 74098 RVA: 0x0007C088 File Offset: 0x0007A288
		' (set) Token: 0x06012173 RID: 74099 RVA: 0x0007C092 File Offset: 0x0007A292
		Friend Overridable Property txtID As TextBox

		' Token: 0x17007062 RID: 28770
		' (get) Token: 0x06012174 RID: 74100 RVA: 0x0007C09B File Offset: 0x0007A29B
		' (set) Token: 0x06012175 RID: 74101 RVA: 0x00A6A48C File Offset: 0x00A6868C
		Private _txtRemarks As TextBox
		Friend Overridable Property txtRemarks As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim textBox As TextBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				textBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007063 RID: 28771
		' (get) Token: 0x06012176 RID: 74102 RVA: 0x0007C0A5 File Offset: 0x0007A2A5
		' (set) Token: 0x06012177 RID: 74103 RVA: 0x0007C0AF File Offset: 0x0007A2AF
		Friend Overridable Property Label8 As Label

		' Token: 0x17007064 RID: 28772
		' (get) Token: 0x06012178 RID: 74104 RVA: 0x0007C0B8 File Offset: 0x0007A2B8
		' (set) Token: 0x06012179 RID: 74105 RVA: 0x0007C0C2 File Offset: 0x0007A2C2
		Friend Overridable Property txtServiceCode As TextBox

		' Token: 0x17007065 RID: 28773
		' (get) Token: 0x0601217A RID: 74106 RVA: 0x0007C0CB File Offset: 0x0007A2CB
		' (set) Token: 0x0601217B RID: 74107 RVA: 0x0007C0D5 File Offset: 0x0007A2D5
		Friend Overridable Property txtS_ID As TextBox

		' Token: 0x17007066 RID: 28774
		' (get) Token: 0x0601217C RID: 74108 RVA: 0x0007C0DE File Offset: 0x0007A2DE
		' (set) Token: 0x0601217D RID: 74109 RVA: 0x0007C0E8 File Offset: 0x0007A2E8
		Friend Overridable Property Label9 As Label

		' Token: 0x17007067 RID: 28775
		' (get) Token: 0x0601217E RID: 74110 RVA: 0x0007C0F1 File Offset: 0x0007A2F1
		' (set) Token: 0x0601217F RID: 74111 RVA: 0x00A6A4D0 File Offset: 0x00A686D0
		Private _txtRepairCharges As TextBox
		Friend Overridable Property txtRepairCharges As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRepairCharges
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtRepairCharges_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtRepairCharges_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRepairCharges_KeyDown
				Dim textBox As TextBox = Me._txtRepairCharges
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtRepairCharges = value
				textBox = Me._txtRepairCharges
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007068 RID: 28776
		' (get) Token: 0x06012180 RID: 74112 RVA: 0x0007C0FB File Offset: 0x0007A2FB
		' (set) Token: 0x06012181 RID: 74113 RVA: 0x0007C105 File Offset: 0x0007A305
		Friend Overridable Property Label14 As Label

		' Token: 0x17007069 RID: 28777
		' (get) Token: 0x06012182 RID: 74114 RVA: 0x0007C10E File Offset: 0x0007A30E
		' (set) Token: 0x06012183 RID: 74115 RVA: 0x00A6A54C File Offset: 0x00A6874C
		Private _txtUpfront As TextBox
		Friend Overridable Property txtUpfront As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUpfront
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtUpfront_TextChanged
				Dim textBox As TextBox = Me._txtUpfront
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtUpfront = value
				textBox = Me._txtUpfront
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700706A RID: 28778
		' (get) Token: 0x06012184 RID: 74116 RVA: 0x0007C118 File Offset: 0x0007A318
		' (set) Token: 0x06012185 RID: 74117 RVA: 0x0007C122 File Offset: 0x0007A322
		Friend Overridable Property Label16 As Label

		' Token: 0x1700706B RID: 28779
		' (get) Token: 0x06012186 RID: 74118 RVA: 0x0007C12B File Offset: 0x0007A32B
		' (set) Token: 0x06012187 RID: 74119 RVA: 0x0007C135 File Offset: 0x0007A335
		Friend Overridable Property Label17 As Label

		' Token: 0x1700706C RID: 28780
		' (get) Token: 0x06012188 RID: 74120 RVA: 0x0007C13E File Offset: 0x0007A33E
		' (set) Token: 0x06012189 RID: 74121 RVA: 0x0007C148 File Offset: 0x0007A348
		Friend Overridable Property txtServiceTaxAmount As TextBox

		' Token: 0x1700706D RID: 28781
		' (get) Token: 0x0601218A RID: 74122 RVA: 0x0007C151 File Offset: 0x0007A351
		' (set) Token: 0x0601218B RID: 74123 RVA: 0x00A6A590 File Offset: 0x00A68790
		Private _txtServiceTaxPer As TextBox
		Friend Overridable Property txtServiceTaxPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtServiceTaxPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtServiceTaxPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtServiceTaxPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtServiceTaxPer_KeyDown
				Dim textBox As TextBox = Me._txtServiceTaxPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtServiceTaxPer = value
				textBox = Me._txtServiceTaxPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700706E RID: 28782
		' (get) Token: 0x0601218C RID: 74124 RVA: 0x0007C15B File Offset: 0x0007A35B
		' (set) Token: 0x0601218D RID: 74125 RVA: 0x0007C165 File Offset: 0x0007A365
		Friend Overridable Property Label18 As Label

		' Token: 0x1700706F RID: 28783
		' (get) Token: 0x0601218E RID: 74126 RVA: 0x0007C16E File Offset: 0x0007A36E
		' (set) Token: 0x0601218F RID: 74127 RVA: 0x0007C178 File Offset: 0x0007A378
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17007070 RID: 28784
		' (get) Token: 0x06012190 RID: 74128 RVA: 0x0007C181 File Offset: 0x0007A381
		' (set) Token: 0x06012191 RID: 74129 RVA: 0x00A6A60C File Offset: 0x00A6880C
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

		' Token: 0x17007071 RID: 28785
		' (get) Token: 0x06012192 RID: 74130 RVA: 0x0007C18B File Offset: 0x0007A38B
		' (set) Token: 0x06012193 RID: 74131 RVA: 0x0007C195 File Offset: 0x0007A395
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17007072 RID: 28786
		' (get) Token: 0x06012194 RID: 74132 RVA: 0x0007C19E File Offset: 0x0007A39E
		' (set) Token: 0x06012195 RID: 74133 RVA: 0x0007C1A8 File Offset: 0x0007A3A8
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x17007073 RID: 28787
		' (get) Token: 0x06012196 RID: 74134 RVA: 0x0007C1B1 File Offset: 0x0007A3B1
		' (set) Token: 0x06012197 RID: 74135 RVA: 0x0007C1BB File Offset: 0x0007A3BB
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17007074 RID: 28788
		' (get) Token: 0x06012198 RID: 74136 RVA: 0x0007C1C4 File Offset: 0x0007A3C4
		' (set) Token: 0x06012199 RID: 74137 RVA: 0x0007C1CE File Offset: 0x0007A3CE
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17007075 RID: 28789
		' (get) Token: 0x0601219A RID: 74138 RVA: 0x0007C1D7 File Offset: 0x0007A3D7
		' (set) Token: 0x0601219B RID: 74139 RVA: 0x00A6A650 File Offset: 0x00A68850
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

		' Token: 0x17007076 RID: 28790
		' (get) Token: 0x0601219C RID: 74140 RVA: 0x0007C1E1 File Offset: 0x0007A3E1
		' (set) Token: 0x0601219D RID: 74141 RVA: 0x0007C1EB File Offset: 0x0007A3EB
		Friend Overridable Property Label6 As Label

		' Token: 0x17007077 RID: 28791
		' (get) Token: 0x0601219E RID: 74142 RVA: 0x0007C1F4 File Offset: 0x0007A3F4
		' (set) Token: 0x0601219F RID: 74143 RVA: 0x0007C1FE File Offset: 0x0007A3FE
		Friend Overridable Property Label15 As Label

		' Token: 0x17007078 RID: 28792
		' (get) Token: 0x060121A0 RID: 74144 RVA: 0x0007C207 File Offset: 0x0007A407
		' (set) Token: 0x060121A1 RID: 74145 RVA: 0x0007C211 File Offset: 0x0007A411
		Friend Overridable Property Label7 As Label

		' Token: 0x17007079 RID: 28793
		' (get) Token: 0x060121A2 RID: 74146 RVA: 0x0007C21A File Offset: 0x0007A41A
		' (set) Token: 0x060121A3 RID: 74147 RVA: 0x0007C224 File Offset: 0x0007A424
		Friend Overridable Property F2 As TextBox

		' Token: 0x1700707A RID: 28794
		' (get) Token: 0x060121A4 RID: 74148 RVA: 0x0007C22D File Offset: 0x0007A42D
		' (set) Token: 0x060121A5 RID: 74149 RVA: 0x0007C237 File Offset: 0x0007A437
		Friend Overridable Property F1 As TextBox

		' Token: 0x1700707B RID: 28795
		' (get) Token: 0x060121A6 RID: 74150 RVA: 0x0007C240 File Offset: 0x0007A440
		' (set) Token: 0x060121A7 RID: 74151 RVA: 0x00A6A694 File Offset: 0x00A68894
		Private _btnGetdata As GelButton
		Friend Overridable Property btnGetdata As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetdata
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetdata_Click
				Dim gelButton As GelButton = Me._btnGetdata
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetdata = value
				gelButton = Me._btnGetdata
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700707C RID: 28796
		' (get) Token: 0x060121A8 RID: 74152 RVA: 0x0007C24A File Offset: 0x0007A44A
		' (set) Token: 0x060121A9 RID: 74153 RVA: 0x00A6A6D8 File Offset: 0x00A688D8
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
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

		' Token: 0x1700707D RID: 28797
		' (get) Token: 0x060121AA RID: 74154 RVA: 0x0007C254 File Offset: 0x0007A454
		' (set) Token: 0x060121AB RID: 74155 RVA: 0x00A6A71C File Offset: 0x00A6891C
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

		' Token: 0x1700707E RID: 28798
		' (get) Token: 0x060121AC RID: 74156 RVA: 0x0007C25E File Offset: 0x0007A45E
		' (set) Token: 0x060121AD RID: 74157 RVA: 0x00A6A760 File Offset: 0x00A68960
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

		' Token: 0x1700707F RID: 28799
		' (get) Token: 0x060121AE RID: 74158 RVA: 0x0007C268 File Offset: 0x0007A468
		' (set) Token: 0x060121AF RID: 74159 RVA: 0x00A6A7A4 File Offset: 0x00A689A4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
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

		' Token: 0x17007080 RID: 28800
		' (get) Token: 0x060121B0 RID: 74160 RVA: 0x0007C272 File Offset: 0x0007A472
		' (set) Token: 0x060121B1 RID: 74161 RVA: 0x00A6A7E8 File Offset: 0x00A689E8
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

		' Token: 0x060121B2 RID: 74162 RVA: 0x00A6A82C File Offset: 0x00A68A2C
		Public Sub Reset()
			Me.txtCID.Text = ""
			Me.txtRemarks.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtInvoiceNo.Text = ""
			Me.txtGrandTotal.Text = ""
			Me.txtTotalPayment.Text = ""
			Me.txtPaymentDue.Text = ""
			Me.txtServiceCode.Text = ""
			Me.txtRepairCharges.Text = ""
			Me.txtUpfront.Text = ""
			Me.txtServiceTaxPer.Text = "0.00"
			Me.txtServiceTaxAmount.Text = "0.00"
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnPrint.Enabled = False
			Me.txtContactNo.Text = ""
			Me.auto()
		End Sub

		' Token: 0x060121B3 RID: 74163 RVA: 0x00A6A974 File Offset: 0x00A68B74
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 Inv_ID FROM InvoiceInfo1 ORDER BY Inv_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("Inv_ID"))
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

		' Token: 0x060121B4 RID: 74164 RVA: 0x00A6AAE0 File Offset: 0x00A68CE0
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrSerBill ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x060121B5 RID: 74165 RVA: 0x00A6AC4C File Offset: 0x00A68E4C
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtInvoiceNo.Text = String.Concat(New String() { "SB-", Me.GenerateIDSr(), "-", Me.F1.Text, "/", Me.F2.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060121B6 RID: 74166 RVA: 0x00A6AD04 File Offset: 0x00A68F04
		Private Sub btnSelect_Click(sender As Object, e As EventArgs)
			Me.txtRepairCharges.Focus()
			MyProject.Forms.frmServicesRecord1.Reset()
			MyProject.Forms.frmServicesRecord1.lblSet.Text = "Billing"
			MyProject.Forms.frmServicesRecord1.ShowDialog()
		End Sub

		' Token: 0x060121B7 RID: 74167 RVA: 0x0007C27C File Offset: 0x0007A47C
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCurrentStock.lblSet.Text = "Billing1"
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.ShowDialog()
		End Sub

		' Token: 0x060121B8 RID: 74168 RVA: 0x00A6AD58 File Offset: 0x00A68F58
		Public Sub Print()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptServiceBillingInvoice As rptServiceBillingInvoice = New rptServiceBillingInvoice()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT InvoiceInfo1.Inv_ID, InvoiceInfo1.InvoiceNo, InvoiceInfo1.InvoiceDate, InvoiceInfo1.ServiceID, InvoiceInfo1.RepairCharges, InvoiceInfo1.Upfront, InvoiceInfo1.ServiceTaxPer, InvoiceInfo1.ServiceTax,InvoiceInfo1.GrandTotal, InvoiceInfo1.TotalPaid, InvoiceInfo1.Balance, InvoiceInfo1.Remarks, Service.S_ID, Service.ServiceCode, Service.CustomerID, Service.ServiceType, Service.ServiceCreationDate,Service.ItemDescription, Service.ProblemDescription, Service.ChargesQuote, Service.AdvanceDeposit, Service.EstimatedRepairDate, Service.Remarks AS Expr1, Service.Status, Customer.ID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr3, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo1 INNER JOIN Service ON InvoiceInfo1.ServiceID = Service.S_ID INNER JOIN Customer ON Service.CustomerID = Customer.ID where InvoiceInfo1.Invoiceno=@d1"
				sqlCommand.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text)
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "InvoiceInfo1")
				sqlDataAdapter.Fill(dataSet, "Service")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptServiceBillingInvoice.SetDataSource(dataSet)
				rptServiceBillingInvoice.SetParameterValue("p1", Me.txtCustomerID.Text)
				rptServiceBillingInvoice.SetParameterValue("p2", DateAndTime.Today)
				rptServiceBillingInvoice.SetParameterValue("0", Me.TextBox9.Text.Trim())
				Dim parameterFields As ParameterFields = New ParameterFields()
				Dim parameterField As ParameterField = New ParameterField()
				Dim parameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
				parameterField.ParameterFieldName = "0"
				parameterDiscreteValue.Value = Me.TextBox9.Text.Trim()
				parameterField.CurrentValues.Add(parameterDiscreteValue)
				parameterFields.Add(parameterField)
				MyProject.Forms.frmReport.CrystalReportViewer1.ParameterFieldInfo = parameterFields
				MyProject.Forms.frmReport.CrystalReportViewer1.Refresh()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptServiceBillingInvoice
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060121B9 RID: 74169 RVA: 0x00A6AFBC File Offset: 0x00A691BC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from InvoiceInfo1 where Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Services")
					ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Receipt")
					ModFunc.CustomerLedgerDelete(Me.txtInvoiceNo.Text)
					ModFunc.SrSerBillDelete(Me.txtInvoiceNo.Text)
					Dim text2 As String = "deleted the service bill having invoice no. '" + Me.txtInvoiceNo.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060121BA RID: 74170 RVA: 0x00A6B170 File Offset: 0x00A69370
		Public Sub Compute1()
			Dim num As Double = Conversion.Val(Me.txtRepairCharges.Text) * Conversion.Val(Me.txtServiceTaxPer.Text) / 100.0
			num = Math.Round(num, 2)
			Me.txtServiceTaxAmount.Text = Conversions.ToString(num)
			Dim num2 As Double = Conversion.Val(Me.txtRepairCharges.Text) + Conversion.Val(Me.txtServiceTaxAmount.Text) - Conversion.Val(Me.txtUpfront.Text)
			num2 = Math.Round(num2, 2)
			Me.txtGrandTotal.Text = Conversions.ToString(num2)
			Dim num3 As Double = Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtTotalPayment.Text)
			num3 = Math.Round(num3, 2)
			Me.txtPaymentDue.Text = Conversions.ToString(num3)
		End Sub

		' Token: 0x060121BB RID: 74171 RVA: 0x0007C2B9 File Offset: 0x0007A4B9
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060121BC RID: 74172 RVA: 0x00A6B250 File Offset: 0x00A69450
		Private Sub txtRepairCharges_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtRepairCharges.Text
					Dim selectionStart As Integer = Me.txtRepairCharges.SelectionStart
					Dim selectionLength As Integer = Me.txtRepairCharges.SelectionLength
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

		' Token: 0x060121BD RID: 74173 RVA: 0x00A6B348 File Offset: 0x00A69548
		Private Sub txtServiceTaxPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtServiceTaxPer.Text
					Dim selectionStart As Integer = Me.txtServiceTaxPer.SelectionStart
					Dim selectionLength As Integer = Me.txtServiceTaxPer.SelectionLength
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

		' Token: 0x060121BE RID: 74174 RVA: 0x0007C2D5 File Offset: 0x0007A4D5
		Private Sub txtRepairCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute1()
		End Sub

		' Token: 0x060121BF RID: 74175 RVA: 0x0007C2D5 File Offset: 0x0007A4D5
		Private Sub txtServiceTaxPer_TextChanged(sender As Object, e As EventArgs)
			Me.Compute1()
		End Sub

		' Token: 0x060121C0 RID: 74176 RVA: 0x0007C2D5 File Offset: 0x0007A4D5
		Private Sub txtUpfront_TextChanged(sender As Object, e As EventArgs)
			Me.Compute1()
		End Sub

		' Token: 0x060121C1 RID: 74177 RVA: 0x00A6B440 File Offset: 0x00A69640
		Private Sub txtTotalPayment_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtTotalPayment.Text
					Dim selectionStart As Integer = Me.txtTotalPayment.SelectionStart
					Dim selectionLength As Integer = Me.txtTotalPayment.SelectionLength
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

		' Token: 0x060121C2 RID: 74178 RVA: 0x0007C2D5 File Offset: 0x0007A4D5
		Private Sub txtTotalPayment_TextChanged(sender As Object, e As EventArgs)
			Me.Compute1()
		End Sub

		' Token: 0x060121C3 RID: 74179 RVA: 0x00A6B538 File Offset: 0x00A69738
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

		' Token: 0x060121C4 RID: 74180 RVA: 0x00A6B62C File Offset: 0x00A6982C
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName), RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtcompname.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
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

		' Token: 0x060121C5 RID: 74181 RVA: 0x0007C2DF File Offset: 0x0007A4DF
		Private Sub frmServiceBilling_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.auto()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Convert_Language()
		End Sub

		' Token: 0x060121C6 RID: 74182 RVA: 0x00A6B798 File Offset: 0x00A69998
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

		' Token: 0x060121C7 RID: 74183 RVA: 0x00A6BA38 File Offset: 0x00A69C38
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

		' Token: 0x060121C8 RID: 74184 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060121C9 RID: 74185 RVA: 0x00A6BAF4 File Offset: 0x00A69CF4
		Private Sub dtpInvoiceDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpInvoiceDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpInvoiceDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpInvoiceDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpInvoiceDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060121CA RID: 74186 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpInvoiceDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060121CB RID: 74187 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRepairCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060121CC RID: 74188 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtServiceTaxPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060121CD RID: 74189 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTotalPayment_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060121CE RID: 74190 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060121CF RID: 74191 RVA: 0x00A6BBA0 File Offset: 0x00A69DA0
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x060121D0 RID: 74192 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServiceBilling_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060121D1 RID: 74193 RVA: 0x00A6BBF0 File Offset: 0x00A69DF0
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

		' Token: 0x060121D2 RID: 74194 RVA: 0x00A6BCE8 File Offset: 0x00A69EE8
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 InvoiceDate from InvoiceInfo1 order by Inv_ID DESC"
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
					Me.dtpInvoiceDate.Value = Me.prevdate
				Else
					Me.dtpInvoiceDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060121D3 RID: 74195 RVA: 0x0007C305 File Offset: 0x0007A505
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub

		' Token: 0x060121D4 RID: 74196 RVA: 0x00A6BE28 File Offset: 0x00A6A028
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.auto()
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve service details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtRepairCharges.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter service charges", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRepairCharges.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtServiceTaxPer.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtServiceTaxPer.Focus()
					Else
						Dim flag4 As Boolean = Conversion.Val(Me.txtTotalPayment.Text) > Conversion.Val(Me.txtGrandTotal.Text)
						If flag4 Then
							MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select * from Company"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = Not ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "insert into InvoiceInfo1(Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d8,@d9,@d10,@d11,@d12,@d13)"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpInvoiceDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtS_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtRepairCharges.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtUpfront.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtServiceTaxPer.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtServiceTaxAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtGrandTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotalPayment.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtPaymentDue.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModFunc.LedgerSave(Me.dtpInvoiceDate.Value.[Date], Me.txtCustomerName.Text, Me.txtInvoiceNo.Text, "Services", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									ModFunc.LedgerSave(Me.dtpInvoiceDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTotalPayment.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									ModFunc.CustomerLedgerSave(Me.dtpInvoiceDate.Value.[Date], Me.txtCustomerName.Text, Me.txtInvoiceNo.Text, "Services", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
									ModFunc.CustomerLedgerSave(Me.dtpInvoiceDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTotalPayment.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into SrSerBill(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									Dim text4 As String = "added the new service bill having Invoice no. '" + Me.txtInvoiceNo.Text + "'"
									ModFunc.LogFunc(Me.lblUser.Text, text4)
									Try
										Dim flag7 As Boolean = ModFunc.CheckForInternetConnection()
										If flag7 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text5 As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes' and AutoSMS='Yes'"
											ModCommonClasses.cmd = New SqlCommand(text5)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												Me.st2 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
												Dim text6 As String = String.Concat(New String() { "Dear Sir/Madam, ", Me.txtCustomerName.Text, " you have successfully received your item having invoice no. ", Me.txtInvoiceNo.Text, ", Best wishes from ", Me.txtcompname.Text.Trim(), "." })
												ModFunc.SMSFunc(Me.txtContactNo.Text, text6, Me.st2)
												ModFunc.SMS(text6)
												MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
											End If
										Else
											MessageBox.Show("SMS is not sent", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End If
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									ModCommonClasses.con.Close()
									Me.btnSave.Enabled = False
									ModFunc.RefreshRecords()
									Dim flag10 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print Service Invoice ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
									If flag10 Then
										Me.Print()
									Else
										Me.Reset()
									End If
								Catch ex2 As Exception
									MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060121D5 RID: 74197 RVA: 0x00A6C6D8 File Offset: 0x00A6A8D8
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve service details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtRepairCharges.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter service charges", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRepairCharges.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtServiceTaxPer.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtServiceTaxPer.Focus()
					Else
						Dim flag4 As Boolean = Conversion.Val(Me.txtTotalPayment.Text) > Conversion.Val(Me.txtGrandTotal.Text)
						If flag4 Then
							MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update InvoiceInfo1 set InvoiceNo=@d2, InvoiceDate=@d3, ServiceID=@d4, RepairCharges=@d5, Upfront=@d6, ServiceTaxPer=@d8, ServiceTax=@d9, GrandTotal=@d10, TotalPaid=@d11, Balance=@d12, Remarks=@d13 where Inv_ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpInvoiceDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtS_ID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtRepairCharges.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtUpfront.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtServiceTaxPer.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtServiceTaxAmount.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtGrandTotal.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotalPayment.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtPaymentDue.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtRemarks.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Services")
								ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Receipt")
								ModFunc.CustomerLedgerDelete(Me.txtInvoiceNo.Text)
								ModFunc.LedgerSave(Me.dtpInvoiceDate.Value.[Date], Me.txtCustomerName.Text, Me.txtInvoiceNo.Text, "Services", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text)
								ModFunc.LedgerSave(Me.dtpInvoiceDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTotalPayment.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
								ModFunc.CustomerLedgerSave(Me.dtpInvoiceDate.Value.[Date], Me.txtCustomerName.Text, Me.txtInvoiceNo.Text, "Services", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
								ModFunc.CustomerLedgerSave(Me.dtpInvoiceDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtTotalPayment.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
								Dim text2 As String = "updated the service bill having invoice no. '" + Me.txtInvoiceNo.Text + "'"
								ModFunc.LogFunc(Me.lblUser.Text, text2)
								Me.btnUpdate.Enabled = False
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060121D6 RID: 74198 RVA: 0x00A6CCDC File Offset: 0x00A6AEDC
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

		' Token: 0x060121D7 RID: 74199 RVA: 0x00A6CD44 File Offset: 0x00A6AF44
		Private Sub btnGetdata_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServiceBillingRecord.lblSet.Text = "Billing"
			MyProject.Forms.frmServiceBillingRecord.Reset()
			MyProject.Forms.frmServiceBillingRecord.Reset()
			MyProject.Forms.frmServiceBillingRecord.ShowDialog()
		End Sub

		' Token: 0x060121D8 RID: 74200 RVA: 0x0007C316 File Offset: 0x0007A516
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x04006CCB RID: 27851
		Private st2 As String

		' Token: 0x04006CCC RID: 27852
		Private ntid As String

		' Token: 0x04006CCD RID: 27853
		Private InvDateSts As String

		' Token: 0x04006CCE RID: 27854
		Private prevdate As DateTime
	End Class
End Namespace
