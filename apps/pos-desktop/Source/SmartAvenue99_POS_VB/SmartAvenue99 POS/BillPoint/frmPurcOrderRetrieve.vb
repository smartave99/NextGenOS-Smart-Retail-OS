Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000363 RID: 867
	<DesignerGenerated()>
	Public Partial Class frmPurcOrderRetrieve
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CDF6 RID: 52726 RVA: 0x0080A1AC File Offset: 0x008083AC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurcOrderRetrieve_Load
			AddHandler MyBase.Closing, AddressOf Me.frmPurcOrderRetrieve_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurcOrderRetrieve_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170050EC RID: 20716
		' (get) Token: 0x0600CDF9 RID: 52729 RVA: 0x0005B967 File Offset: 0x00059B67
		' (set) Token: 0x0600CDFA RID: 52730 RVA: 0x0005B971 File Offset: 0x00059B71
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170050ED RID: 20717
		' (get) Token: 0x0600CDFB RID: 52731 RVA: 0x0005B97A File Offset: 0x00059B7A
		' (set) Token: 0x0600CDFC RID: 52732 RVA: 0x0005B984 File Offset: 0x00059B84
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170050EE RID: 20718
		' (get) Token: 0x0600CDFD RID: 52733 RVA: 0x0005B98D File Offset: 0x00059B8D
		' (set) Token: 0x0600CDFE RID: 52734 RVA: 0x0080B2CC File Offset: 0x008094CC
		Private _btnExportExcel As Button
		Friend Overridable Property btnExportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim button As Button = Me._btnExportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExportExcel = value
				button = Me._btnExportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050EF RID: 20719
		' (get) Token: 0x0600CDFF RID: 52735 RVA: 0x0005B997 File Offset: 0x00059B97
		' (set) Token: 0x0600CE00 RID: 52736 RVA: 0x0080B310 File Offset: 0x00809510
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

		' Token: 0x170050F0 RID: 20720
		' (get) Token: 0x0600CE01 RID: 52737 RVA: 0x0005B9A1 File Offset: 0x00059BA1
		' (set) Token: 0x0600CE02 RID: 52738 RVA: 0x0005B9AB File Offset: 0x00059BAB
		Friend Overridable Property btnReset As Button

		' Token: 0x170050F1 RID: 20721
		' (get) Token: 0x0600CE03 RID: 52739 RVA: 0x0005B9B4 File Offset: 0x00059BB4
		' (set) Token: 0x0600CE04 RID: 52740 RVA: 0x0005B9BE File Offset: 0x00059BBE
		Friend Overridable Property Label5 As Label

		' Token: 0x170050F2 RID: 20722
		' (get) Token: 0x0600CE05 RID: 52741 RVA: 0x0005B9C7 File Offset: 0x00059BC7
		' (set) Token: 0x0600CE06 RID: 52742 RVA: 0x0005B9D1 File Offset: 0x00059BD1
		Friend Overridable Property Label1 As Label

		' Token: 0x170050F3 RID: 20723
		' (get) Token: 0x0600CE07 RID: 52743 RVA: 0x0005B9DA File Offset: 0x00059BDA
		' (set) Token: 0x0600CE08 RID: 52744 RVA: 0x0080B354 File Offset: 0x00809554
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

		' Token: 0x170050F4 RID: 20724
		' (get) Token: 0x0600CE09 RID: 52745 RVA: 0x0005B9E4 File Offset: 0x00059BE4
		' (set) Token: 0x0600CE0A RID: 52746 RVA: 0x0005B9EE File Offset: 0x00059BEE
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170050F5 RID: 20725
		' (get) Token: 0x0600CE0B RID: 52747 RVA: 0x0005B9F7 File Offset: 0x00059BF7
		' (set) Token: 0x0600CE0C RID: 52748 RVA: 0x0005BA01 File Offset: 0x00059C01
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170050F6 RID: 20726
		' (get) Token: 0x0600CE0D RID: 52749 RVA: 0x0005BA0A File Offset: 0x00059C0A
		' (set) Token: 0x0600CE0E RID: 52750 RVA: 0x0005BA14 File Offset: 0x00059C14
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170050F7 RID: 20727
		' (get) Token: 0x0600CE0F RID: 52751 RVA: 0x0005BA1D File Offset: 0x00059C1D
		' (set) Token: 0x0600CE10 RID: 52752 RVA: 0x0005BA27 File Offset: 0x00059C27
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170050F8 RID: 20728
		' (get) Token: 0x0600CE11 RID: 52753 RVA: 0x0005BA30 File Offset: 0x00059C30
		' (set) Token: 0x0600CE12 RID: 52754 RVA: 0x0005BA3A File Offset: 0x00059C3A
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170050F9 RID: 20729
		' (get) Token: 0x0600CE13 RID: 52755 RVA: 0x0005BA43 File Offset: 0x00059C43
		' (set) Token: 0x0600CE14 RID: 52756 RVA: 0x0005BA4D File Offset: 0x00059C4D
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170050FA RID: 20730
		' (get) Token: 0x0600CE15 RID: 52757 RVA: 0x0005BA56 File Offset: 0x00059C56
		' (set) Token: 0x0600CE16 RID: 52758 RVA: 0x0005BA60 File Offset: 0x00059C60
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170050FB RID: 20731
		' (get) Token: 0x0600CE17 RID: 52759 RVA: 0x0005BA69 File Offset: 0x00059C69
		' (set) Token: 0x0600CE18 RID: 52760 RVA: 0x0005BA73 File Offset: 0x00059C73
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170050FC RID: 20732
		' (get) Token: 0x0600CE19 RID: 52761 RVA: 0x0005BA7C File Offset: 0x00059C7C
		' (set) Token: 0x0600CE1A RID: 52762 RVA: 0x0005BA86 File Offset: 0x00059C86
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170050FD RID: 20733
		' (get) Token: 0x0600CE1B RID: 52763 RVA: 0x0005BA8F File Offset: 0x00059C8F
		' (set) Token: 0x0600CE1C RID: 52764 RVA: 0x0005BA99 File Offset: 0x00059C99
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170050FE RID: 20734
		' (get) Token: 0x0600CE1D RID: 52765 RVA: 0x0005BAA2 File Offset: 0x00059CA2
		' (set) Token: 0x0600CE1E RID: 52766 RVA: 0x0005BAAC File Offset: 0x00059CAC
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170050FF RID: 20735
		' (get) Token: 0x0600CE1F RID: 52767 RVA: 0x0005BAB5 File Offset: 0x00059CB5
		' (set) Token: 0x0600CE20 RID: 52768 RVA: 0x0005BABF File Offset: 0x00059CBF
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17005100 RID: 20736
		' (get) Token: 0x0600CE21 RID: 52769 RVA: 0x0005BAC8 File Offset: 0x00059CC8
		' (set) Token: 0x0600CE22 RID: 52770 RVA: 0x0005BAD2 File Offset: 0x00059CD2
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17005101 RID: 20737
		' (get) Token: 0x0600CE23 RID: 52771 RVA: 0x0005BADB File Offset: 0x00059CDB
		' (set) Token: 0x0600CE24 RID: 52772 RVA: 0x0005BAE5 File Offset: 0x00059CE5
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17005102 RID: 20738
		' (get) Token: 0x0600CE25 RID: 52773 RVA: 0x0005BAEE File Offset: 0x00059CEE
		' (set) Token: 0x0600CE26 RID: 52774 RVA: 0x0005BAF8 File Offset: 0x00059CF8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005103 RID: 20739
		' (get) Token: 0x0600CE27 RID: 52775 RVA: 0x0005BB01 File Offset: 0x00059D01
		' (set) Token: 0x0600CE28 RID: 52776 RVA: 0x0005BB0B File Offset: 0x00059D0B
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x0600CE29 RID: 52777 RVA: 0x0080B3B4 File Offset: 0x008095B4
		Private Sub frmPurcOrderRetrieve_Load(sender As Object, e As EventArgs)
			Me.fillPurcOrderNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
		End Sub

		' Token: 0x0600CE2A RID: 52778 RVA: 0x0080B440 File Offset: 0x00809640
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

		' Token: 0x0600CE2B RID: 52779 RVA: 0x0080B528 File Offset: 0x00809728
		Public Sub fillPurcOrderNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PONo) FROM PurchaseOrder", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600CE2C RID: 52780 RVA: 0x0080B65C File Offset: 0x0080985C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and PurchaseOrder.PONo='" + Me.ComboBox1.Text + "'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CE2D RID: 52781 RVA: 0x0005BB14 File Offset: 0x00059D14
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600CE2E RID: 52782 RVA: 0x0080B830 File Offset: 0x00809A30
		Public Sub Retrieve1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPurchaseEntry.txtReferenceNo1.Text = dataGridViewRow.Cells(1).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.cmbReverse.Text = "No"
				MyProject.Forms.frmPurchaseEntry.lbltaxtype.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtSup_ID.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtSupplierID.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(7).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtSubTotal.Text = dataGridViewRow.Cells(8).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtCGST.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtSGST.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtIGST.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.txtCESS.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPurchaseEntry.limitsearch()
				MyProject.Forms.frmPurchaseEntry.btnSave.Enabled = True
				MyProject.Forms.frmPurchaseEntry.GetSupplierBalance1()
				MyProject.Forms.frmPurchaseEntry.btnDelete.Enabled = False
				MyProject.Forms.frmPurchaseEntry.btnUpdate.Enabled = False
				MyProject.Forms.frmPurchaseEntry.GetSupplierInfo()
				MyProject.Forms.frmPurchaseEntry.btnSelection.Enabled = True
				MyProject.Forms.frmPurchaseEntry.lblSet.Text = "Not Allowed"
				Dim flag As Boolean = Operators.CompareString(MyProject.Forms.frmPurchaseEntry.txtGSTNonGST.Text, MyProject.Forms.frmPurchaseEntry.lbltaxtype.Text, False) <> 0
				If flag Then
					MessageBox.Show("Purchase Order Tax Type and your configured Tax Type is not same." & vbCrLf & "Please Configure it", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyProject.Forms.frmPurchaseEntry.Reset()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(PurchaseOrder_Join.Barcode),Qty, Price, Price, DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,'0',(PurchaseOrder_Join.TaxableAmt),Qty,RTRIM(Product.PurchaseUnit),RTRIM(Product.PTax),(Product.SellingPrice),(Product.ReorderPoint),RTRIM(PurchaseOrder_Join.RCipher),RTRIM(PurchaseOrder_Join.WCipher),RTRIM(Category),RTRIM(Product.PurchaseUnit) from Product,PurchaseOrder,PurchaseOrder_Join,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=PurchaseOrder_Join.ProductID and PurchaseOrder.PO_ID=PurchaseOrder_Join.PurchaseOrderID and PO_ID=", dataGridViewRow.Cells(0).Value), ""))
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), "", "", "", "", "", "", ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), "", "" })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPurchaseEntry.DataGridView1.ClearSelection()
					MyProject.Forms.frmPurchaseEntry.Calc()
					MyProject.Forms.frmPurchaseEntry.Compute()
					MyProject.Forms.frmPurchaseEntry.GetQty_S1()
					MyProject.Forms.frmPurchaseEntry.txtTotalAmount.Text = "0.00"
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE2F RID: 52783 RVA: 0x0080BE8C File Offset: 0x0080A08C
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Me.Retrieve1()
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CE30 RID: 52784 RVA: 0x0005BB1E File Offset: 0x00059D1E
		Private Sub frmPurcOrderRetrieve_Closing(sender As Object, e As CancelEventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x0600CE31 RID: 52785 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurcOrderRetrieve_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CE32 RID: 52786 RVA: 0x0080BECC File Offset: 0x0080A0CC
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
