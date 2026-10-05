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
	' Token: 0x020005BF RID: 1471
	<DesignerGenerated()>
	Public Partial Class frmPurchaseReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011E3E RID: 73278 RVA: 0x0007ABCA File Offset: 0x00078DCA
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurchaseReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006F28 RID: 28456
		' (get) Token: 0x06011E41 RID: 73281 RVA: 0x0007ABFC File Offset: 0x00078DFC
		' (set) Token: 0x06011E42 RID: 73282 RVA: 0x0007AC06 File Offset: 0x00078E06
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006F29 RID: 28457
		' (get) Token: 0x06011E43 RID: 73283 RVA: 0x0007AC0F File Offset: 0x00078E0F
		' (set) Token: 0x06011E44 RID: 73284 RVA: 0x0007AC19 File Offset: 0x00078E19
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006F2A RID: 28458
		' (get) Token: 0x06011E45 RID: 73285 RVA: 0x0007AC22 File Offset: 0x00078E22
		' (set) Token: 0x06011E46 RID: 73286 RVA: 0x0007AC2C File Offset: 0x00078E2C
		Friend Overridable Property Label1 As Label

		' Token: 0x17006F2B RID: 28459
		' (get) Token: 0x06011E47 RID: 73287 RVA: 0x0007AC35 File Offset: 0x00078E35
		' (set) Token: 0x06011E48 RID: 73288 RVA: 0x0007AC3F File Offset: 0x00078E3F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006F2C RID: 28460
		' (get) Token: 0x06011E49 RID: 73289 RVA: 0x0007AC48 File Offset: 0x00078E48
		' (set) Token: 0x06011E4A RID: 73290 RVA: 0x0007AC52 File Offset: 0x00078E52
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006F2D RID: 28461
		' (get) Token: 0x06011E4B RID: 73291 RVA: 0x0007AC5B File Offset: 0x00078E5B
		' (set) Token: 0x06011E4C RID: 73292 RVA: 0x0007AC65 File Offset: 0x00078E65
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006F2E RID: 28462
		' (get) Token: 0x06011E4D RID: 73293 RVA: 0x0007AC6E File Offset: 0x00078E6E
		' (set) Token: 0x06011E4E RID: 73294 RVA: 0x0007AC78 File Offset: 0x00078E78
		Friend Overridable Property Label2 As Label

		' Token: 0x17006F2F RID: 28463
		' (get) Token: 0x06011E4F RID: 73295 RVA: 0x0007AC81 File Offset: 0x00078E81
		' (set) Token: 0x06011E50 RID: 73296 RVA: 0x0007AC8B File Offset: 0x00078E8B
		Friend Overridable Property Label4 As Label

		' Token: 0x17006F30 RID: 28464
		' (get) Token: 0x06011E51 RID: 73297 RVA: 0x0007AC94 File Offset: 0x00078E94
		' (set) Token: 0x06011E52 RID: 73298 RVA: 0x0007AC9E File Offset: 0x00078E9E
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006F31 RID: 28465
		' (get) Token: 0x06011E53 RID: 73299 RVA: 0x0007ACA7 File Offset: 0x00078EA7
		' (set) Token: 0x06011E54 RID: 73300 RVA: 0x00A4FDBC File Offset: 0x00A4DFBC
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

		' Token: 0x17006F32 RID: 28466
		' (get) Token: 0x06011E55 RID: 73301 RVA: 0x0007ACB1 File Offset: 0x00078EB1
		' (set) Token: 0x06011E56 RID: 73302 RVA: 0x0007ACBB File Offset: 0x00078EBB
		Friend Overridable Property cmbProductName As ComboBox

		' Token: 0x17006F33 RID: 28467
		' (get) Token: 0x06011E57 RID: 73303 RVA: 0x0007ACC4 File Offset: 0x00078EC4
		' (set) Token: 0x06011E58 RID: 73304 RVA: 0x0007ACCE File Offset: 0x00078ECE
		Friend Overridable Property cmbCategory As ComboBox

		' Token: 0x17006F34 RID: 28468
		' (get) Token: 0x06011E59 RID: 73305 RVA: 0x0007ACD7 File Offset: 0x00078ED7
		' (set) Token: 0x06011E5A RID: 73306 RVA: 0x0007ACE1 File Offset: 0x00078EE1
		Friend Overridable Property Label5 As Label

		' Token: 0x17006F35 RID: 28469
		' (get) Token: 0x06011E5B RID: 73307 RVA: 0x0007ACEA File Offset: 0x00078EEA
		' (set) Token: 0x06011E5C RID: 73308 RVA: 0x0007ACF4 File Offset: 0x00078EF4
		Friend Overridable Property Label3 As Label

		' Token: 0x17006F36 RID: 28470
		' (get) Token: 0x06011E5D RID: 73309 RVA: 0x0007ACFD File Offset: 0x00078EFD
		' (set) Token: 0x06011E5E RID: 73310 RVA: 0x0007AD07 File Offset: 0x00078F07
		Friend Overridable Property Label6 As Label

		' Token: 0x17006F37 RID: 28471
		' (get) Token: 0x06011E5F RID: 73311 RVA: 0x0007AD10 File Offset: 0x00078F10
		' (set) Token: 0x06011E60 RID: 73312 RVA: 0x0007AD1A File Offset: 0x00078F1A
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17006F38 RID: 28472
		' (get) Token: 0x06011E61 RID: 73313 RVA: 0x0007AD23 File Offset: 0x00078F23
		' (set) Token: 0x06011E62 RID: 73314 RVA: 0x0007AD2D File Offset: 0x00078F2D
		Friend Overridable Property Label7 As Label

		' Token: 0x17006F39 RID: 28473
		' (get) Token: 0x06011E63 RID: 73315 RVA: 0x0007AD36 File Offset: 0x00078F36
		' (set) Token: 0x06011E64 RID: 73316 RVA: 0x0007AD40 File Offset: 0x00078F40
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x17006F3A RID: 28474
		' (get) Token: 0x06011E65 RID: 73317 RVA: 0x0007AD49 File Offset: 0x00078F49
		' (set) Token: 0x06011E66 RID: 73318 RVA: 0x00A4FE00 File Offset: 0x00A4E000
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
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

		' Token: 0x17006F3B RID: 28475
		' (get) Token: 0x06011E67 RID: 73319 RVA: 0x0007AD53 File Offset: 0x00078F53
		' (set) Token: 0x06011E68 RID: 73320 RVA: 0x00A4FE44 File Offset: 0x00A4E044
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

		' Token: 0x17006F3C RID: 28476
		' (get) Token: 0x06011E69 RID: 73321 RVA: 0x0007AD5D File Offset: 0x00078F5D
		' (set) Token: 0x06011E6A RID: 73322 RVA: 0x00A4FE88 File Offset: 0x00A4E088
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F3D RID: 28477
		' (get) Token: 0x06011E6B RID: 73323 RVA: 0x0007AD67 File Offset: 0x00078F67
		' (set) Token: 0x06011E6C RID: 73324 RVA: 0x00A4FECC File Offset: 0x00A4E0CC
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F3E RID: 28478
		' (get) Token: 0x06011E6D RID: 73325 RVA: 0x0007AD71 File Offset: 0x00078F71
		' (set) Token: 0x06011E6E RID: 73326 RVA: 0x00A4FF10 File Offset: 0x00A4E110
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F3F RID: 28479
		' (get) Token: 0x06011E6F RID: 73327 RVA: 0x0007AD7B File Offset: 0x00078F7B
		' (set) Token: 0x06011E70 RID: 73328 RVA: 0x00A4FF54 File Offset: 0x00A4E154
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F40 RID: 28480
		' (get) Token: 0x06011E71 RID: 73329 RVA: 0x0007AD85 File Offset: 0x00078F85
		' (set) Token: 0x06011E72 RID: 73330 RVA: 0x00A4FF98 File Offset: 0x00A4E198
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click_1
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

		' Token: 0x06011E73 RID: 73331 RVA: 0x00A4FFDC File Offset: 0x00A4E1DC
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

		' Token: 0x06011E74 RID: 73332 RVA: 0x00A500B8 File Offset: 0x00A4E2B8
		Public Sub fillSupplierName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Supplier", ModCommonClasses.con)
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

		' Token: 0x06011E75 RID: 73333 RVA: 0x00A501EC File Offset: 0x00A4E3EC
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.cmbCategory.Text = ""
			Me.cmbProductName.Text = ""
			Me.ComboBox1.SelectedIndex = -1
		End Sub

		' Token: 0x06011E76 RID: 73334 RVA: 0x0007AD8F File Offset: 0x00078F8F
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011E77 RID: 73335 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06011E78 RID: 73336 RVA: 0x00A50244 File Offset: 0x00A4E444
		Public Sub FillData()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(ProductName), RTRIM(CategoryName) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName Order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbProductName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbProductName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E79 RID: 73337 RVA: 0x00A50348 File Offset: 0x00A4E548
		Public Sub fillCategory()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011E7A RID: 73338 RVA: 0x0007ADAB File Offset: 0x00078FAB
		Private Sub frmPurchaseReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.FillData()
			Me.fillSupplierName()
			Me.fillCategory()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011E7B RID: 73339 RVA: 0x00A5047C File Offset: 0x00A4E67C
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

		' Token: 0x06011E7C RID: 73340 RVA: 0x00A505F4 File Offset: 0x00A4E7F4
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

		' Token: 0x06011E7D RID: 73341 RVA: 0x00A506B0 File Offset: 0x00A4E8B0
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

		' Token: 0x06011E7E RID: 73342 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011E7F RID: 73343 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011E80 RID: 73344 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011E81 RID: 73345 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011E82 RID: 73346 RVA: 0x0007ADD1 File Offset: 0x00078FD1
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011E83 RID: 73347 RVA: 0x00A5077C File Offset: 0x00A4E97C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 order by Stock.Date"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd2 = New SqlCommand("SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("PurchaseC2.xml")
					Dim rptPurchaseC As rptPurchaseC2 = New rptPurchaseC2()
					rptPurchaseC.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptPurchaseC.SetDataSource(ModCommonClasses.ds)
					rptPurchaseC.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptPurchaseC.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptPurchaseC.SetParameterValue("p6", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchaseC
					MyProject.Forms.frmReport.ShowDialog()
					rptPurchaseC.Close()
					rptPurchaseC.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E84 RID: 73348 RVA: 0x00A50AB4 File Offset: 0x00A4ECB4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Stock where Stock.Date between @d1 and @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Stock.ST_ID, Stock.InvoiceNo, Stock.PurchaseType, Stock.ReferenceNo1, Stock.ReferenceNo2, Stock.Date, Stock.SupplierID, Stock.SupplierInvoiceNo, Stock.SupplierInvoiceDate, Stock.TaxType, Stock.SGST,Stock.CGST, Stock.IGST, Stock.CESS, Stock.SubTotal, Stock.PreviousDue, Stock.FreightCharges, Stock.OtherCharges, Stock.Total, Stock.RoundOff, Stock.GrandTotal, Stock.TotalPayment, Stock.PaymentDue,Stock.Remarks, Stock_Product.SP_ID, Stock_Product.StockID, Stock_Product.ProductID, Stock_Product.Barcode, Stock_Product.Qty, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTPer, Stock_Product.CGSTAmt,Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt, Stock_Product.DiscountPer, Stock_Product.DiscountAmt,Stock_Product.TotalAmount, Supplier.ID, Supplier.SupplierID AS Expr1, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID,Supplier.Remarks AS Expr2, Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.GSTIN, Supplier.PAN, Supplier.CIN, Supplier.OpeningBalanceType,Supplier.OpeningBalance, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice,Product.Discount, Product.CGST AS Expr3, Product.SGST AS Expr4, Product.CESS AS Expr5, Product.Barcode AS Expr6, Product.ReorderPoint, Product.OpeningStock, Product.PurchaseUnit,Product.SalesUnit FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(Date)) AS Year, SUM(GrandTotal) AS GrandTotal FROM Stock where date between @d3 and @d4 GROUP BY YEAR(Date) ORDER BY Year", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("Purchase.xml")
					Dim rptPurchase As rptPurchase = New rptPurchase()
					rptPurchase.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptPurchase.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptPurchase.SetParameterValue("p6", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchase
					MyProject.Forms.frmReport.ShowDialog()
					rptPurchase.Close()
					rptPurchase.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E85 RID: 73349 RVA: 0x00A50E90 File Offset: 0x00A4F090
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
				If flag Then
					MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 and CategoryName=@d4 order by Stock.Date"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbCategory.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd2 = New SqlCommand("SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 and CategoryName=@d4 order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd2.Parameters.AddWithValue("@d4", Me.cmbCategory.Text)
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
						ModCommonClasses.dtable2 = New DataTable()
						ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
						ModCommonClasses.ds.WriteXmlSchema("PurchaseC2.xml")
						Dim rptPurchaseC As rptPurchaseC2 = New rptPurchaseC2()
						rptPurchaseC.Subreports(0).SetDataSource(ModCommonClasses.ds)
						rptPurchaseC.SetDataSource(ModCommonClasses.ds)
						rptPurchaseC.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptPurchaseC.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptPurchaseC.SetParameterValue("p6", DateAndTime.Today)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchaseC
						MyProject.Forms.frmReport.ShowDialog()
						rptPurchaseC.Close()
						rptPurchaseC.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E86 RID: 73350 RVA: 0x00A5124C File Offset: 0x00A4F44C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbProductName.Text)) = 0
				If flag Then
					MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 and ProductName=@d4 order by Stock.Date"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbProductName.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd2 = New SqlCommand("SELECT Stock.InvoiceNo, Stock.Date, Product.ProductName, Stock_Product.Qty, Stock_Product.MRP, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTAmt, Stock_Product.SGSTAmt, Stock_Product.IGSTAmt, Stock_Product.CESSAmt,Stock_Product.DiscountAmt, Stock_Product.TotalAmount, Category.CategoryName FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where Stock.Date >=@d2 and Date < @d3 and ProductName=@d4 order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd2.Parameters.AddWithValue("@d4", Me.cmbProductName.Text)
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
						ModCommonClasses.dtable2 = New DataTable()
						ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
						ModCommonClasses.ds.WriteXmlSchema("PurchaseC2.xml")
						Dim rptPurchaseC As rptPurchaseC2 = New rptPurchaseC2()
						rptPurchaseC.Subreports(0).SetDataSource(ModCommonClasses.ds)
						rptPurchaseC.SetDataSource(ModCommonClasses.ds)
						rptPurchaseC.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptPurchaseC.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptPurchaseC.SetParameterValue("p6", DateAndTime.Today)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchaseC
						MyProject.Forms.frmReport.ShowDialog()
						rptPurchaseC.Close()
						rptPurchaseC.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E87 RID: 73351 RVA: 0x00A51608 File Offset: 0x00A4F808
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Stock LEFT JOIN Supplier ON Stock.SupplierID = Supplier.ID where Stock.Date between @d1 and @d2 and Supplier.Name=@d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Stock.ST_ID, Stock.InvoiceNo, Stock.PurchaseType, Stock.ReferenceNo1, Stock.ReferenceNo2, Stock.Date, Stock.SupplierID, Stock.SupplierInvoiceNo, Stock.SupplierInvoiceDate, Stock.TaxType, Stock.SGST,Stock.CGST, Stock.IGST, Stock.CESS, Stock.SubTotal, Stock.PreviousDue, Stock.FreightCharges, Stock.OtherCharges, Stock.Total, Stock.RoundOff, Stock.GrandTotal, Stock.TotalPayment, Stock.PaymentDue,Stock.Remarks, Stock_Product.SP_ID, Stock_Product.StockID, Stock_Product.ProductID, Stock_Product.Barcode, Stock_Product.Qty, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTPer, Stock_Product.CGSTAmt,Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt, Stock_Product.DiscountPer, Stock_Product.DiscountAmt,Stock_Product.TotalAmount, Supplier.ID, Supplier.SupplierID AS Expr1, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID,Supplier.Remarks AS Expr2, Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.GSTIN, Supplier.PAN, Supplier.CIN, Supplier.OpeningBalanceType,Supplier.OpeningBalance, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice,Product.Discount, Product.CGST AS Expr3, Product.SGST AS Expr4, Product.CESS AS Expr5, Product.Barcode AS Expr6, Product.ReorderPoint, Product.OpeningStock, Product.PurchaseUnit,Product.SalesUnit FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Supplier.Name=@d3 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(Date)) AS Year, SUM(GrandTotal) AS GrandTotal FROM Stock where date between @d3 and @d4 GROUP BY YEAR(Date) ORDER BY Year", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("Purchase.xml")
					Dim rptPurchase As rptPurchase = New rptPurchase()
					rptPurchase.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptPurchase.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptPurchase.SetParameterValue("p6", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchase
					MyProject.Forms.frmReport.ShowDialog()
					rptPurchase.Close()
					rptPurchase.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E88 RID: 73352 RVA: 0x00A51A24 File Offset: 0x00A4FC24
		Private Sub GelButton1_Click_1(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Stock LEFT JOIN Supplier ON Stock.SupplierID = Supplier.ID where Stock.Date between @d1 and @d2 and Stock.TaxType=@d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Stock.ST_ID, Stock.InvoiceNo, Stock.PurchaseType, Stock.ReferenceNo1, Stock.ReferenceNo2, Stock.Date, Stock.SupplierID, Stock.SupplierInvoiceNo, Stock.SupplierInvoiceDate, Stock.TaxType, Stock.SGST,Stock.CGST, Stock.IGST, Stock.CESS, Stock.SubTotal, Stock.PreviousDue, Stock.FreightCharges, Stock.OtherCharges, Stock.Total, Stock.RoundOff, Stock.GrandTotal, Stock.TotalPayment, Stock.PaymentDue,Stock.Remarks, Stock_Product.SP_ID, Stock_Product.StockID, Stock_Product.ProductID, Stock_Product.Barcode, Stock_Product.Qty, (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)) as Price, Stock_Product.CGSTPer, Stock_Product.CGSTAmt,Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt, Stock_Product.DiscountPer, Stock_Product.DiscountAmt,Stock_Product.TotalAmount, Supplier.ID, Supplier.SupplierID AS Expr1, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID,Supplier.Remarks AS Expr2, Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.GSTIN, Supplier.PAN, Supplier.CIN, Supplier.OpeningBalanceType,Supplier.OpeningBalance, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice,Product.Discount, Product.CGST AS Expr3, Product.SGST AS Expr4, Product.CESS AS Expr5, Product.Barcode AS Expr6, Product.ReorderPoint, Product.OpeningStock, Product.PurchaseUnit,Product.SalesUnit FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.TaxType=@d3 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(Date)) AS Year, SUM(GrandTotal) AS GrandTotal FROM Stock where date between @d3 and @d4 GROUP BY YEAR(Date) ORDER BY Year", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("Purchase.xml")
					Dim rptPurchase As rptPurchase = New rptPurchase()
					rptPurchase.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetDataSource(ModCommonClasses.ds)
					rptPurchase.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptPurchase.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptPurchase.SetParameterValue("p6", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchase
					MyProject.Forms.frmReport.ShowDialog()
					rptPurchase.Close()
					rptPurchase.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
