Imports System
Imports System.Collections
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
	' Token: 0x020001F4 RID: 500
	<DesignerGenerated()>
	Public Partial Class frmSaleReport_Multi_Payment
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008E24 RID: 36388 RVA: 0x000455BA File Offset: 0x000437BA
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSaleReport_Multi_Payment_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003469 RID: 13417
		' (get) Token: 0x06008E27 RID: 36391 RVA: 0x000455DA File Offset: 0x000437DA
		' (set) Token: 0x06008E28 RID: 36392 RVA: 0x000455E4 File Offset: 0x000437E4
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x1700346A RID: 13418
		' (get) Token: 0x06008E29 RID: 36393 RVA: 0x000455ED File Offset: 0x000437ED
		' (set) Token: 0x06008E2A RID: 36394 RVA: 0x000455F7 File Offset: 0x000437F7
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700346B RID: 13419
		' (get) Token: 0x06008E2B RID: 36395 RVA: 0x00045600 File Offset: 0x00043800
		' (set) Token: 0x06008E2C RID: 36396 RVA: 0x0004560A File Offset: 0x0004380A
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700346C RID: 13420
		' (get) Token: 0x06008E2D RID: 36397 RVA: 0x00045613 File Offset: 0x00043813
		' (set) Token: 0x06008E2E RID: 36398 RVA: 0x00683B10 File Offset: 0x00681D10
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

		' Token: 0x1700346D RID: 13421
		' (get) Token: 0x06008E2F RID: 36399 RVA: 0x0004561D File Offset: 0x0004381D
		' (set) Token: 0x06008E30 RID: 36400 RVA: 0x00045627 File Offset: 0x00043827
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700346E RID: 13422
		' (get) Token: 0x06008E31 RID: 36401 RVA: 0x00045630 File Offset: 0x00043830
		' (set) Token: 0x06008E32 RID: 36402 RVA: 0x00683B54 File Offset: 0x00681D54
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700346F RID: 13423
		' (get) Token: 0x06008E33 RID: 36403 RVA: 0x0004563A File Offset: 0x0004383A
		' (set) Token: 0x06008E34 RID: 36404 RVA: 0x00045644 File Offset: 0x00043844
		Friend Overridable Property btnReset As GelButton

		' Token: 0x17003470 RID: 13424
		' (get) Token: 0x06008E35 RID: 36405 RVA: 0x0004564D File Offset: 0x0004384D
		' (set) Token: 0x06008E36 RID: 36406 RVA: 0x00045657 File Offset: 0x00043857
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17003471 RID: 13425
		' (get) Token: 0x06008E37 RID: 36407 RVA: 0x00045660 File Offset: 0x00043860
		' (set) Token: 0x06008E38 RID: 36408 RVA: 0x0004566A File Offset: 0x0004386A
		Friend Overridable Property Label1 As Label

		' Token: 0x17003472 RID: 13426
		' (get) Token: 0x06008E39 RID: 36409 RVA: 0x00045673 File Offset: 0x00043873
		' (set) Token: 0x06008E3A RID: 36410 RVA: 0x0004567D File Offset: 0x0004387D
		Friend Overridable Property Label3 As Label

		' Token: 0x17003473 RID: 13427
		' (get) Token: 0x06008E3B RID: 36411 RVA: 0x00045686 File Offset: 0x00043886
		' (set) Token: 0x06008E3C RID: 36412 RVA: 0x00045690 File Offset: 0x00043890
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003474 RID: 13428
		' (get) Token: 0x06008E3D RID: 36413 RVA: 0x00045699 File Offset: 0x00043899
		' (set) Token: 0x06008E3E RID: 36414 RVA: 0x000456A3 File Offset: 0x000438A3
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17003475 RID: 13429
		' (get) Token: 0x06008E3F RID: 36415 RVA: 0x000456AC File Offset: 0x000438AC
		' (set) Token: 0x06008E40 RID: 36416 RVA: 0x000456B6 File Offset: 0x000438B6
		Friend Overridable Property Label8 As Label

		' Token: 0x17003476 RID: 13430
		' (get) Token: 0x06008E41 RID: 36417 RVA: 0x000456BF File Offset: 0x000438BF
		' (set) Token: 0x06008E42 RID: 36418 RVA: 0x00683B98 File Offset: 0x00681D98
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003477 RID: 13431
		' (get) Token: 0x06008E43 RID: 36419 RVA: 0x000456C9 File Offset: 0x000438C9
		' (set) Token: 0x06008E44 RID: 36420 RVA: 0x000456D3 File Offset: 0x000438D3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003478 RID: 13432
		' (get) Token: 0x06008E45 RID: 36421 RVA: 0x000456DC File Offset: 0x000438DC
		' (set) Token: 0x06008E46 RID: 36422 RVA: 0x000456E6 File Offset: 0x000438E6
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17003479 RID: 13433
		' (get) Token: 0x06008E47 RID: 36423 RVA: 0x000456EF File Offset: 0x000438EF
		' (set) Token: 0x06008E48 RID: 36424 RVA: 0x000456F9 File Offset: 0x000438F9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700347A RID: 13434
		' (get) Token: 0x06008E49 RID: 36425 RVA: 0x00045702 File Offset: 0x00043902
		' (set) Token: 0x06008E4A RID: 36426 RVA: 0x0004570C File Offset: 0x0004390C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700347B RID: 13435
		' (get) Token: 0x06008E4B RID: 36427 RVA: 0x00045715 File Offset: 0x00043915
		' (set) Token: 0x06008E4C RID: 36428 RVA: 0x0004571F File Offset: 0x0004391F
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700347C RID: 13436
		' (get) Token: 0x06008E4D RID: 36429 RVA: 0x00045728 File Offset: 0x00043928
		' (set) Token: 0x06008E4E RID: 36430 RVA: 0x00045732 File Offset: 0x00043932
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700347D RID: 13437
		' (get) Token: 0x06008E4F RID: 36431 RVA: 0x0004573B File Offset: 0x0004393B
		' (set) Token: 0x06008E50 RID: 36432 RVA: 0x00045745 File Offset: 0x00043945
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700347E RID: 13438
		' (get) Token: 0x06008E51 RID: 36433 RVA: 0x0004574E File Offset: 0x0004394E
		' (set) Token: 0x06008E52 RID: 36434 RVA: 0x00045758 File Offset: 0x00043958
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700347F RID: 13439
		' (get) Token: 0x06008E53 RID: 36435 RVA: 0x00045761 File Offset: 0x00043961
		' (set) Token: 0x06008E54 RID: 36436 RVA: 0x0004576B File Offset: 0x0004396B
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003480 RID: 13440
		' (get) Token: 0x06008E55 RID: 36437 RVA: 0x00045774 File Offset: 0x00043974
		' (set) Token: 0x06008E56 RID: 36438 RVA: 0x0004577E File Offset: 0x0004397E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003481 RID: 13441
		' (get) Token: 0x06008E57 RID: 36439 RVA: 0x00045787 File Offset: 0x00043987
		' (set) Token: 0x06008E58 RID: 36440 RVA: 0x00045791 File Offset: 0x00043991
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003482 RID: 13442
		' (get) Token: 0x06008E59 RID: 36441 RVA: 0x0004579A File Offset: 0x0004399A
		' (set) Token: 0x06008E5A RID: 36442 RVA: 0x000457A4 File Offset: 0x000439A4
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003483 RID: 13443
		' (get) Token: 0x06008E5B RID: 36443 RVA: 0x000457AD File Offset: 0x000439AD
		' (set) Token: 0x06008E5C RID: 36444 RVA: 0x000457B7 File Offset: 0x000439B7
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003484 RID: 13444
		' (get) Token: 0x06008E5D RID: 36445 RVA: 0x000457C0 File Offset: 0x000439C0
		' (set) Token: 0x06008E5E RID: 36446 RVA: 0x000457CA File Offset: 0x000439CA
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003485 RID: 13445
		' (get) Token: 0x06008E5F RID: 36447 RVA: 0x000457D3 File Offset: 0x000439D3
		' (set) Token: 0x06008E60 RID: 36448 RVA: 0x000457DD File Offset: 0x000439DD
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003486 RID: 13446
		' (get) Token: 0x06008E61 RID: 36449 RVA: 0x000457E6 File Offset: 0x000439E6
		' (set) Token: 0x06008E62 RID: 36450 RVA: 0x000457F0 File Offset: 0x000439F0
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x06008E63 RID: 36451 RVA: 0x00683BDC File Offset: 0x00681DDC
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.DataGridView1.Rows.Clear()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "SELECT " & vbCrLf & "    i.InvoiceNo," & vbCrLf & "    i.InvoiceDate," & vbCrLf & "    RTRIM(c.Name) AS CustomerName," & vbCrLf & "    i.GrandTotal," & vbCrLf & vbCrLf & "    -- Individual Payment Modes" & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Cash' THEN ip.TotalPaid ELSE 0 END) AS ByCash," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Cheque' THEN ip.TotalPaid ELSE 0 END) AS ByCheque," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Credit Card' THEN ip.TotalPaid ELSE 0 END) AS ByCreditCard," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Debit Card' THEN ip.TotalPaid ELSE 0 END) AS ByDebitCard," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'PhonePe' THEN ip.TotalPaid ELSE 0 END) AS PhonePe," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'Google Pay' THEN ip.TotalPaid ELSE 0 END) AS GooglePay," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'Paytm' THEN ip.TotalPaid ELSE 0 END) AS Paytm," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'E-Wallet' THEN ip.TotalPaid ELSE 0 END) AS EWallet," & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'ByReturn' THEN ip.TotalPaid ELSE 0 END) AS ByReturn," & vbCrLf & vbCrLf & "    -- Combine all Credit Terms (7/15/30/60/90/120/180/Adjust)" & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode LIKE 'Credit Terms%' THEN ip.TotalPaid ELSE 0 END) AS CreditTerms," & vbCrLf & vbCrLf & "    -- TotalPaid (sum of all modes)" & vbCrLf & "    (" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Cash' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Cheque' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Credit Card' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Debit Card' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'PhonePe' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'Google Pay' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'Paytm' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'E-Wallet' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode LIKE 'Credit Terms%' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'ByReturn' THEN ip.TotalPaid ELSE 0 END)" & vbCrLf & "    ) AS TotalPaid," & vbCrLf & "    RTRIM(i.Operator) AS Operator" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo i" & vbCrLf & "INNER JOIN " & vbCrLf & "    Invoice_Payment ip ON i.Inv_ID = ip.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Customer c ON i.Customer_ID = c.ID" & vbCrLf & "WHERE " & vbCrLf & "    i.InvoiceDate BETWEEN @d1 AND @d2" & vbCrLf & "GROUP BY " & vbCrLf & "    i.InvoiceNo," & vbCrLf & "    i.InvoiceDate," & vbCrLf & "    c.Name," & vbCrLf & "    i.GrandTotal,i.Operator" & vbCrLf & "ORDER BY " & vbCrLf & "    i.InvoiceDate;" & vbCrLf
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim num As Integer = 0
							Dim num2 As Decimal = 0D
							Dim num3 As Decimal = 0D
							Dim num4 As Decimal = 0D
							Dim num5 As Decimal = 0D
							Dim num6 As Decimal = 0D
							Dim num7 As Decimal = 0D
							Dim num8 As Decimal = 0D
							Dim num9 As Decimal = 0D
							Dim num10 As Decimal = 0D
							Dim num11 As Decimal = 0D
							Dim num12 As Decimal = 0D
							Dim num13 As Decimal = 0D
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add()
								Me.DataGridView1.Rows(num).Cells(0).Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(sqlDataReader("InvoiceDate"))).ToString("dd-MMM-yyyy")
								Me.DataGridView1.Rows(num).Cells(1).Value = sqlDataReader("InvoiceNo").ToString()
								Me.DataGridView1.Rows(num).Cells(2).Value = sqlDataReader("CustomerName").ToString()
								Me.DataGridView1.Rows(num).Cells(3).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(4).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCash")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(5).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCheque")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(6).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCreditCard")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(7).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByDebitCard")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(8).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("PhonePe")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(9).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("GooglePay")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(10).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Paytm")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(11).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("EWallet")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(12).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByReturn")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(13).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("CreditTerms")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(14).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(15).Value = sqlDataReader("Operator").ToString()
								num2 = Decimal.Add(num2, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal"))))
								num3 = Decimal.Add(num3, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCash"))))
								num4 = Decimal.Add(num4, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCheque"))))
								num5 = Decimal.Add(num5, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCreditCard"))))
								num6 = Decimal.Add(num6, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByDebitCard"))))
								num7 = Decimal.Add(num7, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("PhonePe"))))
								num8 = Decimal.Add(num8, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("GooglePay"))))
								num9 = Decimal.Add(num9, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Paytm"))))
								num10 = Decimal.Add(num10, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("EWallet"))))
								num11 = Decimal.Add(num11, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByReturn"))))
								num12 = Decimal.Add(num12, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("CreditTerms"))))
								num13 = Decimal.Add(num13, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid"))))
								num += 1
							End While
							Dim num14 As Integer = Me.DataGridView1.Rows.Add()
							Me.DataGridView1.Rows(num14).Cells(0).Value = "T O T A L"
							Me.DataGridView1.Rows(num14).Cells(1).Value = "NOB's:" + Conversions.ToString(num)
							Me.DataGridView1.Rows(num14).Cells(3).Value = Strings.FormatNumber(num2, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(4).Value = Strings.FormatNumber(num3, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(5).Value = Strings.FormatNumber(num4, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(6).Value = Strings.FormatNumber(num5, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(7).Value = Strings.FormatNumber(num6, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(8).Value = Strings.FormatNumber(num7, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(9).Value = Strings.FormatNumber(num8, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(10).Value = Strings.FormatNumber(num9, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(11).Value = Strings.FormatNumber(num10, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(12).Value = Strings.FormatNumber(num11, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(13).Value = Strings.FormatNumber(num12, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(14).Value = Strings.FormatNumber(num13, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).DefaultCellStyle.BackColor = Color.LightGray
							Me.DataGridView1.Rows(num14).DefaultCellStyle.Font = New Font(Me.DataGridView1.Font, FontStyle.Bold)
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x06008E64 RID: 36452 RVA: 0x000457F9 File Offset: 0x000439F9
		Private Sub frmSaleReport_Multi_Payment_Load(sender As Object, e As EventArgs)
			Me.FillUserID()
		End Sub

		' Token: 0x06008E65 RID: 36453 RVA: 0x006846CC File Offset: 0x006828CC
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(UserID) from Registration Order by UserID"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.ComboBox1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox1.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008E66 RID: 36454 RVA: 0x006847A0 File Offset: 0x006829A0
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								Dim dataRow As DataRow = dataTable.NewRow()
								Try
									For Each obj3 As Object In dataGridViewRow.Cells
										Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
										dataRow(dataGridViewCell.ColumnIndex) = If((dataGridViewCell.Value IsNot Nothing), dataGridViewCell.Value.ToString(), "")
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
								dataTable.Rows.Add(dataRow)
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() <> DialogResult.OK
					If Not flag3 Then
						Dim fileName As String = Me.SaveFileDialog1.FileName
						Using xlworkbook As XLWorkbook = New XLWorkbook()
							xlworkbook.Worksheets.Add(dataTable, "Export File")
							xlworkbook.SaveAs(fileName)
						End Using
						MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully: " + ex.Message, "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008E67 RID: 36455 RVA: 0x00684A58 File Offset: 0x00682C58
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.DataGridView1.Rows.Clear()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "SELECT " & vbCrLf & "    i.InvoiceNo," & vbCrLf & "    i.InvoiceDate," & vbCrLf & "    RTRIM(c.Name) AS CustomerName," & vbCrLf & "    i.GrandTotal," & vbCrLf & vbCrLf & "    -- Individual Payment Modes" & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Cash' THEN ip.TotalPaid ELSE 0 END) AS ByCash," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Cheque' THEN ip.TotalPaid ELSE 0 END) AS ByCheque," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Credit Card' THEN ip.TotalPaid ELSE 0 END) AS ByCreditCard," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'By Debit Card' THEN ip.TotalPaid ELSE 0 END) AS ByDebitCard," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'PhonePe' THEN ip.TotalPaid ELSE 0 END) AS PhonePe," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'Google Pay' THEN ip.TotalPaid ELSE 0 END) AS GooglePay," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'Paytm' THEN ip.TotalPaid ELSE 0 END) AS Paytm," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'E-Wallet' THEN ip.TotalPaid ELSE 0 END) AS EWallet," & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode = 'ByReturn' THEN ip.TotalPaid ELSE 0 END) AS ByReturn," & vbCrLf & vbCrLf & "    -- Combine all Credit Terms (7/15/30/60/90/120/180/Adjust)" & vbCrLf & "    SUM(CASE WHEN ip.PaymentMode LIKE 'Credit Terms%' THEN ip.TotalPaid ELSE 0 END) AS CreditTerms," & vbCrLf & vbCrLf & "    -- TotalPaid (sum of all modes)" & vbCrLf & "    (" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Cash' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Cheque' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Credit Card' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'By Debit Card' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'PhonePe' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'Google Pay' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'Paytm' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'E-Wallet' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode LIKE 'Credit Terms%' THEN ip.TotalPaid ELSE 0 END) +" & vbCrLf & "        SUM(CASE WHEN ip.PaymentMode = 'ByReturn' THEN ip.TotalPaid ELSE 0 END)" & vbCrLf & "    ) AS TotalPaid," & vbCrLf & "RTRIM(i.Operator) AS Operator" & vbCrLf & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo i" & vbCrLf & "INNER JOIN " & vbCrLf & "    Invoice_Payment ip ON i.Inv_ID = ip.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Customer c ON i.Customer_ID = c.ID" & vbCrLf & "WHERE " & vbCrLf & "    i.InvoiceDate BETWEEN @d1 AND @d2 AND i.Operator=@d3" & vbCrLf & "GROUP BY " & vbCrLf & "    i.InvoiceNo," & vbCrLf & "    i.InvoiceDate," & vbCrLf & "    c.Name," & vbCrLf & "    i.GrandTotal,i.Operator" & vbCrLf & "ORDER BY " & vbCrLf & "    i.InvoiceDate;" & vbCrLf
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
						sqlCommand.Parameters.AddWithValue("@d3", Me.ComboBox1.Text.ToString())
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim num As Integer = 0
							Dim num2 As Decimal = 0D
							Dim num3 As Decimal = 0D
							Dim num4 As Decimal = 0D
							Dim num5 As Decimal = 0D
							Dim num6 As Decimal = 0D
							Dim num7 As Decimal = 0D
							Dim num8 As Decimal = 0D
							Dim num9 As Decimal = 0D
							Dim num10 As Decimal = 0D
							Dim num11 As Decimal = 0D
							Dim num12 As Decimal = 0D
							Dim num13 As Decimal = 0D
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add()
								Me.DataGridView1.Rows(num).Cells(0).Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(sqlDataReader("InvoiceDate"))).ToString("dd-MMM-yyyy")
								Me.DataGridView1.Rows(num).Cells(1).Value = sqlDataReader("InvoiceNo").ToString()
								Me.DataGridView1.Rows(num).Cells(2).Value = sqlDataReader("CustomerName").ToString()
								Me.DataGridView1.Rows(num).Cells(3).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(4).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCash")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(5).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCheque")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(6).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCreditCard")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(7).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByDebitCard")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(8).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("PhonePe")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(9).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("GooglePay")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(10).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("Paytm")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(11).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("EWallet")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(12).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("ByReturn")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(13).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("CreditTerms")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(14).Value = Strings.FormatNumber(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid")), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
								Me.DataGridView1.Rows(num).Cells(15).Value = sqlDataReader("Operator").ToString()
								num2 = Decimal.Add(num2, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("GrandTotal"))))
								num3 = Decimal.Add(num3, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCash"))))
								num4 = Decimal.Add(num4, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCheque"))))
								num5 = Decimal.Add(num5, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByCreditCard"))))
								num6 = Decimal.Add(num6, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByDebitCard"))))
								num7 = Decimal.Add(num7, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("PhonePe"))))
								num8 = Decimal.Add(num8, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("GooglePay"))))
								num9 = Decimal.Add(num9, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("Paytm"))))
								num10 = Decimal.Add(num10, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("EWallet"))))
								num11 = Decimal.Add(num11, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("ByReturn"))))
								num12 = Decimal.Add(num12, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("CreditTerms"))))
								num13 = Decimal.Add(num13, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("TotalPaid"))))
								num += 1
							End While
							Dim num14 As Integer = Me.DataGridView1.Rows.Add()
							Me.DataGridView1.Rows(num14).Cells(0).Value = "T O T A L"
							Me.DataGridView1.Rows(num14).Cells(1).Value = "NOB's:" + Conversions.ToString(num)
							Me.DataGridView1.Rows(num14).Cells(3).Value = Strings.FormatNumber(num2, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(4).Value = Strings.FormatNumber(num3, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(5).Value = Strings.FormatNumber(num4, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(6).Value = Strings.FormatNumber(num5, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(7).Value = Strings.FormatNumber(num6, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(8).Value = Strings.FormatNumber(num7, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(9).Value = Strings.FormatNumber(num8, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(10).Value = Strings.FormatNumber(num9, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(11).Value = Strings.FormatNumber(num10, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(12).Value = Strings.FormatNumber(num11, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(13).Value = Strings.FormatNumber(num12, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).Cells(14).Value = Strings.FormatNumber(num13, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)
							Me.DataGridView1.Rows(num14).DefaultCellStyle.BackColor = Color.LightGray
							Me.DataGridView1.Rows(num14).DefaultCellStyle.Font = New Font(Me.DataGridView1.Font, FontStyle.Bold)
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub
	End Class
End Namespace
