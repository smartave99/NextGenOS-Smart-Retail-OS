Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005C7 RID: 1479
	<DesignerGenerated()>
	Public Partial Class frmSMSSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011FE5 RID: 73701 RVA: 0x0007B568 File Offset: 0x00079768
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSMSSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSMSSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006FC2 RID: 28610
		' (get) Token: 0x06011FE8 RID: 73704 RVA: 0x0007B59A File Offset: 0x0007979A
		' (set) Token: 0x06011FE9 RID: 73705 RVA: 0x0007B5A4 File Offset: 0x000797A4
		Friend Overridable Property Label1 As Label

		' Token: 0x17006FC3 RID: 28611
		' (get) Token: 0x06011FEA RID: 73706 RVA: 0x0007B5AD File Offset: 0x000797AD
		' (set) Token: 0x06011FEB RID: 73707 RVA: 0x0007B5B7 File Offset: 0x000797B7
		Friend Overridable Property Label2 As Label

		' Token: 0x17006FC4 RID: 28612
		' (get) Token: 0x06011FEC RID: 73708 RVA: 0x0007B5C0 File Offset: 0x000797C0
		' (set) Token: 0x06011FED RID: 73709 RVA: 0x00A5E268 File Offset: 0x00A5C468
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

		' Token: 0x17006FC5 RID: 28613
		' (get) Token: 0x06011FEE RID: 73710 RVA: 0x0007B5CA File Offset: 0x000797CA
		' (set) Token: 0x06011FEF RID: 73711 RVA: 0x0007B5D4 File Offset: 0x000797D4
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006FC6 RID: 28614
		' (get) Token: 0x06011FF0 RID: 73712 RVA: 0x0007B5DD File Offset: 0x000797DD
		' (set) Token: 0x06011FF1 RID: 73713 RVA: 0x0007B5E7 File Offset: 0x000797E7
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x17006FC7 RID: 28615
		' (get) Token: 0x06011FF2 RID: 73714 RVA: 0x0007B5F0 File Offset: 0x000797F0
		' (set) Token: 0x06011FF3 RID: 73715 RVA: 0x0007B5FA File Offset: 0x000797FA
		Friend Overridable Property chkIsDefault As CheckBox

		' Token: 0x17006FC8 RID: 28616
		' (get) Token: 0x06011FF4 RID: 73716 RVA: 0x0007B603 File Offset: 0x00079803
		' (set) Token: 0x06011FF5 RID: 73717 RVA: 0x00A5E2AC File Offset: 0x00A5C4AC
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

		' Token: 0x17006FC9 RID: 28617
		' (get) Token: 0x06011FF6 RID: 73718 RVA: 0x0007B60D File Offset: 0x0007980D
		' (set) Token: 0x06011FF7 RID: 73719 RVA: 0x0007B617 File Offset: 0x00079817
		Friend Overridable Property Label3 As Label

		' Token: 0x17006FCA RID: 28618
		' (get) Token: 0x06011FF8 RID: 73720 RVA: 0x0007B620 File Offset: 0x00079820
		' (set) Token: 0x06011FF9 RID: 73721 RVA: 0x0007B62A File Offset: 0x0007982A
		Friend Overridable Property Label4 As Label

		' Token: 0x17006FCB RID: 28619
		' (get) Token: 0x06011FFA RID: 73722 RVA: 0x0007B633 File Offset: 0x00079833
		' (set) Token: 0x06011FFB RID: 73723 RVA: 0x0007B63D File Offset: 0x0007983D
		Friend Overridable Property Label5 As Label

		' Token: 0x17006FCC RID: 28620
		' (get) Token: 0x06011FFC RID: 73724 RVA: 0x0007B646 File Offset: 0x00079846
		' (set) Token: 0x06011FFD RID: 73725 RVA: 0x0007B650 File Offset: 0x00079850
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006FCD RID: 28621
		' (get) Token: 0x06011FFE RID: 73726 RVA: 0x0007B659 File Offset: 0x00079859
		' (set) Token: 0x06011FFF RID: 73727 RVA: 0x0007B663 File Offset: 0x00079863
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17006FCE RID: 28622
		' (get) Token: 0x06012000 RID: 73728 RVA: 0x0007B66C File Offset: 0x0007986C
		' (set) Token: 0x06012001 RID: 73729 RVA: 0x0007B676 File Offset: 0x00079876
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006FCF RID: 28623
		' (get) Token: 0x06012002 RID: 73730 RVA: 0x0007B67F File Offset: 0x0007987F
		' (set) Token: 0x06012003 RID: 73731 RVA: 0x0007B689 File Offset: 0x00079889
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006FD0 RID: 28624
		' (get) Token: 0x06012004 RID: 73732 RVA: 0x0007B692 File Offset: 0x00079892
		' (set) Token: 0x06012005 RID: 73733 RVA: 0x0007B69C File Offset: 0x0007989C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006FD1 RID: 28625
		' (get) Token: 0x06012006 RID: 73734 RVA: 0x0007B6A5 File Offset: 0x000798A5
		' (set) Token: 0x06012007 RID: 73735 RVA: 0x0007B6AF File Offset: 0x000798AF
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006FD2 RID: 28626
		' (get) Token: 0x06012008 RID: 73736 RVA: 0x0007B6B8 File Offset: 0x000798B8
		' (set) Token: 0x06012009 RID: 73737 RVA: 0x0007B6C2 File Offset: 0x000798C2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006FD3 RID: 28627
		' (get) Token: 0x0601200A RID: 73738 RVA: 0x0007B6CB File Offset: 0x000798CB
		' (set) Token: 0x0601200B RID: 73739 RVA: 0x0007B6D5 File Offset: 0x000798D5
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006FD4 RID: 28628
		' (get) Token: 0x0601200C RID: 73740 RVA: 0x0007B6DE File Offset: 0x000798DE
		' (set) Token: 0x0601200D RID: 73741 RVA: 0x00A5E30C File Offset: 0x00A5C50C
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

		' Token: 0x17006FD5 RID: 28629
		' (get) Token: 0x0601200E RID: 73742 RVA: 0x0007B6E8 File Offset: 0x000798E8
		' (set) Token: 0x0601200F RID: 73743 RVA: 0x00A5E350 File Offset: 0x00A5C550
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

		' Token: 0x17006FD6 RID: 28630
		' (get) Token: 0x06012010 RID: 73744 RVA: 0x0007B6F2 File Offset: 0x000798F2
		' (set) Token: 0x06012011 RID: 73745 RVA: 0x00A5E394 File Offset: 0x00A5C594
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

		' Token: 0x17006FD7 RID: 28631
		' (get) Token: 0x06012012 RID: 73746 RVA: 0x0007B6FC File Offset: 0x000798FC
		' (set) Token: 0x06012013 RID: 73747 RVA: 0x00A5E3D8 File Offset: 0x00A5C5D8
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

		' Token: 0x06012014 RID: 73748 RVA: 0x00A5E41C File Offset: 0x00A5C61C
		Public Sub Reset()
			Me.txtAPIURL.Text = ""
			Me.chkIsDefault.Checked = False
			Me.chkIsEnabled.Checked = True
			Me.CheckBox1.Checked = True
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
		End Sub

		' Token: 0x06012015 RID: 73749 RVA: 0x00A5E48C File Offset: 0x00A5C68C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(APIURL), RTRIM(IsEnabled), RTRIM(IsDefault), RTRIM(AutoSMS) from SMSSetting", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012016 RID: 73750 RVA: 0x00A5E5A8 File Offset: 0x00A5C7A8
		Private Sub frmSMSSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
			Dim text As String = "NWE1NTQzNGQ0NDZjNzM0NDRkMzg2NzZlNWE2NjRlMzQ="
			Dim text2 As String = "Hello"
			Dim text3 As String = "8005859110"
			Dim text4 As String = "RAINTE"
			Dim text5 As String = If(("https://api.textlocal.in/send/?apikey=" + text + "&numbers=@MobileNo&message=@Message&sender=" + text4), "")
			Dim text6 As String = text5.Replace("@Mobile", "91" + text3).Replace("@Message", System.Web.HttpUtility.UrlEncode(text2))
			Me.txtAPIURL.Text = text5.ToString()
		End Sub

		' Token: 0x06012017 RID: 73751 RVA: 0x00A5E638 File Offset: 0x00A5C838
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

		' Token: 0x06012018 RID: 73752 RVA: 0x00A5E7B0 File Offset: 0x00A5C9B0
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

		' Token: 0x06012019 RID: 73753 RVA: 0x00A5E86C File Offset: 0x00A5CA6C
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

		' Token: 0x0601201A RID: 73754 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601201B RID: 73755 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601201C RID: 73756 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601201D RID: 73757 RVA: 0x00A5E938 File Offset: 0x00A5CB38
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from SMSSetting where ID=@d1"
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

		' Token: 0x0601201E RID: 73758 RVA: 0x00A5EA58 File Offset: 0x00A5CC58
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
					Dim flag4 As Boolean = Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString(), "Yes", False) = 0
					If flag4 Then
						Me.CheckBox1.Checked = True
					Else
						Me.CheckBox1.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601201F RID: 73759 RVA: 0x00A5EC08 File Offset: 0x00A5CE08
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAPIURL.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAPIURL, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAPIURL, String.Empty)
			End If
		End Sub

		' Token: 0x06012020 RID: 73760 RVA: 0x0007B706 File Offset: 0x00079906
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012021 RID: 73761 RVA: 0x00A5EC64 File Offset: 0x00A5CE64
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtAPIURL.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter API URL", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtAPIURL.Focus()
			Else
				Try
					Dim checked As Boolean = Me.chkIsDefault.Checked
					If checked Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update SMSSetting set IsDefault='No'"
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
					Dim checked4 As Boolean = Me.CheckBox1.Checked
					If checked4 Then
						Me.st4 = "Yes"
					Else
						Me.st4 = "No"
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = If(("Update SMSSetting set APIURL=@d1,IsDefault=@d2,IsEnabled=@d3,AutoSMS=@d4 where ID=" + Me.txtID.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAPIURL.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st4)
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

		' Token: 0x06012022 RID: 73762 RVA: 0x00A5EED8 File Offset: 0x00A5D0D8
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

		' Token: 0x06012023 RID: 73763 RVA: 0x00A5EF40 File Offset: 0x00A5D140
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
					Try
						Dim checked As Boolean = Me.chkIsDefault.Checked
						If checked Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select IsDefault from SMSSetting where IsDefault='Yes'"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Other HTTP API is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
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
						Dim checked4 As Boolean = Me.CheckBox1.Checked
						If checked4 Then
							Me.st4 = "Yes"
						Else
							Me.st4 = "No"
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "insert into SMSSetting(APIURL,IsDefault,IsEnabled,AutoSMS) VALUES (@d1,@d2,@d3,@d4)"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAPIURL.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st4)
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
		End Sub

		' Token: 0x06012024 RID: 73764 RVA: 0x00A5F284 File Offset: 0x00A5D484
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

		' Token: 0x06012025 RID: 73765 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x04006C28 RID: 27688
		Private st1 As String

		' Token: 0x04006C29 RID: 27689
		Private st2 As String

		' Token: 0x04006C2A RID: 27690
		Private st3 As String

		' Token: 0x04006C2B RID: 27691
		Private st4 As String
	End Class
End Namespace
