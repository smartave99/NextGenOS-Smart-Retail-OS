Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200009C RID: 156
	<DesignerGenerated()>
	Public Partial Class frmSubCategoryNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060017F0 RID: 6128 RVA: 0x000129B4 File Offset: 0x00010BB4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.hideControl = False
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700097F RID: 2431
		' (get) Token: 0x060017F3 RID: 6131 RVA: 0x000129E5 File Offset: 0x00010BE5
		' (set) Token: 0x060017F4 RID: 6132 RVA: 0x00105D98 File Offset: 0x00103F98
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim eventHandler As EventHandler = AddressOf Me.dgw_CurrentCellChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdState_KeyUp
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000980 RID: 2432
		' (get) Token: 0x060017F5 RID: 6133 RVA: 0x000129EF File Offset: 0x00010BEF
		' (set) Token: 0x060017F6 RID: 6134 RVA: 0x000129F9 File Offset: 0x00010BF9
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000981 RID: 2433
		' (get) Token: 0x060017F7 RID: 6135 RVA: 0x00012A02 File Offset: 0x00010C02
		' (set) Token: 0x060017F8 RID: 6136 RVA: 0x00012A0C File Offset: 0x00010C0C
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000982 RID: 2434
		' (get) Token: 0x060017F9 RID: 6137 RVA: 0x00012A15 File Offset: 0x00010C15
		' (set) Token: 0x060017FA RID: 6138 RVA: 0x00105E14 File Offset: 0x00104014
		Private _btnNewSupplier As Button
		Friend Overridable Property btnNewSupplier As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNewSupplier
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._btnNewSupplier
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNewSupplier = value
				button = Me._btnNewSupplier
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000983 RID: 2435
		' (get) Token: 0x060017FB RID: 6139 RVA: 0x00012A1F File Offset: 0x00010C1F
		' (set) Token: 0x060017FC RID: 6140 RVA: 0x00012A29 File Offset: 0x00010C29
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000984 RID: 2436
		' (get) Token: 0x060017FD RID: 6141 RVA: 0x00012A32 File Offset: 0x00010C32
		' (set) Token: 0x060017FE RID: 6142 RVA: 0x00012A3C File Offset: 0x00010C3C
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000985 RID: 2437
		' (get) Token: 0x060017FF RID: 6143 RVA: 0x00012A45 File Offset: 0x00010C45
		' (set) Token: 0x06001800 RID: 6144 RVA: 0x00012A4F File Offset: 0x00010C4F
		Friend Overridable Property Label17 As Label

		' Token: 0x17000986 RID: 2438
		' (get) Token: 0x06001801 RID: 6145 RVA: 0x00012A58 File Offset: 0x00010C58
		' (set) Token: 0x06001802 RID: 6146 RVA: 0x00012A62 File Offset: 0x00010C62
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000987 RID: 2439
		' (get) Token: 0x06001803 RID: 6147 RVA: 0x00012A6B File Offset: 0x00010C6B
		' (set) Token: 0x06001804 RID: 6148 RVA: 0x00012A75 File Offset: 0x00010C75
		Friend Overridable Property Label19 As Label

		' Token: 0x17000988 RID: 2440
		' (get) Token: 0x06001805 RID: 6149 RVA: 0x00012A7E File Offset: 0x00010C7E
		' (set) Token: 0x06001806 RID: 6150 RVA: 0x00105E58 File Offset: 0x00104058
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000989 RID: 2441
		' (get) Token: 0x06001807 RID: 6151 RVA: 0x00012A88 File Offset: 0x00010C88
		' (set) Token: 0x06001808 RID: 6152 RVA: 0x00012A92 File Offset: 0x00010C92
		Friend Overridable Property Label18 As Label

		' Token: 0x1700098A RID: 2442
		' (get) Token: 0x06001809 RID: 6153 RVA: 0x00012A9B File Offset: 0x00010C9B
		' (set) Token: 0x0600180A RID: 6154 RVA: 0x00012AA5 File Offset: 0x00010CA5
		Friend Overridable Property Label21 As Label

		' Token: 0x1700098B RID: 2443
		' (get) Token: 0x0600180B RID: 6155 RVA: 0x00012AAE File Offset: 0x00010CAE
		' (set) Token: 0x0600180C RID: 6156 RVA: 0x00105E9C File Offset: 0x0010409C
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTopResult_TextChanged
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700098C RID: 2444
		' (get) Token: 0x0600180D RID: 6157 RVA: 0x00012AB8 File Offset: 0x00010CB8
		' (set) Token: 0x0600180E RID: 6158 RVA: 0x00105EE0 File Offset: 0x001040E0
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

		' Token: 0x1700098D RID: 2445
		' (get) Token: 0x0600180F RID: 6159 RVA: 0x00012AC2 File Offset: 0x00010CC2
		' (set) Token: 0x06001810 RID: 6160 RVA: 0x00105F24 File Offset: 0x00104124
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchProduct_TextChanged
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700098E RID: 2446
		' (get) Token: 0x06001811 RID: 6161 RVA: 0x00012ACC File Offset: 0x00010CCC
		' (set) Token: 0x06001812 RID: 6162 RVA: 0x00012AD6 File Offset: 0x00010CD6
		Friend Overridable Property Label1 As Label

		' Token: 0x1700098F RID: 2447
		' (get) Token: 0x06001813 RID: 6163 RVA: 0x00012ADF File Offset: 0x00010CDF
		' (set) Token: 0x06001814 RID: 6164 RVA: 0x00012AE9 File Offset: 0x00010CE9
		Friend Overridable Property Button2 As Button

		' Token: 0x17000990 RID: 2448
		' (get) Token: 0x06001815 RID: 6165 RVA: 0x00012AF2 File Offset: 0x00010CF2
		' (set) Token: 0x06001816 RID: 6166 RVA: 0x00012AFC File Offset: 0x00010CFC
		Friend Overridable Property Label2 As Label

		' Token: 0x17000991 RID: 2449
		' (get) Token: 0x06001817 RID: 6167 RVA: 0x00012B05 File Offset: 0x00010D05
		' (set) Token: 0x06001818 RID: 6168 RVA: 0x00012B0F File Offset: 0x00010D0F
		Friend Overridable Property lblId As Label

		' Token: 0x17000992 RID: 2450
		' (get) Token: 0x06001819 RID: 6169 RVA: 0x00012B18 File Offset: 0x00010D18
		' (set) Token: 0x0600181A RID: 6170 RVA: 0x00012B22 File Offset: 0x00010D22
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000993 RID: 2451
		' (get) Token: 0x0600181B RID: 6171 RVA: 0x00012B2B File Offset: 0x00010D2B
		' (set) Token: 0x0600181C RID: 6172 RVA: 0x00012B35 File Offset: 0x00010D35
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000994 RID: 2452
		' (get) Token: 0x0600181D RID: 6173 RVA: 0x00012B3E File Offset: 0x00010D3E
		' (set) Token: 0x0600181E RID: 6174 RVA: 0x00012B48 File Offset: 0x00010D48
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000995 RID: 2453
		' (get) Token: 0x0600181F RID: 6175 RVA: 0x00012B51 File Offset: 0x00010D51
		' (set) Token: 0x06001820 RID: 6176 RVA: 0x00012B5B File Offset: 0x00010D5B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000996 RID: 2454
		' (get) Token: 0x06001821 RID: 6177 RVA: 0x00012B64 File Offset: 0x00010D64
		' (set) Token: 0x06001822 RID: 6178 RVA: 0x00012B6E File Offset: 0x00010D6E
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x17000997 RID: 2455
		' (get) Token: 0x06001823 RID: 6179 RVA: 0x00012B77 File Offset: 0x00010D77
		' (set) Token: 0x06001824 RID: 6180 RVA: 0x00012B81 File Offset: 0x00010D81
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x06001825 RID: 6181 RVA: 0x00012B8A File Offset: 0x00010D8A
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001826 RID: 6182 RVA: 0x00105F68 File Offset: 0x00104168
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.hideControl
				Dim text As String
				If flag Then
					text = "SELECT id,RTRIM(SubCategoryName), RTRIM(Category), IsDefault from SubCategory "
				Else
					text = "SELECT TOP " + Me.txtTopResult.Text + " id,RTRIM(SubCategoryName), RTRIM(Category), IsDefault from SubCategory "
				End If
				Dim flag2 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag2 Then
					text += " WHERE RTrim(SubCategoryName) LIKE @search"
				End If
				text += " ORDER BY id DESC"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				Dim flag3 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag3 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + Me.txtSearchProduct.Text.Trim() + "%")
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text2 As String = "Yes"
					Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "0", False)
					If flag4 Then
						text2 = "No"
					End If
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), text2 })
					Me.dgw.Rows(num).Cells(4).Value = "Update"
					Me.dgw.Rows(num).Cells(5).Value = "Delete"
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag5 As Boolean = Me.hideControl AndAlso Me.dgw.RowCount = 1
				If flag5 Then
					Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
					Me.dgw.MultiSelect = False
				End If
				Dim flag6 As Boolean = Me.dgw.RowCount > 0
				If flag6 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001827 RID: 6183 RVA: 0x00106264 File Offset: 0x00104464
		Private Sub dgw_CurrentCellChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.prevCell IsNot Nothing
			If flag Then
				Me.prevCell.Style.BackColor = Color.White
			End If
			Dim flag2 As Boolean = Me.dgw.CurrentCell IsNot Nothing
			If flag2 Then
				Me.dgw.CurrentCell.Style.BackColor = Color.Yellow
				Me.prevCell = Me.dgw.CurrentCell
			End If
		End Sub

		' Token: 0x06001828 RID: 6184 RVA: 0x001062D8 File Offset: 0x001044D8
		Public Function MoveToNextAndClear() As Boolean
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				textBox.SelectionStart = 0
				textBox.SelectionLength = textBox.Text.Length
				Application.DoEvents()
			End If
			Return True
		End Function

		' Token: 0x06001829 RID: 6185 RVA: 0x00106340 File Offset: 0x00104540
		Private Sub grdState_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.txtSearchProduct.[Select](Me.txtSearchProduct.Text.Length, 0)
				Me.txtSearchProduct.Focus()
				Me.txtSearchProduct.ScrollToCaret()
				Me.txtSearchProduct.Text = ""
			Else
				Me.txtSearchProduct.[Select](Me.txtSearchProduct.Text.Length, 0)
				Me.txtSearchProduct.Focus()
				Me.txtSearchProduct.ScrollToCaret()
			End If
		End Sub

		' Token: 0x0600182A RID: 6186 RVA: 0x001063DC File Offset: 0x001045DC
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim focused As Boolean = Me.txtSearchProduct.Focused
			If focused Then
				Dim flag As Boolean = keyData = Keys.Down
				If flag Then
					Dim flag2 As Boolean = Me.dgw.Rows.Count = 0
					If flag2 Then
						Return True
					End If
					Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
					Me.dgw.MultiSelect = False
					Me.dgw.ClearSelection()
					Dim flag3 As Boolean = Me.dgw.CurrentCell Is Nothing
					If flag3 Then
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Else
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim flag4 As Boolean = rowIndex = Me.dgw.Rows.Count - 1
						If flag4 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
						End If
					End If
					Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Selected = True
					Me.dgw.Focus()
					Return True
				Else
					Dim flag5 As Boolean = keyData = Keys.Up
					If flag5 Then
						Dim flag6 As Boolean = Me.dgw.Rows.Count = 0
						If flag6 Then
							Return True
						End If
						Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
						Me.dgw.MultiSelect = False
						Me.dgw.ClearSelection()
						Dim flag7 As Boolean = Me.dgw.CurrentCell Is Nothing
						If flag7 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.Rows.Count - 1).Cells(1)
						Else
							Dim rowIndex2 As Integer = Me.dgw.CurrentCell.RowIndex
							Dim flag8 As Boolean = rowIndex2 = 0
							If flag8 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.Rows.Count - 1).Cells(1)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex2 - 1).Cells(1)
							End If
						End If
						Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Selected = True
						Me.dgw.Focus()
						Return True
					Else
						Dim flag9 As Boolean = keyData = Keys.Escape
						If flag9 Then
							Me.txtSearchProduct.Text = ""
							Me.txtSearchProduct.Focus()
							Me.txtSearchProduct.SelectionStart = 0
							Return True
						End If
						Dim flag10 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell IsNot Nothing
						If Not flag10 Then
							Return MyBase.ProcessCmdKey(msg, keyData)
						End If
					End If
				End If
			End If
			Dim flag11 As Boolean = Me.dgw.CurrentCell Is Nothing
			Dim flag12 As Boolean
			If flag11 Then
				flag12 = True
			Else
				Dim flag13 As Boolean = Me.hideControl AndAlso Me.dgw.CurrentCell IsNot Nothing
				If flag13 Then
					Dim flag14 As Boolean = keyData = Keys.Down
					If flag14 Then
						Dim flag15 As Boolean = Me.dgw.CurrentCell.RowIndex < Me.dgw.RowCount - 1
						If flag15 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex + 1).Cells(1)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						End If
					Else
						Dim flag16 As Boolean = keyData = Keys.Up
						If flag16 Then
							Dim flag17 As Boolean = Me.dgw.CurrentCell.RowIndex > 0
							If flag17 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex - 1).Cells(1)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.RowCount - 1).Cells(1)
							End If
						Else
							Dim flag18 As Boolean = keyData = Keys.[Return]
							If flag18 Then
								Dim flag19 As Boolean = TypeOf MyBase.Owner Is frmProductSmart
								If flag19 Then
									Dim frmProductSmart As frmProductSmart = CType(MyBase.Owner, frmProductSmart)
									Dim text As String = Me.dgw.CurrentRow.Cells(0).Value.ToString().Trim()
									Dim text2 As String = Me.dgw.CurrentRow.Cells(1).Value.ToString().Trim()
									Dim text3 As String = Me.dgw.CurrentRow.Cells(2).Value.ToString().Trim()
									frmProductSmart.UpdateCatAndSubCategoryName(Me.currentRow, Me.currentColumn, Conversions.ToInteger(text), text2, text3)
									MyBase.Dispose()
								End If
							End If
						End If
					End If
					flag12 = True
				Else
					Dim flag20 As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
					If flag20 Then
						Me.dgw.ClearSelection()
						Dim num As Integer = 1
						Dim num2 As Integer = 1
						Dim flag21 As Boolean = Me.dgw.CurrentCell IsNot Nothing
						If flag21 Then
							Dim rowIndex3 As Integer = Me.dgw.CurrentCell.RowIndex
							Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
							Dim flag22 As Boolean = keyData = Keys.[Return] AndAlso columnIndex = 5
							If flag22 Then
								Me.DeleteCategory(rowIndex3, columnIndex)
								Return True
							End If
							Dim flag23 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 0 AndAlso Me.dgw.CurrentCell.ColumnIndex < 4
							If flag23 Then
								Dim flag24 As Boolean = columnIndex = 3 AndAlso msg.Msg > 0
								If flag24 Then
									Me.dgw.EndEdit()
									Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
									Me.dgw.Refresh()
									Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(rowIndex3)
									MyProject.Forms.frmYesNo.currentRow = rowIndex3
									MyProject.Forms.frmYesNo.currentColumn = columnIndex
									MyProject.Forms.frmYesNo.Owner = Me
									MyProject.Forms.frmYesNo.ShowDialog()
									Return True
								End If
								Dim flag25 As Boolean = columnIndex = 2 AndAlso msg.Msg > 0
								If flag25 Then
									Me.dgw.EndEdit()
									Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
									Me.dgw.Refresh()
									Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(rowIndex3)
									MyProject.Forms.frmCategoryPopup.currentRow = rowIndex3
									MyProject.Forms.frmCategoryPopup.currentColumn = columnIndex
									MyProject.Forms.frmCategoryPopup.Owner = Me
									MyProject.Forms.frmCategoryPopup.ShowDialog()
									MyBase.DialogResult = DialogResult.OK
									MyBase.Close()
									Return True
								End If
								Dim flag26 As Boolean = columnIndex < Me.dgw.Columns.Count
								If flag26 Then
									Me.dgw.Focus()
									Me.dgw.[Select]()
									Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
								End If
								Return Me.MoveToNextAndClear()
							Else
								Dim flag27 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 4
								If flag27 Then
									Dim flag28 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex3).Cells(0).Value, 0, False)
									If Not flag28 Then
										Return True
									End If
									Dim flag29 As Boolean = False
									Me.InsertNewSubCategory(rowIndex3, columnIndex, flag29)
									Dim flag30 As Boolean = flag29
									If flag30 Then
										Dim flag31 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
										If flag31 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(1)
										Else
											Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
										End If
										Return Me.MoveToNextAndClear()
									End If
									Return True
								Else
									If keyData <= Keys.Right Then
										If keyData = Keys.Left Then
											Dim flag32 As Boolean = columnIndex > 5
											If flag32 Then
												Dim flag33 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2).Visible
												If flag33 Then
													num2 += 1
												End If
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2)
											Else
												Dim flag34 As Boolean = columnIndex = 5
												If flag34 Then
													Dim flag35 As Boolean = rowIndex3 > 0
													If flag35 Then
														Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(15)
													Else
														Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(1)
													End If
												End If
											End If
											Return Me.MoveToNextAndClear()
										End If
										If keyData = Keys.Right Then
											Dim flag36 As Boolean = columnIndex < 5
											If flag36 Then
												Dim flag37 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex + num).Visible
												If flag37 Then
													num += 1
												End If
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
											Else
												Dim flag38 As Boolean = columnIndex = 4
												If flag38 Then
													Dim flag39 As Boolean = rowIndex3 >= Me.dgw.Rows.Count - 1
													If flag39 Then
														Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
													Else
														Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(1)
													End If
												End If
											End If
											Return Me.MoveToNextAndClear()
										End If
									ElseIf keyData <> Keys.VolumeDown Then
										If keyData = Keys.VolumeUp Then
											Dim flag40 As Boolean = rowIndex3 > 0
											If flag40 Then
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(columnIndex)
												Return Me.MoveToNextAndClear()
											End If
										End If
									Else
										Dim flag41 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
										If flag41 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
									End If
									Dim flag42 As Boolean = Not Me.txtSearchProduct.Focused
									If flag42 Then
										Me.dgw.BeginEdit(True)
										Me.dgw.ClearSelection()
									End If
								End If
							End If
						End If
					Else
						Dim flag43 As Boolean = keyData = Keys.[Return]
						If flag43 Then
							Dim flag44 As Boolean = Me.dgw.RowCount > 0
							If flag44 Then
								Dim focused2 As Boolean = Me.txtSearchProduct.Focused
								If focused2 Then
									Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
								End If
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
							End If
						End If
					End If
					flag12 = MyBase.ProcessCmdKey(msg, keyData)
				End If
			End If
			Return flag12
		End Function

		' Token: 0x0600182B RID: 6187 RVA: 0x0010709C File Offset: 0x0010529C
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Tag IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Tag)) >= 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.dgw.ClearSelection()
					MyBase.BeginInvoke(New MethodInvoker(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = row.Cells(1)
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End Sub))
					Return
				End If
			Next
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(3).Value = ""
			newRow.Cells(4).Value = "Save"
			Me.lblId.Text = "0"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New MethodInvoker(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(1)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600182C RID: 6188 RVA: 0x0010729C File Offset: 0x0010549C
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSubCategory(rowIndex, columnIndex, flag)
			Me.DeleteCategory(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x0600182D RID: 6189 RVA: 0x001072D4 File Offset: 0x001054D4
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600182E RID: 6190 RVA: 0x00107310 File Offset: 0x00105510
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.lblId.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.lblId.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600182F RID: 6191 RVA: 0x00107414 File Offset: 0x00105614
		Public Sub InsertNewSubCategory(RowIndex As Integer, ColumnIndex As Integer, ByRef isUpdate As Boolean)
			Dim flag As Boolean = ColumnIndex = Me.dgw.Columns(4).Index AndAlso RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(1).Value.ToString())) = 0
					If flag4 Then
						MessageBox.Show("Please enter sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						NewLateBinding.LateCall(NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
					Else
						Dim flag5 As Boolean = dataGridViewRow.Cells(2) Is Nothing
						If flag5 Then
							Dim flag6 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(2).Value.ToString())) = 0
							If flag6 Then
								MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								NewLateBinding.LateCall(dataGridViewRow.Cells(2).Value, Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
								Return
							End If
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select SubCategoryName,Category from SubCategory where SubCategoryName=@d1 and Category=@d2"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(1).Value.ToString().Trim())
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(2).Value.ToString().Trim())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
						If flag7 Then
							MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag8 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Dim flag9 As Boolean = Operators.CompareString(dataGridViewRow.Cells(3).Value.ToString().Trim(), "Yes", False) = 0
							If flag9 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select IsDefault from SubCategory where IsDefault='Yes'"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
								If flag10 Then
									MessageBox.Show("Sub Category is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag11 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag11 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
							End If
							Me.auto()
							Dim value As Object = dataGridViewRow.Cells(4).Value
							Dim text4 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If((Operators.CompareString(text4, "Save", False) <> 0), Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), Me.lblId.Text))
							Dim text5 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
							Dim text6 As String = (If(dataGridViewRow.Cells(2).Value, "")).ToString().Trim()
							Dim flag12 As Boolean = False
							Dim flag13 As Boolean = Operators.CompareString(New ValueTuple(Of Object, String)(dataGridViewRow.Cells(3).Value, "").ToString().Trim(), "Yes", False) = 0
							If flag13 Then
								flag12 = True
							End If
							Dim text7 As String = "insert into SubCategory(SubCategoryName,Category,ID, IsDefault) VALUES (@d1,@d2, @ID,@d3)"
							Dim text8 As String = "update SubCategory set SubCategoryName=@d1,Category=@d2, IsDefault=@d3 where ID= @ID"
							Dim text9 As String = If((Operators.CompareString(text4, "Save", False) = 0), text7, text8)
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								Using sqlCommand As SqlCommand = New SqlCommand(text9, sqlConnection)
									Dim flag14 As Boolean = Operators.CompareString(text4, "Save", False) <> 0
									If flag14 Then
										sqlCommand.Parameters.AddWithValue("@ID", RuntimeHelpers.GetObjectValue(objectValue))
									End If
									sqlCommand.Parameters.AddWithValue("@ID", RuntimeHelpers.GetObjectValue(objectValue))
									sqlCommand.Parameters.AddWithValue("@d1", text5)
									sqlCommand.Parameters.AddWithValue("@d2", text6)
									sqlCommand.Parameters.AddWithValue("@d3", flag12)
									sqlConnection.Open()
									sqlCommand.ExecuteNonQuery()
								End Using
							End Using
							MessageBox.Show("Record " + If((Operators.CompareString(text4, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag15 As Boolean = Operators.CompareString(text4, "Save", False) = 0
							If flag15 Then
								Me.AddNewRow()
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06001830 RID: 6192 RVA: 0x00107A24 File Offset: 0x00105C24
		Public Sub DeleteCategory(RowIndex As Integer, ColumnIndex As Integer)
			Dim flag As Boolean = ColumnIndex <> Me.dgw.Columns(5).Index OrElse RowIndex < 0
			If Not flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim num As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))))
				Dim value As Object = dataGridViewRow.Cells(5).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim flag2 As Boolean = Operators.CompareString(text, "Delete", False) <> 0
				If Not flag2 Then
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this Record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
					Dim flag3 As Boolean = dialogResult = DialogResult.No
					If Not flag3 Then
						dataGridViewRow.Cells(4).Value = "Save"
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select SubCategoryID from Product,SubCategory where Product.SubCategoryID=SubCategory.ID and SubCategoryID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Unable to delete..Already in use in Sub Category Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
									Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM SubCategory WHERE ID=@ID", sqlConnection)
										sqlCommand.Parameters.AddWithValue("@ID", num)
										sqlConnection.Open()
										Dim num2 As Integer = sqlCommand.ExecuteNonQuery()
										Dim flag6 As Boolean = num2 > 0
										If flag6 Then
											MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.Getdata()
											Me.Reset()
										Else
											MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.Reset()
										End If
									End Using
								End Using
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06001831 RID: 6193 RVA: 0x00012B9C File Offset: 0x00010D9C
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x06001832 RID: 6194 RVA: 0x00107CF8 File Offset: 0x00105EF8
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x06001833 RID: 6195 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x06001834 RID: 6196 RVA: 0x00107D2C File Offset: 0x00105F2C
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001835 RID: 6197 RVA: 0x00012BA6 File Offset: 0x00010DA6
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001836 RID: 6198 RVA: 0x00012BA6 File Offset: 0x00010DA6
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Me.Getdata()
		End Sub

		' Token: 0x06001837 RID: 6199 RVA: 0x00107D68 File Offset: 0x00105F68
		Friend Async Sub UpdateYesNo(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			Dim flag As Boolean = nextCol < Me.dgw.Columns.Count
			If flag Then
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(nextCol)
			End If
			Me.dgw.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim editingControl As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			If editingControl IsNot Nothing Then
				editingControl.SelectionStart = 0
				editingControl.SelectionLength = editingControl.Text.Length
			End If
		End Sub

		' Token: 0x06001838 RID: 6200 RVA: 0x00107DB8 File Offset: 0x00105FB8
		Public Sub UpdateCategoryName(currentRow As Integer, currentColumn As Integer, selectedState As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = ""
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedState
			Me.dgw.EndEdit()
			Me.dgw.RefreshEdit()
			Me.dgw.Invalidate()
			Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(currentColumn + 1)
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(3)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x06001839 RID: 6201 RVA: 0x00107EA0 File Offset: 0x001060A0
		Public Sub HideControls(isHide As Boolean, currentSearch As String)
			Me.hideControl = isHide
			If isHide Then
				Dim flag As Boolean = Not String.IsNullOrEmpty(currentSearch)
				If flag Then
					Me.txtSearchProduct.Text = currentSearch
					Me.txtSearchProduct.Focus()
					Me.txtSearchProduct.[Select]()
					Me.txtSearchProduct.SelectAll()
				End If
				Me.Label19.Visible = False
				Me.chkSelectAll.Visible = False
				Me.Label21.Visible = False
				Me.txtTopResult.Visible = False
				Me.Label18.Visible = False
				Me.btnNewSupplier.Visible = False
				Me.Button2.Visible = False
				Me.Button1.Visible = False
				Me.dgw.Columns(3).Visible = False
				Me.dgw.Columns(4).Visible = False
				Me.dgw.Columns(5).Visible = False
			End If
		End Sub

		' Token: 0x0400093F RID: 2367
		Public currentRow As Integer

		' Token: 0x04000940 RID: 2368
		Public currentColumn As Integer

		' Token: 0x04000941 RID: 2369
		Public eventSender As Object

		' Token: 0x04000942 RID: 2370
		Public hideControl As Boolean

		' Token: 0x04000943 RID: 2371
		Private prevCell As DataGridViewCell
	End Class
End Namespace
