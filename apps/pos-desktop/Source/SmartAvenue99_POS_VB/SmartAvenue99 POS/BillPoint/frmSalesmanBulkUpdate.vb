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
	' Token: 0x0200036D RID: 877
	<DesignerGenerated()>
	Public Partial Class frmSalesmanBulkUpdate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CF6C RID: 53100 RVA: 0x0005C383 File Offset: 0x0005A583
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesmanBulkUpdate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesmanBulkUpdate_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005165 RID: 20837
		' (get) Token: 0x0600CF6F RID: 53103 RVA: 0x0005C3B5 File Offset: 0x0005A5B5
		' (set) Token: 0x0600CF70 RID: 53104 RVA: 0x00816C9C File Offset: 0x00814E9C
		Private _TextBox42 As TextBox
		Friend Overridable Property TextBox42 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox42
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox42_LostFocus
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox42_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox42_KeyDown
				Dim textBox As TextBox = Me._TextBox42
				If textBox IsNot Nothing Then
					RemoveHandler textBox.LostFocus, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox42 = value
				textBox = Me._TextBox42
				If textBox IsNot Nothing Then
					AddHandler textBox.LostFocus, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005166 RID: 20838
		' (get) Token: 0x0600CF71 RID: 53105 RVA: 0x0005C3BF File Offset: 0x0005A5BF
		' (set) Token: 0x0600CF72 RID: 53106 RVA: 0x0005C3C9 File Offset: 0x0005A5C9
		Friend Overridable Property Label2 As Label

		' Token: 0x17005167 RID: 20839
		' (get) Token: 0x0600CF73 RID: 53107 RVA: 0x0005C3D2 File Offset: 0x0005A5D2
		' (set) Token: 0x0600CF74 RID: 53108 RVA: 0x0005C3DC File Offset: 0x0005A5DC
		Friend Overridable Property Label1 As Label

		' Token: 0x17005168 RID: 20840
		' (get) Token: 0x0600CF75 RID: 53109 RVA: 0x0005C3E5 File Offset: 0x0005A5E5
		' (set) Token: 0x0600CF76 RID: 53110 RVA: 0x00816D18 File Offset: 0x00814F18
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005169 RID: 20841
		' (get) Token: 0x0600CF77 RID: 53111 RVA: 0x0005C3EF File Offset: 0x0005A5EF
		' (set) Token: 0x0600CF78 RID: 53112 RVA: 0x0005C3F9 File Offset: 0x0005A5F9
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x1700516A RID: 20842
		' (get) Token: 0x0600CF79 RID: 53113 RVA: 0x0005C402 File Offset: 0x0005A602
		' (set) Token: 0x0600CF7A RID: 53114 RVA: 0x0005C40C File Offset: 0x0005A60C
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x1700516B RID: 20843
		' (get) Token: 0x0600CF7B RID: 53115 RVA: 0x0005C415 File Offset: 0x0005A615
		' (set) Token: 0x0600CF7C RID: 53116 RVA: 0x00816D5C File Offset: 0x00814F5C
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
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700516C RID: 20844
		' (get) Token: 0x0600CF7D RID: 53117 RVA: 0x0005C41F File Offset: 0x0005A61F
		' (set) Token: 0x0600CF7E RID: 53118 RVA: 0x0005C429 File Offset: 0x0005A629
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x1700516D RID: 20845
		' (get) Token: 0x0600CF7F RID: 53119 RVA: 0x0005C432 File Offset: 0x0005A632
		' (set) Token: 0x0600CF80 RID: 53120 RVA: 0x0005C43C File Offset: 0x0005A63C
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x1700516E RID: 20846
		' (get) Token: 0x0600CF81 RID: 53121 RVA: 0x0005C445 File Offset: 0x0005A645
		' (set) Token: 0x0600CF82 RID: 53122 RVA: 0x0005C44F File Offset: 0x0005A64F
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x1700516F RID: 20847
		' (get) Token: 0x0600CF83 RID: 53123 RVA: 0x0005C458 File Offset: 0x0005A658
		' (set) Token: 0x0600CF84 RID: 53124 RVA: 0x0005C462 File Offset: 0x0005A662
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17005170 RID: 20848
		' (get) Token: 0x0600CF85 RID: 53125 RVA: 0x0005C46B File Offset: 0x0005A66B
		' (set) Token: 0x0600CF86 RID: 53126 RVA: 0x0005C475 File Offset: 0x0005A675
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17005171 RID: 20849
		' (get) Token: 0x0600CF87 RID: 53127 RVA: 0x0005C47E File Offset: 0x0005A67E
		' (set) Token: 0x0600CF88 RID: 53128 RVA: 0x0005C488 File Offset: 0x0005A688
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17005172 RID: 20850
		' (get) Token: 0x0600CF89 RID: 53129 RVA: 0x0005C491 File Offset: 0x0005A691
		' (set) Token: 0x0600CF8A RID: 53130 RVA: 0x0005C49B File Offset: 0x0005A69B
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17005173 RID: 20851
		' (get) Token: 0x0600CF8B RID: 53131 RVA: 0x0005C4A4 File Offset: 0x0005A6A4
		' (set) Token: 0x0600CF8C RID: 53132 RVA: 0x0005C4AE File Offset: 0x0005A6AE
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17005174 RID: 20852
		' (get) Token: 0x0600CF8D RID: 53133 RVA: 0x0005C4B7 File Offset: 0x0005A6B7
		' (set) Token: 0x0600CF8E RID: 53134 RVA: 0x00816DA0 File Offset: 0x00814FA0
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005175 RID: 20853
		' (get) Token: 0x0600CF8F RID: 53135 RVA: 0x0005C4C1 File Offset: 0x0005A6C1
		' (set) Token: 0x0600CF90 RID: 53136 RVA: 0x00816DE4 File Offset: 0x00814FE4
		Private _listView1 As ListView
		Protected Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.listView1_KeyDown
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
					RemoveHandler listView.KeyDown, keyEventHandler
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.MouseDoubleClick, mouseEventHandler
					AddHandler listView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005176 RID: 20854
		' (get) Token: 0x0600CF91 RID: 53137 RVA: 0x0005C4CB File Offset: 0x0005A6CB
		' (set) Token: 0x0600CF92 RID: 53138 RVA: 0x0005C4D5 File Offset: 0x0005A6D5
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17005177 RID: 20855
		' (get) Token: 0x0600CF93 RID: 53139 RVA: 0x0005C4DE File Offset: 0x0005A6DE
		' (set) Token: 0x0600CF94 RID: 53140 RVA: 0x00816E44 File Offset: 0x00815044
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

		' Token: 0x17005178 RID: 20856
		' (get) Token: 0x0600CF95 RID: 53141 RVA: 0x0005C4E8 File Offset: 0x0005A6E8
		' (set) Token: 0x0600CF96 RID: 53142 RVA: 0x00816E88 File Offset: 0x00815088
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

		' Token: 0x0600CF97 RID: 53143 RVA: 0x0005C4F2 File Offset: 0x0005A6F2
		Private Sub frmSalesmanBulkUpdate_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CF98 RID: 53144 RVA: 0x00816ECC File Offset: 0x008150CC
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

		' Token: 0x0600CF99 RID: 53145 RVA: 0x00817044 File Offset: 0x00815244
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

		' Token: 0x0600CF9A RID: 53146 RVA: 0x00817100 File Offset: 0x00815300
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

		' Token: 0x0600CF9B RID: 53147 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CF9C RID: 53148 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CF9D RID: 53149 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CF9E RID: 53150 RVA: 0x008171CC File Offset: 0x008153CC
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CF9F RID: 53151 RVA: 0x00817470 File Offset: 0x00815670
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x0600CFA0 RID: 53152 RVA: 0x008174C4 File Offset: 0x008156C4
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num - 2 <= 9 Then
					' The following expression was wrapped in a checked-statement
					Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
					Dim width As Integer = Me.CurrentSB.Bounds.Width
					Dim textBox As TextBox = Me.TextBox42
					textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
					textBox.Text = Me.CurrentSB.Text
					textBox.Show()
					textBox.Focus()
				End If
			End If
		End Sub

		' Token: 0x0600CFA1 RID: 53153 RVA: 0x008175F0 File Offset: 0x008157F0
		Private Sub TextBox42_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox42.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Me.TextBox42.Text.Trim(), "", False) <> 0
				Dim flag4 As Boolean = flag3
				If flag4 Then
					Me.CurrentSB.Text = Me.TextBox42.Text
					Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
					flag3 = num = 2
					Dim flag5 As Boolean = flag3
					If flag5 Then
					End If
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x0600CFA2 RID: 53154 RVA: 0x00817698 File Offset: 0x00815898
		Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(keyChar), vbCr, False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
				Dim listView As ListView = Me.listView1
				Me.listView1 = listView
			Else
				flag = keyChar = ChrW(27)
				Dim flag3 As Boolean = flag
				If flag3 Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			End If
		End Sub

		' Token: 0x0600CFA3 RID: 53155 RVA: 0x00817720 File Offset: 0x00815920
		Private Sub listView1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Dim keyCode As Keys = e.KeyCode
				flag = keyCode = Keys.F2
				Dim flag3 As Boolean = flag
				If flag3 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x0600CFA4 RID: 53156 RVA: 0x00817784 File Offset: 0x00815984
		Private Sub Updatelistdata(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text2 As String
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim text As String = String.Concat(New String() { "UPDATE Salesman SET Name = N'", pListView.Items(num4).SubItems(2).Text, "', Address = N'", pListView.Items(num4).SubItems(3).Text, "', City = N'", pListView.Items(num4).SubItems(4).Text, "', State = N'", pListView.Items(num4).SubItems(5).Text, "', ZipCode = N'", pListView.Items(num4).SubItems(6).Text, "', ContactNo = N'", pListView.Items(num4).SubItems(7).Text, "', EmailID = N'", pListView.Items(num4).SubItems(8).Text, "', CommissionPer = N'", pListView.Items(num4).SubItems(9).Text, "', Remarks = N'", pListView.Items(num4).SubItems(10).Text, "' WHERE SM_ID = N'", pListView.Items(num4).SubItems(0).Text, "' and Salesman_ID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					text2 = text2 + pListView.Items(num4).SubItems(0).Text + ","
					pListView.Items(num4).Checked = False
					num += 1
				End If
				num4 += 1
			End While
			Dim text3 As String
			Interaction.MsgBox(String.Concat(New String() { "Total Record(s) Updated ", Conversions.ToString(num), ". Updated ID(s)  ", text2, " having Salesman ID(s). ", text3 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x0600CFA5 RID: 53157 RVA: 0x00817A5C File Offset: 0x00815C5C
		Public Function ExecNonQuery(cmdText As String) As Integer
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
			Dim num As Integer = sqlCommand.ExecuteNonQuery()
			sqlCommand.Dispose()
			sqlConnection.Close()
			Return num
		End Function

		' Token: 0x0600CFA6 RID: 53158 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox42_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CFA7 RID: 53159 RVA: 0x00817AA0 File Offset: 0x00815CA0
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600CFA8 RID: 53160 RVA: 0x00817B8C File Offset: 0x00815D8C
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman where Name like N'%" + Me.TextBox1.Text + "%' order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CFA9 RID: 53161 RVA: 0x00817E44 File Offset: 0x00816044
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman where ContactNo like N'%" + Me.TextBox2.Text + "%' order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CFAA RID: 53162 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesmanBulkUpdate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CFAB RID: 53163 RVA: 0x008180FC File Offset: 0x008162FC
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim listView As ListView = Me.listView1
				Me.Updatelistdata(listView)
				Me.listView1 = listView
				Me.Getdata()
				Me.chkSelectAll.Checked = False
			End If
		End Sub

		' Token: 0x0600CFAC RID: 53164 RVA: 0x0005C503 File Offset: 0x0005A703
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.chkSelectAll.Checked = False
			Me.Getdata()
		End Sub

		' Token: 0x04005351 RID: 21329
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04005352 RID: 21330
		Private CurrentItem As ListViewItem

		' Token: 0x04005353 RID: 21331
		Private bCancelEdit As Boolean
	End Class
End Namespace
