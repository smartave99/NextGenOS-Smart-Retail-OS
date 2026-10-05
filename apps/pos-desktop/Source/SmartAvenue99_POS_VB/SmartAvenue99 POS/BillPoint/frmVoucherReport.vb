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
	' Token: 0x020005C2 RID: 1474
	<DesignerGenerated()>
	Public Partial Class frmVoucherReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011F81 RID: 73601 RVA: 0x0007B3D5 File Offset: 0x000795D5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmVoucherReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006F94 RID: 28564
		' (get) Token: 0x06011F84 RID: 73604 RVA: 0x0007B407 File Offset: 0x00079607
		' (set) Token: 0x06011F85 RID: 73605 RVA: 0x0007B411 File Offset: 0x00079611
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006F95 RID: 28565
		' (get) Token: 0x06011F86 RID: 73606 RVA: 0x0007B41A File Offset: 0x0007961A
		' (set) Token: 0x06011F87 RID: 73607 RVA: 0x0007B424 File Offset: 0x00079624
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006F96 RID: 28566
		' (get) Token: 0x06011F88 RID: 73608 RVA: 0x0007B42D File Offset: 0x0007962D
		' (set) Token: 0x06011F89 RID: 73609 RVA: 0x0007B437 File Offset: 0x00079637
		Friend Overridable Property Label1 As Label

		' Token: 0x17006F97 RID: 28567
		' (get) Token: 0x06011F8A RID: 73610 RVA: 0x0007B440 File Offset: 0x00079640
		' (set) Token: 0x06011F8B RID: 73611 RVA: 0x0007B44A File Offset: 0x0007964A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006F98 RID: 28568
		' (get) Token: 0x06011F8C RID: 73612 RVA: 0x0007B453 File Offset: 0x00079653
		' (set) Token: 0x06011F8D RID: 73613 RVA: 0x00A5C398 File Offset: 0x00A5A598
		Private _cmbVoucherNo As ComboBox
		Friend Overridable Property cmbVoucherNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbVoucherNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbVoucherNo_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbVoucherNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbVoucherNo = value
				comboBox = Me._cmbVoucherNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F99 RID: 28569
		' (get) Token: 0x06011F8E RID: 73614 RVA: 0x0007B45D File Offset: 0x0007965D
		' (set) Token: 0x06011F8F RID: 73615 RVA: 0x0007B467 File Offset: 0x00079667
		Friend Overridable Property Label9 As Label

		' Token: 0x17006F9A RID: 28570
		' (get) Token: 0x06011F90 RID: 73616 RVA: 0x0007B470 File Offset: 0x00079670
		' (set) Token: 0x06011F91 RID: 73617 RVA: 0x00A5C3DC File Offset: 0x00A5A5DC
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

		' Token: 0x17006F9B RID: 28571
		' (get) Token: 0x06011F92 RID: 73618 RVA: 0x0007B47A File Offset: 0x0007967A
		' (set) Token: 0x06011F93 RID: 73619 RVA: 0x0007B484 File Offset: 0x00079684
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006F9C RID: 28572
		' (get) Token: 0x06011F94 RID: 73620 RVA: 0x0007B48D File Offset: 0x0007968D
		' (set) Token: 0x06011F95 RID: 73621 RVA: 0x0007B497 File Offset: 0x00079697
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006F9D RID: 28573
		' (get) Token: 0x06011F96 RID: 73622 RVA: 0x0007B4A0 File Offset: 0x000796A0
		' (set) Token: 0x06011F97 RID: 73623 RVA: 0x0007B4AA File Offset: 0x000796AA
		Friend Overridable Property Label2 As Label

		' Token: 0x17006F9E RID: 28574
		' (get) Token: 0x06011F98 RID: 73624 RVA: 0x0007B4B3 File Offset: 0x000796B3
		' (set) Token: 0x06011F99 RID: 73625 RVA: 0x0007B4BD File Offset: 0x000796BD
		Friend Overridable Property Label4 As Label

		' Token: 0x17006F9F RID: 28575
		' (get) Token: 0x06011F9A RID: 73626 RVA: 0x0007B4C6 File Offset: 0x000796C6
		' (set) Token: 0x06011F9B RID: 73627 RVA: 0x0007B4D0 File Offset: 0x000796D0
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006FA0 RID: 28576
		' (get) Token: 0x06011F9C RID: 73628 RVA: 0x0007B4D9 File Offset: 0x000796D9
		' (set) Token: 0x06011F9D RID: 73629 RVA: 0x00A5C420 File Offset: 0x00A5A620
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

		' Token: 0x17006FA1 RID: 28577
		' (get) Token: 0x06011F9E RID: 73630 RVA: 0x0007B4E3 File Offset: 0x000796E3
		' (set) Token: 0x06011F9F RID: 73631 RVA: 0x00A5C464 File Offset: 0x00A5A664
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

		' Token: 0x17006FA2 RID: 28578
		' (get) Token: 0x06011FA0 RID: 73632 RVA: 0x0007B4ED File Offset: 0x000796ED
		' (set) Token: 0x06011FA1 RID: 73633 RVA: 0x00A5C4A8 File Offset: 0x00A5A6A8
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

		' Token: 0x06011FA2 RID: 73634 RVA: 0x00A5C4EC File Offset: 0x00A5A6EC
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

		' Token: 0x06011FA3 RID: 73635 RVA: 0x00A5C5C8 File Offset: 0x00A5A7C8
		Public Sub fillVoucherNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(VoucherNo) FROM Voucher", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbVoucherNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbVoucherNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011FA4 RID: 73636 RVA: 0x0007B4F7 File Offset: 0x000796F7
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.fillVoucherNo()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011FA5 RID: 73637 RVA: 0x00A5C6F0 File Offset: 0x00A5A8F0
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

		' Token: 0x06011FA6 RID: 73638 RVA: 0x00A5C868 File Offset: 0x00A5AA68
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

		' Token: 0x06011FA7 RID: 73639 RVA: 0x00A5C924 File Offset: 0x00A5AB24
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

		' Token: 0x06011FA8 RID: 73640 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011FA9 RID: 73641 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011FAA RID: 73642 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011FAB RID: 73643 RVA: 0x0007B50F File Offset: 0x0007970F
		Public Sub Reset()
			Me.cmbVoucherNo.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.fillVoucherNo()
		End Sub

		' Token: 0x06011FAC RID: 73644 RVA: 0x0007B542 File Offset: 0x00079742
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011FAD RID: 73645 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbVoucherNo_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06011FAE RID: 73646 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmVoucherReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011FAF RID: 73647 RVA: 0x0007B55E File Offset: 0x0007975E
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011FB0 RID: 73648 RVA: 0x00A5C9F0 File Offset: 0x00A5ABF0
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptExpenses As rptExpenses = New rptExpenses()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where Voucher.date between @d1 and @d2 order by voucher.date"
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter.Fill(dataSet, "Voucher")
				sqlDataAdapter.Fill(dataSet, "Voucher_OtherDetails")
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select ISNULL(sum(GrandTotal),0) from Voucher where Date between @d1 and @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
				End While
				rptExpenses.SetDataSource(dataSet)
				rptExpenses.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
				rptExpenses.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
				rptExpenses.SetParameterValue("p3", Me.a)
				rptExpenses.SetParameterValue("p4", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptExpenses
				MyProject.Forms.frmReport.ShowDialog()
				rptExpenses.Close()
				rptExpenses.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011FB1 RID: 73649 RVA: 0x00A5CCD0 File Offset: 0x00A5AED0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbVoucherNo.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select voucher no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbVoucherNo.Focus()
			Else
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim rptVoucher As rptVoucher = New rptVoucher()
					Dim sqlCommand As SqlCommand = New SqlCommand()
					Dim sqlCommand2 As SqlCommand = New SqlCommand()
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
					Dim dataSet As DataSet = New DataSet()
					Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlCommand.Connection = sqlConnection
					sqlCommand2.Connection = sqlConnection
					sqlCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where VoucherNo='" + Me.cmbVoucherNo.Text + "'"
					sqlCommand2.CommandText = "SELECT * from Company"
					sqlCommand.CommandType = CommandType.Text
					sqlCommand2.CommandType = CommandType.Text
					sqlDataAdapter.SelectCommand = sqlCommand
					sqlDataAdapter2.SelectCommand = sqlCommand2
					sqlDataAdapter.Fill(dataSet, "Voucher")
					sqlDataAdapter.Fill(dataSet, "Voucher_OtherDetails")
					sqlDataAdapter2.Fill(dataSet, "Company")
					rptVoucher.SetDataSource(dataSet)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptVoucher
					MyProject.Forms.frmReport.ShowDialog()
					rptVoucher.Close()
					rptVoucher.Dispose()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x04006C10 RID: 27664
		Private a As Decimal
	End Class
End Namespace
