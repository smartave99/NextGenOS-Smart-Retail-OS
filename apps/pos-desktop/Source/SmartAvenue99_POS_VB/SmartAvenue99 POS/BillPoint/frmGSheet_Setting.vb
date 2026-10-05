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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F2 RID: 498
	<DesignerGenerated()>
	Public Partial Class frmGSheet_Setting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008CEB RID: 36075 RVA: 0x006736CC File Offset: 0x006718CC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSMSSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSMSSetting_KeyDown
			Me.spreadsheetId = ""
			Me.gid = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x170033EB RID: 13291
		' (get) Token: 0x06008CEE RID: 36078 RVA: 0x00044CB2 File Offset: 0x00042EB2
		' (set) Token: 0x06008CEF RID: 36079 RVA: 0x00044CBC File Offset: 0x00042EBC
		Friend Overridable Property Label1 As Label

		' Token: 0x170033EC RID: 13292
		' (get) Token: 0x06008CF0 RID: 36080 RVA: 0x00044CC5 File Offset: 0x00042EC5
		' (set) Token: 0x06008CF1 RID: 36081 RVA: 0x00044CCF File Offset: 0x00042ECF
		Friend Overridable Property Label2 As Label

		' Token: 0x170033ED RID: 13293
		' (get) Token: 0x06008CF2 RID: 36082 RVA: 0x00044CD8 File Offset: 0x00042ED8
		' (set) Token: 0x06008CF3 RID: 36083 RVA: 0x00674880 File Offset: 0x00672A80
		Private _txtspreadsheetId As TextBox
		Friend Overridable Property txtspreadsheetId As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtspreadsheetId
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtspreadsheetId
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtspreadsheetId = value
				textBox = Me._txtspreadsheetId
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170033EE RID: 13294
		' (get) Token: 0x06008CF4 RID: 36084 RVA: 0x00044CE2 File Offset: 0x00042EE2
		' (set) Token: 0x06008CF5 RID: 36085 RVA: 0x00044CEC File Offset: 0x00042EEC
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170033EF RID: 13295
		' (get) Token: 0x06008CF6 RID: 36086 RVA: 0x00044CF5 File Offset: 0x00042EF5
		' (set) Token: 0x06008CF7 RID: 36087 RVA: 0x00044CFF File Offset: 0x00042EFF
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x170033F0 RID: 13296
		' (get) Token: 0x06008CF8 RID: 36088 RVA: 0x00044D08 File Offset: 0x00042F08
		' (set) Token: 0x06008CF9 RID: 36089 RVA: 0x006748C4 File Offset: 0x00672AC4
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

		' Token: 0x170033F1 RID: 13297
		' (get) Token: 0x06008CFA RID: 36090 RVA: 0x00044D12 File Offset: 0x00042F12
		' (set) Token: 0x06008CFB RID: 36091 RVA: 0x00044D1C File Offset: 0x00042F1C
		Friend Overridable Property Label5 As Label

		' Token: 0x170033F2 RID: 13298
		' (get) Token: 0x06008CFC RID: 36092 RVA: 0x00044D25 File Offset: 0x00042F25
		' (set) Token: 0x06008CFD RID: 36093 RVA: 0x00044D2F File Offset: 0x00042F2F
		Friend Overridable Property txtID As TextBox

		' Token: 0x170033F3 RID: 13299
		' (get) Token: 0x06008CFE RID: 36094 RVA: 0x00044D38 File Offset: 0x00042F38
		' (set) Token: 0x06008CFF RID: 36095 RVA: 0x00044D42 File Offset: 0x00042F42
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170033F4 RID: 13300
		' (get) Token: 0x06008D00 RID: 36096 RVA: 0x00044D4B File Offset: 0x00042F4B
		' (set) Token: 0x06008D01 RID: 36097 RVA: 0x00674924 File Offset: 0x00672B24
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

		' Token: 0x170033F5 RID: 13301
		' (get) Token: 0x06008D02 RID: 36098 RVA: 0x00044D55 File Offset: 0x00042F55
		' (set) Token: 0x06008D03 RID: 36099 RVA: 0x00674968 File Offset: 0x00672B68
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

		' Token: 0x170033F6 RID: 13302
		' (get) Token: 0x06008D04 RID: 36100 RVA: 0x00044D5F File Offset: 0x00042F5F
		' (set) Token: 0x06008D05 RID: 36101 RVA: 0x006749AC File Offset: 0x00672BAC
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

		' Token: 0x170033F7 RID: 13303
		' (get) Token: 0x06008D06 RID: 36102 RVA: 0x00044D69 File Offset: 0x00042F69
		' (set) Token: 0x06008D07 RID: 36103 RVA: 0x006749F0 File Offset: 0x00672BF0
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

		' Token: 0x170033F8 RID: 13304
		' (get) Token: 0x06008D08 RID: 36104 RVA: 0x00044D73 File Offset: 0x00042F73
		' (set) Token: 0x06008D09 RID: 36105 RVA: 0x00044D7D File Offset: 0x00042F7D
		Friend Overridable Property txtgid As TextBox

		' Token: 0x170033F9 RID: 13305
		' (get) Token: 0x06008D0A RID: 36106 RVA: 0x00044D86 File Offset: 0x00042F86
		' (set) Token: 0x06008D0B RID: 36107 RVA: 0x00044D90 File Offset: 0x00042F90
		Friend Overridable Property Label6 As Label

		' Token: 0x170033FA RID: 13306
		' (get) Token: 0x06008D0C RID: 36108 RVA: 0x00044D99 File Offset: 0x00042F99
		' (set) Token: 0x06008D0D RID: 36109 RVA: 0x00044DA3 File Offset: 0x00042FA3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170033FB RID: 13307
		' (get) Token: 0x06008D0E RID: 36110 RVA: 0x00044DAC File Offset: 0x00042FAC
		' (set) Token: 0x06008D0F RID: 36111 RVA: 0x00044DB6 File Offset: 0x00042FB6
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170033FC RID: 13308
		' (get) Token: 0x06008D10 RID: 36112 RVA: 0x00044DBF File Offset: 0x00042FBF
		' (set) Token: 0x06008D11 RID: 36113 RVA: 0x00044DC9 File Offset: 0x00042FC9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170033FD RID: 13309
		' (get) Token: 0x06008D12 RID: 36114 RVA: 0x00044DD2 File Offset: 0x00042FD2
		' (set) Token: 0x06008D13 RID: 36115 RVA: 0x00044DDC File Offset: 0x00042FDC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x06008D14 RID: 36116 RVA: 0x00674A34 File Offset: 0x00672C34
		Public Sub Reset()
			Me.txtspreadsheetId.Text = ""
			Me.txtgid.Text = ""
			Me.chkIsEnabled.Checked = True
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
		End Sub

		' Token: 0x06008D15 RID: 36117 RVA: 0x00674A98 File Offset: 0x00672C98
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT " & vbCrLf & "    Id, " & vbCrLf & "    RTRIM(spreadsheetId) AS spreadsheetId, " & vbCrLf & "    RTRIM(gid) AS gid, " & vbCrLf & "    CASE " & vbCrLf & "        WHEN IsEnabled = 1 THEN 'Yes' " & vbCrLf & "        ELSE 'No' " & vbCrLf & "    END AS IsEnabled" & vbCrLf & "FROM " & vbCrLf & "    GSheet_setting", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(3), "Yes", False)
					If flag Then
						Me.spreadsheetId = ModCommonClasses.rdr(1).ToString()
						Me.gid = ModCommonClasses.rdr(2).ToString()
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008D16 RID: 36118 RVA: 0x00674C00 File Offset: 0x00672E00
		Private Sub frmSMSSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
			Dim text As String = "https://docs.google.com/spreadsheets/d/" + Me.spreadsheetId + "/export?format=tsv&gid=" + Me.gid
			Me.Label5.Text = text.ToString()
		End Sub

		' Token: 0x06008D17 RID: 36119 RVA: 0x00674C4C File Offset: 0x00672E4C
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

		' Token: 0x06008D18 RID: 36120 RVA: 0x00674DC4 File Offset: 0x00672FC4
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

		' Token: 0x06008D19 RID: 36121 RVA: 0x00674E80 File Offset: 0x00673080
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

		' Token: 0x06008D1A RID: 36122 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06008D1B RID: 36123 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06008D1C RID: 36124 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06008D1D RID: 36125 RVA: 0x00674F4C File Offset: 0x0067314C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from GSheet_setting where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x06008D1E RID: 36126 RVA: 0x0067506C File Offset: 0x0067326C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.txtspreadsheetId.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtgid.Text = dataGridViewRow.Cells(2).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(3).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkIsEnabled.Checked = True
					Else
						Me.chkIsEnabled.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008D1F RID: 36127 RVA: 0x006751AC File Offset: 0x006733AC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtspreadsheetId.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtspreadsheetId, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtspreadsheetId, String.Empty)
			End If
		End Sub

		' Token: 0x06008D20 RID: 36128 RVA: 0x00044DE5 File Offset: 0x00042FE5
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06008D21 RID: 36129 RVA: 0x00675208 File Offset: 0x00673408
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtspreadsheetId.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter API URL", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtspreadsheetId.Focus()
			Else
				Try
					Dim checked As Boolean = Me.chkIsEnabled.Checked
					If checked Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update GSheet_setting set IsEnabled=0"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
					End If
					Dim checked2 As Boolean = Me.chkIsEnabled.Checked
					If checked2 Then
						Me.st1 = 1
					Else
						Me.st1 = 0
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = If(("Update GSheet_setting set spreadsheetId=@d1,gui=@d2,IsEnabled=@d3 where ID=" + Me.txtID.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtspreadsheetId.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtgid.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st1)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06008D22 RID: 36130 RVA: 0x00675408 File Offset: 0x00673608
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

		' Token: 0x06008D23 RID: 36131 RVA: 0x00675470 File Offset: 0x00673670
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtspreadsheetId.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Spreadsheet Id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtspreadsheetId.Focus()
			Else
				Try
					Dim checked As Boolean = Me.chkIsEnabled.Checked
					If checked Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select * from GSheet_setting where IsEnabled=1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
						If flag2 Then
							MessageBox.Show("Other Googlesheet is already set as enabled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag3 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
					End If
					Dim checked2 As Boolean = Me.chkIsEnabled.Checked
					If checked2 Then
						Me.st1 = 1
					Else
						Me.st1 = 0
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "insert into GSheet_setting(spreadsheetId,gid,IsEnabled) VALUES (@d1,@d2,@d3)"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtspreadsheetId.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtgid.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st1)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Saved", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnSave.Enabled = False
					Me.Getdata()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06008D24 RID: 36132 RVA: 0x006756A4 File Offset: 0x006738A4
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

		' Token: 0x06008D25 RID: 36133 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSMSSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04003E5C RID: 15964
		Private st1 As Integer

		' Token: 0x04003E5D RID: 15965
		Private spreadsheetId As String

		' Token: 0x04003E5E RID: 15966
		Private gid As String
	End Class
End Namespace
