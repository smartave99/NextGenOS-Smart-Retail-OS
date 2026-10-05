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
	' Token: 0x020004E3 RID: 1251
	<DesignerGenerated()>
	Public Partial Class frmTCSRcvd
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FF53 RID: 65363 RVA: 0x0006FF31 File Offset: 0x0006E131
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTCSRcvd_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTCSRcvd_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006194 RID: 24980
		' (get) Token: 0x0600FF56 RID: 65366 RVA: 0x0006FF63 File Offset: 0x0006E163
		' (set) Token: 0x0600FF57 RID: 65367 RVA: 0x0006FF6D File Offset: 0x0006E16D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006195 RID: 24981
		' (get) Token: 0x0600FF58 RID: 65368 RVA: 0x0006FF76 File Offset: 0x0006E176
		' (set) Token: 0x0600FF59 RID: 65369 RVA: 0x0006FF80 File Offset: 0x0006E180
		Friend Overridable Property Label1 As Label

		' Token: 0x17006196 RID: 24982
		' (get) Token: 0x0600FF5A RID: 65370 RVA: 0x0006FF89 File Offset: 0x0006E189
		' (set) Token: 0x0600FF5B RID: 65371 RVA: 0x00988918 File Offset: 0x00986B18
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

		' Token: 0x17006197 RID: 24983
		' (get) Token: 0x0600FF5C RID: 65372 RVA: 0x0006FF93 File Offset: 0x0006E193
		' (set) Token: 0x0600FF5D RID: 65373 RVA: 0x0006FF9D File Offset: 0x0006E19D
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006198 RID: 24984
		' (get) Token: 0x0600FF5E RID: 65374 RVA: 0x0006FFA6 File Offset: 0x0006E1A6
		' (set) Token: 0x0600FF5F RID: 65375 RVA: 0x0006FFB0 File Offset: 0x0006E1B0
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006199 RID: 24985
		' (get) Token: 0x0600FF60 RID: 65376 RVA: 0x0006FFB9 File Offset: 0x0006E1B9
		' (set) Token: 0x0600FF61 RID: 65377 RVA: 0x0006FFC3 File Offset: 0x0006E1C3
		Friend Overridable Property Label2 As Label

		' Token: 0x1700619A RID: 24986
		' (get) Token: 0x0600FF62 RID: 65378 RVA: 0x0006FFCC File Offset: 0x0006E1CC
		' (set) Token: 0x0600FF63 RID: 65379 RVA: 0x0098895C File Offset: 0x00986B5C
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

		' Token: 0x1700619B RID: 24987
		' (get) Token: 0x0600FF64 RID: 65380 RVA: 0x0006FFD6 File Offset: 0x0006E1D6
		' (set) Token: 0x0600FF65 RID: 65381 RVA: 0x0006FFE0 File Offset: 0x0006E1E0
		Friend Overridable Property Label4 As Label

		' Token: 0x1700619C RID: 24988
		' (get) Token: 0x0600FF66 RID: 65382 RVA: 0x0006FFE9 File Offset: 0x0006E1E9
		' (set) Token: 0x0600FF67 RID: 65383 RVA: 0x0006FFF3 File Offset: 0x0006E1F3
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700619D RID: 24989
		' (get) Token: 0x0600FF68 RID: 65384 RVA: 0x0006FFFC File Offset: 0x0006E1FC
		' (set) Token: 0x0600FF69 RID: 65385 RVA: 0x00070006 File Offset: 0x0006E206
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x1700619E RID: 24990
		' (get) Token: 0x0600FF6A RID: 65386 RVA: 0x0007000F File Offset: 0x0006E20F
		' (set) Token: 0x0600FF6B RID: 65387 RVA: 0x00070019 File Offset: 0x0006E219
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700619F RID: 24991
		' (get) Token: 0x0600FF6C RID: 65388 RVA: 0x00070022 File Offset: 0x0006E222
		' (set) Token: 0x0600FF6D RID: 65389 RVA: 0x0007002C File Offset: 0x0006E22C
		Friend Overridable Property Label3 As Label

		' Token: 0x170061A0 RID: 24992
		' (get) Token: 0x0600FF6E RID: 65390 RVA: 0x00070035 File Offset: 0x0006E235
		' (set) Token: 0x0600FF6F RID: 65391 RVA: 0x009889A0 File Offset: 0x00986BA0
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

		' Token: 0x170061A1 RID: 24993
		' (get) Token: 0x0600FF70 RID: 65392 RVA: 0x0007003F File Offset: 0x0006E23F
		' (set) Token: 0x0600FF71 RID: 65393 RVA: 0x00070049 File Offset: 0x0006E249
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170061A2 RID: 24994
		' (get) Token: 0x0600FF72 RID: 65394 RVA: 0x00070052 File Offset: 0x0006E252
		' (set) Token: 0x0600FF73 RID: 65395 RVA: 0x0007005C File Offset: 0x0006E25C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170061A3 RID: 24995
		' (get) Token: 0x0600FF74 RID: 65396 RVA: 0x00070065 File Offset: 0x0006E265
		' (set) Token: 0x0600FF75 RID: 65397 RVA: 0x0007006F File Offset: 0x0006E26F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170061A4 RID: 24996
		' (get) Token: 0x0600FF76 RID: 65398 RVA: 0x00070078 File Offset: 0x0006E278
		' (set) Token: 0x0600FF77 RID: 65399 RVA: 0x00070082 File Offset: 0x0006E282
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170061A5 RID: 24997
		' (get) Token: 0x0600FF78 RID: 65400 RVA: 0x0007008B File Offset: 0x0006E28B
		' (set) Token: 0x0600FF79 RID: 65401 RVA: 0x00070095 File Offset: 0x0006E295
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170061A6 RID: 24998
		' (get) Token: 0x0600FF7A RID: 65402 RVA: 0x0007009E File Offset: 0x0006E29E
		' (set) Token: 0x0600FF7B RID: 65403 RVA: 0x000700A8 File Offset: 0x0006E2A8
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170061A7 RID: 24999
		' (get) Token: 0x0600FF7C RID: 65404 RVA: 0x000700B1 File Offset: 0x0006E2B1
		' (set) Token: 0x0600FF7D RID: 65405 RVA: 0x000700BB File Offset: 0x0006E2BB
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170061A8 RID: 25000
		' (get) Token: 0x0600FF7E RID: 65406 RVA: 0x000700C4 File Offset: 0x0006E2C4
		' (set) Token: 0x0600FF7F RID: 65407 RVA: 0x000700CE File Offset: 0x0006E2CE
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170061A9 RID: 25001
		' (get) Token: 0x0600FF80 RID: 65408 RVA: 0x000700D7 File Offset: 0x0006E2D7
		' (set) Token: 0x0600FF81 RID: 65409 RVA: 0x000700E1 File Offset: 0x0006E2E1
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170061AA RID: 25002
		' (get) Token: 0x0600FF82 RID: 65410 RVA: 0x000700EA File Offset: 0x0006E2EA
		' (set) Token: 0x0600FF83 RID: 65411 RVA: 0x000700F4 File Offset: 0x0006E2F4
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170061AB RID: 25003
		' (get) Token: 0x0600FF84 RID: 65412 RVA: 0x000700FD File Offset: 0x0006E2FD
		' (set) Token: 0x0600FF85 RID: 65413 RVA: 0x00070107 File Offset: 0x0006E307
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170061AC RID: 25004
		' (get) Token: 0x0600FF86 RID: 65414 RVA: 0x00070110 File Offset: 0x0006E310
		' (set) Token: 0x0600FF87 RID: 65415 RVA: 0x0007011A File Offset: 0x0006E31A
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170061AD RID: 25005
		' (get) Token: 0x0600FF88 RID: 65416 RVA: 0x00070123 File Offset: 0x0006E323
		' (set) Token: 0x0600FF89 RID: 65417 RVA: 0x0007012D File Offset: 0x0006E32D
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600FF8A RID: 65418 RVA: 0x009889E4 File Offset: 0x00986BE4
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

		' Token: 0x0600FF8B RID: 65419 RVA: 0x00988AC0 File Offset: 0x00986CC0
		Private Sub frmTCSRcvd_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FF8C RID: 65420 RVA: 0x00988B48 File Offset: 0x00986D48
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

		' Token: 0x0600FF8D RID: 65421 RVA: 0x00988CC0 File Offset: 0x00986EC0
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

		' Token: 0x0600FF8E RID: 65422 RVA: 0x00988D7C File Offset: 0x00986F7C
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

		' Token: 0x0600FF8F RID: 65423 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FF90 RID: 65424 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FF91 RID: 65425 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FF92 RID: 65426 RVA: 0x00988E48 File Offset: 0x00987048
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.PAN),RTRIM(Customer.State),RTRIM(Customer.GSTIN),FreightCharges, RTRIM(BillSundry),RTRIM(TCSPer) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where NOT RTRIM(Customer.PAN)='' and BillSundry='TCS' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.PAN),RTRIM(Customer.State),RTRIM(Customer.GSTIN),FreightCharges, RTRIM(BillSundry), RTRIM(TCSPer) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where RTRIM(Customer.PAN)='' and BillSundry='TCS' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.PAN),RTRIM(Customer.State),RTRIM(Customer.GSTIN),FreightCharges, RTRIM(BillSundry), RTRIM(TCSPer) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where BillSundry='TCS' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
						End If
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FF93 RID: 65427 RVA: 0x009890D0 File Offset: 0x009872D0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please Select PAN Status", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.ComboBox1.Focus()
			Else
				Me.Getdata()
			End If
		End Sub

		' Token: 0x0600FF94 RID: 65428 RVA: 0x0098911C File Offset: 0x0098731C
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

		' Token: 0x0600FF95 RID: 65429 RVA: 0x00989204 File Offset: 0x00987404
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column23").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column23").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600FF96 RID: 65430 RVA: 0x00989314 File Offset: 0x00987514
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

		' Token: 0x0600FF97 RID: 65431 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTCSRcvd_KeyDown(sender As Object, e As KeyEventArgs)
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
