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
	' Token: 0x02000576 RID: 1398
	<DesignerGenerated()>
	Public Partial Class frmBestAndLowSellingItemsReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010FE3 RID: 69603 RVA: 0x00074FE9 File Offset: 0x000731E9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockInAndOutReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBestAndLowSellingItemsReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700696F RID: 26991
		' (get) Token: 0x06010FE6 RID: 69606 RVA: 0x0007501B File Offset: 0x0007321B
		' (set) Token: 0x06010FE7 RID: 69607 RVA: 0x00075025 File Offset: 0x00073225
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006970 RID: 26992
		' (get) Token: 0x06010FE8 RID: 69608 RVA: 0x0007502E File Offset: 0x0007322E
		' (set) Token: 0x06010FE9 RID: 69609 RVA: 0x00075038 File Offset: 0x00073238
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006971 RID: 26993
		' (get) Token: 0x06010FEA RID: 69610 RVA: 0x00075041 File Offset: 0x00073241
		' (set) Token: 0x06010FEB RID: 69611 RVA: 0x0007504B File Offset: 0x0007324B
		Friend Overridable Property Label1 As Label

		' Token: 0x17006972 RID: 26994
		' (get) Token: 0x06010FEC RID: 69612 RVA: 0x00075054 File Offset: 0x00073254
		' (set) Token: 0x06010FED RID: 69613 RVA: 0x0007505E File Offset: 0x0007325E
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006973 RID: 26995
		' (get) Token: 0x06010FEE RID: 69614 RVA: 0x00075067 File Offset: 0x00073267
		' (set) Token: 0x06010FEF RID: 69615 RVA: 0x009DE4F8 File Offset: 0x009DC6F8
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

		' Token: 0x17006974 RID: 26996
		' (get) Token: 0x06010FF0 RID: 69616 RVA: 0x00075071 File Offset: 0x00073271
		' (set) Token: 0x06010FF1 RID: 69617 RVA: 0x0007507B File Offset: 0x0007327B
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006975 RID: 26997
		' (get) Token: 0x06010FF2 RID: 69618 RVA: 0x00075084 File Offset: 0x00073284
		' (set) Token: 0x06010FF3 RID: 69619 RVA: 0x0007508E File Offset: 0x0007328E
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006976 RID: 26998
		' (get) Token: 0x06010FF4 RID: 69620 RVA: 0x00075097 File Offset: 0x00073297
		' (set) Token: 0x06010FF5 RID: 69621 RVA: 0x000750A1 File Offset: 0x000732A1
		Friend Overridable Property Label2 As Label

		' Token: 0x17006977 RID: 26999
		' (get) Token: 0x06010FF6 RID: 69622 RVA: 0x000750AA File Offset: 0x000732AA
		' (set) Token: 0x06010FF7 RID: 69623 RVA: 0x000750B4 File Offset: 0x000732B4
		Friend Overridable Property Label4 As Label

		' Token: 0x17006978 RID: 27000
		' (get) Token: 0x06010FF8 RID: 69624 RVA: 0x000750BD File Offset: 0x000732BD
		' (set) Token: 0x06010FF9 RID: 69625 RVA: 0x000750C7 File Offset: 0x000732C7
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006979 RID: 27001
		' (get) Token: 0x06010FFA RID: 69626 RVA: 0x000750D0 File Offset: 0x000732D0
		' (set) Token: 0x06010FFB RID: 69627 RVA: 0x009DE53C File Offset: 0x009DC73C
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

		' Token: 0x1700697A RID: 27002
		' (get) Token: 0x06010FFC RID: 69628 RVA: 0x000750DA File Offset: 0x000732DA
		' (set) Token: 0x06010FFD RID: 69629 RVA: 0x009DE580 File Offset: 0x009DC780
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

		' Token: 0x1700697B RID: 27003
		' (get) Token: 0x06010FFE RID: 69630 RVA: 0x000750E4 File Offset: 0x000732E4
		' (set) Token: 0x06010FFF RID: 69631 RVA: 0x009DE5C4 File Offset: 0x009DC7C4
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

		' Token: 0x06011000 RID: 69632 RVA: 0x009DE608 File Offset: 0x009DC808
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

		' Token: 0x06011001 RID: 69633 RVA: 0x000750EE File Offset: 0x000732EE
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011002 RID: 69634 RVA: 0x0007510A File Offset: 0x0007330A
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011003 RID: 69635 RVA: 0x00075125 File Offset: 0x00073325
		Private Sub frmStockInAndOutReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011004 RID: 69636 RVA: 0x009DE6E4 File Offset: 0x009DC8E4
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

		' Token: 0x06011005 RID: 69637 RVA: 0x009DE85C File Offset: 0x009DCA5C
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

		' Token: 0x06011006 RID: 69638 RVA: 0x009DE918 File Offset: 0x009DCB18
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

		' Token: 0x06011007 RID: 69639 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011008 RID: 69640 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011009 RID: 69641 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601100A RID: 69642 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBestAndLowSellingItemsReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601100B RID: 69643 RVA: 0x00075136 File Offset: 0x00073336
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601100C RID: 69644 RVA: 0x009DE9E4 File Offset: 0x009DCBE4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Product.ProductCode, Product.ProductName, SubCategory.Category, SubCategory.SubCategoryName, SUM(Invoice_Product.Qty) AS TotalQty FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName INNER JOIN InvoiceInfo ON Invoice_Product.InvoiceID = InvoiceInfo.Inv_ID Where InvoiceDate between @d1 and @d2 GROUP BY Product.ProductCode, Product.ProductName, SubCategory.Category, SubCategory.SubCategoryName HAVING(SUM(Invoice_Product.Qty) > 0) ORDER BY TotalQty ASC", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date])
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("LowSellingItems.xml")
				Dim rptLowSellingItems As rptLowSellingItems = New rptLowSellingItems()
				rptLowSellingItems.SetDataSource(ModCommonClasses.ds)
				rptLowSellingItems.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptLowSellingItems
				MyProject.Forms.frmReport.ShowDialog()
				rptLowSellingItems.Close()
				rptLowSellingItems.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601100D RID: 69645 RVA: 0x009DEB98 File Offset: 0x009DCD98
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Product.ProductCode, Product.ProductName, SubCategory.Category, SubCategory.SubCategoryName, SUM(Invoice_Product.Qty) AS TotalQty FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName INNER JOIN InvoiceInfo ON Invoice_Product.InvoiceID = InvoiceInfo.Inv_ID Where InvoiceDate between @d1 and @d2 GROUP BY Product.ProductCode, Product.ProductName, SubCategory.Category, SubCategory.SubCategoryName HAVING(SUM(Invoice_Product.Qty) > 0) ORDER BY TotalQty DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date])
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("BestSellingItems.xml")
				Dim rptBestSellingItems As rptBestSellingItems = New rptBestSellingItems()
				rptBestSellingItems.SetDataSource(ModCommonClasses.ds)
				rptBestSellingItems.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptBestSellingItems
				MyProject.Forms.frmReport.ShowDialog()
				rptBestSellingItems.Close()
				rptBestSellingItems.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
