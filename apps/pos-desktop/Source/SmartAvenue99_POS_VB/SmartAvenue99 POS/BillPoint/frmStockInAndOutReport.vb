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
	' Token: 0x02000579 RID: 1401
	<DesignerGenerated()>
	Public Partial Class frmStockInAndOutReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601108A RID: 69770 RVA: 0x0007550B File Offset: 0x0007370B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockInAndOutReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockInAndOutReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170069A6 RID: 27046
		' (get) Token: 0x0601108D RID: 69773 RVA: 0x0007553D File Offset: 0x0007373D
		' (set) Token: 0x0601108E RID: 69774 RVA: 0x00075547 File Offset: 0x00073747
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170069A7 RID: 27047
		' (get) Token: 0x0601108F RID: 69775 RVA: 0x00075550 File Offset: 0x00073750
		' (set) Token: 0x06011090 RID: 69776 RVA: 0x0007555A File Offset: 0x0007375A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170069A8 RID: 27048
		' (get) Token: 0x06011091 RID: 69777 RVA: 0x00075563 File Offset: 0x00073763
		' (set) Token: 0x06011092 RID: 69778 RVA: 0x0007556D File Offset: 0x0007376D
		Friend Overridable Property Label1 As Label

		' Token: 0x170069A9 RID: 27049
		' (get) Token: 0x06011093 RID: 69779 RVA: 0x00075576 File Offset: 0x00073776
		' (set) Token: 0x06011094 RID: 69780 RVA: 0x009E3438 File Offset: 0x009E1638
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

		' Token: 0x170069AA RID: 27050
		' (get) Token: 0x06011095 RID: 69781 RVA: 0x00075580 File Offset: 0x00073780
		' (set) Token: 0x06011096 RID: 69782 RVA: 0x0007558A File Offset: 0x0007378A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170069AB RID: 27051
		' (get) Token: 0x06011097 RID: 69783 RVA: 0x00075593 File Offset: 0x00073793
		' (set) Token: 0x06011098 RID: 69784 RVA: 0x0007559D File Offset: 0x0007379D
		Friend Overridable Property Label6 As Label

		' Token: 0x170069AC RID: 27052
		' (get) Token: 0x06011099 RID: 69785 RVA: 0x000755A6 File Offset: 0x000737A6
		' (set) Token: 0x0601109A RID: 69786 RVA: 0x000755B0 File Offset: 0x000737B0
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x170069AD RID: 27053
		' (get) Token: 0x0601109B RID: 69787 RVA: 0x000755B9 File Offset: 0x000737B9
		' (set) Token: 0x0601109C RID: 69788 RVA: 0x009E347C File Offset: 0x009E167C
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

		' Token: 0x170069AE RID: 27054
		' (get) Token: 0x0601109D RID: 69789 RVA: 0x000755C3 File Offset: 0x000737C3
		' (set) Token: 0x0601109E RID: 69790 RVA: 0x009E34C0 File Offset: 0x009E16C0
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

		' Token: 0x170069AF RID: 27055
		' (get) Token: 0x0601109F RID: 69791 RVA: 0x000755CD File Offset: 0x000737CD
		' (set) Token: 0x060110A0 RID: 69792 RVA: 0x009E3504 File Offset: 0x009E1704
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

		' Token: 0x170069B0 RID: 27056
		' (get) Token: 0x060110A1 RID: 69793 RVA: 0x000755D7 File Offset: 0x000737D7
		' (set) Token: 0x060110A2 RID: 69794 RVA: 0x009E3548 File Offset: 0x009E1748
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060110A3 RID: 69795 RVA: 0x000755E1 File Offset: 0x000737E1
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060110A4 RID: 69796 RVA: 0x000755FD File Offset: 0x000737FD
		Private Sub frmStockInAndOutReport_Load(sender As Object, e As EventArgs)
			Me.fillSupplierName()
			Me.Convert_Language()
		End Sub

		' Token: 0x060110A5 RID: 69797 RVA: 0x009E358C File Offset: 0x009E178C
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

		' Token: 0x060110A6 RID: 69798 RVA: 0x009E3704 File Offset: 0x009E1904
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

		' Token: 0x060110A7 RID: 69799 RVA: 0x009E37C0 File Offset: 0x009E19C0
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

		' Token: 0x060110A8 RID: 69800 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060110A9 RID: 69801 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060110AA RID: 69802 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060110AB RID: 69803 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockInAndOutReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060110AC RID: 69804 RVA: 0x009E388C File Offset: 0x009E1A8C
		Public Sub fillSupplierName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT Distinct RTRIM(SuplName) FROM Temp_Stock", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060110AD RID: 69805 RVA: 0x009E39C0 File Offset: 0x009E1BC0
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Temp_Stock.SuplName as ProductCode,Product.HSNCode,ProductName,Temp_Stock.Barcode,Qty,CostPrice*Qty,SPrice*Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Qty > 0 order by ProductName", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("StockInXT.xml")
				Dim rptStockIn As rptStockIn = New rptStockIn()
				rptStockIn.SetDataSource(ModCommonClasses.ds)
				rptStockIn.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockIn
				MyProject.Forms.frmReport.ShowDialog()
				rptStockIn.Close()
				rptStockIn.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060110AE RID: 69806 RVA: 0x009E3B18 File Offset: 0x009E1D18
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT distinct ProductCode,Temp_Stock.SuplName as HSNCode,ProductName,(Temp_Stock.Barcode) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Qty <= 0 order by ProductName", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("StockOut3.xml")
				Dim rptStockOut As rptStockOut = New rptStockOut()
				rptStockOut.SetDataSource(ModCommonClasses.ds)
				rptStockOut.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockOut
				MyProject.Forms.frmReport.ShowDialog()
				rptStockOut.Close()
				rptStockOut.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060110AF RID: 69807 RVA: 0x009E3C70 File Offset: 0x009E1E70
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select Supplier Name" & vbLf, "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Temp_Stock.SuplName as ProductCode,Product.HSNCode,ProductName,Temp_Stock.Barcode,Qty,CostPrice*Qty,SPrice*Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Qty > 0 and Temp_Stock.SuplName=@d3 order by ProductName", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockInXT.xml")
					Dim rptStockIn As rptStockIn = New rptStockIn()
					rptStockIn.SetDataSource(ModCommonClasses.ds)
					rptStockIn.SetParameterValue("p1", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockIn
					MyProject.Forms.frmReport.ShowDialog()
					rptStockIn.Close()
					rptStockIn.Dispose()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060110B0 RID: 69808 RVA: 0x009E3E20 File Offset: 0x009E2020
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select Supplier Name" & vbLf, "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT distinct ProductCode,Temp_Stock.SuplName as HSNCode,ProductName,(Temp_Stock.Barcode) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Qty <= 0 and Temp_Stock.SuplName=@d3 order by ProductName", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("StockOut3.xml")
					Dim rptStockOut As rptStockOut = New rptStockOut()
					rptStockOut.SetDataSource(ModCommonClasses.ds)
					rptStockOut.SetParameterValue("p1", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptStockOut
					MyProject.Forms.frmReport.ShowDialog()
					rptStockOut.Close()
					rptStockOut.Dispose()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub
	End Class
End Namespace
