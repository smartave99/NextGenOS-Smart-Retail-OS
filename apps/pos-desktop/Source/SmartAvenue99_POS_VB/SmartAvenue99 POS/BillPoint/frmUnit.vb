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
	' Token: 0x0200058B RID: 1419
	<DesignerGenerated()>
	Public Partial Class frmUnit
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011379 RID: 70521 RVA: 0x009FD36C File Offset: 0x009FB56C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmUnitMaster_Load
			AddHandler MyBase.Closing, AddressOf Me.frmUnit_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmUnit_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006AC5 RID: 27333
		' (get) Token: 0x0601137C RID: 70524 RVA: 0x000765FD File Offset: 0x000747FD
		' (set) Token: 0x0601137D RID: 70525 RVA: 0x00076607 File Offset: 0x00074807
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006AC6 RID: 27334
		' (get) Token: 0x0601137E RID: 70526 RVA: 0x00076610 File Offset: 0x00074810
		' (set) Token: 0x0601137F RID: 70527 RVA: 0x009FE7C0 File Offset: 0x009FC9C0
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
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006AC7 RID: 27335
		' (get) Token: 0x06011380 RID: 70528 RVA: 0x0007661A File Offset: 0x0007481A
		' (set) Token: 0x06011381 RID: 70529 RVA: 0x00076624 File Offset: 0x00074824
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006AC8 RID: 27336
		' (get) Token: 0x06011382 RID: 70530 RVA: 0x0007662D File Offset: 0x0007482D
		' (set) Token: 0x06011383 RID: 70531 RVA: 0x00076637 File Offset: 0x00074837
		Friend Overridable Property Label1 As Label

		' Token: 0x17006AC9 RID: 27337
		' (get) Token: 0x06011384 RID: 70532 RVA: 0x00076640 File Offset: 0x00074840
		' (set) Token: 0x06011385 RID: 70533 RVA: 0x0007664A File Offset: 0x0007484A
		Friend Overridable Property txtU As TextBox

		' Token: 0x17006ACA RID: 27338
		' (get) Token: 0x06011386 RID: 70534 RVA: 0x00076653 File Offset: 0x00074853
		' (set) Token: 0x06011387 RID: 70535 RVA: 0x0007665D File Offset: 0x0007485D
		Friend Overridable Property lblUser As Label

		' Token: 0x17006ACB RID: 27339
		' (get) Token: 0x06011388 RID: 70536 RVA: 0x00076666 File Offset: 0x00074866
		' (set) Token: 0x06011389 RID: 70537 RVA: 0x009FE820 File Offset: 0x009FCA20
		Private _cmbUnit As ComboBox
		Friend Overridable Property cmbUnit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbUnit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbUnit = value
				comboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006ACC RID: 27340
		' (get) Token: 0x0601138A RID: 70538 RVA: 0x00076670 File Offset: 0x00074870
		' (set) Token: 0x0601138B RID: 70539 RVA: 0x0007667A File Offset: 0x0007487A
		Friend Overridable Property Label2 As Label

		' Token: 0x17006ACD RID: 27341
		' (get) Token: 0x0601138C RID: 70540 RVA: 0x00076683 File Offset: 0x00074883
		' (set) Token: 0x0601138D RID: 70541 RVA: 0x009FE880 File Offset: 0x009FCA80
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006ACE RID: 27342
		' (get) Token: 0x0601138E RID: 70542 RVA: 0x0007668D File Offset: 0x0007488D
		' (set) Token: 0x0601138F RID: 70543 RVA: 0x00076697 File Offset: 0x00074897
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006ACF RID: 27343
		' (get) Token: 0x06011390 RID: 70544 RVA: 0x000766A0 File Offset: 0x000748A0
		' (set) Token: 0x06011391 RID: 70545 RVA: 0x000766AA File Offset: 0x000748AA
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006AD0 RID: 27344
		' (get) Token: 0x06011392 RID: 70546 RVA: 0x000766B3 File Offset: 0x000748B3
		' (set) Token: 0x06011393 RID: 70547 RVA: 0x009FE8E0 File Offset: 0x009FCAE0
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
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

		' Token: 0x17006AD1 RID: 27345
		' (get) Token: 0x06011394 RID: 70548 RVA: 0x000766BD File Offset: 0x000748BD
		' (set) Token: 0x06011395 RID: 70549 RVA: 0x009FE924 File Offset: 0x009FCB24
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
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

		' Token: 0x17006AD2 RID: 27346
		' (get) Token: 0x06011396 RID: 70550 RVA: 0x000766C7 File Offset: 0x000748C7
		' (set) Token: 0x06011397 RID: 70551 RVA: 0x009FE968 File Offset: 0x009FCB68
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

		' Token: 0x17006AD3 RID: 27347
		' (get) Token: 0x06011398 RID: 70552 RVA: 0x000766D1 File Offset: 0x000748D1
		' (set) Token: 0x06011399 RID: 70553 RVA: 0x009FE9AC File Offset: 0x009FCBAC
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

		' Token: 0x17006AD4 RID: 27348
		' (get) Token: 0x0601139A RID: 70554 RVA: 0x000766DB File Offset: 0x000748DB
		' (set) Token: 0x0601139B RID: 70555 RVA: 0x000766E5 File Offset: 0x000748E5
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006AD5 RID: 27349
		' (get) Token: 0x0601139C RID: 70556 RVA: 0x000766EE File Offset: 0x000748EE
		' (set) Token: 0x0601139D RID: 70557 RVA: 0x000766F8 File Offset: 0x000748F8
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x17006AD6 RID: 27350
		' (get) Token: 0x0601139E RID: 70558 RVA: 0x00076701 File Offset: 0x00074901
		' (set) Token: 0x0601139F RID: 70559 RVA: 0x0007670B File Offset: 0x0007490B
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17006AD7 RID: 27351
		' (get) Token: 0x060113A0 RID: 70560 RVA: 0x00076714 File Offset: 0x00074914
		' (set) Token: 0x060113A1 RID: 70561 RVA: 0x0007671E File Offset: 0x0007491E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006AD8 RID: 27352
		' (get) Token: 0x060113A2 RID: 70562 RVA: 0x00076727 File Offset: 0x00074927
		' (set) Token: 0x060113A3 RID: 70563 RVA: 0x00076731 File Offset: 0x00074931
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006AD9 RID: 27353
		' (get) Token: 0x060113A4 RID: 70564 RVA: 0x0007673A File Offset: 0x0007493A
		' (set) Token: 0x060113A5 RID: 70565 RVA: 0x00076744 File Offset: 0x00074944
		Friend Overridable Property IsDefault As DataGridViewTextBoxColumn

		' Token: 0x17006ADA RID: 27354
		' (get) Token: 0x060113A6 RID: 70566 RVA: 0x0007674D File Offset: 0x0007494D
		' (set) Token: 0x060113A7 RID: 70567 RVA: 0x009FE9F0 File Offset: 0x009FCBF0
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

		' Token: 0x060113A8 RID: 70568 RVA: 0x009FEA34 File Offset: 0x009FCC34
		Public Sub Reset()
			Me.cmbUnit.Text = ""
			Me.TextBox1.Text = ""
			Me.cmbUnit.SelectedIndex = -1
			Me.CheckBox1.Checked = False
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
			Me.fillUnitName()
			Me.cmbUnit.Focus()
		End Sub

		' Token: 0x060113A9 RID: 70569 RVA: 0x009FEAC0 File Offset: 0x009FCCC0
		Public Sub fillUnitName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbUnit.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbUnit.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060113AA RID: 70570 RVA: 0x009FEBF4 File Offset: 0x009FCDF4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select Unit from UnitMaster,Product where UnitMaster.Unit=Product.PurchaseUnit and Unit=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select Unit from UnitMaster,Product where UnitMaster.Unit=Product.SalesUnit and Unit=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "delete from UnitMaster where Unit=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
							ModFunc.LogFunc(Me.lblUser.Text, "deleted the Unit '" + Me.cmbUnit.Text + "'")
							MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Getdata()
							Me.Reset()
						Else
							MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
						End If
						Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag6 Then
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060113AB RID: 70571 RVA: 0x009FEEB8 File Offset: 0x009FD0B8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.cmbUnit.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtU.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060113AC RID: 70572 RVA: 0x009FEFA4 File Offset: 0x009FD1A4
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x060113AD RID: 70573 RVA: 0x009FF08C File Offset: 0x009FD28C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Unit),RTRIM(Description), IsDefault from UnitMaster order by IsDefault desc", ModCommonClasses.con)
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

		' Token: 0x060113AE RID: 70574 RVA: 0x009FF18C File Offset: 0x009FD38C
		Private Sub frmUnitMaster_Load(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060113AF RID: 70575 RVA: 0x009FF214 File Offset: 0x009FD414
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

		' Token: 0x060113B0 RID: 70576 RVA: 0x009FF4B4 File Offset: 0x009FD6B4
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

		' Token: 0x060113B1 RID: 70577 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060113B2 RID: 70578 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060113B3 RID: 70579 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060113B4 RID: 70580 RVA: 0x00076757 File Offset: 0x00074957
		Private Sub frmUnit_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmProduct.fillUnit()
		End Sub

		' Token: 0x060113B5 RID: 70581 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060113B6 RID: 70582 RVA: 0x009FF568 File Offset: 0x009FD768
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbUnit.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbUnit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbUnit, String.Empty)
			End If
		End Sub

		' Token: 0x060113B7 RID: 70583 RVA: 0x0007676A File Offset: 0x0007496A
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060113B8 RID: 70584 RVA: 0x009FF610 File Offset: 0x009FD810
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
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbUnit.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter Unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbUnit.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter Description", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox1.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select Unit from UnitMaster where Unit=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Unit Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.cmbUnit.Text = ""
								Me.cmbUnit.Focus()
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Dim checked As Boolean = Me.CheckBox1.Checked
								If checked Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "select IsDefault from UnitMaster where IsDefault='Yes'"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
									If flag7 Then
										MessageBox.Show("Unit is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag8 Then
											ModCommonClasses.rdr.Close()
										End If
										Return
									End If
								End If
								Dim checked2 As Boolean = Me.CheckBox1.Checked
								If checked2 Then
									Me.st2 = "Yes"
								Else
									Me.st2 = "No"
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "insert into UnitMaster(Unit,Description,IsDefault) VALUES (@d1,@d2,@d3)"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModFunc.LogFunc(Me.lblUser.Text, "added the new Unit '" + Me.cmbUnit.Text + "'")
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Getdata()
								Me.fillUnitName()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060113B9 RID: 70585 RVA: 0x009FFA28 File Offset: 0x009FDC28
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbUnit.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter Unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbUnit.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter Description", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox1.Focus()
				Else
					Try
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select IsDefault from UnitMaster where IsDefault='Yes'"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
							If flag3 Then
								MessageBox.Show("Unit is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag4 Then
									ModCommonClasses.rdr.Close()
								End If
								Return
							End If
						End If
						Dim checked2 As Boolean = Me.CheckBox1.Checked
						If checked2 Then
							Me.st2 = "Yes"
						Else
							Me.st2 = "No"
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "update Product set PurchaseUnit=@d1 where PurchaseUnit=@d2"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "update Product set SalesUnit=@d1 where SalesUnit=@d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text4 As String = "Update UnitMaster set Unit=@d1,Description=@d3, IsDefault=@d4 where Unit=@d2"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUnit.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st2)
						ModCommonClasses.cmd.ExecuteReader()
						ModFunc.LogFunc(Me.lblUser.Text, "updated the Unit '" + Me.cmbUnit.Text + "'")
						MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						Me.Getdata()
						ModFunc.RefreshRecords()
						Me.fillUnitName()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x060113BA RID: 70586 RVA: 0x009FFE18 File Offset: 0x009FE018
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060113BB RID: 70587 RVA: 0x00076774 File Offset: 0x00074974
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUnitMasterNew.ShowDialog()
		End Sub

		' Token: 0x040067A7 RID: 26535
		Private st2 As String
	End Class
End Namespace
