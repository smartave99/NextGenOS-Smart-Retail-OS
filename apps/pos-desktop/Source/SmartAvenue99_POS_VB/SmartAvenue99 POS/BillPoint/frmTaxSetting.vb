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
	' Token: 0x0200058A RID: 1418
	<DesignerGenerated()>
	Public Partial Class frmTaxSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601133E RID: 70462 RVA: 0x009FAFC0 File Offset: 0x009F91C0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurchaseSettingName_Load_1
			AddHandler MyBase.Closing, AddressOf Me.frmTaxSetting_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmTaxSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006AB1 RID: 27313
		' (get) Token: 0x06011341 RID: 70465 RVA: 0x000764AC File Offset: 0x000746AC
		' (set) Token: 0x06011342 RID: 70466 RVA: 0x000764B6 File Offset: 0x000746B6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006AB2 RID: 27314
		' (get) Token: 0x06011343 RID: 70467 RVA: 0x000764BF File Offset: 0x000746BF
		' (set) Token: 0x06011344 RID: 70468 RVA: 0x009FC350 File Offset: 0x009FA550
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AB3 RID: 27315
		' (get) Token: 0x06011345 RID: 70469 RVA: 0x000764C9 File Offset: 0x000746C9
		' (set) Token: 0x06011346 RID: 70470 RVA: 0x000764D3 File Offset: 0x000746D3
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006AB4 RID: 27316
		' (get) Token: 0x06011347 RID: 70471 RVA: 0x000764DC File Offset: 0x000746DC
		' (set) Token: 0x06011348 RID: 70472 RVA: 0x000764E6 File Offset: 0x000746E6
		Friend Overridable Property Label1 As Label

		' Token: 0x17006AB5 RID: 27317
		' (get) Token: 0x06011349 RID: 70473 RVA: 0x000764EF File Offset: 0x000746EF
		' (set) Token: 0x0601134A RID: 70474 RVA: 0x000764F9 File Offset: 0x000746F9
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006AB6 RID: 27318
		' (get) Token: 0x0601134B RID: 70475 RVA: 0x00076502 File Offset: 0x00074702
		' (set) Token: 0x0601134C RID: 70476 RVA: 0x0007650C File Offset: 0x0007470C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006AB7 RID: 27319
		' (get) Token: 0x0601134D RID: 70477 RVA: 0x00076515 File Offset: 0x00074715
		' (set) Token: 0x0601134E RID: 70478 RVA: 0x009FC394 File Offset: 0x009FA594
		Private _cmbPurchaseTax As ComboBox
		Friend Overridable Property cmbPurchaseTax As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPurchaseTax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPurchaseTax
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPurchaseTax = value
				comboBox = Me._cmbPurchaseTax
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AB8 RID: 27320
		' (get) Token: 0x0601134F RID: 70479 RVA: 0x0007651F File Offset: 0x0007471F
		' (set) Token: 0x06011350 RID: 70480 RVA: 0x009FC3D8 File Offset: 0x009FA5D8
		Private _cmbSalesTax As ComboBox
		Friend Overridable Property cmbSalesTax As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSalesTax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSalesTax
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSalesTax = value
				comboBox = Me._cmbSalesTax
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AB9 RID: 27321
		' (get) Token: 0x06011351 RID: 70481 RVA: 0x00076529 File Offset: 0x00074729
		' (set) Token: 0x06011352 RID: 70482 RVA: 0x00076533 File Offset: 0x00074733
		Friend Overridable Property Label3 As Label

		' Token: 0x17006ABA RID: 27322
		' (get) Token: 0x06011353 RID: 70483 RVA: 0x0007653C File Offset: 0x0007473C
		' (set) Token: 0x06011354 RID: 70484 RVA: 0x00076546 File Offset: 0x00074746
		Friend Overridable Property Label2 As Label

		' Token: 0x17006ABB RID: 27323
		' (get) Token: 0x06011355 RID: 70485 RVA: 0x0007654F File Offset: 0x0007474F
		' (set) Token: 0x06011356 RID: 70486 RVA: 0x00076559 File Offset: 0x00074759
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006ABC RID: 27324
		' (get) Token: 0x06011357 RID: 70487 RVA: 0x00076562 File Offset: 0x00074762
		' (set) Token: 0x06011358 RID: 70488 RVA: 0x0007656C File Offset: 0x0007476C
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x17006ABD RID: 27325
		' (get) Token: 0x06011359 RID: 70489 RVA: 0x00076575 File Offset: 0x00074775
		' (set) Token: 0x0601135A RID: 70490 RVA: 0x0007657F File Offset: 0x0007477F
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006ABE RID: 27326
		' (get) Token: 0x0601135B RID: 70491 RVA: 0x00076588 File Offset: 0x00074788
		' (set) Token: 0x0601135C RID: 70492 RVA: 0x00076592 File Offset: 0x00074792
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006ABF RID: 27327
		' (get) Token: 0x0601135D RID: 70493 RVA: 0x0007659B File Offset: 0x0007479B
		' (set) Token: 0x0601135E RID: 70494 RVA: 0x000765A5 File Offset: 0x000747A5
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006AC0 RID: 27328
		' (get) Token: 0x0601135F RID: 70495 RVA: 0x000765AE File Offset: 0x000747AE
		' (set) Token: 0x06011360 RID: 70496 RVA: 0x009FC41C File Offset: 0x009FA61C
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AC1 RID: 27329
		' (get) Token: 0x06011361 RID: 70497 RVA: 0x000765B8 File Offset: 0x000747B8
		' (set) Token: 0x06011362 RID: 70498 RVA: 0x009FC460 File Offset: 0x009FA660
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AC2 RID: 27330
		' (get) Token: 0x06011363 RID: 70499 RVA: 0x000765C2 File Offset: 0x000747C2
		' (set) Token: 0x06011364 RID: 70500 RVA: 0x009FC4A4 File Offset: 0x009FA6A4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AC3 RID: 27331
		' (get) Token: 0x06011365 RID: 70501 RVA: 0x000765CC File Offset: 0x000747CC
		' (set) Token: 0x06011366 RID: 70502 RVA: 0x009FC4E8 File Offset: 0x009FA6E8
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AC4 RID: 27332
		' (get) Token: 0x06011367 RID: 70503 RVA: 0x000765D6 File Offset: 0x000747D6
		' (set) Token: 0x06011368 RID: 70504 RVA: 0x009FC52C File Offset: 0x009FA72C
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

		' Token: 0x06011369 RID: 70505 RVA: 0x009FC570 File Offset: 0x009FA770
		Public Sub Reset()
			Me.cmbPurchaseTax.SelectedIndex = 0
			Me.cmbSalesTax.SelectedIndex = 0
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
		End Sub

		' Token: 0x0601136A RID: 70506 RVA: 0x009FC5C8 File Offset: 0x009FA7C8
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Setting where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601136B RID: 70507 RVA: 0x009FC6E0 File Offset: 0x009FA8E0
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbPurchaseTax.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.cmbSalesTax.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601136C RID: 70508 RVA: 0x009FC7CC File Offset: 0x009FA9CC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(PurchaseTax),RTRIM(SalesTax) from Setting", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601136D RID: 70509 RVA: 0x009FC8CC File Offset: 0x009FAACC
		Private Sub frmPurchaseSettingName_Load_1(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601136E RID: 70510 RVA: 0x009FC954 File Offset: 0x009FAB54
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0601136F RID: 70511 RVA: 0x009FCBF4 File Offset: 0x009FADF4
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x06011370 RID: 70512 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011371 RID: 70513 RVA: 0x009FCCA8 File Offset: 0x009FAEA8
		Private Sub frmTaxSetting_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(MyProject.Forms.frmPOS.Label1.Text, "SALE", False) = 0
			If flag Then
				MyProject.Forms.frmPOS.GetSalesTaxType()
				MyProject.Forms.frmPOS.auto()
				MyProject.Forms.frmPOS.Compute()
				MyProject.Forms.frmPOS.Clear1()
				MyProject.Forms.frmPOS.caldgv2()
				MyProject.Forms.frmPOS.OPCode2()
				MyProject.Forms.frmPOS.Bankcondn()
			End If
			Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.Text, "POINT OF SALE", False) = 0
			If flag2 Then
				MyProject.Forms.frmPOSTouch.GetSalesTaxType()
				MyProject.Forms.frmPOSTouch.auto()
				MyProject.Forms.frmPOSTouch.Compute()
				MyProject.Forms.frmPOSTouch.Clear1()
				MyProject.Forms.frmPOSTouch.caldgv2()
				MyProject.Forms.frmPOSTouch.OPCode2()
				MyProject.Forms.frmPOSTouch.Bankcondn()
			End If
			Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseEntry.Label1.Text, "PURCHASE", False) = 0
			If flag3 Then
				MyProject.Forms.frmPurchaseEntry.GetPurchaseTaxType()
			End If
		End Sub

		' Token: 0x06011372 RID: 70514 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTaxSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011373 RID: 70515 RVA: 0x009FCE1C File Offset: 0x009FB01C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbSalesTax.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbSalesTax, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSalesTax, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbPurchaseTax.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbPurchaseTax, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPurchaseTax, String.Empty)
			End If
		End Sub

		' Token: 0x06011374 RID: 70516 RVA: 0x000765E0 File Offset: 0x000747E0
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011375 RID: 70517 RVA: 0x009FCEC4 File Offset: 0x009FB0C4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Me.cmbPurchaseTax.SelectedIndex = -1
				If flag3 Then
					MessageBox.Show("Please Purchase Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbPurchaseTax.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbSalesTax.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please Sales Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.cmbSalesTax.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select count(*) from Setting Having count(*) >= 1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the tax setting", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Setting(PurchaseTax,SalesTax) VALUES (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbPurchaseTax.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSalesTax.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Getdata()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06011376 RID: 70518 RVA: 0x009FD16C File Offset: 0x009FB36C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPurchaseTax.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please Purchase Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbPurchaseTax.Focus()
			Else
				Dim flag2 As Boolean = Me.cmbSalesTax.SelectedIndex = -1
				If flag2 Then
					MessageBox.Show("Please Sales Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbSalesTax.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update Setting set PurchaseTax=@d1,SalesTax=@d2 where ID=@d3"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbPurchaseTax.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbSalesTax.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtID.Text)
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						Me.btnDelete.Enabled = False
						Me.Getdata()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06011377 RID: 70519 RVA: 0x009FD304 File Offset: 0x009FB504
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011378 RID: 70520 RVA: 0x000765EA File Offset: 0x000747EA
		Private Sub GelButton1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxSettingsNew.ShowDialog()
		End Sub
	End Class
End Namespace
