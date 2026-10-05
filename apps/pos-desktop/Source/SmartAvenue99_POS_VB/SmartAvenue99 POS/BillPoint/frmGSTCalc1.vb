Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C8 RID: 1224
	<DesignerGenerated()>
	Public Partial Class frmGSTCalc1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F637 RID: 63031 RVA: 0x0006BD53 File Offset: 0x00069F53
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTCalc1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGSTCalc1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005E2B RID: 24107
		' (get) Token: 0x0600F63A RID: 63034 RVA: 0x0006BD85 File Offset: 0x00069F85
		' (set) Token: 0x0600F63B RID: 63035 RVA: 0x0006BD8F File Offset: 0x00069F8F
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17005E2C RID: 24108
		' (get) Token: 0x0600F63C RID: 63036 RVA: 0x0006BD98 File Offset: 0x00069F98
		' (set) Token: 0x0600F63D RID: 63037 RVA: 0x0006BDA2 File Offset: 0x00069FA2
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005E2D RID: 24109
		' (get) Token: 0x0600F63E RID: 63038 RVA: 0x0006BDAB File Offset: 0x00069FAB
		' (set) Token: 0x0600F63F RID: 63039 RVA: 0x0006BDB5 File Offset: 0x00069FB5
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005E2E RID: 24110
		' (get) Token: 0x0600F640 RID: 63040 RVA: 0x0006BDBE File Offset: 0x00069FBE
		' (set) Token: 0x0600F641 RID: 63041 RVA: 0x0006BDC8 File Offset: 0x00069FC8
		Friend Overridable Property Label2 As Label

		' Token: 0x17005E2F RID: 24111
		' (get) Token: 0x0600F642 RID: 63042 RVA: 0x0006BDD1 File Offset: 0x00069FD1
		' (set) Token: 0x0600F643 RID: 63043 RVA: 0x0006BDDB File Offset: 0x00069FDB
		Friend Overridable Property Label4 As Label

		' Token: 0x17005E30 RID: 24112
		' (get) Token: 0x0600F644 RID: 63044 RVA: 0x0006BDE4 File Offset: 0x00069FE4
		' (set) Token: 0x0600F645 RID: 63045 RVA: 0x0006BDEE File Offset: 0x00069FEE
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005E31 RID: 24113
		' (get) Token: 0x0600F646 RID: 63046 RVA: 0x0006BDF7 File Offset: 0x00069FF7
		' (set) Token: 0x0600F647 RID: 63047 RVA: 0x0006BE01 File Offset: 0x0006A001
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005E32 RID: 24114
		' (get) Token: 0x0600F648 RID: 63048 RVA: 0x0006BE0A File Offset: 0x0006A00A
		' (set) Token: 0x0600F649 RID: 63049 RVA: 0x0006BE14 File Offset: 0x0006A014
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005E33 RID: 24115
		' (get) Token: 0x0600F64A RID: 63050 RVA: 0x0006BE1D File Offset: 0x0006A01D
		' (set) Token: 0x0600F64B RID: 63051 RVA: 0x009395A4 File Offset: 0x009377A4
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

		' Token: 0x17005E34 RID: 24116
		' (get) Token: 0x0600F64C RID: 63052 RVA: 0x0006BE27 File Offset: 0x0006A027
		' (set) Token: 0x0600F64D RID: 63053 RVA: 0x009395E8 File Offset: 0x009377E8
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E35 RID: 24117
		' (get) Token: 0x0600F64E RID: 63054 RVA: 0x0006BE31 File Offset: 0x0006A031
		' (set) Token: 0x0600F64F RID: 63055 RVA: 0x0093962C File Offset: 0x0093782C
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

		' Token: 0x0600F650 RID: 63056 RVA: 0x00939670 File Offset: 0x00937870
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600F651 RID: 63057 RVA: 0x0006BE3B File Offset: 0x0006A03B
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DataGridView1.DataSource = Nothing
		End Sub

		' Token: 0x0600F652 RID: 63058 RVA: 0x0093974C File Offset: 0x0093794C
		Private Sub frmGSTCalc1_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F653 RID: 63059 RVA: 0x009397D4 File Offset: 0x009379D4
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600F654 RID: 63060 RVA: 0x0093994C File Offset: 0x00937B4C
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F655 RID: 63061 RVA: 0x00939A08 File Offset: 0x00937C08
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F656 RID: 63062 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F657 RID: 63063 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F658 RID: 63064 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F659 RID: 63065 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGSTCalc1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F65A RID: 63066 RVA: 0x00939AD4 File Offset: 0x00937CD4
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim text As String = Me.dtpDateFrom.Value.ToString("yyyy-MM-dd")
			Dim text2 As String = Me.dtpDateTo.Value.AddDays(1.0).ToString("yyyy-MM-dd")
			Try
				Me.DataGridView1.DataSource = Nothing
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "DECLARE @DynamicPivotQuery AS NVARCHAR(MAX)," & vbCrLf & "        @ColumnName AS NVARCHAR(MAX)," & vbCrLf & "        @startdate DATETIME," & vbCrLf & "        @enddate DATETIME;" & vbCrLf & vbCrLf & "-- Set the start and end dates" & vbCrLf & "SET @startdate = '", text, "';" & vbCrLf & "SET @enddate = '", text2, "';" & vbCrLf & vbCrLf & "-- Declare parameter definition" & vbCrLf & "DECLARE @ParmDefinition NVARCHAR(500);" & vbCrLf & "SET @ParmDefinition = N'@startdt DATETIME, @enddt DATETIME';" & vbCrLf & vbCrLf & "-- Generate the dynamic column names for pivot" & vbCrLf & "SELECT @ColumnName = ISNULL(@ColumnName + ',', '') + QUOTENAME(CGSTPer)" & vbCrLf & "FROM (" & vbCrLf & "    SELECT DISTINCT CGSTPer " & vbCrLf & "    FROM Stock_Product, Stock" & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID" & vbCrLf & "      AND CGSTPer <> 0" & vbCrLf & "      AND Date >= '", text, "'" & vbCrLf & "      AND Date < '", text2, "'" & vbCrLf & vbCrLf & "    UNION" & vbCrLf & vbCrLf & "    SELECT DISTINCT SGSTPer " & vbCrLf & "    FROM Stock_Product, Stock" & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID" & vbCrLf & "      AND SGSTPer <> 0" & vbCrLf & "      AND Date >= '", text, "'" & vbCrLf & "      AND Date < '", text2, "'" & vbCrLf & vbCrLf & "    UNION" & vbCrLf & vbCrLf & "    SELECT DISTINCT IGSTPer " & vbCrLf & "    FROM Stock_Product, Stock" & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID" & vbCrLf & "      AND IGSTPer <> 0" & vbCrLf & "      AND Date >= '", text, "'" & vbCrLf & "      AND Date < '", text2, "'" & vbCrLf & vbCrLf & "    UNION" & vbCrLf & vbCrLf & "    SELECT DISTINCT CESSPer " & vbCrLf & "    FROM Stock_Product, Stock" & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID" & vbCrLf & "      AND CESSPer <> 0" & vbCrLf & "      AND Date >= '", text, "'" & vbCrLf & "      AND Date < '", text2, "'" & vbCrLf & ") AS Tax;" & vbCrLf & vbCrLf & "-- Build the dynamic pivot query" & vbCrLf & "SET @DynamicPivotQuery = N'" & vbCrLf & "SELECT ''CGST'' AS Tax, ' + @ColumnName + ', " & vbCrLf & "       (SELECT SUM(CGSTAmt) " & vbCrLf & "        FROM Stock, Stock_Product " & vbCrLf & "        WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "          AND Date >= @startdt " & vbCrLf & "          AND Date < @enddt) AS Total" & vbCrLf & "FROM (" & vbCrLf & "    SELECT CGSTPer, CGSTAmt " & vbCrLf & "    FROM Stock, Stock_Product " & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "      AND Date >= @startdt " & vbCrLf & "      AND Date < @enddt" & vbCrLf & ") AS SourceTable" & vbCrLf & "PIVOT (" & vbCrLf & "    SUM(CGSTAmt) FOR CGSTPer IN (' + @ColumnName + ')" & vbCrLf & ") AS PVTTable" & vbCrLf & vbCrLf & "UNION ALL" & vbCrLf & vbCrLf & "SELECT ''SGST'' AS Tax, ' + @ColumnName + ', " & vbCrLf & "       (SELECT SUM(SGSTAmt) " & vbCrLf & "        FROM Stock, Stock_Product " & vbCrLf & "        WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "          AND Date >= @startdt " & vbCrLf & "          AND Date < @enddt) AS Total" & vbCrLf & "FROM (" & vbCrLf & "    SELECT SGSTPer, SGSTAmt " & vbCrLf & "    FROM Stock, Stock_Product " & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "      AND Date >= @startdt " & vbCrLf & "      AND Date < @enddt" & vbCrLf & ") AS SourceTable" & vbCrLf & "PIVOT (" & vbCrLf & "    SUM(SGSTAmt) FOR SGSTPer IN (' + @ColumnName + ')" & vbCrLf & ") AS PVTTable" & vbCrLf & vbCrLf & "UNION ALL" & vbCrLf & vbCrLf & "SELECT ''IGST'' AS Tax, ' + @ColumnName + ', " & vbCrLf & "       (SELECT SUM(IGSTAmt) " & vbCrLf & "        FROM Stock, Stock_Product " & vbCrLf & "        WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "          AND Date >= @startdt " & vbCrLf & "          AND Date < @enddt) AS Total" & vbCrLf & "FROM (" & vbCrLf & "    SELECT IGSTPer, IGSTAmt " & vbCrLf & "    FROM Stock, Stock_Product " & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "      AND Date >= @startdt " & vbCrLf & "      AND Date < @enddt" & vbCrLf & ") AS SourceTable" & vbCrLf & "PIVOT (" & vbCrLf & "    SUM(IGSTAmt) FOR IGSTPer IN (' + @ColumnName + ')" & vbCrLf & ") AS PVTTable" & vbCrLf & vbCrLf & "UNION ALL" & vbCrLf & vbCrLf & "SELECT ''CESS'' AS Tax, ' + @ColumnName + ', " & vbCrLf & "       (SELECT SUM(CESSAmt) " & vbCrLf & "        FROM Stock, Stock_Product " & vbCrLf & "        WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "          AND Date >= @startdt " & vbCrLf & "          AND Date < @enddt) AS Total" & vbCrLf & "FROM (" & vbCrLf & "    SELECT CESSPer, CESSAmt " & vbCrLf & "    FROM Stock, Stock_Product " & vbCrLf & "    WHERE Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "      AND Date >= @startdt " & vbCrLf & "      AND Date < @enddt" & vbCrLf & ") AS SourceTable" & vbCrLf & "PIVOT (" & vbCrLf & "    SUM(CESSAmt) FOR CESSPer IN (' + @ColumnName + ')" & vbCrLf & ") AS PVTTable';" & vbCrLf & vbCrLf & "-- Execute the dynamic query" & vbCrLf & "EXEC sp_executesql @DynamicPivotQuery, @ParmDefinition, @startdt = @startdate, @enddt = @enddate;" & vbCrLf }), ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				Me.DataGridView1.DataSource = ModCommonClasses.ds.Tables(0)
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F65B RID: 63067 RVA: 0x0006BE63 File Offset: 0x0006A063
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F65C RID: 63068 RVA: 0x00939CA0 File Offset: 0x00937EA0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
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
	End Class
End Namespace
