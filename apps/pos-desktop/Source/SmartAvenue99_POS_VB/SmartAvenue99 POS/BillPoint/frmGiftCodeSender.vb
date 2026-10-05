Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000116 RID: 278
	<DesignerGenerated()>
	Public Partial Class frmGiftCodeSender
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002FA0 RID: 12192 RVA: 0x001D5440 File Offset: 0x001D3640
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGiftCodeSender_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmGiftCodeSender_FormClosing
			AddHandler MyBase.KeyDown, AddressOf Me.frmGiftCodeSender_KeyDown
			Me.sts = ""
			Me.sts2 = ""
			Me.cmpnm = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001291 RID: 4753
		' (get) Token: 0x06002FA3 RID: 12195 RVA: 0x0001DE98 File Offset: 0x0001C098
		' (set) Token: 0x06002FA4 RID: 12196 RVA: 0x0001DEA2 File Offset: 0x0001C0A2
		Friend Overridable Property Label1 As Label

		' Token: 0x17001292 RID: 4754
		' (get) Token: 0x06002FA5 RID: 12197 RVA: 0x0001DEAB File Offset: 0x0001C0AB
		' (set) Token: 0x06002FA6 RID: 12198 RVA: 0x0001DEB5 File Offset: 0x0001C0B5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001293 RID: 4755
		' (get) Token: 0x06002FA7 RID: 12199 RVA: 0x0001DEBE File Offset: 0x0001C0BE
		' (set) Token: 0x06002FA8 RID: 12200 RVA: 0x001D69E0 File Offset: 0x001D4BE0
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001294 RID: 4756
		' (get) Token: 0x06002FA9 RID: 12201 RVA: 0x0001DEC8 File Offset: 0x0001C0C8
		' (set) Token: 0x06002FAA RID: 12202 RVA: 0x001D6A24 File Offset: 0x001D4C24
		Private _Start As Button
		Friend Overridable Property Start As Button
			<CompilerGenerated()>
			Get
				Return Me._Start
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Start_Click
				Dim button As Button = Me._Start
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Start = value
				button = Me._Start
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001295 RID: 4757
		' (get) Token: 0x06002FAB RID: 12203 RVA: 0x0001DED2 File Offset: 0x0001C0D2
		' (set) Token: 0x06002FAC RID: 12204 RVA: 0x001D6A68 File Offset: 0x001D4C68
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001296 RID: 4758
		' (get) Token: 0x06002FAD RID: 12205 RVA: 0x0001DEDC File Offset: 0x0001C0DC
		' (set) Token: 0x06002FAE RID: 12206 RVA: 0x0001DEE6 File Offset: 0x0001C0E6
		Friend Overridable Property Label2 As Label

		' Token: 0x17001297 RID: 4759
		' (get) Token: 0x06002FAF RID: 12207 RVA: 0x0001DEEF File Offset: 0x0001C0EF
		' (set) Token: 0x06002FB0 RID: 12208 RVA: 0x001D6AAC File Offset: 0x001D4CAC
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001298 RID: 4760
		' (get) Token: 0x06002FB1 RID: 12209 RVA: 0x0001DEF9 File Offset: 0x0001C0F9
		' (set) Token: 0x06002FB2 RID: 12210 RVA: 0x0001DF03 File Offset: 0x0001C103
		Friend Overridable Property Label10 As Label

		' Token: 0x17001299 RID: 4761
		' (get) Token: 0x06002FB3 RID: 12211 RVA: 0x0001DF0C File Offset: 0x0001C10C
		' (set) Token: 0x06002FB4 RID: 12212 RVA: 0x0001DF16 File Offset: 0x0001C116
		Friend Overridable Property Label6 As Label

		' Token: 0x1700129A RID: 4762
		' (get) Token: 0x06002FB5 RID: 12213 RVA: 0x0001DF1F File Offset: 0x0001C11F
		' (set) Token: 0x06002FB6 RID: 12214 RVA: 0x0001DF29 File Offset: 0x0001C129
		Friend Overridable Property Label5 As Label

		' Token: 0x1700129B RID: 4763
		' (get) Token: 0x06002FB7 RID: 12215 RVA: 0x0001DF32 File Offset: 0x0001C132
		' (set) Token: 0x06002FB8 RID: 12216 RVA: 0x0001DF3C File Offset: 0x0001C13C
		Friend Overridable Property Label4 As Label

		' Token: 0x1700129C RID: 4764
		' (get) Token: 0x06002FB9 RID: 12217 RVA: 0x0001DF45 File Offset: 0x0001C145
		' (set) Token: 0x06002FBA RID: 12218 RVA: 0x0001DF4F File Offset: 0x0001C14F
		Friend Overridable Property Label3 As Label

		' Token: 0x1700129D RID: 4765
		' (get) Token: 0x06002FBB RID: 12219 RVA: 0x0001DF58 File Offset: 0x0001C158
		' (set) Token: 0x06002FBC RID: 12220 RVA: 0x0001DF62 File Offset: 0x0001C162
		Friend Overridable Property Label7 As Label

		' Token: 0x1700129E RID: 4766
		' (get) Token: 0x06002FBD RID: 12221 RVA: 0x0001DF6B File Offset: 0x0001C16B
		' (set) Token: 0x06002FBE RID: 12222 RVA: 0x0001DF75 File Offset: 0x0001C175
		Friend Overridable Property Label8 As Label

		' Token: 0x1700129F RID: 4767
		' (get) Token: 0x06002FBF RID: 12223 RVA: 0x0001DF7E File Offset: 0x0001C17E
		' (set) Token: 0x06002FC0 RID: 12224 RVA: 0x0001DF88 File Offset: 0x0001C188
		Friend Overridable Property Label9 As Label

		' Token: 0x170012A0 RID: 4768
		' (get) Token: 0x06002FC1 RID: 12225 RVA: 0x0001DF91 File Offset: 0x0001C191
		' (set) Token: 0x06002FC2 RID: 12226 RVA: 0x0001DF9B File Offset: 0x0001C19B
		Friend Overridable Property Label11 As Label

		' Token: 0x170012A1 RID: 4769
		' (get) Token: 0x06002FC3 RID: 12227 RVA: 0x0001DFA4 File Offset: 0x0001C1A4
		' (set) Token: 0x06002FC4 RID: 12228 RVA: 0x0001DFAE File Offset: 0x0001C1AE
		Friend Overridable Property Label12 As Label

		' Token: 0x170012A2 RID: 4770
		' (get) Token: 0x06002FC5 RID: 12229 RVA: 0x0001DFB7 File Offset: 0x0001C1B7
		' (set) Token: 0x06002FC6 RID: 12230 RVA: 0x0001DFC1 File Offset: 0x0001C1C1
		Friend Overridable Property Label13 As Label

		' Token: 0x170012A3 RID: 4771
		' (get) Token: 0x06002FC7 RID: 12231 RVA: 0x0001DFCA File Offset: 0x0001C1CA
		' (set) Token: 0x06002FC8 RID: 12232 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
		Friend Overridable Property Label14 As Label

		' Token: 0x170012A4 RID: 4772
		' (get) Token: 0x06002FC9 RID: 12233 RVA: 0x0001DFDD File Offset: 0x0001C1DD
		' (set) Token: 0x06002FCA RID: 12234 RVA: 0x0001DFE7 File Offset: 0x0001C1E7
		Friend Overridable Property Label20 As Label

		' Token: 0x170012A5 RID: 4773
		' (get) Token: 0x06002FCB RID: 12235 RVA: 0x0001DFF0 File Offset: 0x0001C1F0
		' (set) Token: 0x06002FCC RID: 12236 RVA: 0x0001DFFA File Offset: 0x0001C1FA
		Friend Overridable Property Label19 As Label

		' Token: 0x170012A6 RID: 4774
		' (get) Token: 0x06002FCD RID: 12237 RVA: 0x0001E003 File Offset: 0x0001C203
		' (set) Token: 0x06002FCE RID: 12238 RVA: 0x0001E00D File Offset: 0x0001C20D
		Friend Overridable Property Label18 As Label

		' Token: 0x170012A7 RID: 4775
		' (get) Token: 0x06002FCF RID: 12239 RVA: 0x0001E016 File Offset: 0x0001C216
		' (set) Token: 0x06002FD0 RID: 12240 RVA: 0x0001E020 File Offset: 0x0001C220
		Friend Overridable Property Label17 As Label

		' Token: 0x170012A8 RID: 4776
		' (get) Token: 0x06002FD1 RID: 12241 RVA: 0x0001E029 File Offset: 0x0001C229
		' (set) Token: 0x06002FD2 RID: 12242 RVA: 0x0001E033 File Offset: 0x0001C233
		Friend Overridable Property Label16 As Label

		' Token: 0x170012A9 RID: 4777
		' (get) Token: 0x06002FD3 RID: 12243 RVA: 0x0001E03C File Offset: 0x0001C23C
		' (set) Token: 0x06002FD4 RID: 12244 RVA: 0x0001E046 File Offset: 0x0001C246
		Friend Overridable Property Label15 As Label

		' Token: 0x06002FD5 RID: 12245 RVA: 0x001D6AF0 File Offset: 0x001D4CF0
		Public Sub InvNo_Giftcard()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(InvNo) from GiftInfo where Status='NOT USED' order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.ComboBox1.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox1.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002FD6 RID: 12246 RVA: 0x001D6BF4 File Offset: 0x001D4DF4
		Private Sub frmGiftCodeSender_Load(sender As Object, e As EventArgs)
			Me.statusdisplay()
			Me.GetCompanyState()
			Me.InvNo_Giftcard()
			Me.ComboBox1.DropDownHeight = 200
			Me.ComboBox1.DropDownWidth = 400
			Me.Convert_Language()
		End Sub

		' Token: 0x06002FD7 RID: 12247 RVA: 0x001D6C40 File Offset: 0x001D4E40
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin = @lang_hin"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@lang_hin", GlobalVariables.LoggedInLang_code)
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
						Me.UpdateControlsRecursive(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06002FD8 RID: 12248 RVA: 0x001D6DF4 File Offset: 0x001D4FF4
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

		' Token: 0x06002FD9 RID: 12249 RVA: 0x001D6EB0 File Offset: 0x001D50B0
		Private Sub UpdateControlsRecursive(parent As Control)
			Try
				For Each obj As Object In parent.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateControlsRecursive(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06002FDA RID: 12250 RVA: 0x000B726C File Offset: 0x000B546C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(dataGridViewColumn.HeaderText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(dataGridViewColumn.HeaderText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06002FDB RID: 12251 RVA: 0x000B72F4 File Offset: 0x000B54F4
		Private Sub UpdateListViewHeaders(lv As ListView)
			Try
				For Each obj As Object In lv.Columns
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
			Try
				For Each obj2 As Object In lv.Items
					Dim listViewItem As ListViewItem = CType(obj2, ListViewItem)
					Dim flag2 As Boolean = GlobalVariables.translations.ContainsKey(listViewItem.Text)
					If flag2 Then
						listViewItem.Text = GlobalVariables.translations(listViewItem.Text)
					End If
					Try
						For Each obj3 As Object In listViewItem.SubItems
							Dim listViewSubItem As ListViewItem.ListViewSubItem = CType(obj3, ListViewItem.ListViewSubItem)
							Dim flag3 As Boolean = GlobalVariables.translations.ContainsKey(listViewSubItem.Text)
							If flag3 Then
								listViewSubItem.Text = GlobalVariables.translations(listViewSubItem.Text)
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
		End Sub

		' Token: 0x06002FDC RID: 12252 RVA: 0x001D6F5C File Offset: 0x001D515C
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.sts = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002FDD RID: 12253 RVA: 0x001D7050 File Offset: 0x001D5250
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmpnm = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.cmpnm = ""
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002FDE RID: 12254 RVA: 0x001D7148 File Offset: 0x001D5348
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.Label7.Text = ""
			Me.Label3.Text = ""
			Me.Label10.Text = ""
			Me.Label4.Text = ""
			Me.Label6.Text = ""
			Me.Label5.Text = ""
		End Sub

		' Token: 0x06002FDF RID: 12255 RVA: 0x0001E04F File Offset: 0x0001C24F
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06002FE0 RID: 12256 RVA: 0x001D71CC File Offset: 0x001D53CC
		Private Sub Start_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Gift")
			If flag Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Gift\")
			End If
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\Gift"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
			Dim flag2 As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag2 Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag3 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag3 Then
					Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
				Else
					Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select the invoice number", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ComboBox1.Focus()
					Else
						Me.Gift_Print1()
						Me.WAPP_GIFTCARD()
					End If
				End If
			End If
		End Sub

		' Token: 0x06002FE1 RID: 12257 RVA: 0x001D7300 File Offset: 0x001D5500
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
				ModCommonClasses.cmd1.CommandText = "SELECT RTRIM(CustName),RTRIM(Contact),(GiftAmt),RTRIM(Status),(Validfrom),(Validto),RTRIM(GiftCode) from GiftInfo where InvNo=@d1"
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.ComboBox1.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.Label7.Text = ModCommonClasses.rdr1.GetValue(0).ToString()
					Me.Label3.Text = ModCommonClasses.rdr1.GetValue(1).ToString()
					Me.Label10.Text = ModCommonClasses.rdr1.GetValue(6).ToString()
					Me.Label4.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
					Me.Label6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(ModCommonClasses.rdr1.GetValue(4), " To "), ModCommonClasses.rdr1.GetValue(5)))
					Me.Label5.Text = ModCommonClasses.rdr1.GetValue(3).ToString()
				Else
					Me.Label7.Text = ""
					Me.Label3.Text = ""
					Me.Label10.Text = ""
					Me.Label4.Text = ""
					Me.Label6.Text = ""
					Me.Label5.Text = ""
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr1.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con1.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002FE2 RID: 12258 RVA: 0x001D7568 File Offset: 0x001D5768
		Public Sub Gift_Print1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT CID, CustID, CustName, InvNo, InvDate, BillAmt, GiftCode, GiftAmt, Validfrom, Validto, Status, Contact FROM GiftInfo where InvNo=@d1 and Status='NOT USED'"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Dim text2 As String = ModCommonClasses.rdr1.GetValue(2).ToString()
					Dim text3 As String = ModCommonClasses.rdr1.GetValue(11).ToString()
					Dim text4 As String = ModCommonClasses.rdr1.GetValue(6).ToString()
					Dim text5 As String = ModCommonClasses.rdr1.GetValue(7).ToString()
					Dim text6 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(ModCommonClasses.rdr1.GetValue(8), " To "), ModCommonClasses.rdr1.GetValue(9)))
					Try
						Dim reportDocument As ReportDocument = New ReportDocument()
						reportDocument.Load(MyProject.Application.Info.DirectoryPath + "\CryReport\CryGift.rpt")
						reportDocument.SetParameterValue("Name", text2)
						reportDocument.SetParameterValue("Contact", text3)
						reportDocument.SetParameterValue("GiftCode", text4)
						reportDocument.SetParameterValue("GiftAmt", text5)
						reportDocument.SetParameterValue("Validity", text6)
						Dim flag2 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Gift")
						If flag2 Then
							Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Gift\")
						End If
						Dim text7 As String = MyProject.Application.Info.DirectoryPath + "\Gift"
						For Each text8 As String In Directory.GetFiles(text7, "*.*", SearchOption.TopDirectoryOnly)
							File.Delete(text8)
						Next
						reportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, MyProject.Application.Info.DirectoryPath + "\Gift\Gift_Card.Pdf")
						reportDocument.Close()
						reportDocument.Dispose()
					Catch ex As Exception
					End Try
					Dim flag3 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr1.Close()
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con1.Close()
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002FE3 RID: 12259 RVA: 0x001D7850 File Offset: 0x001D5A50
		Private Async Sub WAPP_GIFTCARD()
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) = 0
			If flag Then
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Dim stw As String = String.Format("Dear, {0}, Thank you for purchasing from us. Please find herewith the digital gift card, Redeem this gift card on your next purchase,  _Best wishes from : *{1}*_", Me.Label7.Text.TrimEnd(New Char(-1) {}), Me.cmpnm.TrimEnd(New Char(-1) {}))
					Try
						Dim path As String = ""
						Dim attach As String = MyProject.Application.Info.DirectoryPath + "\Gift\Gift_Card.Pdf"
						Dim dt As DataTable = New DataTable()
						dt = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
						Dim client As WebClient = New WebClient()
						Dim countryCode As String = dt.Rows(0)("c1").ToString()
						client.Credentials = New NetworkCredential(dt.Rows(0)("FtpUser").ToString(), dt.Rows(0)("FtpPassword").ToString())
						Dim filename As String = attach.Split(New Char() { "/"c }).Last()
						Dim flag3 As Boolean = filename.ToUpper().Contains(".PDF")
						If flag3 Then
							Me.Name = "Gift_Card.pdf"
						Else
							Dim flag4 As Boolean = filename.ToUpper().Contains(".PNG")
							If flag4 Then
								Me.Name = "Gift_Card.png"
							Else
								Me.Name = "Gift_Card.jpg"
							End If
						End If
						Dim tmpDir As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\" + frmLogin.InstanceID
						Me.Timer1.Enabled = True
						Dim flag5 As Boolean = clswhatsApp.CreateFtpFolder(tmpDir, frmLogin.InstanceID, dt, Me.Name, path, attach, client, countryCode + Me.Label3.Text, stw, "")
						If flag5 Then
							MessageBox.Show("Gift Card")
						End If
					Catch ex As Exception
						Dim exception As Exception = ex
						MessageBox.Show(exception.Message)
					End Try
				Else
					MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06002FE4 RID: 12260 RVA: 0x001D788C File Offset: 0x001D5A8C
		Private Sub frmGiftCodeSender_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Gift")
			If flag Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Gift\")
			End If
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\Gift"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
		End Sub

		' Token: 0x06002FE5 RID: 12261 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGiftCodeSender_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400146C RID: 5228
		Private sts As String

		' Token: 0x0400146D RID: 5229
		Private sts2 As String

		' Token: 0x0400146E RID: 5230
		Private cmpnm As String
	End Class
End Namespace
