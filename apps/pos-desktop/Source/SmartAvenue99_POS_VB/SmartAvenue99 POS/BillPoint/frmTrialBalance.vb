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
	' Token: 0x020005B3 RID: 1459
	<DesignerGenerated()>
	Public Partial Class frmTrialBalance
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011C4B RID: 72779 RVA: 0x00079FA7 File Offset: 0x000781A7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTrialBalance_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006E69 RID: 28265
		' (get) Token: 0x06011C4E RID: 72782 RVA: 0x00079FD9 File Offset: 0x000781D9
		' (set) Token: 0x06011C4F RID: 72783 RVA: 0x00079FE3 File Offset: 0x000781E3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006E6A RID: 28266
		' (get) Token: 0x06011C50 RID: 72784 RVA: 0x00079FEC File Offset: 0x000781EC
		' (set) Token: 0x06011C51 RID: 72785 RVA: 0x00079FF6 File Offset: 0x000781F6
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006E6B RID: 28267
		' (get) Token: 0x06011C52 RID: 72786 RVA: 0x00079FFF File Offset: 0x000781FF
		' (set) Token: 0x06011C53 RID: 72787 RVA: 0x0007A009 File Offset: 0x00078209
		Friend Overridable Property Label1 As Label

		' Token: 0x17006E6C RID: 28268
		' (get) Token: 0x06011C54 RID: 72788 RVA: 0x0007A012 File Offset: 0x00078212
		' (set) Token: 0x06011C55 RID: 72789 RVA: 0x0007A01C File Offset: 0x0007821C
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006E6D RID: 28269
		' (get) Token: 0x06011C56 RID: 72790 RVA: 0x0007A025 File Offset: 0x00078225
		' (set) Token: 0x06011C57 RID: 72791 RVA: 0x00A40DCC File Offset: 0x00A3EFCC
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

		' Token: 0x17006E6E RID: 28270
		' (get) Token: 0x06011C58 RID: 72792 RVA: 0x0007A02F File Offset: 0x0007822F
		' (set) Token: 0x06011C59 RID: 72793 RVA: 0x0007A039 File Offset: 0x00078239
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006E6F RID: 28271
		' (get) Token: 0x06011C5A RID: 72794 RVA: 0x0007A042 File Offset: 0x00078242
		' (set) Token: 0x06011C5B RID: 72795 RVA: 0x0007A04C File Offset: 0x0007824C
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006E70 RID: 28272
		' (get) Token: 0x06011C5C RID: 72796 RVA: 0x0007A055 File Offset: 0x00078255
		' (set) Token: 0x06011C5D RID: 72797 RVA: 0x0007A05F File Offset: 0x0007825F
		Friend Overridable Property Label2 As Label

		' Token: 0x17006E71 RID: 28273
		' (get) Token: 0x06011C5E RID: 72798 RVA: 0x0007A068 File Offset: 0x00078268
		' (set) Token: 0x06011C5F RID: 72799 RVA: 0x0007A072 File Offset: 0x00078272
		Friend Overridable Property Label4 As Label

		' Token: 0x17006E72 RID: 28274
		' (get) Token: 0x06011C60 RID: 72800 RVA: 0x0007A07B File Offset: 0x0007827B
		' (set) Token: 0x06011C61 RID: 72801 RVA: 0x0007A085 File Offset: 0x00078285
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006E73 RID: 28275
		' (get) Token: 0x06011C62 RID: 72802 RVA: 0x0007A08E File Offset: 0x0007828E
		' (set) Token: 0x06011C63 RID: 72803 RVA: 0x00A40E10 File Offset: 0x00A3F010
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

		' Token: 0x17006E74 RID: 28276
		' (get) Token: 0x06011C64 RID: 72804 RVA: 0x0007A098 File Offset: 0x00078298
		' (set) Token: 0x06011C65 RID: 72805 RVA: 0x00A40E54 File Offset: 0x00A3F054
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

		' Token: 0x06011C66 RID: 72806 RVA: 0x00A40E98 File Offset: 0x00A3F098
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

		' Token: 0x06011C67 RID: 72807 RVA: 0x0007A0A2 File Offset: 0x000782A2
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011C68 RID: 72808 RVA: 0x0007A0BD File Offset: 0x000782BD
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011C69 RID: 72809 RVA: 0x0007A0D9 File Offset: 0x000782D9
		Private Sub frmSalesReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Reset()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011C6A RID: 72810 RVA: 0x00A40F74 File Offset: 0x00A3F174
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

		' Token: 0x06011C6B RID: 72811 RVA: 0x00A410EC File Offset: 0x00A3F2EC
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

		' Token: 0x06011C6C RID: 72812 RVA: 0x00A411A8 File Offset: 0x00A3F3A8
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

		' Token: 0x06011C6D RID: 72813 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011C6E RID: 72814 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011C6F RID: 72815 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011C70 RID: 72816 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTrialBalance_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011C71 RID: 72817 RVA: 0x00A41274 File Offset: 0x00A3F474
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from LedgerBook where Date >=@d2 and Date < @d3"
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
					ModCommonClasses.cmd = New SqlCommand("Select Name, CASE WHEN (Sum(Debit)-Sum(Credit))<= 0 THEN 0 ELSE (Sum(Debit)-Sum(Credit)) END AS Debit,CASE WHEN (Sum(Credit)-Sum(Debit))<= 0 THEN 0 ELSE (Sum(Credit)-Sum(debit)) END AS Credit from LedgerBook where  Date >=@d1 and Date < @d2 Group By Name order by Name", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("TrialBalanceAccounting.xml")
					Dim rptBalancesheet As rptBalancesheet = New rptBalancesheet()
					rptBalancesheet.SetDataSource(ModCommonClasses.ds)
					rptBalancesheet.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptBalancesheet.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptBalancesheet
					MyProject.Forms.frmReport.ShowDialog()
					rptBalancesheet.Close()
					rptBalancesheet.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011C72 RID: 72818 RVA: 0x0007A0F1 File Offset: 0x000782F1
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
