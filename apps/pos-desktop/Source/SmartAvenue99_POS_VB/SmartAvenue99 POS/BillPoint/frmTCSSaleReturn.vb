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
	' Token: 0x020004E4 RID: 1252
	<DesignerGenerated()>
	Public Partial Class frmTCSSaleReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FF98 RID: 65432 RVA: 0x00070136 File Offset: 0x0006E336
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTCSSaleReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTCSSaleReturn_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170061AE RID: 25006
		' (get) Token: 0x0600FF9B RID: 65435 RVA: 0x00070168 File Offset: 0x0006E368
		' (set) Token: 0x0600FF9C RID: 65436 RVA: 0x00070172 File Offset: 0x0006E372
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170061AF RID: 25007
		' (get) Token: 0x0600FF9D RID: 65437 RVA: 0x0007017B File Offset: 0x0006E37B
		' (set) Token: 0x0600FF9E RID: 65438 RVA: 0x0098A568 File Offset: 0x00988768
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

		' Token: 0x170061B0 RID: 25008
		' (get) Token: 0x0600FF9F RID: 65439 RVA: 0x00070185 File Offset: 0x0006E385
		' (set) Token: 0x0600FFA0 RID: 65440 RVA: 0x0007018F File Offset: 0x0006E38F
		Friend Overridable Property Label3 As Label

		' Token: 0x170061B1 RID: 25009
		' (get) Token: 0x0600FFA1 RID: 65441 RVA: 0x00070198 File Offset: 0x0006E398
		' (set) Token: 0x0600FFA2 RID: 65442 RVA: 0x000701A2 File Offset: 0x0006E3A2
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x170061B2 RID: 25010
		' (get) Token: 0x0600FFA3 RID: 65443 RVA: 0x000701AB File Offset: 0x0006E3AB
		' (set) Token: 0x0600FFA4 RID: 65444 RVA: 0x000701B5 File Offset: 0x0006E3B5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170061B3 RID: 25011
		' (get) Token: 0x0600FFA5 RID: 65445 RVA: 0x000701BE File Offset: 0x0006E3BE
		' (set) Token: 0x0600FFA6 RID: 65446 RVA: 0x000701C8 File Offset: 0x0006E3C8
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170061B4 RID: 25012
		' (get) Token: 0x0600FFA7 RID: 65447 RVA: 0x000701D1 File Offset: 0x0006E3D1
		' (set) Token: 0x0600FFA8 RID: 65448 RVA: 0x000701DB File Offset: 0x0006E3DB
		Friend Overridable Property Label2 As Label

		' Token: 0x170061B5 RID: 25013
		' (get) Token: 0x0600FFA9 RID: 65449 RVA: 0x000701E4 File Offset: 0x0006E3E4
		' (set) Token: 0x0600FFAA RID: 65450 RVA: 0x0098A5AC File Offset: 0x009887AC
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

		' Token: 0x170061B6 RID: 25014
		' (get) Token: 0x0600FFAB RID: 65451 RVA: 0x000701EE File Offset: 0x0006E3EE
		' (set) Token: 0x0600FFAC RID: 65452 RVA: 0x000701F8 File Offset: 0x0006E3F8
		Friend Overridable Property Label4 As Label

		' Token: 0x170061B7 RID: 25015
		' (get) Token: 0x0600FFAD RID: 65453 RVA: 0x00070201 File Offset: 0x0006E401
		' (set) Token: 0x0600FFAE RID: 65454 RVA: 0x0007020B File Offset: 0x0006E40B
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170061B8 RID: 25016
		' (get) Token: 0x0600FFAF RID: 65455 RVA: 0x00070214 File Offset: 0x0006E414
		' (set) Token: 0x0600FFB0 RID: 65456 RVA: 0x0007021E File Offset: 0x0006E41E
		Friend Overridable Property Label1 As Label

		' Token: 0x170061B9 RID: 25017
		' (get) Token: 0x0600FFB1 RID: 65457 RVA: 0x00070227 File Offset: 0x0006E427
		' (set) Token: 0x0600FFB2 RID: 65458 RVA: 0x0098A5F0 File Offset: 0x009887F0
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

		' Token: 0x170061BA RID: 25018
		' (get) Token: 0x0600FFB3 RID: 65459 RVA: 0x00070231 File Offset: 0x0006E431
		' (set) Token: 0x0600FFB4 RID: 65460 RVA: 0x0007023B File Offset: 0x0006E43B
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170061BB RID: 25019
		' (get) Token: 0x0600FFB5 RID: 65461 RVA: 0x00070244 File Offset: 0x0006E444
		' (set) Token: 0x0600FFB6 RID: 65462 RVA: 0x0007024E File Offset: 0x0006E44E
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170061BC RID: 25020
		' (get) Token: 0x0600FFB7 RID: 65463 RVA: 0x00070257 File Offset: 0x0006E457
		' (set) Token: 0x0600FFB8 RID: 65464 RVA: 0x00070261 File Offset: 0x0006E461
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170061BD RID: 25021
		' (get) Token: 0x0600FFB9 RID: 65465 RVA: 0x0007026A File Offset: 0x0006E46A
		' (set) Token: 0x0600FFBA RID: 65466 RVA: 0x00070274 File Offset: 0x0006E474
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170061BE RID: 25022
		' (get) Token: 0x0600FFBB RID: 65467 RVA: 0x0007027D File Offset: 0x0006E47D
		' (set) Token: 0x0600FFBC RID: 65468 RVA: 0x00070287 File Offset: 0x0006E487
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170061BF RID: 25023
		' (get) Token: 0x0600FFBD RID: 65469 RVA: 0x00070290 File Offset: 0x0006E490
		' (set) Token: 0x0600FFBE RID: 65470 RVA: 0x0007029A File Offset: 0x0006E49A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170061C0 RID: 25024
		' (get) Token: 0x0600FFBF RID: 65471 RVA: 0x000702A3 File Offset: 0x0006E4A3
		' (set) Token: 0x0600FFC0 RID: 65472 RVA: 0x000702AD File Offset: 0x0006E4AD
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170061C1 RID: 25025
		' (get) Token: 0x0600FFC1 RID: 65473 RVA: 0x000702B6 File Offset: 0x0006E4B6
		' (set) Token: 0x0600FFC2 RID: 65474 RVA: 0x000702C0 File Offset: 0x0006E4C0
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170061C2 RID: 25026
		' (get) Token: 0x0600FFC3 RID: 65475 RVA: 0x000702C9 File Offset: 0x0006E4C9
		' (set) Token: 0x0600FFC4 RID: 65476 RVA: 0x000702D3 File Offset: 0x0006E4D3
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170061C3 RID: 25027
		' (get) Token: 0x0600FFC5 RID: 65477 RVA: 0x000702DC File Offset: 0x0006E4DC
		' (set) Token: 0x0600FFC6 RID: 65478 RVA: 0x000702E6 File Offset: 0x0006E4E6
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600FFC7 RID: 65479 RVA: 0x0098A634 File Offset: 0x00988834
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

		' Token: 0x0600FFC8 RID: 65480 RVA: 0x0098A710 File Offset: 0x00988910
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.FreightCharges,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and SalesReturn.BillSundry='TCS' and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
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

		' Token: 0x0600FFC9 RID: 65481 RVA: 0x000702EF File Offset: 0x0006E4EF
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x0600FFCA RID: 65482 RVA: 0x0098A8E8 File Offset: 0x00988AE8
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

		' Token: 0x0600FFCB RID: 65483 RVA: 0x0098A9D0 File Offset: 0x00988BD0
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column13").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column13").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600FFCC RID: 65484 RVA: 0x0098AAE0 File Offset: 0x00988CE0
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

		' Token: 0x0600FFCD RID: 65485 RVA: 0x0098AD8C File Offset: 0x00988F8C
		Private Sub frmTCSSaleReturn_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FFCE RID: 65486 RVA: 0x0098AE14 File Offset: 0x00989014
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

		' Token: 0x0600FFCF RID: 65487 RVA: 0x0098AF8C File Offset: 0x0098918C
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

		' Token: 0x0600FFD0 RID: 65488 RVA: 0x0098B048 File Offset: 0x00989248
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

		' Token: 0x0600FFD1 RID: 65489 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FFD2 RID: 65490 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FFD3 RID: 65491 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FFD4 RID: 65492 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTCSSaleReturn_KeyDown(sender As Object, e As KeyEventArgs)
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
