Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000127 RID: 295
	<DesignerGenerated()>
	Public Partial Class frmLead2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060032D6 RID: 13014 RVA: 0x0001F922 File Offset: 0x0001DB22
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLead2_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170013C5 RID: 5061
		' (get) Token: 0x060032D9 RID: 13017 RVA: 0x0001F942 File Offset: 0x0001DB42
		' (set) Token: 0x060032DA RID: 13018 RVA: 0x001F831C File Offset: 0x001F651C
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView1_EditingControlShowing
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView1_KeyDown
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellDoubleClick
				Dim dataGridViewCellCancelEventHandler As DataGridViewCellCancelEventHandler = AddressOf Me.DataGridView1_CellBeginEdit
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler2
					RemoveHandler dataGridView.CellBeginEdit, dataGridViewCellCancelEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler2
					AddHandler dataGridView.CellBeginEdit, dataGridViewCellCancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C6 RID: 5062
		' (get) Token: 0x060032DB RID: 13019 RVA: 0x0001F94C File Offset: 0x0001DB4C
		' (set) Token: 0x060032DC RID: 13020 RVA: 0x001F83DC File Offset: 0x001F65DC
		Private _GelButtonNewRecord As Button
		Friend Overridable Property GelButtonNewRecord As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C7 RID: 5063
		' (get) Token: 0x060032DD RID: 13021 RVA: 0x0001F956 File Offset: 0x0001DB56
		' (set) Token: 0x060032DE RID: 13022 RVA: 0x001F8420 File Offset: 0x001F6620
		Private _grdState As DataGridView
		Friend Overridable Property grdState As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.grdState_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdState_KeyDown_1
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdState_CellDoubleClick
				Dim dataGridView As DataGridView = Me._grdState
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._grdState = value
				dataGridView = Me._grdState
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C8 RID: 5064
		' (get) Token: 0x060032DF RID: 13023 RVA: 0x0001F960 File Offset: 0x0001DB60
		' (set) Token: 0x060032E0 RID: 13024 RVA: 0x0001F96A File Offset: 0x0001DB6A
		Friend Overridable Property txtID_Update As TextBox

		' Token: 0x170013C9 RID: 5065
		' (get) Token: 0x060032E1 RID: 13025 RVA: 0x0001F973 File Offset: 0x0001DB73
		' (set) Token: 0x060032E2 RID: 13026 RVA: 0x0001F97D File Offset: 0x0001DB7D
		Friend Overridable Property txtID As TextBox

		' Token: 0x170013CA RID: 5066
		' (get) Token: 0x060032E3 RID: 13027 RVA: 0x0001F986 File Offset: 0x0001DB86
		' (set) Token: 0x060032E4 RID: 13028 RVA: 0x0001F990 File Offset: 0x0001DB90
		Friend Overridable Property lblUser As Label

		' Token: 0x170013CB RID: 5067
		' (get) Token: 0x060032E5 RID: 13029 RVA: 0x0001F999 File Offset: 0x0001DB99
		' (set) Token: 0x060032E6 RID: 13030 RVA: 0x0001F9A3 File Offset: 0x0001DBA3
		Friend Overridable Property Panel7 As Panel

		' Token: 0x170013CC RID: 5068
		' (get) Token: 0x060032E7 RID: 13031 RVA: 0x0001F9AC File Offset: 0x0001DBAC
		' (set) Token: 0x060032E8 RID: 13032 RVA: 0x0001F9B6 File Offset: 0x0001DBB6
		Friend Overridable Property Label18 As Label

		' Token: 0x170013CD RID: 5069
		' (get) Token: 0x060032E9 RID: 13033 RVA: 0x0001F9BF File Offset: 0x0001DBBF
		' (set) Token: 0x060032EA RID: 13034 RVA: 0x0001F9C9 File Offset: 0x0001DBC9
		Friend Overridable Property Label21 As Label

		' Token: 0x170013CE RID: 5070
		' (get) Token: 0x060032EB RID: 13035 RVA: 0x0001F9D2 File Offset: 0x0001DBD2
		' (set) Token: 0x060032EC RID: 13036 RVA: 0x001F849C File Offset: 0x001F669C
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTopResult_KeyDown
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013CF RID: 5071
		' (get) Token: 0x060032ED RID: 13037 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		' (set) Token: 0x060032EE RID: 13038 RVA: 0x001F84E0 File Offset: 0x001F66E0
		Private _grdCo_Mode As DataGridView
		Friend Overridable Property grdCo_Mode As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdCo_Mode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.grdCo_Mode_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdCo_Mode_KeyDown_1
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdCo_Mode_CellDoubleClick
				Dim dataGridView As DataGridView = Me._grdCo_Mode
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._grdCo_Mode = value
				dataGridView = Me._grdCo_Mode
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D0 RID: 5072
		' (get) Token: 0x060032EF RID: 13039 RVA: 0x0001F9E6 File Offset: 0x0001DBE6
		' (set) Token: 0x060032F0 RID: 13040 RVA: 0x001F855C File Offset: 0x001F675C
		Private _grdIntrest_Mode As DataGridView
		Friend Overridable Property grdIntrest_Mode As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdIntrest_Mode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.grdIntrest_Mode_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdIntrest_Mode_KeyDown_1
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdIntrest_Mode_CellDoubleClick
				Dim dataGridView As DataGridView = Me._grdIntrest_Mode
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._grdIntrest_Mode = value
				dataGridView = Me._grdIntrest_Mode
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D1 RID: 5073
		' (get) Token: 0x060032F1 RID: 13041 RVA: 0x0001F9F0 File Offset: 0x0001DBF0
		' (set) Token: 0x060032F2 RID: 13042 RVA: 0x001F85D8 File Offset: 0x001F67D8
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D2 RID: 5074
		' (get) Token: 0x060032F3 RID: 13043 RVA: 0x0001F9FA File Offset: 0x0001DBFA
		' (set) Token: 0x060032F4 RID: 13044 RVA: 0x001F861C File Offset: 0x001F681C
		Private _btnExportExcel As Button
		Friend Overridable Property btnExportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim button As Button = Me._btnExportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExportExcel = value
				button = Me._btnExportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D3 RID: 5075
		' (get) Token: 0x060032F5 RID: 13045 RVA: 0x0001FA04 File Offset: 0x0001DC04
		' (set) Token: 0x060032F6 RID: 13046 RVA: 0x001F8660 File Offset: 0x001F6860
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D4 RID: 5076
		' (get) Token: 0x060032F7 RID: 13047 RVA: 0x0001FA0E File Offset: 0x0001DC0E
		' (set) Token: 0x060032F8 RID: 13048 RVA: 0x001F86A4 File Offset: 0x001F68A4
		Private _grdProduct As DataGridView
		Friend Overridable Property grdProduct As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.grdProduct_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdProduct_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdProduct_CellDoubleClick
				Dim dataGridView As DataGridView = Me._grdProduct
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._grdProduct = value
				dataGridView = Me._grdProduct
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D5 RID: 5077
		' (get) Token: 0x060032F9 RID: 13049 RVA: 0x0001FA18 File Offset: 0x0001DC18
		' (set) Token: 0x060032FA RID: 13050 RVA: 0x001F8720 File Offset: 0x001F6920
		Private _grdUser As DataGridView
		Friend Overridable Property grdUser As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdUser
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.grdUser_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdUser_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdUser_CellDoubleClick
				Dim dataGridView As DataGridView = Me._grdUser
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._grdUser = value
				dataGridView = Me._grdUser
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170013D6 RID: 5078
		' (get) Token: 0x060032FB RID: 13051 RVA: 0x0001FA22 File Offset: 0x0001DC22
		' (set) Token: 0x060032FC RID: 13052 RVA: 0x0001FA2C File Offset: 0x0001DC2C
		Friend Overridable Property txtLead_Id As TextBox

		' Token: 0x170013D7 RID: 5079
		' (get) Token: 0x060032FD RID: 13053 RVA: 0x0001FA35 File Offset: 0x0001DC35
		' (set) Token: 0x060032FE RID: 13054 RVA: 0x0001FA3F File Offset: 0x0001DC3F
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170013D8 RID: 5080
		' (get) Token: 0x060032FF RID: 13055 RVA: 0x0001FA48 File Offset: 0x0001DC48
		' (set) Token: 0x06003300 RID: 13056 RVA: 0x0001FA52 File Offset: 0x0001DC52
		Friend Overridable Property lblUserType As Label

		' Token: 0x170013D9 RID: 5081
		' (get) Token: 0x06003301 RID: 13057 RVA: 0x0001FA5B File Offset: 0x0001DC5B
		' (set) Token: 0x06003302 RID: 13058 RVA: 0x001F879C File Offset: 0x001F699C
		Private _btnAddProduct As Button
		Friend Overridable Property btnAddProduct As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAddProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddProduct_Click
				Dim button As Button = Me._btnAddProduct
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAddProduct = value
				button = Me._btnAddProduct
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013DA RID: 5082
		' (get) Token: 0x06003303 RID: 13059 RVA: 0x0001FA65 File Offset: 0x0001DC65
		' (set) Token: 0x06003304 RID: 13060 RVA: 0x0001FA6F File Offset: 0x0001DC6F
		Friend Overridable Property Label15 As Label

		' Token: 0x170013DB RID: 5083
		' (get) Token: 0x06003305 RID: 13061 RVA: 0x0001FA78 File Offset: 0x0001DC78
		' (set) Token: 0x06003306 RID: 13062 RVA: 0x0001FA82 File Offset: 0x0001DC82
		Friend Overridable Property Id As DataGridViewTextBoxColumn

		' Token: 0x170013DC RID: 5084
		' (get) Token: 0x06003307 RID: 13063 RVA: 0x0001FA8B File Offset: 0x0001DC8B
		' (set) Token: 0x06003308 RID: 13064 RVA: 0x0001FA95 File Offset: 0x0001DC95
		Friend Overridable Property lead_id As DataGridViewTextBoxColumn

		' Token: 0x170013DD RID: 5085
		' (get) Token: 0x06003309 RID: 13065 RVA: 0x0001FA9E File Offset: 0x0001DC9E
		' (set) Token: 0x0600330A RID: 13066 RVA: 0x0001FAA8 File Offset: 0x0001DCA8
		Friend Overridable Property customer_name As DataGridViewTextBoxColumn

		' Token: 0x170013DE RID: 5086
		' (get) Token: 0x0600330B RID: 13067 RVA: 0x0001FAB1 File Offset: 0x0001DCB1
		' (set) Token: 0x0600330C RID: 13068 RVA: 0x0001FABB File Offset: 0x0001DCBB
		Friend Overridable Property co_mode As DataGridViewTextBoxColumn

		' Token: 0x170013DF RID: 5087
		' (get) Token: 0x0600330D RID: 13069 RVA: 0x0001FAC4 File Offset: 0x0001DCC4
		' (set) Token: 0x0600330E RID: 13070 RVA: 0x0001FACE File Offset: 0x0001DCCE
		Friend Overridable Property mobileno As DataGridViewTextBoxColumn

		' Token: 0x170013E0 RID: 5088
		' (get) Token: 0x0600330F RID: 13071 RVA: 0x0001FAD7 File Offset: 0x0001DCD7
		' (set) Token: 0x06003310 RID: 13072 RVA: 0x0001FAE1 File Offset: 0x0001DCE1
		Friend Overridable Property state As DataGridViewTextBoxColumn

		' Token: 0x170013E1 RID: 5089
		' (get) Token: 0x06003311 RID: 13073 RVA: 0x0001FAEA File Offset: 0x0001DCEA
		' (set) Token: 0x06003312 RID: 13074 RVA: 0x0001FAF4 File Offset: 0x0001DCF4
		Friend Overridable Property address As DataGridViewTextBoxColumn

		' Token: 0x170013E2 RID: 5090
		' (get) Token: 0x06003313 RID: 13075 RVA: 0x0001FAFD File Offset: 0x0001DCFD
		' (set) Token: 0x06003314 RID: 13076 RVA: 0x0001FB07 File Offset: 0x0001DD07
		Friend Overridable Property intrest_mode As DataGridViewTextBoxColumn

		' Token: 0x170013E3 RID: 5091
		' (get) Token: 0x06003315 RID: 13077 RVA: 0x0001FB10 File Offset: 0x0001DD10
		' (set) Token: 0x06003316 RID: 13078 RVA: 0x0001FB1A File Offset: 0x0001DD1A
		Friend Overridable Property product_name As DataGridViewTextBoxColumn

		' Token: 0x170013E4 RID: 5092
		' (get) Token: 0x06003317 RID: 13079 RVA: 0x0001FB23 File Offset: 0x0001DD23
		' (set) Token: 0x06003318 RID: 13080 RVA: 0x0001FB2D File Offset: 0x0001DD2D
		Friend Overridable Property alloted_user As DataGridViewTextBoxColumn

		' Token: 0x170013E5 RID: 5093
		' (get) Token: 0x06003319 RID: 13081 RVA: 0x0001FB36 File Offset: 0x0001DD36
		' (set) Token: 0x0600331A RID: 13082 RVA: 0x0001FB40 File Offset: 0x0001DD40
		Friend Overridable Property remarks As DataGridViewTextBoxColumn

		' Token: 0x170013E6 RID: 5094
		' (get) Token: 0x0600331B RID: 13083 RVA: 0x0001FB49 File Offset: 0x0001DD49
		' (set) Token: 0x0600331C RID: 13084 RVA: 0x0001FB53 File Offset: 0x0001DD53
		Friend Overridable Property InsertButtonColumn As DataGridViewButtonColumn

		' Token: 0x170013E7 RID: 5095
		' (get) Token: 0x0600331D RID: 13085 RVA: 0x0001FB5C File Offset: 0x0001DD5C
		' (set) Token: 0x0600331E RID: 13086 RVA: 0x0001FB66 File Offset: 0x0001DD66
		Friend Overridable Property UpdateButtonColumn As DataGridViewButtonColumn

		' Token: 0x170013E8 RID: 5096
		' (get) Token: 0x0600331F RID: 13087 RVA: 0x0001FB6F File Offset: 0x0001DD6F
		' (set) Token: 0x06003320 RID: 13088 RVA: 0x0001FB79 File Offset: 0x0001DD79
		Friend Overridable Property DeleteButtonColumn As DataGridViewButtonColumn

		' Token: 0x170013E9 RID: 5097
		' (get) Token: 0x06003321 RID: 13089 RVA: 0x0001FB82 File Offset: 0x0001DD82
		' (set) Token: 0x06003322 RID: 13090 RVA: 0x001F87E0 File Offset: 0x001F69E0
		Private _txtMobile As TextBox
		Friend Overridable Property txtMobile As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMobile
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMobile_TextChanged
				Dim textBox As TextBox = Me._txtMobile
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtMobile = value
				textBox = Me._txtMobile
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013EA RID: 5098
		' (get) Token: 0x06003323 RID: 13091 RVA: 0x0001FB8C File Offset: 0x0001DD8C
		' (set) Token: 0x06003324 RID: 13092 RVA: 0x0001FB96 File Offset: 0x0001DD96
		Friend Overridable Property Label1 As Label

		' Token: 0x06003325 RID: 13093 RVA: 0x001F8824 File Offset: 0x001F6A24
		Private Sub frmLead2_Load(sender As Object, e As EventArgs)
			Me.LoadStates()
			Me.LoadProducts()
			Me.LoadUsers()
			Me.LoadCoModeGrid()
			Me.LoadInterestModeGrid()
			Me.DataGridView1.Columns(3).DefaultCellStyle.ForeColor = Color.Black
			Me.GetLeadData()
			Me.auto()
		End Sub

		' Token: 0x06003326 RID: 13094 RVA: 0x001F8884 File Offset: 0x001F6A84
		Private Sub LoadCoModeGrid()
			Me.grdCo_Mode.Columns.Clear()
			Me.grdCo_Mode.Rows.Clear()
			Dim dataGridViewTextBoxColumn As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
			dataGridViewTextBoxColumn.HeaderText = "Co-Ordinate Mode"
			dataGridViewTextBoxColumn.Name = "CoMode"
			dataGridViewTextBoxColumn.Width = 200
			Me.grdCo_Mode.Columns.Add(dataGridViewTextBoxColumn)
			Dim array As String() = New String() { "Owner", "Salesman", "Accountant", "Manager", "Clerk" }
			For Each text As String In array
				Me.grdCo_Mode.Rows.Add(New Object() { text })
			Next
			Me.grdCo_Mode.RowHeadersVisible = False
			Me.grdCo_Mode.AllowUserToAddRows = False
			Me.grdCo_Mode.AllowUserToDeleteRows = False
			Me.grdCo_Mode.[ReadOnly] = True
			Me.grdCo_Mode.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		End Sub

		' Token: 0x06003327 RID: 13095 RVA: 0x001F8998 File Offset: 0x001F6B98
		Private Sub LoadInterestModeGrid()
			Me.grdIntrest_Mode.Columns.Clear()
			Me.grdIntrest_Mode.Rows.Clear()
			Dim dataGridViewTextBoxColumn As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
			dataGridViewTextBoxColumn.HeaderText = "Interest Mode"
			dataGridViewTextBoxColumn.Name = "InterestMode"
			dataGridViewTextBoxColumn.Width = 200
			Me.grdIntrest_Mode.Columns.Add(dataGridViewTextBoxColumn)
			Dim array As String() = New String() { "Low", "Medium", "High" }
			For Each text As String In array
				Me.grdIntrest_Mode.Rows.Add(New Object() { text })
			Next
			Me.grdIntrest_Mode.RowHeadersVisible = False
			Me.grdIntrest_Mode.AllowUserToAddRows = False
			Me.grdIntrest_Mode.AllowUserToDeleteRows = False
			Me.grdIntrest_Mode.[ReadOnly] = True
			Me.grdIntrest_Mode.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		End Sub

		' Token: 0x06003328 RID: 13096 RVA: 0x001F8A9C File Offset: 0x001F6C9C
		Public Sub GetLeadData()
			Try
				Me.Cursor = Cursors.WaitCursor
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " " & vbCrLf & "                    id, lead_id,                    " & vbCrLf & "                    customer_name," & vbCrLf & "                    coordinate_mode," & vbCrLf & "                    mobile," & vbCrLf & "                    state," & vbCrLf & "                    address," & vbCrLf & "                    interest_mode," & vbCrLf & "                    productname," & vbCrLf & "                    alloted_user," & vbCrLf & "                    remarks" & vbCrLf & "                    " & vbCrLf & "                 FROM tbl_lead_master" & vbCrLf & "                 ORDER BY lead_id DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.CommandTimeout = 0
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader("Id"), sqlDataReader("lead_id"), sqlDataReader("customer_name"), sqlDataReader("coordinate_mode"), sqlDataReader("mobile"), sqlDataReader("state"), sqlDataReader("address"), sqlDataReader("interest_mode"), sqlDataReader("productname"), sqlDataReader("alloted_user"), sqlDataReader("remarks") })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.ClearSelection()
				RemoveHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				AddHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
			Catch ex As Exception
				MessageBox.Show("Error loading lead data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x06003329 RID: 13097 RVA: 0x001F8CFC File Offset: 0x001F6EFC
		Private Sub LoadStates()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT name as StateName FROM tbl_state ORDER BY name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdState.DataSource = dataTable
						End Using
					End Using
				End Using
				Me.grdState.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
				Me.grdState.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				Me.grdState.[ReadOnly] = True
			Catch ex As Exception
				MessageBox.Show("Error loading states: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600332A RID: 13098 RVA: 0x001F8E04 File Offset: 0x001F7004
		Private Sub LoadProducts()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT product_name As ProductName" & vbCrLf & "                                   FROM tbl_lead_product " & vbCrLf & "                                   WHERE is_deleted = 0 " & vbCrLf & "                                   ORDER BY product_name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdProduct.DataSource = dataTable
						End Using
					End Using
				End Using
				Me.grdProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
				Me.grdProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				Me.grdProduct.[ReadOnly] = True
			Catch ex As Exception
				MessageBox.Show("Error loading products: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600332B RID: 13099 RVA: 0x001F8F0C File Offset: 0x001F710C
		Private Sub LoadUsers()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT RTRIM(UserID) UserName " & vbCrLf & "                                   FROM Registration where RTRIM(UserType)='Sales Person'" & vbCrLf & "                                   ORDER BY UserID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdUser.DataSource = dataTable
						End Using
					End Using
				End Using
				Me.grdUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
				Me.grdUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				Me.grdUser.[ReadOnly] = True
			Catch ex As Exception
				MessageBox.Show("Error loading users: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600332C RID: 13100 RVA: 0x001F9014 File Offset: 0x001F7214
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.strLead_Id = ""
			Me.GetLeadData()
			Me.DataGridView1.[ReadOnly] = False
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			Dim num2 As Integer = 4
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num).Cells(num2)
			Me.DataGridView1.BeginEdit(True)
		End Sub

		' Token: 0x0600332D RID: 13101 RVA: 0x001F908C File Offset: 0x001F728C
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("UpdateButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.txtID_Update.Text = dataGridViewRow.Cells(0).Value.ToString()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "UPDATE tbl_lead_master " & vbCrLf & "                    SET customer_name=@customer_name, " & vbCrLf & "                        coordinate_mode=@coordinate_mode, " & vbCrLf & "                        mobile=@mobile, " & vbCrLf & "                        state=@state, " & vbCrLf & "                        address=@address, " & vbCrLf & "                        interest_mode=@interest_mode, " & vbCrLf & "                        productname=@productname, " & vbCrLf & "                        remarks=@remarks " & vbCrLf & "                    WHERE id=@id"
				ModCommonClasses.cmd = New SqlCommand(text)
				Dim nullIfEmpty As Func(Of Object, Object) = Function(val As Object) If(val Is Nothing OrElse val Is DBNull.Value OrElse String.IsNullOrWhiteSpace(val.ToString()), CObj(DBNull.Value), val)
				ModCommonClasses.cmd.Parameters.Add("@id", SqlDbType.Int).Value = Conversion.Val(Me.txtID_Update.Text)
				ModCommonClasses.cmd.Parameters.Add("@customer_name", SqlDbType.NVarChar, 200).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("customer_name").Value)))
				ModCommonClasses.cmd.Parameters.Add("@coordinate_mode", SqlDbType.NVarChar, 50).Value = "Owner"
				ModCommonClasses.cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 15).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("mobileno").Value)))
				ModCommonClasses.cmd.Parameters.Add("@state", SqlDbType.NVarChar, 100).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("state").Value)))
				ModCommonClasses.cmd.Parameters.Add("@address", SqlDbType.NVarChar, 300).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("state").Value)))
				ModCommonClasses.cmd.Parameters.Add("@interest_mode", SqlDbType.NVarChar, 20).Value = "HIGH"
				ModCommonClasses.cmd.Parameters.Add("@productname", SqlDbType.NVarChar, 200).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("product_name").Value)))
				ModCommonClasses.cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 500).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("remarks").Value)))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				ModFunc.LogFunc(Me.lblUser.Text, "updated the Lead '-' having Product code '" + Me.txtID_Update.Text + "'")
				MessageBox.Show("Successfully Updated", "Lead Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.GetLeadData()
				ModCommonClasses.con.Close()
			End If
			Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("DeleteButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag2 Then
				Try
					Dim flag3 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag3 Then
						Try
							Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
							Me.txtID_Update.Text = dataGridViewRow2.Cells(0).Value.ToString()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "SELECT lead_id FROM tbl_followup_lead where lead_id=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Unable to delete..Already in use in Lead Follow_Up", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
								Return
							End If
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "delete from tbl_lead_master where Id=@d1"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
							Dim flag6 As Boolean = num > 0
							If flag6 Then
								ModFunc.LogFunc(Me.lblUser.Text, "deleted the Lead '-' having Lead Id '" + Me.txtID_Update.Text + "'")
								MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.GetLeadData()
								ModCommonClasses.con.Close()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag7 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("InsertButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag7 Then
				Dim dataGridViewRow3 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim flag8 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow3.Cells("lead_id").Value))) = 0) Or (dataGridViewRow3.Cells("lead_id").Value Is Nothing)
				If flag8 Then
					MessageBox.Show("Please enter lead_id ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.ScrollToSelectedCell(CShort(e.RowIndex), 1S)
				Else
					Dim flag9 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow3.Cells("mobileno").Value))) = 0) Or (dataGridViewRow3.Cells("mobileno").Value Is Nothing)
					If flag9 Then
						MessageBox.Show("Please enter mobile no. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 4S)
					Else
						Dim text4 As String = Strings.Trim(dataGridViewRow3.Cells("mobileno").Value.ToString())
						Dim flag10 As Boolean = Not Regex.IsMatch(text4, "^[0-9]+$")
						If flag10 Then
							MessageBox.Show("Mobile number must contain digits only.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ScrollToSelectedCell(CShort(e.RowIndex), 4S)
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text5 As String = "select RTRIM(mobile) from tbl_lead_master where mobile=@d1"
							ModCommonClasses.cmd = New SqlCommand(text5)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("mobileno").Value))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
							If flag11 Then
								MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.ScrollToSelectedCell(CShort(e.RowIndex), 4S)
								Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag12 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Me.auto()
								Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
									sqlConnection.Open()
									Dim text6 As String = vbCrLf & "        INSERT INTO tbl_lead_master " & vbCrLf & "        (id, lead_id, lead_date, customer_name, coordinate_mode, mobile, state, address, interest_mode, productname, remarks, alloted_user) " & vbCrLf & "        VALUES (@id, @lead_id, @lead_date, @customer_name, @coordinate_mode, @mobile, @state, @address, @interest_mode, @productname, @remarks, @alloted_user)" & vbCrLf & "    "
									Using sqlCommand As SqlCommand = New SqlCommand(text6, sqlConnection)
										Dim nullIfEmpty As Func(Of Object, Object) = Function(val As Object) If(val Is Nothing OrElse val Is DBNull.Value OrElse String.IsNullOrWhiteSpace(val.ToString()), CObj(DBNull.Value), val)
										sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = Conversion.Val(Me.txtID.Text)
										sqlCommand.Parameters.Add("@lead_id", SqlDbType.NVarChar, 50).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("lead_id").Value)))
										sqlCommand.Parameters.Add("@lead_date", SqlDbType.DateTime).Value = DateTime.Now
										Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("customer_name").Value)
										Dim flag13 As Boolean = objectValue Is Nothing OrElse objectValue Is DBNull.Value OrElse String.IsNullOrWhiteSpace(objectValue.ToString())
										If flag13 Then
											sqlCommand.Parameters.Add("@customer_name", SqlDbType.NVarChar, 200).Value = "NA"
										Else
											sqlCommand.Parameters.Add("@customer_name", SqlDbType.NVarChar, 200).Value = objectValue.ToString()
										End If
										sqlCommand.Parameters.Add("@coordinate_mode", SqlDbType.NVarChar, 50).Value = "Owner"
										sqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar, 15).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("mobileno").Value)))
										Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("state").Value)
										Dim flag14 As Boolean = objectValue2 Is Nothing OrElse objectValue2 Is DBNull.Value OrElse String.IsNullOrWhiteSpace(objectValue2.ToString())
										If flag14 Then
											sqlCommand.Parameters.Add("@state", SqlDbType.NVarChar, 100).Value = "NA"
										Else
											sqlCommand.Parameters.Add("@state", SqlDbType.NVarChar, 100).Value = objectValue2.ToString()
										End If
										sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 300).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("state").Value)))
										sqlCommand.Parameters.Add("@interest_mode", SqlDbType.NVarChar, 20).Value = "HIGH"
										Dim objectValue3 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("product_name").Value)
										Dim flag15 As Boolean = objectValue3 Is Nothing OrElse objectValue3 Is DBNull.Value OrElse String.IsNullOrWhiteSpace(objectValue3.ToString())
										If flag15 Then
											sqlCommand.Parameters.Add("@productname", SqlDbType.NVarChar, 200).Value = "NA"
										Else
											sqlCommand.Parameters.Add("@productname", SqlDbType.NVarChar, 200).Value = objectValue3.ToString()
										End If
										sqlCommand.Parameters.Add("@remarks", SqlDbType.NVarChar, 500).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("remarks").Value)))
										sqlCommand.Parameters.Add("@alloted_user", SqlDbType.NVarChar, 100).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("alloted_user").Value)))
										Try
											sqlCommand.ExecuteNonQuery()
											MessageBox.Show("Successfully Saved", "Lead Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.auto()
											Me.GetLeadData()
											Me.GelButtonNewRecord_Click(RuntimeHelpers.GetObjectValue(sender), e)
											Me.DataGridView1.CurrentCell = Me.DataGridView1(4, e.RowIndex)
											Me.DataGridView1.BeginEdit(True)
										Catch ex3 As Exception
											MessageBox.Show("Error inserting lead: " + ex3.Message)
										End Try
									End Using
								End Using
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600332E RID: 13102 RVA: 0x001F9DD0 File Offset: 0x001F7FD0
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtLead_Id.Text = "L-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600332F RID: 13103 RVA: 0x00162C30 File Offset: 0x00160E30
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 id FROM tbl_lead_master ORDER BY id DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("id"))
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

		' Token: 0x06003330 RID: 13104 RVA: 0x001F9E44 File Offset: 0x001F8044
		Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf e.Control Is TextBox
				If flag Then
					Dim textBox As TextBox = CType(e.Control, TextBox)
					RemoveHandler textBox.TextChanged, AddressOf Me.DGV_TextChanged
					AddHandler textBox.TextChanged, AddressOf Me.DGV_TextChanged
				End If
				Dim flag2 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell
				If flag2 Then
					Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
				Else
					Dim flag3 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewTextBoxCell
					If flag3 Then
						Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
						RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
						AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003331 RID: 13105 RVA: 0x001F9F34 File Offset: 0x001F8134
		Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 13
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
						Else
							Dim rowIndex As Integer = dataGridView.CurrentCell.RowIndex
							Dim num As Integer = dataGridView.CurrentCell.ColumnIndex
							While num < dataGridView.ColumnCount AndAlso Not dataGridView.Columns(num).Visible
								num += 1
							End While
							dataGridView.CurrentCell = dataGridView(num, rowIndex)
							dataGridView.BeginEdit(True)
						End If
					Else
						Dim flag4 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag4 Then
							dataGridView.CurrentCell = dataGridView(0, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex2 As Integer = Me.DataGridView1.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
					Dim flag5 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag5 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
							Me.DataGridView1_CellContentClick(Me.DataGridView1, New DataGridViewCellEventArgs(columnIndex, rowIndex2))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
				Dim flag6 As Boolean = e.KeyCode = Keys.Left
				If flag6 Then
					Dim flag7 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
					If flag7 Then
						e.Handled = True
						Dim flag8 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex > 0
						If flag8 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex - 1, Me.DataGridView1.CurrentCell.RowIndex)
						End If
						Me.DataGridView1.BeginEdit(True)
						e.SuppressKeyPress = True
					End If
				Else
					Dim flag9 As Boolean = e.KeyCode = Keys.Right
					If flag9 Then
						Dim flag10 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
						If flag10 Then
							e.Handled = True
							Dim flag11 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.ColumnCount - 1
							If flag11 Then
								Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex + 1, Me.DataGridView1.CurrentCell.RowIndex)
							End If
							Me.DataGridView1.BeginEdit(True)
							e.SuppressKeyPress = True
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003332 RID: 13106 RVA: 0x001FA268 File Offset: 0x001F8468
		Public Sub ScrollToSelectedCell(rowIndex As Short, colIndex As Short)
			Me.DataGridView1.FirstDisplayedScrollingRowIndex = CInt(rowIndex)
			Me.DataGridView1.FirstDisplayedScrollingColumnIndex = CInt(colIndex)
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(CInt(rowIndex)).Cells(CInt(colIndex))
		End Sub

		' Token: 0x06003333 RID: 13107 RVA: 0x001FA2B8 File Offset: 0x001F84B8
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				e.IsInputKey = True
				Dim num As Integer = editingControlDataGridView.CurrentCell.RowIndex
				Dim num2 As Integer = editingControlDataGridView.CurrentCell.ColumnIndex
				Dim flag2 As Boolean = num2 = editingControlDataGridView.ColumnCount - 1
				If flag2 Then
					num += 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num2 += 1
				End If
				Dim flag4 As Boolean = TypeOf editingControlDataGridView.CurrentCell Is DataGridViewButtonCell
				If flag4 Then
					Dim name As String = editingControlDataGridView.CurrentCell.OwningColumn.Name
					If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
						Me.DBoperation(num, "Insert")
					End If
				Else
					editingControlDataGridView.BeginEdit(True)
				End If
				While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
					num2 += 1
				End While
				While num2 <= 11 AndAlso num2 < editingControlDataGridView.ColumnCount AndAlso TypeOf editingControlDataGridView.Columns(num2)Is DataGridViewButtonColumn AndAlso Not editingControlDataGridView.Columns(num2).Name.Equals("InsertButtonColumn")
					num2 += 1
				End While
				Dim flag5 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 19
				If flag5 Then
					num2 = 23
				End If
				Dim flag6 As Boolean = num2 < editingControlDataGridView.ColumnCount
				If flag6 Then
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
					Dim flag7 As Boolean = New Integer() { 11, 23, 32 }.Contains(num2)
					If flag7 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x06003334 RID: 13108 RVA: 0x001FA49C File Offset: 0x001F869C
		Public Sub DBoperation(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Insert", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(rowNo)
				Try
					Dim flag2 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("customer_name").Value))) = 0) Or (dataGridViewRow.Cells("customer_name").Value Is Nothing)
					If flag2 Then
						MessageBox.Show("Please enter customer_name ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag3 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("mobileno").Value))) = 0) Or (dataGridViewRow.Cells("mobileno").Value Is Nothing)
						If flag3 Then
							MessageBox.Show("Please enter mobile no. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag4 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("state").Value))) = 0) Or (dataGridViewRow.Cells("state").Value Is Nothing)
							If flag4 Then
								MessageBox.Show("Please enter State ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "select RTRIM(mobile) from tbl_lead_master where mobile=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("mobileno").Value))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag6 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									Me.auto()
									Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
										sqlConnection.Open()
										Dim text2 As String = vbCrLf & "        INSERT INTO tbl_lead_master " & vbCrLf & "        (lead_id, lead_date, customer_name, coordinate_mode, mobile, state, address, interest_mode, productname, remarks, alloted_user) " & vbCrLf & "        VALUES (@lead_id, @lead_date, @customer_name, @coordinate_mode, @mobile, @state, @address, @interest_mode, @productname, @remarks, @alloted_user)" & vbCrLf & "    "
										Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
											Dim nullIfEmpty As Func(Of Object, Object) = Function(val As Object) If(val Is Nothing OrElse val Is DBNull.Value OrElse String.IsNullOrWhiteSpace(val.ToString()), CObj(DBNull.Value), val)
											sqlCommand.Parameters.Add("@lead_id", SqlDbType.Int).Value = Conversion.Val(Me.txtID.Text)
											sqlCommand.Parameters.Add("@lead_date", SqlDbType.DateTime).Value = DateTime.Now
											sqlCommand.Parameters.Add("@customer_name", SqlDbType.NVarChar, 200).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("customer_name").Value)))
											sqlCommand.Parameters.Add("@coordinate_mode", SqlDbType.NVarChar, 50).Value = "OWNER"
											sqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar, 15).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("mobileno").Value)))
											sqlCommand.Parameters.Add("@state", SqlDbType.NVarChar, 100).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("state").Value)))
											sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 300).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("state").Value)))
											sqlCommand.Parameters.Add("@interest_mode", SqlDbType.NVarChar, 20).Value = "HIGH"
											sqlCommand.Parameters.Add("@productname", SqlDbType.NVarChar, 200).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("product_name").Value)))
											sqlCommand.Parameters.Add("@remarks", SqlDbType.NVarChar, 500).Value = RuntimeHelpers.GetObjectValue(nullIfEmpty(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("remarks").Value)))
											sqlCommand.Parameters.Add("@alloted_user", SqlDbType.NVarChar, 100).Value = Me.lblUser.Text
											sqlCommand.ExecuteNonQuery()
										End Using
									End Using
									MessageBox.Show("Successfully Saved", "Lead Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.auto()
									Me.GetLeadData()
									Me.GelButtonNewRecord.Focus()
								End If
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
		End Sub

		' Token: 0x06003335 RID: 13109 RVA: 0x0001FB9F File Offset: 0x0001DD9F
		Private Sub grdState_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_State()
		End Sub

		' Token: 0x06003336 RID: 13110 RVA: 0x001FAA50 File Offset: 0x001F8C50
		Private Sub grdState_KeyDown_1(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_State()
			End If
		End Sub

		' Token: 0x06003337 RID: 13111 RVA: 0x0001FBA9 File Offset: 0x0001DDA9
		Private Sub grdCo_Mode_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_CoMode()
		End Sub

		' Token: 0x06003338 RID: 13112 RVA: 0x001FAA78 File Offset: 0x001F8C78
		Private Sub grdCo_Mode_KeyDown_1(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_CoMode()
			End If
		End Sub

		' Token: 0x06003339 RID: 13113 RVA: 0x0001FBB3 File Offset: 0x0001DDB3
		Private Sub grdIntrest_Mode_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_InterestMode()
		End Sub

		' Token: 0x0600333A RID: 13114 RVA: 0x001FAAA0 File Offset: 0x001F8CA0
		Private Sub grdIntrest_Mode_KeyDown_1(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_InterestMode()
			End If
		End Sub

		' Token: 0x0600333B RID: 13115 RVA: 0x0001FBBD File Offset: 0x0001DDBD
		Private Sub grdProduct_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_Product()
		End Sub

		' Token: 0x0600333C RID: 13116 RVA: 0x001FAAC8 File Offset: 0x001F8CC8
		Private Sub grdProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_Product()
			End If
		End Sub

		' Token: 0x0600333D RID: 13117 RVA: 0x0001FBC7 File Offset: 0x0001DDC7
		Private Sub grdUser_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_User()
		End Sub

		' Token: 0x0600333E RID: 13118 RVA: 0x001FAAF0 File Offset: 0x001F8CF0
		Private Sub grdUser_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_User()
			End If
		End Sub

		' Token: 0x0600333F RID: 13119 RVA: 0x001FAB18 File Offset: 0x001F8D18
		Public Sub RetrieveData_State()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.grdState.SelectedRows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.grdState.SelectedRows(0)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
					If flag2 Then
						Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
						Me.DataGridView1.CurrentCell.Value = text
						Dim flag3 As Boolean = columnIndex + 1 < Me.DataGridView1.ColumnCount
						If flag3 Then
							Dim num As Integer = columnIndex + 1
							While num < Me.DataGridView1.ColumnCount AndAlso Not Me.DataGridView1.Columns(num).Visible
								num += 1
							End While
							Dim flag4 As Boolean = num < Me.DataGridView1.ColumnCount
							If flag4 Then
								Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(rowIndex).Cells(num)
								Me.DataGridView1.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
									Me.DataGridView1.BeginEdit(True)
									Dim editingControl As Control = Me.DataGridView1.EditingControl
									Dim flag5 As Boolean = editingControl IsNot Nothing AndAlso TypeOf editingControl Is TextBox
									If flag5 Then
										Dim textBox As TextBox = CType(editingControl, TextBox)
										textBox.SelectionStart = textBox.Text.Length
										textBox.SelectionLength = 0
										textBox.Focus()
									End If
								End Sub))
							End If
						End If
					End If
					Me.grdState.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003340 RID: 13120 RVA: 0x001FACC4 File Offset: 0x001F8EC4
		Private Sub DGV_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.CurrentCell Is Nothing
			If Not flag Then
				Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
				Dim textBox As TextBox = CType(sender, TextBox)
				Select Case columnIndex
					Case 3
						Dim flag2 As Boolean = textBox.Text.Length > 0
						If flag2 Then
							Me.FilterCoMode(textBox.Text)
							Me.grdCo_Mode.Visible = True
							Me.grdCo_Mode.BringToFront()
							Me.grdCo_Mode.Focus()
						Else
							Me.grdCo_Mode.Visible = False
						End If
						GoTo IL_026F
					Case 5
						Dim flag3 As Boolean = textBox.Text.Length > 0
						If flag3 Then
							Me.FilterStates(textBox.Text)
							Me.grdState.Visible = True
							Me.grdState.BringToFront()
							Me.grdState.Focus()
						Else
							Me.grdState.Visible = False
						End If
						GoTo IL_026F
					Case 7
						Dim flag4 As Boolean = textBox.Text.Length > 0
						If flag4 Then
							Me.FilterInterestMode(textBox.Text)
							Me.grdIntrest_Mode.Visible = True
							Me.grdIntrest_Mode.BringToFront()
							Me.grdIntrest_Mode.Focus()
						Else
							Me.grdIntrest_Mode.Visible = False
						End If
						GoTo IL_026F
					Case 8
						Dim flag5 As Boolean = textBox.Text.Length > 0
						If flag5 Then
							Me.FilterProduct(textBox.Text)
							Me.grdProduct.Visible = True
							Me.grdProduct.BringToFront()
							Me.grdProduct.Focus()
						Else
							Me.grdProduct.Visible = False
						End If
						GoTo IL_026F
					Case 9
						Dim flag6 As Boolean = textBox.Text.Length > 0
						If flag6 Then
							Me.FilterUser(textBox.Text)
							Me.grdUser.Visible = True
							Me.grdUser.BringToFront()
							Me.grdUser.Focus()
						Else
							Me.grdUser.Visible = False
						End If
						GoTo IL_026F
				End Select
				Me.grdState.Visible = False
				Me.grdCo_Mode.Visible = False
				Me.grdIntrest_Mode.Visible = False
				Me.grdProduct.Visible = False
				Me.grdUser.Visible = False
				IL_026F:
			End If
		End Sub

		' Token: 0x06003341 RID: 13121 RVA: 0x001FAF44 File Offset: 0x001F9144
		Private Sub FilterStates(searchText As String)
			' The following expression was wrapped in a checked-statement
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT name as StateName FROM tbl_state " & vbCrLf & "                                   WHERE name LIKE @search ORDER BY name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@search", searchText + "%")
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdState.DataSource = dataTable
							Dim flag As Boolean = dataTable.Rows.Count = 0
							If flag Then
								Dim num As Integer = Me.DataGridView1.Rows.Count - 1
								Dim num2 As Integer = 5
								Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num - 1).Cells(num2)
								Dim num3 As Integer = If(-If((Me.DataGridView1.Rows.Count > 1 > False), 1, 0), 1, 0)
								Me.DataGridView1.Rows(num - 1).Cells(num2).[ReadOnly] = False
								Me.DataGridView1.Rows(num - 1).[ReadOnly] = False
								Me.DataGridView1.BeginEdit(True)
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error filtering states: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003342 RID: 13122 RVA: 0x001FB134 File Offset: 0x001F9334
		Private Sub FilterCoMode(searchText As String)
			Try
				Me.grdCo_Mode.Rows.Clear()
				Dim array As String() = New String() { "Owner", "Salesman", "Accountant", "Manager", "Others" }
				For Each text As String In array
					Dim flag As Boolean = text.ToLower().Contains(searchText.ToLower())
					If flag Then
						Me.grdCo_Mode.Rows.Add(New Object() { text })
					End If
				Next
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003343 RID: 13123 RVA: 0x001FB1F8 File Offset: 0x001F93F8
		Private Sub FilterInterestMode(searchText As String)
			Try
				Me.grdIntrest_Mode.Rows.Clear()
				Dim array As String() = New String() { "Low", "Medium", "High" }
				For Each text As String In array
					Dim flag As Boolean = text.ToLower().Contains(searchText.ToLower())
					If flag Then
						Me.grdIntrest_Mode.Rows.Add(New Object() { text })
					End If
				Next
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003344 RID: 13124 RVA: 0x001FB2AC File Offset: 0x001F94AC
		Private Sub FilterProduct(searchText As String)
			' The following expression was wrapped in a checked-statement
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT product_name AS ProductName " & vbCrLf & "                                   FROM tbl_lead_product " & vbCrLf & "                                   WHERE is_deleted = 0 AND product_name LIKE @search " & vbCrLf & "                                   ORDER BY product_name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@search", searchText + "%")
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdProduct.DataSource = dataTable
							Dim flag As Boolean = dataTable.Rows.Count = 0
							If flag Then
								Dim num As Integer = Me.DataGridView1.Rows.Count - 1
								Dim num2 As Integer = 8
								Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num - 1).Cells(num2)
								Me.DataGridView1.Rows(num - 1).Cells(num2).[ReadOnly] = False
								Me.DataGridView1.Rows(num - 1).[ReadOnly] = False
								Me.DataGridView1.BeginEdit(True)
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error filtering products: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003345 RID: 13125 RVA: 0x001FB484 File Offset: 0x001F9684
		Private Sub FilterUser(searchText As String)
			' The following expression was wrapped in a checked-statement
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT RTRIM(UserID) AS UserName " & vbCrLf & "                                   FROM Registration " & vbCrLf & "                                   WHERE RTRIM(UserType)='Sales Person' and UserID LIKE @search " & vbCrLf & "                                   ORDER BY UserID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@search", searchText + "%")
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.grdUser.DataSource = dataTable
							Dim flag As Boolean = dataTable.Rows.Count = 0
							If flag Then
								Dim num As Integer = Me.DataGridView1.Rows.Count - 1
								Dim num2 As Integer = 9
								Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num - 1).Cells(num2)
								Me.DataGridView1.Rows(num - 1).Cells(num2).[ReadOnly] = False
								Me.DataGridView1.Rows(num - 1).[ReadOnly] = False
								Me.DataGridView1.BeginEdit(True)
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error filtering users: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003346 RID: 13126 RVA: 0x001FB65C File Offset: 0x001F985C
		Private Sub RetrieveData_CoMode()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.grdCo_Mode.SelectedRows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.grdCo_Mode.SelectedRows(0)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
					If flag2 Then
						Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
						Me.DataGridView1.CurrentCell.Value = text
						Dim flag3 As Boolean = columnIndex + 1 < Me.DataGridView1.ColumnCount
						If flag3 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(rowIndex).Cells(columnIndex + 1)
							Me.DataGridView1.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.BeginEdit(True)
								Dim editingControl As Control = Me.DataGridView1.EditingControl
								Dim flag4 As Boolean = editingControl IsNot Nothing AndAlso TypeOf editingControl Is TextBox
								If flag4 Then
									Dim textBox As TextBox = CType(editingControl, TextBox)
									textBox.SelectionStart = textBox.Text.Length
									textBox.SelectionLength = 0
									textBox.Focus()
								End If
							End Sub))
						End If
					End If
					Me.grdCo_Mode.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003347 RID: 13127 RVA: 0x001FB7A4 File Offset: 0x001F99A4
		Private Sub RetrieveData_InterestMode()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.grdIntrest_Mode.SelectedRows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.grdIntrest_Mode.SelectedRows(0)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
					If flag2 Then
						Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
						Me.DataGridView1.CurrentCell.Value = text
						Dim flag3 As Boolean = columnIndex + 1 < Me.DataGridView1.ColumnCount
						If flag3 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(rowIndex).Cells(columnIndex + 1)
							Me.DataGridView1.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.BeginEdit(True)
								Dim editingControl As Control = Me.DataGridView1.EditingControl
								Dim flag4 As Boolean = editingControl IsNot Nothing AndAlso TypeOf editingControl Is TextBox
								If flag4 Then
									Dim textBox As TextBox = CType(editingControl, TextBox)
									textBox.SelectionStart = textBox.Text.Length
									textBox.SelectionLength = 0
									textBox.Focus()
								End If
							End Sub))
						End If
					End If
					Me.grdIntrest_Mode.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003348 RID: 13128 RVA: 0x001FB8EC File Offset: 0x001F9AEC
		Private Sub RetrieveData_Product()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.grdProduct.SelectedRows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.grdProduct.SelectedRows(0)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
					If flag2 Then
						Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
						Me.DataGridView1.CurrentCell.Value = text
						Dim flag3 As Boolean = columnIndex + 1 < Me.DataGridView1.ColumnCount
						If flag3 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(rowIndex).Cells(columnIndex + 1)
							Me.DataGridView1.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.BeginEdit(True)
								Dim editingControl As Control = Me.DataGridView1.EditingControl
								Dim flag4 As Boolean = editingControl IsNot Nothing AndAlso TypeOf editingControl Is TextBox
								If flag4 Then
									Dim textBox As TextBox = CType(editingControl, TextBox)
									textBox.SelectionStart = textBox.Text.Length
									textBox.SelectionLength = 0
									textBox.Focus()
								End If
							End Sub))
						End If
					End If
					Me.grdProduct.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003349 RID: 13129 RVA: 0x001FBA34 File Offset: 0x001F9C34
		Private Sub RetrieveData_User()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.grdUser.SelectedRows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.grdUser.SelectedRows(0)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
					If flag2 Then
						Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
						Me.DataGridView1.CurrentCell.Value = text
						Dim flag3 As Boolean = columnIndex + 1 < Me.DataGridView1.ColumnCount
						If flag3 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(rowIndex).Cells(columnIndex + 1)
							Me.DataGridView1.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.BeginEdit(True)
								Dim editingControl As Control = Me.DataGridView1.EditingControl
								Dim flag4 As Boolean = editingControl IsNot Nothing AndAlso TypeOf editingControl Is TextBox
								If flag4 Then
									Dim textBox As TextBox = CType(editingControl, TextBox)
									textBox.SelectionStart = textBox.Text.Length
									textBox.SelectionLength = 0
									textBox.Focus()
								End If
							End Sub))
						End If
					End If
					Me.grdUser.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600334A RID: 13130 RVA: 0x001FBB7C File Offset: 0x001F9D7C
		Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.RowIndex < 0 OrElse e.ColumnIndex < 0
				If Not flag Then
					Me.grdState.Visible = False
					Me.grdCo_Mode.Visible = False
					Me.grdIntrest_Mode.Visible = False
					Me.grdProduct.Visible = False
					Me.grdUser.Visible = False
					Dim cellDisplayRectangle As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
					Dim point As Point = Me.DataGridView1.PointToScreen(cellDisplayRectangle.Location)
					Dim height As Integer = cellDisplayRectangle.Height
					Dim num As Integer = 0
					Dim flag2 As Boolean = e.ColumnIndex = 5
					If flag2 Then
						Me.grdState.Location = MyBase.PointToClient(New Point(point.X + num, point.Y + height))
						Me.grdState.Visible = True
						Me.grdState.BringToFront()
						Me.grdState.Focus()
						Me.FilterStates("")
					End If
					Dim flag3 As Boolean = e.ColumnIndex = 3
					If flag3 Then
						Me.grdCo_Mode.Location = MyBase.PointToClient(New Point(point.X + num, point.Y + height))
						Me.grdCo_Mode.Visible = True
						Me.grdCo_Mode.BringToFront()
						Me.grdCo_Mode.Focus()
						Me.FilterCoMode("")
					End If
					Dim flag4 As Boolean = e.ColumnIndex = 7
					If flag4 Then
						Me.grdIntrest_Mode.Location = MyBase.PointToClient(New Point(point.X + num, point.Y + height))
						Me.grdIntrest_Mode.Visible = True
						Me.grdIntrest_Mode.BringToFront()
						Me.grdIntrest_Mode.Focus()
						Me.FilterInterestMode("")
					End If
					Dim flag5 As Boolean = e.ColumnIndex = 8
					If flag5 Then
						Me.grdProduct.Location = MyBase.PointToClient(New Point(point.X + num, point.Y + height))
						Me.grdProduct.Visible = True
						Me.grdProduct.BringToFront()
						Me.grdProduct.Focus()
						Me.FilterProduct("")
					End If
					Dim flag6 As Boolean = e.ColumnIndex = 9
					If flag6 Then
						Me.grdUser.Location = MyBase.PointToClient(New Point(point.X + num, point.Y + height))
						Me.grdUser.Visible = True
						Me.grdUser.BringToFront()
						Me.grdUser.Focus()
						Me.FilterUser("")
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in double click: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600334B RID: 13131 RVA: 0x0001FB9F File Offset: 0x0001DD9F
		Private Sub grdState_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.RetrieveData_State()
		End Sub

		' Token: 0x0600334C RID: 13132 RVA: 0x0001FBA9 File Offset: 0x0001DDA9
		Private Sub grdCo_Mode_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.RetrieveData_CoMode()
		End Sub

		' Token: 0x0600334D RID: 13133 RVA: 0x0001FBB3 File Offset: 0x0001DDB3
		Private Sub grdIntrest_Mode_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.RetrieveData_InterestMode()
		End Sub

		' Token: 0x0600334E RID: 13134 RVA: 0x001FBE80 File Offset: 0x001FA080
		Private Sub txtTopResult_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.GetLeadData()
			End If
		End Sub

		' Token: 0x0600334F RID: 13135 RVA: 0x0001FBBD File Offset: 0x0001DDBD
		Private Sub grdProduct_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.RetrieveData_Product()
		End Sub

		' Token: 0x06003350 RID: 13136 RVA: 0x0001FBC7 File Offset: 0x0001DDC7
		Private Sub grdUser_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.RetrieveData_User()
		End Sub

		' Token: 0x06003351 RID: 13137 RVA: 0x001FBEA8 File Offset: 0x001FA0A8
		Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
			Try
				Dim flag As Boolean = e.RowIndex = Me.DataGridView1.NewRowIndex
				If flag Then
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
					Dim dataGridViewCell As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(0)
					Dim dataGridViewCell2 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
					dataGridViewCell.Value = Conversion.Val(Me.txtID.Text)
					Dim flag2 As Boolean = Operators.CompareString(Me.strLead_Id, Me.txtLead_Id.Text, False) <> 0
					If flag2 Then
						Me.strLead_Id = Me.txtLead_Id.Text
						dataGridViewCell2.Value = Me.strLead_Id
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003352 RID: 13138 RVA: 0x0001FBD1 File Offset: 0x0001DDD1
		Public Sub Reset()
			Me.txtTopResult.Text = "5"
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView1.ClearSelection()
			Me.btnShowAll.Focus()
		End Sub

		' Token: 0x06003353 RID: 13139 RVA: 0x0001FC0E File Offset: 0x0001DE0E
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.strLead_Id = ""
			Me.GetLeadData()
		End Sub

		' Token: 0x06003354 RID: 13140 RVA: 0x001FBFDC File Offset: 0x001FA1DC
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLeadGenerateRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLeadGenerateRecord.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmLeadGenerateRecord.ShowDialog()
			MyProject.Forms.frmLeadGenerateRecord.Dispose()
		End Sub

		' Token: 0x06003355 RID: 13141 RVA: 0x001FC04C File Offset: 0x001FA24C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Dim num As Integer = Me.DataGridView1.Columns.Count - 4
					For i As Integer = 0 To num
						Dim dataGridViewColumn As DataGridViewColumn = Me.DataGridView1.Columns(i)
						dataTable.Columns.Add(dataGridViewColumn.Name)
					Next
					Dim num2 As Integer = 0
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = CDbl(num2) >= Conversion.Val(Me.txtTopResult.Text)
							If flag2 Then
								Exit For
							End If
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj2 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj2, DataGridViewCell)
									Dim flag3 As Boolean = dataGridViewCell.ColumnIndex < 11
									If flag3 Then
										dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
							num2 += 1
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag4 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag4 Then
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

		' Token: 0x06003356 RID: 13142 RVA: 0x001FC310 File Offset: 0x001FA510
		Private Sub btnAddProduct_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLead_Product.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLead_Product.Label2.Text = "lead_product"
			MyProject.Forms.frmLead_Product.Reset()
			MyBase.Dispose()
			MyProject.Forms.frmLead_Product.ShowDialog()
		End Sub

		' Token: 0x06003357 RID: 13143 RVA: 0x001FC380 File Offset: 0x001FA580
		Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " " & vbCrLf & "                    id, lead_id,                    " & vbCrLf & "                    customer_name," & vbCrLf & "                    coordinate_mode," & vbCrLf & "                    mobile," & vbCrLf & "                    state," & vbCrLf & "                    address," & vbCrLf & "                    interest_mode," & vbCrLf & "                    productname," & vbCrLf & "                    alloted_user," & vbCrLf & "                    remarks" & vbCrLf & "                    " & vbCrLf & "                 FROM tbl_lead_master where mobile like '%", Me.txtMobile.Text, "%'" & vbCrLf & "                 ORDER BY lead_id DESC" })
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.CommandTimeout = 0
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader("Id"), sqlDataReader("lead_id"), sqlDataReader("customer_name"), sqlDataReader("coordinate_mode"), sqlDataReader("mobile"), sqlDataReader("state"), sqlDataReader("address"), sqlDataReader("interest_mode"), sqlDataReader("productname"), sqlDataReader("alloted_user"), sqlDataReader("remarks") })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.ClearSelection()
				RemoveHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				AddHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
			Catch ex As Exception
				MessageBox.Show("Error loading lead data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x04001620 RID: 5664
		Private strLead_Id As String
	End Class
End Namespace
