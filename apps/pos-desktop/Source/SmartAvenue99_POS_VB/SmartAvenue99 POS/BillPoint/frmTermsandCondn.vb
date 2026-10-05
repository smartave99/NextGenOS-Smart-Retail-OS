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
	' Token: 0x020004E6 RID: 1254
	<DesignerGenerated()>
	Public Partial Class frmTermsandCondn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010030 RID: 65584 RVA: 0x00070578 File Offset: 0x0006E778
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTermsandCondn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTermsandCondn_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170061E5 RID: 25061
		' (get) Token: 0x06010033 RID: 65587 RVA: 0x000705AA File Offset: 0x0006E7AA
		' (set) Token: 0x06010034 RID: 65588 RVA: 0x000705B4 File Offset: 0x0006E7B4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170061E6 RID: 25062
		' (get) Token: 0x06010035 RID: 65589 RVA: 0x000705BD File Offset: 0x0006E7BD
		' (set) Token: 0x06010036 RID: 65590 RVA: 0x000705C7 File Offset: 0x0006E7C7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170061E7 RID: 25063
		' (get) Token: 0x06010037 RID: 65591 RVA: 0x000705D0 File Offset: 0x0006E7D0
		' (set) Token: 0x06010038 RID: 65592 RVA: 0x000705DA File Offset: 0x0006E7DA
		Friend Overridable Property Label1 As Label

		' Token: 0x170061E8 RID: 25064
		' (get) Token: 0x06010039 RID: 65593 RVA: 0x000705E3 File Offset: 0x0006E7E3
		' (set) Token: 0x0601003A RID: 65594 RVA: 0x000705ED File Offset: 0x0006E7ED
		Friend Overridable Property txtID As TextBox

		' Token: 0x170061E9 RID: 25065
		' (get) Token: 0x0601003B RID: 65595 RVA: 0x000705F6 File Offset: 0x0006E7F6
		' (set) Token: 0x0601003C RID: 65596 RVA: 0x00070600 File Offset: 0x0006E800
		Friend Overridable Property lblUser As Label

		' Token: 0x170061EA RID: 25066
		' (get) Token: 0x0601003D RID: 65597 RVA: 0x00070609 File Offset: 0x0006E809
		' (set) Token: 0x0601003E RID: 65598 RVA: 0x00070613 File Offset: 0x0006E813
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170061EB RID: 25067
		' (get) Token: 0x0601003F RID: 65599 RVA: 0x0007061C File Offset: 0x0006E81C
		' (set) Token: 0x06010040 RID: 65600 RVA: 0x00070626 File Offset: 0x0006E826
		Friend Overridable Property Label3 As Label

		' Token: 0x170061EC RID: 25068
		' (get) Token: 0x06010041 RID: 65601 RVA: 0x0007062F File Offset: 0x0006E82F
		' (set) Token: 0x06010042 RID: 65602 RVA: 0x0098EF24 File Offset: 0x0098D124
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170061ED RID: 25069
		' (get) Token: 0x06010043 RID: 65603 RVA: 0x00070639 File Offset: 0x0006E839
		' (set) Token: 0x06010044 RID: 65604 RVA: 0x0098EF68 File Offset: 0x0098D168
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

		' Token: 0x170061EE RID: 25070
		' (get) Token: 0x06010045 RID: 65605 RVA: 0x00070643 File Offset: 0x0006E843
		' (set) Token: 0x06010046 RID: 65606 RVA: 0x0007064D File Offset: 0x0006E84D
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170061EF RID: 25071
		' (get) Token: 0x06010047 RID: 65607 RVA: 0x00070656 File Offset: 0x0006E856
		' (set) Token: 0x06010048 RID: 65608 RVA: 0x00070660 File Offset: 0x0006E860
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170061F0 RID: 25072
		' (get) Token: 0x06010049 RID: 65609 RVA: 0x00070669 File Offset: 0x0006E869
		' (set) Token: 0x0601004A RID: 65610 RVA: 0x00070673 File Offset: 0x0006E873
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170061F1 RID: 25073
		' (get) Token: 0x0601004B RID: 65611 RVA: 0x0007067C File Offset: 0x0006E87C
		' (set) Token: 0x0601004C RID: 65612 RVA: 0x0098EFC8 File Offset: 0x0098D1C8
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170061F2 RID: 25074
		' (get) Token: 0x0601004D RID: 65613 RVA: 0x00070686 File Offset: 0x0006E886
		' (set) Token: 0x0601004E RID: 65614 RVA: 0x0098F00C File Offset: 0x0098D20C
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170061F3 RID: 25075
		' (get) Token: 0x0601004F RID: 65615 RVA: 0x00070690 File Offset: 0x0006E890
		' (set) Token: 0x06010050 RID: 65616 RVA: 0x0098F050 File Offset: 0x0098D250
		Private _Button5 As GelButton
		Friend Overridable Property Button5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._Button5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button5 = value
				gelButton = Me._Button5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170061F4 RID: 25076
		' (get) Token: 0x06010051 RID: 65617 RVA: 0x0007069A File Offset: 0x0006E89A
		' (set) Token: 0x06010052 RID: 65618 RVA: 0x0098F094 File Offset: 0x0098D294
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button4 = value
				gelButton = Me._Button4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010053 RID: 65619 RVA: 0x0098F0D8 File Offset: 0x0098D2D8
		Private Sub frmTermsandCondn_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010054 RID: 65620 RVA: 0x0098F160 File Offset: 0x0098D360
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

		' Token: 0x06010055 RID: 65621 RVA: 0x0098F2D8 File Offset: 0x0098D4D8
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

		' Token: 0x06010056 RID: 65622 RVA: 0x0098F394 File Offset: 0x0098D594
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

		' Token: 0x06010057 RID: 65623 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010058 RID: 65624 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010059 RID: 65625 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601005A RID: 65626 RVA: 0x000706A4 File Offset: 0x0006E8A4
		Private Sub Clear()
			Me.TextBox1.Text = ""
			Me.txtID.Text = ""
			Me.GetData()
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0601005B RID: 65627 RVA: 0x0098F460 File Offset: 0x0098D660
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button4.Enabled = False
					Me.Button3.Enabled = True
					Me.Button2.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601005C RID: 65628 RVA: 0x0098F528 File Offset: 0x0098D728
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID,RTRIM(c1) from Terms ORDER BY ID", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0601005D RID: 65629 RVA: 0x0098F610 File Offset: 0x0098D810
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

		' Token: 0x0601005E RID: 65630 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTermsandCondn_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601005F RID: 65631 RVA: 0x0098F6F8 File Offset: 0x0098D8F8
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
		End Sub

		' Token: 0x06010060 RID: 65632 RVA: 0x000706DC File Offset: 0x0006E8DC
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.TextBox1.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06010061 RID: 65633 RVA: 0x0098F754 File Offset: 0x0098D954
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
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
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter Terms and Condition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Select count(*) from Terms Having count(*) >= 1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the Terms and Conditions", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "Insert into Terms(c1) VALUES (@d1)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Button4.Enabled = True
							Me.Button3.Enabled = False
							Me.Button2.Enabled = False
							Me.GetData()
							Me.Clear()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010062 RID: 65634 RVA: 0x0098F9D0 File Offset: 0x0098DBD0
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please fill Terms and Condition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.TextBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = If(("Update Terms set c1=@d1 where ID=" + Me.txtID.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.GetData()
					Me.Clear()
					Me.Button4.Enabled = True
					Me.Button3.Enabled = False
					Me.Button2.Enabled = False
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010063 RID: 65635 RVA: 0x0098FB2C File Offset: 0x0098DD2C
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Terms WHERE ID = " + Me.txtID.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Clear()
					End If
				End If
				Me.GetData()
				Me.Clear()
				ModCommonClasses.con.Close()
				Me.Button4.Enabled = True
				Me.Button3.Enabled = False
				Me.Button2.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
