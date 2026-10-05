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
	' Token: 0x0200010B RID: 267
	<DesignerGenerated()>
	Public Partial Class frmEstimateRetrieve
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002B14 RID: 11028 RVA: 0x001A95EC File Offset: 0x001A77EC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEstimateRetrieve_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEstimateRetrieve_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmEstimateRetrieve_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x170010B7 RID: 4279
		' (get) Token: 0x06002B17 RID: 11031 RVA: 0x0001BA2C File Offset: 0x00019C2C
		' (set) Token: 0x06002B18 RID: 11032 RVA: 0x0001BA36 File Offset: 0x00019C36
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170010B8 RID: 4280
		' (get) Token: 0x06002B19 RID: 11033 RVA: 0x0001BA3F File Offset: 0x00019C3F
		' (set) Token: 0x06002B1A RID: 11034 RVA: 0x0001BA49 File Offset: 0x00019C49
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170010B9 RID: 4281
		' (get) Token: 0x06002B1B RID: 11035 RVA: 0x0001BA52 File Offset: 0x00019C52
		' (set) Token: 0x06002B1C RID: 11036 RVA: 0x0001BA5C File Offset: 0x00019C5C
		Friend Overridable Property Label5 As Label

		' Token: 0x170010BA RID: 4282
		' (get) Token: 0x06002B1D RID: 11037 RVA: 0x0001BA65 File Offset: 0x00019C65
		' (set) Token: 0x06002B1E RID: 11038 RVA: 0x001AAAEC File Offset: 0x001A8CEC
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

		' Token: 0x170010BB RID: 4283
		' (get) Token: 0x06002B1F RID: 11039 RVA: 0x0001BA6F File Offset: 0x00019C6F
		' (set) Token: 0x06002B20 RID: 11040 RVA: 0x001AAB30 File Offset: 0x001A8D30
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

		' Token: 0x170010BC RID: 4284
		' (get) Token: 0x06002B21 RID: 11041 RVA: 0x0001BA79 File Offset: 0x00019C79
		' (set) Token: 0x06002B22 RID: 11042 RVA: 0x001AAB74 File Offset: 0x001A8D74
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim mouseEventHandler2 As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler2
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler2
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170010BD RID: 4285
		' (get) Token: 0x06002B23 RID: 11043 RVA: 0x0001BA83 File Offset: 0x00019C83
		' (set) Token: 0x06002B24 RID: 11044 RVA: 0x0001BA8D File Offset: 0x00019C8D
		Friend Overridable Property Label1 As Label

		' Token: 0x170010BE RID: 4286
		' (get) Token: 0x06002B25 RID: 11045 RVA: 0x0001BA96 File Offset: 0x00019C96
		' (set) Token: 0x06002B26 RID: 11046 RVA: 0x0001BAA0 File Offset: 0x00019CA0
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170010BF RID: 4287
		' (get) Token: 0x06002B27 RID: 11047 RVA: 0x0001BAA9 File Offset: 0x00019CA9
		' (set) Token: 0x06002B28 RID: 11048 RVA: 0x001AAC14 File Offset: 0x001A8E14
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

		' Token: 0x170010C0 RID: 4288
		' (get) Token: 0x06002B29 RID: 11049 RVA: 0x0001BAB3 File Offset: 0x00019CB3
		' (set) Token: 0x06002B2A RID: 11050 RVA: 0x0001BABD File Offset: 0x00019CBD
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170010C1 RID: 4289
		' (get) Token: 0x06002B2B RID: 11051 RVA: 0x0001BAC6 File Offset: 0x00019CC6
		' (set) Token: 0x06002B2C RID: 11052 RVA: 0x0001BAD0 File Offset: 0x00019CD0
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170010C2 RID: 4290
		' (get) Token: 0x06002B2D RID: 11053 RVA: 0x0001BAD9 File Offset: 0x00019CD9
		' (set) Token: 0x06002B2E RID: 11054 RVA: 0x0001BAE3 File Offset: 0x00019CE3
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170010C3 RID: 4291
		' (get) Token: 0x06002B2F RID: 11055 RVA: 0x0001BAEC File Offset: 0x00019CEC
		' (set) Token: 0x06002B30 RID: 11056 RVA: 0x0001BAF6 File Offset: 0x00019CF6
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170010C4 RID: 4292
		' (get) Token: 0x06002B31 RID: 11057 RVA: 0x0001BAFF File Offset: 0x00019CFF
		' (set) Token: 0x06002B32 RID: 11058 RVA: 0x0001BB09 File Offset: 0x00019D09
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170010C5 RID: 4293
		' (get) Token: 0x06002B33 RID: 11059 RVA: 0x0001BB12 File Offset: 0x00019D12
		' (set) Token: 0x06002B34 RID: 11060 RVA: 0x0001BB1C File Offset: 0x00019D1C
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170010C6 RID: 4294
		' (get) Token: 0x06002B35 RID: 11061 RVA: 0x0001BB25 File Offset: 0x00019D25
		' (set) Token: 0x06002B36 RID: 11062 RVA: 0x0001BB2F File Offset: 0x00019D2F
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170010C7 RID: 4295
		' (get) Token: 0x06002B37 RID: 11063 RVA: 0x0001BB38 File Offset: 0x00019D38
		' (set) Token: 0x06002B38 RID: 11064 RVA: 0x0001BB42 File Offset: 0x00019D42
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170010C8 RID: 4296
		' (get) Token: 0x06002B39 RID: 11065 RVA: 0x0001BB4B File Offset: 0x00019D4B
		' (set) Token: 0x06002B3A RID: 11066 RVA: 0x0001BB55 File Offset: 0x00019D55
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170010C9 RID: 4297
		' (get) Token: 0x06002B3B RID: 11067 RVA: 0x0001BB5E File Offset: 0x00019D5E
		' (set) Token: 0x06002B3C RID: 11068 RVA: 0x0001BB68 File Offset: 0x00019D68
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170010CA RID: 4298
		' (get) Token: 0x06002B3D RID: 11069 RVA: 0x0001BB71 File Offset: 0x00019D71
		' (set) Token: 0x06002B3E RID: 11070 RVA: 0x0001BB7B File Offset: 0x00019D7B
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170010CB RID: 4299
		' (get) Token: 0x06002B3F RID: 11071 RVA: 0x0001BB84 File Offset: 0x00019D84
		' (set) Token: 0x06002B40 RID: 11072 RVA: 0x0001BB8E File Offset: 0x00019D8E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170010CC RID: 4300
		' (get) Token: 0x06002B41 RID: 11073 RVA: 0x0001BB97 File Offset: 0x00019D97
		' (set) Token: 0x06002B42 RID: 11074 RVA: 0x0001BBA1 File Offset: 0x00019DA1
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170010CD RID: 4301
		' (get) Token: 0x06002B43 RID: 11075 RVA: 0x0001BBAA File Offset: 0x00019DAA
		' (set) Token: 0x06002B44 RID: 11076 RVA: 0x0001BBB4 File Offset: 0x00019DB4
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170010CE RID: 4302
		' (get) Token: 0x06002B45 RID: 11077 RVA: 0x0001BBBD File Offset: 0x00019DBD
		' (set) Token: 0x06002B46 RID: 11078 RVA: 0x0001BBC7 File Offset: 0x00019DC7
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170010CF RID: 4303
		' (get) Token: 0x06002B47 RID: 11079 RVA: 0x0001BBD0 File Offset: 0x00019DD0
		' (set) Token: 0x06002B48 RID: 11080 RVA: 0x0001BBDA File Offset: 0x00019DDA
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170010D0 RID: 4304
		' (get) Token: 0x06002B49 RID: 11081 RVA: 0x0001BBE3 File Offset: 0x00019DE3
		' (set) Token: 0x06002B4A RID: 11082 RVA: 0x0001BBED File Offset: 0x00019DED
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170010D1 RID: 4305
		' (get) Token: 0x06002B4B RID: 11083 RVA: 0x0001BBF6 File Offset: 0x00019DF6
		' (set) Token: 0x06002B4C RID: 11084 RVA: 0x0001BC00 File Offset: 0x00019E00
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170010D2 RID: 4306
		' (get) Token: 0x06002B4D RID: 11085 RVA: 0x0001BC09 File Offset: 0x00019E09
		' (set) Token: 0x06002B4E RID: 11086 RVA: 0x0001BC13 File Offset: 0x00019E13
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170010D3 RID: 4307
		' (get) Token: 0x06002B4F RID: 11087 RVA: 0x0001BC1C File Offset: 0x00019E1C
		' (set) Token: 0x06002B50 RID: 11088 RVA: 0x0001BC26 File Offset: 0x00019E26
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170010D4 RID: 4308
		' (get) Token: 0x06002B51 RID: 11089 RVA: 0x0001BC2F File Offset: 0x00019E2F
		' (set) Token: 0x06002B52 RID: 11090 RVA: 0x0001BC39 File Offset: 0x00019E39
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170010D5 RID: 4309
		' (get) Token: 0x06002B53 RID: 11091 RVA: 0x0001BC42 File Offset: 0x00019E42
		' (set) Token: 0x06002B54 RID: 11092 RVA: 0x0001BC4C File Offset: 0x00019E4C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170010D6 RID: 4310
		' (get) Token: 0x06002B55 RID: 11093 RVA: 0x0001BC55 File Offset: 0x00019E55
		' (set) Token: 0x06002B56 RID: 11094 RVA: 0x0001BC5F File Offset: 0x00019E5F
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170010D7 RID: 4311
		' (get) Token: 0x06002B57 RID: 11095 RVA: 0x0001BC68 File Offset: 0x00019E68
		' (set) Token: 0x06002B58 RID: 11096 RVA: 0x0001BC72 File Offset: 0x00019E72
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170010D8 RID: 4312
		' (get) Token: 0x06002B59 RID: 11097 RVA: 0x0001BC7B File Offset: 0x00019E7B
		' (set) Token: 0x06002B5A RID: 11098 RVA: 0x0001BC85 File Offset: 0x00019E85
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170010D9 RID: 4313
		' (get) Token: 0x06002B5B RID: 11099 RVA: 0x0001BC8E File Offset: 0x00019E8E
		' (set) Token: 0x06002B5C RID: 11100 RVA: 0x0001BC98 File Offset: 0x00019E98
		Friend Overridable Property Label2 As Label

		' Token: 0x06002B5D RID: 11101 RVA: 0x001AAC58 File Offset: 0x001A8E58
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Estimate.QuotationNo), Estimate.Date, RTRIM(Estimate.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), Estimate_Join.Price, Estimate_Join.Qty, RTRIM(SalesUnit),Estimate_Join.DiscountPer, Estimate_Join.DiscountAmt, Estimate_Join.CGSTPer, Estimate_Join.CGSTAmt, Estimate_Join.SGSTPer, Estimate_Join.SGSTAmt, Estimate_Join.IGSTPer, Estimate_Join.IGSTAmt, Estimate_Join.CESSPer, Estimate_Join.CESSAmt, Estimate_Join.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Estimate_Join.Barcode),RTRIM(Estimate.CType) FROM Estimate INNER JOIN Estimate_Join ON Estimate.Q_ID = Estimate_Join.QuotationID INNER JOIN Product ON Estimate_Join.ProductID = Product.PID INNER JOIN Customer ON Estimate.CustomerID = Customer.ID where Estimate.QuotationNo ='" + Me.ComboBox1.Text + "'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002B5E RID: 11102 RVA: 0x001AAEC0 File Offset: 0x001A90C0
		Private Sub frmEstimateRetrieve_Load(sender As Object, e As EventArgs)
			Me.fillEstimateNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
		End Sub

		' Token: 0x06002B5F RID: 11103 RVA: 0x001AAF4C File Offset: 0x001A914C
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

		' Token: 0x06002B60 RID: 11104 RVA: 0x0001BCA1 File Offset: 0x00019EA1
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x06002B61 RID: 11105 RVA: 0x0001BCB8 File Offset: 0x00019EB8
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002B62 RID: 11106 RVA: 0x001AB034 File Offset: 0x001A9234
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

		' Token: 0x06002B63 RID: 11107 RVA: 0x001AB2E0 File Offset: 0x001A94E0
		Public Sub fillEstimateNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(QuotationNo) FROM Estimate", ModCommonClasses.con)
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

		' Token: 0x06002B64 RID: 11108 RVA: 0x0001BCC2 File Offset: 0x00019EC2
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06002B65 RID: 11109 RVA: 0x001AB414 File Offset: 0x001A9614
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
				Catch ex As Exception
				End Try
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
			If flag2 Then
				Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
				Catch ex2 As Exception
				End Try
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag3 Then
				Try
					Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim text As String = dataGridViewRow3.Cells(24).Value.ToString()
					Dim flag4 As Boolean = Operators.CompareString(text, "Retail", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOS.RadioButton1.Checked = True
						MyProject.Forms.frmPOS.RadioButton2.Checked = False
					Else
						Dim flag5 As Boolean = Operators.CompareString(text, "Wholesale", False) = 0
						If flag5 Then
							MyProject.Forms.frmPOS.RadioButton2.Checked = True
							MyProject.Forms.frmPOS.RadioButton1.Checked = False
						Else
							MyProject.Forms.frmPOS.RadioButton1.Checked = True
							MyProject.Forms.frmPOS.RadioButton2.Checked = False
						End If
					End If
					MyProject.Forms.frmPOS.txtNar.Text = "Ref : " + Me.ComboBox1.Text
					MyProject.Forms.frmPOS.txtBarcode.Text = dataGridViewRow3.Cells(23).Value.ToString()
					MyProject.Forms.frmPOS.BarcodeProgram1()
					Try
						For Each obj As Object In Me.dgw.SelectedRows
							Dim dataGridViewRow4 As DataGridViewRow = CType(obj, DataGridViewRow)
							Me.dgw.Rows.RemoveAt(dataGridViewRow4.Index)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Catch ex3 As Exception
				End Try
			End If
			Dim flag6 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
			If flag6 Then
				Try
					Dim dataGridViewRow5 As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim text2 As String = dataGridViewRow5.Cells(24).Value.ToString()
					Dim flag7 As Boolean = Operators.CompareString(text2, "Retail", False) = 0
					If flag7 Then
						MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
						MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
					Else
						Dim flag8 As Boolean = Operators.CompareString(text2, "Wholesale", False) = 0
						If flag8 Then
							MyProject.Forms.frmPOSTouch.RadioButton2.Checked = True
							MyProject.Forms.frmPOSTouch.RadioButton1.Checked = False
						Else
							MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
							MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
						End If
					End If
					MyProject.Forms.frmPOSTouch.txtNar.Text = "Ref : " + Me.ComboBox1.Text
					MyProject.Forms.frmPOSTouch.txtBarcode.Text = dataGridViewRow5.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSTouch.BarcodeProgram1()
					Try
						For Each obj2 As Object In Me.dgw.SelectedRows
							Dim dataGridViewRow6 As DataGridViewRow = CType(obj2, DataGridViewRow)
							Me.dgw.Rows.RemoveAt(dataGridViewRow6.Index)
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				Catch ex4 As Exception
				End Try
			End If
		End Sub

		' Token: 0x06002B66 RID: 11110 RVA: 0x001AB964 File Offset: 0x001A9B64
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
				Catch ex As Exception
				End Try
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
			If flag2 Then
				Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
				Catch ex2 As Exception
				End Try
			End If
		End Sub

		' Token: 0x06002B67 RID: 11111 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEstimateRetrieve_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002B68 RID: 11112 RVA: 0x0001BCB8 File Offset: 0x00019EB8
		Private Sub frmEstimateRetrieve_Closing(sender As Object, e As CancelEventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002B69 RID: 11113 RVA: 0x001ABA70 File Offset: 0x001A9C70
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
				Catch ex As Exception
				End Try
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
			If flag2 Then
				Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
				Catch ex2 As Exception
				End Try
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag3 Then
				Dim flag4 As Boolean = e.KeyCode = Keys.[Return]
				If flag4 Then
					Try
						Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow3.Cells(3).Value.ToString()
					Catch ex3 As Exception
					End Try
					Try
						Dim dataGridViewRow4 As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim text As String = dataGridViewRow4.Cells(24).Value.ToString()
						Dim flag5 As Boolean = Operators.CompareString(text, "Retail", False) = 0
						If flag5 Then
							MyProject.Forms.frmPOS.RadioButton1.Checked = True
							MyProject.Forms.frmPOS.RadioButton2.Checked = False
						Else
							Dim flag6 As Boolean = Operators.CompareString(text, "Wholesale", False) = 0
							If flag6 Then
								MyProject.Forms.frmPOS.RadioButton2.Checked = True
								MyProject.Forms.frmPOS.RadioButton1.Checked = False
							Else
								MyProject.Forms.frmPOS.RadioButton1.Checked = True
								MyProject.Forms.frmPOS.RadioButton2.Checked = False
							End If
						End If
						MyProject.Forms.frmPOS.txtNar.Text = "Ref : " + Me.ComboBox1.Text
						MyProject.Forms.frmPOS.txtBarcode.Text = dataGridViewRow4.Cells(23).Value.ToString()
						MyProject.Forms.frmPOS.BarcodeProgram1()
						Try
							For Each obj As Object In Me.dgw.SelectedRows
								Dim dataGridViewRow5 As DataGridViewRow = CType(obj, DataGridViewRow)
								Me.dgw.Rows.RemoveAt(dataGridViewRow5.Index)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					Catch ex4 As Exception
					End Try
				End If
			End If
			Dim flag7 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
			If flag7 Then
				Dim flag8 As Boolean = e.KeyCode = Keys.[Return]
				If flag8 Then
					Try
						Dim dataGridViewRow6 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow6.Cells(3).Value.ToString()
					Catch ex5 As Exception
					End Try
					Try
						Dim dataGridViewRow7 As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim text2 As String = dataGridViewRow7.Cells(24).Value.ToString()
						Dim flag9 As Boolean = Operators.CompareString(text2, "Retail", False) = 0
						If flag9 Then
							MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
							MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
						Else
							Dim flag10 As Boolean = Operators.CompareString(text2, "Wholesale", False) = 0
							If flag10 Then
								MyProject.Forms.frmPOSTouch.RadioButton2.Checked = True
								MyProject.Forms.frmPOSTouch.RadioButton1.Checked = False
							Else
								MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
								MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
							End If
						End If
						MyProject.Forms.frmPOSTouch.txtNar.Text = "Ref : " + Me.ComboBox1.Text
						MyProject.Forms.frmPOSTouch.txtBarcode.Text = dataGridViewRow7.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.BarcodeProgram1()
						Try
							For Each obj2 As Object In Me.dgw.SelectedRows
								Dim dataGridViewRow8 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Me.dgw.Rows.RemoveAt(dataGridViewRow8.Index)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Catch ex6 As Exception
					End Try
				End If
			End If
		End Sub
	End Class
End Namespace
