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
	' Token: 0x020004D8 RID: 1240
	<DesignerGenerated()>
	Public Partial Class frmRoute
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FC83 RID: 64643 RVA: 0x0006EB6A File Offset: 0x0006CD6A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRoute_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmRoute_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006095 RID: 24725
		' (get) Token: 0x0600FC86 RID: 64646 RVA: 0x0006EB9C File Offset: 0x0006CD9C
		' (set) Token: 0x0600FC87 RID: 64647 RVA: 0x0006EBA6 File Offset: 0x0006CDA6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006096 RID: 24726
		' (get) Token: 0x0600FC88 RID: 64648 RVA: 0x0006EBAF File Offset: 0x0006CDAF
		' (set) Token: 0x0600FC89 RID: 64649 RVA: 0x00972140 File Offset: 0x00970340
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006097 RID: 24727
		' (get) Token: 0x0600FC8A RID: 64650 RVA: 0x0006EBB9 File Offset: 0x0006CDB9
		' (set) Token: 0x0600FC8B RID: 64651 RVA: 0x009721A0 File Offset: 0x009703A0
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

		' Token: 0x17006098 RID: 24728
		' (get) Token: 0x0600FC8C RID: 64652 RVA: 0x0006EBC3 File Offset: 0x0006CDC3
		' (set) Token: 0x0600FC8D RID: 64653 RVA: 0x0006EBCD File Offset: 0x0006CDCD
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006099 RID: 24729
		' (get) Token: 0x0600FC8E RID: 64654 RVA: 0x0006EBD6 File Offset: 0x0006CDD6
		' (set) Token: 0x0600FC8F RID: 64655 RVA: 0x0006EBE0 File Offset: 0x0006CDE0
		Friend Overridable Property txtCategoryName As TextBox

		' Token: 0x1700609A RID: 24730
		' (get) Token: 0x0600FC90 RID: 64656 RVA: 0x0006EBE9 File Offset: 0x0006CDE9
		' (set) Token: 0x0600FC91 RID: 64657 RVA: 0x0006EBF3 File Offset: 0x0006CDF3
		Friend Overridable Property Label1 As Label

		' Token: 0x1700609B RID: 24731
		' (get) Token: 0x0600FC92 RID: 64658 RVA: 0x0006EBFC File Offset: 0x0006CDFC
		' (set) Token: 0x0600FC93 RID: 64659 RVA: 0x0006EC06 File Offset: 0x0006CE06
		Friend Overridable Property lblUser As Label

		' Token: 0x1700609C RID: 24732
		' (get) Token: 0x0600FC94 RID: 64660 RVA: 0x0006EC0F File Offset: 0x0006CE0F
		' (set) Token: 0x0600FC95 RID: 64661 RVA: 0x0006EC19 File Offset: 0x0006CE19
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x1700609D RID: 24733
		' (get) Token: 0x0600FC96 RID: 64662 RVA: 0x0006EC22 File Offset: 0x0006CE22
		' (set) Token: 0x0600FC97 RID: 64663 RVA: 0x0006EC2C File Offset: 0x0006CE2C
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x1700609E RID: 24734
		' (get) Token: 0x0600FC98 RID: 64664 RVA: 0x0006EC35 File Offset: 0x0006CE35
		' (set) Token: 0x0600FC99 RID: 64665 RVA: 0x0006EC3F File Offset: 0x0006CE3F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700609F RID: 24735
		' (get) Token: 0x0600FC9A RID: 64666 RVA: 0x0006EC48 File Offset: 0x0006CE48
		' (set) Token: 0x0600FC9B RID: 64667 RVA: 0x00972200 File Offset: 0x00970400
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

		' Token: 0x170060A0 RID: 24736
		' (get) Token: 0x0600FC9C RID: 64668 RVA: 0x0006EC52 File Offset: 0x0006CE52
		' (set) Token: 0x0600FC9D RID: 64669 RVA: 0x00972244 File Offset: 0x00970444
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

		' Token: 0x170060A1 RID: 24737
		' (get) Token: 0x0600FC9E RID: 64670 RVA: 0x0006EC5C File Offset: 0x0006CE5C
		' (set) Token: 0x0600FC9F RID: 64671 RVA: 0x00972288 File Offset: 0x00970488
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

		' Token: 0x170060A2 RID: 24738
		' (get) Token: 0x0600FCA0 RID: 64672 RVA: 0x0006EC66 File Offset: 0x0006CE66
		' (set) Token: 0x0600FCA1 RID: 64673 RVA: 0x009722CC File Offset: 0x009704CC
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

		' Token: 0x170060A3 RID: 24739
		' (get) Token: 0x0600FCA2 RID: 64674 RVA: 0x0006EC70 File Offset: 0x0006CE70
		' (set) Token: 0x0600FCA3 RID: 64675 RVA: 0x0006EC7A File Offset: 0x0006CE7A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x0600FCA4 RID: 64676 RVA: 0x00972310 File Offset: 0x00970510
		Private Sub frmRoute_Load(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FCA5 RID: 64677 RVA: 0x00972398 File Offset: 0x00970598
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

		' Token: 0x0600FCA6 RID: 64678 RVA: 0x00972638 File Offset: 0x00970838
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

		' Token: 0x0600FCA7 RID: 64679 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FCA8 RID: 64680 RVA: 0x009726EC File Offset: 0x009708EC
		Public Sub Reset()
			Me.cmbCategory.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
			Me.fillGategoryName()
			Me.cmbCategory.Focus()
		End Sub

		' Token: 0x0600FCA9 RID: 64681 RVA: 0x0097275C File Offset: 0x0097095C
		Public Sub fillGategoryName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(routename) FROM Route", ModCommonClasses.con)
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

		' Token: 0x0600FCAA RID: 64682 RVA: 0x00972890 File Offset: 0x00970A90
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from route where routename=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the route '" + Me.cmbCategory.Text.TrimEnd(New Char(-1) {}) + "'")
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

		' Token: 0x0600FCAB RID: 64683 RVA: 0x009729E8 File Offset: 0x00970BE8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtCategoryName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FCAC RID: 64684 RVA: 0x00972AB0 File Offset: 0x00970CB0
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

		' Token: 0x0600FCAD RID: 64685 RVA: 0x00972B98 File Offset: 0x00970D98
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(routename) from route order by routename", ModCommonClasses.con)
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

		' Token: 0x0600FCAE RID: 64686 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FCAF RID: 64687 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmRoute_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FCB0 RID: 64688 RVA: 0x00972C7C File Offset: 0x00970E7C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x0600FCB1 RID: 64689 RVA: 0x0006EC83 File Offset: 0x0006CE83
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FCB2 RID: 64690 RVA: 0x00972CD8 File Offset: 0x00970ED8
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
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter route", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select routename from route where routename=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Route Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbCategory.Text = ""
							Me.cmbCategory.Focus()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Route(routename) VALUES (@d1)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "added the new route '" + Me.cmbCategory.Text + "'")
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
							Me.fillGategoryName()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600FCB3 RID: 64691 RVA: 0x00972FB4 File Offset: 0x009711B4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter route", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update route set routename=@d1 where routename=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCategoryName.Text)
					ModCommonClasses.cmd.ExecuteReader()
					ModFunc.LogFunc(Me.lblUser.Text, "updated the route '" + Me.cmbCategory.Text + "'")
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
					Me.fillGategoryName()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600FCB4 RID: 64692 RVA: 0x00973128 File Offset: 0x00971328
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
