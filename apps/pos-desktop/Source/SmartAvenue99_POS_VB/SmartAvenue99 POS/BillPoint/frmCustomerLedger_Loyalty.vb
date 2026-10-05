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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000D8 RID: 216
	<DesignerGenerated()>
	Public Partial Class frmCustomerLedger_Loyalty
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060026B5 RID: 9909 RVA: 0x00019A76 File Offset: 0x00017C76
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000F42 RID: 3906
		' (get) Token: 0x060026B8 RID: 9912 RVA: 0x00019AA8 File Offset: 0x00017CA8
		' (set) Token: 0x060026B9 RID: 9913 RVA: 0x00019AB2 File Offset: 0x00017CB2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000F43 RID: 3907
		' (get) Token: 0x060026BA RID: 9914 RVA: 0x00019ABB File Offset: 0x00017CBB
		' (set) Token: 0x060026BB RID: 9915 RVA: 0x00019AC5 File Offset: 0x00017CC5
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000F44 RID: 3908
		' (get) Token: 0x060026BC RID: 9916 RVA: 0x00019ACE File Offset: 0x00017CCE
		' (set) Token: 0x060026BD RID: 9917 RVA: 0x00019AD8 File Offset: 0x00017CD8
		Friend Overridable Property Label1 As Label

		' Token: 0x17000F45 RID: 3909
		' (get) Token: 0x060026BE RID: 9918 RVA: 0x00019AE1 File Offset: 0x00017CE1
		' (set) Token: 0x060026BF RID: 9919 RVA: 0x00188030 File Offset: 0x00186230
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

		' Token: 0x17000F46 RID: 3910
		' (get) Token: 0x060026C0 RID: 9920 RVA: 0x00019AEB File Offset: 0x00017CEB
		' (set) Token: 0x060026C1 RID: 9921 RVA: 0x00019AF5 File Offset: 0x00017CF5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000F47 RID: 3911
		' (get) Token: 0x060026C2 RID: 9922 RVA: 0x00019AFE File Offset: 0x00017CFE
		' (set) Token: 0x060026C3 RID: 9923 RVA: 0x00019B08 File Offset: 0x00017D08
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000F48 RID: 3912
		' (get) Token: 0x060026C4 RID: 9924 RVA: 0x00019B11 File Offset: 0x00017D11
		' (set) Token: 0x060026C5 RID: 9925 RVA: 0x00019B1B File Offset: 0x00017D1B
		Friend Overridable Property Label2 As Label

		' Token: 0x17000F49 RID: 3913
		' (get) Token: 0x060026C6 RID: 9926 RVA: 0x00019B24 File Offset: 0x00017D24
		' (set) Token: 0x060026C7 RID: 9927 RVA: 0x00019B2E File Offset: 0x00017D2E
		Friend Overridable Property Label4 As Label

		' Token: 0x17000F4A RID: 3914
		' (get) Token: 0x060026C8 RID: 9928 RVA: 0x00019B37 File Offset: 0x00017D37
		' (set) Token: 0x060026C9 RID: 9929 RVA: 0x00019B41 File Offset: 0x00017D41
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17000F4B RID: 3915
		' (get) Token: 0x060026CA RID: 9930 RVA: 0x00019B4A File Offset: 0x00017D4A
		' (set) Token: 0x060026CB RID: 9931 RVA: 0x00019B54 File Offset: 0x00017D54
		Friend Overridable Property Label3 As Label

		' Token: 0x17000F4C RID: 3916
		' (get) Token: 0x060026CC RID: 9932 RVA: 0x00019B5D File Offset: 0x00017D5D
		' (set) Token: 0x060026CD RID: 9933 RVA: 0x00019B67 File Offset: 0x00017D67
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x17000F4D RID: 3917
		' (get) Token: 0x060026CE RID: 9934 RVA: 0x00019B70 File Offset: 0x00017D70
		' (set) Token: 0x060026CF RID: 9935 RVA: 0x00188074 File Offset: 0x00186274
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerID_TextChanged
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F4E RID: 3918
		' (get) Token: 0x060026D0 RID: 9936 RVA: 0x00019B7A File Offset: 0x00017D7A
		' (set) Token: 0x060026D1 RID: 9937 RVA: 0x00019B84 File Offset: 0x00017D84
		Friend Overridable Property Label5 As Label

		' Token: 0x17000F4F RID: 3919
		' (get) Token: 0x060026D2 RID: 9938 RVA: 0x00019B8D File Offset: 0x00017D8D
		' (set) Token: 0x060026D3 RID: 9939 RVA: 0x001880B8 File Offset: 0x001862B8
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

		' Token: 0x17000F50 RID: 3920
		' (get) Token: 0x060026D4 RID: 9940 RVA: 0x00019B97 File Offset: 0x00017D97
		' (set) Token: 0x060026D5 RID: 9941 RVA: 0x00019BA1 File Offset: 0x00017DA1
		Friend Overridable Property lblBalance As Label

		' Token: 0x17000F51 RID: 3921
		' (get) Token: 0x060026D6 RID: 9942 RVA: 0x00019BAA File Offset: 0x00017DAA
		' (set) Token: 0x060026D7 RID: 9943 RVA: 0x001880FC File Offset: 0x001862FC
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

		' Token: 0x17000F52 RID: 3922
		' (get) Token: 0x060026D8 RID: 9944 RVA: 0x00019BB4 File Offset: 0x00017DB4
		' (set) Token: 0x060026D9 RID: 9945 RVA: 0x00188140 File Offset: 0x00186340
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

		' Token: 0x060026DA RID: 9946 RVA: 0x00188184 File Offset: 0x00186384
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

		' Token: 0x060026DB RID: 9947 RVA: 0x00019BBE File Offset: 0x00017DBE
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
		End Sub

		' Token: 0x060026DC RID: 9948 RVA: 0x00019BFB File Offset: 0x00017DFB
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060026DD RID: 9949 RVA: 0x00019C17 File Offset: 0x00017E17
		Private Sub frmCustomerLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x060026DE RID: 9950 RVA: 0x00188260 File Offset: 0x00186460
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

		' Token: 0x060026DF RID: 9951 RVA: 0x001883D8 File Offset: 0x001865D8
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

		' Token: 0x060026E0 RID: 9952 RVA: 0x00188494 File Offset: 0x00186694
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

		' Token: 0x060026E1 RID: 9953 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060026E2 RID: 9954 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060026E3 RID: 9955 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060026E4 RID: 9956 RVA: 0x00188560 File Offset: 0x00186760
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

		' Token: 0x060026E5 RID: 9957 RVA: 0x00019C28 File Offset: 0x00017E28
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.GetCustomerBalance()
		End Sub

		' Token: 0x060026E6 RID: 9958 RVA: 0x00019C32 File Offset: 0x00017E32
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060026E7 RID: 9959 RVA: 0x001886E4 File Offset: 0x001868E4
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve Customer Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCustomerName.Focus()
				Else
					Me.GetCustomerInfo()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select PartyID from CustomerLedgerBook_Loyality where PartyID=@d1 and Date >=@d2 and Date < @d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
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
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit, Remarks from CustomerLedgerBook_Loyality where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustomerID.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("CustomerLedgerBook.xml")
						Dim rptCustomerLedger As rptCustomerLedger1 = New rptCustomerLedger1()
						rptCustomerLedger.SetDataSource(ModCommonClasses.ds)
						rptCustomerLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptCustomerLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptCustomerLedger.SetParameterValue("p3", Me.txtCustomerID.Text)
						rptCustomerLedger.SetParameterValue("p4", Me.txtCustomerName.Text)
						rptCustomerLedger.SetParameterValue("p5", Me.a)
						rptCustomerLedger.SetParameterValue("p6", Me.b)
						rptCustomerLedger.SetParameterValue("p7", Me.c)
						rptCustomerLedger.SetParameterValue("p8", Me.d)
						rptCustomerLedger.SetParameterValue("p9", Me.lblBalance.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCustomerLedger
						MyProject.Forms.frmReport.ShowDialog()
						rptCustomerLedger.Close()
						rptCustomerLedger.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060026E8 RID: 9960 RVA: 0x00188B20 File Offset: 0x00186D20
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Customer Ledger Loyalty"
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = False
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
		End Sub

		' Token: 0x060026E9 RID: 9961 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060026EA RID: 9962 RVA: 0x00188B80 File Offset: 0x00186D80
		Public Sub GetCustomerBalance()
			Try
				Try
					Me.num1 = 0.0
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Me.lblBalance.ForeColor = Color.DarkGreen
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "Cr"
						Me.lblBalance.ForeColor = Color.Blue
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "Dr"
							Me.lblBalance.ForeColor = Color.Red
						End If
					End If
					Me.lblBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblBalance.Text)), "0.00")
					Me.lblBalance.Text = Me.lblBalance.Text + " " + Me.str.ToString()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04000FF7 RID: 4087
		Private a As String

		' Token: 0x04000FF8 RID: 4088
		Private b As String

		' Token: 0x04000FF9 RID: 4089
		Private c As String

		' Token: 0x04000FFA RID: 4090
		Private d As String

		' Token: 0x04000FFB RID: 4091
		Private num1 As Double

		' Token: 0x04000FFC RID: 4092
		Private str As String
	End Class
End Namespace
