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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000203 RID: 515
	<DesignerGenerated()>
	Public Partial Class frmPurcOrderRetrieve1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009451 RID: 37969 RVA: 0x006B14F8 File Offset: 0x006AF6F8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurcOrderRetrieve1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurcOrderRetrieve1_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmPurcOrderRetrieve1_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700370E RID: 14094
		' (get) Token: 0x06009454 RID: 37972 RVA: 0x00048A40 File Offset: 0x00046C40
		' (set) Token: 0x06009455 RID: 37973 RVA: 0x00048A4A File Offset: 0x00046C4A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700370F RID: 14095
		' (get) Token: 0x06009456 RID: 37974 RVA: 0x00048A53 File Offset: 0x00046C53
		' (set) Token: 0x06009457 RID: 37975 RVA: 0x00048A5D File Offset: 0x00046C5D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17003710 RID: 14096
		' (get) Token: 0x06009458 RID: 37976 RVA: 0x00048A66 File Offset: 0x00046C66
		' (set) Token: 0x06009459 RID: 37977 RVA: 0x006B292C File Offset: 0x006B0B2C
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

		' Token: 0x17003711 RID: 14097
		' (get) Token: 0x0600945A RID: 37978 RVA: 0x00048A70 File Offset: 0x00046C70
		' (set) Token: 0x0600945B RID: 37979 RVA: 0x006B2970 File Offset: 0x006B0B70
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003712 RID: 14098
		' (get) Token: 0x0600945C RID: 37980 RVA: 0x00048A7A File Offset: 0x00046C7A
		' (set) Token: 0x0600945D RID: 37981 RVA: 0x006B29B4 File Offset: 0x006B0BB4
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

		' Token: 0x17003713 RID: 14099
		' (get) Token: 0x0600945E RID: 37982 RVA: 0x00048A84 File Offset: 0x00046C84
		' (set) Token: 0x0600945F RID: 37983 RVA: 0x00048A8E File Offset: 0x00046C8E
		Friend Overridable Property Label5 As Label

		' Token: 0x17003714 RID: 14100
		' (get) Token: 0x06009460 RID: 37984 RVA: 0x00048A97 File Offset: 0x00046C97
		' (set) Token: 0x06009461 RID: 37985 RVA: 0x00048AA1 File Offset: 0x00046CA1
		Friend Overridable Property Label1 As Label

		' Token: 0x17003715 RID: 14101
		' (get) Token: 0x06009462 RID: 37986 RVA: 0x00048AAA File Offset: 0x00046CAA
		' (set) Token: 0x06009463 RID: 37987 RVA: 0x006B29F8 File Offset: 0x006B0BF8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim mouseEventHandler2 As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler2
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler2
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003716 RID: 14102
		' (get) Token: 0x06009464 RID: 37988 RVA: 0x00048AB4 File Offset: 0x00046CB4
		' (set) Token: 0x06009465 RID: 37989 RVA: 0x00048ABE File Offset: 0x00046CBE
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003717 RID: 14103
		' (get) Token: 0x06009466 RID: 37990 RVA: 0x00048AC7 File Offset: 0x00046CC7
		' (set) Token: 0x06009467 RID: 37991 RVA: 0x00048AD1 File Offset: 0x00046CD1
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003718 RID: 14104
		' (get) Token: 0x06009468 RID: 37992 RVA: 0x00048ADA File Offset: 0x00046CDA
		' (set) Token: 0x06009469 RID: 37993 RVA: 0x00048AE4 File Offset: 0x00046CE4
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003719 RID: 14105
		' (get) Token: 0x0600946A RID: 37994 RVA: 0x00048AED File Offset: 0x00046CED
		' (set) Token: 0x0600946B RID: 37995 RVA: 0x00048AF7 File Offset: 0x00046CF7
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700371A RID: 14106
		' (get) Token: 0x0600946C RID: 37996 RVA: 0x00048B00 File Offset: 0x00046D00
		' (set) Token: 0x0600946D RID: 37997 RVA: 0x00048B0A File Offset: 0x00046D0A
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700371B RID: 14107
		' (get) Token: 0x0600946E RID: 37998 RVA: 0x00048B13 File Offset: 0x00046D13
		' (set) Token: 0x0600946F RID: 37999 RVA: 0x00048B1D File Offset: 0x00046D1D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700371C RID: 14108
		' (get) Token: 0x06009470 RID: 38000 RVA: 0x00048B26 File Offset: 0x00046D26
		' (set) Token: 0x06009471 RID: 38001 RVA: 0x00048B30 File Offset: 0x00046D30
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700371D RID: 14109
		' (get) Token: 0x06009472 RID: 38002 RVA: 0x00048B39 File Offset: 0x00046D39
		' (set) Token: 0x06009473 RID: 38003 RVA: 0x00048B43 File Offset: 0x00046D43
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700371E RID: 14110
		' (get) Token: 0x06009474 RID: 38004 RVA: 0x00048B4C File Offset: 0x00046D4C
		' (set) Token: 0x06009475 RID: 38005 RVA: 0x00048B56 File Offset: 0x00046D56
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700371F RID: 14111
		' (get) Token: 0x06009476 RID: 38006 RVA: 0x00048B5F File Offset: 0x00046D5F
		' (set) Token: 0x06009477 RID: 38007 RVA: 0x00048B69 File Offset: 0x00046D69
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003720 RID: 14112
		' (get) Token: 0x06009478 RID: 38008 RVA: 0x00048B72 File Offset: 0x00046D72
		' (set) Token: 0x06009479 RID: 38009 RVA: 0x00048B7C File Offset: 0x00046D7C
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003721 RID: 14113
		' (get) Token: 0x0600947A RID: 38010 RVA: 0x00048B85 File Offset: 0x00046D85
		' (set) Token: 0x0600947B RID: 38011 RVA: 0x00048B8F File Offset: 0x00046D8F
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003722 RID: 14114
		' (get) Token: 0x0600947C RID: 38012 RVA: 0x00048B98 File Offset: 0x00046D98
		' (set) Token: 0x0600947D RID: 38013 RVA: 0x00048BA2 File Offset: 0x00046DA2
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003723 RID: 14115
		' (get) Token: 0x0600947E RID: 38014 RVA: 0x00048BAB File Offset: 0x00046DAB
		' (set) Token: 0x0600947F RID: 38015 RVA: 0x00048BB5 File Offset: 0x00046DB5
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003724 RID: 14116
		' (get) Token: 0x06009480 RID: 38016 RVA: 0x00048BBE File Offset: 0x00046DBE
		' (set) Token: 0x06009481 RID: 38017 RVA: 0x00048BC8 File Offset: 0x00046DC8
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003725 RID: 14117
		' (get) Token: 0x06009482 RID: 38018 RVA: 0x00048BD1 File Offset: 0x00046DD1
		' (set) Token: 0x06009483 RID: 38019 RVA: 0x00048BDB File Offset: 0x00046DDB
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003726 RID: 14118
		' (get) Token: 0x06009484 RID: 38020 RVA: 0x00048BE4 File Offset: 0x00046DE4
		' (set) Token: 0x06009485 RID: 38021 RVA: 0x00048BEE File Offset: 0x00046DEE
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003727 RID: 14119
		' (get) Token: 0x06009486 RID: 38022 RVA: 0x00048BF7 File Offset: 0x00046DF7
		' (set) Token: 0x06009487 RID: 38023 RVA: 0x00048C01 File Offset: 0x00046E01
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003728 RID: 14120
		' (get) Token: 0x06009488 RID: 38024 RVA: 0x00048C0A File Offset: 0x00046E0A
		' (set) Token: 0x06009489 RID: 38025 RVA: 0x00048C14 File Offset: 0x00046E14
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003729 RID: 14121
		' (get) Token: 0x0600948A RID: 38026 RVA: 0x00048C1D File Offset: 0x00046E1D
		' (set) Token: 0x0600948B RID: 38027 RVA: 0x00048C27 File Offset: 0x00046E27
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700372A RID: 14122
		' (get) Token: 0x0600948C RID: 38028 RVA: 0x00048C30 File Offset: 0x00046E30
		' (set) Token: 0x0600948D RID: 38029 RVA: 0x00048C3A File Offset: 0x00046E3A
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700372B RID: 14123
		' (get) Token: 0x0600948E RID: 38030 RVA: 0x00048C43 File Offset: 0x00046E43
		' (set) Token: 0x0600948F RID: 38031 RVA: 0x00048C4D File Offset: 0x00046E4D
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700372C RID: 14124
		' (get) Token: 0x06009490 RID: 38032 RVA: 0x00048C56 File Offset: 0x00046E56
		' (set) Token: 0x06009491 RID: 38033 RVA: 0x00048C60 File Offset: 0x00046E60
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700372D RID: 14125
		' (get) Token: 0x06009492 RID: 38034 RVA: 0x00048C69 File Offset: 0x00046E69
		' (set) Token: 0x06009493 RID: 38035 RVA: 0x00048C73 File Offset: 0x00046E73
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700372E RID: 14126
		' (get) Token: 0x06009494 RID: 38036 RVA: 0x00048C7C File Offset: 0x00046E7C
		' (set) Token: 0x06009495 RID: 38037 RVA: 0x00048C86 File Offset: 0x00046E86
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x06009496 RID: 38038 RVA: 0x006B2A98 File Offset: 0x006B0C98
		Private Sub frmPurcOrderRetrieve1_Load(sender As Object, e As EventArgs)
			Me.fillPurcOrderNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
		End Sub

		' Token: 0x06009497 RID: 38039 RVA: 0x006B2B24 File Offset: 0x006B0D24
		Public Sub fillPurcOrderNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PONo) FROM PurchaseOrder", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06009498 RID: 38040 RVA: 0x006B2C58 File Offset: 0x006B0E58
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

		' Token: 0x06009499 RID: 38041 RVA: 0x006B2D40 File Offset: 0x006B0F40
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseOrder.PONo), PurchaseOrder.Date, RTRIM(PurchaseOrder.TaxType), RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), PurchaseOrder_Join.Price, PurchaseOrder_Join.Qty, RTRIM(PurchaseUnit), PurchaseOrder_Join.DiscountPer, PurchaseOrder_Join.DiscountAmt, PurchaseOrder_Join.CGSTPer, PurchaseOrder_Join.CGSTAmt, PurchaseOrder_Join.SGSTPer, PurchaseOrder_Join.SGSTAmt, PurchaseOrder_Join.IGSTPer, PurchaseOrder_Join.IGSTAmt, PurchaseOrder_Join.CESSPer, PurchaseOrder_Join.CESSAmt, PurchaseOrder_Join.TotalAmount, RTRIM(Product.ProductCode), RTRIM(PurchaseOrder_Join.Barcode) FROM PurchaseOrder INNER JOIN PurchaseOrder_Join ON PurchaseOrder.PO_ID = PurchaseOrder_Join.PurchaseOrderID INNER JOIN Product ON PurchaseOrder_Join.ProductID = Product.PID INNER JOIN Supplier ON PurchaseOrder.SupplierID = Supplier.ID where PurchaseOrder.PONo ='" + Me.ComboBox1.Text + "'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600949A RID: 38042 RVA: 0x00048C8F File Offset: 0x00046E8F
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600949B RID: 38043 RVA: 0x00048C99 File Offset: 0x00046E99
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x0600949C RID: 38044 RVA: 0x00048CB0 File Offset: 0x00046EB0
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600949D RID: 38045 RVA: 0x006B2FAC File Offset: 0x006B11AC
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

		' Token: 0x0600949E RID: 38046 RVA: 0x006B3258 File Offset: 0x006B1458
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.SuplRetrive()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600949F RID: 38047 RVA: 0x006B32D8 File Offset: 0x006B14D8
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.SuplRetrive()
			Catch ex As Exception
			End Try
			Try
				Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.txtRemarks.Text = "Ref : " + Me.ComboBox1.Text
				MyProject.Forms.frmPurchaseEntry.TextBox11.Text = dataGridViewRow2.Cells(23).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtQty.Text = dataGridViewRow2.Cells(9).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtDiscPer.Text = dataGridViewRow2.Cells(11).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.BarcodeEntry()
				Try
					For Each obj As Object In Me.dgw.SelectedRows
						Dim dataGridViewRow3 As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.dgw.Rows.RemoveAt(dataGridViewRow3.Index)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060094A0 RID: 38048 RVA: 0x006B32D8 File Offset: 0x006B14D8
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.SuplRetrive()
			Catch ex As Exception
			End Try
			Try
				Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.txtRemarks.Text = "Ref : " + Me.ComboBox1.Text
				MyProject.Forms.frmPurchaseEntry.TextBox11.Text = dataGridViewRow2.Cells(23).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtQty.Text = dataGridViewRow2.Cells(9).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtDiscPer.Text = dataGridViewRow2.Cells(11).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.BarcodeEntry()
				Try
					For Each obj As Object In Me.dgw.SelectedRows
						Dim dataGridViewRow3 As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.dgw.Rows.RemoveAt(dataGridViewRow3.Index)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060094A1 RID: 38049 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurcOrderRetrieve1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060094A2 RID: 38050 RVA: 0x00048CB0 File Offset: 0x00046EB0
		Private Sub frmPurcOrderRetrieve1_Closing(sender As Object, e As CancelEventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
