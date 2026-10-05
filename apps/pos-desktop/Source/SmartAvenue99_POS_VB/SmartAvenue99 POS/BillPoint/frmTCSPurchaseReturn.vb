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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004E2 RID: 1250
	<DesignerGenerated()>
	Public Partial Class frmTCSPurchaseReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FF17 RID: 65303 RVA: 0x0006FD78 File Offset: 0x0006DF78
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTCSPurchaseReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTCSPurchaseReturn_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700617E RID: 24958
		' (get) Token: 0x0600FF1A RID: 65306 RVA: 0x0006FDAA File Offset: 0x0006DFAA
		' (set) Token: 0x0600FF1B RID: 65307 RVA: 0x0006FDB4 File Offset: 0x0006DFB4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700617F RID: 24959
		' (get) Token: 0x0600FF1C RID: 65308 RVA: 0x0006FDBD File Offset: 0x0006DFBD
		' (set) Token: 0x0600FF1D RID: 65309 RVA: 0x00986C08 File Offset: 0x00984E08
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

		' Token: 0x17006180 RID: 24960
		' (get) Token: 0x0600FF1E RID: 65310 RVA: 0x0006FDC7 File Offset: 0x0006DFC7
		' (set) Token: 0x0600FF1F RID: 65311 RVA: 0x0006FDD1 File Offset: 0x0006DFD1
		Friend Overridable Property Label3 As Label

		' Token: 0x17006181 RID: 24961
		' (get) Token: 0x0600FF20 RID: 65312 RVA: 0x0006FDDA File Offset: 0x0006DFDA
		' (set) Token: 0x0600FF21 RID: 65313 RVA: 0x0006FDE4 File Offset: 0x0006DFE4
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006182 RID: 24962
		' (get) Token: 0x0600FF22 RID: 65314 RVA: 0x0006FDED File Offset: 0x0006DFED
		' (set) Token: 0x0600FF23 RID: 65315 RVA: 0x0006FDF7 File Offset: 0x0006DFF7
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006183 RID: 24963
		' (get) Token: 0x0600FF24 RID: 65316 RVA: 0x0006FE00 File Offset: 0x0006E000
		' (set) Token: 0x0600FF25 RID: 65317 RVA: 0x0006FE0A File Offset: 0x0006E00A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006184 RID: 24964
		' (get) Token: 0x0600FF26 RID: 65318 RVA: 0x0006FE13 File Offset: 0x0006E013
		' (set) Token: 0x0600FF27 RID: 65319 RVA: 0x0006FE1D File Offset: 0x0006E01D
		Friend Overridable Property Label2 As Label

		' Token: 0x17006185 RID: 24965
		' (get) Token: 0x0600FF28 RID: 65320 RVA: 0x0006FE26 File Offset: 0x0006E026
		' (set) Token: 0x0600FF29 RID: 65321 RVA: 0x00986C4C File Offset: 0x00984E4C
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006186 RID: 24966
		' (get) Token: 0x0600FF2A RID: 65322 RVA: 0x0006FE30 File Offset: 0x0006E030
		' (set) Token: 0x0600FF2B RID: 65323 RVA: 0x0006FE3A File Offset: 0x0006E03A
		Friend Overridable Property Label4 As Label

		' Token: 0x17006187 RID: 24967
		' (get) Token: 0x0600FF2C RID: 65324 RVA: 0x0006FE43 File Offset: 0x0006E043
		' (set) Token: 0x0600FF2D RID: 65325 RVA: 0x0006FE4D File Offset: 0x0006E04D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006188 RID: 24968
		' (get) Token: 0x0600FF2E RID: 65326 RVA: 0x0006FE56 File Offset: 0x0006E056
		' (set) Token: 0x0600FF2F RID: 65327 RVA: 0x0006FE60 File Offset: 0x0006E060
		Friend Overridable Property Label1 As Label

		' Token: 0x17006189 RID: 24969
		' (get) Token: 0x0600FF30 RID: 65328 RVA: 0x0006FE69 File Offset: 0x0006E069
		' (set) Token: 0x0600FF31 RID: 65329 RVA: 0x00986C90 File Offset: 0x00984E90
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700618A RID: 24970
		' (get) Token: 0x0600FF32 RID: 65330 RVA: 0x0006FE73 File Offset: 0x0006E073
		' (set) Token: 0x0600FF33 RID: 65331 RVA: 0x0006FE7D File Offset: 0x0006E07D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700618B RID: 24971
		' (get) Token: 0x0600FF34 RID: 65332 RVA: 0x0006FE86 File Offset: 0x0006E086
		' (set) Token: 0x0600FF35 RID: 65333 RVA: 0x0006FE90 File Offset: 0x0006E090
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700618C RID: 24972
		' (get) Token: 0x0600FF36 RID: 65334 RVA: 0x0006FE99 File Offset: 0x0006E099
		' (set) Token: 0x0600FF37 RID: 65335 RVA: 0x0006FEA3 File Offset: 0x0006E0A3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700618D RID: 24973
		' (get) Token: 0x0600FF38 RID: 65336 RVA: 0x0006FEAC File Offset: 0x0006E0AC
		' (set) Token: 0x0600FF39 RID: 65337 RVA: 0x0006FEB6 File Offset: 0x0006E0B6
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700618E RID: 24974
		' (get) Token: 0x0600FF3A RID: 65338 RVA: 0x0006FEBF File Offset: 0x0006E0BF
		' (set) Token: 0x0600FF3B RID: 65339 RVA: 0x0006FEC9 File Offset: 0x0006E0C9
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700618F RID: 24975
		' (get) Token: 0x0600FF3C RID: 65340 RVA: 0x0006FED2 File Offset: 0x0006E0D2
		' (set) Token: 0x0600FF3D RID: 65341 RVA: 0x0006FEDC File Offset: 0x0006E0DC
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006190 RID: 24976
		' (get) Token: 0x0600FF3E RID: 65342 RVA: 0x0006FEE5 File Offset: 0x0006E0E5
		' (set) Token: 0x0600FF3F RID: 65343 RVA: 0x0006FEEF File Offset: 0x0006E0EF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006191 RID: 24977
		' (get) Token: 0x0600FF40 RID: 65344 RVA: 0x0006FEF8 File Offset: 0x0006E0F8
		' (set) Token: 0x0600FF41 RID: 65345 RVA: 0x0006FF02 File Offset: 0x0006E102
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006192 RID: 24978
		' (get) Token: 0x0600FF42 RID: 65346 RVA: 0x0006FF0B File Offset: 0x0006E10B
		' (set) Token: 0x0600FF43 RID: 65347 RVA: 0x0006FF15 File Offset: 0x0006E115
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006193 RID: 24979
		' (get) Token: 0x0600FF44 RID: 65348 RVA: 0x0006FF1E File Offset: 0x0006E11E
		' (set) Token: 0x0600FF45 RID: 65349 RVA: 0x0006FF28 File Offset: 0x0006E128
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600FF46 RID: 65350 RVA: 0x00986CD4 File Offset: 0x00984ED4
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

		' Token: 0x0600FF47 RID: 65351 RVA: 0x00986DB0 File Offset: 0x00984FB0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date, RTRIM(InvoiceNo),Stock.Date, RTRIM(Supplier.SupplierID),RTRIM(Name), PurchaseReturn.FreightCharges, RTRIM(PurchaseReturn.BillSundry) FROM Stock,PurchaseReturn,Supplier where Stock.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Stock.SupplierID and PurchaseReturn.BillSundry='TCS' and PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FF48 RID: 65352 RVA: 0x00986F88 File Offset: 0x00985188
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

		' Token: 0x0600FF49 RID: 65353 RVA: 0x00987070 File Offset: 0x00985270
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600FF4A RID: 65354 RVA: 0x00987180 File Offset: 0x00985380
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

		' Token: 0x0600FF4B RID: 65355 RVA: 0x0098742C File Offset: 0x0098562C
		Private Sub frmTCSPurchaseReturn_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FF4C RID: 65356 RVA: 0x009874B4 File Offset: 0x009856B4
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

		' Token: 0x0600FF4D RID: 65357 RVA: 0x0098762C File Offset: 0x0098582C
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

		' Token: 0x0600FF4E RID: 65358 RVA: 0x009876E8 File Offset: 0x009858E8
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

		' Token: 0x0600FF4F RID: 65359 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FF50 RID: 65360 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FF51 RID: 65361 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FF52 RID: 65362 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTCSPurchaseReturn_KeyDown(sender As Object, e As KeyEventArgs)
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
