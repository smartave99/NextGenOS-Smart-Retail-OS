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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005D4 RID: 1492
	<DesignerGenerated()>
	Public Partial Class frmLogs
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060123E9 RID: 74729 RVA: 0x0007D1A2 File Offset: 0x0007B3A2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmLogs_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007145 RID: 28997
		' (get) Token: 0x060123EC RID: 74732 RVA: 0x0007D1D4 File Offset: 0x0007B3D4
		' (set) Token: 0x060123ED RID: 74733 RVA: 0x0007D1DE File Offset: 0x0007B3DE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007146 RID: 28998
		' (get) Token: 0x060123EE RID: 74734 RVA: 0x0007D1E7 File Offset: 0x0007B3E7
		' (set) Token: 0x060123EF RID: 74735 RVA: 0x00A7F000 File Offset: 0x00A7D200
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007147 RID: 28999
		' (get) Token: 0x060123F0 RID: 74736 RVA: 0x0007D1F1 File Offset: 0x0007B3F1
		' (set) Token: 0x060123F1 RID: 74737 RVA: 0x0007D1FB File Offset: 0x0007B3FB
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17007148 RID: 29000
		' (get) Token: 0x060123F2 RID: 74738 RVA: 0x0007D204 File Offset: 0x0007B404
		' (set) Token: 0x060123F3 RID: 74739 RVA: 0x0007D20E File Offset: 0x0007B40E
		Friend Overridable Property Label1 As Label

		' Token: 0x17007149 RID: 29001
		' (get) Token: 0x060123F4 RID: 74740 RVA: 0x0007D217 File Offset: 0x0007B417
		' (set) Token: 0x060123F5 RID: 74741 RVA: 0x0007D221 File Offset: 0x0007B421
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700714A RID: 29002
		' (get) Token: 0x060123F6 RID: 74742 RVA: 0x0007D22A File Offset: 0x0007B42A
		' (set) Token: 0x060123F7 RID: 74743 RVA: 0x0007D234 File Offset: 0x0007B434
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700714B RID: 29003
		' (get) Token: 0x060123F8 RID: 74744 RVA: 0x0007D23D File Offset: 0x0007B43D
		' (set) Token: 0x060123F9 RID: 74745 RVA: 0x0007D247 File Offset: 0x0007B447
		Friend Overridable Property Label2 As Label

		' Token: 0x1700714C RID: 29004
		' (get) Token: 0x060123FA RID: 74746 RVA: 0x0007D250 File Offset: 0x0007B450
		' (set) Token: 0x060123FB RID: 74747 RVA: 0x0007D25A File Offset: 0x0007B45A
		Friend Overridable Property Label3 As Label

		' Token: 0x1700714D RID: 29005
		' (get) Token: 0x060123FC RID: 74748 RVA: 0x0007D263 File Offset: 0x0007B463
		' (set) Token: 0x060123FD RID: 74749 RVA: 0x00A7F044 File Offset: 0x00A7D244
		Private _cmbUserID As ComboBox
		Friend Overridable Property cmbUserID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbUserID_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbUserID_Format
				Dim comboBox As ComboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbUserID = value
				comboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700714E RID: 29006
		' (get) Token: 0x060123FE RID: 74750 RVA: 0x0007D26D File Offset: 0x0007B46D
		' (set) Token: 0x060123FF RID: 74751 RVA: 0x0007D277 File Offset: 0x0007B477
		Friend Overridable Property lblUser As Label

		' Token: 0x1700714F RID: 29007
		' (get) Token: 0x06012400 RID: 74752 RVA: 0x0007D280 File Offset: 0x0007B480
		' (set) Token: 0x06012401 RID: 74753 RVA: 0x0007D28A File Offset: 0x0007B48A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17007150 RID: 29008
		' (get) Token: 0x06012402 RID: 74754 RVA: 0x0007D293 File Offset: 0x0007B493
		' (set) Token: 0x06012403 RID: 74755 RVA: 0x0007D29D File Offset: 0x0007B49D
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17007151 RID: 29009
		' (get) Token: 0x06012404 RID: 74756 RVA: 0x0007D2A6 File Offset: 0x0007B4A6
		' (set) Token: 0x06012405 RID: 74757 RVA: 0x0007D2B0 File Offset: 0x0007B4B0
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17007152 RID: 29010
		' (get) Token: 0x06012406 RID: 74758 RVA: 0x0007D2B9 File Offset: 0x0007B4B9
		' (set) Token: 0x06012407 RID: 74759 RVA: 0x0007D2C3 File Offset: 0x0007B4C3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17007153 RID: 29011
		' (get) Token: 0x06012408 RID: 74760 RVA: 0x0007D2CC File Offset: 0x0007B4CC
		' (set) Token: 0x06012409 RID: 74761 RVA: 0x0007D2D6 File Offset: 0x0007B4D6
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17007154 RID: 29012
		' (get) Token: 0x0601240A RID: 74762 RVA: 0x0007D2DF File Offset: 0x0007B4DF
		' (set) Token: 0x0601240B RID: 74763 RVA: 0x0007D2E9 File Offset: 0x0007B4E9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17007155 RID: 29013
		' (get) Token: 0x0601240C RID: 74764 RVA: 0x0007D2F2 File Offset: 0x0007B4F2
		' (set) Token: 0x0601240D RID: 74765 RVA: 0x0007D2FC File Offset: 0x0007B4FC
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007156 RID: 29014
		' (get) Token: 0x0601240E RID: 74766 RVA: 0x0007D305 File Offset: 0x0007B505
		' (set) Token: 0x0601240F RID: 74767 RVA: 0x00A7F0A4 File Offset: 0x00A7D2A4
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007157 RID: 29015
		' (get) Token: 0x06012410 RID: 74768 RVA: 0x0007D30F File Offset: 0x0007B50F
		' (set) Token: 0x06012411 RID: 74769 RVA: 0x00A7F0E8 File Offset: 0x00A7D2E8
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007158 RID: 29016
		' (get) Token: 0x06012412 RID: 74770 RVA: 0x0007D319 File Offset: 0x0007B519
		' (set) Token: 0x06012413 RID: 74771 RVA: 0x00A7F12C File Offset: 0x00A7D32C
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

		' Token: 0x17007159 RID: 29017
		' (get) Token: 0x06012414 RID: 74772 RVA: 0x0007D323 File Offset: 0x0007B523
		' (set) Token: 0x06012415 RID: 74773 RVA: 0x00A7F170 File Offset: 0x00A7D370
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

		' Token: 0x06012416 RID: 74774 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06012417 RID: 74775 RVA: 0x00A7F1B4 File Offset: 0x00A7D3B4
		Public Sub fillCombo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(UserID) FROM Registration", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				Dim dataTable As DataTable = ModCommonClasses.ds.Tables(0)
				Me.cmbUserID.Items.Clear()
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbUserID.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06012418 RID: 74776 RVA: 0x00A7F2D8 File Offset: 0x00A7D4D8
		Private Sub cmbUserID_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(UserID),Date,RTRIM(Operation) from Logs where UserID=@d1 order by date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012419 RID: 74777 RVA: 0x00A7F3EC File Offset: 0x00A7D5EC
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(UserID),Date,RTRIM(Operation) from Logs order by Date", ModCommonClasses.con)
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

		' Token: 0x0601241A RID: 74778 RVA: 0x00A7F4EC File Offset: 0x00A7D6EC
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fillCombo()
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601241B RID: 74779 RVA: 0x00A7F57C File Offset: 0x00A7D77C
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) AS default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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

		' Token: 0x0601241C RID: 74780 RVA: 0x00A7F6F4 File Offset: 0x00A7D8F4
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

		' Token: 0x0601241D RID: 74781 RVA: 0x00A7F7B0 File Offset: 0x00A7D9B0
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

		' Token: 0x0601241E RID: 74782 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601241F RID: 74783 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012420 RID: 74784 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012421 RID: 74785 RVA: 0x0007D32D File Offset: 0x0007B52D
		Public Sub Reset()
			Me.cmbUserID.SelectedIndex = -1
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.GetData()
			Me.fillCombo()
		End Sub

		' Token: 0x06012422 RID: 74786 RVA: 0x00A7F87C File Offset: 0x00A7DA7C
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

		' Token: 0x06012423 RID: 74787 RVA: 0x00A7F964 File Offset: 0x00A7DB64
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con.Open()
				Dim text As String = "delete from logs"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "deleted the all logs till date '" + DateAndTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					Me.Reset()
					Me.GetData()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012424 RID: 74788 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbUserID_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06012425 RID: 74789 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmLogs_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012426 RID: 74790 RVA: 0x00A7FA90 File Offset: 0x00A7DC90
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(UserID),Date,RTRIM(Operation) from logs where Date >=@d1 and Date < @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012427 RID: 74791 RVA: 0x0007D36D File Offset: 0x0007B56D
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012428 RID: 74792 RVA: 0x00A7FC14 File Offset: 0x00A7DE14
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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

		' Token: 0x06012429 RID: 74793 RVA: 0x00A7FEC0 File Offset: 0x00A7E0C0
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete all logs?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
