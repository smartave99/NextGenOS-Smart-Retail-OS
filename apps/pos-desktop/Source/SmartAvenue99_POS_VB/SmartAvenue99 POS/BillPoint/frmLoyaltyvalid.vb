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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004D4 RID: 1236
	<DesignerGenerated()>
	Public Partial Class frmLoyaltyvalid
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FB9F RID: 64415 RVA: 0x0006E4E5 File Offset: 0x0006C6E5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLoyaltyvalid_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmLoyaltyvalid_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006046 RID: 24646
		' (get) Token: 0x0600FBA2 RID: 64418 RVA: 0x0006E517 File Offset: 0x0006C717
		' (set) Token: 0x0600FBA3 RID: 64419 RVA: 0x0006E521 File Offset: 0x0006C721
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006047 RID: 24647
		' (get) Token: 0x0600FBA4 RID: 64420 RVA: 0x0006E52A File Offset: 0x0006C72A
		' (set) Token: 0x0600FBA5 RID: 64421 RVA: 0x0006E534 File Offset: 0x0006C734
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006048 RID: 24648
		' (get) Token: 0x0600FBA6 RID: 64422 RVA: 0x0006E53D File Offset: 0x0006C73D
		' (set) Token: 0x0600FBA7 RID: 64423 RVA: 0x0006E547 File Offset: 0x0006C747
		Friend Overridable Property Label1 As Label

		' Token: 0x17006049 RID: 24649
		' (get) Token: 0x0600FBA8 RID: 64424 RVA: 0x0006E550 File Offset: 0x0006C750
		' (set) Token: 0x0600FBA9 RID: 64425 RVA: 0x0006E55A File Offset: 0x0006C75A
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700604A RID: 24650
		' (get) Token: 0x0600FBAA RID: 64426 RVA: 0x0006E563 File Offset: 0x0006C763
		' (set) Token: 0x0600FBAB RID: 64427 RVA: 0x0096ADF4 File Offset: 0x00968FF4
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

		' Token: 0x1700604B RID: 24651
		' (get) Token: 0x0600FBAC RID: 64428 RVA: 0x0006E56D File Offset: 0x0006C76D
		' (set) Token: 0x0600FBAD RID: 64429 RVA: 0x0006E577 File Offset: 0x0006C777
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700604C RID: 24652
		' (get) Token: 0x0600FBAE RID: 64430 RVA: 0x0006E580 File Offset: 0x0006C780
		' (set) Token: 0x0600FBAF RID: 64431 RVA: 0x0006E58A File Offset: 0x0006C78A
		Friend Overridable Property Label2 As Label

		' Token: 0x1700604D RID: 24653
		' (get) Token: 0x0600FBB0 RID: 64432 RVA: 0x0006E593 File Offset: 0x0006C793
		' (set) Token: 0x0600FBB1 RID: 64433 RVA: 0x0096AE54 File Offset: 0x00969054
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

		' Token: 0x1700604E RID: 24654
		' (get) Token: 0x0600FBB2 RID: 64434 RVA: 0x0006E59D File Offset: 0x0006C79D
		' (set) Token: 0x0600FBB3 RID: 64435 RVA: 0x0006E5A7 File Offset: 0x0006C7A7
		Friend Overridable Property Label4 As Label

		' Token: 0x1700604F RID: 24655
		' (get) Token: 0x0600FBB4 RID: 64436 RVA: 0x0006E5B0 File Offset: 0x0006C7B0
		' (set) Token: 0x0600FBB5 RID: 64437 RVA: 0x0006E5BA File Offset: 0x0006C7BA
		Friend Overridable Property Label3 As Label

		' Token: 0x17006050 RID: 24656
		' (get) Token: 0x0600FBB6 RID: 64438 RVA: 0x0006E5C3 File Offset: 0x0006C7C3
		' (set) Token: 0x0600FBB7 RID: 64439 RVA: 0x0096AEB4 File Offset: 0x009690B4
		Private _txtNum As TextBox
		Friend Overridable Property txtNum As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNum
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNum_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtNum
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtNum = value
				textBox = Me._txtNum
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006051 RID: 24657
		' (get) Token: 0x0600FBB8 RID: 64440 RVA: 0x0006E5CD File Offset: 0x0006C7CD
		' (set) Token: 0x0600FBB9 RID: 64441 RVA: 0x0006E5D7 File Offset: 0x0006C7D7
		Friend Overridable Property lblUser As Label

		' Token: 0x17006052 RID: 24658
		' (get) Token: 0x0600FBBA RID: 64442 RVA: 0x0006E5E0 File Offset: 0x0006C7E0
		' (set) Token: 0x0600FBBB RID: 64443 RVA: 0x0006E5EA File Offset: 0x0006C7EA
		Friend Overridable Property Label7 As Label

		' Token: 0x17006053 RID: 24659
		' (get) Token: 0x0600FBBC RID: 64444 RVA: 0x0006E5F3 File Offset: 0x0006C7F3
		' (set) Token: 0x0600FBBD RID: 64445 RVA: 0x0096AF14 File Offset: 0x00969114
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

		' Token: 0x17006054 RID: 24660
		' (get) Token: 0x0600FBBE RID: 64446 RVA: 0x0006E5FD File Offset: 0x0006C7FD
		' (set) Token: 0x0600FBBF RID: 64447 RVA: 0x0006E607 File Offset: 0x0006C807
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006055 RID: 24661
		' (get) Token: 0x0600FBC0 RID: 64448 RVA: 0x0006E610 File Offset: 0x0006C810
		' (set) Token: 0x0600FBC1 RID: 64449 RVA: 0x0006E61A File Offset: 0x0006C81A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006056 RID: 24662
		' (get) Token: 0x0600FBC2 RID: 64450 RVA: 0x0006E623 File Offset: 0x0006C823
		' (set) Token: 0x0600FBC3 RID: 64451 RVA: 0x0006E62D File Offset: 0x0006C82D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006057 RID: 24663
		' (get) Token: 0x0600FBC4 RID: 64452 RVA: 0x0006E636 File Offset: 0x0006C836
		' (set) Token: 0x0600FBC5 RID: 64453 RVA: 0x0006E640 File Offset: 0x0006C840
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006058 RID: 24664
		' (get) Token: 0x0600FBC6 RID: 64454 RVA: 0x0006E649 File Offset: 0x0006C849
		' (set) Token: 0x0600FBC7 RID: 64455 RVA: 0x0006E653 File Offset: 0x0006C853
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006059 RID: 24665
		' (get) Token: 0x0600FBC8 RID: 64456 RVA: 0x0006E65C File Offset: 0x0006C85C
		' (set) Token: 0x0600FBC9 RID: 64457 RVA: 0x0096AF74 File Offset: 0x00969174
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

		' Token: 0x1700605A RID: 24666
		' (get) Token: 0x0600FBCA RID: 64458 RVA: 0x0006E666 File Offset: 0x0006C866
		' (set) Token: 0x0600FBCB RID: 64459 RVA: 0x0096AFB8 File Offset: 0x009691B8
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

		' Token: 0x1700605B RID: 24667
		' (get) Token: 0x0600FBCC RID: 64460 RVA: 0x0006E670 File Offset: 0x0006C870
		' (set) Token: 0x0600FBCD RID: 64461 RVA: 0x0096AFFC File Offset: 0x009691FC
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

		' Token: 0x1700605C RID: 24668
		' (get) Token: 0x0600FBCE RID: 64462 RVA: 0x0006E67A File Offset: 0x0006C87A
		' (set) Token: 0x0600FBCF RID: 64463 RVA: 0x0096B040 File Offset: 0x00969240
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

		' Token: 0x0600FBD0 RID: 64464 RVA: 0x0096B084 File Offset: 0x00969284
		Public Sub Clear()
			Me.txtNum.Text = "0"
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.GetData()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600FBD1 RID: 64465 RVA: 0x0096B0EC File Offset: 0x009692EC
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT id, RTRIM(c1),RTRIM(c3),RTRIM(c2) from Lpointstatus", ModCommonClasses.con)
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

		' Token: 0x0600FBD2 RID: 64466 RVA: 0x0096B1F0 File Offset: 0x009693F0
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
				Me.txtNum.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.ComboBox2.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(3).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FBD3 RID: 64467 RVA: 0x0096B2FC File Offset: 0x009694FC
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

		' Token: 0x0600FBD4 RID: 64468 RVA: 0x0096B3E4 File Offset: 0x009695E4
		Private Sub frmLoyaltyvalid_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FBD5 RID: 64469 RVA: 0x0096B46C File Offset: 0x0096966C
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

		' Token: 0x0600FBD6 RID: 64470 RVA: 0x0096B70C File Offset: 0x0096990C
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

		' Token: 0x0600FBD7 RID: 64471 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FBD8 RID: 64472 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNum_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FBD9 RID: 64473 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FBDA RID: 64474 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FBDB RID: 64475 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmLoyaltyvalid_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FBDC RID: 64476 RVA: 0x0096B7C8 File Offset: 0x009699C8
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtNum.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtNum, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtNum, String.Empty)
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

		' Token: 0x0600FBDD RID: 64477 RVA: 0x0006E684 File Offset: 0x0006C884
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.txtNum.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600FBDE RID: 64478 RVA: 0x0096B8BC File Offset: 0x00969ABC
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
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
					Dim flag3 As Boolean = Operators.CompareString(Me.txtNum.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please fill the Loyalty Point", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtNum.Focus()
					Else
						Dim flag4 As Boolean = Me.ComboBox2.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please fill Calculate On", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox2.Focus()
						Else
							Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = -1
							If flag5 Then
								MessageBox.Show("Please fill the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.ComboBox1.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "Select count(*) from Lpointstatus Having count(*) >= 1"
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
										Dim text3 As String = "insert into Lpointstatus(c1,c2,c3) VALUES (@d1,@d2,@d3)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtNum.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										ModFunc.LogFunc(Me.lblUser.Text, "Added the Loyalty Point : '" + Me.txtNum.Text + "'")
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

		' Token: 0x0600FBDF RID: 64479 RVA: 0x0096BC30 File Offset: 0x00969E30
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					flag = ModCommonClasses.rdr IsNot Nothing
					Dim flag3 As Boolean = flag
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Me.Clear()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtNum.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please fill the Loyalty Point", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtNum.Focus()
					Else
						Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = -1
						If flag5 Then
							MessageBox.Show("Please fill the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox1.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = If(("Update Lpointstatus set c1=@d1,c2=@d2,c3=@d3 where ID=" + Me.TextBox2.Text), "")
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtNum.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModFunc.LogFunc(Me.lblUser.Text, "Updated the Loyalty Point : '" + Me.txtNum.Text + "'")
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
			Finally
			End Try
		End Sub

		' Token: 0x0600FBE0 RID: 64480 RVA: 0x0096BEFC File Offset: 0x0096A0FC
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Lpointstatus WHERE id = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						ModFunc.LogFunc(Me.lblUser.Text, "Deleted the Loyalty Point : '" + Me.txtNum.Text + "'")
						MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Clear()
					End If
				End If
				Me.GetData()
				Me.Clear()
				ModCommonClasses.con.Close()
				Me.Button4.Enabled = True
				Me.Button3.Enabled = False
				Me.Button3.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
