Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000AB RID: 171
	<DesignerGenerated()>
	Public Partial Class frmGoProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600192E RID: 6446 RVA: 0x00013313 File Offset: 0x00011513
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGoProduct_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009E9 RID: 2537
		' (get) Token: 0x06001931 RID: 6449 RVA: 0x00013333 File Offset: 0x00011533
		' (set) Token: 0x06001932 RID: 6450 RVA: 0x0001333D File Offset: 0x0001153D
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170009EA RID: 2538
		' (get) Token: 0x06001933 RID: 6451 RVA: 0x00013346 File Offset: 0x00011546
		' (set) Token: 0x06001934 RID: 6452 RVA: 0x00112820 File Offset: 0x00110A20
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

		' Token: 0x170009EB RID: 2539
		' (get) Token: 0x06001935 RID: 6453 RVA: 0x00013350 File Offset: 0x00011550
		' (set) Token: 0x06001936 RID: 6454 RVA: 0x00112864 File Offset: 0x00110A64
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

		' Token: 0x170009EC RID: 2540
		' (get) Token: 0x06001937 RID: 6455 RVA: 0x0001335A File Offset: 0x0001155A
		' (set) Token: 0x06001938 RID: 6456 RVA: 0x00013364 File Offset: 0x00011564
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x170009ED RID: 2541
		' (get) Token: 0x06001939 RID: 6457 RVA: 0x0001336D File Offset: 0x0001156D
		' (set) Token: 0x0600193A RID: 6458 RVA: 0x00013377 File Offset: 0x00011577
		Friend Overridable Property Panel7 As Panel

		' Token: 0x170009EE RID: 2542
		' (get) Token: 0x0600193B RID: 6459 RVA: 0x00013380 File Offset: 0x00011580
		' (set) Token: 0x0600193C RID: 6460 RVA: 0x0001338A File Offset: 0x0001158A
		Friend Overridable Property Label18 As Label

		' Token: 0x170009EF RID: 2543
		' (get) Token: 0x0600193D RID: 6461 RVA: 0x00013393 File Offset: 0x00011593
		' (set) Token: 0x0600193E RID: 6462 RVA: 0x0001339D File Offset: 0x0001159D
		Friend Overridable Property Label21 As Label

		' Token: 0x170009F0 RID: 2544
		' (get) Token: 0x0600193F RID: 6463 RVA: 0x000133A6 File Offset: 0x000115A6
		' (set) Token: 0x06001940 RID: 6464 RVA: 0x000133B0 File Offset: 0x000115B0
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x170009F1 RID: 2545
		' (get) Token: 0x06001941 RID: 6465 RVA: 0x000133B9 File Offset: 0x000115B9
		' (set) Token: 0x06001942 RID: 6466 RVA: 0x001128A8 File Offset: 0x00110AA8
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearchProduct_KeyDown
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170009F2 RID: 2546
		' (get) Token: 0x06001943 RID: 6467 RVA: 0x000133C3 File Offset: 0x000115C3
		' (set) Token: 0x06001944 RID: 6468 RVA: 0x000133CD File Offset: 0x000115CD
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x170009F3 RID: 2547
		' (get) Token: 0x06001945 RID: 6469 RVA: 0x000133D6 File Offset: 0x000115D6
		' (set) Token: 0x06001946 RID: 6470 RVA: 0x000133E0 File Offset: 0x000115E0
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170009F4 RID: 2548
		' (get) Token: 0x06001947 RID: 6471 RVA: 0x000133E9 File Offset: 0x000115E9
		' (set) Token: 0x06001948 RID: 6472 RVA: 0x000133F3 File Offset: 0x000115F3
		Friend Overridable Property ProductCode1 As DataGridViewTextBoxColumn

		' Token: 0x170009F5 RID: 2549
		' (get) Token: 0x06001949 RID: 6473 RVA: 0x000133FC File Offset: 0x000115FC
		' (set) Token: 0x0600194A RID: 6474 RVA: 0x00013406 File Offset: 0x00011606
		Friend Overridable Property ProductName1 As DataGridViewTextBoxColumn

		' Token: 0x170009F6 RID: 2550
		' (get) Token: 0x0600194B RID: 6475 RVA: 0x0001340F File Offset: 0x0001160F
		' (set) Token: 0x0600194C RID: 6476 RVA: 0x00013419 File Offset: 0x00011619
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170009F7 RID: 2551
		' (get) Token: 0x0600194D RID: 6477 RVA: 0x00013422 File Offset: 0x00011622
		' (set) Token: 0x0600194E RID: 6478 RVA: 0x0001342C File Offset: 0x0001162C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x0600194F RID: 6479 RVA: 0x001128EC File Offset: 0x00110AEC
		Private Sub txtSearchProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.getgriditemdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001950 RID: 6480 RVA: 0x00112948 File Offset: 0x00110B48
		Private Sub getgriditemdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Top ", Me.txtTopResult.Text, vbCrLf & "    product_code," & vbCrLf & "    product_name,unit,tax" & vbCrLf & "    from tbl_product where product_name like N'", Me.txtSearchProduct.Text, "%' order by product_id desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Top ", Me.txtTopResult.Text, vbCrLf & "    product_code," & vbCrLf & "    product_name,unit,tax" & vbCrLf & "    from tbl_product where product_code like N'", Me.txtSearchProduct.Text, "%' order by product_id desc" }), ModCommonClasses.con)
					End If
				End If
				Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While sqlDataReader.Read()
					Me.DataGridView2.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3) })
				End While
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001951 RID: 6481 RVA: 0x00112AE4 File Offset: 0x00110CE4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Top " + Me.txtTopResult.Text + vbCrLf & "    product_code," & vbCrLf & "    product_name,unit,tax" & vbCrLf & "    from tbl_product" & vbCrLf & "     order by product_id desc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001952 RID: 6482 RVA: 0x00112C08 File Offset: 0x00110E08
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView2.Columns.Count = 0) Or (Me.DataGridView2.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView2.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView2.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								Dim dataRow As DataRow = dataTable.NewRow()
								Try
									For Each obj3 As Object In dataGridViewRow.Cells
										Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
										dataRow(dataGridViewCell.ColumnIndex) = If((dataGridViewCell.Value IsNot Nothing), dataGridViewCell.Value.ToString(), "")
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
								dataTable.Rows.Add(dataRow)
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag3 Then
						Dim fileName As String = Me.SaveFileDialog1.FileName
						Using xlworkbook As XLWorkbook = New XLWorkbook()
							xlworkbook.Worksheets.Add(dataTable, "Export File")
							xlworkbook.SaveAs(fileName)
						End Using
						MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						MessageBox.Show("Export Cancelled", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully: " + ex.Message, "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001953 RID: 6483 RVA: 0x00013435 File Offset: 0x00011635
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.txtSearchProduct.Text = ""
		End Sub

		' Token: 0x06001954 RID: 6484 RVA: 0x00013449 File Offset: 0x00011649
		Private Sub frmGoProduct_Load(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub
	End Class
End Namespace
