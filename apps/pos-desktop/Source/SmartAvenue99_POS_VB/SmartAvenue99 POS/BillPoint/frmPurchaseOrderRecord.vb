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
	' Token: 0x02000589 RID: 1417
	<DesignerGenerated()>
	Public Partial Class frmPurchaseOrderRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060112DE RID: 70366 RVA: 0x000761A9 File Offset: 0x000743A9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseOrderRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006A8D RID: 27277
		' (get) Token: 0x060112E1 RID: 70369 RVA: 0x000761DB File Offset: 0x000743DB
		' (set) Token: 0x060112E2 RID: 70370 RVA: 0x000761E5 File Offset: 0x000743E5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006A8E RID: 27278
		' (get) Token: 0x060112E3 RID: 70371 RVA: 0x000761EE File Offset: 0x000743EE
		' (set) Token: 0x060112E4 RID: 70372 RVA: 0x000761F8 File Offset: 0x000743F8
		Friend Overridable Property Label1 As Label

		' Token: 0x17006A8F RID: 27279
		' (get) Token: 0x060112E5 RID: 70373 RVA: 0x00076201 File Offset: 0x00074401
		' (set) Token: 0x060112E6 RID: 70374 RVA: 0x009F9540 File Offset: 0x009F7740
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A90 RID: 27280
		' (get) Token: 0x060112E7 RID: 70375 RVA: 0x0007620B File Offset: 0x0007440B
		' (set) Token: 0x060112E8 RID: 70376 RVA: 0x00076215 File Offset: 0x00074415
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006A91 RID: 27281
		' (get) Token: 0x060112E9 RID: 70377 RVA: 0x0007621E File Offset: 0x0007441E
		' (set) Token: 0x060112EA RID: 70378 RVA: 0x00076228 File Offset: 0x00074428
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006A92 RID: 27282
		' (get) Token: 0x060112EB RID: 70379 RVA: 0x00076231 File Offset: 0x00074431
		' (set) Token: 0x060112EC RID: 70380 RVA: 0x009F95BC File Offset: 0x009F77BC
		Private _txtSupplierName As TextBox
		Friend Overridable Property txtSupplierName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
				Dim textBox As TextBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierName = value
				textBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A93 RID: 27283
		' (get) Token: 0x060112ED RID: 70381 RVA: 0x0007623B File Offset: 0x0007443B
		' (set) Token: 0x060112EE RID: 70382 RVA: 0x00076245 File Offset: 0x00074445
		Friend Overridable Property Label3 As Label

		' Token: 0x17006A94 RID: 27284
		' (get) Token: 0x060112EF RID: 70383 RVA: 0x0007624E File Offset: 0x0007444E
		' (set) Token: 0x060112F0 RID: 70384 RVA: 0x00076258 File Offset: 0x00074458
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006A95 RID: 27285
		' (get) Token: 0x060112F1 RID: 70385 RVA: 0x00076261 File Offset: 0x00074461
		' (set) Token: 0x060112F2 RID: 70386 RVA: 0x0007626B File Offset: 0x0007446B
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006A96 RID: 27286
		' (get) Token: 0x060112F3 RID: 70387 RVA: 0x00076274 File Offset: 0x00074474
		' (set) Token: 0x060112F4 RID: 70388 RVA: 0x0007627E File Offset: 0x0007447E
		Friend Overridable Property Label2 As Label

		' Token: 0x17006A97 RID: 27287
		' (get) Token: 0x060112F5 RID: 70389 RVA: 0x00076287 File Offset: 0x00074487
		' (set) Token: 0x060112F6 RID: 70390 RVA: 0x00076291 File Offset: 0x00074491
		Friend Overridable Property Label4 As Label

		' Token: 0x17006A98 RID: 27288
		' (get) Token: 0x060112F7 RID: 70391 RVA: 0x0007629A File Offset: 0x0007449A
		' (set) Token: 0x060112F8 RID: 70392 RVA: 0x000762A4 File Offset: 0x000744A4
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006A99 RID: 27289
		' (get) Token: 0x060112F9 RID: 70393 RVA: 0x000762AD File Offset: 0x000744AD
		' (set) Token: 0x060112FA RID: 70394 RVA: 0x000762B7 File Offset: 0x000744B7
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17006A9A RID: 27290
		' (get) Token: 0x060112FB RID: 70395 RVA: 0x000762C0 File Offset: 0x000744C0
		' (set) Token: 0x060112FC RID: 70396 RVA: 0x000762CA File Offset: 0x000744CA
		Friend Overridable Property Label5 As Label

		' Token: 0x17006A9B RID: 27291
		' (get) Token: 0x060112FD RID: 70397 RVA: 0x000762D3 File Offset: 0x000744D3
		' (set) Token: 0x060112FE RID: 70398 RVA: 0x009F9600 File Offset: 0x009F7800
		Private _cmbTerms As ComboBox
		Friend Overridable Property cmbTerms As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTerms
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbTerms_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbTerms
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbTerms = value
				comboBox = Me._cmbTerms
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A9C RID: 27292
		' (get) Token: 0x060112FF RID: 70399 RVA: 0x000762DD File Offset: 0x000744DD
		' (set) Token: 0x06011300 RID: 70400 RVA: 0x000762E7 File Offset: 0x000744E7
		Friend Overridable Property lblSet As Label

		' Token: 0x17006A9D RID: 27293
		' (get) Token: 0x06011301 RID: 70401 RVA: 0x000762F0 File Offset: 0x000744F0
		' (set) Token: 0x06011302 RID: 70402 RVA: 0x000762FA File Offset: 0x000744FA
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006A9E RID: 27294
		' (get) Token: 0x06011303 RID: 70403 RVA: 0x00076303 File Offset: 0x00074503
		' (set) Token: 0x06011304 RID: 70404 RVA: 0x0007630D File Offset: 0x0007450D
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006A9F RID: 27295
		' (get) Token: 0x06011305 RID: 70405 RVA: 0x00076316 File Offset: 0x00074516
		' (set) Token: 0x06011306 RID: 70406 RVA: 0x00076320 File Offset: 0x00074520
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006AA0 RID: 27296
		' (get) Token: 0x06011307 RID: 70407 RVA: 0x00076329 File Offset: 0x00074529
		' (set) Token: 0x06011308 RID: 70408 RVA: 0x00076333 File Offset: 0x00074533
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006AA1 RID: 27297
		' (get) Token: 0x06011309 RID: 70409 RVA: 0x0007633C File Offset: 0x0007453C
		' (set) Token: 0x0601130A RID: 70410 RVA: 0x00076346 File Offset: 0x00074546
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006AA2 RID: 27298
		' (get) Token: 0x0601130B RID: 70411 RVA: 0x0007634F File Offset: 0x0007454F
		' (set) Token: 0x0601130C RID: 70412 RVA: 0x00076359 File Offset: 0x00074559
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17006AA3 RID: 27299
		' (get) Token: 0x0601130D RID: 70413 RVA: 0x00076362 File Offset: 0x00074562
		' (set) Token: 0x0601130E RID: 70414 RVA: 0x0007636C File Offset: 0x0007456C
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006AA4 RID: 27300
		' (get) Token: 0x0601130F RID: 70415 RVA: 0x00076375 File Offset: 0x00074575
		' (set) Token: 0x06011310 RID: 70416 RVA: 0x0007637F File Offset: 0x0007457F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006AA5 RID: 27301
		' (get) Token: 0x06011311 RID: 70417 RVA: 0x00076388 File Offset: 0x00074588
		' (set) Token: 0x06011312 RID: 70418 RVA: 0x00076392 File Offset: 0x00074592
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006AA6 RID: 27302
		' (get) Token: 0x06011313 RID: 70419 RVA: 0x0007639B File Offset: 0x0007459B
		' (set) Token: 0x06011314 RID: 70420 RVA: 0x000763A5 File Offset: 0x000745A5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006AA7 RID: 27303
		' (get) Token: 0x06011315 RID: 70421 RVA: 0x000763AE File Offset: 0x000745AE
		' (set) Token: 0x06011316 RID: 70422 RVA: 0x000763B8 File Offset: 0x000745B8
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006AA8 RID: 27304
		' (get) Token: 0x06011317 RID: 70423 RVA: 0x000763C1 File Offset: 0x000745C1
		' (set) Token: 0x06011318 RID: 70424 RVA: 0x000763CB File Offset: 0x000745CB
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006AA9 RID: 27305
		' (get) Token: 0x06011319 RID: 70425 RVA: 0x000763D4 File Offset: 0x000745D4
		' (set) Token: 0x0601131A RID: 70426 RVA: 0x000763DE File Offset: 0x000745DE
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006AAA RID: 27306
		' (get) Token: 0x0601131B RID: 70427 RVA: 0x000763E7 File Offset: 0x000745E7
		' (set) Token: 0x0601131C RID: 70428 RVA: 0x000763F1 File Offset: 0x000745F1
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17006AAB RID: 27307
		' (get) Token: 0x0601131D RID: 70429 RVA: 0x000763FA File Offset: 0x000745FA
		' (set) Token: 0x0601131E RID: 70430 RVA: 0x00076404 File Offset: 0x00074604
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17006AAC RID: 27308
		' (get) Token: 0x0601131F RID: 70431 RVA: 0x0007640D File Offset: 0x0007460D
		' (set) Token: 0x06011320 RID: 70432 RVA: 0x00076417 File Offset: 0x00074617
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006AAD RID: 27309
		' (get) Token: 0x06011321 RID: 70433 RVA: 0x00076420 File Offset: 0x00074620
		' (set) Token: 0x06011322 RID: 70434 RVA: 0x0007642A File Offset: 0x0007462A
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006AAE RID: 27310
		' (get) Token: 0x06011323 RID: 70435 RVA: 0x00076433 File Offset: 0x00074633
		' (set) Token: 0x06011324 RID: 70436 RVA: 0x009F9644 File Offset: 0x009F7844
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

		' Token: 0x17006AAF RID: 27311
		' (get) Token: 0x06011325 RID: 70437 RVA: 0x0007643D File Offset: 0x0007463D
		' (set) Token: 0x06011326 RID: 70438 RVA: 0x009F9688 File Offset: 0x009F7888
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

		' Token: 0x17006AB0 RID: 27312
		' (get) Token: 0x06011327 RID: 70439 RVA: 0x00076447 File Offset: 0x00074647
		' (set) Token: 0x06011328 RID: 70440 RVA: 0x009F96CC File Offset: 0x009F78CC
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

		' Token: 0x06011329 RID: 70441 RVA: 0x009F9710 File Offset: 0x009F7910
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

		' Token: 0x0601132A RID: 70442 RVA: 0x009F97E4 File Offset: 0x009F79E4
		Public Sub Getdata()
			Try
				Me.txtSupplierName.Text = ""
				Me.cmbTerms.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601132B RID: 70443 RVA: 0x009F9A3C File Offset: 0x009F7C3C
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601132C RID: 70444 RVA: 0x009F9AD4 File Offset: 0x009F7CD4
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

		' Token: 0x0601132D RID: 70445 RVA: 0x009F9C4C File Offset: 0x009F7E4C
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

		' Token: 0x0601132E RID: 70446 RVA: 0x009F9D18 File Offset: 0x009F7F18
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

		' Token: 0x0601132F RID: 70447 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011330 RID: 70448 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011331 RID: 70449 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011332 RID: 70450 RVA: 0x009F9DE4 File Offset: 0x009F7FE4
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011333 RID: 70451 RVA: 0x00076451 File Offset: 0x00074651
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011334 RID: 70452 RVA: 0x009F9E0C File Offset: 0x009F800C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "PO", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPurchaseOrder.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseOrder.txtPO_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtPONo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.dtpPODate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.cmbTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.cmbTerms.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSup_ID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSupplierID.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.cmbSupplierName.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSubTotal.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtCGST.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSGST.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtIGST.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtCESS.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtGrandTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtTermsAndConditions.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.btnSave.Enabled = False
						MyProject.Forms.frmPurchaseOrder.btnUpdate.Enabled = True
						MyProject.Forms.frmPurchaseOrder.GetSupplierBalance1()
						MyProject.Forms.frmPurchaseOrder.btnDelete.Enabled = True
						MyProject.Forms.frmPurchaseOrder.GetSupplierInfo()
						MyProject.Forms.frmPurchaseOrder.btnSelection.Enabled = False
						MyProject.Forms.frmPurchaseOrder.cmbTaxType.Enabled = False
						MyProject.Forms.frmPurchaseOrder.btnPrint.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,RTRIM(PurchaseOrder_Join.PTaxType),PurchaseOrder_Join.TaxableAmt,RTRIM(PurchaseOrder_Join.RCipher),RTRIM(PurchaseOrder_Join.WCipher), RTRIM(PurchaseOrder_Join.Barcode) from Product,PurchaseOrder,PurchaseOrder_Join where Product.PID=PurchaseOrder_Join.ProductID and PurchaseOrder.PO_ID=PurchaseOrder_Join.PurchaseOrderID and PO_ID=", dataGridViewRow.Cells(0).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPurchaseOrder.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPurchaseOrder.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPurchaseOrder.DataGridView1.ClearSelection()
						MyProject.Forms.frmPurchaseOrder.GridCalc()
						MyProject.Forms.frmPurchaseOrder.Compute()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011335 RID: 70453 RVA: 0x009FA418 File Offset: 0x009F8618
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

		' Token: 0x06011336 RID: 70454 RVA: 0x0007645B File Offset: 0x0007465B
		Public Sub Reset()
			Me.txtSupplierName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.cmbTerms.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x06011337 RID: 70455 RVA: 0x009FA500 File Offset: 0x009F8700
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and [Name] like N'" + Me.txtSupplierName.Text + "%' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011338 RID: 70456 RVA: 0x009FA74C File Offset: 0x009F894C
		Private Sub cmbTerms_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and Terms='" + Me.cmbTerms.Text + "' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011339 RID: 70457 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseOrderRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601133A RID: 70458 RVA: 0x009FA9A8 File Offset: 0x009F8BA8
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0601133B RID: 70459 RVA: 0x009FAAC0 File Offset: 0x009F8CC0
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				Me.txtSupplierName.Text = ""
				Me.cmbTerms.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601133C RID: 70460 RVA: 0x0007649B File Offset: 0x0007469B
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0601133D RID: 70461 RVA: 0x009FAD14 File Offset: 0x009F8F14
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
