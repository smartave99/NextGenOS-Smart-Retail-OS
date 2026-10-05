Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000558 RID: 1368
	<DesignerGenerated()>
	Public Partial Class frmStockEntryRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010B94 RID: 68500 RVA: 0x00073646 File Offset: 0x00071846
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockEntryRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006781 RID: 26497
		' (get) Token: 0x06010B97 RID: 68503 RVA: 0x00073678 File Offset: 0x00071878
		' (set) Token: 0x06010B98 RID: 68504 RVA: 0x00073682 File Offset: 0x00071882
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006782 RID: 26498
		' (get) Token: 0x06010B99 RID: 68505 RVA: 0x0007368B File Offset: 0x0007188B
		' (set) Token: 0x06010B9A RID: 68506 RVA: 0x009C5260 File Offset: 0x009C3460
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006783 RID: 26499
		' (get) Token: 0x06010B9B RID: 68507 RVA: 0x00073695 File Offset: 0x00071895
		' (set) Token: 0x06010B9C RID: 68508 RVA: 0x009C52C0 File Offset: 0x009C34C0
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

		' Token: 0x17006784 RID: 26500
		' (get) Token: 0x06010B9D RID: 68509 RVA: 0x0007369F File Offset: 0x0007189F
		' (set) Token: 0x06010B9E RID: 68510 RVA: 0x009C5304 File Offset: 0x009C3504
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

		' Token: 0x17006785 RID: 26501
		' (get) Token: 0x06010B9F RID: 68511 RVA: 0x000736A9 File Offset: 0x000718A9
		' (set) Token: 0x06010BA0 RID: 68512 RVA: 0x009C5348 File Offset: 0x009C3548
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

		' Token: 0x17006786 RID: 26502
		' (get) Token: 0x06010BA1 RID: 68513 RVA: 0x000736B3 File Offset: 0x000718B3
		' (set) Token: 0x06010BA2 RID: 68514 RVA: 0x000736BD File Offset: 0x000718BD
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006787 RID: 26503
		' (get) Token: 0x06010BA3 RID: 68515 RVA: 0x000736C6 File Offset: 0x000718C6
		' (set) Token: 0x06010BA4 RID: 68516 RVA: 0x000736D0 File Offset: 0x000718D0
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006788 RID: 26504
		' (get) Token: 0x06010BA5 RID: 68517 RVA: 0x000736D9 File Offset: 0x000718D9
		' (set) Token: 0x06010BA6 RID: 68518 RVA: 0x000736E3 File Offset: 0x000718E3
		Friend Overridable Property Label2 As Label

		' Token: 0x17006789 RID: 26505
		' (get) Token: 0x06010BA7 RID: 68519 RVA: 0x000736EC File Offset: 0x000718EC
		' (set) Token: 0x06010BA8 RID: 68520 RVA: 0x000736F6 File Offset: 0x000718F6
		Friend Overridable Property Label4 As Label

		' Token: 0x1700678A RID: 26506
		' (get) Token: 0x06010BA9 RID: 68521 RVA: 0x000736FF File Offset: 0x000718FF
		' (set) Token: 0x06010BAA RID: 68522 RVA: 0x009C538C File Offset: 0x009C358C
		Private _cmbStockID As ComboBox
		Friend Overridable Property cmbStockID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbStockID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbTicketNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbTicketNo_Format
				Dim comboBox As ComboBox = Me._cmbStockID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbStockID = value
				comboBox = Me._cmbStockID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700678B RID: 26507
		' (get) Token: 0x06010BAB RID: 68523 RVA: 0x00073709 File Offset: 0x00071909
		' (set) Token: 0x06010BAC RID: 68524 RVA: 0x00073713 File Offset: 0x00071913
		Friend Overridable Property Label5 As Label

		' Token: 0x1700678C RID: 26508
		' (get) Token: 0x06010BAD RID: 68525 RVA: 0x0007371C File Offset: 0x0007191C
		' (set) Token: 0x06010BAE RID: 68526 RVA: 0x00073726 File Offset: 0x00071926
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700678D RID: 26509
		' (get) Token: 0x06010BAF RID: 68527 RVA: 0x0007372F File Offset: 0x0007192F
		' (set) Token: 0x06010BB0 RID: 68528 RVA: 0x00073739 File Offset: 0x00071939
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700678E RID: 26510
		' (get) Token: 0x06010BB1 RID: 68529 RVA: 0x00073742 File Offset: 0x00071942
		' (set) Token: 0x06010BB2 RID: 68530 RVA: 0x0007374C File Offset: 0x0007194C
		Friend Overridable Property Label1 As Label

		' Token: 0x1700678F RID: 26511
		' (get) Token: 0x06010BB3 RID: 68531 RVA: 0x00073755 File Offset: 0x00071955
		' (set) Token: 0x06010BB4 RID: 68532 RVA: 0x0007375F File Offset: 0x0007195F
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006790 RID: 26512
		' (get) Token: 0x06010BB5 RID: 68533 RVA: 0x00073768 File Offset: 0x00071968
		' (set) Token: 0x06010BB6 RID: 68534 RVA: 0x00073772 File Offset: 0x00071972
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006791 RID: 26513
		' (get) Token: 0x06010BB7 RID: 68535 RVA: 0x0007377B File Offset: 0x0007197B
		' (set) Token: 0x06010BB8 RID: 68536 RVA: 0x00073785 File Offset: 0x00071985
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006792 RID: 26514
		' (get) Token: 0x06010BB9 RID: 68537 RVA: 0x0007378E File Offset: 0x0007198E
		' (set) Token: 0x06010BBA RID: 68538 RVA: 0x00073798 File Offset: 0x00071998
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x06010BBB RID: 68539 RVA: 0x009C53EC File Offset: 0x009C35EC
		Public Sub fillTransferID()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(St_ID) FROM Stock_Store order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbStockID.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbStockID.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06010BBC RID: 68540 RVA: 0x009C5514 File Offset: 0x009C3714
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010BBD RID: 68541 RVA: 0x009C55E8 File Offset: 0x009C37E8
		Public Sub GetData()
			Try
				Me.cmbStockID.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date,RTRIM(Remarks) from Stock_Store where Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010BBE RID: 68542 RVA: 0x009C577C File Offset: 0x009C397C
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.GetData()
			Me.fillTransferID()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06010BBF RID: 68543 RVA: 0x000737A1 File Offset: 0x000719A1
		Public Sub Reset()
			Me.cmbStockID.Text = ""
			Me.fyear()
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.GetData()
		End Sub

		' Token: 0x06010BC0 RID: 68544 RVA: 0x000737D9 File Offset: 0x000719D9
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010BC1 RID: 68545 RVA: 0x009C580C File Offset: 0x009C3A0C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
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
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
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

		' Token: 0x06010BC2 RID: 68546 RVA: 0x009C5AB8 File Offset: 0x009C3CB8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyBase.Hide()
					MyProject.Forms.frmStockEntry.Show()
					MyProject.Forms.frmStockEntry.txtST_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmStockEntry.dtpDate.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmStockEntry.txtRemarks.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmStockEntry.btnSave.Enabled = False
					MyProject.Forms.frmStockEntry.btnDelete.Enabled = True
					MyProject.Forms.frmStockEntry.btnAdd.Enabled = False
					MyProject.Forms.frmStockEntry.lblSet.Text = "Not allowed"
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select Stock_Store_Join.ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Stock_Store_Join.Qty from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and ST_ID=" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))) + " order by Productname"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmStockEntry.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmStockEntry.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010BC3 RID: 68547 RVA: 0x009C5D28 File Offset: 0x009C3F28
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06010BC4 RID: 68548 RVA: 0x009C55E8 File Offset: 0x009C37E8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbStockID.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date,RTRIM(Remarks) from Stock_Store where Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010BC5 RID: 68549 RVA: 0x009C5E10 File Offset: 0x009C4010
		Private Sub cmbTicketNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date,RTRIM(Remarks) from Stock_Store where ST_ID=@d3 and Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.cmbStockID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010BC6 RID: 68550 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbTicketNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06010BC7 RID: 68551 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockEntryRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
