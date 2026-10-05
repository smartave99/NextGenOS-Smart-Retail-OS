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
	' Token: 0x0200036F RID: 879
	<DesignerGenerated()>
	Public Partial Class frmStockMovementReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CFB4 RID: 53172 RVA: 0x0005C579 File Offset: 0x0005A779
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockMovementReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockMovementReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700517A RID: 20858
		' (get) Token: 0x0600CFB7 RID: 53175 RVA: 0x0005C5AB File Offset: 0x0005A7AB
		' (set) Token: 0x0600CFB8 RID: 53176 RVA: 0x0005C5B5 File Offset: 0x0005A7B5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700517B RID: 20859
		' (get) Token: 0x0600CFB9 RID: 53177 RVA: 0x0005C5BE File Offset: 0x0005A7BE
		' (set) Token: 0x0600CFBA RID: 53178 RVA: 0x0005C5C8 File Offset: 0x0005A7C8
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700517C RID: 20860
		' (get) Token: 0x0600CFBB RID: 53179 RVA: 0x0005C5D1 File Offset: 0x0005A7D1
		' (set) Token: 0x0600CFBC RID: 53180 RVA: 0x0005C5DB File Offset: 0x0005A7DB
		Friend Overridable Property Label1 As Label

		' Token: 0x1700517D RID: 20861
		' (get) Token: 0x0600CFBD RID: 53181 RVA: 0x0005C5E4 File Offset: 0x0005A7E4
		' (set) Token: 0x0600CFBE RID: 53182 RVA: 0x0005C5EE File Offset: 0x0005A7EE
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700517E RID: 20862
		' (get) Token: 0x0600CFBF RID: 53183 RVA: 0x0005C5F7 File Offset: 0x0005A7F7
		' (set) Token: 0x0600CFC0 RID: 53184 RVA: 0x0005C601 File Offset: 0x0005A801
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700517F RID: 20863
		' (get) Token: 0x0600CFC1 RID: 53185 RVA: 0x0005C60A File Offset: 0x0005A80A
		' (set) Token: 0x0600CFC2 RID: 53186 RVA: 0x0005C614 File Offset: 0x0005A814
		Friend Overridable Property Label2 As Label

		' Token: 0x17005180 RID: 20864
		' (get) Token: 0x0600CFC3 RID: 53187 RVA: 0x0005C61D File Offset: 0x0005A81D
		' (set) Token: 0x0600CFC4 RID: 53188 RVA: 0x0005C627 File Offset: 0x0005A827
		Friend Overridable Property Label4 As Label

		' Token: 0x17005181 RID: 20865
		' (get) Token: 0x0600CFC5 RID: 53189 RVA: 0x0005C630 File Offset: 0x0005A830
		' (set) Token: 0x0600CFC6 RID: 53190 RVA: 0x00818F88 File Offset: 0x00817188
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

		' Token: 0x17005182 RID: 20866
		' (get) Token: 0x0600CFC7 RID: 53191 RVA: 0x0005C63A File Offset: 0x0005A83A
		' (set) Token: 0x0600CFC8 RID: 53192 RVA: 0x0005C644 File Offset: 0x0005A844
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005183 RID: 20867
		' (get) Token: 0x0600CFC9 RID: 53193 RVA: 0x0005C64D File Offset: 0x0005A84D
		' (set) Token: 0x0600CFCA RID: 53194 RVA: 0x0005C657 File Offset: 0x0005A857
		Friend Overridable Property Label3 As Label

		' Token: 0x17005184 RID: 20868
		' (get) Token: 0x0600CFCB RID: 53195 RVA: 0x0005C660 File Offset: 0x0005A860
		' (set) Token: 0x0600CFCC RID: 53196 RVA: 0x0005C66A File Offset: 0x0005A86A
		Friend Overridable Property cmbProductName As ComboBox

		' Token: 0x17005185 RID: 20869
		' (get) Token: 0x0600CFCD RID: 53197 RVA: 0x0005C673 File Offset: 0x0005A873
		' (set) Token: 0x0600CFCE RID: 53198 RVA: 0x00818FCC File Offset: 0x008171CC
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

		' Token: 0x17005186 RID: 20870
		' (get) Token: 0x0600CFCF RID: 53199 RVA: 0x0005C67D File Offset: 0x0005A87D
		' (set) Token: 0x0600CFD0 RID: 53200 RVA: 0x00819010 File Offset: 0x00817210
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

		' Token: 0x17005187 RID: 20871
		' (get) Token: 0x0600CFD1 RID: 53201 RVA: 0x0005C687 File Offset: 0x0005A887
		' (set) Token: 0x0600CFD2 RID: 53202 RVA: 0x00819054 File Offset: 0x00817254
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

		' Token: 0x0600CFD3 RID: 53203 RVA: 0x00819098 File Offset: 0x00817298
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

		' Token: 0x0600CFD4 RID: 53204 RVA: 0x0005C691 File Offset: 0x0005A891
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.cmbProductName.SelectedIndex = -1
			Me.dtpDateFrom.Focus()
		End Sub

		' Token: 0x0600CFD5 RID: 53205 RVA: 0x0005C6C5 File Offset: 0x0005A8C5
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CFD6 RID: 53206 RVA: 0x0005C6E1 File Offset: 0x0005A8E1
		Private Sub frmStockMovementReport_Load(sender As Object, e As EventArgs)
			Me.fillproduct()
			Me.Reset()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CFD7 RID: 53207 RVA: 0x00819174 File Offset: 0x00817374
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

		' Token: 0x0600CFD8 RID: 53208 RVA: 0x008192EC File Offset: 0x008174EC
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

		' Token: 0x0600CFD9 RID: 53209 RVA: 0x008193A8 File Offset: 0x008175A8
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

		' Token: 0x0600CFDA RID: 53210 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CFDB RID: 53211 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CFDC RID: 53212 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CFDD RID: 53213 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockMovementReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CFDE RID: 53214 RVA: 0x00819474 File Offset: 0x00817674
		Public Sub fillproduct()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ProductName) FROM Product order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbProductName.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CFDF RID: 53215 RVA: 0x0005C6F9 File Offset: 0x0005A8F9
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CFE0 RID: 53216 RVA: 0x008195B0 File Offset: 0x008177B0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from StockMovement where Date >=@d1 and Date < @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
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
					ModCommonClasses.cmd = New SqlCommand("SELECT Date,PID,ProductName, Max(StockMovement.OpeningStock) AS OpeningStock, SUM(StockIN) AS StockIN, SUM(StockOut) AS StockOUT, Max(StockMovement.OpeningStock) + SUM(StockIN) - SUM(StockOUT) AS ClosingStock FROM StockMovement,Product WHERE StockMovement.ProductID=Product.PID and ProductName=@d3 and Date > = @d1 and Date < @d2 GROUP BY Date,PID,ProductName order by 1,3", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbProductName.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockMovementReport.xml")
					Dim rptStockMovement As rptStockMovement = New rptStockMovement()
					rptStockMovement.SetDataSource(ModCommonClasses.ds)
					rptStockMovement.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptStockMovement.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockMovement
					MyProject.Forms.frmReport.ShowDialog()
					rptStockMovement.Close()
					rptStockMovement.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CFE1 RID: 53217 RVA: 0x008198F4 File Offset: 0x00817AF4
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from StockMovement where Date >=@d1 and Date < @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
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
					ModCommonClasses.cmd = New SqlCommand("SELECT Date,PID,ProductName, Max(StockMovement.OpeningStock) AS OpeningStock, SUM(StockIN) AS StockIN, SUM(StockOut) AS StockOUT, Max(StockMovement.OpeningStock) + SUM(StockIN) - SUM(StockOUT) AS ClosingStock FROM StockMovement,Product WHERE StockMovement.ProductID=Product.PID and Date > = @d1 and Date < @d2 GROUP BY Date,PID,ProductName order by 1,3", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockMovementReport.xml")
					Dim rptStockMovement As rptStockMovement = New rptStockMovement()
					rptStockMovement.SetDataSource(ModCommonClasses.ds)
					rptStockMovement.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptStockMovement.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockMovement
					MyProject.Forms.frmReport.ShowDialog()
					rptStockMovement.Close()
					rptStockMovement.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
