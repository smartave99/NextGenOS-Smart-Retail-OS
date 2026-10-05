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
	' Token: 0x02000555 RID: 1365
	<DesignerGenerated()>
	Public Partial Class frmStockEntryRecord1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010A76 RID: 68214 RVA: 0x00072E6E File Offset: 0x0007106E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockEntryRecord1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700671B RID: 26395
		' (get) Token: 0x06010A79 RID: 68217 RVA: 0x00072EA0 File Offset: 0x000710A0
		' (set) Token: 0x06010A7A RID: 68218 RVA: 0x00072EAA File Offset: 0x000710AA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700671C RID: 26396
		' (get) Token: 0x06010A7B RID: 68219 RVA: 0x00072EB3 File Offset: 0x000710B3
		' (set) Token: 0x06010A7C RID: 68220 RVA: 0x009BB084 File Offset: 0x009B9284
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

		' Token: 0x1700671D RID: 26397
		' (get) Token: 0x06010A7D RID: 68221 RVA: 0x00072EBD File Offset: 0x000710BD
		' (set) Token: 0x06010A7E RID: 68222 RVA: 0x00072EC7 File Offset: 0x000710C7
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700671E RID: 26398
		' (get) Token: 0x06010A7F RID: 68223 RVA: 0x00072ED0 File Offset: 0x000710D0
		' (set) Token: 0x06010A80 RID: 68224 RVA: 0x00072EDA File Offset: 0x000710DA
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700671F RID: 26399
		' (get) Token: 0x06010A81 RID: 68225 RVA: 0x00072EE3 File Offset: 0x000710E3
		' (set) Token: 0x06010A82 RID: 68226 RVA: 0x00072EED File Offset: 0x000710ED
		Friend Overridable Property Label2 As Label

		' Token: 0x17006720 RID: 26400
		' (get) Token: 0x06010A83 RID: 68227 RVA: 0x00072EF6 File Offset: 0x000710F6
		' (set) Token: 0x06010A84 RID: 68228 RVA: 0x00072F00 File Offset: 0x00071100
		Friend Overridable Property Label4 As Label

		' Token: 0x17006721 RID: 26401
		' (get) Token: 0x06010A85 RID: 68229 RVA: 0x00072F09 File Offset: 0x00071109
		' (set) Token: 0x06010A86 RID: 68230 RVA: 0x009BB0C8 File Offset: 0x009B92C8
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

		' Token: 0x17006722 RID: 26402
		' (get) Token: 0x06010A87 RID: 68231 RVA: 0x00072F13 File Offset: 0x00071113
		' (set) Token: 0x06010A88 RID: 68232 RVA: 0x00072F1D File Offset: 0x0007111D
		Friend Overridable Property Label5 As Label

		' Token: 0x17006723 RID: 26403
		' (get) Token: 0x06010A89 RID: 68233 RVA: 0x00072F26 File Offset: 0x00071126
		' (set) Token: 0x06010A8A RID: 68234 RVA: 0x00072F30 File Offset: 0x00071130
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006724 RID: 26404
		' (get) Token: 0x06010A8B RID: 68235 RVA: 0x00072F39 File Offset: 0x00071139
		' (set) Token: 0x06010A8C RID: 68236 RVA: 0x00072F43 File Offset: 0x00071143
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006725 RID: 26405
		' (get) Token: 0x06010A8D RID: 68237 RVA: 0x00072F4C File Offset: 0x0007114C
		' (set) Token: 0x06010A8E RID: 68238 RVA: 0x00072F56 File Offset: 0x00071156
		Friend Overridable Property Label1 As Label

		' Token: 0x17006726 RID: 26406
		' (get) Token: 0x06010A8F RID: 68239 RVA: 0x00072F5F File Offset: 0x0007115F
		' (set) Token: 0x06010A90 RID: 68240 RVA: 0x00072F69 File Offset: 0x00071169
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006727 RID: 26407
		' (get) Token: 0x06010A91 RID: 68241 RVA: 0x00072F72 File Offset: 0x00071172
		' (set) Token: 0x06010A92 RID: 68242 RVA: 0x00072F7C File Offset: 0x0007117C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006728 RID: 26408
		' (get) Token: 0x06010A93 RID: 68243 RVA: 0x00072F85 File Offset: 0x00071185
		' (set) Token: 0x06010A94 RID: 68244 RVA: 0x00072F8F File Offset: 0x0007118F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006729 RID: 26409
		' (get) Token: 0x06010A95 RID: 68245 RVA: 0x00072F98 File Offset: 0x00071198
		' (set) Token: 0x06010A96 RID: 68246 RVA: 0x00072FA2 File Offset: 0x000711A2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700672A RID: 26410
		' (get) Token: 0x06010A97 RID: 68247 RVA: 0x00072FAB File Offset: 0x000711AB
		' (set) Token: 0x06010A98 RID: 68248 RVA: 0x00072FB5 File Offset: 0x000711B5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700672B RID: 26411
		' (get) Token: 0x06010A99 RID: 68249 RVA: 0x00072FBE File Offset: 0x000711BE
		' (set) Token: 0x06010A9A RID: 68250 RVA: 0x00072FC8 File Offset: 0x000711C8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700672C RID: 26412
		' (get) Token: 0x06010A9B RID: 68251 RVA: 0x00072FD1 File Offset: 0x000711D1
		' (set) Token: 0x06010A9C RID: 68252 RVA: 0x00072FDB File Offset: 0x000711DB
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700672D RID: 26413
		' (get) Token: 0x06010A9D RID: 68253 RVA: 0x00072FE4 File Offset: 0x000711E4
		' (set) Token: 0x06010A9E RID: 68254 RVA: 0x00072FEE File Offset: 0x000711EE
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700672E RID: 26414
		' (get) Token: 0x06010A9F RID: 68255 RVA: 0x00072FF7 File Offset: 0x000711F7
		' (set) Token: 0x06010AA0 RID: 68256 RVA: 0x009BB128 File Offset: 0x009B9328
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

		' Token: 0x1700672F RID: 26415
		' (get) Token: 0x06010AA1 RID: 68257 RVA: 0x00073001 File Offset: 0x00071201
		' (set) Token: 0x06010AA2 RID: 68258 RVA: 0x009BB16C File Offset: 0x009B936C
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

		' Token: 0x17006730 RID: 26416
		' (get) Token: 0x06010AA3 RID: 68259 RVA: 0x0007300B File Offset: 0x0007120B
		' (set) Token: 0x06010AA4 RID: 68260 RVA: 0x009BB1B0 File Offset: 0x009B93B0
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010AA5 RID: 68261 RVA: 0x009BB1F4 File Offset: 0x009B93F4
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

		' Token: 0x06010AA6 RID: 68262 RVA: 0x009BB31C File Offset: 0x009B951C
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

		' Token: 0x06010AA7 RID: 68263 RVA: 0x009BB3F8 File Offset: 0x009B95F8
		Public Sub GetData()
			Try
				Me.cmbStockID.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date, Stock_Store_Join.ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Stock_Store_Join.Qty,RTRIM(Remarks) from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010AA8 RID: 68264 RVA: 0x009BB5C4 File Offset: 0x009B97C4
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.GetData()
			Me.fillTransferID()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010AA9 RID: 68265 RVA: 0x009BB65C File Offset: 0x009B985C
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

		' Token: 0x06010AAA RID: 68266 RVA: 0x009BB7D4 File Offset: 0x009B99D4
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x06010AAB RID: 68267 RVA: 0x009BB8A0 File Offset: 0x009B9AA0
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

		' Token: 0x06010AAC RID: 68268 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010AAD RID: 68269 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010AAE RID: 68270 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010AAF RID: 68271 RVA: 0x00073015 File Offset: 0x00071215
		Public Sub Reset()
			Me.cmbStockID.Text = ""
			Me.fyear()
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.GetData()
		End Sub

		' Token: 0x06010AB0 RID: 68272 RVA: 0x009BB96C File Offset: 0x009B9B6C
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

		' Token: 0x06010AB1 RID: 68273 RVA: 0x009BBA54 File Offset: 0x009B9C54
		Private Sub cmbTicketNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date, Stock_Store_Join.ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Stock_Store_Join.Qty,RTRIM(Remarks) from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and ST_ID=@d3 and Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.cmbStockID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010AB2 RID: 68274 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbTicketNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06010AB3 RID: 68275 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockEntryRecord1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010AB4 RID: 68276 RVA: 0x009BB3F8 File Offset: 0x009B95F8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbStockID.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ST_ID,Date, Stock_Store_Join.ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Stock_Store_Join.Qty,RTRIM(Remarks) from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and Date between @d1 and @d2 order by Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010AB5 RID: 68277 RVA: 0x0007304D File Offset: 0x0007124D
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010AB6 RID: 68278 RVA: 0x009BBC3C File Offset: 0x009B9E3C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
