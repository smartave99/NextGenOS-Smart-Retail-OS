Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000AF RID: 175
	<DesignerGenerated()>
	Public Partial Class frmMultiPaymentModeSettings
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001996 RID: 6550 RVA: 0x000135DF File Offset: 0x000117DF
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMultiBillPayment_Load
			AddHandler MyBase.Closing, AddressOf Me.frmMultiPaymentModeSettings_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A09 RID: 2569
		' (get) Token: 0x06001999 RID: 6553 RVA: 0x00013611 File Offset: 0x00011811
		' (set) Token: 0x0600199A RID: 6554 RVA: 0x00119D30 File Offset: 0x00117F30
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A0A RID: 2570
		' (get) Token: 0x0600199B RID: 6555 RVA: 0x0001361B File Offset: 0x0001181B
		' (set) Token: 0x0600199C RID: 6556 RVA: 0x00013625 File Offset: 0x00011825
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000A0B RID: 2571
		' (get) Token: 0x0600199D RID: 6557 RVA: 0x0001362E File Offset: 0x0001182E
		' (set) Token: 0x0600199E RID: 6558 RVA: 0x00013638 File Offset: 0x00011838
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000A0C RID: 2572
		' (get) Token: 0x0600199F RID: 6559 RVA: 0x00013641 File Offset: 0x00011841
		' (set) Token: 0x060019A0 RID: 6560 RVA: 0x0001364B File Offset: 0x0001184B
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000A0D RID: 2573
		' (get) Token: 0x060019A1 RID: 6561 RVA: 0x00013654 File Offset: 0x00011854
		' (set) Token: 0x060019A2 RID: 6562 RVA: 0x0001365E File Offset: 0x0001185E
		Friend Overridable Property DataGridViewComboBoxColumn1 As DataGridViewCheckBoxColumn

		' Token: 0x060019A3 RID: 6563 RVA: 0x00013667 File Offset: 0x00011867
		Private Sub frmMultiBillPayment_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x060019A4 RID: 6564 RVA: 0x00119D74 File Offset: 0x00117F74
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				Me.dgw.RowHeadersVisible = False
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT id, RTRIM(paymentmode),amount, status FROM tbl_BillPaymentMode", sqlConnection)
					Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
					Me.dgw.Rows.Clear()
					While sqlDataReader.Read()
						Me.dgw.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1).ToString(), sqlDataReader(2), sqlDataReader("status"), "" })
					End While
					Me.dgw.Rows.Add(New Object() { 0, "By Return", "0.00", True })
					Me.dgw.Rows.Add(New Object() { 0, "Change", "0.00", True })
					sqlDataReader.Close()
				End Using
				Me.dgw.Rows(Me.dgw.RowCount - 1).[ReadOnly] = True
				Me.dgw.Rows(Me.dgw.RowCount - 2).[ReadOnly] = True
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060019A5 RID: 6565 RVA: 0x00119F5C File Offset: 0x0011815C
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.ColumnIndex = 3 AndAlso e.RowIndex >= 0
				If flag Then
					Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(e.RowIndex).Cells(0).Value))
					Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(e.RowIndex).Cells(3).Value))
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "UPDATE tbl_BillPaymentMode SET status = @status WHERE id = @id"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@status", flag2)
							sqlCommand.Parameters.AddWithValue("@id", num)
							sqlCommand.ExecuteNonQuery()
						End Using
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060019A6 RID: 6566 RVA: 0x00013679 File Offset: 0x00011879
		Private Sub frmMultiPaymentModeSettings_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmMultiBillPayment.Getdata()
		End Sub
	End Class
End Namespace
