Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002A3 RID: 675
	<DesignerGenerated()>
	Public Partial Class frmKitchen_Section
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600ACEA RID: 44266 RVA: 0x007386C4 File Offset: 0x007368C4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmKitchen_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmKitchen_Section_FormClosing
			AddHandler MyBase.KeyDown, AddressOf Me.frmKitchen_Section_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170042DD RID: 17117
		' (get) Token: 0x0600ACED RID: 44269 RVA: 0x0005081A File Offset: 0x0004EA1A
		' (set) Token: 0x0600ACEE RID: 44270 RVA: 0x00050824 File Offset: 0x0004EA24
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170042DE RID: 17118
		' (get) Token: 0x0600ACEF RID: 44271 RVA: 0x0005082D File Offset: 0x0004EA2D
		' (set) Token: 0x0600ACF0 RID: 44272 RVA: 0x00050837 File Offset: 0x0004EA37
		Friend Overridable Property Label3 As Label

		' Token: 0x170042DF RID: 17119
		' (get) Token: 0x0600ACF1 RID: 44273 RVA: 0x00050840 File Offset: 0x0004EA40
		' (set) Token: 0x0600ACF2 RID: 44274 RVA: 0x00739B80 File Offset: 0x00737D80
		Private _txtKitchenName As TextBox
		Friend Overridable Property txtKitchenName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtKitchenName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtKitchenName_KeyDown
				Dim textBox As TextBox = Me._txtKitchenName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtKitchenName = value
				textBox = Me._txtKitchenName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042E0 RID: 17120
		' (get) Token: 0x0600ACF3 RID: 44275 RVA: 0x0005084A File Offset: 0x0004EA4A
		' (set) Token: 0x0600ACF4 RID: 44276 RVA: 0x00050854 File Offset: 0x0004EA54
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170042E1 RID: 17121
		' (get) Token: 0x0600ACF5 RID: 44277 RVA: 0x0005085D File Offset: 0x0004EA5D
		' (set) Token: 0x0600ACF6 RID: 44278 RVA: 0x00050867 File Offset: 0x0004EA67
		Friend Overridable Property Label1 As Label

		' Token: 0x170042E2 RID: 17122
		' (get) Token: 0x0600ACF7 RID: 44279 RVA: 0x00050870 File Offset: 0x0004EA70
		' (set) Token: 0x0600ACF8 RID: 44280 RVA: 0x0005087A File Offset: 0x0004EA7A
		Friend Overridable Property txtKitchen As TextBox

		' Token: 0x170042E3 RID: 17123
		' (get) Token: 0x0600ACF9 RID: 44281 RVA: 0x00050883 File Offset: 0x0004EA83
		' (set) Token: 0x0600ACFA RID: 44282 RVA: 0x0005088D File Offset: 0x0004EA8D
		Friend Overridable Property lblUser As Label

		' Token: 0x170042E4 RID: 17124
		' (get) Token: 0x0600ACFB RID: 44283 RVA: 0x00050896 File Offset: 0x0004EA96
		' (set) Token: 0x0600ACFC RID: 44284 RVA: 0x00739BC4 File Offset: 0x00737DC4
		Private _cmbPrinter As ComboBox
		Friend Overridable Property cmbPrinter As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPrinter
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPrinter_KeyDown
				Dim comboBox As ComboBox = Me._cmbPrinter
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbPrinter = value
				comboBox = Me._cmbPrinter
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042E5 RID: 17125
		' (get) Token: 0x0600ACFD RID: 44285 RVA: 0x000508A0 File Offset: 0x0004EAA0
		' (set) Token: 0x0600ACFE RID: 44286 RVA: 0x000508AA File Offset: 0x0004EAAA
		Friend Overridable Property Label2 As Label

		' Token: 0x170042E6 RID: 17126
		' (get) Token: 0x0600ACFF RID: 44287 RVA: 0x000508B3 File Offset: 0x0004EAB3
		' (set) Token: 0x0600AD00 RID: 44288 RVA: 0x000508BD File Offset: 0x0004EABD
		Friend Overridable Property Label4 As Label

		' Token: 0x170042E7 RID: 17127
		' (get) Token: 0x0600AD01 RID: 44289 RVA: 0x000508C6 File Offset: 0x0004EAC6
		' (set) Token: 0x0600AD02 RID: 44290 RVA: 0x000508D0 File Offset: 0x0004EAD0
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x170042E8 RID: 17128
		' (get) Token: 0x0600AD03 RID: 44291 RVA: 0x000508D9 File Offset: 0x0004EAD9
		' (set) Token: 0x0600AD04 RID: 44292 RVA: 0x00739C08 File Offset: 0x00737E08
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

		' Token: 0x170042E9 RID: 17129
		' (get) Token: 0x0600AD05 RID: 44293 RVA: 0x000508E3 File Offset: 0x0004EAE3
		' (set) Token: 0x0600AD06 RID: 44294 RVA: 0x000508ED File Offset: 0x0004EAED
		Friend Overridable Property Label5 As Label

		' Token: 0x170042EA RID: 17130
		' (get) Token: 0x0600AD07 RID: 44295 RVA: 0x000508F6 File Offset: 0x0004EAF6
		' (set) Token: 0x0600AD08 RID: 44296 RVA: 0x00050900 File Offset: 0x0004EB00
		Friend Overridable Property lblSet As Label

		' Token: 0x170042EB RID: 17131
		' (get) Token: 0x0600AD09 RID: 44297 RVA: 0x00050909 File Offset: 0x0004EB09
		' (set) Token: 0x0600AD0A RID: 44298 RVA: 0x00050913 File Offset: 0x0004EB13
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170042EC RID: 17132
		' (get) Token: 0x0600AD0B RID: 44299 RVA: 0x0005091C File Offset: 0x0004EB1C
		' (set) Token: 0x0600AD0C RID: 44300 RVA: 0x00739C68 File Offset: 0x00737E68
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

		' Token: 0x170042ED RID: 17133
		' (get) Token: 0x0600AD0D RID: 44301 RVA: 0x00050926 File Offset: 0x0004EB26
		' (set) Token: 0x0600AD0E RID: 44302 RVA: 0x00739CAC File Offset: 0x00737EAC
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

		' Token: 0x170042EE RID: 17134
		' (get) Token: 0x0600AD0F RID: 44303 RVA: 0x00050930 File Offset: 0x0004EB30
		' (set) Token: 0x0600AD10 RID: 44304 RVA: 0x00739CF0 File Offset: 0x00737EF0
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

		' Token: 0x170042EF RID: 17135
		' (get) Token: 0x0600AD11 RID: 44305 RVA: 0x0005093A File Offset: 0x0004EB3A
		' (set) Token: 0x0600AD12 RID: 44306 RVA: 0x00739D34 File Offset: 0x00737F34
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

		' Token: 0x170042F0 RID: 17136
		' (get) Token: 0x0600AD13 RID: 44307 RVA: 0x00050944 File Offset: 0x0004EB44
		' (set) Token: 0x0600AD14 RID: 44308 RVA: 0x0005094E File Offset: 0x0004EB4E
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170042F1 RID: 17137
		' (get) Token: 0x0600AD15 RID: 44309 RVA: 0x00050957 File Offset: 0x0004EB57
		' (set) Token: 0x0600AD16 RID: 44310 RVA: 0x00050961 File Offset: 0x0004EB61
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170042F2 RID: 17138
		' (get) Token: 0x0600AD17 RID: 44311 RVA: 0x0005096A File Offset: 0x0004EB6A
		' (set) Token: 0x0600AD18 RID: 44312 RVA: 0x00050974 File Offset: 0x0004EB74
		Friend Overridable Property IsEnabled As DataGridViewTextBoxColumn

		' Token: 0x170042F3 RID: 17139
		' (get) Token: 0x0600AD19 RID: 44313 RVA: 0x0005097D File Offset: 0x0004EB7D
		' (set) Token: 0x0600AD1A RID: 44314 RVA: 0x00050987 File Offset: 0x0004EB87
		Friend Overridable Property Label6 As Label

		' Token: 0x0600AD1B RID: 44315 RVA: 0x00739D78 File Offset: 0x00737F78
		Public Sub Reset()
			Me.cmbPrinter.SelectedIndex = -1
			Me.chkIsEnabled.Checked = True
			Me.txtKitchenName.Text = ""
			Me.txtKitchenName.Focus()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
		End Sub

		' Token: 0x0600AD1C RID: 44316 RVA: 0x00739DE4 File Offset: 0x00737FE4
		Private Sub PopulateInstalledPrintersCombo()
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbPrinter.Items.Clear()
				Dim num As Integer = PrinterSettings.InstalledPrinters.Count - 1
				For i As Integer = 0 To num
					Dim text As String = PrinterSettings.InstalledPrinters(i)
					Me.cmbPrinter.Items.Add(text)
				Next
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AD1D RID: 44317 RVA: 0x00739E74 File Offset: 0x00738074
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select Kitchen.KitchenName from Kitchen,Product where Kitchen.KitchenName=Product.Kitchen and Kitchen.KitchenName=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Product Entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "delete from Kitchen where KitchenName=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Dim text3 As String = "deleted the order section '" + Me.txtKitchenName.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AD1E RID: 44318 RVA: 0x0073A080 File Offset: 0x00738280
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(KitchenName), RTRIM(Printer),RTRIM(IsEnabled) from Kitchen order by KitchenName", ModCommonClasses.con)
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

		' Token: 0x0600AD1F RID: 44319 RVA: 0x0073A174 File Offset: 0x00738374
		Private Sub frmKitchen_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.PopulateInstalledPrintersCombo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600AD20 RID: 44320 RVA: 0x0073A204 File Offset: 0x00738404
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

		' Token: 0x0600AD21 RID: 44321 RVA: 0x0073A4A4 File Offset: 0x007386A4
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

		' Token: 0x0600AD22 RID: 44322 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600AD23 RID: 44323 RVA: 0x0073A558 File Offset: 0x00738758
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtKitchenName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtKitchen.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbPrinter.Text = dataGridViewRow.Cells(1).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkIsEnabled.Checked = True
					Else
						Me.chkIsEnabled.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600AD24 RID: 44324 RVA: 0x0073A6AC File Offset: 0x007388AC
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlText As Brush = SystemBrushes.ControlText
			e.Graphics.DrawString(text, Me.Font, controlText, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600AD25 RID: 44325 RVA: 0x0073A794 File Offset: 0x00738994
		Private Sub frmKitchen_Section_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "Product", False) = 0
			If flag Then
				MyProject.Forms.frmProduct.FillKitchen()
			End If
		End Sub

		' Token: 0x0600AD26 RID: 44326 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtKitchenName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600AD27 RID: 44327 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPrinter_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600AD28 RID: 44328 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmKitchen_Section_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600AD29 RID: 44329 RVA: 0x00050990 File Offset: 0x0004EB90
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600AD2A RID: 44330 RVA: 0x0073A7D4 File Offset: 0x007389D4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtKitchenName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter order section name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtKitchenName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbPrinter.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select KitchenName from Kitchen where KitchenName=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Order Section Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtKitchenName.Text = ""
							Me.txtKitchenName.Focus()
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Dim checked As Boolean = Me.chkIsEnabled.Checked
							If checked Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "insert into Kitchen(KitchenName,Printer,IsEnabled) VALUES (@d1,@d2,@d3)"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinter.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Dim text3 As String = "added the new order section '" + Me.txtKitchenName.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text3)
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
							Me.Getdata()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600AD2B RID: 44331 RVA: 0x0073AA9C File Offset: 0x00738C9C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtKitchenName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter order section name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtKitchenName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbPrinter.Focus()
				Else
					Try
						Dim checked As Boolean = Me.chkIsEnabled.Checked
						If checked Then
							Me.st2 = "Yes"
						Else
							Me.st2 = "No"
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update Product set Kitchen=@d1 where Kitchen=@d2"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtKitchen.Text)
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Update Kitchen set KitchenName=@d1,Printer=@d2,IsEnabled=@d3 where KitchenName=@d4"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtKitchenName.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinter.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtKitchen.Text)
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						Dim text3 As String = "Updated the order section '" + Me.txtKitchenName.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						Me.Getdata()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600AD2C RID: 44332 RVA: 0x0073AD50 File Offset: 0x00738F50
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

		' Token: 0x04004872 RID: 18546
		Private st2 As String
	End Class
End Namespace
