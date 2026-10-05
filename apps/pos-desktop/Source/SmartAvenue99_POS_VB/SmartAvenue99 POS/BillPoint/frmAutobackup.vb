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
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A9 RID: 1193
	<DesignerGenerated()>
	Public Partial Class frmAutobackup
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600ECC9 RID: 60617 RVA: 0x008E8808 File Offset: 0x008E6A08
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAutobackup_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAutobackup_KeyDown
			AddHandler MyBase.FormClosing, AddressOf Me.frmAutobackup_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AD3 RID: 23251
		' (get) Token: 0x0600ECCC RID: 60620 RVA: 0x00067B5C File Offset: 0x00065D5C
		' (set) Token: 0x0600ECCD RID: 60621 RVA: 0x00067B66 File Offset: 0x00065D66
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005AD4 RID: 23252
		' (get) Token: 0x0600ECCE RID: 60622 RVA: 0x00067B6F File Offset: 0x00065D6F
		' (set) Token: 0x0600ECCF RID: 60623 RVA: 0x00067B79 File Offset: 0x00065D79
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005AD5 RID: 23253
		' (get) Token: 0x0600ECD0 RID: 60624 RVA: 0x00067B82 File Offset: 0x00065D82
		' (set) Token: 0x0600ECD1 RID: 60625 RVA: 0x00067B8C File Offset: 0x00065D8C
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005AD6 RID: 23254
		' (get) Token: 0x0600ECD2 RID: 60626 RVA: 0x00067B95 File Offset: 0x00065D95
		' (set) Token: 0x0600ECD3 RID: 60627 RVA: 0x00067B9F File Offset: 0x00065D9F
		Friend Overridable Property Label3 As Label

		' Token: 0x17005AD7 RID: 23255
		' (get) Token: 0x0600ECD4 RID: 60628 RVA: 0x00067BA8 File Offset: 0x00065DA8
		' (set) Token: 0x0600ECD5 RID: 60629 RVA: 0x008E9E9C File Offset: 0x008E809C
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

		' Token: 0x17005AD8 RID: 23256
		' (get) Token: 0x0600ECD6 RID: 60630 RVA: 0x00067BB2 File Offset: 0x00065DB2
		' (set) Token: 0x0600ECD7 RID: 60631 RVA: 0x008E9EE0 File Offset: 0x008E80E0
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

		' Token: 0x17005AD9 RID: 23257
		' (get) Token: 0x0600ECD8 RID: 60632 RVA: 0x00067BBC File Offset: 0x00065DBC
		' (set) Token: 0x0600ECD9 RID: 60633 RVA: 0x00067BC6 File Offset: 0x00065DC6
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005ADA RID: 23258
		' (get) Token: 0x0600ECDA RID: 60634 RVA: 0x00067BCF File Offset: 0x00065DCF
		' (set) Token: 0x0600ECDB RID: 60635 RVA: 0x00067BD9 File Offset: 0x00065DD9
		Friend Overridable Property Label1 As Label

		' Token: 0x17005ADB RID: 23259
		' (get) Token: 0x0600ECDC RID: 60636 RVA: 0x00067BE2 File Offset: 0x00065DE2
		' (set) Token: 0x0600ECDD RID: 60637 RVA: 0x00067BEC File Offset: 0x00065DEC
		Friend Overridable Property Label2 As Label

		' Token: 0x17005ADC RID: 23260
		' (get) Token: 0x0600ECDE RID: 60638 RVA: 0x00067BF5 File Offset: 0x00065DF5
		' (set) Token: 0x0600ECDF RID: 60639 RVA: 0x008E9F40 File Offset: 0x008E8140
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005ADD RID: 23261
		' (get) Token: 0x0600ECE0 RID: 60640 RVA: 0x00067BFF File Offset: 0x00065DFF
		' (set) Token: 0x0600ECE1 RID: 60641 RVA: 0x00067C09 File Offset: 0x00065E09
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x17005ADE RID: 23262
		' (get) Token: 0x0600ECE2 RID: 60642 RVA: 0x00067C12 File Offset: 0x00065E12
		' (set) Token: 0x0600ECE3 RID: 60643 RVA: 0x00067C1C File Offset: 0x00065E1C
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005ADF RID: 23263
		' (get) Token: 0x0600ECE4 RID: 60644 RVA: 0x00067C25 File Offset: 0x00065E25
		' (set) Token: 0x0600ECE5 RID: 60645 RVA: 0x008E9F84 File Offset: 0x008E8184
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button6_MouseHover
				Dim eventHandler3 As EventHandler = AddressOf Me.Button6_MouseLeave
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
					RemoveHandler button.MouseLeave, eventHandler3
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
					AddHandler button.MouseLeave, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x17005AE0 RID: 23264
		' (get) Token: 0x0600ECE6 RID: 60646 RVA: 0x00067C2F File Offset: 0x00065E2F
		' (set) Token: 0x0600ECE7 RID: 60647 RVA: 0x00067C39 File Offset: 0x00065E39
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005AE1 RID: 23265
		' (get) Token: 0x0600ECE8 RID: 60648 RVA: 0x00067C42 File Offset: 0x00065E42
		' (set) Token: 0x0600ECE9 RID: 60649 RVA: 0x00067C4C File Offset: 0x00065E4C
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17005AE2 RID: 23266
		' (get) Token: 0x0600ECEA RID: 60650 RVA: 0x00067C55 File Offset: 0x00065E55
		' (set) Token: 0x0600ECEB RID: 60651 RVA: 0x008EA000 File Offset: 0x008E8200
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AE3 RID: 23267
		' (get) Token: 0x0600ECEC RID: 60652 RVA: 0x00067C5F File Offset: 0x00065E5F
		' (set) Token: 0x0600ECED RID: 60653 RVA: 0x00067C69 File Offset: 0x00065E69
		Friend Overridable Property Label5 As Label

		' Token: 0x17005AE4 RID: 23268
		' (get) Token: 0x0600ECEE RID: 60654 RVA: 0x00067C72 File Offset: 0x00065E72
		' (set) Token: 0x0600ECEF RID: 60655 RVA: 0x00067C7C File Offset: 0x00065E7C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005AE5 RID: 23269
		' (get) Token: 0x0600ECF0 RID: 60656 RVA: 0x00067C85 File Offset: 0x00065E85
		' (set) Token: 0x0600ECF1 RID: 60657 RVA: 0x00067C8F File Offset: 0x00065E8F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005AE6 RID: 23270
		' (get) Token: 0x0600ECF2 RID: 60658 RVA: 0x00067C98 File Offset: 0x00065E98
		' (set) Token: 0x0600ECF3 RID: 60659 RVA: 0x00067CA2 File Offset: 0x00065EA2
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005AE7 RID: 23271
		' (get) Token: 0x0600ECF4 RID: 60660 RVA: 0x00067CAB File Offset: 0x00065EAB
		' (set) Token: 0x0600ECF5 RID: 60661 RVA: 0x00067CB5 File Offset: 0x00065EB5
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005AE8 RID: 23272
		' (get) Token: 0x0600ECF6 RID: 60662 RVA: 0x00067CBE File Offset: 0x00065EBE
		' (set) Token: 0x0600ECF7 RID: 60663 RVA: 0x00067CC8 File Offset: 0x00065EC8
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005AE9 RID: 23273
		' (get) Token: 0x0600ECF8 RID: 60664 RVA: 0x00067CD1 File Offset: 0x00065ED1
		' (set) Token: 0x0600ECF9 RID: 60665 RVA: 0x008EA044 File Offset: 0x008E8244
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
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

		' Token: 0x17005AEA RID: 23274
		' (get) Token: 0x0600ECFA RID: 60666 RVA: 0x00067CDB File Offset: 0x00065EDB
		' (set) Token: 0x0600ECFB RID: 60667 RVA: 0x008EA088 File Offset: 0x008E8288
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
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

		' Token: 0x17005AEB RID: 23275
		' (get) Token: 0x0600ECFC RID: 60668 RVA: 0x00067CE5 File Offset: 0x00065EE5
		' (set) Token: 0x0600ECFD RID: 60669 RVA: 0x008EA0CC File Offset: 0x008E82CC
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

		' Token: 0x17005AEC RID: 23276
		' (get) Token: 0x0600ECFE RID: 60670 RVA: 0x00067CEF File Offset: 0x00065EEF
		' (set) Token: 0x0600ECFF RID: 60671 RVA: 0x008EA110 File Offset: 0x008E8310
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
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

		' Token: 0x0600ED00 RID: 60672 RVA: 0x008EA154 File Offset: 0x008E8354
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Me.TextBox1.Text = folderBrowserDialog.SelectedPath
			End If
		End Sub

		' Token: 0x0600ED01 RID: 60673 RVA: 0x008EA194 File Offset: 0x008E8394
		Private Sub Clear()
			Me.TextBox1.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.GetData()
			Me.Button6.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600ED02 RID: 60674 RVA: 0x008EA208 File Offset: 0x008E8408
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),RTRIM(c3) from Autobackup ORDER BY ID", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ED03 RID: 60675 RVA: 0x008EA30C File Offset: 0x008E850C
		Private Sub frmAutobackup_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600ED04 RID: 60676 RVA: 0x008EA394 File Offset: 0x008E8594
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

		' Token: 0x0600ED05 RID: 60677 RVA: 0x008EA50C File Offset: 0x008E870C
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

		' Token: 0x0600ED06 RID: 60678 RVA: 0x008EA5C8 File Offset: 0x008E87C8
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

		' Token: 0x0600ED07 RID: 60679 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600ED08 RID: 60680 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600ED09 RID: 60681 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ED0A RID: 60682 RVA: 0x008EA694 File Offset: 0x008E8894
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button4.Enabled = False
					Me.Button3.Enabled = True
					Me.Button2.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox2.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.ComboBox2.Text = dataGridViewRow.Cells(3).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ED0B RID: 60683 RVA: 0x008EA7A0 File Offset: 0x008E89A0
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

		' Token: 0x0600ED0C RID: 60684 RVA: 0x00067CF9 File Offset: 0x00065EF9
		Private Sub Button6_MouseHover(sender As Object, e As EventArgs)
			Me.Button6.BackColor = Color.Maroon
			Me.Button6.ForeColor = Color.White
		End Sub

		' Token: 0x0600ED0D RID: 60685 RVA: 0x00067D1E File Offset: 0x00065F1E
		Private Sub Button6_MouseLeave(sender As Object, e As EventArgs)
			Me.Button6.BackColor = Color.DarkViolet
			Me.Button6.ForeColor = Color.White
		End Sub

		' Token: 0x0600ED0E RID: 60686 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAutobackup_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600ED0F RID: 60687 RVA: 0x008EA888 File Offset: 0x008E8A88
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.ComboBox2.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.ComboBox2, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox2, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub

		' Token: 0x0600ED10 RID: 60688 RVA: 0x00067D43 File Offset: 0x00065F43
		Private Sub frmAutobackup_FormClosing(sender As Object, e As FormClosingEventArgs)
			MyProject.Forms.frmMainMenu.Autobackupstatusdisplay()
		End Sub

		' Token: 0x0600ED11 RID: 60689 RVA: 0x00067D56 File Offset: 0x00065F56
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600ED12 RID: 60690 RVA: 0x008EA97C File Offset: 0x008E8B7C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
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
						MessageBox.Show("Please fill Destination Folder Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
						If flag4 Then
							MessageBox.Show("Please fill Auto Offline Backup Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox1.Focus()
						Else
							Dim flag5 As Boolean = (Operators.CompareString(Me.ComboBox2.Text, "", False) = 0) Or (Me.ComboBox2.SelectedIndex = -1)
							If flag5 Then
								MessageBox.Show("Please fill Auto Cloud Backup Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.ComboBox2.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "Select count(*) from Autobackup Having count(*) >= 1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
									If flag6 Then
										MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the information only", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag7 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into Autobackup(c1,c2,c3) VALUES (@d1,@d2,@d3)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.Button4.Enabled = True
										Me.Button3.Enabled = False
										Me.Button2.Enabled = False
										Me.GetData()
										Me.Clear()
									End If
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600ED13 RID: 60691 RVA: 0x008EACFC File Offset: 0x008E8EFC
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Add Company Information first in master entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					flag = ModCommonClasses.rdr IsNot Nothing
					Dim flag3 As Boolean = flag
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Me.Clear()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please fill Destination Folder Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
					Else
						Dim flag5 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
						If flag5 Then
							MessageBox.Show("Please fill Auto Offline Backup Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox1.Focus()
						Else
							Dim flag6 As Boolean = (Operators.CompareString(Me.ComboBox2.Text, "", False) = 0) Or (Me.ComboBox2.SelectedIndex = -1)
							If flag6 Then
								MessageBox.Show("Please fill Auto Cloud Backup Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.ComboBox2.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = If(("Update Autobackup set c1=@d1, c2=@d2, c3=@d3 where ID=" + Me.TextBox2.Text), "")
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									MyProject.Forms.frmMainMenu.Autobackupstatusdisplay()
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
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600ED14 RID: 60692 RVA: 0x008EB01C File Offset: 0x008E921C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Autobackup WHERE ID = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Clear()
					End If
				End If
				ModCommonClasses.con.Close()
				Me.GetData()
				Me.Clear()
				Me.Button4.Enabled = True
				Me.Button3.Enabled = False
				Me.Button3.Enabled = False
				MyProject.Forms.frmMainMenu.Autobackupstatusdisplay()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
