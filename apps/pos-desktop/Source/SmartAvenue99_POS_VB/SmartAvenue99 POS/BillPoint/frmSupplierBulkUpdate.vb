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
	' Token: 0x020004DD RID: 1245
	<DesignerGenerated()>
	Public Partial Class frmSupplierBulkUpdate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FD83 RID: 64899 RVA: 0x0006F179 File Offset: 0x0006D379
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSupplierBulkUpdate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplierBulkUpdate_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170060E5 RID: 24805
		' (get) Token: 0x0600FD86 RID: 64902 RVA: 0x0006F1AB File Offset: 0x0006D3AB
		' (set) Token: 0x0600FD87 RID: 64903 RVA: 0x0006F1B5 File Offset: 0x0006D3B5
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x170060E6 RID: 24806
		' (get) Token: 0x0600FD88 RID: 64904 RVA: 0x0006F1BE File Offset: 0x0006D3BE
		' (set) Token: 0x0600FD89 RID: 64905 RVA: 0x0006F1C8 File Offset: 0x0006D3C8
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x170060E7 RID: 24807
		' (get) Token: 0x0600FD8A RID: 64906 RVA: 0x0006F1D1 File Offset: 0x0006D3D1
		' (set) Token: 0x0600FD8B RID: 64907 RVA: 0x0006F1DB File Offset: 0x0006D3DB
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x170060E8 RID: 24808
		' (get) Token: 0x0600FD8C RID: 64908 RVA: 0x0006F1E4 File Offset: 0x0006D3E4
		' (set) Token: 0x0600FD8D RID: 64909 RVA: 0x0097AB6C File Offset: 0x00978D6C
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

		' Token: 0x170060E9 RID: 24809
		' (get) Token: 0x0600FD8E RID: 64910 RVA: 0x0006F1EE File Offset: 0x0006D3EE
		' (set) Token: 0x0600FD8F RID: 64911 RVA: 0x0006F1F8 File Offset: 0x0006D3F8
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x170060EA RID: 24810
		' (get) Token: 0x0600FD90 RID: 64912 RVA: 0x0006F201 File Offset: 0x0006D401
		' (set) Token: 0x0600FD91 RID: 64913 RVA: 0x0006F20B File Offset: 0x0006D40B
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170060EB RID: 24811
		' (get) Token: 0x0600FD92 RID: 64914 RVA: 0x0006F214 File Offset: 0x0006D414
		' (set) Token: 0x0600FD93 RID: 64915 RVA: 0x0006F21E File Offset: 0x0006D41E
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x170060EC RID: 24812
		' (get) Token: 0x0600FD94 RID: 64916 RVA: 0x0006F227 File Offset: 0x0006D427
		' (set) Token: 0x0600FD95 RID: 64917 RVA: 0x0006F231 File Offset: 0x0006D431
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x170060ED RID: 24813
		' (get) Token: 0x0600FD96 RID: 64918 RVA: 0x0006F23A File Offset: 0x0006D43A
		' (set) Token: 0x0600FD97 RID: 64919 RVA: 0x0006F244 File Offset: 0x0006D444
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x170060EE RID: 24814
		' (get) Token: 0x0600FD98 RID: 64920 RVA: 0x0006F24D File Offset: 0x0006D44D
		' (set) Token: 0x0600FD99 RID: 64921 RVA: 0x0006F257 File Offset: 0x0006D457
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x170060EF RID: 24815
		' (get) Token: 0x0600FD9A RID: 64922 RVA: 0x0006F260 File Offset: 0x0006D460
		' (set) Token: 0x0600FD9B RID: 64923 RVA: 0x0006F26A File Offset: 0x0006D46A
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170060F0 RID: 24816
		' (get) Token: 0x0600FD9C RID: 64924 RVA: 0x0006F273 File Offset: 0x0006D473
		' (set) Token: 0x0600FD9D RID: 64925 RVA: 0x0006F27D File Offset: 0x0006D47D
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170060F1 RID: 24817
		' (get) Token: 0x0600FD9E RID: 64926 RVA: 0x0006F286 File Offset: 0x0006D486
		' (set) Token: 0x0600FD9F RID: 64927 RVA: 0x0006F290 File Offset: 0x0006D490
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x170060F2 RID: 24818
		' (get) Token: 0x0600FDA0 RID: 64928 RVA: 0x0006F299 File Offset: 0x0006D499
		' (set) Token: 0x0600FDA1 RID: 64929 RVA: 0x0006F2A3 File Offset: 0x0006D4A3
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x170060F3 RID: 24819
		' (get) Token: 0x0600FDA2 RID: 64930 RVA: 0x0006F2AC File Offset: 0x0006D4AC
		' (set) Token: 0x0600FDA3 RID: 64931 RVA: 0x0006F2B6 File Offset: 0x0006D4B6
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x170060F4 RID: 24820
		' (get) Token: 0x0600FDA4 RID: 64932 RVA: 0x0006F2BF File Offset: 0x0006D4BF
		' (set) Token: 0x0600FDA5 RID: 64933 RVA: 0x0006F2C9 File Offset: 0x0006D4C9
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x170060F5 RID: 24821
		' (get) Token: 0x0600FDA6 RID: 64934 RVA: 0x0006F2D2 File Offset: 0x0006D4D2
		' (set) Token: 0x0600FDA7 RID: 64935 RVA: 0x0006F2DC File Offset: 0x0006D4DC
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x170060F6 RID: 24822
		' (get) Token: 0x0600FDA8 RID: 64936 RVA: 0x0006F2E5 File Offset: 0x0006D4E5
		' (set) Token: 0x0600FDA9 RID: 64937 RVA: 0x0006F2EF File Offset: 0x0006D4EF
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x170060F7 RID: 24823
		' (get) Token: 0x0600FDAA RID: 64938 RVA: 0x0006F2F8 File Offset: 0x0006D4F8
		' (set) Token: 0x0600FDAB RID: 64939 RVA: 0x0006F302 File Offset: 0x0006D502
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x170060F8 RID: 24824
		' (get) Token: 0x0600FDAC RID: 64940 RVA: 0x0006F30B File Offset: 0x0006D50B
		' (set) Token: 0x0600FDAD RID: 64941 RVA: 0x0006F315 File Offset: 0x0006D515
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x170060F9 RID: 24825
		' (get) Token: 0x0600FDAE RID: 64942 RVA: 0x0006F31E File Offset: 0x0006D51E
		' (set) Token: 0x0600FDAF RID: 64943 RVA: 0x0006F328 File Offset: 0x0006D528
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x170060FA RID: 24826
		' (get) Token: 0x0600FDB0 RID: 64944 RVA: 0x0006F331 File Offset: 0x0006D531
		' (set) Token: 0x0600FDB1 RID: 64945 RVA: 0x0006F33B File Offset: 0x0006D53B
		Friend Overridable Property Label2 As Label

		' Token: 0x170060FB RID: 24827
		' (get) Token: 0x0600FDB2 RID: 64946 RVA: 0x0006F344 File Offset: 0x0006D544
		' (set) Token: 0x0600FDB3 RID: 64947 RVA: 0x0006F34E File Offset: 0x0006D54E
		Friend Overridable Property Label1 As Label

		' Token: 0x170060FC RID: 24828
		' (get) Token: 0x0600FDB4 RID: 64948 RVA: 0x0006F357 File Offset: 0x0006D557
		' (set) Token: 0x0600FDB5 RID: 64949 RVA: 0x0097ABB0 File Offset: 0x00978DB0
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

		' Token: 0x170060FD RID: 24829
		' (get) Token: 0x0600FDB6 RID: 64950 RVA: 0x0006F361 File Offset: 0x0006D561
		' (set) Token: 0x0600FDB7 RID: 64951 RVA: 0x0097ABF4 File Offset: 0x00978DF4
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

		' Token: 0x170060FE RID: 24830
		' (get) Token: 0x0600FDB8 RID: 64952 RVA: 0x0006F36B File Offset: 0x0006D56B
		' (set) Token: 0x0600FDB9 RID: 64953 RVA: 0x0097AC38 File Offset: 0x00978E38
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

		' Token: 0x170060FF RID: 24831
		' (get) Token: 0x0600FDBA RID: 64954 RVA: 0x0006F375 File Offset: 0x0006D575
		' (set) Token: 0x0600FDBB RID: 64955 RVA: 0x0097ACB4 File Offset: 0x00978EB4
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

		' Token: 0x17006100 RID: 24832
		' (get) Token: 0x0600FDBC RID: 64956 RVA: 0x0006F37F File Offset: 0x0006D57F
		' (set) Token: 0x0600FDBD RID: 64957 RVA: 0x0006F389 File Offset: 0x0006D589
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17006101 RID: 24833
		' (get) Token: 0x0600FDBE RID: 64958 RVA: 0x0006F392 File Offset: 0x0006D592
		' (set) Token: 0x0600FDBF RID: 64959 RVA: 0x0006F39C File Offset: 0x0006D59C
		Friend Overridable Property Label6 As Label

		' Token: 0x17006102 RID: 24834
		' (get) Token: 0x0600FDC0 RID: 64960 RVA: 0x0006F3A5 File Offset: 0x0006D5A5
		' (set) Token: 0x0600FDC1 RID: 64961 RVA: 0x0006F3AF File Offset: 0x0006D5AF
		Friend Overridable Property Label7 As Label

		' Token: 0x17006103 RID: 24835
		' (get) Token: 0x0600FDC2 RID: 64962 RVA: 0x0006F3B8 File Offset: 0x0006D5B8
		' (set) Token: 0x0600FDC3 RID: 64963 RVA: 0x0006F3C2 File Offset: 0x0006D5C2
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17006104 RID: 24836
		' (get) Token: 0x0600FDC4 RID: 64964 RVA: 0x0006F3CB File Offset: 0x0006D5CB
		' (set) Token: 0x0600FDC5 RID: 64965 RVA: 0x0097AD14 File Offset: 0x00978F14
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

		' Token: 0x17006105 RID: 24837
		' (get) Token: 0x0600FDC6 RID: 64966 RVA: 0x0006F3D5 File Offset: 0x0006D5D5
		' (set) Token: 0x0600FDC7 RID: 64967 RVA: 0x0097AD58 File Offset: 0x00978F58
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600FDC8 RID: 64968 RVA: 0x0006F3DF File Offset: 0x0006D5DF
		Private Sub frmSupplierBulkUpdate_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FDC9 RID: 64969 RVA: 0x0097AD9C File Offset: 0x00978F9C
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

		' Token: 0x0600FDCA RID: 64970 RVA: 0x0097AF14 File Offset: 0x00979114
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

		' Token: 0x0600FDCB RID: 64971 RVA: 0x0097AFD0 File Offset: 0x009791D0
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

		' Token: 0x0600FDCC RID: 64972 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FDCD RID: 64973 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FDCE RID: 64974 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FDCF RID: 64975 RVA: 0x0097B09C File Offset: 0x0097929C
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " ID, RTRIM(SupplierID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),Limit,RTRIM(Lstatus),RTRIM(SCode) from Supplier order by ID", ModCommonClasses.con)
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
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
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

		' Token: 0x0600FDD0 RID: 64976 RVA: 0x0097B4A8 File Offset: 0x009796A8
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x0600FDD1 RID: 64977 RVA: 0x0097B4FC File Offset: 0x009796FC
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num - 2 <= 19 Then
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

		' Token: 0x0600FDD2 RID: 64978 RVA: 0x0097B628 File Offset: 0x00979828
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

		' Token: 0x0600FDD3 RID: 64979 RVA: 0x0097B6D0 File Offset: 0x009798D0
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

		' Token: 0x0600FDD4 RID: 64980 RVA: 0x0097B758 File Offset: 0x00979958
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

		' Token: 0x0600FDD5 RID: 64981 RVA: 0x0097B7BC File Offset: 0x009799BC
		Private Sub Updatelistdata(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text5 As String
			Dim text6 As String
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
					Dim text As String = String.Concat(New String() { "Update LedgerBook set [Name]= N'", pListView.Items(num4).SubItems(2).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Dim text2 As String = String.Concat(New String() { "Update SupplierLedgerBook set [Name]= N'", pListView.Items(num4).SubItems(2).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Dim text3 As String = String.Concat(New String() { "Update SupplierLedgerBook set SuplNameid= N'", pListView.Items(num4).SubItems(2).Text + "-" + pListView.Items(num4).SubItems(1).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Dim text4 As String = String.Concat(New String() { "UPDATE Supplier SET Name = N'", pListView.Items(num4).SubItems(2).Text, "', Address = N'", pListView.Items(num4).SubItems(3).Text, "', City = N'", pListView.Items(num4).SubItems(4).Text, "', State = N'", pListView.Items(num4).SubItems(5).Text, "', ZipCode = N'", pListView.Items(num4).SubItems(6).Text, "', ContactNo = N'", pListView.Items(num4).SubItems(7).Text, "', EmailID = N'", pListView.Items(num4).SubItems(8).Text, "', Remarks = N'", pListView.Items(num4).SubItems(9).Text, "', AccountNumber = N'", pListView.Items(num4).SubItems(10).Text, "', AccountName = N'", pListView.Items(num4).SubItems(11).Text, "', Bank = N'", pListView.Items(num4).SubItems(12).Text, "', Branch = N'", pListView.Items(num4).SubItems(13).Text, "', IFSCCode = N'", pListView.Items(num4).SubItems(14).Text, "', GSTIN = N'", pListView.Items(num4).SubItems(15).Text, "', PAN = N'", pListView.Items(num4).SubItems(16).Text, "', CIN = N'", pListView.Items(num4).SubItems(17).Text, "', Limit = N'", pListView.Items(num4).SubItems(18).Text, "', Lstatus = N'", pListView.Items(num4).SubItems(19).Text, "', SCode = N'", pListView.Items(num4).SubItems(20).Text, "' WHERE ID = N'", pListView.Items(num4).SubItems(0).Text, "' and SupplierID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					Me.ExecNonQuery(text2)
					Me.ExecNonQuery(text3)
					Me.ExecNonQuery(text4)
					text5 = text5 + pListView.Items(num4).SubItems(0).Text + ","
					text6 = text6 + pListView.Items(num4).SubItems(1).Text + ","
					pListView.Items(num4).Checked = False
					num += 1
				End If
				num4 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Record(s) Updated ", Conversions.ToString(num), ". Updated ID(s)  ", text5, " having Supplier ID(s). ", text6 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x0600FDD6 RID: 64982 RVA: 0x00817A5C File Offset: 0x00815C5C
		Public Function ExecNonQuery(cmdText As String) As Integer
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
			Dim num As Integer = sqlCommand.ExecuteNonQuery()
			sqlCommand.Dispose()
			sqlConnection.Close()
			Return num
		End Function

		' Token: 0x0600FDD7 RID: 64983 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox42_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FDD8 RID: 64984 RVA: 0x0097BDDC File Offset: 0x00979FDC
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

		' Token: 0x0600FDD9 RID: 64985 RVA: 0x0097BEC8 File Offset: 0x0097A0C8
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " ID, RTRIM(SupplierID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),Limit,RTRIM(Lstatus),RTRIM(SCode) from Supplier where Name like N'%", Me.TextBox1.Text, "%' order by ID" }), ModCommonClasses.con)
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
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
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

		' Token: 0x0600FDDA RID: 64986 RVA: 0x0097C2FC File Offset: 0x0097A4FC
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " ID, RTRIM(SupplierID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),Limit,RTRIM(Lstatus),RTRIM(SCode) from Supplier where ContactNo like N'%", Me.TextBox2.Text, "%' order by ID" }), ModCommonClasses.con)
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
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
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

		' Token: 0x0600FDDB RID: 64987 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplierBulkUpdate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FDDC RID: 64988 RVA: 0x0097C730 File Offset: 0x0097A930
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.chkSelectAll.Checked = False
			Me.txtTopResult.Text = "10"
			Me.Getdata()
		End Sub

		' Token: 0x0600FDDD RID: 64989 RVA: 0x0097C788 File Offset: 0x0097A988
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

		' Token: 0x04006134 RID: 24884
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04006135 RID: 24885
		Private CurrentItem As ListViewItem

		' Token: 0x04006136 RID: 24886
		Private bCancelEdit As Boolean
	End Class
End Namespace
