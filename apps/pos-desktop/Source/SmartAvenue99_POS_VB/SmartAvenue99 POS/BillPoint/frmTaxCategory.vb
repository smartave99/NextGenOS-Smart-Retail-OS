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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000370 RID: 880
	<DesignerGenerated()>
	Public Partial Class frmTaxCategory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CFE2 RID: 53218 RVA: 0x00819C18 File Offset: 0x00817E18
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTaxCategory_Load
			AddHandler MyBase.Closing, AddressOf Me.frmTaxCategory_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmTaxCategory_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005188 RID: 20872
		' (get) Token: 0x0600CFE5 RID: 53221 RVA: 0x0005C703 File Offset: 0x0005A903
		' (set) Token: 0x0600CFE6 RID: 53222 RVA: 0x0005C70D File Offset: 0x0005A90D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005189 RID: 20873
		' (get) Token: 0x0600CFE7 RID: 53223 RVA: 0x0005C716 File Offset: 0x0005A916
		' (set) Token: 0x0600CFE8 RID: 53224 RVA: 0x0005C720 File Offset: 0x0005A920
		Friend Overridable Property Label1 As Label

		' Token: 0x1700518A RID: 20874
		' (get) Token: 0x0600CFE9 RID: 53225 RVA: 0x0005C729 File Offset: 0x0005A929
		' (set) Token: 0x0600CFEA RID: 53226 RVA: 0x0081AF40 File Offset: 0x00819140
		Private _txtTax As TextBox
		Friend Overridable Property txtTax As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTax_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtTax_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtTax
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtTax = value
				textBox = Me._txtTax
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700518B RID: 20875
		' (get) Token: 0x0600CFEB RID: 53227 RVA: 0x0005C733 File Offset: 0x0005A933
		' (set) Token: 0x0600CFEC RID: 53228 RVA: 0x0081AFBC File Offset: 0x008191BC
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

		' Token: 0x1700518C RID: 20876
		' (get) Token: 0x0600CFED RID: 53229 RVA: 0x0005C73D File Offset: 0x0005A93D
		' (set) Token: 0x0600CFEE RID: 53230 RVA: 0x0005C747 File Offset: 0x0005A947
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x1700518D RID: 20877
		' (get) Token: 0x0600CFEF RID: 53231 RVA: 0x0005C750 File Offset: 0x0005A950
		' (set) Token: 0x0600CFF0 RID: 53232 RVA: 0x0005C75A File Offset: 0x0005A95A
		Friend Overridable Property lblUser As Label

		' Token: 0x1700518E RID: 20878
		' (get) Token: 0x0600CFF1 RID: 53233 RVA: 0x0005C763 File Offset: 0x0005A963
		' (set) Token: 0x0600CFF2 RID: 53234 RVA: 0x0005C76D File Offset: 0x0005A96D
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700518F RID: 20879
		' (get) Token: 0x0600CFF3 RID: 53235 RVA: 0x0005C776 File Offset: 0x0005A976
		' (set) Token: 0x0600CFF4 RID: 53236 RVA: 0x0005C780 File Offset: 0x0005A980
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005190 RID: 20880
		' (get) Token: 0x0600CFF5 RID: 53237 RVA: 0x0005C789 File Offset: 0x0005A989
		' (set) Token: 0x0600CFF6 RID: 53238 RVA: 0x0005C793 File Offset: 0x0005A993
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005191 RID: 20881
		' (get) Token: 0x0600CFF7 RID: 53239 RVA: 0x0005C79C File Offset: 0x0005A99C
		' (set) Token: 0x0600CFF8 RID: 53240 RVA: 0x0005C7A6 File Offset: 0x0005A9A6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005192 RID: 20882
		' (get) Token: 0x0600CFF9 RID: 53241 RVA: 0x0005C7AF File Offset: 0x0005A9AF
		' (set) Token: 0x0600CFFA RID: 53242 RVA: 0x0005C7B9 File Offset: 0x0005A9B9
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005193 RID: 20883
		' (get) Token: 0x0600CFFB RID: 53243 RVA: 0x0005C7C2 File Offset: 0x0005A9C2
		' (set) Token: 0x0600CFFC RID: 53244 RVA: 0x0005C7CC File Offset: 0x0005A9CC
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005194 RID: 20884
		' (get) Token: 0x0600CFFD RID: 53245 RVA: 0x0005C7D5 File Offset: 0x0005A9D5
		' (set) Token: 0x0600CFFE RID: 53246 RVA: 0x0005C7DF File Offset: 0x0005A9DF
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x17005195 RID: 20885
		' (get) Token: 0x0600CFFF RID: 53247 RVA: 0x0005C7E8 File Offset: 0x0005A9E8
		' (set) Token: 0x0600D000 RID: 53248 RVA: 0x0005C7F2 File Offset: 0x0005A9F2
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005196 RID: 20886
		' (get) Token: 0x0600D001 RID: 53249 RVA: 0x0005C7FB File Offset: 0x0005A9FB
		' (set) Token: 0x0600D002 RID: 53250 RVA: 0x0081B01C File Offset: 0x0081921C
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
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

		' Token: 0x17005197 RID: 20887
		' (get) Token: 0x0600D003 RID: 53251 RVA: 0x0005C805 File Offset: 0x0005AA05
		' (set) Token: 0x0600D004 RID: 53252 RVA: 0x0081B060 File Offset: 0x00819260
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
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

		' Token: 0x17005198 RID: 20888
		' (get) Token: 0x0600D005 RID: 53253 RVA: 0x0005C80F File Offset: 0x0005AA0F
		' (set) Token: 0x0600D006 RID: 53254 RVA: 0x0081B0A4 File Offset: 0x008192A4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click_1
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

		' Token: 0x17005199 RID: 20889
		' (get) Token: 0x0600D007 RID: 53255 RVA: 0x0005C819 File Offset: 0x0005AA19
		' (set) Token: 0x0600D008 RID: 53256 RVA: 0x0081B0E8 File Offset: 0x008192E8
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

		' Token: 0x1700519A RID: 20890
		' (get) Token: 0x0600D009 RID: 53257 RVA: 0x0005C823 File Offset: 0x0005AA23
		' (set) Token: 0x0600D00A RID: 53258 RVA: 0x0005C82D File Offset: 0x0005AA2D
		Friend Overridable Property lblSource As Label

		' Token: 0x1700519B RID: 20891
		' (get) Token: 0x0600D00B RID: 53259 RVA: 0x0005C836 File Offset: 0x0005AA36
		' (set) Token: 0x0600D00C RID: 53260 RVA: 0x0081B12C File Offset: 0x0081932C
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click_1
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

		' Token: 0x0600D00D RID: 53261 RVA: 0x0081B170 File Offset: 0x00819370
		Public Sub Reset()
			Me.CheckBox1.Checked = False
			Me.txtTax.Text = ""
			Me.txtTax.Focus()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.Getdata()
		End Sub

		' Token: 0x0600D00E RID: 53262 RVA: 0x0081B1D8 File Offset: 0x008193D8
		Public Sub Getdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(Rate), RTRIM(IsDefault) from TaxCat order by IsDefault desc", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2) })
				End While
				Me.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D00F RID: 53263 RVA: 0x0005C840 File Offset: 0x0005AA40
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600D010 RID: 53264 RVA: 0x0081B2E4 File Offset: 0x008194E4
		Private Sub DeleteRecord()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "delete from TaxCat where ID=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
				Me.cmd.Connection = Me.con
				Dim num As Integer = Me.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim text2 As String = "deleted the new GST Rate % is : '" + Conversions.ToString(Conversion.Val(Me.txtTax.Text)) + "'"
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = Me.con.State = ConnectionState.Open
				If flag2 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D011 RID: 53265 RVA: 0x0081B438 File Offset: 0x00819638
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtTax.Text = dataGridViewRow.Cells(1).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.CheckBox1.Checked = True
					Else
						Me.CheckBox1.Checked = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600D012 RID: 53266 RVA: 0x0081B54C File Offset: 0x0081974C
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

		' Token: 0x0600D013 RID: 53267 RVA: 0x0081B634 File Offset: 0x00819834
		Private Sub frmTaxCategory_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600D014 RID: 53268 RVA: 0x0081B6BC File Offset: 0x008198BC
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600D015 RID: 53269 RVA: 0x0081B95C File Offset: 0x00819B5C
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x0600D016 RID: 53270 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600D017 RID: 53271 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTax_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600D018 RID: 53272 RVA: 0x0081BA10 File Offset: 0x00819C10
		Private Sub txtTax_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600D019 RID: 53273 RVA: 0x0081BA64 File Offset: 0x00819C64
		Private Sub frmTaxCategory_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec", False) = 0
			If flag Then
				MyProject.Forms.frmProductRec.fillTaxRate()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec1", False) = 0
				If flag2 Then
					MyProject.Forms.frmProductRec1.fillTaxRate()
				Else
					MyProject.Forms.frmProduct.fillTaxRate()
				End If
			End If
		End Sub

		' Token: 0x0600D01A RID: 53274 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTaxCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600D01B RID: 53275 RVA: 0x0081BAE4 File Offset: 0x00819CE4
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtTax.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtTax, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtTax, String.Empty)
			End If
		End Sub

		' Token: 0x0600D01C RID: 53276 RVA: 0x0005C840 File Offset: 0x0005AA40
		Private Sub btnNew_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600D01D RID: 53277 RVA: 0x0081BB40 File Offset: 0x00819D40
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "select * from Company"
			Me.cmd = New SqlCommand(text)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag As Boolean = Not Me.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Else
				Dim flag3 As Boolean = Operators.CompareString(Me.txtTax.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter GST Rate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTax.Focus()
				Else
					Try
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text2 As String = "select IsDefault from TaxCat where IsDefault='Yes'"
							Me.cmd = New SqlCommand(text2)
							Me.cmd.Connection = Me.con
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag4 As Boolean = Me.rdr.Read()
							If flag4 Then
								MessageBox.Show("GST Rate is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = Me.rdr IsNot Nothing
								If flag5 Then
									Me.rdr.Close()
								End If
								Return
							End If
						End If
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text3 As String = "select Rate from TaxCat where Rate=@d1"
						Me.cmd = New SqlCommand(text3)
						Me.cmd.Connection = Me.con
						Me.cmd.Parameters.AddWithValue("@d1", Me.txtTax.Text)
						Me.rdr = Me.cmd.ExecuteReader()
						Dim flag6 As Boolean = Me.rdr.Read()
						If flag6 Then
							MessageBox.Show("GST Rate Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtTax.Text = ""
							Me.txtTax.Focus()
							Dim flag7 As Boolean = Me.rdr IsNot Nothing
							If flag7 Then
								Me.rdr.Close()
							End If
						Else
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text4 As String = "insert into TaxCat (Rate,IsDefault) VALUES (@d1,@d2)"
							Me.cmd = New SqlCommand(text4)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtTax.Text))
							Me.cmd.Parameters.AddWithValue("@d2", Me.st2)
							Me.cmd.ExecuteReader()
							Me.con.Close()
							Dim text5 As String = "added the new GST Rate % is : '" + Conversions.ToString(Conversion.Val(Me.txtTax.Text)) + "'"
							Me.LogFunc(Me.lblUser.Text, text5)
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600D01E RID: 53278 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LogFunc(text As String, st As String)
		End Sub

		' Token: 0x0600D01F RID: 53279 RVA: 0x0081BF30 File Offset: 0x0081A130
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtTax.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter GST Rate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtTax.Focus()
			Else
				Try
					Dim checked As Boolean = Me.CheckBox1.Checked
					If checked Then
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text As String = "Update TaxCat set IsDefault='No'"
						Me.cmd = New SqlCommand(text)
						Me.cmd.Connection = Me.con
						Me.cmd.ExecuteReader()
					End If
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Me.st2 = "Yes"
					Else
						Me.st2 = "No"
					End If
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text2 As String = "Update TaxCat set Rate=@d1, IsDefault=@d2 where ID=@d3"
					Me.cmd = New SqlCommand(text2)
					Me.cmd.Connection = Me.con
					Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtTax.Text))
					Me.cmd.Parameters.AddWithValue("@d2", Me.st2)
					Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtID.Text))
					Me.cmd.ExecuteReader()
					Me.con.Close()
					Dim text3 As String = "updated the new GST Rate % is : '" + Conversions.ToString(Conversion.Val(Me.txtTax.Text)) + "'"
					Me.LogFunc(Me.lblUser.Text, text3)
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600D020 RID: 53280 RVA: 0x0081C17C File Offset: 0x0081A37C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D021 RID: 53281 RVA: 0x0005C84A File Offset: 0x0005AA4A
		Private Sub GelButton1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmTaxCategoryNew.ShowDialog()
		End Sub

		' Token: 0x0400537A RID: 21370
		Private st2 As String

		' Token: 0x0400537B RID: 21371
		Private con As SqlConnection

		' Token: 0x0400537C RID: 21372
		Private cmd As SqlCommand

		' Token: 0x0400537D RID: 21373
		Private rdr As SqlDataReader

		' Token: 0x0400537E RID: 21374
		Private adp As SqlDataAdapter

		' Token: 0x0400537F RID: 21375
		Private ds As DataSet

		' Token: 0x04005380 RID: 21376
		Private dtable As DataTable
	End Class
End Namespace
