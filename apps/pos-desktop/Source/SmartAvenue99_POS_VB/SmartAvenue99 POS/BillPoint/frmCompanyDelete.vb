Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004B0 RID: 1200
	<DesignerGenerated()>
	Public Partial Class frmCompanyDelete
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F0CD RID: 61645 RVA: 0x000695E6 File Offset: 0x000677E6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCompanyDelete_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCompanyDelete_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005C4A RID: 23626
		' (get) Token: 0x0600F0D0 RID: 61648 RVA: 0x00069618 File Offset: 0x00067818
		' (set) Token: 0x0600F0D1 RID: 61649 RVA: 0x00069622 File Offset: 0x00067822
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005C4B RID: 23627
		' (get) Token: 0x0600F0D2 RID: 61650 RVA: 0x0006962B File Offset: 0x0006782B
		' (set) Token: 0x0600F0D3 RID: 61651 RVA: 0x0090B5DC File Offset: 0x009097DC
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

		' Token: 0x17005C4C RID: 23628
		' (get) Token: 0x0600F0D4 RID: 61652 RVA: 0x00069635 File Offset: 0x00067835
		' (set) Token: 0x0600F0D5 RID: 61653 RVA: 0x0006963F File Offset: 0x0006783F
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005C4D RID: 23629
		' (get) Token: 0x0600F0D6 RID: 61654 RVA: 0x00069648 File Offset: 0x00067848
		' (set) Token: 0x0600F0D7 RID: 61655 RVA: 0x00069652 File Offset: 0x00067852
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005C4E RID: 23630
		' (get) Token: 0x0600F0D8 RID: 61656 RVA: 0x0006965B File Offset: 0x0006785B
		' (set) Token: 0x0600F0D9 RID: 61657 RVA: 0x00069665 File Offset: 0x00067865
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005C4F RID: 23631
		' (get) Token: 0x0600F0DA RID: 61658 RVA: 0x0006966E File Offset: 0x0006786E
		' (set) Token: 0x0600F0DB RID: 61659 RVA: 0x00069678 File Offset: 0x00067878
		Friend Overridable Property txtDBName As TextBox

		' Token: 0x17005C50 RID: 23632
		' (get) Token: 0x0600F0DC RID: 61660 RVA: 0x00069681 File Offset: 0x00067881
		' (set) Token: 0x0600F0DD RID: 61661 RVA: 0x0006968B File Offset: 0x0006788B
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005C51 RID: 23633
		' (get) Token: 0x0600F0DE RID: 61662 RVA: 0x00069694 File Offset: 0x00067894
		' (set) Token: 0x0600F0DF RID: 61663 RVA: 0x0006969E File Offset: 0x0006789E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005C52 RID: 23634
		' (get) Token: 0x0600F0E0 RID: 61664 RVA: 0x000696A7 File Offset: 0x000678A7
		' (set) Token: 0x0600F0E1 RID: 61665 RVA: 0x000696B1 File Offset: 0x000678B1
		Friend Overridable Property Label1 As Label

		' Token: 0x17005C53 RID: 23635
		' (get) Token: 0x0600F0E2 RID: 61666 RVA: 0x000696BA File Offset: 0x000678BA
		' (set) Token: 0x0600F0E3 RID: 61667 RVA: 0x000696C4 File Offset: 0x000678C4
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005C54 RID: 23636
		' (get) Token: 0x0600F0E4 RID: 61668 RVA: 0x000696CD File Offset: 0x000678CD
		' (set) Token: 0x0600F0E5 RID: 61669 RVA: 0x000696D7 File Offset: 0x000678D7
		Friend Overridable Property Label2 As Label

		' Token: 0x17005C55 RID: 23637
		' (get) Token: 0x0600F0E6 RID: 61670 RVA: 0x000696E0 File Offset: 0x000678E0
		' (set) Token: 0x0600F0E7 RID: 61671 RVA: 0x000696EA File Offset: 0x000678EA
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17005C56 RID: 23638
		' (get) Token: 0x0600F0E8 RID: 61672 RVA: 0x000696F3 File Offset: 0x000678F3
		' (set) Token: 0x0600F0E9 RID: 61673 RVA: 0x000696FD File Offset: 0x000678FD
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005C57 RID: 23639
		' (get) Token: 0x0600F0EA RID: 61674 RVA: 0x00069706 File Offset: 0x00067906
		' (set) Token: 0x0600F0EB RID: 61675 RVA: 0x00069710 File Offset: 0x00067910
		Friend Overridable Property Label3 As Label

		' Token: 0x17005C58 RID: 23640
		' (get) Token: 0x0600F0EC RID: 61676 RVA: 0x00069719 File Offset: 0x00067919
		' (set) Token: 0x0600F0ED RID: 61677 RVA: 0x00069723 File Offset: 0x00067923
		Friend Overridable Property txtDB As TextBox

		' Token: 0x17005C59 RID: 23641
		' (get) Token: 0x0600F0EE RID: 61678 RVA: 0x0006972C File Offset: 0x0006792C
		' (set) Token: 0x0600F0EF RID: 61679 RVA: 0x0090B63C File Offset: 0x0090983C
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

		' Token: 0x17005C5A RID: 23642
		' (get) Token: 0x0600F0F0 RID: 61680 RVA: 0x00069736 File Offset: 0x00067936
		' (set) Token: 0x0600F0F1 RID: 61681 RVA: 0x0090B680 File Offset: 0x00909880
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

		' Token: 0x17005C5B RID: 23643
		' (get) Token: 0x0600F0F2 RID: 61682 RVA: 0x00069740 File Offset: 0x00067940
		' (set) Token: 0x0600F0F3 RID: 61683 RVA: 0x0090B6C4 File Offset: 0x009098C4
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

		' Token: 0x17005C5C RID: 23644
		' (get) Token: 0x0600F0F4 RID: 61684 RVA: 0x0006974A File Offset: 0x0006794A
		' (set) Token: 0x0600F0F5 RID: 61685 RVA: 0x0090B708 File Offset: 0x00909908
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

		' Token: 0x0600F0F6 RID: 61686 RVA: 0x0090B74C File Offset: 0x0090994C
		Private Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT CompanyName FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.TextBox1.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F0F7 RID: 61687 RVA: 0x00069754 File Offset: 0x00067954
		Private Sub frmCompanyDelete_Load(sender As Object, e As EventArgs)
			Me.CompanyInfoDisplay()
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F0F8 RID: 61688 RVA: 0x0090B84C File Offset: 0x00909A4C
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

		' Token: 0x0600F0F9 RID: 61689 RVA: 0x0090B9C4 File Offset: 0x00909BC4
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

		' Token: 0x0600F0FA RID: 61690 RVA: 0x0090BA80 File Offset: 0x00909C80
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

		' Token: 0x0600F0FB RID: 61691 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F0FC RID: 61692 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F0FD RID: 61693 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F0FE RID: 61694 RVA: 0x0090BB4C File Offset: 0x00909D4C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT (ID),RTRIM(CompanyName),RTRIM(DBName) from RaintechMaster where DBName=@z1 order by ID ASC", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@z1", Me.txtDB.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(1)), RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(2)) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F0FF RID: 61695 RVA: 0x0090BC7C File Offset: 0x00909E7C
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub DeleteRecord()
			Try
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "USE Master ALTER DATABASE ", Me.txtDBName.Text, " SET Single_User WITH Rollback Immediate DROP database ", Me.txtDBName.Text, "" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				Dim text2 As String = "delete from RaintechMaster where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				num = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					ProjectData.EndApp()
				End If
				flag = ModCommonClasses.con.State = ConnectionState.Open
				Dim flag3 As Boolean = flag
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F100 RID: 61696 RVA: 0x0006976C File Offset: 0x0006796C
		Public Sub Reset1()
			Me.btnDelete.Enabled = False
			Me.Button3.Enabled = False
			Me.txtID.Text = ""
			Me.txtDBName.Text = ""
		End Sub

		' Token: 0x0600F101 RID: 61697 RVA: 0x0090BDE8 File Offset: 0x00909FE8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtDBName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.TextBox2.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.TextBox3.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.btnDelete.Enabled = True
					Me.Button3.Enabled = True
				Else
					Me.btnDelete.Enabled = False
					Me.Button3.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F102 RID: 61698 RVA: 0x0090BF1C File Offset: 0x0090A11C
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlText As Brush = SystemBrushes.ControlText
			e.Graphics.DrawString(text, Me.Font, controlText, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F103 RID: 61699 RVA: 0x0090C004 File Offset: 0x0090A204
		Private Sub DeleteDirectory(path As String)
			Dim flag As Boolean = Directory.Exists(path)
			If flag Then
				For Each text As String In Directory.GetFiles(path)
					File.Delete(text)
				Next
				For Each text2 As String In Directory.GetDirectories(path)
					Me.DeleteDirectory(text2)
				Next
				Directory.Delete(path)
			End If
		End Sub

		' Token: 0x0600F104 RID: 61700 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCompanyDelete_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F105 RID: 61701 RVA: 0x000697AB File Offset: 0x000679AB
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.btnDelete.Enabled = False
			Me.Button3.Enabled = False
			Me.TextBox2.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600F106 RID: 61702 RVA: 0x0090C080 File Offset: 0x0090A280
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim text As String = Application.StartupPath + "\session"
				Me.DeleteDirectory(text)
				MessageBox.Show("Successfully Deleted", "Google Drive", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F107 RID: 61703 RVA: 0x0090C0DC File Offset: 0x0090A2DC
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please fill Company name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					ModCommonClasses.con.Open()
					Dim text As String = "Update RaintechMaster set companyName=@d1 where CompanyName=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox3.Text)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Company Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.TextBox2.Text = ""
					Me.TextBox3.Text = ""
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F108 RID: 61704 RVA: 0x0090C230 File Offset: 0x0090A430
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this company all data?" & vbCrLf & "If you delete then application will be closed automatically.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
			End Try
		End Sub
	End Class
End Namespace
