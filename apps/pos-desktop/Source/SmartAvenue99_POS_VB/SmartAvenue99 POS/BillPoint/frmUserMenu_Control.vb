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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000211 RID: 529
	<DesignerGenerated()>
	Public Partial Class frmUserMenu_Control
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009926 RID: 39206 RVA: 0x0004ACC6 File Offset: 0x00048EC6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmUserMenu_Control_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038E1 RID: 14561
		' (get) Token: 0x06009929 RID: 39209 RVA: 0x0004ACE6 File Offset: 0x00048EE6
		' (set) Token: 0x0600992A RID: 39210 RVA: 0x006DFE54 File Offset: 0x006DE054
		Private _dgvMenu As DataGridView
		Friend Overridable Property dgvMenu As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgvMenu
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgvMenu_CellContentClick
				Dim dataGridView As DataGridView = Me._dgvMenu
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgvMenu = value
				dataGridView = Me._dgvMenu
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170038E2 RID: 14562
		' (get) Token: 0x0600992B RID: 39211 RVA: 0x0004ACF0 File Offset: 0x00048EF0
		' (set) Token: 0x0600992C RID: 39212 RVA: 0x0004ACFA File Offset: 0x00048EFA
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170038E3 RID: 14563
		' (get) Token: 0x0600992D RID: 39213 RVA: 0x0004AD03 File Offset: 0x00048F03
		' (set) Token: 0x0600992E RID: 39214 RVA: 0x0004AD0D File Offset: 0x00048F0D
		Friend Overridable Property btnUpdate As GelButton

		' Token: 0x170038E4 RID: 14564
		' (get) Token: 0x0600992F RID: 39215 RVA: 0x0004AD16 File Offset: 0x00048F16
		' (set) Token: 0x06009930 RID: 39216 RVA: 0x0004AD20 File Offset: 0x00048F20
		Friend Overridable Property btnDelete As GelButton

		' Token: 0x170038E5 RID: 14565
		' (get) Token: 0x06009931 RID: 39217 RVA: 0x0004AD29 File Offset: 0x00048F29
		' (set) Token: 0x06009932 RID: 39218 RVA: 0x0004AD33 File Offset: 0x00048F33
		Friend Overridable Property btnNew As GelButton

		' Token: 0x170038E6 RID: 14566
		' (get) Token: 0x06009933 RID: 39219 RVA: 0x0004AD3C File Offset: 0x00048F3C
		' (set) Token: 0x06009934 RID: 39220 RVA: 0x0004AD46 File Offset: 0x00048F46
		Friend Overridable Property btnSave As GelButton

		' Token: 0x170038E7 RID: 14567
		' (get) Token: 0x06009935 RID: 39221 RVA: 0x0004AD4F File Offset: 0x00048F4F
		' (set) Token: 0x06009936 RID: 39222 RVA: 0x006DFE98 File Offset: 0x006DE098
		Private _cmbUserID As ComboBox
		Friend Overridable Property cmbUserID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbUserID_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbUserID = value
				comboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038E8 RID: 14568
		' (get) Token: 0x06009937 RID: 39223 RVA: 0x0004AD59 File Offset: 0x00048F59
		' (set) Token: 0x06009938 RID: 39224 RVA: 0x006DFEDC File Offset: 0x006DE0DC
		Private _cboxCategory As ComboBox
		Friend Overridable Property cboxCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cboxCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cboxCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cboxCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cboxCategory = value
				comboBox = Me._cboxCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038E9 RID: 14569
		' (get) Token: 0x06009939 RID: 39225 RVA: 0x0004AD63 File Offset: 0x00048F63
		' (set) Token: 0x0600993A RID: 39226 RVA: 0x0004AD6D File Offset: 0x00048F6D
		Friend Overridable Property Label2 As Label

		' Token: 0x170038EA RID: 14570
		' (get) Token: 0x0600993B RID: 39227 RVA: 0x0004AD76 File Offset: 0x00048F76
		' (set) Token: 0x0600993C RID: 39228 RVA: 0x0004AD80 File Offset: 0x00048F80
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170038EB RID: 14571
		' (get) Token: 0x0600993D RID: 39229 RVA: 0x0004AD89 File Offset: 0x00048F89
		' (set) Token: 0x0600993E RID: 39230 RVA: 0x0004AD93 File Offset: 0x00048F93
		Friend Overridable Property Label1 As Label

		' Token: 0x0600993F RID: 39231 RVA: 0x0004AD9C File Offset: 0x00048F9C
		Private Sub frmUserMenu_Control_Load(sender As Object, e As EventArgs)
			Me.FillUserID()
			Me.LoadMenuData()
			Me.BindMenuCatgory()
		End Sub

		' Token: 0x06009940 RID: 39232 RVA: 0x006DFF20 File Offset: 0x006DE120
		Public Sub BindMenuCatgory()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "SELECT id, category_name FROM tbl_master_menu_header ORDER BY orderby"
			Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
			Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
			Me.cboxCategory.Items.Clear()
			While sqlDataReader.Read()
				Me.cboxCategory.Items.Add(New KeyValuePair(Of Integer, String)(Conversions.ToInteger(sqlDataReader("id")), sqlDataReader("category_name").ToString()))
			End While
			sqlDataReader.Close()
			sqlConnection.Close()
			Me.cboxCategory.DisplayMember = "Value"
			Me.cboxCategory.ValueMember = "Key"
		End Sub

		' Token: 0x06009941 RID: 39233 RVA: 0x006DFFE0 File Offset: 0x006DE1E0
		Public Sub FillUserID()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT DISTINCT RTRIM(UserID) AS UserID, RTRIM(UserType) AS UserType FROM Registration WHERE UserType NOT IN ('*****') ORDER BY UserID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim dataTable As DataTable = New DataTable()
							dataTable.Load(sqlDataReader)
							Me.cmbUserID.DataSource = dataTable
							Me.cmbUserID.DisplayMember = "UserID"
							Me.cmbUserID.ValueMember = "UserType"
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009942 RID: 39234 RVA: 0x006E00E0 File Offset: 0x006DE2E0
		Private Sub cmbUserID_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbUserID.SelectedIndex <> -1
			If flag Then
				Dim text As String = Me.cmbUserID.SelectedValue.ToString()
				Dim num As Integer = 0
				Do
					Me.SetColumnState(num, False)
					num += 1
				Loop While num <= 3
				If Operators.CompareString(text, "Admin", False) <> 0 Then
					If Operators.CompareString(text, "Moderator", False) <> 0 Then
						If Operators.CompareString(text, "Sales Person", False) <> 0 Then
							If Operators.CompareString(text, "Inventory Manager", False) = 0 Then
								Me.SetColumnState(3, True)
							End If
						Else
							Me.SetColumnState(2, True)
						End If
					Else
						Me.SetColumnState(1, True)
					End If
				Else
					Me.SetColumnState(0, True)
				End If
				Dim flag2 As Boolean = Me.cboxCategory.SelectedItem Is Nothing
				If Not flag2 Then
					Dim selectedItem As Object = Me.cboxCategory.SelectedItem
					Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
					Me.Bindgrid(value)
				End If
			End If
		End Sub

		' Token: 0x06009943 RID: 39235 RVA: 0x006E01E4 File Offset: 0x006DE3E4
		Private Sub SetColumnState(colIndex As Integer, enabled As Boolean)
			Dim flag As Boolean = colIndex < 0 OrElse colIndex >= Me.dgvMenu.Columns.Count
			If Not flag Then
				Me.dgvMenu.Columns(colIndex).[ReadOnly] = Not enabled
				If enabled Then
					Me.dgvMenu.Columns(colIndex).DefaultCellStyle.BackColor = Color.White
					Me.dgvMenu.Columns(colIndex).DefaultCellStyle.ForeColor = Color.Black
				Else
					Me.dgvMenu.Columns(colIndex).DefaultCellStyle.BackColor = Color.LightGray
					Me.dgvMenu.Columns(colIndex).DefaultCellStyle.ForeColor = Color.DarkGray
				End If
				Dim flag2 As Boolean = TypeOf Me.dgvMenu.Columns(colIndex)Is DataGridViewCheckBoxColumn
				If flag2 Then
					Try
						For Each obj As Object In CType(Me.dgvMenu.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							dataGridViewRow.Cells(colIndex).[ReadOnly] = Not enabled
							Dim flag3 As Boolean = Not enabled
							If flag3 Then
								dataGridViewRow.Cells(colIndex).Value = False
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x06009944 RID: 39236 RVA: 0x006E0374 File Offset: 0x006DE574
		Private Sub LoadMenuData()
			Try
				Dim text As String = "SELECT for_Admin,for_Moderator, for_SalesPerson, for_InventoryManager, id, category_name, sub_category_name FROM tbl_master_menu ORDER BY category_name ASC"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						Me.dgvMenu.DataSource = dataTable
						Me.GroupDataByCategory()
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009945 RID: 39237 RVA: 0x006E0438 File Offset: 0x006DE638
		Private Sub GroupDataByCategory()
			Dim text As String = ""
			Try
				Try
					For Each obj As Object In CType(Me.dgvMenu.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim text2 As String = dataGridViewRow.Cells("category_name").Value.ToString()
						Dim flag As Boolean = Operators.CompareString(text2, text, False) <> 0
						If flag Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.LightGray
							dataGridViewRow.DefaultCellStyle.Font = New Font(Me.dgvMenu.Font, FontStyle.Bold)
							text = text2
						End If
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

		' Token: 0x06009946 RID: 39238 RVA: 0x006E0534 File Offset: 0x006DE734
		Private Sub dgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex >= 0 AndAlso TypeOf Me.dgvMenu.Columns(e.ColumnIndex)Is DataGridViewCheckBoxColumn
			If flag Then
				Dim [readOnly] As Boolean = Me.dgvMenu.Columns(e.ColumnIndex).[ReadOnly]
				If [readOnly] Then
					Me.dgvMenu.CancelEdit()
				Else
					Dim dataGridViewRow As DataGridViewRow = Me.dgvMenu.Rows(e.RowIndex)
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))
					Dim name As String = Me.dgvMenu.Columns(e.ColumnIndex).Name
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(e.ColumnIndex).Value)
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)) AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(objectValue))
					dataGridViewRow.Cells(e.ColumnIndex).Value = Not flag2
					Me.UpdateDatabase(num, name, Not flag2)
				End If
			End If
		End Sub

		' Token: 0x06009947 RID: 39239 RVA: 0x006E0664 File Offset: 0x006DE864
		Private Sub UpdateDatabase(id As Integer, columnName As String, newValue As Boolean)
			Dim text As String = String.Format("UPDATE tbl_master_menu SET {0} = @Value WHERE id = @Id", columnName)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Value", newValue)
					sqlCommand.Parameters.AddWithValue("@Id", id)
					sqlConnection.Open()
					sqlCommand.ExecuteNonQuery()
					sqlConnection.Close()
				End Using
			End Using
		End Sub

		' Token: 0x06009948 RID: 39240 RVA: 0x006E0710 File Offset: 0x006DE910
		Private Sub cboxCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbUserID.SelectedIndex <> -1
			If flag Then
				Dim text As String = Me.cmbUserID.SelectedValue.ToString()
				Dim num As Integer = 0
				Do
					Me.SetColumnState(num, False)
					num += 1
				Loop While num <= 3
				If Operators.CompareString(text, "Admin", False) <> 0 Then
					If Operators.CompareString(text, "Moderator", False) <> 0 Then
						If Operators.CompareString(text, "Sales Person", False) <> 0 Then
							If Operators.CompareString(text, "Inventory Manager", False) = 0 Then
								Me.SetColumnState(3, True)
							End If
						Else
							Me.SetColumnState(2, True)
						End If
					Else
						Me.SetColumnState(1, True)
					End If
				Else
					Me.SetColumnState(0, True)
				End If
			End If
			Try
				Dim flag2 As Boolean = Me.cboxCategory.SelectedItem Is Nothing
				If Not flag2 Then
					Dim selectedItem As Object = Me.cboxCategory.SelectedItem
					Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
					Me.Bindgrid(value)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009949 RID: 39241 RVA: 0x006E0854 File Offset: 0x006DEA54
		Public Sub Bindgrid(selectedCategoryName As String)
			Try
				Dim text As String = "SELECT for_Admin,for_Moderator, for_SalesPerson, for_InventoryManager, id, category_name, sub_category_name FROM tbl_master_menu where category_name='" + selectedCategoryName + "'"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						Me.dgvMenu.DataSource = dataTable
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
