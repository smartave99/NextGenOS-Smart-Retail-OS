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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001AD RID: 429
	<DesignerGenerated()>
	Public Partial Class frmPostImport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600652F RID: 25903 RVA: 0x00033C04 File Offset: 0x00031E04
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPostImport_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002565 RID: 9573
		' (get) Token: 0x06006532 RID: 25906 RVA: 0x00033C24 File Offset: 0x00031E24
		' (set) Token: 0x06006533 RID: 25907 RVA: 0x00033C2E File Offset: 0x00031E2E
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17002566 RID: 9574
		' (get) Token: 0x06006534 RID: 25908 RVA: 0x00033C37 File Offset: 0x00031E37
		' (set) Token: 0x06006535 RID: 25909 RVA: 0x0049A0C4 File Offset: 0x004982C4
		Private _Button17 As GelButton
		Friend Overridable Property Button17 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button17_Click
				Dim gelButton As GelButton = Me._Button17
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button17 = value
				gelButton = Me._Button17
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002567 RID: 9575
		' (get) Token: 0x06006536 RID: 25910 RVA: 0x00033C41 File Offset: 0x00031E41
		' (set) Token: 0x06006537 RID: 25911 RVA: 0x0049A108 File Offset: 0x00498308
		Private _btnCategory As GelButton
		Friend Overridable Property btnCategory As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCategory_Click
				Dim gelButton As GelButton = Me._btnCategory
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCategory = value
				gelButton = Me._btnCategory
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002568 RID: 9576
		' (get) Token: 0x06006538 RID: 25912 RVA: 0x00033C4B File Offset: 0x00031E4B
		' (set) Token: 0x06006539 RID: 25913 RVA: 0x0049A14C File Offset: 0x0049834C
		Private _btnSupplierOs As GelButton
		Friend Overridable Property btnSupplierOs As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSupplierOs
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSupplierOs_Click
				Dim gelButton As GelButton = Me._btnSupplierOs
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSupplierOs = value
				gelButton = Me._btnSupplierOs
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002569 RID: 9577
		' (get) Token: 0x0600653A RID: 25914 RVA: 0x00033C55 File Offset: 0x00031E55
		' (set) Token: 0x0600653B RID: 25915 RVA: 0x0049A190 File Offset: 0x00498390
		Private _btnProduct As GelButton
		Friend Overridable Property btnProduct As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnProduct_Click
				Dim gelButton As GelButton = Me._btnProduct
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnProduct = value
				gelButton = Me._btnProduct
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700256A RID: 9578
		' (get) Token: 0x0600653C RID: 25916 RVA: 0x00033C5F File Offset: 0x00031E5F
		' (set) Token: 0x0600653D RID: 25917 RVA: 0x0049A1D4 File Offset: 0x004983D4
		Private _btnSubCat As GelButton
		Friend Overridable Property btnSubCat As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSubCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSubCat_Click
				Dim gelButton As GelButton = Me._btnSubCat
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSubCat = value
				gelButton = Me._btnSubCat
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700256B RID: 9579
		' (get) Token: 0x0600653E RID: 25918 RVA: 0x00033C69 File Offset: 0x00031E69
		' (set) Token: 0x0600653F RID: 25919 RVA: 0x0049A218 File Offset: 0x00498418
		Private _btnSupplier As GelButton
		Friend Overridable Property btnSupplier As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSupplier
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSupplier_Click
				Dim gelButton As GelButton = Me._btnSupplier
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSupplier = value
				gelButton = Me._btnSupplier
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700256C RID: 9580
		' (get) Token: 0x06006540 RID: 25920 RVA: 0x00033C73 File Offset: 0x00031E73
		' (set) Token: 0x06006541 RID: 25921 RVA: 0x0049A25C File Offset: 0x0049845C
		Private _btnCustomers As GelButton
		Friend Overridable Property btnCustomers As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCustomers
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCustomers_Click
				Dim gelButton As GelButton = Me._btnCustomers
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCustomers = value
				gelButton = Me._btnCustomers
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700256D RID: 9581
		' (get) Token: 0x06006542 RID: 25922 RVA: 0x00033C7D File Offset: 0x00031E7D
		' (set) Token: 0x06006543 RID: 25923 RVA: 0x0049A2A0 File Offset: 0x004984A0
		Private _btnCustomerOs As GelButton
		Friend Overridable Property btnCustomerOs As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCustomerOs
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCustomerOs_Click
				Dim gelButton As GelButton = Me._btnCustomerOs
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCustomerOs = value
				gelButton = Me._btnCustomerOs
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700256E RID: 9582
		' (get) Token: 0x06006544 RID: 25924 RVA: 0x00033C87 File Offset: 0x00031E87
		' (set) Token: 0x06006545 RID: 25925 RVA: 0x00033C91 File Offset: 0x00031E91
		Friend Overridable Property lblUser As Label

		' Token: 0x1700256F RID: 9583
		' (get) Token: 0x06006546 RID: 25926 RVA: 0x00033C9A File Offset: 0x00031E9A
		' (set) Token: 0x06006547 RID: 25927 RVA: 0x00033CA4 File Offset: 0x00031EA4
		Friend Overridable Property Label1 As Label

		' Token: 0x06006548 RID: 25928 RVA: 0x0049A2E4 File Offset: 0x004984E4
		Private Sub btnCategory_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Reset()
			MyProject.Forms.frmCategory.ShowDialog()
			MyProject.Forms.frmCategory.Dispose()
		End Sub

		' Token: 0x06006549 RID: 25929 RVA: 0x0049A344 File Offset: 0x00498544
		Private Sub btnSubCat_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Reset()
			MyProject.Forms.frmSubCategory.ShowDialog()
			MyProject.Forms.frmSubCategory.Dispose()
		End Sub

		' Token: 0x0600654A RID: 25930 RVA: 0x00033CAD File Offset: 0x00031EAD
		Private Sub btnCustomers_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmExportImportExcel_Customers.Reset()
			MyProject.Forms.frmExportImportExcel_Customers.ShowDialog()
		End Sub

		' Token: 0x0600654B RID: 25931 RVA: 0x00033CD0 File Offset: 0x00031ED0
		Private Sub btnSupplier_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmExportImportExcel_Suppliers.Reset()
			MyProject.Forms.frmExportImportExcel_Suppliers.ShowDialog()
		End Sub

		' Token: 0x0600654C RID: 25932 RVA: 0x00033CF3 File Offset: 0x00031EF3
		Private Sub btnProduct_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmExportImportExcel_ProductsRecord.Reset()
			MyProject.Forms.frmExportImportExcel_ProductsRecord.ShowDialog()
		End Sub

		' Token: 0x0600654D RID: 25933 RVA: 0x00033D16 File Offset: 0x00031F16
		Private Sub btnCustomerOs_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerOutstanding.ShowDialog()
			MyProject.Forms.frmCustomerOutstanding.Dispose()
		End Sub

		' Token: 0x0600654E RID: 25934 RVA: 0x00033D39 File Offset: 0x00031F39
		Private Sub btnSupplierOs_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierOutstanding.ShowDialog()
			MyProject.Forms.frmSupplierOutstanding.Dispose()
		End Sub

		' Token: 0x0600654F RID: 25935 RVA: 0x0049A3A4 File Offset: 0x004985A4
		Private Sub Button17_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.lblSet.Text = ""
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.ShowDialog()
			MyProject.Forms.frmCurrentStock.Dispose()
		End Sub

		' Token: 0x06006550 RID: 25936 RVA: 0x00033D5C File Offset: 0x00031F5C
		Private Sub frmPostImport_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x06006551 RID: 25937 RVA: 0x0049A40C File Offset: 0x0049860C
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

		' Token: 0x06006552 RID: 25938 RVA: 0x0049A584 File Offset: 0x00498784
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

		' Token: 0x06006553 RID: 25939 RVA: 0x0049A640 File Offset: 0x00498840
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

		' Token: 0x06006554 RID: 25940 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06006555 RID: 25941 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06006556 RID: 25942 RVA: 0x00087088 File Offset: 0x00085288
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
	End Class
End Namespace
