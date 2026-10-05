Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000A2 RID: 162
	<DesignerGenerated()>
	Public Partial Class frmCategoryNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001845 RID: 6213 RVA: 0x00012BDE File Offset: 0x00010DDE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000998 RID: 2456
		' (get) Token: 0x06001848 RID: 6216 RVA: 0x00012C08 File Offset: 0x00010E08
		' (set) Token: 0x06001849 RID: 6217 RVA: 0x00109540 File Offset: 0x00107740
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
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000999 RID: 2457
		' (get) Token: 0x0600184A RID: 6218 RVA: 0x00012C12 File Offset: 0x00010E12
		' (set) Token: 0x0600184B RID: 6219 RVA: 0x00012C1C File Offset: 0x00010E1C
		Public Overridable Property Photo As PictureBox

		' Token: 0x1700099A RID: 2458
		' (get) Token: 0x0600184C RID: 6220 RVA: 0x00012C25 File Offset: 0x00010E25
		' (set) Token: 0x0600184D RID: 6221 RVA: 0x00012C2F File Offset: 0x00010E2F
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x1700099B RID: 2459
		' (get) Token: 0x0600184E RID: 6222 RVA: 0x00012C38 File Offset: 0x00010E38
		' (set) Token: 0x0600184F RID: 6223 RVA: 0x001095A0 File Offset: 0x001077A0
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

		' Token: 0x1700099C RID: 2460
		' (get) Token: 0x06001850 RID: 6224 RVA: 0x00012C42 File Offset: 0x00010E42
		' (set) Token: 0x06001851 RID: 6225 RVA: 0x00012C4C File Offset: 0x00010E4C
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700099D RID: 2461
		' (get) Token: 0x06001852 RID: 6226 RVA: 0x00012C55 File Offset: 0x00010E55
		' (set) Token: 0x06001853 RID: 6227 RVA: 0x00012C5F File Offset: 0x00010E5F
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700099E RID: 2462
		' (get) Token: 0x06001854 RID: 6228 RVA: 0x00012C68 File Offset: 0x00010E68
		' (set) Token: 0x06001855 RID: 6229 RVA: 0x00012C72 File Offset: 0x00010E72
		Friend Overridable Property Label17 As Label

		' Token: 0x1700099F RID: 2463
		' (get) Token: 0x06001856 RID: 6230 RVA: 0x00012C7B File Offset: 0x00010E7B
		' (set) Token: 0x06001857 RID: 6231 RVA: 0x00012C85 File Offset: 0x00010E85
		Friend Overridable Property Panel7 As Panel

		' Token: 0x170009A0 RID: 2464
		' (get) Token: 0x06001858 RID: 6232 RVA: 0x00012C8E File Offset: 0x00010E8E
		' (set) Token: 0x06001859 RID: 6233 RVA: 0x00012C98 File Offset: 0x00010E98
		Friend Overridable Property Label19 As Label

		' Token: 0x170009A1 RID: 2465
		' (get) Token: 0x0600185A RID: 6234 RVA: 0x00012CA1 File Offset: 0x00010EA1
		' (set) Token: 0x0600185B RID: 6235 RVA: 0x001095E4 File Offset: 0x001077E4
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

		' Token: 0x170009A2 RID: 2466
		' (get) Token: 0x0600185C RID: 6236 RVA: 0x00012CAB File Offset: 0x00010EAB
		' (set) Token: 0x0600185D RID: 6237 RVA: 0x00012CB5 File Offset: 0x00010EB5
		Friend Overridable Property Label18 As Label

		' Token: 0x170009A3 RID: 2467
		' (get) Token: 0x0600185E RID: 6238 RVA: 0x00012CBE File Offset: 0x00010EBE
		' (set) Token: 0x0600185F RID: 6239 RVA: 0x00012CC8 File Offset: 0x00010EC8
		Friend Overridable Property Label21 As Label

		' Token: 0x170009A4 RID: 2468
		' (get) Token: 0x06001860 RID: 6240 RVA: 0x00012CD1 File Offset: 0x00010ED1
		' (set) Token: 0x06001861 RID: 6241 RVA: 0x00109628 File Offset: 0x00107828
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

		' Token: 0x170009A5 RID: 2469
		' (get) Token: 0x06001862 RID: 6242 RVA: 0x00012CDB File Offset: 0x00010EDB
		' (set) Token: 0x06001863 RID: 6243 RVA: 0x0010966C File Offset: 0x0010786C
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

		' Token: 0x170009A6 RID: 2470
		' (get) Token: 0x06001864 RID: 6244 RVA: 0x00012CE5 File Offset: 0x00010EE5
		' (set) Token: 0x06001865 RID: 6245 RVA: 0x001096B0 File Offset: 0x001078B0
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

		' Token: 0x170009A7 RID: 2471
		' (get) Token: 0x06001866 RID: 6246 RVA: 0x00012CEF File Offset: 0x00010EEF
		' (set) Token: 0x06001867 RID: 6247 RVA: 0x00012CF9 File Offset: 0x00010EF9
		Friend Overridable Property Label1 As Label

		' Token: 0x170009A8 RID: 2472
		' (get) Token: 0x06001868 RID: 6248 RVA: 0x00012D02 File Offset: 0x00010F02
		' (set) Token: 0x06001869 RID: 6249 RVA: 0x00012D0C File Offset: 0x00010F0C
		Friend Overridable Property Button2 As Button

		' Token: 0x170009A9 RID: 2473
		' (get) Token: 0x0600186A RID: 6250 RVA: 0x00012D15 File Offset: 0x00010F15
		' (set) Token: 0x0600186B RID: 6251 RVA: 0x00012D1F File Offset: 0x00010F1F
		Friend Overridable Property Label2 As Label

		' Token: 0x170009AA RID: 2474
		' (get) Token: 0x0600186C RID: 6252 RVA: 0x00012D28 File Offset: 0x00010F28
		' (set) Token: 0x0600186D RID: 6253 RVA: 0x00012D32 File Offset: 0x00010F32
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170009AB RID: 2475
		' (get) Token: 0x0600186E RID: 6254 RVA: 0x00012D3B File Offset: 0x00010F3B
		' (set) Token: 0x0600186F RID: 6255 RVA: 0x00012D45 File Offset: 0x00010F45
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170009AC RID: 2476
		' (get) Token: 0x06001870 RID: 6256 RVA: 0x00012D4E File Offset: 0x00010F4E
		' (set) Token: 0x06001871 RID: 6257 RVA: 0x00012D58 File Offset: 0x00010F58
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x170009AD RID: 2477
		' (get) Token: 0x06001872 RID: 6258 RVA: 0x00012D61 File Offset: 0x00010F61
		' (set) Token: 0x06001873 RID: 6259 RVA: 0x00012D6B File Offset: 0x00010F6B
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x06001874 RID: 6260 RVA: 0x00012D74 File Offset: 0x00010F74
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001875 RID: 6261 RVA: 0x001096F4 File Offset: 0x001078F4
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " id, RTRIM(categoryname) FROM category"
				Dim flag As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag Then
					text += " WHERE RTrim(categoryname) LIKE @search"
				End If
				text += " ORDER BY id DESC"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				Dim flag2 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + Me.txtSearchProduct.Text.Trim() + "%")
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
					Me.dgw.Rows(num).Cells(2).Value = "Update"
					Me.dgw.Rows(num).Cells(3).Value = "Delete"
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag3 As Boolean = Me.dgw.RowCount > 0
				If flag3 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001876 RID: 6262 RVA: 0x00109958 File Offset: 0x00107B58
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

		' Token: 0x06001877 RID: 6263 RVA: 0x001099CC File Offset: 0x00107BCC
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

		' Token: 0x06001878 RID: 6264 RVA: 0x00109A34 File Offset: 0x00107C34
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim flag As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
			If flag Then
				Dim flag2 As Boolean = keyData = Keys.[Return]
				If flag2 Then
					Me.dgw.ClearSelection()
					Dim num As Integer = 1
					Dim num2 As Integer = 1
					Dim flag3 As Boolean = Me.dgw.CurrentCell IsNot Nothing
					If flag3 Then
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
						Dim flag4 As Boolean = keyData = Keys.[Return] AndAlso columnIndex = 3
						If flag4 Then
							Me.DeleteCategory(rowIndex, columnIndex)
							Return True
						End If
						Dim flag5 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 0 AndAlso Me.dgw.CurrentCell.ColumnIndex < 2
						If flag5 Then
							Dim flag6 As Boolean = columnIndex < Me.dgw.Columns.Count
							If flag6 Then
								Me.dgw.Focus()
								Me.dgw.[Select]()
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
							End If
							Return Me.MoveToNextAndClear()
						End If
						Dim flag7 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 2
						If flag7 Then
							Dim flag8 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex).Cells(0).Value, 0, False)
							If Not flag8 Then
								Return True
							End If
							Dim flag9 As Boolean = False
							Me.InsertNewCategory(rowIndex, columnIndex, flag9)
							Dim flag10 As Boolean = flag9
							If flag10 Then
								Dim flag11 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
								If flag11 Then
									Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
								Else
									Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
								End If
								Return Me.MoveToNextAndClear()
							End If
							Return True
						Else
							Select Case keyData
								Case Keys.Left
									Dim flag12 As Boolean = columnIndex > 3
									If flag12 Then
										Dim flag13 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex - num2).Visible
										If flag13 Then
											num2 += 1
										End If
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex - num2)
									Else
										Dim flag14 As Boolean = columnIndex = 3
										If flag14 Then
											Dim flag15 As Boolean = rowIndex > 0
											If flag15 Then
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(15)
											Else
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(1)
											End If
										End If
									End If
									Return Me.MoveToNextAndClear()
								Case Keys.Up
									Dim flag16 As Boolean = rowIndex > 0
									If flag16 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(columnIndex)
										Return Me.MoveToNextAndClear()
									End If
								Case Keys.Right
									Dim flag17 As Boolean = columnIndex < 3
									If flag17 Then
										Dim flag18 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex + num).Visible
										If flag18 Then
											num += 1
										End If
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
									Else
										Dim flag19 As Boolean = columnIndex = 2
										If flag19 Then
											Dim flag20 As Boolean = rowIndex >= Me.dgw.Rows.Count - 1
											If flag20 Then
												Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
											Else
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
											End If
										End If
									End If
									Return Me.MoveToNextAndClear()
								Case Keys.Down
									Dim flag21 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
									If flag21 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
										Return Me.MoveToNextAndClear()
									End If
							End Select
							Dim flag22 As Boolean = Not Me.txtSearchProduct.Focused
							If flag22 Then
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
							End If
						End If
					End If
				End If
			Else
				Dim flag23 As Boolean = keyData = Keys.[Return]
				If flag23 Then
					Dim flag24 As Boolean = Me.dgw.RowCount > 0
					If flag24 Then
						Dim focused As Boolean = Me.txtSearchProduct.Focused
						If focused Then
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						End If
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End If
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x06001879 RID: 6265 RVA: 0x00109FFC File Offset: 0x001081FC
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Tag IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Tag)) >= 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.dgw.ClearSelection()
					Dim r As DataGridViewRow = row
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = r.Cells(1)
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
			newRow.Cells(2).Value = "Save"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(1)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewCategory(rowIndex, columnIndex, flag)
			Me.DeleteCategory(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x0600187B RID: 6267 RVA: 0x0010A1EC File Offset: 0x001083EC
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600187C RID: 6268 RVA: 0x0010A228 File Offset: 0x00108428
		Public Sub InsertNewCategory(RowIndex As Integer, ColumnIndex As Integer, ByRef isUpdate As Boolean)
			Dim flag As Boolean = ColumnIndex = Me.dgw.Columns(2).Index AndAlso RowIndex >= 0
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
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select categoryname from category where categoryname=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(1).Value.ToString().Trim())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
					If flag4 Then
						MessageBox.Show("Category Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag5 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Dim num As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
						Dim text3 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
						Dim value As Object = dataGridViewRow.Cells(2).Value
						Dim text4 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
						Dim text5 As String = "INSERT INTO category (categoryname)" & vbCrLf & "                 VALUES (@Name)"
						Dim text6 As String = "UPDATE category SET" & vbCrLf & "             categoryname=@Name WHERE ID=@ID"
						Dim text7 As String = If((Operators.CompareString(text4, "Save", False) = 0), text5, text6)
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							Using sqlCommand As SqlCommand = New SqlCommand(text7, sqlConnection)
								Dim flag6 As Boolean = Operators.CompareString(text4, "Save", False) <> 0
								If flag6 Then
									sqlCommand.Parameters.AddWithValue("@ID", num)
								End If
								sqlCommand.Parameters.AddWithValue("@Name", text3)
								sqlConnection.Open()
								sqlCommand.ExecuteNonQuery()
							End Using
						End Using
						MessageBox.Show("Record " + If((Operators.CompareString(text4, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag7 As Boolean = Operators.CompareString(text4, "Save", False) = 0
						If flag7 Then
							Me.AddNewRow()
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600187D RID: 6269 RVA: 0x0010A564 File Offset: 0x00108764
		Public Sub DeleteCategory(RowIndex As Integer, ColumnIndex As Integer)
			Dim flag As Boolean = ColumnIndex <> Me.dgw.Columns(3).Index OrElse RowIndex < 0
			If Not flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim num As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))))
				Dim value As Object = dataGridViewRow.Cells(3).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim flag2 As Boolean = Operators.CompareString(text, "Delete", False) <> 0
				If Not flag2 Then
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
					Dim flag3 As Boolean = dialogResult = DialogResult.No
					If Not flag3 Then
						dataGridViewRow.Cells(2).Value = "Save"
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select CategoryName from Category,SubCategory where Category.CategoryName=SubCategory.Category and CategoryName=@name"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@name", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
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
									Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM category WHERE ID=@ID", sqlConnection)
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

		' Token: 0x0600187E RID: 6270 RVA: 0x00012D86 File Offset: 0x00010F86
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x0600187F RID: 6271 RVA: 0x0010A838 File Offset: 0x00108A38
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x06001880 RID: 6272 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x06001881 RID: 6273 RVA: 0x0010A86C File Offset: 0x00108A6C
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001882 RID: 6274 RVA: 0x00012D90 File Offset: 0x00010F90
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001883 RID: 6275 RVA: 0x00012D90 File Offset: 0x00010F90
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Me.Getdata()
		End Sub

		' Token: 0x0400096D RID: 2413
		Public eventSender As Object

		' Token: 0x0400096E RID: 2414
		Private prevCell As DataGridViewCell
	End Class
End Namespace
