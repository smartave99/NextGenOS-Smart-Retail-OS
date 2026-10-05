Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001FA RID: 506
	<DesignerGenerated()>
	Public Partial Class frmStock_Inward_Notification
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060090F1 RID: 37105 RVA: 0x00046DF3 File Offset: 0x00044FF3
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170035A3 RID: 13731
		' (get) Token: 0x060090F4 RID: 37108 RVA: 0x00046E25 File Offset: 0x00045025
		' (set) Token: 0x060090F5 RID: 37109 RVA: 0x00046E2F File Offset: 0x0004502F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170035A4 RID: 13732
		' (get) Token: 0x060090F6 RID: 37110 RVA: 0x00046E38 File Offset: 0x00045038
		' (set) Token: 0x060090F7 RID: 37111 RVA: 0x00046E42 File Offset: 0x00045042
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170035A5 RID: 13733
		' (get) Token: 0x060090F8 RID: 37112 RVA: 0x00046E4B File Offset: 0x0004504B
		' (set) Token: 0x060090F9 RID: 37113 RVA: 0x00046E55 File Offset: 0x00045055
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170035A6 RID: 13734
		' (get) Token: 0x060090FA RID: 37114 RVA: 0x00046E5E File Offset: 0x0004505E
		' (set) Token: 0x060090FB RID: 37115 RVA: 0x00046E68 File Offset: 0x00045068
		Friend Overridable Property Label2 As Label

		' Token: 0x170035A7 RID: 13735
		' (get) Token: 0x060090FC RID: 37116 RVA: 0x00046E71 File Offset: 0x00045071
		' (set) Token: 0x060090FD RID: 37117 RVA: 0x00046E7B File Offset: 0x0004507B
		Friend Overridable Property Label4 As Label

		' Token: 0x170035A8 RID: 13736
		' (get) Token: 0x060090FE RID: 37118 RVA: 0x00046E84 File Offset: 0x00045084
		' (set) Token: 0x060090FF RID: 37119 RVA: 0x00046E8E File Offset: 0x0004508E
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170035A9 RID: 13737
		' (get) Token: 0x06009100 RID: 37120 RVA: 0x00046E97 File Offset: 0x00045097
		' (set) Token: 0x06009101 RID: 37121 RVA: 0x00046EA1 File Offset: 0x000450A1
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170035AA RID: 13738
		' (get) Token: 0x06009102 RID: 37122 RVA: 0x00046EAA File Offset: 0x000450AA
		' (set) Token: 0x06009103 RID: 37123 RVA: 0x00046EB4 File Offset: 0x000450B4
		Friend Overridable Property lblSet As Label

		' Token: 0x170035AB RID: 13739
		' (get) Token: 0x06009104 RID: 37124 RVA: 0x00046EBD File Offset: 0x000450BD
		' (set) Token: 0x06009105 RID: 37125 RVA: 0x00046EC7 File Offset: 0x000450C7
		Friend Overridable Property Label1 As Label

		' Token: 0x170035AC RID: 13740
		' (get) Token: 0x06009106 RID: 37126 RVA: 0x00046ED0 File Offset: 0x000450D0
		' (set) Token: 0x06009107 RID: 37127 RVA: 0x00046EDA File Offset: 0x000450DA
		Friend Overridable Property lblUserType As Label

		' Token: 0x170035AD RID: 13741
		' (get) Token: 0x06009108 RID: 37128 RVA: 0x00046EE3 File Offset: 0x000450E3
		' (set) Token: 0x06009109 RID: 37129 RVA: 0x00046EED File Offset: 0x000450ED
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170035AE RID: 13742
		' (get) Token: 0x0600910A RID: 37130 RVA: 0x00046EF6 File Offset: 0x000450F6
		' (set) Token: 0x0600910B RID: 37131 RVA: 0x00046F00 File Offset: 0x00045100
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170035AF RID: 13743
		' (get) Token: 0x0600910C RID: 37132 RVA: 0x00046F09 File Offset: 0x00045109
		' (set) Token: 0x0600910D RID: 37133 RVA: 0x00046F13 File Offset: 0x00045113
		Friend Overridable Property Label13 As Label

		' Token: 0x170035B0 RID: 13744
		' (get) Token: 0x0600910E RID: 37134 RVA: 0x00046F1C File Offset: 0x0004511C
		' (set) Token: 0x0600910F RID: 37135 RVA: 0x00046F26 File Offset: 0x00045126
		Friend Overridable Property Label12 As Label

		' Token: 0x170035B1 RID: 13745
		' (get) Token: 0x06009110 RID: 37136 RVA: 0x00046F2F File Offset: 0x0004512F
		' (set) Token: 0x06009111 RID: 37137 RVA: 0x00046F39 File Offset: 0x00045139
		Friend Overridable Property Label11 As Label

		' Token: 0x170035B2 RID: 13746
		' (get) Token: 0x06009112 RID: 37138 RVA: 0x00046F42 File Offset: 0x00045142
		' (set) Token: 0x06009113 RID: 37139 RVA: 0x00046F4C File Offset: 0x0004514C
		Friend Overridable Property Label16 As Label

		' Token: 0x170035B3 RID: 13747
		' (get) Token: 0x06009114 RID: 37140 RVA: 0x00046F55 File Offset: 0x00045155
		' (set) Token: 0x06009115 RID: 37141 RVA: 0x00046F5F File Offset: 0x0004515F
		Friend Overridable Property Label15 As Label

		' Token: 0x170035B4 RID: 13748
		' (get) Token: 0x06009116 RID: 37142 RVA: 0x00046F68 File Offset: 0x00045168
		' (set) Token: 0x06009117 RID: 37143 RVA: 0x00046F72 File Offset: 0x00045172
		Friend Overridable Property Label14 As Label

		' Token: 0x170035B5 RID: 13749
		' (get) Token: 0x06009118 RID: 37144 RVA: 0x00046F7B File Offset: 0x0004517B
		' (set) Token: 0x06009119 RID: 37145 RVA: 0x00046F85 File Offset: 0x00045185
		Friend Overridable Property Label18 As Label

		' Token: 0x170035B6 RID: 13750
		' (get) Token: 0x0600911A RID: 37146 RVA: 0x00046F8E File Offset: 0x0004518E
		' (set) Token: 0x0600911B RID: 37147 RVA: 0x00046F98 File Offset: 0x00045198
		Friend Overridable Property Label17 As Label

		' Token: 0x170035B7 RID: 13751
		' (get) Token: 0x0600911C RID: 37148 RVA: 0x00046FA1 File Offset: 0x000451A1
		' (set) Token: 0x0600911D RID: 37149 RVA: 0x00046FAB File Offset: 0x000451AB
		Friend Overridable Property Label20 As Label

		' Token: 0x170035B8 RID: 13752
		' (get) Token: 0x0600911E RID: 37150 RVA: 0x00046FB4 File Offset: 0x000451B4
		' (set) Token: 0x0600911F RID: 37151 RVA: 0x00046FBE File Offset: 0x000451BE
		Friend Overridable Property Label19 As Label

		' Token: 0x170035B9 RID: 13753
		' (get) Token: 0x06009120 RID: 37152 RVA: 0x00046FC7 File Offset: 0x000451C7
		' (set) Token: 0x06009121 RID: 37153 RVA: 0x0069A994 File Offset: 0x00698B94
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170035BA RID: 13754
		' (get) Token: 0x06009122 RID: 37154 RVA: 0x00046FD1 File Offset: 0x000451D1
		' (set) Token: 0x06009123 RID: 37155 RVA: 0x0069A9D8 File Offset: 0x00698BD8
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

		' Token: 0x170035BB RID: 13755
		' (get) Token: 0x06009124 RID: 37156 RVA: 0x00046FDB File Offset: 0x000451DB
		' (set) Token: 0x06009125 RID: 37157 RVA: 0x0069AA1C File Offset: 0x00698C1C
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

		' Token: 0x170035BC RID: 13756
		' (get) Token: 0x06009126 RID: 37158 RVA: 0x00046FE5 File Offset: 0x000451E5
		' (set) Token: 0x06009127 RID: 37159 RVA: 0x0069AA60 File Offset: 0x00698C60
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

		' Token: 0x170035BD RID: 13757
		' (get) Token: 0x06009128 RID: 37160 RVA: 0x00046FEF File Offset: 0x000451EF
		' (set) Token: 0x06009129 RID: 37161 RVA: 0x0069AAA4 File Offset: 0x00698CA4
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170035BE RID: 13758
		' (get) Token: 0x0600912A RID: 37162 RVA: 0x00046FF9 File Offset: 0x000451F9
		' (set) Token: 0x0600912B RID: 37163 RVA: 0x00047003 File Offset: 0x00045203
		Friend Overridable Property lblFrom_Company_id As Label

		' Token: 0x170035BF RID: 13759
		' (get) Token: 0x0600912C RID: 37164 RVA: 0x0004700C File Offset: 0x0004520C
		' (set) Token: 0x0600912D RID: 37165 RVA: 0x00047016 File Offset: 0x00045216
		Friend Overridable Property lblUser As Label

		' Token: 0x170035C0 RID: 13760
		' (get) Token: 0x0600912E RID: 37166 RVA: 0x0004701F File Offset: 0x0004521F
		' (set) Token: 0x0600912F RID: 37167 RVA: 0x00047029 File Offset: 0x00045229
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x170035C1 RID: 13761
		' (get) Token: 0x06009130 RID: 37168 RVA: 0x00047032 File Offset: 0x00045232
		' (set) Token: 0x06009131 RID: 37169 RVA: 0x0004703C File Offset: 0x0004523C
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x170035C2 RID: 13762
		' (get) Token: 0x06009132 RID: 37170 RVA: 0x00047045 File Offset: 0x00045245
		' (set) Token: 0x06009133 RID: 37171 RVA: 0x0004704F File Offset: 0x0004524F
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x170035C3 RID: 13763
		' (get) Token: 0x06009134 RID: 37172 RVA: 0x00047058 File Offset: 0x00045258
		' (set) Token: 0x06009135 RID: 37173 RVA: 0x00047062 File Offset: 0x00045262
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170035C4 RID: 13764
		' (get) Token: 0x06009136 RID: 37174 RVA: 0x0004706B File Offset: 0x0004526B
		' (set) Token: 0x06009137 RID: 37175 RVA: 0x00047075 File Offset: 0x00045275
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x170035C5 RID: 13765
		' (get) Token: 0x06009138 RID: 37176 RVA: 0x0004707E File Offset: 0x0004527E
		' (set) Token: 0x06009139 RID: 37177 RVA: 0x00047088 File Offset: 0x00045288
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170035C6 RID: 13766
		' (get) Token: 0x0600913A RID: 37178 RVA: 0x00047091 File Offset: 0x00045291
		' (set) Token: 0x0600913B RID: 37179 RVA: 0x0004709B File Offset: 0x0004529B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170035C7 RID: 13767
		' (get) Token: 0x0600913C RID: 37180 RVA: 0x000470A4 File Offset: 0x000452A4
		' (set) Token: 0x0600913D RID: 37181 RVA: 0x000470AE File Offset: 0x000452AE
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170035C8 RID: 13768
		' (get) Token: 0x0600913E RID: 37182 RVA: 0x000470B7 File Offset: 0x000452B7
		' (set) Token: 0x0600913F RID: 37183 RVA: 0x000470C1 File Offset: 0x000452C1
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170035C9 RID: 13769
		' (get) Token: 0x06009140 RID: 37184 RVA: 0x000470CA File Offset: 0x000452CA
		' (set) Token: 0x06009141 RID: 37185 RVA: 0x000470D4 File Offset: 0x000452D4
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170035CA RID: 13770
		' (get) Token: 0x06009142 RID: 37186 RVA: 0x000470DD File Offset: 0x000452DD
		' (set) Token: 0x06009143 RID: 37187 RVA: 0x000470E7 File Offset: 0x000452E7
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170035CB RID: 13771
		' (get) Token: 0x06009144 RID: 37188 RVA: 0x000470F0 File Offset: 0x000452F0
		' (set) Token: 0x06009145 RID: 37189 RVA: 0x000470FA File Offset: 0x000452FA
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170035CC RID: 13772
		' (get) Token: 0x06009146 RID: 37190 RVA: 0x00047103 File Offset: 0x00045303
		' (set) Token: 0x06009147 RID: 37191 RVA: 0x0004710D File Offset: 0x0004530D
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170035CD RID: 13773
		' (get) Token: 0x06009148 RID: 37192 RVA: 0x00047116 File Offset: 0x00045316
		' (set) Token: 0x06009149 RID: 37193 RVA: 0x00047120 File Offset: 0x00045320
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170035CE RID: 13774
		' (get) Token: 0x0600914A RID: 37194 RVA: 0x00047129 File Offset: 0x00045329
		' (set) Token: 0x0600914B RID: 37195 RVA: 0x00047133 File Offset: 0x00045333
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170035CF RID: 13775
		' (get) Token: 0x0600914C RID: 37196 RVA: 0x0004713C File Offset: 0x0004533C
		' (set) Token: 0x0600914D RID: 37197 RVA: 0x00047146 File Offset: 0x00045346
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170035D0 RID: 13776
		' (get) Token: 0x0600914E RID: 37198 RVA: 0x0004714F File Offset: 0x0004534F
		' (set) Token: 0x0600914F RID: 37199 RVA: 0x00047159 File Offset: 0x00045359
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170035D1 RID: 13777
		' (get) Token: 0x06009150 RID: 37200 RVA: 0x00047162 File Offset: 0x00045362
		' (set) Token: 0x06009151 RID: 37201 RVA: 0x0004716C File Offset: 0x0004536C
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170035D2 RID: 13778
		' (get) Token: 0x06009152 RID: 37202 RVA: 0x00047175 File Offset: 0x00045375
		' (set) Token: 0x06009153 RID: 37203 RVA: 0x0004717F File Offset: 0x0004537F
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170035D3 RID: 13779
		' (get) Token: 0x06009154 RID: 37204 RVA: 0x00047188 File Offset: 0x00045388
		' (set) Token: 0x06009155 RID: 37205 RVA: 0x00047192 File Offset: 0x00045392
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170035D4 RID: 13780
		' (get) Token: 0x06009156 RID: 37206 RVA: 0x0004719B File Offset: 0x0004539B
		' (set) Token: 0x06009157 RID: 37207 RVA: 0x000471A5 File Offset: 0x000453A5
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170035D5 RID: 13781
		' (get) Token: 0x06009158 RID: 37208 RVA: 0x000471AE File Offset: 0x000453AE
		' (set) Token: 0x06009159 RID: 37209 RVA: 0x000471B8 File Offset: 0x000453B8
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170035D6 RID: 13782
		' (get) Token: 0x0600915A RID: 37210 RVA: 0x000471C1 File Offset: 0x000453C1
		' (set) Token: 0x0600915B RID: 37211 RVA: 0x000471CB File Offset: 0x000453CB
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170035D7 RID: 13783
		' (get) Token: 0x0600915C RID: 37212 RVA: 0x000471D4 File Offset: 0x000453D4
		' (set) Token: 0x0600915D RID: 37213 RVA: 0x000471DE File Offset: 0x000453DE
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170035D8 RID: 13784
		' (get) Token: 0x0600915E RID: 37214 RVA: 0x000471E7 File Offset: 0x000453E7
		' (set) Token: 0x0600915F RID: 37215 RVA: 0x000471F1 File Offset: 0x000453F1
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170035D9 RID: 13785
		' (get) Token: 0x06009160 RID: 37216 RVA: 0x000471FA File Offset: 0x000453FA
		' (set) Token: 0x06009161 RID: 37217 RVA: 0x00047204 File Offset: 0x00045404
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170035DA RID: 13786
		' (get) Token: 0x06009162 RID: 37218 RVA: 0x0004720D File Offset: 0x0004540D
		' (set) Token: 0x06009163 RID: 37219 RVA: 0x00047217 File Offset: 0x00045417
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170035DB RID: 13787
		' (get) Token: 0x06009164 RID: 37220 RVA: 0x00047220 File Offset: 0x00045420
		' (set) Token: 0x06009165 RID: 37221 RVA: 0x0004722A File Offset: 0x0004542A
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170035DC RID: 13788
		' (get) Token: 0x06009166 RID: 37222 RVA: 0x00047233 File Offset: 0x00045433
		' (set) Token: 0x06009167 RID: 37223 RVA: 0x0004723D File Offset: 0x0004543D
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170035DD RID: 13789
		' (get) Token: 0x06009168 RID: 37224 RVA: 0x00047246 File Offset: 0x00045446
		' (set) Token: 0x06009169 RID: 37225 RVA: 0x00047250 File Offset: 0x00045450
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170035DE RID: 13790
		' (get) Token: 0x0600916A RID: 37226 RVA: 0x00047259 File Offset: 0x00045459
		' (set) Token: 0x0600916B RID: 37227 RVA: 0x00047263 File Offset: 0x00045463
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170035DF RID: 13791
		' (get) Token: 0x0600916C RID: 37228 RVA: 0x0004726C File Offset: 0x0004546C
		' (set) Token: 0x0600916D RID: 37229 RVA: 0x00047276 File Offset: 0x00045476
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170035E0 RID: 13792
		' (get) Token: 0x0600916E RID: 37230 RVA: 0x0004727F File Offset: 0x0004547F
		' (set) Token: 0x0600916F RID: 37231 RVA: 0x00047289 File Offset: 0x00045489
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170035E1 RID: 13793
		' (get) Token: 0x06009170 RID: 37232 RVA: 0x00047292 File Offset: 0x00045492
		' (set) Token: 0x06009171 RID: 37233 RVA: 0x0004729C File Offset: 0x0004549C
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170035E2 RID: 13794
		' (get) Token: 0x06009172 RID: 37234 RVA: 0x000472A5 File Offset: 0x000454A5
		' (set) Token: 0x06009173 RID: 37235 RVA: 0x000472AF File Offset: 0x000454AF
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170035E3 RID: 13795
		' (get) Token: 0x06009174 RID: 37236 RVA: 0x000472B8 File Offset: 0x000454B8
		' (set) Token: 0x06009175 RID: 37237 RVA: 0x000472C2 File Offset: 0x000454C2
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x170035E4 RID: 13796
		' (get) Token: 0x06009176 RID: 37238 RVA: 0x000472CB File Offset: 0x000454CB
		' (set) Token: 0x06009177 RID: 37239 RVA: 0x000472D5 File Offset: 0x000454D5
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x170035E5 RID: 13797
		' (get) Token: 0x06009178 RID: 37240 RVA: 0x000472DE File Offset: 0x000454DE
		' (set) Token: 0x06009179 RID: 37241 RVA: 0x000472E8 File Offset: 0x000454E8
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x170035E6 RID: 13798
		' (get) Token: 0x0600917A RID: 37242 RVA: 0x000472F1 File Offset: 0x000454F1
		' (set) Token: 0x0600917B RID: 37243 RVA: 0x000472FB File Offset: 0x000454FB
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x170035E7 RID: 13799
		' (get) Token: 0x0600917C RID: 37244 RVA: 0x00047304 File Offset: 0x00045504
		' (set) Token: 0x0600917D RID: 37245 RVA: 0x0004730E File Offset: 0x0004550E
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x170035E8 RID: 13800
		' (get) Token: 0x0600917E RID: 37246 RVA: 0x00047317 File Offset: 0x00045517
		' (set) Token: 0x0600917F RID: 37247 RVA: 0x00047321 File Offset: 0x00045521
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x170035E9 RID: 13801
		' (get) Token: 0x06009180 RID: 37248 RVA: 0x0004732A File Offset: 0x0004552A
		' (set) Token: 0x06009181 RID: 37249 RVA: 0x00047334 File Offset: 0x00045534
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x170035EA RID: 13802
		' (get) Token: 0x06009182 RID: 37250 RVA: 0x0004733D File Offset: 0x0004553D
		' (set) Token: 0x06009183 RID: 37251 RVA: 0x00047347 File Offset: 0x00045547
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x170035EB RID: 13803
		' (get) Token: 0x06009184 RID: 37252 RVA: 0x00047350 File Offset: 0x00045550
		' (set) Token: 0x06009185 RID: 37253 RVA: 0x0004735A File Offset: 0x0004555A
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x170035EC RID: 13804
		' (get) Token: 0x06009186 RID: 37254 RVA: 0x00047363 File Offset: 0x00045563
		' (set) Token: 0x06009187 RID: 37255 RVA: 0x0004736D File Offset: 0x0004556D
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x170035ED RID: 13805
		' (get) Token: 0x06009188 RID: 37256 RVA: 0x00047376 File Offset: 0x00045576
		' (set) Token: 0x06009189 RID: 37257 RVA: 0x00047380 File Offset: 0x00045580
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x170035EE RID: 13806
		' (get) Token: 0x0600918A RID: 37258 RVA: 0x00047389 File Offset: 0x00045589
		' (set) Token: 0x0600918B RID: 37259 RVA: 0x00047393 File Offset: 0x00045593
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x170035EF RID: 13807
		' (get) Token: 0x0600918C RID: 37260 RVA: 0x0004739C File Offset: 0x0004559C
		' (set) Token: 0x0600918D RID: 37261 RVA: 0x000473A6 File Offset: 0x000455A6
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x170035F0 RID: 13808
		' (get) Token: 0x0600918E RID: 37262 RVA: 0x000473AF File Offset: 0x000455AF
		' (set) Token: 0x0600918F RID: 37263 RVA: 0x000473B9 File Offset: 0x000455B9
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x170035F1 RID: 13809
		' (get) Token: 0x06009190 RID: 37264 RVA: 0x000473C2 File Offset: 0x000455C2
		' (set) Token: 0x06009191 RID: 37265 RVA: 0x000473CC File Offset: 0x000455CC
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170035F2 RID: 13810
		' (get) Token: 0x06009192 RID: 37266 RVA: 0x000473D5 File Offset: 0x000455D5
		' (set) Token: 0x06009193 RID: 37267 RVA: 0x000473DF File Offset: 0x000455DF
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170035F3 RID: 13811
		' (get) Token: 0x06009194 RID: 37268 RVA: 0x000473E8 File Offset: 0x000455E8
		' (set) Token: 0x06009195 RID: 37269 RVA: 0x000473F2 File Offset: 0x000455F2
		Friend Overridable Property btnInward As DataGridViewButtonColumn

		' Token: 0x06009196 RID: 37270 RVA: 0x0069AB04 File Offset: 0x00698D04
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
					Me.dtpDateTo.Value = DateAndTime.Today
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

		' Token: 0x06009197 RID: 37271 RVA: 0x0069ABE8 File Offset: 0x00698DE8
		Public Sub Getdata(from_companyid As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT " & vbCrLf & "    Inv_ID," & vbCrLf & "    RTRIM(InvoiceNo) AS InvoiceNo," & vbCrLf & "    InvoiceDate," & vbCrLf & "    RTRIM(TaxType) AS TaxType," & vbCrLf & vbCrLf & "    '' AS ID," & vbCrLf & "    '' AS CustomerID," & vbCrLf & "    '' AS CustomerName," & vbCrLf & "    '' AS ContactNo," & vbCrLf & "    '' AS State," & vbCrLf & "    '' AS GSTIN," & vbCrLf & vbCrLf & "    '' as SM_ID," & vbCrLf & "    InvoiceInfo_StockTransfer.SalesmanID," & vbCrLf & "    '' AS SalesmanName," & vbCrLf & vbCrLf & "    SubTotal," & vbCrLf & "    InvoiceInfo_StockTransfer.CGST," & vbCrLf & "    InvoiceInfo_StockTransfer.SGST," & vbCrLf & "    InvoiceInfo_StockTransfer.IGST," & vbCrLf & "    InvoiceInfo_StockTransfer.CESS," & vbCrLf & "    FreightCharges," & vbCrLf & "    OtherCharges," & vbCrLf & "    Total," & vbCrLf & "    RoundOff," & vbCrLf & "    GrandTotal," & vbCrLf & "    TotalPaid," & vbCrLf & "    Balance," & vbCrLf & "    RTRIM(InvoiceInfo_StockTransfer.Remarks) AS Remarks," & vbCrLf & "    RTRIM(Narration) AS Narration," & vbCrLf & "    RTRIM(Eway) AS Eway," & vbCrLf & "    RTRIM(TillID) AS TillID," & vbCrLf & "    RTRIM(Operator) AS Operator," & vbCrLf & "    RTRIM(BillSundry) AS BillSundry," & vbCrLf & "    RTRIM(OfferAmt) AS OfferAmt," & vbCrLf & "    RTRIM(LoyaAmt) AS LoyaAmt," & vbCrLf & "    RTRIM(BillDiscount) AS BillDiscount," & vbCrLf & "    '' AS City," & vbCrLf & vbCrLf & "    Tender," & vbCrLf & "    Refund," & vbCrLf & "    BillCash," & vbCrLf & "    CouponAmt," & vbCrLf & "    GiftAmt," & vbCrLf & "    '' AS Address," & vbCrLf & vbCrLf & "    SRNumber," & vbCrLf & "    ByReturn," & vbCrLf & "    TotalLoyalityPoints," & vbCrLf & "    LoyalityReedemPoints," & vbCrLf & "    LoyalityReedemAmt," & vbCrLf & vbCrLf & "    '' AS Barcode," & vbCrLf & "    '' AS ProductName," & vbCrLf & "    0 AS Qty," & vbCrLf & vbCrLf & "    InvoiceInfo_StockTransfer.from_company_id," & vbCrLf & "    InvoiceInfo_StockTransfer.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS to_companyName,RTRIM(z.CompanyName) AS from_companyName," & vbCrLf & vbCrLf & "    CASE " & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 0 THEN 'Pending'" & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 1 THEN 'Inward'" & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 2 THEN 'Stock Inward Done'" & vbCrLf & "        ELSE 'Unknown'" & vbCrLf & "    END AS StatusText" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockTransfer" & vbCrLf & "LEFT JOIN Branch_Relation y ON InvoiceInfo_StockTransfer.to_company_id = y.to_company_id and y.from_company_id=@d0" & vbCrLf & "LEFT JOIN RaintechMaster z on InvoiceInfo_StockTransfer.from_company_id = z.company_id and z.is_active=1" & vbCrLf & "where InvoiceInfo_StockTransfer.to_company_id=@d0 and InvoiceInfo_StockTransfer.status in(0,1)"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = from_companyid
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text2 As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("to_CompanyName").ToString() + " (" + ModCommonClasses.rdr("to_company_id").ToString() + ")"
					Dim text4 As String = ModCommonClasses.rdr("from_CompanyName").ToString() + " (" + ModCommonClasses.rdr("from_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text2, num, text4, ModCommonClasses.rdr("from_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x06009198 RID: 37272 RVA: 0x0069B220 File Offset: 0x00699420
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your internet connection!")
			Else
				Me.Getdata(Me.lblFrom_Company_id.Text)
				Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
				Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Me.Convert_Language()
			End If
		End Sub

		' Token: 0x06009199 RID: 37273 RVA: 0x0069B2D8 File Offset: 0x006994D8
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

		' Token: 0x0600919A RID: 37274 RVA: 0x0069B450 File Offset: 0x00699650
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

		' Token: 0x0600919B RID: 37275 RVA: 0x0069B51C File Offset: 0x0069971C
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

		' Token: 0x0600919C RID: 37276 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600919D RID: 37277 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600919E RID: 37278 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600919F RID: 37279 RVA: 0x0069B5E8 File Offset: 0x006997E8
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060091A0 RID: 37280 RVA: 0x0069B610 File Offset: 0x00699810
		Public Sub RetrieveData1()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmStock_Settlement.Show()
				MyBase.Hide()
				MyProject.Forms.frmStock_Settlement.txtCompany_id_from.Text = Me.lblFrom_Company_id.Text
				MyProject.Forms.frmStock_Settlement.txtCompany_to.Text = dataGridViewRow.Cells(48).Value.ToString()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin,InvoiceInfo_Product_StockInward.Descr,InvoiceInfo_Product_StockInward.Qty,RTRIM(InvoiceInfo_Product_StockInward.IM1),RTRIM(InvoiceInfo_Product_StockInward.IM2),(InvoiceInfo_Product_StockInward.MRP),(InvoiceInfo_Product_StockInward.TaxableAmt),(InvoiceInfo_Product_StockInward.AltQty),(InvoiceInfo_Product_StockInward.AltUnit),(InvoiceInfo_Product_StockInward.STaxType),(InvoiceInfo_Product_StockInward.TotalMRP),(InvoiceInfo_Product_StockInward.PromoQty),RTRIM(InvoiceInfo_Product_StockInward.MainUnit),RTRIM(InvoiceInfo_Product_StockInward.Batch),RTRIM(InvoiceInfo_Product_StockInward.Mfg),RTRIM(InvoiceInfo_Product_StockInward.Exp),RTRIM(InvoiceInfo_Product_StockInward.Size),RTRIM(InvoiceInfo_Product_StockInward.Colour),InvoiceInfo_Product_StockInward.SalesManID,InvoiceInfo_Product_StockInward.SalesMan,InvoiceInfo_Product_StockInward.SalesManPur,InvoiceInfo_Product_StockInward.SalesManComm ,InvoiceInfo_Product_StockInward.StockID, InvoiceInfo_Product_StockInward.LoyalityPoints from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmStock_Settlement.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmStock_Settlement.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
				End While
				MyProject.Forms.frmStock_Settlement.DataGridView1.ClearSelection()
				ModCommonClasses.con.Close()
			End If
		End Sub

		' Token: 0x060091A1 RID: 37281 RVA: 0x0069BA34 File Offset: 0x00699C34
		Public Sub RetrieveData()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPOSNewTuch_StockInward.Show()
				MyBase.Hide()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
				Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Text.Trim(), "Cash", False) = 0
				If flag2 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_StockInward.txtCompanyState.Text
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.CAddress = dataGridViewRow.Cells(40).Value.ToString()
				Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
				If flag3 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.cb1.Checked = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.cb1.Checked = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCompany_id_from.Text = Me.lblFrom_Company_id.Text
				MyProject.Forms.frmPOSNewTuch_StockInward.txtCompany_to.Text = dataGridViewRow.Cells(48).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockInward.btnSave.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnPrint.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Button5.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Button6.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.txtOffer.Text = "0.00"
				Dim flag4 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
				If flag4 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_StockInward.btnDelete.Enabled = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.btnUpdate.Enabled = False
					MyProject.Forms.frmPOSNewTuch_StockInward.btnDelete.Enabled = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.lblSet.Text = "Not Allowed"
				MyProject.Forms.frmPOSNewTuch_StockInward.btnAdd.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.txtContactNo.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerState.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnCustomerSelection.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.TextBox15.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockInward.Label82.Enabled = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin,InvoiceInfo_Product_StockInward.Descr,InvoiceInfo_Product_StockInward.Qty,RTRIM(InvoiceInfo_Product_StockInward.IM1),RTRIM(InvoiceInfo_Product_StockInward.IM2),(InvoiceInfo_Product_StockInward.MRP),(InvoiceInfo_Product_StockInward.TaxableAmt),(InvoiceInfo_Product_StockInward.AltQty),(InvoiceInfo_Product_StockInward.AltUnit),(InvoiceInfo_Product_StockInward.STaxType),(InvoiceInfo_Product_StockInward.TotalMRP),(InvoiceInfo_Product_StockInward.PromoQty),RTRIM(InvoiceInfo_Product_StockInward.MainUnit),RTRIM(InvoiceInfo_Product_StockInward.Batch),RTRIM(InvoiceInfo_Product_StockInward.Mfg),RTRIM(InvoiceInfo_Product_StockInward.Exp),RTRIM(InvoiceInfo_Product_StockInward.Size),RTRIM(InvoiceInfo_Product_StockInward.Colour),InvoiceInfo_Product_StockInward.SalesManID,InvoiceInfo_Product_StockInward.SalesMan,InvoiceInfo_Product_StockInward.SalesManPur,InvoiceInfo_Product_StockInward.SalesManComm ,InvoiceInfo_Product_StockInward.StockID, InvoiceInfo_Product_StockInward.LoyalityPoints from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
				End While
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView1.ClearSelection()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "SELECT ProductID,RTRIM(Product.HSNCode),RTRIM(Product.ProductName), RTRIM(InvoiceInfo_Product_StockInward.Barcode),InvoiceInfo_Product_StockInward.Qty, InvoiceInfo_Product_StockInward.SalesRate,InvoiceInfo_Product_StockInward.DiscountPer, InvoiceInfo_Product_StockInward.Discount, InvoiceInfo_Product_StockInward.CGSTPer, InvoiceInfo_Product_StockInward.CGSTAmt, InvoiceInfo_Product_StockInward.SGSTPer, InvoiceInfo_Product_StockInward.SGSTAmt, InvoiceInfo_Product_StockInward.IGSTPer,InvoiceInfo_Product_StockInward. IGSTAmt, InvoiceInfo_Product_StockInward.CESSPer,InvoiceInfo_Product_StockInward. CESSAmt,InvoiceInfo_Product_StockInward. TotalAmount,InvoiceInfo_Product_StockInward. PurchaseRate,InvoiceInfo_Product_StockInward. Margin from InvoiceInfo_StockInward,InvoiceInfo_Product_StockInward,Product where InvoiceInfo_StockInward.Inv_ID=InvoiceInfo_Product_StockInward.InvoiceID and Product.PID=InvoiceInfo_Product_StockInward.ProductID and InvoiceInfo_StockInward.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text4 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
				ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Visible = True
					MyProject.Forms.frmPOSNewTuch_StockInward.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				MyProject.Forms.frmPOSNewTuch_StockInward.CustomerBalance_Loyality()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calc()
				MyProject.Forms.frmPOSNewTuch_StockInward.Compute()
				MyProject.Forms.frmPOSNewTuch_StockInward.alldiscountcalc()
				MyProject.Forms.frmPOSNewTuch_StockInward.Bankcondn()
				MyProject.Forms.frmPOSNewTuch_StockInward.totitemnqty()
				MyProject.Forms.frmPOSNewTuch_StockInward.btnSelectSalesman.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockInward.btnListReset1.PerformClick()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calculate12345()
				MyProject.Forms.frmPOSNewTuch_StockInward.Calculate143()
				Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockInward.cmbBSundry.Text, "TCS", False) = 0
				If flag5 Then
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.[ReadOnly] = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_StockInward.txtTCSdbl.Text = "0"
				End If
				MyProject.Forms.frmPOSNewTuch_StockInward.CTypeStatus()
				MyProject.Forms.frmPOSNewTuch_StockInward.BrokerRetrive()
				MyProject.Forms.frmPOSNewTuch_StockInward.CheckBox11.Checked = False
				MyProject.Forms.frmPOSNewTuch_StockInward.txtInvoiceNo.[ReadOnly] = True
			End If
		End Sub

		' Token: 0x060091A2 RID: 37282 RVA: 0x0069CE40 File Offset: 0x0069B040
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

		' Token: 0x060091A3 RID: 37283 RVA: 0x0069CF28 File Offset: 0x0069B128
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your internet connection!")
			Else
				Me.Getdata(Me.lblFrom_Company_id.Text)
			End If
		End Sub

		' Token: 0x060091A4 RID: 37284 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060091A5 RID: 37285 RVA: 0x0069CF8C File Offset: 0x0069B18C
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))
						End If

				Next
				Me.Label14.Text = Conversions.ToString(num4)
				Dim num5 As Integer = Me.dgw.Rows.Count - 1
				Dim num6 As Double
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))
						End If

				Next
				Me.Label15.Text = Conversions.ToString(num6)
				Dim num7 As Integer = Me.dgw.Rows.Count - 1
				Dim num8 As Double
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))
						End If

				Next
				Me.Label16.Text = Conversions.ToString(num8)
				Dim num9 As Integer = Me.dgw.Rows.Count - 1
				Dim num10 As Double
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))
						End If

				Next
				Me.Label18.Text = Conversions.ToString(num10)
				Dim num11 As Integer = Me.dgw.Rows.Count - 1
				Dim num12 As Double
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))
						End If

				Next
				Me.Label20.Text = Conversions.ToString(num12)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
			Me.Label14.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label14.Text), 2), "0.00")
			Me.Label15.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Me.Label16.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label16.Text), 2), "0.00")
			Me.Label18.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label18.Text), 2), "0.00")
			Me.Label20.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label20.Text), 2), "0.00")
		End Sub

		' Token: 0x060091A6 RID: 37286 RVA: 0x000473FB File Offset: 0x000455FB
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x060091A7 RID: 37287 RVA: 0x0069D4F0 File Offset: 0x0069B6F0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060091A8 RID: 37288 RVA: 0x0069D79C File Offset: 0x0069B99C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmStock_Inward_Record.lblSet.Text = "transfer"
			MyProject.Forms.frmStock_Inward_Record.lblUser.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Record.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Record.lblFrom_Company_id.Text = Me.lblFrom_Company_id.Text
			MyProject.Forms.frmStock_Inward_Record.ShowDialog()
		End Sub

		' Token: 0x060091A9 RID: 37289 RVA: 0x0069D83C File Offset: 0x0069BA3C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, InvoiceInfo_StockTransfer.CGST, InvoiceInfo_StockTransfer.SGST, InvoiceInfo_StockTransfer.IGST, InvoiceInfo_StockTransfer.CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo_StockTransfer.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt," & vbCrLf & "'' as Barcode," & vbCrLf & "    '' as ProductName," & vbCrLf & "    0 as Qty," & vbCrLf & "    InvoiceInfo_StockTransfer.from_company_id," & vbCrLf & "    InvoiceInfo_StockTransfer.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS CompanyName, CASE " & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 0 THEN 'Pending'" & vbCrLf & "        ELSE 'Transfer'" & vbCrLf & "    END AS StatusText" & vbCrLf & "from InvoiceInfo_StockTransfer " & vbCrLf & "LEFT Join Customer ON InvoiceInfo_StockTransfer.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON InvoiceInfo_StockTransfer.SalesmanID=Salesman.SM_ID " & vbCrLf & vbCrLf & "LEFT JOIN Branch_Relation y ON InvoiceInfo_StockTransfer.to_company_id = y.to_company_id " & vbCrLf & "where InvoiceInfo_StockTransfer.to_company_id=@d0 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text2 As String = ModCommonClasses.rdr("CompanyName").ToString() + " (" + ModCommonClasses.rdr("to_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text, num, text2, ModCommonClasses.rdr("to_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "INWARD", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnInward") = dataGridViewTextBoxCell
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060091AA RID: 37290 RVA: 0x0069DE20 File Offset: 0x0069C020
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.dgw.Columns(e.ColumnIndex).Name, "btnInward", False) = 0 AndAlso e.RowIndex >= 0
			If flag Then
				Try
					Dim value As Object = Me.dgw.Rows(e.RowIndex).Cells(0).Value
					Dim text As String = If((value IsNot Nothing), value.ToString().Trim(), Nothing)
					Dim value2 As Object = Me.dgw.Rows(e.RowIndex).Cells(48).Value
					Dim text2 As String = If((value2 IsNot Nothing), value2.ToString().Trim(), Nothing)
					Dim value3 As Object = Me.dgw.Rows(e.RowIndex).Cells(49).Value
					Dim text3 As String = If((value3 IsNot Nothing), value3.ToString().Trim(), Nothing)
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to Inward from '" + text2 + "'?", "To Branch", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag2 As Boolean = dialogResult = DialogResult.Yes
					If flag2 Then
						Dim flag3 As Boolean = Not ModFunc.CheckForInternetConnection()
						If flag3 Then
							MessageBox.Show("Please Check your internet connection!")
						Else
							Me.Inward_StockOnline(text, text3, Me.lblFrom_Company_id.Text)
							Me.Getdata(Me.lblFrom_Company_id.Text)
						End If
					End If
				Catch ex As Exception
					MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Me.RetrieveData2()
			End If
		End Sub

		' Token: 0x060091AB RID: 37291 RVA: 0x0069DFE0 File Offset: 0x0069C1E0
		Public Sub RetrieveData2()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmStock_Settlement.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmStock_Settlement.txtCompany_id_from.Text = Me.lblFrom_Company_id.Text
				MyProject.Forms.frmStock_Settlement.txtCompany_to.Text = dataGridViewRow.Cells(48).Value.ToString()
				MyProject.Forms.frmStock_Settlement.txtFrom_company_id.Text = dataGridViewRow.Cells(49).Value.ToString()
				Dim dataTable As DataTable = New DataTable()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                SELECT InvoiceInfo_Product_StockInward.InvoiceID, ProductID," & vbCrLf & "                       RTRIM(InvoiceInfo_Product_StockInward.Barcode) AS Barcode," & vbCrLf & "                       RTRIM(InvoiceInfo_Product_StockInward.ProductName) AS ProductName," & vbCrLf & "                       RTRIM(InvoiceInfo_Product_StockInward.HSNCode) AS HSNCode," & vbCrLf & "                       RTRIM(InvoiceInfo_Product_StockInward.PartNo) AS PartNo," & vbCrLf & "                       Descr, PurchaseRate, MRP, SPrice, WPrice, DiscountPer," & vbCrLf & "                       CGSTPer, SGSTPer, CESSPer," & vbCrLf & "                       PurchaseUnit, PurchaseUnit AS saleUnit, PurchaseUnit AS altUnit, Conv," & vbCrLf & "                       MinStock, GDown, Rack, DefQty, PurchaseRate, MRP, SPrice," & vbCrLf & "                       WPrice, Batch, Mfg, Exp, Colour, Size, IM1, IM2, Status," & vbCrLf & "                       '' AS Qr_code, Qty AS transfer_qty, TocknNo, Category, SubCategoryName              " & vbCrLf & "                FROM InvoiceInfo_Product_StockInward                             " & vbCrLf & "                WHERE InvoiceID = @d1"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							sqlDataAdapter.Fill(dataTable)
						End Using
					End Using
				End Using
				MyProject.Forms.frmStock_Settlement.SkipListViewReset = True
				MyProject.Forms.frmStock_Settlement.LoadTransferItems(dataTable)
				MyProject.Forms.frmStock_Settlement.ShowDialog()
			End If
		End Sub

		' Token: 0x060091AC RID: 37292 RVA: 0x0069E1B4 File Offset: 0x0069C3B4
		Public Sub Inward_StockOnline(selectedInv_Id As String, from_company As String, to_company As String)
			Dim cs As String = ModCS.cs
			Dim text As String = ModCS.RaintechMaster_Online_connection()
			Try
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = New DataTable()
				Using sqlConnection As SqlConnection = New SqlConnection(text)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM InvoiceInfo_StockTransfer WHERE Inv_ID = @InvID and from_company_id=@from_c and to_company_id=@to_c and Status=0", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@InvID", selectedInv_Id)
					sqlCommand.Parameters.AddWithValue("@from_c", from_company)
					sqlCommand.Parameters.AddWithValue("@to_c", to_company)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
						sqlDataAdapter.Fill(dataTable)
					End Using
					Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT * FROM InvoiceInfo_Product_StockTransfer WHERE InvoiceID = @InvID and PBranchFrom=@from_c and PBranchTo=@to_c", sqlConnection)
					sqlCommand2.Parameters.AddWithValue("@InvID", selectedInv_Id)
					sqlCommand2.Parameters.AddWithValue("@from_c", from_company)
					sqlCommand2.Parameters.AddWithValue("@to_c", to_company)
					Using sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
						sqlDataAdapter2.Fill(dataTable2)
					End Using
				End Using
				Using sqlConnection2 As SqlConnection = New SqlConnection(cs)
					sqlConnection2.Open()
					Try
						For Each obj As Object In dataTable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim cols As New List(Of String)()
							Dim vals As New List(Of String)()
							For Each col As DataColumn In dataRow.Table.Columns
								If Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(col.ColumnName) Then
									cols.Add(col.ColumnName)
									vals.Add("@" & col.ColumnName)
								End If
							Next
							Dim text3 As String = String.Join(",", cols)
							Dim text5 As String = String.Join(",", vals)
							Dim text6 As String = String.Format("INSERT INTO InvoiceInfo_StockInward ({0}) VALUES ({1})", text3, text5)
							Dim sqlCommand3 As SqlCommand = New SqlCommand(text6, sqlConnection2)
							Try
								For Each obj2 As Object In dataRow.Table.Columns
									Dim dataColumn As DataColumn = CType(obj2, DataColumn)
									Dim flag As Boolean = Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(dataColumn.ColumnName)
									If flag Then
										sqlCommand3.Parameters.AddWithValue("@" + dataColumn.ColumnName, RuntimeHelpers.GetObjectValue(dataRow(dataColumn.ColumnName)))
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
							sqlCommand3.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim sqlCommand4 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT InvoiceInfo_Product_StockInward ON", sqlConnection2)
					sqlCommand4.ExecuteNonQuery()
					Try
						For Each obj3 As Object In dataTable2.Rows
							Dim dataRow2 As DataRow = CType(obj3, DataRow)
							Dim cols2 As New List(Of String)()
							Dim vals2 As New List(Of String)()
							For Each col As DataColumn In dataRow2.Table.Columns
								If Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(col.ColumnName) Then
									cols2.Add(col.ColumnName)
									vals2.Add("@" & col.ColumnName)
								End If
							Next
							Dim text8 As String = String.Join(",", cols2)
							Dim text10 As String = String.Join(",", vals2)
							Dim text11 As String = String.Format("INSERT INTO InvoiceInfo_Product_StockInward ({0}) VALUES ({1})", text8, text10)
							Dim sqlCommand5 As SqlCommand = New SqlCommand(text11, sqlConnection2)
							Try
								For Each obj4 As Object In dataRow2.Table.Columns
									Dim dataColumn2 As DataColumn = CType(obj4, DataColumn)
									Dim flag2 As Boolean = Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(dataColumn2.ColumnName)
									If flag2 Then
										sqlCommand5.Parameters.AddWithValue("@" + dataColumn2.ColumnName, RuntimeHelpers.GetObjectValue(dataRow2(dataColumn2.ColumnName)))
									End If
								Next
							Finally
								Dim enumerator4 As IEnumerator
								If TypeOf enumerator4 Is IDisposable Then
									TryCast(enumerator4, IDisposable).Dispose()
								End If
							End Try
							sqlCommand5.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator3 As IEnumerator
						If TypeOf enumerator3 Is IDisposable Then
							TryCast(enumerator3, IDisposable).Dispose()
						End If
					End Try
					Dim sqlCommand6 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT InvoiceInfo_Product_StockInward OFF", sqlConnection2)
					sqlCommand6.ExecuteNonQuery()
				End Using
				Using sqlConnection3 As SqlConnection = New SqlConnection(text)
					sqlConnection3.Open()
					Dim sqlCommand7 As SqlCommand = New SqlCommand("UPDATE InvoiceInfo_StockTransfer SET status = 1 WHERE Inv_ID = @InvID and from_company_id=@from_c and to_company_id=@to_c", sqlConnection3)
					sqlCommand7.Parameters.AddWithValue("@InvID", selectedInv_Id)
					sqlCommand7.Parameters.AddWithValue("@from_c", from_company)
					sqlCommand7.Parameters.AddWithValue("@to_c", to_company)
					sqlCommand7.ExecuteNonQuery()
				End Using
				MessageBox.Show("✅ Stock inward completed and marked as inward.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show("❌ Transfer failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
