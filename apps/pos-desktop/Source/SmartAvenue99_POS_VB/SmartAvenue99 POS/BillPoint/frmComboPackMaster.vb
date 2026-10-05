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
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020000D0 RID: 208
	<DesignerGenerated()>
	Public Partial Class frmComboPackMaster
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060024A9 RID: 9385 RVA: 0x00173D8C File Offset: 0x00171F8C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmcategory_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCategory_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCategory_Closing
			AddHandler MyBase.FormClosed, AddressOf Me.frmComboPackMaster_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000E86 RID: 3718
		' (get) Token: 0x060024AC RID: 9388 RVA: 0x00018D18 File Offset: 0x00016F18
		' (set) Token: 0x060024AD RID: 9389 RVA: 0x00018D22 File Offset: 0x00016F22
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x17000E87 RID: 3719
		' (get) Token: 0x060024AE RID: 9390 RVA: 0x00018D2B File Offset: 0x00016F2B
		' (set) Token: 0x060024AF RID: 9391 RVA: 0x00018D35 File Offset: 0x00016F35
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000E88 RID: 3720
		' (get) Token: 0x060024B0 RID: 9392 RVA: 0x00018D3E File Offset: 0x00016F3E
		' (set) Token: 0x060024B1 RID: 9393 RVA: 0x00018D48 File Offset: 0x00016F48
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000E89 RID: 3721
		' (get) Token: 0x060024B2 RID: 9394 RVA: 0x00018D51 File Offset: 0x00016F51
		' (set) Token: 0x060024B3 RID: 9395 RVA: 0x001750E8 File Offset: 0x001732E8
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

		' Token: 0x17000E8A RID: 3722
		' (get) Token: 0x060024B4 RID: 9396 RVA: 0x00018D5B File Offset: 0x00016F5B
		' (set) Token: 0x060024B5 RID: 9397 RVA: 0x0017512C File Offset: 0x0017332C
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

		' Token: 0x17000E8B RID: 3723
		' (get) Token: 0x060024B6 RID: 9398 RVA: 0x00018D65 File Offset: 0x00016F65
		' (set) Token: 0x060024B7 RID: 9399 RVA: 0x00175170 File Offset: 0x00173370
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E8C RID: 3724
		' (get) Token: 0x060024B8 RID: 9400 RVA: 0x00018D6F File Offset: 0x00016F6F
		' (set) Token: 0x060024B9 RID: 9401 RVA: 0x001751B4 File Offset: 0x001733B4
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

		' Token: 0x17000E8D RID: 3725
		' (get) Token: 0x060024BA RID: 9402 RVA: 0x00018D79 File Offset: 0x00016F79
		' (set) Token: 0x060024BB RID: 9403 RVA: 0x00018D83 File Offset: 0x00016F83
		Friend Overridable Property txtCategoryName As TextBox

		' Token: 0x17000E8E RID: 3726
		' (get) Token: 0x060024BC RID: 9404 RVA: 0x00018D8C File Offset: 0x00016F8C
		' (set) Token: 0x060024BD RID: 9405 RVA: 0x00018D96 File Offset: 0x00016F96
		Friend Overridable Property lblUser As Label

		' Token: 0x17000E8F RID: 3727
		' (get) Token: 0x060024BE RID: 9406 RVA: 0x00018D9F File Offset: 0x00016F9F
		' (set) Token: 0x060024BF RID: 9407 RVA: 0x00018DA9 File Offset: 0x00016FA9
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17000E90 RID: 3728
		' (get) Token: 0x060024C0 RID: 9408 RVA: 0x00018DB2 File Offset: 0x00016FB2
		' (set) Token: 0x060024C1 RID: 9409 RVA: 0x00018DBC File Offset: 0x00016FBC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000E91 RID: 3729
		' (get) Token: 0x060024C2 RID: 9410 RVA: 0x00018DC5 File Offset: 0x00016FC5
		' (set) Token: 0x060024C3 RID: 9411 RVA: 0x00018DCF File Offset: 0x00016FCF
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000E92 RID: 3730
		' (get) Token: 0x060024C4 RID: 9412 RVA: 0x00018DD8 File Offset: 0x00016FD8
		' (set) Token: 0x060024C5 RID: 9413 RVA: 0x001751F8 File Offset: 0x001733F8
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E93 RID: 3731
		' (get) Token: 0x060024C6 RID: 9414 RVA: 0x00018DE2 File Offset: 0x00016FE2
		' (set) Token: 0x060024C7 RID: 9415 RVA: 0x00018DEC File Offset: 0x00016FEC
		Friend Overridable Property Label1 As Label

		' Token: 0x17000E94 RID: 3732
		' (get) Token: 0x060024C8 RID: 9416 RVA: 0x00018DF5 File Offset: 0x00016FF5
		' (set) Token: 0x060024C9 RID: 9417 RVA: 0x00175258 File Offset: 0x00173458
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

		' Token: 0x17000E95 RID: 3733
		' (get) Token: 0x060024CA RID: 9418 RVA: 0x00018DFF File Offset: 0x00016FFF
		' (set) Token: 0x060024CB RID: 9419 RVA: 0x00018E09 File Offset: 0x00017009
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000E96 RID: 3734
		' (get) Token: 0x060024CC RID: 9420 RVA: 0x00018E12 File Offset: 0x00017012
		' (set) Token: 0x060024CD RID: 9421 RVA: 0x001752B8 File Offset: 0x001734B8
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E97 RID: 3735
		' (get) Token: 0x060024CE RID: 9422 RVA: 0x00018E1C File Offset: 0x0001701C
		' (set) Token: 0x060024CF RID: 9423 RVA: 0x00018E26 File Offset: 0x00017026
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17000E98 RID: 3736
		' (get) Token: 0x060024D0 RID: 9424 RVA: 0x00018E2F File Offset: 0x0001702F
		' (set) Token: 0x060024D1 RID: 9425 RVA: 0x00018E39 File Offset: 0x00017039
		Friend Overridable Property Label13 As Label

		' Token: 0x17000E99 RID: 3737
		' (get) Token: 0x060024D2 RID: 9426 RVA: 0x00018E42 File Offset: 0x00017042
		' (set) Token: 0x060024D3 RID: 9427 RVA: 0x00018E4C File Offset: 0x0001704C
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000E9A RID: 3738
		' (get) Token: 0x060024D4 RID: 9428 RVA: 0x00018E55 File Offset: 0x00017055
		' (set) Token: 0x060024D5 RID: 9429 RVA: 0x00018E5F File Offset: 0x0001705F
		Friend Overridable Property ComboPack As DataGridViewTextBoxColumn

		' Token: 0x17000E9B RID: 3739
		' (get) Token: 0x060024D6 RID: 9430 RVA: 0x00018E68 File Offset: 0x00017068
		' (set) Token: 0x060024D7 RID: 9431 RVA: 0x00018E72 File Offset: 0x00017072
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000E9C RID: 3740
		' (get) Token: 0x060024D8 RID: 9432 RVA: 0x00018E7B File Offset: 0x0001707B
		' (set) Token: 0x060024D9 RID: 9433 RVA: 0x00018E85 File Offset: 0x00017085
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x060024DA RID: 9434 RVA: 0x001752FC File Offset: 0x001734FC
		Public Sub Reset()
			Me.cmbCategory.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
			Me.fillGategoryName()
			Me.GenerateBarcode()
			Me.cmbCategory.Focus()
		End Sub

		' Token: 0x060024DB RID: 9435 RVA: 0x00175370 File Offset: 0x00173570
		Public Sub fillGategoryName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ComboCategoryName) FROM Combopack order by 1 desc", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060024DC RID: 9436 RVA: 0x001754A4 File Offset: 0x001736A4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Combopack where ComboCategoryName=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the Combopack '" + Me.cmbCategory.Text.TrimEnd(New Char(-1) {}) + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x060024DD RID: 9437 RVA: 0x001755FC File Offset: 0x001737FC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtCategoryName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
					Me.btnUpdate.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060024DE RID: 9438 RVA: 0x001756E8 File Offset: 0x001738E8
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

		' Token: 0x060024DF RID: 9439 RVA: 0x001757D0 File Offset: 0x001739D0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ComboCategoryName),CBarcode,QRCBarcode from Combopack order by ComboCategoryName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060024E0 RID: 9440 RVA: 0x001758D0 File Offset: 0x00173AD0
		Private Sub frmcategory_Load(sender As Object, e As EventArgs)
			Me.LinkLabel1.TabStop = False
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060024E1 RID: 9441 RVA: 0x00175968 File Offset: 0x00173B68
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

		' Token: 0x060024E2 RID: 9442 RVA: 0x00175AE0 File Offset: 0x00173CE0
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

		' Token: 0x060024E3 RID: 9443 RVA: 0x00175B9C File Offset: 0x00173D9C
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

		' Token: 0x060024E4 RID: 9444 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060024E5 RID: 9445 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060024E6 RID: 9446 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060024E7 RID: 9447 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060024E8 RID: 9448 RVA: 0x00175C68 File Offset: 0x00173E68
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
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

		' Token: 0x060024E9 RID: 9449 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060024EA RID: 9450 RVA: 0x00018E8E File Offset: 0x0001708E
		Private Sub frmCategory_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmProduct.fillCategory()
		End Sub

		' Token: 0x060024EB RID: 9451 RVA: 0x00175F14 File Offset: 0x00174114
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x060024EC RID: 9452 RVA: 0x00018EA1 File Offset: 0x000170A1
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060024ED RID: 9453 RVA: 0x00175F70 File Offset: 0x00174170
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060024EE RID: 9454 RVA: 0x00175FF4 File Offset: 0x001741F4
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
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter ComboPack", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select ComboCategoryName from Combopack where ComboCategoryName=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("ComboPack Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbCategory.Text = ""
							Me.cmbCategory.Focus()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Me.Generate_GiftQR(Me.txtBarcode.Text.TrimEnd(New Char(-1) {}))
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Combopack(ComboCategoryName,CBarcode,QRCBarcode) VALUES (@d1,@d2,@d3)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text.TrimEnd(New Char(-1) {}))
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "added the new ComboPack '" + Me.cmbCategory.Text + "'")
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
							Me.fillGategoryName()
							Me.GenerateBarcode()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x060024EF RID: 9455 RVA: 0x0017637C File Offset: 0x0017457C
		Public Sub GenerateBarcode()
			Try
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcode.Text = "CO" + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060024F0 RID: 9456 RVA: 0x001763F4 File Offset: 0x001745F4
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Combopack ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060024F1 RID: 9457 RVA: 0x00176560 File Offset: 0x00174760
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter ComboPack", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
			Else
				Try
					Me.Generate_GiftQR(Me.txtBarcode.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update Combopack set ComboCategoryName=@d1,CBarcode=@d3,QRCBarcode=@d4 where ComboCategoryName=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCategoryName.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.TrimEnd(New Char(-1) {}))
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d4", SqlDbType.Image)
					sqlParameter.Value = buffer
					ModCommonClasses.cmd.Parameters.Add(sqlParameter)
					ModCommonClasses.cmd.ExecuteReader()
					ModFunc.LogFunc(Me.lblUser.Text, "updated the ComboPack '" + Me.cmbCategory.Text + "'")
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
					Me.fillGategoryName()
					Me.Reset()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060024F2 RID: 9458 RVA: 0x00176784 File Offset: 0x00174984
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

		' Token: 0x060024F3 RID: 9459 RVA: 0x001767EC File Offset: 0x001749EC
		Private Sub frmComboPackMaster_FormClosed(sender As Object, e As FormClosedEventArgs)
			MyProject.Forms.frmComboPack.fillGategoryName()
			MyProject.Forms.frmComboPack.cmbCategory.Text = Me.dgw.Rows(Me.dgw.RowCount - 1).Cells("ComboPack").Value.ToString()
		End Sub
	End Class
End Namespace
