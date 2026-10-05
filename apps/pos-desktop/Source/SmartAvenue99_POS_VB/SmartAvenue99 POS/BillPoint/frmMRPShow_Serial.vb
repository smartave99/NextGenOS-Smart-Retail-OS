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
	' Token: 0x02000134 RID: 308
	<DesignerGenerated()>
	Public Partial Class frmMRPShow_Serial
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060034A8 RID: 13480 RVA: 0x002074B8 File Offset: 0x002056B8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMRPShow_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmMRPShow_KeyDown
			AddHandler MyBase.FormClosed, AddressOf Me.frmMRPShow_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700145D RID: 5213
		' (get) Token: 0x060034AB RID: 13483 RVA: 0x000205E0 File Offset: 0x0001E7E0
		' (set) Token: 0x060034AC RID: 13484 RVA: 0x000205EA File Offset: 0x0001E7EA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700145E RID: 5214
		' (get) Token: 0x060034AD RID: 13485 RVA: 0x000205F3 File Offset: 0x0001E7F3
		' (set) Token: 0x060034AE RID: 13486 RVA: 0x002085A4 File Offset: 0x002067A4
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

		' Token: 0x1700145F RID: 5215
		' (get) Token: 0x060034AF RID: 13487 RVA: 0x000205FD File Offset: 0x0001E7FD
		' (set) Token: 0x060034B0 RID: 13488 RVA: 0x00020607 File Offset: 0x0001E807
		Friend Overridable Property Label1 As Label

		' Token: 0x17001460 RID: 5216
		' (get) Token: 0x060034B1 RID: 13489 RVA: 0x00020610 File Offset: 0x0001E810
		' (set) Token: 0x060034B2 RID: 13490 RVA: 0x0002061A File Offset: 0x0001E81A
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17001461 RID: 5217
		' (get) Token: 0x060034B3 RID: 13491 RVA: 0x00020623 File Offset: 0x0001E823
		' (set) Token: 0x060034B4 RID: 13492 RVA: 0x0002062D File Offset: 0x0001E82D
		Friend Overridable Property Label5 As Label

		' Token: 0x17001462 RID: 5218
		' (get) Token: 0x060034B5 RID: 13493 RVA: 0x00020636 File Offset: 0x0001E836
		' (set) Token: 0x060034B6 RID: 13494 RVA: 0x00020640 File Offset: 0x0001E840
		Friend Overridable Property Label4 As Label

		' Token: 0x17001463 RID: 5219
		' (get) Token: 0x060034B7 RID: 13495 RVA: 0x00020649 File Offset: 0x0001E849
		' (set) Token: 0x060034B8 RID: 13496 RVA: 0x00020653 File Offset: 0x0001E853
		Friend Overridable Property Label2 As Label

		' Token: 0x17001464 RID: 5220
		' (get) Token: 0x060034B9 RID: 13497 RVA: 0x0002065C File Offset: 0x0001E85C
		' (set) Token: 0x060034BA RID: 13498 RVA: 0x00020666 File Offset: 0x0001E866
		Friend Overridable Property Label3 As Label

		' Token: 0x17001465 RID: 5221
		' (get) Token: 0x060034BB RID: 13499 RVA: 0x0002066F File Offset: 0x0001E86F
		' (set) Token: 0x060034BC RID: 13500 RVA: 0x00020679 File Offset: 0x0001E879
		Friend Overridable Property lblRateType As Label

		' Token: 0x17001466 RID: 5222
		' (get) Token: 0x060034BD RID: 13501 RVA: 0x00020682 File Offset: 0x0001E882
		' (set) Token: 0x060034BE RID: 13502 RVA: 0x0002068C File Offset: 0x0001E88C
		Friend Overridable Property Label6 As Label

		' Token: 0x17001467 RID: 5223
		' (get) Token: 0x060034BF RID: 13503 RVA: 0x00020695 File Offset: 0x0001E895
		' (set) Token: 0x060034C0 RID: 13504 RVA: 0x0002069F File Offset: 0x0001E89F
		Friend Overridable Property Label8 As Label

		' Token: 0x17001468 RID: 5224
		' (get) Token: 0x060034C1 RID: 13505 RVA: 0x000206A8 File Offset: 0x0001E8A8
		' (set) Token: 0x060034C2 RID: 13506 RVA: 0x00208620 File Offset: 0x00206820
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

		' Token: 0x17001469 RID: 5225
		' (get) Token: 0x060034C3 RID: 13507 RVA: 0x000206B2 File Offset: 0x0001E8B2
		' (set) Token: 0x060034C4 RID: 13508 RVA: 0x00208664 File Offset: 0x00206864
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

		' Token: 0x1700146A RID: 5226
		' (get) Token: 0x060034C5 RID: 13509 RVA: 0x000206BC File Offset: 0x0001E8BC
		' (set) Token: 0x060034C6 RID: 13510 RVA: 0x002086A8 File Offset: 0x002068A8
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

		' Token: 0x1700146B RID: 5227
		' (get) Token: 0x060034C7 RID: 13511 RVA: 0x000206C6 File Offset: 0x0001E8C6
		' (set) Token: 0x060034C8 RID: 13512 RVA: 0x002086EC File Offset: 0x002068EC
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

		' Token: 0x1700146C RID: 5228
		' (get) Token: 0x060034C9 RID: 13513 RVA: 0x000206D0 File Offset: 0x0001E8D0
		' (set) Token: 0x060034CA RID: 13514 RVA: 0x000206DA File Offset: 0x0001E8DA
		Friend Overridable Property lblBarcode As Label

		' Token: 0x1700146D RID: 5229
		' (get) Token: 0x060034CB RID: 13515 RVA: 0x000206E3 File Offset: 0x0001E8E3
		' (set) Token: 0x060034CC RID: 13516 RVA: 0x000206ED File Offset: 0x0001E8ED
		Friend Overridable Property lblPOSPanel As Label

		' Token: 0x1700146E RID: 5230
		' (get) Token: 0x060034CD RID: 13517 RVA: 0x000206F6 File Offset: 0x0001E8F6
		' (set) Token: 0x060034CE RID: 13518 RVA: 0x00020700 File Offset: 0x0001E900
		Friend Overridable Property Serial_no As DataGridViewTextBoxColumn

		' Token: 0x1700146F RID: 5231
		' (get) Token: 0x060034CF RID: 13519 RVA: 0x00020709 File Offset: 0x0001E909
		' (set) Token: 0x060034D0 RID: 13520 RVA: 0x00020713 File Offset: 0x0001E913
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x060034D1 RID: 13521 RVA: 0x00208730 File Offset: 0x00206930
		Private Sub frmMRPShow_Load(sender As Object, e As EventArgs)
			Me.getdata()
			Me.dgw.Focus()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060034D2 RID: 13522 RVA: 0x002087C4 File Offset: 0x002069C4
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

		' Token: 0x060034D3 RID: 13523 RVA: 0x00208944 File Offset: 0x00206B44
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

		' Token: 0x060034D4 RID: 13524 RVA: 0x00208B7C File Offset: 0x00206D7C
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

		' Token: 0x060034D5 RID: 13525 RVA: 0x00208BFC File Offset: 0x00206DFC
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

		' Token: 0x060034D6 RID: 13526 RVA: 0x00208C7C File Offset: 0x00206E7C
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select serialno1 SerialNumber, barcode from tbl_product_serial_final WHERE " & vbCrLf & "    ProductID = @d1 " & vbCrLf & "    AND Barcode = @d2" & vbCrLf & "    AND Status='PURCHASE'" & vbCrLf & vbCrLf & "/* UNION ALL" & vbCrLf & vbCrLf & "select serialno1 SerialNumber, barcode from tbl_product_serial_final WHERE " & vbCrLf & "    ProductID = @d1 " & vbCrLf & "    AND Barcode = @d2" & vbCrLf & "    AND Status='PURCHASE'" & vbCrLf & "    AND serialno2  <> ''*/ ", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCustomerID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060034D7 RID: 13527 RVA: 0x00208DA4 File Offset: 0x00206FA4
		Private Sub getdata1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Color like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Size like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Info like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Batch like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 4
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Mfgdate like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 5
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.Expdate like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 6
										If flag7 Then
											ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.IMEI1 like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 7
											If flag8 Then
												ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " (Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice), (Stock_Product.TaxableAmt / Stock_Product.Qty), ((Stock_Product.TaxableAmt + Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) / Stock_Product.Qty), RTRIM(Stock_Product.Barcode), RTRIM(Stock_Product.Color), RTRIM(Stock_Product.Size), RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch), RTRIM(Stock_Product.Mfgdate), RTRIM(Stock_Product.Expdate), RTRIM(Stock_Product.IMEI1), RTRIM(Stock_Product.IMEI2),RTRIM(Stock_Product.SP_ID) FROM Stock_Product where Stock_Product.ProductID=@d1 and Stock_Product.Barcode=@d2 and Stock_Product.IMEI2 like N'", Me.TextBox1.Text, "%' order by Stock_Product.MRP DESC" }), ModCommonClasses.con)
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

		' Token: 0x060034D8 RID: 13528 RVA: 0x002092D8 File Offset: 0x002074D8
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

		' Token: 0x060034D9 RID: 13529 RVA: 0x00209608 File Offset: 0x00207808
		Public Sub Retrievedata1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim flag As Boolean = dataGridViewRow.Cells(0).Value.ToString() <> Nothing
				If flag Then
					MyProject.Forms.frmPOSTouch.lblSerialno.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(1)
				Else
					MyProject.Forms.frmPOSTouch.lblSerialno.Text = Conversions.ToString(0)
				End If
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060034DA RID: 13530 RVA: 0x002096D8 File Offset: 0x002078D8
		Public Sub Retrievedata3()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim flag As Boolean = dataGridViewRow.Cells(0).Value.ToString() <> Nothing
				If flag Then
					MyProject.Forms.frmPOSNewTuch.lblSerialno.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtQty.Text = Conversions.ToString(1)
				Else
					MyProject.Forms.frmPOSNewTuch.lblSerialno.Text = Conversions.ToString(0)
				End If
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060034DB RID: 13531 RVA: 0x002097A8 File Offset: 0x002079A8
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

		' Token: 0x060034DC RID: 13532 RVA: 0x00209838 File Offset: 0x00207A38
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

		' Token: 0x060034DD RID: 13533 RVA: 0x002098B8 File Offset: 0x00207AB8
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

		' Token: 0x060034DE RID: 13534 RVA: 0x002099A0 File Offset: 0x00207BA0
		Private Sub frmMRPShow_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = (e.KeyCode = Keys.F4) And (e.Modifiers = Keys.Alt)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060034DF RID: 13535 RVA: 0x002099D4 File Offset: 0x00207BD4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.NumericUpDown1.Value = Conversions.ToDecimal("5")
			Me.getdata()
			Me.dgw.Focus()
		End Sub

		' Token: 0x060034E0 RID: 13536 RVA: 0x0002071C File Offset: 0x0001E91C
		Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x060034E1 RID: 13537 RVA: 0x00020726 File Offset: 0x0001E926
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.getdata1()
		End Sub

		' Token: 0x060034E2 RID: 13538 RVA: 0x00020730 File Offset: 0x0001E930
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x060034E3 RID: 13539 RVA: 0x00020750 File Offset: 0x0001E950
		Private Sub frmMRPShow_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.lblPOSPanel.Text = ""
		End Sub
	End Class
End Namespace
