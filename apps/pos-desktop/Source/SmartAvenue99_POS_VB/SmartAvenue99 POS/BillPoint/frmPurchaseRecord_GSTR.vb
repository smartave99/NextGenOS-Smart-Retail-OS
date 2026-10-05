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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200056D RID: 1389
	<DesignerGenerated()>
	Public Partial Class frmPurchaseRecord_GSTR
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010E4A RID: 69194 RVA: 0x000744F5 File Offset: 0x000726F5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170068BD RID: 26813
		' (get) Token: 0x06010E4D RID: 69197 RVA: 0x00074527 File Offset: 0x00072727
		' (set) Token: 0x06010E4E RID: 69198 RVA: 0x00074531 File Offset: 0x00072731
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170068BE RID: 26814
		' (get) Token: 0x06010E4F RID: 69199 RVA: 0x0007453A File Offset: 0x0007273A
		' (set) Token: 0x06010E50 RID: 69200 RVA: 0x009D563C File Offset: 0x009D383C
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170068BF RID: 26815
		' (get) Token: 0x06010E51 RID: 69201 RVA: 0x00074544 File Offset: 0x00072744
		' (set) Token: 0x06010E52 RID: 69202 RVA: 0x0007454E File Offset: 0x0007274E
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170068C0 RID: 26816
		' (get) Token: 0x06010E53 RID: 69203 RVA: 0x00074557 File Offset: 0x00072757
		' (set) Token: 0x06010E54 RID: 69204 RVA: 0x00074561 File Offset: 0x00072761
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170068C1 RID: 26817
		' (get) Token: 0x06010E55 RID: 69205 RVA: 0x0007456A File Offset: 0x0007276A
		' (set) Token: 0x06010E56 RID: 69206 RVA: 0x00074574 File Offset: 0x00072774
		Friend Overridable Property Label2 As Label

		' Token: 0x170068C2 RID: 26818
		' (get) Token: 0x06010E57 RID: 69207 RVA: 0x0007457D File Offset: 0x0007277D
		' (set) Token: 0x06010E58 RID: 69208 RVA: 0x00074587 File Offset: 0x00072787
		Friend Overridable Property Label4 As Label

		' Token: 0x170068C3 RID: 26819
		' (get) Token: 0x06010E59 RID: 69209 RVA: 0x00074590 File Offset: 0x00072790
		' (set) Token: 0x06010E5A RID: 69210 RVA: 0x0007459A File Offset: 0x0007279A
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170068C4 RID: 26820
		' (get) Token: 0x06010E5B RID: 69211 RVA: 0x000745A3 File Offset: 0x000727A3
		' (set) Token: 0x06010E5C RID: 69212 RVA: 0x000745AD File Offset: 0x000727AD
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170068C5 RID: 26821
		' (get) Token: 0x06010E5D RID: 69213 RVA: 0x000745B6 File Offset: 0x000727B6
		' (set) Token: 0x06010E5E RID: 69214 RVA: 0x000745C0 File Offset: 0x000727C0
		Friend Overridable Property Label1 As Label

		' Token: 0x170068C6 RID: 26822
		' (get) Token: 0x06010E5F RID: 69215 RVA: 0x000745C9 File Offset: 0x000727C9
		' (set) Token: 0x06010E60 RID: 69216 RVA: 0x000745D3 File Offset: 0x000727D3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170068C7 RID: 26823
		' (get) Token: 0x06010E61 RID: 69217 RVA: 0x000745DC File Offset: 0x000727DC
		' (set) Token: 0x06010E62 RID: 69218 RVA: 0x000745E6 File Offset: 0x000727E6
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170068C8 RID: 26824
		' (get) Token: 0x06010E63 RID: 69219 RVA: 0x000745EF File Offset: 0x000727EF
		' (set) Token: 0x06010E64 RID: 69220 RVA: 0x009D569C File Offset: 0x009D389C
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170068C9 RID: 26825
		' (get) Token: 0x06010E65 RID: 69221 RVA: 0x000745F9 File Offset: 0x000727F9
		' (set) Token: 0x06010E66 RID: 69222 RVA: 0x009D56E0 File Offset: 0x009D38E0
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170068CA RID: 26826
		' (get) Token: 0x06010E67 RID: 69223 RVA: 0x00074603 File Offset: 0x00072803
		' (set) Token: 0x06010E68 RID: 69224 RVA: 0x009D5724 File Offset: 0x009D3924
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

		' Token: 0x170068CB RID: 26827
		' (get) Token: 0x06010E69 RID: 69225 RVA: 0x0007460D File Offset: 0x0007280D
		' (set) Token: 0x06010E6A RID: 69226 RVA: 0x00074617 File Offset: 0x00072817
		Friend Overridable Property Label3 As Label

		' Token: 0x170068CC RID: 26828
		' (get) Token: 0x06010E6B RID: 69227 RVA: 0x00074620 File Offset: 0x00072820
		' (set) Token: 0x06010E6C RID: 69228 RVA: 0x0007462A File Offset: 0x0007282A
		Friend Overridable Property Label6 As Label

		' Token: 0x170068CD RID: 26829
		' (get) Token: 0x06010E6D RID: 69229 RVA: 0x00074633 File Offset: 0x00072833
		' (set) Token: 0x06010E6E RID: 69230 RVA: 0x0007463D File Offset: 0x0007283D
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170068CE RID: 26830
		' (get) Token: 0x06010E6F RID: 69231 RVA: 0x00074646 File Offset: 0x00072846
		' (set) Token: 0x06010E70 RID: 69232 RVA: 0x00074650 File Offset: 0x00072850
		Friend Overridable Property Label8 As Label

		' Token: 0x170068CF RID: 26831
		' (get) Token: 0x06010E71 RID: 69233 RVA: 0x00074659 File Offset: 0x00072859
		' (set) Token: 0x06010E72 RID: 69234 RVA: 0x009D5768 File Offset: 0x009D3968
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170068D0 RID: 26832
		' (get) Token: 0x06010E73 RID: 69235 RVA: 0x00074663 File Offset: 0x00072863
		' (set) Token: 0x06010E74 RID: 69236 RVA: 0x0007466D File Offset: 0x0007286D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170068D1 RID: 26833
		' (get) Token: 0x06010E75 RID: 69237 RVA: 0x00074676 File Offset: 0x00072876
		' (set) Token: 0x06010E76 RID: 69238 RVA: 0x00074680 File Offset: 0x00072880
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170068D2 RID: 26834
		' (get) Token: 0x06010E77 RID: 69239 RVA: 0x00074689 File Offset: 0x00072889
		' (set) Token: 0x06010E78 RID: 69240 RVA: 0x00074693 File Offset: 0x00072893
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170068D3 RID: 26835
		' (get) Token: 0x06010E79 RID: 69241 RVA: 0x0007469C File Offset: 0x0007289C
		' (set) Token: 0x06010E7A RID: 69242 RVA: 0x000746A6 File Offset: 0x000728A6
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170068D4 RID: 26836
		' (get) Token: 0x06010E7B RID: 69243 RVA: 0x000746AF File Offset: 0x000728AF
		' (set) Token: 0x06010E7C RID: 69244 RVA: 0x000746B9 File Offset: 0x000728B9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170068D5 RID: 26837
		' (get) Token: 0x06010E7D RID: 69245 RVA: 0x000746C2 File Offset: 0x000728C2
		' (set) Token: 0x06010E7E RID: 69246 RVA: 0x000746CC File Offset: 0x000728CC
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170068D6 RID: 26838
		' (get) Token: 0x06010E7F RID: 69247 RVA: 0x000746D5 File Offset: 0x000728D5
		' (set) Token: 0x06010E80 RID: 69248 RVA: 0x000746DF File Offset: 0x000728DF
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170068D7 RID: 26839
		' (get) Token: 0x06010E81 RID: 69249 RVA: 0x000746E8 File Offset: 0x000728E8
		' (set) Token: 0x06010E82 RID: 69250 RVA: 0x000746F2 File Offset: 0x000728F2
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170068D8 RID: 26840
		' (get) Token: 0x06010E83 RID: 69251 RVA: 0x000746FB File Offset: 0x000728FB
		' (set) Token: 0x06010E84 RID: 69252 RVA: 0x00074705 File Offset: 0x00072905
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170068D9 RID: 26841
		' (get) Token: 0x06010E85 RID: 69253 RVA: 0x0007470E File Offset: 0x0007290E
		' (set) Token: 0x06010E86 RID: 69254 RVA: 0x00074718 File Offset: 0x00072918
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170068DA RID: 26842
		' (get) Token: 0x06010E87 RID: 69255 RVA: 0x00074721 File Offset: 0x00072921
		' (set) Token: 0x06010E88 RID: 69256 RVA: 0x0007472B File Offset: 0x0007292B
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170068DB RID: 26843
		' (get) Token: 0x06010E89 RID: 69257 RVA: 0x00074734 File Offset: 0x00072934
		' (set) Token: 0x06010E8A RID: 69258 RVA: 0x0007473E File Offset: 0x0007293E
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170068DC RID: 26844
		' (get) Token: 0x06010E8B RID: 69259 RVA: 0x00074747 File Offset: 0x00072947
		' (set) Token: 0x06010E8C RID: 69260 RVA: 0x00074751 File Offset: 0x00072951
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170068DD RID: 26845
		' (get) Token: 0x06010E8D RID: 69261 RVA: 0x0007475A File Offset: 0x0007295A
		' (set) Token: 0x06010E8E RID: 69262 RVA: 0x00074764 File Offset: 0x00072964
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170068DE RID: 26846
		' (get) Token: 0x06010E8F RID: 69263 RVA: 0x0007476D File Offset: 0x0007296D
		' (set) Token: 0x06010E90 RID: 69264 RVA: 0x00074777 File Offset: 0x00072977
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170068DF RID: 26847
		' (get) Token: 0x06010E91 RID: 69265 RVA: 0x00074780 File Offset: 0x00072980
		' (set) Token: 0x06010E92 RID: 69266 RVA: 0x0007478A File Offset: 0x0007298A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170068E0 RID: 26848
		' (get) Token: 0x06010E93 RID: 69267 RVA: 0x00074793 File Offset: 0x00072993
		' (set) Token: 0x06010E94 RID: 69268 RVA: 0x0007479D File Offset: 0x0007299D
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170068E1 RID: 26849
		' (get) Token: 0x06010E95 RID: 69269 RVA: 0x000747A6 File Offset: 0x000729A6
		' (set) Token: 0x06010E96 RID: 69270 RVA: 0x000747B0 File Offset: 0x000729B0
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170068E2 RID: 26850
		' (get) Token: 0x06010E97 RID: 69271 RVA: 0x000747B9 File Offset: 0x000729B9
		' (set) Token: 0x06010E98 RID: 69272 RVA: 0x000747C3 File Offset: 0x000729C3
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170068E3 RID: 26851
		' (get) Token: 0x06010E99 RID: 69273 RVA: 0x000747CC File Offset: 0x000729CC
		' (set) Token: 0x06010E9A RID: 69274 RVA: 0x000747D6 File Offset: 0x000729D6
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170068E4 RID: 26852
		' (get) Token: 0x06010E9B RID: 69275 RVA: 0x000747DF File Offset: 0x000729DF
		' (set) Token: 0x06010E9C RID: 69276 RVA: 0x000747E9 File Offset: 0x000729E9
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170068E5 RID: 26853
		' (get) Token: 0x06010E9D RID: 69277 RVA: 0x000747F2 File Offset: 0x000729F2
		' (set) Token: 0x06010E9E RID: 69278 RVA: 0x000747FC File Offset: 0x000729FC
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170068E6 RID: 26854
		' (get) Token: 0x06010E9F RID: 69279 RVA: 0x00074805 File Offset: 0x00072A05
		' (set) Token: 0x06010EA0 RID: 69280 RVA: 0x0007480F File Offset: 0x00072A0F
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170068E7 RID: 26855
		' (get) Token: 0x06010EA1 RID: 69281 RVA: 0x00074818 File Offset: 0x00072A18
		' (set) Token: 0x06010EA2 RID: 69282 RVA: 0x00074822 File Offset: 0x00072A22
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170068E8 RID: 26856
		' (get) Token: 0x06010EA3 RID: 69283 RVA: 0x0007482B File Offset: 0x00072A2B
		' (set) Token: 0x06010EA4 RID: 69284 RVA: 0x00074835 File Offset: 0x00072A35
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170068E9 RID: 26857
		' (get) Token: 0x06010EA5 RID: 69285 RVA: 0x0007483E File Offset: 0x00072A3E
		' (set) Token: 0x06010EA6 RID: 69286 RVA: 0x00074848 File Offset: 0x00072A48
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170068EA RID: 26858
		' (get) Token: 0x06010EA7 RID: 69287 RVA: 0x00074851 File Offset: 0x00072A51
		' (set) Token: 0x06010EA8 RID: 69288 RVA: 0x0007485B File Offset: 0x00072A5B
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170068EB RID: 26859
		' (get) Token: 0x06010EA9 RID: 69289 RVA: 0x00074864 File Offset: 0x00072A64
		' (set) Token: 0x06010EAA RID: 69290 RVA: 0x0007486E File Offset: 0x00072A6E
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170068EC RID: 26860
		' (get) Token: 0x06010EAB RID: 69291 RVA: 0x00074877 File Offset: 0x00072A77
		' (set) Token: 0x06010EAC RID: 69292 RVA: 0x00074881 File Offset: 0x00072A81
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170068ED RID: 26861
		' (get) Token: 0x06010EAD RID: 69293 RVA: 0x0007488A File Offset: 0x00072A8A
		' (set) Token: 0x06010EAE RID: 69294 RVA: 0x00074894 File Offset: 0x00072A94
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170068EE RID: 26862
		' (get) Token: 0x06010EAF RID: 69295 RVA: 0x0007489D File Offset: 0x00072A9D
		' (set) Token: 0x06010EB0 RID: 69296 RVA: 0x000748A7 File Offset: 0x00072AA7
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170068EF RID: 26863
		' (get) Token: 0x06010EB1 RID: 69297 RVA: 0x000748B0 File Offset: 0x00072AB0
		' (set) Token: 0x06010EB2 RID: 69298 RVA: 0x000748BA File Offset: 0x00072ABA
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170068F0 RID: 26864
		' (get) Token: 0x06010EB3 RID: 69299 RVA: 0x000748C3 File Offset: 0x00072AC3
		' (set) Token: 0x06010EB4 RID: 69300 RVA: 0x000748CD File Offset: 0x00072ACD
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170068F1 RID: 26865
		' (get) Token: 0x06010EB5 RID: 69301 RVA: 0x000748D6 File Offset: 0x00072AD6
		' (set) Token: 0x06010EB6 RID: 69302 RVA: 0x000748E0 File Offset: 0x00072AE0
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170068F2 RID: 26866
		' (get) Token: 0x06010EB7 RID: 69303 RVA: 0x000748E9 File Offset: 0x00072AE9
		' (set) Token: 0x06010EB8 RID: 69304 RVA: 0x000748F3 File Offset: 0x00072AF3
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170068F3 RID: 26867
		' (get) Token: 0x06010EB9 RID: 69305 RVA: 0x000748FC File Offset: 0x00072AFC
		' (set) Token: 0x06010EBA RID: 69306 RVA: 0x009D57AC File Offset: 0x009D39AC
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

		' Token: 0x170068F4 RID: 26868
		' (get) Token: 0x06010EBB RID: 69307 RVA: 0x00074906 File Offset: 0x00072B06
		' (set) Token: 0x06010EBC RID: 69308 RVA: 0x009D57F0 File Offset: 0x009D39F0
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

		' Token: 0x170068F5 RID: 26869
		' (get) Token: 0x06010EBD RID: 69309 RVA: 0x00074910 File Offset: 0x00072B10
		' (set) Token: 0x06010EBE RID: 69310 RVA: 0x009D5834 File Offset: 0x009D3A34
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

		' Token: 0x06010EBF RID: 69311 RVA: 0x009D5878 File Offset: 0x009D3A78
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

		' Token: 0x06010EC0 RID: 69312 RVA: 0x009D594C File Offset: 0x009D3B4C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType, RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010EC1 RID: 69313 RVA: 0x009D5CD4 File Offset: 0x009D3ED4
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010EC2 RID: 69314 RVA: 0x009D5D6C File Offset: 0x009D3F6C
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

		' Token: 0x06010EC3 RID: 69315 RVA: 0x009D5EE4 File Offset: 0x009D40E4
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

		' Token: 0x06010EC4 RID: 69316 RVA: 0x009D5FB0 File Offset: 0x009D41B0
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

		' Token: 0x06010EC5 RID: 69317 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010EC6 RID: 69318 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010EC7 RID: 69319 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010EC8 RID: 69320 RVA: 0x009D607C File Offset: 0x009D427C
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

		' Token: 0x06010EC9 RID: 69321 RVA: 0x0007491A File Offset: 0x00072B1A
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06010ECA RID: 69322 RVA: 0x009D6164 File Offset: 0x009D4364
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.InvoiceNo=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.SupplierInvoiceNo=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Supplier.Name=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Product.ProductName=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Product.ProductCode=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 5
										If flag7 Then
											ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Barcode=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
											ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
											ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 6
											If flag8 Then
												ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Color=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
												ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
												ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
											Else
												Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 7
												If flag9 Then
													ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Size=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
													ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
													ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
												Else
													Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 8
													If flag10 Then
														ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Info=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
														ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
														ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
													Else
														Dim flag11 As Boolean = Me.ComboBox1.SelectedIndex = 9
														If flag11 Then
															ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Batch=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
															ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
															ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
														Else
															Dim flag12 As Boolean = Me.ComboBox1.SelectedIndex = 10
															If flag12 Then
																ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.IMEI1=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
																ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
																ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
															Else
																Dim flag13 As Boolean = Me.ComboBox1.SelectedIndex = 11
																If flag13 Then
																	ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.IMEI2=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
																	ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
																	ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
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
						End If
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06010ECB RID: 69323 RVA: 0x0007493C File Offset: 0x00072B3C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010ECC RID: 69324 RVA: 0x00074971 File Offset: 0x00072B71
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010ECD RID: 69325 RVA: 0x009D6D4C File Offset: 0x009D4F4C
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.cpy = dataGridViewRow.Cells(0).Value.ToString()
				Clipboard.SetDataObject(Me.cpy)
				MessageBox.Show("Invoice Number is Copied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010ECE RID: 69326 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010ECF RID: 69327 RVA: 0x009D6DCC File Offset: 0x009D4FCC
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
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x06010ED0 RID: 69328 RVA: 0x009D6EE4 File Offset: 0x009D50E4
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and NOT Stock.TaxType=@d3 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.TaxType=@d3 order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010ED1 RID: 69329 RVA: 0x009D7358 File Offset: 0x009D5558
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010ED2 RID: 69330 RVA: 0x009D7700 File Offset: 0x009D5900
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06010ED3 RID: 69331 RVA: 0x009D7750 File Offset: 0x009D5950
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

		' Token: 0x040065D5 RID: 26069
		Private cpy As String
	End Class
End Namespace
