Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001EA RID: 490
	<DesignerGenerated()>
	Public Partial Class frmBulkProductSeting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060083FC RID: 33788 RVA: 0x00040913 File Offset: 0x0003EB13
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductSeting_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003064 RID: 12388
		' (get) Token: 0x060083FF RID: 33791 RVA: 0x00040933 File Offset: 0x0003EB33
		' (set) Token: 0x06008400 RID: 33792 RVA: 0x006208B4 File Offset: 0x0061EAB4
		Private _CheckedListBox1 As CheckedListBox
		Friend Overridable Property CheckedListBox1 As CheckedListBox
			<CompilerGenerated()>
			Get
				Return Me._CheckedListBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckedListBox)
				Dim itemCheckEventHandler As ItemCheckEventHandler = AddressOf Me.CheckedListBox1_ItemCheck
				Dim checkedListBox As CheckedListBox = Me._CheckedListBox1
				If checkedListBox IsNot Nothing Then
					RemoveHandler checkedListBox.ItemCheck, itemCheckEventHandler
				End If
				Me._CheckedListBox1 = value
				checkedListBox = Me._CheckedListBox1
				If checkedListBox IsNot Nothing Then
					AddHandler checkedListBox.ItemCheck, itemCheckEventHandler
				End If
			End Set
		End Property

		' Token: 0x06008401 RID: 33793 RVA: 0x006208F8 File Offset: 0x0061EAF8
		Private Sub FetchDataAndPopulateCheckedListBox()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				sqlDataAdapter.SelectCommand = New SqlCommand("SELECT menu_name, is_active FROM Bulk_product_menu_setting", ModCommonClasses.con)
				Dim dataSet As DataSet = New DataSet("ds1")
				sqlDataAdapter.Fill(dataSet, "is_active")
				Me.CheckedListBox1.Items.Clear()
				Dim dataTable As DataTable = dataSet.Tables("is_active")
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("menu_name").ToString()
						Dim flag As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataRow("is_active")))
						Me.CheckedListBox1.Items.Add(text, flag)
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

		' Token: 0x06008402 RID: 33794 RVA: 0x0004093D File Offset: 0x0003EB3D
		Private Sub frmProductSeting_Load(sender As Object, e As EventArgs)
			Me.FetchDataAndPopulateCheckedListBox()
		End Sub

		' Token: 0x06008403 RID: 33795 RVA: 0x00620A3C File Offset: 0x0061EC3C
		Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs)
			Dim text As String = Me.CheckedListBox1.Items(e.Index).ToString()
			Dim flag As Boolean = e.NewValue = CheckState.Checked
			Me.UpdateDatabase(text, flag)
		End Sub

		' Token: 0x06008404 RID: 33796 RVA: 0x00620A7C File Offset: 0x0061EC7C
		Private Sub UpdateDatabase(itemName As String, isChecked As Boolean)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update Bulk_product_menu_setting set is_active=@is_active where menu_name=@menu_name"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@is_active", isChecked)
				ModCommonClasses.cmd.Parameters.AddWithValue("@menu_name", itemName)
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub
	End Class
End Namespace
