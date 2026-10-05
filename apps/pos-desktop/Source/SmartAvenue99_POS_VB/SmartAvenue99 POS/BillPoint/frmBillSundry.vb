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
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004AD RID: 1197
	<DesignerGenerated()>
	Public Partial Class frmBillSundry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EFE1 RID: 61409 RVA: 0x00069012 File Offset: 0x00067212
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBillSundry_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBillSundry_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005BFA RID: 23546
		' (get) Token: 0x0600EFE4 RID: 61412 RVA: 0x00069044 File Offset: 0x00067244
		' (set) Token: 0x0600EFE5 RID: 61413 RVA: 0x0006904E File Offset: 0x0006724E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005BFB RID: 23547
		' (get) Token: 0x0600EFE6 RID: 61414 RVA: 0x00069057 File Offset: 0x00067257
		' (set) Token: 0x0600EFE7 RID: 61415 RVA: 0x00903410 File Offset: 0x00901610
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

		' Token: 0x17005BFC RID: 23548
		' (get) Token: 0x0600EFE8 RID: 61416 RVA: 0x00069061 File Offset: 0x00067261
		' (set) Token: 0x0600EFE9 RID: 61417 RVA: 0x0006906B File Offset: 0x0006726B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005BFD RID: 23549
		' (get) Token: 0x0600EFEA RID: 61418 RVA: 0x00069074 File Offset: 0x00067274
		' (set) Token: 0x0600EFEB RID: 61419 RVA: 0x0006907E File Offset: 0x0006727E
		Friend Overridable Property txtU As TextBox

		' Token: 0x17005BFE RID: 23550
		' (get) Token: 0x0600EFEC RID: 61420 RVA: 0x00069087 File Offset: 0x00067287
		' (set) Token: 0x0600EFED RID: 61421 RVA: 0x00069091 File Offset: 0x00067291
		Friend Overridable Property Label1 As Label

		' Token: 0x17005BFF RID: 23551
		' (get) Token: 0x0600EFEE RID: 61422 RVA: 0x0006909A File Offset: 0x0006729A
		' (set) Token: 0x0600EFEF RID: 61423 RVA: 0x000690A4 File Offset: 0x000672A4
		Friend Overridable Property lblUser As Label

		' Token: 0x17005C00 RID: 23552
		' (get) Token: 0x0600EFF0 RID: 61424 RVA: 0x000690AD File Offset: 0x000672AD
		' (set) Token: 0x0600EFF1 RID: 61425 RVA: 0x000690B7 File Offset: 0x000672B7
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x17005C01 RID: 23553
		' (get) Token: 0x0600EFF2 RID: 61426 RVA: 0x000690C0 File Offset: 0x000672C0
		' (set) Token: 0x0600EFF3 RID: 61427 RVA: 0x00903470 File Offset: 0x00901670
		Private _cmbBS As ComboBox
		Friend Overridable Property cmbBS As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbBS
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbBS_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbBS
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbBS = value
				comboBox = Me._cmbBS
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C02 RID: 23554
		' (get) Token: 0x0600EFF4 RID: 61428 RVA: 0x000690CA File Offset: 0x000672CA
		' (set) Token: 0x0600EFF5 RID: 61429 RVA: 0x000690D4 File Offset: 0x000672D4
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005C03 RID: 23555
		' (get) Token: 0x0600EFF6 RID: 61430 RVA: 0x000690DD File Offset: 0x000672DD
		' (set) Token: 0x0600EFF7 RID: 61431 RVA: 0x000690E7 File Offset: 0x000672E7
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005C04 RID: 23556
		' (get) Token: 0x0600EFF8 RID: 61432 RVA: 0x000690F0 File Offset: 0x000672F0
		' (set) Token: 0x0600EFF9 RID: 61433 RVA: 0x009034D0 File Offset: 0x009016D0
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

		' Token: 0x17005C05 RID: 23557
		' (get) Token: 0x0600EFFA RID: 61434 RVA: 0x000690FA File Offset: 0x000672FA
		' (set) Token: 0x0600EFFB RID: 61435 RVA: 0x00903514 File Offset: 0x00901714
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

		' Token: 0x17005C06 RID: 23558
		' (get) Token: 0x0600EFFC RID: 61436 RVA: 0x00069104 File Offset: 0x00067304
		' (set) Token: 0x0600EFFD RID: 61437 RVA: 0x00903558 File Offset: 0x00901758
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

		' Token: 0x17005C07 RID: 23559
		' (get) Token: 0x0600EFFE RID: 61438 RVA: 0x0006910E File Offset: 0x0006730E
		' (set) Token: 0x0600EFFF RID: 61439 RVA: 0x0090359C File Offset: 0x0090179C
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

		' Token: 0x17005C08 RID: 23560
		' (get) Token: 0x0600F000 RID: 61440 RVA: 0x00069118 File Offset: 0x00067318
		' (set) Token: 0x0600F001 RID: 61441 RVA: 0x00069122 File Offset: 0x00067322
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x0600F002 RID: 61442 RVA: 0x009035E0 File Offset: 0x009017E0
		Public Sub Reset()
			Me.cmbBS.Text = ""
			Me.cmbBS.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.cmbBS.Focus()
			Me.Getdata()
			Me.fillBillSundry()
		End Sub

		' Token: 0x0600F003 RID: 61443 RVA: 0x00903650 File Offset: 0x00901850
		Public Sub fillBillSundry()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Head) FROM BillSundry", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbBS.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbBS.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F004 RID: 61444 RVA: 0x00903784 File Offset: 0x00901984
		Private Sub DeleteRecord()
			Dim flag As Boolean = Operators.CompareString(Me.txtU.Text, "TCS", False) = 0
			If flag Then
				MessageBox.Show("'TCS' head is not allowed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtU.Text, "TDS", False) = 0
				If flag2 Then
					MessageBox.Show("'TDS' head is not allowed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select Head from BillSundry,InvoiceInfo where BillSundry.Head=InvoiceInfo.BillSundry and Head=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Unable to delete..Already in use in Sale Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select Head from BillSundry,Stock where BillSundry.Head=Stock.BillSundry and Head=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select Head from BillSundry,SalesReturn where BillSundry.Head=SalesReturn.BillSundry and Head=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
								If flag7 Then
									MessageBox.Show("Unable to delete..Already in use in Sales Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag8 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "select Head from BillSundry,PurchaseReturn where BillSundry.Head=PurchaseReturn.BillSundry and Head=@d1"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
									If flag9 Then
										MessageBox.Show("Unable to delete..Already in use in Purchase Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text5 As String = "delete from BillSundry where Head=@d1"
										ModCommonClasses.cmd = New SqlCommand(text5)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
										Dim flag11 As Boolean = num > 0
										If flag11 Then
											ModFunc.LogFunc(Me.lblUser.Text, "deleted the Bill Sundry Head '" + Me.cmbBS.Text + "'")
											MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.Getdata()
											Me.Reset()
										Else
											MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.Reset()
										End If
										Dim flag12 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
										If flag12 Then
											ModCommonClasses.con.Close()
										End If
									End If
								End If
							End If
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600F005 RID: 61445 RVA: 0x00903C2C File Offset: 0x00901E2C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.cmbBS.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtU.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F006 RID: 61446 RVA: 0x00903CF4 File Offset: 0x00901EF4
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

		' Token: 0x0600F007 RID: 61447 RVA: 0x00903DDC File Offset: 0x00901FDC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Head) from BillSundry order by Head", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F008 RID: 61448 RVA: 0x00903EC0 File Offset: 0x009020C0
		Private Sub frmBillSundry_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.fillBillSundry()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F009 RID: 61449 RVA: 0x00903F50 File Offset: 0x00902150
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

		' Token: 0x0600F00A RID: 61450 RVA: 0x009041F0 File Offset: 0x009023F0
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

		' Token: 0x0600F00B RID: 61451 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F00C RID: 61452 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbBS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F00D RID: 61453 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBillSundry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F00E RID: 61454 RVA: 0x009042A4 File Offset: 0x009024A4
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbBS.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbBS, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbBS, String.Empty)
			End If
		End Sub

		' Token: 0x0600F00F RID: 61455 RVA: 0x0006912B File Offset: 0x0006732B
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F010 RID: 61456 RVA: 0x00904300 File Offset: 0x00902500
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
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbBS.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please Bill Sundry Head", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbBS.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select Head from BillSundry where Head=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Head Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbBS.Text = ""
							Me.cmbBS.Focus()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into BillSundry(Head) VALUES (@d1)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "added the new Bill Sundry Head '" + Me.cmbBS.Text + "'")
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
							Me.fillBillSundry()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600F011 RID: 61457 RVA: 0x009045C8 File Offset: 0x009027C8
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbBS.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please Bill Sundry Head", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbBS.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtU.Text, "TCS", False) = 0
				If flag2 Then
					MessageBox.Show("'TCS' head is not allowed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtU.Text, "TDS", False) = 0
					If flag3 Then
						MessageBox.Show("'TDS' head is not allowed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "update InvoiceInfo set BillSundry=@d1 where BillSundry=@d2"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "update Stock set BillSundry=@d1 where BillSundry=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "update SalesReturn set BillSundry=@d1 where BillSundry=@d2"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "update PurchaseReturn set BillSundry=@d1 where BillSundry=@d2"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text5 As String = "Update BillSundry set Head=@d1 where Head=@d2"
							ModCommonClasses.cmd = New SqlCommand(text5)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbBS.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtU.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModFunc.LogFunc(Me.lblUser.Text, "updated the Bill Sundry Head '" + Me.cmbBS.Text + "'")
							MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							Me.Getdata()
							ModFunc.RefreshRecords()
							Me.fillBillSundry()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F012 RID: 61458 RVA: 0x009049FC File Offset: 0x00902BFC
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
	End Class
End Namespace
