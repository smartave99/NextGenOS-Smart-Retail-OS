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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005AA RID: 1450
	<DesignerGenerated()>
	Public Partial Class frmSMS
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011BB5 RID: 72629 RVA: 0x00079E03 File Offset: 0x00078003
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSMS_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006E22 RID: 28194
		' (get) Token: 0x06011BB8 RID: 72632 RVA: 0x00079E35 File Offset: 0x00078035
		' (set) Token: 0x06011BB9 RID: 72633 RVA: 0x00079E3F File Offset: 0x0007803F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006E23 RID: 28195
		' (get) Token: 0x06011BBA RID: 72634 RVA: 0x00079E48 File Offset: 0x00078048
		' (set) Token: 0x06011BBB RID: 72635 RVA: 0x00079E52 File Offset: 0x00078052
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006E24 RID: 28196
		' (get) Token: 0x06011BBC RID: 72636 RVA: 0x00079E5B File Offset: 0x0007805B
		' (set) Token: 0x06011BBD RID: 72637 RVA: 0x00A3F644 File Offset: 0x00A3D844
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E25 RID: 28197
		' (get) Token: 0x06011BBE RID: 72638 RVA: 0x00079E65 File Offset: 0x00078065
		' (set) Token: 0x06011BBF RID: 72639 RVA: 0x00079E6F File Offset: 0x0007806F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006E26 RID: 28198
		' (get) Token: 0x06011BC0 RID: 72640 RVA: 0x00079E78 File Offset: 0x00078078
		' (set) Token: 0x06011BC1 RID: 72641 RVA: 0x00079E82 File Offset: 0x00078082
		Friend Overridable Property Label1 As Label

		' Token: 0x17006E27 RID: 28199
		' (get) Token: 0x06011BC2 RID: 72642 RVA: 0x00079E8B File Offset: 0x0007808B
		' (set) Token: 0x06011BC3 RID: 72643 RVA: 0x00079E95 File Offset: 0x00078095
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006E28 RID: 28200
		' (get) Token: 0x06011BC4 RID: 72644 RVA: 0x00079E9E File Offset: 0x0007809E
		' (set) Token: 0x06011BC5 RID: 72645 RVA: 0x00079EA8 File Offset: 0x000780A8
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006E29 RID: 28201
		' (get) Token: 0x06011BC6 RID: 72646 RVA: 0x00079EB1 File Offset: 0x000780B1
		' (set) Token: 0x06011BC7 RID: 72647 RVA: 0x00079EBB File Offset: 0x000780BB
		Friend Overridable Property Label2 As Label

		' Token: 0x17006E2A RID: 28202
		' (get) Token: 0x06011BC8 RID: 72648 RVA: 0x00079EC4 File Offset: 0x000780C4
		' (set) Token: 0x06011BC9 RID: 72649 RVA: 0x00079ECE File Offset: 0x000780CE
		Friend Overridable Property Label3 As Label

		' Token: 0x17006E2B RID: 28203
		' (get) Token: 0x06011BCA RID: 72650 RVA: 0x00079ED7 File Offset: 0x000780D7
		' (set) Token: 0x06011BCB RID: 72651 RVA: 0x00079EE1 File Offset: 0x000780E1
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006E2C RID: 28204
		' (get) Token: 0x06011BCC RID: 72652 RVA: 0x00079EEA File Offset: 0x000780EA
		' (set) Token: 0x06011BCD RID: 72653 RVA: 0x00079EF4 File Offset: 0x000780F4
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17006E2D RID: 28205
		' (get) Token: 0x06011BCE RID: 72654 RVA: 0x00079EFD File Offset: 0x000780FD
		' (set) Token: 0x06011BCF RID: 72655 RVA: 0x00A3F688 File Offset: 0x00A3D888
		Private _btnDeleteAllLogs As Button
		Friend Overridable Property btnDeleteAllLogs As Button
			<CompilerGenerated()>
			Get
				Return Me._btnDeleteAllLogs
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnDeleteAllLogs_Click
				Dim button As Button = Me._btnDeleteAllLogs
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnDeleteAllLogs = value
				button = Me._btnDeleteAllLogs
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E2E RID: 28206
		' (get) Token: 0x06011BD0 RID: 72656 RVA: 0x00079F07 File Offset: 0x00078107
		' (set) Token: 0x06011BD1 RID: 72657 RVA: 0x00079F11 File Offset: 0x00078111
		Friend Overridable Property lblUser As Label

		' Token: 0x17006E2F RID: 28207
		' (get) Token: 0x06011BD2 RID: 72658 RVA: 0x00079F1A File Offset: 0x0007811A
		' (set) Token: 0x06011BD3 RID: 72659 RVA: 0x00079F24 File Offset: 0x00078124
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006E30 RID: 28208
		' (get) Token: 0x06011BD4 RID: 72660 RVA: 0x00079F2D File Offset: 0x0007812D
		' (set) Token: 0x06011BD5 RID: 72661 RVA: 0x00079F37 File Offset: 0x00078137
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006E31 RID: 28209
		' (get) Token: 0x06011BD6 RID: 72662 RVA: 0x00079F40 File Offset: 0x00078140
		' (set) Token: 0x06011BD7 RID: 72663 RVA: 0x00079F4A File Offset: 0x0007814A
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006E32 RID: 28210
		' (get) Token: 0x06011BD8 RID: 72664 RVA: 0x00079F53 File Offset: 0x00078153
		' (set) Token: 0x06011BD9 RID: 72665 RVA: 0x00A3F6CC File Offset: 0x00A3D8CC
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

		' Token: 0x17006E33 RID: 28211
		' (get) Token: 0x06011BDA RID: 72666 RVA: 0x00079F5D File Offset: 0x0007815D
		' (set) Token: 0x06011BDB RID: 72667 RVA: 0x00A3F710 File Offset: 0x00A3D910
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

		' Token: 0x17006E34 RID: 28212
		' (get) Token: 0x06011BDC RID: 72668 RVA: 0x00079F67 File Offset: 0x00078167
		' (set) Token: 0x06011BDD RID: 72669 RVA: 0x00A3F754 File Offset: 0x00A3D954
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

		' Token: 0x06011BDE RID: 72670 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06011BDF RID: 72671 RVA: 0x00A3F798 File Offset: 0x00A3D998
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Date,RTRIM(Message) from SMS order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011BE0 RID: 72672 RVA: 0x00A3F888 File Offset: 0x00A3DA88
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011BE1 RID: 72673 RVA: 0x00A3F910 File Offset: 0x00A3DB10
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

		' Token: 0x06011BE2 RID: 72674 RVA: 0x00A3FA88 File Offset: 0x00A3DC88
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x06011BE3 RID: 72675 RVA: 0x00A3FB54 File Offset: 0x00A3DD54
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

		' Token: 0x06011BE4 RID: 72676 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011BE5 RID: 72677 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011BE6 RID: 72678 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011BE7 RID: 72679 RVA: 0x00079F71 File Offset: 0x00078171
		Public Sub Reset()
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.GetData()
		End Sub

		' Token: 0x06011BE8 RID: 72680 RVA: 0x00A3FC20 File Offset: 0x00A3DE20
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

		' Token: 0x06011BE9 RID: 72681 RVA: 0x00A3FD08 File Offset: 0x00A3DF08
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con.Open()
				Dim text As String = "delete from SMS"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "deleted the all sms data till date '" + DateAndTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					Me.Reset()
					Me.GetData()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011BEA RID: 72682 RVA: 0x00A3FE34 File Offset: 0x00A3E034
		Private Sub btnDeleteAllLogs_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete all sms data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011BEB RID: 72683 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSMS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011BEC RID: 72684 RVA: 0x00A3FE9C File Offset: 0x00A3E09C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Date,RTRIM(Message) from SMS where Date >=@d1 and Date < @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011BED RID: 72685 RVA: 0x00079F9D File Offset: 0x0007819D
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011BEE RID: 72686 RVA: 0x00A40020 File Offset: 0x00A3E220
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
