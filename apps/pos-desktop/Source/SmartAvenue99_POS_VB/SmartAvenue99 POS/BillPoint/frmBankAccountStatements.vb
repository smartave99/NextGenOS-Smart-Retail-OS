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
	' Token: 0x02000012 RID: 18
	<DesignerGenerated()>
	Public Partial Class frmBankAccountStatements
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06000494 RID: 1172 RVA: 0x000091D5 File Offset: 0x000073D5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBankAccountStatements_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBankAccountStatements_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170002CA RID: 714
		' (get) Token: 0x06000497 RID: 1175 RVA: 0x00009207 File Offset: 0x00007407
		' (set) Token: 0x06000498 RID: 1176 RVA: 0x00009211 File Offset: 0x00007411
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170002CB RID: 715
		' (get) Token: 0x06000499 RID: 1177 RVA: 0x0000921A File Offset: 0x0000741A
		' (set) Token: 0x0600049A RID: 1178 RVA: 0x00009224 File Offset: 0x00007424
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170002CC RID: 716
		' (get) Token: 0x0600049B RID: 1179 RVA: 0x0000922D File Offset: 0x0000742D
		' (set) Token: 0x0600049C RID: 1180 RVA: 0x00009237 File Offset: 0x00007437
		Friend Overridable Property Label1 As Label

		' Token: 0x170002CD RID: 717
		' (get) Token: 0x0600049D RID: 1181 RVA: 0x00009240 File Offset: 0x00007440
		' (set) Token: 0x0600049E RID: 1182 RVA: 0x0000924A File Offset: 0x0000744A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170002CE RID: 718
		' (get) Token: 0x0600049F RID: 1183 RVA: 0x00009253 File Offset: 0x00007453
		' (set) Token: 0x060004A0 RID: 1184 RVA: 0x00086088 File Offset: 0x00084288
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

		' Token: 0x170002CF RID: 719
		' (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000925D File Offset: 0x0000745D
		' (set) Token: 0x060004A2 RID: 1186 RVA: 0x00009267 File Offset: 0x00007467
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170002D0 RID: 720
		' (get) Token: 0x060004A3 RID: 1187 RVA: 0x00009270 File Offset: 0x00007470
		' (set) Token: 0x060004A4 RID: 1188 RVA: 0x0000927A File Offset: 0x0000747A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170002D1 RID: 721
		' (get) Token: 0x060004A5 RID: 1189 RVA: 0x00009283 File Offset: 0x00007483
		' (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000928D File Offset: 0x0000748D
		Friend Overridable Property Label2 As Label

		' Token: 0x170002D2 RID: 722
		' (get) Token: 0x060004A7 RID: 1191 RVA: 0x00009296 File Offset: 0x00007496
		' (set) Token: 0x060004A8 RID: 1192 RVA: 0x000092A0 File Offset: 0x000074A0
		Friend Overridable Property Label4 As Label

		' Token: 0x170002D3 RID: 723
		' (get) Token: 0x060004A9 RID: 1193 RVA: 0x000092A9 File Offset: 0x000074A9
		' (set) Token: 0x060004AA RID: 1194 RVA: 0x000092B3 File Offset: 0x000074B3
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170002D4 RID: 724
		' (get) Token: 0x060004AB RID: 1195 RVA: 0x000092BC File Offset: 0x000074BC
		' (set) Token: 0x060004AC RID: 1196 RVA: 0x000092C6 File Offset: 0x000074C6
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170002D5 RID: 725
		' (get) Token: 0x060004AD RID: 1197 RVA: 0x000092CF File Offset: 0x000074CF
		' (set) Token: 0x060004AE RID: 1198 RVA: 0x000092D9 File Offset: 0x000074D9
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170002D6 RID: 726
		' (get) Token: 0x060004AF RID: 1199 RVA: 0x000092E2 File Offset: 0x000074E2
		' (set) Token: 0x060004B0 RID: 1200 RVA: 0x000092EC File Offset: 0x000074EC
		Friend Overridable Property Label3 As Label

		' Token: 0x170002D7 RID: 727
		' (get) Token: 0x060004B1 RID: 1201 RVA: 0x000092F5 File Offset: 0x000074F5
		' (set) Token: 0x060004B2 RID: 1202 RVA: 0x000092FF File Offset: 0x000074FF
		Friend Overridable Property Label5 As Label

		' Token: 0x170002D8 RID: 728
		' (get) Token: 0x060004B3 RID: 1203 RVA: 0x00009308 File Offset: 0x00007508
		' (set) Token: 0x060004B4 RID: 1204 RVA: 0x00009312 File Offset: 0x00007512
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170002D9 RID: 729
		' (get) Token: 0x060004B5 RID: 1205 RVA: 0x0000931B File Offset: 0x0000751B
		' (set) Token: 0x060004B6 RID: 1206 RVA: 0x000860CC File Offset: 0x000842CC
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002DA RID: 730
		' (get) Token: 0x060004B7 RID: 1207 RVA: 0x00009325 File Offset: 0x00007525
		' (set) Token: 0x060004B8 RID: 1208 RVA: 0x0000932F File Offset: 0x0000752F
		Friend Overridable Property Label6 As Label

		' Token: 0x170002DB RID: 731
		' (get) Token: 0x060004B9 RID: 1209 RVA: 0x00009338 File Offset: 0x00007538
		' (set) Token: 0x060004BA RID: 1210 RVA: 0x00009342 File Offset: 0x00007542
		Friend Overridable Property lblCurBalance As Label

		' Token: 0x170002DC RID: 732
		' (get) Token: 0x060004BB RID: 1211 RVA: 0x0000934B File Offset: 0x0000754B
		' (set) Token: 0x060004BC RID: 1212 RVA: 0x00086110 File Offset: 0x00084310
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002DD RID: 733
		' (get) Token: 0x060004BD RID: 1213 RVA: 0x00009355 File Offset: 0x00007555
		' (set) Token: 0x060004BE RID: 1214 RVA: 0x00086154 File Offset: 0x00084354
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002DE RID: 734
		' (get) Token: 0x060004BF RID: 1215 RVA: 0x0000935F File Offset: 0x0000755F
		' (set) Token: 0x060004C0 RID: 1216 RVA: 0x00086198 File Offset: 0x00084398
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060004C1 RID: 1217 RVA: 0x000861DC File Offset: 0x000843DC
		Public Sub Reset()
			Me.dtpDateFrom.Text = Conversions.ToString(DateAndTime.Today)
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.cmbAccountNo.SelectedIndex = -1
			Me.lblCurBalance.Text = ""
		End Sub

		' Token: 0x060004C2 RID: 1218 RVA: 0x00009369 File Offset: 0x00007569
		Private Sub cmbAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.GetCurrentBalance()
		End Sub

		' Token: 0x060004C3 RID: 1219 RVA: 0x00086258 File Offset: 0x00084458
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please select account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbAccountNo.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from BankAccountLedger where Date >=@d1 and Date < @d2 and AccNo=@d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbAccountNo.Text)
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
						ModCommonClasses.cmd = New SqlCommand("SELECT Credit,Debit, BankAccountLedger.Id, BankAccountLedger.AccNo, BankAccountLedger.Date, BankAccountLedger.LedgerNo, BankAccountLedger.Label, BankAccountLedger.Debit, BankBranch.BranchName, BankBranch.SwiftCode, BankBranch.IFSCCode, BankBranch.BankName, BankAccountRegistration.AccountName FROM Bank INNER JOIN BankBranch ON Bank.BankName = BankBranch.BankName INNER JOIN BankAccountRegistration ON BankBranch.Id = BankAccountRegistration.BranchID INNER JOIN BankAccountLedger ON BankAccountRegistration.AccountNo = BankAccountLedger.AccNo where Date >=@d1 and Date < @d2 and AccNo=@d3 order by ID,Date,LedgerNo", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbAccountNo.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("BankAccountStatements3.xml")
						Dim rptBankAccountStatements As rptBankAccountStatements1 = New rptBankAccountStatements1()
						rptBankAccountStatements.SetDataSource(ModCommonClasses.ds)
						rptBankAccountStatements.SetParameterValue("p1", Me.DateTimePicker2.Value.[Date])
						rptBankAccountStatements.SetParameterValue("p2", Me.DateTimePicker1.Value.[Date])
						rptBankAccountStatements.SetParameterValue("CB", Me.lblCurBalance.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptBankAccountStatements
						MyProject.Forms.frmReport.ShowDialog()
						rptBankAccountStatements.Close()
						rptBankAccountStatements.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060004C4 RID: 1220 RVA: 0x00009373 File Offset: 0x00007573
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060004C5 RID: 1221 RVA: 0x00086618 File Offset: 0x00084818
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from BankAccountLedger where Date >=@d1 and Date < @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
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
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("Select  Id, Date, AccNo, LedgerNo, Label, Debit, Credit from BankAccountLedger where Date >=@d1 and Date < @d2 order by ID,Date,LedgerNo", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("BankAccountStatements1.xml")
					Dim rptBankAccountStatements As rptBankAccountStatements = New rptBankAccountStatements()
					rptBankAccountStatements.SetDataSource(ModCommonClasses.ds)
					rptBankAccountStatements.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptBankAccountStatements.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptBankAccountStatements
					MyProject.Forms.frmReport.ShowDialog()
					rptBankAccountStatements.Close()
					rptBankAccountStatements.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060004C6 RID: 1222 RVA: 0x0008693C File Offset: 0x00084B3C
		Public Sub GetCurrentBalance()
			Try
				Me.num1 = 0.0
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) FROM BankAccountLedger where AccNo=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text.ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
				Me.lblCurBalance.Text = Conversions.ToString(Me.num1)
				Me.lblCurBalance.ForeColor = Color.DarkGreen
				Dim flag2 As Boolean = Conversion.Val(Me.lblCurBalance.Text) >= 0.0
				If flag2 Then
					Me.str = "Cr"
					Me.lblCurBalance.ForeColor = Color.Blue
				Else
					Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblCurBalance.Text) < 0.0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						Me.lblCurBalance.ForeColor = Color.Red
					End If
				End If
				Me.lblCurBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblCurBalance.Text)), "0.00")
				Me.lblCurBalance.Text = Me.lblCurBalance.Text + " " + Me.str.ToString()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060004C7 RID: 1223 RVA: 0x0000937D File Offset: 0x0000757D
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060004C8 RID: 1224 RVA: 0x00086B50 File Offset: 0x00084D50
		Public Sub fillAccountNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060004C9 RID: 1225 RVA: 0x00009399 File Offset: 0x00007599
		Private Sub frmBankAccountStatements_Load(sender As Object, e As EventArgs)
			Me.fillAccountNo()
			Me.Convert_Language()
		End Sub

		' Token: 0x060004CA RID: 1226 RVA: 0x00086C78 File Offset: 0x00084E78
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

		' Token: 0x060004CB RID: 1227 RVA: 0x00086DF0 File Offset: 0x00084FF0
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

		' Token: 0x060004CC RID: 1228 RVA: 0x00086EAC File Offset: 0x000850AC
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

		' Token: 0x060004CD RID: 1229 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060004CE RID: 1230 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060004CF RID: 1231 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060004D0 RID: 1232 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBankAccountStatements_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x040001BD RID: 445
		Private a As Decimal

		' Token: 0x040001BE RID: 446
		Private b As Decimal

		' Token: 0x040001BF RID: 447
		Private c As Decimal

		' Token: 0x040001C0 RID: 448
		Private d As Decimal

		' Token: 0x040001C1 RID: 449
		Private f As Decimal

		' Token: 0x040001C2 RID: 450
		Private g As Decimal

		' Token: 0x040001C3 RID: 451
		Private h As Decimal

		' Token: 0x040001C4 RID: 452
		Private i As Decimal

		' Token: 0x040001C5 RID: 453
		Private num1 As Double

		' Token: 0x040001C6 RID: 454
		Private str As String
	End Class
End Namespace
