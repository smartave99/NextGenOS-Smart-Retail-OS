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
	' Token: 0x02000200 RID: 512
	<DesignerGenerated()>
	Public Partial Class frmEwayBillSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009368 RID: 37736 RVA: 0x000482A4 File Offset: 0x000464A4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSMSSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSMSSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170036B0 RID: 14000
		' (get) Token: 0x0600936B RID: 37739 RVA: 0x000482D6 File Offset: 0x000464D6
		' (set) Token: 0x0600936C RID: 37740 RVA: 0x000482E0 File Offset: 0x000464E0
		Friend Overridable Property Label1 As Label

		' Token: 0x170036B1 RID: 14001
		' (get) Token: 0x0600936D RID: 37741 RVA: 0x000482E9 File Offset: 0x000464E9
		' (set) Token: 0x0600936E RID: 37742 RVA: 0x000482F3 File Offset: 0x000464F3
		Friend Overridable Property Label2 As Label

		' Token: 0x170036B2 RID: 14002
		' (get) Token: 0x0600936F RID: 37743 RVA: 0x000482FC File Offset: 0x000464FC
		' (set) Token: 0x06009370 RID: 37744 RVA: 0x006AB68C File Offset: 0x006A988C
		Private _txtAPIURL As TextBox
		Friend Overridable Property txtAPIURL As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAPIURL
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAPIURL
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAPIURL = value
				textBox = Me._txtAPIURL
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170036B3 RID: 14003
		' (get) Token: 0x06009371 RID: 37745 RVA: 0x00048306 File Offset: 0x00046506
		' (set) Token: 0x06009372 RID: 37746 RVA: 0x00048310 File Offset: 0x00046510
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170036B4 RID: 14004
		' (get) Token: 0x06009373 RID: 37747 RVA: 0x00048319 File Offset: 0x00046519
		' (set) Token: 0x06009374 RID: 37748 RVA: 0x00048323 File Offset: 0x00046523
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x170036B5 RID: 14005
		' (get) Token: 0x06009375 RID: 37749 RVA: 0x0004832C File Offset: 0x0004652C
		' (set) Token: 0x06009376 RID: 37750 RVA: 0x00048336 File Offset: 0x00046536
		Friend Overridable Property chkIsDefault As CheckBox

		' Token: 0x170036B6 RID: 14006
		' (get) Token: 0x06009377 RID: 37751 RVA: 0x0004833F File Offset: 0x0004653F
		' (set) Token: 0x06009378 RID: 37752 RVA: 0x006AB6D0 File Offset: 0x006A98D0
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

		' Token: 0x170036B7 RID: 14007
		' (get) Token: 0x06009379 RID: 37753 RVA: 0x00048349 File Offset: 0x00046549
		' (set) Token: 0x0600937A RID: 37754 RVA: 0x00048353 File Offset: 0x00046553
		Friend Overridable Property txtID As TextBox

		' Token: 0x170036B8 RID: 14008
		' (get) Token: 0x0600937B RID: 37755 RVA: 0x0004835C File Offset: 0x0004655C
		' (set) Token: 0x0600937C RID: 37756 RVA: 0x00048366 File Offset: 0x00046566
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170036B9 RID: 14009
		' (get) Token: 0x0600937D RID: 37757 RVA: 0x0004836F File Offset: 0x0004656F
		' (set) Token: 0x0600937E RID: 37758 RVA: 0x006AB730 File Offset: 0x006A9930
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

		' Token: 0x170036BA RID: 14010
		' (get) Token: 0x0600937F RID: 37759 RVA: 0x00048379 File Offset: 0x00046579
		' (set) Token: 0x06009380 RID: 37760 RVA: 0x006AB774 File Offset: 0x006A9974
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

		' Token: 0x170036BB RID: 14011
		' (get) Token: 0x06009381 RID: 37761 RVA: 0x00048383 File Offset: 0x00046583
		' (set) Token: 0x06009382 RID: 37762 RVA: 0x006AB7B8 File Offset: 0x006A99B8
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

		' Token: 0x170036BC RID: 14012
		' (get) Token: 0x06009383 RID: 37763 RVA: 0x0004838D File Offset: 0x0004658D
		' (set) Token: 0x06009384 RID: 37764 RVA: 0x006AB7FC File Offset: 0x006A99FC
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

		' Token: 0x170036BD RID: 14013
		' (get) Token: 0x06009385 RID: 37765 RVA: 0x00048397 File Offset: 0x00046597
		' (set) Token: 0x06009386 RID: 37766 RVA: 0x000483A1 File Offset: 0x000465A1
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170036BE RID: 14014
		' (get) Token: 0x06009387 RID: 37767 RVA: 0x000483AA File Offset: 0x000465AA
		' (set) Token: 0x06009388 RID: 37768 RVA: 0x000483B4 File Offset: 0x000465B4
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170036BF RID: 14015
		' (get) Token: 0x06009389 RID: 37769 RVA: 0x000483BD File Offset: 0x000465BD
		' (set) Token: 0x0600938A RID: 37770 RVA: 0x000483C7 File Offset: 0x000465C7
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170036C0 RID: 14016
		' (get) Token: 0x0600938B RID: 37771 RVA: 0x000483D0 File Offset: 0x000465D0
		' (set) Token: 0x0600938C RID: 37772 RVA: 0x000483DA File Offset: 0x000465DA
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170036C1 RID: 14017
		' (get) Token: 0x0600938D RID: 37773 RVA: 0x000483E3 File Offset: 0x000465E3
		' (set) Token: 0x0600938E RID: 37774 RVA: 0x000483ED File Offset: 0x000465ED
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170036C2 RID: 14018
		' (get) Token: 0x0600938F RID: 37775 RVA: 0x000483F6 File Offset: 0x000465F6
		' (set) Token: 0x06009390 RID: 37776 RVA: 0x00048400 File Offset: 0x00046600
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170036C3 RID: 14019
		' (get) Token: 0x06009391 RID: 37777 RVA: 0x00048409 File Offset: 0x00046609
		' (set) Token: 0x06009392 RID: 37778 RVA: 0x00048413 File Offset: 0x00046613
		Friend Overridable Property Label7 As Label

		' Token: 0x170036C4 RID: 14020
		' (get) Token: 0x06009393 RID: 37779 RVA: 0x0004841C File Offset: 0x0004661C
		' (set) Token: 0x06009394 RID: 37780 RVA: 0x00048426 File Offset: 0x00046626
		Friend Overridable Property Label6 As Label

		' Token: 0x170036C5 RID: 14021
		' (get) Token: 0x06009395 RID: 37781 RVA: 0x0004842F File Offset: 0x0004662F
		' (set) Token: 0x06009396 RID: 37782 RVA: 0x00048439 File Offset: 0x00046639
		Friend Overridable Property txtPassword As TextBox

		' Token: 0x170036C6 RID: 14022
		' (get) Token: 0x06009397 RID: 37783 RVA: 0x00048442 File Offset: 0x00046642
		' (set) Token: 0x06009398 RID: 37784 RVA: 0x0004844C File Offset: 0x0004664C
		Friend Overridable Property txtUser As TextBox

		' Token: 0x06009399 RID: 37785 RVA: 0x006AB840 File Offset: 0x006A9A40
		Public Sub Reset()
			Me.txtAPIURL.Text = ""
			Me.chkIsDefault.Checked = False
			Me.chkIsEnabled.Checked = True
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
		End Sub

		' Token: 0x0600939A RID: 37786 RVA: 0x006AB8A0 File Offset: 0x006A9AA0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(APIURL), RTRIM(IsEnabled), RTRIM(IsDefault), RTRIM(username), RTRIM(password) from EwaybillAPISetting", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600939B RID: 37787 RVA: 0x00048455 File Offset: 0x00046655
		Private Sub frmSMSSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600939C RID: 37788 RVA: 0x006AB9C8 File Offset: 0x006A9BC8
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

		' Token: 0x0600939D RID: 37789 RVA: 0x006ABB40 File Offset: 0x006A9D40
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

		' Token: 0x0600939E RID: 37790 RVA: 0x006ABBFC File Offset: 0x006A9DFC
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

		' Token: 0x0600939F RID: 37791 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060093A0 RID: 37792 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060093A1 RID: 37793 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060093A2 RID: 37794 RVA: 0x006ABCC8 File Offset: 0x006A9EC8
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from EwaybillAPISetting where ID=@d1"
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

		' Token: 0x060093A3 RID: 37795 RVA: 0x006ABDE8 File Offset: 0x006A9FE8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.txtAPIURL.Text = dataGridViewRow.Cells(1).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(3).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkIsDefault.Checked = True
					Else
						Me.chkIsDefault.Checked = False
					End If
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), "Yes", False) = 0
					If flag3 Then
						Me.chkIsEnabled.Checked = True
					Else
						Me.chkIsEnabled.Checked = False
					End If
					Me.txtUser.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtPassword.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060093A4 RID: 37796 RVA: 0x006ABF94 File Offset: 0x006AA194
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAPIURL.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAPIURL, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAPIURL, String.Empty)
			End If
		End Sub

		' Token: 0x060093A5 RID: 37797 RVA: 0x00048466 File Offset: 0x00046666
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060093A6 RID: 37798 RVA: 0x006ABFF0 File Offset: 0x006AA1F0
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtAPIURL.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter API URL", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtAPIURL.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtUser.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter User", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtUser.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtPassword.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter Password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtPassword.Focus()
					Else
						Try
							Dim checked As Boolean = Me.chkIsDefault.Checked
							If checked Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update EwaybillAPISetting set IsDefault='No'"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
							End If
							Dim checked2 As Boolean = Me.chkIsDefault.Checked
							If checked2 Then
								Me.st1 = "Yes"
							Else
								Me.st1 = "No"
							End If
							Dim checked3 As Boolean = Me.chkIsEnabled.Checked
							If checked3 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Update EwaybillAPISetting set APIURL=@d1,IsDefault=@d2,IsEnabled=@d3,username=@d4,password=@d5 where ID=" + Me.txtID.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAPIURL.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtUser.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtPassword.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							Me.Getdata()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060093A7 RID: 37799 RVA: 0x006AC2E0 File Offset: 0x006AA4E0
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

		' Token: 0x060093A8 RID: 37800 RVA: 0x006AC348 File Offset: 0x006AA548
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtAPIURL.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter API URL", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAPIURL.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtUser.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please enter User", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtUser.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtPassword.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please enter Password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtPassword.Focus()
						Else
							Try
								Dim checked As Boolean = Me.chkIsDefault.Checked
								If checked Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select IsDefault from EwaybillAPISetting where IsDefault='Yes'"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
									If flag6 Then
										MessageBox.Show("Other HTTP API is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag7 Then
											ModCommonClasses.rdr.Close()
										End If
										Return
									End If
								End If
								Dim checked2 As Boolean = Me.chkIsDefault.Checked
								If checked2 Then
									Me.st1 = "Yes"
								Else
									Me.st1 = "No"
								End If
								Dim checked3 As Boolean = Me.chkIsEnabled.Checked
								If checked3 Then
									Me.st2 = "Yes"
								Else
									Me.st2 = "No"
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into EwaybillAPISetting(APIURL,IsDefault,IsEnabled,username,password) VALUES (@d1,@d2,@d3,@d4,@d5)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAPIURL.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtUser.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtPassword.Text)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Getdata()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060093A9 RID: 37801 RVA: 0x006AC708 File Offset: 0x006AA908
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

		' Token: 0x060093AA RID: 37802 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x04004163 RID: 16739
		Private st1 As String

		' Token: 0x04004164 RID: 16740
		Private st2 As String

		' Token: 0x04004165 RID: 16741
		Private st3 As String
	End Class
End Namespace
