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
	' Token: 0x020004F0 RID: 1264
	<DesignerGenerated()>
	Public Partial Class GSTSaleRegister
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060103F1 RID: 66545 RVA: 0x0007226A File Offset: 0x0007046A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.GSTSaleRegister_Load
			AddHandler MyBase.KeyDown, AddressOf Me.GSTSaleRegister_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006368 RID: 25448
		' (get) Token: 0x060103F4 RID: 66548 RVA: 0x0007229C File Offset: 0x0007049C
		' (set) Token: 0x060103F5 RID: 66549 RVA: 0x000722A6 File Offset: 0x000704A6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006369 RID: 25449
		' (get) Token: 0x060103F6 RID: 66550 RVA: 0x000722AF File Offset: 0x000704AF
		' (set) Token: 0x060103F7 RID: 66551 RVA: 0x000722B9 File Offset: 0x000704B9
		Friend Overridable Property Label1 As Label

		' Token: 0x1700636A RID: 25450
		' (get) Token: 0x060103F8 RID: 66552 RVA: 0x000722C2 File Offset: 0x000704C2
		' (set) Token: 0x060103F9 RID: 66553 RVA: 0x009ADC54 File Offset: 0x009ABE54
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

		' Token: 0x1700636B RID: 25451
		' (get) Token: 0x060103FA RID: 66554 RVA: 0x000722CC File Offset: 0x000704CC
		' (set) Token: 0x060103FB RID: 66555 RVA: 0x000722D6 File Offset: 0x000704D6
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700636C RID: 25452
		' (get) Token: 0x060103FC RID: 66556 RVA: 0x000722DF File Offset: 0x000704DF
		' (set) Token: 0x060103FD RID: 66557 RVA: 0x000722E9 File Offset: 0x000704E9
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700636D RID: 25453
		' (get) Token: 0x060103FE RID: 66558 RVA: 0x000722F2 File Offset: 0x000704F2
		' (set) Token: 0x060103FF RID: 66559 RVA: 0x000722FC File Offset: 0x000704FC
		Friend Overridable Property Label2 As Label

		' Token: 0x1700636E RID: 25454
		' (get) Token: 0x06010400 RID: 66560 RVA: 0x00072305 File Offset: 0x00070505
		' (set) Token: 0x06010401 RID: 66561 RVA: 0x0007230F File Offset: 0x0007050F
		Friend Overridable Property Label4 As Label

		' Token: 0x1700636F RID: 25455
		' (get) Token: 0x06010402 RID: 66562 RVA: 0x00072318 File Offset: 0x00070518
		' (set) Token: 0x06010403 RID: 66563 RVA: 0x00072322 File Offset: 0x00070522
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006370 RID: 25456
		' (get) Token: 0x06010404 RID: 66564 RVA: 0x0007232B File Offset: 0x0007052B
		' (set) Token: 0x06010405 RID: 66565 RVA: 0x00072335 File Offset: 0x00070535
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006371 RID: 25457
		' (get) Token: 0x06010406 RID: 66566 RVA: 0x0007233E File Offset: 0x0007053E
		' (set) Token: 0x06010407 RID: 66567 RVA: 0x00072348 File Offset: 0x00070548
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006372 RID: 25458
		' (get) Token: 0x06010408 RID: 66568 RVA: 0x00072351 File Offset: 0x00070551
		' (set) Token: 0x06010409 RID: 66569 RVA: 0x0007235B File Offset: 0x0007055B
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006373 RID: 25459
		' (get) Token: 0x0601040A RID: 66570 RVA: 0x00072364 File Offset: 0x00070564
		' (set) Token: 0x0601040B RID: 66571 RVA: 0x0007236E File Offset: 0x0007056E
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006374 RID: 25460
		' (get) Token: 0x0601040C RID: 66572 RVA: 0x00072377 File Offset: 0x00070577
		' (set) Token: 0x0601040D RID: 66573 RVA: 0x00072381 File Offset: 0x00070581
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006375 RID: 25461
		' (get) Token: 0x0601040E RID: 66574 RVA: 0x0007238A File Offset: 0x0007058A
		' (set) Token: 0x0601040F RID: 66575 RVA: 0x00072394 File Offset: 0x00070594
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006376 RID: 25462
		' (get) Token: 0x06010410 RID: 66576 RVA: 0x0007239D File Offset: 0x0007059D
		' (set) Token: 0x06010411 RID: 66577 RVA: 0x000723A7 File Offset: 0x000705A7
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006377 RID: 25463
		' (get) Token: 0x06010412 RID: 66578 RVA: 0x000723B0 File Offset: 0x000705B0
		' (set) Token: 0x06010413 RID: 66579 RVA: 0x000723BA File Offset: 0x000705BA
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006378 RID: 25464
		' (get) Token: 0x06010414 RID: 66580 RVA: 0x000723C3 File Offset: 0x000705C3
		' (set) Token: 0x06010415 RID: 66581 RVA: 0x000723CD File Offset: 0x000705CD
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006379 RID: 25465
		' (get) Token: 0x06010416 RID: 66582 RVA: 0x000723D6 File Offset: 0x000705D6
		' (set) Token: 0x06010417 RID: 66583 RVA: 0x000723E0 File Offset: 0x000705E0
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700637A RID: 25466
		' (get) Token: 0x06010418 RID: 66584 RVA: 0x000723E9 File Offset: 0x000705E9
		' (set) Token: 0x06010419 RID: 66585 RVA: 0x000723F3 File Offset: 0x000705F3
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700637B RID: 25467
		' (get) Token: 0x0601041A RID: 66586 RVA: 0x000723FC File Offset: 0x000705FC
		' (set) Token: 0x0601041B RID: 66587 RVA: 0x00072406 File Offset: 0x00070606
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x1700637C RID: 25468
		' (get) Token: 0x0601041C RID: 66588 RVA: 0x0007240F File Offset: 0x0007060F
		' (set) Token: 0x0601041D RID: 66589 RVA: 0x00072419 File Offset: 0x00070619
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700637D RID: 25469
		' (get) Token: 0x0601041E RID: 66590 RVA: 0x00072422 File Offset: 0x00070622
		' (set) Token: 0x0601041F RID: 66591 RVA: 0x0007242C File Offset: 0x0007062C
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x1700637E RID: 25470
		' (get) Token: 0x06010420 RID: 66592 RVA: 0x00072435 File Offset: 0x00070635
		' (set) Token: 0x06010421 RID: 66593 RVA: 0x0007243F File Offset: 0x0007063F
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700637F RID: 25471
		' (get) Token: 0x06010422 RID: 66594 RVA: 0x00072448 File Offset: 0x00070648
		' (set) Token: 0x06010423 RID: 66595 RVA: 0x00072452 File Offset: 0x00070652
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17006380 RID: 25472
		' (get) Token: 0x06010424 RID: 66596 RVA: 0x0007245B File Offset: 0x0007065B
		' (set) Token: 0x06010425 RID: 66597 RVA: 0x00072465 File Offset: 0x00070665
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17006381 RID: 25473
		' (get) Token: 0x06010426 RID: 66598 RVA: 0x0007246E File Offset: 0x0007066E
		' (set) Token: 0x06010427 RID: 66599 RVA: 0x00072478 File Offset: 0x00070678
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17006382 RID: 25474
		' (get) Token: 0x06010428 RID: 66600 RVA: 0x00072481 File Offset: 0x00070681
		' (set) Token: 0x06010429 RID: 66601 RVA: 0x0007248B File Offset: 0x0007068B
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17006383 RID: 25475
		' (get) Token: 0x0601042A RID: 66602 RVA: 0x00072494 File Offset: 0x00070694
		' (set) Token: 0x0601042B RID: 66603 RVA: 0x0007249E File Offset: 0x0007069E
		Friend Overridable Property Label10 As Label

		' Token: 0x17006384 RID: 25476
		' (get) Token: 0x0601042C RID: 66604 RVA: 0x000724A7 File Offset: 0x000706A7
		' (set) Token: 0x0601042D RID: 66605 RVA: 0x000724B1 File Offset: 0x000706B1
		Friend Overridable Property Label9 As Label

		' Token: 0x17006385 RID: 25477
		' (get) Token: 0x0601042E RID: 66606 RVA: 0x000724BA File Offset: 0x000706BA
		' (set) Token: 0x0601042F RID: 66607 RVA: 0x000724C4 File Offset: 0x000706C4
		Friend Overridable Property Label8 As Label

		' Token: 0x17006386 RID: 25478
		' (get) Token: 0x06010430 RID: 66608 RVA: 0x000724CD File Offset: 0x000706CD
		' (set) Token: 0x06010431 RID: 66609 RVA: 0x000724D7 File Offset: 0x000706D7
		Friend Overridable Property Label7 As Label

		' Token: 0x17006387 RID: 25479
		' (get) Token: 0x06010432 RID: 66610 RVA: 0x000724E0 File Offset: 0x000706E0
		' (set) Token: 0x06010433 RID: 66611 RVA: 0x000724EA File Offset: 0x000706EA
		Friend Overridable Property Label6 As Label

		' Token: 0x17006388 RID: 25480
		' (get) Token: 0x06010434 RID: 66612 RVA: 0x000724F3 File Offset: 0x000706F3
		' (set) Token: 0x06010435 RID: 66613 RVA: 0x000724FD File Offset: 0x000706FD
		Friend Overridable Property Label5 As Label

		' Token: 0x17006389 RID: 25481
		' (get) Token: 0x06010436 RID: 66614 RVA: 0x00072506 File Offset: 0x00070706
		' (set) Token: 0x06010437 RID: 66615 RVA: 0x00072510 File Offset: 0x00070710
		Friend Overridable Property Label3 As Label

		' Token: 0x1700638A RID: 25482
		' (get) Token: 0x06010438 RID: 66616 RVA: 0x00072519 File Offset: 0x00070719
		' (set) Token: 0x06010439 RID: 66617 RVA: 0x00072523 File Offset: 0x00070723
		Friend Overridable Property Label11 As Label

		' Token: 0x1700638B RID: 25483
		' (get) Token: 0x0601043A RID: 66618 RVA: 0x0007252C File Offset: 0x0007072C
		' (set) Token: 0x0601043B RID: 66619 RVA: 0x00072536 File Offset: 0x00070736
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700638C RID: 25484
		' (get) Token: 0x0601043C RID: 66620 RVA: 0x0007253F File Offset: 0x0007073F
		' (set) Token: 0x0601043D RID: 66621 RVA: 0x009ADC98 File Offset: 0x009ABE98
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

		' Token: 0x1700638D RID: 25485
		' (get) Token: 0x0601043E RID: 66622 RVA: 0x00072549 File Offset: 0x00070749
		' (set) Token: 0x0601043F RID: 66623 RVA: 0x009ADCDC File Offset: 0x009ABEDC
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

		' Token: 0x1700638E RID: 25486
		' (get) Token: 0x06010440 RID: 66624 RVA: 0x00072553 File Offset: 0x00070753
		' (set) Token: 0x06010441 RID: 66625 RVA: 0x009ADD20 File Offset: 0x009ABF20
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

		' Token: 0x1700638F RID: 25487
		' (get) Token: 0x06010442 RID: 66626 RVA: 0x0007255D File Offset: 0x0007075D
		' (set) Token: 0x06010443 RID: 66627 RVA: 0x009ADD64 File Offset: 0x009ABF64
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

		' Token: 0x17006390 RID: 25488
		' (get) Token: 0x06010444 RID: 66628 RVA: 0x00072567 File Offset: 0x00070767
		' (set) Token: 0x06010445 RID: 66629 RVA: 0x009ADDA8 File Offset: 0x009ABFA8
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

		' Token: 0x06010446 RID: 66630 RVA: 0x009ADDEC File Offset: 0x009ABFEC
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

		' Token: 0x06010447 RID: 66631 RVA: 0x009ADEC0 File Offset: 0x009AC0C0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(InvoiceNo), InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.GSTIN), GrandTotal, TaxableAmt, CGST, SGST, IGST, CESS, (GrandTotal-(TaxableAmt + CGST + SGST + IGST + CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 and NOT InvoiceInfo.TaxType='NON GST' order by InvoiceDate", ModCommonClasses.con)
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

		' Token: 0x06010448 RID: 66632 RVA: 0x009AE0C0 File Offset: 0x009AC2C0
		Private Sub GSTSaleRegister_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.cal()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010449 RID: 66633 RVA: 0x009AE158 File Offset: 0x009AC358
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

		' Token: 0x0601044A RID: 66634 RVA: 0x009AE2D0 File Offset: 0x009AC4D0
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

		' Token: 0x0601044B RID: 66635 RVA: 0x009AE39C File Offset: 0x009AC59C
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

		' Token: 0x0601044C RID: 66636 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601044D RID: 66637 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601044E RID: 66638 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601044F RID: 66639 RVA: 0x009AE468 File Offset: 0x009AC668
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

		' Token: 0x06010450 RID: 66640 RVA: 0x009AE550 File Offset: 0x009AC750
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

		' Token: 0x06010451 RID: 66641 RVA: 0x00072571 File Offset: 0x00070771
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06010452 RID: 66642 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub GSTSaleRegister_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010453 RID: 66643 RVA: 0x009AEBB8 File Offset: 0x009ACDB8
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

		' Token: 0x06010454 RID: 66644 RVA: 0x009AEE64 File Offset: 0x009AD064
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
				textObject4.Text = "Customer Name"
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x06010455 RID: 66645 RVA: 0x0007258D File Offset: 0x0007078D
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x06010456 RID: 66646 RVA: 0x000725B6 File Offset: 0x000707B6
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.cal()
		End Sub
	End Class
End Namespace
