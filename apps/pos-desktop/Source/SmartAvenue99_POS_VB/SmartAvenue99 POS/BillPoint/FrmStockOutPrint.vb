Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000601 RID: 1537
	<DesignerGenerated()>
	Public Partial Class FrmStockOutPrint
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012B55 RID: 76629 RVA: 0x00ABDE4C File Offset: 0x00ABC04C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmStockOutPrint_Load
			Me.CompanyName = ""
			Me.Address = ""
			Me.ContactNo = ""
			Me.EmailID = ""
			Me.GSTIN = ""
			Me.State = ""
			Me.FYFrom = ""
			Me.FYTo = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700740B RID: 29707
		' (get) Token: 0x06012B58 RID: 76632 RVA: 0x0007FC85 File Offset: 0x0007DE85
		' (set) Token: 0x06012B59 RID: 76633 RVA: 0x00ABE764 File Offset: 0x00ABC964
		Private _ListView2 As ListView
		Friend Overridable Property ListView2 As ListView
			<CompilerGenerated()>
			Get
				Return Me._ListView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.ListView2_MouseDoubleClick
				Dim listView As ListView = Me._ListView2
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
				End If
				Me._ListView2 = value
				listView = Me._ListView2
				If listView IsNot Nothing Then
					AddHandler listView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700740C RID: 29708
		' (get) Token: 0x06012B5A RID: 76634 RVA: 0x0007FC8F File Offset: 0x0007DE8F
		' (set) Token: 0x06012B5B RID: 76635 RVA: 0x0007FC99 File Offset: 0x0007DE99
		Friend Overridable Property ColumnHeader76 As ColumnHeader

		' Token: 0x1700740D RID: 29709
		' (get) Token: 0x06012B5C RID: 76636 RVA: 0x0007FCA2 File Offset: 0x0007DEA2
		' (set) Token: 0x06012B5D RID: 76637 RVA: 0x0007FCAC File Offset: 0x0007DEAC
		Friend Overridable Property ColumnHeader39 As ColumnHeader

		' Token: 0x1700740E RID: 29710
		' (get) Token: 0x06012B5E RID: 76638 RVA: 0x0007FCB5 File Offset: 0x0007DEB5
		' (set) Token: 0x06012B5F RID: 76639 RVA: 0x00ABE7A8 File Offset: 0x00ABC9A8
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

		' Token: 0x1700740F RID: 29711
		' (get) Token: 0x06012B60 RID: 76640 RVA: 0x0007FCBF File Offset: 0x0007DEBF
		' (set) Token: 0x06012B61 RID: 76641 RVA: 0x0007FCC9 File Offset: 0x0007DEC9
		Friend Overridable Property Label2 As Label

		' Token: 0x17007410 RID: 29712
		' (get) Token: 0x06012B62 RID: 76642 RVA: 0x0007FCD2 File Offset: 0x0007DED2
		' (set) Token: 0x06012B63 RID: 76643 RVA: 0x00ABE7EC File Offset: 0x00ABC9EC
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007411 RID: 29713
		' (get) Token: 0x06012B64 RID: 76644 RVA: 0x0007FCDC File Offset: 0x0007DEDC
		' (set) Token: 0x06012B65 RID: 76645 RVA: 0x00ABE830 File Offset: 0x00ABCA30
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

		' Token: 0x17007412 RID: 29714
		' (get) Token: 0x06012B66 RID: 76646 RVA: 0x0007FCE6 File Offset: 0x0007DEE6
		' (set) Token: 0x06012B67 RID: 76647 RVA: 0x0007FCF0 File Offset: 0x0007DEF0
		Friend Overridable Property Label6 As Label

		' Token: 0x17007413 RID: 29715
		' (get) Token: 0x06012B68 RID: 76648 RVA: 0x0007FCF9 File Offset: 0x0007DEF9
		' (set) Token: 0x06012B69 RID: 76649 RVA: 0x0007FD03 File Offset: 0x0007DF03
		Friend Overridable Property Label7 As Label

		' Token: 0x17007414 RID: 29716
		' (get) Token: 0x06012B6A RID: 76650 RVA: 0x0007FD0C File Offset: 0x0007DF0C
		' (set) Token: 0x06012B6B RID: 76651 RVA: 0x0007FD16 File Offset: 0x0007DF16
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x06012B6C RID: 76652 RVA: 0x0007FD1F File Offset: 0x0007DF1F
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.GetData()
		End Sub

		' Token: 0x06012B6D RID: 76653 RVA: 0x00ABE874 File Offset: 0x00ABCA74
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.GetData()
			End If
		End Sub

		' Token: 0x06012B6E RID: 76654 RVA: 0x00ABE89C File Offset: 0x00ABCA9C
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, "  TocknNo, COUNT(*) as ProductCount FROM P_Transfer WHERE TocknNo like N'", Me.TextBox1.Text, "%' and PStatus = 'o' GROUP BY TocknNo" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView2.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					Me.ListView2.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B6F RID: 76655 RVA: 0x0007FD29 File Offset: 0x0007DF29
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.rePrint()
		End Sub

		' Token: 0x06012B70 RID: 76656 RVA: 0x00ABE9F4 File Offset: 0x00ABCBF4
		Public Function rePrint() As Object
			Try
				Dim num As Integer = Me.ListView2.Items.IndexOf(Me.ListView2.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.ListView2.Items(num)
				Dim rptP_Transfer As rptP_Transfer = New rptP_Transfer()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,QrBarcode,T_Qty,TocknNo,Category,SubCategoryName FROM P_Transfer WHERE TocknNo like N'" + listViewItem.Text + "%' and PStatus = 'o'"
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter.Fill(dataSet, "p_transfer")
				rptP_Transfer.SetDataSource(dataSet)
				rptP_Transfer.SetParameterValue("CompanyName", Me.CompanyName)
				rptP_Transfer.SetParameterValue("Address", Me.Address)
				rptP_Transfer.SetParameterValue("ContactNo", Me.ContactNo)
				rptP_Transfer.SetParameterValue("EmailID", Me.EmailID)
				rptP_Transfer.SetParameterValue("GSTIN", Me.GSTIN)
				rptP_Transfer.SetParameterValue("State", Me.State)
				rptP_Transfer.SetParameterValue("FYFrom", Me.FYFrom)
				rptP_Transfer.SetParameterValue("FYTo", Me.FYTo)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptP_Transfer
				MyProject.Forms.frmReport.ShowDialog()
				rptP_Transfer.Close()
				rptP_Transfer.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012B71 RID: 76657 RVA: 0x00ABEBBC File Offset: 0x00ABCDBC
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(ID), RTRIM(CompanyName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(State), RTRIM(FYFrom), RTRIM(FYTo), RTRIM(AndroidID), RTRIM(CurSym) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.CompanyName = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.Address = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.ContactNo = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.EmailID = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.GSTIN = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.State = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.FYFrom = Conversions.ToString(ModCommonClasses.rdr.GetValue(7))
					Me.FYTo = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012B72 RID: 76658 RVA: 0x0007FD29 File Offset: 0x0007DF29
		Private Sub ListView2_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.rePrint()
		End Sub

		' Token: 0x06012B73 RID: 76659 RVA: 0x0007FD33 File Offset: 0x0007DF33
		Private Sub FrmStockOutPrint_Load(sender As Object, e As EventArgs)
			Me.CompanyInfoDisplay()
		End Sub

		' Token: 0x040070A3 RID: 28835
		Private CompanyName As String

		' Token: 0x040070A4 RID: 28836
		Private Address As String

		' Token: 0x040070A5 RID: 28837
		Private ContactNo As String

		' Token: 0x040070A6 RID: 28838
		Private EmailID As String

		' Token: 0x040070A7 RID: 28839
		Private GSTIN As String

		' Token: 0x040070A8 RID: 28840
		Private State As String

		' Token: 0x040070A9 RID: 28841
		Private FYFrom As String

		' Token: 0x040070AA RID: 28842
		Private FYTo As String
	End Class
End Namespace
