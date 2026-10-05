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
	' Token: 0x0200056A RID: 1386
	<DesignerGenerated()>
	Public Partial Class frmGSTCalc
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010D40 RID: 68928 RVA: 0x00073C54 File Offset: 0x00071E54
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTCalc_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGSTCalc_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006857 RID: 26711
		' (get) Token: 0x06010D43 RID: 68931 RVA: 0x00073C86 File Offset: 0x00071E86
		' (set) Token: 0x06010D44 RID: 68932 RVA: 0x00073C90 File Offset: 0x00071E90
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17006858 RID: 26712
		' (get) Token: 0x06010D45 RID: 68933 RVA: 0x00073C99 File Offset: 0x00071E99
		' (set) Token: 0x06010D46 RID: 68934 RVA: 0x00073CA3 File Offset: 0x00071EA3
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006859 RID: 26713
		' (get) Token: 0x06010D47 RID: 68935 RVA: 0x00073CAC File Offset: 0x00071EAC
		' (set) Token: 0x06010D48 RID: 68936 RVA: 0x00073CB6 File Offset: 0x00071EB6
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700685A RID: 26714
		' (get) Token: 0x06010D49 RID: 68937 RVA: 0x00073CBF File Offset: 0x00071EBF
		' (set) Token: 0x06010D4A RID: 68938 RVA: 0x00073CC9 File Offset: 0x00071EC9
		Friend Overridable Property Label2 As Label

		' Token: 0x1700685B RID: 26715
		' (get) Token: 0x06010D4B RID: 68939 RVA: 0x00073CD2 File Offset: 0x00071ED2
		' (set) Token: 0x06010D4C RID: 68940 RVA: 0x00073CDC File Offset: 0x00071EDC
		Friend Overridable Property Label4 As Label

		' Token: 0x1700685C RID: 26716
		' (get) Token: 0x06010D4D RID: 68941 RVA: 0x00073CE5 File Offset: 0x00071EE5
		' (set) Token: 0x06010D4E RID: 68942 RVA: 0x00073CEF File Offset: 0x00071EEF
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700685D RID: 26717
		' (get) Token: 0x06010D4F RID: 68943 RVA: 0x00073CF8 File Offset: 0x00071EF8
		' (set) Token: 0x06010D50 RID: 68944 RVA: 0x00073D02 File Offset: 0x00071F02
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700685E RID: 26718
		' (get) Token: 0x06010D51 RID: 68945 RVA: 0x00073D0B File Offset: 0x00071F0B
		' (set) Token: 0x06010D52 RID: 68946 RVA: 0x009CBF44 File Offset: 0x009CA144
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

		' Token: 0x1700685F RID: 26719
		' (get) Token: 0x06010D53 RID: 68947 RVA: 0x00073D15 File Offset: 0x00071F15
		' (set) Token: 0x06010D54 RID: 68948 RVA: 0x009CBF88 File Offset: 0x009CA188
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

		' Token: 0x17006860 RID: 26720
		' (get) Token: 0x06010D55 RID: 68949 RVA: 0x00073D1F File Offset: 0x00071F1F
		' (set) Token: 0x06010D56 RID: 68950 RVA: 0x009CBFCC File Offset: 0x009CA1CC
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

		' Token: 0x06010D57 RID: 68951 RVA: 0x009CC010 File Offset: 0x009CA210
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

		' Token: 0x06010D58 RID: 68952 RVA: 0x00073D29 File Offset: 0x00071F29
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DataGridView1.DataSource = Nothing
		End Sub

		' Token: 0x06010D59 RID: 68953 RVA: 0x009CC0EC File Offset: 0x009CA2EC
		Private Sub frmGSTCalc_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010D5A RID: 68954 RVA: 0x009CC174 File Offset: 0x009CA374
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

		' Token: 0x06010D5B RID: 68955 RVA: 0x009CC2EC File Offset: 0x009CA4EC
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

		' Token: 0x06010D5C RID: 68956 RVA: 0x009CC3A8 File Offset: 0x009CA5A8
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

		' Token: 0x06010D5D RID: 68957 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010D5E RID: 68958 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010D5F RID: 68959 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010D60 RID: 68960 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGSTCalc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010D61 RID: 68961 RVA: 0x009CC474 File Offset: 0x009CA674
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim text As String = Me.dtpDateFrom.Value.ToString("yyyy-MM-dd")
			Dim text2 As String = Me.dtpDateTo.Value.AddDays(1.0).ToString("yyyy-MM-dd")
			Try
				Me.DataGridView1.DataSource = Nothing
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "DECLARE @DynamicPivotQuery AS NVARCHAR(MAX), " & vbCrLf & "        @ColumnName AS NVARCHAR(MAX)," & vbCrLf & "        @startdate DATETIME," & vbCrLf & "        @enddate DATETIME;" & vbCrLf & vbCrLf & "-- Set the start and end dates" & vbCrLf & "SET @startdate = '", text, "';" & vbCrLf & "SET @enddate = '", text2, "';" & vbCrLf & vbCrLf & vbCrLf & "DECLARE @ParmDefinition NVARCHAR(500);" & vbCrLf & "SET @ParmDefinition = N'@startdt DATETIME, @enddt DATETIME';" & vbCrLf & vbCrLf & "-- Construct the column names dynamically" & vbCrLf & "SELECT @ColumnName = ISNULL(@ColumnName + ',', '') + QUOTENAME(CGSTPer)" & vbCrLf & "FROM (" & vbCrLf & "    SELECT DISTINCT CGSTPer" & vbCrLf & "    FROM Invoice_Product, InvoiceInfo" & vbCrLf & "    WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "      AND CGSTPer <> 0" & vbCrLf & "      AND InvoiceDate >= '", text, "'" & vbCrLf & "      AND InvoiceDate < '", text2, "'" & vbCrLf & "    UNION" & vbCrLf & "    SELECT DISTINCT SGSTPer" & vbCrLf & "    FROM Invoice_Product, InvoiceInfo" & vbCrLf & "    WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "      AND SGSTPer <> 0" & vbCrLf & "      AND InvoiceDate >= '", text, "'" & vbCrLf & "      AND InvoiceDate < '", text2, "'" & vbCrLf & "    UNION" & vbCrLf & "    SELECT DISTINCT IGSTPer" & vbCrLf & "    FROM Invoice_Product, InvoiceInfo" & vbCrLf & "    WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "      AND IGSTPer <> 0" & vbCrLf & "      AND InvoiceDate >= '", text, "'" & vbCrLf & "      AND InvoiceDate < '", text2, "'" & vbCrLf & "    UNION" & vbCrLf & "    SELECT DISTINCT CESSPer" & vbCrLf & "    FROM Invoice_Product, InvoiceInfo" & vbCrLf & "    WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "      AND CESSPer <> 0" & vbCrLf & "      AND InvoiceDate >= '", text, "'" & vbCrLf & "      AND InvoiceDate < '", text2, "'" & vbCrLf & ") AS Tax;" & vbCrLf & vbCrLf & "-- Construct the dynamic pivot query" & vbCrLf & "SET @DynamicPivotQuery = N'" & vbCrLf & "    SELECT ''CGST'' AS Tax, ' + @ColumnName + ', " & vbCrLf & "           (SELECT SUM(CGSTAmt) " & vbCrLf & "            FROM InvoiceInfo, Invoice_Product" & vbCrLf & "            WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "              AND InvoiceDate >= @startdt" & vbCrLf & "              AND InvoiceDate < @enddt) AS Total" & vbCrLf & "    FROM (" & vbCrLf & "        SELECT CGSTPer, CGSTAmt" & vbCrLf & "        FROM InvoiceInfo, Invoice_Product" & vbCrLf & "        WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "          AND InvoiceDate >= @startdt" & vbCrLf & "          AND InvoiceDate < @enddt" & vbCrLf & "    ) AS SourceTable" & vbCrLf & "    PIVOT (" & vbCrLf & "        SUM(CGSTAmt) FOR CGSTPer IN (' + @ColumnName + ')" & vbCrLf & "    ) AS PVTTable" & vbCrLf & "    UNION ALL" & vbCrLf & "    SELECT ''SGST'' AS Tax, ' + @ColumnName + '," & vbCrLf & "           (SELECT SUM(SGSTAmt) " & vbCrLf & "            FROM InvoiceInfo, Invoice_Product" & vbCrLf & "            WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "              AND InvoiceDate >= @startdt" & vbCrLf & "              AND InvoiceDate < @enddt) AS Total" & vbCrLf & "    FROM (" & vbCrLf & "        SELECT SGSTPer, SGSTAmt" & vbCrLf & "        FROM InvoiceInfo, Invoice_Product" & vbCrLf & "        WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "          AND InvoiceDate >= @startdt" & vbCrLf & "          AND InvoiceDate < @enddt" & vbCrLf & "    ) AS SourceTable" & vbCrLf & "    PIVOT (" & vbCrLf & "        SUM(SGSTAmt) FOR SGSTPer IN (' + @ColumnName + ')" & vbCrLf & "    ) AS PVTTable" & vbCrLf & "    UNION ALL" & vbCrLf & "    SELECT ''IGST'' AS Tax, ' + @ColumnName + '," & vbCrLf & "           (SELECT SUM(IGSTAmt) " & vbCrLf & "            FROM InvoiceInfo, Invoice_Product" & vbCrLf & "            WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "              AND InvoiceDate >= @startdt" & vbCrLf & "              AND InvoiceDate < @enddt) AS Total" & vbCrLf & "    FROM (" & vbCrLf & "        SELECT IGSTPer, IGSTAmt" & vbCrLf & "        FROM InvoiceInfo, Invoice_Product" & vbCrLf & "        WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "          AND InvoiceDate >= @startdt" & vbCrLf & "          AND InvoiceDate < @enddt" & vbCrLf & "    ) AS SourceTable" & vbCrLf & "    PIVOT (" & vbCrLf & "        SUM(IGSTAmt) FOR IGSTPer IN (' + @ColumnName + ')" & vbCrLf & "    ) AS PVTTable" & vbCrLf & "    UNION ALL" & vbCrLf & "    SELECT ''CESS'' AS Tax, ' + @ColumnName + '," & vbCrLf & "           (SELECT SUM(CESSAmt) " & vbCrLf & "            FROM InvoiceInfo, Invoice_Product" & vbCrLf & "            WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "              AND InvoiceDate >= @startdt" & vbCrLf & "              AND InvoiceDate < @enddt) AS Total" & vbCrLf & "    FROM (" & vbCrLf & "        SELECT CESSPer, CESSAmt" & vbCrLf & "        FROM InvoiceInfo, Invoice_Product" & vbCrLf & "        WHERE InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID" & vbCrLf & "          AND InvoiceDate >= @startdt" & vbCrLf & "          AND InvoiceDate < @enddt" & vbCrLf & "    ) AS SourceTable" & vbCrLf & "    PIVOT (" & vbCrLf & "        SUM(CESSAmt) FOR CESSPer IN (' + @ColumnName + ')" & vbCrLf & "    ) AS PVTTable';" & vbCrLf & vbCrLf & "-- Execute the dynamic query" & vbCrLf & "EXEC sp_executesql @DynamicPivotQuery, @ParmDefinition, @startdt = @startdate, @enddt = @enddate;" & vbCrLf }), ModCommonClasses.con)
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

		' Token: 0x06010D62 RID: 68962 RVA: 0x00073D51 File Offset: 0x00071F51
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010D63 RID: 68963 RVA: 0x009CC640 File Offset: 0x009CA840
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
