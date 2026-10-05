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
	' Token: 0x020001EB RID: 491
	<DesignerGenerated()>
	Public Partial Class frmProductSeting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008405 RID: 33797 RVA: 0x00040947 File Offset: 0x0003EB47
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductSeting_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003065 RID: 12389
		' (get) Token: 0x06008408 RID: 33800 RVA: 0x00040967 File Offset: 0x0003EB67
		' (set) Token: 0x06008409 RID: 33801 RVA: 0x00620CD8 File Offset: 0x0061EED8
		Private _CheckedListBox1 As CheckedListBox
		Friend Overridable Property CheckedListBox1 As CheckedListBox
			<CompilerGenerated()>
			Get
				Return Me._CheckedListBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckedListBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckedListBox1_ItemCheck
				Dim checkedListBox As CheckedListBox = Me._CheckedListBox1
				If checkedListBox IsNot Nothing Then
					RemoveHandler checkedListBox.SelectedIndexChanged, eventHandler
				End If
				Me._CheckedListBox1 = value
				checkedListBox = Me._CheckedListBox1
				If checkedListBox IsNot Nothing Then
					AddHandler checkedListBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600840A RID: 33802 RVA: 0x00620D1C File Offset: 0x0061EF1C
		Private Sub FetchDataAndPopulateCheckedListBox()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				sqlDataAdapter.SelectCommand = New SqlCommand("SELECT menu_name, is_active FROM product_menu_setting", ModCommonClasses.con)
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

		' Token: 0x0600840B RID: 33803 RVA: 0x00040971 File Offset: 0x0003EB71
		Private Sub frmProductSeting_Load(sender As Object, e As EventArgs)
			Me.FetchDataAndPopulateCheckedListBox()
		End Sub

		' Token: 0x0600840C RID: 33804 RVA: 0x00620E60 File Offset: 0x0061F060
		Private Sub CheckedListBox1_ItemCheck(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.CheckedListBox1.SelectedIndex >= 0
			If flag Then
				Dim text As String = Me.CheckedListBox1.Items(Me.CheckedListBox1.SelectedIndex).ToString()
				Dim flag2 As Boolean = Me.CheckedListBox1.GetItemChecked(Me.CheckedListBox1.SelectedIndex)
				flag2 = Not flag2
				Me.CheckedListBox1.SetItemChecked(Me.CheckedListBox1.SelectedIndex, flag2)
				Me.UpdateDatabase(text, flag2)
				Me.CheckedListBox1.ClearSelected()
			End If
		End Sub

		' Token: 0x0600840D RID: 33805 RVA: 0x00620EF0 File Offset: 0x0061F0F0
		Private Sub UpdateDatabase(itemName As String, isChecked As Boolean)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update product_menu_setting set is_active=@is_active where menu_name=@menu_name"
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
