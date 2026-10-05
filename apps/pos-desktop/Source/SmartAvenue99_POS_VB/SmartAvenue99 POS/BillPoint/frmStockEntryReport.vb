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
	' Token: 0x02000554 RID: 1364
	<DesignerGenerated()>
	Public Partial Class frmStockEntryReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010A50 RID: 68176 RVA: 0x00072D34 File Offset: 0x00070F34
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockEntryReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockEntryReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006710 RID: 26384
		' (get) Token: 0x06010A53 RID: 68179 RVA: 0x00072D66 File Offset: 0x00070F66
		' (set) Token: 0x06010A54 RID: 68180 RVA: 0x00072D70 File Offset: 0x00070F70
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006711 RID: 26385
		' (get) Token: 0x06010A55 RID: 68181 RVA: 0x00072D79 File Offset: 0x00070F79
		' (set) Token: 0x06010A56 RID: 68182 RVA: 0x00072D83 File Offset: 0x00070F83
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006712 RID: 26386
		' (get) Token: 0x06010A57 RID: 68183 RVA: 0x00072D8C File Offset: 0x00070F8C
		' (set) Token: 0x06010A58 RID: 68184 RVA: 0x00072D96 File Offset: 0x00070F96
		Friend Overridable Property Label1 As Label

		' Token: 0x17006713 RID: 26387
		' (get) Token: 0x06010A59 RID: 68185 RVA: 0x00072D9F File Offset: 0x00070F9F
		' (set) Token: 0x06010A5A RID: 68186 RVA: 0x00072DA9 File Offset: 0x00070FA9
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006714 RID: 26388
		' (get) Token: 0x06010A5B RID: 68187 RVA: 0x00072DB2 File Offset: 0x00070FB2
		' (set) Token: 0x06010A5C RID: 68188 RVA: 0x00072DBC File Offset: 0x00070FBC
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006715 RID: 26389
		' (get) Token: 0x06010A5D RID: 68189 RVA: 0x00072DC5 File Offset: 0x00070FC5
		' (set) Token: 0x06010A5E RID: 68190 RVA: 0x00072DCF File Offset: 0x00070FCF
		Friend Overridable Property Label2 As Label

		' Token: 0x17006716 RID: 26390
		' (get) Token: 0x06010A5F RID: 68191 RVA: 0x00072DD8 File Offset: 0x00070FD8
		' (set) Token: 0x06010A60 RID: 68192 RVA: 0x00072DE2 File Offset: 0x00070FE2
		Friend Overridable Property Label4 As Label

		' Token: 0x17006717 RID: 26391
		' (get) Token: 0x06010A61 RID: 68193 RVA: 0x00072DEB File Offset: 0x00070FEB
		' (set) Token: 0x06010A62 RID: 68194 RVA: 0x00072DF5 File Offset: 0x00070FF5
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006718 RID: 26392
		' (get) Token: 0x06010A63 RID: 68195 RVA: 0x00072DFE File Offset: 0x00070FFE
		' (set) Token: 0x06010A64 RID: 68196 RVA: 0x009B96AC File Offset: 0x009B78AC
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

		' Token: 0x17006719 RID: 26393
		' (get) Token: 0x06010A65 RID: 68197 RVA: 0x00072E08 File Offset: 0x00071008
		' (set) Token: 0x06010A66 RID: 68198 RVA: 0x009B96F0 File Offset: 0x009B78F0
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

		' Token: 0x1700671A RID: 26394
		' (get) Token: 0x06010A67 RID: 68199 RVA: 0x00072E12 File Offset: 0x00071012
		' (set) Token: 0x06010A68 RID: 68200 RVA: 0x009B9734 File Offset: 0x009B7934
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

		' Token: 0x06010A69 RID: 68201 RVA: 0x009B9778 File Offset: 0x009B7978
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

		' Token: 0x06010A6A RID: 68202 RVA: 0x00072E1C File Offset: 0x0007101C
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06010A6B RID: 68203 RVA: 0x00072E37 File Offset: 0x00071037
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06010A6C RID: 68204 RVA: 0x00072E53 File Offset: 0x00071053
		Private Sub frmStockEntryReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06010A6D RID: 68205 RVA: 0x009B9854 File Offset: 0x009B7A54
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

		' Token: 0x06010A6E RID: 68206 RVA: 0x009B99CC File Offset: 0x009B7BCC
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

		' Token: 0x06010A6F RID: 68207 RVA: 0x009B9A88 File Offset: 0x009B7C88
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

		' Token: 0x06010A70 RID: 68208 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010A71 RID: 68209 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010A72 RID: 68210 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010A73 RID: 68211 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockEntryReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010A74 RID: 68212 RVA: 0x009B9B54 File Offset: 0x009B7D54
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Sum(Qty) from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and Date between @d1 and @d2 group by ProductID,ProductName,Stock_Store_Join.Barcode having sum(qty)> 0 order by ProductName"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("Select ProductID,RTRIM(ProductName),RTRIM(Stock_Store_Join.Barcode),Sum(Qty) from Product,Stock_Store,Stock_Store_Join where Product.PID=Stock_Store_Join.ProductID and Stock_Store.ST_ID=Stock_Store_Join.StockID and Date between @d1 and @d2 group by ProductID,ProductName,Stock_Store_Join.Barcode having sum(qty)> 0 order by ProductName", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockEntryReport.xml")
					Dim rptStockEntry As rptStockEntry = New rptStockEntry()
					rptStockEntry.SetDataSource(ModCommonClasses.ds)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockEntry
					MyProject.Forms.frmReport.ShowDialog()
					rptStockEntry.Close()
					rptStockEntry.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010A75 RID: 68213 RVA: 0x00072E64 File Offset: 0x00071064
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
