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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000575 RID: 1397
	<DesignerGenerated()>
	Public Partial Class frmCreditTermsStatements
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010FA2 RID: 69538 RVA: 0x00074DF8 File Offset: 0x00072FF8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCreditTermsStatements_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006958 RID: 26968
		' (get) Token: 0x06010FA5 RID: 69541 RVA: 0x00074E2A File Offset: 0x0007302A
		' (set) Token: 0x06010FA6 RID: 69542 RVA: 0x00074E34 File Offset: 0x00073034
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006959 RID: 26969
		' (get) Token: 0x06010FA7 RID: 69543 RVA: 0x00074E3D File Offset: 0x0007303D
		' (set) Token: 0x06010FA8 RID: 69544 RVA: 0x00074E47 File Offset: 0x00073047
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700695A RID: 26970
		' (get) Token: 0x06010FA9 RID: 69545 RVA: 0x00074E50 File Offset: 0x00073050
		' (set) Token: 0x06010FAA RID: 69546 RVA: 0x00074E5A File Offset: 0x0007305A
		Friend Overridable Property Label1 As Label

		' Token: 0x1700695B RID: 26971
		' (get) Token: 0x06010FAB RID: 69547 RVA: 0x00074E63 File Offset: 0x00073063
		' (set) Token: 0x06010FAC RID: 69548 RVA: 0x009DCB30 File Offset: 0x009DAD30
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700695C RID: 26972
		' (get) Token: 0x06010FAD RID: 69549 RVA: 0x00074E6D File Offset: 0x0007306D
		' (set) Token: 0x06010FAE RID: 69550 RVA: 0x00074E77 File Offset: 0x00073077
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700695D RID: 26973
		' (get) Token: 0x06010FAF RID: 69551 RVA: 0x00074E80 File Offset: 0x00073080
		' (set) Token: 0x06010FB0 RID: 69552 RVA: 0x009DCB74 File Offset: 0x009DAD74
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

		' Token: 0x1700695E RID: 26974
		' (get) Token: 0x06010FB1 RID: 69553 RVA: 0x00074E8A File Offset: 0x0007308A
		' (set) Token: 0x06010FB2 RID: 69554 RVA: 0x00074E94 File Offset: 0x00073094
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700695F RID: 26975
		' (get) Token: 0x06010FB3 RID: 69555 RVA: 0x00074E9D File Offset: 0x0007309D
		' (set) Token: 0x06010FB4 RID: 69556 RVA: 0x00074EA7 File Offset: 0x000730A7
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006960 RID: 26976
		' (get) Token: 0x06010FB5 RID: 69557 RVA: 0x00074EB0 File Offset: 0x000730B0
		' (set) Token: 0x06010FB6 RID: 69558 RVA: 0x00074EBA File Offset: 0x000730BA
		Friend Overridable Property Label2 As Label

		' Token: 0x17006961 RID: 26977
		' (get) Token: 0x06010FB7 RID: 69559 RVA: 0x00074EC3 File Offset: 0x000730C3
		' (set) Token: 0x06010FB8 RID: 69560 RVA: 0x00074ECD File Offset: 0x000730CD
		Friend Overridable Property Label4 As Label

		' Token: 0x17006962 RID: 26978
		' (get) Token: 0x06010FB9 RID: 69561 RVA: 0x00074ED6 File Offset: 0x000730D6
		' (set) Token: 0x06010FBA RID: 69562 RVA: 0x00074EE0 File Offset: 0x000730E0
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006963 RID: 26979
		' (get) Token: 0x06010FBB RID: 69563 RVA: 0x00074EE9 File Offset: 0x000730E9
		' (set) Token: 0x06010FBC RID: 69564 RVA: 0x009DCBB8 File Offset: 0x009DADB8
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006964 RID: 26980
		' (get) Token: 0x06010FBD RID: 69565 RVA: 0x00074EF3 File Offset: 0x000730F3
		' (set) Token: 0x06010FBE RID: 69566 RVA: 0x00074EFD File Offset: 0x000730FD
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006965 RID: 26981
		' (get) Token: 0x06010FBF RID: 69567 RVA: 0x00074F06 File Offset: 0x00073106
		' (set) Token: 0x06010FC0 RID: 69568 RVA: 0x009DCBFC File Offset: 0x009DADFC
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006966 RID: 26982
		' (get) Token: 0x06010FC1 RID: 69569 RVA: 0x00074F10 File Offset: 0x00073110
		' (set) Token: 0x06010FC2 RID: 69570 RVA: 0x00074F1A File Offset: 0x0007311A
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x17006967 RID: 26983
		' (get) Token: 0x06010FC3 RID: 69571 RVA: 0x00074F23 File Offset: 0x00073123
		' (set) Token: 0x06010FC4 RID: 69572 RVA: 0x00074F2D File Offset: 0x0007312D
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17006968 RID: 26984
		' (get) Token: 0x06010FC5 RID: 69573 RVA: 0x00074F36 File Offset: 0x00073136
		' (set) Token: 0x06010FC6 RID: 69574 RVA: 0x00074F40 File Offset: 0x00073140
		Friend Overridable Property Label5 As Label

		' Token: 0x17006969 RID: 26985
		' (get) Token: 0x06010FC7 RID: 69575 RVA: 0x00074F49 File Offset: 0x00073149
		' (set) Token: 0x06010FC8 RID: 69576 RVA: 0x00074F53 File Offset: 0x00073153
		Friend Overridable Property Label3 As Label

		' Token: 0x1700696A RID: 26986
		' (get) Token: 0x06010FC9 RID: 69577 RVA: 0x00074F5C File Offset: 0x0007315C
		' (set) Token: 0x06010FCA RID: 69578 RVA: 0x009DCC40 File Offset: 0x009DAE40
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700696B RID: 26987
		' (get) Token: 0x06010FCB RID: 69579 RVA: 0x00074F66 File Offset: 0x00073166
		' (set) Token: 0x06010FCC RID: 69580 RVA: 0x00074F70 File Offset: 0x00073170
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x1700696C RID: 26988
		' (get) Token: 0x06010FCD RID: 69581 RVA: 0x00074F79 File Offset: 0x00073179
		' (set) Token: 0x06010FCE RID: 69582 RVA: 0x00074F83 File Offset: 0x00073183
		Friend Overridable Property Label6 As Label

		' Token: 0x1700696D RID: 26989
		' (get) Token: 0x06010FCF RID: 69583 RVA: 0x00074F8C File Offset: 0x0007318C
		' (set) Token: 0x06010FD0 RID: 69584 RVA: 0x00074F96 File Offset: 0x00073196
		Friend Overridable Property Label7 As Label

		' Token: 0x1700696E RID: 26990
		' (get) Token: 0x06010FD1 RID: 69585 RVA: 0x00074F9F File Offset: 0x0007319F
		' (set) Token: 0x06010FD2 RID: 69586 RVA: 0x00074FA9 File Offset: 0x000731A9
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x06010FD3 RID: 69587 RVA: 0x009DCC84 File Offset: 0x009DAE84
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
					Me.DateTimePicker2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x06010FD4 RID: 69588 RVA: 0x009DCD7C File Offset: 0x009DAF7C
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.txtCustomerID.Text = ""
			Me.txtCustomerName.Text = ""
		End Sub

		' Token: 0x06010FD5 RID: 69589 RVA: 0x00074FB2 File Offset: 0x000731B2
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010FD6 RID: 69590 RVA: 0x00074FBC File Offset: 0x000731BC
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06010FD7 RID: 69591 RVA: 0x009DCDD8 File Offset: 0x009DAFD8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.CustomerID, Customer.Name, Invoice_Payment.PaymentMode, Invoice_Payment.TotalPaid FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoice_Payment.PaymentMode like 'Credit Terms%' and InvoiceDate >=@d2 and InvoiceDate < @d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.CustomerID, Customer.Name, Invoice_Payment.PaymentMode, Invoice_Payment.TotalPaid FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoice_Payment.PaymentMode like 'Credit Terms%' and InvoiceDate >=@d1 and InvoiceDate < @d2", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("CreditTermsStatements.xml")
					Dim rptCreditTermsStatements As rptCreditTermsStatements = New rptCreditTermsStatements()
					rptCreditTermsStatements.SetDataSource(ModCommonClasses.ds)
					rptCreditTermsStatements.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptCreditTermsStatements.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCreditTermsStatements
					MyProject.Forms.frmReport.ShowDialog()
					rptCreditTermsStatements.Close()
					rptCreditTermsStatements.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010FD8 RID: 69592 RVA: 0x00074FD8 File Offset: 0x000731D8
		Private Sub frmSalesReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06010FD9 RID: 69593 RVA: 0x009DD0FC File Offset: 0x009DB2FC
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

		' Token: 0x06010FDA RID: 69594 RVA: 0x009DD274 File Offset: 0x009DB474
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

		' Token: 0x06010FDB RID: 69595 RVA: 0x009DD330 File Offset: 0x009DB530
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

		' Token: 0x06010FDC RID: 69596 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010FDD RID: 69597 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010FDE RID: 69598 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010FDF RID: 69599 RVA: 0x009DD3FC File Offset: 0x009DB5FC
		Public Sub GetCustomerInfo()
			Try
				Me.a = ""
				Me.b = ""
				Me.c = ""
				Me.d = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Address),RTRIM(City),RTRIM(ContactNo),RTRIM(State) FROM Customer WHERE CustomerID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.a = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.b = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.c = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.d = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010FE0 RID: 69600 RVA: 0x009DD580 File Offset: 0x009DB780
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "CT"
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = False
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
		End Sub

		' Token: 0x06010FE1 RID: 69601 RVA: 0x009DD5E0 File Offset: 0x009DB7E0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve Customer Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCustomerName.Focus()
			Else
				Me.GetCustomerInfo()
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.CustomerID, Customer.Name, Invoice_Payment.PaymentMode, Invoice_Payment.TotalPaid FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoice_Payment.PaymentMode like 'Credit Terms%' and InvoiceDate >=@d2 and InvoiceDate < @d3 and Customer.CustomerID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.CustomerID, Customer.Name, Invoice_Payment.PaymentMode, Invoice_Payment.TotalPaid FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoice_Payment.PaymentMode like 'Credit Terms%' and InvoiceDate >=@d1 and InvoiceDate < @d2 and Customer.CustomerID=@d3", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustomerID.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("CreditTermsStatementsByCustomer.xml")
						Dim rptCreditTermsStatementsByCustomer As rptCreditTermsStatementsByCustomer = New rptCreditTermsStatementsByCustomer()
						rptCreditTermsStatementsByCustomer.SetDataSource(ModCommonClasses.ds)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p1", Me.DateTimePicker2.Value.[Date])
						rptCreditTermsStatementsByCustomer.SetParameterValue("p2", Me.DateTimePicker1.Value.[Date])
						rptCreditTermsStatementsByCustomer.SetParameterValue("p3", Me.txtCustomerID.Text)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p4", Me.txtCustomerName.Text)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p5", Me.a)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p6", Me.b)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p7", Me.c)
						rptCreditTermsStatementsByCustomer.SetParameterValue("p8", Me.d)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCreditTermsStatementsByCustomer
						MyProject.Forms.frmReport.ShowDialog()
						rptCreditTermsStatementsByCustomer.Close()
						rptCreditTermsStatementsByCustomer.Dispose()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010FE2 RID: 69602 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCreditTermsStatements_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006626 RID: 26150
		Private a As String

		' Token: 0x04006627 RID: 26151
		Private b As String

		' Token: 0x04006628 RID: 26152
		Private c As String

		' Token: 0x04006629 RID: 26153
		Private d As String
	End Class
End Namespace
