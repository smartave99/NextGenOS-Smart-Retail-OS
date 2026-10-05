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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000135 RID: 309
	<DesignerGenerated()>
	Public Partial Class frmMRP_Purchase_Update
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060034E4 RID: 13540 RVA: 0x00209A2C File Offset: 0x00207C2C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMRP_Purchase_Update_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmMRPShow_KeyDown
			AddHandler MyBase.FormClosed, AddressOf Me.frmMRPShow_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001470 RID: 5232
		' (get) Token: 0x060034E7 RID: 13543 RVA: 0x00020764 File Offset: 0x0001E964
		' (set) Token: 0x060034E8 RID: 13544 RVA: 0x0002076E File Offset: 0x0001E96E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001471 RID: 5233
		' (get) Token: 0x060034E9 RID: 13545 RVA: 0x00020777 File Offset: 0x0001E977
		' (set) Token: 0x060034EA RID: 13546 RVA: 0x0020AFB0 File Offset: 0x002091B0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001472 RID: 5234
		' (get) Token: 0x060034EB RID: 13547 RVA: 0x00020781 File Offset: 0x0001E981
		' (set) Token: 0x060034EC RID: 13548 RVA: 0x0002078B File Offset: 0x0001E98B
		Friend Overridable Property Label1 As Label

		' Token: 0x17001473 RID: 5235
		' (get) Token: 0x060034ED RID: 13549 RVA: 0x00020794 File Offset: 0x0001E994
		' (set) Token: 0x060034EE RID: 13550 RVA: 0x0002079E File Offset: 0x0001E99E
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17001474 RID: 5236
		' (get) Token: 0x060034EF RID: 13551 RVA: 0x000207A7 File Offset: 0x0001E9A7
		' (set) Token: 0x060034F0 RID: 13552 RVA: 0x000207B1 File Offset: 0x0001E9B1
		Friend Overridable Property Label5 As Label

		' Token: 0x17001475 RID: 5237
		' (get) Token: 0x060034F1 RID: 13553 RVA: 0x000207BA File Offset: 0x0001E9BA
		' (set) Token: 0x060034F2 RID: 13554 RVA: 0x000207C4 File Offset: 0x0001E9C4
		Friend Overridable Property Label4 As Label

		' Token: 0x17001476 RID: 5238
		' (get) Token: 0x060034F3 RID: 13555 RVA: 0x000207CD File Offset: 0x0001E9CD
		' (set) Token: 0x060034F4 RID: 13556 RVA: 0x000207D7 File Offset: 0x0001E9D7
		Friend Overridable Property Label2 As Label

		' Token: 0x17001477 RID: 5239
		' (get) Token: 0x060034F5 RID: 13557 RVA: 0x000207E0 File Offset: 0x0001E9E0
		' (set) Token: 0x060034F6 RID: 13558 RVA: 0x000207EA File Offset: 0x0001E9EA
		Friend Overridable Property Label3 As Label

		' Token: 0x17001478 RID: 5240
		' (get) Token: 0x060034F7 RID: 13559 RVA: 0x000207F3 File Offset: 0x0001E9F3
		' (set) Token: 0x060034F8 RID: 13560 RVA: 0x000207FD File Offset: 0x0001E9FD
		Friend Overridable Property lblRateType As Label

		' Token: 0x17001479 RID: 5241
		' (get) Token: 0x060034F9 RID: 13561 RVA: 0x00020806 File Offset: 0x0001EA06
		' (set) Token: 0x060034FA RID: 13562 RVA: 0x00020810 File Offset: 0x0001EA10
		Friend Overridable Property Label6 As Label

		' Token: 0x1700147A RID: 5242
		' (get) Token: 0x060034FB RID: 13563 RVA: 0x00020819 File Offset: 0x0001EA19
		' (set) Token: 0x060034FC RID: 13564 RVA: 0x00020823 File Offset: 0x0001EA23
		Friend Overridable Property Label8 As Label

		' Token: 0x1700147B RID: 5243
		' (get) Token: 0x060034FD RID: 13565 RVA: 0x0002082C File Offset: 0x0001EA2C
		' (set) Token: 0x060034FE RID: 13566 RVA: 0x0020B02C File Offset: 0x0020922C
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

		' Token: 0x1700147C RID: 5244
		' (get) Token: 0x060034FF RID: 13567 RVA: 0x00020836 File Offset: 0x0001EA36
		' (set) Token: 0x06003500 RID: 13568 RVA: 0x0020B070 File Offset: 0x00209270
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

		' Token: 0x1700147D RID: 5245
		' (get) Token: 0x06003501 RID: 13569 RVA: 0x00020840 File Offset: 0x0001EA40
		' (set) Token: 0x06003502 RID: 13570 RVA: 0x0020B0B4 File Offset: 0x002092B4
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

		' Token: 0x1700147E RID: 5246
		' (get) Token: 0x06003503 RID: 13571 RVA: 0x0002084A File Offset: 0x0001EA4A
		' (set) Token: 0x06003504 RID: 13572 RVA: 0x0020B0F8 File Offset: 0x002092F8
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

		' Token: 0x1700147F RID: 5247
		' (get) Token: 0x06003505 RID: 13573 RVA: 0x00020854 File Offset: 0x0001EA54
		' (set) Token: 0x06003506 RID: 13574 RVA: 0x0002085E File Offset: 0x0001EA5E
		Friend Overridable Property lblPOSPanel As Label

		' Token: 0x17001480 RID: 5248
		' (get) Token: 0x06003507 RID: 13575 RVA: 0x00020867 File Offset: 0x0001EA67
		' (set) Token: 0x06003508 RID: 13576 RVA: 0x0020B13C File Offset: 0x0020933C
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001481 RID: 5249
		' (get) Token: 0x06003509 RID: 13577 RVA: 0x00020871 File Offset: 0x0001EA71
		' (set) Token: 0x0600350A RID: 13578 RVA: 0x0002087B File Offset: 0x0001EA7B
		Friend Overridable Property SP_ID As DataGridViewTextBoxColumn

		' Token: 0x17001482 RID: 5250
		' (get) Token: 0x0600350B RID: 13579 RVA: 0x00020884 File Offset: 0x0001EA84
		' (set) Token: 0x0600350C RID: 13580 RVA: 0x0002088E File Offset: 0x0001EA8E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001483 RID: 5251
		' (get) Token: 0x0600350D RID: 13581 RVA: 0x00020897 File Offset: 0x0001EA97
		' (set) Token: 0x0600350E RID: 13582 RVA: 0x000208A1 File Offset: 0x0001EAA1
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001484 RID: 5252
		' (get) Token: 0x0600350F RID: 13583 RVA: 0x000208AA File Offset: 0x0001EAAA
		' (set) Token: 0x06003510 RID: 13584 RVA: 0x000208B4 File Offset: 0x0001EAB4
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17001485 RID: 5253
		' (get) Token: 0x06003511 RID: 13585 RVA: 0x000208BD File Offset: 0x0001EABD
		' (set) Token: 0x06003512 RID: 13586 RVA: 0x000208C7 File Offset: 0x0001EAC7
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001486 RID: 5254
		' (get) Token: 0x06003513 RID: 13587 RVA: 0x000208D0 File Offset: 0x0001EAD0
		' (set) Token: 0x06003514 RID: 13588 RVA: 0x000208DA File Offset: 0x0001EADA
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001487 RID: 5255
		' (get) Token: 0x06003515 RID: 13589 RVA: 0x000208E3 File Offset: 0x0001EAE3
		' (set) Token: 0x06003516 RID: 13590 RVA: 0x000208ED File Offset: 0x0001EAED
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001488 RID: 5256
		' (get) Token: 0x06003517 RID: 13591 RVA: 0x000208F6 File Offset: 0x0001EAF6
		' (set) Token: 0x06003518 RID: 13592 RVA: 0x00020900 File Offset: 0x0001EB00
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17001489 RID: 5257
		' (get) Token: 0x06003519 RID: 13593 RVA: 0x00020909 File Offset: 0x0001EB09
		' (set) Token: 0x0600351A RID: 13594 RVA: 0x00020913 File Offset: 0x0001EB13
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700148A RID: 5258
		' (get) Token: 0x0600351B RID: 13595 RVA: 0x0002091C File Offset: 0x0001EB1C
		' (set) Token: 0x0600351C RID: 13596 RVA: 0x00020926 File Offset: 0x0001EB26
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700148B RID: 5259
		' (get) Token: 0x0600351D RID: 13597 RVA: 0x0002092F File Offset: 0x0001EB2F
		' (set) Token: 0x0600351E RID: 13598 RVA: 0x00020939 File Offset: 0x0001EB39
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700148C RID: 5260
		' (get) Token: 0x0600351F RID: 13599 RVA: 0x00020942 File Offset: 0x0001EB42
		' (set) Token: 0x06003520 RID: 13600 RVA: 0x0002094C File Offset: 0x0001EB4C
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700148D RID: 5261
		' (get) Token: 0x06003521 RID: 13601 RVA: 0x00020955 File Offset: 0x0001EB55
		' (set) Token: 0x06003522 RID: 13602 RVA: 0x0002095F File Offset: 0x0001EB5F
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700148E RID: 5262
		' (get) Token: 0x06003523 RID: 13603 RVA: 0x00020968 File Offset: 0x0001EB68
		' (set) Token: 0x06003524 RID: 13604 RVA: 0x00020972 File Offset: 0x0001EB72
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700148F RID: 5263
		' (get) Token: 0x06003525 RID: 13605 RVA: 0x0002097B File Offset: 0x0001EB7B
		' (set) Token: 0x06003526 RID: 13606 RVA: 0x00020985 File Offset: 0x0001EB85
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17001490 RID: 5264
		' (get) Token: 0x06003527 RID: 13607 RVA: 0x0002098E File Offset: 0x0001EB8E
		' (set) Token: 0x06003528 RID: 13608 RVA: 0x00020998 File Offset: 0x0001EB98
		Friend Overridable Property btnUpdate As DataGridViewButtonColumn

		' Token: 0x06003529 RID: 13609 RVA: 0x0020B180 File Offset: 0x00209380
		Private Sub frmMRP_Purchase_Update_Load(sender As Object, e As EventArgs)
			Me.getdata()
			Me.dgw.Focus()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600352A RID: 13610 RVA: 0x0020B214 File Offset: 0x00209414
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

		' Token: 0x0600352B RID: 13611 RVA: 0x0020B38C File Offset: 0x0020958C
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

		' Token: 0x0600352C RID: 13612 RVA: 0x0020B458 File Offset: 0x00209658
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

		' Token: 0x0600352D RID: 13613 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600352E RID: 13614 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600352F RID: 13615 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06003530 RID: 13616 RVA: 0x0020B524 File Offset: 0x00209724
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT DISTINCT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " Stock_Product.Sp_id, (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info), RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2) FROM Stock_Product where Stock_Product.Barcode=@d2 order by Stock_Product.MRP DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003531 RID: 13617 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
		End Sub

		' Token: 0x06003532 RID: 13618 RVA: 0x0020B710 File Offset: 0x00209910
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

		' Token: 0x06003533 RID: 13619 RVA: 0x002099A0 File Offset: 0x00207BA0
		Private Sub frmMRPShow_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = (e.KeyCode = Keys.F4) And (e.Modifiers = Keys.Alt)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06003534 RID: 13620 RVA: 0x0020B7F8 File Offset: 0x002099F8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.NumericUpDown1.Value = Conversions.ToDecimal("5")
			Me.getdata()
			Me.dgw.Focus()
		End Sub

		' Token: 0x06003535 RID: 13621 RVA: 0x000209A1 File Offset: 0x0001EBA1
		Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x06003536 RID: 13622 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06003537 RID: 13623 RVA: 0x000209AB File Offset: 0x0001EBAB
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x06003538 RID: 13624 RVA: 0x000209CB File Offset: 0x0001EBCB
		Private Sub frmMRPShow_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.lblPOSPanel.Text = ""
		End Sub

		' Token: 0x06003539 RID: 13625 RVA: 0x0020B850 File Offset: 0x00209A50
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.getdata()
			End If
		End Sub

		' Token: 0x0600353A RID: 13626 RVA: 0x0020B878 File Offset: 0x00209A78
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.dgw.Columns("btnUpdate").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(e.RowIndex)
				Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells("SP_ID").Value.ToString(), "", False) <> 0
				If flag2 Then
					Dim text As String = Conversions.ToString(dataGridViewRow.Cells("SP_ID").Value)
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells("Column1").Value.ToString(), "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Operators.CompareString(dataGridViewRow.Cells("Column5").Value.ToString(), "", False) = 0
						If flag4 Then
							MessageBox.Show("Please enter Retail Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag5 As Boolean = Operators.CompareString(dataGridViewRow.Cells("Column6").Value.ToString(), "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter WHolesale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "update Stock_Product set MRP=@d2,RPrice=@d3, WPrice=@d4 where SP_ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow.Cells("Column1").Value.ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells("Column5").Value.ToString()))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow.Cells("Column6").Value.ToString()))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Data Updated Sucessfully!")
								Me.getdata()
							End If
						End If
					End If
				Else
					MessageBox.Show("Id not found!")
				End If
			End If
		End Sub
	End Class
End Namespace
