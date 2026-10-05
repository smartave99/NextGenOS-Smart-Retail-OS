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
	' Token: 0x020004E1 RID: 1249
	<DesignerGenerated()>
	Public Partial Class frmTCSPurchase
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FEDC RID: 65244 RVA: 0x0006FBC8 File Offset: 0x0006DDC8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTCSPurchase_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTCSPurchase_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006169 RID: 24937
		' (get) Token: 0x0600FEDF RID: 65247 RVA: 0x0006FBFA File Offset: 0x0006DDFA
		' (set) Token: 0x0600FEE0 RID: 65248 RVA: 0x0006FC04 File Offset: 0x0006DE04
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700616A RID: 24938
		' (get) Token: 0x0600FEE1 RID: 65249 RVA: 0x0006FC0D File Offset: 0x0006DE0D
		' (set) Token: 0x0600FEE2 RID: 65250 RVA: 0x0006FC17 File Offset: 0x0006DE17
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700616B RID: 24939
		' (get) Token: 0x0600FEE3 RID: 65251 RVA: 0x0006FC20 File Offset: 0x0006DE20
		' (set) Token: 0x0600FEE4 RID: 65252 RVA: 0x0006FC2A File Offset: 0x0006DE2A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700616C RID: 24940
		' (get) Token: 0x0600FEE5 RID: 65253 RVA: 0x0006FC33 File Offset: 0x0006DE33
		' (set) Token: 0x0600FEE6 RID: 65254 RVA: 0x0006FC3D File Offset: 0x0006DE3D
		Friend Overridable Property Label2 As Label

		' Token: 0x1700616D RID: 24941
		' (get) Token: 0x0600FEE7 RID: 65255 RVA: 0x0006FC46 File Offset: 0x0006DE46
		' (set) Token: 0x0600FEE8 RID: 65256 RVA: 0x009850AC File Offset: 0x009832AC
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

		' Token: 0x1700616E RID: 24942
		' (get) Token: 0x0600FEE9 RID: 65257 RVA: 0x0006FC50 File Offset: 0x0006DE50
		' (set) Token: 0x0600FEEA RID: 65258 RVA: 0x0006FC5A File Offset: 0x0006DE5A
		Friend Overridable Property Label4 As Label

		' Token: 0x1700616F RID: 24943
		' (get) Token: 0x0600FEEB RID: 65259 RVA: 0x0006FC63 File Offset: 0x0006DE63
		' (set) Token: 0x0600FEEC RID: 65260 RVA: 0x0006FC6D File Offset: 0x0006DE6D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006170 RID: 24944
		' (get) Token: 0x0600FEED RID: 65261 RVA: 0x0006FC76 File Offset: 0x0006DE76
		' (set) Token: 0x0600FEEE RID: 65262 RVA: 0x0006FC80 File Offset: 0x0006DE80
		Friend Overridable Property Label1 As Label

		' Token: 0x17006171 RID: 24945
		' (get) Token: 0x0600FEEF RID: 65263 RVA: 0x0006FC89 File Offset: 0x0006DE89
		' (set) Token: 0x0600FEF0 RID: 65264 RVA: 0x009850F0 File Offset: 0x009832F0
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

		' Token: 0x17006172 RID: 24946
		' (get) Token: 0x0600FEF1 RID: 65265 RVA: 0x0006FC93 File Offset: 0x0006DE93
		' (set) Token: 0x0600FEF2 RID: 65266 RVA: 0x0006FC9D File Offset: 0x0006DE9D
		Friend Overridable Property Label3 As Label

		' Token: 0x17006173 RID: 24947
		' (get) Token: 0x0600FEF3 RID: 65267 RVA: 0x0006FCA6 File Offset: 0x0006DEA6
		' (set) Token: 0x0600FEF4 RID: 65268 RVA: 0x0006FCB0 File Offset: 0x0006DEB0
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006174 RID: 24948
		' (get) Token: 0x0600FEF5 RID: 65269 RVA: 0x0006FCB9 File Offset: 0x0006DEB9
		' (set) Token: 0x0600FEF6 RID: 65270 RVA: 0x00985134 File Offset: 0x00983334
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

		' Token: 0x17006175 RID: 24949
		' (get) Token: 0x0600FEF7 RID: 65271 RVA: 0x0006FCC3 File Offset: 0x0006DEC3
		' (set) Token: 0x0600FEF8 RID: 65272 RVA: 0x0006FCCD File Offset: 0x0006DECD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006176 RID: 24950
		' (get) Token: 0x0600FEF9 RID: 65273 RVA: 0x0006FCD6 File Offset: 0x0006DED6
		' (set) Token: 0x0600FEFA RID: 65274 RVA: 0x0006FCE0 File Offset: 0x0006DEE0
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006177 RID: 24951
		' (get) Token: 0x0600FEFB RID: 65275 RVA: 0x0006FCE9 File Offset: 0x0006DEE9
		' (set) Token: 0x0600FEFC RID: 65276 RVA: 0x0006FCF3 File Offset: 0x0006DEF3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006178 RID: 24952
		' (get) Token: 0x0600FEFD RID: 65277 RVA: 0x0006FCFC File Offset: 0x0006DEFC
		' (set) Token: 0x0600FEFE RID: 65278 RVA: 0x0006FD06 File Offset: 0x0006DF06
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006179 RID: 24953
		' (get) Token: 0x0600FEFF RID: 65279 RVA: 0x0006FD0F File Offset: 0x0006DF0F
		' (set) Token: 0x0600FF00 RID: 65280 RVA: 0x0006FD19 File Offset: 0x0006DF19
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700617A RID: 24954
		' (get) Token: 0x0600FF01 RID: 65281 RVA: 0x0006FD22 File Offset: 0x0006DF22
		' (set) Token: 0x0600FF02 RID: 65282 RVA: 0x0006FD2C File Offset: 0x0006DF2C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700617B RID: 24955
		' (get) Token: 0x0600FF03 RID: 65283 RVA: 0x0006FD35 File Offset: 0x0006DF35
		' (set) Token: 0x0600FF04 RID: 65284 RVA: 0x0006FD3F File Offset: 0x0006DF3F
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700617C RID: 24956
		' (get) Token: 0x0600FF05 RID: 65285 RVA: 0x0006FD48 File Offset: 0x0006DF48
		' (set) Token: 0x0600FF06 RID: 65286 RVA: 0x0006FD52 File Offset: 0x0006DF52
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700617D RID: 24957
		' (get) Token: 0x0600FF07 RID: 65287 RVA: 0x0006FD5B File Offset: 0x0006DF5B
		' (set) Token: 0x0600FF08 RID: 65288 RVA: 0x0006FD65 File Offset: 0x0006DF65
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600FF09 RID: 65289 RVA: 0x00985178 File Offset: 0x00983378
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

		' Token: 0x0600FF0A RID: 65290 RVA: 0x00985254 File Offset: 0x00983454
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date, Supplier.ID, RTRIM(Supplier.SupplierID), RTRIM(Name), FreightCharges, RTRIM(Stock.BillSundry) from Supplier,Stock where Supplier.ID=Stock.SupplierID and RTRIM(Stock.BillSundry)='TCS' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FF0B RID: 65291 RVA: 0x0006FD6E File Offset: 0x0006DF6E
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600FF0C RID: 65292 RVA: 0x00985434 File Offset: 0x00983634
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

		' Token: 0x0600FF0D RID: 65293 RVA: 0x0098551C File Offset: 0x0098371C
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column15").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column15").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600FF0E RID: 65294 RVA: 0x0098562C File Offset: 0x0098382C
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

		' Token: 0x0600FF0F RID: 65295 RVA: 0x009858D8 File Offset: 0x00983AD8
		Private Sub frmTCSPurchase_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FF10 RID: 65296 RVA: 0x00985960 File Offset: 0x00983B60
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

		' Token: 0x0600FF11 RID: 65297 RVA: 0x00985AD8 File Offset: 0x00983CD8
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

		' Token: 0x0600FF12 RID: 65298 RVA: 0x00985B94 File Offset: 0x00983D94
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

		' Token: 0x0600FF13 RID: 65299 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FF14 RID: 65300 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FF15 RID: 65301 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FF16 RID: 65302 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTCSPurchase_KeyDown(sender As Object, e As KeyEventArgs)
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
