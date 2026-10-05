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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002A2 RID: 674
	<DesignerGenerated()>
	Public Partial Class frmInvoiceHeader
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600ACA2 RID: 44194 RVA: 0x0005065E File Offset: 0x0004E85E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmInvoiceHeader_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmInvoiceHeader_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170042C5 RID: 17093
		' (get) Token: 0x0600ACA5 RID: 44197 RVA: 0x00050690 File Offset: 0x0004E890
		' (set) Token: 0x0600ACA6 RID: 44198 RVA: 0x0005069A File Offset: 0x0004E89A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170042C6 RID: 17094
		' (get) Token: 0x0600ACA7 RID: 44199 RVA: 0x000506A3 File Offset: 0x0004E8A3
		' (set) Token: 0x0600ACA8 RID: 44200 RVA: 0x000506AD File Offset: 0x0004E8AD
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170042C7 RID: 17095
		' (get) Token: 0x0600ACA9 RID: 44201 RVA: 0x000506B6 File Offset: 0x0004E8B6
		' (set) Token: 0x0600ACAA RID: 44202 RVA: 0x000506C0 File Offset: 0x0004E8C0
		Friend Overridable Property Label1 As Label

		' Token: 0x170042C8 RID: 17096
		' (get) Token: 0x0600ACAB RID: 44203 RVA: 0x000506C9 File Offset: 0x0004E8C9
		' (set) Token: 0x0600ACAC RID: 44204 RVA: 0x000506D3 File Offset: 0x0004E8D3
		Friend Overridable Property txtU As TextBox

		' Token: 0x170042C9 RID: 17097
		' (get) Token: 0x0600ACAD RID: 44205 RVA: 0x000506DC File Offset: 0x0004E8DC
		' (set) Token: 0x0600ACAE RID: 44206 RVA: 0x000506E6 File Offset: 0x0004E8E6
		Friend Overridable Property lblUser As Label

		' Token: 0x170042CA RID: 17098
		' (get) Token: 0x0600ACAF RID: 44207 RVA: 0x000506EF File Offset: 0x0004E8EF
		' (set) Token: 0x0600ACB0 RID: 44208 RVA: 0x000506F9 File Offset: 0x0004E8F9
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170042CB RID: 17099
		' (get) Token: 0x0600ACB1 RID: 44209 RVA: 0x00050702 File Offset: 0x0004E902
		' (set) Token: 0x0600ACB2 RID: 44210 RVA: 0x007374DC File Offset: 0x007356DC
		Private _txtUnit As TextBox
		Friend Overridable Property txtUnit As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtUnit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtUnit
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtUnit = value
				textBox = Me._txtUnit
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042CC RID: 17100
		' (get) Token: 0x0600ACB3 RID: 44211 RVA: 0x0005070C File Offset: 0x0004E90C
		' (set) Token: 0x0600ACB4 RID: 44212 RVA: 0x00050716 File Offset: 0x0004E916
		Friend Overridable Property Label3 As Label

		' Token: 0x170042CD RID: 17101
		' (get) Token: 0x0600ACB5 RID: 44213 RVA: 0x0005071F File Offset: 0x0004E91F
		' (set) Token: 0x0600ACB6 RID: 44214 RVA: 0x0073753C File Offset: 0x0073573C
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

		' Token: 0x170042CE RID: 17102
		' (get) Token: 0x0600ACB7 RID: 44215 RVA: 0x00050729 File Offset: 0x0004E929
		' (set) Token: 0x0600ACB8 RID: 44216 RVA: 0x0073759C File Offset: 0x0073579C
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
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042CF RID: 17103
		' (get) Token: 0x0600ACB9 RID: 44217 RVA: 0x00050733 File Offset: 0x0004E933
		' (set) Token: 0x0600ACBA RID: 44218 RVA: 0x0005073D File Offset: 0x0004E93D
		Friend Overridable Property Label2 As Label

		' Token: 0x170042D0 RID: 17104
		' (get) Token: 0x0600ACBB RID: 44219 RVA: 0x00050746 File Offset: 0x0004E946
		' (set) Token: 0x0600ACBC RID: 44220 RVA: 0x00050750 File Offset: 0x0004E950
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170042D1 RID: 17105
		' (get) Token: 0x0600ACBD RID: 44221 RVA: 0x00050759 File Offset: 0x0004E959
		' (set) Token: 0x0600ACBE RID: 44222 RVA: 0x00050763 File Offset: 0x0004E963
		Friend Overridable Property Label4 As Label

		' Token: 0x170042D2 RID: 17106
		' (get) Token: 0x0600ACBF RID: 44223 RVA: 0x0005076C File Offset: 0x0004E96C
		' (set) Token: 0x0600ACC0 RID: 44224 RVA: 0x007375FC File Offset: 0x007357FC
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox2_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042D3 RID: 17107
		' (get) Token: 0x0600ACC1 RID: 44225 RVA: 0x00050776 File Offset: 0x0004E976
		' (set) Token: 0x0600ACC2 RID: 44226 RVA: 0x00050780 File Offset: 0x0004E980
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170042D4 RID: 17108
		' (get) Token: 0x0600ACC3 RID: 44227 RVA: 0x00050789 File Offset: 0x0004E989
		' (set) Token: 0x0600ACC4 RID: 44228 RVA: 0x00050793 File Offset: 0x0004E993
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170042D5 RID: 17109
		' (get) Token: 0x0600ACC5 RID: 44229 RVA: 0x0005079C File Offset: 0x0004E99C
		' (set) Token: 0x0600ACC6 RID: 44230 RVA: 0x000507A6 File Offset: 0x0004E9A6
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170042D6 RID: 17110
		' (get) Token: 0x0600ACC7 RID: 44231 RVA: 0x000507AF File Offset: 0x0004E9AF
		' (set) Token: 0x0600ACC8 RID: 44232 RVA: 0x000507B9 File Offset: 0x0004E9B9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170042D7 RID: 17111
		' (get) Token: 0x0600ACC9 RID: 44233 RVA: 0x000507C2 File Offset: 0x0004E9C2
		' (set) Token: 0x0600ACCA RID: 44234 RVA: 0x000507CC File Offset: 0x0004E9CC
		Friend Overridable Property Label5 As Label

		' Token: 0x170042D8 RID: 17112
		' (get) Token: 0x0600ACCB RID: 44235 RVA: 0x000507D5 File Offset: 0x0004E9D5
		' (set) Token: 0x0600ACCC RID: 44236 RVA: 0x000507DF File Offset: 0x0004E9DF
		Friend Overridable Property txtTillID As TextBox

		' Token: 0x170042D9 RID: 17113
		' (get) Token: 0x0600ACCD RID: 44237 RVA: 0x000507E8 File Offset: 0x0004E9E8
		' (set) Token: 0x0600ACCE RID: 44238 RVA: 0x0073765C File Offset: 0x0073585C
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

		' Token: 0x170042DA RID: 17114
		' (get) Token: 0x0600ACCF RID: 44239 RVA: 0x000507F2 File Offset: 0x0004E9F2
		' (set) Token: 0x0600ACD0 RID: 44240 RVA: 0x007376A0 File Offset: 0x007358A0
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
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

		' Token: 0x170042DB RID: 17115
		' (get) Token: 0x0600ACD1 RID: 44241 RVA: 0x000507FC File Offset: 0x0004E9FC
		' (set) Token: 0x0600ACD2 RID: 44242 RVA: 0x007376E4 File Offset: 0x007358E4
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

		' Token: 0x170042DC RID: 17116
		' (get) Token: 0x0600ACD3 RID: 44243 RVA: 0x00050806 File Offset: 0x0004EA06
		' (set) Token: 0x0600ACD4 RID: 44244 RVA: 0x00737728 File Offset: 0x00735928
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
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

		' Token: 0x0600ACD5 RID: 44245 RVA: 0x0073776C File Offset: 0x0073596C
		Private Sub frmInvoiceHeader_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600ACD6 RID: 44246 RVA: 0x007377FC File Offset: 0x007359FC
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

		' Token: 0x0600ACD7 RID: 44247 RVA: 0x00737974 File Offset: 0x00735B74
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

		' Token: 0x0600ACD8 RID: 44248 RVA: 0x00737A30 File Offset: 0x00735C30
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

		' Token: 0x0600ACD9 RID: 44249 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600ACDA RID: 44250 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600ACDB RID: 44251 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ACDC RID: 44252 RVA: 0x00737AFC File Offset: 0x00735CFC
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Name),RTRIM(LIDS), RTRIM(DefInvTemp), RTRIM(TID) from InvoiceHead order by Name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				Me.dgw.ClearSelection()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ACDD RID: 44253 RVA: 0x00737C08 File Offset: 0x00735E08
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from InvoiceHead where TID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x0600ACDE RID: 44254 RVA: 0x00737D28 File Offset: 0x00735F28
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtUnit.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtU.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.ComboBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.ComboBox2.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtTillID.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.Button3.Enabled = True
					Me.Button2.Enabled = True
					Me.Button4.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ACDF RID: 44255 RVA: 0x00737E64 File Offset: 0x00736064
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

		' Token: 0x0600ACE0 RID: 44256 RVA: 0x00737F4C File Offset: 0x0073614C
		Public Sub Reset()
			Me.txtUnit.Text = ""
			Me.Button4.Enabled = True
			Me.Button2.Enabled = False
			Me.Button3.Enabled = False
			Me.txtUnit.Focus()
			Me.ComboBox1.SelectedIndex = 0
			Me.ComboBox2.SelectedIndex = 0
			Me.txtTillID.Text = Dns.GetHostName()
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0600ACE1 RID: 44257 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ACE2 RID: 44258 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmInvoiceHeader_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600ACE3 RID: 44259 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ACE4 RID: 44260 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ACE5 RID: 44261 RVA: 0x00737FD8 File Offset: 0x007361D8
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtUnit.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtUnit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtUnit, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.ComboBox2.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.ComboBox2, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox2, String.Empty)
			End If
		End Sub

		' Token: 0x0600ACE6 RID: 44262 RVA: 0x00050810 File Offset: 0x0004EA10
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600ACE7 RID: 44263 RVA: 0x007380CC File Offset: 0x007362CC
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
				Try
					Dim flag3 As Boolean = Operators.CompareString(Me.txtUnit.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter Header Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtUnit.Focus()
					Else
						Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please enter Last Invoice Date Show", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ComboBox1.Focus()
						Else
							Dim flag5 As Boolean = Me.ComboBox2.SelectedIndex = -1
							If flag5 Then
								MessageBox.Show("Please select default invoice template", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ComboBox2.Focus()
							Else
								Try
									For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(Me.txtTillID.Text, dataGridViewRow.Cells(3).Value, False)
										If flag6 Then
											MessageBox.Show("Same Terminal ID can not be accepted", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtTillID.Focus()
											Return
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "insert into InvoiceHead(Name, LIDS, DefInvTemp,TID) VALUES (@d1,@d2,@d3,@d4)"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUnit.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtTillID.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Button4.Enabled = False
								Me.Getdata()
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600ACE8 RID: 44264 RVA: 0x00738414 File Offset: 0x00736614
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Operators.CompareString(Me.txtUnit.Text, "", False) = 0) And (Me.ComboBox1.SelectedIndex = -1)
			If flag Then
				MessageBox.Show("Please fill required field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtUnit.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtUnit.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter Header Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtUnit.Focus()
				Else
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please enter Last Invoice Date Show", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ComboBox1.Focus()
					Else
						Dim flag4 As Boolean = Me.ComboBox2.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please select default invoice template", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ComboBox2.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update InvoiceHead set Name=@d1, LIDS=@d2, DefInvTemp=@d3 where TID=@d4"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUnit.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtTillID.Text)
								ModCommonClasses.cmd.ExecuteReader()
								MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Button3.Enabled = False
								Me.Getdata()
								Me.Reset()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600ACE9 RID: 44265 RVA: 0x00738654 File Offset: 0x00736854
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
					Me.Reset()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
