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
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000CC RID: 204
	<DesignerGenerated()>
	Public Partial Class frmChangeBarcode
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x17000E11 RID: 3601
		' (get) Token: 0x0600236B RID: 9067 RVA: 0x00018452 File Offset: 0x00016652
		' (set) Token: 0x0600236C RID: 9068 RVA: 0x00168954 File Offset: 0x00166B54
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

		' Token: 0x17000E12 RID: 3602
		' (get) Token: 0x0600236D RID: 9069 RVA: 0x0001845C File Offset: 0x0001665C
		' (set) Token: 0x0600236E RID: 9070 RVA: 0x00018466 File Offset: 0x00016666
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17000E13 RID: 3603
		' (get) Token: 0x0600236F RID: 9071 RVA: 0x0001846F File Offset: 0x0001666F
		' (set) Token: 0x06002370 RID: 9072 RVA: 0x00018479 File Offset: 0x00016679
		Friend Overridable Property Column1 As DataGridViewCheckBoxColumn

		' Token: 0x17000E14 RID: 3604
		' (get) Token: 0x06002371 RID: 9073 RVA: 0x00018482 File Offset: 0x00016682
		' (set) Token: 0x06002372 RID: 9074 RVA: 0x0001848C File Offset: 0x0001668C
		Friend Overridable Property ProductID As DataGridViewTextBoxColumn

		' Token: 0x17000E15 RID: 3605
		' (get) Token: 0x06002373 RID: 9075 RVA: 0x00018495 File Offset: 0x00016695
		' (set) Token: 0x06002374 RID: 9076 RVA: 0x0001849F File Offset: 0x0001669F
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000E16 RID: 3606
		' (get) Token: 0x06002375 RID: 9077 RVA: 0x000184A8 File Offset: 0x000166A8
		' (set) Token: 0x06002376 RID: 9078 RVA: 0x000184B2 File Offset: 0x000166B2
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000E17 RID: 3607
		' (get) Token: 0x06002377 RID: 9079 RVA: 0x000184BB File Offset: 0x000166BB
		' (set) Token: 0x06002378 RID: 9080 RVA: 0x000184C5 File Offset: 0x000166C5
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000E18 RID: 3608
		' (get) Token: 0x06002379 RID: 9081 RVA: 0x000184CE File Offset: 0x000166CE
		' (set) Token: 0x0600237A RID: 9082 RVA: 0x000184D8 File Offset: 0x000166D8
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17000E19 RID: 3609
		' (get) Token: 0x0600237B RID: 9083 RVA: 0x000184E1 File Offset: 0x000166E1
		' (set) Token: 0x0600237C RID: 9084 RVA: 0x000184EB File Offset: 0x000166EB
		Friend Overridable Property CostPrice As DataGridViewTextBoxColumn

		' Token: 0x17000E1A RID: 3610
		' (get) Token: 0x0600237D RID: 9085 RVA: 0x000184F4 File Offset: 0x000166F4
		' (set) Token: 0x0600237E RID: 9086 RVA: 0x000184FE File Offset: 0x000166FE
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17000E1B RID: 3611
		' (get) Token: 0x0600237F RID: 9087 RVA: 0x00018507 File Offset: 0x00016707
		' (set) Token: 0x06002380 RID: 9088 RVA: 0x00018511 File Offset: 0x00016711
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17000E1C RID: 3612
		' (get) Token: 0x06002381 RID: 9089 RVA: 0x0001851A File Offset: 0x0001671A
		' (set) Token: 0x06002382 RID: 9090 RVA: 0x00018524 File Offset: 0x00016724
		Friend Overridable Property NewBarcode As DataGridViewTextBoxColumn

		' Token: 0x06002383 RID: 9091 RVA: 0x00168998 File Offset: 0x00166B98
		Private Sub frmChangeBarcode_Load(sender As Object, e As EventArgs)
			Try
				Me.DataGridView1.Rows.Clear()
				Dim text2 As String = String.Join(",", Me.checkedItems.Select(Function(id As String) String.Format("'{0}'", id)))
				Dim flag As Boolean = String.IsNullOrEmpty(text2)
				If Not flag Then
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text3 As String = String.Format("SELECT PID, RTRIM(Product.ProductCode), RTRIM(Productname), RTRIM(HSNCode), RTRIM(Description), CostPrice, SellingPrice, RTRIM(Temp_Stock.Barcode) FROM Product, Temp_Stock WHERE Temp_Stock.ProductID = Product.PID AND Product.PID IN ({0}) ORDER BY PID", text2)
						Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								While sqlDataReader.Read()
									Me.DataGridView1.Rows.Add(New Object() { True, sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7) })
								End While
							End Using
						End Using
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002384 RID: 9092 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub BindData()
		End Sub

		' Token: 0x06002385 RID: 9093 RVA: 0x0001852D File Offset: 0x0001672D
		Public Sub New(items As List(Of String))
			AddHandler MyBase.Load, AddressOf Me.frmChangeBarcode_Load
			Me.InitializeComponent()
			Me.checkedItems = items
		End Sub

		' Token: 0x06002386 RID: 9094 RVA: 0x00018558 File Offset: 0x00016758
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Me.UpdateCheckedBarcodes()
		End Sub

		' Token: 0x06002387 RID: 9095 RVA: 0x00168B84 File Offset: 0x00166D84
		Private Sub UpdateCheckedBarcodes()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = String.IsNullOrEmpty(Conversions.ToString(dataGridViewRow.Cells(9).Value))
							If flag2 Then
								MessageBox.Show("Please enter a new bar code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select Barcode from Temp_Stock where Barcode=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
							If flag3 Then
								MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.DataGridView1.Focus()
								Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag4 Then
									ModCommonClasses.rdr.Close()
								End If
								Return
							End If
							Dim text2 As String = "select Barcode from tbl_product_serial_final where Barcode=@d1"
							ModCommonClasses.cmd1 = New SqlCommand(text2)
							ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value))
							ModCommonClasses.cmd1.Connection = ModCommonClasses.con
							ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr1.Read()
							If flag5 Then
								MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.DataGridView1.Focus()
								Dim flag6 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr1.Close()
								End If
								Return
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand("UPDATE Temp_Stock SET Barcode = @NewBarcode WHERE ProductID = @ProductID", sqlConnection)
						sqlCommand.Parameters.Add("@NewBarcode", SqlDbType.NVarChar)
						sqlCommand.Parameters.Add("@ProductID", SqlDbType.Int)
						Try
							For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag7 As Boolean = Not dataGridViewRow2.IsNewRow AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value))
								If flag7 Then
									Dim flag8 As Boolean = dataGridViewRow2.Cells("NewBarcode").Value IsNot Nothing AndAlso dataGridViewRow2.Cells("ProductID").Value IsNot Nothing
									If flag8 Then
										sqlCommand.Parameters("@NewBarcode").Value = dataGridViewRow2.Cells("NewBarcode").Value.ToString()
										sqlCommand.Parameters("@ProductID").Value = Convert.ToInt32(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ProductID").Value))
										sqlCommand.ExecuteNonQuery()
									End If
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
				MessageBox.Show("Checked rows' barcodes updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show("Error updating barcodes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04000E86 RID: 3718
		Private checkedItems As List(Of String)
	End Class
End Namespace
