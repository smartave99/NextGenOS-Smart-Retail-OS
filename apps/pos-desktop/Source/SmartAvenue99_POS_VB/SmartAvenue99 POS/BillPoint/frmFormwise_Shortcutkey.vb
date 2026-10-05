Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001EC RID: 492
	<DesignerGenerated()>
	Public Partial Class frmFormwise_Shortcutkey
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600840E RID: 33806 RVA: 0x0004097B File Offset: 0x0003EB7B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductwiseProfit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003066 RID: 12390
		' (get) Token: 0x06008411 RID: 33809 RVA: 0x0004099B File Offset: 0x0003EB9B
		' (set) Token: 0x06008412 RID: 33810 RVA: 0x000409A5 File Offset: 0x0003EBA5
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17003067 RID: 12391
		' (get) Token: 0x06008413 RID: 33811 RVA: 0x000409AE File Offset: 0x0003EBAE
		' (set) Token: 0x06008414 RID: 33812 RVA: 0x000409B8 File Offset: 0x0003EBB8
		Friend Overridable Property Label1 As Label

		' Token: 0x06008415 RID: 33813 RVA: 0x000409C1 File Offset: 0x0003EBC1
		Private Sub frmProductwiseProfit_Load(sender As Object, e As EventArgs)
			Me.LoadShortcutKeys(Me.Label1.Text)
		End Sub

		' Token: 0x06008416 RID: 33814 RVA: 0x0062151C File Offset: 0x0061F71C
		Private Sub LoadShortcutKeys(formName As String)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT shortcut_key AS [Shortcut Key], details AS [Function] " & vbCrLf & "                                   FROM tbl_formwise_shortcut_key " & vbCrLf & "                                   WHERE form_name = @form_name " & vbCrLf & "                                   ORDER BY shortcut_key"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@form_name", formName)
						Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						Me.DataGridView1.DataSource = dataTable
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading shortcuts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
