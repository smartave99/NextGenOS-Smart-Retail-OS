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
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000553 RID: 1363
	<DesignerGenerated()>
	Public Partial Class frmStockAdjustment_Store_Record
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010A01 RID: 68097 RVA: 0x00072B07 File Offset: 0x00070D07
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockAdjustment_Store_Record_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170066F3 RID: 26355
		' (get) Token: 0x06010A04 RID: 68100 RVA: 0x00072B39 File Offset: 0x00070D39
		' (set) Token: 0x06010A05 RID: 68101 RVA: 0x00072B43 File Offset: 0x00070D43
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170066F4 RID: 26356
		' (get) Token: 0x06010A06 RID: 68102 RVA: 0x00072B4C File Offset: 0x00070D4C
		' (set) Token: 0x06010A07 RID: 68103 RVA: 0x00072B56 File Offset: 0x00070D56
		Friend Overridable Property Label1 As Label

		' Token: 0x170066F5 RID: 26357
		' (get) Token: 0x06010A08 RID: 68104 RVA: 0x00072B5F File Offset: 0x00070D5F
		' (set) Token: 0x06010A09 RID: 68105 RVA: 0x009B7AD0 File Offset: 0x009B5CD0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170066F6 RID: 26358
		' (get) Token: 0x06010A0A RID: 68106 RVA: 0x00072B69 File Offset: 0x00070D69
		' (set) Token: 0x06010A0B RID: 68107 RVA: 0x00072B73 File Offset: 0x00070D73
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170066F7 RID: 26359
		' (get) Token: 0x06010A0C RID: 68108 RVA: 0x00072B7C File Offset: 0x00070D7C
		' (set) Token: 0x06010A0D RID: 68109 RVA: 0x00072B86 File Offset: 0x00070D86
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170066F8 RID: 26360
		' (get) Token: 0x06010A0E RID: 68110 RVA: 0x00072B8F File Offset: 0x00070D8F
		' (set) Token: 0x06010A0F RID: 68111 RVA: 0x00072B99 File Offset: 0x00070D99
		Friend Overridable Property Label2 As Label

		' Token: 0x170066F9 RID: 26361
		' (get) Token: 0x06010A10 RID: 68112 RVA: 0x00072BA2 File Offset: 0x00070DA2
		' (set) Token: 0x06010A11 RID: 68113 RVA: 0x00072BAC File Offset: 0x00070DAC
		Friend Overridable Property Label4 As Label

		' Token: 0x170066FA RID: 26362
		' (get) Token: 0x06010A12 RID: 68114 RVA: 0x00072BB5 File Offset: 0x00070DB5
		' (set) Token: 0x06010A13 RID: 68115 RVA: 0x00072BBF File Offset: 0x00070DBF
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170066FB RID: 26363
		' (get) Token: 0x06010A14 RID: 68116 RVA: 0x00072BC8 File Offset: 0x00070DC8
		' (set) Token: 0x06010A15 RID: 68117 RVA: 0x00072BD2 File Offset: 0x00070DD2
		Friend Overridable Property lblSet As Label

		' Token: 0x170066FC RID: 26364
		' (get) Token: 0x06010A16 RID: 68118 RVA: 0x00072BDB File Offset: 0x00070DDB
		' (set) Token: 0x06010A17 RID: 68119 RVA: 0x00072BE5 File Offset: 0x00070DE5
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170066FD RID: 26365
		' (get) Token: 0x06010A18 RID: 68120 RVA: 0x00072BEE File Offset: 0x00070DEE
		' (set) Token: 0x06010A19 RID: 68121 RVA: 0x00072BF8 File Offset: 0x00070DF8
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170066FE RID: 26366
		' (get) Token: 0x06010A1A RID: 68122 RVA: 0x00072C01 File Offset: 0x00070E01
		' (set) Token: 0x06010A1B RID: 68123 RVA: 0x00072C0B File Offset: 0x00070E0B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170066FF RID: 26367
		' (get) Token: 0x06010A1C RID: 68124 RVA: 0x00072C14 File Offset: 0x00070E14
		' (set) Token: 0x06010A1D RID: 68125 RVA: 0x00072C1E File Offset: 0x00070E1E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006700 RID: 26368
		' (get) Token: 0x06010A1E RID: 68126 RVA: 0x00072C27 File Offset: 0x00070E27
		' (set) Token: 0x06010A1F RID: 68127 RVA: 0x00072C31 File Offset: 0x00070E31
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006701 RID: 26369
		' (get) Token: 0x06010A20 RID: 68128 RVA: 0x00072C3A File Offset: 0x00070E3A
		' (set) Token: 0x06010A21 RID: 68129 RVA: 0x00072C44 File Offset: 0x00070E44
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006702 RID: 26370
		' (get) Token: 0x06010A22 RID: 68130 RVA: 0x00072C4D File Offset: 0x00070E4D
		' (set) Token: 0x06010A23 RID: 68131 RVA: 0x00072C57 File Offset: 0x00070E57
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006703 RID: 26371
		' (get) Token: 0x06010A24 RID: 68132 RVA: 0x00072C60 File Offset: 0x00070E60
		' (set) Token: 0x06010A25 RID: 68133 RVA: 0x00072C6A File Offset: 0x00070E6A
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006704 RID: 26372
		' (get) Token: 0x06010A26 RID: 68134 RVA: 0x00072C73 File Offset: 0x00070E73
		' (set) Token: 0x06010A27 RID: 68135 RVA: 0x00072C7D File Offset: 0x00070E7D
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006705 RID: 26373
		' (get) Token: 0x06010A28 RID: 68136 RVA: 0x00072C86 File Offset: 0x00070E86
		' (set) Token: 0x06010A29 RID: 68137 RVA: 0x00072C90 File Offset: 0x00070E90
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006706 RID: 26374
		' (get) Token: 0x06010A2A RID: 68138 RVA: 0x00072C99 File Offset: 0x00070E99
		' (set) Token: 0x06010A2B RID: 68139 RVA: 0x00072CA3 File Offset: 0x00070EA3
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17006707 RID: 26375
		' (get) Token: 0x06010A2C RID: 68140 RVA: 0x00072CAC File Offset: 0x00070EAC
		' (set) Token: 0x06010A2D RID: 68141 RVA: 0x009B7B30 File Offset: 0x009B5D30
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBarcode_TextChanged
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006708 RID: 26376
		' (get) Token: 0x06010A2E RID: 68142 RVA: 0x00072CB6 File Offset: 0x00070EB6
		' (set) Token: 0x06010A2F RID: 68143 RVA: 0x00072CC0 File Offset: 0x00070EC0
		Friend Overridable Property Label3 As Label

		' Token: 0x17006709 RID: 26377
		' (get) Token: 0x06010A30 RID: 68144 RVA: 0x00072CC9 File Offset: 0x00070EC9
		' (set) Token: 0x06010A31 RID: 68145 RVA: 0x00072CD3 File Offset: 0x00070ED3
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700670A RID: 26378
		' (get) Token: 0x06010A32 RID: 68146 RVA: 0x00072CDC File Offset: 0x00070EDC
		' (set) Token: 0x06010A33 RID: 68147 RVA: 0x009B7B74 File Offset: 0x009B5D74
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtProductName_TextChanged
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700670B RID: 26379
		' (get) Token: 0x06010A34 RID: 68148 RVA: 0x00072CE6 File Offset: 0x00070EE6
		' (set) Token: 0x06010A35 RID: 68149 RVA: 0x00072CF0 File Offset: 0x00070EF0
		Friend Overridable Property Label5 As Label

		' Token: 0x1700670C RID: 26380
		' (get) Token: 0x06010A36 RID: 68150 RVA: 0x00072CF9 File Offset: 0x00070EF9
		' (set) Token: 0x06010A37 RID: 68151 RVA: 0x00072D03 File Offset: 0x00070F03
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700670D RID: 26381
		' (get) Token: 0x06010A38 RID: 68152 RVA: 0x00072D0C File Offset: 0x00070F0C
		' (set) Token: 0x06010A39 RID: 68153 RVA: 0x009B7BB8 File Offset: 0x009B5DB8
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

		' Token: 0x1700670E RID: 26382
		' (get) Token: 0x06010A3A RID: 68154 RVA: 0x00072D16 File Offset: 0x00070F16
		' (set) Token: 0x06010A3B RID: 68155 RVA: 0x009B7BFC File Offset: 0x009B5DFC
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

		' Token: 0x1700670F RID: 26383
		' (get) Token: 0x06010A3C RID: 68156 RVA: 0x00072D20 File Offset: 0x00070F20
		' (set) Token: 0x06010A3D RID: 68157 RVA: 0x009B7C40 File Offset: 0x009B5E40
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

		' Token: 0x06010A3E RID: 68158 RVA: 0x009B7C84 File Offset: 0x009B5E84
		Public Sub Getdata()
			Try
				Me.txtProductName.Text = ""
				Me.txtBarcode.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT  StockAdjustment_Store.SA_ID, StockAdjustment_Store.Date, StockAdjustment_Store.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Store.Barcode), RTRIM(StockAdjustment_Store.AdjustmentType),StockAdjustment_Store.Qty, RTRIM(StockAdjustment_Store.Reason) FROM StockAdjustment_Store INNER JOIN Product ON StockAdjustment_Store.ProductID = Product.PID where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010A3F RID: 68159 RVA: 0x009B7E80 File Offset: 0x009B6080
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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

		' Token: 0x06010A40 RID: 68160 RVA: 0x009B7F54 File Offset: 0x009B6154
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010A41 RID: 68161 RVA: 0x009B7FE4 File Offset: 0x009B61E4
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

		' Token: 0x06010A42 RID: 68162 RVA: 0x009B815C File Offset: 0x009B635C
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

		' Token: 0x06010A43 RID: 68163 RVA: 0x009B8228 File Offset: 0x009B6428
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

		' Token: 0x06010A44 RID: 68164 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010A45 RID: 68165 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010A46 RID: 68166 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010A47 RID: 68167 RVA: 0x009B82F4 File Offset: 0x009B64F4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "SA", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmStockAdjustment_Store.Show()
						MyBase.Hide()
						MyProject.Forms.frmStockAdjustment_Store.txtAdjustmentID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.dtpDate.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtProductID.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtProductCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtProductName.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(6).Value.ToString(), "Plus", False) = 0
						If flag3 Then
							MyProject.Forms.frmStockAdjustment_Store.rbPlus.Checked = True
						Else
							MyProject.Forms.frmStockAdjustment_Store.rbMinus.Checked = True
						End If
						MyProject.Forms.frmStockAdjustment_Store.txtQty.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtQ.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtReason.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmStockAdjustment_Store.txtBarcode.Enabled = False
						MyProject.Forms.frmStockAdjustment_Store.btnDelete.Enabled = True
						MyProject.Forms.frmStockAdjustment_Store.btnUpdate.Enabled = True
						MyProject.Forms.frmStockAdjustment_Store.btnSave.Enabled = False
						MyProject.Forms.frmStockAdjustment_Store.txtProductName.Enabled = False
						MyProject.Forms.frmStockAdjustment_Store.GetQty_S()
						MyProject.Forms.frmStockAdjustment_Store.gbAdjustment.Enabled = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010A48 RID: 68168 RVA: 0x009B860C File Offset: 0x009B680C
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

		' Token: 0x06010A49 RID: 68169 RVA: 0x009B86F4 File Offset: 0x009B68F4
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.fyear()
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.Getdata()
		End Sub

		' Token: 0x06010A4A RID: 68170 RVA: 0x009B8748 File Offset: 0x009B6948
		Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT  StockAdjustment_Store.SA_ID, StockAdjustment_Store.Date, StockAdjustment_Store.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Store.Barcode), RTRIM(StockAdjustment_Store.AdjustmentType),StockAdjustment_Store.Qty, RTRIM(StockAdjustment_Store.Reason) FROM StockAdjustment_Store INNER JOIN Product ON StockAdjustment_Store.ProductID = Product.PID where ProductName like N'" + Me.txtProductName.Text + "%' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010A4B RID: 68171 RVA: 0x009B892C File Offset: 0x009B6B2C
		Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT  StockAdjustment_Store.SA_ID, StockAdjustment_Store.Date, StockAdjustment_Store.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Store.Barcode), RTRIM(StockAdjustment_Store.AdjustmentType),StockAdjustment_Store.Qty, RTRIM(StockAdjustment_Store.Reason) FROM StockAdjustment_Store INNER JOIN Product ON StockAdjustment_Store.ProductID = Product.PID where StockAdjustment_Store.Barcode like N'" + Me.txtBarcode.Text + "%' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010A4C RID: 68172 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockAdjustment_Store_Record_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010A4D RID: 68173 RVA: 0x009B7C84 File Offset: 0x009B5E84
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				Me.txtProductName.Text = ""
				Me.txtBarcode.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT  StockAdjustment_Store.SA_ID, StockAdjustment_Store.Date, StockAdjustment_Store.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Store.Barcode), RTRIM(StockAdjustment_Store.AdjustmentType),StockAdjustment_Store.Qty, RTRIM(StockAdjustment_Store.Reason) FROM StockAdjustment_Store INNER JOIN Product ON StockAdjustment_Store.ProductID = Product.PID where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010A4E RID: 68174 RVA: 0x00072D2A File Offset: 0x00070F2A
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010A4F RID: 68175 RVA: 0x009B8B10 File Offset: 0x009B6D10
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
