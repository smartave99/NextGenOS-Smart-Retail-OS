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
	' Token: 0x02000204 RID: 516
	<DesignerGenerated()>
	Public Partial Class frmQuotationRetrieve
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060094A3 RID: 38051 RVA: 0x006B34D4 File Offset: 0x006B16D4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmQuotationRetrieve_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmQuotationRetrieve_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmQuotationRetrieve_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700372F RID: 14127
		' (get) Token: 0x060094A6 RID: 38054 RVA: 0x00048CBA File Offset: 0x00046EBA
		' (set) Token: 0x060094A7 RID: 38055 RVA: 0x00048CC4 File Offset: 0x00046EC4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003730 RID: 14128
		' (get) Token: 0x060094A8 RID: 38056 RVA: 0x00048CCD File Offset: 0x00046ECD
		' (set) Token: 0x060094A9 RID: 38057 RVA: 0x00048CD7 File Offset: 0x00046ED7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17003731 RID: 14129
		' (get) Token: 0x060094AA RID: 38058 RVA: 0x00048CE0 File Offset: 0x00046EE0
		' (set) Token: 0x060094AB RID: 38059 RVA: 0x006B4964 File Offset: 0x006B2B64
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

		' Token: 0x17003732 RID: 14130
		' (get) Token: 0x060094AC RID: 38060 RVA: 0x00048CEA File Offset: 0x00046EEA
		' (set) Token: 0x060094AD RID: 38061 RVA: 0x006B49A8 File Offset: 0x006B2BA8
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

		' Token: 0x17003733 RID: 14131
		' (get) Token: 0x060094AE RID: 38062 RVA: 0x00048CF4 File Offset: 0x00046EF4
		' (set) Token: 0x060094AF RID: 38063 RVA: 0x006B49EC File Offset: 0x006B2BEC
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

		' Token: 0x17003734 RID: 14132
		' (get) Token: 0x060094B0 RID: 38064 RVA: 0x00048CFE File Offset: 0x00046EFE
		' (set) Token: 0x060094B1 RID: 38065 RVA: 0x00048D08 File Offset: 0x00046F08
		Friend Overridable Property Label5 As Label

		' Token: 0x17003735 RID: 14133
		' (get) Token: 0x060094B2 RID: 38066 RVA: 0x00048D11 File Offset: 0x00046F11
		' (set) Token: 0x060094B3 RID: 38067 RVA: 0x006B4A30 File Offset: 0x006B2C30
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

		' Token: 0x17003736 RID: 14134
		' (get) Token: 0x060094B4 RID: 38068 RVA: 0x00048D1B File Offset: 0x00046F1B
		' (set) Token: 0x060094B5 RID: 38069 RVA: 0x00048D25 File Offset: 0x00046F25
		Friend Overridable Property Label1 As Label

		' Token: 0x17003737 RID: 14135
		' (get) Token: 0x060094B6 RID: 38070 RVA: 0x00048D2E File Offset: 0x00046F2E
		' (set) Token: 0x060094B7 RID: 38071 RVA: 0x00048D38 File Offset: 0x00046F38
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003738 RID: 14136
		' (get) Token: 0x060094B8 RID: 38072 RVA: 0x00048D41 File Offset: 0x00046F41
		' (set) Token: 0x060094B9 RID: 38073 RVA: 0x00048D4B File Offset: 0x00046F4B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003739 RID: 14137
		' (get) Token: 0x060094BA RID: 38074 RVA: 0x00048D54 File Offset: 0x00046F54
		' (set) Token: 0x060094BB RID: 38075 RVA: 0x00048D5E File Offset: 0x00046F5E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700373A RID: 14138
		' (get) Token: 0x060094BC RID: 38076 RVA: 0x00048D67 File Offset: 0x00046F67
		' (set) Token: 0x060094BD RID: 38077 RVA: 0x00048D71 File Offset: 0x00046F71
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700373B RID: 14139
		' (get) Token: 0x060094BE RID: 38078 RVA: 0x00048D7A File Offset: 0x00046F7A
		' (set) Token: 0x060094BF RID: 38079 RVA: 0x00048D84 File Offset: 0x00046F84
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700373C RID: 14140
		' (get) Token: 0x060094C0 RID: 38080 RVA: 0x00048D8D File Offset: 0x00046F8D
		' (set) Token: 0x060094C1 RID: 38081 RVA: 0x00048D97 File Offset: 0x00046F97
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700373D RID: 14141
		' (get) Token: 0x060094C2 RID: 38082 RVA: 0x00048DA0 File Offset: 0x00046FA0
		' (set) Token: 0x060094C3 RID: 38083 RVA: 0x00048DAA File Offset: 0x00046FAA
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700373E RID: 14142
		' (get) Token: 0x060094C4 RID: 38084 RVA: 0x00048DB3 File Offset: 0x00046FB3
		' (set) Token: 0x060094C5 RID: 38085 RVA: 0x00048DBD File Offset: 0x00046FBD
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700373F RID: 14143
		' (get) Token: 0x060094C6 RID: 38086 RVA: 0x00048DC6 File Offset: 0x00046FC6
		' (set) Token: 0x060094C7 RID: 38087 RVA: 0x00048DD0 File Offset: 0x00046FD0
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003740 RID: 14144
		' (get) Token: 0x060094C8 RID: 38088 RVA: 0x00048DD9 File Offset: 0x00046FD9
		' (set) Token: 0x060094C9 RID: 38089 RVA: 0x00048DE3 File Offset: 0x00046FE3
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003741 RID: 14145
		' (get) Token: 0x060094CA RID: 38090 RVA: 0x00048DEC File Offset: 0x00046FEC
		' (set) Token: 0x060094CB RID: 38091 RVA: 0x00048DF6 File Offset: 0x00046FF6
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003742 RID: 14146
		' (get) Token: 0x060094CC RID: 38092 RVA: 0x00048DFF File Offset: 0x00046FFF
		' (set) Token: 0x060094CD RID: 38093 RVA: 0x00048E09 File Offset: 0x00047009
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003743 RID: 14147
		' (get) Token: 0x060094CE RID: 38094 RVA: 0x00048E12 File Offset: 0x00047012
		' (set) Token: 0x060094CF RID: 38095 RVA: 0x00048E1C File Offset: 0x0004701C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003744 RID: 14148
		' (get) Token: 0x060094D0 RID: 38096 RVA: 0x00048E25 File Offset: 0x00047025
		' (set) Token: 0x060094D1 RID: 38097 RVA: 0x00048E2F File Offset: 0x0004702F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003745 RID: 14149
		' (get) Token: 0x060094D2 RID: 38098 RVA: 0x00048E38 File Offset: 0x00047038
		' (set) Token: 0x060094D3 RID: 38099 RVA: 0x00048E42 File Offset: 0x00047042
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003746 RID: 14150
		' (get) Token: 0x060094D4 RID: 38100 RVA: 0x00048E4B File Offset: 0x0004704B
		' (set) Token: 0x060094D5 RID: 38101 RVA: 0x00048E55 File Offset: 0x00047055
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003747 RID: 14151
		' (get) Token: 0x060094D6 RID: 38102 RVA: 0x00048E5E File Offset: 0x0004705E
		' (set) Token: 0x060094D7 RID: 38103 RVA: 0x00048E68 File Offset: 0x00047068
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003748 RID: 14152
		' (get) Token: 0x060094D8 RID: 38104 RVA: 0x00048E71 File Offset: 0x00047071
		' (set) Token: 0x060094D9 RID: 38105 RVA: 0x00048E7B File Offset: 0x0004707B
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003749 RID: 14153
		' (get) Token: 0x060094DA RID: 38106 RVA: 0x00048E84 File Offset: 0x00047084
		' (set) Token: 0x060094DB RID: 38107 RVA: 0x00048E8E File Offset: 0x0004708E
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700374A RID: 14154
		' (get) Token: 0x060094DC RID: 38108 RVA: 0x00048E97 File Offset: 0x00047097
		' (set) Token: 0x060094DD RID: 38109 RVA: 0x00048EA1 File Offset: 0x000470A1
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700374B RID: 14155
		' (get) Token: 0x060094DE RID: 38110 RVA: 0x00048EAA File Offset: 0x000470AA
		' (set) Token: 0x060094DF RID: 38111 RVA: 0x00048EB4 File Offset: 0x000470B4
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700374C RID: 14156
		' (get) Token: 0x060094E0 RID: 38112 RVA: 0x00048EBD File Offset: 0x000470BD
		' (set) Token: 0x060094E1 RID: 38113 RVA: 0x00048EC7 File Offset: 0x000470C7
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700374D RID: 14157
		' (get) Token: 0x060094E2 RID: 38114 RVA: 0x00048ED0 File Offset: 0x000470D0
		' (set) Token: 0x060094E3 RID: 38115 RVA: 0x00048EDA File Offset: 0x000470DA
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700374E RID: 14158
		' (get) Token: 0x060094E4 RID: 38116 RVA: 0x00048EE3 File Offset: 0x000470E3
		' (set) Token: 0x060094E5 RID: 38117 RVA: 0x00048EED File Offset: 0x000470ED
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700374F RID: 14159
		' (get) Token: 0x060094E6 RID: 38118 RVA: 0x00048EF6 File Offset: 0x000470F6
		' (set) Token: 0x060094E7 RID: 38119 RVA: 0x00048F00 File Offset: 0x00047100
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17003750 RID: 14160
		' (get) Token: 0x060094E8 RID: 38120 RVA: 0x00048F09 File Offset: 0x00047109
		' (set) Token: 0x060094E9 RID: 38121 RVA: 0x00048F13 File Offset: 0x00047113
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003751 RID: 14161
		' (get) Token: 0x060094EA RID: 38122 RVA: 0x00048F1C File Offset: 0x0004711C
		' (set) Token: 0x060094EB RID: 38123 RVA: 0x00048F26 File Offset: 0x00047126
		Friend Overridable Property Label2 As Label

		' Token: 0x060094EC RID: 38124 RVA: 0x006B4AD0 File Offset: 0x006B2CD0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Quotation.QuotationNo), Quotation.Date, RTRIM(Quotation.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), Quotation_Join.Price, Quotation_Join.Qty, RTRIM(SalesUnit),Quotation_Join.DiscountPer, Quotation_Join.DiscountAmt, Quotation_Join.CGSTPer, Quotation_Join.CGSTAmt, Quotation_Join.SGSTPer, Quotation_Join.SGSTAmt, Quotation_Join.IGSTPer, Quotation_Join.IGSTAmt, Quotation_Join.CESSPer, Quotation_Join.CESSAmt, Quotation_Join.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Quotation_Join.Barcode), RTRIM(Quotation.CType) FROM Quotation INNER JOIN Quotation_Join ON Quotation.Q_ID = Quotation_Join.QuotationID INNER JOIN Product ON Quotation_Join.ProductID = Product.PID INNER JOIN Customer ON Quotation.CustomerID = Customer.ID where Quotation.QuotationNo ='" + Me.ComboBox1.Text + "'", ModCommonClasses.con)
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

		' Token: 0x060094ED RID: 38125 RVA: 0x006B4D38 File Offset: 0x006B2F38
		Private Sub frmQuotationRetrieve_Load(sender As Object, e As EventArgs)
			Me.fillEstimateNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
		End Sub

		' Token: 0x060094EE RID: 38126 RVA: 0x006B4DC4 File Offset: 0x006B2FC4
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

		' Token: 0x060094EF RID: 38127 RVA: 0x00048F2F File Offset: 0x0004712F
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x060094F0 RID: 38128 RVA: 0x00048F46 File Offset: 0x00047146
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060094F1 RID: 38129 RVA: 0x006B4EAC File Offset: 0x006B30AC
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

		' Token: 0x060094F2 RID: 38130 RVA: 0x006B5158 File Offset: 0x006B3358
		Public Sub fillEstimateNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(QuotationNo) FROM Quotation", ModCommonClasses.con)
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

		' Token: 0x060094F3 RID: 38131 RVA: 0x00048F50 File Offset: 0x00047150
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060094F4 RID: 38132 RVA: 0x006B528C File Offset: 0x006B348C
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
				If flag2 Then
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
				End If
			Catch ex As Exception
			End Try
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
					MyProject.Forms.frmPOS.BarcodeProgram2()
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
				Catch ex2 As Exception
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
					MyProject.Forms.frmPOSTouch.BarcodeProgram2()
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
				Catch ex3 As Exception
				End Try
			End If
		End Sub

		' Token: 0x060094F5 RID: 38133 RVA: 0x006B57AC File Offset: 0x006B39AC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
				If flag2 Then
					Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060094F6 RID: 38134 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmQuotationRetrieve_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060094F7 RID: 38135 RVA: 0x00048F46 File Offset: 0x00047146
		Private Sub frmQuotationRetrieve_Closing(sender As Object, e As CancelEventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060094F8 RID: 38136 RVA: 0x006B5898 File Offset: 0x006B3A98
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(3).Value.ToString()
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
					If flag3 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow2.Cells(3).Value.ToString()
					End If
				Catch ex As Exception
				End Try
				Try
					Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.SelectedRows(0)
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow3.Cells(3).Value.ToString()
				Catch ex2 As Exception
				End Try
				Dim flag4 As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
				If flag4 Then
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
						MyProject.Forms.frmPOS.BarcodeProgram2()
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
					Catch ex3 As Exception
					End Try
				End If
				Dim flag7 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
				If flag7 Then
					Try
						Dim dataGridViewRow6 As DataGridViewRow = Me.dgw.SelectedRows(0)
						Dim text2 As String = dataGridViewRow6.Cells(24).Value.ToString()
						Dim flag8 As Boolean = Operators.CompareString(text2, "Retail", False) = 0
						If flag8 Then
							MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
							MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
						Else
							Dim flag9 As Boolean = Operators.CompareString(text2, "Wholesale", False) = 0
							If flag9 Then
								MyProject.Forms.frmPOSTouch.RadioButton2.Checked = True
								MyProject.Forms.frmPOSTouch.RadioButton1.Checked = False
							Else
								MyProject.Forms.frmPOSTouch.RadioButton1.Checked = True
								MyProject.Forms.frmPOSTouch.RadioButton2.Checked = False
							End If
						End If
						MyProject.Forms.frmPOSTouch.txtNar.Text = "Ref : " + Me.ComboBox1.Text
						MyProject.Forms.frmPOSTouch.txtBarcode.Text = dataGridViewRow6.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.BarcodeProgram2()
						Try
							For Each obj2 As Object In Me.dgw.SelectedRows
								Dim dataGridViewRow7 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Me.dgw.Rows.RemoveAt(dataGridViewRow7.Index)
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
			End If
		End Sub
	End Class
End Namespace
