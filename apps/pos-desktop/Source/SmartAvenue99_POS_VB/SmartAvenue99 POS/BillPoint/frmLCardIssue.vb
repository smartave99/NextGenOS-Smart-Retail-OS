Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020004CF RID: 1231
	<DesignerGenerated()>
	Public Partial Class frmLCardIssue
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FAF3 RID: 64243 RVA: 0x009648D4 File Offset: 0x00962AD4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLCardIssue_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmLCardIssue_KeyDown
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700600E RID: 24590
		' (get) Token: 0x0600FAF6 RID: 64246 RVA: 0x0006E04B File Offset: 0x0006C24B
		' (set) Token: 0x0600FAF7 RID: 64247 RVA: 0x0006E055 File Offset: 0x0006C255
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700600F RID: 24591
		' (get) Token: 0x0600FAF8 RID: 64248 RVA: 0x0006E05E File Offset: 0x0006C25E
		' (set) Token: 0x0600FAF9 RID: 64249 RVA: 0x0006E068 File Offset: 0x0006C268
		Friend Overridable Property Label15 As Label

		' Token: 0x17006010 RID: 24592
		' (get) Token: 0x0600FAFA RID: 64250 RVA: 0x0006E071 File Offset: 0x0006C271
		' (set) Token: 0x0600FAFB RID: 64251 RVA: 0x009661A0 File Offset: 0x009643A0
		Private _txtBank As TextBox
		Friend Overridable Property txtBank As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBank
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBank_KeyDown
				Dim textBox As TextBox = Me._txtBank
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBank = value
				textBox = Me._txtBank
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006011 RID: 24593
		' (get) Token: 0x0600FAFC RID: 64252 RVA: 0x0006E07B File Offset: 0x0006C27B
		' (set) Token: 0x0600FAFD RID: 64253 RVA: 0x009661E4 File Offset: 0x009643E4
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006012 RID: 24594
		' (get) Token: 0x0600FAFE RID: 64254 RVA: 0x0006E085 File Offset: 0x0006C285
		' (set) Token: 0x0600FAFF RID: 64255 RVA: 0x0006E08F File Offset: 0x0006C28F
		Friend Overridable Property Label14 As Label

		' Token: 0x17006013 RID: 24595
		' (get) Token: 0x0600FB00 RID: 64256 RVA: 0x0006E098 File Offset: 0x0006C298
		' (set) Token: 0x0600FB01 RID: 64257 RVA: 0x0006E0A2 File Offset: 0x0006C2A2
		Friend Overridable Property Label5 As Label

		' Token: 0x17006014 RID: 24596
		' (get) Token: 0x0600FB02 RID: 64258 RVA: 0x0006E0AB File Offset: 0x0006C2AB
		' (set) Token: 0x0600FB03 RID: 64259 RVA: 0x00966228 File Offset: 0x00964428
		Private _txtSwiftCode As TextBox
		Friend Overridable Property txtSwiftCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSwiftCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSwiftCode_KeyDown
				Dim textBox As TextBox = Me._txtSwiftCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSwiftCode = value
				textBox = Me._txtSwiftCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006015 RID: 24597
		' (get) Token: 0x0600FB04 RID: 64260 RVA: 0x0006E0B5 File Offset: 0x0006C2B5
		' (set) Token: 0x0600FB05 RID: 64261 RVA: 0x0096626C File Offset: 0x0096446C
		Private _txtIFSCCode As TextBox
		Friend Overridable Property txtIFSCCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIFSCCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIFSCCode_KeyDown
				Dim textBox As TextBox = Me._txtIFSCCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIFSCCode = value
				textBox = Me._txtIFSCCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006016 RID: 24598
		' (get) Token: 0x0600FB06 RID: 64262 RVA: 0x0006E0BF File Offset: 0x0006C2BF
		' (set) Token: 0x0600FB07 RID: 64263 RVA: 0x0006E0C9 File Offset: 0x0006C2C9
		Friend Overridable Property Label6 As Label

		' Token: 0x17006017 RID: 24599
		' (get) Token: 0x0600FB08 RID: 64264 RVA: 0x0006E0D2 File Offset: 0x0006C2D2
		' (set) Token: 0x0600FB09 RID: 64265 RVA: 0x009662B0 File Offset: 0x009644B0
		Private _txtBranchName As TextBox
		Friend Overridable Property txtBranchName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBranchName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBranchName_KeyDown
				Dim textBox As TextBox = Me._txtBranchName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBranchName = value
				textBox = Me._txtBranchName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006018 RID: 24600
		' (get) Token: 0x0600FB0A RID: 64266 RVA: 0x0006E0DC File Offset: 0x0006C2DC
		' (set) Token: 0x0600FB0B RID: 64267 RVA: 0x0006E0E6 File Offset: 0x0006C2E6
		Friend Overridable Property Label7 As Label

		' Token: 0x17006019 RID: 24601
		' (get) Token: 0x0600FB0C RID: 64268 RVA: 0x0006E0EF File Offset: 0x0006C2EF
		' (set) Token: 0x0600FB0D RID: 64269 RVA: 0x0006E0F9 File Offset: 0x0006C2F9
		Friend Overridable Property Label12 As Label

		' Token: 0x1700601A RID: 24602
		' (get) Token: 0x0600FB0E RID: 64270 RVA: 0x0006E102 File Offset: 0x0006C302
		' (set) Token: 0x0600FB0F RID: 64271 RVA: 0x009662F4 File Offset: 0x009644F4
		Private _txtAccountName As TextBox
		Friend Overridable Property txtAccountName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccountName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAccountName_KeyDown
				Dim textBox As TextBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAccountName = value
				textBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700601B RID: 24603
		' (get) Token: 0x0600FB10 RID: 64272 RVA: 0x0006E10C File Offset: 0x0006C30C
		' (set) Token: 0x0600FB11 RID: 64273 RVA: 0x0006E116 File Offset: 0x0006C316
		Friend Overridable Property Label3 As Label

		' Token: 0x1700601C RID: 24604
		' (get) Token: 0x0600FB12 RID: 64274 RVA: 0x0006E11F File Offset: 0x0006C31F
		' (set) Token: 0x0600FB13 RID: 64275 RVA: 0x0006E129 File Offset: 0x0006C329
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700601D RID: 24605
		' (get) Token: 0x0600FB14 RID: 64276 RVA: 0x0006E132 File Offset: 0x0006C332
		' (set) Token: 0x0600FB15 RID: 64277 RVA: 0x0006E13C File Offset: 0x0006C33C
		Friend Overridable Property lblUser As Label

		' Token: 0x1700601E RID: 24606
		' (get) Token: 0x0600FB16 RID: 64278 RVA: 0x0006E145 File Offset: 0x0006C345
		' (set) Token: 0x0600FB17 RID: 64279 RVA: 0x0006E14F File Offset: 0x0006C34F
		Friend Overridable Property Label1 As Label

		' Token: 0x1700601F RID: 24607
		' (get) Token: 0x0600FB18 RID: 64280 RVA: 0x0006E158 File Offset: 0x0006C358
		' (set) Token: 0x0600FB19 RID: 64281 RVA: 0x0006E162 File Offset: 0x0006C362
		Friend Overridable Property Label2 As Label

		' Token: 0x17006020 RID: 24608
		' (get) Token: 0x0600FB1A RID: 64282 RVA: 0x0006E16B File Offset: 0x0006C36B
		' (set) Token: 0x0600FB1B RID: 64283 RVA: 0x0006E175 File Offset: 0x0006C375
		Friend Overridable Property Label16 As Label

		' Token: 0x17006021 RID: 24609
		' (get) Token: 0x0600FB1C RID: 64284 RVA: 0x0006E17E File Offset: 0x0006C37E
		' (set) Token: 0x0600FB1D RID: 64285 RVA: 0x00966338 File Offset: 0x00964538
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006022 RID: 24610
		' (get) Token: 0x0600FB1E RID: 64286 RVA: 0x0006E188 File Offset: 0x0006C388
		' (set) Token: 0x0600FB1F RID: 64287 RVA: 0x0006E192 File Offset: 0x0006C392
		Friend Overridable Property Label4 As Label

		' Token: 0x17006023 RID: 24611
		' (get) Token: 0x0600FB20 RID: 64288 RVA: 0x0006E19B File Offset: 0x0006C39B
		' (set) Token: 0x0600FB21 RID: 64289 RVA: 0x0006E1A5 File Offset: 0x0006C3A5
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17006024 RID: 24612
		' (get) Token: 0x0600FB22 RID: 64290 RVA: 0x0006E1AE File Offset: 0x0006C3AE
		' (set) Token: 0x0600FB23 RID: 64291 RVA: 0x0006E1B8 File Offset: 0x0006C3B8
		Friend Overridable Property FlowLayoutPanel As FlowLayoutPanel

		' Token: 0x17006025 RID: 24613
		' (get) Token: 0x0600FB24 RID: 64292 RVA: 0x0006E1C1 File Offset: 0x0006C3C1
		' (set) Token: 0x0600FB25 RID: 64293 RVA: 0x0006E1CB File Offset: 0x0006C3CB
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17006026 RID: 24614
		' (get) Token: 0x0600FB26 RID: 64294 RVA: 0x0006E1D4 File Offset: 0x0006C3D4
		' (set) Token: 0x0600FB27 RID: 64295 RVA: 0x0006E1DE File Offset: 0x0006C3DE
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17006027 RID: 24615
		' (get) Token: 0x0600FB28 RID: 64296 RVA: 0x0006E1E7 File Offset: 0x0006C3E7
		' (set) Token: 0x0600FB29 RID: 64297 RVA: 0x0096637C File Offset: 0x0096457C
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click_1
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006028 RID: 24616
		' (get) Token: 0x0600FB2A RID: 64298 RVA: 0x0006E1F1 File Offset: 0x0006C3F1
		' (set) Token: 0x0600FB2B RID: 64299 RVA: 0x009663C0 File Offset: 0x009645C0
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006029 RID: 24617
		' (get) Token: 0x0600FB2C RID: 64300 RVA: 0x0006E1FB File Offset: 0x0006C3FB
		' (set) Token: 0x0600FB2D RID: 64301 RVA: 0x0006E205 File Offset: 0x0006C405
		Friend Overridable Property Label8 As Label

		' Token: 0x1700602A RID: 24618
		' (get) Token: 0x0600FB2E RID: 64302 RVA: 0x0006E20E File Offset: 0x0006C40E
		' (set) Token: 0x0600FB2F RID: 64303 RVA: 0x0006E218 File Offset: 0x0006C418
		Friend Overridable Property Label9 As Label

		' Token: 0x1700602B RID: 24619
		' (get) Token: 0x0600FB30 RID: 64304 RVA: 0x0006E221 File Offset: 0x0006C421
		' (set) Token: 0x0600FB31 RID: 64305 RVA: 0x0006E22B File Offset: 0x0006C42B
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x1700602C RID: 24620
		' (get) Token: 0x0600FB32 RID: 64306 RVA: 0x0006E234 File Offset: 0x0006C434
		' (set) Token: 0x0600FB33 RID: 64307 RVA: 0x00966404 File Offset: 0x00964604
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

		' Token: 0x1700602D RID: 24621
		' (get) Token: 0x0600FB34 RID: 64308 RVA: 0x0006E23E File Offset: 0x0006C43E
		' (set) Token: 0x0600FB35 RID: 64309 RVA: 0x00966448 File Offset: 0x00964648
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

		' Token: 0x1700602E RID: 24622
		' (get) Token: 0x0600FB36 RID: 64310 RVA: 0x0006E248 File Offset: 0x0006C448
		' (set) Token: 0x0600FB37 RID: 64311 RVA: 0x0006E252 File Offset: 0x0006C452
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x0600FB38 RID: 64312
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600FB39 RID: 64313
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600FB3A RID: 64314 RVA: 0x0006E25B File Offset: 0x0006C45B
		Private Sub frmLCardIssue_Load(sender As Object, e As EventArgs)
			Me.fillCustomerid()
			Me.cmbAccountNo.Focus()
			Me.CheckBox1.TabStop = False
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FB3B RID: 64315 RVA: 0x0096648C File Offset: 0x0096468C
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

		' Token: 0x0600FB3C RID: 64316 RVA: 0x00966604 File Offset: 0x00964804
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

		' Token: 0x0600FB3D RID: 64317 RVA: 0x009666C0 File Offset: 0x009648C0
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

		' Token: 0x0600FB3E RID: 64318 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FB3F RID: 64319 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FB40 RID: 64320 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FB41 RID: 64321 RVA: 0x00131C7C File Offset: 0x0012FE7C
		Public Sub fillCustomerid()
			Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB42 RID: 64322 RVA: 0x0096678C File Offset: 0x0096498C
		Private Sub Clear()
			Me.cmbAccountNo.Text = ""
			Me.txtAccountName.Text = ""
			Me.txtBank.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Text = ""
			Me.cmbAccountNo.Focus()
		End Sub

		' Token: 0x0600FB43 RID: 64323 RVA: 0x0096682C File Offset: 0x00964A2C
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					Me.txtAccountName.Text = ""
					Me.txtBank.Text = ""
					Me.txtBranchName.Text = ""
					Me.txtSwiftCode.Text = ""
					Me.txtIFSCCode.Text = ""
					Me.ComboBox1.SelectedIndex = -1
					Me.ComboBox1.Text = ""
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Name),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(CardNo),RTRIM(Status) from Customer where CustomerID=@d1"
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.txtAccountName.Text = ModCommonClasses.rdr.GetValue(0).ToString()
						Me.txtBank.Text = ModCommonClasses.rdr.GetValue(1).ToString()
						Me.txtBranchName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
						Me.txtSwiftCode.Text = ModCommonClasses.rdr.GetValue(3).ToString()
						Me.txtIFSCCode.Text = ModCommonClasses.rdr.GetValue(4).ToString()
						Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB44 RID: 64324 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB45 RID: 64325 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB46 RID: 64326 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBranchName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB47 RID: 64327 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSwiftCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB48 RID: 64328 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIFSCCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB49 RID: 64329 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FB4A RID: 64330 RVA: 0x00966A74 File Offset: 0x00964C74
		Public Sub FillCustomerCardStatus()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT DISTINCT TOP " + Me.txtTopResult.Text + " RTRIM(CustomerID),RTRIM(Name),RTRIM(Status) from Customer WHERE NOT Name='Cash' order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = String.Concat(New String() { "Customer ID : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Name : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Status : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim() })
					button.TextAlign = ContentAlignment.MiddleCenter
					Dim limeGreen As Color = Color.LimeGreen
					Dim orange As Color = Color.Orange
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(2).ToString().Trim(), "Activated", False) = 0
					If flag Then
						button.BackColor = limeGreen
					Else
						Dim flag2 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(2).ToString().Trim(), "Deactivated", False) = 0
						If flag2 Then
							button.BackColor = orange
						Else
							button.BackColor = deepSkyBlue
						End If
					End If
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 180
					button.Height = 80
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB4B RID: 64331 RVA: 0x00966D6C File Offset: 0x00964F6C
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(button.Tag))
				Me.cmbAccountNo.Text = text.Split(New Char() { ","c })(0).ToString()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Try
				Me.txtAccountName.Text = ""
				Me.txtBank.Text = ""
				Me.txtBranchName.Text = ""
				Me.txtSwiftCode.Text = ""
				Me.txtIFSCCode.Text = ""
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox1.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Name),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(CardNo),RTRIM(Status) from Customer where CustomerID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtAccountName.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtBank.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtBranchName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtSwiftCode.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtIFSCCode.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(5).ToString()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB4C RID: 64332 RVA: 0x0096700C File Offset: 0x0096520C
		Public Sub FillCustomerCardStatus2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT DISTINCT RTRIM(CustomerID),RTRIM(Name),RTRIM(Status) from Customer order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = String.Concat(New String() { "Customer ID : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Name : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Status : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim() })
					button.TextAlign = ContentAlignment.MiddleCenter
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					button.BackColor = deepSkyBlue
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 180
					button.Height = 80
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB4D RID: 64333 RVA: 0x00967274 File Offset: 0x00965474
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmLCardIssue.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmLCardIssue.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x0600FB4E RID: 64334 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmLCardIssue_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FB4F RID: 64335 RVA: 0x009672BC File Offset: 0x009654BC
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.FillCustomerCardStatus()
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Me.FlowLayoutPanel.Controls.Clear()
				End If
			End If
		End Sub

		' Token: 0x0600FB50 RID: 64336 RVA: 0x00967308 File Offset: 0x00965508
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600FB51 RID: 64337 RVA: 0x0096738C File Offset: 0x0096558C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtAccountName.Text, "Cash", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed to isuue the loyalty card in favour of 'Cash' account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtIFSCCode.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill the Loyalty Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtIFSCCode.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.ComboBox1.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please fill the Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ComboBox1.Focus()
					Else
						Try
							Me.Generate_GiftQR(Me.txtSwiftCode.Text)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "Update Customer set CardNo=@d1,Status=@d2,QrCustomer=@qr where CustomerID=@d0"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtIFSCCode.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.cmbAccountNo.Text)
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@qr", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.ExecuteReader()
							Dim text2 As String = String.Concat(New String() { "Loyalty Card having no. '", Me.txtIFSCCode.Text, "' , in favour of '", Me.txtAccountName.Text, "'" })
							ModFunc.LogFunc(Me.lblUser.Text, text2)
							MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Clear()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600FB52 RID: 64338 RVA: 0x0006E285 File Offset: 0x0006C485
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub

		' Token: 0x04006028 RID: 24616
		Private UserButtons As List(Of Button)
	End Class
End Namespace
