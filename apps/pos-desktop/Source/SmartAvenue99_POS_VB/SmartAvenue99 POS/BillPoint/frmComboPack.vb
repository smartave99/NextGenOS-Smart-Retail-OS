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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000CE RID: 206
	<DesignerGenerated()>
	Public Partial Class frmComboPack
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600238B RID: 9099 RVA: 0x0001856E File Offset: 0x0001676E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmComboPack_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000E1D RID: 3613
		' (get) Token: 0x0600238E RID: 9102 RVA: 0x0001858E File Offset: 0x0001678E
		' (set) Token: 0x0600238F RID: 9103 RVA: 0x00018598 File Offset: 0x00016798
		Friend Overridable Property lblBarcode As Label

		' Token: 0x17000E1E RID: 3614
		' (get) Token: 0x06002390 RID: 9104 RVA: 0x000185A1 File Offset: 0x000167A1
		' (set) Token: 0x06002391 RID: 9105 RVA: 0x0016B82C File Offset: 0x00169A2C
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E1F RID: 3615
		' (get) Token: 0x06002392 RID: 9106 RVA: 0x000185AB File Offset: 0x000167AB
		' (set) Token: 0x06002393 RID: 9107 RVA: 0x000185B5 File Offset: 0x000167B5
		Friend Overridable Property lblUser As Label

		' Token: 0x17000E20 RID: 3616
		' (get) Token: 0x06002394 RID: 9108 RVA: 0x000185BE File Offset: 0x000167BE
		' (set) Token: 0x06002395 RID: 9109 RVA: 0x000185C8 File Offset: 0x000167C8
		Friend Overridable Property Label1 As Label

		' Token: 0x17000E21 RID: 3617
		' (get) Token: 0x06002396 RID: 9110 RVA: 0x000185D1 File Offset: 0x000167D1
		' (set) Token: 0x06002397 RID: 9111 RVA: 0x000185DB File Offset: 0x000167DB
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17000E22 RID: 3618
		' (get) Token: 0x06002398 RID: 9112 RVA: 0x000185E4 File Offset: 0x000167E4
		' (set) Token: 0x06002399 RID: 9113 RVA: 0x000185EE File Offset: 0x000167EE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000E23 RID: 3619
		' (get) Token: 0x0600239A RID: 9114 RVA: 0x000185F7 File Offset: 0x000167F7
		' (set) Token: 0x0600239B RID: 9115 RVA: 0x0016B870 File Offset: 0x00169A70
		Private _Panel4 As Panel
		Friend Overridable Property Panel4 As Panel
			<CompilerGenerated()>
			Get
				Return Me._Panel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Dim paintEventHandler As PaintEventHandler = AddressOf Me.Panel4_Paint
				Dim panel As Panel = Me._Panel4
				If panel IsNot Nothing Then
					RemoveHandler panel.Paint, paintEventHandler
				End If
				Me._Panel4 = value
				panel = Me._Panel4
				If panel IsNot Nothing Then
					AddHandler panel.Paint, paintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E24 RID: 3620
		' (get) Token: 0x0600239C RID: 9116 RVA: 0x00018601 File Offset: 0x00016801
		' (set) Token: 0x0600239D RID: 9117 RVA: 0x0001860B File Offset: 0x0001680B
		Friend Overridable Property Label7 As Label

		' Token: 0x17000E25 RID: 3621
		' (get) Token: 0x0600239E RID: 9118 RVA: 0x00018614 File Offset: 0x00016814
		' (set) Token: 0x0600239F RID: 9119 RVA: 0x0001861E File Offset: 0x0001681E
		Friend Overridable Property Label2 As Label

		' Token: 0x17000E26 RID: 3622
		' (get) Token: 0x060023A0 RID: 9120 RVA: 0x00018627 File Offset: 0x00016827
		' (set) Token: 0x060023A1 RID: 9121 RVA: 0x00018631 File Offset: 0x00016831
		Friend Overridable Property Label5 As Label

		' Token: 0x17000E27 RID: 3623
		' (get) Token: 0x060023A2 RID: 9122 RVA: 0x0001863A File Offset: 0x0001683A
		' (set) Token: 0x060023A3 RID: 9123 RVA: 0x00018644 File Offset: 0x00016844
		Friend Overridable Property txtQty As TextBox

		' Token: 0x17000E28 RID: 3624
		' (get) Token: 0x060023A4 RID: 9124 RVA: 0x0001864D File Offset: 0x0001684D
		' (set) Token: 0x060023A5 RID: 9125 RVA: 0x00018657 File Offset: 0x00016857
		Friend Overridable Property Label3 As Label

		' Token: 0x17000E29 RID: 3625
		' (get) Token: 0x060023A6 RID: 9126 RVA: 0x00018660 File Offset: 0x00016860
		' (set) Token: 0x060023A7 RID: 9127 RVA: 0x0016B8B4 File Offset: 0x00169AB4
		Private _btnUpdateProduct As GelButton
		Friend Overridable Property btnUpdateProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdateProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdateProduct_Click
				Dim gelButton As GelButton = Me._btnUpdateProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdateProduct = value
				gelButton = Me._btnUpdateProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E2A RID: 3626
		' (get) Token: 0x060023A8 RID: 9128 RVA: 0x0001866A File Offset: 0x0001686A
		' (set) Token: 0x060023A9 RID: 9129 RVA: 0x0016B8F8 File Offset: 0x00169AF8
		Private _btnAddProduct As GelButton
		Friend Overridable Property btnAddProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._btnAddProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddProduct = value
				gelButton = Me._btnAddProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E2B RID: 3627
		' (get) Token: 0x060023AA RID: 9130 RVA: 0x00018674 File Offset: 0x00016874
		' (set) Token: 0x060023AB RID: 9131 RVA: 0x0016B93C File Offset: 0x00169B3C
		Private _btnRemoveProduct As GelButton
		Friend Overridable Property btnRemoveProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRemoveProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemoveProduct_Click
				Dim gelButton As GelButton = Me._btnRemoveProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRemoveProduct = value
				gelButton = Me._btnRemoveProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E2C RID: 3628
		' (get) Token: 0x060023AC RID: 9132 RVA: 0x0001867E File Offset: 0x0001687E
		' (set) Token: 0x060023AD RID: 9133 RVA: 0x00018688 File Offset: 0x00016888
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17000E2D RID: 3629
		' (get) Token: 0x060023AE RID: 9134 RVA: 0x00018691 File Offset: 0x00016891
		' (set) Token: 0x060023AF RID: 9135 RVA: 0x0016B980 File Offset: 0x00169B80
		Private _cmbProductName As TextBox
		Friend Overridable Property cmbProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox20_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductName_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.cmbProductName_KeyDown
				Dim textBox As TextBox = Me._cmbProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler2
				End If
				Me._cmbProductName = value
				textBox = Me._cmbProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
					AddHandler textBox.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17000E2E RID: 3630
		' (get) Token: 0x060023B0 RID: 9136 RVA: 0x0001869B File Offset: 0x0001689B
		' (set) Token: 0x060023B1 RID: 9137 RVA: 0x0016B9FC File Offset: 0x00169BFC
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E2F RID: 3631
		' (get) Token: 0x060023B2 RID: 9138 RVA: 0x000186A5 File Offset: 0x000168A5
		' (set) Token: 0x060023B3 RID: 9139 RVA: 0x0016BA40 File Offset: 0x00169C40
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

		' Token: 0x17000E30 RID: 3632
		' (get) Token: 0x060023B4 RID: 9140 RVA: 0x000186AF File Offset: 0x000168AF
		' (set) Token: 0x060023B5 RID: 9141 RVA: 0x0016BA84 File Offset: 0x00169C84
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler2
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17000E31 RID: 3633
		' (get) Token: 0x060023B6 RID: 9142 RVA: 0x000186B9 File Offset: 0x000168B9
		' (set) Token: 0x060023B7 RID: 9143 RVA: 0x000186C3 File Offset: 0x000168C3
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17000E32 RID: 3634
		' (get) Token: 0x060023B8 RID: 9144 RVA: 0x000186CC File Offset: 0x000168CC
		' (set) Token: 0x060023B9 RID: 9145 RVA: 0x000186D6 File Offset: 0x000168D6
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17000E33 RID: 3635
		' (get) Token: 0x060023BA RID: 9146 RVA: 0x000186DF File Offset: 0x000168DF
		' (set) Token: 0x060023BB RID: 9147 RVA: 0x000186E9 File Offset: 0x000168E9
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17000E34 RID: 3636
		' (get) Token: 0x060023BC RID: 9148 RVA: 0x000186F2 File Offset: 0x000168F2
		' (set) Token: 0x060023BD RID: 9149 RVA: 0x000186FC File Offset: 0x000168FC
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17000E35 RID: 3637
		' (get) Token: 0x060023BE RID: 9150 RVA: 0x00018705 File Offset: 0x00016905
		' (set) Token: 0x060023BF RID: 9151 RVA: 0x0001870F File Offset: 0x0001690F
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17000E36 RID: 3638
		' (get) Token: 0x060023C0 RID: 9152 RVA: 0x00018718 File Offset: 0x00016918
		' (set) Token: 0x060023C1 RID: 9153 RVA: 0x00018722 File Offset: 0x00016922
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17000E37 RID: 3639
		' (get) Token: 0x060023C2 RID: 9154 RVA: 0x0001872B File Offset: 0x0001692B
		' (set) Token: 0x060023C3 RID: 9155 RVA: 0x00018735 File Offset: 0x00016935
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17000E38 RID: 3640
		' (get) Token: 0x060023C4 RID: 9156 RVA: 0x0001873E File Offset: 0x0001693E
		' (set) Token: 0x060023C5 RID: 9157 RVA: 0x00018748 File Offset: 0x00016948
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17000E39 RID: 3641
		' (get) Token: 0x060023C6 RID: 9158 RVA: 0x00018751 File Offset: 0x00016951
		' (set) Token: 0x060023C7 RID: 9159 RVA: 0x0001875B File Offset: 0x0001695B
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17000E3A RID: 3642
		' (get) Token: 0x060023C8 RID: 9160 RVA: 0x00018764 File Offset: 0x00016964
		' (set) Token: 0x060023C9 RID: 9161 RVA: 0x0001876E File Offset: 0x0001696E
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17000E3B RID: 3643
		' (get) Token: 0x060023CA RID: 9162 RVA: 0x00018777 File Offset: 0x00016977
		' (set) Token: 0x060023CB RID: 9163 RVA: 0x00018781 File Offset: 0x00016981
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17000E3C RID: 3644
		' (get) Token: 0x060023CC RID: 9164 RVA: 0x0001878A File Offset: 0x0001698A
		' (set) Token: 0x060023CD RID: 9165 RVA: 0x00018794 File Offset: 0x00016994
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17000E3D RID: 3645
		' (get) Token: 0x060023CE RID: 9166 RVA: 0x0001879D File Offset: 0x0001699D
		' (set) Token: 0x060023CF RID: 9167 RVA: 0x000187A7 File Offset: 0x000169A7
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17000E3E RID: 3646
		' (get) Token: 0x060023D0 RID: 9168 RVA: 0x000187B0 File Offset: 0x000169B0
		' (set) Token: 0x060023D1 RID: 9169 RVA: 0x000187BA File Offset: 0x000169BA
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17000E3F RID: 3647
		' (get) Token: 0x060023D2 RID: 9170 RVA: 0x000187C3 File Offset: 0x000169C3
		' (set) Token: 0x060023D3 RID: 9171 RVA: 0x000187CD File Offset: 0x000169CD
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17000E40 RID: 3648
		' (get) Token: 0x060023D4 RID: 9172 RVA: 0x000187D6 File Offset: 0x000169D6
		' (set) Token: 0x060023D5 RID: 9173 RVA: 0x000187E0 File Offset: 0x000169E0
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17000E41 RID: 3649
		' (get) Token: 0x060023D6 RID: 9174 RVA: 0x000187E9 File Offset: 0x000169E9
		' (set) Token: 0x060023D7 RID: 9175 RVA: 0x000187F3 File Offset: 0x000169F3
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17000E42 RID: 3650
		' (get) Token: 0x060023D8 RID: 9176 RVA: 0x000187FC File Offset: 0x000169FC
		' (set) Token: 0x060023D9 RID: 9177 RVA: 0x00018806 File Offset: 0x00016A06
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17000E43 RID: 3651
		' (get) Token: 0x060023DA RID: 9178 RVA: 0x0001880F File Offset: 0x00016A0F
		' (set) Token: 0x060023DB RID: 9179 RVA: 0x00018819 File Offset: 0x00016A19
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000E44 RID: 3652
		' (get) Token: 0x060023DC RID: 9180 RVA: 0x00018822 File Offset: 0x00016A22
		' (set) Token: 0x060023DD RID: 9181 RVA: 0x0001882C File Offset: 0x00016A2C
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000E45 RID: 3653
		' (get) Token: 0x060023DE RID: 9182 RVA: 0x00018835 File Offset: 0x00016A35
		' (set) Token: 0x060023DF RID: 9183 RVA: 0x0001883F File Offset: 0x00016A3F
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17000E46 RID: 3654
		' (get) Token: 0x060023E0 RID: 9184 RVA: 0x00018848 File Offset: 0x00016A48
		' (set) Token: 0x060023E1 RID: 9185 RVA: 0x00018852 File Offset: 0x00016A52
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17000E47 RID: 3655
		' (get) Token: 0x060023E2 RID: 9186 RVA: 0x0001885B File Offset: 0x00016A5B
		' (set) Token: 0x060023E3 RID: 9187 RVA: 0x00018865 File Offset: 0x00016A65
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17000E48 RID: 3656
		' (get) Token: 0x060023E4 RID: 9188 RVA: 0x0001886E File Offset: 0x00016A6E
		' (set) Token: 0x060023E5 RID: 9189 RVA: 0x00018878 File Offset: 0x00016A78
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17000E49 RID: 3657
		' (get) Token: 0x060023E6 RID: 9190 RVA: 0x00018881 File Offset: 0x00016A81
		' (set) Token: 0x060023E7 RID: 9191 RVA: 0x0001888B File Offset: 0x00016A8B
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17000E4A RID: 3658
		' (get) Token: 0x060023E8 RID: 9192 RVA: 0x00018894 File Offset: 0x00016A94
		' (set) Token: 0x060023E9 RID: 9193 RVA: 0x0001889E File Offset: 0x00016A9E
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17000E4B RID: 3659
		' (get) Token: 0x060023EA RID: 9194 RVA: 0x000188A7 File Offset: 0x00016AA7
		' (set) Token: 0x060023EB RID: 9195 RVA: 0x000188B1 File Offset: 0x00016AB1
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17000E4C RID: 3660
		' (get) Token: 0x060023EC RID: 9196 RVA: 0x000188BA File Offset: 0x00016ABA
		' (set) Token: 0x060023ED RID: 9197 RVA: 0x000188C4 File Offset: 0x00016AC4
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17000E4D RID: 3661
		' (get) Token: 0x060023EE RID: 9198 RVA: 0x000188CD File Offset: 0x00016ACD
		' (set) Token: 0x060023EF RID: 9199 RVA: 0x000188D7 File Offset: 0x00016AD7
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17000E4E RID: 3662
		' (get) Token: 0x060023F0 RID: 9200 RVA: 0x000188E0 File Offset: 0x00016AE0
		' (set) Token: 0x060023F1 RID: 9201 RVA: 0x000188EA File Offset: 0x00016AEA
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x17000E4F RID: 3663
		' (get) Token: 0x060023F2 RID: 9202 RVA: 0x000188F3 File Offset: 0x00016AF3
		' (set) Token: 0x060023F3 RID: 9203 RVA: 0x000188FD File Offset: 0x00016AFD
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x17000E50 RID: 3664
		' (get) Token: 0x060023F4 RID: 9204 RVA: 0x00018906 File Offset: 0x00016B06
		' (set) Token: 0x060023F5 RID: 9205 RVA: 0x00018910 File Offset: 0x00016B10
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x17000E51 RID: 3665
		' (get) Token: 0x060023F6 RID: 9206 RVA: 0x00018919 File Offset: 0x00016B19
		' (set) Token: 0x060023F7 RID: 9207 RVA: 0x00018923 File Offset: 0x00016B23
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x17000E52 RID: 3666
		' (get) Token: 0x060023F8 RID: 9208 RVA: 0x0001892C File Offset: 0x00016B2C
		' (set) Token: 0x060023F9 RID: 9209 RVA: 0x00018936 File Offset: 0x00016B36
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x17000E53 RID: 3667
		' (get) Token: 0x060023FA RID: 9210 RVA: 0x0001893F File Offset: 0x00016B3F
		' (set) Token: 0x060023FB RID: 9211 RVA: 0x0016BB00 File Offset: 0x00169D00
		Private _btnClear As GelButton
		Friend Overridable Property btnClear As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim gelButton As GelButton = Me._btnClear
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnClear = value
				gelButton = Me._btnClear
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E54 RID: 3668
		' (get) Token: 0x060023FC RID: 9212 RVA: 0x00018949 File Offset: 0x00016B49
		' (set) Token: 0x060023FD RID: 9213 RVA: 0x00018953 File Offset: 0x00016B53
		Friend Overridable Property txtComboPackID As TextBox

		' Token: 0x17000E55 RID: 3669
		' (get) Token: 0x060023FE RID: 9214 RVA: 0x0001895C File Offset: 0x00016B5C
		' (set) Token: 0x060023FF RID: 9215 RVA: 0x00018966 File Offset: 0x00016B66
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000E56 RID: 3670
		' (get) Token: 0x06002400 RID: 9216 RVA: 0x0001896F File Offset: 0x00016B6F
		' (set) Token: 0x06002401 RID: 9217 RVA: 0x00018979 File Offset: 0x00016B79
		Friend Overridable Property ProductName As DataGridViewTextBoxColumn

		' Token: 0x17000E57 RID: 3671
		' (get) Token: 0x06002402 RID: 9218 RVA: 0x00018982 File Offset: 0x00016B82
		' (set) Token: 0x06002403 RID: 9219 RVA: 0x0001898C File Offset: 0x00016B8C
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17000E58 RID: 3672
		' (get) Token: 0x06002404 RID: 9220 RVA: 0x00018995 File Offset: 0x00016B95
		' (set) Token: 0x06002405 RID: 9221 RVA: 0x0001899F File Offset: 0x00016B9F
		Friend Overridable Property DefaultQty As DataGridViewTextBoxColumn

		' Token: 0x17000E59 RID: 3673
		' (get) Token: 0x06002406 RID: 9222 RVA: 0x000189A8 File Offset: 0x00016BA8
		' (set) Token: 0x06002407 RID: 9223 RVA: 0x000189B2 File Offset: 0x00016BB2
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x06002408 RID: 9224 RVA: 0x0016BB44 File Offset: 0x00169D44
		Public Sub fillGategoryName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ComboCategoryName) FROM Combopack order by 1 desc", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06002409 RID: 9225 RVA: 0x000189BB File Offset: 0x00016BBB
		Private Sub frmComboPack_Load(sender As Object, e As EventArgs)
			Me.fillGategoryName()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600240A RID: 9226 RVA: 0x0016BC78 File Offset: 0x00169E78
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

		' Token: 0x0600240B RID: 9227 RVA: 0x0016BDF0 File Offset: 0x00169FF0
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

		' Token: 0x0600240C RID: 9228 RVA: 0x0016BEAC File Offset: 0x0016A0AC
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

		' Token: 0x0600240D RID: 9229 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600240E RID: 9230 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600240F RID: 9231 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002410 RID: 9232 RVA: 0x0016BF78 File Offset: 0x0016A178
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmComboPackMaster.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmComboPackMaster.Reset()
			MyProject.Forms.frmComboPackMaster.ShowDialog()
			MyProject.Forms.frmComboPackMaster.Dispose()
		End Sub

		' Token: 0x06002411 RID: 9233 RVA: 0x0016BFD8 File Offset: 0x0016A1D8
		Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbProductName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x06002412 RID: 9234 RVA: 0x0016C028 File Offset: 0x0016A228
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				Me.dgw4.Columns(24).Visible = True
				Me.dgw4.Columns(26).Visible = True
				Me.dgw4.Columns(27).Visible = True
				Me.dgw4.Columns(28).Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 30 PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.EPPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.EPPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Product.LastPrice),RTRIM(Temp_Stock.Damage),RTRIM(Product.Description),RTRIM(Product.MinStock),(Temp_Stock.MRP),RTRIM(Product.STax),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'" + Me.cmbProductName.Text + "%' order by ProductName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002413 RID: 9235 RVA: 0x0016C380 File Offset: 0x0016A580
		Public Sub RetrieveData1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
				Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
				Dim flag As Boolean = (Conversion.Val(Me.txtQty.Text) = 0.0) Or (Operators.CompareString(Me.txtQty.Text, "", False) = 0)
				If flag Then
					Me.txtQty.Text = "1"
				Else
					Me.txtQty.Text = dataGridViewRow.Cells(29).Value.ToString()
				End If
				Me.dgw4.Visible = False
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002414 RID: 9236 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)
		End Sub

		' Token: 0x06002415 RID: 9237 RVA: 0x000189CC File Offset: 0x00016BCC
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06002416 RID: 9238 RVA: 0x0016C4A8 File Offset: 0x0016A6A8
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06002417 RID: 9239 RVA: 0x0016C4D0 File Offset: 0x0016A6D0
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
					Me.cmbProductName.Focus()
					Me.cmbProductName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.cmbProductName.Text = Me.cmbProductName.Text.Remove(Me.cmbProductName.Text.Length - 1, 1)
						Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
						Me.cmbProductName.Focus()
						Me.cmbProductName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "a"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "b"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "c"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "d"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "e"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "f"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "g"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "h"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "i"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "j"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "k"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "l"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "m"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "n"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "o"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "p"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "q"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "r"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "s"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "t"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "u"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "v"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "w"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "x"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "y"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "z"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "0"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "1"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "2"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "3"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "4"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "5"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "6"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "7"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "8"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "9"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "+"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "-"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + "\"
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
				Me.cmbProductName.Text = Me.cmbProductName.Text + ","
				Me.cmbProductName.[Select](Me.cmbProductName.Text.Length, 0)
				Me.cmbProductName.Focus()
				Me.cmbProductName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06002418 RID: 9240 RVA: 0x0016DF18 File Offset: 0x0016C118
		Private Sub cmbProductName_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06002419 RID: 9241 RVA: 0x0016DF60 File Offset: 0x0016C160
		Private Sub cmbProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getgriditemdata()
					Me.dgw4.Visible = True
					Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
					If flag3 Then
						Me.dgw4.Focus()
						Me.RetrieveData1()
					Else
						Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
						If flag4 Then
							Me.dgw4.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					e.SuppressKeyPress = True
				End If
			End If
		End Sub

		' Token: 0x0600241A RID: 9242 RVA: 0x0016E02C File Offset: 0x0016C22C
		Private Function Clear() As Object
			Me.txtProductID.Text = ""
			Me.cmbProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtQty.Text = Conversions.ToString(1)
			Me.btnRemoveProduct.Enabled = False
			Me.btnUpdateProduct.Enabled = False
			Me.btnAddProduct.Enabled = True
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600241B RID: 9243 RVA: 0x0016E0A8 File Offset: 0x0016C2A8
		Private Function ShowProduct(name As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ProductID,Product.ProductName,ComboPack_Product.Barcode,ComboPack_Product.DefaultQty,ComboPack_Product.ComboCategoryName from ComboPack_Product INNER Join Product ON ComboPack_Product.ProductID = Product.PID where ComboCategoryName = N'" + name + "' order by ComboCategoryName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1).ToString().Trim(), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600241C RID: 9244 RVA: 0x0016E1D0 File Offset: 0x0016C3D0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please Select ComboPackName", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please Select product Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Barcode Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBarcode.Focus()
					Else
						Try
							For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag4 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), Me.txtBarcode.Text.Trim(), False) = 0))
								If flag4 Then
									MessageBox.Show("Same Product already added To grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.Clear()
									Return
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "insert into ComboPack_Product(ComboCategoryName, ProductID, Barcode, DefaultQty) VALUES (@d1,@d2,@d3,@d4)"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Prepare()
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.ToString().Trim())
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtQty.Text)
						ModCommonClasses.cmd.ExecuteNonQuery()
						Me.ShowProduct(Me.cmbCategory.Text)
						ModCommonClasses.cmd.Parameters.Clear()
						ModCommonClasses.con.Close()
					End If
				End If
			End If
		End Sub

		' Token: 0x0600241D RID: 9245 RVA: 0x0016E498 File Offset: 0x0016C698
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbProductName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtQty.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.btnRemoveProduct.Enabled = True
					Me.btnUpdateProduct.Enabled = True
					Me.btnAddProduct.Enabled = False
					Me.dgw4.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600241E RID: 9246 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub DeleteRecord()
		End Sub

		' Token: 0x0600241F RID: 9247 RVA: 0x0016E5B4 File Offset: 0x0016C7B4
		Private Sub btnRemoveProduct_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), Me.txtBarcode.Text.Trim(), False) = 0), Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString().Trim(), Me.cmbCategory.Text.ToString().Trim(), False) = 0))
					If flag Then
						Try
							Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
							If flag2 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "delete from ComboPack_Product where ProductID=@d1 AND Barcode=@d2 AND ComboCategoryName=@d3 "
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text.Trim())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCategory.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.Clear()
			Me.ShowProduct(Me.cmbCategory.Text)
		End Sub

		' Token: 0x06002420 RID: 9248 RVA: 0x000189D6 File Offset: 0x00016BD6
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub

		' Token: 0x06002421 RID: 9249 RVA: 0x0016E814 File Offset: 0x0016CA14
		Private Sub btnUpdateProduct_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), Me.txtBarcode.Text.Trim(), False) = 0), Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString().Trim(), Me.cmbCategory.Text.ToString().Trim(), False) = 0))
					If flag Then
						Try
							Dim flag2 As Boolean = MessageBox.Show("Do you really want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
							If flag2 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = String.Concat(New String() { "update ComboPack_Product set DefaultQty=@d1 where ProductID= ", Me.txtProductID.Text, " AND Barcode = '", Me.txtBarcode.Text.Trim(), "' AND ComboCategoryName = '", Me.cmbCategory.Text, "'" })
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtQty.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.Clear()
			Me.ShowProduct(Me.cmbCategory.Text)
		End Sub

		' Token: 0x06002422 RID: 9250 RVA: 0x0016EA78 File Offset: 0x0016CC78
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ComboID FROM ComboPackPost ORDER BY ComboID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ComboID"))
				End If
				ModCommonClasses.rdr.Close()
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

		' Token: 0x06002423 RID: 9251 RVA: 0x0016EBCC File Offset: 0x0016CDCC
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "insert into ComboPackPost(ComboPackName) VALUES (@d1)"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text)
				ModCommonClasses.cmd.ExecuteNonQuery()
				text = Me.GenerateID()
				ModCommonClasses.cmd.Parameters.Clear()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text3 As String = "insert into ComboPack_Product(ComboID,ProductID,Barcode,DefaultQty) VALUES (@d1,@d2,@d3,@d4)"
			ModCommonClasses.cmd = New SqlCommand(text3)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Prepare()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Not dataGridViewRow.IsNewRow
					If flag Then
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.cmd.Parameters.Clear()
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06002424 RID: 9252 RVA: 0x0016EE3C File Offset: 0x0016D03C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim text As String = Me.dgw.SelectedRows(0).Cells(0).Value.ToString()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002425 RID: 9253 RVA: 0x0016EEB0 File Offset: 0x0016D0B0
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim text As String = Conversions.ToString(Me.cmbCategory.SelectedItem)
				Me.ShowProduct(text)
			Catch ex As Exception
			End Try
		End Sub
	End Class
End Namespace
