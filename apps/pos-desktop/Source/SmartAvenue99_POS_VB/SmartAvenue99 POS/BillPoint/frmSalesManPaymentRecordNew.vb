Imports System
Imports System.Collections
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
	' Token: 0x0200020A RID: 522
	<DesignerGenerated()>
	Public Partial Class frmSalesManPaymentRecordNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060097AC RID: 38828 RVA: 0x0004A1BD File Offset: 0x000483BD
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCreditCustomerReceiptRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003853 RID: 14419
		' (get) Token: 0x060097AF RID: 38831 RVA: 0x0004A1EF File Offset: 0x000483EF
		' (set) Token: 0x060097B0 RID: 38832 RVA: 0x0004A1F9 File Offset: 0x000483F9
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003854 RID: 14420
		' (get) Token: 0x060097B1 RID: 38833 RVA: 0x0004A202 File Offset: 0x00048402
		' (set) Token: 0x060097B2 RID: 38834 RVA: 0x0004A20C File Offset: 0x0004840C
		Friend Overridable Property lblSet As Label

		' Token: 0x17003855 RID: 14421
		' (get) Token: 0x060097B3 RID: 38835 RVA: 0x0004A215 File Offset: 0x00048415
		' (set) Token: 0x060097B4 RID: 38836 RVA: 0x0004A21F File Offset: 0x0004841F
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003856 RID: 14422
		' (get) Token: 0x060097B5 RID: 38837 RVA: 0x0004A228 File Offset: 0x00048428
		' (set) Token: 0x060097B6 RID: 38838 RVA: 0x0004A232 File Offset: 0x00048432
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003857 RID: 14423
		' (get) Token: 0x060097B7 RID: 38839 RVA: 0x0004A23B File Offset: 0x0004843B
		' (set) Token: 0x060097B8 RID: 38840 RVA: 0x0004A245 File Offset: 0x00048445
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003858 RID: 14424
		' (get) Token: 0x060097B9 RID: 38841 RVA: 0x0004A24E File Offset: 0x0004844E
		' (set) Token: 0x060097BA RID: 38842 RVA: 0x0004A258 File Offset: 0x00048458
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003859 RID: 14425
		' (get) Token: 0x060097BB RID: 38843 RVA: 0x0004A261 File Offset: 0x00048461
		' (set) Token: 0x060097BC RID: 38844 RVA: 0x0004A26B File Offset: 0x0004846B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700385A RID: 14426
		' (get) Token: 0x060097BD RID: 38845 RVA: 0x0004A274 File Offset: 0x00048474
		' (set) Token: 0x060097BE RID: 38846 RVA: 0x0004A27E File Offset: 0x0004847E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700385B RID: 14427
		' (get) Token: 0x060097BF RID: 38847 RVA: 0x0004A287 File Offset: 0x00048487
		' (set) Token: 0x060097C0 RID: 38848 RVA: 0x0004A291 File Offset: 0x00048491
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700385C RID: 14428
		' (get) Token: 0x060097C1 RID: 38849 RVA: 0x0004A29A File Offset: 0x0004849A
		' (set) Token: 0x060097C2 RID: 38850 RVA: 0x0004A2A4 File Offset: 0x000484A4
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700385D RID: 14429
		' (get) Token: 0x060097C3 RID: 38851 RVA: 0x0004A2AD File Offset: 0x000484AD
		' (set) Token: 0x060097C4 RID: 38852 RVA: 0x0004A2B7 File Offset: 0x000484B7
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700385E RID: 14430
		' (get) Token: 0x060097C5 RID: 38853 RVA: 0x0004A2C0 File Offset: 0x000484C0
		' (set) Token: 0x060097C6 RID: 38854 RVA: 0x0004A2CA File Offset: 0x000484CA
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700385F RID: 14431
		' (get) Token: 0x060097C7 RID: 38855 RVA: 0x0004A2D3 File Offset: 0x000484D3
		' (set) Token: 0x060097C8 RID: 38856 RVA: 0x0004A2DD File Offset: 0x000484DD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003860 RID: 14432
		' (get) Token: 0x060097C9 RID: 38857 RVA: 0x0004A2E6 File Offset: 0x000484E6
		' (set) Token: 0x060097CA RID: 38858 RVA: 0x006D10B8 File Offset: 0x006CF2B8
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

		' Token: 0x17003861 RID: 14433
		' (get) Token: 0x060097CB RID: 38859 RVA: 0x0004A2F0 File Offset: 0x000484F0
		' (set) Token: 0x060097CC RID: 38860 RVA: 0x006D1134 File Offset: 0x006CF334
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

		' Token: 0x17003862 RID: 14434
		' (get) Token: 0x060097CD RID: 38861 RVA: 0x0004A2FA File Offset: 0x000484FA
		' (set) Token: 0x060097CE RID: 38862 RVA: 0x0004A304 File Offset: 0x00048504
		Friend Overridable Property Label3 As Label

		' Token: 0x17003863 RID: 14435
		' (get) Token: 0x060097CF RID: 38863 RVA: 0x0004A30D File Offset: 0x0004850D
		' (set) Token: 0x060097D0 RID: 38864 RVA: 0x0004A317 File Offset: 0x00048517
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17003864 RID: 14436
		' (get) Token: 0x060097D1 RID: 38865 RVA: 0x0004A320 File Offset: 0x00048520
		' (set) Token: 0x060097D2 RID: 38866 RVA: 0x0004A32A File Offset: 0x0004852A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17003865 RID: 14437
		' (get) Token: 0x060097D3 RID: 38867 RVA: 0x0004A333 File Offset: 0x00048533
		' (set) Token: 0x060097D4 RID: 38868 RVA: 0x0004A33D File Offset: 0x0004853D
		Friend Overridable Property Label2 As Label

		' Token: 0x17003866 RID: 14438
		' (get) Token: 0x060097D5 RID: 38869 RVA: 0x0004A346 File Offset: 0x00048546
		' (set) Token: 0x060097D6 RID: 38870 RVA: 0x006D1178 File Offset: 0x006CF378
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

		' Token: 0x17003867 RID: 14439
		' (get) Token: 0x060097D7 RID: 38871 RVA: 0x0004A350 File Offset: 0x00048550
		' (set) Token: 0x060097D8 RID: 38872 RVA: 0x0004A35A File Offset: 0x0004855A
		Friend Overridable Property Label4 As Label

		' Token: 0x17003868 RID: 14440
		' (get) Token: 0x060097D9 RID: 38873 RVA: 0x0004A363 File Offset: 0x00048563
		' (set) Token: 0x060097DA RID: 38874 RVA: 0x0004A36D File Offset: 0x0004856D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003869 RID: 14441
		' (get) Token: 0x060097DB RID: 38875 RVA: 0x0004A376 File Offset: 0x00048576
		' (set) Token: 0x060097DC RID: 38876 RVA: 0x0004A380 File Offset: 0x00048580
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700386A RID: 14442
		' (get) Token: 0x060097DD RID: 38877 RVA: 0x0004A389 File Offset: 0x00048589
		' (set) Token: 0x060097DE RID: 38878 RVA: 0x006D11BC File Offset: 0x006CF3BC
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

		' Token: 0x1700386B RID: 14443
		' (get) Token: 0x060097DF RID: 38879 RVA: 0x0004A393 File Offset: 0x00048593
		' (set) Token: 0x060097E0 RID: 38880 RVA: 0x006D1200 File Offset: 0x006CF400
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

		' Token: 0x1700386C RID: 14444
		' (get) Token: 0x060097E1 RID: 38881 RVA: 0x0004A39D File Offset: 0x0004859D
		' (set) Token: 0x060097E2 RID: 38882 RVA: 0x0004A3A7 File Offset: 0x000485A7
		Friend Overridable Property Label5 As Label

		' Token: 0x1700386D RID: 14445
		' (get) Token: 0x060097E3 RID: 38883 RVA: 0x0004A3B0 File Offset: 0x000485B0
		' (set) Token: 0x060097E4 RID: 38884 RVA: 0x0004A3BA File Offset: 0x000485BA
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700386E RID: 14446
		' (get) Token: 0x060097E5 RID: 38885 RVA: 0x0004A3C3 File Offset: 0x000485C3
		' (set) Token: 0x060097E6 RID: 38886 RVA: 0x0004A3CD File Offset: 0x000485CD
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700386F RID: 14447
		' (get) Token: 0x060097E7 RID: 38887 RVA: 0x0004A3D6 File Offset: 0x000485D6
		' (set) Token: 0x060097E8 RID: 38888 RVA: 0x0004A3E0 File Offset: 0x000485E0
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003870 RID: 14448
		' (get) Token: 0x060097E9 RID: 38889 RVA: 0x0004A3E9 File Offset: 0x000485E9
		' (set) Token: 0x060097EA RID: 38890 RVA: 0x0004A3F3 File Offset: 0x000485F3
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17003871 RID: 14449
		' (get) Token: 0x060097EB RID: 38891 RVA: 0x0004A3FC File Offset: 0x000485FC
		' (set) Token: 0x060097EC RID: 38892 RVA: 0x0004A406 File Offset: 0x00048606
		Friend Overridable Property Label1 As Label

		' Token: 0x060097ED RID: 38893 RVA: 0x006D1244 File Offset: 0x006CF444
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

		' Token: 0x060097EE RID: 38894 RVA: 0x006D1318 File Offset: 0x006CF518
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),SalesMan.SM_ID,RTRIM(SalesMan.SalesMan_ID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditSalesManPayment.Remarks),RTRIM(CreditSalesManPayment.BankAcNo) from SalesMan,CreditSalesManPayment where SalesMan.SM_ID=CreditSalesManPayment.Customer_ID and Amount > 0 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060097EF RID: 38895 RVA: 0x006D1510 File Offset: 0x006CF710
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x060097F0 RID: 38896 RVA: 0x006D1598 File Offset: 0x006CF798
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060097F1 RID: 38897 RVA: 0x006D15C0 File Offset: 0x006CF7C0
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmSalesManPayment.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesManPayment.txtT_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtTransactionNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesManPayment.dtpTranactionDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSalesManPayment.cmbPaymentMode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtCustID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmSalesManPayment.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtTransactionAmount.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtTempAmt.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtPaymentModeDetails.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtRemarks.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmSalesManPayment.cmbAccountNo.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmSalesManPayment.btnSave.Enabled = False
						MyProject.Forms.frmSalesManPayment.btnUpdate.Enabled = True
						MyProject.Forms.frmSalesManPayment.btnDelete.Enabled = True
						MyProject.Forms.frmSalesManPayment.GetCustomerInfo()
						MyProject.Forms.frmSalesManPayment.btnSelection.Enabled = False
						MyProject.Forms.frmSalesManPayment.btnPrint.Enabled = True
						MyProject.Forms.frmSalesManPayment.Button2.Enabled = True
						MyProject.Forms.frmSalesManPayment.GetCustomerBalance()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060097F2 RID: 38898 RVA: 0x0004A40F File Offset: 0x0004860F
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060097F3 RID: 38899 RVA: 0x006D1910 File Offset: 0x006CFB10
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

		' Token: 0x060097F4 RID: 38900 RVA: 0x0004A419 File Offset: 0x00048619
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x060097F5 RID: 38901 RVA: 0x006D19F8 File Offset: 0x006CFBF8
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),SalesMan.SM_ID,RTRIM(SalesMan.SalesMan_ID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditSalesManPayment.Remarks),RTRIM(CreditSalesManPayment.BankAcNo) from SalesMan,CreditSalesManPayment where SalesMan.SM_ID=CreditSalesManPayment.Customer_ID and Amount > 0  and [Name] like N'" + Me.txtCustomerName.Text + "%' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060097F6 RID: 38902 RVA: 0x006D1C08 File Offset: 0x006CFE08
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),SalesMan.SM_ID,RTRIM(SalesMan.SalesMan_ID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditSalesManPayment.Remarks),RTRIM(CreditSalesManPayment.BankAcNo) from SalesMan,CreditSalesManPayment where SalesMan.SM_ID=CreditSalesManPayment.Customer_ID and Amount > 0 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060097F7 RID: 38903 RVA: 0x0004A44C File Offset: 0x0004864C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060097F8 RID: 38904 RVA: 0x006D1E14 File Offset: 0x006D0014
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

		' Token: 0x060097F9 RID: 38905 RVA: 0x006D20C0 File Offset: 0x006D02C0
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x060097FA RID: 38906 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCreditCustomerReceiptRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04004339 RID: 17209
		Private num1 As Decimal

		' Token: 0x0400433A RID: 17210
		Private num2 As Decimal

		' Token: 0x0400433B RID: 17211
		Private num3 As Decimal

		' Token: 0x0400433C RID: 17212
		Private str As String
	End Class
End Namespace
