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
	' Token: 0x0200058C RID: 1420
	<DesignerGenerated()>
	Public Partial Class frmSalesReturnRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060113BC RID: 70588 RVA: 0x00076787 File Offset: 0x00074987
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesReturnRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006ADB RID: 27355
		' (get) Token: 0x060113BF RID: 70591 RVA: 0x000767B9 File Offset: 0x000749B9
		' (set) Token: 0x060113C0 RID: 70592 RVA: 0x000767C3 File Offset: 0x000749C3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006ADC RID: 27356
		' (get) Token: 0x060113C1 RID: 70593 RVA: 0x000767CC File Offset: 0x000749CC
		' (set) Token: 0x060113C2 RID: 70594 RVA: 0x00A016A8 File Offset: 0x009FF8A8
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

		' Token: 0x17006ADD RID: 27357
		' (get) Token: 0x060113C3 RID: 70595 RVA: 0x000767D6 File Offset: 0x000749D6
		' (set) Token: 0x060113C4 RID: 70596 RVA: 0x000767E0 File Offset: 0x000749E0
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006ADE RID: 27358
		' (get) Token: 0x060113C5 RID: 70597 RVA: 0x000767E9 File Offset: 0x000749E9
		' (set) Token: 0x060113C6 RID: 70598 RVA: 0x00A01724 File Offset: 0x009FF924
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006ADF RID: 27359
		' (get) Token: 0x060113C7 RID: 70599 RVA: 0x000767F3 File Offset: 0x000749F3
		' (set) Token: 0x060113C8 RID: 70600 RVA: 0x000767FD File Offset: 0x000749FD
		Friend Overridable Property Label3 As Label

		' Token: 0x17006AE0 RID: 27360
		' (get) Token: 0x060113C9 RID: 70601 RVA: 0x00076806 File Offset: 0x00074A06
		' (set) Token: 0x060113CA RID: 70602 RVA: 0x00076810 File Offset: 0x00074A10
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006AE1 RID: 27361
		' (get) Token: 0x060113CB RID: 70603 RVA: 0x00076819 File Offset: 0x00074A19
		' (set) Token: 0x060113CC RID: 70604 RVA: 0x00076823 File Offset: 0x00074A23
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006AE2 RID: 27362
		' (get) Token: 0x060113CD RID: 70605 RVA: 0x0007682C File Offset: 0x00074A2C
		' (set) Token: 0x060113CE RID: 70606 RVA: 0x00076836 File Offset: 0x00074A36
		Friend Overridable Property Label2 As Label

		' Token: 0x17006AE3 RID: 27363
		' (get) Token: 0x060113CF RID: 70607 RVA: 0x0007683F File Offset: 0x00074A3F
		' (set) Token: 0x060113D0 RID: 70608 RVA: 0x00076849 File Offset: 0x00074A49
		Friend Overridable Property Label4 As Label

		' Token: 0x17006AE4 RID: 27364
		' (get) Token: 0x060113D1 RID: 70609 RVA: 0x00076852 File Offset: 0x00074A52
		' (set) Token: 0x060113D2 RID: 70610 RVA: 0x0007685C File Offset: 0x00074A5C
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006AE5 RID: 27365
		' (get) Token: 0x060113D3 RID: 70611 RVA: 0x00076865 File Offset: 0x00074A65
		' (set) Token: 0x060113D4 RID: 70612 RVA: 0x0007686F File Offset: 0x00074A6F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006AE6 RID: 27366
		' (get) Token: 0x060113D5 RID: 70613 RVA: 0x00076878 File Offset: 0x00074A78
		' (set) Token: 0x060113D6 RID: 70614 RVA: 0x00076882 File Offset: 0x00074A82
		Friend Overridable Property Label1 As Label

		' Token: 0x17006AE7 RID: 27367
		' (get) Token: 0x060113D7 RID: 70615 RVA: 0x0007688B File Offset: 0x00074A8B
		' (set) Token: 0x060113D8 RID: 70616 RVA: 0x00076895 File Offset: 0x00074A95
		Friend Overridable Property lblSet As Label

		' Token: 0x17006AE8 RID: 27368
		' (get) Token: 0x060113D9 RID: 70617 RVA: 0x0007689E File Offset: 0x00074A9E
		' (set) Token: 0x060113DA RID: 70618 RVA: 0x000768A8 File Offset: 0x00074AA8
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006AE9 RID: 27369
		' (get) Token: 0x060113DB RID: 70619 RVA: 0x000768B1 File Offset: 0x00074AB1
		' (set) Token: 0x060113DC RID: 70620 RVA: 0x000768BB File Offset: 0x00074ABB
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17006AEA RID: 27370
		' (get) Token: 0x060113DD RID: 70621 RVA: 0x000768C4 File Offset: 0x00074AC4
		' (set) Token: 0x060113DE RID: 70622 RVA: 0x000768CE File Offset: 0x00074ACE
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006AEB RID: 27371
		' (get) Token: 0x060113DF RID: 70623 RVA: 0x000768D7 File Offset: 0x00074AD7
		' (set) Token: 0x060113E0 RID: 70624 RVA: 0x000768E1 File Offset: 0x00074AE1
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006AEC RID: 27372
		' (get) Token: 0x060113E1 RID: 70625 RVA: 0x000768EA File Offset: 0x00074AEA
		' (set) Token: 0x060113E2 RID: 70626 RVA: 0x000768F4 File Offset: 0x00074AF4
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006AED RID: 27373
		' (get) Token: 0x060113E3 RID: 70627 RVA: 0x000768FD File Offset: 0x00074AFD
		' (set) Token: 0x060113E4 RID: 70628 RVA: 0x00076907 File Offset: 0x00074B07
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006AEE RID: 27374
		' (get) Token: 0x060113E5 RID: 70629 RVA: 0x00076910 File Offset: 0x00074B10
		' (set) Token: 0x060113E6 RID: 70630 RVA: 0x0007691A File Offset: 0x00074B1A
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006AEF RID: 27375
		' (get) Token: 0x060113E7 RID: 70631 RVA: 0x00076923 File Offset: 0x00074B23
		' (set) Token: 0x060113E8 RID: 70632 RVA: 0x0007692D File Offset: 0x00074B2D
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006AF0 RID: 27376
		' (get) Token: 0x060113E9 RID: 70633 RVA: 0x00076936 File Offset: 0x00074B36
		' (set) Token: 0x060113EA RID: 70634 RVA: 0x00076940 File Offset: 0x00074B40
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006AF1 RID: 27377
		' (get) Token: 0x060113EB RID: 70635 RVA: 0x00076949 File Offset: 0x00074B49
		' (set) Token: 0x060113EC RID: 70636 RVA: 0x00076953 File Offset: 0x00074B53
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006AF2 RID: 27378
		' (get) Token: 0x060113ED RID: 70637 RVA: 0x0007695C File Offset: 0x00074B5C
		' (set) Token: 0x060113EE RID: 70638 RVA: 0x00076966 File Offset: 0x00074B66
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006AF3 RID: 27379
		' (get) Token: 0x060113EF RID: 70639 RVA: 0x0007696F File Offset: 0x00074B6F
		' (set) Token: 0x060113F0 RID: 70640 RVA: 0x00076979 File Offset: 0x00074B79
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006AF4 RID: 27380
		' (get) Token: 0x060113F1 RID: 70641 RVA: 0x00076982 File Offset: 0x00074B82
		' (set) Token: 0x060113F2 RID: 70642 RVA: 0x0007698C File Offset: 0x00074B8C
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006AF5 RID: 27381
		' (get) Token: 0x060113F3 RID: 70643 RVA: 0x00076995 File Offset: 0x00074B95
		' (set) Token: 0x060113F4 RID: 70644 RVA: 0x0007699F File Offset: 0x00074B9F
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006AF6 RID: 27382
		' (get) Token: 0x060113F5 RID: 70645 RVA: 0x000769A8 File Offset: 0x00074BA8
		' (set) Token: 0x060113F6 RID: 70646 RVA: 0x000769B2 File Offset: 0x00074BB2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006AF7 RID: 27383
		' (get) Token: 0x060113F7 RID: 70647 RVA: 0x000769BB File Offset: 0x00074BBB
		' (set) Token: 0x060113F8 RID: 70648 RVA: 0x000769C5 File Offset: 0x00074BC5
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17006AF8 RID: 27384
		' (get) Token: 0x060113F9 RID: 70649 RVA: 0x000769CE File Offset: 0x00074BCE
		' (set) Token: 0x060113FA RID: 70650 RVA: 0x000769D8 File Offset: 0x00074BD8
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006AF9 RID: 27385
		' (get) Token: 0x060113FB RID: 70651 RVA: 0x000769E1 File Offset: 0x00074BE1
		' (set) Token: 0x060113FC RID: 70652 RVA: 0x000769EB File Offset: 0x00074BEB
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17006AFA RID: 27386
		' (get) Token: 0x060113FD RID: 70653 RVA: 0x000769F4 File Offset: 0x00074BF4
		' (set) Token: 0x060113FE RID: 70654 RVA: 0x000769FE File Offset: 0x00074BFE
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006AFB RID: 27387
		' (get) Token: 0x060113FF RID: 70655 RVA: 0x00076A07 File Offset: 0x00074C07
		' (set) Token: 0x06011400 RID: 70656 RVA: 0x00076A11 File Offset: 0x00074C11
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17006AFC RID: 27388
		' (get) Token: 0x06011401 RID: 70657 RVA: 0x00076A1A File Offset: 0x00074C1A
		' (set) Token: 0x06011402 RID: 70658 RVA: 0x00076A24 File Offset: 0x00074C24
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17006AFD RID: 27389
		' (get) Token: 0x06011403 RID: 70659 RVA: 0x00076A2D File Offset: 0x00074C2D
		' (set) Token: 0x06011404 RID: 70660 RVA: 0x00076A37 File Offset: 0x00074C37
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006AFE RID: 27390
		' (get) Token: 0x06011405 RID: 70661 RVA: 0x00076A40 File Offset: 0x00074C40
		' (set) Token: 0x06011406 RID: 70662 RVA: 0x00076A4A File Offset: 0x00074C4A
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006AFF RID: 27391
		' (get) Token: 0x06011407 RID: 70663 RVA: 0x00076A53 File Offset: 0x00074C53
		' (set) Token: 0x06011408 RID: 70664 RVA: 0x00A01768 File Offset: 0x009FF968
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

		' Token: 0x17006B00 RID: 27392
		' (get) Token: 0x06011409 RID: 70665 RVA: 0x00076A5D File Offset: 0x00074C5D
		' (set) Token: 0x0601140A RID: 70666 RVA: 0x00A017AC File Offset: 0x009FF9AC
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

		' Token: 0x17006B01 RID: 27393
		' (get) Token: 0x0601140B RID: 70667 RVA: 0x00076A67 File Offset: 0x00074C67
		' (set) Token: 0x0601140C RID: 70668 RVA: 0x00A017F0 File Offset: 0x009FF9F0
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0601140D RID: 70669 RVA: 0x00A01834 File Offset: 0x009FFA34
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

		' Token: 0x0601140E RID: 70670 RVA: 0x00A01908 File Offset: 0x009FFB08
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),SalesID,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal),SalesReturn.PaymentMode,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601140F RID: 70671 RVA: 0x00A01B9C File Offset: 0x009FFD9C
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

		' Token: 0x06011410 RID: 70672 RVA: 0x00A01C34 File Offset: 0x009FFE34
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

		' Token: 0x06011411 RID: 70673 RVA: 0x00A01DAC File Offset: 0x009FFFAC
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

		' Token: 0x06011412 RID: 70674 RVA: 0x00A01E78 File Offset: 0x00A00078
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

		' Token: 0x06011413 RID: 70675 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011414 RID: 70676 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011415 RID: 70677 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011416 RID: 70678 RVA: 0x00A01F44 File Offset: 0x00A00144
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011417 RID: 70679 RVA: 0x00A01F6C File Offset: 0x00A0016C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "SR", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmSalesReturn.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesReturn.txtSRID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSRNO.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesReturn.dtpSRDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtGSTnonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSalesID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSalesInvoiceNo.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmSalesReturn.dtpSalesDate.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCustomerID.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCustomerName.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSubTotal.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCGST.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtSGST.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtIGST.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtCESS.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtFreightCharges.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtBillDiscount.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtTotal.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtRoundOff.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmSalesReturn.txtGrandTotal.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmSalesReturn.cmbPmtMode.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmSalesReturn.cmbBSundry.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmSalesReturn.btnDelete.Enabled = False
						MyProject.Forms.frmSalesReturn.DataGridView1.Enabled = True
						MyProject.Forms.frmSalesReturn.btnAdd.Enabled = False
						MyProject.Forms.frmSalesReturn.btnRemove.Enabled = False
						MyProject.Forms.frmSalesReturn.lblSet.Text = "Not Allowed"
						MyProject.Forms.frmSalesReturn.btnDelete.Enabled = True
						MyProject.Forms.frmSalesReturn.btnSelection.Enabled = False
						MyProject.Forms.frmSalesReturn.btnPrint.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(SalesReturn_Join.Barcode),SalesReturn_Join.Qty, SalesReturn_Join.SalesRate,SalesReturn_Join. DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer,SalesReturn_Join. IGSTAmt, SalesReturn_Join.CESSPer,SalesReturn_Join. CESSAmt,ReturnQty,SalesReturn_Join. TotalAmount,SalesReturn_Join.PurchaseRate,SalesReturn_Join.Margin, RTRIM(SalesReturn_Join.STaxType), RTRIM(SalesReturn_Join.TaxableAmt) FROM SalesReturn_Join INNER JOIN SalesReturn ON SalesReturn_Join.SalesReturnID = SalesReturn.SR_ID INNER JOIN Product ON Product.PID = SalesReturn_Join.ProductID and SR_ID=", dataGridViewRow.Cells(0).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmSalesReturn.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmSalesReturn.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
						End While
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_saleReturn a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmSalesReturn.DataGridView5F.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmSalesReturn.DataGridView5F.Visible = True
							MyProject.Forms.frmSalesReturn.DataGridView5F.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmSalesReturn.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						MyProject.Forms.frmSalesReturn.Calc()
						MyProject.Forms.frmSalesReturn.Compute()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011418 RID: 70680 RVA: 0x00076A71 File Offset: 0x00074C71
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011419 RID: 70681 RVA: 0x00A027C8 File Offset: 0x00A009C8
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

		' Token: 0x0601141A RID: 70682 RVA: 0x00076A7B File Offset: 0x00074C7B
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x0601141B RID: 70683 RVA: 0x00A028B0 File Offset: 0x00A00AB0
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),SalesID,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal),SalesReturn.PaymentMode,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID  and [Name] like N'" + Me.txtCustomerName.Text + "%' and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601141C RID: 70684 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesReturnRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601141D RID: 70685 RVA: 0x00A02B60 File Offset: 0x00A00D60
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

		' Token: 0x0601141E RID: 70686 RVA: 0x00076AAE File Offset: 0x00074CAE
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0601141F RID: 70687 RVA: 0x00A02C78 File Offset: 0x00A00E78
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

		' Token: 0x06011420 RID: 70688 RVA: 0x00A02F24 File Offset: 0x00A01124
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),SalesID,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal),SalesReturn.PaymentMode,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub
	End Class
End Namespace
