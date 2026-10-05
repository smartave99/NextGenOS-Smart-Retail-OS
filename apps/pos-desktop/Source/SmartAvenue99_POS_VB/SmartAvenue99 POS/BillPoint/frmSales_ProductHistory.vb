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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F7 RID: 503
	<DesignerGenerated()>
	Public Partial Class frmSales_ProductHistory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008FB6 RID: 36790 RVA: 0x0004639C File Offset: 0x0004459C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003520 RID: 13600
		' (get) Token: 0x06008FB9 RID: 36793 RVA: 0x000463CE File Offset: 0x000445CE
		' (set) Token: 0x06008FBA RID: 36794 RVA: 0x000463D8 File Offset: 0x000445D8
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003521 RID: 13601
		' (get) Token: 0x06008FBB RID: 36795 RVA: 0x000463E1 File Offset: 0x000445E1
		' (set) Token: 0x06008FBC RID: 36796 RVA: 0x0068D6F8 File Offset: 0x0068B8F8
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003522 RID: 13602
		' (get) Token: 0x06008FBD RID: 36797 RVA: 0x000463EB File Offset: 0x000445EB
		' (set) Token: 0x06008FBE RID: 36798 RVA: 0x000463F5 File Offset: 0x000445F5
		Friend Overridable Property Label1 As Label

		' Token: 0x17003523 RID: 13603
		' (get) Token: 0x06008FBF RID: 36799 RVA: 0x000463FE File Offset: 0x000445FE
		' (set) Token: 0x06008FC0 RID: 36800 RVA: 0x00046408 File Offset: 0x00044608
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003524 RID: 13604
		' (get) Token: 0x06008FC1 RID: 36801 RVA: 0x00046411 File Offset: 0x00044611
		' (set) Token: 0x06008FC2 RID: 36802 RVA: 0x0004641B File Offset: 0x0004461B
		Friend Overridable Property Label6 As Label

		' Token: 0x17003525 RID: 13605
		' (get) Token: 0x06008FC3 RID: 36803 RVA: 0x00046424 File Offset: 0x00044624
		' (set) Token: 0x06008FC4 RID: 36804 RVA: 0x0004642E File Offset: 0x0004462E
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17003526 RID: 13606
		' (get) Token: 0x06008FC5 RID: 36805 RVA: 0x00046437 File Offset: 0x00044637
		' (set) Token: 0x06008FC6 RID: 36806 RVA: 0x00046441 File Offset: 0x00044641
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003527 RID: 13607
		' (get) Token: 0x06008FC7 RID: 36807 RVA: 0x0004644A File Offset: 0x0004464A
		' (set) Token: 0x06008FC8 RID: 36808 RVA: 0x00046454 File Offset: 0x00044654
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003528 RID: 13608
		' (get) Token: 0x06008FC9 RID: 36809 RVA: 0x0004645D File Offset: 0x0004465D
		' (set) Token: 0x06008FCA RID: 36810 RVA: 0x00046467 File Offset: 0x00044667
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003529 RID: 13609
		' (get) Token: 0x06008FCB RID: 36811 RVA: 0x00046470 File Offset: 0x00044670
		' (set) Token: 0x06008FCC RID: 36812 RVA: 0x0004647A File Offset: 0x0004467A
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700352A RID: 13610
		' (get) Token: 0x06008FCD RID: 36813 RVA: 0x00046483 File Offset: 0x00044683
		' (set) Token: 0x06008FCE RID: 36814 RVA: 0x0004648D File Offset: 0x0004468D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700352B RID: 13611
		' (get) Token: 0x06008FCF RID: 36815 RVA: 0x00046496 File Offset: 0x00044696
		' (set) Token: 0x06008FD0 RID: 36816 RVA: 0x000464A0 File Offset: 0x000446A0
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700352C RID: 13612
		' (get) Token: 0x06008FD1 RID: 36817 RVA: 0x000464A9 File Offset: 0x000446A9
		' (set) Token: 0x06008FD2 RID: 36818 RVA: 0x000464B3 File Offset: 0x000446B3
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700352D RID: 13613
		' (get) Token: 0x06008FD3 RID: 36819 RVA: 0x000464BC File Offset: 0x000446BC
		' (set) Token: 0x06008FD4 RID: 36820 RVA: 0x000464C6 File Offset: 0x000446C6
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700352E RID: 13614
		' (get) Token: 0x06008FD5 RID: 36821 RVA: 0x000464CF File Offset: 0x000446CF
		' (set) Token: 0x06008FD6 RID: 36822 RVA: 0x000464D9 File Offset: 0x000446D9
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700352F RID: 13615
		' (get) Token: 0x06008FD7 RID: 36823 RVA: 0x000464E2 File Offset: 0x000446E2
		' (set) Token: 0x06008FD8 RID: 36824 RVA: 0x000464EC File Offset: 0x000446EC
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003530 RID: 13616
		' (get) Token: 0x06008FD9 RID: 36825 RVA: 0x000464F5 File Offset: 0x000446F5
		' (set) Token: 0x06008FDA RID: 36826 RVA: 0x000464FF File Offset: 0x000446FF
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003531 RID: 13617
		' (get) Token: 0x06008FDB RID: 36827 RVA: 0x00046508 File Offset: 0x00044708
		' (set) Token: 0x06008FDC RID: 36828 RVA: 0x00046512 File Offset: 0x00044712
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003532 RID: 13618
		' (get) Token: 0x06008FDD RID: 36829 RVA: 0x0004651B File Offset: 0x0004471B
		' (set) Token: 0x06008FDE RID: 36830 RVA: 0x00046525 File Offset: 0x00044725
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003533 RID: 13619
		' (get) Token: 0x06008FDF RID: 36831 RVA: 0x0004652E File Offset: 0x0004472E
		' (set) Token: 0x06008FE0 RID: 36832 RVA: 0x00046538 File Offset: 0x00044738
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003534 RID: 13620
		' (get) Token: 0x06008FE1 RID: 36833 RVA: 0x00046541 File Offset: 0x00044741
		' (set) Token: 0x06008FE2 RID: 36834 RVA: 0x0004654B File Offset: 0x0004474B
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003535 RID: 13621
		' (get) Token: 0x06008FE3 RID: 36835 RVA: 0x00046554 File Offset: 0x00044754
		' (set) Token: 0x06008FE4 RID: 36836 RVA: 0x0004655E File Offset: 0x0004475E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003536 RID: 13622
		' (get) Token: 0x06008FE5 RID: 36837 RVA: 0x00046567 File Offset: 0x00044767
		' (set) Token: 0x06008FE6 RID: 36838 RVA: 0x00046571 File Offset: 0x00044771
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003537 RID: 13623
		' (get) Token: 0x06008FE7 RID: 36839 RVA: 0x0004657A File Offset: 0x0004477A
		' (set) Token: 0x06008FE8 RID: 36840 RVA: 0x00046584 File Offset: 0x00044784
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003538 RID: 13624
		' (get) Token: 0x06008FE9 RID: 36841 RVA: 0x0004658D File Offset: 0x0004478D
		' (set) Token: 0x06008FEA RID: 36842 RVA: 0x00046597 File Offset: 0x00044797
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17003539 RID: 13625
		' (get) Token: 0x06008FEB RID: 36843 RVA: 0x000465A0 File Offset: 0x000447A0
		' (set) Token: 0x06008FEC RID: 36844 RVA: 0x000465AA File Offset: 0x000447AA
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700353A RID: 13626
		' (get) Token: 0x06008FED RID: 36845 RVA: 0x000465B3 File Offset: 0x000447B3
		' (set) Token: 0x06008FEE RID: 36846 RVA: 0x000465BD File Offset: 0x000447BD
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700353B RID: 13627
		' (get) Token: 0x06008FEF RID: 36847 RVA: 0x000465C6 File Offset: 0x000447C6
		' (set) Token: 0x06008FF0 RID: 36848 RVA: 0x000465D0 File Offset: 0x000447D0
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700353C RID: 13628
		' (get) Token: 0x06008FF1 RID: 36849 RVA: 0x000465D9 File Offset: 0x000447D9
		' (set) Token: 0x06008FF2 RID: 36850 RVA: 0x000465E3 File Offset: 0x000447E3
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700353D RID: 13629
		' (get) Token: 0x06008FF3 RID: 36851 RVA: 0x000465EC File Offset: 0x000447EC
		' (set) Token: 0x06008FF4 RID: 36852 RVA: 0x000465F6 File Offset: 0x000447F6
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700353E RID: 13630
		' (get) Token: 0x06008FF5 RID: 36853 RVA: 0x000465FF File Offset: 0x000447FF
		' (set) Token: 0x06008FF6 RID: 36854 RVA: 0x00046609 File Offset: 0x00044809
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700353F RID: 13631
		' (get) Token: 0x06008FF7 RID: 36855 RVA: 0x00046612 File Offset: 0x00044812
		' (set) Token: 0x06008FF8 RID: 36856 RVA: 0x0004661C File Offset: 0x0004481C
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17003540 RID: 13632
		' (get) Token: 0x06008FF9 RID: 36857 RVA: 0x00046625 File Offset: 0x00044825
		' (set) Token: 0x06008FFA RID: 36858 RVA: 0x0004662F File Offset: 0x0004482F
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17003541 RID: 13633
		' (get) Token: 0x06008FFB RID: 36859 RVA: 0x00046638 File Offset: 0x00044838
		' (set) Token: 0x06008FFC RID: 36860 RVA: 0x00046642 File Offset: 0x00044842
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003542 RID: 13634
		' (get) Token: 0x06008FFD RID: 36861 RVA: 0x0004664B File Offset: 0x0004484B
		' (set) Token: 0x06008FFE RID: 36862 RVA: 0x00046655 File Offset: 0x00044855
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003543 RID: 13635
		' (get) Token: 0x06008FFF RID: 36863 RVA: 0x0004665E File Offset: 0x0004485E
		' (set) Token: 0x06009000 RID: 36864 RVA: 0x00046668 File Offset: 0x00044868
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003544 RID: 13636
		' (get) Token: 0x06009001 RID: 36865 RVA: 0x00046671 File Offset: 0x00044871
		' (set) Token: 0x06009002 RID: 36866 RVA: 0x0004667B File Offset: 0x0004487B
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003545 RID: 13637
		' (get) Token: 0x06009003 RID: 36867 RVA: 0x00046684 File Offset: 0x00044884
		' (set) Token: 0x06009004 RID: 36868 RVA: 0x0004668E File Offset: 0x0004488E
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003546 RID: 13638
		' (get) Token: 0x06009005 RID: 36869 RVA: 0x00046697 File Offset: 0x00044897
		' (set) Token: 0x06009006 RID: 36870 RVA: 0x000466A1 File Offset: 0x000448A1
		Friend Overridable Property lblBarcode As Label

		' Token: 0x17003547 RID: 13639
		' (get) Token: 0x06009007 RID: 36871 RVA: 0x000466AA File Offset: 0x000448AA
		' (set) Token: 0x06009008 RID: 36872 RVA: 0x000466B4 File Offset: 0x000448B4
		Friend Overridable Property lblCustomerId As Label

		' Token: 0x17003548 RID: 13640
		' (get) Token: 0x06009009 RID: 36873 RVA: 0x000466BD File Offset: 0x000448BD
		' (set) Token: 0x0600900A RID: 36874 RVA: 0x000466C7 File Offset: 0x000448C7
		Friend Overridable Property Label10 As Label

		' Token: 0x17003549 RID: 13641
		' (get) Token: 0x0600900B RID: 36875 RVA: 0x000466D0 File Offset: 0x000448D0
		' (set) Token: 0x0600900C RID: 36876 RVA: 0x000466DA File Offset: 0x000448DA
		Friend Overridable Property Label11 As Label

		' Token: 0x1700354A RID: 13642
		' (get) Token: 0x0600900D RID: 36877 RVA: 0x000466E3 File Offset: 0x000448E3
		' (set) Token: 0x0600900E RID: 36878 RVA: 0x000466ED File Offset: 0x000448ED
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x0600900F RID: 36879 RVA: 0x0068D758 File Offset: 0x0068B958
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.Customer_ID = @custid and Invoice_Product.Barcode = @barcode order by Invoiceinfo.InvoiceDate desc", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@custid", SqlDbType.VarChar).Value = Me.lblCustomerId.Text
				ModCommonClasses.cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = Me.lblBarcode.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009010 RID: 36880 RVA: 0x0068DA9C File Offset: 0x0068BC9C
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06009011 RID: 36881 RVA: 0x0068DB2C File Offset: 0x0068BD2C
		Public Sub Convert_Language()
			Dim text As String = "Select default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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

		' Token: 0x06009012 RID: 36882 RVA: 0x0068DCA4 File Offset: 0x0068BEA4
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

		' Token: 0x06009013 RID: 36883 RVA: 0x0068DD70 File Offset: 0x0068BF70
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

		' Token: 0x06009014 RID: 36884 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06009015 RID: 36885 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06009016 RID: 36886 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06009017 RID: 36887 RVA: 0x0068DE3C File Offset: 0x0068C03C
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

		' Token: 0x06009018 RID: 36888 RVA: 0x000466F6 File Offset: 0x000448F6
		Public Sub Reset()
			Me.Getdata()
		End Sub

		' Token: 0x06009019 RID: 36889 RVA: 0x0068DF24 File Offset: 0x0068C124
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.cpy = dataGridViewRow.Cells(0).Value.ToString()
				Clipboard.SetDataObject(Me.cpy)
				MessageBox.Show("Invoice Number is Copied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600901A RID: 36890 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmSalesInvoiceRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x0600901B RID: 36891 RVA: 0x0068DFA4 File Offset: 0x0068C1A4
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600901C RID: 36892 RVA: 0x00046700 File Offset: 0x00044900
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600901D RID: 36893 RVA: 0x0068E0BC File Offset: 0x0068C2BC
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

		' Token: 0x04003FC9 RID: 16329
		Private cpy As String
	End Class
End Namespace
