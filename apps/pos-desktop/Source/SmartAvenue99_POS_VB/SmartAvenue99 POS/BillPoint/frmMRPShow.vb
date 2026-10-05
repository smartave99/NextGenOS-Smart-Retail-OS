Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002A9 RID: 681
	<DesignerGenerated()>
	Public Partial Class frmMRPShow
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AE04 RID: 44548 RVA: 0x00742F1C File Offset: 0x0074111C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMRPShow_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmMRPShow_KeyDown
			AddHandler MyBase.FormClosed, AddressOf Me.frmMRPShow_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700434A RID: 17226
		' (get) Token: 0x0600AE07 RID: 44551 RVA: 0x00050F38 File Offset: 0x0004F138
		' (set) Token: 0x0600AE08 RID: 44552 RVA: 0x00050F42 File Offset: 0x0004F142
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700434B RID: 17227
		' (get) Token: 0x0600AE09 RID: 44553 RVA: 0x00050F4B File Offset: 0x0004F14B
		' (set) Token: 0x0600AE0A RID: 44554 RVA: 0x007444D0 File Offset: 0x007426D0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700434C RID: 17228
		' (get) Token: 0x0600AE0B RID: 44555 RVA: 0x00050F55 File Offset: 0x0004F155
		' (set) Token: 0x0600AE0C RID: 44556 RVA: 0x00050F5F File Offset: 0x0004F15F
		Friend Overridable Property Label1 As Label

		' Token: 0x1700434D RID: 17229
		' (get) Token: 0x0600AE0D RID: 44557 RVA: 0x00050F68 File Offset: 0x0004F168
		' (set) Token: 0x0600AE0E RID: 44558 RVA: 0x00050F72 File Offset: 0x0004F172
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x1700434E RID: 17230
		' (get) Token: 0x0600AE0F RID: 44559 RVA: 0x00050F7B File Offset: 0x0004F17B
		' (set) Token: 0x0600AE10 RID: 44560 RVA: 0x00050F85 File Offset: 0x0004F185
		Friend Overridable Property Label5 As Label

		' Token: 0x1700434F RID: 17231
		' (get) Token: 0x0600AE11 RID: 44561 RVA: 0x00050F8E File Offset: 0x0004F18E
		' (set) Token: 0x0600AE12 RID: 44562 RVA: 0x00050F98 File Offset: 0x0004F198
		Friend Overridable Property Label4 As Label

		' Token: 0x17004350 RID: 17232
		' (get) Token: 0x0600AE13 RID: 44563 RVA: 0x00050FA1 File Offset: 0x0004F1A1
		' (set) Token: 0x0600AE14 RID: 44564 RVA: 0x00050FAB File Offset: 0x0004F1AB
		Friend Overridable Property Label2 As Label

		' Token: 0x17004351 RID: 17233
		' (get) Token: 0x0600AE15 RID: 44565 RVA: 0x00050FB4 File Offset: 0x0004F1B4
		' (set) Token: 0x0600AE16 RID: 44566 RVA: 0x00050FBE File Offset: 0x0004F1BE
		Friend Overridable Property Label3 As Label

		' Token: 0x17004352 RID: 17234
		' (get) Token: 0x0600AE17 RID: 44567 RVA: 0x00050FC7 File Offset: 0x0004F1C7
		' (set) Token: 0x0600AE18 RID: 44568 RVA: 0x00050FD1 File Offset: 0x0004F1D1
		Friend Overridable Property lblRateType As Label

		' Token: 0x17004353 RID: 17235
		' (get) Token: 0x0600AE19 RID: 44569 RVA: 0x00050FDA File Offset: 0x0004F1DA
		' (set) Token: 0x0600AE1A RID: 44570 RVA: 0x00050FE4 File Offset: 0x0004F1E4
		Friend Overridable Property Label6 As Label

		' Token: 0x17004354 RID: 17236
		' (get) Token: 0x0600AE1B RID: 44571 RVA: 0x00050FED File Offset: 0x0004F1ED
		' (set) Token: 0x0600AE1C RID: 44572 RVA: 0x00050FF7 File Offset: 0x0004F1F7
		Friend Overridable Property Label8 As Label

		' Token: 0x17004355 RID: 17237
		' (get) Token: 0x0600AE1D RID: 44573 RVA: 0x00051000 File Offset: 0x0004F200
		' (set) Token: 0x0600AE1E RID: 44574 RVA: 0x0074454C File Offset: 0x0074274C
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004356 RID: 17238
		' (get) Token: 0x0600AE1F RID: 44575 RVA: 0x0005100A File Offset: 0x0004F20A
		' (set) Token: 0x0600AE20 RID: 44576 RVA: 0x00744590 File Offset: 0x00742790
		Private _NumericUpDown1 As NumericUpDown
		Friend Overridable Property NumericUpDown1 As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._NumericUpDown1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.NumericUpDown1_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._NumericUpDown1 = value
				numericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004357 RID: 17239
		' (get) Token: 0x0600AE21 RID: 44577 RVA: 0x00051014 File Offset: 0x0004F214
		' (set) Token: 0x0600AE22 RID: 44578 RVA: 0x007445D4 File Offset: 0x007427D4
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004358 RID: 17240
		' (get) Token: 0x0600AE23 RID: 44579 RVA: 0x0005101E File Offset: 0x0004F21E
		' (set) Token: 0x0600AE24 RID: 44580 RVA: 0x00744618 File Offset: 0x00742818
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

		' Token: 0x17004359 RID: 17241
		' (get) Token: 0x0600AE25 RID: 44581 RVA: 0x00051028 File Offset: 0x0004F228
		' (set) Token: 0x0600AE26 RID: 44582 RVA: 0x00051032 File Offset: 0x0004F232
		Friend Overridable Property lblBarcode As Label

		' Token: 0x1700435A RID: 17242
		' (get) Token: 0x0600AE27 RID: 44583 RVA: 0x0005103B File Offset: 0x0004F23B
		' (set) Token: 0x0600AE28 RID: 44584 RVA: 0x00051045 File Offset: 0x0004F245
		Friend Overridable Property lblPOSPanel As Label

		' Token: 0x1700435B RID: 17243
		' (get) Token: 0x0600AE29 RID: 44585 RVA: 0x0005104E File Offset: 0x0004F24E
		' (set) Token: 0x0600AE2A RID: 44586 RVA: 0x00051058 File Offset: 0x0004F258
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700435C RID: 17244
		' (get) Token: 0x0600AE2B RID: 44587 RVA: 0x00051061 File Offset: 0x0004F261
		' (set) Token: 0x0600AE2C RID: 44588 RVA: 0x0005106B File Offset: 0x0004F26B
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700435D RID: 17245
		' (get) Token: 0x0600AE2D RID: 44589 RVA: 0x00051074 File Offset: 0x0004F274
		' (set) Token: 0x0600AE2E RID: 44590 RVA: 0x0005107E File Offset: 0x0004F27E
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700435E RID: 17246
		' (get) Token: 0x0600AE2F RID: 44591 RVA: 0x00051087 File Offset: 0x0004F287
		' (set) Token: 0x0600AE30 RID: 44592 RVA: 0x00051091 File Offset: 0x0004F291
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700435F RID: 17247
		' (get) Token: 0x0600AE31 RID: 44593 RVA: 0x0005109A File Offset: 0x0004F29A
		' (set) Token: 0x0600AE32 RID: 44594 RVA: 0x000510A4 File Offset: 0x0004F2A4
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004360 RID: 17248
		' (get) Token: 0x0600AE33 RID: 44595 RVA: 0x000510AD File Offset: 0x0004F2AD
		' (set) Token: 0x0600AE34 RID: 44596 RVA: 0x000510B7 File Offset: 0x0004F2B7
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004361 RID: 17249
		' (get) Token: 0x0600AE35 RID: 44597 RVA: 0x000510C0 File Offset: 0x0004F2C0
		' (set) Token: 0x0600AE36 RID: 44598 RVA: 0x000510CA File Offset: 0x0004F2CA
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004362 RID: 17250
		' (get) Token: 0x0600AE37 RID: 44599 RVA: 0x000510D3 File Offset: 0x0004F2D3
		' (set) Token: 0x0600AE38 RID: 44600 RVA: 0x000510DD File Offset: 0x0004F2DD
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004363 RID: 17251
		' (get) Token: 0x0600AE39 RID: 44601 RVA: 0x000510E6 File Offset: 0x0004F2E6
		' (set) Token: 0x0600AE3A RID: 44602 RVA: 0x000510F0 File Offset: 0x0004F2F0
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004364 RID: 17252
		' (get) Token: 0x0600AE3B RID: 44603 RVA: 0x000510F9 File Offset: 0x0004F2F9
		' (set) Token: 0x0600AE3C RID: 44604 RVA: 0x00051103 File Offset: 0x0004F303
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004365 RID: 17253
		' (get) Token: 0x0600AE3D RID: 44605 RVA: 0x0005110C File Offset: 0x0004F30C
		' (set) Token: 0x0600AE3E RID: 44606 RVA: 0x00051116 File Offset: 0x0004F316
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004366 RID: 17254
		' (get) Token: 0x0600AE3F RID: 44607 RVA: 0x0005111F File Offset: 0x0004F31F
		' (set) Token: 0x0600AE40 RID: 44608 RVA: 0x00051129 File Offset: 0x0004F329
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004367 RID: 17255
		' (get) Token: 0x0600AE41 RID: 44609 RVA: 0x00051132 File Offset: 0x0004F332
		' (set) Token: 0x0600AE42 RID: 44610 RVA: 0x0005113C File Offset: 0x0004F33C
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004368 RID: 17256
		' (get) Token: 0x0600AE43 RID: 44611 RVA: 0x00051145 File Offset: 0x0004F345
		' (set) Token: 0x0600AE44 RID: 44612 RVA: 0x0005114F File Offset: 0x0004F34F
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004369 RID: 17257
		' (get) Token: 0x0600AE45 RID: 44613 RVA: 0x00051158 File Offset: 0x0004F358
		' (set) Token: 0x0600AE46 RID: 44614 RVA: 0x00051162 File Offset: 0x0004F362
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x0600AE47 RID: 44615 RVA: 0x0074465C File Offset: 0x0074285C
		Private Sub frmMRPShow_Load(sender As Object, e As EventArgs)
			Me.getdata()
			Me.dgw.Focus()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600AE48 RID: 44616 RVA: 0x007446F0 File Offset: 0x007428F0
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) as default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Me.UpdateDataGridViewHeaders(Me.dgw, GlobalVariables.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600AE49 RID: 44617 RVA: 0x00744870 File Offset: 0x00742A70
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
				End If
			End If
			Dim flag3 As Boolean = TypeOf ctrl Is TabControl
			If flag3 Then
				Dim tabControl As TabControl = CType(ctrl, TabControl)
				Try
					For Each obj As Object In tabControl.TabPages
						Dim tabPage As TabPage = CType(obj, TabPage)
						Dim text2 As String = tabPage.Text
						Dim flag4 As Boolean = translations.ContainsKey(text2)
						If flag4 Then
							tabPage.Text = translations(text2)
						End If
						Try
							For Each obj2 As Object In tabPage.Controls
								Dim control As Control = CType(obj2, Control)
								Me.UpdateAllControls(control, translations)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Dim flag5 As Boolean = TypeOf ctrl Is MenuStrip
			If flag5 Then
				Dim menuStrip As MenuStrip = CType(ctrl, MenuStrip)
				Try
					For Each obj3 As Object In menuStrip.Items
						Dim toolStripMenuItem As ToolStripMenuItem = CType(obj3, ToolStripMenuItem)
						Me.UpdateMenuItems(toolStripMenuItem, translations)
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj4 As Object In ctrl.Controls
					Dim control2 As Control = CType(obj4, Control)
					Me.UpdateAllControls(control2, translations)
				Next
			Finally
				Dim enumerator4 As IEnumerator
				If TypeOf enumerator4 Is IDisposable Then
					TryCast(enumerator4, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600AE4A RID: 44618 RVA: 0x00208B7C File Offset: 0x00206D7C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView, translations As Dictionary(Of String, String))
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600AE4B RID: 44619 RVA: 0x00744AA8 File Offset: 0x00742CA8
		Private Sub UpdateMenuItems(menuItem As ToolStripMenuItem, translations As Dictionary(Of String, String))
			Dim text As String = menuItem.Text
			Dim flag As Boolean = translations.ContainsKey(text)
			If flag Then
				menuItem.Text = translations(text)
			End If
			Try
				For Each toolStripMenuItem As ToolStripMenuItem In menuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
					Me.UpdateMenuItems(toolStripMenuItem, translations)
				Next
			Finally
				Dim enumerator As IEnumerator(Of ToolStripMenuItem)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600AE4C RID: 44620 RVA: 0x00744B28 File Offset: 0x00742D28
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info), RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 order by Stock_Product.SP_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AE4D RID: 44621 RVA: 0x00744D40 File Offset: 0x00742F40
		Private Sub getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Color like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Size like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Info like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Batch like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 4
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Mfgdate like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 5
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Expdate like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 6
										If flag7 Then
											ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.IMEI1 like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 7
											If flag8 Then
												ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.IMEI2 like N'", Me.TextBox1.Text, "%' order by Stock_Product.SP_ID DESC" }), ModCommonClasses.con)
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AE4E RID: 44622 RVA: 0x00745274 File Offset: 0x00743474
		Public Sub Retrievedata()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim flag As Boolean = Operators.CompareString(Me.lblRateType.Text, "Retail", False) = 0
				If flag Then
					MyProject.Forms.frmPOS.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)), 2), "0.00")
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblRateType.Text, "Wholesale", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOS.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)), 2), "0.00")
					End If
				End If
				MyProject.Forms.frmPOS.txtPurchaseRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)), 2), "0.00")
				MyProject.Forms.frmPOS.lblMRP.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), 2), "0.00")
				MyProject.Forms.frmPOS.txtBatch1.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOS.txtMfg1.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOS.txtExp1.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOS.txtSize1.Text = dataGridViewRow.Cells(7).Value.ToString()
				MyProject.Forms.frmPOS.txtColour1.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOS.txtPurcTaxPrice.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)), 2), "0.00")
				MyProject.Forms.frmPOS.txtIMEI1.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOS.txtIMEI2.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOS.Calc()
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AE4F RID: 44623 RVA: 0x007455A4 File Offset: 0x007437A4
		Public Sub Retrievedata1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim flag As Boolean = Operators.CompareString(Me.lblRateType.Text, "Retail", False) = 0
				If flag Then
					MyProject.Forms.frmPOSTouch.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)), 2), "0.00")
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblRateType.Text, "Wholesale", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSTouch.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)), 2), "0.00")
					End If
				End If
				MyProject.Forms.frmPOSTouch.txtPurchaseRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)), 2), "0.00")
				MyProject.Forms.frmPOSTouch.lblMRP.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), 2), "0.00")
				MyProject.Forms.frmPOSTouch.txtBatch1.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtMfg1.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtExp1.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtSize1.Text = dataGridViewRow.Cells(7).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtColour1.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtIMEI1.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtIMEI2.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOSTouch.txtStockId.Text = dataGridViewRow.Cells(14).Value.ToString()
				MyProject.Forms.frmPOSTouch.Calc()
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AE50 RID: 44624 RVA: 0x007458BC File Offset: 0x00743ABC
		Public Sub Retrievedata3()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim flag As Boolean = Operators.CompareString(Me.lblRateType.Text, "Retail", False) = 0
				If flag Then
					MyProject.Forms.frmPOSNewTuch.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)), 2), "0.00")
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblRateType.Text, "Wholesale", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch.txtSalesRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)), 2), "0.00")
					End If
				End If
				MyProject.Forms.frmPOSNewTuch.txtPurchaseRate.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)), 2), "0.00")
				MyProject.Forms.frmPOSNewTuch.lblMRP.Text = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), 2), "0.00")
				MyProject.Forms.frmPOSNewTuch.txtBatch1.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtMfg1.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtExp1.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtSize1.Text = dataGridViewRow.Cells(7).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtColour1.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtIMEI1.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtIMEI2.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.txtStockId.Text = dataGridViewRow.Cells(14).Value.ToString()
				MyProject.Forms.frmPOSNewTuch.Calc()
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600AE51 RID: 44625 RVA: 0x00745BD4 File Offset: 0x00743DD4
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "SALE", False) = 0
				If flag2 Then
					Me.Retrievedata()
				End If
				Dim flag3 As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "POINT OF SALE", False) = 0
				If flag3 Then
					Me.Retrievedata1()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "POINTOFSALENEW", False) = 0
				If flag4 Then
					Me.Retrievedata3()
				End If
			End If
		End Sub

		' Token: 0x0600AE52 RID: 44626 RVA: 0x00745C64 File Offset: 0x00743E64
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "SALE", False) = 0
			If flag Then
				Me.Retrievedata()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "POINT OF SALE", False) = 0
			If flag2 Then
				Me.Retrievedata1()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.lblPOSPanel.Text, "POINT OF SALENEW", False) = 0
			If flag3 Then
				Me.Retrievedata1()
			End If
		End Sub

		' Token: 0x0600AE53 RID: 44627 RVA: 0x00745CE4 File Offset: 0x00743EE4
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

		' Token: 0x0600AE54 RID: 44628 RVA: 0x002099A0 File Offset: 0x00207BA0
		Private Sub frmMRPShow_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = (e.KeyCode = Keys.F4) And (e.Modifiers = Keys.Alt)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600AE55 RID: 44629 RVA: 0x00745DCC File Offset: 0x00743FCC
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.NumericUpDown1.Value = Conversions.ToDecimal("5")
			Me.getdata()
			Me.dgw.Focus()
		End Sub

		' Token: 0x0600AE56 RID: 44630 RVA: 0x0005116B File Offset: 0x0004F36B
		Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x0600AE57 RID: 44631 RVA: 0x00051175 File Offset: 0x0004F375
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.getdata1()
		End Sub

		' Token: 0x0600AE58 RID: 44632 RVA: 0x0005117F File Offset: 0x0004F37F
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x0600AE59 RID: 44633 RVA: 0x0005119F File Offset: 0x0004F39F
		Private Sub frmMRPShow_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.lblPOSPanel.Text = ""
		End Sub
	End Class
End Namespace
