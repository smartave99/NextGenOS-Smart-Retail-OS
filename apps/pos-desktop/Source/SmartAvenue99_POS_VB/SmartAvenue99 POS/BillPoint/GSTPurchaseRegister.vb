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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004EF RID: 1263
	<DesignerGenerated()>
	Public Partial Class GSTPurchaseRegister
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010389 RID: 66441 RVA: 0x00071EFA File Offset: 0x000700FA
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.GSTPurchaseRegister_Load
			AddHandler MyBase.KeyDown, AddressOf Me.GSTPurchaseRegister_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700633E RID: 25406
		' (get) Token: 0x0601038C RID: 66444 RVA: 0x00071F2C File Offset: 0x0007012C
		' (set) Token: 0x0601038D RID: 66445 RVA: 0x00071F36 File Offset: 0x00070136
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700633F RID: 25407
		' (get) Token: 0x0601038E RID: 66446 RVA: 0x00071F3F File Offset: 0x0007013F
		' (set) Token: 0x0601038F RID: 66447 RVA: 0x00071F49 File Offset: 0x00070149
		Friend Overridable Property Label11 As Label

		' Token: 0x17006340 RID: 25408
		' (get) Token: 0x06010390 RID: 66448 RVA: 0x00071F52 File Offset: 0x00070152
		' (set) Token: 0x06010391 RID: 66449 RVA: 0x00071F5C File Offset: 0x0007015C
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17006341 RID: 25409
		' (get) Token: 0x06010392 RID: 66450 RVA: 0x00071F65 File Offset: 0x00070165
		' (set) Token: 0x06010393 RID: 66451 RVA: 0x00071F6F File Offset: 0x0007016F
		Friend Overridable Property Label10 As Label

		' Token: 0x17006342 RID: 25410
		' (get) Token: 0x06010394 RID: 66452 RVA: 0x00071F78 File Offset: 0x00070178
		' (set) Token: 0x06010395 RID: 66453 RVA: 0x00071F82 File Offset: 0x00070182
		Friend Overridable Property Label9 As Label

		' Token: 0x17006343 RID: 25411
		' (get) Token: 0x06010396 RID: 66454 RVA: 0x00071F8B File Offset: 0x0007018B
		' (set) Token: 0x06010397 RID: 66455 RVA: 0x00071F95 File Offset: 0x00070195
		Friend Overridable Property Label8 As Label

		' Token: 0x17006344 RID: 25412
		' (get) Token: 0x06010398 RID: 66456 RVA: 0x00071F9E File Offset: 0x0007019E
		' (set) Token: 0x06010399 RID: 66457 RVA: 0x00071FA8 File Offset: 0x000701A8
		Friend Overridable Property Label7 As Label

		' Token: 0x17006345 RID: 25413
		' (get) Token: 0x0601039A RID: 66458 RVA: 0x00071FB1 File Offset: 0x000701B1
		' (set) Token: 0x0601039B RID: 66459 RVA: 0x00071FBB File Offset: 0x000701BB
		Friend Overridable Property Label6 As Label

		' Token: 0x17006346 RID: 25414
		' (get) Token: 0x0601039C RID: 66460 RVA: 0x00071FC4 File Offset: 0x000701C4
		' (set) Token: 0x0601039D RID: 66461 RVA: 0x00071FCE File Offset: 0x000701CE
		Friend Overridable Property Label5 As Label

		' Token: 0x17006347 RID: 25415
		' (get) Token: 0x0601039E RID: 66462 RVA: 0x00071FD7 File Offset: 0x000701D7
		' (set) Token: 0x0601039F RID: 66463 RVA: 0x00071FE1 File Offset: 0x000701E1
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006348 RID: 25416
		' (get) Token: 0x060103A0 RID: 66464 RVA: 0x00071FEA File Offset: 0x000701EA
		' (set) Token: 0x060103A1 RID: 66465 RVA: 0x00071FF4 File Offset: 0x000701F4
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17006349 RID: 25417
		' (get) Token: 0x060103A2 RID: 66466 RVA: 0x00071FFD File Offset: 0x000701FD
		' (set) Token: 0x060103A3 RID: 66467 RVA: 0x00072007 File Offset: 0x00070207
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700634A RID: 25418
		' (get) Token: 0x060103A4 RID: 66468 RVA: 0x00072010 File Offset: 0x00070210
		' (set) Token: 0x060103A5 RID: 66469 RVA: 0x0007201A File Offset: 0x0007021A
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x1700634B RID: 25419
		' (get) Token: 0x060103A6 RID: 66470 RVA: 0x00072023 File Offset: 0x00070223
		' (set) Token: 0x060103A7 RID: 66471 RVA: 0x0007202D File Offset: 0x0007022D
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x1700634C RID: 25420
		' (get) Token: 0x060103A8 RID: 66472 RVA: 0x00072036 File Offset: 0x00070236
		' (set) Token: 0x060103A9 RID: 66473 RVA: 0x00072040 File Offset: 0x00070240
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x1700634D RID: 25421
		' (get) Token: 0x060103AA RID: 66474 RVA: 0x00072049 File Offset: 0x00070249
		' (set) Token: 0x060103AB RID: 66475 RVA: 0x00072053 File Offset: 0x00070253
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x1700634E RID: 25422
		' (get) Token: 0x060103AC RID: 66476 RVA: 0x0007205C File Offset: 0x0007025C
		' (set) Token: 0x060103AD RID: 66477 RVA: 0x00072066 File Offset: 0x00070266
		Friend Overridable Property Label3 As Label

		' Token: 0x1700634F RID: 25423
		' (get) Token: 0x060103AE RID: 66478 RVA: 0x0007206F File Offset: 0x0007026F
		' (set) Token: 0x060103AF RID: 66479 RVA: 0x00072079 File Offset: 0x00070279
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006350 RID: 25424
		' (get) Token: 0x060103B0 RID: 66480 RVA: 0x00072082 File Offset: 0x00070282
		' (set) Token: 0x060103B1 RID: 66481 RVA: 0x0007208C File Offset: 0x0007028C
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006351 RID: 25425
		' (get) Token: 0x060103B2 RID: 66482 RVA: 0x00072095 File Offset: 0x00070295
		' (set) Token: 0x060103B3 RID: 66483 RVA: 0x0007209F File Offset: 0x0007029F
		Friend Overridable Property Label2 As Label

		' Token: 0x17006352 RID: 25426
		' (get) Token: 0x060103B4 RID: 66484 RVA: 0x000720A8 File Offset: 0x000702A8
		' (set) Token: 0x060103B5 RID: 66485 RVA: 0x000720B2 File Offset: 0x000702B2
		Friend Overridable Property Label4 As Label

		' Token: 0x17006353 RID: 25427
		' (get) Token: 0x060103B6 RID: 66486 RVA: 0x000720BB File Offset: 0x000702BB
		' (set) Token: 0x060103B7 RID: 66487 RVA: 0x000720C5 File Offset: 0x000702C5
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006354 RID: 25428
		' (get) Token: 0x060103B8 RID: 66488 RVA: 0x000720CE File Offset: 0x000702CE
		' (set) Token: 0x060103B9 RID: 66489 RVA: 0x009AA5D0 File Offset: 0x009A87D0
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

		' Token: 0x17006355 RID: 25429
		' (get) Token: 0x060103BA RID: 66490 RVA: 0x000720D8 File Offset: 0x000702D8
		' (set) Token: 0x060103BB RID: 66491 RVA: 0x000720E2 File Offset: 0x000702E2
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006356 RID: 25430
		' (get) Token: 0x060103BC RID: 66492 RVA: 0x000720EB File Offset: 0x000702EB
		' (set) Token: 0x060103BD RID: 66493 RVA: 0x000720F5 File Offset: 0x000702F5
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006357 RID: 25431
		' (get) Token: 0x060103BE RID: 66494 RVA: 0x000720FE File Offset: 0x000702FE
		' (set) Token: 0x060103BF RID: 66495 RVA: 0x00072108 File Offset: 0x00070308
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006358 RID: 25432
		' (get) Token: 0x060103C0 RID: 66496 RVA: 0x00072111 File Offset: 0x00070311
		' (set) Token: 0x060103C1 RID: 66497 RVA: 0x0007211B File Offset: 0x0007031B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006359 RID: 25433
		' (get) Token: 0x060103C2 RID: 66498 RVA: 0x00072124 File Offset: 0x00070324
		' (set) Token: 0x060103C3 RID: 66499 RVA: 0x0007212E File Offset: 0x0007032E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700635A RID: 25434
		' (get) Token: 0x060103C4 RID: 66500 RVA: 0x00072137 File Offset: 0x00070337
		' (set) Token: 0x060103C5 RID: 66501 RVA: 0x00072141 File Offset: 0x00070341
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700635B RID: 25435
		' (get) Token: 0x060103C6 RID: 66502 RVA: 0x0007214A File Offset: 0x0007034A
		' (set) Token: 0x060103C7 RID: 66503 RVA: 0x00072154 File Offset: 0x00070354
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700635C RID: 25436
		' (get) Token: 0x060103C8 RID: 66504 RVA: 0x0007215D File Offset: 0x0007035D
		' (set) Token: 0x060103C9 RID: 66505 RVA: 0x00072167 File Offset: 0x00070367
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700635D RID: 25437
		' (get) Token: 0x060103CA RID: 66506 RVA: 0x00072170 File Offset: 0x00070370
		' (set) Token: 0x060103CB RID: 66507 RVA: 0x0007217A File Offset: 0x0007037A
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700635E RID: 25438
		' (get) Token: 0x060103CC RID: 66508 RVA: 0x00072183 File Offset: 0x00070383
		' (set) Token: 0x060103CD RID: 66509 RVA: 0x0007218D File Offset: 0x0007038D
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700635F RID: 25439
		' (get) Token: 0x060103CE RID: 66510 RVA: 0x00072196 File Offset: 0x00070396
		' (set) Token: 0x060103CF RID: 66511 RVA: 0x000721A0 File Offset: 0x000703A0
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006360 RID: 25440
		' (get) Token: 0x060103D0 RID: 66512 RVA: 0x000721A9 File Offset: 0x000703A9
		' (set) Token: 0x060103D1 RID: 66513 RVA: 0x000721B3 File Offset: 0x000703B3
		Friend Overridable Property Label1 As Label

		' Token: 0x17006361 RID: 25441
		' (get) Token: 0x060103D2 RID: 66514 RVA: 0x000721BC File Offset: 0x000703BC
		' (set) Token: 0x060103D3 RID: 66515 RVA: 0x000721C6 File Offset: 0x000703C6
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006362 RID: 25442
		' (get) Token: 0x060103D4 RID: 66516 RVA: 0x000721CF File Offset: 0x000703CF
		' (set) Token: 0x060103D5 RID: 66517 RVA: 0x009AA614 File Offset: 0x009A8814
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006363 RID: 25443
		' (get) Token: 0x060103D6 RID: 66518 RVA: 0x000721D9 File Offset: 0x000703D9
		' (set) Token: 0x060103D7 RID: 66519 RVA: 0x000721E3 File Offset: 0x000703E3
		Friend Overridable Property btnAddCustomer As GelButton

		' Token: 0x17006364 RID: 25444
		' (get) Token: 0x060103D8 RID: 66520 RVA: 0x000721EC File Offset: 0x000703EC
		' (set) Token: 0x060103D9 RID: 66521 RVA: 0x009AA658 File Offset: 0x009A8858
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

		' Token: 0x17006365 RID: 25445
		' (get) Token: 0x060103DA RID: 66522 RVA: 0x000721F6 File Offset: 0x000703F6
		' (set) Token: 0x060103DB RID: 66523 RVA: 0x009AA69C File Offset: 0x009A889C
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

		' Token: 0x17006366 RID: 25446
		' (get) Token: 0x060103DC RID: 66524 RVA: 0x00072200 File Offset: 0x00070400
		' (set) Token: 0x060103DD RID: 66525 RVA: 0x009AA6E0 File Offset: 0x009A88E0
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

		' Token: 0x17006367 RID: 25447
		' (get) Token: 0x060103DE RID: 66526 RVA: 0x0007220A File Offset: 0x0007040A
		' (set) Token: 0x060103DF RID: 66527 RVA: 0x009AA724 File Offset: 0x009A8924
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
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

		' Token: 0x060103E0 RID: 66528 RVA: 0x009AA768 File Offset: 0x009A8968
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

		' Token: 0x060103E1 RID: 66529 RVA: 0x009AA83C File Offset: 0x009A8A3C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceNo), Date, RTRIM(Supplier.Name),RTRIM(Supplier.GSTIN), ((TaxableAmt + CGST + SGST + IGST + CESS + FreightCharges)-OtherCharges), TaxableAmt, CGST,SGST,IGST,CESS, (FreightCharges - OtherCharges) from Supplier,Stock where Supplier.ID=Stock.SupplierID and [Date] between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060103E2 RID: 66530 RVA: 0x009AAA3C File Offset: 0x009A8C3C
		Private Sub GSTPurchaseRegister_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.cal()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060103E3 RID: 66531 RVA: 0x009AAAD4 File Offset: 0x009A8CD4
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

		' Token: 0x060103E4 RID: 66532 RVA: 0x009AAC4C File Offset: 0x009A8E4C
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

		' Token: 0x060103E5 RID: 66533 RVA: 0x009AAD18 File Offset: 0x009A8F18
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

		' Token: 0x060103E6 RID: 66534 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060103E7 RID: 66535 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060103E8 RID: 66536 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060103E9 RID: 66537 RVA: 0x009AADE4 File Offset: 0x009A8FE4
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

		' Token: 0x060103EA RID: 66538 RVA: 0x009AAECC File Offset: 0x009A90CC
		Private Sub cal()
			Me.TextBox1.Text = "0.00"
			Me.TextBox2.Text = "0.00"
			Me.TextBox3.Text = "0.00"
			Me.TextBox4.Text = "0.00"
			Me.TextBox5.Text = "0.00"
			Me.TextBox6.Text = "0.00"
			Me.TextBox7.Text = "0.00"
			Dim num As Integer = Me.dgw.Rows.Count - 1
			Dim num2 As Double
			For i As Integer = 0 To num
				Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))

					If flag Then
						num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))
					End If

			Next
			Me.TextBox1.Text = Conversions.ToString(num2)
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Dim num3 As Integer = Me.dgw.Rows.Count - 1
			Dim num4 As Double
			For j As Integer = 0 To num3
				Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))

					If flag2 Then
						num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))
					End If

			Next
			Me.TextBox2.Text = Conversions.ToString(num4)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 2), "0.00")
			Dim num5 As Integer = Me.dgw.Rows.Count - 1
			Dim num6 As Double
			For k As Integer = 0 To num5
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))

					If flag3 Then
						num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))
					End If

			Next
			Me.TextBox3.Text = Conversions.ToString(num6)
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
			Dim num7 As Integer = Me.dgw.Rows.Count - 1
			Dim num8 As Double
			For l As Integer = 0 To num7
				Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))

					If flag4 Then
						num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))
					End If

			Next
			Me.TextBox4.Text = Conversions.ToString(num8)
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Dim num9 As Integer = Me.dgw.Rows.Count - 1
			Dim num10 As Double
			For m As Integer = 0 To num9
				Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))

					If flag5 Then
						num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))
					End If

			Next
			Me.TextBox5.Text = Conversions.ToString(num10)
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
			Dim num11 As Integer = Me.dgw.Rows.Count - 1
			Dim num12 As Double
			For n As Integer = 0 To num11
				Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))

					If flag6 Then
						num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))
					End If

			Next
			Me.TextBox6.Text = Conversions.ToString(num12)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text), 2), "0.00")
			Dim num13 As Integer = Me.dgw.Rows.Count - 1
			Dim num15 As Double
			For num14 As Integer = 0 To num13
				Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))

					If flag7 Then
						num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))
					End If

			Next
			Me.TextBox7.Text = Conversions.ToString(num15)
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
		End Sub

		' Token: 0x060103EB RID: 66539 RVA: 0x00072214 File Offset: 0x00070414
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060103EC RID: 66540 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub GSTPurchaseRegister_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060103ED RID: 66541 RVA: 0x00072230 File Offset: 0x00070430
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x060103EE RID: 66542 RVA: 0x00072241 File Offset: 0x00070441
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x060103EF RID: 66543 RVA: 0x009AB534 File Offset: 0x009A9734
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.RowCount = 0
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("BillNo")
				dataTable2.Columns.Add("Date")
				dataTable2.Columns.Add("CName")
				dataTable2.Columns.Add("GSTIN")
				dataTable2.Columns.Add("BillAmt")
				dataTable2.Columns.Add("TxblAmt")
				dataTable2.Columns.Add("CGSTAmt")
				dataTable2.Columns.Add("SGSTAmt")
				dataTable2.Columns.Add("IGSTAmt")
				dataTable2.Columns.Add("CESSAmt")
				dataTable2.Columns.Add("OtherAmt")
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New rptGSTSale()
				reportDocument.SetDataSource(dataTable)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text27"), TextObject)
				textObject.Text = Me.dtpDateFrom.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text28"), TextObject)
				textObject2.Text = Me.dtpDateTo.Text
				Dim textObject3 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text22"), TextObject)
				textObject3.Text = Me.Label1.Text
				Dim textObject4 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text3"), TextObject)
				textObject4.Text = "Supplier Name"
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x060103F0 RID: 66544 RVA: 0x009AB8FC File Offset: 0x009A9AFC
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
